Namespace SQLServer
	Namespace PPS100LB
	Public Class RGSGrindRecord
	Inherits ClassDBSQLServer

	Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
                DataSaveTime = Now
                FK1_DataSaveTime = Now
	End Sub

#Region "RGSID 屬性:RGSID"
	Private _RGSID As System.String
	''' <summary>
	''' RGSID
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property RGSID () As System.String
		Get
			Return _RGSID
		End Get
		Set(Byval value as System.String)
			_RGSID = value
		End Set
	End Property
#End Region
#Region "RollerID 屬性:RollerID"
	Private _RollerID As System.String
	''' <summary>
	''' RollerID
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property RollerID () As System.String
		Get
			Return _RollerID
		End Get
		Set(Byval value as System.String)
			_RollerID = value
		End Set
	End Property
#End Region
#Region "DataSaveTime 屬性:DataSaveTime"
	Private _DataSaveTime As System.DateTime
	''' <summary>
	''' DataSaveTime
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property DataSaveTime () As System.DateTime
		Get
			Return _DataSaveTime
		End Get
		Set(Byval value as System.DateTime)
			_DataSaveTime = value
		End Set
	End Property
#End Region
#Region "Size 屬性:Size"
	Private _Size As System.Decimal
	''' <summary>
	''' Size
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Size () As System.Decimal
		Get
			Return _Size
		End Get
		Set(Byval value as System.Decimal)
			_Size = value
		End Set
	End Property
#End Region
#Region "CrownShape 屬性:CrownShape"
	Private _CrownShape As System.String
	''' <summary>
	''' CrownShape
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property CrownShape () As System.String
		Get
			Return _CrownShape
		End Get
		Set(Byval value as System.String)
			_CrownShape = value
		End Set
	End Property
#End Region
#Region "GrindWeight 屬性:GrindWeight"
	Private _GrindWeight As System.Decimal
	''' <summary>
	''' GrindWeight
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property GrindWeight () As System.Decimal
		Get
			Return _GrindWeight
		End Get
		Set(Byval value as System.Decimal)
			_GrindWeight = value
		End Set
	End Property
#End Region
#Region "ProcessedState 屬性:ProcessedState"
	Private _ProcessedState As System.Decimal
	''' <summary>
	''' ProcessedState
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ProcessedState () As System.Decimal
		Get
			Return _ProcessedState
		End Get
		Set(Byval value as System.Decimal)
			_ProcessedState = value
		End Set
	End Property
#End Region
#Region "ProcessEmployeeID 屬性:ProcessEmployeeID"
            Private _ProcessEmployeeID As System.String
            ''' <summary>
            ''' ProcessEmployeeID
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ProcessEmployeeID() As System.String
                Get
                    Return _ProcessEmployeeID
                End Get
                Set(ByVal value As System.String)
                    _ProcessEmployeeID = value
                End Set
            End Property
#End Region
#Region "Memo1 屬性:Memo1"
            Private _Memo1 As System.String
            ''' <summary>
            ''' Memo1
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Memo1() As System.String
                Get
                    Return _Memo1
                End Get
                Set(ByVal value As System.String)
                    _Memo1 = value
                End Set
            End Property
#End Region
#Region "FK1_RGSID 屬性:FK1_RGSID"
            Private _FK1_RGSID As System.String
            ''' <summary>
            ''' FK1_RGSID
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FK1_RGSID() As System.String
                Get
                    Return _FK1_RGSID
                End Get
                Set(ByVal value As System.String)
                    _FK1_RGSID = value
                End Set
            End Property
#End Region
#Region "FK1_RollerID 屬性:FK1_RollerID"
	Private _FK1_RollerID As System.String
	''' <summary>
	''' FK1_RollerID
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FK1_RollerID () As System.String
		Get
			Return _FK1_RollerID
		End Get
		Set(Byval value as System.String)
			_FK1_RollerID = value
		End Set
	End Property
