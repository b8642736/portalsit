''' <summary>
''' 新分光儀JY4
''' </summary>
''' <remarks></remarks>
Public Class JY4Converter
    Inherits DeviceDataConverterBase

    Sub New(ByVal SetDeviceData As String)
        MyBase.New(DeviceTypeEnum.JY4, SetDeviceData)
    End Sub

    Sub New(ByVal SetDevice As DeviceTypeEnum, ByVal SetDeviceData As String)
        MyBase.New(SetDevice, SetDeviceData)
    End Sub


#Region "Task值 屬性:Task"

    Private _Task As String
    ''' <summary>
    ''' Task值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Task() As String
        Get
            If IsNothing(_Task) Then
                _Task = GetFieldValue(TitleFieldEnum.Task)
            End If
            Return _Task
        End Get
        Private Set(ByVal value As String)
            _Task = value
        End Set
    End Property

#End Region
#Region "Method值 屬性:Method"

    Private _Method As String
    ''' <summary>
    ''' Method值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Method() As String
        Get
            If IsNothing(_Method) Then
                _Method = GetFieldValue(TitleFieldEnum.Method)
            End If
            Return _Method
        End Get
        Private Set(ByVal value As String)
            _Method = value
        End Set
    End Property

#End Region
#Region "Sample值 屬性:Sample"

    Private _Sample As String
    ''' <summary>
    ''' Sample值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Sample() As String
        Get
            If IsNothing(_Sample) Then
                _Sample = GetFieldValue(TitleFieldEnum.Sample)
            End If
            Return _Sample
        End Get
        Private Set(ByVal value As String)
            _Sample = value
        End Set
    End Property

#End Region
#Region "Comments值 屬性:Comments"

    Private _Comments As String
    ''' <summary>
    ''' Contents值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Comments() As String
        Get
            If IsNothing(_Comments) Then
                _Comments = GetFieldValue(TitleFieldEnum.Comments)
            End If
            Return _Comments
        End Get
        Private Set(ByVal value As String)
            _Comments = value
        End Set
    End Property

#End Region
#Region "Shift值 屬性:Shift"

    Private _Shift As String
    ''' <summary>
    ''' Shift值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Shift() As String
        Get
            If IsNothing(_Shift) Then
                _Shift = GetFieldValue(TitleFieldEnum.Shift)
            End If
            Return _Shift
        End Get
        Private Set(ByVal value As String)
            _Shift = value
        End Set
    End Property

#End Region
#Region "Furance值 屬性:Furance"

    Private _Furance As String
    ''' <summary>
    ''' Furance值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Furance() As String
        Get
            If IsNothing(_Furance) Then
                _Furance = GetFieldValue(TitleFieldEnum.Furnace)
            End If
            Return _Furance
        End Get
        Private Set(ByVal value As String)
            _Furance = value
        End Set
    End Property

#End Region
#Region "Melt值 屬性:Melt"

    Private _Melt As String
    ''' <summary>
    ''' Melt值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Melt() As String
        Get
            If IsNothing(_Melt) Then
                _Melt = GetFieldValue(TitleFieldEnum.Melt)
            End If
            Return _Melt
        End Get
        Private Set(ByVal value As String)
            _Melt = value
        End Set
    End Property

