Namespace SQLServer
	Namespace PPS100LB
	Public Class OperationPCRunningState
	Inherits ClassDBSQLServer

	Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
                Me.LastSaveTime = New DateTime(2000, 1, 1)
            End Sub

#Region "RunningPCIP 屬性:RunningPCIP"
	Private _RunningPCIP As System.String
	''' <summary>
	''' RunningPCIP
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property RunningPCIP() As System.String
                Get
                    Return _RunningPCIP
                End Get
                Set(ByVal value As System.String)
                    _RunningPCIP = value
                End Set
            End Property
#End Region
#Region "RunPCName 屬性:RunPCName"
	Private _RunPCName As System.String
	''' <summary>
	''' RunPCName
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property RunPCName () As System.String
		Get
			Return _RunPCName
		End Get
		Set(Byval value as System.String)
			_RunPCName = value
		End Set
	End Property
#End Region
#Region "Line1WaitProcessCoils 屬性:Line1WaitProcessCoils"
            Private _Line1WaitProcessCoils As System.String
            ''' <summary>
            ''' Line1WaitProcessCoils
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Line1WaitProcessCoils() As System.String
                Get
                    Return _Line1WaitProcessCoils
                End Get
                Set(ByVal value As System.String)
                    _Line1WaitProcessCoils = value
                End Set
            End Property
#End Region
#Region "Line2WaitProcessCoils 屬性:Line2WaitProcessCoils"
            Private _Line2WaitProcessCoils As System.String
            ''' <summary>
            ''' Line1WaitProcessCoils
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Line2WaitProcessCoils() As System.String
                Get
                    Return _Line2WaitProcessCoils
                End Get
                Set(ByVal value As System.String)
                    _Line2WaitProcessCoils = value
                End Set
            End Property
#End Region
#Region "RunningProcessCoils 屬性:RunningProcessCoils"
	Private _RunningProcessCoils As System.String
	''' <summary>
	''' RunningProcessCoils
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property RunningProcessCoils () As System.String
		Get
			Return _RunningProcessCoils
		End Get
		Set(Byval value as System.String)
			_RunningProcessCoils = value
		End Set
	End Property
#End Region
#Region "FinishProcessWaitEditCoils 屬性:FinishProcessWaitEditCoils(此欄位已廢棄不用)"
            Private _FinishProcessWaitEditCoils As System.String
            ''' <summary>
            ''' FinishProcessWaitEditCoils(此欄位已廢棄不用)
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FinishProcessWaitEditCoils() As System.String
                Get
                    Return _FinishProcessWaitEditCoils
                End Get
                Set(ByVal value As System.String)
                    _FinishProcessWaitEditCoils = value
                End Set
            End Property
#End Region
#Region "MaxCoilNumberInRunningProcessSet 屬性:MaxCoilNumberInRunningProcessSet"
            Private _MaxCoilNumberInRunningProcessSet As System.Int32
            ''' <summary>
            ''' MaxCoilNumberInRunningProcessSet
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property MaxCoilNumberInRunningProcessSet() As System.Int32
                Get
                    Return _MaxCoilNumberInRunningProcessSet
                End Get
                Set(ByVal value As System.Int32)
                    _MaxCoilNumberInRunningProcessSet = value
                End Set
            End Property
#End Region
#Region "Line1COMPortNumber 屬性:Line1COMPortNumber"
	Private _Line1COMPortNumber As System.Int32
	''' <summary>
	''' Line1COMPortNumber
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Line1COMPortNumber () As System.Int32
		Get
			Return _Line1COMPortNumber
		End Get
		Set(Byval value as System.Int32)
			_Line1COMPortNumber = value
		End Set
	End Property
#End Region
#Region "Line2COMPortNumber 屬性:Line2COMPortNumber"
	Private _Line2COMPortNumber As System.Int32
	''' <summary>
	''' Line2COMPortNumber
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Line2COMPortNumber () As System.Int32
		Get
			Return _Line2COMPortNumber
		End Get
		Set(Byval value as System.Int32)
			_Line2COMPortNumber = value
		End Set
	End Property
#End Region
#Region "Line2IsEnable 屬性:Line2IsEnable"
	Private _Line2IsEnable As System.Boolean
	''' <summary>
	''' Line2IsEnable
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Line2IsEnable () As System.Boolean
		Get
			Return _Line2IsEnable
		End Get
		Set(Byval value as System.Boolean)
			_Line2IsEnable = value
		End Set
	End Property
#End Region
#Region "預設使用站名稱 屬性:DefaultUseStationName"

            Private _DefaultUseStationName As String
            ''' <summary>
            ''' 預設使用站名稱
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property DefaultUseStationName() As String
                Get
                    Return _DefaultUseStationName
                End Get
                Set(ByVal value As String)
                    _DefaultUseStationName = value
                End Set
            End Property

#End Region
#Region "最後儲存時間 屬性:LastSaveTime"
            Private _LastSaveTime As DateTime
            ''' <summary>
            ''' 最後儲存時間
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property LastSaveTime() As DateTime
                Get
                    Return _LastSaveTime
                End Get
                Set(ByVal value As DateTime)
                    _LastSaveTime = value
                End Set
            End Property
