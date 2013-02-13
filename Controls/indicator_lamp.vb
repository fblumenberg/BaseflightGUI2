Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Text
Imports System.Data

Namespace BaseflightGUIControls
    Class indicator_lamp
        Inherits BaseflightControl
#Region "Fields"

        ' Parameters
        <Description("Indicator Color"), Category("Apperance"), DefaultValue(0), Browsable(True)> _
        Public Property indicator_color() As Integer
            Get
                Return m_indicator_color
            End Get
            Set(value As Integer)
                m_indicator_color = value
            End Set
        End Property

        Private m_indicator_color As Integer
        'Green default (1-red);
        <Description("Indicator Status"), Category("Apperance"), DefaultValue(False), Browsable(True)> _
        Public Property status() As Boolean
            Get
                Return m_status
            End Get
            Set(value As Boolean)
                m_status = value
            End Set
        End Property
        Private m_status As Boolean
        'off
        'No need for properties since it's overrided
        Public Overrides Property Text() As String
            Get
                Return m_Text
            End Get
            Set(value As String)
                m_Text = value
            End Set
        End Property
        Private m_Text As String

        ' Images

        Private bmpRedOff As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.i_red_off)
        Private bmpRedOn As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.i_red_on)
        Private bmpGreenOff As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.i_green_off)
        Private bmpGreenOn As New Bitmap(Global.BaseflightGUI.My.Resources.Resources.i_green_on)


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
            Me.Height = 17
            Me.Width = 50
        End Sub
#End Region

#Region "Paint"

        Protected Overrides Sub OnPaint(pe As PaintEventArgs)
            ' Calling the base class OnPaint
            MyBase.OnPaint(pe)

            Dim drawFont As New System.Drawing.Font(FontFamily.GenericMonospace, 8.0F)
            Dim drawBrushOrange As New System.Drawing.SolidBrush(System.Drawing.Color.Orange)
            Dim drawBrushWhite As New System.Drawing.SolidBrush(System.Drawing.Color.White)
            Dim drawBrushDim As New System.Drawing.SolidBrush(System.Drawing.Color.Gray)

            bmpRedOff.MakeTransparent(Color.Yellow)
            bmpRedOn.MakeTransparent(Color.Yellow)
            bmpGreenOff.MakeTransparent(Color.Yellow)
            bmpGreenOn.MakeTransparent(Color.Yellow)

            If indicator_color = 0 Then
                If status Then
                    pe.Graphics.DrawImageUnscaled(bmpGreenOn, 0, 0)
                Else
                    pe.Graphics.DrawImageUnscaled(bmpGreenOff, 0, 0)
                End If
            Else
                If status Then
                    pe.Graphics.DrawImageUnscaled(bmpRedOn, 0, 0)
                Else
                    pe.Graphics.DrawImageUnscaled(bmpRedOff, 0, 0)

                End If
            End If
            Dim stringSize As New SizeF()
            stringSize = pe.Graphics.MeasureString(Text, drawFont)
            If status Then
                If indicator_color = 0 Then
                    pe.Graphics.DrawString(Text, drawFont, drawBrushWhite, 1 + (48 - stringSize.Width) / 2, (15 - stringSize.Height) / 2)
                Else
                    pe.Graphics.DrawString(Text, drawFont, drawBrushOrange, 1 + (48 - stringSize.Width) / 2, (15 - stringSize.Height) / 2)
                End If
            Else
                pe.Graphics.DrawString(Text, drawFont, drawBrushDim, 1 + (48 - stringSize.Width) / 2, (15 - stringSize.Height) / 2)
            End If

            'Dispose objects
            drawFont.Dispose()
            drawBrushDim.Dispose()
            drawBrushOrange.Dispose()
            drawBrushWhite.Dispose()

        End Sub


#End Region

#Region "Methods"


        Public Sub SetStatus(value As Boolean)
            status = value
            frmMain.Refresh()
        End Sub



        Protected Overrides ReadOnly Property DefaultSize() As Size
            Get
                Return New Size(50, 17)
            End Get
        End Property

        Protected Overrides Sub SetBoundsCore(x As Integer, y As Integer, width As Integer, height As Integer, specified As BoundsSpecified)
            MyBase.SetBoundsCore(x, y, 50, 17, specified)
        End Sub


#End Region
    End Class
End Namespace
