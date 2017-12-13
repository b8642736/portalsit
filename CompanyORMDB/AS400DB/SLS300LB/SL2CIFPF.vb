Namespace SLS300LB
    ''' <summary>
    ''' 用途說明檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SL2CIFPF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("SLS300LB", GetType(SL2CIFPF).Name)
        End Sub

#Region "用途 屬性:CIF01"
        Private _CIF01 As System.String
        ''' <summary>
        ''' 用途
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CIF01() As System.String
            Get
                Return _CIF01
            End Get
            Set(ByVal value As System.String)
                _CIF01 = value
            End Set
        End Property
#End Region
#Region "說明 屬性:CIF02"
        Private _CIF02 As System.String
        ''' <summary>
        ''' 說明
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIF02() As System.String
            Get
                Return _CIF02
            End Get
            Set(ByVal value As System.String)
                _CIF02 = value
            End Set
        End Property
#End Region
#Region "CODE- 1 屬性:CIF91"
        Private _CIF91 As System.String
        ''' <summary>
        ''' CODE- 1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIF91() As System.String
            Get
                Return _CIF91
            End Get
            Set(ByVal value As System.String)
                _CIF91 = value
            End Set
        End Property
#End Region
    End Class
End Namespace