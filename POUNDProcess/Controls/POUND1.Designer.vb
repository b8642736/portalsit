<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class POUND1
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("鋼捲號碼1")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(POUND1))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnClearMsgRecord = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbDeviceWeight = New System.Windows.Forms.TextBox()
        Me.bsDataSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbSha01_02 = New System.Windows.Forms.Label()
        Me.lbEditCountMsg = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbStoreArea = New System.Windows.Forms.TextBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnTrnasWeight = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btInputCoilNumber = New System.Windows.Forms.TextBox()
        Me.btnManualAddCoil = New System.Windows.Forms.Button()
        Me.btnCoilMoveUp = New System.Windows.Forms.Button()
        Me.btnCoilMoveDown = New System.Windows.Forms.Button()
        Me.btnSaveWeight = New System.Windows.Forms.Button()
        Me.btnClearCoils = New System.Windows.Forms.Button()
        Me.btnManualInsertCoil = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.tbMsgRecords = New System.Windows.Forms.TextBox()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stlMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SPWeight = New ExWindowControlLibrary.SerialPortEx()
        Me.BarcordScanRS232 = New ExWindowControlLibrary.SerialPortEx()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.bsDataSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 192.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 192.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnClearMsgRecord, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbDeviceWeight, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbSha01_02, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbEditCountMsg, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.tbStoreArea, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ProgressBar1, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnTrnasWeight, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label12, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label13, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.tbMsgRecords, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TreeView1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(662, 441)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'btnClearMsgRecord
        '
        Me.btnClearMsgRecord.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearMsgRecord.Location = New System.Drawing.Point(306, 243)
        Me.btnClearMsgRecord.Name = "btnClearMsgRecord"
        Me.btnClearMsgRecord.Size = New System.Drawing.Size(75, 23)
        Me.btnClearMsgRecord.TabIndex = 37
        Me.btnClearMsgRecord.Text = "清除訊息"
        Me.btnClearMsgRecord.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("標楷體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(396, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 80)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "過磅重量:"
        '
        'tbDeviceWeight
        '
        Me.tbDeviceWeight.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDeviceWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TableLayoutPanel1.SetColumnSpan(Me.tbDeviceWeight, 2)
        Me.tbDeviceWeight.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC06", True))
        Me.tbDeviceWeight.Font = New System.Drawing.Font("標楷體", 60.0!)
        Me.tbDeviceWeight.ForeColor = System.Drawing.Color.Red
        Me.tbDeviceWeight.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.tbDeviceWeight.Location = New System.Drawing.Point(456, 43)
        Me.tbDeviceWeight.Name = "tbDeviceWeight"
        Me.tbDeviceWeight.Size = New System.Drawing.Size(132, 103)
        Me.tbDeviceWeight.TabIndex = 21
        Me.tbDeviceWeight.Text = "0"
        Me.tbDeviceWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bsDataSource
        '
        Me.bsDataSource.DataSource = GetType(CompanyORMDB.PPS100LB.PPSCICPF)
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("標楷體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(534, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 40)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "編號:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("標楷體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(396, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 40)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "鋼捲號碼:"
        '
        'lbSha01_02
        '
        Me.lbSha01_02.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbSha01_02.AutoSize = True
        Me.lbSha01_02.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CoilFullNumber", True))
        Me.lbSha01_02.Font = New System.Drawing.Font("標楷體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbSha01_02.Location = New System.Drawing.Point(456, 0)
        Me.lbSha01_02.Name = "lbSha01_02"
        Me.lbSha01_02.Size = New System.Drawing.Size(63, 40)
        Me.lbSha01_02.TabIndex = 30
        Me.lbSha01_02.Text = "(未知)"
        '
        'lbEditCountMsg
        '
        Me.lbEditCountMsg.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbEditCountMsg.AutoSize = True
        Me.lbEditCountMsg.Font = New System.Drawing.Font("標楷體", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbEditCountMsg.Location = New System.Drawing.Point(3, 5)
        Me.lbEditCountMsg.Name = "lbEditCountMsg"
        Me.lbEditCountMsg.Size = New System.Drawing.Size(186, 29)
        Me.lbEditCountMsg.TabIndex = 32
        Me.lbEditCountMsg.Text = "鋼捲數量:"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC05", True))
        Me.Label10.Font = New System.Drawing.Font("標楷體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(594, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 40)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "(未知)"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("標楷體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(396, 120)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 40)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "儲區:"
        '
        'tbStoreArea
        '
        Me.tbStoreArea.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbStoreArea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbStoreArea.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC95", True))
        Me.tbStoreArea.Location = New System.Drawing.Point(456, 123)
        Me.tbStoreArea.Name = "tbStoreArea"
        Me.tbStoreArea.Size = New System.Drawing.Size(63, 36)
        Me.tbStoreArea.TabIndex = 33
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.ProgressBar1, 2)
        Me.ProgressBar1.Location = New System.Drawing.Point(525, 131)
        Me.ProgressBar1.Maximum = 10000
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ProgressBar1.Size = New System.Drawing.Size(134, 18)
        Me.ProgressBar1.TabIndex = 20
        '
        'btnTrnasWeight
        '
        Me.btnTrnasWeight.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTrnasWeight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTrnasWeight.Location = New System.Drawing.Point(594, 43)
        Me.btnTrnasWeight.Name = "btnTrnasWeight"
        Me.btnTrnasWeight.Size = New System.Drawing.Size(65, 74)
        Me.btnTrnasWeight.TabIndex = 39
        Me.btnTrnasWeight.Text = "儀器重" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "量截取"
        Me.btnTrnasWeight.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btInputCoilNumber, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnManualAddCoil, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.btnCoilMoveUp, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.btnCoilMoveDown, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.btnSaveWeight, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.btnClearCoils, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.btnManualInsertCoil, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.btnLogout, 0, 1)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(195, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 6
        Me.TableLayoutPanel1.SetRowSpan(Me.TableLayoutPanel2, 4)
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(186, 194)
        Me.TableLayoutPanel2.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "鋼捲編號:"
        '
        'btInputCoilNumber
        '
        Me.btInputCoilNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btInputCoilNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.btInputCoilNumber.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.btInputCoilNumber.Location = New System.Drawing.Point(96, 3)
        Me.btInputCoilNumber.MaxLength = 10
        Me.btInputCoilNumber.Name = "btInputCoilNumber"
        Me.btInputCoilNumber.Size = New System.Drawing.Size(87, 36)
        Me.btInputCoilNumber.TabIndex = 0
        '
        'btnManualAddCoil
        '
        Me.btnManualAddCoil.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnManualAddCoil.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnManualAddCoil.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnManualAddCoil.Location = New System.Drawing.Point(93, 36)
        Me.btnManualAddCoil.Margin = New System.Windows.Forms.Padding(0)
        Me.btnManualAddCoil.Name = "btnManualAddCoil"
        Me.btnManualAddCoil.Size = New System.Drawing.Size(93, 36)
        Me.btnManualAddCoil.TabIndex = 2
        Me.btnManualAddCoil.Text = "手動加入"
        Me.btnManualAddCoil.UseVisualStyleBackColor = False
        '
        'btnCoilMoveUp
        '
        Me.btnCoilMoveUp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCoilMoveUp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCoilMoveUp.Location = New System.Drawing.Point(0, 108)
        Me.btnCoilMoveUp.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCoilMoveUp.Name = "btnCoilMoveUp"
        Me.btnCoilMoveUp.Size = New System.Drawing.Size(93, 36)
        Me.btnCoilMoveUp.TabIndex = 30
        Me.btnCoilMoveUp.Text = "鋼捲上移"
        Me.btnCoilMoveUp.UseVisualStyleBackColor = True
        '
        'btnCoilMoveDown
        '
        Me.btnCoilMoveDown.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCoilMoveDown.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCoilMoveDown.Location = New System.Drawing.Point(0, 144)
        Me.btnCoilMoveDown.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCoilMoveDown.Name = "btnCoilMoveDown"
        Me.btnCoilMoveDown.Size = New System.Drawing.Size(93, 36)
        Me.btnCoilMoveDown.TabIndex = 31
        Me.btnCoilMoveDown.Text = "鋼捲下移"
        Me.btnCoilMoveDown.UseVisualStyleBackColor = True
        '
        'btnSaveWeight
        '
        Me.btnSaveWeight.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveWeight.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSaveWeight.Font = New System.Drawing.Font("標楷體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnSaveWeight.Location = New System.Drawing.Point(93, 108)
        Me.btnSaveWeight.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSaveWeight.Name = "btnSaveWeight"
        Me.TableLayoutPanel2.SetRowSpan(Me.btnSaveWeight, 2)
        Me.btnSaveWeight.Size = New System.Drawing.Size(93, 72)
        Me.btnSaveWeight.TabIndex = 3
        Me.btnSaveWeight.Text = "儲存重量並切換下顆鋼捲"
        Me.btnSaveWeight.UseVisualStyleBackColor = False
        '
        'btnClearCoils
        '
        Me.btnClearCoils.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearCoils.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnClearCoils.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearCoils.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClearCoils.Location = New System.Drawing.Point(0, 72)
        Me.btnClearCoils.Margin = New System.Windows.Forms.Padding(0)
        Me.btnClearCoils.Name = "btnClearCoils"
        Me.btnClearCoils.Size = New System.Drawing.Size(93, 36)
        Me.btnClearCoils.TabIndex = 29
        Me.btnClearCoils.Text = "移除鋼捲"
        Me.btnClearCoils.UseVisualStyleBackColor = True
        '
        'btnManualInsertCoil
        '
        Me.btnManualInsertCoil.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnManualInsertCoil.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnManualInsertCoil.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnManualInsertCoil.Location = New System.Drawing.Point(93, 72)
        Me.btnManualInsertCoil.Margin = New System.Windows.Forms.Padding(0)
        Me.btnManualInsertCoil.Name = "btnManualInsertCoil"
        Me.btnManualInsertCoil.Size = New System.Drawing.Size(93, 36)
        Me.btnManualInsertCoil.TabIndex = 28
        Me.btnManualInsertCoil.Text = "手動插入"
        Me.btnManualInsertCoil.UseVisualStyleBackColor = False
        '
        'btnLogout
        '
        Me.btnLogout.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogout.Location = New System.Drawing.Point(0, 36)
        Me.btnLogout.Margin = New System.Windows.Forms.Padding(0)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(93, 36)
        Me.btnLogout.TabIndex = 33
        Me.btnLogout.Text = "系統登出"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("標楷體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(396, 160)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 40)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "登入工號:"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC94", True))
        Me.Label12.Font = New System.Drawing.Font("標楷體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(456, 160)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 40)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "(未知)"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("標楷體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.Location = New System.Drawing.Point(243, 200)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(138, 27)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "訊息記錄:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(195, 283)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(186, 155)
        Me.FlowLayoutPanel1.TabIndex = 37
        '
        'tbMsgRecords
        '
        Me.tbMsgRecords.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbMsgRecords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.tbMsgRecords, 4)
        Me.tbMsgRecords.Font = New System.Drawing.Font("標楷體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tbMsgRecords.ForeColor = System.Drawing.Color.Red
        Me.tbMsgRecords.Location = New System.Drawing.Point(387, 203)
        Me.tbMsgRecords.Multiline = True
        Me.tbMsgRecords.Name = "tbMsgRecords"
        Me.tbMsgRecords.ReadOnly = True
        Me.TableLayoutPanel1.SetRowSpan(Me.tbMsgRecords, 3)
        Me.tbMsgRecords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbMsgRecords.Size = New System.Drawing.Size(272, 235)
        Me.tbMsgRecords.TabIndex = 38
        '
        'TreeView1
        '
        Me.TreeView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.ImageList1
        Me.TreeView1.Indent = 10
        Me.TreeView1.Location = New System.Drawing.Point(4, 44)
        Me.TreeView1.Margin = New System.Windows.Forms.Padding(4)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.Name = "Node1"
        TreeNode1.Text = "鋼捲號碼1"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.TableLayoutPanel1.SetRowSpan(Me.TreeView1, 6)
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.ShowLines = False
        Me.TreeView1.ShowPlusMinus = False
        Me.TreeView1.Size = New System.Drawing.Size(184, 393)
        Me.TreeView1.TabIndex = 26
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Line1.jpg")
        Me.ImageList1.Images.SetKeyName(1, "Coil1.jpg")
        Me.ImageList1.Images.SetKeyName(2, "Arrow.jpg")
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.stlMessage})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 441)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(662, 29)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(52, 24)
        Me.ToolStripStatusLabel1.Text = "訊息:"
        '
        'stlMessage
        '
        Me.stlMessage.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.stlMessage.ForeColor = System.Drawing.Color.Red
        Me.stlMessage.Name = "stlMessage"
        Me.stlMessage.Size = New System.Drawing.Size(0, 24)
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'SPWeight
        '
        Me.SPWeight.BaudRate = 2400
        Me.SPWeight.ContainerUserControl = Nothing
        Me.SPWeight.DataBits = 7
        Me.SPWeight.Parity = System.IO.Ports.Parity.Even
        Me.SPWeight.PortName = "COM2"
        Me.SPWeight.ReceiveDataIntervalMilliSeconds = 10
        '
        'BarcordScanRS232
        '
        Me.BarcordScanRS232.ContainerUserControl = Nothing
        Me.BarcordScanRS232.ReceiveDataIntervalMilliSeconds = 100
        '
        'POUND1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "POUND1"
        Me.Size = New System.Drawing.Size(662, 470)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.bsDataSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btInputCoilNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnManualAddCoil As System.Windows.Forms.Button
    Friend WithEvents btnSaveWeight As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents tbDeviceWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnManualInsertCoil As System.Windows.Forms.Button
    Friend WithEvents btnClearCoils As System.Windows.Forms.Button
    Friend WithEvents btnCoilMoveUp As System.Windows.Forms.Button
    Friend WithEvents btnCoilMoveDown As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents stlMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SPWeight As ExWindowControlLibrary.SerialPortEx
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbSha01_02 As System.Windows.Forms.Label
    Friend WithEvents bsDataSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents BarcordScanRS232 As ExWindowControlLibrary.SerialPortEx
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbStoreArea As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lbEditCountMsg As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnClearMsgRecord As System.Windows.Forms.Button
    Friend WithEvents tbMsgRecords As System.Windows.Forms.TextBox
    Friend WithEvents btnLogout As System.Windows.Forms.Button
    Friend WithEvents btnTrnasWeight As System.Windows.Forms.Button

End Class
