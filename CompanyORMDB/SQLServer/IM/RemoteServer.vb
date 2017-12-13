Namespace SQLServer
    Namespace IM
        <Serializable()> _
        Public Class RemoteServer
            Inherits ClassDBSQLServer

#Region "New"
            Public Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "IM")
            End Sub

            Sub New(ByVal SetRegisterClassType As Type, ByVal SetUseMode As WellKnownObjectMode, ByVal SetUsePort As Integer, ByVal SetUseRemoteProtocol As RemoteProtocolType)
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "IM")
                Dim GetLocalIPs As List(Of String) = DeviceInformation.GetLocalIPs
                If GetLocalIPs.Count > 0 Then
                    Me.IP = GetLocalIPs.Item(0)
                End If

                Me.CPUNumber = DeviceInformation.GetCpuIDs.Item(0).ToString
                Me.RegisterClassType = SetRegisterClassType
                Me.Port = SetUsePort
                Me.RemoteProtocol = SetUseRemoteProtocol
                Me.Mode = SetUseMode
                Me.LastUnRegisteredTime = New DateTime(2000, 1, 1)
            End Sub
#End Region

#Region "處理器編號 屬性:CPUNumber"

            Private _CPUNumber As String
            ''' <summary>
            ''' 處理器編號
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property CPUNumber() As String
                Get
                    Return _CPUNumber
                End Get
                Set(ByVal value As String)
                    _CPUNumber = value
                End Set
            End Property

#End Region
#Region "註冊類別名稱 屬性:RegisterClassName"

            Private _RegisterClassName As String
            ''' <summary>
            ''' 使用通道名稱
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property RegisterClassName() As String
                Get
                    Return _RegisterClassName
                End Get
                Private Set(ByVal value As String)
                    _RegisterClassName = value
                End Set
            End Property
#End Region
#Region "連結Port 屬性:Port"

            Private _Port As Integer = 0
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
          Public Property Port() As Integer
                Get
                    Return _Port
                End Get
                Set(ByVal value As Integer)
                    If value > IPEndPoint.MaxPort Then
                        value = IPEndPoint.MaxPort
                    End If
                    If value < IPEndPoint.MinPort Then
                        value = IPEndPoint.MinPort
                    End If
                    'If value <> _Port Then
                    '    ServerUnRegister()  '反註冊伺服物件
                    'End If
                    _Port = value
                End Set
            End Property

#End Region
#Region "連線通訊協定 屬性:RemoteProtocol"

            Private _RemoteProtocol As RemoteProtocolType
            ''' <summary>
            ''' 連線通訊協定
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property RemoteProtocol() As RemoteProtocolType
                Get
                    Return _RemoteProtocol
                End Get
                Set(ByVal value As RemoteProtocolType)
                    _RemoteProtocol = value
                End Set
            End Property

#End Region
#Region "伺服端IP 屬性:IP"

            Private _IP As String
            ''' <summary>
            ''' 伺服端IP
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property IP() As String
                Get
                    Return _IP.Trim
                End Get
                Set(ByVal value As String)
                    _IP = value
                End Set
            End Property

#End Region
#Region "使用模式 屬性:Mode"

            Private _Mode As WellKnownObjectMode
            ''' <summary>
            ''' 使用模式
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Mode() As WellKnownObjectMode
                Get
                    Return _Mode
                End Get
                Set(ByVal value As WellKnownObjectMode)
                    _Mode = value
                End Set
            End Property

#End Region
#Region "最後伺服端註冊時間 屬性:LastRegisteredTime"
            Private _LastRegisteredTime As System.DateTime
            ''' <summary>
            ''' 最後伺服端註冊時間
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property LastRegisteredTime() As System.DateTime
                Get
                    Return _LastRegisteredTime
                End Get
                Set(ByVal value As System.DateTime)
                    _LastRegisteredTime = value
                End Set
            End Property
#End Region
#Region "最後伺服端反註冊時間 屬性:LastUnRegisteredTime"
            Private _LastUnRegisteredTime As DateTime
            ''' <summary>
            ''' 最後伺服端反註冊時間
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property LastUnRegisteredTime() As DateTime
                Get
                    Return _LastUnRegisteredTime
                End Get
                Set(ByVal value As DateTime)
                    _LastUnRegisteredTime = value
                End Set
            End Property
