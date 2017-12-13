Namespace SQLServer
	Namespace PPS100LB
	Public Class QABugRecord
	Inherits ClassDBSQLServer

            Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
                Me.CoilMaxLength = 9999
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
                    If Not String.IsNullOrEmpty(_CoilNumber) Then
                        _CoilNumber = _CoilNumber.Replace(".", Nothing)
                    End If
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
#Region "站台名稱 屬性:StationName"
            ''' <summary>
            ''' 站台名稱
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Property StationName As String
#End Region
#Region "版本 屬性:Version"
            ''' <summary>
            ''' 版本
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Property Version As String = "1"
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
            Public Property DataCreateTime() As System.DateTime
                Get
                    Return _DataCreateTime
                End Get
                Set(ByVal value As System.DateTime)
                    _DataCreateTime = value
                End Set
            End Property
#End Region
#Region "QABug_Number 屬性:QABug_Number"
            Private _QABug_Number As System.String
            ''' <summary>
            ''' QABug_Number
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property QABug_Number() As System.String
                Get
                    Return _QABug_Number
                End Get
                Set(ByVal value As System.String)
                    _QABug_Number = value
                End Set
            End Property
#End Region
#Region "Degree 屬性:Degree"
            Private _Degree As System.Int32
	''' <summary>
	''' Degree
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
            Public Property Degree() As System.Int32
                Get
                    Return _Degree
                End Get
                Set(ByVal value As System.Int32)
                    _Degree = value
                End Set
            End Property
#End Region
#Region "StartPosition 屬性:StartPosition"
	Private _StartPosition As System.Decimal
	''' <summary>
	''' StartPosition
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property StartPosition () As System.Decimal
		Get
			Return _StartPosition
		End Get
		Set(Byval value as System.Decimal)
			_StartPosition = value
		End Set
	End Property
#End Region
#Region "EndPosition 屬性:EndPosition"
	Private _EndPosition As System.Decimal
	''' <summary>
	''' EndPosition
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EndPosition () As System.Decimal
		Get
			Return _EndPosition
		End Get
		Set(Byval value as System.Decimal)
			_EndPosition = value
		End Set
	End Property
#End Region
#Region "DPositionType 屬性:DPositionType"
            Private _DPositionType As Integer = 1
	''' <summary>
	''' DPositionType
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
            Public Property DPositionType() As Integer
                Get
                    Return _DPositionType
                End Get
                Set(ByVal value As Integer)
                    _DPositionType = value
                End Set
            End Property
#End Region
#Region "DPositionStart 屬性:DPositionStart"
	Private _DPositionStart As System.Decimal
	''' <summary>
	''' DPositionStart
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property DPositionStart () As System.Decimal
		Get
			Return _DPositionStart
		End Get
		Set(Byval value as System.Decimal)
			_DPositionStart = value
		End Set
	End Property
#End Region
#Region "DPositionEnd 屬性:DPositionEnd"
	Private _DPositionEnd As System.Decimal
	''' <summary>
	''' DPositionEnd
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property DPositionEnd () As System.Decimal
		Get
			Return _DPositionEnd
		End Get
		Set(Byval value as System.Decimal)
			_DPositionEnd = value
		End Set
	End Property
#End Region
#Region "PosOrNeg 屬性:PosOrNeg"
            Private _PosOrNeg As Integer
	''' <summary>
	''' PosOrNeg
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
            Public Property PosOrNeg() As Integer
                Get
                    Return _PosOrNeg
                End Get
                Set(ByVal value As Integer)
                    _PosOrNeg = value
                End Set
            End Property
#End Region
#Region "Density 屬性:Density"
	Private _Density As System.Decimal
	''' <summary>
	''' Density
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Density () As System.Decimal
		Get
			Return _Density
		End Get
		Set(Byval value as System.Decimal)
			_Density = value
		End Set
	End Property
