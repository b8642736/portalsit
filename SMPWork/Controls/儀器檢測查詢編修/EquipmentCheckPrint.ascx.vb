Public Partial Class EquipmentCheckPrint
    Inherits System.Web.UI.UserControl

    Dim DataContext As New SMPDataContext

#Region "查詢 方法:Search"
    '<DataObjectMethod(DataObjectMethodType.Select)> _
    'Function Search1() As List(Of SMPWork.ReportUseDataSet.EquipmentCheckDataTableRow)

    'End Function
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="StartDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal StartDate As Date, ByVal IsRealDataMode As Boolean) As SMPWork.ReportUseDataSet.EquipmentCheckDataTableDataTable
        If IsNothing(StartDate) Then
            Return New SMPWork.ReportUseDataSet.EquipmentCheckDataTableDataTable
        End If
        Dim ReturnValue As New SMPWork.ReportUseDataSet.EquipmentCheckDataTableDataTable

        For Each EachItem As Date In (From A In DataContext.標準樣本接收資料 Where A.日期時間 >= StartDate And A.日期時間 < StartDate.AddDays(1) Select A.日期時間.Date Distinct).ToList
            Dim AddItem As SMPWork.ReportUseDataSet.EquipmentCheckDataTableRow = ReturnValue.NewRow
            'Dim PrintArgConverter As New DataConvertClass(EachItem.Date, Me.PrintArgString.Item("比對值設定"), Me.PrintArgString.Item("比對值上限設定"), Me.PrintArgString.Item("比對值下限設定"), Me.PrintArgString.Item("溫度值設定"), Me.PrintArgString.Item("濕度值設定"))
            Dim PrintArgConverter As DataConvertClass = Nothing
            Try
                PrintArgConverter = New DataConvertClass(EachItem.Date, IsRealDataMode)
            Catch ex As Exception

            End Try
            If IsNothing(PrintArgConverter) Then
                Return New SMPWork.ReportUseDataSet.EquipmentCheckDataTableDataTable
            End If

            With AddItem
                .DataDate = Format(EachItem, "yyyy/MM/dd")
                .Title1Values = Me.PrintArgString.Item("JY56E表頭參數設定") & "@@@" & Me.PrintArgString.Item("Metalys2表頭參數設定") & "@@" & PrintArgConverter.TitleValuesString(1, 1) & "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
                .Title2Values = Me.PrintArgString.Item("NO表頭參數設定") & "@@@" & Me.PrintArgString.Item("CS表頭參數設定") & "@@" & PrintArgConverter.TitleValuesString(1, 2) & "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
                .Title1ValuesB = Me.PrintArgString.Item("XRF表頭參數設定") & "@@@" & Me.PrintArgString.Item("Metalys1表頭參數設定") & "@@" & PrintArgConverter.TitleValuesString(2, 1) & "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"

                .T1Row1Values = PrintArgConverter.PrintString(DataConvertClass.PrintStringType.早1STD)
                .T1Row2Values = PrintArgConverter.PrintString(DataConvertClass.PrintStringType.早1分析值)
                .T1Row3Values = PrintArgConverter.PrintString(DataConvertClass.PrintStringType.早2STD)
                .T1Row4Values = PrintArgConverter.PrintString(DataConvertClass.PrintStringType.早2分析值)
                .T1Row5Values = PrintArgConverter.PrintString(DataConvertClass.PrintStringType.中1STD)
                .T1Row6Values = PrintArgConverter.PrintString(DataConvertClass.PrintStringType.中1分析值)
                .T1Row7Values = PrintArgConverter.PrintString(DataConvertClass.PrintStringType.中2STD)
                .T1Row8Values = PrintArgConverter.PrintString(DataConvertClass.PrintStringType.中2分析值)
                .T1Row9Values = PrintArgConverter.PrintString(DataConvertClass.PrintStringType.夜1STD)
                .T1Row10Values = PrintArgConverter.PrintString(DataConvertClass.PrintStringType.夜1分析值)
                .T1Row11Values = PrintArgConverter.PrintString(DataConvertClass.PrintStringType.夜2STD)
                .T1Row12Values = PrintArgConverter.PrintString(DataConvertClass.PrintStringType.夜2分析值)
                .T2Row1Values = PrintArgConverter.PrintString(DataConvertClass.PrintStringType.NOCSSTD)
                .T2Row2Values = PrintArgConverter.PrintString(DataConvertClass.PrintStringType.NOCS分析值)
                .T1Row1ValuesB = PrintArgConverter.PrintString(DataConvertClass.PrintStringType.早1BSTD)
                .T1Row2ValuesB = PrintArgConverter.PrintString(DataConvertClass.PrintStringType.早1B分析值)
                .T1Row3ValuesB = PrintArgConverter.PrintString(DataConvertClass.PrintStringType.早2BSTD)
                .T1Row4ValuesB = PrintArgConverter.PrintString(DataConvertClass.PrintStringType.早2B分析值)
                .T1Row5ValuesB = PrintArgConverter.PrintString(DataConvertClass.PrintStringType.中1BSTD)
                .T1Row6ValuesB = PrintArgConverter.PrintString(DataConvertClass.PrintStringType.中1B分析值)
                .T1Row7ValuesB = PrintArgConverter.PrintString(DataConvertClass.PrintStringType.中2BSTD)
                .T1Row8ValuesB = PrintArgConverter.PrintString(DataConvertClass.PrintStringType.中2B分析值)
                .T1Row9ValuesB = PrintArgConverter.PrintString(DataConvertClass.PrintStringType.夜1BSTD)
                .T1Row10ValuesB = PrintArgConverter.PrintString(DataConvertClass.PrintStringType.夜1B分析值)
                .T1Row11ValuesB = PrintArgConverter.PrintString(DataConvertClass.PrintStringType.夜2BSTD)
                .T1Row12ValuesB = PrintArgConverter.PrintString(DataConvertClass.PrintStringType.夜2B分析值)
            End With
            ReturnValue.Rows.Add(AddItem)
        Next
        Return ReturnValue
    End Function
#End Region

