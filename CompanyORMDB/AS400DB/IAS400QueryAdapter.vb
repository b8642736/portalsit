Public Interface IAS400QueryAdapter

    Function SelectQueryGo(ByVal SetSourceQueryString As String) As DataTable
    Function ExecuteNonQueryGo(ByVal SetSourceQueryString As String) As Integer

End Interface