#End Region
#Region "遠端鋼捲掃描手動加入鋼捲準備線1暫存區 屬性:RemoteScannerManualAddLine1Coils"
            Private _RemoteScannerManualAddLine1Coils As String
            ''' <summary>
            ''' 遠端鋼捲掃描手動加入鋼捲準備線1暫存區
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property RemoteScannerManualAddLine1Coils() As String
                Get
                    Return _RemoteScannerManualAddLine1Coils
                End Get
                Set(ByVal value As String)
                    _RemoteScannerManualAddLine1Coils = value
                End Set
            End Property

#End Region
#Region "遠端鋼捲掃描手動加入鋼捲準備線2暫存區 屬性:RemoteScannerManualAddLine2Coils"
            Private _RemoteScannerManualAddLine2Coils As String
            ''' <summary>
            ''' 遠端鋼捲掃描手動加入鋼捲準備線2暫存區
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property RemoteScannerManualAddLine2Coils() As String
                Get
                    Return _RemoteScannerManualAddLine2Coils
                End Get
                Set(ByVal value As String)
                    _RemoteScannerManualAddLine2Coils = value
                End Set
            End Property
#End Region
#Region "當CoilEnd發生是否自動產生CoilStart 屬性:IsAutoCoilStartWhenCoilEnd"
            Private _IsAutoCoilStartWhenCoilEnd As Boolean
            ''' <summary>
            ''' 當CoilEnd發生是否自動產生CoilStart
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property IsAutoCoilStartWhenCoilEnd() As Boolean
                Get
                    Return _IsAutoCoilStartWhenCoilEnd
                End Get
                Set(ByVal value As Boolean)
                    _IsAutoCoilStartWhenCoilEnd = value
                End Set
            End Property

#End Region
#Region "用戶端應用程式執行模式 屬性:ClientRunningMode"
            Private _ClientRunningMode As Integer = 0
            ''' <summary>
            ''' 用戶端應用程式執行模式
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks>0.單機模式 1.APL Remote模式</remarks>
            Public Property ClientRunningMode() As Integer
                Get
                    Return _ClientRunningMode
                End Get
                Set(ByVal value As Integer)
                    _ClientRunningMode = value
                    AboutServerOperationPCRunningState = Nothing
                End Set
            End Property
#End Region
#Region "用戶端連線至伺服端的IP 屬性:ClientRemoteToServerIP"
            Private _ClientRemoteToServerIP As String
            ''' <summary>
            ''' 用戶端連線至伺服端的IP
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ClientRemoteToServerIP() As String
                Get
                    Return _ClientRemoteToServerIP
                End Get
                Set(ByVal value As String)
                    _ClientRemoteToServerIP = value
                    AboutServerOperationPCRunningState = Nothing
                End Set
            End Property

#End Region
#Region "ZML_BURod1 屬性:ZML_BURod1"
            Private _ZML_BURod1 As System.String
            ''' <summary>
            ''' 背輥A
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_BURod1() As System.String
                Get
                    Return _ZML_BURod1
                End Get
                Set(ByVal value As System.String)
                    _ZML_BURod1 = value
                End Set
            End Property
#End Region
#Region "ZML_BURod2 屬性:ZML_BURod2"
            Private _ZML_BURod2 As System.String
            ''' <summary>
            ''' 背輥B
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_BURod2() As System.String
                Get
                    Return _ZML_BURod2
                End Get
                Set(ByVal value As System.String)
                    _ZML_BURod2 = value
                End Set
            End Property
#End Region
#Region "ZML_BURod3 屬性:ZML_BURod3"
            Private _ZML_BURod3 As System.String
            ''' <summary>
            ''' 背輥C
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_BURod3() As System.String
                Get
                    Return _ZML_BURod3
                End Get
                Set(ByVal value As System.String)
                    _ZML_BURod3 = value
                End Set
            End Property
#End Region
#Region "ZML_BURod4 屬性:ZML_BURod4"
            Private _ZML_BURod4 As System.String
            ''' <summary>
            ''' 背輥D
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_BURod4() As System.String
                Get
                    Return _ZML_BURod4
                End Get
                Set(ByVal value As System.String)
                    _ZML_BURod4 = value
                End Set
            End Property
#End Region
#Region "ZML_BDRod1 屬性:ZML_BDRod1"
            Private _ZML_BDRod1 As System.String
            ''' <summary>
            ''' 背輥E
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_BDRod1() As System.String
                Get
                    Return _ZML_BDRod1
                End Get
                Set(ByVal value As System.String)
                    _ZML_BDRod1 = value
                End Set
            End Property
#End Region
#Region "ZML_BDRod2 屬性:ZML_BDRod2"
            Private _ZML_BDRod2 As System.String
            ''' <summary>
            ''' 背輥F
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_BDRod2() As System.String
                Get
                    Return _ZML_BDRod2
                End Get
                Set(ByVal value As System.String)
                    _ZML_BDRod2 = value
                End Set
            End Property
#End Region
#Region "ZML_BDRod3 屬性:ZML_BDRod3"
            Private _ZML_BDRod3 As System.String
            ''' <summary>
            ''' 背輥G
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_BDRod3() As System.String
                Get
                    Return _ZML_BDRod3
                End Get
                Set(ByVal value As System.String)
                    _ZML_BDRod3 = value
                End Set
            End Property
