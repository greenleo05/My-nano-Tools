Imports System.Diagnostics.Eventing
Imports System.Drawing.Text
Imports System.IO

Public Class Form1

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.Title = "Select a File" ' 파일 선택 창 제목
        openFileDialog1.InitialDirectory = "c:\" ' 초기 디렉토리 설정
        openFileDialog1.Filter = "Text File|*.txt" ' .txt 파일만 열 수 있도록

        If openFileDialog1.ShowDialog() = DialogResult.OK Then ' 파일이 선택되었을 때
            txtFilePath.Text = openFileDialog1.FileName ' 선택한 파일 경로를 텍스트 박스에 표시
        End If
    End Sub

    Private Sub btnOpenNano_Click(sender As Object, e As EventArgs) Handles btnOpenNano.Click
        If txtFilePath.Text = "" Then ' 파일 경로가 비어있는지 확인
            MessageBox.Show("Please select a file first.") ' 경고 메시지 표시
            Exit Sub
        End If

        Dim winPath As String = txtFilePath.Text ' 윈도우 파일 경로
        Dim wslPath As String = ConvertToWslPath(winPath) ' WSL 파일 경로로 변환

        Dim command As String = $"~/my-nano/mynano ""{wslPath}""" ' command 변수에 WSL 명령어 생성

        RunWslCommand(command) ' WSL 명령어 실행
    End Sub

    Private Function ConvertToWslPath(winPath As String) As String '윈도우 경로를 WSL 경로로 변환하는 function
        Dim drive As String = winPath.Substring(0, 1).ToLower() ' 드라이브 문자 추출 및 소문자로 변환
        Dim path As String = winPath.Substring(2).Replace("\", "/") ' 경로 부분 추출 및 슬래시 변환
        Return $"/mnt/{drive}{path}" ' WSL 경로 형식으로 만들어 반환
    End Function

    Private Sub RunWslCommand(wslCmd As String) ' WSL 명령어를 실행하는 subroutine
        Dim proc As New Process() ' 새로운 프로세스 생성
        proc.StartInfo.FileName = "cmd.exe" ' cmd.exe를 실행 파일로 설정

        proc.StartInfo.Arguments = $"/c wsl -- bash -c '{wslCmd}'" ' WSL 명령어를 인수로 설정
        proc.StartInfo.UseShellExecute = True ' 셸 실행 사용
        proc.Start() ' 프로세스 시작
    End Sub

    Private Sub btnInstall_Click(sender As Object, e As EventArgs) Handles btnInstall.Click

        ' 1. WSL 설치 여부 확인
        If Not IsWslInstalled() Then
            Dim result As DialogResult = MessageBox.Show(
                "Mynano 실행을 위해 WSL(Windows Subsystem for Linux)이 필요합니다." & vbCrLf &
                "지금 설치하시겠습니까? (관리자 권한 필요)",
                "설치 필요", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                InstallWsl() ' WSL 설치 함수 호출
                ' 설치 후 재부팅이 필요할 수 있으므로 여기서 멈춤
                Exit Sub
            Else
                MessageBox.Show("WSL 설치가 취소되었습니다. Mynano를 사용할 수 없습니다.")
                Exit Sub
            End If
        End If

        ' 3. 핵심: 바이너리 배포 함수 호출
        DeployMynanoBinary()

    End Sub

    Private Function IsWslInstalled() As Boolean
        Try
            Dim proc As New Process()
            proc.StartInfo.FileName = "wsl"

            ' --list 명령어로 설치된 목록을 가져오기
            proc.StartInfo.Arguments = "--list"
            proc.StartInfo.UseShellExecute = False
            proc.StartInfo.RedirectStandardOutput = True ' 출력 내용을 읽어야 함
            proc.StartInfo.CreateNoWindow = True

            ' 인코딩 문제 방지를 위해 유니코드 설정
            proc.StartInfo.StandardOutputEncoding = System.Text.Encoding.Unicode

            proc.Start()

            ' 출력된 내용 모두 읽기
            Dim output As String = proc.StandardOutput.ReadToEnd()
            proc.WaitForExit(3000)

            ' 1. 명령어가 에러를 뱉었거나 (기능 꺼짐)
            ' 2. 출력 내용에 "Ubuntu"라는 단어가 없으면 설치 안 된 것으로 간주
            If proc.ExitCode <> 0 OrElse Not output.Contains("Ubuntu") Then
                Return False
            End If

            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub InstallWsl()
        Try
            Dim proc As New Process()
            proc.StartInfo.FileName = "powershell"
            ' 관리자 권한으로 wsl --install 실행
            proc.StartInfo.Arguments = "Start-Process wsl -ArgumentList '--install' -Verb RunAs"
            proc.StartInfo.UseShellExecute = True
            proc.Start()

            MessageBox.Show("WSL 설치가 완료되고 아이디와 비밀번호를 모두 설정했으면 '예'를 눌러주세요." & vbCrLf &
                            "설치가 완료되면 컴퓨터를 재부팅해야 합니다!", "안내")
        Catch ex As Exception
            MessageBox.Show("설치 명령 실행 실패: " & ex.Message)
        End Try
    End Sub

    Private Sub DeployMynanoBinary()
        Try
            ' Resource1에서 직접 파일 꺼내기 (Reflection 방식)
            ' 1. 리소스 매니저를 통해 Resource1에 접속하기
            Dim rm As New System.Resources.ResourceManager("My_nano_Tools.Resource1", System.Reflection.Assembly.GetExecutingAssembly())

            ' 2. "mynano"라는 이름의 파일 요청
            ' (만약 파일 이름이 다르면 여기서 에러가 날 수 있으니 Try로 감싸기)
            Dim obj As Object = rm.GetObject("mynano")

            If obj Is Nothing Then
                MessageBox.Show("Resource1 안에서 'mynano' 파일을 찾을 수 없습니다!" & vbCrLf &
                                "리소스 탭에서 파일 이름이 'mynano'가 맞는지 확인해주세요.")
                Exit Sub
            End If

            ' 3. 바이트 배열로 변환
            Dim resourceData As Byte() = CType(obj, Byte())

            ' 4. 윈도우 임시 폴더에 풀기
            Dim safeDir As String = "C:\Users\Public\MynanoTemp"

            ' 폴더가 없으면 만들기
            If Not Directory.Exists(safeDir) Then
                Directory.CreateDirectory(safeDir)
            End If

            Dim tempFilePath As String = Path.Combine(safeDir, "mynano")
            File.WriteAllBytes(tempFilePath, resourceData)


            ' 5. WSL 사용자 확인
            Dim userProc As New Process()
            userProc.StartInfo.FileName = "wsl"
            userProc.StartInfo.Arguments = "whoami"
            userProc.StartInfo.UseShellExecute = False
            userProc.StartInfo.RedirectStandardOutput = True
            userProc.StartInfo.CreateNoWindow = True
            userProc.Start()

            If Not userProc.WaitForExit(3000) Then
                MessageBox.Show("WSL 응답 없음")
                Exit Sub
            End If

            Dim wslUser As String = userProc.StandardOutput.ReadToEnd().Trim()

            ' 6. WSL로 복사 및 실행 권한 부여
            Dim wslTargetDir As String = $"/home/{wslUser}/my-nano"
            Dim wslTargetFile As String = $"{wslTargetDir}/mynano"

            ' 윈도우 경로 -> WSL 경로 변환
            Dim drive As String = tempFilePath.Substring(0, 1).ToLower()
            Dim pathPart As String = tempFilePath.Substring(2).Replace("\", "/")
            Dim wslTempPath As String = $"/mnt/{drive}{pathPart}"

            Dim commands As String = $"mkdir -p {wslTargetDir}; cp ""{wslTempPath}"" ""{wslTargetFile}""; chmod +x ""{wslTargetFile}"""

            RunWslCommand(commands)

            MessageBox.Show($"설치 완료!{vbCrLf}경로: {wslTargetFile}", "성공")

        Catch ex As Exception
            MessageBox.Show("오류 발생: " & ex.Message)
        End Try
    End Sub

    Private Sub btnOpenGithub_Click(sender As Object, e As EventArgs) Handles btnOpenGithub.Click
        ' 주소를 지정하여 기본 웹 브라우저에서 열기
        Dim url As String = "https://github.com/greenleo05/my-nano/tree/main"
        Process.Start(New ProcessStartInfo(url) With {.UseShellExecute = True})
    End Sub

    Private Sub btnOpenVelog_Click(sender As Object, e As EventArgs) Handles btnOpenVelog.Click
        Dim url As String = "https://velog.io/@greenleo5/series"
        Process.Start(New ProcessStartInfo(url) With {.UseShellExecute = True})
    End Sub

    Private Sub btnOpenGithubpage_Click(sender As Object, e As EventArgs) Handles btnOpenGithubpage.Click
        Dim url As String = "https://github.com/greenleo05/My-nano-Tools"
        Process.Start(New ProcessStartInfo(url) With {.UseShellExecute = True})
    End Sub
End Class
