Namespace PPS100LB
    ''' <summary>
    ''' 繳庫鋼捲判定記錄８３／０２（含）以後
    ''' </summary>
    ''' <remarks></remarks>
    Public Class PPSQCPPF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("PPS100LB", GetType(PPSQCPPF).Name)
        End Sub

#Region "責任單位 屬性:QCP01"
        Private _QCP01 As System.String
        ''' <summary>
        ''' 責任單位
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP01() As System.String
            Get
                Return _QCP01
            End Get
            Set(ByVal value As System.String)
                _QCP01 = value
            End Set
        End Property
#End Region
#Region "鋼捲號碼 屬性:QCP02"
        Private _QCP02 As System.String
        ''' <summary>
        ''' 鋼捲號碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QCP02() As System.String
            Get
                Return _QCP02
            End Get
            Set(ByVal value As System.String)
                _QCP02 = value
            End Set
        End Property
#End Region
#Region "鋼捲斷捲號碼 屬性:QCP03"
        Private _QCP03 As System.String
        ''' <summary>
        ''' 鋼捲斷捲號碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QCP03() As System.String
            Get
                Return _QCP03
            End Get
            Set(ByVal value As System.String)
                _QCP03 = value
            End Set
        End Property
#End Region
#Region "資料日期 屬性:QCP04"
        Private _QCP04 As System.Int32
        ''' <summary>
        ''' 資料日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP04() As System.Int32
            Get
                Return _QCP04
            End Get
            Set(ByVal value As System.Int32)
                _QCP04 = value
            End Set
        End Property
#End Region
#Region "表面 屬性:QCP05"
        Private _QCP05 As System.String
        ''' <summary>
        ''' 表面
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP05() As System.String
            Get
                Return _QCP05
            End Get
            Set(ByVal value As System.String)
                _QCP05 = value
            End Set
        End Property
#End Region
#Region "厚度 屬性:QCP06"
        Private _QCP06 As System.Single
        ''' <summary>
        ''' 厚度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP06() As System.Single
            Get
                Return _QCP06
            End Get
            Set(ByVal value As System.Single)
                _QCP06 = value
            End Set
        End Property
#End Region
#Region "寬度 屬性:QCP07"
        Private _QCP07 As System.Int32
        ''' <summary>
        ''' 寬度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP07() As System.Int32
            Get
                Return _QCP07
            End Get
            Set(ByVal value As System.Int32)
                _QCP07 = value
            End Set
        End Property
#End Region
#Region "長度 屬性:QCP08"
        Private _QCP08 As System.Int32
        ''' <summary>
        ''' 長度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP08() As System.Int32
            Get
                Return _QCP08
            End Get
            Set(ByVal value As System.Int32)
                _QCP08 = value
            End Set
        End Property
#End Region
#Region "鋼片片數 屬性:QCP09"
        Private _QCP09 As System.Int32
        ''' <summary>
        ''' 鋼片片數
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP09() As System.Int32
            Get
                Return _QCP09
            End Get
            Set(ByVal value As System.Int32)
                _QCP09 = value
            End Set
        End Property
#End Region
#Region "等級 屬性:QCP10"
        Private _QCP10 As System.String
        ''' <summary>
        ''' 等級
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP10() As System.String
            Get
                Return _QCP10
            End Get
            Set(ByVal value As System.String)
                _QCP10 = value
            End Set
        End Property
#End Region
#Region "外銷 屬性:QCP11"
        Private _QCP11 As System.String
        ''' <summary>
        ''' 外銷
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP11() As System.String
            Get
                Return _QCP11
            End Get
            Set(ByVal value As System.String)
                _QCP11 = value
            End Set
        End Property
#End Region
#Region "用途 屬性:QCP12"
        Private _QCP12 As System.String
        ''' <summary>
        ''' 用途
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP12() As System.String
            Get
                Return _QCP12
            End Get
            Set(ByVal value As System.String)
                _QCP12 = value
            End Set
        End Property
#End Region
#Region "亮度 屬性:QCP13"
        Private _QCP13 As System.String
        ''' <summary>
        ''' 亮度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP13() As System.String
            Get
                Return _QCP13
            End Get
            Set(ByVal value As System.String)
                _QCP13 = value
            End Set
        End Property
#End Region
#Region "品檢員 屬性:QCP14"
        Private _QCP14 As System.String
        ''' <summary>
        ''' 品檢員
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP14() As System.String
            Get
                Return _QCP14
            End Get
            Set(ByVal value As System.String)
                _QCP14 = value
            End Set
        End Property
