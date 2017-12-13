Public Class UCScheduleAndState


#Region "產生並顯示爐號資料 函式:CreateAndDisplayStoveData"
    ''' <summary>
    ''' 產生並顯示爐號資料
    ''' </summary>
    ''' <remarks>產生回傳最近3個月未完成之最後爐號資料</remarks>
    Private Sub CreateAndDisplayStoveData(ByVal SetBindingSource As BindingSource, ByVal StartStvoeNumber As String, ByVal CreateCount As Integer)
        Dim NowTime As DateTime = (New CompanyORMDB.WSDBSQLQueryAdapter(True)).GetServerTime
        StartStvoeNumber = StartStvoeNumber.ToUpper
        If Not (StartStvoeNumber.Length = 5 AndAlso (StartStvoeNumber.Substring(0, 1) = "A" OrElse StartStvoeNumber.Substring(0, 1) = "B")) Then
            Exit Sub
        End If
        Dim Pre3MonthDateString As Integer = (CType(Format(NowTime.AddMonths(-3), "yyyy"), Double) - 1911) * 10000 + CType(Format(NowTime.AddMonths(-3), "MMdd"), Double)
        Dim After3MonthDateString As Integer = (CType(Format(NowTime.AddMonths(3), "yyyy"), Double) - 1911) * 10000 + CType(Format(NowTime.AddMonths(3), "MMdd"), Double)
        Dim NextStoveNumber As Integer = CType(StartStvoeNumber.Substring(1, StartStvoeNumber.Length - 1), Integer)
        Dim FindStoveNumbers As String = Nothing
        CompanyORMDB.SQLServer.QCDB01.ProcessSchedule.AboutElemenDatasStoveNumber.Clear()
        For ItemCount As Integer = NextStoveNumber To NextStoveNumber + CreateCount
            FindStoveNumbers &= IIf(IsNothing(FindStoveNumbers), Nothing, "','") & StartStvoeNumber.Substring(0, 1) & Format(IIf(ItemCount > 9999, 1, ItemCount), "0000")
            CompanyORMDB.SQLServer.QCDB01.ProcessSchedule.AboutElemenDatasStoveNumber.Add(StartStvoeNumber.Substring(0, 1) & Format(IIf(ItemCount > 9999, 1, ItemCount), "0000"))
        Next

        Dim SetSoryNumberToZroQry As String = "Update ProcessSchedule Set SortNumber=0 Where StoveNumber Like '" & StartStvoeNumber.Substring(0, 1) & "%' AND  NOT StoveNumber IN ('" & FindStoveNumbers & "')"
        Dim RunAdapter As CompanyORMDB.SQLServerSQLQueryAdapter = (New CompanyORMDB.SQLServer.QCDB01.ProcessSchedule).CDBCurrentUseSQLQueryAdapter
        RunAdapter.ExecuteNonQuery(SetSoryNumberToZroQry)

        Dim QryString As String = "Select * from ProcessSchedule Where StartStateTime>='" & Format(NowTime.AddMonths(-3), "yyyy/MM/dd HH:mm:ss") & "' AND StartStateTime<='" & Format(NowTime.AddMonths(3), "yyyy/MM/dd HH:mm:ss") & "' AND StoveNumber IN ('" & FindStoveNumbers & "')  Order by SortNumber "
        Dim SearchResult As List(Of CompanyORMDB.SQLServer.QCDB01.ProcessSchedule) = CompanyORMDB.SQLServer.QCDB01.ProcessSchedule.CDBSelect(Of CompanyORMDB.SQLServer.QCDB01.ProcessSchedule)(QryString)
        '重新安排排序
        Dim TempDictionData As New Dictionary(Of String, CompanyORMDB.SQLServer.QCDB01.ProcessSchedule)
        For Each EachItem As CompanyORMDB.SQLServer.QCDB01.ProcessSchedule In SearchResult
            If TempDictionData.ContainsKey(EachItem.StoveNumber.Trim) Then
                EachItem.CDBDelete()
            Else
                TempDictionData.Add(EachItem.StoveNumber.Trim, EachItem)
            End If
        Next


        For AddItemCount As Integer = 1 To CreateCount
            NextStoveNumber = IIf(NextStoveNumber > 9999, 1, NextStoveNumber)
            Dim NextABStoveNumberString As String = StartStvoeNumber.Substring(0, 1) & Format(NextStoveNumber, "0000")
            If Not TempDictionData.ContainsKey(NextABStoveNumberString) Then
                Dim AddItem As New CompanyORMDB.SQLServer.QCDB01.ProcessSchedule
                With AddItem
                    .ID = Guid.NewGuid.ToString
                    .StoveNumber = NextABStoveNumberString
                    .SteelKind = "304"
                    .CurrentState = IIf(AddItem.IsInProcessCC, 2, 1)
                    .StartStateTime = NowTime
                    .SortNumber = AddItemCount
                End With
                If AddItem.CDBSave > 0 Then
                    TempDictionData.Add(AddItem.StoveNumber, AddItem)
                End If
            Else
                TempDictionData.Item(NextABStoveNumberString).SortNumber = AddItemCount
                TempDictionData.Item(NextABStoveNumberString).CDBSave()
            End If
            NextStoveNumber += 1
        Next
        SearchResult.Clear()

        'CompanyORMDB.SQLServer.QCDB01.ProcessSchedule.AboutElemenDatasStoveNumber.Clear()
        For Each EachItem As CompanyORMDB.SQLServer.QCDB01.ProcessSchedule In TempDictionData.Values
            'CompanyORMDB.SQLServer.QCDB01.ProcessSchedule.AboutElemenDatasStoveNumber.Add(EachItem.StoveNumber)
            SearchResult.Add(EachItem)
        Next
        SearchResult.Sort(AddressOf CompareProcessScheduleBySortNumber)
        SetBindingSource.DataSource = SearchResult
        SetBindingSource.Position = 1
    End Sub

    Private Shared Function CompareProcessScheduleBySortNumber(ByVal x As CompanyORMDB.SQLServer.QCDB01.ProcessSchedule, ByVal y As CompanyORMDB.SQLServer.QCDB01.ProcessSchedule) As Integer
        Select Case True
            Case x.SortNumber > y.SortNumber
                Return 1
            Case x.SortNumber < y.SortNumber
                Return -1
        End Select
        Return 0
    End Function


