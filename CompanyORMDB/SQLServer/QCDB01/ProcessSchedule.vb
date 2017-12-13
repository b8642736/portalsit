Namespace SQLServer
	Namespace QCDB01
	Public Class ProcessSchedule
	Inherits ClassDBSQLServer

            Shared DefaultDateValue = New DateTime(2000, 1, 1)
            Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server0SM, "QCDB01")
                Me.ID = Guid.NewGuid.ToString
                Me.StartStateTime = DefaultDateValue
                Me.EndStateTime = DefaultDateValue
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
                    Return _ID
                End Get
                Set(ByVal value As System.String)
                    _ID = value
                End Set
            End Property
#End Region
#Region "SortNumber 屬性:SortNumber"
            Private _SortNumber As System.Int32
            ''' <summary>
            ''' SortNumber
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SortNumber() As System.Int32
                Get
                    Return _SortNumber
                End Get
                Set(ByVal value As System.Int32)
                    _SortNumber = value
                End Set
            End Property
#End Region
#Region "StoveNumber 屬性:StoveNumber"
            Private _StoveNumber As System.String
            ''' <summary>
            ''' StoveNumber
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property StoveNumber() As System.String
                Get
                    Return _StoveNumber
                End Get
                Set(ByVal value As System.String)
                    _StoveNumber = value
                End Set
            End Property
#End Region
#Region "SteelKind 屬性:SteelKind"
            Private _SteelKind As System.String
            ''' <summary>
            ''' SteelKind
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SteelKind() As System.String
                Get
                    Return _SteelKind
                End Get
                Set(ByVal value As System.String)
                    _SteelKind = value
                End Set
            End Property
#End Region
#Region "CurrentState 屬性:CurrentState"
            Private _CurrentState As System.Int32
            ''' <summary>
            ''' CurrentState
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CurrentState() As System.Int32
                Get
                    Return _CurrentState
                End Get
                Set(ByVal value As System.Int32)
                    _CurrentState = value
                End Set
            End Property
#End Region
#Region "StartStateTime 屬性:StartStateTime"
            Private _StartStateTime As System.DateTime
            ''' <summary>
            ''' StartStateTime
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property StartStateTime() As System.DateTime
                Get
                    Return _StartStateTime
                End Get
                Set(ByVal value As System.DateTime)
                    _StartStateTime = value
                End Set
            End Property
#End Region
#Region "EndStateTime 屬性:EndStateTime"
            Private _EndStateTime As DateTime
            ''' <summary>
            ''' EndStateTime
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property EndStateTime() As DateTime
                Get
                    If _EndStateTime < DefaultDateValue Then
                        _EndStateTime = DefaultDateValue
                    End If
                    Return _EndStateTime
                End Get
                Set(ByVal value As DateTime)
                    _EndStateTime = value
                End Set
            End Property

#End Region

#Region "相關成份分析資料資料快取爐號  屬性:AboutElemenDatasStoveNumber"

            Private Shared _AboutElemenDatasStoveNumber As New List(Of String)
            ''' <summary>
            ''' 相關成份分析資料資料快取
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Public Shared Property AboutElemenDatasStoveNumber() As List(Of String)
                Get
                    If IsNothing(_AboutElemenDatasStoveNumber) Then
                        _AboutElemenDatasStoveNumber = New List(Of String)
                    End If
                    Return _AboutElemenDatasStoveNumber
                End Get
                Set(ByVal value As List(Of String))
                    _AboutElemenDatasStoveNumber = value
                End Set
            End Property

#End Region

