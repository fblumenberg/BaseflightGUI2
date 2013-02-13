Module modCLI

    Public isCLI As Boolean = False
    Public cliBuffer As String = ""

    Public Sub AccessToTB()
        If frmMain.txtCLIResult.InvokeRequired Then
            frmMain.txtCLIResult.BeginInvoke(New MethodInvoker(AddressOf AccessToTB))
            Return
        End If
        frmMain.txtCLIResult.AppendText(cliBuffer)
    End Sub

    Public Sub startCLI()
        serialPort.ReadExisting()
        isCLI = True
        serialPort.Write("#")
    End Sub

    Public Sub endcli()
        If isCLI = True Then
            serialPort.Write("exit" & vbCrLf)
            serialPort.ReadExisting()
            isCLI = False
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
        If fd.ShowDialog() = DialogResult.OK Then
            Dim filename As String = fd.FileName
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
        If fd.ShowDialog() = DialogResult.OK Then
            Dim filename As String = fd.FileName
            Dim commands As String() = System.IO.File.ReadAllLines(filename)
            For Each command As String In commands
                serialPort.Write(command & vbCr & vbLf)
                'readCOM()
            Next
        End If
    End Sub

    Public Sub saveCLI()
        serialPort.Write("Save" & vbCr & vbLf)
        System.Threading.Thread.Sleep(5000)
        serialPort.Write(vbCrLf)
        startCLI()
    End Sub

    '{ "cmix", "design custom mixer", cliCMix },
    '{ "mixer", "mixer name or list", cliMixer },

End Module