#End Region
#Region "WindowLoginName 屬性:WindowLoginName"
            Private _WindowLoginName As System.String
            ''' <summary>
            ''' WindowLoginName
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property WindowLoginName() As System.String
                Get
                    Return _WindowLoginName
                End Get
                Set(ByVal value As System.String)
                    _WindowLoginName = value
                End Set
            End Property
#End Region


#Region "註冊類別型別 屬性:RegisterClassType"

            Private _RegisterClassType As Type
            ''' <summary>
            ''' 註冊類別型別
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Public Property RegisterClassType() As Type
                Get
                    Return _RegisterClassType
                End Get
                Set(ByVal value As Type)
                    _RegisterClassType = value
                    If IsNothing(_RegisterClassType) Then
                        Me.RegisterClassName = Nothing
                    Else
                        Me.RegisterClassName = _RegisterClassType.Name
                    End If
                End Set
            End Property

#End Region
#Region "是否為本機伺服端 屬性:IsLocalRemoteServer"
            ''' <summary>
            ''' 是否為本機伺服端
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Public ReadOnly Property IsLocalRemoteServer() As Boolean
                Get
                    Return Me.CPUNumber = DeviceInformation.GetCpuIDs.Item(0).ToString
                End Get
            End Property

#End Region
#Region "註冊通道 函式:RegisterChannel"
            ''' <summary>
            ''' 註冊通道
            ''' </summary>
            ''' <remarks></remarks>
            Public Sub RegisterChannel()
                Dim FindTheServerRegisterChannelAndPort = TheServerRegisterChannelAndPort
                If Not IsNothing(FindTheServerRegisterChannelAndPort) Then
                    Exit Sub
                End If
                Dim RegOneChannel As IChannel = Nothing
                Dim ServerProvider As New BinaryServerFormatterSinkProvider
                ServerProvider.TypeFilterLevel = Formatters.TypeFilterLevel.Full
                Select Case True
                    Case Me.RemoteProtocol = RemoteProtocolType.Tcp
                        RegOneChannel = New TcpServerChannel(Guid.NewGuid.ToString, Port, ServerProvider)
                    Case Me.RemoteProtocol = RemoteProtocolType.Http
                        RegOneChannel = New Http.HttpServerChannel(Guid.NewGuid.ToString, Port, ServerProvider)
                End Select

                ChannelServices.RegisterChannel(RegOneChannel, False)
                AlreadyRegisteredChannelPorts.Add(New ChannelAndPortClass(Port, RegOneChannel))
            End Sub
#End Region
#Region "反註冊通道 函式:UnRegisterChannel"
            ''' <summary>
            ''' 註冊通道
            ''' </summary>
            ''' <remarks></remarks>
            Public Sub UnRegisterChannel()
                Dim FindTheServerRegisterChannelAndPort = TheServerRegisterChannelAndPort
                If IsNothing(FindTheServerRegisterChannelAndPort) Then
                    Exit Sub
                End If
                ChannelServices.UnregisterChannel(FindTheServerRegisterChannelAndPort.RegisterChannel)
                AlreadyRegisteredChannelPorts.Remove(FindTheServerRegisterChannelAndPort)
            End Sub
#End Region
#Region "此RemoteServer註冊通道與Port 屬性:TheServerRegisterChannelAndPort"
            ''' <summary>
            ''' 此RemoteServer註冊通道與Port
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Public ReadOnly Property TheServerRegisterChannelAndPort() As ChannelAndPortClass
                Get
                    Dim ReturnValue As ChannelAndPortClass = Nothing
                    For Each EachItem As ChannelAndPortClass In RemoteServer.AlreadyRegisteredChannelPorts
                        If EachItem.RegisterPort = Me.Port Then
                            ReturnValue = EachItem
                            Exit For
                        End If
                    Next
                    Return ReturnValue
                End Get
            End Property

#End Region
#Region "相關RemoteClient 屬性:AboutRemoteClient"
            ''' <summary>
            ''' 相關RemoteClients
            ''' </summary>
            ''' <remarks></remarks>
            Private _AboutRemoteClient As RemoteClient
            ''' <summary>
            ''' 相關RemoteClients
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Public Property AboutRemoteClient() As RemoteClient
                Get
                    If IsNothing(_AboutRemoteClient) Then
                        _AboutRemoteClient = New RemoteClient(Me)
                    End If
                    Return _AboutRemoteClient
                End Get
                Private Set(ByVal value As RemoteClient)
                    _AboutRemoteClient = value
                End Set
            End Property