#End Region
#Region "Cycle 屬性:Cycle"
            Private _Cycle As Integer
	''' <summary>
	''' Cycle
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
            Public Property Cycle() As Integer
                Get
                    Return _Cycle
                End Get
                Set(ByVal value As Integer)
                    _Cycle = value
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
#Region "鋼捲總長 屬性:CoilMaxLength"
            ''' <summary>
            ''' 鋼捲總長
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property CoilMaxLength As Long
#End Region
#Region "快速輸入字串 屬性:FastInputString"
            Private _FastInputString As String
            ''' <summary>
            ''' 快速輸入字串
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FastInputString() As String
                Get
                    Return _FastInputString
                End Get
                Set(ByVal value As String)
                    _FastInputString = value
                End Set
            End Property
#End Region


#Region "資料是否完整 屬性:IsDataGood"
            ''' <summary>
            ''' 資料是否完整
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property IsDataGood As Boolean
                Get
                    If String.IsNullOrEmpty(CoilNumber) OrElse CoilNumber.Length < 5 Then
                        Return False
                    End If
                    If DataDate < New Date(2000, 1, 1) Then
                        Return False
                    End If
                    If String.IsNullOrEmpty(Me.StationName) OrElse Me.StationName.Trim.Length = 0 Then
                        Return False
                    End If
                    If String.IsNullOrEmpty(Me.QABug_Number) OrElse Me.QABug_Number.Trim.Length = 0 Then
                        Return False
                    End If
                    If Degree <= 0 Then
                        Return False
                    End If
                    If StartPosition = 0 Then
                        Return False
                    End If
                    If DPositionType <> 0 AndAlso DPositionType <> 5 AndAlso DPositionStart = 0 Then
                        Return False
                    End If
                    If PosOrNeg = 0 Then
                        Return False
                    End If
                    If Density = 0 Then
                        Return False
                    End If
                    Return True
                End Get
            End Property
#End Region
#Region "綜合程度 屬性:SynthesesDegree"
            Dim SynthesesDegreeArray(,) As Integer = {{1, 2, 3, 3, 4, 4}, _
                                           {1, 1, 1, 1, 1, 1}, _
                                           {1, 1, 2, 2, 2, 2}, _
                                           {2, 2, 3, 3, 3, 3}, _
                                           {3, 3, 4, 4, 4, 4}, _
                                           {4, 4, 5, 5, 5, 5}, _
                                           {5, 5, 6, 6, 6, 6}, _
                                           {6, 6, 7, 7, 7, 7}, _
                                           {7, 7, 8, 8, 8, 8}, _
                                           {8, 8, 9, 9, 9, 9}}
            Dim NotUsageBugs() As Integer = {11, 13, 15, 22, 24, 28, 48, 49, 52, 55, 56, 58, 80}
            ''' <summary>
            ''' 綜合程度
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks>程度輸入:0~6 密度輸入:0~9</remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property SynthesesDegree As Integer
                Get
                    If Me.Degree <= 0 OrElse Me.Density <= 0 Then
                        Return 0
                    End If

                    Dim SetDegree As Integer = Me.Degree
                    SetDegree = IIf(SetDegree > 6, 6, SetDegree)
                    SetDegree -= 1  '索引由0起算
                    For Each EachBugNumber As Integer In NotUsageBugs
                        If EachBugNumber = Val(Me.QABug_Number) Then
                            Return SynthesesDegreeArray(0, SetDegree)
                        End If
                    Next
                    Dim SetDensity As Integer = Me.Density
                    SetDensity = IIf(SetDensity > 9, 9, SetDensity)
                    Return SynthesesDegreeArray(SetDensity, SetDegree)
                End Get
            End Property
#End Region



#Region "分佈型態名稱 屬性:DPositionTypeName"
            ''' <summary>
            ''' 分佈型態名稱
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property DPositionTypeName As String
                Get
                    Select Case True
                        Case DPositionType = 1
                            Return "內"
                        Case DPositionType = 2
                            Return "外"
                        Case DPositionType = 3
                            Return "全"
                        Case DPositionType = 4
                            Return "雙"
                        Case DPositionType = 5
                            Return "無"
                    End Select
                    Return "未知"
                End Get
            End Property
#End Region
#Region "正反名稱 屬性:PosOrNegName"
            ''' <summary>
            ''' 正反名稱
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property PosOrNegName As String
                Get
                    Select Case PosOrNeg
                        Case 1
                            Return "正"
                        Case 2
                            Return "反"
                        Case 3
                            Return "雙"
                        Case Else
                            Return "未知"
                    End Select
                End Get
            End Property
