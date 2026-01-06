# My-nano Tools

My-nano 프로그램을 Windows 환경에서 편리하게 설치하고 사용할 수 있도록 만든 런처입니다.

---

## UI 설명
먼저, 프로그램을 열면 아래와 같은 화면이 있습니다.

<img width="454" height="584" alt="image" src="https://github.com/user-attachments/assets/2995f2da-076c-4536-a975-b61f16679fff" />

1. File Path<br>
   **파일 경로**를 설정하는 창입니다. **Browse 버튼**을 이용하여 Windows 경로 내의 **`.txt` 파일** 경로를 선택할 수 있습니다.
   
2. Select Mode / Start<br>
   Start Mynano를 클릭하여 Mynano를 실행할 수 있습니다. **Mynano가 설치되지 않은 경우 정상적으로 실행되지 않습니다.**

3. What's mynano?<br>
   Mynano 프로그램 GitHub 주소로 연결되며 README.md 내용을 읽을 수 있습니다.

4. Install<br>
   Install WSL and mynano 버튼을 누르면 **WSL이 설치되고**, WSL을 설치한 후 다시 프로그램을 열어 버튼을 누르면 **mynano가 설치**됩니다.
   프로그램 중 이미 설치된 프로그램이 있을 경우 그 프로그램은 설치되지 않으며, 설치 방법에 대해서는 아래에서 상세하게 설명합니다.

5. Velog/GitHub<br>
   저의 Velog와 Github로 바로 연결되는 웹사이트를 엽니다.

## 설치 방법
1. **Install 버튼을 누르고** WSL 설치 안내 메시지를 읽습니다.
2. 콘솔 창이 나오고 **WSL 설치가 시작**됩니다.
3. WSL 설치가 완료되었으면 **콘솔 창이 꺼지거나 `Username`과 `password`를 설정하는 창이 켜집니다.** (password를 입력할 때는 입력해도 입력한 텍스트가 뜨지 않는 것이 정상입니다.)
   <br>- **콘솔 창이 꺼졌을 때**는 컴퓨터를 재부팅한 뒤 뜨는 창에서 `Username`과 `password`를 설정하는 창이 켜진다면 3번과 같이 진행하면 됩니다.
   <br>- **만약 재부팅 후에 아무 창도 뜨지 않았다면** `cmd`를 켜서 `wsl --install`을 입력하여 재설치를 진행하여 주시거나 프로그램을 켜서 Install 버튼을 다시 눌러 주십시오.
6. WSL 설치가 완료되었으면 **컴퓨터를 재부팅한 뒤 다시 Install 버튼을 눌러 mynano를 설치**합니다.
   <br>- 만약 **'WSL 응답 없음'**이라고 뜬다면, Windows 검색창에서 wsl을 찾아 한 번 실행시킨 후에 다시 시도해 주십시오.
7. 설치 완료 메시지가 떴으면 **mynano 설치에 성공한 것**입니다.