#End Region
#Region "一級長度M 屬性:QCP15"
        Private _QCP15 As System.Int32
        ''' <summary>
        ''' 一級長度M
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP15() As System.Int32
            Get
                Return _QCP15
            End Get
            Set(ByVal value As System.Int32)
                _QCP15 = value
            End Set
        End Property
#End Region
#Region "二級長度M 屬性:QCP16"
        Private _QCP16 As System.Int32
        ''' <summary>
        ''' 二級長度M
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP16() As System.Int32
            Get
                Return _QCP16
            End Get
            Set(ByVal value As System.Int32)
                _QCP16 = value
            End Set
        End Property
#End Region
#Region "三級長度M 屬性:QCP17"
        Private _QCP17 As System.Int32
        ''' <summary>
        ''' 三級長度M
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP17() As System.Int32
            Get
                Return _QCP17
            End Get
            Set(ByVal value As System.Int32)
                _QCP17 = value
            End Set
        End Property
#End Region
#Region "頭尾長度M 屬性:QCP18"
        Private _QCP18 As System.Int32
        ''' <summary>
        ''' 頭尾長度M
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP18() As System.Int32
            Get
                Return _QCP18
            End Get
            Set(ByVal value As System.Int32)
                _QCP18 = value
            End Set
        End Property
#End Region
#Region "邊料寬度MM 屬性:QCP19"
        Private _QCP19 As System.Int32
        ''' <summary>
        ''' 邊料寬度MM
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP19() As System.Int32
            Get
                Return _QCP19
            End Get
            Set(ByVal value As System.Int32)
                _QCP19 = value
            End Set
        End Property
#End Region
#Region "廢料長度M 屬性:QCP20"
        Private _QCP20 As System.Int32
        ''' <summary>
        ''' 廢料長度M
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP20() As System.Int32
            Get
                Return _QCP20
            End Get
            Set(ByVal value As System.Int32)
                _QCP20 = value
            End Set
        End Property
#End Region
#Region "一級主要缺陷 屬性:QCP21"
        Private _QCP21 As System.Int32
        ''' <summary>
        ''' 一級主要缺陷
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP21() As System.Int32
            Get
                Return _QCP21
            End Get
            Set(ByVal value As System.Int32)
                _QCP21 = value
            End Set
        End Property
#End Region
#Region "亮度 屬性:QCP22"
        Private _QCP22 As System.Int32
        ''' <summary>
        ''' 亮度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP22() As System.Int32
            Get
                Return _QCP22
            End Get
            Set(ByVal value As System.Int32)
                _QCP22 = value
            End Set
        End Property
#End Region
#Region "一級缺陷程度 屬性:QCP23"
        Private _QCP23 As System.String
        ''' <summary>
        ''' 一級缺陷程度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP23() As System.String
            Get
                Return _QCP23
            End Get
            Set(ByVal value As System.String)
                _QCP23 = value
            End Set
        End Property
#End Region
#Region "二級主要缺陷１ 屬性:QCP24"
        Private _QCP24 As System.Int32
        ''' <summary>
        ''' 二級主要缺陷１
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP24() As System.Int32
            Get
                Return _QCP24
            End Get
            Set(ByVal value As System.Int32)
                _QCP24 = value
            End Set
        End Property
#End Region
#Region "二級缺陷１長度M 屬性:QCP25"
        Private _QCP25 As System.Int32
        ''' <summary>
        ''' 二級缺陷１長度M
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP25() As System.Int32
            Get
                Return _QCP25
            End Get
            Set(ByVal value As System.Int32)
                _QCP25 = value
            End Set
        End Property
#End Region
#Region "二級缺陷１程度 屬性:QCP26"
        Private _QCP26 As System.String
        ''' <summary>
        ''' 二級缺陷１程度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP26() As System.String
            Get
                Return _QCP26
            End Get
            Set(ByVal value As System.String)
                _QCP26 = value
            End Set
        End Property
#End Region
#Region "二級主要缺陷２ 屬性:QCP27"
        Private _QCP27 As System.Int32
        ''' <summary>
        ''' 二級主要缺陷２
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP27() As System.Int32
            Get
                Return _QCP27
            End Get
            Set(ByVal value As System.Int32)
                _QCP27 = value
            End Set
        End Property
