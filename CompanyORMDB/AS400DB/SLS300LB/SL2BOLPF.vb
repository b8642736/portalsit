Namespace SLS300LB
    ''' <summary>
    ''' 提貨單檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SL2BOLPF
        Inherits ClassDBAS400

        Sub New()
            'MyBase.New("SLS300LB", GetType(SL2BOLPF).Name)
            MyBase.New("TESTKUKU", GetType(SL2BOLPF).Name, New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.WebService))
        End Sub

#Region "提貨單日期 屬性:BOL01"
        Private _BOL01 As System.String
        ''' <summary>
        ''' 提貨單日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL01() As System.String
            Get
                Return _BOL01
            End Get
            Set(ByVal value As System.String)
                _BOL01 = value
            End Set
        End Property
#End Region
#Region "提貨單編號 屬性:BOL02"
        Private _BOL02 As System.String
        ''' <summary>
        ''' 提貨單編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property BOL02() As System.String
            Get
                Return _BOL02
            End Get
            Set(ByVal value As System.String)
                _BOL02 = value
            End Set
        End Property
#End Region
#Region "報價單編號 屬性:BOL03"
        Private _BOL03 As System.String
        ''' <summary>
        ''' 報價單編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL03() As System.String
            Get
                Return _BOL03
            End Get
            Set(ByVal value As System.String)
                _BOL03 = value
            End Set
        End Property
#End Region
#Region "送交日期 屬性:BOL04"
        Private _BOL04 As System.String
        ''' <summary>
        ''' 送交日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL04() As System.String
            Get
                Return _BOL04
            End Get
            Set(ByVal value As System.String)
                _BOL04 = value
            End Set
        End Property
#End Region
#Region "鋼種 屬性:BOL05"
        Private _BOL05 As System.String
        ''' <summary>
        ''' 鋼種
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL05() As System.String
            Get
                Return _BOL05
            End Get
            Set(ByVal value As System.String)
                _BOL05 = value
            End Set
        End Property
#End Region
#Region "表面 屬性:BOL06"
        Private _BOL06 As System.String
        ''' <summary>
        ''' 表面
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL06() As System.String
            Get
                Return _BOL06
            End Get
            Set(ByVal value As System.String)
                _BOL06 = value
            End Set
        End Property
#End Region
#Region "厚度 屬性:BOL07"
        Private _BOL07 As System.Single
        ''' <summary>
        ''' 厚度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL07() As System.Single
            Get
                Return _BOL07
            End Get
            Set(ByVal value As System.Single)
                _BOL07 = value
            End Set
        End Property
#End Region
#Region "寬度 屬性:BOL08"
        Private _BOL08 As System.Int32
        ''' <summary>
        ''' 寬度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL08() As System.Int32
            Get
                Return _BOL08
            End Get
            Set(ByVal value As System.Int32)
                _BOL08 = value
            End Set
        End Property
#End Region
#Region "毛、修邊 屬性:BOL09"
        Private _BOL09 As System.String
        ''' <summary>
        ''' 毛、修邊
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL09() As System.String
            Get
                Return _BOL09
            End Get
            Set(ByVal value As System.String)
                _BOL09 = value
            End Set
        End Property
#End Region
#Region "長度 屬性:BOL10"
        Private _BOL10 As System.Int32
        ''' <summary>
        ''' 長度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL10() As System.Int32
            Get
                Return _BOL10
            End Get
            Set(ByVal value As System.Int32)
                _BOL10 = value
            End Set
        End Property
#End Region
#Region "內徑 屬性:BOL11"
        Private _BOL11 As System.Int32
        ''' <summary>
        ''' 內徑
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL11() As System.Int32
            Get
                Return _BOL11
            End Get
            Set(ByVal value As System.Int32)
                _BOL11 = value
            End Set
        End Property
#End Region
#Region "片數 屬性:BOL12"
        Private _BOL12 As System.Int32
        ''' <summary>
        ''' 片數
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL12() As System.Int32
            Get
                Return _BOL12
            End Get
            Set(ByVal value As System.Int32)
                _BOL12 = value
            End Set
        End Property
#End Region
#Region "捲、片 屬性:BOL13"
        Private _BOL13 As System.String
        ''' <summary>
        ''' 捲、片
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL13() As System.String
            Get
                Return _BOL13
            End Get
            Set(ByVal value As System.String)
                _BOL13 = value
            End Set
        End Property
#End Region
#Region "淨重TON 屬性:BOL14"
        Private _BOL14 As Double
        ''' <summary>
        ''' 淨重TON
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL14() As Double
            Get
                Return _BOL14
            End Get
            Set(ByVal value As Double)
                _BOL14 = value
            End Set
        End Property
