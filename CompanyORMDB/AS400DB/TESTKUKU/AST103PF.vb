Namespace TESTKUKU
    Public Class AST103PF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("TESTKUKU", GetType(AST103PF).Name)
        End Sub

#Region "財產編號 屬性:AS301"
        Private _AS301 As System.String
        ''' <summary>
        ''' 財產編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property AS301() As System.String
            Get
                Return _AS301
            End Get
            Set(ByVal value As System.String)
                _AS301 = value
            End Set
        End Property
#End Region
#Region "序號 屬性:AS302"
        Private _AS302 As System.String
        ''' <summary>
        ''' 序號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property AS302() As System.String
            Get
                Return _AS302
            End Get
            Set(ByVal value As System.String)
                _AS302 = value
            End Set
        End Property
#End Region
#Region "請購憑證 屬性:AS303"
        Private _AS303 As System.String
        ''' <summary>
        ''' 請購憑證
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property AS303() As System.String
            Get
                Return _AS303
            End Get
            Set(ByVal value As System.String)
                _AS303 = value
            End Set
        End Property
#End Region
#Region "入帳日 屬性:AS304"
        Private _AS304 As System.Int32
        ''' <summary>
        ''' 入帳日
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property AS304() As System.Int32
            Get
                Return _AS304
            End Get
            Set(ByVal value As System.Int32)
                _AS304 = value
            End Set
        End Property
#End Region
#Region "領料單 屬性:AS305"
        Private _AS305 As System.String
        ''' <summary>
        ''' 領料單
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AS305() As System.String
            Get
                Return _AS305
            End Get
            Set(ByVal value As System.String)
                _AS305 = value
            End Set
        End Property
#End Region
#Region "部門 屬性:AS306"
        Private _AS306 As System.String
        ''' <summary>
        ''' 部門
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AS306() As System.String
            Get
                Return _AS306
            End Get
            Set(ByVal value As System.String)
                _AS306 = value
            End Set
        End Property
#End Region
#Region "數量 屬性:AS307"
        Private _AS307 As System.Int32
        ''' <summary>
        ''' 數量
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AS307() As System.Int32
            Get
                Return _AS307
            End Get
            Set(ByVal value As System.Int32)
                _AS307 = value
            End Set
        End Property
#End Region
#Region "金額 屬性:AS308"
        Private _AS308 As System.Single
        ''' <summary>
        ''' 金額
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AS308() As System.Single
            Get
                Return _AS308
            End Get
            Set(ByVal value As System.Single)
                _AS308 = value
            End Set
        End Property
#End Region
#Region "年限 屬性:AS309"
        Private _AS309 As System.Int32
        ''' <summary>
        ''' 年限
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AS309() As System.Int32
            Get
                Return _AS309
            End Get
            Set(ByVal value As System.Int32)
                _AS309 = value
            End Set
        End Property
#End Region
#Region "名稱說明 屬性:AS310"
        Private _AS310 As System.String
        ''' <summary>
        ''' 名稱說明
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AS310() As System.String
            Get
                Return _AS310
            End Get
            Set(ByVal value As System.String)
                _AS310 = value
            End Set
        End Property
#End Region
#Region "保管人員工代號 屬性:AS311"
        Private _AS311 As System.String
        ''' <summary>
        ''' 保管人員工代號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AS311() As System.String
            Get
                Return _AS311
            End Get
            Set(ByVal value As System.String)
                _AS311 = value
            End Set
        End Property
#End Region
#Region "狀態碼 屬性:AS312"
        Private _AS312 As System.String
        ''' <summary>
        ''' 狀態碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AS312() As System.String
            Get
                Return _AS312
            End Get
            Set(ByVal value As System.String)
                _AS312 = value
            End Set
        End Property
#End Region
#Region "註1 屬性:AS391"
        Private _AS391 As System.String
        ''' <summary>
        ''' 註1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AS391() As System.String
            Get
                Return _AS391
            End Get
            Set(ByVal value As System.String)
                _AS391 = value
            End Set
        End Property
#End Region
#Region "註2 屬性:AS392"
        Private _AS392 As System.String
        ''' <summary>
        ''' 註2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AS392() As System.String
            Get
                Return _AS392
            End Get
            Set(ByVal value As System.String)
                _AS392 = value
            End Set
        End Property
#End Region
    End Class
End Namespace