Public Class frmMap
    Dim map As String = ""
    Dim mapstr() As Char = {"T", "A", "E", "R", "1", "2,", "3", "4"}

    Private Sub frmMap_Load(sender As Object, e As EventArgs) Handles Me.Load
        isCLI = False
        createForm()
    End Sub

    Private Sub cmdSet_Click(sender As Object, e As EventArgs) Handles cmdSet.Click
        isCLI = True
        serialPort.Write("Map " & map & vbCr & vbLf)
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        isCLI = True
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub createForm()
        map = filterIncomingBuffer(serialPort.ReadExisting)
        serialPort.Write("Map" & vbCr & vbLf)
        System.Threading.Thread.Sleep(400)
        map = filterIncomingBuffer(serialPort.ReadExisting)
        map = map.Replace("#", "").Trim
        map = map.Replace("Map", "").Trim
        map = map.Replace("Current assignment:", "").Trim
        setCMB()
    End Sub

    Dim isStartup As Boolean = False
    Private Sub setCMB()
        isStartup = True
        Dim mapping As String = "TAER1234"
        If map.Length > 7 Then
            cmbChannel1.SelectedIndex = mapping.IndexOf(map.Substring(0, 1))
            cmbChannel2.SelectedIndex = mapping.IndexOf(map.Substring(1, 1))
            cmbChannel3.SelectedIndex = mapping.IndexOf(map.Substring(2, 1))
            cmbChannel4.SelectedIndex = mapping.IndexOf(map.Substring(3, 1))
            cmbChannel5.SelectedIndex = mapping.IndexOf(map.Substring(4, 1))
            cmbChannel6.SelectedIndex = mapping.IndexOf(map.Substring(5, 1))
            cmbChannel7.SelectedIndex = mapping.IndexOf(map.Substring(6, 1))
            cmbChannel8.SelectedIndex = mapping.IndexOf(map.Substring(7, 1))
        End If
        readCMB()
        isStartup = False
    End Sub

    Private Sub readCMB()
        isError = False
        For Each ctrl As Control In ErrorProvider1.ContainerControl.Controls
            If ErrorProvider1.GetError(ctrl) <> "" Then
                isError = True
            End If
        Next
        If isError = False Then
            map = mapstr(cmbChannel1.SelectedIndex)
            map = map & mapstr(cmbChannel2.SelectedIndex)
            map = map & mapstr(cmbChannel3.SelectedIndex)
            map = map & mapstr(cmbChannel4.SelectedIndex)
            map = map & mapstr(cmbChannel5.SelectedIndex)
            map = map & mapstr(cmbChannel6.SelectedIndex)
            map = map & mapstr(cmbChannel7.SelectedIndex)
            map = map & mapstr(cmbChannel8.SelectedIndex)
            lblVMapping.Text = map
            Me.cmdSet.Enabled = True
        Else
            lblVMapping.Text = "Error"
            Me.cmdSet.Enabled = False
        End If
    End Sub

    Private Sub rbEATR_CheckedChanged(sender As Object, e As EventArgs) Handles rbAETR.CheckedChanged
        If rbAETR.Checked = True Then
            map = "AETR1234"
            setCMB()
        End If
    End Sub

    Private Sub rbERTA_CheckedChanged(sender As Object, e As EventArgs) Handles rbERTA.CheckedChanged
        If rbERTA.Checked = True Then
            map = "ERTA1234"
            setCMB()
        End If
    End Sub

    Private Sub rbTAER_CheckedChanged(sender As Object, e As EventArgs) Handles rbTAER.CheckedChanged
        If rbTAER.Checked = True Then
            map = "TAER1234"
            setCMB()
        End If
    End Sub

    Dim isError As Boolean = False
    Private Sub cmbChannel1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbChannel1.SelectedIndexChanged, cmbChannel2.SelectedIndexChanged, cmbChannel3.SelectedIndexChanged, cmbChannel4.SelectedIndexChanged, cmbChannel8.SelectedIndexChanged, cmbChannel7.SelectedIndexChanged, cmbChannel6.SelectedIndexChanged, cmbChannel5.SelectedIndexChanged
        If isStartup = True Then Exit Sub
        ErrorProvider1.Clear()
        Dim id As Integer = -1
        id = cmbChannel1.SelectedIndex
        For i1 As Integer = 1 To 8
            id = DirectCast(Controls("cmbChannel" & i1), ComboBox).SelectedIndex()
            For i2 As Integer = 1 To 8
                If i2 <> i1 Then
                    If id = DirectCast(Controls("cmbChannel" & i2), ComboBox).SelectedIndex() Then
                        ErrorProvider1.SetError(DirectCast(Controls("cmbChannel" & i2), ComboBox), "Error")
                        ErrorProvider1.SetError(DirectCast(Controls("cmbChannel" & i1), ComboBox), "Error")
                    End If
                End If
            Next
        Next
        readCMB()
    End Sub

End Class