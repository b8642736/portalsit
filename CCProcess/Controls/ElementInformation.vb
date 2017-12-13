Public Class ElementInformation

#Region "取得化學成份資料 屬性:GetElementInformations"
    ''' <summary>
    ''' 取得化學成份資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetElementInformations(ByVal StoveNumber As String, ByVal NearDate As Date) As List(Of ElementInformation)
        If String.IsNullOrEmpty(StoveNumber) Then
            Return New List(Of ElementInformation)
        End If
        Dim ReturnValue As New List(Of ElementInformation)
        Dim DBContext As New CompanyLINQDB.SMPDataContext
        Dim StartDate As Integer
        Dim EndDate As Integer
        Try
            StartDate = New CompanyORMDB.AS400DateConverter(NearDate.AddMonths(-5)).TwIntegerTypeData
            EndDate = New CompanyORMDB.AS400DateConverter(NearDate.AddMonths(5)).TwIntegerTypeData
        Catch ex As Exception
            Return New List(Of ElementInformation)
        End Try
        Dim SearchResult = (From A In DBContext.分析資料 Where A.爐號 = Left(StoveNumber, 5) And A.日期 >= StartDate And A.日期 <= EndDate And (A.站別.Substring(0, 1) = "L" Or A.站別.Substring(0, 1) = "C") Order By A.日期, A.時間 Select A).ToList

        For Each EachItem In SearchResult
            Dim AddItem As New ElementInformation
            With AddItem
                .StationAndSampleNumber = EachItem.站別 & EachItem.序號
                .C = EachItem.C
                .Si = EachItem.Si
                .Mn = EachItem.Mn
                .P = EachItem.P
                .S = EachItem.S
                .Cr = EachItem.Cr
                .Ni = EachItem.Ni
                .Cu = EachItem.Cu
                .Mo = EachItem.Mo
                .Co = EachItem.Co
                .Al = EachItem.AL
                .Pb = EachItem.Pb
                .Sn = EachItem.Sn
                .O2 = EachItem.O2
                .N2 = EachItem.N2
            End With
            ReturnValue.Add(AddItem)
        Next

        Return ReturnValue
    End Function
#End Region

#Region "站台名稱及樣本塊數 屬性:StationAndSampleNumber"
    Private _StationAndSampleNumber As String
    ''' <summary>
    ''' 站台名稱及樣本塊數
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property StationAndSampleNumber() As String
        Get
            Return _StationAndSampleNumber
        End Get
        Private Set(ByVal value As String)
            _StationAndSampleNumber = value
        End Set
    End Property

#End Region
#Region "元素C 屬性:C"
    Private _C As Single
    Property C As Single
        Get
            Return _C
        End Get
        Private Set(value As Single)
            _C = value
        End Set
    End Property
#End Region
#Region "元素Si 屬性:Si"
    Private _Si As Single
    Property Si As Single
        Get
            Return _Si
        End Get
        Private Set(value As Single)
            _Si = value
        End Set
    End Property
#End Region
#Region "元素Mn 屬性:Mn"
    Private _Mn As Single
    Property Mn As Single
        Get
            Return _Mn
        End Get
        Private Set(value As Single)
            _Mn = value
        End Set
    End Property
#End Region
#Region "元素P 屬性:P"
    Private _P As Single
    Property P As Single
        Get
            Return _P
        End Get
        Private Set(value As Single)
            _P = value
        End Set
    End Property
#End Region
#Region "元素S 屬性:S"
    Private _S As Single
    Property S As Single
        Get
            Return _S
        End Get
        Private Set(value As Single)
            _S = value
        End Set
    End Property
#End Region
#Region "元素Cr 屬性:Cr"
    Private _Cr As Single
    Property Cr As Single
        Get
            Return _Cr
        End Get
        Private Set(value As Single)
            _Cr = value
        End Set
    End Property
#End Region
#Region "元素Ni 屬性:Ni"
    Private _Ni As Single
    Property Ni As Single
        Get
            Return _Ni
        End Get
        Private Set(value As Single)
            _Ni = value
        End Set
    End Property
#End Region
#Region "元素Cu 屬性:Cu"
    Private _Cu As Single
    Property Cu As Single
        Get
            Return _Cu
        End Get
        Private Set(value As Single)
            _Cu = value
        End Set
    End Property
#End Region
#Region "元素Mo 屬性:Mo"
    Private _Mo As Single
    Property Mo As Single
        Get
            Return _Mo
        End Get
        Private Set(value As Single)
            _Mo = value
        End Set
    End Property
#End Region
#Region "元素Co 屬性:Co"
    Private _Co As Single
    Property Co As Single
        Get
            Return _Co
        End Get
        Private Set(value As Single)
            _Co = value
        End Set
    End Property
#End Region
#Region "元素Al 屬性:Al"
    Private _Al As Single
    Property Al As Single
        Get
            Return _Al
        End Get
        Private Set(value As Single)
            _Al = value
        End Set
    End Property
#End Region
#Region "元素Pb 屬性:Pb"
    Private _Pb As Single
    Property Pb As Single
        Get
            Return _Pb
        End Get
        Private Set(value As Single)
            _Pb = value
        End Set
    End Property
#End Region
#Region "元素Sn 屬性:Sn"
    Private _Sn As Single
    Property Sn As Single
        Get
            Return _Sn
        End Get
        Private Set(value As Single)
            _Sn = value
        End Set
    End Property
#End Region
#Region "元素O2 屬性:O2"
    Private _O2 As Single
    Property O2 As Single
        Get
            Return _O2
        End Get
        Private Set(value As Single)
            _O2 = value
        End Set
    End Property
#End Region
#Region "元素N2 屬性:N2"
    Private _N2 As Single
    Property N2 As Single
        Get
            Return _N2
        End Get
        Private Set(value As Single)
            _N2 = value
        End Set
    End Property
#End Region


End Class