#End Region
#Region "繳庫單編號 屬性:BOL15"
        Private _BOL15 As System.String
        ''' <summary>
        ''' 繳庫單編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL15() As System.String
            Get
                Return _BOL15
            End Get
            Set(ByVal value As System.String)
                _BOL15 = value
            End Set
        End Property
#End Region
#Region "鋼捲編號-1 屬性:BOL16"
        Private _BOL16 As System.String
        ''' <summary>
        ''' 鋼捲編號-1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property BOL16() As System.String
            Get
                Return _BOL16
            End Get
            Set(ByVal value As System.String)
                _BOL16 = value
            End Set
        End Property
#End Region
#Region "鋼捲編號-2 屬性:BOL17"
        Private _BOL17 As System.String
        ''' <summary>
        ''' 鋼捲編號-2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property BOL17() As System.String
            Get
                Return _BOL17
            End Get
            Set(ByVal value As System.String)
                _BOL17 = value
            End Set
        End Property
#End Region
#Region "等級 屬性:BOL18"
        Private _BOL18 As System.String
        ''' <summary>
        ''' 等級
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL18() As System.String
            Get
                Return _BOL18
            End Get
            Set(ByVal value As System.String)
                _BOL18 = value
            End Set
        End Property
#End Region
#Region "發貨員員工編號 屬性:BOL19"
        Private _BOL19 As System.String
        ''' <summary>
        ''' 發貨員員工編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL19() As System.String
            Get
                Return _BOL19
            End Get
            Set(ByVal value As System.String)
                _BOL19 = value
            End Set
        End Property
#End Region
#Region "車號 屬性:BOL20"
        Private _BOL20 As System.String
        ''' <summary>
        ''' 車號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL20() As System.String
            Get
                Return _BOL20
            End Get
            Set(ByVal value As System.String)
                _BOL20 = value
            End Set
        End Property
#End Region
#Region "一級品金額 屬性:BOL21"
        Private _BOL21 As System.Int32
        ''' <summary>
        ''' 一級品金額
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL21() As System.Int32
            Get
                Return _BOL21
            End Get
            Set(ByVal value As System.Int32)
                _BOL21 = value
            End Set
        End Property
#End Region
#Region "二級品金額 屬性:BOL22"
        Private _BOL22 As System.Int32
        ''' <summary>
        ''' 二級品金額
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL22() As System.Int32
            Get
                Return _BOL22
            End Get
            Set(ByVal value As System.Int32)
                _BOL22 = value
            End Set
        End Property
#End Region
#Region "三級品金額 屬性:BOL23"
        Private _BOL23 As System.Int32
        ''' <summary>
        ''' 三級品金額
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL23() As System.Int32
            Get
                Return _BOL23
            End Get
            Set(ByVal value As System.Int32)
                _BOL23 = value
            End Set
        End Property
#End Region
#Region "頭尾料金額 屬性:BOL24"
        Private _BOL24 As System.Int32
        ''' <summary>
        ''' 頭尾料金額
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL24() As System.Int32
            Get
                Return _BOL24
            End Get
            Set(ByVal value As System.Int32)
                _BOL24 = value
            End Set
        End Property
#End Region
#Region "邊緣料金額 屬性:BOL25"
        Private _BOL25 As System.Int32
        ''' <summary>
        ''' 邊緣料金額
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL25() As System.Int32
            Get
                Return _BOL25
            End Get
            Set(ByVal value As System.Int32)
                _BOL25 = value
            End Set
        End Property
#End Region
#Region "廢料金額 屬性:BOL26"
        Private _BOL26 As System.Int32
        ''' <summary>
        ''' 廢料金額
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL26() As System.Int32
            Get
                Return _BOL26
            End Get
            Set(ByVal value As System.Int32)
                _BOL26 = value
            End Set
        End Property
#End Region
#Region "總金額 屬性:BOL27"
        Private _BOL27 As Double
        ''' <summary>
        ''' 總金額
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL27() As Double
            Get
                Return _BOL27
            End Get
            Set(ByVal value As Double)
                _BOL27 = value
            End Set
        End Property
#End Region
#Region "管料折扣 屬性:BOL28"
        Private _BOL28 As System.Int32
        ''' <summary>
        ''' 管料折扣
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL28() As System.Int32
            Get
                Return _BOL28
            End Get
            Set(ByVal value As System.Int32)
                _BOL28 = value
            End Set
        End Property
#End Region
#Region "LEEWAY比例--A1 屬性:BOL29"
        Private _BOL29 As System.Single
        ''' <summary>
        ''' LEEWAY比例--A1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL29() As System.Single
            Get
                Return _BOL29
            End Get
            Set(ByVal value As System.Single)
                _BOL29 = value
            End Set
        End Property
