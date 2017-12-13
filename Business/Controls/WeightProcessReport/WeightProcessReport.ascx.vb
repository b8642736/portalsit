Public Partial Class WeightProcessReport
    Inherits System.Web.UI.UserControl

#Region "資料查詢 方法:Search"
    ''' <summary>
    ''' 資料查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function Search(ByVal FindDate As Date, ByVal StartNumber As Integer, ByVal EndNumber As Integer) As Business.WeightProcessDataSet.WeightProcessDataTableDataTable
        'Dim SetFindDate As String = (Format(FindDate, "yyyy") - 1911) * 10000 + Format(FindDate, "MMdd")
        'Dim SQLString As String = "Select * from @#PPS100LB.PPSCICPF Where PPS03 =" & SetFindDate & " AND PPS07>=" & StartNumber & " AND PPS07<=" & EndNumber & " Order by PPS07"
        'Dim SearchResult As List(Of CompanyORMDB.PPS100LB.PPSCICPF) = CompanyORMDB.PPS100LB.PPSCICPF.CDBSetDataTableToObjects(Of CompanyORMDB.PPS100LB.PPSCICPF)(New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString).SelectQuery)
        'Dim ReturnValue As New WeightProcessDataSet.WeightProcessDataTableDataTable
        'For Each EachItem As CompanyORMDB.PPS100LB.PPSCICPF In SearchResult
        '    Dim EachItemTemp As CompanyORMDB.PPS100LB.PPSCICPF = EachItem
        '    Dim AddRow As Business.WeightProcessDataSet.WeightProcessDataTableRow = ReturnValue.NewRow
        '    With AddRow
        '        .鋼捲號碼 = EachItemTemp.PPS01.Trim & EachItemTemp.PPS02.Trim
        '        .序號 = EachItemTemp.PPS07
        '        .毛重 = EachItemTemp.PPS05
        '        .繳庫單位 = EachItemTemp.AboutPPSSHAPFs_LastRecordSHA08
        '        .備註 = EachItemTemp.AboutPPSSHAPFs_LastRecordSHA35
        '    End With
        '    ReturnValue.Rows.Add(AddRow)
        'Next
        Dim SetFindDate As String = (Format(FindDate, "yyyy") - 1911) * 10000 + Format(FindDate, "MMdd")
        Dim SQLString As String = "Select * from @#PPS100LB.PPSCICPF Where CIC03 =" & SetFindDate & " AND CIC05>=" & StartNumber & " AND CIC05<=" & EndNumber & " Order by CIC05"
        Dim SearchResult As List(Of CompanyORMDB.PPS100LB.PPSCICPF) = CompanyORMDB.PPS100LB.PPSCICPF.CDBSetDataTableToObjects(Of CompanyORMDB.PPS100LB.PPSCICPF)(New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString).SelectQuery)
        Dim ReturnValue As New WeightProcessDataSet.WeightProcessDataTableDataTable
        For Each EachItem As CompanyORMDB.PPS100LB.PPSCICPF In SearchResult
            Dim EachItemTemp As CompanyORMDB.PPS100LB.PPSCICPF = EachItem
            Dim AddRow As Business.WeightProcessDataSet.WeightProcessDataTableRow = ReturnValue.NewRow
            With AddRow
                .鋼捲號碼 = EachItemTemp.CIC01.Trim & EachItemTemp.CIC02.Trim
                .序號 = EachItemTemp.CIC05
                .毛重 = EachItemTemp.CIC06
                .繳庫單位 = EachItemTemp.AboutPPSSHAPFs_LastRecordSHA08
                .備註 = EachItemTemp.AboutPPSSHAPFs_LastRecordSHA35
            End With
            ReturnValue.Rows.Add(AddRow)
        Next
        Return ReturnValue
    End Function


#End Region

#Region "使用者是否已按下查詢 屬性:IsUserAlreadyPutSearch"

    ''' <summary>
    ''' 使用者是否已按下查詢
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsUserAlreadyPutSearch() As Boolean
        Get
            If IsNothing(Me.ViewState("_IsUserAlreadyPutSearch")) Then
                Return False
            End If
            Return Me.ViewState("_IsUserAlreadyPutSearch")
        End Get
        Set(ByVal value As Boolean)
            Me.ViewState("_IsUserAlreadyPutSearch") = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            TextBox1.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Me.IsUserAlreadyPutSearch = True
        ReportViewer1.Visible = True
        Dim PrintDate As Date = CType(Me.TextBox1.Text, DateTime)
        Dim Parameters(0) As Microsoft.Reporting.WebForms.ReportParameter
        Parameters(0) = New Microsoft.Reporting.WebForms.ReportParameter("PrintDate", Format(PrintDate, "yyyy") - 1911 & " 年" & Format(PrintDate, " MM 月 dd  日"))
        ReportViewer1.LocalReport.SetParameters(Parameters)
        ReportViewer1.Visible = True
        ReportViewer1.LocalReport.Refresh()
    End Sub

    Private Sub odsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsSearchResult.Selecting
        e.Cancel = Not Me.IsUserAlreadyPutSearch
    End Sub

End Class