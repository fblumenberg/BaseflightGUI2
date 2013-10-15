Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Text
Imports System.Data

Namespace BaseflightGUIControls
    Class rc_expo_control
        Inherits BaseflightControl

#Region "Fields"

        ' Parameters
        Private RC_Rate As Double = 1.0F
        Private RC_Expo As Double = 0.8F
        Private got_data As [Boolean] = False

        ' Images

        Private bmpBackground As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.rcexpo)


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
            Me.Height = 100
            Me.Width = 150
        End Sub
#End Region

#Region "Paint"

        Protected Overrides Sub OnPaint(pe As PaintEventArgs)
            ' Calling the base class OnPaint
            MyBase.OnPaint(pe)
            Dim drawRedPen As New Pen(Color.Red, 2)

            Dim drawFont As New System.Drawing.Font(FontFamily.GenericMonospace, 8.0F)
            Dim drawBrush As New System.Drawing.SolidBrush(System.Drawing.Color.DarkGray)
            Dim drawBrushGreen As New System.Drawing.SolidBrush(System.Drawing.Color.DarkGray)

            bmpBackground.MakeTransparent(Color.Yellow)
            pe.Graphics.DrawImageUnscaled(bmpBackground, 0, 0)

            Dim a As Double = Math.Min(RC_Rate, 1.0F)
            Dim b As Double = RC_Expo
            Dim inter As Integer
            Dim val As Double

            '4x4 pixel pint fir drawing
            Dim bm As New Bitmap(4, 4)
            Dim gfx As Graphics = Graphics.FromImage(bm)
            gfx.FillRectangle(drawBrushGreen, 0, 0, 3, 3)

            'Quick hack to scale the original rc rate box to this control size... I was lazy to rewrite the calculations...
            If got_data Then


                For i As Integer = 0 To 69
                    inter = 10 * i
                    val = a * inter * (1 - b + inter * inter * b / 490000)
                    pe.Graphics.DrawImageUnscaled(bm, CInt(Math.Truncate(CDbl(i) * 1.9F)) + 9, 5 + CInt(Math.Truncate((70 - val / 10) * 1.2F)))
                Next

                If RC_Rate > 1 Then
                    pe.Graphics.DrawEllipse(drawRedPen, 138, 4, 6, 6)
                End If

                pe.Graphics.DrawString("Rate:" & [String].Format("{0:0.00}", RC_Rate), drawFont, drawBrush, 10, 5)
                pe.Graphics.DrawString("Expo:" & [String].Format("{0:0.00}", RC_Expo), drawFont, drawBrush, 10, 15)
            Else
                pe.Graphics.DrawString("No Data", drawFont, drawBrush, 10, 5)
            End If

            gfx.Dispose()
            bm.Dispose()
            drawBrush.Dispose()
            drawBrushGreen.Dispose()
            drawFont.Dispose()
            drawRedPen.Dispose()

        End Sub

#End Region

#Region "Methods"

        '''<summary>
        ''' Define the values to be displayed on the indicator
        '''</summary>

        Public Sub SetRCExpoParameters(rc_rate__1 As Double, rc_expo__2 As Double)
            RC_Rate = rc_rate__1
            RC_Expo = rc_expo__2
            got_data = True
            Me.Refresh()
        End Sub

        Protected Overrides ReadOnly Property DefaultSize() As Size
            Get
                Return New Size(150, 100)
            End Get
        End Property

        Protected Overrides Sub SetBoundsCore(x As Integer, y As Integer, width As Integer, height As Integer, specified As BoundsSpecified)
            MyBase.SetBoundsCore(x, y, 150, 100, specified)
        End Sub


#End Region
    End Class
End Namespace