#End Region
#Region "ZML_BDRod4 屬性:ZML_BDRod4"
            Private _ZML_BDRod4 As System.String
            ''' <summary>
            ''' 背輥H
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_BDRod4() As System.String
                Get
                    Return _ZML_BDRod4
                End Get
                Set(ByVal value As System.String)
                    _ZML_BDRod4 = value
                End Set
            End Property
#End Region
#Region "ZML_MURod1 屬性:ZML_MURod1"
            Private _ZML_MURod1 As System.String
            ''' <summary>
            ''' 上左驅輥
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_MURod1() As System.String
                Get
                    Return _ZML_MURod1
                End Get
                Set(ByVal value As System.String)
                    _ZML_MURod1 = value
                End Set
            End Property
#End Region
#Region "ZML_MURod2 屬性:ZML_MURod2"
            Private _ZML_MURod2 As System.String
            ''' <summary>
            ''' 上惰輥
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_MURod2() As System.String
                Get
                    Return _ZML_MURod2
                End Get
                Set(ByVal value As System.String)
                    _ZML_MURod2 = value
                End Set
            End Property
#End Region
#Region "ZML_MURod3 屬性:ZML_MURod3"
            Private _ZML_MURod3 As System.String
            ''' <summary>
            ''' 上右驅輥
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_MURod3() As System.String
                Get
                    Return _ZML_MURod3
                End Get
                Set(ByVal value As System.String)
                    _ZML_MURod3 = value
                End Set
            End Property
#End Region
#Region "ZML_MDRod1 屬性:ZML_MDRod1"
            Private _ZML_MDRod1 As System.String
            ''' <summary>
            ''' 下左驅輥
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_MDRod1() As System.String
                Get
                    Return _ZML_MDRod1
                End Get
                Set(ByVal value As System.String)
                    _ZML_MDRod1 = value
                End Set
            End Property
#End Region
#Region "ZML_MDRod2 屬性:ZML_MDRod2"
            Private _ZML_MDRod2 As System.String
            ''' <summary>
            ''' 下惰輥
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_MDRod2() As System.String
                Get
                    Return _ZML_MDRod2
                End Get
                Set(ByVal value As System.String)
                    _ZML_MDRod2 = value
                End Set
            End Property
#End Region
#Region "ZML_MDRod3 屬性:ZML_MDRod3"
            Private _ZML_MDRod3 As System.String
            ''' <summary>
            ''' 下右驅輥
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_MDRod3() As System.String
                Get
                    Return _ZML_MDRod3
                End Get
                Set(ByVal value As System.String)
                    _ZML_MDRod3 = value
                End Set
            End Property
#End Region
#Region "ZML_SURod1 屬性:ZML_SURod1"
            Private _ZML_SURod1 As System.String
            ''' <summary>
            ''' 上左第一中間輥
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_SURod1() As System.String
                Get
                    Return _ZML_SURod1
                End Get
                Set(ByVal value As System.String)
                    _ZML_SURod1 = value
                End Set
            End Property
#End Region
#Region "ZML_SURod3 屬性:ZML_SURod3"
            Private _ZML_SURod3 As System.String
            ''' <summary>
            ''' 上右第一中間輥
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_SURod3() As System.String
                Get
                    Return _ZML_SURod3
                End Get
                Set(ByVal value As System.String)
                    _ZML_SURod3 = value
                End Set
            End Property
#End Region
#Region "ZML_SDRod1 屬性:ZML_SDRod1"
            Private _ZML_SDRod1 As System.String
            ''' <summary>
            ''' 下左第一中間輥
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_SDRod1() As System.String
                Get
                    Return _ZML_SDRod1
                End Get
                Set(ByVal value As System.String)
                    _ZML_SDRod1 = value
                End Set
            End Property
#End Region
#Region "ZML_SDRod3 屬性:ZML_SDRod3"
            Private _ZML_SDRod3 As System.String
            ''' <summary>
            ''' 下右第一中間輥
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_SDRod3() As System.String
                Get
                    Return _ZML_SDRod3
                End Get
                Set(ByVal value As System.String)
                    _ZML_SDRod3 = value
                End Set
            End Property
#End Region
#Region "ZML_AT1 屬性:ZML_AT1"
            Private _ZML_AT1 As System.Decimal
            ''' <summary>
            ''' ZML_AT1
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_AT1() As System.Decimal
                Get
                    Return _ZML_AT1
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_AT1 = value
                End Set
            End Property
#End Region
#Region "ZML_AT2 屬性:ZML_AT2"
            Private _ZML_AT2 As System.Decimal
            ''' <summary>
            ''' ZML_AT2
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_AT2() As System.Decimal
                Get
                    Return _ZML_AT2
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_AT2 = value
                End Set
            End Property
#End Region
#Region "ZML_AT3 屬性:ZML_AT3"
            Private _ZML_AT3 As System.Decimal
            ''' <summary>
            ''' ZML_AT3
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_AT3() As System.Decimal
                Get
                    Return _ZML_AT3
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_AT3 = value
                End Set
            End Property
