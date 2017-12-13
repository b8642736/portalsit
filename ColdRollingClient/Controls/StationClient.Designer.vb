<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StationClient
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StationClient))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpCoilScanAndMachineProcess = New System.Windows.Forms.TabPage()
        Me.tpCoilAfterRunningProcessControl = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.EditButton = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.SHA01DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA02DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA04DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA39DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA06DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA08DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA11DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA12DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA13DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA14DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA15DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA16DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA17DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA18DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA19DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA21DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA22DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA23DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA24DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA25DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA26DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA27DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA28DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsdNewAddCoilDatas = New System.Windows.Forms.BindingSource(Me.components)
        Me.bsCurrentCoilDatas = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btnAddCoil = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.lbProcessSchedual = New System.Windows.Forms.Label()
        Me.flpProcessSchedualSelect = New System.Windows.Forms.FlowLayoutPanel()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.tbShowDetail1 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.FK_OutSHA01 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FK_OutSHA02 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BreakCoilNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GuageDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WidthDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LengthDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WeightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReturnWeightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CoilStartTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CoilEndTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ScaleWeightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OtherWeightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Memo1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WriteEmployeeNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FKRunStationNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RunStationPCIPDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FKLastRefSHA01DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FKLastRefSHA02DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FKLastRefSHA04DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FKRunProcessSchedualIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsCurrentRunProcessData = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCreateTheStationDatas1 = New System.Windows.Forms.Button()
        Me.btnPrintLabel = New System.Windows.Forms.Button()
        Me.tbShowDetail2 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.btnCreateTheStationDatas = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.SHA01DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA02DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA04DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA39DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA06DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA08DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA11DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA12DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA13DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA14DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA15DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA16DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA17DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA18DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA19DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA21DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA22DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA23DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA24DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA25DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA26DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA27DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA28DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA29DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ILAfterProcessTabPageImages = New System.Windows.Forms.ImageList(Me.components)
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnEndAndSave = New System.Windows.Forms.Button()
        Me.btnDeleteLastSaveDatas = New System.Windows.Forms.Button()
        Me.tpCoilMoveStationEdit = New System.Windows.Forms.TabPage()
        Me.tpCoilBeforeRunningProcess = New System.Windows.Forms.TabPage()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SerialPortEx1 = New ExWindowControlLibrary.SerialPortEx()
        Me.tpSelfQC = New System.Windows.Forms.TabPage()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsdNewAddCoilDatas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsCurrentCoilDatas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.tbShowDetail1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsCurrentRunProcessData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbShowDetail2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpCoilScanAndMachineProcess)
        Me.TabControl1.Controls.Add(Me.tpCoilAfterRunningProcessControl)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.tpCoilMoveStationEdit)
        Me.TabControl1.Controls.Add(Me.tpCoilBeforeRunningProcess)
        Me.TabControl1.Controls.Add(Me.tpSelfQC)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("標楷體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(760, 578)
        Me.TabControl1.TabIndex = 2
        '
        'tpCoilScanAndMachineProcess
        '
        Me.tpCoilScanAndMachineProcess.Location = New System.Drawing.Point(4, 26)
        Me.tpCoilScanAndMachineProcess.Name = "tpCoilScanAndMachineProcess"
        Me.tpCoilScanAndMachineProcess.Size = New System.Drawing.Size(752, 548)
        Me.tpCoilScanAndMachineProcess.TabIndex = 3
        Me.tpCoilScanAndMachineProcess.Text = "鋼捲掃描作業"
        Me.tpCoilScanAndMachineProcess.UseVisualStyleBackColor = True
        '
        'tpCoilAfterRunningProcessControl
        '
        Me.tpCoilAfterRunningProcessControl.Location = New System.Drawing.Point(4, 26)
        Me.tpCoilAfterRunningProcessControl.Name = "tpCoilAfterRunningProcessControl"
        Me.tpCoilAfterRunningProcessControl.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCoilAfterRunningProcessControl.Size = New System.Drawing.Size(752, 548)
        Me.tpCoilAfterRunningProcessControl.TabIndex = 6
        Me.tpCoilAfterRunningProcessControl.Text = "新版本站完成鋼捲編修作業"
        Me.tpCoilAfterRunningProcessControl.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 26)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(752, 548)
        Me.TabPage2.TabIndex = 0
        Me.TabPage2.Text = "本站完成鋼捲編修作業"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.18699!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.81301!))
        Me.TableLayoutPanel1.Controls.Add(Me.TreeView1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox2, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbProcessSchedual, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.flpProcessSchedualSelect, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TabControl2, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.29932!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.70068!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(746, 542)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TreeView1
        '
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.ImageList1
        Me.TreeView1.Location = New System.Drawing.Point(3, 73)
        Me.TreeView1.Name = "TreeView1"
        Me.TableLayoutPanel1.SetRowSpan(Me.TreeView1, 3)
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.Size = New System.Drawing.Size(137, 466)
        Me.TreeView1.TabIndex = 5
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Line1.jpg")
        Me.ImageList1.Images.SetKeyName(1, "Coil1.jpg")
        Me.ImageList1.Images.SetKeyName(2, "Coil2.jpg")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DataGridView2)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(146, 108)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(597, 205)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "新增資料編輯區"
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AllowUserToOrderColumns = True
        Me.DataGridView2.AutoGenerateColumns = False
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EditButton, Me.SHA01DataGridViewTextBoxColumn, Me.SHA02DataGridViewTextBoxColumn, Me.SHA04DataGridViewTextBoxColumn, Me.SHA39DataGridViewTextBoxColumn, Me.SHA06DataGridViewTextBoxColumn, Me.SHA08DataGridViewTextBoxColumn, Me.SHA11DataGridViewTextBoxColumn, Me.SHA12DataGridViewTextBoxColumn, Me.SHA13DataGridViewTextBoxColumn, Me.SHA14DataGridViewTextBoxColumn, Me.SHA15DataGridViewTextBoxColumn, Me.SHA16DataGridViewTextBoxColumn, Me.SHA17DataGridViewTextBoxColumn, Me.SHA18DataGridViewTextBoxColumn, Me.SHA19DataGridViewTextBoxColumn, Me.SHA20, Me.SHA21DataGridViewTextBoxColumn, Me.SHA22DataGridViewTextBoxColumn, Me.SHA23DataGridViewTextBoxColumn, Me.SHA24DataGridViewTextBoxColumn, Me.SHA25DataGridViewTextBoxColumn, Me.SHA26DataGridViewTextBoxColumn, Me.SHA27DataGridViewTextBoxColumn, Me.SHA28DataGridViewTextBoxColumn, Me.SHA29})
        Me.DataGridView2.DataSource = Me.bsdNewAddCoilDatas
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.Location = New System.Drawing.Point(3, 23)
        Me.DataGridView2.MultiSelect = False
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersWidth = 20
        Me.DataGridView2.RowTemplate.Height = 24
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(591, 179)
        Me.DataGridView2.TabIndex = 10
        '
        'EditButton
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red
        Me.EditButton.DefaultCellStyle = DataGridViewCellStyle1
        Me.EditButton.Frozen = True
        Me.EditButton.HeaderText = "編輯"
        Me.EditButton.Name = "EditButton"
        Me.EditButton.ReadOnly = True
        Me.EditButton.Text = "編輯"
        Me.EditButton.ToolTipText = "編輯"
        Me.EditButton.UseColumnTextForButtonValue = True
        Me.EditButton.Width = 41
        '
        'SHA01DataGridViewTextBoxColumn
        '
        Me.SHA01DataGridViewTextBoxColumn.DataPropertyName = "SHA01"
        Me.SHA01DataGridViewTextBoxColumn.HeaderText = "鋼捲號碼"
        Me.SHA01DataGridViewTextBoxColumn.Name = "SHA01DataGridViewTextBoxColumn"
        Me.SHA01DataGridViewTextBoxColumn.ReadOnly = True
        Me.SHA01DataGridViewTextBoxColumn.Width = 75
        '
        'SHA02DataGridViewTextBoxColumn
        '
        Me.SHA02DataGridViewTextBoxColumn.DataPropertyName = "SHA02"
        Me.SHA02DataGridViewTextBoxColumn.HeaderText = "分捲號碼"
        Me.SHA02DataGridViewTextBoxColumn.Name = "SHA02DataGridViewTextBoxColumn"
        Me.SHA02DataGridViewTextBoxColumn.ReadOnly = True
        Me.SHA02DataGridViewTextBoxColumn.Width = 75
        '
        'SHA04DataGridViewTextBoxColumn
        '
        Me.SHA04DataGridViewTextBoxColumn.DataPropertyName = "SHA04"
        Me.SHA04DataGridViewTextBoxColumn.HeaderText = "序順"
        Me.SHA04DataGridViewTextBoxColumn.Name = "SHA04DataGridViewTextBoxColumn"
        Me.SHA04DataGridViewTextBoxColumn.ReadOnly = True
        Me.SHA04DataGridViewTextBoxColumn.Width = 60
        '
        'SHA39DataGridViewTextBoxColumn
        '
        Me.SHA39DataGridViewTextBoxColumn.DataPropertyName = "SHA39"
        Me.SHA39DataGridViewTextBoxColumn.HeaderText = "最終產品表面"
        Me.SHA39DataGridViewTextBoxColumn.Name = "SHA39DataGridViewTextBoxColumn"
        Me.SHA39DataGridViewTextBoxColumn.ReadOnly = True
        Me.SHA39DataGridViewTextBoxColumn.Width = 89
        '
        'SHA06DataGridViewTextBoxColumn
        '
        Me.SHA06DataGridViewTextBoxColumn.DataPropertyName = "SHA06"
        Me.SHA06DataGridViewTextBoxColumn.HeaderText = "製程表面"
        Me.SHA06DataGridViewTextBoxColumn.Name = "SHA06DataGridViewTextBoxColumn"
        Me.SHA06DataGridViewTextBoxColumn.ReadOnly = True
        Me.SHA06DataGridViewTextBoxColumn.Width = 75
        '
        'SHA08DataGridViewTextBoxColumn
        '
        Me.SHA08DataGridViewTextBoxColumn.DataPropertyName = "SHA08"
        Me.SHA08DataGridViewTextBoxColumn.HeaderText = "產線"
        Me.SHA08DataGridViewTextBoxColumn.Name = "SHA08DataGridViewTextBoxColumn"
        Me.SHA08DataGridViewTextBoxColumn.ReadOnly = True
        Me.SHA08DataGridViewTextBoxColumn.Width = 60
        '
        'SHA11DataGridViewTextBoxColumn
        '
        Me.SHA11DataGridViewTextBoxColumn.DataPropertyName = "SHA11"
        Me.SHA11DataGridViewTextBoxColumn.HeaderText = "排程日期"
        Me.SHA11DataGridViewTextBoxColumn.Name = "SHA11DataGridViewTextBoxColumn"
        Me.SHA11DataGridViewTextBoxColumn.ReadOnly = True
        Me.SHA11DataGridViewTextBoxColumn.Width = 75
        '
        'SHA12DataGridViewTextBoxColumn
        '
        Me.SHA12DataGridViewTextBoxColumn.DataPropertyName = "SHA12"
        Me.SHA12DataGridViewTextBoxColumn.HeaderText = "鋼種"
        Me.SHA12DataGridViewTextBoxColumn.Name = "SHA12DataGridViewTextBoxColumn"
        Me.SHA12DataGridViewTextBoxColumn.ReadOnly = True
        Me.SHA12DataGridViewTextBoxColumn.Width = 60
        '
        'SHA13DataGridViewTextBoxColumn
        '
        Me.SHA13DataGridViewTextBoxColumn.DataPropertyName = "SHA13"
        Me.SHA13DataGridViewTextBoxColumn.HeaderText = "型別"
        Me.SHA13DataGridViewTextBoxColumn.Name = "SHA13DataGridViewTextBoxColumn"
        Me.SHA13DataGridViewTextBoxColumn.ReadOnly = True
        Me.SHA13DataGridViewTextBoxColumn.Width = 60
        '
        'SHA14DataGridViewTextBoxColumn
        '
        Me.SHA14DataGridViewTextBoxColumn.DataPropertyName = "SHA14"
        Me.SHA14DataGridViewTextBoxColumn.HeaderText = "厚度"
        Me.SHA14DataGridViewTextBoxColumn.Name = "SHA14DataGridViewTextBoxColumn"
        Me.SHA14DataGridViewTextBoxColumn.ReadOnly = True
        Me.SHA14DataGridViewTextBoxColumn.Width = 60
        '
        'SHA15DataGridViewTextBoxColumn
        '
        Me.SHA15DataGridViewTextBoxColumn.DataPropertyName = "SHA15"
        Me.SHA15DataGridViewTextBoxColumn.HeaderText = "寬度"
        Me.SHA15DataGridViewTextBoxColumn.Name = "SHA15DataGridViewTextBoxColumn"
        Me.SHA15DataGridViewTextBoxColumn.ReadOnly = True
        Me.SHA15DataGridViewTextBoxColumn.Width = 60
        '
        'SHA16DataGridViewTextBoxColumn
        '
        Me.SHA16DataGridViewTextBoxColumn.DataPropertyName = "SHA16"
        Me.SHA16DataGridViewTextBoxColumn.HeaderText = "長度"
        Me.SHA16DataGridViewTextBoxColumn.Name = "SHA16DataGridViewTextBoxColumn"
        Me.SHA16DataGridViewTextBoxColumn.ReadOnly = True
        Me.SHA16DataGridViewTextBoxColumn.Width = 60
        '
        'SHA17DataGridViewTextBoxColumn
        '
        Me.SHA17DataGridViewTextBoxColumn.DataPropertyName = "SHA17"
        Me.SHA17DataGridViewTextBoxColumn.HeaderText = "重量"
        Me.SHA17DataGridViewTextBoxColumn.Name = "SHA17DataGridViewTextBoxColumn"
        Me.SHA17DataGridViewTextBoxColumn.ReadOnly = True
        Me.SHA17DataGridViewTextBoxColumn.Width = 60
        '
        'SHA18DataGridViewTextBoxColumn
        '
        Me.SHA18DataGridViewTextBoxColumn.DataPropertyName = "SHA18"
        Me.SHA18DataGridViewTextBoxColumn.HeaderText = "退料重"
        Me.SHA18DataGridViewTextBoxColumn.Name = "SHA18DataGridViewTextBoxColumn"
        Me.SHA18DataGridViewTextBoxColumn.ReadOnly = True
        Me.SHA18DataGridViewTextBoxColumn.Width = 75
        '
        'SHA19DataGridViewTextBoxColumn
        '
        Me.SHA19DataGridViewTextBoxColumn.DataPropertyName = "SHA19"
        Me.SHA19DataGridViewTextBoxColumn.HeaderText = "損耗重"
        Me.SHA19DataGridViewTextBoxColumn.Name = "SHA19DataGridViewTextBoxColumn"
        Me.SHA19DataGridViewTextBoxColumn.ReadOnly = True
        Me.SHA19DataGridViewTextBoxColumn.Width = 75
        '
        'SHA20
        '
        Me.SHA20.DataPropertyName = "SHA20"
        Me.SHA20.HeaderText = "頭尾料重"
        Me.SHA20.Name = "SHA20"
        Me.SHA20.ReadOnly = True
        Me.SHA20.Width = 75
        '
        'SHA21DataGridViewTextBoxColumn
        '
        Me.SHA21DataGridViewTextBoxColumn.DataPropertyName = "SHA21"
        Me.SHA21DataGridViewTextBoxColumn.HeaderText = "完成日期"
        Me.SHA21DataGridViewTextBoxColumn.Name = "SHA21DataGridViewTextBoxColumn"
        Me.SHA21DataGridViewTextBoxColumn.ReadOnly = True
        Me.SHA21DataGridViewTextBoxColumn.Width = 75
        '
        'SHA22DataGridViewTextBoxColumn
        '
        Me.SHA22DataGridViewTextBoxColumn.DataPropertyName = "SHA22"
        Me.SHA22DataGridViewTextBoxColumn.HeaderText = "開始日期"
        Me.SHA22DataGridViewTextBoxColumn.Name = "SHA22DataGridViewTextBoxColumn"
        Me.SHA22DataGridViewTextBoxColumn.ReadOnly = True
        Me.SHA22DataGridViewTextBoxColumn.Width = 75
        '
        'SHA23DataGridViewTextBoxColumn
        '
        Me.SHA23DataGridViewTextBoxColumn.DataPropertyName = "SHA23"
        Me.SHA23DataGridViewTextBoxColumn.HeaderText = "開始分"
        Me.SHA23DataGridViewTextBoxColumn.Name = "SHA23DataGridViewTextBoxColumn"
        Me.SHA23DataGridViewTextBoxColumn.ReadOnly = True
        Me.SHA23DataGridViewTextBoxColumn.Width = 75
        '
        'SHA24DataGridViewTextBoxColumn
        '
        Me.SHA24DataGridViewTextBoxColumn.DataPropertyName = "SHA24"
        Me.SHA24DataGridViewTextBoxColumn.HeaderText = "結束時"
        Me.SHA24DataGridViewTextBoxColumn.Name = "SHA24DataGridViewTextBoxColumn"
        Me.SHA24DataGridViewTextBoxColumn.ReadOnly = True
        Me.SHA24DataGridViewTextBoxColumn.Width = 75
        '
        'SHA25DataGridViewTextBoxColumn
        '
        Me.SHA25DataGridViewTextBoxColumn.DataPropertyName = "SHA25"
        Me.SHA25DataGridViewTextBoxColumn.HeaderText = "結束分"
        Me.SHA25DataGridViewTextBoxColumn.Name = "SHA25DataGridViewTextBoxColumn"
        Me.SHA25DataGridViewTextBoxColumn.ReadOnly = True
        Me.SHA25DataGridViewTextBoxColumn.Width = 75
        '
        'SHA26DataGridViewTextBoxColumn
        '
        Me.SHA26DataGridViewTextBoxColumn.DataPropertyName = "SHA26"
        Me.SHA26DataGridViewTextBoxColumn.HeaderText = "GP研磨次數"
        Me.SHA26DataGridViewTextBoxColumn.Name = "SHA26DataGridViewTextBoxColumn"
        Me.SHA26DataGridViewTextBoxColumn.ReadOnly = True
        Me.SHA26DataGridViewTextBoxColumn.Width = 89
        '
        'SHA27DataGridViewTextBoxColumn
        '
        Me.SHA27DataGridViewTextBoxColumn.DataPropertyName = "SHA27"
        Me.SHA27DataGridViewTextBoxColumn.HeaderText = "下一產線"
        Me.SHA27DataGridViewTextBoxColumn.Name = "SHA27DataGridViewTextBoxColumn"
        Me.SHA27DataGridViewTextBoxColumn.ReadOnly = True
        Me.SHA27DataGridViewTextBoxColumn.Width = 75
        '
        'SHA28DataGridViewTextBoxColumn
        '
        Me.SHA28DataGridViewTextBoxColumn.DataPropertyName = "SHA28"
        Me.SHA28DataGridViewTextBoxColumn.HeaderText = "產線是否完成"
        Me.SHA28DataGridViewTextBoxColumn.Name = "SHA28DataGridViewTextBoxColumn"
        Me.SHA28DataGridViewTextBoxColumn.ReadOnly = True
        Me.SHA28DataGridViewTextBoxColumn.Width = 89
        '
        'SHA29
        '
        Me.SHA29.DataPropertyName = "SHA29"
        Me.SHA29.HeaderText = "是否為完成產品"
        Me.SHA29.Name = "SHA29"
        Me.SHA29.ReadOnly = True
        Me.SHA29.Width = 104
        '
        'bsdNewAddCoilDatas
        '
        Me.bsdNewAddCoilDatas.DataSource = Me.bsCurrentCoilDatas
        '
        'bsCurrentCoilDatas
        '
        Me.bsCurrentCoilDatas.DataMember = "CurrentRunningCoilDetailDatas"
        Me.bsCurrentCoilDatas.DataSource = GetType(ColdRollingClient.StationClient)
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 32)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "臨時鋼捲手動加入:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.Label3)
        Me.FlowLayoutPanel2.Controls.Add(Me.TextBox1)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnAddCoil)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnRemove)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(146, 3)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(597, 29)
        Me.FlowLayoutPanel2.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "鋼捲號碼"
        '
        'TextBox1
        '
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Location = New System.Drawing.Point(81, 3)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 27)
        Me.TextBox1.TabIndex = 7
        '
        'btnAddCoil
        '
        Me.btnAddCoil.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddCoil.Location = New System.Drawing.Point(187, 3)
        Me.btnAddCoil.Name = "btnAddCoil"
        Me.btnAddCoil.Size = New System.Drawing.Size(95, 23)
        Me.btnAddCoil.TabIndex = 6
        Me.btnAddCoil.Text = "手動加入"
        Me.btnAddCoil.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRemove.Location = New System.Drawing.Point(288, 3)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(95, 23)
        Me.btnRemove.TabIndex = 9
        Me.btnRemove.Text = "移除已加入"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'lbProcessSchedual
        '
        Me.lbProcessSchedual.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbProcessSchedual.AutoSize = True
        Me.lbProcessSchedual.Location = New System.Drawing.Point(28, 44)
        Me.lbProcessSchedual.Name = "lbProcessSchedual"
        Me.lbProcessSchedual.Size = New System.Drawing.Size(112, 16)
        Me.lbProcessSchedual.TabIndex = 12
        Me.lbProcessSchedual.Text = "處理角色選定:"
        '
        'flpProcessSchedualSelect
        '
        Me.flpProcessSchedualSelect.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpProcessSchedualSelect.AutoScroll = True
        Me.flpProcessSchedualSelect.Location = New System.Drawing.Point(146, 38)
        Me.flpProcessSchedualSelect.Name = "flpProcessSchedualSelect"
        Me.flpProcessSchedualSelect.Size = New System.Drawing.Size(597, 29)
        Me.flpProcessSchedualSelect.TabIndex = 13
        Me.flpProcessSchedualSelect.WrapContents = False
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.tbShowDetail1)
        Me.TabControl2.Controls.Add(Me.tbShowDetail2)
        Me.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl2.ImageList = Me.ILAfterProcessTabPageImages
        Me.TabControl2.Location = New System.Drawing.Point(146, 319)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(597, 220)
        Me.TabControl2.TabIndex = 14
        '
        'tbShowDetail1
        '
        Me.tbShowDetail1.Controls.Add(Me.TableLayoutPanel3)
        Me.tbShowDetail1.ImageIndex = 0
        Me.tbShowDetail1.Location = New System.Drawing.Point(4, 26)
        Me.tbShowDetail1.Name = "tbShowDetail1"
        Me.tbShowDetail1.Size = New System.Drawing.Size(589, 190)
        Me.tbShowDetail1.TabIndex = 1
        Me.tbShowDetail1.Text = "本站作業完成待轉換資料"
        Me.tbShowDetail1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 4
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 187.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.DataGridView3, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label5, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnCreateTheStationDatas1, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnPrintLabel, 2, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(589, 190)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'DataGridView3
        '
        Me.DataGridView3.AllowUserToAddRows = False
        Me.DataGridView3.AllowUserToDeleteRows = False
        Me.DataGridView3.AllowUserToOrderColumns = True
        Me.DataGridView3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView3.AutoGenerateColumns = False
        Me.DataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FK_OutSHA01, Me.FK_OutSHA02, Me.BreakCoilNumberDataGridViewTextBoxColumn, Me.GuageDataGridViewTextBoxColumn, Me.WidthDataGridViewTextBoxColumn, Me.LengthDataGridViewTextBoxColumn, Me.WeightDataGridViewTextBoxColumn, Me.ReturnWeightDataGridViewTextBoxColumn, Me.CoilStartTimeDataGridViewTextBoxColumn, Me.CoilEndTimeDataGridViewTextBoxColumn, Me.ScaleWeightDataGridViewTextBoxColumn, Me.OtherWeightDataGridViewTextBoxColumn, Me.Memo1DataGridViewTextBoxColumn, Me.WriteEmployeeNumberDataGridViewTextBoxColumn, Me.FKRunStationNameDataGridViewTextBoxColumn, Me.RunStationPCIPDataGridViewTextBoxColumn, Me.FKLastRefSHA01DataGridViewTextBoxColumn, Me.FKLastRefSHA02DataGridViewTextBoxColumn, Me.FKLastRefSHA04DataGridViewTextBoxColumn, Me.FKRunProcessSchedualIDDataGridViewTextBoxColumn, Me.IDDataGridViewTextBoxColumn})
        Me.TableLayoutPanel3.SetColumnSpan(Me.DataGridView3, 4)
        Me.DataGridView3.DataSource = Me.bsCurrentRunProcessData
        Me.DataGridView3.Location = New System.Drawing.Point(3, 33)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.RowTemplate.Height = 24
        Me.DataGridView3.Size = New System.Drawing.Size(583, 154)
        Me.DataGridView3.TabIndex = 0
        '
        'FK_OutSHA01
        '
        Me.FK_OutSHA01.DataPropertyName = "FK_OutSHA01"
        Me.FK_OutSHA01.HeaderText = "鋼捲編號"
        Me.FK_OutSHA01.Name = "FK_OutSHA01"
        Me.FK_OutSHA01.Width = 75
        '
        'FK_OutSHA02
        '
        Me.FK_OutSHA02.DataPropertyName = "FK_OutSHA02"
        Me.FK_OutSHA02.HeaderText = "分捲編號"
        Me.FK_OutSHA02.Name = "FK_OutSHA02"
        Me.FK_OutSHA02.Width = 75
        '
        'BreakCoilNumberDataGridViewTextBoxColumn
        '
        Me.BreakCoilNumberDataGridViewTextBoxColumn.DataPropertyName = "BreakCoilNumber"
        Me.BreakCoilNumberDataGridViewTextBoxColumn.HeaderText = "分捲順序"
        Me.BreakCoilNumberDataGridViewTextBoxColumn.Name = "BreakCoilNumberDataGridViewTextBoxColumn"
        Me.BreakCoilNumberDataGridViewTextBoxColumn.Width = 75
        '
        'GuageDataGridViewTextBoxColumn
        '
        Me.GuageDataGridViewTextBoxColumn.DataPropertyName = "Guage"
        Me.GuageDataGridViewTextBoxColumn.HeaderText = "厚度"
        Me.GuageDataGridViewTextBoxColumn.Name = "GuageDataGridViewTextBoxColumn"
        Me.GuageDataGridViewTextBoxColumn.Width = 60
        '
        'WidthDataGridViewTextBoxColumn
        '
        Me.WidthDataGridViewTextBoxColumn.DataPropertyName = "Width"
        Me.WidthDataGridViewTextBoxColumn.HeaderText = "寬度"
        Me.WidthDataGridViewTextBoxColumn.Name = "WidthDataGridViewTextBoxColumn"
        Me.WidthDataGridViewTextBoxColumn.Width = 60
        '
        'LengthDataGridViewTextBoxColumn
        '
        Me.LengthDataGridViewTextBoxColumn.DataPropertyName = "Length"
        Me.LengthDataGridViewTextBoxColumn.HeaderText = "長度"
        Me.LengthDataGridViewTextBoxColumn.Name = "LengthDataGridViewTextBoxColumn"
        Me.LengthDataGridViewTextBoxColumn.Width = 60
        '
        'WeightDataGridViewTextBoxColumn
        '
        Me.WeightDataGridViewTextBoxColumn.DataPropertyName = "Weight"
        Me.WeightDataGridViewTextBoxColumn.HeaderText = "重量"
        Me.WeightDataGridViewTextBoxColumn.Name = "WeightDataGridViewTextBoxColumn"
        Me.WeightDataGridViewTextBoxColumn.Width = 60
        '
        'ReturnWeightDataGridViewTextBoxColumn
        '
        Me.ReturnWeightDataGridViewTextBoxColumn.DataPropertyName = "ReturnWeight"
        Me.ReturnWeightDataGridViewTextBoxColumn.HeaderText = "退料重"
        Me.ReturnWeightDataGridViewTextBoxColumn.Name = "ReturnWeightDataGridViewTextBoxColumn"
        Me.ReturnWeightDataGridViewTextBoxColumn.Width = 75
        '
        'CoilStartTimeDataGridViewTextBoxColumn
        '
        Me.CoilStartTimeDataGridViewTextBoxColumn.DataPropertyName = "CoilStartTime"
        Me.CoilStartTimeDataGridViewTextBoxColumn.HeaderText = "起始時間"
        Me.CoilStartTimeDataGridViewTextBoxColumn.Name = "CoilStartTimeDataGridViewTextBoxColumn"
        Me.CoilStartTimeDataGridViewTextBoxColumn.Width = 75
        '
        'CoilEndTimeDataGridViewTextBoxColumn
        '
        Me.CoilEndTimeDataGridViewTextBoxColumn.DataPropertyName = "CoilEndTime"
        Me.CoilEndTimeDataGridViewTextBoxColumn.HeaderText = "終止時間"
        Me.CoilEndTimeDataGridViewTextBoxColumn.Name = "CoilEndTimeDataGridViewTextBoxColumn"
        Me.CoilEndTimeDataGridViewTextBoxColumn.Width = 75
        '
        'ScaleWeightDataGridViewTextBoxColumn
        '
        Me.ScaleWeightDataGridViewTextBoxColumn.DataPropertyName = "ScaleWeight"
        Me.ScaleWeightDataGridViewTextBoxColumn.HeaderText = "損耗重"
        Me.ScaleWeightDataGridViewTextBoxColumn.Name = "ScaleWeightDataGridViewTextBoxColumn"
        Me.ScaleWeightDataGridViewTextBoxColumn.Width = 75
        '
        'OtherWeightDataGridViewTextBoxColumn
        '
        Me.OtherWeightDataGridViewTextBoxColumn.DataPropertyName = "OtherWeight"
        Me.OtherWeightDataGridViewTextBoxColumn.HeaderText = "頭尾料重"
        Me.OtherWeightDataGridViewTextBoxColumn.Name = "OtherWeightDataGridViewTextBoxColumn"
        Me.OtherWeightDataGridViewTextBoxColumn.Width = 75
        '
        'Memo1DataGridViewTextBoxColumn
        '
        Me.Memo1DataGridViewTextBoxColumn.DataPropertyName = "Memo1"
        Me.Memo1DataGridViewTextBoxColumn.HeaderText = "備註1"
        Me.Memo1DataGridViewTextBoxColumn.Name = "Memo1DataGridViewTextBoxColumn"
        Me.Memo1DataGridViewTextBoxColumn.Width = 60
        '
        'WriteEmployeeNumberDataGridViewTextBoxColumn
        '
        Me.WriteEmployeeNumberDataGridViewTextBoxColumn.DataPropertyName = "WriteEmployeeNumber"
        Me.WriteEmployeeNumberDataGridViewTextBoxColumn.HeaderText = "員工工號"
        Me.WriteEmployeeNumberDataGridViewTextBoxColumn.Name = "WriteEmployeeNumberDataGridViewTextBoxColumn"
        Me.WriteEmployeeNumberDataGridViewTextBoxColumn.Width = 75
        '
        'FKRunStationNameDataGridViewTextBoxColumn
        '
        Me.FKRunStationNameDataGridViewTextBoxColumn.DataPropertyName = "FK_RunStationName"
        Me.FKRunStationNameDataGridViewTextBoxColumn.HeaderText = "執行站台屬性名稱"
        Me.FKRunStationNameDataGridViewTextBoxColumn.Name = "FKRunStationNameDataGridViewTextBoxColumn"
        Me.FKRunStationNameDataGridViewTextBoxColumn.Width = 104
        '
        'RunStationPCIPDataGridViewTextBoxColumn
        '
        Me.RunStationPCIPDataGridViewTextBoxColumn.DataPropertyName = "RunStationPCIP"
        Me.RunStationPCIPDataGridViewTextBoxColumn.HeaderText = "產生站台IP"
        Me.RunStationPCIPDataGridViewTextBoxColumn.Name = "RunStationPCIPDataGridViewTextBoxColumn"
        Me.RunStationPCIPDataGridViewTextBoxColumn.Width = 89
        '
        'FKLastRefSHA01DataGridViewTextBoxColumn
        '
        Me.FKLastRefSHA01DataGridViewTextBoxColumn.DataPropertyName = "FK_LastRefSHA01"
        Me.FKLastRefSHA01DataGridViewTextBoxColumn.HeaderText = "最後參考SHA01"
        Me.FKLastRefSHA01DataGridViewTextBoxColumn.Name = "FKLastRefSHA01DataGridViewTextBoxColumn"
        Me.FKLastRefSHA01DataGridViewTextBoxColumn.Width = 89
        '
        'FKLastRefSHA02DataGridViewTextBoxColumn
        '
        Me.FKLastRefSHA02DataGridViewTextBoxColumn.DataPropertyName = "FK_LastRefSHA02"
        Me.FKLastRefSHA02DataGridViewTextBoxColumn.HeaderText = "最後參考SHA02"
        Me.FKLastRefSHA02DataGridViewTextBoxColumn.Name = "FKLastRefSHA02DataGridViewTextBoxColumn"
        Me.FKLastRefSHA02DataGridViewTextBoxColumn.Width = 89
        '
        'FKLastRefSHA04DataGridViewTextBoxColumn
        '
        Me.FKLastRefSHA04DataGridViewTextBoxColumn.DataPropertyName = "FK_LastRefSHA04"
        Me.FKLastRefSHA04DataGridViewTextBoxColumn.HeaderText = "最後參考SHA04"
        Me.FKLastRefSHA04DataGridViewTextBoxColumn.Name = "FKLastRefSHA04DataGridViewTextBoxColumn"
        Me.FKLastRefSHA04DataGridViewTextBoxColumn.Width = 89
        '
        'FKRunProcessSchedualIDDataGridViewTextBoxColumn
        '
        Me.FKRunProcessSchedualIDDataGridViewTextBoxColumn.DataPropertyName = "FK_RunProcessSchedualID"
        Me.FKRunProcessSchedualIDDataGridViewTextBoxColumn.HeaderText = "執行ProcessSchedualID"
        Me.FKRunProcessSchedualIDDataGridViewTextBoxColumn.Name = "FKRunProcessSchedualIDDataGridViewTextBoxColumn"
        Me.FKRunProcessSchedualIDDataGridViewTextBoxColumn.Width = 183
        '
        'IDDataGridViewTextBoxColumn
        '
        Me.IDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn.Name = "IDDataGridViewTextBoxColumn"
        Me.IDDataGridViewTextBoxColumn.Width = 49
        '
        'bsCurrentRunProcessData
        '
        Me.bsCurrentRunProcessData.DataSource = GetType(CompanyORMDB.SQLServer.PPS100LB.RunProcessData)
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(168, 30)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "鋼捲掃描作業資料產生排程資料:"
        '
        'btnCreateTheStationDatas1
        '
        Me.btnCreateTheStationDatas1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreateTheStationDatas1.Location = New System.Drawing.Point(187, 0)
        Me.btnCreateTheStationDatas1.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCreateTheStationDatas1.Name = "btnCreateTheStationDatas1"
        Me.btnCreateTheStationDatas1.Size = New System.Drawing.Size(143, 30)
        Me.btnCreateTheStationDatas1.TabIndex = 2
        Me.btnCreateTheStationDatas1.Text = "產生/重新產生 本站資料"
        Me.btnCreateTheStationDatas1.UseVisualStyleBackColor = True
        '
        'btnPrintLabel
        '
        Me.btnPrintLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintLabel.Location = New System.Drawing.Point(330, 0)
        Me.btnPrintLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.btnPrintLabel.Name = "btnPrintLabel"
        Me.btnPrintLabel.Size = New System.Drawing.Size(105, 30)
        Me.btnPrintLabel.TabIndex = 3
        Me.btnPrintLabel.Text = "補印條碼"
        Me.btnPrintLabel.UseVisualStyleBackColor = True
        '
        'tbShowDetail2
        '
        Me.tbShowDetail2.Controls.Add(Me.TableLayoutPanel2)
        Me.tbShowDetail2.ImageIndex = 1
        Me.tbShowDetail2.Location = New System.Drawing.Point(4, 26)
        Me.tbShowDetail2.Name = "tbShowDetail2"
        Me.tbShowDetail2.Size = New System.Drawing.Size(589, 190)
        Me.tbShowDetail2.TabIndex = 0
        Me.tbShowDetail2.Text = "歷史排程記錄"
        Me.tbShowDetail2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel3, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.DataGridView1, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(589, 190)
        Me.TableLayoutPanel2.TabIndex = 13
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel3.Controls.Add(Me.Label4)
        Me.FlowLayoutPanel3.Controls.Add(Me.NumericUpDown1)
        Me.FlowLayoutPanel3.Controls.Add(Me.btnCreateTheStationDatas)
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(153, 3)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(433, 24)
        Me.FlowLayoutPanel3.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "分捲:"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(57, 3)
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(42, 27)
        Me.NumericUpDown1.TabIndex = 1
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'btnCreateTheStationDatas
        '
        Me.btnCreateTheStationDatas.Enabled = False
        Me.btnCreateTheStationDatas.Location = New System.Drawing.Point(105, 3)
        Me.btnCreateTheStationDatas.Name = "btnCreateTheStationDatas"
        Me.btnCreateTheStationDatas.Size = New System.Drawing.Size(154, 23)
        Me.btnCreateTheStationDatas.TabIndex = 3
        Me.btnCreateTheStationDatas.Text = "產生/重新產生 本站資料"
        Me.btnCreateTheStationDatas.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SHA01DataGridViewTextBoxColumn1, Me.SHA02DataGridViewTextBoxColumn1, Me.SHA04DataGridViewTextBoxColumn1, Me.SHA39DataGridViewTextBoxColumn1, Me.SHA06DataGridViewTextBoxColumn1, Me.SHA08DataGridViewTextBoxColumn1, Me.SHA11DataGridViewTextBoxColumn1, Me.SHA12DataGridViewTextBoxColumn1, Me.SHA13DataGridViewTextBoxColumn1, Me.SHA14DataGridViewTextBoxColumn1, Me.SHA15DataGridViewTextBoxColumn1, Me.SHA16DataGridViewTextBoxColumn1, Me.SHA17DataGridViewTextBoxColumn1, Me.SHA18DataGridViewTextBoxColumn1, Me.SHA19DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn1, Me.SHA21DataGridViewTextBoxColumn1, Me.SHA22DataGridViewTextBoxColumn1, Me.SHA23DataGridViewTextBoxColumn1, Me.SHA24DataGridViewTextBoxColumn1, Me.SHA25DataGridViewTextBoxColumn1, Me.SHA26DataGridViewTextBoxColumn1, Me.SHA27DataGridViewTextBoxColumn1, Me.SHA28DataGridViewTextBoxColumn1, Me.SHA29DataGridViewTextBoxColumn1})
        Me.TableLayoutPanel2.SetColumnSpan(Me.DataGridView1, 2)
        Me.DataGridView1.DataSource = Me.bsCurrentCoilDatas
        Me.DataGridView1.Location = New System.Drawing.Point(3, 33)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 20
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(583, 154)
        Me.DataGridView1.TabIndex = 12
        '
        'SHA01DataGridViewTextBoxColumn1
        '
        Me.SHA01DataGridViewTextBoxColumn1.DataPropertyName = "SHA01"
        Me.SHA01DataGridViewTextBoxColumn1.HeaderText = "鋼捲號碼"
        Me.SHA01DataGridViewTextBoxColumn1.Name = "SHA01DataGridViewTextBoxColumn1"
        Me.SHA01DataGridViewTextBoxColumn1.ReadOnly = True
        Me.SHA01DataGridViewTextBoxColumn1.Width = 75
        '
        'SHA02DataGridViewTextBoxColumn1
        '
        Me.SHA02DataGridViewTextBoxColumn1.DataPropertyName = "SHA02"
        Me.SHA02DataGridViewTextBoxColumn1.HeaderText = "分捲號碼"
        Me.SHA02DataGridViewTextBoxColumn1.Name = "SHA02DataGridViewTextBoxColumn1"
        Me.SHA02DataGridViewTextBoxColumn1.ReadOnly = True
        Me.SHA02DataGridViewTextBoxColumn1.Width = 75
        '
        'SHA04DataGridViewTextBoxColumn1
        '
        Me.SHA04DataGridViewTextBoxColumn1.DataPropertyName = "SHA04"
        Me.SHA04DataGridViewTextBoxColumn1.HeaderText = "順序"
        Me.SHA04DataGridViewTextBoxColumn1.Name = "SHA04DataGridViewTextBoxColumn1"
        Me.SHA04DataGridViewTextBoxColumn1.ReadOnly = True
        Me.SHA04DataGridViewTextBoxColumn1.Width = 60
        '
        'SHA39DataGridViewTextBoxColumn1
        '
        Me.SHA39DataGridViewTextBoxColumn1.DataPropertyName = "SHA39"
        Me.SHA39DataGridViewTextBoxColumn1.HeaderText = "最終產品表面"
        Me.SHA39DataGridViewTextBoxColumn1.Name = "SHA39DataGridViewTextBoxColumn1"
        Me.SHA39DataGridViewTextBoxColumn1.ReadOnly = True
        Me.SHA39DataGridViewTextBoxColumn1.Width = 89
        '
        'SHA06DataGridViewTextBoxColumn1
        '
        Me.SHA06DataGridViewTextBoxColumn1.DataPropertyName = "SHA06"
        Me.SHA06DataGridViewTextBoxColumn1.HeaderText = "製程表面"
        Me.SHA06DataGridViewTextBoxColumn1.Name = "SHA06DataGridViewTextBoxColumn1"
        Me.SHA06DataGridViewTextBoxColumn1.ReadOnly = True
        Me.SHA06DataGridViewTextBoxColumn1.Width = 75
        '
        'SHA08DataGridViewTextBoxColumn1
        '
        Me.SHA08DataGridViewTextBoxColumn1.DataPropertyName = "SHA08"
        Me.SHA08DataGridViewTextBoxColumn1.HeaderText = "產線"
        Me.SHA08DataGridViewTextBoxColumn1.Name = "SHA08DataGridViewTextBoxColumn1"
        Me.SHA08DataGridViewTextBoxColumn1.ReadOnly = True
        Me.SHA08DataGridViewTextBoxColumn1.Width = 60
        '
        'SHA11DataGridViewTextBoxColumn1
        '
        Me.SHA11DataGridViewTextBoxColumn1.DataPropertyName = "SHA11"
        Me.SHA11DataGridViewTextBoxColumn1.HeaderText = "排程日期"
        Me.SHA11DataGridViewTextBoxColumn1.Name = "SHA11DataGridViewTextBoxColumn1"
        Me.SHA11DataGridViewTextBoxColumn1.ReadOnly = True
        Me.SHA11DataGridViewTextBoxColumn1.Width = 75
        '
        'SHA12DataGridViewTextBoxColumn1
        '
        Me.SHA12DataGridViewTextBoxColumn1.DataPropertyName = "SHA12"
        Me.SHA12DataGridViewTextBoxColumn1.HeaderText = "鋼種"
        Me.SHA12DataGridViewTextBoxColumn1.Name = "SHA12DataGridViewTextBoxColumn1"
        Me.SHA12DataGridViewTextBoxColumn1.ReadOnly = True
        Me.SHA12DataGridViewTextBoxColumn1.Width = 60
        '
        'SHA13DataGridViewTextBoxColumn1
        '
        Me.SHA13DataGridViewTextBoxColumn1.DataPropertyName = "SHA13"
        Me.SHA13DataGridViewTextBoxColumn1.HeaderText = "型別"
        Me.SHA13DataGridViewTextBoxColumn1.Name = "SHA13DataGridViewTextBoxColumn1"
        Me.SHA13DataGridViewTextBoxColumn1.ReadOnly = True
        Me.SHA13DataGridViewTextBoxColumn1.Width = 60
        '
        'SHA14DataGridViewTextBoxColumn1
        '
        Me.SHA14DataGridViewTextBoxColumn1.DataPropertyName = "SHA14"
        Me.SHA14DataGridViewTextBoxColumn1.HeaderText = "厚度"
        Me.SHA14DataGridViewTextBoxColumn1.Name = "SHA14DataGridViewTextBoxColumn1"
        Me.SHA14DataGridViewTextBoxColumn1.ReadOnly = True
        Me.SHA14DataGridViewTextBoxColumn1.Width = 60
        '
        'SHA15DataGridViewTextBoxColumn1
        '
        Me.SHA15DataGridViewTextBoxColumn1.DataPropertyName = "SHA15"
        Me.SHA15DataGridViewTextBoxColumn1.HeaderText = "寬度"
        Me.SHA15DataGridViewTextBoxColumn1.Name = "SHA15DataGridViewTextBoxColumn1"
        Me.SHA15DataGridViewTextBoxColumn1.ReadOnly = True
        Me.SHA15DataGridViewTextBoxColumn1.Width = 60
        '
        'SHA16DataGridViewTextBoxColumn1
        '
        Me.SHA16DataGridViewTextBoxColumn1.DataPropertyName = "SHA16"
        Me.SHA16DataGridViewTextBoxColumn1.HeaderText = "長度"
        Me.SHA16DataGridViewTextBoxColumn1.Name = "SHA16DataGridViewTextBoxColumn1"
        Me.SHA16DataGridViewTextBoxColumn1.ReadOnly = True
        Me.SHA16DataGridViewTextBoxColumn1.Width = 60
        '
        'SHA17DataGridViewTextBoxColumn1
        '
        Me.SHA17DataGridViewTextBoxColumn1.DataPropertyName = "SHA17"
        Me.SHA17DataGridViewTextBoxColumn1.HeaderText = "重量"
        Me.SHA17DataGridViewTextBoxColumn1.Name = "SHA17DataGridViewTextBoxColumn1"
        Me.SHA17DataGridViewTextBoxColumn1.ReadOnly = True
        Me.SHA17DataGridViewTextBoxColumn1.Width = 60
        '
        'SHA18DataGridViewTextBoxColumn1
        '
        Me.SHA18DataGridViewTextBoxColumn1.DataPropertyName = "SHA18"
        Me.SHA18DataGridViewTextBoxColumn1.HeaderText = "退料重"
        Me.SHA18DataGridViewTextBoxColumn1.Name = "SHA18DataGridViewTextBoxColumn1"
        Me.SHA18DataGridViewTextBoxColumn1.ReadOnly = True
        Me.SHA18DataGridViewTextBoxColumn1.Width = 75
        '
        'SHA19DataGridViewTextBoxColumn1
        '
        Me.SHA19DataGridViewTextBoxColumn1.DataPropertyName = "SHA19"
        Me.SHA19DataGridViewTextBoxColumn1.HeaderText = "損秏重"
        Me.SHA19DataGridViewTextBoxColumn1.Name = "SHA19DataGridViewTextBoxColumn1"
        Me.SHA19DataGridViewTextBoxColumn1.ReadOnly = True
        Me.SHA19DataGridViewTextBoxColumn1.Width = 75
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "SHA20"
        Me.DataGridViewTextBoxColumn1.HeaderText = "頭尾料重"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 75
        '
        'SHA21DataGridViewTextBoxColumn1
        '
        Me.SHA21DataGridViewTextBoxColumn1.DataPropertyName = "SHA21"
        Me.SHA21DataGridViewTextBoxColumn1.HeaderText = "完成日期"
        Me.SHA21DataGridViewTextBoxColumn1.Name = "SHA21DataGridViewTextBoxColumn1"
        Me.SHA21DataGridViewTextBoxColumn1.ReadOnly = True
        Me.SHA21DataGridViewTextBoxColumn1.Width = 75
        '
        'SHA22DataGridViewTextBoxColumn1
        '
        Me.SHA22DataGridViewTextBoxColumn1.DataPropertyName = "SHA22"
        Me.SHA22DataGridViewTextBoxColumn1.HeaderText = "開始時"
        Me.SHA22DataGridViewTextBoxColumn1.Name = "SHA22DataGridViewTextBoxColumn1"
        Me.SHA22DataGridViewTextBoxColumn1.ReadOnly = True
        Me.SHA22DataGridViewTextBoxColumn1.Width = 75
        '
        'SHA23DataGridViewTextBoxColumn1
        '
        Me.SHA23DataGridViewTextBoxColumn1.DataPropertyName = "SHA23"
        Me.SHA23DataGridViewTextBoxColumn1.HeaderText = "開始分"
        Me.SHA23DataGridViewTextBoxColumn1.Name = "SHA23DataGridViewTextBoxColumn1"
        Me.SHA23DataGridViewTextBoxColumn1.ReadOnly = True
        Me.SHA23DataGridViewTextBoxColumn1.Width = 75
        '
        'SHA24DataGridViewTextBoxColumn1
        '
        Me.SHA24DataGridViewTextBoxColumn1.DataPropertyName = "SHA24"
        Me.SHA24DataGridViewTextBoxColumn1.HeaderText = "結束時"
        Me.SHA24DataGridViewTextBoxColumn1.Name = "SHA24DataGridViewTextBoxColumn1"
        Me.SHA24DataGridViewTextBoxColumn1.ReadOnly = True
        Me.SHA24DataGridViewTextBoxColumn1.Width = 75
        '
        'SHA25DataGridViewTextBoxColumn1
        '
        Me.SHA25DataGridViewTextBoxColumn1.DataPropertyName = "SHA25"
        Me.SHA25DataGridViewTextBoxColumn1.HeaderText = "結束分"
        Me.SHA25DataGridViewTextBoxColumn1.Name = "SHA25DataGridViewTextBoxColumn1"
        Me.SHA25DataGridViewTextBoxColumn1.ReadOnly = True
        Me.SHA25DataGridViewTextBoxColumn1.Width = 75
        '
        'SHA26DataGridViewTextBoxColumn1
        '
        Me.SHA26DataGridViewTextBoxColumn1.DataPropertyName = "SHA26"
        Me.SHA26DataGridViewTextBoxColumn1.HeaderText = "GP研磨次數"
        Me.SHA26DataGridViewTextBoxColumn1.Name = "SHA26DataGridViewTextBoxColumn1"
        Me.SHA26DataGridViewTextBoxColumn1.ReadOnly = True
        Me.SHA26DataGridViewTextBoxColumn1.Width = 89
        '
        'SHA27DataGridViewTextBoxColumn1
        '
        Me.SHA27DataGridViewTextBoxColumn1.DataPropertyName = "SHA27"
        Me.SHA27DataGridViewTextBoxColumn1.HeaderText = "下一產線"
        Me.SHA27DataGridViewTextBoxColumn1.Name = "SHA27DataGridViewTextBoxColumn1"
        Me.SHA27DataGridViewTextBoxColumn1.ReadOnly = True
        Me.SHA27DataGridViewTextBoxColumn1.Width = 75
        '
        'SHA28DataGridViewTextBoxColumn1
        '
        Me.SHA28DataGridViewTextBoxColumn1.DataPropertyName = "SHA28"
        Me.SHA28DataGridViewTextBoxColumn1.HeaderText = "產線是否完成"
        Me.SHA28DataGridViewTextBoxColumn1.Name = "SHA28DataGridViewTextBoxColumn1"
        Me.SHA28DataGridViewTextBoxColumn1.ReadOnly = True
        Me.SHA28DataGridViewTextBoxColumn1.Width = 89
        '
        'SHA29DataGridViewTextBoxColumn1
        '
        Me.SHA29DataGridViewTextBoxColumn1.DataPropertyName = "SHA29"
        Me.SHA29DataGridViewTextBoxColumn1.HeaderText = "是否為完成產品"
        Me.SHA29DataGridViewTextBoxColumn1.Name = "SHA29DataGridViewTextBoxColumn1"
        Me.SHA29DataGridViewTextBoxColumn1.ReadOnly = True
        Me.SHA29DataGridViewTextBoxColumn1.Width = 104
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 30)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "手動強制產生排程資料:"
        '
        'ILAfterProcessTabPageImages
        '
        Me.ILAfterProcessTabPageImages.ImageStream = CType(resources.GetObject("ILAfterProcessTabPageImages.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ILAfterProcessTabPageImages.TransparentColor = System.Drawing.Color.Transparent
        Me.ILAfterProcessTabPageImages.Images.SetKeyName(0, "Process1.jpg")
        Me.ILAfterProcessTabPageImages.Images.SetKeyName(1, "History1.jpg")
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btnEndAndSave)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnDeleteLastSaveDatas)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(146, 73)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(597, 29)
        Me.FlowLayoutPanel1.TabIndex = 15
        '
        'btnEndAndSave
        '
        Me.btnEndAndSave.Location = New System.Drawing.Point(3, 3)
        Me.btnEndAndSave.Name = "btnEndAndSave"
        Me.btnEndAndSave.Size = New System.Drawing.Size(108, 23)
        Me.btnEndAndSave.TabIndex = 4
        Me.btnEndAndSave.Text = "結束並儲存資料"
        Me.btnEndAndSave.UseVisualStyleBackColor = True
        '
        'btnDeleteLastSaveDatas
        '
        Me.btnDeleteLastSaveDatas.AutoSize = True
        Me.btnDeleteLastSaveDatas.Enabled = False
        Me.btnDeleteLastSaveDatas.Location = New System.Drawing.Point(117, 3)
        Me.btnDeleteLastSaveDatas.Name = "btnDeleteLastSaveDatas"
        Me.btnDeleteLastSaveDatas.Size = New System.Drawing.Size(178, 26)
        Me.btnDeleteLastSaveDatas.TabIndex = 5
        Me.btnDeleteLastSaveDatas.Text = "刪除最後本站儲存資料"
        Me.btnDeleteLastSaveDatas.UseVisualStyleBackColor = True
        '
        'tpCoilMoveStationEdit
        '
        Me.tpCoilMoveStationEdit.Location = New System.Drawing.Point(4, 26)
        Me.tpCoilMoveStationEdit.Name = "tpCoilMoveStationEdit"
        Me.tpCoilMoveStationEdit.Size = New System.Drawing.Size(752, 548)
        Me.tpCoilMoveStationEdit.TabIndex = 4
        Me.tpCoilMoveStationEdit.Text = "生計黑皮派工"
        Me.tpCoilMoveStationEdit.UseVisualStyleBackColor = True
        '
        'tpCoilBeforeRunningProcess
        '
        Me.tpCoilBeforeRunningProcess.Location = New System.Drawing.Point(4, 26)
        Me.tpCoilBeforeRunningProcess.Name = "tpCoilBeforeRunningProcess"
        Me.tpCoilBeforeRunningProcess.Size = New System.Drawing.Size(752, 548)
        Me.tpCoilBeforeRunningProcess.TabIndex = 5
        Me.tpCoilBeforeRunningProcess.Text = "準備線鋼捲預覽"
        Me.tpCoilBeforeRunningProcess.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tsslMessage})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 578)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(760, 22)
        Me.StatusStrip1.TabIndex = 3
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
        Me.tsslMessage.ForeColor = System.Drawing.Color.Red
        Me.tsslMessage.Name = "tsslMessage"
        Me.tsslMessage.Size = New System.Drawing.Size(0, 17)
        '
        'SerialPortEx1
        '
        Me.SerialPortEx1.ContainerUserControl = Nothing
        Me.SerialPortEx1.ReceiveDataIntervalMilliSeconds = 100
        '
        'tpSelfQC
        '
        Me.tpSelfQC.Location = New System.Drawing.Point(4, 26)
        Me.tpSelfQC.Name = "tpSelfQC"
        Me.tpSelfQC.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSelfQC.Size = New System.Drawing.Size(752, 548)
        Me.tpSelfQC.TabIndex = 7
        Me.tpSelfQC.Text = "自主品管"
        Me.tpSelfQC.UseVisualStyleBackColor = True
        '
        'StationClient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "StationClient"
        Me.Size = New System.Drawing.Size(760, 600)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsdNewAddCoilDatas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsCurrentCoilDatas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.tbShowDetail1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsCurrentRunProcessData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbShowDetail2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.FlowLayoutPanel3.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnAddCoil As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel3 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnCreateTheStationDatas As System.Windows.Forms.Button
    Friend WithEvents btnEndAndSave As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents bsCurrentCoilDatas As System.Windows.Forms.BindingSource
    Friend WithEvents bsdNewAddCoilDatas As System.Windows.Forms.BindingSource
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SerialPortEx1 As ExWindowControlLibrary.SerialPortEx
    Friend WithEvents btnDeleteLastSaveDatas As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents SHA01DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA02DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA04DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA39DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA06DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA08DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA11DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA12DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA13DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA14DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA15DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA16DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA17DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA18DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA19DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA21DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA22DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA23DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA24DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA25DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA26DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA27DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA28DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA29DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EditButton As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents SHA01DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA02DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA04DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA39DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA06DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA08DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA11DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA12DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA13DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA14DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA15DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA16DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA17DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA18DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA19DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA21DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA22DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA23DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA24DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA25DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA26DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA27DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA28DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tpCoilScanAndMachineProcess As System.Windows.Forms.TabPage
    Friend WithEvents lbProcessSchedual As System.Windows.Forms.Label
    Friend WithEvents flpProcessSchedualSelect As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents tbShowDetail2 As System.Windows.Forms.TabPage
    Friend WithEvents tbShowDetail1 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView3 As System.Windows.Forms.DataGridView
    Friend WithEvents bsCurrentRunProcessData As System.Windows.Forms.BindingSource
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnCreateTheStationDatas1 As System.Windows.Forms.Button
    Friend WithEvents FKPreRunProcessDataIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ILAfterProcessTabPageImages As System.Windows.Forms.ImageList
    Friend WithEvents btnPrintLabel As System.Windows.Forms.Button
    Friend WithEvents FK_OutSHA01 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FK_OutSHA02 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BreakCoilNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GuageDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WidthDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LengthDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnWeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CoilStartTimeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CoilEndTimeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScaleWeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OtherWeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Memo1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WriteEmployeeNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FKRunStationNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RunStationPCIPDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FKLastRefSHA01DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FKLastRefSHA02DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FKLastRefSHA04DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FKRunProcessSchedualIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tpCoilMoveStationEdit As System.Windows.Forms.TabPage
    Friend WithEvents tpCoilBeforeRunningProcess As System.Windows.Forms.TabPage
    Friend WithEvents tpCoilAfterRunningProcessControl As System.Windows.Forms.TabPage
    Friend WithEvents tpSelfQC As System.Windows.Forms.TabPage

End Class
