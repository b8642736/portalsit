Public Class LabelPrint

    Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
    Declare Auto Function SetForegroundWindow Lib "USER32.DLL" (ByVal hWnd As IntPtr) As Boolean



#Region "列印資料 屬性:PrintDatas"

    Private _PrintDatas As ColdRollingClientDataSet.CoilLabelDataSetDataTable
    ''' <summary>
    ''' 列印資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PrintDatas() As ColdRollingClientDataSet.CoilLabelDataSetDataTable
        Get
            Return _PrintDatas
        End Get
        Private Set(ByVal value As ColdRollingClientDataSet.CoilLabelDataSetDataTable)
            _PrintDatas = value
            Me.BSCoilLabelDataSet.DataSource = _PrintDatas
        End Set
    End Property

#End Region
#Region "是否直接列印 屬性:IsDirectPrit"

    Private _IsDirectPrit As Boolean = False
    ''' <summary>
    ''' 是否直接列印
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsDirectPrit() As Boolean
        Get
            Return _IsDirectPrit
        End Get
        Private Set(ByVal value As Boolean)
            _IsDirectPrit = value
        End Set
    End Property

#End Region
#Region "傳送Enter指令至列印視窗 方法:SendKeyForPrintWindow"
    ''' <summary>
    ''' 傳送Enter指令至列印視窗
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SendKeyForPrintWindow(Optional ByVal DelayMilliSeconds As Double = 2000)
        Dim hWnd As Integer
        For PrintTimes As Integer = 1 To 5
            Threading.Thread.Sleep(DelayMilliSeconds)
            hWnd = FindWindow(vbNullString, "列印")
            If hWnd Then
                SetForegroundWindow(hWnd)
                SendKeys.SendWait("{Enter}")
                Exit Sub
            End If
        Next
        MsgBox("未找到列印視窗!")

        'If hWnd Then
        '    SetForegroundWindow(hWnd)
        '    SendKeys.SendWait("{Enter}")
        'Else
        '    MsgBox("未找到列印視窗!")
        'End If
    End Sub
#End Region
#Region "取得手動輸入資料 方法:GetManualInputData"
    ''' <summary>
    ''' 取得手動輸入資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetManualInputData() As ColdRollingClientDataSet.CoilLabelDataSetDataTable
        Dim ReturnValue As New ColdRollingClientDataSet.CoilLabelDataSetDataTable
        Dim AddItem As ColdRollingClientDataSet.CoilLabelDataSetRow = ReturnValue.NewRow
        With AddItem
            .序號 = TextBox1.Text.Trim
            .鋼捲編號 = TextBox2.Text.Trim
            .重量或長度 = TextBox4.Text.Trim
            .厚度 = TextBox5.Text.Trim
            .寬度 = TextBox6.Text.Trim
            .產出日期時間 = Format(DateTimePicker1.Value, "yyyy/MM/dd hh:mm:ss")
            .班別 = TextBox8.Text.Trim
            .規格 = TextBox3.Text.Trim
            .線別 = TextBox9.Text.Trim
            .用途 = TextBox10.Text.Trim
            .外銷 = IIf(RadioButton1.Checked, "內銷", "外銷")
            .檢驗員 = TextBox12.Text.Trim
            .鋼種規格 = TextBox7.Text.Trim
            .客戶編號 = TextBox11.Text.Trim
        End With
        ReturnValue.Rows.Add(AddItem)
        For CopyTime As Integer = 1 To NumericUpDown1.Value - 1
            ReturnValue.Merge(ReturnValue.Copy)
        Next
        Return ReturnValue
    End Function
#End Region

#Region "序號手動調整 屬性:SerialNumberJudge"
    Private Shared _SerialNumberJudge As Integer
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property SerialNumberJudge() As Integer
        Get
            Return _SerialNumberJudge
        End Get
        Set(ByVal value As Integer)
            _SerialNumberJudge = value
        End Set
    End Property

#End Region

