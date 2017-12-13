<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainControl_UserLogin
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
        Me.tbLoginID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.rbAPL1 = New System.Windows.Forms.RadioButton()
        Me.rbAPL2 = New System.Windows.Forms.RadioButton()
        Me.rbBAL = New System.Windows.Forms.RadioButton()
        Me.lbMessage = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbPassword = New System.Windows.Forms.TextBox()
        Me.EditPanel = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnChangeHand = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.pbGetL2Length = New System.Windows.Forms.PictureBox()
        Me.tbHandPosition = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        CType(Me.pbGetL2Length, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.tbLoginID, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbPassword, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.EditPanel, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnChangeHand, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2, 3, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(896, 519)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'tbLoginID
        '
        Me.tbLoginID.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbLoginID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbLoginID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbLoginID.Font = New System.Drawing.Font("標楷體", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tbLoginID.Location = New System.Drawing.Point(153, 3)
        Me.tbLoginID.MaxLength = 6
        Me.tbLoginID.Name = "tbLoginID"
        Me.tbLoginID.Size = New System.Drawing.Size(144, 46)
        Me.tbLoginID.TabIndex = 4
        Me.tbLoginID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "登入工號:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(135, 48)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "登入編修站別:"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.FlowLayoutPanel1, 4)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbAPL1)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbAPL2)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbBAL)
        Me.FlowLayoutPanel1.Controls.Add(Me.lbMessage)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(153, 103)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(740, 74)
        Me.FlowLayoutPanel1.TabIndex = 3
        '
        'rbAPL1
        '
        Me.rbAPL1.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbAPL1.Checked = True
        Me.rbAPL1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbAPL1.Font = New System.Drawing.Font("新細明體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rbAPL1.Location = New System.Drawing.Point(3, 3)
        Me.rbAPL1.Name = "rbAPL1"
        Me.rbAPL1.Size = New System.Drawing.Size(105, 68)
        Me.rbAPL1.TabIndex = 3
        Me.rbAPL1.TabStop = True
        Me.rbAPL1.Text = "登入APL1"
        Me.rbAPL1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbAPL1.UseVisualStyleBackColor = True
        '
        'rbAPL2
        '
        Me.rbAPL2.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbAPL2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbAPL2.Font = New System.Drawing.Font("新細明體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rbAPL2.Location = New System.Drawing.Point(114, 3)
        Me.rbAPL2.Name = "rbAPL2"
        Me.rbAPL2.Size = New System.Drawing.Size(105, 68)
        Me.rbAPL2.TabIndex = 4
        Me.rbAPL2.Text = "登入APL2"
        Me.rbAPL2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbAPL2.UseVisualStyleBackColor = True
        '
        'rbBAL
        '
        Me.rbBAL.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbBAL.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbBAL.Font = New System.Drawing.Font("新細明體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rbBAL.Location = New System.Drawing.Point(225, 3)
        Me.rbBAL.Name = "rbBAL"
        Me.rbBAL.Size = New System.Drawing.Size(105, 68)
        Me.rbBAL.TabIndex = 5
        Me.rbBAL.Text = "登入BAL"
        Me.rbBAL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbBAL.UseVisualStyleBackColor = True
        '
        'lbMessage
        '
        Me.lbMessage.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbMessage.Location = New System.Drawing.Point(336, 0)
        Me.lbMessage.Name = "lbMessage"
        Me.lbMessage.Size = New System.Drawing.Size(217, 71)
        Me.lbMessage.TabIndex = 6
        Me.lbMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "登入密碼:"
        '
        'tbPassword
        '
        Me.tbPassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbPassword.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbPassword.Font = New System.Drawing.Font("標楷體", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tbPassword.Location = New System.Drawing.Point(153, 53)
        Me.tbPassword.MaxLength = 10
        Me.tbPassword.Name = "tbPassword"
        Me.tbPassword.Size = New System.Drawing.Size(144, 46)
        Me.tbPassword.TabIndex = 5
        Me.tbPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbPassword.UseSystemPasswordChar = True
        '
        'EditPanel
        '
        Me.EditPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.EditPanel, 5)
        Me.EditPanel.Location = New System.Drawing.Point(593, 336)
        Me.EditPanel.Name = "EditPanel"
        Me.EditPanel.Size = New System.Drawing.Size(300, 180)
        Me.EditPanel.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(324, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 24)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "交接米數:"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(324, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 24)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "交接按鈕:"
        '
        'btnChangeHand
        '
        Me.btnChangeHand.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnChangeHand.AutoSize = True
        Me.btnChangeHand.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnChangeHand.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnChangeHand.Location = New System.Drawing.Point(453, 53)
        Me.btnChangeHand.Name = "btnChangeHand"
        Me.btnChangeHand.Size = New System.Drawing.Size(195, 44)
        Me.btnChangeHand.TabIndex = 9
        Me.btnChangeHand.Text = "交接並關閉系統"
        Me.btnChangeHand.UseVisualStyleBackColor = True
        Me.btnChangeHand.Visible = False
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel2.Controls.Add(Me.pbGetL2Length)
        Me.FlowLayoutPanel2.Controls.Add(Me.tbHandPosition)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(453, 3)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(394, 44)
        Me.FlowLayoutPanel2.TabIndex = 10
        '
        'pbGetL2Length
        '
        Me.pbGetL2Length.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.pbGetL2Length.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbGetL2Length.Image = Global.QAColdRollingClient.My.Resources.Resources.L2MsgGet
        Me.pbGetL2Length.Location = New System.Drawing.Point(0, 0)
        Me.pbGetL2Length.Margin = New System.Windows.Forms.Padding(0)
        Me.pbGetL2Length.Name = "pbGetL2Length"
        Me.pbGetL2Length.Size = New System.Drawing.Size(46, 46)
        Me.pbGetL2Length.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbGetL2Length.TabIndex = 7
        Me.pbGetL2Length.TabStop = False
        Me.pbGetL2Length.Visible = False
        '
        'tbHandPosition
        '
        Me.tbHandPosition.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tbHandPosition.Location = New System.Drawing.Point(49, 3)
        Me.tbHandPosition.Name = "tbHandPosition"
        Me.tbHandPosition.Size = New System.Drawing.Size(146, 36)
        Me.tbHandPosition.TabIndex = 8
        Me.tbHandPosition.Visible = False
        '
        'MainControl_UserLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "MainControl_UserLogin"
        Me.Size = New System.Drawing.Size(899, 522)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        CType(Me.pbGetL2Length, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbAPL1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbAPL2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbBAL As System.Windows.Forms.RadioButton
    Friend WithEvents tbPassword As System.Windows.Forms.TextBox
    Friend WithEvents tbLoginID As System.Windows.Forms.TextBox
    Friend WithEvents EditPanel As System.Windows.Forms.Panel
    Friend WithEvents lbMessage As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnChangeHand As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pbGetL2Length As System.Windows.Forms.PictureBox
    Friend WithEvents tbHandPosition As System.Windows.Forms.TextBox

End Class