#End Region
#Region "FK1_DataSaveTime 屬性:FK1_DataSaveTime"
	Private _FK1_DataSaveTime As System.DateTime
	''' <summary>
	''' FK1_DataSaveTime
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FK1_DataSaveTime () As System.DateTime
		Get
			Return _FK1_DataSaveTime
		End Get
		Set(Byval value as System.DateTime)
			_FK1_DataSaveTime = value
		End Set
	End Property
#End Region
#Region "FK2_RunProcessData_ID 屬性:FK2_RunProcessData_ID"
	Private _FK2_RunProcessData_ID As System.String
	''' <summary>
	''' FK2_RunProcessData_ID
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FK2_RunProcessData_ID () As System.String
		Get
			Return _FK2_RunProcessData_ID
		End Get
		Set(Byval value as System.String)
			_FK2_RunProcessData_ID = value
		End Set
	End Property
#End Region

#Region "處理狀態說明 屬性:ProcessStateDescript"
            ''' <summary>
            ''' 處理狀態說明
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property ProcessStateDescript As String
                Get
                    Select Case ProcessedState
                        Case 0
                            Return "正常"
                        Case 1
                            Return "裂痕"
                        Case Else
                            Return "未知"
                    End Select
                End Get
            End Property
#End Region

#Region "是否可編修或刪除資料 屬性:IsCanEditDeleteData"
            ''' <summary>
            ''' 是否可編修或刪除資料
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property IsCanEditDeleteData As Boolean
                Get
                    If Not String.IsNullOrEmpty(FK2_RunProcessData_ID) AndAlso FK2_RunProcessData_ID.Trim.Length > 0 Then
                        Return False
                    End If
                    '查詢是否有其它資料已參考此筆資料
                    Dim QryString As String = "Select count(*) from RGSGrindRecord where DataSaveTime > '" & Format(Me.DataSaveTime, "yyyy/MM/dd HH:mm:ss") & "' and FK1_RGSID='" & Me.RGSID & "' and FK1_RollerID='" & Me.RollerID & "' "
                    Dim Adapter As New SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
                    If Val(Adapter.SelectQuery(QryString).Rows(0).Item(0)) > 0 Then
                        Return False
                    End If

                    Return True
                End Get
            End Property
#End Region

#Region "相關RunProcessData 屬性:AboutRunProcessData"
            Dim _AboutRunProcessDataLastAccessTime As DateTime = Now.AddSeconds(-3)
            Private _AboutRunProcessData As RunProcessData
            ''' <summary>
            ''' 相關RunProcessData
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Public Property AboutRunProcessData As RunProcessData
                Get
                    If IsNothing(_AboutRunProcessData) AndAlso Not String.IsNullOrEmpty(FK2_RunProcessData_ID) AndAlso FK2_RunProcessData_ID.Trim.Length > 0 AndAlso Now.Subtract(_AboutRunProcessDataLastAccessTime).TotalSeconds > 2 Then
                        Dim SQLString = "Select * From RunProcessData Where ID='" & Me.FK2_RunProcessData_ID & "'"
                        SQLString &= " UNION Select * From RunProcessDataHistory Where ID='" & Me.FK2_RunProcessData_ID & "' Order by SysCoilStartTime Desc"
                        Dim SearchResult As List(Of RunProcessData) = RunProcessData.CDBSelect(Of RunProcessData)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLString)
                        If SearchResult.Count > 0 Then
                            _AboutRunProcessData = SearchResult(0)
                        End If
                        _AboutRunProcessDataLastAccessTime = Now
                    End If
                    Return _AboutRunProcessData
                End Get
                Set(value As RunProcessData)
                    _AboutRunProcessData = value
                    If IsNothing(_AboutRunProcessData) Then
                        FK2_RunProcessData_ID = ""
                    Else
                        FK2_RunProcessData_ID = _AboutRunProcessData.ID
                    End If
                End Set
            End Property
