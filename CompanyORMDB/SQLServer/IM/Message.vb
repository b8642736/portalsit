Namespace SQLServer
	Namespace IM
	Public Class Message
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"IM")
	End Sub

#Region "ID 屬性:ID"
	Private _ID As System.String
	''' <summary>
	''' ID
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ID () As System.String
		Get
			Return _ID
		End Get
		Set(Byval value as System.String)
			_ID = value
		End Set
	End Property
#End Region
#Region "MsgText 屬性:MsgText"
	Private _MsgText As System.String
	''' <summary>
	''' MsgText
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MsgText () As System.String
		Get
			Return _MsgText
		End Get
		Set(Byval value as System.String)
			_MsgText = value
		End Set
	End Property
#End Region
#Region "IsHaveFinalRecieveTime 屬性:IsHaveFinalRecieveTime"
	Private _IsHaveFinalRecieveTime As System.Boolean
	''' <summary>
	''' IsHaveFinalRecieveTime
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property IsHaveFinalRecieveTime () As System.Boolean
		Get
			Return _IsHaveFinalRecieveTime
		End Get
		Set(Byval value as System.Boolean)
			_IsHaveFinalRecieveTime = value
		End Set
	End Property
#End Region
#Region "FinalRecieveMinuteSpan 屬性:FinalRecieveMinuteSpan"
            Private _FinalRecieveMinuteSpan As System.Decimal
            ''' <summary>
            ''' FinalRecieveMinuteSpan
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FinalRecieveMinuteSpan() As System.Decimal
                Get
                    Return _FinalRecieveMinuteSpan
                End Get
                Set(ByVal value As System.Decimal)
                    _FinalRecieveMinuteSpan = value
                End Set
            End Property
#End Region
#Region "IsHaveNotSendReplyTime 屬性:IsHaveNotSendReplyTime"
	Private _IsHaveNotSendReplyTime As System.Boolean
	''' <summary>
	''' IsHaveNotSendReplyTime
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property IsHaveNotSendReplyTime () As System.Boolean
		Get
			Return _IsHaveNotSendReplyTime
		End Get
		Set(Byval value as System.Boolean)
			_IsHaveNotSendReplyTime = value
		End Set
	End Property
#End Region
#Region "NotSendReplyMinuteSpan 屬性:NotSendReplyMinuteSpan"
            Private _NotSendReplyMinuteSpan As System.Decimal
            ''' <summary>
            ''' NotSendReplyMinuteSpan
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property NotSendReplyMinuteSpan() As System.Decimal
                Get
                    Return _NotSendReplyMinuteSpan
                End Get
                Set(ByVal value As System.Decimal)
                    _NotSendReplyMinuteSpan = value
                End Set
            End Property
#End Region
#Region "IsNeedSendEmail 屬性:IsNeedSendEmail"
	Private _IsNeedSendEmail As System.Boolean
	''' <summary>
	''' IsNeedSendEmail
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property IsNeedSendEmail () As System.Boolean
		Get
			Return _IsNeedSendEmail
		End Get
		Set(Byval value as System.Boolean)
			_IsNeedSendEmail = value
		End Set
	End Property
#End Region

	End Class
	End Namespace
End Namespace