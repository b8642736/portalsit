Imports Microsoft.Office.Interop

Public Class DataConvertExcel
    Sub New(ByVal SetSourceData As DataTable, ByVal ConvertToFileName As String)
        Me.SourceData = SetSourceData
        Me.FileName = ConvertToFileName
    End Sub

    Sub New(ByVal SetSourceData As DataTable, ByVal SetConvertColumnNames As List(Of ConvertColumnName), ByVal ConvertToFileName As String)
        Me.SourceData = SetSourceData
        Me.FileName = ConvertToFileName
        Me.ConvertColumnNames = SetConvertColumnNames
    End Sub




#Region "檔案名稱 屬性:FileName"

    Private _FileName As String = "File1.xls"
    ''' <summary>
    ''' 檔案名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FileName() As String
        Get
            Return _FileName
        End Get
        Set(ByVal value As String)
            _FileName = value
        End Set
    End Property

#End Region

#Region "欄位轉換集合 屬性:ConvertColumnNames"

    Private _ConvertColumnNames As List(Of ConvertColumnName)
    ''' <summary>
    ''' 欄位轉換集合
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ConvertColumnNames() As List(Of ConvertColumnName)
        Get
            Return _ConvertColumnNames
        End Get
        Set(ByVal value As List(Of ConvertColumnName))
            _ConvertColumnNames = value
        End Set
    End Property

#End Region

#Region "資料來源 屬性SourceData"

    Private _SourceData As DataTable
    ''' <summary>
    ''' 資料來源
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SourceData() As DataTable
        Get
            Return _SourceData
        End Get
        Set(ByVal value As DataTable)
            _SourceData = value
        End Set
    End Property

#End Region

#Region "現在使用ExcelWorkBook 屬性:CurrentUseWorkBook"
    Private _CurrentUseWorkBook As Excel.Workbook
    ''' <summary>
    ''' 現在使用ExcelWorkBook
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CurrentUseWorkBook() As Excel.Workbook
        Get
            If IsNothing(_CurrentUseWorkBook) Then
                Dim objExcelApp As New Excel.Application
                objExcelApp.Visible = False
                _CurrentUseWorkBook = objExcelApp.Workbooks.Add
            End If
            Return _CurrentUseWorkBook
        End Get
        Private Set(ByVal value As Excel.Workbook)
            _CurrentUseWorkBook = value
        End Set
    End Property

#End Region


    'Sub DownloadEXCELFile(Of ObjectType)(ByVal Response As Web.HttpResponse, ByVal SetSourceData As IList(Of ObjectType), ByVal SetConvertColumnNames As List(Of ConvertColumnName), ByVal ConvertToFileName As String)
    '    Dim ConvertDataTable As DataTable = ConvertColumnName.CreatDataTable(SetConvertColumnNames)
    '    For Each EachData As ObjectType In SetSourceData

    '    Next
    '    For Each EachItem As ConvertColumnName In SetConvertColumnNames
    '        Dim AddRow As DataRow = ConvertDataTable.NewRow
    '        With AddRow

    '        End With
    '    Next

    '    'For Each EachColumn As DataColumn In ConvertDataTable.Columns
    '    '    If Not IsNothing(SetSourceData.Item(EachColumn.ColumnName)) Then
    '    '        SetSourceData.Item(EachColumn.ColumnName) = EachItem.Item(EachColumn.ColumnName)
    '    '    End If
    '    'Next
    '    Me.SourceData = ConvertDataTable
    '    Me.FileName = ConvertToFileName
    '    Me.ConvertColumnNames = SetConvertColumnNames
    '    DownloadEXCELFile(Response)
    'End Sub
