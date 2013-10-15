Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Text
Imports System.Data

Namespace BaseflightGUIControls
    Class BaseglightMotors
        Inherits BaseflightControl
#Region "Fields"

        ' Parameters

        Private Enum CopterType
            Tri = 1
            QuadP
            QuadX
            BI
            Gimbal
            Y6
            Hex6
            FlyWing
            Y4
            Hex6X
            Octo8Coax
            Octo8P
            Octo8X
            Airplane
            Heli120
            Heli90
            Vtail
        End Enum

        Shared coord_quadX As Integer(,) = {{120, 170, 70}, {120, 80, 70}, {40, 170, 70}, {40, 80, 70}}
        Shared coord_quadP As Integer(,) = {{75, 180, 70}, {125, 130, 70}, {25, 130, 70}, {75, 80, 70}}
        Shared coord_tri As Integer(,) = {{70, 130, 70}, {120, 80, 70}, {20, 80, 70}, {40, 160, 70}}
        Shared coord_y6 As Integer(,) = {{70, 160, 70}, {120, 90, 70}, {20, 90, 70}, {80, 170, 70}, {130, 100, 70}, {30, 100, 70}}
        Shared coord_y4 As Integer(,) = {{95, 170, 70}, {120, 80, 70}, {50, 170, 70}, {20, 80, 70}}
        Shared coord_wing As Integer(,) = {{70, 80, 70}, {20, 140, 70}, {120, 140, 70}}
        Shared coord_gimbal As Integer(,) = {{50, 60, 70}, {50, 120, 70}}
        Shared coord_bi As Integer(,) = {{40, 90, 70}, {120, 90, 70}, {10, 120, 70}, {90, 120, 70}}
        Shared coord_hex6 As Integer(,) = {{120, 170, 70}, {120, 90, 70}, {20, 170, 70}, {20, 90, 70}, {70, 80, 70}, {70, 180, 70}}
        Shared coord_hex6x As Integer(,) = {{100, 180, 70}, {100, 80, 70}, {60, 180, 70}, {60, 80, 70}, {140, 130, 70}, {20, 130, 70}}
        Shared coord_octo8c As Integer(,) = {{110, 170, 60}, {110, 70, 60}, {30, 170, 60}, {30, 70, 60}, {130, 180, 60}, {130, 80, 60}, {50, 180, 60}, {50, 80, 60}}
        Shared coord_octo8p As Integer(,) = {{45, 80, 50}, {115, 80, 50}, {115, 160, 50}, {45, 160, 50}, {80, 60, 50}, {145, 120, 50}, {80, 180, 50}, {15, 120, 50}}
        Shared coord_octo8x As Integer(,) = {{30, 80, 50}, {100, 60, 50}, {130, 150, 50}, {60, 170, 50}, {60, 60, 50}, {130, 80, 50}, {100, 170, 50}, {30, 150, 50}}
        Shared coord_airplane As Integer(,) = {{15, 125, 70}, {130, 125, 70}, {5, 170, 70}, {80, 167, 70}, {80, 75, 70}}
        Shared coord_heli120 As Integer(,) = {{85, 105, 70}, {50, 95, 70}, {75, 155, 70}, {120, 95, 70}, {10, 150, 110}}
        Shared coord_heli90 As Integer(,) = {{85, 105, 70}, {120, 95, 70}, {75, 155, 70}, {50, 95, 70}, {10, 150, 100}}
        Shared coord_vtail As Integer(,) = {{95, 170, 70}, {120, 80, 70}, {50, 170, 70}, {20, 80, 70}}

        Shared CopterTypeToDraw As CopterType = CopterType.QuadP
        Private Shared motorvals As Integer() = {1500, 1500, 1500, 1500, 1500, 1500, 1500, 1500}
        Private Shared servovals As Integer() = {1500, 1500, 1500, 1500, 1500, 1500, 1500, 1500}

        Private l As Integer
        Private i As Integer
        Private hval As Integer
        ' Images

        Private bmpQuadX As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.quadx)
        Private bmpQuadP As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.quadp)
        Private bmpTri As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.tri)
        Private bmpY6 As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.y6)
        Private bmpY4 As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.y4)
        Private bmpBi As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.bicopter)
        Private bmpHex6 As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.hex6)
        Private bmpHex6X As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.hex6x)
        Private bmpFw As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.fw)
        Private bmpGimbal As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.gimbal)
        Private bmpOcto8x As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.octo8x)
        Private bmpOcto8p As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.octo8p)
        Private bmpOcto8c As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.octo8coax)
        Private bmpAirplane As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.airplane)
        Private bmpHeli120 As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.heli_120)
        Private bmpHeli90 As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.heli_90)
        Private bmpVtail As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.vtail)

