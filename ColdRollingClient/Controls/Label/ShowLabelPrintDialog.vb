Imports System.Windows.Forms

Public Class ShowLabelPrintDialog

#Region "上層表單 私有屬性:UPLevelForm"

    Private _UPLevelForm As Form
    ''' <summary>
    ''' 上層表單
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property UPLevelForm() As Form
        Get
            Return _UPLevelForm
        End Get
        Set(ByVal value As Form)
            _UPLevelForm = value
        End Set
    End Property


#End Region
#Region "預設列印控制項 屬性/事件:DefaultShowLabelPrintControl/DefaultShowLabelPrintControlEvent"
    WithEvents DefaultShowLabelPrintControlEvent As LabelPrint
    Private _DefaultShowLabelPrintControl As LabelPrint
    Private ReadOnly Property DefaultShowLabelPrintControl() As LabelPrint
        Get
            If IsNothing(_DefaultShowLabelPrintControl) Then
                _DefaultShowLabelPrintControl = New LabelPrint
                DefaultShowLabelPrintControlEvent = _DefaultShowLabelPrintControl
                Panel1.Controls.Add(_DefaultShowLabelPrintControl)
                _DefaultShowLabelPrintControl.Dock = DockStyle.Fill
            End If
            Return _DefaultShowLabelPrintControl
        End Get

    End Property

#End Region

    Shadows Sub Show(ByVal SetDefaultValue As CoilRunningItem, ByVal Sender As CoilScanAndMachineProcess, ByVal ParentForm As Form)
        Me.UPLevelForm = ParentForm
        ParentForm.Enabled = False
        MyBase.Show()
        DefaultShowLabelPrintControl.TabControl1.SelectedTab = DefaultShowLabelPrintControl.TabPage2
        If Not IsNothing(SetDefaultValue) Then
            Dim SetData As New ColdRollingClientDataSet.CoilLabelDataSetDataTable
            Dim SetDataRow As ColdRollingClientDataSet.CoilLabelDataSetRow = SetData.NewRow
            Dim AboutSL2CICPF As CompanyORMDB.SLS300LB.SL2CICPF = Nothing
            With SetDataRow
                If Sender.CurrentEditRunProcessDatas.Count > 0 Then
                    .序號 = Sender.CurrentEditRunProcessDatas(0).TheSerialNumberForStation
                    .重量或長度 = IIf(Sender.CurrentEditRunProcessDatas(0).Length > 0, Sender.CurrentEditRunProcessDatas(0).Length, Sender.CurrentEditRunProcessDatas(0).Weight)
                    If Not IsNothing(Sender.CurrentEditRunProcessDatas(0).AboutLastRefPPSSHAPF) Then
                        .鋼種規格 = Sender.CurrentEditRunProcessDatas(0).AboutLastRefPPSSHAPF.SHA12.Trim & Sender.CurrentEditRunProcessDatas(0).AboutLastRefPPSSHAPF.SHA13
                        AboutSL2CICPF = Sender.CurrentEditRunProcessDatas(0).AboutLastOutPPSSHAPF.AboutSL2CICPF
                    End If
                End If
                .厚度 = SetDefaultValue.CurrentRunningCoilScanedTreeNode.SteelGuage
                .寬度 = SetDefaultValue.CurrentRunningCoilScanedTreeNode.SteelWidth
                .鋼捲編號 = SetDefaultValue.CurrentRunningCoilScanedTreeNode.CoilFullNumber
                .產出日期時間 = Now
                .線別 = Sender.CurrentUseingStationRadioButton.Text.Trim
                .班別 = CompanyORMDB.TABLE.TABLE7PF.GetClassNumber(.線別, Now)
                If Not IsNothing(AboutSL2CICPF) Then
                    .客戶編號 = AboutSL2CICPF.CIC10.Substring(0, 3)
                Else
                    .客戶編號 = "---"
                End If
            End With
            SetData.Rows.Add(SetDataRow)
            DefaultShowLabelPrintControl.SetPrintDatasAndPrint(SetData, False, Sender.CurrentUseingStationRadioButton.Text.Trim)
        End If
    End Sub


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        UPLevelForm.Enabled = True
        UPLevelForm.Show()
        UPLevelForm.BringToFront()
        Me.Close()
    End Sub

    Private Sub DefaultShowLabelPrintControlEvent_ExitEvent(Sender As LabelPrint) Handles DefaultShowLabelPrintControlEvent.ExitEvent
        Call OK_Button_Click(Nothing, Nothing)
    End Sub
End Class
