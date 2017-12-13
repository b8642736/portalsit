Namespace SQLServer
    Namespace IM
        <Serializable()> _
        Public MustInherit Class RemottingClassRefObjectBase
            Inherits MarshalByRefObject

            Sub New(ByVal SetUseMode As WellKnownObjectMode, ByVal SetUsePort As Integer, ByVal SetUseRemoteProtocol As SQLServer.IM.RemoteProtocolType)
                If SetUsePort Mod 2 = 1 Then
                    Throw New Exception("伺服端使用之Port預設為偶數!")
                End If
                If IsNothing(InitialRemoteServer) Then
                    InitialRemoteServer = New SQLServer.IM.RemoteServer(Me.GetType, SetUseMode, SetUsePort, SetUseRemoteProtocol)
                End If
            End Sub

            Public Overrides Function InitializeLifetimeService() As Object
                Return Nothing
                'Return MyBase.InitializeLifetimeService()
            End Function

#Region "PC伺服端上線通知 函式:NoticeToReLoadClientConnectToServersFromDB"
            ''' <summary>
            ''' PC伺服端上線通知
            ''' </summary>
            ''' <param name="StartRemoteClassType"></param>
            ''' <remarks></remarks>
            Public Sub NoticeToReLoadClientConnectToServersFromDB(ByVal StartRemoteClassType As Type)
                ReLoadClientConnectToServersFromDB(StartRemoteClassType)
            End Sub
#End Region
#Region "取得本機伺服端系統資訊 屬性:GetDeviceInfo"
            ''' <summary>
            ''' 取得本機伺服端系統資訊
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Function GetDeviceInfo() As DeviceInformation
                Return New DeviceInformation
            End Function
#End Region
#Region "資料庫未存儲時第一個預設RemoteServer 屬性:InitialRemoteServer"

            <NonSerialized()> _
          Private _InitialRemoteServer As SQLServer.IM.RemoteServer
            ''' <summary>
            ''' 資料庫未存儲時第一個預設RemoteServer
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property InitialRemoteServer() As SQLServer.IM.RemoteServer
                Get
                    Return _InitialRemoteServer
                End Get
                Private Set(ByVal value As SQLServer.IM.RemoteServer)
                    _InitialRemoteServer = value
                End Set
            End Property
#End Region

#Region "啟用或建立啟用本機伺服物件(RremoteServer) 函式:StartUseOrCreateUseLocalRemoteServer"
            ''' <summary>
            ''' 啟用或建立啟用本機伺服物件(RremoteServer)
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Function StartUseOrCreateUseLocalRemoteServer() As RemoteServer
                'Dim QryString As String = "Select * From RemoteServer Where RegisterClassName='" & InitialRemoteServer.RegisterClassType.Name & "' AND CPUNumber='" & (New DeviceInformation).CpuIDs(0) & "'"
                Dim QryString As String = "Select * From RemoteServer Where RegisterClassName='" & InitialRemoteServer.RegisterClassType.Name & "' AND CPUNumber='" & (New DeviceInformation).CpuIDs(0) & "' AND IP='" & DeviceInformation.GetLocalIPs(0).Trim & "'"
                Dim FindRemoteServer As List(Of RemoteServer) = RemoteServer.CDBSelect(Of RemoteServer)(QryString, (New RemoteServer).CDBCurrentUseSQLQueryAdapter)
                If FindRemoteServer.Count = 0 Then
                    Dim NewRemoteServer As RemoteServer = New SQLServer.IM.RemoteServer(InitialRemoteServer.RegisterClassType, InitialRemoteServer.RemoteProtocol, InitialRemoteServer.Port, InitialRemoteServer.RemoteProtocol)
                    If RemoteServer.ServerRegisterAndSaveDB(InitialRemoteServer.RegisterClassType, NewRemoteServer, 1, 3) Then
                        CType(NewRemoteServer.AboutRemoteClient.RemoteClientProxyObject, RemottingClassRefObjectBase).NoticeToReLoadClientConnectToServersFromDB(InitialRemoteServer.RegisterClassType)
                        Return NewRemoteServer
                    Else
                        Return Nothing
                    End If
                    'Return IIf(RemoteServer.ServerRegisterAndSaveDB(InitialRemoteServer.RegisterClassType, NewRemoteServer, 1, 3), NewRemoteServer, Nothing)
                End If
                FindRemoteServer(0).RegisterClassType = InitialRemoteServer.RegisterClassType
                RemoteServer.ServerRegisterAndSaveDB(InitialRemoteServer.RegisterClassType, FindRemoteServer(0), 1, 3)

                '通知各已上線的站(重新載入)本站已註
                For Each EachItem As RemoteClient In DBRemoteClientConnectToServersOnline(InitialRemoteServer.RegisterClassType)
                    If EachItem.IsConnectToLocalRemoteServer Then
                        Continue For
                    End If
                    CType(EachItem.RemoteClientProxyObject, RemottingClassRefObjectBase).NoticeToReLoadClientConnectToServersFromDB(InitialRemoteServer.RegisterClassType)
                Next
                Return FindRemoteServer(0)
            End Function
#End Region
#Region "由資料庫重新載入所有Client端連線伺服物件 函式(Shared)/事件(Shared):ReLoadClientConnectToServersFromDB/ReLoadClientConnectToServersFromDB_Event"
            Shared Event ReLoadClientConnectToServersFromDB_Event(ByVal LoadRemoteClient As List(Of RemoteClient))
            ''' <summary>
            ''' 由資料庫重新載入所有Client端連線伺服物件
            ''' </summary>
            ''' <remarks></remarks>
            Public Shared Sub ReLoadClientConnectToServersFromDB(ByVal RegisterClassType As Type)

                For Each EachItem As RemoteClient In FindDBRemoteClientConnectToServers(RegisterClassType)
                    DBRemoteClientConnectToServers.Remove(EachItem)
                Next

                Dim QryString As String = "Select * From RemoteServer Where RegisterClassName='" & RegisterClassType.Name & "'"
                Dim SearchResult As List(Of RemoteServer) = RemoteServer.CDBSelect(Of RemoteServer)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.WebService, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "IM", QryString)

                If Not IsNothing(SearchResult) AndAlso SearchResult.Count > 0 Then
                    DBRemoteClientConnectToServers = New List(Of RemoteClient)
                    For Each EachItem As RemoteServer In SearchResult
                        DBRemoteClientConnectToServers.Add(New RemoteClient(EachItem))
                        EachItem.RegisterClassType = RegisterClassType
                    Next
                End If
                RaiseEvent ReLoadClientConnectToServersFromDB_Event(_DBRemoteClientConnectToServers)
            End Sub


#End Region
#Region "於DBRemoteClientConnectToServers中找尋某型別的RemoteClient (Shared)方法:FindDBRemoteClientConnectToServers"
            ''' <summary>
            ''' 於DBRemoteClientConnectToServers中找尋某型別的RemoteClient
            ''' </summary>
            ''' <param name="RegisterClassType"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Private Shared Function FindDBRemoteClientConnectToServers(ByVal RegisterClassType As Type) As List(Of RemoteClient)
                Dim ReturnValue As New List(Of RemoteClient)
                If IsNothing(DBRemoteClientConnectToServers) OrElse DBRemoteClientConnectToServers.Count = 0 Then
                    Return ReturnValue
                End If
                For Each EachItem As RemoteClient In DBRemoteClientConnectToServers
                    If EachItem.ConnectToRemoteServer.RegisterClassType Is RegisterClassType Then
                        ReturnValue.Add(EachItem)
                    End If
                Next
                Return ReturnValue
            End Function

#End Region
#Region "Client端連線資料庫所有伺服物件(資料範圍Sahred) 屬性:DBRemoteClientConnectToServers"
            ''' <summary>
            ''' Client端連線資料庫所有伺服物件
            ''' </summary>
            ''' <param name="RegisterClassType"></param>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Shared ReadOnly Property DBRemoteClientConnectToServers(ByVal RegisterClassType As Type) As List(Of RemoteClient)
                Get
                    Dim ReturnValue As List(Of RemoteClient) = FindDBRemoteClientConnectToServers(RegisterClassType)
                    If ReturnValue.Count = 0 Then
                        ReLoadClientConnectToServersFromDB(RegisterClassType)
                        ReturnValue = FindDBRemoteClientConnectToServers(RegisterClassType)
                    End If
                    Return ReturnValue
                End Get
            End Property
            ''' <summary>
            ''' Client端連線資料庫所有伺服物件
            ''' </summary>
            ''' <remarks></remarks>
            <NonSerialized()> _
            Private Shared _DBRemoteClientConnectToServers As New List(Of RemoteClient)
            ''' <summary>
            ''' Client端連線資料庫所有伺服物件(資料範圍Sahred)
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Private Shared Property DBRemoteClientConnectToServers() As List(Of RemoteClient)
                Get
                    Return _DBRemoteClientConnectToServers
                End Get
                Set(ByVal value As List(Of RemoteClient))
                    _DBRemoteClientConnectToServers = value
                End Set
            End Property
#End Region
#Region "Client端連線資料庫所有伺服物件(線上) 屬性(Shared):DBRemoteClientConnectToServersOnline"
            ''' <summary>
            ''' Client端連線資料庫所有伺服物件(線上)
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Shared ReadOnly Property DBRemoteClientConnectToServersOnline(ByVal RegisterClassType As Type, Optional ByVal LimitWaitSeconds As Integer = 3) As List(Of RemoteClient)
                Get
                    Dim FindRemoteClient As List(Of RemoteClient) = DBRemoteClientConnectToServers(RegisterClassType)
                    Dim ReturnValue As List(Of RemoteClient) = RemoteClient.FindDBRemoteClientsIsOnline(FindRemoteClient, LimitWaitSeconds)
                    If FindRemoteClient.Count > 0 AndAlso ReturnValue.Count = 0 Then   '因某些原因未取得線上RemoteClient,再取一次
                        ReturnValue = RemoteClient.FindDBRemoteClientsIsOnline(FindRemoteClient, LimitWaitSeconds)
                    End If
                    Return ReturnValue
                End Get
            End Property
#End Region
#Region "Client端連線資料庫本機伺服物件(線上) 屬性(Shared):DBRemoteClientConnectToLocalServerOnline"
            ''' <summary>
            ''' Client端連線資料庫本機伺服物件(線上)
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Shared ReadOnly Property DBRemoteClientConnectToLocalServerOnline(ByVal RegisterClassType As Type) As RemoteClient
                Get
                    For Each EachItem As RemoteClient In DBRemoteClientConnectToServersOnline(RegisterClassType)
                        If EachItem.IsConnectToLocalRemoteServer Then
                            Return EachItem
                        End If
                    Next
                    Return Nothing
                End Get
            End Property
#End Region



        End Class
    End Namespace
End Namespace

