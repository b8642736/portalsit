Namespace AST500LB
    ''' <summary>
    ''' 固定資產調撥移轉記錄
    ''' </summary>
    ''' <remarks></remarks>
    Public Class AST401PF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("AST500LB", GetType(AST401PF).Name)
            Me.TRNDATE = (Format(Now, "yyyy") - 1911) * 10000 + Format(Now, "MMdd")
            Me.TRNTIME = CType(Format(Now, "hhmmss"), Integer)
        End Sub

#Region "移轉資產日期 屬性:TRNDATE"
        Private _TRNDATE As System.Int32
        ''' <summary>
        ''' 移轉資產日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property TRNDATE() As System.Int32
            Get
                Return _TRNDATE
            End Get
            Set(ByVal value As System.Int32)
                _TRNDATE = value
            End Set
        End Property
#End Region
#Region "移轉資產時間 屬性:TRNTIME"
        Private _TRNTIME As String
        ''' <summary>
        ''' 移轉資產時間
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property TRNTIME() As String
            Get
                Return _TRNTIME
            End Get
            Set(ByVal value As String)
                _TRNTIME = value
            End Set
        End Property
#End Region
#Region "原資產編號 屬性:FNUMBER"
        Private _FNUMBER As System.String
        ''' <summary>
        ''' 原資產編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FNUMBER() As System.String
            Get
                Return _FNUMBER
            End Get
            Set(ByVal value As System.String)
                _FNUMBER = value
                About_AST106PF = Nothing
            End Set
        End Property
#End Region
#Region "新資產編號 屬性:TNUMBER"
        Private _TNUMBER As System.String
        ''' <summary>
        ''' 新資產編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TNUMBER() As System.String
            Get
                Return _TNUMBER
            End Get
            Set(ByVal value As System.String)
                _TNUMBER = value
            End Set
        End Property
#End Region
#Region "原單位代號 屬性:FDEPTSA"
        Private _FDEPTSA As System.String
        ''' <summary>
        ''' 原單位代號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FDEPTSA() As System.String
            Get
                If (IsNothing(_FDEPTSA) OrElse _FDEPTSA.Trim.Length = 0) AndAlso Not IsNothing(About_AST106PF) Then
                    _FDEPTSA = About_AST106PF.DEPTSA
                End If
                Return _FDEPTSA
            End Get
            Set(ByVal value As System.String)
                _FDEPTSA = value
            End Set
        End Property
#End Region
#Region "新單位代號 屬性:TDEPTSA"
        Private _TDEPTSA As System.String
        ''' <summary>
        ''' 新單位代號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TDEPTSA() As System.String
            Get
                Return _TDEPTSA
            End Get
            Set(ByVal value As System.String)
                _TDEPTSA = value
            End Set
        End Property
#End Region
#Region "移轉數量 屬性:TRNCOUNT"
        Private _TRNCOUNT As System.Int32
        ''' <summary>
        ''' 移轉數量
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TRNCOUNT() As System.Int32
            Get
                Return _TRNCOUNT
            End Get
            Set(ByVal value As System.Int32)
                _TRNCOUNT = value
            End Set
        End Property
#End Region
#Region "備註1 屬性:MEMO1"
        Private _MEMO1 As System.String
        ''' <summary>
        ''' 備註1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MEMO1() As System.String
            Get
                Return _MEMO1
            End Get
            Set(ByVal value As System.String)
                _MEMO1 = value
            End Set
        End Property
#End Region


#Region "移轉資產日期日期格式 屬性:TRNDATEDateFormat"
        ''' <summary>
        ''' 移轉資產日期日期格式
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property TRNDATEDateFormat() As Date
            Get
                'Dim ReturnValue As DateTime = (New AS400DateConverter(Me.TRNDATE)).DateValue
                'Dim TimeString As String = Me.TRNTIME.ToString.Trim
                'If TimeString.Length = 6 Then
                '    ReturnValue.AddHours(CType(TimeString.Substring(0, 2), Integer))
                '    ReturnValue.AddMinutes(CType(TimeString.Substring(2, 2), Integer))
                '    ReturnValue.AddSeconds(CType(TimeString.Substring(4, 2), Integer))
                'End If
                Return (New AS400DateConverter(Me.TRNDATE)).DateValue
            End Get
            Set(ByVal value As Date)
                Me.TRNDATE = (New AS400DateConverter(value)).TwIntegerTypeData
            End Set
        End Property

#End Region

