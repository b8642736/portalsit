Namespace TABLE
    Public Class TABLE7PF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("""TABLE""", GetType(TABLE7PF).Name)
        End Sub

#Region "生產線 屬性:TB701"
        Private _TB701 As System.String
        ''' <summary>
        ''' 生產線
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property TB701() As System.String
            Get
                Return _TB701
            End Get
            Set(ByVal value As System.String)
                _TB701 = value
            End Set
        End Property
#End Region
#Region "日期 屬性:TB702"
        Private _TB702 As System.Int32
        ''' <summary>
        ''' 日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property TB702() As System.Int32
            Get
                Return _TB702
            End Get
            Set(ByVal value As System.Int32)
                _TB702 = value
            End Set
        End Property
#End Region
#Region "早班 屬性:TB703"
        Private _TB703 As System.String
        ''' <summary>
        ''' 早班
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TB703() As System.String
            Get
                Return _TB703
            End Get
            Set(ByVal value As System.String)
                _TB703 = value
            End Set
        End Property
#End Region
#Region "中班 屬性:TB704"
        Private _TB704 As System.String
        ''' <summary>
        ''' 中班
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TB704() As System.String
            Get
                Return _TB704
            End Get
            Set(ByVal value As System.String)
                _TB704 = value
            End Set
        End Property
#End Region
#Region "晚班 屬性:TB705"
        Private _TB705 As System.String
        ''' <summary>
        ''' 晚班
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TB705() As System.String
            Get
                Return _TB705
            End Get
            Set(ByVal value As System.String)
                _TB705 = value
            End Set
        End Property
#End Region
#Region "帶班工號－早 屬性:TB706"
        Private _TB706 As System.String
        ''' <summary>
        ''' 帶班工號－早
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TB706() As System.String
            Get
                Return _TB706
            End Get
            Set(ByVal value As System.String)
                _TB706 = value
            End Set
        End Property
#End Region
#Region "帶班工號－中 屬性:TB707"
        Private _TB707 As System.String
        ''' <summary>
        ''' 帶班工號－中
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TB707() As System.String
            Get
                Return _TB707
            End Get
            Set(ByVal value As System.String)
                _TB707 = value
            End Set
        End Property
#End Region
#Region "帶班工號－晚 屬性:TB708"
        Private _TB708 As System.String
        ''' <summary>
        ''' 帶班工號－晚
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TB708() As System.String
            Get
                Return _TB708
            End Get
            Set(ByVal value As System.String)
                _TB708 = value
            End Set
        End Property
#End Region

#Region "取得某時間點之班別 方法:GetClassNumber"
        ''' <summary>
        ''' 取得某時間點之班別
        ''' </summary>
        ''' <param name="GetTime"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetClassNumber(ByVal GetLineName As String, ByVal GetTime As DateTime) As String
            Dim ReturnValue As String = Nothing
            Dim QryString As String = "Select * from @#""TABLE"".TABLE7PF WHERE TB702=" & (New CompanyORMDB.AS400DateConverter(GetTime.Date)).TwIntegerTypeData & " AND TB701='" & GetLineName & "'"
            Dim SearchResult As List(Of TABLE7PF) = TABLE7PF.CDBSelect(Of TABLE7PF)(QryString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            If SearchResult.Count = 0 Then
                Return Nothing
            End If
            Dim Time1 As DateTime = GetTime.Date.AddHours(8)
            Dim Time2 As DateTime = GetTime.Date.AddHours(16)
            Dim Time3 As DateTime = GetTime.Date.AddDays(1)
            Select Case True
                Case GetTime >= Time1 AndAlso GetTime < Time2
                    Return SearchResult(0).TB703
                Case GetTime >= Time2 AndAlso GetTime < Time3
                    Return SearchResult(0).TB704
                Case GetTime >= Time3 AndAlso GetTime < GetTime.Date.AddDays(1)
                    Return SearchResult(0).TB705
                Case Else
                    Return "--"
            End Select
            Return Nothing
        End Function
#End Region

    End Class
End Namespace