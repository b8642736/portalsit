<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShowHistoryProcessDialog
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
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.bsCurrentRunProcessData = New System.Windows.Forms.BindingSource(Me.components)
        Me.SHA01DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA02DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA04DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA05DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA06DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA07DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA08DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA10DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA11DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA12DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA13DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA14DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA15DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA16DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA17DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA18DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA19DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA20DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA21DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA22DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA23DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA24DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA25DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA26DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA27DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA33DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA34DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA35DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHA39DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsCurrentRunProcessData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(627, 485)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'OK_Button
        '
        Me.OK_Button.Cursor = System.Windows.Forms.Cursors.Hand
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(116, 35)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "確定並返回"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Location = New System.Drawing.Point(3, 44)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(621, 438)
        Me.Panel1.TabIndex = 1
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SHA01DataGridViewTextBoxColumn, Me.SHA02DataGridViewTextBoxColumn, Me.SHA04DataGridViewTextBoxColumn, Me.SHA05DataGridViewTextBoxColumn, Me.SHA06DataGridViewTextBoxColumn, Me.SHA07DataGridViewTextBoxColumn, Me.SHA08DataGridViewTextBoxColumn, Me.SHA10DataGridViewTextBoxColumn, Me.SHA11DataGridViewTextBoxColumn, Me.SHA12DataGridViewTextBoxColumn, Me.SHA13DataGridViewTextBoxColumn, Me.SHA14DataGridViewTextBoxColumn, Me.SHA15DataGridViewTextBoxColumn, Me.SHA16DataGridViewTextBoxColumn, Me.SHA17DataGridViewTextBoxColumn, Me.SHA18DataGridViewTextBoxColumn, Me.SHA19DataGridViewTextBoxColumn, Me.SHA20DataGridViewTextBoxColumn, Me.SHA21DataGridViewTextBoxColumn, Me.SHA22DataGridViewTextBoxColumn, Me.SHA23DataGridViewTextBoxColumn, Me.SHA24DataGridViewTextBoxColumn, Me.SHA25DataGridViewTextBoxColumn, Me.SHA26DataGridViewTextBoxColumn, Me.SHA27DataGridViewTextBoxColumn, Me.SHA33DataGridViewTextBoxColumn, Me.SHA34DataGridViewTextBoxColumn, Me.SHA35DataGridViewTextBoxColumn, Me.SHA39DataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.bsCurrentRunProcessData
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(621, 438)
        Me.DataGridView1.TabIndex = 0
        '
        'bsCurrentRunProcessData
        '
        Me.bsCurrentRunProcessData.DataSource = GetType(CompanyORMDB.SQLServer.PPS100LB.PPSSHAPF)
        '
        'SHA01DataGridViewTextBoxColumn
        '
        Me.SHA01DataGridViewTextBoxColumn.DataPropertyName = "SHA01"
        Me.SHA01DataGridViewTextBoxColumn.HeaderText = "鋼捲號碼"
        Me.SHA01DataGridViewTextBoxColumn.Name = "SHA01DataGridViewTextBoxColumn"
        Me.SHA01DataGridViewTextBoxColumn.ReadOnly = True
        '
        'SHA02DataGridViewTextBoxColumn
        '
        Me.SHA02DataGridViewTextBoxColumn.DataPropertyName = "SHA02"
        Me.SHA02DataGridViewTextBoxColumn.HeaderText = "分捲號碼"
        Me.SHA02DataGridViewTextBoxColumn.Name = "SHA02DataGridViewTextBoxColumn"
        Me.SHA02DataGridViewTextBoxColumn.ReadOnly = True
        '
        'SHA04DataGridViewTextBoxColumn
        '
        Me.SHA04DataGridViewTextBoxColumn.DataPropertyName = "SHA04"
        Me.SHA04DataGridViewTextBoxColumn.HeaderText = "序號"
        Me.SHA04DataGridViewTextBoxColumn.Name = "SHA04DataGridViewTextBoxColumn"
        Me.SHA04DataGridViewTextBoxColumn.ReadOnly = True
        '
        'SHA05DataGridViewTextBoxColumn
        '
        Me.SHA05DataGridViewTextBoxColumn.DataPropertyName = "SHA05"
        Me.SHA05DataGridViewTextBoxColumn.HeaderText = "計劃厚度"
        Me.SHA05DataGridViewTextBoxColumn.Name = "SHA05DataGridViewTextBoxColumn"
        Me.SHA05DataGridViewTextBoxColumn.ReadOnly = True
        '
        'SHA06DataGridViewTextBoxColumn
        '
        Me.SHA06DataGridViewTextBoxColumn.DataPropertyName = "SHA06"
        Me.SHA06DataGridViewTextBoxColumn.HeaderText = "表面"
        Me.SHA06DataGridViewTextBoxColumn.Name = "SHA06DataGridViewTextBoxColumn"
        Me.SHA06DataGridViewTextBoxColumn.ReadOnly = True
        '
        'SHA07DataGridViewTextBoxColumn
        '
        Me.SHA07DataGridViewTextBoxColumn.DataPropertyName = "SHA07"
        Me.SHA07DataGridViewTextBoxColumn.HeaderText = "厚度"
        Me.SHA07DataGridViewTextBoxColumn.Name = "SHA07DataGridViewTextBoxColumn"
        Me.SHA07DataGridViewTextBoxColumn.ReadOnly = True
        '
        'SHA08DataGridViewTextBoxColumn
        '
        Me.SHA08DataGridViewTextBoxColumn.DataPropertyName = "SHA08"
        Me.SHA08DataGridViewTextBoxColumn.HeaderText = "產線"
        Me.SHA08DataGridViewTextBoxColumn.Name = "SHA08DataGridViewTextBoxColumn"
        Me.SHA08DataGridViewTextBoxColumn.ReadOnly = True
        '
        'SHA10DataGridViewTextBoxColumn
        '
        Me.SHA10DataGridViewTextBoxColumn.DataPropertyName = "SHA10"
        Me.SHA10DataGridViewTextBoxColumn.HeaderText = "排程編號"
        Me.SHA10DataGridViewTextBoxColumn.Name = "SHA10DataGridViewTextBoxColumn"
        Me.SHA10DataGridViewTextBoxColumn.ReadOnly = True
        '
        'SHA11DataGridViewTextBoxColumn
        '
        Me.SHA11DataGridViewTextBoxColumn.DataPropertyName = "SHA11"
        Me.SHA11DataGridViewTextBoxColumn.HeaderText = "排程日期"
        Me.SHA11DataGridViewTextBoxColumn.Name = "SHA11DataGridViewTextBoxColumn"
        Me.SHA11DataGridViewTextBoxColumn.ReadOnly = True
        '
        'SHA12DataGridViewTextBoxColumn
        '
        Me.SHA12DataGridViewTextBoxColumn.DataPropertyName = "SHA12"
        Me.SHA12DataGridViewTextBoxColumn.HeaderText = "鋼種"
        Me.SHA12DataGridViewTextBoxColumn.Name = "SHA12DataGridViewTextBoxColumn"
        Me.SHA12DataGridViewTextBoxColumn.ReadOnly = True
        '
        'SHA13DataGridViewTextBoxColumn
        '
        Me.SHA13DataGridViewTextBoxColumn.DataPropertyName = "SHA13"
        Me.SHA13DataGridViewTextBoxColumn.HeaderText = "型別"
        Me.SHA13DataGridViewTextBoxColumn.Name = "SHA13DataGridViewTextBoxColumn"
        Me.SHA13DataGridViewTextBoxColumn.ReadOnly = True
        '
        'SHA14DataGridViewTextBoxColumn
        '
        Me.SHA14DataGridViewTextBoxColumn.DataPropertyName = "SHA14"
        Me.SHA14DataGridViewTextBoxColumn.HeaderText = "厚度"
        Me.SHA14DataGridViewTextBoxColumn.Name = "SHA14DataGridViewTextBoxColumn"
        Me.SHA14DataGridViewTextBoxColumn.ReadOnly = True
        '
        'SHA15DataGridViewTextBoxColumn
        '
        Me.SHA15DataGridViewTextBoxColumn.DataPropertyName = "SHA15"
        Me.SHA15DataGridViewTextBoxColumn.HeaderText = "寬度"
        Me.SHA15DataGridViewTextBoxColumn.Name = "SHA15DataGridViewTextBoxColumn"
        Me.SHA15DataGridViewTextBoxColumn.ReadOnly = True
        '
        'SHA16DataGridViewTextBoxColumn
        '
        Me.SHA16DataGridViewTextBoxColumn.DataPropertyName = "SHA16"
        Me.SHA16DataGridViewTextBoxColumn.HeaderText = "長度"
        Me.SHA16DataGridViewTextBoxColumn.Name = "SHA16DataGridViewTextBoxColumn"
        Me.SHA16DataGridViewTextBoxColumn.ReadOnly = True
        '
        'SHA17DataGridViewTextBoxColumn
        '
        Me.SHA17DataGridViewTextBoxColumn.DataPropertyName = "SHA17"
        Me.SHA17DataGridViewTextBoxColumn.HeaderText = "重量"
        Me.SHA17DataGridViewTextBoxColumn.Name = "SHA17DataGridViewTextBoxColumn"
        Me.SHA17DataGridViewTextBoxColumn.ReadOnly = True
        '
        'SHA18DataGridViewTextBoxColumn
        '
        Me.SHA18DataGridViewTextBoxColumn.DataPropertyName = "SHA18"
        Me.SHA18DataGridViewTextBoxColumn.HeaderText = "回爐重"
        Me.SHA18DataGridViewTextBoxColumn.Name = "SHA18DataGridViewTextBoxColumn"
        Me.SHA18DataGridViewTextBoxColumn.ReadOnly = True
        '
        'SHA19DataGridViewTextBoxColumn
        '
        Me.SHA19DataGridViewTextBoxColumn.DataPropertyName = "SHA19"
        Me.SHA19DataGridViewTextBoxColumn.HeaderText = "耗損重"
        Me.SHA19DataGridViewTextBoxColumn.Name = "SHA19DataGridViewTextBoxColumn"
        Me.SHA19DataGridViewTextBoxColumn.ReadOnly = True
        '
        'SHA20DataGridViewTextBoxColumn
        '
        Me.SHA20DataGridViewTextBoxColumn.DataPropertyName = "SHA20"
        Me.SHA20DataGridViewTextBoxColumn.HeaderText = "其它重"
        Me.SHA20DataGridViewTextBoxColumn.Name = "SHA20DataGridViewTextBoxColumn"
        Me.SHA20DataGridViewTextBoxColumn.ReadOnly = True
        '
        'SHA21DataGridViewTextBoxColumn
        '
        Me.SHA21DataGridViewTextBoxColumn.DataPropertyName = "SHA21"
        Me.SHA21DataGridViewTextBoxColumn.HeaderText = "完成日期"
        Me.SHA21DataGridViewTextBoxColumn.Name = "SHA21DataGridViewTextBoxColumn"
        Me.SHA21DataGridViewTextBoxColumn.ReadOnly = True
        '
        'SHA22DataGridViewTextBoxColumn
        '
        Me.SHA22DataGridViewTextBoxColumn.DataPropertyName = "SHA22"
        Me.SHA22DataGridViewTextBoxColumn.HeaderText = "起始時"
        Me.SHA22DataGridViewTextBoxColumn.Name = "SHA22DataGridViewTextBoxColumn"
        Me.SHA22DataGridViewTextBoxColumn.ReadOnly = True
        '
        'SHA23DataGridViewTextBoxColumn
        '
        Me.SHA23DataGridViewTextBoxColumn.DataPropertyName = "SHA23"
        Me.SHA23DataGridViewTextBoxColumn.HeaderText = "起始分"
        Me.SHA23DataGridViewTextBoxColumn.Name = "SHA23DataGridViewTextBoxColumn"
        Me.SHA23DataGridViewTextBoxColumn.ReadOnly = True
        '
        'SHA24DataGridViewTextBoxColumn
        '
        Me.SHA24DataGridViewTextBoxColumn.DataPropertyName = "SHA24"
        Me.SHA24DataGridViewTextBoxColumn.HeaderText = "終止時"
        Me.SHA24DataGridViewTextBoxColumn.Name = "SHA24DataGridViewTextBoxColumn"
        Me.SHA24DataGridViewTextBoxColumn.ReadOnly = True
        '
        'SHA25DataGridViewTextBoxColumn
        '
        Me.SHA25DataGridViewTextBoxColumn.DataPropertyName = "SHA25"
        Me.SHA25DataGridViewTextBoxColumn.HeaderText = "終止分"
        Me.SHA25DataGridViewTextBoxColumn.Name = "SHA25DataGridViewTextBoxColumn"
        Me.SHA25DataGridViewTextBoxColumn.ReadOnly = True
        '
        'SHA26DataGridViewTextBoxColumn
        '
        Me.SHA26DataGridViewTextBoxColumn.DataPropertyName = "SHA26"
        Me.SHA26DataGridViewTextBoxColumn.HeaderText = "GP研磨次數"
        Me.SHA26DataGridViewTextBoxColumn.Name = "SHA26DataGridViewTextBoxColumn"
        Me.SHA26DataGridViewTextBoxColumn.ReadOnly = True
        '
        'SHA27DataGridViewTextBoxColumn
        '
        Me.SHA27DataGridViewTextBoxColumn.DataPropertyName = "SHA27"
        Me.SHA27DataGridViewTextBoxColumn.HeaderText = "下一產線"
        Me.SHA27DataGridViewTextBoxColumn.Name = "SHA27DataGridViewTextBoxColumn"
        Me.SHA27DataGridViewTextBoxColumn.ReadOnly = True
        '
        'SHA33DataGridViewTextBoxColumn
        '
        Me.SHA33DataGridViewTextBoxColumn.DataPropertyName = "SHA33"
        Me.SHA33DataGridViewTextBoxColumn.HeaderText = "公稱厚度"
        Me.SHA33DataGridViewTextBoxColumn.Name = "SHA33DataGridViewTextBoxColumn"
        Me.SHA33DataGridViewTextBoxColumn.ReadOnly = True
        '
        'SHA34DataGridViewTextBoxColumn
        '
        Me.SHA34DataGridViewTextBoxColumn.DataPropertyName = "SHA34"
        Me.SHA34DataGridViewTextBoxColumn.HeaderText = "公稱寬度"
        Me.SHA34DataGridViewTextBoxColumn.Name = "SHA34DataGridViewTextBoxColumn"
        Me.SHA34DataGridViewTextBoxColumn.ReadOnly = True
        '
        'SHA35DataGridViewTextBoxColumn
        '
        Me.SHA35DataGridViewTextBoxColumn.DataPropertyName = "SHA35"
        Me.SHA35DataGridViewTextBoxColumn.HeaderText = "出口代碼"
        Me.SHA35DataGridViewTextBoxColumn.Name = "SHA35DataGridViewTextBoxColumn"
        Me.SHA35DataGridViewTextBoxColumn.ReadOnly = True
        '
        'SHA39DataGridViewTextBoxColumn
        '
        Me.SHA39DataGridViewTextBoxColumn.DataPropertyName = "SHA39"
        Me.SHA39DataGridViewTextBoxColumn.HeaderText = "計劃表面"
        Me.SHA39DataGridViewTextBoxColumn.Name = "SHA39DataGridViewTextBoxColumn"
        Me.SHA39DataGridViewTextBoxColumn.ReadOnly = True
        '
        'ShowHistoryProcessDialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(627, 485)
        Me.ControlBox = False
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ShowHistoryProcessDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "歷使排程"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsCurrentRunProcessData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents bsCurrentRunProcessData As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents SHA01DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA02DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA04DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA05DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA06DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA07DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA08DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA10DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA11DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA12DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA13DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA14DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA15DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA16DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA17DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA18DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA19DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA20DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA21DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA22DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA23DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA24DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA25DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA26DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA27DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA33DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA34DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA35DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHA39DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
