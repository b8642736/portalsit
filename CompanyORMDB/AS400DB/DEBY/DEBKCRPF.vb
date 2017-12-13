Namespace DEBSYSLB
    Public Class DEBKCRPF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("DEBSYSLB", GetType(DEBKCRPF).Name)
        End Sub

#Region "幣別代號 屬性:CURRNO"
        Private _CURRNO As System.String
        ''' <summary>
        ''' 幣別代號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CURRNO() As System.String
            Get
                Return _CURRNO
            End Get
            Set(ByVal value As System.String)
                _CURRNO = value
            End Set
        End Property
#End Region
#Region "幣別 屬性:CURRAN"
        Private _CURRAN As System.String
        ''' <summary>
        ''' 幣別
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CURRAN() As System.String
            Get
                Return _CURRAN
            End Get
            Set(ByVal value As System.String)
                _CURRAN = value
            End Set
        End Property
#End Region
#Region "匯率 屬性:CHGRTE"
        Private _CHGRTE As System.Single
        ''' <summary>
        ''' 匯率
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CHGRTE() As System.Single
            Get
                Return _CHGRTE
            End Get
            Set(ByVal value As System.Single)
                _CHGRTE = value
            End Set
        End Property
#End Region
    End Class
End Namespace