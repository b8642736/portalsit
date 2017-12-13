Public Interface IWSDBSQLQuery

    Function GetServerTimeGo() As DateTime
    Function AS400SelectQueryGo(ByVal SetSourceQueryString As String, ByVal AcceptCodeReplay As String) As DataTable
    Function AS400ExecuteNonQueryGo(ByVal SetSourceQueryString As String, ByVal AcceptCodeReplay As String) As Integer
    Function SQLServerSelectQueryGo(ByVal SetSourceQueryString As String, ByVal SetSQLServerIPOrName As String, ByVal SetConnectDBName As String, ByVal AcceptCodeReplay As String) As DataTable
    Function SQLServerExecuteNonQueryGo(ByVal SetSourceQueryString As String, ByVal SetSQLServerIPOrName As String, ByVal SetConnectDBName As String, ByVal AcceptCodeReplay As String) As Integer
End Interface