#End Region
#Region "已註冊Port 屬性(Shared):AlreadyRegisteredChannelPorts"

            Private Shared _AlreadyRegisteredChannelPorts As New List(Of ChannelAndPortClass)
            ''' <summary>
            ''' 已註冊Port
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Public Shared Property AlreadyRegisteredChannelPorts() As List(Of ChannelAndPortClass)
                Get
                    Return _AlreadyRegisteredChannelPorts
                End Get
                Private Set(ByVal value As List(Of ChannelAndPortClass))
                    _AlreadyRegisteredChannelPorts = value
                End Set
            End Property

#End Region


#Region "已註冊ChannelAndPort類別 類別:ChannelAndPortClass"
            ''' <summary>
            ''' 已註冊ChannelAndPort結構
            ''' </summary>
            ''' <remarks></remarks>
            Class ChannelAndPortClass

                Sub New(ByVal SetRegisterPort As Integer, ByVal SetRegisterChannel As IChannel)
                    Me.RegisterPort = SetRegisterPort
                    Me.RegisterChannel = SetRegisterChannel
                End Sub
                Private _RegisterPort As Integer
                Public Property RegisterPort() As Integer
                    Get
                        Return _RegisterPort
                    End Get
                    Set(ByVal value As Integer)
                        _RegisterPort = value
                    End Set
                End Property


                Private _RegisterChannel As IChannel
                Public Property RegisterChannel() As IChannel
                    Get
                        Return _RegisterChannel
                    End Get
                    Set(ByVal value As IChannel)
                        _RegisterChannel = value
                    End Set
                End Property

            End Class
#End Region



#Region "註冊伺服物件並儲存更新資料庫 Shared方法:ServerRegisterAndSaveDB"
            ''' <summary>
            ''' 註冊伺服物件並儲存更新資料庫
            ''' </summary>
            ''' <param name="SetRemoteServer"></param>
            ''' <param name="TryTimes"></param>
            ''' <param name="ErrorWaitMilliseconds"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Shared Function ServerRegisterAndSaveDB(ByVal RegObjectType As Type, ByVal SetRemoteServer As CompanyORMDB.SQLServer.IM.RemoteServer, ByVal TryTimes As Integer, ByVal ErrorWaitMilliseconds As Integer) As Boolean
                Dim ReturnValue As Boolean = ServerRegister(RegObjectType, SetRemoteServer, TryTimes, ErrorWaitMilliseconds)
                If ReturnValue Then
                    Dim WSAdapter As New CompanyORMDB.WSDBSQLQueryAdapter(True)
                    SetRemoteServer.LastRegisteredTime = WSAdapter.GetServerTime
                    SetRemoteServer.WindowLoginName = My.User.Name
                    SetRemoteServer.CDBSave()
                End If
                Return ReturnValue
            End Function

            ''' <summary>
            ''' 註冊伺服物件並儲存更新資料庫
            ''' </summary>
            ''' <param name="SetRemoteServer"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Shared Function ServerRegisterAndSaveDB(ByVal RegObjectType As Type, ByVal SetRemoteServer As CompanyORMDB.SQLServer.IM.RemoteServer) As Boolean
                Dim ReturnValue As Boolean = ServerRegister(RegObjectType, SetRemoteServer)
                If ReturnValue Then
                    Dim WSAdapter As New CompanyORMDB.WSDBSQLQueryAdapter(True)
                    SetRemoteServer.LastRegisteredTime = WSAdapter.GetServerTime
                    SetRemoteServer.CDBSave()
                End If
                Return ReturnValue
            End Function
