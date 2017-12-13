Public Class Form7

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("ok")
        'Dim SaveCount As Integer
        'Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        'For Each EachItem In IO.File.ReadAllLines("c:\test1.csv")
        '    Dim InsertObject As New CompanyORMDB.AST500LB.AST501PF
        '    With InsertObject
        '        .NUMBER = CType(EachItem.Split(",")(0), String).Trim
        '        .FACKIND = CType(EachItem.Split(",")(1), String).Trim
        '        .SDATE = Val(EachItem.Split(",")(2))
        '        .EDATE = Val(EachItem.Split(",")(3))
        '        .FACKIND = Val(EachItem.Split(",")(4))
        '        .MEMO = "MISConvert 2013/07/05 "
        '        .SQLQueryAdapterByThisObject = Adapter
        '    End With
        '    SaveCount += InsertObject.CDBInsert()
        'Next
        'MsgBox("成功儲存" & SaveCount & " 筆")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        MsgBox("ok")
        'Me.TextBox1.Text = IO.File.ReadAllText("c:\test1.csv")

    End Sub
End Class