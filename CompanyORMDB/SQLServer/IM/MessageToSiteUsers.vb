Namespace SQLServer
	Namespace IM
	Public Class MessageToSiteUsers
	Inherits ClassDBSQLServer

            Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "IM")
                Me.SendMessageBatchNumber = Guid.NewGuid.ToString
                Me.SendTime = New DateTime(2000, 1, 1)
                Me.ReceiveTime = Me.SendTime
                Me.FinalRecieveTime = Me.SendTime
                Me.NotSendReplyTime = Me.SendTime
                Me.SenderReceivedNotSendReplyTime = Me.SendTime
                Me.SystemFirstReceiveTime = Me.SendTime
                Me.SystemLastReceiveTime = Me.SendTime
            End Sub
            'SendMessageBatchNumber
#Region "傳送訊息批號 屬性:SendMessageBatchNumber"
            Private _SendMessageBatchNumber As String
            ''' <summary>
            ''' 傳送訊息批號
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property SendMessageBatchNumber() As String
                Get
                    Return _SendMessageBatchNumber
                End Get
                Set(ByVal value As String)
                    _SendMessageBatchNumber = value
                End Set
            End Property

#End Region
#Region "FK_MessageID 屬性:FK_MessageID"
	Private _FK_MessageID As System.String
	''' <summary>
	''' FK_MessageID
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property FK_MessageID() As System.String
                Get
                    Return _FK_MessageID
                End Get
                Set(ByVal value As System.String)
                    _FK_MessageID = value
                End Set
            End Property
#End Region
#Region "FK_ToSiteID 屬性:FK_ToSiteID"
	Private _FK_ToSiteID As System.String
	''' <summary>
	''' FK_ToSiteID
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
    Public Property FK_ToSiteID() As System.String
                Get
                    Return _FK_ToSiteID
                End Get
                Set(ByVal value As System.String)
                    _FK_ToSiteID = value
                End Set
            End Property
#End Region
#Region "FK_ToSiteUsersID 屬性:FK_ToSiteUsersID"
	Private _FK_ToSiteUsersID As System.String
	''' <summary>
	''' FK_ToSiteUsersID
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
 Public Property FK_ToSiteUsersID() As System.String
                Get
                    Return _FK_ToSiteUsersID
                End Get
                Set(ByVal value As System.String)
                    _FK_ToSiteUsersID = value
                End Set
            End Property
#End Region
#Region "發送者網路IP 屬性:FromClientIP"
            Private _FromClientIP As System.String
            ''' <summary>
            ''' 發送者網路IP
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
 Public Property FromClientIP() As System.String
                Get
                    Return _FromClientIP
                End Get
                Set(ByVal value As System.String)
                    _FromClientIP = value
                End Set
            End Property
#End Region
#Region "傳送時間 屬性:SendTime"
            Private _SendTime As System.DateTime
            ''' <summary>
            ''' 傳送時間
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
 Public Property SendTime() As System.DateTime
                Get
                    Return _SendTime
                End Get
                Set(ByVal value As System.DateTime)
                    _SendTime = value.AddMilliseconds(-value.Millisecond)
                End Set
            End Property
#End Region
#Region "發送者Windows登入名稱 屬性:FromWindowLoginName"
            Private _FromWindowLoginName As System.String
            ''' <summary>
            ''' 發送者Windows登入名稱
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FromWindowLoginName() As System.String
                Get
                    Return _FromWindowLoginName
                End Get
                Set(ByVal value As System.String)
                    _FromWindowLoginName = value
                End Set
            End Property
#End Region
#Region "是否已接收 屬性:IsReceived"
            Private _IsReceived As System.Boolean
            ''' <summary>
            ''' 是否已接收
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property IsReceived() As System.Boolean
                Get
                    Return _IsReceived
                End Get
                Set(ByVal value As System.Boolean)
                    _IsReceived = value
                End Set
            End Property
