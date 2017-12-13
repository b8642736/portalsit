Public Class CoilMoveStationEdit

#Region "相關CoilScanAndMachineProcess 屬性:AboutCoilScanAndMachineProcess"

    Private _AboutCoilScanAndMachineProcess As CoilScanAndMachineProcess
    ''' <summary>
    ''' 相關CoilScanAndMachineProcess
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AboutCoilScanAndMachineProcess() As CoilScanAndMachineProcess
        Get
            Return _AboutCoilScanAndMachineProcess
        End Get
        Private Set(ByVal value As CoilScanAndMachineProcess)
            _AboutCoilScanAndMachineProcess = value
        End Set
    End Property

#End Region

#Region "重整生計派工資訊 函式:RefreshPMDisplayInformation"
    ''' <summary>
    ''' 重整生計派工資訊
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RefreshPMDisplayInformation()
        If Not Me.TabControl1.SelectedTab Is tpPMNewsMode Then
            Exit Sub
        End If

        Dim RunStationName As String = Nothing

        If Not IsNothing(AboutCoilScanAndMachineProcess.CurrentUseingStationRadioButton) Then
            RunStationName = AboutCoilScanAndMachineProcess.CurrentUseingStationRadioButton.Text.Trim
        End If

        Me.bsPlanProductionDisplay.Clear()
        If String.IsNullOrEmpty(RunStationName) OrElse Not (RunStationName.Substring(0, 2) = "CP" OrElse RunStationName.Substring(0, 2) = "AP" OrElse RunStationName.Substring(0, 2) = "ZM") Then
            Exit Sub
        End If

        Dim QryString As String = "Select * from PlanProductionDisplay WHERE CIW12>0 AND LEFT(CIW0A,2)='" & RunStationName.Substring(0, 2) & "' ORDER BY CIW15"
        Dim SetDatas1 As List(Of CompanyORMDB.SQLServer.PPS100LB.PlanProductionDisplay) = CompanyORMDB.SQLServer.PPS100LB.PlanProductionDisplay.CDBSelect(Of CompanyORMDB.SQLServer.PPS100LB.PlanProductionDisplay)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
        Me.bsPlanProductionDisplay.DataSource = SetDatas1

    End Sub
#End Region
#Region "監看模式 屬性:MoniterMode"
    ''' <summary>
    ''' 監看模式
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MoniterMode() As Boolean
        Get
            Return Timer1.Enabled
        End Get
        Set(ByVal value As Boolean)
            Timer1.Enabled = value
        End Set
    End Property

#End Region


    Public Sub New(ByVal SetCoilScanAndMachineProcess As CoilScanAndMachineProcess)
        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        Me.AboutCoilScanAndMachineProcess = SetCoilScanAndMachineProcess
    End Sub

    Private Sub btnRun_Click(sender As System.Object, e As System.EventArgs) Handles btnRun.Click
        bsCoilMoveState.Clear()
        Dim QryString As String = "Select * from CoilMoveState Where RunStationPCIP='" & PPSSHAPFFlowAdapter.CurrentOperationPCRunningState.RunningPCIP.Trim & "' "
        If Not String.IsNullOrEmpty(tbFilterCoilNumbers.Text) Then
            If tbFilterCoilNumbers.Text.Contains("~") Then
                QryString &= " and RunCoilFullNumber >= '" & tbFilterCoilNumbers.Text.Split("~")(0) & "' and RunCoilFullNumber <= '" & tbFilterCoilNumbers.Text.Split("~")(1) & "'"
            Else
                QryString &= " and RunCoilFullNumber in ('" & tbFilterCoilNumbers.Text.Replace(",", "','") & "') "
            End If
        End If
        If cbIsDateFilter.Checked Then
            QryString &= " and AS400Time >= '" & DateTimePicker1.Value.Date & "' and AS400Time < '" & DateTimePicker2.Value.AddDays(1).Date & "'"
        End If
        Me.bsCoilMoveState.DataSource = CompanyORMDB.ORMBaseClass.ClassDBSQLServer.CDBSelect(Of CompanyORMDB.SQLServer.PPS100LB.CoilMoveState)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
    End Sub

    Private Sub CoilMoveStationEdit_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        DateTimePicker1.Text = New Date(Now.Year, Now.Month, 1)
    End Sub

    Private Sub tbDelete_Click(sender As System.Object, e As System.EventArgs) Handles tbDelete.Click
        If MsgBox("是否確定刪除,刪除後將會扣除執行派工數量?", MsgBoxStyle.YesNo, "注意!") = DialogResult.No Then
            Exit Sub
        End If
        Dim CurrentUseStationName As String = ""
        If Not IsNothing(AboutCoilScanAndMachineProcess.CurrentUseingStationRadioButton) Then
            CurrentUseStationName = AboutCoilScanAndMachineProcess.CurrentUseingStationRadioButton.Text.Trim
        End If
        DataGridView1.EndEdit()
        Dim RemoveItems As New List(Of DataGridViewRow)
        For Each EachItem As DataGridViewRow In DataGridView1.Rows
            If CType(EachItem.Cells("DataSelect").Value, Boolean) = True Then
                Dim DeleteObject As CompanyORMDB.SQLServer.PPS100LB.CoilMoveState = EachItem.DataBoundItem
                If DeleteObject.CDBDelete() > 0 Then
                    RemoveItems.Add(EachItem)
                End If
            End If
        Next
        For Each RemoveItem In RemoveItems
            DataGridView1.Rows.Remove(RemoveItem)
        Next
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        RefreshPMDisplayInformation()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
