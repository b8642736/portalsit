Public Class ProductBugSearch
    Inherits System.Web.UI.UserControl


#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="QryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Search(ByVal QryString As String, ByVal BugsFilter As String) As QualityControlDataSet.ProductBugSearchDataTable
        Dim ReturnValue As New QualityControlDataSet.ProductBugSearchDataTable
        If String.IsNullOrEmpty(QryString) Then
            Return ReturnValue
        End If
        Dim ReturnValueTemp As New QualityControlDataSet.ProductBugSearchDataTable
        Dim SearchResult As List(Of DataRow) = (From A In New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QryString).SelectQuery).ToList
        For Each EachItem As DataRow In SearchResult
            For FieldCount = 24 To 45 Step 3
                If IsDBNull(EachItem.Item("QCP" & FieldCount)) OrElse CType(EachItem.Item("QCP" & FieldCount), Integer) = 0 Then
                    Continue For
                End If
                AddBugDataTable(EachItem, ReturnValueTemp, FieldCount)
            Next
        Next


        Static AllPPSDEFPFKeyAndNames As Dictionary(Of Integer, String)
        If IsNothing(AllPPSDEFPFKeyAndNames) Then
            AllPPSDEFPFKeyAndNames = New Dictionary(Of Integer, String)
            Dim AS400Adapter As New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            For Each EachItem In CompanyORMDB.PPS100LB.PPSDEFPF.ALL_PPSDEPF(AS400Adapter)
                AllPPSDEFPFKeyAndNames.Add(EachItem.DEF01, EachItem.DEF02)
            Next
        End If


        For Each EachItem In (From A In ReturnValueTemp Where (String.IsNullOrEmpty(BugsFilter) OrElse BugsFilter.Split(",").Contains(A.缺陷代碼)) Select A Order By A.缺陷代碼, A.鋼種, A.表面, A.鋼捲編號).ToList
            Dim AddRow As QualityControlDataSet.ProductBugSearchRow = ReturnValue.NewRow
            With AddRow
                .缺陷代碼 = EachItem("缺陷代碼")
                If AllPPSDEFPFKeyAndNames.ContainsKey(Val(.缺陷代碼)) Then
                    .缺陷代碼 &= AllPPSDEFPFKeyAndNames(Val(.缺陷代碼))
                End If
                .鋼種 = EachItem("鋼種")
                .表面 = EachItem("表面")
                '.缺陷等級 = EachItem("缺陷等級")
                .鋼捲編號 = EachItem("鋼捲編號")
                .重量 = EachItem("重量")
                .長度 = EachItem("長度")
                .厚度 = EachItem("厚度")
                .寬度 = EachItem("寬度")
                .淨重 = EachItem("淨重")
                .一級重量 = EachItem("一級重量")
                .二級重量 = EachItem("二級重量")
                .三級重量 = EachItem("三級重量")
                .頭尾重量 = EachItem("頭尾重量")
                .邊切重量 = EachItem("邊切重量")
                .廢料重量 = EachItem("廢料重量")
            End With
            ReturnValue.Rows.Add(AddRow)
        Next

        Return ReturnValue
    End Function

    Private Sub AddBugDataTable(ByVal AddDataRow As DataRow, ByRef TargetDataTable As QualityControlDataSet.ProductBugSearchDataTable, ByVal QCPFieldNumber As Integer)
        Dim AddRow As QualityControlDataSet.ProductBugSearchRow = TargetDataTable.NewRow
        '計算等級長度比
        Dim BugLengRate As Single
        Dim LevelTotalLeng As Double = 0
        Select Case True
            Case QCPFieldNumber >= 24 And QCPFieldNumber <= 35
                For FieldCount = 24 To 33 Step 3
                    LevelTotalLeng += CType(AddDataRow.Item("QCP" & FieldCount), Double)
                Next
            Case QCPFieldNumber >= 36 And QCPFieldNumber <= 47
                For FieldCount = 36 To 45 Step 3
                    LevelTotalLeng += CType(AddDataRow.Item("QCP" & FieldCount), Double)
                Next
            Case Else
                Exit Sub
        End Select
        BugLengRate = CType(AddDataRow.Item("QCP" & QCPFieldNumber), Double) / LevelTotalLeng

        With AddRow
            .缺陷代碼 = CType(AddDataRow.Item("QCP" & QCPFieldNumber), String)
            .鋼種 = CType(AddDataRow.Item("CIA05"), String).Trim
            .表面 = CType(AddDataRow.Item("CIA06"), String).Trim
            '.缺陷等級 = IIf(QCPFieldNumber >= 24 And QCPFieldNumber <= 35, "二級", "三級")
            .鋼捲編號 = CType(AddDataRow.Item("QCP02"), String).Trim & CType(AddDataRow.Item("QCP03"), String).Trim
            .重量 = Format(IIf(QCPFieldNumber >= 24 And QCPFieldNumber <= 35, CType(AddDataRow.Item("CIA24"), Double), CType(AddDataRow.Item("CIA25"), Double)) * BugLengRate, "0,0.0")
            .長度 = CType(AddDataRow.Item("QCP" & QCPFieldNumber + 1), Double)
            .厚度 = CType(AddDataRow.Item("QCP06"), Double)
            .寬度 = CType(AddDataRow.Item("QCP07"), Double)
            .淨重 = Format(CType(AddDataRow.Item("CIA13"), Double), "0.0")
            .一級重量 = Format(CType(AddDataRow.Item("CIA23"), Double), "0.0")
            .二級重量 = Format(CType(AddDataRow.Item("CIA24"), Double), "0.0")
            .三級重量 = Format(CType(AddDataRow.Item("CIA25"), Double), "0.0")
            .頭尾重量 = Format(CType(AddDataRow.Item("CIA26"), Double), "0.0")
            .邊切重量 = Format(CType(AddDataRow.Item("CIA27"), Double), "0.0")
            .廢料重量 = Format(CType(AddDataRow.Item("CIA28"), Double), "0.0")
        End With
        TargetDataTable.Rows.Add(AddRow)
    End Sub
