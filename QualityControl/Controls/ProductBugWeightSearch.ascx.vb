Public Class ProductBugWeightSearch
    Inherits System.Web.UI.UserControl


#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String) As QualityControlDataSet.ProductBugWeightSearchDataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return New QualityControlDataSet.ProductBugWeightSearchDataTable
        End If
        Dim QryResult As DataTable = New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC).SelectQuery(SQLString)
        Dim ReturnValue As New QualityControlDataSet.ProductBugWeightSearchDataTable
        For Each EachITtem As DataRow In QryResult.Rows
            Dim AddItem As QualityControlDataSet.ProductBugWeightSearchRow = ReturnValue.NewRow
            With AddItem
                .鋼種 = EachITtem.Item("CIA05")
                .表面 = EachITtem.Item("CIA06")
                .批號 = EachITtem.Item("BLA11")
                .黑皮號碼 = EachITtem.Item("BLA09")
                .鋼捲號碼 = EachITtem.Item("CIA02") & CType(EachITtem.Item("CIA03"), String).Trim
                .厚度 = EachITtem.Item("CIA07")
                .等級 = EachITtem.Item("CIA16") & Right(CType(EachITtem.Item("CIA52"), String), 1)
                .繳庫淨重 = EachITtem.Item("CIA13")
            End With
            ReturnValue.Rows.Add(AddItem)
        Next
        Return ReturnValue
    End Function
    Private Function GetBugName(ByVal BugCode As String) As String
        If String.IsNullOrEmpty(BugCode) OrElse BugCode.Trim.Length = 0 Then
            Return Nothing
        End If
        Dim QryResult As DataTable = New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC).SelectQuery("Select * from @#PPS100LB.PPSDEFPF ORDER BY DEF01")
        Dim GetReturnDataRow As DataRow = (From A In QryResult Where CType(A.Item("DEF01"), String) = BugCode Select A).FirstOrDefault
        If IsNothing(GetReturnDataRow) Then
            Return Nothing
        End If
        Return GetReturnDataRow.Item("DEF02")
    End Function
#End Region

#Region "SQL查詢產生至控制項 方法:MakerSQLStringToControl"
    ''' <summary>
    ''' 查詢產生至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakerSQLStringToControl()
        Dim ReturnValue As String = "Select  A.CIA02,A.CIA03,A.CIA05,A.CIA06,A.CIA07,A.CIA52,A.CIA13,A.CIA16,B.QCP21,B.QCP24,B.QCP27,B.QCP30,B.QCP33,B.QCP36,B.QCP39,B.QCP42,B.QCP45,C.BLA02,C.BLA09,C.BLA11 From @#PPS100LB.PPSCIAPF A LEFT JOIN @#PPS100LB.PPSQCPPF B ON A.CIA02 || A.CIA03 = B.QCP02 || B.QCP03  LEFT JOIN @#PPS100LB.PPSBLAPF C ON A.CIA02 = C.BLA09 AND A.CIA55>=C.BLA08  WHERE  1=1 "
        If Not String.IsNullOrEmpty(tbLotNumbers.Text) AndAlso tbLotNumbers.Text.Trim.Length > 0 Then
            tbLotNumbers.Text = tbLotNumbers.Text.Trim
            If tbLotNumbers.Text.Contains("~") Then
                ReturnValue &= " AND C.BLA11 >='" & Me.tbLotNumbers.Text.Split("~")(0).Trim & "' AND C.BLA11 <='" & Me.tbLotNumbers.Text.Split("~")(1).Trim & "'"
            Else
                ReturnValue &= " AND C.BLA11 IN ('" & Me.tbLotNumbers.Text.Replace(",", "','") & "')"
            End If
        End If

        If Not String.IsNullOrEmpty(tbBugs.Text) AndAlso tbBugs.Text.Trim.Length > 0 Then
            Dim ContainBugs As String = Me.tbBugs.Text.Trim
            ReturnValue &= " AND ("
            ReturnValue &= "     (B.QCP10='1'  AND B.QCP21 IN (" & ContainBugs & "))"
            ReturnValue &= "  OR (B.QCP10='2'  AND ( B.QCP24 IN (" & ContainBugs & ")"
            ReturnValue &= "                    OR   B.QCP27 IN (" & ContainBugs & ")"
            ReturnValue &= "                    OR   B.QCP30 IN (" & ContainBugs & ")"
            ReturnValue &= "                    OR   B.QCP33 IN (" & ContainBugs & ")  ))"
            ReturnValue &= "  OR (B.QCP10='3'  AND ( B.QCP36 IN (" & ContainBugs & ")"
            ReturnValue &= "                    OR   B.QCP39 IN (" & ContainBugs & ")"
            ReturnValue &= "                    OR   B.QCP42 IN (" & ContainBugs & ")"
            ReturnValue &= "                    OR   B.QCP45 IN (" & ContainBugs & ")  ))"
            ReturnValue &= ")"
        End If

        Me.HFQry.Value = ReturnValue
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakerSQLStringToControl()
        Me.GridView1.DataBind()
    End Sub

    Protected Sub btnDownToExcel_Click(sender As Object, e As EventArgs) Handles btnDownToExcel.Click
        MakerSQLStringToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = New PublicClassLibrary.DataConvertExcel(Search(Me.HFQry.Value), "成品鋼捲等級重量查詢" & Format(Now, "mmss") & ".xls")
        If Not IsNothing(ExcelConvert) Then
            ExcelConvert.DownloadEXCELFile(Me.Response)
        End If
    End Sub

End Class