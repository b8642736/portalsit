Namespace Portalsit2
    Partial Public Class WSDBSQLQuery
        Implements IWSDBSQLQuery

        Public Function GetServerTimeGo() As Date Implements IWSDBSQLQuery.GetServerTimeGo
            Return Me.GetServerTime
        End Function

        Public Function AS400ExecuteNonQueryGo(ByVal SetSourceQueryString As String, ByVal AcceptCodeReplay As String) As Integer Implements IWSDBSQLQuery.AS400ExecuteNonQueryGo
            Return Me.AS400ExecuteNonQuery(SetSourceQueryString, AcceptCodeReplay)
        End Function

        Public Function AS400SelectQueryGo(ByVal SetSourceQueryString As String, ByVal AcceptCodeReplay As String) As System.Data.DataTable Implements IWSDBSQLQuery.AS400SelectQueryGo
            Return Me.AS400SelectQuery(SetSourceQueryString, AcceptCodeReplay)
        End Function

        Public Function SQLServerSelectQueryGo(ByVal SetSourceQueryString As String, ByVal SetSQLServerIPOrName As String, ByVal SetConnectDBName As String, ByVal AcceptCodeReplay As String) As System.Data.DataTable Implements IWSDBSQLQuery.SQLServerSelectQueryGo
            Return Me.SQLServerSelectQuery(SetSourceQueryString, SetSQLServerIPOrName, SetConnectDBName, AcceptCodeReplay)
        End Function

        Public Function SQLServerExecuteNonQueryGo(ByVal SetSourceQueryString As String, ByVal SetSQLServerIPOrName As String, ByVal SetConnectDBName As String, ByVal AcceptCodeReplay As String) As Integer Implements IWSDBSQLQuery.SQLServerExecuteNonQueryGo
            Return Me.SQLServerExecuteNonQuery(SetSourceQueryString, SetSQLServerIPOrName, SetConnectDBName, AcceptCodeReplay)
        End Function

    End Class

End Namespace

Namespace Server04m
    Partial Public Class WSDBSQLQuery
        Implements IWSDBSQLQuery

        Public Function GetServerTimeGo() As Date Implements IWSDBSQLQuery.GetServerTimeGo
            Return Me.GetServerTime
        End Function

        Public Function AS400ExecuteNonQueryGo(ByVal SetSourceQueryString As String, ByVal AcceptCodeReplay As String) As Integer Implements IWSDBSQLQuery.AS400ExecuteNonQueryGo
            Return Me.AS400ExecuteNonQuery(SetSourceQueryString, AcceptCodeReplay)
        End Function

        Public Function AS400SelectQueryGo(ByVal SetSourceQueryString As String, ByVal AcceptCodeReplay As String) As System.Data.DataTable Implements IWSDBSQLQuery.AS400SelectQueryGo
            Return Me.AS400SelectQuery(SetSourceQueryString, AcceptCodeReplay)
        End Function

        Public Function SQLServerSelectQueryGo(ByVal SetSourceQueryString As String, ByVal SetSQLServerIPOrName As String, ByVal SetConnectDBName As String, ByVal AcceptCodeReplay As String) As System.Data.DataTable Implements IWSDBSQLQuery.SQLServerSelectQueryGo
            Return Me.SQLServerSelectQuery(SetSourceQueryString, SetSQLServerIPOrName, SetConnectDBName, AcceptCodeReplay)
        End Function

        Public Function SQLServerExecuteNonQueryGo(ByVal SetSourceQueryString As String, ByVal SetSQLServerIPOrName As String, ByVal SetConnectDBName As String, ByVal AcceptCodeReplay As String) As Integer Implements IWSDBSQLQuery.SQLServerExecuteNonQueryGo
            Return Me.SQLServerExecuteNonQuery(SetSourceQueryString, SetSQLServerIPOrName, SetConnectDBName, AcceptCodeReplay)
        End Function

    End Class

End Namespace

Namespace Server0bm
    Partial Public Class WSDBSQLQuery
        Implements IWSDBSQLQuery

        Public Function GetServerTimeGo() As Date Implements IWSDBSQLQuery.GetServerTimeGo
            Return Me.GetServerTime
        End Function

        Public Function AS400ExecuteNonQueryGo(ByVal SetSourceQueryString As String, ByVal AcceptCodeReplay As String) As Integer Implements IWSDBSQLQuery.AS400ExecuteNonQueryGo
            Return Me.AS400ExecuteNonQuery(SetSourceQueryString, AcceptCodeReplay)
        End Function

        Public Function AS400SelectQueryGo(ByVal SetSourceQueryString As String, ByVal AcceptCodeReplay As String) As System.Data.DataTable Implements IWSDBSQLQuery.AS400SelectQueryGo
            Return Me.AS400SelectQuery(SetSourceQueryString, AcceptCodeReplay)
        End Function

        Public Function SQLServerSelectQueryGo(ByVal SetSourceQueryString As String, ByVal SetSQLServerIPOrName As String, ByVal SetConnectDBName As String, ByVal AcceptCodeReplay As String) As System.Data.DataTable Implements IWSDBSQLQuery.SQLServerSelectQueryGo
            Return Me.SQLServerSelectQuery(SetSourceQueryString, SetSQLServerIPOrName, SetConnectDBName, AcceptCodeReplay)
        End Function

        Public Function SQLServerExecuteNonQueryGo(ByVal SetSourceQueryString As String, ByVal SetSQLServerIPOrName As String, ByVal SetConnectDBName As String, ByVal AcceptCodeReplay As String) As Integer Implements IWSDBSQLQuery.SQLServerExecuteNonQueryGo
            Return Me.SQLServerExecuteNonQuery(SetSourceQueryString, SetSQLServerIPOrName, SetConnectDBName, AcceptCodeReplay)
        End Function

    End Class

End Namespace
