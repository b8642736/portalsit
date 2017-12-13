Namespace SQLServer
	Namespace QCDB01
	Public Class 分析資料_外購
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"QCDB01")
	End Sub

#Region "爐號 屬性:爐號"
	Private _爐號 As System.String
	''' <summary>
	''' 爐號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property 爐號 () As System.String
		Get
			Return _爐號
		End Get
		Set(Byval value as System.String)
			_爐號 = value
		End Set
	End Property
#End Region
#Region "鋼種 屬性:鋼種"
	Private _鋼種 As System.String
	''' <summary>
	''' 鋼種
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 鋼種 () As System.String
		Get
			Return _鋼種
		End Get
		Set(Byval value as System.String)
			_鋼種 = value
		End Set
	End Property
#End Region
#Region "材質 屬性:材質"
	Private _材質 As System.String
	''' <summary>
	''' 材質
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 材質 () As System.String
		Get
			Return _材質
		End Get
		Set(Byval value as System.String)
			_材質 = value
		End Set
	End Property
#End Region
#Region "站別 屬性:站別"
	Private _站別 As System.String
	''' <summary>
	''' 站別
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property 站別 () As System.String
		Get
			Return _站別
		End Get
		Set(Byval value as System.String)
			_站別 = value
		End Set
	End Property
#End Region
#Region "序號 屬性:序號"
	Private _序號 As System.Int16
	''' <summary>
	''' 序號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property 序號 () As System.Int16
		Get
			Return _序號
		End Get
		Set(Byval value as System.Int16)
			_序號 = value
		End Set
	End Property
#End Region
#Region "判定 屬性:判定"
	Private _判定 As System.String
	''' <summary>
	''' 判定
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 判定 () As System.String
		Get
			Return _判定
		End Get
		Set(Byval value as System.String)
			_判定 = value
		End Set
	End Property
#End Region
#Region "日期 屬性:日期"
            Private _日期 As System.Int32
	''' <summary>
	''' 日期
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property 日期() As System.Int32
                Get
                    Return _日期
                End Get
                Set(ByVal value As System.Int32)
                    _日期 = value
                End Set
            End Property
#End Region
#Region "時間 屬性:時間"
	Private _時間 As System.String
	''' <summary>
	''' 時間
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 時間 () As System.String
		Get
			Return _時間
		End Get
		Set(Byval value as System.String)
			_時間 = value
		End Set
	End Property
#End Region
#Region "操作員 屬性:操作員"
	Private _操作員 As System.String
	''' <summary>
	''' 操作員
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 操作員 () As System.String
		Get
			Return _操作員
		End Get
		Set(Byval value as System.String)
			_操作員 = value
		End Set
	End Property
#End Region
#Region "DF 屬性:DF"
	Private _DF As System.Double
	''' <summary>
	''' DF
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property DF () As System.Double
		Get
			Return _DF
		End Get
		Set(Byval value as System.Double)
			_DF = value
		End Set
	End Property
#End Region
#Region "MD30 屬性:MD30"
	Private _MD30 As System.Double
	''' <summary>
	''' MD30
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MD30 () As System.Double
		Get
			Return _MD30
		End Get
		Set(Byval value as System.Double)
			_MD30 = value
		End Set
	End Property
#End Region
#Region "C 屬性:C"
	Private _C As System.Double
	''' <summary>
	''' C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property C () As System.Double
		Get
			Return _C
		End Get
		Set(Byval value as System.Double)
			_C = value
		End Set
	End Property
#End Region
#Region "Si 屬性:Si"
	Private _Si As System.Double
	''' <summary>
	''' Si
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Si () As System.Double
		Get
			Return _Si
		End Get
		Set(Byval value as System.Double)
			_Si = value
		End Set
	End Property
#End Region
#Region "Mn 屬性:Mn"
	Private _Mn As System.Double
	''' <summary>
	''' Mn
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Mn () As System.Double
		Get
			Return _Mn
		End Get
		Set(Byval value as System.Double)
			_Mn = value
		End Set
	End Property
