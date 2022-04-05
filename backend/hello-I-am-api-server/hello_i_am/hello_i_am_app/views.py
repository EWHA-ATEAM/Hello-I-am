import os

import numpy as np
from rest_framework.response import Response
from rest_framework.decorators import api_view

from django.shortcuts import render
from django.http import HttpResponse

import tensorflow as tf
import tensorflow_hub as hub
import tensorflow_text

from keras.models import load_model
from keras.preprocessing import image
import numpy as np

from .models import Screenimage

## 손동작 사진 인삭하는 함수
@api_view(['POST'])
def get_image(request):
    form = Screenimage()

    # 유니티로부터 이미지 받아오기
    screenimage = request.FILES['screenImage']
    # print(screenimage)
    form.image = screenimage
    form.save()

    # 사진 인식 모델 로드하기
    file_name = os.path.dirname(__file__) + '/model3.h5'    # 배포할 때를 대비해... (내 로컬 절대경로로 쓰면 안 됨)
    model = load_model(file_name)

    # 모델에 인풋할 수 있도록 형태 바꾸기
    img = image.load_img("./media/images/screenImage.dat", target_size=(150, 150))
    # print(os.listdir("./media/images/"))

    img2 = image.img_to_array(img)
    img2 = np.expand_dims(img2, axis=0)

    # 사진 삭제하기
    form.delete()  # db에서 삭제하기 - media 폴더의 사진도 같이 삭제

    # 예측하기
    predict = model.predict(img2)
    # print("사진의 예측값은:", predict)
    # {'heart':0, 'hi':1, 'pet':2}

    res = -1    # 아무 인덱스도 아닌 -1로 초기화

    if predict[0][0] == 1:
        res = 0
    elif predict[0][1] == 1:
        res = 1
    elif predict[0][2] == 1:
        res = 2

    return HttpResponse(res)



## 음성인식으로 받은 문장의 카테고리를 분류해서 대답하는 함수
@api_view(['POST'])
def label_user_chat(request):
    # sentence = str(request.data.get('sentence'))
    sentence = str(request.POST['sentence'])
    print(sentence)
    animal = int(request.POST['animal'])

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
        "너는 누구랑 같이 살아?", "너는 몇 살이야?", "어떻게 생겼어?"
    ])
    embeddings1 = model(sentences1)
    embeddings2 = model(sentences2)

    # Calculate cosine similarity
    res = tf.tensordot(embeddings1, embeddings2, axes=[[1], [1]])
    res_index = np.argmax(res[0])

    polarbear_res = ["북극곰(0)", "북극곰(1)", "북극곰(2)", "북극곰(3)", "북극곰(4)", "북극곰(5)", "북극곰(6)", "북극곰(7)", "북극곰(8)"]
    redpanda_res = ["레서판다(0)", "레서판다(1)", "레서판다(2)", "레서판다(3)", "레서판다(4)", "레서판다(5)", "레서판다(6)", "레서판다(7)", "레서판다(8)"]
    snowleopard_res = ["설표(0)", "설표(1)", "설표(2)", "설표(3)", "설표(4)", "설표(5)", "설표(6)", "설표(7)", "설표(8)"]

    # 질문의 카테고리에 따른 대답
    # 북극곰 (animal: 0)
    if animal == 0:
        res = polarbear_res[res_index]

    # 레서판다 (animal: 1)
    if animal == 1:
        res = redpanda_res[res_index]
    # 설표 (animal: 2)
    if animal == 2:
        res = snowleopard_res[res_index]

    return HttpResponse(res)
