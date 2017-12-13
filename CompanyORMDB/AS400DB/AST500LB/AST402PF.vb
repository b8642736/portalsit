Namespace AST500LB
Public Class AST402PF
	Inherits ClassDBAS400

	Sub New()
            MyBase.New("AST500LB", GetType(AST402PF).Name)
            ISWAITPRT = 1
	End Sub

#Region "移出單位 屬性:OUTDEPT"
	Private _OUTDEPT As System.String
	''' <summary>
	''' 移出單位
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property OUTDEPT () As System.String
		Get
			Return _OUTDEPT
		End Get
		Set(Byval value as System.String)
			_OUTDEPT = value
		End Set
	End Property
#End Region
#Region "移入單位 屬性:INDEPT"
	Private _INDEPT As System.String
	''' <summary>
	''' 移入單位
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property INDEPT () As System.String
		Get
			Return _INDEPT
		End Get
		Set(Byval value as System.String)
			_INDEPT = value
		End Set
	End Property
#End Region
#Region "資料建立日期 屬性:CDATADATE"
	Private _CDATADATE As System.String
	''' <summary>
	''' 資料建立日期
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property CDATADATE () As System.String
		Get
			Return _CDATADATE
		End Get
		Set(Byval value as System.String)
			_CDATADATE = value
		End Set
	End Property
#End Region
#Region "資產編號 屬性:NUMBER"
	Private _NUMBER As System.String
	''' <summary>
	''' 資產編號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property NUMBER () As System.String
		Get
			Return _NUMBER
		End Get
		Set(Byval value as System.String)
			_NUMBER = value
		End Set
	End Property
#End Region
#Region "資產類別 屬性:KIND"
	Private _KIND As System.String
	''' <summary>
	''' 資產類別
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property KIND () As System.String
		Get
			Return _KIND
		End Get
		Set(Byval value as System.String)
			_KIND = value
		End Set
	End Property
#End Region
#Region "資產名稱 屬性:NAME"
	Private _NAME As System.String
	''' <summary>
	''' 資產名稱
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property NAME () As System.String
		Get
			Return _NAME
		End Get
		Set(Byval value as System.String)
			_NAME = value
		End Set
	End Property
#End Region
#Region "數量 屬性:QUANT"
	Private _QUANT As System.Int32
	''' <summary>
	''' 數量
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QUANT () As System.Int32
		Get
			Return _QUANT
		End Get
		Set(Byval value as System.Int32)
			_QUANT = value
		End Set
	End Property
#End Region
#Region "出帳資產編號 屬性:REFORGNUM"
	Private _REFORGNUM As System.String
	''' <summary>
	''' 出帳資產編號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property REFORGNUM () As System.String
		Get
			Return _REFORGNUM
		End Get
		Set(Byval value as System.String)
			_REFORGNUM = value
		End Set
	End Property
#End Region
#Region "入帳資產總值 屬性:TVALUE"
	Private _TVALUE As System.Single
	''' <summary>
	''' 入帳資產總值
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property TVALUE () As System.Single
		Get
			Return _TVALUE
		End Get
		Set(Byval value as System.Single)
			_TVALUE = value
		End Set
	End Property
#End Region
#Region "移轉時殘值 屬性:TDEPR"
	Private _TDEPR As System.Single
	''' <summary>
	''' 移轉時殘值
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property TDEPR () As System.Single
		Get
			Return _TDEPR
		End Get
		Set(Byval value as System.Single)
			_TDEPR = value
		End Set
	End Property
#End Region
#Region "移轉後預估年限 屬性:TDUEDAY"
	Private _TDUEDAY As System.Int32
	''' <summary>
	''' 移轉後預估年限
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property TDUEDAY () As System.Int32
		Get
			Return _TDUEDAY
		End Get
		Set(Byval value as System.Int32)
			_TDUEDAY = value
		End Set
	End Property
#End Region
#Region "編修資料工號 屬性:EDTUSRID"
	Private _EDTUSRID As System.String
	''' <summary>
	''' 編修資料工號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EDTUSRID () As System.String
		Get
			Return _EDTUSRID
		End Get
		Set(Byval value as System.String)
			_EDTUSRID = value
		End Set
	End Property
#End Region
#Region "設備使用者姓名 屬性:USERNAME"
	Private _USERNAME As System.String
	''' <summary>
	''' 設備使用者姓名
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property USERNAME () As System.String
		Get
			Return _USERNAME
		End Get
		Set(Byval value as System.String)
			_USERNAME = value
		End Set
	End Property
#End Region
#Region "設備編號 屬性:EQUID"
	Private _EQUID As System.String
	''' <summary>
	''' 設備編號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EQUID () As System.String
		Get
			Return _EQUID
		End Get
		Set(Byval value as System.String)
			_EQUID = value
		End Set
	End Property
#End Region
#Region "設備IP 屬性:EQUIP"
	Private _EQUIP As System.String
	''' <summary>
	''' 設備IP
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EQUIP () As System.String
		Get
			Return _EQUIP
		End Get
		Set(Byval value as System.String)
			_EQUIP = value
		End Set
	End Property
#End Region
#Region "資訊處設備ID 屬性:MISEQUID"
	Private _MISEQUID As System.String
	''' <summary>
	''' 資訊處設備ID
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MISEQUID () As System.String
		Get
			Return _MISEQUID
		End Get
		Set(Byval value as System.String)
			_MISEQUID = value
		End Set
	End Property
#End Region
#Region "備註 屬性:MEMO"
	Private _MEMO As System.String
	''' <summary>
	''' 備註
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MEMO () As System.String
		Get
			Return _MEMO
		End Get
		Set(Byval value as System.String)
			_MEMO = value
		End Set
	End Property
#End Region
#Region "印表群編號 屬性:PRINTGUP"
        Private _PRINTGUP As String
        ''' <summary>
        ''' 印表群編號 輸入者工號+列印順序
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PRINTGUP() As String
            Get
                Return _PRINTGUP
            End Get
            Set(ByVal value As String)
                _PRINTGUP = value
            End Set
        End Property

#End Region
#Region "是否等待列印 屬性:ISWAITPRT"
        Private _ISWAITPRT As Integer
        ''' <summary>
        ''' 是否等待列印
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ISWAITPRT() As Integer
            Get
                Return _ISWAITPRT
            End Get
            Set(ByVal value As Integer)
                _ISWAITPRT = value
            End Set
        End Property

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
                    Dim QryString As String = "Select * From " & (New AST106PF).CDBFullAS400DBPath & " Where Number='" & Me.NUMBER & "' AND SEQ=1"
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
#Region "目前相關使用單位 屬性:About_AST106PF_ASTFSA"
        Private _About_AST106PF_ASTFSA As String
        ''' <summary>
        ''' 目前相關使用單位
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Property About_AST106PF_ASTFSA As String
            Get
                If String.IsNullOrEmpty(_About_AST106PF_ASTFSA) AndAlso Not IsNothing(About_AST106PF) Then
                    _About_AST106PF_ASTFSA = About_AST106PF.DEPTSA
                End If
                Return _About_AST106PF_ASTFSA
            End Get
            Set(value As String)
                _About_AST106PF_ASTFSA = value
            End Set
        End Property
#End Region


#Region "新增/修改資料檢核錯誤訊息 屬性:InsertUpdateDataCheckErrorMessage"
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Property InsertUpdateDataCheckErrorMessage As String
#End Region
#Region "新增/修改資料檢核 函式:InsertUpdateDataCheck"
        Public Function InsertDataCheck() As Boolean
            InsertUpdateDataCheckErrorMessage = Nothing

        End Function
#End Region
    End Class
End Namespace