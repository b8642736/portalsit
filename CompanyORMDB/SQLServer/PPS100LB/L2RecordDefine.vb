Namespace SQLServer
	Namespace PPS100LB
	Public Class L2RecordDefine
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"PPS100LB")
	End Sub

#Region "LineName 屬性:LineName"
	Private _LineName As System.String
	''' <summary>
	''' LineName
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property LineName () As System.String
		Get
			Return _LineName
		End Get
		Set(Byval value as System.String)
			_LineName = value
		End Set
	End Property
#End Region
#Region "TagName 屬性:TagName"
	Private _TagName As System.String
	''' <summary>
	''' TagName
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property TagName () As System.String
		Get
			Return _TagName
		End Get
		Set(Byval value as System.String)
			_TagName = value
		End Set
	End Property
#End Region
#Region "GetDataTagIntervalSec 屬性:GetDataTagIntervalSec"
            Private _SaveDataTagIntervalSec As Long
            ''' <summary>
            ''' GetDataTagIntervalSec
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SaveDataTagIntervalSec() As Long
                Get
                    Return _SaveDataTagIntervalSec
                End Get
                Set(ByVal value As Long)
                    _SaveDataTagIntervalSec = value
                End Set
            End Property
#End Region
#Region "IsEnable 屬性:IsEnable"
	Private _IsEnable As System.Boolean
	''' <summary>
	''' IsEnable
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property IsEnable () As System.Boolean
		Get
			Return _IsEnable
		End Get
		Set(Byval value as System.Boolean)
			_IsEnable = value
		End Set
	End Property
#End Region
#Region "Description 屬性:Description"
	Private _Description As System.String
	''' <summary>
	''' Description
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Description () As System.String
		Get
			Return _Description
		End Get
		Set(Byval value as System.String)
			_Description = value
		End Set
	End Property
#End Region
#Region "取得資料之形態 屬性:GetValueType"
            ''' <summary>
            ''' 取得資料之形態
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property GetValueType As String
#End Region
#Region "資料來源伺服器 屬性:DataSourceServer"
            ''' <summary>
            ''' 定義資料來源為那台伺服器或檔
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property DataSourceServer As String
#End Region


        End Class
	End Namespace
End Namespace