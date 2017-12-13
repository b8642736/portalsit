Public Partial Class PCashInOutReportMaker
    Inherits System.Web.UI.UserControl


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

    Dim DataContext As New CompanyLINQDB.PCashDataContext

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            TextBox1.Text = Format(Now, "yyyy")
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        ReportViewer1.Visible = True
        Dim Parameters(2) As Microsoft.Reporting.WebForms.ReportParameter
        Dim ToCashCheckMoney As Long = (From C In DataContext.PCash1 Where (From A In DataContext.PCash3 Where (From B In DataContext.PCash2 Where B.RecDate >= New DateTime(Val(TextBox1.Text), 1, 1) And B.RecDate <= New DateTime(Val(TextBox1.Text), 1, 1).AddYears(1).AddSeconds(-1) And B.IsToCashed = True And B.IsNewYearStartTicket = False Select B.RecDate.ToString + B.Number.ToString).Contains(A.PC2RecDate.ToString + A.PC2Number.ToString) Select A.PC1RecDate.ToString & A.PC1Number.ToString).Contains(C.RecDate.ToString & C.Number.ToString) Select C.PutMoney).ToList.Sum
        ToCashCheckMoney += (From A In DataContext.PCash2 Where A.RecDate >= New DateTime(Val(TextBox1.Text), 1, 1) And A.RecDate <= New DateTime(Val(TextBox1.Text), 1, 1).AddYears(1).AddSeconds(-1) And A.IsNewYearStartTicket = True Select A.NewYearStartMoney).ToList.Sum
        Dim UnToCashCheckMoney As Long = (From C In DataContext.PCash1 Where (From A In DataContext.PCash3 Where (From B In DataContext.PCash2 Where B.RecDate >= New DateTime(Val(TextBox1.Text), 1, 1) And B.RecDate <= New DateTime(Val(TextBox1.Text), 1, 1).AddYears(1).AddSeconds(-1) And B.IsToCashed = False And B.IsNewYearStartTicket = False Select B.RecDate.ToString + B.Number.ToString).Contains(A.PC2RecDate.ToString + A.PC2Number.ToString) Select A.PC1RecDate.ToString & A.PC1Number.ToString).Contains(C.RecDate.ToString & C.Number.ToString) Select C.PutMoney).ToList.Sum
        Parameters(0) = New Microsoft.Reporting.WebForms.ReportParameter("CheckMoney1", ToCashCheckMoney + UnToCashCheckMoney)
        Parameters(1) = New Microsoft.Reporting.WebForms.ReportParameter("CheckMoney2", ToCashCheckMoney)
        Parameters(2) = New Microsoft.Reporting.WebForms.ReportParameter("CheckMoney3", UnToCashCheckMoney)
        ReportViewer1.LocalReport.SetParameters(Parameters)
        ReportViewer1.LocalReport.Refresh()
    End Sub

    Protected Sub LDSSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSSearchResult.Selecting
        If IsUserAlreadyPutSearch = False Then
            e.Cancel = True
            Exit Sub
        End If
        Dim Result As IQueryable(Of PCash1) = From A In DataContext.PCash1 Where A.RecDate >= New DateTime(Val(TextBox1.Text), 1, 1) And A.RecDate < New DateTime(Val(TextBox1.Text), 1, 1).AddYears(1) Select A Order By A.Number, A.RecDate
        Result = IIf(DropDownList1.SelectedValue = "0ALL", Result, From A In Result Where A.DepCode = DropDownList1.SelectedValue Select A)
        e.Result = Result
    End Sub

    Protected Sub LDSPCCash4_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSPCCash4.Selecting
        Dim AllItem As New CompanyLINQDB.PCash4
        AllItem.DepCode = "0ALL"
        AllItem.DepName = "全部"
        Dim Result As List(Of CompanyLINQDB.PCash4) = (From A In DataContext.PCash4 Select A).ToList
        Result.Add(AllItem)
        e.Result = Result
    End Sub
End Class