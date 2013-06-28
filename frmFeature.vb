Public Class frmFeature

    Private Sub frmFeature_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            col = New DataColumn("Feature", GetType(System.String))
            dt.Columns.Add(col)
            col = New DataColumn("Description", GetType(System.String))
            dt.Columns.Add(col)
            col = New DataColumn("URL", GetType(System.String))
            dt.Columns.Add(col)
            dgFeature.AutoGenerateColumns = False
            dgFeature.DataSource = dt
            Me.colChecked.DataPropertyName = "Checked"
            Me.colFeature.DataPropertyName = "Feature"
            Me.colDescription.DataPropertyName = "Description"
            Me.colURL.DataPropertyName = "URL"
        End If
    End Sub

    Private Sub createForm()
        dt.Clear()
        serialPort.Write("Feature" & vbCr & vbLf)
        System.Threading.Thread.Sleep(200)
        Dim featureSet As String = filterIncomingBuffer(serialPort.ReadExisting)

        serialPort.Write("Feature List" & vbCr & vbLf)
        System.Threading.Thread.Sleep(200)
        Dim result As String = filterIncomingBuffer(serialPort.ReadExisting)
        result = result.Replace("#", "").Trim
        result = result.Replace("Feature List", "").Trim
        result = result.Replace("Available features:", "").Trim
        Dim featureList() As String = Nothing
        If result.Contains(vbCrLf) Then
            featureList = result.Split(vbCrLf)
        Else
            featureList = result.Split(" ")
        End If
        For i As Integer = 0 To featureList.Length - 1
            If featureList(i).ToUpper.Trim <> "PASS" Then
                Dim newrow As DataRow = dt.NewRow
                newrow("Feature") = featureList(i)
                newrow("Description") = getDescription(featureList(i).Trim, HelpType.cliFeature)
                newrow("URL") = getURL(featureList(i).Trim)
                If featureSet.Contains(featureList(i).Trim) = True Then
                    newrow("Checked") = True
                Else
                    newrow("Checked") = False
                End If
                dt.Rows.Add(newrow)
            End If
        Next
        If isNewOnlineItem = True Then
            saveOnlineHelp()
            isNewOnlineItem = False
        End If
    End Sub

    Private Function getURL(ByRef Item As String) As String
        Dim result As String = ""
        Dim dr() As DataRow = dtOnlineHelp.Select("Item like '" & Item & "' and Type = " & HelpType.cliFeature & " and Language = '" & Language & "'")
        If dr.Length = 0 Then
            addEmptyRow(Item, 2, Language)
            isNewOnlineItem = True
        Else
            Try
                result = dr(0)("URL")
            Catch ex As Exception
                dr(0)("URL") = ""
                isNewOnlineItem = True
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
                command = "Feature " & dr("Feature").trim
            Else
                command = "Feature -" & dr("Feature").trim
            End If
            serialPort.Write(command & vbCr & vbLf)
            System.Threading.Thread.Sleep(200)
        Next
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub dgFeature_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgFeature.CellMouseClick
        If e.RowIndex > -1 Then
            If e.ColumnIndex = 3 Then
                Dim url As String = ""
                url = Me.dgFeature.Item(e.ColumnIndex, e.RowIndex).Value
                If url <> "" Then
                    Process.Start(url)
                End If
            End If
        End If
    End Sub

End Class