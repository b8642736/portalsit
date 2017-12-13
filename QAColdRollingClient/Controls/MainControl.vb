Public Class MainControl

    Public Event ExitSystem(ByVal Sender As MainControl)

    Public Shared tempQAThick As List(Of QAThickness)
    Public trigger As Boolean = True

#Region "登入工號 屬性:LoginID"
    Property LoginID As String '= 30276
#End Region
#Region "可以編修產線 屬性:CanEditStationLine"
    Private _CanEditStationLine As String '= "APL2"
    ''' <summary>
    ''' 可以編修產線
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CanEditStationLine As String
        Get
            Return _CanEditStationLine
        End Get
        Set(value As String)
            If Not String.IsNullOrEmpty(_CanEditStationLine) AndAlso value <> _CanEditStationLine Then
                Me.SaveAllControlDataToDB()
            End If
            _CanEditStationLine = value
        End Set
    End Property
#End Region
#Region "編輯鋼捲號碼 屬性:EditCoilNumber"
    Dim _EditCoilNumber As String
    ''' <summary>
    ''' 編輯鋼捲號碼
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property EditCoilNumber As String
        Get
            Return _EditCoilNumber
        End Get
        Set(value As String)
            'If Not String.IsNullOrEmpty(_EditCoilNumber) AndAlso value <> _EditCoilNumber Then
            '    Me.SaveAllControlDataToDB()
            'End If
            'Dim OldCoilNumber As String = _EditCoilNumber
            _EditCoilNumber = value
            'If OldCoilNumber <> _EditCoilNumber Then
            '    AutoSetNowDataDateAndLaseVersion()
            'End If
            'RefreshAllEnableControl()
        End Set
    End Property
#End Region
#Region "編輯資料日期 屬性:EditDataDate"
    Dim _EditDataDate As Nullable(Of Date) '= Now.Date
    ''' <summary>
    ''' 編輯資料日期
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property EditDataDate As Nullable(Of Date)
        Get
            Return _EditDataDate
        End Get
        Set(value As Nullable(Of Date))
            'If Not IsNothing(_EditDataDate) AndAlso value.Value <> _EditDataDate.Value Then
            '    Me.SaveAllControlDataToDB()
            'End If
            _EditDataDate = value
            'RefreshAllEnableControl()
        End Set
    End Property
#End Region
#Region "編輯日期版本 屬性:EditDataDateVersion"
    Private _EditDataDateVersion As String = Nothing
    ''' <summary>
    ''' 編輯日期版本
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property EditDataDateVersion As String
        Get
            Return _EditDataDateVersion
        End Get
        Set(value As String)
            'If Not String.IsNullOrEmpty(_EditDataDateVersion) AndAlso value <> _EditDataDateVersion Then
            '    Me.SaveAllControlDataToDB()
            'End If
            _EditDataDateVersion = value
        End Set
    End Property
#End Region
#Region "編輯輸出鋼捲號碼 屬性:EditOutCoilNumber"
    Private _EditOutCoilNumber As String
    ''' <summary>
    ''' 編輯輸出鋼捲號碼
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EditOutCoilNumber() As String
        Get
            If String.IsNullOrEmpty(_EditOutCoilNumber) Then
                _EditOutCoilNumber = Me.EditCoilNumber
            End If
            Return _EditOutCoilNumber
        End Get
        Set(ByVal value As String)
            _EditOutCoilNumber = value
        End Set
    End Property

#End Region
#Region "編修站名 屬性:EditStationName"
    ''' <summary>
    ''' 編修站名
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property EditStationName As String
        Get
            Select Case True
                Case rbAPL1.Checked
                    Return "APL1"
                Case rbAPL2.Checked
                    Return "APL2"
                Case rbBAL.Checked
                    Return "BAL"
            End Select
            Return ""
        End Get
        Private Set(value As String)
            Select Case True
                Case value = "APL1"
                    rbAPL1.Checked = True
                Case value = "APL2"
                    rbAPL2.Checked = True
                Case value = "BAL"
                    rbBAL.Checked = True
            End Select
        End Set
    End Property
#End Region
#Region "全捲鋼捲長 屬性:CoilMaxLength"
    Private _CoilMaxLength As Long = 9999
    ''' <summary>
    ''' 全捲鋼捲長
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CoilMaxLength As Long
        Get
            Return _CoilMaxLength
        End Get
        Private Set(ByVal value As Long)
            Static LastSetValue As Long = 9999
            _CoilMaxLength = value
            If String.IsNullOrEmpty(Me.LoginID) OrElse String.IsNullOrEmpty(CanEditStationLine) OrElse _
             String.IsNullOrEmpty(EditCoilNumber) OrElse IsNothing(Me.EditDataDate) OrElse _
             String.IsNullOrEmpty(Me.EditDataDateVersion) OrElse String.IsNullOrEmpty(Me.EditStationName) _
             Then
                LastSetValue = 9999
                _CoilMaxLength = 9999 : Exit Property
            End If
            If _CoilMaxLength < 1 OrElse _CoilMaxLength > 9999 Then
                _CoilMaxLength = 9999
            End If
            '變更鋼捲總長度
            If _CoilMaxLength <> LastSetValue Then
                For Each EachItem As BugItemMinDisplay In QABugRecordShowControls
                    With EachItem
                        If .QABugRecordData.EditEmployeeID.Trim = Me.LoginID.Trim AndAlso _
                            .QABugRecordData.StationName.Trim = Me.CanEditStationLine.Trim AndAlso _
                            .QABugRecordData.CoilNumber.Trim = Me.EditCoilNumber.Trim AndAlso _
                            (Not IsNothing(Me.EditDataDate) AndAlso .QABugRecordData.DataDate = Me.EditDataDate.Value) AndAlso _
                            .QABugRecordData.Version = Me.EditDataDateVersion AndAlso _
                            .QABugRecordData.CoilMaxLength <> _CoilMaxLength Then

                            .QABugRecordData.CoilMaxLength = _CoilMaxLength
                            .QABugRecordData = EachItem.QABugRecordData '更新顯示
                            .QABugRecordData.CDBSave()

                        End If
                    End With
                Next
            End If
            LastSetValue = _CoilMaxLength
        End Set
    End Property
#End Region
#Region "編修站之IP 屬性:EditStationIP"
    ''' <summary>
    ''' 編修站之IP
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property EditStationIP As String
        Get
            Select Case EditStationName
                Case "APL1"
                    Return "10.12.7.21"
                Case "APL2"
                    Return "10.12.2.21"
                Case "BAL"
                    Return "10.12.21.21"
            End Select
            Return ""
        End Get
    End Property
#End Region
#Region "列印標主機IP  屬性:PrintLabelStationNameIP"
    ''' <summary>
    ''' 列印標主機IP
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property PrintLabelStationIP As String
        Get
            Select Case EditStationName
                Case "APL1"
                    Return "10.12.7.10"
                Case "APL2"
                    Return "10.12.2.10"
                Case "BAL"
                    Return "10.12.21.3"
            End Select
            Return ""
        End Get
    End Property
#End Region
#Region "自動設定最新資料日期及最新版本 函式:AutoSetDataDateAndLaseVersion"
    ''' <summary>
    ''' 自動設定最新資料日期及最新版本
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AutoSetNowDataDateAndLaseVersion(Optional IsWillFindYesterdayData As Boolean = True)
        Me.EditDataDate = Nothing
        Me.EditDataDateVersion = Nothing
        If String.IsNullOrEmpty(Me.EditCoilNumber) Then
            Exit Sub
        End If
        Me.EditDataDate = Now.Date '先找當天資料是否存在
        Dim Qry As String = "Select * From QABugRecordTitle where OutCoilNumber='" & Me.EditOutCoilNumber.Trim & "' and StationName='" & Me.CanEditStationLine.Trim & "' and DataDate = '" & Format(Me.EditDataDate, "yyyy/MM/dd") & "' Order by  Version Desc "
        Dim Adapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
        Dim SearchResult2 As DataTable = Adapter.SelectQuery(Qry)
        If SearchResult2.Rows.Count > 0 Then
            Me.EditCoilNumber = SearchResult2.Rows(0).Item("CoilNumber")
            Me.EditDataDateVersion = Val(SearchResult2.Rows(0).Item("Version"))
        Else
            Me.EditDataDate = Now.Date.AddDays(-1)  '再找前一天資料是否存在,有則使用前一天資料
            Qry = "Select * From QABugRecordTitle where OutCoilNumber='" & Me.EditOutCoilNumber.Trim & "' and StationName='" & Me.CanEditStationLine.Trim & "' and DataDate = '" & Format(Me.EditDataDate, "yyyy/MM/dd") & "' Order by  Version Desc "
            Dim SearchResult3 As DataTable = Adapter.SelectQuery(Qry)
            If IsWillFindYesterdayData AndAlso SearchResult3.Rows.Count > 0 Then
                Me.EditCoilNumber = SearchResult3.Rows(0).Item("CoilNumber")
                Me.EditDataDateVersion = Val(SearchResult3.Rows(0).Item("Version"))
            Else
                Me.EditDataDate = Now.Date
                Me.EditDataDateVersion = 1
            End If
        End If
    End Sub
#End Region
#Region "可作業條件是否充足 屬性:IsCanWorkDataReady"
    ''' <summary>
    ''' 可作業條件是否充足
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsCanWorkDataReady As Boolean
        Get
            '檢核是否資料完備才可取得編修缺陷記錄台頭
            Select Case True
                Case String.IsNullOrEmpty(LoginID) OrElse LoginID.Trim.Length = 0
                    Return False
                Case String.IsNullOrEmpty(CanEditStationLine) OrElse CanEditStationLine.Trim.Length = 0
                    Return False
                Case String.IsNullOrEmpty(EditCoilNumber) OrElse EditCoilNumber.Trim.Length = 0
                    Return False
                Case IsNothing(EditDataDate)
                    Return False
                Case CanEditStationLine <> CurrentEditStationLine
                    Return False
                Case String.IsNullOrEmpty(EditOutCoilNumber) OrElse EditOutCoilNumber.Trim.Length = 0
                Case Else
            End Select
            Return True
        End Get
    End Property
#End Region

#Region "目前正在編修之缺陷記錄台頭 屬性:CurrentEditQABugRecordTitle"
    Private _CurrentEditQABugRecordTitle As QABugRecordTitle
    'Private LastSearchKey As String
    ''' <summary>
    ''' 目前正在編修之缺陷記錄台頭
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CurrentEditQABugRecordTitle() As QABugRecordTitle
        Get
            Return _CurrentEditQABugRecordTitle
        End Get
        Private Set(ByVal value As QABugRecordTitle)
            _CurrentEditQABugRecordTitle = value
            If IsNothing(_CurrentEditQABugRecordTitle) Then
                Me.CoilOtherInfoControl = Nothing
            End If
        End Set
    End Property

#End Region
#Region "重新載入缺台頭資料 函式:ReloadQABugRecordTitleData"
    ''' <summary>
    ''' 重新載入缺台頭資料
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ReloadQABugRecordTitleData()
        '檢核是否資料完備才可取得編修缺陷記錄台頭
        Me.CurrentEditQABugRecordTitle = Nothing
        If IsCanWorkDataReady = False Then
            Exit Sub
        End If

        Dim QryString As New System.Text.StringBuilder
        QryString.Append("Select * From QABugRecordTitle Where CoilNumber='" & Me.EditCoilNumber & "'")
        QryString.Append(" and StationName='" & Me.CanEditStationLine & "'")
        QryString.Append(" and DataDate='" & Format(Me.EditDataDate, "yyyy/MM/dd") & "'")
        QryString.Append(" and Version='" & Me.EditDataDateVersion & "'")
        QryString.Append(" and OutCoilNumber='" & Me.EditOutCoilNumber & "'")
        QryString.Append(" order by CoilStartTime desc")



        Dim QryResult As List(Of CompanyORMDB.SQLServer.PPS100LB.QABugRecordTitle) = CompanyORMDB.SQLServer.PPS100LB.QABugRecordTitle.CDBSelect(Of CompanyORMDB.SQLServer.PPS100LB.QABugRecordTitle)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString.ToString)
        If QryResult.Count = 0 Then
            Dim AS400Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, "PPS100LB")
            _CurrentEditQABugRecordTitle = New QABugRecordTitle
            With _CurrentEditQABugRecordTitle
                .CoilNumber = Me.EditCoilNumber
                .StationName = Me.EditStationName
                .DataDate = Me.EditDataDate
                .Version = Me.EditDataDateVersion
                .OutCoilNumber = Me.EditOutCoilNumber
                .LastEditEmployeeID = Me.LoginID
                '有經過CPL時,APL1產線要自動設定導片為六米
                If Not String.IsNullOrEmpty(.StationName) AndAlso .StationName.PadRight(4).Substring(0, 4) = "APL1" Then
                    QryString.Clear()
                    QryString.Append("Select Count(*) From @#PPS100LB.PPSSHAPF WHERE RTRIM(SHA01)='" & Me.EditCoilNumber.PadRight(5).Substring(0, 5) & "' AND SHA21>0 AND SHA08 LIKE 'CP%'")
                    Dim QryResult1 As DataTable = AS400Adapter.SelectQuery(QryString.ToString)
                    Dim IsOveerCPLLine As Boolean = (Val(QryResult1.Rows(0).Item(0)) > 0)
                    .CoilPositionErrLength = IIf(IsOveerCPLLine, -6, 0)
                    .JointLength = IIf(IsOveerCPLLine, 6, 0)
                Else
                    .CoilPositionErrLength = 0
                    .JointLength = 0
                End If
            End With
            If CurrentEditQABugRecordTitle.CDBSave = 0 Then
                CurrentEditQABugRecordTitle = Nothing
            End If
        Else
            CurrentEditQABugRecordTitle = QryResult(0)
            If CurrentEditQABugRecordTitle.IsWillHandOver Then
                CurrentEditQABugRecordTitle.LastEditEmployeeID = Me.LoginID
                CurrentEditQABugRecordTitle.IsWillHandOver = False
                CurrentEditQABugRecordTitle.CDBSave()
            End If
        End If
    End Sub
#End Region


#Region "重整控制項顯示 屬性:RefreshAllEnableControl"
    ''' <summary>
    ''' 重整控制項顯示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshAllEnableControl()
        tbLogin.Text = "登入" & IIf(String.IsNullOrEmpty(CanEditStationLine), Nothing, ":" & CanEditStationLine)
        tbLogin.Text &= IIf(String.IsNullOrEmpty(LoginID), Nothing, vbNewLine & "工號:" & LoginID)
        btnCoilNumber.Visible = Not String.IsNullOrEmpty(LoginID) AndAlso Not String.IsNullOrEmpty(CanEditStationLine)
        btnCoilNumber.Text = "鋼捲編號" & IIf(String.IsNullOrEmpty(EditOutCoilNumber), Nothing, vbNewLine & EditOutCoilNumber)
        If IsNothing(EditDataDate) Then
            btnDataDate.Text = "報表日期"
        Else
            btnDataDate.Text = "報表日期" & vbNewLine & EditDataDate.Value.Year - 1911 & Format(EditDataDate.Value, "/MM/dd")
        End If
        If tlpItems.Controls.Count > 0 Then
            FlowLay.Enabled = Not TypeOf tlpItems.Controls(0) Is BugItemEdit
        Else
            FlowLay.Enabled = True
        End If
        btnDataDate.Visible = Not String.IsNullOrEmpty(CanEditStationLine) AndAlso Not String.IsNullOrEmpty(LoginID) AndAlso Not String.IsNullOrEmpty(EditCoilNumber)
        rbAPL1.Visible = Not String.IsNullOrEmpty(EditCoilNumber) AndAlso Not IsNothing(EditDataDate)
        rbAPL2.Visible = rbAPL1.Visible
        rbBAL.Visible = rbAPL1.Visible
        tbPrint.Visible = rbAPL1.Visible
        'tbPrint.Enabled = (Me.CanEditStationLine = "APL1" And rbAPL1.Checked)
        'btnAddNewBugRecord.Visible = rbAPL1.Visible AndAlso (Me.CurrentEditStationLine = Me.CanEditStationLine)
        'If btnAddNewBugRecord.Visible = True Then
        '    Select Case True
        '        Case TabControl1.SelectedTab Is tpBugEdit
        '            btnAddNewBugRecord.Text = "新增缺陷"
        '        Case TabControl1.SelectedTab Is tpThicknessEdit
        '            btnAddNewBugRecord.Text = "新增厚度"
        '            'Case TabControl1.SelectedTab Is tpBrightnessEdit AndAlso Me.CurrentEditStationLine.Substring(0, 3) = "BAL"
        '            '    btnAddNewBugRecord.Text = "新增亮度"
        '        Case Else
        '            btnAddNewBugRecord.Visible = False
        '    End Select
        'End If

        ''106/08/17 ADD
        ''刷新缺陷輸入的radioBtn的初始值
        ''Me.CoilOtherInfoControl.refreshRadioBtn_upAndDown()
        ''106/08/29 ADD
        ''初始上下收狀態
        initialRadioBtn_UpDown()
      




        btnPageDown.Visible = rbAPL1.Visible
        btnPageUP.Visible = rbAPL1.Visible
        If tpThicknessEdit.Controls.Count > 0 Then
            For Each EachControl As Control In tpThicknessEdit.Controls
                EachControl.Visible = rbAPL1.Visible
            Next
        End If
        If tpQuickOperator.Controls.Count > 0 Then
            For Each EachControl As Control In tpQuickOperator.Controls
                EachControl.Visible = rbAPL1.Visible
            Next
        End If
        If tpOtherEdit.Controls.Count > 0 Then
            For Each EachControl As Control In tpOtherEdit.Controls
                EachControl.Visible = rbAPL1.Visible
            Next
        End If

        btnQuckSetAP2AllValues.Enabled = False
        If Not String.IsNullOrEmpty(Me.CanEditStationLine) AndAlso Not String.IsNullOrEmpty(Me.CurrentEditStationLine) AndAlso _
            Me.CanEditStationLine = Me.CurrentEditStationLine Then
            btnQuckSetAP2AllValues.Enabled = True
        End If

        btnExit.Text = "離開"
    End Sub
#End Region

#Region "目前正在編輯的站台名稱 屬性:CurrentEditStationLine"
    ''' <summary>
    ''' 目前正在編輯的站台名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CurrentEditStationLine As String
        Get
            Select Case True
                Case rbAPL1.Checked
                    Return "APL1"
                Case rbAPL2.Checked
                    Return "APL2"
                Case rbBAL.Checked
                    Return "BAL"
            End Select
            Return Nothing
        End Get
        Set(value As String)
            Select Case True
                Case value = "APL1"
                    rbAPL1.Checked = True
                Case value = "APL2"
                    rbAPL2.Checked = True
                Case value = "BAL"
                    rbBAL.Checked = True
            End Select
        End Set
    End Property
#End Region

#Region "缺陷資料顯示控制項 屬性:QABugRecordShowControls"
    Private _QABugRecordShowControls As New List(Of Control)
    ''' <summary>
    ''' 缺陷資料顯示控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property QABugRecordShowControls As List(Of Control)
        Get
            Return _QABugRecordShowControls
        End Get
        Set(value As List(Of Control))
            _QABugRecordShowControls = value
        End Set
    End Property
#End Region
#Region "重新顯示缺陷資料顯示控制項 函式:ReDisplayQABugRecordShowControls"
    ''' <summary>
    ''' 重新顯示缺陷資料顯示控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ReDisplayQABugRecordShowControls()

        tlpItems.Controls.Clear()
        '只有顯示抬頭資訊
        Dim AddTitleShowOnlyControl As New BugItemMinDisplay(Nothing, Me)

        With AddTitleShowOnlyControl
            .IsWillShowTitle = True
            .IsWillShowDatadetail = False
            .Anchor = AnchorStyles.Bottom And AnchorStyles.Left And AnchorStyles.Right And AnchorStyles.Top
            .Font = New Font("Arial", 14, FontStyle.Bold)
            .Margin = New Padding(0, 5, 20, 5)
        End With
        tlpItems.Controls.Add(AddTitleShowOnlyControl)



        tlpItems.SetCellPosition(AddTitleShowOnlyControl, New TableLayoutPanelCellPosition(0, 0))

        '重整顯示資料本身
        For Each EachItem As Control In QABugRecordShowControls
            RemoveHandler CType(EachItem, BugItemMinDisplay).ControlMouseDownClick, AddressOf QABugRecordShowControls_ControlMouseDownClick
        Next
        Dim flpItemContainer As New FlowLayoutPanel
        flpItemContainer.AutoScroll = False
        flpItemContainer.FlowDirection = FlowDirection.TopDown
        flpItemContainer.Dock = DockStyle.Fill
        'flpItemContainer.Anchor = AnchorStyles.Bottom And AnchorStyles.Left And AnchorStyles.Right And AnchorStyles.Top
        flpItemContainer.VerticalScroll.Visible = True
        flpItemContainer.HorizontalScroll.Visible = False
        flpItemContainer.WrapContents = False
        flpItemContainer.Padding = New Padding(0, 0, 10, 0)
        flpItemContainer.Margin = New Padding(0)



        flpItemContainer.Refresh()

        tlpItems.SetCellPosition(flpItemContainer, New TableLayoutPanelCellPosition(0, 1))
        tlpItems.SetRowSpan(flpItemContainer, tlpItems.RowCount - 1)
        tlpItems.Controls.Add(flpItemContainer)
        For Each EachItem As BugItemMinDisplay In QABugRecordShowControls
            With EachItem
                .Anchor = AnchorStyles.Top 'Or AnchorStyles.Right Or AnchorStyles.Left
                .Margin = New Padding(0)
                .Font = tlpItems.Controls(0).Font
                .Size = New Size(tlpItems.Controls(0).Width, 70)
                .Cursor = Cursors.Hand
                .IsWillShowTitle = False
            End With


            AddHandler CType(EachItem, BugItemMinDisplay).ControlMouseDownClick, AddressOf QABugRecordShowControls_ControlMouseDownClick
            flpItemContainer.Controls.Add(EachItem)
        Next
        flpItemContainer.AutoScroll = True

    End Sub
