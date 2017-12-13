Namespace PPS100LB
Public Class PPSSUCPF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("PPS100LB", GetType(PPSSUCPF).Name)
	End Sub

#Region "類別 屬性:SUC01"
	Private _SUC01 As System.String
	''' <summary>
	''' 類別
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property SUC01 () As System.String
		Get
			Return _SUC01
		End Get
		Set(Byval value as System.String)
			_SUC01 = value
		End Set
	End Property
#End Region
#Region "代號 屬性:SUC02"
	Private _SUC02 As System.String
	''' <summary>
	''' 代號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property SUC02 () As System.String
		Get
			Return _SUC02
		End Get
		Set(Byval value as System.String)
			_SUC02 = value
		End Set
	End Property
#End Region
#Region "說明 屬性:SUC03"
	Private _SUC03 As System.String
	''' <summary>
	''' 說明
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property SUC03 () As System.String
		Get
			Return _SUC03
		End Get
		Set(Byval value as System.String)
			_SUC03 = value
		End Set
	End Property
#End Region
End Class
End Namespace