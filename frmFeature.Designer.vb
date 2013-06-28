<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFeature
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFeature))
        Me.dgFeature = New System.Windows.Forms.DataGridView()
        Me.colChecked = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colFeature = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colURL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdSet = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        CType(Me.dgFeature, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgFeature
        '
        Me.dgFeature.AllowUserToAddRows = False
        Me.dgFeature.AllowUserToDeleteRows = False
        Me.dgFeature.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgFeature.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        Me.dgFeature.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFeature.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colChecked, Me.colFeature, Me.colDescription, Me.colURL})
        Me.dgFeature.Location = New System.Drawing.Point(12, 12)
        Me.dgFeature.Name = "dgFeature"
        Me.dgFeature.RowHeadersVisible = False
        Me.dgFeature.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgFeature.Size = New System.Drawing.Size(568, 482)
        Me.dgFeature.TabIndex = 0
        '
        'colChecked
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.NullValue = False
        Me.colChecked.DefaultCellStyle = DataGridViewCellStyle1
        Me.colChecked.HeaderText = "Checked"
        Me.colChecked.Name = "colChecked"
        Me.colChecked.Width = 22
        '
        'colFeature
        '
        Me.colFeature.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.colFeature.DefaultCellStyle = DataGridViewCellStyle2
        Me.colFeature.HeaderText = "Feature"
        Me.colFeature.Name = "colFeature"
        Me.colFeature.ReadOnly = True
        Me.colFeature.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colFeature.Width = 68
        '
        'colDescription
        '
        Me.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDescription.DefaultCellStyle = DataGridViewCellStyle3
        Me.colDescription.HeaderText = "Description"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colURL
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.colURL.DefaultCellStyle = DataGridViewCellStyle4
        Me.colURL.HeaderText = "URL"
        Me.colURL.Name = "colURL"
        Me.colURL.ReadOnly = True
        Me.colURL.Width = 30
        '
        'cmdSet
        '
        Me.cmdSet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSet.Location = New System.Drawing.Point(505, 500)
        Me.cmdSet.Name = "cmdSet"
        Me.cmdSet.Size = New System.Drawing.Size(75, 23)
        Me.cmdSet.TabIndex = 1
        Me.cmdSet.Text = "Set"
        Me.cmdSet.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Location = New System.Drawing.Point(424, 500)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'frmFeature
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 535)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSet)
        Me.Controls.Add(Me.dgFeature)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmFeature"
        Me.Text = "Feature"
        CType(Me.dgFeature, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgFeature As System.Windows.Forms.DataGridView
    Friend WithEvents cmdSet As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents colChecked As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colFeature As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colURL As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
