<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BugItemEdit_LengthInput
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
        Me.components = New System.ComponentModel.Container()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.KeyBoardPanel = New System.Windows.Forms.Panel()
        Me.lbInputCaption = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.flpPositionLengthArial = New System.Windows.Forms.FlowLayoutPanel()
        Me.pbGetL2Msg1 = New System.Windows.Forms.PictureBox()
        Me.tbStartLength = New System.Windows.Forms.TextBox()
        Me.btnSlash = New System.Windows.Forms.Button()
        Me.pbGetL2Msg2 = New System.Windows.Forms.PictureBox()
        Me.tbEndLength = New System.Windows.Forms.TextBox()
        Me.flpPositionWidthArial = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbIn = New System.Windows.Forms.RadioButton()
        Me.rbOut = New System.Windows.Forms.RadioButton()
        Me.rbAll = New System.Windows.Forms.RadioButton()
        Me.rbTwo = New System.Windows.Forms.RadioButton()
        Me.rbNone = New System.Windows.Forms.RadioButton()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.pbGetL2Msg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbGetL2Msg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flpPositionWidthArial.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.71429!))
        Me.TableLayoutPanel1.Controls.Add(Me.KeyBoardPanel, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbInputCaption, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.flpPositionWidthArial, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(761, 389)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'KeyBoardPanel
        '
        Me.KeyBoardPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.KeyBoardPanel, 2)
        Me.KeyBoardPanel.Location = New System.Drawing.Point(558, 206)
        Me.KeyBoardPanel.Name = "KeyBoardPanel"
        Me.KeyBoardPanel.Size = New System.Drawing.Size(200, 180)
        Me.KeyBoardPanel.TabIndex = 2
        '
        'lbInputCaption
        '
        Me.lbInputCaption.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbInputCaption.AutoSize = True
        Me.lbInputCaption.Font = New System.Drawing.Font("標楷體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbInputCaption.Location = New System.Drawing.Point(3, 35)
        Me.lbInputCaption.Name = "lbInputCaption"
        Me.lbInputCaption.Size = New System.Drawing.Size(102, 35)
        Me.lbInputCaption.TabIndex = 4
        Me.lbInputCaption.Text = "長/寬:"
        Me.lbInputCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.Controls.Add(Me.flpPositionLengthArial)
        Me.FlowLayoutPanel1.Controls.Add(Me.pbGetL2Msg1)
        Me.FlowLayoutPanel1.Controls.Add(Me.tbStartLength)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnSlash)
        Me.FlowLayoutPanel1.Controls.Add(Me.pbGetL2Msg2)
        Me.FlowLayoutPanel1.Controls.Add(Me.tbEndLength)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(111, 38)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(647, 29)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'flpPositionLengthArial
        '
        Me.flpPositionLengthArial.AutoSize = True
        Me.flpPositionLengthArial.Location = New System.Drawing.Point(3, 3)
        Me.flpPositionLengthArial.Name = "flpPositionLengthArial"
        Me.flpPositionLengthArial.Size = New System.Drawing.Size(0, 0)
        Me.flpPositionLengthArial.TabIndex = 3
        '
        'pbGetL2Msg1
        '
        Me.pbGetL2Msg1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbGetL2Msg1.Image = Global.QAColdRollingClient.My.Resources.Resources.L2MsgGet
        Me.pbGetL2Msg1.Location = New System.Drawing.Point(6, 0)
        Me.pbGetL2Msg1.Margin = New System.Windows.Forms.Padding(0)
        Me.pbGetL2Msg1.Name = "pbGetL2Msg1"
        Me.pbGetL2Msg1.Size = New System.Drawing.Size(30, 30)
        Me.pbGetL2Msg1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbGetL2Msg1.TabIndex = 6
        Me.pbGetL2Msg1.TabStop = False
        '
        'tbStartLength
        '
        Me.tbStartLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbStartLength.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbStartLength.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tbStartLength.Location = New System.Drawing.Point(39, 3)
        Me.tbStartLength.MaxLength = 5
        Me.tbStartLength.Name = "tbStartLength"
        Me.tbStartLength.Size = New System.Drawing.Size(90, 36)
        Me.tbStartLength.TabIndex = 3
        Me.tbStartLength.Text = "1"
        Me.tbStartLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbStartLength.WordWrap = False
        '
        'btnSlash
        '
        Me.btnSlash.AutoSize = True
        Me.btnSlash.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSlash.BackColor = System.Drawing.Color.Transparent
        Me.btnSlash.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSlash.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSlash.Font = New System.Drawing.Font("細明體", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnSlash.Location = New System.Drawing.Point(132, 0)
        Me.btnSlash.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSlash.Name = "btnSlash"
        Me.btnSlash.Size = New System.Drawing.Size(43, 44)
        Me.btnSlash.TabIndex = 8
        Me.btnSlash.Text = "~"
        Me.btnSlash.UseVisualStyleBackColor = False
        '
        'pbGetL2Msg2
        '
        Me.pbGetL2Msg2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbGetL2Msg2.Image = Global.QAColdRollingClient.My.Resources.Resources.L2MsgGet
        Me.pbGetL2Msg2.Location = New System.Drawing.Point(175, 0)
        Me.pbGetL2Msg2.Margin = New System.Windows.Forms.Padding(0)
        Me.pbGetL2Msg2.Name = "pbGetL2Msg2"
        Me.pbGetL2Msg2.Size = New System.Drawing.Size(30, 30)
        Me.pbGetL2Msg2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbGetL2Msg2.TabIndex = 7
        Me.pbGetL2Msg2.TabStop = False
        '
        'tbEndLength
        '
        Me.tbEndLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbEndLength.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbEndLength.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tbEndLength.Location = New System.Drawing.Point(208, 3)
        Me.tbEndLength.MaxLength = 5
        Me.tbEndLength.Name = "tbEndLength"
        Me.tbEndLength.Size = New System.Drawing.Size(90, 36)
        Me.tbEndLength.TabIndex = 4
        Me.tbEndLength.Text = "9999"
        Me.tbEndLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbEndLength.WordWrap = False
        '
        'flpPositionWidthArial
        '
        Me.flpPositionWidthArial.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpPositionWidthArial.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.flpPositionWidthArial, 2)
        Me.flpPositionWidthArial.Controls.Add(Me.Label2)
        Me.flpPositionWidthArial.Controls.Add(Me.rbIn)
        Me.flpPositionWidthArial.Controls.Add(Me.rbOut)
        Me.flpPositionWidthArial.Controls.Add(Me.rbAll)
        Me.flpPositionWidthArial.Controls.Add(Me.rbTwo)
        Me.flpPositionWidthArial.Controls.Add(Me.rbNone)
        Me.flpPositionWidthArial.Location = New System.Drawing.Point(3, 3)
        Me.flpPositionWidthArial.Name = "flpPositionWidthArial"
        Me.flpPositionWidthArial.Size = New System.Drawing.Size(755, 29)
        Me.flpPositionWidthArial.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("標楷體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 42)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "寬度範圍:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rbIn
        '
        Me.rbIn.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbIn.AutoSize = True
        Me.rbIn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbIn.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red
        Me.rbIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbIn.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rbIn.Location = New System.Drawing.Point(147, 3)
        Me.rbIn.Name = "rbIn"
        Me.rbIn.Size = New System.Drawing.Size(60, 36)
        Me.rbIn.TabIndex = 3
        Me.rbIn.Tag = "1"
        Me.rbIn.Text = "1內"
        Me.rbIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbIn.UseVisualStyleBackColor = True
        '
        'rbOut
        '
        Me.rbOut.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbOut.AutoSize = True
        Me.rbOut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbOut.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red
        Me.rbOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbOut.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rbOut.Location = New System.Drawing.Point(213, 3)
        Me.rbOut.Name = "rbOut"
        Me.rbOut.Size = New System.Drawing.Size(60, 36)
        Me.rbOut.TabIndex = 4
        Me.rbOut.Text = "2外"
        Me.rbOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbOut.UseVisualStyleBackColor = True
        '
        'rbAll
        '
        Me.rbAll.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbAll.AutoSize = True
        Me.rbAll.Checked = True
        Me.rbAll.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbAll.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red
        Me.rbAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbAll.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rbAll.Location = New System.Drawing.Point(279, 3)
        Me.rbAll.Name = "rbAll"
        Me.rbAll.Size = New System.Drawing.Size(60, 36)
        Me.rbAll.TabIndex = 6
        Me.rbAll.TabStop = True
        Me.rbAll.Tag = "0"
        Me.rbAll.Text = "3全"
        Me.rbAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbAll.UseVisualStyleBackColor = True
        '
        'rbTwo
        '
        Me.rbTwo.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbTwo.AutoSize = True
        Me.rbTwo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbTwo.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red
        Me.rbTwo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbTwo.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rbTwo.Location = New System.Drawing.Point(345, 3)
        Me.rbTwo.Name = "rbTwo"
        Me.rbTwo.Size = New System.Drawing.Size(60, 36)
        Me.rbTwo.TabIndex = 5
        Me.rbTwo.Text = "4雙"
        Me.rbTwo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbTwo.UseVisualStyleBackColor = True
        '
        'rbNone
        '
        Me.rbNone.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbNone.AutoSize = True
        Me.rbNone.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbNone.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red
        Me.rbNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbNone.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rbNone.Location = New System.Drawing.Point(411, 3)
        Me.rbNone.Name = "rbNone"
        Me.rbNone.Size = New System.Drawing.Size(60, 36)
        Me.rbNone.TabIndex = 7
        Me.rbNone.Text = "5無"
        Me.rbNone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbNone.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'BugItemEdit_LengthInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "BugItemEdit_LengthInput"
        Me.Size = New System.Drawing.Size(761, 389)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        CType(Me.pbGetL2Msg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbGetL2Msg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpPositionWidthArial.ResumeLayout(False)
        Me.flpPositionWidthArial.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents tbStartLength As System.Windows.Forms.TextBox
    Friend WithEvents tbEndLength As System.Windows.Forms.TextBox
    Friend WithEvents flpPositionWidthArial As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbIn As System.Windows.Forms.RadioButton
    Friend WithEvents rbOut As System.Windows.Forms.RadioButton
    Friend WithEvents rbTwo As System.Windows.Forms.RadioButton
    Friend WithEvents rbAll As System.Windows.Forms.RadioButton
    Friend WithEvents rbNone As System.Windows.Forms.RadioButton
    Friend WithEvents KeyBoardPanel As System.Windows.Forms.Panel
    Friend WithEvents flpPositionLengthArial As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbInputCaption As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents pbGetL2Msg1 As System.Windows.Forms.PictureBox
    Friend WithEvents pbGetL2Msg2 As System.Windows.Forms.PictureBox
    Friend WithEvents btnSlash As System.Windows.Forms.Button

End Class
