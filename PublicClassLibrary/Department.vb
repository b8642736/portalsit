Imports System.Text
Imports CompanyORMDB

Public Class Department
    Private WP_AS400Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

#Region "getDepartmentTable : 取得所有部門TABLE"
    Public Function getDepartmentTable() As DataTable
        Dim querySQL As New StringBuilder
        querySQL.Append("SELECT pqdp1,pqdp2 " & vbNewLine)
        querySQL.Append("FROM @#PLT000LB.PQDDPTl2 " & vbNewLine)
        querySQL.Append("WHERE 1=1 " & vbNewLine)
        querySQL.Append("ORDER BY pqdp1 " & vbNewLine)
        Dim queryDataTable As DataTable = WP_AS400Adapter.SelectQuery(querySQL.ToString)
        Return queryDataTable
    End Function
#End Region
#Region "getDepartmentName : 取得部門中文名稱"
    Public Function getChineseDepartmentName(ByVal oid As String) As String
        Dim querySQL As New StringBuilder
        querySQL.Append("SELECT pqdp2 " & vbNewLine)
        querySQL.Append("FROM @#PLT000LB.PQDDPTl2 " & vbNewLine)
        querySQL.Append("WHERE 1=1 " & vbNewLine)
        querySQL.Append("AND pqdp1 = '" & oid & "'" & vbNewLine)
        querySQL.Append("ORDER BY pqdp1 " & vbNewLine)
        Dim queryDataTable As DataTable = WP_AS400Adapter.SelectQuery(querySQL.ToString)
        If queryDataTable.Rows.Count = 0 Then
            Return "---"
        Else
            Return queryDataTable.Rows(0).Item(0).ToString
        End If
    End Function
#End Region
#Region "getDepartmentTable : 取得部門會計代號"
    Public Function getDepartmentCode(ByVal oid As String) As String
        Dim querySQL As New StringBuilder
        querySQL.Append("SELECT pqdp3 " & vbNewLine)
        querySQL.Append("FROM @#PLT000LB.PQDDPTl2 " & vbNewLine)
        querySQL.Append("WHERE 1=1 " & vbNewLine)
        querySQL.Append("AND pqdp1 = '" & oid & "'" & vbNewLine)
        querySQL.Append("ORDER BY pqdp1 " & vbNewLine)
        Dim queryDataTable As DataTable = WP_AS400Adapter.SelectQuery(querySQL.ToString)
        If queryDataTable.Rows.Count = 0 Then
            Return "---"
        Else
            Return queryDataTable.Rows(0).Item(0).ToString
        End If
    End Function
#End Region
End Class
