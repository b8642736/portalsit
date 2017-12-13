Partial Public Class BorrowLCBillPayMoneyEdit
    Inherits System.Web.UI.UserControl

    Dim DBDataContext As New CompanyLINQDB.FincialDataContext

#Region "已開狀銀行代碼查詢 方法:SearchBankInfo"
    ''' <summary>
    ''' 已開狀銀行代碼查詢
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
#Region "已開狀銀行代碼查詢1 方法:SearchBankInfo1"
    ''' <summary>
    ''' 已開狀銀行代碼查詢1
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function SearchBankInfo1() As List(Of CompanyORMDB.CASH.CASH05PF)
        Dim HaveLCBorrowBankNumbers As List(Of String) = (From A In DBDataContext.Borrow Where A.FK_ContractKind = "S3" Select A.FK_BankNumber Distinct).ToList
        Dim ReturnValue As List(Of CompanyORMDB.CASH.CASH05PF) = (From A In CompanyORMDB.CASH.CASH05PF.CDBSelect(Of CompanyORMDB.CASH.CASH05PF)("Select * From @#CASH.CASH05PF Order by BANKNM", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC) Where HaveLCBorrowBankNumbers.Contains(A.BANKN1) Select A).ToList
        For Each EachItem As CompanyORMDB.CASH.CASH05PF In ReturnValue
            EachItem.BANKNM = EachItem.BANKN1 & "=>" & EachItem.BANKNM
        Next
        Return ReturnValue
    End Function
#End Region
#Region "已開狀且有效之記錄銀行代碼查詢2 方法:SearchBankInfo2"
    Private _SearchBankInfo2 As List(Of CompanyORMDB.CASH.CASH05PF)
    ''' <summary>
    ''' 已開狀且有效之記錄銀行代碼查詢2
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function SearchBankInfo2() As List(Of CompanyORMDB.CASH.CASH05PF)
        If IsNothing(_SearchBankInfo2) Then
            Dim HaveLCBorrowBankNumbers As List(Of String) = (From A In DBDataContext.Borrow Where A.FK_ContractKind = "S3" And Now.Date >= A.BorrowStartDate And Now.Date <= A.BorrowEndDate Select A.FK_BankNumber Distinct).ToList
            Dim ReturnValue As List(Of CompanyORMDB.CASH.CASH05PF) = (From A In CompanyORMDB.CASH.CASH05PF.CDBSelect(Of CompanyORMDB.CASH.CASH05PF)("Select * From @#CASH.CASH05PF Order by BANKNM", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC) Where HaveLCBorrowBankNumbers.Contains(A.BANKN1) Select A).ToList
            For Each EachItem As CompanyORMDB.CASH.CASH05PF In ReturnValue
                EachItem.BANKNM = EachItem.BANKN1 & "=>" & EachItem.BANKNM
            Next
            _SearchBankInfo2 = ReturnValue
        End If
        Return _SearchBankInfo2
    End Function
