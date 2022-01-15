import tensorflow as tf
import tensorflow_hub as hub
import tensorflow_text

# Load required models
encoder = hub.KerasLayer("https://tfhub.dev/jeongukjae/distilkobert_sentence_encoder/1")
preprocessor = hub.KerasLayer("https://tfhub.dev/jeongukjae/distilkobert_cased_preprocess/1")

# Define sentence encoder model
inputs = tf.keras.Input([], dtype=tf.string)
encoder_inputs = preprocessor(inputs)
sentence_embedding = encoder(encoder_inputs)
normalized_sentence_embedding = tf.nn.l2_normalize(sentence_embedding, axis=-1)
model = tf.keras.Model(inputs, normalized_sentence_embedding)

# Encode sentences using distilkobert_sentence_encoder
sentences1 = tf.constant([
"키가 몇 cm야?"
])
sentences2 = tf.constant([
"너를 뭐라고 부르면 될까?","너는 어디에 살아?", "밥 뭐먹었어?", "기분이 어때?", "힘든 이유가 뭐야?", "내가 널 도울 방법이 있을까?",
    "너는 누구랑 같이 살아?", "너는 몇 살이야?", "너의 몸무게는 얼마야?"
])
embeddings1 = model(sentences1)
embeddings2 = model(sentences2)

# Calculate cosine similarity
res = tf.tensordot(embeddings1, embeddings2, axes=[[1], [1]])
print(res)
print(tf.reduce_max(res))
print(tf.math.argmax(res))
# Expected outputs:
#
# tf.Tensor(
# [[ 0.8907616   0.07906969 -0.09612353  0.00167902]
#  [ 0.0184274   0.6840409  -0.1102942   0.02653065]
#  [-0.00795126 -0.10688838  0.5041443  -0.01270578]
#  [ 0.04684553 -0.0619101   0.00684686  0.68705124]], shape=(4, 4), dtype=float32)
