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
        Me.ConvertDataSaveToDB1 = New SMPLocateProcessControls.ConvertDataSaveToDB
        Me.SuspendLayout()
        '
        'ConvertDataSaveToDB1
        '
        Me.ConvertDataSaveToDB1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ConvertDataSaveToDB1.Location = New System.Drawing.Point(0, 0)
        Me.ConvertDataSaveToDB1.Name = "ConvertDataSaveToDB1"
        Me.ConvertDataSaveToDB1.Size = New System.Drawing.Size(514, 424)
        Me.ConvertDataSaveToDB1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 424)
        Me.Controls.Add(Me.ConvertDataSaveToDB1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ConvertDataSaveToDB1 As SMPLocateProcessControls.ConvertDataSaveToDB
End Class