#End Region

#Region "Constructor"

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

            ' diplay mask
            Dim drawPen As New Pen(Color.White, 1)
            Dim maskPen As New Pen(Me.BackColor, 5)
            Dim drawFont As New System.Drawing.Font(FontFamily.GenericMonospace, 8.0F)
            Dim drawBrush As New System.Drawing.SolidBrush(System.Drawing.Color.Black)
            Dim drawBrushGreen As New System.Drawing.SolidBrush(System.Drawing.Color.LightGreen)
            Dim drawBrushBlue As New System.Drawing.SolidBrush(System.Drawing.Color.LightBlue)

            Select Case CopterTypeToDraw
                Case CopterType.QuadX
                    bmpQuadX.MakeTransparent(Color.Yellow)
                    pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpQuadX.Width, bmpQuadX.Height)
                    pe.Graphics.DrawImageUnscaled(bmpQuadX, 0, 0, bmpQuadX.Width, bmpQuadX.Height)
                    For i As Integer = 0 To 3
                        Dim h As Integer = CInt(Math.Truncate((motorvals(i) - 900) * CSng(coord_quadX(i, 2) / 1200.0F)))
                        pe.Graphics.FillRectangle(drawBrushGreen, coord_quadX(i, 0), coord_quadX(i, 1) - h, 10, h)
                        pe.Graphics.DrawString([String].Format("{0:0}", motorvals(i)), drawFont, drawBrush, coord_quadX(i, 0) + 12, coord_quadX(i, 1) - 10)
                    Next
                    Exit Select
                Case CopterType.QuadP
                    bmpQuadP.MakeTransparent(Color.Yellow)
                    pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpQuadP.Width, bmpQuadP.Height)
                    pe.Graphics.DrawImageUnscaled(bmpQuadP, 0, 0, bmpQuadP.Width, bmpQuadP.Height)
                    For i As Integer = 0 To 3
                        Dim h As Integer = CInt(Math.Truncate((motorvals(i) - 900) * CSng(coord_quadP(i, 2) / 1200.0F)))
                        pe.Graphics.FillRectangle(drawBrushGreen, coord_quadP(i, 0), coord_quadP(i, 1) - h, 10, h)
                        pe.Graphics.DrawString([String].Format("{0:0}", motorvals(i)), drawFont, drawBrush, coord_quadP(i, 0) + 12, coord_quadP(i, 1) - 10)
                    Next
                    Exit Select
                Case CopterType.Tri
                    bmpTri.MakeTransparent(Color.Yellow)
                    pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpTri.Width, bmpTri.Height)
                    pe.Graphics.DrawImageUnscaled(bmpTri, 0, 0, bmpTri.Width, bmpTri.Height)
                    For i As Integer = 0 To 2
                        Dim h As Integer = CInt(Math.Truncate((motorvals(i) - 900) * CSng(coord_tri(i, 2) / 1200.0F)))
                        pe.Graphics.FillRectangle(drawBrushGreen, coord_tri(i, 0), coord_tri(i, 1) - h, 10, h)
                        pe.Graphics.DrawString([String].Format("{0:0}", motorvals(i)), drawFont, drawBrush, coord_tri(i, 0) + 12, coord_tri(i, 1) - 10)
                    Next
                    l = CInt(Math.Truncate((servovals(5) - 900) * CSng(coord_tri(3, 2) / 1200.0F)))
                    pe.Graphics.FillRectangle(drawBrushGreen, coord_tri(3, 0), coord_tri(3, 1) - 10, l, 10)
                    pe.Graphics.DrawString([String].Format("{0:0}", servovals(5)), drawFont, drawBrush, coord_tri(3, 0), coord_tri(3, 1))
                    Exit Select
                Case CopterType.Gimbal
                    bmpGimbal.MakeTransparent(Color.Yellow)
                    pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpGimbal.Width, bmpGimbal.Height)
                    pe.Graphics.DrawImageUnscaled(bmpGimbal, 0, 0, bmpGimbal.Width, bmpGimbal.Height)
                    For i As Integer = 0 To 1
                        l = CInt(Math.Truncate((servovals(i + 1) - 900) * CSng(coord_gimbal(i, 2) / 1200.0F)))
                        pe.Graphics.FillRectangle(drawBrushGreen, coord_gimbal(i, 0), coord_gimbal(i, 1) - 10, l, 10)
                        pe.Graphics.DrawString([String].Format("{0:0}", servovals(i + 1)), drawFont, drawBrush, coord_gimbal(i, 0), coord_gimbal(i, 1))
                    Next
                    Exit Select
                Case CopterType.Y6
                    bmpY6.MakeTransparent(Color.Yellow)
                    pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpY6.Width, bmpY6.Height)
                    pe.Graphics.DrawImageUnscaled(bmpY6, 0, 0, bmpY6.Width, bmpY6.Height)
                    For i As Integer = 0 To 5
                        Dim h As Integer = CInt(Math.Truncate((motorvals(i) - 900) * CSng(coord_y6(i, 2) / 1200.0F)))
                        pe.Graphics.FillRectangle(drawBrushGreen, coord_y6(i, 0), coord_y6(i, 1) - h, 9, h)
                        If i < 3 Then
                            pe.Graphics.DrawString([String].Format("{0:0}", motorvals(i)), drawFont, drawBrush, coord_y6(i, 0) + 9, coord_y6(i, 1) - 73)
                        Else
                            pe.Graphics.DrawString([String].Format("{0:0}", motorvals(i)), drawFont, drawBrush, coord_y6(i, 0) + 9, coord_y6(i, 1) - 11)
                        End If
                    Next
                    Exit Select
                Case CopterType.Y4
                    bmpY4.MakeTransparent(Color.Yellow)
                    pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpY4.Width, bmpY4.Height)
                    pe.Graphics.DrawImageUnscaled(bmpY4, 0, 0, bmpY4.Width, bmpY4.Height)
                    For i As Integer = 0 To 3
                        Dim h As Integer = CInt(Math.Truncate((motorvals(i) - 900) * CSng(coord_y4(i, 2) / 1200.0F)))
                        pe.Graphics.FillRectangle(drawBrushGreen, coord_y4(i, 0), coord_y4(i, 1) - h, 10, h)
                        pe.Graphics.DrawString([String].Format("{0:0}", motorvals(i)), drawFont, drawBrush, coord_y4(i, 0) + 12, coord_y4(i, 1) - 10)
                    Next
                    Exit Select
                Case CopterType.BI
                    bmpBi.MakeTransparent(Color.Yellow)
                    pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpBi.Width, bmpBi.Height)
                    pe.Graphics.DrawImageUnscaled(bmpBi, 0, 0, bmpBi.Width, bmpBi.Height)
                    For i As Integer = 0 To 1
                        Dim h As Integer = CInt(Math.Truncate((motorvals(i) - 900) * CSng(coord_bi(i, 2) / 1200.0F)))
                        pe.Graphics.FillRectangle(drawBrushGreen, coord_bi(i, 0), coord_bi(i, 1) - h, 10, h)
                        pe.Graphics.DrawString([String].Format("{0:0}", motorvals(i)), drawFont, drawBrush, coord_bi(i, 0) + 12, coord_bi(i, 1) - 10)
                    Next
                    For i As Integer = 0 To 1
                        l = CInt(Math.Truncate((servovals(i + 4) - 900) * CSng(coord_bi(2 + i, 2) / 1200.0F)))
                        pe.Graphics.FillRectangle(drawBrushGreen, coord_bi(2 + i, 0), coord_bi(2 + i, 1) - 10, l, 10)
                        '??? is servo 0 in new gui also?
                        pe.Graphics.DrawString([String].Format("{0:0}", servovals(i + 4)), drawFont, drawBrush, coord_bi(2 + i, 0), coord_bi(2 + i, 1))
                    Next
                    Exit Select
                Case CopterType.Hex6
                    bmpHex6.MakeTransparent(Color.Yellow)
                    pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpHex6.Width, bmpHex6.Height)
                    pe.Graphics.DrawImageUnscaled(bmpHex6, 0, 0, bmpHex6.Width, bmpHex6.Height)
                    For i As Integer = 0 To 5
                        Dim h As Integer = CInt(Math.Truncate((motorvals(i) - 900) * CSng(coord_hex6(i, 2) / 1200.0F)))
                        pe.Graphics.FillRectangle(drawBrushGreen, coord_hex6(i, 0), coord_hex6(i, 1) - h, 10, h)
                        pe.Graphics.DrawString([String].Format("{0:0}", motorvals(i)), drawFont, drawBrush, coord_hex6(i, 0) + 9, coord_hex6(i, 1) - 12)
                    Next
                    Exit Select
                Case CopterType.Hex6X
                    bmpHex6X.MakeTransparent(Color.Yellow)
                    pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpHex6X.Width, bmpHex6X.Height)
                    pe.Graphics.DrawImageUnscaled(bmpHex6X, 0, 0, bmpHex6X.Width, bmpHex6X.Height)
                    For i As Integer = 0 To 5
                        Dim h As Integer = CInt(Math.Truncate((motorvals(i) - 900) * CSng(coord_hex6x(i, 2) / 1200.0F)))
                        pe.Graphics.FillRectangle(drawBrushGreen, coord_hex6x(i, 0), coord_hex6x(i, 1) - h, 10, h)
                        If i > 3 Then
                            pe.Graphics.DrawString([String].Format("{0:0}", motorvals(i)), drawFont, drawBrush, coord_hex6x(i, 0) - 12, coord_hex6x(i, 1) + 8)
                        Else
                            pe.Graphics.DrawString([String].Format("{0:0}", motorvals(i)), drawFont, drawBrush, coord_hex6x(i, 0) + 9, coord_hex6x(i, 1) - 12)
                        End If
                    Next
                    Exit Select
                Case CopterType.FlyWing
                    bmpFw.MakeTransparent(Color.Yellow)
                    pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpFw.Width, bmpFw.Height)
                    pe.Graphics.DrawImageUnscaled(bmpFw, 0, 0, bmpFw.Width, bmpFw.Height)
                    Dim bar As Integer = CInt(Math.Truncate((motorvals(0) - 900) * CSng(coord_wing(0, 2) / 1200.0F)))
                    pe.Graphics.FillRectangle(drawBrushGreen, coord_wing(0, 0), coord_wing(0, 1) - bar, 10, bar)
                    pe.Graphics.DrawString([String].Format("{0:0}", motorvals(0)), drawFont, drawBrush, coord_wing(0, 0) + 12, coord_wing(0, 1) - 10)
                    For i As Integer = 1 To 2
                        Dim h As Integer = CInt(Math.Truncate((servovals(i - 1) - 900) * CSng(coord_wing(i, 2) / 1200.0F)))
                        pe.Graphics.FillRectangle(drawBrushGreen, coord_wing(i, 0), coord_wing(i, 1) - h, 10, h)
                        pe.Graphics.DrawString([String].Format("{0:0}", servovals(i - 1)), drawFont, drawBrush, coord_wing(i, 0) + 12, coord_wing(i, 1) - 10)
                    Next
                    Exit Select
                Case CopterType.Octo8Coax
                    bmpOcto8c.MakeTransparent(Color.Yellow)
                    pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpOcto8c.Width, bmpOcto8c.Height)
                    pe.Graphics.DrawImageUnscaled(bmpOcto8c, 0, 0, bmpOcto8c.Width, bmpOcto8c.Height)
                    For i As Integer = 0 To 7
                        Dim h As Integer = CInt(Math.Truncate((motorvals(i) - 900) * CSng(coord_octo8c(i, 2) / 1200.0F)))
                        pe.Graphics.FillRectangle(drawBrushGreen, coord_octo8c(i, 0), coord_octo8c(i, 1) - h, 10, h)
                        pe.Graphics.DrawString([String].Format("{0:0}", motorvals(i)), drawFont, drawBrush, coord_octo8c(i, 0) - 12, coord_octo8c(i, 1))
                    Next
                    Exit Select
                Case CopterType.Octo8P
                    bmpOcto8p.MakeTransparent(Color.Yellow)
                    pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpOcto8p.Width, bmpOcto8p.Height)
                    pe.Graphics.DrawImageUnscaled(bmpOcto8p, 0, 0, bmpOcto8p.Width, bmpOcto8p.Height)
                    For i As Integer = 0 To 7
                        Dim h As Integer = CInt(Math.Truncate((motorvals(i) - 900) * CSng(coord_octo8p(i, 2) / 1200.0F)))
                        pe.Graphics.FillRectangle(drawBrushGreen, coord_octo8p(i, 0), coord_octo8p(i, 1) - h, 10, h)
                        pe.Graphics.DrawString([String].Format("{0:0}", motorvals(i)), drawFont, drawBrush, coord_octo8p(i, 0) - 12, coord_octo8p(i, 1) + 8)
                    Next
                    Exit Select
                Case CopterType.Octo8X
                    bmpOcto8x.MakeTransparent(Color.Yellow)
                    pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpOcto8x.Width, bmpOcto8x.Height)
                    pe.Graphics.DrawImageUnscaled(bmpOcto8x, 0, 0, bmpOcto8x.Width, bmpOcto8x.Height)
                    For i As Integer = 0 To 7
                        Dim h As Integer = CInt(Math.Truncate((motorvals(i) - 900) * CSng(coord_octo8x(i, 2) / 1200.0F)))
                        pe.Graphics.FillRectangle(drawBrushGreen, coord_octo8x(i, 0), coord_octo8x(i, 1) - h, 10, h)
                        pe.Graphics.DrawString([String].Format("{0:0}", motorvals(i)), drawFont, drawBrush, coord_octo8x(i, 0) - 12, coord_octo8x(i, 1) + 8)
                    Next
                    Exit Select
                Case CopterType.Vtail
                    bmpVtail.MakeTransparent(Color.Yellow)
                    pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpVtail.Width, bmpVtail.Height)
                    pe.Graphics.DrawImageUnscaled(bmpVtail, 0, 0, bmpVtail.Width, bmpVtail.Height)
                    For i As Integer = 0 To 3
                        Dim h As Integer = CInt(Math.Truncate((motorvals(i) - 900) * CSng(coord_y4(i, 2) / 1200.0F)))
                        pe.Graphics.FillRectangle(drawBrushGreen, coord_y4(i, 0), coord_y4(i, 1) - h, 10, h)
                        pe.Graphics.DrawString([String].Format("{0:0}", motorvals(i)), drawFont, drawBrush, coord_y4(i, 0) + 12, coord_y4(i, 1) - 10)
                    Next
                    Exit Select
                Case CopterType.Airplane
                    bmpAirplane.MakeTransparent(Color.Yellow)
                    pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpAirplane.Width, bmpAirplane.Height)
                    pe.Graphics.DrawImageUnscaled(bmpAirplane, 0, 0, bmpAirplane.Width, bmpAirplane.Height)

                    hval = CInt(Math.Truncate((servovals(3) - 900) * CSng(coord_airplane(0, 2) / 1200.0F)))
                    'Wing1
                    pe.Graphics.FillRectangle(drawBrushGreen, coord_airplane(0, 0), coord_airplane(0, 1) - hval, 10, hval)
                    pe.Graphics.DrawString([String].Format("{0:0}", servovals(3)), drawFont, drawBrush, coord_airplane(0, 0) + 12, coord_airplane(0, 1) - 10)

                    hval = CInt(Math.Truncate((servovals(4) - 900) * CSng(coord_airplane(1, 2) / 1200.0F)))
                    'Wing2
                    pe.Graphics.FillRectangle(drawBrushGreen, coord_airplane(1, 0), coord_airplane(1, 1) - hval, 10, hval)
                    pe.Graphics.DrawString([String].Format("{0:0}", servovals(4)), drawFont, drawBrush, coord_airplane(1, 0) + 12, coord_airplane(1, 1) - 10)

                    hval = CInt(Math.Truncate((servovals(5) - 900) * CSng(coord_airplane(2, 2) / 1200.0F)))
                    'Rudder
                    pe.Graphics.FillRectangle(drawBrushGreen, coord_airplane(2, 0), coord_airplane(2, 1) - 10, hval, 10)
                    pe.Graphics.DrawString([String].Format("{0:0}", servovals(5)), drawFont, drawBrush, coord_airplane(2, 0), coord_airplane(2, 1) + 10)

                    hval = CInt(Math.Truncate((servovals(6) - 900) * CSng(coord_airplane(3, 2) / 1200.0F)))
                    'Elevator
                    pe.Graphics.FillRectangle(drawBrushGreen, coord_airplane(3, 0), coord_airplane(3, 1) - hval, 10, hval)
                    pe.Graphics.DrawString([String].Format("{0:0}", servovals(6)), drawFont, drawBrush, coord_airplane(3, 0) + 12, coord_airplane(3, 1) - 12)

                    hval = CInt(Math.Truncate((motorvals(0) - 900) * CSng(coord_airplane(4, 2) / 1200.0F)))
                    'hval = CInt(Math.Truncate((servovals(7) - 900) * CSng(coord_airplane(4, 2) / 1200.0F)))
                    'Throttle

                    pe.Graphics.FillRectangle(drawBrushGreen, coord_airplane(4, 0), coord_airplane(4, 1) - hval, 10, hval)
                    pe.Graphics.DrawString([String].Format("{0:0}", servovals(7)), drawFont, drawBrush, coord_airplane(4, 0) + 12, coord_airplane(4, 1) - 10)
                    Exit Select
                Case CopterType.Heli120
                    bmpHeli120.MakeTransparent(Color.Yellow)
                    pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpHeli120.Width, bmpHeli120.Height)
                    pe.Graphics.DrawImageUnscaled(bmpHeli120, 0, 0, bmpHeli120.Width, bmpHeli120.Height)

                    For i As Integer = 0 To 4
                        hval = CInt(Math.Truncate((servovals(3 + i) - 900) * CSng(coord_heli120(i, 2) / 1200.0F)))
                        If i = 2 Then
                            pe.Graphics.FillRectangle(drawBrushGreen, coord_heli120(i, 0), coord_heli120(i, 1) - 10, hval, 10)
                        Else
                            pe.Graphics.FillRectangle(drawBrushGreen, coord_heli120(i, 0), coord_heli120(i, 1) - hval, 10, hval)
                        End If

                        pe.Graphics.DrawString([String].Format("{0:0}", servovals(3 + i)), drawFont, drawBrush, coord_heli120(i, 0), coord_heli120(i, 1) + 10)
                    Next
                    Exit Select
                Case CopterType.Heli90
                    bmpHeli90.MakeTransparent(Color.Yellow)
                    pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpHeli90.Width, bmpHeli90.Height)
                    pe.Graphics.DrawImageUnscaled(bmpHeli90, 0, 0, bmpHeli90.Width, bmpHeli90.Height)

                    For i As Integer = 0 To 4
                        hval = CInt(Math.Truncate((servovals(3 + i) - 900) * CSng(coord_heli90(i, 2) / 1200.0F)))
                        If i = 2 Then
                            pe.Graphics.FillRectangle(drawBrushGreen, coord_heli90(i, 0), coord_heli90(i, 1) - 10, hval, 10)
                        Else
                            pe.Graphics.FillRectangle(drawBrushGreen, coord_heli90(i, 0), coord_heli90(i, 1) - hval, 10, hval)
                        End If

                        pe.Graphics.DrawString([String].Format("{0:0}", servovals(3 + i)), drawFont, drawBrush, coord_heli90(i, 0), coord_heli120(i, 1) + 10)
                    Next
                    Exit Select
            End Select

            'Disposing graph objects
            drawPen.Dispose()
            maskPen.Dispose()
            drawFont.Dispose()
            drawBrush.Dispose()
            drawBrushGreen.Dispose()
            drawBrushBlue.Dispose()
        End Sub

#End Region

#Region "Methods"

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="motor_values"></param>
        ''' <param name="servo_values"></param>
        ''' <param name="MultiType"></param>
        ''' <remarks></remarks>
        Public Sub SetMotorsIndicatorParameters(motor_values As Integer(), servo_values As Integer(), MultiType As Integer)
            motorvals = motor_values
            servovals = servo_values
            CopterTypeToDraw = CType(MultiType, CopterType)
            Me.Refresh()
        End Sub

#End Region

    End Class

End Namespace