#End Region
#Region "重新載入資料庫缺陷資料 函式:ReLoadDBQABugRecords"
    ''' <summary>
    ''' 重新載入資料庫缺陷資料
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ReLoadDBQABugRecords()
        For Each EachItem As Control In QABugRecordShowControls
            RemoveHandler CType(EachItem, BugItemMinDisplay).ControlMouseDownClick, AddressOf QABugRecordShowControls_ControlMouseDownClick
        Next
        QABugRecordShowControls.Clear()
        tlpBugEditTable.SetColumnSpan(tlpItems, 1)
        If String.IsNullOrEmpty(EditCoilNumber) OrElse IsNothing(EditDataDate) Then
            Exit Sub
        End If

        '載入鋼捲缺陷資料
        Dim Qry As String = "Select * From QABugRecord Where CoilNumber='" & EditCoilNumber & "' AND OutCoilNumber='" & Me.EditOutCoilNumber & "' And  DataDate='" & Format(Me.EditDataDate, "yyyy/MM/dd") & "' AND StationName='" & CurrentEditStationLine & "'  AND Version='" & Me.EditDataDateVersion.Trim & "' and RecordState <> 3 and EndPosition >= 9999 "
        Qry &= " UNION Select * From QABugRecord Where CoilNumber='" & EditCoilNumber & "' AND OutCoilNumber='" & Me.EditOutCoilNumber & "' And  DataDate='" & Format(Me.EditDataDate, "yyyy/MM/dd") & "' AND StationName='" & CurrentEditStationLine & "'  AND Version='" & Me.EditDataDateVersion.Trim & "' and RecordState <> 3  and EndPosition < 9999  "


        Dim ShowItemNumber As Integer = 1
        Dim SetCoilMaxLength As Long = 9999    '設定整捲長變數
        Dim SearchResult As List(Of QABugRecord) = QABugRecord.CDBSelect(Of QABugRecord)(Qry)

        If Not IsNothing(Me.CurrentEditQABugRecordTitle) Then
            ReloadQABugRecordTitleData()
        End If

        For Each EachItem As QABugRecord In SearchResult
            Dim AddItem As New BugItemMinDisplay(EachItem, Me)
            With AddItem
                .ItemNumber = Format(ShowItemNumber, "00")
                .Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
                .Font = New Font("Arial", 9, FontStyle.Bold)
                .Cursor = Cursors.Hand

                If Not String.IsNullOrEmpty(EachItem.EditEmployeeID) AndAlso Not String.IsNullOrEmpty(Me.LoginID) Then
                    If Not IsNothing(Me.CurrentEditQABugRecordTitle) AndAlso EachItem.EditEmployeeID.Trim <> Me.LoginID AndAlso _
                         Not IsNothing(Me.CurrentEditQABugRecordTitle.HandOverBeforeeEmpID) AndAlso EachItem.EditEmployeeID.Trim = Me.CurrentEditQABugRecordTitle.HandOverBeforeeEmpID.Trim Then
                        '執行交接人員資料編修權限移轉
                        EachItem.EditEmployeeID = Me.LoginID
                        EachItem.CDBSave()
                    End If
                    .IsCanEdit = (EachItem.EditEmployeeID.Trim = Me.LoginID) AndAlso (Me.CurrentEditStationLine = Me.CanEditStationLine)
                Else
                    .IsCanEdit = False
                End If

                If .QABugRecordData.EditEmployeeID.Trim = Me.LoginID.Trim AndAlso SetCoilMaxLength <> .QABugRecordData.CoilMaxLength Then
                    SetCoilMaxLength = .QABugRecordData.CoilMaxLength
                End If
            End With
            AddItem.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
            AddHandler CType(AddItem, BugItemMinDisplay).ControlMouseDownClick, AddressOf QABugRecordShowControls_ControlMouseDownClick
            QABugRecordShowControls.Add(AddItem)
            ShowItemNumber += 1
        Next
        Me.CoilMaxLength = SetCoilMaxLength '依據現有資料設定整捲長

        ReDisplayQABugRecordShowControls()
    End Sub
#End Region


#Region "實測厚度資料顯示控制項 屬性:QAThicknessRecordShowControls"
    Private _QAThicknessRecordShowControls As New List(Of Control)
    ''' <summary>
    ''' 實測厚度資料顯示控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property QAThicknessRecordShowControls As List(Of Control)
        Get
            Return _QAThicknessRecordShowControls
        End Get
        Set(value As List(Of Control))
            _QAThicknessRecordShowControls = value
        End Set
    End Property
#End Region
#Region "重新顯示實測厚度資料顯示控制項 函式:ReDisplayQAThicknessRecordShowControls"
    ''' <summary>
    ''' 重新顯示實測厚度資料顯示控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ReDisplayQAThicknessRecordShowControls()
        For Each EachItem As Control In QAThicknessRecordShowControls
            RemoveHandler CType(EachItem, ThickItemMinDisplay).ControlMouseDownClick, AddressOf QAThicknessRecordShowControls_ControlMouseDownClick
        Next
        tlpItems.Controls.Clear()
        Dim EachItemIndex As Integer = 1
        Dim PageContinerCount As Integer = tlpThicknessItems.RowCount * tlpThicknessItems.ColumnCount
        Dim SetRowLocation As Integer = 0
        Dim SetColumnLocation As Integer = 0
        tlpThicknessItems.Controls.Clear()
        For Each EachItem As ThickItemMinDisplay In QAThicknessRecordShowControls
            If Not (EachItemIndex >= ((ShowPageNumber - 1) * PageContinerCount + 1) And EachItemIndex < (ShowPageNumber * PageContinerCount + 1)) Then
                EachItemIndex += 1
                Continue For
            End If
            EachItemIndex += 1
            With EachItem
                .Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
                .Font = New Font("Arial", 14, FontStyle.Bold)
                .Cursor = Cursors.Hand
                .Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
                If SetRowLocation > 0 Then
                    .IsWillShowTitle = False
                End If
            End With
            AddHandler CType(EachItem, ThickItemMinDisplay).ControlMouseDownClick, AddressOf QAThicknessRecordShowControls_ControlMouseDownClick
            tlpThicknessItems.Controls.Add(EachItem)
            tlpThicknessItems.SetCellPosition(EachItem, New TableLayoutPanelCellPosition(SetColumnLocation, SetRowLocation))
            SetRowLocation += 1
            If SetRowLocation >= tlpItems.RowCount Then
                SetRowLocation = 0
                SetColumnLocation += 1
            End If
        Next


    End Sub
#End Region
#Region "重新載入載入實測厚度資料 函式:ReLoadDBQAThicknessRecords"
    ''' <summary>
    ''' 重新載入載入實測厚度資料
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ReLoadDBQAThicknessRecords()
        For Each EachItem As Control In QABugRecordShowControls
            RemoveHandler CType(EachItem, BugItemMinDisplay).ControlMouseDownClick, AddressOf QABugRecordShowControls_ControlMouseDownClick
        Next
        QAThicknessRecordShowControls.Clear()
        If String.IsNullOrEmpty(EditCoilNumber) OrElse IsNothing(EditDataDate) Then
            Exit Sub
        End If

        '載入鋼捲實測厚度資料
        Dim Qry As String = "Select * From QAThickness Where CoilNumber='" & EditCoilNumber.Trim & "' AND OutCoilNumber = '" & EditOutCoilNumber.Trim & "' And  DataDate='" & Format(Me.EditDataDate, "yyyy/MM/dd") & "' AND StationName='" & CurrentEditStationLine & "'  AND Version='" & Me.EditDataDateVersion.Trim & "'  and RecordState <> 3 Order by DataCreateTime Asc "
        Dim ShowItemNumber As Integer = 1
        For Each EachItem As QAThickness In QAThickness.CDBSelect(Of QAThickness)(Qry)
            Dim AddItem As New ThickItemMinDisplay(EachItem, Me)
            With AddItem
                .ItemNumber = Format(ShowItemNumber, "00")
                .Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
                .Font = New Font("Arial", 9, FontStyle.Bold)
                .Cursor = Cursors.Hand
                If Not String.IsNullOrEmpty(EachItem.EditEmployeeID) AndAlso Not String.IsNullOrEmpty(Me.LoginID) Then
                    .IsCanEdit = (EachItem.EditEmployeeID.Trim = Me.LoginID) AndAlso (Me.CurrentEditStationLine = Me.CanEditStationLine)
                Else
                    .IsCanEdit = False
                End If
            End With
            AddItem.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
            AddHandler CType(AddItem, ThickItemMinDisplay).ControlMouseDownClick, AddressOf QAThicknessRecordShowControls_ControlMouseDownClick
            QAThicknessRecordShowControls.Add(AddItem)
            ShowItemNumber += 1
        Next

        ReDisplayQAThicknessRecordShowControls()
    End Sub
#End Region


#Region "使用者登入控制項 屬性/事件:UserLoginControl/UserLoginControlEvent"
    WithEvents UserLoginControlEvent As MainControl_UserLogin
    Private _UserLoginControl As MainControl_UserLogin
    ''' <summary>
    ''' 使用者登入控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property UserLoginControl As MainControl_UserLogin
        Get
            If IsNothing(_UserLoginControl) Then
                _UserLoginControl = New MainControl_UserLogin(Me)
                UserLoginControlEvent = _UserLoginControl
                _UserLoginControl.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
            End If
            Return _UserLoginControl
        End Get
        Set(value As MainControl_UserLogin)
            _UserLoginControl = value
        End Set
    End Property
#End Region
#Region "鋼捲編號輸入控制項 屬性/事件:MainControl_CoilNumberInputControl/MainControl_CoilNumberInputControlEvent"
    WithEvents MainControl_CoilNumberInputControlEvent As MainControl_CoilNumberInput
    Private _MainControl_CoilNumberInputControl As MainControl_CoilNumberInput
    ''' <summary>
    ''' 鋼捲編號輸入控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property MainControl_CoilNumberInputControl As MainControl_CoilNumberInput
        Get
            If IsNothing(_MainControl_CoilNumberInputControl) Then
                _MainControl_CoilNumberInputControl = New MainControl_CoilNumberInput(Me)
                MainControl_CoilNumberInputControlEvent = _MainControl_CoilNumberInputControl
                _MainControl_CoilNumberInputControl.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
            End If
            Return _MainControl_CoilNumberInputControl
        End Get
    End Property
#End Region
#Region "報表缺限群組輸入控制項 屬性/事件:BugItemGroupEditControl/BugItemGroupEditControlEvent"
    WithEvents BugItemGroupEditControlEvent As BugItemGroupEdit
    Private _BugItemGroupEditControl As BugItemGroupEdit = Nothing
    ''' <summary>
    ''' 報表缺限群組輸入控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property BugItemGroupEditControl As BugItemGroupEdit
        Get
            If IsNothing(_BugItemGroupEditControl) Then
                _BugItemGroupEditControl = New BugItemGroupEdit(Me)
                BugItemGroupEditControlEvent = _BugItemGroupEditControl
                _BugItemGroupEditControl.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
            End If
            Return _BugItemGroupEditControl
        End Get
    End Property
#End Region
#Region "缺陷編修控制項/事件 事件:BugItemEditControl/BugItemEditControlEvent"
    WithEvents BugItemEditControlEvent As BugItemEdit
    Private _BugItemEditControl As BugItemEdit
    Property BugItemEditControl As BugItemEdit
        Get
            If IsNothing(_BugItemEditControl) Then
                _BugItemEditControl = New BugItemEdit(Nothing, Me, BugItemEdit.ControlDataProcessModeEnum.InsertMode)
                BugItemEditControlEvent = _BugItemEditControl
            End If
            Return _BugItemEditControl
        End Get
        Private Set(value As BugItemEdit)
            _BugItemEditControl = value
            BugItemEditControlEvent = _BugItemEditControl
        End Set
    End Property
#End Region
#Region "實測厚度控制項 屬性/事件:ThicknessEditControl/ThicknessEditControlEvent"
    WithEvents ThicknessEditControlEvent As ThickItemEdit
    Private _ThicknessEditControl As ThickItemEdit
    ''' <summary>
    ''' 實測厚度控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ThicknessEditControl As ThickItemEdit
        Get
            If IsNothing(_ThicknessEditControl) Then
                _ThicknessEditControl = New ThickItemEdit(Nothing, Me)
                ThicknessEditControlEvent = _ThicknessEditControl
            End If
            Return _ThicknessEditControl
        End Get
        Set(value As ThickItemEdit)
            _ThicknessEditControl = value
            ThicknessEditControlEvent = _ThicknessEditControl
        End Set
    End Property
#End Region
#Region "鋼捲台頭資訊編修_BAL 屬性/事件:CoilOtherInfoControl/CoilOtherInfoControlEvent"
    WithEvents CoilOtherInfoControlEvent As IxxxTitleEdit

    Private _CoilOtherInfoControl As IxxxTitleEdit
    Public Property CoilOtherInfoControl() As IxxxTitleEdit
        Get
            Select Case True
                Case String.IsNullOrEmpty(Me.CurrentEditStationLine)
                    _CoilOtherInfoControl = Nothing
                Case Me.CurrentEditStationLine = "APL1" AndAlso (IsNothing(_CoilOtherInfoControl) OrElse Not TypeOf _CoilOtherInfoControl Is APL1OthersEdit)
                    _CoilOtherInfoControl = New APL1OthersEdit(Me)
                Case Me.CurrentEditStationLine = "APL2" AndAlso (IsNothing(_CoilOtherInfoControl) OrElse Not TypeOf _CoilOtherInfoControl Is APL2OthersEdit)
                    _CoilOtherInfoControl = New APL2OthersEdit(Me)
                Case Me.CurrentEditStationLine = "BAL" AndAlso (IsNothing(_CoilOtherInfoControl) OrElse Not TypeOf _CoilOtherInfoControl Is BALOthersEdit)
                    _CoilOtherInfoControl = New BALOthersEdit(Me)
            End Select
            CoilOtherInfoControlEvent = _CoilOtherInfoControl
            Return _CoilOtherInfoControl
        End Get
        Set(ByVal value As IxxxTitleEdit)
            _CoilOtherInfoControl = value
        End Set
    End Property

#End Region


#Region "顯示控制項至編輯顯示區域 函式:ShowControlToFullEditArea"
    ''' <summary>
    ''' 顯示控制項至編輯顯示區域
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowControlToFullEditArea(ByVal SetShowControl As Control)
        Select Case True
            Case TabControl1.SelectedTab Is tpBugEdit
                Select Case True
                    Case IsNothing(SetShowControl)
                        tlpBugEditTable.SetColumnSpan(tlpItems, 2)
                        tlpItems.Controls.Clear()
                        ReDisplayQABugRecordShowControls()
                    Case TypeOf SetShowControl Is BugItemEdit
                        For Each EachControl As Control In tlpBugEditTable.Controls
                            If TypeOf EachControl Is BugItemEdit Then
                                tlpBugEditTable.Controls.Remove(EachControl)
                            End If
                        Next
                        SetShowControl.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
                        tlpBugEditTable.SetRow(SetShowControl, 0)
                        tlpBugEditTable.SetColumn(SetShowControl, 1)
                        tlpBugEditTable.Controls.Add(SetShowControl)
                        SetShowControl.Visible = True
                    Case Else
                        tlpBugEditTable.SetColumnSpan(tlpItems, 2)
                        tlpItems.Controls.Clear()
                        SetShowControl.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
                        tlpItems.SetRowSpan(SetShowControl, tlpItems.RowCount)
                        tlpItems.SetColumnSpan(SetShowControl, tlpItems.ColumnCount)
                        tlpItems.Controls.Add(SetShowControl)
                        SetShowControl.Visible = True
                End Select
            Case TabControl1.SelectedTab Is tpThicknessEdit
                Select Case True
                    Case IsNothing(SetShowControl)
                        tlpThicknessItems.Controls.Clear()
                        ReDisplayQAThicknessRecordShowControls()
                    Case TypeOf SetShowControl Is ThickItemEdit
                        For Each EachControl As Control In tlpThicknessEditTable.Controls
                            If TypeOf EachControl Is ThickItemEdit Then
                                tlpThicknessEditTable.Controls.Remove(EachControl)
                            End If
                        Next
                        SetShowControl.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
                        tlpThicknessEditTable.SetRow(SetShowControl, 0)
                        tlpThicknessEditTable.SetColumn(SetShowControl, 1)
                        tlpThicknessEditTable.Controls.Add(SetShowControl)
                        SetShowControl.Visible = True
                End Select

            Case Else
        End Select

    End Sub
#End Region

#Region "顯示頁次 屬性:ShowPageNumber"
    Private _ShowPageNumber As Integer = 1
    ''' <summary>
    ''' 顯示頁次
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ShowPageNumber As Integer
        Get
            Return _ShowPageNumber
        End Get
        Set(value As Integer)
            Select Case True
                Case TabControl1.SelectedTab Is tpBugEdit
                    Dim PageContinerCount As Integer = tlpItems.RowCount * tlpItems.ColumnCount
                    Dim MaxNumber As Integer = QABugRecordShowControls.Count \ PageContinerCount + IIf(QABugRecordShowControls.Count Mod PageContinerCount > 0, 1, 0)
                    MaxNumber = IIf(MaxNumber < 1, 1, MaxNumber)
                    _ShowPageNumber = IIf(value < 1, 1, value)
                    _ShowPageNumber = IIf(_ShowPageNumber > MaxNumber, MaxNumber, _ShowPageNumber)
                    lbPage.Text = "頁次: " & _ShowPageNumber & "/" & MaxNumber
                Case TabControl1.SelectedTab Is tpThicknessEdit
                    Dim PageContinerCount As Integer = tlpThicknessItems.RowCount * tlpThicknessItems.ColumnCount
                    Dim MaxNumber As Integer = QAThicknessRecordShowControls.Count \ PageContinerCount + IIf(QAThicknessRecordShowControls.Count Mod PageContinerCount > 0, 1, 0)
                    MaxNumber = IIf(MaxNumber < 1, 1, MaxNumber)
                    _ShowPageNumber = IIf(value < 1, 1, value)
                    _ShowPageNumber = IIf(_ShowPageNumber > MaxNumber, MaxNumber, _ShowPageNumber)
                    lbPage.Text = "頁次: " & _ShowPageNumber & "/" & MaxNumber
            End Select
        End Set
    End Property