#End Region
#Region "P 屬性:P"
	Private _P As System.Double
	''' <summary>
	''' P
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property P () As System.Double
		Get
			Return _P
		End Get
		Set(Byval value as System.Double)
			_P = value
		End Set
	End Property
#End Region
#Region "S 屬性:S"
	Private _S As System.Double
	''' <summary>
	''' S
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property S () As System.Double
		Get
			Return _S
		End Get
		Set(Byval value as System.Double)
			_S = value
		End Set
	End Property
#End Region
#Region "Cr 屬性:Cr"
	Private _Cr As System.Double
	''' <summary>
	''' Cr
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Cr () As System.Double
		Get
			Return _Cr
		End Get
		Set(Byval value as System.Double)
			_Cr = value
		End Set
	End Property
#End Region
#Region "Ni 屬性:Ni"
	Private _Ni As System.Double
	''' <summary>
	''' Ni
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Ni () As System.Double
		Get
			Return _Ni
		End Get
		Set(Byval value as System.Double)
			_Ni = value
		End Set
	End Property
#End Region
#Region "Cu 屬性:Cu"
	Private _Cu As System.Double
	''' <summary>
	''' Cu
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Cu () As System.Double
		Get
			Return _Cu
		End Get
		Set(Byval value as System.Double)
			_Cu = value
		End Set
	End Property
#End Region
#Region "Mo 屬性:Mo"
	Private _Mo As System.Double
	''' <summary>
	''' Mo
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Mo () As System.Double
		Get
			Return _Mo
		End Get
		Set(Byval value as System.Double)
			_Mo = value
		End Set
	End Property
#End Region
#Region "Co 屬性:Co"
	Private _Co As System.Double
	''' <summary>
	''' Co
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Co () As System.Double
		Get
			Return _Co
		End Get
		Set(Byval value as System.Double)
			_Co = value
		End Set
	End Property
#End Region
#Region "AL 屬性:AL"
	Private _AL As System.Double
	''' <summary>
	''' AL
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property AL () As System.Double
		Get
			Return _AL
		End Get
		Set(Byval value as System.Double)
			_AL = value
		End Set
	End Property
#End Region
#Region "Sn 屬性:Sn"
	Private _Sn As System.Double
	''' <summary>
	''' Sn
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Sn () As System.Double
		Get
			Return _Sn
		End Get
		Set(Byval value as System.Double)
			_Sn = value
		End Set
	End Property
#End Region
#Region "Pb 屬性:Pb"
	Private _Pb As System.Double
	''' <summary>
	''' Pb
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Pb () As System.Double
		Get
			Return _Pb
		End Get
		Set(Byval value as System.Double)
			_Pb = value
		End Set
	End Property
#End Region
#Region "Ti 屬性:Ti"
	Private _Ti As System.Double
	''' <summary>
	''' Ti
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Ti () As System.Double
		Get
			Return _Ti
		End Get
		Set(Byval value as System.Double)
			_Ti = value
		End Set
	End Property
#End Region
#Region "Nb 屬性:Nb"
	Private _Nb As System.Double
	''' <summary>
	''' Nb
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Nb () As System.Double
		Get
			Return _Nb
		End Get
		Set(Byval value as System.Double)
			_Nb = value
		End Set
	End Property
#End Region
#Region "V 屬性:V"
	Private _V As System.Double
	''' <summary>
	''' V
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property V () As System.Double
		Get
			Return _V
		End Get
		Set(Byval value as System.Double)
			_V = value
		End Set
	End Property
#End Region
#Region "W 屬性:W"
	Private _W As System.Double
	''' <summary>
	''' W
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property W () As System.Double
		Get
			Return _W
		End Get
		Set(Byval value as System.Double)
			_W = value
		End Set
	End Property
#End Region
#Region "O2 屬性:O2"
	Private _O2 As System.Double
	''' <summary>
	''' O2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property O2 () As System.Double
		Get
			Return _O2
		End Get
		Set(Byval value as System.Double)
			_O2 = value
		End Set
	End Property