#Region "設定列印資料 函式:SetPrintDatasAndPrint"
    ''' <summary>
    ''' 設定列印資料
    ''' </summary>
    ''' <param name="SetDatas"></param>
    ''' <param name="SetIsDirectToPrint"></param>
    ''' <remarks></remarks>
    Public Sub SetPrintDatasAndPrint(ByVal SetDatas As ColdRollingClientDataSet.CoilLabelDataSetDataTable, ByVal SetIsDirectToPrint As Boolean, ByVal SetPrintStationName As String)
        Me.IsDirectPrit = SetIsDirectToPrint
        Me.PrintDatas = SetDatas
        If SetPrintStationName.Trim.ToUpper.PadRight(3).Substring(0, 3) = "TLL" OrElse SetPrintStationName.Trim.ToUpper.PadRight(3).Substring(0, 3) = "SBL" OrElse SetPrintStationName.Trim.ToUpper.PadRight(3).Substring(0, 3) = "SPL" OrElse SetPrintStationName.Trim.ToUpper.PadRight(4).Substring(0, 4) = "APL2" Then
            ReportViewer1.Visible = False
            ReportViewer1.Dock = DockStyle.None
            ReportViewer2.Visible = True
            ReportViewer2.Dock = DockStyle.Fill
            ReportViewer2.BringToFront()
            ReportViewer2.RefreshReport()
        Else
            ReportViewer2.Visible = False
            ReportViewer2.Dock = DockStyle.None
            ReportViewer1.Visible = True
            ReportViewer1.Dock = DockStyle.Fill
            ReportViewer1.BringToFront()
            ReportViewer1.RefreshReport()
        End If

        Dim SetData As ColdRollingClientDataSet.CoilLabelDataSetRow = SetDatas(0)
        If Not SetData.Is序號Null Then
            Me.TextBox1.Text = SetData.序號
        End If
        If Not SetData.Is鋼捲編號Null Then
            Me.TextBox2.Text = SetData.鋼捲編號
        End If
        If Not SetData.Is鋼種規格Null Then
            Me.TextBox7.Text = SetData.鋼種規格.Trim
        End If
        If Not SetData.Is規格Null Then
            Me.TextBox3.Text = SetData.規格
        End If
        If Not SetData.Is重量或長度Null Then
            Me.TextBox4.Text = SetData.重量或長度
        End If
        If Not SetData.Is厚度Null Then
            Me.TextBox5.Text = SetData.厚度
        End If
        If Not SetData.Is寬度Null Then
            Me.TextBox6.Text = SetData.寬度
        End If

        If Not SetData.Is產出日期時間Null Then
            Me.DateTimePicker1.Value = CType(SetData.產出日期時間, DateTime)
        End If
        If Not SetData.Is班別Null Then
            Me.TextBox8.Text = SetData.班別
        End If
        If Not SetData.Is線別Null Then
            Me.TextBox9.Text = SetData.線別
        End If
        If Not SetData.Is用途Null Then
            Me.TextBox10.Text = SetData.用途
        End If
        If Not SetData.Is外銷Null Then
            If SetData.外銷 = "內銷" Then
                RadioButton1.Checked = True
            Else
                RadioButton2.Checked = True
            End If
        End If
        If Not SetData.Is檢驗員Null Then
            Me.TextBox12.Text = SetData.檢驗員
        End If
        If Not SetData.Is客戶編號Null Then
            TextBox11.Text = SetData.客戶編號
        End If
    End Sub

