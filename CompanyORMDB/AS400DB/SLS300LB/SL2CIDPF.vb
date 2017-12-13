Namespace SLS300LB
    ''' <summary>
    ''' 列管訂單需求內容
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SL2CIDPF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("SLS300LB", GetType(SL2CIDPF).Name)
        End Sub

#Region "客戶 屬性:CID01"
        Private _CID01 As System.String
        ''' <summary>
        ''' 客戶
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CID01() As System.String
            Get
                Return _CID01
            End Get
            Set(ByVal value As System.String)
                _CID01 = value
            End Set
        End Property
#End Region
#Region "報價單 屬性:CID02"
        Private _CID02 As System.String
        ''' <summary>
        ''' 報價單
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CID02() As System.String
            Get
                Return _CID02
            End Get
            Set(ByVal value As System.String)
                _CID02 = value
            End Set
        End Property
#End Region
#Region "鋼種 屬性:CID03"
        Private _CID03 As System.String
        ''' <summary>
        ''' 鋼種
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CID03() As System.String
            Get
                Return _CID03
            End Get
            Set(ByVal value As System.String)
                _CID03 = value
            End Set
        End Property
#End Region
#Region "TYPE 屬性:CID04"
        Private _CID04 As System.String
        ''' <summary>
        ''' TYPE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CID04() As System.String
            Get
                Return _CID04
            End Get
            Set(ByVal value As System.String)
                _CID04 = value
            End Set
        End Property
#End Region
#Region "表面 屬性:CID05"
        Private _CID05 As System.String
        ''' <summary>
        ''' 表面
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CID05() As System.String
            Get
                Return _CID05
            End Get
            Set(ByVal value As System.String)
                _CID05 = value
            End Set
        End Property
#End Region
#Region "厚度 屬性:CID06"
        Private _CID06 As System.String
        ''' <summary>
        ''' 厚度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CID06() As System.String
            Get
                Return _CID06
            End Get
            Set(ByVal value As System.String)
                _CID06 = value
            End Set
        End Property
#End Region
#Region "範圍 屬性:CID07"
        Private _CID07 As System.String
        ''' <summary>
        ''' 範圍
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CID07() As System.String
            Get
                Return _CID07
            End Get
            Set(ByVal value As System.String)
                _CID07 = value
            End Set
        End Property
#End Region
#Region "料 屬性:CID08"
        Private _CID08 As System.String
        ''' <summary>
        ''' 料
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CID08() As System.String
            Get
                Return _CID08
            End Get
            Set(ByVal value As System.String)
                _CID08 = value
            End Set
        End Property
#End Region
#Region "銷 屬性:CID09"
        Private _CID09 As System.String
        ''' <summary>
        ''' 銷
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CID09() As System.String
            Get
                Return _CID09
            End Get
            Set(ByVal value As System.String)
                _CID09 = value
            End Set
        End Property
#End Region
#Region "建檔日 屬性:CID10"
        Private _CID10 As System.String
        ''' <summary>
        ''' 建檔日
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID10() As System.String
            Get
                Return _CID10
            End Get
            Set(ByVal value As System.String)
                _CID10 = value
            End Set
        End Property
#End Region
#Region "列管種類 屬性:CID11"
        Private _CID11 As System.String
        ''' <summary>
        ''' 列管種類
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID11() As System.String
            Get
                Return _CID11
            End Get
            Set(ByVal value As System.String)
                _CID11 = value
            End Set
        End Property
#End Region
#Region "製程編號 屬性:CID12"
        Private _CID12 As System.String
        ''' <summary>
        ''' 製程編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID12() As System.String
            Get
                Return _CID12
            End Get
            Set(ByVal value As System.String)
                _CID12 = value
            End Set
        End Property
#End Region
#Region "目標厚 屬性:CID40"
        Private _CID40 As System.Single
        ''' <summary>
        ''' 目標厚
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID40() As System.Single
            Get
                Return _CID40
            End Get
            Set(ByVal value As System.Single)
                _CID40 = value
            End Set
        End Property
#End Region
#Region "厚起 屬性:CID13"
        Private _CID13 As System.Single
        ''' <summary>
        ''' 厚起
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID13() As System.Single
            Get
                Return _CID13
            End Get
            Set(ByVal value As System.Single)
                _CID13 = value
            End Set
        End Property
