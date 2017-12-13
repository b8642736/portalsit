<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ThickItemEdit
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
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnOKCopy1 = New System.Windows.Forms.Button()
        Me.btnOKCopy2 = New System.Windows.Forms.Button()
        Me.btnOKCopy3 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbThick25 = New System.Windows.Forms.Label()
        Me.tbLength = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnPlus = New System.Windows.Forms.Button()
        Me.tbThick = New System.Windows.Forms.TextBox()
        Me.btnMinus = New System.Windows.Forms.Button()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnPlus1 = New System.Windows.Forms.Button()
        Me.btnMinus1 = New System.Windows.Forms.Button()
        Me.tbWidth = New System.Windows.Forms.TextBox()
        Me.pbGetL2Msg = New System.Windows.Forms.PictureBox()
        Me.lbShowCoilMessage = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnPlus2 = New System.Windows.Forms.Button()
        Me.tbThick60 = New System.Windows.Forms.TextBox()
        Me.btnMinus2 = New System.Windows.Forms.Button()
        Me.InputPanel = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.pbGetL2Msg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.InputPanel, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(783, 469)
        Me.TableLayoutPanel1.TabIndex = 0
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
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 83)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(777, 44)
        Me.FlowLayoutPanel1.TabIndex = 3
        '
        'btnOK
        '
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOK.Font = New System.Drawing.Font("新細明體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnOK.Location = New System.Drawing.Point(3, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(70, 38)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "確認"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Font = New System.Drawing.Font("新細明體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(76, 3)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(70, 38)
        Me.btnDelete.TabIndex = 8
        Me.btnDelete.Text = "刪除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnOKCopy1
        '
        Me.btnOKCopy1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOKCopy1.Font = New System.Drawing.Font("新細明體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnOKCopy1.Location = New System.Drawing.Point(149, 3)
        Me.btnOKCopy1.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.btnOKCopy1.Name = "btnOKCopy1"
        Me.btnOKCopy1.Size = New System.Drawing.Size(110, 38)
        Me.btnOKCopy1.TabIndex = 9
        Me.btnOKCopy1.Tag = "1"
        Me.btnOKCopy1.Text = "多複製1份"
        Me.btnOKCopy1.UseVisualStyleBackColor = True
        '
        'btnOKCopy2
        '
        Me.btnOKCopy2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOKCopy2.Font = New System.Drawing.Font("新細明體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnOKCopy2.Location = New System.Drawing.Point(262, 3)
        Me.btnOKCopy2.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.btnOKCopy2.Name = "btnOKCopy2"
        Me.btnOKCopy2.Size = New System.Drawing.Size(110, 38)
        Me.btnOKCopy2.TabIndex = 10
        Me.btnOKCopy2.Tag = "2"
        Me.btnOKCopy2.Text = "多複製2份"
        Me.btnOKCopy2.UseVisualStyleBackColor = True
        '
        'btnOKCopy3
        '
        Me.btnOKCopy3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOKCopy3.Font = New System.Drawing.Font("新細明體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnOKCopy3.Location = New System.Drawing.Point(375, 3)
        Me.btnOKCopy3.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.btnOKCopy3.Name = "btnOKCopy3"
        Me.btnOKCopy3.Size = New System.Drawing.Size(110, 38)
        Me.btnOKCopy3.TabIndex = 11
        Me.btnOKCopy3.Tag = "3"
        Me.btnOKCopy3.Text = "多複製3份"
        Me.btnOKCopy3.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 5
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 4, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lbThick25, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.tbLength, 4, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel4, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.pbGetL2Msg, 3, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lbShowCoilMessage, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel5, 0, 2)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.57143!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.57143!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.85714!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(777, 74)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(591, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(183, 21)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "長度mm"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(375, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(180, 21)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "寬mm"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbThick25
        '
        Me.lbThick25.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbThick25.AutoSize = True
        Me.lbThick25.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbThick25.Location = New System.Drawing.Point(189, 21)
        Me.lbThick25.Name = "lbThick25"
        Me.lbThick25.Size = New System.Drawing.Size(180, 21)
        Me.lbThick25.TabIndex = 0
        Me.lbThick25.Text = "距邊25mm厚"
        Me.lbThick25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbLength
        '
        Me.tbLength.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbLength.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbLength.Font = New System.Drawing.Font("標楷體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tbLength.Location = New System.Drawing.Point(591, 45)
        Me.tbLength.MaxLength = 5
        Me.tbLength.Name = "tbLength"
        Me.tbLength.Size = New System.Drawing.Size(183, 33)
        Me.tbLength.TabIndex = 11
        Me.tbLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnPlus, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.tbThick, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnMinus, 1, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(189, 45)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(180, 26)
        Me.TableLayoutPanel3.TabIndex = 12
        '
        'btnPlus
        '
        Me.btnPlus.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnPlus.Location = New System.Drawing.Point(149, 0)
        Me.btnPlus.Margin = New System.Windows.Forms.Padding(0)
        Me.btnPlus.Name = "btnPlus"
        Me.btnPlus.Size = New System.Drawing.Size(30, 23)
        Me.btnPlus.TabIndex = 11
        Me.btnPlus.Text = "+"
        Me.btnPlus.UseVisualStyleBackColor = True
        '
        'tbThick
        '
        Me.tbThick.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbThick.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbThick.Font = New System.Drawing.Font("標楷體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tbThick.Location = New System.Drawing.Point(0, 0)
        Me.tbThick.Margin = New System.Windows.Forms.Padding(0)
        Me.tbThick.MaxLength = 5
        Me.tbThick.Name = "tbThick"
        Me.tbThick.Size = New System.Drawing.Size(116, 33)
        Me.tbThick.TabIndex = 9
        Me.tbThick.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnMinus
        '
        Me.btnMinus.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnMinus.Location = New System.Drawing.Point(117, 0)
        Me.btnMinus.Margin = New System.Windows.Forms.Padding(0)
        Me.btnMinus.Name = "btnMinus"
        Me.btnMinus.Size = New System.Drawing.Size(30, 23)
        Me.btnMinus.TabIndex = 10
        Me.btnMinus.Text = "-"
        Me.btnMinus.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.btnPlus1, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.btnMinus1, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.tbWidth, 0, 0)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(375, 45)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(180, 26)
        Me.TableLayoutPanel4.TabIndex = 12
        '
        'btnPlus1
        '
        Me.btnPlus1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnPlus1.Location = New System.Drawing.Point(147, 0)
        Me.btnPlus1.Margin = New System.Windows.Forms.Padding(0)
        Me.btnPlus1.Name = "btnPlus1"
        Me.btnPlus1.Size = New System.Drawing.Size(30, 23)
        Me.btnPlus1.TabIndex = 12
        Me.btnPlus1.Text = "+"
        Me.btnPlus1.UseVisualStyleBackColor = True
        '
        'btnMinus1
        '
        Me.btnMinus1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnMinus1.Location = New System.Drawing.Point(112, 0)
        Me.btnMinus1.Margin = New System.Windows.Forms.Padding(0)
        Me.btnMinus1.Name = "btnMinus1"
        Me.btnMinus1.Size = New System.Drawing.Size(30, 23)
        Me.btnMinus1.TabIndex = 11
        Me.btnMinus1.Text = "-"
        Me.btnMinus1.UseVisualStyleBackColor = True
        '
        'tbWidth
        '
        Me.tbWidth.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbWidth.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbWidth.Font = New System.Drawing.Font("標楷體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tbWidth.Location = New System.Drawing.Point(0, 0)
        Me.tbWidth.Margin = New System.Windows.Forms.Padding(0)
        Me.tbWidth.MaxLength = 5
        Me.tbWidth.Name = "tbWidth"
        Me.tbWidth.Size = New System.Drawing.Size(110, 33)
        Me.tbWidth.TabIndex = 10
        Me.tbWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'pbGetL2Msg
        '
        Me.pbGetL2Msg.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbGetL2Msg.Image = Global.QAColdRollingClient.My.Resources.Resources.L2MsgGet
        Me.pbGetL2Msg.Location = New System.Drawing.Point(558, 42)
        Me.pbGetL2Msg.Margin = New System.Windows.Forms.Padding(0)
        Me.pbGetL2Msg.Name = "pbGetL2Msg"
        Me.pbGetL2Msg.Size = New System.Drawing.Size(30, 30)
        Me.pbGetL2Msg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbGetL2Msg.TabIndex = 12
        Me.pbGetL2Msg.TabStop = False
        '
        'lbShowCoilMessage
        '
        Me.lbShowCoilMessage.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbShowCoilMessage.AutoSize = True
        Me.lbShowCoilMessage.Font = New System.Drawing.Font("標楷體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbShowCoilMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbShowCoilMessage.Location = New System.Drawing.Point(3, 2)
        Me.lbShowCoilMessage.Name = "lbShowCoilMessage"
        Me.lbShowCoilMessage.Size = New System.Drawing.Size(80, 16)
        Me.lbShowCoilMessage.TabIndex = 13
        Me.lbShowCoilMessage.Text = "鋼捲資訊:"
        Me.lbShowCoilMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(180, 21)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "距邊60mm厚"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel5.ColumnCount = 3
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.btnPlus2, 2, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.tbThick60, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.btnMinus2, 1, 0)
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 45)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(180, 26)
        Me.TableLayoutPanel5.TabIndex = 15
        '
        'btnPlus2
        '
        Me.btnPlus2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnPlus2.Location = New System.Drawing.Point(149, 0)
        Me.btnPlus2.Margin = New System.Windows.Forms.Padding(0)
        Me.btnPlus2.Name = "btnPlus2"
        Me.btnPlus2.Size = New System.Drawing.Size(30, 23)
        Me.btnPlus2.TabIndex = 11
        Me.btnPlus2.Text = "+"
        Me.btnPlus2.UseVisualStyleBackColor = True
        '
        'tbThick60
        '
        Me.tbThick60.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbThick60.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbThick60.Font = New System.Drawing.Font("標楷體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tbThick60.Location = New System.Drawing.Point(0, 0)
        Me.tbThick60.Margin = New System.Windows.Forms.Padding(0)
        Me.tbThick60.MaxLength = 5
        Me.tbThick60.Name = "tbThick60"
        Me.tbThick60.Size = New System.Drawing.Size(116, 33)
        Me.tbThick60.TabIndex = 9
        Me.tbThick60.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnMinus2
        '
        Me.btnMinus2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnMinus2.Location = New System.Drawing.Point(117, 0)
        Me.btnMinus2.Margin = New System.Windows.Forms.Padding(0)
        Me.btnMinus2.Name = "btnMinus2"
        Me.btnMinus2.Size = New System.Drawing.Size(30, 23)
        Me.btnMinus2.TabIndex = 10
        Me.btnMinus2.Text = "-"
        Me.btnMinus2.UseVisualStyleBackColor = True
        '
        'InputPanel
        '
        Me.InputPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InputPanel.Location = New System.Drawing.Point(580, 286)
        Me.InputPanel.Name = "InputPanel"
        Me.InputPanel.Size = New System.Drawing.Size(200, 180)
        Me.InputPanel.TabIndex = 4
        '
        'ThickItemEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "ThickItemEdit"
        Me.Size = New System.Drawing.Size(783, 469)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        CType(Me.pbGetL2Msg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbThick25 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnOKCopy1 As System.Windows.Forms.Button
    Friend WithEvents btnOKCopy2 As System.Windows.Forms.Button
    Friend WithEvents btnOKCopy3 As System.Windows.Forms.Button
    Friend WithEvents InputPanel As System.Windows.Forms.Panel
    Friend WithEvents tbThick As System.Windows.Forms.TextBox
    Friend WithEvents tbWidth As System.Windows.Forms.TextBox
    Friend WithEvents tbLength As System.Windows.Forms.TextBox
    Friend WithEvents pbGetL2Msg As System.Windows.Forms.PictureBox
    Friend WithEvents lbShowCoilMessage As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnPlus As System.Windows.Forms.Button
    Friend WithEvents btnMinus As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnPlus1 As System.Windows.Forms.Button
    Friend WithEvents btnMinus1 As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnPlus2 As System.Windows.Forms.Button
    Friend WithEvents tbThick60 As System.Windows.Forms.TextBox
    Friend WithEvents btnMinus2 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
