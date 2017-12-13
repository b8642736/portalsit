Namespace PPS100LB
    ''' <summary>
    ''' 成品繳庫檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Class PPSCIAPF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("PPS100LB", GetType(PPSCIAPF).Name)
        End Sub

        Sub New(ByVal SetLibraryName As String, ByVal SetFileName As String)
            MyBase.New(SetLibraryName, SetFileName)
        End Sub


#Region "現場繳庫單位 屬性:CIA56"
        Private _CIA56 As System.String
        ''' <summary>
        ''' 現場繳庫單位
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA56() As System.String
            Get
                Return _CIA56
            End Get
            Set(ByVal value As System.String)
                _CIA56 = value
            End Set
        End Property
#End Region
#Region "繳庫編號 屬性:CIA01"
        Private _CIA01 As System.String
        ''' <summary>
        ''' 繳庫編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA01() As System.String
            Get
                Return _CIA01
            End Get
            Set(ByVal value As System.String)
                _CIA01 = value
            End Set
        End Property
#End Region
#Region "鋼捲號碼1 屬性:CIA02"
        Private _CIA02 As System.String
        ''' <summary>
        ''' 鋼捲號碼1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CIA02() As System.String
            Get
                Return _CIA02
            End Get
            Set(ByVal value As System.String)
                _CIA02 = value
            End Set
        End Property
#End Region
#Region "鋼捲號碼2 屬性:CIA03"
        Private _CIA03 As System.String
        ''' <summary>
        ''' 鋼捲號碼2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CIA03() As System.String
            Get
                Return _CIA03
            End Get
            Set(ByVal value As System.String)
                _CIA03 = value
            End Set
        End Property
#End Region
#Region "報價單號 屬性:CIA04"
        Private _CIA04 As System.String
        ''' <summary>
        ''' 報價單號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA04() As System.String
            Get
                Return _CIA04
            End Get
            Set(ByVal value As System.String)
                _CIA04 = value
            End Set
        End Property
#End Region
#Region "鋼種 屬性:CIA05"
        Private _CIA05 As System.String
        ''' <summary>
        ''' 鋼種
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA05() As System.String
            Get
                Return _CIA05
            End Get
            Set(ByVal value As System.String)
                _CIA05 = value
            End Set
        End Property
#End Region
#Region "表面 屬性:CIA06"
        Private _CIA06 As System.String
        ''' <summary>
        ''' 表面
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA06() As System.String
            Get
                Return _CIA06
            End Get
            Set(ByVal value As System.String)
                _CIA06 = value
            End Set
        End Property
#End Region
#Region "厚度 屬性:CIA07"
        Private _CIA07 As System.Single
        ''' <summary>
        ''' 厚度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA07() As System.Single
            Get
                Return _CIA07
            End Get
            Set(ByVal value As System.Single)
                _CIA07 = value
            End Set
        End Property
#End Region
#Region "寬度 屬性:CIA08"
        Private _CIA08 As System.Int32
        ''' <summary>
        ''' 寬度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA08() As System.Int32
            Get
                Return _CIA08
            End Get
            Set(ByVal value As System.Int32)
                _CIA08 = value
            End Set
        End Property
#End Region
#Region "長度 屬性:CIA09"
        Private _CIA09 As System.Int32
        ''' <summary>
        ''' 長度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA09() As System.Int32
            Get
                Return _CIA09
            End Get
            Set(ByVal value As System.Int32)
                _CIA09 = value
            End Set
        End Property
#End Region
#Region "內徑 屬性:CIA10"
        Private _CIA10 As System.Int32
        ''' <summary>
        ''' 內徑
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA10() As System.Int32
            Get
                Return _CIA10
            End Get
            Set(ByVal value As System.Int32)
                _CIA10 = value
            End Set
        End Property
#End Region
#Region "數量 屬性:CIA11"
        Private _CIA11 As System.Int32
        ''' <summary>
        ''' 數量
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA11() As System.Int32
            Get
                Return _CIA11
            End Get
            Set(ByVal value As System.Int32)
                _CIA11 = value
            End Set
        End Property
#End Region
#Region "捲、片(C/S) 屬性:CIA12"
        Private _CIA12 As System.String
        ''' <summary>
        ''' 捲、片(C/S)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA12() As System.String
            Get
                Return _CIA12
            End Get
            Set(ByVal value As System.String)
                _CIA12 = value
            End Set
        End Property
