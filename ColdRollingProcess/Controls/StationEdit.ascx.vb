Public Class StationEdit
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryString As String) As List(Of CompanyORMDB.SQLServer.PPS100LB.Station)
        If String.IsNullOrEmpty(QryString) Then
            Return New List(Of CompanyORMDB.SQLServer.PPS100LB.Station)
        End If
        Return CompanyORMDB.SQLServer.PPS100LB.Station.CDBSelect(Of CompanyORMDB.SQLServer.PPS100LB.Station)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
    End Function
#End Region
#Region "新增 方法:Insert"
    <DataObjectMethod(DataObjectMethodType.Insert)> _
    Public Function Insert(ByVal SourceObject As CompanyORMDB.SQLServer.PPS100LB.Station) As Integer
        Return SourceObject.CDBInsert
    End Function
#End Region
#Region "更新 方法:Update"
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Function Update(ByVal SourceObject As CompanyORMDB.SQLServer.PPS100LB.Station) As Integer
        Return SourceObject.CDBUpdate
    End Function
#End Region
#Region "刪除 方法:Delete"
    <DataObjectMethod(DataObjectMethodType.Delete)> _
    Public Function Delete(ByVal SourceObject As CompanyORMDB.SQLServer.PPS100LB.Station) As Integer
        Return SourceObject.CDBDelete
    End Function
#End Region

#Region "父站台查詢 方法:ParentStationSearch"
    ''' <summary>
    ''' 父站台查詢
    ''' </summary>
    ''' <param name="QryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function ParentStationSearch(ByVal QryString As String) As List(Of CompanyORMDB.SQLServer.PPS100LB.Station)
        If String.IsNullOrEmpty(QryString) Then
            Return New List(Of CompanyORMDB.SQLServer.PPS100LB.Station)
        End If
        Return CompanyORMDB.SQLServer.PPS100LB.Station.CDBSelect(Of CompanyORMDB.SQLServer.PPS100LB.Station)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
    End Function
#End Region

#Region "產生查詢字串至控制項  函式:MakeQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakeQryStringToControl()
        Dim ReturnValue As String = "Select * From Station Where 1=1 "
        If Not (String.IsNullOrEmpty(tbStationName.Text) OrElse tbStationName.Text.Trim.Length = 0) Then
            ReturnValue &= " AND StationName LIKE '%" & tbStationName.Text.Trim & "%'"
        End If
        Me.hfQryString.Value = ReturnValue
    End Sub
#End Region
#Region "產生父站台查詢字串至控制項  函式:MakeParentStationQryStringToControl"
    ''' <summary>
    ''' 產生父站台查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakeParentStationQryStringToControl()
        Dim ReturnValue As String = "Select * From Station Where 1=1 "
        If Not IsNothing(Me.ListView1.EditItem) AndAlso Not IsNothing(Me.ListView1.EditItem.FindControl("StationNameTextBox")) Then
            ReturnValue &= " AND StationName<>'" & CType(Me.ListView1.EditItem.FindControl("StationNameTextBox"), TextBox).Text & "'"
        End If
        Me.hfQryString0.Value = ReturnValue
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub tbSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tbSearch.Click
        MakeQryStringToControl()
        Me.ListView1.DataBind()
    End Sub


    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBack.Click
        Me.MultiView1.SetActiveView(Me.View1)
        Call tbSearch_Click(Nothing, Nothing)
    End Sub

    Private Sub ListView1_ItemInserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewInsertEventArgs) Handles ListView1.ItemInserting
        e.Values("FK_ParentStationName") = CType(Me.ListView1.InsertItem.FindControl("DropDownList1"), DropDownList).SelectedValue
    End Sub

    Private Sub ListView1_ItemUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewUpdateEventArgs) Handles ListView1.ItemUpdating
        e.NewValues("FK_ParentStationName") = CType(Me.ListView1.EditItem.FindControl("DropDownList1"), DropDownList).SelectedValue
    End Sub

    Private Sub ListView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.PreRender
        MakeParentStationQryStringToControl()

        If Not IsNothing(Me.ListView1.EditItem) AndAlso Not IsNothing(Me.ListView1.EditItem.FindControl("DropDownList1")) Then
            Dim GetFindValue As String = CType(Me.ListView1.EditItem.FindControl("hfFK_ParentStationName"), HiddenField).Value.Trim
            Dim SetDropDownList As DropDownList = Me.ListView1.EditItem.FindControl("DropDownList1")
            For Each EachItem As ListItem In SetDropDownList.Items
                If GetFindValue = EachItem.Value.Trim Then
                    SetDropDownList.SelectedIndex = SetDropDownList.Items.IndexOf(EachItem)
                    Exit Sub
                End If
            Next
        End If

    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Me.StationToWebClientPCAccountEdit1.StationName = Nothing
        If IsNothing(ListView1.SelectedDataKey) Then
            Exit Sub
        End If
        Me.StationToWebClientPCAccountEdit1.StationName = ListView1.SelectedDataKey.Value
        Me.StationToWebClientPCAccountEdit1.DefaultSearchRefresh()
        Me.MultiView1.SetActiveView(Me.View2)
    End Sub

End Class