#Region "下載檔案(快速版) Shared函式:DownloadEXCELFile"
    ''' <summary>
    ''' 下載檔案(快速版) 
    ''' </summary>
    ''' <param name="Response"></param>
    ''' <remarks></remarks>
    Public Sub DownloadEXCELFile(ByVal Response As Web.HttpResponse)
        Call DownloadEXCELFile_V2(Response)
    End Sub
#End Region

#Region "下載檔案(快速版) ：產生HTML文字檔後將副檔名改為.XLS，在非微軟Office的Excel會無法開啟：DownloadEXCELFile_V1"
    ''' <summary>
    ''' 下載檔案(快速版) ：產生HTML文字檔後將副檔名改為.XLS，在非微軟Office的Excel會無法開啟
    ''' </summary>
    ''' <param name="Response"></param>
    ''' <remarks></remarks>
    Public Sub DownloadEXCELFile_V1(ByVal Response As Web.HttpResponse)
        Response.Clear()
        Response.Buffer = True
        Response.Charset = ""
        Response.AddHeader("Accept-Language", "zh-tw")
        Response.AddHeader("Content-Disposition", "Attachment;FileName=" + System.Web.HttpUtility.UrlEncode(Me.FileName, System.Text.Encoding.UTF8))
        Response.ContentType = "application/vnd.ms-excel"
        Response.Write(" <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8""> ")
        Dim stringWrite As New System.IO.StringWriter
        Dim htmlWrite As New System.Web.UI.HtmlTextWriter(stringWrite)
        Dim dg As New Web.UI.WebControls.DataGrid



        If Not IsNothing(ConvertColumnNames) And Not IsNothing(Me.SourceData) Then
            Dim WillRemoveColumn As New List(Of DataColumn)
            For Each EachColumn As DataColumn In Me.SourceData.Columns
                Dim TempEachColumn As DataColumn = EachColumn
                Dim WillConvertConvertColumnName As ConvertColumnName = (From A In ConvertColumnNames Where A.SourceFieldName = TempEachColumn.Caption Select A).FirstOrDefault
                If IsNothing(WillConvertConvertColumnName) Then
                    WillRemoveColumn.Add(EachColumn)
                Else
                    EachColumn.ColumnName = WillConvertConvertColumnName.DisplayFieldName
                End If
            Next
            For Each EachItem As DataColumn In WillRemoveColumn
                Me.SourceData.Columns.Remove(EachItem)
            Next
        End If




        dg.DataSource = Me.SourceData
        dg.DataBind()
        dg.RenderControl(htmlWrite)
        Response.Write(stringWrite.ToString)
        Try
            Response.Flush()
        Catch ex As Exception
        End Try
        Response.End()
    End Sub

#End Region

#Region "下載檔案(快速版) ：透過NPOI元件產生EXCEL檔，在非微軟的Office可以正常開啟：DownloadEXCELFile_V2"
    ''' <summary>
    ''' 下載檔案(快速版) ：透過NPOI元件產生EXCEL檔，在非微軟的Office可以正常開啟
    ''' </summary>
    ''' <param name="Response"></param>
    ''' <remarks></remarks>
    ''' 
    Public Sub DownloadEXCELFile_V2(ByVal Response As Web.HttpResponse)
        Dim npoiClassOjb As New NpoiClass

        'Step1：欄位移除/別名
        If Not IsNothing(ConvertColumnNames) And Not IsNothing(Me.SourceData) Then
            Dim WillRemoveColumn As New List(Of DataColumn)
            For Each EachColumn As DataColumn In Me.SourceData.Columns
                Dim TempEachColumn As DataColumn = EachColumn
                Dim WillConvertConvertColumnName As ConvertColumnName = (From A In ConvertColumnNames Where A.SourceFieldName = TempEachColumn.Caption Select A).FirstOrDefault
                If IsNothing(WillConvertConvertColumnName) Then
                    WillRemoveColumn.Add(EachColumn)
                Else
                    EachColumn.ColumnName = WillConvertConvertColumnName.DisplayFieldName
                End If
            Next
            For Each EachItem As DataColumn In WillRemoveColumn
                Me.SourceData.Columns.Remove(EachItem)
            Next
        End If

        'Step2：匯入DataTable
        npoiClassOjb.SetDataTable(Me.SourceData)


        'Step3：下載
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/vnd.ms-excel"
        Response.Charset = ""


        Response.AddHeader("Content-Disposition", String.Format("attachment; filename=" + System.Web.HttpUtility.UrlEncode(Me.FileName, System.Text.Encoding.UTF8)))
        Response.BinaryWrite(npoiClassOjb.GetMemory.ToArray)
    End Sub
#End Region