#End Region
#Region "淨重KG 屬性:CIA13"
        Private _CIA13 As System.Int32
        ''' <summary>
        ''' 淨重KG
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA13() As System.Int32
            Get
                Return _CIA13
            End Get
            Set(ByVal value As System.Int32)
                _CIA13 = value
            End Set
        End Property
#End Region
#Region "毛重KG 屬性:CIA14"
        Private _CIA14 As System.Int32
        ''' <summary>
        ''' 毛重KG
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA14() As System.Int32
            Get
                Return _CIA14
            End Get
            Set(ByVal value As System.Int32)
                _CIA14 = value
            End Set
        End Property
#End Region
#Region "儲區 屬性:CIA15"
        Private _CIA15 As System.String
        ''' <summary>
        ''' 儲區
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA15() As System.String
            Get
                Return _CIA15
            End Get
            Set(ByVal value As System.String)
                _CIA15 = value
            End Set
        End Property
#End Region
#Region "等級 屬性:CIA16"
        Private _CIA16 As System.String
        ''' <summary>
        ''' 等級(空白為非正常品)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA16() As System.String
            Get
                Return _CIA16
            End Get
            Set(ByVal value As System.String)
                _CIA16 = value
            End Set
        End Property
#End Region
#Region "一級長度 屬性:CIA17"
        Private _CIA17 As System.Int32
        ''' <summary>
        ''' 一級長度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA17() As System.Int32
            Get
                Return _CIA17
            End Get
            Set(ByVal value As System.Int32)
                _CIA17 = value
            End Set
        End Property
#End Region
#Region "二級長度 屬性:CIA18"
        Private _CIA18 As System.Int32
        ''' <summary>
        ''' 二級長度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA18() As System.Int32
            Get
                Return _CIA18
            End Get
            Set(ByVal value As System.Int32)
                _CIA18 = value
            End Set
        End Property
#End Region
#Region "三級長度 屬性:CIA19"
        Private _CIA19 As System.Int32
        ''' <summary>
        ''' 三級長度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA19() As System.Int32
            Get
                Return _CIA19
            End Get
            Set(ByVal value As System.Int32)
                _CIA19 = value
            End Set
        End Property
#End Region
#Region "頭尾長度 屬性:CIA20"
        Private _CIA20 As System.Int32
        ''' <summary>
        ''' 頭尾長度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA20() As System.Int32
            Get
                Return _CIA20
            End Get
            Set(ByVal value As System.Int32)
                _CIA20 = value
            End Set
        End Property
#End Region
#Region "邊切寬度 屬性:CIA21"
        Private _CIA21 As System.Int32
        ''' <summary>
        ''' 邊切寬度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA21() As System.Int32
            Get
                Return _CIA21
            End Get
            Set(ByVal value As System.Int32)
                _CIA21 = value
            End Set
        End Property
#End Region
#Region "廢鋼長度 屬性:CIA22"
        Private _CIA22 As System.Int32
        ''' <summary>
        ''' 廢鋼長度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA22() As System.Int32
            Get
                Return _CIA22
            End Get
            Set(ByVal value As System.Int32)
                _CIA22 = value
            End Set
        End Property
#End Region
#Region "一級重量 屬性:CIA23"
        Private _CIA23 As System.Int32
        ''' <summary>
        ''' 一級重量
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA23() As System.Int32
            Get
                Return _CIA23
            End Get
            Set(ByVal value As System.Int32)
                _CIA23 = value
            End Set
        End Property
#End Region
#Region "二級重量 屬性:CIA24"
        Private _CIA24 As System.Int32
        ''' <summary>
        ''' 二級重量
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA24() As System.Int32
            Get
                Return _CIA24
            End Get
            Set(ByVal value As System.Int32)
                _CIA24 = value
            End Set
        End Property
#End Region
#Region "三級重量 屬性:CIA25"
        Private _CIA25 As System.Int32
        ''' <summary>
        ''' 三級重量
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA25() As System.Int32
            Get
                Return _CIA25
            End Get
            Set(ByVal value As System.Int32)
                _CIA25 = value
            End Set
        End Property
#End Region
#Region "頭尾重量 屬性:CIA26"
        Private _CIA26 As System.Int32
        ''' <summary>
        ''' 頭尾重量
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA26() As System.Int32
            Get
                Return _CIA26
            End Get
            Set(ByVal value As System.Int32)
                _CIA26 = value
            End Set
        End Property
