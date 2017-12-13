Namespace ACLIB
    ''' <summary>
    ''' 會計科目代號檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ACA010PF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("ACLIB", GetType(ACA010PF).Name)
        End Sub

#Region "會計科目代號 屬性:ACCTNO"
        Private _ACCTNO As System.String
        ''' <summary>
        ''' 會計科目代號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property ACCTNO() As System.String
            Get
                Return _ACCTNO
            End Get
            Set(ByVal value As System.String)
                _ACCTNO = value
            End Set
        End Property
#End Region
#Region "會計科目名稱 屬性:ACCTNM"
        Private _ACCTNM As System.String
        ''' <summary>
        ''' 會計科目名稱
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ACCTNM() As System.String
            Get
                Return _ACCTNM
            End Get
            Set(ByVal value As System.String)
                _ACCTNM = value
            End Set
        End Property
#End Region
#Region "借貸別 屬性:DBCRID"
        Private _DBCRID As System.String
        ''' <summary>
        ''' 借貸別
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DBCRID() As System.String
            Get
                Return _DBCRID
            End Get
            Set(ByVal value As System.String)
                _DBCRID = value
            End Set
        End Property
#End Region
#Region "明細類別 屬性:DETLID"
        Private _DETLID As System.String
        ''' <summary>
        ''' 明細類別
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DETLID() As System.String
            Get
                Return _DETLID
            End Get
            Set(ByVal value As System.String)
                _DETLID = value
            End Set
        End Property
#End Region
#Region "沖銷類別 屬性:FINDID"
        Private _FINDID As System.String
        ''' <summary>
        ''' 沖銷類別
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FINDID() As System.String
            Get
                Return _FINDID
            End Get
            Set(ByVal value As System.String)
                _FINDID = value
            End Set
        End Property
#End Region
#Region "單位代號 屬性:STAT01"
        Private _STAT01 As System.String
        ''' <summary>
        ''' 單位代號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property STAT01() As System.String
            Get
                Return _STAT01
            End Get
            Set(ByVal value As System.String)
                _STAT01 = value
            End Set
        End Property
#End Region
#Region "承訂編號 屬性:STAT02"
        Private _STAT02 As System.String
        ''' <summary>
        ''' 承訂編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property STAT02() As System.String
            Get
                Return _STAT02
            End Get
            Set(ByVal value As System.String)
                _STAT02 = value
            End Set
        End Property
#End Region
#Region "往來廠別 屬性:STAT03"
        Private _STAT03 As System.String
        ''' <summary>
        ''' 往來廠別
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property STAT03() As System.String
            Get
                Return _STAT03
            End Get
            Set(ByVal value As System.String)
                _STAT03 = value
            End Set
        End Property
#End Region
#Region "成本類別 屬性:STAT04"
        Private _STAT04 As System.String
        ''' <summary>
        ''' 成本類別
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property STAT04() As System.String
            Get
                Return _STAT04
            End Get
            Set(ByVal value As System.String)
                _STAT04 = value
            End Set
        End Property
#End Region
#Region "營運類否 屬性:STAT05"
        Private _STAT05 As System.String
        ''' <summary>
        ''' 營運類否
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property STAT05() As System.String
            Get
                Return _STAT05
            End Get
            Set(ByVal value As System.String)
                _STAT05 = value
            End Set
        End Property
#End Region
#Region "借貸減項 屬性:STAT06"
        Private _STAT06 As System.String
        ''' <summary>
        ''' 借貸減項
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property STAT06() As System.String
            Get
                Return _STAT06
            End Get
            Set(ByVal value As System.String)
                _STAT06 = value
            End Set
        End Property
#End Region
#Region "輸入判斷 屬性:STAT07"
        Private _STAT07 As System.String
        ''' <summary>
        ''' 輸入判斷
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property STAT07() As System.String
            Get
                Return _STAT07
            End Get
            Set(ByVal value As System.String)
                _STAT07 = value
            End Set
        End Property
#End Region
#Region "輸入判斷 屬性:STAT08"
        Private _STAT08 As System.String
        ''' <summary>
        ''' 輸入判斷
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property STAT08() As System.String
            Get
                Return _STAT08
            End Get
            Set(ByVal value As System.String)
                _STAT08 = value
            End Set
        End Property
#End Region
#Region "輸入判斷 屬性:STAT09"
        Private _STAT09 As System.String
        ''' <summary>
        ''' 輸入判斷
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property STAT09() As System.String
            Get
                Return _STAT09
            End Get
            Set(ByVal value As System.String)
                _STAT09 = value
            End Set
        End Property
#End Region
#Region "輸入判斷 屬性:STAT10"
        Private _STAT10 As System.String
        ''' <summary>
        ''' 輸入判斷
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property STAT10() As System.String
            Get
                Return _STAT10
            End Get
            Set(ByVal value As System.String)
                _STAT10 = value
            End Set
        End Property
#End Region
#Region "輸入判斷 屬性:STAT11"
        Private _STAT11 As System.String
        ''' <summary>
        ''' 輸入判斷
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property STAT11() As System.String
            Get
                Return _STAT11
            End Get
            Set(ByVal value As System.String)
                _STAT11 = value
            End Set
        End Property
#End Region
#Region "輸入判斷 屬性:STAT12"
        Private _STAT12 As System.String
        ''' <summary>
        ''' 輸入判斷
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property STAT12() As System.String
            Get
                Return _STAT12
            End Get
            Set(ByVal value As System.String)
                _STAT12 = value
            End Set
        End Property
#End Region
#Region "輸入判斷 屬性:STAT13"
        Private _STAT13 As System.String
        ''' <summary>
        ''' 輸入判斷
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property STAT13() As System.String
            Get
                Return _STAT13
            End Get
            Set(ByVal value As System.String)
                _STAT13 = value
            End Set
        End Property
#End Region
#Region "輸入判斷 屬性:STAT14"
        Private _STAT14 As System.String
        ''' <summary>
        ''' 輸入判斷
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property STAT14() As System.String
            Get
                Return _STAT14
            End Get
            Set(ByVal value As System.String)
                _STAT14 = value
            End Set
        End Property
#End Region
#Region "輸入判斷 屬性:STAT15"
        Private _STAT15 As System.String
        ''' <summary>
        ''' 輸入判斷
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property STAT15() As System.String
            Get
                Return _STAT15
            End Get
            Set(ByVal value As System.String)
                _STAT15 = value
            End Set
        End Property
#End Region
#Region "月結註記 屬性:MNMARK"
        Private _MNMARK As System.String
        ''' <summary>
        ''' 月結註記
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MNMARK() As System.String
            Get
                Return _MNMARK
            End Get
            Set(ByVal value As System.String)
                _MNMARK = value
            End Set
        End Property
#End Region

#Region "所有會計科目代號檔 屬性:AllACA010PFs"
        Private Shared _AllACA010PFs As List(Of ACA010PF) = Nothing
        ''' <summary>
        ''' 所有會計科目代號檔
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Shared ReadOnly Property AllACA010PFs As List(Of ACA010PF)
            Get
                Static LastGetDataTime As DateTime = Now
                If Now.Subtract(LastGetDataTime).Seconds > 3 Then
                    _AllACA010PFs = Nothing
                End If
                If IsNothing(_AllACA010PFs) Then
                    _AllACA010PFs = ACA010PF.CDBSelect(Of ACA010PF)("Select * From @#ACLIB.ACA010PF Order by ACCTNO ", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                End If
                LastGetDataTime = Now
                Return _AllACA010PFs
            End Get
        End Property
#End Region

    End Class
End Namespace