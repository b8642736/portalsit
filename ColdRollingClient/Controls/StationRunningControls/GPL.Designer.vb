<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GPL
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
        Me.bsDataSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tbPaperFixLength = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.bsSelectTable1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ColdRollingClientDataSet = New ColdRollingClient.ColdRollingClientDataSet()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cbPaperPLSelect = New System.Windows.Forms.ComboBox()
        Me.bsSelectTable0 = New System.Windows.Forms.BindingSource(Me.components)
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.bsSelectTable3 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.bsSelectTable2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.PSpecialOrderControl = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbCheckAllDataCorrect = New System.Windows.Forms.CheckBox()
        Me.tCheckData = New System.Windows.Forms.Timer(Me.components)
        CType(Me.bsDataSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.bsSelectTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ColdRollingClientDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsSelectTable0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsSelectTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsSelectTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bsDataSource
        '
        Me.bsDataSource.DataSource = GetType(CompanyORMDB.SQLServer.PPS100LB.RunProcessData)
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PSpecialOrderControl, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbCheckAllDataCorrect, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.54546!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.45454!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(539, 366)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 8
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 6)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox4, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label13, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.tbPaperFixLength, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label12, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox2, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label10, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ComboBox1, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label11, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label21, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cbPaperPLSelect, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox9, 7, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label19, 6, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox8, 5, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label18, 4, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox7, 3, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label17, 2, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label22, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.ComboBox4, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label14, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.ComboBox2, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label15, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox5, 3, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label16, 4, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox6, 5, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label23, 6, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox3, 7, 2)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 33)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(533, 94)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'TextBox4
        '
        Me.TextBox4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC14", True))
        Me.TextBox4.Location = New System.Drawing.Point(69, 26)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(56, 22)
        Me.TextBox4.TabIndex = 25
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 28)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 12)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "襯紙基重:"
        '
        'tbPaperFixLength
        '
        Me.tbPaperFixLength.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tbPaperFixLength.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC12", True))
        Me.tbPaperFixLength.Location = New System.Drawing.Point(465, 3)
        Me.tbPaperFixLength.Name = "tbPaperFixLength"
        Me.tbPaperFixLength.Size = New System.Drawing.Size(62, 22)
        Me.tbPaperFixLength.TabIndex = 24
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(403, 5)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 12)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "襯紙定長:"
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC13", True))
        Me.TextBox2.Location = New System.Drawing.Point(333, 3)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(56, 22)
        Me.TextBox2.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(283, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 12)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "襯紙寬:"
        '
        'ComboBox1
        '
        Me.ComboBox1.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.bsDataSource, "CIC15", True))
        Me.ComboBox1.DataSource = Me.bsSelectTable1
        Me.ComboBox1.DisplayMember = "厚薄"
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(201, 3)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(56, 20)
        Me.ComboBox1.TabIndex = 31
        Me.ComboBox1.ValueMember = "值"
        '
        'bsSelectTable1
        '
        Me.bsSelectTable1.DataMember = "PackageSelectTable1"
        Me.bsSelectTable1.DataSource = Me.ColdRollingClientDataSet
        '
        'ColdRollingClientDataSet
        '
        Me.ColdRollingClientDataSet.DataSetName = "ColdRollingClientDataSet"
        Me.ColdRollingClientDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(139, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 12)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "襯紙厚薄:"
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(10, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(53, 23)
        Me.Label21.TabIndex = 33
        Me.Label21.Text = "襯紙夾整捲:"
        '
        'cbPaperPLSelect
        '
        Me.cbPaperPLSelect.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.bsDataSource, "CIC11", True))
        Me.cbPaperPLSelect.DataSource = Me.bsSelectTable0
        Me.cbPaperPLSelect.DisplayMember = "襯紙夾整捲"
        Me.cbPaperPLSelect.FormattingEnabled = True
        Me.cbPaperPLSelect.Location = New System.Drawing.Point(69, 3)
        Me.cbPaperPLSelect.Name = "cbPaperPLSelect"
        Me.cbPaperPLSelect.Size = New System.Drawing.Size(56, 20)
        Me.cbPaperPLSelect.TabIndex = 34
        Me.cbPaperPLSelect.ValueMember = "值"
        '
        'bsSelectTable0
        '
        Me.bsSelectTable0.DataMember = "PackageSelectTable0"
        Me.bsSelectTable0.DataSource = Me.ColdRollingClientDataSet
        '
        'TextBox9
        '
        Me.TextBox9.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox9.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC34", True))
        Me.TextBox9.Location = New System.Drawing.Point(465, 72)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(62, 22)
        Me.TextBox9.TabIndex = 30
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(406, 69)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(53, 24)
        Me.Label19.TabIndex = 22
        Me.Label19.Text = "奇力龍基重:"
        '
        'TextBox8
        '
        Me.TextBox8.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox8.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC32", True))
        Me.TextBox8.Location = New System.Drawing.Point(333, 72)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(56, 22)
        Me.TextBox8.TabIndex = 29
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(271, 75)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 12)
        Me.Label18.TabIndex = 21
        Me.Label18.Text = "奇力龍長:"
        '
        'TextBox7
        '
        Me.TextBox7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox7.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC33", True))
        Me.TextBox7.Location = New System.Drawing.Point(201, 72)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(56, 22)
        Me.TextBox7.TabIndex = 28
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(139, 75)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 12)
        Me.Label17.TabIndex = 20
        Me.Label17.Text = "奇力龍寬:"
        '
        'Label22
        '
        Me.Label22.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(10, 69)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(53, 24)
        Me.Label22.TabIndex = 35
        Me.Label22.Text = "奇力龍整捲:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboBox4
        '
        Me.ComboBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox4.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.bsDataSource, "CIC31", True))
        Me.ComboBox4.DataSource = Me.bsSelectTable3
        Me.ComboBox4.DisplayMember = "是否奇力龍包整捲"
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(69, 72)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(60, 20)
        Me.ComboBox4.TabIndex = 36
        Me.ComboBox4.ValueMember = "值"
        '
        'bsSelectTable3
        '
        Me.bsSelectTable3.DataMember = "PackageSelectTable3"
        Me.bsSelectTable3.DataSource = Me.ColdRollingClientDataSet
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 51)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 12)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "是否套筒:"
        '
        'ComboBox2
        '
        Me.ComboBox2.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.bsDataSource, "CIC21", True))
        Me.ComboBox2.DataSource = Me.bsSelectTable2
        Me.ComboBox2.DisplayMember = "是否使用紙套筒"
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(69, 49)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(56, 20)
        Me.ComboBox2.TabIndex = 32
        Me.ComboBox2.ValueMember = "值"
        '
        'bsSelectTable2
        '
        Me.bsSelectTable2.DataMember = "PackageSelectTable2"
        Me.bsSelectTable2.DataSource = Me.ColdRollingClientDataSet
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(139, 51)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 12)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "套筒外徑:"
        '
        'TextBox5
        '
        Me.TextBox5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC22", True))
        Me.TextBox5.Location = New System.Drawing.Point(201, 49)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(56, 22)
        Me.TextBox5.TabIndex = 26
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(271, 51)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 12)
        Me.Label16.TabIndex = 19
        Me.Label16.Text = "套筒內徑:"
        '
        'TextBox6
        '
        Me.TextBox6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC23", True))
        Me.TextBox6.Location = New System.Drawing.Point(333, 49)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(56, 22)
        Me.TextBox6.TabIndex = 27
        '
        'Label23
        '
        Me.Label23.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(415, 51)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(44, 12)
        Me.Label23.TabIndex = 37
        Me.Label23.Text = "套筒重:"
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC24", True))
        Me.TextBox3.Location = New System.Drawing.Point(465, 49)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(65, 22)
        Me.TextBox3.TabIndex = 38
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "PASS 數:"
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "RunPassCont", True))
        Me.TextBox1.Location = New System.Drawing.Point(92, 4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(83, 22)
        Me.TextBox1.TabIndex = 4
        '
        'PSpecialOrderControl
        '
        Me.PSpecialOrderControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.PSpecialOrderControl, 6)
        Me.PSpecialOrderControl.Location = New System.Drawing.Point(3, 133)
        Me.PSpecialOrderControl.Name = "PSpecialOrderControl"
        Me.PSpecialOrderControl.Size = New System.Drawing.Size(533, 122)
        Me.PSpecialOrderControl.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(184, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 12)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "確認輸入資料:"
        '
        'cbCheckAllDataCorrect
        '
        Me.cbCheckAllDataCorrect.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbCheckAllDataCorrect.AutoSize = True
        Me.cbCheckAllDataCorrect.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.bsDataSource, "IsUserRunningDataChecked", True))
        Me.cbCheckAllDataCorrect.Location = New System.Drawing.Point(270, 7)
        Me.cbCheckAllDataCorrect.Name = "cbCheckAllDataCorrect"
        Me.cbCheckAllDataCorrect.Size = New System.Drawing.Size(72, 16)
        Me.cbCheckAllDataCorrect.TabIndex = 7
        Me.cbCheckAllDataCorrect.Text = "確認無誤"
        Me.cbCheckAllDataCorrect.UseVisualStyleBackColor = True
        '
        'tCheckData
        '
        Me.tCheckData.Enabled = True
        Me.tCheckData.Interval = 500
        '
        'GPL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "GPL"
        Me.Size = New System.Drawing.Size(539, 366)
        CType(Me.bsDataSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.bsSelectTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ColdRollingClientDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsSelectTable0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsSelectTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsSelectTable2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bsDataSource As System.Windows.Forms.BindingSource
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents bsSelectTable1 As System.Windows.Forms.BindingSource
    Friend WithEvents ColdRollingClientDataSet As ColdRollingClient.ColdRollingClientDataSet
    Friend WithEvents bsSelectTable3 As System.Windows.Forms.BindingSource
    Friend WithEvents bsSelectTable2 As System.Windows.Forms.BindingSource
    Friend WithEvents bsSelectTable0 As System.Windows.Forms.BindingSource
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tbPaperFixLength As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cbPaperPLSelect As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents PSpecialOrderControl As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbCheckAllDataCorrect As System.Windows.Forms.CheckBox
    Friend WithEvents tCheckData As System.Windows.Forms.Timer

End Class
