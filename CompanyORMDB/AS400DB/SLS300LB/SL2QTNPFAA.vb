Namespace sls300lb
    ''' <summary>
    ''' 報價單資料檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SL2QTNPF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("sls300lb", GetType(SL2QTNPF).Name)
        End Sub

#Region "客戶編號 屬性:QTN01"
        Private _QTN01 As System.String
        ''' <summary>
        ''' 客戶編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QTN01() As System.String
            Get
                Return _QTN01
            End Get
            Set(ByVal value As System.String)
                _QTN01 = value
            End Set
        End Property
#End Region
#Region "報價單編號 屬性:QTN02"
        Private _QTN02 As System.String
        ''' <summary>
        ''' 報價單編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QTN02() As System.String
            Get
                Return _QTN02
            End Get
            Set(ByVal value As System.String)
                _QTN02 = value
            End Set
        End Property
#End Region
#Region "鋼　種 屬性:QTN03"
        Private _QTN03 As System.String
        ''' <summary>
        ''' 鋼　種
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QTN03() As System.String
            Get
                Return _QTN03
            End Get
            Set(ByVal value As System.String)
                _QTN03 = value
            End Set
        End Property
#End Region
#Region "表　面 屬性:QTN04"
        Private _QTN04 As System.String
        ''' <summary>
        ''' 表　面
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QTN04() As System.String
            Get
                Return _QTN04
            End Get
            Set(ByVal value As System.String)
                _QTN04 = value
                About_SL2CH2PF_CH205 = Nothing
            End Set
        End Property
#End Region
#Region "厚　度 屬性:QTN05"
        Private _QTN05 As System.String
        ''' <summary>
        ''' 厚　度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QTN05() As System.String
            Get
                Return _QTN05
            End Get
            Set(ByVal value As System.String)
                _QTN05 = value
            End Set
        End Property
#End Region
#Region "寬　度 屬性:QTN06"
        Private _QTN06 As System.Int32
        ''' <summary>
        ''' 寬　度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QTN06() As System.Int32
            Get
                Return _QTN06
            End Get
            Set(ByVal value As System.Int32)
                _QTN06 = value
            End Set
        End Property
#End Region
#Region "長　度 屬性:QTN07"
        Private _QTN07 As System.Int32
        ''' <summary>
        ''' 長　度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QTN07() As System.Int32
            Get
                Return _QTN07
            End Get
            Set(ByVal value As System.Int32)
                _QTN07 = value
            End Set
        End Property
#End Region
#Region "毛、修邊 屬性:QTN08"
        Private _QTN08 As System.String
        ''' <summary>
        ''' 毛、修邊
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QTN08() As System.String
            Get
                Return _QTN08
            End Get
            Set(ByVal value As System.String)
                _QTN08 = value
            End Set
        End Property
#End Region
#Region "鋼捲內徑 屬性:QTN09"
        Private _QTN09 As System.Int32
        ''' <summary>
        ''' 鋼捲內徑
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QTN09() As System.Int32
            Get
                Return _QTN09
            End Get
            Set(ByVal value As System.Int32)
                _QTN09 = value
            End Set
        End Property
#End Region
#Region "鋼捲、片 屬性:QTN10"
        Private _QTN10 As System.String
        ''' <summary>
        ''' 鋼捲、片
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QTN10() As System.String
            Get
                Return _QTN10
            End Get
            Set(ByVal value As System.String)
                _QTN10 = value
            End Set
        End Property
#End Region
#Region "數量片數 屬性:QTN11"
        Private _QTN11 As System.Int32
        ''' <summary>
        ''' 數量片數
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTN11() As System.Int32
            Get
                Return _QTN11
            End Get
            Set(ByVal value As System.Int32)
                _QTN11 = value
            End Set
        End Property
#End Region
#Region "重量噸數 屬性:QTN12"
        Private _QTN12 As System.Single
        ''' <summary>
        ''' 重量噸數
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTN12() As System.Single
            Get
                Return _QTN12
            End Get
            Set(ByVal value As System.Single)
                _QTN12 = value
            End Set
        End Property
#End Region
#Region "一級品單價 屬性:QTN13"
        Private _QTN13 As System.Int32
        ''' <summary>
        ''' 一級品單價
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTN13() As System.Int32
            Get
                Return _QTN13
            End Get
            Set(ByVal value As System.Int32)
                _QTN13 = value
            End Set
        End Property
