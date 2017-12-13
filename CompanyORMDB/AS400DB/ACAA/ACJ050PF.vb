Namespace ACAA
    ''' <summary>
    ''' 費用類預算檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ACJ050PF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("ACAA", GetType(ACJ050PF).Name)
        End Sub

#Region "預算會計年 屬性:ACCTYR"
        Private _ACCTYR As System.String
        ''' <summary>
        ''' 預算會計年
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property ACCTYR() As System.String
            Get
                Return _ACCTYR
            End Get
            Set(ByVal value As System.String)
                _ACCTYR = value
            End Set
        End Property
#End Region
#Region "單位代號 屬性:DEPTNO"
        Private _DEPTNO As System.String
        ''' <summary>
        ''' 單位代號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property DEPTNO() As System.String
            Get
                Return _DEPTNO
            End Get
            Set(ByVal value As System.String)
                _DEPTNO = value
            End Set
        End Property
#End Region
#Region "會計科目 屬性:ACCTNO"
        Private _ACCTNO As System.String
        ''' <summary>
        ''' 會計科目
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property ACCTNO() As System.String
            Get
                Return _ACCTNO
            End Get
            Set(ByVal value As System.String)
                _ACCTNO = value
            End Set
        End Property
#End Region
#Region "明細科目 屬性:DETLNO"
        Private _DETLNO As System.String
        ''' <summary>
        ''' 明細科目
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property DETLNO() As System.String
            Get
                Return _DETLNO
            End Get
            Set(ByVal value As System.String)
                _DETLNO = value
            End Set
        End Property
#End Region
#Region "輸入 屬性:INPUT"
        Private _INPUT As System.String
        ''' <summary>
        ''' 輸入
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property INPUT() As System.String
            Get
                Return _INPUT
            End Get
            Set(ByVal value As System.String)
                _INPUT = value
            End Set
        End Property
#End Region
#Region "全年預算金額 屬性:BDGTTT"
        Private _BDGTTT As System.Single
        ''' <summary>
        ''' 全年預算金額
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BDGTTT() As System.Single
            Get
                Return _BDGTTT
            End Get
            Set(ByVal value As System.Single)
                _BDGTTT = value
            End Set
        End Property
#End Region
#Region "變動費用 屬性:BDGVAR"
        Private _BDGVAR As Double
        ''' <summary>
        ''' 變動費用
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BDGVAR() As Double
            Get
                Return _BDGVAR
            End Get
            Set(ByVal value As Double)
                _BDGVAR = value
            End Set
        End Property
#End Region
#Region "固定費用 屬性:BDGFIX"
        Private _BDGFIX As Double
        ''' <summary>
        ''' 固定費用
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BDGFIX() As Double
            Get
                Return _BDGFIX
            End Get
            Set(ByVal value As Double)
                _BDGFIX = value
            End Set
        End Property
#End Region
#Region "說明 屬性:MEMO"
        Private _MEMO As System.String
        ''' <summary>
        ''' 說明
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MEMO() As System.String
            Get
                Return _MEMO
            End Get
            Set(ByVal value As System.String)
                _MEMO = value
            End Set
        End Property
#End Region


#Region "所有會計科目代號檔 屬性:AllACJ050PFs"
        Private Shared _AllACJ050PFs As List(Of ACJ050PF) = Nothing
        ''' <summary>
        ''' 所有會計科目代號檔
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Shared ReadOnly Property AllACJ050PFs(ByVal GetTaiwanYear As Integer) As List(Of ACJ050PF)
            Get
                Static LastGetDataTime As DateTime = Now
                Static _GetTaiwanYear As Integer = -1
                If Now.Subtract(LastGetDataTime).Seconds > 3 OrElse _GetTaiwanYear <> GetTaiwanYear Then
                    _AllACJ050PFs = Nothing
                End If
                If IsNothing(_AllACJ050PFs) Then
                    _AllACJ050PFs = ACJ050PF.CDBSelect(Of ACJ050PF)("Select * From @#ACAA.ACJ050PF.SA Where ACCTYR='" & Format(GetTaiwanYear, "000") & "' Order by ACCTNO,DETLNO ", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                End If
                _GetTaiwanYear = GetTaiwanYear
                LastGetDataTime = Now
                Return _AllACJ050PFs
            End Get
        End Property
#End Region

    End Class
End Namespace