#Region "資料列轉換類別 類別:DataConvertClass"
    Private Class DataConvertClass
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="SetDataDate"></param>
        ''' <remarks>
        '''Metalys1表頭參數設定|Metalys #1@SQ-F-09@分02
        '''Metalys2表頭參數設定|Metalys #2@SQ-F-10@分03
        '''NO表頭參數設定|TC-136,TC-436@SQ-F-1,SQ-F-2@分13,分25
        '''CS表頭參數設定|CS-400@SQ-F-30@分12
        '''XRF表頭參數設定|Rigaku 3550@SQ-F-25@分30
        '''JY56E表頭參數設定|JY-56E@SQ-F-08@SQ-F-25@分01
        ''' </remarks>
        Sub New(ByVal SetDataDate As Date, ByVal IsRealDataMode As Boolean)
            'Me.比對值 = 比對值設定
            'Me.容許誤差值上限 = 容許誤差值上限設定
            'Me.容許誤差值下限 = 容許誤差值下限設定
            'Me.溫度值 = 溫度值設定
            'Me.濕度值 = 濕度值設定
            Class1StartTime = SetDataDate.Date.AddHours(7).AddMinutes(30)
            Class2StartTime = SetDataDate.Date.AddHours(15).AddMinutes(30)
            Class3StartTime = SetDataDate.Date.AddHours(23).AddMinutes(30)
            IsRealDataDisplayMode = IsRealDataMode

            'For Each EachItem As 標準樣本接收資料 In (From A In DataContext.標準樣本接收資料 Where A.日期時間 >= Class1StartTime And A.日期時間 < Class1StartTime.AddDays(1) Select A Order By A.日期時間 Descending).ToList
            '    Me.所有分析內容值.Add(New 標準樣本接收資料OneSample(EachItem))
            'Next
            Dim TheDateAllDatas As List(Of 標準樣本接收資料) = (From A In DataContext.標準樣本接收資料 Where A.日期時間 >= Class1StartTime And A.日期時間 < Class1StartTime.AddDays(1) Select A Order By A.日期時間 Descending).ToList
            Dim AnalysisTimes As New List(Of DateTime)
            For Each EachItem In (From A In TheDateAllDatas Where A.日期時間 >= Class1StartTime And A.日期時間 < Class1StartTime.AddDays(1) Select 爐號 = A.爐號, 站別 = A.站別, 序號 = A.序號, 日期時間 = A.日期時間 Distinct Order By 日期時間 Descending).ToList
                'Me.所有分析內容值.Add(New 標準樣本接收資料OneSample(EachItem))
                Dim AddItem As 標準樣本接收資料 = (From A In TheDateAllDatas Where A.爐號 = EachItem.爐號 And A.站別 = EachItem.站別 And A.序號 = EachItem.序號 And A.日期時間 = EachItem.日期時間 Select A).FirstOrDefault
                If Not IsNothing(AddItem) Then
                    Me.所有分析內容值.Add(New 標準樣本接收資料OneSample(AddItem))
                End If
            Next
            Me.所有NO內容值.AddRange((From A In DataContext.標準樣本接收資料OX Where A.日期時間 >= Class1StartTime And A.日期時間 < Class1StartTime.AddDays(1) Select A Order By A.日期時間 Descending).ToList)
            Me.所有CS內容值.AddRange((From A In DataContext.標準樣本接收資料CS Where A.日期時間 >= Class1StartTime And A.日期時間 < Class1StartTime.AddDays(1) Select A Order By A.日期時間 Descending).ToList)

            If Not Me.IsRealDataDisplayMode Then
                For Each EachItem As 標準樣本接收資料OneSample In Me.所有分析內容值
                    EachItem.DataDisplayMode = 標準樣本接收資料OneSample.DataDisplayModeEnum.ForCheckMode
                Next
                For Each EachItem As 標準樣本接收資料OX In Me.所有NO內容值
                    EachItem.DataDisplayMode = 標準樣本接收資料OneSample.DataDisplayModeEnum.ForCheckMode
                Next
                For Each EachItem As 標準樣本接收資料CS In Me.所有CS內容值
                    EachItem.DataDisplayMode = 標準樣本接收資料OneSample.DataDisplayModeEnum.ForCheckMode
                Next
            End If
        End Sub

#Region "是否為真實資料顯示模式 屬性:IsRealDataDisplayMode"

        Private _IsRealDataDisplayMode As Boolean = True
        ''' <summary>
        ''' 是否為真實資料顯示模式
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IsRealDataDisplayMode() As Boolean
            Get
                Return _IsRealDataDisplayMode
            End Get
            Set(ByVal value As Boolean)
                _IsRealDataDisplayMode = value
            End Set
        End Property

