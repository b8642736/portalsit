﻿'------------------------------------------------------------------------------
' <auto-generated>
'     這段程式碼是由工具產生的。
'     執行階段版本:4.0.30319.1
'
'     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
'     變更將會遺失。
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Reflection


<Global.System.Data.Linq.Mapping.DatabaseAttribute(Name:="QCdb01")>  _
Partial Public Class PCashDataContext
	Inherits System.Data.Linq.DataContext
	
	Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
	
  #Region "擴充性方法定義"
  Partial Private Sub OnCreated()
  End Sub
  Partial Private Sub InsertPCash3(instance As PCash3)
    End Sub
  Partial Private Sub UpdatePCash3(instance As PCash3)
    End Sub
  Partial Private Sub DeletePCash3(instance As PCash3)
    End Sub
  Partial Private Sub InsertPCash2(instance As PCash2)
    End Sub
  Partial Private Sub UpdatePCash2(instance As PCash2)
    End Sub
  Partial Private Sub DeletePCash2(instance As PCash2)
    End Sub
  Partial Private Sub InsertPCash1(instance As PCash1)
    End Sub
  Partial Private Sub UpdatePCash1(instance As PCash1)
    End Sub
  Partial Private Sub DeletePCash1(instance As PCash1)
    End Sub
  Partial Private Sub InsertPCash4(instance As PCash4)
    End Sub
  Partial Private Sub UpdatePCash4(instance As PCash4)
    End Sub
  Partial Private Sub DeletePCash4(instance As PCash4)
    End Sub
  #End Region
	
	Public Sub New()
		MyBase.New(Global.CompanyLINQDB.My.MySettings.Default.Server1_QCdb01, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public ReadOnly Property PCash3() As System.Data.Linq.Table(Of PCash3)
		Get
			Return Me.GetTable(Of PCash3)
		End Get
	End Property
	
	Public ReadOnly Property PCash2() As System.Data.Linq.Table(Of PCash2)
		Get
			Return Me.GetTable(Of PCash2)
		End Get
	End Property
	
	Public ReadOnly Property PCash1() As System.Data.Linq.Table(Of PCash1)
		Get
			Return Me.GetTable(Of PCash1)
		End Get
	End Property
	
	Public ReadOnly Property PCash4() As System.Data.Linq.Table(Of PCash4)
		Get
			Return Me.GetTable(Of PCash4)
		End Get
	End Property
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.PCash3")>  _
Partial Public Class PCash3
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _PC1RecDate As Date
	
	Private _PC1Number As Integer
	
	Private _PC2RecDate As Date
	
	Private _PC2Number As Integer
	
	Private _PCash2 As EntityRef(Of PCash2)
	
	Private _PCash1 As EntityRef(Of PCash1)
	
    #Region "擴充性方法定義"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnPC1RecDateChanging(value As Date)
    End Sub
    Partial Private Sub OnPC1RecDateChanged()
    End Sub
    Partial Private Sub OnPC1NumberChanging(value As Integer)
    End Sub
    Partial Private Sub OnPC1NumberChanged()
    End Sub
    Partial Private Sub OnPC2RecDateChanging(value As Date)
    End Sub
    Partial Private Sub OnPC2RecDateChanged()
    End Sub
    Partial Private Sub OnPC2NumberChanging(value As Integer)
    End Sub
    Partial Private Sub OnPC2NumberChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		Me._PCash2 = CType(Nothing, EntityRef(Of PCash2))
		Me._PCash1 = CType(Nothing, EntityRef(Of PCash1))
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_PC1RecDate", DbType:="DateTime NOT NULL", IsPrimaryKey:=true)>  _
	Public Property PC1RecDate() As Date
		Get
			Return Me._PC1RecDate
		End Get
		Set
			If ((Me._PC1RecDate = value)  _
						= false) Then
				If Me._PCash1.HasLoadedOrAssignedValue Then
					Throw New System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException()
				End If
				Me.OnPC1RecDateChanging(value)
				Me.SendPropertyChanging
				Me._PC1RecDate = value
				Me.SendPropertyChanged("PC1RecDate")
				Me.OnPC1RecDateChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_PC1Number", DbType:="Int NOT NULL", IsPrimaryKey:=true)>  _
	Public Property PC1Number() As Integer
		Get
			Return Me._PC1Number
		End Get
		Set
			If ((Me._PC1Number = value)  _
						= false) Then
				If Me._PCash1.HasLoadedOrAssignedValue Then
					Throw New System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException()
				End If
				Me.OnPC1NumberChanging(value)
				Me.SendPropertyChanging
				Me._PC1Number = value
				Me.SendPropertyChanged("PC1Number")
				Me.OnPC1NumberChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_PC2RecDate", DbType:="DateTime NOT NULL", IsPrimaryKey:=true)>  _
	Public Property PC2RecDate() As Date
		Get
			Return Me._PC2RecDate
		End Get
		Set
			If ((Me._PC2RecDate = value)  _
						= false) Then
				If Me._PCash2.HasLoadedOrAssignedValue Then
					Throw New System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException()
				End If
				Me.OnPC2RecDateChanging(value)
				Me.SendPropertyChanging
				Me._PC2RecDate = value
				Me.SendPropertyChanged("PC2RecDate")
				Me.OnPC2RecDateChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_PC2Number", DbType:="Int NOT NULL", IsPrimaryKey:=true)>  _
	Public Property PC2Number() As Integer
		Get
			Return Me._PC2Number
		End Get
		Set
			If ((Me._PC2Number = value)  _
						= false) Then
				If Me._PCash2.HasLoadedOrAssignedValue Then
					Throw New System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException()
				End If
				Me.OnPC2NumberChanging(value)
				Me.SendPropertyChanging
				Me._PC2Number = value
				Me.SendPropertyChanged("PC2Number")
				Me.OnPC2NumberChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.AssociationAttribute(Name:="PCash2_PCash3", Storage:="_PCash2", ThisKey:="PC2RecDate,PC2Number", OtherKey:="RecDate,Number", IsForeignKey:=true, DeleteOnNull:=true, DeleteRule:="CASCADE")>  _
	Public Property PCash2() As PCash2
		Get
			Return Me._PCash2.Entity
		End Get
		Set
			Dim previousValue As PCash2 = Me._PCash2.Entity
			If ((Object.Equals(previousValue, value) = false)  _
						OrElse (Me._PCash2.HasLoadedOrAssignedValue = false)) Then
				Me.SendPropertyChanging
				If ((previousValue Is Nothing)  _
							= false) Then
					Me._PCash2.Entity = Nothing
					previousValue.PCash3.Remove(Me)
				End If
				Me._PCash2.Entity = value
				If ((value Is Nothing)  _
							= false) Then
					value.PCash3.Add(Me)
					Me._PC2RecDate = value.RecDate
					Me._PC2Number = value.Number
				Else
					Me._PC2RecDate = CType(Nothing, Date)
					Me._PC2Number = CType(Nothing, Integer)
				End If
				Me.SendPropertyChanged("PCash2")
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.AssociationAttribute(Name:="PCash1_PCash3", Storage:="_PCash1", ThisKey:="PC1RecDate,PC1Number", OtherKey:="RecDate,Number", IsForeignKey:=true)>  _
	Public Property PCash1() As PCash1
		Get
			Return Me._PCash1.Entity
		End Get
		Set
			Dim previousValue As PCash1 = Me._PCash1.Entity
			If ((Object.Equals(previousValue, value) = false)  _
						OrElse (Me._PCash1.HasLoadedOrAssignedValue = false)) Then
				Me.SendPropertyChanging
				If ((previousValue Is Nothing)  _
							= false) Then
					Me._PCash1.Entity = Nothing
					previousValue.PCash3.Remove(Me)
				End If
				Me._PCash1.Entity = value
				If ((value Is Nothing)  _
							= false) Then
					value.PCash3.Add(Me)
					Me._PC1RecDate = value.RecDate
					Me._PC1Number = value.Number
				Else
					Me._PC1RecDate = CType(Nothing, Date)
					Me._PC1Number = CType(Nothing, Integer)
				End If
				Me.SendPropertyChanged("PCash1")
			End If
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.PCash2")>  _
Partial Public Class PCash2
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _RecDate As Date
	
	Private _Number As Integer
	
	Private _TicketNumber As String
	
	Private _ToCashDateTime As System.Nullable(Of Date)
	
	Private _IsToCashed As Boolean
	
	Private _IsNewYearStartTicket As Boolean
	
	Private _NewYearStartMoney As Decimal
	
	Private _SaveTime As System.Nullable(Of Date)
	
	Private _PCash3 As EntitySet(Of PCash3)
	
    #Region "擴充性方法定義"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnRecDateChanging(value As Date)
    End Sub
    Partial Private Sub OnRecDateChanged()
    End Sub
    Partial Private Sub OnNumberChanging(value As Integer)
    End Sub
    Partial Private Sub OnNumberChanged()
    End Sub
    Partial Private Sub OnTicketNumberChanging(value As String)
    End Sub
    Partial Private Sub OnTicketNumberChanged()
    End Sub
    Partial Private Sub OnToCashDateTimeChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnToCashDateTimeChanged()
    End Sub
    Partial Private Sub OnIsToCashedChanging(value As Boolean)
    End Sub
    Partial Private Sub OnIsToCashedChanged()
    End Sub
    Partial Private Sub OnIsNewYearStartTicketChanging(value As Boolean)
    End Sub
    Partial Private Sub OnIsNewYearStartTicketChanged()
    End Sub
    Partial Private Sub OnNewYearStartMoneyChanging(value As Decimal)
    End Sub
    Partial Private Sub OnNewYearStartMoneyChanged()
    End Sub
    Partial Private Sub OnSaveTimeChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnSaveTimeChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		Me._PCash3 = New EntitySet(Of PCash3)(AddressOf Me.attach_PCash3, AddressOf Me.detach_PCash3)
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_RecDate", DbType:="DateTime NOT NULL", IsPrimaryKey:=true)>  _
	Public Property RecDate() As Date
		Get
			Return Me._RecDate
		End Get
		Set
			If ((Me._RecDate = value)  _
						= false) Then
				Me.OnRecDateChanging(value)
				Me.SendPropertyChanging
				Me._RecDate = value
				Me.SendPropertyChanged("RecDate")
				Me.OnRecDateChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Number", DbType:="Int NOT NULL", IsPrimaryKey:=true)>  _
	Public Property Number() As Integer
		Get
			Return Me._Number
		End Get
		Set
			If ((Me._Number = value)  _
						= false) Then
				Me.OnNumberChanging(value)
				Me.SendPropertyChanging
				Me._Number = value
				Me.SendPropertyChanged("Number")
				Me.OnNumberChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_TicketNumber", DbType:="Char(12)")>  _
	Public Property TicketNumber() As String
		Get
			Return Me._TicketNumber
		End Get
		Set
			If (String.Equals(Me._TicketNumber, value) = false) Then
				Me.OnTicketNumberChanging(value)
				Me.SendPropertyChanging
				Me._TicketNumber = value
				Me.SendPropertyChanged("TicketNumber")
				Me.OnTicketNumberChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_ToCashDateTime", DbType:="DateTime")>  _
	Public Property ToCashDateTime() As System.Nullable(Of Date)
		Get
			Return Me._ToCashDateTime
		End Get
		Set
			If (Me._ToCashDateTime.Equals(value) = false) Then
				Me.OnToCashDateTimeChanging(value)
				Me.SendPropertyChanging
				Me._ToCashDateTime = value
				Me.SendPropertyChanged("ToCashDateTime")
				Me.OnToCashDateTimeChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IsToCashed", DbType:="Bit NOT NULL")>  _
	Public Property IsToCashed() As Boolean
		Get
			Return Me._IsToCashed
		End Get
		Set
			If ((Me._IsToCashed = value)  _
						= false) Then
				Me.OnIsToCashedChanging(value)
				Me.SendPropertyChanging
				Me._IsToCashed = value
				Me.SendPropertyChanged("IsToCashed")
				Me.OnIsToCashedChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IsNewYearStartTicket", DbType:="Bit NOT NULL")>  _
	Public Property IsNewYearStartTicket() As Boolean
		Get
			Return Me._IsNewYearStartTicket
		End Get
		Set
			If ((Me._IsNewYearStartTicket = value)  _
						= false) Then
				Me.OnIsNewYearStartTicketChanging(value)
				Me.SendPropertyChanging
				Me._IsNewYearStartTicket = value
				Me.SendPropertyChanged("IsNewYearStartTicket")
				Me.OnIsNewYearStartTicketChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_NewYearStartMoney", DbType:="Money NOT NULL")>  _
	Public Property NewYearStartMoney() As Decimal
		Get
			Return Me._NewYearStartMoney
		End Get
		Set
			If ((Me._NewYearStartMoney = value)  _
						= false) Then
				Me.OnNewYearStartMoneyChanging(value)
				Me.SendPropertyChanging
				Me._NewYearStartMoney = value
				Me.SendPropertyChanged("NewYearStartMoney")
				Me.OnNewYearStartMoneyChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_SaveTime", DbType:="DateTime")>  _
	Public Property SaveTime() As System.Nullable(Of Date)
		Get
			Return Me._SaveTime
		End Get
		Set
			If (Me._SaveTime.Equals(value) = false) Then
				Me.OnSaveTimeChanging(value)
				Me.SendPropertyChanging
				Me._SaveTime = value
				Me.SendPropertyChanged("SaveTime")
				Me.OnSaveTimeChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.AssociationAttribute(Name:="PCash2_PCash3", Storage:="_PCash3", ThisKey:="RecDate,Number", OtherKey:="PC2RecDate,PC2Number")>  _
	Public Property PCash3() As EntitySet(Of PCash3)
		Get
			Return Me._PCash3
		End Get
		Set
			Me._PCash3.Assign(value)
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
	
	Private Sub attach_PCash3(ByVal entity As PCash3)
		Me.SendPropertyChanging
		entity.PCash2 = Me
	End Sub
	
	Private Sub detach_PCash3(ByVal entity As PCash3)
		Me.SendPropertyChanging
		entity.PCash2 = Nothing
	End Sub
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.PCash1")>  _
Partial Public Class PCash1
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _RecDate As Date
	
	Private _Number As Integer
	
	Private _DepCode As String
	
	Private _Descript As String
	
	Private _PutMoney As System.Nullable(Of Decimal)
	
	Private _SaveTime As System.Nullable(Of Date)
	
	Private _PCash3 As EntitySet(Of PCash3)
	
	Private _PCash4 As EntityRef(Of PCash4)
	
    #Region "擴充性方法定義"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnRecDateChanging(value As Date)
    End Sub
    Partial Private Sub OnRecDateChanged()
    End Sub
    Partial Private Sub OnNumberChanging(value As Integer)
    End Sub
    Partial Private Sub OnNumberChanged()
    End Sub
    Partial Private Sub OnDepCodeChanging(value As String)
    End Sub
    Partial Private Sub OnDepCodeChanged()
    End Sub
    Partial Private Sub OnDescriptChanging(value As String)
    End Sub
    Partial Private Sub OnDescriptChanged()
    End Sub
    Partial Private Sub OnPutMoneyChanging(value As System.Nullable(Of Decimal))
    End Sub
    Partial Private Sub OnPutMoneyChanged()
    End Sub
    Partial Private Sub OnSaveTimeChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnSaveTimeChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		Me._PCash3 = New EntitySet(Of PCash3)(AddressOf Me.attach_PCash3, AddressOf Me.detach_PCash3)
		Me._PCash4 = CType(Nothing, EntityRef(Of PCash4))
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_RecDate", DbType:="DateTime NOT NULL", IsPrimaryKey:=true)>  _
	Public Property RecDate() As Date
		Get
			Return Me._RecDate
		End Get
		Set
			If ((Me._RecDate = value)  _
						= false) Then
				Me.OnRecDateChanging(value)
				Me.SendPropertyChanging
				Me._RecDate = value
				Me.SendPropertyChanged("RecDate")
				Me.OnRecDateChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Number", DbType:="Int NOT NULL", IsPrimaryKey:=true)>  _
	Public Property Number() As Integer
		Get
			Return Me._Number
		End Get
		Set
			If ((Me._Number = value)  _
						= false) Then
				Me.OnNumberChanging(value)
				Me.SendPropertyChanging
				Me._Number = value
				Me.SendPropertyChanged("Number")
				Me.OnNumberChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DepCode", DbType:="Char(10)")>  _
	Public Property DepCode() As String
		Get
			Return Me._DepCode
		End Get
		Set
			If (String.Equals(Me._DepCode, value) = false) Then
				If Me._PCash4.HasLoadedOrAssignedValue Then
					Throw New System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException()
				End If
				Me.OnDepCodeChanging(value)
				Me.SendPropertyChanging
				Me._DepCode = value
				Me.SendPropertyChanged("DepCode")
				Me.OnDepCodeChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Descript", DbType:="Text", UpdateCheck:=UpdateCheck.Never)>  _
	Public Property Descript() As String
		Get
			Return Me._Descript
		End Get
		Set
			If (String.Equals(Me._Descript, value) = false) Then
				Me.OnDescriptChanging(value)
				Me.SendPropertyChanging
				Me._Descript = value
				Me.SendPropertyChanged("Descript")
				Me.OnDescriptChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_PutMoney", DbType:="Money")>  _
	Public Property PutMoney() As System.Nullable(Of Decimal)
		Get
			Return Me._PutMoney
		End Get
		Set
			If (Me._PutMoney.Equals(value) = false) Then
				Me.OnPutMoneyChanging(value)
				Me.SendPropertyChanging
				Me._PutMoney = value
				Me.SendPropertyChanged("PutMoney")
				Me.OnPutMoneyChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_SaveTime", DbType:="DateTime")>  _
	Public Property SaveTime() As System.Nullable(Of Date)
		Get
			Return Me._SaveTime
		End Get
		Set
			If (Me._SaveTime.Equals(value) = false) Then
				Me.OnSaveTimeChanging(value)
				Me.SendPropertyChanging
				Me._SaveTime = value
				Me.SendPropertyChanged("SaveTime")
				Me.OnSaveTimeChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.AssociationAttribute(Name:="PCash1_PCash3", Storage:="_PCash3", ThisKey:="RecDate,Number", OtherKey:="PC1RecDate,PC1Number")>  _
	Public Property PCash3() As EntitySet(Of PCash3)
		Get
			Return Me._PCash3
		End Get
		Set
			Me._PCash3.Assign(value)
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.AssociationAttribute(Name:="PCash4_PCash1", Storage:="_PCash4", ThisKey:="DepCode", OtherKey:="DepCode", IsForeignKey:=true)>  _
	Public Property PCash4() As PCash4
		Get
			Return Me._PCash4.Entity
		End Get
		Set
			Dim previousValue As PCash4 = Me._PCash4.Entity
			If ((Object.Equals(previousValue, value) = false)  _
						OrElse (Me._PCash4.HasLoadedOrAssignedValue = false)) Then
				Me.SendPropertyChanging
				If ((previousValue Is Nothing)  _
							= false) Then
					Me._PCash4.Entity = Nothing
					previousValue.PCash1.Remove(Me)
				End If
				Me._PCash4.Entity = value
				If ((value Is Nothing)  _
							= false) Then
					value.PCash1.Add(Me)
					Me._DepCode = value.DepCode
				Else
					Me._DepCode = CType(Nothing, String)
				End If
				Me.SendPropertyChanged("PCash4")
			End If
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
	
	Private Sub attach_PCash3(ByVal entity As PCash3)
		Me.SendPropertyChanging
		entity.PCash1 = Me
	End Sub
	
	Private Sub detach_PCash3(ByVal entity As PCash3)
		Me.SendPropertyChanging
		entity.PCash1 = Nothing
	End Sub
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.PCash4")>  _
Partial Public Class PCash4
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _DepCode As String
	
	Private _DepName As String
	
	Private _PCash1 As EntitySet(Of PCash1)
	
    #Region "擴充性方法定義"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnDepCodeChanging(value As String)
    End Sub
    Partial Private Sub OnDepCodeChanged()
    End Sub
    Partial Private Sub OnDepNameChanging(value As String)
    End Sub
    Partial Private Sub OnDepNameChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		Me._PCash1 = New EntitySet(Of PCash1)(AddressOf Me.attach_PCash1, AddressOf Me.detach_PCash1)
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DepCode", DbType:="Char(10) NOT NULL", CanBeNull:=false, IsPrimaryKey:=true)>  _
	Public Property DepCode() As String
		Get
			Return Me._DepCode
		End Get
		Set
			If (String.Equals(Me._DepCode, value) = false) Then
				Me.OnDepCodeChanging(value)
				Me.SendPropertyChanging
				Me._DepCode = value
				Me.SendPropertyChanged("DepCode")
				Me.OnDepCodeChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DepName", DbType:="Char(30)")>  _
	Public Property DepName() As String
		Get
			Return Me._DepName
		End Get
		Set
			If (String.Equals(Me._DepName, value) = false) Then
				Me.OnDepNameChanging(value)
				Me.SendPropertyChanging
				Me._DepName = value
				Me.SendPropertyChanged("DepName")
				Me.OnDepNameChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.AssociationAttribute(Name:="PCash4_PCash1", Storage:="_PCash1", ThisKey:="DepCode", OtherKey:="DepCode")>  _
	Public Property PCash1() As EntitySet(Of PCash1)
		Get
			Return Me._PCash1
		End Get
		Set
			Me._PCash1.Assign(value)
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
	
	Private Sub attach_PCash1(ByVal entity As PCash1)
		Me.SendPropertyChanging
		entity.PCash4 = Me
	End Sub
	
	Private Sub detach_PCash1(ByVal entity As PCash1)
		Me.SendPropertyChanging
		entity.PCash4 = Nothing
	End Sub
End Class