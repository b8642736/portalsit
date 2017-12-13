<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WeightPair
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
        Me.dgvProductsDisplay = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbDopantWeight = New System.Windows.Forms.TextBox()
        Me.btnCompare = New System.Windows.Forms.Button()
        Me.btnDeleteCompare = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbContractNumber = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbProductNumber = New System.Windows.Forms.TextBox()
        Me.btnSearchContract = New System.Windows.Forms.Button()
        Me.dgvContractDisplay = New System.Windows.Forms.DataGridView()
        Me.UnArriveWeight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnReSearch = New System.Windows.Forms.Button()
        Me.dgvWeightDisplay = New System.Windows.Forms.DataGridView()
        Me.IsCompareTOContractDetail = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.WF_form_No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tRefreshWeightData = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.bsInProducts = New System.Windows.Forms.BindingSource(Me.components)
        Me.WRB201DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WRB202DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WRB203DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WRB204DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WRB205DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WRB206DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WRB207DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WRB208DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WRB209DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WRB2URDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsContractDataSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.WFNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WFmonthNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WFstarttimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WFcompletetimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WFCompanyNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WFCarIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WFfirstWeightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WFTatolWeightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WFEmptyWeightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WFDeadWeightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WFFormtypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsWeightDataSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.WRB316DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WRB301DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WRB302DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WRB303DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WRB304DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WRB305DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WRB306DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WRB307DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WRB308DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WRB310DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WRB314DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WRB315DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WRB3URDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WRB3TMDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvProductsDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.dgvContractDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.dgvWeightDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.bsInProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsContractDataSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsWeightDataSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.dgvProductsDisplay, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 0, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(14, 13)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1079, 726)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'dgvProductsDisplay
        '
        Me.dgvProductsDisplay.AllowUserToAddRows = False
        Me.dgvProductsDisplay.AllowUserToDeleteRows = False
        Me.dgvProductsDisplay.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProductsDisplay.AutoGenerateColumns = False
        Me.dgvProductsDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductsDisplay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.WRB316DataGridViewTextBoxColumn, Me.WRB301DataGridViewTextBoxColumn, Me.WRB302DataGridViewTextBoxColumn, Me.WRB303DataGridViewTextBoxColumn, Me.WRB304DataGridViewTextBoxColumn, Me.WRB305DataGridViewTextBoxColumn, Me.WRB306DataGridViewTextBoxColumn, Me.WRB307DataGridViewTextBoxColumn, Me.WRB308DataGridViewTextBoxColumn, Me.WRB310DataGridViewTextBoxColumn, Me.WRB314DataGridViewTextBoxColumn, Me.WRB315DataGridViewTextBoxColumn, Me.WRB3URDataGridViewTextBoxColumn, Me.WRB3TMDataGridViewTextBoxColumn})
        Me.dgvProductsDisplay.DataSource = Me.bsInProducts
        Me.dgvProductsDisplay.Location = New System.Drawing.Point(617, 33)
        Me.dgvProductsDisplay.Name = "dgvProductsDisplay"
        Me.dgvProductsDisplay.ReadOnly = True
        Me.TableLayoutPanel1.SetRowSpan(Me.dgvProductsDisplay, 3)
        Me.dgvProductsDisplay.RowTemplate.Height = 24
        Me.dgvProductsDisplay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProductsDisplay.Size = New System.Drawing.Size(459, 690)
        Me.dgvProductsDisplay.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(467, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 12)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "配對納入明細  =>"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(617, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(459, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "進料明細編修"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(458, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "過磅資料"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.11111!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.88889!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.tbDopantWeight, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnCompare, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.btnDeleteCompare, 0, 2)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(467, 33)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 5
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(144, 327)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 12)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "雜物重:"
        '
        'tbDopantWeight
        '
        Me.tbDopantWeight.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDopantWeight.Location = New System.Drawing.Point(54, 9)
        Me.tbDopantWeight.Name = "tbDopantWeight"
        Me.tbDopantWeight.Size = New System.Drawing.Size(87, 22)
        Me.tbDopantWeight.TabIndex = 1
        '
        'btnCompare
        '
        Me.btnCompare.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCompare.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TableLayoutPanel2.SetColumnSpan(Me.btnCompare, 2)
        Me.btnCompare.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCompare.Location = New System.Drawing.Point(3, 43)
        Me.btnCompare.Name = "btnCompare"
        Me.btnCompare.Size = New System.Drawing.Size(138, 34)
        Me.btnCompare.TabIndex = 2
        Me.btnCompare.Text = "配對加入進料明細   =>"
        Me.btnCompare.UseVisualStyleBackColor = False
        '
        'btnDeleteCompare
        '
        Me.btnDeleteCompare.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteCompare.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TableLayoutPanel2.SetColumnSpan(Me.btnDeleteCompare, 2)
        Me.btnDeleteCompare.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDeleteCompare.Location = New System.Drawing.Point(3, 83)
        Me.btnDeleteCompare.Name = "btnDeleteCompare"
        Me.btnDeleteCompare.Size = New System.Drawing.Size(138, 34)
        Me.btnDeleteCompare.TabIndex = 3
        Me.btnDeleteCompare.Text = "<=   刪除進料明細"
        Me.btnDeleteCompare.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 372)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(458, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "合約規劃進料"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.ColumnCount = 5
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label6, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.tbContractNumber, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label7, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.tbProductNumber, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnSearchContract, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.dgvContractDisplay, 0, 1)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 396)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(458, 327)
        Me.TableLayoutPanel3.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(32, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 12)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "合約案號:"
        '
        'tbContractNumber
        '
        Me.tbContractNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbContractNumber.Location = New System.Drawing.Point(94, 4)
        Me.tbContractNumber.Name = "tbContractNumber"
        Me.tbContractNumber.Size = New System.Drawing.Size(85, 22)
        Me.tbContractNumber.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(214, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 12)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "物料編號:"
        '
        'tbProductNumber
        '
        Me.tbProductNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbProductNumber.Location = New System.Drawing.Point(276, 4)
        Me.tbProductNumber.Name = "tbProductNumber"
        Me.tbProductNumber.Size = New System.Drawing.Size(85, 22)
        Me.tbProductNumber.TabIndex = 6
        '
        'btnSearchContract
        '
        Me.btnSearchContract.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearchContract.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSearchContract.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearchContract.Location = New System.Drawing.Point(367, 3)
        Me.btnSearchContract.Name = "btnSearchContract"
        Me.btnSearchContract.Size = New System.Drawing.Size(88, 24)
        Me.btnSearchContract.TabIndex = 4
        Me.btnSearchContract.Text = "搜尋合約"
        Me.btnSearchContract.UseVisualStyleBackColor = False
        '
        'dgvContractDisplay
        '
        Me.dgvContractDisplay.AllowUserToAddRows = False
        Me.dgvContractDisplay.AllowUserToDeleteRows = False
        Me.dgvContractDisplay.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvContractDisplay.AutoGenerateColumns = False
        Me.dgvContractDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvContractDisplay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.WRB201DataGridViewTextBoxColumn, Me.WRB202DataGridViewTextBoxColumn, Me.WRB203DataGridViewTextBoxColumn, Me.WRB204DataGridViewTextBoxColumn, Me.WRB205DataGridViewTextBoxColumn, Me.WRB206DataGridViewTextBoxColumn, Me.UnArriveWeight, Me.WRB207DataGridViewTextBoxColumn, Me.WRB208DataGridViewTextBoxColumn, Me.WRB209DataGridViewTextBoxColumn, Me.WRB2URDataGridViewTextBoxColumn})
        Me.TableLayoutPanel3.SetColumnSpan(Me.dgvContractDisplay, 5)
        Me.dgvContractDisplay.DataSource = Me.bsContractDataSource
        Me.dgvContractDisplay.Location = New System.Drawing.Point(3, 33)
        Me.dgvContractDisplay.Name = "dgvContractDisplay"
        Me.dgvContractDisplay.ReadOnly = True
        Me.dgvContractDisplay.RowTemplate.Height = 24
        Me.dgvContractDisplay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvContractDisplay.Size = New System.Drawing.Size(452, 291)
        Me.dgvContractDisplay.TabIndex = 7
        '
        'UnArriveWeight
        '
        Me.UnArriveWeight.DataPropertyName = "UnArriveWeight"
        Me.UnArriveWeight.HeaderText = "未進料重量"
        Me.UnArriveWeight.Name = "UnArriveWeight"
        Me.UnArriveWeight.ReadOnly = True
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.btnReSearch, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.dgvWeightDisplay, 0, 1)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 33)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(458, 327)
        Me.TableLayoutPanel4.TabIndex = 8
        '
        'btnReSearch
        '
        Me.btnReSearch.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnReSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReSearch.Location = New System.Drawing.Point(3, 3)
        Me.btnReSearch.Name = "btnReSearch"
        Me.btnReSearch.Size = New System.Drawing.Size(452, 24)
        Me.btnReSearch.TabIndex = 6
        Me.btnReSearch.Text = "重整顯示"
        Me.btnReSearch.UseVisualStyleBackColor = False
        '
        'dgvWeightDisplay
        '
        Me.dgvWeightDisplay.AllowUserToAddRows = False
        Me.dgvWeightDisplay.AllowUserToDeleteRows = False
        Me.dgvWeightDisplay.AutoGenerateColumns = False
        Me.dgvWeightDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWeightDisplay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.WFNoDataGridViewTextBoxColumn, Me.WFmonthNoDataGridViewTextBoxColumn, Me.IsCompareTOContractDetail, Me.WF_form_No, Me.WFstarttimeDataGridViewTextBoxColumn, Me.WFcompletetimeDataGridViewTextBoxColumn, Me.WFCompanyNameDataGridViewTextBoxColumn, Me.WFCarIDDataGridViewTextBoxColumn, Me.WFfirstWeightDataGridViewTextBoxColumn, Me.WFTatolWeightDataGridViewTextBoxColumn, Me.WFEmptyWeightDataGridViewTextBoxColumn, Me.WFDeadWeightDataGridViewTextBoxColumn, Me.WFFormtypeDataGridViewTextBoxColumn})
        Me.dgvWeightDisplay.DataSource = Me.bsWeightDataSource
        Me.dgvWeightDisplay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvWeightDisplay.Location = New System.Drawing.Point(3, 33)
        Me.dgvWeightDisplay.Name = "dgvWeightDisplay"
        Me.dgvWeightDisplay.ReadOnly = True
        Me.dgvWeightDisplay.RowTemplate.Height = 24
        Me.dgvWeightDisplay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvWeightDisplay.Size = New System.Drawing.Size(452, 291)
        Me.dgvWeightDisplay.TabIndex = 5
        '
        'IsCompareTOContractDetail
        '
        Me.IsCompareTOContractDetail.DataPropertyName = "IsCompareTOContractDetail"
        Me.IsCompareTOContractDetail.HeaderText = "是否配置合約"
        Me.IsCompareTOContractDetail.Name = "IsCompareTOContractDetail"
        Me.IsCompareTOContractDetail.ReadOnly = True
        '
        'WF_form_No
        '
        Me.WF_form_No.DataPropertyName = "WF_form_No"
        Me.WF_form_No.HeaderText = "車次"
        Me.WF_form_No.Name = "WF_form_No"
        Me.WF_form_No.ReadOnly = True
        '
        'tRefreshWeightData
        '
        Me.tRefreshWeightData.Enabled = True
        Me.tRefreshWeightData.Interval = 3000
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tsslMessage})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 732)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1108, 22)
        Me.StatusStrip1.TabIndex = 1
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
        'bsInProducts
        '
        Me.bsInProducts.DataSource = GetType(CompanyORMDB.MTS100LB.WARB03PF)
        '
        'WRB201DataGridViewTextBoxColumn
        '
        Me.WRB201DataGridViewTextBoxColumn.DataPropertyName = "WRB201"
        Me.WRB201DataGridViewTextBoxColumn.HeaderText = "合約案號"
        Me.WRB201DataGridViewTextBoxColumn.Name = "WRB201DataGridViewTextBoxColumn"
        Me.WRB201DataGridViewTextBoxColumn.ReadOnly = True
        '
        'WRB202DataGridViewTextBoxColumn
        '
        Me.WRB202DataGridViewTextBoxColumn.DataPropertyName = "WRB202"
        Me.WRB202DataGridViewTextBoxColumn.HeaderText = "料號"
        Me.WRB202DataGridViewTextBoxColumn.Name = "WRB202DataGridViewTextBoxColumn"
        Me.WRB202DataGridViewTextBoxColumn.ReadOnly = True
        '
        'WRB203DataGridViewTextBoxColumn
        '
        Me.WRB203DataGridViewTextBoxColumn.DataPropertyName = "WRB203"
        Me.WRB203DataGridViewTextBoxColumn.HeaderText = "合約數量"
        Me.WRB203DataGridViewTextBoxColumn.Name = "WRB203DataGridViewTextBoxColumn"
        Me.WRB203DataGridViewTextBoxColumn.ReadOnly = True
        '
        'WRB204DataGridViewTextBoxColumn
        '
        Me.WRB204DataGridViewTextBoxColumn.DataPropertyName = "WRB204"
        Me.WRB204DataGridViewTextBoxColumn.HeaderText = "進料起日"
        Me.WRB204DataGridViewTextBoxColumn.Name = "WRB204DataGridViewTextBoxColumn"
        Me.WRB204DataGridViewTextBoxColumn.ReadOnly = True
        '
        'WRB205DataGridViewTextBoxColumn
        '
        Me.WRB205DataGridViewTextBoxColumn.DataPropertyName = "WRB205"
        Me.WRB205DataGridViewTextBoxColumn.HeaderText = "進料訖日"
        Me.WRB205DataGridViewTextBoxColumn.Name = "WRB205DataGridViewTextBoxColumn"
        Me.WRB205DataGridViewTextBoxColumn.ReadOnly = True
        '
        'WRB206DataGridViewTextBoxColumn
        '
        Me.WRB206DataGridViewTextBoxColumn.DataPropertyName = "WRB206"
        Me.WRB206DataGridViewTextBoxColumn.HeaderText = "安排單位"
        Me.WRB206DataGridViewTextBoxColumn.Name = "WRB206DataGridViewTextBoxColumn"
        Me.WRB206DataGridViewTextBoxColumn.ReadOnly = True
        '
        'WRB207DataGridViewTextBoxColumn
        '
        Me.WRB207DataGridViewTextBoxColumn.DataPropertyName = "WRB207"
        Me.WRB207DataGridViewTextBoxColumn.HeaderText = "WRB207"
        Me.WRB207DataGridViewTextBoxColumn.Name = "WRB207DataGridViewTextBoxColumn"
        Me.WRB207DataGridViewTextBoxColumn.ReadOnly = True
        Me.WRB207DataGridViewTextBoxColumn.Visible = False
        '
        'WRB208DataGridViewTextBoxColumn
        '
        Me.WRB208DataGridViewTextBoxColumn.DataPropertyName = "WRB208"
        Me.WRB208DataGridViewTextBoxColumn.HeaderText = "WRB208"
        Me.WRB208DataGridViewTextBoxColumn.Name = "WRB208DataGridViewTextBoxColumn"
        Me.WRB208DataGridViewTextBoxColumn.ReadOnly = True
        Me.WRB208DataGridViewTextBoxColumn.Visible = False
        '
        'WRB209DataGridViewTextBoxColumn
        '
        Me.WRB209DataGridViewTextBoxColumn.DataPropertyName = "WRB209"
        Me.WRB209DataGridViewTextBoxColumn.HeaderText = "WRB209"
        Me.WRB209DataGridViewTextBoxColumn.Name = "WRB209DataGridViewTextBoxColumn"
        Me.WRB209DataGridViewTextBoxColumn.ReadOnly = True
        Me.WRB209DataGridViewTextBoxColumn.Visible = False
        '
        'WRB2URDataGridViewTextBoxColumn
        '
        Me.WRB2URDataGridViewTextBoxColumn.DataPropertyName = "WRB2UR"
        Me.WRB2URDataGridViewTextBoxColumn.HeaderText = "WRB2UR"
        Me.WRB2URDataGridViewTextBoxColumn.Name = "WRB2URDataGridViewTextBoxColumn"
        Me.WRB2URDataGridViewTextBoxColumn.ReadOnly = True
        Me.WRB2URDataGridViewTextBoxColumn.Visible = False
        '
        'bsContractDataSource
        '
        Me.bsContractDataSource.DataSource = GetType(CompanyORMDB.MTS100LB.WARB02PF)
        '
        'WFNoDataGridViewTextBoxColumn
        '
        Me.WFNoDataGridViewTextBoxColumn.DataPropertyName = "WF_No"
        Me.WFNoDataGridViewTextBoxColumn.HeaderText = "WF_No"
        Me.WFNoDataGridViewTextBoxColumn.Name = "WFNoDataGridViewTextBoxColumn"
        Me.WFNoDataGridViewTextBoxColumn.ReadOnly = True
        Me.WFNoDataGridViewTextBoxColumn.Visible = False
        '
        'WFmonthNoDataGridViewTextBoxColumn
        '
        Me.WFmonthNoDataGridViewTextBoxColumn.DataPropertyName = "WF_month_No"
        Me.WFmonthNoDataGridViewTextBoxColumn.HeaderText = "WF_month_No"
        Me.WFmonthNoDataGridViewTextBoxColumn.Name = "WFmonthNoDataGridViewTextBoxColumn"
        Me.WFmonthNoDataGridViewTextBoxColumn.ReadOnly = True
        Me.WFmonthNoDataGridViewTextBoxColumn.Visible = False
        '
        'WFstarttimeDataGridViewTextBoxColumn
        '
        Me.WFstarttimeDataGridViewTextBoxColumn.DataPropertyName = "WF_start_time"
        Me.WFstarttimeDataGridViewTextBoxColumn.HeaderText = "起始時間"
        Me.WFstarttimeDataGridViewTextBoxColumn.Name = "WFstarttimeDataGridViewTextBoxColumn"
        Me.WFstarttimeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'WFcompletetimeDataGridViewTextBoxColumn
        '
        Me.WFcompletetimeDataGridViewTextBoxColumn.DataPropertyName = "WF_complete_time"
        Me.WFcompletetimeDataGridViewTextBoxColumn.HeaderText = "結束時間"
        Me.WFcompletetimeDataGridViewTextBoxColumn.Name = "WFcompletetimeDataGridViewTextBoxColumn"
        Me.WFcompletetimeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'WFCompanyNameDataGridViewTextBoxColumn
        '
        Me.WFCompanyNameDataGridViewTextBoxColumn.DataPropertyName = "WF_Company_Name"
        Me.WFCompanyNameDataGridViewTextBoxColumn.HeaderText = "公司名稱"
        Me.WFCompanyNameDataGridViewTextBoxColumn.Name = "WFCompanyNameDataGridViewTextBoxColumn"
        Me.WFCompanyNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'WFCarIDDataGridViewTextBoxColumn
        '
        Me.WFCarIDDataGridViewTextBoxColumn.DataPropertyName = "WF_Car_ID"
        Me.WFCarIDDataGridViewTextBoxColumn.HeaderText = "車號"
        Me.WFCarIDDataGridViewTextBoxColumn.Name = "WFCarIDDataGridViewTextBoxColumn"
        Me.WFCarIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'WFfirstWeightDataGridViewTextBoxColumn
        '
        Me.WFfirstWeightDataGridViewTextBoxColumn.DataPropertyName = "WF_first_Weight"
        Me.WFfirstWeightDataGridViewTextBoxColumn.HeaderText = "WF_first_Weight"
        Me.WFfirstWeightDataGridViewTextBoxColumn.Name = "WFfirstWeightDataGridViewTextBoxColumn"
        Me.WFfirstWeightDataGridViewTextBoxColumn.ReadOnly = True
        Me.WFfirstWeightDataGridViewTextBoxColumn.Visible = False
        '
        'WFTatolWeightDataGridViewTextBoxColumn
        '
        Me.WFTatolWeightDataGridViewTextBoxColumn.DataPropertyName = "WF_Tatol_Weight"
        Me.WFTatolWeightDataGridViewTextBoxColumn.HeaderText = "總重"
        Me.WFTatolWeightDataGridViewTextBoxColumn.Name = "WFTatolWeightDataGridViewTextBoxColumn"
        Me.WFTatolWeightDataGridViewTextBoxColumn.ReadOnly = True
        '
        'WFEmptyWeightDataGridViewTextBoxColumn
        '
        Me.WFEmptyWeightDataGridViewTextBoxColumn.DataPropertyName = "WF_Empty_Weight"
        Me.WFEmptyWeightDataGridViewTextBoxColumn.HeaderText = "WF_Empty_Weight"
        Me.WFEmptyWeightDataGridViewTextBoxColumn.Name = "WFEmptyWeightDataGridViewTextBoxColumn"
        Me.WFEmptyWeightDataGridViewTextBoxColumn.ReadOnly = True
        Me.WFEmptyWeightDataGridViewTextBoxColumn.Visible = False
        '
        'WFDeadWeightDataGridViewTextBoxColumn
        '
        Me.WFDeadWeightDataGridViewTextBoxColumn.DataPropertyName = "WF_Dead_Weight"
        Me.WFDeadWeightDataGridViewTextBoxColumn.HeaderText = "淨重"
        Me.WFDeadWeightDataGridViewTextBoxColumn.Name = "WFDeadWeightDataGridViewTextBoxColumn"
        Me.WFDeadWeightDataGridViewTextBoxColumn.ReadOnly = True
        '
        'WFFormtypeDataGridViewTextBoxColumn
        '
        Me.WFFormtypeDataGridViewTextBoxColumn.DataPropertyName = "WF_Form_type"
        Me.WFFormtypeDataGridViewTextBoxColumn.HeaderText = "進出庫"
        Me.WFFormtypeDataGridViewTextBoxColumn.Name = "WFFormtypeDataGridViewTextBoxColumn"
        Me.WFFormtypeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'bsWeightDataSource
        '
        Me.bsWeightDataSource.DataSource = GetType(WeightHousePairOrder.tbl_Weightbridge_form)
        '
        'WRB316DataGridViewTextBoxColumn
        '
        Me.WRB316DataGridViewTextBoxColumn.DataPropertyName = "WRB316"
        Me.WRB316DataGridViewTextBoxColumn.HeaderText = "登入碼"
        Me.WRB316DataGridViewTextBoxColumn.Name = "WRB316DataGridViewTextBoxColumn"
        Me.WRB316DataGridViewTextBoxColumn.ReadOnly = True
        Me.WRB316DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.WRB316DataGridViewTextBoxColumn.Width = 80
        '
        'WRB301DataGridViewTextBoxColumn
        '
        Me.WRB301DataGridViewTextBoxColumn.DataPropertyName = "WRB301"
        Me.WRB301DataGridViewTextBoxColumn.HeaderText = "進料日期"
        Me.WRB301DataGridViewTextBoxColumn.Name = "WRB301DataGridViewTextBoxColumn"
        Me.WRB301DataGridViewTextBoxColumn.ReadOnly = True
        '
        'WRB302DataGridViewTextBoxColumn
        '
        Me.WRB302DataGridViewTextBoxColumn.DataPropertyName = "WRB302"
        Me.WRB302DataGridViewTextBoxColumn.HeaderText = "物料編號"
        Me.WRB302DataGridViewTextBoxColumn.Name = "WRB302DataGridViewTextBoxColumn"
        Me.WRB302DataGridViewTextBoxColumn.ReadOnly = True
        '
        'WRB303DataGridViewTextBoxColumn
        '
        Me.WRB303DataGridViewTextBoxColumn.DataPropertyName = "WRB303"
        Me.WRB303DataGridViewTextBoxColumn.HeaderText = "合約案號"
        Me.WRB303DataGridViewTextBoxColumn.Name = "WRB303DataGridViewTextBoxColumn"
        Me.WRB303DataGridViewTextBoxColumn.ReadOnly = True
        '
        'WRB304DataGridViewTextBoxColumn
        '
        Me.WRB304DataGridViewTextBoxColumn.DataPropertyName = "WRB304"
        Me.WRB304DataGridViewTextBoxColumn.HeaderText = "車次"
        Me.WRB304DataGridViewTextBoxColumn.Name = "WRB304DataGridViewTextBoxColumn"
        Me.WRB304DataGridViewTextBoxColumn.ReadOnly = True
        '
        'WRB305DataGridViewTextBoxColumn
        '
        Me.WRB305DataGridViewTextBoxColumn.DataPropertyName = "WRB305"
        Me.WRB305DataGridViewTextBoxColumn.HeaderText = "跨單序號"
        Me.WRB305DataGridViewTextBoxColumn.Name = "WRB305DataGridViewTextBoxColumn"
        Me.WRB305DataGridViewTextBoxColumn.ReadOnly = True
        '
        'WRB306DataGridViewTextBoxColumn
        '
        Me.WRB306DataGridViewTextBoxColumn.DataPropertyName = "WRB306"
        Me.WRB306DataGridViewTextBoxColumn.HeaderText = "淨重"
        Me.WRB306DataGridViewTextBoxColumn.Name = "WRB306DataGridViewTextBoxColumn"
        Me.WRB306DataGridViewTextBoxColumn.ReadOnly = True
        '
        'WRB307DataGridViewTextBoxColumn
        '
        Me.WRB307DataGridViewTextBoxColumn.DataPropertyName = "WRB307"
        Me.WRB307DataGridViewTextBoxColumn.HeaderText = "雜物重"
        Me.WRB307DataGridViewTextBoxColumn.Name = "WRB307DataGridViewTextBoxColumn"
        Me.WRB307DataGridViewTextBoxColumn.ReadOnly = True
        '
        'WRB308DataGridViewTextBoxColumn
        '
        Me.WRB308DataGridViewTextBoxColumn.DataPropertyName = "WRB308"
        Me.WRB308DataGridViewTextBoxColumn.HeaderText = "WRB308"
        Me.WRB308DataGridViewTextBoxColumn.Name = "WRB308DataGridViewTextBoxColumn"
        Me.WRB308DataGridViewTextBoxColumn.ReadOnly = True
        Me.WRB308DataGridViewTextBoxColumn.Visible = False
        '
        'WRB310DataGridViewTextBoxColumn
        '
        Me.WRB310DataGridViewTextBoxColumn.DataPropertyName = "WRB310"
        Me.WRB310DataGridViewTextBoxColumn.HeaderText = "WRB310"
        Me.WRB310DataGridViewTextBoxColumn.Name = "WRB310DataGridViewTextBoxColumn"
        Me.WRB310DataGridViewTextBoxColumn.ReadOnly = True
        Me.WRB310DataGridViewTextBoxColumn.Visible = False
        '
        'WRB314DataGridViewTextBoxColumn
        '
        Me.WRB314DataGridViewTextBoxColumn.DataPropertyName = "WRB314"
        Me.WRB314DataGridViewTextBoxColumn.HeaderText = "WRB314"
        Me.WRB314DataGridViewTextBoxColumn.Name = "WRB314DataGridViewTextBoxColumn"
        Me.WRB314DataGridViewTextBoxColumn.ReadOnly = True
        Me.WRB314DataGridViewTextBoxColumn.Visible = False
        '
        'WRB315DataGridViewTextBoxColumn
        '
        Me.WRB315DataGridViewTextBoxColumn.DataPropertyName = "WRB315"
        Me.WRB315DataGridViewTextBoxColumn.HeaderText = "WRB315"
        Me.WRB315DataGridViewTextBoxColumn.Name = "WRB315DataGridViewTextBoxColumn"
        Me.WRB315DataGridViewTextBoxColumn.ReadOnly = True
        Me.WRB315DataGridViewTextBoxColumn.Visible = False
        '
        'WRB3URDataGridViewTextBoxColumn
        '
        Me.WRB3URDataGridViewTextBoxColumn.DataPropertyName = "WRB3UR"
        Me.WRB3URDataGridViewTextBoxColumn.HeaderText = "WRB3UR"
        Me.WRB3URDataGridViewTextBoxColumn.Name = "WRB3URDataGridViewTextBoxColumn"
        Me.WRB3URDataGridViewTextBoxColumn.ReadOnly = True
        Me.WRB3URDataGridViewTextBoxColumn.Visible = False
        '
        'WRB3TMDataGridViewTextBoxColumn
        '
        Me.WRB3TMDataGridViewTextBoxColumn.DataPropertyName = "WRB3TM"
        Me.WRB3TMDataGridViewTextBoxColumn.HeaderText = "WRB3TM"
        Me.WRB3TMDataGridViewTextBoxColumn.Name = "WRB3TMDataGridViewTextBoxColumn"
        Me.WRB3TMDataGridViewTextBoxColumn.ReadOnly = True
        Me.WRB3TMDataGridViewTextBoxColumn.Visible = False
        '
        'WeightPair
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "WeightPair"
        Me.Size = New System.Drawing.Size(1108, 754)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.dgvProductsDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.dgvContractDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel4.ResumeLayout(False)
        CType(Me.dgvWeightDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.bsInProducts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsContractDataSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsWeightDataSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbDopantWeight As System.Windows.Forms.TextBox
    Friend WithEvents btnCompare As System.Windows.Forms.Button
    Friend WithEvents btnDeleteCompare As System.Windows.Forms.Button
    Friend WithEvents dgvWeightDisplay As System.Windows.Forms.DataGridView
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnSearchContract As System.Windows.Forms.Button
    Friend WithEvents dgvProductsDisplay As System.Windows.Forms.DataGridView
    Friend WithEvents dgvContractDisplay As System.Windows.Forms.DataGridView
    Friend WithEvents tbContractNumber As System.Windows.Forms.TextBox
    Friend WithEvents tbProductNumber As System.Windows.Forms.TextBox
    Friend WithEvents bsWeightDataSource As System.Windows.Forms.BindingSource
    Friend WithEvents bsContractDataSource As System.Windows.Forms.BindingSource
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnReSearch As System.Windows.Forms.Button
    Friend WithEvents bsInProducts As System.Windows.Forms.BindingSource
    Friend WithEvents WRB201DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WRB202DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WRB203DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WRB204DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WRB205DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WRB206DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnArriveWeight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WRB207DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WRB208DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WRB209DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WRB2URDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tRefreshWeightData As System.Windows.Forms.Timer
    Friend WithEvents WFNoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WFmonthNoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsCompareTOContractDetail As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents WF_form_No As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WFstarttimeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WFcompletetimeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WFCompanyNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WFCarIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WFfirstWeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WFTatolWeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WFEmptyWeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WFDeadWeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WFFormtypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WRB316DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WRB301DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WRB302DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WRB303DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WRB304DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WRB305DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WRB306DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WRB307DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WRB308DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WRB310DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WRB314DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WRB315DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WRB3URDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WRB3TMDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
