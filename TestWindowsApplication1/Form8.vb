Public Class Form8

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim SaveCount As Integer
        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        For Each EachItem In IO.File.ReadAllLines("c:\test1.csv")
            Dim InsertObject As New CompanyORMDB.ACAA.ACJ050PF
            Dim InsertObject1 As New CompanyORMDB.ACLIB.ACJ050PF
            With InsertObject
                .ACCTYR = CType(EachItem.Split(",")(0), String).Trim
                InsertObject1.ACCTYR = .ACCTYR
                .ACCTNO = CType(EachItem.Split(",")(1), String).Trim
                InsertObject1.ACCTNO = .ACCTNO
                .DETLNO = CType(EachItem.Split(",")(2), String).Trim
                InsertObject1.DETLNO = .DETLNO
                .DEPTNO = CType(EachItem.Split(",")(3), String).Trim
                InsertObject1.DEPTNO = .DEPTNO
                .BDGFIX = Val(EachItem.Split(",")(4))
                InsertObject1.BDGFIX = .BDGFIX
                .BDGVAR = Val(EachItem.Split(",")(5))
                InsertObject1.BDGVAR = .BDGVAR
                .BDGTTT = Val(.BDGFIX) + Val(.BDGVAR)
                InsertObject1.BDGTTT = .BDGTTT
                .SQLQueryAdapterByThisObject = Adapter
                InsertObject1.SQLQueryAdapterByThisObject = .SQLQueryAdapterByThisObject
                .CDBMemberName = "AA"
                InsertObject1.CDBMemberName = "SA"
            End With
            SaveCount += InsertObject.CDBInsert()
            InsertObject1.CDBInsert()
        Next
        MsgBox("成功儲存" & SaveCount & " 筆")
    End Sub
End Class