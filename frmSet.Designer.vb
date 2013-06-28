<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSet
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSet))
        Me.dgSet = New System.Windows.Forms.DataGridView()
        Me.colItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colURL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSet = New System.Windows.Forms.Button()
        Me.cmdGPS = New System.Windows.Forms.Button()
        Me.cmdSONAR = New System.Windows.Forms.Button()
        Me.cmdALL = New System.Windows.Forms.Button()
        Me.cmdLED = New System.Windows.Forms.Button()
        Me.cmdGimbal = New System.Windows.Forms.Button()
        Me.cmdPID = New System.Windows.Forms.Button()
        Me.cmdAutoland = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.dgSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgSet
        '
        Me.dgSet.AllowUserToAddRows = False
        Me.dgSet.AllowUserToDeleteRows = False
        Me.dgSet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSet.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        Me.dgSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSet.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItem, Me.colValue, Me.colMin, Me.colMax, Me.colType, Me.colDescription, Me.colURL})
        Me.dgSet.Location = New System.Drawing.Point(12, 38)
        Me.dgSet.Name = "dgSet"
        Me.dgSet.RowHeadersWidth = 15
        Me.dgSet.Size = New System.Drawing.Size(609, 305)
        Me.dgSet.TabIndex = 0
        '
        'colItem
        '
        Me.colItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.colItem.DefaultCellStyle = DataGridViewCellStyle1
        Me.colItem.HeaderText = "Item"
        Me.colItem.Name = "colItem"
        Me.colItem.ReadOnly = True
        Me.colItem.Width = 52
        '
        'colValue
        '
        Me.colValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.colValue.DefaultCellStyle = DataGridViewCellStyle2
        Me.colValue.HeaderText = "Value"
        Me.colValue.Name = "colValue"
        Me.colValue.Width = 59
        '
        'colMin
        '
        Me.colMin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.colMin.DefaultCellStyle = DataGridViewCellStyle3
        Me.colMin.HeaderText = "Min"
        Me.colMin.Name = "colMin"
        Me.colMin.ReadOnly = True
        Me.colMin.Width = 49
        '
        'colMax
        '
        Me.colMax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.colMax.DefaultCellStyle = DataGridViewCellStyle4
        Me.colMax.HeaderText = "Max"
        Me.colMax.Name = "colMax"
        Me.colMax.ReadOnly = True
        Me.colMax.Width = 52
        '
        'colType
        '
        Me.colType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.colType.DefaultCellStyle = DataGridViewCellStyle5
        Me.colType.HeaderText = "Type"
        Me.colType.Name = "colType"
        Me.colType.ReadOnly = True
        Me.colType.Width = 56
        '
        'colDescription
        '
        Me.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDescription.DefaultCellStyle = DataGridViewCellStyle6
        Me.colDescription.HeaderText = "Description"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.ReadOnly = True
        '
        'colURL
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.colURL.DefaultCellStyle = DataGridViewCellStyle7
        Me.colURL.HeaderText = "URL"
        Me.colURL.Name = "colURL"
        Me.colURL.ReadOnly = True
        Me.colURL.Width = 50
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Location = New System.Drawing.Point(465, 349)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSet
        '
        Me.cmdSet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSet.Location = New System.Drawing.Point(546, 349)
        Me.cmdSet.Name = "cmdSet"
        Me.cmdSet.Size = New System.Drawing.Size(75, 23)
        Me.cmdSet.TabIndex = 3
        Me.cmdSet.Text = "Set"
        Me.cmdSet.UseVisualStyleBackColor = True
        '
        'cmdGPS
        '
        Me.cmdGPS.Location = New System.Drawing.Point(63, 9)
        Me.cmdGPS.Name = "cmdGPS"
        Me.cmdGPS.Size = New System.Drawing.Size(50, 23)
        Me.cmdGPS.TabIndex = 4
        Me.cmdGPS.Text = "GPS"
        Me.cmdGPS.UseVisualStyleBackColor = True
        '
        'cmdSONAR
        '
        Me.cmdSONAR.Location = New System.Drawing.Point(114, 9)
        Me.cmdSONAR.Name = "cmdSONAR"
        Me.cmdSONAR.Size = New System.Drawing.Size(50, 23)
        Me.cmdSONAR.TabIndex = 4
        Me.cmdSONAR.Text = "Sonar"
        Me.cmdSONAR.UseVisualStyleBackColor = True
        '
        'cmdALL
        '
        Me.cmdALL.Location = New System.Drawing.Point(12, 9)
        Me.cmdALL.Name = "cmdALL"
        Me.cmdALL.Size = New System.Drawing.Size(50, 23)
        Me.cmdALL.TabIndex = 4
        Me.cmdALL.Text = "*"
        Me.cmdALL.UseVisualStyleBackColor = True
        '
        'cmdLED
        '
        Me.cmdLED.Location = New System.Drawing.Point(165, 9)
        Me.cmdLED.Name = "cmdLED"
        Me.cmdLED.Size = New System.Drawing.Size(50, 23)
        Me.cmdLED.TabIndex = 4
        Me.cmdLED.Text = "LED"
        Me.cmdLED.UseVisualStyleBackColor = True
        '
        'cmdGimbal
        '
        Me.cmdGimbal.Location = New System.Drawing.Point(216, 9)
        Me.cmdGimbal.Name = "cmdGimbal"
        Me.cmdGimbal.Size = New System.Drawing.Size(50, 23)
        Me.cmdGimbal.TabIndex = 4
        Me.cmdGimbal.Text = "Gimbal"
        Me.cmdGimbal.UseVisualStyleBackColor = True
        '
        'cmdPID
        '
        Me.cmdPID.Location = New System.Drawing.Point(267, 9)
        Me.cmdPID.Name = "cmdPID"
        Me.cmdPID.Size = New System.Drawing.Size(50, 23)
        Me.cmdPID.TabIndex = 4
        Me.cmdPID.Text = "PID"
        Me.cmdPID.UseVisualStyleBackColor = True
        '
        'cmdAutoland
        '
        Me.cmdAutoland.Location = New System.Drawing.Point(318, 9)
        Me.cmdAutoland.Name = "cmdAutoland"
        Me.cmdAutoland.Size = New System.Drawing.Size(50, 23)
        Me.cmdAutoland.TabIndex = 4
        Me.cmdAutoland.Text = "AL"
        Me.cmdAutoland.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(369, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(50, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Sonar"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'frmSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 384)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdAutoland)
        Me.Controls.Add(Me.cmdPID)
        Me.Controls.Add(Me.cmdGimbal)
        Me.Controls.Add(Me.cmdLED)
        Me.Controls.Add(Me.cmdSONAR)
        Me.Controls.Add(Me.cmdALL)
        Me.Controls.Add(Me.cmdGPS)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSet)
        Me.Controls.Add(Me.dgSet)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSet"
        Me.Text = "Set"
        CType(Me.dgSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgSet As System.Windows.Forms.DataGridView
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdSet As System.Windows.Forms.Button
    Friend WithEvents colItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colURL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdGPS As System.Windows.Forms.Button
    Friend WithEvents cmdSONAR As System.Windows.Forms.Button
    Friend WithEvents cmdALL As System.Windows.Forms.Button
    Friend WithEvents cmdLED As System.Windows.Forms.Button
    Friend WithEvents cmdGimbal As System.Windows.Forms.Button
    Friend WithEvents cmdPID As System.Windows.Forms.Button
    Friend WithEvents cmdAutoland As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