#End Region
#Region "厚止 屬性:CID14"
        Private _CID14 As System.Single
        ''' <summary>
        ''' 厚止
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID14() As System.Single
            Get
                Return _CID14
            End Get
            Set(ByVal value As System.Single)
                _CID14 = value
            End Set
        End Property
#End Region
#Region "寬起 屬性:CID15"
        Private _CID15 As System.Int32
        ''' <summary>
        ''' 寬起
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID15() As System.Int32
            Get
                Return _CID15
            End Get
            Set(ByVal value As System.Int32)
                _CID15 = value
            End Set
        End Property
#End Region
#Region "寬止 屬性:CID16"
        Private _CID16 As System.Int32
        ''' <summary>
        ''' 寬止
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID16() As System.Int32
            Get
                Return _CID16
            End Get
            Set(ByVal value As System.Int32)
                _CID16 = value
            End Set
        End Property
#End Region
#Region "重量起 屬性:CID17"
        Private _CID17 As System.Int32
        ''' <summary>
        ''' 重量起
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID17() As System.Int32
            Get
                Return _CID17
            End Get
            Set(ByVal value As System.Int32)
                _CID17 = value
            End Set
        End Property
#End Region
#Region "重量止 屬性:CID18"
        Private _CID18 As System.Int32
        ''' <summary>
        ''' 重量止
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID18() As System.Int32
            Get
                Return _CID18
            End Get
            Set(ByVal value As System.Int32)
                _CID18 = value
            End Set
        End Property
#End Region
#Region "HRB起 屬性:CID19"
        Private _CID19 As System.Single
        ''' <summary>
        ''' HRB起
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID19() As System.Single
            Get
                Return _CID19
            End Get
            Set(ByVal value As System.Single)
                _CID19 = value
            End Set
        End Property
#End Region
#Region "HRB止 屬性:CID20"
        Private _CID20 As System.Single
        ''' <summary>
        ''' HRB止
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID20() As System.Single
            Get
                Return _CID20
            End Get
            Set(ByVal value As System.Single)
                _CID20 = value
            End Set
        End Property
#End Region
#Region "HV起 屬性:CID21"
        Private _CID21 As System.Single
        ''' <summary>
        ''' HV起
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID21() As System.Single
            Get
                Return _CID21
            End Get
            Set(ByVal value As System.Single)
                _CID21 = value
            End Set
        End Property
#End Region
#Region "HV止 屬性:CID22"
        Private _CID22 As System.Single
        ''' <summary>
        ''' HV止
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID22() As System.Single
            Get
                Return _CID22
            End Get
            Set(ByVal value As System.Single)
                _CID22 = value
            End Set
        End Property
#End Region
#Region "研磨正 屬性:CID23"
        Private _CID23 As System.Int32
        ''' <summary>
        ''' 研磨正
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID23() As System.Int32
            Get
                Return _CID23
            End Get
            Set(ByVal value As System.Int32)
                _CID23 = value
            End Set
        End Property
#End Region
#Region "研磨反 屬性:CID24"
        Private _CID24 As System.Int32
        ''' <summary>
        ''' 研磨反
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID24() As System.Int32
            Get
                Return _CID24
            End Get
            Set(ByVal value As System.Int32)
                _CID24 = value
            End Set
        End Property
#End Region
#Region "用途 屬性:CID25"
        Private _CID25 As System.String
        ''' <summary>
        ''' 用途
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID25() As System.String
            Get
                Return _CID25
            End Get
            Set(ByVal value As System.String)
                _CID25 = value
            End Set
        End Property
#End Region
#Region "化１ 屬性:CID31"
        Private _CID31 As System.String
        ''' <summary>
        ''' 化１
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID31() As System.String
            Get
                Return _CID31
            End Get
            Set(ByVal value As System.String)
                _CID31 = value
            End Set
        End Property
#End Region
#Region "起１ 屬性:CID32"
        Private _CID32 As System.Single
        ''' <summary>
        ''' 起１
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID32() As System.Single
            Get
                Return _CID32
            End Get
            Set(ByVal value As System.Single)
                _CID32 = value
            End Set
        End Property