#End Region
#Region "接收時間 屬性:ReceiveTime"
            Private _ReceiveTime As System.DateTime
            ''' <summary>
            ''' 接收時間
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ReceiveTime() As System.DateTime
                Get
                    Return _ReceiveTime
                End Get
                Set(ByVal value As System.DateTime)
                    _ReceiveTime = value.AddMilliseconds(-value.Millisecond)
                End Set
            End Property
#End Region
#Region "是否有最終接收時間 屬性:IsHaveFinalRecieveTime"
            Private _IsHaveFinalRecieveTime As System.Boolean
            ''' <summary>
            ''' 是否有最終接收時間
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property IsHaveFinalRecieveTime() As System.Boolean
                Get
                    Return _IsHaveFinalRecieveTime
                End Get
                Set(ByVal value As System.Boolean)
                    _IsHaveFinalRecieveTime = value
                End Set
            End Property
#End Region
#Region "最終接收時間 屬性:FinalRecieveTime"
            Private _FinalRecieveTime As System.DateTime
            ''' <summary>
            ''' 最終接收時間
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FinalRecieveTime() As System.DateTime
                Get
                    Return _FinalRecieveTime
                End Get
                Set(ByVal value As System.DateTime)
                    _FinalRecieveTime = value.AddMilliseconds(-value.Millisecond)
                End Set
            End Property
#End Region
#Region "是未未接收回應發送者 屬性:IsHaveNotSendReplye"
            Private _IsHaveNotSendReplye As System.Boolean
            ''' <summary>
            ''' 是未未接收回應發送者
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property IsHaveNotSendReplye() As System.Boolean
                Get
                    Return _IsHaveNotSendReplye
                End Get
                Set(ByVal value As System.Boolean)
                    _IsHaveNotSendReplye = value
                End Set
            End Property
#End Region
#Region "是否發送者已確認訊息未接收 屬性:IsSenderReceiveNotSendReplye"
            Private _IsSenderReceiveNotSendReplye As System.Boolean
            ''' <summary>
            ''' 是否發送者已確認訊息未接收
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property IsSenderReceiveNotSendReplye() As System.Boolean
                Get
                    Return _IsSenderReceiveNotSendReplye
                End Get
                Set(ByVal value As System.Boolean)
                    _IsSenderReceiveNotSendReplye = value
                End Set
            End Property
#End Region
#Region "發送者確認訊息未接收生效啟始時間 屬性:NotSendReplyTime"
            Private _NotSendReplyTime As System.DateTime
            ''' <summary>
            ''' 發送者確認訊息未接收生效啟始時間
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property NotSendReplyTime() As System.DateTime
                Get
                    Return _NotSendReplyTime
                End Get
                Set(ByVal value As System.DateTime)
                    _NotSendReplyTime = value.AddMilliseconds(-value.Millisecond)
                End Set
            End Property
#End Region
#Region "發送者已確認訊息未接收時間"

            Private _SenderReceivedNotSendReplyTime As DateTime
            ''' <summary>
            ''' 發送者已確認訊息未接收時間
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SenderReceivedNotSendReplyTime() As DateTime
                Get
                    Return _SenderReceivedNotSendReplyTime
                End Get
                Set(ByVal value As DateTime)
                    _SenderReceivedNotSendReplyTime = value.AddMilliseconds(-value.Millisecond)
                End Set
            End Property

#End Region
#Region "訊息抬頭 屬性:MsgText"
            Private _MsgText As System.String
            ''' <summary>
            ''' 訊息抬頭
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property MsgText() As System.String
                Get
                    Return _MsgText
                End Get
                Set(ByVal value As System.String)
                    _MsgText = value
                End Set
            End Property
#End Region
#Region "訊息內容 屬性:AddMsgContent"
            Private _AddMsgContent As System.String
            ''' <summary>
            ''' 訊息內容
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property AddMsgContent() As System.String
                Get
                    Return _AddMsgContent
                End Get
                Set(ByVal value As System.String)
                    _AddMsgContent = value
                End Set
            End Property
