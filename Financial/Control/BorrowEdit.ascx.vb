Partial Public Class BorrowEdit
    Inherits System.Web.UI.UserControl

    Dim DBDataContext As New CompanyLINQDB.FincialDataContext

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
#Region "使用者是否已按下查詢 屬性:IsUserAlreadyPutSearch1"

    ''' <summary>
    ''' 使用者是否已按下查詢
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsUserAlreadyPutSearch1() As Boolean
        Get
            If IsNothing(Me.ViewState("_IsUserAlreadyPutSearch1")) Then
                Return False
            End If
            Return Me.ViewState("_IsUserAlreadyPutSearch1")
        End Get
        Set(ByVal value As Boolean)
            Me.ViewState("_IsUserAlreadyPutSearch1") = value
        End Set
    End Property
#End Region

#Region "準備借款名單類別 屬性:PrepareBorrowItemClass"
    <Serializable()> _
    Public Class PrepareBorrowItemClass

        Sub New()

        End Sub

        Sub New(ByVal SetBankNumber As String, ByVal SetConractKind As String, ByVal SetStartDate As DateTime)
            Me.BankNumber = SetBankNumber
            Me.ContractKind = SetConractKind
            Me.ContractStartDate = SetStartDate

            Me.BorrowStartDate = Now.Date
            If Not IsNothing(About_BorrowContract) Then
                Me.BorrowEndDate = Me.BorrowStartDate.AddMonths(About_BorrowContract.RepaymentMonths)
                Me.ExchangeRate = About_BorrowContract.NTExchangeRate
            End If
        End Sub

#Region "銀行編號 屬性BankNumber"
        Private _BankNumber As String
        Public Property BankNumber() As String
            Get
                Return _BankNumber
            End Get
            Set(ByVal value As String)
                _BankNumber = value
            End Set
        End Property

#End Region
#Region "合約種類 屬性:ContractKind"

        Private _ContractKind As String
        Public Property ContractKind() As String
            Get
                Return _ContractKind
            End Get
            Set(ByVal value As String)
                _ContractKind = value
            End Set
        End Property
#End Region
#Region "合約啟始日 屬性:ContractStartDate"

        Private _ContractStartDate As DateTime
        Public Property ContractStartDate() As DateTime
            Get
                Return _ContractStartDate
            End Get
            Set(ByVal value As DateTime)
                _ContractStartDate = value
            End Set
        End Property

#End Region



#Region "銀行名稱 屬性:BankName"
        ''' <summary>
        ''' 銀行名稱
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property BankName() As String
            Get
                If IsNothing(Me.About_BorrowContract) Then
                    Return Nothing
                End If
                Return About_BorrowContract.BankName
            End Get
        End Property

        'Private _BankName As String
        'Public Property BankName() As String
        '    Get
        '        Return _BankName
        '    End Get
        '    Set(ByVal value As String)
        '        _BankName = value
        '    End Set
        'End Property

#End Region
#Region "合約種類別稱  屬性:ContractKindName"
        ''' <summary>
        ''' 合約種類別稱
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property ContractKindName() As String
            Get
                If IsNothing(Me.About_BorrowContract) Then
                    Return Nothing
                End If
                Return About_BorrowContract.ContractKindName
            End Get
        End Property

        'Private _ContractKindName As String
        'Public Property ContractKindName() As String
        '    Get
        '        Return _ContractKindName
        '    End Get
        '    Set(ByVal value As String)
        '        _ContractKindName = value
        '    End Set
        'End Property

#End Region
#Region "預備借款金額 屬性:PrepareBorrowMoney"

        Private _PrepareBorrowMoney As Double
        ''' <summary>
        ''' 預備借款金額
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PrepareBorrowMoney() As Double
            Get
                Return _PrepareBorrowMoney
            End Get
            Set(ByVal value As Double)
                _PrepareBorrowMoney = value
            End Set
        End Property

#End Region
#Region "預備借款台幣金額 屬性:PrePareBorrowNTMoney"
        ''' <summary>
        ''' 預備借款台幣金額
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property PrePareBorrowNTMoney() As Double
            Get
                Return Me.PrepareBorrowMoney * Me.ExchangeRate
            End Get
        End Property