#End Region
#Region "二級缺陷２長度M 屬性:QCP28"
        Private _QCP28 As System.Int32
        ''' <summary>
        ''' 二級缺陷２長度M
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP28() As System.Int32
            Get
                Return _QCP28
            End Get
            Set(ByVal value As System.Int32)
                _QCP28 = value
            End Set
        End Property
#End Region
#Region "二級缺陷２程度 屬性:QCP29"
        Private _QCP29 As System.String
        ''' <summary>
        ''' 二級缺陷２程度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP29() As System.String
            Get
                Return _QCP29
            End Get
            Set(ByVal value As System.String)
                _QCP29 = value
            End Set
        End Property
#End Region
#Region "二級主要缺陷３ 屬性:QCP30"
        Private _QCP30 As System.Int32
        ''' <summary>
        ''' 二級主要缺陷３
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP30() As System.Int32
            Get
                Return _QCP30
            End Get
            Set(ByVal value As System.Int32)
                _QCP30 = value
            End Set
        End Property
#End Region
#Region "二級缺陷３長度M 屬性:QCP31"
        Private _QCP31 As System.Int32
        ''' <summary>
        ''' 二級缺陷３長度M
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP31() As System.Int32
            Get
                Return _QCP31
            End Get
            Set(ByVal value As System.Int32)
                _QCP31 = value
            End Set
        End Property
#End Region
#Region "二級缺陷３程度 屬性:QCP32"
        Private _QCP32 As System.String
        ''' <summary>
        ''' 二級缺陷３程度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP32() As System.String
            Get
                Return _QCP32
            End Get
            Set(ByVal value As System.String)
                _QCP32 = value
            End Set
        End Property
#End Region
#Region "二級主要缺陷４ 屬性:QCP33"
        Private _QCP33 As System.Int32
        ''' <summary>
        ''' 二級主要缺陷４
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP33() As System.Int32
            Get
                Return _QCP33
            End Get
            Set(ByVal value As System.Int32)
                _QCP33 = value
            End Set
        End Property
#End Region
#Region "二級缺陷４長度M 屬性:QCP34"
        Private _QCP34 As System.Int32
        ''' <summary>
        ''' 二級缺陷４長度M
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP34() As System.Int32
            Get
                Return _QCP34
            End Get
            Set(ByVal value As System.Int32)
                _QCP34 = value
            End Set
        End Property
#End Region
#Region "二級缺陷４程度 屬性:QCP35"
        Private _QCP35 As System.String
        ''' <summary>
        ''' 二級缺陷４程度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP35() As System.String
            Get
                Return _QCP35
            End Get
            Set(ByVal value As System.String)
                _QCP35 = value
            End Set
        End Property
#End Region
#Region "三級主要缺陷１ 屬性:QCP36"
        Private _QCP36 As System.Int32
        ''' <summary>
        ''' 三級主要缺陷１
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP36() As System.Int32
            Get
                Return _QCP36
            End Get
            Set(ByVal value As System.Int32)
                _QCP36 = value
            End Set
        End Property
#End Region
#Region "三級缺陷１長度M 屬性:QCP37"
        Private _QCP37 As System.Int32
        ''' <summary>
        ''' 三級缺陷１長度M
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP37() As System.Int32
            Get
                Return _QCP37
            End Get
            Set(ByVal value As System.Int32)
                _QCP37 = value
            End Set
        End Property
#End Region
#Region "三級缺陷１程度 屬性:QCP38"
        Private _QCP38 As System.String
        ''' <summary>
        ''' 三級缺陷１程度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP38() As System.String
            Get
                Return _QCP38
            End Get
            Set(ByVal value As System.String)
                _QCP38 = value
            End Set
        End Property
#End Region
#Region "三級主要缺陷２ 屬性:QCP39"
        Private _QCP39 As System.Int32
        ''' <summary>
        ''' 三級主要缺陷２
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP39() As System.Int32
            Get
                Return _QCP39
            End Get
            Set(ByVal value As System.Int32)
                _QCP39 = value
            End Set
        End Property
#End Region
#Region "三級缺陷２長度M 屬性:QCP40"
        Private _QCP40 As System.Int32
        ''' <summary>
        ''' 三級缺陷２長度M
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP40() As System.Int32
            Get
                Return _QCP40
            End Get
            Set(ByVal value As System.Int32)
                _QCP40 = value
            End Set
        End Property
#End Region
#Region "三級缺陷２程度 屬性:QCP41"
        Private _QCP41 As System.String
        ''' <summary>
        ''' 三級缺陷２程度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP41() As System.String
            Get
                Return _QCP41
            End Get
            Set(ByVal value As System.String)
                _QCP41 = value
            End Set
        End Property