#End Region
#Region "取得欄位值 方法:GetFieldValue"
    ''' <summary>
    ''' 取得欄位值
    ''' </summary>
    ''' <param name="TitleField"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFieldValue(ByVal TitleField As TitleFieldEnum) As String
        Dim ReturnValue As String = Nothing
        Dim FindDataString As String = Nothing
        Select Case TitleField
            Case TitleFieldEnum.Task
                ReturnValue = FindTitleFieldValue("Task")
            Case TitleFieldEnum.Method
                ReturnValue = FindTitleFieldValue("Method")
            Case TitleFieldEnum.Sample
                ReturnValue = FindTitleFieldValue("Sample")
            Case TitleFieldEnum.Comments
                ReturnValue = FindTitleFieldValue("Comments")
            Case TitleFieldEnum.Shift
                ReturnValue = FindTitleFieldValue("Shift")
            Case TitleFieldEnum.Furnace
                ReturnValue = FindTitleFieldValue("Furnace")
            Case TitleFieldEnum.Melt
                ReturnValue = FindTitleFieldValue("Melt")
            Case TitleFieldEnum.Warning
                ReturnValue = FindTitleFieldValue("Warning")
            Case TitleFieldEnum.SpecialSamplesAccuracyCheckUpResult
                ReturnValue = FindTitleFieldValue("Special")
            Case TitleFieldEnum.RecalibrationCheckUpResult
                ReturnValue = FindTitleFieldValue("Recalibration")
            Case TitleFieldEnum.MiniCalibrationResult
                ReturnValue = FindTitleFieldValue("MiniCalibration")
        End Select
        Return ReturnValue
    End Function
    ''' <summary>
    ''' 取得欄位值
    ''' </summary>
    ''' <param name="FieldName"></param>
    ''' <param name="ValueIndex"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFieldValue(ByVal FieldName As ElementFieldEnum, ByVal ValueIndex As Integer) As Single
        Dim ReturnValue As Single = Nothing
        If ValueIndex > SampleDataCount Then
            Return Nothing
        End If
        Select Case FieldName
            Case ElementFieldEnum.C
                ReturnValue = FindFieldValue("C", ValueIndex)
            Case ElementFieldEnum.Si
                ReturnValue = FindFieldValue("SI", ValueIndex)
            Case ElementFieldEnum.Mn
                ReturnValue = FindFieldValue("MN", ValueIndex)
            Case ElementFieldEnum.P
                ReturnValue = FindFieldValue("P", ValueIndex)
            Case ElementFieldEnum.S
                ReturnValue = FindFieldValue("S", ValueIndex)
            Case ElementFieldEnum.Cr
                ReturnValue = FindFieldValue("CR", ValueIndex)
            Case ElementFieldEnum.Ni
                ReturnValue = FindFieldValue("NI", ValueIndex)
            Case ElementFieldEnum.Cu
                ReturnValue = FindFieldValue("CU", ValueIndex)
            Case ElementFieldEnum.Mo
                ReturnValue = FindFieldValue("MO", ValueIndex)
            Case ElementFieldEnum.Co
                ReturnValue = FindFieldValue("CO", ValueIndex)
            Case ElementFieldEnum.AL
                ReturnValue = FindFieldValue("AL", ValueIndex)
            Case ElementFieldEnum.Sn
                ReturnValue = FindFieldValue("SN", ValueIndex)
            Case ElementFieldEnum.Pb
                ReturnValue = FindFieldValue("PB", ValueIndex)
            Case ElementFieldEnum.Ti
                ReturnValue = FindFieldValue("TI", ValueIndex)
            Case ElementFieldEnum.Nb
                ReturnValue = FindFieldValue("NB", ValueIndex)
            Case ElementFieldEnum.V
                ReturnValue = FindFieldValue("V", ValueIndex)
            Case ElementFieldEnum.W
                ReturnValue = FindFieldValue("W", ValueIndex)
            Case ElementFieldEnum.N
                ReturnValue = FindFieldValue("N", ValueIndex)
            Case ElementFieldEnum.B
                ReturnValue = FindFieldValue("B", ValueIndex)
            Case ElementFieldEnum.Ca
                ReturnValue = FindFieldValue("CA", ValueIndex)
            Case ElementFieldEnum.Mg
                ReturnValue = FindFieldValue("MG", ValueIndex)
            Case ElementFieldEnum.As
                ReturnValue = FindFieldValue("AS", ValueIndex)
            Case ElementFieldEnum.Bi
                ReturnValue = FindFieldValue("BI", ValueIndex)
            Case ElementFieldEnum.Sb
                ReturnValue = FindFieldValue("SB", ValueIndex)
            Case ElementFieldEnum.Zn
                ReturnValue = FindFieldValue("ZN", ValueIndex)
            Case ElementFieldEnum.Zr
                ReturnValue = FindFieldValue("ZR", ValueIndex)
            Case ElementFieldEnum.Fe
                ReturnValue = FindFieldValue("FE", ValueIndex)
        End Select
        Return ReturnValue
    End Function

    Public Function FindTitleFieldValue(ByVal FieldName As String)
        Dim ReturnValue As String = Nothing
        Dim FindFieldName As String = FieldName.ToUpper
        For Each EachItem As String In Me.DeviceDataLines
            If EachItem.ToUpper.StartsWith(FindFieldName) Then
                ReturnValue = EachItem.ToUpper.Replace(FindFieldName, Nothing).Trim
            End If
        Next
        Return ReturnValue
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="FieldName"></param>
    ''' <param name="ValueIndex">起始值1</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function FindFieldValue(ByVal FieldName As String, ByVal ValueIndex As Integer) As Nullable(Of Single)
        If ValueIndex > SampleDataCount Then
            Return Nothing
        End If

        Dim FindFieldName As String = FieldName.ToUpper
        Dim IsInElementFields As Boolean = False
        For Each EachItem As String In Me.DeviceDataLines
            If IsInElementFields = False Then
                If EachItem.Contains("(+)") Then
                    IsInElementFields = True
                End If
                Continue For
            End If
            If EachItem.Trim.Split(" ")(0).ToUpper = FieldName.ToUpper Then
                Dim ValueDataArray() As String = EachItem.ToUpper.Replace(FieldName.ToUpper, "").Replace("<", "").Replace(">", "").Replace("%", "").Split(" ")
                Dim CurrentValueIndex As Integer = 0
                For Each EachData As String In ValueDataArray
                    If EachData.Trim.Length > 0 Then
                        CurrentValueIndex += 1
                        If CurrentValueIndex = ValueIndex Then
                            Return EachData
                        End If
                    End If
                Next
                Return Nothing
            End If
        Next
        Return Nothing
    End Function
