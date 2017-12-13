Namespace AST500LB
    Public Class AST501PF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("AST500LB", GetType(AST501PF).Name)
        End Sub

#Region "資產編號 屬性:NUMBER"
        Private _NUMBER As System.String
        ''' <summary>
        ''' 資產編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property NUMBER() As System.String
            Get
                Return _NUMBER
            End Get
            Set(ByVal value As System.String)
                _NUMBER = value
            End Set
        End Property
#End Region
#Region "廠別 屬性:FACKIND"

        Private _FACKIND As String
        ''' <summary>
        ''' 廠別
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property FACKIND() As String
            Get
                Return _FACKIND
            End Get
            Set(ByVal value As String)
                _FACKIND = value
            End Set
        End Property

#End Region
#Region "啟始日期 屬性:SDATE"
        Private _SDATE As System.Int32
        ''' <summary>
        ''' 啟始日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property SDATE() As System.Int32
            Get
                Return _SDATE
            End Get
            Set(ByVal value As System.Int32)
                _SDATE = value
            End Set
        End Property
#End Region
#Region "保險種類 屬性:SAVKIND"
        Private _SAVKIND As System.Int32
        ''' <summary>
        ''' 保險種類
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>1.火險2.爆炸險</remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property SAVKIND() As System.Int32
            Get
                Return _SAVKIND
            End Get
            Set(ByVal value As System.Int32)
                _SAVKIND = value
            End Set
        End Property
#End Region
#Region "終止日期 屬性:EDATE"
        Private _EDATE As System.Int32
        ''' <summary>
        ''' 終止日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property EDATE() As System.Int32
            Get
                Return _EDATE
            End Get
            Set(ByVal value As System.Int32)
                _EDATE = value
            End Set
        End Property
#End Region
#Region "備註事項 屬性:MEMO"
        Private _MEMO As System.String
        ''' <summary>
        ''' 備註事項
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MEMO() As System.String
            Get
                Return _MEMO
            End Get
            Set(ByVal value As System.String)
                _MEMO = value
            End Set
        End Property
#End Region

#Region "保險種類中文 屬性:SAVKINDChinese"
        ''' <summary>
        ''' 保險種類中文
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property SAVKINDChinese() As String
            Get
                Dim ReturnValue() As String = {"aa", "bb"}

                Select Case True
                    Case Me.SAVKIND = 1
                        Return "火險"
                    Case Me.SAVKIND = 2
                        Return "爆炸險"
                    Case Else
                        Return "未知"
                End Select
            End Get
        End Property
#End Region
#Region "啟始日期日期格式 屬性:SDATEDateFormat"
        ''' <summary>
        ''' 啟始日期日期格式
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Property SDATEDateFormat() As Date
            Get
                Return (New AS400DateConverter(SDATE)).DateValue
            End Get
            Set(ByVal value As Date)
                Me.SDATE = (New AS400DateConverter(value)).TwIntegerTypeData
            End Set
        End Property
#End Region
#Region "終止日期日期格式 屬性:EDATEDateFormat"
        ''' <summary>
        ''' 終止日期日期格式
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Property EDATEDateFormat() As Date
            Get
                Return (New AS400DateConverter(EDATE)).DateValue
            End Get
            Set(ByVal value As Date)
                Me.EDATE = (New AS400DateConverter(value)).TwIntegerTypeData
            End Set
        End Property
#End Region

#Region "資產名稱 屬性:AssetName"
        Private _AssetName As String = Nothing
        ''' <summary>
        ''' 資產名稱
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AssetName() As String
            Get
                If Not String.IsNullOrEmpty(_AssetName) Then
                    Return _AssetName
                End If
                Dim GetDataType As AST101PF.FactoryEnum = AST101PF.FactoryEnum.SA
                Select Case Me.FACKIND.ToUpper
                    Case "SA"
                        GetDataType = AST101PF.FactoryEnum.SA
                    Case "AA"
                        GetDataType = AST101PF.FactoryEnum.AA
                    Case "AB"
                        GetDataType = AST101PF.FactoryEnum.AB
                    Case "QA"
                        GetDataType = AST101PF.FactoryEnum.QA
                    Case "NA"
                        GetDataType = AST101PF.FactoryEnum.NA
                    Case "RA"
                        GetDataType = AST101PF.FactoryEnum.RA
                    Case "RC"
                        GetDataType = AST101PF.FactoryEnum.RC
                    Case "RD"
                        GetDataType = AST101PF.FactoryEnum.RD
                End Select
                Dim myNumber As String = Me.NUMBER.Trim
                For Each EachItem As AST101PF In AST101PF.AllAST101PF(GetDataType)
                    If EachItem.NUMBER.Trim = myNumber Then
                        _AssetName = EachItem.NAME
                        Exit For
                    End If
                Next
                Return _AssetName
            End Get
        End Property
#End Region




    End Class
End Namespace