#End Region

        Dim DataContext As New SMPDataContext
        'Private 比對值 As String
        'Private 容許誤差值上限 As String
        'Private 容許誤差值下限 As String
        'Private 溫度值 As String
        'Private 濕度值 As String
        Private 所有分析內容值 As New List(Of 標準樣本接收資料OneSample)
        Private 所有NO內容值 As New List(Of 標準樣本接收資料OX)
        Private 所有CS內容值 As New List(Of 標準樣本接收資料CS)
        Dim Class1StartTime As DateTime
        Dim Class2StartTime As DateTime
        Dim Class3StartTime As DateTime

        ReadOnly Property TitleValuesString(ByVal PageNumber As Integer, ByVal LineNumber As Integer) As String
            Get
                Dim AnalysisSampleDatas As New List(Of 標準樣本接收資料OneSample)
                Dim NOSampleDatas As New List(Of 標準樣本接收資料OX)
                Dim CSSampleDatas As New List(Of 標準樣本接收資料CS)

                Dim ReturnValue As String = Nothing
                Dim DeviceName() As String
                If PageNumber = 1 Then
                    DeviceName = {"JY#3", "JY#5"}
                Else
                    DeviceName = {"XRF", "JY#4"}
                End If

                Dim NoOrCsDatas As List(Of String) = New List(Of String)
                For Each DeviceNameString As String In DeviceName
                    Dim DeviceNameStringTemp As String = DeviceNameString
                    For ClassNumber As Integer = 1 To 3
                        AnalysisSampleDatas.Clear()
                        NOSampleDatas.Clear()
                        CSSampleDatas.Clear()
                        NoOrCsDatas.Clear()
                        Select Case ClassNumber
                            Case 1  '早1/早2
                                AnalysisSampleDatas = (From A In 所有分析內容值 Where A.日期時間 >= Class1StartTime And A.日期時間 < Class2StartTime And A.DeviceName.Trim = DeviceNameStringTemp Select A Order By A.日期時間).ToList
                                If DeviceNameString = "JY#3" Then
                                    NOSampleDatas = (From A In 所有NO內容值 Where A.日期時間 >= Class1StartTime And A.日期時間 < Class2StartTime Select A Order By A.日期時間).ToList
                                End If
                                If DeviceNameString = "JY#5" Then
                                    CSSampleDatas = (From A In 所有CS內容值 Where A.日期時間 >= Class1StartTime And A.日期時間 < Class2StartTime Select A Order By A.日期時間).ToList
                                End If
                            Case 2  '中1/中2
                                AnalysisSampleDatas = (From A In 所有分析內容值 Where A.日期時間 >= Class2StartTime And A.日期時間 < Class3StartTime And A.DeviceName.Trim = DeviceNameStringTemp Select A Order By A.日期時間).ToList
                                If DeviceNameString = "JY#3" Then
                                    NOSampleDatas = (From A In 所有NO內容值 Where A.日期時間 >= Class2StartTime And A.日期時間 < Class3StartTime Select A Order By A.日期時間).ToList
                                End If
                                If DeviceNameString = "JY#5" Then
                                    CSSampleDatas = (From A In 所有CS內容值 Where A.日期時間 >= Class2StartTime And A.日期時間 < Class3StartTime Select A Order By A.日期時間).ToList
                                End If
                            Case 3  '夜1/夜2
                                AnalysisSampleDatas = (From A In 所有分析內容值 Where A.日期時間 >= Class3StartTime And A.日期時間 < Class1StartTime.AddDays(1) And A.DeviceName.Trim = DeviceNameStringTemp Select A Order By A.日期時間).ToList
                                If DeviceNameString = "JY#3" Then
                                    NOSampleDatas = (From A In 所有NO內容值 Where A.日期時間 >= Class3StartTime And A.日期時間 < Class1StartTime.AddDays(1) Select A Order By A.日期時間).ToList
                                End If
                                If DeviceNameString = "JY#5" Then
                                    CSSampleDatas = (From A In 所有CS內容值 Where A.日期時間 >= Class3StartTime And A.日期時間 < Class1StartTime.AddDays(1) Select A Order By A.日期時間).ToList
                                End If
                        End Select

                        If LineNumber = 1 Then
                            Select Case True
                                Case AnalysisSampleDatas.Count = 0
                                    ReturnValue &= "@@@@"
                                Case AnalysisSampleDatas.Count < 2
                                    ReturnValue &= "@" & AnalysisSampleDatas(0).MakeDataEmployeeNumber & "@" & StandSampleNameConvert(AnalysisSampleDatas(0).UseStandardSampleName)
                                    ReturnValue &= "@@"
                                Case Else
                                    ReturnValue &= "@" & AnalysisSampleDatas(0).MakeDataEmployeeNumber & "@" & StandSampleNameConvert(AnalysisSampleDatas(0).UseStandardSampleName)
                                    ReturnValue &= "@" & AnalysisSampleDatas(1).MakeDataEmployeeNumber & "@" & StandSampleNameConvert(AnalysisSampleDatas(1).UseStandardSampleName)
                            End Select
                        Else
                            NoOrCsDatas.AddRange((From A In NOSampleDatas Select A.SampleID).ToList)
                            NoOrCsDatas.AddRange((From A In CSSampleDatas Select A.SampleID).ToList)
                            Select Case True
                                Case NoOrCsDatas.Count = 0
                                    NoOrCsDatas.Add("")
                                    NoOrCsDatas.Add("")
                                Case NoOrCsDatas.Count = 1
                                    NoOrCsDatas.Add("")
                            End Select


                            Select Case True
                                Case AnalysisSampleDatas.Count = 0
                                    ReturnValue &= "@@" & NoOrCsDatas(0) & "@@" & NoOrCsDatas(1)
                                Case AnalysisSampleDatas.Count < 2
                                    ReturnValue &= "@" & AnalysisSampleDatas(0).MakeDataEmployeeNumber & "@" & NoOrCsDatas(0)
                                    ReturnValue &= "@@" & NoOrCsDatas(1)
                                Case Else
                                    ReturnValue &= "@" & AnalysisSampleDatas(0).MakeDataEmployeeNumber & "@" & NoOrCsDatas(0)
                                    ReturnValue &= "@" & AnalysisSampleDatas(1).MakeDataEmployeeNumber & "@" & NoOrCsDatas(1)
                            End Select
                        End If

                    Next
                Next


                'If LineNumber = 2 Then
                '    For ClassNumber As Integer = 1 To 3
                '        Select Case ClassNumber
                '            Case 1  '早1/早2
                '                AnalysisSampleDatas = (From A In 所有分析內容值 Where A.日期時間 >= Class1StartTime And A.日期時間 < Class2StartTime And A.DeviceName.Trim = DeviceNameStringTemp Select A Order By A.日期時間).ToList
                '                NOSampleDatas = (From A In 所有NO內容值 Where A.日期時間 >= Class1StartTime And A.日期時間 < Class2StartTime Select A Order By A.日期時間).ToList
                '                CSSampleDatas = (From A In 所有CS內容值 Where A.日期時間 >= Class1StartTime And A.日期時間 < Class2StartTime Select A Order By A.日期時間).ToList
                '            Case 2  '中1/中2
                '                AnalysisSampleDatas = (From A In 所有分析內容值 Where A.日期時間 >= Class2StartTime And A.日期時間 < Class3StartTime And A.DeviceName.Trim = DeviceNameStringTemp Select A Order By A.日期時間).ToList
                '                NOSampleDatas = (From A In 所有NO內容值 Where A.日期時間 >= Class2StartTime And A.日期時間 < Class3StartTime Select A Order By A.日期時間).ToList
                '                CSSampleDatas = (From A In 所有CS內容值 Where A.日期時間 >= Class2StartTime And A.日期時間 < Class3StartTime Select A Order By A.日期時間).ToList
                '            Case 3  '夜1/夜2
                '                AnalysisSampleDatas = (From A In 所有分析內容值 Where A.日期時間 >= Class3StartTime And A.日期時間 < Class1StartTime.AddDays(1) And A.DeviceName.Trim = DeviceNameStringTemp Select A Order By A.日期時間).ToList
                '                NOSampleDatas = (From A In 所有NO內容值 Where A.日期時間 >= Class3StartTime And A.日期時間 < Class1StartTime.AddDays(1) Select A Order By A.日期時間).ToList
                '                CSSampleDatas = (From A In 所有CS內容值 Where A.日期時間 >= Class3StartTime And A.日期時間 < Class1StartTime.AddDays(1) Select A Order By A.日期時間).ToList
                '        End Select
                '    Next
                '    Dim EmployeeNumbers As List(Of String) = New List(Of String)
                '    Dim NOSampleNames As List(Of String) = New List(Of String)
                '    Dim CSSampleNames As List(Of String) = New List(Of String)
                '    Select Case True
                '        Case AnalysisSampleDatas.Count = 0
                '        Case AnalysisSampleDatas.Count < 2
                '            EmployeeNumbers.Add(AnalysisSampleDatas(0).MakeDataEmployeeNumber)
                '        Case Else
                '            EmployeeNumbers.Add(AnalysisSampleDatas(0).MakeDataEmployeeNumber)
                '            EmployeeNumbers.Add(AnalysisSampleDatas(1).MakeDataEmployeeNumber)
                '    End Select
                '    Select Case True
                '        Case NOSampleDatas.Count = 0
                '        Case NOSampleDatas.Count < 2
                '            NOSampleNames.Add(NOSampleDatas(0).SampleID)
                '        Case Else
                '            NOSampleNames.Add(NOSampleDatas(0).SampleID)
                '            NOSampleNames.Add(NOSampleDatas(1).SampleID)
                '    End Select
                '    Select Case True
                '        Case CSSampleDatas.Count = 0
                '        Case CSSampleDatas.Count < 2
                '            CSSampleNames.Add(CSSampleDatas(0).SampleID)
                '        Case Else
                '            CSSampleNames.Add(CSSampleDatas(0).SampleID)
                '            CSSampleNames.Add(CSSampleDatas(1).SampleID)
                '    End Select

                'End If

                Return ReturnValue
            End Get
        End Property

        Private Function StandSampleNameConvert(ByVal OrginSampleName As String) As String
            If String.IsNullOrEmpty(OrginSampleName) Then
                Return ""
            End If
            Return IIf(OrginSampleName.ToUpper.Substring(0, 2) = "2F", "2F", OrginSampleName)
        End Function

        'ReadOnly Property TitleValuesString(ByVal PageNumber As Integer) As String
        '    Get
        '        Dim SampleDatas As New List(Of 標準樣本接收資料OneSample)
        '        Dim ReturnValue As String = Nothing
        '        Dim DeviceName() As String
        '        If PageNumber = 1 Then
        '            DeviceName = {"JY#3", "JY#5"}
        '        Else
        '            DeviceName = {"XRF", "JY#4"}
        '        End If
        '        For Each DeviceNameString As String In DeviceName
        '            Dim DeviceNameStringTemp As String = DeviceNameString
        '            For ClassNumber As Integer = 1 To 3
        '                SampleDatas.Clear()
        '                Select Case ClassNumber
        '                    Case 1  '早1/早2
        '                        SampleDatas = (From A In 所有分析內容值 Where A.日期時間 >= Class1StartTime And A.日期時間 < Class2StartTime And A.DeviceName.Trim = DeviceNameStringTemp Select A Order By A.日期時間).ToList
        '                    Case 2  '中1/中2
        '                        SampleDatas = (From A In 所有分析內容值 Where A.日期時間 >= Class2StartTime And A.日期時間 < Class3StartTime And A.DeviceName.Trim = DeviceNameStringTemp Select A Order By A.日期時間).ToList
        '                    Case 3  '夜1/夜2
        '                        SampleDatas = (From A In 所有分析內容值 Where A.日期時間 >= Class3StartTime And A.日期時間 < Class1StartTime.AddDays(1) And A.DeviceName.Trim = DeviceNameStringTemp Select A Order By A.日期時間).ToList
        '                End Select
        '                Select Case True
        '                    Case SampleDatas.Count = 0
        '                        ReturnValue &= "@@@@"
        '                    Case SampleDatas.Count < 2
        '                        ReturnValue &= "@" & SampleDatas(0).MakeDataEmployeeNumber & "@" & SampleDatas(0).UseStandardSampleName
        '                        ReturnValue &= "@@"
        '                    Case Else
        '                        ReturnValue &= "@" & SampleDatas(0).MakeDataEmployeeNumber & "@" & SampleDatas(0).UseStandardSampleName
        '                        ReturnValue &= "@" & SampleDatas(1).MakeDataEmployeeNumber & "@" & SampleDatas(1).UseStandardSampleName
        '                End Select
        '            Next
        '        Next
        '        Return ReturnValue
        '    End Get
        'End Property



        ReadOnly Property PrintString(ByVal GetStringType As PrintStringType) As String
            Get
                Try
                    Dim ReturnValue As String = Nothing
                    Dim FilterStartTime As DateTime
                    Dim FilterEndTime As DateTime
                    Dim FilterLeftDeviceName As String
                    Dim FilterRightDeviceName As String

                    If GetStringType = PrintStringType.早1STD OrElse GetStringType = PrintStringType.早2STD _
                       OrElse GetStringType = PrintStringType.中1STD OrElse GetStringType = PrintStringType.中2STD _
                       OrElse GetStringType = PrintStringType.夜1STD OrElse GetStringType = PrintStringType.夜2STD _
                       OrElse GetStringType = PrintStringType.早1分析值 OrElse GetStringType = PrintStringType.早2分析值 _
                       OrElse GetStringType = PrintStringType.中1分析值 OrElse GetStringType = PrintStringType.中2分析值 _
                       OrElse GetStringType = PrintStringType.夜1分析值 OrElse GetStringType = PrintStringType.夜2分析值 _
                       OrElse GetStringType = PrintStringType.NOCSSTD _
                       Then
                        FilterLeftDeviceName = "JY#3"
                        FilterRightDeviceName = "JY#5"
                    End If
                    If GetStringType = PrintStringType.早1BSTD OrElse GetStringType = PrintStringType.早2BSTD _
                       OrElse GetStringType = PrintStringType.中1BSTD OrElse GetStringType = PrintStringType.中2BSTD _
                       OrElse GetStringType = PrintStringType.夜1BSTD OrElse GetStringType = PrintStringType.夜2BSTD _
                       OrElse GetStringType = PrintStringType.早1B分析值 OrElse GetStringType = PrintStringType.早2B分析值 _
                       OrElse GetStringType = PrintStringType.中1B分析值 OrElse GetStringType = PrintStringType.中2B分析值 _
                       OrElse GetStringType = PrintStringType.夜1B分析值 OrElse GetStringType = PrintStringType.夜2B分析值 _
                       Then
                        FilterLeftDeviceName = "XRF"
                        FilterRightDeviceName = "JY#4"
                    End If


                    If GetStringType.ToString.Contains("早") Then
                        FilterStartTime = Class1StartTime
                        FilterEndTime = Class2StartTime
                    End If
                    If GetStringType.ToString.Contains("中") Then
                        FilterStartTime = Class2StartTime
                        FilterEndTime = Class3StartTime
                    End If
                    If GetStringType.ToString.Contains("夜") Then
                        FilterStartTime = Class3StartTime
                        FilterEndTime = Class1StartTime.AddDays(1)
                    End If


                    Dim Class1CSData As 標準樣本接收資料CS = Nothing
                    Dim Class2CSData As 標準樣本接收資料CS = Nothing
                    Dim Class3CSData As 標準樣本接收資料CS = Nothing
                    Dim Class1NOData As 標準樣本接收資料OX = Nothing
                    Dim Class2NOData As 標準樣本接收資料OX = Nothing
                    Dim Class3NOData As 標準樣本接收資料OX = Nothing
                    If GetStringType = PrintStringType.NOCSSTD OrElse GetStringType = PrintStringType.NOCS分析值 Then
                        Class1CSData = (From A In DataContext.標準樣本接收資料CS Where A.日期時間 >= Class1StartTime And A.日期時間 < Class2StartTime Select A Order By A.日期時間 Descending).FirstOrDefault
                        Class2CSData = (From A In DataContext.標準樣本接收資料CS Where A.日期時間 >= Class2StartTime And A.日期時間 < Class3StartTime Select A Order By A.日期時間 Descending).FirstOrDefault
                        Class3CSData = (From A In DataContext.標準樣本接收資料CS Where A.日期時間 >= Class3StartTime And A.日期時間 < Class1StartTime.AddDays(1) Select A Order By A.日期時間 Descending).FirstOrDefault
                        Class1NOData = (From A In DataContext.標準樣本接收資料OX Where A.日期時間 >= Class1StartTime And A.日期時間 < Class2StartTime Select A Order By A.日期時間 Descending).FirstOrDefault
                        Class2NOData = (From A In DataContext.標準樣本接收資料OX Where A.日期時間 >= Class2StartTime And A.日期時間 < Class3StartTime Select A Order By A.日期時間 Descending).FirstOrDefault
                        Class3NOData = (From A In DataContext.標準樣本接收資料OX Where A.日期時間 >= Class3StartTime And A.日期時間 < Class1StartTime.AddDays(1) Select A Order By A.日期時間 Descending).FirstOrDefault
                    End If



                    'Dim StdData As 標準樣本接收資料OneSample = Nothing
                    Dim SMPStdSample As SMPStandardSample = Nothing
                    Select Case True
                        Case GetStringType = PrintStringType.早1STD OrElse GetStringType = PrintStringType.早2STD OrElse GetStringType = PrintStringType.中1STD OrElse GetStringType = PrintStringType.中2STD OrElse GetStringType = PrintStringType.夜1STD OrElse GetStringType = PrintStringType.夜2STD _
                            OrElse GetStringType = PrintStringType.早1BSTD OrElse GetStringType = PrintStringType.早2BSTD OrElse GetStringType = PrintStringType.中1BSTD OrElse GetStringType = PrintStringType.中2BSTD OrElse GetStringType = PrintStringType.夜1BSTD OrElse GetStringType = PrintStringType.夜2BSTD
                            '顯示標準值
                            Dim SampleDatas As List(Of 標準樣本接收資料OneSample) = (From A In 所有分析內容值 Where A.日期時間 >= FilterStartTime And A.日期時間 < FilterEndTime And A.DeviceName.Trim = FilterLeftDeviceName Select A Order By A.日期時間).ToList
                            ReturnValue = Me.GetTemperateOrWet(GetStringType, True)
                            Select Case Me.GetTemperateAndWetIsGood(GetStringType)
                                Case True
                                    ReturnValue &= "@O"
                                Case False
                                    ReturnValue &= "@X"
                                Case Else
                                    ReturnValue &= "@"
                            End Select
                            Select Case True
                                Case SampleDatas.Count = 0
                                    ReturnValue &= "@@@@@@@@@@"
                                Case SampleDatas.Count >= 1 AndAlso GetStringType.ToString.Substring(1, 1) = "1"
                                    SMPStdSample = SampleDatas(0).AboutSMPStandardSample
                                    ReturnValue &= "@" & SMPStdSample.C & "@" & SMPStdSample.Si & "@" & SMPStdSample.Mn & "@" & SMPStdSample.P & "@" & SMPStdSample.S & "@" & SMPStdSample.Cr & "@" & SMPStdSample.Ni & "@" & SMPStdSample.Cu & "@" & SMPStdSample.Mo
                                    ReturnValue &= "@" '& IIf(DiffValuesIsGood(SampleDatas(0)), "O", "X")   '判定
                                Case SampleDatas.Count < 2 AndAlso GetStringType.ToString.Substring(1, 1) = "2"
                                    ReturnValue &= "@@@@@@@@@@"
                                Case SampleDatas.Count >= 2 AndAlso GetStringType.ToString.Substring(1, 1) = "2"
                                    SMPStdSample = SampleDatas(1).AboutSMPStandardSample
                                    ReturnValue &= "@" & SMPStdSample.C & "@" & SMPStdSample.Si & "@" & SMPStdSample.Mn & "@" & SMPStdSample.P & "@" & SMPStdSample.S & "@" & SMPStdSample.Cr & "@" & SMPStdSample.Ni & "@" & SMPStdSample.Cu & "@" & SMPStdSample.Mo
                                    ReturnValue &= "@" '& IIf(DiffValuesIsGood(SampleDatas(0)), "O", "X")   '判定
                            End Select

                            SampleDatas = (From A In 所有分析內容值 Where A.日期時間 >= FilterStartTime And A.日期時間 < FilterEndTime And A.DeviceName.Trim = FilterRightDeviceName Select A Order By A.日期時間).ToList
                            Select Case True
                                Case SampleDatas.Count = 0
                                Case SampleDatas.Count >= 1 AndAlso GetStringType.ToString.Substring(1, 1) = "1"
                                    SMPStdSample = SampleDatas(0).AboutSMPStandardSample
                                    ReturnValue &= "@" & SMPStdSample.C & "@" & SMPStdSample.Si & "@" & SMPStdSample.Mn & "@" & SMPStdSample.P & "@" & SMPStdSample.S & "@" & SMPStdSample.Cr & "@" & SMPStdSample.Ni & "@" & SMPStdSample.Cu & "@" & SMPStdSample.Mo
                                Case SampleDatas.Count >= 2 AndAlso GetStringType.ToString.Substring(1, 1) = "2"
                                    SMPStdSample = SampleDatas(1).AboutSMPStandardSample
                                    ReturnValue &= "@" & SMPStdSample.C & "@" & SMPStdSample.Si & "@" & SMPStdSample.Mn & "@" & SMPStdSample.P & "@" & SMPStdSample.S & "@" & SMPStdSample.Cr & "@" & SMPStdSample.Ni & "@" & SMPStdSample.Cu & "@" & SMPStdSample.Mo
                            End Select
                        Case GetStringType = PrintStringType.早1分析值 OrElse GetStringType = PrintStringType.早2分析值 OrElse GetStringType = PrintStringType.中1分析值 OrElse GetStringType = PrintStringType.中2分析值 OrElse GetStringType = PrintStringType.夜1分析值 OrElse GetStringType = PrintStringType.夜2分析值 _
                            OrElse GetStringType = PrintStringType.早1B分析值 OrElse GetStringType = PrintStringType.早2B分析值 OrElse GetStringType = PrintStringType.中1B分析值 OrElse GetStringType = PrintStringType.中2B分析值 OrElse GetStringType = PrintStringType.夜1B分析值 OrElse GetStringType = PrintStringType.夜2B分析值

                            Dim SampleDatas As List(Of 標準樣本接收資料OneSample) = (From A In 所有分析內容值 Where A.日期時間 >= FilterStartTime And A.日期時間 < FilterEndTime And A.DeviceName.Trim = FilterLeftDeviceName Select A Order By A.日期時間).ToList
                            ReturnValue = Me.GetTemperateOrWet(GetStringType, False) & "@"
                            Select Case True
                                Case SampleDatas.Count = 0
                                    ReturnValue &= "@@@@@@@@@@"
                                Case SampleDatas.Count >= 1 AndAlso GetStringType.ToString.Substring(1, 1) = "1"
                                    ReturnValue &= "@" & SampleDatas(0).C & "@" & SampleDatas(0).Si & "@" & SampleDatas(0).Mn & "@" & SampleDatas(0).P & "@" & SampleDatas(0).S & "@" & SampleDatas(0).Cr & "@" & SampleDatas(0).Ni & "@" & SampleDatas(0).Cu & "@" & SampleDatas(0).Mo
                                    ReturnValue &= "@" & IIf(DiffValuesIsGood(SampleDatas(0)), "O", "X")   '判定
                                Case SampleDatas.Count < 2 AndAlso GetStringType.ToString.Substring(1, 1) = "2"
                                    ReturnValue &= "@@@@@@@@@@"
                                Case SampleDatas.Count >= 2 AndAlso GetStringType.ToString.Substring(1, 1) = "2"
                                    ReturnValue &= "@" & SampleDatas(1).C & "@" & SampleDatas(1).Si & "@" & SampleDatas(1).Mn & "@" & SampleDatas(1).P & "@" & SampleDatas(1).S & "@" & SampleDatas(1).Cr & "@" & SampleDatas(1).Ni & "@" & SampleDatas(1).Cu & "@" & SampleDatas(1).Mo
                                    ReturnValue &= "@" & IIf(DiffValuesIsGood(SampleDatas(1)), "O", "X")   '判定
                            End Select

                            SampleDatas = (From A In 所有分析內容值 Where A.日期時間 >= FilterStartTime And A.日期時間 < FilterEndTime And A.DeviceName.Trim = FilterRightDeviceName Select A Order By A.日期時間).ToList
                            Select Case True
                                Case SampleDatas.Count = 0
                                Case SampleDatas.Count >= 1 AndAlso GetStringType.ToString.Substring(1, 1) = "1"
                                    ReturnValue &= "@" & SampleDatas(0).C & "@" & SampleDatas(0).Si & "@" & SampleDatas(0).Mn & "@" & SampleDatas(0).P & "@" & SampleDatas(0).S & "@" & SampleDatas(0).Cr & "@" & SampleDatas(0).Ni & "@" & SampleDatas(0).Cu & "@" & SampleDatas(0).Mo
                                    ReturnValue &= "@" & IIf(DiffValuesIsGood(SampleDatas(0)), "O", "X")   '判定
                                Case SampleDatas.Count >= 2 AndAlso GetStringType.ToString.Substring(1, 1) = "2"
                                    ReturnValue &= "@" & SampleDatas(1).C & "@" & SampleDatas(1).Si & "@" & SampleDatas(1).Mn & "@" & SampleDatas(1).P & "@" & SampleDatas(1).S & "@" & SampleDatas(1).Cr & "@" & SampleDatas(1).Ni & "@" & SampleDatas(1).Cu & "@" & SampleDatas(1).Mo
                                    ReturnValue &= "@" & IIf(DiffValuesIsGood(SampleDatas(1)), "O", "X")   '判定
                            End Select

                        Case GetStringType = PrintStringType.NOCSSTD
                            '顯示標準值
                            Dim NOString As String = Nothing
                            Dim CSString As String = Nothing
                            If Not IsNothing(Class1NOData) AndAlso Not IsNothing(Class1NOData.AboutSMPStandardSample) Then
                                NOString = Class1NOData.AboutSMPStandardSample.N & "@0@"
                            Else
                                NOString = "@@"
                            End If
                            If Not IsNothing(Class2NOData) AndAlso Not IsNothing(Class2NOData.AboutSMPStandardSample) Then
                                NOString &= "@" & Class2NOData.AboutSMPStandardSample.N & "@0@"
                            Else
                                NOString &= "@@@"
                            End If
                            If Not IsNothing(Class3NOData) AndAlso Not IsNothing(Class3NOData.AboutSMPStandardSample) Then
                                NOString &= "@" & Class3NOData.AboutSMPStandardSample.N & "@0@"
                            Else
                                NOString &= "@@@"
                            End If
                            If Not IsNothing(Class1CSData) AndAlso Not IsNothing(Class1CSData.AboutSMPStandardSample) Then
                                CSString = Class1CSData.AboutSMPStandardSample.C & "@" & Class1CSData.AboutSMPStandardSample.S & "@"
                            Else
                                CSString = "@@"
                            End If
                            If Not IsNothing(Class2CSData) AndAlso Not IsNothing(Class2CSData.AboutSMPStandardSample) Then
                                CSString &= "@" & Class2CSData.AboutSMPStandardSample.C & "@" & Class2CSData.AboutSMPStandardSample.S & "@"
                            Else
                                CSString &= "@@@"
                            End If
                            If Not IsNothing(Class3CSData) AndAlso Not IsNothing(Class3CSData.AboutSMPStandardSample) Then
                                CSString &= "@" & Class3CSData.AboutSMPStandardSample.C & "@" & Class3CSData.AboutSMPStandardSample.S & "@"
                            Else
                                CSString &= "@@@"
                            End If

                            ReturnValue = NOString & "@@" & CSString
                        Case GetStringType = PrintStringType.NOCS分析值
                            If Not IsNothing(Class1NOData) Then
                                ReturnValue = Class1NOData.N1 & "@" & Class1NOData.O1
                                ReturnValue &= "@" & NODiffValuesIsGood(Class1NOData)   '判定
                            Else
                                ReturnValue &= "@@"
                            End If
                            If Not IsNothing(Class2NOData) Then
                                ReturnValue &= "@" & Class2NOData.N1 & "@" & Class2NOData.O1
                                ReturnValue &= "@" & NODiffValuesIsGood(Class2NOData)   '判定
                            Else
                                ReturnValue &= "@@@"
                            End If
                            If Not IsNothing(Class3NOData) Then
                                ReturnValue &= "@" & Class3NOData.N1 & "@" & Class3NOData.O1
                                ReturnValue &= "@" & NODiffValuesIsGood(Class3NOData)   '判定
                            Else
                                ReturnValue &= "@@@"
                            End If


                            If Not IsNothing(Class1CSData) Then
                                ReturnValue &= "@" & Class1CSData.C1 & "@" & Class1CSData.S1
                                ReturnValue &= "@" & CSDiffValuesIsGood(Class1CSData)   '判定
                            Else
                                ReturnValue &= "@@@"
                            End If
                            If Not IsNothing(Class2CSData) Then
                                ReturnValue &= "@" & CSDiffValuesIsGood(Class2CSData)   '判定
                            Else
                                ReturnValue &= "@"
                            End If
                            If Not IsNothing(Class3CSData) Then
                                ReturnValue &= "@" & CSDiffValuesIsGood(Class3CSData)   '判定
                            Else
                                ReturnValue &= "@"
                            End If

                    End Select

                    Return FormatReturnValue(ReturnValue, GetStringType) & "@@@@@@@@@@@@@@@@@@@@@@@@@"
                Catch ex As Exception
                    Return "DataErr:" & ex.ToString & "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
                End Try

            End Get
        End Property

