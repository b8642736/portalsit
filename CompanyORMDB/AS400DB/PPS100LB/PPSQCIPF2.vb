Namespace PPS100LB
Public Class PPSQCIPF2
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("PPS100LB", GetType(PPSQCIPF2).Name)
	End Sub

#Region "LOTS NO 屬性:QCA01A"
	Private _QCA01A As System.String
	''' <summary>
	''' LOTS NO
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property QCA01A () As System.String
		Get
			Return _QCA01A
		End Get
		Set(Byval value as System.String)
			_QCA01A = value
		End Set
	End Property
#End Region
#Region "BUILD-UP NO 屬性:QCA01B"
	Private _QCA01B As System.String
	''' <summary>
	''' BUILD-UP NO
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property QCA01B () As System.String
		Get
			Return _QCA01B
		End Get
		Set(Byval value as System.String)
			_QCA01B = value
		End Set
	End Property
#End Region
#Region "INSPECT DATE 屬性:QCA02"
	Private _QCA02 As System.Int32
	''' <summary>
	''' INSPECT DATE
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property QCA02 () As System.Int32
		Get
			Return _QCA02
		End Get
		Set(Byval value as System.Int32)
			_QCA02 = value
		End Set
	End Property
#End Region
#Region "INSPECT TIME-HR 屬性:QCA03"
	Private _QCA03 As System.Int32
	''' <summary>
	''' INSPECT TIME-HR
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA03 () As System.Int32
		Get
			Return _QCA03
		End Get
		Set(Byval value as System.Int32)
			_QCA03 = value
		End Set
	End Property
#End Region
#Region "INSPECT TIME-MIN. 屬性:QCA04"
	Private _QCA04 As System.Int32
	''' <summary>
	''' INSPECT TIME-MIN.
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA04 () As System.Int32
		Get
			Return _QCA04
		End Get
		Set(Byval value as System.Int32)
			_QCA04 = value
		End Set
	End Property
#End Region
#Region "GRADE 屬性:QCA05"
	Private _QCA05 As System.String
	''' <summary>
	''' GRADE
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA05 () As System.String
		Get
			Return _QCA05
		End Get
		Set(Byval value as System.String)
			_QCA05 = value
		End Set
	End Property
#End Region
#Region "TYPE 屬性:QCA06"
	Private _QCA06 As System.String
	''' <summary>
	''' TYPE
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA06 () As System.String
		Get
			Return _QCA06
		End Get
		Set(Byval value as System.String)
			_QCA06 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:C 屬性:QCA07"
	Private _QCA07 As System.Single
	''' <summary>
	''' ELEMENT:C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA07 () As System.Single
		Get
			Return _QCA07
		End Get
		Set(Byval value as System.Single)
			_QCA07 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:SI 屬性:QCA08"
	Private _QCA08 As System.Single
	''' <summary>
	''' ELEMENT:SI
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA08 () As System.Single
		Get
			Return _QCA08
		End Get
		Set(Byval value as System.Single)
			_QCA08 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:MN 屬性:QCA09"
	Private _QCA09 As System.Single
	''' <summary>
	''' ELEMENT:MN
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA09 () As System.Single
		Get
			Return _QCA09
		End Get
		Set(Byval value as System.Single)
			_QCA09 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:P 屬性:QCA10"
	Private _QCA10 As System.Single
	''' <summary>
	''' ELEMENT:P
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA10 () As System.Single
		Get
			Return _QCA10
		End Get
		Set(Byval value as System.Single)
			_QCA10 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:S 屬性:QCA11"
	Private _QCA11 As System.Single
	''' <summary>
	''' ELEMENT:S
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA11 () As System.Single
		Get
			Return _QCA11
		End Get
		Set(Byval value as System.Single)
			_QCA11 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:CR 屬性:QCA12"
	Private _QCA12 As System.Single
	''' <summary>
	''' ELEMENT:CR
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA12 () As System.Single
		Get
			Return _QCA12
		End Get
		Set(Byval value as System.Single)
			_QCA12 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:NI 屬性:QCA13"
	Private _QCA13 As System.Single
	''' <summary>
	''' ELEMENT:NI
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA13 () As System.Single
		Get
			Return _QCA13
		End Get
		Set(Byval value as System.Single)
			_QCA13 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:CU 屬性:QCA14"
	Private _QCA14 As System.Single
	''' <summary>
	''' ELEMENT:CU
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA14 () As System.Single
		Get
			Return _QCA14
		End Get
		Set(Byval value as System.Single)
			_QCA14 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:MO 屬性:QCA15"
	Private _QCA15 As System.Single
	''' <summary>
	''' ELEMENT:MO
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA15 () As System.Single
		Get
			Return _QCA15
		End Get
		Set(Byval value as System.Single)
			_QCA15 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:CO 屬性:QCA16"
	Private _QCA16 As System.Single
	''' <summary>
	''' ELEMENT:CO
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA16 () As System.Single
		Get
			Return _QCA16
		End Get
		Set(Byval value as System.Single)
			_QCA16 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:AL 屬性:QCA17"
	Private _QCA17 As System.Single
	''' <summary>
	''' ELEMENT:AL
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA17 () As System.Single
		Get
			Return _QCA17
		End Get
		Set(Byval value as System.Single)
			_QCA17 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:SN 屬性:QCA18"
	Private _QCA18 As System.Single
	''' <summary>
	''' ELEMENT:SN
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA18 () As System.Single
		Get
			Return _QCA18
		End Get
		Set(Byval value as System.Single)
			_QCA18 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:PB 屬性:QCA19"
	Private _QCA19 As System.Single
	''' <summary>
	''' ELEMENT:PB
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA19 () As System.Single
		Get
			Return _QCA19
		End Get
		Set(Byval value as System.Single)
			_QCA19 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:TI 屬性:QCA20"
	Private _QCA20 As System.Single
	''' <summary>
	''' ELEMENT:TI
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA20 () As System.Single
		Get
			Return _QCA20
		End Get
		Set(Byval value as System.Single)
			_QCA20 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:NB 屬性:QCA21"
	Private _QCA21 As System.Single
	''' <summary>
	''' ELEMENT:NB
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA21 () As System.Single
		Get
			Return _QCA21
		End Get
		Set(Byval value as System.Single)
			_QCA21 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:V 屬性:QCA22"
	Private _QCA22 As System.Single
	''' <summary>
	''' ELEMENT:V
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA22 () As System.Single
		Get
			Return _QCA22
		End Get
		Set(Byval value as System.Single)
			_QCA22 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:W 屬性:QCA23"
	Private _QCA23 As System.Single
	''' <summary>
	''' ELEMENT:W
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA23 () As System.Single
		Get
			Return _QCA23
		End Get
		Set(Byval value as System.Single)
			_QCA23 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:O2 屬性:QCA24"
	Private _QCA24 As System.Single
	''' <summary>
	''' ELEMENT:O2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA24 () As System.Single
		Get
			Return _QCA24
		End Get
		Set(Byval value as System.Single)
			_QCA24 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:N2 屬性:QCA25"
	Private _QCA25 As System.Single
	''' <summary>
	''' ELEMENT:N2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA25 () As System.Single
		Get
			Return _QCA25
		End Get
		Set(Byval value as System.Single)
			_QCA25 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:H2 屬性:QCA26"
	Private _QCA26 As System.Single
	''' <summary>
	''' ELEMENT:H2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA26 () As System.Single
		Get
			Return _QCA26
		End Get
		Set(Byval value as System.Single)
			_QCA26 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:B 屬性:QCA27"
	Private _QCA27 As System.Single
	''' <summary>
	''' ELEMENT:B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA27 () As System.Single
		Get
			Return _QCA27
		End Get
		Set(Byval value as System.Single)
			_QCA27 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:Ca 屬性:QCA28"
	Private _QCA28 As System.Single
	''' <summary>
	''' ELEMENT:Ca
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA28 () As System.Single
		Get
			Return _QCA28
		End Get
		Set(Byval value as System.Single)
			_QCA28 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:Mg 屬性:QCA29"
	Private _QCA29 As System.Single
	''' <summary>
	''' ELEMENT:Mg
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA29 () As System.Single
		Get
			Return _QCA29
		End Get
		Set(Byval value as System.Single)
			_QCA29 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:Fe 屬性:QCA30"
	Private _QCA30 As System.Single
	''' <summary>
	''' ELEMENT:Fe
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA30 () As System.Single
		Get
			Return _QCA30
		End Get
		Set(Byval value as System.Single)
			_QCA30 = value
		End Set
	End Property
