<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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

    '注意:  以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.SaveDateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsslMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslSaveTagMsg = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslHAServerState = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tHAServerLookChange = New System.Windows.Forms.Timer(Me.components)
        Me.LineNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TagNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValueChangeTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KeyNameForCoilDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TagIntValueDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TagStringValueDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsGoodStatusDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.bsL2RealTimeTagDisplay = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.bsL2RealTimeTagDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(852, 427)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 397)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 12)
        Me.Label1.TabIndex = 3
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LineNameDataGridViewTextBoxColumn, Me.TagNameDataGridViewTextBoxColumn, Me.ValueChangeTimeDataGridViewTextBoxColumn, Me.KeyNameForCoilDataGridViewTextBoxColumn, Me.TagIntValueDataGridViewTextBoxColumn, Me.TagStringValueDataGridViewTextBoxColumn, Me.IsGoodStatusDataGridViewCheckBoxColumn, Me.SaveDateTime, Me.Description})
        Me.TableLayoutPanel1.SetColumnSpan(Me.DataGridView1, 2)
        Me.DataGridView1.DataSource = Me.bsL2RealTimeTagDisplay
        Me.DataGridView1.Location = New System.Drawing.Point(3, 73)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(846, 321)
        Me.DataGridView1.TabIndex = 0
        '
        'SaveDateTime
        '
        Me.SaveDateTime.DataPropertyName = "NextSaveTime"
        DataGridViewCellStyle2.Format = "G"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.SaveDateTime.DefaultCellStyle = DataGridViewCellStyle2
        Me.SaveDateTime.HeaderText = "下次寫檔時間"
        Me.SaveDateTime.Name = "SaveDateTime"
        Me.SaveDateTime.ReadOnly = True
        '
        'Description
        '
        Me.Description.DataPropertyName = "Description"
        Me.Description.HeaderText = "說明"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 6
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 2)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnStart, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnStop, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(846, 64)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'btnStart
        '
        Me.btnStart.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStart.Location = New System.Drawing.Point(3, 3)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(134, 58)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "啟動"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStop.Enabled = False
        Me.btnStop.Location = New System.Drawing.Point(143, 3)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(134, 58)
        Me.btnStop.TabIndex = 2
        Me.btnStop.Text = "暫停監控"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "唐榮L2通訊中繼"
        Me.NotifyIcon1.Visible = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslMessage, Me.tsslSaveTagMsg, Me.tsslHAServerState})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 429)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(876, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsslMessage
        '
        Me.tsslMessage.Name = "tsslMessage"
        Me.tsslMessage.Size = New System.Drawing.Size(75, 17)
        Me.tsslMessage.Text = "tsslMessage"
        '
        'tsslSaveTagMsg
        '
        Me.tsslSaveTagMsg.Name = "tsslSaveTagMsg"
        Me.tsslSaveTagMsg.Size = New System.Drawing.Size(98, 17)
        Me.tsslSaveTagMsg.Text = "tsslSaveTagMsg"
        '
        'tsslHAServerState
        '
        Me.tsslHAServerState.ForeColor = System.Drawing.Color.Blue
        Me.tsslHAServerState.Name = "tsslHAServerState"
        Me.tsslHAServerState.Size = New System.Drawing.Size(105, 17)
        Me.tsslHAServerState.Text = "tsslHAServerState"
        '
        'tHAServerLookChange
        '
        Me.tHAServerLookChange.Interval = 1400
        '
        'LineNameDataGridViewTextBoxColumn
        '
        Me.LineNameDataGridViewTextBoxColumn.DataPropertyName = "LineName"
        Me.LineNameDataGridViewTextBoxColumn.HeaderText = "產線名稱"
        Me.LineNameDataGridViewTextBoxColumn.Name = "LineNameDataGridViewTextBoxColumn"
        Me.LineNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TagNameDataGridViewTextBoxColumn
        '
        Me.TagNameDataGridViewTextBoxColumn.DataPropertyName = "TagName"
        Me.TagNameDataGridViewTextBoxColumn.HeaderText = "標籤名稱"
        Me.TagNameDataGridViewTextBoxColumn.Name = "TagNameDataGridViewTextBoxColumn"
        Me.TagNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ValueChangeTimeDataGridViewTextBoxColumn
        '
        Me.ValueChangeTimeDataGridViewTextBoxColumn.DataPropertyName = "ValueChangeTime"
        DataGridViewCellStyle1.Format = "G"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.ValueChangeTimeDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.ValueChangeTimeDataGridViewTextBoxColumn.HeaderText = "值變更時間"
        Me.ValueChangeTimeDataGridViewTextBoxColumn.Name = "ValueChangeTimeDataGridViewTextBoxColumn"
        Me.ValueChangeTimeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'KeyNameForCoilDataGridViewTextBoxColumn
        '
        Me.KeyNameForCoilDataGridViewTextBoxColumn.DataPropertyName = "KeyNameForCoil"
        Me.KeyNameForCoilDataGridViewTextBoxColumn.HeaderText = "鋼捲識別值"
        Me.KeyNameForCoilDataGridViewTextBoxColumn.Name = "KeyNameForCoilDataGridViewTextBoxColumn"
        Me.KeyNameForCoilDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TagIntValueDataGridViewTextBoxColumn
        '
        Me.TagIntValueDataGridViewTextBoxColumn.DataPropertyName = "TagIntValue"
        Me.TagIntValueDataGridViewTextBoxColumn.HeaderText = "數字值"
        Me.TagIntValueDataGridViewTextBoxColumn.Name = "TagIntValueDataGridViewTextBoxColumn"
        Me.TagIntValueDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TagStringValueDataGridViewTextBoxColumn
        '
        Me.TagStringValueDataGridViewTextBoxColumn.DataPropertyName = "TagStringValue"
        Me.TagStringValueDataGridViewTextBoxColumn.HeaderText = "文字值"
        Me.TagStringValueDataGridViewTextBoxColumn.Name = "TagStringValueDataGridViewTextBoxColumn"
        Me.TagStringValueDataGridViewTextBoxColumn.ReadOnly = True
        '
        'IsGoodStatusDataGridViewCheckBoxColumn
        '
        Me.IsGoodStatusDataGridViewCheckBoxColumn.DataPropertyName = "IsGoodStatus"
        Me.IsGoodStatusDataGridViewCheckBoxColumn.HeaderText = "值是否正常"
        Me.IsGoodStatusDataGridViewCheckBoxColumn.Name = "IsGoodStatusDataGridViewCheckBoxColumn"
        Me.IsGoodStatusDataGridViewCheckBoxColumn.ReadOnly = True
        '
        'bsL2RealTimeTagDisplay
        '
        Me.bsL2RealTimeTagDisplay.DataSource = GetType(CompanyORMDB.SQLServer.IM.L2RealTimeTagDisplay)
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(876, 451)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MainForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.bsL2RealTimeTagDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslSaveTagMsg As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents bsL2RealTimeTagDisplay As System.Windows.Forms.BindingSource
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LineNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TagNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValueChangeTimeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KeyNameForCoilDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TagIntValueDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TagStringValueDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsGoodStatusDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents SaveDateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tHAServerLookChange As System.Windows.Forms.Timer
    Friend WithEvents tsslHAServerState As System.Windows.Forms.ToolStripStatusLabel
End Class
