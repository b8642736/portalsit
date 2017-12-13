Public Class CoilLevelWeightSearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String, ByVal AllPPSSHASQLString As String) As QualityControlDataSet.CoilLevelWeightSearchDataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return New QualityControlDataSet.CoilLevelWeightSearchDataTable
        End If

        Dim AboutAllPPSSHAPFs As New List(Of CompanyORMDB.IPPS100LB.IPPSSHAPF)
        For Each EachItem In CompanyORMDB.PPS100LB.PPSSHAPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSSHAPF)(AllPPSSHASQLString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            AboutAllPPSSHAPFs.Add(EachItem)
        Next

        Dim QryResult As DataTable = New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC).SelectQuery(SQLString)
        Dim ReturnValue As New QualityControlDataSet.CoilLevelWeightSearchDataTable
        For Each EachITtem As DataRow In QryResult.Rows
            Dim AddItem As QualityControlDataSet.CoilLevelWeightSearchRow = ReturnValue.NewRow
            With AddItem
                .鋼捲號碼 = EachITtem.Item("CIA02") & CType(EachITtem.Item("CIA03"), String).Trim
                .鋼種 = EachITtem.Item("CIA05")
                .表面 = EachITtem.Item("CIA06")
                .厚度 = EachITtem.Item("CIA07")
                .寬度 = EachITtem.Item("CIA08")
                .等級 = EachITtem.Item("CIA16")
                .淨重 = EachITtem.Item("CIA13")
                'If Not IsDBNull(EachITtem.Item("QCP21")) Then
                '    .一級缺陷 = GetBugName(EachITtem.Item("QCP21"))
                'End If
                If Not IsDBNull(EachITtem.Item("CIA52")) AndAlso CType(EachITtem.Item("CIA52"), String).Trim = "X" _
                    AndAlso Not IsDBNull(EachITtem.Item("CIA23")) AndAlso Val(EachITtem.Item("CIA23")) > 0 Then
                    Dim SetValue As String = ""
                    If Not IsDBNull(EachITtem.Item("QCP21")) AndAlso Trim(CType(EachITtem.Item("QCP21"), String)).Length > 0 Then
                        SetValue = GetBugName(EachITtem.Item("QCP21"))
                    End If
                    If SetValue = "" AndAlso Not IsDBNull(EachITtem.Item("QCP24")) AndAlso Trim(CType(EachITtem.Item("QCP24"), Integer)) > 0 Then
                        SetValue = GetBugName(EachITtem.Item("QCP24"))
                    End If
                    .一級X缺陷 = SetValue
                End If
                If Not IsDBNull(EachITtem.Item("QCP24")) Then
                    .二級缺陷1 = GetBugName(EachITtem.Item("QCP24"))
                End If
                If Not IsDBNull(EachITtem.Item("QCP27")) Then
                    .二級缺陷2 = GetBugName(EachITtem.Item("QCP27"))
                End If
                If Not IsDBNull(EachITtem.Item("QCP30")) Then
                    .二級缺陷3 = GetBugName(EachITtem.Item("QCP30"))
                End If
                If Not IsDBNull(EachITtem.Item("QCP33")) Then
                    .二級缺陷4 = GetBugName(EachITtem.Item("QCP33"))
                End If
                If Not IsDBNull(EachITtem.Item("QCP36")) Then
                    .三級缺陷1 = GetBugName(EachITtem.Item("QCP36"))
                End If
                If Not IsDBNull(EachITtem.Item("QCP39")) Then
                    .三級缺陷2 = GetBugName(EachITtem.Item("QCP39"))
                End If
                If Not IsDBNull(EachITtem.Item("QCP42")) Then
                    .三級缺陷3 = GetBugName(EachITtem.Item("QCP42"))
                End If
                If Not IsDBNull(EachITtem.Item("QCP45")) Then
                    .三級缺陷4 = GetBugName(EachITtem.Item("QCP45"))
                End If
                If Not IsDBNull(EachITtem.Item("QCP48")) Then
                    .頭尾缺陷 = GetBugName(EachITtem.Item("QCP48"))
                End If
                If Not IsDBNull(EachITtem.Item("QCP51")) Then
                    .邊切缺陷 = GetBugName(EachITtem.Item("QCP51"))
                End If
                If Not IsDBNull(EachITtem.Item("QCP56")) Then
                    .廢鋼缺陷 = GetBugName(EachITtem.Item("QCP56"))
                End If
                If Not IsDBNull(EachITtem.Item("QOO12")) Then
                    .原因說明 = EachITtem.Item("QOO12")
                End If
                '重量
                If Not IsDBNull(EachITtem.Item("CIA52")) AndAlso CType(EachITtem.Item("CIA52"), String).Trim = "X" Then
                    .一級X重量 = EachITtem.Item("CIA23")    '1X級重量
                    .一級重量 = 0
                Else
                    .一級重量 = EachITtem.Item("CIA23")     '正常1級重量
                    .一級X重量 = 0
                End If
                .二級重量 = EachITtem.Item("CIA24")
                .三級重量 = EachITtem.Item("CIA25")
                If Not IsDBNull(EachITtem.Item("QCP16")) AndAlso Val(EachITtem.Item("QCP16")) <> 0 Then
                    If Not IsDBNull(EachITtem.Item("QCP25")) Then
                        .二級缺陷1重量 = Format(Val(EachITtem.Item("CIA24")) * (Val(EachITtem.Item("QCP25")) / Val(EachITtem.Item("QCP16"))), "0")
                    End If
                    If Not IsDBNull(EachITtem.Item("QCP28")) Then
                        .二級缺陷2重量 = Format(Val(EachITtem.Item("CIA24")) * (Val(EachITtem.Item("QCP28")) / Val(EachITtem.Item("QCP16"))), "0")
                    End If
                    If Not IsDBNull(EachITtem.Item("QCP31")) Then
                        .二級缺陷3重量 = Format(Val(EachITtem.Item("CIA24")) * (Val(EachITtem.Item("QCP31")) / Val(EachITtem.Item("QCP16"))), "0")
                    End If
                    If Not IsDBNull(EachITtem.Item("QCP34")) Then
                        .二級缺陷4重量 = Format(Val(EachITtem.Item("CIA24")) * (Val(EachITtem.Item("QCP34")) / Val(EachITtem.Item("QCP16"))), "0")
                    End If
                End If
                If Not IsDBNull(EachITtem.Item("QCP17")) AndAlso Val(EachITtem.Item("QCP17")) <> 0 Then
                    If Not IsDBNull(EachITtem.Item("QCP37")) Then
                        .三級缺陷1重量 = Format(Val(EachITtem.Item("CIA25")) * (Val(EachITtem.Item("QCP37")) / Val(EachITtem.Item("QCP17"))), "0")
                    End If
                    If Not IsDBNull(EachITtem.Item("QCP40")) Then
                        .三級缺陷2重量 = Format(Val(EachITtem.Item("CIA25")) * (Val(EachITtem.Item("QCP40")) / Val(EachITtem.Item("QCP17"))), "0")
                    End If
                    If Not IsDBNull(EachITtem.Item("QCP43")) Then
                        .三級缺陷3重量 = Format(Val(EachITtem.Item("CIA25")) * (Val(EachITtem.Item("QCP43")) / Val(EachITtem.Item("QCP17"))), "0")
                    End If
                    If Not IsDBNull(EachITtem.Item("QCP46")) Then
                        .三級缺陷4重量 = Format(Val(EachITtem.Item("CIA25")) * (Val(EachITtem.Item("QCP46")) / Val(EachITtem.Item("QCP17"))), "0")
                    End If
                End If
                If Not IsDBNull(EachITtem.Item("QCP11")) Then
                    .內外銷 = EachITtem.Item("QCP11")
                End If
                If Not IsDBNull(EachITtem.Item("CIA41")) Then
                    Select Case True
                        Case CType(EachITtem.Item("CIA41"), String).Trim = "U"
                            .裁邊 = ""
                        Case CType(EachITtem.Item("CIA41"), String).Trim = ""
                            .裁邊 = "B"
                    End Select
                End If
                If Not IsDBNull(EachITtem.Item("CIA33")) Then
                    .料別 = EachITtem.Item("CIA33")
                End If
                If Not IsDBNull(EachITtem.Item("BLA07")) Then
                    .鋼胚號碼 = EachITtem.Item("BLA07")
                End If
                If Not IsDBNull(EachITtem.Item("BLA01")) Then
                    .熱軋號碼 = EachITtem.Item("BLA01")
                End If
                If Not IsDBNull(EachITtem.Item("BLA11")) Then
                    .熱軋批號 = EachITtem.Item("BLA11")
                End If

                Dim CurrentPPSCIAPF As New PPS100LB.PPSCIAPF
                CurrentPPSCIAPF.CDBSetDataRowValueToObject(EachITtem)
                Dim SearchResult1 As List(Of IPPS100LB.IPPSSHAPF) = (From A In AboutAllPPSSHAPFs Where A.SHA01 = CurrentPPSCIAPF.CIA02 Select A).ToList
                If SearchResult1.Count > 0 Then
                    .黑皮重 = CType((New CoilYieldRateCompute(CurrentPPSCIAPF, SearchResult1)).InputWeight, Long)
                    If Val(.一級重量) > 0 AndAlso Val(.淨重) > 0 Then
                        .一級品百分比 = Format(Val(.一級重量) / Val(.淨重), "0.0%")
                    End If
                    If Val(.淨重) > 0 AndAlso Val(.黑皮重) > 0 Then
                        .產出百分比 = Format(Val(.淨重) / Val(.黑皮重), "0.0%")
                    End If
                End If

                If Not IsDBNull(EachITtem.Item("BLA03")) Then
                    .黑皮厚度 = EachITtem.Item("BLA03")
                End If

                If Not IsDBNull(EachITtem.Item("CIA26")) Then
                    .頭尾重量 = EachITtem.Item("CIA26")
                End If
                If Not IsDBNull(EachITtem.Item("CIA27")) Then
                    .邊切重量 = EachITtem.Item("CIA27")
                End If
                If Not IsDBNull(EachITtem.Item("CIA28")) Then
                    .廢鋼重量 = EachITtem.Item("CIA28")
                End If
                If Not IsDBNull(EachITtem.Item("QCP71")) And Val(EachITtem.Item("QCP71")) > 0 Then
                    .繳庫切除頭尾缺陷 = GetBugName(Val(EachITtem.Item("QCP71")))
                End If
                If Not IsDBNull(EachITtem.Item("CIA13")) AndAlso Not IsDBNull(EachITtem.Item("CIA09")) AndAlso Not IsDBNull(EachITtem.Item("QCP72")) Then
                    .繳庫切除頭尾重 = Format(Val(EachITtem.Item("CIA13")) * (Val(EachITtem.Item("QCP72")) / Val(EachITtem.Item("CIA09"))), "0")
                End If
                .客戶編號 = CType(EachITtem.Item("CIA04"), String).PadRight(3).Substring(0, 3)
                .客戶名稱 = GetCustomerName(.客戶編號.Trim)
            End With
            ReturnValue.Rows.Add(AddItem)
        Next
        Return ReturnValue
    End Function

    Private Function GetBugName(ByVal BugCode As String) As String
        If String.IsNullOrEmpty(BugCode) OrElse BugCode.Trim.Length = 0 Then
            Return Nothing
        End If

        'Dim QryResult As DataTable = New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC).SelectQuery("Select * from @#PPS100LB.PPSDEFPF ORDER BY DEF01")
        Static QryResult As DataTable
        If IsNothing(QryResult) Then
            QryResult = New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC).SelectQuery("Select * from @#PPS100LB.PPSDEFPF ORDER BY DEF01")
        End If

        Dim GetReturnDataRow As DataRow = (From A In QryResult Where CType(A.Item("DEF01"), String) = BugCode Select A).FirstOrDefault
        If IsNothing(GetReturnDataRow) Then
            Return Nothing
        End If
        Return GetReturnDataRow.Item("DEF02")
    End Function
    Private Function GetCustomerName(ByVal CustomerID As String) As String
        If String.IsNullOrEmpty(CustomerID) OrElse CustomerID.Trim.Length = 0 Then
            Return Nothing
        End If
        Static SearchResult As List(Of CompanyORMDB.SLS300LB.SL2CUAPF)
        If IsNothing(SearchResult) Then
            Dim SQLString As String = "Select * from @#SLS300LB.SL2CUAPF"
            SearchResult = CompanyORMDB.SLS300LB.SL2QTNPF.CDBSetDataTableToObjects(Of CompanyORMDB.SLS300LB.SL2CUAPF)(New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString).SelectQuery)
        End If
        Return (From A In SearchResult Where A.CUA01 = CustomerID Select A.CUA11).FirstOrDefault
    End Function
