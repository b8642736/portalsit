Namespace SQLServer
    Namespace PPS100LB
        ''' <summary>
        ''' 相關SQLServerP.P.排程檔
        ''' </summary>
        ''' <remarks></remarks>
        Public Class PPSSHAPF
            Inherits ClassDBSQLServer
            Implements IPPS100LB.IPPSSHAPF

            Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
            End Sub

#Region "SHA01 屬性:SHA01"
            Private _SHA01 As System.String
            ''' <summary>
            ''' SHA01
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property SHA01() As System.String Implements IPPS100LB.IPPSSHAPF.SHA01
                Get
                    Return _SHA01
                End Get
                Set(ByVal value As System.String)
                    _SHA01 = value
                End Set
            End Property
#End Region
#Region "SHA02 屬性:SHA02"
            Private _SHA02 As System.String
            ''' <summary>
            ''' SHA02
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property SHA02() As System.String Implements IPPS100LB.IPPSSHAPF.SHA02
                Get
                    Return _SHA02
                End Get
                Set(ByVal value As System.String)
                    _SHA02 = value
                End Set
            End Property
#End Region
#Region "SHA03 屬性:SHA03"
            Private _SHA03 As System.String
            ''' <summary>
            ''' SHA03
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA03() As System.String Implements IPPS100LB.IPPSSHAPF.SHA03
                Get
                    Return _SHA03
                End Get
                Set(ByVal value As System.String)
                    _SHA03 = value
                End Set
            End Property
#End Region
#Region "SHA04 屬性:SHA04"
            Private _SHA04 As Integer
            ''' <summary>
            ''' SHA04
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property SHA04() As Integer Implements IPPS100LB.IPPSSHAPF.SHA04
                Get
                    Return _SHA04
                End Get
                Set(ByVal value As Integer)
                    _SHA04 = value
                End Set
            End Property
#End Region
#Region "SHA05 屬性:SHA05"
            Private _SHA05 As System.String
            ''' <summary>
            ''' SHA05
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA05() As System.String Implements IPPS100LB.IPPSSHAPF.SHA05
                Get
                    Return _SHA05
                End Get
                Set(ByVal value As System.String)
                    _SHA05 = value
                End Set
            End Property
#End Region
#Region "SHA06 屬性:SHA06"
            Private _SHA06 As System.String
            ''' <summary>
            ''' SHA06
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA06() As System.String Implements IPPS100LB.IPPSSHAPF.SHA06
                Get
                    Return _SHA06.Trim
                End Get
                Set(ByVal value As System.String)
                    _SHA06 = value
                End Set
            End Property
#End Region
#Region "SHA07 屬性:SHA07"
            Private _SHA07 As System.String
            ''' <summary>
            ''' SHA07
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA07() As System.String Implements IPPS100LB.IPPSSHAPF.SHA07
                Get
                    Return _SHA07
                End Get
                Set(ByVal value As System.String)
                    _SHA07 = value
                End Set
            End Property
#End Region
#Region "SHA08 屬性:SHA08"
            Private _SHA08 As System.String
            ''' <summary>
            ''' SHA08
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA08() As System.String Implements IPPS100LB.IPPSSHAPF.SHA08
                Get
                    Return _SHA08
                End Get
                Set(ByVal value As System.String)
                    _SHA08 = value
                End Set
            End Property
#End Region
#Region "SHA09 屬性:SHA09"
            Private _SHA09 As System.String
            ''' <summary>
            ''' SHA09
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA09() As System.String Implements IPPS100LB.IPPSSHAPF.SHA09
                Get
                    Return _SHA09
                End Get
                Set(ByVal value As System.String)
                    _SHA09 = value
                End Set
            End Property
#End Region
#Region "SHA10 屬性:SHA10"
            Private _SHA10 As System.String
            ''' <summary>
            ''' SHA10
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA10() As System.String Implements IPPS100LB.IPPSSHAPF.SHA10
                Get
                    Return _SHA10
                End Get
                Set(ByVal value As System.String)
                    _SHA10 = value
                End Set
            End Property
