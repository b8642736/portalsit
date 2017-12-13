Namespace SLS300LB
    ''' <summary>
    ''' 公稱厚度＜子範圍＞檔（派工用）
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SL2CH7PF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("SLS300LB", GetType(SL2CH7PF).Name)
        End Sub

#Region "CR/HR 屬性:CH701"
        Private _CH701 As System.String
        ''' <summary>
        ''' CR/HR
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CH701() As System.String
            Get
                Return _CH701
            End Get
            Set(ByVal value As System.String)
                _CH701 = value
            End Set
        End Property
#End Region
#Region "料別 屬性:CH70A"
        Private _CH70A As System.String
        ''' <summary>
        ''' 料別
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CH70A() As System.String
            Get
                Return _CH70A
            End Get
            Set(ByVal value As System.String)
                _CH70A = value
            End Set
        End Property
#End Region
#Region "厚度 屬性:CH702"
        Private _CH702 As System.String
        ''' <summary>
        ''' 厚度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CH702() As System.String
            Get
                Return _CH702
            End Get
            Set(ByVal value As System.String)
                _CH702 = value
            End Set
        End Property
#End Region
#Region "子範圍 屬性:CH703"
        Private _CH703 As System.String
        ''' <summary>
        ''' 子範圍
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CH703() As System.String
            Get
                Return _CH703
            End Get
            Set(ByVal value As System.String)
                _CH703 = value
            End Set
        End Property
#End Region
#Region "厚度下限 屬性:CH704"
        Private _CH704 As System.Single
        ''' <summary>
        ''' 厚度下限
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CH704() As System.Single
            Get
                Return _CH704
            End Get
            Set(ByVal value As System.Single)
                _CH704 = value
            End Set
        End Property
#End Region
#Region "厚度上限 屬性:CH705"
        Private _CH705 As System.Single
        ''' <summary>
        ''' 厚度上限
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CH705() As System.Single
            Get
                Return _CH705
            End Get
            Set(ByVal value As System.Single)
                _CH705 = value
            End Set
        End Property
#End Region
#Region "目標厚度 屬性:CH706"
        Private _CH706 As System.Single
        ''' <summary>
        ''' 目標厚度(非容許下限)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CH706() As System.Single
            Get
                Return _CH706
            End Get
            Set(ByVal value As System.Single)
                _CH706 = value
            End Set
        End Property
#End Region
#Region "CH707 屬性:CH707"
        Private _CH707 As System.Single
        ''' <summary>
        ''' (非容許上限)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CH707() As System.Single
            Get
                Return _CH707
            End Get
            Set(ByVal value As System.Single)
                _CH707 = value
            End Set
        End Property
#End Region
    End Class
End Namespace