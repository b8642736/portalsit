Namespace PPS100LB
Public Class PPSQCGPF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("PPS100LB", GetType(PPSQCGPF).Name)
	End Sub

#Region "DATE 屬性:QCG01"
	Private _QCG01 As System.Int32
	''' <summary>
	''' DATE
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property QCG01 () As System.Int32
		Get
			Return _QCG01
		End Get
		Set(Byval value as System.Int32)
			_QCG01 = value
		End Set
	End Property
#End Region
#Region "鋼捲 屬性:QCG02"
	Private _QCG02 As System.String
	''' <summary>
	''' 鋼捲
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property QCG02 () As System.String
		Get
			Return _QCG02
		End Get
		Set(Byval value as System.String)
			_QCG02 = value
		End Set
	End Property
#End Region
#Region "斷捲 屬性:QCG03"
	Private _QCG03 As System.String
	''' <summary>
	''' 斷捲
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property QCG03 () As System.String
		Get
			Return _QCG03
		End Get
		Set(Byval value as System.String)
			_QCG03 = value
		End Set
	End Property
#End Region
#Region "LINE 屬性:QCG04"
	Private _QCG04 As System.String
	''' <summary>
	''' LINE
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property QCG04 () As System.String
		Get
			Return _QCG04
		End Get
		Set(Byval value as System.String)
			_QCG04 = value
		End Set
	End Property
#End Region
#Region "DIRECTION 屬性:QCG05"
	Private _QCG05 As System.String
	''' <summary>
	''' DIRECTION
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property QCG05 () As System.String
		Get
			Return _QCG05
		End Get
		Set(Byval value as System.String)
			_QCG05 = value
		End Set
	End Property
#End Region
#Region "GAUGE 屬性:QCG06"
	Private _QCG06 As System.Single
	''' <summary>
	''' GAUGE
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG06 () As System.Single
		Get
			Return _QCG06
		End Get
		Set(Byval value as System.Single)
			_QCG06 = value
		End Set
	End Property
#End Region
#Region "WIDTH 屬性:QCG07"
	Private _QCG07 As System.Single
	''' <summary>
	''' WIDTH
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG07 () As System.Single
		Get
			Return _QCG07
		End Get
		Set(Byval value as System.Single)
			_QCG07 = value
		End Set
	End Property
#End Region
#Region "AERA 屬性:QCG08"
	Private _QCG08 As System.Single
	''' <summary>
	''' AERA
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG08 () As System.Single
		Get
			Return _QCG08
		End Get
		Set(Byval value as System.Single)
			_QCG08 = value
		End Set
	End Property
#End Region
#Region "Y.P 屬性:QCG09"
	Private _QCG09 As System.Int32
	''' <summary>
	''' Y.P
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG09 () As System.Int32
		Get
			Return _QCG09
		End Get
		Set(Byval value as System.Int32)
			_QCG09 = value
		End Set
	End Property
#End Region
#Region "T.P 屬性:QCG10"
	Private _QCG10 As System.Int32
	''' <summary>
	''' T.P
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG10 () As System.Int32
		Get
			Return _QCG10
		End Get
		Set(Byval value as System.Int32)
			_QCG10 = value
		End Set
	End Property
#End Region
#Region "Y.S 屬性:QCG11"
	Private _QCG11 As System.Int32
	''' <summary>
	''' Y.S
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG11 () As System.Int32
		Get
			Return _QCG11
		End Get
		Set(Byval value as System.Int32)
			_QCG11 = value
		End Set
	End Property
#End Region
#Region "T.S 屬性:QCG12"
	Private _QCG12 As System.Int32
	''' <summary>
	''' T.S
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG12 () As System.Int32
		Get
			Return _QCG12
		End Get
		Set(Byval value as System.Int32)
			_QCG12 = value
		End Set
	End Property
#End Region
#Region "ELONGATION 屬性:QCG13"
	Private _QCG13 As System.Single
	''' <summary>
	''' ELONGATION
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG13 () As System.Single
		Get
			Return _QCG13
		End Get
		Set(Byval value as System.Single)
			_QCG13 = value
		End Set
	End Property
#End Region
#Region "HRB 屬性:QCG14"
	Private _QCG14 As System.Single
	''' <summary>
	''' HRB
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG14 () As System.Single
		Get
			Return _QCG14
		End Get
		Set(Byval value as System.Single)
			_QCG14 = value
		End Set
	End Property