#End Region

#Region "載入顯示資料 函式:LoadDisplayData"
    ''' <summary>
    ''' 載入顯示資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadDisplayData()
        Me.BSStoveA.DataSource = New List(Of CompanyORMDB.SQLServer.QCDB01.ProcessSchedule)
        Me.BSStoveB.DataSource = New List(Of CompanyORMDB.SQLServer.QCDB01.ProcessSchedule)
        Application.DoEvents()
        Dim QryString As String = "SELECT * FROM ProcessSchedule Where SortNumber>0 Order By SortNumber,StoveNumber Desc "
        Dim SearchResult As List(Of CompanyORMDB.SQLServer.QCDB01.ProcessSchedule) = CompanyORMDB.SQLServer.QCDB01.ProcessSchedule.CDBSelect(Of CompanyORMDB.SQLServer.QCDB01.ProcessSchedule)(QryString)
        Dim StoveADatas As New List(Of CompanyORMDB.SQLServer.QCDB01.ProcessSchedule)
        Dim StoveBDatas As New List(Of CompanyORMDB.SQLServer.QCDB01.ProcessSchedule)
        CompanyORMDB.SQLServer.QCDB01.ProcessSchedule.AboutElemenDatasStoveNumber.Clear()
        For Each EachItem As CompanyORMDB.SQLServer.QCDB01.ProcessSchedule In SearchResult
            If Not String.IsNullOrEmpty(EachItem.StoveNumber) AndAlso EachItem.StoveNumber.Trim.Length > 0 AndAlso (EachItem.StoveNumber.Substring(0, 1) = "A" Or EachItem.StoveNumber.Substring(0, 1) = "B") Then
                If EachItem.StoveNumber.Substring(0, 1) = "A" Then
                    StoveADatas.Add(EachItem)
                Else
                    StoveBDatas.Add(EachItem)
                End If
            End If
            CompanyORMDB.SQLServer.QCDB01.ProcessSchedule.AboutElemenDatasStoveNumber.Add(EachItem.StoveNumber)
        Next
        Me.BSStoveA.DataSource = StoveADatas
        Me.BSStoveB.DataSource = StoveBDatas
        Me.BSStoveA.Position = 1
        Me.BSStoveB.Position = 1
    End Sub