#End Region
#Region "預備借款幣別名稱 屬性:CreditMoneyName"
        ''' <summary>
        ''' 預備借款幣別名稱
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property CreditMoneyName() As String
            Get
                If IsNothing(Me.About_BorrowContract) Then
                    Return Nothing
                End If
                Return Me.About_BorrowContract.CreditMoneyName
            End Get
        End Property

        'Private _CreditMoneyName As String
        'Public Property CreditMoneyName() As String
        '    Get
        '        Return _CreditMoneyName
        '    End Get
        '    Set(ByVal value As String)
        '        _CreditMoneyName = value
        '    End Set
        'End Property

#End Region
#Region "現在借利率 屬性:NowBorrowRate"
        Private _NowBorrowRate As Single = -1
        ''' <summary>
        ''' 現在借利率
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property NowBorrowRate() As Single
            Get
                If _NowBorrowRate >= 0 Then
                    Return _NowBorrowRate
                End If
                If IsNothing(Me.About_BorrowContract) Then
                    Return Nothing
                End If
                _NowBorrowRate = Me.About_BorrowContract.ContractRate
                Return _NowBorrowRate
            End Get
            Set(ByVal value As Single)
                _NowBorrowRate = value
            End Set
        End Property

#End Region
#Region "開狀LC編號 屬性:LCNumber"
        Private _LCNumber As String
        ''' <summary>
        ''' 開狀LC編號
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property LCNumber() As String
            Get
                Return _LCNumber
            End Get
            Set(ByVal value As String)
                _LCNumber = value
            End Set
        End Property

#End Region
#Region "匯率 屬性:ExchangeRate"

        Private _ExchangeRate As Single
        ''' <summary>
        ''' 匯率
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ExchangeRate() As Single
            Get
                Return _ExchangeRate
            End Get
            Set(ByVal value As Single)
                _ExchangeRate = value
            End Set
        End Property

#End Region
#Region "LC案號 屬性:LCCaseNumber"

        Private _LCCaseNumber As String
        ''' <summary>
        ''' LC案號
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property LCCaseNumber() As String
            Get
                Return _LCCaseNumber
            End Get
            Set(ByVal value As String)
                _LCCaseNumber = value
            End Set
        End Property

#End Region
#Region "借款啟始日 屬性:BorrowStartDate"

        Private _BorrowStartDate As DateTime
        ''' <summary>
        ''' 借款啟始日
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BorrowStartDate() As DateTime
            Get
                Return _BorrowStartDate
            End Get
            Set(ByVal value As DateTime)
                _BorrowStartDate = value
            End Set
        End Property

#End Region
#Region "借款到期日 屬性:BorrowEndDate"

        Private _BorrowEndDate As DateTime
        ''' <summary>
        ''' 借款到期日
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BorrowEndDate() As DateTime
            Get
                Return _BorrowEndDate
            End Get
            Set(ByVal value As DateTime)
                _BorrowEndDate = value
            End Set
        End Property

#End Region
#Region "寬緩月數 屬性:LatePayMonths"

        Private _LatePayMonths As Integer
        ''' <summary>
        ''' 寬緩月數
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property LatePayMonths() As Integer
            Get
                Return _LatePayMonths
            End Get
            Set(ByVal value As Integer)
                _LatePayMonths = value
            End Set
        End Property


#End Region
#Region "還款期數 屬性:RePaymentTimes"

        Private _RePaymentTimes As Integer
        ''' <summary>
        ''' 還款期數
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RePaymentTimes() As Integer
            Get
                Return _RePaymentTimes
            End Get
            Set(ByVal value As Integer)
                _RePaymentTimes = value
            End Set
        End Property

#End Region
#Region "存入帳號(還款帳號) 屬性:RePaymentBankNumber"

        Private _RePaymentBankNumber As String
        ''' <summary>
        ''' 存入帳號(還款帳號)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RePaymentBankNumber() As String
            Get
                Return _RePaymentBankNumber
            End Get
            Set(ByVal value As String)
                _RePaymentBankNumber = value
            End Set
        End Property

