Namespace FOD100LB
Public Class FODPLCPF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("FOD100LB", GetType(FODPLCPF).Name)
	End Sub

#Region "置處代號 屬性:FDPLC1"
	Private _FDPLC1 As System.String
	''' <summary>
	''' 置處代號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property FDPLC1 () As System.String
		Get
			Return _FDPLC1
		End Get
		Set(Byval value as System.String)
			_FDPLC1 = value
		End Set
	End Property
#End Region
#Region "置便當處 屬性:FDPLC2"
	Private _FDPLC2 As System.String
	''' <summary>
	''' 置便當處
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FDPLC2 () As System.String
		Get
			Return _FDPLC2
		End Get
		Set(Byval value as System.String)
			_FDPLC2 = value
		End Set
	End Property
#End Region
#Region "置處序號 屬性:FDPLC3"
	Private _FDPLC3 As System.Int32
	''' <summary>
	''' 置處序號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FDPLC3 () As System.Int32
		Get
			Return _FDPLC3
		End Get
		Set(Byval value as System.Int32)
			_FDPLC3 = value
		End Set
	End Property
#End Region
#Region "CODE 屬性:FDPLC9"
	Private _FDPLC9 As System.String
	''' <summary>
	''' CODE
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FDPLC9 () As System.String
		Get
			Return _FDPLC9
		End Get
		Set(Byval value as System.String)
			_FDPLC9 = value
		End Set
	End Property
#End Region
End Class
End Namespace