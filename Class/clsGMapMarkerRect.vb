Imports System.Collections.Generic
Imports System.Linq
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO.Ports
Imports System.Threading
Imports GMap.NET
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers

Imports System.Security.Cryptography.X509Certificates

Imports System.Net
Imports System.Net.Sockets
Imports System.Xml
' config file
Imports System.Runtime.InteropServices
' dll imports
Imports ZedGraph
' Graphs
Imports System.Reflection

Imports System.IO

Imports System.Drawing.Drawing2D

'Namespace BaseflightGUI
''' <summary>
''' Struct as used in Ardupilot
''' </summary>
Public Structure Locationwp
    Public id As Byte
    ' command id
    Public options As Byte
    Public p1 As Single
    ' param 1
    Public p2 As Single
    ' param 2
    Public p3 As Single
    ' param 3
    Public p4 As Single
    ' param 4
    Public lat As Single
    ' Lattitude * 10**7
    Public lng As Single
    ' Longitude * 10**7
    Public alt As Single
    ' Altitude in centimeters (meters * 100)
End Structure


''' <summary>
''' used to override the drawing of the waypoint box bounding
''' </summary>
Public Class GMapMarkerRect
    Inherits GMapMarker
    Public Pen As New Pen(Brushes.White, 2)

    Public Property Color() As Color
        Get
            Return Pen.Color
        End Get
        Set(value As Color)
            Pen.Color = value
        End Set
    End Property

    Public InnerMarker As GMapMarker

    Public wprad As Integer = 0
    Public MainMap As GMapControl

    Public Sub New(p As PointLatLng)
        MyBase.New(p)
        Pen.DashStyle = DashStyle.Dash

        ' do not forget set Size of the marker
        ' if so, you shall have no event on it ;}
        Size = New System.Drawing.Size(50, 50)
        Offset = New System.Drawing.Point(-Size.Width \ 2, -Size.Height \ 2 - 20)
    End Sub

    Public Overrides Sub OnRender(g As Graphics)
        MyBase.OnRender(g)

        If wprad = 0 OrElse MainMap Is Nothing Then
            Return
        End If

        ' undo autochange in mouse over
        If Pen.Color = Color.Blue Then
            Pen.Color = Color.White
        End If

        Dim width As Double = (MainMap.MapProvider.Projection.GetDistance(MainMap.FromLocalToLatLng(0, 0), MainMap.FromLocalToLatLng(MainMap.Width, 0)) * 1000.0)
        Dim height As Double = (MainMap.MapProvider.Projection.GetDistance(MainMap.FromLocalToLatLng(0, 0), MainMap.FromLocalToLatLng(MainMap.Height, 0)) * 1000.0)
        Dim m2pixelwidth As Double = MainMap.Width / width
        Dim m2pixelheight As Double = MainMap.Height / height

        Dim loc As New GPoint(CInt(Math.Truncate(LocalPosition.X - (m2pixelwidth * wprad * 2))), LocalPosition.Y)
        ' MainMap.FromLatLngToLocal(wpradposition);
        g.DrawArc(Pen, New System.Drawing.Rectangle(LocalPosition.X - Offset.X - (Math.Abs(loc.X - LocalPosition.X) \ 2), LocalPosition.Y - Offset.Y - Math.Abs(loc.X - LocalPosition.X) \ 2, Math.Abs(loc.X - LocalPosition.X), Math.Abs(loc.X - LocalPosition.X)), 0, 360)

    End Sub
End Class


Public Class GMapMarkerQuad
    Inherits GMapMarker
    Const rad2deg As Single = CSng(180 / Math.PI)
    Const deg2rad As Single = CSng(1.0 / rad2deg)

    Shared ReadOnly SizeSt As New System.Drawing.Size(Global.BaseflightGUI.My.Resources.Resources.quadicon.Width, Global.BaseflightGUI.My.Resources.Resources.quadicon.Height)
    Private heading As Single = 0
    Private cog As Single = -1
    Private target As Single = -1

    Public Sub New(p As PointLatLng, heading As Single, cog As Single, target As Single)
        MyBase.New(p)
        Me.heading = heading
        Me.cog = cog
        Me.target = target
        Size = SizeSt
    End Sub

    Public Overrides Sub OnRender(g As Graphics)
        Dim temp As Matrix = g.Transform
        g.TranslateTransform(LocalPosition.X, LocalPosition.Y)
        Dim pic As Image = Global.BaseflightGUI.My.Resources.Resources.quadicon

        Dim length As Integer = 100
        ' anti NaN
        g.DrawLine(New Pen(Color.Red, 2), 0.0F, 0.0F, CSng(Math.Cos((heading - 90) * deg2rad)) * length, CSng(Math.Sin((heading - 90) * deg2rad)) * length)
        'g.DrawLine(new Pen(Color.Black, 2), 0.0f, 0.0f, (float)Math.Cos((cog - 90) * deg2rad) * length, (float)Math.Sin((cog - 90) * deg2rad) * length);
        'g.DrawLine(new Pen(Color.Orange, 2), 0.0f, 0.0f, (float)Math.Cos((target - 90) * deg2rad) * length, (float)Math.Sin((target - 90) * deg2rad) * length);
        ' anti NaN
        g.RotateTransform(heading)
        g.DrawImageUnscaled(pic, pic.Width \ -2 - 5, pic.Height \ -2)
        g.Transform = temp
    End Sub