#Region "重新取得相關成份資料 函式:ReGetAboutElementDatas"
            ''' <summary>
            ''' 重新取得相關成份資料
            ''' </summary>
            ''' <remarks></remarks>
            Public Sub ReGetAboutElementDatas()
                _AboutElementDatas = Nothing
            End Sub
            ''' <summary>
            ''' 重新取得相關成份資料
            ''' </summary>
            ''' <param name="AllProcessSchedule"></param>
            ''' <remarks></remarks>
            Public Shared Sub ReGetAboutElementDatas(ByVal AllProcessSchedule As List(Of ProcessSchedule))
                For Each EachItem As ProcessSchedule In AllProcessSchedule
                    EachItem.ReGetAboutElementDatas()
                Next
            End Sub
#End Region
#Region "相關成份資料 屬性:AboutElementDatas"

            Private Shared _AllAboutElementDatas As DataTable
            Private _AboutElementDatas As List(Of 分析資料)
            ''' <summary>
            ''' 相關成份資料
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
             ReadOnly Property AboutElementDatas() As List(Of 分析資料)
                Get
                    If Not IsNothing(_AboutElementDatas) Then
                        Return _AboutElementDatas
                    End If
                    _AboutElementDatas = New List(Of 分析資料)
                    Static WSDBSQLQueryAdapter As New CompanyORMDB.WSDBSQLQueryAdapter(True)
                    Dim NowTime As DateTime = WSDBSQLQueryAdapter.GetServerTime
                    Dim StoveNumbersString As String = Nothing
                    For Each EachItem As String In AboutElemenDatasStoveNumber
                        StoveNumbersString &= IIf(IsNothing(StoveNumbersString), Nothing, "','") & EachItem.Trim
                    Next
                    If String.IsNullOrEmpty(StoveNumbersString) Then
                        StoveNumbersString &= Me.StoveNumber
                        'Throw New Exception("請先設定AboutElemenDatasStoveNumber值")
                    End If
                    Dim Pre3MonthDateString As Integer = (CType(Format(NowTime.AddMonths(-1), "yyyy"), Double) - 1911) * 10000 + CType(Format(NowTime.AddMonths(-1), "MMdd"), Double)
                    Dim After3MonthDateString As Integer = (CType(Format(NowTime.AddMonths(1), "yyyy"), Double) - 1911) * 10000 + CType(Format(NowTime.AddMonths(1), "MMdd"), Double)
                    _AllAboutElementDatas = Me.CDBCurrentUseSQLQueryAdapter.SelectQuery("Select * From 分析資料 Where 爐號 in ('" & StoveNumbersString & "') AND (日期>=" & Pre3MonthDateString & " OR 日期<=" & After3MonthDateString & ") Order by 日期 Desc ,時間 Desc")
                    For Each EachItem As DataRow In _AllAboutElementDatas.Rows
                        If CType(EachItem.Item("爐號"), String).Trim = Me.StoveNumber.Trim Then
                            Dim AddItem As New 分析資料
                            AddItem.CDBSetDataRowValueToObject(EachItem)
                            AddItem.SQLQueryAdapterByThisObject = CDBCurrentUseSQLQueryAdapter
                            _AboutElementDatas.Add(AddItem)
                        End If
                    Next
                    Return _AboutElementDatas
                End Get

            End Property
#End Region


            '#Region "相關成份資料 屬性:AboutElementDatas"
            '            Private _AboutElementDatas As List(Of 分析資料)
            '            ''' <summary>
            '            ''' 相關成份資料
            '            ''' </summary>
            '            ''' <value></value>
            '            ''' <returns></returns>
            '            ''' <remarks></remarks>
            '            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            '            ReadOnly Property AboutElementDatas() As List(Of 分析資料)
            '                Get
            '                    Static PCNowTime As DateTime = Now
            '                    Static WSDBSQLQueryAdapter As New CompanyORMDB.WSDBSQLQueryAdapter(True)
            '                    Dim NowTime As DateTime = WSDBSQLQueryAdapter.GetServerTime
            '                    If Now.Subtract(PCNowTime).TotalSeconds > 5 Then
            '                        NowTime = WSDBSQLQueryAdapter.GetServerTime
            '                        PCNowTime = Now
            '                    End If
            '                    If Not IsNothing(_AboutElementDatas) AndAlso Is分析資料DBChanged(NowTime) = False Then
            '                        Return _AboutElementDatas
            '                    End If
            '                    Dim Pre3MonthDateString As Integer = (CType(Format(NowTime.AddMonths(-1), "yyyy"), Double) - 1911) * 10000 + CType(Format(NowTime.AddMonths(-1), "MMdd"), Double)
            '                    Dim After3MonthDateString As Integer = (CType(Format(NowTime.AddMonths(1), "yyyy"), Double) - 1911) * 10000 + CType(Format(NowTime.AddMonths(1), "MMdd"), Double)
            '                    _AboutElementDatas = 分析資料.CDBSelect(Of 分析資料)("Select * From 分析資料 Where 爐號='" & Me.StoveNumber & "' AND (日期>=" & Pre3MonthDateString & " OR 日期<=" & After3MonthDateString & ") Order by 日期 Desc ,時間 Desc", Me.CDBCurrentUseSQLQueryAdapter)

            '                    Return _AboutElementDatas
            '                End Get
            '            End Property

            '            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            '            Private ReadOnly Property Is分析資料DBChanged(ByVal NowTime As DateTime) As Boolean
            '                Get
            '                    Static LastGetTime As DateTime = NowTime
            '                    If NowTime.Subtract(LastGetTime).TotalSeconds <= 5 Then
            '                        Return False
            '                    End If
            '                    Static LastChangedID As Integer = -1
            '                    Dim GetNewChangeID As Integer = Me.CDBCurrentUseSQLQueryAdapter.SelectQuery("Select ChangeID FROM AspNet_SqlCacheTablesForChangeNotification Where TableName='分析資料'").Rows(0).Item(0)
            '                    If LastChangedID >= 0 AndAlso LastChangedID = GetNewChangeID Then
            '                        Return False
            '                    End If
            '                    LastChangedID = GetNewChangeID
            '                    LastGetTime = NowTime
            '                    Return True
            '                End Get
            '            End Property
            '#End Region

