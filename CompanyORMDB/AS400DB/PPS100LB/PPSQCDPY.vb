Namespace PPS100LB
Public Class PPSQCDPY
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("PPS100LB", GetType(PPSQCDPY).Name)
	End Sub

#Region "CERTIFICATE NO 屬性:QCD01"
	Private _QCD01 As System.String
	''' <summary>
	''' CERTIFICATE NO
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD01 () As System.String
		Get
			Return _QCD01
		End Get
		Set(Byval value as System.String)
			_QCD01 = value
		End Set
	End Property
#End Region
#Region "CUSTOMER NO 屬性:QCD02"
	Private _QCD02 As System.String
	''' <summary>
	''' CUSTOMER NO
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property QCD02 () As System.String
		Get
			Return _QCD02
		End Get
		Set(Byval value as System.String)
			_QCD02 = value
		End Set
	End Property
#End Region
#Region "ORDER NO 屬性:QCD03"
	Private _QCD03 As System.String
	''' <summary>
	''' ORDER NO
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property QCD03 () As System.String
		Get
			Return _QCD03
		End Get
		Set(Byval value as System.String)
			_QCD03 = value
		End Set
	End Property
#End Region
#Region "L/C NO 屬性:QCD04"
	Private _QCD04 As System.String
	''' <summary>
	''' L/C NO
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property QCD04 () As System.String
		Get
			Return _QCD04
		End Get
		Set(Byval value as System.String)
			_QCD04 = value
		End Set
	End Property
#End Region
#Region "DESCRIPTION 屬性:QCD05"
	Private _QCD05 As System.String
	''' <summary>
	''' DESCRIPTION
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD05 () As System.String
		Get
			Return _QCD05
		End Get
		Set(Byval value as System.String)
			_QCD05 = value
		End Set
	End Property
#End Region
#Region "SPECIFICATION 屬性:QCD06"
	Private _QCD06 As System.String
	''' <summary>
	''' SPECIFICATION
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD06 () As System.String
		Get
			Return _QCD06
		End Get
		Set(Byval value as System.String)
			_QCD06 = value
		End Set
	End Property
#End Region
#Region "SIZE-1 屬性:QCD07"
	Private _QCD07 As System.String
	''' <summary>
	''' SIZE-1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD07 () As System.String
		Get
			Return _QCD07
		End Get
		Set(Byval value as System.String)
			_QCD07 = value
		End Set
	End Property
#End Region
#Region "GRADE-1 屬性:QCD08X"
	Private _QCD08X As System.String
	''' <summary>
	''' GRADE-1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD08X () As System.String
		Get
			Return _QCD08X
		End Get
		Set(Byval value as System.String)
			_QCD08X = value
		End Set
	End Property
#End Region
#Region "FINISH-1 屬性:QCD09X"
	Private _QCD09X As System.String
	''' <summary>
	''' FINISH-1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD09X () As System.String
		Get
			Return _QCD09X
		End Get
		Set(Byval value as System.String)
			_QCD09X = value
		End Set
	End Property
#End Region
#Region "QUANTITY-1 屬性:QCD10"
	Private _QCD10 As System.Int32
	''' <summary>
	''' QUANTITY-1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD10 () As System.Int32
		Get
			Return _QCD10
		End Get
		Set(Byval value as System.Int32)
			_QCD10 = value
		End Set
	End Property
#End Region
#Region "UNIT-1 屬性:QCD11"
	Private _QCD11 As System.String
	''' <summary>
	''' UNIT-1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD11 () As System.String
		Get
			Return _QCD11
		End Get
		Set(Byval value as System.String)
			_QCD11 = value
		End Set
	End Property
#End Region
#Region "WEIGHT-1 屬性:QCD12"
	Private _QCD12 As System.Int32
	''' <summary>
	''' WEIGHT-1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD12 () As System.Int32
		Get
			Return _QCD12
		End Get
		Set(Byval value as System.Int32)
			_QCD12 = value
		End Set
	End Property
#End Region
#Region "WT-UNIT-1 屬性:QCD13"
	Private _QCD13 As System.String
	''' <summary>
	''' WT-UNIT-1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD13 () As System.String
		Get
			Return _QCD13
		End Get
		Set(Byval value as System.String)
			_QCD13 = value
		End Set
	End Property
#End Region
#Region "HEAT NO-1 屬性:QCD14"
	Private _QCD14 As System.String
	''' <summary>
	''' HEAT NO-1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD14 () As System.String
		Get
			Return _QCD14
		End Get
		Set(Byval value as System.String)
			_QCD14 = value
		End Set
	End Property
#End Region
#Region "COIL NO-1 屬性:QCD15"
	Private _QCD15 As System.String
	''' <summary>
	''' COIL NO-1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD15 () As System.String
		Get
			Return _QCD15
		End Get
		Set(Byval value as System.String)
			_QCD15 = value
		End Set
	End Property
#End Region
#Region "BREAK NO-1 屬性:QCD16"
	Private _QCD16 As System.String
	''' <summary>
	''' BREAK NO-1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD16 () As System.String
		Get
			Return _QCD16
		End Get
		Set(Byval value as System.String)
			_QCD16 = value
		End Set
	End Property
#End Region
#Region "SIZE-2 屬性:QCD17"
	Private _QCD17 As System.String
	''' <summary>
	''' SIZE-2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD17 () As System.String
		Get
			Return _QCD17
		End Get
		Set(Byval value as System.String)
			_QCD17 = value
		End Set
	End Property
#End Region
#Region "GRADE-2 屬性:QCD18X"
	Private _QCD18X As System.String
	''' <summary>
	''' GRADE-2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD18X () As System.String
		Get
			Return _QCD18X
		End Get
		Set(Byval value as System.String)
			_QCD18X = value
		End Set
	End Property
#End Region
#Region "FINISH-2 屬性:QCD19X"
	Private _QCD19X As System.String
	''' <summary>
	''' FINISH-2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD19X () As System.String
		Get
			Return _QCD19X
		End Get
		Set(Byval value as System.String)
			_QCD19X = value
		End Set
	End Property
#End Region
#Region "QUANTITY-2 屬性:QCD20"
	Private _QCD20 As System.Int32
	''' <summary>
	''' QUANTITY-2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD20 () As System.Int32
		Get
			Return _QCD20
		End Get
		Set(Byval value as System.Int32)
			_QCD20 = value
		End Set
	End Property
#End Region
#Region "UNIT-2 屬性:QCD21"
	Private _QCD21 As System.String
	''' <summary>
	''' UNIT-2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD21 () As System.String
		Get
			Return _QCD21
		End Get
		Set(Byval value as System.String)
			_QCD21 = value
		End Set
	End Property
#End Region
#Region "WEIGHT-2 屬性:QCD22"
	Private _QCD22 As System.Int32
	''' <summary>
	''' WEIGHT-2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD22 () As System.Int32
		Get
			Return _QCD22
		End Get
		Set(Byval value as System.Int32)
			_QCD22 = value
		End Set
	End Property
#End Region
#Region "WT-UNIT-2 屬性:QCD23"
	Private _QCD23 As System.String
	''' <summary>
	''' WT-UNIT-2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD23 () As System.String
		Get
			Return _QCD23
		End Get
		Set(Byval value as System.String)
			_QCD23 = value
		End Set
	End Property
#End Region
#Region "HEAT NO-2 屬性:QCD24"
	Private _QCD24 As System.String
	''' <summary>
	''' HEAT NO-2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD24 () As System.String
		Get
			Return _QCD24
		End Get
		Set(Byval value as System.String)
			_QCD24 = value
		End Set
	End Property
#End Region
#Region "COIL NO-2 屬性:QCD25"
	Private _QCD25 As System.String
	''' <summary>
	''' COIL NO-2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD25 () As System.String
		Get
			Return _QCD25
		End Get
		Set(Byval value as System.String)
			_QCD25 = value
		End Set
	End Property
#End Region
#Region "BREAK NO-2 屬性:QCD26"
	Private _QCD26 As System.String
	''' <summary>
	''' BREAK NO-2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD26 () As System.String
		Get
			Return _QCD26
		End Get
		Set(Byval value as System.String)
			_QCD26 = value
		End Set
	End Property
#End Region
#Region "SIZE-3 屬性:QCD27"
	Private _QCD27 As System.String
	''' <summary>
	''' SIZE-3
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD27 () As System.String
		Get
			Return _QCD27
		End Get
		Set(Byval value as System.String)
			_QCD27 = value
		End Set
	End Property
#End Region
#Region "GRADE-3 屬性:QCD28X"
	Private _QCD28X As System.String
	''' <summary>
	''' GRADE-3
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD28X () As System.String
		Get
			Return _QCD28X
		End Get
		Set(Byval value as System.String)
			_QCD28X = value
		End Set
	End Property
#End Region
#Region "FINISH-3 屬性:QCD29X"
	Private _QCD29X As System.String
	''' <summary>
	''' FINISH-3
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD29X () As System.String
		Get
			Return _QCD29X
		End Get
		Set(Byval value as System.String)
			_QCD29X = value
		End Set
	End Property
#End Region
#Region "QUANTITY-3 屬性:QCD30"
	Private _QCD30 As System.Int32
	''' <summary>
	''' QUANTITY-3
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD30 () As System.Int32
		Get
			Return _QCD30
		End Get
		Set(Byval value as System.Int32)
			_QCD30 = value
		End Set
	End Property
#End Region
#Region "UNIT-3 屬性:QCD31"
	Private _QCD31 As System.String
	''' <summary>
	''' UNIT-3
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD31 () As System.String
		Get
			Return _QCD31
		End Get
		Set(Byval value as System.String)
			_QCD31 = value
		End Set
	End Property
#End Region
#Region "WEIGHT-3 屬性:QCD32"
	Private _QCD32 As System.Int32
	''' <summary>
	''' WEIGHT-3
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD32 () As System.Int32
		Get
			Return _QCD32
		End Get
		Set(Byval value as System.Int32)
			_QCD32 = value
		End Set
	End Property
#End Region
#Region "WT-UNIT-3 屬性:QCD33"
	Private _QCD33 As System.String
	''' <summary>
	''' WT-UNIT-3
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD33 () As System.String
		Get
			Return _QCD33
		End Get
		Set(Byval value as System.String)
			_QCD33 = value
		End Set
	End Property
#End Region
#Region "HEAT NO-3 屬性:QCD34"
	Private _QCD34 As System.String
	''' <summary>
	''' HEAT NO-3
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD34 () As System.String
		Get
			Return _QCD34
		End Get
		Set(Byval value as System.String)
			_QCD34 = value
		End Set
	End Property
