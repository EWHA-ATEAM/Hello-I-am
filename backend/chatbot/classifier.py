import tensorflow as tf
import tensorflow_hub as hub
import tensorflow_text

user_question = "배고파"

def label_user_question(user_question):

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
    user_question
    ])
    sentences2 = tf.constant([
    "안녕? 너는 이름이 뭐야","너는 어디에 살아?", "밥 뭐먹었어?", "기분이 어때?", "힘든 이유가 뭐야?", "내가 널 도울 방법이 있을까?",
        "너는 누구랑 같이 살아?", "너는 몇 살이야?", "너의 몸무게는 얼마야?"
    ])
    embeddings1 = model(sentences1)
    embeddings2 = model(sentences2)

    # Calculate cosine similarity
    res = tf.tensordot(embeddings1, embeddings2, axes=[[1], [1]])
    #print(res)
    res_index = tf.rank(res).numpy()
    #print(res_index)

    return res_index

print(label_user_question(user_question))