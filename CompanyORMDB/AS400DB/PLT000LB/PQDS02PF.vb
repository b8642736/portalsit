Namespace PLT000LB
Public Class PQDS02PF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("PLT000LB", GetType(PQDS02PF).Name)
	End Sub

#Region "年 屬性:QDS20A"
	Private _QDS20A As System.Int32
	''' <summary>
	''' 年
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property QDS20A () As System.Int32
		Get
			Return _QDS20A
		End Get
		Set(Byval value as System.Int32)
			_QDS20A = value
		End Set
	End Property
#End Region
#Region "月 屬性:QDS20B"
	Private _QDS20B As System.String
	''' <summary>
	''' 月
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property QDS20B () As System.String
		Get
			Return _QDS20B
		End Get
		Set(Byval value as System.String)
			_QDS20B = value
		End Set
	End Property
#End Region
#Region "類別碼 屬性:QDS20C"
	Private _QDS20C As System.String
	''' <summary>
	''' 類別碼
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property QDS20C () As System.String
		Get
			Return _QDS20C
		End Get
		Set(Byval value as System.String)
			_QDS20C = value
		End Set
	End Property
#End Region
#Region "班別 屬性:QDS20D"
	Private _QDS20D As System.String
	''' <summary>
	''' 班別
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property QDS20D () As System.String
		Get
			Return _QDS20D
		End Get
		Set(Byval value as System.String)
			_QDS20D = value
		End Set
	End Property
#End Region
#Region "應出勤碼01 屬性:QDS201"
	Private _QDS201 As System.String
	''' <summary>
	''' 應出勤碼01
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS201 () As System.String
		Get
			Return _QDS201
		End Get
		Set(Byval value as System.String)
			_QDS201 = value
		End Set
	End Property
#End Region
#Region "02 屬性:QDS202"
	Private _QDS202 As System.String
	''' <summary>
	''' 02
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS202 () As System.String
		Get
			Return _QDS202
		End Get
		Set(Byval value as System.String)
			_QDS202 = value
		End Set
	End Property
#End Region
#Region "03 屬性:QDS203"
	Private _QDS203 As System.String
	''' <summary>
	''' 03
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS203 () As System.String
		Get
			Return _QDS203
		End Get
		Set(Byval value as System.String)
			_QDS203 = value
		End Set
	End Property
#End Region
#Region "04 屬性:QDS204"
	Private _QDS204 As System.String
	''' <summary>
	''' 04
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS204 () As System.String
		Get
			Return _QDS204
		End Get
		Set(Byval value as System.String)
			_QDS204 = value
		End Set
	End Property
#End Region
#Region "05 屬性:QDS205"
	Private _QDS205 As System.String
	''' <summary>
	''' 05
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS205 () As System.String
		Get
			Return _QDS205
		End Get
		Set(Byval value as System.String)
			_QDS205 = value
		End Set
	End Property
#End Region
#Region "06 屬性:QDS206"
	Private _QDS206 As System.String
	''' <summary>
	''' 06
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS206 () As System.String
		Get
			Return _QDS206
		End Get
		Set(Byval value as System.String)
			_QDS206 = value
		End Set
	End Property
#End Region
#Region "07 屬性:QDS207"
	Private _QDS207 As System.String
	''' <summary>
	''' 07
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS207 () As System.String
		Get
			Return _QDS207
		End Get
		Set(Byval value as System.String)
			_QDS207 = value
		End Set
	End Property
#End Region
#Region "08 屬性:QDS208"
	Private _QDS208 As System.String
	''' <summary>
	''' 08
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS208 () As System.String
		Get
			Return _QDS208
		End Get
		Set(Byval value as System.String)
			_QDS208 = value
		End Set
	End Property
#End Region
#Region "09 屬性:QDS209"
	Private _QDS209 As System.String
	''' <summary>
	''' 09
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS209 () As System.String
		Get
			Return _QDS209
		End Get
		Set(Byval value as System.String)
			_QDS209 = value
		End Set
	End Property
#End Region
#Region "10 屬性:QDS210"
	Private _QDS210 As System.String
	''' <summary>
	''' 10
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS210 () As System.String
		Get
			Return _QDS210
		End Get
		Set(Byval value as System.String)
			_QDS210 = value
		End Set
	End Property
#End Region
#Region "11 屬性:QDS211"
	Private _QDS211 As System.String
	''' <summary>
	''' 11
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS211 () As System.String
		Get
			Return _QDS211
		End Get
		Set(Byval value as System.String)
			_QDS211 = value
		End Set
	End Property
#End Region
#Region "12 屬性:QDS212"
	Private _QDS212 As System.String
	''' <summary>
	''' 12
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS212 () As System.String
		Get
			Return _QDS212
		End Get
		Set(Byval value as System.String)
			_QDS212 = value
		End Set
	End Property
#End Region
#Region "13 屬性:QDS213"
	Private _QDS213 As System.String
	''' <summary>
	''' 13
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS213 () As System.String
		Get
			Return _QDS213
		End Get
		Set(Byval value as System.String)
			_QDS213 = value
		End Set
	End Property
