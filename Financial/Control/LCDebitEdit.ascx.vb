Public Partial Class LCDebitEdit
    Inherits System.Web.UI.UserControl

#Region "信用狀債務查詢 方法:SearchItem"
    ''' <summary>
    ''' 信用狀債務查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SearchItem(ByVal QryString As String) As List(Of CompanyORMDB.DEBSYSLB.LCUSPF)
        Return CompanyORMDB.DEBSYSLB.LCUSPF.CDBSelect(Of CompanyORMDB.DEBSYSLB.LCUSPF)(QryString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    End Function
#End Region
#Region "信用狀債務新增 方法:InsertItem"
    <DataObjectMethod(DataObjectMethodType.Insert)> _
    Public Shared Sub InsertItem(ByVal ItemObject As CompanyORMDB.DEBSYSLB.LCUSPF)
        'ODSMoneyKind
        ItemObject.DEPART = ItemObject.DEPART.Replace("_", Nothing)
        Dim AS400Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        ItemObject.SQLQueryAdapterByThisObject = AS400Adapter
        ItemObject.CDBInsert()
    End Sub
#End Region
#Region "信用狀債務修改 方法:UpdateItem"
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Shared Sub UpdateItem(ByVal ItemObject As CompanyORMDB.DEBSYSLB.LCUSPF)
        Dim AS400Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        ItemObject.SQLQueryAdapterByThisObject = AS400Adapter
        ItemObject.CDBUpdate()
    End Sub
#End Region
#Region "信用狀債務刪除 方法:DeleteItem"
    <DataObjectMethod(DataObjectMethodType.Delete)> _
    Public Shared Sub DeleteItem(ByVal ItemObject As CompanyORMDB.DEBSYSLB.LCUSPF)
        Dim AS400Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        ItemObject.SQLQueryAdapterByThisObject = AS400Adapter
        ItemObject.CDBDelete()
    End Sub

#End Region

#Region "幣別代碼查詢 方法:MoneyKindSearch"
    ''' <summary>
    ''' 幣別代碼查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function MoneyKindSearch() As List(Of CompanyORMDB.DEBSYSLB.DEBKCRPF)
        Static ReturnValue As List(Of CompanyORMDB.DEBSYSLB.DEBKCRPF)
        If IsNothing(ReturnValue) Then
            ReturnValue = CompanyORMDB.DEBSYSLB.DEBKCRPF.CDBSelect(Of CompanyORMDB.DEBSYSLB.DEBKCRPF)("Select * from @#DEBSYSLB.DEBKCRPF Order by CURRNO", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        End If
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

#Region "設定查詢字串至控制項 函式:SetQryStringToControl"
    ''' <summary>
    ''' 設定查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetQryStringToControl()
        'Dim SetValue As String = "Select * from @#DEBSYSLB.LCUSPF Where 1=1 "
        Dim SetValue As String = "Select * from " & (New CompanyORMDB.DEBSYSLB.LCUSPF).CDBFullAS400DBPath & " Where 1=1 "

        If Not String.IsNullOrEmpty(tbLCID.Text) And tbLCID.Text.Trim.Length > 0 Then
            SetValue &= " AND LCUSNO LIKE '" & tbLCID.Text.Trim & "%' "
        End If

        If CheckBox1.Checked Then
            Dim StartDate As Date = tbStartDate1.Text
            Dim EndDate As Date = tbEndDate1.Text
            Dim StartDateString As String = Format(Format(StartDate, "yyyy") - 1911, "000") & Format(StartDate, "MMdd")
            Dim EndDateString As String = Format(Format(EndDate, "yyyy") - 1911, "000") & Format(EndDate, "MMdd")
            SetValue &= " AND LODAY>='" & StartDateString & "' AND LODAY<='" & EndDateString & "' "
        End If
        If CheckBox2.Checked Then
            Dim StartDate As Date = tbStartDate2.Text
            Dim EndDate As Date = tbEndDate2.Text
            Dim StartDateString As String = Format(Format(StartDate, "yyyy") - 1911, "000") & Format(StartDate, "MMdd")
            Dim EndDateString As String = Format(Format(EndDate, "yyyy") - 1911, "000") & Format(EndDate, "MMdd")
            SetValue &= " AND TODAY>='" & StartDateString & "' AND TODAY<='" & EndDateString & "' "
        End If
        Me.hfQryString.Value = SetValue & " Order by LCUSNO "
    End Sub
#End Region

    Public Sub DropDownList2_OnPreRender(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim SenderObj As DropDownList = sender
        SenderObj.Items.Clear()
        For Each EachItem As CompanyORMDB.DEBSYSLB.DEBKCRPF In MoneyKindSearch()
            SenderObj.Items.Add(New ListItem(EachItem.CURRAN, EachItem.CURRAN))
        Next
    End Sub
    Public Sub DropDownList2_OnInit(ByVal sender As Object, ByVal e As System.EventArgs)
        Call DropDownList2_OnPreRender(sender, e)
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.tbStartDate1.Text = Format(New DateTime(Now.AddYears(-1).Year, 1, 1), "yyyy/MM/dd")
            Me.tbEndDate1.Text = Format(Now, "yyyy/MM/dd")
            Me.tbStartDate2.Text = Me.tbStartDate1.Text
            Me.tbEndDate2.Text = Me.tbEndDate1.Text
        End If
    End Sub

    Protected Sub odsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsSearchResult.Selecting
        e.Cancel = Not IsUserAlreadyPutSearch
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        SetQryStringToControl()
        Me.ListView1.DataBind()
    End Sub

    Protected Sub btnClearSearchCondiction_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearSearchCondiction.Click
        IsUserAlreadyPutSearch = False
        tbLCID.Text = Nothing
        CheckBox1.Checked = False
        CheckBox2.Checked = False
    End Sub

    Public Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        args.IsValid = Not String.IsNullOrEmpty(CType(Me.ListView1.InsertItem.FindControl("LCUSNOTextBox"), TextBox).Text)
    End Sub

End Class