Namespace AST500LB
    ''' <summary>
    ''' 非消耗性物品收發檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Class AST103PF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("AST500LB", GetType(AST103PF).Name)
        End Sub

#Region "財產編號 屬性:AS301"
        Private _AS301 As System.String
        ''' <summary>
        ''' 財產編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property AS301() As System.String
            Get
                Return _AS301
            End Get
            Set(ByVal value As System.String)
                _AS301 = value
            End Set
        End Property
#End Region
#Region "序號 屬性:AS302"
        Private _AS302 As System.String
        ''' <summary>
        ''' 序號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property AS302() As System.String
            Get
                Return _AS302
            End Get
            Set(ByVal value As System.String)
                _AS302 = value
            End Set
        End Property
#End Region
#Region "請購憑證 屬性:AS303"
        Private _AS303 As System.String
        ''' <summary>
        ''' 請購憑證
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property AS303() As System.String
            Get
                Return _AS303
            End Get
            Set(ByVal value As System.String)
                _AS303 = value
            End Set
        End Property
#End Region
#Region "入帳日 屬性:AS304"
        Private _AS304 As System.Int32
        ''' <summary>
        ''' 入帳日
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property AS304() As System.Int32
            Get
                Return _AS304
            End Get
            Set(ByVal value As System.Int32)
                _AS304 = value
            End Set
        End Property
#End Region
#Region "領料單 屬性:AS305"
        Private _AS305 As System.String
        ''' <summary>
        ''' 領料單
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AS305() As System.String
            Get
                Return _AS305
            End Get
            Set(ByVal value As System.String)
                _AS305 = value
            End Set
        End Property
#End Region
#Region "部門 屬性:AS306"
        Private _AS306 As System.String
        ''' <summary>
        ''' 部門
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AS306() As System.String
            Get
                Return _AS306
            End Get
            Set(ByVal value As System.String)
                _AS306 = value
            End Set
        End Property
#End Region
#Region "數量 屬性:AS307"
        Private _AS307 As System.Int32
        ''' <summary>
        ''' 數量
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AS307() As System.Int32
            Get
                Return _AS307
            End Get
            Set(ByVal value As System.Int32)
                _AS307 = value
            End Set
        End Property
#End Region
#Region "金額 屬性:AS308"
        Private _AS308 As System.Single
        ''' <summary>
        ''' 金額
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AS308() As System.Single
            Get
                Return _AS308
            End Get
            Set(ByVal value As System.Single)
                _AS308 = value
            End Set
        End Property
#End Region
#Region "年限 屬性:AS309"
        Private _AS309 As System.Int32
        ''' <summary>
        ''' 年限
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AS309() As System.Int32
            Get
                Return _AS309
            End Get
            Set(ByVal value As System.Int32)
                _AS309 = value
            End Set
        End Property
#End Region
#Region "名稱說明 屬性:AS310"
        Private _AS310 As System.String
        ''' <summary>
        ''' 名稱說明
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AS310() As System.String
            Get
                Return _AS310
            End Get
            Set(ByVal value As System.String)
                _AS310 = value
            End Set
        End Property
#End Region
#Region "保管人員工代號 屬性:AS311"
        Private _AS311 As System.String
        ''' <summary>
        ''' 保管人員工代號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AS311() As System.String
            Get
                Return _AS311
            End Get
            Set(ByVal value As System.String)
                _AS311 = value
            End Set
        End Property
#End Region
#Region "狀態碼 屬性:AS312"
        Private _AS312 As System.String
        ''' <summary>
        ''' 01:正常 02:報廢 03:繳回 04:變賣
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AS312() As System.String
            Get
                Return _AS312
            End Get
            Set(ByVal value As System.String)
                _AS312 = value
            End Set
        End Property
#End Region
#Region "註1 屬性:AS391"
        Private _AS391 As System.String
        ''' <summary>
        ''' 註1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AS391() As System.String
            Get
                Return _AS391
            End Get
            Set(ByVal value As System.String)
                _AS391 = value
            End Set
        End Property
#End Region
#Region "註2 屬性:AS392"
        Private _AS392 As System.String
        ''' <summary>
        ''' 註2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AS392() As System.String
            Get
                Return _AS392
            End Get
            Set(ByVal value As System.String)
                _AS392 = value
            End Set
        End Property
#End Region
#Region "備註1 屬性:AS393"
        Private _AS393 As System.String
        ''' <summary>
        ''' 備註1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AS393() As System.String
            Get
                Return _AS393
            End Get
            Set(ByVal value As System.String)
                _AS393 = value
            End Set
        End Property
#End Region

#Region "入帳日_日期格式 屬性:AS304_DateTimeFormat"
        ''' <summary>
        ''' 入帳日
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Property AS304_DateTimeFormat() As DateTime
            Get
                Try
                    Return (New CompanyORMDB.AS400DateConverter(AS304)).DateValue
                Catch ex As Exception
                    Return Nothing
                End Try
            End Get
            Set(ByVal value As DateTime)
                AS304 = (New CompanyORMDB.AS400DateConverter(value)).TwIntegerTypeData
            End Set
        End Property
#End Region
#Region "保管人姓名 屬性:AS311_EmployeeName"
        ''' <summary>
        ''' 保管人姓名
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AS311_EmployeeName() As String
            Get
                If IsNothing(AS311) OrElse String.IsNullOrEmpty(AS311) Then
                    Return Nothing
                End If
                Dim QueryString As String = "Select PT0101,PT0102 From @#" & (New PLT500LB.PTM010PF).CDBLibraryName & ".PTM010PF Where PT0102='" & Me.AS311.Replace("'", Nothing) & "'"
                Dim SelectedEemployees As List(Of PLT500LB.PTM010PF) = ClassDBAS400.CDBSelect(Of CompanyORMDB.PLT500LB.PTM010PF)(QueryString, Me.CDBCurrentUseSQLQueryAdapter)
                If SelectedEemployees.Count = 0 Then
                    Return Nothing
                End If
                Return SelectedEemployees(0).PT0101
            End Get
        End Property
#End Region
#Region "狀態碼中文解釋 屬性:AS312_Explain"
        ''' <summary>
        ''' 狀態碼中文解釋
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AS312_Explain() As String
            Get
                Return GetAS312_Explain(Me.AS312)
            End Get
        End Property
        ''' <summary>
        ''' 狀態碼中文解釋
        ''' </summary>
        ''' <param name="SourceCode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetAS312_Explain(ByVal SourceCode As String) As String
            Select Case True
                Case SourceCode = "01"
                    Return "使用中"
                Case SourceCode = "02"
                    Return "已報廢"
                Case SourceCode = "03"
                    Return "已繳回"
                Case SourceCode = "04"
                    Return "變賣"
                Case Else
                    Return Nothing
            End Select
        End Function
#End Region


    End Class
End Namespace