#End Region
#Region "14 屬性:QDS214"
	Private _QDS214 As System.String
	''' <summary>
	''' 14
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS214 () As System.String
		Get
			Return _QDS214
		End Get
		Set(Byval value as System.String)
			_QDS214 = value
		End Set
	End Property
#End Region
#Region "15 屬性:QDS215"
	Private _QDS215 As System.String
	''' <summary>
	''' 15
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS215 () As System.String
		Get
			Return _QDS215
		End Get
		Set(Byval value as System.String)
			_QDS215 = value
		End Set
	End Property
#End Region
#Region "16 屬性:QDS216"
	Private _QDS216 As System.String
	''' <summary>
	''' 16
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS216 () As System.String
		Get
			Return _QDS216
		End Get
		Set(Byval value as System.String)
			_QDS216 = value
		End Set
	End Property
#End Region
#Region "17 屬性:QDS217"
	Private _QDS217 As System.String
	''' <summary>
	''' 17
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS217 () As System.String
		Get
			Return _QDS217
		End Get
		Set(Byval value as System.String)
			_QDS217 = value
		End Set
	End Property
#End Region
#Region "18 屬性:QDS218"
	Private _QDS218 As System.String
	''' <summary>
	''' 18
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS218 () As System.String
		Get
			Return _QDS218
		End Get
		Set(Byval value as System.String)
			_QDS218 = value
		End Set
	End Property
#End Region
#Region "19 屬性:QDS219"
	Private _QDS219 As System.String
	''' <summary>
	''' 19
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS219 () As System.String
		Get
			Return _QDS219
		End Get
		Set(Byval value as System.String)
			_QDS219 = value
		End Set
	End Property
#End Region
#Region "20 屬性:QDS220"
	Private _QDS220 As System.String
	''' <summary>
	''' 20
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS220 () As System.String
		Get
			Return _QDS220
		End Get
		Set(Byval value as System.String)
			_QDS220 = value
		End Set
	End Property
#End Region
#Region "21 屬性:QDS221"
	Private _QDS221 As System.String
	''' <summary>
	''' 21
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS221 () As System.String
		Get
			Return _QDS221
		End Get
		Set(Byval value as System.String)
			_QDS221 = value
		End Set
	End Property
#End Region
#Region "22 屬性:QDS222"
	Private _QDS222 As System.String
	''' <summary>
	''' 22
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS222 () As System.String
		Get
			Return _QDS222
		End Get
		Set(Byval value as System.String)
			_QDS222 = value
		End Set
	End Property
#End Region
#Region "23 屬性:QDS223"
	Private _QDS223 As System.String
	''' <summary>
	''' 23
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS223 () As System.String
		Get
			Return _QDS223
		End Get
		Set(Byval value as System.String)
			_QDS223 = value
		End Set
	End Property
#End Region
#Region "24 屬性:QDS224"
	Private _QDS224 As System.String
	''' <summary>
	''' 24
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS224 () As System.String
		Get
			Return _QDS224
		End Get
		Set(Byval value as System.String)
			_QDS224 = value
		End Set
	End Property
#End Region
#Region "25 屬性:QDS225"
	Private _QDS225 As System.String
	''' <summary>
	''' 25
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS225 () As System.String
		Get
			Return _QDS225
		End Get
		Set(Byval value as System.String)
			_QDS225 = value
		End Set
	End Property
#End Region
#Region "26 屬性:QDS226"
	Private _QDS226 As System.String
	''' <summary>
	''' 26
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS226 () As System.String
		Get
			Return _QDS226
		End Get
		Set(Byval value as System.String)
			_QDS226 = value
		End Set
	End Property
#End Region
#Region "27 屬性:QDS227"
	Private _QDS227 As System.String
	''' <summary>
	''' 27
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS227 () As System.String
		Get
			Return _QDS227
		End Get
		Set(Byval value as System.String)
			_QDS227 = value
		End Set
	End Property
#End Region
#Region "28 屬性:QDS228"
	Private _QDS228 As System.String
	''' <summary>
	''' 28
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS228 () As System.String
		Get
			Return _QDS228
		End Get
		Set(Byval value as System.String)
			_QDS228 = value
		End Set
	End Property
#End Region
#Region "29 屬性:QDS229"
	Private _QDS229 As System.String
	''' <summary>
	''' 29
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS229 () As System.String
		Get
			Return _QDS229
		End Get
		Set(Byval value as System.String)
			_QDS229 = value
		End Set
	End Property
#End Region
#Region "30 屬性:QDS230"
	Private _QDS230 As System.String
	''' <summary>
	''' 30
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS230 () As System.String
		Get
			Return _QDS230
		End Get
		Set(Byval value as System.String)
			_QDS230 = value
		End Set
	End Property
#End Region
#Region "31 屬性:QDS231"
	Private _QDS231 As System.String
	''' <summary>
	''' 31
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QDS231 () As System.String
		Get
			Return _QDS231
		End Get
		Set(Byval value as System.String)
			_QDS231 = value
		End Set
	End Property
#End Region
End Class
End Namespace