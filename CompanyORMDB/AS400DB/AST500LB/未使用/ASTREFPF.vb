Namespace AST500LB
Public Class ASTREFPF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("AST500LB", GetType(ASTREFPF).Name)
	End Sub

#Region "FIXED 屬性:NUMBER"
	Private _NUMBER As System.String
	''' <summary>
	''' FIXED
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property NUMBER () As System.String
		Get
			Return _NUMBER
		End Get
		Set(Byval value as System.String)
			_NUMBER = value
		End Set
	End Property
#End Region
#Region "FIXED 屬性:NAME"
	Private _NAME As System.String
	''' <summary>
	''' FIXED
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property NAME () As System.String
		Get
			Return _NAME
		End Get
		Set(Byval value as System.String)
			_NAME = value
		End Set
	End Property
#End Region
#Region "UNIT 屬性:UNIT"
	Private _UNIT As System.String
	''' <summary>
	''' UNIT
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property UNIT () As System.String
		Get
			Return _UNIT
		End Get
		Set(Byval value as System.String)
			_UNIT = value
		End Set
	End Property
#End Region
#Region "QUANTITY 屬性:QUANT"
	Private _QUANT As System.Int32
	''' <summary>
	''' QUANTITY
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QUANT () As System.Int32
		Get
			Return _QUANT
		End Get
		Set(Byval value as System.Int32)
			_QUANT = value
		End Set
	End Property
#End Region
#Region "AMOUNT 屬性:AMOUNT"
	Private _AMOUNT As System.Single
	''' <summary>
	''' AMOUNT
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property AMOUNT () As System.Single
		Get
			Return _AMOUNT
		End Get
		Set(Byval value as System.Single)
			_AMOUNT = value
		End Set
	End Property
#End Region
#Region "購置年月 屬性:DATE"
	Private _DATE As System.Int32
	''' <summary>
	''' 購置年月
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
        Public Property [DATE]() As System.Int32
            Get
                Return _DATE
            End Get
            Set(ByVal value As System.Int32)
                _DATE = value
            End Set
        End Property
#End Region
#Region "USE 屬性:USLAFF"
	Private _USLAFF As System.Int32
	''' <summary>
	''' USE
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property USLAFF () As System.Int32
		Get
			Return _USLAFF
		End Get
		Set(Byval value as System.Int32)
			_USLAFF = value
		End Set
	End Property
#End Region
#Region "DEPARTMENT 屬性:DEPT"
	Private _DEPT As System.String
	''' <summary>
	''' DEPARTMENT
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property DEPT () As System.String
		Get
			Return _DEPT
		End Get
		Set(Byval value as System.String)
			_DEPT = value
		End Set
	End Property
#End Region
#Region "DISCOUNT 屬性:DEPR"
	Private _DEPR As System.Single
	''' <summary>
	''' DISCOUNT
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property DEPR () As System.Single
		Get
			Return _DEPR
		End Get
		Set(Byval value as System.Single)
			_DEPR = value
		End Set
	End Property
#End Region
#Region "REESTIMATE 屬性:AMT"
	Private _AMT As System.Single
	''' <summary>
	''' REESTIMATE
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property AMT () As System.Single
		Get
			Return _AMT
		End Get
		Set(Byval value as System.Single)
			_AMT = value
		End Set
	End Property
#End Region
#Region "UNIT 屬性:PRICE"
	Private _PRICE As System.Single
	''' <summary>
	''' UNIT
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property PRICE () As System.Single
		Get
			Return _PRICE
		End Get
		Set(Byval value as System.Single)
			_PRICE = value
		End Set
	End Property
#End Region
#Region "TOTAL 屬性:TAMOUN"
	Private _TAMOUN As System.Single
	''' <summary>
	''' TOTAL
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property TAMOUN () As System.Single
		Get
			Return _TAMOUN
		End Get
		Set(Byval value as System.Single)
			_TAMOUN = value
		End Set
	End Property
#End Region
#Region "TOTAL 屬性:DEPREC"
	Private _DEPREC As System.Single
	''' <summary>
	''' TOTAL
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property DEPREC () As System.Single
		Get
			Return _DEPREC
		End Get
		Set(Byval value as System.Single)
			_DEPREC = value
		End Set
	End Property
#End Region
#Region "TRANSFER 屬性:DATEB"
	Private _DATEB As System.Int32
	''' <summary>
	''' TRANSFER
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property DATEB () As System.Int32
		Get
			Return _DATEB
		End Get
		Set(Byval value as System.Int32)
			_DATEB = value
		End Set
	End Property
#End Region
#Region "TRANSFER 屬性:DEMTB"
	Private _DEMTB As System.String
	''' <summary>
	''' TRANSFER
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property DEMTB () As System.String
		Get
			Return _DEMTB
		End Get
		Set(Byval value as System.String)
			_DEMTB = value
		End Set
	End Property
#End Region
#Region "TRANSFER 屬性:DEPTB"
	Private _DEPTB As System.String
	''' <summary>
	''' TRANSFER
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property DEPTB () As System.String
		Get
			Return _DEPTB
		End Get
		Set(Byval value as System.String)
			_DEPTB = value
		End Set
	End Property
#End Region
#Region "HAPPEN 屬性:DATEC"
	Private _DATEC As System.Int32
	''' <summary>
	''' HAPPEN
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property DATEC () As System.Int32
		Get
			Return _DATEC
		End Get
		Set(Byval value as System.Int32)
			_DATEC = value
		End Set
	End Property
#End Region
#Region "REMAIN 屬性:DEPREB"
	Private _DEPREB As System.Single
	''' <summary>
	''' REMAIN
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property DEPREB () As System.Single
		Get
			Return _DEPREB
		End Get
		Set(Byval value as System.Single)
			_DEPREB = value
		End Set
	End Property
#End Region
#Region "NEW 屬性:NUMBEN"
	Private _NUMBEN As System.String
	''' <summary>
	''' NEW
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property NUMBEN () As System.String
		Get
			Return _NUMBEN
		End Get
		Set(Byval value as System.String)
			_NUMBEN = value
		End Set
	End Property
#End Region
#Region "NEW 屬性:DEPTN"
	Private _DEPTN As System.String
	''' <summary>
	''' NEW
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property DEPTN () As System.String
		Get
			Return _DEPTN
		End Get
		Set(Byval value as System.String)
			_DEPTN = value
		End Set
	End Property
#End Region
#Region "WHY 屬性:WHY"
	Private _WHY As System.String
	''' <summary>
	''' WHY
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property WHY () As System.String
		Get
			Return _WHY
		End Get
		Set(Byval value as System.String)
			_WHY = value
		End Set
	End Property
#End Region
#Region "NONDISCOUNT 屬性:DEPRED"
	Private _DEPRED As System.Single
	''' <summary>
	''' NONDISCOUNT
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property DEPRED () As System.Single
		Get
			Return _DEPRED
		End Get
		Set(Byval value as System.Single)
			_DEPRED = value
		End Set
	End Property
#End Region
#Region "殘值金額 屬性:V7611"
	Private _V7611 As System.Single
	''' <summary>
	''' 殘值金額
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property V7611 () As System.Single
		Get
			Return _V7611
		End Get
		Set(Byval value as System.Single)
			_V7611 = value
		End Set
	End Property
#End Region
#Region "殘值重估使用年限 屬性:N7611"
	Private _N7611 As System.Int32
	''' <summary>
	''' 殘值重估使用年限
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property N7611 () As System.Int32
		Get
			Return _N7611
		End Get
		Set(Byval value as System.Int32)
			_N7611 = value
		End Set
	End Property
#End Region
End Class
End Namespace