#End Region
#Region "COIL NO-3 屬性:QCD35"
	Private _QCD35 As System.String
	''' <summary>
	''' COIL NO-3
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD35 () As System.String
		Get
			Return _QCD35
		End Get
		Set(Byval value as System.String)
			_QCD35 = value
		End Set
	End Property
#End Region
#Region "BREAK NO-3 屬性:QCD36"
	Private _QCD36 As System.String
	''' <summary>
	''' BREAK NO-3
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD36 () As System.String
		Get
			Return _QCD36
		End Get
		Set(Byval value as System.String)
			_QCD36 = value
		End Set
	End Property
#End Region
#Region "SIZE-4 屬性:QCD37"
	Private _QCD37 As System.String
	''' <summary>
	''' SIZE-4
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD37 () As System.String
		Get
			Return _QCD37
		End Get
		Set(Byval value as System.String)
			_QCD37 = value
		End Set
	End Property
#End Region
#Region "GRADE-4 屬性:QCD38X"
	Private _QCD38X As System.String
	''' <summary>
	''' GRADE-4
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD38X () As System.String
		Get
			Return _QCD38X
		End Get
		Set(Byval value as System.String)
			_QCD38X = value
		End Set
	End Property
#End Region
#Region "FINISH-4 屬性:QCD39X"
	Private _QCD39X As System.String
	''' <summary>
	''' FINISH-4
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD39X () As System.String
		Get
			Return _QCD39X
		End Get
		Set(Byval value as System.String)
			_QCD39X = value
		End Set
	End Property
#End Region
#Region "QUANTITY-4 屬性:QCD40"
	Private _QCD40 As System.Int32
	''' <summary>
	''' QUANTITY-4
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD40 () As System.Int32
		Get
			Return _QCD40
		End Get
		Set(Byval value as System.Int32)
			_QCD40 = value
		End Set
	End Property
#End Region
#Region "UNIT-4 屬性:QCD41"
	Private _QCD41 As System.String
	''' <summary>
	''' UNIT-4
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD41 () As System.String
		Get
			Return _QCD41
		End Get
		Set(Byval value as System.String)
			_QCD41 = value
		End Set
	End Property
#End Region
#Region "WEIGHT-4 屬性:QCD42"
	Private _QCD42 As System.Int32
	''' <summary>
	''' WEIGHT-4
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD42 () As System.Int32
		Get
			Return _QCD42
		End Get
		Set(Byval value as System.Int32)
			_QCD42 = value
		End Set
	End Property
#End Region
#Region "WT-UNIT-4 屬性:QCD43"
	Private _QCD43 As System.String
	''' <summary>
	''' WT-UNIT-4
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD43 () As System.String
		Get
			Return _QCD43
		End Get
		Set(Byval value as System.String)
			_QCD43 = value
		End Set
	End Property
#End Region
#Region "HEAT NO-4 屬性:QCD44"
	Private _QCD44 As System.String
	''' <summary>
	''' HEAT NO-4
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD44 () As System.String
		Get
			Return _QCD44
		End Get
		Set(Byval value as System.String)
			_QCD44 = value
		End Set
	End Property
#End Region
#Region "COIL NO-4 屬性:QCD45"
	Private _QCD45 As System.String
	''' <summary>
	''' COIL NO-4
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD45 () As System.String
		Get
			Return _QCD45
		End Get
		Set(Byval value as System.String)
			_QCD45 = value
		End Set
	End Property
#End Region
#Region "BREAK NO-4 屬性:QCD46"
	Private _QCD46 As System.String
	''' <summary>
	''' BREAK NO-4
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD46 () As System.String
		Get
			Return _QCD46
		End Get
		Set(Byval value as System.String)
			_QCD46 = value
		End Set
	End Property
#End Region
#Region "SIZE-5 屬性:QCD47"
	Private _QCD47 As System.String
	''' <summary>
	''' SIZE-5
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD47 () As System.String
		Get
			Return _QCD47
		End Get
		Set(Byval value as System.String)
			_QCD47 = value
		End Set
	End Property
#End Region
#Region "GRADE-5 屬性:QCD48X"
	Private _QCD48X As System.String
	''' <summary>
	''' GRADE-5
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD48X () As System.String
		Get
			Return _QCD48X
		End Get
		Set(Byval value as System.String)
			_QCD48X = value
		End Set
	End Property
#End Region
#Region "FINISH-5 屬性:QCD49X"
	Private _QCD49X As System.String
	''' <summary>
	''' FINISH-5
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD49X () As System.String
		Get
			Return _QCD49X
		End Get
		Set(Byval value as System.String)
			_QCD49X = value
		End Set
	End Property
#End Region
#Region "QUANTITY-5 屬性:QCD50"
	Private _QCD50 As System.Int32
	''' <summary>
	''' QUANTITY-5
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD50 () As System.Int32
		Get
			Return _QCD50
		End Get
		Set(Byval value as System.Int32)
			_QCD50 = value
		End Set
	End Property
#End Region
#Region "UNIT-5 屬性:QCD51"
	Private _QCD51 As System.String
	''' <summary>
	''' UNIT-5
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD51 () As System.String
		Get
			Return _QCD51
		End Get
		Set(Byval value as System.String)
			_QCD51 = value
		End Set
	End Property
#End Region
#Region "WEIGHT-5 屬性:QCD52"
	Private _QCD52 As System.Int32
	''' <summary>
	''' WEIGHT-5
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD52 () As System.Int32
		Get
			Return _QCD52
		End Get
		Set(Byval value as System.Int32)
			_QCD52 = value
		End Set
	End Property
#End Region
#Region "WT-UNIT-5 屬性:QCD53"
	Private _QCD53 As System.String
	''' <summary>
	''' WT-UNIT-5
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD53 () As System.String
		Get
			Return _QCD53
		End Get
		Set(Byval value as System.String)
			_QCD53 = value
		End Set
	End Property
#End Region
#Region "HEAT NO-5 屬性:QCD54"
	Private _QCD54 As System.String
	''' <summary>
	''' HEAT NO-5
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD54 () As System.String
		Get
			Return _QCD54
		End Get
		Set(Byval value as System.String)
			_QCD54 = value
		End Set
	End Property
#End Region
#Region "COIL NO-5 屬性:QCD55"
	Private _QCD55 As System.String
	''' <summary>
	''' COIL NO-5
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD55 () As System.String
		Get
			Return _QCD55
		End Get
		Set(Byval value as System.String)
			_QCD55 = value
		End Set
	End Property
#End Region
#Region "BREAK NO-5 屬性:QCD56"
	Private _QCD56 As System.String
	''' <summary>
	''' BREAK NO-5
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD56 () As System.String
		Get
			Return _QCD56
		End Get
		Set(Byval value as System.String)
			_QCD56 = value
		End Set
	End Property
#End Region
#Region "SIZE-6 屬性:QCD57"
	Private _QCD57 As System.String
	''' <summary>
	''' SIZE-6
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD57 () As System.String
		Get
			Return _QCD57
		End Get
		Set(Byval value as System.String)
			_QCD57 = value
		End Set
	End Property
#End Region
#Region "GRADE-6 屬性:QCD58X"
	Private _QCD58X As System.String
	''' <summary>
	''' GRADE-6
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD58X () As System.String
		Get
			Return _QCD58X
		End Get
		Set(Byval value as System.String)
			_QCD58X = value
		End Set
	End Property
#End Region
#Region "FINISH-6 屬性:QCD59X"
	Private _QCD59X As System.String
	''' <summary>
	''' FINISH-6
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD59X () As System.String
		Get
			Return _QCD59X
		End Get
		Set(Byval value as System.String)
			_QCD59X = value
		End Set
	End Property
#End Region
#Region "QUANTITY-6 屬性:QCD60"
	Private _QCD60 As System.Int32
	''' <summary>
	''' QUANTITY-6
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD60 () As System.Int32
		Get
			Return _QCD60
		End Get
		Set(Byval value as System.Int32)
			_QCD60 = value
		End Set
	End Property
#End Region
#Region "UNIT-6 屬性:QCD61"
	Private _QCD61 As System.String
	''' <summary>
	''' UNIT-6
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD61 () As System.String
		Get
			Return _QCD61
		End Get
		Set(Byval value as System.String)
			_QCD61 = value
		End Set
	End Property
#End Region
#Region "WEIGHT-6 屬性:QCD62"
	Private _QCD62 As System.Int32
	''' <summary>
	''' WEIGHT-6
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD62 () As System.Int32
		Get
			Return _QCD62
		End Get
		Set(Byval value as System.Int32)
			_QCD62 = value
		End Set
	End Property
#End Region
#Region "WT-UNIT-6 屬性:QCD63"
	Private _QCD63 As System.String
	''' <summary>
	''' WT-UNIT-6
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD63 () As System.String
		Get
			Return _QCD63
		End Get
		Set(Byval value as System.String)
			_QCD63 = value
		End Set
	End Property
#End Region
#Region "HEAT NO-6 屬性:QCD64"
	Private _QCD64 As System.String
	''' <summary>
	''' HEAT NO-6
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD64 () As System.String
		Get
			Return _QCD64
		End Get
		Set(Byval value as System.String)
			_QCD64 = value
		End Set
	End Property
#End Region
#Region "COIL NO-6 屬性:QCD65"
	Private _QCD65 As System.String
	''' <summary>
	''' COIL NO-6
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD65 () As System.String
		Get
			Return _QCD65
		End Get
		Set(Byval value as System.String)
			_QCD65 = value
		End Set
	End Property
#End Region
#Region "BREAK NO-6 屬性:QCD66"
	Private _QCD66 As System.String
	''' <summary>
	''' BREAK NO-6
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD66 () As System.String
		Get
			Return _QCD66
		End Get
		Set(Byval value as System.String)
			_QCD66 = value
		End Set
	End Property
#End Region
#Region "SIZE-7 屬性:QCD67"
	Private _QCD67 As System.String
	''' <summary>
	''' SIZE-7
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD67 () As System.String
		Get
			Return _QCD67
		End Get
		Set(Byval value as System.String)
			_QCD67 = value
		End Set
	End Property
#End Region
#Region "GRADE-7 屬性:QCD68X"
	Private _QCD68X As System.String
	''' <summary>
	''' GRADE-7
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD68X () As System.String
		Get
			Return _QCD68X
		End Get
		Set(Byval value as System.String)
			_QCD68X = value
		End Set
	End Property
#End Region
#Region "FINISH-7 屬性:QCD69X"
	Private _QCD69X As System.String
	''' <summary>
	''' FINISH-7
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD69X () As System.String
		Get
			Return _QCD69X
		End Get
		Set(Byval value as System.String)
			_QCD69X = value
		End Set
	End Property
#End Region
#Region "QUANTITY-7 屬性:QCD70"
	Private _QCD70 As System.Int32
	''' <summary>
	''' QUANTITY-7
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD70 () As System.Int32
		Get
			Return _QCD70
		End Get
		Set(Byval value as System.Int32)
			_QCD70 = value
		End Set
	End Property