#Region "下載檔案(未使用測試權限中) 函式:DownloadEXCELFile"
    ''' <summary>
    ''' 下載檔案
    ''' </summary>
    ''' <param name="SourceWebPage"></param>
    ''' <remarks></remarks>
    Public Sub DownloadEXCELFile(ByVal SourceWebPage As System.Web.UI.Page)
        'Dim SaveFileFullPath As String = ConvertToExcelFile()
        If IsNothing(Me.SourceData) Then
            Exit Sub
        End If
        Dim SaveFileDirectPath As String = "C:\WatchFileTemp\ExcelConvertTemp"
        Dim NewFileName As String = Guid.NewGuid.ToString & ".xls"
        Dim SaveFileFullPath As String = SaveFileDirectPath & "\" & NewFileName
        If Not IO.File.Exists(SaveFileDirectPath) Then
            IO.Directory.CreateDirectory(SaveFileDirectPath)
        End If


        Me.CurrentUseWorkBook.SaveAs(SaveFileFullPath, Excel.XlFileFormat.xlWorkbookNormal, Nothing, Nothing, False, False, Excel.XlSaveAsAccessMode.xlShared, False, False, Nothing, Nothing)
        Me.CurrentUseWorkBook.Close()
        'Me.CurrentUseWorkBook.Application.DisplayAlerts = True
        'Me.CurrentUseWorkBook.Application.Quit()
        System.Runtime.InteropServices.Marshal.ReleaseComObject(Me.CurrentUseWorkBook)
        'System.Runtime.InteropServices.Marshal.ReleaseComObject(Me.CurrentUseWorkBook.Application)


        If IsNothing(SaveFileFullPath) Then
            Exit Sub
        End If
        Dim NET As New System.Net.WebClient
        SourceWebPage.Response.ClearHeaders()
        SourceWebPage.Response.Clear()
        SourceWebPage.Response.Expires = 0
        SourceWebPage.Response.Buffer = True
        SourceWebPage.Response.HeaderEncoding = Text.Encoding.GetEncoding("big5")
        SourceWebPage.Response.AddHeader("Accept-Language", "zh-tw")
        SourceWebPage.Response.AddHeader("Content-Disposition", "Attachment;FileName=" + System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8))
        SourceWebPage.Response.ContentType = "APPLICATION/octet-stream"
        SourceWebPage.Response.BinaryWrite(NET.DownloadData(SaveFileFullPath))
        'SourceWebPage.Response.WriteFile(SaveFileFullPath, False)

        IO.File.Delete(SaveFileFullPath)
        SourceWebPage.Response.End()





    End Sub

#End Region


#Region "轉換DataTable成ExcelWorkBook 方法ConvertToExcelFile"
    ''' <summary>
    ''' 轉換DataTable成ExcelWorkBook
    ''' </summary>
    ''' <returns>回傳轉換後的檔案路徑(含檔名)</returns>
    ''' <remarks></remarks>
    Public Function ConvertToExcelSheet(ByVal ConvertToSheetName As String) As Boolean

        Dim ExcelWorkSheet As Excel.Worksheet = Me.CurrentUseWorkBook.Worksheets.Add
        ExcelWorkSheet.Name = ConvertToSheetName
        Dim ColumnCount As Integer = 1
        Dim RowCount As Integer = 1
        If IsNothing(ConvertColumnNames) Then
            For Each EachColumn As DataColumn In Me.SourceData.Columns
                ExcelWorkSheet.Cells(1, ColumnCount) = EachColumn.Caption
                ColumnCount += 1
            Next
            RowCount += 1
            For Each EachRow As DataRow In Me.SourceData.Rows
                ColumnCount = 1
                For Each EachColumn As DataColumn In Me.SourceData.Columns
                    'ExcelWorkSheet.Cells(RowCount, ColumnCount) = IIf(Me.SourceData.Columns(ColumnCount) Is GetType(String), "'", Nothing) & EachRow.Item(EachColumn.ColumnName)
                    ExcelWorkSheet.Cells(RowCount, ColumnCount) = EachRow.Item(EachColumn.ColumnName)
                    ColumnCount += 1
                Next
                RowCount += 1
            Next
        Else
            For Each EachItem As ConvertColumnName In ConvertColumnNames
                ExcelWorkSheet.Cells(1, ColumnCount) = EachItem.DisplayFieldName
                ColumnCount += 1
            Next
            RowCount += 1
            For Each EachRow As DataRow In Me.SourceData.Rows
                ColumnCount = 1
                For Each EachItem As ConvertColumnName In ConvertColumnNames
                    'ExcelWorkSheet.Cells(RowCount, ColumnCount) = IIf(Me.SourceData.Columns(ColumnCount) Is GetType(String), "'", Nothing) & EachRow.Item(EachItem.SourceFieldName)
                    ExcelWorkSheet.Cells(RowCount, ColumnCount) = EachRow.Item(EachItem.SourceFieldName)
                    ColumnCount += 1
                Next
                RowCount += 1
            Next
        End If
        RowCount = 2
        System.Runtime.InteropServices.Marshal.ReleaseComObject(ExcelWorkSheet)

        Return True
    End Function