#End Region
#Region "將捲抽捲至指定資料控制項位置 函式:ScrollToDataControl"
    ''' <summary>
    ''' 將捲抽捲至指定資料控制項位置
    ''' </summary>
    ''' <param name="ToControlData"></param>
    ''' <remarks></remarks>
    Public Sub ScrollToDataControl(ByVal ToControlData As QABugRecord)
        If IsNothing(ToControlData) Then
            Exit Sub
        End If

        '將Scrollbar導向剛才編修之資料
        Dim flpItemContainer As FlowLayoutPanel = Nothing
        For Each EachItem As Control In tlpItems.Controls
            If TypeOf EachItem Is FlowLayoutPanel Then
                flpItemContainer = EachItem : Exit For
            End If
        Next
        If Not IsNothing(flpItemContainer) Then
            Dim ScrollToControl As Control = Nothing
            For Each EachItem As BugItemMinDisplay In QABugRecordShowControls
                If EachItem.QABugRecordData.EditEmployeeID.Trim = ToControlData.EditEmployeeID.Trim AndAlso _
                    EachItem.QABugRecordData.CoilNumber.Trim = ToControlData.CoilNumber.Trim AndAlso _
                    EachItem.QABugRecordData.DataDate = ToControlData.DataDate AndAlso _
                    EachItem.QABugRecordData.StationName.Trim = ToControlData.StationName.Trim AndAlso _
                    EachItem.QABugRecordData.Version.Trim = ToControlData.Version.Trim AndAlso _
                    EachItem.QABugRecordData.DataCreateTime = ToControlData.DataCreateTime Then
                    ScrollToControl = EachItem : Exit For
                End If
            Next
            If Not IsNothing(ScrollToControl) Then
                flpItemContainer.VerticalScroll.Value = flpItemContainer.VerticalScroll.Maximum
                flpItemContainer.ScrollControlIntoView(ScrollToControl)
            End If
        End If
    End Sub
#End Region

#Region "L2訊號配接器 屬性/事件:L2OPCUAAdapter/L2OPCUAAdapterEvent"
    WithEvents L2OPCUAAdapterEvent As OPCUAAdapter
    Private _L2OPCUAAdapter As OPCUAAdapter
    Public Property L2OPCUAAdapter() As OPCUAAdapter
        Get
            If IsNothing(L2OPCUAAdapterEvent) Then
                Try
                    _L2OPCUAAdapter = New OPCUAAdapter(Me, "opc.tcp://10.12.6.30:49320")
                    If _L2OPCUAAdapter.ConnectOPCServer() = False Then
                        lbMessage.Text = "L2 設備訊號無法連線成功,無法取得訊號資料!"
                    Else
                        lbMessage.Text = "L2 設備訊號連線成功!"
                    End If
                Catch ex As Exception
                    lbMessage.Text = "L2 設備訊號連線失敗,無法取得訊號資料!"
                End Try
            End If
            L2OPCUAAdapterEvent = _L2OPCUAAdapter
            Return _L2OPCUAAdapter
        End Get
        Set(ByVal value As OPCUAAdapter)
            _L2OPCUAAdapter = value
        End Set
    End Property
#End Region
#Region "APL1鋼捲位置 屬性:APL1CoilPosition"
    Private _APL1CoilPosition As Long
    Public Property APL1CoilPosition() As Long
        Get
            Return _APL1CoilPosition
        End Get
        Private Set(ByVal value As Long)
            _APL1CoilPosition = value
        End Set
    End Property
#End Region
#Region "APL2鋼捲位置 屬性:APL2CoilPosition"
    Private _APL2CoilPosition As Long
    Public Property APL2CoilPosition() As Long
        Get
            Return _APL2CoilPosition
        End Get
        Private Set(ByVal value As Long)
            _APL2CoilPosition = value
        End Set
    End Property
#End Region
#Region "BAL鋼捲位置 屬性:BALCoilPosition"
    Private _BALCoilPosition As Long
    Public Property BALCoilPosition() As Long
        Get
            Return _BALCoilPosition
        End Get
        Private Set(ByVal value As Long)
            _BALCoilPosition = value
        End Set
    End Property
#End Region
#Region "鋼捲收捲狀態(ADD NEW)屬性:BALCoilPosition"
    Private _coilUpDown_Status As String
    Public Property coilUpDown_Status() As String
        Get
            Return _coilUpDown_Status
        End Get
        Private Set(ByVal value As String)
            _coilUpDown_Status = value
        End Set
    End Property
#End Region
#Region "鋼捲收捲方式 屬性:CoilReceiveType"
    ''' <summary>
    ''' 鋼捲收捲方式(1上收0下收)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CoilReceiveType As Integer = -1
#End Region
#Region "開始連線L2之OPCServer並取得資料 函式:StartUseOPCServerGetData "
    Private Sub StartUseOPCServerGetData()
        L2OPCUAAdapter.AddOPCItem("ns=2;s=APL1.CLX.Global.AP1_Length", Type.GetType("Integer"))
        L2OPCUAAdapter.AddOPCItem("ns=2;s=APL2.CLX.Global.AP2_Length", Type.GetType("Integer"))
        L2OPCUAAdapter.AddOPCItem("ns=2;s=BAL.CLX.Global.BAL_Length", Type.GetType("Integer"))

        L2OPCUAAdapter.AddOPCItem("ns=2;s=APL1.CLX.Global.L2_TR_OVER", Type.GetType("Integer"))
        L2OPCUAAdapter.AddOPCItem("ns=2;s=APL2.CLX.Global.L2_TR_OVER", Type.GetType("Integer"))
        L2OPCUAAdapter.AddOPCItem("ns=2;s=BAL.CLX.Global.L2_TR_OVER", Type.GetType("Integer"))

        'If {"APL1", "APL2"}.Contains(Me.CanEditStationLine) Then
        '    L2OPCUAAdapter.AddOPCItem("ns=2;s=APL1.CLX.Global.L2_TR_OVER", Type.GetType("Integer"))
        '    L2OPCUAAdapter.AddOPCItem("ns=2;s=APL2.CLX.Global.L2_TR_OVER", Type.GetType("Integer"))
        'End If
        L2OPCUAAdapter.OPCItemSubscribt()
    End Sub

    Private Sub L2OPCUAAdapterEvent_DAServerStateChanged(clientHandle As Integer, state As Kepware.ClientAce.OpcDaClient.ServerState) Handles L2OPCUAAdapterEvent.DAServerStateChanged
        Select Case True
            Case state = Kepware.ClientAce.OpcDaClient.ServerState.CONNECTED
                Me.lbMessage.Text = "L2訊號連線正常!"
            Case state = Kepware.ClientAce.OpcDaClient.ServerState.DISCONNECTED
                Me.lbMessage.Text = "L2訊號中斷連線,無法取得鋼捲位置!"
            Case Else
                Me.lbMessage.Text = "L2訊號連線異常,無法取得鋼捲位置!"
        End Select
    End Sub


    Private Sub L2OPCUAAdapterEvent_SubscriptionReaded(allQualitiesGood As Boolean, noErrors As Boolean, AllValues As Dictionary(Of Integer, OPCUAAdapter.OPCItemSubscribeDefine)) Handles L2OPCUAAdapterEvent.SubscriptionReaded
        Try
            mut.WaitOne()

            If IsCanWorkDataReady = False Then
                Exit Sub
            End If
            Dim ShowPosition As String
            If allQualitiesGood = False Then
                lbCoilPosition.Text = "資料載取有錯誤發生!"
            End If

            '鋼捲位置
            If AllValues(1).OPCReturnValue.Quality.IsGood Then
                APL1CoilPosition = Val(AllValues(1).OPCReturnValue.Value + Me.CoilOtherInfoControl.CoilPositionErrLength)
                If APL1CoilPosition < 0 Then
                    APL1CoilPosition = 0
                End If
            Else
                APL1CoilPosition = 0
            End If
            If AllValues(2).OPCReturnValue.Quality.IsGood Then
                APL2CoilPosition = Val(AllValues(2).OPCReturnValue.Value + Me.CoilOtherInfoControl.CoilPositionErrLength)
                If APL2CoilPosition < 0 Then
                    APL2CoilPosition = 0
                End If
            Else
                APL2CoilPosition = 0
            End If
            If AllValues(3).OPCReturnValue.Quality.IsGood Then
                BALCoilPosition = Val(AllValues(3).OPCReturnValue.Value + Me.CoilOtherInfoControl.CoilPositionErrLength)
                If BALCoilPosition < 0 Then
                    BALCoilPosition = 0
                End If
            Else
                BALCoilPosition = 0
            End If

            '鋼捲上下收(非0上收0下收)  儀器接收訊號
            'Select Case True
            '    Case Me.CanEditStationLine = "APL1" AndAlso AllValues.Count > 3 AndAlso AllValues(4).OPCReturnValue.Quality.IsGood
            '        CoilReceiveType = Val(AllValues(4).OPCReturnValue.Value)
            '    Case Me.CanEditStationLine = "APL2" AndAlso AllValues.Count > 4 AndAlso AllValues(5).OPCReturnValue.Quality.IsGood

            '        'original
            '        'CoilReceiveType = Val(AllValues(5).OPCReturnValue.Value)
            '        CoilReceiveType = -1

            '        If AllValues(5).OPCReturnValue.Value = True Then
            '            CoilReceiveType = -1
            '        Else
            '            CoilReceiveType = 0
            '        End If

            '    Case Me.CanEditStationLine = "BAL" AndAlso AllValues.Count > 5 AndAlso AllValues(6).OPCReturnValue.Quality.IsGood
            '        CoilReceiveType = Val(AllValues(6).OPCReturnValue.Value)
            'End Select


            ''106/08/10 ADD
            ''品管反應儀器上下收不准，依照使用者來決定上下收狀態
            Dim upDownType As String = ""
            ''Me.CoilOtherInfoControl.getUpDown_Status(upDownType)
            ''106/08/29 ADD
            If radBtn_UP.Checked = True And radBtn_Down.Checked = False Then
                upDownType = "上收"
            ElseIf radBtn_UP.Checked = False And radBtn_Down.Checked = True Then
                upDownType = "下收"
            Else
                upDownType = "none"
            End If

            coilUpDown_Status = upDownType

            If upDownType = "上收" Then
                CoilReceiveType = -1
            ElseIf upDownType = "下收" Then
                CoilReceiveType = 0
            Else
                CoilReceiveType = 1
            End If




            If Not IsNothing(BugItemEditControl) Then
                Select Case True
                    Case CurrentEditStationLine = "APL1"
                        Me.lbTitlePosition.Text = "米數:" & APL1CoilPosition
                        BugItemEditControl.ShowPositionAndCoilReceiveType(APL1CoilPosition, CoilReceiveType)
                        If APL1CoilPosition > 20 Then
                            Me.BeforeChangCoilMaxLength = APL1CoilPosition
                            Me.BeforeChangeCoilReceiveType = CoilReceiveType
                        End If
                    Case CurrentEditStationLine = "APL2"
                        Me.lbTitlePosition.Text = "米數:" & APL2CoilPosition
                        BugItemEditControl.ShowPositionAndCoilReceiveType(APL2CoilPosition, CoilReceiveType)
                        If APL2CoilPosition > 20 Then
                            Me.BeforeChangCoilMaxLength = APL2CoilPosition
                            Me.BeforeChangeCoilReceiveType = CoilReceiveType
                        End If
                    Case CurrentEditStationLine = "BAL"
                        Me.lbTitlePosition.Text = "米數:" & BALCoilPosition
                        BugItemEditControl.ShowPositionAndCoilReceiveType(BALCoilPosition, CoilReceiveType)
                        If BALCoilPosition > 20 Then
                            Me.BeforeChangCoilMaxLength = BALCoilPosition
                            Me.BeforeChangeCoilReceiveType = CoilReceiveType
                        End If
                    Case Else
                        Me.lbTitlePosition.Text = "米數:0"
                End Select
            End If

            Dim CoilReceiveString As String
            Select Case CoilReceiveType
                Case 0
                    CoilReceiveString = "本線" & Me.CanEditStationLine & "下收"
                Case -1
                    CoilReceiveString = "本線" & Me.CanEditStationLine & "上收"
                Case Else
                    CoilReceiveString = "本線" & Me.CanEditStationLine
            End Select
            ShowPosition = APL1CoilPosition
            ShowPosition &= "/" & APL2CoilPosition
            ShowPosition &= "/" & BALCoilPosition
            lbCoilPosition.Text = ShowPosition & " " & CoilReceiveString

        Catch ex As Exception
        Finally
            mut.ReleaseMutex()
        End Try


    End Sub
#End Region

#Region "定時關閉授權視窗程式碼 (停用)"
    '    Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
    '    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    '        Dim NewThread As New Threading.Thread(AddressOf SendKeyForPrintWindow)
    '        NewThread.Priority = Threading.ThreadPriority.Highest
    '        NewThread.Start()
    '    End Sub

    '#Region "傳送Enter指令至列印視窗 方法:SendKeyForPrintWindow"
    '    ''' <summary>
    '    ''' 傳送Enter指令至列印視窗
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    Private Sub SendKeyForPrintWindow(Optional ByVal DelayMilliSeconds As Double = 100)
    '        Dim hWnd As Integer
    '        For PrintTimes As Integer = 1 To 5
    '            Threading.Thread.Sleep(DelayMilliSeconds)
    '            hWnd = FindWindow(vbNullString, "Demo Mode")
    '            If hWnd Then
    '                SendKeys.SendWait("%{F4}")
    '                Exit Sub
    '            End If
    '        Next
    '    End Sub
    '#End Region

#End Region

#Region "品管快速輸入所有資料 屬性:AllQAQuickInputGroupDatas"
    Private _AllQAQuickInputGroupDatas As List(Of QAQuickInputGroup)
    ''' <summary>
    ''' 品管快速輸入所有資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property AllQAQuickInputGroupDatas As List(Of QAQuickInputGroup)
        Get
            If IsNothing(_AllQAQuickInputGroupDatas) Then
                _AllQAQuickInputGroupDatas = QAQuickInputGroup.AllQAQuickInputGroupDatas
            End If
            Return _AllQAQuickInputGroupDatas
        End Get
    End Property
#End Region
#Region "載入品管快速輸入按鈕至快速輸入區 函式:LoadQuickInputButtonToArea"
    ''' <summary>
    ''' 載入品管快速輸入按鈕至快速輸入區
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadQuickInputButtonToArea()
        For Each EachButton As Button In flpQuickOperator.Controls
            RemoveHandler EachButton.Click, AddressOf InsertBugClick
        Next
        flpQuickOperator.Controls.Clear()
        Dim QuickInputDatas As List(Of QAQuickInputGroup) = (From A In AllQAQuickInputGroupDatas Where A.StationName.Trim = Me.EditStationName.Trim And A.GroupNumber > 0 Select A).ToList
        For Each EachGroupNumber As String In (From A In QuickInputDatas Order By A.SortNumber Select A.GroupNumber).Distinct
            Dim SetButtonText As String = (From A In QuickInputDatas Where Not String.IsNullOrEmpty(A.GroupName) AndAlso A.GroupName.Trim.Length > 0 And A.GroupNumber = EachGroupNumber Order By A.SortNumber Select A.GroupName).First
            Dim NewButton As New Button
            With NewButton
                .Text = Trim(IIf(String.IsNullOrEmpty(SetButtonText), "快速輸入群" & EachGroupNumber, SetButtonText))
                .Width = 200
                .Height = 40
                .Tag = EachGroupNumber
                .TextAlign = ContentAlignment.MiddleCenter
                .Cursor = Cursors.Hand
                AddHandler .Click, AddressOf InsertBugClick
            End With
            flpQuickOperator.Controls.Add(NewButton)
        Next
    End Sub

    Private Sub InsertBugClick(sender As Object, e As EventArgs)
        If Me.CanEditStationLine <> Me.CurrentEditStationLine Then
            Exit Sub
        End If
        Dim PushButton As Button = sender
        InsertQABugRecords(Me.EditStationName, PushButton.Tag)
        Me.TabControl1.SelectedTab = tpBugEdit

    End Sub
