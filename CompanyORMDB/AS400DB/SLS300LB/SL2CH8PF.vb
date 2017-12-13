Namespace SLS300LB
    ''' <summary>
    ''' 料別查核檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SL2CH8PF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("SLS300LB", GetType(SL2CH8PF).Name)
        End Sub

#Region "料別 屬性:CH801"
        Private _CH801 As System.String
        ''' <summary>
        ''' 料別
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CH801() As System.String
            Get
                Return _CH801
            End Get
            Set(ByVal value As System.String)
                _CH801 = value
            End Set
        End Property
#End Region
#Region "說明 屬性:CH802"
        Private _CH802 As System.String
        ''' <summary>
        ''' 說明
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CH802() As System.String
            Get
                Return _CH802
            End Get
            Set(ByVal value As System.String)
                _CH802 = value
            End Set
        End Property
#End Region
#Region "CODE- 1 屬性:CH891"
        Private _CH891 As System.String
        ''' <summary>
        ''' CODE- 1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CH891() As System.String
            Get
                Return _CH891
            End Get
            Set(ByVal value As System.String)
                _CH891 = value
            End Set
        End Property
#End Region

    End Class
End Namespace