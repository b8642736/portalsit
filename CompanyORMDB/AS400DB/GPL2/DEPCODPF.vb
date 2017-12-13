Namespace GPL2
    ''' <summary>
    ''' 新單位代碼轉換表
    ''' </summary>
    ''' <remarks></remarks>
    Public Class DEPCODPF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("GPL2", GetType(DEPCODPF).Name)
        End Sub

#Region "部門別 屬性:DEPT"
        Private _DEPT As System.String
        ''' <summary>
        ''' 部門別
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property DEPT() As System.String
            Get
                Return _DEPT
            End Get
            Set(ByVal value As System.String)
                _DEPT = value
            End Set
        End Property
#End Region
#Region "單位代碼 屬性:DEPCOD"
        Private _DEPCOD As System.String
        ''' <summary>
        ''' 單位代碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property DEPCOD() As System.String
            Get
                Return _DEPCOD
            End Get
            Set(ByVal value As System.String)
                _DEPCOD = value
            End Set
        End Property
#End Region
#Region "單位名稱 屬性:DEPNAM"
        Private _DEPNAM As System.String
        ''' <summary>
        ''' 單位名稱
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DEPNAM() As System.String
            Get
                Return _DEPNAM
            End Get
            Set(ByVal value As System.String)
                _DEPNAM = value
            End Set
        End Property
#End Region
#Region "排序編號 屬性:SORTNU"
        Private _SORTNU As System.Int32
        ''' <summary>
        ''' 排序編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SORTNU() As System.Int32
            Get
                Return _SORTNU
            End Get
            Set(ByVal value As System.Int32)
                _SORTNU = value
            End Set
        End Property
#End Region
#Region "成本中心 屬性:COSTC"
        Private _COSTC As System.String
        ''' <summary>
        ''' 成本中心
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property COSTC() As System.String
            Get
                Return _COSTC
            End Get
            Set(ByVal value As System.String)
                _COSTC = value
            End Set
        End Property
#End Region
#Region "一般費用科目 屬性:ACCTN1"
        Private _ACCTN1 As System.String
        ''' <summary>
        ''' 一般費用科目
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ACCTN1() As System.String
            Get
                Return _ACCTN1
            End Get
            Set(ByVal value As System.String)
                _ACCTN1 = value
            End Set
        End Property
#End Region
#Region "用人費用科目 屬性:ACCTN2"
        Private _ACCTN2 As System.String
        ''' <summary>
        ''' 用人費用科目
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ACCTN2() As System.String
            Get
                Return _ACCTN2
            End Get
            Set(ByVal value As System.String)
                _ACCTN2 = value
            End Set
        End Property
#End Region
#Region "代碼1 屬性:CODE1"
        Private _CODE1 As System.String
        ''' <summary>
        ''' 代碼1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CODE1() As System.String
            Get
                Return _CODE1
            End Get
            Set(ByVal value As System.String)
                _CODE1 = value
            End Set
        End Property
#End Region
#Region "代碼2 屬性:CODE2"
        Private _CODE2 As System.String
        ''' <summary>
        ''' 代碼2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CODE2() As System.String
            Get
                Return _CODE2
            End Get
            Set(ByVal value As System.String)
                _CODE2 = value
            End Set
        End Property
#End Region
#Region "代碼3 屬性:CODE3"
        Private _CODE3 As System.String
        ''' <summary>
        ''' 代碼3
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CODE3() As System.String
            Get
                Return _CODE3
            End Get
            Set(ByVal value As System.String)
                _CODE3 = value
            End Set
        End Property
#End Region
#Region "代碼4 屬性:CODE4"
        Private _CODE4 As System.String
        ''' <summary>
        ''' 代碼4
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CODE4() As System.String
            Get
                Return _CODE4
            End Get
            Set(ByVal value As System.String)
                _CODE4 = value
            End Set
        End Property
#End Region
#Region "代碼5 屬性:CODE5"
        Private _CODE5 As System.String
        ''' <summary>
        ''' 代碼5
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CODE5() As System.String
            Get
                Return _CODE5
            End Get
            Set(ByVal value As System.String)
                _CODE5 = value
            End Set
        End Property
#End Region
#Region "備註 屬性:MEMO"
        Private _MEMO As System.String
        ''' <summary>
        ''' 備註
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

#Region "所有新單位代碼轉換 屬性:AllDEPCODPFs"
        Private Shared _AllDEPCODPFs As List(Of DEPCODPF) = Nothing
        ''' <summary>
        ''' 所有新單位代碼轉換
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Shared ReadOnly Property AllDEPCODPFs As List(Of DEPCODPF)
            Get
                Static LastGetDataTime As DateTime = Now
                If Now.Subtract(LastGetDataTime).Seconds > 3 Then
                    _AllDEPCODPFs = Nothing
                End If
                If IsNothing(_AllDEPCODPFs) Then
                    _AllDEPCODPFs = DEPCODPF.CDBSelect(Of DEPCODPF)("Select * From @#GPL2.DEPCODPF Order by DEPT,DEPCOD ", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                End If
                LastGetDataTime = Now
                Return _AllDEPCODPFs
            End Get
        End Property
#End Region

    End Class
End Namespace