Namespace SQLServer
	Namespace PPS100LB
	Public Class QAThickness
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"PPS100LB")
	End Sub

#Region "CoilNumber 屬性:CoilNumber"
	Private _CoilNumber As System.String
	''' <summary>
	''' CoilNumber
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property CoilNumber () As System.String
		Get
			Return _CoilNumber
		End Get
		Set(Byval value as System.String)
			_CoilNumber = value
		End Set
	End Property
#End Region
#Region "DataDate 屬性:DataDate"
	Private _DataDate As System.DateTime
	''' <summary>
	''' DataDate
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property DataDate () As System.DateTime
		Get
			Return _DataDate
		End Get
		Set(Byval value as System.DateTime)
			_DataDate = value
		End Set
	End Property
#End Region
#Region "StationName 屬性:StationName"
	Private _StationName As System.String
	''' <summary>
	''' StationName
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property StationName () As System.String
		Get
			Return _StationName
		End Get
		Set(Byval value as System.String)
			_StationName = value
		End Set
	End Property
#End Region
#Region "Version 屬性:Version"
	Private _Version As System.String
	''' <summary>
	''' Version
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property Version () As System.String
		Get
			Return _Version
		End Get
		Set(Byval value as System.String)
			_Version = value
		End Set
	End Property
#End Region
#Region "輸出鋼捲編號 屬性:OutCoilNumber"
            Private _OutCoilNumber As String
            ''' <summary>
            ''' 輸出鋼捲編號
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property OutCoilNumber() As String
                Get
                    Return _OutCoilNumber
                End Get
                Set(ByVal value As String)
                    _OutCoilNumber = value
                End Set
            End Property

#End Region
#Region "DataCreateTime 屬性:DataCreateTime"
	Private _DataCreateTime As System.DateTime
	''' <summary>
	''' DataCreateTime
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property DataCreateTime () As System.DateTime
		Get
			Return _DataCreateTime
		End Get
		Set(Byval value as System.DateTime)
			_DataCreateTime = value
		End Set
	End Property
#End Region
#Region "Thick 屬性:Thick"
            Private _Thick As Single
	''' <summary>
	''' Thick
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
            Public Property Thick() As Single
                Get
                    Return _Thick
                End Get
                Set(ByVal value As Single)
                    _Thick = value
                End Set
            End Property
#End Region
#Region "Width 屬性:Width"
            Private _Width As Long
	''' <summary>
	''' Width
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
            Public Property Width() As Long
                Get
                    Return _Width
                End Get
                Set(ByVal value As Long)
                    _Width = value
                End Set
            End Property
#End Region
#Region "Length 屬性:Length"
            Private _Length As Long
	''' <summary>
	''' Length
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
            Public Property Length() As Long
                Get
                    Return _Length
                End Get
                Set(ByVal value As Long)
                    _Length = value
                End Set
            End Property
#End Region
#Region "RunClientIP 屬性:RunClientIP"
            Private _RunClientIP As System.String
            ''' <summary>
            ''' RunClientIP
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property RunClientIP() As System.String
                Get
                    Return _RunClientIP
                End Get
                Set(ByVal value As System.String)
                    _RunClientIP = value
                End Set
            End Property
#End Region
#Region "此筆資料狀態 屬性:RecordState"
            ''' <summary>
            ''' 此筆資料狀態
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks>1.已完成2.編輯中(資料不完整)3.已刪除</remarks>
            Property RecordState As Integer = 2
#End Region
#Region "編修員工編號 屬性:EditEmployeeID"
            Property EditEmployeeID As String
#End Region
#Region "Thick60 屬性:Thick60"
            Private _Thick60 As System.Decimal
            ''' <summary>
            ''' Thick60
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Thick60() As System.Decimal
                Get
                    Return _Thick60
                End Get
                Set(ByVal value As System.Decimal)
                    _Thick60 = value
                End Set
            End Property
#End Region

	End Class
	End Namespace
End Namespace