#End Region
#Region "邊切重量 屬性:CIA27"
        Private _CIA27 As System.Int32
        ''' <summary>
        ''' 邊切重量
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA27() As System.Int32
            Get
                Return _CIA27
            End Get
            Set(ByVal value As System.Int32)
                _CIA27 = value
            End Set
        End Property
#End Region
#Region "廢鋼重量 屬性:CIA28"
        Private _CIA28 As System.Int32
        ''' <summary>
        ''' 廢鋼重量
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA28() As System.Int32
            Get
                Return _CIA28
            End Get
            Set(ByVal value As System.Int32)
                _CIA28 = value
            End Set
        End Property
#End Region
#Region "剪料重量 屬性:CIA29"
        Private _CIA29 As System.Int32
        ''' <summary>
        ''' 剪料重量
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA29() As System.Int32
            Get
                Return _CIA29
            End Get
            Set(ByVal value As System.Int32)
                _CIA29 = value
            End Set
        End Property
#End Region
#Region "退貨重量 屬性:CIA30"
        Private _CIA30 As System.Int32
        ''' <summary>
        ''' 退貨重量
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA30() As System.Int32
            Get
                Return _CIA30
            End Get
            Set(ByVal value As System.Int32)
                _CIA30 = value
            End Set
        End Property
#End Region
#Region "損耗重量 屬性:CIA31"
        Private _CIA31 As System.Int32
        ''' <summary>
        ''' 損耗重量
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA31() As System.Int32
            Get
                Return _CIA31
            End Get
            Set(ByVal value As System.Int32)
                _CIA31 = value
            End Set
        End Property
#End Region
#Region "品管檢驗員 屬性:CIA32"
        Private _CIA32 As System.Int32
        ''' <summary>
        ''' 品管檢驗員
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA32() As System.Int32
            Get
                Return _CIA32
            End Get
            Set(ByVal value As System.Int32)
                _CIA32 = value
            End Set
        End Property
#End Region
#Region "PIPE 屬性:CIA33"
        Private _CIA33 As System.String
        ''' <summary>
        ''' PIPE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA33() As System.String
            Get
                Return _CIA33
            End Get
            Set(ByVal value As System.String)
                _CIA33 = value
            End Set
        End Property
#End Region
#Region "外銷 屬性:CIA34"
        Private _CIA34 As System.String
        ''' <summary>
        ''' 外銷
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA34() As System.String
            Get
                Return _CIA34
            End Get
            Set(ByVal value As System.String)
                _CIA34 = value
            End Set
        End Property
#End Region
#Region "序號 屬性:CIA35"
        Private _CIA35 As System.String
        ''' <summary>
        ''' 序號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA35() As System.String
            Get
                Return _CIA35
            End Get
            Set(ByVal value As System.String)
                _CIA35 = value
            End Set
        End Property
#End Region
#Region "TYPE 屬性:CIA36"
        Private _CIA36 As System.String
        ''' <summary>
        ''' TYPE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA36() As System.String
            Get
                Return _CIA36
            End Get
            Set(ByVal value As System.String)
                _CIA36 = value
            End Set
        End Property
#End Region
#Region "代鋼種 屬性:CIA37"
        Private _CIA37 As System.String
        ''' <summary>
        ''' 代鋼種
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA37() As System.String
            Get
                Return _CIA37
            End Get
            Set(ByVal value As System.String)
                _CIA37 = value
            End Set
        End Property
#End Region
#Region "代表面 屬性:CIA38"
        Private _CIA38 As System.String
        ''' <summary>
        ''' 代表面
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA38() As System.String
            Get
                Return _CIA38
            End Get
            Set(ByVal value As System.String)
                _CIA38 = value
            End Set
        End Property
#End Region
#Region "代厚度 屬性:CIA39"
        Private _CIA39 As System.String
        ''' <summary>
        ''' 代厚度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA39() As System.String
            Get
                Return _CIA39
            End Get
            Set(ByVal value As System.String)
                _CIA39 = value
            End Set
        End Property
#End Region
#Region "代寬度 屬性:CIA40"
        Private _CIA40 As System.Int32
        ''' <summary>
        ''' 代寬度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA40() As System.Int32
            Get
                Return _CIA40
            End Get
            Set(ByVal value As System.Int32)
                _CIA40 = value
            End Set
        End Property