#Region "格式化回傳數值 方法:FormatReturnValue"
        ''' <summary>
        ''' 格式化回傳數值
        ''' </summary>
        ''' <param name="SourceData"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function FormatReturnValue(ByVal SourceData As String, ByVal GetStringType As PrintStringType) As String
            Dim ReturenValue As String = Nothing
            For Each EachItem As String In SourceData.Split("@")
                If String.IsNullOrEmpty(EachItem) And Not IsNumeric(EachItem) Then
                    ReturenValue &= EachItem & "@"
                    Continue For
                End If
                If GetStringType = PrintStringType.NOCS分析值 OrElse GetStringType = PrintStringType.NOCSSTD Then
                    ReturenValue &= Format(Val(EachItem), "0.####") & "@"
                Else
                    ReturenValue &= Format(Val(EachItem), "0.###") & "@"
                End If
            Next
            Return ReturenValue
        End Function
#End Region

#Region "轉換NO資料OneSample為ListData 方法:ConvertNOSampleToListData"
        Private Function ConvertNOSampleToListData(ByVal SourceData As 標準樣本接收資料OX) As List(Of Single)
            Dim ReturnValue As New List(Of Single)
            ReturnValue.Add(SourceData.N1)
            ReturnValue.Add(SourceData.O1)
            Return ReturnValue
        End Function