#End Region
#Region "ZML_AT4 屬性:ZML_AT4"
            Private _ZML_AT4 As System.Decimal
            ''' <summary>
            ''' ZML_AT4
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_AT4() As System.Decimal
                Get
                    Return _ZML_AT4
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_AT4 = value
                End Set
            End Property
#End Region
#Region "ZML_AT5 屬性:ZML_AT5"
            Private _ZML_AT5 As System.Decimal
            ''' <summary>
            ''' ZML_AT5
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_AT5() As System.Decimal
                Get
                    Return _ZML_AT5
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_AT5 = value
                End Set
            End Property
#End Region
#Region "ZML_AT6 屬性:ZML_AT6"
            Private _ZML_AT6 As System.Decimal
            ''' <summary>
            ''' ZML_AT6
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_AT6() As System.Decimal
                Get
                    Return _ZML_AT6
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_AT6 = value
                End Set
            End Property
#End Region
#Region "ZML_BT1 屬性:ZML_BT1"
            Private _ZML_BT1 As System.Decimal
            ''' <summary>
            ''' ZML_BT1
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_BT1() As System.Decimal
                Get
                    Return _ZML_BT1
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_BT1 = value
                End Set
            End Property
#End Region
#Region "ZML_BT2 屬性:ZML_BT2"
            Private _ZML_BT2 As System.Decimal
            ''' <summary>
            ''' ZML_BT2
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_BT2() As System.Decimal
                Get
                    Return _ZML_BT2
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_BT2 = value
                End Set
            End Property
#End Region
#Region "ZML_BT3 屬性:ZML_BT3"
            Private _ZML_BT3 As System.Decimal
            ''' <summary>
            ''' ZML_BT3
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_BT3() As System.Decimal
                Get
                    Return _ZML_BT3
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_BT3 = value
                End Set
            End Property
#End Region
#Region "ZML_BT4 屬性:ZML_BT4"
            Private _ZML_BT4 As System.Decimal
            ''' <summary>
            ''' ZML_BT4
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_BT4() As System.Decimal
                Get
                    Return _ZML_BT4
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_BT4 = value
                End Set
            End Property
#End Region
#Region "ZML_BT5 屬性:ZML_BT5"
            Private _ZML_BT5 As System.Decimal
            ''' <summary>
            ''' ZML_BT5
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_BT5() As System.Decimal
                Get
                    Return _ZML_BT5
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_BT5 = value
                End Set
            End Property
#End Region
#Region "ZML_BT6 屬性:ZML_BT6"
            Private _ZML_BT6 As System.Decimal
            ''' <summary>
            ''' ZML_BT6
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_BT6() As System.Decimal
                Get
                    Return _ZML_BT6
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_BT6 = value
                End Set
            End Property
#End Region
#Region "ZML_CT1 屬性:ZML_CT1"
            Private _ZML_CT1 As System.Decimal
            ''' <summary>
            ''' ZML_CT1
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_CT1() As System.Decimal
                Get
                    Return _ZML_CT1
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_CT1 = value
                End Set
            End Property
#End Region
#Region "ZML_CT2 屬性:ZML_CT2"
            Private _ZML_CT2 As System.Decimal
            ''' <summary>
            ''' ZML_CT2
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_CT2() As System.Decimal
                Get
                    Return _ZML_CT2
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_CT2 = value
                End Set
            End Property
#End Region
#Region "ZML_CT3 屬性:ZML_CT3"
            Private _ZML_CT3 As System.Decimal
            ''' <summary>
            ''' ZML_CT3
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_CT3() As System.Decimal
                Get
                    Return _ZML_CT3
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_CT3 = value
                End Set
            End Property
#End Region
#Region "ZML_CT4 屬性:ZML_CT4"
            Private _ZML_CT4 As System.Decimal
            ''' <summary>
            ''' ZML_CT4
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_CT4() As System.Decimal
                Get
                    Return _ZML_CT4
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_CT4 = value
                End Set
            End Property
#End Region
#Region "ZML_CT5 屬性:ZML_CT5"
            Private _ZML_CT5 As System.Decimal
            ''' <summary>
            ''' ZML_CT5
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_CT5() As System.Decimal
                Get
                    Return _ZML_CT5
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_CT5 = value
                End Set
            End Property
#End Region
#Region "ZML_CT6 屬性:ZML_CT6"
            Private _ZML_CT6 As System.Decimal
            ''' <summary>
            ''' ZML_CT6
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_CT6() As System.Decimal
                Get
                    Return _ZML_CT6
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_CT6 = value
                End Set
            End Property
#End Region
#Region "ZML_DT1 屬性:ZML_DT1"
            Private _ZML_DT1 As System.Decimal
            ''' <summary>
            ''' ZML_DT1
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_DT1() As System.Decimal
                Get
                    Return _ZML_DT1
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_DT1 = value
                End Set
            End Property
#End Region
#Region "ZML_DT2 屬性:ZML_DT2"
            Private _ZML_DT2 As System.Decimal
            ''' <summary>
            ''' ZML_DT2
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_DT2() As System.Decimal
                Get
                    Return _ZML_DT2
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_DT2 = value
                End Set
            End Property
