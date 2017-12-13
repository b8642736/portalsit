Public Partial Class WebUserOrIPAllAuthoritySearch
    Inherits System.Web.UI.UserControl

    Dim DBDataContext As CompanyLINQDB.WebAPPAuthorityDataContext = New CompanyLINQDB.WebAPPAuthorityDataContext

#Region "資料查詢 方法:Search"
    ''' <summary>
    ''' 資料查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function Search(ByVal UserWindowAccount As String, ByVal UserDisplayName As String, ByVal UserMemo1 As String, ByVal FindWebSystem As String, ByVal FindSystemFunction As String) As AllAuthoritySearchDataSet.WebUerAllAuthorityDataTableDataTable
        Dim DBDataContext As CompanyLINQDB.WebAPPAuthorityDataContext = New CompanyLINQDB.WebAPPAuthorityDataContext
        Dim LoginAccountQuery As IQueryable(Of CompanyLINQDB.WebLoginAccount) = From A In DBDataContext.WebLoginAccount Select A
        If Not String.IsNullOrEmpty(UserWindowAccount) Then
            LoginAccountQuery = From A In LoginAccountQuery Where A.WindowLoginName Like "*" & UserWindowAccount & "*" Select A
        End If
        If Not String.IsNullOrEmpty(UserDisplayName) Then
            LoginAccountQuery = From A In LoginAccountQuery Where A.DisplayName Like "*" & UserDisplayName & "*" Select A
        End If
        If Not String.IsNullOrEmpty(UserMemo1) Then
            LoginAccountQuery = From A In LoginAccountQuery Where A.Memo1 Like "*" & UserMemo1 & "*" Select A
        End If


        Dim SystemFunctionsQuery As IQueryable(Of CompanyLINQDB.WebSystemFunction) = From A In DBDataContext.WebSystemFunction Select A
        If FindWebSystem <> "ALL" Then
            SystemFunctionsQuery = From A In SystemFunctionsQuery Where A.SystemCode = FindWebSystem Select A
        End If
        If FindSystemFunction <> "ALL" Then
            SystemFunctionsQuery = From A In SystemFunctionsQuery Where A.FunctionCode = FindSystemFunction Select A
        End If


        Dim AllWebGroupAuthority As List(Of CompanyLINQDB.WebGroupAuthority) = (From A In DBDataContext.WebGroupAuthority Select A).ToList
        Dim ReturnValue As New AllAuthoritySearchDataSet.WebUerAllAuthorityDataTableDataTable
        Dim AddItem As DataRow = Nothing
        For Each EachLoginAccount As CompanyLINQDB.WebLoginAccount In LoginAccountQuery.ToList
            Dim EachLoginAccountTemp As CompanyLINQDB.WebLoginAccount = EachLoginAccount
            Dim UserHaveAllWebSystems As List(Of CompanyLINQDB.WebGroupAccount) = (From A In EachLoginAccountTemp.About_WebGroupAccounts Select A).ToList
            Dim UserHaveAllWebSystemFunctions As New List(Of CompanyLINQDB.WebSystemFunction)
            For Each EachItem In From A In UserHaveAllWebSystems Select A
                UserHaveAllWebSystemFunctions.AddRange(EachItem.About_WebSystemFunctions)
            Next

            For Each EachSystemFunction As CompanyLINQDB.WebSystemFunction In SystemFunctionsQuery.ToList
                Dim EachSystemFunctionTemp As CompanyLINQDB.WebSystemFunction = EachSystemFunction
                '找尋個別授權
                If (From A In DBDataContext.WebUserAuthority Where A.FKWebLoginAccount_WindowLoginName = EachLoginAccountTemp.WindowLoginName And A.FK_SystemCode = EachSystemFunctionTemp.SystemCode And A.FK_SystemFunctionCode = EachSystemFunctionTemp.FunctionCode Select A).Any Then
                    AddRowItem(ReturnValue, EachLoginAccountTemp.WindowLoginName, EachLoginAccountTemp.DisplayName, EachLoginAccountTemp.Memo1, Nothing, EachSystemFunctionTemp.WebSystem.SystemName, EachSystemFunctionTemp.FunctionName, EachSystemFunctionTemp.Description)
                End If

                '找尋群組方式授權
                For Each EachLoginAccountWebGroup As CompanyLINQDB.WebGroupAccount In EachLoginAccountTemp.About_WebGroupAccounts
                    If (From A In EachLoginAccountWebGroup.About_WebSystemFunctions Where A.SystemCode = EachSystemFunctionTemp.SystemCode And A.FunctionCode = EachSystemFunctionTemp.FunctionCode Select A).Any Then
                        AddRowItem(ReturnValue, EachLoginAccountTemp.WindowLoginName, EachLoginAccountTemp.DisplayName, EachLoginAccountTemp.Memo1, EachLoginAccountWebGroup.GroupName, EachSystemFunctionTemp.WebSystem.SystemName, EachSystemFunctionTemp.FunctionName, EachSystemFunctionTemp.Description)
                    End If
                Next
            Next
        Next
        Return ReturnValue

    End Function

    Private Shared Sub AddRowItem(ByRef SourceDataTable As AllAuthoritySearchDataSet.WebUerAllAuthorityDataTableDataTable, ByVal ParamArray FieldValues() As String)
        Dim AddItem As DataRow = SourceDataTable.NewRow
        With AddItem
            .Item("Window登入帳號") = FieldValues(0)
            .Item("Window使用者顯示名稱") = FieldValues(1)
            .Item("Window使用者備註1") = FieldValues(2)
            .Item("授權群組") = FieldValues(3)
            .Item("授權系統") = FieldValues(4)
            .Item("授權系統功能") = FieldValues(5)
            .Item("授權備註1") = FieldValues(6)
        End With
        SourceDataTable.Rows.Add(AddItem)
    End Sub
