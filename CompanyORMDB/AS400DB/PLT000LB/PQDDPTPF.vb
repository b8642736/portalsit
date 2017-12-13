Namespace PLT000LB
    '<Serializable()> _
    Public Class PQDDPTPF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("PLT000LB", GetType(PQDDPTPF).Name)
        End Sub

#Region "單位 屬性:PQDP1"
        Private _PQDP1 As System.String
        ''' <summary>
        ''' 單位
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property PQDP1() As System.String
            Get
                Return _PQDP1
            End Get
            Set(ByVal value As System.String)
                _PQDP1 = value
            End Set
        End Property
#End Region
#Region "單位中文 屬性:PQDP2"
        Private _PQDP2 As System.String
        ''' <summary>
        ''' 單位中文
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PQDP2() As System.String
            Get
                Return _PQDP2
            End Get
            Set(ByVal value As System.String)
                _PQDP2 = value
            End Set
        End Property
#End Region
#Region "成本中心 屬性:PQDP3"
        Private _PQDP3 As System.String
        ''' <summary>
        ''' 成本中心
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PQDP3() As System.String
            Get
                Return _PQDP3
            End Get
            Set(ByVal value As System.String)
                _PQDP3 = value
            End Set
        End Property
#End Region
#Region "職員科目 屬性:PQDP4"
        Private _PQDP4 As System.String
        ''' <summary>
        ''' 職員科目
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PQDP4() As System.String
            Get
                Return _PQDP4
            End Get
            Set(ByVal value As System.String)
                _PQDP4 = value
            End Set
        End Property
#End Region
#Region "工員科目 屬性:PQDP5"
        Private _PQDP5 As System.String
        ''' <summary>
        ''' 工員科目
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PQDP5() As System.String
            Get
                Return _PQDP5
            End Get
            Set(ByVal value As System.String)
                _PQDP5 = value
            End Set
        End Property
#End Region
    End Class
End Namespace