#End Region
#Region "代U 屬性:CIA41"
        Private _CIA41 As System.String
        ''' <summary>
        ''' 代"U"
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA41() As System.String
            Get
                Return _CIA41
            End Get
            Set(ByVal value As System.String)
                _CIA41 = value
            End Set
        End Property
#End Region
#Region "代長度 屬性:CIA42"
        Private _CIA42 As System.Int32
        ''' <summary>
        ''' 代長度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA42() As System.Int32
            Get
                Return _CIA42
            End Get
            Set(ByVal value As System.Int32)
                _CIA42 = value
            End Set
        End Property
#End Region
#Region "代內徑 屬性:CIA43"
        Private _CIA43 As System.Int32
        ''' <summary>
        ''' 代內徑
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA43() As System.Int32
            Get
                Return _CIA43
            End Get
            Set(ByVal value As System.Int32)
                _CIA43 = value
            End Set
        End Property
#End Region
#Region "代C/S 屬性:CIA44"
        Private _CIA44 As System.String
        ''' <summary>
        ''' 代C/S
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA44() As System.String
            Get
                Return _CIA44
            End Get
            Set(ByVal value As System.String)
                _CIA44 = value
            End Set
        End Property
#End Region
#Region "繳庫碼 屬性:CIA45"
        Private _CIA45 As System.String
        ''' <summary>
        ''' 繳庫碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA45() As System.String
            Get
                Return _CIA45
            End Get
            Set(ByVal value As System.String)
                _CIA45 = value
            End Set
        End Property
#End Region
#Region "發貨碼 屬性:CIA46"
        Private _CIA46 As System.String
        ''' <summary>
        ''' 繳庫碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA46() As System.String
            Get
                Return _CIA46
            End Get
            Set(ByVal value As System.String)
                _CIA46 = value
            End Set
        End Property
#End Region
#Region "銷退碼 屬性:CIA47"
        Private _CIA47 As System.String
        ''' <summary>
        ''' 銷退碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA47() As System.String
            Get
                Return _CIA47
            End Get
            Set(ByVal value As System.String)
                _CIA47 = value
            End Set
        End Property
#End Region
#Region "改判碼 屬性:CIA48"
        Private _CIA48 As System.String
        ''' <summary>
        ''' 改判碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA48() As System.String
            Get
                Return _CIA48
            End Get
            Set(ByVal value As System.String)
                _CIA48 = value
            End Set
        End Property
#End Region
#Region "組合碼 屬性:CIA49"
        Private _CIA49 As System.String
        ''' <summary>
        ''' 組合碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA49() As System.String
            Get
                Return _CIA49
            End Get
            Set(ByVal value As System.String)
                _CIA49 = value
            End Set
        End Property
#End Region
#Region "無主管理 屬性:CIA50"
        Private _CIA50 As System.String
        ''' <summary>
        ''' 無主管理
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA50() As System.String
            Get
                Return _CIA50
            End Get
            Set(ByVal value As System.String)
                _CIA50 = value
            End Set
        End Property
#End Region
#Region "CODE-7 屬性:CIA51"
        Private _CIA51 As System.String
        ''' <summary>
        ''' CODE-7
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA51() As System.String
            Get
                Return _CIA51
            End Get
            Set(ByVal value As System.String)
                _CIA51 = value
            End Set
        End Property
#End Region
#Region "CODE-8 屬性:CIA52"
        Private _CIA52 As System.String
        ''' <summary>
        ''' CODE-8
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA52() As System.String
            Get
                Return _CIA52
            End Get
            Set(ByVal value As System.String)
                _CIA52 = value
            End Set
        End Property
#End Region
#Region "表面等級 屬性:CIA53"
        Private _CIA53 As System.String
        ''' <summary>
        ''' 表面等級
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA53() As System.String
            Get
                Return _CIA53
            End Get
            Set(ByVal value As System.String)
                _CIA53 = value
            End Set
        End Property
#End Region
#Region "PACKING 屬性:CIA54"        
         Private _CIA54 As System.Int32
        ''' <summary>
        ''' PACKING
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CIA54() As System.Int32
            Get
                Return _CIA54
            End Get
            Set(ByVal value As System.Int32)
                _CIA54 = value
            End Set
        End Property