#End Region
#Region "二 屬性:QTN14"
        Private _QTN14 As System.Int32
        ''' <summary>
        ''' 二　　＂
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTN14() As System.Int32
            Get
                Return _QTN14
            End Get
            Set(ByVal value As System.Int32)
                _QTN14 = value
            End Set
        End Property
#End Region
#Region "三 屬性:QTN15"
        Private _QTN15 As System.Int32
        ''' <summary>
        ''' 三　　＂
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTN15() As System.Int32
            Get
                Return _QTN15
            End Get
            Set(ByVal value As System.Int32)
                _QTN15 = value
            End Set
        End Property
#End Region
#Region "報價單日期 屬性:QTN16"
        Private _QTN16 As System.String
        ''' <summary>
        ''' 報價單日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTN16() As System.String
            Get
                Return _QTN16
            End Get
            Set(ByVal value As System.String)
                _QTN16 = value
            End Set
        End Property
#End Region
#Region "希望交貨日期 屬性:QTN17"
        Private _QTN17 As System.String
        ''' <summary>
        ''' 希望交貨日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTN17() As System.String
            Get
                Return _QTN17
            End Get
            Set(ByVal value As System.String)
                _QTN17 = value
            End Set
        End Property
#End Region
#Region "承辦員號 屬性:QTN18"
        Private _QTN18 As System.String
        ''' <summary>
        ''' 承辦員號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTN18() As System.String
            Get
                Return _QTN18
            End Get
            Set(ByVal value As System.String)
                _QTN18 = value
            End Set
        End Property
#End Region
#Region "計價方式 屬性:QTN19"
        Private _QTN19 As System.String
        ''' <summary>
        ''' 計價方式
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTN19() As System.String
            Get
                Return _QTN19
            End Get
            Set(ByVal value As System.String)
                _QTN19 = value
            End Set
        End Property
#End Region
#Region "申購單編號 屬性:QTN20"
        Private _QTN20 As System.String
        ''' <summary>
        ''' 申購單編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTN20() As System.String
            Get
                Return _QTN20
            End Get
            Set(ByVal value As System.String)
                _QTN20 = value
            End Set
        End Property
#End Region
#Region "已發貨量 屬性:QTN21"
        Private _QTN21 As System.Single
        ''' <summary>
        ''' 已發貨量
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTN21() As System.Single
            Get
                Return _QTN21
            End Get
            Set(ByVal value As System.Single)
                _QTN21 = value
            End Set
        End Property
#End Region
#Region "待發貨量 屬性:QTN22"
        Private _QTN22 As System.Int32
        ''' <summary>
        ''' 待發貨量
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTN22() As System.Int32
            Get
                Return _QTN22
            End Get
            Set(ByVal value As System.Int32)
                _QTN22 = value
            End Set
        End Property
#End Region
#Region "承訂變更次數 屬性:QTN23"
        Private _QTN23 As System.Int32
        ''' <summary>
        ''' 承訂變更次數
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTN23() As System.Int32
            Get
                Return _QTN23
            End Get
            Set(ByVal value As System.Int32)
                _QTN23 = value
            End Set
        End Property
#End Region
#Region "已安排生產數量 屬性:QTN24"
        Private _QTN24 As System.Int32
        ''' <summary>
        ''' 已安排生產數量
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTN24() As System.Int32
            Get
                Return _QTN24
            End Get
            Set(ByVal value As System.Int32)
                _QTN24 = value
            End Set
        End Property
#End Region
#Region "管　料 屬性:QTN25"
        Private _QTN25 As System.String
        ''' <summary>
        ''' 管　料
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QTN25() As System.String
            Get
                Return _QTN25
            End Get
            Set(ByVal value As System.String)
                _QTN25 = value
            End Set
        End Property
#End Region
#Region "實　績 屬性:QTN26"
        Private _QTN26 As System.String
        ''' <summary>
        ''' 實　績
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTN26() As System.String
            Get
                Return _QTN26
            End Get
            Set(ByVal value As System.String)
                _QTN26 = value
            End Set
        End Property
#End Region
#Region "列印序號 屬性:QTN27"
        Private _QTN27 As System.String
        ''' <summary>
        ''' 列印序號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTN27() As System.String
            Get
                Return _QTN27
            End Get
            Set(ByVal value As System.String)
                _QTN27 = value
            End Set
        End Property
