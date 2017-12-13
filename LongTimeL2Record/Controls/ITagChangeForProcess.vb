Public Interface ITagChangeForProcess
    Property LineName As String
    Function ProcessChange(ByVal AllDatas As List(Of L2RealTimeTagDisplay), ByVal ChangedDatas As List(Of L2RealTimeTagDisplay), ByVal TimeOutDatas As List(Of L2RealTimeTagDisplay)) As Integer
    Property ReadObjectRunningProcessStatus As Dictionary(Of String, String)
    Property WriteObjectRunningProcessStatus As Dictionary(Of String, String)

End Interface
