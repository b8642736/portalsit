<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.ExcelFileToDB1 = New UserControl.ExcelFileToDB
        Me.Button1 = New System.Windows.Forms.Button
        Me.SerialPortEx1 = New ExWindowControlLibrary.SerialPortEx
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ExcelFileToDB1
        '
        Me.ExcelFileToDB1.Location = New System.Drawing.Point(31, 33)
        Me.ExcelFileToDB1.Name = "ExcelFileToDB1"
        Me.ExcelFileToDB1.Size = New System.Drawing.Size(463, 192)
        Me.ExcelFileToDB1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(81, 276)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(152, 50)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "RegexTest"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'SerialPortEx1
        '
        Me.SerialPortEx1.ContainerUserControl = Nothing
        Me.SerialPortEx1.ReceiveDataIntervalMilliSeconds = 100
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(104, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Label1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(552, 430)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ExcelFileToDB1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ExcelFileToDB1 As UserControl.ExcelFileToDB
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents SerialPortEx1 As ExWindowControlLibrary.SerialPortEx
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
