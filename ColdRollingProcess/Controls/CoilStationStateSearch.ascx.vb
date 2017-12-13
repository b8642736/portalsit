Public Class CoilStationStateSearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="QryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryString As String) As ColdRollingProcessDataSet.CoilStationStateSearchDataTable
        Dim ReturnValue As New ColdRollingProcessDataSet.CoilStationStateSearchDataTable
        If String.IsNullOrEmpty(QryString) Then
            Return ReturnValue
        End If
        Dim Adapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB", QryString)
        Dim SearchResult As List(Of DataRow) = (From A In Adapter.SelectQuery.Rows Select CType(A, DataRow)).ToList
        Dim AS400PPSSHAPFAndSL2CICPFDatas As DataTable = FindAS400DatasFromSearchData(SearchResult)
        Dim AS400PPSSHAPFAndSL2CICPFData As DataRow = Nothing
        For Each EachItem As DataRow In SearchResult
            Dim AddRow As ColdRollingProcessDataSet.CoilStationStateSearchRow = ReturnValue.NewRow
            With AddRow
                .鋼捲號碼 = EachItem.Item("FK_OutSHA01") & EachItem.Item("FK_OutSHA02")
                .重量 = EachItem.Item("Weight")
                .厚度 = EachItem.Item("Guage")
                .寬度 = EachItem.Item("Width")
                .線別 = EachItem.Item("FK_RunStationName")
                .產出時間 = Format(EachItem.Item("CoilEndTime"), "yyyy/MM/dd HH:mm:ss")
                AS400PPSSHAPFAndSL2CICPFData = (From A In AS400PPSSHAPFAndSL2CICPFDatas.Rows Where CType(A.Item("SHA01"), String) = CType(EachItem.Item("FK_LastRefSHA01"), String) And CType(A.Item("SHA02"), String).Trim = CType(EachItem.Item("FK_LastRefSHA02"), String).Trim And CType(A.Item("SHA04"), String) = CType(EachItem.Item("FK_LastRefSHA04"), Integer) Select A).FirstOrDefault
                If Not IsNothing(AS400PPSSHAPFAndSL2CICPFData) Then
                    .鋼種 = AS400PPSSHAPFAndSL2CICPFData.Item("SHA12")
                    .表面 = AS400PPSSHAPFAndSL2CICPFData.Item("SHA39")
                    .料別 = AS400PPSSHAPFAndSL2CICPFData.Item("SHA36")
                    If Not IsDBNull(AS400PPSSHAPFAndSL2CICPFData.Item("BLA11")) Then
                        .熱軋批次 = AS400PPSSHAPFAndSL2CICPFData.Item("BLA11")
                    End If
                    If Not IsDBNull(AS400PPSSHAPFAndSL2CICPFData.Item("CIC10")) Then
                        .報價單號碼 = AS400PPSSHAPFAndSL2CICPFData.Item("CIC10")
                    End If
                    If Not IsDBNull(AS400PPSSHAPFAndSL2CICPFData.Item("CIC14")) Then
                        Dim Cic14String As String = CType(AS400PPSSHAPFAndSL2CICPFData.Item("CIC14"), String).Trim.PadRight(4)
                        .報價單厚度 = Cic14String.Substring(0, 1) & "." & Cic14String.Substring(1, 3)
                    End If
                End If
            End With
            ReturnValue.Rows.Add(AddRow)
        Next

        Return ReturnValue
    End Function

    Public Function Search1(ByVal QryString As String) As ColdRollingProcessDataSet.CoilStationStateSearch1DataTable
        Dim ReturnValue As New ColdRollingProcessDataSet.CoilStationStateSearch1DataTable
        If String.IsNullOrEmpty(QryString) Then
            Return ReturnValue
        End If
        Dim Adapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB", QryString)
        Dim SearchResult As List(Of DataRow) = (From A In Adapter.SelectQuery.Rows Select CType(A, DataRow)).ToList
        Dim AS400PPSSHAPFAndSL2CICPFDatas As DataTable = FindAS400DatasFromSearchData(SearchResult)
        Dim AS400PPSSHAPFAndSL2CICPFData As DataRow = Nothing
        For Each EachItem As DataRow In SearchResult
            Dim AddRow As ColdRollingProcessDataSet.CoilStationStateSearch1Row = ReturnValue.NewRow
            With AddRow
                .鋼捲號碼 = EachItem.Item("FK_OutSHA01") & EachItem.Item("FK_OutSHA02")
                .重量 = EachItem.Item("Weight")
                .厚度 = EachItem.Item("Guage")
                .寬度 = EachItem.Item("Width")
                .線別 = EachItem.Item("FK_RunStationName")
                .產出時間 = Format(EachItem.Item("CoilEndTime"), "yyyy/MM/dd HH:mm:ss")
                .L2運作時間 = Format(EachItem.Item("SysCoilStartTime"), "yyyy/MM/dd HH:mm:ss") & "~" & Format(EachItem.Item("SysCoilEndTime"), "HH:mm:ss")
                AS400PPSSHAPFAndSL2CICPFData = (From A In AS400PPSSHAPFAndSL2CICPFDatas.Rows Where CType(A.Item("SHA01"), String) = CType(EachItem.Item("FK_LastRefSHA01"), String) And CType(A.Item("SHA02"), String).Trim = CType(EachItem.Item("FK_LastRefSHA02"), String).Trim And CType(A.Item("SHA04"), String) = CType(EachItem.Item("FK_LastRefSHA04"), Integer) Select A).FirstOrDefault
                If Not IsNothing(AS400PPSSHAPFAndSL2CICPFData) Then
                    .鋼種 = AS400PPSSHAPFAndSL2CICPFData.Item("SHA12")
                    .表面 = AS400PPSSHAPFAndSL2CICPFData.Item("SHA39")
                    .料別 = AS400PPSSHAPFAndSL2CICPFData.Item("SHA36")
                    .熱軋批次 = AS400PPSSHAPFAndSL2CICPFData.Item("BLA11")
                    .AS400運作時間 = Val(AS400PPSSHAPFAndSL2CICPFData.Item("SHA21")) + 1911 & "  " & Format(AS400PPSSHAPFAndSL2CICPFData.Item("SHA22"), "00") & Format(AS400PPSSHAPFAndSL2CICPFData.Item("SHA23"), "00") & "~" & Format(AS400PPSSHAPFAndSL2CICPFData.Item("SHA24"), "00") & Format(AS400PPSSHAPFAndSL2CICPFData.Item("SHA25"), "00")
                    If Not IsDBNull(AS400PPSSHAPFAndSL2CICPFData.Item("CIC10")) Then
                        .報價單號碼 = AS400PPSSHAPFAndSL2CICPFData.Item("CIC10")
                    End If
                    If Not IsDBNull(AS400PPSSHAPFAndSL2CICPFData.Item("CIC14")) Then
                        Dim Cic14String As String = CType(AS400PPSSHAPFAndSL2CICPFData.Item("CIC14"), String).Trim.PadRight(4)
                        .報價單厚度 = Cic14String.Substring(0, 1) & "." & Cic14String.Substring(1, 3)
                    End If
                End If
            End With
            ReturnValue.Rows.Add(AddRow)
        Next

        Return ReturnValue
    End Function

    '由 AS400取得PPSSHAPF資料
    Private Function FindAS400DatasFromSearchData(ByRef SearchData As List(Of DataRow)) As DataTable
        If SearchData.Count = 0 Then
            Return New DataTable
        End If
        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim QryString As New StringBuilder
        'QryString.Append("Select A.SHA01,A.SHA02,A.SHA04,A.SHA12,A.SHA36,A.SHA39,B.CIC10,B.CIC14 from @#PPS100LB.PPSSHAPF A LEFT JOIN @#SLS300LB.SL2CICPF B ON A.SHA01 || A.SHA02 = B.CIC01 || B.CIC02  WHERE A.SHA01 || A.SHA02 IN (")
        QryString.Append("Select A.SHA01,A.SHA02,A.SHA04,A.SHA12,A.SHA21,A.SHA22,A.SHA23,A.SHA24,A.SHA25,A.SHA36,A.SHA39,B.CIC10,B.CIC14,C.BLA11 from @#PPS100LB.PPSSHAPF A LEFT JOIN @#SLS300LB.SL2CICPF B ON A.SHA01 || A.SHA02 = B.CIC01 || B.CIC02  LEFT JOIN @#PPS100LB.PPSBLAPF C ON A.SHA01 = C.BLA09 WHERE A.SHA01 || A.SHA02 IN (")

        Dim IsSecondDatas As Boolean = False
        For Each EachItem As DataRow In SearchData
            QryString.Append(IIf(IsSecondDatas, ",'", "'") & CType(EachItem.Item("FK_LastRefSHA01"), String) & CType(EachItem.Item("FK_LastRefSHA02"), String).Trim & "'")
            IsSecondDatas = True
        Next
        QryString.Append(")")
        Return Adapter.SelectQuery(QryString.ToString)
    End Function
