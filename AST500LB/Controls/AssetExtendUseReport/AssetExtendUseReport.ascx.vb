Public Class AssetExtendUseReport
    Inherits System.Web.UI.UserControl


#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="QryString1"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryString1 As String, ByVal ShowReportType As String, ByVal ManagerDept As String) As AST500LBDataSet.AssetExtendUseReportDataTable
        Dim ReturnValue As AST500LBDataSet.AssetExtendUseReportDataTable = New AST500LBDataSet.AssetExtendUseReportDataTable
        If String.IsNullOrEmpty(QryString1) Then
            Return ReturnValue
        End If
        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim AllDEPCODPFs As List(Of CompanyORMDB.GPL2.DEPCODPF) = Nothing
        'If ShowReportType <> "1" Then
        '    AllDEPCODPFs = CompanyORMDB.GPL2.DEPCODPF.CDBSelect(Of CompanyORMDB.GPL2.DEPCODPF)("Select * from @#GPL2.DEPCODPF", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        'End If
        AllDEPCODPFs = CompanyORMDB.GPL2.DEPCODPF.CDBSelect(Of CompanyORMDB.GPL2.DEPCODPF)("Select * from @#GPL2.DEPCODPF", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)


        Dim FindMainEquitment As DataRow = Nothing
        For Each EachItem As DataRow In Adapter.SelectQuery(QryString1).Rows
            FindMainEquitment = Nothing
            If Not IsDBNull(EachItem.Item("MASTER")) AndAlso CType(EachItem.Item("MASTER"), String).Trim.Length > 0 Then
                Dim QryString As String = "Select A.*, B.DEPTSA From @#ast500lb.ast101pf.ASTFSA A LEFT JOIN @#AST500LB.AST106PF.ASTFSA B ON A.NUMBER=B.NUMBER AND B.SEQ=1 where A.NUMBER='" & CType(EachItem.Item("MASTER"), String).Trim & "'"
                Dim SearchResult As DataTable = Adapter.SelectQuery(QryString)
                If SearchResult.Rows.Count > 0 Then
                    FindMainEquitment = SearchResult.Rows(0)
                End If
            End If
            Dim AddRow As AST500LBDataSet.AssetExtendUseReportRow = ReturnValue.NewRow
            With AddRow
                If Not IsDBNull(EachItem.Item("DEPTSA")) Then
                    .單位 = CType(EachItem.Item("DEPTSA"), String).Trim
                End If
                .財產統一編號 = CType(EachItem.Item("NUMBER"), String).Trim
                .名稱 = CType(EachItem.Item("NAME"), String).Trim
                .購置日期 = CType(EachItem.Item("DATE"), String).Trim
                .使用年限 = CType(EachItem.Item("USLAFF"), String).Trim
                .原帳面價值 = Format(CType(EachItem.Item("AMOUNT"), Double), "0,0.00")
                .殘值 = Format(CType(EachItem.Item("AMOUNT"), Double) - CType(EachItem.Item("DEPR"), Double), "0,0.00")
                .殘值重估年限 = CType(EachItem.Item("N7611"), String).Trim
                .數量 = CType(EachItem.Item("QUANT"), String).Trim

                Dim FindDep As CompanyORMDB.GPL2.DEPCODPF = (From A In AllDEPCODPFs Where A.DEPCOD.Trim.PadRight(2) = CType(EachItem.Item("DEPTSA"), String).Trim.PadRight(2).Substring(0, 2) Or A.DEPCOD.Trim.PadRight(3) = CType(EachItem.Item("DEPTSA"), String).Trim.PadRight(3).Substring(0, 3) Select A).FirstOrDefault
                If Not IsNothing(FindDep) Then
                    .歸屬單位 = FindDep.DEPNAM
                    .單位 = .歸屬單位.Trim & "/" & .單位
                End If

                'If ShowReportType <> "1" AndAlso Not IsNothing(AllDEPCODPFs) Then
                'Else
                '    .歸屬單位 = ManagerDept
                'End If

                'If ShowReportType = 1 Then
                '    '總表
                '    .歸屬單位 = ""
                'Else
                '    '明細表
                '    Dim FindDep As CompanyORMDB.GPL2.DEPCODPF = (From A In AllDEPCODPFs Where A.DEPCOD.Trim.PadRight(2) = CType(EachItem.Item("DEPTSA"), String).Trim.PadRight(2).Substring(0, 2) Select A).FirstOrDefault
                '    If Not IsNothing(FindDep) Then
                '        .歸屬單位 = "管理單位:" & FindDep.DEPNAM
                '    End If
                'End If
                '.歸屬單位 = "管理單位:行政處"



                If Not IsNothing(FindMainEquitment) Then
                    .財產統一編號 &= vbNewLine & CType(FindMainEquitment.Item("NUMBER"), String).Trim
                    .名稱 &= vbNewLine & CType(FindMainEquitment.Item("NAME"), String).Trim
                    .購置日期 &= vbNewLine & CType(FindMainEquitment.Item("DATE"), String).Trim
                    .使用年限 &= vbNewLine & CType(FindMainEquitment.Item("USLAFF"), String).Trim
                    .殘值重估年限 &= vbNewLine & CType(FindMainEquitment.Item("N7611"), String).Trim
                    .備註 = "" & vbNewLine & "<===注意:上述備品隸屬之主設備"
                End If
            End With
            ReturnValue.Rows.Add(AddRow)
        Next
        Return ReturnValue
    End Function