#End Region
#Region "SHA11 屬性:SHA11"
            Private _SHA11 As System.Double
            ''' <summary>
            ''' SHA11
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA11() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA11
                Get
                    Return _SHA11
                End Get
                Set(ByVal value As System.Double)
                    _SHA11 = value
                End Set
            End Property
#End Region
#Region "SHA12 屬性:SHA12"
            Private _SHA12 As System.String
            ''' <summary>
            ''' SHA12
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA12() As System.String Implements IPPS100LB.IPPSSHAPF.SHA12
                Get
                    Return _SHA12
                End Get
                Set(ByVal value As System.String)
                    _SHA12 = value
                End Set
            End Property
#End Region
#Region "SHA13 屬性:SHA13"
            Private _SHA13 As System.String
            ''' <summary>
            ''' SHA13
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA13() As System.String Implements IPPS100LB.IPPSSHAPF.SHA13
                Get
                    Return _SHA13
                End Get
                Set(ByVal value As System.String)
                    _SHA13 = value
                End Set
            End Property
#End Region
#Region "SHA14 屬性:SHA14"
            Private _SHA14 As System.Double
            ''' <summary>
            ''' SHA14
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA14() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA14
                Get
                    Return _SHA14
                End Get
                Set(ByVal value As System.Double)
                    _SHA14 = value
                End Set
            End Property
#End Region
#Region "SHA15 屬性:SHA15"
            Private _SHA15 As System.Double
            ''' <summary>
            ''' SHA15
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA15() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA15
                Get
                    Return _SHA15
                End Get
                Set(ByVal value As System.Double)
                    _SHA15 = value
                End Set
            End Property
#End Region
#Region "SHA16 屬性:SHA16"
            Private _SHA16 As System.Double
            ''' <summary>
            ''' SHA16
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA16() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA16
                Get
                    Return _SHA16
                End Get
                Set(ByVal value As System.Double)
                    _SHA16 = value
                End Set
            End Property
#End Region
#Region "SHA17 屬性:SHA17"
            Private _SHA17 As System.Double
            ''' <summary>
            ''' SHA17
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA17() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA17
                Get
                    Return _SHA17
                End Get
                Set(ByVal value As System.Double)
                    _SHA17 = value
                End Set
            End Property
#End Region
#Region "SHA18 屬性:SHA18"
            Private _SHA18 As System.Double
            ''' <summary>
            ''' SHA18
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA18() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA18
                Get
                    Return _SHA18
                End Get
                Set(ByVal value As System.Double)
                    _SHA18 = value
                End Set
            End Property
#End Region
#Region "SHA19 屬性:SHA19"
            Private _SHA19 As System.Double
            ''' <summary>
            ''' SHA19
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA19() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA19
                Get
                    Return _SHA19
                End Get
                Set(ByVal value As System.Double)
                    _SHA19 = value
                End Set
            End Property
#End Region
#Region "SHA20 屬性:SHA20"
            Private _SHA20 As System.Double
            ''' <summary>
            ''' SHA20
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA20() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA20
                Get
                    Return _SHA20
                End Get
                Set(ByVal value As System.Double)
                    _SHA20 = value
                End Set
            End Property
#End Region
#Region "SHA21 屬性:SHA21"
            Private _SHA21 As System.Double
            ''' <summary>
            ''' SHA21
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA21() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA21
                Get
                    Return _SHA21
                End Get
                Set(ByVal value As System.Double)
                    _SHA21 = value
                End Set
            End Property
#End Region
#Region "SHA22 屬性:SHA22"
            Private _SHA22 As System.Double
            ''' <summary>
            ''' SHA22
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA22() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA22
                Get
                    Return _SHA22
                End Get
                Set(ByVal value As System.Double)
                    _SHA22 = value
                End Set
            End Property
