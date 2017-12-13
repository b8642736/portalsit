<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainControl
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

    '注意:  以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLay = New System.Windows.Forms.FlowLayoutPanel()
        Me.tbLogin = New System.Windows.Forms.Button()
        Me.btnCoilNumber = New System.Windows.Forms.Button()
        Me.btnDataDate = New System.Windows.Forms.Button()
        Me.rbAPL1 = New System.Windows.Forms.RadioButton()
        Me.rbAPL2 = New System.Windows.Forms.RadioButton()
        Me.rbBAL = New System.Windows.Forms.RadioButton()
        Me.tbPrint = New System.Windows.Forms.Button()
        Me.lbPage = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lbTitlePosition = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.radBtn_Down = New System.Windows.Forms.RadioButton()
        Me.radBtn_UP = New System.Windows.Forms.RadioButton()
        Me.btnPageDown = New System.Windows.Forms.Button()
        Me.btnPageUP = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpBugEdit = New System.Windows.Forms.TabPage()
        Me.tlpBugEditTable = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpItems = New System.Windows.Forms.TableLayoutPanel()
        Me.VScrollBar1 = New System.Windows.Forms.VScrollBar()
        Me.tpQuickOperator = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.flpQuickOperator = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnInsertBug33s = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnQuckSetAP2AllValues = New System.Windows.Forms.Button()
        Me.tpThicknessEdit = New System.Windows.Forms.TabPage()
        Me.tlpThicknessEditTable = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpThicknessItems = New System.Windows.Forms.TableLayoutPanel()
        Me.tpOtherEdit = New System.Windows.Forms.TabPage()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.lbPos = New System.Windows.Forms.Label()
        Me.lbCoilPosition = New System.Windows.Forms.Label()
        Me.lbMessage = New System.Windows.Forms.Label()
        Me.lbIsRunnCoilMessage = New System.Windows.Forms.Label()
        Me.TimRunTimeReplace = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLay.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpBugEdit.SuspendLayout()
        Me.tlpBugEditTable.SuspendLayout()
        Me.tlpItems.SuspendLayout()
        Me.tpQuickOperator.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.flpQuickOperator.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.tpThicknessEdit.SuspendLayout()
        Me.tlpThicknessEditTable.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLay, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TabControl1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 0, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1495, 662)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'FlowLay
        '
        Me.FlowLay.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLay.Controls.Add(Me.tbLogin)
        Me.FlowLay.Controls.Add(Me.btnCoilNumber)
        Me.FlowLay.Controls.Add(Me.btnDataDate)
        Me.FlowLay.Controls.Add(Me.rbAPL1)
        Me.FlowLay.Controls.Add(Me.rbAPL2)
        Me.FlowLay.Controls.Add(Me.rbBAL)
        Me.FlowLay.Controls.Add(Me.tbPrint)
        Me.FlowLay.Controls.Add(Me.lbPage)
        Me.FlowLay.Controls.Add(Me.btnExit)
        Me.FlowLay.Controls.Add(Me.lbTitlePosition)
        Me.FlowLay.Controls.Add(Me.Panel1)
        Me.FlowLay.Controls.Add(Me.btnPageDown)
        Me.FlowLay.Controls.Add(Me.btnPageUP)
        Me.FlowLay.Location = New System.Drawing.Point(3, 3)
        Me.FlowLay.Name = "FlowLay"
        Me.FlowLay.Size = New System.Drawing.Size(1489, 74)
        Me.FlowLay.TabIndex = 1
        '
        'tbLogin
        '
        Me.tbLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbLogin.Font = New System.Drawing.Font("新細明體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tbLogin.Location = New System.Drawing.Point(3, 3)
        Me.tbLogin.Name = "tbLogin"
        Me.tbLogin.Size = New System.Drawing.Size(159, 68)
        Me.tbLogin.TabIndex = 11
        Me.tbLogin.Text = "登入"
        Me.tbLogin.UseVisualStyleBackColor = True
        '
        'btnCoilNumber
        '
        Me.btnCoilNumber.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCoilNumber.Font = New System.Drawing.Font("新細明體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnCoilNumber.Location = New System.Drawing.Point(168, 3)
        Me.btnCoilNumber.Name = "btnCoilNumber"
        Me.btnCoilNumber.Size = New System.Drawing.Size(105, 68)
        Me.btnCoilNumber.TabIndex = 0
        Me.btnCoilNumber.Text = "鋼捲編號"
        Me.btnCoilNumber.UseVisualStyleBackColor = True
        Me.btnCoilNumber.Visible = False
        '
        'btnDataDate
        '
        Me.btnDataDate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDataDate.Font = New System.Drawing.Font("新細明體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnDataDate.Location = New System.Drawing.Point(279, 3)
        Me.btnDataDate.Name = "btnDataDate"
        Me.btnDataDate.Size = New System.Drawing.Size(105, 68)
        Me.btnDataDate.TabIndex = 7
        Me.btnDataDate.Text = "報表日期"
        Me.btnDataDate.UseVisualStyleBackColor = True
        Me.btnDataDate.Visible = False
        '
        'rbAPL1
        '
        Me.rbAPL1.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbAPL1.Checked = True
        Me.rbAPL1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbAPL1.Font = New System.Drawing.Font("新細明體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rbAPL1.Location = New System.Drawing.Point(390, 3)
        Me.rbAPL1.Name = "rbAPL1"
        Me.rbAPL1.Size = New System.Drawing.Size(105, 68)
        Me.rbAPL1.TabIndex = 2
        Me.rbAPL1.TabStop = True
        Me.rbAPL1.Text = "APL1"
        Me.rbAPL1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbAPL1.UseVisualStyleBackColor = True
        Me.rbAPL1.Visible = False
        '
        'rbAPL2
        '
        Me.rbAPL2.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbAPL2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbAPL2.Font = New System.Drawing.Font("新細明體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rbAPL2.Location = New System.Drawing.Point(501, 3)
        Me.rbAPL2.Name = "rbAPL2"
        Me.rbAPL2.Size = New System.Drawing.Size(105, 68)
        Me.rbAPL2.TabIndex = 3
        Me.rbAPL2.Text = "APL2"
        Me.rbAPL2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbAPL2.UseVisualStyleBackColor = True
        Me.rbAPL2.Visible = False
        '
        'rbBAL
        '
        Me.rbBAL.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbBAL.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbBAL.Font = New System.Drawing.Font("新細明體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rbBAL.Location = New System.Drawing.Point(612, 3)
        Me.rbBAL.Name = "rbBAL"
        Me.rbBAL.Size = New System.Drawing.Size(105, 68)
        Me.rbBAL.TabIndex = 4
        Me.rbBAL.Text = "BAL"
        Me.rbBAL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbBAL.UseVisualStyleBackColor = True
        Me.rbBAL.Visible = False
        '
        'tbPrint
        '
        Me.tbPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbPrint.Font = New System.Drawing.Font("新細明體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tbPrint.Location = New System.Drawing.Point(723, 3)
        Me.tbPrint.Name = "tbPrint"
        Me.tbPrint.Size = New System.Drawing.Size(105, 68)
        Me.tbPrint.TabIndex = 12
        Me.tbPrint.Text = "印表"
        Me.tbPrint.UseVisualStyleBackColor = True
        Me.tbPrint.Visible = False
        '
        'lbPage
        '
        Me.lbPage.Font = New System.Drawing.Font("標楷體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbPage.Location = New System.Drawing.Point(834, 0)
        Me.lbPage.Name = "lbPage"
        Me.lbPage.Size = New System.Drawing.Size(100, 71)
        Me.lbPage.TabIndex = 9
        Me.lbPage.Text = "頁次: 1"
        Me.lbPage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnExit
        '
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExit.Font = New System.Drawing.Font("新細明體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnExit.Location = New System.Drawing.Point(940, 3)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(105, 68)
        Me.btnExit.TabIndex = 10
        Me.btnExit.Text = "離開系統"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lbTitlePosition
        '
        Me.lbTitlePosition.Font = New System.Drawing.Font("標楷體", 21.0!, System.Drawing.FontStyle.Bold)
        Me.lbTitlePosition.Location = New System.Drawing.Point(1051, 0)
        Me.lbTitlePosition.Name = "lbTitlePosition"
        Me.lbTitlePosition.Size = New System.Drawing.Size(118, 71)
        Me.lbTitlePosition.TabIndex = 13
        Me.lbTitlePosition.Text = "米數: 0"
        Me.lbTitlePosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.radBtn_Down)
        Me.Panel1.Controls.Add(Me.radBtn_UP)
        Me.Panel1.Location = New System.Drawing.Point(1175, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(238, 68)
        Me.Panel1.TabIndex = 14
        '
        'radBtn_Down
        '
        Me.radBtn_Down.AutoSize = True
        Me.radBtn_Down.Font = New System.Drawing.Font("標楷體", 28.0!, System.Drawing.FontStyle.Bold)
        Me.radBtn_Down.Location = New System.Drawing.Point(119, 12)
        Me.radBtn_Down.Margin = New System.Windows.Forms.Padding(0)
        Me.radBtn_Down.Name = "radBtn_Down"
        Me.radBtn_Down.Size = New System.Drawing.Size(113, 42)
        Me.radBtn_Down.TabIndex = 4
        Me.radBtn_Down.Text = "下收"
        Me.radBtn_Down.UseVisualStyleBackColor = True
        '
        'radBtn_UP
        '
        Me.radBtn_UP.AutoSize = True
        Me.radBtn_UP.FlatAppearance.BorderSize = 5
        Me.radBtn_UP.Font = New System.Drawing.Font("標楷體", 28.0!, System.Drawing.FontStyle.Bold)
        Me.radBtn_UP.Location = New System.Drawing.Point(5, 12)
        Me.radBtn_UP.Name = "radBtn_UP"
        Me.radBtn_UP.Size = New System.Drawing.Size(113, 42)
        Me.radBtn_UP.TabIndex = 3
        Me.radBtn_UP.Text = "上收"
        Me.radBtn_UP.UseVisualStyleBackColor = True
        '
        'btnPageDown
        '
        Me.btnPageDown.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPageDown.Font = New System.Drawing.Font("新細明體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnPageDown.Location = New System.Drawing.Point(3, 77)
        Me.btnPageDown.Name = "btnPageDown"
        Me.btnPageDown.Size = New System.Drawing.Size(105, 68)
        Me.btnPageDown.TabIndex = 5
        Me.btnPageDown.Text = "下一頁"
        Me.btnPageDown.UseVisualStyleBackColor = True
        Me.btnPageDown.Visible = False
        '
        'btnPageUP
        '
        Me.btnPageUP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPageUP.Font = New System.Drawing.Font("新細明體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnPageUP.Location = New System.Drawing.Point(114, 77)
        Me.btnPageUP.Name = "btnPageUP"
        Me.btnPageUP.Size = New System.Drawing.Size(105, 68)
        Me.btnPageUP.TabIndex = 6
        Me.btnPageUP.Text = "上一頁"
        Me.btnPageUP.UseVisualStyleBackColor = True
        Me.btnPageUP.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tpBugEdit)
        Me.TabControl1.Controls.Add(Me.tpQuickOperator)
        Me.TabControl1.Controls.Add(Me.tpThicknessEdit)
        Me.TabControl1.Controls.Add(Me.tpOtherEdit)
        Me.TabControl1.Font = New System.Drawing.Font("標楷體", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabControl1.ItemSize = New System.Drawing.Size(80, 50)
        Me.TabControl1.Location = New System.Drawing.Point(3, 83)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1489, 556)
        Me.TabControl1.TabIndex = 2
        '
        'tpBugEdit
        '
        Me.tpBugEdit.Controls.Add(Me.tlpBugEditTable)
        Me.tpBugEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tpBugEdit.Font = New System.Drawing.Font("標楷體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tpBugEdit.Location = New System.Drawing.Point(4, 54)
        Me.tpBugEdit.Name = "tpBugEdit"
        Me.tpBugEdit.Padding = New System.Windows.Forms.Padding(3)
        Me.tpBugEdit.Size = New System.Drawing.Size(1481, 498)
        Me.tpBugEdit.TabIndex = 0
        Me.tpBugEdit.Text = "缺陷輸入"
        Me.tpBugEdit.UseVisualStyleBackColor = True
        '
        'tlpBugEditTable
        '
        Me.tlpBugEditTable.ColumnCount = 2
        Me.tlpBugEditTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.tlpBugEditTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
        Me.tlpBugEditTable.Controls.Add(Me.tlpItems, 0, 0)
        Me.tlpBugEditTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpBugEditTable.Location = New System.Drawing.Point(3, 3)
        Me.tlpBugEditTable.Name = "tlpBugEditTable"
        Me.tlpBugEditTable.RowCount = 1
        Me.tlpBugEditTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpBugEditTable.Size = New System.Drawing.Size(1475, 492)
        Me.tlpBugEditTable.TabIndex = 0
        '
        'tlpItems
        '
        Me.tlpItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpItems.ColumnCount = 1
        Me.tlpItems.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpItems.Controls.Add(Me.VScrollBar1, 0, 0)
        Me.tlpItems.Location = New System.Drawing.Point(0, 0)
        Me.tlpItems.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpItems.Name = "tlpItems"
        Me.tlpItems.RowCount = 8
        Me.tlpItems.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.tlpItems.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.tlpItems.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.tlpItems.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.tlpItems.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.tlpItems.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.tlpItems.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.tlpItems.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.tlpItems.Size = New System.Drawing.Size(516, 492)
        Me.tlpItems.TabIndex = 0
        '
        'VScrollBar1
        '
        Me.VScrollBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VScrollBar1.Location = New System.Drawing.Point(484, 0)
        Me.VScrollBar1.Name = "VScrollBar1"
        Me.VScrollBar1.Size = New System.Drawing.Size(32, 61)
        Me.VScrollBar1.TabIndex = 0
        '
        'tpQuickOperator
        '
        Me.tpQuickOperator.Controls.Add(Me.TableLayoutPanel2)
        Me.tpQuickOperator.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tpQuickOperator.Location = New System.Drawing.Point(4, 54)
        Me.tpQuickOperator.Name = "tpQuickOperator"
        Me.tpQuickOperator.Padding = New System.Windows.Forms.Padding(3)
        Me.tpQuickOperator.Size = New System.Drawing.Size(1481, 498)
        Me.tpQuickOperator.TabIndex = 4
        Me.tpQuickOperator.Text = "快速操作"
        Me.tpQuickOperator.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.flpQuickOperator, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel2, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1475, 492)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'flpQuickOperator
        '
        Me.flpQuickOperator.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpQuickOperator.Controls.Add(Me.btnInsertBug33s)
        Me.flpQuickOperator.Location = New System.Drawing.Point(3, 83)
        Me.flpQuickOperator.Name = "flpQuickOperator"
        Me.flpQuickOperator.Size = New System.Drawing.Size(1469, 406)
        Me.flpQuickOperator.TabIndex = 1
        '
        'btnInsertBug33s
        '
        Me.btnInsertBug33s.Location = New System.Drawing.Point(3, 3)
        Me.btnInsertBug33s.Name = "btnInsertBug33s"
        Me.btnInsertBug33s.Size = New System.Drawing.Size(272, 48)
        Me.btnInsertBug33s.TabIndex = 0
        Me.btnInsertBug33s.Text = "加入常用缺陷33共4組"
        Me.btnInsertBug33s.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnQuckSetAP2AllValues)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(1469, 74)
        Me.FlowLayoutPanel2.TabIndex = 2
        '
        'btnQuckSetAP2AllValues
        '
        Me.btnQuckSetAP2AllValues.Location = New System.Drawing.Point(3, 3)
        Me.btnQuckSetAP2AllValues.Name = "btnQuckSetAP2AllValues"
        Me.btnQuckSetAP2AllValues.Size = New System.Drawing.Size(170, 71)
        Me.btnQuckSetAP2AllValues.TabIndex = 0
        Me.btnQuckSetAP2AllValues.Text = "環境預設"
        Me.btnQuckSetAP2AllValues.UseVisualStyleBackColor = True
        '
        'tpThicknessEdit
        '
        Me.tpThicknessEdit.Controls.Add(Me.tlpThicknessEditTable)
        Me.tpThicknessEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tpThicknessEdit.Font = New System.Drawing.Font("標楷體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tpThicknessEdit.Location = New System.Drawing.Point(4, 54)
        Me.tpThicknessEdit.Name = "tpThicknessEdit"
        Me.tpThicknessEdit.Padding = New System.Windows.Forms.Padding(3)
        Me.tpThicknessEdit.Size = New System.Drawing.Size(1481, 498)
        Me.tpThicknessEdit.TabIndex = 1
        Me.tpThicknessEdit.Text = "鋼捲厚度"
        Me.tpThicknessEdit.UseVisualStyleBackColor = True
        '
        'tlpThicknessEditTable
        '
        Me.tlpThicknessEditTable.ColumnCount = 2
        Me.tlpThicknessEditTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.tlpThicknessEditTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
        Me.tlpThicknessEditTable.Controls.Add(Me.tlpThicknessItems, 0, 0)
        Me.tlpThicknessEditTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpThicknessEditTable.Location = New System.Drawing.Point(3, 3)
        Me.tlpThicknessEditTable.Name = "tlpThicknessEditTable"
        Me.tlpThicknessEditTable.RowCount = 1
        Me.tlpThicknessEditTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpThicknessEditTable.Size = New System.Drawing.Size(1475, 492)
        Me.tlpThicknessEditTable.TabIndex = 1
        '
        'tlpThicknessItems
        '
        Me.tlpThicknessItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpThicknessItems.ColumnCount = 1
        Me.tlpThicknessItems.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpThicknessItems.Location = New System.Drawing.Point(3, 3)
        Me.tlpThicknessItems.Name = "tlpThicknessItems"
        Me.tlpThicknessItems.RowCount = 9
        Me.tlpThicknessItems.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.36735!))
        Me.tlpThicknessItems.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.20408!))
        Me.tlpThicknessItems.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.20408!))
        Me.tlpThicknessItems.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.20408!))
        Me.tlpThicknessItems.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.20408!))
        Me.tlpThicknessItems.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.20408!))
        Me.tlpThicknessItems.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.20408!))
        Me.tlpThicknessItems.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.20408!))
        Me.tlpThicknessItems.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.20408!))
        Me.tlpThicknessItems.Size = New System.Drawing.Size(510, 486)
        Me.tlpThicknessItems.TabIndex = 0
        '
        'tpOtherEdit
        '
        Me.tpOtherEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tpOtherEdit.Location = New System.Drawing.Point(4, 54)
        Me.tpOtherEdit.Name = "tpOtherEdit"
        Me.tpOtherEdit.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOtherEdit.Size = New System.Drawing.Size(1481, 498)
        Me.tpOtherEdit.TabIndex = 5
        Me.tpOtherEdit.Text = "其它資訊"
        Me.tpOtherEdit.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.Controls.Add(Me.lbPos)
        Me.FlowLayoutPanel1.Controls.Add(Me.lbCoilPosition)
        Me.FlowLayoutPanel1.Controls.Add(Me.lbMessage)
        Me.FlowLayoutPanel1.Controls.Add(Me.lbIsRunnCoilMessage)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 642)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1495, 20)
        Me.FlowLayoutPanel1.TabIndex = 3
        '
        'lbPos
        '
        Me.lbPos.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbPos.AutoSize = True
        Me.lbPos.Font = New System.Drawing.Font("標楷體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbPos.ForeColor = System.Drawing.Color.Blue
        Me.lbPos.Location = New System.Drawing.Point(3, 0)
        Me.lbPos.Name = "lbPos"
        Me.lbPos.Size = New System.Drawing.Size(175, 13)
        Me.lbPos.TabIndex = 5
        Me.lbPos.Text = "鋼捲位置(APL1/APL2/BAL):"
        '
        'lbCoilPosition
        '
        Me.lbCoilPosition.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbCoilPosition.AutoSize = True
        Me.lbCoilPosition.Font = New System.Drawing.Font("標楷體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbCoilPosition.ForeColor = System.Drawing.Color.Blue
        Me.lbCoilPosition.Location = New System.Drawing.Point(184, 0)
        Me.lbCoilPosition.Name = "lbCoilPosition"
        Me.lbCoilPosition.Size = New System.Drawing.Size(42, 13)
        Me.lbCoilPosition.TabIndex = 6
        Me.lbCoilPosition.Text = "0/0/0"
        '
        'lbMessage
        '
        Me.lbMessage.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbMessage.AutoSize = True
        Me.lbMessage.Font = New System.Drawing.Font("標楷體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbMessage.ForeColor = System.Drawing.Color.Red
        Me.lbMessage.Location = New System.Drawing.Point(232, 0)
        Me.lbMessage.Name = "lbMessage"
        Me.lbMessage.Size = New System.Drawing.Size(70, 13)
        Me.lbMessage.TabIndex = 4
        Me.lbMessage.Text = "執行訊息!"
        '
        'lbIsRunnCoilMessage
        '
        Me.lbIsRunnCoilMessage.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbIsRunnCoilMessage.AutoSize = True
        Me.lbIsRunnCoilMessage.Font = New System.Drawing.Font("標楷體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbIsRunnCoilMessage.ForeColor = System.Drawing.Color.Green
        Me.lbIsRunnCoilMessage.Location = New System.Drawing.Point(308, 0)
        Me.lbIsRunnCoilMessage.Name = "lbIsRunnCoilMessage"
        Me.lbIsRunnCoilMessage.Size = New System.Drawing.Size(0, 13)
        Me.lbIsRunnCoilMessage.TabIndex = 7
        '
        'TimRunTimeReplace
        '
        Me.TimRunTimeReplace.Enabled = True
        Me.TimRunTimeReplace.Interval = 1000
        '
        'MainControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "MainControl"
        Me.Size = New System.Drawing.Size(1495, 662)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.FlowLay.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tpBugEdit.ResumeLayout(False)
        Me.tlpBugEditTable.ResumeLayout(False)
        Me.tlpItems.ResumeLayout(False)
        Me.tpQuickOperator.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.flpQuickOperator.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.tpThicknessEdit.ResumeLayout(False)
        Me.tlpThicknessEditTable.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpItems As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowLay As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnCoilNumber As System.Windows.Forms.Button
    Friend WithEvents rbAPL1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbAPL2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbBAL As System.Windows.Forms.RadioButton
    Friend WithEvents btnPageDown As System.Windows.Forms.Button
    Friend WithEvents btnPageUP As System.Windows.Forms.Button
    Friend WithEvents btnDataDate As System.Windows.Forms.Button
    Friend WithEvents lbPage As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents tbLogin As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpBugEdit As System.Windows.Forms.TabPage
    Friend WithEvents tpThicknessEdit As System.Windows.Forms.TabPage
    Friend WithEvents tlpBugEditTable As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpThicknessEditTable As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpThicknessItems As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tpQuickOperator As System.Windows.Forms.TabPage
    Friend WithEvents btnInsertBug33s As System.Windows.Forms.Button
    Friend WithEvents tpOtherEdit As System.Windows.Forms.TabPage
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lbPos As System.Windows.Forms.Label
    Friend WithEvents lbMessage As System.Windows.Forms.Label
    Friend WithEvents lbCoilPosition As System.Windows.Forms.Label
    Friend WithEvents TimRunTimeReplace As System.Windows.Forms.Timer
    Friend WithEvents flpQuickOperator As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents tbPrint As System.Windows.Forms.Button
    Friend WithEvents lbIsRunnCoilMessage As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnQuckSetAP2AllValues As System.Windows.Forms.Button
    Friend WithEvents lbTitlePosition As System.Windows.Forms.Label
    Friend WithEvents VScrollBar1 As System.Windows.Forms.VScrollBar
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents radBtn_UP As System.Windows.Forms.RadioButton
    Friend WithEvents radBtn_Down As System.Windows.Forms.RadioButton

End Class
