''' <summary>
''' 新分光儀JY5
''' </summary>
''' <remarks></remarks>
Public Class JY5Converter
    Inherits JY4Converter

    Sub New(ByVal SetDeviceData As String)
        MyBase.New(DeviceTypeEnum.JY5, SetDeviceData)
    End Sub

    Sub New(ByVal SetDevice As DeviceTypeEnum, ByVal SetDeviceData As String)
        MyBase.New(SetDevice, SetDeviceData)
    End Sub

#Region "資料物件 屬性:ORMObjects"
    Overloads Property ORMObjects() As List(Of JYData)
        Get
            Dim RetyrnValue As List(Of JYData) = MyBase.ORMObjects
            For Each EachValue As JYData In RetyrnValue
                EachValue.DeviceName = "JY5"
            Next
            Return RetyrnValue
        End Get
        Set(ByVal value As List(Of JYData))
            MyBase.ORMObjects = value
        End Set
    End Property
#End Region


End Class
