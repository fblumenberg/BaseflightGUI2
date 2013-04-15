<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmError
    Inherits Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmError))
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.lblErrorHeading = New System.Windows.Forms.Label()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.lblSource = New System.Windows.Forms.Label()
        Me.txtSource = New System.Windows.Forms.TextBox()
        Me.lblStackTrace = New System.Windows.Forms.Label()
        Me.txtErrorText = New System.Windows.Forms.TextBox()
        Me.lblInnerException = New System.Windows.Forms.Label()
        Me.txtComment = New System.Windows.Forms.TextBox()
        Me.lblHelplink = New System.Windows.Forms.Label()
        Me.txtHelplink = New System.Windows.Forms.TextBox()
        Me.scMain = New System.Windows.Forms.SplitContainer()
        Me.cmdClipBoard = New System.Windows.Forms.Button()
        Me.KryptonPanel1 = New System.Windows.Forms.Panel()
        CType(Me.scMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scMain.Panel1.SuspendLayout()
        Me.scMain.Panel2.SuspendLayout()
        Me.scMain.SuspendLayout()
        Me.KryptonPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.Location = New System.Drawing.Point(372, 492)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(77, 25)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(457, 492)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(77, 25)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'lblErrorHeading
        '
        Me.lblErrorHeading.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorHeading.Location = New System.Drawing.Point(10, 6)
        Me.lblErrorHeading.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblErrorHeading.Name = "lblErrorHeading"
        Me.lblErrorHeading.Size = New System.Drawing.Size(197, 29)
        Me.lblErrorHeading.TabIndex = 1
        Me.lblErrorHeading.Text = "Sorry there is a error."
        '
        'txtMessage
        '
        Me.txtMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMessage.Location = New System.Drawing.Point(117, 34)
        Me.txtMessage.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.ReadOnly = True
        Me.txtMessage.Size = New System.Drawing.Size(403, 21)
        Me.txtMessage.TabIndex = 2
        '
        'lblMessage
        '
        Me.lblMessage.Location = New System.Drawing.Point(10, 34)
        Me.lblMessage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(59, 20)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.Text = "Message"
        '
        'lblSource
        '
        Me.lblSource.Location = New System.Drawing.Point(10, 61)
        Me.lblSource.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSource.Name = "lblSource"
        Me.lblSource.Size = New System.Drawing.Size(48, 20)
        Me.lblSource.TabIndex = 1
        Me.lblSource.Text = "Source"
        '
        'txtSource
        '
        Me.txtSource.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSource.Location = New System.Drawing.Point(117, 61)
        Me.txtSource.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.ReadOnly = True
        Me.txtSource.Size = New System.Drawing.Size(403, 21)
        Me.txtSource.TabIndex = 2
        '
        'lblStackTrace
        '
        Me.lblStackTrace.Location = New System.Drawing.Point(9, 6)
        Me.lblStackTrace.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStackTrace.Name = "lblStackTrace"
        Me.lblStackTrace.Size = New System.Drawing.Size(63, 20)
        Me.lblStackTrace.TabIndex = 1
        Me.lblStackTrace.Text = "Error Text"
        '
        'txtErrorText
        '
        Me.txtErrorText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtErrorText.Location = New System.Drawing.Point(112, 3)
        Me.txtErrorText.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtErrorText.Multiline = True
        Me.txtErrorText.Name = "txtErrorText"
        Me.txtErrorText.ReadOnly = True
        Me.txtErrorText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtErrorText.Size = New System.Drawing.Size(403, 235)
        Me.txtErrorText.TabIndex = 2
        '
        'lblInnerException
        '
        Me.lblInnerException.Location = New System.Drawing.Point(9, 3)
        Me.lblInnerException.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInnerException.Name = "lblInnerException"
        Me.lblInnerException.Size = New System.Drawing.Size(93, 20)
        Me.lblInnerException.TabIndex = 1
        Me.lblInnerException.Text = "Your Comment"
        '
        'txtComment
        '
        Me.txtComment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComment.Location = New System.Drawing.Point(112, 3)
        Me.txtComment.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComment.Size = New System.Drawing.Size(403, 117)
        Me.txtComment.TabIndex = 2
        '
        'lblHelplink
        '
        Me.lblHelplink.Location = New System.Drawing.Point(10, 88)
        Me.lblHelplink.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHelplink.Name = "lblHelplink"
        Me.lblHelplink.Size = New System.Drawing.Size(55, 20)
        Me.lblHelplink.TabIndex = 1
        Me.lblHelplink.Text = "Helplink"
        '
        'txtHelplink
        '
        Me.txtHelplink.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHelplink.Location = New System.Drawing.Point(117, 88)
        Me.txtHelplink.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtHelplink.Name = "txtHelplink"
        Me.txtHelplink.ReadOnly = True
        Me.txtHelplink.Size = New System.Drawing.Size(403, 21)
        Me.txtHelplink.TabIndex = 2
        '
        'scMain
        '
        Me.scMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.scMain.Location = New System.Drawing.Point(5, 118)
        Me.scMain.Name = "scMain"
        Me.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'scMain.Panel1
        '
        Me.scMain.Panel1.Controls.Add(Me.lblStackTrace)
        Me.scMain.Panel1.Controls.Add(Me.txtErrorText)
        '
        'scMain.Panel2
        '
        Me.scMain.Panel2.Controls.Add(Me.txtComment)
        Me.scMain.Panel2.Controls.Add(Me.lblInnerException)
        Me.scMain.Size = New System.Drawing.Size(529, 368)
        Me.scMain.SplitterDistance = 241
        Me.scMain.TabIndex = 3
        '
        'cmdClipBoard
        '
        Me.cmdClipBoard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdClipBoard.AutoSize = True
        Me.cmdClipBoard.Location = New System.Drawing.Point(5, 492)
        Me.cmdClipBoard.Name = "cmdClipBoard"
        Me.cmdClipBoard.Size = New System.Drawing.Size(75, 25)
        Me.cmdClipBoard.TabIndex = 4
        Me.cmdClipBoard.Text = "Clipboard"
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.lblHelplink)
        Me.KryptonPanel1.Controls.Add(Me.lblSource)
        Me.KryptonPanel1.Controls.Add(Me.lblMessage)
        Me.KryptonPanel1.Controls.Add(Me.lblErrorHeading)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(538, 527)
        Me.KryptonPanel1.TabIndex = 5
        '
        'frmError
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(538, 527)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.cmdClipBoard)
        Me.Controls.Add(Me.scMain)
        Me.Controls.Add(Me.txtHelplink)
        Me.Controls.Add(Me.txtSource)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmError"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Error"
        Me.TopMost = True
        Me.scMain.Panel1.ResumeLayout(False)
        Me.scMain.Panel1.PerformLayout()
        Me.scMain.Panel2.ResumeLayout(False)
        Me.scMain.Panel2.PerformLayout()
        CType(Me.scMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scMain.ResumeLayout(False)
        Me.KryptonPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As Button
    Friend WithEvents Cancel_Button As Button
    Friend WithEvents lblErrorHeading As Label
    Friend WithEvents txtMessage As TextBox
    Friend WithEvents lblMessage As Label
    Friend WithEvents lblSource As Label
    Friend WithEvents txtSource As TextBox
    Friend WithEvents lblStackTrace As Label
    Friend WithEvents txtErrorText As TextBox
    Friend WithEvents lblInnerException As Label
    Friend WithEvents txtComment As TextBox
    Friend WithEvents lblHelplink As Label
    Friend WithEvents txtHelplink As TextBox
    Friend WithEvents scMain As SplitContainer
    Friend WithEvents cmdClipBoard As Button
    Friend WithEvents KryptonPanel1 As Panel

End Class