#End Region
#Region "傳送訊息至Email 屬性:ToSendEmailAddress"
            Private _ToSendEmailAddress As System.String
            ''' <summary>
            ''' 傳送訊息至Email
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ToSendEmailAddress() As System.String
                Get
                    Return _ToSendEmailAddress
                End Get
                Set(ByVal value As System.String)
                    _ToSendEmailAddress = value
                End Set
            End Property
#End Region
#Region "系統第一次接收時間 屬性:SystemFirstReceiveTime"
            Private _SystemFirstReceiveTime As System.DateTime
            ''' <summary>
            ''' 系統第一次接收時間
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SystemFirstReceiveTime() As System.DateTime
                Get
                    Return _SystemFirstReceiveTime
                End Get
                Set(ByVal value As System.DateTime)
                    _SystemFirstReceiveTime = value.AddMilliseconds(-value.Millisecond)
                End Set
            End Property
#End Region
#Region "系統最後接收時間 屬性:SystemLastReceiveTime"
            Private _SystemLastReceiveTime As System.DateTime
            ''' <summary>
            ''' 系統最後接收時間
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SystemLastReceiveTime() As System.DateTime
                Get
                    Return _SystemLastReceiveTime
                End Get
                Set(ByVal value As System.DateTime)
                    _SystemLastReceiveTime = value.AddMilliseconds(-value.Millisecond)
                End Set
            End Property
#End Region
#Region "等待交接班2次確認IP 屬性:WaitReceived2CheckIP"

            Private _WaitReceived2CheckIP As String
            ''' <summary>
            ''' 等待交接班2次確認IP
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property WaitReceived2CheckIP() As String
                Get
                    Return _WaitReceived2CheckIP
                End Get
                Set(ByVal value As String)
                    _WaitReceived2CheckIP = value
                End Set
            End Property

#End Region


#Region "發送者訊息確認狀態 屬性:SenderMessageCheckState"
            ''' <summary>
            ''' 發送者訊息確認狀態
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property SenderMessageCheckState() As MessageCheckStateEnum
                Get
                    If Me.IsHaveNotSendReplye = False OrElse Me.IsReceived And Me.ReceiveTime < Me.NotSendReplyTime Then
                        Return MessageCheckStateEnum.NoNeedCheck
                    Else
                        If Me.IsSenderReceiveNotSendReplye Then
                            Return MessageCheckStateEnum.Checked
                        Else
                            If TheMessageIsPastNoSendReplayTime Then
                                Return MessageCheckStateEnum.WaitCheck
                            Else
                                Return MessageCheckStateEnum.NoNeedCheck
                            End If
                        End If
                    End If
                End Get
            End Property
#End Region
#Region "接收者訊息確認狀態 屬性:ReceiverMessageCheckState"
            ''' <summary>
            ''' 接收者訊息確認狀態
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property ReceiverMessageCheckState() As MessageCheckStateEnum
                Get
                    If Me.IsReceived Then
                        Return MessageCheckStateEnum.Checked
                    Else
                        If Me.IsHaveFinalRecieveTime AndAlso TheMesageIsPastReceiveTime Then
                            Return MessageCheckStateEnum.NoNeedCheck
                        Else
                            Return MessageCheckStateEnum.WaitCheck
                        End If
                    End If
                End Get
            End Property
#End Region
#Region "這則訊息是否逾期簽收 屬性:TheMesageIsPastReceiveTime"
            ''' <summary>
            ''' 這則訊息是否逾期簽收
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property TheMesageIsPastReceiveTime() As Boolean
                Get
                    If Not Me.IsHaveNotSendReplye Then
                        Return False
                    Else
                        If Me.IsReceived Then
                            Return Me.ReceiveTime > FinalRecieveTime
                        Else
                            Dim WSAdapter As New CompanyORMDB.WSDBSQLQueryAdapter(True)
                            Return WSAdapter.GetServerTime > FinalRecieveTime
                        End If
                    End If
                End Get
            End Property