#End Region
#Region "新增缺陷資料 函式:InsertQABugRecords"
    Private Shared mut1 As New Mutex()

    ''' <summary>
    ''' 新增缺陷資料
    ''' </summary>
    ''' <param name="InsertDatas"></param>
    ''' <remarks></remarks>
    Private Sub InsertQABugRecords(ByVal InsertDatas As List(Of QAQuickInputGroup))
        If Me.CurrentEditStationLine <> Me.CanEditStationLine Then
            Exit Sub
        End If
        '取得所有資料最後一筆的儲存時間
        mut1.WaitOne()
        Try
            Dim LastSaveTime As DateTime
            For Each EachItem As BugItemMinDisplay In Me.QABugRecordShowControls
                If EachItem.QABugRecordData.DataCreateTime > LastSaveTime Then
                    LastSaveTime = EachItem.QABugRecordData.DataCreateTime
                End If
            Next
            LastSaveTime = IIf(LastSaveTime < Now, Now, LastSaveTime)


            ''106/08/10 ADD
            ''取得鋼捲厚度頁籤的5筆長度資料
            'Dim QAThick As String() = returnQAThick_Item().ToString.Split(",")
            'Dim times_138 As Integer = 1


            Dim InsertTimes As Integer = 1
            For Each EachItem As QAQuickInputGroup In InsertDatas
                If EachItem.StationName.Trim <> Me.CurrentEditStationLine.Trim Then
                    Continue For
                End If

                Dim QuickInsertObject As QABugRecord = New QABugRecord   ''單筆缺陷資料
                With QuickInsertObject
                    .CoilNumber = EditCoilNumber
                    .OutCoilNumber = CurrentEditQABugRecordTitle.OutCoilNumber
                    .Version = EditDataDateVersion
                    .EditEmployeeID = LoginID
                    .DataDate = EditDataDate
                    .StationName = EditStationName
                    .DataCreateTime = LastSaveTime.AddSeconds(InsertTimes)
                    .QABug_Number = EachItem.QABug_Number
                    .Degree = EachItem.Degree
                    .StartPosition = EachItem.StartPosition
                    .EndPosition = EachItem.EndPosition

                    ''增設快組1功能為，取得鋼捲厚度頁籤的後4筆長度資料，寫回預設9999長度
                    '(138,238)為一組，index由4到11
                    'If QAThick(0) <> "" Then
                    '    If EachItem.GroupName.Trim = "快組1" And EachItem.StationName.Trim = "BAL" And EachItem.GroupNumber = 22 Then
                    '        If EachItem.QABug_Number.Trim = "138" Or EachItem.QABug_Number.Trim = "238" Then
                    '            If times_138 >= 4 And times_138 <= 11 Then        ''忽略前2筆138、238資料，根據[dbo].[QAQuickInputGroup]的SortNumber來做Index判斷
                    '                Dim index_group As Integer = Math.Floor(IIf(times_138 Mod 2 = 0, times_138 / 2 - 1, (times_138 - 1) / 2 - 1))

                    '                QuickInsertObject.StartPosition = QAThick(index_group) + 40
                    '                QuickInsertObject.EndPosition = QAThick(index_group) + 40
                    '            End If
                    '        End If
                    '    End If
                    'End If
                    .DPositionType = EachItem.DPositionType
                    .DPositionStart = EachItem.DPositionStart
                    .DPositionEnd = EachItem.DPositionEnd
                    .Density = EachItem.Density
                    .CoilMaxLength = CoilMaxLength
                    .PosOrNeg = EachItem.PosOrNeg
                    .CDBSave()
                End With


                'times_138 += 1
                InsertTimes += 1
            Next
        Catch ex As Exception
            mut1.ReleaseMutex()
            Throw ex
        Finally
            mut1.ReleaseMutex()
        End Try
    End Sub
    Private Sub InsertQABugRecords(ByVal StationName As String, ByVal GroupNumber As Integer)
        If String.IsNullOrEmpty(StationName) AndAlso Me.CanEditStationLine <> StationName Then
            Exit Sub
        End If
        InsertQABugRecords((From A In Me.AllQAQuickInputGroupDatas Where A.StationName.Trim = StationName.Trim And A.GroupNumber = GroupNumber Select A).ToList)
    End Sub
#End Region


#Region "執行下一個輸入階段 函式:GoRunNextInputProcess"
    ''' <summary>
    ''' 執行下一個輸入階段
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub GoRunNextInputProcess()
        If String.IsNullOrEmpty(LoginID) OrElse LoginID.Trim.Length = 0 OrElse _
           String.IsNullOrEmpty(CanEditStationLine) OrElse CanEditStationLine.Trim.Length = 0 Then
            Call tbLogin_Click(Nothing, Nothing) : Exit Sub
        End If

        If String.IsNullOrEmpty(EditOutCoilNumber) OrElse EditOutCoilNumber.Trim.Length = 0 Then
            Dim GetFile As L2Message1 = L2MessageWatchControl.ManualGetFileInfo()
            If Not IsNothing(GetFile) Then
                With GetFile
                    Me.EditCoilNumber = .CoilFullNumber
                    Me.EditOutCoilNumber = .OutCoilFullNumber
                    AutoSetNowDataDateAndLaseVersion()
                End With
                ValidCanEditCoilFullNumberIsOnLineCoilFullNumber(True)  '驗證是否為目前線上正在生產鋼捲
            Else
                Call btnCoilNumber_Click(Nothing, Nothing) : Exit Sub
            End If
        End If

        If IsNothing(EditDataDate) Then
            Call btnDataDate_Click(Nothing, Nothing) : Exit Sub
        End If

        Select Case True
            Case CanEditStationLine = "APL1"
                Call ReloadQABugRecordTitleData()
                If Not IsNothing(Me.CurrentEditQABugRecordTitle) Then
                    Me.CoilOtherInfoControl.InitControlValue()
                End If
                rbAPL1.Select()
                Call rbAPL1_MouseUp(rbAPL1, Nothing)
                AddNewEditBugORThickRecord()
            Case CanEditStationLine = "APL2"
                Call ReloadQABugRecordTitleData()
                If Not IsNothing(Me.CurrentEditQABugRecordTitle) Then
                    Me.CoilOtherInfoControl.InitControlValue()
                End If
                rbAPL2.Select()
                Call rbAPL1_MouseUp(rbAPL2, Nothing)
                AddNewEditBugORThickRecord()
            Case CanEditStationLine = "BAL"
                Call ReloadQABugRecordTitleData()
                If Not IsNothing(Me.CurrentEditQABugRecordTitle) Then
                    Me.CoilOtherInfoControl.InitControlValue()
                End If
                rbBAL.Select()
                Call rbAPL1_MouseUp(rbBAL, Nothing)
                AddNewEditBugORThickRecord()
        End Select
    End Sub
#End Region
#Region "新增一筆可編輯之缺陷或厚度資料 函式:AddNewEditBugORThickRecord"
    ''' <summary>
    ''' 新增一筆可編輯之缺陷或厚度資料
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddNewEditBugORThickRecord()
        '新增一筆 缺陷資料/厚度資料 做為編輯

        '檢核是否資料完備才可自動啟動新增作業
        Select Case True
            Case String.IsNullOrEmpty(LoginID) OrElse LoginID.Trim.Length = 0 OrElse _
                String.IsNullOrEmpty(CanEditStationLine) OrElse CanEditStationLine.Trim.Length = 0
                Exit Sub
            Case String.IsNullOrEmpty(EditCoilNumber) OrElse EditCoilNumber.Trim.Length = 0
                Exit Sub
            Case IsNothing(EditDataDate)
                Exit Sub
            Case CanEditStationLine <> CurrentEditStationLine
                Exit Sub
            Case Else
        End Select

        If IsNothing(CurrentEditQABugRecordTitle) Then
            ReloadQABugRecordTitleData()
        End If






        Select Case True
            Case TabControl1.SelectedTab Is tpBugEdit
                Dim SetData As QABugRecord = New QABugRecord
                With SetData
                    .CoilNumber = Me.EditCoilNumber
                    .DataDate = Me.EditDataDate
                    .Version = Me.EditDataDateVersion
                    .OutCoilNumber = CurrentEditQABugRecordTitle.OutCoilNumber
                    .StationName = Me.CurrentEditStationLine
                    .EditEmployeeID = Me.LoginID
                    Select Case True
                        Case Me.CanEditStationLine = "APL1" AndAlso APL1CoilPosition > 0
                            .StartPosition = APL1CoilPosition
                        Case Me.CanEditStationLine = "APL2" AndAlso APL2CoilPosition > 0
                            .StartPosition = APL2CoilPosition
                        Case Me.CanEditStationLine = "BAL" AndAlso BALCoilPosition > 0
                            .StartPosition = BALCoilPosition
                        Case Else
                            .StartPosition = 1
                    End Select
                    .DPositionType = 1
                    .EndPosition = Me.CoilMaxLength
                    .CoilMaxLength = Me.CoilMaxLength
                    .DPositionStart = 1
                    .DPositionEnd = 1
                    Try
                        .DataCreateTime = CompanyORMDB.DeviceInformation.GetSQLServerTime(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m)
                    Catch ex As Exception
                        .DataCreateTime = Now
                    End Try
                    '確保新增之資料時間至少為所有資料最後一筆的儲存時間+1秒
                    Try
                        .DataCreateTime = CompanyORMDB.DeviceInformation.GetSQLServerTime(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m)
                    Catch ex As Exception
                        .DataCreateTime = Now
                    End Try
                    For Each EachItem As BugItemMinDisplay In Me.QABugRecordShowControls
                        If EachItem.QABugRecordData.DataCreateTime > .DataCreateTime Then
                            .DataCreateTime = EachItem.QABugRecordData.DataCreateTime.AddSeconds(1)
                        End If
                    Next
                End With
                With Me.BugItemEditControl
                    .ControlDataProcessMode = BugItemEdit.ControlDataProcessModeEnum.InsertMode
                    .EditQABugRecord = SetData
                    .Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
                End With
                ShowControlToFullEditArea(Me.BugItemEditControl)
                Me.BugItemEditControl.ShowCoilInformation(Me.EditCoilNumber)
                Me.BugItemEditControl.SendButtonCommand(BugItemEdit.ButtonTypeEnum.BugNumberButton)
            Case TabControl1.SelectedTab Is tpThicknessEdit
                Dim ALLQAThicknessDatas As List(Of QAThickness) = (From A In QAThicknessRecordShowControls Select CType(A, ThickItemMinDisplay).QAThicknessRecordData).ToList
                Dim LastInputData As QAThickness = (From A In ALLQAThicknessDatas Order By A.DataCreateTime Descending Select A).FirstOrDefault


                ''紀錄目前QAThickData
                tempQAThick = ALLQAThicknessDatas


                Dim SetData As QAThickness = New QAThickness
                With SetData
                    .CoilNumber = Me.EditCoilNumber
                    .DataDate = Me.EditDataDate
                    .Version = Me.EditDataDateVersion
                    .OutCoilNumber = CurrentEditQABugRecordTitle.OutCoilNumber
                    .StationName = Me.CurrentEditStationLine
                    .EditEmployeeID = Me.LoginID
                    Select Case True
                        Case Me.CanEditStationLine = "APL1" AndAlso APL1CoilPosition > 0
                            .Length = APL1CoilPosition
                        Case Me.CanEditStationLine = "APL2" AndAlso APL2CoilPosition > 0
                            .Length = APL2CoilPosition
                        Case Me.CanEditStationLine = "BAL" AndAlso BALCoilPosition > 0
                            .Length = BALCoilPosition
                        Case Else
                            .Length = 1
                    End Select
                    If Not IsNothing(LastInputData) Then
                        .Width = LastInputData.Width
                        .Thick = LastInputData.Thick
                        .Thick60 = LastInputData.Thick60
                    Else
                        .Width = 1
                        .Thick = 1
                    End If
                    '確保新增之資料時間至少為所有資料最後一筆的儲存時間+1秒
                    Try
                        .DataCreateTime = CompanyORMDB.DeviceInformation.GetSQLServerTime(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m)
                    Catch ex As Exception
                        .DataCreateTime = Now
                    End Try
                    For Each EachItem As ThickItemMinDisplay In Me.QAThicknessRecordShowControls
                        If EachItem.QAThicknessRecordData.DataCreateTime > .DataCreateTime Then
                            .DataCreateTime = EachItem.QAThicknessRecordData.DataCreateTime.AddSeconds(1)
                        End If
                    Next
                    If .Width = 1 And .Thick = 1 Then
                        '找尋前一線鋼捲資料並預設厚度及寬度
                        'GetPreStationSetWidthAndThick(SetData)
                        Dim myAboutPPSBLAPF As CompanyORMDB.PPS100LB.PPSBLAPF = Me.CurrentEditQABugRecordTitle.AboutPPSBLAPF
                        If Not IsNothing(myAboutPPSBLAPF) Then
                            .Thick = myAboutPPSBLAPF.BLA03
                            .Thick60 = .Thick
                            .Width = myAboutPPSBLAPF.BLA04
                        End If
                    End If
                End With
                With Me.ThicknessEditControl
                    .EditQAThickness = SetData
                    .Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
                End With
                ShowControlToFullEditArea(Me.ThicknessEditControl)
                Me.ThicknessEditControl.ControlDataProcessMode = ThickItemEdit.ControlDataProcessModeEnum.InsertMode
                'Case TabControl1.SelectedTab Is tpBrightnessEdit
            Case Else
        End Select
        Me.RefreshAllEnableControl()
    End Sub

#End Region

#Region "是否為線上正式機器 屬性:IsOnLineMachine"
    ''' <summary>
    ''' 是否為線上正式機器
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''debug
    ReadOnly Property IsOnLineMachine As Boolean
        Get
            Dim TheDeviceIIP As String = CompanyORMDB.DeviceInformation.GetLocalIPs(0)
            If String.IsNullOrEmpty(TheDeviceIIP) Then
                Return False
            End If
            Dim DeviceIPArray() As String = TheDeviceIIP.Split(".")
            If DeviceIPArray(0).Trim = "10" AndAlso DeviceIPArray(1).Trim = "12" Then
                Return True
            End If
            Return False
        End Get
    End Property
#End Region
#Region "L2訊號監控元件 屬性/事件:L2MessageWatchControl"
    WithEvents L2MessageWatchControlEvent As ReceiveL2Message
    Private _L2MessageWatchControl As ReceiveL2Message
    ''' <summary>
    ''' L2訊號監控元件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property L2MessageWatchControl() As ReceiveL2Message
        Get
            If IsNothing(_L2MessageWatchControl) AndAlso Not String.IsNullOrEmpty(Me.CanEditStationLine) AndAlso Me.CanEditStationLine.Trim.Length >= 3 Then
                'debug
                'Dim TestModePath As String = IIf(IsOnLineMachine, Nothing, "_Test")

                Dim TestModePath As String = Nothing


                'test
                If IsOnLineMachine Then
                    TestModePath = Nothing
                Else
                    TestModePath = "_Test"
                End If


                If {"SBL", "TLL", "SPL", "CPL1", "CPL2", "GPL1", "GPL2", "APL1", "APL2", "BAL", "ZML1", "ZML2", "ZML3"} _
                    .Contains(Me.CanEditStationLine.PadRight(4).Substring(0, 4).Trim) Then
                    Dim LineName As String = Me.CanEditStationLine.PadRight(4).Substring(0, 4).Trim
                    _L2MessageWatchControl = New ReceiveL2Message("//10.12.6.30/" & LineName & TestModePath & "/received/" & LineName & ".txt")


                    'Debug.WriteLine(" L2Message    FULL  PATH:       " + _L2MessageWatchControl.FileFullPath)
                    'Debug.WriteLine(" temp         FULL  PATH:       " + temp.FileFullPath)
                End If

                L2MessageWatchControlEvent = _L2MessageWatchControl
            End If
            Return _L2MessageWatchControl
        End Get
        Set(value As ReceiveL2Message)
            _L2MessageWatchControl = value
        End Set
    End Property

#End Region
#Region "接收處理L2訊號 方法/委派:ProcessL2Message/ProcessL2MessageAndUpdateUI"
    Private Shared mut As New Mutex()
    Private Delegate Sub ProcessL2MessageAndUpdateUI(L2Message As L2Message1)
    ''' <summary>
    ''' 接收處理L2訊號
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ProcessL2Message(ByVal L2Message As L2Message1)
        Me.Enabled = False
        mut.WaitOne()
        Try
            Select Case True
                Case Me.IsCanWorkDataReady = False
                    Exit Sub
                Case L2Message.Status <> L2Message1.StatusEnum.RUNNING
                    Exit Sub
                Case L2Message.StatusOrder <> 1
                    Exit Sub
                Case L2Message.LineName.PadRight(3) = "BAL" AndAlso Me.CanEditStationLine.Trim <> L2Message.LineName.PadRight(3).Trim.Substring(0, 3)
                    Exit Sub
                Case L2Message.LineName.PadRight(3) = "APL" AndAlso Me.CanEditStationLine.Trim <> L2Message.LineName.PadRight(4).Trim.Substring(0, 4)
                    Exit Sub
                Case String.IsNullOrEmpty(L2Message.CoilFullNumber) OrElse String.IsNullOrEmpty(L2Message.OutCoilFullNumber)
                    Exit Sub
                Case Me.EditCoilNumber.Trim = L2Message.CoilFullNumber.Trim AndAlso Me.EditOutCoilNumber.Trim = L2Message.OutCoilFullNumber.Trim
                    Exit Sub
            End Select

            'Dim OldEditCoilFullNumber As String
            'Dim OldEditOutCoilFullNumber As String
            'OldEditCoilFullNumber = Me.EditCoilNumber.Trim
            'OldEditOutCoilFullNumber = Me.EditOutCoilNumber

            Dim ChangeCoilNumberArgs As New List(Of String)
            Select Case True
                Case Me.EditCoilNumber.Trim <> L2Message.CoilFullNumber.Trim    '新鋼捲上線
                    SaveAllControlDataToDB()
                    BeforeChangCoilL2MessageSave() '切換鋼捲前最終L2訊息存儲
                    'Print(Me.EditCoilNumber, Me.EditOutCoilNumber, Me.EditDataDate, Me.CanEditStationLine, Me.EditDataDateVersion)
                    Me.EditCoilNumber = L2Message.CoilFullNumber.Trim
                    Me.EditOutCoilNumber = L2Message.OutCoilFullNumber.Trim
                    AutoSetNowDataDateAndLaseVersion(False) '
                    Me.GoRunNextInputProcess()

                Case Me.EditCoilNumber.Trim = L2Message.CoilFullNumber.Trim AndAlso _
                    Me.EditCoilNumber.Trim = Me.EditOutCoilNumber AndAlso _
                    Me.EditOutCoilNumber <> L2Message.OutCoilFullNumber     '原鋼捲出現分捲狀況(本捲為第一捲)
                    'Me.CoilOtherInfoControl.SaveControlDataToDB()
                    'SaveAllControlDataToDB()
                    Me.TabControl1.SelectedTab = tpBugEdit
                    BeforeChangCoilL2MessageSave() '切換鋼捲前最終L2訊息存儲
                    'Print(Me.EditCoilNumber, Me.EditOutCoilNumber, Me.EditDataDate, Me.CanEditStationLine, Me.EditDataDateVersion)
                    ChangeCoilNumberArgs.Add(Me.EditCoilNumber.Trim)
                    ChangeCoilNumberArgs.Add(L2Message.CoilFullNumber.Trim)
                    ChangeCoilNumberArgs.Add(Me.EditOutCoilNumber.Trim)
                    ChangeCoilNumberArgs.Add(Me.EditOutCoilNumber.Trim & "A")
                    Me.QABugRecordShowControls.Clear()
                    Me.QAThicknessRecordShowControls.Clear()
                    Me.CoilOtherInfoControl = Nothing
                    Me.CurrentEditQABugRecordTitle = Nothing
                    Me.EditCoilNumber = L2Message.CoilFullNumber.Trim
                    Me.EditOutCoilNumber = L2Message.OutCoilFullNumber.Trim
                    AutoSetNowDataDateAndLaseVersion()
                    ChangeCoilNumberForLastUserEditVersion(ChangeCoilNumberArgs(0), ChangeCoilNumberArgs(1), ChangeCoilNumberArgs(2), ChangeCoilNumberArgs(3))
                    Me.GoRunNextInputProcess()

                Case Me.EditCoilNumber.Trim = L2Message.CoilFullNumber.Trim AndAlso _
                    Me.EditCoilNumber.Trim <> Me.EditOutCoilNumber AndAlso _
                    Me.EditOutCoilNumber.Trim <> L2Message.OutCoilFullNumber.Trim AndAlso _
                    Me.EditCoilNumber.Trim <> L2Message.OutCoilFullNumber.Trim    '原鋼捲出現分捲狀況(本捲為第二捲/第三捲....)
                    'Me.CoilOtherInfoControl.SaveControlDataToDB()
                    'SaveAllControlDataToDB()
                    Me.TabControl1.SelectedTab = tpBugEdit
                    BeforeChangCoilL2MessageSave() '切換鋼捲前最終L2訊息存儲
                    'Print(Me.EditCoilNumber, Me.EditOutCoilNumber, Me.EditDataDate, Me.CanEditStationLine, Me.EditDataDateVersion)
                    Me.QABugRecordShowControls.Clear()
                    Me.QAThicknessRecordShowControls.Clear()
                    Me.CoilOtherInfoControl = Nothing
                    Me.CurrentEditQABugRecordTitle = Nothing
                    Me.EditCoilNumber = L2Message.CoilFullNumber.Trim
                    Me.EditOutCoilNumber = L2Message.OutCoilFullNumber.Trim
                    AutoSetNowDataDateAndLaseVersion()
                    Me.GoRunNextInputProcess()

                Case Me.EditCoilNumber.Trim = L2Message.CoilFullNumber.Trim AndAlso _
                    Me.EditCoilNumber.Trim <> Me.EditOutCoilNumber.Trim AndAlso _
                    Me.EditCoilNumber.Trim = L2Message.OutCoilFullNumber.Trim      '原已分捲之鋼捲回復為未捲狀況
                    Me.TabControl1.SelectedTab = tpBugEdit
                    Me.QABugRecordShowControls.Clear()
                    Me.QAThicknessRecordShowControls.Clear()
                    Me.CoilOtherInfoControl = Nothing
                    Me.CurrentEditQABugRecordTitle = Nothing
                    Me.EditCoilNumber = L2Message.CoilFullNumber.Trim
                    Me.EditOutCoilNumber = L2Message.OutCoilFullNumber.Trim
                    ChangeCoilNumberForLastUserEditVersion(Me.EditCoilNumber, Me.EditCoilNumber, Me.EditOutCoilNumber & "A", Me.EditOutCoilNumber)
                    AutoSetNowDataDateAndLaseVersion()
                    Me.GoRunNextInputProcess()
            End Select
            ValidCanEditCoilFullNumberIsOnLineCoilFullNumber(True)  '驗證是否為目前線上正在生產鋼捲
            BeforeChangCoilMaxLength = 0
        Catch ex As Exception
            lbMessage.Text = "品管缺陷L2訊號接收後處理錯誤:" & ex.ToString

            Dim MailObject As New PublicClassLibrary.MISMail
            Dim SendBody As String
            With MailObject
                .ToMailAddress.Add(New MailAddress("kuku@mail.tangeng.com.tw", "古政剛"))
                SendBody = Me.EditCoilNumber & "接收資料" & L2Message.Message & vbNewLine & "錯誤訊息:" & ex.ToString
                SendBody &= vbNewLine & "ProcessL2Message 執行動作訊息:" & L2Message.Message
                .SendMail("軋鋼品管缺陷輸入訊號接收資料異常通知!", SendBody)

                .ToMailAddress.Add(New MailAddress("30355@mail.tangeng.com.tw", "龔泓璋"))
                SendBody = Me.EditCoilNumber & "接收資料" & L2Message.Message & vbNewLine & "錯誤訊息:" & ex.ToString
                SendBody &= vbNewLine & "ProcessL2Message 執行動作訊息:" & L2Message.Message
                .SendMail("軋鋼品管缺陷輸入訊號接收資料異常通知!", SendBody)
            End With
        Finally
            mut.ReleaseMutex()
            Me.Enabled = True
        End Try

        'ZML1,RUNNING,1,P7417,P7417A,0,1.4,960
        'ZML1,PRE-UP,1,P6672,P6672,0,0.49,960

        '欄位定義:
        'APL1=產線
        'RUNNING=狀態(RUNNING,PRE-UP,PRE-DOWN)
        '1= 狀態的順序(由靠近出至入口,由上到下)
        'P7417=原捲鋼捲編號
        'P7417A=輸出鋼捲編號
        '0=長度
        '1.4=厚度(TLL, CPL, GPL 產線實際值*1000)
        '960=寬度
    End Sub





#End Region
#Region "驗證可編修之鋼捲號碼是否為線上生產之鋼捲 函式:ValidCanEditCoilFullNumberIsOnLineCoilFullNumber"
    ''' <summary>
    ''' 驗證可編修之鋼捲號碼是否為線上生產之鋼捲
    ''' </summary>
    ''' <param name="WillRefreshStateAndMessage">是否要更新狀態與訊息</param>
    ''' <remarks></remarks>
    ''' Private sub ValidCanEditCoilFullNumberIsOnLineCoilFullNumber(Optional ByVal WillRefreshStateAndMessage As Boolean = True) As Boolean
    Private Sub ValidCanEditCoilFullNumberIsOnLineCoilFullNumber(Optional ByVal WillRefreshStateAndMessage As Boolean = True)

        Dim ReturnValue As Boolean = False

        If Not String.IsNullOrEmpty(EditCoilNumber) AndAlso Not String.IsNullOrEmpty(EditOutCoilNumber) Then    '讀取判斷

            Dim GetFile As L2Message1 = L2MessageWatchControl.ManualGetFileInfo()


            If Not IsNothing(GetFile) _
                AndAlso Not String.IsNullOrEmpty(GetFile.CoilFullNumber) _
                AndAlso Not String.IsNullOrEmpty(GetFile.OutCoilFullNumber) _
                AndAlso Not String.IsNullOrEmpty(Me.EditCoilNumber) _
                AndAlso Not String.IsNullOrEmpty(Me.EditOutCoilNumber) _
                AndAlso GetFile.OutCoilFullNumber.Trim = Me.EditOutCoilNumber.Trim Then
                ReturnValue = True

                'Debug.WriteLine("1.)a   EditCoilNumber>>  " + GetFile.OutCoilFullNumber)
                'Debug.WriteLine("1.)b   EditOutCoilNumber>>  " + Me.EditOutCoilNumber)
            Else
                ReturnValue = False


                'Debug.WriteLine("2.)a   EditCoilNumber>>  " + GetFile.OutCoilFullNumber)
                'Debug.WriteLine("2.)b   EditOutCoilNumber>>  " + Me.EditOutCoilNumber)


            End If
        Else

            'Debug.WriteLine("A.)a   EditCoilNumber>>  " + Me.EditCoilNumber)
            'Debug.WriteLine("A.)b   EditOutCoilNumber>>  " + Me.EditOutCoilNumber)

            ReturnValue = False
        End If


        'If WillRefreshStateAndMessage Then
        '    CanEditCoilFullNumberIsOnLineCoilFullNumberState = ReturnValue
        '    If CanEditCoilFullNumberIsOnLineCoilFullNumberState Then
        '        lbIsRunnCoilMessage.Text = "本鋼捲目前正在上線執行中!"
        '    Else
        '        lbIsRunnCoilMessage.Text = "本鋼捲非上線之鋼捲!"
        '    End If
        'End If
        If ReturnValue = True Then
            lbIsRunnCoilMessage.Text = "本鋼捲目前正在上線執行中!"
            CanEditCoilFullNumberIsOnLineCoilFullNumberState = True
        Else
            lbIsRunnCoilMessage.Text = "本鋼捲非上線之鋼捲!"
            CanEditCoilFullNumberIsOnLineCoilFullNumberState = False
        End If
        'Debug.WriteLine("--------------------------------------------------------------------")

        'Return ReturnValue

    End Sub
#End Region
#Region "可編修之鋼捲號碼是否為線上生產之鋼捲 屬性:CanEditCoilFullNumberIsOnLineCoilFullNumberState"
    Private _CanEditCoilFullNumberIsOnLineCoilFullNumberState As Boolean = False
    ''' <summary>
    ''' 可編修之鋼捲號碼是否為線上生產之鋼捲
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CanEditCoilFullNumberIsOnLineCoilFullNumberState() As Boolean
        Get
            Return _CanEditCoilFullNumberIsOnLineCoilFullNumberState
        End Get
        Private Set(ByVal value As Boolean)
            _CanEditCoilFullNumberIsOnLineCoilFullNumberState = value
        End Set
    End Property
#End Region
#Region "切換鋼捲前最終L2訊息存儲 函式:BeforeChangCoilStatusSave"
    ''' <summary>
    ''' 切換鋼捲前最終L2訊息存儲
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BeforeChangCoilL2MessageSave()
        'If Not IsNothing(Me.CurrentEditQABugRecordTitle) AndAlso BeforeChangCoilMaxLength > 100 AndAlso CanEditCoilFullNumberIsOnLineCoilFullNumberState Then
        If Not IsNothing(Me.CurrentEditQABugRecordTitle) AndAlso BeforeChangCoilMaxLength > 100 AndAlso CanEditCoilFullNumberIsOnLineCoilFullNumberState Then
            With Me.CurrentEditQABugRecordTitle
                .CoilMaxLength = BeforeChangCoilMaxLength '記錄鋼捲最終長度
                If .StationName.PadRight(4).Substring(0, 4) = "APL1" Then 'APL1要扣除導片長度儲存真正母片長度
                    .CoilMaxLength = .CoilMaxLength - Math.Abs(Me.CurrentEditQABugRecordTitle.JointLength)
                    If .CoilMaxLength < 0 Then
                        .CoilMaxLength = 0
                    End If
                    .CoilMaxAddJointLength = .CoilMaxLength + .JointLength * 2
                End If
                .CoilEndTime = System.DateTime.Now()
                .CoilReceiveType = BeforeChangeCoilReceiveType    '記錄上/下收捲
                .CDBSave()
            End With
        End If
    End Sub
#End Region
#Region "切換鋼捲前最終長度 屬性:BeforeChangCoilMaxLength"
    ''' <summary>
    ''' 切換鋼捲前最終長度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property BeforeChangCoilMaxLength As ULong
#End Region
#Region "切換鋼捲前最終收捲狀態 屬性:BeforeChangeCoilReceiveType"
    ''' <summary>
    ''' 切換鋼捲前最終收捲狀態(1上收0下收)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property BeforeChangeCoilReceiveType As Integer = 0
#End Region


#Region "鋼捲號碼變更For使用者最後編修版本 函式:ChangeCoilNumberForLastUserEditVersion"
    ''' <summary>
    ''' 鋼捲號碼變更For使用者最後編修版本
    ''' </summary>
    ''' <param name="OldCoilNumber"></param>
    ''' <param name="NewCoilNumber"></param>
    ''' <param name="OldOutCoilNumber"></param>
    ''' <param name="NewOutCoilNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ChangeCoilNumberForLastUserEditVersion(ByVal OldCoilNumber As String, ByVal NewCoilNumber As String, ByVal OldOutCoilNumber As String, ByVal NewOutCoilNumber As String) As Boolean
        Select Case True
            Case String.IsNullOrEmpty(OldCoilNumber)
                Return False
            Case String.IsNullOrEmpty(NewCoilNumber)
                Return False
            Case String.IsNullOrEmpty(OldOutCoilNumber)
                Return False
            Case String.IsNullOrEmpty(NewOutCoilNumber)
                Return False
        End Select
        Dim QryString As New System.Text.StringBuilder
        QryString.Append("Select * from QABugRecordTitle Where CoilNumber='" & OldCoilNumber.Trim & "' ")
        QryString.Append(" and OutCoilNumber = '" & OldOutCoilNumber.Trim & "' ")
        QryString.Append(" and StationName = '" & Me.CanEditStationLine.Trim & "' ")
        QryString.Append(" Order by DataDate desc , Version desc ")
        Dim SearchResult As List(Of QABugRecordTitle) = QABugRecord.CDBSelect(Of QABugRecordTitle)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString.ToString)
        Dim FindedQABugRecordTitle As QABugRecordTitle = Nothing
        If SearchResult.Count = 0 Then
            Return False
        Else
            FindedQABugRecordTitle = SearchResult(0)
            QryString.Clear()
            QryString.Append("Select * from QABugRecordTitle Where CoilNumber='" & NewCoilNumber.Trim & "' ")
            QryString.Append(" and OutCoilNumber = '" & NewOutCoilNumber.Trim & "' ")
            QryString.Append(" and StationName = '" & FindedQABugRecordTitle.StationName.Trim & "' ")
            QryString.Append(" and DataDate = '" & Format(FindedQABugRecordTitle.DataDate, "yyyy/MM/dd") & "' ")
            QryString.Append(" and Version = " & FindedQABugRecordTitle.Version & " ")
            SearchResult = QABugRecord.CDBSelect(Of QABugRecordTitle)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString.ToString)
            If SearchResult.Count > 0 Then  '資料庫已存在相同key值條件之資料所以無法將目前資料作轉換
                Return False
            End If
        End If
        Dim Adapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
        '變更缺陷資料
        QryString.Clear()
        QryString.Append("Update QABugRecord set CoilNumber='" & NewCoilNumber & "' , OutCoilNumber='" & NewOutCoilNumber & "' ")
        QryString.Append(" Where CoilNumber = '" & FindedQABugRecordTitle.CoilNumber & "'")
        QryString.Append(" and OutCoilNumber = '" & FindedQABugRecordTitle.OutCoilNumber & "'")
        QryString.Append(" and StationName = '" & FindedQABugRecordTitle.StationName & "'")
        QryString.Append(" and DataDate = '" & Format(FindedQABugRecordTitle.DataDate, "yyyy/MM/dd") & "'")
        QryString.Append(" and Version = " & FindedQABugRecordTitle.Version)
        Adapter.ExecuteNonQuery(QryString.ToString)

        '變更缺陷厚度資料
        QryString.Clear()
        QryString.Append("Update QAThickness set CoilNumber='" & NewCoilNumber & "' , OutCoilNumber='" & NewOutCoilNumber & "' ")
        QryString.Append(" Where CoilNumber = '" & FindedQABugRecordTitle.CoilNumber & "'")
        QryString.Append(" and OutCoilNumber = '" & FindedQABugRecordTitle.OutCoilNumber & "'")
        QryString.Append(" and StationName = '" & FindedQABugRecordTitle.StationName & "'")
        QryString.Append(" and DataDate = '" & Format(FindedQABugRecordTitle.DataDate, "yyyy/MM/dd") & "'")
        QryString.Append(" and Version = " & FindedQABugRecordTitle.Version)
        Adapter.ExecuteNonQuery(QryString.ToString)

        '變更缺陷台頭資訊
        QryString.Clear()
        QryString.Append("Update QABugRecordTitle set CoilNumber='" & NewCoilNumber & "' , OutCoilNumber='" & NewOutCoilNumber & "' ")
        QryString.Append(" , LastEditEmployeeID = '" & Me.LoginID.Trim & "'")
        QryString.Append(" Where CoilNumber = '" & FindedQABugRecordTitle.CoilNumber & "'")
        QryString.Append(" and OutCoilNumber = '" & FindedQABugRecordTitle.OutCoilNumber & "'")
        QryString.Append(" and StationName = '" & FindedQABugRecordTitle.StationName & "'")
        QryString.Append(" and DataDate = '" & Format(FindedQABugRecordTitle.DataDate, "yyyy/MM/dd") & "'")
        QryString.Append(" and Version = " & FindedQABugRecordTitle.Version)
        Adapter.ExecuteNonQuery(QryString.ToString)

        Return True
    End Function

