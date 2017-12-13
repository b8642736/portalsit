Public Partial Class MainSubAssetEdit
    Inherits System.Web.UI.UserControl


#Region "查詢 方法:Search/MatchSearch1/MatchSearch2"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="MasterAsset"></param>
    ''' <param name="SubAsset"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal MasterAsset As String, ByVal SubAsset As String) As List(Of AST107PF)
        Dim WhereString As String = Nothing
        If Not IsNothing(MasterAsset) AndAlso MasterAsset.Trim.Length > 0 Then
            WhereString &= IIf(IsNothing(WhereString), Nothing, " AND ") & " Master Like '" & MasterAsset.Trim & "%' "
        End If
        If Not IsNothing(SubAsset) AndAlso SubAsset.Trim.Length > 0 Then
            WhereString &= IIf(IsNothing(WhereString), Nothing, " AND ") & " Number Like '" & SubAsset.Trim & "%' "
        End If
        Dim Qry As String = "Select * from " & (New CompanyORMDB.AST500LB.AST107PF).CDBFullAS400DBPath & IIf(IsNothing(WhereString), Nothing, " Where " & WhereString)
        Return CompanyORMDB.ORMBaseClass.ClassDBAS400.CDBSelect(Of AST107PF)(Qry, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    End Function

    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function MatchSearch1(ByVal MasterAsset As String) As List(Of AST101PF)
        Dim WhereString As String = Nothing
        If Not IsNothing(MasterAsset) AndAlso MasterAsset.Trim.Length > 0 Then
            WhereString &= IIf(IsNothing(WhereString), Nothing, " AND ") & " Number Like '" & MasterAsset.Trim & "%' "
        End If
        Dim Qry As String = "Select * from " & (New CompanyORMDB.AST500LB.AST101PF).CDBFullAS400DBPath.Trim & ".ASTFSA" & IIf(IsNothing(WhereString), Nothing, " Where " & WhereString)
        Return CompanyORMDB.ORMBaseClass.ClassDBAS400.CDBSelect(Of AST101PF)(Qry, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function MatchSearch2(ByVal SubAsset As String) As List(Of AST101PF)
        Dim WhereString As String = Nothing
        If Not IsNothing(SubAsset) AndAlso SubAsset.Trim.Length > 0 Then
            WhereString &= IIf(IsNothing(WhereString), Nothing, " AND ") & " Number Like '" & SubAsset.Trim & "%' "
        End If
        Dim Qry As String = "Select * from " & (New CompanyORMDB.AST500LB.AST101PF).CDBFullAS400DBPath.Trim & ".ASTFSA" & IIf(IsNothing(WhereString), Nothing, " Where " & WhereString)
        Return CompanyORMDB.ORMBaseClass.ClassDBAS400.CDBSelect(Of AST101PF)(Qry, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

    End Function


    Private Function SearchAsset(Of ObjectType As {New, CompanyORMDB.ORMBaseClass.ClassDBAS400})(ByVal AssetNumber As String, ByVal AssetName As String, ByVal PlanCode As String) As List(Of ObjectType)
        Dim WhereString As String = Nothing
        Dim FromDBAndMemberPathString As String = (New ObjectType).CDBFullAS400DBPath.Trim
        If Not String.IsNullOrEmpty(AssetNumber) AndAlso AssetNumber.Trim.Length > 0 Then
            WhereString &= IIf(IsNothing(WhereString), Nothing, " AND ") & "NUMBER='" & AssetNumber & "'"
        End If
        If Not String.IsNullOrEmpty(AssetName) AndAlso AssetName.Trim.Length > 0 Then
            WhereString &= IIf(IsNothing(WhereString), Nothing, " AND ") & "NAME LIKE '%" & AssetName & "%'"
        End If
        If Not String.IsNullOrEmpty(PlanCode) AndAlso PlanCode.Trim.Length > 0 Then
            FromDBAndMemberPathString &= ".ASTF" & PlanCode
        End If

        Dim QryString As String = "Select * From " & FromDBAndMemberPathString & IIf(IsNothing(WhereString), Nothing, " Where " & WhereString)
        Return CompanyORMDB.ORMBaseClass.ClassDBAS400.CDBSelect(Of ObjectType)(QryString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

    End Function

    Private Function SearchDiscardAsset(Of ObjectType As {New, CompanyORMDB.ORMBaseClass.ClassDBAS400})(ByVal AssetNumber As String, ByVal AssetName As String, ByVal PlanCode As String) As List(Of ObjectType)
        Dim WhereString As String = Nothing
        Dim FromDBAndMemberPathString As String = (New ObjectType).CDBFullAS400DBPath.Trim
        If Not String.IsNullOrEmpty(AssetNumber) AndAlso AssetNumber.Trim.Length > 0 Then
            WhereString &= IIf(IsNothing(WhereString), Nothing, " AND ") & "NUMBER='" & AssetNumber & "'"
        End If
        If Not String.IsNullOrEmpty(AssetName) AndAlso AssetName.Trim.Length > 0 Then
            WhereString &= IIf(IsNothing(WhereString), Nothing, " AND ") & "CNAME LIKE '%" & AssetName & "%'"
        End If
        If Not String.IsNullOrEmpty(PlanCode) AndAlso PlanCode.Trim.Length > 0 Then
            FromDBAndMemberPathString &= ".ASTF" & PlanCode
        End If

        Dim QryString As String = "Select * From " & FromDBAndMemberPathString & IIf(IsNothing(WhereString), Nothing, " Where " & WhereString)
        Return CompanyORMDB.ORMBaseClass.ClassDBAS400.CDBSelect(Of ObjectType)(QryString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

    End Function


#End Region
#Region "刪除 方法:Delete"
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <param name="SoureObject"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Delete)> _
  Public Function Delete(ByVal SoureObject As AST107PF) As Integer
        SoureObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return SoureObject.CDBDelete
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch1Clear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch1Clear.Click
        IsUserAlreadyPutSearch1 = False
        TextBox3.Text = Nothing
        TextBox4.Text = Nothing
    End Sub

    Private Sub GridView2_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.PageIndexChanged, GridView3.PageIndexChanged
        CType(sender, GridView).SelectedIndex = -1
        btnAddMatch.Enabled = False
    End Sub

    Private Sub GridView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.SelectedIndexChanged, GridView3.SelectedIndexChanged
        btnAddMatch.Enabled = (GridView2.SelectedIndex >= 0 And GridView3.SelectedIndex >= 0)
    End Sub

    Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        Me.GridView1.DataBind()
    End Sub

    Protected Sub btnSearch1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch1.Click
        IsUserAlreadyPutSearch1 = True
        Me.GridView2.DataBind()
        Me.GridView3.DataBind()
    End Sub

    Private Sub odsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsSearchResult.Selecting
        e.Cancel = Not IsUserAlreadyPutSearch
    End Sub

    Private Sub odsMatchSearch1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsMatchSearch1.Selecting, odsMatchSearch2.Selecting
        e.Cancel = Not IsUserAlreadyPutSearch1
    End Sub

    Protected Sub btnSearchClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchClear.Click
        Me.IsUserAlreadyPutSearch = False
        Me.TextBox1.Text = Nothing
        Me.TextBox2.Text = Nothing
    End Sub

    Protected Sub btnAddMatch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddMatch.Click
        Dim NewItem As New AST107PF
        With NewItem
            .SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            .MASTER = GridView2.SelectedValue
            .NUMBER = GridView3.SelectedValue
        End With
        Try
            Dim InsertCount As Integer = NewItem.CDBInsert()
            lbMessage.Text = "已成功加入" & InsertCount & " 筆資料"
            lbMessage.Visible = True
        Catch ex As Exception
            lbMessage.Text = "發生錯誤:" & ex.ToString
        End Try
    End Sub


    Private Sub TabContainer1_ActiveTabChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabContainer1.ActiveTabChanged
        lbMessage.Visible = False
    End Sub
End Class