Namespace SQLServer
	Namespace PPS100LB
	Public Class L2RealTimeTagDisplay
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
#Region "資料變更時間 屬性:ValueChangeTime"
            Private _ValueChangeTime As System.DateTime
            ''' <summary>
            ''' 資料變更時間
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ValueChangeTime() As System.DateTime
                Get
                    Return _ValueChangeTime
                End Get
                Set(ByVal value As System.DateTime)
                    _ValueChangeTime = value
                End Set
            End Property
#End Region
#Region "KeyNameForCoil 屬性:KeyNameForCoil"
	Private _KeyNameForCoil As System.String
	''' <summary>
	''' KeyNameForCoil
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property KeyNameForCoil () As System.String
		Get
			Return _KeyNameForCoil
		End Get
		Set(Byval value as System.String)
			_KeyNameForCoil = value
		End Set
	End Property
#End Region
#Region "TagIntValue 屬性:TagIntValue"
            Private _TagIntValue As Single
	''' <summary>
	''' TagIntValue
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
            Public Property TagIntValue() As Single
                Get
                    Return _TagIntValue
                End Get
                Set(ByVal value As Single)
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
#Region "IsGoodStatus 屬性:IsGoodStatus"
            Private _IsGoodStatus As Boolean
            ''' <summary>
            ''' IsGoodStatus
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property IsGoodStatus() As Boolean
                Get
                    Return _IsGoodStatus
                End Get
                Set(ByVal value As Boolean)
                    _IsGoodStatus = value
                End Set
            End Property

#End Region

	End Class
	End Namespace
End Namespace