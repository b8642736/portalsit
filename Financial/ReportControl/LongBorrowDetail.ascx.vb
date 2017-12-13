Public Partial Class LongBorrowDetail
    Inherits System.Web.UI.UserControl

    Dim DBDataContext As New CompanyLINQDB.FincialDataContext


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

    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClear.Click
        IsUserAlreadyPutSearch = False
        RadioButtonList1.SelectedIndex = 0
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        Me.ReportViewer1.LocalReport.Refresh()
    End Sub

    Protected Sub ldsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSearchResult.Selecting
        If IsUserAlreadyPutSearch = False Then
            'e.Cancel = True
            e.Result = New List(Of Borrow)
            Exit Sub
        End If

        Dim Result As IQueryable(Of CompanyLINQDB.Borrow) = From A In DBDataContext.Borrow Where Now >= A.BorrowStartDate And Now <= A.BorrowEndDate Select A
        Select Case True
            Case RadioButtonList1.SelectedIndex = 1
                Result = From a In Result Where a.FK_ContractKind = "L1" Select a
            Case RadioButtonList1.SelectedIndex = 2
                Result = From a In Result Where a.FK_ContractKind = "L2" Select a
            Case Else
                Result = From a In Result Where a.FK_ContractKind = "L1" Or a.FK_ContractKind = "L2" Select a
        End Select
        e.Result = (From A In Result.ToList Where A.NextTimePlanPayUseMoney > 0 Select A Order By A.NextTimePlanPayUseMoneyDate).ToList
    End Sub
End Class