#End Region
#Region "UNIT-7 屬性:QCD71"
	Private _QCD71 As System.String
	''' <summary>
	''' UNIT-7
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD71 () As System.String
		Get
			Return _QCD71
		End Get
		Set(Byval value as System.String)
			_QCD71 = value
		End Set
	End Property
#End Region
#Region "WEIGHT-7 屬性:QCD72"
	Private _QCD72 As System.Int32
	''' <summary>
	''' WEIGHT-7
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD72 () As System.Int32
		Get
			Return _QCD72
		End Get
		Set(Byval value as System.Int32)
			_QCD72 = value
		End Set
	End Property
#End Region
#Region "WT-UNIT-7 屬性:QCD73"
	Private _QCD73 As System.String
	''' <summary>
	''' WT-UNIT-7
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD73 () As System.String
		Get
			Return _QCD73
		End Get
		Set(Byval value as System.String)
			_QCD73 = value
		End Set
	End Property
#End Region
#Region "HEAT NO-7 屬性:QCD74"
	Private _QCD74 As System.String
	''' <summary>
	''' HEAT NO-7
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD74 () As System.String
		Get
			Return _QCD74
		End Get
		Set(Byval value as System.String)
			_QCD74 = value
		End Set
	End Property
#End Region
#Region "COIL NO-7 屬性:QCD75"
	Private _QCD75 As System.String
	''' <summary>
	''' COIL NO-7
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD75 () As System.String
		Get
			Return _QCD75
		End Get
		Set(Byval value as System.String)
			_QCD75 = value
		End Set
	End Property
#End Region
#Region "BREAK NO-7 屬性:QCD76"
	Private _QCD76 As System.String
	''' <summary>
	''' BREAK NO-7
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD76 () As System.String
		Get
			Return _QCD76
		End Get
		Set(Byval value as System.String)
			_QCD76 = value
		End Set
	End Property
#End Region
#Region "CODE-1 屬性:QCD77"
	Private _QCD77 As System.String
	''' <summary>
	''' CODE-1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD77 () As System.String
		Get
			Return _QCD77
		End Get
		Set(Byval value as System.String)
			_QCD77 = value
		End Set
	End Property
#End Region
#Region "CODE-2 屬性:QCD78"
	Private _QCD78 As System.String
	''' <summary>
	''' CODE-2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD78 () As System.String
		Get
			Return _QCD78
		End Get
		Set(Byval value as System.String)
			_QCD78 = value
		End Set
	End Property
#End Region
#Region "CODE-3 N:印氮 屬性:QCD79"
	Private _QCD79 As System.String
	''' <summary>
	''' CODE-3 N:印氮
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD79 () As System.String
		Get
			Return _QCD79
		End Get
		Set(Byval value as System.String)
			_QCD79 = value
		End Set
	End Property
#End Region
#Region "CODE-4 Y: ASTM 屬性:QCD80"
	Private _QCD80 As System.String
	''' <summary>
	''' CODE-4 Y: ASTM
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD80 () As System.String
		Get
			Return _QCD80
		End Get
		Set(Byval value as System.String)
			_QCD80 = value
		End Set
	End Property
#End Region
#Region "COPIES 屬性:QCD81"
	Private _QCD81 As System.Int32
	''' <summary>
	''' COPIES
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD81 () As System.Int32
		Get
			Return _QCD81
		End Get
		Set(Byval value as System.Int32)
			_QCD81 = value
		End Set
	End Property
#End Region
#Region "Type_A 屬性:QCD0A"
	Private _QCD0A As System.String
	''' <summary>
	''' Type_A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD0A () As System.String
		Get
			Return _QCD0A
		End Get
		Set(Byval value as System.String)
			_QCD0A = value
		End Set
	End Property
#End Region
#Region "DATE 屬性:QCD0B"
	Private _QCD0B As System.Int32
	''' <summary>
	''' DATE
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD0B () As System.Int32
		Get
			Return _QCD0B
		End Get
		Set(Byval value as System.Int32)
			_QCD0B = value
		End Set
	End Property
#End Region
#Region "客戶 屬性:QCD0C"
	Private _QCD0C As System.String
	''' <summary>
	''' 客戶
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD0C () As System.String
		Get
			Return _QCD0C
		End Get
		Set(Byval value as System.String)
			_QCD0C = value
		End Set
	End Property
#End Region
#Region "規格標準 屬性:QCD0D"
	Private _QCD0D As System.String
	''' <summary>
	''' 規格標準
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCD0D () As System.String
		Get
			Return _QCD0D
		End Get
		Set(Byval value as System.String)
			_QCD0D = value
		End Set
	End Property
#End Region
#Region "ELEMENT:C 屬性:QCA070"
	Private _QCA070 As System.Single
	''' <summary>
	''' ELEMENT:C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA070 () As System.Single
		Get
			Return _QCA070
		End Get
		Set(Byval value as System.Single)
			_QCA070 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:SI 屬性:QCA080"
	Private _QCA080 As System.Single
	''' <summary>
	''' ELEMENT:SI
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA080 () As System.Single
		Get
			Return _QCA080
		End Get
		Set(Byval value as System.Single)
			_QCA080 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:MN 屬性:QCA090"
	Private _QCA090 As System.Single
	''' <summary>
	''' ELEMENT:MN
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA090 () As System.Single
		Get
			Return _QCA090
		End Get
		Set(Byval value as System.Single)
			_QCA090 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:P 屬性:QCA100"
	Private _QCA100 As System.Single
	''' <summary>
	''' ELEMENT:P
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA100 () As System.Single
		Get
			Return _QCA100
		End Get
		Set(Byval value as System.Single)
			_QCA100 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:S 屬性:QCA110"
	Private _QCA110 As System.Single
	''' <summary>
	''' ELEMENT:S
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA110 () As System.Single
		Get
			Return _QCA110
		End Get
		Set(Byval value as System.Single)
			_QCA110 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:CR 屬性:QCA120"
	Private _QCA120 As System.Single
	''' <summary>
	''' ELEMENT:CR
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA120 () As System.Single
		Get
			Return _QCA120
		End Get
		Set(Byval value as System.Single)
			_QCA120 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:NI 屬性:QCA130"
	Private _QCA130 As System.Single
	''' <summary>
	''' ELEMENT:NI
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA130 () As System.Single
		Get
			Return _QCA130
		End Get
		Set(Byval value as System.Single)
			_QCA130 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:MO 屬性:QCA150"
	Private _QCA150 As System.Single
	''' <summary>
	''' ELEMENT:MO
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA150 () As System.Single
		Get
			Return _QCA150
		End Get
		Set(Byval value as System.Single)
			_QCA150 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:N2 屬性:QCA250"
	Private _QCA250 As System.Single
	''' <summary>
	''' ELEMENT:N2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA250 () As System.Single
		Get
			Return _QCA250
		End Get
		Set(Byval value as System.Single)
			_QCA250 = value
		End Set
	End Property
#End Region
#Region "T.S KG/MM¬2 屬性:QCG120"
	Private _QCG120 As System.Int32
	''' <summary>
	''' T.S KG/MM¬2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG120 () As System.Int32
		Get
			Return _QCG120
		End Get
		Set(Byval value as System.Int32)
			_QCG120 = value
		End Set
	End Property
#End Region
#Region "Y.S KG/MM¬2 屬性:QCG110"
	Private _QCG110 As System.Int32
	''' <summary>
	''' Y.S KG/MM¬2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG110 () As System.Int32
		Get
			Return _QCG110
		End Get
		Set(Byval value as System.Int32)
			_QCG110 = value
		End Set
	End Property
#End Region
#Region "ELONGATION % 屬性:QCG130"
	Private _QCG130 As System.Single
	''' <summary>
	''' ELONGATION %
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG130 () As System.Single
		Get
			Return _QCG130
		End Get
		Set(Byval value as System.Single)
			_QCG130 = value
		End Set
	End Property
#End Region
#Region "HRB 屬性:QCG140"
	Private _QCG140 As System.Single
	''' <summary>
	''' HRB
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG140 () As System.Single
		Get
			Return _QCG140
		End Get
		Set(Byval value as System.Single)
			_QCG140 = value
		End Set
	End Property
#End Region
#Region "HRC 屬性:QCG210"
	Private _QCG210 As System.Single
	''' <summary>
	''' HRC
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG210 () As System.Single
		Get
			Return _QCG210
		End Get
		Set(Byval value as System.Single)
			_QCG210 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:C 屬性:QCA071"
	Private _QCA071 As System.Single
	''' <summary>
	''' ELEMENT:C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA071 () As System.Single
		Get
			Return _QCA071
		End Get
		Set(Byval value as System.Single)
			_QCA071 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:SI 屬性:QCA081"
	Private _QCA081 As System.Single
	''' <summary>
	''' ELEMENT:SI
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA081 () As System.Single
		Get
			Return _QCA081
		End Get
		Set(Byval value as System.Single)
			_QCA081 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:MN 屬性:QCA091"
	Private _QCA091 As System.Single
	''' <summary>
	''' ELEMENT:MN
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA091 () As System.Single
		Get
			Return _QCA091
		End Get
		Set(Byval value as System.Single)
			_QCA091 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:P 屬性:QCA101"
	Private _QCA101 As System.Single
	''' <summary>
	''' ELEMENT:P
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA101 () As System.Single
		Get
			Return _QCA101
		End Get
		Set(Byval value as System.Single)
			_QCA101 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:S 屬性:QCA111"
	Private _QCA111 As System.Single
	''' <summary>
	''' ELEMENT:S
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA111 () As System.Single
		Get
			Return _QCA111
		End Get
		Set(Byval value as System.Single)
			_QCA111 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:CR 屬性:QCA121"
	Private _QCA121 As System.Single
	''' <summary>
	''' ELEMENT:CR
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA121 () As System.Single
		Get
			Return _QCA121
		End Get
		Set(Byval value as System.Single)
			_QCA121 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:NI 屬性:QCA131"
	Private _QCA131 As System.Single
	''' <summary>
	''' ELEMENT:NI
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA131 () As System.Single
		Get
			Return _QCA131
		End Get
		Set(Byval value as System.Single)
			_QCA131 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:MO 屬性:QCA151"
	Private _QCA151 As System.Single
	''' <summary>
	''' ELEMENT:MO
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA151 () As System.Single
		Get
			Return _QCA151
		End Get
		Set(Byval value as System.Single)
			_QCA151 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:N2 屬性:QCA251"
	Private _QCA251 As System.Single
	''' <summary>
	''' ELEMENT:N2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA251 () As System.Single
		Get
			Return _QCA251
		End Get
		Set(Byval value as System.Single)
			_QCA251 = value
		End Set
	End Property
