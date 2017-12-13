Public Class CarbonSulfurConverter
    Inherits DeviceDataConverterBase

    Sub New(ByVal SetDeviceData As String)
        MyBase.New(DeviceTypeEnum.CarbonSulfur, SetDeviceData)
    End Sub

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
                _Method = FindMethodValue()
            End If
            Return _Method
        End Get
        Private Set(ByVal value As String)
            _Method = value
        End Set
    End Property
    Private Function FindMethodValue() As String
        Dim Datas() As String = DeviceDataLines(0).ToUpper.Split(":")
        If Datas.Length > 2 Then
            Return Datas(2).Trim
        End If
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

    Private Function FindTimeValue() As DateTime
        For Each EachItem As String In DeviceDataLines(0).Split(" ")
            If EachItem.Contains(":") Then
                Dim Hour As Integer = CType(EachItem.Split(":")(0), Integer)
                Dim Minute As Integer = CType(EachItem.Split(":")(1), Integer)
                Return Now.Date.AddHours(Hour).AddMinutes(Minute)
            End If
        Next
        Return Nothing
    End Function

#End Region
#Region "ID值 屬性:IDValue"


    Private _IDValue As String
    ''' <summary>
    ''' ID值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IDValue() As String
        Get
            If IsNothing(_IDValue) Then
                _IDValue = FindIDValue()
            End If
            Return _IDValue
        End Get
        Private Set(ByVal value As String)
            _IDValue = value
        End Set
    End Property
    Private Function FindIDValue() As String
        Dim NextEachItemIsValue As Boolean = False
        For Each EachItem As String In DeviceDataLines(1).Split(" ")
            If NextEachItemIsValue Then
                Return EachItem.Trim
            End If
            If EachItem.ToUpper.Contains("ID:") Then
                NextEachItemIsValue = True
            End If
        Next
        Return Nothing
    End Function
#End Region
#Region "重量值 屬性:WT"

    Private _WT As Nullable(Of Single)
    ''' <summary>
    ''' 重量值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WT() As Nullable(Of Single)
        Get
            If IsNothing(_WT) Then
                _WT = FindWTValue()
            End If
            Return _WT
        End Get
        Private Set(ByVal value As Nullable(Of Single))
            _WT = value
        End Set
    End Property

    Private Function FindWTValue() As Nullable(Of Single)
        If DeviceDataLines(1).Contains("=") Then
            Return CType(DeviceDataLines(1).Split("=")(1).ToUpper.Replace("G", Nothing).Trim, Single)
        End If
        Return Nothing
    End Function

#End Region
#Region "Carbon值 屬性:Carbon"

    Private _Carbon As Nullable(Of Single)
    Public Property Carbon() As Nullable(Of Single)
        Get
            If IsNothing(_Carbon) Then
                _Carbon = FindCarbonValue()
            End If
            Return _Carbon
        End Get
        Private Set(ByVal value As Nullable(Of Single))
            _Carbon = value
        End Set
    End Property

    Private Function FindCarbonValue() As Nullable(Of Single)
        Dim NextEachItemIsValue As Boolean = False
        For Each EachItem As String In Me.DeviceDataLines(2).Split(" ")
            If NextEachItemIsValue Then
                Return CType(EachItem.Replace("%", Nothing).Trim, Single)
            End If
            If EachItem.ToUpper.Contains("CARBON") Then
                NextEachItemIsValue = True
            End If
        Next
    End Function

#End Region
#Region "Sulfur值 屬性:Sulfur"

    Private _Sulfur As Nullable(Of Single)
    ''' <summary>
    ''' Sulfur值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Sulfur() As Nullable(Of Single)
        Get
            If IsNothing(_Sulfur) Then
                _Sulfur = FindSulfurValue()
            End If
            Return _Sulfur
        End Get
        Private Set(ByVal value As Nullable(Of Single))
            _Sulfur = value
        End Set
    End Property
    Private Function FindSulfurValue() As Nullable(Of Single)
        Dim NextEachItemIsValue As Boolean = False
        For Each EachItem As String In Me.DeviceDataLines(2).Split(" ")
            If NextEachItemIsValue Then
                Return CType(EachItem.Replace("%", Nothing).Trim, Single)
            End If
            If EachItem.ToUpper.Contains("SULFUR") Then
                NextEachItemIsValue = True
            End If
        Next
    End Function
#End Region
#Region "資料物件 屬性:ORMObject"

    Private _ORMObject As CarbonSulfurData
    ''' <summary>
    ''' 資料物件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ORMObject() As CarbonSulfurData
        Get
            If IsNothing(_ORMObject) Then
                _ORMObject = New CarbonSulfurData
                With _ORMObject
                    .ID = Me.IDValue
                    .WT = Me.WT
                    .Carbon = Me.Carbon
                    .Sulfur = Me.Sulfur
                    .Method = Me.Method
                End With
            End If
            Return _ORMObject
        End Get
        Protected Set(ByVal value As CarbonSulfurData)
            _ORMObject = value
        End Set
    End Property

#End Region

End Class
