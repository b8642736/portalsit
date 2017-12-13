Namespace SQLServer
    Namespace PPS100LB
        ''' <summary>
        ''' 鋼捲移動狀態
        ''' </summary>
        ''' <remarks></remarks>
        Public Class CoilMoveState
            Inherits ClassDBSQLServer

            Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
            End Sub

            Sub New(ByVal SetCoilFullNumber As String, ByVal SetUseStationName As String, ByVal SetNextRunStationName As String, ByVal SetDescript As String, ByVal SetPPSSHAPFFlowAdapter As PPSSHAPFFlowAdapter)
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")

                With Me
                    .SQLServerTime = CompanyORMDB.DeviceInformation.GetSQLServerTime(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m)
                    .RunStationPCIP = PPSSHAPFFlowAdapter.CurrentOperationPCRunningState.RunningPCIP.Trim
                    .RunCoilFullNumber = SetCoilFullNumber
                    .RunStationName = SetUseStationName
                    .AS400Time = CompanyORMDB.DeviceInformation.GetAS400ServerTime
                    .NextRunStationName = SetNextRunStationName
                    .Descript = SetDescript
                    .DeductPlanProductionDisplayCount = 0
                    Dim AS400Time As DateTime = CompanyORMDB.DeviceInformation.GetAS400ServerTime
                    Dim AboutPPSBLAPF As CompanyORMDB.PPS100LB.PPSBLAPF = SetPPSSHAPFFlowAdapter.CoilFullNumberForLastPPSSHAPF.AboutPPSBLAPF
                    Dim AboutOperationPCRunningStateDetail As CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningStateDetail = CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningStateDetail.FindOperationPCRunningStateDetail(.RunStationPCIP, .RunCoilFullNumber)
                    If Not IsNothing(AS400Time) AndAlso Not IsNothing(AboutPPSBLAPF) AndAlso Not IsNothing(AboutOperationPCRunningStateDetail) Then
                        'Dim AboutPlanProductionDisplay As PlanProductionDisplay = PlanProductionDisplay.FindMatchSpecPlanProductionDisplay(SetUseStationName.Substring(0, 3), CoilMoveState.ConvertBlackWidthToOrderWidth(AboutPPSBLAPF.BLA04), AboutPPSBLAPF.BLA02, AboutPPSBLAPF.BLA18, AboutPPSBLAPF.BLA03, AboutOperationPCRunningStateDetail.Set_PlanProductionDisplay_CIW06Value)
                        Dim AboutPlanProductionDisplay As PlanProductionDisplay = PlanProductionDisplay.FindMatchSpecPlanProductionDisplay(SetUseStationName.Substring(0, 3), AboutPPSBLAPF.BLA04, AboutPPSBLAPF.BLA02, AboutPPSBLAPF.BLA18, AboutPPSBLAPF.BLA03, AboutOperationPCRunningStateDetail.Set_PlanProductionDisplay_CIW06Value)
                        If Not IsNothing(AboutPlanProductionDisplay) Then
                            .AddDeleteKey_CIW0A = AboutPlanProductionDisplay.CIW0A
                            .AddDeleteKey_CIW00 = Val(Format(AS400Time, "yyyyMMdd")) - 19110000
                            .AddDeleteKey_CIW01 = Val(Format(AS400Time, "HHmmss"))
                            .AddDeleteKey_CIW02 = AboutPlanProductionDisplay.CIW02
                            .AddDeleteKey_CIW03 = AboutPlanProductionDisplay.CIW03
                            .AddDeleteKey_CIW04 = AboutPlanProductionDisplay.CIW04
                            .AddDeleteKey_CIW05 = AboutPlanProductionDisplay.CIW05
                            .AddDeleteKey_CIW06 = AboutPlanProductionDisplay.CIW06
                            .AddDeleteKey_CIW15 = AboutPlanProductionDisplay.CIW15
                        End If
                    End If
                End With

            End Sub

