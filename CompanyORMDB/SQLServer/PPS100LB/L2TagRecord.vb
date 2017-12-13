Namespace SQLServer
	Namespace PPS100LB
	Public Class L2TagRecord
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
#Region "ValueCreateTime 屬性:ValueCreateTime"
	Private _ValueCreateTime As System.DateTime
	''' <summary>
	''' ValueCreateTime
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property ValueCreateTime () As System.DateTime
		Get
			Return _ValueCreateTime
		End Get
		Set(Byval value as System.DateTime)
			_ValueCreateTime = value
		End Set
	End Property
#End Region
#Region "TagIntValue 屬性:TagIntValue"
            Private _TagIntValue As System.Decimal
            ''' <summary>
            ''' TagIntValue
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property TagIntValue() As System.Decimal
                Get
                    Return _TagIntValue
                End Get
                Set(ByVal value As System.Decimal)
                    _TagIntValue = value
                End Set
            End Property
#End Region
#Region "TagStringValue 屬性:TagStringValue"
            Private _TagStringValue As String
            ''' <summary>
            ''' TagIntValue
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property TagStringValue() As String
                Get
                    Return _TagStringValue
                End Get
                Set(ByVal value As String)
                    _TagStringValue = value
                End Set
            End Property
#End Region


	End Class
	End Namespace
End Namespace