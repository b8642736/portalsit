Public Class OPCUAAdapter

    Dim WithEvents daServerMgt As New Kepware.ClientAce.OpcDaClient.DaServerMgt
    Public Event ErrorMessage(ByVal e As Exception, ByVal ErrorMessage As String)
    Public Event ItemValueReaded(ByVal IsDataGood As Boolean, ByVal ReadData As Object, ByVal ClientHandle As Object)
    Public Event SubscriptionReaded(ByVal allQualitiesGood As Boolean, ByVal noErrors As Boolean, ByVal AllValues As Dictionary(Of Integer, OPCItemSubscribeDefine))
    Public Event DAServerStateChanged(clientHandle As Integer, state As Kepware.ClientAce.OpcDaClient.ServerState)
    Private SourceControl As Control

    Sub New(ByVal SetSourncControl As Control)
        SourceControl = SetSourncControl
    End Sub

    Sub New(ByVal SetSourncControl As Control, ByVal SetEndPointURL As String)
        SourceControl = SetSourncControl
        EndPointURL = SetEndPointURL
    End Sub

#Region "終端結點位址 屬性:EndPointURL"
    'Private _EndPointURL As String = "opc.tcp://10.12.6.30:49320"
    Private _EndPointURL As String = "opc.tcp://10.1.3.52:49320"
    ''' <summary>
    ''' 終端結點位址
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EndPointURL() As String
        Get
            Return _EndPointURL
        End Get
        Set(ByVal value As String)
            _EndPointURL = value
        End Set
    End Property

#End Region

#Region "連線OPCServer 方法:ConnectOPCServer"
    ''' <summary>
    ''' 連線OPCServer
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConnectOPCServer() As Boolean

        If IsConnected Then
            Return True
        End If

        Dim clientHandle As Integer
        clientHandle = 1

        ' The connectInfo structure defines a number of connection parameters.
        ' We will describe each of them below.
        Dim connectInfo As New Kepware.ClientAce.OpcDaClient.ConnectInfo
        connectInfo.ClientName = EndPointURL
        connectInfo.LocalId = "en"
        connectInfo.KeepAliveTime = 60000
        connectInfo.RetryAfterConnectionError = True
        connectInfo.RetryInitialConnection = False

        ' The connectFailed is set by the API. You should check this value
        ' after a to the Connect method. We will initialize it to False in case
        ' Connect throws an exception before it can be set.
        Dim ConnectResult As Boolean
        ConnectResult = False

        ' Call the Connect API method:
        Try
            daServerMgt.Connect(EndPointURL, clientHandle, connectInfo, ConnectResult)
            '' Update our connection status textbox
            'txtConnectionStatus.Text = "Connection Succeeded"
            ConnectResult = True
        Catch ex As Exception
            RaiseEvent ErrorMessage(ex, "Handled Connect exception. Reason: " & ex.Message)
            ConnectResult = True
        End Try
        Return ConnectResult
    End Function
#End Region
#Region "中斷連線OPCServer 方法:ConnectOPCServer"
    ''' <summary>
    ''' 中斷連線OPCServer
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DisConnectOPCServer() As Boolean
        If Not IsNothing(daServerMgt) AndAlso daServerMgt.IsConnected Then
            daServerMgt.Disconnect()
        End If
        Return True
    End Function
#End Region

#Region "是否已連線 屬性:IsConnected"
    ''' <summary>
    ''' 是否已連線
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsConnected As Boolean
        Get
            If IsNothing(daServerMgt) Then
                Return False
            End If

            Return daServerMgt.IsConnected
        End Get
    End Property
#End Region