#End Region
#Region "*合約外 屬性:QTN28"
        Private _QTN28 As System.String
        ''' <summary>
        ''' *合約外
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTN28() As System.String
            Get
                Return _QTN28
            End Get
            Set(ByVal value As System.String)
                _QTN28 = value
            End Set
        End Property
#End Region
#Region "E外銷 屬性:QTN29"
        Private _QTN29 As System.String
        ''' <summary>
        ''' E外銷
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTN29() As System.String
            Get
                Return _QTN29
            End Get
            Set(ByVal value As System.String)
                _QTN29 = value
            End Set
        End Property
#End Region
#Region "鋼種TYPE 屬性:QTN30"
        Private _QTN30 As System.String
        ''' <summary>
        ''' 鋼種TYPE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTN30() As System.String
            Get
                Return _QTN30
            End Get
            Set(ByVal value As System.String)
                _QTN30 = value
            End Set
        End Property
#End Region
#Region "交貨地點序號 屬性:QTN31"
        Private _QTN31 As System.String
        ''' <summary>
        ''' 交貨地點序號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTN31() As System.String
            Get
                Return _QTN31
            End Get
            Set(ByVal value As System.String)
                _QTN31 = value
            End Set
        End Property
#End Region
#Region "*結案 屬性:QTN91"
        Private _QTN91 As System.String
        ''' <summary>
        ''' *結案
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTN91() As System.String
            Get
                Return _QTN91
            End Get
            Set(ByVal value As System.String)
                _QTN91 = value
            End Set
        End Property
#End Region
#Region "表面等級 屬性:QTN92"
        Private _QTN92 As System.String
        ''' <summary>
        ''' 表面等級
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QTN92() As System.String
            Get
                Return _QTN92
            End Get
            Set(ByVal value As System.String)
                _QTN92 = value
            End Set
        End Property
#End Region
#Region "CODE- 3 屬性:QTN93"
        Private _QTN93 As System.String
        ''' <summary>
        ''' CODE- 3
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTN93() As System.String
            Get
                Return _QTN93
            End Get
            Set(ByVal value As System.String)
                _QTN93 = value
            End Set
        End Property
#End Region
#Region "CODE- 4 屬性:QTN94"
        Private _QTN94 As System.String
        ''' <summary>
        ''' CODE- 4
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTN94() As System.String
            Get
                Return _QTN94
            End Get
            Set(ByVal value As System.String)
                _QTN94 = value
            End Set
        End Property
#End Region
#Region "CODE- 5 屬性:QTN95"
        Private _QTN95 As System.String
        ''' <summary>
        ''' CODE- 5
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTN95() As System.String
            Get
                Return _QTN95
            End Get
            Set(ByVal value As System.String)
                _QTN95 = value
            End Set
        End Property
#End Region

#Region "相關表面查核檔欄位CH205 屬性:About_SL2CH2PF_CH205"
        Private _About_SL2CH2PF_CH205 As String
        ''' <summary>
        ''' 相關表面查核檔欄位CH205
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property About_SL2CH2PF_CH205() As String
            Get
                If IsNothing(_About_SL2CH2PF_CH205) Then
                    For Each EachItem As SL2CH2PF In AboutAll_SL2CH2PF
                        If EachItem.CH201 = Me.QTN04 Then
                            _About_SL2CH2PF_CH205 = EachItem.CH205
                            Exit For
                        End If
                    Next
                End If
                Return _About_SL2CH2PF_CH205
            End Get
            Private Set(ByVal value As String)
                _About_SL2CH2PF_CH205 = value
            End Set
        End Property
#End Region

#Region "全部表面查核檔(SHARED) 屬性:All_SL2CH2PF"
        Private Shared _AboutAll_SL2CH2PF As List(Of SL2CH2PF)
        ''' <summary>
        ''' 全部表面查核檔(SHARED)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property AboutAll_SL2CH2PF() As List(Of SL2CH2PF)
            Get
                If IsNothing(_AboutAll_SL2CH2PF) Then
                    _AboutAll_SL2CH2PF = SL2CH2PF.CDBSetDataTableToObjects(Of sls300lb.SL2CH2PF)(New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, "Select * from @#SLS300LB.SL2CH2PF").SelectQuery)
                End If
                Return _AboutAll_SL2CH2PF
            End Get
        End Property
#End Region

    End Class
End Namespace