Public Interface IStationRunningControl

    ReadOnly Property EdittingData As CompanyORMDB.SQLServer.PPS100LB.RunProcessData
    Property EditingCoilScanedTreeNode As CoilScanedTreeNode
    Function DataEndEditAndSave() As Integer
    Property ParentControl_CoilScanAndMachineProcess As CoilScanAndMachineProcess

End Interface