#End Region

#Region "變更兩筆資料順序 函式:ChangeTwoReocrdOrder"
    ''' <summary>
    ''' 變更兩筆資料順序
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ChangeTwoReocrdOrder(ByVal SourceDataSource As BindingSource, ByVal IsChangePreRecordPosition As Boolean)
        Dim DataRow1 As CompanyORMDB.SQLServer.QCDB01.ProcessSchedule = SourceDataSource.Current
        If IsNothing(DataRow1) Then
            Exit Sub
        End If
        Dim DataRow2 As CompanyORMDB.SQLServer.QCDB01.ProcessSchedule = Nothing  '= SourceData.Item(1)
        Dim SourceData As List(Of CompanyORMDB.SQLServer.QCDB01.ProcessSchedule) = SourceDataSource.DataSource
        If IsChangePreRecordPosition Then
            Dim RreRecordIndex As Integer = SourceData.IndexOf(DataRow1) - 1
            If RreRecordIndex < 0 Then
                DataRow2 = Nothing
            Else
                DataRow2 = SourceData(RreRecordIndex)
            End If
        Else
            Dim AfterRecordIndex As Integer = SourceData.IndexOf(DataRow1) + 1
            If AfterRecordIndex >= SourceData.Count Then
                DataRow2 = Nothing
            Else
                DataRow2 = SourceData(AfterRecordIndex)
            End If
        End If
        If IsNothing(DataRow2) Then
            Exit Sub
        End If

        Dim TempOrderNumber As Integer = DataRow1.SortNumber
        DataRow1.SortNumber = DataRow2.SortNumber
        DataRow2.SortNumber = TempOrderNumber
        SourceData.Sort(AddressOf CompareProcessScheduleBySortNumber)
        SourceDataSource.DataSource = SourceData
        SourceDataSource.ResetBindings(True)
        If IsChangePreRecordPosition Then
            SourceDataSource.MovePrevious()
        Else
            SourceDataSource.MoveNext()
        End If
    End Sub
#End Region