#End Region
#Region "N2 屬性:N2"
	Private _N2 As System.Double
	''' <summary>
	''' N2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property N2 () As System.Double
		Get
			Return _N2
		End Get
		Set(Byval value as System.Double)
			_N2 = value
		End Set
	End Property
#End Region
#Region "H2 屬性:H2"
	Private _H2 As System.Double
	''' <summary>
	''' H2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property H2 () As System.Double
		Get
			Return _H2
		End Get
		Set(Byval value as System.Double)
			_H2 = value
		End Set
	End Property
#End Region
#Region "B 屬性:B"
	Private _B As System.Double
	''' <summary>
	''' B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property B () As System.Double
		Get
			Return _B
		End Get
		Set(Byval value as System.Double)
			_B = value
		End Set
	End Property
#End Region
#Region "Ca 屬性:Ca"
	Private _Ca As System.Double
	''' <summary>
	''' Ca
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Ca () As System.Double
		Get
			Return _Ca
		End Get
		Set(Byval value as System.Double)
			_Ca = value
		End Set
	End Property
#End Region
#Region "Mg 屬性:Mg"
	Private _Mg As System.Double
	''' <summary>
	''' Mg
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Mg () As System.Double
		Get
			Return _Mg
		End Get
		Set(Byval value as System.Double)
			_Mg = value
		End Set
	End Property
#End Region
#Region "Fe 屬性:Fe"
	Private _Fe As System.Double
	''' <summary>
	''' Fe
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Fe () As System.Double
		Get
			Return _Fe
		End Get
		Set(Byval value as System.Double)
			_Fe = value
		End Set
	End Property
#End Region
#Region "N1 屬性:N1"
	Private _N1 As System.Double
	''' <summary>
	''' N1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property N1 () As System.Double
		Get
			Return _N1
		End Get
		Set(Byval value as System.Double)
			_N1 = value
		End Set
	End Property
#End Region
#Region "O1 屬性:O1"
	Private _O1 As System.Double
	''' <summary>
	''' O1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property O1 () As System.Double
		Get
			Return _O1
		End Get
		Set(Byval value as System.Double)
			_O1 = value
		End Set
	End Property
#End Region
#Region "C2 屬性:C2"
	Private _C2 As System.Double
	''' <summary>
	''' C2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property C2 () As System.Double
		Get
			Return _C2
		End Get
		Set(Byval value as System.Double)
			_C2 = value
		End Set
	End Property
#End Region
#Region "S2 屬性:S2"
	Private _S2 As System.Double
	''' <summary>
	''' S2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property S2 () As System.Double
		Get
			Return _S2
		End Get
		Set(Byval value as System.Double)
			_S2 = value
		End Set
	End Property
#End Region
#Region "Ag 屬性:Ag"
            Private _Ag As System.Double
            ''' <summary>
            ''' Ag
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Ag() As System.Double
                Get
                    Return _Ag
                End Get
                Set(ByVal value As System.Double)
                    _Ag = value
                End Set
            End Property
#End Region
#Region "分光儀編號 屬性:分光儀編號"
            Private _分光儀編號 As System.String
	''' <summary>
	''' 分光儀編號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 分光儀編號 () As System.String
		Get
			Return _分光儀編號
		End Get
		Set(Byval value as System.String)
			_分光儀編號 = value
		End Set
	End Property
#End Region
#Region "輻射 屬性:輻射"
	Private _輻射 As System.Double
	''' <summary>
	''' 輻射
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 輻射 () As System.Double
		Get
			Return _輻射
		End Get
		Set(Byval value as System.Double)
			_輻射 = value
		End Set
	End Property
#End Region
#Region "連鑄爐次 屬性:連鑄爐次"
	Private _連鑄爐次 As System.Int16
	''' <summary>
	''' 連鑄爐次
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 連鑄爐次 () As System.Int16
		Get
			Return _連鑄爐次
		End Get
		Set(Byval value as System.Int16)
			_連鑄爐次 = value
		End Set
	End Property