#Region "非同步讀取OPC資料 屬性:OPCItemAsyncRead"
    ''' <summary>
    ''' 非同步讀取OPC資料
    ''' </summary>
    ''' <param name="ReadTagItemName">讀取TAG的名稱例:ns=2;s=Channel_1.Device_1.K0</param>
    ''' <param name="maxAge">資料有效時間</param>
    ''' <param name="SetClientHandle"></param>
    ''' <returns>回傳TaskID</returns>
    ''' <remarks></remarks>
    Public Function OPCItemAsyncRead(ByVal ReadTagItemName As String, Optional maxAge As Integer = 0, Optional SetClientHandle As Object = Nothing) As Integer

        Dim TransID As Integer
        TransID = RandomNumber(65535, 1)
        Try
            ' The item identifiers array describe the items we wish to read. We
            ' may read more than one item at a time. However, the GUI in this
            ' example is set up so that only one item can be read at a time.
            Dim itemIdentifiers(0) As Kepware.ClientAce.OpcDaClient.ItemIdentifier
            itemIdentifiers(0) = New Kepware.ClientAce.OpcDaClient.ItemIdentifier
            itemIdentifiers(0).ItemName = ReadTagItemName ' OPCItemNameTextBoxes(itemIndex).Text
            itemIdentifiers(0).ClientHandle = SetClientHandle

            '' The itemValues array is filled by the API with the current
            '' value of the requested items. The API will dimension and
            '' allocate members of this array for us.
            'Dim itemValues() As Kepware.ClientAce.OpcDaClient.ItemValue

            ' Call the Read API method:
            Dim returnCode As Kepware.ClientAce.OpcDaClient.ReturnCode
            returnCode = daServerMgt.ReadAsync(TransID, maxAge, itemIdentifiers)

            ' Handle result:
            ' Check result
            If returnCode <> Kepware.ClientAce.OpcDaClient.ReturnCode.SUCCEEDED Then
                RaiseEvent ErrorMessage(Nothing, "ReadAsync failed with error: " & Hex(itemIdentifiers(0).ResultID.Code) & vbCrLf & "Description: " & itemIdentifiers(0).ResultID.Description)
            End If
            Return TransID
        Catch ex As Exception
            RaiseEvent ErrorMessage(ex, "Handled Async Read exception. Reason: " & ex.Message)
        End Try
        Return -1
    End Function

    Public Function RandomNumber(ByVal MaxNumber As Integer, Optional ByVal MinNumber As Integer = 1) As Integer

        'initialize random number generator
        Dim r As New Random(System.DateTime.Now.Millisecond)

        'if passed incorrect arguments, swap them
        'can also throw exception or return 0

        If MinNumber > MaxNumber Then
            Dim t As Integer = MinNumber
            MinNumber = MaxNumber
            MaxNumber = t
        End If

        Return r.Next(MinNumber, MaxNumber)

    End Function
#End Region

#Region "訂閱資料項參數定義 類別:OPCItemSubscribeDefine"
    ''' <summary>
    ''' 訂閱資料項參數定義
    ''' </summary>
    ''' <remarks></remarks>
    Class OPCItemSubscribeDefine
        Sub New(ByVal SetReadTagItemName As String, ByVal SetClientHandle As Object, ByVal SetDataType As Type)
            Me.ReadTagItemName = SetReadTagItemName
            Me.ClientHandle = SetClientHandle
            Me.DataType = SetDataType
        End Sub

        Property ReadTagItemName As String  '訂閱標韱名稱
        Property ClientHandle As Object '設定每一筆 Tag 的唯一編號做為判斷依據
        Property DataType As Type '資料型別
        Property OPCReturnValue As Kepware.ClientAce.OpcDaClient.ItemValueCallback '由OPC伺服器回傳的資料
    End Class