#End Region
#Region "LEEWAY比例--A2 屬性:BOL30"
        Private _BOL30 As System.Single
        ''' <summary>
        ''' LEEWAY比例--A2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL30() As System.Single
            Get
                Return _BOL30
            End Get
            Set(ByVal value As System.Single)
                _BOL30 = value
            End Set
        End Property
#End Region
#Region "一級品差價 屬性:BOL33"
        Private _BOL33 As System.Int32
        ''' <summary>
        ''' 一級品差價
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL33() As System.Int32
            Get
                Return _BOL33
            End Get
            Set(ByVal value As System.Int32)
                _BOL33 = value
            End Set
        End Property
#End Region
#Region "二級品差價 屬性:BOL34"
        Private _BOL34 As System.Int32
        ''' <summary>
        ''' 二級品差價
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL34() As System.Int32
            Get
                Return _BOL34
            End Get
            Set(ByVal value As System.Int32)
                _BOL34 = value
            End Set
        End Property
#End Region
#Region "三級品差價 屬性:BOL35"
        Private _BOL35 As System.Int32
        ''' <summary>
        ''' 三級品差價
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL35() As System.Int32
            Get
                Return _BOL35
            End Get
            Set(ByVal value As System.Int32)
                _BOL35 = value
            End Set
        End Property
#End Region
#Region "儲區位置 屬性:BOL31"
        Private _BOL31 As System.String
        ''' <summary>
        ''' 儲區位置
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL31() As System.String
            Get
                Return _BOL31
            End Get
            Set(ByVal value As System.String)
                _BOL31 = value
            End Set
        End Property
#End Region
#Region "毛重KG 屬性:BOL32"
        Private _BOL32 As System.Int32
        ''' <summary>
        ''' 毛重KG
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL32() As System.Int32
            Get
                Return _BOL32
            End Get
            Set(ByVal value As System.Int32)
                _BOL32 = value
            End Set
        End Property
#End Region
#Region "CODE - 1 屬性:BOL91"
        Private _BOL91 As System.String
        ''' <summary>
        ''' CODE - 1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL91() As System.String
            Get
                Return _BOL91
            End Get
            Set(ByVal value As System.String)
                _BOL91 = value
            End Set
        End Property
#End Region
#Region "CODE - 2 屬性:BOL92"
        Private _BOL92 As System.String
        ''' <summary>
        ''' CODE - 2(' ' OR 'F':內銷 'E':直接外銷 'O':間接外銷)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL92() As System.String
            Get
                Return _BOL92
            End Get
            Set(ByVal value As System.String)
                _BOL92 = value
            End Set
        End Property
#End Region
#Region "CODE - 3 屬性:BOL93"
        Private _BOL93 As System.String
        ''' <summary>
        ''' CODE - 3
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL93() As System.String
            Get
                Return _BOL93
            End Get
            Set(ByVal value As System.String)
                _BOL93 = value
            End Set
        End Property
#End Region
#Region "CODE - 4 屬性:BOL94"
        Private _BOL94 As System.String
        ''' <summary>
        ''' CODE - 4
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BOL94() As System.String
            Get
                Return _BOL94
            End Get
            Set(ByVal value As System.String)
                _BOL94 = value
            End Set
        End Property
#End Region

#Region "是否已提貨 屬性:IsAlreadyOutOfFactory"
        ''' <summary>
        ''' 是否已提貨
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property IsAlreadyOutOfFactory() As Boolean
            Get
                Return Me.CarNumber.Trim.Length > 0
            End Get

        End Property
#End Region
#Region "是否為內銷 屬性:IsHomeSell"
        ''' <summary>
        ''' 是否為內銷
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property IsHomeSell() As Boolean
            Get
                Return Me.BOL92 = " " Or Me.BOL92.ToUpper = "F"
            End Get
        End Property
#End Region
#Region "鋼捲編號  屬性:CoilNumber"
        ''' <summary>
        ''' 鋼捲編號
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property CoilNumber() As String
            Get
                Return Me.BOL16.Trim & BOL17.Trim
            End Get
        End Property
#End Region
#Region "司機車號 屬性:CarNumber"

        ''' <summary>
        ''' 司機車號
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property CarNumber() As String
            Get
                Return Me.BOL20.PadLeft(7).Substring(0, 7)
            End Get
            Set(ByVal value As String)
                If IsNothing(value) Then
                    value = ""
                End If
                Me.BOL20 = value.PadLeft(7).Substring(0, 7) & Me.BOL20.Substring(7, 3)
            End Set
        End Property

#End Region
#Region "交送日期日期格式 屬性:BOL04_DateFormat"
        ''' <summary>
        ''' 交送日期日期格式
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property BOL04_DateFormat() As Nullable(Of Date)
            Get
                If Me.BOL04.Trim.Length = 0 Then
                    Return Nothing
                End If
                Try
                    Return New AS400DateConverter(Me.BOL04).DateValue
                Catch ex As Exception
                    Return Nothing
                End Try
            End Get
        End Property
