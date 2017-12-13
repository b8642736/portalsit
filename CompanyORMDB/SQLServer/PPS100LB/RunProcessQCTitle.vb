Namespace SQLServer
	Namespace PPS100LB
	Public Class RunProcessQCTitle
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"PPS100LB")
	End Sub

#Region "FK_RunProcessDataID 屬性:FK_RunProcessDataID"
            Private _FK_RunProcessDataID As System.String
            ''' <summary>
            ''' FK_RunProcessDataID
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property FK_RunProcessDataID() As System.String
                Get
                    Return _FK_RunProcessDataID
                End Get
                Set(ByVal value As System.String)
                    _FK_RunProcessDataID = value
                End Set
            End Property
#End Region
#Region "FK_LastRefSHA01 屬性:FK_LastRefSHA01"
            Private _FK_LastRefSHA01 As System.String
            ''' <summary>
            ''' FK_LastRefSHA01
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FK_LastRefSHA01() As System.String
                Get
                    Return _FK_LastRefSHA01
                End Get
                Set(ByVal value As System.String)
                    _FK_LastRefSHA01 = value
                End Set
            End Property
#End Region
#Region "FK_LastRefSHA02 屬性:FK_LastRefSHA02"
            Private _FK_LastRefSHA02 As System.String
            ''' <summary>
            ''' FK_LastRefSHA02
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FK_LastRefSHA02() As System.String
                Get
                    Return _FK_LastRefSHA02
                End Get
                Set(ByVal value As System.String)
                    _FK_LastRefSHA02 = value
                End Set
            End Property
#End Region
#Region "FK_LastRefSHA04 屬性:FK_LastRefSHA04"
            Private _FK_LastRefSHA04 As System.Int32
            ''' <summary>
            ''' FK_LastRefSHA04
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FK_LastRefSHA04() As System.Int32
                Get
                    Return _FK_LastRefSHA04
                End Get
                Set(ByVal value As System.Int32)
                    _FK_LastRefSHA04 = value
                End Set
            End Property
#End Region
#Region "SysCoilStartTime 屬性:SysCoilStartTime"
	Private _SysCoilStartTime As System.DateTime
	''' <summary>
	''' SysCoilStartTime
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property SysCoilStartTime () As System.DateTime
		Get
			Return _SysCoilStartTime
		End Get
		Set(Byval value as System.DateTime)
			_SysCoilStartTime = value
		End Set
	End Property
#End Region
#Region "RunStationName 屬性:RunStationName"
            ''' <summary>
            ''' RunStationName
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property RunStationName As String
#End Region
#Region "RunStationPCIP 屬性:RunStationPCIP"
            ''' <summary>
            ''' RunStationPCIP
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property RunStationPCIP As String
#End Region
#Region "是否不平整 屬性:IsNoSmooth"
            Private _IsNoSmooth As Boolean
            ''' <summary>
            ''' 是否不平整
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property IsNoSmooth() As Boolean
                Get
                    Return _IsNoSmooth
                End Get
                Set(ByVal value As Boolean)
                    _IsNoSmooth = value
                End Set
            End Property
#End Region
#Region "IsUserCheckOK 屬性:IsUserCheckOK"
            Private _IsUserCheckOK As Boolean
	''' <summary>
	''' IsUserCheckOK
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
            Public Property IsUserCheckOK() As Boolean
                Get
                    Return _IsUserCheckOK
                End Get
                Set(ByVal value As Boolean)
                    _IsUserCheckOK = value
                End Set
            End Property
#End Region
#Region "UserCheckTime 屬性:UserCheckTime"
	Private _UserCheckTime As System.DateTime
	''' <summary>
	''' UserCheckTime
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property UserCheckTime () As System.DateTime
		Get
			Return _UserCheckTime
		End Get
		Set(Byval value as System.DateTime)
			_UserCheckTime = value
		End Set
	End Property
#End Region
#Region "是否通知品管 屬性:IsNoticeQC"
            Private _IsNoticeQC As Boolean
            ''' <summary>
            ''' 是否通知品管
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property IsNoticeQC() As Boolean
                Get
                    Return _IsNoticeQC
                End Get
                Set(ByVal value As Boolean)
                    _IsNoticeQC = value
                End Set
            End Property
#End Region

#Region "相關AboutRunProcessQCDetail 屬性:AboutRunProcessQCDetail"
            Private _AboutRunProcessQCDetail As List(Of RunProcessQCDetail)
            Private _AboutRunProcessQCDetailLastAccessTime As DateTime = Now
            ''' <summary>
            ''' 相關AboutRunProcessQCDetail
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property AboutRunProcessQCDetail As List(Of RunProcessQCDetail)
                Get
                    If IsNothing(_AboutRunProcessQCDetail) OrElse Now.Subtract(_AboutRunProcessQCDetailLastAccessTime).TotalSeconds > 3 Then
                        Dim Qry As String = "Select * from RunProcessQCDetail Where FK_RunProcessDataID ='" & Me.FK_RunProcessDataID & "' "
                        _AboutRunProcessQCDetail = CompanyORMDB.SQLServer.PPS100LB.RunProcessQCDetail.CDBSelect(Of CompanyORMDB.SQLServer.PPS100LB.RunProcessQCDetail)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, Qry)
                        _AboutRunProcessQCDetailLastAccessTime = Now
                    End If
                    Return _AboutRunProcessQCDetail
                End Get
            End Property
#End Region

#Region "覆寫刪除 函式:CDBDelete"
            ''' <summary>
            ''' 覆寫刪除
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Overrides Function CDBDelete() As Integer
                Dim DeleteQry = "Delete from RunProcessQCDetail WHERE FK_RunProcessDataID='" & Me.FK_RunProcessDataID & "'"
                Dim Adapter As New SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
                Adapter.ExecuteNonQuery()
                Return MyBase.CDBDelete()
            End Function
#End Region

        End Class
	End Namespace
End Namespace