#End Region
#Region "儲存所有資料至資料庫 函式:SaveAllControlDataToDB"
    ''' <summary>
    ''' 儲存所有資料至資料庫
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SaveAllControlDataToDB()
        '檢核是否資料完備才可自動啟動新增作業
        If IsCanWorkDataReady AndAlso Not IsNothing(Me.CoilOtherInfoControl) Then
            Me.CoilOtherInfoControl.SaveControlDataToDB()
        End If
    End Sub

    'Private Delegate Sub SetControlValueToQABugRecordOtherDataUI()
    ' ''' <summary>
    ' ''' 設定控制項值至資料物件
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Public Sub SaveAllControlDataToDB()
    '    Dim cb As New SetControlValueToQABugRecordOtherDataUI(AddressOf SaveAllControlDataToDB1)
    '    Me.BeginInvoke(cb)
    'End Sub


    Public Sub SaveAllControlDataToDB(ByVal ReplaceForRunProcessDataCoilFullNumber As String)
        Dim ServerIP As String = Nothing
        Select Case True
            Case String.IsNullOrEmpty(ReplaceForRunProcessDataCoilFullNumber)
                Exit Sub
            Case IsCanWorkDataReady = False
                Exit Sub
            Case Me.EditStationName = "APL1"
                ServerIP = "10.12.7.10"
                'ServerIP = "10.1.3.22"
            Case Me.EditStationName = "APL2"
                ServerIP = "10.12.2.10"
            Case Me.EditStationName = "BAL"
                ServerIP = "10.12.21.3"
            Case Else
                Exit Sub
        End Select
        Dim QryString As New System.Text.StringBuilder
        QryString.Append("Select * from RunProcessData Where (FK_OutSHA01 + FK_OutSHA02)='" & ReplaceForRunProcessDataCoilFullNumber.Trim & "'")
        QryString.Append(" and RunStationPCIP='" & ServerIP & "'")
        QryString.Append(" and (ThisRecordState=2 or ThisRecordState=3)")
        QryString.Append(" and (SysCoilEndTime >= '" & Format(Me.EditDataDate.Value.AddDays(-1), "yyyy/MM/dd") & "' and SysCoilEndTime <= '" & Format(Me.EditDataDate.Value.AddDays(1), "yyyy/MM/dd") & "')")
        Dim SearchResult1 As List(Of CompanyORMDB.SQLServer.PPS100LB.RunProcessData) = CompanyORMDB.SQLServer.PPS100LB.RunProcessData.CDBSelect(Of CompanyORMDB.SQLServer.PPS100LB.RunProcessData)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString.ToString)
        If SearchResult1.Count = 0 Then
            Exit Sub
        End If

        Dim GetRunProcessData As CompanyORMDB.SQLServer.PPS100LB.RunProcessData = SearchResult1(0)
        Me.CoilOtherInfoControl.SetControlValueToQABugRecordOtherData()
        With GetRunProcessData
            CurrentEditQABugRecordTitle.CoilStartTime = .SysCoilStartTime
            CurrentEditQABugRecordTitle.CoilEndTime = .SysCoilEndTime
            CurrentEditQABugRecordTitle.CoilMaxAddJointLength = .Length
            CurrentEditQABugRecordTitle.CoilMaxLength = IIf(CurrentEditQABugRecordTitle.CoilMaxLength > .Length, .Length, CurrentEditQABugRecordTitle.CoilMaxLength)
            CurrentEditQABugRecordTitle.IsUpdateFromL2Value = True
            CurrentEditQABugRecordTitle.LastEditEmployeeID = Me.LoginID
        End With
        Me.CoilOtherInfoControl.InitControlValue()
        Me.SaveAllControlDataToDB()
    End Sub
#End Region

#Region "APL2缺陷快速預設 函式:APL2QuickSetValue(預備廢除)"
    ''' <summary>
    ''' APL2缺陷快速預設
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub APL2QuickSetValue()
        '檢核是否資料完備才可自動啟動新增作業
        Select Case True
            Case String.IsNullOrEmpty(LoginID) OrElse LoginID.Trim.Length = 0 OrElse _
                String.IsNullOrEmpty(CanEditStationLine) OrElse CanEditStationLine.Trim.Length = 0 OrElse _
                String.IsNullOrEmpty(Me.CurrentEditStationLine) OrElse Me.CurrentEditStationLine.Trim.Length = 0
                Exit Sub
            Case String.IsNullOrEmpty(EditCoilNumber) OrElse EditCoilNumber.Trim.Length = 0
                Exit Sub
            Case IsNothing(EditDataDate)
                Exit Sub
            Case CanEditStationLine <> CurrentEditStationLine
                Exit Sub
            Case String.IsNullOrEmpty(Me.EditOutCoilNumber) OrElse Me.CanEditStationLine <> "APL2"
                Exit Sub
            Case Else
        End Select


        '尋找ZML派工資料
        Dim Qry As String = "Select * From @#PPS100LB.PPSSHAPF WHERE SHA01='" & Me.EditOutCoilNumber.Substring(0, 5) & "' ORDER BY SHA21 desc , SHA24  desc , SHA25 desc"
        Dim SearchResult As List(Of CompanyORMDB.PPS100LB.PPSSHAPF) = CompanyORMDB.PPS100LB.PPSSHAPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSSHAPF)(Qry, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim SearchResultZML As CompanyORMDB.PPS100LB.PPSSHAPF = (From A In SearchResult Where A.SHA08.StartsWith("Z") Select A).FirstOrDefault
        Dim SearchResultAPL1 As CompanyORMDB.PPS100LB.PPSSHAPF = (From A In SearchResult Where A.SHA08.StartsWith("AP") And A.SHA08.Contains("1") Select A).FirstOrDefault
        If IsNothing(SearchResultZML) AndAlso Not IsNothing(SearchResultAPL1) Then
            Exit Sub
        End If

        '尋找前一線品管資料
        If Me.IsOnLineMachine Then
            Qry = "Select * from QABugRecordTitle Where OutCoilNumber='" & Me.EditOutCoilNumber.Trim & "' and ConvertToAS400Time >= '2016/1/1' AND StationName ='APL1' order by ConvertToAS400Time Desc ,CoilStartTime Desc"
        Else
            Qry = "Select * from QABugRecordTitle Where OutCoilNumber='" & Me.EditOutCoilNumber.Trim & "' AND StationName ='APL1' order by ConvertToAS400Time Desc ,CoilStartTime Desc"
        End If
        Dim QASearchResult As List(Of QABugRecordTitle) = QABugRecordTitle.CDBSelect(Of QABugRecordTitle)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, Qry)
        If QASearchResult.Count = 0 OrElse QASearchResult(0).CoilMaxLength >= 9999 Then
            Exit Sub
        End If

        '設定厚度資料
        Dim SetThick As Double = SearchResultZML.SHA14 - 0.03    '派工厚度-0.01=ZML設定厚度,ZML設定厚度-0.02=本線厚度
        Dim SetWidth As Long = CType(SearchResultZML.SHA15, Long) - 3
        Dim DefaultAPL2MaxLength As Long = (SearchResultAPL1.SHA14 / (SearchResultZML.SHA14 - 0.01)) * (QASearchResult(0).CoilMaxLength - 15)
        If DefaultAPL2MaxLength < 500 Then
            Exit Sub
        End If
        Dim SetLengthPosition As New List(Of Long)
        Dim GetLength As Long = DefaultAPL2MaxLength / 4
        For EachThickCount As Integer = 1 To 5
            Select Case True
                Case EachThickCount = 1
                    SetLengthPosition.Add(4)
                Case EachThickCount = 5 And SetThick <= 0.7
                    SetLengthPosition.Add(DefaultAPL2MaxLength - 30)
                Case EachThickCount = 5
                    SetLengthPosition.Add(DefaultAPL2MaxLength - 200)
                Case Else
                    SetLengthPosition.Add(GetLength * (EachThickCount - 1))
            End Select
        Next

        Qry = "Select * From QAThickness Where CoilNumber='" & EditCoilNumber.Trim & "' AND OutCoilNumber = '" & EditOutCoilNumber.Trim & "' And  DataDate='" & Format(Me.EditDataDate, "yyyy/MM/dd") & "' AND StationName='" & CurrentEditStationLine & "'  AND Version='" & Me.EditDataDateVersion.Trim & "'  and RecordState <> 3 Order by DataCreateTime Asc "
        Dim ALLQAThicknessDatas As List(Of QAThickness) = (From A In QAThickness.CDBSelect(Of QAThickness)(Qry) Select A Order By A.DataCreateTime Ascending).ToList
        Dim NextSetDateTime As Nullable(Of DateTime) = (From A In ALLQAThicknessDatas Select A.DataCreateTime Order By DataCreateTime Descending).FirstOrDefault
        For EachControlCount As Integer = ALLQAThicknessDatas.Count + 1 To 5
            Dim SetData As QAThickness = New QAThickness
            With SetData
                .CoilNumber = Me.EditCoilNumber
                .DataDate = Me.EditDataDate
                .Version = Me.EditDataDateVersion
                .OutCoilNumber = CurrentEditQABugRecordTitle.OutCoilNumber
                .StationName = Me.CurrentEditStationLine
                .EditEmployeeID = Me.LoginID
                .Length = SetLengthPosition(IIf(EachControlCount = 0, 0, EachControlCount - 1))
                .Width = SetWidth
                .Thick60 = SetThick
                .RecordState = 1
                '確保新增之資料時間至少為所有資料最後一筆的儲存時間+1秒
                If IsNothing(NextSetDateTime.Value) OrElse NextSetDateTime.Value < (New DateTime(2000, 1, 1)) Then
                    Try
                        NextSetDateTime = CompanyORMDB.DeviceInformation.GetSQLServerTime(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m)
                    Catch ex As Exception
                        NextSetDateTime = Now
                    End Try
                Else
                    NextSetDateTime = NextSetDateTime.Value.AddSeconds(1)
                End If
                .DataCreateTime = NextSetDateTime.Value
                If .CDBSave() > 0 Then
                    Dim AddItem As New ThickItemMinDisplay(SetData, Me)
                    With AddItem
                        .ItemNumber = Format(EachControlCount, "00")
                        .Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
                        .Font = New Font("Arial", 9, FontStyle.Bold)
                        .Cursor = Cursors.Hand
                        .IsCanEdit = True
                    End With
                    AddItem.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
                    AddHandler CType(AddItem, ThickItemMinDisplay).ControlMouseDownClick, AddressOf QAThicknessRecordShowControls_ControlMouseDownClick
                    QAThicknessRecordShowControls.Add(AddItem)
                End If
            End With
        Next
        ReLoadDBQAThicknessRecords()
        '設定138/238位置米數
        Dim AllQABugRecords As New List(Of QABugRecord)
        For Each EachItem As BugItemMinDisplay In QABugRecordShowControls
            AllQABugRecords.Add(EachItem.QABugRecordData)
        Next
        Dim The138Datas As List(Of QABugRecord) = (From A In AllQABugRecords Where A.QABug_Number = 138 Select A Order By A.DataCreateTime).ToList
        Dim The238Datas As List(Of QABugRecord) = (From A In AllQABugRecords Where A.QABug_Number = 238 Select A Order By A.DataCreateTime).ToList
        For EachDataCount As Integer = 1 To 5
            If The138Datas.Count >= EachDataCount Then
                With The138Datas(EachDataCount - 1)
                    .StartPosition = SetLengthPosition(EachDataCount - 1)
                    .EndPosition = .StartPosition
                    .CDBSave()
                End With
            End If
            If The238Datas.Count >= EachDataCount Then
                With The238Datas(EachDataCount - 1)
                    .StartPosition = SetLengthPosition(EachDataCount - 1)
                    .EndPosition = .StartPosition
                    .CDBSave()
                End With
            End If
        Next
    End Sub