#End Region
#Region "止１ 屬性:CID33"
        Private _CID33 As System.Single
        ''' <summary>
        ''' 止１
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID33() As System.Single
            Get
                Return _CID33
            End Get
            Set(ByVal value As System.Single)
                _CID33 = value
            End Set
        End Property
#End Region
#Region "化２ 屬性:CID34"
        Private _CID34 As System.String
        ''' <summary>
        ''' 化２
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID34() As System.String
            Get
                Return _CID34
            End Get
            Set(ByVal value As System.String)
                _CID34 = value
            End Set
        End Property
#End Region
#Region "起２ 屬性:CID35"
        Private _CID35 As System.Single
        ''' <summary>
        ''' 起２
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID35() As System.Single
            Get
                Return _CID35
            End Get
            Set(ByVal value As System.Single)
                _CID35 = value
            End Set
        End Property
#End Region
#Region "止２ 屬性:CID36"
        Private _CID36 As System.Single
        ''' <summary>
        ''' 止２
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID36() As System.Single
            Get
                Return _CID36
            End Get
            Set(ByVal value As System.Single)
                _CID36 = value
            End Set
        End Property
#End Region
#Region "化３ 屬性:CID37"
        Private _CID37 As System.String
        ''' <summary>
        ''' 化３
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID37() As System.String
            Get
                Return _CID37
            End Get
            Set(ByVal value As System.String)
                _CID37 = value
            End Set
        End Property
#End Region
#Region "起３ 屬性:CID38"
        Private _CID38 As System.Single
        ''' <summary>
        ''' 起３
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID38() As System.Single
            Get
                Return _CID38
            End Get
            Set(ByVal value As System.Single)
                _CID38 = value
            End Set
        End Property
#End Region
#Region "止３ 屬性:CID39"
        Private _CID39 As System.Single
        ''' <summary>
        ''' 止３
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID39() As System.Single
            Get
                Return _CID39
            End Get
            Set(ByVal value As System.Single)
                _CID39 = value
            End Set
        End Property
#End Region
#Region "核取旗標 屬性:CID41"
        Private _CID41 As System.String
        ''' <summary>
        ''' 核取旗標
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID41() As System.String
            Get
                Return _CID41
            End Get
            Set(ByVal value As System.String)
                _CID41 = value
            End Set
        End Property
#End Region
#Region "異動日 屬性:CID42"
        Private _CID42 As System.String
        ''' <summary>
        ''' 異動日
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID42() As System.String
            Get
                Return _CID42
            End Get
            Set(ByVal value As System.String)
                _CID42 = value
            End Set
        End Property
#End Region
#Region "派工截止日 屬性:CID43"
        Private _CID43 As System.String
        ''' <summary>
        ''' 派工截止日
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID43() As System.String
            Get
                Return _CID43
            End Get
            Set(ByVal value As System.String)
                _CID43 = value
            End Set
        End Property
#End Region
#Region "原因 屬性:CID44"
        Private _CID44 As System.String
        ''' <summary>
        ''' 原因
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID44() As System.String
            Get
                Return _CID44
            End Get
            Set(ByVal value As System.String)
                _CID44 = value
            End Set
        End Property
#End Region
#Region "核准編號 屬性:CID45"
        Private _CID45 As System.String
        ''' <summary>
        ''' 核准編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID45() As System.String
            Get
                Return _CID45
            End Get
            Set(ByVal value As System.String)
                _CID45 = value
            End Set
        End Property
#End Region
#Region "CODE-1 屬性:CID91"
        Private _CID91 As System.String
        ''' <summary>
        ''' CODE-1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID91() As System.String
            Get
                Return _CID91
            End Get
            Set(ByVal value As System.String)
                _CID91 = value
            End Set
        End Property
#End Region
#Region "CODE-2 屬性:CID92"
        Private _CID92 As System.String
        ''' <summary>
        ''' CODE-2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID92() As System.String
            Get
                Return _CID92
            End Get
            Set(ByVal value As System.String)
                _CID92 = value
            End Set
        End Property
#End Region
#Region "CODE-3 屬性:CID93"
        Private _CID93 As System.String
        ''' <summary>
        ''' CODE-3
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID93() As System.String
            Get
                Return _CID93
            End Get
            Set(ByVal value As System.String)
                _CID93 = value
            End Set
        End Property