#End Region
#Region "相關RunProcessData_處理ZML機台名稱 屬性:AboutRunProcessData_ZMLName"
            ''' <summary>
            ''' 相關RunProcessData_處理ZML機台名稱
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property AboutRunProcessData_ZMLName As String
                Get
                    Dim GetAboutRunProcessData As RunProcessData = AboutRunProcessData
                    If IsNothing(GetAboutRunProcessData) Then
                        Return Nothing
                    End If
                    Return GetAboutRunProcessData.FK_RunStationName
                End Get
            End Property
#End Region
#Region "相關RunProcessData_鋼捲編號 屬性:AboutRunProcessData_CoilFullNumber"
            ''' <summary>
            ''' 相關RunProcessData_處理ZML機台名稱
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property AboutRunProcessData_CoilFullNumber As String
                Get
                    Dim GetAboutRunProcessData As RunProcessData = AboutRunProcessData
                    If IsNothing(GetAboutRunProcessData) Then
                        Return Nothing
                    End If
                    Return GetAboutRunProcessData.FK_OutSHA01 & GetAboutRunProcessData.FK_OutSHA02.Trim
                End Get
            End Property
#End Region


            Public Overrides Function CDBInsert() As Integer
                '取得前一筆RGSGrindRecord資料,計算此筆資料之研磨量及相關外鍵值
                Dim QryString As String = "Select top 1 * from RGSGrindRecord Where DataSaveTime < '" & Format(Me.DataSaveTime, "yyyy/MM/dd HH:mm:ss") & "' AND RGSID='" & Me.RGSID & "' AND RollerID='" & Me.RollerID & "' order by DataSaveTime desc "
                Dim SearchResult As List(Of RGSGrindRecord) = RGSGrindRecord.CDBSelect(Of RGSGrindRecord)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
                If SearchResult.Count > 0 Then
                    Me.FK1_RGSID = SearchResult(0).RGSID
                    Me.FK1_RollerID = SearchResult(0).RollerID
                    Me._FK1_DataSaveTime = SearchResult(0).DataSaveTime
                    Me.GrindWeight = SearchResult(0).Size - Me.Size
                End If
                If String.IsNullOrEmpty(FK2_RunProcessData_ID) Then
                    Dim GetAboutRunProcessData As RunProcessData = Me.AboutRunProcessData
                    If Not IsNothing(GetAboutRunProcessData) Then
                        FK2_RunProcessData_ID = GetAboutRunProcessData.ID
                    End If
                End If
                Return MyBase.CDBInsert()
            End Function

            Public Overrides Function CDBUpdate() As Integer
                Dim QryString As String = "Select top 1 * from RGSGrindRecord Where DataSaveTime < '" & Format(Me.DataSaveTime, "yyyy/MM/dd HH:mm:ss") & "' AND RGSID='" & Me.RGSID & "' AND RollerID='" & Me.RollerID & "' order by DataSaveTime desc "
                Dim SearchResult As List(Of RGSGrindRecord) = RGSGrindRecord.CDBSelect(Of RGSGrindRecord)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
                If SearchResult.Count > 0 Then
                    Me.FK1_RGSID = SearchResult(0).RGSID
                    Me.FK1_RollerID = SearchResult(0).RollerID
                    Me._FK1_DataSaveTime = SearchResult(0).DataSaveTime
                    Me.GrindWeight = SearchResult(0).Size - Me.Size
                End If
                If String.IsNullOrEmpty(FK2_RunProcessData_ID) Then
                    Dim GetAboutRunProcessData As RunProcessData = Me.AboutRunProcessData
                    If Not IsNothing(GetAboutRunProcessData) Then
                        FK2_RunProcessData_ID = GetAboutRunProcessData.ID
                    End If
                End If
                Return MyBase.CDBUpdate()
            End Function

        End Class
	End Namespace
End Namespace