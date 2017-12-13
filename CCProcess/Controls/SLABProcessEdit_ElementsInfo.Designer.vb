<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SLABProcessEdit_ElementsInfo
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
        Me.bsElementInformation = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.StationAndSampleNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SiDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MnDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CrDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NiDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CuDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AlDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PbDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SnDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.O2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.N2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.bsElementInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bsElementInformation
        '
        Me.bsElementInformation.DataSource = GetType(CCProcess.ElementInformation)
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.StationAndSampleNumberDataGridViewTextBoxColumn, Me.CDataGridViewTextBoxColumn, Me.SiDataGridViewTextBoxColumn, Me.MnDataGridViewTextBoxColumn, Me.PDataGridViewTextBoxColumn, Me.SDataGridViewTextBoxColumn, Me.CrDataGridViewTextBoxColumn, Me.NiDataGridViewTextBoxColumn, Me.CuDataGridViewTextBoxColumn, Me.MoDataGridViewTextBoxColumn, Me.CoDataGridViewTextBoxColumn, Me.AlDataGridViewTextBoxColumn, Me.PbDataGridViewTextBoxColumn, Me.SnDataGridViewTextBoxColumn, Me.O2DataGridViewTextBoxColumn, Me.N2DataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.bsElementInformation
        Me.DataGridView1.Location = New System.Drawing.Point(14, 15)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(611, 307)
        Me.DataGridView1.TabIndex = 0
        '
        'StationAndSampleNumberDataGridViewTextBoxColumn
        '
        Me.StationAndSampleNumberDataGridViewTextBoxColumn.DataPropertyName = "StationAndSampleNumber"
        Me.StationAndSampleNumberDataGridViewTextBoxColumn.HeaderText = "化學成份"
        Me.StationAndSampleNumberDataGridViewTextBoxColumn.Name = "StationAndSampleNumberDataGridViewTextBoxColumn"
        Me.StationAndSampleNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.StationAndSampleNumberDataGridViewTextBoxColumn.Width = 78
        '
        'CDataGridViewTextBoxColumn
        '
        Me.CDataGridViewTextBoxColumn.DataPropertyName = "C"
        Me.CDataGridViewTextBoxColumn.HeaderText = "C"
        Me.CDataGridViewTextBoxColumn.Name = "CDataGridViewTextBoxColumn"
        Me.CDataGridViewTextBoxColumn.ReadOnly = True
        Me.CDataGridViewTextBoxColumn.Width = 38
        '
        'SiDataGridViewTextBoxColumn
        '
        Me.SiDataGridViewTextBoxColumn.DataPropertyName = "Si"
        Me.SiDataGridViewTextBoxColumn.HeaderText = "Si"
        Me.SiDataGridViewTextBoxColumn.Name = "SiDataGridViewTextBoxColumn"
        Me.SiDataGridViewTextBoxColumn.ReadOnly = True
        Me.SiDataGridViewTextBoxColumn.Width = 39
        '
        'MnDataGridViewTextBoxColumn
        '
        Me.MnDataGridViewTextBoxColumn.DataPropertyName = "Mn"
        Me.MnDataGridViewTextBoxColumn.HeaderText = "Mn"
        Me.MnDataGridViewTextBoxColumn.Name = "MnDataGridViewTextBoxColumn"
        Me.MnDataGridViewTextBoxColumn.ReadOnly = True
        Me.MnDataGridViewTextBoxColumn.Width = 46
        '
        'PDataGridViewTextBoxColumn
        '
        Me.PDataGridViewTextBoxColumn.DataPropertyName = "P"
        Me.PDataGridViewTextBoxColumn.HeaderText = "P"
        Me.PDataGridViewTextBoxColumn.Name = "PDataGridViewTextBoxColumn"
        Me.PDataGridViewTextBoxColumn.ReadOnly = True
        Me.PDataGridViewTextBoxColumn.Width = 36
        '
        'SDataGridViewTextBoxColumn
        '
        Me.SDataGridViewTextBoxColumn.DataPropertyName = "S"
        Me.SDataGridViewTextBoxColumn.HeaderText = "S"
        Me.SDataGridViewTextBoxColumn.Name = "SDataGridViewTextBoxColumn"
        Me.SDataGridViewTextBoxColumn.ReadOnly = True
        Me.SDataGridViewTextBoxColumn.Width = 36
        '
        'CrDataGridViewTextBoxColumn
        '
        Me.CrDataGridViewTextBoxColumn.DataPropertyName = "Cr"
        Me.CrDataGridViewTextBoxColumn.HeaderText = "Cr"
        Me.CrDataGridViewTextBoxColumn.Name = "CrDataGridViewTextBoxColumn"
        Me.CrDataGridViewTextBoxColumn.ReadOnly = True
        Me.CrDataGridViewTextBoxColumn.Width = 42
        '
        'NiDataGridViewTextBoxColumn
        '
        Me.NiDataGridViewTextBoxColumn.DataPropertyName = "Ni"
        Me.NiDataGridViewTextBoxColumn.HeaderText = "Ni"
        Me.NiDataGridViewTextBoxColumn.Name = "NiDataGridViewTextBoxColumn"
        Me.NiDataGridViewTextBoxColumn.ReadOnly = True
        Me.NiDataGridViewTextBoxColumn.Width = 41
        '
        'CuDataGridViewTextBoxColumn
        '
        Me.CuDataGridViewTextBoxColumn.DataPropertyName = "Cu"
        Me.CuDataGridViewTextBoxColumn.HeaderText = "Cu"
        Me.CuDataGridViewTextBoxColumn.Name = "CuDataGridViewTextBoxColumn"
        Me.CuDataGridViewTextBoxColumn.ReadOnly = True
        Me.CuDataGridViewTextBoxColumn.Width = 44
        '
        'MoDataGridViewTextBoxColumn
        '
        Me.MoDataGridViewTextBoxColumn.DataPropertyName = "Mo"
        Me.MoDataGridViewTextBoxColumn.HeaderText = "Mo"
        Me.MoDataGridViewTextBoxColumn.Name = "MoDataGridViewTextBoxColumn"
        Me.MoDataGridViewTextBoxColumn.ReadOnly = True
        Me.MoDataGridViewTextBoxColumn.Width = 46
        '
        'CoDataGridViewTextBoxColumn
        '
        Me.CoDataGridViewTextBoxColumn.DataPropertyName = "Co"
        Me.CoDataGridViewTextBoxColumn.HeaderText = "Co"
        Me.CoDataGridViewTextBoxColumn.Name = "CoDataGridViewTextBoxColumn"
        Me.CoDataGridViewTextBoxColumn.ReadOnly = True
        Me.CoDataGridViewTextBoxColumn.Width = 44
        '
        'AlDataGridViewTextBoxColumn
        '
        Me.AlDataGridViewTextBoxColumn.DataPropertyName = "Al"
        Me.AlDataGridViewTextBoxColumn.HeaderText = "Al"
        Me.AlDataGridViewTextBoxColumn.Name = "AlDataGridViewTextBoxColumn"
        Me.AlDataGridViewTextBoxColumn.ReadOnly = True
        Me.AlDataGridViewTextBoxColumn.Width = 41
        '
        'PbDataGridViewTextBoxColumn
        '
        Me.PbDataGridViewTextBoxColumn.DataPropertyName = "Pb"
        Me.PbDataGridViewTextBoxColumn.HeaderText = "Pb"
        Me.PbDataGridViewTextBoxColumn.Name = "PbDataGridViewTextBoxColumn"
        Me.PbDataGridViewTextBoxColumn.ReadOnly = True
        Me.PbDataGridViewTextBoxColumn.Width = 42
        '
        'SnDataGridViewTextBoxColumn
        '
        Me.SnDataGridViewTextBoxColumn.DataPropertyName = "Sn"
        Me.SnDataGridViewTextBoxColumn.HeaderText = "Sn"
        Me.SnDataGridViewTextBoxColumn.Name = "SnDataGridViewTextBoxColumn"
        Me.SnDataGridViewTextBoxColumn.ReadOnly = True
        Me.SnDataGridViewTextBoxColumn.Width = 42
        '
        'O2DataGridViewTextBoxColumn
        '
        Me.O2DataGridViewTextBoxColumn.DataPropertyName = "O2"
        Me.O2DataGridViewTextBoxColumn.HeaderText = "O2"
        Me.O2DataGridViewTextBoxColumn.Name = "O2DataGridViewTextBoxColumn"
        Me.O2DataGridViewTextBoxColumn.ReadOnly = True
        Me.O2DataGridViewTextBoxColumn.Width = 44
        '
        'N2DataGridViewTextBoxColumn
        '
        Me.N2DataGridViewTextBoxColumn.DataPropertyName = "N2"
        Me.N2DataGridViewTextBoxColumn.HeaderText = "N2"
        Me.N2DataGridViewTextBoxColumn.Name = "N2DataGridViewTextBoxColumn"
        Me.N2DataGridViewTextBoxColumn.ReadOnly = True
        Me.N2DataGridViewTextBoxColumn.Width = 44
        '
        'SLABProcessEdit_ElementsInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "SLABProcessEdit_ElementsInfo"
        Me.Size = New System.Drawing.Size(642, 341)
        CType(Me.bsElementInformation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bsElementInformation As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents StationAndSampleNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SiDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MnDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CrDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NiDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CuDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AlDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PbDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SnDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents O2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents N2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
