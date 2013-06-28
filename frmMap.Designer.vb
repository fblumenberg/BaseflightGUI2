<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMap
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMap))
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSet = New System.Windows.Forms.Button()
        Me.rbAETR = New System.Windows.Forms.RadioButton()
        Me.rbERTA = New System.Windows.Forms.RadioButton()
        Me.rbTAER = New System.Windows.Forms.RadioButton()
        Me.cmbChannel2 = New System.Windows.Forms.ComboBox()
        Me.lblChannel1 = New System.Windows.Forms.Label()
        Me.lblChannel2 = New System.Windows.Forms.Label()
        Me.lblChannel3 = New System.Windows.Forms.Label()
        Me.lblChannel4 = New System.Windows.Forms.Label()
        Me.cmbChannel1 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbChannel3 = New System.Windows.Forms.ComboBox()
        Me.cmbChannel4 = New System.Windows.Forms.ComboBox()
        Me.lblMapping = New System.Windows.Forms.Label()
        Me.lblVMapping = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cmbChannel6 = New System.Windows.Forms.ComboBox()
        Me.cmbChannel7 = New System.Windows.Forms.ComboBox()
        Me.cmbChannel8 = New System.Windows.Forms.ComboBox()
        Me.lblChannel5 = New System.Windows.Forms.Label()
        Me.cmbChannel5 = New System.Windows.Forms.ComboBox()
        Me.lblChannel6 = New System.Windows.Forms.Label()
        Me.lblChannel7 = New System.Windows.Forms.Label()
        Me.lblChannel8 = New System.Windows.Forms.Label()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Location = New System.Drawing.Point(274, 262)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSet
        '
        Me.cmdSet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSet.Location = New System.Drawing.Point(355, 262)
        Me.cmdSet.Name = "cmdSet"
        Me.cmdSet.Size = New System.Drawing.Size(75, 23)
        Me.cmdSet.TabIndex = 3
        Me.cmdSet.Text = "Set"
        Me.cmdSet.UseVisualStyleBackColor = True
        '
        'rbAETR
        '
        Me.rbAETR.AutoSize = True
        Me.rbAETR.Location = New System.Drawing.Point(12, 12)
        Me.rbAETR.Name = "rbAETR"
        Me.rbAETR.Size = New System.Drawing.Size(117, 17)
        Me.rbAETR.TabIndex = 4
        Me.rbAETR.TabStop = True
        Me.rbAETR.Text = "AETR (Futaba/Jeti)"
        Me.rbAETR.UseVisualStyleBackColor = True
        '
        'rbERTA
        '
        Me.rbERTA.AutoSize = True
        Me.rbERTA.Location = New System.Drawing.Point(12, 35)
        Me.rbERTA.Name = "rbERTA"
        Me.rbERTA.Size = New System.Drawing.Size(96, 17)
        Me.rbERTA.TabIndex = 4
        Me.rbERTA.TabStop = True
        Me.rbERTA.Text = "ERTA (Futuba)"
        Me.rbERTA.UseVisualStyleBackColor = True
        '
        'rbTAER
        '
        Me.rbTAER.AutoSize = True
        Me.rbTAER.Location = New System.Drawing.Point(12, 58)
        Me.rbTAER.Name = "rbTAER"
        Me.rbTAER.Size = New System.Drawing.Size(158, 17)
        Me.rbTAER.TabIndex = 4
        Me.rbTAER.TabStop = True
        Me.rbTAER.Text = "TAER (Spektrum, Graupner)"
        Me.rbTAER.UseVisualStyleBackColor = True
        '
        'cmbChannel2
        '
        Me.cmbChannel2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbChannel2.FormattingEnabled = True
        Me.cmbChannel2.Items.AddRange(New Object() {"T=Throttle", "A=Aileron", "E=Elevator", "R=Ruder", "AUX 1", "AUX 2", "AUX 3", "AUX 4"})
        Me.cmbChannel2.Location = New System.Drawing.Point(84, 132)
        Me.cmbChannel2.Name = "cmbChannel2"
        Me.cmbChannel2.Size = New System.Drawing.Size(121, 21)
        Me.cmbChannel2.TabIndex = 5
        '
        'lblChannel1
        '
        Me.lblChannel1.AutoSize = True
        Me.lblChannel1.Location = New System.Drawing.Point(12, 108)
        Me.lblChannel1.Name = "lblChannel1"
        Me.lblChannel1.Size = New System.Drawing.Size(55, 13)
        Me.lblChannel1.TabIndex = 6
        Me.lblChannel1.Text = "Channel 1"
        '
        'lblChannel2
        '
        Me.lblChannel2.AutoSize = True
        Me.lblChannel2.Location = New System.Drawing.Point(12, 135)
        Me.lblChannel2.Name = "lblChannel2"
        Me.lblChannel2.Size = New System.Drawing.Size(55, 13)
        Me.lblChannel2.TabIndex = 6
        Me.lblChannel2.Text = "Channel 2"
        '
        'lblChannel3
        '
        Me.lblChannel3.AutoSize = True
        Me.lblChannel3.Location = New System.Drawing.Point(12, 162)
        Me.lblChannel3.Name = "lblChannel3"
        Me.lblChannel3.Size = New System.Drawing.Size(55, 13)
        Me.lblChannel3.TabIndex = 6
        Me.lblChannel3.Text = "Channel 3"
        '
        'lblChannel4
        '
        Me.lblChannel4.AutoSize = True
        Me.lblChannel4.Location = New System.Drawing.Point(12, 189)
        Me.lblChannel4.Name = "lblChannel4"
        Me.lblChannel4.Size = New System.Drawing.Size(55, 13)
        Me.lblChannel4.TabIndex = 6
        Me.lblChannel4.Text = "Channel 4"
        '
        'cmbChannel1
        '
        Me.cmbChannel1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbChannel1.FormattingEnabled = True
        Me.cmbChannel1.Items.AddRange(New Object() {"T=Throttle", "A=Aileron", "E=Elevator", "R=Ruder", "AUX 1", "AUX 2", "AUX 3", "AUX 4"})
        Me.cmbChannel1.Location = New System.Drawing.Point(84, 105)
        Me.cmbChannel1.Name = "cmbChannel1"
        Me.cmbChannel1.Size = New System.Drawing.Size(121, 21)
        Me.cmbChannel1.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(-147, 273)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Label1"
        '
        'cmbChannel3
        '
        Me.cmbChannel3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbChannel3.FormattingEnabled = True
        Me.cmbChannel3.Items.AddRange(New Object() {"T=Throttle", "A=Aileron", "E=Elevator", "R=Ruder", "AUX 1", "AUX 2", "AUX 3", "AUX 4"})
        Me.cmbChannel3.Location = New System.Drawing.Point(84, 159)
        Me.cmbChannel3.Name = "cmbChannel3"
        Me.cmbChannel3.Size = New System.Drawing.Size(121, 21)
        Me.cmbChannel3.TabIndex = 5
        '
        'cmbChannel4
        '
        Me.cmbChannel4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbChannel4.FormattingEnabled = True
        Me.cmbChannel4.Items.AddRange(New Object() {"T=Throttle", "A=Aileron", "E=Elevator", "R=Ruder", "AUX 1", "AUX 2", "AUX 3", "AUX 4"})
        Me.cmbChannel4.Location = New System.Drawing.Point(84, 186)
        Me.cmbChannel4.Name = "cmbChannel4"
        Me.cmbChannel4.Size = New System.Drawing.Size(121, 21)
        Me.cmbChannel4.TabIndex = 5
        '
        'lblMapping
        '
        Me.lblMapping.AutoSize = True
        Me.lblMapping.Location = New System.Drawing.Point(12, 225)
        Me.lblMapping.Name = "lblMapping"
        Me.lblMapping.Size = New System.Drawing.Size(48, 13)
        Me.lblMapping.TabIndex = 7
        Me.lblMapping.Text = "Mapping"
        '
        'lblVMapping
        '
        Me.lblVMapping.AutoSize = True
        Me.lblVMapping.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVMapping.Location = New System.Drawing.Point(81, 223)
        Me.lblVMapping.Name = "lblVMapping"
        Me.lblVMapping.Size = New System.Drawing.Size(81, 16)
        Me.lblVMapping.TabIndex = 7
        Me.lblVMapping.Text = "TAER1234"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'cmbChannel6
        '
        Me.cmbChannel6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbChannel6.FormattingEnabled = True
        Me.cmbChannel6.Items.AddRange(New Object() {"T=Throttle", "A=Aileron", "E=Elevator", "R=Ruder", "AUX 1", "AUX 2", "AUX 3", "AUX 4"})
        Me.cmbChannel6.Location = New System.Drawing.Point(309, 132)
        Me.cmbChannel6.Name = "cmbChannel6"
        Me.cmbChannel6.Size = New System.Drawing.Size(121, 21)
        Me.cmbChannel6.TabIndex = 5
        '
        'cmbChannel7
        '
        Me.cmbChannel7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbChannel7.FormattingEnabled = True
        Me.cmbChannel7.Items.AddRange(New Object() {"T=Throttle", "A=Aileron", "E=Elevator", "R=Ruder", "AUX 1", "AUX 2", "AUX 3", "AUX 4"})
        Me.cmbChannel7.Location = New System.Drawing.Point(309, 159)
        Me.cmbChannel7.Name = "cmbChannel7"
        Me.cmbChannel7.Size = New System.Drawing.Size(121, 21)
        Me.cmbChannel7.TabIndex = 5
        '
        'cmbChannel8
        '
        Me.cmbChannel8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbChannel8.FormattingEnabled = True
        Me.cmbChannel8.Items.AddRange(New Object() {"T=Throttle", "A=Aileron", "E=Elevator", "R=Ruder", "AUX 1", "AUX 2", "AUX 3", "AUX 4"})
        Me.cmbChannel8.Location = New System.Drawing.Point(309, 186)
        Me.cmbChannel8.Name = "cmbChannel8"
        Me.cmbChannel8.Size = New System.Drawing.Size(121, 21)
        Me.cmbChannel8.TabIndex = 5
        '
        'lblChannel5
        '
        Me.lblChannel5.AutoSize = True
        Me.lblChannel5.Location = New System.Drawing.Point(237, 108)
        Me.lblChannel5.Name = "lblChannel5"
        Me.lblChannel5.Size = New System.Drawing.Size(55, 13)
        Me.lblChannel5.TabIndex = 6
        Me.lblChannel5.Text = "Channel 5"
        '
        'cmbChannel5
        '
        Me.cmbChannel5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbChannel5.FormattingEnabled = True
        Me.cmbChannel5.Items.AddRange(New Object() {"T=Throttle", "A=Aileron", "E=Elevator", "R=Ruder", "AUX 1", "AUX 2", "AUX 3", "AUX 4"})
        Me.cmbChannel5.Location = New System.Drawing.Point(309, 105)
        Me.cmbChannel5.Name = "cmbChannel5"
        Me.cmbChannel5.Size = New System.Drawing.Size(121, 21)
        Me.cmbChannel5.TabIndex = 5
        '
        'lblChannel6
        '
        Me.lblChannel6.AutoSize = True
        Me.lblChannel6.Location = New System.Drawing.Point(237, 135)
        Me.lblChannel6.Name = "lblChannel6"
        Me.lblChannel6.Size = New System.Drawing.Size(55, 13)
        Me.lblChannel6.TabIndex = 6
        Me.lblChannel6.Text = "Channel 6"
        '
        'lblChannel7
        '
        Me.lblChannel7.AutoSize = True
        Me.lblChannel7.Location = New System.Drawing.Point(237, 162)
        Me.lblChannel7.Name = "lblChannel7"
        Me.lblChannel7.Size = New System.Drawing.Size(55, 13)
        Me.lblChannel7.TabIndex = 6
        Me.lblChannel7.Text = "Channel 7"
        '
        'lblChannel8
        '
        Me.lblChannel8.AutoSize = True
        Me.lblChannel8.Location = New System.Drawing.Point(237, 189)
        Me.lblChannel8.Name = "lblChannel8"
        Me.lblChannel8.Size = New System.Drawing.Size(55, 13)
        Me.lblChannel8.TabIndex = 6
        Me.lblChannel8.Text = "Channel 8"
        '
        'frmMap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(442, 297)
        Me.Controls.Add(Me.lblVMapping)
        Me.Controls.Add(Me.lblMapping)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblChannel8)
        Me.Controls.Add(Me.lblChannel4)
        Me.Controls.Add(Me.lblChannel7)
        Me.Controls.Add(Me.lblChannel3)
        Me.Controls.Add(Me.lblChannel6)
        Me.Controls.Add(Me.lblChannel2)
        Me.Controls.Add(Me.cmbChannel5)
        Me.Controls.Add(Me.cmbChannel1)
        Me.Controls.Add(Me.lblChannel5)
        Me.Controls.Add(Me.lblChannel1)
        Me.Controls.Add(Me.cmbChannel8)
        Me.Controls.Add(Me.cmbChannel7)
        Me.Controls.Add(Me.cmbChannel4)
        Me.Controls.Add(Me.cmbChannel6)
        Me.Controls.Add(Me.cmbChannel3)
        Me.Controls.Add(Me.cmbChannel2)
        Me.Controls.Add(Me.rbTAER)
        Me.Controls.Add(Me.rbERTA)
        Me.Controls.Add(Me.rbAETR)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSet)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMap"
        Me.Text = "Map"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdSet As System.Windows.Forms.Button
    Friend WithEvents rbAETR As System.Windows.Forms.RadioButton
    Friend WithEvents rbERTA As System.Windows.Forms.RadioButton
    Friend WithEvents rbTAER As System.Windows.Forms.RadioButton
    Friend WithEvents cmbChannel2 As System.Windows.Forms.ComboBox
    Friend WithEvents lblChannel1 As System.Windows.Forms.Label
    Friend WithEvents lblChannel2 As System.Windows.Forms.Label
    Friend WithEvents lblChannel3 As System.Windows.Forms.Label
    Friend WithEvents lblChannel4 As System.Windows.Forms.Label
    Friend WithEvents cmbChannel1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbChannel3 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbChannel4 As System.Windows.Forms.ComboBox
    Friend WithEvents lblMapping As System.Windows.Forms.Label
    Friend WithEvents lblVMapping As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblChannel8 As System.Windows.Forms.Label
    Friend WithEvents lblChannel7 As System.Windows.Forms.Label
    Friend WithEvents lblChannel6 As System.Windows.Forms.Label
    Friend WithEvents cmbChannel5 As System.Windows.Forms.ComboBox
    Friend WithEvents lblChannel5 As System.Windows.Forms.Label
    Friend WithEvents cmbChannel8 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbChannel7 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbChannel6 As System.Windows.Forms.ComboBox
End Class
