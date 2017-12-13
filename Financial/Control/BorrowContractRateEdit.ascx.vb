Public Partial Class BorrowContractRateEdit
    Inherits System.Web.UI.UserControl


#Region "銀行代碼查詢 方法:SearchBankInfo"
    ''' <summary>
    ''' 銀行代碼查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SearchBankInfo() As List(Of CompanyORMDB.CASH.CASH05PF)
        Dim ReturnValue As List(Of CompanyORMDB.CASH.CASH05PF) = SearchBankInfo1()
        Dim InsertAllOption As New CompanyORMDB.CASH.CASH05PF
        InsertAllOption.BANKNM = "全部"
        InsertAllOption.BANKN1 = "ALL"
        ReturnValue.Insert(0, InsertAllOption)
        Return ReturnValue
    End Function
#End Region
#Region "銀行代碼查詢1 方法:SearchBankInfo1"
    ''' <summary>
    ''' 銀行代碼查詢1
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SearchBankInfo1() As List(Of CompanyORMDB.CASH.CASH05PF)
        Dim ReturnValue As List(Of CompanyORMDB.CASH.CASH05PF) = CompanyORMDB.CASH.CASH05PF.CDBSelect(Of CompanyORMDB.CASH.CASH05PF)("Select * From @#CASH.CASH05PF Order by BANKNM", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        For Each EachItem As CompanyORMDB.CASH.CASH05PF In ReturnValue
            EachItem.BANKNM = EachItem.BANKN1 & "=>" & EachItem.BANKNM
        Next
        Return ReturnValue
    End Function
#End Region

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
        If Not IsPostBack Then
            TextBox1.Text = Format(Now, "yyyy/01/01")
            TextBox2.Text = Format(Now.AddYears(10), "yyyy/01/01")
        End If
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Select Case e.CommandName.ToUpper
            Case "SELECT"
                Me.TabPanel2.Visible = True
                Me.TabContainer1.ActiveTab = Me.TabPanel2
            Case "PAGE"
                Me.TabPanel2.Visible = False
                Me.TabContainer1.ActiveTab = Me.TabPanel1
        End Select
    End Sub

    Protected Sub LDSSearchResult1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSSearchResult1.Selecting
        If Not Me.TabContainer1.ActiveTab Is Me.TabPanel2 AndAlso GridView1.SelectedIndex >= 0 Then
            e.Cancel = True
            Exit Sub
        End If

        Dim Result As IQueryable(Of CompanyLINQDB.BorrowContractRate) = From A In DBDataContext.BorrowContractRate Where A.BankNumber = GridView1.SelectedDataKey.Values("BankNumber").ToString And A.ContractKind = GridView1.SelectedDataKey.Values("ContractKind").ToString And A.StartDate = CType(GridView1.SelectedDataKey.Values("StartDate"), DateTime) Select A
        If RadioButtonList1.SelectedValue = "1" Then
            Dim InputStartDate As DateTime = CType(Me.TextBox1.Text, DateTime)
            Dim InputEndDate As DateTime = CType(Me.TextBox2.Text, DateTime).AddDays(1).AddSeconds(-1)
            Result = From A In Result Where Not (A.RateStartDate < InputStartDate And A.RateEndDate < InputStartDate Or A.RateStartDate > InputEndDate And A.RateEndDate > InputEndDate) Select A
        End If
        e.Result = Result
    End Sub

    Protected Sub LDSSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSSearchResult.Selecting
        If IsUserAlreadyPutSearch = False Then
            e.Cancel = True
            Exit Sub
        End If

        Dim Result As IQueryable(Of CompanyLINQDB.BorrowContract) = From A In DBDataContext.BorrowContract Where A.ContractKind <> "99" Select A
        Result = IIf(DropDownList1.SelectedValue = "ALL", Result, (From A In Result Where A.BankNumber = Me.DropDownList1.SelectedValue Select A))
        Result = IIf(DropDownList2.SelectedValue = "ALL", Result, From A In Result Where A.ContractKind = DropDownList2.SelectedValue Select A)
        e.Result = Result
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        Me.TabPanel2.Visible = False
        Me.GridView1.DataBind()
    End Sub

    Protected Sub btnClearSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearSearch.Click
        Me.DropDownList1.SelectedIndex = 0
        Me.DropDownList2.SelectedIndex = 0
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        ListView1.DataBind()
    End Sub

    Private Sub ListView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.PreRender
        ListView1.DataBind()
        CType(ListView1.InsertItem.FindControl("BankNumberTextBox"), TextBox).Text = GridView1.SelectedDataKey.Values("BankNumber")
        CType(ListView1.InsertItem.FindControl("ContractKindTextBox"), TextBox).Text = GridView1.SelectedDataKey.Values("ContractKind")
        CType(ListView1.InsertItem.FindControl("StartDateTextBox"), TextBox).Text = GridView1.SelectedDataKey.Values("StartDate")
        CType(ListView1.InsertItem.FindControl("RateStartDateTextBox"), TextBox).Text = Format(Now, "yyyy/MM/dd")
        CType(ListView1.InsertItem.FindControl("RateEndDateTextBox"), TextBox).Text = Format(Now.AddDays(7), "yyyy/MM/dd")
    End Sub

    Protected Sub btnRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRefresh.Click
        Me.ListView1.DataBind()
    End Sub

    Protected Sub CustomValidator1_OnServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        If ListView1.EditIndex >= 0 Then
            args.IsValid = True
            Exit Sub
        End If
        Dim Result As IQueryable(Of CompanyLINQDB.BorrowContractRate) = From A In DBDataContext.BorrowContractRate Where A.BankNumber = GridView1.SelectedDataKey.Values("BankNumber").ToString And A.ContractKind = GridView1.SelectedDataKey.Values("ContractKind").ToString And A.StartDate = CType(GridView1.SelectedDataKey.Values("StartDate"), DateTime) Select A
        Dim InputStartDate As DateTime = CType(CType(ListView1.InsertItem.FindControl("RateStartDateTextBox"), TextBox).Text, DateTime)
        Dim InputEndDate As DateTime = CType(CType(ListView1.InsertItem.FindControl("RateEndDateTextBox"), TextBox).Text, DateTime).AddDays(1).AddSeconds(-1)
        If (From A In Result Where Not (A.RateStartDate < InputStartDate And A.RateEndDate < InputStartDate Or A.RateStartDate > InputEndDate And A.RateEndDate > InputEndDate) Select A).Count > 0 Then
            CType(source, CustomValidator).Text = "此段期間已有利率產生無法重複新增!"
            args.IsValid = False
        End If
    End Sub
    Protected Sub CustomValidator2_OnServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        '未完成仍需Debug
        If ListView1.EditIndex < 0 Then
            args.IsValid = True
            Exit Sub
        End If

        Dim InputStartDate As DateTime = CType(CType(ListView1.EditItem.FindControl("RateStartDateLabel1"), Label).Text, DateTime)
        Dim InputEndDate As DateTime = CType(CType(ListView1.EditItem.FindControl("RateEndDateTextBox"), TextBox).Text, DateTime).AddDays(1).AddSeconds(-1)
        Dim Result As IQueryable(Of CompanyLINQDB.BorrowContractRate) = From A In DBDataContext.BorrowContractRate Where A.BankNumber = GridView1.SelectedDataKey.Values("BankNumber").ToString And A.ContractKind = GridView1.SelectedDataKey.Values("ContractKind").ToString And A.StartDate = CType(GridView1.SelectedDataKey.Values("StartDate"), DateTime) And Not (A.RateStartDate < InputStartDate And A.RateEndDate < InputStartDate Or A.RateStartDate > InputEndDate And A.RateEndDate > InputEndDate) Select A

        Dim CurrentEditBanknumber As String = CType(ListView1.EditItem.FindControl("BankNumberLabel1"), Label).Text
        Dim CurrentEditContractKind As String = CType(ListView1.EditItem.FindControl("ContractKindLabel1"), Label).Text
        Dim CurrentEditStartDate As DateTime = CType(CType(ListView1.EditItem.FindControl("StartDateLabel1"), Label).Text, DateTime)
        Dim CurrentEditRateStartDate As DateTime = CType(CType(ListView1.EditItem.FindControl("RateStartDateLabel1"), Label).Text, DateTime)
        Result = From A In Result Where A.BankNumber <> CurrentEditBanknumber And A.ContractKind <> CurrentEditContractKind And A.StartDate <> CurrentEditStartDate And A.RateStartDate <> CurrentEditRateStartDate Select A

        Dim RecordCount As Integer = (From A In Result Select A).Count
        If RecordCount > 0 Then
            CType(source, CustomValidator).Text = "此段期間已有利率產生無法重複更新!"
            args.IsValid = False
        End If

    End Sub

End Class