Public Class Form9

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim QryString As String = "SELECT COUNT(*) FROM @#PPS100LB.PPSSHAPF "
        'Dim aa As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QryString)
        'MsgBox(aa.SelectQuery.Rows(0).Item(0))


        Dim Connect As New Odbc.OdbcConnection("Dsn=AS400;uid=pgmrodbc;pwd=tangeng;;QueryTimeOut=0;")

        MsgBox(Connect.State.ToString)
        Connect.Open()
        MsgBox(Connect.State.ToString)

        If Connect.State <> ConnectionState.Closed Then
            Connect.Close()
        End If
        MsgBox(Connect.State.ToString)
    End Sub

End Class