#End Region
#Region "轉換CS資料OneSample為ListData 方法:ConvertCSSampleToListData"
        Private Function ConvertCSSampleToListData(ByVal SourceData As 標準樣本接收資料CS) As List(Of Single)
            Dim ReturnValue As New List(Of Single)
            ReturnValue.Add(SourceData.C1)
            ReturnValue.Add(SourceData.S1)
            Return ReturnValue
        End Function
#End Region


#Region "差值計算判定 函數:DiffValuesIsGood"
        ''' <summary>
        ''' 差值計算判定
        ''' </summary>
        ''' <param name="SourceData"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function DiffValuesIsGood(ByVal SourceData As 標準樣本接收資料OneSample) As Boolean
            Select Case True
                Case IsNothing(SourceData)
                    Throw New Exception("找不到 標準樣本接收資料")
                Case IsNothing(SourceData.AboutSMPStandardSample)
                    Throw New Exception("找不到 比對樣本資料")
                Case IsNothing(SourceData.About標準樣本接收資料上下限)
                    Throw New Exception("找不到  比對樣本之上下限資料")
            End Select
            If SourceData.C > SourceData.About標準樣本接收資料上下限.UP_C OrElse SourceData.C < SourceData.About標準樣本接收資料上下限.Down_C _
                OrElse SourceData.Si > SourceData.About標準樣本接收資料上下限.UP_Si OrElse SourceData.Si < SourceData.About標準樣本接收資料上下限.Down_Si _
                OrElse SourceData.Mn > SourceData.About標準樣本接收資料上下限.UP_Mn OrElse SourceData.Mn < SourceData.About標準樣本接收資料上下限.Down_Mn _
                OrElse SourceData.P > SourceData.About標準樣本接收資料上下限.UP_P OrElse SourceData.P < SourceData.About標準樣本接收資料上下限.Down_P _
                OrElse SourceData.S > SourceData.About標準樣本接收資料上下限.UP_S OrElse SourceData.S < SourceData.About標準樣本接收資料上下限.Down_S _
                OrElse SourceData.Cr > SourceData.About標準樣本接收資料上下限.UP_Cr OrElse SourceData.Cr < SourceData.About標準樣本接收資料上下限.Down_Cr _
                OrElse SourceData.Ni > SourceData.About標準樣本接收資料上下限.UP_Ni OrElse SourceData.Ni < SourceData.About標準樣本接收資料上下限.Down_Ni _
                OrElse SourceData.Cu > SourceData.About標準樣本接收資料上下限.UP_Cu OrElse SourceData.Cu < SourceData.About標準樣本接收資料上下限.Down_Cu _
                OrElse SourceData.Mo > SourceData.About標準樣本接收資料上下限.UP_Mo OrElse SourceData.Mo < SourceData.About標準樣本接收資料上下限.Down_Mo Then
                Return False
            End If
            Return True
        End Function
