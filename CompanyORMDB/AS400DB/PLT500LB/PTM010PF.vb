Namespace PLT500LB
    ''' <summary>
    ''' 人事基本資料作業(基本資料檔)
    ''' </summary>
    ''' <remarks></remarks>
    Public Class PTM010PF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("PLT500LB", GetType(PTM010PF).Name)
        End Sub

#Region "中文姓名 屬性:PT0101"
        Private _PT0101 As System.String
        ''' <summary>
        ''' 中文姓名
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0101() As System.String
            Get
                Return _PT0101
            End Get
            Set(ByVal value As System.String)
                _PT0101 = value
            End Set
        End Property
#End Region
#Region "員工編號 屬性:PT0102"
        Private _PT0102 As System.String
        ''' <summary>
        ''' 員工編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property PT0102() As System.String
            Get
                Return _PT0102
            End Get
            Set(ByVal value As System.String)
                _PT0102 = value
            End Set
        End Property
#End Region
#Region "英文姓名 屬性:PT0103"
        Private _PT0103 As System.String
        ''' <summary>
        ''' 英文姓名
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0103() As System.String
            Get
                Return _PT0103
            End Get
            Set(ByVal value As System.String)
                _PT0103 = value
            End Set
        End Property
#End Region
#Region "身份証號 屬性:PT0104"
        Private _PT0104 As System.String
        ''' <summary>
        ''' 身份証號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0104() As System.String
            Get
                Return _PT0104
            End Get
            Set(ByVal value As System.String)
                _PT0104 = value
            End Set
        End Property
#End Region
#Region "護照號碼 屬性:PT0105"
        Private _PT0105 As System.String
        ''' <summary>
        ''' 護照號碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0105() As System.String
            Get
                Return _PT0105
            End Get
            Set(ByVal value As System.String)
                _PT0105 = value
            End Set
        End Property
#End Region
#Region "性別碼 屬性:PT0106"
        Private _PT0106 As System.String
        ''' <summary>
        ''' 性別碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0106() As System.String
            Get
                Return _PT0106
            End Get
            Set(ByVal value As System.String)
                _PT0106 = value
            End Set
        End Property
#End Region
#Region "性別 屬性:PT0107"
        Private _PT0107 As System.String
        ''' <summary>
        ''' 性別
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0107() As System.String
            Get
                Return _PT0107
            End Get
            Set(ByVal value As System.String)
                _PT0107 = value
            End Set
        End Property
#End Region
#Region "婚姻碼 屬性:PT0108"
        Private _PT0108 As System.String
        ''' <summary>
        ''' 婚姻碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0108() As System.String
            Get
                Return _PT0108
            End Get
            Set(ByVal value As System.String)
                _PT0108 = value
            End Set
        End Property
#End Region
#Region "婚姻 屬性:PT0109"
        Private _PT0109 As System.String
        ''' <summary>
        ''' 婚姻
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0109() As System.String
            Get
                Return _PT0109
            End Get
            Set(ByVal value As System.String)
                _PT0109 = value
            End Set
        End Property
#End Region
#Region "出生日期 屬性:PT0110"
        Private _PT0110 As System.String
        ''' <summary>
        ''' 出生日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0110() As System.String
            Get
                Return _PT0110
            End Get
            Set(ByVal value As System.String)
                _PT0110 = value
            End Set
        End Property
#End Region
#Region "入廠日期 屬性:PT0111"
        Private _PT0111 As System.String
        ''' <summary>
        ''' 入廠日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0111() As System.String
            Get
                Return _PT0111
            End Get
            Set(ByVal value As System.String)
                _PT0111 = value
            End Set
        End Property
#End Region
#Region "國籍碼 屬性:PT0112"
        Private _PT0112 As System.String
        ''' <summary>
        ''' 國籍碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0112() As System.String
            Get
                Return _PT0112
            End Get
            Set(ByVal value As System.String)
                _PT0112 = value
            End Set
        End Property
#End Region
#Region "籍貫省市碼 屬性:PT0113"
        Private _PT0113 As System.String
        ''' <summary>
        ''' 籍貫省市碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0113() As System.String
            Get
                Return _PT0113
            End Get
            Set(ByVal value As System.String)
                _PT0113 = value
            End Set
        End Property
