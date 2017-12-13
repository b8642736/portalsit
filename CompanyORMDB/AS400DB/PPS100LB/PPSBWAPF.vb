Namespace PPS100LB
Public Class PPSBWAPF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("PPS100LB", GetType(PPSBWAPF).Name)
	End Sub

#Region "HOT ROLLING NO 屬性:BWA01"
	Private _BWA01 As System.String
	''' <summary>
	''' HOT ROLLING NO
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property BWA01 () As System.String
		Get
			Return _BWA01
		End Get
		Set(Byval value as System.String)
			_BWA01 = value
		End Set
	End Property
#End Region
#Region "GRADE 屬性:BWA02"
	Private _BWA02 As System.String
	''' <summary>
	''' GRADE
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWA02 () As System.String
		Get
			Return _BWA02
		End Get
		Set(Byval value as System.String)
			_BWA02 = value
		End Set
	End Property
#End Region
#Region "GAUGE,UNIT-M/M STANDARD 屬性:BWA03"
	Private _BWA03 As System.Single
	''' <summary>
	''' GAUGE,UNIT-M/M STANDARD
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWA03 () As System.Single
		Get
			Return _BWA03
		End Get
		Set(Byval value as System.Single)
			_BWA03 = value
		End Set
	End Property
#End Region
#Region "WIDTH,UNIT-M/M STANDARD 屬性:BWA04"
	Private _BWA04 As System.Int32
	''' <summary>
	''' WIDTH,UNIT-M/M STANDARD
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWA04 () As System.Int32
		Get
			Return _BWA04
		End Get
		Set(Byval value as System.Int32)
			_BWA04 = value
		End Set
	End Property
#End Region
#Region "LENGTH,UNIT-M 屬性:BWA05"
	Private _BWA05 As System.Int32
	''' <summary>
	''' LENGTH,UNIT-M
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWA05 () As System.Int32
		Get
			Return _BWA05
		End Get
		Set(Byval value as System.Int32)
			_BWA05 = value
		End Set
	End Property
#End Region
#Region "WEIGHT,UNIT-KG 屬性:BWA06"
	Private _BWA06 As System.Int32
	''' <summary>
	''' WEIGHT,UNIT-KG
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWA06 () As System.Int32
		Get
			Return _BWA06
		End Get
		Set(Byval value as System.Int32)
			_BWA06 = value
		End Set
	End Property
#End Region
#Region "SLAB NO 屬性:BWA07"
	Private _BWA07 As System.String
	''' <summary>
	''' SLAB NO
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWA07 () As System.String
		Get
			Return _BWA07
		End Get
		Set(Byval value as System.String)
			_BWA07 = value
		End Set
	End Property
#End Region
#Region "BLACK COIL CHECK-IN DATE 屬性:BWA08"
	Private _BWA08 As System.Int32
	''' <summary>
	''' BLACK COIL CHECK-IN DATE
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWA08 () As System.Int32
		Get
			Return _BWA08
		End Get
		Set(Byval value as System.Int32)
			_BWA08 = value
		End Set
	End Property
#End Region
#Region "BUILD-UP NO 屬性:BWA09"
	Private _BWA09 As System.String
	''' <summary>
	''' BUILD-UP NO
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWA09 () As System.String
		Get
			Return _BWA09
		End Get
		Set(Byval value as System.String)
			_BWA09 = value
		End Set
	End Property
#End Region
#Region "BUILD-UP SEQUENCE NO 屬性:BWA10"
	Private _BWA10 As System.String
	''' <summary>
	''' BUILD-UP SEQUENCE NO
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWA10 () As System.String
		Get
			Return _BWA10
		End Get
		Set(Byval value as System.String)
			_BWA10 = value
		End Set
	End Property
#End Region
#Region "LOTS NO 屬性:BWA11"
	Private _BWA11 As System.String
	''' <summary>
	''' LOTS NO
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property BWA11 () As System.String
		Get
			Return _BWA11
		End Get
		Set(Byval value as System.String)
			_BWA11 = value
		End Set
	End Property
