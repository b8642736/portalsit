Public Partial Class BorrowPayMoneyEdit
    Inherits System.Web.UI.UserControl


    Dim DBDataContext As New CompanyLINQDB.FincialDataContext

#Region "銀行代碼查詢 方法:SearchBankInfo"
    ''' <summary>
    ''' 銀行代碼查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function SearchBankInfo() As List(Of CompanyORMDB.CASH.CASH05PF)
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
    Public Function SearchBankInfo1() As List(Of CompanyORMDB.CASH.CASH05PF)
        Dim ReturnValue As List(Of CompanyORMDB.CASH.CASH05PF) = (From A In CompanyORMDB.CASH.CASH05PF.CDBSelect(Of CompanyORMDB.CASH.CASH05PF)("Select * From @#CASH.CASH05PF Order by BANKN1", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC) Select A).ToList
        For Each EachItem As CompanyORMDB.CASH.CASH05PF In ReturnValue
            EachItem.BANKNM = EachItem.BANKN1 & "=>" & EachItem.BANKNM
        Next
        Return ReturnValue
    End Function
#End Region
#Region "已借款且有效之記錄銀行代碼查詢2 方法:SearchBankInfo2"
    Private _SearchBankInfo2 As List(Of CompanyORMDB.CASH.CASH05PF)
    ''' <summary>
    ''' 已借款且有效之記錄銀行代碼查詢2
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function SearchBankInfo2() As List(Of CompanyORMDB.CASH.CASH05PF)
        If IsNothing(_SearchBankInfo2) Then
            'Dim HaveLCBorrowBankNumbers As List(Of String) = (From A In DBDataContext.Borrow Where A.FK_ContractKind <> "S3" And Now.Date >= A.BorrowStartDate And Now.Date <= A.BorrowEndDate Select A.FK_BankNumber Distinct).ToList
            'Dim ReturnValue As List(Of CompanyLINQDB.CASH.CASH05PF) = (From A In CompanyLINQDB.CASH.CASH05PF.CDBSelect(Of CompanyLINQDB.CASH.CASH05PF)("Select * From @#CASH.CASH05PF Order by BANKN1") Where HaveLCBorrowBankNumbers.Contains(A.BANKN1) Select A).ToList
            'For Each EachItem As CompanyLINQDB.CASH.CASH05PF In ReturnValue
            '    EachItem.BANKNM = EachItem.BANKN1 & "=>" & EachItem.BANKNM
            'Next
            '_SearchBankInfo2 = ReturnValue
            _SearchBankInfo2 = SearchBankInfo3()
        End If

        Dim InsertAllOption As New CompanyORMDB.CASH.CASH05PF
        InsertAllOption.BANKNM = "全部"
        InsertAllOption.BANKN1 = "ALL"
        _SearchBankInfo2.Insert(0, InsertAllOption)

        Return _SearchBankInfo2
    End Function
#End Region
#Region "已借款且有效之記錄銀行代碼查詢3 方法:SearchBankInfo3"
    Private _SearchBankInfo3 As List(Of CompanyORMDB.CASH.CASH05PF)
    ''' <summary>
    ''' 已借款且有效之記錄銀行代碼查詢2
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function SearchBankInfo3() As List(Of CompanyORMDB.CASH.CASH05PF)
        If IsNothing(_SearchBankInfo3) Then
            Dim HaveLCBorrowBankNumbers As List(Of String) = (From A In DBDataContext.Borrow Where A.FK_ContractKind <> "S3" And Now.Date >= A.BorrowStartDate And Now.Date <= A.BorrowEndDate Select A.FK_BankNumber Distinct).ToList
            Dim ReturnValue As List(Of CompanyORMDB.CASH.CASH05PF) = (From A In CompanyORMDB.CASH.CASH05PF.CDBSelect(Of CompanyORMDB.CASH.CASH05PF)("Select * From @#CASH.CASH05PF Order by BANKN1", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC) Where HaveLCBorrowBankNumbers.Contains(A.BANKN1) Select A).ToList
            For Each EachItem As CompanyORMDB.CASH.CASH05PF In ReturnValue
                EachItem.BANKNM = EachItem.BANKN1 & "=>" & EachItem.BANKNM
            Next
            _SearchBankInfo3 = ReturnValue
        End If
        Return _SearchBankInfo3
    End Function
