Namespace PPS100LB
    ''' <summary>
    ''' 缺陷代碼說明
    ''' </summary>
    ''' <remarks></remarks>
    Public Class PPSDEFPF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("PPS100LB", GetType(PPSDEFPF).Name)
        End Sub

#Region "DEFECTIVE CODE 屬性:DEF01"
        Private _DEF01 As System.Int32
        ''' <summary>
        ''' DEFECTIVE CODE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property DEF01() As System.Int32
            Get
                Return _DEF01
            End Get
            Set(ByVal value As System.Int32)
                _DEF01 = value
            End Set
        End Property
#End Region
#Region "DEFECTIVE EXPLAIN 屬性:DEF02"
        Private _DEF02 As System.String
        ''' <summary>
        ''' DEFECTIVE EXPLAIN
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DEF02() As System.String
            Get
                Return _DEF02
            End Get
            Set(ByVal value As System.String)
                _DEF02 = value
            End Set
        End Property
#End Region
#Region "DEFECTIVE NOTE 屬性:DEF03"
        Private _DEF03 As System.String
        ''' <summary>
        ''' DEFECTIVE NOTE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DEF03() As System.String
            Get
                Return _DEF03
            End Get
            Set(ByVal value As System.String)
                _DEF03 = value
            End Set
        End Property
#End Region
#Region "CODE-1 屬性:DEF04"
        Private _DEF04 As System.String
        ''' <summary>
        ''' CODE-1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DEF04() As System.String
            Get
                Return _DEF04
            End Get
            Set(ByVal value As System.String)
                _DEF04 = value
            End Set
        End Property
#End Region

#Region "所有缺陷代碼說明 屬性:ALL_PPSDEPF"
        Private Shared _ALL_PPSDEPF As List(Of PPSDEFPF) = Nothing
        ''' <summary>
        ''' 所有缺陷代碼說明
        ''' </summary>
        ''' <param name="SetAS400SQLQueryAdapter"></param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property ALL_PPSDEPF(Optional ByVal SetAS400SQLQueryAdapter As AS400SQLQueryAdapter = Nothing) As List(Of PPSDEFPF)
            Get
                If IsNothing(_ALL_PPSDEPF) Then
                    If IsNothing(SetAS400SQLQueryAdapter) Then
                        SetAS400SQLQueryAdapter = (New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC))
                    End If
                    _ALL_PPSDEPF = CompanyORMDB.PPS100LB.PPSDEFPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSDEFPF)("Select * from " & (New CompanyORMDB.PPS100LB.PPSDEFPF).CDBFullAS400DBPath, SetAS400SQLQueryAdapter)
                End If
                Return _ALL_PPSDEPF
            End Get
        End Property
#End Region

    End Class
End Namespace