#End Region
#Region "訂閱資料項參數集合 屬性:OPCItemSubscribeCollection"
    Private _OPCItemSubscribeCollection As New Dictionary(Of Integer, OPCItemSubscribeDefine)
    ''' <summary>
    ''' 訂閱資料項參數集合
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>參數1:ClientHandle 設定每一筆 Tag 的唯一編號做為判斷依據;參數2:OPCItemSubscribeDefine</remarks>
    Public Property OPCItemSubscribeCollection() As Dictionary(Of Integer, OPCItemSubscribeDefine)
        Get
            Return _OPCItemSubscribeCollection
        End Get
        Private Set(ByVal value As Dictionary(Of Integer, OPCItemSubscribeDefine))
            _OPCItemSubscribeCollection = value
        End Set
    End Property

#End Region
#Region "是否啟用訂閱 屬性:IsEnableSubscribe"
    ''' <summary>
    ''' 是否啟用訂閱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsEnableSubscribe As Boolean = True
#End Region
#Region "加入訂閱資料項 函式:AddOPCItem"
    ''' <summary>
    ''' 加入訂閱資料項
    ''' </summary>
    ''' <param name="SetReadTagItemName"></param>
    ''' <param name="SetDataType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AddOPCItem(ByVal SetReadTagItemName As String, ByVal SetDataType As Type) As Boolean
        Static SetClientHandleID As Integer = 0
        SetClientHandleID += 1  '設定每一筆 Tag 的唯一編號做為判斷依據
        OPCItemSubscribeCollection.Add(SetClientHandleID, New OPCItemSubscribeDefine(SetReadTagItemName, SetClientHandleID, SetDataType))
        Return True
    End Function
#End Region
#Region "清除訂閱資料項 函式:ClearOPCItems"
    ''' <summary>
    ''' 清除訂閱資料項
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearOPCItems()
        OPCItemSubscribeCollection.Clear()
    End Sub
#End Region
#Region "訂閱更新频率(時間) 屬性:SubscriptionUpdateRate"
    Private _SubscriptionUpdateRate As Integer = 1000
    ''' <summary>
    ''' 訂閱更新频率(時間)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SubscriptionUpdateRate() As Integer
        Get
            Return _SubscriptionUpdateRate
        End Get
        Set(ByVal value As Integer)
            _SubscriptionUpdateRate = value
        End Set
    End Property
#End Region
#Region "訂閱Deadband百分比 屬性:DeadbandPecentage"
    Private _DeadbandPecentage As Integer = 0
    Public Property DeadbandPecentage() As Integer
        Get
            Return _DeadbandPecentage
        End Get
        Set(ByVal value As Integer)
            _DeadbandPecentage = IIf(value < 0, 0, value)
            _DeadbandPecentage = IIf(value > 100, 100, value)
        End Set
    End Property

#End Region
#Region "訂閱OPC資料 屬性:OPCItemSubscribt"
    Dim activeServerSubscriptionHandle As Integer
    Dim activeClientSubscriptionHandle As Integer
    ''' <summary>
    ''' 訂閱OPC資料
    ''' </summary>
    ''' <param name="ReadTagItemName"></param>
    ''' <param name="maxAge"></param>
    ''' This allows a meaningful handle to be assigned to each subscription. This value will be returned in each DataChanged event. It provides a way to indicate the subscription for which the data update is intended.
    ''' </param>
    ''' <remarks></remarks>
    Public Sub OPCItemSubscribt(Optional maxAge As Integer = 0)
        Dim clientSubscriptionHandle As Integer = 1
        Dim itemIndex As Integer
        Dim itemIdentifiers(OPCItemSubscribeCollection.Count - 1) As Kepware.ClientAce.OpcDaClient.ItemIdentifier

        itemIndex = 0
        For Each EachItem As OPCItemSubscribeDefine In OPCItemSubscribeCollection.Values
            itemIdentifiers(itemIndex) = New Kepware.ClientAce.OpcDaClient.ItemIdentifier
            itemIdentifiers(itemIndex).ItemName = EachItem.ReadTagItemName ' OPCItemNameTextBoxes(itemIndex).Text
            itemIdentifiers(itemIndex).ClientHandle = EachItem.ClientHandle ' itemIndex
            itemIdentifiers(itemIndex).DataType = EachItem.DataType ' Type.GetType("System.Int16")  ' Assign types like this: Type.GetType("System.UInt16" for a word type)
            itemIndex += 1
        Next

        'For itemIndex = 0 To OPCItemSubscribeCollection.Count - 1
        '    itemIdentifiers(itemIndex) = New Kepware.ClientAce.OpcDaClient.ItemIdentifier
        '    itemIdentifiers(itemIndex).ItemName = OPCItemSubscribeCollection(itemIndex).ReadTagItemName ' OPCItemNameTextBoxes(itemIndex).Text
        '    itemIdentifiers(itemIndex).ClientHandle = OPCItemSubscribeCollection(itemIndex).ClientHandle ' itemIndex
        '    itemIdentifiers(itemIndex).DataType = itemIdentifiers(itemIndex).DataType ' Type.GetType("System.Int16")  ' Assign types like this: Type.GetType("System.UInt16" for a word type)
        'Next

        ' The revisedUpdateRate parameter is the actual update rate that the
        ' server will be using.
        Dim revisedUpdateRate As Integer

        ' Call the Subscribe API method:
        Try
            daServerMgt.Subscribe(clientSubscriptionHandle, IsEnableSubscribe, SubscriptionUpdateRate, revisedUpdateRate, DeadbandPecentage, itemIdentifiers, activeServerSubscriptionHandle)

            ' Handle result:
            SubscriptionUpdateRate = revisedUpdateRate  '將伺服端實際UpdateRate回傳給本元件
            ' Save the active client subscription handle for use in 
            ' DataChanged events:
            activeClientSubscriptionHandle = clientSubscriptionHandle



            ' Check item result ID:
            For itemIndex = 0 To OPCItemSubscribeCollection.Count - 1
                If itemIdentifiers(itemIndex).ResultID.Succeeded = False Then

                    ' Show a message box if an item could not be added to subscription.
                    ' You would probably use some other, less annoying, means to alert
                    ' the user to failed item enrolments in an actual application. 
                    RaiseEvent ErrorMessage(Nothing, "Failed to add item " & itemIdentifiers(itemIndex).ItemName & " to subscription")
                End If
            Next

        Catch ex As Exception
            activeClientSubscriptionHandle = 0
            RaiseEvent ErrorMessage(ex, "Handled Subscribe exception. Reason: " & ex.Message)
        End Try
    End Sub
#End Region
#Region "變更OPC資料訂閱 函式:OPCItemSubscriptModify"
    ''' <summary>
    ''' 變更OPC資料訂閱
    ''' </summary>
    ''' <param name="ReadTagItemName"></param>
    ''' <param name="maxAge"></param>
    ''' <param name="SetclientSubscriptionHandle"></param>
    ''' <remarks></remarks>
    Public Sub OPCItemSubscriptModify(ByVal ReadTagItemName As String, Optional maxAge As Integer = 0, Optional SetclientSubscriptionHandle As Object = Nothing)
        ' These parameters have the same meaning as described above for the
        ' Subscribe method.
        Dim revisedUpdateRate As Integer

        ' Call SubscriptionModify API method:
        ' (Note, we are using the server subscription handle here.)
        Try
            daServerMgt.SubscriptionModify(activeServerSubscriptionHandle, IsEnableSubscribe, SubscriptionUpdateRate, revisedUpdateRate, DeadbandPecentage)
            SubscriptionUpdateRate = revisedUpdateRate  '將伺服端實際UpdateRate回傳給本元件
        Catch ex As Exception
            RaiseEvent ErrorMessage(ex, "Handled Subscription Modify exception. Reason: " & ex.Message)
        End Try
    End Sub