#End Region


End Class


#Region "欄位轉換 類別:ConvertColumnName"
''' <summary>
''' 欄位轉換
''' </summary>
''' <remarks></remarks>
Public Class ConvertColumnName

    Sub New(ByVal SetSoureFieldName As String, ByVal SetDisplayName As String)
        Me.SourceFieldName = SetSoureFieldName
        Me.DisplayFieldName = SetDisplayName
    End Sub
    Sub New(ByVal SetSoureFieldName As String, ByVal SetDisplayName As String, ByVal SetDataType As System.Type)
        Me.SourceFieldName = SetSoureFieldName
        Me.DisplayFieldName = SetDisplayName
        Me.DataType = SetDataType
    End Sub

#Region "產生資料表 方法:CreatDataTable"
    ''' <summary>
    ''' 產生資料表
    ''' </summary>
    ''' <param name="ConvertSoure"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreatDataTable(ByVal ConvertSoure As List(Of ConvertColumnName)) As DataTable
        Dim ReturnValue As New DataTable
        For Each EachItem As ConvertColumnName In ConvertSoure
            If Not IsNothing(EachItem.DataType) Then
                ReturnValue.Columns.Add(EachItem.SourceFieldName, EachItem.DataType)
            End If
        Next
        Return ReturnValue
    End Function
#End Region

#Region "欄位名稱 屬性:SourceFieldName"

    Private _SourceFieldName As String
    ''' <summary>
    ''' 欄位名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SourceFieldName() As String
        Get
            Return _SourceFieldName
        End Get
        Set(ByVal value As String)
            _SourceFieldName = value
        End Set
    End Property
#End Region

#Region "顯示名稱  屬性:DisplayFieldName"

    Private _DisplayFieldName As String
    ''' <summary>
    ''' 顯示名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DisplayFieldName() As String
        Get
            Return _DisplayFieldName
        End Get
        Set(ByVal value As String)
            _DisplayFieldName = value
        End Set
    End Property
#End Region

#Region "欄位資料形別 屬性:DataType"


    Private _DataType As System.Type
    ''' <summary>
    ''' 欄位資料形別
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DataType() As System.Type
        Get
            Return _DataType
        End Get
        Set(ByVal value As System.Type)
            _DataType = value
        End Set
    End Property


#End Region

End Class
#End Region





#Region "NpoiClass：NPOI相關Method"

Class NpoiClass

#Region "NpoiSheetName：Sheet名稱"
    Private _npoiSheetName As String = "Sheet1"
    Public Property NpoiSheetName As String
        Get
            If _npoiSheetName.Trim = "" Then _npoiSheetName = "Sheet1"
            Return _npoiSheetName
        End Get
        Set(value As String)
            _npoiSheetName = value
        End Set
    End Property
#End Region

#Region "NpoiWorkBook：WorkBook物件"

    Private _npoiWorkbook As NPOI.HSSF.UserModel.HSSFWorkbook
    Public Property NpoiWorkBook As NPOI.HSSF.UserModel.HSSFWorkbook
        Get
            If IsNothing(_npoiWorkbook) Then
                _npoiWorkbook = New NPOI.HSSF.UserModel.HSSFWorkbook
            End If
            Return _npoiWorkbook
        End Get
        Set(value As NPOI.HSSF.UserModel.HSSFWorkbook)
            _npoiWorkbook = value
        End Set
    End Property
#End Region

#Region "NpoiSheet：Sheet物件"
    Private _npoiSheet As NPOI.HSSF.UserModel.HSSFSheet
    Public Property NpoiSheet As NPOI.HSSF.UserModel.HSSFSheet
        Get
            If IsNothing(_npoiSheet) Then
                _npoiSheet = NpoiWorkBook.CreateSheet(NpoiSheetName)
            Else
                _npoiSheet = NpoiWorkBook.GetSheet(NpoiWorkBook.GetSheetName(0))
            End If
            Return _npoiSheet
        End Get
        Set(value As NPOI.HSSF.UserModel.HSSFSheet)
            _npoiSheet = value
        End Set
    End Property
#End Region