#End Region
#Region "NO差值計算判定 函數:NODiffValuesIsGood"
        ''' <summary>
        ''' NO差值計算判定
        ''' </summary>
        ''' <param name="SourceData"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function NODiffValuesIsGood(ByVal SourceData As 標準樣本接收資料OX) As String
            Dim ReturnValue As Nullable(Of Boolean) = Nothing
            If IsNothing(SourceData) Then
                Return "--"
            End If
            Dim GetAbout標準樣本接收資料上下限 As 標準樣本接收資料上下限 = SourceData.About標準樣本接收資料上下限
            If IsNothing(GetAbout標準樣本接收資料上下限) Then
                Return "--"
            End If
            If SourceData.N1 > GetAbout標準樣本接收資料上下限.UP_N2 OrElse SourceData.N1 < GetAbout標準樣本接收資料上下限.Down_N2 Then
                ReturnValue = "X"
            End If
            'O不比對
            Return "O"
        End Function
#End Region
#Region "CS差值計算判定 函數:CSDiffValuesIsGood"
        ''' <summary>
        ''' CS差值計算判定
        ''' </summary>
        ''' <param name="SourceData"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function CSDiffValuesIsGood(ByVal SourceData As 標準樣本接收資料CS) As String
            Dim ReturnValue As Nullable(Of Boolean) = Nothing
            If IsNothing(SourceData) Then
                Return "--"
            End If
            Dim GetAbout標準樣本接收資料上下限 As 標準樣本接收資料上下限 = SourceData.About標準樣本接收資料上下限
            If IsNothing(GetAbout標準樣本接收資料上下限) Then
                Return "--"
            End If
            If SourceData.C1 > GetAbout標準樣本接收資料上下限.UP_C OrElse SourceData.C1 < GetAbout標準樣本接收資料上下限.Down_C Then
                Return "X"
            End If
            If SourceData.S1 > GetAbout標準樣本接收資料上下限.UP_S OrElse SourceData.S1 < GetAbout標準樣本接收資料上下限.Down_S Then
                Return "X"
            End If
            Return "O"
        End Function

