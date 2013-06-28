Module modCLI

    Public isCLI As Boolean = False
    Public cliBuffer As String = ""

    Public Function filterIncomingBuffer(ByVal value As String) As String
        Dim result As String = ""
        result = value.Replace(Chr(32) & "[1D", "")
        Return result
    End Function

    Public Sub AccessToTB()
        Try
            If frmMain.txtCLIResult.InvokeRequired Then
                frmMain.txtCLIResult.BeginInvoke(New MethodInvoker(AddressOf AccessToTB))
                Return
            End If
            frmMain.txtCLIResult.AppendText(cliBuffer)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub startCLI()
        If serialPort.IsOpen = True Then
            System.Threading.Thread.Sleep(1000)
            Do While serialPort.BytesToRead > 0
                serialPort.ReadExisting()
            Loop
            serialPort.ReadExisting()
            serialPort.DiscardInBuffer()
            isCLI = True
            serialPort.Write("#")
        End If
        frmMain.txtCLICommand.Focus()
    End Sub

    Public Sub endcli()
        If isCLI = True Then
            If serialPort.IsOpen = True Then
                serialPort.Write("exit" & vbCrLf)
                'serialPort.DiscardInBuffer()
                'isCLI = False
                System.Threading.Thread.Sleep(500)
            Else
                'lostConnection()
                frmMain.setButtons(False)
            End If
        End If
    End Sub

    Private Sub setCLICmdDefault()
        frmMain.cmdCLIDefaults.Enabled = True
        frmMain.cmdCLIFeature.Enabled = True
        frmMain.cmdCLIHelp.Enabled = True
        frmMain.cmdCLILoad.Enabled = True
        frmMain.cmdCLIMap.Enabled = True
        frmMain.cmdCLISave.Enabled = True
        frmMain.cmdCLISet.Enabled = True
        frmMain.cmdCLIStatus.Enabled = True
        frmMain.cmdCLIVersion.Enabled = True
    End Sub

    Public Sub setCLICmdEnterCommand()
        frmMain.cmdCLIDefaults.Enabled = False
        frmMain.cmdCLIFeature.Enabled = False
        frmMain.cmdCLIHelp.Enabled = False
        frmMain.cmdCLILoad.Enabled = False
        frmMain.cmdCLIMap.Enabled = False
        frmMain.cmdCLISave.Enabled = False
        frmMain.cmdCLISet.Enabled = False
        frmMain.cmdCLIStatus.Enabled = False
        frmMain.cmdCLIVersion.Enabled = False
    End Sub

    Public Sub CLISendComamand()
        setCLICmdDefault()
        Dim Command As String = frmMain.txtCLICommand.Text + vbCrLf
        serialPort.Write(Command)
        cmdList.Add(Command)
        cmdCount = cmdList.Count
        frmMain.txtCLICommand.Text = ""
        'Dim doReboot As Boolean = False
        'If Command.ToUpper.StartsWith("SAVE") = True Then
        '    doReboot = True
        'ElseIf Command.ToUpper.StartsWith("DEFAULT") = True Then
        '    doReboot = True
        'End If

        'If doReboot = True Then
        '    frmReboot.StartPosition = FormStartPosition.Manual
        '    frmReboot.Location = New System.Drawing.Point(frmMain.Location.X + (frmMain.Width - frmReboot.Width) / 2, frmMain.Location.Y + (frmMain.Height - frmReboot.Height) / 2)
        '    frmReboot.Show()
        'End If

    End Sub

    Private cmdList As New ArrayList()
    Private cmdCount As Integer = -1
    Public Sub CommandHistory()
        If cmdCount >= 0 Then
            If cmdCount > 0 Then cmdCount -= 1
            frmMain.txtCLICommand.Text = TryCast(cmdList(cmdCount), String)
        End If
    End Sub

    Private Sub cmdLoad_Click(sender As Object, e As EventArgs)
        Dim fd As New OpenFileDialog()
        fd.InitialDirectory = sConfigFolder
        If fd.ShowDialog() = DialogResult.OK Then
            Dim filename As String = fd.FileName
            sConfigFolder = System.IO.Path.GetDirectoryName(fd.FileName)
            ini.Write("GUI", "WayPointFolder", sWayPointFolder)
            Dim commands As String() = System.IO.File.ReadAllLines(filename)
            For Each command As String In commands
                serialPort.Write(command & vbCr & vbLf)
                System.Threading.Thread.Sleep(200)
            Next
        End If
    End Sub

    Private Sub tabPagePID_Click(sender As Object, e As EventArgs)

    End Sub

    Friend lngReady As String = "Ready"
    Public Sub loadCLIFile()
        Dim isError As Boolean = False
        serialPort.ReadExisting()
        Dim fd As New OpenFileDialog()
        fd.InitialDirectory = sConfigFolder
        If fd.ShowDialog() = DialogResult.OK Then
            isCLI = False
            Dim filename As String = fd.FileName
            sConfigFolder = System.IO.Path.GetDirectoryName(filename)
            ini.Write("GUI", "ConfigFolder", sConfigFolder)
            Dim commands As String() = System.IO.File.ReadAllLines(filename)
            For I As Integer = 0 To commands.Length - 1
                'For Each command As String In commands
                If commands(I).Length > 0 Then
                    If commands(I).Substring(0, 1) <> ";" Then
                        If isConnected = False Then
                            isError = True
                            Exit For
                        End If
                        serialPort.Write(commands(I) & vbCr & vbLf)
                        'frmMain.txtCLIResult.AppendText(commands(I) & vbCr & vbLf)
                        System.Threading.Thread.Sleep(cliLoadSleep)
                        Dim buffer As String = serialPort.ReadExisting
                        frmMain.txtCLIResult.AppendText(filterIncomingBuffer(buffer) & vbCr & vbLf)
                    End If
                End If
                ' If I = commands.Length - 2 Then Stop
            Next
            isCLI = True
        End If
        If isError = True Then
            frmMain.txtCLIResult.AppendText(vbCrLf & "Error importing settings" & vbCrLf)
        Else
            frmMain.txtCLIResult.AppendText(vbCrLf & lngReady & vbCrLf)
        End If
    End Sub

End Module