#Region "SetDataTable：將DataTable物件載入"
    Public Sub SetDataTable(ByVal fromDataTable As DataTable)

        Dim indexRow As Integer = 0
        Dim npoiRow As NPOI.SS.UserModel.IRow
        Dim npoiCell As NPOI.SS.UserModel.ICell
        Dim cellValue As String

        '標題
        npoiRow = NpoiSheet.CreateRow(indexRow)
        For Each eachColumn As DataColumn In fromDataTable.Columns
            npoiCell = npoiRow.CreateCell(eachColumn.Ordinal)

            cellValue = eachColumn.ColumnName
            If Decimal.TryParse(cellValue, System.Globalization.NumberStyles.Number) = True Then
                npoiCell.SetCellValue(Decimal.Parse(cellValue, System.Globalization.NumberStyles.Number))
            Else
                npoiCell.SetCellValue(cellValue)
            End If

            ''文字格式
            'npoiCell.CellStyle.DataFormat = NPOI.HSSF.UserModel.HSSFDataFormat.GetBuiltinFormat("@")
        Next

        '內容

        For Each eachRow As DataRow In fromDataTable.Rows
            indexRow += 1
            npoiRow = NpoiSheet.CreateRow(indexRow)

            For Each eachColumn As DataColumn In fromDataTable.Columns
                npoiCell = npoiRow.CreateCell(eachColumn.Ordinal)

                'npoiCell.SetCellValue(eachRow.Item(eachColumn.ColumnName).ToString & Chr(13))

                'npoiCell.SetCellValue(eachRow.Item(eachColumn.ColumnName).ToString)
                'npoiCell.CellStyle.DataFormat = NPOI.HSSF.UserModel.HSSFDataFormat.GetBuiltinFormat("#")

                cellValue = eachRow.Item(eachColumn.ColumnName).ToString.Trim
                If Decimal.TryParse(cellValue, System.Globalization.NumberStyles.Number) = True Then
                    npoiCell.SetCellValue(Decimal.Parse(cellValue, System.Globalization.NumberStyles.Number))
                Else
                    npoiCell.SetCellValue(cellValue)
                End If
            Next
        Next
    End Sub

#End Region

#Region "SetWrapText：處理換行符號Cell要調整高度"
    Public Sub SetWrapText()
        Dim cs As NPOI.HSSF.UserModel.HSSFCellStyle
        Dim maxCellLine As Integer

        Dim newLineString() As String = New String() {"<br>", "<BR>", "\n", "\N", Chr(10)}

        For indexRow As Integer = 0 To NpoiSheet.PhysicalNumberOfRows - 1
            maxCellLine = 1
            Dim npoiRow As NPOI.SS.UserModel.IRow = NpoiSheet.GetRow(indexRow)
            'Dim cs As NPOI.HSSF.UserModel.HSSFCellStyle = NpoiWorkBook.CreateCellStyle
            'cs.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.TOP

            '將目前欄位的CellStyle設定為自動換行 
            ' cs.WrapText = True
            For indexCol As Integer = 0 To npoiRow.PhysicalNumberOfCells - 1
                Dim npoiCell As NPOI.SS.UserModel.ICell = npoiRow.GetCell(indexCol)

                cs = npoiCell.CellStyle
                cs.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.TOP
                '將目前欄位的CellStyle設定為自動換行 
                cs.WrapText = True

                'npoiCell.CellStyle = cs
                Try
                    npoiCell.CellStyle = cs

                    Dim cellText As String = npoiCell.RichStringCellValue.String

                    '計算換行符號次數
                    Dim nowCellLine As Integer = 1
                    For Each eachString As String In newLineString
                        nowCellLine += Split(cellText, eachString).Length - 1
                    Next

                    If nowCellLine > maxCellLine Then maxCellLine = nowCellLine

                    '置換換行符號
                    For Each eachString As String In newLineString
                        cellText = cellText.Replace(eachString, Chr(10))
                    Next
                    npoiCell.SetCellValue(cellText)

                Catch ex As Exception
                End Try
            Next

            'Row的高度
            npoiRow.Height = (NpoiSheet.DefaultRowHeight * maxCellLine)
            npoiRow.HeightInPoints = (NpoiSheet.DefaultRowHeightInPoints * maxCellLine)
        Next
    End Sub

#End Region

#Region "GetMemory：取得資料流"
    Public Function GetMemory() As IO.MemoryStream
        Dim ms As IO.MemoryStream = New IO.MemoryStream()
        Try

            Call SetWrapText()

            NpoiWorkBook.Write(ms)
        Finally
            NpoiWorkBook = Nothing
        End Try
        Return ms
    End Function
#End Region
End Class

#End Region