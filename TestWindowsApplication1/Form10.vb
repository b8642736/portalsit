Public Class Form10

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim SaveCount As Integer
        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        For Each EachItem In IO.File.ReadAllLines("c:\test2.csv")
            Dim InsertObject As New CompanyORMDB.PPS100LB.PPSBLGPF
            With InsertObject
                .BLG01 = CType(EachItem.Split(",")(0), String).Trim
                .BLG02 = CType(EachItem.Split(",")(1), String).Trim
                .BLG06 = CType(EachItem.Split(",")(2), String).Trim
                .BLG16 = CType(EachItem.Split(",")(3), String).Trim
                .SQLQueryAdapterByThisObject = Adapter
            End With
            SaveCount += InsertObject.CDBInsert()
        Next
        MsgBox("成功儲存" & SaveCount & " 筆")
    End Sub


End Class