#End Region
#Region "CODE-1 屬性:BWA12"
	Private _BWA12 As System.String
	''' <summary>
	''' CODE-1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWA12 () As System.String
		Get
			Return _BWA12
		End Get
		Set(Byval value as System.String)
			_BWA12 = value
		End Set
	End Property
#End Region
#Region "CODE-2 屬性:BWA13"
	Private _BWA13 As System.String
	''' <summary>
	''' CODE-2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWA13 () As System.String
		Get
			Return _BWA13
		End Get
		Set(Byval value as System.String)
			_BWA13 = value
		End Set
	End Property
#End Region
#Region "CODE-3 屬性:BWA14"
	Private _BWA14 As System.String
	''' <summary>
	''' CODE-3
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWA14 () As System.String
		Get
			Return _BWA14
		End Get
		Set(Byval value as System.String)
			_BWA14 = value
		End Set
	End Property
#End Region
#Region "CODE-4 屬性:BWA15"
	Private _BWA15 As System.String
	''' <summary>
	''' CODE-4
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWA15 () As System.String
		Get
			Return _BWA15
		End Get
		Set(Byval value as System.String)
			_BWA15 = value
		End Set
	End Property
#End Region
#Region "CODE-5 屬性:BWA16"
	Private _BWA16 As System.String
	''' <summary>
	''' CODE-5
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWA16 () As System.String
		Get
			Return _BWA16
		End Get
		Set(Byval value as System.String)
			_BWA16 = value
		End Set
	End Property
#End Region
#Region "SCHEDULE NO 屬性:BWA17"
	Private _BWA17 As System.String
	''' <summary>
	''' SCHEDULE NO
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWA17 () As System.String
		Get
			Return _BWA17
		End Get
		Set(Byval value as System.String)
			_BWA17 = value
		End Set
	End Property
#End Region
#Region "GRADE SPECIAL TYPE 屬性:BWA18"
	Private _BWA18 As System.String
	''' <summary>
	''' GRADE SPECIAL TYPE
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWA18 () As System.String
		Get
			Return _BWA18
		End Get
		Set(Byval value as System.String)
			_BWA18 = value
		End Set
	End Property
#End Region
#Region "FINISH 屬性:BWA19"
	Private _BWA19 As System.String
	''' <summary>
	''' FINISH
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWA19 () As System.String
		Get
			Return _BWA19
		End Get
		Set(Byval value as System.String)
			_BWA19 = value
		End Set
	End Property
#End Region
#Region "C/S C:COIL S:SHEET 屬性:BWA20"
	Private _BWA20 As System.String
	''' <summary>
	''' C/S C:COIL S:SHEET
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWA20 () As System.String
		Get
			Return _BWA20
		End Get
		Set(Byval value as System.String)
			_BWA20 = value
		End Set
	End Property
#End Region
#Region "SHEET 屬性:BWA21"
	Private _BWA21 As System.Int32
	''' <summary>
	''' SHEET
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWA21 () As System.Int32
		Get
			Return _BWA21
		End Get
		Set(Byval value as System.Int32)
			_BWA21 = value
		End Set
	End Property
#End Region
#Region "GAUGE,UNIT-M/M ACTUAL 屬性:BWA22"
	Private _BWA22 As System.Single
	''' <summary>
	''' GAUGE,UNIT-M/M ACTUAL
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWA22 () As System.Single
		Get
			Return _BWA22
		End Get
		Set(Byval value as System.Single)
			_BWA22 = value
		End Set
	End Property
#End Region
#Region "WIDTH,UNIT-M/M ACTUAL 屬性:BWA23"
	Private _BWA23 As System.Int32
	''' <summary>
	''' WIDTH,UNIT-M/M ACTUAL
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWA23 () As System.Int32
		Get
			Return _BWA23
		End Get
		Set(Byval value as System.Int32)
			_BWA23 = value
		End Set
	End Property
#End Region
#Region "CLASS 屬性:BWA24"
	Private _BWA24 As System.String
	''' <summary>
	''' CLASS
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWA24 () As System.String
		Get
			Return _BWA24
		End Get
		Set(Byval value as System.String)
			_BWA24 = value
		End Set
	End Property
#End Region
End Class
End Namespace