#End Region
#Region "T.S KG/MM¬2 屬性:QCG121"
	Private _QCG121 As System.Int32
	''' <summary>
	''' T.S KG/MM¬2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG121 () As System.Int32
		Get
			Return _QCG121
		End Get
		Set(Byval value as System.Int32)
			_QCG121 = value
		End Set
	End Property
#End Region
#Region "Y.S KG/MM¬2 屬性:QCG111"
	Private _QCG111 As System.Int32
	''' <summary>
	''' Y.S KG/MM¬2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG111 () As System.Int32
		Get
			Return _QCG111
		End Get
		Set(Byval value as System.Int32)
			_QCG111 = value
		End Set
	End Property
#End Region
#Region "ELONGATION % 屬性:QCG131"
	Private _QCG131 As System.Single
	''' <summary>
	''' ELONGATION %
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG131 () As System.Single
		Get
			Return _QCG131
		End Get
		Set(Byval value as System.Single)
			_QCG131 = value
		End Set
	End Property
#End Region
#Region "HRB 屬性:QCG141"
	Private _QCG141 As System.Single
	''' <summary>
	''' HRB
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG141 () As System.Single
		Get
			Return _QCG141
		End Get
		Set(Byval value as System.Single)
			_QCG141 = value
		End Set
	End Property
#End Region
#Region "HRC 屬性:QCG211"
	Private _QCG211 As System.Single
	''' <summary>
	''' HRC
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG211 () As System.Single
		Get
			Return _QCG211
		End Get
		Set(Byval value as System.Single)
			_QCG211 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:C 屬性:QCA072"
	Private _QCA072 As System.Single
	''' <summary>
	''' ELEMENT:C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA072 () As System.Single
		Get
			Return _QCA072
		End Get
		Set(Byval value as System.Single)
			_QCA072 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:SI 屬性:QCA082"
	Private _QCA082 As System.Single
	''' <summary>
	''' ELEMENT:SI
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA082 () As System.Single
		Get
			Return _QCA082
		End Get
		Set(Byval value as System.Single)
			_QCA082 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:MN 屬性:QCA092"
	Private _QCA092 As System.Single
	''' <summary>
	''' ELEMENT:MN
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA092 () As System.Single
		Get
			Return _QCA092
		End Get
		Set(Byval value as System.Single)
			_QCA092 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:P 屬性:QCA102"
	Private _QCA102 As System.Single
	''' <summary>
	''' ELEMENT:P
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA102 () As System.Single
		Get
			Return _QCA102
		End Get
		Set(Byval value as System.Single)
			_QCA102 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:S 屬性:QCA112"
	Private _QCA112 As System.Single
	''' <summary>
	''' ELEMENT:S
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA112 () As System.Single
		Get
			Return _QCA112
		End Get
		Set(Byval value as System.Single)
			_QCA112 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:CR 屬性:QCA122"
	Private _QCA122 As System.Single
	''' <summary>
	''' ELEMENT:CR
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA122 () As System.Single
		Get
			Return _QCA122
		End Get
		Set(Byval value as System.Single)
			_QCA122 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:NI 屬性:QCA132"
	Private _QCA132 As System.Single
	''' <summary>
	''' ELEMENT:NI
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA132 () As System.Single
		Get
			Return _QCA132
		End Get
		Set(Byval value as System.Single)
			_QCA132 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:MO 屬性:QCA152"
	Private _QCA152 As System.Single
	''' <summary>
	''' ELEMENT:MO
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA152 () As System.Single
		Get
			Return _QCA152
		End Get
		Set(Byval value as System.Single)
			_QCA152 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:N2 屬性:QCA252"
	Private _QCA252 As System.Single
	''' <summary>
	''' ELEMENT:N2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA252 () As System.Single
		Get
			Return _QCA252
		End Get
		Set(Byval value as System.Single)
			_QCA252 = value
		End Set
	End Property
#End Region
#Region "T.S KG/MM¬2 屬性:QCG122"
	Private _QCG122 As System.Int32
	''' <summary>
	''' T.S KG/MM¬2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG122 () As System.Int32
		Get
			Return _QCG122
		End Get
		Set(Byval value as System.Int32)
			_QCG122 = value
		End Set
	End Property
#End Region
#Region "Y.S KG/MM¬2 屬性:QCG112"
	Private _QCG112 As System.Int32
	''' <summary>
	''' Y.S KG/MM¬2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG112 () As System.Int32
		Get
			Return _QCG112
		End Get
		Set(Byval value as System.Int32)
			_QCG112 = value
		End Set
	End Property
#End Region
#Region "ELONGATION % 屬性:QCG132"
	Private _QCG132 As System.Single
	''' <summary>
	''' ELONGATION %
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG132 () As System.Single
		Get
			Return _QCG132
		End Get
		Set(Byval value as System.Single)
			_QCG132 = value
		End Set
	End Property
#End Region
#Region "HRB 屬性:QCG142"
	Private _QCG142 As System.Single
	''' <summary>
	''' HRB
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG142 () As System.Single
		Get
			Return _QCG142
		End Get
		Set(Byval value as System.Single)
			_QCG142 = value
		End Set
	End Property
#End Region
#Region "HRC 屬性:QCG212"
	Private _QCG212 As System.Single
	''' <summary>
	''' HRC
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG212 () As System.Single
		Get
			Return _QCG212
		End Get
		Set(Byval value as System.Single)
			_QCG212 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:C 屬性:QCA073"
	Private _QCA073 As System.Single
	''' <summary>
	''' ELEMENT:C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA073 () As System.Single
		Get
			Return _QCA073
		End Get
		Set(Byval value as System.Single)
			_QCA073 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:SI 屬性:QCA083"
	Private _QCA083 As System.Single
	''' <summary>
	''' ELEMENT:SI
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA083 () As System.Single
		Get
			Return _QCA083
		End Get
		Set(Byval value as System.Single)
			_QCA083 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:MN 屬性:QCA093"
	Private _QCA093 As System.Single
	''' <summary>
	''' ELEMENT:MN
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA093 () As System.Single
		Get
			Return _QCA093
		End Get
		Set(Byval value as System.Single)
			_QCA093 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:P 屬性:QCA103"
	Private _QCA103 As System.Single
	''' <summary>
	''' ELEMENT:P
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA103 () As System.Single
		Get
			Return _QCA103
		End Get
		Set(Byval value as System.Single)
			_QCA103 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:S 屬性:QCA113"
	Private _QCA113 As System.Single
	''' <summary>
	''' ELEMENT:S
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA113 () As System.Single
		Get
			Return _QCA113
		End Get
		Set(Byval value as System.Single)
			_QCA113 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:CR 屬性:QCA123"
	Private _QCA123 As System.Single
	''' <summary>
	''' ELEMENT:CR
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA123 () As System.Single
		Get
			Return _QCA123
		End Get
		Set(Byval value as System.Single)
			_QCA123 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:NI 屬性:QCA133"
	Private _QCA133 As System.Single
	''' <summary>
	''' ELEMENT:NI
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA133 () As System.Single
		Get
			Return _QCA133
		End Get
		Set(Byval value as System.Single)
			_QCA133 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:MO 屬性:QCA153"
	Private _QCA153 As System.Single
	''' <summary>
	''' ELEMENT:MO
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA153 () As System.Single
		Get
			Return _QCA153
		End Get
		Set(Byval value as System.Single)
			_QCA153 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:N2 屬性:QCA253"
	Private _QCA253 As System.Single
	''' <summary>
	''' ELEMENT:N2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA253 () As System.Single
		Get
			Return _QCA253
		End Get
		Set(Byval value as System.Single)
			_QCA253 = value
		End Set
	End Property
#End Region
#Region "T.S KG/MM¬2 屬性:QCG123"
	Private _QCG123 As System.Int32
	''' <summary>
	''' T.S KG/MM¬2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG123 () As System.Int32
		Get
			Return _QCG123
		End Get
		Set(Byval value as System.Int32)
			_QCG123 = value
		End Set
	End Property
#End Region
#Region "Y.S KG/MM¬2 屬性:QCG113"
	Private _QCG113 As System.Int32
	''' <summary>
	''' Y.S KG/MM¬2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG113 () As System.Int32
		Get
			Return _QCG113
		End Get
		Set(Byval value as System.Int32)
			_QCG113 = value
		End Set
	End Property
#End Region
#Region "ELONGATION % 屬性:QCG133"
	Private _QCG133 As System.Single
	''' <summary>
	''' ELONGATION %
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG133 () As System.Single
		Get
			Return _QCG133
		End Get
		Set(Byval value as System.Single)
			_QCG133 = value
		End Set
	End Property
#End Region
#Region "HRB 屬性:QCG143"
	Private _QCG143 As System.Single
	''' <summary>
	''' HRB
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG143 () As System.Single
		Get
			Return _QCG143
		End Get
		Set(Byval value as System.Single)
			_QCG143 = value
		End Set
	End Property
#End Region
#Region "HRC 屬性:QCG213"
	Private _QCG213 As System.Single
	''' <summary>
	''' HRC
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG213 () As System.Single
		Get
			Return _QCG213
		End Get
		Set(Byval value as System.Single)
			_QCG213 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:C 屬性:QCA074"
	Private _QCA074 As System.Single
	''' <summary>
	''' ELEMENT:C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA074 () As System.Single
		Get
			Return _QCA074
		End Get
		Set(Byval value as System.Single)
			_QCA074 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:SI 屬性:QCA084"
	Private _QCA084 As System.Single
	''' <summary>
	''' ELEMENT:SI
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA084 () As System.Single
		Get
			Return _QCA084
		End Get
		Set(Byval value as System.Single)
			_QCA084 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:MN 屬性:QCA094"
	Private _QCA094 As System.Single
	''' <summary>
	''' ELEMENT:MN
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA094 () As System.Single
		Get
			Return _QCA094
		End Get
		Set(Byval value as System.Single)
			_QCA094 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:P 屬性:QCA104"
	Private _QCA104 As System.Single
	''' <summary>
	''' ELEMENT:P
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA104 () As System.Single
		Get
			Return _QCA104
		End Get
		Set(Byval value as System.Single)
			_QCA104 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:S 屬性:QCA114"
	Private _QCA114 As System.Single
	''' <summary>
	''' ELEMENT:S
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA114 () As System.Single
		Get
			Return _QCA114
		End Get
		Set(Byval value as System.Single)
			_QCA114 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:CR 屬性:QCA124"
	Private _QCA124 As System.Single
	''' <summary>
	''' ELEMENT:CR
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA124 () As System.Single
		Get
			Return _QCA124
		End Get
		Set(Byval value as System.Single)
			_QCA124 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:NI 屬性:QCA134"
	Private _QCA134 As System.Single
	''' <summary>
	''' ELEMENT:NI
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA134 () As System.Single
		Get
			Return _QCA134
		End Get
		Set(Byval value as System.Single)
			_QCA134 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:MO 屬性:QCA154"
	Private _QCA154 As System.Single
	''' <summary>
	''' ELEMENT:MO
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA154 () As System.Single
		Get
			Return _QCA154
		End Get
		Set(Byval value as System.Single)
			_QCA154 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:N2 屬性:QCA254"
	Private _QCA254 As System.Single
	''' <summary>
	''' ELEMENT:N2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA254 () As System.Single
		Get
			Return _QCA254
		End Get
		Set(Byval value as System.Single)
			_QCA254 = value
		End Set
	End Property
