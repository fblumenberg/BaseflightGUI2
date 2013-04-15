Module modFirmwareUpdate

    Public firmwareFile As String = ""
    Public STMFlashLoader As String = ""

    Public Sub initFirmwareUpdate()
        If isStartup = True Then Exit Sub
        Dim openComPort As Boolean = False
        frmMain.LoadingCircle.Visible = False
        firmwareFile = frmMain.txtFirmwareFile.Text
        STMFlashLoader = Application.StartupPath & "\STMFlashLoader.exe"
        ini.Write("GUI", "FirmwareShowOutput", frmMain.chkFWShowOutput.Checked)
        If System.IO.File.Exists(firmwareFile) = True And System.IO.File.Exists(STMFlashLoader) = True Then
            frmMain.cmdFWUpdate.Enabled = True
        Else
            frmMain.cmdFWUpdate.Enabled = False
        End If
    End Sub

    Public Sub readFirmwareFile()
        Dim ofdLoadParameters As New OpenFileDialog()
        ofdLoadParameters.Filter = "Baseflight Firmware File|*.hex"
        ofdLoadParameters.Title = "Load Firmware"
        ofdLoadParameters.InitialDirectory = sFirmwareFolder
        If ofdLoadParameters.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            'we have file to open
            frmMain.txtFirmwareFile.Text = ofdLoadParameters.FileName
            If sFirmwareFolder <> System.IO.Path.GetDirectoryName(ofdLoadParameters.FileName) Then
                sFirmwareFolder = System.IO.Path.GetDirectoryName(ofdLoadParameters.FileName)
                ini.Write("GUI", "FirmwareFolder", sFirmwareFolder)
            End If
        End If
        initFirmwareUpdate()
    End Sub

    Public Sub updateFirmware()
        Dim result As Integer = 0
        frmMain.LoadingCircle.Visible = True
        frmMain.LoadingCircle.Active = True
        Application.DoEvents()
        frmMain.lblFWError.Visible = False
        frmMain.lblFWSuccessful.Visible = False
        If frmMain.chkFWSendR.Checked = True Then
            If serialPort.IsOpen = False Then
                serialPort.PortName = frmMain.cmbCOMPort.Text
                serialPort.BaudRate = CInt(frmMain.cmbCOMSpeed.Text)
                serialPort.Open()
                serialPort.ReadExisting()
            End If
            serialPort.Write("R")
            System.Threading.Thread.Sleep(2000)
        End If
        If serialPort.IsOpen = True Then
            serialPort.Close()
        End If
        Dim Arguments As String = ""
        Arguments = Arguments & " -c --pn " & serialPort.PortName.Replace("COM", "") & " --br " & serialPort.BaudRate & " --db 8"
        Arguments = Arguments & " -i STM32_Med-density_128K"
        Arguments = Arguments & " -e --all"
        Arguments = Arguments & " -d --fn """ & firmwareFile & """"
        Arguments = Arguments & " -r --a 0x8000000"

        Dim myProcess As System.Diagnostics.Process = Nothing
        Dim processStartInfo As System.Diagnostics.ProcessStartInfo
        processStartInfo = New System.Diagnostics.ProcessStartInfo()
        'msiexec als zu startendes Programm und die Parameter lauten Bspw. /a C:\Install.MSI /quiet
        processStartInfo.FileName = STMFlashLoader
        processStartInfo.Arguments = Arguments
        processStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
        processStartInfo.UseShellExecute = False
        processStartInfo.CreateNoWindow = Not frmMain.chkFWShowOutput.Checked
        'processStartInfo.RedirectStandardOutput = True
        'processStartInfo.RedirectStandardError = True
        Try
            myProcess = System.Diagnostics.Process.Start(processStartInfo)
            Do
                If Not myProcess.HasExited Then
                    ' Refresh the current process property values.
                    myProcess.Refresh()

                    If myProcess.Responding Then
                        'Console.WriteLine("Status = Running")


                        ' Display the results.
                    Else
                        Console.WriteLine("Status = Not Responding")
                    End If
                End If
                Application.DoEvents()
            Loop While Not myProcess.WaitForExit(1000)
            result = myProcess.ExitCode
            If result = 0 Then
                frmMain.lblFWSuccessful.Visible = True
            Else
                frmMain.lblFWError.Visible = True
            End If
        Catch ex As Exception

        Finally
            If Not (myProcess Is Nothing) Then
                myProcess.Dispose()
            End If
        End Try
        System.Threading.Thread.Sleep(5000)
        frmMain.LoadingCircle.Visible = False
        frmMain.LoadingCircle.Active = False

        connectCOM()
        readBaseflightBasics()
        'readSettings()
    End Sub

End Module