#End Region
#Region "註冊伺服物件 Shared方法:ServerRegister"
            ''' <summary>
            ''' 註冊伺服物件
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Shared Function ServerRegister(ByVal RegObjectType As Type, ByVal SetRemoteServer As CompanyORMDB.SQLServer.IM.RemoteServer, ByVal TryTimes As Integer, ByVal ErrorWaitMilliseconds As Integer) As Boolean
                Dim myTryTimes As Integer = 1
                Dim ReturnValue As Boolean = False
                SetRemoteServer.UnRegisterChannel()
                If TryTimes < myTryTimes Then
                    Return ReturnValue
                End If
                Do While myTryTimes <= TryTimes
                    Try
                        ReturnValue = ServerRegister(RegObjectType, SetRemoteServer)
                        Exit Do
                    Catch ex As Exception
                        ReturnValue = False
                        System.Threading.Thread.Sleep(ErrorWaitMilliseconds)
                    End Try
                    myTryTimes += 1
                Loop
                Return ReturnValue

            End Function
            ''' <summary>
            ''' 註冊伺服物件
            ''' </summary>
            ''' <param name="SetRemoteServer"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Shared Function ServerRegister(ByVal RegObjectType As Type, ByVal SetRemoteServer As CompanyORMDB.SQLServer.IM.RemoteServer) As Boolean
                If SetRemoteServer.IsLocalRemoteServer = False Then
                    Throw New Exception("不可註冊非本機 RemoteServer 之Remotting!")
                End If
                Try

                    If IsNothing(SetRemoteServer.TheServerRegisterChannelAndPort) Then   '通道註冊
                        SetRemoteServer.RegisterChannel()
                    End If

                    RemotingConfiguration.RegisterWellKnownServiceType(RegObjectType, SetRemoteServer.RegisterClassName, SetRemoteServer.Mode)

                    'Dim AddRemoteClient As RemoteClient = New RemoteClient(Me)
                    'AddRemoteClient.RemoteClientProxyObject = AddRemoteClient.GetObject(Of RegisterObjectType)()
                    'AboutRemoteClients.Add(AddRemoteClient)

                Catch ex1 As Exception
                    Throw New IO.IOException("註冊伺服類別失敗!" & ex1.ToString)
                End Try
                Return True
            End Function

#End Region



        End Class

#Region "RemoteClient類別 類別:RemoteClient"
        ''' <summary>
        ''' RemoteClient類別
        ''' </summary>
        ''' <remarks></remarks>
        Public Class RemoteClient

#Region "建構 初始值設定"

            Sub New(ByVal SourceRemoteServer As RemoteServer)
                ConnectToRemoteServer = SourceRemoteServer
            End Sub

#End Region

#Region "是否連線至本機伺服端 屬性:IsConnectToLocalRemoteServer"
            ''' <summary>
            ''' 是否連線至本機伺服端
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public ReadOnly Property IsConnectToLocalRemoteServer() As Boolean
                Get
                    If IsNothing(ConnectToRemoteServer) Then
                        Return False
                    End If
                    Return Me.ConnectToRemoteServer.IsLocalRemoteServer
                End Get
            End Property
#End Region
#Region "連線至伺服器資訊 屬性:ConnectToRemoteServer"

            Private _ConnectToRemoteServer As RemoteServer
            ''' <summary>
            ''' 連線至伺服器資訊
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ConnectToRemoteServer() As RemoteServer
                Get
                    Return _ConnectToRemoteServer
                End Get
                Private Set(ByVal value As RemoteServer)
                    _ConnectToRemoteServer = value
                End Set
            End Property

#End Region
#Region "Client端代理物件 屬性:RemoteClientProxyObject"
            ''' <summary>
            ''' Client端代理物件
            ''' </summary>
            ''' <remarks></remarks>
            Private _RemoteClientProxyObject As MarshalByRefObject
            ''' <summary>
            ''' Client端代理物件
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property RemoteClientProxyObject() As MarshalByRefObject
                Get
                    If IsNothing(_RemoteClientProxyObject) Then
                        _RemoteClientProxyObject = GetObject(Nothing)
                    End If
                    Return _RemoteClientProxyObject
                End Get
                Protected Friend Set(ByVal value As MarshalByRefObject)
                    _RemoteClientProxyObject = value
                End Set
            End Property
