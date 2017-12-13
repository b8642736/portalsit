Namespace COME
Public Class KIND02PF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("COME", GetType(KIND02PF).Name)
	End Sub

#Region "單據號碼1 屬性:KD201"
	Private _KD201 As System.String
	''' <summary>
	''' 單據號碼1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property KD201 () As System.String
		Get
			Return _KD201
		End Get
		Set(Byval value as System.String)
			_KD201 = value
		End Set
	End Property
#End Region
#Region "單據號碼2 屬性:KD202"
	Private _KD202 As System.Int32
	''' <summary>
	''' 單據號碼2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property KD202 () As System.Int32
		Get
			Return _KD202
		End Get
		Set(Byval value as System.Int32)
			_KD202 = value
		End Set
	End Property
#End Region
#Region "項次 屬性:KD203"
	Private _KD203 As System.Int32
	''' <summary>
	''' 項次
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property KD203 () As System.Int32
		Get
			Return _KD203
		End Get
		Set(Byval value as System.Int32)
			_KD203 = value
		End Set
	End Property
#End Region
#Region "金額 屬性:KD204"
        Private _KD204 As System.Int64
	''' <summary>
	''' 金額
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
        Public Property KD204() As System.Int64
            Get
                Return _KD204
            End Get
            Set(ByVal value As System.Int64)
                _KD204 = value
            End Set
        End Property
#End Region
#Region "摘要 屬性:KD205"
	Private _KD205 As System.String
	''' <summary>
	''' 摘要
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property KD205 () As System.String
		Get
			Return _KD205
		End Get
		Set(Byval value as System.String)
			_KD205 = value
		End Set
	End Property
#End Region
#Region "備註 屬性:KD206"
	Private _KD206 As System.String
	''' <summary>
	''' 備註
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property KD206 () As System.String
		Get
			Return _KD206
		End Get
		Set(Byval value as System.String)
			_KD206 = value
		End Set
	End Property
#End Region
End Class
End Namespace