#End Region
#Region "CODE-4 屬性:CID94"
        Private _CID94 As System.String
        ''' <summary>
        ''' CODE-4
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID94() As System.String
            Get
                Return _CID94
            End Get
            Set(ByVal value As System.String)
                _CID94 = value
            End Set
        End Property
#End Region
#Region "CODE-5 屬性:CID95"
        Private _CID95 As System.String
        ''' <summary>
        ''' CODE-5
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CID95() As System.String
            Get
                Return _CID95
            End Get
            Set(ByVal value As System.String)
                _CID95 = value
            End Set
        End Property
#End Region


#Region "訂單編號 屬性:OrderNumber"
        ''' <summary>
        ''' 訂單編號
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property OrderNumber As String
            Get
                Return Me.CID01 & Me.CID02
            End Get
        End Property
#End Region
#Region "派料碼 屬性:DispatchCode"
        ''' <summary>
        ''' 派料碼
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property DispatchCode As String
            Get
                Dim ReturnValue As String = CID09.PadRight(1).Trim
                Dim myAboutSL2QTNPF As SL2QTNPF = Me.AboutSL2QTNPF
                Dim myAboutSL2CH8PF As SL2CH8PF = Me.AboutSL2CH8PF
                If String.IsNullOrEmpty(ReturnValue) AndAlso Not IsNothing(AboutSL2QTNPF) Then
                    If Not AboutSL2QTNPF.IsHomeSell Then
                        ReturnValue = "X"
                    Else
                        ReturnValue = " "
                    End If
                End If
                If Not IsNothing(myAboutSL2QTNPF) Then
                    If myAboutSL2QTNPF.IsDeckleEdge Then
                        ReturnValue &= " "
                    Else
                        ReturnValue &= "B"
                    End If
                End If
                If Not IsNothing(myAboutSL2CH8PF) Then
                    ReturnValue &= myAboutSL2CH8PF.CH802.Substring(0, 2)
                Else
                    If Not IsNothing(myAboutSL2QTNPF) Then
                        ReturnValue &= myAboutSL2QTNPF.QTN25.PadRight(2)
                    End If
                End If
                Return ReturnValue.PadRight(4)
            End Get
        End Property
#End Region
#Region "毛修邊顯示 屬性:DeckleOrNoEdgeDisplay"
        ''' <summary>
        ''' 毛修邊顯示
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property DeckleOrNoEdgeDisplay As String
            Get
                Dim myAboutSL2QTNPF As SL2QTNPF = Me.AboutSL2QTNPF
                If Not IsNothing(myAboutSL2QTNPF) Then
                    Return IIf(myAboutSL2QTNPF.IsDeckleEdge, "毛邊", "修邊")
                End If
                Return Nothing
            End Get
        End Property
#End Region
#Region "交庫期限 屬性:InStorageDate"
        ''' <summary>
        ''' 交庫期限
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property InStorageDate As DateTime
            Get
                Dim myAboutSL2QTAPF As SL2QTAPF = Me.AboutSL2QTAPF
                Dim ReturnValue As DateTime = New DateTime(2000, 1, 1)
                If Not IsNothing(myAboutSL2QTAPF) Then
                    If String.IsNullOrEmpty(myAboutSL2QTAPF.QTA28) OrElse myAboutSL2QTAPF.QTA28.Trim.Length = 0 Then
                        Return ReturnValue
                    End If
                    Try
                        ReturnValue = (New AS400DateConverter(myAboutSL2QTAPF.QTA28)).DateValue
                    Catch ex As Exception
                        Return ReturnValue
                    End Try
                    Return ReturnValue
                End If
                Return ReturnValue
            End Get
        End Property
#End Region
#Region "訂單厚度 屬性:OrderThick"
        ''' <summary>
        ''' 訂單厚度(公稱厚度)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property OrderThick As Single
            Get
                If Not IsNothing(AboutSL2CH7PF) Then
                    Return AboutSL2CH7PF.CH706
                End If
                Return 0
            End Get
        End Property
#End Region
#Region "訂單厚度範圍 屬性:OrderThickRange"
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property OrderThickRange As String
            Get
                Return AboutSL2CH7PF_CH704 & "~" & AboutSL2CH7PF_CH705
            End Get
        End Property