#End Region
#Region "取得用戶物件 方法:GetObject"
            Shared ChannelIsAlreadyRegister As Boolean = False
            ''' <summary>
            ''' 取得用戶物件
            ''' </summary>
            ''' <param name="SetProxyObjectState"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Private Function GetObject(ByVal SetProxyObjectState As Object) As MarshalByRefObject

                'Client端通道註冊
                If Not ChannelIsAlreadyRegister Then
                    Dim TempClientChannelSinkStack As IClientChannelSinkProvider = Nothing
                    Select Case True
                        Case ConnectToRemoteServer.RemoteProtocol = CompanyORMDB.SQLServer.IM.RemoteProtocolType.Tcp
                            ChannelServices.RegisterChannel(New TcpClientChannel(Guid.NewGuid.ToString, TempClientChannelSinkStack), False)
                        Case ConnectToRemoteServer.RemoteProtocol = CompanyORMDB.SQLServer.IM.RemoteProtocolType.Http
                            ChannelServices.RegisterChannel(New Http.HttpClientChannel(Guid.NewGuid.ToString, TempClientChannelSinkStack), False)
                    End Select
                    ChannelIsAlreadyRegister = True
                End If



                Dim ReturnValue As MarshalByRefObject = Nothing
                Select Case True
                    Case ConnectToRemoteServer.RemoteProtocol = CompanyORMDB.SQLServer.IM.RemoteProtocolType.Tcp AndAlso IsNothing(SetProxyObjectState)
                        ReturnValue = Activator.GetObject(Me.ConnectToRemoteServer.RegisterClassType, "tcp://" & Me.ConnectToRemoteServer.IP & ":" & Me.ConnectToRemoteServer.Port & "/" & Me.ConnectToRemoteServer.RegisterClassName)
                    Case ConnectToRemoteServer.RemoteProtocol = CompanyORMDB.SQLServer.IM.RemoteProtocolType.Tcp AndAlso Not IsNothing(SetProxyObjectState)
                        ReturnValue = Activator.GetObject(Me.ConnectToRemoteServer.RegisterClassType, "tcp://" & Me.ConnectToRemoteServer.IP & ":" & Me.ConnectToRemoteServer.Port & "/" & Me.ConnectToRemoteServer.RegisterClassName, SetProxyObjectState)
                    Case ConnectToRemoteServer.RemoteProtocol = CompanyORMDB.SQLServer.IM.RemoteProtocolType.Http AndAlso IsNothing(SetProxyObjectState)
                        ReturnValue = Activator.GetObject(Me.ConnectToRemoteServer.RegisterClassType, "Http://" & Me.ConnectToRemoteServer.IP & ":" & Me.ConnectToRemoteServer.Port & "/" & Me.ConnectToRemoteServer.RegisterClassName)
                    Case ConnectToRemoteServer.RemoteProtocol = CompanyORMDB.SQLServer.IM.RemoteProtocolType.Http AndAlso Not IsNothing(SetProxyObjectState)
                        ReturnValue = Activator.GetObject(Me.ConnectToRemoteServer.RegisterClassType, "Http://" & Me.ConnectToRemoteServer.IP & ":" & Me.ConnectToRemoteServer.Port & "/" & Me.ConnectToRemoteServer.RegisterClassName, SetProxyObjectState)
                End Select

                Return ReturnValue
            End Function
#End Region