#End Region
#Region "ELEMENT: 屬性:QCA31"
	Private _QCA31 As System.Single
	''' <summary>
	''' ELEMENT:
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA31 () As System.Single
		Get
			Return _QCA31
		End Get
		Set(Byval value as System.Single)
			_QCA31 = value
		End Set
	End Property
#End Region
#Region "INSPECTOR-1 屬性:QCA32"
	Private _QCA32 As System.String
	''' <summary>
	''' INSPECTOR-1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA32 () As System.String
		Get
			Return _QCA32
		End Get
		Set(Byval value as System.String)
			_QCA32 = value
		End Set
	End Property
#End Region
#Region "INSPECTOR-2 屬性:QCA33"
	Private _QCA33 As System.String
	''' <summary>
	''' INSPECTOR-2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA33 () As System.String
		Get
			Return _QCA33
		End Get
		Set(Byval value as System.String)
			_QCA33 = value
		End Set
	End Property
#End Region
#Region "CODE-1 屬性:QCA34"
	Private _QCA34 As System.String
	''' <summary>
	''' CODE-1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA34 () As System.String
		Get
			Return _QCA34
		End Get
		Set(Byval value as System.String)
			_QCA34 = value
		End Set
	End Property
#End Region
#Region "爐代 屬性:QCA35"
	Private _QCA35 As System.String
	''' <summary>
	''' 爐代
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA35 () As System.String
		Get
			Return _QCA35
		End Get
		Set(Byval value as System.String)
			_QCA35 = value
		End Set
	End Property
#End Region
#Region "CODE-3 屬性:QCA36"
	Private _QCA36 As System.String
	''' <summary>
	''' CODE-3
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA36 () As System.String
		Get
			Return _QCA36
		End Get
		Set(Byval value as System.String)
			_QCA36 = value
		End Set
	End Property
#End Region
#Region "CODE-4 屬性:QCA37"
	Private _QCA37 As System.String
	''' <summary>
	''' CODE-4
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA37 () As System.String
		Get
			Return _QCA37
		End Get
		Set(Byval value as System.String)
			_QCA37 = value
		End Set
	End Property
#End Region
#Region "CODE-5 屬性:QCA38"
	Private _QCA38 As System.String
	''' <summary>
	''' CODE-5
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA38 () As System.String
		Get
			Return _QCA38
		End Get
		Set(Byval value as System.String)
			_QCA38 = value
		End Set
	End Property
#End Region
End Class
End Namespace