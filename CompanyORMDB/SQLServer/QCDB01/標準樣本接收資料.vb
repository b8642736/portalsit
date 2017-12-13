Namespace SQLServer
	Namespace QCDB01
	Public Class 標準樣本接收資料
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
#Region "日期時間 屬性:日期時間"
	Private _日期時間 As System.DateTime
	''' <summary>
	''' 日期時間
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property 日期時間 () As System.DateTime
		Get
			Return _日期時間
		End Get
		Set(Byval value as System.DateTime)
			_日期時間 = value
		End Set
	End Property
#End Region
#Region "點序 屬性:點序"
	Private _點序 As System.Int32
	''' <summary>
	''' 點序
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property 點序 () As System.Int32
		Get
			Return _點序
		End Get
		Set(Byval value as System.Int32)
			_點序 = value
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
#Region "As 屬性:As"
            Private _As As System.Double
	''' <summary>
	''' As
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
            Public Property [As]() As System.Double
                Get
                    Return _As
                End Get
                Set(ByVal value As System.Double)
                    _As = value
                End Set
            End Property
#End Region
#Region "Bi 屬性:Bi"
	Private _Bi As System.Double
	''' <summary>
	''' Bi
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Bi () As System.Double
		Get
			Return _Bi
		End Get
		Set(Byval value as System.Double)
			_Bi = value
		End Set
	End Property
#End Region
#Region "Sb 屬性:Sb"
	Private _Sb As System.Double
	''' <summary>
	''' Sb
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Sb () As System.Double
		Get
			Return _Sb
		End Get
		Set(Byval value as System.Double)
			_Sb = value
		End Set
	End Property
#End Region
#Region "Zn 屬性:Zn"
	Private _Zn As System.Double
	''' <summary>
	''' Zn
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Zn () As System.Double
		Get
			Return _Zn
		End Get
		Set(Byval value as System.Double)
			_Zn = value
		End Set
	End Property
#End Region
#Region "Zr 屬性:Zr"
	Private _Zr As System.Double
	''' <summary>
	''' Zr
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Zr () As System.Double
		Get
			Return _Zr
		End Get
		Set(Byval value as System.Double)
			_Zr = value
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
#Region "SampleMark 屬性:SampleMark"
	Private _SampleMark As System.String
	''' <summary>
	''' SampleMark
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property SampleMark () As System.String
		Get
			Return _SampleMark
		End Get
		Set(Byval value as System.String)
			_SampleMark = value
		End Set
	End Property
#End Region
#Region "Sample 屬性:Sample"
	Private _Sample As System.String
	''' <summary>
	''' Sample
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Sample () As System.String
		Get
			Return _Sample
		End Get
		Set(Byval value as System.String)
			_Sample = value
		End Set
	End Property
#End Region
#Region "Comments 屬性:Comments"
	Private _Comments As System.String
	''' <summary>
	''' Comments
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Comments () As System.String
		Get
			Return _Comments
		End Get
		Set(Byval value as System.String)
			_Comments = value
		End Set
	End Property
#End Region
#Region "Task 屬性:Task"
	Private _Task As System.String
	''' <summary>
	''' Task
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Task () As System.String
		Get
			Return _Task
		End Get
		Set(Byval value as System.String)
			_Task = value
		End Set
	End Property
#End Region
#Region "Method 屬性:Method"
	Private _Method As System.String
	''' <summary>
	''' Method
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Method () As System.String
		Get
			Return _Method
		End Get
		Set(Byval value as System.String)
			_Method = value
		End Set
	End Property
#End Region
#Region "Shift 屬性:Shift"
	Private _Shift As System.String
	''' <summary>
	''' Shift
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Shift () As System.String
		Get
			Return _Shift
		End Get
		Set(Byval value as System.String)
			_Shift = value
		End Set
	End Property
#End Region
#Region "Furance 屬性:Furance"
	Private _Furance As System.String
	''' <summary>
	''' Furance
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Furance () As System.String
		Get
			Return _Furance
		End Get
		Set(Byval value as System.String)
			_Furance = value
		End Set
	End Property
#End Region
#Region "Melt 屬性:Melt"
	Private _Melt As System.String
	''' <summary>
	''' Melt
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Melt () As System.String
		Get
			Return _Melt
		End Get
		Set(Byval value as System.String)
			_Melt = value
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
#Region "Type 屬性:Type"
	Private _Type As System.String
	''' <summary>
	''' Type
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Type () As System.String
		Get
			Return _Type
		End Get
		Set(Byval value as System.String)
			_Type = value
		End Set
	End Property
#End Region
#Region "DeviceName 屬性:DeviceName"
	Private _DeviceName As System.String
	''' <summary>
	''' DeviceName
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property DeviceName () As System.String
		Get
			Return _DeviceName
		End Get
		Set(Byval value as System.String)
			_DeviceName = value
		End Set
	End Property
#End Region
#Region "FK_SampleNumber 屬性:FK_SampleNumber"
	Private _FK_SampleNumber As System.String
	''' <summary>
	''' FK_SampleNumber
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FK_SampleNumber () As System.String
		Get
			Return _FK_SampleNumber
		End Get
		Set(Byval value as System.String)
			_FK_SampleNumber = value
		End Set
	End Property
#End Region
#Region "Ta 屬性:Ta"
            Private _Ta As System.Double
            ''' <summary>
            ''' Ta
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Ta() As System.Double
                Get
                    Return _Ta
                End Get
                Set(ByVal value As System.Double)
                    _Ta = value
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

        End Class
	End Namespace
End Namespace