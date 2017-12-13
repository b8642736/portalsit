Public Class AST106PF
    Private Shared AS400DBAdapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    Public Shared Function GetSA_AST106PF_DEPTSA() As List(Of String)

        'Dim DBService As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        'Dim AST101PFNumbers As New List(Of String)
        'For Each EachItem As Data.DataRow In DBService.SelectQuery("Select NUMBER From @#AST500LB.AST101PF.ASTFSA Where DEPT='SA'").Rows
        '    AST101PFNumbers.Add(EachItem.Item("NUMBER"))
        'Next
        'Dim AST106PFResult As List(Of AST106PF) = GetSelectResult("Select NUMBER,DEPTSA From @#AST500LB.AST106PF Where SEQ=1 Order by DEPTSA")

        'Return (From A In AST106PFResult Where AST101PFNumbers.Contains(A.NUMBER) Select A.DEPTSA).Distinct.ToList

        Dim ReturnValue As New List(Of String)
        ReturnValue.AddRange(GetAST106PF_DEPTSA("ASTFSA"))
        ReturnValue.AddRange(GetAST106PF_DEPTSA("ASTFAA"))
        ReturnValue.AddRange(GetAST106PF_DEPTSA("ASTFAB"))
        ReturnValue.AddRange(GetAST106PF_DEPTSA("ASTFNA"))
        ReturnValue.AddRange(GetAST106PF_DEPTSA("ASTFQA"))
        ReturnValue.AddRange(GetAST106PF_DEPTSA("ASTFRA"))
        ReturnValue.AddRange(GetAST106PF_DEPTSA("ASTFRC"))
        ReturnValue.AddRange(GetAST106PF_DEPTSA("ASTFRD"))
        Return ReturnValue

        'Dim SQLQry As String = Nothing
        'SQLQry = "Select DISTINCT DEPTSA FROM @#AST500LB.AST106PF.ASTFSA Where NUMBER IN (Select Number From @#AST500LB.AST101PF.ASTFSA Where DEPT='SA') AND SEQ=1 Order by DEPTSA"
        'SQLQry &= " UNION " & "Select DISTINCT DEPTSA FROM @#AST500LB.AST106PF.ASTFAA Where NUMBER IN (Select Number From @#AST500LB.AST101PF.ASTFAA ) AND SEQ=1 Order by DEPTSA"
        'SQLQry &= " UNION " & "Select DISTINCT DEPTSA FROM @#AST500LB.AST106PF.ASTFAB Where NUMBER IN (Select Number From @#AST500LB.AST101PF.ASTFAB ) AND SEQ=1 Order by DEPTSA"
        'SQLQry &= " UNION " & "Select DISTINCT DEPTSA FROM @#AST500LB.AST106PF.ASTFNA Where NUMBER IN (Select Number From @#AST500LB.AST101PF.ASTFNA ) AND SEQ=1 Order by DEPTSA"
        'SQLQry &= " UNION " & "Select DISTINCT DEPTSA FROM @#AST500LB.AST106PF.ASTFQA Where NUMBER IN (Select Number From @#AST500LB.AST101PF.ASTFQA ) AND SEQ=1 Order by DEPTSA"
        'SQLQry &= " UNION " & "Select DISTINCT DEPTSA FROM @#AST500LB.AST106PF.ASTFRA Where NUMBER IN (Select Number From @#AST500LB.AST101PF.ASTFRA ) AND SEQ=1 Order by DEPTSA"
        'SQLQry &= " UNION " & "Select DISTINCT DEPTSA FROM @#AST500LB.AST106PF.ASTFRC Where NUMBER IN (Select Number From @#AST500LB.AST101PF.ASTFRC ) AND SEQ=1 Order by DEPTSA"
        'SQLQry &= " UNION " & "Select DISTINCT DEPTSA FROM @#AST500LB.AST106PF.ASTFRD Where NUMBER IN (Select Number From @#AST500LB.AST101PF.ASTFRD ) AND SEQ=1 Order by DEPTSA"
        'Return (From A In AS400DBAdapter.SelectQuery(SQLQry) Select CType(A.Item("DEPTSA"), String)).ToList
    End Function

    Public Shared Function GetAST106PF_DEPTSA(ByVal MemberName As String) As List(Of String)
        Dim SQLQry As String = Nothing
        Select Case True
            Case MemberName.ToUpper = "DEPTSA"
                SQLQry = "Select DISTINCT DEPTSA FROM @#AST500LB.AST106PF." & MemberName & " Where NUMBER IN (Select Number From @#AST500LB.AST101PF." & MemberName & " Where DEPT='SA') AND SEQ=1 Order by DEPTSA"
            Case Else
                SQLQry = "Select DISTINCT DEPTSA FROM @#AST500LB.AST106PF." & MemberName & " Where NUMBER IN (Select Number From @#AST500LB.AST101PF." & MemberName & " ) AND SEQ=1 Order by DEPTSA"
        End Select
        Return (From A In AS400DBAdapter.SelectQuery(SQLQry) Select CType(A.Item("DEPTSA"), String)).ToList

    End Function


    Friend Shared Function GetSelectResult(ByVal SelectString As String) As List(Of AST106PF)
        'Dim DBService As New CompanyLINQDB.AS400SQLQuery
        Dim DBService As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim ReturnValue As New List(Of AST106PF)
        Dim QueryResult As DataTable = DBService.SelectQuery(SelectString)
        If IsNothing(QueryResult) Then
            Return ReturnValue
        End If
        For Each EachItem As DataRow In DBService.SelectQuery(SelectString).Rows
            Dim AddItem As New AST106PF
            With AddItem
                .NUMBER = EachItem.Item("NUMBER")
                .DEPTSA = EachItem.Item("DEPTSA")
            End With
            ReturnValue.Add(AddItem)
        Next
        Return ReturnValue
    End Function

    Private _DEPTSA As String
    Public Property DEPTSA() As String
        Get
            Return _DEPTSA
        End Get
        Set(ByVal value As String)
            _DEPTSA = value
        End Set
    End Property


    Private _NUMBER As String
    Public Property NUMBER() As String
        Get
            Return _NUMBER
        End Get
        Set(ByVal value As String)
            _NUMBER = value
        End Set
    End Property

End Class
