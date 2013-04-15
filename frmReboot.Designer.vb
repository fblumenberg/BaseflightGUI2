<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReboot
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReboot))
        Me.lblReboot = New System.Windows.Forms.Label()
        Me.timerCountdown = New System.Windows.Forms.Timer(Me.components)
        Me.lblCountdown = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblReboot
        '
        Me.lblReboot.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblReboot.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReboot.ForeColor = System.Drawing.Color.Red
        Me.lblReboot.Location = New System.Drawing.Point(3, 33)
        Me.lblReboot.Name = "lblReboot"
        Me.lblReboot.Size = New System.Drawing.Size(608, 94)
        Me.lblReboot.TabIndex = 0
        Me.lblReboot.Text = "The FlightControl is rebooting now." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please wait!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblReboot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'timerCountdown
        '
        '
        'lblCountdown
        '
        Me.lblCountdown.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCountdown.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountdown.ForeColor = System.Drawing.Color.Red
        Me.lblCountdown.Location = New System.Drawing.Point(3, 127)
        Me.lblCountdown.Name = "lblCountdown"
        Me.lblCountdown.Size = New System.Drawing.Size(608, 78)
        Me.lblCountdown.TabIndex = 0
        Me.lblCountdown.Text = "5"
        Me.lblCountdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmReboot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 257)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblCountdown)
        Me.Controls.Add(Me.lblReboot)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReboot"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Rebooting"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblReboot As System.Windows.Forms.Label
    Friend WithEvents timerCountdown As System.Windows.Forms.Timer
    Friend WithEvents lblCountdown As System.Windows.Forms.Label
End Class
