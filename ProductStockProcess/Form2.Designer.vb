﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.ProductOutCheck1 = New ProductStockProcessControls.ProductOutCheck
        Me.SuspendLayout()
        '
        'ProductOutCheck1
        '
        Me.ProductOutCheck1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProductOutCheck1.Location = New System.Drawing.Point(0, 0)
        Me.ProductOutCheck1.Name = "ProductOutCheck1"
        Me.ProductOutCheck1.Size = New System.Drawing.Size(489, 378)
        Me.ProductOutCheck1.TabIndex = 0
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(489, 378)
        Me.Controls.Add(Me.ProductOutCheck1)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ProductOutCheck1 As ProductStockProcessControls.ProductOutCheck
End Class