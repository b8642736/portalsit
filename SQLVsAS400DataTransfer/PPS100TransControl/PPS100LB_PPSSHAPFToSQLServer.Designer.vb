<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PPS100LB_PPSSHAPFToSQLServer
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.tbAddTimeByEveryDay = New System.Windows.Forms.Button()
        Me.tbAddTimeByOneDay = New System.Windows.Forms.Button()
        Me.tbRemoveSet = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.NowRunning = New System.Windows.Forms.Button()
        Me.tbStartRun = New System.Windows.Forms.Button()
        Me.btStopRun = New System.Windows.Forms.Button()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.rtbMessage = New System.Windows.Forms.RichTextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.rtbMsgHistory = New System.Windows.Forms.RichTextBox()
        Me.btnClearHistory = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.DBSchedualRefreshTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(663, 504)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SplitContainer1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(655, 478)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "AS400資料轉SQLServer"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.rtbMessage)
        Me.SplitContainer1.Size = New System.Drawing.Size(649, 472)
        Me.SplitContainer1.SplitterDistance = 141
        Me.SplitContainer1.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.18487!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.54622!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.43697!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.DateTimePicker1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DateTimePicker2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbAddTimeByEveryDay, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.tbAddTimeByOneDay, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.tbRemoveSet, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.ListBox1, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.NowRunning, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.tbStartRun, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.btStopRun, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.LinkLabel1, 2, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(649, 141)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(84, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "轉換日期:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(84, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "轉換時間:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = ""
        Me.DateTimePicker1.Location = New System.Drawing.Point(146, 3)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(159, 22)
        Me.DateTimePicker1.TabIndex = 2
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CustomFormat = "hh:mm:ss"
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DateTimePicker2.Location = New System.Drawing.Point(146, 27)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.ShowUpDown = True
        Me.DateTimePicker2.Size = New System.Drawing.Size(159, 22)
        Me.DateTimePicker2.TabIndex = 3
        '
        'tbAddTimeByEveryDay
        '
        Me.tbAddTimeByEveryDay.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbAddTimeByEveryDay.Location = New System.Drawing.Point(143, 49)
        Me.tbAddTimeByEveryDay.Margin = New System.Windows.Forms.Padding(0)
        Me.tbAddTimeByEveryDay.Name = "tbAddTimeByEveryDay"
        Me.tbAddTimeByEveryDay.Size = New System.Drawing.Size(165, 22)
        Me.tbAddTimeByEveryDay.TabIndex = 4
        Me.tbAddTimeByEveryDay.Text = "加入每日轉換時間"
        Me.tbAddTimeByEveryDay.UseVisualStyleBackColor = True
        '
        'tbAddTimeByOneDay
        '
        Me.tbAddTimeByOneDay.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbAddTimeByOneDay.Location = New System.Drawing.Point(143, 71)
        Me.tbAddTimeByOneDay.Margin = New System.Windows.Forms.Padding(0)
        Me.tbAddTimeByOneDay.Name = "tbAddTimeByOneDay"
        Me.tbAddTimeByOneDay.Size = New System.Drawing.Size(165, 24)
        Me.tbAddTimeByOneDay.TabIndex = 6
        Me.tbAddTimeByOneDay.Text = "加入特定轉換日期時間"
        Me.tbAddTimeByOneDay.UseVisualStyleBackColor = True
        '
        'tbRemoveSet
        '
        Me.tbRemoveSet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbRemoveSet.Enabled = False
        Me.tbRemoveSet.Location = New System.Drawing.Point(143, 95)
        Me.tbRemoveSet.Margin = New System.Windows.Forms.Padding(0)
        Me.tbRemoveSet.Name = "tbRemoveSet"
        Me.tbRemoveSet.Size = New System.Drawing.Size(165, 24)
        Me.tbRemoveSet.TabIndex = 5
        Me.tbRemoveSet.Text = "移除設定"
        Me.tbRemoveSet.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 12
        Me.ListBox1.Location = New System.Drawing.Point(308, 24)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.ListBox1.Name = "ListBox1"
        Me.TableLayoutPanel1.SetRowSpan(Me.ListBox1, 5)
        Me.ListBox1.Size = New System.Drawing.Size(341, 117)
        Me.ListBox1.TabIndex = 7
        '
        'NowRunning
        '
        Me.NowRunning.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NowRunning.Location = New System.Drawing.Point(0, 49)
        Me.NowRunning.Margin = New System.Windows.Forms.Padding(0)
        Me.NowRunning.Name = "NowRunning"
        Me.TableLayoutPanel1.SetRowSpan(Me.NowRunning, 3)
        Me.NowRunning.Size = New System.Drawing.Size(143, 70)
        Me.NowRunning.TabIndex = 11
        Me.NowRunning.Text = "立刻執行資料轉換"
        Me.NowRunning.UseVisualStyleBackColor = True
        '
        'tbStartRun
        '
        Me.tbStartRun.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbStartRun.Location = New System.Drawing.Point(0, 119)
        Me.tbStartRun.Margin = New System.Windows.Forms.Padding(0)
        Me.tbStartRun.Name = "tbStartRun"
        Me.tbStartRun.Size = New System.Drawing.Size(143, 22)
        Me.tbStartRun.TabIndex = 9
        Me.tbStartRun.Text = "開始執行排程"
        Me.tbStartRun.UseVisualStyleBackColor = True
        '
        'btStopRun
        '
        Me.btStopRun.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btStopRun.Location = New System.Drawing.Point(143, 119)
        Me.btStopRun.Margin = New System.Windows.Forms.Padding(0)
        Me.btStopRun.Name = "btStopRun"
        Me.btStopRun.Size = New System.Drawing.Size(165, 22)
        Me.btStopRun.TabIndex = 10
        Me.btStopRun.Text = "終止執行排程"
        Me.btStopRun.UseVisualStyleBackColor = True
        Me.btStopRun.Visible = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(311, 6)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(335, 12)
        Me.LinkLabel1.TabIndex = 12
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "設定轉換日期及時間 (按一下由資料庫更新)"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rtbMessage
        '
        Me.rtbMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbMessage.Location = New System.Drawing.Point(0, 0)
        Me.rtbMessage.Name = "rtbMessage"
        Me.rtbMessage.Size = New System.Drawing.Size(649, 327)
        Me.rtbMessage.TabIndex = 0
        Me.rtbMessage.Text = ""
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(655, 478)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "資料轉換記錄"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.rtbMsgHistory, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.btnClearHistory, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.548596!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.4514!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(649, 472)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'rtbMsgHistory
        '
        Me.rtbMsgHistory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbMsgHistory.Location = New System.Drawing.Point(3, 48)
        Me.rtbMsgHistory.Name = "rtbMsgHistory"
        Me.rtbMsgHistory.Size = New System.Drawing.Size(643, 421)
        Me.rtbMsgHistory.TabIndex = 0
        Me.rtbMsgHistory.Text = ""
        '
        'btnClearHistory
        '
        Me.btnClearHistory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearHistory.Location = New System.Drawing.Point(3, 3)
        Me.btnClearHistory.Name = "btnClearHistory"
        Me.btnClearHistory.Size = New System.Drawing.Size(643, 39)
        Me.btnClearHistory.TabIndex = 0
        Me.btnClearHistory.Text = "清除記錄"
        Me.btnClearHistory.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'DBSchedualRefreshTimer
        '
        Me.DBSchedualRefreshTimer.Enabled = True
        Me.DBSchedualRefreshTimer.Interval = 600000
        '
        'PPS100LB_PPSSHAPFToSQLServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "PPS100LB_PPSSHAPFToSQLServer"
        Me.Size = New System.Drawing.Size(663, 504)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rtbMessage As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents tbAddTimeByEveryDay As System.Windows.Forms.Button
    Friend WithEvents tbAddTimeByOneDay As System.Windows.Forms.Button
    Friend WithEvents tbRemoveSet As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents tbStartRun As System.Windows.Forms.Button
    Friend WithEvents btStopRun As System.Windows.Forms.Button
    Friend WithEvents NowRunning As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rtbMsgHistory As System.Windows.Forms.RichTextBox
    Friend WithEvents btnClearHistory As System.Windows.Forms.Button
    Friend WithEvents DBSchedualRefreshTimer As System.Windows.Forms.Timer
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel

End Class