#End Region
#Region "三級主要缺陷３ 屬性:QCP42"
        Private _QCP42 As System.Int32
        ''' <summary>
        ''' 三級主要缺陷３
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP42() As System.Int32
            Get
                Return _QCP42
            End Get
            Set(ByVal value As System.Int32)
                _QCP42 = value
            End Set
        End Property
#End Region
#Region "三級缺陷３長度M 屬性:QCP43"
        Private _QCP43 As System.Int32
        ''' <summary>
        ''' 三級缺陷３長度M
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP43() As System.Int32
            Get
                Return _QCP43
            End Get
            Set(ByVal value As System.Int32)
                _QCP43 = value
            End Set
        End Property
#End Region
#Region "三級缺陷３程度 屬性:QCP44"
        Private _QCP44 As System.String
        ''' <summary>
        ''' 三級缺陷３程度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP44() As System.String
            Get
                Return _QCP44
            End Get
            Set(ByVal value As System.String)
                _QCP44 = value
            End Set
        End Property
#End Region
#Region "三級主要缺陷４ 屬性:QCP45"
        Private _QCP45 As System.Int32
        ''' <summary>
        ''' 三級主要缺陷４
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP45() As System.Int32
            Get
                Return _QCP45
            End Get
            Set(ByVal value As System.Int32)
                _QCP45 = value
            End Set
        End Property
#End Region
#Region "三級缺陷４長度M 屬性:QCP46"
        Private _QCP46 As System.Int32
        ''' <summary>
        ''' 三級缺陷４長度M
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP46() As System.Int32
            Get
                Return _QCP46
            End Get
            Set(ByVal value As System.Int32)
                _QCP46 = value
            End Set
        End Property
#End Region
#Region "三級缺陷４程度 屬性:QCP47"
        Private _QCP47 As System.String
        ''' <summary>
        ''' 三級缺陷４程度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP47() As System.String
            Get
                Return _QCP47
            End Get
            Set(ByVal value As System.String)
                _QCP47 = value
            End Set
        End Property
#End Region
#Region "頭尾主要缺陷 屬性:QCP48"
        Private _QCP48 As System.Int32
        ''' <summary>
        ''' 頭尾主要缺陷
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP48() As System.Int32
            Get
                Return _QCP48
            End Get
            Set(ByVal value As System.Int32)
                _QCP48 = value
            End Set
        End Property
#End Region
#Region "頭尾缺陷長度M 屬性:QCP49"
        Private _QCP49 As System.Int32
        ''' <summary>
        ''' 頭尾缺陷長度M
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP49() As System.Int32
            Get
                Return _QCP49
            End Get
            Set(ByVal value As System.Int32)
                _QCP49 = value
            End Set
        End Property
#End Region
#Region "頭尾缺陷程度 屬性:QCP50"
        Private _QCP50 As System.String
        ''' <summary>
        ''' 頭尾缺陷程度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP50() As System.String
            Get
                Return _QCP50
            End Get
            Set(ByVal value As System.String)
                _QCP50 = value
            End Set
        End Property
#End Region
#Region "邊料主要缺陷 屬性:QCP51"
        Private _QCP51 As System.Int32
        ''' <summary>
        ''' 邊料主要缺陷
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP51() As System.Int32
            Get
                Return _QCP51
            End Get
            Set(ByVal value As System.Int32)
                _QCP51 = value
            End Set
        End Property
#End Region
#Region "邊料缺陷內側MM 屬性:QCP52"
        Private _QCP52 As System.Int32
        ''' <summary>
        ''' 邊料缺陷內側MM
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP52() As System.Int32
            Get
                Return _QCP52
            End Get
            Set(ByVal value As System.Int32)
                _QCP52 = value
            End Set
        End Property
#End Region
#Region "內側缺陷程度 屬性:QCP53"
        Private _QCP53 As System.String
        ''' <summary>
        ''' 內側缺陷程度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP53() As System.String
            Get
                Return _QCP53
            End Get
            Set(ByVal value As System.String)
                _QCP53 = value
            End Set
        End Property
#End Region
#Region "邊料缺陷外側MM 屬性:QCP54"
        Private _QCP54 As System.Int32
        ''' <summary>
        ''' 邊料缺陷外側MM
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP54() As System.Int32
            Get
                Return _QCP54
            End Get
            Set(ByVal value As System.Int32)
                _QCP54 = value
            End Set
        End Property
