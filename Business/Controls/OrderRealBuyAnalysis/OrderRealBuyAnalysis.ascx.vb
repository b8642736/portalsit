Public Class OrderRealBuyAnalysis
    Inherits System.Web.UI.UserControl
    'OrderRealBuyAnalysisDataTable
#Region "資料查詢 方法:Search"
    'Public Shared Function Search(ByVal SQLQry As String) As List(Of SLS300LB.OrderRealBuyAnalysisDataTableRow)
    ''' <summary>
    ''' 資料查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function Search(ByVal SQLQry As String) As SLS300LB.OrderRealBuyAnalysisDataTableDataTable
        If String.IsNullOrEmpty(SQLQry) Then
            Return New SLS300LB.OrderRealBuyAnalysisDataTableDataTable
        End If


        Dim ReturnValue As New SLS300LB.OrderRealBuyAnalysisDataTableDataTable
        Dim GetDatas As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = CompanyORMDB.SLS300LB.SL2QTNPF.CDBSelect(Of CompanyORMDB.SLS300LB.SL2QTNPF)(SQLQry, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim AddItem As SLS300LB.OrderRealBuyAnalysisDataTableRow
        For Each Eachitem In (From A In GetDatas Select A.QTN01, A.QTN03, A.QTN04 Order By QTN01, QTN03, QTN04).Distinct
            Dim FilterDatas As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = (From A In GetDatas Where A.QTN01 = Eachitem.QTN01 And A.QTN03 = Eachitem.QTN03 And A.QTN04 = Eachitem.QTN04 Select A).ToList
            AddItem = ReturnValue.NewRow
            Dim FindCustomer As CompanyORMDB.SLS300LB.SL2CUAPF = (From A In CompanyORMDB.SLS300LB.SL2CUAPF.ALLSL2CUAPFs Where A.CUA01.Trim = Eachitem.QTN01).FirstOrDefault

            With AddItem
                If IsNothing(FindCustomer) OrElse String.IsNullOrEmpty(FindCustomer.CUA11) Then
                    .公司名稱 = Eachitem.QTN01
                Else
                    .公司名稱 = IIf(FindCustomer.CUA11.Trim.Length = 0, Eachitem.QTN01, FindCustomer.CUA11.Trim)
                End If
                .鋼種 = Eachitem.QTN03
                .表面 = Eachitem.QTN04
                .訂購量 = Format((From A In FilterDatas Select A.QTN12).Sum * 1000, "0,0")
                .出貨量 = Format((From A In FilterDatas Select A.QTN21).Sum * 1000, "0,0")
                .達成率 = Format(CType(.出貨量, Double) / CType(.訂購量, Double), "0,0.00%")
            End With
            ReturnValue.Rows.Add(AddItem)
        Next
        If ReturnValue.Rows.Count > 0 Then
            AddItem = ReturnValue.NewRow
            With AddItem
                .公司名稱 = "平均"
                .訂購量 = Format((From A In ReturnValue Select CType(A.Item("訂購量"), Double)).Average, "0,0")
                .出貨量 = Format((From A In ReturnValue.Rows Select CType(A.Item("出貨量"), Double)).Average, "0,0")
                .達成率 = Format(CType(.出貨量, Double) / CType(.訂購量, Double), "0,0.00%")
            End With
            ReturnValue.Rows.Add(AddItem)
        End If


        Return ReturnValue
    End Function
#End Region

#Region "產生查詢至控製項 函式:MakeQryToControl"
    Private Sub MakeQryToControl()
        Dim SQLString As String = "Select A.* from @#SLS300LB.SL2QTNPF AS A WHERE QTN29='E' "  '外銷

        Dim StartTwDate As String = Format(CType(tbStartYear.Text, Integer) * 100 + CType(tbStartMonth.Text, Integer), "00000")
        Dim EndTwDate As String = Format(CType(tbEndYear.Text, Integer) * 100 + CType(tbEndMonth.Text, Integer) + 1, "00000")
        SQLString &= " AND QTN02>='" & StartTwDate & "' AND QTN02<'" & EndTwDate & "'"
        hfQry.Value = SQLString
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.tbStartYear.Text = Format(Now, "yyyy") - 1911
            Me.tbEndYear.Text = Me.tbStartYear.Text
            Me.tbStartMonth.Text = Format(Now, "MM")
            Me.tbEndMonth.Text = Me.tbStartMonth.Text
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        MakeQryToControl()
        ReportViewer1.Visible = True
        Dim Parameters(0) As Microsoft.Reporting.WebForms.ReportParameter
        Parameters(0) = New Microsoft.Reporting.WebForms.ReportParameter("TitleParameter1", tbStartYear.Text & "年" & tbStartMonth.Text & "月~" & tbEndYear.Text & "年" & tbEndMonth.Text & "月 ")
        ReportViewer1.LocalReport.SetParameters(Parameters)
        ReportViewer1.LocalReport.Refresh()
    End Sub

End Class