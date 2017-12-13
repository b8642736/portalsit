Public Class WaitConvertFileInfo
    Inherits ListViewItem

    Dim DBContent As New CompanyLINQDB.EAFDataContext

    Sub New(ByVal FileFullPath As String)
        Me.UploadFileFullPath = FileFullPath
    End Sub
    Public Overrides Function ToString() As String
        Return FileName
    End Function

#Region "檔案完整路徑 屬性:UploadFileFullPath"

    Private _UploadFileFullPath As String = Nothing
    ''' <summary>
    ''' 檔案完整路徑
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UploadFileFullPath() As String
        Get
            Return _UploadFileFullPath
        End Get
        Set(ByVal value As String)
            _UploadFileFullPath = value
        End Set
    End Property

#End Region
#Region "檔案是否存在於磁碟機 屬性:IsFileExistsInDisk"
    ''' <summary>
    ''' 檔案是否存在於磁碟機
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsFileExistInDisk() As Boolean
        Get
            If IsNothing(Me.UploadFileFullPath) Then
                Return False
            End If
            Return System.IO.File.Exists(Me.UploadFileFullPath)
        End Get
    End Property
#End Region
#Region "檔案名稱 屬性:FileName"
    ''' <summary>
    ''' 檔案名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property FileName() As String
        Get
            If IsNothing(Me.UploadFileFullPath) Then
                Return Nothing
            End If
            Dim Temps() As String = Me.UploadFileFullPath.Split("\")
            Return Temps(Temps.Length - 1)
        End Get
    End Property
#End Region
#Region "上傳轉換 屬性:UploadAndConvert"
    ''' <summary>
    ''' 上傳轉換
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UploadAndConvert(Optional ByVal IsConvertOverToDelete As Boolean = True)
        If Me.IsFileExistInDisk = False Then
            ConvertResultMessage = "檔案轉換失敗,因為檔案不存在於磁碟中!"
            Exit Sub
        End If
        ConvertResultMessage = "檔案轉換中...!"
        Dim ConvertResult As String = Nothing
        Try
            ConvertResult = ConvertExcelFileToDataBase()
        Catch ex As Exception
            ConvertResult = ex.ToString
        End Try
        Me.IsConvertSuccess = IsNothing(ConvertResult)
        If Me.IsConvertSuccess Then
            ConvertResultMessage = Me.FileName & "檔案轉換成功!"
            System.IO.File.Delete(UploadFileFullPath)
        Else
            ConvertResultMessage = Me.FileName & "檔案轉換失敗!" & vbNewLine & "原因:" & ConvertResult
        End If

    End Sub
#End Region
#Region "轉換是否完成  屬性:IsConvertSuccess"

    Private _IsConvertSuccess As Boolean = False
    ''' <summary>
    ''' 轉換是否完成
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsConvertSuccess() As Boolean
        Get
            Return _IsConvertSuccess
        End Get
        Set(ByVal value As Boolean)
            _IsConvertSuccess = value
        End Set
    End Property

#End Region
#Region "傳換結果訊息 屬性:ConvertResultMessage"

    Private _ConvertResultMessage As String
    ''' <summary>
    ''' 傳換結果訊息
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ConvertResultMessage() As String
        Get
            If IsNothing(_ConvertResultMessage) Then
                _ConvertResultMessage = Me.FileName & "檔案尚未轉換"
            End If
            Return _ConvertResultMessage
        End Get
        Private Set(ByVal value As String)
            _ConvertResultMessage = value
        End Set
    End Property

#End Region
#Region "刪除檔案 方法:DeleteFile"
    ''' <summary>
    ''' 刪除檔案
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DeleteFile()
        If Me.IsFileExistInDisk = False Then
            ConvertResultMessage = "檔案刪除失敗,因為檔案不存在於磁碟中!"
            Exit Sub
        End If
        System.IO.File.Delete(Me.UploadFileFullPath)
    End Sub
#End Region





#Region "轉換Excel檔案至資料庫 方法:ConvertExcelFileToDataBase"
    ''' <summary>
    ''' 轉換Excel檔案至資料庫
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ConvertExcelFileToDataBase() As String

        Dim ReturnValue As String = Nothing
        Dim TempStringValue As String = Nothing
        Dim TempStringsValue() As String = Nothing
        Dim TempDoubleValue As Double = Nothing
        Dim TempDateValue As Date = Nothing

        Dim ShowText As String = Nothing
        Dim NewRecord As EAFT1 = Nothing
        Dim ConvertRecordCount As Integer = 0

        Dim myExcelFile As Microsoft.Office.Interop.Excel.Application = Nothing
        Try
            myExcelFile = New Microsoft.Office.Interop.Excel.Application
            myExcelFile.Workbooks.Open(Me.UploadFileFullPath)
            For Each EachItem As Microsoft.Office.Interop.Excel.Worksheet In myExcelFile.Worksheets
                If EachItem.Name.Length = 5 AndAlso (EachItem.Name.Substring(0, 1).ToUpper = "A" OrElse EachItem.Name.Substring(0, 1).ToUpper = "B") Then
                    NewRecord = New EAFT1
                    With NewRecord
                        TempStringValue = CType(EachItem.Cells(56, 30), Microsoft.Office.Interop.Excel.Range).Value2
                        If TempStringValue.Length >= 5 AndAlso TempStringValue.Substring(1, 1) = " " AndAlso TempStringValue.Substring(3, 1) = " " Then
                            TempStringValue = TempStringValue.Substring(0, 1) & TempStringValue.Substring(2, 1) & TempStringValue.Substring(4, 1)
                        End If
                        .Rector = TempStringValue
                        .SetElecticOnUser = CType(EachItem.Cells(55, 30), Microsoft.Office.Interop.Excel.Range).Value2
                        .Monitor = CType(EachItem.Cells(54, 30), Microsoft.Office.Interop.Excel.Range).Value2
                        .Class = CType(EachItem.Cells(53, 30), Microsoft.Office.Interop.Excel.Range).Value2
                        .StoveNumber = CType(EachItem.Cells(52, 30), Microsoft.Office.Interop.Excel.Range).Value2
                        .SteelKind = CType(EachItem.Cells(51, 30), Microsoft.Office.Interop.Excel.Range).Value2
                        TempStringValue = CType(EachItem.Cells(49, 30), Microsoft.Office.Interop.Excel.Range).Value2
                        TempStringsValue = TempStringValue.Split(TempStringValue.Substring(2, 1))
                        .DataDate = New Date(CType(TempStringsValue(0), Integer) + 1911, CType(TempStringsValue(1), Integer), CType(TempStringsValue(2), Integer))
                        If EachItem.Name.Substring(0, 1).ToUpper = "A" Then
                            .DolomiteWeight = CType(EachItem.Cells(48, 30), Microsoft.Office.Interop.Excel.Range).Value2
                            .LDWeight = Val(CType(EachItem.Cells(47, 30), Microsoft.Office.Interop.Excel.Range).Value2)
                        Else
                            .DolomiteWeight = Val(CType(EachItem.Cells(47, 30), Microsoft.Office.Interop.Excel.Range).Value2)
                            .LDWeight = CType(EachItem.Cells(48, 30), Microsoft.Office.Interop.Excel.Range).Value2
                        End If
                        .CaOWeight = Val(CType(EachItem.Cells(46, 30), Microsoft.Office.Interop.Excel.Range).Value2)
                        .FettlingWeight = Val(CType(EachItem.Cells(45, 30), Microsoft.Office.Interop.Excel.Range).Value2)
                        .CaOWeight = Val(CType(EachItem.Cells(46, 30), Microsoft.Office.Interop.Excel.Range).Value2)
                        .FettlingWeight = Val(CType(EachItem.Cells(45, 30), Microsoft.Office.Interop.Excel.Range).Value2)
                        .TapFrequency = Val(CType(EachItem.Cells(44, 30), Microsoft.Office.Interop.Excel.Range).Value2)
                        .StoveCoverFequency = Val(CType(EachItem.Cells(43, 30), Microsoft.Office.Interop.Excel.Range).Value2)
                        .StoveWallFequency = Val(CType(EachItem.Cells(42, 30), Microsoft.Office.Interop.Excel.Range).Value2)
                        .StoveBottomFequency = Val(CType(EachItem.Cells(41, 30), Microsoft.Office.Interop.Excel.Range).Value2)
                        .SteelOutputWeight = Val(CType(EachItem.Cells(29, 30), Microsoft.Office.Interop.Excel.Range).Value2)
                        .MoltenSteelWeight = Val(CType(EachItem.Cells(28, 30), Microsoft.Office.Interop.Excel.Range).Value2)
                        .ResidueWeight = Val(CType(EachItem.Cells(27, 30), Microsoft.Office.Interop.Excel.Range).Value2)
                        .StartElectricPower = Val(CType(EachItem.Cells(8, 30), Microsoft.Office.Interop.Excel.Range).Value2)
                        .EndElectricPower = Val(CType(EachItem.Cells(9, 30), Microsoft.Office.Interop.Excel.Range).Value2)
                        .Allocate_C = Val(CType(EachItem.Cells(43, 18), Microsoft.Office.Interop.Excel.Range).Value2)
                        .Allocate_Si = Val(CType(EachItem.Cells(43, 19), Microsoft.Office.Interop.Excel.Range).Value2)
                        .Allocate_Mn = Val(CType(EachItem.Cells(43, 20), Microsoft.Office.Interop.Excel.Range).Value2)
                        .Allocate_P = Val(CType(EachItem.Cells(43, 21), Microsoft.Office.Interop.Excel.Range).Value2)
                        .Allocate_S = Val(CType(EachItem.Cells(43, 22), Microsoft.Office.Interop.Excel.Range).Value2)
                        .Allocate_Cr = Val(CType(EachItem.Cells(43, 23), Microsoft.Office.Interop.Excel.Range).Value2)
                        .Allocate_Ni = Val(CType(EachItem.Cells(43, 24), Microsoft.Office.Interop.Excel.Range).Value2)
                        .Allocate_Cu = Val(CType(EachItem.Cells(43, 25), Microsoft.Office.Interop.Excel.Range).Value2)
                        .Allocate_Mo = Val(CType(EachItem.Cells(43, 26), Microsoft.Office.Interop.Excel.Range).Value2)
                        .ConvertFileName = Me.FileName
                    End With
                    Try
                        DBContent.EAFT1.InsertOnSubmit(NewRecord)
                        DBContent.SubmitChanges()
                        ConvertOperator(EachItem, NewRecord)
                        ConvertWaitTimeEvent(EachItem, NewRecord)
                        ConvertElectricAnalysis(EachItem, NewRecord)
                        SteelElementAnalysis(EachItem, NewRecord)
                        DeleteOldData(NewRecord)
                    Catch ex As Exception
                        Dim DBCommand As System.Data.Common.DbCommand = DBContent.Connection.CreateCommand
                        DBCommand.CommandText = "Delete  from EAFT1 Where ConvertFileName='" & Me.FileName & "'"
                        DBCommand.Connection.Open()
                        DBCommand.ExecuteNonQuery()
                        DBCommand.Connection.Close()
                        ReturnValue = "資料轉換中,有一筆失敗!(此批轉換資料將全部刪除) 爐號:" & EachItem.Name
                        ReturnValue &= "資料異常爐號:" & EachItem.Name & vbNewLine & "錯誤原因(給程式設計師使用):" & ex.ToString
                        Return ReturnValue
                    End Try
                    ConvertRecordCount += 1
                End If
            Next

        Catch ex As Exception
            Return ex.ToString
        Finally
            If Not IsNothing(myExcelFile) Then
                myExcelFile.ActiveWorkbook.Close()
                System.IO.File.Delete(Me.UploadFileFullPath)
            End If
        End Try

        Return Nothing
    End Function
#End Region
#Region "轉換作業內容 方法:ConvertOperator"
    ''' <summary>
    ''' 轉換作業內容
    ''' </summary>
    ''' <param name="ExcelSheet"></param>
    ''' <param name="SourceEAFT1"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ConvertOperator(ByVal ExcelSheet As Microsoft.Office.Interop.Excel.Worksheet, ByVal SourceEAFT1 As EAFT1) As Boolean
        Dim OperatorNumber As Integer = 0
        Dim OperatorTypeID As Integer = 0
        Dim PreAddMinute As Integer = 0
        For EachRowNumber As Integer = 5 To 41
            Dim OperatorTime As DateTime = SourceEAFT1.DataDate.Value
            OperatorTime = OperatorTime.AddHours(CType(CType(ExcelSheet.Cells(EachRowNumber, 2), Microsoft.Office.Interop.Excel.Range).Value2, Integer))
            If Not IsNothing(CType(ExcelSheet.Cells(EachRowNumber, 4), Microsoft.Office.Interop.Excel.Range).Value2) Then
                OperatorTime = OperatorTime.AddMinutes(CType(CType(ExcelSheet.Cells(EachRowNumber, 4), Microsoft.Office.Interop.Excel.Range).Value2, Integer))
            Else
                OperatorTime = OperatorTime.AddMinutes(PreAddMinute)
            End If
            PreAddMinute = OperatorTime.Minute



            Dim IsInputStartTime As Boolean = False
            If Not IsNothing(CType(ExcelSheet.Cells(EachRowNumber, 4), Microsoft.Office.Interop.Excel.Range).Value2) Then
                IsInputStartTime = True
            End If
            Dim OperatorString As String = ""
            If Not IsNothing(CType(ExcelSheet.Cells(EachRowNumber, 5), Microsoft.Office.Interop.Excel.Range).Value2) Then
                OperatorString = CType(CType(ExcelSheet.Cells(EachRowNumber, 5), Microsoft.Office.Interop.Excel.Range).Value2, String).Trim()
            End If
            Dim V As Long = 0
            If Not IsNothing(CType(ExcelSheet.Cells(EachRowNumber, 9), Microsoft.Office.Interop.Excel.Range).Value2) Then
                V = Val(CType(ExcelSheet.Cells(EachRowNumber, 9), Microsoft.Office.Interop.Excel.Range).Value2)
            End If
            Dim EFPerstange As Integer = 0
            If Not IsNothing(CType(ExcelSheet.Cells(EachRowNumber, 10), Microsoft.Office.Interop.Excel.Range).Value2) Then
                EFPerstange = Val(CType(ExcelSheet.Cells(EachRowNumber, 10), Microsoft.Office.Interop.Excel.Range).Value2)
            End If
            Dim EPower As Long = 0
            If Not IsNothing(CType(ExcelSheet.Cells(EachRowNumber, 11), Microsoft.Office.Interop.Excel.Range).Value2) Then
                EPower = Val(CType(ExcelSheet.Cells(EachRowNumber, 11), Microsoft.Office.Interop.Excel.Range).Value2)
            End If
            Dim TempetureC As Long = 0
            If Not IsNothing(CType(ExcelSheet.Cells(EachRowNumber, 12), Microsoft.Office.Interop.Excel.Range).Value2) Then
                TempetureC = Val(CType(CType(ExcelSheet.Cells(EachRowNumber, 12), Microsoft.Office.Interop.Excel.Range).Value2, Integer))
            End If
            Dim O3 As Long = 0
            If Not IsNothing(CType(ExcelSheet.Cells(EachRowNumber, 13), Microsoft.Office.Interop.Excel.Range).Value2) Then
                O3 = CType(CType(ExcelSheet.Cells(EachRowNumber, 13), Microsoft.Office.Interop.Excel.Range).Value2, Integer)
            End If
            Dim Memo1 As String = Nothing
            If Not IsNothing(CType(ExcelSheet.Cells(EachRowNumber, 14), Microsoft.Office.Interop.Excel.Range).Value2) Then
                Memo1 = CType(ExcelSheet.Cells(EachRowNumber, 14), Microsoft.Office.Interop.Excel.Range).Value2
            End If
            Dim Memo2 As Integer = 0
            If Not IsNothing(CType(ExcelSheet.Cells(EachRowNumber, 15), Microsoft.Office.Interop.Excel.Range).Value2) Then
                Memo2 = Val(CType(ExcelSheet.Cells(EachRowNumber, 15), Microsoft.Office.Interop.Excel.Range).Value2)
            End If
            Dim Memo3 As Integer = 0
            If Not IsNothing(CType(ExcelSheet.Cells(EachRowNumber, 16), Microsoft.Office.Interop.Excel.Range).Value2) Then
                Memo3 = Val(CType(ExcelSheet.Cells(EachRowNumber, 16), Microsoft.Office.Interop.Excel.Range).Value2)
            End If
            If IsInputStartTime = False AndAlso String.IsNullOrEmpty(OperatorString) AndAlso V = 0 AndAlso EFPerstange = 0 AndAlso EPower = 0 AndAlso TempetureC = 0 AndAlso O3 = 0 AndAlso String.IsNullOrEmpty(Memo1) AndAlso Memo2 = 0 AndAlso Memo3 = 0 Then
                Continue For
            End If
            OperatorNumber += 1
            Dim NewOperatorData As New EAFT2
            With NewOperatorData
                .FK_EAF1ID = SourceEAFT1.ID
                .StartTime = OperatorTime
                Select Case True
                    Case OperatorString = "前爐完"
                        OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.前爐完)
                    Case OperatorString = "接電極完"
                        OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.接電極完)
                    Case OperatorString = "補爐完"
                        OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.補爐完)
                    Case OperatorString = "" AndAlso EachRowNumber = 8 AndAlso CType(CType(ExcelSheet.Cells(EachRowNumber + 1, 5), Microsoft.Office.Interop.Excel.Range).Value2, String).Trim = "送電Ⅰ"
                        OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.準備送電I)
                    Case OperatorString = "追加" AndAlso CType(CType(ExcelSheet.Cells(EachRowNumber + 1, 5), Microsoft.Office.Interop.Excel.Range).Value2, String).Trim = "送電Ⅱ"
                        OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.準備送電II)
                    Case OperatorString = "追加" AndAlso CType(CType(ExcelSheet.Cells(EachRowNumber + 1, 5), Microsoft.Office.Interop.Excel.Range).Value2, String).Trim = "送電Ⅲ"
                        OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.準備送電III)
                    Case OperatorString = "追加" AndAlso CType(CType(ExcelSheet.Cells(EachRowNumber + 1, 5), Microsoft.Office.Interop.Excel.Range).Value2, String).Trim = "送電IV"
                        OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.準備送電IV)
                    Case OperatorString = "送電Ⅰ"
                        OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.送電I)
                    Case OperatorString = "送電Ⅱ"
                        OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.送電II)
                    Case OperatorString = "送電Ⅲ"
                        OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.送電III)
                    Case OperatorString = "送電IV"
                        OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.送電IV)
                    Case OperatorString = "M.D."
                        OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.MD)
                    Case OperatorString = "S1,T1"
                        OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.S1_T1)
                    Case OperatorString = "O2"
                        OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.O2)
                    Case OperatorString = "O2止"
                        OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.O2止)
                    Case OperatorString = "S2,T2"
                        OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.S2_T2)
                    Case OperatorString = "Tap"
                        OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.Tap)
                    Case OperatorString = "S3,T3" Or OperatorString = "S3，T3"
                        OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.S3_T3)
                End Select
                .FK_OperatorTypeID = OperatorTypeID
                .Voltage = V
                .ElectricCurrentPercentage = EFPerstange
                .ElectricPower = EPower
                .Thermograph = TempetureC
                .Oxygen = O3
                .MemoItem = Memo1
                .MemoMetal = Memo2
                .MemoDregs = Memo3
                .OperatorOrder = OperatorNumber
            End With

            DBContent.EAFT2.InsertOnSubmit(NewOperatorData)
        Next
        DBContent.SubmitChanges()
        Return True
    End Function
#End Region
#Region "轉換等待時間 方法:ConvertWaitTimeEvent"
    ''' <summary>
    ''' 轉換等待時間
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ConvertWaitTimeEvent(ByVal ExcelSheet As Microsoft.Office.Interop.Excel.Worksheet, ByVal SourceEAFT1 As EAFT1) As Boolean
        Dim EventNumber As Integer = 0
        Dim OperatorTypeID As Integer = 0
        For EachRowNumber As Integer = 5 To 41
            Dim OperatorString As String = ""
            If Not IsNothing(CType(ExcelSheet.Cells(EachRowNumber, 5), Microsoft.Office.Interop.Excel.Range).Value2) Then
                OperatorString = CType(CType(ExcelSheet.Cells(EachRowNumber, 5), Microsoft.Office.Interop.Excel.Range).Value2, String).Trim()
            End If
            Select Case True
                Case OperatorString = "前爐完"
                    OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.前爐完)
                Case OperatorString = "接電極完"
                    OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.接電極完)
                Case OperatorString = "補爐完"
                    OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.補爐完)
                Case OperatorString = "" AndAlso EachRowNumber = 8 AndAlso CType(CType(ExcelSheet.Cells(EachRowNumber + 1, 5), Microsoft.Office.Interop.Excel.Range).Value2, String).Trim = "送電Ⅰ"
                    OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.準備送電I)
                Case OperatorString = "追加" AndAlso CType(CType(ExcelSheet.Cells(EachRowNumber + 1, 5), Microsoft.Office.Interop.Excel.Range).Value2, String).Trim = "送電Ⅱ"
                    OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.準備送電II)
                Case OperatorString = "追加" AndAlso CType(CType(ExcelSheet.Cells(EachRowNumber + 1, 5), Microsoft.Office.Interop.Excel.Range).Value2, String).Trim = "送電Ⅲ"
                    OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.準備送電III)
                Case OperatorString = "追加" AndAlso CType(CType(ExcelSheet.Cells(EachRowNumber + 1, 5), Microsoft.Office.Interop.Excel.Range).Value2, String).Trim = "送電IV"
                    OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.準備送電IV)
                Case OperatorString = "送電Ⅰ"
                    OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.送電I)
                Case OperatorString = "送電Ⅱ"
                    OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.送電II)
                Case OperatorString = "送電Ⅲ"
                    OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.送電III)
                Case OperatorString = "送電IV"
                    OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.送電IV)
                Case OperatorString = "M.D."
                    OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.MD)
                Case OperatorString = "S1,T1"
                    OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.S1_T1)
                Case OperatorString = "O2"
                    OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.O2)
                Case OperatorString = "O2止"
                    OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.O2止)
                Case OperatorString = "S2,T2"
                    OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.S2_T2)
                Case OperatorString = "Tap"
                    OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.Tap)
                Case OperatorString = "S3,T3" Or OperatorString = "S3，T3"
                    OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.S3_T3)
            End Select
            If OperatorTypeID = 0 Then
                Stop
            End If

            For EachColumnNumber As Integer = 0 To 2

                Dim ReasonString As String = CType(CType(ExcelSheet.Cells(EachRowNumber, 17 + EachColumnNumber * 4), Microsoft.Office.Interop.Excel.Range).Value2, String)
                Dim StartTimeString As String = CType(CType(ExcelSheet.Cells(EachRowNumber, 18 + EachColumnNumber * 4), Microsoft.Office.Interop.Excel.Range).Value2, String)
                Dim EndTimeString As String = CType(CType(ExcelSheet.Cells(EachRowNumber, 19 + EachColumnNumber * 4), Microsoft.Office.Interop.Excel.Range).Value2, String)


                If String.IsNullOrEmpty(ReasonString) OrElse String.IsNullOrEmpty(StartTimeString) OrElse String.IsNullOrEmpty(EndTimeString) Then
                    Continue For
                End If

                Dim StartTime As DateTime = SourceEAFT1.DataDate.Value
                Dim StartTimeAddHour As Integer = StartTimeString.Split(".")(0)
                Dim StartTimeAddMinute As Integer = StartTimeString.Split(".")(1)
                Dim EndTime As DateTime = SourceEAFT1.DataDate.Value
                Dim EndTimeAddHour As Integer = EndTimeString.Split(".")(0)
                Dim EndTimeAddMinute As Integer = EndTimeString.Split(".")(1)
                StartTime = StartTime.AddHours(StartTimeAddHour)
                StartTime = StartTime.AddMinutes(StartTimeAddMinute)
                EndTime = EndTime.AddHours(EndTimeAddHour)
                EndTime = EndTime.AddMinutes(EndTimeAddMinute)

                EventNumber += 1
                Dim NewOperatorData As New EAFT2_Wait
                With NewOperatorData
                    .FK_OperatorTypeID = OperatorTypeID
                    .WaitReason = ReasonString
                    .FK_EAF1ID = SourceEAFT1.ID
                    .StartTime = StartTime
                    .EndTime = EndTime
                    .EventNumber = EventNumber
                End With
                If NewOperatorData.StartTime > NewOperatorData.EndTime Then
                    NewOperatorData.EndTime = NewOperatorData.EndTime.AddDays(1)
                End If
                DBContent.EAFT2_Wait.InsertOnSubmit(NewOperatorData)
            Next
        Next
        DBContent.SubmitChanges()
        Return True

    End Function
#End Region
#Region "轉換送電分析 方法:ConvertElectricAnalysis"
    ''' <summary>
    ''' 轉換送電分析
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ConvertElectricAnalysis(ByVal ExcelSheet As Microsoft.Office.Interop.Excel.Worksheet, ByVal SourceEAFT1 As EAFT1) As Boolean
        For EachItem As Integer = 0 To 3
            If IsNothing(CType(ExcelSheet.Cells(44, 4 + EachItem * 2), Microsoft.Office.Interop.Excel.Range).Value2) Then
                Continue For
            End If
            Dim GetToneValue As Single = Val(CType(ExcelSheet.Cells(44, 4 + EachItem * 2), Microsoft.Office.Interop.Excel.Range).Value2)
            If GetToneValue = 0 Then
                Continue For
            End If
            Dim AddNewItem As New EAFT2_Analysis
            With AddNewItem
                .EAFT1 = SourceEAFT1
                .TONValue = GetToneValue
                Select Case EachItem
                    Case 0
                        .FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.送電I)
                    Case 1
                        .FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.送電II)
                    Case 2
                        .FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.送電III)
                    Case 3
                        .FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.送電IV)
                End Select
                .Bucket = Val(CType(ExcelSheet.Cells(50, 4 + EachItem * 2), Microsoft.Office.Interop.Excel.Range).Value2)
            End With

            DBContent.EAFT2_Analysis.InsertOnSubmit(AddNewItem)
        Next
        DBContent.SubmitChanges()
        Return True
    End Function
#End Region
#Region "成份分析 方法:SteelElementAnalysis"
    ''' <summary>
    ''' 成份分析
    ''' </summary>
    ''' <param name="ExcelSheet"></param>
    ''' <param name="SourceEAFT1"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SteelElementAnalysis(ByVal ExcelSheet As Microsoft.Office.Interop.Excel.Worksheet, ByVal SourceEAFT1 As EAFT1) As Boolean


        For EachItem As Integer = 0 To 4
            If Val(CType(ExcelSheet.Cells(53 + EachItem, 4), Microsoft.Office.Interop.Excel.Range).Value2) = 0 AndAlso Val(CType(ExcelSheet.Cells(53 + EachItem, 5), Microsoft.Office.Interop.Excel.Range).Value2) = 0 Then
                Continue For
            End If
            Dim AddNewItem As New EAFT3
            With AddNewItem
                .EAFT1 = SourceEAFT1
                .SampleNumber = EachItem + 1
                .C = Val(CType(ExcelSheet.Cells(53 + EachItem, 4), Microsoft.Office.Interop.Excel.Range).Value2)
                .Si = Val(CType(ExcelSheet.Cells(53 + EachItem, 5), Microsoft.Office.Interop.Excel.Range).Value2)
                .Mn = Val(CType(ExcelSheet.Cells(53 + EachItem, 6), Microsoft.Office.Interop.Excel.Range).Value2)
                .P = Val(CType(ExcelSheet.Cells(53 + EachItem, 7), Microsoft.Office.Interop.Excel.Range).Value2)
                .S = Val(CType(ExcelSheet.Cells(53 + EachItem, 8), Microsoft.Office.Interop.Excel.Range).Value2)
                .Cr = Val(CType(ExcelSheet.Cells(53 + EachItem, 9), Microsoft.Office.Interop.Excel.Range).Value2)
                .Ni = Val(CType(ExcelSheet.Cells(53 + EachItem, 10), Microsoft.Office.Interop.Excel.Range).Value2)
                .Cu = Val(CType(ExcelSheet.Cells(53 + EachItem, 11), Microsoft.Office.Interop.Excel.Range).Value2)
                .Mo = Val(CType(ExcelSheet.Cells(53 + EachItem, 12), Microsoft.Office.Interop.Excel.Range).Value2)
                .Sn = Val(CType(ExcelSheet.Cells(53 + EachItem, 13), Microsoft.Office.Interop.Excel.Range).Value2)
                .Pb = Val(CType(ExcelSheet.Cells(53 + EachItem, 14), Microsoft.Office.Interop.Excel.Range).Value2)
                .Co = Val(CType(ExcelSheet.Cells(53 + EachItem, 15), Microsoft.Office.Interop.Excel.Range).Value2)
            End With
            DBContent.EAFT3.InsertOnSubmit(AddNewItem)

        Next
        DBContent.SubmitChanges()
        Return True

    End Function

#End Region
#Region "刪除最新資料前三個月重覆爐號資料 方法:DeleteOldData"
    ''' <summary>
    ''' 刪除最新資料前三個月重覆爐號資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function DeleteOldData(ByVal NewData As EAFT1) As Boolean
        For Each EachItem In (From A In DBContent.EAFT1 Where A.StoveNumber = NewData.StoveNumber And A.DataDate >= NewData.DataDate.Value.AddMonths(-3) And A.DataDate <= NewData.DataDate And A.ID <> NewData.ID)
            DBContent.EAFT1.DeleteOnSubmit(EachItem)
        Next
        DBContent.SubmitChanges()
        Return True
    End Function
#End Region

End Class
