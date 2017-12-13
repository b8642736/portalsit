<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserLogin
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

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.tbNewpwd = New System.Windows.Forms.TextBox()
        Me.btnChangepwd = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbLoginpwd = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbLoginID = New System.Windows.Forms.TextBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.btnSavepwd = New System.Windows.Forms.Button()
        Me.btnCancelSavepwd = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbMessage = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.tbNewpwd, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnChangepwd, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.tbLoginpwd, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbLoginID, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnLogin, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSavepwd, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancelSavepwd, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lbMessage, 1, 3)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(16, 18)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(463, 140)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'tbNewpwd
        '
        Me.tbNewpwd.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbNewpwd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbNewpwd.Enabled = False
        Me.tbNewpwd.Location = New System.Drawing.Point(103, 76)
        Me.tbNewpwd.MaxLength = 7
        Me.tbNewpwd.Name = "tbNewpwd"
        Me.tbNewpwd.Size = New System.Drawing.Size(94, 22)
        Me.tbNewpwd.TabIndex = 8
        '
        'btnChangepwd
        '
        Me.btnChangepwd.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChangepwd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnChangepwd.Location = New System.Drawing.Point(203, 38)
        Me.btnChangepwd.Name = "btnChangepwd"
        Me.btnChangepwd.Size = New System.Drawing.Size(117, 29)
        Me.btnChangepwd.TabIndex = 6
        Me.btnChangepwd.Text = "變更密碼"
        Me.btnChangepwd.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "變更設定新密碼:"
        '
        'tbLoginpwd
        '
        Me.tbLoginpwd.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbLoginpwd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbLoginpwd.Location = New System.Drawing.Point(103, 41)
        Me.tbLoginpwd.MaxLength = 7
        Me.tbLoginpwd.Name = "tbLoginpwd"
        Me.tbLoginpwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbLoginpwd.Size = New System.Drawing.Size(94, 22)
        Me.tbLoginpwd.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "使用者工號:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(65, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "密碼:"
        '
        'tbLoginID
        '
        Me.tbLoginID.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbLoginID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbLoginID.Location = New System.Drawing.Point(103, 6)
        Me.tbLoginID.MaxLength = 7
        Me.tbLoginID.Name = "tbLoginID"
        Me.tbLoginID.Size = New System.Drawing.Size(94, 22)
        Me.tbLoginID.TabIndex = 2
        '
        'btnLogin
        '
        Me.btnLogin.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogin.Location = New System.Drawing.Point(203, 3)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(117, 29)
        Me.btnLogin.TabIndex = 5
        Me.btnLogin.Text = "登入"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'btnSavepwd
        '
        Me.btnSavepwd.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSavepwd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSavepwd.Enabled = False
        Me.btnSavepwd.Location = New System.Drawing.Point(203, 73)
        Me.btnSavepwd.Name = "btnSavepwd"
        Me.btnSavepwd.Size = New System.Drawing.Size(117, 29)
        Me.btnSavepwd.TabIndex = 7
        Me.btnSavepwd.Text = "儲存新密碼"
        Me.btnSavepwd.UseVisualStyleBackColor = True
        '
        'btnCancelSavepwd
        '
        Me.btnCancelSavepwd.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelSavepwd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelSavepwd.Enabled = False
        Me.btnCancelSavepwd.Location = New System.Drawing.Point(326, 73)
        Me.btnCancelSavepwd.Name = "btnCancelSavepwd"
        Me.btnCancelSavepwd.Size = New System.Drawing.Size(134, 29)
        Me.btnCancelSavepwd.TabIndex = 9
        Me.btnCancelSavepwd.Text = "取消儲存"
        Me.btnCancelSavepwd.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(65, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 12)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "訊息:"
        '
        'lbMessage
        '
        Me.lbMessage.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbMessage.AutoSize = True
        Me.lbMessage.ForeColor = System.Drawing.Color.Red
        Me.lbMessage.Location = New System.Drawing.Point(103, 116)
        Me.lbMessage.Name = "lbMessage"
        Me.lbMessage.Size = New System.Drawing.Size(17, 12)
        Me.lbMessage.TabIndex = 11
        Me.lbMessage.Text = "---"
        '
        'UserLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "UserLogin"
        Me.Size = New System.Drawing.Size(517, 187)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbLoginpwd As System.Windows.Forms.TextBox
    Friend WithEvents tbLoginID As System.Windows.Forms.TextBox
    Friend WithEvents btnChangepwd As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents btnSavepwd As System.Windows.Forms.Button
    Friend WithEvents tbNewpwd As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelSavepwd As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbMessage As System.Windows.Forms.Label

End Class
