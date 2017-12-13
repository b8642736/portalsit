<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class APL2OthersEdit
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbAPL2ThickMM = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.tbCoilMaxLength = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbAPL2BATestHeadMM = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbAPL2BATestTailMM = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbJointLength = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel6 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbCoilPositionErrLength = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbIsUpdateFromL2Value = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel7 = New System.Windows.Forms.FlowLayoutPanel()
        Me.lbCoilStartTime = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lbCoilEndTime = New System.Windows.Forms.Label()
        Me.btnAssignEndTime = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.rbAPL2IsExportPackage1 = New System.Windows.Forms.RadioButton()
        Me.rbAPL2IsExportPackage2 = New System.Windows.Forms.RadioButton()
        Me.rbAPL2IsExportPackage3 = New System.Windows.Forms.RadioButton()
        Me.KeybordPanel = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.FlowLayoutPanel6.SuspendLayout()
        Me.FlowLayoutPanel7.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.KeybordPanel, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 297.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 249.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(805, 554)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.63636!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.36364!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.63636!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.36364!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.tbAPL2ThickMM, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label17, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.tbCoilMaxLength, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel3, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label8, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.tbJointLength, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label12, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel6, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label15, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.cbIsUpdateFromL2Value, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label13, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel7, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel1, 3, 2)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 6
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.02406!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.40206!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.965635!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.965635!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.34021!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.27148!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(799, 291)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("標楷體", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(407, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 67)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "APL2測厚儀厚度mm:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbAPL2ThickMM
        '
        Me.tbAPL2ThickMM.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tbAPL2ThickMM.Font = New System.Drawing.Font("標楷體", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tbAPL2ThickMM.Location = New System.Drawing.Point(509, 15)
        Me.tbAPL2ThickMM.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.tbAPL2ThickMM.Name = "tbAPL2ThickMM"
        Me.tbAPL2ThickMM.Size = New System.Drawing.Size(100, 39)
        Me.tbAPL2ThickMM.TabIndex = 5
        '
        'Label17
        '
        Me.Label17.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("標楷體", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label17.Location = New System.Drawing.Point(401, 67)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(102, 39)
        Me.Label17.TabIndex = 25
        Me.Label17.Text = "鋼捲母片長:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbCoilMaxLength
        '
        Me.tbCoilMaxLength.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbCoilMaxLength.Font = New System.Drawing.Font("標楷體", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tbCoilMaxLength.Location = New System.Drawing.Point(509, 73)
        Me.tbCoilMaxLength.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.tbCoilMaxLength.Name = "tbCoilMaxLength"
        Me.tbCoilMaxLength.Size = New System.Drawing.Size(100, 39)
        Me.tbCoilMaxLength.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("標楷體", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 8)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 54)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "試片厚度mm:"
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel3.Controls.Add(Me.Label4)
        Me.FlowLayoutPanel3.Controls.Add(Me.tbAPL2BATestHeadMM)
        Me.FlowLayoutPanel3.Controls.Add(Me.Label5)
        Me.FlowLayoutPanel3.Controls.Add(Me.tbAPL2BATestTailMM)
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(111, 3)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(284, 61)
        Me.FlowLayoutPanel3.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("標楷體", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 27)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "頭:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbAPL2BATestHeadMM
        '
        Me.tbAPL2BATestHeadMM.Font = New System.Drawing.Font("標楷體", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tbAPL2BATestHeadMM.Location = New System.Drawing.Point(63, 6)
        Me.tbAPL2BATestHeadMM.Name = "tbAPL2BATestHeadMM"
        Me.tbAPL2BATestHeadMM.Size = New System.Drawing.Size(100, 39)
        Me.tbAPL2BATestHeadMM.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("標楷體", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(169, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 27)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "尾:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbAPL2BATestTailMM
        '
        Me.tbAPL2BATestTailMM.Font = New System.Drawing.Font("標楷體", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tbAPL2BATestTailMM.Location = New System.Drawing.Point(3, 51)
        Me.tbAPL2BATestTailMM.Name = "tbAPL2BATestTailMM"
        Me.tbAPL2BATestTailMM.Size = New System.Drawing.Size(100, 39)
        Me.tbAPL2BATestTailMM.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("標楷體", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(40, 67)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 39)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "導片長:"
        '
        'tbJointLength
        '
        Me.tbJointLength.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tbJointLength.Font = New System.Drawing.Font("標楷體", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tbJointLength.Location = New System.Drawing.Point(111, 70)
        Me.tbJointLength.Name = "tbJointLength"
        Me.tbJointLength.Size = New System.Drawing.Size(100, 39)
        Me.tbJointLength.TabIndex = 36
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("標楷體", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(12, 106)
        Me.Label12.Margin = New System.Windows.Forms.Padding(0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(96, 29)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "位置誤差:"
        '
        'FlowLayoutPanel6
        '
        Me.FlowLayoutPanel6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel6.Controls.Add(Me.Label11)
        Me.FlowLayoutPanel6.Controls.Add(Me.tbCoilPositionErrLength)
        Me.FlowLayoutPanel6.Location = New System.Drawing.Point(111, 109)
        Me.FlowLayoutPanel6.Name = "FlowLayoutPanel6"
        Me.FlowLayoutPanel6.Size = New System.Drawing.Size(284, 23)
        Me.FlowLayoutPanel6.TabIndex = 45
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label11.AutoEllipsis = True
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("標楷體", 18.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(0, 7)
        Me.Label11.Margin = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(25, 25)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "-"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbCoilPositionErrLength
        '
        Me.tbCoilPositionErrLength.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbCoilPositionErrLength.Font = New System.Drawing.Font("標楷體", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tbCoilPositionErrLength.Location = New System.Drawing.Point(28, 3)
        Me.tbCoilPositionErrLength.Name = "tbCoilPositionErrLength"
        Me.tbCoilPositionErrLength.Size = New System.Drawing.Size(40, 39)
        Me.tbCoilPositionErrLength.TabIndex = 30
        Me.tbCoilPositionErrLength.Text = "2"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("標楷體", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label15.Location = New System.Drawing.Point(0, 135)
        Me.Label15.Margin = New System.Windows.Forms.Padding(0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(108, 29)
        Me.Label15.TabIndex = 42
        Me.Label15.Text = "是否L2更新:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbIsUpdateFromL2Value
        '
        Me.cbIsUpdateFromL2Value.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbIsUpdateFromL2Value.AutoSize = True
        Me.cbIsUpdateFromL2Value.Enabled = False
        Me.cbIsUpdateFromL2Value.Font = New System.Drawing.Font("標楷體", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbIsUpdateFromL2Value.Location = New System.Drawing.Point(111, 138)
        Me.cbIsUpdateFromL2Value.Name = "cbIsUpdateFromL2Value"
        Me.cbIsUpdateFromL2Value.Size = New System.Drawing.Size(284, 23)
        Me.cbIsUpdateFromL2Value.TabIndex = 43
        Me.cbIsUpdateFromL2Value.Text = "是,L2數據資料已更新"
        Me.cbIsUpdateFromL2Value.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("標楷體", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 176)
        Me.Label13.Margin = New System.Windows.Forms.Padding(0, 12, 0, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(96, 21)
        Me.Label13.TabIndex = 40
        Me.Label13.Text = "鋼捲時間:"
        '
        'FlowLayoutPanel7
        '
        Me.FlowLayoutPanel7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.SetColumnSpan(Me.FlowLayoutPanel7, 3)
        Me.FlowLayoutPanel7.Controls.Add(Me.lbCoilStartTime)
        Me.FlowLayoutPanel7.Controls.Add(Me.Label14)
        Me.FlowLayoutPanel7.Controls.Add(Me.lbCoilEndTime)
        Me.FlowLayoutPanel7.Controls.Add(Me.btnAssignEndTime)
        Me.FlowLayoutPanel7.Location = New System.Drawing.Point(108, 164)
        Me.FlowLayoutPanel7.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel7.Name = "FlowLayoutPanel7"
        Me.FlowLayoutPanel7.Size = New System.Drawing.Size(691, 33)
        Me.FlowLayoutPanel7.TabIndex = 41
        '
        'lbCoilStartTime
        '
        Me.lbCoilStartTime.AutoSize = True
        Me.lbCoilStartTime.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbCoilStartTime.Font = New System.Drawing.Font("標楷體", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbCoilStartTime.Location = New System.Drawing.Point(3, 9)
        Me.lbCoilStartTime.Margin = New System.Windows.Forms.Padding(3, 9, 3, 0)
        Me.lbCoilStartTime.Name = "lbCoilStartTime"
        Me.lbCoilStartTime.Size = New System.Drawing.Size(82, 32)
        Me.lbCoilStartTime.TabIndex = 0
        Me.lbCoilStartTime.Text = "Stime"
        Me.lbCoilStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label14.Font = New System.Drawing.Font("標楷體", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.Location = New System.Drawing.Point(91, 9)
        Me.Label14.Margin = New System.Windows.Forms.Padding(3, 9, 3, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(26, 32)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "~"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbCoilEndTime
        '
        Me.lbCoilEndTime.AutoSize = True
        Me.lbCoilEndTime.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbCoilEndTime.Font = New System.Drawing.Font("標楷體", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbCoilEndTime.Location = New System.Drawing.Point(123, 9)
        Me.lbCoilEndTime.Margin = New System.Windows.Forms.Padding(3, 9, 3, 0)
        Me.lbCoilEndTime.Name = "lbCoilEndTime"
        Me.lbCoilEndTime.Size = New System.Drawing.Size(82, 32)
        Me.lbCoilEndTime.TabIndex = 2
        Me.lbCoilEndTime.Text = "Etime"
        Me.lbCoilEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAssignEndTime
        '
        Me.btnAssignEndTime.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnAssignEndTime.AutoSize = True
        Me.btnAssignEndTime.Font = New System.Drawing.Font("標楷體", 18.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnAssignEndTime.Location = New System.Drawing.Point(211, 3)
        Me.btnAssignEndTime.Name = "btnAssignEndTime"
        Me.btnAssignEndTime.Size = New System.Drawing.Size(178, 35)
        Me.btnAssignEndTime.TabIndex = 5
        Me.btnAssignEndTime.Text = "指定結束時間"
        Me.btnAssignEndTime.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("標楷體", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(435, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 29)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "外包裝:"
        Me.Label2.Visible = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbAPL2IsExportPackage1)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbAPL2IsExportPackage2)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbAPL2IsExportPackage3)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(509, 109)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(287, 23)
        Me.FlowLayoutPanel1.TabIndex = 6
        Me.FlowLayoutPanel1.Visible = False
        '
        'rbAPL2IsExportPackage1
        '
        Me.rbAPL2IsExportPackage1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbAPL2IsExportPackage1.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbAPL2IsExportPackage1.AutoSize = True
        Me.rbAPL2IsExportPackage1.Checked = True
        Me.rbAPL2IsExportPackage1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbAPL2IsExportPackage1.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightPink
        Me.rbAPL2IsExportPackage1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbAPL2IsExportPackage1.Font = New System.Drawing.Font("標楷體", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rbAPL2IsExportPackage1.Location = New System.Drawing.Point(3, 6)
        Me.rbAPL2IsExportPackage1.Name = "rbAPL2IsExportPackage1"
        Me.rbAPL2IsExportPackage1.Size = New System.Drawing.Size(80, 39)
        Me.rbAPL2IsExportPackage1.TabIndex = 0
        Me.rbAPL2IsExportPackage1.TabStop = True
        Me.rbAPL2IsExportPackage1.Text = "未選"
        Me.rbAPL2IsExportPackage1.UseVisualStyleBackColor = True
        '
        'rbAPL2IsExportPackage2
        '
        Me.rbAPL2IsExportPackage2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbAPL2IsExportPackage2.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbAPL2IsExportPackage2.AutoSize = True
        Me.rbAPL2IsExportPackage2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbAPL2IsExportPackage2.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightPink
        Me.rbAPL2IsExportPackage2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbAPL2IsExportPackage2.Font = New System.Drawing.Font("標楷體", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rbAPL2IsExportPackage2.Location = New System.Drawing.Point(89, 6)
        Me.rbAPL2IsExportPackage2.Name = "rbAPL2IsExportPackage2"
        Me.rbAPL2IsExportPackage2.Size = New System.Drawing.Size(136, 39)
        Me.rbAPL2IsExportPackage2.TabIndex = 1
        Me.rbAPL2IsExportPackage2.Text = "有外包裝"
        Me.rbAPL2IsExportPackage2.UseVisualStyleBackColor = True
        '
        'rbAPL2IsExportPackage3
        '
        Me.rbAPL2IsExportPackage3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbAPL2IsExportPackage3.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbAPL2IsExportPackage3.AutoSize = True
        Me.rbAPL2IsExportPackage3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbAPL2IsExportPackage3.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightPink
        Me.rbAPL2IsExportPackage3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbAPL2IsExportPackage3.Font = New System.Drawing.Font("標楷體", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rbAPL2IsExportPackage3.Location = New System.Drawing.Point(3, 51)
        Me.rbAPL2IsExportPackage3.Name = "rbAPL2IsExportPackage3"
        Me.rbAPL2IsExportPackage3.Size = New System.Drawing.Size(136, 39)
        Me.rbAPL2IsExportPackage3.TabIndex = 2
        Me.rbAPL2IsExportPackage3.Text = "無外包裝"
        Me.rbAPL2IsExportPackage3.UseVisualStyleBackColor = True
        '
        'KeybordPanel
        '
        Me.KeybordPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.KeybordPanel, 2)
        Me.KeybordPanel.Location = New System.Drawing.Point(602, 371)
        Me.KeybordPanel.Name = "KeybordPanel"
        Me.KeybordPanel.Size = New System.Drawing.Size(200, 180)
        Me.KeybordPanel.TabIndex = 3
        '
        'APL2OthersEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "APL2OthersEdit"
        Me.Size = New System.Drawing.Size(805, 554)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.FlowLayoutPanel3.PerformLayout()
        Me.FlowLayoutPanel6.ResumeLayout(False)
        Me.FlowLayoutPanel6.PerformLayout()
        Me.FlowLayoutPanel7.ResumeLayout(False)
        Me.FlowLayoutPanel7.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbAPL2ThickMM As System.Windows.Forms.TextBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbAPL2IsExportPackage1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbAPL2IsExportPackage2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbAPL2IsExportPackage3 As System.Windows.Forms.RadioButton
    Friend WithEvents FlowLayoutPanel3 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbAPL2BATestHeadMM As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbAPL2BATestTailMM As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents tbCoilMaxLength As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbJointLength As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel7 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lbCoilStartTime As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lbCoilEndTime As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbIsUpdateFromL2Value As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel6 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbCoilPositionErrLength As System.Windows.Forms.TextBox
    Friend WithEvents btnAssignEndTime As System.Windows.Forms.Button
    Friend WithEvents KeybordPanel As System.Windows.Forms.Panel

End Class
