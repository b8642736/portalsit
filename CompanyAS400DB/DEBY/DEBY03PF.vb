Namespace DEBY

    Public Class DEBY03PF
        Inherits ClassDB

        Sub New()
            MyBase.New("TESTKUKU", GetType(DEBY03PF).Name)
        End Sub


#Region "找尋某家銀行之借款 方法:FindBankDeby"
        ''' <summary>
        ''' 找尋某家銀行之借款
        ''' </summary>
        ''' <param name="FindBankNumber"></param>
        ''' <param name="SetDebyKind"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function FindBankDeby(ByVal FindBankNumber As String, ByVal SetDebyKind As DebyKindEnum) As List(Of DEBY03PF)
            Dim DefaultObjectSet As New DEBY03PF
            Dim SQL As String = "Select  * From " & DefaultObjectSet.CDBFullAS400DBPath & " Where "
            SQL &= "BANKN1='" & FindBankNumber.Replace("'", Nothing) & "'"
            Select Case SetDebyKind
                Case DebyKindEnum.ShortDeby
                    SQL &= "TYPENO='ST'"
                Case DebyKindEnum.LongDeby
                    SQL &= "TYPENO='LG'"
            End Select

            Return DEBY03PF.CDBSelect(Of DEBY03PF)(SQL)
        End Function
#End Region

#Region "借款種類 屬性:TYPENO"

        Private _TYPENO As String
        ''' <summary>
        ''' 借款種類
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property TYPENO() As String
            Get
                Return _TYPENO
            End Get
            Set(ByVal value As String)
                _TYPENO = value
            End Set
        End Property

#End Region
#Region "發行日 屬性:FROMDT"

        Private _FROMDT As String
        ''' <summary>
        ''' 發行日
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
      Public Property FROMDT() As String
            Get
                Return _FROMDT
            End Get
            Set(ByVal value As String)
                _FROMDT = value
            End Set
        End Property



#End Region
#Region "流水號 屬性:NUMBER"

        Private _NUMBER As Integer
        ''' <summary>
        ''' 流水號
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property NUMBER() As Integer
            Get
                Return _NUMBER
            End Get
            Set(ByVal value As Integer)
                _NUMBER = value
            End Set
        End Property

#End Region
#Region "單位別 屬性:DEPART"

        Private _DEPART As String
        ''' <summary>
        ''' 單位別
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DEPART() As String
            Get
                Return _DEPART
            End Get
            Set(ByVal value As String)
                _DEPART = value
            End Set
        End Property

#End Region
#Region "到期日 屬性:TODATE"

        Private _TODATE As String
        ''' <summary>
        ''' 到期日
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TODATE() As String
            Get
                Return _TODATE
            End Get
            Set(ByVal value As String)
                _TODATE = value
            End Set
        End Property

#End Region
#Region "幣別 屬性:NTTYPE"

        Private _NTTYPE As String
        ''' <summary>
        ''' 幣別
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property NTTYPE() As String
            Get
                Return _NTTYPE
            End Get
            Set(ByVal value As String)
                _NTTYPE = value
            End Set
        End Property

#End Region
#Region "金額 屬性:AMOUNT"

        Private _AMOUNT As Double
        ''' <summary>
        ''' 金額
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AMOUNT() As Double
            Get
                Return _AMOUNT
            End Get
            Set(ByVal value As Double)
                _AMOUNT = value
            End Set
        End Property

#End Region
#Region "利息 屬性:INTAMT"

        Private _INTAMT As Double
        ''' <summary>
        ''' 利息
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property INTAMT() As Double
            Get
                Return _INTAMT
            End Get
            Set(ByVal value As Double)
                _INTAMT = value
            End Set
        End Property

#End Region
#Region "借款銀行 屬性:BANKN1"

        Private _BANKN1 As String
        ''' <summary>
        ''' 借款銀行
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BANKN1() As String
            Get
                Return _BANKN1
            End Get
            Set(ByVal value As String)
                _BANKN1 = value
            End Set
        End Property

#End Region
#Region "存入銀行帳號 屬性:BANKN2"

        Private _BANKN2 As String
        Public Property BANKN2() As String
            Get
                Return _BANKN2
            End Get
            Set(ByVal value As String)
                _BANKN2 = value
            End Set
        End Property

#End Region
#Region "摘要 屬性:MEMO26"

        Private _MEMO26 As String
        ''' <summary>
        ''' 摘要
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MEMO26() As String
            Get
                Return _MEMO26
            End Get
            Set(ByVal value As String)
                _MEMO26 = value
            End Set
        End Property

#End Region
#Region "備註 屬性:MEMO62"

        Private _MEMO62 As String
        ''' <summary>
        ''' 備註
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MEMO62() As String
            Get
                Return _MEMO62
            End Get
            Set(ByVal value As String)
                _MEMO62 = value
            End Set
        End Property

#End Region
#Region "簽呈日期 屬性:PAPER1"

        Private _PAPER1 As String
        ''' <summary>
        ''' 簽呈日期
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PAPER1() As String
            Get
                Return _PAPER1
            End Get
            Set(ByVal value As String)
                _PAPER1 = value
            End Set
        End Property

#End Region
#Region "發文日期 屬性:PAPER2"

        Private _PAPER2 As String
        ''' <summary>
        ''' 發文日期
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PAPER2() As String
            Get
                Return _PAPER2
            End Get
            Set(ByVal value As String)
                _PAPER2 = value
            End Set
        End Property

#End Region
#Region "發文號 屬性:PAPER3"

        Private _PAPER3 As String
        ''' <summary>
        ''' 發文號
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PAPER3() As String
            Get
                Return _PAPER3
            End Get
            Set(ByVal value As String)
                _PAPER3 = value
            End Set
        End Property

#End Region
#Region "收款傳票 屬性:SHTNOA"

        Private _SHTNOA As String
        ''' <summary>
        ''' 收款傳票
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHTNOA() As String
            Get
                Return _SHTNOA
            End Get
            Set(ByVal value As String)
                _SHTNOA = value
            End Set
        End Property

#End Region
#Region "還款傳票 屬性:SHTNOB"

        Private _SHTNOB As String
        ''' <summary>
        ''' 還款傳票
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHTNOB() As String
            Get
                Return _SHTNOB
            End Get
            Set(ByVal value As String)
                _SHTNOB = value
            End Set
        End Property

#End Region
#Region "利息傳票 屬性:SHTNOC"

        Private _SHTNOC As String
        ''' <summary>
        ''' 利息傳票
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHTNOC() As String
            Get
                Return _SHTNOC
            End Get
            Set(ByVal value As String)
                _SHTNOC = value
            End Set
        End Property

#End Region
#Region "六聯單編號 屬性:SIXNO8"

        Private _SIXNO8 As String
        ''' <summary>
        ''' 六聯單編號
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SIXNO8() As String
            Get
                Return _SIXNO8
            End Get
            Set(ByVal value As String)
                _SIXNO8 = value
            End Set
        End Property

#End Region
#Region "流水號 屬性：SIXNO1"

        Private _SIXNO1 As String
        ''' <summary>
        ''' 流水號
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SIXNO1() As String
            Get
                Return _SIXNO1
            End Get
            Set(ByVal value As String)
                _SIXNO1 = value
            End Set
        End Property

#End Region
#Region "通知單號碼 屬性:OUTFN1"

        Private _OUTFN1 As Integer
        ''' <summary>
        ''' 通知單號碼
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property OUTFN1() As Integer
            Get
                Return _OUTFN1
            End Get
            Set(ByVal value As Integer)
                _OUTFN1 = value
            End Set
        End Property

#End Region
#Region "通知單年度 屬性:OUTFN2"

        Private _OUTFN2 As String
        ''' <summary>
        ''' 通知單年度
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property OUTFN2() As String
            Get
                Return _OUTFN2
            End Get
            Set(ByVal value As String)
                _OUTFN2 = value
            End Set
        End Property

#End Region
#Region "輸入者基本 屬性:USERN1"

        Private _USERN1 As String
        ''' <summary>
        ''' 輸入者基本
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property USERN1() As String
            Get
                Return _USERN1
            End Get
            Set(ByVal value As String)
                _USERN1 = value
            End Set
        End Property

#End Region
#Region "輸入日期 屬性:INPUT1"

        Private _INPUT1 As String
        ''' <summary>
        ''' 輸入日期
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property INPUT1() As String
            Get
                Return _INPUT1
            End Get
            Set(ByVal value As String)
                _INPUT1 = value
            End Set
        End Property

#End Region
#Region "輸入者收款 屬性:USERNA"

        Private _USERNA As String
        ''' <summary>
        ''' 輸入者收款
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property USERNA() As String
            Get
                Return _USERNA
            End Get
            Set(ByVal value As String)
                _USERNA = value
            End Set
        End Property

#End Region
#Region "輸入日期 屬性:INPUTA"

        Private _INPUTA As String
        ''' <summary>
        ''' 輸入日期
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property INPUTA() As String
            Get
                Return _INPUTA
            End Get
            Set(ByVal value As String)
                _INPUTA = value
            End Set
        End Property

#End Region
#Region "輸入者還款 屬性:USERNB"

        Private _USERNB As String
        ''' <summary>
        ''' 輸入者還款
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property USERNB() As String
            Get
                Return _USERNB
            End Get
            Set(ByVal value As String)
                _USERNB = value
            End Set
        End Property

#End Region
#Region "輸入日期 屬性:INPUTB"

        Private _INPUTB As String
        ''' <summary>
        ''' 輸入日期
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property INPUTB() As String
            Get
                Return _INPUTB
            End Get
            Set(ByVal value As String)
                _INPUTB = value
            End Set
        End Property

#End Region
#Region "輸入者利息 屬性:USERNC"

        Private _USERNC As String
        ''' <summary>
        ''' 輸入者利息
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property USERNC() As String
            Get
                Return _USERNC
            End Get
            Set(ByVal value As String)
                _USERNC = value
            End Set
        End Property

#End Region
#Region "輸入日期 屬性:INPUTC"

        Private _INPUTC As String
        ''' <summary>
        ''' 輸入日期
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property INPUTC() As String
            Get
                Return _INPUTC
            End Get
            Set(ByVal value As String)
                _INPUTC = value
            End Set
        End Property

#End Region
#Region "期限 屬性:PERIOD"

        Private _PERIOD As Integer
        ''' <summary>
        ''' 期限
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PERIOD() As Integer
            Get
                Return _PERIOD
            End Get
            Set(ByVal value As Integer)
                _PERIOD = value
            End Set
        End Property

#End Region
#Region "利率 屬性:CURRAN"

        Private _CURRAN As Integer
        ''' <summary>
        ''' 利率
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CURRAN() As Integer
            Get
                Return _CURRAN
            End Get
            Set(ByVal value As Integer)
                _CURRAN = value
            End Set
        End Property

#End Region
#Region "期限年 屬性:PERIO1"

        Private _PERIO1 As Integer
        ''' <summary>
        ''' 期限年
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PERIO1() As Integer
            Get
                Return _PERIO1
            End Get
            Set(ByVal value As Integer)
                _PERIO1 = value
            End Set
        End Property


#End Region
#Region "期限月 屬性:PERIO2"


        Private _PERIO2 As Integer
        ''' <summary>
        ''' 期限月
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PERIO2() As Integer
            Get
                Return _PERIO2
            End Get
            Set(ByVal value As Integer)
                _PERIO2 = value
            End Set
        End Property



#End Region
#Region "寬限期年 屬性:PERIO3"

        Private _PERIO3 As Integer
        ''' <summary>
        ''' 寬限期年
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PERIO3() As Integer
            Get
                Return _PERIO3
            End Get
            Set(ByVal value As Integer)
                _PERIO3 = value
            End Set
        End Property

#End Region
#Region "寬限期月 屬性:PERIO4"


        Private _PERIO4 As Integer
        ''' <summary>
        ''' 寬限期月
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PERIO4() As Integer
            Get
                Return _PERIO4
            End Get
            Set(ByVal value As Integer)
                _PERIO4 = value
            End Set
        End Property


#End Region
#Region "還本間隔年 屬性:PERIO5"

        Private _PERIO5 As Integer
        ''' <summary>
        ''' 還本間隔年
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PERIO5() As Integer
            Get
                Return _PERIO5
            End Get
            Set(ByVal value As Integer)
                _PERIO5 = value
            End Set
        End Property

#End Region
#Region "還本間隔月 屬性:PERIO6"


        Private _PERIO6 As Integer
        ''' <summary>
        ''' 還本間隔月
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PERIO6() As Integer
            Get
                Return _PERIO6
            End Get
            Set(ByVal value As Integer)
                _PERIO6 = value
            End Set
        End Property


#End Region
#Region "每月付息日 屬性:PERIO7"

        Private _PERIO7 As Integer
        ''' <summary>
        ''' 每月付息日
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PERIO7() As Integer
            Get
                Return _PERIO7
            End Get
            Set(ByVal value As Integer)
                _PERIO7 = value
            End Set
        End Property

#End Region
#Region "付息方式 屬性:INTTYP"

        Private _INTTYP As String
        Public Property INTTYP() As String
            Get
                Return _INTTYP
            End Get
            Set(ByVal value As String)
                _INTTYP = value
            End Set
        End Property

#End Region

        Public Enum DebyKindEnum
            ShortDeby = 0
            LongDeby = 1
            ALL = 99
        End Enum
    End Class
End Namespace
