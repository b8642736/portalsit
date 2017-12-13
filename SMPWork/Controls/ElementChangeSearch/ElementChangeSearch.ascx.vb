Public Class ElementChangeSearch
    Inherits System.Web.UI.UserControl

#Region "資料查詢 方法:Search"
    ''' <summary>
    ''' 資料查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function Search(ByVal IsButtonClick As Boolean, ByVal StoveNumber As String, ByVal StationName As String) As List(Of CompanyLINQDB.分析資料變更記錄)
        If IsButtonClick = False Then
            Return New List(Of CompanyLINQDB.分析資料變更記錄)
        End If
        Dim DBAdapter As New CompanyLINQDB.SMPDataContext
        Dim ReturnValue As IQueryable(Of CompanyLINQDB.分析資料變更記錄) = From A In DBAdapter.分析資料變更記錄 Select A
        If Not String.IsNullOrEmpty(StoveNumber) Then
            ReturnValue = From A In ReturnValue Where A.爐號 = StoveNumber Select A
        End If
        If Not String.IsNullOrEmpty(StationName) AndAlso StationName <> "ALL" Then
            ReturnValue = From A In ReturnValue Where A.站別 Like StationName Select A
        End If
        Return ReturnValue.ToList
    End Function
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.hfArg0.Value = True
        Me.hfArg1.Value = tbFurnaceNumber.Text.Trim
        Me.hfArg2.Value = DDLStationName.SelectedValue
        GridView1.DataBind()
    End Sub
End Class