#End Region
#Region "缺陷快速預設 函式:QuickSetValue(準備上線)"
    ''' <summary>
    ''' 缺陷快速預設
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub QuickSetValue()
        '檢核是否資料完備才可自動啟動新增作業
        Select Case True
            Case String.IsNullOrEmpty(LoginID) OrElse LoginID.Trim.Length = 0 OrElse _
                String.IsNullOrEmpty(CanEditStationLine) OrElse CanEditStationLine.Trim.Length = 0 OrElse _
                String.IsNullOrEmpty(Me.CurrentEditStationLine) OrElse Me.CurrentEditStationLine.Trim.Length = 0
                Exit Sub
            Case String.IsNullOrEmpty(EditCoilNumber) OrElse EditCoilNumber.Trim.Length = 0
                Exit Sub
            Case IsNothing(EditDataDate)
                Exit Sub
            Case CanEditStationLine <> CurrentEditStationLine
                Exit Sub
            Case String.IsNullOrEmpty(Me.EditOutCoilNumber)
                Exit Sub
            Case Else
        End Select


        '尋找ZML派工資料
        Dim Qry As String = "Select * From @#PPS100LB.PPSSHAPF WHERE SHA01='" & Me.EditOutCoilNumber.Substring(0, 5) & "' ORDER BY SHA21 desc , SHA24  desc , SHA25 desc"
        Dim SearchResult As List(Of CompanyORMDB.PPS100LB.PPSSHAPF) = CompanyORMDB.PPS100LB.PPSSHAPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSSHAPF)(Qry, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim SearchResultZML As CompanyORMDB.PPS100LB.PPSSHAPF = (From A In SearchResult Where A.SHA08.StartsWith("Z") Select A).FirstOrDefault
        Dim SearchResultAPL1 As CompanyORMDB.PPS100LB.PPSSHAPF = (From A In SearchResult Where A.SHA08.StartsWith("AP") And A.SHA08.Contains("1") Select A).FirstOrDefault
        Dim SearchResultBL As CompanyORMDB.PPS100LB.PPSSHAPF = (From A In SearchResult Where A.SHA08.StartsWith("BL") Select A).FirstOrDefault

        Select Case True
            Case (Me.CanEditStationLine = "APL2" OrElse Me.CanEditStationLine = "BAL") AndAlso IsNothing(SearchResultZML) AndAlso Not IsNothing(SearchResultAPL1)
                Exit Sub
            Case Me.CanEditStationLine = "APL1" AndAlso IsNothing(SearchResultBL)
                Exit Sub
        End Select

        'APL2/BAL 需尋找前一線品管資料(APL1除外)
        Dim QASearchResult As List(Of QABugRecordTitle) = Nothing
        If Me.CanEditStationLine <> "APL1" Then
            If Me.IsOnLineMachine Then
                Qry = "Select * from QABugRecordTitle Where OutCoilNumber='" & Me.EditOutCoilNumber.Trim & "' and ConvertToAS400Time >= '2016/1/1' AND StationName ='APL1' order by ConvertToAS400Time Desc ,CoilStartTime Desc"
            Else
                Qry = "Select * from QABugRecordTitle Where OutCoilNumber='" & Me.EditOutCoilNumber.Trim & "' AND StationName ='APL1' order by ConvertToAS400Time Desc ,CoilStartTime Desc"
            End If
            QASearchResult = QABugRecordTitle.CDBSelect(Of QABugRecordTitle)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, Qry)
            If QASearchResult.Count = 0 OrElse QASearchResult(0).CoilMaxLength >= 9999 Then
                Exit Sub
            End If
        End If

        '設定厚度資料
        Dim SetThick As Double = 0
        Dim SetWidth As Long = 0
        Dim SetMaxLength As Long = 0
        Select Case True
            Case Me.CanEditStationLine = "APL1" AndAlso SearchResultBL.SHA15 <> 0 AndAlso SearchResultBL.SHA14 <> 0
                SetThick = SearchResultBL.SHA14
                SetWidth = SearchResultBL.SHA15
                SetMaxLength = SearchResultBL.SHA17 / SearchResultBL.SHA15 / SearchResultBL.SHA14 / 7.93 * 1000
            Case (Me.CanEditStationLine = "APL2" OrElse Me.CanEditStationLine = "BAL") AndAlso (SearchResultZML.SHA14 - 0.01) <> 0
                SetThick = SearchResultZML.SHA14 - 0.03    '派工厚度-0.01=ZML設定厚度,ZML設定厚度-0.02=本線厚度
                SetWidth = CType(SearchResultZML.SHA15, Long) - 3
                SetMaxLength = (SearchResultAPL1.SHA14 / (SearchResultZML.SHA14 - 0.01)) * (QASearchResult(0).CoilMaxLength - 15)
        End Select

        If SetMaxLength < 300 Then
            Exit Sub
        End If
        Dim SetLengthPosition As New List(Of Long)
        Dim GetLength As Long = SetMaxLength / 4
        For EachThickCount As Integer = 1 To 5
            Select Case True
                Case EachThickCount = 1
                    SetLengthPosition.Add(4)
                Case EachThickCount = 5 And SetThick <= 0.7
                    SetLengthPosition.Add(SetMaxLength - 30)
                Case EachThickCount = 5
                    SetLengthPosition.Add(SetMaxLength - 200)
                Case Else
                    SetLengthPosition.Add(GetLength * (EachThickCount - 1))
            End Select
        Next

        Qry = "Select * From QAThickness Where CoilNumber='" & EditCoilNumber.Trim & "' AND OutCoilNumber = '" & EditOutCoilNumber.Trim & "' And  DataDate='" & Format(Me.EditDataDate, "yyyy/MM/dd") & "' AND StationName='" & CurrentEditStationLine & "'  AND Version='" & Me.EditDataDateVersion.Trim & "'  and RecordState <> 3 Order by DataCreateTime Asc "
        Dim ALLQAThicknessDatas As List(Of QAThickness) = (From A In QAThickness.CDBSelect(Of QAThickness)(Qry) Select A Order By A.DataCreateTime Ascending).ToList
        Dim NextSetDateTime As Nullable(Of DateTime) = (From A In ALLQAThicknessDatas Select A.DataCreateTime Order By DataCreateTime Descending).FirstOrDefault
        For EachControlCount As Integer = ALLQAThicknessDatas.Count + 1 To 5
            Dim SetData As QAThickness = New QAThickness
            With SetData
                .CoilNumber = Me.EditCoilNumber
                .DataDate = Me.EditDataDate
                .Version = Me.EditDataDateVersion
                .OutCoilNumber = CurrentEditQABugRecordTitle.OutCoilNumber
                .StationName = Me.CurrentEditStationLine
                .EditEmployeeID = Me.LoginID
                .Length = SetLengthPosition(IIf(EachControlCount = 0, 0, EachControlCount - 1))
                .Width = SetWidth
                .Thick60 = SetThick
                .RecordState = 1
                '確保新增之資料時間至少為所有資料最後一筆的儲存時間+1秒
                If IsNothing(NextSetDateTime.Value) OrElse NextSetDateTime.Value < (New DateTime(2000, 1, 1)) Then
                    Try
                        NextSetDateTime = CompanyORMDB.DeviceInformation.GetSQLServerTime(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m)
                    Catch ex As Exception
                        NextSetDateTime = Now
                    End Try
                Else
                    NextSetDateTime = NextSetDateTime.Value.AddSeconds(1)
                End If
                .DataCreateTime = NextSetDateTime.Value
                If .CDBSave() > 0 Then
                    Dim AddItem As New ThickItemMinDisplay(SetData, Me)
                    With AddItem
                        .ItemNumber = Format(EachControlCount, "00")
                        .Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
                        .Font = New Font("Arial", 9, FontStyle.Bold)
                        .Cursor = Cursors.Hand
                        .IsCanEdit = True
                    End With
                    AddItem.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
                    AddHandler CType(AddItem, ThickItemMinDisplay).ControlMouseDownClick, AddressOf QAThicknessRecordShowControls_ControlMouseDownClick
                    QAThicknessRecordShowControls.Add(AddItem)
                End If
            End With
        Next
        ReLoadDBQAThicknessRecords()

        Dim AllQABugRecords As New List(Of QABugRecord)
        For Each EachItem As BugItemMinDisplay In QABugRecordShowControls
            AllQABugRecords.Add(EachItem.QABugRecordData)
        Next
        Select Case True
            Case Me.CanEditStationLine = "APL1" '由最後4筆厚度資更新缺陷10(銹皮)
                Dim The10Datas As List(Of QABugRecord) = (From A In AllQABugRecords Where A.QABug_Number = 10 Select A Order By A.DataCreateTime).ToList
                For EachDataCount As Integer = 2 To 5       '只取最後4個厚度資料米數來設定缺陷10的米數
                    If The10Datas.Count >= EachDataCount Then
                        With The10Datas(EachDataCount - 1)
                            .StartPosition = SetLengthPosition(EachDataCount - 1)
                            .EndPosition = .StartPosition
                            .CDBSave()
                        End With
                    End If
                Next

            Case Me.CanEditStationLine = "APL2"
                '由厚度資料5筆,設定138/238位置米數
                Dim The138Datas As List(Of QABugRecord) = (From A In AllQABugRecords Where A.QABug_Number = 138 Select A Order By A.DataCreateTime).ToList
                Dim The238Datas As List(Of QABugRecord) = (From A In AllQABugRecords Where A.QABug_Number = 238 Select A Order By A.DataCreateTime).ToList
                For EachDataCount As Integer = 1 To 5
                    If The138Datas.Count >= EachDataCount Then
                        With The138Datas(EachDataCount - 1)
                            .StartPosition = SetLengthPosition(EachDataCount - 1)
                            .EndPosition = .StartPosition
                            .CDBSave()
                        End With
                    End If
                    If The238Datas.Count >= EachDataCount Then
                        With The238Datas(EachDataCount - 1)
                            .StartPosition = SetLengthPosition(EachDataCount - 1)
                            .EndPosition = .StartPosition
                            .CDBSave()
                        End With
                    End If
                Next
            Case Me.CanEditStationLine = "BAL"
                '由缺陷33,設定亮度米數(最多6筆)
                If IsNothing(CoilOtherInfoControl) OrElse Not TypeOf CoilOtherInfoControl Is BALOthersEdit Then
                    Exit Sub
                End If
                Dim The33Datas As List(Of QABugRecord) = (From A In AllQABugRecords Where A.QABug_Number = 33 Select A Order By A.DataCreateTime).ToList
                Dim SetPosition As New List(Of Integer)
                For EachDataCount As Integer = 0 To The33Datas.Count - 1
                    SetPosition.Add(The33Datas(EachDataCount).StartPosition)
                Next
                CType(CoilOtherInfoControl, BALOthersEdit).SetBrightLengthMM(SetPosition, SetPosition)
        End Select

    End Sub
#End Region
#Region "APL2BAL依厚度位置更新缺陷位置 函式:APL2BALBugPositionFromThickPosition"
    ''' <summary>
    ''' APL2依厚度位置更新缺陷位置
    ''' </summary>
    ''' <param name="FromThickPosition"></param>
    ''' <remarks></remarks>
    Private Sub APL2BALBugPositionFromThickPosition(ByVal FromThickPosition As QAThickness)
        If String.IsNullOrEmpty(Me.CanEditStationLine) OrElse String.IsNullOrEmpty(Me.CurrentEditStationLine) OrElse IsNothing(FromThickPosition) Then
            Exit Sub
        End If
        If Me.CanEditStationLine <> Me.CurrentEditStationLine Then
            Exit Sub
        End If

        Dim AllQABugRecords As New List(Of QABugRecord)
        For Each EachItem As BugItemMinDisplay In QABugRecordShowControls
            AllQABugRecords.Add(EachItem.QABugRecordData)
        Next

        Select Case True
            Case Me.CanEditStationLine = "APL1"
                '由厚度位置更新缺陷10的位置資料
                Dim AllQAThicknessRecords As New List(Of QAThickness)
                Dim AddCount As Integer = 0
                Dim SetThe10DataIndex = 0
                For ThickItemMinDisplayIndex As Integer = QAThicknessRecordShowControls.Count - 1 To 1 Step -1
                    AllQAThicknessRecords.Add(CType(QAThicknessRecordShowControls(ThickItemMinDisplayIndex), ThickItemMinDisplay).QAThicknessRecordData)
                    If AddCount >= 4 Then
                        Exit For
                    End If
                Next
                AllQAThicknessRecords.Reverse()
                Dim The10Datas As List(Of QABugRecord) = (From A In AllQABugRecords Where A.QABug_Number = 10 Select A Order By A.DataCreateTime).ToList
                For TheQAThicknessIndex As Integer = 0 To AllQAThicknessRecords.Count - 1
                    If AllQAThicknessRecords(TheQAThicknessIndex).DataCreateTime = FromThickPosition.DataCreateTime AndAlso The10Datas.Count - 1 >= TheQAThicknessIndex Then
                        With The10Datas(TheQAThicknessIndex)
                            .StartPosition = FromThickPosition.Length
                            .EndPosition = .StartPosition
                            .CDBSave()
                        End With
                    End If
                Next


            Case Me.CanEditStationLine = "BAL"
                '由厚度位置更新缺陷10的位置資料
                Dim AllQAThicknessRecords As New List(Of QAThickness)
                For Each EachItem As ThickItemMinDisplay In QAThicknessRecordShowControls
                    AllQAThicknessRecords.Add(EachItem.QAThicknessRecordData)
                Next

                For TheQAThicknessIndex As Integer = 1 To AllQAThicknessRecords.Count
                    If AllQAThicknessRecords(TheQAThicknessIndex).DataCreateTime = FromThickPosition.DataCreateTime AndAlso TheQAThicknessIndex <> 1 Then
                        Dim The10Datas As List(Of QABugRecord) = (From A In AllQABugRecords Where A.QABug_Number = 10 Select A Order By A.DataCreateTime).ToList
                        For EachDataCount As Integer = 2 To 5       '只取最後4個厚度資料米數來設定缺陷10的米數
                            If The10Datas.Count >= EachDataCount And EachDataCount = TheQAThicknessIndex Then
                                With The10Datas(EachDataCount - 1)
                                    .StartPosition = FromThickPosition.Length
                                    .EndPosition = .StartPosition
                                    .CDBSave()
                                End With
                            End If
                            Exit Sub
                        Next
                    End If
                Next
            Case Me.CanEditStationLine = "APL2"
                Dim WillSet138238DataPosition As Integer = 1
                For Each EachItem As ThickItemMinDisplay In QAThicknessRecordShowControls
                    If EachItem.QAThicknessRecordData.DataCreateTime = FromThickPosition.DataCreateTime Then
                        '設定138/238位置米數
                        Dim The138Datas As List(Of QABugRecord) = (From A In AllQABugRecords Where A.QABug_Number = 138 Select A Order By A.DataCreateTime).ToList
                        Dim The238Datas As List(Of QABugRecord) = (From A In AllQABugRecords Where A.QABug_Number = 238 Select A Order By A.DataCreateTime).ToList
                        If The138Datas.Count >= WillSet138238DataPosition Then
                            With The138Datas(WillSet138238DataPosition - 1)
                                .StartPosition = FromThickPosition.Length
                                .EndPosition = .StartPosition
                                .CDBSave()
                            End With
                        End If
                        If The238Datas.Count >= WillSet138238DataPosition Then
                            With The238Datas(WillSet138238DataPosition - 1)
                                .StartPosition = FromThickPosition.Length
                                .EndPosition = .StartPosition
                                .CDBSave()
                            End With
                        End If
                        Exit Sub
                    End If
                    WillSet138238DataPosition += 1
                Next

        End Select

    End Sub
#End Region
#Region "BAL依缺陷更新亮度位置 函式:BALBrightPositionMMFromBugPosition"
    ''' <summary>
    ''' BAL依缺陷更新亮度位置
    ''' </summary>
    ''' <param name="FromBug"></param>
    ''' <remarks></remarks>
    Private Sub BALBrightPositionMMFromBugPosition(ByVal FromBug As QABugRecord)
        '由缺陷138,設定亮度米數(最多6筆)
        If IsNothing(FromBug) OrElse IsNothing(CoilOtherInfoControl) OrElse Not TypeOf CoilOtherInfoControl Is BALOthersEdit OrElse Me.CanEditStationLine <> "BAL" OrElse Me.CanEditStationLine <> Me.CurrentEditStationLine Then
            Exit Sub
        End If
        Dim AllQABugRecords As New List(Of QABugRecord)
        For Each EachItem As BugItemMinDisplay In QABugRecordShowControls
            AllQABugRecords.Add(EachItem.QABugRecordData)
        Next

        ''同步BAL--缺陷138長度
        Dim The138Datas As List(Of QABugRecord) = (From A In AllQABugRecords Where A.QABug_Number = 138 Select A Order By A.DataCreateTime).ToList
        For EachDataCount As Integer = 1 To The138Datas.Count
            If The138Datas(EachDataCount - 1) Is FromBug AndAlso EachDataCount <= 6 Then
                CType(CoilOtherInfoControl, BALOthersEdit).SetBrightLengthMM(FromBug.StartPosition, FromBug.StartPosition, EachDataCount)
                CType(CoilOtherInfoControl, BALOthersEdit).SaveControlDataToDB()
                Exit For
            End If
        Next
    End Sub
#End Region