#End Region


#Region "SQL查詢產生至控制項 方法:MakerSQLStringToControl"
    ''' <summary>
    ''' 查詢產生至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakerSQLStringToControl()
        Dim ReturnValue As New StringBuilder
        Dim FromWhereString As New StringBuilder
        ReturnValue.Append("Select  A.* ,B.*, C.QOO12, D.BLA07, D.BLA01, D.BLA11, D.BLA06, D.BLA03 ")
        FromWhereString.Append(" From @#PPS100LB.PPSCIAPF A LEFT JOIN @#PPS100LB.PPSQCPPF B ON A.CIA02 || A.CIA03 = B.QCP02 || B.QCP03 AND A.CIA58=B.QCP59 LEFT JOIN @#PPS100LB.PPSQCOPF C ON A.CIA02=C.QCP02 AND A.CIA03=C.QCP03 AND A.CIA58=C.QCP59  AND C.QOO11=1  LEFT JOIN @#PPS100LB.PPSBLAPF D ON A.CIA02 = D.BLA09 AND A.CIA55 >= D.BLA08")
        FromWhereString.Append("  WHERE 1=1 ")

        If ddsSearchDateMode.Text = "會計日期" Then
            FromWhereString.Append("  AND  A.CIA58 >= " & (New CompanyORMDB.AS400DateConverter(CType(Me.tbStartDate.Text, Date))).TwIntegerTypeData & " AND A.CIA58 <= " & (New CompanyORMDB.AS400DateConverter(CType(Me.tbEndDate.Text, Date))).TwIntegerTypeData & " AND B.QCP59 >= " & (New CompanyORMDB.AS400DateConverter(CType(Me.tbStartDate.Text, Date))).TwIntegerTypeData & " AND B.QCP59 <= " & (New CompanyORMDB.AS400DateConverter(CType(Me.tbEndDate.Text, Date))).TwIntegerTypeData)
        ElseIf ddsSearchDateMode.Text = "繳庫日期" Then
            FromWhereString.Append("  AND  A.CIA55 >= " & (New CompanyORMDB.AS400DateConverter(CType(Me.tbStartDate.Text, Date))).TwIntegerTypeData & " AND A.CIA55 <= " & (New CompanyORMDB.AS400DateConverter(CType(Me.tbEndDate.Text, Date))).TwIntegerTypeData & " AND B.QCP59 >= A.CIA58 AND B.QCP59 <= A.CIA58  ")
        End If

        FromWhereString.Append(" AND A.CIA06 IN (SELECT CH201 FROM @#SLS300LB.SL2CH2PF WHERE CH202<>'Y')")

        If Not String.IsNullOrEmpty(tbLevels.Text) AndAlso tbLevels.Text.Trim.Length > 0 Then
            FromWhereString.Append(" AND A.CIA16 IN ('" & Me.tbLevels.Text.Replace(",", "','") & "')")
        End If
        If CheckBox1.Checked Then
            If Not String.IsNullOrEmpty(tbStartWeight.Text) AndAlso tbStartWeight.Text.Trim.Length > 0 Then
                FromWhereString.Append(" AND A.CIA13>=" & Me.tbStartWeight.Text)
            End If
            If Not String.IsNullOrEmpty(tbEndWeight.Text) AndAlso tbEndWeight.Text.Trim.Length > 0 Then
                FromWhereString.Append(" AND A.CIA13<=" & Me.tbEndWeight.Text)
            End If
        End If

        Dim SHAQry As New StringBuilder
        SHAQry.Append(String.Format("Select * FROM @#PPS100LB.PPSSHAPF  Where SHA01 IN (Select A.CIA02 {0})", FromWhereString.ToString))

        ReturnValue.Append(FromWhereString.ToString)
        ReturnValue.Append(" ORDER BY cia02,cia03")

        Me.HFQry.Value = ReturnValue.ToString
        Me.HFQry0.Value = SHAQry.ToString
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.tbStartDate.Text = Format(New Date(Now.Year, Now.Month, 1), "yyyy/MM/dd")
            Me.tbEndDate.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        MakerSQLStringToControl()
        Me.GridView1.DataBind()
    End Sub

    Protected Sub btnDownToExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDownToExcel.Click
        MakerSQLStringToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = New PublicClassLibrary.DataConvertExcel(Search(Me.HFQry.Value, Me.HFQry0.Value), "鋼捲等級重量查詢" & Format(Now, "mmss") & ".xls")
        If Not IsNothing(ExcelConvert) Then
            ExcelConvert.DownloadEXCELFile(Me.Response)
        End If

    End Sub
End Class