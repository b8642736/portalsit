Public Class XRayConverter
    Inherits DeviceDataConverterBase

    Sub New(ByVal SetDeviceData As String)
        MyBase.New(DeviceTypeEnum.Xray, SetDeviceData)
    End Sub

#Region "爐號 屬性:StoveNumber"
    ''' <summary>
    ''' 爐號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property StoveNumber() As String
        Get
            If IsNothing(Me.Sample) Then
                Return Nothing
            End If
            Return Me.Sample.Split("-")(0)
        End Get
    End Property
#End Region
#Region "MATHOD值 屬性:MATHOD"

    Private _MATHOD As String
    ''' <summary>
    ''' MATHOD值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MATHOD() As String
        Get
            If IsNothing(_MATHOD) Then
                _MATHOD = Me.DeviceDataLines(0).Split(" ")(1).Trim
            End If
            Return _MATHOD
        End Get
        Private Set(ByVal value As String)
            _MATHOD = value
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
                _Sample = Me.DeviceDataLines(0).Split(" ")(3)
            End If
            Return _Sample
        End Get
        Private Set(ByVal value As String)
            _Sample = value
        End Set
    End Property

#End Region
#Region "SAMPLENAME值 屬性:SAMPLENAME"

    Private _SAMPLENAME As String
    ''' <summary>
    ''' MATHOD值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SAMPLENAME() As String
        Get
            If IsNothing(_SAMPLENAME) Then
                _SAMPLENAME = Me.DeviceDataLines(0).Split(" ")(2)
            End If
            Return _SAMPLENAME
        End Get
        Private Set(ByVal value As String)
            _SAMPLENAME = value
        End Set
    End Property

#End Region
#Region "裝置資料行 屬性:DeviceDataLines"
    ''' <summary>
    ''' 裝置資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads ReadOnly Property DeviceDataLines() As List(Of String)
        Get
            Dim ReturnValue As New List(Of String)
            For Each EachItem As String In MyBase.DeviceDataLines
                ReturnValue.Add(EachItem.Substring(1))
            Next
            Return ReturnValue
        End Get
    End Property

#End Region
#Region "取得欄位值 方法:GetFieldValue"
    ''' <summary>
    ''' 取得欄位值
    ''' </summary>
    ''' <param name="ElementField"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFieldValue(ByVal ElementField As ElementFieldEnum) As String
        Dim ReturnValue As Single = Nothing
        Select Case ElementField
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
            Case ElementFieldEnum.W
                ReturnValue = FindFieldValue("W")
            Case ElementFieldEnum.Ca
                ReturnValue = FindFieldValue("CA")
            Case ElementFieldEnum.As
                ReturnValue = FindFieldValue("AS")
            Case ElementFieldEnum.Zn
                ReturnValue = FindFieldValue("ZN")
            Case ElementFieldEnum.Hg
                ReturnValue = FindFieldValue("HG")
            Case ElementFieldEnum.Cd
                ReturnValue = FindFieldValue("CD")
        End Select
        Return ReturnValue
    End Function

    Private Function FindFieldValue(ByVal FieldName As String) As Nullable(Of Single)
        Dim FindFieldName As String = FieldName.ToUpper

        For Each EachItem As String In Me.DeviceDataLines
            Dim ValueDataArray() As String = EachItem.Split(" ")
            Dim NextEachItemIsValue As Boolean = False
            For Each EachData As String In ValueDataArray
                If NextEachItemIsValue AndAlso EachData.Trim.Length > 0 Then
                    Return CType(EachData.Trim, Single)
                End If
                If NextEachItemIsValue = False AndAlso EachData.Trim.ToUpper = FindFieldName Then
                    NextEachItemIsValue = True
                End If
            Next
        Next
        Return Nothing
    End Function

#End Region

#Region "資料物件 屬性:ORMObjects"
    Private _ORMObjects As List(Of JYData)
    Overridable Property ORMObjects() As List(Of JYData)
        Get
            If IsNothing(_ORMObjects) Then
                _ORMObjects = New List(Of JYData)

                Dim AddItem As New JYData
                Dim FieldValue As Object = Nothing
                For Each EachItem As String In (New JYData).CDBClassFieldNames
                    FieldValue = FindFieldValue(EachItem)
                    If Not IsNothing(FieldValue) Then
                        AddItem.CDBSetFieldValue(EachItem, FieldValue)
                    End If

                Next
                With AddItem
                    '.Task = Me.Task
                    '.Method = Me.Method
                    .Sample = Me.Sample
                    '.Comments = Me.Comments
                    '.Shift = Me.Shift
                    '.Furance = Me.Furance
                    '.Melt = Me.Melt
                    .爐號 = JY4Converter.ParseStoveNumber(Me.Sample)
                    .站別 = JY4Converter.ParseStationNumber(Me.Sample)
                    .序號 = JY4Converter.ParseSerialNumber(Me.Sample)
                    '.鋼種 = JY4Converter.ParseSteelKindString(Me.Comments)
                    '.Type = JY4Converter.ParseTypeString(Me.Comments)
                    .DeviceName = "XRay"
                End With
                _ORMObjects.Add(AddItem)
            End If
            Return _ORMObjects
        End Get
        Protected Set(ByVal value As List(Of JYData))
            _ORMObjects = value
        End Set
    End Property
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
        Ca = 20
        [As] = 22
        Zn = 25
        Hg = 28
        Cd = 29
    End Enum
#End Region

End Class