#End Region
#Region "這則訊息時間是否到達傳送者等待逾期時間 屬性:TheMessageIsPastNoSendReplayTime"
            ''' <summary>
            ''' 這則訊息時間是否到達傳送者等待逾期時間
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property TheMessageIsPastNoSendReplayTime() As Boolean
                Get
                    If Not IsHaveNotSendReplye Then
                        Return False
                    Else
                        If Me.IsSenderReceiveNotSendReplye Then
                            Return SenderReceivedNotSendReplyTime > NotSendReplyTime
                        Else
                            Dim WSAdapter As New CompanyORMDB.WSDBSQLQueryAdapter(True)
                            Return WSAdapter.GetServerTime > NotSendReplyTime
                        End If
                    End If
                End Get
            End Property
#End Region
#Region "收訊者角色 屬性:ReceiveMessageRole"
            Private _ReceiveMessageRole As ReceiveMessageRoleEnum = ReceiveMessageRoleEnum.UnKnow
            ''' <summary>
            ''' 收訊者角色
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property ReceiveMessageRole(Optional ByVal AllSiteUserCachData As List(Of SiteUser) = Nothing) As ReceiveMessageRoleEnum
                Get
                    If _ReceiveMessageRole = ReceiveMessageRoleEnum.UnKnow Then
                        If IsNothing(AllSiteUserCachData) Then
                            AllSiteUserCachData = SiteUser.CDBSelect(Of SiteUser)("Select * from SiteUser Where ID='" & Me.FK_ToSiteUsersID & "'", Me.CDBCurrentUseSQLQueryAdapter)
                        End If
                        _ReceiveMessageRole = GetUserToMessageRole(AllSiteUserCachData, My.User.Name, DeviceInformation.GetLocalIPs)
                    End If
                    Return _ReceiveMessageRole
                End Get
            End Property
