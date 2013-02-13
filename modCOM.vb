Module modCOM
    Public sSerialSpeeds As String() = {"115200", "57600", "38400", "19200", "9600"}
    Public guiDefaultPort As String = "COM9"
    Public guiDefaultSerialSpeed As String = "115200"
    Public serialPort As IO.Ports.SerialPort

    Public isConnected As Boolean = False
    Public isRealtime As Boolean = False
    Public comError As Boolean = False
    Public inBuffer As Byte()

    Public Sub serial_ports_enumerate()
        'Enumerate all serial ports
        frmMain.cmdConnect.Enabled = True
        'Enable the connect button
        Dim ports As String() = IO.Ports.SerialPort.GetPortNames()
        frmMain.cmbCOMPort.Items.Clear()
        For Each port As String In ports
            frmMain.cmbCOMPort.Items.Add(port)
        Next
        frmMain.cmbCOMPort.SelectedIndex = frmMain.cmbCOMPort.FindStringExact(guiDefaultPort)

        'if prefered port is not available then select the first one 
        If frmMain.cmbCOMPort.Text = "" Then
            If frmMain.cmbCOMPort.Items.Count > 0 Then
                frmMain.cmbCOMPort.SelectedIndex = 0
            End If
        End If

        'Thisable connect button if there is no selected com port
        If frmMain.cmbCOMPort.Items.Count = 0 Then
            frmMain.cmdConnect.Enabled = False
        End If
    End Sub

    Public Sub initCOMPorts()
        serial_ports_enumerate()
        For Each speed As String In sSerialSpeeds
            frmMain.cmbCOMSpeed.Items.Add(speed)
        Next
        frmMain.cmbCOMSpeed.SelectedItem = guiDefaultSerialSpeed

        'Init serial port object
        serialPort = New IO.Ports.SerialPort()
        'Set up serial port parameters (at least the ones what we know upfront
        serialPort.DataBits = 8
        serialPort.Parity = IO.Ports.Parity.None
        serialPort.StopBits = IO.Ports.StopBits.One
        serialPort.Handshake = IO.Ports.Handshake.None
        serialPort.DtrEnable = False
        '??
        serialPort.ReadBufferSize = 4096        '4K byte of read buffer
        serialPort.ReadTimeout = 500            ' 500msec timeout;
        'serialPort.ReceivedBytesThreshold = 1

    End Sub

    Public Sub disconnectCOM()
        If isConnected = True Then
            frmMain.cmdConnect.Text = "Connect"
            frmMain.cmdConnect.Image = Global.BaseflightGUI.My.Resources.Resources.Link_Add_32_n_p
            isConnected = False
            frmMain.timerRealtime.Stop()                       ''Stop timer(s), whatever it takes
            serialPort.Close()
        End If
    End Sub

    Public Function connectCOM() As Boolean
        Dim result As Boolean = False
        comError = False
        frmMain.cmdConnect.Image = Global.BaseflightGUI.My.Resources.Resources.Link_Search_32_n_p
        frmMain.cmdConnect.Text = "Connecting"
        serialPort.PortName = frmMain.cmbCOMPort.Text
        serialPort.BaudRate = CInt(frmMain.cmbCOMSpeed.Text)
        Try
            serialPort.Open()
            serialPort.ReadExisting()
        Catch
            ''WRONG, it seems that the combobox selection pointed to a port which is no longer available
            MessageBox.Show("Please check that your USB cable is still connected." & vbCrLf & "After you press OK, Serial ports will be re-enumerated", "Error opening COM port", MessageBoxButtons.OK, MessageBoxIcon.Error)
            serial_ports_enumerate()
            frmMain.cmdConnect.Text = "Connect"
            frmMain.cmdConnect.Image = Global.BaseflightGUI.My.Resources.Resources.Link_Add_32_n_p
            Return False
        End Try

        ''We have to do it for a couple of times to ensure that we will have parameters loaded 
        Application.DoEvents()
        For i As Integer = 0 To 10
            MSPquery(MSP_BOXNAMES)
            readCOM()
            If comError = True Then
                result = False
                frmMain.cmdConnect.Text = "Connect"
                frmMain.cmdConnect.Image = Global.BaseflightGUI.My.Resources.Resources.Link_Add_32_n_p
                Exit For
            End If
            mw_gui = New baseflight_data_gui(iPidItems, iCheckBoxItems, iSoftwareVersion)
            mw_params = New mw_settings(iPidItems, iCheckBoxItems, iSoftwareVersion)
            If iCheckBoxItems > 0 Then
                frmMain.cmdConnect.Image = Global.BaseflightGUI.My.Resources.Resources.Link_Remove_32_n_p()
                frmMain.cmdConnect.Text = "Disconnect"
                isConnected = True
                result = True
                Exit For
            End If
        Next

        Return result
    End Function

    Public Sub lostConnection()
        comError = True
        MessageBox.Show("Please check that your USB cable is still connected.", "Error finding FlightControl", MessageBoxButtons.OK, MessageBoxIcon.Error)
        disconnectCOM()
    End Sub

    Public Sub readCOM()
        Try
            Dim bIsPortOpen As Boolean = serialPort.IsOpen
        Catch
            'Hmm, if this throws an exception it should mean that we have an issue here
            comError = True
            Return
        End Try

        If serialPort.IsOpen Then
            'Just process what is received. Get received commands and put them into 
            Try
                If isRealtime = False Then
                    Dim timeout As DateTime = Now
                    Do While serialPort.BytesToRead = 0 And comError = False
                        If Now > DateAdd(DateInterval.Second, 10, timeout) Then
                            comError = True
                        End If
                        Application.DoEvents()
                    Loop
                    System.Threading.Thread.Sleep(250)
                End If
                If comError = False Then
                    Try
                        If isCLI = True Then
                            System.Threading.Thread.Sleep(250)
                            cliBuffer = serialPort.ReadExisting()
                            'Do While serialPort.BytesToRead > 0
                            '    cliBuffer = cliBuffer & vbCrLf & serialPort.ReadLine
                            'Loop
                            AccessToTB()
                        Else
                            ReadMSP()
                        End If
                    Catch
                        'port not opened, (it could happen when U disconnect the usb cable while connected
                        'comError = true; //do nothing
                        'return;
                        lostConnection()
                    End Try
                Else
                    lostConnection()
                End If
            Catch ex As Exception
                lostConnection()
            End Try
        Else
            'port not opened, (it could happen when U disconnect the usb cable while connected
            lostConnection()
        End If
    End Sub

End Module
