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
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' title
        ' 
        title.AutoSize = True
        title.Font = New Font("맑은 고딕", 36F, FontStyle.Regular, GraphicsUnit.Point, CByte(129))
        title.Location = New Point(317, 37)
        title.Name = "title"
        title.Size = New Size(384, 65)
        title.TabIndex = 0
        title.Text = "My-nano Studio"
        ' 
        ' txtFilePath
        ' 
        txtFilePath.Location = New Point(356, 140)
        txtFilePath.Name = "txtFilePath"
        txtFilePath.Size = New Size(275, 23)
        txtFilePath.TabIndex = 1
        ' 
        ' titlePath
        ' 
        titlePath.AutoSize = True
        titlePath.Location = New Point(305, 144)
        titlePath.Name = "titlePath"
        titlePath.Size = New Size(31, 15)
        titlePath.TabIndex = 2
        titlePath.Text = "Path"
        ' 
        ' btnBrowse
        ' 
        btnBrowse.Location = New Point(637, 140)
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
        GroupBox1.Location = New Point(305, 189)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(407, 124)
        GroupBox1.TabIndex = 4
        GroupBox1.TabStop = False
        GroupBox1.Text = "Select Mode"
        ' 
        ' btnOpenHex
        ' 
        btnOpenHex.Location = New Point(111, 74)
        btnOpenHex.Name = "btnOpenHex"
        btnOpenHex.Size = New Size(176, 23)
        btnOpenHex.TabIndex = 1
        btnOpenHex.Text = "MyHex(Coming Soon)"
        btnOpenHex.UseVisualStyleBackColor = True
        ' 
        ' btnOpenNano
        ' 
        btnOpenNano.Location = New Point(111, 34)
        btnOpenNano.Name = "btnOpenNano"
        btnOpenNano.Size = New Size(176, 23)
        btnOpenNano.TabIndex = 0
        btnOpenNano.Text = "MyNano"
        btnOpenNano.UseVisualStyleBackColor = True
        ' 
        ' btnInstall
        ' 
        btnInstall.Location = New Point(822, 478)
        btnInstall.Name = "btnInstall"
        btnInstall.Size = New Size(186, 59)
        btnInstall.TabIndex = 5
        btnInstall.Text = "Install WSL and mynano"
        btnInstall.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1037, 563)
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

End Class