#End Region

#Region "相互轉換快速輸入字串與本物件 函式:TransFastInputStringToObject"
            ''' <summary>
            ''' 相互轉換快速輸入字串與本物件
            ''' </summary>
            ''' <param name="TransType">0.字串轉物件,1.物件轉字串</param>
            ''' <remarks></remarks>
            Public Sub TransFastInputStringToObject(Optional ByVal TransType As Integer = 0)
                TransFastInputStringAndObjectErrorMsg = Nothing
                Dim SetErrorMsg As New Text.StringBuilder
                Select Case True
                    Case TransType = 0
                        '代號+程度+長度+分佈位置(分佈寬度範圍+分佈寬度)+正反+密度+週期
                        Dim ColumnNames() As String = {"缺陷代號", "程度", "長度", "分佈寬度範圍", "分佈寬度", "正反", "密度", "週期"}
                        Dim TestObject As QABugRecord = Me.CDBClone
                        TestObject.SQLQueryAdapterByThisObject = SQLQueryAdapter
                        If String.IsNullOrEmpty(FastInputString) OrElse FastInputString.Trim.Length = 0 Then
                            TransFastInputStringAndObjectErrorMsg = "輸入字串不可為空值!"
                            ConvertTestObjectToFastInputStringExplain(TestObject)
                            Exit Sub
                        End If
                        Dim SplitValues() As String = FastInputString.Split("+")
                        For ColumnCount As Integer = 0 To 8
                            Select Case True
                                Case (ColumnCount + 1) > SplitValues.Length AndAlso (ColumnCount + 1) <= SplitValues.Length
                                    SetErrorMsg.Append(IIf(SetErrorMsg.Length = 0, Nothing, "/") & ColumnNames(ColumnCount))

                            End Select
                        Next
                        Dim IsBugNumberCorrect As Boolean = False
                        For Each EachItem As QABUG In QABUG.AllBugDatas
                            If EachItem.Number = Val(SplitValues(0)) Then
                                IsBugNumberCorrect = True : Exit For
                            End If
                        Next
                        If IsBugNumberCorrect = False Then
                            SetErrorMsg.Append("缺陷代碼")
                        End If

                        Dim IsDegreeCorrect As Boolean = True
                        If Val(SplitValues(1)) < 0 AndAlso Val(SplitValues(1)) > 9 Then
                            IsDegreeCorrect = False
                            SetErrorMsg.Append(IIf(SetErrorMsg.Length = 0, Nothing, "/") & "程度")
                        End If

                        Dim IsLengthCorrect As Boolean = False
                        If SplitValues(1).Contains("/") Then
                            StartPosition = Val(SplitValues(1))
                            EndPosition = StartPosition
                        Else
                            StartPosition = Val(SplitValues(1).Split("/")(0))
                            EndPosition = Val(SplitValues(1).Split("/")(1))
                        End If

                        If SetErrorMsg.Length > 0 Then
                            SetErrorMsg.Append(" 輸入有誤!")
                        End If
                        ConvertTestObjectToFastInputStringExplain(TestObject)
                    Case TransType = 1
                    Case Else
                End Select
            End Sub

            Private Sub ConvertTestObjectToFastInputStringExplain(ByVal TestObject As QABugRecord)
                If IsNothing(TestObject) Then
                    FastInputStringExplain = "<缺陷代碼>+<程度>+<長度>+<分佈寬度範圍>+<分佈寬度>+<正反>+<密度>+<週期>"
                    Exit Sub
                End If
                Dim SetFastInputStringExplain As New Text.StringBuilder
                With TestObject
                    SetFastInputStringExplain.Append("缺陷:" & .QABug_Number)
                    SetFastInputStringExplain.Append("+程度:" & .Degree)
                    Select Case True
                        Case .StartPosition = .EndPosition
                            SetFastInputStringExplain.Append("+長度:單點")
                        Case .StartPosition <= 1 AndAlso .EndPosition > .CoilMaxLength
                            SetFastInputStringExplain.Append("+長度:全捲")
                        Case Else
                            SetFastInputStringExplain.Append("+長度:範圍")
                    End Select
                    SetFastInputStringExplain.Append(.StartPosition & "~" & .EndPosition)
                    SetFastInputStringExplain.Append("+寬度範圍:" & .DPositionTypeName)
                    Select Case True
                        Case .DPositionStart = .DPositionEnd
                            SetFastInputStringExplain.Append("單點")
                        Case Else
                            SetFastInputStringExplain.Append("範圍")
                    End Select
                    SetFastInputStringExplain.Append("+" & .DPositionStart & "~" & .DPositionEnd)
                    SetFastInputStringExplain.Append("+" & .PosOrNegName)
                    SetFastInputStringExplain.Append("+密度:" & .Density)
                    SetFastInputStringExplain.Append("+週期:" & .Cycle)
                End With
                FastInputStringExplain = SetFastInputStringExplain.ToString
            End Sub
#End Region
#Region "相互轉換快速輸入字串與本物件錯誤訊息 屬性:TransFastInputStringAndObjectErrorMsg"
            ''' <summary>
            ''' 相互轉換快速輸入字串與本物件錯誤訊息
            ''' </summary>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Property TransFastInputStringAndObjectErrorMsg As String
