Namespace AST501LB

    Public Class AST001PFEx
        Inherits AST501LB.AST001PF

        Sub New()
            Me.CDBMemberName = Nothing
            If IsNothing(Me.AboutAST106PF) Then
                Me.AboutAST106PF = New AST501LB.AST106PF
                AboutAST106PF.SEQ = 1
            End If
        End Sub


#Region "資產編號 屬性:NUMBER"
        Private _NUMBER As System.String
        ''' <summary>
        ''' 資產編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Overrides Property NUMBER() As System.String
            Get
                Return _NUMBER
            End Get
            Set(ByVal value As System.String)
                _NUMBER = value
            End Set
        End Property
#End Region
#Region "序號 屬性:SEQ"
        Private _SEQ As System.Int32
        ''' <summary>
        ''' 序號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property SEQ() As System.Int32
            Get
                Return _SEQ
            End Get
            Set(ByVal value As System.Int32)
                _SEQ = value
            End Set
        End Property
#End Region
#Region "單位代號 屬性:DEPTSA"
        Private _DEPTSA As System.String
        ''' <summary>
        ''' 單位代號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property DEPTSA() As System.String
            Get
                Return _DEPTSA
            End Get
            Set(ByVal value As System.String)
                _DEPTSA = value
            End Set
        End Property
#End Region
#Region "入帳編號 屬性:PNO"
        Private _PNO As System.String
        ''' <summary>
        ''' 入帳編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property PNO() As System.String
            Get
                Return _PNO
            End Get
            Set(ByVal value As System.String)
                _PNO = value
            End Set
        End Property
#End Region
#Region "規格1 屬性:SPEC1"
        Private _SPEC1 As System.String
        ''' <summary>
        ''' 規格1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property SPEC1() As System.String
            Get
                Return _SPEC1
            End Get
            Set(ByVal value As System.String)
                _SPEC1 = value
            End Set
        End Property
#End Region
#Region "規格2 屬性:SPEC2"
        Private _SPEC2 As System.String
        ''' <summary>
        ''' 規格2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property SPEC2() As System.String
            Get
                Return _SPEC2
            End Get
            Set(ByVal value As System.String)
                _SPEC2 = value
            End Set
        End Property
#End Region
#Region "供應廠商 屬性:MTSV01"
        Private _MTSV01 As System.String
        ''' <summary>
        ''' 供應廠商
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property MTSV01() As System.String
            Get
                Return _MTSV01
            End Get
            Set(ByVal value As System.String)
                _MTSV01 = value
            End Set
        End Property
#End Region


