Public Class OrderMonthBuyAnalysis
    Inherits System.Web.UI.UserControl
    'OrderRealBuyAnalysisDataTable

#Region "資料查詢 方法:Search"
    'Public Shared Function Search(ByVal SQLQry As String) As List(Of SLS300LB.OrderMonthBuyAnalysisDataTableRow)

    'End Function
    ''' <summary>
    ''' 資料查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function Search(ByVal SQLQry As String, ByVal SQLQry1 As String) As SLS300LB.OrderMonthBuyAnalysisDataTableDataTable
        If String.IsNullOrEmpty(SQLQry) Then
            Return New SLS300LB.OrderMonthBuyAnalysisDataTableDataTable
        End If

        Dim ReturnValue As New SLS300LB.OrderMonthBuyAnalysisDataTableDataTable
        Dim GetDatas As List(Of CompanyORMDB.SLS300LB.SL2BOLPF) = CompanyORMDB.SLS300LB.SL2BOLPF.CDBSelect(Of CompanyORMDB.SLS300LB.SL2BOLPF)(SQLQry, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim AboutPPSCIAPFs As List(Of CompanyORMDB.PPS100LB.PPSCIAPF) = CompanyORMDB.PPS100LB.PPSCIAPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSCIAPF)(SQLQry1, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim AddItem As SLS300LB.OrderMonthBuyAnalysisDataTableRow
        For Each EachItem As String In (From A In GetDatas Order By A.BOL03 Select A.BOL03.Substring(0, 3) & A.BOL05).Distinct
            Dim CustomerID As String = EachItem.Substring(0, 3)
            Dim SteelKind As String = EachItem.Substring(3)
            Dim EachItemDatas As List(Of CompanyORMDB.SLS300LB.SL2BOLPF) = (From A In GetDatas Where A.BOL03.Substring(0, 3) & A.BOL05 = CustomerID & SteelKind Select A).ToList
            'Dim AA As List(Of String) = (From A In AboutPPSCIAPFs Where (From B In EachItemDatas Select B.BOL02 & B.BOL16 & B.BOL17).Contains(A.CIA62 & A.CIA02 & A.CIA03) And A.CIA59.Trim.Length > 0 Select A.CIA59).Distinct.ToList
            For Each EachThick As String In (From A In AboutPPSCIAPFs Where (From B In EachItemDatas Select B.BOL02 & B.BOL16 & B.BOL17).Contains(A.CIA62 & A.CIA02 & A.CIA03) And A.CIA59.Trim.Length > 0 Select A.CIA59).Distinct.ToList

                Dim EachThickTemp As String = EachThick
                Dim EachItemSubDatas = (From A In EachItemDatas Where (From B In AboutPPSCIAPFs Where B.CIA59 = EachThickTemp Select B.CIA62 & B.CIA02 & B.CIA03).Contains(A.BOL02 & A.BOL16 & A.BOL17) Select A).ToList
                Dim FindCustomer As CompanyORMDB.SLS300LB.SL2CUAPF = (From A In CompanyORMDB.SLS300LB.SL2CUAPF.ALLSL2CUAPFs Where A.CUA01.Trim = CustomerID).FirstOrDefault
                Dim HROrCrSubDatas As List(Of CompanyORMDB.SLS300LB.SL2BOLPF)
                Dim SubPPSCIAPFs As New List(Of CompanyORMDB.PPS100LB.PPSCIAPF)
                For HROrCr As Integer = 0 To 1
                    If HROrCr = 0 Then
                        HROrCrSubDatas = (From A In EachItemSubDatas Where A.BOL06 = "NO1" Select A).ToList
                        SubPPSCIAPFs = (From A In AboutPPSCIAPFs Where A.CIA06 = "NO1" And A.CIA05 = SteelKind And (From B In EachItemSubDatas Select B.BOL02 & B.BOL16 & B.BOL17).Contains(A.CIA62 & A.CIA02 & A.CIA03) Select A).ToList
                    Else
                        HROrCrSubDatas = (From A In EachItemSubDatas Where A.BOL06 <> "NO1" Select A).ToList
                        SubPPSCIAPFs = (From A In AboutPPSCIAPFs Where A.CIA06 <> "NO1" And A.CIA05 = SteelKind And (From B In EachItemSubDatas Select B.BOL02 & B.BOL16 & B.BOL17).Contains(A.CIA62 & A.CIA02 & A.CIA03) Select A).ToList
                    End If
                    If HROrCrSubDatas.Count = 0 Then
                        Continue For
                    End If
                    AddItem = ReturnValue.NewOrderMonthBuyAnalysisDataTableRow
                    Try
                        'If CustomerID.Trim = "D04" And SteelKind.Trim = "304" And EachThick.Trim = "150" Then
                        '    Stop
                        'End If
                        With AddItem
                            .公司代碼 = CustomerID
                            If Not IsNothing(FindCustomer) AndAlso Not String.IsNullOrEmpty(FindCustomer.CUA11) Then
                                .公司名稱 = FindCustomer.CUA11.Trim
                            End If

                            'If IsNothing(FindCustomer) OrElse String.IsNullOrEmpty(FindCustomer.CUA11) Then
                            '    .公司名稱 = CustomerID
                            'Else
                            '    .公司名稱 = IIf(FindCustomer.CUA11.Trim.Length = 0, CustomerID, CustomerID & ":" & FindCustomer.CUA11.Trim)
                            'End If
                            .鋼種 = SteelKind
                            .表面 = IIf(HROrCr = 0, "HR", "CR")
                            .厚度 = EachThickTemp.Trim.PadLeft(1).Substring(0, 1) & "." & EachThickTemp.Trim.PadLeft(3).Substring(1, 2)
                            '.Level1發貨量 = (From A In EachItemSubDatas Where A.BOL18 = 1 Select A.BOL14).Sum
                            '.Level1金額 = (From A In EachItemSubDatas Where A.BOL18 = 1 Select A.BOL27).Sum
                            '.Level2發貨量 = (From A In EachItemSubDatas Where A.BOL18 = 2 Select A.BOL14).Sum
                            '.Level2金額 = (From A In EachItemSubDatas Where A.BOL18 = 2 Select A.BOL27).Sum
                            '.Level3發貨量 = (From A In EachItemSubDatas Where A.BOL18 = 3 Select A.BOL14).Sum
                            '.Level3金額 = (From A In EachItemSubDatas Where A.BOL18 = 3 Select A.BOL27).Sum
                            '.總發貨量 = (From A In EachItemSubDatas Select A.BOL14).Sum
                            '.總金額 = (From A In EachItemSubDatas Select A.BOL27).Sum
                            .Level1發貨量 = (From A In HROrCrSubDatas Where A.BOL18 = 1 Select A.BOL14).Sum
                            .Level1金額 = (From A In HROrCrSubDatas Where A.BOL18 = 1 Select A.BOL27).Sum
                            .Level2發貨量 = (From A In HROrCrSubDatas Where A.BOL18 = 2 Select A.BOL14).Sum
                            .Level2金額 = (From A In HROrCrSubDatas Where A.BOL18 = 2 Select A.BOL27).Sum
                            .Level3發貨量 = (From A In HROrCrSubDatas Where A.BOL18 = 3 Select A.BOL14).Sum
                            .Level3金額 = (From A In HROrCrSubDatas Where A.BOL18 = 3 Select A.BOL27).Sum
                            .總發貨量 = (From A In HROrCrSubDatas Select A.BOL14).Sum
                            .總金額 = (From A In HROrCrSubDatas Select A.BOL27).Sum
                        End With
                        ReturnValue.Rows.Add(AddItem)
                    Catch ex As Exception
                        AddItem.公司名稱 &= "發生資料錯誤:"
                        ReturnValue.Rows.Add(AddItem)
                        Return ReturnValue
                    End Try
                Next
            Next
        Next
        '表面小計與合計
        Dim SmallCountAddDatas As New List(Of SLS300LB.OrderMonthBuyAnalysisDataTableRow)
        SmallCountAddDatas.Add(GetSmallCountDataRow(ReturnValue, "HR"))
        SmallCountAddDatas.Add(GetSmallCountDataRow(ReturnValue, "CR"))
        SmallCountAddDatas.Add(GetSmallCountDataRow(ReturnValue))
        For Each EachItem In SmallCountAddDatas
            If CType(EachItem.總金額, Double) > 0 Then
                ReturnValue.Rows.Add(EachItem)
            End If
        Next

        Return ReturnValue
    End Function

    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function Search1(ByVal SQLQry As String, ByVal SQLQry1 As String) As SLS300LB.OrderMonthBuyAnalysisDataTableDataTable
        If String.IsNullOrEmpty(SQLQry) Then
            Return New SLS300LB.OrderMonthBuyAnalysisDataTableDataTable
        End If

        Dim ReturnValue As New SLS300LB.OrderMonthBuyAnalysisDataTableDataTable
        Dim GetDatas As List(Of CompanyORMDB.SLS300LB.SL2BOLPF) = CompanyORMDB.SLS300LB.SL2BOLPF.CDBSelect(Of CompanyORMDB.SLS300LB.SL2BOLPF)(SQLQry, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim AboutPPSCIAPFs As List(Of CompanyORMDB.PPS100LB.PPSCIAPF) = CompanyORMDB.PPS100LB.PPSCIAPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSCIAPF)(SQLQry1, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim AddItem As SLS300LB.OrderMonthBuyAnalysisDataTableRow
        For Each EachItem As String In (From A In GetDatas Order By A.BOL03 Select A.BOL03.Substring(0, 3) & A.BOL05).Distinct
            Dim CustomerID As String = EachItem.Substring(0, 3)
            Dim SteelKind As String = EachItem.Substring(3)
            Dim EachItemDatas As List(Of CompanyORMDB.SLS300LB.SL2BOLPF) = (From A In GetDatas Where A.BOL03.Substring(0, 3) & A.BOL05 = CustomerID & SteelKind Select A).ToList

            'For Each EachThick As String In (From A In AboutPPSCIAPFs Where (From B In EachItemDatas Select B.BOL02 & B.BOL16 & B.BOL17).Contains(A.CIA62 & A.CIA02 & A.CIA03) And A.CIA59.Trim.Length > 0 Select A.CIA59).Distinct.ToList

            'Dim EachThickTemp As String = EachThick
            Dim EachItemSubDatas = (From A In EachItemDatas Where (From B In AboutPPSCIAPFs Where B.CIA59.Trim.Length > 0 Select B.CIA62 & B.CIA02 & B.CIA03).Contains(A.BOL02 & A.BOL16 & A.BOL17) Select A).ToList
            Dim FindCustomer As CompanyORMDB.SLS300LB.SL2CUAPF = (From A In CompanyORMDB.SLS300LB.SL2CUAPF.ALLSL2CUAPFs Where A.CUA01.Trim = CustomerID).FirstOrDefault
            Dim HROrCrSubDatas As List(Of CompanyORMDB.SLS300LB.SL2BOLPF)
            Dim SubPPSCIAPFs As New List(Of CompanyORMDB.PPS100LB.PPSCIAPF)
            For HROrCr As Integer = 0 To 1
                If HROrCr = 0 Then
                    HROrCrSubDatas = (From A In EachItemSubDatas Where A.BOL06 = "NO1" Select A).ToList
                    SubPPSCIAPFs = (From A In AboutPPSCIAPFs Where A.CIA06 = "NO1" And A.CIA05 = SteelKind And (From B In EachItemSubDatas Select B.BOL02 & B.BOL16 & B.BOL17).Contains(A.CIA62 & A.CIA02 & A.CIA03) Select A).ToList
                Else
                    HROrCrSubDatas = (From A In EachItemSubDatas Where A.BOL06 <> "NO1" Select A).ToList
                    SubPPSCIAPFs = (From A In AboutPPSCIAPFs Where A.CIA06 <> "NO1" And A.CIA05 = SteelKind And (From B In EachItemSubDatas Select B.BOL02 & B.BOL16 & B.BOL17).Contains(A.CIA62 & A.CIA02 & A.CIA03) Select A).ToList
                End If
                If HROrCrSubDatas.Count = 0 Then
                    Continue For
                End If
                AddItem = ReturnValue.NewOrderMonthBuyAnalysisDataTableRow
                Try

                    With AddItem
                        .公司代碼 = CustomerID
                        If Not IsNothing(FindCustomer) AndAlso Not String.IsNullOrEmpty(FindCustomer.CUA11) Then
                            .公司名稱 = FindCustomer.CUA11.Trim
                        End If
                        .鋼種 = SteelKind
                        .表面 = IIf(HROrCr = 0, "HR", "CR")
                        .厚度 = "--"
                        '.Level1發貨量 = (From A In EachItemSubDatas Where A.BOL18 = 1 Select A.BOL14).Sum
                        '.Level1金額 = (From A In EachItemSubDatas Where A.BOL18 = 1 Select A.BOL27).Sum
                        '.Level2發貨量 = (From A In EachItemSubDatas Where A.BOL18 = 2 Select A.BOL14).Sum
                        '.Level2金額 = (From A In EachItemSubDatas Where A.BOL18 = 2 Select A.BOL27).Sum
                        '.Level3發貨量 = (From A In EachItemSubDatas Where A.BOL18 = 3 Select A.BOL14).Sum
                        '.Level3金額 = (From A In EachItemSubDatas Where A.BOL18 = 3 Select A.BOL27).Sum
                        '.總發貨量 = (From A In EachItemSubDatas Select A.BOL14).Sum
                        '.總金額 = (From A In EachItemSubDatas Select A.BOL27).Sum
                        .Level1發貨量 = (From A In HROrCrSubDatas Where A.BOL18 = 1 Select A.BOL14).Sum
                        .Level1金額 = (From A In HROrCrSubDatas Where A.BOL18 = 1 Select A.BOL27).Sum
                        .Level2發貨量 = (From A In HROrCrSubDatas Where A.BOL18 = 2 Select A.BOL14).Sum
                        .Level2金額 = (From A In HROrCrSubDatas Where A.BOL18 = 2 Select A.BOL27).Sum
                        .Level3發貨量 = (From A In HROrCrSubDatas Where A.BOL18 = 3 Select A.BOL14).Sum
                        .Level3金額 = (From A In HROrCrSubDatas Where A.BOL18 = 3 Select A.BOL27).Sum
                        .總發貨量 = (From A In HROrCrSubDatas Select A.BOL14).Sum
                        .總金額 = (From A In HROrCrSubDatas Select A.BOL27).Sum
                    End With
                    ReturnValue.Rows.Add(AddItem)
                Catch ex As Exception
                    AddItem.公司名稱 &= "發生資料錯誤:"
                    ReturnValue.Rows.Add(AddItem)
                    Return ReturnValue
                End Try
            Next
            'Next
        Next
        '表面小計與合計
        Dim SmallCountAddDatas As New List(Of SLS300LB.OrderMonthBuyAnalysisDataTableRow)
        SmallCountAddDatas.Add(GetSmallCountDataRow(ReturnValue, "HR"))
        SmallCountAddDatas.Add(GetSmallCountDataRow(ReturnValue, "CR"))
        SmallCountAddDatas.Add(GetSmallCountDataRow(ReturnValue))
        For Each EachItem In SmallCountAddDatas
            If CType(EachItem.總金額, Double) > 0 Then
                ReturnValue.Rows.Add(EachItem)
            End If
        Next

        Return ReturnValue
    End Function

    Private Shared Function GetSmallCountDataRow(ByVal SourceDataTable As SLS300LB.OrderMonthBuyAnalysisDataTableDataTable, Optional ByVal CROrHRFaceString As String = Nothing) As SLS300LB.OrderMonthBuyAnalysisDataTableRow
        Dim ReturnValue As SLS300LB.OrderMonthBuyAnalysisDataTableRow
        If String.IsNullOrEmpty(CROrHRFaceString) Then
            ReturnValue = SourceDataTable.NewOrderMonthBuyAnalysisDataTableRow
            With ReturnValue
                .公司名稱 = "合計:"
                .Level1發貨量 = (From A In SourceDataTable Select CType(A.Level1發貨量, Double)).Sum
                .Level1金額 = (From A In SourceDataTable Select CType(A.Level1金額, Double)).Sum
                .Level2發貨量 = (From A In SourceDataTable Select CType(A.Level2發貨量, Double)).Sum
                .Level2金額 = (From A In SourceDataTable Select CType(A.Level2金額, Double)).Sum
                .Level3發貨量 = (From A In SourceDataTable Select CType(A.Level3發貨量, Double)).Sum
                .Level3金額 = (From A In SourceDataTable Select CType(A.Level3金額, Double)).Sum
                .總發貨量 = (From A In SourceDataTable Select CType(A.總發貨量, Double)).Sum
                .總金額 = (From A In SourceDataTable Select CType(A.總金額, Double)).Sum
            End With
        Else
            ReturnValue = SourceDataTable.NewOrderMonthBuyAnalysisDataTableRow
            With ReturnValue
                .公司名稱 = CROrHRFaceString.Trim & "小計:"
                .Level1發貨量 = (From A In SourceDataTable Where A.表面 = CROrHRFaceString Select CType(A.Level1發貨量, Double)).Sum
                .Level1金額 = (From A In SourceDataTable Where A.表面 = CROrHRFaceString Select CType(A.Level1金額, Double)).Sum
                .Level2發貨量 = (From A In SourceDataTable Where A.表面 = CROrHRFaceString Select CType(A.Level2發貨量, Double)).Sum
                .Level2金額 = (From A In SourceDataTable Where A.表面 = CROrHRFaceString Select CType(A.Level2金額, Double)).Sum
                .Level3發貨量 = (From A In SourceDataTable Where A.表面 = CROrHRFaceString Select CType(A.Level3發貨量, Double)).Sum
                .Level3金額 = (From A In SourceDataTable Where A.表面 = CROrHRFaceString Select CType(A.Level3金額, Double)).Sum
                .總發貨量 = (From A In SourceDataTable Where A.表面 = CROrHRFaceString Select CType(A.總發貨量, Double)).Sum
                .總金額 = (From A In SourceDataTable Where A.表面 = CROrHRFaceString Select CType(A.總金額, Double)).Sum
            End With
        End If
        Return ReturnValue
    End Function
#End Region

#Region "產生查詢至控製項 函式:MakeQryToControl"
    Private Sub MakeQryToControl()
        'select bol92,substr(bol03,4,5) as QTNYM,cus,cia05,cia06,cia59,cia16,decimal(sum(bol14),8,3) as QTY ,decimal(sum(bol27),9,0) as AMT  from @#sls300lb.sl2boll8 , @#pps100lb.ppscialu  where ym='09907' and bol05='202 ' and substr(bol16,1,1)<>'B' and cia62=bol02 and cia02=bol16 and cia03=bol17 group by bol92,substr(bol03,4,5),cus,cia05,cia06,cia59,cia16 order by 1,2,3,4,5,6,7
        Dim SQLString As String = "Select * from @#SLS300LB.SL2BOLPF WHERE BOL16 <> 'B' "  '排除非正常品

        Dim StartTwDate1 As String = Format(CType(tbStartYear1.Text, Integer) * 100 + CType(tbStartMonth1.Text, Integer), "00000")
        SQLString &= " AND substr(BOL01,1,5) ='" & StartTwDate1 & "' "

        If Not String.IsNullOrEmpty(tbSteelKinds.Text) AndAlso tbSteelKinds.Text.Trim.Length > 0 Then
            SQLString &= " AND BOL05 IN ('" & tbSteelKinds.Text.Trim.Replace(",", "','") & "') "
        End If

        If RadioButtonList1.SelectedValue <> "ALL" Then
            SQLString &= " AND BOL06 " & IIf(RadioButtonList1.SelectedValue = "HR", "='NO1'", "<>'NO1'")
        End If

        If RadioButtonList2.SelectedValue <> "ALL" Then
            SQLString &= " AND BOL92 " & IIf(RadioButtonList2.SelectedValue = "內銷", "=' '", "<>' '")
        End If

        If CheckBox1.Checked Then
            Dim StartTwDate2 As String = Format(CType(tbStartYear2.Text, Integer) * 100 + CType(tbStartMonth2.Text, Integer), "00000")
            Dim EndTwDate2 As String = Format(CType(tbEndYear2.Text, Integer) * 100 + CType(tbEndMonth2.Text, Integer), "00000")
            SQLString &= " AND substr(BOL03,4,5) >='" & StartTwDate2 & "' AND substr(BOL03,4,5) <='" & EndTwDate2 & "' "
        End If

        hfQry.Value = SQLString
        hfQry1.Value = "Select * from @#PPS100LB.PPSCIAPF Where CIA62 IN (" & SQLString.Replace("*", "BOL02") & ")"
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.tbStartYear1.Text = Format(Now, "yyyy") - 1911
            Me.tbStartMonth1.Text = Format(Now, "MM")
            Me.tbStartYear2.Text = Me.tbStartYear1.Text
            Me.tbStartMonth2.Text = Me.tbStartMonth1.Text
            Me.tbEndYear2.Text = Me.tbStartYear1.Text
            Me.tbEndMonth2.Text = Me.tbStartMonth1.Text
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        MakeQryToControl()
        Dim Parameters(0) As Microsoft.Reporting.WebForms.ReportParameter
        Dim SetPar1String As String = tbStartYear1.Text & "年" & tbStartMonth1.Text & "月發貨"
        SetPar1String &= IIf(CheckBox1.Checked, "/" & tbStartYear2.Text & "年" & tbStartMonth2.Text & "月~" & tbEndYear2.Text & "年" & tbEndMonth2.Text & "月訂單", Nothing)
        Parameters(0) = New Microsoft.Reporting.WebForms.ReportParameter("TitleParameter1", "(" & SetPar1String & ")")
        Select Case RadioButtonList3.SelectedValue
            Case 1
                Me.MultiView1.SetActiveView(View1)
                ReportViewer1.Visible = True
                ReportViewer1.LocalReport.SetParameters(Parameters)
                ReportViewer1.LocalReport.Refresh()
            Case 2
                Me.MultiView1.SetActiveView(View2)
                ReportViewer2.Visible = True
                ReportViewer2.LocalReport.SetParameters(Parameters)
                ReportViewer2.LocalReport.Refresh()
        End Select

    End Sub
End Class