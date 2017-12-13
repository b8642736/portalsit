Namespace SMS100LB
Public Class SMSSGEPF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("SMS100LB", GetType(SMSSGEPF).Name)
	End Sub

#Region "爐號 屬性:SGA01"
	Private _SGA01 As System.String
	''' <summary>
	''' 爐號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property SGA01 () As System.String
		Get
			Return _SGA01
		End Get
		Set(Byval value as System.String)
			_SGA01 = value
		End Set
	End Property
#End Region
#Region "連鑄 屬性:SGA02"
	Private _SGA02 As System.String
	''' <summary>
	''' 連鑄
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property SGA02 () As System.String
		Get
			Return _SGA02
		End Get
		Set(Byval value as System.String)
			_SGA02 = value
		End Set
	End Property
#End Region
#Region "塊序 屬性:SGA03"
	Private _SGA03 As System.Int32
	''' <summary>
	''' 塊序
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property SGA03 () As System.Int32
		Get
			Return _SGA03
		End Get
		Set(Byval value as System.Int32)
			_SGA03 = value
		End Set
	End Property
#End Region
#Region "切割 屬性:SGA04"
	Private _SGA04 As System.String
	''' <summary>
	''' 切割
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property SGA04 () As System.String
		Get
			Return _SGA04
		End Get
		Set(Byval value as System.String)
			_SGA04 = value
		End Set
	End Property
#End Region
#Region "異常編號 屬性:SGE11"
	Private _SGE11 As System.String
	''' <summary>
	''' 異常編號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property SGE11 () As System.String
		Get
			Return _SGE11
		End Get
		Set(Byval value as System.String)
			_SGE11 = value
		End Set
	End Property
#End Region
#Region "CODE-1 屬性:SGE91"
	Private _SGE91 As System.String
	''' <summary>
	''' CODE-1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property SGE91 () As System.String
		Get
			Return _SGE91
		End Get
		Set(Byval value as System.String)
			_SGE91 = value
		End Set
	End Property
#End Region
#Region "CODE-2 屬性:SGE92"
	Private _SGE92 As System.String
	''' <summary>
	''' CODE-2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property SGE92 () As System.String
		Get
			Return _SGE92
		End Get
		Set(Byval value as System.String)
			_SGE92 = value
		End Set
	End Property
#End Region
End Class
End Namespace