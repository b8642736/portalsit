<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CPL
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
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.bsDataSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label17 = New System.Windows.Forms.Label()
        Me.tbPaperFixLength = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.bsSelectTable1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ColdRollingClientDataSet = New ColdRollingClient.ColdRollingClientDataSet()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cbPaperPLSelect = New System.Windows.Forms.ComboBox()
        Me.bsSelectTable0 = New System.Windows.Forms.BindingSource(Me.components)
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.bsSelectTable3 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label26 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.bsSelectTable2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.lbCSCNumber = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbIsHeadOrTail = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lbRunLine = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbThekindStationRunCount = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.bsDataSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsSelectTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ColdRollingClientDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsSelectTable0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsSelectTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsSelectTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lbCSCNumber, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbIsHeadOrTail, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label12, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label13, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label14, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbRunLine, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label16, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbThekindStationRunCount, 5, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox1, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label15, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label30, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox10, 3, 3)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 14)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(622, 411)
        Me.TableLayoutPanel1.TabIndex = 2
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
        Me.TableLayoutPanel2.Controls.Add(Me.Label17, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.tbPaperFixLength, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label18, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox2, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label19, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ComboBox1, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label20, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label21, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cbPaperPLSelect, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox9, 7, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label22, 6, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox8, 5, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label23, 4, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox7, 3, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label24, 2, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label25, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.ComboBox4, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label26, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.ComboBox2, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label27, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox5, 3, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label28, 4, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox6, 5, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label29, 6, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox3, 7, 2)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 143)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(616, 265)
        Me.TableLayoutPanel2.TabIndex = 23
        '
        'TextBox4
        '
        Me.TextBox4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC14", True))
        Me.TextBox4.Location = New System.Drawing.Point(80, 88)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(70, 22)
        Me.TextBox4.TabIndex = 25
        '
        'bsDataSource
        '
        Me.bsDataSource.DataSource = GetType(CompanyORMDB.SQLServer.PPS100LB.RunProcessData)
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(18, 93)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 12)
        Me.Label17.TabIndex = 16
        Me.Label17.Text = "襯紙基重:"
        '
        'tbPaperFixLength
        '
        Me.tbPaperFixLength.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tbPaperFixLength.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC12", True))
        Me.tbPaperFixLength.Location = New System.Drawing.Point(542, 22)
        Me.tbPaperFixLength.Name = "tbPaperFixLength"
        Me.tbPaperFixLength.Size = New System.Drawing.Size(70, 22)
        Me.tbPaperFixLength.TabIndex = 24
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(480, 27)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 12)
        Me.Label18.TabIndex = 15
        Me.Label18.Text = "襯紙定長:"
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC13", True))
        Me.TextBox2.Location = New System.Drawing.Point(388, 22)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(70, 22)
        Me.TextBox2.TabIndex = 13
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(338, 27)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(44, 12)
        Me.Label19.TabIndex = 12
        Me.Label19.Text = "襯紙寬:"
        '
        'ComboBox1
        '
        Me.ComboBox1.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.bsDataSource, "CIC15", True))
        Me.ComboBox1.DataSource = Me.bsSelectTable1
        Me.ComboBox1.DisplayMember = "厚薄"
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(234, 3)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(70, 20)
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
        'Label20
        '
        Me.Label20.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(172, 27)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(56, 12)
        Me.Label20.TabIndex = 14
        Me.Label20.Text = "襯紙厚薄:"
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 27)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(68, 12)
        Me.Label21.TabIndex = 33
        Me.Label21.Text = "襯紙夾整捲:"
        '
        'cbPaperPLSelect
        '
        Me.cbPaperPLSelect.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.bsDataSource, "CIC11", True))
        Me.cbPaperPLSelect.DataSource = Me.bsSelectTable0
        Me.cbPaperPLSelect.DisplayMember = "襯紙夾整捲"
        Me.cbPaperPLSelect.FormattingEnabled = True
        Me.cbPaperPLSelect.Location = New System.Drawing.Point(80, 3)
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
        'TextBox9
        '
        Me.TextBox9.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox9.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC34", True))
        Me.TextBox9.Location = New System.Drawing.Point(542, 220)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(70, 22)
        Me.TextBox9.TabIndex = 30
        '
        'Label22
        '
        Me.Label22.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(468, 225)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(68, 12)
        Me.Label22.TabIndex = 22
        Me.Label22.Text = "奇力龍基重:"
        '
        'TextBox8
        '
        Me.TextBox8.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox8.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC32", True))
        Me.TextBox8.Location = New System.Drawing.Point(388, 220)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(70, 22)
        Me.TextBox8.TabIndex = 29
        '
        'Label23
        '
        Me.Label23.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(326, 225)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(56, 12)
        Me.Label23.TabIndex = 21
        Me.Label23.Text = "奇力龍長:"
        '
        'TextBox7
        '
        Me.TextBox7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox7.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC33", True))
        Me.TextBox7.Location = New System.Drawing.Point(234, 220)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(70, 22)
        Me.TextBox7.TabIndex = 28
        '
        'Label24
        '
        Me.Label24.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(172, 225)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(56, 12)
        Me.Label24.TabIndex = 20
        Me.Label24.Text = "奇力龍寬:"
        '
        'Label25
        '
        Me.Label25.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(6, 225)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(68, 12)
        Me.Label25.TabIndex = 35
        Me.Label25.Text = "奇力龍整捲:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboBox4
        '
        Me.ComboBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox4.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.bsDataSource, "CIC31", True))
        Me.ComboBox4.DataSource = Me.bsSelectTable3
        Me.ComboBox4.DisplayMember = "是否奇力龍包整捲"
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(80, 221)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(71, 20)
        Me.ComboBox4.TabIndex = 36
        Me.ComboBox4.ValueMember = "值"
        '
        'bsSelectTable3
        '
        Me.bsSelectTable3.DataMember = "PackageSelectTable3"
        Me.bsSelectTable3.DataSource = Me.ColdRollingClientDataSet
        '
        'Label26
        '
        Me.Label26.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(18, 159)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(56, 12)
        Me.Label26.TabIndex = 17
        Me.Label26.Text = "是否套筒:"
        '
        'ComboBox2
        '
        Me.ComboBox2.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.bsDataSource, "CIC21", True))
        Me.ComboBox2.DataSource = Me.bsSelectTable2
        Me.ComboBox2.DisplayMember = "是否使用紙套筒"
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(80, 135)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(70, 20)
        Me.ComboBox2.TabIndex = 32
        Me.ComboBox2.ValueMember = "值"
        '
        'bsSelectTable2
        '
        Me.bsSelectTable2.DataMember = "PackageSelectTable2"
        Me.bsSelectTable2.DataSource = Me.ColdRollingClientDataSet
        '
        'Label27
        '
        Me.Label27.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(172, 159)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(56, 12)
        Me.Label27.TabIndex = 18
        Me.Label27.Text = "套筒外徑:"
        '
        'TextBox5
        '
        Me.TextBox5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC22", True))
        Me.TextBox5.Location = New System.Drawing.Point(234, 154)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(70, 22)
        Me.TextBox5.TabIndex = 26
        '
        'Label28
        '
        Me.Label28.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(326, 159)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(56, 12)
        Me.Label28.TabIndex = 19
        Me.Label28.Text = "套筒內徑:"
        '
        'TextBox6
        '
        Me.TextBox6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC23", True))
        Me.TextBox6.Location = New System.Drawing.Point(388, 154)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(70, 22)
        Me.TextBox6.TabIndex = 27
        '
        'Label29
        '
        Me.Label29.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(492, 159)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(44, 12)
        Me.Label29.TabIndex = 37
        Me.Label29.Text = "套筒重:"
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "CIC24", True))
        Me.TextBox3.Location = New System.Drawing.Point(542, 154)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(71, 22)
        Me.TextBox3.TabIndex = 38
        '
        'lbCSCNumber
        '
        Me.lbCSCNumber.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbCSCNumber.AutoSize = True
        Me.lbCSCNumber.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "AboutPPSBLAPF_BLA01", True))
        Me.lbCSCNumber.ForeColor = System.Drawing.Color.Black
        Me.lbCSCNumber.Location = New System.Drawing.Point(106, 11)
        Me.lbCSCNumber.Name = "lbCSCNumber"
        Me.lbCSCNumber.Size = New System.Drawing.Size(21, 12)
        Me.lbCSCNumber.TabIndex = 3
        Me.lbCSCNumber.Text = "----"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(44, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "中鋼號碼:"
        '
        'lbIsHeadOrTail
        '
        Me.lbIsHeadOrTail.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbIsHeadOrTail.AutoSize = True
        Me.lbIsHeadOrTail.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "HeadTailDescript", True))
        Me.lbIsHeadOrTail.ForeColor = System.Drawing.Color.Black
        Me.lbIsHeadOrTail.Location = New System.Drawing.Point(312, 11)
        Me.lbIsHeadOrTail.Name = "lbIsHeadOrTail"
        Me.lbIsHeadOrTail.Size = New System.Drawing.Size(21, 12)
        Me.lbIsHeadOrTail.TabIndex = 1
        Me.lbIsHeadOrTail.Text = "----"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(238, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "頭尾塊指示:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(456, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "鋼種材質:"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "AboutPPSBLAPF_BLA02", True))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(518, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(21, 12)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "----"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(41, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 12)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "厚度/寬度:"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(274, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 12)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "重量:"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(480, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 12)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "表面:"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(20, 81)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 12)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "目前指派產線:"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(250, 81)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 12)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "下一產線:"
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label12.AutoSize = True
        Me.Label12.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "AboutLastOutPPSSHAPF_ThickWidth", True))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(106, 46)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(21, 12)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "----"
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label13.AutoSize = True
        Me.Label13.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "AboutLastOutPPSSHAPF_Weight", True))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(312, 46)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(21, 12)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "----"
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label14.AutoSize = True
        Me.Label14.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "AboutLastOutPPSSHAPF_Face", True))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(518, 46)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(21, 12)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "----"
        '
        'lbRunLine
        '
        Me.lbRunLine.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbRunLine.AutoSize = True
        Me.lbRunLine.BackColor = System.Drawing.SystemColors.Control
        Me.lbRunLine.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "AboutLastOutPPSSHAPF_LineName", True))
        Me.lbRunLine.ForeColor = System.Drawing.Color.Black
        Me.lbRunLine.Location = New System.Drawing.Point(106, 81)
        Me.lbRunLine.Name = "lbRunLine"
        Me.lbRunLine.Size = New System.Drawing.Size(21, 12)
        Me.lbRunLine.TabIndex = 16
        Me.lbRunLine.Text = "----"
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label16.AutoSize = True
        Me.Label16.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "AboutLastOutPPSSHAPF_NextLineName", True))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(312, 81)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(21, 12)
        Me.Label16.TabIndex = 17
        Me.Label16.Text = "----"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(423, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 12)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "CPL已執行次數:"
        '
        'lbThekindStationRunCount
        '
        Me.lbThekindStationRunCount.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbThekindStationRunCount.AutoSize = True
        Me.lbThekindStationRunCount.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "TheKindStationRunCount", True))
        Me.lbThekindStationRunCount.ForeColor = System.Drawing.Color.Black
        Me.lbThekindStationRunCount.Location = New System.Drawing.Point(518, 81)
        Me.lbThekindStationRunCount.Name = "lbThekindStationRunCount"
        Me.lbThekindStationRunCount.Size = New System.Drawing.Size(21, 12)
        Me.lbThekindStationRunCount.TabIndex = 20
        Me.lbThekindStationRunCount.Text = "----"
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "Length", True))
        Me.TextBox1.Location = New System.Drawing.Point(106, 111)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(97, 22)
        Me.TextBox1.TabIndex = 21
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(68, 116)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(32, 12)
        Me.Label15.TabIndex = 22
        Me.Label15.Text = "長度:"
        '
        'Label30
        '
        Me.Label30.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(262, 116)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(44, 12)
        Me.Label30.TabIndex = 24
        Me.Label30.Text = "退料重:"
        '
        'TextBox10
        '
        Me.TextBox10.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox10.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsDataSource, "ReturnWeight", True))
        Me.TextBox10.Location = New System.Drawing.Point(312, 111)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(97, 22)
        Me.TextBox10.TabIndex = 25
        '
        'CPL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "CPL"
        Me.Size = New System.Drawing.Size(646, 443)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.bsDataSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsSelectTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ColdRollingClientDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsSelectTable0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsSelectTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsSelectTable2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbCSCNumber As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbIsHeadOrTail As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bsDataSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lbRunLine As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbThekindStationRunCount As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents bsSelectTable1 As System.Windows.Forms.BindingSource
    Friend WithEvents ColdRollingClientDataSet As ColdRollingClient.ColdRollingClientDataSet
    Friend WithEvents bsSelectTable3 As System.Windows.Forms.BindingSource
    Friend WithEvents bsSelectTable2 As System.Windows.Forms.BindingSource
    Friend WithEvents bsSelectTable0 As System.Windows.Forms.BindingSource
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents tbPaperFixLength As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cbPaperPLSelect As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox

End Class