#End Region
#Region "付息方式 屬性:PayRateKind"

        Private _PayRateKind As Integer
        ''' <summary>
        ''' 付息方式(1.月2.日(算頭不算尾)3.日(頭尾都算)4.借款時付息5.到期一次付息)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PayRateKind() As Integer
            Get
                Return _PayRateKind
            End Get
            Set(ByVal value As Integer)
                _PayRateKind = value
            End Set
        End Property

#End Region
#Region "每月付息日 屬性:PayRateMoneyDayNumber"

        Private _PayRateMoneyDayNumber As Integer
        ''' <summary>
        ''' 每月付息日
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PayRateMoneyDayNumber() As Integer
            Get
                Return _PayRateMoneyDayNumber
            End Get
            Set(ByVal value As Integer)
                _PayRateMoneyDayNumber = value
            End Set
        End Property

#End Region
#Region "還本日 屬性:PayPrincipalMoneyDayNumber"

        Private _PayPrincipalMoneyDayNumber As Integer
        ''' <summary>
        ''' 還本日
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PayPrincipalMoneyDayNumber() As Integer
            Get
                Return _PayPrincipalMoneyDayNumber
            End Get
            Set(ByVal value As Integer)
                _PayPrincipalMoneyDayNumber = value
            End Set
        End Property

#End Region
#Region "備註1 屬性:Memo1"

        Private _Memo1 As String
        ''' <summary>
        ''' 備註1
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Memo1() As String
            Get
                Return _Memo1
            End Get
            Set(ByVal value As String)
                _Memo1 = value
            End Set
        End Property

#End Region
#Region "付息金額 屬性:PayRateMoney"

        Private _PayRateMoney As Double
        ''' <summary>
        ''' 付息金額
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PayRateMoney() As Double
            Get
                Return _PayRateMoney
            End Get
            Set(ByVal value As Double)
                _PayRateMoney = value
            End Set
        End Property

#End Region

#Region "是否為LC開狀 屬性:IsLCCreate"
        ''' <summary>
        ''' 是否為LC開狀
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property IsLCCreate() As Boolean
            Get
                If IsNothing(Me.About_BorrowContract) Then
                    Return Nothing
                End If
                Return About_BorrowContract.IsLCCreate
            End Get
        End Property
#End Region
#Region "是否為外幣 屬性:IsForeignMoneyKind"
        ''' <summary>
        ''' 是否為外幣
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property IsForeignMoneyKind() As Boolean
            Get
                If IsNothing(Me.About_BorrowContract) Then
                    Return Nothing
                End If
                Return About_BorrowContract.IsForeignMoneyKind
            End Get
        End Property
#End Region

#Region "相關借款合約 屬性:About_BorrowContract"
        <NonSerialized()> Private _About_BorrowContract As CompanyLINQDB.BorrowContract = Nothing
        ''' <summary>
        ''' 相關借款合約
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property About_BorrowContract() As CompanyLINQDB.BorrowContract
            Get
                If IsNothing(_About_BorrowContract) Then
                    Dim DBDataContext As New CompanyLINQDB.FincialDataContext
                    _About_BorrowContract = (From A In DBDataContext.BorrowContract Where A.BankNumber = Me.BankNumber And A.ContractKind = Me.ContractKind And A.StartDate = Me.ContractStartDate Select A).FirstOrDefault
                End If
                Return _About_BorrowContract
            End Get
        End Property
#End Region

#Region "產生一筆新借款/開狀記錄 方法:CreateNewBorrowData"
        ''' <summary>
        ''' 產生一筆新借款/開狀記錄 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CreateNewBorrowData() As CompanyLINQDB.Borrow
            Dim ReturnValue As New CompanyLINQDB.Borrow
            With ReturnValue
                .FK_BankNumber = BankNumber
                .FK_ContractKind = ContractKind
                .FK_StartDate = ContractStartDate
                .ID = .GetNextCanUseID
                .BorrowMoney = PrepareBorrowMoney
                .BorrowStartDate = BorrowStartDate
                .BorrowEndDate = BorrowEndDate
                .BorrowRate = NowBorrowRate
                .LCNumber = LCNumber
                .ExchangeRate = ExchangeRate
                .LCCaseNumber = LCCaseNumber
                .ProcessEmployee = WebAppAuthority.CurrentWindowsLoginEmployeeNumber
                .LatePayMonths = LatePayMonths
                .RePaymentTimes = RePaymentTimes
                .RePaymentBankNumber = RePaymentBankNumber
                .PayRateKind = PayRateKind
                .PayRateMoneyDayNumber = PayRateMoneyDayNumber
                .PayPrincipalMoneyDayNumber = PayPrincipalMoneyDayNumber
                .Memo1 = Memo1
                .PayRateMoney = PayRateMoney
            End With
            Return ReturnValue
        End Function
