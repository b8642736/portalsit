<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainControl_CoilNumberInput
    Inherits System.Windows.Forms.UserControl

    'UserControl 覆寫 Dispose 以清除元件清單。
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

    '注意:  以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.tbNewCoilNumber = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnOKReturn = New System.Windows.Forms.Button()
        Me.btnCancelReturn = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnMixCoilChange = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.pbGetOnlineCoilNumber = New System.Windows.Forms.PictureBox()
        Me.tbCoilNumber = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.fpHistoryCoilContainer = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnHisCoil1 = New System.Windows.Forms.Button()
        Me.btnHisCoil2 = New System.Windows.Forms.Button()
        Me.btnHisCoil3 = New System.Windows.Forms.Button()
        Me.btnHisCoil4 = New System.Windows.Forms.Button()
        Me.btnHisCoil5 = New System.Windows.Forms.Button()
        Me.btnHisCoil6 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.pbGetOnlineCoilNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fpHistoryCoilContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.tbNewCoilNumber, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnOKReturn, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancelReturn, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnMixCoilChange, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.fpHistoryCoilContainer, 1, 0)
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("標楷體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(796, 505)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'tbNewCoilNumber
        '
        Me.tbNewCoilNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbNewCoilNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbNewCoilNumber.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tbNewCoilNumber.Location = New System.Drawing.Point(162, 79)
        Me.tbNewCoilNumber.Name = "tbNewCoilNumber"
        Me.tbNewCoilNumber.Size = New System.Drawing.Size(232, 36)
        Me.tbNewCoilNumber.TabIndex = 10
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel2, 2)
        Me.Panel2.Location = New System.Drawing.Point(400, 117)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(393, 385)
        Me.Panel2.TabIndex = 6
        '
        'btnOKReturn
        '
        Me.btnOKReturn.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOKReturn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOKReturn.Enabled = False
        Me.btnOKReturn.Font = New System.Drawing.Font("新細明體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnOKReturn.Location = New System.Drawing.Point(400, 41)
        Me.btnOKReturn.Name = "btnOKReturn"
        Me.btnOKReturn.Size = New System.Drawing.Size(193, 32)
        Me.btnOKReturn.TabIndex = 1
        Me.btnOKReturn.Text = "確定"
        Me.btnOKReturn.UseVisualStyleBackColor = True
        '
        'btnCancelReturn
        '
        Me.btnCancelReturn.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelReturn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelReturn.Font = New System.Drawing.Font("新細明體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnCancelReturn.Location = New System.Drawing.Point(599, 41)
        Me.btnCancelReturn.Name = "btnCancelReturn"
        Me.btnCancelReturn.Size = New System.Drawing.Size(194, 32)
        Me.btnCancelReturn.TabIndex = 2
        Me.btnCancelReturn.Text = "取消"
        Me.btnCancelReturn.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Location = New System.Drawing.Point(3, 117)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(391, 385)
        Me.Panel1.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(26, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 38)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "混料新鋼捲號碼:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnMixCoilChange
        '
        Me.btnMixCoilChange.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMixCoilChange.Enabled = False
        Me.btnMixCoilChange.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnMixCoilChange.Location = New System.Drawing.Point(400, 79)
        Me.btnMixCoilChange.Name = "btnMixCoilChange"
        Me.btnMixCoilChange.Size = New System.Drawing.Size(193, 32)
        Me.btnMixCoilChange.TabIndex = 8
        Me.btnMixCoilChange.Text = "混料鋼捲號碼變更" & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnMixCoilChange.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.Controls.Add(Me.pbGetOnlineCoilNumber)
        Me.FlowLayoutPanel1.Controls.Add(Me.tbCoilNumber)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(162, 41)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(232, 32)
        Me.FlowLayoutPanel1.TabIndex = 11
        '
        'pbGetOnlineCoilNumber
        '
        Me.pbGetOnlineCoilNumber.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.pbGetOnlineCoilNumber.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbGetOnlineCoilNumber.Image = Global.QAColdRollingClient.My.Resources.Resources.L2MsgGet
        Me.pbGetOnlineCoilNumber.Location = New System.Drawing.Point(0, 8)
        Me.pbGetOnlineCoilNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.pbGetOnlineCoilNumber.Name = "pbGetOnlineCoilNumber"
        Me.pbGetOnlineCoilNumber.Size = New System.Drawing.Size(25, 25)
        Me.pbGetOnlineCoilNumber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbGetOnlineCoilNumber.TabIndex = 7
        Me.pbGetOnlineCoilNumber.TabStop = False
        '
        'tbCoilNumber
        '
        Me.tbCoilNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbCoilNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbCoilNumber.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tbCoilNumber.Location = New System.Drawing.Point(28, 3)
        Me.tbCoilNumber.Name = "tbCoilNumber"
        Me.tbCoilNumber.Size = New System.Drawing.Size(158, 36)
        Me.tbCoilNumber.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 24)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "鋼捲號碼:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(147, 38)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "歷史編號(新->舊):"
        '
        'fpHistoryCoilContainer
        '
        Me.fpHistoryCoilContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.fpHistoryCoilContainer, 3)
        Me.fpHistoryCoilContainer.Controls.Add(Me.btnHisCoil1)
        Me.fpHistoryCoilContainer.Controls.Add(Me.btnHisCoil2)
        Me.fpHistoryCoilContainer.Controls.Add(Me.btnHisCoil3)
        Me.fpHistoryCoilContainer.Controls.Add(Me.btnHisCoil4)
        Me.fpHistoryCoilContainer.Controls.Add(Me.btnHisCoil5)
        Me.fpHistoryCoilContainer.Controls.Add(Me.btnHisCoil6)
        Me.fpHistoryCoilContainer.Location = New System.Drawing.Point(162, 3)
        Me.fpHistoryCoilContainer.Name = "fpHistoryCoilContainer"
        Me.fpHistoryCoilContainer.Size = New System.Drawing.Size(631, 32)
        Me.fpHistoryCoilContainer.TabIndex = 13
        '
        'btnHisCoil1
        '
        Me.btnHisCoil1.AutoSize = True
        Me.btnHisCoil1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHisCoil1.Location = New System.Drawing.Point(0, 0)
        Me.btnHisCoil1.Margin = New System.Windows.Forms.Padding(0)
        Me.btnHisCoil1.Name = "btnHisCoil1"
        Me.btnHisCoil1.Size = New System.Drawing.Size(96, 29)
        Me.btnHisCoil1.TabIndex = 0
        Me.btnHisCoil1.UseVisualStyleBackColor = True
        '
        'btnHisCoil2
        '
        Me.btnHisCoil2.AutoSize = True
        Me.btnHisCoil2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHisCoil2.Location = New System.Drawing.Point(96, 0)
        Me.btnHisCoil2.Margin = New System.Windows.Forms.Padding(0)
        Me.btnHisCoil2.Name = "btnHisCoil2"
        Me.btnHisCoil2.Size = New System.Drawing.Size(96, 29)
        Me.btnHisCoil2.TabIndex = 1
        Me.btnHisCoil2.UseVisualStyleBackColor = True
        '
        'btnHisCoil3
        '
        Me.btnHisCoil3.AutoSize = True
        Me.btnHisCoil3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHisCoil3.Location = New System.Drawing.Point(192, 0)
        Me.btnHisCoil3.Margin = New System.Windows.Forms.Padding(0)
        Me.btnHisCoil3.Name = "btnHisCoil3"
        Me.btnHisCoil3.Size = New System.Drawing.Size(96, 29)
        Me.btnHisCoil3.TabIndex = 2
        Me.btnHisCoil3.UseVisualStyleBackColor = True
        '
        'btnHisCoil4
        '
        Me.btnHisCoil4.AutoSize = True
        Me.btnHisCoil4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHisCoil4.Location = New System.Drawing.Point(288, 0)
        Me.btnHisCoil4.Margin = New System.Windows.Forms.Padding(0)
        Me.btnHisCoil4.Name = "btnHisCoil4"
        Me.btnHisCoil4.Size = New System.Drawing.Size(96, 29)
        Me.btnHisCoil4.TabIndex = 3
        Me.btnHisCoil4.UseVisualStyleBackColor = True
        '
        'btnHisCoil5
        '
        Me.btnHisCoil5.AutoSize = True
        Me.btnHisCoil5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHisCoil5.Location = New System.Drawing.Point(384, 0)
        Me.btnHisCoil5.Margin = New System.Windows.Forms.Padding(0)
        Me.btnHisCoil5.Name = "btnHisCoil5"
        Me.btnHisCoil5.Size = New System.Drawing.Size(96, 29)
        Me.btnHisCoil5.TabIndex = 4
        Me.btnHisCoil5.UseVisualStyleBackColor = True
        '
        'btnHisCoil6
        '
        Me.btnHisCoil6.AutoSize = True
        Me.btnHisCoil6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHisCoil6.Location = New System.Drawing.Point(480, 0)
        Me.btnHisCoil6.Margin = New System.Windows.Forms.Padding(0)
        Me.btnHisCoil6.Name = "btnHisCoil6"
        Me.btnHisCoil6.Size = New System.Drawing.Size(96, 29)
        Me.btnHisCoil6.TabIndex = 5
        Me.btnHisCoil6.UseVisualStyleBackColor = True
        '
        'MainControl_CoilNumberInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "MainControl_CoilNumberInput"
        Me.Size = New System.Drawing.Size(810, 508)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        CType(Me.pbGetOnlineCoilNumber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fpHistoryCoilContainer.ResumeLayout(False)
        Me.fpHistoryCoilContainer.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnOKReturn As System.Windows.Forms.Button
    Friend WithEvents btnCancelReturn As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnMixCoilChange As System.Windows.Forms.Button
    Friend WithEvents tbNewCoilNumber As System.Windows.Forms.TextBox
    Friend WithEvents tbCoilNumber As System.Windows.Forms.TextBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pbGetOnlineCoilNumber As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents fpHistoryCoilContainer As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnHisCoil1 As System.Windows.Forms.Button
    Friend WithEvents btnHisCoil2 As System.Windows.Forms.Button
    Friend WithEvents btnHisCoil3 As System.Windows.Forms.Button
    Friend WithEvents btnHisCoil4 As System.Windows.Forms.Button
    Friend WithEvents btnHisCoil5 As System.Windows.Forms.Button
    Friend WithEvents btnHisCoil6 As System.Windows.Forms.Button

End Class