#End Region
#Region "繳庫日期 屬性:CIA55"        
         Private _CIA55 As System.Int32
        ''' <summary>
        ''' 繳庫日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CIA55() As System.Int32
            Get
                Return _CIA55
            End Get
            Set(ByVal value As System.Int32)
                _CIA55 = value
            End Set
        End Property
#End Region
#Region "會計日期 屬性:CIA58"
        Private _CIA58 As System.Int32
        ''' <summary>
        ''' 會計日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA58() As System.Int32
            Get
                Return _CIA58
            End Get
            Set(ByVal value As System.Int32)
                _CIA58 = value
            End Set
        End Property
#End Region
#Region "繳庫序號 屬性:CIA57"
        Private _CIA57 As System.Int32
        ''' <summary>
        ''' 繳庫序號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA57() As System.Int32
            Get
                Return _CIA57
            End Get
            Set(ByVal value As System.Int32)
                _CIA57 = value
            End Set
        End Property
#End Region
#Region "公稱厚度 屬性:CIA59"
        Private _CIA59 As System.String
        ''' <summary>
        ''' 公稱厚度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA59() As System.String
            Get
                Return _CIA59
            End Get
            Set(ByVal value As System.String)
                _CIA59 = value
            End Set
        End Property
#End Region
#Region "公稱寬度 屬性:CIA60"
        Private _CIA60 As System.Int32
        ''' <summary>
        ''' 公稱寬度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA60() As System.Int32
            Get
                Return _CIA60
            End Get
            Set(ByVal value As System.Int32)
                _CIA60 = value
            End Set
        End Property
#End Region
#Region "毛、修邊 屬性:CIA61"
        Private _CIA61 As System.String
        ''' <summary>
        ''' 毛、修邊
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA61() As System.String
            Get
                Return _CIA61
            End Get
            Set(ByVal value As System.String)
                _CIA61 = value
            End Set
        End Property
#End Region
#Region "提貨單號 屬性:CIA62"
        Private _CIA62 As System.String
        ''' <summary>
        ''' 提貨單號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA62() As System.String
            Get
                Return _CIA62
            End Get
            Set(ByVal value As System.String)
                _CIA62 = value
            End Set
        End Property
#End Region
#Region "提貨單日期 屬性:CIA63"
        Private _CIA63 As System.Int32
        ''' <summary>
        ''' 提貨單日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA63() As System.Int32
            Get
                Return _CIA63
            End Get
            Set(ByVal value As System.Int32)
                _CIA63 = value
            End Set
        End Property
#End Region
#Region "出廠日期 屬性:CIA64"
        Private _CIA64 As System.Int32
        ''' <summary>
        ''' 出廠日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA64() As System.Int32
            Get
                Return _CIA64
            End Get
            Set(ByVal value As System.Int32)
                _CIA64 = value
            End Set
        End Property
#End Region
#Region "出廠時間 屬性:CIA65"
        Private _CIA65 As System.Int32
        ''' <summary>
        ''' 出廠時間
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA65() As System.Int32
            Get
                Return _CIA65
            End Get
            Set(ByVal value As System.Int32)
                _CIA65 = value
            End Set
        End Property
#End Region
#Region "用途 屬性:CIA66"
        Private _CIA66 As System.String
        ''' <summary>
        ''' 用途
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA66() As System.String
            Get
                Return _CIA66
            End Get
            Set(ByVal value As System.String)
                _CIA66 = value
            End Set
        End Property
#End Region
#Region "箱號 屬性:CIA67"
        Private _CIA67 As System.String
        ''' <summary>
        ''' 箱號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA67() As System.String
            Get
                Return _CIA67
            End Get
            Set(ByVal value As System.String)
                _CIA67 = value
            End Set
        End Property
#End Region
#Region "輻射 屬性:CIA68"
        Private _CIA68 As System.Int32
        ''' <summary>
        ''' 輻射
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA68() As System.Int32
            Get
                Return _CIA68
            End Get
            Set(ByVal value As System.Int32)
                _CIA68 = value
            End Set
        End Property
#End Region
#Region "CODE 屬性:CIA69"
        Private _CIA69 As System.String
        ''' <summary>
        ''' CODE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIA69() As System.String
            Get
                Return _CIA69
            End Get
            Set(ByVal value As System.String)
                _CIA69 = value
            End Set
        End Property
