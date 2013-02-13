Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Text
Imports System.Data

Namespace BaseflightGUIControls
    Class GpsIndicatorInstrumentControl
        Inherits BaseflightControl
#Region "Fields"

        ' Parameters
        Private Heading As Integer
        'Heading to Home
        Private Distance As Integer
        'Distance to Home
        Private Numsat As Integer
        'Number of Sats
        Private GPS_fix As Boolean
        'GPS Fix (color of the sat symbol)
        Private GPS_home As Boolean
        'GPS Home is set (left led)
        Private GPS_pkt As Boolean
        'Hearthbeet (right led)

        ' Images

        Private bmpLeftLedGreen As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.gps_left_led_green)
        Private bmpLeftLedRed As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.gps_left_led_red)

        Private bmpRightLedGreen As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.gps_right_led_green)
        Private bmpRightLedRed As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.gps_right_led_red)

        Private bmpHeadingWheel As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.gps_direction)
        Private bmpSatGreen As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.gps_sat_green)
        Private bmpSatRed As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.gps_sat_red)
        Private bmpBackGround As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.gps_background)


#End Region

#Region "Contructor"

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.Container = Nothing

        Public Sub New()
            ' Double bufferisation
            SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint, True)
        End Sub

#End Region

#Region "Component Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify 
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container()
        End Sub
#End Region

#Region "Paint"

        Protected Overrides Sub OnPaint(pe As PaintEventArgs)
            ' Calling the base class OnPaint
            MyBase.OnPaint(pe)

            bmpHeadingWheel.MakeTransparent(Color.Yellow)
            bmpLeftLedGreen.MakeTransparent(Color.Yellow)
            bmpLeftLedRed.MakeTransparent(Color.Yellow)
            bmpRightLedGreen.MakeTransparent(Color.Yellow)
            bmpRightLedRed.MakeTransparent(Color.Yellow)
            bmpSatGreen.MakeTransparent(Color.Yellow)
            bmpSatRed.MakeTransparent(Color.Yellow)
            bmpBackGround.MakeTransparent(Color.Yellow)


            ' diplay mask
            Dim maskPen As New Pen(Me.BackColor, 30)
            pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpBackGround.Width, bmpBackGround.Height)

            ' display background
            pe.Graphics.DrawImageUnscaled(bmpBackGround, 0, 0)

            'Leds
            If GPS_home Then
                pe.Graphics.DrawImageUnscaled(bmpLeftLedGreen, 0, 0)
            Else
                pe.Graphics.DrawImageUnscaled(bmpLeftLedRed, 0, 0)
            End If
            If GPS_pkt Then
                pe.Graphics.DrawImageUnscaled(bmpRightLedGreen, 0, 0)
            Else
                pe.Graphics.DrawImageUnscaled(bmpRightLedRed, 0, 0)
            End If


            Dim bmp As New Bitmap(136, 136)
            Dim gfx As Graphics = Graphics.FromImage(bmp)
            gfx.TranslateTransform(68.0F, 68.0F)
            gfx.RotateTransform(Heading)
            gfx.TranslateTransform(-68.0F, -68.0F)
            gfx.DrawImageUnscaled(bmpHeadingWheel, 0, 0)
            pe.Graphics.DrawImageUnscaled(bmp, 7, 7)

            ' display Sat

            If GPS_fix Then
                pe.Graphics.DrawImageUnscaled(bmpSatGreen, 0, 0)
            Else
                pe.Graphics.DrawImageUnscaled(bmpSatRed, 0, 0)
            End If


            'And add text
            Dim drawFont As New System.Drawing.Font(FontFamily.GenericMonospace, 8.0F)
            Dim drawSatFont As New System.Drawing.Font("Arial", 10.0F)
            Dim drawBrush As New System.Drawing.SolidBrush(System.Drawing.Color.Black)
            pe.Graphics.DrawString([String].Format("{0:0000 m}", Distance), drawFont, drawBrush, 55, 100)
            pe.Graphics.DrawString([String].Format("{0:000°}", Heading), drawFont, drawBrush, 62, 40)
            pe.Graphics.DrawString([String].Format("{0:0}", Numsat), drawSatFont, drawBrush, 89, 64)

            'Dispose temp objects
            maskPen.Dispose()
            gfx.Dispose()
            bmp.Dispose()
            drawFont.Dispose()
            drawSatFont.Dispose()
            drawBrush.Dispose()


        End Sub

#End Region

#Region "Methods"


        ''' <summary>
        ''' Define the physical value to be displayed on the indicator
        ''' </summary>
        Public Sub SetGPSIndicatorParameters(headingtohome As Integer, distancetohome As Integer, numsat__1 As Integer, gpsfix As Boolean, gpshome As Boolean, gpspkt As Boolean)
            Heading = headingtohome
            Distance = distancetohome
            Numsat = numsat__1
            GPS_fix = gpsfix
            GPS_home = gpshome
            GPS_pkt = gpspkt
            Me.Refresh()
        End Sub

#End Region
    End Class
End Namespace