#End Region
#Region "記錄時間 屬性:RecordTime"

    Private _RecordTime As DateTime = Nothing
    ''' <summary>
    ''' 記錄時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RecordTime() As DateTime
        Get
            If IsNothing(_RecordTime) Then
                _RecordTime = FindTimeValue()
            End If
            Return _RecordTime
        End Get
        Private Set(ByVal value As DateTime)
            _RecordTime = value
        End Set
    End Property

    Public Function FindTimeValue() As DateTime
        For RowIndex As Integer = DeviceDataLines.Count - 1 To 1 Step -1
            If DeviceDataLines(RowIndex).Trim.Length > 0 AndAlso DeviceDataLines(RowIndex).Contains("-") AndAlso DeviceDataLines(RowIndex).Contains(":") Then
                For Each EachTokenData As String In DeviceDataLines(RowIndex).Trim.Split(" ")
                    If EachTokenData.Contains(":") Then
                        Dim Hour As Integer = CType(EachTokenData.Split(":")(0), Integer)
                        Dim Minute As Integer = CType(EachTokenData.Split(":")(1), Integer)
                        Return Now.Date.AddHours(Hour).AddMinutes(Minute)
                    End If
                Next
            End If
        Next
        Return Nothing
    End Function

#End Region
#Region "樣本資料筆數 屬性:SampleDataCount"
    ''' <summary>
    ''' 樣本資料筆數
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SampleDataCount() As Integer
        Get
            Dim RecordCount As Integer = 0
            Do While Me.DeviceData.Contains(RecordCount + 1 & " (+)")
                RecordCount += 1
            Loop
            Return RecordCount
        End Get
    End Property
#End Region

#Region "資料物件 屬性:ORMObjects"
    Private _ORMObjects As List(Of JYData)
    Overridable Property ORMObjects() As List(Of JYData)
        Get
            If IsNothing(_ORMObjects) Then
                _ORMObjects = New List(Of JYData)
                For EachDataIndex As Integer = 1 To Me.SampleDataCount
                    Dim AddItem As New JYData
                    Dim FieldValue As Object = Nothing
                    For Each EachItem As String In (New JYData).CDBClassFieldNames
                        FieldValue = FindFieldValue(EachItem, EachDataIndex)
                        If Not IsNothing(FieldValue) Then
                            AddItem.CDBSetFieldValue(EachItem, FieldValue)
                        Else
                            FieldValue = FindTitleFieldValue(EachItem)
                            If Not IsNothing(FieldValue) Then
                                AddItem.CDBSetFieldValue(EachItem, FieldValue)
                            End If
                        End If
                    Next
                    With AddItem
                        .Task = Me.Task
                        .Method = Me.Method
                        .Sample = Me.Sample
                        .Comments = Me.Comments
                        .Shift = Me.Shift
                        .Furance = Me.Furance
                        .Melt = Me.Melt
                        .爐號 = ParseStoveNumber(Me.Sample)
                        .站別 = ParseStationNumber(Me.Sample)
                        .序號 = ParseSerialNumber(Me.Sample)
                        .鋼種 = ParseSteelKindString(Me.Comments)
                        .Type = ParseTypeString(Me.Comments)
                        .DeviceName = "JY4"
                    End With
                    _ORMObjects.Add(AddItem)
                Next
            End If
            Return _ORMObjects
        End Get
        Protected Set(ByVal value As List(Of JYData))
            _ORMObjects = value
        End Set
    End Property
#End Region


#Region "抬頭欄位列舉 列舉:TitleFieldEnum"
    ''' <summary>
    ''' 抬頭欄位列舉
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum TitleFieldEnum
        Task = 1
        Method = 2
        Sample = 3
        Comments = 4
        Shift = 5
        Furnace = 6
        Melt = 7
        Warning = 8
        SpecialSamplesAccuracyCheckUpResult = 9
        RecalibrationCheckUpResult = 10
        MiniCalibrationResult = 11
    End Enum
