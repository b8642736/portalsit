Namespace SQLServer
	Namespace WELFARE
	Public Class 傳票明細
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"WELFARE")
	End Sub

#Region "傳票編號 屬性:傳票編號"
	Private _傳票編號 As System.String
	''' <summary>
	''' 傳票編號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property 傳票編號 () As System.String
		Get
			Return _傳票編號
		End Get
		Set(Byval value as System.String)
			_傳票編號 = value
		End Set
	End Property
#End Region
#Region "序號 屬性:序號"
	Private _序號 As System.Int16
	''' <summary>
	''' 序號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property 序號 () As System.Int16
		Get
			Return _序號
		End Get
		Set(Byval value as System.Int16)
			_序號 = value
		End Set
	End Property
#End Region
#Region "會計科目 屬性:會計科目"
	Private _會計科目 As System.String
	''' <summary>
	''' 會計科目
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 會計科目 () As System.String
		Get
			Return _會計科目
		End Get
		Set(Byval value as System.String)
			_會計科目 = value
		End Set
	End Property
#End Region
#Region "科目別 屬性:科目別"
	Private _科目別 As System.String
	''' <summary>
	''' 科目別
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 科目別 () As System.String
		Get
			Return _科目別
		End Get
		Set(Byval value as System.String)
			_科目別 = value
		End Set
	End Property
#End Region
#Region "款項目 屬性:款項目"
	Private _款項目 As System.String
	''' <summary>
	''' 款項目
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 款項目 () As System.String
		Get
			Return _款項目
		End Get
		Set(Byval value as System.String)
			_款項目 = value
		End Set
	End Property
#End Region
#Region "明細項 屬性:明細項"
	Private _明細項 As System.String
	''' <summary>
	''' 明細項
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 明細項 () As System.String
		Get
			Return _明細項
		End Get
		Set(Byval value as System.String)
			_明細項 = value
		End Set
	End Property
#End Region
#Region "借貸別 屬性:借貸別"
	Private _借貸別 As System.String
	''' <summary>
	''' 借貸別
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 借貸別 () As System.String
		Get
			Return _借貸別
		End Get
		Set(Byval value as System.String)
			_借貸別 = value
		End Set
	End Property
#End Region
#Region "金額 屬性:金額"
	Private _金額 As System.Double
	''' <summary>
	''' 金額
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 金額 () As System.Double
		Get
			Return _金額
		End Get
		Set(Byval value as System.Double)
			_金額 = value
		End Set
	End Property
#End Region
#Region "摘要 屬性:摘要"
	Private _摘要 As System.String
	''' <summary>
	''' 摘要
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 摘要 () As System.String
		Get
			Return _摘要
		End Get
		Set(Byval value as System.String)
			_摘要 = value
		End Set
	End Property
#End Region

	End Class
	End Namespace
End Namespace