Public Partial Class AssetSearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="AssetNumber"></param>
    ''' <param name="AssetName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal AssetNumber As String, ByVal AssetName As String, ByVal PlanClass As String) As List(Of CompanyORMDB.AST500LB.AST101PF)
        Dim WhereString As String = Nothing
        If Not IsNothing(AssetNumber) AndAlso Not String.IsNullOrEmpty(AssetNumber) Then
            WhereString &= IIf(IsNothing(WhereString), Nothing, " AND ") & " Number='" & AssetNumber & "'"
        End If
        If Not IsNothing(AssetName) AndAlso Not String.IsNullOrEmpty(AssetName) Then
            WhereString &= IIf(IsNothing(WhereString), Nothing, " AND ") & " NAME LIKE '" & AssetName & "%'"
        End If

        Dim QryString As String = "Select * from " & (New AST101PF).CDBFullAS400DBPath.Trim & "." & PlanClass & IIf(IsNothing(WhereString), Nothing, " Where " & WhereString)
        Return CompanyORMDB.ORMBaseClass.ClassDBAS400.CDBSelect(Of AST101PF)(QryString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
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
#Region "使用者選擇之物件 事件:UserSelectAST101PFEvent"
    ''' <summary>
    ''' 使用者選擇之物件
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <param name="SelectObject"></param>
    ''' <remarks></remarks>
    Public Event UserSelectAST101PFEvent(ByVal Sender As AssetSearch, ByVal SelectObject As AST101PF)
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearchClearCondiction_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchClearCondiction.Click
        Me.TextBox1.Text = Nothing
        Me.TextBox2.Text = Nothing
        Me.IsUserAlreadyPutSearch = False
    End Sub

    Private Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim FindObjects As List(Of AST101PF) = Search(GridView1.SelectedValue, Nothing, RadioButtonList1.SelectedValue)
        If FindObjects.Count > 0 Then
            RaiseEvent UserSelectAST101PFEvent(Me, FindObjects(0))
        End If
    End Sub

    Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        e.Cancel = Not Me.IsUserAlreadyPutSearch
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Me.IsUserAlreadyPutSearch = True
        Me.GridView1.SelectedIndex = -1
        Me.GridView1.DataBind()
    End Sub

    Protected Sub odsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsSearchResult.Selecting
        e.Cancel = Not Me.IsUserAlreadyPutSearch
    End Sub

    Protected Sub btnCancelAndBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelAndBack.Click
        RaiseEvent UserSelectAST101PFEvent(Me, Nothing)
    End Sub

End Class