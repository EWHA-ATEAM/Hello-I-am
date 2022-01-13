# 필요한 모델 임포트
import pandas as pd
import tensorflow as tf
from tensorflow.keras import preprocessing
from tensorflow.keras.models import Model
from tensorflow.keras.layers import Input, Embedding, Dense, Dropout, Conv1D, GlobalMaxPool1D, concatenate

# 데이터 읽어오기
train_file = "./ChatbotData.csv"
data = pd.read_csv(train_file,delimiter=',')
# ChatbotData.csv 파일에서 Q는 질문, label은 라벨링한 감정을 의미합니다.
# tolist()함수를 통해 리스트로 만들기
features = data['Q'].tolist()
labels = data['label'].tolist()

# 단어 인덱스 시퀀스 벡터
corpus = [preprocessing.text.text_to_word_sequence(text) for text in features]
# text_to_word_sequence(text) 함수를 통해 text를 단어 시퀀스로  만듭니다.
# 단어 시퀀스란? 단어 토큰들의 순차적 리스트를 의미합니다.
# ex) features[0]="3박4일 놀러가고 싶다." -> corpus[0]=['3박4일', '놀러가고', '싶다']
# 이렇게 생성한 말뭉치를 corpus에 저장합니다.
tokenizer = preprocessing.text.Tokenizer()  # 텐서플로의 토크나이저
tokenizer.fit_on_texts(corpus)
# texts_to_sequences(corpus)함수를 통해 corpus 내 모든 단어(토큰)를 시퀀스 번호로 변환합니다.
# 변환된 시퀀스 번호를 이용해 단어 임베딩 벡터를 만들겠습니다.
sequences = tokenizer.texts_to_sequences(corpus)
# ex) corpus[0]=['3박4일', '놀러가고', '싶다'] -> sequences[0]=[2580, 803, 11]
# 이렇게 시퀀스 번호로 생성한 벡터에는 문제점이 있습니다.
# 바로, 문장길이가 제각각이기 때문에 벡터 크기가 다 다르다는 것입니다.
# 하지만, CNN 모델의 입력 계층은 고정된 개수의 뉴런 (입력 노드)을 가집니다...!
word_index = tokenizer.word_index   # 모든 단어의 인덱스 (-> 단어 총개수 구하는 데에 쓰임)

# 최대 단어 시퀀스 벡터 크기
MAX_SEQ_LEN = 15
# padding은 앞을 0으로 채울것인지 (pre), 뒤를 0으로 채울것인지 (post) 정하는 인자입니다.
padded_seqs=preprocessing.sequence.pad_sequences(sequences, maxlen=MAX_SEQ_LEN, padding='post')
# ex) sequences[0]=[2580, 803, 11] -> padded_seqs[0]=[2580, 803, 11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0] (크기가 15인 벡터)

# 학습 데이터셋 : 검증 데이터셋 : 테스트 데이터셋 = 7 : 2 : 1
ds = tf.data.Dataset.from_tensor_slices((padded_seqs, labels))    # x: padded_seqs, y: labels
ds = ds.shuffle(len(features))  # len(features) = 데이터셋의 문장 수

# 약 10000개의 데이터
train_size = int(len(padded_seqs)*0.7)  # 약 7000
val_size = int(len(padded_seqs)*0.2)    # 약 2000
test_size = int(len(padded_seqs)*0.1)   # 약 1000

train_ds = ds.take(train_size).batch(20)
val_ds = ds.skip(train_size).take(val_size).batch(20)
test_ds = ds.skip(train_size+val_size).take(test_size).batch(20)

# 하이퍼파라미터 설정하기
dropout_prob = 0.5
EMB_SIZE = 128
EPOCH = 5
VOCAB_SIZE = len(word_index)+1  # 전체 단어 수

# CNN 모델 정의하기
# 함수형 모델 방식으로 구현

# 단어 임베딩 영역 (1번째 단계)
# 입력층
input_layer = Input(shape=(MAX_SEQ_LEN, ))
# 임베딩 계층
embedding_layer = Embedding(VOCAB_SIZE, EMB_SIZE, input_length=MAX_SEQ_LEN)(input_layer)
# 드롭아웃 계층
dropout_emb = Dropout(rate=dropout_prob)(embedding_layer)

# 임베딩 벡터에서 특징 추출을 하는 영역 (2번째 단계)
# 3-gram
conv1 = Conv1D(
    filters=128,
    kernel_size=3,
    padding='valid',
    activation=tf.nn.relu)(dropout_emb)
pool1 = GlobalMaxPool1D()(conv1)
# 4-gram
conv2 = Conv1D(
    filters=128,
    kernel_size=4,
    padding='valid',
    activation=tf.nn.relu)(dropout_emb)
pool2 = GlobalMaxPool1D()(conv2)
# 5-gram
conv3 = Conv1D(
    filters=128,
    kernel_size=5,
    padding='valid',
    activation=tf.nn.relu)(dropout_emb)
pool3 = GlobalMaxPool1D()(conv3)

# 병렬로 연결된 추출된 특징맵의 결과를 하나로 묶어주기
concat = concatenate([pool1, pool2, pool3])

# 완전 연결 계층 (분류 - 마지막 단계)
hidden = Dense(128, activation=tf.nn.relu)(concat)
dropout_hidden = Dropout(rate=dropout_prob)(hidden)
logits = Dense(3, name='logits')(dropout_hidden)
predictions = Dense(3,activation=tf.nn.softmax)(logits)

# 정의한 모델을 생성하기
model = Model(inputs=input_layer, outputs=predictions)
model.compile(optimizer='adam', loss='sparse_categorical_crossentropy', metrics=['accuracy'])

# 모델 학습
model.fit(train_ds, validation_data=val_ds, epochs=EPOCH, verbose=1)

# 모델 평가 (테스트 데이터셋 사용)
loss, accuracy = model.evaluate(test_ds, verbose=1)
print('Accuracy: %f' %(accuracy*100))
print('loss: %f' %(loss))

# 모델 저장
model.save('cnn_model.h5')
