Imports System.Drawing

Public Class QRCode

#Region "New：建構值"
    Sub New()
        Me.New("")
    End Sub
    Sub New(ByVal fromContent As String)
        Me._Content = fromContent
    End Sub
#End Region

#Region "ErrorCorrectionLevel：設定錯誤修正容量"
    '/*
    '  Level L (Low)      7%  of codewords can be restored. 
    '  Level M (Medium)   15% of codewords can be restored. 
    '  Level Q (Quartile) 25% of codewords can be restored. 
    '  Level H (High)     30% of codewords can be restored. 
    '*/
    Private _ErrorCorrectionLevel As Gma.QrCodeNet.Encoding.ErrorCorrectionLevel = Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.L
    Public Property ErrorCorrectionLevel As Gma.QrCodeNet.Encoding.ErrorCorrectionLevel
        Set(value As Gma.QrCodeNet.Encoding.ErrorCorrectionLevel)
            Me._ErrorCorrectionLevel = value
        End Set
        Get
            Return Me._ErrorCorrectionLevel
        End Get
    End Property
#End Region

#Region "Content：QRCode文字內容"
    Private _Content As String
    Public Property Content As String
        Set(value As String)
            Me._Content = value
        End Set
        Get
            If Me._Content.Length > 0 Then
                Return Me._Content
            Else
                Return String.Format("{0}{1}{2}{3}", "Not Set", "Hello World..!", _
                                                                                    vbNewLine, _
                                                                                    Now.ToString("yyyymmdd_HHMMss"))
            End If
        End Get
    End Property
#End Region

#Region "ColorOfDark：QRcode圖片顏色-黑暗"
    Private _ColorOfDark As System.Drawing.Brush = Brushes.Black
    Public Property ColorOfDark As System.Drawing.Brush
        Set(value As System.Drawing.Brush)
            Me._ColorOfDark = value
        End Set
        Get
            Return Me._ColorOfDark
        End Get
    End Property
#End Region

#Region "ColorOfLight：QRcode圖片顏色-明亮"
    Private _ColorOfLight As System.Drawing.Brush = Brushes.White
    Public Property ColorOfLight As System.Drawing.Brush
        Set(value As System.Drawing.Brush)
            Me._ColorOfLight = value
        End Set
        Get
            Return Me._ColorOfLight
        End Get
    End Property
#End Region

#Region "RenderSizeInPixels：定義線條寬度"
    Private _RenderSizeInPixels As Integer = 12
    Public Property RenderSizeInPixels As Integer
        Set(value As Integer)
            Me._RenderSizeInPixels = value
        End Set
        Get
            Return Me._RenderSizeInPixels
        End Get
    End Property

#End Region

#Region "RenderQuietZoneModules"
    Private _RenderQuietZoneModules As Gma.QrCodeNet.Encoding.Windows.Render.QuietZoneModules = Gma.QrCodeNet.Encoding.Windows.Render.QuietZoneModules.Two
    Public Property RenderQuietZoneModules As Gma.QrCodeNet.Encoding.Windows.Render.QuietZoneModules
        Set(value As Gma.QrCodeNet.Encoding.Windows.Render.QuietZoneModules)
            Me._RenderQuietZoneModules = value
        End Set
        Get
            Return Me._RenderQuietZoneModules
        End Get
    End Property
#End Region

#Region "GetImage：取得QRCode影像檔"
    Public Function GetImage() As Image
        '輸入要製作二維條碼的字串
        Dim WEncoder As New Gma.QrCodeNet.Encoding.QrEncoder(Me.ErrorCorrectionLevel)
        Dim WQrCode As Gma.QrCodeNet.Encoding.QrCode = WEncoder.Encode(Me.Content)

        '繪二維條碼圖初始化
        Dim WRenderer As Gma.QrCodeNet.Encoding.Windows.Render.GraphicsRenderer =
                New Gma.QrCodeNet.Encoding.Windows.Render.GraphicsRenderer(
                          New Gma.QrCodeNet.Encoding.Windows.Render.FixedModuleSize(
                                   Me.RenderSizeInPixels,
                                   Me.RenderQuietZoneModules),
                                            Me.ColorOfDark,
                                            Me.ColorOfLight)

        '留白區大小
        Dim WPadding As Point = New Point(2, 2)

        '取得條碼圖大小
        Dim WDrawingSize As Gma.QrCodeNet.Encoding.Windows.Render.DrawingSize = WRenderer.SizeCalculator.GetSize(WQrCode.Matrix.Width)
        Dim WImgWidth As Integer = WDrawingSize.CodeWidth + 2 * WPadding.X
        Dim WImgHeight As Integer = WDrawingSize.CodeWidth + 2 * WPadding.Y

        '設定影像大小
        Dim WImage As Image = New Bitmap(WImgWidth, WImgHeight)

        Dim WGraphics As Graphics = Graphics.FromImage(WImage)
        WRenderer.Draw(WGraphics, WQrCode.Matrix, WPadding)

        Return WImage
    End Function
#End Region
End Class