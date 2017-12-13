Namespace sls300lb
    ''' <summary>
    ''' 表面查核檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SL2CH2PF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("sls300lb", GetType(SL2CH2PF).Name)
        End Sub

#Region "表　面 屬性:CH201"
        Private _CH201 As System.String
        ''' <summary>
        ''' 表　面
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CH201() As System.String
            Get
                Return _CH201
            End Get
            Set(ByVal value As System.String)
                _CH201 = value
            End Set
        End Property
#End Region
#Region "非正常品 屬性:CH202"
        Private _CH202 As System.String
        ''' <summary>
        ''' 非正常品
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CH202() As System.String
            Get
                Return _CH202
            End Get
            Set(ByVal value As System.String)
                _CH202 = value
            End Set
        End Property
#End Region
#Region "序　號 屬性:CH203"
        Private _CH203 As System.Int32
        ''' <summary>
        ''' 序　號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CH203() As System.Int32
            Get
                Return _CH203
            End Get
            Set(ByVal value As System.Int32)
                _CH203 = value
            End Set
        End Property
#End Region
#Region "表面等級 屬性:CH204"
        Private _CH204 As System.String
        ''' <summary>
        ''' 表面等級
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CH204() As System.String
            Get
                Return _CH204
            End Get
            Set(ByVal value As System.String)
                _CH204 = value
            End Set
        End Property
#End Region
#Region "CR / HR 屬性:CH205"
        Private _CH205 As System.String
        ''' <summary>
        ''' CR / HR
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CH205() As System.String
            Get
                Return _CH205
            End Get
            Set(ByVal value As System.String)
                _CH205 = value
            End Set
        End Property
#End Region
#Region "CODE- 1 屬性:CH206"
        Private _CH206 As System.String
        ''' <summary>
        ''' CODE- 1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CH206() As System.String
            Get
                Return _CH206
            End Get
            Set(ByVal value As System.String)
                _CH206 = value
            End Set
        End Property
#End Region
#Region "中文說明 屬性:CH207"
        Private _CH207 As System.String
        ''' <summary>
        ''' 中文說明
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CH207() As System.String
            Get
                Return _CH207
            End Get
            Set(ByVal value As System.String)
                _CH207 = value
            End Set
        End Property
#End Region

    End Class
End Namespace