import numpy as np
from rest_framework.response import Response
from rest_framework.decorators import api_view

from django.shortcuts import render
from django.http import HttpResponse

import tensorflow as tf
import tensorflow_hub as hub
import tensorflow_text

from tensorflow.keras.models import load_model
from keras.preprocessing import image
import numpy as np


## 손동작 사진 인삭하는 함수
@api_view(['POST'])
def get_image(request):

    # 유니티로부터 이미지 받아오기
    screenimage = (request.data.get('screenImage'))
    print(screenimage)
    print(type(screenimage))

    model = load_model('model2.h5')    # 사진 인식 모델 로드하기

    # 모델에 인풋할 수 있도록 형태 바꾸기
    img = image.load_img(screenimage, target_size=(150, 150))
    img2 = image.img_to_array(img)
    img2 = np.expand_dims(img2, axis=0)

    # 예측하기
    predict = model.predict(img2)
    print("사진의 예측값은:", predict)
    # {'heart':0, 'hi':1, 'pet':2}

    res = -1    # 아무 인덱스도 아닌 -1로 초기화

    if predict[0][0] == 1:
        print('heart')
        res = 0
    elif predict[0][1] == 1:
        print('hi')
        res = 1
    elif predict[0][2] == 1:
        print('pet')
        res = 2

    return HttpResponse(res)


## 음성인식으로 받은 문장의 카테고리를 분류해서 대답하는 함수
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
        "안녕? 너는 이름이 뭐야", "너는 어디에 살아?", "밥 뭐먹었어?", "기분이 어때?", "힘든 이유가 뭐야?", "내가 널 도울 방법이 있을까?",
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