#End Region
#Region "取得使用者對收訊者角色 方法:GetUserToMessageRole"
            ''' <summary>
            ''' 取得收訊者角色
            ''' </summary>
            ''' <param name="SetWindowsLoginName"></param>
            ''' <param name="ClientPCIPs"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Private Function GetUserToMessageRole(ByVal AllSiteUserCachData As List(Of SiteUser), Optional ByVal SetWindowsLoginName As String = Nothing, Optional ByVal ClientPCIPs As List(Of String) = Nothing) As ReceiveMessageRoleEnum
                Dim ReturnValue As ReceiveMessageRoleEnum = ReceiveMessageRoleEnum.UnKnow
                Dim IsSender As Boolean = False
                Dim IsReceiver As Boolean = False
                Dim WindowsLoginName As String = Nothing
                If Not IsNothing(SetWindowsLoginName) AndAlso SetWindowsLoginName.Split("\").Length > 1 Then
                    WindowsLoginName = SetWindowsLoginName.Split("\")(1).Trim
                Else
                    WindowsLoginName = SetWindowsLoginName.Trim
                End If


                For Each EachItem As SiteUser In AllSiteUserCachData
                    If Not String.IsNullOrEmpty(WindowsLoginName) AndAlso EachItem.UserPKeyKind = 2 AndAlso EachItem.UserPKey.Trim = WindowsLoginName AndAlso EachItem.ID.Trim = Me.FK_ToSiteUsersID.Trim Then
                        IsReceiver = True : Exit For
                    End If

                    If Not IsNothing(ClientPCIPs) AndAlso EachItem.UserPKeyKind = 1 AndAlso EachItem.ID.Trim = Me.FK_ToSiteUsersID.Trim Then
                        For Each EachIP As String In ClientPCIPs
                            If EachIP.Trim = EachItem.UserPKey.Trim Then
                                IsReceiver = True : Exit For
                            End If
                        Next
                    End If
                Next

                IsSender = Not String.IsNullOrEmpty(WindowsLoginName) AndAlso Not String.IsNullOrEmpty(Me.FromWindowLoginName) AndAlso Me.FromWindowLoginName.Trim = WindowsLoginName.Trim
                If IsReceiver = False AndAlso Not IsNothing(ClientPCIPs) Then
                    For Each EachIP As String In ClientPCIPs
                        If EachIP.Trim = Me.FromClientIP.Trim Then
                            IsSender = True : Exit For
                        End If
                    Next
                End If

                Select Case True
                    Case Not IsSender And Not IsReceiver
                        ReturnValue = ReceiveMessageRoleEnum.UnKnow
                    Case IsSender And Not IsReceiver
                        ReturnValue = ReceiveMessageRoleEnum.Sender
                    Case Not IsSender And IsReceiver
                        ReturnValue = ReceiveMessageRoleEnum.Receiver
                    Case IsSender And IsReceiver
                        ReturnValue = ReceiveMessageRoleEnum.SenderAndReceiver
                End Select
                Return ReturnValue
            End Function
#End Region
#Region "收訊者角色列舉 列舉:ReceiveMessageRoleEnum"
            ''' <summary>
            ''' 收訊者角色列舉
            ''' </summary>
            ''' <remarks></remarks>
            Public Enum ReceiveMessageRoleEnum
                UnKnow = 0
                Sender = 1
                Receiver = 2
                SenderAndReceiver = 3
            End Enum
#End Region
#Region "訊息確認狀態列舉 列舉:MessageCheckStateEnum"
            ''' <summary>
            ''' 訊息確認狀態列舉
            ''' </summary>
            ''' <remarks></remarks>
            Public Enum MessageCheckStateEnum
                NoNeedCheck = 0     '不須確認
                WaitCheck = 1       '等待確認
                Checked = 2         '已確認
            End Enum
#End Region
#Region "發送者資訊 屬性:SenderInformation"
            Shared _ALLWebLoginAccount As List(Of CompanyORMDB.SQLServer.QCDB01.WebLoginAccount) = Nothing
            Shared _ALLWebClientPCAccount As List(Of CompanyORMDB.SQLServer.QCDB01.WebClientPCAccount) = Nothing
            Private _SenderInformation As String = Nothing
            ''' <summary>
            ''' 發送者資訊
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
           ReadOnly Property SenderInformation() As String
                Get
                    If IsNothing(_SenderInformation) Then
                        If IsNothing(_ALLWebLoginAccount) Then
                            _ALLWebLoginAccount = SQLServer.QCDB01.WebLoginAccount.CDBSelect(Of SQLServer.QCDB01.WebLoginAccount)("Select * From WebLoginAccount ", (New SQLServer.QCDB01.WebLoginAccount).SQLQueryAdapterByThisObject)
                        End If
                        If IsNothing(_ALLWebClientPCAccount) Then
                            _ALLWebClientPCAccount = SQLServer.QCDB01.WebLoginAccount.CDBSelect(Of SQLServer.QCDB01.WebClientPCAccount)("Select * From WebClientPCAccount ", (New SQLServer.QCDB01.WebLoginAccount).SQLQueryAdapterByThisObject)
                        End If
                        If Not String.IsNullOrEmpty(Me.FromWindowLoginName) AndAlso Me.FromWindowLoginName.Trim.Length > 0 Then
                            For Each EachItem As SQLServer.QCDB01.WebLoginAccount In _ALLWebLoginAccount
                                If EachItem.WindowLoginName.Trim = Me.FromWindowLoginName.Trim Then
                                    _SenderInformation &= "Window 帳號:" & EachItem.WindowLoginName.Trim
                                    If Not String.IsNullOrEmpty(EachItem.Memo1) AndAlso EachItem.Memo1.Trim.Length > 0 Then
                                        _SenderInformation &= "(" & EachItem.Memo1.Trim & ")"
                                    End If
                                    Exit For
                                End If
                            Next
                        End If
                        If Not String.IsNullOrEmpty(Me.FromClientIP) AndAlso Me.FromClientIP.Trim.Length > 0 AndAlso FromClientIP.Trim <> "127.0.0.1" Then
                            For Each EachItem As SQLServer.QCDB01.WebClientPCAccount In _ALLWebClientPCAccount
                                If EachItem.ClientIP.Trim = Me.FromClientIP.Trim Then
                                    _SenderInformation &= IIf(IsNothing(_SenderInformation), Nothing, "/")
                                    _SenderInformation &= "電腦IP:" & EachItem.ClientIP.Trim
                                    If Not String.IsNullOrEmpty(EachItem.Memo1) AndAlso EachItem.Memo1.Trim.Length > 0 Then
                                        _SenderInformation &= "(" & EachItem.Memo1.Trim & ")"
                                    End If
                                    Exit For
                                End If
                            Next

                        End If
                    End If
                    Return _SenderInformation
                End Get
            End Property
#End Region
#Region "訊息接收者資訊 屬性:ReceiverInformation"
            Private _ReceiverInformation As String = Nothing
            Shared _AllSiteUser As List(Of SiteUser) = Nothing
            ''' <summary>
            ''' 訊息接收者資訊
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property ReceiverInformation() As String
                Get
                    If IsNothing(_ReceiverInformation) Then
                        If IsNothing(_AllSiteUser) Then
                            _AllSiteUser = SQLServer.IM.SiteUser.CDBSelect(Of SQLServer.IM.SiteUser)("Select * From SiteUser ", (New SQLServer.IM.SiteUser).SQLQueryAdapterByThisObject)
                        End If
                        Dim FindAboutSiteUser As SiteUser = Nothing
                        For Each EachItem As SiteUser In _AllSiteUser
                            If EachItem.ID = Me.FK_ToSiteUsersID Then
                                FindAboutSiteUser = EachItem
                                Exit For
                            End If
                        Next
                        If IsNothing(FindAboutSiteUser) Then
                            Return "未知 SiteUser=" & Me.FK_ToSiteUsersID
                        End If
                        If FindAboutSiteUser.UserPKeyKind = 1 Then
                            '使用IP
                            If IsNothing(_ALLWebClientPCAccount) Then
                                _ALLWebClientPCAccount = SQLServer.QCDB01.WebLoginAccount.CDBSelect(Of SQLServer.QCDB01.WebClientPCAccount)("Select * From WebClientPCAccount ", (New SQLServer.QCDB01.WebLoginAccount).SQLQueryAdapterByThisObject)
                            End If
                            For Each EachItem As QCDB01.WebClientPCAccount In _ALLWebClientPCAccount
                                If EachItem.ClientIP.Trim = FindAboutSiteUser.UserPKey.Trim Then
                                    _ReceiverInformation = "電腦IP:" & EachItem.ClientIP.Trim
                                    If Not String.IsNullOrEmpty(EachItem.Memo1) AndAlso EachItem.Memo1.Trim.Length > 0 Then
                                        _ReceiverInformation &= "(" & EachItem.Memo1.Trim & ")"
                                    End If
                                    Exit For
                                End If
                            Next
                        Else
                            '使用WindowName
                            If IsNothing(_ALLWebLoginAccount) Then
                                _ALLWebLoginAccount = SQLServer.QCDB01.WebLoginAccount.CDBSelect(Of SQLServer.QCDB01.WebLoginAccount)("Select * From WebLoginAccount ", (New SQLServer.QCDB01.WebLoginAccount).SQLQueryAdapterByThisObject)
                            End If
                            For Each EachItem As QCDB01.WebLoginAccount In _ALLWebLoginAccount
                                If EachItem.WindowLoginName.Trim = FindAboutSiteUser.UserPKey.Trim Then
                                    _ReceiverInformation = "Windows帳號:" & EachItem.WindowLoginName.Trim
                                    If Not String.IsNullOrEmpty(EachItem.Memo1) AndAlso EachItem.Memo1.Trim.Length > 0 Then
                                        _ReceiverInformation &= "(" & EachItem.Memo1.Trim & ")"
                                    End If
                                    Exit For
                                End If
                            Next
                        End If
                    End If
                    Return _ReceiverInformation
                End Get
            End Property
#End Region


        End Class


	End Namespace
End Namespace