#End Region
#Region "SHA23 屬性:SHA23"
            Private _SHA23 As System.Double
            ''' <summary>
            ''' SHA23
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA23() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA23
                Get
                    Return _SHA23
                End Get
                Set(ByVal value As System.Double)
                    _SHA23 = value
                End Set
            End Property
#End Region
#Region "SHA24 屬性:SHA24"
            Private _SHA24 As System.Double
            ''' <summary>
            ''' SHA24
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA24() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA24
                Get
                    Return _SHA24
                End Get
                Set(ByVal value As System.Double)
                    _SHA24 = value
                End Set
            End Property
#End Region
#Region "SHA25 屬性:SHA25"
            Private _SHA25 As System.Double
            ''' <summary>
            ''' SHA25
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA25() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA25
                Get
                    Return _SHA25
                End Get
                Set(ByVal value As System.Double)
                    _SHA25 = value
                End Set
            End Property
#End Region
#Region "SHA26 屬性:SHA26"
            Private _SHA26 As System.String
            ''' <summary>
            ''' SHA26
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA26() As System.String Implements IPPS100LB.IPPSSHAPF.SHA26
                Get
                    Return _SHA26
                End Get
                Set(ByVal value As System.String)
                    _SHA26 = value
                End Set
            End Property
#End Region
#Region "SHA27 屬性:SHA27"
            Private _SHA27 As System.String
            ''' <summary>
            ''' SHA27
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA27() As System.String Implements IPPS100LB.IPPSSHAPF.SHA27
                Get
                    Return _SHA27
                End Get
                Set(ByVal value As System.String)
                    _SHA27 = value
                End Set
            End Property
#End Region
#Region "SHA28 屬性:SHA28"
            Private _SHA28 As System.String
            ''' <summary>
            ''' SHA28(*:表示本站已執行完成)
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA28() As System.String Implements IPPS100LB.IPPSSHAPF.SHA28
                Get
                    Return _SHA28
                End Get
                Set(ByVal value As System.String)
                    _SHA28 = value
                End Set
            End Property
#End Region
#Region "SHA29 屬性:SHA29"
            Private _SHA29 As System.String
            ''' <summary>
            ''' SHA29
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA29() As System.String Implements IPPS100LB.IPPSSHAPF.SHA29
                Get
                    Return _SHA29
                End Get
                Set(ByVal value As System.String)
                    _SHA29 = value
                End Set
            End Property
#End Region
#Region "SHA30 屬性:SHA30"
            Private _SHA30 As System.String
            ''' <summary>
            ''' SHA30
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA30() As System.String Implements IPPS100LB.IPPSSHAPF.SHA30
                Get
                    Return _SHA30
                End Get
                Set(ByVal value As System.String)
                    _SHA30 = value
                End Set
            End Property
#End Region
#Region "SHA31 屬性:SHA31"
            Private _SHA31 As System.String
            ''' <summary>
            ''' SHA31
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA31() As System.String Implements IPPS100LB.IPPSSHAPF.SHA31
                Get
                    Return _SHA31
                End Get
                Set(ByVal value As System.String)
                    _SHA31 = value
                End Set
            End Property
#End Region
#Region "SHA32 屬性:SHA32"
            Private _SHA32 As System.String
            ''' <summary>
            ''' SHA32
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA32() As System.String Implements IPPS100LB.IPPSSHAPF.SHA32
                Get
                    Return _SHA32
                End Get
                Set(ByVal value As System.String)
                    _SHA32 = value
                End Set
            End Property
#End Region
#Region "SHA33 屬性:SHA33"
            Private _SHA33 As System.String
            ''' <summary>
            ''' SHA33
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA33() As System.String Implements IPPS100LB.IPPSSHAPF.SHA33
                Get
                    Return _SHA33
                End Get
                Set(ByVal value As System.String)
                    _SHA33 = value
                End Set
            End Property
#End Region
#Region "SHA34 屬性:SHA34"
            Private _SHA34 As System.Double
            ''' <summary>
            ''' SHA34
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA34() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA34
                Get
                    Return _SHA34
                End Get
                Set(ByVal value As System.Double)
                    _SHA34 = value
                End Set
            End Property
