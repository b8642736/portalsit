Public Class QABugEdit
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="QryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Search(ByVal QryString As String) As List(Of CompanyORMDB.SQLServer.PPS100LB.QABUG)
        Dim ReturnValue As New List(Of CompanyORMDB.SQLServer.PPS100LB.QABUG)
        If String.IsNullOrEmpty(QryString) Then
            Return ReturnValue
        End If
        ReturnValue = CompanyORMDB.SQLServer.PPS100LB.QABUG.CDBSelect(Of CompanyORMDB.SQLServer.PPS100LB.QABUG)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)

        Return ReturnValue
    End Function

#End Region
#Region "新增 方法:CDBInsert"
    <DataObjectMethod(DataObjectMethodType.Insert)> _
    Public Shared Function CDBInsert(ByVal SourceObject As CompanyORMDB.SQLServer.PPS100LB.QABUG) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
        Return SourceObject.CDBInsert()
    End Function
#End Region
#Region "刪除 方法:CDBDelete"
    <DataObjectMethod(DataObjectMethodType.Delete)> _
    Public Shared Function CDBDelete(ByVal SourceObject As CompanyORMDB.SQLServer.PPS100LB.QABUG) As Integer
        If SourceObject.IsUsedForUser = True Then
            Return 0    '已使用者使用之缺陷不可刪除
        End If
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
        Return SourceObject.CDBDelete
    End Function
#End Region
#Region "修改 方法:CDBUpdate"
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Shared Function CDBUpdate(ByVal SourceObject As CompanyORMDB.SQLServer.PPS100LB.QABUG) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
        Return SourceObject.CDBSave
    End Function
#End Region

#Region "設定查詢條件至控制項 屬性:SetQryStringToControl"
    ''' <summary>
    ''' 設定查詢條件至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetQryStringToControl()
        Me.hfQryString.Value = Nothing
        Dim ReturnValue As New StringBuilder
        ReturnValue.Append("Select A.* From QABug A Where 1=1 ")

        If Not String.IsNullOrEmpty(tbBugNumbers.Text) Then
            tbBugNumbers.Text = tbBugNumbers.Text.ToUpper
            ReturnValue.Append(" AND Number in ('" & tbBugNumbers.Text.Replace(",", "','") & "')")
        End If

        If Not String.IsNullOrEmpty(tbBugNames.Text) Then
            ReturnValue.Append(" AND (")
            Dim IsFirstInLoop As Boolean = True
            For Each EachItem As String In tbBugNames.Text.Split(",")
                If Not IsFirstInLoop Then
                    ReturnValue.Append(" OR ")
                End If
                ReturnValue.Append(" CName like '%" & EachItem & "%' ")
                IsFirstInLoop = False
            Next
            ReturnValue.Append(")")
        End If

        Me.hfQryString.Value = ReturnValue.ToString & " Order by " & RadioButtonList1.SelectedValue
    End Sub
#End Region

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SetQryStringToControl()
        ListView1.DataBind()
    End Sub

    Private Sub ListView1_PreRender(sender As Object, e As EventArgs) Handles ListView1.PreRender
        Dim InsertAPL1Field As TextBox = ListView1.InsertItem.FindControl("APL1SortNumberTextBox")
        Dim InsertAPL2Field As TextBox = ListView1.InsertItem.FindControl("APL2SortNumberTextBox")
        Dim InsertBALField As TextBox = ListView1.InsertItem.FindControl("BALSortNumberTextBox")
        If String.IsNullOrEmpty(InsertAPL1Field.Text) Then
            InsertAPL1Field.Text = "999"
        End If
        If String.IsNullOrEmpty(InsertAPL2Field.Text) Then
            InsertAPL2Field.Text = "999"
        End If
        If String.IsNullOrEmpty(InsertBALField.Text) Then
            InsertBALField.Text = "999"
        End If
    End Sub
End Class