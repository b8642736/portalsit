Namespace SMS100LB
Public Class SMSC22PF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("SMS100LB", GetType(SMSC22PF).Name)
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
#Region "長度M 屬性:T4"
	Private _T4 As System.Int32
	''' <summary>
	''' 長度M
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
#Region "速度 屬性:T5"
	Private _T5 As System.Single
	''' <summary>
	''' 速度
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
#Region "水溫差CL1 屬性:T6"
	Private _T6 As System.Single
	''' <summary>
	''' 水溫差CL1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T6 () As System.Single
		Get
			Return _T6
		End Get
		Set(Byval value as System.Single)
			_T6 = value
		End Set
	End Property
#End Region
#Region "水溫差CL2 屬性:T7"
	Private _T7 As System.Single
	''' <summary>
	''' 水溫差CL2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T7 () As System.Single
		Get
			Return _T7
		End Get
		Set(Byval value as System.Single)
			_T7 = value
		End Set
	End Property
#End Region
#Region "水溫差CL3 屬性:T8"
	Private _T8 As System.Single
	''' <summary>
	''' 水溫差CL3
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T8 () As System.Single
		Get
			Return _T8
		End Get
		Set(Byval value as System.Single)
			_T8 = value
		End Set
	End Property
#End Region
#Region "水溫差CL4 屬性:T9"
	Private _T9 As System.Single
	''' <summary>
	''' 水溫差CL4
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T9 () As System.Single
		Get
			Return _T9
		End Get
		Set(Byval value as System.Single)
			_T9 = value
		End Set
	End Property
#End Region
#Region "模冷卻水溫度 屬性:T10"
        Private _T10 As System.Int32
        ''' <summary>
        ''' 模冷卻水溫度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T10() As System.Int32
            Get
                Return _T10
            End Get
            Set(ByVal value As System.Int32)
                _T10 = value
            End Set
        End Property
#End Region
#Region "模冷卻水壓力 屬性:T11"
        Private _T11 As System.Single
        ''' <summary>
        ''' 模冷卻水壓力
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T11() As System.Single
            Get
                Return _T11
            End Get
            Set(ByVal value As System.Single)
                _T11 = value
            End Set
        End Property
#End Region

End Class
End Namespace