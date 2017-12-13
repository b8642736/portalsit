<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTest
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.FileSystemWatcher1 = New System.IO.FileSystemWatcher()
        Me.btnEmailTest = New System.Windows.Forms.Button()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(135, 137)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(320, 66)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "條碼列印"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(135, 53)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(320, 63)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "主控端"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(135, 227)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(320, 68)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "轉換本站狀態至文字檔"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        Me.FileSystemWatcher1.Filter = "test1.txt"
        Me.FileSystemWatcher1.NotifyFilter = System.IO.NotifyFilters.LastWrite
        Me.FileSystemWatcher1.Path = "\\10.1.4.30\WebRunning\WatchFolderTest"
        Me.FileSystemWatcher1.SynchronizingObject = Me
        '
        'btnEmailTest
        '
        Me.btnEmailTest.Location = New System.Drawing.Point(138, 318)
        Me.btnEmailTest.Name = "btnEmailTest"
        Me.btnEmailTest.Size = New System.Drawing.Size(316, 63)
        Me.btnEmailTest.TabIndex = 7
        Me.btnEmailTest.Text = "Email Test"
        Me.btnEmailTest.UseVisualStyleBackColor = True
        '
        'FormTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(631, 540)
        Me.Controls.Add(Me.btnEmailTest)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.KeyPreview = True
        Me.Name = "FormTest"
        Me.Text = "FormTest"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents FileSystemWatcher1 As System.IO.FileSystemWatcher
    Friend WithEvents btnEmailTest As System.Windows.Forms.Button
End Class
