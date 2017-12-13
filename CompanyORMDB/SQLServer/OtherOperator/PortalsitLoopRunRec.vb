Namespace SQLServer
	Namespace OtherOperator
	Public Class PortalsitLoopRunRec
	Inherits ClassDBSQLServer

            Public Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "OtherOperator")
                Me.StartRunTime = Now
                Me.EndRunTime = Me.StartRunTime.AddSeconds(-1)
            End Sub

            Public Sub New(ByVal SetRunClass As String, ByVal SetRunServerIP As String)
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "OtherOperator")
                Me.StartRunTime = Now
                Me.EndRunTime = Me.StartRunTime.AddSeconds(-1)
                Me.RunClass = SetRunClass
                Me.RunServerIP = SetRunServerIP
            End Sub


#Region "StartRunTime 屬性:StartRunTime"
            Private _StartRunTime As System.DateTime
            ''' <summary>
            ''' StartRunTime
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property StartRunTime() As System.DateTime
                Get
                    Return _StartRunTime
                End Get
                Set(ByVal value As System.DateTime)
                    _StartRunTime = value
                End Set
            End Property
#End Region
#Region "RunClass 屬性:RunClass"
            Private _RunClass As System.String
            ''' <summary>
            ''' RunClass
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property RunClass() As System.String
                Get
                    Return _RunClass
                End Get
                Set(ByVal value As System.String)
                    _RunClass = value
                End Set
            End Property
#End Region
#Region "RunServerIP 屬性:RunServerIP"
            Private _RunServerIP As System.String
            ''' <summary>
            ''' RunServerIP
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property RunServerIP() As System.String
                Get
                    Return _RunServerIP
                End Get
                Set(ByVal value As System.String)
                    _RunServerIP = value
                End Set
            End Property
#End Region
#Region "EndRunTime 屬性:EndRunTime"
            Private _EndRunTime As System.DateTime
            ''' <summary>
            ''' EndRunTime
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property EndRunTime() As System.DateTime
                Get
                    Return _EndRunTime
                End Get
                Set(ByVal value As System.DateTime)
                    _EndRunTime = value
                End Set
            End Property
#End Region

#Region "是否完成執行 屬性:IsFinishRun"
            ''' <summary>
            ''' 是否完成執行
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property IsFinishRun As Boolean
                Get
                    If EndRunTime < Me.StartRunTime Then
                        Return False
                    End If
                    Return True
                End Get
            End Property
#End Region

#Region "取得某類別最後執行記錄 方法:GetLastPortalsitLoopRunRec"
            ''' <summary>
            ''' 取得某類別最後執行記錄
            ''' </summary>
            ''' <param name="ClassName"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Shared Function GetLastPortalsitLoopRunRec(ByVal ClassName As String, Optional StartRunTimeByThisDay As Date = Nothing) As PortalsitLoopRunRec
                If String.IsNullOrEmpty(ClassName) OrElse ClassName.Trim.Length = 0 Then
                    Return Nothing
                End If
                Dim QryString As String = "Select TOP 1 * from PortalsitLoopRunRec where RunClass='" & ClassName & "' "
                If Not IsNothing(StartRunTimeByThisDay) Then
                    QryString &= " and StartRunTime >= '" & Format(StartRunTimeByThisDay, "yyyy/MM/dd") & "' and StartRunTime < '" & Format(StartRunTimeByThisDay.AddDays(1), "yyyy/MM/dd") & "' "
                End If
                QryString &= " order by StartRunTime desc"
                Dim SearchResult = PortalsitLoopRunRec.CDBSelect(Of PortalsitLoopRunRec)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
                If SearchResult.Count = 0 Then
                    Return Nothing
                End If
                Return SearchResult(0)
            End Function
#End Region

            Public Overrides Function CDBSave() As Integer

                If String.IsNullOrEmpty(Me.RunClass) OrElse Me.RunClass.Trim.Length = 0 Then
                    Throw New Exception("PortalsitLoopRunRec儲存時類別欄位不可為空白!")
                End If
                If String.IsNullOrEmpty(Me.RunServerIP) OrElse Me.RunServerIP.Trim.Length = 0 Then
                    Throw New Exception("PortalsitLoopRunRec儲存時執行伺服器IP欄位不可為空白!")
                End If
                Return MyBase.CDBSave()
            End Function
        End Class
	End Namespace
End Namespace