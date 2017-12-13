<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EquipmentDataReceive
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
        Me.components = New System.ComponentModel.Container
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.DEquipConnMsg = New System.Windows.Forms.Label
        Me.CSConnMsg = New System.Windows.Forms.Label
        Me.XrayConnMsg = New System.Windows.Forms.Label
        Me.ONConnMsg = New System.Windows.Forms.Label
        Me.jy5ConnMsg = New System.Windows.Forms.Label
        Me.jy4ConnMsg = New System.Windows.Forms.Label
        Me.jy3ConnMsg = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.btnShowDetailJY1 = New System.Windows.Forms.Button
        Me.btnShowDetailJY3 = New System.Windows.Forms.Button
        Me.btnShowDetailJY4 = New System.Windows.Forms.Button
        Me.btnShowDetailJY5 = New System.Windows.Forms.Button
        Me.btnShowDetailOAndN = New System.Windows.Forms.Button
        Me.btnShowDetailXRay = New System.Windows.Forms.Button
        Me.btnShowDetailCS = New System.Windows.Forms.Button
        Me.btnShowDetailD = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.tbReceiveData = New System.Windows.Forms.RichTextBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.RTBData = New System.Windows.Forms.RichTextBox
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.rbtErrorMessage = New System.Windows.Forms.RichTextBox
        Me.btnClearErrorMessage = New System.Windows.Forms.Button
        Me.jy1ConnMsg = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.btnResetAllComPort = New System.Windows.Forms.Button
        Me.spJY1 = New System.IO.Ports.SerialPort(Me.components)
        Me.spJY3 = New System.IO.Ports.SerialPort(Me.components)
        Me.spJY5 = New System.IO.Ports.SerialPort(Me.components)
        Me.spJY4 = New System.IO.Ports.SerialPort(Me.components)
        Me.spOxygenNitrogen = New System.IO.Ports.SerialPort(Me.components)
        Me.spXray = New System.IO.Ports.SerialPort(Me.components)
        Me.spCarbonSulfur = New System.IO.Ports.SerialPort(Me.components)
        Me.spD = New System.IO.Ports.SerialPort(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel1.Controls.Add(Me.DEquipConnMsg, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.CSConnMsg, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.XrayConnMsg, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.ONConnMsg, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.jy5ConnMsg, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.jy4ConnMsg, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.jy3ConnMsg, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.Label12, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnShowDetailJY1, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnShowDetailJY3, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnShowDetailJY4, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnShowDetailJY5, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btnShowDetailOAndN, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.btnShowDetailXRay, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.btnShowDetailCS, 2, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.btnShowDetailD, 2, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.TabControl1, 0, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.jy1ConnMsg, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.btnResetAllComPort, 1, 9)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 11
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(565, 392)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'DEquipConnMsg
        '
        Me.DEquipConnMsg.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DEquipConnMsg.AutoSize = True
        Me.DEquipConnMsg.Location = New System.Drawing.Point(191, 164)
        Me.DEquipConnMsg.Name = "DEquipConnMsg"
        Me.DEquipConnMsg.Size = New System.Drawing.Size(182, 12)
        Me.DEquipConnMsg.TabIndex = 28
        Me.DEquipConnMsg.Text = "Label11"
        Me.DEquipConnMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CSConnMsg
        '
        Me.CSConnMsg.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CSConnMsg.AutoSize = True
        Me.CSConnMsg.Location = New System.Drawing.Point(191, 144)
        Me.CSConnMsg.Name = "CSConnMsg"
        Me.CSConnMsg.Size = New System.Drawing.Size(182, 12)
        Me.CSConnMsg.TabIndex = 27
        Me.CSConnMsg.Text = "Label11"
        Me.CSConnMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'XrayConnMsg
        '
        Me.XrayConnMsg.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XrayConnMsg.AutoSize = True
        Me.XrayConnMsg.Location = New System.Drawing.Point(191, 124)
        Me.XrayConnMsg.Name = "XrayConnMsg"
        Me.XrayConnMsg.Size = New System.Drawing.Size(182, 12)
        Me.XrayConnMsg.TabIndex = 26
        Me.XrayConnMsg.Text = "Label11"
        Me.XrayConnMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ONConnMsg
        '
        Me.ONConnMsg.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ONConnMsg.AutoSize = True
        Me.ONConnMsg.Location = New System.Drawing.Point(191, 104)
        Me.ONConnMsg.Name = "ONConnMsg"
        Me.ONConnMsg.Size = New System.Drawing.Size(182, 12)
        Me.ONConnMsg.TabIndex = 25
        Me.ONConnMsg.Text = "Label11"
        Me.ONConnMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'jy5ConnMsg
        '
        Me.jy5ConnMsg.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.jy5ConnMsg.AutoSize = True
        Me.jy5ConnMsg.Location = New System.Drawing.Point(191, 84)
        Me.jy5ConnMsg.Name = "jy5ConnMsg"
        Me.jy5ConnMsg.Size = New System.Drawing.Size(182, 12)
        Me.jy5ConnMsg.TabIndex = 24
        Me.jy5ConnMsg.Text = "Label11"
        Me.jy5ConnMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'jy4ConnMsg
        '
        Me.jy4ConnMsg.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.jy4ConnMsg.AutoSize = True
        Me.jy4ConnMsg.Location = New System.Drawing.Point(191, 64)
        Me.jy4ConnMsg.Name = "jy4ConnMsg"
        Me.jy4ConnMsg.Size = New System.Drawing.Size(182, 12)
        Me.jy4ConnMsg.TabIndex = 23
        Me.jy4ConnMsg.Text = "Label11"
        Me.jy4ConnMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'jy3ConnMsg
        '
        Me.jy3ConnMsg.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.jy3ConnMsg.AutoSize = True
        Me.jy3ConnMsg.Location = New System.Drawing.Point(191, 44)
        Me.jy3ConnMsg.Name = "jy3ConnMsg"
        Me.jy3ConnMsg.Size = New System.Drawing.Size(182, 12)
        Me.jy3ConnMsg.TabIndex = 22
        Me.jy3ConnMsg.Text = "Label11"
        Me.jy3ConnMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(191, 4)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(182, 12)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "連線狀態"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 4)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(182, 12)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "儀器名稱"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(117, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "JY#1分光儀:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(117, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "JY#3分光儀:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(117, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "JY#4分光儀:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(117, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 12)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "JY#5分光儀:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(129, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 12)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "氮氧分析:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(151, 124)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 12)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "X ray:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(129, 144)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 12)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "碳硫分析:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(142, 164)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 12)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "儀器 D:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(379, 4)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(183, 12)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "顯示詳細資料"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnShowDetailJY1
        '
        Me.btnShowDetailJY1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShowDetailJY1.BackColor = System.Drawing.SystemColors.Control
        Me.btnShowDetailJY1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShowDetailJY1.Location = New System.Drawing.Point(376, 20)
        Me.btnShowDetailJY1.Margin = New System.Windows.Forms.Padding(0)
        Me.btnShowDetailJY1.Name = "btnShowDetailJY1"
        Me.btnShowDetailJY1.Size = New System.Drawing.Size(189, 20)
        Me.btnShowDetailJY1.TabIndex = 12
        Me.btnShowDetailJY1.Text = "顯示"
        Me.btnShowDetailJY1.UseVisualStyleBackColor = True
        '
        'btnShowDetailJY3
        '
        Me.btnShowDetailJY3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShowDetailJY3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShowDetailJY3.Location = New System.Drawing.Point(376, 40)
        Me.btnShowDetailJY3.Margin = New System.Windows.Forms.Padding(0)
        Me.btnShowDetailJY3.Name = "btnShowDetailJY3"
        Me.btnShowDetailJY3.Size = New System.Drawing.Size(189, 20)
        Me.btnShowDetailJY3.TabIndex = 13
        Me.btnShowDetailJY3.Text = "顯示"
        Me.btnShowDetailJY3.UseVisualStyleBackColor = True
        '
        'btnShowDetailJY4
        '
        Me.btnShowDetailJY4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShowDetailJY4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShowDetailJY4.Location = New System.Drawing.Point(376, 60)
        Me.btnShowDetailJY4.Margin = New System.Windows.Forms.Padding(0)
        Me.btnShowDetailJY4.Name = "btnShowDetailJY4"
        Me.btnShowDetailJY4.Size = New System.Drawing.Size(189, 20)
        Me.btnShowDetailJY4.TabIndex = 14
        Me.btnShowDetailJY4.Text = "顯示"
        Me.btnShowDetailJY4.UseVisualStyleBackColor = True
        '
        'btnShowDetailJY5
        '
        Me.btnShowDetailJY5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShowDetailJY5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShowDetailJY5.Location = New System.Drawing.Point(376, 80)
        Me.btnShowDetailJY5.Margin = New System.Windows.Forms.Padding(0)
        Me.btnShowDetailJY5.Name = "btnShowDetailJY5"
        Me.btnShowDetailJY5.Size = New System.Drawing.Size(189, 20)
        Me.btnShowDetailJY5.TabIndex = 15
        Me.btnShowDetailJY5.Text = "顯示"
        Me.btnShowDetailJY5.UseVisualStyleBackColor = True
        '
        'btnShowDetailOAndN
        '
        Me.btnShowDetailOAndN.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShowDetailOAndN.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShowDetailOAndN.Location = New System.Drawing.Point(376, 100)
        Me.btnShowDetailOAndN.Margin = New System.Windows.Forms.Padding(0)
        Me.btnShowDetailOAndN.Name = "btnShowDetailOAndN"
        Me.btnShowDetailOAndN.Size = New System.Drawing.Size(189, 20)
        Me.btnShowDetailOAndN.TabIndex = 16
        Me.btnShowDetailOAndN.Text = "顯示"
        Me.btnShowDetailOAndN.UseVisualStyleBackColor = True
        '
        'btnShowDetailXRay
        '
        Me.btnShowDetailXRay.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShowDetailXRay.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShowDetailXRay.Location = New System.Drawing.Point(376, 120)
        Me.btnShowDetailXRay.Margin = New System.Windows.Forms.Padding(0)
        Me.btnShowDetailXRay.Name = "btnShowDetailXRay"
        Me.btnShowDetailXRay.Size = New System.Drawing.Size(189, 20)
        Me.btnShowDetailXRay.TabIndex = 17
        Me.btnShowDetailXRay.Text = "顯示"
        Me.btnShowDetailXRay.UseVisualStyleBackColor = True
        '
        'btnShowDetailCS
        '
        Me.btnShowDetailCS.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShowDetailCS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShowDetailCS.Location = New System.Drawing.Point(376, 140)
        Me.btnShowDetailCS.Margin = New System.Windows.Forms.Padding(0)
        Me.btnShowDetailCS.Name = "btnShowDetailCS"
        Me.btnShowDetailCS.Size = New System.Drawing.Size(189, 20)
        Me.btnShowDetailCS.TabIndex = 18
        Me.btnShowDetailCS.Text = "顯示"
        Me.btnShowDetailCS.UseVisualStyleBackColor = True
        '
        'btnShowDetailD
        '
        Me.btnShowDetailD.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShowDetailD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShowDetailD.Location = New System.Drawing.Point(376, 160)
        Me.btnShowDetailD.Margin = New System.Windows.Forms.Padding(0)
        Me.btnShowDetailD.Name = "btnShowDetailD"
        Me.btnShowDetailD.Size = New System.Drawing.Size(189, 20)
        Me.btnShowDetailD.TabIndex = 19
        Me.btnShowDetailD.Text = "顯示"
        Me.btnShowDetailD.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.TabControl1, 3)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(3, 203)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(559, 186)
        Me.TabControl1.TabIndex = 20
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.tbReceiveData)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(551, 160)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "詳細資料"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'tbReceiveData
        '
        Me.tbReceiveData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbReceiveData.Location = New System.Drawing.Point(3, 3)
        Me.tbReceiveData.Name = "tbReceiveData"
        Me.tbReceiveData.Size = New System.Drawing.Size(545, 154)
        Me.tbReceiveData.TabIndex = 0
        Me.tbReceiveData.Text = ""
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.RTBData)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(551, 160)
        Me.TabPage2.TabIndex = 3
        Me.TabPage2.Text = "接收資料"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'RTBData
        '
        Me.RTBData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RTBData.Location = New System.Drawing.Point(0, 0)
        Me.RTBData.Name = "RTBData"
        Me.RTBData.Size = New System.Drawing.Size(551, 160)
        Me.RTBData.TabIndex = 0
        Me.RTBData.Text = ""
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(551, 160)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "接收發錯誤記錄"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.rbtErrorMessage, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.btnClearErrorMessage, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(551, 160)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'rbtErrorMessage
        '
        Me.rbtErrorMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbtErrorMessage.Location = New System.Drawing.Point(3, 43)
        Me.rbtErrorMessage.Name = "rbtErrorMessage"
        Me.rbtErrorMessage.ReadOnly = True
        Me.rbtErrorMessage.Size = New System.Drawing.Size(545, 114)
        Me.rbtErrorMessage.TabIndex = 0
        Me.rbtErrorMessage.Text = ""
        '
        'btnClearErrorMessage
        '
        Me.btnClearErrorMessage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearErrorMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnClearErrorMessage.Location = New System.Drawing.Point(3, 3)
        Me.btnClearErrorMessage.Name = "btnClearErrorMessage"
        Me.btnClearErrorMessage.Size = New System.Drawing.Size(545, 34)
        Me.btnClearErrorMessage.TabIndex = 1
        Me.btnClearErrorMessage.Text = "清除錯誤記錄"
        Me.btnClearErrorMessage.UseVisualStyleBackColor = True
        '
        'jy1ConnMsg
        '
        Me.jy1ConnMsg.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.jy1ConnMsg.AutoSize = True
        Me.jy1ConnMsg.Location = New System.Drawing.Point(191, 24)
        Me.jy1ConnMsg.Name = "jy1ConnMsg"
        Me.jy1ConnMsg.Size = New System.Drawing.Size(182, 12)
        Me.jy1ConnMsg.TabIndex = 21
        Me.jy1ConnMsg.Text = "Label11"
        Me.jy1ConnMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(129, 184)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 12)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "其它控制:"
        '
        'btnResetAllComPort
        '
        Me.btnResetAllComPort.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnResetAllComPort.Location = New System.Drawing.Point(188, 180)
        Me.btnResetAllComPort.Margin = New System.Windows.Forms.Padding(0)
        Me.btnResetAllComPort.Name = "btnResetAllComPort"
        Me.btnResetAllComPort.Size = New System.Drawing.Size(142, 20)
        Me.btnResetAllComPort.TabIndex = 30
        Me.btnResetAllComPort.Text = "重設所有通訊連線"
        Me.btnResetAllComPort.UseVisualStyleBackColor = True
        '
        'spJY1
        '
        '
        'spJY3
        '
        Me.spJY3.DataBits = 7
        Me.spJY3.Parity = System.IO.Ports.Parity.Even
        Me.spJY3.PortName = "COM11"
        '
        'spJY5
        '
        Me.spJY5.PortName = "COM13"
        Me.spJY5.StopBits = System.IO.Ports.StopBits.Two
        '
        'spJY4
        '
        Me.spJY4.PortName = "COM12"
        '
        'spOxygenNitrogen
        '
        Me.spOxygenNitrogen.BaudRate = 2400
        Me.spOxygenNitrogen.DataBits = 7
        Me.spOxygenNitrogen.Parity = System.IO.Ports.Parity.Odd
        Me.spOxygenNitrogen.PortName = "COM14"
        Me.spOxygenNitrogen.StopBits = System.IO.Ports.StopBits.Two
        '
        'spXray
        '
        Me.spXray.PortName = "COM4"
        '
        'spCarbonSulfur
        '
        Me.spCarbonSulfur.PortName = "COM5"
        '
        'spD
        '
        Me.spD.PortName = "COM5"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'EquipmentDataReceive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "EquipmentDataReceive"
        Me.Size = New System.Drawing.Size(565, 392)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents spJY1 As System.IO.Ports.SerialPort
    Friend WithEvents spJY3 As System.IO.Ports.SerialPort
    Friend WithEvents spJY5 As System.IO.Ports.SerialPort
    Friend WithEvents spJY4 As System.IO.Ports.SerialPort
    Friend WithEvents spOxygenNitrogen As System.IO.Ports.SerialPort
    Friend WithEvents spXray As System.IO.Ports.SerialPort
    Friend WithEvents spCarbonSulfur As System.IO.Ports.SerialPort
    Friend WithEvents spD As System.IO.Ports.SerialPort
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnShowDetailJY1 As System.Windows.Forms.Button
    Friend WithEvents btnShowDetailJY3 As System.Windows.Forms.Button
    Friend WithEvents btnShowDetailJY4 As System.Windows.Forms.Button
    Friend WithEvents btnShowDetailJY5 As System.Windows.Forms.Button
    Friend WithEvents btnShowDetailOAndN As System.Windows.Forms.Button
    Friend WithEvents btnShowDetailXRay As System.Windows.Forms.Button
    Friend WithEvents btnShowDetailCS As System.Windows.Forms.Button
    Friend WithEvents btnShowDetailD As System.Windows.Forms.Button
    Friend WithEvents DEquipConnMsg As System.Windows.Forms.Label
    Friend WithEvents CSConnMsg As System.Windows.Forms.Label
    Friend WithEvents XrayConnMsg As System.Windows.Forms.Label
    Friend WithEvents ONConnMsg As System.Windows.Forms.Label
    Friend WithEvents jy5ConnMsg As System.Windows.Forms.Label
    Friend WithEvents jy4ConnMsg As System.Windows.Forms.Label
    Friend WithEvents jy3ConnMsg As System.Windows.Forms.Label
    Friend WithEvents jy1ConnMsg As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents tbReceiveData As System.Windows.Forms.RichTextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rbtErrorMessage As System.Windows.Forms.RichTextBox
    Friend WithEvents btnClearErrorMessage As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnResetAllComPort As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents RTBData As System.Windows.Forms.RichTextBox

End Class
