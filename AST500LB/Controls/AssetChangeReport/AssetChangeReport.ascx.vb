Public Class AssetChangeReport
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="QryString1"></param>
    ''' <param name="QryString2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryString1 As String, ByVal QryString2 As String) As AST500LBDataSet.AssetChangeReportDataTable
        Dim ReturnValue As AST500LBDataSet.AssetChangeReportDataTable = New AST500LBDataSet.AssetChangeReportDataTable
        If String.IsNullOrEmpty(QryString1) OrElse String.IsNullOrEmpty(QryString2) Then
            Return ReturnValue
        End If
        Dim DBService As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim AddRow As AST500LBDataSet.AssetChangeReportRow
        For Each EachItem As DataRow In DBService.SelectQuery(QryString1).Rows
            AddRow = ReturnValue.NewRow
            With AddRow
                .增減 = "A"
                If Not IsDBNull(EachItem.Item("NUMBER")) Then
                    .財產統一編號 = EachItem.Item("NUMBER")
                End If
                If Not IsDBNull(EachItem.Item("NAME")) Then
                    .名稱 = EachItem.Item("NAME")
                End If
                If Not IsDBNull(EachItem.Item("DEPTSA")) Then
                    .使用單位 = EachItem.Item("DEPTSA")
                End If
                If Not IsDBNull(EachItem.Item("USLAFF")) Then
                    .使用年限 = EachItem.Item("USLAFF")
                End If
                If Not IsDBNull(EachItem.Item("UNIT")) Then
                    .計量單位 = EachItem.Item("UNIT")
                End If
                If Not IsDBNull(EachItem.Item("QUANT")) Then
                    .數量 = EachItem.Item("QUANT")
                End If
                If Not IsDBNull(EachItem.Item("PRICE")) Then
                    .單價 = Format(Val(EachItem.Item("PRICE")), "###,##0.00")
                End If
                If Not IsDBNull(EachItem.Item("TAMOUN")) Then
                    .帳面金額 = Format(Val(EachItem.Item("TAMOUN")), "###,##0.00")
                End If
                If .財產統一編號.Substring(0, 2) = "10" Then  '針對土地做處理
                    .累計折舊金額 = Format(0, "###,##0.00")
                    .殘值 = Format(Val(EachItem.Item("TAMOUN")), "###,##0.00")
                End If
            End With
            ReturnValue.Rows.Add(AddRow)
        Next

        For Each EachItem As DataRow In DBService.SelectQuery(QryString2).Rows
            AddRow = ReturnValue.NewRow
            With AddRow
                .增減 = "C"
                If Not IsDBNull(EachItem.Item("NUMBER")) Then
                    .財產統一編號 = EachItem.Item("NUMBER")
                End If
                If Not IsDBNull(EachItem.Item("CNAME")) Then
                    .名稱 = EachItem.Item("CNAME")
                End If
                If Not IsDBNull(EachItem.Item("DEPTSA")) Then
                    .使用單位 = EachItem.Item("DEPTSA")
                End If
                If Not IsDBNull(EachItem.Item("USLAFF")) Then
                    .使用年限 = EachItem.Item("USLAFF")
                End If
                If Not IsDBNull(EachItem.Item("UNIT")) Then
                    .計量單位 = EachItem.Item("UNIT")
                End If
                If Not IsDBNull(EachItem.Item("QUANT")) Then
                    .數量 = EachItem.Item("QUANT")
                End If
                If Not IsDBNull(EachItem.Item("PRICE")) Then
                    .單價 = Format(EachItem.Item("PRICE"), "###,##0.00")
                End If
                If Not IsDBNull(EachItem.Item("TAMOUN")) Then
                    .帳面金額 = Format(Val(EachItem.Item("TAMOUN")), "###,##0.00")
                End If
                If Not IsDBNull(EachItem.Item("DEPR")) Then
                    .累計折舊金額 = Format(Val(EachItem.Item("DEPR")), "###,##0.00")
                Else
                    .累計折舊金額 = Format(0, "###,##0.00")
                End If
                If Not IsDBNull(EachItem.Item("TAMOUN")) AndAlso Not IsDBNull(EachItem.Item("DEPR")) Then
                    .殘值 = Format(Val(EachItem.Item("TAMOUN")) - Val(EachItem.Item("DEPR")), "###,##0.00")
                Else
                    If Not IsDBNull(EachItem.Item("TAMOUN")) Then
                        .殘值 = Format(Val(EachItem.Item("TAMOUN")), "###,##0.00")
                    End If
                End If
            End With
            ReturnValue.Rows.Add(AddRow)
        Next


        Return ReturnValue
    End Function
#End Region
#Region "計算合計結果至報表參數 函式:SubTotalToReportParameter"
    Private Sub SubTotalToReportParameter(ByVal SourceReport As Microsoft.Reporting.WebForms.Report)
        Dim SearchResult1 As AST500LB.AST500LBDataSet.AssetChangeReportDataTable = Search(hfQry1.Value, hfQry2.Value)
        Dim DBService As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        'Dim QryPreMonth As String = "Select A.* , B.DEPTSA From @#AST500LB.AST101PF.ASTF" & RadioButtonList1.SelectedValue & " A LEFT JOIN @#AST500LB.AST106PF.ASTF" & RadioButtonList1.SelectedValue & " B ON A.NUMBER=B.NUMBER Where B.SEQ=1 Order by A.NUMBER"
        Dim QryPreMonth As String = "Select A.* From @#AST500LB.AST101PF.ASTF" & RadioButtonList1.SelectedValue & " A Order by A.NUMBER"
        Dim PreMonthSearchReslut = DBService.SelectQuery(QryPreMonth)
        'Dim QryThisMonth As String = "Select A.* , B.DEPTSA From @#AST500LB.AST201PF.ASTF" & RadioButtonList1.SelectedValue & " A LEFT JOIN @#AST500LB.AST106PF.ASTF" & RadioButtonList1.SelectedValue & " B ON A.NUMBER=B.NUMBER Where B.SEQ=1 Order by A.NUMBER"
        Dim QryThisMonth As String = "Select A.* From @#AST500LB.AST201PF.ASTF" & RadioButtonList1.SelectedValue & " A  Order by A.NUMBER"
        Dim ThisMonthSearchReslut = DBService.SelectQuery(QryThisMonth)
        Dim TitleArg1 As String = Nothing
        Select Case RadioButtonList1.SelectedValue
            Case "AA"
                TitleArg1 = "總公司" & RadioButtonList1.SelectedValue
            Case "AB"
                TitleArg1 = "總公司-新豐" & RadioButtonList1.SelectedValue
            Case "NA"
                TitleArg1 = "台北辦事處" & RadioButtonList1.SelectedValue
            Case "QA"
                TitleArg1 = "營建部" & RadioButtonList1.SelectedValue
            Case "RA"
                TitleArg1 = "機械廠本部" & RadioButtonList1.SelectedValue
            Case "RC"
                TitleArg1 = "公路車輛事業部" & RadioButtonList1.SelectedValue
            Case "RD"
                TitleArg1 = "鋼構組" & RadioButtonList1.SelectedValue
            Case "SA"
                TitleArg1 = "不銹鋼"
        End Select

        Dim TitleArg2 As String = Nothing
        Dim ThisMonthFirstDay As Date = New Date(Now.Year, Now.Month, 1)
        Select Case True
            Case Now <= ThisMonthFirstDay.AddDays(15)
                TitleArg2 = Now.AddMonths(-1).Year - 1911 & " 年" & ThisMonthFirstDay.AddMonths(-1).Month
            Case Now > ThisMonthFirstDay.AddDays(15)
                TitleArg2 = Now.Year - 1911 & " 年" & ThisMonthFirstDay.Month
        End Select
        Dim ValueTemp As Double
        Dim TotalValue As Double
        Dim ThisMonthTotalValues As New Dictionary(Of String, List(Of Double))  '計算記錄本月結存數值
        ThisMonthTotalValues.Add("1", New List(Of Double))
        ThisMonthTotalValues.Add("11", New List(Of Double))
        ThisMonthTotalValues.Add("2", New List(Of Double))
        ThisMonthTotalValues.Add("3", New List(Of Double))
        ThisMonthTotalValues.Add("4", New List(Of Double))
        ThisMonthTotalValues.Add("5", New List(Of Double))
        '上月結存
        ValueTemp = (From A In PreMonthSearchReslut Where CType(A.Item("NUMBER"), String).Substring(0, 7) < "1110101" Select CType(A.Item("AMOUNT"), Double)).Sum
        TotalValue += ValueTemp : ThisMonthTotalValues("1").Add(ValueTemp)
        Dim SubDatasRow1 As String = Format(ValueTemp, "###,##0.00")
        ValueTemp = (From A In PreMonthSearchReslut Where CType(A.Item("NUMBER"), String).Substring(0, 7) >= "1110101" And CType(A.Item("NUMBER"), String).Substring(0, 1) < "2" Select CType(A.Item("AMOUNT"), Double)).Sum
        TotalValue += ValueTemp : ThisMonthTotalValues("11").Add(ValueTemp)
        Dim SubDatasRow2 As String = Format(ValueTemp, "###,##0.00")
        ValueTemp = (From A In PreMonthSearchReslut Where CType(A.Item("NUMBER"), String).Substring(0, 1) = "2" Select CType(A.Item("AMOUNT"), Double)).Sum
        TotalValue += ValueTemp : ThisMonthTotalValues("2").Add(ValueTemp)
        Dim SubDatasRow3 As String = Format(ValueTemp, "###,##0.00")
        ValueTemp = (From A In PreMonthSearchReslut Where CType(A.Item("NUMBER"), String).Substring(0, 1) = "3" Select CType(A.Item("AMOUNT"), Double)).Sum
        TotalValue += ValueTemp : ThisMonthTotalValues("3").Add(ValueTemp)
        Dim SubDatasRow4 As String = Format(ValueTemp, "###,##0.00")
        ValueTemp = (From A In PreMonthSearchReslut Where CType(A.Item("NUMBER"), String).Substring(0, 1) = "4" Select CType(A.Item("AMOUNT"), Double)).Sum
        TotalValue += ValueTemp : ThisMonthTotalValues("4").Add(ValueTemp)
        Dim SubDatasRow5 As String = Format(ValueTemp, "###,##0.00")
        ValueTemp = (From A In PreMonthSearchReslut Where CType(A.Item("NUMBER"), String).Substring(0, 1) = "5" Select CType(A.Item("AMOUNT"), Double)).Sum
        TotalValue += ValueTemp : ThisMonthTotalValues("5").Add(ValueTemp)
        Dim SubDatasRow6 As String = Format(ValueTemp, "###,##0.00")
        Dim SubDatasRow7 As String = Format(TotalValue, "###,##0.00")
        '本月增加
        TotalValue = 0
        ValueTemp = (From A In SearchResult1 Where A.增減 = "A" And A.財產統一編號.Substring(0, 7) < "1110101" Select CType(A.帳面金額, Double)).Sum
        TotalValue += ValueTemp : ThisMonthTotalValues("1").Add(ValueTemp)
        SubDatasRow1 &= "@" & Format(ValueTemp, "###,##0.00")
        ValueTemp = (From A In SearchResult1 Where A.增減 = "A" And A.財產統一編號.Substring(0, 7) >= "1110101" And A.財產統一編號.Substring(0, 1) < "2" Select CType(A.帳面金額, Double)).Sum
        TotalValue += ValueTemp : ThisMonthTotalValues("11").Add(ValueTemp)
        SubDatasRow2 &= "@" & Format(ValueTemp, "###,##0.00")
        ValueTemp = (From A In SearchResult1 Where A.增減 = "A" And A.財產統一編號.Substring(0, 1) = "2" Select CType(A.帳面金額, Double)).Sum
        TotalValue += ValueTemp : ThisMonthTotalValues("2").Add(ValueTemp)
        SubDatasRow3 &= "@" & Format(ValueTemp, "###,##0.00")
        ValueTemp = (From A In SearchResult1 Where A.增減 = "A" And A.財產統一編號.Substring(0, 1) = "3" Select CType(A.帳面金額, Double)).Sum
        TotalValue += ValueTemp : ThisMonthTotalValues("3").Add(ValueTemp)
        SubDatasRow4 &= "@" & Format(ValueTemp, "###,##0.00")
        ValueTemp = (From A In SearchResult1 Where A.增減 = "A" And A.財產統一編號.Substring(0, 1) = "4" Select CType(A.帳面金額, Double)).Sum
        TotalValue += ValueTemp : ThisMonthTotalValues("4").Add(ValueTemp)
        SubDatasRow5 &= "@" & Format(ValueTemp, "###,##0.00")
        ValueTemp = (From A In SearchResult1 Where A.增減 = "A" And A.財產統一編號.Substring(0, 1) = "5" Select CType(A.帳面金額, Double)).Sum
        TotalValue += ValueTemp : ThisMonthTotalValues("5").Add(ValueTemp)
        SubDatasRow6 &= "@" & Format(ValueTemp, "###,##0.00")
        SubDatasRow7 &= "@" & Format(TotalValue, "###,##0.00")
        '本月減少
        TotalValue = 0
        ValueTemp = (From A In SearchResult1 Where A.增減 = "C" And A.財產統一編號.Substring(0, 7) < "1110101" Select CType(A.帳面金額, Double)).Sum
        TotalValue += ValueTemp : ThisMonthTotalValues("1").Add(ValueTemp)
        SubDatasRow1 &= "@" & Format(ValueTemp, "###,##0.00")
        ValueTemp = (From A In SearchResult1 Where A.增減 = "C" And A.財產統一編號.Substring(0, 7) >= "1110101" And A.財產統一編號.Substring(0, 1) < "2" Select CType(A.帳面金額, Double)).Sum
        TotalValue += ValueTemp : ThisMonthTotalValues("11").Add(ValueTemp)
        SubDatasRow2 &= "@" & Format(ValueTemp, "###,##0.00")
        ValueTemp = (From A In SearchResult1 Where A.增減 = "C" And A.財產統一編號.Substring(0, 1) = "2" Select CType(A.帳面金額, Double)).Sum
        TotalValue += ValueTemp : ThisMonthTotalValues("2").Add(ValueTemp)
        SubDatasRow3 &= "@" & Format(ValueTemp, "###,##0.00")
        ValueTemp = (From A In SearchResult1 Where A.增減 = "C" And A.財產統一編號.Substring(0, 1) = "3" Select CType(A.帳面金額, Double)).Sum
        TotalValue += ValueTemp : ThisMonthTotalValues("3").Add(ValueTemp)
        SubDatasRow4 &= "@" & Format(ValueTemp, "###,##0.00")
        ValueTemp = (From A In SearchResult1 Where A.增減 = "C" And A.財產統一編號.Substring(0, 1) = "4" Select CType(A.帳面金額, Double)).Sum
        TotalValue += ValueTemp : ThisMonthTotalValues("4").Add(ValueTemp)
        SubDatasRow5 &= "@" & Format(ValueTemp, "###,##0.00")
        ValueTemp = (From A In SearchResult1 Where A.增減 = "C" And A.財產統一編號.Substring(0, 1) = "5" Select CType(A.帳面金額, Double)).Sum
        TotalValue += ValueTemp : ThisMonthTotalValues("5").Add(ValueTemp)
        SubDatasRow6 &= "@" & Format(ValueTemp, "###,##0.00")
        SubDatasRow7 &= "@" & Format(TotalValue, "###,##0.00")
        '本月結存
        TotalValue = 0
        ValueTemp = ThisMonthTotalValues("1").Item(0) + ThisMonthTotalValues("1").Item(1) - ThisMonthTotalValues("1").Item(2)
        TotalValue += ValueTemp
        SubDatasRow1 &= "@" & Format(ValueTemp, "###,##0.00")
        ValueTemp = ThisMonthTotalValues("11").Item(0) + ThisMonthTotalValues("11").Item(1) - ThisMonthTotalValues("11").Item(2)
        TotalValue += ValueTemp
        SubDatasRow2 &= "@" & Format(ValueTemp, "###,##0.00")
        ValueTemp = ThisMonthTotalValues("2").Item(0) + ThisMonthTotalValues("2").Item(1) - ThisMonthTotalValues("2").Item(2)
        TotalValue += ValueTemp
        SubDatasRow3 &= "@" & Format(ValueTemp, "###,##0.00")
        ValueTemp = ThisMonthTotalValues("3").Item(0) + ThisMonthTotalValues("3").Item(1) - ThisMonthTotalValues("3").Item(2)
        TotalValue += ValueTemp
        SubDatasRow4 &= "@" & Format(ValueTemp, "###,##0.00")
        ValueTemp = ThisMonthTotalValues("4").Item(0) + ThisMonthTotalValues("4").Item(1) - ThisMonthTotalValues("4").Item(2)
        TotalValue += ValueTemp
        SubDatasRow5 &= "@" & Format(ValueTemp, "###,##0.00")
        ValueTemp = ThisMonthTotalValues("5").Item(0) + ThisMonthTotalValues("5").Item(1) - ThisMonthTotalValues("5").Item(2)
        TotalValue += ValueTemp
        SubDatasRow6 &= "@" & Format(ValueTemp, "###,##0.00")
        SubDatasRow7 &= "@" & Format(TotalValue, "###,##0.00")

        Dim Parameters(8) As Microsoft.Reporting.WebForms.ReportParameter
        Parameters(0) = New Microsoft.Reporting.WebForms.ReportParameter("TitleArg1", TitleArg1)
        Parameters(1) = New Microsoft.Reporting.WebForms.ReportParameter("TitleArg2", TitleArg2)
        Parameters(2) = New Microsoft.Reporting.WebForms.ReportParameter("SubDatasRow1", SubDatasRow1)
        Parameters(3) = New Microsoft.Reporting.WebForms.ReportParameter("SubDatasRow2", SubDatasRow2)
        Parameters(4) = New Microsoft.Reporting.WebForms.ReportParameter("SubDatasRow3", SubDatasRow3)
        Parameters(5) = New Microsoft.Reporting.WebForms.ReportParameter("SubDatasRow4", SubDatasRow4)
        Parameters(6) = New Microsoft.Reporting.WebForms.ReportParameter("SubDatasRow5", SubDatasRow5)
        Parameters(7) = New Microsoft.Reporting.WebForms.ReportParameter("SubDatasRow6", SubDatasRow6)
        Parameters(8) = New Microsoft.Reporting.WebForms.ReportParameter("SubDatasRow7", SubDatasRow7)
        SourceReport.SetParameters(Parameters)
    End Sub
#End Region
#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim SQLString1 As String = Nothing
        Dim SQLString2 As String = Nothing
        SQLString1 = "Select A.* , B.DEPTSA From @#AST500LB.AST001PF.ASTF" & RadioButtonList1.SelectedValue & " A LEFT JOIN @#AST500LB.AST106PF.ASTF" & RadioButtonList1.SelectedValue & " B ON A.NUMBER=B.NUMBER Where B.SEQ=1 Order by A.NUMBER"
        SQLString2 = "Select A.* , B.DEPTSA From @#AST500LB.AST003PF.ASTF" & RadioButtonList1.SelectedValue & " A LEFT JOIN @#AST500LB.AST106PF.ASTF" & RadioButtonList1.SelectedValue & " B ON A.NUMBER=B.NUMBER Where B.SEQ=1 Order by A.NUMBER"
        Me.hfQry1.Value = SQLString1
        Me.hfQry2.Value = SQLString2
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakQryStringToControl()
        SubTotalToReportParameter(ReportViewer1.LocalReport)
        ReportViewer1.LocalReport.Refresh()

    End Sub

End Class