#Region "印表 函式:Print"
    ''' <summary>
    ''' 印表
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Print(ByVal SetCoilNumber As String, SetOutCoilNumber As String, ByVal SetDataDate As Date, ByVal SetStationName As String, ByVal SetVersion As String)

        '載入鋼捲缺陷表頭資料
        Dim Qry As String = "Select * From QABugRecordTitle where CoilNumber='" & SetCoilNumber & "' and OutCoilNumber='" & SetOutCoilNumber & "' and StationName='" & SetStationName & "' and DataDate = '" & Format(SetDataDate, "yyyy/MM/dd") & "' AND Version='" & SetVersion & "' "
        Dim Adapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
        Dim SearchResult As List(Of QABugRecordTitle) = QABugRecordTitle.CDBSelect(Of QABugRecordTitle)(Qry, Adapter)
        Dim FindedQABugRecordTitle As QABugRecordTitle = Nothing
        Dim CoilMaxLength As Double = 0
        Dim SetHeadMaterialType As String

        If SearchResult.Count = 0 Then
            Exit Sub
        Else
            FindedQABugRecordTitle = SearchResult(0)
            CoilMaxLength = FindedQABugRecordTitle.CoilMaxLength
        End If
        Dim PringArg As New RDLCDirectPrint.PrintArg
        With PringArg
            .TitleArg1 = SetStationName.Trim
            .HeadCoilNumber = SetOutCoilNumber
            If Not IsNothing(FindedQABugRecordTitle.AboutPPSBLAPF) Then
                .HeadSteelKind = FindedQABugRecordTitle.AboutPPSBLAPF.BLA02.Trim & FindedQABugRecordTitle.AboutPPSBLAPF.BLA18.Trim
                .TailHotCoilBatch = FindedQABugRecordTitle.AboutPPSBLAPF.BLA11.Trim
                .HeadBilletNumber = FindedQABugRecordTitle.AboutPPSBLAPF.BLA07
            Else
                .HeadSteelKind = ""
                .TailHotCoilBatch = ""
                .HeadBilletNumber = ""
            End If
            Select Case SetStationName.Trim
                Case "APL1"
                    .HeadSteelFace = "NO1"
                Case "APL2"
                    .HeadSteelFace = "2D"
                Case "BAL"
                    .HeadSteelFace = "BAL"
            End Select

            .HeadThick = FindedQABugRecordTitle.PublicThickAndSubThick
            .HeadLength = FindedQABugRecordTitle.CoilMaxLength
            .HeadLineName = SetStationName
            '料別尋找
            Qry = "Select SHA36 From @#PPS100LB.PPSSHAPF WHERE RTRIM(SHA01 || SHA02)='" & SetCoilNumber.Trim & "' AND SHA36<>'' fetch first 1 rows only"
            Dim AS400Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, "PPS100LB")
            Dim SearchResult1 As DataTable = AS400Adapter.SelectQuery(Qry)
            If SearchResult1.Rows.Count > 0 Then
                .HeadMaterialType = CType(SearchResult1.Rows(0).Item(0), String).Trim
            Else
                .HeadMaterialType = "未知"
            End If
            SetHeadMaterialType = .HeadMaterialType
            .HeadCoilBirthday = Format(FindedQABugRecordTitle.CoilStartTime, "yyyy/MM/dd HH:mm") & " ~ " & Format(FindedQABugRecordTitle.CoilEndTime, "yyyy/MM/dd HH:mm")


            ''Get Coil Type From AS400
            Qry = "Select SHA12 From @#PPS100LB.PPSSHAPF Where SHA01='" & SetCoilNumber.Trim & "' AND SHA12 <> '' order by sha21 desc fetch first 1 rows only"
            SearchResult1 = AS400Adapter.SelectQuery(Qry)  ''重新Select
            If SearchResult1.Rows.Count > 0 Then
                .CoilType = CType(SearchResult1.Rows(0).Item(0), String).Trim
            Else
                .CoilType = ""
            End If


            ''原始CODE
            '.HeadCoilReceiveType = IIf(FindedQABugRecordTitle.CoilReceiveType = 0, "下收", "上收")

            'If CoilReceiveType.Equals(0) Then
            '    .HeadCoilReceiveType = "下收"
            'Else
            '    .HeadCoilReceiveType = "上收"
            'End If



            ''更改印表時的上下收，換由使用者決定顆鋼捲的收卷狀態
            ''Dim upDown_Status As String = ""
            ''Me.CoilOtherInfoControl.getUpDown_Status(upDown_Status)
            ''106/08/29 ADD
            If coilUpDown_Status = "上收" Then
                .HeadCoilReceiveType = "上收"
            ElseIf coilUpDown_Status = "下收" Then
                .HeadCoilReceiveType = "下收"
            Else
                .HeadCoilReceiveType = ""
            End If


            'If upDown_Status = "上收" Then
            '    .HeadCoilReceiveType = "上收"
            'ElseIf upDown_Status = "下收" Then
            '    .HeadCoilReceiveType = "下收"
            'Else
            '    .HeadCoilReceiveType = ""
            'End If


            .TailPackage = Choose(FindedQABugRecordTitle.APL1IsExportPackage + 1, {"", "有", "無"})  '停用
            .TailBrokeMachine = Choose(FindedQABugRecordTitle.APL1IsUseDestory + 1, {"", "使用", "未使用"})
            If SetStationName.Trim = "APL2" Then    'APL2印表時將破碎機當測厚儀厚度使用
                .TailBrokeMachine = FindedQABugRecordTitle.APL2ThickMM
            End If
            'If FindedQABugRecordTitle.APL1IsNo1GetTest = 1 Then    '停用
            '    .TailNO1Test = "厚度:" & FindedQABugRecordTitle.APL1No1TestThickMM
            'Else
            '    .TailNO1Test = "未取"
            'End If
            If FindedQABugRecordTitle.APL2BATestHeadMM = 0 AndAlso FindedQABugRecordTitle.APL2BATestTailMM = 0 Then
                .TailTestThick = "未取"
            Else
                .TailTestThick = "頭片:" & Format("0.00", FindedQABugRecordTitle.APL2BATestHeadMM) & IIf(String.IsNullOrEmpty(.TailTestThick), "", " / ") & "尾片:" & Format("0.00", FindedQABugRecordTitle.APL2BATestTailMM)
                'If FindedQABugRecordTitle.APL2BATestHeadMM > 0 Then
                '    .TailTestThick = "頭片:" & Format("0.00", FindedQABugRecordTitle.APL2BATestHeadMM)
                'End If
                'If FindedQABugRecordTitle.APL2BATestTailMM > 0 Then
                '    .TailTestThick &= IIf(String.IsNullOrEmpty(.TailTestThick), "", " / ") & "尾片:" & Format("0.00", FindedQABugRecordTitle.APL2BATestTailMM)
                'End If
            End If
            .TailNO1Shape = Choose(FindedQABugRecordTitle.APL1No1Form + 1, {"平整", "輕微波狀", "中度波狀", "嚴重波狀"})
            If Not IsNothing(FindedQABugRecordTitle.HandOverBeforeeEmpID) Then
                .TailInputEmployeeNO = FindedQABugRecordTitle.HandOverBeforeeEmpID.Trim
            End If
            If Not IsNothing(.TailInputEmployeeNO) AndAlso .TailInputEmployeeNO.Length > 0 _
                AndAlso Not IsNothing(FindedQABugRecordTitle.LastEditEmployeeID) AndAlso FindedQABugRecordTitle.LastEditEmployeeID.Trim.Length > 0 Then
                .TailInputEmployeeNO &= " / "
            End If
            .TailInputEmployeeNO &= FindedQABugRecordTitle.LastEditEmployeeID

            If Not IsNothing(FindedQABugRecordTitle.HandOverLength) Then
                .HandOverLength = FindedQABugRecordTitle.HandOverLength
            End If


            If .HeadSteelFace = "BAL" Then  '待測試
                Dim TailBALLightArgs(6) As String
                For PrintLineCount As Integer = 1 To 6
                    Dim FieldName As String = Nothing
                    Select Case PrintLineCount
                        Case 1
                            FieldName = "BALPBrightLengthMM"
                        Case 2
                            FieldName = "BALPBrightCenterMM"
                        Case 3
                            FieldName = "BALPBrightSideMM"
                        Case 4
                            FieldName = "BALNBrightLengthMM"
                        Case 5
                            FieldName = "BALNBrightCenterMM"
                        Case 6
                            FieldName = "BALNBrightSideMM"
                    End Select
                    For EachFieldCount As Integer = 1 To 6
                        If FindedQABugRecordTitle.CDBGetFieldValue(FieldName & EachFieldCount) > 0 Then
                            If String.IsNullOrEmpty(TailBALLightArgs(PrintLineCount)) Then
                                TailBALLightArgs(PrintLineCount) = FindedQABugRecordTitle.CDBGetFieldValue(FieldName & EachFieldCount)
                            Else
                                TailBALLightArgs(PrintLineCount) &= "@" & FindedQABugRecordTitle.CDBGetFieldValue(FieldName & EachFieldCount)
                            End If
                        Else
                            TailBALLightArgs(PrintLineCount) &= "@"
                        End If
                    Next
                Next
                .TailBALLightArg1 = TailBALLightArgs(1)
                .TailBALLightArg2 = TailBALLightArgs(2)
                .TailBALLightArg3 = TailBALLightArgs(3)
                .TailBALLightArg4 = TailBALLightArgs(4)
                .TailBALLightArg5 = TailBALLightArgs(5)
                .TailBALLightArg6 = TailBALLightArgs(6)

                '片型
                Dim BALSectionSheetArgs(4) As String

                For EachFieldCount As Integer = 1 To 4
                    Dim FieldName1 As String = Nothing
                    Select Case EachFieldCount
                        Case 1
                            FieldName1 = "PositionMM"
                        Case 2
                            FieldName1 = "OperateMM"
                        Case 3
                            FieldName1 = "MiddleMM"
                        Case 4
                            FieldName1 = "PowerMM"
                    End Select
                    For PrintLineCount As Integer = 1 To 4
                        Dim FieldName As String = Nothing
                        Select Case PrintLineCount
                            Case 1
                                FieldName = "BALSection1" & FieldName1
                            Case 2
                                FieldName = "BALSection2" & FieldName1
                            Case 3
                                FieldName = "BALSection3" & FieldName1
                            Case 4
                                FieldName = "BALSection4" & FieldName1
                        End Select
                        If FindedQABugRecordTitle.CDBGetFieldValue(FieldName) > 0 Then
                            If String.IsNullOrEmpty(BALSectionSheetArgs(PrintLineCount)) Then
                                BALSectionSheetArgs(PrintLineCount) = FindedQABugRecordTitle.CDBGetFieldValue(FieldName)
                            Else
                                BALSectionSheetArgs(PrintLineCount) &= "@" & FindedQABugRecordTitle.CDBGetFieldValue(FieldName)
                            End If
                        Else
                            BALSectionSheetArgs(PrintLineCount) &= "@"
                        End If
                    Next
                Next
                .SectionSheetArg1 = BALSectionSheetArgs(1)
                .SectionSheetArg2 = BALSectionSheetArgs(2)
                .SectionSheetArg3 = BALSectionSheetArgs(3)
                .SectionSheetArg4 = BALSectionSheetArgs(4)
                'If Not IsNothing(FindedQABugRecordTitle.HandOverLength) Then
                '    .HandOverLength = FindedQABugRecordTitle.HandOverLength
                'End If
            End If

        End With


        '載入鋼捲缺陷資料
        'Dim Qry As String = "Select * From QABugRecord Where CoilNumber='" & EditCoilNumber & "' AND OutCoilNumber='" & Me.EditOutCoilNumber & "' And  DataDate='" & Me.EditDataDate & "' AND StationName='" & CurrentEditStationLine & "'  AND Version='" & Me.EditDataDateVersion.Trim & "' and RecordState <> 3 Order by DataCreateTime Asc "
        Qry = "Select * From QABugRecord Where CoilNumber='" & SetCoilNumber & "' AND OutCoilNumber='" & SetOutCoilNumber & "' And  DataDate='" & Format(SetDataDate, "yyyy/MM/dd") & "' AND StationName='" & SetStationName & "'  AND Version='" & SetVersion & "' and RecordState <> 3 Order by DataCreateTime Asc "
        Dim PrintBugData As New DBDataSet.BugsDataTable


        'If SetStationName.PadRight(4).Substring(0, 4) = "APL1" Then
        '    For Each EachItem As QABugRecord In QABugRecord.CDBSelect(Of QABugRecord)(Qry)
        '        Dim PrintBugDataRow As DBDataSet.BugsRow = PrintBugData.NewRow
        '        With PrintBugDataRow
        '            .QABug_Number = EachItem.QABug_Number
        '            .Degree = EachItem.Degree
        '            .Length = EachItem.StartPosition & " ~ " & IIf(EachItem.EndPosition > CoilMaxLength, CoilMaxLength, EachItem.EndPosition)
        '            If {1, 2, 4}.Contains(EachItem.DPositionType) Then
        '                .DPosition = EachItem.DPositionTypeName & EachItem.DPositionStart & " ~ " & EachItem.DPositionEnd
        '            Else
        '                .DPosition = EachItem.DPositionTypeName
        '            End If
        '            .PosOrNeg = EachItem.PosOrNegName
        '            .Density = EachItem.Density
        '            .Cycle = EachItem.Cycle
        '        End With
        '        PrintBugData.Rows.Add(PrintBugDataRow)
        '    Next
        'Else
        'End If
        'BAL/APL1/APL2產線第二筆資料秀在右半邊
        Dim RowCount1 As Integer = 1
        Dim PrintBugDataRow As DBDataSet.BugsRow = Nothing
        Dim AllBugDatas As List(Of CompanyORMDB.SQLServer.PPS100LB.QABUG) = CompanyORMDB.SQLServer.PPS100LB.QABUG.AllBugDatas
        Dim FindedBugDefine As CompanyORMDB.SQLServer.PPS100LB.QABUG = Nothing
        For Each EachItem As QABugRecord In QABugRecord.CDBSelect(Of QABugRecord)(Qry)
            FindedBugDefine = (From A In AllBugDatas Where A.Number.Trim = EachItem.QABug_Number.Trim Select A).FirstOrDefault
            If RowCount1 Mod 2 = 1 Then
                PrintBugDataRow = PrintBugData.NewRow
                With PrintBugDataRow
                    .QABug_Number = EachItem.QABug_Number
                    .Degree = EachItem.Degree
                    .Length = EachItem.StartPosition & " ~ " & IIf(EachItem.EndPosition > CoilMaxLength, CoilMaxLength, EachItem.EndPosition)
                    If {1, 2, 4}.Contains(EachItem.DPositionType) Then
                        .DPosition = EachItem.DPositionTypeName & EachItem.DPositionStart & " ~ " & EachItem.DPositionEnd
                    Else
                        .DPosition = EachItem.DPositionTypeName
                    End If
                    .PosOrNeg = EachItem.PosOrNegName
                    .Density = EachItem.Density
                    .Cycle = EachItem.Cycle
                    If Not IsNothing(FindedBugDefine) AndAlso FindedBugDefine.IsAttentation Then
                        .IsAttentation = "1"
                    Else
                        .IsAttentation = "0"
                    End If
                End With
                PrintBugData.Rows.Add(PrintBugDataRow)
            Else
                With PrintBugDataRow
                    .C2QABug_Number = EachItem.QABug_Number
                    .C2Degree = EachItem.Degree
                    .C2Length = EachItem.StartPosition & " ~ " & IIf(EachItem.EndPosition > CoilMaxLength, CoilMaxLength, EachItem.EndPosition)
                    If {1, 2, 4}.Contains(EachItem.DPositionType) Then
                        .C2DPosition = EachItem.DPositionTypeName & EachItem.DPositionStart & " ~ " & EachItem.DPositionEnd
                    Else
                        .C2DPosition = EachItem.DPositionTypeName
                    End If
                    .C2PosOrNeg = EachItem.PosOrNegName
                    .C2Density = EachItem.Density
                    .C2Cycle = EachItem.Cycle
                    If Not IsNothing(FindedBugDefine) AndAlso FindedBugDefine.IsAttentation Then
                        .C2IsAttentation = "1"
                    Else
                        .C2IsAttentation = "0"
                    End If
                End With
            End If
            RowCount1 += 1
        Next


        '載入鋼捲實測厚度資料
        Qry = "Select * From QAThickness Where CoilNumber='" & SetCoilNumber & "' AND OutCoilNumber = '" & SetOutCoilNumber & "' And  DataDate='" & Format(SetDataDate, "yyyy/MM/dd") & "' AND StationName='" & SetStationName & "'  AND Version='" & SetVersion & "'  and RecordState <> 3 Order by DataCreateTime Asc "
        Dim PrintThickData As New DBDataSet.ThicksDataTable
        Dim RowCount As Integer = 1
        Dim AvgThickDatas As New List(Of Decimal)
        Dim AvgWidthDatas As New List(Of Decimal)

        For Each EachItem As QAThickness In QAThickness.CDBSelect(Of QAThickness)(Qry)

            Dim PrintThickDataRow As DBDataSet.ThicksRow = PrintThickData.NewRow
            With PrintThickDataRow
                If SetStationName.PadRight(4).Substring(0, 4) = "APL1" Then
                    Select Case True
                        Case EachItem.Thick60 > 0 AndAlso EachItem.Thick > 0
                            .ThickText = String.Format("{0:0.###}~{1:0.###} * {2:0000} * {3:0000}              ", {EachItem.Thick60, EachItem.Thick, EachItem.Width, EachItem.Length})
                        Case EachItem.Thick60 > 0
                            .ThickText = String.Format("{0:0.###} * {1:0000} * {2:0000}              ", {EachItem.Thick60, EachItem.Width, EachItem.Length})
                        Case EachItem.Thick > 0
                            .ThickText = String.Format("{0:0.###} * {1:0000} * {2:0000}              ", {EachItem.Thick, EachItem.Width, EachItem.Length})
                        Case Else
                            .ThickText = String.Format("{0:0.###} * {1:0000} * {2:0000}              ", {0, EachItem.Width, EachItem.Length})
                    End Select


                Else
                    'BAL/APL2 只印距邊60
                    Select Case True
                        Case EachItem.Thick60 > 0
                            .ThickText = String.Format("{0:0.###} * {1:0000} * {2:0000}", {EachItem.Thick60, EachItem.Width, EachItem.Length})
                        Case Else
                            .ThickText = String.Format("{0:0.###} * {1:0000} * {2:0000}", {0, EachItem.Width, EachItem.Length})
                    End Select
                End If
                '計算平均厚度/寬度使用
                If EachItem.Thick60 > 0 Then
                    AvgThickDatas.Add(EachItem.Thick60)
                End If
                If EachItem.Width > 0 Then
                    AvgWidthDatas.Add(EachItem.Width)
                End If
            End With
            PrintThickData.Rows.Add(PrintThickDataRow)

        Next

        ''鋼捲第一筆檢測資料差異過大，因此不列入平均計算
        If AvgThickDatas.Count > 0 And EditStationName.Trim <> "APL1" Then

            AvgThickDatas.RemoveAt(0)
            AvgWidthDatas.RemoveAt(0)

        End If



        Dim BalAplMemoToPrintArgString As New StringBuilder
        BalAplMemoToPrintArgString.Append("品檢員:" & PringArg.TailInputEmployeeNO)
        BalAplMemoToPrintArgString.Append("      鋼捲編號:" & SetCoilNumber)
        If AvgThickDatas.Count > 0 Then
            BalAplMemoToPrintArgString.Append(vbNewLine & "平均厚度:" & Format(AvgThickDatas.Average, "0.##"))
        Else
            BalAplMemoToPrintArgString.Append(vbNewLine & "平均厚度:0")
        End If
        BalAplMemoToPrintArgString.Append("      料別:" & SetHeadMaterialType)
        If AvgWidthDatas.Count > 0 Then
            BalAplMemoToPrintArgString.Append(vbNewLine & "平均寬度:" & Format(AvgWidthDatas.Average, "0"))
        Else
            BalAplMemoToPrintArgString.Append(vbNewLine & "平均寬度:0")
        End If

        BalAplMemoToPrintArgString.Append("     鋼種:" & PringArg.CoilType)

        BalAplMemoToPrintArgString.Append(vbNewLine & "總    長:" & PringArg.HeadLength)
        PringArg.BALMemo = BalAplMemoToPrintArgString.ToString
        PringArg.APLMemo = PringArg.BALMemo


        If SetStationName.Trim = "APL1" Then    '加入C40欄位值
            Qry = "Select B.BLG16 From @#PPS100LB.PPSBLAPF A JOIN @#PPS100LB.PPSBLGPF B ON A.BLA01=BLG02 WHERE RTRIM(A.BLA09)='" & SetCoilNumber.Trim & "' ORDER BY A.BLA08 DESC fetch first 1 rows only"
            Dim AS400Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, "PPS100LB")
            Dim SearchResultC40 As DataTable = AS400Adapter.SelectQuery(Qry)
            If SearchResultC40.Rows.Count > 0 Then
                PringArg.C40 = CType(SearchResultC40.Rows(0).Item(0), String).Trim
            Else
                PringArg.C40 = 0
            End If
        End If

        Static PrintObject As New RDLCDirectPrint("QAColdRollingClient.RDLCDirectPrint.rdlc")

        Try

            PrintObject.SetPrintDatasAndPrint({PrintBugData, PrintThickData}, PringArg)

        Catch ex As Exception

            MessageBox.Show("錯誤!!報表無法印出，請聯繫相關人員處理")

            Dim MailObject As New PublicClassLibrary.MISMail

            MailObject.ToMailAddress.Add(New MailAddress("30355@mail.tangeng.com.tw", "龔泓璋"))
            MailObject.SendMail("報表印出處理錯誤通知!!", "產線:" & Me.EditCoilNumber & "  " & Me.EditCoilNumber & "資料轉換!" & vbNewLine & "錯誤訊息:" & ex.ToString)

            Exit Sub
        End Try

    End Sub
