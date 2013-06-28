Public Class frmMixer

    Private Sub frmMixer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isCLI = False
        createDT()
        createForm()
    End Sub

    Dim dt As New DataTable
    Private Sub createDT()
        If dt.Columns.Count = 0 Then
            Dim col As DataColumn
            col = New DataColumn("Checked", GetType(System.Boolean))
            dt.Columns.Add(col)
            col = New DataColumn("Mixer", GetType(System.String))
            dt.Columns.Add(col)
            col = New DataColumn("Description", GetType(System.String))
            dt.Columns.Add(col)
            col = New DataColumn("URL", GetType(System.String))
            dt.Columns.Add(col)
            dgMixer.AutoGenerateColumns = False
            dgMixer.DataSource = dt
            Me.colChecked.DataPropertyName = "Checked"
            Me.colFeature.DataPropertyName = "Mixer"
            Me.colDescription.DataPropertyName = "Description"
            Me.colURL.DataPropertyName = "URL"
        End If
    End Sub

    Private Sub createForm()
        dt.Clear()
        serialPort.Write("Mixer ?" & vbCr & vbLf)
        System.Threading.Thread.Sleep(200)
        Dim mixerSet As String = filterIncomingBuffer(serialPort.ReadExisting)

        serialPort.Write("Mixer List" & vbCr & vbLf)
        System.Threading.Thread.Sleep(200)
        Dim result As String = filterIncomingBuffer(serialPort.ReadExisting)
        '# mixer list
        'Available mixers: TRI QUADP QUADX BI GIMBAL Y6 HEX6 FLYING_WING Y4 HEX6X OCTOX8 OCTOFLATP OCTOFLATX AIRPLANE HELI_120_CCPM HELI_90_DEG VTAIL4 CUSTOM
        result = result.Replace("#", "").Trim
        result = result.Replace("Mixer List", "").Trim
        result = result.Replace("Available mixers:", "").Trim
        Dim mixerList() As String = Nothing
        If result.Contains(vbCrLf) Then
            mixerList = result.Split(vbCrLf)
        Else
            mixerList = result.Split(" ")
        End If
        For Each item As String In mixerList
            Dim newrow As DataRow = dt.NewRow
            newrow("Mixer") = item.Trim
            newrow("Description") = getDescription(item.Trim, HelpType.cliMixer)
            newrow("URL") = getURL(item.Trim)
            If mixerSet.Contains(item.Trim) = True Then
                newrow("Checked") = True
            Else
                newrow("Checked") = False
            End If
            dt.Rows.Add(newrow)
        Next
        If isNewOnlineItem = True Then
            saveOnlineHelp()
            isNewOnlineItem = False
        End If
    End Sub

    Private Function getURL(ByRef Item As String) As String
        Dim result As String = ""
        Dim dr() As DataRow = dtOnlineHelp.Select("Item like '" & Item.Trim & "' and Type = " & HelpType.cliMixer & " and Language = '" & Language & "'")
        If dr.Length = 0 Then
            addEmptyRow(Item, HelpType.cliMixer, Language)
            isNewOnlineItem = True
        Else
            Try
                result = dr(0)("URL")
            Catch ex As Exception
                dr(0)("URL") = ""
            End Try
        End If
        Return result
    End Function

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        isCLI = True
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub cmdSet_Click(sender As Object, e As EventArgs) Handles cmdSet.Click
        isCLI = True
        For Each dr As DataRow In dt.Rows
            Dim command As String = ""
            If dr("Checked") = True Then
                command = "Mixer " & dr("Mixer").trim
                serialPort.Write(command & vbCr & vbLf)
                System.Threading.Thread.Sleep(200)
            End If
        Next
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub dgMixer_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgMixer.CellContentClick
        Dim i As Integer = 0
        For Each dr In dt.Rows
            If i <> e.RowIndex Then
                dr("Checked") = False
            End If
            i += 1
        Next
    End Sub

    Private Sub dgMixer_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgMixer.CellMouseClick
        If e.RowIndex > -1 Then
            If e.ColumnIndex = 3 Then
                Dim url As String = ""
                url = Me.dgMixer.Item("colURL", e.RowIndex).Value
                If url <> "" Then
                    Process.Start(url)
                End If
            End If
        End If
    End Sub

End Class