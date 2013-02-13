Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Collections
Imports System.Drawing
Imports System.Text
Imports System.Data

Namespace BaseflightGUIControls
    Class artifical_horizon
        Inherits BaseflightControl

#Region "Fields"



        ' Parameters
        Private PitchAngle As Double = 0
        Private RollAngle As Double = 0
        Private bIndicatorType As Boolean = False
        'normal artifical horizon
        ' Images
        Private bmpBackground As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.Horizon_Background)
        Private bmpEmptyBackground As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.Horizon_empty_Background)
        Private bmpHorizon As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.Horizon_GroundSky)
        Private bmpPlane As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.Maquette_Avion)
        Private bmpToggleON As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.toggle_on)
        Private bmpToggleOFF As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.toggle_off)
        Private bmpRoll As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.roll)
        Private bmpPitch As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.pitch)



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

            Dim ptHorizon_sky As New Point(12, -105)
            Dim ptRotation As New Point(75, 75)

            bmpBackground.MakeTransparent(Color.Yellow)
            bmpEmptyBackground.MakeTransparent(Color.Yellow)
            bmpPlane.MakeTransparent(Color.Yellow)
            bmpRoll.MakeTransparent(Color.Yellow)
            bmpPitch.MakeTransparent(Color.Yellow)

            'Horizon
            Dim bmp As New Bitmap(125, 360)
            Dim gfx As Graphics = Graphics.FromImage(bmp)
            Dim maskPen As New Pen(Me.BackColor, 30)

            If bIndicatorType = False Then

                gfx.TranslateTransform(62.0F, 180.0F)
                gfx.RotateTransform(CSng(RollAngle))
                gfx.TranslateTransform(-62.0F, -180.0F)
                gfx.TranslateTransform(0, CSng(PitchAngle) * 2)
                gfx.DrawImageUnscaled(bmpHorizon, 0, 0)

                'Draw
                pe.Graphics.DrawImageUnscaled(bmp, 12, -105)
                ' diplay mask
                pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpBackground.Width, bmpBackground.Height)
                ' display control background
                pe.Graphics.DrawImageUnscaled(bmpBackground, 0, 0, (bmpBackground.Width), (bmpBackground.Height))
                ' display aircraft symbol
                pe.Graphics.DrawImageUnscaled(bmpPlane, CInt(Math.Truncate((0.5 * bmpBackground.Width - 0.5 * bmpPlane.Width))), CInt(Math.Truncate((0.5 * bmpBackground.Height - 0.5 * bmpPlane.Height))), (bmpPlane.Width), (bmpPlane.Height))
                'Display toggle switch
                pe.Graphics.DrawImageUnscaled(bmpToggleOFF, 114, 6)
            Else

                'create an empty Bitmap image
                Dim bmpRollTemp As New Bitmap(bmpRoll.Width, bmpRoll.Height + 50)
                'turn the Bitmap into a Graphics object
                Dim gfxRoll As Graphics = Graphics.FromImage(bmpRollTemp)
                'now we set the rotation point to the center of our image
                gfxRoll.TranslateTransform(CSng(bmpRollTemp.Width) / 2, CSng(bmpRollTemp.Height) / 2)
                'now rotate the image
                gfxRoll.RotateTransform(-CSng(RollAngle))
                gfxRoll.TranslateTransform(-CSng(bmpRollTemp.Width) / 2, -CSng(bmpRollTemp.Height) / 2)
                'now draw our new image onto the graphics object
                gfxRoll.DrawImage(bmpRoll, New Point(0, 25))
                'dispose of our Graphics object
                gfxRoll.Dispose()

                Dim bmpPitchTemp As New Bitmap(bmpPitch.Width, bmpPitch.Height + 50)
                'turn the Bitmap into a Graphics object
                Dim gfxPitch As Graphics = Graphics.FromImage(bmpPitchTemp)
                'now we set the rotation point to the center of our image
                gfxPitch.TranslateTransform(CSng(bmpPitchTemp.Width) / 2, CSng(bmpPitchTemp.Height) / 2)
                'now rotate the image
                gfxPitch.RotateTransform(-CSng(PitchAngle))
                gfxPitch.TranslateTransform(-CSng(bmpPitchTemp.Width) / 2, -CSng(bmpPitchTemp.Height) / 2)
                'now draw our new image onto the graphics object
                gfxPitch.DrawImage(bmpPitch, New Point(0, 25))
                'dispose of our Graphics object
                gfxPitch.Dispose()




                ' diplay mask
                pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpBackground.Width, bmpBackground.Height)
                ' display control background
                pe.Graphics.DrawImageUnscaled(bmpEmptyBackground, 0, 0, (bmpBackground.Width), (bmpBackground.Height))
                'Display toggle switch
                pe.Graphics.DrawImageUnscaled(bmpToggleON, 114, 6)
                'Draw roll
                pe.Graphics.DrawImageUnscaled(bmpRollTemp, 35, 11)
                'Draw pitch
                pe.Graphics.DrawImageUnscaled(bmpPitchTemp, 35, 71)

                bmpRollTemp.Dispose()

                bmpPitchTemp.Dispose()
            End If

            gfx.Dispose()
            bmp.Dispose()
            maskPen.Dispose()


        End Sub

#End Region

#Region "Methods"

        ''' <summary>
        ''' Define the physical value to be displayed on the indicator
        ''' </summary>
        ''' <param name="aircraftPitchAngle">The aircraft pitch angle in °deg</param>
        ''' <param name="aircraftRollAngle">The aircraft roll angle in °deg</param>
        Public Sub SetArtificalHorizon(aircraftPitchAngle As Double, aircraftRollAngle As Double)
            PitchAngle = aircraftPitchAngle
            RollAngle = aircraftRollAngle

            Me.Refresh()
        End Sub

        Public Sub SetArtificalHorizonType(type As Boolean)
            bIndicatorType = type
            Me.Refresh()
        End Sub

        Public Sub ToggleArtificalHorizonType()
            bIndicatorType = Not bIndicatorType
            Me.Refresh()
        End Sub


#End Region

    End Class
End Namespace
