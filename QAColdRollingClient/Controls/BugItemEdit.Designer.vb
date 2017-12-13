<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BugItemEdit
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
        Me.tbLength = New System.Windows.Forms.Button()
        Me.tbCycle = New System.Windows.Forms.Button()
        Me.tbBug_Number = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbLength = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbDegree = New System.Windows.Forms.Button()
        Me.tbDistribute = New System.Windows.Forms.Button()
        Me.tbPosOrNeg = New System.Windows.Forms.Button()
        Me.tbDensity = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnOKCopy1 = New System.Windows.Forms.Button()
        Me.btnOKCopy2 = New System.Windows.Forms.Button()
        Me.btnOKCopy3 = New System.Windows.Forms.Button()
        Me.gbEditArea = New System.Windows.Forms.TableLayoutPanel()
        Me.lbShowCoilMessage = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.80951!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.142857!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.80953!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.80953!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.142857!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.142857!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.142857!))
        Me.TableLayoutPanel1.Controls.Add(Me.tbLength, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbCycle, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbBug_Number, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbLength, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbDegree, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbDistribute, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbPosOrNeg, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbDensity, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 6, 0)
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("標楷體", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 23)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(786, 44)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'tbLength
        '
        Me.tbLength.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbLength.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbLength.Location = New System.Drawing.Point(243, 13)
        Me.tbLength.Margin = New System.Windows.Forms.Padding(0)
        Me.tbLength.Name = "tbLength"
        Me.tbLength.Size = New System.Drawing.Size(187, 31)
        Me.tbLength.TabIndex = 5
        Me.tbLength.Text = "--"
        Me.tbLength.UseVisualStyleBackColor = True
        '
        'tbCycle
        '
        Me.tbCycle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbCycle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbCycle.Location = New System.Drawing.Point(729, 13)
        Me.tbCycle.Margin = New System.Windows.Forms.Padding(0)
        Me.tbCycle.Name = "tbCycle"
        Me.tbCycle.Size = New System.Drawing.Size(57, 31)
        Me.tbCycle.TabIndex = 2
        Me.tbCycle.Text = "--"
        Me.tbCycle.UseVisualStyleBackColor = True
        '
        'tbBug_Number
        '
        Me.tbBug_Number.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbBug_Number.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbBug_Number.Location = New System.Drawing.Point(0, 13)
        Me.tbBug_Number.Margin = New System.Windows.Forms.Padding(0)
        Me.tbBug_Number.Name = "tbBug_Number"
        Me.tbBug_Number.Size = New System.Drawing.Size(187, 31)
        Me.tbBug_Number.TabIndex = 5
        Me.tbBug_Number.Text = "--"
        Me.tbBug_Number.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("標楷體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(673, 0)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "密度"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("標楷體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(617, 0)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "正反"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("標楷體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(430, 0)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(187, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "分佈位置mm"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbLength
        '
        Me.lbLength.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbLength.AutoSize = True
        Me.lbLength.Font = New System.Drawing.Font("標楷體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbLength.Location = New System.Drawing.Point(243, 0)
        Me.lbLength.Margin = New System.Windows.Forms.Padding(0)
        Me.lbLength.Name = "lbLength"
        Me.lbLength.Size = New System.Drawing.Size(187, 13)
        Me.lbLength.TabIndex = 2
        Me.lbLength.Text = "長度"
        Me.lbLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("標楷體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(187, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "程度"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("標楷體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(187, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "代號"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbDegree
        '
        Me.tbDegree.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDegree.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbDegree.Location = New System.Drawing.Point(187, 13)
        Me.tbDegree.Margin = New System.Windows.Forms.Padding(0)
        Me.tbDegree.Name = "tbDegree"
        Me.tbDegree.Size = New System.Drawing.Size(56, 31)
        Me.tbDegree.TabIndex = 3
        Me.tbDegree.Text = "--"
        Me.tbDegree.UseVisualStyleBackColor = True
        '
        'tbDistribute
        '
        Me.tbDistribute.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDistribute.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbDistribute.Location = New System.Drawing.Point(430, 13)
        Me.tbDistribute.Margin = New System.Windows.Forms.Padding(0)
        Me.tbDistribute.Name = "tbDistribute"
        Me.tbDistribute.Size = New System.Drawing.Size(187, 31)
        Me.tbDistribute.TabIndex = 4
        Me.tbDistribute.Text = "--"
        Me.tbDistribute.UseVisualStyleBackColor = True
        '
        'tbPosOrNeg
        '
        Me.tbPosOrNeg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbPosOrNeg.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbPosOrNeg.Location = New System.Drawing.Point(617, 13)
        Me.tbPosOrNeg.Margin = New System.Windows.Forms.Padding(0)
        Me.tbPosOrNeg.Name = "tbPosOrNeg"
        Me.tbPosOrNeg.Size = New System.Drawing.Size(56, 31)
        Me.tbPosOrNeg.TabIndex = 2
        Me.tbPosOrNeg.Text = "--"
        Me.tbPosOrNeg.UseVisualStyleBackColor = True
        '
        'tbDensity
        '
        Me.tbDensity.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDensity.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbDensity.Location = New System.Drawing.Point(673, 13)
        Me.tbDensity.Margin = New System.Windows.Forms.Padding(0)
        Me.tbDensity.Name = "tbDensity"
        Me.tbDensity.Size = New System.Drawing.Size(56, 31)
        Me.tbDensity.TabIndex = 0
        Me.tbDensity.Text = "--"
        Me.tbDensity.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("標楷體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(729, 0)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "周期"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel1, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel1, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.gbEditArea, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lbShowCoilMessage, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(792, 562)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnOK)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnDelete)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnOKCopy1)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnOKCopy2)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnOKCopy3)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 70)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(792, 36)
        Me.FlowLayoutPanel1.TabIndex = 2
        '
        'btnOK
        '
        Me.btnOK.AutoSize = True
        Me.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOK.Font = New System.Drawing.Font("標楷體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnOK.Location = New System.Drawing.Point(3, 3)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(66, 31)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "確認"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.AutoSize = True
        Me.btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Font = New System.Drawing.Font("標楷體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(72, 3)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(0, 3, 3, 0)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(66, 31)
        Me.btnDelete.TabIndex = 8
        Me.btnDelete.Text = "刪除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnOKCopy1
        '
        Me.btnOKCopy1.AutoSize = True
        Me.btnOKCopy1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnOKCopy1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOKCopy1.Font = New System.Drawing.Font("標楷體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnOKCopy1.Location = New System.Drawing.Point(141, 3)
        Me.btnOKCopy1.Margin = New System.Windows.Forms.Padding(0, 3, 3, 0)
        Me.btnOKCopy1.Name = "btnOKCopy1"
        Me.btnOKCopy1.Size = New System.Drawing.Size(124, 31)
        Me.btnOKCopy1.TabIndex = 9
        Me.btnOKCopy1.Tag = "1"
        Me.btnOKCopy1.Text = "多複製1份"
        Me.btnOKCopy1.UseVisualStyleBackColor = True
        '
        'btnOKCopy2
        '
        Me.btnOKCopy2.AutoSize = True
        Me.btnOKCopy2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnOKCopy2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOKCopy2.Font = New System.Drawing.Font("標楷體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnOKCopy2.Location = New System.Drawing.Point(268, 3)
        Me.btnOKCopy2.Margin = New System.Windows.Forms.Padding(0, 3, 3, 0)
        Me.btnOKCopy2.Name = "btnOKCopy2"
        Me.btnOKCopy2.Size = New System.Drawing.Size(124, 31)
        Me.btnOKCopy2.TabIndex = 10
        Me.btnOKCopy2.Tag = "2"
        Me.btnOKCopy2.Text = "多複製2份"
        Me.btnOKCopy2.UseVisualStyleBackColor = True
        '
        'btnOKCopy3
        '
        Me.btnOKCopy3.AutoSize = True
        Me.btnOKCopy3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnOKCopy3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOKCopy3.Font = New System.Drawing.Font("標楷體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnOKCopy3.Location = New System.Drawing.Point(395, 3)
        Me.btnOKCopy3.Margin = New System.Windows.Forms.Padding(0, 3, 3, 0)
        Me.btnOKCopy3.Name = "btnOKCopy3"
        Me.btnOKCopy3.Size = New System.Drawing.Size(124, 31)
        Me.btnOKCopy3.TabIndex = 11
        Me.btnOKCopy3.Tag = "3"
        Me.btnOKCopy3.Text = "多複製3份"
        Me.btnOKCopy3.UseVisualStyleBackColor = True
        '
        'gbEditArea
        '
        Me.gbEditArea.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbEditArea.ColumnCount = 2
        Me.gbEditArea.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.gbEditArea.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.gbEditArea.Location = New System.Drawing.Point(0, 106)
        Me.gbEditArea.Margin = New System.Windows.Forms.Padding(0)
        Me.gbEditArea.Name = "gbEditArea"
        Me.gbEditArea.RowCount = 2
        Me.gbEditArea.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.gbEditArea.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180.0!))
        Me.gbEditArea.Size = New System.Drawing.Size(792, 456)
        Me.gbEditArea.TabIndex = 3
        '
        'lbShowCoilMessage
        '
        Me.lbShowCoilMessage.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbShowCoilMessage.AutoSize = True
        Me.lbShowCoilMessage.Font = New System.Drawing.Font("標楷體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbShowCoilMessage.Location = New System.Drawing.Point(3, 0)
        Me.lbShowCoilMessage.Name = "lbShowCoilMessage"
        Me.lbShowCoilMessage.Size = New System.Drawing.Size(99, 19)
        Me.lbShowCoilMessage.TabIndex = 4
        Me.lbShowCoilMessage.Text = "鋼捲資訊:"
        '
        'BugItemEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Name = "BugItemEdit"
        Me.Size = New System.Drawing.Size(792, 562)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbLength As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tbDensity As System.Windows.Forms.Button
    Friend WithEvents tbDistribute As System.Windows.Forms.Button
    Friend WithEvents tbDegree As System.Windows.Forms.Button
    Friend WithEvents tbCycle As System.Windows.Forms.Button
    Friend WithEvents tbPosOrNeg As System.Windows.Forms.Button
    Friend WithEvents tbLength As System.Windows.Forms.Button
    Friend WithEvents tbBug_Number As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnOKCopy1 As System.Windows.Forms.Button
    Friend WithEvents btnOKCopy2 As System.Windows.Forms.Button
    Friend WithEvents btnOKCopy3 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents gbEditArea As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbShowCoilMessage As System.Windows.Forms.Label

End Class