#End Region
#Region "快速輸入字串說明 屬性:FastInputStringExplain"
            Dim _FastInputStringExplain As String = "<缺陷代碼>+<程度>+<長度>+<分佈寬度範圍>+<分佈寬度>+<正反>+<密度>+<週期>"
            ''' <summary>
            ''' 快速輸入字串說明
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Public Property FastInputStringExplain As String
                Get
                    Return _FastInputStringExplain
                End Get
                Private Set(value As String)
                    _FastInputStringExplain = value
                End Set
            End Property
#End Region



#Region "相關鋼捲缺陷其它資料 屬性:AboutQABugRecordOtherData"
            Private _AboutQABugRecordOtherData As QABugRecordTitle
            Private _AboutQABugRecordOtherDataLastReadDBTime As DateTime = Now
            ''' <summary>
            ''' 相關鋼捲缺陷其它資料
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Public Property AboutQABugRecordOtherData() As QABugRecordTitle
                Get
                    If IsNothing(_AboutQABugRecordOtherData) OrElse Now.Subtract(_AboutQABugRecordOtherDataLastReadDBTime).TotalSeconds > 3 Then
                        Dim QryString As New System.Text.StringBuilder
                        QryString.Append("Select * From QABugRecordOtherData Where CoilNumber='" & Me.CoilNumber & "'")
                        QryString.Append(" and StationName='" & Me.StationName & "'")
                        QryString.Append(" and DataDate='" & Me.DataDate & "'")
                        QryString.Append(" and Version='" & Me.Version & "'")
                        QryString.Append(" order by DataCreateTime desc")

                        Dim GetDatas As List(Of QABugRecordTitle) = QABugRecordTitle.CDBSelect(Of QABugRecordTitle)(QryString.ToString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                        If GetDatas.Count > 0 Then
                            _AboutQABugRecordOtherData = GetDatas(0)
                        End If
                        _AboutQABugRecordOtherDataLastReadDBTime = Now
                    End If
                    Return _AboutQABugRecordOtherData
                End Get
                Private Set(ByVal value As QABugRecordTitle)
                    _AboutQABugRecordOtherData = value
                End Set
            End Property
#End Region

            Public Overrides Function CDBInsert() As Integer
                If RecordState = 2 AndAlso IsDataGood Then
                    RecordState = 1
                End If
                If Me.EndPosition > Me.CoilMaxLength Then
                    Me.EndPosition = Me.CoilMaxLength
                End If
                Return MyBase.CDBInsert()
            End Function

            Public Overrides Function CDBUpdate() As Integer
                If RecordState = 2 AndAlso IsDataGood Then
                    RecordState = 1
                End If
                If Me.EndPosition > Me.CoilMaxLength Then
                    Me.EndPosition = Me.CoilMaxLength
                End If
                Return MyBase.CDBUpdate()
            End Function
        End Class
	End Namespace
End Namespace