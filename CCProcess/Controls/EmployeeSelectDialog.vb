Imports System.Windows.Forms

Public Class EmployeeSelectDialog

    Public Event ReturnEvent(ByVal ReturnValue As CompanyORMDB.PLT000LB.PQDM01PF)

    Private Sub EmployeeSelectDialog_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Call btnCancelBack_Click(Nothing, Nothing)
    End Sub

    Private Sub EmployeeSelectDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.bsPQDM01PF.DataSource = CompanyORMDB.PLT000LB.PQDM01PF.GetEmployees(Now.Year - 1911, Now.Month, "W331")
    End Sub

    Private Sub btnCancelBack_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelBack.Click
        RaiseEvent ReturnEvent(Nothing)
        Me.Hide()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = 0 AndAlso e.RowIndex >= 0 Then
            RaiseEvent ReturnEvent(DataGridView1.Rows(e.RowIndex).DataBoundItem)
            Me.Hide()
        End If
    End Sub
End Class
