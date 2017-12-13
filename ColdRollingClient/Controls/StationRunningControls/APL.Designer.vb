<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class APL
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
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.bsDataSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tbPaperFixLength = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.bsSelectTable1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ColdRollingClientDataSet = New ColdRollingClient.ColdRollingClientDataSet()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbPaperPLSelect = New System.Windows.Forms.ComboBox()
        Me.bsSelectTable0 = New System.Windows.Forms.BindingSource(Me.components)
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.ComboBox6 = New System.Windows.Forms.ComboBox()
        Me.bsSelectTable3 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ComboBox7 = New System.Windows.Forms.ComboBox()
        Me.bsSelectTable2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.cbWillSplitCoil = New System.Windows.Forms.CheckBox()
        Me.cbPaperPrint4Copies = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.PSpecialOrderControl = New System.Windows.Forms.Panel()
        Me.cbCheckAllDataCorrect = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tCheckData = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.bsDataSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsSelectTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ColdRollingClientDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsSelectTable0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsSelectTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsSelectTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 6
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel1, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.cbWillSplitCoil, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cbPaperPrint4Copies, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox2, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox3, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox4, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.PSpecialOrderControl, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.cbCheckAllDataCorrect, 5, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label8, 4, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 5
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(699, 307)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 8
        Me.TableLayoutPanel2.SetColumnSpan(Me.TableLayoutPanel1, 6)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label13, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbPaperFixLength, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox9, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBox4, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbPaperPLSelect, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox10, 7, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label14, 6, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox11, 5, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label15, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox12, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label16, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label22, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBox6, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label23, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBox7, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label24, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox13, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label25, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox14, 5, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label26, 6, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox15, 7, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 93)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(693, 94)
        Me.TableLayoutPanel1.TabIndex = 32
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC14", True))
        Me.TextBox1.Location = New System.Drawing.Point(89, 26)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(70, 22)
        Me.TextBox1.TabIndex = 25
        '
        'bsDataSource
        '
        Me.bsDataSource.DataSource = GetType(CompanyORMDB.SQLServer.PPS100LB.RunProcessData)
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(27, 28)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 12)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "襯紙基重:"
        '
        'tbPaperFixLength
        '
        Me.tbPaperFixLength.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tbPaperFixLength.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC12", True))
        Me.tbPaperFixLength.Location = New System.Drawing.Point(605, 3)
        Me.tbPaperFixLength.Name = "tbPaperFixLength"
        Me.tbPaperFixLength.Size = New System.Drawing.Size(70, 22)
        Me.tbPaperFixLength.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(543, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 12)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "襯紙定長:"
        '
        'TextBox9
        '
        Me.TextBox9.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox9.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC13", True))
        Me.TextBox9.Location = New System.Drawing.Point(433, 3)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(70, 22)
        Me.TextBox9.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(383, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 12)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "襯紙寬:"
        '
        'ComboBox4
        '
        Me.ComboBox4.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.bsDataSource, "CIC15", True))
        Me.ComboBox4.DataSource = Me.bsSelectTable1
        Me.ComboBox4.DisplayMember = "厚薄"
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(261, 3)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(70, 20)
        Me.ComboBox4.TabIndex = 31
        Me.ComboBox4.ValueMember = "值"
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
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(199, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 12)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "襯紙厚薄:"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 12)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "襯紙夾整捲:"
        '
        'cbPaperPLSelect
        '
        Me.cbPaperPLSelect.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.bsDataSource, "CIC11", True))
        Me.cbPaperPLSelect.DataSource = Me.bsSelectTable0
        Me.cbPaperPLSelect.DisplayMember = "襯紙夾整捲"
        Me.cbPaperPLSelect.FormattingEnabled = True
        Me.cbPaperPLSelect.Location = New System.Drawing.Point(89, 3)
        Me.cbPaperPLSelect.Name = "cbPaperPLSelect"
        Me.cbPaperPLSelect.Size = New System.Drawing.Size(70, 20)
        Me.cbPaperPLSelect.TabIndex = 34
        Me.cbPaperPLSelect.ValueMember = "值"
        '
        'bsSelectTable0
        '
        Me.bsSelectTable0.DataMember = "PackageSelectTable0"
        Me.bsSelectTable0.DataSource = Me.ColdRollingClientDataSet
        '
        'TextBox10
        '
        Me.TextBox10.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox10.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC34", True))
        Me.TextBox10.Location = New System.Drawing.Point(605, 72)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(70, 22)
        Me.TextBox10.TabIndex = 30
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(531, 75)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(68, 12)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "奇力龍基重:"
        '
        'TextBox11
        '
        Me.TextBox11.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox11.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC32", True))
        Me.TextBox11.Location = New System.Drawing.Point(433, 72)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(70, 22)
        Me.TextBox11.TabIndex = 29
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(371, 75)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 12)
        Me.Label15.TabIndex = 21
        Me.Label15.Text = "奇力龍長:"
        '
        'TextBox12
        '
        Me.TextBox12.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox12.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC33", True))
        Me.TextBox12.Location = New System.Drawing.Point(261, 72)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(70, 22)
        Me.TextBox12.TabIndex = 28
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(199, 75)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 12)
        Me.Label16.TabIndex = 20
        Me.Label16.Text = "奇力龍寬:"
        '
        'Label22
        '
        Me.Label22.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(15, 75)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(68, 12)
        Me.Label22.TabIndex = 35
        Me.Label22.Text = "奇力龍整捲:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboBox6
        '
        Me.ComboBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox6.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.bsDataSource, "CIC31", True))
        Me.ComboBox6.DataSource = Me.bsSelectTable3
        Me.ComboBox6.DisplayMember = "是否奇力龍包整捲"
        Me.ComboBox6.FormattingEnabled = True
        Me.ComboBox6.Location = New System.Drawing.Point(89, 72)
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(80, 20)
        Me.ComboBox6.TabIndex = 36
        Me.ComboBox6.ValueMember = "值"
        '
        'bsSelectTable3
        '
        Me.bsSelectTable3.DataMember = "PackageSelectTable3"
        Me.bsSelectTable3.DataSource = Me.ColdRollingClientDataSet
        '
        'Label23
        '
        Me.Label23.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(27, 51)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(56, 12)
        Me.Label23.TabIndex = 17
        Me.Label23.Text = "是否套筒:"
        '
        'ComboBox7
        '
        Me.ComboBox7.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.bsDataSource, "CIC21", True))
        Me.ComboBox7.DataSource = Me.bsSelectTable2
        Me.ComboBox7.DisplayMember = "是否使用紙套筒"
        Me.ComboBox7.FormattingEnabled = True
        Me.ComboBox7.Location = New System.Drawing.Point(89, 49)
        Me.ComboBox7.Name = "ComboBox7"
        Me.ComboBox7.Size = New System.Drawing.Size(70, 20)
        Me.ComboBox7.TabIndex = 32
        Me.ComboBox7.ValueMember = "值"
        '
        'bsSelectTable2
        '
        Me.bsSelectTable2.DataMember = "PackageSelectTable2"
        Me.bsSelectTable2.DataSource = Me.ColdRollingClientDataSet
        '
        'Label24
        '
        Me.Label24.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(199, 51)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(56, 12)
        Me.Label24.TabIndex = 18
        Me.Label24.Text = "套筒外徑:"
        '
        'TextBox13
        '
        Me.TextBox13.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox13.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC22", True))
        Me.TextBox13.Location = New System.Drawing.Point(261, 49)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New System.Drawing.Size(70, 22)
        Me.TextBox13.TabIndex = 26
        '
        'Label25
        '
        Me.Label25.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(371, 51)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(56, 12)
        Me.Label25.TabIndex = 19
        Me.Label25.Text = "套筒內徑:"
        '
        'TextBox14
        '
        Me.TextBox14.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox14.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC23", True))
        Me.TextBox14.Location = New System.Drawing.Point(433, 49)
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New System.Drawing.Size(70, 22)
        Me.TextBox14.TabIndex = 27
        '
        'Label26
        '
        Me.Label26.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(555, 51)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(44, 12)
        Me.Label26.TabIndex = 37
        Me.Label26.Text = "套筒重:"
        '
        'TextBox15
        '
        Me.TextBox15.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox15.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC24", True))
        Me.TextBox15.Location = New System.Drawing.Point(605, 49)
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New System.Drawing.Size(70, 22)
        Me.TextBox15.TabIndex = 38
        '
        'cbWillSplitCoil
        '
        Me.cbWillSplitCoil.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbWillSplitCoil.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.cbWillSplitCoil, 2)
        Me.cbWillSplitCoil.Location = New System.Drawing.Point(3, 7)
        Me.cbWillSplitCoil.Name = "cbWillSplitCoil"
        Me.cbWillSplitCoil.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbWillSplitCoil.Size = New System.Drawing.Size(226, 16)
        Me.cbWillSplitCoil.TabIndex = 34
        Me.cbWillSplitCoil.Text = "此鋼捲預計即將分捲"
        Me.cbWillSplitCoil.UseVisualStyleBackColor = True
        '
        'cbPaperPrint4Copies
        '
        Me.cbPaperPrint4Copies.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbPaperPrint4Copies.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.cbPaperPrint4Copies, 2)
        Me.cbPaperPrint4Copies.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.bsDataSource, "IsFinishProduct", True))
        Me.cbPaperPrint4Copies.Location = New System.Drawing.Point(235, 7)
        Me.cbPaperPrint4Copies.Name = "cbPaperPrint4Copies"
        Me.cbPaperPrint4Copies.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbPaperPrint4Copies.Size = New System.Drawing.Size(226, 16)
        Me.cbPaperPrint4Copies.TabIndex = 35
        Me.cbPaperPrint4Copies.Text = "成品入庫並加列印條碼N張"
        Me.cbPaperPrint4Copies.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(69, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 12)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "退料重:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(301, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 12)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "損耗重:"
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "ReturnWeight", True))
        Me.TextBox2.Location = New System.Drawing.Point(119, 34)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(110, 22)
        Me.TextBox2.TabIndex = 38
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "ScaleWeight", True))
        Me.TextBox3.Location = New System.Drawing.Point(351, 34)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(110, 22)
        Me.TextBox3.TabIndex = 39
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(545, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 12)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "重量:"
        '
        'TextBox4
        '
        Me.TextBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "Weight", True))
        Me.TextBox4.Location = New System.Drawing.Point(583, 4)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(113, 22)
        Me.TextBox4.TabIndex = 41
        '
        'PSpecialOrderControl
        '
        Me.PSpecialOrderControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.SetColumnSpan(Me.PSpecialOrderControl, 6)
        Me.PSpecialOrderControl.Location = New System.Drawing.Point(3, 193)
        Me.PSpecialOrderControl.Name = "PSpecialOrderControl"
        Me.PSpecialOrderControl.Size = New System.Drawing.Size(693, 111)
        Me.PSpecialOrderControl.TabIndex = 42
        '
        'cbCheckAllDataCorrect
        '
        Me.cbCheckAllDataCorrect.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbCheckAllDataCorrect.AutoSize = True
        Me.cbCheckAllDataCorrect.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.bsDataSource, "IsUserRunningDataChecked", True))
        Me.cbCheckAllDataCorrect.Location = New System.Drawing.Point(583, 37)
        Me.cbCheckAllDataCorrect.Name = "cbCheckAllDataCorrect"
        Me.cbCheckAllDataCorrect.Size = New System.Drawing.Size(72, 16)
        Me.cbCheckAllDataCorrect.TabIndex = 43
        Me.cbCheckAllDataCorrect.Text = "確認無誤"
        Me.cbCheckAllDataCorrect.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(497, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 12)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "確認輸入資料:"
        '
        'tCheckData
        '
        Me.tCheckData.Enabled = True
        Me.tCheckData.Interval = 500
        '
        'APL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Name = "APL"
        Me.Size = New System.Drawing.Size(699, 307)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.bsDataSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsSelectTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ColdRollingClientDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsSelectTable0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsSelectTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsSelectTable2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents bsDataSource As System.Windows.Forms.BindingSource
    Friend WithEvents bsSelectTable1 As System.Windows.Forms.BindingSource
    Friend WithEvents ColdRollingClientDataSet As ColdRollingClient.ColdRollingClientDataSet
    Friend WithEvents bsSelectTable2 As System.Windows.Forms.BindingSource
    Friend WithEvents bsSelectTable0 As System.Windows.Forms.BindingSource
    Friend WithEvents bsSelectTable3 As System.Windows.Forms.BindingSource
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tbPaperFixLength As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbPaperPLSelect As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ComboBox6 As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents ComboBox7 As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TextBox13 As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TextBox14 As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TextBox15 As System.Windows.Forms.TextBox
    Friend WithEvents cbWillSplitCoil As System.Windows.Forms.CheckBox
    Friend WithEvents cbPaperPrint4Copies As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents PSpecialOrderControl As System.Windows.Forms.Panel
    Friend WithEvents cbCheckAllDataCorrect As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tCheckData As System.Windows.Forms.Timer

End Class
