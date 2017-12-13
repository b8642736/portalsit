Namespace DEBY

    ''' <summary>
    ''' 幣別代碼檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Class DEBY07PF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("DYBE", GetType(DEBY07PF).Name)
        End Sub

#Region "幣別代碼 屬性:TYPENO"

        Private _TYPENO As String
        ''' <summary>
        ''' 幣別代碼
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TYPENO() As String
            Get
                Return _TYPENO
            End Get
            Set(ByVal value As String)
                _TYPENO = value
            End Set
        End Property

#End Region
#Region "幣別說明 屬性:TYPENM"

        Private _TYPENM As String
        ''' <summary>
        ''' 幣別說明
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TYPENM() As String
            Get
                Return _TYPENM
            End Get
            Set(ByVal value As String)
                _TYPENM = value
            End Set
        End Property

#End Region

    End Class
End Namespace