#End Region
#Region "取消訂閱 函式:Unsubscribe"
    ''' <summary>
    ''' 取消訂閱
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Unsubscribe()
        ' Call SubscriptionCancel API method:
        ' (Note, we are using the server subscription handle here.)
        Try
            daServerMgt.SubscriptionCancel(activeServerSubscriptionHandle)
        Catch ex As Exception
            RaiseEvent ErrorMessage(ex, "Handled SubscriptionCancel exception. Reason: " & ex.Message)
        End Try
    End Sub
#End Region


#Region "非同步資料讀取返回 私有函式:daServerMgt_ReadCompleted"
    ''' <summary>
    ''' 非同步資料讀取返回
    ''' </summary>
    ''' <param name="transactionHandle"></param>
    ''' <param name="allQualitiesGood"></param>
    ''' <param name="noErrors"></param>
    ''' <param name="itemValues"></param>
    ''' <remarks></remarks>
    Private Sub daServerMgt_ReadCompleted(ByVal transactionHandle As Integer, ByVal allQualitiesGood As Boolean, ByVal noErrors As Boolean, ByVal itemValues() As Kepware.ClientAce.OpcDaClient.ItemValueCallback) Handles daServerMgt.ReadCompleted
        My.Application.Log.WriteEntry("daServerMgt_ReadCompleted enter")

        ' We need to forward the callback to the main thread of the application if
        ' we access the GUI directly from the callback. It is recommended to do this
        ' even if the application is running in the back ground.
        '
        ' See Control.Invoke Method (Delegate, Object[]) for a good explanation. Note, we are using BeginInvoke()
        ' instead of Invoke() so that the delegate is called asynchronously.

        ' Create an instance of the delegate and assign it address of method with same signature as ReadCompletedEventHandler.
        Dim RCevHndlr As New Kepware.ClientAce.OpcDaClient.DaServerMgt.ReadCompletedEventHandler(AddressOf NotifyControlReadCompleted)
        Dim returnValue As IAsyncResult
        returnValue = SourceControl.BeginInvoke(RCevHndlr, New Object() {transactionHandle, allQualitiesGood, noErrors, itemValues})

        My.Application.Log.WriteEntry("daServerMgt_ReadCompleted exit")
    End Sub
