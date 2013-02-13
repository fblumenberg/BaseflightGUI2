Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Text
Imports System.Data

Namespace BaseflightGUIControls
    Class throttle_expo_control
        Inherits BaseflightControl
#Region "Fields"

        ' Parameters
        Private T_MID As Double = 0.5F
        Private T_EXPO As Double = 0.5F
        Private Throttle As Integer = 1100
        Private got_data As [Boolean] = False
        Private lookupT As Integer() = New Integer(10) {}

        ' Images

        Private bmpBackground As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.rcexpo)

#End Region

#Region "Contructor"

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.Container = Nothing

        'Constructor
        Public Sub New()
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
            Try
                Dim drawRedPen As New Pen(Color.Red, 2)

                Dim drawFont As New System.Drawing.Font(FontFamily.GenericMonospace, 8.0F)
                Dim drawBrush As New System.Drawing.SolidBrush(System.Drawing.Color.DarkGray)
                Dim drawBrushBlue As New System.Drawing.SolidBrush(System.Drawing.Color.DarkGray)
                Dim drawBrushRed As New System.Drawing.SolidBrush(System.Drawing.Color.Red)

                bmpBackground.MakeTransparent(Color.Yellow)
                pe.Graphics.DrawImageUnscaled(bmpBackground, 0, 0)

                Dim a As Double = T_MID
                Dim b As Double = T_EXPO
                Dim val As Double

                Dim curvepoints As Integer() = New Integer(74) {}

                For i As Integer = 0 To 10
                    Dim mid As Integer = CInt(Math.Truncate(100 * a))
                    Dim expo As Integer = CInt(Math.Truncate(100 * b))
                    Dim tmp As Integer = 10 * i - mid
                    Dim y As Integer = 1
                    If tmp > 0 Then
                        y = 100 - mid
                    End If
                    If tmp < 0 Then
                        y = mid
                    End If
                    lookupT(i) = CInt(10 * mid + tmp * (100 - expo + tmp * tmp * expo \ (y * y)) \ 10)
                Next

                '4x4 pixel pint fir drawing
                Dim bm As New Bitmap(4, 4)
                Dim gfx As Graphics = Graphics.FromImage(bm)
                gfx.FillRectangle(drawBrushBlue, 0, 0, 3, 3)

                Dim bl As New Bitmap(6, 6)
                Dim gfx1 As Graphics = Graphics.FromImage(bl)
                gfx1.FillRectangle(drawBrushRed, 0, 0, 5, 5)

                'Quick hack to scale the original rc rate box to this control size... I was lazy to rewrite the calculations...
                If got_data Then

                    For i As Integer = 0 To 69
                        Dim tmp As Integer = (1000 \ 70) * i
                        Dim tmp2 As Integer = tmp \ 100
                        Dim rccommand As Integer = lookupT(tmp2) + (tmp - tmp2 * 100) * (lookupT(tmp2 + 1) - lookupT(tmp2)) \ 100
                        val = rccommand * 70 \ 1000
                        pe.Graphics.DrawImageUnscaled(bm, CInt(Math.Truncate(CDbl(i) * 1.9F)) + 9, 5 + CInt(Math.Truncate((70 - val) * 1.2F)))
                        curvepoints(i) = CInt(Math.Truncate((70 - val) * 1.2F))
                    Next
                    curvepoints(70) = curvepoints(69)
                    curvepoints(71) = curvepoints(69)
                    curvepoints(72) = curvepoints(69)
                    curvepoints(73) = curvepoints(69)

                    pe.Graphics.DrawImageUnscaled(bl, CInt(Math.Truncate(CDbl((Math.Max(1100, Throttle) - 1100) * 70 \ 900) * 1.9F)) + 9, curvepoints(CInt(Math.Truncate(CDbl((Math.Max(1100, Throttle) - 1100) * 70 \ 900)))) + 2)

                    pe.Graphics.DrawString("Mid:" & [String].Format("{0:0.00}", T_MID), drawFont, drawBrush, 10, 5)
                    pe.Graphics.DrawString("Expo:" & [String].Format("{0:0.00}", T_EXPO), drawFont, drawBrush, 10, 15)
                Else
                    pe.Graphics.DrawString("No Data", drawFont, drawBrush, 10, 5)
                End If

                gfx.Dispose()
                gfx1.Dispose()
                bl.Dispose()
                bm.Dispose()
                drawBrush.Dispose()
                drawBrushBlue.Dispose()
                drawFont.Dispose()
                drawRedPen.Dispose()
            Catch ex As Exception

            End Try
        End Sub

#End Region

#Region "Methods"

        '''<summary>
        ''' Define the values to be displayed on the indicator
        '''</summary>

        Public Sub SetRCExpoParameters(throttle_MID As Double, throttle_EXPO As Double, rcThrottle As Integer)
            T_MID = throttle_MID
            T_EXPO = throttle_EXPO
            Throttle = rcThrottle

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
