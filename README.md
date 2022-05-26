# 🐻안녕?나는,🐻
**멸종위기종 관심 증대를 위한 소통형 가상동물원**
> 내 소개를 해볼게! 안녕? 나는, 

## 🐻<안녕?나는,> 플레이 가이드🐻

1. 시작화면에서 **입장하기**버튼을 통해 가상동물원으로 입장해보세요!
   * 첫 방문일 경우 튜토리얼이 제공되니 천천히 읽어보며 사용법을 익혀보세요 :)
   * 이후에도 도움말이 필요할 경우 메인 AR 화면에서 오른쪽 상단의 도움말 버튼을 통해 주요 기능을 확인할 수 있습니다.
2. 메뉴 화면에서 **원하는 동물**을 선택합니다.
3. 메인 AR화면으로 전환되면 가이드를 따라 **장애물이 없는 평평한 바닥**을 찾아 카메라로 비춥니다.
4. 바닥에 **하늘색 표시**가 나타나면 원하는 위치를 터치해 동물을 불러보세요!
5. 이후 나타난 자유롭게 상호작용하며 동물과 친구가 되어봐요 :)
   * 튜토리얼/도움말에서 제시된 **손모양**을 취한 후 화면 **하단의 셔터를 눌러 사진**을 찍어보세요.
   * 왼쪽 하단의 **마이크버튼**을 꾹 누르고 화면에 마이크가 나타나면 **동물에게 질문**해보세요.


## 프로젝트 소개
<img src="https://user-images.githubusercontent.com/60884877/170442089-eaed5393-ba39-4184-bae4-f637bb19f44c.png" width="400px">

멸종위기종과 AR을 이용해 소통하며 관련 정보를 얻고<br/>이 과정에서 생기는 동물에 대한 친밀감으로 지속적인 관심을 이끌어내는 **교육 목적의 AR 콘텐츠**

[앱 시연 및 포스터 설명 영상](https://youtu.be/8SQA-MDzAF4)

### 프로젝트 흐름도
<img src="https://user-images.githubusercontent.com/60884877/170525807-f1a26e19-fe02-4ef2-ad29-7da8e9547885.png"  width="550px"/>

### 개발 도구
<img src="https://img.shields.io/badge/Unity-FFFFFF?style=flat-square&logo=unity&logoColor=black"/> <img src="https://img.shields.io/badge/Pycharm-black?style=flat-square&logo=pycharm&logoColor=white"/><br/>
<img src="https://img.shields.io/badge/C%23-239120?style=flat-square&logo=Csharp&logoColor=white"/> <img src="https://img.shields.io/badge/Python-3776AB?style=flat-square&logo=python&logoColor=white"/> <img src="https://img.shields.io/badge/Django-092E20?style=flat-square&logo=django&logoColor=white"/> <img src="https://img.shields.io/badge/TensorFlow-FF6F00?style=flat-square&logo=tensorflow&logoColor=white"/>

* Unity 2020.3.23f1
* Python 3.7.11
* pip 21.2.4


## 실행 방법
> 보안상의 이유로 Naver Clova STT Key와 Server의 url이 입력되어있지 않으며<br/>컴퓨터로는 AR기능이 포함되어있는 Main 화면을 실행할 수 없어<br/>**📱안드로이드 기기**와 추후 추가될 **⚙apk파일**을 이용해 실행하는 것을 권장합니다.

### ✔ apk 앱 설치 (권장)
1. 링크(추후 추가)를 통해 apk 파일을 안드로이드 기기에 다운로드
2. `내 파일 > Download > HelloIam`을 눌러 기기에 설치
   * 이때, 출처를 알 수 없는 앱 설치 팝업이 뜬다면 '이번에만 설치 허용' 체크 후 진행
3. 어플을 실행
   * 메뉴 화면에서 메인AR 화면으로 넘어갈 때 뜨는 권한 팝업 허용 → 하지 않을 경우 앱을 제대로 사용할 수 없음 :(
   * 만약 실수로 허용하지 않았다면 `설정 > 애플리케이션` 에서 `HelloIam`을 찾아 권한 허용

----------

#### 컴퓨터 (권장하지 않음)
아래 명령어를 통해 레포지토리를 local에 클론

```git
git clone https://github.com/EWHA-ATEAM/Hello-I-am.git
```

프론트엔드와 백엔드를 같은 컴퓨터에서 실행시키거나 같은 와이파이에 연결되어있어야 함


##### FrontEnd - Unity
1. Unity 2020.3.23f1 설치
2. `Hello-I-am/frontend/Hello_I_am` 폴더를 Unity Hub의 오른쪽 상단 _열기_ 버튼을 통해 열고 실행
3. `Project` tap에서 `Assets/Scenes/Home`을 더블 클릭하여 앱의 첫 화면이 `Game`탭에 보이도록 설정
4. 화면 상단의 ` ▶ `버튼을 눌러 실행

##### BackEnd - Pycharm
1. `Hello-I-am/backend` 폴더를 엶
2. 아래 명령어를 통해 서버를 실행시킴
   ```pip
   python manage.py runserver 0.0.0.0:8000
   ```  

## 팀 소개
| <img src="https://user-images.githubusercontent.com/60884877/145065869-3061a8b2-22f1-47ff-9bde-7ac45e598795.png" width="90px"> | <img src="https://user-images.githubusercontent.com/60884877/145065877-9815f00b-f28f-49f5-a26e-3a3c50f2804e.png" width="100px"> | <img src="https://user-images.githubusercontent.com/60884877/145065873-60f2f731-8006-4b00-be0c-749595f56c9d.png" width="100px"> | 
| ---------- | ---------- | ---------- | 
| [이희원](https://github.com/Tina-223) | [채지은](https://github.com/cje1903) | [최지민](https://github.com/zmin9) |
