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

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SQLServer與AS400資料轉換ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.全部啟動 = New System.Windows.Forms.ToolStripMenuItem()
        Me.軋鋼排程轉SQLServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.煉鋼成份轉AS400ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SQLServer與AS400資料轉換ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(593, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SQLServer與AS400資料轉換ToolStripMenuItem
        '
        Me.SQLServer與AS400資料轉換ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.全部啟動, Me.軋鋼排程轉SQLServerToolStripMenuItem, Me.煉鋼成份轉AS400ToolStripMenuItem})
        Me.SQLServer與AS400資料轉換ToolStripMenuItem.Name = "SQLServer與AS400資料轉換ToolStripMenuItem"
        Me.SQLServer與AS400資料轉換ToolStripMenuItem.Size = New System.Drawing.Size(174, 20)
        Me.SQLServer與AS400資料轉換ToolStripMenuItem.Text = "SQLServer與AS400資料轉換"
        '
        '全部啟動
        '
        Me.全部啟動.Name = "全部啟動"
        Me.全部啟動.Size = New System.Drawing.Size(215, 22)
        Me.全部啟動.Text = "全部轉換啟動"
        '
        '軋鋼排程轉SQLServerToolStripMenuItem
        '
        Me.軋鋼排程轉SQLServerToolStripMenuItem.Name = "軋鋼排程轉SQLServerToolStripMenuItem"
        Me.軋鋼排程轉SQLServerToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.軋鋼排程轉SQLServerToolStripMenuItem.Text = "400軋鋼排程轉SQLServer"
        '
        '煉鋼成份轉AS400ToolStripMenuItem
        '
        Me.煉鋼成份轉AS400ToolStripMenuItem.Name = "煉鋼成份轉AS400ToolStripMenuItem"
        Me.煉鋼成份轉AS400ToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.煉鋼成份轉AS400ToolStripMenuItem.Text = "煉鋼成份轉AS400"
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(593, 408)
        Me.Panel1.TabIndex = 1
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 432)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MainForm1"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents SQLServer與AS400資料轉換ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 全部啟動 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 軋鋼排程轉SQLServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 煉鋼成份轉AS400ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
