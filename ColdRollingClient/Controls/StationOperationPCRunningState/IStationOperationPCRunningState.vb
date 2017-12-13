Public Interface IStationOperationPCRunningState

    Property ParentControl_CoilScanAndMachineProcess As CoilScanAndMachineProcess
    Function DataEndEditAndSave() As Integer
    ReadOnly Property EdittingData As CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState

End Interface
