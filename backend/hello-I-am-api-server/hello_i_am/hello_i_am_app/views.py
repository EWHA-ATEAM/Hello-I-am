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

from .models import screenimage_delete_action, Screenimage

import matplotlib.pyplot as plt

## 손동작 사진 인삭하는 함수
@api_view(['POST'])
def get_image(request):
    form = Screenimage()

    # 유니티로부터 이미지 받아오기
    screenimage = request.FILES['screenImage']
    print(screenimage)
    form.image = screenimage
    form.save()

    # a = imggg.imread(screenimage)
    # plt.imshow(a)
    # plt.show()

    # 사진 인식 모델 로드하기
    file_name = os.path.dirname(__file__) + '/model2.h5'    # 배포할 때를 대비해... (내 로컬 절대경로로 쓰면 안 됨)
    model = load_model(file_name)

    # 모델에 인풋할 수 있도록 형태 바꾸기
    img = image.load_img("./media/images/screenImage.dat", target_size=(150, 150))
    print(os.listdir("./media/images/"))
    plt.imshow(img)
    plt.show()

    img2 = image.img_to_array(img)
    img2 = np.expand_dims(img2, axis=0)

    print('사진 삭제할게요')
    form.delete()  # db에서 삭제하기
    # media 폴더에서도 삭제하기 (screenimage_delete_action)

    # 예측하기
    predict = model.predict(img2)
    print("사진의 예측값은:", predict)
    # {'heart':0, 'hi':1, 'pet':2}

    res = -1    # 아무 인덱스도 아닌 -1로 초기화

    print(predict[0][0])
    print(predict[0][1])
    print(predict[0][2])

    # if predict[0][0] == 1:
    #     print('heart')
    #     res = 0
    # elif predict[0][1] == 1:
    #     print('hi')
    #     res = 1
    # elif predict[0][2] == 1:
    #     print('pet')
    #     res = 2

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
        "너는 누구랑 같이 살아?", "너는 몇 살이야?", "너의 몸무게는 얼마야?"
    ])
    embeddings1 = model(sentences1)
    embeddings2 = model(sentences2)

    # Calculate cosine similarity
    res = tf.tensordot(embeddings1, embeddings2, axes=[[1], [1]])
    res_index = np.argmax(res[0])

    # 질문의 카테고리에 따른 대답
    # 북극곰 (animal: 0)
    if animal == 0:
        if res_index == 0:
            res = "북극곰(0)"
        elif res_index == 1:
            res = "북극곰(1)"
        elif res_index == 2:
            res = "북극곰(2)"
        elif res_index == 3:
            res = "북극곰(3)"
        elif res_index == 4:
            res = "북극곰(4)"
        elif res_index == 5:
            res = "북극곰(5)"
        elif res_index == 6:
            res = "북극곰(6)"
        elif res_index == 7:
            res = "북극곰(7)"
        elif res_index == 8:
            res = "북극곰(8)"
        else:
            res = "나머지^^"

    # 레서판다 (animal: 1)
    if animal == 1:
        if res_index == 0:
            res = "레서판다(0)"
        elif res_index == 1:
            res = "레서판다(1)"
        elif res_index == 2:
            res = "레서판다(2)"
        elif res_index == 3:
            res = "레서판다(3)"
        elif res_index == 4:
            res = "레서판다(4)"
        elif res_index == 5:
            res = "레서판다(5)"
        elif res_index == 6:
            res = "레서판다(6)"
        elif res_index == 7:
            res = "레서판다(7)"
        elif res_index == 8:
            res = "레서판다(8)"
        else:
            res = "나머지^^"

    # 설표 (animal: 2)
    if animal == 2:
        if res_index == 0:
            res = "설표(0)"
        elif res_index == 1:
            res = "설표(1)"
        elif res_index == 2:
            res = "설표(2)"
        elif res_index == 3:
            res = "설표(3)"
        elif res_index == 4:
            res = "설표(4)"
        elif res_index == 5:
            res = "설표(5)"
        elif res_index == 6:
            res = "설표(6)"
        elif res_index == 7:
            res = "설표(7)"
        elif res_index == 8:
            res = "설표(8)"
        else:
            res = "나머지^^"

    return HttpResponse(res)