#End Region
#Region "ZML_DT3 屬性:ZML_DT3"
            Private _ZML_DT3 As System.Decimal
            ''' <summary>
            ''' ZML_DT3
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_DT3() As System.Decimal
                Get
                    Return _ZML_DT3
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_DT3 = value
                End Set
            End Property
#End Region
#Region "ZML_DT4 屬性:ZML_DT4"
            Private _ZML_DT4 As System.Decimal
            ''' <summary>
            ''' ZML_DT4
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_DT4() As System.Decimal
                Get
                    Return _ZML_DT4
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_DT4 = value
                End Set
            End Property
#End Region
#Region "ZML_DT5 屬性:ZML_DT5"
            Private _ZML_DT5 As System.Decimal
            ''' <summary>
            ''' ZML_DT5
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_DT5() As System.Decimal
                Get
                    Return _ZML_DT5
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_DT5 = value
                End Set
            End Property
#End Region
#Region "ZML_DT6 屬性:ZML_DT6"
            Private _ZML_DT6 As System.Decimal
            ''' <summary>
            ''' ZML_DT6
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_DT6() As System.Decimal
                Get
                    Return _ZML_DT6
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_DT6 = value
                End Set
            End Property
#End Region
#Region "ZML_ET1 屬性:ZML_ET1"
            Private _ZML_ET1 As System.Decimal
            ''' <summary>
            ''' ZML_ET1
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_ET1() As System.Decimal
                Get
                    Return _ZML_ET1
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_ET1 = value
                End Set
            End Property
#End Region
#Region "ZML_ET2 屬性:ZML_ET2"
            Private _ZML_ET2 As System.Decimal
            ''' <summary>
            ''' ZML_ET2
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_ET2() As System.Decimal
                Get
                    Return _ZML_ET2
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_ET2 = value
                End Set
            End Property
#End Region
#Region "ZML_ET3 屬性:ZML_ET3"
            Private _ZML_ET3 As System.Decimal
            ''' <summary>
            ''' ZML_ET3
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_ET3() As System.Decimal
                Get
                    Return _ZML_ET3
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_ET3 = value
                End Set
            End Property
#End Region
#Region "ZML_ET4 屬性:ZML_ET4"
            Private _ZML_ET4 As System.Decimal
            ''' <summary>
            ''' ZML_ET4
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_ET4() As System.Decimal
                Get
                    Return _ZML_ET4
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_ET4 = value
                End Set
            End Property
#End Region
#Region "ZML_ET5 屬性:ZML_ET5"
            Private _ZML_ET5 As System.Decimal
            ''' <summary>
            ''' ZML_ET5
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_ET5() As System.Decimal
                Get
                    Return _ZML_ET5
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_ET5 = value
                End Set
            End Property
#End Region
#Region "ZML_ET6 屬性:ZML_ET6"
            Private _ZML_ET6 As System.Decimal
            ''' <summary>
            ''' ZML_ET6
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_ET6() As System.Decimal
                Get
                    Return _ZML_ET6
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_ET6 = value
                End Set
            End Property
#End Region
#Region "ZML_FT1 屬性:ZML_FT1"
            Private _ZML_FT1 As System.Decimal
            ''' <summary>
            ''' ZML_FT1
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_FT1() As System.Decimal
                Get
                    Return _ZML_FT1
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_FT1 = value
                End Set
            End Property
#End Region
#Region "ZML_FT2 屬性:ZML_FT2"
            Private _ZML_FT2 As System.Decimal
            ''' <summary>
            ''' ZML_FT2
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_FT2() As System.Decimal
                Get
                    Return _ZML_FT2
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_FT2 = value
                End Set
            End Property
#End Region
#Region "ZML_FT3 屬性:ZML_FT3"
            Private _ZML_FT3 As System.Decimal
            ''' <summary>
            ''' ZML_FT3
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_FT3() As System.Decimal
                Get
                    Return _ZML_FT3
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_FT3 = value
                End Set
            End Property
#End Region
#Region "ZML_FT4 屬性:ZML_FT4"
            Private _ZML_FT4 As System.Decimal
            ''' <summary>
            ''' ZML_FT4
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_FT4() As System.Decimal
                Get
                    Return _ZML_FT4
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_FT4 = value
                End Set
            End Property
#End Region
#Region "ZML_FT5 屬性:ZML_FT5"
            Private _ZML_FT5 As System.Decimal
            ''' <summary>
            ''' ZML_FT5
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_FT5() As System.Decimal
                Get
                    Return _ZML_FT5
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_FT5 = value
                End Set
            End Property
#End Region
#Region "ZML_FT6 屬性:ZML_FT6"
            Private _ZML_FT6 As System.Decimal
            ''' <summary>
            ''' ZML_FT6
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_FT6() As System.Decimal
                Get
                    Return _ZML_FT6
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_FT6 = value
                End Set
            End Property
#End Region
#Region "ZML_GT1 屬性:ZML_GT1"
            Private _ZML_GT1 As System.Decimal
            ''' <summary>
            ''' ZML_GT1
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_GT1() As System.Decimal
                Get
                    Return _ZML_GT1
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_GT1 = value
                End Set
            End Property
