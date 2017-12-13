Public Class ExTreeNode

    Sub New()

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub
    Sub New(ByVal SetAboutWebMenu)
        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()
        Me.AboutWebMenu = SetAboutWebMenu
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        '請在此處加入您自訂的繪製程式碼
    End Sub

#Region "相關WebMenu 屬性:AboutWebMenu"

    Private _AboutWebMenu As WebMenu
    ''' <summary>
    ''' 相關WebMenu
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AboutWebMenu() As WebMenu
        Get
            Return _AboutWebMenu
        End Get
        Set(ByVal value As WebMenu)
            _AboutWebMenu = value
        End Set
    End Property

#End Region

End Class
