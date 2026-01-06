<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        title = New Label()
        txtFilePath = New TextBox()
        titlePath = New Label()
        btnBrowse = New Button()
        GroupBox1 = New GroupBox()
        btnOpenHex = New Button()
        btnOpenNano = New Button()
        btnInstall = New Button()
        Label1 = New Label()
        Label2 = New Label()
        btnOpenGithub = New Button()
        btnOpenVelog = New Button()
        btnOpenGithubpage = New Button()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' title
        ' 
        title.AutoSize = True
        title.Font = New Font("맑은 고딕", 36F, FontStyle.Regular, GraphicsUnit.Point, CByte(129))
        title.Location = New Point(34, 9)
        title.Name = "title"
        title.Size = New Size(384, 65)
        title.TabIndex = 0
        title.Text = "My-nano Studio"
        ' 
        ' txtFilePath
        ' 
        txtFilePath.Location = New Point(81, 93)
        txtFilePath.Name = "txtFilePath"
        txtFilePath.Size = New Size(275, 23)
        txtFilePath.TabIndex = 1
        ' 
        ' titlePath
        ' 
        titlePath.AutoSize = True
        titlePath.Location = New Point(20, 97)
        titlePath.Name = "titlePath"
        titlePath.Size = New Size(53, 15)
        titlePath.TabIndex = 2
        titlePath.Text = "File Path"
        ' 
        ' btnBrowse
        ' 
        btnBrowse.Location = New Point(362, 93)
        btnBrowse.Name = "btnBrowse"
        btnBrowse.Size = New Size(75, 23)
        btnBrowse.TabIndex = 3
        btnBrowse.Text = "Browse..."
        btnBrowse.UseVisualStyleBackColor = True
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(btnOpenHex)
        GroupBox1.Controls.Add(btnOpenNano)
        GroupBox1.Location = New Point(24, 136)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(407, 188)
        GroupBox1.TabIndex = 4
        GroupBox1.TabStop = False
        GroupBox1.Text = "Select Mode / Start"
        ' 
        ' btnOpenHex
        ' 
        btnOpenHex.Location = New Point(111, 144)
        btnOpenHex.Name = "btnOpenHex"
        btnOpenHex.Size = New Size(176, 23)
        btnOpenHex.TabIndex = 1
        btnOpenHex.Text = "(Coming Soon)"
        btnOpenHex.UseVisualStyleBackColor = True
        ' 
        ' btnOpenNano
        ' 
        btnOpenNano.Location = New Point(111, 45)
        btnOpenNano.Name = "btnOpenNano"
        btnOpenNano.Size = New Size(176, 76)
        btnOpenNano.TabIndex = 0
        btnOpenNano.Text = "Start MyNano"
        btnOpenNano.UseVisualStyleBackColor = True
        ' 
        ' btnInstall
        ' 
        btnInstall.Location = New Point(135, 420)
        btnInstall.Name = "btnInstall"
        btnInstall.Size = New Size(176, 59)
        btnInstall.TabIndex = 5
        btnInstall.Text = "Install WSL and mynano"
        btnInstall.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(153, 402)
        Label1.Name = "Label1"
        Label1.Size = New Size(141, 15)
        Label1.TabIndex = 6
        Label1.Text = "What if it's not installed?"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(109, 350)
        Label2.Name = "Label2"
        Label2.Size = New Size(97, 15)
        Label2.TabIndex = 7
        Label2.Text = "What's mynano?"
        ' 
        ' btnOpenGithub
        ' 
        btnOpenGithub.Location = New Point(212, 346)
        btnOpenGithub.Name = "btnOpenGithub"
        btnOpenGithub.Size = New Size(111, 23)
        btnOpenGithub.TabIndex = 8
        btnOpenGithub.Text = "Learn more..."
        btnOpenGithub.UseVisualStyleBackColor = True
        ' 
        ' btnOpenVelog
        ' 
        btnOpenVelog.Location = New Point(135, 528)
        btnOpenVelog.Name = "btnOpenVelog"
        btnOpenVelog.Size = New Size(75, 23)
        btnOpenVelog.TabIndex = 9
        btnOpenVelog.Text = "Velog"
        btnOpenVelog.UseVisualStyleBackColor = True
        ' 
        ' btnOpenGithubpage
        ' 
        btnOpenGithubpage.Location = New Point(236, 528)
        btnOpenGithubpage.Name = "btnOpenGithubpage"
        btnOpenGithubpage.Size = New Size(75, 23)
        btnOpenGithubpage.TabIndex = 10
        btnOpenGithubpage.Text = "Github"
        btnOpenGithubpage.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(456, 563)
        Controls.Add(btnOpenGithubpage)
        Controls.Add(btnOpenVelog)
        Controls.Add(btnOpenGithub)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(btnInstall)
        Controls.Add(GroupBox1)
        Controls.Add(btnBrowse)
        Controls.Add(titlePath)
        Controls.Add(txtFilePath)
        Controls.Add(title)
        Name = "Form1"
        Text = "My-nano Studio"
        GroupBox1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents title As Label
    Friend WithEvents txtFilePath As TextBox
    Friend WithEvents titlePath As Label
    Friend WithEvents btnBrowse As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnOpenHex As Button
    Friend WithEvents btnOpenNano As Button
    Friend WithEvents btnInstall As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnOpenGithub As Button
    Friend WithEvents btnOpenVelog As Button
    Friend WithEvents btnOpenGithubpage As Button

End Class
