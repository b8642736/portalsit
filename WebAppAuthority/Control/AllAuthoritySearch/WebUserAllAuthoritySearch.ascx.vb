Public Partial Class WebUserAllAuthoritySearch1
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
        Dim Query As IQueryable(Of CompanyLINQDB.WebLoginAccount) = From A In DBDataContext.WebLoginAccount Select A
        If Not String.IsNullOrEmpty(UserWindowAccount) Then
            Query = From A In Query Where A.WindowLoginName Like "%" & UserWindowAccount & "%" Select A
        End If
        If Not String.IsNullOrEmpty(UserDisplayName) Then
            Query = From A In Query Where A.DisplayName Like "%" & UserDisplayName & "%" Select A
        End If
        If Not String.IsNullOrEmpty(UserMemo1) Then
            Query = From A In Query Where A.Memo1 Like "%" & UserMemo1 & "%" Select A
        End If

        Dim QuerySystemFunctions As IQueryable(Of CompanyLINQDB.WebSystemFunction) = From A In DBDataContext.WebSystemFunction Select A
        If FindWebSystem <> "ALL" Then
            QuerySystemFunctions = From A In QuerySystemFunctions Where A.SystemCode = FindWebSystem Select A
            If FindSystemFunction <> "ALL" Then
                QuerySystemFunctions = From A In QuerySystemFunctions Where A.FunctionCode = FindSystemFunction Select A
            End If
        End If

        'Dim SearchResult As New List(Of AllAuthoritySearchDataSet.WebUerAllAuthorityDataTableDataTable) '= (From A In CompanyORMDB.PPS100LB.PPSCIALJ.CDBSetDataTableToObjects(Of CompanyORMDB.PPS100LB.PPSCIALJ)(New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString).SelectQuery) Select A).ToList

        Dim ReturnValue As New AllAuthoritySearchDataSet.WebUerAllAuthorityDataTableDataTable 'TO FROM  A IN Query
        Dim AddItem As DataRow = Nothing
        For Each EachItem As CompanyLINQDB.WebLoginAccount In Query.ToList
            Dim EachItemTemp As CompanyLINQDB.WebLoginAccount = EachItem

            For Each EachSystemFunction As CompanyLINQDB.WebSystemFunction In QuerySystemFunctions.ToList
                Dim EachSystemFunctionTemp As CompanyLINQDB.WebSystemFunction = EachSystemFunction
                '找尋個別授權
                If (From A In DBDataContext.WebUserAuthority Where A.FKWebLoginAccount_WindowLoginName = EachItemTemp.WindowLoginName And A.FK_SystemCode = EachSystemFunctionTemp.SystemCode And A.FK_SystemFunctionCode = EachSystemFunctionTemp.FunctionCode Select A).Any Then
                    AddRowItem(ReturnValue, EachItemTemp.WindowLoginName, EachItemTemp.DisplayName, EachItemTemp.Memo1, Nothing, EachSystemFunctionTemp.WebSystem.SystemName, EachSystemFunctionTemp.FunctionName, EachSystemFunctionTemp.Description)
                End If
                '找尋群組授權
                Dim WebSystemFunctionForWebGroupAuthority_GroupCodes As List(Of String) = (From A In DBDataContext.WebGroupAuthority Where A.FK_SystemCode = EachSystemFunctionTemp.SystemCode And A.FK_SystemFunctionCode = EachSystemFunctionTemp.FunctionCode Select A.GroupCode).ToList
                If (From A In DBDataContext.WebLoginAccountToWebGroupAccount Where A.WindowLoginName = EachItemTemp.WindowLoginName And WebSystemFunctionForWebGroupAuthority_GroupCodes.Contains(A.GroupCode) Select A).Any Then
                    AddRowItem(ReturnValue, EachItemTemp.WindowLoginName, EachItemTemp.DisplayName, EachItemTemp.Memo1, Nothing, EachSystemFunctionTemp.WebSystem.SystemName, EachSystemFunctionTemp.FunctionName, EachSystemFunctionTemp.Description)
                End If
            Next
        Next
        Return ReturnValue



        'AddItem = ReturnValue.NewRow
        'With AddItem()
        '    .Item("Window登入帳號") = EachItem.WindowLoginName
        '    .Item("Window使用者顯示名稱") = EachItem.DisplayName
        '    .Item("Window使用者備註1") = EachItem.Memo1
        '    .Item("授權群組") = EachItem.WindowLoginName
        '    .Item("授權系統") = EachItem.WindowLoginName
        '    .Item("授權系統功能") = EachItem.WindowLoginName
        '    .Item("授權備註1") = EachItem.WindowLoginName

        'End With

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
        Dim AddItem As New CompanyLINQDB.WebSystemFunction
        AddItem.FunctionCode = "ALL"
        AddItem.FunctionName = "全部"
        Result.Insert(0, AddItem)
        e.Result = Result
    End Sub
End Class