#End Region
#Region "籍貫省市 屬性:PT0114"
        Private _PT0114 As System.String
        ''' <summary>
        ''' 籍貫省市
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0114() As System.String
            Get
                Return _PT0114
            End Get
            Set(ByVal value As System.String)
                _PT0114 = value
            End Set
        End Property
#End Region
#Region "籍貫縣市 屬性:PT0115"
        Private _PT0115 As System.String
        ''' <summary>
        ''' 籍貫縣市
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0115() As System.String
            Get
                Return _PT0115
            End Get
            Set(ByVal value As System.String)
                _PT0115 = value
            End Set
        End Property
#End Region
#Region "政黨碼 屬性:PT0116"
        Private _PT0116 As System.String
        ''' <summary>
        ''' 政黨碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0116() As System.String
            Get
                Return _PT0116
            End Get
            Set(ByVal value As System.String)
                _PT0116 = value
            End Set
        End Property
#End Region
#Region "政黨 屬性:PT0117"
        Private _PT0117 As System.String
        ''' <summary>
        ''' 政黨
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0117() As System.String
            Get
                Return _PT0117
            End Get
            Set(ByVal value As System.String)
                _PT0117 = value
            End Set
        End Property
#End Region
#Region "宗教碼 屬性:PT0118"
        Private _PT0118 As System.String
        ''' <summary>
        ''' 宗教碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0118() As System.String
            Get
                Return _PT0118
            End Get
            Set(ByVal value As System.String)
                _PT0118 = value
            End Set
        End Property
#End Region
#Region "宗教 屬性:PT0119"
        Private _PT0119 As System.String
        ''' <summary>
        ''' 宗教
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0119() As System.String
            Get
                Return _PT0119
            End Get
            Set(ByVal value As System.String)
                _PT0119 = value
            End Set
        End Property
#End Region
#Region "身高 屬性:PT0120"
        Private _PT0120 As System.Int32
        ''' <summary>
        ''' 身高
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0120() As System.Int32
            Get
                Return _PT0120
            End Get
            Set(ByVal value As System.Int32)
                _PT0120 = value
            End Set
        End Property
#End Region
#Region "體重 屬性:PT0121"
        Private _PT0121 As System.Int32
        ''' <summary>
        ''' 體重
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0121() As System.Int32
            Get
                Return _PT0121
            End Get
            Set(ByVal value As System.Int32)
                _PT0121 = value
            End Set
        End Property
#End Region
#Region "血型 屬性:PT0122"
        Private _PT0122 As System.String
        ''' <summary>
        ''' 血型
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0122() As System.String
            Get
                Return _PT0122
            End Get
            Set(ByVal value As System.String)
                _PT0122 = value
            End Set
        End Property
#End Region
#Region "戶籍郵遞區號 屬性:PT0123"
        Private _PT0123 As System.String
        ''' <summary>
        ''' 戶籍郵遞區號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0123() As System.String
            Get
                Return _PT0123
            End Get
            Set(ByVal value As System.String)
                _PT0123 = value
            End Set
        End Property
#End Region
#Region "戶籍地址 屬性:PT0124"
        Private _PT0124 As System.String
        ''' <summary>
        ''' 戶籍地址
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0124() As System.String
            Get
                Return _PT0124
            End Get
            Set(ByVal value As System.String)
                _PT0124 = value
            End Set
        End Property
#End Region
#Region "現居郵遞區號 屬性:PT0125"
        Private _PT0125 As System.String
        ''' <summary>
        ''' 現居郵遞區號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0125() As System.String
            Get
                Return _PT0125
            End Get
            Set(ByVal value As System.String)
                _PT0125 = value
            End Set
        End Property
#End Region
#Region "現居地址 屬性:PT0126"
        Private _PT0126 As System.String
        ''' <summary>
        ''' 現居地址
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0126() As System.String
            Get
                Return _PT0126
            End Get
            Set(ByVal value As System.String)
                _PT0126 = value
            End Set
        End Property
#End Region
#Region "住宅電話 屬性:PT0127"
        Private _PT0127 As System.String
        ''' <summary>
        ''' 住宅電話
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0127() As System.String
            Get
                Return _PT0127
            End Get
            Set(ByVal value As System.String)
                _PT0127 = value
            End Set
        End Property
#End Region
#Region "役別碼 屬性:PT0128"
        Private _PT0128 As System.String
        ''' <summary>
        ''' 役別碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0128() As System.String
            Get
                Return _PT0128
            End Get
            Set(ByVal value As System.String)
                _PT0128 = value
            End Set
        End Property