#Region "製程狀態 屬性:ProcessState"
            '''' <summary>
            '''' 製程狀態
            '''' </summary>
            '''' <value></value>
            '''' <returns></returns>
            '''' <remarks></remarks>
            'ReadOnly Property ProcessState(Optional ByVal CachData As List(Of 分析資料) = Nothing) As String
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property ProcessState() As String
                Get
                    Dim GetElementDatas As List(Of 分析資料) = AboutElementDatas
                    If AboutElementDatas.Count = 0 Then
                        Return "未開始生產"
                    End If

                    Dim LastGetElementData As 分析資料 = GetElementDatas(0)
                    Return "站別:" & LastGetElementData.站別 & " 序號:" & LastGetElementData.序號
                End Get
            End Property
#End Region
#Region "目前狀態文字說明 屬性:CurrentStateExplain"
            ''' <summary>
            ''' 目前狀態文字說明
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>\
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property CurrentStateExplain() As String
                Get
                    Select Case True
                        Case Me.CurrentState = 1
                            Return "製程中"
                        Case Me.CurrentState = 2
                            Return "已完成"
                        Case Me.CurrentState = 3
                            Return "倒爐"
                        Case Else
                            Return "未知"
                    End Select
                End Get
            End Property
#End Region
#Region "是否已至CC製程 屬性:IsInProcessCC"
            ''' <summary>
            ''' 是否已至CC製程
            ''' </summary>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property IsInProcessCC() As Boolean
                Get
                    Dim AboutElementData As List(Of 分析資料) = AboutElementDatas
                    If Not IsNothing(AboutElementData) Then
                        For Each EachItem As 分析資料 In AboutElementData
                            If EachItem.站別.Trim.Length > 0 AndAlso EachItem.站別.Substring(0, 1) = "C" Then
                                Return True
                            End If
                        Next
                    End If
                    Return False
                End Get
            End Property
#End Region

        End Class
	End Namespace
End Namespace