import tensorflow as tf
import pandas as pd
from tensorflow.keras.models import Model, load_model
from tensorflow.keras import preprocessing

# 데이터 읽어오기
train_file = "./ChatbotData.csv"
data = pd.read_csv(train_file, delimiter=',')
# ChatbotData.csv 파일에서 Q는 질문, label은 라벨링한 감정을 의미합니다.
# tolist()함수를 통해 리스트로 만들기
features = data['Q'].tolist()
labels = data['label'].tolist()

# 단어 인덱스 시퀀스 벡터
corpus = [preprocessing.text.text_to_word_sequence(text) for text in features]
tokenizer = preprocessing.text.Tokenizer()  # 텐서플로의 토크나이저
tokenizer.fit_on_texts(corpus)
sequences = tokenizer.texts_to_sequences(corpus)

# 최대 단어 시퀀스 벡터 크기
MAX_SEQ_LEN = 15
padded_seqs=preprocessing.sequence.pad_sequences(sequences, maxlen=MAX_SEQ_LEN, padding='post')

# 테스트용 데이터셋 생성
ds = tf.data.Dataset.from_tensor_slices((padded_seqs, labels))
ds = ds.shuffle(len(features))  # 데이터셋의 문장 수
test_ds = ds.take(2000).batch(20)   # 2000개의 데이터를 테스트 셋으로 사용하기

# 모델 불러오기
model = load_model('cnn_model.h5')
model.summary()
# 모델 평가하기
model.evaluate(test_ds, verbose=2)

# 눈에 보이는 데이터로 시험해보기
# 테스트용 데이터셋의 10212번째 데이터 출력
print("단어 시퀀스: ", corpus[11823])
# ex) corpus[n] = ["3박4일", "놀러가고", "싶다"]
print("단어 인덱스 시퀀스: ", padded_seqs[11823])
# ex) padded_seqs[n]=[2580, 803, 11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0] (크기가 15인 벡터)
print("문장 분류(실제 정답): ", labels[11823])

picks = [11823]
predict = model.predict(padded_seqs[picks])
predict_class = tf.math.argmax(predict, axis=1)
print("감정 예측 점수: ", predict)
# 3개의 클래스에 대한 점수 (가장 높은 것을 답으로 내놓음)
print("감정 예측 클래스: ", predict_class.numpy())