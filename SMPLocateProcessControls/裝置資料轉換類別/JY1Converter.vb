''' <summary>
''' 舊分光儀DOS系統版JY1
''' </summary>
''' <remarks></remarks>
Public Class JY1Converter
    Inherits DeviceDataConverterBase

    Sub New(ByVal SetDeviceData As String)
        MyBase.New(DeviceTypeEnum.JY1, SetDeviceData)
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
                _AgencyConveter = New JY4Converter(Me.DeviceData.Replace("Ga", vbNewLine & "1 (+)" & vbNewLine & "Ga"))
            End If
            Return _AgencyConveter
        End Get
    End Property
#End Region


#Region "爐號 屬性:StoveNumber"
    ''' <summary>
    ''' 爐號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property StoveNumber() As String
        Get
            Dim FindValue As String = GetFieldValue(TitleFieldEnum.Sample)
            If IsNothing(FindValue) OrElse FindValue.Length = 0 Then
                Return Nothing
            End If
            Dim Values() As String = FindValue.Split("-")
            If Values.Length < 1 Then
                Return Nothing
            End If
            Return Values(0)
        End Get
    End Property
#End Region
#Region "站別 屬性:StationNumber"
    ''' <summary>
    ''' 站別
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property StationNumber() As String
        Get
            Dim FindValue As String = GetFieldValue(TitleFieldEnum.Sample)
            If IsNothing(FindValue) OrElse FindValue.Length = 0 Then
                Return Nothing
            End If
            Dim Values() As String = FindValue.Split("-")
            If Values.Length < 2 Then
                Return Nothing
            End If
            Return Values(1)
        End Get
    End Property
#End Region
#Region "序號 屬性:SerailNumber"
    ''' <summary>
    ''' 序號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SerailNumber() As String
        Get
            Dim FindValue As String = GetFieldValue(TitleFieldEnum.Sample)
            If IsNothing(FindValue) OrElse FindValue.Length = 0 Then
                Return Nothing
            End If
            Dim Values() As String = FindValue.Split("-")
            If Values.Length < 3 Then
                Return Nothing
            End If
            Return Values(2)
        End Get
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
            Case TitleFieldEnum.Sample
                ReturnValue = FindTitleFieldValue("Sample")
            Case TitleFieldEnum.Comments
                ReturnValue = FindTitleFieldValue("Comments")
            Case TitleFieldEnum.EmloyeeNumber
                ReturnValue = FindTitleFieldValue("EmloyeeNumber")
        End Select
        Return ReturnValue
    End Function
    ''' <summary>
    ''' 取得欄位值
    ''' </summary>
    ''' <param name="FieldName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFieldValue(ByVal FieldName As ElementFieldEnum) As Single
        Dim ReturnValue As Single = Nothing
        Select Case FieldName
            Case ElementFieldEnum.C
                ReturnValue = FindFieldValue("C")
            Case ElementFieldEnum.Si
                ReturnValue = FindFieldValue("SI")
            Case ElementFieldEnum.Mn
                ReturnValue = FindFieldValue("MN")
            Case ElementFieldEnum.P
                ReturnValue = FindFieldValue("P")
            Case ElementFieldEnum.S
                ReturnValue = FindFieldValue("S")
            Case ElementFieldEnum.Cr
                ReturnValue = FindFieldValue("CR")
            Case ElementFieldEnum.Ni
                ReturnValue = FindFieldValue("NI")
            Case ElementFieldEnum.Cu
                ReturnValue = FindFieldValue("CU")
            Case ElementFieldEnum.Mo
                ReturnValue = FindFieldValue("MO")
            Case ElementFieldEnum.Co
                ReturnValue = FindFieldValue("CO")
            Case ElementFieldEnum.AL
                ReturnValue = FindFieldValue("AL")
            Case ElementFieldEnum.Sn
                ReturnValue = FindFieldValue("SN")
            Case ElementFieldEnum.Pb
                ReturnValue = FindFieldValue("PB")
            Case ElementFieldEnum.Ti
                ReturnValue = FindFieldValue("TI")
            Case ElementFieldEnum.Nb
                ReturnValue = FindFieldValue("NB")
            Case ElementFieldEnum.V
                ReturnValue = FindFieldValue("V")
            Case ElementFieldEnum.Ga
                ReturnValue = FindFieldValue("GA")
            Case ElementFieldEnum.W
                ReturnValue = FindFieldValue("W")
            Case ElementFieldEnum.B
                ReturnValue = FindFieldValue("B")
            Case ElementFieldEnum.Ca
                ReturnValue = FindFieldValue("CA")
            Case ElementFieldEnum.Fe
                ReturnValue = FindFieldValue("FE")
        End Select
        Return ReturnValue
    End Function

    Private Function FindFieldValue(ByVal FieldName As String) As Nullable(Of Single)
        Return Me.AgencyConveter.FindFieldValue(FieldName, 1)
    End Function

    Private Function FindTitleFieldValue(ByVal FieldName As String) As String
        Dim ValueIndex As Integer = 0
        Dim FindFieldName As String = FieldName.ToUpper
        For Each EachItem As String In Me.DeviceDataLines(0).Split(" ")
            If EachItem.Length > 0 Then
                Select Case True
                    Case ValueIndex = 3 And FindFieldName = "TASK"
                        Return EachItem
                    Case ValueIndex = 6 And FindFieldName = "SAMPLE"
                        Return EachItem
                    Case ValueIndex = 7 And FindFieldName = "EMPLOYEENUMBER"
                        Return EachItem
                    Case ValueIndex = 8 And FindFieldName = "COMMENTS"
                        Return EachItem
                End Select
                ValueIndex += 1
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
                _RecordTime = Now
            End If
            Return _RecordTime
        End Get
        Private Set(ByVal value As DateTime)
            _RecordTime = value
        End Set
    End Property