#End Region
#Region "單捲重範圍 屬性:WeightRange"
        ''' <summary>
        ''' 單捲重範圍
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property WeightRange As String
            Get
                Return CID17 & "~" & CID18
            End Get
        End Property
#End Region
#Region "單捲厚度範圍 屬性:ThickRange"
        ''' <summary>
        ''' 單捲厚度範圍
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property ThickRange As String
            Get
                Return CID13 & "~" & CID14
            End Get
        End Property
#End Region
#Region "單捲寬度範圍 屬性:WithRange"
        ''' <summary>
        ''' 單捲寬度範圍
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property WithRange As String
            Get
                Return CID15 & "~" & CID16
            End Get
        End Property
#End Region
#Region "伸長HRB範圍 屬性:HRBRange"
        ''' <summary>
        ''' 伸長HRB範圍
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property HRBRange As String
            Get
                Return CID19 & "~" & CID20
            End Get
        End Property
#End Region
#Region "伸長HV範圍 屬性:HVRange"
        ''' <summary>
        ''' 伸長HV範圍
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property HVRange As String
            Get
                Return CID21 & "~" & CID22
            End Get
        End Property
#End Region
#Region "伸長EL範圍 屬性:ELRange"
        ''' <summary>
        ''' EL
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property ELRange As String
            Get
                Return CID32 & "~" & CID33
            End Get
        End Property
#End Region
#Region "抗拉TS範圍 屬性:TSRange"
        ''' <summary>
        ''' 抗拉TS範圍
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property TSRange As String
            Get
                Return CID35 & "~" & CID36
            End Get
        End Property
#End Region
#Region "其它要求說明1 屬性:OtherRequireDescript1"
        ''' <summary>
        ''' 其它要求說明1
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property OtherRequireDescript1 As String
            Get
                Dim GetSL2CINPF As SL2CINPF = FindSL2CINPF(CID93)
                If IsNothing(GetSL2CINPF) Then
                    Return Nothing
                End If
                Return GetSL2CINPF.CIN02
            End Get
        End Property
#End Region
#Region "其它要求說明2 屬性:OtherRequireDescript2"
        ''' <summary>
        ''' 其它要求說明2
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property OtherRequireDescript2 As String
            Get
                Dim GetSL2CINPF As SL2CINPF = FindSL2CINPF(CID05.PadRight(3).Substring(1, 1))
                If IsNothing(GetSL2CINPF) Then
                    Return Nothing
                End If
                Return GetSL2CINPF.CIN02
            End Get
        End Property
#End Region
#Region "其它要求說明3 屬性:OtherRequireDescript3"
        ''' <summary>
        ''' 其它要求說明2
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property OtherRequireDescript3 As String
            Get
                Dim GetSL2CINPF As SL2CINPF = FindSL2CINPF(CID05.PadRight(3).Substring(2, 1))
                If IsNothing(GetSL2CINPF) Then
                    Return Nothing
                End If
                Return GetSL2CINPF.CIN02
            End Get
        End Property
#End Region


#Region "取得相關其它要求說明檔資料 屬性:FindSL2CINPF"
        Private _FindSL2CINPFs As List(Of CompanyORMDB.SLS300LB.SL2CINPF)
        Private _GetSL2CINPFLastAccessTime As DateTime = New DateTime(200, 1, 1)
        ''' <summary>
        ''' 取得相關其它要求說明檔資料
        ''' </summary>
        ''' <param name="FindUseCode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function FindSL2CINPF(ByVal FindUseCode As String) As SL2CINPF
            If String.IsNullOrEmpty(FindUseCode) OrElse FindUseCode.Trim.Length = 0 Then
                Return Nothing
            End If
            If Now.Subtract(_GetSL2CINPFLastAccessTime).TotalSeconds > 3 Then
                _FindSL2CINPFs = SL2CINPF.AllSL2CINPFs
                LastAccessTime = Now
            End If
            If Not IsNothing(_FindSL2CINPFs) Then
                For Each EachItem As SL2CINPF In _FindSL2CINPFs
                    If EachItem.CIN01 = FindUseCode Then
                        Return EachItem
                    End If
                Next
            End If
            Return Nothing
        End Function
