<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CoilAfterRunningProcess
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CoilAfterRunningProcess))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpSearch1 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel6 = New System.Windows.Forms.FlowLayoutPanel()
        Me.rbIsCheckedDataAll = New System.Windows.Forms.RadioButton()
        Me.rbIsCheckedDataYes = New System.Windows.Forms.RadioButton()
        Me.rbIsCheckedDataNo = New System.Windows.Forms.RadioButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbWillFilterDate = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.tbCoilNumbers = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tpSearchResultOrder = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel8 = New System.Windows.Forms.FlowLayoutPanel()
        Me.rbSort1 = New System.Windows.Forms.RadioButton()
        Me.rbSort2 = New System.Windows.Forms.RadioButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbSearchRun = New System.Windows.Forms.ToolStripButton()
        Me.tsbClearSearchFilter = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbAddCoilBreak = New System.Windows.Forms.ToolStripButton()
        Me.tsbDeletCoilBreak = New System.Windows.Forms.ToolStripButton()
        Me.tsbPrintBarCode = New System.Windows.Forms.ToolStripButton()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tvSearchResult = New System.Windows.Forms.TreeView()
        Me.tabDetailEdit = New System.Windows.Forms.TabControl()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpSearch1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel6.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.tpSearchResultOrder.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.FlowLayoutPanel8.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.48387!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.51613!))
        Me.TableLayoutPanel1.Controls.Add(Me.TabControl1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ToolStrip1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tvSearchResult, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.tabDetailEdit, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(620, 520)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.TabControl1, 2)
        Me.TabControl1.Controls.Add(Me.tpSearch1)
        Me.TabControl1.Controls.Add(Me.tpSearchResultOrder)
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(614, 114)
        Me.TabControl1.TabIndex = 0
        '
        'tpSearch1
        '
        Me.tpSearch1.Controls.Add(Me.TableLayoutPanel2)
        Me.tpSearch1.Location = New System.Drawing.Point(4, 22)
        Me.tpSearch1.Name = "tpSearch1"
        Me.tpSearch1.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSearch1.Size = New System.Drawing.Size(606, 88)
        Me.tpSearch1.TabIndex = 0
        Me.tpSearch1.Text = "查詢條件1"
        Me.tpSearch1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.83333!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.16667!))
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel6, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label10, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.cbWillFilterDate, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel1, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel2, 1, 2)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(600, 82)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'FlowLayoutPanel6
        '
        Me.FlowLayoutPanel6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel6.Controls.Add(Me.rbIsCheckedDataAll)
        Me.FlowLayoutPanel6.Controls.Add(Me.rbIsCheckedDataYes)
        Me.FlowLayoutPanel6.Controls.Add(Me.rbIsCheckedDataNo)
        Me.FlowLayoutPanel6.Location = New System.Drawing.Point(101, 32)
        Me.FlowLayoutPanel6.Margin = New System.Windows.Forms.Padding(1, 5, 1, 1)
        Me.FlowLayoutPanel6.Name = "FlowLayoutPanel6"
        Me.FlowLayoutPanel6.Size = New System.Drawing.Size(498, 21)
        Me.FlowLayoutPanel6.TabIndex = 10
        '
        'rbIsCheckedDataAll
        '
        Me.rbIsCheckedDataAll.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbIsCheckedDataAll.AutoSize = True
        Me.rbIsCheckedDataAll.Checked = True
        Me.rbIsCheckedDataAll.Location = New System.Drawing.Point(3, 3)
        Me.rbIsCheckedDataAll.Name = "rbIsCheckedDataAll"
        Me.rbIsCheckedDataAll.Size = New System.Drawing.Size(47, 16)
        Me.rbIsCheckedDataAll.TabIndex = 0
        Me.rbIsCheckedDataAll.TabStop = True
        Me.rbIsCheckedDataAll.Text = "全部"
        Me.rbIsCheckedDataAll.UseVisualStyleBackColor = True
        '
        'rbIsCheckedDataYes
        '
        Me.rbIsCheckedDataYes.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbIsCheckedDataYes.AutoSize = True
        Me.rbIsCheckedDataYes.Location = New System.Drawing.Point(56, 3)
        Me.rbIsCheckedDataYes.Name = "rbIsCheckedDataYes"
        Me.rbIsCheckedDataYes.Size = New System.Drawing.Size(74, 16)
        Me.rbIsCheckedDataYes.TabIndex = 1
        Me.rbIsCheckedDataYes.Text = "是,已確認"
        Me.rbIsCheckedDataYes.UseVisualStyleBackColor = True
        '
        'rbIsCheckedDataNo
        '
        Me.rbIsCheckedDataNo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbIsCheckedDataNo.AutoSize = True
        Me.rbIsCheckedDataNo.Location = New System.Drawing.Point(136, 3)
        Me.rbIsCheckedDataNo.Name = "rbIsCheckedDataNo"
        Me.rbIsCheckedDataNo.Size = New System.Drawing.Size(74, 16)
        Me.rbIsCheckedDataNo.TabIndex = 2
        Me.rbIsCheckedDataNo.Text = "否,未確認"
        Me.rbIsCheckedDataNo.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(17, 34)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 12)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "是否確認資料:"
        '
        'cbWillFilterDate
        '
        Me.cbWillFilterDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cbWillFilterDate.AutoSize = True
        Me.cbWillFilterDate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbWillFilterDate.Checked = True
        Me.cbWillFilterDate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbWillFilterDate.Location = New System.Drawing.Point(22, 5)
        Me.cbWillFilterDate.Name = "cbWillFilterDate"
        Me.cbWillFilterDate.Size = New System.Drawing.Size(75, 16)
        Me.cbWillFilterDate.TabIndex = 0
        Me.cbWillFilterDate.Text = "日期時間:"
        Me.cbWillFilterDate.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.Controls.Add(Me.dtpStartDate)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label1)
        Me.FlowLayoutPanel1.Controls.Add(Me.dtpEndDate)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(101, 1)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(1)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(498, 25)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpStartDate.Location = New System.Drawing.Point(3, 3)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(127, 22)
        Me.dtpStartDate.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(136, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "~"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpEndDate.Location = New System.Drawing.Point(153, 3)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(127, 22)
        Me.dtpEndDate.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(41, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "鋼捲號碼:"
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel2.Controls.Add(Me.tbCoilNumbers)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label3)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(101, 55)
        Me.FlowLayoutPanel2.Margin = New System.Windows.Forms.Padding(1)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(498, 26)
        Me.FlowLayoutPanel2.TabIndex = 3
        '
        'tbCoilNumbers
        '
        Me.tbCoilNumbers.Location = New System.Drawing.Point(3, 3)
        Me.tbCoilNumbers.Name = "tbCoilNumbers"
        Me.tbCoilNumbers.Size = New System.Drawing.Size(277, 22)
        Me.tbCoilNumbers.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(286, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(160, 12)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "(可以 ',' 區分,Ex:A1234,A1235)"
        '
        'tpSearchResultOrder
        '
        Me.tpSearchResultOrder.Controls.Add(Me.TableLayoutPanel4)
        Me.tpSearchResultOrder.Location = New System.Drawing.Point(4, 22)
        Me.tpSearchResultOrder.Name = "tpSearchResultOrder"
        Me.tpSearchResultOrder.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSearchResultOrder.Size = New System.Drawing.Size(606, 88)
        Me.tpSearchResultOrder.TabIndex = 2
        Me.tpSearchResultOrder.Text = "查詢結果排序"
        Me.tpSearchResultOrder.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.83333!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.16667!))
        Me.TableLayoutPanel4.Controls.Add(Me.Label12, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.FlowLayoutPanel8, 1, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(600, 82)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(41, 14)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 12)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "排序依據:"
        '
        'FlowLayoutPanel8
        '
        Me.FlowLayoutPanel8.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel8.Controls.Add(Me.rbSort1)
        Me.FlowLayoutPanel8.Controls.Add(Me.rbSort2)
        Me.FlowLayoutPanel8.Location = New System.Drawing.Point(101, 5)
        Me.FlowLayoutPanel8.Margin = New System.Windows.Forms.Padding(1, 5, 1, 1)
        Me.FlowLayoutPanel8.Name = "FlowLayoutPanel8"
        Me.FlowLayoutPanel8.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.FlowLayoutPanel8.Size = New System.Drawing.Size(498, 35)
        Me.FlowLayoutPanel8.TabIndex = 13
        '
        'rbSort1
        '
        Me.rbSort1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbSort1.AutoSize = True
        Me.rbSort1.Checked = True
        Me.rbSort1.Location = New System.Drawing.Point(3, 8)
        Me.rbSort1.Name = "rbSort1"
        Me.rbSort1.Size = New System.Drawing.Size(47, 16)
        Me.rbSort1.TabIndex = 0
        Me.rbSort1.TabStop = True
        Me.rbSort1.Text = "時間"
        Me.rbSort1.UseVisualStyleBackColor = True
        '
        'rbSort2
        '
        Me.rbSort2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbSort2.AutoSize = True
        Me.rbSort2.Location = New System.Drawing.Point(56, 8)
        Me.rbSort2.Name = "rbSort2"
        Me.rbSort2.Size = New System.Drawing.Size(71, 16)
        Me.rbSort2.TabIndex = 1
        Me.rbSort2.Text = "鋼捲號碼"
        Me.rbSort2.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ToolStrip1, 2)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSearchRun, Me.tsbClearSearchFilter, Me.ToolStripSeparator1, Me.tsbAddCoilBreak, Me.tsbDeletCoilBreak, Me.tsbPrintBarCode, Me.tsbSave})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 120)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(620, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbSearchRun
        '
        Me.tsbSearchRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbSearchRun.Image = CType(resources.GetObject("tsbSearchRun.Image"), System.Drawing.Image)
        Me.tsbSearchRun.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSearchRun.Name = "tsbSearchRun"
        Me.tsbSearchRun.Size = New System.Drawing.Size(59, 22)
        Me.tsbSearchRun.Text = "執行查詢"
        '
        'tsbClearSearchFilter
        '
        Me.tsbClearSearchFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbClearSearchFilter.Image = CType(resources.GetObject("tsbClearSearchFilter.Image"), System.Drawing.Image)
        Me.tsbClearSearchFilter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbClearSearchFilter.Name = "tsbClearSearchFilter"
        Me.tsbClearSearchFilter.Size = New System.Drawing.Size(83, 22)
        Me.tsbClearSearchFilter.Text = "清除查詢條件"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbAddCoilBreak
        '
        Me.tsbAddCoilBreak.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbAddCoilBreak.Enabled = False
        Me.tsbAddCoilBreak.Image = CType(resources.GetObject("tsbAddCoilBreak.Image"), System.Drawing.Image)
        Me.tsbAddCoilBreak.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAddCoilBreak.Name = "tsbAddCoilBreak"
        Me.tsbAddCoilBreak.Size = New System.Drawing.Size(59, 22)
        Me.tsbAddCoilBreak.Text = "鋼捲分捲"
        '
        'tsbDeletCoilBreak
        '
        Me.tsbDeletCoilBreak.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbDeletCoilBreak.Enabled = False
        Me.tsbDeletCoilBreak.Image = CType(resources.GetObject("tsbDeletCoilBreak.Image"), System.Drawing.Image)
        Me.tsbDeletCoilBreak.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDeletCoilBreak.Name = "tsbDeletCoilBreak"
        Me.tsbDeletCoilBreak.Size = New System.Drawing.Size(59, 22)
        Me.tsbDeletCoilBreak.Text = "刪除分捲"
        '
        'tsbPrintBarCode
        '
        Me.tsbPrintBarCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbPrintBarCode.Enabled = False
        Me.tsbPrintBarCode.Image = CType(resources.GetObject("tsbPrintBarCode.Image"), System.Drawing.Image)
        Me.tsbPrintBarCode.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPrintBarCode.Name = "tsbPrintBarCode"
        Me.tsbPrintBarCode.Size = New System.Drawing.Size(59, 22)
        Me.tsbPrintBarCode.Text = "列印條碼"
        '
        'tsbSave
        '
        Me.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbSave.Enabled = False
        Me.tsbSave.Image = CType(resources.GetObject("tsbSave.Image"), System.Drawing.Image)
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(35, 22)
        Me.tsbSave.Text = "儲存"
        '
        'tvSearchResult
        '
        Me.tvSearchResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvSearchResult.Font = New System.Drawing.Font("標楷體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tvSearchResult.Location = New System.Drawing.Point(3, 153)
        Me.tvSearchResult.Name = "tvSearchResult"
        Me.tvSearchResult.Size = New System.Drawing.Size(151, 364)
        Me.tvSearchResult.TabIndex = 2
        '
        'tabDetailEdit
        '
        Me.tabDetailEdit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabDetailEdit.Location = New System.Drawing.Point(160, 153)
        Me.tabDetailEdit.Name = "tabDetailEdit"
        Me.tabDetailEdit.SelectedIndex = 0
        Me.tabDetailEdit.Size = New System.Drawing.Size(457, 364)
        Me.tabDetailEdit.TabIndex = 3
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tsslMessage})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 498)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(2, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(620, 22)
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
        Me.tsslMessage.BackColor = System.Drawing.SystemColors.Control
        Me.tsslMessage.ForeColor = System.Drawing.Color.Red
        Me.tsslMessage.Name = "tsslMessage"
        Me.tsslMessage.Size = New System.Drawing.Size(23, 17)
        Me.tsslMessage.Text = "無!"
        '
        'CoilAfterRunningProcess
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "CoilAfterRunningProcess"
        Me.Size = New System.Drawing.Size(620, 520)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tpSearch1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.FlowLayoutPanel6.ResumeLayout(False)
        Me.FlowLayoutPanel6.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.tpSearchResultOrder.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.FlowLayoutPanel8.ResumeLayout(False)
        Me.FlowLayoutPanel8.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpSearch1 As System.Windows.Forms.TabPage
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSearchRun As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbClearSearchFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbAddCoilBreak As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDeletCoilBreak As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbPrintBarCode As System.Windows.Forms.ToolStripButton
    Friend WithEvents tpSearchResultOrder As System.Windows.Forms.TabPage
    Friend WithEvents tvSearchResult As System.Windows.Forms.TreeView
    Friend WithEvents tabDetailEdit As System.Windows.Forms.TabControl
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cbWillFilterDate As System.Windows.Forms.CheckBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents tbCoilNumbers As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel6 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbIsCheckedDataAll As System.Windows.Forms.RadioButton
    Friend WithEvents rbIsCheckedDataYes As System.Windows.Forms.RadioButton
    Friend WithEvents rbIsCheckedDataNo As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel8 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbSort1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbSort2 As System.Windows.Forms.RadioButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton

End Class