#Region "SQLServerTime 屬性:SQLServerTime"
            Private _SQLServerTime As System.DateTime
            ''' <summary>
            ''' WebServerTime
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property SQLServerTime() As System.DateTime
                Get
                    Return _SQLServerTime
                End Get
                Set(ByVal value As System.DateTime)
                    _SQLServerTime = value
                End Set
            End Property
#End Region
#Region "RunStationPCIP 屬性:RunStationPCIP"
            Private _RunStationPCIP As System.String
            ''' <summary>
            ''' RunStationPCIP
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property RunStationPCIP() As System.String
                Get
                    Return _RunStationPCIP
                End Get
                Set(ByVal value As System.String)
                    _RunStationPCIP = value
                End Set
            End Property
#End Region
#Region "RunCoilFullNumber 屬性:RunCoilFullNumber"
            Private _RunCoilFullNumber As System.String
            ''' <summary>
            ''' RunCoilFullNumber
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property RunCoilFullNumber() As System.String
                Get
                    Return _RunCoilFullNumber
                End Get
                Set(ByVal value As System.String)
                    _RunCoilFullNumber = value
                End Set
            End Property
#End Region
#Region "RunStationName 屬性:RunStationName"
            Private _RunStationName As System.String
            ''' <summary>
            ''' RunStationName
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property RunStationName() As System.String
                Get
                    Return _RunStationName
                End Get
                Set(ByVal value As System.String)
                    _RunStationName = value
                End Set
            End Property
#End Region
#Region "AS400Time 屬性:AS400Time"
            Private _AS400Time As System.DateTime
            ''' <summary>
            ''' AS400Time
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property AS400Time() As System.DateTime
                Get
                    Return _AS400Time
                End Get
                Set(ByVal value As System.DateTime)
                    _AS400Time = value
                End Set
            End Property
#End Region
#Region "NextRunStationName 屬性:NextRunStationName"
            Private _NextRunStationName As System.String
            ''' <summary>
            ''' NextRunStationName
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property NextRunStationName() As System.String
                Get
                    Return _NextRunStationName
                End Get
                Set(ByVal value As System.String)
                    _NextRunStationName = value
                End Set
            End Property
#End Region
#Region "Descript 屬性:Descript"
            Private _Descript As String
            ''' <summary>
            ''' 說明
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Descript() As String
                Get
                    Return _Descript
                End Get
                Set(ByVal value As String)
                    _Descript = value
                End Set
            End Property

#End Region
#Region "增加或刪除派工數量參考Key值 AddDeleteKey_CIW0A"
            Private _AddDeleteKey_CIW0A As String
            Public Property AddDeleteKey_CIW0A() As String
                Get
                    Return _AddDeleteKey_CIW0A
                End Get
                Set(ByVal value As String)
                    _AddDeleteKey_CIW0A = value
                End Set
            End Property
#End Region
#Region "增加或刪除派工數量參考Key值 AddDeleteKey_CIW00"
            Private _AddDeleteKey_CIW00 As Integer
            Public Property AddDeleteKey_CIW00() As Integer
                Get
                    Return _AddDeleteKey_CIW00
                End Get
                Set(ByVal value As Integer)
                    _AddDeleteKey_CIW00 = value
                End Set
            End Property

#End Region
#Region "增加或刪除派工數量參考Key值 AddDeleteKey_CIW01"
            Private _AddDeleteKey_CIW01 As Integer
            Public Property AddDeleteKey_CIW01() As Integer
                Get
                    Return _AddDeleteKey_CIW01
                End Get
                Set(ByVal value As Integer)
                    _AddDeleteKey_CIW01 = value
                End Set
            End Property
#End Region
#Region "增加或刪除派工數量參考Key值 AddDeleteKey_CIW02"
            Private _AddDeleteKey_CIW02 As Integer
            Public Property AddDeleteKey_CIW02() As Integer
                Get
                    Return _AddDeleteKey_CIW02
                End Get
                Set(ByVal value As Integer)
                    _AddDeleteKey_CIW02 = value
                End Set
            End Property