#End Region
#Region "T.S KG/MM¬2 屬性:QCG124"
	Private _QCG124 As System.Int32
	''' <summary>
	''' T.S KG/MM¬2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG124 () As System.Int32
		Get
			Return _QCG124
		End Get
		Set(Byval value as System.Int32)
			_QCG124 = value
		End Set
	End Property
#End Region
#Region "Y.S KG/MM¬2 屬性:QCG114"
	Private _QCG114 As System.Int32
	''' <summary>
	''' Y.S KG/MM¬2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG114 () As System.Int32
		Get
			Return _QCG114
		End Get
		Set(Byval value as System.Int32)
			_QCG114 = value
		End Set
	End Property
#End Region
#Region "ELONGATION % 屬性:QCG134"
	Private _QCG134 As System.Single
	''' <summary>
	''' ELONGATION %
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG134 () As System.Single
		Get
			Return _QCG134
		End Get
		Set(Byval value as System.Single)
			_QCG134 = value
		End Set
	End Property
#End Region
#Region "HRB 屬性:QCG144"
	Private _QCG144 As System.Single
	''' <summary>
	''' HRB
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG144 () As System.Single
		Get
			Return _QCG144
		End Get
		Set(Byval value as System.Single)
			_QCG144 = value
		End Set
	End Property
#End Region
#Region "HRC 屬性:QCG214"
	Private _QCG214 As System.Single
	''' <summary>
	''' HRC
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG214 () As System.Single
		Get
			Return _QCG214
		End Get
		Set(Byval value as System.Single)
			_QCG214 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:C 屬性:QCA075"
	Private _QCA075 As System.Single
	''' <summary>
	''' ELEMENT:C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA075 () As System.Single
		Get
			Return _QCA075
		End Get
		Set(Byval value as System.Single)
			_QCA075 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:SI 屬性:QCA085"
	Private _QCA085 As System.Single
	''' <summary>
	''' ELEMENT:SI
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA085 () As System.Single
		Get
			Return _QCA085
		End Get
		Set(Byval value as System.Single)
			_QCA085 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:MN 屬性:QCA095"
	Private _QCA095 As System.Single
	''' <summary>
	''' ELEMENT:MN
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA095 () As System.Single
		Get
			Return _QCA095
		End Get
		Set(Byval value as System.Single)
			_QCA095 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:P 屬性:QCA105"
	Private _QCA105 As System.Single
	''' <summary>
	''' ELEMENT:P
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA105 () As System.Single
		Get
			Return _QCA105
		End Get
		Set(Byval value as System.Single)
			_QCA105 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:S 屬性:QCA115"
	Private _QCA115 As System.Single
	''' <summary>
	''' ELEMENT:S
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA115 () As System.Single
		Get
			Return _QCA115
		End Get
		Set(Byval value as System.Single)
			_QCA115 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:CR 屬性:QCA125"
	Private _QCA125 As System.Single
	''' <summary>
	''' ELEMENT:CR
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA125 () As System.Single
		Get
			Return _QCA125
		End Get
		Set(Byval value as System.Single)
			_QCA125 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:NI 屬性:QCA135"
	Private _QCA135 As System.Single
	''' <summary>
	''' ELEMENT:NI
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA135 () As System.Single
		Get
			Return _QCA135
		End Get
		Set(Byval value as System.Single)
			_QCA135 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:MO 屬性:QCA155"
	Private _QCA155 As System.Single
	''' <summary>
	''' ELEMENT:MO
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA155 () As System.Single
		Get
			Return _QCA155
		End Get
		Set(Byval value as System.Single)
			_QCA155 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:N2 屬性:QCA255"
	Private _QCA255 As System.Single
	''' <summary>
	''' ELEMENT:N2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA255 () As System.Single
		Get
			Return _QCA255
		End Get
		Set(Byval value as System.Single)
			_QCA255 = value
		End Set
	End Property
#End Region
#Region "T.S KG/MM¬2 屬性:QCG125"
	Private _QCG125 As System.Int32
	''' <summary>
	''' T.S KG/MM¬2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG125 () As System.Int32
		Get
			Return _QCG125
		End Get
		Set(Byval value as System.Int32)
			_QCG125 = value
		End Set
	End Property
#End Region
#Region "Y.S KG/MM¬2 屬性:QCG115"
	Private _QCG115 As System.Int32
	''' <summary>
	''' Y.S KG/MM¬2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG115 () As System.Int32
		Get
			Return _QCG115
		End Get
		Set(Byval value as System.Int32)
			_QCG115 = value
		End Set
	End Property
#End Region
#Region "ELONGATION % 屬性:QCG135"
	Private _QCG135 As System.Single
	''' <summary>
	''' ELONGATION %
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG135 () As System.Single
		Get
			Return _QCG135
		End Get
		Set(Byval value as System.Single)
			_QCG135 = value
		End Set
	End Property
#End Region
#Region "HRB 屬性:QCG145"
	Private _QCG145 As System.Single
	''' <summary>
	''' HRB
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG145 () As System.Single
		Get
			Return _QCG145
		End Get
		Set(Byval value as System.Single)
			_QCG145 = value
		End Set
	End Property
#End Region
#Region "HRC 屬性:QCG215"
	Private _QCG215 As System.Single
	''' <summary>
	''' HRC
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG215 () As System.Single
		Get
			Return _QCG215
		End Get
		Set(Byval value as System.Single)
			_QCG215 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:C 屬性:QCA076"
	Private _QCA076 As System.Single
	''' <summary>
	''' ELEMENT:C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA076 () As System.Single
		Get
			Return _QCA076
		End Get
		Set(Byval value as System.Single)
			_QCA076 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:SI 屬性:QCA086"
	Private _QCA086 As System.Single
	''' <summary>
	''' ELEMENT:SI
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA086 () As System.Single
		Get
			Return _QCA086
		End Get
		Set(Byval value as System.Single)
			_QCA086 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:MN 屬性:QCA096"
	Private _QCA096 As System.Single
	''' <summary>
	''' ELEMENT:MN
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA096 () As System.Single
		Get
			Return _QCA096
		End Get
		Set(Byval value as System.Single)
			_QCA096 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:P 屬性:QCA106"
	Private _QCA106 As System.Single
	''' <summary>
	''' ELEMENT:P
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA106 () As System.Single
		Get
			Return _QCA106
		End Get
		Set(Byval value as System.Single)
			_QCA106 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:S 屬性:QCA116"
	Private _QCA116 As System.Single
	''' <summary>
	''' ELEMENT:S
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA116 () As System.Single
		Get
			Return _QCA116
		End Get
		Set(Byval value as System.Single)
			_QCA116 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:CR 屬性:QCA126"
	Private _QCA126 As System.Single
	''' <summary>
	''' ELEMENT:CR
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA126 () As System.Single
		Get
			Return _QCA126
		End Get
		Set(Byval value as System.Single)
			_QCA126 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:NI 屬性:QCA136"
	Private _QCA136 As System.Single
	''' <summary>
	''' ELEMENT:NI
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA136 () As System.Single
		Get
			Return _QCA136
		End Get
		Set(Byval value as System.Single)
			_QCA136 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:MO 屬性:QCA156"
	Private _QCA156 As System.Single
	''' <summary>
	''' ELEMENT:MO
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA156 () As System.Single
		Get
			Return _QCA156
		End Get
		Set(Byval value as System.Single)
			_QCA156 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:N2 屬性:QCA256"
	Private _QCA256 As System.Single
	''' <summary>
	''' ELEMENT:N2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA256 () As System.Single
		Get
			Return _QCA256
		End Get
		Set(Byval value as System.Single)
			_QCA256 = value
		End Set
	End Property
#End Region
#Region "T.S KG/MM¬2 屬性:QCG126"
	Private _QCG126 As System.Int32
	''' <summary>
	''' T.S KG/MM¬2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG126 () As System.Int32
		Get
			Return _QCG126
		End Get
		Set(Byval value as System.Int32)
			_QCG126 = value
		End Set
	End Property
#End Region
#Region "Y.S KG/MM¬2 屬性:QCG116"
	Private _QCG116 As System.Int32
	''' <summary>
	''' Y.S KG/MM¬2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG116 () As System.Int32
		Get
			Return _QCG116
		End Get
		Set(Byval value as System.Int32)
			_QCG116 = value
		End Set
	End Property
#End Region
#Region "ELONGATION % 屬性:QCG136"
	Private _QCG136 As System.Single
	''' <summary>
	''' ELONGATION %
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG136 () As System.Single
		Get
			Return _QCG136
		End Get
		Set(Byval value as System.Single)
			_QCG136 = value
		End Set
	End Property
#End Region
#Region "HRB 屬性:QCG146"
	Private _QCG146 As System.Single
	''' <summary>
	''' HRB
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG146 () As System.Single
		Get
			Return _QCG146
		End Get
		Set(Byval value as System.Single)
			_QCG146 = value
		End Set
	End Property
#End Region
#Region "HRC 屬性:QCG216"
	Private _QCG216 As System.Single
	''' <summary>
	''' HRC
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG216 () As System.Single
		Get
			Return _QCG216
		End Get
		Set(Byval value as System.Single)
			_QCG216 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:CU 屬性:QCA140"
	Private _QCA140 As System.Single
	''' <summary>
	''' ELEMENT:CU
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA140 () As System.Single
		Get
			Return _QCA140
		End Get
		Set(Byval value as System.Single)
			_QCA140 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:CU 屬性:QCA141"
	Private _QCA141 As System.Single
	''' <summary>
	''' ELEMENT:CU
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA141 () As System.Single
		Get
			Return _QCA141
		End Get
		Set(Byval value as System.Single)
			_QCA141 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:CU 屬性:QCA142"
	Private _QCA142 As System.Single
	''' <summary>
	''' ELEMENT:CU
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA142 () As System.Single
		Get
			Return _QCA142
		End Get
		Set(Byval value as System.Single)
			_QCA142 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:CU 屬性:QCA143"
	Private _QCA143 As System.Single
	''' <summary>
	''' ELEMENT:CU
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA143 () As System.Single
		Get
			Return _QCA143
		End Get
		Set(Byval value as System.Single)
			_QCA143 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:CU 屬性:QCA144"
	Private _QCA144 As System.Single
	''' <summary>
	''' ELEMENT:CU
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA144 () As System.Single
		Get
			Return _QCA144
		End Get
		Set(Byval value as System.Single)
			_QCA144 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:CU 屬性:QCA145"
	Private _QCA145 As System.Single
	''' <summary>
	''' ELEMENT:CU
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA145 () As System.Single
		Get
			Return _QCA145
		End Get
		Set(Byval value as System.Single)
			_QCA145 = value
		End Set
	End Property
