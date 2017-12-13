Public Class ProcessSchedualEdit
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryString As String, ByVal FilterEquipmentNames As String) As List(Of CompanyORMDB.SQLServer.PPS100LB.ProcessSchedual)
        If String.IsNullOrEmpty(QryString) Then
            Return New List(Of ProcessSchedual)
        End If
        Dim SearchResult As List(Of ProcessSchedual) = ProcessSchedual.CDBSelect(Of ProcessSchedual)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
        Dim ReturnValue As New List(Of ProcessSchedual)
        For Each EachItem As ProcessSchedual In SearchResult
            ReturnValue.Add(EachItem)
            ReturnValue.AddRange(EachItem.AllNextProcessSchedualEquipments)
        Next
        If Not (String.IsNullOrEmpty(FilterEquipmentNames) OrElse FilterEquipmentNames.Trim.Length = 0) Then
            Return (From A In ReturnValue Where FilterEquipmentNames.Trim.Split(",").Contains(A.EquipmentName.Trim) Select A).ToList
        End If
        Return ReturnValue
    End Function
#End Region
#Region "新增 方法:Insert"
    <DataObjectMethod(DataObjectMethodType.Insert)> _
    Public Function Insert(ByVal SourceObject As CompanyORMDB.SQLServer.PPS100LB.ProcessSchedual) As Integer
        Return SourceObject.CDBInsert
    End Function
#End Region
#Region "更新 方法:Update"
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Function Update(ByVal SourceObject As CompanyORMDB.SQLServer.PPS100LB.ProcessSchedual) As Integer
        Return SourceObject.CDBUpdate
    End Function
#End Region
#Region "刪除 方法:Delete"
    <DataObjectMethod(DataObjectMethodType.Delete)> _
    Public Function Delete(ByVal SourceObject As CompanyORMDB.SQLServer.PPS100LB.ProcessSchedual) As Integer
        Return SourceObject.CDBDelete
    End Function
#End Region
#Region "查詢 方法:Search"
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function SearchConnectNodes(ByVal SetConnectProcessSchedualID As String) As List(Of CompanyORMDB.SQLServer.PPS100LB.ProcessSchedual)
        Dim QryString As String = "Select * From ProcessSchedual Where ID='" & SetConnectProcessSchedualID & "'"
        Dim SetConnectProcessSchedual As ProcessSchedual = (From A In ProcessSchedual.CDBSelect(Of ProcessSchedual)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, qrystring) Select A).FirstOrDefault
        If IsNothing(SetConnectProcessSchedual) Then
            Return New List(Of CompanyORMDB.SQLServer.PPS100LB.ProcessSchedual)
        End If
        QryString = "Select * From ProcessSchedual Where ID<>'" & SetConnectProcessSchedualID & "' AND FinalFish='" & SetConnectProcessSchedual.FinalFish & "' "
        If Not String.IsNullOrEmpty(SetConnectProcessSchedual.PreProcessSchedualIDs) AndAlso SetConnectProcessSchedual.PreProcessSchedualIDs.Trim.Length > 0 Then
            QryString &= " AND ID NOT IN ('" & SetConnectProcessSchedual.PreProcessSchedualIDs.Trim.Replace(",", "','") & "')"
        End If

        'Dim RetrunValue As List(Of ProcessSchedual) = ProcessSchedual.CDBSelect(Of ProcessSchedual)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
        'Dim RemoveNodeIDs As List(Of String) = (From A In SetConnectProcessSchedual.AllNextProcessSchedualEquipments Select A.ID.Trim).ToList
        'For Each EachItem In (From A In RetrunValue Where RemoveNodeIDs.Contains(A.ID.Trim) Select A).ToList
        '    RetrunValue.Remove(EachItem)
        'Next

        Return ProcessSchedual.CDBSelect(Of ProcessSchedual)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
    End Function
#End Region
#Region "查詢所有節點 方法:SearchAllStation"
    ''' <summary>
    ''' 查詢所有節點
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function SearchAllStation() As List(Of CompanyORMDB.SQLServer.PPS100LB.Station)
        Return CompanyORMDB.SQLServer.PPS100LB.Station.AllStation
    End Function
#End Region


#Region "產生查詢字串至控制項  函式:MakeQryStringToControl"
    Private Sub MakeQryStringToControl()
        Dim ReturnValue As String = "Select * From ProcessSchedual Where PreProcessSchedualIDs='' "
        If Not (String.IsNullOrEmpty(TextBox2.Text) OrElse TextBox2.Text.Trim.Length = 0) Then
            ReturnValue &= " AND FinalFish in ('" & TextBox2.Text.Trim.Replace(",", "','") & "')"
        End If
        Me.hfQryString.Value = ReturnValue
    End Sub