#End Region
#Region "增加或刪除派工數量參考Key值 AddDeleteKey_CIW03"
            Private _AddDeleteKey_CIW03 As String
            Public Property AddDeleteKey_CIW03() As String
                Get
                    Return _AddDeleteKey_CIW03
                End Get
                Set(ByVal value As String)
                    _AddDeleteKey_CIW03 = value
                End Set
            End Property
#End Region
#Region "增加或刪除派工數量參考Key值 AddDeleteKey_CIW04"
            Private _AddDeleteKey_CIW04 As String
            Public Property AddDeleteKey_CIW04() As String
                Get
                    Return _AddDeleteKey_CIW04
                End Get
                Set(ByVal value As String)
                    _AddDeleteKey_CIW04 = value
                End Set
            End Property
#End Region
#Region "增加或刪除派工數量參考Key值 AddDeleteKey_CIW05"
            Private _AddDeleteKey_CIW05 As String
            Public Property AddDeleteKey_CIW05() As String
                Get
                    Return _AddDeleteKey_CIW05
                End Get
                Set(ByVal value As String)
                    _AddDeleteKey_CIW05 = value
                End Set
            End Property

#End Region
#Region "增加或刪除派工數量參考Key值 AddDeleteKey_CIW06"
            Private _AddDeleteKey_CIW06 As Integer
            ''' <summary>
            ''' 增加或刪除參考Key值
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property AddDeleteKey_CIW06() As Integer
                Get
                    Return _AddDeleteKey_CIW06
                End Get
                Set(ByVal value As Integer)
                    _AddDeleteKey_CIW06 = value
                End Set
            End Property

#End Region
#Region "增加或刪除派工數量參考Key值 AddDeleteKey_CIW15"
            Private _AddDeleteKey_CIW15 As Integer
            Public Property AddDeleteKey_CIW15() As Integer
                Get
                    Return _AddDeleteKey_CIW15
                End Get
                Set(ByVal value As Integer)
                    _AddDeleteKey_CIW15 = value
                End Set
            End Property

#End Region
#Region "扣除生技派工(PlanProductionDisplay)數量 屬性:DeductPlanProductionDisplayCount"
            Private _DeductPlanProductionDisplayCount As Integer
            ''' <summary>
            ''' 扣除生技派工(PlanProductionDisplay)數量
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property DeductPlanProductionDisplayCount() As Integer
                Get
                    Return _DeductPlanProductionDisplayCount
                End Get
                Set(ByVal value As Integer)
                    _DeductPlanProductionDisplayCount = value
                End Set
            End Property

#End Region


#Region "轉換訂單寬度至黑皮寬度 方法:ConvertOrderWidthToBlackWidth"
            ''' <summary>
            ''' 轉換訂單寬度至黑皮寬度
            ''' </summary>
            ''' <param name="BlackWidth"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Shared Function ConvertBlackWidthToOrderWidth(ByVal BlackWidth As Integer) As Integer
                Select Case True
                    Case BlackWidth >= 945 And BlackWidth <= 960
                        Return 914
                    Case BlackWidth >= 1025 And BlackWidth <= 1040
                        Return 1000
                    Case BlackWidth >= 1240 And BlackWidth <= 1265
                        Return 1219
                    Case BlackWidth >= 1266 And BlackWidth <= 1284
                        Return 1250
                    Case BlackWidth >= 1285 And BlackWidth <= 1295
                        Return 1260
                End Select
                Return BlackWidth
            End Function
