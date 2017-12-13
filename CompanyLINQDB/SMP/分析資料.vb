Partial Public Class 分析資料


    '#Region "相關資料DataRow 屬性:AboutDataRow"
    '    Private _AboutDataRow As DataRow
    '    ''' <summary>
    '    ''' 相關資料DataRow
    '    ''' </summary>
    '    ''' <value></value>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    ReadOnly Property AboutDataRow As DataRow
    '        Get
    '            Static LastGetDataTime As DateTime = Now
    '            If IsNothing(_AboutDataRow) OrElse Now.Subtract(LastGetDataTime).TotalSeconds > 3 Then
    '                Dim QryAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01Test")
    '                Dim QryString As String = "Select * From 分析資料 Where 爐號='" & Me.爐號 & "' AND 站別='" & Me.站別 & "' AND 序號=" & Me.序號 & " AND 日期=" & Me.日期
    '                Dim SearchResult As DataTable = QryAdapter.SelectQuery(QryString)
    '                If SearchResult.Rows.Count > 0 Then
    '                    _AboutDataRow = SearchResult.Rows(0)
    '                End If
    '            End If
    '            LastGetDataTime = Now
    '            Return _AboutDataRow
    '        End Get
    '    End Property
    '#End Region

    Public Function CreateTheObjectDataRow() As DataRow
        Dim QryAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01Test")
        Dim CreateItem As DataRow = QryAdapter.SelectQuery("SELECT TOP 0  * FROM 分析資料").NewRow
        With CreateItem
            If Not IsNothing(Me.爐號) Then .Item("爐號") = Me.爐號
            If Not IsNothing(Me.鋼種) Then .Item("鋼種") = Me.鋼種
            If Not IsNothing(Me.材質) Then .Item("材質") = Me.材質
            If Not IsNothing(Me.站別) Then .Item("站別") = Me.站別
            If Not IsNothing(Me.序號) Then .Item("序號") = Me.序號
            If Not IsNothing(Me.判定) Then .Item("判定") = Me.判定
            If Not IsNothing(Me.日期) Then .Item("日期") = Me.日期
            If Not IsNothing(Me.時間) Then .Item("時間") = Me.時間
            If Not IsNothing(Me.操作員) Then .Item("操作員") = Me.操作員
            If Not IsNothing(Me.DF) Then .Item("DF") = Me.DF
            If Not IsNothing(Me.MD30) Then .Item("MD30") = Me.MD30
            If Not IsNothing(Me.C) Then .Item("C") = Me.C
            If Not IsNothing(Me.Si) Then .Item("Si") = Me.Si
            If Not IsNothing(Me.Mn) Then .Item("Mn") = Me.Mn
            If Not IsNothing(Me.P) Then .Item("P") = Me.P
            If Not IsNothing(Me.S) Then .Item("S") = Me.S
            If Not IsNothing(Me.Cr) Then .Item("Cr") = Me.Cr
            If Not IsNothing(Me.Ni) Then .Item("Ni") = Me.Ni
            If Not IsNothing(Me.Cu) Then .Item("Cu") = Me.Cu
            If Not IsNothing(Me.Mo) Then .Item("Mo") = Me.Mo
            If Not IsNothing(Me.Co) Then .Item("Co") = Me.Co
            If Not IsNothing(Me.AL) Then .Item("AL") = Me.AL
            If Not IsNothing(Me.Sn) Then .Item("Sn") = Me.Sn
            If Not IsNothing(Me.Pb) Then .Item("Pb") = Me.Pb
            If Not IsNothing(Me.Ti) Then .Item("Ti") = Me.Ti
            If Not IsNothing(Me.Nb) Then .Item("Nb") = Me.Nb
            If Not IsNothing(Me.V) Then .Item("V") = Me.V
            If Not IsNothing(Me.W) Then .Item("W") = Me.W
            If Not IsNothing(Me.O2) Then .Item("O2") = Me.O2
            If Not IsNothing(Me.N2) Then .Item("N2") = Me.N2
            If Not IsNothing(Me.H2) Then .Item("H2") = Me.H2
            If Not IsNothing(Me.B) Then .Item("B") = Me.B
            If Not IsNothing(Me.Ca) Then .Item("Ca") = Me.Ca
            If Not IsNothing(Me.Mg) Then .Item("Mg") = Me.Mg
            If Not IsNothing(Me.Fe) Then .Item("Fe") = Me.Fe
            If Not IsNothing(Me.N1) Then .Item("N1") = Me.N1
            If Not IsNothing(Me.O1) Then .Item("O1") = Me.O1
            If Not IsNothing(Me.C2) Then .Item("C2") = Me.C2
            If Not IsNothing(Me.S2) Then .Item("S2") = Me.S2
            If Not IsNothing(Me.分光儀編號) Then .Item("分光儀編號") = Me.分光儀編號
            If Not IsNothing(Me.輻射) Then .Item("輻射") = Me.輻射
            If Not IsNothing(Me.連鑄爐次) Then .Item("連鑄爐次") = Me.連鑄爐次
            If Not IsNothing(Me.最後爐) Then .Item("最後爐") = Me.最後爐
            If Not IsNothing(Me.驗收料) Then .Item("驗收料") = Me.驗收料
            If Not IsNothing(Me.備註1) Then .Item("備註1") = Me.備註1
            If Not IsNothing(Me.資料異動者) Then .Item("資料異動者") = Me.資料異動者
            If Not IsNothing(Me.資料異動日期) Then .Item("資料異動日期") = Me.資料異動日期
        End With
        Return CreateItem
    End Function

#Region "相關AS400資料 屬性:AboutPPSQCAPF"

    Private _AboutPPSQCAPF As CompanyORMDB.PPS100LB.PPSQCAPF = Nothing
    ''' <summary>
    ''' 相關AS400資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AboutPPSQCAPF() As CompanyORMDB.PPS100LB.PPSQCAPF
        Get
            If Me.站別.Trim.Length < 1 OrElse Me.站別.Trim.Substring(0, 1).ToUpper <> "C" Then
                Return Nothing
            End If
            If IsNothing(_AboutPPSQCAPF) Then
                Dim DBDataContext As New CompanyORMDB.AS400SQLQueryAdapter
                Dim QryString As String = "Select * From @#TESTKUKU.PPSQCAPF Where QCA01='" & Me.爐號 & "' AND QCA02=" & Me.日期
                Dim SearchResult As List(Of CompanyORMDB.PPS100LB.PPSQCAPF) = CompanyORMDB.PPS100LB.PPSQCAPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSQCAPF)(QryString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

                If SearchResult.Count > 0 Then
                    _AboutPPSQCAPF = SearchResult(0)
                End If
            End If
            Return _AboutPPSQCAPF
        End Get
        Private Set(ByVal value As CompanyORMDB.PPS100LB.PPSQCAPF)
            _AboutPPSQCAPF = value
        End Set
    End Property

#End Region


End Class
