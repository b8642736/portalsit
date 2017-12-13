Public Class InOutOperationLineNameEdit
    Inherits System.Web.UI.UserControl
#Region "查詢 方法:Search"
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryString As String) As List(Of InOutOperationLineName)
        If String.IsNullOrEmpty(QryString) Then
            Return New List(Of InOutOperationLineName)
        End If
        Return InOutOperationLineName.CDBSelect(Of InOutOperationLineName)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
    End Function
#End Region
#Region "新增 方法:Insert"
    <DataObjectMethod(DataObjectMethodType.Insert)> _
    Public Function Insert(ByVal SourceObject As InOutOperationLineName) As Integer
        Return SourceObject.CDBInsert
    End Function
#End Region
#Region "更新 方法:Update"
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Function Update(ByVal SourceObject As InOutOperationLineName) As Integer
        Return SourceObject.CDBUpdate
    End Function
#End Region
#Region "刪除 方法:Delete"
    <DataObjectMethod(DataObjectMethodType.Delete)> _
    Public Function Delete(ByVal SourceObject As InOutOperationLineName) As Integer
        Return SourceObject.CDBDelete
    End Function
#End Region


#Region "產生查詢字串至控制項  函式:MakeQryStringToControl"
    Private Sub MakeQryStringToControl()
        Dim ReturnValue As String = "Select * From InOutOperationLineName Where 1=1 "
        If Not (String.IsNullOrEmpty(TextBox1.Text) OrElse TextBox1.Text.Trim.Length = 0) Then
            ReturnValue &= " AND InNextOperationLineName LIKE '%" & TextBox1.Text.Trim & "%'"
        End If
        If Not (String.IsNullOrEmpty(TextBox2.Text) OrElse TextBox2.Text.Trim.Length = 0) Then
            ReturnValue &= " AND InCurrentFish LIKE '%" & TextBox2.Text.Trim & "%'"
        End If
        If Not (String.IsNullOrEmpty(TextBox3.Text) OrElse TextBox3.Text.Trim.Length = 0) Then
            ReturnValue &= " AND OutOperationLineName LIKE '%" & TextBox3.Text.Trim & "%'"
        End If
        If Not (String.IsNullOrEmpty(TextBox4.Text) OrElse TextBox4.Text.Trim.Length = 0) Then
            ReturnValue &= " AND OutNextOperationLineName LIKE '%" & TextBox4.Text.Trim & "%'"
        End If
        Me.hfQryString.Value = ReturnValue
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnClearSearchCondiction_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearSearchCondiction.Click
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        TextBox3.Text = Nothing
        TextBox4.Text = Nothing
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        MakeQryStringToControl()
        ListView1.DataBind()
    End Sub
End Class