#End Region

    Private Sub btnCoilNumber_Click(sender As Object, e As EventArgs) Handles btnCoilNumber.Click
        '鋼捲號碼設定
        TabControl1.SelectedTab = tpBugEdit
        MainControl_CoilNumberInputControl.InitControlValue(Me.EditCoilNumber)
        ShowControlToFullEditArea(MainControl_CoilNumberInputControl)
        Me.RefreshAllEnableControl()
    End Sub

    Private Sub MainControl_CoilNumberInputControlEvent_ButtonClickEvent(sender As Object, Value As String) Handles MainControl_CoilNumberInputControlEvent.ButtonClickEvent
        '鋼捲號碼設定返回
        If Not String.IsNullOrEmpty(Value) Then
            Me.EditCoilNumber = Value
            Me.EditOutCoilNumber = Value
        Else
            If Not String.IsNullOrEmpty(EditCoilNumber) AndAlso Value <> EditCoilNumber Then
                Me.SaveAllControlDataToDB()
                EditCoilNumber = Value
                EditOutCoilNumber = Value
                AutoSetNowDataDateAndLaseVersion()  '設定此鋼捲之最新編修日期及版本
            End If
        End If

        ValidCanEditCoilFullNumberIsOnLineCoilFullNumber(True)


        GoRunNextInputProcess()
        Me.ShowPageNumber = 1
    End Sub

    Private Sub QABugRecordShowControls_ControlMouseDownClick(ByVal Sender As BugItemMinDisplay, e As MouseEventArgs, ByVal SendButtonType As BugItemMinDisplay.ButtonTypeEnum)
        '顯示編修詳細缺陷控制項資料
        BugItemEditControl.EditQABugRecord = Sender.QABugRecordData
        With BugItemEditControl
            .ControlDataProcessMode = BugItemEdit.ControlDataProcessModeEnum.EditMode
            .EditQABugRecord.CoilNumber = Me.EditCoilNumber
            .EditQABugRecord.DataDate = Me.EditDataDate
            .EditQABugRecord.StationName = Me.CurrentEditStationLine
            .Visible = True
        End With
        For Each EachItem As BugItemMinDisplay In Me.QABugRecordShowControls
            If Sender Is EachItem Then
                EachItem.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
                EachItem.BackColor = Color.Green    '使用者選擇變色
            Else
                EachItem.BorderStyle = Windows.Forms.BorderStyle.None
                EachItem.IsCanEdit = EachItem.IsCanEdit '變回正常顏色
            End If
        Next
        ShowControlToFullEditArea(BugItemEditControl)
        BugItemEditControl.ShowCoilInformation(Me.EditCoilNumber)   '顯示鋼捲資訊
        BugItemEditControl.SendButtonCommand(SendButtonType)
        Me.RefreshAllEnableControl()
    End Sub

    Private Sub QAThicknessRecordShowControls_ControlMouseDownClick(ByVal Sender As ThickItemMinDisplay, e As MouseEventArgs, ByVal SendButtonType As BugItemMinDisplay.ButtonTypeEnum)
        '顯示編修詳細實測厚度控制項資料
        ThicknessEditControl.EditQAThickness = Sender.QAThicknessRecordData
        With ThicknessEditControl
            .EditQAThickness.CoilNumber = Me.EditCoilNumber
            .EditQAThickness.DataDate = Me.EditDataDate
            .EditQAThickness.StationName = Me.CurrentEditStationLine
            .Visible = True
        End With
        For Each EachItem As ThickItemMinDisplay In Me.QAThicknessRecordShowControls
            If Sender Is EachItem Then
                EachItem.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
                EachItem.BackColor = Color.Green    '使用者選擇變色
            Else
                EachItem.BorderStyle = Windows.Forms.BorderStyle.None
                EachItem.IsCanEdit = EachItem.IsCanEdit '變回正常顏色
            End If
        Next
        ShowControlToFullEditArea(ThicknessEditControl)
        ThicknessEditControl.ControlDataProcessMode = ThickItemEdit.ControlDataProcessModeEnum.EditMode
        ThicknessEditControl.SendButtonCommand(SendButtonType)
        Me.RefreshAllEnableControl()

    End Sub


    Private Sub btnDataDate_Click(sender As Object, e As EventArgs) Handles btnDataDate.Click
        '顯示編修報表日期控制項
        TabControl1.SelectedTab = tpBugEdit
        ShowControlToFullEditArea(Me.BugItemGroupEditControl)
        Me.BugItemGroupEditControl.RefreshDataDateMenu()
        Me.RefreshAllEnableControl()

    End Sub

    'Private Sub BugItemGroupEditControlEvent_DataDateSelect(Sender As BugItemGroupEdit, SelectDate As Nullable(Of Date), SelectVersion As String) Handles BugItemGroupEditControlEvent.DataDateSelect
    '    ''顯示編修報表日期控制項事件返回
    '    If Not IsNothing(SelectDate) Then
    '        Me.EditDataDate = SelectDate
    '        Me.EditDataDateVersion = SelectVersion

    '        Me.EditCoilNumber = CType(Sender.Tag, String).Split(",")(2)
    '        Me.EditOutCoilNumber = CType(Sender.Tag, String).Split(",")(3)
    '        ShowPageNumber = 1
    '    End If

    '    GoRunNextInputProcess()
    '    ShowPageNumber = 1
    'End Sub

    Private Sub BugItemGroupEditControlEvent_DataDateSelect(Sender As BugItemGroupEdit, ByVal SenderClickButton As Button) Handles BugItemGroupEditControlEvent.DataDateSelect
        ''顯示編修報表日期控制項事件返回
        If Not IsNothing(SenderClickButton) Then
            Me.EditDataDate = CType(CType(SenderClickButton.Tag, String).Split(",")(0), Date)
            Me.EditDataDateVersion = CType(SenderClickButton.Tag, String).Split(",")(1)
            Me.EditCoilNumber = CType(SenderClickButton.Tag, String).Split(",")(2)
            Me.EditOutCoilNumber = CType(SenderClickButton.Tag, String).Split(",")(3)
            ShowPageNumber = 1
        End If

        GoRunNextInputProcess()
        ShowPageNumber = 1
    End Sub
    Private Sub rbAPL1_MouseUp(sender As Object, e As MouseEventArgs) Handles rbAPL1.MouseUp, rbAPL2.MouseUp, rbBAL.MouseUp
        '切換顯示站台缺陷
        TabControl1.SelectedTab = tpBugEdit



        ''106/08/29 ADD
        ''偵測狀態，登入時重設上下收
        trigger = True


        ShowPageNumber = 1
        ReLoadDBQABugRecords()
        If Me.QABugRecordShowControls.Count = 0 AndAlso _
            Me.CanEditStationLine.Trim = Me.CurrentEditStationLine.Trim Then
            If EditStationIP = CompanyORMDB.DeviceInformation.GetLocalIPs(0).Trim Then
                InsertQABugRecords(Me.CurrentEditStationLine, 0)
            Else
                If MsgBox("本機非現場主機,是否要執行預設缺陷群新增功能?(會產生多筆缺陷預設值)", MsgBoxStyle.YesNoCancel) = vbYes Then
                    InsertQABugRecords(Me.CurrentEditStationLine, 0)
                End If
            End If
            ReLoadDBQABugRecords()
        End If

        Me.RefreshAllEnableControl()
        If CurrentEditStationLine = Me.CanEditStationLine Then
            AddNewEditBugORThickRecord()
        Else
            BugItemEditControl.Visible = False
        End If
        If Not IsNothing(ThicknessEditControlEvent) Then
            ThicknessEditControlEvent.Visible = False
        End If
    End Sub

    Private Sub MainControl_Load(sender As Object, e As EventArgs) Handles Me.Load
        '預設值測試用(開發時請開啟)
        'LoginID = 30276
        'CanEditStationLine = "APL1"
        'EditCoilNumber = "Q1005"
        'EditStationName = CanEditStationLine
        'CanEditStationLine = "APL1"

        Dim GetClientIP As String = CompanyORMDB.DeviceInformation.GetLocalIPs(0).Trim
        If Not String.IsNullOrEmpty(GetClientIP) Then
            Select Case True
                'Case GetClientIP = "10.1.3.52"
                '    CanEditStationLine = "APL2"
                '    Me.UserLoginControl.CompulsiveEditStationName = CanEditStationLine
                Case GetClientIP = "10.12.7.21"
                    CanEditStationLine = "APL1"
                    Me.UserLoginControl.CompulsiveEditStationName = CanEditStationLine
                Case GetClientIP = "10.12.2.21"
                    CanEditStationLine = "APL2"
                    Me.UserLoginControl.CompulsiveEditStationName = CanEditStationLine
                Case GetClientIP = "10.12.21.21"
                    CanEditStationLine = "BAL"
                    Me.UserLoginControl.CompulsiveEditStationName = CanEditStationLine
                Case Else
                    CanEditStationLine = "APL1"
            End Select
        End If

        '監看L2訊號
        If Not IsNothing(L2MessageWatchControl) AndAlso L2MessageWatchControl.StartWatch() = False Then  'Server端開始監控Level2之訊號及接收
            MsgBox("無法連線接L2訊號伺服器請洽資訊處系統管理員!")
        End If
        GoRunNextInputProcess()
        ValidCanEditCoilFullNumberIsOnLineCoilFullNumber(True)
        StartUseOPCServerGetData()
    End Sub


    Private Sub btnPageDown_Click(sender As Object, e As EventArgs) Handles btnPageDown.Click, btnPageUP.Click
        If sender Is btnPageDown Then
            ShowPageNumber += 1
        Else
            ShowPageNumber -= 1
        End If

        Select Case True
            Case TabControl1.SelectedTab Is tpBugEdit
                ReDisplayQABugRecordShowControls()
                Dim flpItemContainer As FlowLayoutPanel = Nothing
                For Each EachItem As Control In tlpItems.Controls
                    If TypeOf EachItem Is FlowLayoutPanel Then
                        flpItemContainer = EachItem : Exit For
                    End If
                Next
                If Not IsNothing(flpItemContainer) Then
                    Dim ScrollToControl As Control = Nothing
                    If flpItemContainer.Controls.Count > (ShowPageNumber - 1) * 9 Then
                        ScrollToControl = flpItemContainer.Controls((ShowPageNumber - 1) * 9)
                    End If
                    If Not IsNothing(ScrollToControl) Then
                        flpItemContainer.VerticalScroll.Value = flpItemContainer.VerticalScroll.Maximum
                        flpItemContainer.ScrollControlIntoView(ScrollToControl)
                    End If
                End If
            Case TabControl1.SelectedTab Is tpThicknessEdit
                ReDisplayQAThicknessRecordShowControls()
        End Select

        Me.RefreshAllEnableControl()
    End Sub


    Public Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        If btnExit.Text = "離開" Then
            btnExit.Text = "確認離開" : Exit Sub
        End If
        RaiseEvent ExitSystem(Me)
    End Sub

    Private Sub tbLogin_Click(sender As Object, e As EventArgs) Handles tbLogin.Click
        '開啟入控制項
        TabControl1.SelectedTab = tpBugEdit
        ShowControlToFullEditArea(UserLoginControl)
        UserLoginControl.RefreshDisplay()
        Me.RefreshAllEnableControl()

    End Sub

    Private Sub UserLoginControlEvent_UserLoginEvent(sender As MainControl_UserLogin, LoginID As String, EditLineStation As String) Handles UserLoginControlEvent.UserLoginEvent
        '入控制項返回事件
        Me.LoginID = LoginID.Trim
        Me.CanEditStationLine = EditLineStation.Trim
        Dim OldEditStationLineName As String = Me.CurrentEditStationLine
        Me.CurrentEditStationLine = Me.CanEditStationLine


        '重新設定監看L2訊號
        If Not String.IsNullOrEmpty(OldEditStationLineName) AndAlso _
            Not String.IsNullOrEmpty(Me.CurrentEditStationLine) AndAlso _
            OldEditStationLineName <> Me.CurrentEditStationLine _
            And Not IsNothing(L2MessageWatchControl) Then
            L2MessageWatchControl.StopWatch() : L2MessageWatchControl = Nothing
            If L2MessageWatchControl.StartWatch() = False Then  'Server端開始監控Level2之訊號及接收
                MsgBox("無法連線接L2訊號伺服器請洽資訊處系統管理員!")
            End If
        End If



        'ReLoadDBQABugRecords()
        'ReDisplayQABugRecordShowControls()
        GoRunNextInputProcess()
        Me.RefreshAllEnableControl()
    End Sub

    Private Sub TabControl1_Selected(sender As Object, e As TabControlEventArgs) Handles TabControl1.Selected
        ShowPageNumber = ShowPageNumber
        Select Case True
            Case TabControl1.SelectedTab Is tpBugEdit
                ReLoadDBQABugRecords()
                AddNewEditBugORThickRecord()
            Case TabControl1.SelectedTab Is tpThicknessEdit
                ReLoadDBQAThicknessRecords()
                AddNewEditBugORThickRecord()
            Case TabControl1.SelectedTab Is tpQuickOperator
                flpQuickOperator.Enabled = (CurrentEditStationLine = CanEditStationLine)
                LoadQuickInputButtonToArea()
            Case TabControl1.SelectedTab Is tpOtherEdit
                Static LastSetStationNameControl As String = Nothing
                Static OldCoilOtherInfoControl As Control = Nothing
                If String.IsNullOrEmpty(LastSetStationNameControl) OrElse LastSetStationNameControl <> CurrentEditStationLine _
                    OrElse Not OldCoilOtherInfoControl Is CoilOtherInfoControl Then
                    Me.tpOtherEdit.Controls.Clear()
                    Me.tpOtherEdit.Controls.Add(CoilOtherInfoControl)
                    CType(CoilOtherInfoControl, Control).Enabled = (CurrentEditStationLine = CanEditStationLine)
                    CType(CoilOtherInfoControl, Control).Dock = DockStyle.Fill
                    LastSetStationNameControl = CurrentEditStationLine
                    OldCoilOtherInfoControl = CoilOtherInfoControl
                End If
                CoilOtherInfoControl.InitControlValue()
        End Select
        RefreshAllEnableControl()
    End Sub

    Private Sub BugItemEditControlEvent_CallBackEvent(Sender As Object, FinishEditData As QABugRecord) Handles BugItemEditControlEvent.CallBackEvent
        '編修詳細缺陷控制項事件返回
        BALBrightPositionMMFromBugPosition(FinishEditData)  'BAL部份需將缺陷33米數更新亮度米數
        Me.BugItemEditControlEvent.Visible = False
        ReLoadDBQABugRecords()
        ReDisplayQABugRecordShowControls()
        Me.RefreshAllEnableControl()
        ScrollToDataControl(FinishEditData)         '將Scrollbar導向剛才編修之資料
        AddNewEditBugORThickRecord()
    End Sub

    Private Sub BugItemEditControlEvent_CallBackCancelEvent(Sender As Object, FinishEditData As QABugRecord) Handles BugItemEditControlEvent.CallBackCancelEvent
        Me.RefreshAllEnableControl()
        Call ScrollToDataControl(FinishEditData)
        For Each EachControl As Control In tlpBugEditTable.Controls
            If TypeOf EachControl Is BugItemEdit Then
                tlpBugEditTable.Controls.Remove(EachControl) : Exit Sub
            End If
        Next
    End Sub

    Private Sub ThicknessEditControlEvent_CallBackEvent(Sender As Object, FinishEditData As QAThickness) Handles ThicknessEditControlEvent.CallBackEvent
        '編修詳細實測厚度控制項事件返回
        'Me.ThicknessEditControlEvent.Visible = False
        ReLoadDBQAThicknessRecords()
        AddNewEditBugORThickRecord()
        ReDisplayQAThicknessRecordShowControls()
        Me.RefreshAllEnableControl()
        APL2BALBugPositionFromThickPosition(FinishEditData)
    End Sub


    Private Sub btnInsertBug33s_Click(sender As Object, e As EventArgs) Handles btnInsertBug33s.Click
        If Me.CanEditStationLine <> Me.CurrentEditStationLine Then
            Exit Sub
        End If
        '取得所有資料最後一筆的儲存時間
        Dim LastSaveTime As DateTime
        For Each EachItem As BugItemMinDisplay In Me.QABugRecordShowControls
            If EachItem.QABugRecordData.DataCreateTime > LastSaveTime Then
                LastSaveTime = EachItem.QABugRecordData.DataCreateTime
            End If
        Next
        LastSaveTime = IIf(LastSaveTime < Now, Now, LastSaveTime)

        For InsertTimes As Integer = 1 To 4
            Dim QuickInsertObject As QABugRecord = New QABugRecord
            With QuickInsertObject
                .CoilNumber = EditCoilNumber
                .EditEmployeeID = LoginID
                .DataDate = EditDataDate
                .StationName = EditStationName
                .DataCreateTime = LastSaveTime.AddSeconds(InsertTimes)
                .QABug_Number = 33
                .Degree = 4
                Select Case True
                    Case Me.CanEditStationLine = "APL1" AndAlso APL1CoilPosition > 0
                        .StartPosition = APL1CoilPosition
                    Case Me.CanEditStationLine = "APL2" AndAlso APL2CoilPosition > 0
                        .StartPosition = APL2CoilPosition
                    Case Me.CanEditStationLine = "BAL" AndAlso BALCoilPosition > 0
                        .StartPosition = BALCoilPosition
                    Case Else
                        .StartPosition = 1
                End Select
                .EndPosition = CoilMaxLength
                .DPositionStart = 1
                .DPositionEnd = 1
                .Density = 3
                .CoilMaxLength = CoilMaxLength
                Select Case InsertTimes
                    Case 1
                        .DPositionType = 1  '內
                        .PosOrNeg = 1
                    Case 2
                        .DPositionType = 3  '外
                        .PosOrNeg = 1
                    Case 3
                        .DPositionType = 1  '內
                        .PosOrNeg = 2
                    Case 4
                        .DPositionType = 3  '外
                        .PosOrNeg = 2
                    Case Else
                        Continue For
                End Select
                .CDBSave()
            End With
        Next
        Me.TabControl1.SelectedTab = tpBugEdit
    End Sub

    Private Sub CoilOtherInfoControlEvent_CallBackEvent(Sender As Object, ReturnValue As String) Handles CoilOtherInfoControlEvent.CallBackEvent
        TabControl1.SelectedTab = tpBugEdit
        BugItemEditControl.EditQABugRecord = BugItemEditControl.EditQABugRecord '重整畫面資料用
    End Sub

    Private Sub TabControl1_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles TabControl1.Selecting
        Static PreSelectTabPage As TabPage = Nothing
        If Not IsNothing(PreSelectTabPage) AndAlso PreSelectTabPage Is tpOtherEdit AndAlso PreSelectTabPage.Controls.Count > 0 Then
            CType(PreSelectTabPage.Controls(0), IxxxTitleEdit).SaveControlDataToDB()
        End If
        PreSelectTabPage = e.TabPage
    End Sub

    Private Sub CoilOtherInfoControlEvent_MessageEvent(Message As String) Handles CoilOtherInfoControlEvent.MessageEvent
        Me.lbMessage.Text = Message
    End Sub


    Private Sub L2MessageWatchControlEvent_FileChangedEvent(sender As Object, e As IO.FileSystemEventArgs, L2Message As L2Message1) Handles L2MessageWatchControlEvent.FileChangedEvent
        Dim cb As New ProcessL2MessageAndUpdateUI(AddressOf ProcessL2Message)
        Me.BeginInvoke(cb, L2Message)
    End Sub

    Private Sub tbPrint_Click(sender As Object, e As EventArgs) Handles tbPrint.Click
        If Not IsCanWorkDataReady Then
            lbMessage.Text = "基本資料不完整,無法印表!"
            Exit Sub
        End If
        If TabControl1.SelectedTab Is tpOtherEdit AndAlso Not IsNothing(Me.CoilOtherInfoControl) Then
            Me.CoilOtherInfoControl.SaveControlDataToDB()
        End If

        '' Print(Me.EditCoilNumber, Me.EditOutCoilNumber, Me.EditDataDate, Me.CanEditStationLine, Me.EditDataDateVersion)

        ''Print Report
        Print(Me.EditCoilNumber, Me.EditOutCoilNumber, Me.EditDataDate, Me.CanEditStationLine, Me.EditDataDateVersion)

        '測試期間關閉資料轉換
        Try
            If IsOnLineMachine Then
                Me.CurrentEditQABugRecordTitle.SaveBugDataToAS400() '現場電腦印表時資料直接轉AS400
            Else
                If MsgBox("是否要將目前資料轉至AS400", MsgBoxStyle.YesNoCancel, "注意") = vbYes Then
                    Me.CurrentEditQABugRecordTitle.SaveBugDataToAS400() '非現場電腦印表時資料直接轉AS400
                End If
            End If
        Catch ex As Exception
            Dim MailObject As New PublicClassLibrary.MISMail
            With MailObject
                .ToMailAddress.Add(New MailAddress("kuku@mail.tangeng.com.tw", "古政剛"))
                .ToMailAddress.Add(New MailAddress("planckli@mail.tangeng.com.tw", "利嘉翔"))
                .ToMailAddress.Add(New MailAddress("30355@mail.tangeng.com.tw", "龔泓璋"))
                .SendMail("品管缺陷資料轉AS400處理發生錯誤通知!", "產線:" & Me.EditStationName & "  " & Me.EditOutCoilNumber & "資料轉換!" & vbNewLine & "錯誤訊息:" & ex.ToString)
            End With
            Me.lbMessage.Text = "注意:品管缺陷資料轉AS400處理發生錯誤!"
        End Try
    End Sub

    Private Sub btnQuckSetAP2AllValues_Click(sender As Object, e As EventArgs) Handles btnQuckSetAP2AllValues.Click
        If btnQuckSetAP2AllValues.Text = "本線環境預設" Then
            btnQuckSetAP2AllValues.Text = "確認本線環境重新預設?"
            Exit Sub
        End If
        'APL2QuickSetValue()
        QuickSetValue()
        btnQuckSetAP2AllValues.Text = "本線環境預設"
    End Sub


    ''106/08/09 Add 雙面鏡功能
    ''紀錄目前QAThicknessRecordShowControls的值，Set至BALOthersEdit
    Public Shared Function returnQAThick_Item()

        Dim returnValue As String = ""

        If tempQAThick Is Nothing Then
            Return ""
        End If

        For i As Integer = 0 To tempQAThick.Count - 1

            returnValue &= tempQAThick(i).Length & ","
        Next
        Return returnValue.ToString()
    End Function

    ''106/08/16 ADD
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        'If (Me.CoilOtherInfoControl IsNot Nothing) Then
        '    Me.CoilOtherInfoControl.SetUpDown_Status(coilUpDown_Status)
        'End If

        If coilUpDown_Status = "上收" Then
            radBtn_UP.Checked = True
            radBtn_Down.Checked = False
        ElseIf coilUpDown_Status = "下收" Then
            radBtn_UP.Checked = False
            radBtn_Down.Checked = True
        Else
            radBtn_UP.Checked = False
            radBtn_Down.Checked = False
        End If

    End Sub
    ''106/08/29 ADD
    Private Sub initialRadioBtn_UpDown()
        '根據每一站決定初始上下收狀態
        If trigger = True Then
            If EditStationName = "APL1" Or EditStationName = "BAL" Then
                radBtn_UP.Checked = False
                radBtn_Down.Checked = True

                radBtn_UP.BackColor = Color.Transparent
                radBtn_Down.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffdad3")

            Else
                radBtn_UP.Checked = False
                radBtn_Down.Checked = False


                radBtn_UP.BackColor = Color.Transparent
                radBtn_Down.BackColor = Color.Transparent
            End If

            trigger = False
        End If
    End Sub

    Private Sub radBtn_UP_CheckedChanged(sender As Object, e As EventArgs) Handles radBtn_UP.CheckedChanged
        If radBtn_UP.Checked = True And radBtn_Down.Checked = False Then
            radBtn_UP.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffdad3")
            radBtn_Down.BackColor = Color.Transparent
        ElseIf radBtn_UP.Checked = False And radBtn_Down.Checked = True Then
            radBtn_UP.BackColor = Color.Transparent
            radBtn_Down.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffdad3")
        Else
            radBtn_UP.BackColor = Color.Transparent
            radBtn_Down.BackColor = Color.Transparent
        End If

    End Sub
End Class
