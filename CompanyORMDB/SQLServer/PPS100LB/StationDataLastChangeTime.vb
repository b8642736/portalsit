Namespace SQLServer
	Namespace PPS100LB
	Public Class StationDataLastChangeTime
	Inherits ClassDBSQLServer

            Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
                Me.LastSaveTime = Now.AddMinutes(-10)
                Me.OperationPCRunningStateSaveTime = Me.LastSaveTime
                Me.OperationPCRunningStateDetailSaveTime = Me.LastSaveTime
            End Sub
            Sub New(ByVal SetRunningPCIP As String)
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
                Me.RunningPCIP = SetRunningPCIP.Trim
                Me.LastSaveTime = Now.AddMinutes(-10)
                Me.OperationPCRunningStateSaveTime = Me.LastSaveTime
                Me.OperationPCRunningStateDetailSaveTime = Me.LastSaveTime
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
#Region "OperationPCRunningStateSaveTime 屬性:OperationPCRunningStateSaveTime"
	Private _OperationPCRunningStateSaveTime As System.DateTime
	''' <summary>
	''' OperationPCRunningStateSaveTime
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property OperationPCRunningStateSaveTime () As System.DateTime
		Get
			Return _OperationPCRunningStateSaveTime
		End Get
		Set(Byval value as System.DateTime)
			_OperationPCRunningStateSaveTime = value
		End Set
	End Property
#End Region
#Region "OperationPCRunningStateDetailSaveTime 屬性:OperationPCRunningStateDetailSaveTime"
	Private _OperationPCRunningStateDetailSaveTime As System.DateTime
	''' <summary>
	''' OperationPCRunningStateDetailSaveTime
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property OperationPCRunningStateDetailSaveTime () As System.DateTime
		Get
			Return _OperationPCRunningStateDetailSaveTime
		End Get
		Set(Byval value as System.DateTime)
			_OperationPCRunningStateDetailSaveTime = value
		End Set
	End Property
#End Region
#Region "LastSaveTime 屬性:LastSaveTime"
	Private _LastSaveTime As System.DateTime
	''' <summary>
	''' LastSaveTime
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property LastSaveTime () As System.DateTime
		Get
			Return _LastSaveTime
		End Get
		Set(Byval value as System.DateTime)
			_LastSaveTime = value
		End Set
	End Property
#End Region


#Region "設定最新最後儲存時間 方法:SetNewLastSaveTime"
            ''' <summary>
            ''' 設定最新最後儲存時間
            ''' </summary>
            ''' <param name="SetPCIP"></param>
            ''' <param name="SetType"></param>
            ''' <returns>回傳成功存儲存之StationDataLastChangeTime,失敗則回傳Notrhing</returns>
            ''' <remarks></remarks>
            Public Shared Function SetNewLastSaveTime(ByVal SetPCIP As String, ByVal SetType As StationDataLastChangeTimeType) As StationDataLastChangeTime
                Dim FindStationDataLastChangeTime As StationDataLastChangeTime = FindStationDataLastChangeTimeForIP(SetPCIP)
                If IsNothing(FindStationDataLastChangeTime) Then
                    FindStationDataLastChangeTime = New StationDataLastChangeTime(SetPCIP)
                End If

                Dim SetSaveTime As DateTime = Now
                Try
                    SetSaveTime = DeviceInformation.GetSQLServerTime(SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m) ' SQLQueryAdapter.WebServiceSQLQueryAdapter.GetServerTime
                Catch ex As Exception
                    Try
                        SetSaveTime = SQLQueryAdapter.WebServiceSQLQueryAdapter.GetServerTime
                    Catch ex1 As Exception
                        SetSaveTime = Now
                    End Try
                End Try
                FindStationDataLastChangeTime.LastSaveTime = SetSaveTime

                Select Case True
                    Case SetType = StationDataLastChangeTimeType.OperationPCRunningStateSaveTime
                        FindStationDataLastChangeTime.OperationPCRunningStateSaveTime = FindStationDataLastChangeTime.LastSaveTime
                    Case SetType = StationDataLastChangeTimeType.OperationPCRunningStateDetailSaveTime
                        FindStationDataLastChangeTime.OperationPCRunningStateDetailSaveTime = FindStationDataLastChangeTime.LastSaveTime
                    Case Else
                End Select
                If FindStationDataLastChangeTime.CDBSave > 0 Then
                    Return FindStationDataLastChangeTime
                End If
                Return Nothing
            End Function

            Public Enum StationDataLastChangeTimeType
                OperationPCRunningStateSaveTime = 1
                OperationPCRunningStateDetailSaveTime = 2
            End Enum
#End Region
#Region "尋找IP相關之StationDataLastChangeTime 方法:FindStationDataLastChangeTimeForIP"
            ''' <summary>
            ''' 尋找IP相關之StationDataLastChangeTime
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Shared Function FindStationDataLastChangeTimeForIP(ByVal FindPCIP As String) As StationDataLastChangeTime
                Dim QryString As String = "Select * from StationDataLastChangeTime Where RunningPCIP='" & FindPCIP.Trim & "'"
                Dim SearchResult = StationDataLastChangeTime.CDBSelect(Of StationDataLastChangeTime)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
                If SearchResult.Count = 0 Then
                    Return Nothing
                End If
                Return SearchResult(0)
            End Function
#End Region


            Public Overrides Function CDBSave() As Integer
                Dim SetSaveTime As DateTime = Now
                Try
                    SetSaveTime = DeviceInformation.GetSQLServerTime(SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m) ' SQLQueryAdapter.WebServiceSQLQueryAdapter.GetServerTime
                Catch ex As Exception
                    Try
                        SetSaveTime = SQLQueryAdapter.WebServiceSQLQueryAdapter.GetServerTime
                    Catch ex1 As Exception
                        SetSaveTime = Now
                    End Try
                End Try
                Me.LastSaveTime = SetSaveTime
                Return MyBase.CDBSave()
            End Function
	End Class
	End Namespace
End Namespace