#End Region
#Region "SHA35 屬性:SHA35"
            Private _SHA35 As System.String
            ''' <summary>
            ''' SHA35
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA35() As System.String Implements IPPS100LB.IPPSSHAPF.SHA35
                Get
                    Return _SHA35
                End Get
                Set(ByVal value As System.String)
                    _SHA35 = value
                End Set
            End Property
#End Region
#Region "SHA36 屬性:SHA36"
            Private _SHA36 As System.String
            ''' <summary>
            ''' SHA36
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA36() As System.String Implements IPPS100LB.IPPSSHAPF.SHA36
                Get
                    Return _SHA36
                End Get
                Set(ByVal value As System.String)
                    _SHA36 = value
                End Set
            End Property
#End Region
#Region "SHA37 屬性:SHA37"
            Private _SHA37 As System.String
            ''' <summary>
            ''' SHA37
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA37() As System.String Implements IPPS100LB.IPPSSHAPF.SHA37
                Get
                    Return _SHA37
                End Get
                Set(ByVal value As System.String)
                    _SHA37 = value
                End Set
            End Property
#End Region
#Region "SHA38 屬性:SHA38"
            Private _SHA38 As System.Double
            ''' <summary>
            ''' SHA38
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA38() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA38
                Get
                    Return _SHA38
                End Get
                Set(ByVal value As System.Double)
                    _SHA38 = value
                End Set
            End Property
#End Region
#Region "SHA39 屬性:SHA39"
            Private _SHA39 As System.String
            ''' <summary>
            ''' SHA39
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SHA39() As System.String Implements IPPS100LB.IPPSSHAPF.SHA39
                Get
                    Return _SHA39
                End Get
                Set(ByVal value As System.String)
                    _SHA39 = value
                End Set
            End Property
#End Region
#Region "IsTransToAS400 屬性:IsTransToAS400"
            Private _IsTransToAS400 As System.Boolean
            ''' <summary>
            ''' IsTransToAS400
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property IsTransToAS400() As System.Boolean
                Get
                    Return _IsTransToAS400
                End Get
                Set(ByVal value As System.Boolean)
                    _IsTransToAS400 = value
                End Set
            End Property
#End Region
#Region "DataSourceType 屬性:DataSourceType"

            Private _DataSourceType As Integer
            ''' <summary>
            ''' 1.AS400資料來源2.SQLServer現場產生
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property DataSourceType() As Integer
                Get
                    Return _DataSourceType
                End Get
                Set(ByVal value As Integer)
                    _DataSourceType = value
                End Set
            End Property

#End Region
#Region "FK_ProcessSchedualID"

            Private _FK_ProcessSchedualID As String
            ''' <summary>
            ''' 軋鋼處理排程ID
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FK_ProcessSchedualID() As String
                Get
                    Return _FK_ProcessSchedualID
                End Get
                Set(ByVal value As String)
                    _FK_ProcessSchedualID = value
                End Set
            End Property

#End Region
#Region "儲存PC之IP 屬性:SavePCIP"

            Private _SavePCIP As String
            ''' <summary>
            ''' 儲存PC之IP
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SavePCIP() As String
                Get
                    Return _SavePCIP
                End Get
                Set(ByVal value As String)
                    _SavePCIP = value
                End Set
            End Property

#End Region

#Region "是否為完成產品 屬性:IsFinishProduct"
            ''' <summary>
            ''' 是否為完成產品
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Public Property IsFinishProduct() As Boolean
                Get
                    Return SHA29 = "*"
                End Get
                Set(ByVal value As Boolean)
                    SHA29 = IIf(value, "*", " ")
                End Set
            End Property

#End Region