#End Region


    End Class
#End Region
#Region "由此控制項產生一筆預備借款名單 方法:CreateNewPrepareBorrowItem"
    ''' <summary>
    ''' 由此控制項產生一筆預備借款名單
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateNewPrepareBorrowItem() As PrepareBorrowItemClass
        Dim ReturnValue As New PrepareBorrowItemClass(GridView1.SelectedDataKey.Values("BankNumber"), GridView1.SelectedDataKey.Values("ContractKind"), CType(GridView1.SelectedDataKey.Values("StartDate"), DateTime))
        With ReturnValue
            .PrepareBorrowMoney = CType(tbPreSetBorrowMoney.Text, Double)
            If String.IsNullOrEmpty(tbPreSetBorrowRate.Text) Then
                .NowBorrowRate = Nothing
            Else
                .NowBorrowRate = CType(tbPreSetBorrowRate.Text, Single)
            End If
            .ExchangeRate = CType(tbPreSetExchangeRage.Text, Single)
            .LCNumber = tbPreSetLCNumber.Text
            .LCCaseNumber = tbPreSetLCCaseNumber.Text
            .BorrowStartDate = tbPreSetStartDate.Text
            .BorrowEndDate = tbPreSetEndDate.Text
            .LatePayMonths = tbPreSetLatePayMonths.Text
            .RePaymentTimes = tbPreSetRePaymentTimes.Text
            .RePaymentBankNumber = ddlPreSetRePaymentBankNumber.SelectedValue
            .PayRateKind = ddlPreSetPayRateKind.SelectedValue
            .PayRateMoneyDayNumber = btPreSetPayRateMoneyDayNumber.Text
            .PayPrincipalMoneyDayNumber = btPreSetPayPrincipalMoneyDayNumber.Text
            .Memo1 = tbPreSetMemo1.Text
            .PayRateMoney = CType(btPreSetPayRateMoney.Text, Double)
        End With
        Return ReturnValue
    End Function
#End Region

#Region "準備借款名單 屬性:PrepareBorrowItem"
    ''' <summary>
    ''' 準備借款名單
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PrepareBorrowItem() As List(Of PrepareBorrowItemClass)
        Get
            If IsNothing(Me.Page) Then
                Return Nothing
            End If
            If IsNothing(Me.Session("_PrepareBorrowItem")) Then
                Me.Session("_PrepareBorrowItem") = New List(Of PrepareBorrowItemClass)
            End If
            Return Me.Session("_PrepareBorrowItem")

        End Get
        Set(ByVal value As List(Of PrepareBorrowItemClass))
            Me.Session("_PrepareBorrowItem") = value
        End Set
    End Property

#End Region
#Region "準備借款名單顯示 方法:DisplayPrepareBorrorItems"
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function DisplayPrepareBorrorItems(ByVal SourceBorrowItem As List(Of PrepareBorrowItemClass)) As List(Of PrepareBorrowItemClass)
        Return SourceBorrowItem
    End Function
#End Region