#End Region
#Region "非同步資料讀取返回委派 私有函式:NotifyControlReadCompleted"
    ''' <summary>
    ''' 非同步資料讀取返回委派
    ''' </summary>
    ''' <param name="transactionHandle"></param>
    ''' <param name="allQualitiesGood"></param>
    ''' <param name="noErrors"></param>
    ''' <param name="itemValues"></param>
    ''' <remarks>觸發本元件之事件告知外介控制項資料抵逹</remarks>
    Private Sub NotifyControlReadCompleted(ByVal transactionHandle As Integer, ByVal allQualitiesGood As Boolean, ByVal noErrors As Boolean, ByVal itemValues() As Kepware.ClientAce.OpcDaClient.ItemValueCallback)
        Dim GetClientHandle = -1
        Try
            GetClientHandle = itemValues(0).ClientHandle
            If itemValues(0).ResultID.Succeeded Then
                RaiseEvent ItemValueReaded(True, itemValues(0).Value, GetClientHandle)
            End If
        Catch ex As Exception
            RaiseEvent ItemValueReaded(False, Nothing, GetClientHandle)
            RaiseEvent ErrorMessage(ex, "Handled Async Read Complete exception. Reason: " & ex.Message)
        End Try
    End Sub
#End Region


#Region "非同步批次讀取返回 私有函式:daServerMgt_DataChanged"
    ''' <summary>
    ''' 非同步批次讀取返回
    ''' </summary>
    ''' <param name="clientSubscription"></param>
    ''' <param name="allQualitiesGood"></param>
    ''' <param name="noErrors"></param>
    ''' <param name="itemValues"></param>
    ''' <remarks></remarks>
    Private Sub daServerMgt_DataChanged(ByVal clientSubscription As Integer, ByVal allQualitiesGood As Boolean, ByVal noErrors As Boolean, ByVal itemValues() As Kepware.ClientAce.OpcDaClient.ItemValueCallback) Handles daServerMgt.DataChanged

        ' We need to forward the callback to the main thread of the application if we access the GUI directly from the callback. 
        'It is recommended to do this even if the application is running in the back ground.
        Me.SourceControl.BeginInvoke(New Kepware.ClientAce.OpcDaClient.DaServerMgt.DataChangedEventHandler(AddressOf DataChanged), New Object() {clientSubscription, allQualitiesGood, noErrors, itemValues})
    End Sub