#End Region

#Region "取得溫度或濕度 方法:GetTemperate"
        ''' <summary>
        ''' 取得溫度或濕度
        ''' </summary>
        ''' <param name="GetClassType"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetTemperateOrWet(ByVal GetClassType As PrintStringType, ByVal IsGetTemperate As Boolean) As String
            Dim StartDateTime As DateTime
            Dim EndDateTime As DateTime
            Dim GetArgVal As String = GetClassType.ToString.Substring(0, 2)
            Select Case True
                Case GetArgVal = "早1" Or GetArgVal = "早2"
                    StartDateTime = Class1StartTime : EndDateTime = Class2StartTime
                Case GetArgVal = "中1" Or GetArgVal = "中2"
                    StartDateTime = Class2StartTime : EndDateTime = Class3StartTime
                Case GetArgVal = "夜1" Or GetArgVal = "夜2"
                    StartDateTime = Class3StartTime : EndDateTime = Class1StartTime.AddDays(1)
            End Select
            Dim GetValues As List(Of 溫濕度記錄) = (From A In DataContext.溫濕度記錄 Where A.DataDateTime >= StartDateTime And A.DataDateTime <= EndDateTime Select A).ToList
            If GetClassType.ToString.Substring(0, 2) = "早2" OrElse GetClassType.ToString.Substring(0, 2) = "中2" OrElse GetClassType.ToString.Substring(0, 2) = "夜2" Then
                If GetValues.Count < 2 Then
                    Return Nothing
                Else
                    Return IIf(IsGetTemperate, GetValues(1).Temperture, GetValues(1).Humidity)
                End If
            Else
                If GetValues.Count < 1 Then
                    Return Nothing
                Else
                    Return IIf(IsGetTemperate, GetValues(0).Temperture, GetValues(0).Humidity)
                End If
            End If
            Return Nothing
        End Function
#End Region
#Region "取得溫度及濕度判定是否合格 方法:GetTemperateAndWetIsGood"
        ''' <summary>
        ''' 取得溫度判定是否合格
        ''' </summary>
        ''' <param name="GetClassType"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetTemperateAndWetIsGood(ByVal GetClassType As PrintStringType) As Nullable(Of Boolean)
            Dim Value1 As String = GetTemperateOrWet(GetClassType, True)
            Dim Value2 As String = GetTemperateOrWet(GetClassType, False)
            If IsNothing(Value1) OrElse IsNothing(Value2) Then
                Return Nothing
            End If
            Return Val(Value1) >= 19 And Val(Value1) <= 25 And Val(Value2) <= 70
        End Function

#End Region



        Public Enum PrintStringType
            '成分比對值 = 0
            'NOCS分析標準值 = 13
            早1分析值 = 1
            早1STD = 2
            早2分析值 = 3
            早2STD = 4
            中1分析值 = 5
            中1STD = 6
            中2分析值 = 7
            中2STD = 8
            夜1分析值 = 9
            夜1STD = 10
            夜2分析值 = 11
            夜2STD = 12
            NOCS分析值 = 13
            NOCSSTD = 14
            早1B分析值 = 15
            早1BSTD = 16
            早2B分析值 = 17
            早2BSTD = 18
            中1B分析值 = 19
            中1BSTD = 20
            中2B分析值 = 21
            中2BSTD = 22
            夜1B分析值 = 23
            夜1BSTD = 24
            夜2B分析值 = 25
            夜2BSTD = 26
        End Enum
    End Class