#End Region
#Region "是否可即刻出廠(輸入鋼捲出貨車輛登入)　屬性:IsCanOutFactoryNow"
        ''' <summary>
        ''' 是否可即刻出廠(輸入鋼捲出貨車輛登入)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property IsCanOutFactoryNow() As Boolean
            Get
                Dim GetCarNumber = String.Copy(Me.CarNumber).Trim
                If Me.IsHomeSell Then
                    Select Case True
                        Case Me.BOL04.Trim.Length <> 0
                            Me.CanNotOutFactoryNowReason = "已有送交日期:" & Me.BOL04 : Return False
                        Case GetCarNumber.Length <> 0
                            Me.CanNotOutFactoryNowReason = "已有送交車號:" & GetCarNumber : Return False
                    End Select
                Else
                    Dim SendDate As Nullable(Of DateTime) = Me.BOL04_DateFormat
                    Select Case True
                        Case GetCarNumber.Length
                            Me.CanNotOutFactoryNowReason = "已有送交車號:" & GetCarNumber : Return False
                        Case IsNothing(SendDate)
                            Me.CanNotOutFactoryNowReason = "送交日期不正確:" & Me.BOL04 : Return False
                        Case Now.Date > SendDate.Value.Date.AddDays(7)
                            Me.CanNotOutFactoryNowReason = "外銷可出貨載止日:" & SendDate.Value.Date.AddDays(7) : Return False
                    End Select
                End If
                Return True
            End Get
        End Property
#End Region
#Region "無法即刻出廠原因 屬性:CanNotOutFactoryNowReason"

        Private _CanNotOutFactoryNowReason As String
        ''' <summary>
        ''' 無法即刻出廠原因
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property CanNotOutFactoryNowReason() As String
            Get
                If IsCanOutFactoryNow = True Then
                    Return Nothing
                End If
                Return _CanNotOutFactoryNowReason
            End Get
            Private Set(ByVal value As String)
                _CanNotOutFactoryNowReason = value
            End Set
        End Property

#End Region
#Region "客戶名稱 屬性:CustomerName"
        Private _CustomerName As String = Nothing
        Private Shared _CustomerFileCache As List(Of SL2CUAPF) = Nothing
        ''' <summary>
        ''' 客戶名稱
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property CustomerName() As String
            Get
                If String.IsNullOrEmpty(_CustomerName) Then
                    If IsNothing(_CustomerFileCache) Then
                        _CustomerFileCache = SL2CUAPF.CDBSelect(Of SL2CUAPF)("Select * From @#SLS300LB.SL2CUAPF", Me.CDBCurrentUseSQLQueryAdapter)
                    End If
                    For Each EachItem As SL2CUAPF In _CustomerFileCache
                        If EachItem.CUA01 = Me.BOL03.Substring(0, 3) Then
                            _CustomerName = EachItem.CUA11
                            Exit For
                        End If
                    Next
                End If
                Return _CustomerName
            End Get
        End Property
#End Region
#Region "CR或HR文字 屬性:CROrHR"
        Private _CROrHR As String = Nothing
        Private Shared _SL2CH2PFFileCache As List(Of SL2CH2PF) = Nothing
        ''' <summary>
        ''' CR或HR文字
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property CROrHR() As String
            Get
                If String.IsNullOrEmpty(_CROrHR) Then
                    If IsNothing(_SL2CH2PFFileCache) Then
                        _SL2CH2PFFileCache = SL2CH2PF.CDBSelect(Of SL2CH2PF)("Select * From @#SLS300LB.SL2CH2PF Where CH202=' ' ", Me.CDBCurrentUseSQLQueryAdapter)
                    End If
                    For Each EachItem As SL2CH2PF In _SL2CH2PFFileCache
                        If EachItem.CH201 = Me.BOL06 Then
                            _CROrHR = EachItem.CH205
                            Exit For
                        End If
                    Next
                End If
                Return _CROrHR
            End Get
        End Property
#End Region

        Public Overrides Function CDBUpdate() As Integer
            Dim ReturnValue As Integer = MyBase.CDBUpdate()
            If ReturnValue > 0 Then
                Dim UpdateQuery As String = "Update @#TESTKUKU.PPSCIAPF SET CIA64=" & Me.BOL04 & " WHERE CIA63=" & Me.BOL01 & " AND CIA62='" & Me.BOL02 & "' AND CIA02='" & Me.BOL16 & "' AND CIA03='" & Me.BOL17 & "'"
                Me.SQLQueryAdapterByThisObject.ExecuteNonQuery(UpdateQuery)
            End If
            Return ReturnValue
        End Function


    End Class
End Namespace