#End Region

            '#Region "是否正在第一次準備生產階段 屬性:IsNowReadyProductionStatus"
            '            Private _IsNowReadyFirstProductionStatus As Nullable(Of Boolean) = Nothing
            '            ''' <summary>
            '            ''' 是否正在第一次準備生產階段
            '            ''' </summary>
            '            ''' <value></value>
            '            ''' <returns></returns>
            '            ''' <remarks></remarks>
            '            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            '            ReadOnly Property IsNowReadyFirstProductionStatus As Boolean
            '                Get
            '                    If Not IsNothing(_IsNowReadyFirstProductionStatus) Then
            '                        Return _IsNowReadyFirstProductionStatus
            '                    End If
            '                    Dim AboutPPSSHAPFs As List(Of CompanyORMDB.PPS100LB.PPSSHAPF) = AboutAS400PPSSHAPFs
            '                    If AboutPPSSHAPFs.Count = 0 OrElse AboutPPSSHAPFs.Count > 2 Then
            '                        _IsNowReadyFirstProductionStatus = False
            '                        Return _IsNowReadyFirstProductionStatus
            '                    End If
            '                    Dim SQLAdapter = Me.CDBCurrentUseSQLQueryAdapter
            '                    Dim QryString As String = "Select COUNT(*) from CoilMoveState Where SQLServerTime >= '" & Format(Now.AddYears(-2), "yyyy/MM/dd HH:mm:ss") & "' and SQLServerTime <= '" & Format(Now.AddYears(2), "yyyy/MM/dd HH:mm:ss") & "' "
            '                    QryString &= " and RunStationPCIP='" & Me.RunStationPCIP & "' "
            '                    QryString &= " and RunCoilFullNumber='" & Me.RunCoilFullNumber & "' "
            '                    If CType(Me.CDBCurrentUseSQLQueryAdapter.SelectQuery(QryString).Rows(0).Item(0), Integer) > 0 Then
            '                        _IsNowReadyFirstProductionStatus = False
            '                        Return _IsNowReadyFirstProductionStatus
            '                    End If
            '                    _IsNowReadyFirstProductionStatus = True
            '                    Return _IsNowReadyFirstProductionStatus
            '                End Get
            '            End Property
            '#End Region