#End Region
#Region "非同步批次讀取返回委派 私有函式:DataChanged"
    ''' <summary>
    ''' 非同步批次讀取返回委派
    ''' </summary>
    ''' <param name="clientSubscription"></param>
    ''' <param name="allQualitiesGood"></param>
    ''' <param name="noErrors"></param>
    ''' <param name="itemValues"></param>
    ''' <remarks></remarks>
    Private Sub DataChanged(ByVal clientSubscription As Integer, ByVal allQualitiesGood As Boolean, ByVal noErrors As Boolean, ByVal itemValues() As Kepware.ClientAce.OpcDaClient.ItemValueCallback)
        Dim ReturnValue As New Dictionary(Of Integer, OPCItemSubscribeDefine)
        If activeClientSubscriptionHandle = clientSubscription Then
            For Each EachitemValue As Kepware.ClientAce.OpcDaClient.ItemValueCallback In itemValues
                If OPCItemSubscribeCollection.ContainsKey(EachitemValue.ClientHandle) Then
                    OPCItemSubscribeCollection.Item(EachitemValue.ClientHandle).OPCReturnValue = EachitemValue
                End If
            Next
        End If
        RaiseEvent SubscriptionReaded(allQualitiesGood, noErrors, OPCItemSubscribeCollection)
    End Sub

#End Region

#Region "OPC資料寫入暫不開放使用 <注意:危險>"

    '#Region "非同步OPC資料寫入 方式:OPCItemASyncWrite"
    '    Public Sub OPCItemASyncWrite(Of SendValueType)(ByVal SendTagItemName As String, ByVal SendValue As SendValueType, Optional SetClientHandle As Integer = 1)
    '        ' Determine index of item to write to from the write button pressed:
    '        'Dim itemIndex As Integer
    '        ' initialize the return code varaible
    '        Dim returnCode As Kepware.ClientAce.OpcDaClient.ReturnCode


    '        Try
    '            ' Define parameters for Write method:

    '            ' The item identifiers array describe the items we wish to write to.
    '            ' We may write to more than one item at a time. However, the GUI in
    '            ' this example is set up so that only one item can be written to at
    '            ' a time.
    '            Dim itemIdentifiers(0) As Kepware.ClientAce.OpcDaClient.ItemIdentifier
    '            itemIdentifiers(0) = New Kepware.ClientAce.OpcDaClient.ItemIdentifier
    '            itemIdentifiers(0).ItemName = SendTagItemName
    '            'itemIdentifiers(0).DataType = Type.GetType("System.UInt16")
    '            itemIdentifiers(0).ClientHandle = SetClientHandle

    '            ' The itemValues array contains the values we wish to write to the
    '            ' items.
    '            Dim itemValues(0) As Kepware.ClientAce.OpcDaClient.ItemValue
    '            itemValues(0) = New Kepware.ClientAce.OpcDaClient.ItemValue
    '            itemValues(0).Value = SendValue 'CInt(OPCItemWriteValueTextBoxes(itemIndex).Text)


    '            Dim TransID As Integer
    '            TransID = RandomNumber(65535, 1)

    '            ' Call the Write API method:
    '            returnCode = daServerMgt.WriteAsync(TransID, itemIdentifiers, itemValues)

    '            ' Handle result:
    '            If returnCode <> Kepware.ClientAce.OpcDaClient.ReturnCode.SUCCEEDED Then
    '                RaiseEvent ErrorMessage(Nothing, "Async Write failed with a result of " & Hex(itemIdentifiers(0).ResultID.Code) & vbCrLf & "Description: " & itemIdentifiers(0).ResultID.Description)
    '            End If
    '        Catch ex As Exception
    '            RaiseEvent ErrorMessage(ex, "Handled Async Write exception. Reason: " & ex.Message)
    '        End Try
    '    End Sub

    '#End Region