#Region "核對狀態新增資料並更新GridView 函式:CheckStateCreateDataAndUpdateGridView"
    ''' <summary>
    ''' 核對狀態新增資料並更新GridView
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckStateCreateDataAndUpdateGridView()
        Dim QryString As String = "SELECT * FROM ProcessSchedule Where SortNumber>0 Order By SortNumber,StoveNumber Desc "
        Dim SearchResult As List(Of CompanyORMDB.SQLServer.QCDB01.ProcessSchedule) = CompanyORMDB.SQLServer.QCDB01.ProcessSchedule.CDBSelect(Of CompanyORMDB.SQLServer.QCDB01.ProcessSchedule)(QryString)
        Dim StoveADatas As New List(Of CompanyORMDB.SQLServer.QCDB01.ProcessSchedule)
        Dim StoveBDatas As New List(Of CompanyORMDB.SQLServer.QCDB01.ProcessSchedule)
        CompanyORMDB.SQLServer.QCDB01.ProcessSchedule.AboutElemenDatasStoveNumber.Clear()
        For Each EachItem As CompanyORMDB.SQLServer.QCDB01.ProcessSchedule In SearchResult
            If Not String.IsNullOrEmpty(EachItem.StoveNumber) AndAlso EachItem.StoveNumber.Trim.Length > 0 AndAlso (EachItem.StoveNumber.Substring(0, 1) = "A" Or EachItem.StoveNumber.Substring(0, 1) = "B") Then
                If EachItem.StoveNumber.Substring(0, 1) = "A" Then
                    StoveADatas.Add(EachItem)
                Else
                    StoveBDatas.Add(EachItem)
                End If
            End If
            CompanyORMDB.SQLServer.QCDB01.ProcessSchedule.AboutElemenDatasStoveNumber.Add(EachItem.StoveNumber)
        Next

        CompanyORMDB.SQLServer.QCDB01.ProcessSchedule.ReGetAboutElementDatas(StoveADatas) : StoveADatas.Sort(AddressOf CompareProcessScheduleBySortNumber)
        CompanyORMDB.SQLServer.QCDB01.ProcessSchedule.ReGetAboutElementDatas(StoveBDatas) : StoveBDatas.Sort(AddressOf CompareProcessScheduleBySortNumber)

        Dim HighAreaLastStoveNumber As Integer = -1
        Dim LowAreaLastStoveNumber As Integer = -1
        For Each EachItem As CompanyORMDB.SQLServer.QCDB01.ProcessSchedule In StoveADatas
            If EachItem.IsInProcessCC Then
                EachItem.SortNumber = 0
                EachItem.CurrentState = 2
            End If
            If EachItem.StoveNumber.Trim.Length > 2 Then
                Dim GetStoveNumber As Integer = CType(EachItem.StoveNumber.Substring(1, EachItem.StoveNumber.Length - 1), Integer)
                If EachItem.CurrentState = 2 OrElse EachItem.CurrentState = 3 Then
                    GetStoveNumber += 1
                End If
                If GetStoveNumber > 1000 Then
                    HighAreaLastStoveNumber = IIf(HighAreaLastStoveNumber > GetStoveNumber, HighAreaLastStoveNumber, GetStoveNumber)
                Else
                    LowAreaLastStoveNumber = IIf(LowAreaLastStoveNumber > GetStoveNumber, LowAreaLastStoveNumber, GetStoveNumber)
                End If
            End If
        Next
        StoveADatas.RemoveAll(AddressOf RemoveInCondiction)
        Dim StoveANextAddNumber As Integer = IIf(LowAreaLastStoveNumber > 0, LowAreaLastStoveNumber, HighAreaLastStoveNumber)

        HighAreaLastStoveNumber = -1 : LowAreaLastStoveNumber = -1
        For Each EachItem As CompanyORMDB.SQLServer.QCDB01.ProcessSchedule In StoveBDatas
            If EachItem.IsInProcessCC Then
                EachItem.SortNumber = 0
                EachItem.CurrentState = 2
            End If
            If EachItem.StoveNumber.Trim.Length > 2 Then
                Dim GetStoveNumber As Integer = CType(EachItem.StoveNumber.Substring(1, EachItem.StoveNumber.Length - 1), Integer)
                If EachItem.CurrentState = 2 OrElse EachItem.CurrentState = 3 Then
                    GetStoveNumber += 1
                End If
                If GetStoveNumber > 1000 Then
                    HighAreaLastStoveNumber = IIf(HighAreaLastStoveNumber > GetStoveNumber, HighAreaLastStoveNumber, GetStoveNumber)
                Else
                    LowAreaLastStoveNumber = IIf(LowAreaLastStoveNumber > GetStoveNumber, LowAreaLastStoveNumber, GetStoveNumber)
                End If
            End If
        Next
        StoveBDatas.RemoveAll(AddressOf RemoveInCondiction)
        Dim StoveBNextAddNumber As Integer = IIf(LowAreaLastStoveNumber > 0, LowAreaLastStoveNumber, HighAreaLastStoveNumber)


        Dim StoveADisplayCount As Integer = 20
        Dim StoveBDisplayCount As Integer = 20
        Dim StaticWSDBSQLQueryAdapter As New CompanyORMDB.WSDBSQLQueryAdapter(True)
        Dim NowTime As DateTime = StaticWSDBSQLQueryAdapter.GetServerTime
        For AddItemCount As Integer = 1 To StoveADisplayCount - StoveADatas.Count
            Dim AddItem As New CompanyORMDB.SQLServer.QCDB01.ProcessSchedule
            StoveANextAddNumber += 1 : StoveANextAddNumber = IIf(StoveANextAddNumber <= 0, 1, StoveANextAddNumber)
            With AddItem
                .ID = Guid.NewGuid.ToString
                .StoveNumber = "A" & Format(StoveANextAddNumber, "0000")
                CompanyORMDB.SQLServer.QCDB01.ProcessSchedule.AboutElemenDatasStoveNumber.Add(.StoveNumber)
                .SteelKind = "304"
                .CurrentState = IIf(AddItem.IsInProcessCC, 2, 1)
                .StartStateTime = NowTime
                .SortNumber = 10000 + AddItemCount
            End With
            StoveADatas.Add(AddItem)
        Next
        For AddItemCount As Integer = 1 To StoveBDisplayCount - StoveBDatas.Count
            Dim AddItem As New CompanyORMDB.SQLServer.QCDB01.ProcessSchedule
            StoveBNextAddNumber += 1 : StoveBNextAddNumber = IIf(StoveBNextAddNumber <= 0, 1, StoveBNextAddNumber)
            With AddItem
                .ID = Guid.NewGuid.ToString
                .StoveNumber = "B" & Format(StoveBNextAddNumber, "0000")
                CompanyORMDB.SQLServer.QCDB01.ProcessSchedule.AboutElemenDatasStoveNumber.Add(.StoveNumber)
                .SteelKind = "304"
                .CurrentState = IIf(AddItem.IsInProcessCC, 2, 1)
                .StartStateTime = NowTime
                .SortNumber = 10000 + AddItemCount
            End With
            StoveBDatas.Add(AddItem)
            CompanyORMDB.SQLServer.QCDB01.ProcessSchedule.AboutElemenDatasStoveNumber.Add(AddItem.StoveNumber)
        Next

        Dim RemoveDoublesStoveNumbers As String = Nothing
        For Each EachItem As CompanyORMDB.SQLServer.QCDB01.ProcessSchedule In StoveADatas
            EachItem.SortNumber = StoveADatas.IndexOf(EachItem) + 1
            EachItem.ReGetAboutElementDatas()
            RemoveDoublesStoveNumbers &= IIf(EachItem.CDBSave() <= 0, Nothing, IIf(String.IsNullOrEmpty(RemoveDoublesStoveNumbers), Nothing, ",") & EachItem.StoveNumber)
        Next
        For Each EachItem As CompanyORMDB.SQLServer.QCDB01.ProcessSchedule In StoveBDatas
            EachItem.SortNumber = StoveBDatas.IndexOf(EachItem) + 1
            EachItem.ReGetAboutElementDatas()
            RemoveDoublesStoveNumbers &= IIf(EachItem.CDBSave() <= 0, Nothing, IIf(String.IsNullOrEmpty(RemoveDoublesStoveNumbers), Nothing, ",") & EachItem.StoveNumber)
        Next
        RemoveDoublesStoveNumber(RemoveDoublesStoveNumbers)
        StoveADatas.Sort(AddressOf CompareProcessScheduleBySortNumber)
        StoveBDatas.Sort(AddressOf CompareProcessScheduleBySortNumber)

        SetDataAndRefreshDataGridView(StoveADatas, StoveBDatas)

    End Sub

    Private Function RemoveInCondiction(ByVal SourceItem As CompanyORMDB.SQLServer.QCDB01.ProcessSchedule) As Boolean
        Dim StaticWSDBSQLQueryAdapter As New CompanyORMDB.WSDBSQLQueryAdapter(True)
        Dim ReturnValue As Boolean = (SourceItem.CurrentState = 2 OrElse SourceItem.CurrentState = 3)
        If ReturnValue Then
            SourceItem.SortNumber = 0
            SourceItem.EndStateTime = StaticWSDBSQLQueryAdapter.GetServerTime
            ReturnValue = (SourceItem.CDBSave() > 0)
        End If
        Return ReturnValue
    End Function

    Private Sub SetDataAndRefreshDataGridView(ByVal StoveAData As List(Of CompanyORMDB.SQLServer.QCDB01.ProcessSchedule), ByVal StoveBData As List(Of CompanyORMDB.SQLServer.QCDB01.ProcessSchedule))
        For Each EachItem As CompanyORMDB.SQLServer.QCDB01.ProcessSchedule In StoveAData
            EachItem.ReGetAboutElementDatas()
        Next
        For Each EachItem As CompanyORMDB.SQLServer.QCDB01.ProcessSchedule In StoveBData
            EachItem.ReGetAboutElementDatas()
        Next
        Dim NewDelegate As New SetGridViewDataSourceDelegate(AddressOf SetGridViewDataSource)
        Dim Args(2) As Object
        Args(0) = Me.BSStoveA
        Args(1) = StoveAData
        Args(2) = DataGridView1
        Me.Invoke(NewDelegate, Args)
        Args(0) = Me.BSStoveB
        Args(1) = StoveBData
        Args(2) = DataGridView2
        Me.Invoke(NewDelegate, Args)
    End Sub

    Delegate Sub SetGridViewDataSourceDelegate(ByVal SetBindingSource As BindingSource, ByVal SetData As List(Of CompanyORMDB.SQLServer.QCDB01.ProcessSchedule), ByVal SetRefreshDataGridView As DataGridView)
    Private Sub SetGridViewDataSource(ByVal SetBindingSource As BindingSource, ByVal SetData As List(Of CompanyORMDB.SQLServer.QCDB01.ProcessSchedule), ByVal SetRefreshDataGridView As DataGridView)
        SetBindingSource.DataSource = SetData
        SetBindingSource.ResetBindings(True)
        Application.DoEvents()
    End Sub

    '移除其它工作站所自行新增重複之爐號
    Private Sub RemoveDoublesStoveNumber(ByVal StoveNumbers As String)
        If String.IsNullOrEmpty(StoveNumbers) Then
            Exit Sub
        End If
        Dim QryString As String = "SELECT * FROM ProcessSchedule Where SortNumber>0 AND StoveNumber in ('" & StoveNumbers.Replace(",", "','") & "') Order By StoveNumber , StartStateTime Desc "
        Dim SearchResult As List(Of CompanyORMDB.SQLServer.QCDB01.ProcessSchedule) = CompanyORMDB.SQLServer.QCDB01.ProcessSchedule.CDBSelect(Of CompanyORMDB.SQLServer.QCDB01.ProcessSchedule)(QryString)
        Dim PreItem As CompanyORMDB.SQLServer.QCDB01.ProcessSchedule = Nothing
        For Each EachItme As CompanyORMDB.SQLServer.QCDB01.ProcessSchedule In SearchResult
            If Not IsNothing(PreItem) AndAlso PreItem.StoveNumber.Trim = EachItme.StoveNumber.Trim Then
                PreItem.CDBDelete()
            End If
            PreItem = EachItme
        Next
    End Sub