#End Region
#Region "役別說明 屬性:PT0129"
        Private _PT0129 As System.String
        ''' <summary>
        ''' 役別說明
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0129() As System.String
            Get
                Return _PT0129
            End Get
            Set(ByVal value As System.String)
                _PT0129 = value
            End Set
        End Property
#End Region
#Region "軍種碼 屬性:PT0130"
        Private _PT0130 As System.String
        ''' <summary>
        ''' 軍種碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0130() As System.String
            Get
                Return _PT0130
            End Get
            Set(ByVal value As System.String)
                _PT0130 = value
            End Set
        End Property
#End Region
#Region "軍種 屬性:PT0131"
        Private _PT0131 As System.String
        ''' <summary>
        ''' 軍種
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0131() As System.String
            Get
                Return _PT0131
            End Get
            Set(ByVal value As System.String)
                _PT0131 = value
            End Set
        End Property
#End Region
#Region "兵科碼 屬性:PT0132"
        Private _PT0132 As System.String
        ''' <summary>
        ''' 兵科碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0132() As System.String
            Get
                Return _PT0132
            End Get
            Set(ByVal value As System.String)
                _PT0132 = value
            End Set
        End Property
#End Region
#Region "兵科 屬性:PT0133"
        Private _PT0133 As System.String
        ''' <summary>
        ''' 兵科
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0133() As System.String
            Get
                Return _PT0133
            End Get
            Set(ByVal value As System.String)
                _PT0133 = value
            End Set
        End Property
#End Region
#Region "軍階碼 屬性:PT0134"
        Private _PT0134 As System.String
        ''' <summary>
        ''' 軍階碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0134() As System.String
            Get
                Return _PT0134
            End Get
            Set(ByVal value As System.String)
                _PT0134 = value
            End Set
        End Property
#End Region
#Region "軍階 屬性:PT0135"
        Private _PT0135 As System.String
        ''' <summary>
        ''' 軍階
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0135() As System.String
            Get
                Return _PT0135
            End Get
            Set(ByVal value As System.String)
                _PT0135 = value
            End Set
        End Property
#End Region
#Region "服役起 屬性:PT0136"
        Private _PT0136 As System.String
        ''' <summary>
        ''' 服役起
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0136() As System.String
            Get
                Return _PT0136
            End Get
            Set(ByVal value As System.String)
                _PT0136 = value
            End Set
        End Property
#End Region
#Region "服役訖 屬性:PT0137"
        Private _PT0137 As System.String
        ''' <summary>
        ''' 服役訖
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0137() As System.String
            Get
                Return _PT0137
            End Get
            Set(ByVal value As System.String)
                _PT0137 = value
            End Set
        End Property
#End Region
#Region "兵籍號碼 屬性:PT0138"
        Private _PT0138 As System.String
        ''' <summary>
        ''' 兵籍號碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0138() As System.String
            Get
                Return _PT0138
            End Get
            Set(ByVal value As System.String)
                _PT0138 = value
            End Set
        End Property
#End Region
#Region "團管區碼 屬性:PT0139"
        Private _PT0139 As System.String
        ''' <summary>
        ''' 團管區碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0139() As System.String
            Get
                Return _PT0139
            End Get
            Set(ByVal value As System.String)
                _PT0139 = value
            End Set
        End Property
#End Region
#Region "團管區 屬性:PT0140"
        Private _PT0140 As System.String
        ''' <summary>
        ''' 團管區
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0140() As System.String
            Get
                Return _PT0140
            End Get
            Set(ByVal value As System.String)
                _PT0140 = value
            End Set
        End Property
#End Region
#Region "已辦緩召 屬性:PT0141"
        Private _PT0141 As System.String
        ''' <summary>
        ''' 已辦緩召
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0141() As System.String
            Get
                Return _PT0141
            End Get
            Set(ByVal value As System.String)
                _PT0141 = value
            End Set
        End Property
#End Region
#Region "主要專長碼 屬性:PT0142"
        Private _PT0142 As System.String
        ''' <summary>
        ''' 主要專長碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0142() As System.String
            Get
                Return _PT0142
            End Get
            Set(ByVal value As System.String)
                _PT0142 = value
            End Set
        End Property
