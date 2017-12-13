Public Interface IMonitorObject
    Property AllL2RealTimeTagDisplay As List(Of CompanyORMDB.SQLServer.IM.L2RealTimeTagDisplay)
    Property IsPauseGetData As Boolean
    Sub StartMonitorAllL2Tags()
    Sub StopMonitorAllL2Tags()

End Interface
