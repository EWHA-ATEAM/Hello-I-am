import numpy as np
from rest_framework.response import Response
from rest_framework.decorators import api_view

from django.shortcuts import render
from django.http import HttpResponse

import tensorflow as tf
import tensorflow_hub as hub
import tensorflow_text

@api_view(['POST'])
def label_user_chat(request):
    sentence = str(request.data.get('sentence'))
    print(sentence)

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
    sentence
    ])
    sentences2 = tf.constant([  # 질문의 카테고리에 따른 대표 질문들
    "안녕? 너는 이름이 뭐야","너는 어디에 살아?", "밥 뭐먹었어?", "기분이 어때?", "힘든 이유가 뭐야?", "내가 널 도울 방법이 있을까?",
        "너는 누구랑 같이 살아?", "너는 몇 살이야?", "너의 몸무게는 얼마야?"
    ])
    embeddings1 = model(sentences1)
    embeddings2 = model(sentences2)

    # Calculate cosine similarity
    res = tf.tensordot(embeddings1, embeddings2, axes=[[1], [1]])
    res_index = np.argmax(res[0])

    # 질문의 카테고리에 따른 대답
    if res_index == 0:
        res = "(0) 안녕 나는 곰곰이야!"
    elif res_index == 1:
        res = "(1) 나는 북극에 살아"
    elif res_index == 2:
        res = "(2) 나는 바다사자를 먹었어"
    elif res_index == 3:
        res = "(3) 나는 지금 우울해"
    elif res_index == 4:
        res = "(4) 북극의 빙하가 녹고 있어서 살 곳이 없어지고 있어.."
    elif res_index == 5:
        res = "나를 돕기 위해서는 지구를 아껴줘"
    elif res_index == 6:
        res = "얼마전에 독립해서 혼자 살고 있어"
    elif res_index == 7:
        res = "나는 4살이야"
    elif res_index == 8:
        res = "나느 400kg 정도 돼"
    else:
        res = "나머지^^"

    return HttpResponse(res)