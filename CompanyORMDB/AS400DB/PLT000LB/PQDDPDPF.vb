Namespace PLT000LB
    ''' <summary>
    ''' 單位代碼檔(包含單位代碼)
    ''' </summary>
    ''' <remarks></remarks>
    Public Class PQDDPDPF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("PLT000LB", GetType(PQDDPDPF).Name)
        End Sub

#Region "舊代號 屬性:PQDD1"
        Private _PQDD1 As System.String
        ''' <summary>
        ''' 舊代號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PQDD1() As System.String
            Get
                Return _PQDD1
            End Get
            Set(ByVal value As System.String)
                _PQDD1 = value
            End Set
        End Property
#End Region
#Region "部門中文 屬性:PQDD2"
        Private _PQDD2 As System.String
        ''' <summary>
        ''' 部門中文
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PQDD2() As System.String
            Get
                Return _PQDD2
            End Get
            Set(ByVal value As System.String)
                _PQDD2 = value
            End Set
        End Property
#End Region
#Region "新代號 屬性:PQDD3"
        Private _PQDD3 As System.String
        ''' <summary>
        ''' 新代號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property PQDD3() As System.String
            Get
                Return _PQDD3
            End Get
            Set(ByVal value As System.String)
                _PQDD3 = value
            End Set
        End Property
#End Region
#Region "一級部門 屬性:PQDD4"
        Private _PQDD4 As System.String
        ''' <summary>
        ''' 一級部門
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PQDD4() As System.String
            Get
                Return _PQDD4
            End Get
            Set(ByVal value As System.String)
                _PQDD4 = value
            End Set
        End Property
#End Region
#Region "二級部門 屬性:PQDD5"
        Private _PQDD5 As System.String
        ''' <summary>
        ''' 二級部門
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PQDD5() As System.String
            Get
                Return _PQDD5
            End Get
            Set(ByVal value As System.String)
                _PQDD5 = value
            End Set
        End Property
#End Region
#Region "順序 屬性:PQDD6"
        Private _PQDD6 As System.Int32
        ''' <summary>
        ''' 順序
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PQDD6() As System.Int32
            Get
                Return _PQDD6
            End Get
            Set(ByVal value As System.Int32)
                _PQDD6 = value
            End Set
        End Property
#End Region

#Region "尋找單位代碼資料 方法:FindPQDDPDPF"
        ''' <summary>
        ''' 尋找單位代碼資料
        ''' </summary>
        ''' <param name="NewDepCode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function FindPQDDPDPF(ByVal NewDepCode As String) As PQDDPDPF
            Dim QryString As String = "Select * From @#PLT000LB.PQDDPDPF WHERE PQDD3='" & NewDepCode.Replace("'", Nothing).Trim & "'"
            Dim SearchResult As List(Of PQDDPDPF) = PQDDPDPF.CDBSelect(Of PQDDPDPF)(QryString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            If SearchResult.Count = 0 Then
                Return Nothing
            End If
            Return SearchResult(0)
        End Function
#End Region

    End Class
End Namespace