#Region "現在選擇之借款合約 屬性:CurrentSelectBorrowContract"
    ''' <summary>
    ''' 現在選擇之借款合約
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CurrentSelectBorrowContract() As CompanyLINQDB.BorrowContract
        Get
            Return Me.Session.Item("_CurrentSelectBorrowContract")
        End Get
        Set(ByVal value As CompanyLINQDB.BorrowContract)
            Me.Session.Item("_CurrentSelectBorrowContract") = value
            SetControlValue()
        End Set
    End Property

    Private Sub SetControlValue()
        Dim SelectBorrowContract As CompanyLINQDB.BorrowContract = CurrentSelectBorrowContract
        If IsNothing(SelectBorrowContract) Then
            Exit Sub
        End If
        Me.tbPreSetBorrowMoney.Text = SelectBorrowContract.SubBorrowContractCanUseMoneyByOrderAndFilder
        Me.lbMaxCanUseMoney.Text = SelectBorrowContract.CanUseMoney
        Me.lbPreSetBorrowMoneyKindName.Text = SelectBorrowContract.CreditMoneyName
        Me.lbPreSetBorrowMoneyKindName0.Text = Me.lbPreSetBorrowMoneyKindName.Text
        Me.tbPreSetBorrowRate.Text = Nothing
        Me.tbPreSetLCNumber.Text = Nothing
        Me.tbPreSetLCCaseNumber.Text = Nothing
        Me.tbPreSetLatePayMonths.Text = SelectBorrowContract.LatePayMonths
        Me.tbPreSetStartDate.Text = Format(Now.Date, "yyyy/MM/dd")
        Me.tbPreSetEndDate.Text = Format(Now.AddMonths(SelectBorrowContract.RepaymentMonths).Date, "yyyy/MM/dd")
        Me.tbPreSetRePaymentTimes.Text = SelectBorrowContract.RePaymentTimes
        Me.ddlPreSetRePaymentBankNumber.SelectedValue = SelectBorrowContract.RePaymentBankNumber
        Me.ddlPreSetPayRateKind.SelectedValue = SelectBorrowContract.PayRateKind
        Me.btPreSetPayRateMoneyDayNumber.Text = SelectBorrowContract.PayRateMoneyDayNumber
        Me.tbPreSetMemo1.Text = SelectBorrowContract.Memo1
        Me.tbPreSetLCNumber.Visible = SelectBorrowContract.IsLCCreate
        Me.tbPreSetLCCaseNumber.Visible = SelectBorrowContract.IsLCCreate
        Me.btPreSetPayRateMoney.Text = 0
        Me.btPreSetPayPrincipalMoneyDayNumber.Text = "1"
        Me.Panel3.Enabled = False


        If SelectBorrowContract.IsForeignMoneyKind Then
            tbPreSetExchangeRage.Text = SelectBorrowContract.NTExchangeRate
            tbPreSetExchangeRage.Enabled = True
        Else
            tbPreSetExchangeRage.Text = 1
            tbPreSetExchangeRage.Enabled = False
        End If


    End Sub
#End Region
#Region "驗證編輯借款資料更新前是否正確並傳回錯誤訊息 方法:ValidatorBorrowEditAndGetErrorMsg"
    ''' <summary>
    ''' 驗證編輯借款資料更新前是否正確並傳回錯誤訊息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ValidatorBorrowEditAndGetErrorMsg()
        Dim ReturnValue As String = Nothing
        Dim TestObject As New CompanyLINQDB.Borrow
        With TestObject
            .FK_BankNumber = CType(ListView1.EditItem.FindControl("FK_BankNumberLabel1"), Label).Text
            .FK_ContractKind = CType(ListView1.EditItem.FindControl("HFFK_ContractKind"), HiddenField).Value
            .FK_StartDate = CType(ListView1.EditItem.FindControl("FK_StartDateLabel1"), Label).Text
            .ID = CType(ListView1.EditItem.FindControl("HFID"), HiddenField).Value
            .BorrowStartDate = CType(ListView1.EditItem.FindControl("BorrowStartDateTextBox"), TextBox).Text
            .BorrowEndDate = CType(ListView1.EditItem.FindControl("BorrowEndDateTextBox"), TextBox).Text
            .BorrowMoney = CType(ListView1.EditItem.FindControl("BorrowMoneyTextBox"), TextBox).Text
            .BorrowRate = CType(ListView1.EditItem.FindControl("BorrowRateTextBox"), TextBox).Text
            .ExchangeRate = CType(ListView1.EditItem.FindControl("ExchangeRateTextBox"), TextBox).Text
            .LCNumber = CType(ListView1.EditItem.FindControl("LCNumberTextBox"), TextBox).Text
            .LCCaseNumber = CType(ListView1.EditItem.FindControl("LCCaseNumberTextBox"), TextBox).Text
            .LatePayMonths = CType(ListView1.EditItem.FindControl("LatePayMonthsTextBox"), TextBox).Text
            .RePaymentTimes = CType(ListView1.EditItem.FindControl("RePaymentTimesTextBox"), TextBox).Text
            .RePaymentBankNumber = CType(ListView1.EditItem.FindControl("ddlPreSetRePaymentBankNumber"), DropDownList).SelectedValue
            .PayRateKind = CType(ListView1.EditItem.FindControl("ddlPayRateKind"), DropDownList).SelectedValue
            .PayRateMoneyDayNumber = CType(ListView1.EditItem.FindControl("PayRateMoneyDayNumberTextBox"), TextBox).Text
            .PayPrincipalMoneyDayNumber = CType(ListView1.EditItem.FindControl("PayPrincipalMoneyDayNumberTextBox"), TextBox).Text
        End With
        Return CompanyLINQDB.Borrow.GetCheckDataError(TestObject, CompanyLINQDB.CheckDataErrorMode.EditMode)
    End Function
