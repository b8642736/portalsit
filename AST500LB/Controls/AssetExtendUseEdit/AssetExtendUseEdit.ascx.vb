Public Class AssetExtendUseEdit
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="QryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryString As String) As List(Of AST201PF)
        Return CompanyORMDB.AST500LB.AST201PF.CDBSelect(Of CompanyORMDB.AST500LB.AST201PF)(QryString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    End Function

#End Region
#Region "修改 方法:CDBUpdate"
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Shared Function CDBUpdate(ByVal SourceObject As AST201PF) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        SourceObject.CDBMemberName = "ASTFSA"
        Return SourceObject.CDBUpdate()
    End Function
#End Region
#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim SearchYearMonth As Integer
        If Now > New Date(Now.Year, Now.Month, 15) Then
            SearchYearMonth = Val(New CompanyORMDB.AS400DateConverter(Now).TwSevenCharsTypeData.Substring(0, 5))
        Else
            SearchYearMonth = Val(New CompanyORMDB.AS400DateConverter(Now.AddMonths(-1)).TwSevenCharsTypeData.Substring(0, 5))
        End If

        Dim SQLString As String = Nothing
        SQLString = "Select * From @#AST500LB.AST201PF.ASTFSA WHERE NUMBER IN ( Select NUMBER From @#AST500LB.AST101PF.ASTFSA WHERE (DATE + USLAFF*100 + N7611*100) = " & SearchYearMonth & ") order by NUMBER"
        Me.hfQryString.Value = SQLString
    End Sub
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakQryStringToControl()
        ListView1.DataBind()
    End Sub
End Class