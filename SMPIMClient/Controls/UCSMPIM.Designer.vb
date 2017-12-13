<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCSMPIM
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
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("新訊息接收")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("本機傳送未回應")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCSMPIM))
        Me.rbSetAuthority2 = New System.Windows.Forms.RadioButton
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TPMoniter = New System.Windows.Forms.TabPage
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
        Me.TPReceiveMsg = New System.Windows.Forms.TabPage
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.ILMessage = New System.Windows.Forms.ImageList(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbMsgText = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbSendTime = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.tsbCheckOne = New System.Windows.Forms.ToolStripButton
        Me.tsbCheckSelected = New System.Windows.Forms.ToolStripButton
        Me.tsnReReadNOCheckMessage = New System.Windows.Forms.ToolStripButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.lbSenderInfo = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbSeceiverInfo = New System.Windows.Forms.Label
        Me.TPMessageSendAndSearch = New System.Windows.Forms.TabPage
        Me.WebBrowser2 = New System.Windows.Forms.WebBrowser
        Me.TPSchedual = New System.Windows.Forms.TabPage
        Me.TPChangeClassMsg = New System.Windows.Forms.TabPage
        Me.TPSysOperator = New System.Windows.Forms.TabPage
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbSetAuthority1 = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.MTBIP = New System.Windows.Forms.TextBox
        Me.rbSebWebServer3 = New System.Windows.Forms.RadioButton
        Me.rbSebWebServer2 = New System.Windows.Forms.RadioButton
        Me.rbSebWebServer1 = New System.Windows.Forms.RadioButton
        Me.btnRefreshWeb = New System.Windows.Forms.Button
        Me.tsslMessage = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.bsMessageToSiteUser = New System.Windows.Forms.BindingSource(Me.components)
        Me.RefreshBackNodeTimer = New System.Windows.Forms.Timer(Me.components)
        Me.tsbMsgToNextClass = New System.Windows.Forms.ToolStripButton
        Me.TabControl1.SuspendLayout()
        Me.TPMoniter.SuspendLayout()
        Me.TPReceiveMsg.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.TPMessageSendAndSearch.SuspendLayout()
        Me.TPSysOperator.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.bsMessageToSiteUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rbSetAuthority2
        '
        Me.rbSetAuthority2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbSetAuthority2.AutoSize = True
        Me.rbSetAuthority2.Location = New System.Drawing.Point(112, 35)
        Me.rbSetAuthority2.Name = "rbSetAuthority2"
        Me.rbSetAuthority2.Size = New System.Drawing.Size(165, 23)
        Me.rbSetAuthority2.TabIndex = 1
        Me.rbSetAuthority2.Text = "Window登入授權"
        Me.rbSetAuthority2.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TPMoniter)
        Me.TabControl1.Controls.Add(Me.TPReceiveMsg)
        Me.TabControl1.Controls.Add(Me.TPMessageSendAndSearch)
        Me.TabControl1.Controls.Add(Me.TPSchedual)
        Me.TabControl1.Controls.Add(Me.TPChangeClassMsg)
        Me.TabControl1.Controls.Add(Me.TPSysOperator)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabControl1.ImageList = Me.ILMessage
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(659, 511)
        Me.TabControl1.TabIndex = 2
        '
        'TPMoniter
        '
        Me.TPMoniter.Controls.Add(Me.WebBrowser1)
        Me.TPMoniter.Location = New System.Drawing.Point(4, 29)
        Me.TPMoniter.Name = "TPMoniter"
        Me.TPMoniter.Padding = New System.Windows.Forms.Padding(3)
        Me.TPMoniter.Size = New System.Drawing.Size(651, 478)
        Me.TPMoniter.TabIndex = 0
        Me.TPMoniter.Text = "化學成份監看"
        Me.TPMoniter.UseVisualStyleBackColor = True
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(3, 3)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(645, 472)
        Me.WebBrowser1.TabIndex = 0
        Me.WebBrowser1.Url = New System.Uri("", System.UriKind.Relative)
        '
        'TPReceiveMsg
        '
        Me.TPReceiveMsg.Controls.Add(Me.SplitContainer1)
        Me.TPReceiveMsg.Location = New System.Drawing.Point(4, 29)
        Me.TPReceiveMsg.Name = "TPReceiveMsg"
        Me.TPReceiveMsg.Padding = New System.Windows.Forms.Padding(3)
        Me.TPReceiveMsg.Size = New System.Drawing.Size(651, 478)
        Me.TPReceiveMsg.TabIndex = 1
        Me.TPReceiveMsg.Text = "訊息接收"
        Me.TPReceiveMsg.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TreeView1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(645, 472)
        Me.SplitContainer1.SplitterDistance = 302
        Me.SplitContainer1.TabIndex = 0
        '
        'TreeView1
        '
        Me.TreeView1.CheckBoxes = True
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.ILMessage
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Name = "TreeView1"
        TreeNode3.Name = "NewNode"
        TreeNode3.Text = "新訊息接收"
        TreeNode4.Name = "BackNode"
        TreeNode4.Text = "本機傳送未回應"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode3, TreeNode4})
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.Size = New System.Drawing.Size(302, 472)
        Me.TreeView1.TabIndex = 0
        '
        'ILMessage
        '
        Me.ILMessage.ImageStream = CType(resources.GetObject("ILMessage.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ILMessage.TransparentColor = System.Drawing.Color.Transparent
        Me.ILMessage.Images.SetKeyName(0, "ReadingMail.png")
        Me.ILMessage.Images.SetKeyName(1, "SendMail.png")
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.21312!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.78688!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbMsgText, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbSendTime, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.RichTextBox1, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.ToolStrip2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lbSenderInfo, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lbSeceiverInfo, 1, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(339, 472)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "訊息名稱:"
        '
        'lbMsgText
        '
        Me.lbMsgText.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbMsgText.AutoSize = True
        Me.lbMsgText.Location = New System.Drawing.Point(61, 35)
        Me.lbMsgText.Name = "lbMsgText"
        Me.lbMsgText.Size = New System.Drawing.Size(105, 19)
        Me.lbMsgText.TabIndex = 1
        Me.lbMsgText.Text = "<訊息名稱>"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 30)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "發送時間:"
        '
        'lbSendTime
        '
        Me.lbSendTime.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbSendTime.AutoSize = True
        Me.lbSendTime.Location = New System.Drawing.Point(61, 65)
        Me.lbSendTime.Name = "lbSendTime"
        Me.lbSendTime.Size = New System.Drawing.Size(105, 19)
        Me.lbSendTime.TabIndex = 4
        Me.lbSendTime.Text = "<發送時間>"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 38)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "附加訊息:"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.AliceBlue
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Location = New System.Drawing.Point(61, 153)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(275, 316)
        Me.RichTextBox1.TabIndex = 6
        Me.RichTextBox1.Text = ""
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.ToolStrip2, 2)
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbCheckOne, Me.tsbCheckSelected, Me.tsbMsgToNextClass, Me.tsnReReadNOCheckMessage})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(339, 30)
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
        Me.tsbCheckOne.Size = New System.Drawing.Size(128, 27)
        Me.tsbCheckOne.Text = "單筆確認讀取"
        '
        'tsbCheckSelected
        '
        Me.tsbCheckSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbCheckSelected.Enabled = False
        Me.tsbCheckSelected.Image = CType(resources.GetObject("tsbCheckSelected.Image"), System.Drawing.Image)
        Me.tsbCheckSelected.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCheckSelected.Name = "tsbCheckSelected"
        Me.tsbCheckSelected.Size = New System.Drawing.Size(128, 27)
        Me.tsbCheckSelected.Text = "選取確認讀取"
        Me.tsbCheckSelected.ToolTipText = "選取確認讀取"
        '
        'tsnReReadNOCheckMessage
        '
        Me.tsnReReadNOCheckMessage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsnReReadNOCheckMessage.Image = CType(resources.GetObject("tsnReReadNOCheckMessage.Image"), System.Drawing.Image)
        Me.tsnReReadNOCheckMessage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsnReReadNOCheckMessage.Name = "tsnReReadNOCheckMessage"
        Me.tsnReReadNOCheckMessage.Size = New System.Drawing.Size(185, 28)
        Me.tsnReReadNOCheckMessage.Text = "重新取得未讀取訊息"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 30)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "訊息來源:"
        '
        'lbSenderInfo
        '
        Me.lbSenderInfo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbSenderInfo.AutoSize = True
        Me.lbSenderInfo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbSenderInfo.Location = New System.Drawing.Point(61, 95)
        Me.lbSenderInfo.Name = "lbSenderInfo"
        Me.lbSenderInfo.Size = New System.Drawing.Size(143, 19)
        Me.lbSenderInfo.TabIndex = 9
        Me.lbSenderInfo.Text = "<發送訊息來源>"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 30)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "訊息接收:"
        '
        'lbSeceiverInfo
        '
        Me.lbSeceiverInfo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbSeceiverInfo.AutoSize = True
        Me.lbSeceiverInfo.Location = New System.Drawing.Point(61, 125)
        Me.lbSeceiverInfo.Name = "lbSeceiverInfo"
        Me.lbSeceiverInfo.Size = New System.Drawing.Size(162, 19)
        Me.lbSeceiverInfo.TabIndex = 11
        Me.lbSeceiverInfo.Text = "<訊息接收者資訊>"
        '
        'TPMessageSendAndSearch
        '
        Me.TPMessageSendAndSearch.Controls.Add(Me.WebBrowser2)
        Me.TPMessageSendAndSearch.Location = New System.Drawing.Point(4, 29)
        Me.TPMessageSendAndSearch.Name = "TPMessageSendAndSearch"
        Me.TPMessageSendAndSearch.Size = New System.Drawing.Size(651, 478)
        Me.TPMessageSendAndSearch.TabIndex = 2
        Me.TPMessageSendAndSearch.Text = "訊息發送及查詢"
        Me.TPMessageSendAndSearch.UseVisualStyleBackColor = True
        '
        'WebBrowser2
        '
        Me.WebBrowser2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser2.Location = New System.Drawing.Point(0, 0)
        Me.WebBrowser2.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser2.Name = "WebBrowser2"
        Me.WebBrowser2.Size = New System.Drawing.Size(651, 478)
        Me.WebBrowser2.TabIndex = 0
        Me.WebBrowser2.Url = New System.Uri("", System.UriKind.Relative)
        '
        'TPSchedual
        '
        Me.TPSchedual.Location = New System.Drawing.Point(4, 29)
        Me.TPSchedual.Name = "TPSchedual"
        Me.TPSchedual.Padding = New System.Windows.Forms.Padding(3)
        Me.TPSchedual.Size = New System.Drawing.Size(651, 478)
        Me.TPSchedual.TabIndex = 3
        Me.TPSchedual.Text = "排程"
        Me.TPSchedual.UseVisualStyleBackColor = True
        '
        'TPChangeClassMsg
        '
        Me.TPChangeClassMsg.Location = New System.Drawing.Point(4, 29)
        Me.TPChangeClassMsg.Name = "TPChangeClassMsg"
        Me.TPChangeClassMsg.Padding = New System.Windows.Forms.Padding(3)
        Me.TPChangeClassMsg.Size = New System.Drawing.Size(651, 478)
        Me.TPChangeClassMsg.TabIndex = 5
        Me.TPChangeClassMsg.Text = "交接班訊息"
        Me.TPChangeClassMsg.UseVisualStyleBackColor = True
        '
        'TPSysOperator
        '
        Me.TPSysOperator.Controls.Add(Me.TableLayoutPanel3)
        Me.TPSysOperator.Location = New System.Drawing.Point(4, 29)
        Me.TPSysOperator.Name = "TPSysOperator"
        Me.TPSysOperator.Padding = New System.Windows.Forms.Padding(3)
        Me.TPSysOperator.Size = New System.Drawing.Size(651, 478)
        Me.TPSysOperator.TabIndex = 4
        Me.TPSysOperator.Text = "系統設定"
        Me.TPSysOperator.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 4
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Button1, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.GroupBox2, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.GroupBox1, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.btnRefreshWeb, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 5
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(645, 389)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(155, 71)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "重啟被控端訊息接收"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.SetColumnSpan(Me.GroupBox2, 4)
        Me.GroupBox2.Controls.Add(Me.rbSetAuthority2)
        Me.GroupBox2.Controls.Add(Me.rbSetAuthority1)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 157)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox2.Size = New System.Drawing.Size(639, 71)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "網頁授權選擇"
        '
        'rbSetAuthority1
        '
        Me.rbSetAuthority1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbSetAuthority1.AutoSize = True
        Me.rbSetAuthority1.Checked = True
        Me.rbSetAuthority1.Location = New System.Drawing.Point(3, 35)
        Me.rbSetAuthority1.Name = "rbSetAuthority1"
        Me.rbSetAuthority1.Size = New System.Drawing.Size(103, 23)
        Me.rbSetAuthority1.TabIndex = 0
        Me.rbSetAuthority1.TabStop = True
        Me.rbSetAuthority1.Text = "本機授權"
        Me.rbSetAuthority1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.SetColumnSpan(Me.GroupBox1, 4)
        Me.GroupBox1.Controls.Add(Me.MTBIP)
        Me.GroupBox1.Controls.Add(Me.rbSebWebServer3)
        Me.GroupBox1.Controls.Add(Me.rbSebWebServer2)
        Me.GroupBox1.Controls.Add(Me.rbSebWebServer1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 80)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox1.Size = New System.Drawing.Size(639, 71)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "化學成份監看 與 訊息癹送及查詢 伺服器選擇"
        '
        'MTBIP
        '
        Me.MTBIP.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.MTBIP.Location = New System.Drawing.Point(326, 34)
        Me.MTBIP.Name = "MTBIP"
        Me.MTBIP.Size = New System.Drawing.Size(131, 30)
        Me.MTBIP.TabIndex = 3
        '
        'rbSebWebServer3
        '
        Me.rbSebWebServer3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbSebWebServer3.AutoSize = True
        Me.rbSebWebServer3.Location = New System.Drawing.Point(157, 35)
        Me.rbSebWebServer3.Name = "rbSebWebServer3"
        Me.rbSebWebServer3.Size = New System.Drawing.Size(163, 23)
        Me.rbSebWebServer3.TabIndex = 2
        Me.rbSebWebServer3.Text = "自訂伺服器 IP=>"
        Me.rbSebWebServer3.UseVisualStyleBackColor = True
        '
        'rbSebWebServer2
        '
        Me.rbSebWebServer2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbSebWebServer2.AutoSize = True
        Me.rbSebWebServer2.Location = New System.Drawing.Point(80, 35)
        Me.rbSebWebServer2.Name = "rbSebWebServer2"
        Me.rbSebWebServer2.Size = New System.Drawing.Size(103, 23)
        Me.rbSebWebServer2.TabIndex = 1
        Me.rbSebWebServer2.Text = "次伺服器"
        Me.rbSebWebServer2.UseVisualStyleBackColor = True
        '
        'rbSebWebServer1
        '
        Me.rbSebWebServer1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbSebWebServer1.AutoSize = True
        Me.rbSebWebServer1.Checked = True
        Me.rbSebWebServer1.Location = New System.Drawing.Point(3, 35)
        Me.rbSebWebServer1.Name = "rbSebWebServer1"
        Me.rbSebWebServer1.Size = New System.Drawing.Size(103, 23)
        Me.rbSebWebServer1.TabIndex = 0
        Me.rbSebWebServer1.TabStop = True
        Me.rbSebWebServer1.Text = "主伺服器"
        Me.rbSebWebServer1.UseVisualStyleBackColor = True
        '
        'btnRefreshWeb
        '
        Me.btnRefreshWeb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefreshWeb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefreshWeb.Location = New System.Drawing.Point(164, 3)
        Me.btnRefreshWeb.Name = "btnRefreshWeb"
        Me.btnRefreshWeb.Size = New System.Drawing.Size(155, 71)
        Me.btnRefreshWeb.TabIndex = 5
        Me.btnRefreshWeb.Text = "重整網頁"
        Me.btnRefreshWeb.UseVisualStyleBackColor = True
        '
        'tsslMessage
        '
        Me.tsslMessage.ForeColor = System.Drawing.Color.Red
        Me.tsslMessage.Name = "tsslMessage"
        Me.tsslMessage.Size = New System.Drawing.Size(48, 17)
        Me.tsslMessage.Text = "無訊息!"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(35, 17)
        Me.ToolStripStatusLabel1.Text = "訊息:"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tsslMessage})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 511)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(659, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'RefreshBackNodeTimer
        '
        Me.RefreshBackNodeTimer.Interval = 1000
        '
        'tsbMsgToNextClass
        '
        Me.tsbMsgToNextClass.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbMsgToNextClass.Enabled = False
        Me.tsbMsgToNextClass.Image = CType(resources.GetObject("tsbMsgToNextClass.Image"), System.Drawing.Image)
        Me.tsbMsgToNextClass.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbMsgToNextClass.Name = "tsbMsgToNextClass"
        Me.tsbMsgToNextClass.Size = New System.Drawing.Size(147, 28)
        Me.tsbMsgToNextClass.Text = "選取放入交接班"
        '
        'UCSMPIM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "UCSMPIM"
        Me.Size = New System.Drawing.Size(659, 533)
        Me.TabControl1.ResumeLayout(False)
        Me.TPMoniter.ResumeLayout(False)
        Me.TPReceiveMsg.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.TPMessageSendAndSearch.ResumeLayout(False)
        Me.TPSysOperator.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.bsMessageToSiteUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbSetAuthority2 As System.Windows.Forms.RadioButton
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TPMoniter As System.Windows.Forms.TabPage
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents TPReceiveMsg As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents ILMessage As System.Windows.Forms.ImageList
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbMsgText As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbSendTime As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbCheckOne As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsnReReadNOCheckMessage As System.Windows.Forms.ToolStripButton
    Friend WithEvents TPMessageSendAndSearch As System.Windows.Forms.TabPage
    Friend WithEvents WebBrowser2 As System.Windows.Forms.WebBrowser
    Friend WithEvents TPSchedual As System.Windows.Forms.TabPage
    Friend WithEvents TPSysOperator As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbSetAuthority1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbSebWebServer3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbSebWebServer2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbSebWebServer1 As System.Windows.Forms.RadioButton
    Friend WithEvents tsslMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents bsMessageToSiteUser As System.Windows.Forms.BindingSource
    Friend WithEvents btnRefreshWeb As System.Windows.Forms.Button
    Friend WithEvents MTBIP As System.Windows.Forms.TextBox
    Friend WithEvents RefreshBackNodeTimer As System.Windows.Forms.Timer
    Friend WithEvents tsbCheckSelected As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbSenderInfo As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbSeceiverInfo As System.Windows.Forms.Label
    Friend WithEvents TPChangeClassMsg As System.Windows.Forms.TabPage
    Friend WithEvents tsbMsgToNextClass As System.Windows.Forms.ToolStripButton

End Class
