Namespace DEBSYSLB
Public Class LCUSPF
	Inherits ClassDBAS400


	Sub New()
            MyBase.New("DEBSYSLB", GetType(LCUSPF).Name)
        End Sub

#Region "信用狀編號 屬性:LCUSNO"
	Private _LCUSNO As System.String
	''' <summary>
	''' 信用狀編號
	''' </summary>
	''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
 Public Property LCUSNO() As System.String
            Get
                Return _LCUSNO
            End Get
            Set(ByVal value As System.String)
                _LCUSNO = value
            End Set
        End Property
#End Region
#Region "單位別 屬性:DEPART"
	Private _DEPART As System.String
	''' <summary>
	''' 單位別
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property DEPART () As System.String
		Get
			Return _DEPART
		End Get
            Set(ByVal value As System.String)
                _DEPART = value
            End Set
	End Property
#End Region
#Region "金額 屬性:AMOUNT"
	Private _AMOUNT As System.Single
	''' <summary>
	''' 金額
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
#Region "發行日 屬性:LODAY"
	Private _LODAY As System.String
	''' <summary>
	''' 發行日
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property LODAY () As System.String
		Get
			Return _LODAY
		End Get
		Set(Byval value as System.String)
			_LODAY = value
		End Set
	End Property
#End Region
#Region "到期日 屬性:TODAY"
	Private _TODAY As System.String
	''' <summary>
	''' 到期日
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property TODAY () As System.String
		Get
			Return _TODAY
		End Get
		Set(Byval value as System.String)
			_TODAY = value
		End Set
	End Property
#End Region
#Region "期限 屬性:PERIOD"
	Private _PERIOD As System.Int32
	''' <summary>
	''' 期限
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property PERIOD () As System.Int32
		Get
			Return _PERIOD
		End Get
		Set(Byval value as System.Int32)
			_PERIOD = value
		End Set
	End Property
#End Region
#Region "利率 屬性:IR"
	Private _IR As System.Single
	''' <summary>
	''' 利率
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property IR () As System.Single
		Get
			Return _IR
		End Get
		Set(Byval value as System.Single)
			_IR = value
		End Set
	End Property
#End Region
#Region "幣別 屬性:CURRAN"
	Private _CURRAN As System.String
	''' <summary>
	''' 幣別
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property CURRAN () As System.String
		Get
			Return _CURRAN
		End Get
		Set(Byval value as System.String)
			_CURRAN = value
		End Set
	End Property
#End Region
#Region "利息 屬性:INTER"
	Private _INTER As System.Single
	''' <summary>
	''' 利息
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property INTER () As System.Single
            Get
                _INTER = Me.AMOUNT * Me.PERIOD / 360 * Me.IR
                Return _INTER
            End Get
		Set(Byval value as System.Single)
			_INTER = value
		End Set
	End Property
#End Region
#Region "銀行別 屬性:BANK"
	Private _BANK As System.String
	''' <summary>
	''' 銀行別
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BANK () As System.String
		Get
			Return _BANK
		End Get
		Set(Byval value as System.String)
			_BANK = value
		End Set
	End Property
#End Region
#Region "兌換率 屬性:CR"
	Private _CR As System.Single
	''' <summary>
	''' 兌換率
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property CR () As System.Single
		Get
			Return _CR
		End Get
		Set(Byval value as System.Single)
			_CR = value
		End Set
	End Property
#End Region
#Region "新台幣金額 屬性:NTAMT"
        Private _NTAMT As System.Double
	''' <summary>
	''' 新台幣金額
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
        Public Property NTAMT() As System.Double
            Get
                If CR = 0 Then
                    _NTAMT = AMOUNT
                Else
                    _NTAMT = AMOUNT * CR
                End If
                Return _NTAMT
            End Get
            Set(ByVal value As System.Double)
                _NTAMT = value
            End Set
        End Property
#End Region


#Region "單位別ForPC使用 屬性:DEPARTForPC"
        ''' <summary>
        ''' 單位別ForPC使用
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Property DEPARTForPC() As String
            Get
                Return AS400StringConverter.QuickConvert(DEPART, AS400StringConverter.SourceDataTypeEnum.AS400)
            End Get
            Set(ByVal value As String)
                DEPART = AS400StringConverter.QuickConvert(value.Trim, AS400StringConverter.SourceDataTypeEnum.PC)
            End Set
        End Property

#End Region
End Class
End Namespace