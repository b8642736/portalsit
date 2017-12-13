Namespace PPS100LB
    ''' <summary>
    ''' 缺限追蹤分析檔案（鋼胚資訊)
    ''' </summary>
    ''' <remarks></remarks>
    Public Class PPSPU0PF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("PPS100LB", GetType(PPSPU0PF).Name)
        End Sub

#Region "批次 屬性:PU001"
        Private _PU001 As System.String
        ''' <summary>
        ''' 批次
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property PU001() As System.String
            Get
                Return _PU001
            End Get
            Set(ByVal value As System.String)
                _PU001 = value
            End Set
        End Property
#End Region
#Region "鋼捲 屬性:PU002"
        Private _PU002 As System.String
        ''' <summary>
        ''' 鋼捲
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property PU002() As System.String
            Get
                Return _PU002
            End Get
            Set(ByVal value As System.String)
                _PU002 = value
            End Set
        End Property
#End Region
#Region "鋼胚號碼 屬性:PU003"
        Private _PU003 As System.String
        ''' <summary>
        ''' 鋼胚號碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PU003() As System.String
            Get
                Return _PU003
            End Get
            Set(ByVal value As System.String)
                _PU003 = value
            End Set
        End Property
#End Region
#Region "鋼胚生產日 屬性:PU004"
        Private _PU004 As System.Int32
        ''' <summary>
        ''' 鋼胚生產日
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PU004() As System.Int32
            Get
                Return _PU004
            End Get
            Set(ByVal value As System.Int32)
                _PU004 = value
            End Set
        End Property
#End Region
#Region "熱軋號碼 屬性:PU005"
        Private _PU005 As System.String
        ''' <summary>
        ''' 熱軋號碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PU005() As System.String
            Get
                Return _PU005
            End Get
            Set(ByVal value As System.String)
                _PU005 = value
            End Set
        End Property
#End Region
#Region "黑皮厚度 屬性:PU006"
        Private _PU006 As System.Single
        ''' <summary>
        ''' 黑皮厚度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PU006() As System.Single
            Get
                Return _PU006
            End Get
            Set(ByVal value As System.Single)
                _PU006 = value
            End Set
        End Property
#End Region
#Region "CODE-1 屬性:PU091"
        Private _PU091 As System.String
        ''' <summary>
        ''' CODE-1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PU091() As System.String
            Get
                Return _PU091
            End Get
            Set(ByVal value As System.String)
                _PU091 = value
            End Set
        End Property
#End Region
#Region "CODE-2 屬性:PU092"
        Private _PU092 As System.String
        ''' <summary>
        ''' CODE-2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PU092() As System.String
            Get
                Return _PU092
            End Get
            Set(ByVal value As System.String)
                _PU092 = value
            End Set
        End Property
#End Region

    End Class
End Namespace