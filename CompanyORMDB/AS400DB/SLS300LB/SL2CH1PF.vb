Namespace SLS300LB
    ''' <summary>
    ''' 各鋼種相關資訊
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SL2CH1PF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("SLS300LB", GetType(SL2CH1PF).Name)
        End Sub

#Region "鋼種 屬性:CH101"
        Private _CH101 As System.String
        ''' <summary>
        ''' 鋼種
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CH101() As System.String
            Get
                Return _CH101
            End Get
            Set(ByVal value As System.String)
                _CH101 = value
            End Set
        End Property
#End Region
#Region "TYPE 屬性:CH101A"
        Private _CH101A As System.String
        ''' <summary>
        ''' TYPE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CH101A() As System.String
            Get
                Return _CH101A
            End Get
            Set(ByVal value As System.String)
                _CH101A = value
            End Set
        End Property
#End Region
#Region "是否生產 屬性:CH102"
        Private _CH102 As System.String
        ''' <summary>
        ''' 是否生產
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CH102() As System.String
            Get
                Return _CH102
            End Get
            Set(ByVal value As System.String)
                _CH102 = value
            End Set
        End Property
#End Region
#Region "CODE- 1 屬性:CH103"
        Private _CH103 As System.String
        ''' <summary>
        ''' CODE- 1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CH103() As System.String
            Get
                Return _CH103
            End Get
            Set(ByVal value As System.String)
                _CH103 = value
            End Set
        End Property
#End Region
#Region "對照 屬性:CH104"
        Private _CH104 As System.String
        ''' <summary>
        ''' 對照
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CH104() As System.String
            Get
                Return _CH104
            End Get
            Set(ByVal value As System.String)
                _CH104 = value
            End Set
        End Property
#End Region
#Region "說明 屬性:CH105"
        Private _CH105 As System.String
        ''' <summary>
        ''' 說明
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CH105() As System.String
            Get
                Return _CH105
            End Get
            Set(ByVal value As System.String)
                _CH105 = value
            End Set
        End Property
#End Region
#Region "歐規 屬性:CH111"
        Private _CH111 As System.String
        ''' <summary>
        ''' 歐規
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CH111() As System.String
            Get
                Return _CH111
            End Get
            Set(ByVal value As System.String)
                _CH111 = value
            End Set
        End Property
#End Region
#Region "美規 屬性:CH112"
        Private _CH112 As System.String
        ''' <summary>
        ''' 美規
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CH112() As System.String
            Get
                Return _CH112
            End Get
            Set(ByVal value As System.String)
                _CH112 = value
            End Set
        End Property
#End Region
#Region "中規範CR 屬性:CH121C"
        Private _CH121C As System.String
        ''' <summary>
        ''' 中規範CR
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CH121C() As System.String
            Get
                Return _CH121C
            End Get
            Set(ByVal value As System.String)
                _CH121C = value
            End Set
        End Property
#End Region
#Region "中規範HR 屬性:CH121H"
        Private _CH121H As System.String
        ''' <summary>
        ''' 中規範HR
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CH121H() As System.String
            Get
                Return _CH121H
            End Get
            Set(ByVal value As System.String)
                _CH121H = value
            End Set
        End Property
#End Region
#Region "美規範 屬性:CH122"
        Private _CH122 As System.String
        ''' <summary>
        ''' 美規範
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CH122() As System.String
            Get
                Return _CH122
            End Get
            Set(ByVal value As System.String)
                _CH122 = value
            End Set
        End Property
#End Region
#Region "歐一般規範 屬性:CH123A"
        Private _CH123A As System.String
        ''' <summary>
        ''' 歐一般規範
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CH123A() As System.String
            Get
                Return _CH123A
            End Get
            Set(ByVal value As System.String)
                _CH123A = value
            End Set
        End Property
#End Region
#Region "歐壓容規範 屬性:CH123B"
        Private _CH123B As System.String
        ''' <summary>
        ''' 歐壓容規範
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CH123B() As System.String
            Get
                Return _CH123B
            End Get
            Set(ByVal value As System.String)
                _CH123B = value
            End Set
        End Property
#End Region
#Region "日規範CR 屬性:CH124C"
        Private _CH124C As System.String
        ''' <summary>
        ''' 日規範CR
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CH124C() As System.String
            Get
                Return _CH124C
            End Get
            Set(ByVal value As System.String)
                _CH124C = value
            End Set
        End Property
#End Region
#Region "日規範HR 屬性:CH124H"
        Private _CH124H As System.String
        ''' <summary>
        ''' 日規範HR
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CH124H() As System.String
            Get
                Return _CH124H
            End Get
            Set(ByVal value As System.String)
                _CH124H = value
            End Set
        End Property
#End Region
#Region "其他 屬性:CH125"
        Private _CH125 As System.String
        ''' <summary>
        ''' 其他
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CH125() As System.String
            Get
                Return _CH125
            End Get
            Set(ByVal value As System.String)
                _CH125 = value
            End Set
        End Property
#End Region

#Region "尋找SL2CH1PF 方法:FindSL2CH1PF"
        ''' <summary>
        ''' 尋找SL2CH1PF
        ''' </summary>
        ''' <param name="FindCH101"></param>
        ''' <param name="FindCH101A"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function FindSL2CH1PF(ByVal FindCH101 As String, ByVal FindCH101A As String) As SL2CH1PF
            Dim QryString As String = "Select * From @#SLS300LB.SL2CH1PF Where CH101='" & FindCH101.Trim & "' AND CH101A='" & FindCH101A & "' "
            Dim SearchResult As List(Of SL2CH1PF) = SL2CH1PF.CDBSelect(Of SL2CH1PF)(QryString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            If SearchResult.Count = 0 Then
                Return Nothing
            End If
            Return SearchResult(0)
        End Function

#End Region

    End Class
End Namespace