Namespace SMS100LB
Public Class SMSC1PF
	Inherits ClassDBAS400

	Sub New()
            MyBase.New("SMS100LB", GetType(SMSC1PF).Name)
            Me.T3 = (Val(Format(Now, "yyyy")) - 1911) * 10000 + Val(Format(Now, "MMdd"))
            Me.T6 = "304"
            Me.IsFistAddNewData = True
            Me.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        End Sub

#Region "爐號 屬性:T1"
	Private _T1 As System.String
	''' <summary>
	''' 爐號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property T1 () As System.String
		Get
			Return _T1
		End Get
            Set(ByVal value As System.String)
                If Not String.IsNullOrEmpty(value) Then
                    _T1 = value.Trim.ToUpper
                Else
                    _T1 = value
                End If
            End Set
	End Property
#End Region
#Region "盛鋼桶號碼 屬性:T2"
	Private _T2 As System.String
	''' <summary>
	''' 盛鋼桶號碼
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T2 () As System.String
		Get
			Return _T2
		End Get
		Set(Byval value as System.String)
			_T2 = value
		End Set
	End Property
#End Region
#Region "日期 屬性:T3"
	Private _T3 As System.Int32
	''' <summary>
	''' 日期
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property T3 () As System.Int32
		Get
			Return _T3
		End Get
		Set(Byval value as System.Int32)
			_T3 = value
		End Set
	End Property
#End Region
#Region "連鑄 屬性:T4"
	Private _T4 As System.String
	''' <summary>
	''' 連鑄
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T4 () As System.String
		Get
			Return _T4
		End Get
		Set(Byval value as System.String)
			_T4 = value
		End Set
	End Property
#End Region
#Region "盛鋼桶空重 屬性:T5"
	Private _T5 As System.Single
	''' <summary>
	''' 盛鋼桶空重
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T5 () As System.Single
		Get
			Return _T5
		End Get
		Set(Byval value as System.Single)
			_T5 = value
		End Set
	End Property
#End Region
#Region "鋼種 屬性:T6"
	Private _T6 As System.String
	''' <summary>
	''' 鋼種
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T6 () As System.String
		Get
			Return _T6
		End Get
		Set(Byval value as System.String)
			_T6 = value
		End Set
	End Property
#End Region
#Region "受鋼開始時間 屬性:T7"
	Private _T7 As System.String
	''' <summary>
	''' 受鋼開始時間
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T7 () As System.String
		Get
			Return _T7
		End Get
		Set(Byval value as System.String)
			_T7 = value
		End Set
	End Property
#End Region
#Region "預估出鋼時間 屬性:T8"
	Private _T8 As System.String
	''' <summary>
	''' 預估出鋼時間
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T8 () As System.String
		Get
			Return _T8
		End Get
		Set(Byval value as System.String)
			_T8 = value
		End Set
	End Property
#End Region
#Region "停止預熱時間 屬性:T9"
	Private _T9 As System.String
	''' <summary>
	''' 停止預熱時間
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T9 () As System.String
		Get
			Return _T9
		End Get
		Set(Byval value as System.String)
			_T9 = value
		End Set
	End Property
#End Region
#Region "出鋼開始時間起 屬性:T10"
	Private _T10 As System.String
	''' <summary>
	''' 出鋼開始時間起
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T10 () As System.String
		Get
			Return _T10
		End Get
		Set(Byval value as System.String)
			_T10 = value
		End Set
	End Property
#End Region
#Region "出鋼開始時間訖 屬性:T11"
	Private _T11 As System.String
	''' <summary>
	''' 出鋼開始時間訖
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T11 () As System.String
		Get
			Return _T11
		End Get
		Set(Byval value as System.String)
			_T11 = value
		End Set
	End Property
#End Region
#Region "出鋼溫度 屬性:T12"
	Private _T12 As System.Int32
	''' <summary>
	''' 出鋼溫度
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T12 () As System.Int32
		Get
			Return _T12
		End Get
		Set(Byval value as System.Int32)
			_T12 = value
		End Set
	End Property