#Region "找尋Client端連線資料庫所有上線中伺服物件 方法(Shared):FindDBRemoteClientsIsOnline"
            ''' <summary>
            ''' 找尋Client端連線資料庫所有上線中伺服物件
            ''' </summary>
            ''' <param name="SourceRemoteClients"></param>
            ''' <param name="LimitWaitSeconds"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Shared Function FindDBRemoteClientsIsOnline(ByVal SourceRemoteClients As List(Of RemoteClient), Optional ByVal LimitWaitSeconds As Integer = 3) As List(Of RemoteClient)
                Dim ReturnValue As List(Of RemoteClient) = Nothing
                If IsNothing(SourceRemoteClients) Then
                    Return Nothing
                End If

                '使用多執行緒偵測所有用戶端
                Dim TestRemoteClientSignalObjects As List(Of TestRemoteClientSignalObject) = New List(Of TestRemoteClientSignalObject)
                Dim RunThreads As List(Of Thread) = New List(Of Thread)
                For Each EachItem As RemoteClient In SourceRemoteClients
                    'ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf TestRemoteClientIsOnline))
                    Dim NewThread As Thread = New Thread(AddressOf EachItem.TestRemoteClientIsOnline)
                    Dim NewTestRemoteClientSignalObject As TestRemoteClientSignalObject = New TestRemoteClientSignalObject(EachItem, LimitWaitSeconds)
                    RunThreads.Add(NewThread)
                    NewThread.Start(NewTestRemoteClientSignalObject)
                    TestRemoteClientSignalObjects.Add(NewTestRemoteClientSignalObject)
                Next
                For Each EachTrhead As Thread In RunThreads
                    EachTrhead.Join()   '等待所有用戶端偵測完畢
                Next


                ReturnValue = New List(Of RemoteClient)
                For Each EachItem As TestRemoteClientSignalObject In TestRemoteClientSignalObjects
                    If EachItem.IsCanConnected Then
                        ReturnValue.Add(EachItem.SetRemoteClient)
                    End If
                Next

                Return ReturnValue
            End Function
#End Region
#Region "測試RemoteClient是否可以連線 方法/非同步迅號類別:TestRemoteClientIsOnline/TestRemoteClientSignalObject"
#Region "測試RemoteClient是否可以連線非同步迅號類別 屬性:TestRemoteClientSignalObject"
            ''' <summary>
            ''' 測試RemoteClient是否可以連線非同步迅號類別
            ''' </summary>
            ''' <remarks></remarks>
            Public Class TestRemoteClientSignalObject
                Sub New(ByVal UseRemoteClient As RemoteClient, ByVal UseLimitWaitSeconds As Integer)
                    Me.SetRemoteClient = UseRemoteClient
                    Me.SetLimitWaitSeconds = UseLimitWaitSeconds
                End Sub
                Public SetRemoteClient As RemoteClient
                Public SetLimitWaitSeconds As Integer
                Public IsCanConnected As Boolean = False
            End Class
#End Region
            ''' <summary>
            ''' 測試RemoteClient是否可以連線
            ''' </summary>
            ''' <param name="SourceRemoteClient"></param>
            ''' <remarks></remarks>
            Public Sub TestRemoteClientIsOnline(ByVal SourceRemoteClient As RemoteClient, Optional ByVal LimitWaitSeconds As Integer = 2)
                Dim myTestRemoteClientSignalObject As TestRemoteClientSignalObject = New TestRemoteClientSignalObject(SourceRemoteClient, LimitWaitSeconds)
                myTestRemoteClientSignalObject.IsCanConnected = False

                Dim NewThread As Thread = New Thread(AddressOf TestRemoteClient)
                NewThread.Start(myTestRemoteClientSignalObject)
                NewThread.Join(myTestRemoteClientSignalObject.SetLimitWaitSeconds * 1000)
            End Sub

            ''' <summary>
            ''' 測試RemoteClient是否可以連線,使用非同步訊號TestRemoteClientSignalObject
            ''' </summary>
            ''' <param name="SyncTestRemoteClientSignalObject"></param>
            ''' <remarks></remarks>
            Private Sub TestRemoteClientIsOnline(ByVal SyncTestRemoteClientSignalObject As Object)
                Dim myTestRemoteClientSignalObject As TestRemoteClientSignalObject = SyncTestRemoteClientSignalObject
                myTestRemoteClientSignalObject.IsCanConnected = False

                Dim NewThread As Thread = New Thread(AddressOf TestRemoteClient)
                NewThread.Start(myTestRemoteClientSignalObject)
                NewThread.Join(myTestRemoteClientSignalObject.SetLimitWaitSeconds * 1000)
                If NewThread.IsAlive Then
                    NewThread.Abort()
                End If
            End Sub

            Private Sub TestRemoteClient(ByVal StateObject As Object)
                Dim myTestRemoteClientSignalObject As TestRemoteClientSignalObject = StateObject
                myTestRemoteClientSignalObject.IsCanConnected = False
                Do
                    Try
                        Dim SourceRemoteClient As RemoteClient = myTestRemoteClientSignalObject.SetRemoteClient
                        Dim GetTimeString As String = CType(SourceRemoteClient.RemoteClientProxyObject, RemottingClassRefObjectBase).GetDeviceInfo.ComputerTime.ToString
                        If (Not IsNothing(GetTimeString)) AndAlso GetTimeString <> "" Then
                            myTestRemoteClientSignalObject.IsCanConnected = True
                            Thread.CurrentThread.Abort()
                        End If
                    Catch ex As Exception
                    End Try
                    Thread.Sleep(100)
                Loop
            End Sub
#End Region


        End Class
#End Region

#Region "Remote協定  Type:RemoteProtocolType"
        ''' <summary>
        ''' Remote協定
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum RemoteProtocolType
            Tcp = 0
            Http = 1
        End Enum
#End Region

    End Namespace
End Namespace