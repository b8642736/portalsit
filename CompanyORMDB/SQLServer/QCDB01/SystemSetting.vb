Namespace SQLServer
	Namespace QCDB01
	Public Class SystemSetting
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"QCDB01")
	End Sub

#Region "Key_Word 屬性:Key_Word"
	Private _Key_Word As System.String
	''' <summary>
	''' Key_Word
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property Key_Word () As System.String
		Get
			Return _Key_Word
		End Get
		Set(Byval value as System.String)
			_Key_Word = value
		End Set
	End Property
#End Region
#Region "Key_Name 屬性:Key_Name"
	Private _Key_Name As System.String
	''' <summary>
	''' Key_Name
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Key_Name () As System.String
		Get
			Return _Key_Name
		End Get
		Set(Byval value as System.String)
			_Key_Name = value
		End Set
	End Property
#End Region
#Region "Content 屬性:Content"
	Private _Content As System.String
	''' <summary>
	''' Content
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Content () As System.String
		Get
			Return _Content
		End Get
		Set(Byval value as System.String)
			_Content = value
		End Set
	End Property
#End Region
#Region "User_ModifyFlag 屬性:User_ModifyFlag"
	Private _User_ModifyFlag As System.String
	''' <summary>
	''' User_ModifyFlag
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property User_ModifyFlag () As System.String
		Get
			Return _User_ModifyFlag
		End Get
		Set(Byval value as System.String)
			_User_ModifyFlag = value
		End Set
	End Property
#End Region
	End Class
	End Namespace
End Namespace