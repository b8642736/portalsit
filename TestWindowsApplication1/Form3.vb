Public Class Form3

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.RichTextBox1.Text = IO.File.ReadAllText("c:\test1.csv")
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim SaveCount As Integer
        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        For Each EachItem In IO.File.ReadAllLines("c:\test1.csv")
            Dim InsertObject As New CompanyORMDB.ACAA.ACJ050PF
            With InsertObject
                .ACCTYR = CType(EachItem.Split(",")(0), String).Trim
                .ACCTNO = CType(EachItem.Split(",")(1), String).Trim
                .DETLNO = CType(EachItem.Split(",")(2), String).Trim
                .DEPTNO = CType(EachItem.Split(",")(3), String).Trim
                .BDGFIX = Val(EachItem.Split(",")(4))
                .BDGVAR = Val(EachItem.Split(",")(5))
                .BDGTTT = Val(.BDGFIX) + Val(.BDGVAR)
                .SQLQueryAdapterByThisObject = Adapter
                .CDBMemberName = "AA"
            End With
            SaveCount += InsertObject.CDBInsert()
        Next
        MsgBox("成功儲存" & SaveCount & " 筆")
    End Sub
End Class