<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TemperatureWeightEdit_MeasureRecord
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.T3DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.T5DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsSMSC21PF = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsSMSC21PF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.T3DataGridViewTextBoxColumn, Me.T5DataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.bsSMSC21PF
        Me.DataGridView1.Enabled = False
        Me.DataGridView1.Location = New System.Drawing.Point(13, 16)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(519, 262)
        Me.DataGridView1.TabIndex = 0
        '
        'T3DataGridViewTextBoxColumn
        '
        Me.T3DataGridViewTextBoxColumn.DataPropertyName = "T3"
        Me.T3DataGridViewTextBoxColumn.HeaderText = "時間"
        Me.T3DataGridViewTextBoxColumn.MaxInputLength = 4
        Me.T3DataGridViewTextBoxColumn.Name = "T3DataGridViewTextBoxColumn"
        Me.T3DataGridViewTextBoxColumn.ReadOnly = True
        '
        'T5DataGridViewTextBoxColumn
        '
        Me.T5DataGridViewTextBoxColumn.DataPropertyName = "T5"
        Me.T5DataGridViewTextBoxColumn.HeaderText = "溫度"
        Me.T5DataGridViewTextBoxColumn.MaxInputLength = 5
        Me.T5DataGridViewTextBoxColumn.Name = "T5DataGridViewTextBoxColumn"
        Me.T5DataGridViewTextBoxColumn.ReadOnly = True
        '
        'bsSMSC21PF
        '
        Me.bsSMSC21PF.DataSource = GetType(CompanyORMDB.SMS100LB.SMSC21PF)
        '
        'TemperatureWeightEdit_MeasureRecord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "TemperatureWeightEdit_MeasureRecord"
        Me.Size = New System.Drawing.Size(547, 296)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsSMSC21PF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents bsSMSC21PF As System.Windows.Forms.BindingSource
    Friend WithEvents T3DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents T5DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