#Region "取得核對儲存發生錯誤訊息 函式:GetSaveCheckErrorMessage"
        ''' <summary>
        ''' 取得核對儲存發生錯誤訊息
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetSaveCheckErrorMessage() As String
            Dim ReturnValue As String = Nothing
            Dim IsDBHaveFNUMBER As Boolean = False
            Dim IsDBHaveFDEPTSA As Boolean = False
            Dim QryString As String = Nothing
            If Not IsNothing(Me.FNUMBER) AndAlso Me.FNUMBER.Trim.Length > 0 Then
                QryString = "Select Count(*) From " & (New AST101PF).CDBFullAS400DBPath.Trim & ".ASTFSA Where Number='" & Me.FNUMBER & "'"
                IsDBHaveFNUMBER = Me.CDBCurrentUseSQLQueryAdapter.SelectQuery(QryString).Rows(0).Item(0) > 0
            End If
            If Not IsNothing(Me.FDEPTSA) AndAlso Me.FDEPTSA.Trim.Length > 0 Then
                QryString = "Select Count(*) From " & (New AST106PF).CDBFullAS400DBPath.Trim & ".ASTFSA Where Number='" & Me.FNUMBER & "'"
                IsDBHaveFDEPTSA = Me.CDBCurrentUseSQLQueryAdapter.SelectQuery(QryString).Rows(0).Item(0) > 0
            End If
            Select Case True
                Case Not IsDBHaveFNUMBER
                    ReturnValue = "資料庫找不到原資產編號!"
                Case Not IsDBHaveFDEPTSA
                    ReturnValue = "資料庫找不到原單位代號!"
                Case IsNothing(Me.TNUMBER) OrElse Me.TNUMBER.Trim.Length <= 0
                    ReturnValue = "新資產編號必須輸入!"
                Case IsNothing(Me.TDEPTSA) OrElse Me.TDEPTSA.Trim.Length <= 0
                    ReturnValue = "新單位代碼必須輸入!"
                Case Me.TRNCOUNT <= 0
                    ReturnValue = "移轉數量必須大於0!"
            End Select
            Return ReturnValue
        End Function
#End Region
#Region "相關使用單位 屬性:About_AST106PF"

        Private _About_AST106PF As AST106PF = Nothing
        ''' <summary>
        ''' 相關使用單位
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property About_AST106PF() As AST106PF
            Get
                If IsNothing(_About_AST106PF) Then
                    Dim QryString As String = "Select * From " & (New AST106PF).CDBFullAS400DBPath & " Where Number='" & Me.FNUMBER & "'"
                    Dim SearchResult As List(Of AST106PF) = AST106PF.CDBSelect(Of AST106PF)(QryString, Me.CDBCurrentUseSQLQueryAdapter)
                    If SearchResult.Count > 0 Then
                        _About_AST106PF = SearchResult.Item(0)
                    End If
                End If
                Return _About_AST106PF
            End Get
            Private Set(ByVal value As AST106PF)
                _About_AST106PF = value
            End Set
        End Property

#End Region


        '#Region "新增 方法:CDBInsert"
        '        ''' <summary>
        '        ''' 新增
        '        ''' </summary>
        '        ''' <returns></returns>
        '        ''' <remarks></remarks>
        '        <DataObjectMethod(DataObjectMethodType.Insert)> _
        '            Public Overrides Function CDBInsert() As Integer
        '            '新增一筆AST106PF
        '            Dim NewAST106PF As New AST500LB.AST106PF
        '            With NewAST106PF
        '                .NUMBER = Me.TNUMBER
        '                .SEQ = 1
        '                .DEPTSA = Me.TDEPTSA
        '            End With
        '            Try
        '                If NewAST106PF.CDBSave <= 0 Then
        '                    Return 0
        '                End If
        '            Catch ex As Exception
        '                Throw New Exception("無法建立AST106PF 原因:" & ex.ToString)
        '            End Try
        '            'Dim OldAST101PF As LIST(OF AST500LB.AST101PF) =AST500LB.AST101PF.CDBSelect("Select * from " & (New AST500LB.AST101PF).CDBFullAS400DBPath 
        '            '新增一筆AST101PF
        '            Dim NewAST101PF As New AST500LB.AST101PF
        '            With NewAST101PF

        '            End With
        '            '新增一筆AST201PF
        '            '變更原AST101PF數量及折舊後更新
        '            '變更原AST201PF數量及折舊後更新
        '            Return MyBase.CDBInsert
        '        End Function
        '#End Region
        '#Region "修改 方法:CDBUpdate"
        '        ''' <summary>
        '        ''' 修改
        '        ''' </summary>
        '        ''' <returns></returns>
        '        ''' <remarks></remarks>
        '        Public Overrides Function CDBUpdate() As Integer
        '            Throw New Exception("此筆資料不可修改!")
        '        End Function
        '#End Region
        '#Region "刪除 方法:CDBDelete"
        '        Public Overrides Function CDBDelete() As Integer
        '            Throw New Exception("此筆資料不可刪除!")
        '        End Function
        '#End Region

    End Class
End Namespace