#Region "相關AST106PF 屬性:AboutAST106PF"
        Private _AboutAST106PF As AST501LB.AST106PF
        Private _AboutAST106PFIsSearched As Boolean = False
        ''' <summary>
        ''' 相關AST106PF
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property AboutAST106PF() As AST501LB.AST106PF
            Get
                If IsNothing(_AboutAST106PF) And Not String.IsNullOrEmpty(Me.CDBMemberName) AndAlso _AboutAST106PFIsSearched = False Then
                    Dim Qry As String = "Select * from @#AST501LB.AST106PF" & " WHERE NUMBER='" & Me.NUMBER & "'"
                    Dim SearchResult As List(Of AST501LB.AST106PF) = AST501LB.AST106PF.CDBSelect(Of AST501LB.AST106PF)(Qry, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                    If SearchResult.Count > 0 Then
                        _AboutAST106PF = SearchResult(0)
                    End If
                    _AboutAST106PFIsSearched = True
                End If
                Return _AboutAST106PF
            End Get
            Set(ByVal value As AST501LB.AST106PF)
                _AboutAST106PF = value
                _AboutAST106PFIsSearched = False
            End Set
        End Property

#End Region
#Region "相關供應商資料  屬性:AboutMTSV01PF"
        Private _AboutMTSV01PF As MTS600LB.MTSBC1PF
        Private _AboutMTSV01PFIsSearched As Boolean = False
        ''' <summary>
        ''' 相關供應商資料
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property AboutMTSV01PF() As MTS600LB.MTSBC1PF
            Get
                If IsNothing(_AboutMTSV01PF) AndAlso _AboutMTSV01PFIsSearched = False Then
                    If Not String.IsNullOrEmpty(Me.MTSV01) AndAlso Me.MTSV01.Trim.Length > 0 Then
                        Dim Qry As String = "SELECT COUNT(*) FROM @#MTS600LB.MTSV01PF WHERE MTSV01='" & Me.MTSV01 & "'"
                        Dim SearchResult As List(Of MTS600LB.MTSBC1PF) = MTS600LB.MTSBC1PF.CDBSelect(Of MTS600LB.MTSBC1PF)(Qry, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                        If SearchResult.Count > 0 Then
                            _AboutMTSV01PF = SearchResult(0)
                        End If
                    End If
                    _AboutMTSV01PFIsSearched = True
                End If
                Return _AboutMTSV01PF
            End Get
            Private Set(ByVal value As MTS600LB.MTSBC1PF)
                _AboutMTSV01PF = value
                _AboutMTSV01PFIsSearched = False
            End Set
        End Property


#End Region
#Region "讀取AST106PF至本物件 函式:ReadAST106PFToMe"
        ''' <summary>
        ''' 讀取AST106PF至本物件
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub ReadAST106PFToMe()
            _AboutAST106PFIsSearched = False
            AboutAST106PF = Nothing
            With Me
                .SEQ = 0
                .DEPTSA = Nothing
                .PNO = Nothing
                .SPEC1 = Nothing
                .SPEC2 = Nothing
                .MTSV01 = Nothing
                If Not IsNothing(Me.AboutAST106PF) Then
                    .SEQ = Me.AboutAST106PF.SEQ
                    .DEPTSA = Me.AboutAST106PF.DEPTSA
                    .PNO = Me.AboutAST106PF.PNO
                    .SPEC1 = Me.AboutAST106PF.SPEC1
                    .SPEC2 = Me.AboutAST106PF.SPEC2
                    .MTSV01 = Me.AboutAST106PF.MTSV01
                    .CDBMemberName = Me.CDBMemberName
                End If
            End With
        End Sub
#End Region

#Region "覆寫新增 函式:CDBInsert"
        ''' <summary>
        ''' 覆寫新增
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function CDBInsert() As Integer
            If String.IsNullOrEmpty(Me.CDBMemberName) Then
                Return 0
            End If
            With Me.AboutAST106PF
                .NUMBER = Me.NUMBER
                .SEQ = Me.SEQ
                .DEPTSA = Me.DEPTSA
                .PNO = Me.PNO
                .MTSV01 = Me.MTSV01
                .SPEC1 = Me.SPEC1
                .SPEC2 = Me.SPEC2
                .CDBMemberName = Me.CDBMemberName
                .SQLQueryAdapterByThisObject = Me.SQLQueryAdapterByThisObject
            End With
            Me.AboutAST106PF.CDBMemberName = Me.CDBMemberName
            If Not IsNothing(Me.AboutAST106PF) AndAlso Me.AboutAST106PF.CDBInsert() > 0 Then
                Return MyBase.CDBInsert
            End If
            Return 0
        End Function
#End Region
#Region "覆寫儲存 函式:CDBUpdate"
        ''' <summary>
        ''' 覆寫儲存
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function CDBUpdate() As Integer
            If String.IsNullOrEmpty(Me.CDBMemberName) Then
                Return 0
            End If
            If Me.NUMBER <> Me.AboutAST106PF.NUMBER Then
                Me.AboutAST106PF.CDBMemberName = Me.CDBMemberName
                Me.AboutAST106PF.SQLQueryAdapterByThisObject = Me.SQLQueryAdapterByThisObject
                Me.AboutAST106PF.CDBDelete()
            End If
            With Me.AboutAST106PF
                .NUMBER = Me.NUMBER
                .SEQ = Me.SEQ
                .DEPTSA = Me.DEPTSA
                .PNO = Me.PNO
                .MTSV01 = Me.MTSV01
                .SPEC1 = Me.SPEC1
                .SPEC2 = Me.SPEC2
                .CDBMemberName = Me.CDBMemberName
                .SQLQueryAdapterByThisObject = Me.SQLQueryAdapterByThisObject
            End With
            If Not IsNothing(Me.AboutAST106PF) AndAlso Me.AboutAST106PF.CDBSave() > 0 Then
                Return MyBase.CDBUpdate()
            End If
            Return 0
        End Function
#End Region
#Region "覆寫刪除 函式:CDBDelete"
        ''' <summary>
        ''' 覆寫刪除
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function CDBDelete() As Integer
            If String.IsNullOrEmpty(Me.CDBMemberName) Then
                Return 0
            End If
            If Not IsNothing(Me.AboutAST106PF) Then
                ReadAST106PFToMe()
                Me.AboutAST106PF.NUMBER = Me.NUMBER
                Me.AboutAST106PF.SEQ = Me.SEQ
                Me.AboutAST106PF.CDBMemberName = Me.CDBMemberName
                Me.AboutAST106PF.SQLQueryAdapterByThisObject = Me.SQLQueryAdapterByThisObject
                If Me.AboutAST106PF.CDBDelete() > 0 Then
                    Return MyBase.CDBDelete()
                End If
            End If
            Return 0
        End Function
#End Region


    End Class
End Namespace