#End Region
#Region "計算合計結果至報表參數 函式:SubTotalToReportParameter"
    ''' <summary>
    ''' 計算合計結果至報表參數
    ''' </summary>
    ''' <param name="SourceReport"></param>
    ''' <remarks></remarks>
    Private Sub SubTotalToReportParameter(ByVal SourceReport As Microsoft.Reporting.WebForms.Report)
        '"       時間:" +Now() + "     唐榮公司   固定資產    殘值使用年限重估表    (自" + Year(Now()) +" 年" + Month(Now()) + " 月起算)   頁次:" + Globals!PageNumber
        Dim TitleArg1 As String = Nothing
        Dim TitleArg2 As String = Nothing
        TitleArg1 = "       時間:" & Format(Now(), "yyyy/MM/dd") & "     唐榮公司   固定資產    殘值使用年限重估表    (自 " & tbSearchYearMonth.Text.Substring(0, 3) & " 年" & tbSearchYearMonth.Text.Substring(3, 2) & " 月起算)"
        'Select Case True
        '    Case rblReportType.SelectedValue = "1"
        '        TitleArg2 = "使用單位主管@行政處@會計處@副總經理@總經理@"
        '    Case rblReportType.SelectedValue = "2"
        '        TitleArg2 = "使用單位主管@行政處@企劃處@會計處@副總經理@"
        '    Case Else
        '        TitleArg2 = "使用單位主管@行政處@企劃處@會計處@副總經理@總經理"
        'End Select
        Dim Parameters(2) As Microsoft.Reporting.WebForms.ReportParameter
        Parameters(0) = New Microsoft.Reporting.WebForms.ReportParameter("TitleString", TitleArg1)
        Parameters(1) = New Microsoft.Reporting.WebForms.ReportParameter("SingArgs", TitleArg2)
        Parameters(2) = New Microsoft.Reporting.WebForms.ReportParameter("ShowReportType", rblReportType.SelectedValue)
        SourceReport.SetParameters(Parameters)
    End Sub
#End Region
#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim SQLString As New StringBuilder
        Dim FactoryName As String = RadioButtonList1.SelectedValue
        SQLString.Append("Select A.*,B.*,C.MASTER From @#AST500LB.AST101PF.ASTF" & FactoryName & " A LEFT JOIN @#AST500LB.AST106PF.ASTF" & FactoryName & " B ON A.NUMBER=B.NUMBER AND B.SEQ=1 LEFT JOIN @#AST500LB.AST107PF C ON A.NUMBER=C.NUMBER WHERE (A.DATE + A.USLAFF*100 + A.N7611*100) = " & tbSearchYearMonth.Text)
        'Select Case True
        '    Case rblReportType.SelectedValue = "2"
        '        SQLString.Append(" AND A.AMOUNT < 1000000 ")
        '    Case rblReportType.SelectedValue = "3"
        '        SQLString.Append(" AND A.AMOUNT >= 1000000 ")
        'End Select
        'Me.hfQry1.Value = SQLString.ToString & IIf(rblReportType.SelectedValue = "1", " order by A.NUMBER,B.DEPTSA", " order by B.DEPTSA,A.NUMBER")

        Me.hfQry1.Value = SQLString.ToString & " order by A.NUMBER,B.DEPTSA"

    End Sub
#End Region

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Now > New Date(Now.Year, Now.Month, 15) Then
                tbSearchYearMonth.Text = Val(Format(Now.AddMonths(1), "yyyyMM")) - 191100
            Else
                tbSearchYearMonth.Text = Val(Format(Now, "yyyyMM")) - 191100
            End If
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakQryStringToControl()
        SubTotalToReportParameter(ReportViewer1.LocalReport)
        ReportViewer1.LocalReport.Refresh()
    End Sub

End Class