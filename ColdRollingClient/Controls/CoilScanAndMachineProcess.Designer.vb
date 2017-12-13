<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CoilScanAndMachineProcess
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
        Me.components = New System.ComponentModel.Container()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("上線")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("下線")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CoilScanAndMachineProcess))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.PBCoilStart = New System.Windows.Forms.PictureBox()
        Me.tlpCoilRunControls = New System.Windows.Forms.TableLayoutPanel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnCoilMoveOtherLine = New System.Windows.Forms.Button()
        Me.btnClearCoils = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btInputCoilNumber = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btClearCoils = New System.Windows.Forms.Button()
        Me.rbLine2CoilInpupt = New System.Windows.Forms.RadioButton()
        Me.rbLine1CoilInpupt = New System.Windows.Forms.RadioButton()
        Me.btnCoilMoveUp = New System.Windows.Forms.Button()
        Me.btnCoilMoveDown = New System.Windows.Forms.Button()
        Me.btnManualAddCoil = New System.Windows.Forms.Button()
        Me.btnManualInsertCoil = New System.Windows.Forms.Button()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ILTreeNodes = New System.Windows.Forms.ImageList(Me.components)
        Me.tabDetailEdit = New System.Windows.Forms.TabControl()
        Me.tsButtons = New System.Windows.Forms.ToolStrip()
        Me.tsbAddBreadkCoil = New System.Windows.Forms.ToolStripButton()
        Me.tsbDelBreadkCoil = New System.Windows.Forms.ToolStripButton()
        Me.tsbShowOrder = New System.Windows.Forms.ToolStripButton()
        Me.tsbShowHistoryProcess = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbManualBarCodePrint = New System.Windows.Forms.ToolStripButton()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RadioButton24 = New System.Windows.Forms.RadioButton()
        Me.RadioButton23 = New System.Windows.Forms.RadioButton()
        Me.RadioButton22 = New System.Windows.Forms.RadioButton()
        Me.RadioButton21 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RadioButton14 = New System.Windows.Forms.RadioButton()
        Me.RadioButton13 = New System.Windows.Forms.RadioButton()
        Me.RadioButton12 = New System.Windows.Forms.RadioButton()
        Me.RadioButton11 = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpMainOperator = New System.Windows.Forms.TabPage()
        Me.tpSetSysConfig = New System.Windows.Forms.TabPage()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnInputChangePWD = New System.Windows.Forms.Button()
        Me.tbInputPWD = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbMode2 = New System.Windows.Forms.RadioButton()
        Me.rbMode1 = New System.Windows.Forms.RadioButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbRemoteToServerIP = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nudMaxCoilRunningNumber = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.flpDefaultStationSet = New System.Windows.Forms.FlowLayoutPanel()
        Me.cbAutoCoilStart = New System.Windows.Forms.CheckBox()
        Me.cbLine2Switch = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lbDisplayRole = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cbIsStopL2MessageTalk = New System.Windows.Forms.CheckBox()
        Me.cbIsStopPDIMessageTalk = New System.Windows.Forms.CheckBox()
        Me.cbIsStopPDOMessageTalk = New System.Windows.Forms.CheckBox()
        Me.tpZMLWorkConfig = New System.Windows.Forms.TabPage()
        Me.ILTabImages = New System.Windows.Forms.ImageList(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TFlashControlState = New System.Windows.Forms.Timer(Me.components)
        Me.speLine1RS232 = New ExWindowControlLibrary.SerialPortEx()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        CType(Me.PBCoilStart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tsButtons.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpMainOperator.SuspendLayout()
        Me.tpSetSysConfig.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMaxCoilRunningNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 221.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 226.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel5, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.SplitContainer1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tabDetailEdit, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.tsButtons, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ToolStrip1, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel8, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(4, 4)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(892, 760)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel5.ColumnCount = 2
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel5, 2)
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.PBCoilStart, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.tlpCoilRunControls, 1, 0)
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(225, 54)
        Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 122.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(663, 122)
        Me.TableLayoutPanel5.TabIndex = 2
        '
        'PBCoilStart
        '
        Me.PBCoilStart.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PBCoilStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBCoilStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PBCoilStart.Enabled = False
        Me.PBCoilStart.Image = Global.ColdRollingClient.My.Resources.Resources.OutputImage0
        Me.PBCoilStart.Location = New System.Drawing.Point(4, 4)
        Me.PBCoilStart.Margin = New System.Windows.Forms.Padding(4)
        Me.PBCoilStart.Name = "PBCoilStart"
        Me.PBCoilStart.Size = New System.Drawing.Size(45, 114)
        Me.PBCoilStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBCoilStart.TabIndex = 0
        Me.PBCoilStart.TabStop = False
        Me.PBCoilStart.Tag = "Coil Start"
        '
        'tlpCoilRunControls
        '
        Me.tlpCoilRunControls.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpCoilRunControls.BackColor = System.Drawing.SystemColors.Control
        Me.tlpCoilRunControls.ColumnCount = 6
        Me.tlpCoilRunControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpCoilRunControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpCoilRunControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpCoilRunControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpCoilRunControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpCoilRunControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpCoilRunControls.Location = New System.Drawing.Point(57, 4)
        Me.tlpCoilRunControls.Margin = New System.Windows.Forms.Padding(4)
        Me.tlpCoilRunControls.Name = "tlpCoilRunControls"
        Me.tlpCoilRunControls.RowCount = 1
        Me.tlpCoilRunControls.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpCoilRunControls.Size = New System.Drawing.Size(602, 114)
        Me.tlpCoilRunControls.TabIndex = 2
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(4, 54)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel6)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TreeView1)
        Me.TableLayoutPanel1.SetRowSpan(Me.SplitContainer1, 3)
        Me.SplitContainer1.Size = New System.Drawing.Size(213, 702)
        Me.SplitContainer1.SplitterDistance = 301
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 9
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 2
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.btnCoilMoveOtherLine, 0, 3)
        Me.TableLayoutPanel6.Controls.Add(Me.btnClearCoils, 0, 4)
        Me.TableLayoutPanel6.Controls.Add(Me.Label6, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.btInputCoilNumber, 1, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.GroupBox1, 0, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.btnCoilMoveUp, 0, 5)
        Me.TableLayoutPanel6.Controls.Add(Me.btnCoilMoveDown, 1, 5)
        Me.TableLayoutPanel6.Controls.Add(Me.btnManualAddCoil, 1, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.btnManualInsertCoil, 0, 1)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel6.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 6
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(213, 301)
        Me.TableLayoutPanel6.TabIndex = 8
        '
        'btnCoilMoveOtherLine
        '
        Me.btnCoilMoveOtherLine.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel6.SetColumnSpan(Me.btnCoilMoveOtherLine, 2)
        Me.btnCoilMoveOtherLine.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCoilMoveOtherLine.Location = New System.Drawing.Point(0, 181)
        Me.btnCoilMoveOtherLine.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCoilMoveOtherLine.Name = "btnCoilMoveOtherLine"
        Me.btnCoilMoveOtherLine.Size = New System.Drawing.Size(213, 40)
        Me.btnCoilMoveOtherLine.TabIndex = 7
        Me.btnCoilMoveOtherLine.Text = "鋼捲移至別條線"
        Me.btnCoilMoveOtherLine.UseVisualStyleBackColor = True
        '
        'btnClearCoils
        '
        Me.btnClearCoils.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearCoils.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TableLayoutPanel6.SetColumnSpan(Me.btnClearCoils, 2)
        Me.btnClearCoils.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearCoils.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClearCoils.Location = New System.Drawing.Point(0, 221)
        Me.btnClearCoils.Margin = New System.Windows.Forms.Padding(0)
        Me.btnClearCoils.Name = "btnClearCoils"
        Me.btnClearCoils.Size = New System.Drawing.Size(213, 40)
        Me.btnClearCoils.TabIndex = 4
        Me.btnClearCoils.Text = "移除鋼捲"
        Me.btnClearCoils.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(0, 12)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "鋼捲編號:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btInputCoilNumber
        '
        Me.btInputCoilNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btInputCoilNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.btInputCoilNumber.Location = New System.Drawing.Point(110, 6)
        Me.btInputCoilNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.btInputCoilNumber.Name = "btInputCoilNumber"
        Me.btInputCoilNumber.Size = New System.Drawing.Size(99, 27)
        Me.btInputCoilNumber.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel6.SetColumnSpan(Me.GroupBox1, 2)
        Me.GroupBox1.Controls.Add(Me.btClearCoils)
        Me.GroupBox1.Controls.Add(Me.rbLine2CoilInpupt)
        Me.GroupBox1.Controls.Add(Me.rbLine1CoilInpupt)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 91)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(0, 11, 0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox1.Size = New System.Drawing.Size(213, 90)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "加入/清除 上下線區域"
        '
        'btClearCoils
        '
        Me.btClearCoils.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btClearCoils.Location = New System.Drawing.Point(121, 16)
        Me.btClearCoils.Margin = New System.Windows.Forms.Padding(4)
        Me.btClearCoils.Name = "btClearCoils"
        Me.btClearCoils.Size = New System.Drawing.Size(72, 63)
        Me.btClearCoils.TabIndex = 2
        Me.btClearCoils.Text = "清除"
        Me.btClearCoils.UseVisualStyleBackColor = True
        '
        'rbLine2CoilInpupt
        '
        Me.rbLine2CoilInpupt.AutoSize = True
        Me.rbLine2CoilInpupt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbLine2CoilInpupt.Location = New System.Drawing.Point(38, 51)
        Me.rbLine2CoilInpupt.Margin = New System.Windows.Forms.Padding(4)
        Me.rbLine2CoilInpupt.Name = "rbLine2CoilInpupt"
        Me.rbLine2CoilInpupt.Size = New System.Drawing.Size(58, 20)
        Me.rbLine2CoilInpupt.TabIndex = 1
        Me.rbLine2CoilInpupt.Text = "下線"
        Me.rbLine2CoilInpupt.UseVisualStyleBackColor = True
        '
        'rbLine1CoilInpupt
        '
        Me.rbLine1CoilInpupt.AutoSize = True
        Me.rbLine1CoilInpupt.Checked = True
        Me.rbLine1CoilInpupt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbLine1CoilInpupt.Location = New System.Drawing.Point(38, 21)
        Me.rbLine1CoilInpupt.Margin = New System.Windows.Forms.Padding(4)
        Me.rbLine1CoilInpupt.Name = "rbLine1CoilInpupt"
        Me.rbLine1CoilInpupt.Size = New System.Drawing.Size(58, 20)
        Me.rbLine1CoilInpupt.TabIndex = 0
        Me.rbLine1CoilInpupt.TabStop = True
        Me.rbLine1CoilInpupt.Text = "上線"
        Me.rbLine1CoilInpupt.UseVisualStyleBackColor = True
        '
        'btnCoilMoveUp
        '
        Me.btnCoilMoveUp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCoilMoveUp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCoilMoveUp.Location = New System.Drawing.Point(0, 261)
        Me.btnCoilMoveUp.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCoilMoveUp.Name = "btnCoilMoveUp"
        Me.btnCoilMoveUp.Size = New System.Drawing.Size(106, 40)
        Me.btnCoilMoveUp.TabIndex = 5
        Me.btnCoilMoveUp.Text = "鋼捲上移"
        Me.btnCoilMoveUp.UseVisualStyleBackColor = True
        '
        'btnCoilMoveDown
        '
        Me.btnCoilMoveDown.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCoilMoveDown.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCoilMoveDown.Location = New System.Drawing.Point(106, 261)
        Me.btnCoilMoveDown.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCoilMoveDown.Name = "btnCoilMoveDown"
        Me.btnCoilMoveDown.Size = New System.Drawing.Size(107, 40)
        Me.btnCoilMoveDown.TabIndex = 6
        Me.btnCoilMoveDown.Text = "鋼捲下移"
        Me.btnCoilMoveDown.UseVisualStyleBackColor = True
        '
        'btnManualAddCoil
        '
        Me.btnManualAddCoil.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnManualAddCoil.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnManualAddCoil.Location = New System.Drawing.Point(106, 40)
        Me.btnManualAddCoil.Margin = New System.Windows.Forms.Padding(0)
        Me.btnManualAddCoil.Name = "btnManualAddCoil"
        Me.btnManualAddCoil.Size = New System.Drawing.Size(107, 40)
        Me.btnManualAddCoil.TabIndex = 3
        Me.btnManualAddCoil.Text = "手動加入"
        Me.btnManualAddCoil.UseVisualStyleBackColor = True
        '
        'btnManualInsertCoil
        '
        Me.btnManualInsertCoil.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnManualInsertCoil.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnManualInsertCoil.Location = New System.Drawing.Point(0, 40)
        Me.btnManualInsertCoil.Margin = New System.Windows.Forms.Padding(0)
        Me.btnManualInsertCoil.Name = "btnManualInsertCoil"
        Me.btnManualInsertCoil.Size = New System.Drawing.Size(106, 40)
        Me.btnManualInsertCoil.TabIndex = 8
        Me.btnManualInsertCoil.Text = "手動插入"
        Me.btnManualInsertCoil.UseVisualStyleBackColor = True
        '
        'TreeView1
        '
        Me.TreeView1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Font = New System.Drawing.Font("標楷體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.ILTreeNodes
        Me.TreeView1.Indent = 10
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Margin = New System.Windows.Forms.Padding(4)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.Name = "Node1"
        TreeNode1.Text = "上線"
        TreeNode2.Name = "Node2"
        TreeNode2.Text = "下線"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2})
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.ShowLines = False
        Me.TreeView1.ShowPlusMinus = False
        Me.TreeView1.Size = New System.Drawing.Size(213, 396)
        Me.TreeView1.TabIndex = 6
        '
        'ILTreeNodes
        '
        Me.ILTreeNodes.ImageStream = CType(resources.GetObject("ILTreeNodes.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ILTreeNodes.TransparentColor = System.Drawing.Color.Transparent
        Me.ILTreeNodes.Images.SetKeyName(0, "Coil1.jpg")
        Me.ILTreeNodes.Images.SetKeyName(1, "TE201.jpg")
        Me.ILTreeNodes.Images.SetKeyName(2, "202.jpg")
        Me.ILTreeNodes.Images.SetKeyName(3, "TE202.jpg")
        Me.ILTreeNodes.Images.SetKeyName(4, "301.jpg")
        Me.ILTreeNodes.Images.SetKeyName(5, "304.jpg")
        '
        'tabDetailEdit
        '
        Me.tabDetailEdit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.tabDetailEdit, 2)
        Me.tabDetailEdit.Location = New System.Drawing.Point(225, 224)
        Me.tabDetailEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.tabDetailEdit.Name = "tabDetailEdit"
        Me.tabDetailEdit.SelectedIndex = 0
        Me.tabDetailEdit.Size = New System.Drawing.Size(663, 532)
        Me.tabDetailEdit.TabIndex = 10
        '
        'tsButtons
        '
        Me.tsButtons.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tsButtons.Dock = System.Windows.Forms.DockStyle.None
        Me.tsButtons.Enabled = False
        Me.tsButtons.Font = New System.Drawing.Font("標楷體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tsButtons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAddBreadkCoil, Me.tsbDelBreadkCoil, Me.tsbShowOrder, Me.tsbShowHistoryProcess})
        Me.tsButtons.Location = New System.Drawing.Point(221, 180)
        Me.tsButtons.Name = "tsButtons"
        Me.tsButtons.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.tsButtons.Size = New System.Drawing.Size(445, 40)
        Me.tsButtons.TabIndex = 11
        Me.tsButtons.Text = "ToolStrip1"
        '
        'tsbAddBreadkCoil
        '
        Me.tsbAddBreadkCoil.Image = Global.ColdRollingClient.My.Resources.Resources.Coil3
        Me.tsbAddBreadkCoil.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAddBreadkCoil.Name = "tsbAddBreadkCoil"
        Me.tsbAddBreadkCoil.Size = New System.Drawing.Size(140, 37)
        Me.tsbAddBreadkCoil.Text = "分捲產出並列印"
        '
        'tsbDelBreadkCoil
        '
        Me.tsbDelBreadkCoil.Image = Global.ColdRollingClient.My.Resources.Resources.Delete1
        Me.tsbDelBreadkCoil.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDelBreadkCoil.Name = "tsbDelBreadkCoil"
        Me.tsbDelBreadkCoil.Size = New System.Drawing.Size(92, 37)
        Me.tsbDelBreadkCoil.Text = "刪除分捲"
        '
        'tsbShowOrder
        '
        Me.tsbShowOrder.Image = Global.ColdRollingClient.My.Resources.Resources.order
        Me.tsbShowOrder.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbShowOrder.Name = "tsbShowOrder"
        Me.tsbShowOrder.Size = New System.Drawing.Size(92, 37)
        Me.tsbShowOrder.Text = "顯示訂單"
        '
        'tsbShowHistoryProcess
        '
        Me.tsbShowHistoryProcess.Image = Global.ColdRollingClient.My.Resources.Resources.History2
        Me.tsbShowHistoryProcess.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbShowHistoryProcess.Name = "tsbShowHistoryProcess"
        Me.tsbShowHistoryProcess.Size = New System.Drawing.Size(124, 20)
        Me.tsbShowHistoryProcess.Text = "顯示歷史排程"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbManualBarCodePrint})
        Me.ToolStrip1.Location = New System.Drawing.Point(666, 180)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(226, 40)
        Me.ToolStrip1.TabIndex = 13
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbManualBarCodePrint
        '
        Me.tsbManualBarCodePrint.Font = New System.Drawing.Font("標楷體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tsbManualBarCodePrint.Image = Global.ColdRollingClient.My.Resources.Resources.Barcode
        Me.tsbManualBarCodePrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbManualBarCodePrint.Name = "tsbManualBarCodePrint"
        Me.tsbManualBarCodePrint.Size = New System.Drawing.Size(124, 37)
        Me.tsbManualBarCodePrint.Text = "手動條碼列印"
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel8.ColumnCount = 3
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel8, 3)
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.GroupBox3, 2, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.GroupBox2, 1, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.Label9, 0, 0)
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel8.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 1
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(892, 50)
        Me.TableLayoutPanel8.TabIndex = 14
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.RadioButton24)
        Me.GroupBox3.Controls.Add(Me.RadioButton23)
        Me.GroupBox3.Controls.Add(Me.RadioButton22)
        Me.GroupBox3.Controls.Add(Me.RadioButton21)
        Me.GroupBox3.Location = New System.Drawing.Point(515, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(374, 44)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Coil Start 前變更設定"
        '
        'RadioButton24
        '
        Me.RadioButton24.AutoSize = True
        Me.RadioButton24.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RadioButton24.Location = New System.Drawing.Point(317, 18)
        Me.RadioButton24.Name = "RadioButton24"
        Me.RadioButton24.Size = New System.Drawing.Size(98, 20)
        Me.RadioButton24.TabIndex = 5
        Me.RadioButton24.Text = "4.直投NO1"
        Me.RadioButton24.UseVisualStyleBackColor = True
        '
        'RadioButton23
        '
        Me.RadioButton23.AutoSize = True
        Me.RadioButton23.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RadioButton23.Location = New System.Drawing.Point(213, 18)
        Me.RadioButton23.Name = "RadioButton23"
        Me.RadioButton23.Size = New System.Drawing.Size(98, 20)
        Me.RadioButton23.TabIndex = 4
        Me.RadioButton23.Text = "3.直投ZML"
        Me.RadioButton23.UseVisualStyleBackColor = True
        '
        'RadioButton22
        '
        Me.RadioButton22.AutoSize = True
        Me.RadioButton22.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RadioButton22.Location = New System.Drawing.Point(101, 18)
        Me.RadioButton22.Name = "RadioButton22"
        Me.RadioButton22.Size = New System.Drawing.Size(106, 20)
        Me.RadioButton22.TabIndex = 3
        Me.RadioButton22.Text = "2.黑皮直軋"
        Me.RadioButton22.UseVisualStyleBackColor = True
        '
        'RadioButton21
        '
        Me.RadioButton21.AutoSize = True
        Me.RadioButton21.Checked = True
        Me.RadioButton21.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RadioButton21.Location = New System.Drawing.Point(5, 18)
        Me.RadioButton21.Name = "RadioButton21"
        Me.RadioButton21.Size = New System.Drawing.Size(90, 20)
        Me.RadioButton21.TabIndex = 2
        Me.RadioButton21.TabStop = True
        Me.RadioButton21.Text = "1.組合料"
        Me.RadioButton21.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.RadioButton14)
        Me.GroupBox2.Controls.Add(Me.RadioButton13)
        Me.GroupBox2.Controls.Add(Me.RadioButton12)
        Me.GroupBox2.Controls.Add(Me.RadioButton11)
        Me.GroupBox2.Location = New System.Drawing.Point(136, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(373, 44)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "鋼捲 掃描/手動輸入 前設定"
        '
        'RadioButton14
        '
        Me.RadioButton14.AutoSize = True
        Me.RadioButton14.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RadioButton14.Location = New System.Drawing.Point(317, 18)
        Me.RadioButton14.Name = "RadioButton14"
        Me.RadioButton14.Size = New System.Drawing.Size(98, 20)
        Me.RadioButton14.TabIndex = 3
        Me.RadioButton14.Text = "4.直投NO1"
        Me.RadioButton14.UseVisualStyleBackColor = True
        '
        'RadioButton13
        '
        Me.RadioButton13.AutoSize = True
        Me.RadioButton13.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RadioButton13.Location = New System.Drawing.Point(213, 18)
        Me.RadioButton13.Name = "RadioButton13"
        Me.RadioButton13.Size = New System.Drawing.Size(98, 20)
        Me.RadioButton13.TabIndex = 2
        Me.RadioButton13.Text = "3.直投ZML"
        Me.RadioButton13.UseVisualStyleBackColor = True
        '
        'RadioButton12
        '
        Me.RadioButton12.AutoSize = True
        Me.RadioButton12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RadioButton12.Location = New System.Drawing.Point(101, 18)
        Me.RadioButton12.Name = "RadioButton12"
        Me.RadioButton12.Size = New System.Drawing.Size(106, 20)
        Me.RadioButton12.TabIndex = 1
        Me.RadioButton12.Text = "2.黑皮直軋"
        Me.RadioButton12.UseVisualStyleBackColor = True
        '
        'RadioButton11
        '
        Me.RadioButton11.AutoSize = True
        Me.RadioButton11.Checked = True
        Me.RadioButton11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RadioButton11.Location = New System.Drawing.Point(5, 18)
        Me.RadioButton11.Name = "RadioButton11"
        Me.RadioButton11.Size = New System.Drawing.Size(90, 20)
        Me.RadioButton11.TabIndex = 0
        Me.RadioButton11.TabStop = True
        Me.RadioButton11.Text = "1.組合料"
        Me.RadioButton11.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 32)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "生計派工扣帳設定:"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpMainOperator)
        Me.TabControl1.Controls.Add(Me.tpSetSysConfig)
        Me.TabControl1.Controls.Add(Me.tpZMLWorkConfig)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.ImageList = Me.ILTabImages
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(908, 798)
        Me.TabControl1.TabIndex = 1
        '
        'tpMainOperator
        '
        Me.tpMainOperator.Controls.Add(Me.TableLayoutPanel1)
        Me.tpMainOperator.ImageIndex = 0
        Me.tpMainOperator.Location = New System.Drawing.Point(4, 26)
        Me.tpMainOperator.Margin = New System.Windows.Forms.Padding(4)
        Me.tpMainOperator.Name = "tpMainOperator"
        Me.tpMainOperator.Padding = New System.Windows.Forms.Padding(4)
        Me.tpMainOperator.Size = New System.Drawing.Size(900, 768)
        Me.tpMainOperator.TabIndex = 0
        Me.tpMainOperator.Text = "掃描處理"
        Me.tpMainOperator.UseVisualStyleBackColor = True
        '
        'tpSetSysConfig
        '
        Me.tpSetSysConfig.Controls.Add(Me.SplitContainer2)
        Me.tpSetSysConfig.ImageIndex = 1
        Me.tpSetSysConfig.Location = New System.Drawing.Point(4, 26)
        Me.tpSetSysConfig.Margin = New System.Windows.Forms.Padding(4)
        Me.tpSetSysConfig.Name = "tpSetSysConfig"
        Me.tpSetSysConfig.Padding = New System.Windows.Forms.Padding(4)
        Me.tpSetSysConfig.Size = New System.Drawing.Size(900, 768)
        Me.tpSetSysConfig.TabIndex = 1
        Me.tpSetSysConfig.Text = "本機/伺服端硬體設定配置"
        Me.tpSetSysConfig.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.Location = New System.Drawing.Point(6, 7)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.TableLayoutPanel7)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.TableLayoutPanel4)
        Me.SplitContainer2.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.SplitContainer2.Size = New System.Drawing.Size(889, 574)
        Me.SplitContainer2.SplitterDistance = 71
        Me.SplitContainer2.TabIndex = 2
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 3
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel7.Controls.Add(Me.Label7, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.btnInputChangePWD, 2, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.tbInputPWD, 1, 0)
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(11, 17)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(396, 34)
        Me.TableLayoutPanel7.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(49, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 16)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "輸入密碼:"
        '
        'btnInputChangePWD
        '
        Me.btnInputChangePWD.Location = New System.Drawing.Point(267, 3)
        Me.btnInputChangePWD.Name = "btnInputChangePWD"
        Me.btnInputChangePWD.Size = New System.Drawing.Size(126, 27)
        Me.btnInputChangePWD.TabIndex = 0
        Me.btnInputChangePWD.Text = "修改設定"
        Me.btnInputChangePWD.UseVisualStyleBackColor = True
        '
        'tbInputPWD
        '
        Me.tbInputPWD.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbInputPWD.Location = New System.Drawing.Point(135, 3)
        Me.tbInputPWD.Name = "tbInputPWD"
        Me.tbInputPWD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbInputPWD.Size = New System.Drawing.Size(126, 27)
        Me.tbInputPWD.TabIndex = 2
        Me.tbInputPWD.WordWrap = False
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.23077!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.76923!))
        Me.TableLayoutPanel4.Controls.Add(Me.Label4, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Panel1, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label10, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.tbRemoteToServerIP, 1, 1)
        Me.TableLayoutPanel4.Enabled = False
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(11, 19)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(578, 92)
        Me.TableLayoutPanel4.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(62, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "模式切換:"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.rbMode2)
        Me.Panel1.Controls.Add(Me.rbMode1)
        Me.Panel1.Location = New System.Drawing.Point(148, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(427, 40)
        Me.Panel1.TabIndex = 1
        '
        'rbMode2
        '
        Me.rbMode2.AutoSize = True
        Me.rbMode2.Location = New System.Drawing.Point(127, 12)
        Me.rbMode2.Name = "rbMode2"
        Me.rbMode2.Size = New System.Drawing.Size(122, 20)
        Me.rbMode2.TabIndex = 1
        Me.rbMode2.Text = "本機為用戶端"
        Me.rbMode2.UseVisualStyleBackColor = True
        '
        'rbMode1
        '
        Me.rbMode1.AutoSize = True
        Me.rbMode1.Checked = True
        Me.rbMode1.Location = New System.Drawing.Point(12, 12)
        Me.rbMode1.Name = "rbMode1"
        Me.rbMode1.Size = New System.Drawing.Size(122, 20)
        Me.rbMode1.TabIndex = 0
        Me.rbMode1.TabStop = True
        Me.rbMode1.Text = "本機為伺服端"
        Me.rbMode1.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(14, 61)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 16)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "連線至伺服端IP:"
        '
        'tbRemoteToServerIP
        '
        Me.tbRemoteToServerIP.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tbRemoteToServerIP.Location = New System.Drawing.Point(148, 55)
        Me.tbRemoteToServerIP.Name = "tbRemoteToServerIP"
        Me.tbRemoteToServerIP.Size = New System.Drawing.Size(112, 27)
        Me.tbRemoteToServerIP.TabIndex = 3
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.81763!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.18237!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label15, 0, 9)
        Me.TableLayoutPanel2.Controls.Add(Me.Label14, 0, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.Label8, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.nudMaxCoilRunningNumber, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.flpDefaultStationSet, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.cbAutoCoilStart, 1, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.cbLine2Switch, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label11, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label12, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lbDisplayRole, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label13, 0, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.cbIsStopL2MessageTalk, 1, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.cbIsStopPDIMessageTalk, 1, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.cbIsStopPDOMessageTalk, 1, 9)
        Me.TableLayoutPanel2.Enabled = False
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(11, 150)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 10
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(863, 329)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(171, 300)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(168, 16)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "是否停止接收PDO訊號:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(171, 264)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(168, 16)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "是否停止傳送PDI訊號:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(99, 200)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(240, 16)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "當系統CoilEnd時自動CoilStart:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.78114!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.21886!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.NumericUpDown1, 1, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(343, 37)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(520, 22)
        Me.TableLayoutPanel3.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(224, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "使用RS232(不使用COM設為0) COM:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(232, 0)
        Me.NumericUpDown1.Margin = New System.Windows.Forms.Padding(0)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(61, 27)
        Me.NumericUpDown1.TabIndex = 1
        Me.NumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(243, 40)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 16)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "預設掃描槍:"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 96)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(328, 32)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "本產線運行中可容納鋼捲數(APL可設2個以上):"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudMaxCoilRunningNumber
        '
        Me.nudMaxCoilRunningNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.nudMaxCoilRunningNumber.Location = New System.Drawing.Point(347, 100)
        Me.nudMaxCoilRunningNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.nudMaxCoilRunningNumber.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.nudMaxCoilRunningNumber.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudMaxCoilRunningNumber.Name = "nudMaxCoilRunningNumber"
        Me.nudMaxCoilRunningNumber.Size = New System.Drawing.Size(61, 27)
        Me.nudMaxCoilRunningNumber.TabIndex = 17
        Me.nudMaxCoilRunningNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudMaxCoilRunningNumber.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(195, 136)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 16)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "站台屬性預設設定:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'flpDefaultStationSet
        '
        Me.flpDefaultStationSet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpDefaultStationSet.Location = New System.Drawing.Point(347, 132)
        Me.flpDefaultStationSet.Margin = New System.Windows.Forms.Padding(4)
        Me.flpDefaultStationSet.Name = "flpDefaultStationSet"
        Me.TableLayoutPanel2.SetRowSpan(Me.flpDefaultStationSet, 2)
        Me.flpDefaultStationSet.Size = New System.Drawing.Size(512, 56)
        Me.flpDefaultStationSet.TabIndex = 20
        '
        'cbAutoCoilStart
        '
        Me.cbAutoCoilStart.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbAutoCoilStart.AutoSize = True
        Me.cbAutoCoilStart.Location = New System.Drawing.Point(346, 198)
        Me.cbAutoCoilStart.Name = "cbAutoCoilStart"
        Me.cbAutoCoilStart.Size = New System.Drawing.Size(227, 20)
        Me.cbAutoCoilStart.TabIndex = 22
        Me.cbAutoCoilStart.Text = "系統自動產生CoilStart訊號"
        Me.cbAutoCoilStart.UseVisualStyleBackColor = True
        '
        'cbLine2Switch
        '
        Me.cbLine2Switch.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbLine2Switch.AutoSize = True
        Me.cbLine2Switch.Location = New System.Drawing.Point(347, 70)
        Me.cbLine2Switch.Margin = New System.Windows.Forms.Padding(4)
        Me.cbLine2Switch.Name = "cbLine2Switch"
        Me.cbLine2Switch.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbLine2Switch.Size = New System.Drawing.Size(59, 20)
        Me.cbLine2Switch.TabIndex = 1
        Me.cbLine2Switch.Text = "啟用"
        Me.cbLine2Switch.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(124, 72)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(216, 16)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "第二條準備線(APL/BAL適用):"
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(191, 8)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(149, 16)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "以下設定資料來源:"
        '
        'lbDisplayRole
        '
        Me.lbDisplayRole.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbDisplayRole.AutoSize = True
        Me.lbDisplayRole.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbDisplayRole.ForeColor = System.Drawing.Color.Red
        Me.lbDisplayRole.Location = New System.Drawing.Point(346, 8)
        Me.lbDisplayRole.Name = "lbDisplayRole"
        Me.lbDisplayRole.Size = New System.Drawing.Size(42, 16)
        Me.lbDisplayRole.TabIndex = 26
        Me.lbDisplayRole.Text = "本機"
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(147, 232)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(192, 16)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "是否停止傳送接數L2訊號:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbIsStopL2MessageTalk
        '
        Me.cbIsStopL2MessageTalk.AutoSize = True
        Me.cbIsStopL2MessageTalk.Location = New System.Drawing.Point(346, 227)
        Me.cbIsStopL2MessageTalk.Name = "cbIsStopL2MessageTalk"
        Me.cbIsStopL2MessageTalk.Size = New System.Drawing.Size(195, 20)
        Me.cbIsStopL2MessageTalk.TabIndex = 29
        Me.cbIsStopL2MessageTalk.Text = "是,停止L2訊號傳送接收"
        Me.cbIsStopL2MessageTalk.UseVisualStyleBackColor = True
        '
        'cbIsStopPDIMessageTalk
        '
        Me.cbIsStopPDIMessageTalk.AutoSize = True
        Me.cbIsStopPDIMessageTalk.Location = New System.Drawing.Point(346, 259)
        Me.cbIsStopPDIMessageTalk.Name = "cbIsStopPDIMessageTalk"
        Me.cbIsStopPDIMessageTalk.Size = New System.Drawing.Size(171, 20)
        Me.cbIsStopPDIMessageTalk.TabIndex = 30
        Me.cbIsStopPDIMessageTalk.Text = "是,停止PDI訊號傳送"
        Me.cbIsStopPDIMessageTalk.UseVisualStyleBackColor = True
        '
        'cbIsStopPDOMessageTalk
        '
        Me.cbIsStopPDOMessageTalk.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbIsStopPDOMessageTalk.AutoSize = True
        Me.cbIsStopPDOMessageTalk.Location = New System.Drawing.Point(346, 298)
        Me.cbIsStopPDOMessageTalk.Name = "cbIsStopPDOMessageTalk"
        Me.cbIsStopPDOMessageTalk.Size = New System.Drawing.Size(171, 20)
        Me.cbIsStopPDOMessageTalk.TabIndex = 32
        Me.cbIsStopPDOMessageTalk.Text = "是,停止PDO訊號接收"
        Me.cbIsStopPDOMessageTalk.UseVisualStyleBackColor = True
        '
        'tpZMLWorkConfig
        '
        Me.tpZMLWorkConfig.Location = New System.Drawing.Point(4, 26)
        Me.tpZMLWorkConfig.Name = "tpZMLWorkConfig"
        Me.tpZMLWorkConfig.Padding = New System.Windows.Forms.Padding(3)
        Me.tpZMLWorkConfig.Size = New System.Drawing.Size(900, 768)
        Me.tpZMLWorkConfig.TabIndex = 2
        Me.tpZMLWorkConfig.Text = "ZML工作棍設定"
        Me.tpZMLWorkConfig.UseVisualStyleBackColor = True
        '
        'ILTabImages
        '
        Me.ILTabImages.ImageStream = CType(resources.GetObject("ILTabImages.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ILTabImages.TransparentColor = System.Drawing.Color.Transparent
        Me.ILTabImages.Images.SetKeyName(0, "Coil1.jpg")
        Me.ILTabImages.Images.SetKeyName(1, "Config1.jpg")
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tsslMessage})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 798)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(2, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(908, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(34, 17)
        Me.ToolStripStatusLabel1.Text = "訊息:"
        '
        'tsslMessage
        '
        Me.tsslMessage.BackColor = System.Drawing.SystemColors.Control
        Me.tsslMessage.ForeColor = System.Drawing.Color.Red
        Me.tsslMessage.Name = "tsslMessage"
        Me.tsslMessage.Size = New System.Drawing.Size(23, 17)
        Me.tsslMessage.Text = "無!"
        '
        'TFlashControlState
        '
        Me.TFlashControlState.Interval = 3000
        '
        'speLine1RS232
        '
        Me.speLine1RS232.ContainerUserControl = Nothing
        Me.speLine1RS232.ReceiveDataIntervalMilliSeconds = 100
        '
        'CoilScanAndMachineProcess
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("標楷體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "CoilScanAndMachineProcess"
        Me.Size = New System.Drawing.Size(908, 820)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        CType(Me.PBCoilStart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tsButtons.ResumeLayout(False)
        Me.tsButtons.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel8.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tpMainOperator.ResumeLayout(False)
        Me.tpSetSysConfig.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel7.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMaxCoilRunningNumber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpMainOperator As System.Windows.Forms.TabPage
    Friend WithEvents tpSetSysConfig As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cbLine2Switch As System.Windows.Forms.CheckBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents nudMaxCoilRunningNumber As System.Windows.Forms.NumericUpDown
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PBCoilStart As System.Windows.Forms.PictureBox
    Friend WithEvents tlpCoilRunControls As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btInputCoilNumber As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbLine2CoilInpupt As System.Windows.Forms.RadioButton
    Friend WithEvents rbLine1CoilInpupt As System.Windows.Forms.RadioButton
    Friend WithEvents btnManualAddCoil As System.Windows.Forms.Button
    Friend WithEvents btnClearCoils As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnCoilMoveDown As System.Windows.Forms.Button
    Friend WithEvents btnCoilMoveUp As System.Windows.Forms.Button
    Friend WithEvents btClearCoils As System.Windows.Forms.Button
    Friend WithEvents btnCoilMoveOtherLine As System.Windows.Forms.Button
    Friend WithEvents speLine1RS232 As ExWindowControlLibrary.SerialPortEx
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents flpDefaultStationSet As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents tabDetailEdit As System.Windows.Forms.TabControl
    Friend WithEvents tsButtons As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbAddBreadkCoil As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDelBreadkCoil As System.Windows.Forms.ToolStripButton
    Friend WithEvents ILTabImages As System.Windows.Forms.ImageList
    Friend WithEvents tsbShowOrder As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbShowHistoryProcess As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnInputChangePWD As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbInputPWD As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbManualBarCodePrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbAutoCoilStart As System.Windows.Forms.CheckBox
    Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton12 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton11 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton22 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton21 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton24 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton23 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton14 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton13 As System.Windows.Forms.RadioButton
    Friend WithEvents btnManualInsertCoil As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TFlashControlState As System.Windows.Forms.Timer
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rbMode2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbMode1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbRemoteToServerIP As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lbDisplayRole As System.Windows.Forms.Label
    Friend WithEvents tpZMLWorkConfig As System.Windows.Forms.TabPage
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cbIsStopL2MessageTalk As System.Windows.Forms.CheckBox
    Friend WithEvents cbIsStopPDIMessageTalk As System.Windows.Forms.CheckBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbIsStopPDOMessageTalk As System.Windows.Forms.CheckBox
    Friend WithEvents ILTreeNodes As System.Windows.Forms.ImageList

End Class
