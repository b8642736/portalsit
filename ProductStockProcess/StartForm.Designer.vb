<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StartForm
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.WeightProcess1 = New ProductStockProcessControls.WeightProcess
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.ProductLabelPrint1 = New ProductStockProcessControls.ProductLabelPrint
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(435, 381)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.WeightProcess1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(427, 355)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'WeightProcess1
        '
        Me.WeightProcess1.CurrentUsePPSSHAPF = Nothing
        Me.WeightProcess1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WeightProcess1.Location = New System.Drawing.Point(3, 3)
        Me.WeightProcess1.Name = "WeightProcess1"
        'Me.WeightProcess1.NowTime = New Date(2009, 4, 16, 9, 53, 42, 310)
        Me.WeightProcess1.Size = New System.Drawing.Size(421, 349)
        Me.WeightProcess1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ProductLabelPrint1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(427, 355)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ProductLabelPrint1
        '
        Me.ProductLabelPrint1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProductLabelPrint1.IsPushSearchButton = False
        Me.ProductLabelPrint1.Location = New System.Drawing.Point(3, 3)
        Me.ProductLabelPrint1.Name = "ProductLabelPrint1"
        Me.ProductLabelPrint1.Size = New System.Drawing.Size(421, 349)
        Me.ProductLabelPrint1.TabIndex = 0
        '
        'StartForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 381)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "StartForm"
        Me.Text = "StartForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents WeightProcess1 As ProductStockProcessControls.WeightProcess
    Friend WithEvents ProductLabelPrint1 As ProductStockProcessControls.ProductLabelPrint
End Class
