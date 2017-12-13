Public Class ExpenseDetailSearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SqlString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SqlString As String) As AccountDataSet.ExpenseDetailSearchDataTable
        If String.IsNullOrEmpty(SqlString) Then
            Return New AccountDataSet.ExpenseDetailSearchDataTable
        End If
        Dim ReturnValue As New AccountDataSet.ExpenseDetailSearchDataTable
        Dim SearchResult As List(Of CompanyORMDB.ACLIB.ACD010PF) = CompanyORMDB.ACLIB.ACD010PF.CDBSelect(Of CompanyORMDB.ACLIB.ACD010PF)(SqlString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        For Each EachItem As CompanyORMDB.ACLIB.ACD010PF In SearchResult
            Dim EachItemTemp As CompanyORMDB.ACLIB.ACD010PF = EachItem
            Dim AddItem As AccountDataSet.ExpenseDetailSearchRow = ReturnValue.NewRow
            With AddItem
                .會計科目 = EachItem.ACCTNO & EachItem.ACCTNOName
                .明細科目 = EachItem.DETLNO & EachItem.DETLNOName
                .單位 = EachItemTemp.DEPTNO
                .使用單位 = EachItemTemp.WORKNO
                .固定金額 = CType(IIf(EachItem.IsFixMoney AndAlso EachItem.DBORCR = "A", EachItem.AMOUNT, 0), Double)
                .固定金額 = CType(Val(.固定金額) - CType(IIf(EachItem.IsFixMoney AndAlso EachItem.DBORCR = "B", EachItem.AMOUNT, 0), Double), Double)
                .固定金額 = Format(Val(.固定金額), "##,##0.##")
                .變動金額 = CType(IIf(EachItem.IsFixMoney = False AndAlso EachItem.DBORCR = "A", EachItem.AMOUNT, 0), Double)
                .變動金額 = CType(Val(.變動金額) - CType(IIf(EachItem.IsFixMoney = False AndAlso EachItem.DBORCR = "B", EachItem.AMOUNT, 0), Double), Double)
                .變動金額 = Format(Val(.變動金額), "##,##0.##")
                .摘要 = EachItem.REMARK
                .入帳日期 = EachItem.ACTDAT
                .傳票編號 = EachItem.SHTNO1
            End With
            ReturnValue.Rows.Add(AddItem)
        Next
        Return ReturnValue
    End Function
#End Region

#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim ReturnValue As String
        Dim StartDate As Integer = New CompanyORMDB.AS400DateConverter(CType(Me.tbStartDate.Text, Date)).TwIntegerTypeData
        Dim EndDate As Integer = New CompanyORMDB.AS400DateConverter(CType(Me.tbEndDate.Text, Date)).TwIntegerTypeData
        ReturnValue = "Select * From  @#" & IIf(rblFactory.SelectedValue = "SA", "ACLIB.ACD010PF.SA ", "ACAA.ACD010PF." & rblFactory.SelectedValue) & _
                  " WHERE ACTDAT>= " & StartDate & " AND ACTDAT<=" & EndDate


        If Not String.IsNullOrEmpty(tbACCTNO.Text) Then
            tbACCTNO.Text = tbACCTNO.Text.Replace("'", Nothing)
            If tbACCTNO.Text.Contains("~") Then
                ReturnValue &= IIf(tbACCTNO.Text.Trim.Length > 0, " AND ACCTNO >= '" & tbACCTNO.Text.Split("~")(0).Trim & "' AND ACCTNO <= '" & tbACCTNO.Text.Split("~")(1).Trim & "'", Nothing)
            Else
                ReturnValue &= IIf(tbACCTNO.Text.Trim.Length > 0, " AND ACCTNO IN ('" & tbACCTNO.Text.Replace(",", "','") & "')", Nothing)
            End If
        End If

        If Not String.IsNullOrEmpty(tbDETLNO.Text) Then
            ReturnValue &= IIf(tbDETLNO.Text.Trim.Length > 0, " AND DETLNO IN ('" & tbDETLNO.Text.Replace(",", "','") & "')", Nothing)
        End If

        If Not String.IsNullOrEmpty(tbDEPTNO.Text) Then
            ReturnValue &= IIf(tbDEPTNO.Text.Trim.Length > 0, " AND DEPTNO IN ('" & tbDEPTNO.Text.Replace(",", "','") & "')", Nothing)
        End If


        If Not String.IsNullOrEmpty(tbUseDepts.Text) Then
            If tbUseDepts.Text.Contains("*") Then
                ReturnValue &= IIf(tbUseDepts.Text.Trim.Length > 0, " AND WORKNO LIKE ('" & tbUseDepts.Text.Replace("*", "%") & "')", Nothing)
            Else
                ReturnValue &= IIf(tbUseDepts.Text.Trim.Length > 0, " AND WORKNO IN ('" & tbUseDepts.Text.Replace(",", "','") & "')", Nothing)
            End If
        End If


        '篩選費用類會計科目
        'ReturnValue &= " AND SUBSTR(ACCTNO,1,4) IN (Select DISTINCT ACCTNO FROM @#ACLIB.ACJ050PF.SA )"
        ReturnValue &= " AND SUBSTR(ACCTNO,1,4) IN (Select DISTINCT ACCTNO FROM @#" & IIf(rblFactory.SelectedValue = "SA", "ACLIB.ACJ050PF.SA", "ACAA.ACJ050PF." & rblFactory.SelectedValue) & " )"

        Me.hfQryString.Value = ReturnValue & " Order by ACCTNO,DETLNO,DEPTNO"
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Format(Now, "yyyy/MM/01")
            tbEndDate.Text = tbStartDate.Text
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        MakQryStringToControl()
        GridView1.DataBind()
    End Sub

    Protected Sub btnExcelFileDownload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExcelFileDownload.Click
        MakQryStringToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = New PublicClassLibrary.DataConvertExcel(Search(Me.hfQryString.Value), "費用科目細目金額合計" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub

End Class