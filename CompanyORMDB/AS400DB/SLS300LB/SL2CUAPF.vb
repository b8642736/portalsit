Namespace SLS300LB
    ''' <summary>
    ''' 客戶基本資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SL2CUAPF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("SLS300LB", GetType(SL2CUAPF).Name)
        End Sub

#Region "客戶編號 屬性:CUA01"
        Private _CUA01 As System.String
        ''' <summary>
        ''' 客戶編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CUA01() As System.String
            Get
                Return _CUA01
            End Get
            Set(ByVal value As System.String)
                _CUA01 = value
            End Set
        End Property
#End Region
#Region "名稱 屬性:CUA02"
        Private _CUA02 As System.String
        ''' <summary>
        ''' 名稱
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CUA02() As System.String
            Get
                Return _CUA02
            End Get
            Set(ByVal value As System.String)
                _CUA02 = value
            End Set
        End Property
#End Region
#Region "統一編號 屬性:CUA03"
        Private _CUA03 As System.String
        ''' <summary>
        ''' 統一編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CUA03() As System.String
            Get
                Return _CUA03
            End Get
            Set(ByVal value As System.String)
                _CUA03 = value
            End Set
        End Property
#End Region
#Region "郵遞區號－１ 屬性:CUA04"
        Private _CUA04 As System.String
        ''' <summary>
        ''' 郵遞區號－１
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CUA04() As System.String
            Get
                Return _CUA04
            End Get
            Set(ByVal value As System.String)
                _CUA04 = value
            End Set
        End Property
#End Region
#Region "住址－１ 屬性:CUA05"
        Private _CUA05 As System.String
        ''' <summary>
        ''' 住址－１
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CUA05() As System.String
            Get
                Return _CUA05
            End Get
            Set(ByVal value As System.String)
                _CUA05 = value
            End Set
        End Property
#End Region
#Region "電話－１ 屬性:CUA06"
        Private _CUA06 As System.String
        ''' <summary>
        ''' 電話－１
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CUA06() As System.String
            Get
                Return _CUA06
            End Get
            Set(ByVal value As System.String)
                _CUA06 = value
            End Set
        End Property
#End Region
#Region "郵遞區號－２ 屬性:CUA07"
        Private _CUA07 As System.String
        ''' <summary>
        ''' 郵遞區號－２
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CUA07() As System.String
            Get
                Return _CUA07
            End Get
            Set(ByVal value As System.String)
                _CUA07 = value
            End Set
        End Property
#End Region
#Region "住址－２ 屬性:CUA08"
        Private _CUA08 As System.String
        ''' <summary>
        ''' 住址－２
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CUA08() As System.String
            Get
                Return _CUA08
            End Get
            Set(ByVal value As System.String)
                _CUA08 = value
            End Set
        End Property
#End Region
#Region "電話－２ 屬性:CUA09"
        Private _CUA09 As System.String
        ''' <summary>
        ''' 電話－２
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CUA09() As System.String
            Get
                Return _CUA09
            End Get
            Set(ByVal value As System.String)
                _CUA09 = value
            End Set
        End Property
#End Region
#Region "是否印檢驗證明 屬性:CUA10"
        Private _CUA10 As System.String
        ''' <summary>
        ''' 是否印檢驗證明
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CUA10() As System.String
            Get
                Return _CUA10
            End Get
            Set(ByVal value As System.String)
                _CUA10 = value
            End Set
        End Property
#End Region
#Region "客戶名稱簡寫 屬性:CUA11"
        Private _CUA11 As System.String
        ''' <summary>
        ''' 客戶名稱簡寫
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CUA11() As System.String
            Get
                Return _CUA11
            End Get
            Set(ByVal value As System.String)
                _CUA11 = value
            End Set
        End Property
#End Region
#Region "CODE-1 屬性:CUA91"
        Private _CUA91 As System.String
        ''' <summary>
        ''' CODE-1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CUA91() As System.String
            Get
                Return _CUA91
            End Get
            Set(ByVal value As System.String)
                _CUA91 = value
            End Set
        End Property
#End Region
#Region "CODE-2 屬性:CUA92"
        Private _CUA92 As System.String
        ''' <summary>
        ''' CODE-2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CUA92() As System.String
            Get
                Return _CUA92
            End Get
            Set(ByVal value As System.String)
                _CUA92 = value
            End Set
        End Property
#End Region
#Region "CODE-3 屬性:CUA93"
        Private _CUA93 As System.String
        ''' <summary>
        ''' CODE-3
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CUA93() As System.String
            Get
                Return _CUA93
            End Get
            Set(ByVal value As System.String)
                _CUA93 = value
            End Set
        End Property
#End Region
#Region "CODE-4提貨用 屬性:CUA94"
        Private _CUA94 As System.String
        ''' <summary>
        ''' CODE-4提貨用
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CUA94() As System.String
            Get
                Return _CUA94
            End Get
            Set(ByVal value As System.String)
                _CUA94 = value
            End Set
        End Property
#End Region

#Region "所有客戶資料 Shared屬性:ALLSL2CUAPFs"

        Private Shared _ALLSL2CUAPFs As List(Of SL2CUAPF)
        ''' <summary>
        ''' 所有客戶資料
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Shared ReadOnly Property ALLSL2CUAPFs() As List(Of SL2CUAPF)
            Get
                If IsNothing(_ALLSL2CUAPFs) Then
                    _ALLSL2CUAPFs = SL2CUAPF.CDBSelect(Of SL2CUAPF)("Select * from @#SLS300LB.SL2CUAPF", AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                End If
                Return _ALLSL2CUAPFs
            End Get
        End Property

#End Region
#Region "依客戶編號取得客戶簡稱 方法:GetShortName"
        ''' <summary>
        ''' 依客戶編號取得客戶簡稱
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function GetShortName(ByVal GetCUA01 As String) As String
            For Each EachItem In ALLSL2CUAPFs
                If EachItem.CUA01 = GetCUA01 Then
                    Return EachItem.CUA11
                End If
            Next
            Return Nothing
        End Function
#End Region
    End Class
End Namespace