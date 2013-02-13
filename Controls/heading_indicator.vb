Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Collections
Imports System.Drawing
Imports System.Text
Imports System.Data

Namespace BaseflightGUIControls
    Class heading_indicator
        Inherits BaseflightControl
#Region "Fields"

        ' Parameters
        Private Heading As Integer

        ' Images
        Private bmpBackground As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.HeadingIndicator_Background)
        Private bmpHeadingwheel As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.HeadingWeel)
        Private bmpAircaft As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.HeadingIndicator_Aircraft)

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

            ' Pre Display computings
            Dim ptRotation As New Point(75, 75)
            Dim ptImgAircraft As New Point(35, 20)
            Dim ptImgHeadingWeel As New Point(7, 7)

            bmpBackground.MakeTransparent(Color.Yellow)
            bmpHeadingwheel.MakeTransparent(Color.Yellow)
            bmpAircaft.MakeTransparent(Color.Yellow)

            ' diplay mask
            Dim maskPen As New Pen(Me.BackColor, 30)
            'pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpBackground.Width, bmpBackground.Height);

            ' display Background
            pe.Graphics.DrawImageUnscaled(bmpBackground, 0, 0)

            ' display HeadingWheel
            Dim bmp As New Bitmap(136, 136)
            Dim gfx As Graphics = Graphics.FromImage(bmp)
            gfx.TranslateTransform(68.0F, 68.0F)
            gfx.RotateTransform(-Heading)
            gfx.TranslateTransform(-68.0F, -68.0F)
            gfx.DrawImageUnscaled(bmpHeadingwheel, 0, 0)
            pe.Graphics.DrawImageUnscaled(bmp, 7, 7)

            'Add text
            Dim drawFont As New System.Drawing.Font(FontFamily.GenericMonospace, 8.0F)
            Dim drawBrush As New System.Drawing.SolidBrush(System.Drawing.Color.White)
            pe.Graphics.DrawString([String].Format("{0:000°}", Heading), drawFont, drawBrush, 115, 3)
            ' display aircraft
            pe.Graphics.DrawImageUnscaled(bmpAircaft, CInt(ptImgAircraft.X), CInt(ptImgAircraft.Y))

            'Dispose objects used 
            gfx.Dispose()
            bmp.Dispose()
            maskPen.Dispose()
            drawFont.Dispose()
            drawBrush.Dispose()



        End Sub

#End Region

#Region "Methods"

        ''' <summary>
        ''' Define the physical value to be displayed on the indicator
        ''' </summary>
        ''' <param name="aircraftHeading">The aircraft heading in °deg</param>
        Public Sub SetHeadingIndicatorParameters(aircraftHeading As Integer)
            If aircraftHeading < 0 Then
                Heading = 360 + aircraftHeading
            Else
                Heading = aircraftHeading
            End If
            Me.Refresh()
        End Sub

#End Region
    End Class
End Namespace