#End Region
#Region "主要專長 屬性:PT0143"
        Private _PT0143 As System.String
        ''' <summary>
        ''' 主要專長
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0143() As System.String
            Get
                Return _PT0143
            End Get
            Set(ByVal value As System.String)
                _PT0143 = value
            End Set
        End Property
#End Region
#Region "次要專長碼 屬性:PT0144"
        Private _PT0144 As System.String
        ''' <summary>
        ''' 次要專長碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0144() As System.String
            Get
                Return _PT0144
            End Get
            Set(ByVal value As System.String)
                _PT0144 = value
            End Set
        End Property
#End Region
#Region "次要專長 屬性:PT0145"
        Private _PT0145 As System.String
        ''' <summary>
        ''' 次要專長
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0145() As System.String
            Get
                Return _PT0145
            End Get
            Set(ByVal value As System.String)
                _PT0145 = value
            End Set
        End Property
#End Region
#Region "未入公司公職年資年 屬性:PT0146"
        Private _PT0146 As System.Int32
        ''' <summary>
        ''' 未入公司公職年資年
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0146() As System.Int32
            Get
                Return _PT0146
            End Get
            Set(ByVal value As System.Int32)
                _PT0146 = value
            End Set
        End Property
#End Region
#Region "未入公司公職年資月 屬性:PT0147"
        Private _PT0147 As System.Int32
        ''' <summary>
        ''' 未入公司公職年資月
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0147() As System.Int32
            Get
                Return _PT0147
            End Get
            Set(ByVal value As System.Int32)
                _PT0147 = value
            End Set
        End Property
#End Region
#Region "任公職原因碼 屬性:PT0148"
        Private _PT0148 As System.String
        ''' <summary>
        ''' 任公職原因碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0148() As System.String
            Get
                Return _PT0148
            End Get
            Set(ByVal value As System.String)
                _PT0148 = value
            End Set
        End Property
#End Region
#Region "任公職原因 屬性:PT0149"
        Private _PT0149 As System.String
        ''' <summary>
        ''' 任公職原因
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0149() As System.String
            Get
                Return _PT0149
            End Get
            Set(ByVal value As System.String)
                _PT0149 = value
            End Set
        End Property
#End Region
#Region "最近入公司日期 屬性:PT0150"
        Private _PT0150 As System.String
        ''' <summary>
        ''' 最近入公司日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0150() As System.String
            Get
                Return _PT0150
            End Get
            Set(ByVal value As System.String)
                _PT0150 = value
            End Set
        End Property
#End Region
#Region "填表日期 屬性:PT0151"
        Private _PT0151 As System.String
        ''' <summary>
        ''' 填表日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0151() As System.String
            Get
                Return _PT0151
            End Get
            Set(ByVal value As System.String)
                _PT0151 = value
            End Set
        End Property
#End Region
#Region "緊急連絡人 屬性:PT0152"
        Private _PT0152 As System.String
        ''' <summary>
        ''' 緊急連絡人
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0152() As System.String
            Get
                Return _PT0152
            End Get
            Set(ByVal value As System.String)
                _PT0152 = value
            End Set
        End Property
#End Region
#Region "緊急連絡人關係 屬性:PT0153"
        Private _PT0153 As System.String
        ''' <summary>
        ''' 緊急連絡人關係
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0153() As System.String
            Get
                Return _PT0153
            End Get
            Set(ByVal value As System.String)
                _PT0153 = value
            End Set
        End Property
#End Region
#Region "緊急連絡人電話 屬性:PT0154"
        Private _PT0154 As System.String
        ''' <summary>
        ''' 緊急連絡人電話
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0154() As System.String
            Get
                Return _PT0154
            End Get
            Set(ByVal value As System.String)
                _PT0154 = value
            End Set
        End Property
#End Region
#Region "緊急連絡人地址 屬性:PT0155"
        Private _PT0155 As System.String
        ''' <summary>
        ''' 緊急連絡人地址
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0155() As System.String
            Get
                Return _PT0155
            End Get
            Set(ByVal value As System.String)
                _PT0155 = value
            End Set
        End Property
#End Region
#Region "附註 屬性:PT0156"
        Private _PT0156 As System.String
        ''' <summary>
        ''' 附註
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0156() As System.String
            Get
                Return _PT0156
            End Get
            Set(ByVal value As System.String)
                _PT0156 = value
            End Set
        End Property