#End Region

#Region "查詢條件產生至控制項 方法:ControlWhereMaker"
    ''' <summary>
    ''' 查詢條件產生至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakerQryStringToControl()
        Dim ReturnValue As New StringBuilder
        ReturnValue.Append("SELECT FK_OutSHA01,FK_OutSHA02,Weight,Guage,Width,FK_RunStationName,CoilEndTime,FK_LastRefSHA01,FK_LastRefSHA02,FK_LastRefSHA04,SysCoilStartTime,SysCoilEndTime FROM RunProcessData A  Where A.CoilEndTime >= '" & Me.tbStartDate.Text.Replace("'", Nothing) & "' AND A.CoilEndTime < '" & CType(Me.tbEndDate.Text.Replace("'", Nothing), Date).AddDays(1).ToString("yyyy/MM/dd") & "' ")

        tbCoilNumbers.Text = tbCoilNumbers.Text.Replace("'", Nothing)
        If tbCoilNumbers.Text.Contains("~") Then
            ReturnValue.Append(IIf(tbCoilNumbers.Text.Trim.Length > 0, " AND RTRIM(A.FK_OutSHA01 + A.FK_OutSHA02) >= '" & tbCoilNumbers.Text.Split("~")(0).Trim & "' AND RTRIM(A.FK_OutSHA01 + A.FK_OutSHA02) <= '" & tbCoilNumbers.Text.Split("~")(1).Trim & "'", Nothing))
        Else
            ReturnValue.Append(IIf(tbCoilNumbers.Text.Trim.Length > 0, " AND RTRIM(A.FK_OutSHA01 + A.FK_OutSHA02) IN ('" & tbCoilNumbers.Text.Replace(",", "','") & "')", Nothing))
        End If

        Dim FilterLines As String = Nothing
        For Each EachControl As Control In paLines.Controls
            If TypeOf EachControl Is CheckBox AndAlso CType(EachControl, CheckBox).Checked Then
                FilterLines &= IIf(String.IsNullOrEmpty(FilterLines), "", ",") & CType(EachControl, CheckBox).Text
            End If
        Next
        If Not String.IsNullOrEmpty(FilterLines) Then
            ReturnValue.Append(" AND ( ")
            Dim IsFirtInRoop As Boolean = True
            For Each EachItem As String In FilterLines.Split(",")
                ReturnValue.Append(IIf(IsFirtInRoop = False, " OR ", "") & " A.FK_RunStationName Like '" & EachItem.Trim & "%' ")
                IsFirtInRoop = False
            Next
            ReturnValue.Append(" ) ")
        End If


        If Not String.IsNullOrEmpty(tbLength.Text) AndAlso tbLength.Text.Trim.Length > 0 Then
            tbLength.Text = tbLength.Text.Replace("'", Nothing)
            If tbLength.Text.Contains("~") Then
                ReturnValue.Append(IIf(tbLength.Text.Trim.Length > 0, " AND A.Length >= " & tbLength.Text.Split("~")(0).Trim & " AND A.Length <= " & tbLength.Text.Split("~")(1).Trim, Nothing))
            Else
                ReturnValue.Append(IIf(tbLength.Text.Trim.Length > 0, " AND A.Length = " & tbLength.Text, Nothing))
            End If
        End If

        If Not String.IsNullOrEmpty(tbWeight.Text) AndAlso tbWeight.Text.Trim.Length > 0 Then
            tbWeight.Text = tbWeight.Text.Replace("'", Nothing)
            If tbWeight.Text.Contains("~") Then
                ReturnValue.Append(IIf(tbWeight.Text.Trim.Length > 0, " AND A.Weight >= " & tbWeight.Text.Split("~")(0).Trim & " AND A.Weight <= " & tbWeight.Text.Split("~")(1).Trim, Nothing))
            Else
                ReturnValue.Append(IIf(tbWeight.Text.Trim.Length > 0, " AND A.Weight = " & tbWeight.Text, Nothing))
            End If
        End If

        If Not String.IsNullOrEmpty(tbGuage.Text) AndAlso tbGuage.Text.Trim.Length > 0 Then
            tbGuage.Text = tbGuage.Text.Replace("'", Nothing)
            If tbGuage.Text.Contains("~") Then
                ReturnValue.Append(IIf(tbGuage.Text.Trim.Length > 0, " AND A.Guage >= " & tbGuage.Text.Split("~")(0).Trim & " AND A.Guage <= " & tbGuage.Text.Split("~")(1).Trim, Nothing))
            Else
                ReturnValue.Append(IIf(tbGuage.Text.Trim.Length > 0, " AND A.Guage = " & tbGuage.Text, Nothing))
            End If
        End If


        If Not String.IsNullOrEmpty(tbWidth.Text) AndAlso tbWidth.Text.Trim.Length > 0 Then
            tbWidth.Text = tbWidth.Text.Replace("'", Nothing)
            If tbWidth.Text.Contains("~") Then
                ReturnValue.Append(IIf(tbWidth.Text.Trim.Length > 0, " AND A.Width >= " & tbWidth.Text.Split("~")(0).Trim & " AND A.Width <= " & tbWidth.Text.Split("~")(1).Trim, Nothing))
            Else
                ReturnValue.Append(IIf(tbWidth.Text.Trim.Length > 0, " AND A.Width = " & tbWidth.Text, Nothing))
            End If
        End If

        '找尋歷史資料
        Dim OrginSQL As String = ReturnValue.ToString
        ReturnValue.Append(" UNION (")
        ReturnValue.Append(OrginSQL.Replace("FROM RunProcessData", "FROM RunProcessDataHistory"))
        ReturnValue.Append(" )")
        ReturnValue.Append(" Order by A.CoilEndTime")

        Me.hfQry.Value = ReturnValue.ToString
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Now.AddDays(-7).ToString("yyyy/MM/dd")
            tbEndDate.Text = Now.ToString("yyyy/MM/dd")
            'By JiaRong 1050624
            'btnSearchToExcelAdvance.Visible = WebAppAuthority.ValidAuthorityModule.IsCanValidAuthoritySystem("COLD01", "COLD0116")
            btnSearchToExcelAdvance.Visible = AppAuthority.ValidAuthorityModule.IsCanValidAuthoritySystem("COLD01", "COLD0116")

        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakerQryStringToControl()
        Me.GridView1.DataBind()
    End Sub

    Protected Sub btnSearchToExcel_Click(sender As Object, e As EventArgs) Handles btnSearchToExcel.Click
        MakerQryStringToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = New PublicClassLibrary.DataConvertExcel(Search(Me.hfQry.Value), "鋼捲產線狀況查詢" & Format(Now, "mmss") & ".xls")
        If Not IsNothing(ExcelConvert) Then
            ExcelConvert.DownloadEXCELFile(Me.Response)
        End If
    End Sub

    Protected Sub btnSearchToExcelAdvance_Click(sender As Object, e As EventArgs) Handles btnSearchToExcelAdvance.Click
        MakerQryStringToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = New PublicClassLibrary.DataConvertExcel(Search1(Me.hfQry.Value), "鋼捲產線狀況進階查詢" & Format(Now, "mmss") & ".xls")
        If Not IsNothing(ExcelConvert) Then
            ExcelConvert.DownloadEXCELFile(Me.Response)
        End If
    End Sub
End Class