#End Region
#Region "ELEMENT:CU 屬性:QCA146"
	Private _QCA146 As System.Single
	''' <summary>
	''' ELEMENT:CU
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCA146 () As System.Single
		Get
			Return _QCA146
		End Get
		Set(Byval value as System.Single)
			_QCA146 = value
		End Set
	End Property
#End Region
#Region "Rp1.0 屬性:QCG280"
        Private _QCG280 As System.Int32
        ''' <summary>
        ''' Rp1.0
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCG280() As System.Int32
            Get
                Return _QCG280
            End Get
            Set(ByVal value As System.Int32)
                _QCG280 = value
            End Set
        End Property
#End Region
#Region "Rp1.0 屬性:QCG281"
        Private _QCG281 As System.Int32
        ''' <summary>
        ''' Rp1.0
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCG281() As System.Int32
            Get
                Return _QCG281
            End Get
            Set(ByVal value As System.Int32)
                _QCG281 = value
            End Set
        End Property
#End Region
#Region "Rp1.0 屬性:QCG282"
        Private _QCG282 As System.Int32
        ''' <summary>
        ''' Rp1.0
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCG282() As System.Int32
            Get
                Return _QCG282
            End Get
            Set(ByVal value As System.Int32)
                _QCG282 = value
            End Set
        End Property
#End Region
#Region "Rp1.0 屬性:QCG283"
        Private _QCG283 As System.Int32
        ''' <summary>
        ''' Rp1.0
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCG283() As System.Int32
            Get
                Return _QCG283
            End Get
            Set(ByVal value As System.Int32)
                _QCG283 = value
            End Set
        End Property
#End Region
#Region "Rp1.0 屬性:QCG284"
        Private _QCG284 As System.Int32
        ''' <summary>
        ''' Rp1.0
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCG284() As System.Int32
            Get
                Return _QCG284
            End Get
            Set(ByVal value As System.Int32)
                _QCG284 = value
            End Set
        End Property
#End Region
#Region "Rp1.0 屬性:QCG285"
        Private _QCG285 As System.Int32
        ''' <summary>
        ''' Rp1.0
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCG285() As System.Int32
            Get
                Return _QCG285
            End Get
            Set(ByVal value As System.Int32)
                _QCG285 = value
            End Set
        End Property
#End Region
#Region "Rp1.0 屬性:QCG286"
        Private _QCG286 As System.Int32
        ''' <summary>
        ''' Rp1.0
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCG286() As System.Int32
            Get
                Return _QCG286
            End Get
            Set(ByVal value As System.Int32)
                _QCG286 = value
            End Set
        End Property
#End Region


#Region "相關客戶  屬性:AboutSL2CUAPF"
        Private _AboutSL2CUAPF As SLS300LB.SL2CUAPF = Nothing
        ''' <summary>
        ''' 相關客戶
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutSL2CUAPF() As SLS300LB.SL2CUAPF
            Get
                If IsNothing(_AboutSL2CUAPF) Then
                    Dim GetValues As List(Of SLS300LB.SL2CUAPF) = SLS300LB.SL2CUAPF.CDBSelect(Of SLS300LB.SL2CUAPF)("Select * from " & (New SLS300LB.SL2CUAPF).CDBFullAS400DBPath & " Where cua01='" & Me.QCD02.Substring(0, 3) & "'", Me.CDBCurrentUseSQLQueryAdapter)
                    If GetValues.Count > 0 Then
                        _AboutSL2CUAPF = GetValues(0)
                    End If
                End If
                Return _AboutSL2CUAPF
            End Get
        End Property
#End Region

