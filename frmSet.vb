Public Class frmSet
    '# set *
    'Current settings: 
    'deadband = 10 0 32 0
    'yawdeadband = 15 0 100 0
    'alt_hold_throttle_neutral = 50 1 250 0
    'midrc = 1500 1200 1700 2
    'rc_rate = 100 0 250 0
    'rc_expo = 80 0 100 0
    'thr_mid = 50 0 100 0
    'thr_expo = 0 0 250 0
    'roll_pitch_rate = 0 0 100 0
    'yawrate = 0 0 100 0
    'd_level = 20 0 200 0
    'auxChannels = 8 4 14 0
    'SONAR_Pinout = 1 0 1 0
    'LED_Type = 2 0 3 0
    'LED_pinout = 1 0 1 0
    'LED_ControlChannel = 6 1 12 0
    'LED_ARMED = 1 0 1 0
    'LED_Toggle_Delay = 20 0 65535 2
    'LED_Pattern1 = 16711935 0 2147483647 4
    'LED_Pattern2 = 16711935 0 2147483647 4
    'LED_Pattern3 = 16711935 0 2147483647 4

    '# 

    Private Sub frmSet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            isCLI = False
            createDTSet()
            readDTSet()
        Catch ex As Exception
            frmError.lastCommand = "initTPMap()"
            frmError.myEx = ex
            If frmError.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                System.Windows.Forms.Application.Exit()
            End If
        End Try
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        isCLI = True
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub cmdSet_Click(sender As Object, e As EventArgs) Handles cmdSet.Click
        isCLI = True
        writeSet()
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Dim dtSet As New DataTable
    Dim bsSet As New BindingSource
    Private Sub createDTSet()
        Try
            If dtSet.Columns.Count > 0 Then Exit Sub
            Dim col As DataColumn
            col = New DataColumn("Item", GetType(System.String))
            dtSet.Columns.Add(col)
            col = New DataColumn("Value", GetType(System.String))
            dtSet.Columns.Add(col)
            col = New DataColumn("Min", GetType(System.String))
            dtSet.Columns.Add(col)
            col = New DataColumn("Max", GetType(System.String))
            dtSet.Columns.Add(col)
            col = New DataColumn("Type", GetType(System.String))
            dtSet.Columns.Add(col)
            col = New DataColumn("URL", GetType(System.String))
            dtSet.Columns.Add(col)
            col = New DataColumn("Description", GetType(System.String))
            dtSet.Columns.Add(col)
            dgSet.AutoGenerateColumns = False
            bsSet.DataSource = dtSet
            dgSet.DataSource = bsSet
            Me.colItem.DataPropertyName = "Item"
            Me.colValue.DataPropertyName = "Value"
            Me.colMin.DataPropertyName = "Min"
            Me.colMax.DataPropertyName = "Max"
            Me.colType.DataPropertyName = "Type"
            Me.colDescription.DataPropertyName = "Description"
            Me.colURL.DataPropertyName = "URL"
        Catch ex As Exception
            frmError.lastCommand = "initTPMap()"
            frmError.myEx = ex
            If frmError.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                System.Windows.Forms.Application.Exit()
            End If
        End Try
    End Sub

    Private Sub readDTSet()
        Try
            Dim setReady As Boolean = False
            Dim result As String = ""
            dtSet.Clear()
            serialPort.ReadExisting()
            serialPort.Write("SET *" & vbCr & vbLf)
            sleep(150)
            Do While setReady = False
                Do While serialPort.BytesToRead > 0
                    result = result & Chr(serialPort.ReadByte)
                Loop
                If result.Substring(result.Length - 3, 3).Contains("#") = True Then
                    setReady = True
                End If
                sleep(150)
            Loop
            '# set *
            'Current settings: 
            result = result.Replace("#", "").Trim
            result = result.Replace("SET *", "").Trim
            result = result.Replace("Current settings:", "").Trim
            result = result.Replace("  ", " ").Trim
            Dim setList() As String = Nothing
            setList = result.Split(vbCrLf)
            For i As Integer = 0 To setList.Length - 1
                Dim line As String = setList(i).Trim
                If line <> "" Then
                    Dim items() As String = line.Split(" ")
                    If items.Length > 2 Then
                        Dim newrow As DataRow = dtSet.NewRow
                        newrow("Item") = items(0)
                        newrow("Value") = items(2)
                        If items.Length > 3 Then
                            newrow("Min") = items(3)
                            newrow("Max") = items(4)
                            'VAR_UINT8,
                            'VAR_INT8,
                            'VAR_UINT16,
                            'VAR_INT16,
                            'VAR_UINT32,
                            'VAR_FLOAT
                            If items.Length > 5 Then
                                Select Case items(5)
                                    Case 0
                                        newrow("Type") = "UINT8"
                                    Case 1
                                        newrow("Type") = "INT8"
                                    Case 2
                                        newrow("Type") = "UINT16"
                                    Case 3
                                        newrow("Type") = "INT16"
                                    Case 4
                                        newrow("Type") = "UINT32"
                                    Case 5
                                        newrow("Type") = "FLOAT"
                                    Case Else
                                        newrow("Type") = "unknown"
                                End Select
                            Else
                                If items(2).Contains(".") Then
                                    newrow("Type") = "FLOAT"
                                Else
                                    newrow("Type") = "unknown"
                                End If
                            End If
                            newrow("Description") = getDescription(items(0).Trim, HelpType.cliSet)
                            newrow("URL") = getURL(items(0).Trim)
                            dtSet.Rows.Add(newrow)
                        Else
                            'Stop
                        End If
                    End If
                End If
            Next
            dtSet.AcceptChanges()
            If isNewOnlineItem = True Then
                saveOnlineHelp()
                isNewOnlineItem = False
            End If
        Catch ex As Exception
            frmError.lastCommand = "initTPMap()"
            frmError.myEx = ex
            If frmError.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                System.Windows.Forms.Application.Exit()
            End If
        End Try
    End Sub

    Private Function getURL(ByRef Item As String) As String
        Dim result As String = ""
        Dim dr() As DataRow = dtOnlineHelp.Select("Item like '" & Item & "' and Type = " & HelpType.cliSet & " and Language = '" & Language & "'")
        If dr.Length = 0 Then
            addEmptyRow(Item, 1, Language)
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

    Public Sub writeSet()
        For Each dr As DataRow In dtSet.Rows
            If dr.RowState = DataRowState.Modified Then
                Dim command As String = "SET " & dr("Item") & " = " & dr("Value")
                serialPort.Write(command & vbCr & vbLf)
                System.Threading.Thread.Sleep(200)
            End If
        Next
    End Sub

    Dim oldValue As Double
    Private Sub dgSet_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgSet.CellBeginEdit
        oldValue = dgSet.Item("colValue", e.RowIndex).Value
    End Sub

    Private Sub dgSet_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgSet.CellEndEdit
        Dim isError As Boolean = False
        If IsNumeric(dgSet.Item("colValue", e.RowIndex).Value) Then
            Dim value As Double = dgSet.Item("colValue", e.RowIndex).Value
            Dim min As Double = dgSet.Item("colMin", e.RowIndex).Value
            Dim max As Double = dgSet.Item("colMax", e.RowIndex).Value
            If min <= value And value <= max Then
                'Every think is fine
            Else
                isError = True
            End If
        Else
            isError = True
        End If
        If isError = True Then
            If dgSet.Item("colValue", e.RowIndex).Value = "FLOAT" Then
                dgSet.Item("colValue", e.RowIndex).Value = oldValue
            Else
                dgSet.Item("colValue", e.RowIndex).Value = CInt(oldValue)
            End If
        End If
    End Sub

    Private Sub dgSet_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgSet.CellMouseClick
        If e.RowIndex > -1 Then
            If e.ColumnIndex = 6 Then
                Dim url As String = ""
                url = Me.dgSet.Item("colURL", e.RowIndex).Value
                If url <> "" Then
                    Process.Start(url)
                End If
            End If
        End If
    End Sub

    Private Sub cmdGPS_Click(sender As Object, e As EventArgs) Handles cmdGPS.Click
        bsSet.Filter = "Item LIKE 'gps_%'"
    End Sub

    Private Sub cmdSONAR_Click(sender As Object, e As EventArgs) Handles cmdSONAR.Click
        bsSet.Filter = "item LIKE 'snr_%'"
    End Sub

    Private Sub cmdALL_Click(sender As Object, e As EventArgs) Handles cmdALL.Click
        bsSet.Filter = ""
    End Sub

    Private Sub cmdLED_Click(sender As Object, e As EventArgs) Handles cmdLED.Click
        bsSet.Filter = "Item LIKE 'LED%'"
    End Sub

    Private Sub cmdGimbal_Click(sender As Object, e As EventArgs) Handles cmdGimbal.Click
    End Sub

     Private Sub cmdPID_Click(sender As Object, e As EventArgs) Handles cmdPID.Click
        bsSet.Filter = "Item LIKE 'P_%' or Item LIKE 'I_%' or Item LIKE 'D_%'"
    End Sub

    Private Sub cmdAutoland_Click(sender As Object, e As EventArgs) Handles cmdAutoland.Click
        bsSet.Filter = "item LIKE 'al_%'"
    End Sub
End Class