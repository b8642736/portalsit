<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmployeeSelectDialog
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.bsPQDM01PF = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnCancelBack = New System.Windows.Forms.Button()
        Me.Column1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.QD100ADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QD100CDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsPQDM01PF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancelBack, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(14, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(514, 418)
        Me.TableLayoutPanel1.TabIndex = 1
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.QD100ADataGridViewTextBoxColumn, Me.QD100CDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.bsPQDM01PF
        Me.DataGridView1.Location = New System.Drawing.Point(3, 43)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(508, 372)
        Me.DataGridView1.TabIndex = 2
        '
        'bsPQDM01PF
        '
        Me.bsPQDM01PF.DataSource = GetType(CompanyORMDB.PLT000LB.PQDM01PF)
        '
        'btnCancelBack
        '
        Me.btnCancelBack.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelBack.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelBack.Location = New System.Drawing.Point(3, 3)
        Me.btnCancelBack.Name = "btnCancelBack"
        Me.btnCancelBack.Size = New System.Drawing.Size(508, 34)
        Me.btnCancelBack.TabIndex = 1
        Me.btnCancelBack.Text = "取消返回"
        Me.btnCancelBack.UseVisualStyleBackColor = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "選擇設定"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Text = "選擇設定"
        Me.Column1.UseColumnTextForButtonValue = True
        '
        'QD100ADataGridViewTextBoxColumn
        '
        Me.QD100ADataGridViewTextBoxColumn.DataPropertyName = "QD100A"
        Me.QD100ADataGridViewTextBoxColumn.HeaderText = "員工編號"
        Me.QD100ADataGridViewTextBoxColumn.Name = "QD100ADataGridViewTextBoxColumn"
        Me.QD100ADataGridViewTextBoxColumn.ReadOnly = True
        '
        'QD100CDataGridViewTextBoxColumn
        '
        Me.QD100CDataGridViewTextBoxColumn.DataPropertyName = "QD100C"
        Me.QD100CDataGridViewTextBoxColumn.HeaderText = "姓名"
        Me.QD100CDataGridViewTextBoxColumn.Name = "QD100CDataGridViewTextBoxColumn"
        Me.QD100CDataGridViewTextBoxColumn.ReadOnly = True
        '
        'EmployeeSelectDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 435)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EmployeeSelectDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "員工選擇設定"
        Me.TopMost = True
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsPQDM01PF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnCancelBack As System.Windows.Forms.Button
    Friend WithEvents bsPQDM01PF As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents QD100ADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QD100CDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
