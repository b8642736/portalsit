Public Partial Class BorrowContractEdit
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
        Dim ReturnValue As List(Of CompanyORMDB.CASH.CASH05PF) = CompanyORMDB.CASH.CASH05PF.CDBSelect(Of CompanyORMDB.CASH.CASH05PF)("Select * From @#CASH.CASH05PF Order by BANKN1", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        For Each EachItem As CompanyORMDB.CASH.CASH05PF In ReturnValue
            EachItem.BANKNM = EachItem.BANKN1 & "=>" & EachItem.BANKNM
        Next
        Return ReturnValue
    End Function
#End Region
#Region "幣別查詢 方法:SearchMoneyKind"
    ''' <summary>
    ''' 幣別查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SearchMoneyKind() As List(Of CompanyORMDB.DEBY.DEBY07PF)
        'Return CompanyORMDB.ORMBaseClass.ClassDBAS400.CDBSelect(Of CompanyORMDB.DEBY.DEBY07PF)("Select * From @#DEBY.DEBY07PF ORDER BY TYPENO")
        Return CompanyORMDB.ORMBaseClass.ClassDBAS400.CDBSelect(Of CompanyORMDB.DEBY.DEBY07PF)("Select * From @#DEBY.DEBY07PF ORDER BY TYPENO", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    End Function
#End Region

#Region "子借款合約編輯模式下父借款合約 屬性ParentBorrowContractForSubBorrowContractEditMode"
    ''' <summary>
    ''' 子借款合約編輯模式下父借款合約
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ParentBorrowContractForSubBorrowContractEditMode() As CompanyLINQDB.BorrowContract
        Get
            If Not Me.MultiView1.GetActiveView Is Me.SubContractEditView OrElse Me.FormView1.SelectedValue < 0 Then
                Return Nothing
            End If
            Static ReturnValue As CompanyLINQDB.BorrowContract = Nothing
            If IsNothing(ReturnValue) Then
                ReturnValue = (From A In DBDataContext.BorrowContract Where A.BankNumber = FormView1.DataKey.Values(FormView1.DataKeyNames(0)).ToString And A.ContractKind = FormView1.DataKey.Values(FormView1.DataKeyNames(1)).ToString And A.StartDate = CType(FormView1.DataKey.Values(FormView1.DataKeyNames(2)), DateTime) Select A).FirstOrDefault
            End If
            Return ReturnValue
        End Get
    End Property
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
            tbStartDate.Text = Format(Now, "yyyy/01/01")
            tbEndDate.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Dim SourceControl As CustomValidator = source
        Select Case True
            Case DateTime.TryParse(args.Value, Nothing) = False
                SourceControl.Text = "必須要為正確日期格式!"
                args.IsValid = False
        End Select

    End Sub

    Protected Sub CustomValidator2_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)

        Dim SourceControl As CustomValidator = source
        Select Case True
            Case DateTime.TryParse(args.Value, Nothing) = False
                SourceControl.Text = "必須要為正確日期格式!"
                args.IsValid = False
            Case CType(source, CustomValidator).ID = "CustomValidator1" AndAlso CType(CType(Me.FormView1.FindControl("StartDateTextBox"), TextBox).Text, DateTime) >= CType(CType(Me.FormView1.FindControl("EndDateTextBox"), TextBox).Text, DateTime)
                SourceControl.Text = "合約截止日期必須大於合約起始日期!"
                args.IsValid = False
            Case CType(source, CustomValidator).ID = "CustomValidator10" AndAlso CType(CType(Me.FormView1.FindControl("StartDateTextBox11"), TextBox).Text, DateTime) >= CType(CType(Me.FormView1.FindControl("EndDateTextBox12"), TextBox).Text, DateTime)
                SourceControl.Text = "合約截止日期必須大於合約起始日期!"
                args.IsValid = False
        End Select
    End Sub

    Protected Sub ldsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSearchResult.Selecting
        If IsUserAlreadyPutSearch = False OrElse (Not Me.MultiView1.GetActiveView Is Me.SearchContractView) Then
            e.Cancel = True
            Exit Sub
        End If

        Dim Result As IQueryable(Of CompanyLINQDB.BorrowContract) = From A In DBDataContext.BorrowContract Select A
        Result = IIf(DropDownList1.SelectedValue = "ALL", Result, (From A In Result Where A.BankNumber = Me.DropDownList1.SelectedValue Select A))
        Result = IIf(DropDownList2.SelectedValue = "ALL", Result, From A In Result Where A.ContractKind = DropDownList2.SelectedValue Select A)
        Dim InputStartDate As DateTime = CType(Me.tbStartDate.Text, DateTime)
        Dim InputEndDate As DateTime = CType(Me.tbEndDate.Text, DateTime).AddDays(1).AddSeconds(-1)
        Result = From A In Result Where Not (A.StartDate < InputStartDate And A.EndDate < InputStartDate Or A.StartDate > InputEndDate And A.EndDate > InputEndDate) Select A
        e.Result = Result

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Me.IsUserAlreadyPutSearch = True
        Me.FormView1.DataBind()
    End Sub

    Protected Sub btnClearSearchCondiction_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearSearchCondiction.Click
        tbStartDate.Text = Format(Now, "yyyy/01/01")
        tbEndDate.Text = Format(Now, "yyyy/MM/dd")
        DropDownList1.SelectedIndex = 0
        DropDownList2.SelectedIndex = 0
    End Sub

    Protected Sub CustomValidator3_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Dim SourceControl As CustomValidator = source
        Select Case True
            Case String.IsNullOrEmpty(args.Value)
                SourceControl.Text = "必須有值!"
                args.IsValid = False
            Case Not String.IsNullOrEmpty(args.Value) AndAlso Val(args.Value) <= 0
                SourceControl.Text = "值必須大於0!"
                args.IsValid = False
        End Select
    End Sub

    Private Sub FormView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.PreRender
        Select Case True
            Case FormView1.CurrentMode = FormViewMode.Insert
                Dim InsertValidIsAllTrue As Boolean = CType(FormView1.FindControl("CustomValidator1"), CustomValidator).IsValid
                InsertValidIsAllTrue = InsertValidIsAllTrue And CType(FormView1.FindControl("CustomValidator2"), CustomValidator).IsValid
                InsertValidIsAllTrue = InsertValidIsAllTrue And CType(FormView1.FindControl("CustomValidator3"), CustomValidator).IsValid
                InsertValidIsAllTrue = InsertValidIsAllTrue And CType(FormView1.FindControl("CustomValidator4"), CustomValidator).IsValid
                If InsertValidIsAllTrue = False Then    '驗證期間(驗證失敗)不給初始值
                    Exit Sub
                End If
                CType(FormView1.FindControl("StartDateTextBox"), TextBox).Text = Format(Now, "yyyy/MM/dd")
                CType(FormView1.FindControl("EndDateTextBox"), TextBox).Text = Format(Now.AddYears(1), "yyyy/MM/dd")
                CType(FormView1.FindControl("CreditMoneyTextBox"), TextBox).Text = "0"
                CType(FormView1.FindControl("TextBox2"), TextBox).Text = "0"
                CType(FormView1.FindControl("TextBox3"), TextBox).Text = "1"
                CType(FormView1.FindControl("TextBox7"), TextBox).Text = "1"
                CType(FormView1.FindControl("TextBox19"), TextBox).Text = "0"
                If WebAppAuthority.ValidAuthorityModule.CurrentLoginMode = WebAppAuthority.LoginAuthorityModeType.WindowsAuthority Then
                    Dim WindowsLoginID As String = WebAppAuthority.CurrentWindowsLoginEmployeeNumber
                    '1020709 by renhsin
                    'Dim LoginEmployee As CompanyORMDB.PLT500LB.PTM010PF = CompanyORMDB.ORMBaseClass.ClassDBAS400.CDBSelect(Of CompanyORMDB.PLT500LB.PTM010PF)("Select * from PLT500LB.PTM010PF Where PT0102='" & WindowsLoginID & "'").FirstOrDefault
                    Dim LoginEmployee As CompanyORMDB.PLT500LB.PTM010PF = CompanyORMDB.ORMBaseClass.ClassDBAS400.CDBSelect(Of CompanyORMDB.PLT500LB.PTM010PF)("Select * from @#PLT500LB.PTM010PF Where PT0102='" & WindowsLoginID & "'", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC).FirstOrDefault
                    If Not IsNothing(LoginEmployee) Then
                        CType(FormView1.FindControl("ProcessEmployeeTextBox"), TextBox).Text = LoginEmployee.PT0101
                    End If
                End If
        End Select
    End Sub

    Private Sub FormView2_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView2.PreRender
        Select Case True
            Case FormView2.CurrentMode = FormViewMode.Insert
                Dim InsertValidIsAllTrue As Boolean = CType(FormView2.FindControl("CustomValidator11"), CustomValidator).IsValid
                InsertValidIsAllTrue = InsertValidIsAllTrue And CType(FormView2.FindControl("CustomValidator12"), CustomValidator).IsValid
                InsertValidIsAllTrue = InsertValidIsAllTrue And CType(FormView2.FindControl("CustomValidator13"), CustomValidator).IsValid
                InsertValidIsAllTrue = InsertValidIsAllTrue And CType(FormView2.FindControl("CustomValidator14"), CustomValidator).IsValid
                If InsertValidIsAllTrue = False Then    '驗證期間(驗證失敗)不給初始值
                    Exit Sub
                End If
                CType(FormView2.FindControl("HFBankNumber"), HiddenField).Value = FormView1.DataKey.Values(FormView1.DataKeyNames(0))
                CType(FormView2.FindControl("StartDateTextBox0"), TextBox).Text = IIf(Now > ParentBorrowContractForSubBorrowContractEditMode.StartDate, Format(Now, "yyyy/MM/dd"), ParentBorrowContractForSubBorrowContractEditMode.StartDate)
                CType(FormView2.FindControl("EndDateTextBox1"), TextBox).Text = IIf(Now < ParentBorrowContractForSubBorrowContractEditMode.EndDate, ParentBorrowContractForSubBorrowContractEditMode.EndDate, Format(Now, "yyyy/MM/dd"))
                CType(FormView2.FindControl("CreditMoneyTextBox1"), TextBox).Text = "0"
                CType(FormView2.FindControl("DropDownList16"), DropDownList).SelectedValue = ParentBorrowContractForSubBorrowContractEditMode.CreditMoneyKind
                CType(FormView2.FindControl("DropDownList17"), DropDownList).SelectedValue = ParentBorrowContractForSubBorrowContractEditMode.RePaymentBankNumber
                CType(FormView2.FindControl("DropDownList18"), DropDownList).SelectedValue = ParentBorrowContractForSubBorrowContractEditMode.PayRateKind
                CType(FormView2.FindControl("TextBox15"), TextBox).Text = ParentBorrowContractForSubBorrowContractEditMode.LatePayMonths
                CType(FormView2.FindControl("TextBox16"), TextBox).Text = ParentBorrowContractForSubBorrowContractEditMode.RePaymentTimes
                CType(FormView2.FindControl("TextBox17"), TextBox).Text = ParentBorrowContractForSubBorrowContractEditMode.PayRateMoneyDayNumber
                CType(FormView2.FindControl("TextBox20"), TextBox).Text = "0"
                If WebAppAuthority.ValidAuthorityModule.CurrentLoginMode = WebAppAuthority.LoginAuthorityModeType.WindowsAuthority Then
                    Dim WindowsLoginID As String = WebAppAuthority.CurrentWindowsLoginEmployeeNumber
                    '1020709 by renhsin
                    'Dim LoginEmployee As CompanyORMDB.PLT500LB.PTM010PF = CompanyORMDB.ORMBaseClass.ClassDBAS400.CDBSelect(Of CompanyORMDB.PLT500LB.PTM010PF)("Select * from PLT500LB.PTM010PF Where PT0102='" & WindowsLoginID & "'").FirstOrDefault
                    Dim LoginEmployee As CompanyORMDB.PLT500LB.PTM010PF = CompanyORMDB.ORMBaseClass.ClassDBAS400.CDBSelect(Of CompanyORMDB.PLT500LB.PTM010PF)("Select * from PLT500LB.PTM010PF Where PT0102='" & WindowsLoginID & "'", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC).FirstOrDefault
                    If Not IsNothing(LoginEmployee) Then
                        CType(FormView2.FindControl("ProcessEmployeeTextBox1"), TextBox).Text = LoginEmployee.PT0101
                    End If
                End If
                CType(Me.FormView2.FindControl("CHIsHaveParentContract"), CheckBox).Checked = True
                CType(Me.FormView2.FindControl("HFFK_CompostBankNumber"), HiddenField).Value = ParentBorrowContractForSubBorrowContractEditMode.BankNumber  'FormView1.DataKey.Values(FormView1.DataKeyNames(0))
                CType(Me.FormView2.FindControl("HFFK_CompostContractKind"), HiddenField).Value = ParentBorrowContractForSubBorrowContractEditMode.ContractKind ' FormView1.DataKey.Values(FormView1.DataKeyNames(1))
                CType(Me.FormView2.FindControl("tbFK_CompostStartDate"), TextBox).Text = ParentBorrowContractForSubBorrowContractEditMode.StartDate ' FormView1.DataKey.Values(FormView1.DataKeyNames(2))
        End Select

    End Sub


    Protected Sub CustomValidator4_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Dim SourceControl As CustomValidator = source
        If CType(args.Value, Integer) < 1 Then
            SourceControl.Text = "還款期數最少必須1期!"
            args.IsValid = False
        End If
    End Sub

    Protected Sub CustomValidator5_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Dim SourceControl As CustomValidator = source
        Select Case True
            Case DateTime.TryParse(args.Value, Nothing) = False
                SourceControl.Text = "必須要為正確日期格式!"
                args.IsValid = False
            Case Me.MultiView1.GetActiveView Is SearchContractView AndAlso CType(CType(Me.FormView1.FindControl("StartDateLabel1"), Label).Text, DateTime) >= CType(CType(Me.FormView1.FindControl("EndDateTextBox"), TextBox).Text, DateTime)
                SourceControl.Text = "合約截止日期必須大於合約起始日期!"
                args.IsValid = False
            Case Me.MultiView1.GetActiveView Is SubContractEditView AndAlso CType(CType(Me.FormView2.FindControl("StartDateLabel2"), Label).Text, DateTime) >= CType(CType(Me.FormView2.FindControl("EndDateTextBox0"), TextBox).Text, DateTime)
                SourceControl.Text = "合約截止日期必須大於合約起始日期!"
                args.IsValid = False
        End Select

    End Sub

    Protected Sub CustomValidator7_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Dim SourceControl As CustomValidator = source
        If CType(args.Value, Integer) < 1 Then
            SourceControl.Text = "還款期數最少必須1期!"
            args.IsValid = False
        End If

    End Sub

    Protected Sub Backup_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.MultiView1.SetActiveView(Me.SearchContractView)
        Me.FormView1.DataBind()
    End Sub

    Protected Sub LDSSubContractSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSSubContractSearchResult.Selecting
        If Not Me.MultiView1.GetActiveView Is Me.SubContractEditView Then
            e.Cancel = True
            Exit Sub
        End If
        Dim CurrentBankNumber As String = FormView1.DataKey.Values(FormView1.DataKeyNames(0))
        Dim CurrentContractKind As String = FormView1.DataKey.Values(FormView1.DataKeyNames(1))
        Dim CurrentStartDate As DateTime = CType(FormView1.DataKey.Values(FormView1.DataKeyNames(2)), DateTime)
        e.Result = From A In DBDataContext.BorrowContract Where A.FK_CompostBankNumber = CurrentBankNumber And A.FK_CompostContractKind = CurrentContractKind And A.FK_CompostStartDate = CurrentStartDate Select A
    End Sub

    Protected Sub btnCancelBackup_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.FormView1.DataBind()
        Me.MultiView1.SetActiveView(Me.SearchContractView)
    End Sub

    Protected Sub lbEditSubContract_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.MultiView1.SetActiveView(Me.SubContractEditView)
    End Sub

End Class