#End Region



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            TextBox2.Text = Now.Date.AddDays(-3)
            TextBox3.Text = Now.Date
            CheckBoxList2.Items(0).Selected = True
        End If
    End Sub

    Protected Sub LDSSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSSearchResult.Selecting
        If IsUserAlreadyPutSearch = False OrElse MultiView1.ActiveViewIndex <> 0 Then
            e.Cancel = True
            Exit Sub
        End If

        Dim Result As IQueryable(Of CompanyLINQDB.BorrowContract) = From A In DBDataContext.BorrowContract Select A
        Result = IIf(DropDownList1.SelectedValue = "ALL", Result, From A In Result Where A.BankNumber = DropDownList1.SelectedValue Select A)

        Dim SubResult1 As List(Of CompanyLINQDB.BorrowContract) = (From A In Result Where (A.IsHaveParentBorrowContract = False Or A.IsHaveParentBorrowContract Is Nothing) And A.ContractKind <> "99" Select A).ToList
        Dim SubResult2 As New List(Of CompanyLINQDB.BorrowContract)
        Dim QuatoList As New List(Of String)
        For Each EachItem As ListItem In ListBox2.Items
            QuatoList.Add(EachItem.Value)
        Next
        For Each EachItem As CompanyLINQDB.BorrowContract In From A In Result Where A.ContractKind = "99" Select A
            SubResult2.AddRange(EachItem.GetSubContractCanUseMoneyByOrderAndFilder(QuatoList))
        Next


        If CheckBoxList2.Items(0).Selected = False Then
            Dim SelectValues As List(Of String) = New List(Of String)
            For Each EachItem As ListItem In CheckBoxList2.Items
                If EachItem.Selected Then
                    SelectValues.Add(EachItem.Value)
                End If
            Next
            If SelectValues.Count > 0 Then
                SubResult1 = (From A In SubResult1 Where SelectValues.Contains(A.ContractKind) Select A).ToList
                SubResult2 = (From A In SubResult2 Where SelectValues.Contains(A.ContractKind) Select A).ToList
            End If
        End If



        Dim FinalResult As List(Of CompanyLINQDB.BorrowContract) = Nothing
        If CType(tbSearchMaxNTDollar.Text, Double) > 0 Then
            FinalResult = (From A In SubResult1.Union(SubResult2) Where A.SubBorrowContractCanUseMoneyByOrderAndFilder >= CType(tbSearchMaxNTDollar.Text, Double) Select A Order By A.ContractRate).ToList
        Else
            FinalResult = (From A In SubResult1.Union(SubResult2) Select A).ToList
        End If

        If RadioButtonList1.SelectedValue = "0" Then
            FinalResult = (From A In FinalResult Where Now >= A.StartDate And Now < A.EndDate.AddDays(1) Select A).ToList
        End If
        e.Result = FinalResult
        lbSumBankCount.Text = 0
        lbSumCanBorrowMoney.Text = 0
        lbAvgContractRate.Text = 0.0
        If FinalResult.Count > 0 Then
            lbSumBankCount.Text = (From A In FinalResult Select A.BankNumber Distinct).Count
            lbSumCanBorrowMoney.Text = Format((From A In FinalResult Select A.CanUseNTMoney).Sum, "###,###,###,###")
            lbAvgContractRate.Text = (From A In FinalResult Select A.ContractRate).Sum / FinalResult.Count
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Me.IsUserAlreadyPutSearch = True
        TabContainer2.ActiveTab = Me.TabPanel21
        Me.MultiView1.SetActiveView(View1)
        GridView1.DataBind()
    End Sub

    Protected Sub btnClearSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearSearch.Click
        For Each EachItem As ListItem In CheckBoxList2.Items
            EachItem.Selected = False
        Next
        CheckBoxList2.Items(0).Selected = True
        DropDownList1.SelectedIndex = 0
        IsUserAlreadyPutSearch = False
    End Sub


    Protected Sub btnUpQuatoPriority_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpQuatoPriority.Click
        If ListBox2.SelectedIndex <= 0 Then
            Exit Sub
        End If
        Dim ToMoveIndex As Integer = ListBox2.SelectedIndex - 1
        Dim GetMoveItem As ListItem = ListBox2.SelectedItem
        Dim AfterChangeList As New List(Of ListItem)
        For AddItemIndex As Integer = 0 To ListBox2.Items.Count - 1
            Select Case True
                Case AddItemIndex = ListBox2.SelectedIndex
                Case AddItemIndex = ToMoveIndex
                    AfterChangeList.Add(GetMoveItem)
                    AfterChangeList.Add(ListBox2.Items(ToMoveIndex))
                Case Else
                    AfterChangeList.Add(ListBox2.Items(AddItemIndex))
            End Select
        Next
        ListBox2.Items.Clear()
        ListBox2.Items.AddRange(AfterChangeList.ToArray)
    End Sub

    Protected Sub btnDownQuatoPriority_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDownQuatoPriority.Click
        If ListBox2.SelectedIndex >= ListBox2.Items.Count - 1 Then
            Exit Sub
        End If
        Dim ToMoveIndex As Integer = ListBox2.SelectedIndex + 1
        Dim GetMoveItem As ListItem = ListBox2.SelectedItem
        Dim AfterChangeList As New List(Of ListItem)
        For AddItemIndex As Integer = 0 To ListBox2.Items.Count - 1
            Select Case True
                Case AddItemIndex = ToMoveIndex
                Case AddItemIndex = ListBox2.SelectedIndex
                    AfterChangeList.Add(ListBox2.Items(ToMoveIndex))
                    AfterChangeList.Add(GetMoveItem)
                Case Else
                    AfterChangeList.Add(ListBox2.Items(AddItemIndex))
            End Select
        Next
        ListBox2.Items.Clear()
        ListBox2.Items.AddRange(AfterChangeList.ToArray)
    End Sub

    Private Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Me.CurrentSelectBorrowContract = (From A In DBDataContext.BorrowContract Where A.BankNumber = CType(GridView1.SelectedDataKey.Values("BankNumber"), String) And A.ContractKind = CType(GridView1.SelectedDataKey.Values("ContractKind"), String) And A.StartDate = CType(GridView1.SelectedDataKey.Values("StartDate"), DateTime) Select A).FirstOrDefault
        Me.MultiView1.SetActiveView(View2)
    End Sub

    Protected Sub btnDesignBorrow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDesignBorrow.Click
        For Each EachItem As PrepareBorrowItemClass In Me.PrepareBorrowItem
            Me.DBDataContext.Borrow.InsertOnSubmit(EachItem.CreateNewBorrowData)
        Next
        Me.DBDataContext.SubmitChanges()
        Me.PrepareBorrowItem.Clear()
        IsUserAlreadyPutSearch = False
        GridView1.DataBind()
    End Sub

    Private Sub TabContainer2_ActiveTabChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabContainer2.ActiveTabChanged
        Select Case True
            Case TabContainer2.ActiveTab Is TabPanel23
                Me.GridView2.DataBind()
                lbBankTotalCount.Text = (From A In Me.PrepareBorrowItem Select A.BankNumber Distinct).Count
                lbTotalPreBorrowMoney.Text = Format((From A In Me.PrepareBorrowItem Select A.PrePareBorrowNTMoney).Sum, "###,###,###,###")
            Case TabContainer2.ActiveTab Is TabPanel24
                ListView1.DataBind()
        End Select
    End Sub

    Private Sub GridView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.SelectedIndexChanged
        Dim WillRemoveItem As PrepareBorrowItemClass = (From A In Me.PrepareBorrowItem Where A.ContractKind = GridView2.SelectedDataKey.Values("ContractKind") And A.BankNumber = GridView2.SelectedDataKey.Values("BankNumber") And A.ContractStartDate = GridView2.SelectedDataKey.Values("ContractStartDate") Select A).FirstOrDefault
        If Not IsNothing(WillRemoveItem) Then
            PrepareBorrowItem.Remove(WillRemoveItem)
        End If
        lbTotalPreBorrowMoney.Text = Format((From A In Me.PrepareBorrowItem Select A.PrePareBorrowNTMoney).Sum, "###,###,###,###")
    End Sub

    Protected Sub btnClearPreBorrowItems_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearPreBorrowItems.Click
        Me.PrepareBorrowItem.Clear()
    End Sub

    Protected Sub ldsHistorySearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsHistorySearchResult.Selecting
        If IsUserAlreadyPutSearch1 = False Then
            e.Cancel = True
            Exit Sub
        End If
        Dim Result As IQueryable(Of CompanyLINQDB.Borrow) = From A In DBDataContext.Borrow Where A.BorrowStartDate >= CType(TextBox2.Text, DateTime) And A.BorrowStartDate <= CType(TextBox3.Text, DateTime) Select A
        Result = IIf(DropDownList2.SelectedValue = "ALL", Result, From A In Result Where A.FK_BankNumber = DropDownList2.SelectedValue Select A)
        e.Result = Result
    End Sub

    Protected Sub btnSearchHistory_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchHistory.Click
        Me.IsUserAlreadyPutSearch1 = True
        ListView1.DataBind()
    End Sub

    Protected Sub btnClearHistorySearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearHistorySearch.Click
        TextBox2.Text = Now.Date.AddDays(-3)
        TextBox3.Text = Now.Date
        IsUserAlreadyPutSearch1 = False
    End Sub

    Protected Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Dim SourceControl As CustomValidator = source
        Dim ErrorMsg As String = ValidatorBorrowEditAndGetErrorMsg()
        SourceControl.Text = Nothing
        If Not IsNothing(ErrorMsg) Then
            SourceControl.Text = ErrorMsg
            args.IsValid = False
        End If
    End Sub

    Protected Sub btnAddPreBorrowMenu_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddPreBorrowMenu.Click
        '加入預備借款前測試資料是否有誤
        Dim WillSetItem As PrepareBorrowItemClass = CreateNewPrepareBorrowItem()
        Dim GetErrowMessage As String = CompanyLINQDB.Borrow.GetCheckDataError(WillSetItem.CreateNewBorrowData)
        Me.LBMsg.Visible = Not IsNothing(GetErrowMessage)
        If Not IsNothing(GetErrowMessage) Then
            LBMsg.Text = "資料發生錯誤:" & GetErrowMessage
            Exit Sub
        End If

        Dim FindOldItem As PrepareBorrowItemClass = (From A In Me.PrepareBorrowItem Where A.BankNumber = WillSetItem.BankNumber And A.ContractKind = WillSetItem.ContractKind And A.ContractStartDate = WillSetItem.ContractStartDate Select A).FirstOrDefault
        If Not IsNothing(FindOldItem) Then
            Me.PrepareBorrowItem.Remove(FindOldItem)
        End If
        Me.PrepareBorrowItem.Add(WillSetItem)
        Me.ListView1.DataBind()
        Me.MultiView1.SetActiveView(View1)
    End Sub

    Protected Sub btnCancelPreBorrowMenu_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelPreBorrowMenu.Click
        Me.MultiView1.SetActiveView(View1)
    End Sub

    Private Sub ddlPreSetPayRateKind_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPreSetPayRateKind.SelectedIndexChanged
        Panel3.Enabled = CType(sender, DropDownList).SelectedValue = "4"
    End Sub
End Class