# Login-Register-System
### 2021.3.4f1
# 결과물



https://user-images.githubusercontent.com/56676158/173175722-b1c18791-75b9-455b-bb73-018ceb909372.mp4


# UI
- RectTranform의 앵커 프리셋을 활용하여, 여러 해상도에 대응하도록 구현.

<p align="center">
<img src= https://user-images.githubusercontent.com/56676158/169354764-0a0a47d3-e2c6-4e5c-b572-8e171f772910.png></p>

Vertical Layout Group을 활용하여, 텍스트 입력 부분과 버튼 부분을 분할
## 텍스트 입력부분
- Vertical Layout Group을 활용하여 정렬.
## 버튼 부분
- Horizontal Layout Group을 활용하여 정렬.

# 연출
## 인트로 화면
- 코루틴을 활용하여, 2번 항목 구현.
- Image 컴포넌트의 알파값을 0~1까지 점진적으로 전환함으로써 페이드인 연출.
- RectTransform의 y값을 설정한 값까지 올린 후 로그인 버튼 생성되도록 구현.
## 로그인 화면
- 취소 버튼 클릭 시, 생성된 로그인 팝업 창 비활성화.
- 버튼의 Interactble을 활용하여, 로그인 버튼 비활성화/활성화 구현.
- Json을 활용하여 처음 등록하는 유저들의 정보들을 저장.
- Dictionary를 활용하여 기존 유저의 비밀번호 비교.
- 애니메이션을 활용하여 로그인 실패 애니메이션 구현.
## 로그인 성공 이후
- RectTransform을 임의의 속도로 z축 회전 할 수 있도록 구현.
- Invoke를 활용하여, 3초 후 다음 씬으로 전환.
