Namespace SQLServer
    Namespace IM
        ''' <summary>
        ''' 分光室訊息溝通類別
        ''' </summary>
        ''' <remarks></remarks>
        <Serializable()> _
        Public Class SMPMessageNotice
            Inherits RemottingClassRefObjectBase

            Sub New()
                MyBase.New(WellKnownObjectMode.SingleCall, 7000, CompanyORMDB.SQLServer.IM.RemoteProtocolType.Tcp)
            End Sub

#Region "最後訊息接收時間 屬性:LastReceiveDBMessageTime"

            Private _LastReceiveDBMessageTime As DateTime
            ''' <summary>
            ''' 最後訊息接收時間
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property LastReceiveDBMessageTime() As DateTime
                Get
                    Return _LastReceiveDBMessageTime
                End Get
                Private Set(ByVal value As DateTime)
                    _LastReceiveDBMessageTime = value
                End Set
            End Property

#End Region
#Region "讀取資料庫交接班訊息 方法:ReadDBWaitReceived2CheckMessage"
            ''' <summary>
            ''' 讀取資料庫交接班訊息
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Shared Function ReadDBWaitReceived2CheckMessage() As List(Of MessageToSiteUsers)
                Dim QryString As String = "Select * From " & GetType(MessageToSiteUsers).Name & " Where "
                QryString &= "WaitReceived2CheckIP='" & CompanyORMDB.DeviceInformation.GetLocalIPs(0) & "'"
                QryString &= " Order by SendTime Desc "

                Dim ReturnValue As List(Of MessageToSiteUsers) = MessageToSiteUsers.CDBSelect(Of MessageToSiteUsers)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.WebService, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "IM", QryString)
                Return ReturnValue

            End Function