#End Region
#Region "出鋼重量 屬性:T13"
	Private _T13 As System.Single
	''' <summary>
	''' 出鋼重量
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T13 () As System.Single
		Get
			Return _T13
		End Get
		Set(Byval value as System.Single)
			_T13 = value
		End Set
	End Property
#End Region
#Region "盛鋼桶總重 屬性:T14"
	Private _T14 As System.Single
	''' <summary>
	''' 盛鋼桶總重
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T14 () As System.Single
		Get
			Return _T14
		End Get
		Set(Byval value as System.Single)
			_T14 = value
		End Set
	End Property
#End Region
#Region "攪拌備註事項 屬性:T15"
        Private _T15 As System.String
        ''' <summary>
        ''' 攪拌備註事項
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T15() As System.String
            Get
                Return _T15
            End Get
            Set(ByVal value As System.String)
                _T15 = value
            End Set
        End Property
#End Region
#Region "攪拌站記錄員 屬性:T17"
        Private _T17 As System.String
        ''' <summary>
        ''' 攪拌站記錄員
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T17() As System.String
            Get
                Return _T17
            End Get
            Set(ByVal value As System.String)
                _T17 = value
            End Set
        End Property
#End Region


#Region "是否為第一次新增之資料 屬性:IsFistAddNewData"
        ''' <summary>
        ''' 是否為第一次新增之資料
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Property IsFistAddNewData As Boolean
#End Region
#Region "相關攪拌記錄 屬性:AboutSMSC11PFs"
        Private _AboutSMSC11PFs As List(Of SMSC11PF)
        ''' <summary>
        ''' 相關攪拌記錄
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property AboutSMSC11PFs() As List(Of SMSC11PF)
            Get
                If IsNothing(_AboutSMSC11PFs) Then
                    _AboutSMSC11PFs = SMSC11PF.CDBSelect(Of SMSC11PF)("Select * From @#SMS100LB.SMSC11PF WHERE T1='" & Me.T1 & "' AND T2=" & Me.T3 & " Order by T3", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                End If
                '移除未有時間之資料
                For Each EachItem In _AboutSMSC11PFs.ToArray
                    If String.IsNullOrEmpty(EachItem.T3) OrElse EachItem.T3.Trim.Length = 0 Then
                        _AboutSMSC11PFs.Remove(EachItem)
                    End If
                Next
                Return _AboutSMSC11PFs
            End Get
            Set(ByVal value As List(Of SMSC11PF))
                _AboutSMSC11PFs = value
            End Set
        End Property
#End Region
#Region "相關T/D測溫(分鋼槽液溫)記錄 屬性:AboutSMSC21PFs"
        Private _AboutSMSC21PFs As List(Of SMSC21PF)
        ''' <summary>
        ''' 相關T/D測溫(分鋼槽液溫)記錄
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property AboutSMSC21PFs() As List(Of SMSC21PF)
            Get
                If IsNothing(_AboutSMSC21PFs) Then
                    _AboutSMSC21PFs = SMSC21PF.CDBSelect(Of SMSC21PF)("Select * From @#SMS100LB.SMSC21PF WHERE T1='" & Me.T1 & "' AND T2=" & Me.T3 & " Order by T3", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                End If
                Return _AboutSMSC21PFs
            End Get
            Set(ByVal value As List(Of SMSC21PF))
                _AboutSMSC21PFs = value
            End Set
        End Property
#End Region
#Region "相關連鑄記錄表 屬性:AboutSMSC2PF"
        Private _AboutSMSC2PF As List(Of SMSC2PF)
        ''' <summary>
        ''' 相關連鑄記錄表
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public ReadOnly Property AboutSMSC2PF() As SMSC2PF
            Get
                If IsNothing(_AboutSMSC2PF) OrElse _AboutSMSC2PF.Count = 0 Then
                    _AboutSMSC2PF = SMSC21PF.CDBSelect(Of SMSC2PF)("Select * From @#SMS100LB.SMSC2PF WHERE T1='" & Me.T1 & "' AND T2=" & Me.T3 & " Order by T3", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                End If
                If _AboutSMSC2PF.Count = 0 Then
                    Return Nothing
                End If
                _AboutSMSC2PF(0).IsFistAddNewData = False
                Return _AboutSMSC2PF(0)
            End Get
        End Property
#End Region

#Region "錯誤訊息 屬性:ErrorMessage"
        Private _ErrorMessage As String
        ''' <summary>
        ''' 錯誤訊息
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property ErrorMessage() As String
            Get
                Return _ErrorMessage
            End Get
            Set(ByVal value As String)
                _ErrorMessage = value
            End Set
        End Property

#End Region

#Region "驗證資料 方法:ValidData"
        ''' <summary>
        ''' 驗證資料
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ValidData() As Boolean
            ErrorMessage = Nothing
            If String.IsNullOrEmpty(Me.T1) OrElse Me.T1.Trim.Length < 5 Then
                ErrorMessage = "爐號欄位必須有資料且欄位必須有五位文數字!"
                Return False
            End If
            If Me.T3.ToString.Trim.Length < 7 Then
                ErrorMessage = "日期欄位必須有資料且欄位必須有七位數字!"
                Return False

            End If
            'SMSC11PF資料驗證
            For Each EachItem As SMSC11PF In Me.AboutSMSC11PFs
                If String.IsNullOrEmpty(EachItem.T3) OrElse EachItem.T3.Trim.Length < 4 Then
                    ErrorMessage = "攪拌時間欄位必須有四位數字!"
                    Return False
                End If
            Next
            For Each EachItem As SMSC11PF In Me.AboutSMSC11PFs
                '驗證是否有時間重覆狀況
                For Each EachItem1 As SMSC11PF In Me.AboutSMSC11PFs
                    If Not EachItem Is EachItem1 AndAlso EachItem.T3.Trim = EachItem1.T3.Trim Then
                        ErrorMessage = "攪拌時間欄位資料之時間不可重覆!"
                        Return False
                    End If
                Next
            Next

            Return True
        End Function
#End Region
#Region "覆寫儲存函式:CDBSave"
        ''' <summary>
        ''' 覆寫儲存
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function CDBSave() As Integer
            ErrorMessage = Nothing
            If Me.IsFistAddNewData Then
                Dim QryString As String = "Select count(*) from @#sms100lb.smsc1pf where T1='" & T1 & "' AND T3=" & T3
                If CType(Me.SQLQueryAdapterByThisObject.SelectQuery(QryString).Rows(0).Item(0), Integer) > 0 Then
                    ErrorMessage = "您輸入之爐號" & T1 & "已存在於資料庫請重新輸入!"
                    Exit Function
                End If
            End If

            Dim AlreadySaveItems As New List(Of ClassDBAS400)
            Try
                For Each EachItem In AboutSMSC11PFs
                    EachItem.T1 = Me.T1
                    EachItem.T2 = Me.T3
                    EachItem.SQLQueryAdapterByThisObject = Me.SQLQueryAdapterByThisObject
                    If EachItem.CDBSave() > 0 Then
                        AlreadySaveItems.Add(EachItem)
                    End If
                Next
                If MyBase.CDBSave() > 0 Then
                    Me.IsFistAddNewData = False
                    Return True
                End If
                Return False
            Catch ex As Exception
                For Each EachItem In AlreadySaveItems
                    EachItem.CDBDelete()
                Next
                ErrorMessage = "資料儲存發生錯誤:" & ex.ToString
                Return 0
            End Try
        End Function
#End Region
#Region "覆寫刪除函式:CDBDelete"
        Public Overrides Function CDBDelete() As Integer
            Dim DeleteQry As String = "Delete From @#SMS100LB.SMSC11PF Where T1='" & Me.T1 & "' AND T2=" & Me.T3
            Me.SQLQueryAdapterByThisObject.ExecuteNonQuery(DeleteQry)
            DeleteQry = "Delete From @#SMS100LB.SMSC12PF Where T1='" & Me.T1 & "' AND T2=" & Me.T3
            Me.SQLQueryAdapterByThisObject.ExecuteNonQuery(DeleteQry)
            Return MyBase.CDBDelete()
        End Function
#End Region

    End Class
End Namespace