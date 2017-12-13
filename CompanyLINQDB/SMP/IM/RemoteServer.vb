Partial Public Class RemoteServer

#Region "所有上線中用戶端 屬性:AllOnLineRemoteClient"
    Private _AllOnLineRemoteClient As List(Of CompanyORMDB.SQLServer.IM.RemoteClient)
    ''' <summary>
    ''' 所有上線中用戶端
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property AllOnLineRemoteClient() As List(Of CompanyORMDB.SQLServer.IM.RemoteClient)
        Get
            Dim NoticeClients As List(Of CompanyORMDB.SQLServer.IM.RemoteClient) = Nothing
            Static LastGetDataTime As DateTime = New DateTime(2000, 1, 1)
            If IsNothing(NoticeClients) OrElse Now.Subtract(LastGetDataTime).TotalSeconds > 20 Then
                _AllOnLineRemoteClient = CompanyORMDB.SQLServer.IM.SMPMessageNotice.DBRemoteClientConnectToServersOnline(GetType(CompanyORMDB.SQLServer.IM.SMPMessageNotice), 3)
            End If
            LastGetDataTime = Now
            Return _AllOnLineRemoteClient
        End Get
    End Property
#End Region

#Region "是否上線中 屬性:IsOnLine"
    ''' <summary>
    ''' 是否上線中
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsOnLine() As Boolean
        Get
            Dim AllOnLineRemoteServer As List(Of CompanyORMDB.SQLServer.IM.RemoteServer) = (From A In AllOnLineRemoteClient Select A.ConnectToRemoteServer).ToList
            Return Not IsNothing((From A In AllOnLineRemoteServer Where A.CPUNumber.Trim = Me.CPUNumber.Trim And A.RegisterClassName.Trim = Me.RegisterClassName.Trim And A.Port = Me.Port And A.RemoteProtocol = Me.RemoteProtocol Select A).FirstOrDefault)
        End Get
    End Property
#End Region

End Class
