Namespace SMS100LB
Public Class SMSC21PF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("SMS100LB", GetType(SMSC21PF).Name)
	End Sub

#Region "爐號 屬性:T1"
	Private _T1 As System.String
	''' <summary>
	''' 爐號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property T1 () As System.String
		Get
			Return _T1
		End Get
		Set(Byval value as System.String)
                _T1 = value
		End Set
	End Property
#End Region
#Region "日期 屬性:T2"
	Private _T2 As System.Int32
	''' <summary>
	''' 日期
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property T2 () As System.Int32
		Get
			Return _T2
		End Get
		Set(Byval value as System.Int32)
			_T2 = value
		End Set
	End Property
#End Region
#Region "時間 屬性:T3"
	Private _T3 As System.String
	''' <summary>
	''' 時間
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property T3() As System.String
            Get
                Return _T3
            End Get
            Set(ByVal value As System.String)
                _T3 = value.Trim
            End Set
        End Property
#End Region
#Region "溫度 屬性:T4"
	Private _T4 As System.Int32
	''' <summary>
	''' 溫度
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T4 () As System.Int32
		Get
			Return _T4
		End Get
		Set(Byval value as System.Int32)
			_T4 = value
		End Set
	End Property
#End Region
#Region "澆鑄速度 屬性:T5"
	Private _T5 As System.Single
	''' <summary>
	''' 澆鑄速度
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T5 () As System.Single
		Get
			Return _T5
		End Get
		Set(Byval value as System.Single)
			_T5 = value
		End Set
	End Property
#End Region
#Region "頻率 屬性:T6"
	Private _T6 As System.Int32
	''' <summary>
	''' 頻率
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T6 () As System.Int32
		Get
			Return _T6
		End Get
		Set(Byval value as System.Int32)
			_T6 = value
		End Set
	End Property
#End Region
End Class
End Namespace