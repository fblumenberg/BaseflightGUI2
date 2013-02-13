Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Text
Imports System.Data
Imports System.IO
Imports System.IO.Ports

Namespace BaseflightGUIControls


    Class StackPanel
        Inherits TabControl
        Protected Overrides Sub WndProc(ByRef m As Message)
            ' Hide tabs by trapping the TCM_ADJUSTRECT message 
            If m.Msg = &H1328 AndAlso Not DesignMode Then
                m.Result = CType(1, IntPtr)
            Else
                MyBase.WndProc(m)
            End If
        End Sub
    End Class



    ''' <summary>
    ''' Binary CheckBox control, for visually enhanced checkbox
    ''' </summary>
    Class CheckBoxEx
        Inherits CheckBox
        'class derived from the CheckBox class
        'init vars for OnPaint
        Private Shared lightgrayBrush As Brush = New SolidBrush(Color.DimGray)
        Private Shared grayBrush As Brush = New SolidBrush(Color.Gray)
        Private Shared lightgreenBrush As Brush = New SolidBrush(Color.LightGreen)
        Private Shared orangeBrush As Brush = New SolidBrush(Color.Orange)
        Private Shared orangePen As New Pen(orangeBrush, 1)

        Private h As Boolean

        Public Property IsHighlighted() As Boolean
            Get
                Return h
            End Get
            Set(value As Boolean)
                h = value
                Me.Refresh()
            End Set
        End Property
        '0 orange highlight around the box

        Public Property aux() As Integer
            Get
                Return m_aux
            End Get
            Set(value As Integer)
                m_aux = value
            End Set
        End Property

        Private m_aux As Integer
        Public Property rclevel() As Integer
            Get
                Return m_rclevel
            End Get
            Set(value As Integer)
                m_rclevel = value
            End Set
        End Property

        Private m_rclevel As Integer
        Public Property item() As Integer
            Get
                Return m_item
            End Get
            Set(value As Integer)
                m_item = value
            End Set
        End Property
        Private m_item As Integer

        'default constructor
        Public Sub New()
        End Sub

        'we only need to override the OnPaint method 
        'we do our own painting here
        Protected Overrides Sub OnPaint(pe As PaintEventArgs)
            MyBase.OnPaint(pe)
            'needed
            pe.Graphics.FillRectangle(grayBrush, 0, 0, 15, 14)
            pe.Graphics.FillRectangle(lightgrayBrush, 0, 0, 14, 13)

            If Me.Checked Then
                pe.Graphics.FillRectangle(lightgreenBrush, 0, 0, 14, 13)
            End If
            If h Then
                pe.Graphics.DrawRectangle(orangePen, 0, 0, 14, 13)
            End If
        End Sub

        Private Sub InitializeComponent()
            Me.SuspendLayout()
            Me.ResumeLayout(False)

        End Sub

    End Class
End Namespace