#End Region
#Region "現在新增使用LC到單  屬性:NowInsertUseBorrowLCBill"
    ''' <summary>
    ''' 現在新增使用LC到單
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property NowInsertUseBorrowLCBill() As CompanyLINQDB.BorrowLCBill
        Get
            Return Me.Session("_NowInsertUseBorrowLCBill")
        End Get
        Set(ByVal value As CompanyLINQDB.BorrowLCBill)
            Dim OldValue As CompanyLINQDB.BorrowLCBill = Me.Session("_NowInsertUseBorrowLCBill")
            Me.Session("_NowInsertUseBorrowLCBill") = value

            Dim DDL2 As DropDownList = Me.ListView1.InsertItem.FindControl("DropDownList2")
            Dim DDL3 As DropDownList = Me.ListView1.InsertItem.FindControl("DropDownList3")
            Dim DDL4 As DropDownList = Me.ListView1.InsertItem.FindControl("DropDownList4")
            Dim DDL5 As DropDownList = Me.ListView1.InsertItem.FindControl("DropDownList5")
            Dim InsertButton As Button = Me.ListView1.InsertItem.FindControl("InsertButton")

            If Not OldValue Is value Then
                If Not IsNothing(value) Then
                    CType(Me.ListView1.InsertItem.FindControl("PayMoneyDateTextBox"), TextBox).Text = Now.Date
                    CType(Me.ListView1.InsertItem.FindControl("FK_BankNumberLabel"), Label).Text = value.FK_BankNumber

                    CType(Me.ListView1.InsertItem.FindControl("HFFK_BankNumber"), HiddenField).Value = DDL2.SelectedValue
                    CType(Me.ListView1.InsertItem.FindControl("HFFK_ContractKind"), HiddenField).Value = "S3"
                    CType(Me.ListView1.InsertItem.FindControl("HFFK_StartDate"), HiddenField).Value = DDL3.SelectedValue
                    CType(Me.ListView1.InsertItem.FindControl("HFFK_BorrowID"), HiddenField).Value = DDL4.SelectedValue
                    CType(Me.ListView1.InsertItem.FindControl("HFFK_BorrowLCBillID"), HiddenField).Value = DDL5.SelectedValue
                    CType(Me.ListView1.InsertItem.FindControl("PayUseMoneyTextBox"), TextBox).Text = value.WaitPayUseMoney
                    CType(Me.ListView1.InsertItem.FindControl("PayRateMoneyTextBox"), TextBox).Text = Format(value.NextTimePlanPayRateMoney, "#.00")
                    CType(Me.ListView1.InsertItem.FindControl("CreditMoneyNameLabel"), Label).Text = value.CreditMoneyName
                    InsertButton.Enabled = CType(CType(Me.ListView1.InsertItem.FindControl("PayUseMoneyTextBox"), TextBox).Text, Integer) > 0 Or CType(CType(Me.ListView1.InsertItem.FindControl("PayRateMoneyTextBox"), TextBox).Text, Integer) > 0
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
            tbsFK_StartDate1.Text = New DateTime(Now.Year, 1, 1)
            tbsFK_StartDate2.Text = Format(Now.Date, "yyyy/MM/dd")
            tbsFK_BorrowStartDate1.Text = New DateTime(Now.Year, 1, 1)
            tbsFK_BorrowStartDate2.Text = New DateTime(Now.Year, 12, 31)
            tbsBillStartDate1.Text = tbsFK_BorrowStartDate1.Text
            tbsBillStartDate2.Text = tbsFK_BorrowStartDate2.Text
            tbsPayMoneyDate1.Text = New DateTime(Now.Year, 1, 1)
            tbsPayMoneyDate2.Text = Now.Date
        End If

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        Me.ListView1.DataBind()
    End Sub

    Protected Sub btnClearSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearSearch.Click
        If DropDownList1.Items.Count >= 0 Then
            DropDownList1.SelectedIndex = 0
        End If
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        tbLCNumber.Text = Nothing
    End Sub

    Protected Sub ldsSubLCBorrowContract_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSubLCBorrowContract.Selecting
        Dim SenderObject As DropDownList = Me.ListView1.InsertItem.FindControl("DropDownList2")
        If SenderObject.SelectedIndex < 0 Then
            e.Cancel = True
            Exit Sub
        End If
        e.Result = From A In DBDataContext.BorrowContract Where A.BankNumber = SenderObject.SelectedValue And A.ContractKind = "S3" Select A
    End Sub

    Protected Sub ldsSubBorrow_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSubBorrow.Selecting
        Dim SenderObject1 As DropDownList = Me.ListView1.InsertItem.FindControl("DropDownList2")
        Dim SenderObject2 As DropDownList = Me.ListView1.InsertItem.FindControl("DropDownList3")
        If SenderObject1.SelectedIndex < 0 OrElse SenderObject2.SelectedIndex < 0 Then
            e.Cancel = True
            Exit Sub
        End If
        '找尋該銀行所有 已開狀 且有效之記錄
        e.Result = From A In DBDataContext.Borrow Where A.FK_BankNumber = SenderObject1.SelectedValue And A.FK_ContractKind = "S3" And A.FK_StartDate = SenderObject2.SelectedValue And Now.Date >= A.BorrowStartDate And Now.Date <= A.BorrowEndDate Select A
    End Sub

    Protected Sub ldsSubBorrowLCBill_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSubBorrowLCBill.Selecting
        Dim SenderObject1 As DropDownList = Me.ListView1.InsertItem.FindControl("DropDownList2")
        Dim SenderObject2 As DropDownList = Me.ListView1.InsertItem.FindControl("DropDownList3")
        Dim SenderObject3 As DropDownList = Me.ListView1.InsertItem.FindControl("DropDownList4")
        If SenderObject1.SelectedIndex < 0 OrElse SenderObject2.SelectedIndex < 0 OrElse SenderObject3.SelectedIndex < 0 Then
            e.Cancel = True
            Exit Sub
        End If
        '找尋所有 到單 記錄
        e.Result = From A In DBDataContext.BorrowLCBill Where A.FK_BankNumber = SenderObject1.SelectedValue And A.FK_ContractKind = "S3" And A.FK_StartDate = SenderObject2.SelectedValue And A.FK_BorrowID = SenderObject3.SelectedValue Select A
    End Sub


    Public Sub DropDownList2_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim DDL2 As DropDownList = Me.ListView1.InsertItem.FindControl("DropDownList2")
        If DDL2.Items.Count > 0 And DDL2.SelectedIndex < 0 Then
            DDL2.SelectedIndex = 0
        End If
    End Sub
    Public Sub DropDownList3_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim DDL3 As DropDownList = Me.ListView1.InsertItem.FindControl("DropDownList3")
        If DDL3.Items.Count > 0 And DDL3.SelectedIndex < 0 Then
            DDL3.SelectedIndex = 0
        End If
    End Sub

    Public Sub DropDownList4_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim DDL4 As DropDownList = Me.ListView1.InsertItem.FindControl("DropDownList4")
        If DDL4.Items.Count > 0 And DDL4.SelectedIndex < 0 Then
            DDL4.SelectedIndex = 0
        End If

    End Sub

    Public Sub DropDownList5_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim DDL5 As DropDownList = sender
        If DDL5.Items.Count > 0 And DDL5.SelectedIndex < 0 Then
            DDL5.SelectedIndex = 0
        End If

        Call DropDownList5_SelectedIndexChanged(sender, e)
    End Sub

    Public Sub DropDownList2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(Me.ListView1.InsertItem.FindControl("DropDownList3"), DropDownList).DataBind()
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
            Dim ContractStartDate As String = CType(Me.ListView1.InsertItem.FindControl("DropDownList3"), DropDownList).SelectedValue
            Dim BorrowID As String = CType(Me.ListView1.InsertItem.FindControl("DropDownList4"), DropDownList).SelectedValue
            Dim BorrowLCBillID As String = CType(Me.ListView1.InsertItem.FindControl("DropDownList5"), DropDownList).SelectedValue
            Me.NowInsertUseBorrowLCBill = (From A In DBDataContext.BorrowLCBill Where A.FK_BankNumber = BankNumber And A.FK_ContractKind = "S3" And A.FK_StartDate = ContractStartDate And A.FK_BorrowID = BorrowID And A.ID = BorrowLCBillID Select A).FirstOrDefault
        Else
            Me.NowInsertUseBorrowLCBill = Nothing
        End If
    End Sub

    Private Sub ListView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.PreRender
        If Not IsPostBack Or String.IsNullOrEmpty(CType(Me.ListView1.InsertItem.FindControl("PayRateMoneyCritdialDateTextBox"), TextBox).Text) Then
            CType(Me.ListView1.InsertItem.FindControl("PayRateMoneyCritdialDateTextBox"), TextBox).Text = Format(Now.Date, "yyyy/MM/dd")
        End If
    End Sub

    Private Sub ldsSearchResult_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceInsertEventArgs) Handles ldsSearchResult.Inserting
        Dim InsertData As CompanyLINQDB.BorrowLCBillPayMoney = e.NewObject
        InsertData.ID = InsertData.GetNextCanUseID
        InsertData.FK_BorrowLCBillID = Me.NowInsertUseBorrowLCBill.ID
    End Sub

    Protected Sub ldsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSearchResult.Selecting
        If IsUserAlreadyPutSearch = False Then
            e.Result = New List(Of CompanyLINQDB.BorrowLCBillPayMoney)
            Exit Sub
        End If

        Dim Result As IQueryable(Of CompanyLINQDB.BorrowLCBillPayMoney) = From A In DBDataContext.BorrowLCBillPayMoney Select A
        If DropDownList1.SelectedValue <> "ALL" Then
            Result = From A In DBDataContext.BorrowLCBill Where A.FK_BankNumber = DropDownList1.SelectedValue Select A
        End If
        If CheckBox1.Checked Then
            Result = From A In Result Where A.FK_StartDate >= CType(tbsFK_StartDate1.Text, DateTime) And A.FK_StartDate <= CType(tbsFK_StartDate2.Text, DateTime) Select A
        End If
        If CheckBox2.Checked Then
            Dim BorrowIDs As List(Of Integer) = (From A In DBDataContext.Borrow Where A.BorrowStartDate >= CType(tbsFK_BorrowStartDate1.Text, DateTime) And A.BorrowEndDate <= CType(tbsFK_BorrowStartDate2.Text, DateTime) Select A.ID).ToList
            Result = From A In Result Where BorrowIDs.Contains(A.ID) Select A
        End If
        If CheckBox3.Checked Then
            Dim BorrowBillIDs As List(Of Integer) = (From A In DBDataContext.BorrowLCBill Where A.BillStartDate >= CType(tbsBillStartDate1.Text, DateTime) And A.BillEndDate <= CType(tbsBillStartDate2.Text, DateTime) Select A.ID).ToList
            Result = From A In Result Where BorrowBillIDs.Contains(A.ID) Select A
        End If
        If CheckBox4.Checked Then
            Result = From A In Result Where A.PayMoneyDate >= CType(tbsPayMoneyDate1.Text, DateTime) And A.PayMoneyDate <= CType(tbsPayMoneyDate2.Text, DateTime) Select A
        End If

        If Not String.IsNullOrEmpty(tbLCNumber.Text.Trim) Then
            Dim FindBorrow As CompanyLINQDB.Borrow = (From A In DBDataContext.Borrow Where A.LCNumber Like tbLCNumber.Text.Trim & "*" Select A).FirstOrDefault
            If IsNothing(FindBorrow) Then
                e.Result = New List(Of CompanyLINQDB.BorrowLCBillPayMoney)
                Exit Sub
            End If
            e.Result = From A In Result Where A.FK_BorrowID = FindBorrow.ID Select A
        End If
        e.Result = Result

    End Sub
End Class