Public Class CPL
    Implements IStationRunningControl



#Region "編輯中資料 屬性:EdittingData"
    ''' <summary>
    ''' 編輯中資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property EdittingData As CompanyORMDB.SQLServer.PPS100LB.RunProcessData Implements IStationRunningControl.EdittingData
        Get
            Return Me.bsDataSource.Current
        End Get
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
    Public Property ParentControl_CoilScanAndMachineProcess As CoilScanAndMachineProcess Implements IStationRunningControl.ParentControl_CoilScanAndMachineProcess
        Get
            Return _ParentControl_CoilScanAndMachineProcess
        End Get
        Private Set(value As CoilScanAndMachineProcess)
            _ParentControl_CoilScanAndMachineProcess = value
        End Set
    End Property
#End Region
#Region "重整下拉選單Bind資料來源 函式:RefreshBindPullDownMenuData"
    ''' <summary>
    ''' 重整下拉選單Bind資料來源
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshBindPullDownMenuData()
        ColdRollingClientDataSet.PackageSelectTable0.Rows.Clear()
        ColdRollingClientDataSet.PackageSelectTable1.Rows.Clear()
        ColdRollingClientDataSet.PackageSelectTable2.Rows.Clear()
        Dim AddItem0 As ColdRollingClientDataSet.PackageSelectTable0Row
        AddItem0 = ColdRollingClientDataSet.PackageSelectTable0.NewRow
        With AddItem0
            .Item("襯紙夾整捲") = "無"
            .Item("值") = "N"
        End With
        ColdRollingClientDataSet.PackageSelectTable0.Rows.Add(AddItem0)

        AddItem0 = ColdRollingClientDataSet.PackageSelectTable0.NewRow
        With AddItem0
            .Item("襯紙夾整捲") = "有"
            .Item("值") = "Y"
        End With
        ColdRollingClientDataSet.PackageSelectTable0.Rows.Add(AddItem0)



        Dim AddItem1 As ColdRollingClientDataSet.PackageSelectTable1Row
        AddItem1 = ColdRollingClientDataSet.PackageSelectTable1.NewRow
        With AddItem1
            .Item("厚薄") = "無"
            .Item("值") = "N"
        End With
        ColdRollingClientDataSet.PackageSelectTable1.Rows.Add(AddItem1)

        AddItem1 = ColdRollingClientDataSet.PackageSelectTable1.NewRow
        With AddItem1
            .Item("厚薄") = "薄"
            .Item("值") = "1"
        End With
        ColdRollingClientDataSet.PackageSelectTable1.Rows.Add(AddItem1)

        AddItem1 = ColdRollingClientDataSet.PackageSelectTable1.NewRow
        With AddItem1
            .Item("厚薄") = "厚"
            .Item("值") = "2"
        End With
        ColdRollingClientDataSet.PackageSelectTable1.Rows.Add(AddItem1)


        Dim AddItem2 As ColdRollingClientDataSet.PackageSelectTable2Row
        AddItem2 = ColdRollingClientDataSet.PackageSelectTable2.NewRow
        With AddItem2
            .Item("是否使用紙套筒") = "無"
            .Item("值") = "N"
        End With
        ColdRollingClientDataSet.PackageSelectTable2.Rows.Add(AddItem2)

        AddItem2 = ColdRollingClientDataSet.PackageSelectTable2.NewRow
        With AddItem2
            .Item("是否使用紙套筒") = "薄板"
            .Item("值") = "Y"
        End With
        ColdRollingClientDataSet.PackageSelectTable2.Rows.Add(AddItem2)


        Dim AddItem3 As ColdRollingClientDataSet.PackageSelectTable3Row
        AddItem3 = ColdRollingClientDataSet.PackageSelectTable3.NewRow
        With AddItem3
            .Item("是否奇力龍包整捲") = "是"
            .Item("值") = "Y"
        End With
        ColdRollingClientDataSet.PackageSelectTable3.Rows.Add(AddItem3)

        AddItem3 = ColdRollingClientDataSet.PackageSelectTable3.NewRow
        With AddItem3
            .Item("是否奇力龍包整捲") = "否"
            .Item("值") = "N"
        End With
        ColdRollingClientDataSet.PackageSelectTable3.Rows.Add(AddItem3)

    End Sub
#End Region



    Public Sub New(ByVal SetDefaultData As CompanyORMDB.SQLServer.PPS100LB.RunProcessData, ByVal SetCoilScanAndMachineProcess As CoilScanAndMachineProcess)

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        '在 InitializeComponent() 呼叫之後加入任何初始設定。
        Me.ParentControl_CoilScanAndMachineProcess = SetCoilScanAndMachineProcess
        RefreshBindPullDownMenuData()   '重整下拉選單Bind資料來源
        Me.bsDataSource.Clear()
        Me.bsDataSource.Add(SetDefaultData)
        Dim LastRefPPSSHAPF As CompanyORMDB.IPPS100LB.IPPSSHAPF = SetDefaultData.AboutLastRefPPSSHAPF

    End Sub


    Private Sub bsDataSource_CurrentChanged(sender As Object, e As System.EventArgs) Handles bsDataSource.CurrentChanged
        lbIsHeadOrTail.BackColor = Me.BackColor
        lbRunLine.BackColor = Me.BackColor
        tbAttention.BackColor = Me.BackColor
        lbThekindStationRunCount.BackColor = Me.BackColor
        If Not IsNothing(EdittingData) AndAlso EdittingData.HeadTailDescript = "頭塊" OrElse EdittingData.HeadTailDescript = "尾塊" Then
            lbIsHeadOrTail.BackColor = Color.Coral
        End If
        If Not IsNothing(EdittingData) AndAlso Not String.IsNullOrEmpty(EdittingData.Attention) Then
            tbAttention.BackColor = Color.Coral
        End If
        If Val(lbThekindStationRunCount.Text) > 0 Then
            lbThekindStationRunCount.BackColor = Color.Coral
        End If
        If Not IsNothing(EdittingData) AndAlso Not String.IsNullOrEmpty(EdittingData.AboutLastOutPPSSHAPF_LineName) AndAlso EdittingData.AboutLastOutPPSSHAPF_LineName.Length >= 2 AndAlso EdittingData.AboutLastOutPPSSHAPF_LineName.Substring(0, 2) <> "CP" Then
            lbRunLine.BackColor = Color.Coral
        End If
    End Sub

    Public Function DataEndEditAndSave() As Integer Implements IStationRunningControl.DataEndEditAndSave
        Me.bsDataSource.EndEdit()
        Return Me.EdittingData.CDBSave()
    End Function

    Private Sub cbPaperPLSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPaperPLSelect.SelectedIndexChanged
        tbPaperFixLength.Enabled = (CType(sender, ComboBox).SelectedValue = "N")
        If tbPaperFixLength.Enabled = False Then
            tbPaperFixLength.Text = "9999.9"
        End If
    End Sub

End Class
