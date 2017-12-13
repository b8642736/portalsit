Namespace SQLServer
	Namespace PPS100LB
	Public Class InOutOperationLineName
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"PPS100LB")
	End Sub

#Region "ID 屬性:ID"
	Private _ID As System.String
	''' <summary>
	''' ID
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property ID() As System.String
                Get
                    If String.IsNullOrEmpty(_ID) OrElse _ID.Trim.Length = 0 Then
                        _ID = Guid.NewGuid.ToString
                    End If
                    Return _ID
                End Get
                Set(ByVal value As System.String)
                    _ID = value
                End Set
            End Property
#End Region
#Region "InNextOperationLineName 屬性:InNextOperationLineName"
	Private _InNextOperationLineName As System.String
	''' <summary>
	''' InNextOperationLineName
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property InNextOperationLineName () As System.String
		Get
			Return _InNextOperationLineName
		End Get
		Set(Byval value as System.String)
			_InNextOperationLineName = value
		End Set
	End Property
#End Region
#Region "InCurrentFish 屬性:InCurrentFish"
	Private _InCurrentFish As System.String
	''' <summary>
	''' InCurrentFish
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property InCurrentFish () As System.String
		Get
			Return _InCurrentFish
		End Get
		Set(Byval value as System.String)
			_InCurrentFish = value
		End Set
	End Property
#End Region
#Region "OutOperationLineName 屬性:OutOperationLineName"
	Private _OutOperationLineName As System.String
	''' <summary>
	''' OutOperationLineName
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property OutOperationLineName () As System.String
		Get
			Return _OutOperationLineName
		End Get
		Set(Byval value as System.String)
			_OutOperationLineName = value
		End Set
	End Property
#End Region
#Region "OutNextOperationLineName 屬性:OutNextOperationLineName"
	Private _OutNextOperationLineName As System.String
	''' <summary>
	''' OutNextOperationLineName
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property OutNextOperationLineName () As System.String
		Get
			Return _OutNextOperationLineName
		End Get
		Set(Byval value as System.String)
			_OutNextOperationLineName = value
		End Set
	End Property
#End Region


	End Class
	End Namespace
End Namespace