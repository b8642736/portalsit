''' <summary>
''' 舊分光儀WIN98系統版JY3
''' </summary>
''' <remarks></remarks>
Public Class JY3Converter
    Inherits DeviceDataConverterBase

    Sub New(ByVal SetDeviceData As String)
        MyBase.New(DeviceTypeEnum.JY3, SetDeviceData)
    End Sub

#Region "代理型轉換物件 屬性:AgencyConveter"
    Private _AgencyConveter As JY4Converter
    ''' <summary>
    ''' 代理型轉換物件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property AgencyConveter() As JY4Converter
        Get
            If IsNothing(_AgencyConveter) Then
                _AgencyConveter = New JY4Converter(Me.DeviceData.ToUpper.Replace("PPM", Nothing))
            End If
            Return _AgencyConveter
        End Get
    End Property
#End Region


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
            Case ElementFieldEnum.Ga
                ReturnValue = FindFieldValue("GA", ValueIndex)
            Case ElementFieldEnum.W
                ReturnValue = FindFieldValue("W", ValueIndex)
            Case ElementFieldEnum.B
                ReturnValue = FindFieldValue("B", ValueIndex)
            Case ElementFieldEnum.Ca
                ReturnValue = FindFieldValue("CA", ValueIndex)
            Case ElementFieldEnum.Mg
                ReturnValue = FindFieldValue("MG", ValueIndex)
            Case ElementFieldEnum.Fe
                ReturnValue = FindFieldValue("FE", ValueIndex)
        End Select
        Return ReturnValue
    End Function

    Private Function FindFieldValue(ByVal FieldName As String, ByVal ValueIndex As Integer) As Nullable(Of Single)
        Return Me.AgencyConveter.FindFieldValue(FieldName, ValueIndex)
    End Function

    Private Function FindTitleFieldValue(ByVal FieldName As String) As String
        Return Me.AgencyConveter.FindTitleFieldValue(FieldName)
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
                _RecordTime = Me.AgencyConveter.FindTimeValue
            End If
            Return _RecordTime
        End Get
        Private Set(ByVal value As DateTime)
            _RecordTime = value
        End Set
    End Property

#End Region
#Region "資料物件 屬性:ORMObjects"
    Private _ORMObjects As List(Of JYData)
    ''' <summary>
    ''' 資料物件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ORMObjects() As List(Of JYData)
        Get
            If IsNothing(_ORMObjects) Then
                _ORMObjects = New List(Of JYData)
                For EachDataIndex As Integer = 1 To AgencyConveter.SampleDataCount
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
                        '.爐號 = Me.StoveNumber
                        '.站別 = Me.StationNumber
                        '.序號 = Me.SerailNumber


                        .爐號 = JY4Converter.ParseStoveNumber(Me.Sample)
                        .站別 = JY4Converter.ParseStationNumber(Me.Sample)
                        .序號 = JY4Converter.ParseSerialNumber(Me.Sample)
                        .鋼種 = JY4Converter.ParseSteelKindString(Me.Sample)
                        .Type = JY4Converter.ParseTypeString(Me.Sample)
                        .DeviceName = "JY3"
                    End With
                    _ORMObjects.Add(AddItem)
                Next
            End If
            Return _ORMObjects
        End Get
        Private Set(ByVal value As List(Of JYData))
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
        Ga = 28
        W = 17
        B = 19
        Ca = 20
        Mg = 21
        Fe = 27
    End Enum
#End Region

    Private Sub JY3Converter_DeviceDataChanged(ByVal OrginData As String, ByVal NewData As String) Handles Me.DeviceDataChanged
        ORMObjects = Nothing
    End Sub

End Class
