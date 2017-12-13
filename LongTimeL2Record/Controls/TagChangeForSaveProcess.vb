Public Class TagChangeForSaveProcess
    Implements ITagChangeForProcess


#Region "產線名稱 屬性:LineName"
    ''' <summary>
    ''' 產線名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LineName As String = Nothing Implements ITagChangeForProcess.LineName  '尚未使用
#End Region

    Public Property ReadObjectRunningProcessStatus As Dictionary(Of String, String) Implements ITagChangeForProcess.ReadObjectRunningProcessStatus  '尚未使用

    Public Property WriteObjectRunningProcessStatus As Dictionary(Of String, String) Implements ITagChangeForProcess.WriteObjectRunningProcessStatus  '尚未使用

    Public Function ProcessChange(AllDatas As List(Of L2RealTimeTagDisplay), ChangedDatas As List(Of L2RealTimeTagDisplay), ByVal TimeOutDatas As List(Of L2RealTimeTagDisplay)) As Integer Implements ITagChangeForProcess.ProcessChange
        If IsNothing(ChangedDatas) Then
            Return 0
        End If
        Dim ReturnValue As Integer = 0
        Dim NowTime As DateTime = Now
        For Each EachItem As L2RealTimeTagDisplay In TimeOutDatas
            Dim SaveItem As New L2TagRecord
            With SaveItem
                .LineName = EachItem.LineName
                .TagName = EachItem.TagName
                .ValueCreateTime = NowTime
                .TagIntValue = EachItem.TagIntValue
                .TagStringValue = EachItem.TagStringValue
            End With
            ReturnValue += SaveItem.CDBSave
        Next
        Return ReturnValue
    End Function

End Class
