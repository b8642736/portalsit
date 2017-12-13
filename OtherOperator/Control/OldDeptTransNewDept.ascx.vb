Public Class OldDeptTransNewDept
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnDEPTransfer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDEPTransfer.Click
        If String.IsNullOrEmpty(Me.TextBox1.Text) OrElse String.IsNullOrEmpty(TextBox2.Text) OrElse TextBox1.Text.Trim.Length = 0 OrElse TextBox2.Text.Trim.Length = 0 Then
            tbMsg.Text = "資料轉換失敗,請勿必輸入資料來源及欄位名稱!"
            Exit Sub
        End If
        Dim WhereString As String = IIf(String.IsNullOrEmpty(TextBox3.Text) OrElse TextBox3.Text.Trim.Length = 0, Nothing, " AND " & TextBox3.Text)
        tbMsg.Text = Nothing
        Dim AS400Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim NotTransDepCodes As String = Nothing
        Dim NotTransQry As String = "Select DISTINCT " & TextBox2.Text.Trim & " from @#" & TextBox1.Text.Trim & " Where " & TextBox2.Text.Trim & "  NOT IN (Select OLDCOD From @#GPL2.DEPCOEPF)" & WhereString
        Dim NotTransCountQry As String = "Select Count(*) from @#" & TextBox1.Text.Trim & " Where " & TextBox2.Text.Trim & "  NOT IN (Select OLDCOD From @#GPL2.DEPCOEPF)" & WhereString
        Dim NotTransCoun As Double = AS400Adapter.SelectQuery(NotTransCountQry).Rows(0)(0)
        For Each EachItem As DataRow In AS400Adapter.SelectQuery(NotTransQry).Rows
            NotTransDepCodes &= IIf(String.IsNullOrEmpty(NotTransDepCodes), Nothing, ",") & CType(EachItem.Item(TextBox2.Text.Trim), String)
        Next
        If Not String.IsNullOrEmpty(NotTransDepCodes) Then
            tbMsg.Text &= vbNewLine & "未轉換單位(共" & NotTransCoun & "筆)如下:" & NotTransDepCodes
        End If


        Dim TransOneDeptDataMessage As String
        Dim TotalSuccessTransCount As Double = 0
        For Each EachItem As DataRow In AS400Adapter.SelectQuery("Select * from @#GPL2.DEPCOEPF").Rows
            Dim OldDeptCode As String = CType(EachItem.Item("OLDCOD"), String)
            Dim NewDeptCode As String = CType(EachItem.Item("DEPCOD"), String)
            TransOneDeptDataMessage = "轉換舊單位:" & OldDeptCode & " 至新單位:" & NewDeptCode
            Dim UpdateQry As String = "UPDATE @#" & TextBox1.Text.Trim & " Set " & TextBox2.Text.Trim & "='" & NewDeptCode & "' Where " & TextBox2.Text.Trim & "='" & OldDeptCode & "' " & WhereString
            Try
                Dim TransCount As Integer = AS400Adapter.ExecuteNonQuery(UpdateQry)
                TransOneDeptDataMessage &= " 成功合計:" & TransCount & " 筆"
                TotalSuccessTransCount += TransCount
            Catch ex As Exception
                TransOneDeptDataMessage &= "失敗原因如下:" & vbNewLine & ex.ToString
            End Try
            tbMsg.Text &= IIf(String.IsNullOrEmpty(tbMsg.Text), Nothing, vbNewLine) & TransOneDeptDataMessage
        Next
        tbMsg.Text &= vbNewLine & "合計成功轉換資料:" & TotalSuccessTransCount & " 筆"

    End Sub

End Class