#End Region
#Region "無使用介面快速直接列印 函式:UnUIQuickPrint"
    Private Shared LabelPrintControl As LabelPrint = Nothing
    ''' <summary>
    ''' 無使用介面直接列印
    ''' </summary>
    ''' <param name="SetDatas"></param>
    ''' <remarks></remarks>
    Public Shared Sub UnUIQuickPrint(ByVal SetDatas As ColdRollingClientDataSet.CoilLabelDataSetDataTable, ByVal SetPrintStationName As String)
        If IsNothing(LabelPrintControl) Then
            LabelPrintControl = New LabelPrint
            LabelPrintControl.IsDirectPrit = True
        End If
        LabelPrintControl.SetPrintDatasAndPrint(SetDatas, True, SetPrintStationName)
    End Sub

    Public Shared Sub UnUIQuickPrint(ByVal SetPrintPrintRunProcessDatas As RunProcessData, ByVal SetPrintStationName As String, Optional ByVal CopyTimes As Integer = 1)
        If IsNothing(SetPrintPrintRunProcessDatas) Then
            Exit Sub
        End If
        Dim PrintData As New ColdRollingClientDataSet.CoilLabelDataSetDataTable
        Dim PrintDataRow As ColdRollingClientDataSet.CoilLabelDataSetRow = PrintData.NewRow
        Dim GetAboutLastRefPPSSHAPF As CompanyORMDB.IPPS100LB.IPPSSHAPF = SetPrintPrintRunProcessDatas.AboutLastRefPPSSHAPF
        Dim AboutSL2CICPF As CompanyORMDB.SLS300LB.SL2CICPF = Nothing
        With PrintDataRow
            .鋼捲編號 = SetPrintPrintRunProcessDatas.FK_OutSHA01 & SetPrintPrintRunProcessDatas.FK_OutSHA02.Trim
            .厚度 = Format(SetPrintPrintRunProcessDatas.Guage, "0.00")
            .寬度 = SetPrintPrintRunProcessDatas.Width
            'If Not String.IsNullOrEmpty(SetPrintStationName) AndAlso SetPrintStationName.Trim.ToUpper = "TLL" Then
            '    .產出日期時間 = Format(SetPrintPrintRunProcessDatas.CoilEndTime, "yyyy/MM/dd")
            '    .重量或長度 = ""
            'Else
            '    .產出日期時間 = SetPrintPrintRunProcessDatas.CoilEndTime
            '    'APL/CPL 強制印重量
            '    .重量或長度 = IIf(SetPrintPrintRunProcessDatas.Length > 0 And Not {"APL", "CPL"}.Contains(SetPrintStationName.PadRight(3).Substring(0, 3).ToUpper), "長:" & SetPrintPrintRunProcessDatas.Length, "重:" & SetPrintPrintRunProcessDatas.Weight)
            'End If
            Select Case True
                Case SetPrintStationName.Trim.ToUpper = "TLL"
                    '成品線或成品特殊列印
                    .產出日期時間 = Format(SetPrintPrintRunProcessDatas.CoilEndTime, "yyyy/MM/dd")
                    .重量或長度 = ""
                Case SetPrintStationName.Trim.ToUpper.PadRight(3).Substring(0, 3) = "SBL" OrElse SetPrintStationName.Trim.ToUpper.PadRight(3).Substring(0, 3) = "SPL" OrElse SetPrintStationName.Trim.ToUpper = "APL2"
                    '成品線或成品特殊列印
                    .產出日期時間 = SetPrintPrintRunProcessDatas.CoilEndTime
                    'APL 強制印重量
                    .重量或長度 = IIf(SetPrintPrintRunProcessDatas.Length > 0 And Not {"APL"}.Contains(SetPrintStationName.PadRight(3).Substring(0, 3).ToUpper), SetPrintPrintRunProcessDatas.Length, SetPrintPrintRunProcessDatas.Weight)
                Case Else
                    .產出日期時間 = SetPrintPrintRunProcessDatas.CoilEndTime
                    'APL/CPL 強制印重量
                    .重量或長度 = "      " & IIf(SetPrintPrintRunProcessDatas.Length > 0 And Not {"APL", "CPL"}.Contains(SetPrintStationName.PadRight(3).Substring(0, 3).ToUpper), "長:" & SetPrintPrintRunProcessDatas.Length, "重:" & SetPrintPrintRunProcessDatas.Weight)
            End Select

            If Not String.IsNullOrEmpty(SetPrintPrintRunProcessDatas.FK_RunStationName) AndAlso SetPrintPrintRunProcessDatas.FK_RunStationName.Substring(0, 3) = "CPL" Then
                .序號 = SetPrintPrintRunProcessDatas.TheSerialNumberForStation + SerialNumberJudge
            End If
            .線別 = SetPrintStationName
            .班別 = CompanyORMDB.TABLE.TABLE7PF.GetClassNumber(SetPrintStationName, SetPrintPrintRunProcessDatas.CoilEndTime)
            If Not IsNothing(GetAboutLastRefPPSSHAPF) Then
                .外銷 = IIf(GetAboutLastRefPPSSHAPF.SHA35.Trim = "", "內銷", "外銷")
                Select Case True
                    Case SetPrintStationName.Trim.Length >= 3 AndAlso (SetPrintStationName.Trim = "SPL" OrElse SetPrintStationName.Trim = "SBL" OrElse SetPrintStationName.Trim = "TLL")
                        .規格 = GetAboutLastRefPPSSHAPF.SHA39 '成品線直接印計劃表面
                    Case SetPrintStationName.Trim.Length >= 3 AndAlso SetPrintStationName.Trim.Substring(0, 3) = "CPL"
                        .規格 = ""
                    Case Else
                        .規格 = GetAboutLastRefPPSSHAPF.SHA06
                End Select

                Select Case True
                    Case SetPrintStationName.Trim.Length >= 3 AndAlso SetPrintStationName.Trim.Substring(0, 3) = "CPL"
                        'Dim FindSL2CH1PF As CompanyORMDB.SLS300LB.SL2CH1PF = CompanyORMDB.SLS300LB.SL2CH1PF.FindSL2CH1PF(GetAboutLastRefPPSSHAPF.SHA12, GetAboutLastRefPPSSHAPF.SHA13)
                        'If Not IsNothing(FindSL2CH1PF) Then
                        '    .鋼種規格 = FindSL2CH1PF.CH104.Trim
                        'Else
                        'End If
                        If GetAboutLastRefPPSSHAPF.SHA13.PadRight(2).Substring(0, 2) = "TE" Then
                            .鋼種規格 = GetAboutLastRefPPSSHAPF.SHA13.PadRight(2).Substring(0, 2) & GetAboutLastRefPPSSHAPF.SHA12 & IIf(GetAboutLastRefPPSSHAPF.SHA13.Trim.Length > 2, "-" & GetAboutLastRefPPSSHAPF.SHA13.PadRight(4).Substring(2, 2).Trim, "")
                        Else
                            .鋼種規格 = GetAboutLastRefPPSSHAPF.SHA12 & IIf(GetAboutLastRefPPSSHAPF.SHA13.Trim.Length > 0, "-" & GetAboutLastRefPPSSHAPF.SHA13.Trim, "")
                        End If
                    Case Else
                        .鋼種規格 = GetAboutLastRefPPSSHAPF.SHA12.Trim & GetAboutLastRefPPSSHAPF.SHA13
                End Select
                AboutSL2CICPF = GetAboutLastRefPPSSHAPF.AboutSL2CICPF
                If Not IsNothing(AboutSL2CICPF) Then
                    .客戶編號 = AboutSL2CICPF.CIC10.Substring(0, 3)
                Else
                    .客戶編號 = "---"
                End If
            End If

        End With

        PrintData.Rows.Add(PrintDataRow)
        Dim PrintDataTemp As New ColdRollingClientDataSet.CoilLabelDataSetDataTable
        PrintDataTemp.Merge(PrintData.Copy())
        For CopyCount As Integer = 2 To CopyTimes
            PrintData.Merge(PrintDataTemp.Copy())
        Next

        UnUIQuickPrint(PrintData, SetPrintStationName)
    End Sub

#End Region

#Region "離開事件 事件:ExitEvent"
    ''' <summary>
    ''' 離開事件
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <remarks></remarks>
    Public Event ExitEvent(ByVal Sender As LabelPrint)
#End Region



    Private Sub btnInputAndPreViewPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInputAndPreViewPrint.Click, btnInputAndDirectPrint.Click
        Try
            If sender Is btnInputAndPreViewPrint Then
                TabControl1.SelectedTab = TabPage1
            Else
                IsDirectPrit = True
            End If
            PrintDatas = GetManualInputData()

            If ReportViewer1.Visible Then
                ReportViewer1.RefreshReport()
            Else
                ReportViewer2.RefreshReport()
            End If

        Catch ex As Exception
            MsgBox("輸入資料有誤!" & ex.ToString)
            Exit Sub
        End Try
    End Sub

    Private Sub ReportViewer1_RenderingComplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) Handles ReportViewer1.RenderingComplete, ReportViewer2.RenderingComplete
        If IsDirectPrit Then
            IsDirectPrit = False
            Dim NewThread As New Threading.Thread(AddressOf SendKeyForPrintWindow)
            NewThread.Priority = Threading.ThreadPriority.Highest
            NewThread.Start()
            CType(sender, Microsoft.Reporting.WinForms.ReportViewer).PrintDialog()
            RaiseEvent ExitEvent(Me)
        End If
    End Sub

    Private Sub tbSpecialSerialNumberAdjust_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbSpecialSerialNumberAdjust.TextChanged
        SerialNumberJudge = Val(tbSpecialSerialNumberAdjust.Text)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
