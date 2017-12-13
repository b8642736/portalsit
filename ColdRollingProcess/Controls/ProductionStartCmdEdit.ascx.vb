Public Class ProductionStartCmdEdit
    Inherits System.Web.UI.UserControl


#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLSQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLSQLString As String) As List(Of CompanyORMDB.SQLServer.PPS100LB.PlanProductionDisplay)
        If String.IsNullOrEmpty(SQLSQLString) Then
            Return New List(Of CompanyORMDB.SQLServer.PPS100LB.PlanProductionDisplay)
        End If
        Return CompanyORMDB.SQLServer.PPS100LB.PlanProductionDisplay.CDBSelect(Of CompanyORMDB.SQLServer.PPS100LB.PlanProductionDisplay)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLSQLString)
    End Function
#End Region
#Region "新增 方法:Insert"
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <param name="SourceObject"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Insert)> _
    Public Function Insert(ByVal SourceObject As CompanyORMDB.SQLServer.PPS100LB.PlanProductionDisplay) As Integer
        Dim ReturnValue As Integer = SourceObject.CDBInsert
        If ReturnValue > 0 Then
            CompanyORMDB.SQLServer.PPS100LB.PlanProductionDisplay.ReOrderCIW15()
        End If
        Return ReturnValue
    End Function
#End Region
#Region "更新 方法:Update"
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Function Update(ByVal SourceObject As CompanyORMDB.SQLServer.PPS100LB.PlanProductionDisplay) As Integer
        Dim ReturnValue As Integer = SourceObject.CDBUpdate
        If SourceObject.CIW15 Mod 10 <> 0 Then
            CompanyORMDB.SQLServer.PPS100LB.PlanProductionDisplay.ReOrderCIW15()
        End If
        Return ReturnValue
    End Function
#End Region
#Region "刪除 方法:Delete"
    <DataObjectMethod(DataObjectMethodType.Delete)> _
    Public Function Delete(ByVal SourceObject As CompanyORMDB.SQLServer.PPS100LB.PlanProductionDisplay) As Integer
        Dim ReturnValue As Integer = SourceObject.CDBDelete
        If ReturnValue > 0 Then
            CompanyORMDB.SQLServer.PPS100LB.PlanProductionDisplay.ReOrderCIW15()
        End If
        Return ReturnValue
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

#Region "控制項Where條件產生器 方法:ControlWhereMaker"
    ''' <summary>
    ''' Where
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ControlWhereMaker()
        Dim ReturnValueForSQL As New StringBuilder
        ReturnValueForSQL.Append("Select * from PlanProductionDisplay Where 1=1 ")

        If RadioButtonList1.SelectedValue <> "ALL" Then
            ReturnValueForSQL.Append(" AND LEFT(CIW0A,2)='" & RadioButtonList1.SelectedValue.Substring(0, 2) & "'")
        End If

        If Not String.IsNullOrEmpty(tbSteelKindType.Text) AndAlso tbSteelKindType.Text.Trim.Length > 0 Then
            ReturnValueForSQL.Append(" AND ((RTRIM(LTRIM(CIW03)) + RTRIM(LTRIM(CIW04))) IN ('" & tbSteelKindType.Text.Trim.Replace(",", "','") & "') )")
        End If

        If Not String.IsNullOrEmpty(tbWidth.Text) AndAlso tbWidth.Text.Trim.Length > 0 Then
            If tbWidth.Text.Contains("~") Then
                ReturnValueForSQL.Append(" AND CIW02 >= " & tbWidth.Text.Split("~")(0).Trim)
                ReturnValueForSQL.Append(" AND CIW02 <= " & tbWidth.Text.Split("~")(1).Trim)
            Else
                ReturnValueForSQL.Append(" AND CIW02 in (" & tbWidth.Text.Trim & ")")
            End If
        End If

        If Not String.IsNullOrEmpty(tbThick.Text) AndAlso tbThick.Text.Trim.Length > 0 Then
            'ReturnValueForSQL.Append(" AND CAST(CIW05 as float) IN (" & tbThick.Text.Trim & ")")
            If tbThick.Text.Contains("~") Then
                ReturnValueForSQL.Append(" AND CIW05 >= " & tbThick.Text.Split("~")(0).Trim)
                ReturnValueForSQL.Append(" AND CIW05 <= " & tbThick.Text.Split("~")(1).Trim)
            Else
                ReturnValueForSQL.Append(" AND CIW05 in ('" & tbThick.Text.Trim.Replace(",", "','") & "')")
            End If

        End If

        Dim SelectValues As String = Nothing
        For Each EachItem As ListItem In CheckBoxList1.Items
            If EachItem.Selected Then
                SelectValues &= IIf(String.IsNullOrEmpty(SelectValues), "", ",") & EachItem.Value
            End If
        Next
        If Not (String.IsNullOrEmpty(SelectValues) OrElse SelectValues.Split(",").Count = CheckBoxList1.Items.Count) Then
            ReturnValueForSQL.Append(" AND CIW06 IN (" & SelectValues & ")")
        End If

        If CheckBox1.Checked Then
            ReturnValueForSQL.Append(" AND CIW12 >0 ")
        End If


        Me.hfSQLQry.Value = ReturnValueForSQL.ToString & " Order by CIW15"
    End Sub
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ControlWhereMaker()
        ListView1.DataBind()
    End Sub

End Class