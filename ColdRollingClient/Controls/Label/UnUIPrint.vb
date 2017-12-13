Imports System
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Microsoft.Reporting.WinForms

Public Class UnUIPrint

#Region "設定列印資料 函式:SetPrintDatasAndPrint"
    ''' <summary>
    ''' 設定列印資料
    ''' </summary>
    ''' <param name="SetDatas"></param>
    ''' <remarks></remarks>
    Public Sub SetPrintDatasAndPrint(ByVal SetDatas As ColdRollingClientDataSet.CoilLabelDataSetDataTable, ByVal SetPrintStationName As String)
        Dim PrintControl As RDLCDirectPrint = Nothing
        If SetPrintStationName.Trim.ToUpper.PadRight(3).Substring(0, 3) = "TLL" OrElse SetPrintStationName.Trim.ToUpper.PadRight(3).Substring(0, 3) = "SBL" OrElse SetPrintStationName.Trim.ToUpper.PadRight(3).Substring(0, 3) = "SPL" OrElse SetPrintStationName.Trim.ToUpper.PadRight(4).Substring(0, 4) = "APL2" Then
            PrintControl = New RDLCDirectPrint("ColdRollingClient.CoilLabelForProduct.rdlc")
        Else
            PrintControl = New RDLCDirectPrint("ColdRollingClient.CoilLabel.rdlc")
        End If

        With PrintControl
            .DeviceInfo_MarginLeft = 0.1
            .DeviceInfo_MarginRight = 0.5
            .DeviceInfo_MarginTop = 0.75
            .DeviceInfo_MarginBottom = 0
            .OutPaperSize = New PaperSize("Customer", 11.45 * 0.039 * 1000, 21.6 * 0.039 * 1000)
            .OutPrintDocument.DefaultPageSettings.Landscape = True
        End With
        Dim myDataSet As New ColdRollingClientDataSet
        myDataSet.Tables.Add(SetDatas)
        Dim DataSorce As New ReportDataSource("DataSet1", CType(SetDatas, DataTable))
        PrintControl.Print(DataSorce)
    End Sub

#End Region

#Region "無使用介面快速直接列印 函式:UnUIQuickPrint"
    Private Shared LabelPrintControl As UnUIPrint = Nothing
    ''' <summary>
    ''' 無使用介面直接列印
    ''' </summary>
    ''' <param name="SetDatas"></param>
    ''' <remarks></remarks>
    Public Shared Sub UnUIQuickPrint(ByVal SetDatas As ColdRollingClientDataSet.CoilLabelDataSetDataTable, ByVal SetPrintStationName As String)
        If IsNothing(LabelPrintControl) Then
            LabelPrintControl = New UnUIPrint
        End If
        LabelPrintControl.SetPrintDatasAndPrint(SetDatas, SetPrintStationName)
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
            '    '.重量或長度 = IIf(SetPrintPrintRunProcessDatas.Length > 0 And Not {"APL", "CPL"}.Contains(SetPrintStationName.PadRight(3).Substring(0, 3).ToUpper), "長:" & SetPrintPrintRunProcessDatas.Length, "重:" & SetPrintPrintRunProcessDatas.Weight)
            '    .重量或長度 = "      " & IIf(SetPrintPrintRunProcessDatas.Length > 0 And Not {"APL", "CPL"}.Contains(SetPrintStationName.PadRight(3).Substring(0, 3).ToUpper), "長:" & SetPrintPrintRunProcessDatas.Length, "重:" & SetPrintPrintRunProcessDatas.Weight)
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
                    'APL/CPL/ZML 強制印重量
                    .重量或長度 = "      " & IIf(SetPrintPrintRunProcessDatas.Length > 0 And Not {"APL", "CPL", "ZML"}.Contains(SetPrintStationName.PadRight(3).Substring(0, 3).ToUpper), "長:" & SetPrintPrintRunProcessDatas.Length, "重:" & SetPrintPrintRunProcessDatas.Weight)
            End Select


            If Not String.IsNullOrEmpty(SetPrintPrintRunProcessDatas.FK_RunStationName) AndAlso SetPrintPrintRunProcessDatas.FK_RunStationName.Substring(0, 3) = "CPL" Then
                .序號 = SetPrintPrintRunProcessDatas.TheSerialNumberForStation + LabelPrint.SerialNumberJudge  'SerialNumberJudge
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




End Class
