Namespace DEBYSYSLB
    ''' <summary>
    ''' 幣別匯率檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Class DEBKCRPF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("DEBYSYSLB", GetType(DEBKCRPF).Name)
        End Sub

#Region "幣別代碼 屬性:CURRNO"

        Private _CURRNO As String
        ''' <summary>
        ''' 幣別代碼
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
       Public Property CURRNO() As String
            Get
                Return _CURRNO
            End Get
            Set(ByVal value As String)
                _CURRNO = value
            End Set
        End Property

#End Region
#Region "幣別名稱 屬性:CURRAN"

        Private _CURRAN As String
        ''' <summary>
        ''' 幣別名稱
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CURRAN() As String
            Get
                Return _CURRAN
            End Get
            Set(ByVal value As String)
                _CURRAN = value
            End Set
        End Property

#End Region
#Region "匯率 屬性:CHGRTE"

        Private _CHGRTE As Single
        ''' <summary>
        ''' 匯率
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CHGRTE() As Single
            Get
                Return _CHGRTE
            End Get
            Set(ByVal value As Single)
                _CHGRTE = value
            End Set
        End Property

#End Region

    End Class
End Namespace
