Public Class AddAsset
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="QryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryString As String) As List(Of CompanyORMDB.AST501LB.AST001PFEx)
        If String.IsNullOrEmpty(QryString) OrElse QryString.Trim.Length = 0 Then
            Return New List(Of CompanyORMDB.AST501LB.AST001PFEx)
        End If
        Dim SearchResult As List(Of CompanyORMDB.AST501LB.AST001PFEx) = CompanyORMDB.AST501LB.AST001PFEx.CDBSelect(Of CompanyORMDB.AST501LB.AST001PFEx)(QryString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        For Each EachItem In SearchResult
            EachItem.ReadAST106PFToMe()
        Next
        Return SearchResult
    End Function
#End Region
#Region "新增 方法:CDBInsert"
    <DataObjectMethod(DataObjectMethodType.Insert)> _
    Public Shared Function CDBInsert(ByVal SourceObject As CompanyORMDB.AST501LB.AST001PFEx) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        If String.IsNullOrEmpty(SourceObject.CDBMemberName) Then
            Return 0
        End If
        Return SourceObject.CDBInsert()
    End Function
#End Region
#Region "修改 方法:CDBUpdate"
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Shared Function CDBUpdate(ByVal SourceObject As CompanyORMDB.AST501LB.AST001PFEx) As Integer
        If String.IsNullOrEmpty(SourceObject.CDBMemberName) Then
            Return 0
        End If
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return SourceObject.CDBSave
    End Function
#End Region
#Region "刪除 方法:CDBDelete"
    <DataObjectMethod(DataObjectMethodType.Delete)> _
    Public Shared Function CDBDelete(ByVal SourceObject As CompanyORMDB.AST501LB.AST001PFEx) As Integer
        If String.IsNullOrEmpty(SourceObject.CDBMemberName) Then
            Return 0
        End If
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return SourceObject.CDBDelete()
    End Function
#End Region

#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim SQLString As String = Nothing
        SQLString = " Select A.* From @#AST501LB.AST001PF.ASTF" & RadioButtonList1.SelectedValue & " A ORDER BY A.CODE "
        Me.hfQryString.Value = SQLString
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim SetYearMonth As Date = Now
            If Now >= (New Date(Now.Year, Now.Month, 1)) AndAlso Now < (New Date(Now.Year, Now.Month, 7)) Then
                SetYearMonth = Now.AddMonths(-1)
            End If
            tbYearMonth.Text = Format(SetYearMonth, "yyyy") - 1911 & Format(SetYearMonth, "MM")
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.MakQryStringToControl()
        Me.ListView1.DataBind()
    End Sub

    Private Sub odsSearhResult_Inserting(sender As Object, e As ObjectDataSourceMethodEventArgs) Handles odsSearhResult.Inserting, odsSearhResult.Deleting, odsSearhResult.Updating
        CType(e.InputParameters(0), CompanyORMDB.AST501LB.AST001PFEx).CDBMemberName = "ASTF" & RadioButtonList1.SelectedValue
    End Sub

    Private Sub ListView1_PreRender(sender As Object, e As EventArgs) Handles ListView1.PreRender
        Dim CODETextbox As TextBox = ListView1.InsertItem.FindControl("CODETextBox")
        If String.IsNullOrEmpty(CODETextbox.Text) OrElse CODETextbox.Text.Trim.Length = 0 Then
            CODETextbox.Text = "A"
        End If
        Dim QUANTTextBox As TextBox = ListView1.InsertItem.FindControl("QUANTTextBox")
        If String.IsNullOrEmpty(QUANTTextBox.Text) OrElse QUANTTextBox.Text.Trim.Length = 0 Then
            QUANTTextBox.Text = "1"
        End If
        '入帳年月(購置年月)
        Dim DATETextBox As TextBox = ListView1.InsertItem.FindControl("DATETextBox")
        If String.IsNullOrEmpty(DATETextBox.Text) OrElse DATETextBox.Text.Trim.Length = 0 Then
            DATETextBox.Text = tbYearMonth.Text
        End If
        Dim USLAFFTextBox As TextBox = ListView1.InsertItem.FindControl("USLAFFTextBox")
        If String.IsNullOrEmpty(USLAFFTextBox.Text) OrElse USLAFFTextBox.Text.Trim.Length = 0 Then
            USLAFFTextBox.Text = "1"
        End If
        '發生年月
        Dim DATENTextBox As TextBox = ListView1.InsertItem.FindControl("DATENTextBox")
        If String.IsNullOrEmpty(DATENTextBox.Text) OrElse DATENTextBox.Text.Trim.Length = 0 Then
            DATENTextBox.Text = tbYearMonth.Text
        End If
        '折舊
        Dim DEPRECTextBox As TextBox = ListView1.InsertItem.FindControl("DEPRECTextBox")
        If String.IsNullOrEmpty(DEPRECTextBox.Text) OrElse DEPRECTextBox.Text.Trim.Length = 0 Then
            DEPRECTextBox.Text = "1"
        End If
        '序號
        Dim SEQTextBox As TextBox = ListView1.InsertItem.FindControl("SEQTextBox")
        Dim HiddenField As HiddenField = ListView1.InsertItem.FindControl("HiddenField1")
        If String.IsNullOrEmpty(SEQTextBox.Text) OrElse SEQTextBox.Text.Trim.Length = 0 Then
            SEQTextBox.Text = "1"
            HiddenField.Value = "1"
        End If
    End Sub

End Class