#Region "非同步OPC資料寫入返回 函式:daServerMgtWriteCompleted"
    ''' <summary>
    ''' 非同步OPC資料寫入返回
    ''' </summary>
    ''' <param name="transaction"></param>
    ''' <param name="noErrors"></param>
    ''' <param name="itemResults"></param>
    ''' <remarks></remarks>
    Private Sub daServerMgtWriteCompleted(ByVal transaction As Integer, ByVal noErrors As Boolean, ByVal itemResults() As Kepware.ClientAce.OpcDaClient.ItemResultCallback) Handles daServerMgt.WriteCompleted
        'My.Application.Log.WriteEntry("daServerMgt_WriteCompleted enter")

        ' We need to forward the callback to the main thread of the
        ' application if we access the GUI directly from the callback. It is
        ' recommended to do this even if the application is running in the back ground.
        Me.SourceControl.BeginInvoke(New Kepware.ClientAce.OpcDaClient.DaServerMgt.WriteCompletedEventHandler(AddressOf WriteCompleted), New Object() {transaction, noErrors, itemResults})
        'My.Application.Log.WriteEntry("daServerMgt_WriteCompleted exit")
    End Sub
#End Region
#Region "非同步OPC資料寫入返回委派 函式:WriteCompleted"
    ''' <summary>
    ''' 非同步OPC資料寫入返回委派
    ''' </summary>
    ''' <param name="transaction"></param>
    ''' <param name="noErrors"></param>
    ''' <param name="itemResults"></param>
    ''' <remarks></remarks>
    Private Sub WriteCompleted(ByVal transaction As Integer, ByVal noErrors As Boolean, ByVal itemResults() As Kepware.ClientAce.OpcDaClient.ItemResultCallback)
        'My.Application.Log.WriteEntry("WriteCompleted enter")
        Try
            '~~ Process the call back infomration here.
            If Not itemResults(0).ResultID.Succeeded Then
                RaiseEvent ErrorMessage(Nothing, "Async Write Complete failed with error: " & Hex(itemResults(0).ResultID.Code) & vbCrLf & "Description: " & itemResults(0).ResultID.Description)
            End If
        Catch ex As Exception
            RaiseEvent ErrorMessage(ex, "Handled Async Write Complete exception. Reason: " & ex.Message)
        End Try

        'My.Application.Log.WriteEntry("WriteCompleted exit")
    End Sub
#End Region
#End Region

#Region "DAServer狀況變更 私有函式:daServerMgt_ServerStateChanged"
    Private Sub daServerMgt_ServerStateChanged(clientHandle As Integer, state As Kepware.ClientAce.OpcDaClient.ServerState) Handles daServerMgt.ServerStateChanged
        Try
            Me.SourceControl.BeginInvoke(New Kepware.ClientAce.OpcDaClient.DaServerMgt.ServerStateChangedEventHandler(AddressOf DAServerStateChanged_Delegate), New Object() {clientHandle, state})

        Catch ex As Exception

        End Try
    End Sub
#End Region
#Region "DAServer狀變更委派 私有函式:DAServerStateChanged"
    Private Sub DAServerStateChanged_Delegate(clientHandle As Integer, state As Kepware.ClientAce.OpcDaClient.ServerState)
        RaiseEvent DAServerStateChanged(clientHandle, state)
    End Sub

#End Region

End Class
