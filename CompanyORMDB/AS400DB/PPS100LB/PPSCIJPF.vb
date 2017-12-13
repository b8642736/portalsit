Namespace PPS100LB
    ''' <summary>
    ''' 過磅資料登入者設檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Class PPSCIJPF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("PPS100LB", GetType(PPSCIJPF).Name)
        End Sub

#Region "使用者工號 屬性:CIJ01"
        Private _CIJ01 As System.String
        ''' <summary>
        ''' 使用者工號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CIJ01() As System.String
            Get
                Return _CIJ01
            End Get
            Set(ByVal value As System.String)
                _CIJ01 = value
            End Set
        End Property
#End Region
#Region "使用者密碼 屬性:CIJ02"
        Private _CIJ02 As System.String
        ''' <summary>
        ''' 使用者密碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIJ02() As System.String
            Get
                Return _CIJ02
            End Get
            Set(ByVal value As System.String)
                _CIJ02 = value
            End Set
        End Property
#End Region
#Region "使用者姓名 屬性:CIJ03"
        Private _CIJ03 As System.String
        ''' <summary>
        ''' 使用者姓名
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIJ03() As System.String
            Get
                Return _CIJ03
            End Get
            Set(ByVal value As System.String)
                _CIJ03 = value
            End Set
        End Property
#End Region
    End Class
End Namespace