#End Region

#Region "一級品重量比率 屬性:CIA23WeightRate"
        ''' <summary>
        ''' 一級品重量比率
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property CIA23WeightRate As Double
            Get
                Return Me.CIA23 / Me.CIA13
            End Get
        End Property
#End Region
#Region "是否為正常品 屬性:IsNormalGOOD"
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property IsNormalGOOD As Boolean
            Get
                Dim MyFace As String = Me.CIA06.Trim
                Return MyFace = "BA" OrElse MyFace = "2B" OrElse MyFace = "NO1" OrElse MyFace = "SH" OrElse MyFace = "2D"
            End Get
        End Property
#End Region
#Region "是否為HR 屬性:IsHR"
        ''' <summary>
        ''' 是否為HR
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property IsHR As Boolean
            Get
                Return Me.CIA06.Trim = "NO1"
            End Get
        End Property
#End Region




#Region "相關提貨單檔 屬性:AboutSL2BOLPF"

        Private _AboutSL2BOLPF As SLS300LB.SL2BOLPF
        ''' <summary>
        ''' 相關提貨單檔
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property AboutSL2BOLPF(Optional ByVal FindDataCach As List(Of SLS300LB.SL2BOLPF) = Nothing) As SLS300LB.SL2BOLPF
            Get
                If IsNothing(_AboutSL2BOLPF) Then
                    If Not IsNothing(FindDataCach) Then
                        For Each EachItem As SLS300LB.SL2BOLPF In FindDataCach
                            If EachItem.BOL02 = Me.CIA62 AndAlso EachItem.BOL16 = Me.CIA02 AndAlso EachItem.BOL17 = Me.CIA03 Then
                                _AboutSL2BOLPF = EachItem : Exit For
                            End If
                        Next
                    End If
                    If IsNothing(_AboutSL2BOLPF) Then
                        Dim QryString = "Select * From " & (New SLS300LB.SL2BOLPF).CDBFullAS400DBPath & " Where BOL02='" & Me.CIA62 & "' AND BOL16='" & Me.CIA02 & "' AND BOL17='" & Me.CIA03 & "' "
                        Dim SearchResult As List(Of SLS300LB.SL2BOLPF) = SLS300LB.SL2BOLPF.CDBSelect(Of SLS300LB.SL2BOLPF)(QryString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                        If SearchResult.Count > 0 Then
                            _AboutSL2BOLPF = SearchResult(0)
                        End If
                    End If
                End If
                Return _AboutSL2BOLPF
            End Get
            Set(ByVal value As SLS300LB.SL2BOLPF)
                _AboutSL2BOLPF = value
            End Set
        End Property

#End Region

#Region "子厚度範圍(型別) 屬性:SubThickArea"
        ''' <summary>
        ''' 子厚度範圍(型別)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property SubThickArea() As String
            Get
                If Me.CIA35 = " " OrElse Me.CIA35 = "1" Then
                    Return "1"
                End If
                Return Me.CIA35
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
                Select Case True
                    Case Me.CIA34 = " "
                        Return True
                    Case Me.CIA34.ToUpper = "X"
                        Return False
                End Select
                Return False
            End Get
        End Property
#End Region
#Region "內外銷中文字串 屬性:ExportORHomeSellString"
        ''' <summary>
        ''' 內外銷中文字串
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property ExportORHomeSellString() As String
            Get
                Return IIf(IsHomeSell, "內銷", "外銷")
            End Get
        End Property
#End Region

#Region "訂購年月 屬性:OrderYearMonth"
        Private _OrderYearMonth As String = Nothing
        ''' <summary>
        ''' 訂購年月
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property OrderYearMonth() As String
            Get
                If IsNothing(_OrderYearMonth) Then
                    _OrderYearMonth = Me.CIA04.Substring(3, 4)
                End If
                Return _OrderYearMonth
            End Get
        End Property
#End Region
#Region "提貨年月 屬性:OutDoorYearMonth"
        Private _OutDoorYearMonth As String = Nothing
        ''' <summary>
        ''' 提貨年月
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property OutDoorYearMonth() As String
            Get
                If IsNothing(_OutDoorYearMonth) Then
                    _OutDoorYearMonth = Me.CIA62.Substring(2, 4)
                End If
                Return _OutDoorYearMonth
            End Get
        End Property
#End Region
    End Class
End Namespace