#Region "相關軋鋼處理排程 屬性:About_ProcessSchedual"
            ''' <summary>
            ''' 相關軋鋼處理排程
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property About_ProcessSchedual As ProcessSchedual Implements IPPS100LB.IPPSSHAPF.About_ProcessSchedual
                Get
                    For Each EachItem As ProcessSchedual In ProcessSchedual.AllProcessScheduals
                        If EachItem.ID.Trim = Me.FK_ProcessSchedualID.Trim Then
                            Return EachItem
                        End If
                    Next
                    Return Nothing
                End Get
            End Property
#End Region



#Region "相關鋼捲編號(SHA01+SHA02)之在製品鋼捲入有主 屬性:AboutSL2CICPF"
            Private _AboutSL2CICPF As SLS300LB.SL2CICPF = Nothing
            ''' <summary>
            ''' 相關鋼捲編號(SHA01+SHA02)之在製品鋼捲入有主
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property AboutSL2CICPF As SLS300LB.SL2CICPF Implements IPPS100LB.IPPSSHAPF.AboutSL2CICPF
                Get
                    Dim FindCoilFullNumber As String = (Me.SHA01 & Me.SHA02).PadRight(5).Trim
                    If IsNothing(_AboutSL2CICPF) OrElse ((_AboutSL2CICPF.CIC01 & _AboutSL2CICPF.CIC02).Trim <> FindCoilFullNumber AndAlso (_AboutSL2CICPF.CIC01 & _AboutSL2CICPF.CIC02).Trim <> FindCoilFullNumber.Substring(0, FindCoilFullNumber.Length - 1)) Then
                        _AboutSL2CICPF = FindSL2CIAPF(FindCoilFullNumber)
                    End If
                    Return _AboutSL2CICPF
                End Get
            End Property
            Private Function FindSL2CIAPF(ByVal CoilFullNumber As String) As SLS300LB.SL2CICPF
                Dim ReturnValue As SLS300LB.SL2CICPF = Nothing
                Dim AllSHA01_SL2CICPFs As List(Of SLS300LB.SL2CICPF) = AboutSHA01_SL2CICPFs
                For Each EachItem As SLS300LB.SL2CICPF In AllSHA01_SL2CICPFs
                    If (EachItem.CIC01 & EachItem.CIC02.Trim) = CoilFullNumber Then
                        ReturnValue = EachItem : Return ReturnValue
                    End If
                Next
                If CoilFullNumber.Length <= 5 Then
                    Return ReturnValue
                End If
                For Each EachItem As SLS300LB.SL2CICPF In AllSHA01_SL2CICPFs
                    If (EachItem.CIC01 & EachItem.CIC02.Trim) = CoilFullNumber.Substring(0, CoilFullNumber.Length - 1) Then
                        ReturnValue = EachItem : Exit For
                    End If
                Next
                Return ReturnValue
            End Function
