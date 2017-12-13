<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCWaitReceived2Check
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCWaitReceived2Check))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbMsgText = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbSendTime = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lbSenderInfo = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbSeceiverInfo = New System.Windows.Forms.Label
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.tsbCheckOne = New System.Windows.Forms.ToolStripButton
        Me.tsbCheckSelected = New System.Windows.Forms.ToolStripButton
        Me.tsnReReadNOCheckMessage = New System.Windows.Forms.ToolStripButton
        Me.bsSearchResult = New System.Windows.Forms.BindingSource(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsslMessage = New System.Windows.Forms.ToolStripStatusLabel
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.bsSearchResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.19048!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.80952!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TreeView1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ToolStrip2, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(5)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.345795!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.65421!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(910, 678)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.21312!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.78688!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lbMsgText, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lbSendTime, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.RichTextBox1, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lbSenderInfo, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lbSeceiverInfo, 1, 3)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(243, 68)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(5)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 5
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(662, 605)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 14)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "訊息名稱:"
        '
        'lbMsgText
        '
        Me.lbMsgText.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbMsgText.AutoSize = True
        Me.lbMsgText.Location = New System.Drawing.Point(118, 14)
        Me.lbMsgText.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lbMsgText.Name = "lbMsgText"
        Me.lbMsgText.Size = New System.Drawing.Size(105, 19)
        Me.lbMsgText.TabIndex = 1
        Me.lbMsgText.Text = "<訊息名稱>"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 62)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 19)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "發送時間:"
        '
        'lbSendTime
        '
        Me.lbSendTime.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbSendTime.AutoSize = True
        Me.lbSendTime.Location = New System.Drawing.Point(118, 62)
        Me.lbSendTime.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lbSendTime.Name = "lbSendTime"
        Me.lbSendTime.Size = New System.Drawing.Size(105, 19)
        Me.lbSendTime.TabIndex = 4
        Me.lbSendTime.Text = "<發送時間>"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 192)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 19)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "附加訊息:"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.AliceBlue
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Location = New System.Drawing.Point(118, 197)
        Me.RichTextBox1.Margin = New System.Windows.Forms.Padding(5)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(539, 403)
        Me.RichTextBox1.TabIndex = 6
        Me.RichTextBox1.Text = ""
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 110)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 19)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "訊息來源:"
        '
        'lbSenderInfo
        '
        Me.lbSenderInfo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbSenderInfo.AutoSize = True
        Me.lbSenderInfo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbSenderInfo.Location = New System.Drawing.Point(118, 110)
        Me.lbSenderInfo.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lbSenderInfo.Name = "lbSenderInfo"
        Me.lbSenderInfo.Size = New System.Drawing.Size(143, 19)
        Me.lbSenderInfo.TabIndex = 9
        Me.lbSenderInfo.Text = "<發送訊息來源>"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 158)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 19)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "訊息接收:"
        '
        'lbSeceiverInfo
        '
        Me.lbSeceiverInfo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbSeceiverInfo.AutoSize = True
        Me.lbSeceiverInfo.Location = New System.Drawing.Point(118, 158)
        Me.lbSeceiverInfo.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lbSeceiverInfo.Name = "lbSeceiverInfo"
        Me.lbSeceiverInfo.Size = New System.Drawing.Size(162, 19)
        Me.lbSeceiverInfo.TabIndex = 11
        Me.lbSeceiverInfo.Text = "<訊息接收者資訊>"
        '
        'TreeView1
        '
        Me.TreeView1.CheckBoxes = True
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Location = New System.Drawing.Point(5, 5)
        Me.TreeView1.Margin = New System.Windows.Forms.Padding(5)
        Me.TreeView1.Name = "TreeView1"
        Me.TableLayoutPanel1.SetRowSpan(Me.TreeView1, 2)
        Me.TreeView1.ShowLines = False
        Me.TreeView1.Size = New System.Drawing.Size(228, 668)
        Me.TreeView1.TabIndex = 1
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbCheckOne, Me.tsbCheckSelected, Me.tsnReReadNOCheckMessage})
        Me.ToolStrip2.Location = New System.Drawing.Point(238, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStrip2.Size = New System.Drawing.Size(672, 63)
        Me.ToolStrip2.TabIndex = 7
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'tsbCheckOne
        '
        Me.tsbCheckOne.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbCheckOne.Enabled = False
        Me.tsbCheckOne.Image = CType(resources.GetObject("tsbCheckOne.Image"), System.Drawing.Image)
        Me.tsbCheckOne.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCheckOne.Name = "tsbCheckOne"
        Me.tsbCheckOne.Size = New System.Drawing.Size(128, 60)
        Me.tsbCheckOne.Text = "單筆確認讀取"
        '
        'tsbCheckSelected
        '
        Me.tsbCheckSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbCheckSelected.Enabled = False
        Me.tsbCheckSelected.Image = CType(resources.GetObject("tsbCheckSelected.Image"), System.Drawing.Image)
        Me.tsbCheckSelected.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCheckSelected.Name = "tsbCheckSelected"
        Me.tsbCheckSelected.Size = New System.Drawing.Size(128, 60)
        Me.tsbCheckSelected.Text = "選取確認讀取"
        Me.tsbCheckSelected.ToolTipText = "選取確認讀取"
        '
        'tsnReReadNOCheckMessage
        '
        Me.tsnReReadNOCheckMessage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsnReReadNOCheckMessage.Image = CType(resources.GetObject("tsnReReadNOCheckMessage.Image"), System.Drawing.Image)
        Me.tsnReReadNOCheckMessage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsnReReadNOCheckMessage.Name = "tsnReReadNOCheckMessage"
        Me.tsnReReadNOCheckMessage.Size = New System.Drawing.Size(185, 50)
        Me.tsnReReadNOCheckMessage.Text = "重新取得未讀取訊息"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tsslMessage})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 646)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(910, 32)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(59, 27)
        Me.ToolStripStatusLabel1.Text = "訊息:"
        '
        'tsslMessage
        '
        Me.tsslMessage.ForeColor = System.Drawing.Color.Red
        Me.tsslMessage.Name = "tsslMessage"
        Me.tsslMessage.Size = New System.Drawing.Size(39, 27)
        Me.tsslMessage.Text = "無!"
        '
        'UCWaitReceived2Check
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "UCWaitReceived2Check"
        Me.Size = New System.Drawing.Size(910, 678)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.bsSearchResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents bsSearchResult As System.Windows.Forms.BindingSource
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbMsgText As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbSendTime As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbCheckOne As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCheckSelected As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsnReReadNOCheckMessage As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbSenderInfo As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbSeceiverInfo As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslMessage As System.Windows.Forms.ToolStripStatusLabel

End Class