#End Region
#Region "R-VALUE 屬性:QCG15"
	Private _QCG15 As System.Single
	''' <summary>
	''' R-VALUE
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG15 () As System.Single
		Get
			Return _QCG15
		End Get
		Set(Byval value as System.Single)
			_QCG15 = value
		End Set
	End Property
#End Region
#Region "N-VALUE 屬性:QCG16"
	Private _QCG16 As System.Single
	''' <summary>
	''' N-VALUE
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG16 () As System.Single
		Get
			Return _QCG16
		End Get
		Set(Byval value as System.Single)
			_QCG16 = value
		End Set
	End Property
#End Region
#Region "OLSEN 屬性:QCG17"
	Private _QCG17 As System.Single
	''' <summary>
	''' OLSEN
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG17 () As System.Single
		Get
			Return _QCG17
		End Get
		Set(Byval value as System.Single)
			_QCG17 = value
		End Set
	End Property
#End Region
#Region "橘皮 屬性:QCG18"
	Private _QCG18 As System.Single
	''' <summary>
	''' 橘皮
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG18 () As System.Single
		Get
			Return _QCG18
		End Get
		Set(Byval value as System.Single)
			_QCG18 = value
		End Set
	End Property
#End Region
#Region "REMA 屬性:QCG19"
	Private _QCG19 As System.String
	''' <summary>
	''' REMA
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG19 () As System.String
		Get
			Return _QCG19
		End Get
		Set(Byval value as System.String)
			_QCG19 = value
		End Set
	End Property
#End Region
#Region "HV 屬性:QCG20"
	Private _QCG20 As System.Single
	''' <summary>
	''' HV
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG20 () As System.Single
		Get
			Return _QCG20
		End Get
		Set(Byval value as System.Single)
			_QCG20 = value
		End Set
	End Property
#End Region
#Region "HRC 屬性:QCG21"
	Private _QCG21 As System.Single
	''' <summary>
	''' HRC
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG21 () As System.Single
		Get
			Return _QCG21
		End Get
		Set(Byval value as System.Single)
			_QCG21 = value
		End Set
	End Property
#End Region
#Region " 屬性:QCG22"
	Private _QCG22 As System.String
	''' <summary>
	''' 
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG22 () As System.String
		Get
			Return _QCG22
		End Get
		Set(Byval value as System.String)
			_QCG22 = value
		End Set
	End Property
#End Region
#Region "CODE-1 屬性:QCG23"
	Private _QCG23 As System.String
	''' <summary>
	''' CODE-1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG23 () As System.String
		Get
			Return _QCG23
		End Get
		Set(Byval value as System.String)
			_QCG23 = value
		End Set
	End Property
#End Region
#Region "CODE-2 屬性:QCG24"
	Private _QCG24 As System.String
	''' <summary>
	''' CODE-2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG24 () As System.String
		Get
			Return _QCG24
		End Get
		Set(Byval value as System.String)
			_QCG24 = value
		End Set
	End Property
#End Region
#Region "CUP 屬性:QCG25"
	Private _QCG25 As System.Single
	''' <summary>
	''' CUP
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG25 () As System.Single
		Get
			Return _QCG25
		End Get
		Set(Byval value as System.Single)
			_QCG25 = value
		End Set
	End Property
#End Region
#Region "E-Modulus 屬性:QCG26"
	Private _QCG26 As System.Single
	''' <summary>
	''' E-Modulus
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG26 () As System.Single
		Get
			Return _QCG26
		End Get
		Set(Byval value as System.Single)
			_QCG26 = value
		End Set
	End Property
#End Region
#Region "μ 屬性:QCG27"
	Private _QCG27 As System.Single
	''' <summary>
	''' μ
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG27 () As System.Single
		Get
			Return _QCG27
		End Get
		Set(Byval value as System.Single)
			_QCG27 = value
		End Set
	End Property
#End Region
#Region "Rp1.0 屬性:QCG28"
	Private _QCG28 As System.Int32
	''' <summary>
	''' Rp1.0
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QCG28 () As System.Int32
		Get
			Return _QCG28
		End Get
		Set(Byval value as System.Int32)
			_QCG28 = value
		End Set
	End Property
#End Region
End Class
End Namespace