#End Region
#Region "資料查詢(電腦IP) 方法:SearchIP"
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SearchIP(ByVal ClientIP As String, ByVal ClientDisplayName As String, ByVal ClientMemo1 As String, ByVal FindWebSystem As String, ByVal FindSystemFunction As String) As AllAuthoritySearchDataSet.WebComputerAllAuthorityDataTableDataTable
        Dim DBDataContext As CompanyLINQDB.WebAPPAuthorityDataContext = New CompanyLINQDB.WebAPPAuthorityDataContext
        Dim WebClientPCAccountQuery As IQueryable(Of CompanyLINQDB.WebClientPCAccount) = From A In DBDataContext.WebClientPCAccount Select A
        If Not String.IsNullOrEmpty(ClientIP) Then
            WebClientPCAccountQuery = From A In WebClientPCAccountQuery Where A.ClientIP Like "*" & ClientIP & "*" Select A
        End If
        If Not String.IsNullOrEmpty(ClientDisplayName) Then
            WebClientPCAccountQuery = From A In WebClientPCAccountQuery Where A.PCName Like "*" & ClientDisplayName & "*" Select A
        End If
        If Not String.IsNullOrEmpty(ClientMemo1) Then
            WebClientPCAccountQuery = From A In WebClientPCAccountQuery Where A.Memo1 Like "*" & ClientMemo1 & "*" Select A
        End If


        Dim SystemFunctionsQuery As IQueryable(Of CompanyLINQDB.WebSystemFunction) = From A In DBDataContext.WebSystemFunction Select A
        If FindWebSystem <> "ALL" Then
            SystemFunctionsQuery = From A In SystemFunctionsQuery Where A.SystemCode = FindWebSystem Select A
        End If
        If FindSystemFunction <> "ALL" Then
            SystemFunctionsQuery = From A In SystemFunctionsQuery Where A.FunctionCode = FindSystemFunction Select A
        End If


        Dim AllWebGroupAuthority As List(Of CompanyLINQDB.WebGroupAuthority) = (From A In DBDataContext.WebGroupAuthority Select A).ToList
        Dim ReturnValue As New AllAuthoritySearchDataSet.WebComputerAllAuthorityDataTableDataTable
        Dim AddItem As DataRow = Nothing
        For Each EachClientPCAccount As CompanyLINQDB.WebClientPCAccount In WebClientPCAccountQuery.ToList
            Dim EachClientPCAccountTemp As CompanyLINQDB.WebClientPCAccount = EachClientPCAccount
            Dim UserHaveAllWebSystems As List(Of CompanyLINQDB.WebGroupAccount) = (From A In EachClientPCAccountTemp.About_WebGroupAccounts Select A).ToList
            Dim UserHaveAllWebSystemFunctions As New List(Of CompanyLINQDB.WebSystemFunction)
            For Each EachItem In From A In UserHaveAllWebSystems Select A
                UserHaveAllWebSystemFunctions.AddRange(EachItem.About_WebSystemFunctions)
            Next

            For Each EachSystemFunction As CompanyLINQDB.WebSystemFunction In SystemFunctionsQuery.ToList
                Dim EachSystemFunctionTemp As CompanyLINQDB.WebSystemFunction = EachSystemFunction
                '找尋個別授權
                If (From A In DBDataContext.WebClientPCAuthority Where A.FKWebClientPCAccount_ClientIP = EachClientPCAccountTemp.ClientIP And A.FK_SystemCode = EachSystemFunctionTemp.SystemCode And A.FK_SystemFunctionCode = EachSystemFunctionTemp.FunctionCode Select A).Any Then
                    AddRowItem2(ReturnValue, EachClientPCAccountTemp.ClientIP, EachClientPCAccountTemp.PCName, EachClientPCAccountTemp.Memo1, Nothing, EachSystemFunctionTemp.WebSystem.SystemName, EachSystemFunctionTemp.FunctionName, EachSystemFunctionTemp.Description)
                End If

                '找尋群組方式授權
                For Each EachLoginAccountWebGroup As CompanyLINQDB.WebGroupAccount In EachClientPCAccountTemp.About_WebGroupAccounts
                    If (From A In EachLoginAccountWebGroup.About_WebSystemFunctions Where A.SystemCode = EachSystemFunctionTemp.SystemCode And A.FunctionCode = EachSystemFunctionTemp.FunctionCode Select A).Any Then
                        AddRowItem2(ReturnValue, EachClientPCAccountTemp.ClientIP, EachClientPCAccountTemp.PCName, EachClientPCAccountTemp.Memo1, EachLoginAccountWebGroup.GroupName, EachSystemFunctionTemp.WebSystem.SystemName, EachSystemFunctionTemp.FunctionName, EachSystemFunctionTemp.Description)
                    End If
                Next
            Next
        Next
        Return ReturnValue
    End Function

    Private Shared Sub AddRowItem2(ByRef SourceDataTable As AllAuthoritySearchDataSet.WebComputerAllAuthorityDataTableDataTable, ByVal ParamArray FieldValues() As String)
        Dim AddItem As DataRow = SourceDataTable.NewRow
        With AddItem
            .Item("電腦IP") = FieldValues(0)
            .Item("電腦名稱") = FieldValues(1)
            .Item("電腦備註1") = FieldValues(2)
            .Item("授權群組") = FieldValues(3)
            .Item("授權系統") = FieldValues(4)
            .Item("授權系統功能") = FieldValues(5)
            .Item("授權備註1") = FieldValues(6)
        End With
        SourceDataTable.Rows.Add(AddItem)
    End Sub

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

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Me.DropDownList2.DataBind()
        Me.UpdatePanel2.Update()
    End Sub

    Protected Sub ldsWebSystem_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsWebSystem.Selecting
        Dim Result As List(Of CompanyLINQDB.WebSystem) = (From A In DBDataContext.WebSystem Select A).ToList
        Dim AddItem As New CompanyLINQDB.WebSystem
        AddItem.SystemCode = "ALL"
        AddItem.SystemName = "全部"
        Result.Insert(0, AddItem)
        e.Result = Result
    End Sub

    Protected Sub ldsWebSystemFunction_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsWebSystemFunction.Selecting
        Dim Result As List(Of CompanyLINQDB.WebSystemFunction) = (From A In DBDataContext.WebSystemFunction Select A).ToList
        If Not String.IsNullOrEmpty(DropDownList1.SelectedValue) AndAlso DropDownList1.SelectedValue <> "ALL" Then
            Result = (From A In Result Where A.SystemCode = DropDownList1.SelectedValue Select A).ToList
        End If
        Dim AddItem As New CompanyLINQDB.WebSystemFunction
        AddItem.FunctionCode = "ALL"
        AddItem.FunctionName = "全部"
        Result.Insert(0, AddItem)
        e.Result = Result
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Me.IsUserAlreadyPutSearch = True
        Select Case RadioButtonList1.SelectedValue
            Case "USER"
                Me.GridView1.DataBind()
            Case "PC"
                Me.GridView2.DataBind()
        End Select
    End Sub

    Protected Sub ObjectDataSource1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ObjectDataSource1.Selecting, odsSearchResult2.Selecting
        e.Cancel = Not IsUserAlreadyPutSearch
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        Me.IsUserAlreadyPutSearch = False
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        TextBox3.Text = Nothing
        Select Case True
            Case RadioButtonList1.SelectedValue = "USER"
                Me.MultiView1.SetActiveView(Me.View1)
                Me.Label1.Text = "使用者登入帳號:"
                Me.Label2.Text = "使用者顯示名稱:"
                Me.Label3.Text = "使用者備註1:"
                Me.btnSearch.Text = "查詢使用者"
            Case RadioButtonList1.SelectedValue = "PC"
                Me.MultiView1.SetActiveView(Me.View2)
                Me.Label1.Text = "電腦登入IP:"
                Me.Label2.Text = "電腦顯示名稱:"
                Me.Label3.Text = "電腦備註1:"
                Me.btnSearch.Text = "查詢電腦"
        End Select
    End Sub

    Protected Sub btnSearchClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchClear.Click
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        TextBox3.Text = Nothing
        Me.DropDownList1.SelectedIndex = 0
        Me.DropDownList2.SelectedIndex = 0
    End Sub
End Class