#End Region
#Region "ZML_GT2 屬性:ZML_GT2"
            Private _ZML_GT2 As System.Decimal
            ''' <summary>
            ''' ZML_GT2
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_GT2() As System.Decimal
                Get
                    Return _ZML_GT2
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_GT2 = value
                End Set
            End Property
#End Region
#Region "ZML_GT3 屬性:ZML_GT3"
            Private _ZML_GT3 As System.Decimal
            ''' <summary>
            ''' ZML_GT3
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_GT3() As System.Decimal
                Get
                    Return _ZML_GT3
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_GT3 = value
                End Set
            End Property
#End Region
#Region "ZML_GT4 屬性:ZML_GT4"
            Private _ZML_GT4 As System.Decimal
            ''' <summary>
            ''' ZML_GT4
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_GT4() As System.Decimal
                Get
                    Return _ZML_GT4
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_GT4 = value
                End Set
            End Property
#End Region
#Region "ZML_GT5 屬性:ZML_GT5"
            Private _ZML_GT5 As System.Decimal
            ''' <summary>
            ''' ZML_GT5
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_GT5() As System.Decimal
                Get
                    Return _ZML_GT5
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_GT5 = value
                End Set
            End Property
#End Region
#Region "ZML_GT6 屬性:ZML_GT6"
            Private _ZML_GT6 As System.Decimal
            ''' <summary>
            ''' ZML_GT6
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_GT6() As System.Decimal
                Get
                    Return _ZML_GT6
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_GT6 = value
                End Set
            End Property
#End Region
#Region "ZML_HT1 屬性:ZML_HT1"
            Private _ZML_HT1 As System.Decimal
            ''' <summary>
            ''' ZML_HT1
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_HT1() As System.Decimal
                Get
                    Return _ZML_HT1
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_HT1 = value
                End Set
            End Property
#End Region
#Region "ZML_HT2 屬性:ZML_HT2"
            Private _ZML_HT2 As System.Decimal
            ''' <summary>
            ''' ZML_HT2
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_HT2() As System.Decimal
                Get
                    Return _ZML_HT2
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_HT2 = value
                End Set
            End Property
#End Region
#Region "ZML_HT3 屬性:ZML_HT3"
            Private _ZML_HT3 As System.Decimal
            ''' <summary>
            ''' ZML_HT3
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_HT3() As System.Decimal
                Get
                    Return _ZML_HT3
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_HT3 = value
                End Set
            End Property
#End Region
#Region "ZML_HT4 屬性:ZML_HT4"
            Private _ZML_HT4 As System.Decimal
            ''' <summary>
            ''' ZML_HT4
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_HT4() As System.Decimal
                Get
                    Return _ZML_HT4
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_HT4 = value
                End Set
            End Property
#End Region
#Region "ZML_HT5 屬性:ZML_HT5"
            Private _ZML_HT5 As System.Decimal
            ''' <summary>
            ''' ZML_HT5
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_HT5() As System.Decimal
                Get
                    Return _ZML_HT5
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_HT5 = value
                End Set
            End Property
#End Region
#Region "ZML_HT6 屬性:ZML_HT6"
            Private _ZML_HT6 As System.Decimal
            ''' <summary>
            ''' ZML_HT6
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_HT6() As System.Decimal
                Get
                    Return _ZML_HT6
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_HT6 = value
                End Set
            End Property
#End Region
#Region "IsStopL2MsgTalk 屬性:IsStopL2MsgTalk"
            Private _IsStopL2MsgTalk As System.Boolean
            ''' <summary>
            ''' 是否停止硬體L2訊傳送接收
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property IsStopL2MsgTalk() As System.Boolean
                Get
                    Return _IsStopL2MsgTalk
                End Get
                Set(ByVal value As System.Boolean)
                    _IsStopL2MsgTalk = value
                End Set
            End Property
#End Region
#Region "IsStopPDIMsgTalk 屬性:IsStopPDIMsgTalk"
            Private _IsStopPDIMsgTalk As System.Boolean
            ''' <summary>
            ''' 是否停止PDI訊號傳送
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property IsStopPDIMsgTalk() As System.Boolean
                Get
                    Return _IsStopPDIMsgTalk
                End Get
                Set(ByVal value As System.Boolean)
                    _IsStopPDIMsgTalk = value
                End Set
            End Property
#End Region
#Region "IsStopPDOMsgTalk 屬性:IsStopPDOMsgTalk"
            Private _IsStopPDOMsgTalk As System.Boolean
            ''' <summary>
            ''' 是否停止PDO訊號接收
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property IsStopPDOMsgTalk() As System.Boolean
                Get
                    Return _IsStopPDOMsgTalk
                End Get
                Set(ByVal value As System.Boolean)
                    _IsStopPDOMsgTalk = value
                End Set
            End Property
#End Region
#Region "印表標籤數列印頁數 屬性:LabelPrintPageCount"
            Private _LabelPrintPageCount As Integer = 2
            ''' <summary>
            ''' 印表標籤數列印頁數
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property LabelPrintPageCount() As Integer
                Get
                    If _LabelPrintPageCount <= 0 Then
                        _LabelPrintPageCount = 2
                    End If
                    Return _LabelPrintPageCount
                End Get
                Set(ByVal value As Integer)
                    _LabelPrintPageCount = value
                End Set
            End Property

