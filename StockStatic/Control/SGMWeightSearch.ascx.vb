Public Class SGMWeightSearch
    Inherits System.Web.UI.UserControl


#Region "資料查詢 方法:Search"
    ''' <summary>
    ''' 資料查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryString As String) As StockStatic.DisplayDataSet.SGMWeightSearchDataTable
        Dim ReturnValue As New StockStatic.DisplayDataSet.SGMWeightSearchDataTable
        If String.IsNullOrEmpty(QryString) Then
            Return ReturnValue
        End If
        Dim SearchResult As List(Of CompanyORMDB.SMS100LB.SMSSGAPF) = CompanyORMDB.SMS100LB.SMSSGAPF.CDBSelect(Of CompanyORMDB.SMS100LB.SMSSGAPF)(QryString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        For Each EachItem As CompanyORMDB.SMS100LB.SMSSGAPF In SearchResult
            Dim AddItem As StockStatic.DisplayDataSet.SGMWeightSearchRow = ReturnValue.NewRow
            With AddItem
                .澆鑄日期 = EachItem.SGA07
                .澆鑄序號 = EachItem.SGA13
                .鋼胚編號 = EachItem.StoveNumber
                .重磨次數 = EachItem.SGA25
                .澆鑄班別 = EachItem.SGA17
                .鋼種材質 = EachItem.StoveKindName1
                .研磨前過磅重 = EachItem.SGA15
                .研磨後過磅重 = EachItem.SGA24
                .切塊退回重 = EachItem.SGA27
                .研磨重 = EachItem.GrindWeight
                .批號 = EachItem.SGA33
                .寬度 = EachItem.SGA09
            End With
            ReturnValue.Rows.Add(AddItem)
        Next
        Return ReturnValue
    End Function

#End Region


#Region "產生查詢指令至控制項 函式:MakeQryToControl"
    ''' <summary>
    ''' 產生查詢指令至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakeQryToControl()
        Dim QueryString As String = "SELECT * FROM @#SMS100LB.SMSSGAPF A WHERE A.SGA15 <> A.SGA24 AND A.SGA35<>'R' "

        Dim StartDateValue As Integer = New CompanyORMDB.AS400DateConverter(CType(btSearchDate1.Text, Date)).TwIntegerTypeData
        Dim EndDateValue As Integer = New CompanyORMDB.AS400DateConverter(CType(btEndDate1.Text, Date)).TwIntegerTypeData
        If CheckBox1.Checked Then
            QueryString &= " AND SGA07 >= " & StartDateValue & " AND SGA07<= " & EndDateValue
        End If
        If Not String.IsNullOrEmpty(tbBatchSearch.Text) AndAlso tbBatchSearch.Text.Trim.Length > 0 Then
            If tbBatchSearch.Text.Contains("~") Then
                QueryString &= " AND SGA33 >= '" & tbBatchSearch.Text.Trim.Split("~")(0) & "' AND SGA33<= '" & tbBatchSearch.Text.Trim.Split("~")(1) & "' "
            Else
                QueryString &= " AND SGA33 = '" & tbBatchSearch.Text.Trim & "' "
            End If
        End If
        If Not String.IsNullOrEmpty(tbWidth.Text) AndAlso tbWidth.Text.Trim.Length > 0 Then
            QueryString &= " AND SGA09 IN ('" & tbWidth.Text.Trim.Replace(",", "','") & "') "
        End If
        If Not String.IsNullOrEmpty(tbSteelKind.Text) AndAlso tbSteelKind.Text.Trim.Length > 0 Then
            QueryString &= " AND SGA05 IN ('" & tbSteelKind.Text.Trim.Replace(",", "','") & "') "
        End If
        If Not String.IsNullOrEmpty(tbSlabNumber.Text) AndAlso tbSlabNumber.Text.Trim.Length > 0 Then
            QueryString &= " AND SGA01 || '-' || SGA02 || DIGITS(SGA03) || SGA04   LIKE '" & tbSlabNumber.Text.Trim.Replace("*", "%") & "' "
        End If

        If Not String.IsNullOrEmpty(tbStoveNumbers.Text) AndAlso tbStoveNumbers.Text.Trim.Length > 0 Then
            If tbStoveNumbers.Text.Contains("~") Then
                QueryString &= " AND SGA01 >= '" & tbStoveNumbers.Text.Trim.Split("~")(0) & "' AND SGA01<= '" & tbStoveNumbers.Text.Trim.Split("~")(1) & "' "
            Else
                QueryString &= " AND SGA01 = '" & tbStoveNumbers.Text.Trim & "' "
            End If
        End If

        QueryString &= " Order by A.SGA07,A.SGA13,A.SGA02,A.SGA03,A.SGA25"

        Me.hfQry.Value = QueryString
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            btSearchDate1.Text = Now.Date.AddDays(-1)
            btEndDate1.Text = Now.Date
        End If
    End Sub

    Protected Sub btnSearchToExcel_Click(sender As Object, e As EventArgs) Handles btnSearchToExcel.Click
        MakeQryToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = New PublicClassLibrary.DataConvertExcel(Search(Me.hfQry.Value), "鋼胚研磨重量查詢" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakeQryToControl
        Me.GridView1.DataBind()

    End Sub
End Class