#End Region
#Region "相關鋼捲編號(SHA01+SHA02)之列管訂單 屬性:AboutSL2CIDPF"
            Private _AboutSL2CIDPF As SLS300LB.SL2CIDPF = Nothing
            Private _AboutSL2CIDPFAccTime As DateTime = New DateTime(200, 1, 1)
            ''' <summary>
            ''' 相關鋼捲編號(SHA01+SHA02)之列管訂單
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property AboutSL2CIDPF As SLS300LB.SL2CIDPF Implements IPPS100LB.IPPSSHAPF.AboutSL2CIDPF
                Get
                    If Now.Subtract(_AboutSL2CIDPFAccTime).TotalSeconds > 3 AndAlso IsNothing(_AboutSL2CIDPF) Then
                        Dim AboutSL2CICPF As CompanyORMDB.SLS300LB.SL2CICPF = Me.AboutSL2CICPF
                        If Not IsNothing(AboutSL2CICPF) Then
                            Dim Qry As String = "Select * From @#SLS300LB.SL2CIDPF Where (CID01 || CID02) ='" & AboutSL2CICPF.CIC10 & "' AND CID03='" & AboutSL2CICPF.CIC11 & "' AND CID04='" & AboutSL2CICPF.CIC12 & "' AND  CID05='" & AboutSL2CICPF.CIC13 & "' AND CID06='" & AboutSL2CICPF.CIC14.Substring(0, 2) & "." & AboutSL2CICPF.CIC14.Substring(2, 2) & "' AND CID07='" & AboutSL2CICPF.CIC15 & "' "
                            Dim SearchResult As List(Of CompanyORMDB.SLS300LB.SL2CIDPF) = SLS300LB.SL2CIDPF.CDBSelect(Of SLS300LB.SL2CIDPF)(Qry, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                            If SearchResult.Count > 0 Then
                                _AboutSL2CIDPF = SearchResult(0)
                            End If
                        End If
                        _AboutSL2CIDPFAccTime = Now
                    End If
                    Return _AboutSL2CIDPF
                End Get
            End Property
#End Region
#Region "相關鋼捲編號(只有SHA01)之所有在製品鋼捲入有主 私有屬性:AboutSHA01_SL2CICPFs"
            Private _AboutSHA01_SL2CIAPFs As List(Of SLS300LB.SL2CICPF) = Nothing
            ''' <summary>
            ''' 相關鋼捲編號(只有SHA01)之有在製品鋼捲入有主
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Private ReadOnly Property AboutSHA01_SL2CICPFs As List(Of SLS300LB.SL2CICPF)
                Get
                    If IsNothing(_AboutSHA01_SL2CIAPFs) OrElse _AboutSHA01_SL2CIAPFs.Count = 0 Then
                        Dim Qry As String = "Select * From @#SLS300LB.SL2CICPF Where CIC01='" & Me.SHA01 & "' AND CIC91<>'Z'"    'Z:表示非已入庫並新增至PPSCIAPF
                        _AboutSHA01_SL2CIAPFs = SLS300LB.SL2CICPF.CDBSelect(Of SLS300LB.SL2CICPF)(Qry, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                    End If
                    Return _AboutSHA01_SL2CIAPFs
                End Get
            End Property
#End Region
#Region "相關黑皮資料 屬性:About_PPSBLAPF"
            Private _About_PPSBLAPF As CompanyORMDB.PPS100LB.PPSBLAPF = Nothing
            ''' <summary>
            ''' 相關黑皮資料
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property About_PPSBLAPF As CompanyORMDB.PPS100LB.PPSBLAPF Implements IPPS100LB.IPPSSHAPF.AboutPPSBLAPF
                Get
                    If IsNothing(_About_PPSBLAPF) Then
                        Dim QryString As String = "Select * from @#PPS100LB.PPSBLAPF WHERE BLA09='" & Me.SHA01 & "'"
                        Dim SearchResult As List(Of CompanyORMDB.PPS100LB.PPSBLAPF) = CompanyORMDB.PPS100LB.PPSBLAPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSBLAPF)(QryString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                        If SearchResult.Count = 0 Then
                            Return Nothing
                        End If
                        _About_PPSBLAPF = SearchResult(0)
                    End If
                    Return _About_PPSBLAPF
                End Get
            End Property

#End Region



#Region "內外銷判別"
            Private _PP_ExportJudge As Boolean
            ''' <summary>
            ''' 相關鋼捲編號(SHA01+SHA02)之列管訂單
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property PP_ExportJudge As Boolean Implements IPPS100LB.IPPSSHAPF.PP_ExportJudge
                Get
                    Dim Qry As String

                    Qry = " select *  from @#PPS100LB.PPSSHAPF " & _
                            "  where SHA01='" & SHA01 & "' and " & _
                            " SHA02 ='" & SHA02 & "' and SHA35 <> ''"

                    Dim searchResult As List(Of CompanyORMDB.PPS100LB.PPSSHAPF) = CompanyORMDB.PPS100LB.PPSSHAPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSSHAPF)(Qry, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

                    If searchResult.Count > 0 Then
                        Return True
                    Else
                        Return False
                    End If
                    Return False
                End Get
            End Property
#End Region
        End Class
    End Namespace
End Namespace