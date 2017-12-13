Namespace MTS100LB
Public Class WARB03PF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("MTS100LB", GetType(WARB03PF).Name)
	End Sub

#Region "進料日期 屬性:WRB301"
	Private _WRB301 As System.Int32
	''' <summary>
	''' 進料日期
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property WRB301 () As System.Int32
		Get
			Return _WRB301
		End Get
		Set(Byval value as System.Int32)
			_WRB301 = value
		End Set
	End Property
#End Region
#Region "物料編號 屬性:WRB302"
	Private _WRB302 As System.String
	''' <summary>
	''' 物料編號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property WRB302 () As System.String
		Get
			Return _WRB302
		End Get
		Set(Byval value as System.String)
			_WRB302 = value
		End Set
	End Property
#End Region
#Region "合約案號 屬性:WRB303"
	Private _WRB303 As System.String
	''' <summary>
	''' 合約案號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property WRB303 () As System.String
		Get
			Return _WRB303
		End Get
		Set(Byval value as System.String)
			_WRB303 = value
		End Set
	End Property
#End Region
#Region "車次 屬性:WRB304"
	Private _WRB304 As System.Int32
	''' <summary>
	''' 車次
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property WRB304 () As System.Int32
		Get
			Return _WRB304
		End Get
		Set(Byval value as System.Int32)
			_WRB304 = value
		End Set
	End Property
#End Region
#Region "跨單序號 屬性:WRB305"
	Private _WRB305 As System.Int32
	''' <summary>
	''' 跨單序號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property WRB305 () As System.Int32
		Get
			Return _WRB305
		End Get
		Set(Byval value as System.Int32)
			_WRB305 = value
		End Set
	End Property
#End Region
#Region "進料淨重 屬性:WRB306"
	Private _WRB306 As System.Single
	''' <summary>
	''' 進料淨重
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property WRB306 () As System.Single
		Get
			Return _WRB306
		End Get
		Set(Byval value as System.Single)
			_WRB306 = value
		End Set
	End Property
#End Region
#Region "雜物重 屬性:WRB307"
	Private _WRB307 As System.Single
	''' <summary>
	''' 雜物重
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property WRB307 () As System.Single
		Get
			Return _WRB307
		End Get
		Set(Byval value as System.Single)
			_WRB307 = value
		End Set
	End Property
#End Region
#Region "單據種類 屬性:WRB308"
	Private _WRB308 As System.String
	''' <summary>
	''' 單據種類
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property WRB308 () As System.String
		Get
			Return _WRB308
		End Get
		Set(Byval value as System.String)
			_WRB308 = value
		End Set
	End Property
#End Region
#Region "退料來源 屬性:WRB310"
	Private _WRB310 As System.String
	''' <summary>
	''' 退料來源
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property WRB310 () As System.String
		Get
			Return _WRB310
		End Get
		Set(Byval value as System.String)
			_WRB310 = value
		End Set
	End Property
#End Region
#Region "代軋批次 屬性:WRB314"
	Private _WRB314 As System.String
	''' <summary>
	''' 代軋批次
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property WRB314 () As System.String
		Get
			Return _WRB314
		End Get
		Set(Byval value as System.String)
			_WRB314 = value
		End Set
	End Property
#End Region
#Region "是否註銷 屬性:WRB318"
	Private _WRB318 As System.String
	''' <summary>
	''' 是否註銷
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property WRB318 () As System.String
		Get
			Return _WRB318
		End Get
		Set(Byval value as System.String)
			_WRB318 = value
		End Set
	End Property
#End Region
#Region "磅單編號 屬性:WRB315"
	Private _WRB315 As System.Int32
	''' <summary>
	''' 磅單編號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property WRB315 () As System.Int32
		Get
			Return _WRB315
		End Get
		Set(Byval value as System.Int32)
			_WRB315 = value
		End Set
	End Property
#End Region
#Region "登錄碼 屬性:WRB316"
	Private _WRB316 As System.String
	''' <summary>
	''' 登錄碼
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property WRB316 () As System.String
		Get
			Return _WRB316
		End Get
		Set(Byval value as System.String)
			_WRB316 = value
		End Set
	End Property
#End Region
#Region "地磅站別 屬性:WRB317"
	Private _WRB317 As System.String
	''' <summary>
	''' 地磅站別
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property WRB317 () As System.String
		Get
			Return _WRB317
		End Get
		Set(Byval value as System.String)
			_WRB317 = value
		End Set
	End Property
#End Region
#Region "廠商 屬性:WRB319"
	Private _WRB319 As System.String
	''' <summary>
	''' 廠商
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property WRB319 () As System.String
		Get
			Return _WRB319
		End Get
		Set(Byval value as System.String)
			_WRB319 = value
		End Set
	End Property
#End Region
#Region "品名 屬性:WRB320"
	Private _WRB320 As System.String
	''' <summary>
	''' 品名
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property WRB320 () As System.String
		Get
			Return _WRB320
		End Get
		Set(Byval value as System.String)
			_WRB320 = value
		End Set
	End Property
#End Region
#Region "登錄人員 屬性:WRB3UR"
	Private _WRB3UR As System.String
	''' <summary>
	''' 登錄人員
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property WRB3UR () As System.String
		Get
			Return _WRB3UR
		End Get
		Set(Byval value as System.String)
			_WRB3UR = value
		End Set
	End Property
#End Region
#Region "登錄時間 屬性:WRB3TM"
	Private _WRB3TM As System.Int32
	''' <summary>
	''' 登錄時間
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property WRB3TM () As System.Int32
		Get
			Return _WRB3TM
		End Get
		Set(Byval value as System.Int32)
			_WRB3TM = value
		End Set
	End Property
#End Region
End Class
End Namespace