#End Region
#Region "離職日期 屬性:PT0157"
        Private _PT0157 As System.String
        ''' <summary>
        ''' 離職日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0157() As System.String
            Get
                Return _PT0157
            End Get
            Set(ByVal value As System.String)
                _PT0157 = value
            End Set
        End Property
#End Region
#Region "備用日期 屬性:PT0158"
        Private _PT0158 As System.String
        ''' <summary>
        ''' 備用日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0158() As System.String
            Get
                Return _PT0158
            End Get
            Set(ByVal value As System.String)
                _PT0158 = value
            End Set
        End Property
#End Region
#Region "兵役專長碼 屬性:PT0159"
        Private _PT0159 As System.String
        ''' <summary>
        ''' 兵役專長碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0159() As System.String
            Get
                Return _PT0159
            End Get
            Set(ByVal value As System.String)
                _PT0159 = value
            End Set
        End Property
#End Region
#Region "銀行帳號 屬性:PT0160"
        Private _PT0160 As System.String
        ''' <summary>
        ''' 銀行帳號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0160() As System.String
            Get
                Return _PT0160
            End Get
            Set(ByVal value As System.String)
                _PT0160 = value
            End Set
        End Property
#End Region
#Region "免刷卡 屬性:PT0161"
        Private _PT0161 As System.String
        ''' <summary>
        ''' 免刷卡
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0161() As System.String
            Get
                Return _PT0161
            End Get
            Set(ByVal value As System.String)
                _PT0161 = value
            End Set
        End Property
#End Region
#Region "免值日 屬性:PT0162"
        Private _PT0162 As System.String
        ''' <summary>
        ''' 免值日
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0162() As System.String
            Get
                Return _PT0162
            End Get
            Set(ByVal value As System.String)
                _PT0162 = value
            End Set
        End Property
#End Region
#Region "碼１ 屬性:PT0163"
        Private _PT0163 As System.String
        ''' <summary>
        ''' 碼１
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0163() As System.String
            Get
                Return _PT0163
            End Get
            Set(ByVal value As System.String)
                _PT0163 = value
            End Set
        End Property
#End Region
#Region "碼２ 屬性:PT0164"
        Private _PT0164 As System.String
        ''' <summary>
        ''' 碼２
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0164() As System.String
            Get
                Return _PT0164
            End Get
            Set(ByVal value As System.String)
                _PT0164 = value
            End Set
        End Property
#End Region
#Region "碼３ 屬性:PT0165"
        Private _PT0165 As System.String
        ''' <summary>
        ''' 碼３
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0165() As System.String
            Get
                Return _PT0165
            End Get
            Set(ByVal value As System.String)
                _PT0165 = value
            End Set
        End Property
#End Region
#Region "碼４ 屬性:PT0166"
        Private _PT0166 As System.String
        ''' <summary>
        ''' 碼４
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0166() As System.String
            Get
                Return _PT0166
            End Get
            Set(ByVal value As System.String)
                _PT0166 = value
            End Set
        End Property
#End Region
#Region "碼５ 屬性:PT0167"
        Private _PT0167 As System.Int32
        ''' <summary>
        ''' 碼５
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0167() As System.Int32
            Get
                Return _PT0167
            End Get
            Set(ByVal value As System.Int32)
                _PT0167 = value
            End Set
        End Property
#End Region
#Region "碼５ 屬性:PT0168"
        Private _PT0168 As System.Int32
        ''' <summary>
        ''' 碼５
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PT0168() As System.Int32
            Get
                Return _PT0168
            End Get
            Set(ByVal value As System.Int32)
                _PT0168 = value
            End Set
        End Property
#End Region


#Region "所有在職員工資料 Shared屬性:ALLInCompanyPTM010PFs"
        Private Shared _ALLInCompanyPTM010PFs As List(Of PTM010PF)
        ''' <summary>
        ''' 所有在職員工資料
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Shared ReadOnly Property ALLInCompanyPTM010PFs() As List(Of PTM010PF)
            Get
                If IsNothing(_ALLInCompanyPTM010PFs) Then
                    _ALLInCompanyPTM010PFs = PTM010PF.CDBSelect(Of PTM010PF)("Select * from @#PLT500LB.PTM010PF Where PT0163 = ' ' ", AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                End If
                Return _ALLInCompanyPTM010PFs
            End Get
        End Property

#End Region

    End Class

End Namespace
