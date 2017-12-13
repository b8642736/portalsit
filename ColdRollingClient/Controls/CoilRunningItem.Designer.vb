<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CoilRunningItem
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.tbMoveBack = New System.Windows.Forms.Button()
        Me.lbCoilNumberTitle = New System.Windows.Forms.Label()
        Me.lbCoilNumber = New System.Windows.Forms.Label()
        Me.EditButton = New System.Windows.Forms.Button()
        Me.tbMoveFront = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbMoveBack, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbCoilNumberTitle, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbCoilNumber, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.EditButton, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.tbMoveFront, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("標楷體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(209, 114)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackgroundImage = Global.ColdRollingClient.My.Resources.Resources.Coil1
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(3, 41)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(98, 32)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'tbMoveBack
        '
        Me.tbMoveBack.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbMoveBack.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbMoveBack.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tbMoveBack.Location = New System.Drawing.Point(107, 41)
        Me.tbMoveBack.Name = "tbMoveBack"
        Me.tbMoveBack.Size = New System.Drawing.Size(99, 32)
        Me.tbMoveBack.TabIndex = 1
        Me.tbMoveBack.Text = "<<"
        Me.tbMoveBack.UseVisualStyleBackColor = True
        '
        'lbCoilNumberTitle
        '
        Me.lbCoilNumberTitle.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbCoilNumberTitle.AutoSize = True
        Me.lbCoilNumberTitle.Location = New System.Drawing.Point(21, 11)
        Me.lbCoilNumberTitle.Name = "lbCoilNumberTitle"
        Me.lbCoilNumberTitle.Size = New System.Drawing.Size(80, 16)
        Me.lbCoilNumberTitle.TabIndex = 0
        Me.lbCoilNumberTitle.Text = "鋼捲編號:"
        '
        'lbCoilNumber
        '
        Me.lbCoilNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbCoilNumber.AutoSize = True
        Me.lbCoilNumber.Location = New System.Drawing.Point(107, 11)
        Me.lbCoilNumber.Name = "lbCoilNumber"
        Me.lbCoilNumber.Size = New System.Drawing.Size(99, 16)
        Me.lbCoilNumber.TabIndex = 4
        Me.lbCoilNumber.Text = "未知!"
        '
        'EditButton
        '
        Me.EditButton.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EditButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.EditButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EditButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.EditButton.Location = New System.Drawing.Point(3, 79)
        Me.EditButton.Name = "EditButton"
        Me.EditButton.Size = New System.Drawing.Size(98, 32)
        Me.EditButton.TabIndex = 3
        Me.EditButton.Text = "編修"
        Me.EditButton.UseVisualStyleBackColor = True
        '
        'tbMoveFront
        '
        Me.tbMoveFront.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbMoveFront.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbMoveFront.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tbMoveFront.Location = New System.Drawing.Point(107, 79)
        Me.tbMoveFront.Name = "tbMoveFront"
        Me.tbMoveFront.Size = New System.Drawing.Size(99, 32)
        Me.tbMoveFront.TabIndex = 2
        Me.tbMoveFront.Text = ">>"
        Me.tbMoveFront.UseVisualStyleBackColor = True
        '
        'CoilRunningItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "CoilRunningItem"
        Me.Size = New System.Drawing.Size(209, 114)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbCoilNumberTitle As System.Windows.Forms.Label
    Friend WithEvents tbMoveBack As System.Windows.Forms.Button
    Friend WithEvents tbMoveFront As System.Windows.Forms.Button
    Friend WithEvents EditButton As System.Windows.Forms.Button
    Friend WithEvents lbCoilNumber As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