#End Region

    Private ListView1ItemCmd As String = Nothing

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        MakeQryStringToControl()
        ListView1.DataBind()
    End Sub

    Public Sub btnEditConnect_Click(ByVal sender As Object, ByVal e As EventArgs)
        If IsNothing(ListView1ItemCmd) OrElse IsNothing(ListView1.SelectedDataKey) Then
            Exit Sub
        End If

        Select Case True
            Case ListView1ItemCmd = "設定連結"
                hfConnectNodeID.Value = ListView1.SelectedDataKey.Value '設定連結之節點ID
                If Not String.IsNullOrEmpty(hfConnectNodeID.Value) OrElse hfConnectNodeID.Value.Trim.Length = 0 Then
                    Me.MultiView1.SetActiveView(View2)
                    GridView1.DataBind()
                End If
            Case ListView1ItemCmd = "名稱轉換設定"
                Me.MultiView1.SetActiveView(View3)
                ProcessToInOutOperationLineNameEdit1.ProcessSchedualID = ListView1.SelectedDataKey.Value
                ProcessToInOutOperationLineNameEdit1.DefaultSearchRefresh()
                'Case ListView1ItemCmd = "電腦IP對應"
                '    Me.MultiView1.SetActiveView(View4)
                '    ProcessToWebClientPCAccountEdit1.ProcessSchedualID = ListView1.SelectedDataKey.Value
                '    ProcessToWebClientPCAccountEdit1.DefaultSearchRefresh()
        End Select
    End Sub

    Protected Sub btnCancelToSet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelToSet.Click
        hfConnectNodeID.Value = Nothing
        ListView1.SelectedIndex = -1
        Me.MultiView1.SetActiveView(View1)
        Call btnSearch_Click(Nothing, Nothing)
    End Sub

    Private Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim QryString As String = "Select * from ProcessSchedual Where ID='" & hfConnectNodeID.Value & "'"
        Dim SourceNode As ProcessSchedual = (From A In ProcessSchedual.CDBSelect(Of ProcessSchedual)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString) Select A).FirstOrDefault
        Dim SetPreNodeID As String = GridView1.SelectedDataKey.Value
        If IsNothing(SourceNode) OrElse String.IsNullOrEmpty(SetPreNodeID) OrElse SetPreNodeID.Trim.Length = 0 Then
            Exit Sub
        End If
        SourceNode.PreProcessSchedualIDs = SourceNode.PreProcessSchedualIDs.Trim & IIf(String.IsNullOrEmpty(SourceNode.PreProcessSchedualIDs) OrElse SourceNode.PreProcessSchedualIDs.Trim.Length = 0, Nothing, ",") & SetPreNodeID.Trim
        If SourceNode.CDBSave > 0 Then
            Call btnCancelToSet_Click(Nothing, Nothing)
        End If

    End Sub

    Protected Sub btnClearAllConnect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearAllConnect.Click
        Dim QryString As String = "Select * from ProcessSchedual Where ID='" & hfConnectNodeID.Value & "'"
        Dim SourceNode As ProcessSchedual = (From A In ProcessSchedual.CDBSelect(Of ProcessSchedual)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString) Select A).FirstOrDefault
        If IsNothing(SourceNode) Then
            Exit Sub
        End If
        SourceNode.PreProcessSchedualIDs = ""
        If SourceNode.CDBSave > 0 Then
            Call btnCancelToSet_Click(Nothing, Nothing)
        End If
    End Sub

    Protected Sub btnGoBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGoBack.Click
        ProcessToInOutOperationLineNameEdit1.ProcessSchedualID = Nothing
        Call btnCancelToSet_Click(Nothing, Nothing)
    End Sub

    Private Sub ListView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewCommandEventArgs) Handles ListView1.ItemCommand
        ListView1ItemCmd = CType(e.CommandSource, Button).Text.Trim
    End Sub


    Private Sub ListView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.PreRender
        If Not IsNothing(Me.ListView1.EditItem) AndAlso Not IsNothing(Me.ListView1.EditItem.FindControl("DropDownList1")) Then
            Dim GetFindValue As String = CType(Me.ListView1.EditItem.FindControl("hfStationName"), HiddenField).Value.Trim
            Dim SetDropDownList As DropDownList = Me.ListView1.EditItem.FindControl("DropDownList1")
            For Each EachItem As ListItem In SetDropDownList.Items
                If GetFindValue = EachItem.Value.Trim Then
                    SetDropDownList.SelectedIndex = SetDropDownList.Items.IndexOf(EachItem)
                    Exit Sub
                End If
            Next
        End If
    End Sub

    Private Sub ListView1_ItemInserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewInsertEventArgs) Handles ListView1.ItemInserting
        e.Values("FK_StationName") = CType(Me.ListView1.InsertItem.FindControl("DropDownList1"), DropDownList).SelectedValue
    End Sub

    Private Sub ListView1_ItemUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewUpdateEventArgs) Handles ListView1.ItemUpdating
        e.NewValues("FK_StationName") = CType(Me.ListView1.EditItem.FindControl("DropDownList1"), DropDownList).SelectedValue
    End Sub

    Protected Sub ListView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub
End Class