End Class

Public Class GMapMarkerHome
    Inherits GMapMarker
    Shared ReadOnly SizeSt As New System.Drawing.Size(Global.BaseflightGUI.My.Resources.Resources.quadicon.Width, Global.BaseflightGUI.My.Resources.Resources.quadicon.Height)

    Public Sub New(p As PointLatLng)
        MyBase.New(p)
        Size = SizeSt
    End Sub

    Public Overrides Sub OnRender(g As Graphics)
        Dim temp As Matrix = g.Transform
        g.TranslateTransform(LocalPosition.X, LocalPosition.Y)
        Dim pic As Image = Global.BaseflightGUI.My.Resources.Resources.home
        g.DrawImageUnscaled(pic, pic.Width \ -2 - 7, -pic.Height - 14)
        g.Transform = temp

    End Sub
End Class

Public Class GMapMarkerWayPoint
    Inherits GMapMarker
    Const rad2deg As Single = CSng(180 / Math.PI)
    Const deg2rad As Single = CSng(1.0 / rad2deg)

    Shared ReadOnly SizeSt As New System.Drawing.Size(Global.BaseflightGUI.My.Resources.WayPoint_x32.Width, Global.BaseflightGUI.My.Resources.WayPoint_x32.Height)
    Private heading As Single = 0
    Private cog As Single = -1
    Private target As Single = -1

    Public Sub New(p As PointLatLng, heading As Single, cog As Single, target As Single)
        MyBase.New(p)
        Me.heading = heading
        Me.cog = cog
        Me.target = target
        Size = SizeSt
    End Sub

    Public Overrides Sub OnRender(g As Graphics)
        Dim temp As Matrix = g.Transform
        g.TranslateTransform(LocalPosition.X, LocalPosition.Y)
        Dim pic As Image = Global.BaseflightGUI.My.Resources.WayPoint_x32

        g.RotateTransform(heading)
        g.DrawImageUnscaled(pic, pic.Width \ -2, pic.Height \ -2)
        g.Transform = temp
    End Sub
End Class

Public Class PointLatLngAlt
    Public Lat As Double = 0
    Public Lng As Double = 0
    Public Alt As Double = 0
    Public Tag As String = ""
    Public color As Color = color.White

    Public Sub New(lat As Double, lng As Double, alt As Double, tag As String)
        Me.Lat = lat
        Me.Lng = lng
        Me.Alt = alt
        Me.Tag = tag
    End Sub


    Public Sub New()
    End Sub

    Public Sub New(pll As GMap.NET.PointLatLng)
        Me.Lat = pll.Lat
        Me.Lng = pll.Lng
    End Sub

    Public Sub New(locwp As Locationwp)
        Me.Lat = locwp.lat
        Me.Lng = locwp.lng
        Me.Alt = locwp.alt
    End Sub

    Public Sub New(plla As PointLatLngAlt)
        Me.Lat = plla.Lat
        Me.Lng = plla.Lng
        Me.Alt = plla.Alt
        Me.color = plla.color
        Me.Tag = plla.Tag
    End Sub

    Public Function Point() As PointLatLng
        Return New PointLatLng(Lat, Lng)
    End Function

    Public Overrides Function Equals(pllaobj As [Object]) As Boolean
        Dim plla As PointLatLngAlt = DirectCast(pllaobj, PointLatLngAlt)

        If plla Is Nothing Then
            Return False
        End If

        If Me.Lat = plla.Lat AndAlso Me.Lng = plla.Lng AndAlso Me.Alt = plla.Alt AndAlso Me.color = plla.color AndAlso Me.Tag = plla.Tag Then
            Return True
        End If
        Return False
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return CInt(Math.Truncate((Lat + Lng + Alt) * 100))
    End Function

    ''' <summary>
    ''' Calc Distance in M
    ''' </summary>
    ''' <param name="p2"></param>
    ''' <returns>Distance in M</returns>
    Public Function GetDistance(p2 As PointLatLngAlt) As Double
        Dim d As Double = Lat * 0.0174532925199433
        Dim num2 As Double = Lng * 0.0174532925199433
        Dim num3 As Double = p2.Lat * 0.0174532925199433
        Dim num4 As Double = p2.Lng * 0.0174532925199433
        Dim num5 As Double = num4 - num2
        Dim num6 As Double = num3 - d
        Dim num7 As Double = Math.Pow(Math.Sin(num6 / 2.0), 2.0) + ((Math.Cos(d) * Math.Cos(num3)) * Math.Pow(Math.Sin(num5 / 2.0), 2.0))
        Dim num8 As Double = 2.0 * Math.Atan2(Math.Sqrt(num7), Math.Sqrt(1.0 - num7))
        Return (6378.137 * num8) * 1000
        ' M
    End Function

End Class

'End Namespace