#End Region



#Region "相關OperationPCRunningStateDetail 屬性:AboutOperationPCRunningStateDetails"
            ''' <summary>
            ''' 相關OperationPCRunningStateDetail
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property AboutOperationPCRunningStateDetails As List(Of OperationPCRunningStateDetail)
                Get
                    Dim SearchCoils As String = Me.Line1WaitProcessCoils
                    SearchCoils &= IIf(Not String.IsNullOrEmpty(SearchCoils) AndAlso SearchCoils.Trim.Length > 0, ";", Nothing) & Me.Line2WaitProcessCoils
                    SearchCoils = SearchCoils.Replace(";", "','")
                    Dim QryString As String = "Select * from OperationPCRunningStateDetail Where RunningPCIP='" & Me.RunningPCIP & "' and RunningProcessCoilNumber in ('" & SearchCoils & "') order by RunningProcessCoilNumber"
                    Return OperationPCRunningStateDetail.CDBSelect(Of OperationPCRunningStateDetail)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
                End Get
            End Property
#End Region
#Region "相關伺服端之OperationPCRunningState 屬性:AboutServerOperationPCRunningState"
            Dim _LastAccessTime As DateTime = Now.AddSeconds(-3)
            Private _AboutServerOperationPCRunningState As OperationPCRunningState
            ''' <summary>
            ''' 相關伺服端之OperationPCRunningState
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Property AboutServerOperationPCRunningState As OperationPCRunningState
                Get
                    If IsNothing(_AboutServerOperationPCRunningState) Then
                        If Me.ClientRunningMode = 1 AndAlso Now.Subtract(_LastAccessTime).TotalSeconds > 2 AndAlso Not String.IsNullOrEmpty(Me.ClientRemoteToServerIP) AndAlso Me.ClientRemoteToServerIP.Trim.Length > 0 Then
                            Dim SQLString As String = "Select * from OperationPCRunningState Where RunningPCIP='" & Me.ClientRemoteToServerIP.Trim & "'"
                            Dim SearchResult As List(Of CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState) = CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState.CDBSelect(Of CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLString)
                            If SearchResult.Count = 0 Then
                                _AboutServerOperationPCRunningState = Nothing
                            Else
                                _AboutServerOperationPCRunningState = SearchResult(0)
                            End If
                            _LastAccessTime = Now
                        End If
                    End If
                    Return _AboutServerOperationPCRunningState
                End Get
                Private Set(value As OperationPCRunningState)
                    _AboutServerOperationPCRunningState = value
                    _LastAccessTime = Now.AddSeconds(-3)
                End Set
            End Property
#End Region
#Region "此筆OperationPCRunningState是否為本機OperationPCRunningState 屬性:IsTheOperationPCRunningStateForThisMachine"
            ''' <summary>
            ''' 此筆OperationPCRunningState是否為本機OperationPCRunningState
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property IsTheOperationPCRunningStateForThisMachine As Boolean
                Get
                    Return Me.RunningPCIP.Trim = DeviceInformation.GetLocalIPs(0).Trim
                End Get
            End Property
#End Region
#Region "相關CoilEnd等待編輯之所有鋼捲編號 屬性:AboutFinishProcessWaitEditCoilNumbers"
            ''' <summary>
            ''' 相關CoilEnd等待編輯之所有鋼捲編號
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property AboutFinishProcessWaitEditCoilNumbers As List(Of String)
                Get
                    Dim QryString As String = "Select FK_LastRefSHA01, FK_LastRefSHA02, FK_LastRefSHA04,SysCoilEndTime From RunProcessData Where RunStationPCIP='" & PPSSHAPFFlowAdapter.CurrentOperationPCRunningState.RunningPCIP.Trim & "' and FK_RunStationName='" & Me.DefaultUseStationName.Trim & "' and ThisRecordState='2' order by SysCoilEndTime Desc"
                    Dim SQLAdapter As New SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")

                    Dim AddedReturnData As New List(Of String)
                    Dim ReturnValue As New List(Of String)
                    For Each EachItem As DataRow In SQLAdapter.SelectQuery(QryString).Rows
                        Dim AddValue1 As String = EachItem.Item("FK_LastRefSHA01") & EachItem.Item("FK_LastRefSHA02") & EachItem.Item("FK_LastRefSHA04")
                        Dim AddValue2 As String = EachItem.Item("FK_LastRefSHA01") & EachItem.Item("FK_LastRefSHA02")
                        If AddedReturnData.Contains(AddValue1) = False Then
                            AddedReturnData.Add(AddValue1)
                            ReturnValue.Add(AddValue2)
                        End If
                    Next
                    Return ReturnValue
                End Get
            End Property