#End Region
#Region "讀取資料庫未確認訊息 方法:ReadDBNotCheckMessage"
            ''' <summary>
            ''' 讀取資料庫未確認訊息
            ''' </summary>
            ''' <remarks></remarks>
            Public Shared Function ReadDBNotCheckMessage() As List(Of MessageToSiteUsers)
                Dim PCIPQryString As String = Nothing
                For Each EachItem As String In CompanyORMDB.DeviceInformation.GetLocalIPs()
                    If EachItem.Length > 3 AndAlso EachItem.Substring(0, 3) <> "127" Then
                        PCIPQryString &= IIf(IsNothing(PCIPQryString), Nothing, ",") & EachItem.Trim
                        PCIPQryString = PCIPQryString.Replace(",", "','")
                    End If
                Next
                Dim WindowsLoginName As String = Nothing
                If Not String.IsNullOrEmpty(My.User.Name) AndAlso My.User.Name.Split("\").Length > 1 Then
                    WindowsLoginName = My.User.Name.Split("\")(1).Trim
                End If
                If String.IsNullOrEmpty(WindowsLoginName) AndAlso String.IsNullOrEmpty(PCIPQryString) Then
                    Return New List(Of MessageToSiteUsers)
                End If

                Dim QryString1 As String = "Select ID From " & GetType(SiteUser).Name & " Where "
                If Not String.IsNullOrEmpty(WindowsLoginName) Then
                    QryString1 &= " (UserPKeyKind=2 AND UserPKey='" & WindowsLoginName & "') "
                End If
                If Not String.IsNullOrEmpty(PCIPQryString) Then
                    QryString1 &= IIf(String.IsNullOrEmpty(WindowsLoginName), Nothing, " OR ")
                    QryString1 &= " (UserPKeyKind=1 AND UserPKey IN ('" & PCIPQryString & "'))"
                End If

                Dim ServerTime As DateTime = (New CompanyORMDB.WSDBSQLQueryAdapter).GetServerTime
                Dim QryString2 As String = "Select * From " & GetType(MessageToSiteUsers).Name & " Where "
                QryString2 &= "("
                QryString2 &= "IsReceived=0 AND FK_ToSiteUsersID IN (" & QryString1 & ") "
                QryString2 &= " AND ( IsHaveFinalRecieveTime=0 OR (IsHaveFinalRecieveTime=1 AND FinalRecieveTime>='" & Format(ServerTime, "yyyy/MM/dd HH:mm:ss") & "')) "
                QryString2 &= ") "

                If Not String.IsNullOrEmpty(WindowsLoginName) Or Not String.IsNullOrEmpty(PCIPQryString) Then
                    QryString2 &= " OR (IsHaveNotSendReplye=1 AND IsSenderReceiveNotSendReplye=0 AND NotSendReplyTime < '" & Format(ServerTime, "yyyy/MM/dd HH:mm:ss") & "' "

                    QryString2 &= " AND ( "
                    If Not IsNothing(WindowsLoginName) Then
                        QryString2 &= " FromWindowLoginName='" & WindowsLoginName & "' "
                    End If
                    If Not String.IsNullOrEmpty(PCIPQryString) Then
                        QryString2 &= IIf(Not String.IsNullOrEmpty(WindowsLoginName), " OR ", Nothing)
                        QryString2 &= " FromClientIP IN ('" & PCIPQryString & "')"
                    End If
                    QryString2 &= " ) "

                    QryString2 &= " ) "
                End If
                QryString2 &= " Order by SendTime Desc "


                Dim ReturnValue As List(Of MessageToSiteUsers) = MessageToSiteUsers.CDBSelect(Of MessageToSiteUsers)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.WebService, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "IM", QryString2)
                Dim NewThread As New Thread(AddressOf UpdateSystemReceiveTime)
                NewThread.Start(ReturnValue)

                Return ReturnValue

            End Function

            Private Shared Sub UpdateSystemReceiveTime(ByVal MessageToSiteUsers As Object)
                Dim LastReceiveDBMessageTime = (New CompanyORMDB.WSDBSQLQueryAdapter).GetServerTime
                Static SystemFirstReceiveTime As DateTime = (New MessageToSiteUsers).SystemFirstReceiveTime
                For Each EachItem As MessageToSiteUsers In MessageToSiteUsers
                    If EachItem.SystemFirstReceiveTime = SystemFirstReceiveTime Then
                        EachItem.SystemFirstReceiveTime = LastReceiveDBMessageTime
                        EachItem.SystemLastReceiveTime = LastReceiveDBMessageTime
                        EachItem.CDBSave()
                    Else
                        EachItem.SystemLastReceiveTime = LastReceiveDBMessageTime
                        EachItem.CDBSave()
                    End If
                Next

            End Sub
#End Region


#Region "通知接收資料庫訊息 函式:NoticeToReceiveDBMessage/NoticeToReceiveDBMessageEvent"
            Public Event NoticeToReceiveDBMessageEvent(ByVal Sender As SMPMessageNotice)
            ''' <summary>
            ''' 通知接收資料庫訊息
            ''' </summary>
            ''' <remarks></remarks>
            Public Sub NoticeToReceiveDBMessage()
                Dim NewThread As New Thread(AddressOf NoticeThread)
                NewThread.Start()
            End Sub

            Private Sub NoticeThread()
                RaiseEvent NoticeToReceiveDBMessageEvent(Me)
            End Sub
#End Region

#Region "通知系統設定變更 函式:NoticeChangedSystemConfig"
            Public Event NoticeChangedSystemConfigEvent(ByVal SetWebIP As String, ByVal SetAuthorityMode As Integer)
            ''' <summary>
            ''' 通知系統設定變更
            ''' </summary>
            ''' <param name="SetWebIP"></param>
            ''' <param name="SetAuthorityMode"></param>
            ''' <remarks></remarks>
            Public Sub NoticeChangedSystemConfig(ByVal SetWebIP As String, ByVal SetAuthorityMode As Integer)
                Dim NewThread As New Thread(AddressOf NoticeThread1)
                Dim Parameters As New List(Of Object)
                Parameters.Add(SetWebIP)
                Parameters.Add(SetAuthorityMode)
                NewThread.Start(Parameters)
            End Sub
            Private Sub NoticeThread1(ByVal Parameters As Object)
                Dim GetParameters As List(Of Object) = Parameters
                RaiseEvent NoticeChangedSystemConfigEvent(GetParameters(0), GetParameters(1))
            End Sub
#End Region


        End Class
    End Namespace
End Namespace