#Region "取得記錄欄位值 方法:GetRecordFieldValue "
        ''' <summary>
        ''' 取得記錄欄位值
        ''' </summary>
        ''' <param name="FieldName">欄位名稱</param>
        ''' <param name="RecordIndex">1~7</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetRecordFieldValue(ByVal FieldName As RecordFieldNameEnum, ByVal RecordIndex As Integer) As Object
            If RecordIndex < 0 OrElse RecordIndex > 7 Then
                Return Nothing
            End If
            If FieldName = RecordFieldNameEnum.GRADE OrElse FieldName = RecordFieldNameEnum.FINISH Then
            End If
            Select Case True
                Case FieldName = RecordFieldNameEnum.GRADE OrElse FieldName = RecordFieldNameEnum.FINISH
                    Return Me.CDBGetFieldValue("QCD" & Format(FieldName + ((RecordIndex - 1) * 10), "00X"))
                Case FieldName = RecordFieldNameEnum.SIZE OrElse FieldName = RecordFieldNameEnum.QUANTITY OrElse _
                    FieldName = RecordFieldNameEnum.UNIT OrElse FieldName = RecordFieldNameEnum.WEIGHT OrElse _
                    FieldName = RecordFieldNameEnum.WT_UNIT OrElse FieldName = RecordFieldNameEnum.HEAT_NO OrElse _
                    FieldName = RecordFieldNameEnum.COIL_NO OrElse FieldName = RecordFieldNameEnum.BREAK_NO
                    Return Me.CDBGetFieldValue("QCD" & Format(FieldName + ((RecordIndex - 1) * 10), "00"))
                Case FieldName = RecordFieldNameEnum.ElementC OrElse FieldName = RecordFieldNameEnum.ElementSi OrElse _
                    FieldName = RecordFieldNameEnum.ElementMN OrElse FieldName = RecordFieldNameEnum.ElementP OrElse _
                    FieldName = RecordFieldNameEnum.ElementS OrElse FieldName = RecordFieldNameEnum.ElementCR OrElse _
                    FieldName = RecordFieldNameEnum.ElementNI OrElse FieldName = RecordFieldNameEnum.ElementMO OrElse _
                    FieldName = RecordFieldNameEnum.ElementN
                    Return Me.CDBGetFieldValue("QCA" & Format((FieldName + (RecordIndex - 1)) Mod 1000, "000"))
                Case FieldName = RecordFieldNameEnum.ElementTS OrElse FieldName = RecordFieldNameEnum.ElementYS OrElse _
                    FieldName = RecordFieldNameEnum.ELONGATION OrElse FieldName = RecordFieldNameEnum.HRB OrElse _
                    FieldName = RecordFieldNameEnum.HRC
                    Return Me.CDBGetFieldValue("QCG" & Format(FieldName Mod 2000 + (RecordIndex - 1), "000"))
                Case FieldName = RecordFieldNameEnum.ElementCU
                    Return Me.CDBGetFieldValue("QCA" & Format(FieldName Mod 3000 + (RecordIndex - 1), "000"))
                Case FieldName = RecordFieldNameEnum.RP
                    Return Me.CDBGetFieldValue("QCG" & Format(FieldName Mod 3000 + (RecordIndex - 1), "000"))
            End Select
            Return Nothing
        End Function

        Public Enum RecordFieldNameEnum
            SIZE = 7
            GRADE = 8
            FINISH = 9
            QUANTITY = 10
            UNIT = 11
            WEIGHT = 12
            WT_UNIT = 13
            HEAT_NO = 14
            COIL_NO = 15
            BREAK_NO = 16
            ElementC = 1070
            ElementSi = 1080
            ElementMN = 1090
            ElementP = 1100
            ElementS = 1110
            ElementCR = 1120
            ElementNI = 1130
            ElementMO = 1150
            ElementN = 1250
            ElementTS = 2120
            ElementYS = 2110
            ELONGATION = 2130
            HRB = 2140
            HRC = 2210
            ElementCU = 3140
            RP = 3280
        End Enum

#End Region
#Region "取得XML品證欄位值 方法:GetXMLInspectionMakerFieldValue"
        Private Function GetXMLInspectionMakerFieldValue(ByVal InspectionField As InspectionMakerFieldEnum, ByVal RecordIndex As Integer) As String
            'For i = 12 To 18
            '    If (Cells(i, 1) <= 0) Then Exit For
            '    'XMLstring = XMLstring & "<Detail>" & vbCrLf
            '    'XMLstring = XMLstring & "<Item>" & Cells(i, 1) & "</Item>" & vbCrLf
            '    'XMLstring = XMLstring & "<ProductID>" & Cells(i, 2) & "</ProductID>" & vbCrLf
            '    'XMLstring = XMLstring & "<HeatNo>" & Cells(i, 4) & "</HeatNo>" & vbCrLf
            '    'XMLstring = XMLstring & "<ProductFrom>" & Cells(i, 6) & "</ProductFrom>" & vbCrLf
            '    'XMLstring = XMLstring & "<SteelGrade>" & Cells(i, 7) & "</SteelGrade>" & vbCrLf
            '    'XMLstring = XMLstring & "<Finish>" & Cells(i, 8) & "</Finish>" & vbCrLf
            '    'XMLstring = XMLstring & "<Category>" & Cells(i, 9) & "</Category>" & vbCrLf
            '    'XMLstring = XMLstring & "<ProductFitted>" & Cells(i, 10) & "</ProductFitted>" & vbCrLf
            '    'XMLstring = XMLstring & "<NetWeight>" & Cells(i, 14) & " " & Cells(i, 15) & "</NetWeight>" & vbCrLf
            '    XMLstring = XMLstring & "<Specification>" & Cells(i, 16) & "</Specification>" & vbCrLf
            '    XMLstring = XMLstring & "<C>" & Cells(i + 11, 2) & "</C>" & vbCrLf
            '    XMLstring = XMLstring & "<Si>" & Cells(i + 11, 3) & "</Si>" & vbCrLf
            '    XMLstring = XMLstring & "<Mn>" & Cells(i + 11, 4) & "</Mn>" & vbCrLf
            '    XMLstring = XMLstring & "<P>" & Cells(i + 11, 5) & "</P>" & vbCrLf
            '    XMLstring = XMLstring & "<S>" & Cells(i + 11, 6) & "</S>" & vbCrLf
            '    XMLstring = XMLstring & "<Cr>" & Cells(i + 11, 7) & "</Cr>" & vbCrLf
            '    XMLstring = XMLstring & "<Ni>" & Cells(i + 11, 8) & "</Ni>" & vbCrLf
            '    XMLstring = XMLstring & "<N>" & Cells(i + 11, 9) & "</N>" & vbCrLf
            '    If (Cells(i + 11, 10) = "--") Then XMLstring = XMLstring & "<Cu></Cu>" Else XMLstring = XMLstring & "<Cu>" & Cells(i + 11, 10) & "</Cu>" & vbCrLf
            '    XMLstring = XMLstring & "<TS>" & Cells(i + 11, 12) & "</TS>" & vbCrLf
            '    XMLstring = XMLstring & "<YS>" & Cells(i + 11, 13) & "</YS>" & vbCrLf
            '    XMLstring = XMLstring & "<Elong>" & Cells(i + 11, 14) & "</Elong>" & vbCrLf
            '    If (Cells(i + 11, 15) = "--") Then XMLstring = XMLstring & "<HRB></HRB>" Else XMLstring = XMLstring & "<HRB>" & Cells(i + 11, 15) & "</HRB>" & vbCrLf
            '    If (Cells(i + 11, 16) = "--") Then XMLstring = XMLstring & "<HV></HV>" Else XMLstring = XMLstring & "<HV>" & Cells(i + 11, 16) & "</HV>" & vbCrLf
            '    ' XMLstring = XMLstring & "<HRC>" & Cells(i + 11, 17) & "</HRC>"
            '    XMLstring = XMLstring & "</Detail>" & vbCrLf
            'Next i

            If RecordIndex < 0 OrElse RecordIndex > 7 Then
                Return Nothing
            End If
            Select Case InspectionField
                Case InspectionMakerFieldEnum.Item  'A
                    Return InspectionField
                Case InspectionMakerFieldEnum.ProductID 'B
                    Dim CoilNumber As String = CType(GetRecordFieldValue(RecordFieldNameEnum.COIL_NO, RecordIndex), String)
                    Dim CoilBreak As String = CType(GetRecordFieldValue(RecordFieldNameEnum.BREAK_NO, RecordIndex), String).Trim
                    Return IIf(CoilBreak.Length = 0, CoilNumber, CoilNumber & "-" & CoilBreak)
                Case InspectionMakerFieldEnum.HeatNo    'D
                    Return CType(GetRecordFieldValue(RecordFieldNameEnum.HEAT_NO, RecordIndex), String)
                Case InspectionMakerFieldEnum.ProductFrom   'F
                    Return Left(Me.QCD05.PadRight(4), 4)
                Case InspectionMakerFieldEnum.SteelGrade    'G
                    If Me.QCD08X.Substring(0, 1) = "T" OrElse Me.QCD08X.Trim.Length <= 4 Then
                        Return Me.QCD08X
                    End If
                    Return Me.QCD08X.Substring(0, 4) & "-" & Me.QCD08X.PadRight(7).Substring(4, 3).Trim
                Case InspectionMakerFieldEnum.Finish    'H
                    Dim ReturnValue As String = Nothing
                    Select Case True
                        Case Me.QCD05.Substring(0, 3) = "BHR"
                            ReturnValue = "Black"
                        Case CType(GetRecordFieldValue(RecordFieldNameEnum.COIL_NO, RecordIndex), String) = "04536"
                            ReturnValue = "NO1-GP"
                        Case Else
                            ReturnValue = CType(GetRecordFieldValue(RecordFieldNameEnum.FINISH, RecordIndex), String).Trim
                    End Select

                    '硬片名稱轉換
                    Dim FinishString As String = GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.Finish, RecordIndex)
                    Dim SteelGradeString As String = GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.SteelGrade, RecordIndex)
                    If SteelGradeString.PadRight(2).Substring(0, 2) <> "TP" And _
                        SteelGradeString.PadRight(3).Substring(0, 3) <> "316" And _
                         (FinishString.Substring(0, 1) = "H" OrElse FinishString.Substring(0, 2) = "SH" OrElse FinishString.Substring(0, 2) = "EH") Then
                        If GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.SteelGrade, RecordIndex).Substring(0, 1) = "2" Then
                            ReturnValue = "SH"   '200系鋼種一律顥示'SH'
                        Else
                            If Not String.IsNullOrEmpty(FinishString) AndAlso FinishString.Substring(1, 1) <> "H" Then
                                If FinishString.Substring(2, 1) = "H" Then
                                    ReturnValue = ReturnValue.Substring(1, 1) & "/16H"
                                Else
                                    ReturnValue = ReturnValue.Substring(1, 1) & "/" & ReturnValue.Substring(2, 1) & "H"
                                End If
                            End If
                        End If
                    End If
                    Return ReturnValue
                Case InspectionMakerFieldEnum.Category  'I
                    Dim ReturnValue As String = Nothing
                    If GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.SteelGrade, RecordIndex).PadRight(4).Substring(0, 4) = "301L" & _
                       GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.Finish, RecordIndex) <> "SH" Then   '台灣車輛
                        ReturnValue = "LT"
                    Else
                        ReturnValue = CType(GetRecordFieldValue(RecordFieldNameEnum.UNIT, RecordIndex), String)
                    End If
                    ReturnValue = IIf(Me.QCD78 = "E" OrElse Me.QCD78 = "O", "X" & ReturnValue, ReturnValue)
                    Return ReturnValue
                Case InspectionMakerFieldEnum.ProductFitted 'J
                    Return CType(GetRecordFieldValue(RecordFieldNameEnum.SIZE, RecordIndex), String)
                Case InspectionMakerFieldEnum.NetWeight 'N
                    Return CType(GetRecordFieldValue(RecordFieldNameEnum.WEIGHT, RecordIndex), String)
                Case InspectionMakerFieldEnum.Specification 'P
                    Dim ReturnValue As String
                    Dim SteelGradeString As String = GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.SteelGrade, RecordIndex)
                    Select Case True
                        Case SteelGradeString.Substring(0, 2) = "TP"
                            ReturnValue = "ASTM A312"
                        Case SteelGradeString = "316"
                            ReturnValue = "ASTM A240-08"
                        Case Else
                            ReturnValue = Me.QCD0D  '標準規格
                            Dim FinishString As String = GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.Finish, RecordIndex)
                            If FinishString.Substring(0, 1) = "H" OrElse FinishString.Substring(0, 2) = "SH" OrElse FinishString.Substring(0, 2) = "EH" Then
                                If Me.QCD78.Substring(0, 1) = "E" OrElse Me.QCD78.Substring(0, 1) = "O" Then
                                    ReturnValue = "JIS G4313-96"
                                Else
                                    ReturnValue = "CNS 8399-98"
                                End If
                            Else
                                Dim SpecificationString = GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.Specification, RecordIndex)
                                If SpecificationString.PadLeft(3).Substring(0, 3) = "CNS" Then
                                    ReturnValue = SpecificationString & "-05"
                                Else
                                    ReturnValue = SpecificationString & "-08"
                                End If
                            End If
                    End Select
                    ReturnValue = IIf(GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.SteelGrade, RecordIndex).PadLeft(4).Substring(0, 4) = "301L", "ASTM A240-8", ReturnValue)
                    'TE特殊鋼捲
                    ReturnValue = IIf(GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.SteelGrade, RecordIndex).PadLeft(2).Substring(0, 2) = "TE", "", ReturnValue)
                    Return ReturnValue
                Case InspectionMakerFieldEnum.C

                Case InspectionMakerFieldEnum.Si
                Case InspectionMakerFieldEnum.Mn
                Case InspectionMakerFieldEnum.P
                Case InspectionMakerFieldEnum.S
                Case InspectionMakerFieldEnum.Cr
                Case InspectionMakerFieldEnum.Ni
                Case InspectionMakerFieldEnum.N
                Case InspectionMakerFieldEnum.Cu
                Case InspectionMakerFieldEnum.TS
                Case InspectionMakerFieldEnum.YS
                Case InspectionMakerFieldEnum.Elong
                Case InspectionMakerFieldEnum.HRB
                Case InspectionMakerFieldEnum.HV
                Case InspectionMakerFieldEnum.HRC
            End Select

            '未完成
            Return Nothing
        End Function

        Public Enum InspectionMakerFieldEnum
            Item = 1
            ProductID = 2
            HeatNo = 3
            ProductFrom = 4
            SteelGrade = 5
            Finish = 6
            Category = 7
            ProductFitted = 8
            NetWeight = 9
            Specification = 10
            C = 11
            Si = 12
            Mn = 13
            P = 14
            S = 15
            Cr = 16
            Ni = 17
            N = 18
            Cu = 19
            TS = 20
            YS = 21
            Elong = 22
            HRB = 23
            HV = 24
            HRC = 25
        End Enum
#End Region

#Region "XMLInspection產生 方法:XMLInspectionMaker"
        ''' <summary>
        ''' XMLInspection產生
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function XMLInspectionMaker() As String
            Dim XMLstring As String
            If IsNothing(AboutSL2CUAPF) Then
                Throw New Exception("無法取得客戶資料!(" & Me.QCD02.Substring(0, 3) & ")")
            End If
            XMLstring = "<Inspection>" & vbCrLf
            ' 注意讀取客戶統編
            XMLstring = XMLstring & "<Ban>" & AboutSL2CUAPF.CUA03 & "</Ban>" & vbCrLf
            ' -----------------
            XMLstring = XMLstring & "<Customer>" & Me.QCD0C & "</Customer>" & vbCrLf
            XMLstring = XMLstring & "<ContractNo>" & Me.QCD03 & "</ContractNo>" & vbCrLf
            ' 注意問題
            XMLstring = XMLstring & "<LcNo>" & Me.QCD04 & "</LcNo>" & vbCrLf
            XMLstring = XMLstring & "<CertificateNo>" & Me.QCD01 & "</CertificateNo>" & vbCrLf
            XMLstring = XMLstring & "<SignMark>IT0149</SignMark>" & vbCrLf
            XMLstring = XMLstring & "<Remark>" & vbCrLf
            '' Remark = ""
            'For i = 31 To 39
            '    If (Trim(Cells(i, 2)) <> "") Then
            '        If (Trim(Cells(i, 1)) = "") Then
            '            XMLstring = XMLstring & Cells(i, 2) & "\r\n "
            '        Else
            '            XMLstring = XMLstring & Cells(i, 1) & Cells(i, 2) & "\r\n "
            '        End If
            '    End If
            'Next i
            XMLstring = XMLstring & "</Remark>"


            For DataRowCount As Integer = 1 To 7
                If CType(GetRecordFieldValue(RecordFieldNameEnum.WEIGHT, DataRowCount), Double) > 0 Then '判斷重量是否大於0
                    XMLstring = XMLstring & "<Detail>" & vbCrLf
                    XMLstring = XMLstring & "<Item>" & GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.Item, DataRowCount) & "</Item>" & vbCrLf
                    XMLstring = XMLstring & "<ProductID>" & GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.ProductID, DataRowCount) & "</ProductID>" & vbCrLf
                    XMLstring = XMLstring & "<HeatNo>" & GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.HeatNo, DataRowCount) & "</HeatNo>" & vbCrLf
                    XMLstring = XMLstring & "<ProductFrom>" & GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.ProductFrom, DataRowCount) & "</ProductFrom>" & vbCrLf
                    XMLstring = XMLstring & "<SteelGrade>" & GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.SteelGrade, DataRowCount) & "</SteelGrade>" & vbCrLf
                    XMLstring = XMLstring & "<Finish>" & GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.Finish, DataRowCount) & "</Finish>" & vbCrLf
                    XMLstring = XMLstring & "<Category>" & GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.Category, DataRowCount) & "</Category>" & vbCrLf
                    XMLstring = XMLstring & "<ProductFitted>" & GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.ProductFitted, DataRowCount) & "</ProductFitted>" & vbCrLf
                    XMLstring = XMLstring & "<NetWeight>" & GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.NetWeight, DataRowCount) & "</NetWeight>" & vbCrLf
                    XMLstring = XMLstring & "<Specification>" & GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.Specification, DataRowCount) & "</Specification>" & vbCrLf
                    XMLstring = XMLstring & "<C>" & GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.C, DataRowCount) & "</C>" & vbCrLf
                    XMLstring = XMLstring & "<Si>" & GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.Si, DataRowCount) & "</Si>" & vbCrLf
                    XMLstring = XMLstring & "<Mn>" & GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.Mn, DataRowCount) & "</Mn>" & vbCrLf
                    XMLstring = XMLstring & "<P>" & GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.P, DataRowCount) & "</P>" & vbCrLf
                    XMLstring = XMLstring & "<S>" & GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.S, DataRowCount) & "</S>" & vbCrLf
                    XMLstring = XMLstring & "<Cr>" & GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.Cr, DataRowCount) & "</Cr>" & vbCrLf
                    XMLstring = XMLstring & "<Ni>" & GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.Ni, DataRowCount) & "</Ni>" & vbCrLf
                    XMLstring = XMLstring & "<N>" & GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.N, DataRowCount) & "</N>" & vbCrLf
                    XMLstring = XMLstring & "<Cu>" & GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.Cu, DataRowCount) & "</Cu>" & vbCrLf
                    XMLstring = XMLstring & "<TS>" & GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.TS, DataRowCount) & "</TS>" & vbCrLf
                    XMLstring = XMLstring & "<YS>" & GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.YS, DataRowCount) & "</YS>" & vbCrLf
                    XMLstring = XMLstring & "<Elong>" & GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.Elong, DataRowCount) & "</Elong>" & vbCrLf
                    XMLstring = XMLstring & "<HRB>" & GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.HRB, DataRowCount) & "</HRB>" & vbCrLf
                    XMLstring = XMLstring & "<HV>" & GetXMLInspectionMakerFieldValue(InspectionMakerFieldEnum.HV, DataRowCount) & "</HV>" & vbCrLf
                    XMLstring = XMLstring & "</Detail>" & vbCrLf
                End If
            Next
            XMLstring = XMLstring & "</Inspection> " & vbCrLf
            Return XMLstring
        End Function
#End Region

#Region "檢驗細目 屬性:InspectionDetailItems"
        Private _InspectionDetailItems As List(Of DetailItemClass)
        ''' <summary>
        ''' 檢驗細目
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property InspectionDetailItems As List(Of DetailItemClass)
            Get
                If IsNothing(_InspectionDetailItems) Then
                    _InspectionDetailItems = New List(Of DetailItemClass)
                    Dim AddItem As DetailItemClass
                    For EachitemCount As Integer = 1 To 7
                        Dim CoilFirstNumber As String = GetRecordFieldValue(RecordFieldNameEnum.COIL_NO, EachitemCount)
                        If String.IsNullOrEmpty(CoilFirstNumber) OrElse CoilFirstNumber.Trim = "" Then
                            Continue For
                        End If
                        AddItem = New DetailItemClass
                        With AddItem
                            .OrderNumber = Me.QCD03
                            .ThisPageNumber = Me.QCD01
                            .CoilFullNumber = CoilFirstNumber & GetRecordFieldValue(RecordFieldNameEnum.BREAK_NO, EachitemCount)
                            .HeatNumber = GetRecordFieldValue(RecordFieldNameEnum.HEAT_NO, EachitemCount)
                            .ProductForm = Me.QCD05.PadRight(2).Substring(0, 2).Trim
                            Dim GetAboutPPSCIAPF As PPSCIAPF = .AboutPPSCIAPF
                            Dim GetAboutSL2Z01PF As SLS300LB.SL2Z01PF = .AboutSL2Z01PF

                            If Not IsNothing(GetAboutPPSCIAPF) Then
                                '一般鋼捲
                                .MaterialType = GetAboutPPSCIAPF.CIA34  '內外銷
                                If GetAboutPPSCIAPF.CIA61 <> "U" Then
                                    .MaterialType &= "B"    '修邊
                                Else
                                    .MaterialType &= " "    '毛邊
                                End If
                                .MaterialType &= GetAboutPPSCIAPF.CIA33     'PIPE

                            Else
                                '1041007 by renhsin 鋼胚
                                '------------------------------------------------------------------
                                'SLS300LB.SL2Z01PF檔無相關欄位：『內外銷』、『毛邊/修邊』、『PIPE』
                                'GetAboutPPSCIAPF
                                .MaterialType = ""
                                '------------------------------------------------------------------
                            End If
                            .FINISH = GetRecordFieldValue(RecordFieldNameEnum.FINISH, EachitemCount)
                            .GRADE = GetRecordFieldValue(RecordFieldNameEnum.GRADE, EachitemCount)
                            .SIZE = GetRecordFieldValue(RecordFieldNameEnum.SIZE, EachitemCount)
                            .Weight = GetRecordFieldValue(RecordFieldNameEnum.WEIGHT, EachitemCount)
                            .Specification = Me.QCD0D
                            .ElementC = GetRecordFieldValue(RecordFieldNameEnum.ElementC, EachitemCount)
                            .ElementSi = GetRecordFieldValue(RecordFieldNameEnum.ElementSi, EachitemCount)
                            .ElementMn = GetRecordFieldValue(RecordFieldNameEnum.ElementMN, EachitemCount)
                            .ElementP = GetRecordFieldValue(RecordFieldNameEnum.ElementP, EachitemCount)
                            .ElementS = GetRecordFieldValue(RecordFieldNameEnum.ElementS, EachitemCount)
                            .ElementCr = GetRecordFieldValue(RecordFieldNameEnum.ElementCR, EachitemCount)
                            .ElementNi = GetRecordFieldValue(RecordFieldNameEnum.ElementNI, EachitemCount)
                            .ElementN = GetRecordFieldValue(RecordFieldNameEnum.ElementN, EachitemCount)
                            .ElementCu = GetRecordFieldValue(RecordFieldNameEnum.ElementCU, EachitemCount)
                            .TS = GetRecordFieldValue(RecordFieldNameEnum.ElementTS, EachitemCount)
                            .YS = GetRecordFieldValue(RecordFieldNameEnum.ElementYS, EachitemCount)
                            .Elong = GetRecordFieldValue(RecordFieldNameEnum.ELONGATION, EachitemCount)
                            .HRB = GetRecordFieldValue(RecordFieldNameEnum.HRB, EachitemCount)
                            .Rp = GetRecordFieldValue(RecordFieldNameEnum.RP, EachitemCount)
                        End With
                        _InspectionDetailItems.Add(AddItem)
                    Next
                End If
                Return _InspectionDetailItems
            End Get
        End Property
#End Region

#Region "檢驗細目類別 屬性:DetailItemClass"
        Public Class DetailItemClass
            Property OrderNumber As String  '訂單編號
            Property ThisPageNumber As String '本單編號
            Property CoilFullNumber As String '鋼捲編號
            Property HeatNumber As String   '爐號
            Property ProductForm As String  '產品型態
            Property GRADE As String        '鋼種
            Property FINISH As String       '表面
            Property MaterialType As String  '料別
            Property SIZE As String         '產品尺寸 Thickness*Width*Length
            Property Weight As Double       '淨重
            Property Specification As String    '參照規範
            Property ElementC As Single     '成份
            Property ElementSi As Single     '成份
            Property ElementMn As Single     '成份
            Property ElementP As Single     '成份
            Property ElementS As Single     '成份
            Property ElementCr As Single     '成份
            Property ElementNi As Single     '成份
            Property ElementN As Single     '成份
            Property ElementCu As Single     '成份
            Property TS As Single           '抗拉強度
            Property YS As Single           '降伏強度
            Property Elong As Single        '伸長率
            Property HRB As Single          '硬度值
            Property Rp As Single           'RP值

#Region "相關成品繳庫檔 屬性:AboutPPSCIAPF(一般鋼捲) / AboutPPSCIAPF(鋼胚)"
            Private _AboutPPSCIAPF As PPS100LB.PPSCIAPF
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Property AboutPPSCIAPF As PPS100LB.PPSCIAPF
                Get
                    If IsNothing(_AboutPPSCIAPF) Then
                        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                        Dim GetValues As List(Of PPS100LB.PPSCIAPF) = SLS300LB.SL2CUAPF.CDBSelect(Of PPS100LB.PPSCIAPF)("SELECT * FROM @#PPS100LB.PPSCIAPF WHERE CIA02 || CIA03='" & CoilFullNumber & "' AND CIA04='" & OrderNumber & "'", Adapter)
                        If GetValues.Count > 0 Then
                            _AboutPPSCIAPF = GetValues(0)
                        End If
                    End If
                    Return _AboutPPSCIAPF
                End Get
                Set(value As PPS100LB.PPSCIAPF)
                    _AboutPPSCIAPF = value
                End Set
            End Property

            Private _AboutSL2Z01PF As SLS300LB.SL2Z01PF
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Property AboutSL2Z01PF As SLS300LB.SL2Z01PF
                Get
                    If IsNothing(_AboutSL2Z01PF) Then
                        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                        Dim GetValues As List(Of SLS300LB.SL2Z01PF) = SLS300LB.SL2Z01PF.CDBSelect(Of SLS300LB.SL2Z01PF)("SELECT * FROM @#SLS300LB.SL2Z01PF WHERE BLT01 || BLT02='" & CoilFullNumber & "' ", Adapter)
                        If GetValues.Count > 0 Then
                            _AboutSL2Z01PF = GetValues(0)
                        End If
                    End If
                    Return _AboutSL2Z01PF
                End Get
                Set(value As SLS300LB.SL2Z01PF)
                    _AboutSL2Z01PF = value
                End Set
            End Property
#End Region
        End Class
#End Region

    End Class
End Namespace