#End Region
#Region "相關CoilEnd等待編輯之所有鋼捲編號(前50筆) 屬性:AboutTop50FinishProcessWaitEditCoilNumbers"
            ''' <summary>
            ''' 相關CoilEnd等待編輯之所有鋼捲編號(前50筆)
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property AboutTop50FinishProcessWaitEditCoilNumbers As List(Of String)
                Get
                    Dim QryString As String = "Select TOP 50 FK_LastRefSHA01, FK_LastRefSHA02, FK_LastRefSHA04,SysCoilEndTime From RunProcessData Where RunStationPCIP='" & PPSSHAPFFlowAdapter.CurrentOperationPCRunningState.RunningPCIP.Trim & "' and FK_RunStationName='" & Me.DefaultUseStationName.Trim & "' and ThisRecordState='2' order by SysCoilEndTime Desc"
                    Dim SQLAdapter As New SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")

                    Dim AddedReturnData As New List(Of String)
                    Dim ReturnValue As New List(Of String)
                    For Each EachItem As DataRow In SQLAdapter.SelectQuery(QryString).Rows
                        Dim AddValue1 As String = EachItem.Item("FK_LastRefSHA01") & EachItem.Item("FK_LastRefSHA02") & EachItem.Item("FK_LastRefSHA04")
                        Dim AddValue2 As String = EachItem.Item("FK_LastRefSHA01") & EachItem.Item("FK_LastRefSHA02")
                        If AddedReturnData.Contains(AddValue1) = False Then
                            AddedReturnData.Add(AddValue1)
                            ReturnValue.Add(AddValue2)
                        End If
                    Next
                    Return ReturnValue

                End Get
            End Property
#End Region
#Region "取得站台操作狀況 函式:GetOperationPCRunningStateForLineName"
            ''' <summary>
            ''' 取得站台操作狀況
            ''' </summary>
            ''' <param name="LineName"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Shared Function GetOperationPCRunningStateForLineName(ByVal LineName As OperationLineNameEnum) As OperationPCRunningState
                Dim Qry As String = "Select * from OperationPCRunningState Where RunningPCIP='" & OperationLineIP(LineName) & "'"
                Dim SearchResult As List(Of OperationPCRunningState) = OperationPCRunningState.CDBSelect(Of OperationPCRunningState)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, Qry)
                If SearchResult.Count > 0 Then
                    Return SearchResult(0)
                End If
                Return Nothing
            End Function
#End Region
#Region "產線名稱列舉 列舉:OperationLineNameEnum"
            ''' <summary>
            ''' 產線名稱列舉
            ''' </summary>
            ''' <remarks></remarks>
            Public Enum OperationLineNameEnum
                CPL1 = 1
                CPL2 = 2
                APL1 = 3
                APL2 = 4
                ZML1 = 5
                ZML2 = 6
                ZML3 = 7
                BAL = 8
                GPL1 = 9
                GPL2 = 10
                SPL = 11
                SBL = 12
                TLL = 13
            End Enum
#End Region
#Region "產線名稱IP 屬性:OperationLineIP"
            ''' <summary>
            ''' 產線名稱IP
            ''' </summary>
            ''' <param name="LineName"></param>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Shared ReadOnly Property OperationLineIP(ByVal LineName As OperationLineNameEnum) As String
                Get
                    Select Case LineName
                        Case OperationLineNameEnum.CPL1
                            Return "10.12.10.10"
                        Case OperationLineNameEnum.CPL2
                            Return "10.12.18.10"
                        Case OperationLineNameEnum.APL1
                            Return "10.12.7.10"
                        Case OperationLineNameEnum.APL2
                            Return "10.12.2.10"
                        Case OperationLineNameEnum.BAL
                            Return "10.12.21.3"
                        Case OperationLineNameEnum.ZML1
                            Return "10.12.14.10"
                        Case OperationLineNameEnum.ZML2
                            Return "10.12.15.10"
                        Case OperationLineNameEnum.ZML3
                            Return "10.12.17.10"
                        Case OperationLineNameEnum.GPL1
                            Return "10.12.13.19"
                        Case OperationLineNameEnum.GPL2
                            Return "10.12.12.10"
                        Case OperationLineNameEnum.SPL
                            Return "10.12.6.10"
                        Case OperationLineNameEnum.TLL
                            Return "10.12.5.10"
                        Case OperationLineNameEnum.SBL
                            Return "10.12.20.10"
                        Case Else
                            Return ""
                    End Select
                End Get
            End Property
#End Region



            Public Overrides Function CDBSave() As Integer
                Dim SetSaveTime As DateTime = Now
                Dim SaveLastChangeTimeObject = StationDataLastChangeTime.SetNewLastSaveTime(Me.RunningPCIP, StationDataLastChangeTime.StationDataLastChangeTimeType.OperationPCRunningStateSaveTime)
                If Not IsNothing(SaveLastChangeTimeObject) Then
                    SetSaveTime = SaveLastChangeTimeObject.LastSaveTime
                Else
                    Try
                        SetSaveTime = DeviceInformation.GetSQLServerTime(SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m) ' SQLQueryAdapter.WebServiceSQLQueryAdapter.GetServerTime
                    Catch ex As Exception
                        Try
                            SetSaveTime = SQLQueryAdapter.WebServiceSQLQueryAdapter.GetServerTime
                        Catch ex1 As Exception
                            SetSaveTime = Now
                        End Try
                    End Try
                End If
                Me.LastSaveTime = SetSaveTime

                Return MyBase.CDBSave()
            End Function

	End Class
	End Namespace
End Namespace