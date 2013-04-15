Module modCLI

    Public isCLI As Boolean = False
    Public cliBuffer As String = ""

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
            System.Threading.Thread.Sleep(500)
            serialPort.ReadExisting()
            isCLI = True
            serialPort.Write("#")
        End If
    End Sub

    Public Sub endcli()
        If isCLI = True Then
            If serialPort.IsOpen = True Then
                serialPort.Write("exit" & vbCrLf)
                serialPort.ReadExisting()
                isCLI = False
            Else
                'lostConnection()
                frmMain.setButtonsOffline()
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

        frmMain.cmdCLIList.Enabled = False
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
        frmMain.cmdCLIList.Enabled = False
        serialPort.Write(frmMain.txtCLICommand.Text + vbCrLf)
        cmdList.Add(frmMain.txtCLICommand.Text)
        cmdCount = cmdList.Count
        frmMain.txtCLICommand.Text = ""
    End Sub

    Private cmdList As New ArrayList()
    Private cmdCount As Integer = 0
    Public Sub CommandHistory()
        If cmdCount >= 0 Then
            cmdCount -= 1
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
            Next
        End If
    End Sub

    Private Sub tabPagePID_Click(sender As Object, e As EventArgs)

    End Sub

    Public Sub loadCLIFile()
        Dim fd As New OpenFileDialog()
        fd.InitialDirectory = sConfigFolder
        If fd.ShowDialog() = DialogResult.OK Then
            Dim filename As String = fd.FileName
            sConfigFolder = System.IO.Path.GetDirectoryName(filename)
            ini.Write("GUI", "ConfigFolder", sConfigFolder)
            Dim commands As String() = System.IO.File.ReadAllLines(filename)
            For Each command As String In commands
                serialPort.Write(command & vbCr & vbLf)
                'readCOM()
            Next
        End If
    End Sub

End Module
