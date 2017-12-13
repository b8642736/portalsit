<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BugItemMinDisplay
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbPosOrNeg = New System.Windows.Forms.Label()
        Me.lbDensity = New System.Windows.Forms.Label()
        Me.lbDegree = New System.Windows.Forms.Label()
        Me.lbCycle = New System.Windows.Forms.Label()
        Me.lbPosition = New System.Windows.Forms.Label()
        Me.lbDistribute = New System.Windows.Forms.Label()
        Me.lbBug_Number = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lbItemNumber = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(61, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 64)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "代號"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(116, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 64)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "程度"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(171, 0)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(212, 64)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "長度"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(395, 0)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(212, 64)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "分佈位置"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(619, 0)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 64)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "正反"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(674, 0)
        Me.Label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 64)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "密度"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbPosOrNeg
        '
        Me.lbPosOrNeg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbPosOrNeg.AutoSize = True
        Me.lbPosOrNeg.Location = New System.Drawing.Point(619, 64)
        Me.lbPosOrNeg.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lbPosOrNeg.Name = "lbPosOrNeg"
        Me.lbPosOrNeg.Size = New System.Drawing.Size(43, 64)
        Me.lbPosOrNeg.TabIndex = 7
        Me.lbPosOrNeg.Text = "--"
        Me.lbPosOrNeg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbDensity
        '
        Me.lbDensity.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbDensity.AutoSize = True
        Me.lbDensity.Location = New System.Drawing.Point(674, 64)
        Me.lbDensity.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lbDensity.Name = "lbDensity"
        Me.lbDensity.Size = New System.Drawing.Size(43, 64)
        Me.lbDensity.TabIndex = 8
        Me.lbDensity.Text = "--"
        Me.lbDensity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbDegree
        '
        Me.lbDegree.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbDegree.AutoSize = True
        Me.lbDegree.Location = New System.Drawing.Point(116, 64)
        Me.lbDegree.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lbDegree.Name = "lbDegree"
        Me.lbDegree.Size = New System.Drawing.Size(43, 64)
        Me.lbDegree.TabIndex = 9
        Me.lbDegree.Text = "--"
        Me.lbDegree.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbCycle
        '
        Me.lbCycle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbCycle.AutoSize = True
        Me.lbCycle.Location = New System.Drawing.Point(729, 64)
        Me.lbCycle.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lbCycle.Name = "lbCycle"
        Me.lbCycle.Size = New System.Drawing.Size(43, 64)
        Me.lbCycle.TabIndex = 10
        Me.lbCycle.Text = "--"
        Me.lbCycle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbPosition
        '
        Me.lbPosition.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbPosition.AutoSize = True
        Me.lbPosition.Location = New System.Drawing.Point(171, 64)
        Me.lbPosition.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lbPosition.Name = "lbPosition"
        Me.lbPosition.Size = New System.Drawing.Size(212, 64)
        Me.lbPosition.TabIndex = 11
        Me.lbPosition.Text = "--"
        Me.lbPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbDistribute
        '
        Me.lbDistribute.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbDistribute.AutoSize = True
        Me.lbDistribute.Location = New System.Drawing.Point(395, 64)
        Me.lbDistribute.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lbDistribute.Name = "lbDistribute"
        Me.lbDistribute.Size = New System.Drawing.Size(212, 64)
        Me.lbDistribute.TabIndex = 12
        Me.lbDistribute.Text = "--"
        Me.lbDistribute.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbBug_Number
        '
        Me.lbBug_Number.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbBug_Number.AutoSize = True
        Me.lbBug_Number.Location = New System.Drawing.Point(61, 64)
        Me.lbBug_Number.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lbBug_Number.Name = "lbBug_Number"
        Me.lbBug_Number.Size = New System.Drawing.Size(43, 64)
        Me.lbBug_Number.TabIndex = 13
        Me.lbBug_Number.Text = "--"
        Me.lbBug_Number.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 8
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lbItemNumber, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbCycle, 7, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbPosOrNeg, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbDistribute, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbBug_Number, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbPosition, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbDensity, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbDegree, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 7, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(778, 128)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lbItemNumber
        '
        Me.lbItemNumber.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbItemNumber.AutoSize = True
        Me.lbItemNumber.ForeColor = System.Drawing.Color.Red
        Me.lbItemNumber.Location = New System.Drawing.Point(6, 64)
        Me.lbItemNumber.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lbItemNumber.Name = "lbItemNumber"
        Me.lbItemNumber.Size = New System.Drawing.Size(43, 64)
        Me.lbItemNumber.TabIndex = 15
        Me.lbItemNumber.Text = "--"
        Me.lbItemNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 0)
        Me.Label8.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 64)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "項次"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.Location = New System.Drawing.Point(726, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 64)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "周期"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BugItemMinDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("標楷體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "BugItemMinDisplay"
        Me.Size = New System.Drawing.Size(778, 128)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbPosOrNeg As System.Windows.Forms.Label
    Friend WithEvents lbDensity As System.Windows.Forms.Label
    Friend WithEvents lbDegree As System.Windows.Forms.Label
    Friend WithEvents lbCycle As System.Windows.Forms.Label
    Friend WithEvents lbPosition As System.Windows.Forms.Label
    Friend WithEvents lbDistribute As System.Windows.Forms.Label
    Friend WithEvents lbBug_Number As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbItemNumber As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label

End Class