#Region "相關AS400排程資料 屬性:AboutAS400PPSSHAPFs"
            ''' <summary>
            ''' 相關AS400排程資料
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property AboutAS400PPSSHAPFs As List(Of CompanyORMDB.PPS100LB.PPSSHAPF)
                Get
                    Dim QryString As String = "SELECT * FROM @#PPS100LB.PPSSHAPF WHERE SHA01='" & Me.RunCoilFullNumber.Substring(0, 5) & "' order by sha04"
                    Dim Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QryString)
                    Return CompanyORMDB.PPS100LB.PPSSHAPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSSHAPF)(QryString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                End Get
            End Property
#End Region

#Region "重新取得伺服器時間 函式:RefreshWebServerAndAS400Time"
            ''' <summary>
            ''' 重新取得伺服器時間
            ''' </summary>
            ''' <remarks></remarks>
            Public Sub RefreshWebServerAndAS400Time()
                Dim AS400Time As Nullable(Of DateTime) = DeviceInformation.GetAS400ServerTime
                Dim SQLServerTime As DateTime = DeviceInformation.GetSQLServerTime(SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m)
                If Not IsNothing(AS400Time) Then
                    Me.AS400Time = AS400Time
                End If
                If Not IsNothing(SQLServerTime) Then
                    Me.SQLServerTime = SQLServerTime
                End If
            End Sub
#End Region

#Region "找尋CoilMoveState 方法:FindCoilMoveState"
            ''' <summary>
            ''' 找尋CoilMoveState
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Shared Function FindCoilMoveState(ByVal ClientIP As String, ByVal CoilFullNumber As String) As CoilMoveState
                Dim QryString As String = "Select * from CoilMoveState Where RunStationPCIP='" & ClientIP.Trim & "' and RunCoilFullNumber='" & CoilFullNumber & "' Order by SQLServerTime Desc"
                Dim SearchResult As List(Of CoilMoveState) = CoilMoveState.CDBSelect(Of CoilMoveState)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
                If SearchResult.Count = 0 Then
                    Return Nothing
                End If
                Return SearchResult(0)
            End Function
#End Region

            Public Overrides Function CDBDelete() As Integer
                Dim QryString As String = "SELECT * FROM PlanProductionDisplay Where "
                QryString &= " CIW0A='" & Me.AddDeleteKey_CIW0A & "'"
                QryString &= " AND CIW02=" & Me.AddDeleteKey_CIW02
                QryString &= " AND CIW03='" & Me.AddDeleteKey_CIW03 & "' "
                QryString &= " AND CIW04='" & Me.AddDeleteKey_CIW04 & "' "
                QryString &= " AND CIW05='" & Me.AddDeleteKey_CIW05 & "' "
                QryString &= " AND CIW06=" & Me.AddDeleteKey_CIW06
                QryString &= " AND CIW15=" & Me.AddDeleteKey_CIW15
                Dim SearchResult As List(Of PPS100LB.PlanProductionDisplay) = PPS100LB.PlanProductionDisplay.CDBSelect(Of PPS100LB.PlanProductionDisplay)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
                If SearchResult.Count > 0 Then
                    SearchResult(0).CIW12 += Me.DeductPlanProductionDisplayCount
                    SearchResult(0).CDBSave()
                End If
                Return MyBase.CDBDelete()
            End Function


            Public Overrides Function CDBInsert() As Integer
                Dim QryString As String = "SELECT * FROM PlanProductionDisplay Where "
                QryString &= " CIW0A='" & Me.AddDeleteKey_CIW0A & "'"
                QryString &= " AND CIW02=" & Me.AddDeleteKey_CIW02
                QryString &= " AND CIW03='" & Me.AddDeleteKey_CIW03 & "' "
                QryString &= " AND CIW04='" & Me.AddDeleteKey_CIW04 & "' "
                QryString &= " AND CIW05='" & Me.AddDeleteKey_CIW05 & "' "
                QryString &= " AND CIW06=" & Me.AddDeleteKey_CIW06
                QryString &= " AND CIW15=" & Me.AddDeleteKey_CIW15
                Dim SearchResult As List(Of PPS100LB.PlanProductionDisplay) = PPS100LB.PlanProductionDisplay.CDBSelect(Of PPS100LB.PlanProductionDisplay)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
                Dim IsCIW12Counted As Boolean = False
                If SearchResult.Count > 0 AndAlso SearchResult(0).CIW12 > 0 Then
                    '只限CPL/APL/ZML 在第一站做 CoilStart 時才扣除生計派工數量
                    Dim RunStation As String = Me.RunStationName.PadRight(3).Substring(0, 3).ToUpper
                    If (RunStation = "CPL" OrElse RunStation = "APL" OrElse RunStation = "ZML") Then
                        'IsNowReadyFirstProductionStatus Then   '94/5/6 刪除不再使用
                        Me.DeductPlanProductionDisplayCount += 1
                        SearchResult(0).CIW12 -= 1
                    End If
                    If SearchResult(0).CDBSave > 0 Then
                        IsCIW12Counted = (Me.DeductPlanProductionDisplayCount > 0)
                        Me.AddDeleteKey_CIW0A = SearchResult(0).CIW0A
                        Me.AddDeleteKey_CIW00 = SearchResult(0).CIW00
                        Me.AddDeleteKey_CIW01 = SearchResult(0).CIW01
                        Me.AddDeleteKey_CIW02 = SearchResult(0).CIW02
                        Me.AddDeleteKey_CIW03 = SearchResult(0).CIW03
                        Me.AddDeleteKey_CIW05 = SearchResult(0).CIW05
                        Me.AddDeleteKey_CIW06 = SearchResult(0).CIW06
                        Me.AddDeleteKey_CIW15 = SearchResult(0).CIW15
                    End If
                End If

                Dim ReturnValue As Integer = 0
                Try
                    ReturnValue = MyBase.CDBInsert()
                    Return ReturnValue
                Catch ex As Exception
                    ReturnValue = 0
                Finally
                    If ReturnValue = 0 AndAlso IsCIW12Counted Then
                        SearchResult(0).CIW12 += 1
                        SearchResult(0).CDBSave()
                    End If
                End Try

            End Function


        End Class
    End Namespace
End Namespace