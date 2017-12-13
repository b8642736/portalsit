Public Class StationRadioButton
    Inherits RadioButton
    Sub New(ByVal SetUseStation As Station, ByVal SetCoilScanAndMachineProcess As CoilScanAndMachineProcess)
        UseStation = SetUseStation
        Me.Text = SetUseStation.StationName
        Me.ParentControl_CoilScanAndMachineProcess = SetCoilScanAndMachineProcess
    End Sub

#Region "使用Station 屬性:UseStation"

    Private _UseStation As Station
    ''' <summary>
    ''' 使用Station
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UseStation() As Station
        Get
            Return _UseStation
        End Get
        Private Set(ByVal value As Station)
            _UseStation = value
        End Set
    End Property

#End Region
#Region "上層控制項CoilScanAndMachineProcess 屬性:ParentControl_CoilScanAndMachineProcess"
    Private _ParentControl_CoilScanAndMachineProcess As CoilScanAndMachineProcess
    ''' <summary>
    ''' 上層控制項CoilScanAndMachineProcess
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ParentControl_CoilScanAndMachineProcess As CoilScanAndMachineProcess
        Get
            Return _ParentControl_CoilScanAndMachineProcess
        End Get
        Private Set(value As CoilScanAndMachineProcess)
            _ParentControl_CoilScanAndMachineProcess = value
        End Set
    End Property
#End Region

#Region "產生相對應之StationRunningControl 方法:CreateStationRunningControl"
    ''' <summary>
    ''' 產生相對應之StationRunningControl
    ''' </summary>
    ''' <param name="SourceData"></param>
    ''' <param name="SetEditingCoilScanedTreeNode">作為顯示特殊訂單之用</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateStationRunningControl(ByVal SourceData As CompanyORMDB.SQLServer.PPS100LB.RunProcessData, ByVal SetEditingCoilScanedTreeNode As CoilScanedTreeNode) As Control
        If IsNothing(SourceData) Then
            Return Nothing
        End If
        Select Case True
            Case Me.UseStation.StationName.Trim.Substring(0, 3) = "ZML"
                Return New ZML(SourceData, ParentControl_CoilScanAndMachineProcess, SetEditingCoilScanedTreeNode)
            Case Me.UseStation.StationName.Trim.Substring(0, 3) = "TLL"
                Return New TLL(SourceData, ParentControl_CoilScanAndMachineProcess, SetEditingCoilScanedTreeNode)
            Case Me.UseStation.StationName.Trim.Substring(0, 3) = "SPL"
                Return New SPL(SourceData, ParentControl_CoilScanAndMachineProcess, SetEditingCoilScanedTreeNode)
            Case Me.UseStation.StationName.Trim.Substring(0, 2) = "CP"
                Return New CPL(SourceData, ParentControl_CoilScanAndMachineProcess, SetEditingCoilScanedTreeNode)
            Case Me.UseStation.StationName.Trim.Substring(0, 3) = "APL"
                Return New APL(SourceData, ParentControl_CoilScanAndMachineProcess, SetEditingCoilScanedTreeNode)
            Case Me.UseStation.StationName.Trim.Substring(0, 3) = "SBL"
                Return New SBL(SourceData, ParentControl_CoilScanAndMachineProcess, SetEditingCoilScanedTreeNode)
            Case Me.UseStation.StationName.Trim.Substring(0, 3) = "GPL"
                Return New GPL(SourceData, ParentControl_CoilScanAndMachineProcess, SetEditingCoilScanedTreeNode)
            Case Me.UseStation.StationName.Trim.Substring(0, 3) = "BAL"
                Return New BAL(SourceData, ParentControl_CoilScanAndMachineProcess, SetEditingCoilScanedTreeNode)
        End Select

        Return Nothing
    End Function
#End Region

End Class