#End Region
#Region "外側缺陷程度 屬性:QCP55"
        Private _QCP55 As System.String
        ''' <summary>
        ''' 外側缺陷程度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP55() As System.String
            Get
                Return _QCP55
            End Get
            Set(ByVal value As System.String)
                _QCP55 = value
            End Set
        End Property
#End Region
#Region "廢料主要缺陷 屬性:QCP56"
        Private _QCP56 As System.Int32
        ''' <summary>
        ''' 廢料主要缺陷
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP56() As System.Int32
            Get
                Return _QCP56
            End Get
            Set(ByVal value As System.Int32)
                _QCP56 = value
            End Set
        End Property
#End Region
#Region "廢料缺陷長度M 屬性:QCP57"
        Private _QCP57 As System.Int32
        ''' <summary>
        ''' 廢料缺陷長度M
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP57() As System.Int32
            Get
                Return _QCP57
            End Get
            Set(ByVal value As System.Int32)
                _QCP57 = value
            End Set
        End Property
#End Region
#Region "廢料缺陷程度 屬性:QCP58"
        Private _QCP58 As System.String
        ''' <summary>
        ''' 廢料缺陷程度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP58() As System.String
            Get
                Return _QCP58
            End Get
            Set(ByVal value As System.String)
                _QCP58 = value
            End Set
        End Property
#End Region
#Region "結帳日期 屬性:QCP59"
        Private _QCP59 As System.Int32
        ''' <summary>
        ''' 結帳日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QCP59() As System.Int32
            Get
                Return _QCP59
            End Get
            Set(ByVal value As System.Int32)
                _QCP59 = value
            End Set
        End Property
#End Region
#Region "CODE-1 屬性:QCP91"
        Private _QCP91 As System.String
        ''' <summary>
        ''' CODE-1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP91() As System.String
            Get
                Return _QCP91
            End Get
            Set(ByVal value As System.String)
                _QCP91 = value
            End Set
        End Property
#End Region
#Region "CODE-2 屬性:QCP92"
        Private _QCP92 As System.String
        ''' <summary>
        ''' CODE-2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP92() As System.String
            Get
                Return _QCP92
            End Get
            Set(ByVal value As System.String)
                _QCP92 = value
            End Set
        End Property
#End Region
#Region "CODE-3 屬性:QCP93"
        Private _QCP93 As System.String
        ''' <summary>
        ''' CODE-3
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QCP93() As System.String
            Get
                Return _QCP93
            End Get
            Set(ByVal value As System.String)
                _QCP93 = value
            End Set
        End Property
#End Region

#Region "主要缺陷 屬性:MainDefects"

        Private _MainDefects As List(Of DefectClass) = Nothing
        ''' <summary>
        ''' 主要缺陷
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MainDefects() As List(Of DefectClass)
            Get
                If IsNothing(_MainDefects) Then
                    _MainDefects = New List(Of DefectClass)
                    Select Case Me.QCP10
                        Case "1"
                            If Me.QCP21 > 0 Then
                                Dim AddItem As New DefectClass(Me)
                                With AddItem
                                    .Level = 1
                                    .DefectCode = Me.CDBGetFieldValue("QCP21")
                                    .DefectLevel = Me.CDBGetFieldValue("QCP23")
                                End With
                                _MainDefects.Add(AddItem)

                            End If
                        Case "2"
                            For ColumnCount As Integer = 24 To 33 Step 3
                                If CType(Me.CDBGetFieldValue("QCP" & ColumnCount), Integer) > 0 Then
                                    Dim AddItem As New DefectClass(Me)
                                    With AddItem
                                        .Level = 2
                                        .DefectCode = CType(Me.CDBGetFieldValue("QCP" & ColumnCount), Integer)
                                        .DefectLength = CType(Me.CDBGetFieldValue("QCP" & ColumnCount + 1), Integer)
                                        .DefectLevel = CType(Me.CDBGetFieldValue("QCP" & ColumnCount + 2), String)
                                    End With
                                    _MainDefects.Add(AddItem)
                                End If
                            Next
                        Case "3"
                            For ColumnCount As Integer = 36 To 45 Step 3
                                If CType(Me.CDBGetFieldValue("QCP" & ColumnCount), Integer) > 0 Then
                                    Dim AddItem As New DefectClass(Me)
                                    With AddItem
                                        .Level = 3
                                        .DefectCode = CType(Me.CDBGetFieldValue("QCP" & ColumnCount), Integer)
                                        .DefectLength = CType(Me.CDBGetFieldValue("QCP" & ColumnCount + 1), Integer)
                                        .DefectLevel = CType(Me.CDBGetFieldValue("QCP" & ColumnCount + 2), String)
                                    End With
                                    _MainDefects.Add(AddItem)
                                End If
                            Next
                    End Select

                End If
                Return _MainDefects
            End Get
            Private Set(ByVal value As List(Of DefectClass))
                _MainDefects = value
            End Set
        End Property

