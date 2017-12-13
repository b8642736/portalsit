<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CoilMoveStationEdit
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpPMNewsMode = New System.Windows.Forms.TabPage()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DisplayWidth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpSearchEditMode = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.tbFilterCoilNumbers = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.tbDelete = New System.Windows.Forms.Button()
        Me.cbIsDateFilter = New System.Windows.Forms.CheckBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.DataSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.CIW15DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CIW12DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CIW05DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CIW0ADataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CIW03DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CIW04DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CIW06DescriptDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsPlanProductionDisplay = New System.Windows.Forms.BindingSource(Me.components)
        Me.RunStationPCIPDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RunCoilFullNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RunStationNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AS400TimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NextRunStationNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsCoilMoveState = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpPMNewsMode.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpSearchEditMode.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel3.SuspendLayout()
        CType(Me.bsPlanProductionDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsCoilMoveState, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TabControl1, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 569.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(619, 569)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tpPMNewsMode)
        Me.TabControl1.Controls.Add(Me.tpSearchEditMode)
        Me.TabControl1.Font = New System.Drawing.Font("標楷體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(613, 563)
        Me.TabControl1.TabIndex = 2
        '
        'tpPMNewsMode
        '
        Me.tpPMNewsMode.Controls.Add(Me.DataGridView2)
        Me.tpPMNewsMode.Location = New System.Drawing.Point(4, 26)
        Me.tpPMNewsMode.Name = "tpPMNewsMode"
        Me.tpPMNewsMode.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPMNewsMode.Size = New System.Drawing.Size(605, 533)
        Me.tpPMNewsMode.TabIndex = 0
        Me.tpPMNewsMode.Text = "生技派工計劃"
        Me.tpPMNewsMode.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AutoGenerateColumns = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CIW15DataGridViewTextBoxColumn1, Me.DisplayWidth, Me.CIW12DataGridViewTextBoxColumn1, Me.CIW05DataGridViewTextBoxColumn1, Me.CIW0ADataGridViewTextBoxColumn1, Me.CIW03DataGridViewTextBoxColumn1, Me.CIW04DataGridViewTextBoxColumn1, Me.CIW06DescriptDataGridViewTextBoxColumn})
        Me.DataGridView2.DataSource = Me.bsPlanProductionDisplay
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowTemplate.Height = 24
        Me.DataGridView2.Size = New System.Drawing.Size(599, 527)
        Me.DataGridView2.TabIndex = 5
        '
        'DisplayWidth
        '
        Me.DisplayWidth.DataPropertyName = "DisplayWidth"
        Me.DisplayWidth.HeaderText = "寬度"
        Me.DisplayWidth.Name = "DisplayWidth"
        Me.DisplayWidth.ReadOnly = True
        '
        'tpSearchEditMode
        '
        Me.tpSearchEditMode.Controls.Add(Me.TableLayoutPanel2)
        Me.tpSearchEditMode.Location = New System.Drawing.Point(4, 26)
        Me.tpSearchEditMode.Name = "tpSearchEditMode"
        Me.tpSearchEditMode.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSearchEditMode.Size = New System.Drawing.Size(605, 533)
        Me.tpSearchEditMode.TabIndex = 1
        Me.tpSearchEditMode.Text = "派工完成鋼捲查詢編修"
        Me.tpSearchEditMode.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnRun, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel1, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel2, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.DataGridView1, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel3, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.cbIsDateFilter, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(599, 527)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'btnRun
        '
        Me.btnRun.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRun.Location = New System.Drawing.Point(133, 83)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(98, 34)
        Me.btnRun.TabIndex = 1
        Me.btnRun.Text = "執行查詢"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(47, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "鋼捲號碼:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.Controls.Add(Me.DateTimePicker1)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label5)
        Me.FlowLayoutPanel1.Controls.Add(Me.DateTimePicker2)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(133, 43)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(463, 34)
        Me.FlowLayoutPanel1.TabIndex = 7
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(3, 3)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(98, 27)
        Me.DateTimePicker1.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(107, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(16, 33)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "~"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(129, 3)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(98, 27)
        Me.DateTimePicker2.TabIndex = 8
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel2.Controls.Add(Me.tbFilterCoilNumbers)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(133, 3)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(463, 34)
        Me.FlowLayoutPanel2.TabIndex = 8
        '
        'tbFilterCoilNumbers
        '
        Me.tbFilterCoilNumbers.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbFilterCoilNumbers.Location = New System.Drawing.Point(3, 3)
        Me.tbFilterCoilNumbers.Name = "tbFilterCoilNumbers"
        Me.tbFilterCoilNumbers.Size = New System.Drawing.Size(153, 27)
        Me.tbFilterCoilNumbers.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(360, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "(兩個以上請以',' 或 '~' 表示,EX:B1000~B2000)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataSelect, Me.RunStationPCIPDataGridViewTextBoxColumn, Me.RunCoilFullNumberDataGridViewTextBoxColumn, Me.RunStationNameDataGridViewTextBoxColumn, Me.AS400TimeDataGridViewTextBoxColumn, Me.NextRunStationNameDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.bsCoilMoveState
        Me.DataGridView1.Location = New System.Drawing.Point(133, 123)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(463, 401)
        Me.DataGridView1.TabIndex = 9
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel3.Controls.Add(Me.tbDelete)
        Me.FlowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(3, 123)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(124, 401)
        Me.FlowLayoutPanel3.TabIndex = 10
        '
        'tbDelete
        '
        Me.tbDelete.Location = New System.Drawing.Point(3, 3)
        Me.tbDelete.Name = "tbDelete"
        Me.tbDelete.Size = New System.Drawing.Size(116, 54)
        Me.tbDelete.TabIndex = 0
        Me.tbDelete.Text = "刪除並加回生計未派工處理捲數"
        Me.tbDelete.UseVisualStyleBackColor = True
        '
        'cbIsDateFilter
        '
        Me.cbIsDateFilter.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cbIsDateFilter.AutoSize = True
        Me.cbIsDateFilter.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbIsDateFilter.Location = New System.Drawing.Point(60, 50)
        Me.cbIsDateFilter.Name = "cbIsDateFilter"
        Me.cbIsDateFilter.Size = New System.Drawing.Size(67, 20)
        Me.cbIsDateFilter.TabIndex = 11
        Me.cbIsDateFilter.Text = "期間:"
        Me.cbIsDateFilter.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 6000
        '
        'DataSelect
        '
        Me.DataSelect.HeaderText = "刪除選取"
        Me.DataSelect.Name = "DataSelect"
        '
        'CIW15DataGridViewTextBoxColumn1
        '
        Me.CIW15DataGridViewTextBoxColumn1.DataPropertyName = "CIW15"
        Me.CIW15DataGridViewTextBoxColumn1.HeaderText = "順序"
        Me.CIW15DataGridViewTextBoxColumn1.Name = "CIW15DataGridViewTextBoxColumn1"
        Me.CIW15DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'CIW12DataGridViewTextBoxColumn1
        '
        Me.CIW12DataGridViewTextBoxColumn1.DataPropertyName = "CIW12"
        Me.CIW12DataGridViewTextBoxColumn1.HeaderText = "數量"
        Me.CIW12DataGridViewTextBoxColumn1.Name = "CIW12DataGridViewTextBoxColumn1"
        Me.CIW12DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'CIW05DataGridViewTextBoxColumn1
        '
        Me.CIW05DataGridViewTextBoxColumn1.DataPropertyName = "CIW05"
        Me.CIW05DataGridViewTextBoxColumn1.HeaderText = "厚度"
        Me.CIW05DataGridViewTextBoxColumn1.Name = "CIW05DataGridViewTextBoxColumn1"
        Me.CIW05DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'CIW0ADataGridViewTextBoxColumn1
        '
        Me.CIW0ADataGridViewTextBoxColumn1.DataPropertyName = "CIW0A"
        Me.CIW0ADataGridViewTextBoxColumn1.HeaderText = "線別"
        Me.CIW0ADataGridViewTextBoxColumn1.Name = "CIW0ADataGridViewTextBoxColumn1"
        Me.CIW0ADataGridViewTextBoxColumn1.ReadOnly = True
        '
        'CIW03DataGridViewTextBoxColumn1
        '
        Me.CIW03DataGridViewTextBoxColumn1.DataPropertyName = "CIW03"
        Me.CIW03DataGridViewTextBoxColumn1.HeaderText = "鋼種"
        Me.CIW03DataGridViewTextBoxColumn1.Name = "CIW03DataGridViewTextBoxColumn1"
        Me.CIW03DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'CIW04DataGridViewTextBoxColumn1
        '
        Me.CIW04DataGridViewTextBoxColumn1.DataPropertyName = "CIW04"
        Me.CIW04DataGridViewTextBoxColumn1.HeaderText = "Type"
        Me.CIW04DataGridViewTextBoxColumn1.Name = "CIW04DataGridViewTextBoxColumn1"
        Me.CIW04DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'CIW06DescriptDataGridViewTextBoxColumn
        '
        Me.CIW06DescriptDataGridViewTextBoxColumn.DataPropertyName = "CIW06Descript"
        Me.CIW06DescriptDataGridViewTextBoxColumn.HeaderText = "說明"
        Me.CIW06DescriptDataGridViewTextBoxColumn.Name = "CIW06DescriptDataGridViewTextBoxColumn"
        Me.CIW06DescriptDataGridViewTextBoxColumn.ReadOnly = True
        '
        'bsPlanProductionDisplay
        '
        Me.bsPlanProductionDisplay.DataSource = GetType(CompanyORMDB.SQLServer.PPS100LB.PlanProductionDisplay)
        '
        'RunStationPCIPDataGridViewTextBoxColumn
        '
        Me.RunStationPCIPDataGridViewTextBoxColumn.DataPropertyName = "RunStationPCIP"
        Me.RunStationPCIPDataGridViewTextBoxColumn.HeaderText = "處理站台IP"
        Me.RunStationPCIPDataGridViewTextBoxColumn.Name = "RunStationPCIPDataGridViewTextBoxColumn"
        Me.RunStationPCIPDataGridViewTextBoxColumn.ReadOnly = True
        '
        'RunCoilFullNumberDataGridViewTextBoxColumn
        '
        Me.RunCoilFullNumberDataGridViewTextBoxColumn.DataPropertyName = "RunCoilFullNumber"
        Me.RunCoilFullNumberDataGridViewTextBoxColumn.HeaderText = "鋼捲號碼"
        Me.RunCoilFullNumberDataGridViewTextBoxColumn.Name = "RunCoilFullNumberDataGridViewTextBoxColumn"
        Me.RunCoilFullNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'RunStationNameDataGridViewTextBoxColumn
        '
        Me.RunStationNameDataGridViewTextBoxColumn.DataPropertyName = "RunStationName"
        Me.RunStationNameDataGridViewTextBoxColumn.HeaderText = "處理站台名稱"
        Me.RunStationNameDataGridViewTextBoxColumn.Name = "RunStationNameDataGridViewTextBoxColumn"
        Me.RunStationNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AS400TimeDataGridViewTextBoxColumn
        '
        Me.AS400TimeDataGridViewTextBoxColumn.DataPropertyName = "AS400Time"
        Me.AS400TimeDataGridViewTextBoxColumn.HeaderText = "AS400時間"
        Me.AS400TimeDataGridViewTextBoxColumn.Name = "AS400TimeDataGridViewTextBoxColumn"
        Me.AS400TimeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NextRunStationNameDataGridViewTextBoxColumn
        '
        Me.NextRunStationNameDataGridViewTextBoxColumn.DataPropertyName = "NextRunStationName"
        Me.NextRunStationNameDataGridViewTextBoxColumn.HeaderText = "處理後下一站名稱"
        Me.NextRunStationNameDataGridViewTextBoxColumn.Name = "NextRunStationNameDataGridViewTextBoxColumn"
        Me.NextRunStationNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'bsCoilMoveState
        '
        Me.bsCoilMoveState.DataSource = GetType(CompanyORMDB.SQLServer.PPS100LB.CoilMoveState)
        '
        'CoilMoveStationEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "CoilMoveStationEdit"
        Me.Size = New System.Drawing.Size(619, 569)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tpPMNewsMode.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpSearchEditMode.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel3.ResumeLayout(False)
        CType(Me.bsPlanProductionDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsCoilMoveState, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpPMNewsMode As System.Windows.Forms.TabPage
    Friend WithEvents tpSearchEditMode As System.Windows.Forms.TabPage
    Friend WithEvents tbFilterCoilNumbers As System.Windows.Forms.TextBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents bsCoilMoveState As System.Windows.Forms.BindingSource
    Friend WithEvents FlowLayoutPanel3 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents tbDelete As System.Windows.Forms.Button
    Friend WithEvents WebServerTimeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbIsDateFilter As System.Windows.Forms.CheckBox
    Friend WithEvents AfterRunCoilFullNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents bsPlanProductionDisplay As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents CIW15DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DisplayWidth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CIW12DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CIW05DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CIW0ADataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CIW03DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CIW04DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CIW06DescriptDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataSelect As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents RunStationPCIPDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RunCoilFullNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RunStationNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AS400TimeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NextRunStationNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
