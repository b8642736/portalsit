<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BugItemGroupEdit
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
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbYear = New System.Windows.Forms.RadioButton()
        Me.rbMonth = New System.Windows.Forms.RadioButton()
        Me.rbDay = New System.Windows.Forms.RadioButton()
        Me.btnCoilNumber = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.41279!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.58721!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.41572!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.58428!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(794, 475)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.FlowLayoutPanel2, 2)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label1)
        Me.FlowLayoutPanel2.Controls.Add(Me.rbYear)
        Me.FlowLayoutPanel2.Controls.Add(Me.rbMonth)
        Me.FlowLayoutPanel2.Controls.Add(Me.rbDay)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnCoilNumber)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnCancel)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(226, 3)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(565, 95)
        Me.FlowLayoutPanel2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 57)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "民國"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rbYear
        '
        Me.rbYear.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbYear.Checked = True
        Me.rbYear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbYear.Font = New System.Drawing.Font("標楷體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rbYear.Location = New System.Drawing.Point(75, 3)
        Me.rbYear.Name = "rbYear"
        Me.rbYear.Size = New System.Drawing.Size(90, 51)
        Me.rbYear.TabIndex = 4
        Me.rbYear.TabStop = True
        Me.rbYear.Text = "103"
        Me.rbYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbYear.UseVisualStyleBackColor = True
        '
        'rbMonth
        '
        Me.rbMonth.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbMonth.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbMonth.Font = New System.Drawing.Font("標楷體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rbMonth.Location = New System.Drawing.Point(171, 3)
        Me.rbMonth.Name = "rbMonth"
        Me.rbMonth.Size = New System.Drawing.Size(90, 51)
        Me.rbMonth.TabIndex = 5
        Me.rbMonth.Text = "10"
        Me.rbMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbMonth.UseVisualStyleBackColor = True
        '
        'rbDay
        '
        Me.rbDay.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbDay.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbDay.Font = New System.Drawing.Font("標楷體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rbDay.Location = New System.Drawing.Point(267, 3)
        Me.rbDay.Name = "rbDay"
        Me.rbDay.Size = New System.Drawing.Size(90, 51)
        Me.rbDay.TabIndex = 6
        Me.rbDay.Text = "10"
        Me.rbDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbDay.UseVisualStyleBackColor = True
        '
        'btnCoilNumber
        '
        Me.btnCoilNumber.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnCoilNumber.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCoilNumber.Font = New System.Drawing.Font("標楷體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnCoilNumber.Location = New System.Drawing.Point(363, 3)
        Me.btnCoilNumber.Name = "btnCoilNumber"
        Me.btnCoilNumber.Size = New System.Drawing.Size(90, 51)
        Me.btnCoilNumber.TabIndex = 2
        Me.btnCoilNumber.Text = "新增站台" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "資料日期"
        Me.btnCoilNumber.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.Font = New System.Drawing.Font("標楷體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(459, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 51)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "取消"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.TableLayoutPanel1.SetRowSpan(Me.FlowLayoutPanel1, 2)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(217, 469)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(0, 10, 0, 10)
        Me.Label2.Size = New System.Drawing.Size(210, 44)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "選擇站台資料日期"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Location = New System.Drawing.Point(226, 104)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(565, 368)
        Me.Panel1.TabIndex = 3
        '
        'BugItemGroupEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "BugItemGroupEdit"
        Me.Size = New System.Drawing.Size(794, 475)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnCoilNumber As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rbYear As System.Windows.Forms.RadioButton
    Friend WithEvents rbMonth As System.Windows.Forms.RadioButton
    Friend WithEvents rbDay As System.Windows.Forms.RadioButton
    Friend WithEvents btnCancel As System.Windows.Forms.Button

End Class
