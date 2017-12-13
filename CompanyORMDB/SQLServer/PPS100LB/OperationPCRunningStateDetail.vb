Namespace SQLServer
	Namespace PPS100LB
	Public Class OperationPCRunningStateDetail
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"PPS100LB")
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
#Region "RunningProcessCoilNumber 屬性:RunningProcessCoilNumber"
	Private _RunningProcessCoilNumber As System.String
	''' <summary>
	''' RunningProcessCoilNumber
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property RunningProcessCoilNumber() As System.String
                Get
                    Return _RunningProcessCoilNumber
                End Get
                Set(ByVal value As System.String)
                    _RunningProcessCoilNumber = value
                End Set
            End Property
#End Region
#Region "Set_PlanProductionDisplay_CIW06Value 屬性:Set_PlanProductionDisplay_CIW06Value"
            Private _Set_PlanProductionDisplay_CIW06Value As Integer
            ''' <summary>
            ''' Set_PlanProductionDisplay_CIW06Value
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Set_PlanProductionDisplay_CIW06Value() As Integer
                Get
                    Return _Set_PlanProductionDisplay_CIW06Value
                End Get
                Set(ByVal value As Integer)
                    _Set_PlanProductionDisplay_CIW06Value = value
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
            Public Property RunPCName() As System.String
                Get
                    Return _RunPCName
                End Get
                Set(ByVal value As System.String)
                    _RunPCName = value
                End Set
            End Property
#End Region

#Region "尋找OperationPCRunningStateDetail 方法:FindOperationPCRunningStateDetail"
            ''' <summary>
            ''' OperationPCRunningStateDetail
            ''' </summary>
            ''' <param name="ClientIP"></param>
            ''' <param name="CoilNumber"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Shared Function FindOperationPCRunningStateDetail(ByVal ClientIP As String, ByVal CoilNumber As String) As OperationPCRunningStateDetail
                Dim QryString As String = "SELECT * From OperationPCRunningStateDetail Where RunningPCIP='" & ClientIP.Trim & "' and RunningProcessCoilNumber='" & CoilNumber.Trim & "'"
                Dim SearchResult As List(Of OperationPCRunningStateDetail) = OperationPCRunningStateDetail.CDBSelect(Of OperationPCRunningStateDetail)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
                If SearchResult.Count = 0 Then
                    Return Nothing
                End If
                Return SearchResult(0)
            End Function
#End Region

#Region "新增或更新OperationPCRunningStateDetail至資料庫 函式:AddOrUpdateOperationPCRunningStateDetailToDB"
            ''' <summary>
            ''' 新增或更新OperationPCRunningStateDetail至資料庫
            ''' </summary>
            ''' <param name="SourceOperationPCRunningState"></param>
            ''' <remarks></remarks>
            Public Shared Function AddOrUpdateOperationPCRunningStateDetailToDB(ByVal SourceOperationPCRunningState As OperationPCRunningState, ByVal SetRunningProcessCoilNumber As String, ByVal SetCIW06Value As Integer, Optional SetServerIP As String = Nothing) As Integer
                '限制只有APL或CPL才能執行
                If String.IsNullOrEmpty(SourceOperationPCRunningState.DefaultUseStationName) OrElse _
                    SourceOperationPCRunningState.DefaultUseStationName.Length < 2 OrElse _
                    Not (SourceOperationPCRunningState.DefaultUseStationName.Substring(0, 2) = "CP" OrElse _
                         SourceOperationPCRunningState.DefaultUseStationName.Substring(0, 2) = "AP" OrElse _
                         SourceOperationPCRunningState.DefaultUseStationName.Substring(0, 2) = "ZM") Then
                    Return 0
                End If
                Dim InsertObject As New OperationPCRunningStateDetail
                With InsertObject
                    If Not IsNothing(SetServerIP) Then
                        .RunningPCIP = SetServerIP
                    Else
                        .RunningPCIP = SourceOperationPCRunningState.RunningPCIP
                    End If
                    .RunPCName = SourceOperationPCRunningState.RunPCName
                    .RunningProcessCoilNumber = SetRunningProcessCoilNumber
                    .Set_PlanProductionDisplay_CIW06Value = SetCIW06Value
                End With
                Return InsertObject.CDBSave
            End Function
#End Region
#Region "由資料庫刪除OperationPCRunningStateDetail 函式:DeleteOperationPCRunningStateDetailFromDB"
            ''' <summary>
            ''' 由資料庫刪除OperationPCRunningStateDetail
            ''' </summary>
            ''' <param name="SourceOperationPCRunningState"></param>
            ''' <param name="SetRunningProcessCoilNumber"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Shared Function DeleteOperationPCRunningStateDetailFromDB(ByVal SourceOperationPCRunningState As OperationPCRunningState, ByVal SetRunningProcessCoilNumber As String, Optional SetServerIP As String = Nothing) As Integer
                '限制只有APL或CPL才能執行
                If String.IsNullOrEmpty(SourceOperationPCRunningState.DefaultUseStationName) OrElse _
                    SourceOperationPCRunningState.DefaultUseStationName.Length < 2 OrElse _
                    Not (SourceOperationPCRunningState.DefaultUseStationName.Substring(0, 2) = "CP" OrElse _
                         SourceOperationPCRunningState.DefaultUseStationName.Substring(0, 2) = "AP") Then
                    Return 0
                End If

                Dim QryString As String = "Delete From OperationPCRunningStateDetail Where RunningPCIP='" & IIf(String.IsNullOrEmpty(SetServerIP), SourceOperationPCRunningState.RunningPCIP, SetServerIP) & "' and RunningProcessCoilNumber='" & SetRunningProcessCoilNumber & "'"
                Dim Adapter As New SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
                Dim ReturnValue As Integer = Adapter.ExecuteNonQuery(QryString)
                If ReturnValue > 0 Then
                    Call StationDataLastChangeTime.SetNewLastSaveTime(SourceOperationPCRunningState.RunningPCIP, StationDataLastChangeTime.StationDataLastChangeTimeType.OperationPCRunningStateDetailSaveTime)
                End If
                Return ReturnValue
            End Function
#End Region

            Public Overrides Function CDBSave() As Integer
                Call StationDataLastChangeTime.SetNewLastSaveTime(Me.RunningPCIP, StationDataLastChangeTime.StationDataLastChangeTimeType.OperationPCRunningStateDetailSaveTime)
                Return MyBase.CDBSave()
            End Function

        End Class
	End Namespace
End Namespace