#End Region
#Region "相關PPSQDEPF 屬性:About_PPSQDEPFs"
        Private _About_PPSQDEPFs As List(Of PPSQDEPF)
        ''' <summary>
        ''' 相關PPSQDEPF
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property About_PPSQDEPFs() As List(Of PPSQDEPF)
            Get
                If IsNothing(_About_PPSQDEPFs) Then
                    Dim SQLString As String = "Select * From " & (New PPSQDEPF).CDBFullAS400DBPath & "Where QDE02='" & Me.QCP02 & "' AND QDE03='" & Me.QCP03 & "' AND QDE04>=" & Me.QCP59
                    _About_PPSQDEPFs = PPSQDEPF.CDBSelect(Of PPSQDEPF)(SQLString, Me.CDBCurrentUseSQLQueryAdapter)
                End If
                Return _About_PPSQDEPFs
            End Get
        End Property
#End Region

#Region "缺陷類別  類別:DefectClass"
        ''' <summary>
        ''' 缺陷類別
        ''' </summary>
        ''' <remarks></remarks>
        Class DefectClass

            Sub New(ByVal SetAboutPPSQCPPF As PPS100LB.PPSQCPPF)
                Me.AboutPPSQCPPF = SetAboutPPSQCPPF
            End Sub

#Region "等級 屬性:Level"

            Private _Level As Integer
            ''' <summary>
            ''' 等級
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Level() As Integer
                Get
                    Return _Level
                End Get
                Set(ByVal value As Integer)
                    _Level = value
                End Set
            End Property

#End Region
#Region "缺陷代碼 屬性:DefectCode"

            Private _DefectCode As Integer
            ''' <summary>
            ''' 缺陷代碼
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property DefectCode() As Integer
                Get
                    Return _DefectCode
                End Get
                Set(ByVal value As Integer)
                    _DefectCode = value
                End Set
            End Property

#End Region
#Region "缺陷長度 屬性:DefectLength"

            Private _DefectLength As Integer
            ''' <summary>
            ''' 缺陷長度
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property DefectLength() As Integer
                Get
                    Return _DefectLength
                End Get
                Set(ByVal value As Integer)
                    _DefectLength = value
                End Set
            End Property

#End Region
#Region "缺陷程度 屬性:DefectLevel"

            Private _DefectLevel As String
            ''' <summary>
            ''' 缺陷程度
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property DefectLevel() As String
                Get
                    Return _DefectLevel
                End Get
                Set(ByVal value As String)
                    _DefectLevel = value
                End Set
            End Property

#End Region
#Region "缺陷代碼中文說明  屬性:DefectCodeExplainString"
            ''' <summary>
            ''' 缺陷代碼中文說明
            ''' </summary>
            ''' <remarks></remarks>
            Private _DefectCodeExplainString As String
            ReadOnly Property DefectCodeExplainString() As String
                Get
                    If IsNothing(_DefectCodeExplainString) Then
                        For Each EachItem As PPSDEFPF In PPSDEFPF.ALL_PPSDEPF(Me.AboutPPSQCPPF.CDBCurrentUseSQLQueryAdapter)
                            If EachItem.DEF01 = Me.DefectCode Then
                                _DefectCodeExplainString = EachItem.DEF02
                                Exit For
                            End If
                        Next
                    End If
                    Return _DefectCodeExplainString
                End Get
            End Property
#End Region
#Region "相關繳庫鋼捲判定記錄 屬性:AboutPPSQCPPF"

            Private _AboutPPSQCPPF As PPSQCPPF
            ''' <summary>
            ''' 相關繳庫鋼捲判定記錄
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property AboutPPSQCPPF() As PPSQCPPF
                Get
                    Return _AboutPPSQCPPF
                End Get
                Private Set(ByVal value As PPSQCPPF)
                    _AboutPPSQCPPF = value
                End Set
            End Property
#End Region
        End Class
#End Region

    End Class
End Namespace