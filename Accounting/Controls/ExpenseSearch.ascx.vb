Public Class ExpenseSearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SqlString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SqlString As String, ByVal SqlString0 As String, ByVal SqlString1 As String) As AccountDataSet.ExpenseSearchDataTable
        If String.IsNullOrEmpty(SqlString) Then
            Return New AccountDataSet.ExpenseSearchDataTable
        End If
        Dim ReturnValue As New AccountDataSet.ExpenseSearchDataTable
        Dim SearchResult As List(Of CompanyORMDB.ACLIB.ACD010PF) = CompanyORMDB.ACLIB.ACD010PF.CDBSelect(Of CompanyORMDB.ACLIB.ACD010PF)(SqlString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        'Dim SearchResult0 As List(Of CompanyORMDB.ACLIB.ACD010PF) = CompanyORMDB.ACLIB.ACD010PF.CDBSelect(Of CompanyORMDB.ACLIB.ACD010PF)(SqlString0, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim SearchResult0 As List(Of CompanyORMDB.ACLIB.ACD010PF)
        Try
            SearchResult0 = CompanyORMDB.ACLIB.ACD010PF.CDBSelect(Of CompanyORMDB.ACLIB.ACD010PF)(SqlString0, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Catch ex As Exception

        End Try

        Dim LastACCTNO As String = Nothing
        Dim LastDETLNO As String = Nothing

        Dim Type1Keys As List(Of String) = (From A In SearchResult Select A.ACCTNO & "," & A.DETLNO & "," & A.DEPTNO Distinct).ToList
        Dim IsType1KeyInACJ050PF As Boolean   '判斷ACD010PF是否存在於ACJ050PF 
        For Each EachItem As String In (From A In SearchResult.Union(SearchResult0) Select A.ACCTNO & "," & A.DETLNO & "," & A.DEPTNO Distinct).ToList
            Dim EachItemTemp As String = EachItem
            IsType1KeyInACJ050PF = Type1Keys.Contains(EachItemTemp) '判斷ACD010PF Key值是否存在於ACJ050PF 

            '判定斷是否有未指定單位之預算,如有則新增一筆
            If Not String.IsNullOrEmpty(LastACCTNO) AndAlso (LastACCTNO <> EachItemTemp.Split(",")(0) OrElse LastDETLNO <> EachItemTemp.Split(",")(1)) Then
                Dim FindBudget As String = FindBuget(SqlString1, LastACCTNO, LastDETLNO)
                If FindBudget <> "," Then
                    Dim AddItem1 As AccountDataSet.ExpenseSearchRow = ReturnValue.NewRow
                    With AddItem1
                        .會計科目 = LastACCTNO
                        .明細科目 = LastDETLNO
                        .成本單位 = "-----"
                        '.使用單位 = "-----"
                        .固定預算 = FindBudget.Split(",")(0)
                        .變動預算 = FindBudget.Split(",")(1)
                        .固定預算 = Format(Val(.固定預算), "##,##0.##")
                        .變動預算 = Format(Val(.變動預算), "##,##0.##")
                        .狀態說明 = "預算已執行但無成本單位"
                    End With
                    ReturnValue.Rows.Add(AddItem1)
                End If
            End If

            Dim SubSearchResult = (From A In SearchResult Where A.ACCTNO = EachItemTemp.Split(",")(0) And A.DETLNO = EachItemTemp.Split(",")(1) And A.DEPTNO = EachItemTemp.Split(",")(2) Select A).ToList
            Dim AddItem As AccountDataSet.ExpenseSearchRow = ReturnValue.NewRow
            With AddItem
                .會計科目 = EachItemTemp.Split(",")(0)
                .明細科目 = EachItemTemp.Split(",")(1)
                If SubSearchResult.Count > 0 Then
                    .科目明細說明 = SubSearchResult(0).ACCTNOName & "(" & SubSearchResult(0).DETLNOName & ")"
                End If
                .成本單位 = EachItemTemp.Split(",")(2)
                If IsType1KeyInACJ050PF Then
                    .固定金額 = CType((From A In SubSearchResult Where A.IsFixMoney And A.DBORCR = "A" Select A.AMOUNT).Sum, Double)
                    .固定金額 = CType(Val(.固定金額) - CType((From A In SubSearchResult Where A.IsFixMoney And A.DBORCR = "B" Select A.AMOUNT).Sum, Double), Double)
                    .變動金額 = CType((From A In SubSearchResult Where A.IsFixMoney = False And A.DBORCR = "A" Select A.AMOUNT).Sum, Double)
                    .變動金額 = CType(Val(.變動金額) - CType((From A In SubSearchResult Where A.IsFixMoney = False And A.DBORCR = "B" Select A.AMOUNT).Sum, Double), Double)
                Else
                    .固定金額 = 0
                    .變動金額 = CType((From A In SubSearchResult Where A.DBORCR = "A" Select A.AMOUNT).Sum, Double)
                    .變動金額 = CType(Val(.變動金額) - CType((From A In SubSearchResult Where A.DBORCR = "B" Select A.AMOUNT).Sum, Double), Double)
                End If
                .固定金額 = Format(Val(.固定金額), "##,##0.##")
                .變動金額 = Format(Val(.變動金額), "##,##0.##")
                Dim FindBudget As String = FindBuget(SqlString1, EachItemTemp.Split(",")(0), EachItemTemp.Split(",")(1), EachItemTemp.Split(",")(2))
                If FindBudget <> "," Then
                    .固定預算 = FindBudget.Split(",")(0)
                    .變動預算 = FindBudget.Split(",")(1)
                    .固定預算 = Format(Val(.固定預算), "##,##0.##")
                    .變動預算 = Format(Val(.變動預算), "##,##0.##")
                End If
                .狀態說明 = "預算已執行"
            End With
            ReturnValue.Rows.Add(AddItem)
            LastACCTNO = EachItemTemp.Split(",")(0)
            LastDETLNO = EachItemTemp.Split(",")(1)
        Next

        '判定斷是否有未指定單位之預算,如有則新增一筆
        If Not String.IsNullOrEmpty(LastACCTNO) And ReturnValue.Count > 0 Then
            Dim FindBudget As String = FindBuget(SqlString1, LastACCTNO, LastDETLNO)
            If FindBudget <> "," Then
                Dim AddItem1 As AccountDataSet.ExpenseSearchRow = ReturnValue.NewRow
                With AddItem1
                    .會計科目 = LastACCTNO
                    .明細科目 = LastDETLNO
                    .成本單位 = "-----"
                    .固定預算 = FindBudget.Split(",")(0)
                    .變動預算 = FindBudget.Split(",")(1)
                    .固定預算 = Format(Val(.固定預算), "##,##0.##")
                    .變動預算 = Format(Val(.變動預算), "##,##0.##")
                    .狀態說明 = "預算已執行但無成本單位"
                End With
                ReturnValue.Rows.Add(AddItem1)
            End If
        End If

        '輸出有預算但未使用部份
        If Not IsNothing(QryResultNotUsed) AndAlso QryResultNotUsed.Count > 0 Then
            For Each EachItem In QryResultNotUsed
                Dim AddItem1 As AccountDataSet.ExpenseSearchRow = ReturnValue.NewRow
                With AddItem1
                    .會計科目 = EachItem.ACCTNO
                    .明細科目 = EachItem.DETLNO
                    .成本單位 = EachItem.DEPTNO
                    .固定預算 = EachItem.BDGFIX
                    .變動預算 = EachItem.BDGVAR
                    .固定金額 = Format(Val(.固定金額), "##,##0.##")
                    .變動金額 = Format(Val(.變動金額), "##,##0.##")
                    .固定預算 = Format(Val(.固定預算), "##,##0.##")
                    .變動預算 = Format(Val(.變動預算), "##,##0.##")
                    .狀態說明 = "有預算未執行"
                End With
                ReturnValue.Rows.Add(AddItem1)
            Next
        End If

        Return ReturnValue
    End Function

    Dim QryResultNotUsed As List(Of CompanyORMDB.ACAA.ACJ050PF) = Nothing

    Private Function FindBuget(ByVal QryString As String, ByVal ACCTNO As String, ByVal DETLNO As String, Optional ByVal DEPTNO As String = Nothing) As String
        ACCTNO = ACCTNO.Trim
        DETLNO = DETLNO.Trim
        If Not String.IsNullOrEmpty(DEPTNO) Then
            DEPTNO = DEPTNO.Trim
        End If
        Static Qry As String = Nothing
        Static QryResult As List(Of CompanyORMDB.ACAA.ACJ050PF) = Nothing
        If String.IsNullOrEmpty(QryString) Then
            Return ","
        End If
        If String.IsNullOrEmpty(Qry) OrElse Qry <> QryString Then
            Qry = QryString
            QryResult = CompanyORMDB.ACAA.ACJ050PF.CDBSelect(Of CompanyORMDB.ACAA.ACJ050PF)(QryString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            QryResultNotUsed = QryResult.ToList
        End If
        Dim SearchResult As List(Of CompanyORMDB.ACAA.ACJ050PF) = Nothing
        If String.IsNullOrEmpty(DEPTNO) Then
            SearchResult = (From A In QryResult Where A.ACCTNO.Trim = ACCTNO And A.DETLNO.Trim = DETLNO And A.DEPTNO.Trim = "" Select A).ToList
        Else
            SearchResult = (From A In QryResult Where A.ACCTNO.Trim = ACCTNO And A.DETLNO.Trim = DETLNO And A.DEPTNO.Trim = DEPTNO Select A).ToList
        End If
        If SearchResult.Count = 0 Then
            Return ","
        End If
        For Each EachItem In SearchResult
            QryResultNotUsed.Remove(EachItem)
        Next
        Return Format((From A In SearchResult Select A.BDGFIX).Sum, "0.00") & "," & Format((From A In SearchResult Select A.BDGVAR).Sum, "0.00")
    End Function
#End Region

#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim ReturnValue As String
        Dim ReturnValue1 As String
        Dim StartDate As Integer = New CompanyORMDB.AS400DateConverter(CType(Me.tbStartDate.Text, Date)).TwIntegerTypeData
        Dim EndDate As Integer = New CompanyORMDB.AS400DateConverter(CType(Me.tbEndDate.Text, Date)).TwIntegerTypeData
        ReturnValue = "Select * From  @#ACLIB.ACD010PF.SA WHERE ACTDAT>= " & StartDate & " AND ACTDAT<=" & EndDate

        '只可查詢民國100年以後的資料
        ReturnValue1 = "Select * From  @#ACAA.ACJ050PF.SA100A " & _
                  " WHERE ACCTYR>='100' AND BDGTTT > 0  AND ACCTYR>= '" & Format(CType(Me.tbStartDate.Text, Date), "yyyy") - 1911 & "' AND ACCTYR <= '" & Format(CType(Me.tbEndDate.Text, Date), "yyyy") - 1911 & "' "
        Dim ReturnValue00 As String = ReturnValue1 & " AND ACCTNO || DETLNO || DEPTNO  NOT IN ( Select ACCTNO || LEFT(DETLNO,4) || DEPTNO From @#ACLIB.ACD010PF.SA WHERE ACTDAT>=1000000 AND ACTDAT>= " & Format(CType(Me.tbStartDate.Text, Date), "yyyy") - 1911 & "0000 AND ACTDAT < " & Format(CType(Me.tbEndDate.Text, Date), "yyyy") - 1910 & "0000 )"


        If Not String.IsNullOrEmpty(tbACCTNO.Text) Then
            tbACCTNO.Text = tbACCTNO.Text.Replace("'", Nothing)
            If tbACCTNO.Text.Contains("~") Then
                ReturnValue &= IIf(tbACCTNO.Text.Trim.Length > 0, " AND ACCTNO >= '" & tbACCTNO.Text.Split("~")(0).Trim & "' AND ACCTNO <= '" & tbACCTNO.Text.Split("~")(1).Trim & "'", Nothing)
                ReturnValue1 &= IIf(tbACCTNO.Text.Trim.Length > 0, " AND ACCTNO >= '" & tbACCTNO.Text.Split("~")(0).Trim & "' AND ACCTNO <= '" & tbACCTNO.Text.Split("~")(1).Trim & "'", Nothing)
            Else
                ReturnValue &= IIf(tbACCTNO.Text.Trim.Length > 0, " AND ACCTNO IN ('" & tbACCTNO.Text.Replace(",", "','") & "')", Nothing)
                ReturnValue1 &= IIf(tbACCTNO.Text.Trim.Length > 0, " AND ACCTNO IN ('" & tbACCTNO.Text.Replace(",", "','") & "')", Nothing)
            End If
        End If

        '篩選費用類會計科目
        Dim ReturnValue0 As String = ReturnValue & " AND SUBSTR(ACCTNO,1,4) NOT IN ( Select DISTINCT ACCTNO FROM @#ACLIB.ACJ050PF.SA ) "
        ReturnValue &= " AND SUBSTR(ACCTNO,1,4) IN ( Select DISTINCT ACCTNO FROM @#ACLIB.ACJ050PF.SA )"


        Me.hfQryString.Value = ReturnValue & " Order by ACCTNO,DETLNO,DEPTNO"       'ACD010PF  有 AND ACJ050PF 有 以ACD010為主
        Me.hfQryString0.Value = ReturnValue0 & " Order by ACCTNO,DETLNO,DEPTNO"     'ACD010PF  有 AND ACJ050PF 無 以ACD010為主
        Me.hfQryString1.Value = ReturnValue1 & " Order by ACCTNO,DETLNO,DEPTNO"     'ACJ050PF查詢範圍全部 以ACJ050PF為主
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
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = New PublicClassLibrary.DataConvertExcel(Search(Me.hfQryString.Value, Me.hfQryString0.Value, Me.hfQryString1.Value), "費用科目金額合計" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub
End Class