#End Region

#Region "設定查詢條件至控制項 屬性:SetQryStringToControl"
    ''' <summary>
    ''' 設定查詢條件至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetQryStringToControl()
        Dim ReturnValue As New StringBuilder
        ReturnValue.Append("Select A.* , B.* From @#PPS100LB.PPSCIAPF A LEFT JOIN @#PPS100LB.PPSQCPPF B ON A.CIA02=B.QCP02 AND A.CIA03=B.QCP03 AND A.CIA55<=B.QCP04 WHERE  A.CIA06 IN (SELECT CH201 FROM @#SLS300LB.SL2CH2PF WHERE CH202=' ' ) AND A.CIA45 IN ('C','D','Z','*','R') ")
        ReturnValue.Append(" AND CIA58>=" & New AS400DateConverter(Me.tbStartDate1.Text).TwIntegerTypeData & " AND CIA58<=" & New AS400DateConverter(Me.tbEndDate1.Text).TwIntegerTypeData)

        Me.hfQryString.Value = Nothing
        Me.hfBugFilters.Value = Nothing

        If Not String.IsNullOrEmpty(tbBugCode.Text) Then
            Me.hfBugFilters.Value = tbBugCode.Text.Replace("'", Nothing)
            ReturnValue.Append(" AND (")
            Dim IsFirtRoop As Boolean = True
            For FieldCount = 24 To 45 Step 3
                ReturnValue.Append(IIf(IsFirtRoop, Nothing, " OR ") & " QCP" & FieldCount & " IN (" & Me.hfBugFilters.Value & ")")
                IsFirtRoop = False
            Next
            ReturnValue.Append(")")
        End If


        If Not String.IsNullOrEmpty(tbSteelKindType.Text) Then
            ReturnValue.Append(" AND CIA05 IN ('" & tbSteelKindType.Text.Replace("'", Nothing).Replace(",", "','").Trim & "')")
        End If

        If Not String.IsNullOrEmpty(tbFace.Text) Then
            ReturnValue.Append(" AND CIA06 IN ('" & tbFace.Text.Replace("'", Nothing).Replace(",", "','").Trim & "')")
        End If

        ReturnValue.Append(" ORDER BY CIA05 , CIA06")
        Me.hfQryString.Value = ReturnValue.ToString
    End Sub
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim StartDate As DateTime = New Date(Now.Year, Now.Month, 1)
            Dim EndDate As DateTime = StartDate.AddDays(5)
            Me.tbStartDate1.Text = StartDate
            Me.tbEndDate1.Text = EndDate
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SetQryStringToControl()
        GridView1.DataBind()
    End Sub

    Protected Sub btnSearchToExcel_Click(sender As Object, e As EventArgs) Handles btnSearchToExcel.Click
        SetQryStringToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = New PublicClassLibrary.DataConvertExcel(Search(Me.hfQryString.Value, Me.hfBugFilters.Value), "成品缺陷細目查詢" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub
End Class