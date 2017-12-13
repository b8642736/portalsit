Namespace FOD100LB
Public Class FODM04PF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("FOD100LB", GetType(FODM04PF).Name)
	End Sub

#Region "出勤單位編號 屬性:FD401"
	Private _FD401 As System.String
	''' <summary>
	''' 出勤單位編號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property FD401 () As System.String
		Get
			Return _FD401
		End Get
		Set(Byval value as System.String)
			_FD401 = value
		End Set
	End Property
#End Region
#Region "伙食單位編 屬性:FD402"
	Private _FD402 As System.String
	''' <summary>
	''' 伙食單位編
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD402 () As System.String
		Get
			Return _FD402
		End Get
		Set(Byval value as System.String)
			_FD402 = value
		End Set
	End Property
#End Region
#Region "是否有效 屬性:FD403"
	Private _FD403 As System.String
	''' <summary>
	''' 是否有效
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD403 () As System.String
		Get
			Return _FD403
		End Get
		Set(Byval value as System.String)
			_FD403 = value
		End Set
	End Property
#End Region
#Region "備註 屬性:FD404"
	Private _FD404 As System.String
	''' <summary>
	''' 備註
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD404 () As System.String
		Get
			Return _FD404
		End Get
		Set(Byval value as System.String)
			_FD404 = value
		End Set
	End Property
#End Region
End Class
End Namespace