#End Region
#Region "重整新增時可用合約代碼重整 函式:RefreshInsertCanUseContractKind"
    ''' <summary>
    ''' 重整新增時可用合約代碼重整
    ''' </summary>
    ''' <param name="SetBankNumber"></param>
    ''' <remarks></remarks>
    Private Sub RefreshInsertCanUseContractKind(ByVal SetBankNumber As String)
        Dim SourceControl As DropDownList = Me.ListView1.InsertItem.FindControl("DropDownList3")
        Dim CanUseContractKindNumber As List(Of String) = (From A In DBDataContext.Borrow Where A.FK_BankNumber = SetBankNumber And CompanyLINQDB.BorrowPayMoney.AllCanUseContractKindCodes.Contains(A.FK_ContractKind) Select A.FK_ContractKind Distinct).ToList
        SourceControl.Items.Clear()
        For Each EachItem As String In CanUseContractKindNumber
            SourceControl.Items.Add(New ListItem(CompanyLINQDB.BorrowContract.GetContractKindName(EachItem), EachItem))
            SourceControl.SelectedIndex = 0
        Next
    End Sub
#End Region
#Region "現在新增使用借款資料  屬性:NowInsertUseBorrow"
    ''' <summary>
    ''' 現在新增使用借款資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property NowInsertUseBorrow() As CompanyLINQDB.Borrow
        Get
            Return Me.Session("_NowInsertUseBorrow")
        End Get
        Set(ByVal value As CompanyLINQDB.Borrow)
            Dim OldValue As CompanyLINQDB.Borrow = Me.Session("_NowInsertUseBorrow")
            Me.Session("_NowInsertUseBorrow") = value

            Dim InsertButton As Button = Me.ListView1.InsertItem.FindControl("InsertButton")
            Dim PayUseMoneyTextBox As TextBox = Me.ListView1.InsertItem.FindControl("PayUseMoneyTextBox")
            Dim PayRateMoneyTextBox As TextBox = Me.ListView1.InsertItem.FindControl("PayRateMoneyTextBox")
            PayUseMoneyTextBox.Text = "0"
            PayRateMoneyTextBox.Text = "0"
            If Not OldValue Is value Then
                If Not IsNothing(value) Then
                    CType(Me.ListView1.InsertItem.FindControl("PayBankNumberDropDownList"), DropDownList).SelectedValue = value.RePaymentBankNumber
                    PayUseMoneyTextBox.Text = Format(value.NextTimePlanPayUseMoney, "0.00")
                    PayRateMoneyTextBox.Text = Format(value.PayRateMoney, "0.000")
                    InsertButton.Enabled = CType(Me.ListView1.InsertItem.FindControl("DropDownList5"), DropDownList).Items.Count > 0
                Else
                    InsertButton.Enabled = False
                End If
            End If
        End Set
    End Property
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
            Call btnClearSearch_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ListView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.PreRender
        Dim PayMoneyDateTextBox As TextBox = ListView1.InsertItem.FindControl("PayMoneyDateTextBox")
        Dim PayRateMoneyCritdialDateTextBox As TextBox = ListView1.InsertItem.FindControl("PayRateMoneyCritdialDateTextBox")
        If Not IsPostBack OrElse String.IsNullOrEmpty(PayMoneyDateTextBox.Text) OrElse String.IsNullOrEmpty(PayRateMoneyCritdialDateTextBox.Text) Then
            PayMoneyDateTextBox.Text = Format(Now.Date, "yyyy/MM/dd")
            PayRateMoneyCritdialDateTextBox.Text = Format(Now.Date, "yyyy/MM/dd")
        End If
    End Sub

    Public Sub DropDownList2_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim DDL As DropDownList = sender
        If DDL.Items.Count > 0 And DDL.SelectedIndex < 0 Then
            DDL.SelectedIndex = 0
        End If
    End Sub

    Public Sub DropDownList4_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim DDL As DropDownList = sender
        If DDL.Items.Count > 0 And DDL.SelectedIndex < 0 Then
            DDL.SelectedIndex = 0
        End If
    End Sub

    Public Sub DropDownList5_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim DDL As DropDownList = sender
        If DDL.Items.Count > 0 And DDL.SelectedIndex < 0 Then
            DDL.SelectedIndex = 0
        End If
        Call DropDownList5_SelectedIndexChanged(sender, e)
    End Sub

    Public Sub DropDownList2_OnPreRender(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not IsPostBack Then
            RefreshInsertCanUseContractKind(CType(Me.ListView1.InsertItem.FindControl("DropDownList2"), DropDownList).SelectedValue)
        End If
    End Sub

    Public Sub DropDownList2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        RefreshInsertCanUseContractKind(CType(Me.ListView1.InsertItem.FindControl("DropDownList2"), DropDownList).SelectedValue)
        CType(Me.ListView1.InsertItem.FindControl("DropDownList4"), DropDownList).DataBind()
        CType(Me.ListView1.InsertItem.FindControl("DropDownList5"), DropDownList).DataBind()
    End Sub

    Public Sub DropDownList3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(Me.ListView1.InsertItem.FindControl("DropDownList4"), DropDownList).DataBind()
        CType(Me.ListView1.InsertItem.FindControl("DropDownList5"), DropDownList).DataBind()
    End Sub

    Public Sub DropDownList4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(Me.ListView1.InsertItem.FindControl("DropDownList5"), DropDownList).DataBind()
    End Sub

    Public Sub DropDownList5_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim DDL5 As DropDownList = sender
        If DDL5.SelectedIndex >= 0 Then
            Dim BankNumber As String = CType(Me.ListView1.InsertItem.FindControl("DropDownList2"), DropDownList).SelectedValue
            Dim ContractKind As String = CType(Me.ListView1.InsertItem.FindControl("DropDownList3"), DropDownList).SelectedValue
            Dim ContractStartDate As String = CType(Me.ListView1.InsertItem.FindControl("DropDownList4"), DropDownList).SelectedValue
            Dim BorrowID As String = CType(Me.ListView1.InsertItem.FindControl("DropDownList5"), DropDownList).SelectedValue
            Me.NowInsertUseBorrow = (From A In DBDataContext.Borrow Where A.FK_BankNumber = BankNumber And A.FK_ContractKind = ContractKind And A.FK_StartDate = ContractStartDate And A.ID = BorrowID Select A).FirstOrDefault
        Else
            Me.NowInsertUseBorrow = Nothing
        End If
    End Sub

    Protected Sub ldsSubLCBorrowContract_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSubLCBorrowContract.Selecting
        If CType(Me.ListView1.InsertItem.FindControl("DropDownList2"), DropDownList).Items.Count = 0 Then
            RefreshInsertCanUseContractKind(CType(Me.ListView1.InsertItem.FindControl("DropDownList2"), DropDownList).SelectedValue)
        End If
        Dim FindBankNumber As String = CType(Me.ListView1.InsertItem.FindControl("DropDownList2"), DropDownList).SelectedValue
        Dim FindContrackKind As String = CType(Me.ListView1.InsertItem.FindControl("DropDownList3"), DropDownList).SelectedValue
        e.Result = From A In DBDataContext.BorrowContract Where A.BankNumber = FindBankNumber And A.ContractKind = FindContrackKind Select A
    End Sub

    Protected Sub ldsSubBorrow_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSubBorrow.Selecting
        If String.IsNullOrEmpty(CType(Me.ListView1.InsertItem.FindControl("DropDownList4"), DropDownList).SelectedValue) Then
            e.Cancel = True
            Exit Sub
        End If
        Dim FindBankNumber As String = CType(Me.ListView1.InsertItem.FindControl("DropDownList2"), DropDownList).SelectedValue
        Dim FindContractKind As String = CType(Me.ListView1.InsertItem.FindControl("DropDownList3"), DropDownList).SelectedValue
        Dim FindContractStartDate As Date = CType(Me.ListView1.InsertItem.FindControl("DropDownList4"), DropDownList).SelectedValue
        e.Result = From A In DBDataContext.Borrow Where A.FK_BankNumber = FindBankNumber And A.FK_ContractKind = FindContractKind And A.FK_StartDate = FindContractStartDate Select A
    End Sub

    Private Sub ldsSearchResult_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceInsertEventArgs) Handles ldsSearchResult.Inserting
        Dim InsertData As CompanyLINQDB.BorrowPayMoney = e.NewObject
        InsertData.FK_BankNumber = CType(Me.ListView1.InsertItem.FindControl("DropDownList2"), DropDownList).SelectedValue
        InsertData.FK_ContractKind = CType(Me.ListView1.InsertItem.FindControl("DropDownList3"), DropDownList).SelectedValue
        InsertData.FK_StartDate = CType(Me.ListView1.InsertItem.FindControl("DropDownList4"), DropDownList).SelectedValue
        InsertData.FK_BorrowID = CType(Me.ListView1.InsertItem.FindControl("DropDownList5"), DropDownList).SelectedValue
        InsertData.PayMoneyTool = CType(Me.ListView1.InsertItem.FindControl("PayMoneyToolDropDownList"), DropDownList).SelectedValue
        InsertData.PayBankNumber = CType(Me.ListView1.InsertItem.FindControl("PayBankNumberDropDownList"), DropDownList).SelectedValue
        InsertData.ID = InsertData.GetNextCanUseID
    End Sub

    Protected Sub btnClearSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearSearch.Click
        DropDownList1.SelectedIndex = 0
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox3.Checked = False
        tbsFK_StartDate1.Text = Now.Date.AddYears(-3)
        tbsFK_StartDate2.Text = Now.Date
        tbsFK_BorrowStartDate1.Text = New DateTime(Now.Year, 1, 1)
        tbsFK_BorrowStartDate2.Text = New DateTime(Now.Year, 12, 31)
        tbsPayMoneyDate1.Text = tbsFK_BorrowStartDate1.Text
        tbsPayMoneyDate2.Text = tbsFK_BorrowStartDate2.Text
        IsUserAlreadyPutSearch = False
    End Sub

    Protected Sub ldsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSearchResult.Selecting
        If IsUserAlreadyPutSearch = False Then
            e.Result = New List(Of CompanyLINQDB.BorrowPayMoney)
            Exit Sub
        End If

        Dim Result As IQueryable(Of CompanyLINQDB.BorrowPayMoney) = From A In DBDataContext.BorrowPayMoney Select A
        If DropDownList1.SelectedValue <> "ALL" Then
            Result = From A In DBDataContext.BorrowPayMoney Where A.FK_BankNumber = DropDownList1.SelectedValue Select A
        End If
        If DropDownList2.SelectedValue <> "ALL" Then
            Result = From A In DBDataContext.BorrowPayMoney Where A.FK_ContractKind = DropDownList2.SelectedValue Select A
        End If
        If CheckBox1.Checked Then
            Result = From A In Result Where A.FK_StartDate >= CType(tbsFK_StartDate1.Text, DateTime) And A.FK_StartDate <= CType(tbsFK_StartDate2.Text, DateTime) Select A
        End If
        If CheckBox2.Checked Then
            Dim BorrowIDs As List(Of Integer) = (From A In DBDataContext.Borrow Where A.BorrowStartDate >= CType(tbsFK_BorrowStartDate1.Text, DateTime) And A.BorrowEndDate <= CType(tbsFK_BorrowStartDate2.Text, DateTime) Select A.ID).ToList
            Result = From A In Result Where BorrowIDs.Contains(A.ID) Select A
        End If
        If CheckBox3.Checked Then
            Result = From A In Result Where A.PayMoneyDate >= CType(tbsPayMoneyDate1.Text, DateTime) And A.PayMoneyDate <= CType(tbsPayMoneyDate2.Text, DateTime) Select A
        End If
        e.Result = Result
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        ListView1.DataBind()
        CType(Me.ListView1.InsertItem.FindControl("DropDownList2"), DropDownList).DataBind()
        RefreshInsertCanUseContractKind(CType(Me.ListView1.InsertItem.FindControl("DropDownList2"), DropDownList).SelectedValue)
    End Sub

End Class