#End Region


#Region "印表列印參數 屬性:PrintArgString"
    Private Shared CurrentAppPath As String = Nothing
    Private Property PrintArgString() As Dictionary(Of String, String)
        Get
            Dim ReturnValue As New Dictionary(Of String, String)
            If IsNothing(CurrentAppPath) Then
                CurrentAppPath = Server.MapPath(".")
            End If

            Dim FileText As IO.TextReader = New IO.StringReader(My.Computer.FileSystem.ReadAllText(CurrentAppPath & "\App_Data\EquipmentCheckPrintSetTextFile.txt"))

            Dim ReadString As String = Nothing
            Do
                ReadString = FileText.ReadLine
                If Not IsNothing(ReadString) AndAlso ReadString.Trim.Length > 0 Then
                    ReturnValue.Add(ReadString.Split("|")(0), ReadString.Split("|")(1))
                End If
            Loop While Not IsNothing(ReadString) AndAlso ReadString.Trim.Length > 0


            Return ReturnValue
        End Get
        Set(ByVal value As Dictionary(Of String, String))
            If IsNothing(CurrentAppPath) Then
                CurrentAppPath = Server.MapPath(".")
            End If
            Dim SaveString As String = Nothing
            For Each EachItem As String In value.Keys
                SaveString &= IIf(IsNothing(SaveString), Nothing, vbNewLine) & EachItem & "|" & value.Item(EachItem)
            Next
            Dim StringWriter As New IO.StreamWriter(CurrentAppPath & "\App_Data\EquipmentCheckPrintSetTextFile.txt", False)
            StringWriter.Write(SaveString)
            StringWriter.Flush() : StringWriter.Close()

        End Set
    End Property

#End Region
#Region "取得印表參數檔案至控制項 函式:GetPrintArgFileToControl"
    ''' <summary>
    ''' 取得印表參數檔案至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetPrintArgFileToControl()
        'Metalys1表頭參數設定|Metalys #1@SQ-F-09@分02
        'Metalys2表頭參數設定|Metalys #2@SQ-F-10@分03
        'NO表頭參數設定|TC-136,TC-436@SQ-F-1,SQ-F-2@分13,分25
        'CS表頭參數設定|CS-400@SQ-F-30@分12
        'XRF表頭參數設定|Rigaku 3550@SQ-F-25@分30
        'JY56E表頭參數設定|JY-56E@SQ-F-08@SQ-F-25@分01
        For Each EachItem As Control In TabPanel2.Controls(1).Controls
            If TypeOf EachItem Is TextBox AndAlso EachItem.ID.Substring(0, 3) = "tbr" Then
                Dim GetControla As TextBox = EachItem
                GetControla.Text = Nothing
                Dim ArgFileData As Dictionary(Of String, String) = PrintArgString
                Dim HashKey As String = Nothing
                Select Case True
                    Case EachItem.ID.Substring(3, 1) = "1"
                        HashKey = "Metalys1表頭參數設定"
                    Case EachItem.ID.Substring(3, 1) = "2"
                        HashKey = "Metalys2表頭參數設定"
                    Case EachItem.ID.Substring(3, 1) = "3"
                        HashKey = "NO表頭參數設定"
                    Case EachItem.ID.Substring(3, 1) = "4"
                        HashKey = "CS表頭參數設定"
                    Case EachItem.ID.Substring(3, 1) = "5"
                        HashKey = "XRF表頭參數設定"
                    Case EachItem.ID.Substring(3, 1) = "6"
                        HashKey = "JY56E表頭參數設定"
                End Select
                Dim ControlCount As Integer = 1
                If Not IsNothing(HashKey) Then
                    For Each EachValue As String In ArgFileData.Item(HashKey).Split("@")
                        Dim FindControl As TextBox = TabPanel2.Controls(1).FindControl("tbr" & EachItem.ID.Substring(3, 1) & "_" & ControlCount)
                        If Not IsNothing(FindControl) Then
                            FindControl.Text = EachValue
                            ControlCount += 1
                        End If
                    Next
                End If

            End If
        Next
    End Sub
#End Region
#Region "將控制項印表參數寫入檔案 函式:WritePrintArgToFile"
    Private Sub WritePrintArgToFile()
        Dim SaveDictionaryData As New Dictionary(Of String, String)
        For DataLines As Integer = 1 To 6
            Dim HashKey As String = Nothing
            Select Case DataLines
                Case 1
                    HashKey = "Metalys1表頭參數設定"
                Case 2
                    HashKey = "Metalys2表頭參數設定"
                Case 3
                    HashKey = "NO表頭參數設定"
                Case 4
                    HashKey = "CS表頭參數設定"
                Case 5
                    HashKey = "XRF表頭參數設定"
                Case 6
                    HashKey = "JY56E表頭參數設定"
            End Select
            Dim KeyValue As String = Nothing
            For ItemCount As Integer = 1 To 3
                Dim FindControl As TextBox = TabPanel2.Controls(1).FindControl("tbr" & DataLines & "_" & ItemCount)
                If Not IsNothing(FindControl) Then
                    KeyValue &= IIf(ItemCount = 1, "", "@") & FindControl.Text.Trim.Replace("@", Nothing).Replace("|", Nothing)
                    'If DataLines <= 4 Then
                    '    KeyValue &= IIf(ItemCount = 1, "", "@") & CType(FindControl.Text, Single)
                    'Else
                    '    KeyValue &= IIf(ItemCount = 1, "", "@") & FindControl.Text.Trim.Replace("@", Nothing).Replace("|", Nothing)
                    'End If
                End If
            Next
            SaveDictionaryData.Add(HashKey, KeyValue)
        Next
        If SaveDictionaryData.Count > 0 Then
            PrintArgString = SaveDictionaryData
        End If
    End Sub
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Format(Now, "yyyy/MM/dd")
            CurrentAppPath = Server.MapPath(".")
            Me.hfIsShowRealDataMode.Value = False
        End If
    End Sub

    Protected Sub tbReadSet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tbReadSet.Click
        GetPrintArgFileToControl()
        tbSaveSet.Enabled = True
    End Sub


    Protected Sub tbSaveSet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tbSaveSet.Click
        WritePrintArgToFile()
    End Sub

    Protected Sub tbSearchPrint_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tbSearchPrint.Click
        Me.hfIsShowRealDataMode.Value = (lbSearchMode.ForeColor = Drawing.Color.Red)
        ReportViewer1.DataBind()
        ReportViewer1.LocalReport.Refresh()
    End Sub

    Private Sub TabContainer1_ActiveTabChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabContainer1.ActiveTabChanged
        If TabContainer1.ActiveTab Is TabPanel2 AndAlso tbSaveSet.Enabled = False Then
            Call tbReadSet_Click(Nothing, Nothing)
        End If
    End Sub

    Protected Sub lbSearchMode_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbSearchMode.Click
        lbSearchMode.ForeColor = IIf(lbSearchMode.ForeColor = Drawing.Color.Red, Drawing.Color.Black, Drawing.Color.Red)
    End Sub
End Class