#End Region
#Region "資料物件 屬性:ORMObject"
    Private _ORMObject As JYData
    ''' <summary>
    ''' 資料物件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ORMObject() As JYData
        Get
            If IsNothing(_ORMObject) Then
                _ORMObject = New JYData
                Dim FieldValue As Object = Nothing
                For Each EachItem As String In _ORMObject.CDBClassFieldNames
                    FieldValue = FindFieldValue(EachItem)
                    If Not IsNothing(FieldValue) Then
                        _ORMObject.CDBSetFieldValue(EachItem, FieldValue)
                    Else
                        FieldValue = FindTitleFieldValue(EachItem)
                        If Not IsNothing(FieldValue) Then
                            _ORMObject.CDBSetFieldValue(EachItem, FieldValue)
                        End If
                    End If
                Next
            End If
            With _ORMObject
                '.爐號 = Me.StoveNumber
                '.站別 = Me.StationNumber
                '.序號 = Me.SerailNumber
                .爐號 = JY4Converter.ParseStoveNumber(GetFieldValue(TitleFieldEnum.Sample))
                .站別 = JY4Converter.ParseStationNumber(GetFieldValue(TitleFieldEnum.Sample))
                .序號 = JY4Converter.ParseSerialNumber(GetFieldValue(TitleFieldEnum.Sample))
                .鋼種 = JY4Converter.ParseSteelKindString(GetFieldValue(TitleFieldEnum.Comments))
                .Type = JY4Converter.ParseTypeString(GetFieldValue(TitleFieldEnum.Comments))
                .DeviceName = "JY1"
            End With
            Return _ORMObject
        End Get
        Private Set(ByVal value As JYData)
            _ORMObject = value
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
        Sample = 3
        Comments = 4
        EmloyeeNumber = 12
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
        Fe = 27
    End Enum
#End Region

    Private Sub JY1Converter_DeviceDataChanged(ByVal OrginData As String, ByVal NewData As String) Handles Me.DeviceDataChanged
        ORMObject = Nothing
    End Sub

End Class