#End Region
#Region "元素欄位列舉  列舉:ElementFieldEnum"
    ''' <summary>
    ''' 元素欄位列舉
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum ElementFieldEnum
        C = 1
        Si = 2
        Mn = 3
        P = 4
        S = 5
        Cr = 6
        Ni = 7
        Cu = 8
        Mo = 9
        Co = 10
        AL = 11
        Sn = 12
        Pb = 13
        Ti = 14
        Nb = 15
        V = 16
        W = 17
        N = 18
        B = 19
        Ca = 20
        Mg = 21
        [As] = 22
        Bi = 23
        Sb = 24
        Zn = 25
        Zr = 26
        Fe = 27
    End Enum
#End Region

#Region "解析鋼種字串 方法:ParseSteelKindString"
    ''' <summary>
    ''' 解析鋼種字串
    ''' </summary>
    ''' <param name="SourceString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ParseSteelKindString(ByVal SourceString As String) As String
        Dim SourceValue As String = SourceString
        If IsNothing(SourceValue) OrElse SourceValue.Trim.Length = 0 Then
            Return Nothing
        End If
        SourceValue = SourceString.ToUpper
        Dim Values() As String = SourceValue.Replace("TE", Nothing).Replace("LN", "L").Split("-")
        SourceValue = Values(0).Trim
        Return SourceValue
    End Function
#End Region
#Region "解析材質字串 方法:ParseTypeString"
    ''' <summary>
    ''' 解析材質字串
    ''' </summary>
    ''' <param name="SourceString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ParseTypeString(ByVal SourceString As String) As String
        Dim SourceValue As String = SourceString
        If IsNothing(SourceValue) OrElse SourceValue.Trim.Length = 0 Then
            Return Nothing
        End If
        SourceValue = SourceString.ToUpper

        Dim Values() As String = SourceValue.Split("-")
        If Values.Length = 1 Then
            Select Case True
                Case Values(0).Contains("LN")
                    Return "N"
                Case Values(0).Contains("TE")
                    Return "TE"
                Case Else
                    Return Nothing
            End Select
        End If
        If Values.Length >= 2 Then
            Dim GetAnotherString As String = Nothing
            For EachValueIndex As Integer = 1 To Values.Length - 1
                GetAnotherString &= Values(EachValueIndex).Trim
            Next
            Select Case True
                Case Values(0).Contains("LN")
                    Return "N" & GetAnotherString
                Case Values(0).Contains("TE")
                    Return "TE" & GetAnotherString
                Case Else
                    Return GetAnotherString
            End Select
        End If
        Return Nothing
    End Function
#End Region
#Region "解析爐號字串 方法:ParseStoveNumber"
    Public Shared Function ParseStoveNumber(ByVal SourceString As String) As String
        Dim SourceValue As String = SourceString
        If IsNothing(SourceValue) OrElse SourceValue.Trim.Length = 0 Then
            Return Nothing
        End If
        SourceValue = SourceString.ToUpper
        Dim Values() As String = SourceValue.Split("-")
        Return Values(0).Trim
    End Function
#End Region
#Region "解析站別 方法:ParseStationNumber"
    Public Shared Function ParseStationNumber(ByVal SourceString As String) As String
        Dim SourceValue As String = SourceString
        If IsNothing(SourceValue) OrElse SourceValue.Trim.Length = 0 Then
            Return Nothing
        End If
        SourceValue = SourceString.ToUpper
        Dim Values() As String = SourceValue.Split("-")
        If Values.Length < 2 Then
            Return Nothing
        End If
        Return Values(1).Trim
    End Function
#End Region
#Region "解析序號 方法:ParseSerialNumber"
    Public Shared Function ParseSerialNumber(ByVal SourceString As String) As String
        Dim SourceValue As String = SourceString
        If IsNothing(SourceValue) OrElse SourceValue.Trim.Length = 0 Then
            Return Nothing
        End If
        SourceValue = SourceString.ToUpper
        Dim Values() As String = SourceValue.Split("-")
        If Values.Length < 3 Then
            Return Nothing
        End If
        Return Values(2).Trim
    End Function
#End Region

    Private Sub JY3Converter_DeviceDataChanged(ByVal OrginData As String, ByVal NewData As String) Handles Me.DeviceDataChanged
        ORMObjects = Nothing
    End Sub

End Class