#End Region

#Region "相關公稱厚度資料 屬性:AboutSL2CH7PF"
        Private _AboutSL2CH7PF As CompanyORMDB.SLS300LB.SL2CH7PF = Nothing
        Private LastAccessTime As DateTime = New DateTime(2014, 1, 1)
        ''' <summary>
        ''' 相關公稱厚度資料
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutSL2CH7PF As CompanyORMDB.SLS300LB.SL2CH7PF
            Get
                If IsNothing(_AboutSL2CH7PF) AndAlso Now.Subtract(LastAccessTime).TotalSeconds > 3 Then
                    Dim FindCRHR As String = "CR"
                    Dim FindMaterialType As String = "B"
                    Dim FindThithTypeas As String = " "     '子範圍/厚度型別
                    If Not String.IsNullOrEmpty(Me.CID05) AndAlso Me.CID05 = "NO1" Then
                        FindCRHR = "HR"
                        FindMaterialType = "X"
                    End If
                    If String.IsNullOrEmpty(Me.CID06) OrElse Me.CID06 = "1" Then
                        FindThithTypeas = " "
                    Else
                        FindThithTypeas = Me.CID06
                    End If
                    Dim QryString As String = "Select * from @#SLS300LB.SL2CH7PF WHERE CH701='" & FindCRHR & "' AND CH70A='" & FindMaterialType & "' AND CH703='" & FindThithTypeas & "' "
                    Dim SearchResult As List(Of CompanyORMDB.SLS300LB.SL2CH7PF) = CompanyORMDB.SLS300LB.SL2CH7PF.CDBSelect(Of CompanyORMDB.SLS300LB.SL2CH7PF)(QryString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                    If SearchResult.Count > 0 Then
                        _AboutSL2CH7PF = SearchResult(0)
                    End If
                    LastAccessTime = Now
                End If
                Return _AboutSL2CH7PF
            End Get
        End Property
#End Region
#Region "相關公稱厚度_厚度下限 屬性:AboutSL2CH7PF_CH704"
        ''' <summary>
        ''' 相關公稱厚度_厚度下限
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property AboutSL2CH7PF_CH704 As Single
            Get
                If Not IsNothing(AboutSL2CH7PF) Then
                    Return AboutSL2CH7PF.CH704
                End If
                Return 0
            End Get
        End Property
#End Region
#Region "相關公稱厚度_厚度上限 屬性:AboutSL2CH7PF_CH705"
        ''' <summary>
        ''' 相關公稱厚度_厚度上限
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property AboutSL2CH7PF_CH705 As Single
            Get
                If Not IsNothing(AboutSL2CH7PF) Then
                    Return AboutSL2CH7PF.CH705
                End If
                Return 0
            End Get
        End Property
#End Region


#Region "相關在製品鋼捲入有主資料 屬性:AboutSL2CICPF"
        Private _AboutSL2CICPF As SL2CICPF
        Private AboutSL2CICPFLastAccessTime As DateTime = New DateTime(2014, 1, 1)
        ''' <summary>
        ''' 相關在製品鋼捲入有主資料
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property AboutSL2CICPF() As SL2CICPF
            Get
                If IsNothing(_AboutSL2CICPF) AndAlso Now.Subtract(AboutSL2CICPFLastAccessTime).TotalSeconds > 3 Then
                    Dim QryString As String = "Select * from @#SLS300LB.SL2CICPF WHERE CIC10='" & Me.CID01 & Me.CID02 & "' "
                    Dim SearchResult As List(Of CompanyORMDB.SLS300LB.SL2CICPF) = CompanyORMDB.SLS300LB.SL2CICPF.CDBSelect(Of CompanyORMDB.SLS300LB.SL2CICPF)(QryString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                    If SearchResult.Count > 0 Then
                        _AboutSL2CICPF = SearchResult(0)
                    End If
                    AboutSL2CICPFLastAccessTime = Now
                End If
                Return _AboutSL2CICPF
            End Get
            Set(ByVal value As SL2CICPF)
                _AboutSL2CICPF = value
            End Set
        End Property
#End Region
#Region "相關報價單資料 屬性:AboutSL2QTNPF"
        Private _AboutSL2QTNPF As SL2QTNPF
        Private AboutSL2QTNPFLastAccessTime As DateTime = New DateTime(2014, 1, 1)
        ''' <summary>
        ''' 相關報價單資料
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AboutSL2QTNPF() As SL2QTNPF
            Get
                If IsNothing(_AboutSL2QTNPF) AndAlso Now.Subtract(AboutSL2QTNPFLastAccessTime).TotalSeconds > 3 Then
                    Dim QryString As String = "Select * from @#SLS300LB.SL2QTNPF WHERE (QTN01 || QTN02)='" & Me.CID01 & Me.CID02 & "' "
                    Dim SearchResult As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = CompanyORMDB.SLS300LB.SL2QTNPF.CDBSelect(Of CompanyORMDB.SLS300LB.SL2QTNPF)(QryString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                    If SearchResult.Count > 0 Then
                        _AboutSL2QTNPF = SearchResult(0)
                    End If
                    AboutSL2QTNPFLastAccessTime = Now
                End If
                Return _AboutSL2QTNPF
            End Get
            Set(ByVal value As SL2QTNPF)
                _AboutSL2QTNPF = value
            End Set
        End Property
#End Region
#Region "相關報價單資料_寬度 屬性:AboutSL2QTNPF_QTN06"
        ''' <summary>
        ''' 相關報價單資料_寬度
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutSL2QTNPF_QTN06 As Integer
            Get
                Dim mySL2QTNPF = Me.AboutSL2QTNPF
                If IsNothing(mySL2QTNPF) Then
                    Return 0
                End If
                Return mySL2QTNPF.QTN06
            End Get
        End Property
#End Region
#Region "相關料別查核檔資料 屬性:AboutSL2CH8PF"
        Private _AboutSL2CH8PF As SL2CH8PF
        Private AboutSL2CH8PFLastAccessTime As DateTime = New DateTime(2014, 1, 1)
        ''' <summary>
        ''' 相關料別查核檔資料
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property AboutSL2CH8PF() As SL2CH8PF
            Get
                If IsNothing(_AboutSL2CH8PF) AndAlso Now.Subtract(AboutSL2CH8PFLastAccessTime).TotalSeconds > 3 Then
                    Dim QryString As String = "Select * from @#SLS300LB.SL2CH8PF WHERE CH801='" & Me.CID08 & "' "
                    Dim SearchResult As List(Of CompanyORMDB.SLS300LB.SL2CH8PF) = CompanyORMDB.SLS300LB.SL2CH8PF.CDBSelect(Of CompanyORMDB.SLS300LB.SL2CH8PF)(QryString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                    If SearchResult.Count > 0 Then
                        _AboutSL2CH8PF = SearchResult(0)
                    End If
                    AboutSL2CH8PFLastAccessTime = Now
                End If
                Return _AboutSL2CH8PF
            End Get
            Set(ByVal value As SL2CH8PF)
                _AboutSL2CH8PF = value
            End Set
        End Property

#End Region
#Region "相關報價單標題資料 屬性:AboutSL2QTAPF"
        Private _AboutSL2QTAPF As SL2QTAPF
        Private AboutSL2QTAPFLastAccessTime As DateTime = New DateTime(2014, 1, 1)
        ''' <summary>
        ''' 相關報價單標題資料
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property AboutSL2QTAPF() As SL2QTAPF
            Get
                If IsNothing(_AboutSL2QTAPF) AndAlso Now.Subtract(AboutSL2QTAPFLastAccessTime).TotalSeconds > 3 Then
                    Dim QryString As String = "Select * from @#SLS300LB.SL2QTAPF WHERE (QTA01 || QTA02) ='" & Me.CID01 & CID02 & "' "
                    Dim SearchResult As List(Of CompanyORMDB.SLS300LB.SL2QTAPF) = CompanyORMDB.SLS300LB.SL2QTAPF.CDBSelect(Of CompanyORMDB.SLS300LB.SL2QTAPF)(QryString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                    If SearchResult.Count > 0 Then
                        _AboutSL2QTAPF = SearchResult(0)
                    End If
                    AboutSL2QTAPFLastAccessTime = Now
                End If
                Return _AboutSL2QTAPF
            End Get
            Set(ByVal value As SL2QTAPF)
                _AboutSL2QTAPF = value
            End Set
        End Property
#End Region
#Region "相關用途說明檔資料 屬性:AboutSL2CIFAPF"
        Private _AboutSL2CIFPF As SL2CIFPF
        Private AboutSL2CIFPFLastAccessTime As DateTime = New DateTime(2014, 1, 1)
        ''' <summary>
        ''' 相關用途說明檔資料
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property AboutSL2CIFAPF() As SL2CIFPF
            Get
                If IsNothing(_AboutSL2CIFPF) AndAlso Now.Subtract(AboutSL2CIFPFLastAccessTime).TotalSeconds > 3 Then
                    Dim QryString As String = "Select * from @#SLS300LB.SL2CIFPF WHERE CIF01 ='" & Me.CID25 & "' "
                    Dim SearchResult As List(Of CompanyORMDB.SLS300LB.SL2CIFPF) = CompanyORMDB.SLS300LB.SL2CIFPF.CDBSelect(Of CompanyORMDB.SLS300LB.SL2CIFPF)(QryString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                    If SearchResult.Count > 0 Then
                        _AboutSL2CIFPF = SearchResult(0)
                    End If
                    AboutSL2CIFPFLastAccessTime = Now
                End If
                Return _AboutSL2CIFPF
            End Get
            Set(ByVal value As SL2CIFPF)
                _AboutSL2CIFPF = value
            End Set
        End Property
#End Region
#Region "用途說明 屬性:AboutSL2CIFPF_CIF02"
        ''' <summary>
        ''' 用途說明
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutSL2CIFPF_CIF02 As String
            Get
                Dim mySL2CIFPF = Me.AboutSL2CIFAPF
                If IsNothing(mySL2CIFPF) Then
                    Return 0
                End If
                Return mySL2CIFPF.CIF02
            End Get
        End Property
#End Region



#Region "切頭尾顯示 屬性:DeckleOrNoEdgeDisplay"
        ''' <summary>
        ''' 切頭尾顯示
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property CutMaterialDisplay As String
            Get
                Dim myAboutSL2QTNPF As SL2QTNPF = Me.AboutSL2QTNPF
                If Not IsNothing(myAboutSL2QTNPF) Then
                    ''Return IIf(myAboutSL2QTNPF.IsCutMaterial, "切頭尾", "-----")
                    If myAboutSL2QTNPF.IsCutMaterial = 1 Then

                        Return "切頭尾"
                    ElseIf myAboutSL2QTNPF.IsCutMaterial = 2 Then
                        Return "不切頭尾"
                    Else
                        Return "依標準製程"
                    End If
                End If
                Return "依標準製程"
            End Get
        End Property
#End Region
#Region "夾襯紙顯示 屬性:PackingPaperDisplay"
        ''' <summary>
        ''' 切頭尾顯示
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property PackingPaperDisplay As String
            Get
                Dim myAboutSL2QTNPF As SL2QTNPF = Me.AboutSL2QTNPF
                If Not IsNothing(myAboutSL2QTNPF) Then
                    ''Return IIf(myAboutSL2QTNPF.IsCutMaterial, "切頭尾", "-----")
                    If myAboutSL2QTNPF.IsAddPackingPaper = 1 Then

                        Return "夾襯紙"
                    ElseIf myAboutSL2QTNPF.IsCutMaterial = 2 Then
                        Return "不夾襯紙"
                    Else
                        Return "依標準製程"
                    End If
                End If
                Return "依標準製程"
            End Get
        End Property
#End Region
#Region "口徑大小顯示 屬性:InsideRadiusDisplay"
        ''' <summary>
        ''' 切頭尾顯示
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property InsideRadiusDisplay As String
            Get
                Dim myAboutSL2QTNPF As SL2QTNPF = Me.AboutSL2QTNPF
                If Not IsNothing(myAboutSL2QTNPF) Then
                    Return myAboutSL2QTNPF.InsideRadius
                End If
                Return "依標準製程"
            End Get
        End Property
#End Region
#Region "外銷包裝 屬性:"
        ''' <summary>
        ''' 外銷包裝顯示
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property ExportDisplay As String
            Get
                If CID94.Trim <> "" Then
                    Return "外銷"
                Else
                    Return "內銷"
                End If
                Return "內銷"
            End Get
        End Property
#End Region
    End Class
End Namespace