#End Region

#Region "控制項模式 屬性:ControlMode"

    Private _ControlMode As ControlModeEnum = ControlModeEnum.SleepMode
    ''' <summary>
    ''' 控制項模式
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ControlMode() As ControlModeEnum
        Get
            Return _ControlMode
        End Get
        Set(ByVal value As ControlModeEnum)
            _ControlMode = value

            If _ControlMode = ControlModeEnum.MoniterMode Then
                Dim NewThread As New Threading.Thread(AddressOf MoniterTimerSub)
                NewThread.Start()
            End If

            MoniterTimer.Enabled = (_ControlMode = ControlModeEnum.MoniterMode)
        End Set
    End Property

    Public Enum ControlModeEnum
        MoniterMode = 1
        EditMode = 2
        SleepMode = 99
    End Enum
#End Region

    Private Sub tbChangeAScore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbChangeAScore.Click, tbChangeBScore.Click
        If sender Is tbChangeAScore Then
            CreateAndDisplayStoveData(Me.BSStoveA, "A" & tbStartA.Text, 20)
        Else
            CreateAndDisplayStoveData(Me.BSStoveB, "B" & tbStartB.Text, 20)
        End If
    End Sub

    Private Sub UCScheduleAndState_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Authority As New PublicClassLibrary1.ValidAuthority(My.User.Name, CompanyORMDB.DeviceInformation.GetLocalIPs(0))
        btnSaveAll.Enabled = Authority.IsCanValidAuthoritySystemFunction("SMPWRK01", "SMPWRK0106")
        Dim DataList As New List(Of CurrentStateClass)
        DataList.Add(New CurrentStateClass(1, "製程中"))
        DataList.Add(New CurrentStateClass(2, "完成"))
        DataList.Add(New CurrentStateClass(3, "倒爐"))
        DataList.Add(New CurrentStateClass(4, "熔煉"))
        Me.BSCurrentStateA.DataSource = DataList.ToArray
        Me.BSCurrentStateB.DataSource = DataList.ToArray
        LoadDisplayData()
    End Sub


    Private Sub btnUP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUP.Click, btnDown.Click, btnUPB.Click, btnDownB.Click
        ChangeTwoReocrdOrder(IIf(sender Is btnUP OrElse sender Is btnDown, Me.BSStoveA, Me.BSStoveB), sender Is btnUP OrElse sender Is btnUPB)
    End Sub


    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click
        If TableLayoutPanel2.Enabled Then
            For Each EachItem As CompanyORMDB.SQLServer.QCDB01.ProcessSchedule In Me.BSStoveA.DataSource
                EachItem.CDBSave()
            Next
            For Each EachItem As CompanyORMDB.SQLServer.QCDB01.ProcessSchedule In Me.BSStoveB.DataSource
                EachItem.CDBSave()
            Next
            btnSaveAll.Text = "資料編輯模式"
            ControlMode = ControlModeEnum.MoniterMode
        Else
            btnSaveAll.Text = "儲存所有資料切換監看模式"
            ControlMode = ControlModeEnum.EditMode
        End If
        TableLayoutPanel2.Enabled = Not TableLayoutPanel2.Enabled
        TableLayoutPanel4.Enabled = TableLayoutPanel2.Enabled
        TableLayoutPanel5.Enabled = TableLayoutPanel2.Enabled
    End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged, DataGridView2.SelectionChanged
        Dim SenderObject As DataGridView = sender
        If SenderObject.SelectedRows.Count > 0 Then
            If SenderObject Is DataGridView1 Then
                btnUP.Enabled = SenderObject.SelectedRows(0).Index > 0
                btnDown.Enabled = SenderObject.SelectedRows(0).Index + 1 < SenderObject.RowCount
            Else
                btnUPB.Enabled = SenderObject.SelectedRows(0).Index > 0
                btnDownB.Enabled = SenderObject.SelectedRows(0).Index + 1 < SenderObject.RowCount
            End If
        End If
    End Sub

    Private Sub btnRefreshData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshData.Click
        Dim BeforeColor As Color = btnRefreshData.BackColor
        Dim BeforeText As String = btnRefreshData.Text
        btnRefreshData.Text = "資料重整中請稍後.....!"
        btnRefreshData.BackColor = Color.Red
        Application.DoEvents()
        LoadDisplayData()
        btnRefreshData.Text = BeforeText
        btnRefreshData.BackColor = BeforeColor
        btnRefreshData.Text = "資料重整完畢!"
    End Sub

    Private Sub MoniterTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoniterTimer.Tick
        MoniterTimer.Enabled = False
        Dim NewThread As New Threading.Thread(AddressOf MoniterTimerSub)
        NewThread.Start()
    End Sub
    Private Sub MoniterTimerSub()
        CheckStateCreateDataAndUpdateGridView()
        '啟動監看計時器
        Dim NewDelegate As SetOnMoniterTimerSub = AddressOf SetOnMoniterTimer
        Me.Invoke(NewDelegate)
    End Sub
    Delegate Sub SetOnMoniterTimerSub()
    Private Sub SetOnMoniterTimer()
        MoniterTimer.Enabled = (ControlMode = ControlModeEnum.MoniterMode)
    End Sub


End Class

#Region "CurrentStateList"

Public Class CurrentStateClass

    Sub New(ByVal SetCurrentStateVlue As Integer, ByVal SetCurrentStateExplain As String)
        CurrentStateVlue = SetCurrentStateVlue
        CurrentStateExplain = SetCurrentStateExplain
    End Sub

    Private _CurrentStateVlue As Integer
    Public Property CurrentStateVlue() As Integer
        Get
            Return _CurrentStateVlue
        End Get
        Set(ByVal value As Integer)
            _CurrentStateVlue = value
        End Set
    End Property

    Private _CurrentStateExplain As String
    Public Property CurrentStateExplain() As String
        Get
            Return _CurrentStateExplain
        End Get
        Set(ByVal value As String)
            _CurrentStateExplain = value
        End Set
    End Property
End Class

#End Region

