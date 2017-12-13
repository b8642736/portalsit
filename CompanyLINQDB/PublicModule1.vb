Public Module PublicModule1

#Region "取得目前伺服器IP 方法:GetCurrentDBServerIP"
    ''' <summary>
    ''' 取得目前伺服器IP
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCurrentDBServerIP() As String
        Dim GetStrings() As String = CType(My.Settings.Item("Server1_QCdb01"), String).Split(";")
        For Each EachItem As String In GetStrings
            If EachItem.Trim.ToUpper.Substring(0, 4) = "DATA" Then
                Return EachItem.Split("=")(1)
            End If
        Next
        Return Nothing
    End Function
#End Region

#Region "變更資料庫 方法:ChangeDBServer"
    ''' <summary>
    ''' 變更資料庫
    ''' </summary>
    ''' <param name="SetDBServerConnectString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ChangeDBServer(ByVal SetDBServerConnectString As String) As Boolean
        Dim SQLConnection As New Data.SqlClient.SqlConnection(SetDBServerConnectString)
        Try
            SQLConnection.Open()
            SQLConnection.Close()
        Catch ex As Exception
            Return False
        End Try
        My.Settings.Item("Server1_QCdb01") = SetDBServerConnectString
        Return True
    End Function
#End Region

#Region "取得資料來源中之下一位編號 方法:GetNextNumber"
    ''' <summary>
    ''' 取得資料來源中之下一位編號
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetNextNumber(ByVal SourceData As List(Of Integer), Optional ByVal StartNumber As Integer = 1) As Integer
        For EachNumber As Integer = StartNumber To Integer.MaxValue
            If SourceData.Contains(EachNumber) = False Then
                Return EachNumber
            End If
        Next
        Return -1
    End Function
#End Region

#Region "確認資料正確性模式 列舉:CheckDataErrorMode"
    ''' <summary>
    ''' 確認資料正確性模式
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum CheckDataErrorMode
        InsertMode = 0
        EditMode = 1
        Delete = 2
    End Enum
#End Region

End Module