#End Region
#Region "最後爐 屬性:最後爐"
	Private _最後爐 As System.String
	''' <summary>
	''' 最後爐
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 最後爐 () As System.String
		Get
			Return _最後爐
		End Get
		Set(Byval value as System.String)
			_最後爐 = value
		End Set
	End Property
#End Region
#Region "驗收料 屬性:驗收料"
	Private _驗收料 As System.String
	''' <summary>
	''' 驗收料
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 驗收料 () As System.String
		Get
			Return _驗收料
		End Get
		Set(Byval value as System.String)
			_驗收料 = value
		End Set
	End Property
#End Region
#Region "備註1 屬性:備註1"
	Private _備註1 As System.String
	''' <summary>
	''' 備註1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 備註1 () As System.String
		Get
			Return _備註1
		End Get
		Set(Byval value as System.String)
			_備註1 = value
		End Set
	End Property
#End Region
#Region "資料異動者 屬性:資料異動者"
	Private _資料異動者 As System.String
	''' <summary>
	''' 資料異動者
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 資料異動者 () As System.String
		Get
			Return _資料異動者
		End Get
		Set(Byval value as System.String)
			_資料異動者 = value
		End Set
	End Property
#End Region
#Region "資料異動日期 屬性:資料異動日期"
	Private _資料異動日期 As System.DateTime
	''' <summary>
	''' 資料異動日期
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 資料異動日期 () As System.DateTime
		Get
			Return _資料異動日期
		End Get
		Set(Byval value as System.DateTime)
			_資料異動日期 = value
		End Set
	End Property
#End Region
#Region "內部驗收 屬性:內部驗收"
	Private _內部驗收 As System.String
	''' <summary>
	''' 內部驗收
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 內部驗收 () As System.String
		Get
			Return _內部驗收
		End Get
		Set(Byval value as System.String)
			_內部驗收 = value
		End Set
	End Property
#End Region
#Region "洗爐 屬性:洗爐"
	Private _洗爐 As System.String
	''' <summary>
	''' 洗爐
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 洗爐 () As System.String
		Get
			Return _洗爐
		End Get
		Set(Byval value as System.String)
			_洗爐 = value
		End Set
	End Property
#End Region
#Region "LOSS 屬性:LOSS"
	Private _LOSS As System.String
	''' <summary>
	''' LOSS
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property LOSS () As System.String
		Get
			Return _LOSS
		End Get
		Set(Byval value as System.String)
			_LOSS = value
		End Set
	End Property
#End Region
#Region "LOSS備註 屬性:LOSS備註"
	Private _LOSS備註 As System.String
	''' <summary>
	''' LOSS備註
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property LOSS備註 () As System.String
		Get
			Return _LOSS備註
		End Get
		Set(Byval value as System.String)
			_LOSS備註 = value
		End Set
	End Property
#End Region




#Region "相關AS400成份 屬性:AboutAS400Data"
            ''' <summary>
            ''' 相關AS400成份
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property AboutAS400Data As CompanyORMDB.PPS100LB.PPSQCAPF
                Get
                    Dim DateConvert As New AS400DateConverter
                    Dim GetDate As Date = (New AS400DateConverter(Me.日期)).DateValue.Date
                    Dim StartDate As Integer = New AS400DateConverter(GetDate.AddDays(-7)).TwIntegerTypeData
                    Dim EndDate As Integer = New AS400DateConverter(GetDate.AddDays(3)).TwIntegerTypeData
                    Dim QryString As String = "Select * from @#PPS100LB.PPSQCIPF2 WHERE QCA01A='" & Me.爐號.Trim & "' AND QCA01B='" & Me.站別.Trim & "' AND (QCA02>=" & StartDate & " OR QCA02<=" & EndDate & ")"
                    Dim ReturnValue As List(Of CompanyORMDB.PPS100LB.PPSQCAPF) = CompanyORMDB.PPS100LB.PPSQCAPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSQCAPF)(QryString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                    If ReturnValue.Count = 0 Then
                        Return Nothing
                    End If
                    Return ReturnValue(0)
                End Get
            End Property
#End Region

	End Class
	End Namespace
End Namespace