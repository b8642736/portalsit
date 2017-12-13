Namespace SQLServer
    Namespace IM
        ''' <summary>
        ''' 冷軋遠端鋼捲掃描訊息溝通類別
        ''' </summary>
        ''' <remarks></remarks>
        <Serializable()> _
        Public Class RemoteCoilScannerNotice
            Inherits RemottingClassRefObjectBase

            Sub New()
                MyBase.New(WellKnownObjectMode.SingleCall, 7100, CompanyORMDB.SQLServer.IM.RemoteProtocolType.Tcp)
            End Sub


#Region "通知重新讀取軋鋼作業執行狀態 函式:NoticeToReReadOperationPCRunningState/NoticeToReReadOperationPCRunningStateEvent"
            Public Event NoticeToReReadOperationPCRunningStateEvent(ByVal Sender As RemoteCoilScannerNotice)
            ''' <summary>
            ''' 通知讀取作業執行狀態
            ''' </summary>
            ''' <remarks></remarks>
            Public Sub NoticeToReReadOperationPCRunningState()
                Dim NewThread As New Thread(AddressOf NoticeThread)
                NewThread.Start()
            End Sub

            Private Sub NoticeThread()
                RaiseEvent NoticeToReReadOperationPCRunningStateEvent(Me)
            End Sub
#End Region

#Region "連線通知 ConnectNotice"
            Public Event ConnectNoticeEvent(ByVal FromPCIP As String)
            ''' <summary>
            ''' 連線通知(計劃每秒通知一次)
            ''' </summary>
            ''' <param name="FromPCIP"></param>
            ''' <remarks></remarks>
            Public Sub ConnectNotice(ByVal FromPCIP As String)
                Dim NewThread As New Thread(AddressOf ConnectNoticeThread)
                NewThread.Start(FromPCIP)
            End Sub

            Private Sub ConnectNoticeThread(ByVal Parameter As Object)
                RaiseEvent ConnectNoticeEvent(Parameter)
            End Sub
#End Region

        End Class

    End Namespace
End Namespace
