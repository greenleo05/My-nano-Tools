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
            Dim result As DialogResult = MessageBox.Show("mynano 실행을 위해 WSL(Windows Subsystem for Linux) 설치가 필요합니다." & vbCrLf & "설치를 진행하시겠습니까? (관리자 권한 필요, 재부팅될 수 있음)", "설치 필요", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                InstallWsl()
            Else
                MessageBox.Show("WSL 설치가 필요합니다. 설치 후 다시 시도해주세요.", "설치 취소", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            DeployMynanoBinary()
        End If
    End Sub

    Private Function IsWslInstalled() As Boolean
        Try
            Dim proc As New Process()
            proc.StartInfo.FileName = "wsl"
            proc.StartInfo.Arguments = "--status"
            proc.StartInfo.UseShellExecute = False
            proc.StartInfo.CreateNoWindow = True
            proc.Start()
            proc.WaitForExit()

            Return (proc.ExitCode = 0)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub InstallWsl()
        Try
            Dim proc As New Process()
            proc.StartInfo.FileName = "powershell"

            proc.StartInfo.Arguments = "Start-Process wsl -ArgumentList '--install' -Verb RunAs"
            proc.StartInfo.UseShellExecute = True
            proc.Start()
            proc.WaitForExit()

            MessageBox.Show("WSL 설치가 완료되었습니다. 시스템을 재부팅해주세요.", "설치 완료", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("WSL 설치 중 오류가 발생했습니다: " & ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DeployMynanoBinary()
        Try
            ' 1. WSL의 기본 사용자 홈 디렉토리 찾기
            ' (\\wsl$\Ubuntu\home\사용자명\ 형태로 접근)

            ' 현재 WSL 사용자의 이름을 알아내기
            Dim userProc As New Process()
            userProc.StartInfo.FileName = "wsl"
            userProc.StartInfo.Arguments = "whoami" ' WSL에서 현재 사용자 이름 얻기
            userProc.StartInfo.UseShellExecute = False
            userProc.StartInfo.RedirectStandardOutput = True
            userProc.StartInfo.CreateNoWindow = True
            userProc.Start()
            Dim wslUser As String = userProc.StandardOutput.ReadToEnd().Trim() ' 사용자 이름 wslUser에 저장
            userProc.WaitForExit()

            If wslUser = "" Then ' 사용자 이름을 못 찾았을 때
                MessageBox.Show("WSL 사용자를 찾을 수 없습니다. WSL이 실행 중인지 확인하세요.")
                Exit Sub
            End If

            ' 2. 복사할 경로 설정 (WSL 파일 시스템에 직접 접근)
            ' \\wsl.localhost\배포 파일\ 경로 사용
            Dim targetDir As String = $"\\wsl.localhost\Ubuntu\home\{wslUser}\my-nano"
            Dim targetFile As String = Path.Combine(targetDir, "mynano")

            ' 폴더가 없으면 생성하기 (WSL command)
            RunWslCommand($"mkdir -p /home/{wslUser}/my-nano")

            ' 3. 리소스에서 파일 꺼내서 저장하기
            File.WriteAllBytes(targetFile, My.Resources.Resource1.mynano)

            ' 4. 실행 권한 부여하기 (chmod +x)
            RunWslCommand($"chmod +x /home/{wslUser}/my-nano/mynano")

            MessageBox.Show($"설치 완료! {vbCrLf}경로: {targetFile}", "성공")

        Catch ex As Exception
            MessageBox.Show("파일 설치 실패: " & ex.Message & vbCrLf & "Ubuntu가 실행 중인지 확인해주세요.")
        End Try
    End Sub
End Class
