Public Class FAMExtendUse
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="QryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryString As String) As List(Of CompanyORMDB.AST501LB.ASTEXTPF)
        If String.IsNullOrEmpty(QryString) Then
            Return New List(Of CompanyORMDB.AST501LB.ASTEXTPF)
        End If
        Return CompanyORMDB.AST501LB.ASTEXTPF.CDBSelect(Of CompanyORMDB.AST501LB.ASTEXTPF)(QryString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
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
    Public Shared Function Insert(ByVal SourceObject As CompanyORMDB.AST501LB.ASTEXTPF) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        If String.IsNullOrEmpty(SourceObject.CDBMemberName) Then
            Return 0
        End If
        Return SourceObject.CDBInsert()
    End Function
#End Region
#Region "修改 方法:Update"
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <param name="SourceObject"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Shared Function Update(ByVal SourceObject As CompanyORMDB.AST501LB.ASTEXTPF) As Integer
        If String.IsNullOrEmpty(SourceObject.CDBMemberName) Then
            Return 0
        End If
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return SourceObject.CDBSave
    End Function
#End Region
#Region "刪除 方法:Delete"
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <param name="SourceObject"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Delete)> _
    Public Shared Function Delete(ByVal SourceObject As CompanyORMDB.AST501LB.ASTEXTPF) As Integer
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
        SQLString = " Select A.* From @#AST500LB.AST101PF.ASTF A " & RadioButtonList1.SelectedValue & _
                    " Where (USLAFF + N7611*100) =" & tbYearMonth.Text.Trim & " ORDER BY A.CODE "
        Dim SearchResult1 As List(Of CompanyORMDB.AST500LB.AST101PF) = CompanyORMDB.AST500LB.AST101PF.CDBSelect(Of CompanyORMDB.AST500LB.AST101PF)(SQLString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        SQLString = " Select A.* From @#AST501LB.ASTEXTPF A Where FACNAM='" & RadioButtonList1.SelectedValue & "' " _
            & " AND YDATE =" & tbYearMonth.Text.Trim & " ORDER BY A.CODE "
        Dim SearchResult2 As List(Of CompanyORMDB.AST501LB.ASTEXTPF) = CompanyORMDB.AST501LB.ASTEXTPF.CDBSelect(Of CompanyORMDB.AST501LB.ASTEXTPF)(SQLString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

        For Each EachItem In SearchResult1
            Dim FindASTEXPF As CompanyORMDB.AST501LB.ASTEXTPF = (From A In SearchResult2 Where A.NUMBER = EachItem.NUMBER Select A).FirstOrDefault
            If IsNothing(FindASTEXPF) Then
                FindASTEXPF = New CompanyORMDB.AST501LB.ASTEXTPF
                With FindASTEXPF
                    .NUMBER = EachItem.NUMBER
                    .YDATE = EachItem.USLAFF + EachItem.N7611 * 100
                    .EXTYER = 1
                End With
                FindASTEXPF.CDBSave()
            End If
        Next
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

    Private Sub ListView1_PreRender(sender As Object, e As EventArgs) Handles ListView1.PreRender
        Dim FACNAMDropDownList As DropDownList = ListView1.InsertItem.FindControl("FACNAMDropDownList")
        If Not IsNothing(FACNAMDropDownList) Then
            FACNAMDropDownList.SelectedValue = RadioButtonList1.SelectedValue
        End If
    End Sub
End Class