Module modCOM
    Public dtComPorts As New DataTable

    Public sSerialSpeeds As String() = {"115200", "57600", "38400", "19200", "9600"}
    Public guiDefaultPort As String = "COM9"
    Public guiDefaultSerialSpeed As String = "115200"
    Public serialPort As IO.Ports.SerialPort

    Public isConnected As Boolean = False
    Public isRealtime As Boolean = False
    Public comError As Boolean = False
    Public gpsBuffer As Byte()
    Public comTimeOut As Integer = 500

    Public isBluetooth As Boolean = False
    Public Timeout As Integer = 10
    Public USBTimeout As Integer = 10
    Public BluetoothTimeout As Integer = 10
    Public RebootTimeout As Integer = 120
    Public fcCount As Integer = 1
    Public LastReceived As DateTime = Now

    Public Sub timeoutError()
        If serialPort.BytesToRead > 0 Then
            serialPort.DiscardInBuffer()
        End If
        frmMain.timerRealtime.Stop()
        comError = True
        isConnected = False
        MessageBox.Show(frmMain, lngTimeOut.Replace("{sec}", Timeout), lngError, MessageBoxButtons.OK, MessageBoxIcon.Error)
        disconnectCOM()
    End Sub

    Public Sub createDtComPorts()
        If dtComPorts.Columns.Count = 0 Then
            Dim col As DataColumn
            col = New DataColumn("Port", GetType(System.String))
            dtComPorts.Columns.Add(col)
            col = New DataColumn("Description", GetType(System.String))
            dtComPorts.Columns.Add(col)
            dtComPorts.TableName = "ComPorts"
        End If
    End Sub

    Public Sub serial_ports_enumerate()
        createDtComPorts()
        'Enumerate all serial ports
        frmMain.cmdConnect.Enabled = True
        'Enable the connect button
        Dim ports As String() = IO.Ports.SerialPort.GetPortNames()
        dtComPorts.Clear()
        For Each port As String In ports
            Dim newRow As DataRow = dtComPorts.NewRow
            newRow("Port") = port
            newRow("Description") = getAddPortInformation(port)
            dtComPorts.Rows.Add(newRow)
        Next
        frmMain.cmbCOMPort.ComboBox.DataSource = dtComPorts
        frmMain.cmbCOMPort.ComboBox.DisplayMember = "Description"
        frmMain.cmbCOMPort.ComboBox.ValueMember = "Port"

        frmMain.cmbCOMPort.ComboBox.SelectedValue = guiDefaultPort

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

    Private Function getAddPortInformation(ByVal port As String) As String
        Dim result As String = port
        Dim searcher As New Management.ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_PnPEntity")
        For Each queryObj As Management.ManagementObject In searcher.Get()
            If InStr(queryObj("Caption"), "(" & port & ")") > 0 Then
                'For Each po As Management.PropertyData In queryObj.Properties
                '    Debug.Write(po.Name & " - " & cccString(po.Value) & vbCrLf)
                'Next
                result = port & "  - " & queryObj("Description")
                Exit For
            End If
        Next
        Return result
    End Function

    Private Function cccString(ByVal value As Object) As String
        Dim result As String = ""
        If IsNothing(value) = False Then
            result = value.ToString
        End If
        Return result
    End Function

    Public Sub initCOMPorts()
        isStartup = True
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
        serialPort.RtsEnable = False
        '??
        serialPort.ReadBufferSize = 8 * 1024            ' 8K byte of read buffer
        serialPort.ReadTimeout = comTimeOut * 1000      ' 500msec timeout;
        isStartup = False
    End Sub

    Public Sub disconnectCOM()
        frmMain.timerRealtime.Stop()                       ''Stop timer(s), whatever it takes
        If serialPort.IsOpen = True Then
            serialPort.DiscardInBuffer()
            Dim CloseDown As New Threading.Thread(New Threading.ThreadStart(AddressOf CloseSerialOnExit))
            'close port in new thread to avoid hang
            CloseDown.Start()
            'close port in new thread to avoid hang
        End If
        frmMain.cmdConnect.Text = "Connect"
        frmMain.cmdConnect.Image = Global.BaseflightGUI.My.Resources.Resources.Link_Add_32_n_p
        If isConnected = True Then
            isConnected = False
        End If
        frmMain.setButtons(False)
        isConnected = False
        serial_packet_count = 0
        frmMain.lblVPacketReceived.Text = serial_packet_count
    End Sub

    Private Sub CloseSerialOnExit()
        Try
            serialPort.Close()
        Catch ex As Exception

        End Try
    End Sub

    Public Function connectCOM() As Boolean
        Dim result As Boolean = False
        comError = False
        frmMain.cmdConnect.Image = Global.BaseflightGUI.My.Resources.Resources.Link_Search_32_n_p
        frmMain.cmdConnect.Text = "Connecting"
        If serialPort.IsOpen = False Then
            serialPort.PortName = frmMain.cmbCOMPort.ComboBox.SelectedValue
            serialPort.BaudRate = CInt(frmMain.cmbCOMSpeed.Text)
            Try
                isConnected = True
                serialPort.Open()
                serialPort.ReadExisting()
            Catch
                ''WRONG, it seems that the combobox selection pointed to a port which is no longer available
                MessageBox.Show(frmMain, "Please check that your USB cable is still connected." & vbCrLf & "After you press OK, Serial ports will be re-enumerated", "Error opening COM port", MessageBoxButtons.OK, MessageBoxIcon.Error)
                serial_ports_enumerate()
                frmMain.cmdConnect.Text = "Connect"
                frmMain.cmdConnect.Image = Global.BaseflightGUI.My.Resources.Resources.Link_Add_32_n_p
                Return False
            End Try
        End If
        ''We have to do it for a couple of times to ensure that we will have parameters loaded 
        Application.DoEvents()
        Try
            serialPort.WriteTimeout = 1000 * 15
            serialPort.Write("Exit" & vbCrLf)
            serialPort.ReadExisting()
            For i As Integer = 0 To 10
                MSPquery(MSP_BOXNAMES)
                readCOM()
                If comError = True Then
                    result = False
                    frmMain.cmdConnect.Text = "Connect"
                    frmMain.cmdConnect.Image = Global.BaseflightGUI.My.Resources.Resources.Link_Add_32_n_p
                    Exit For
                End If
                mw_params = New mw_settings(iPidItems, iCheckBoxItems, iSoftwareVersion)
                If iCheckBoxItems > 0 Then
                    frmMain.cmdConnect.Image = Global.BaseflightGUI.My.Resources.Resources.Link_Remove_32_n_p()
                    frmMain.cmdConnect.Text = "Disconnect"
                    isConnected = True
                    result = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            lostConnection()
        End Try
        Return result
    End Function

    Public Sub lostConnection()
        Try
            frmMain.timerRealtime.Stop()
            comError = True
            isConnected = False
            MessageBox.Show(frmMain, "Please check that your USB cable is still connected.", "Error finding FlightControl", MessageBoxButtons.OK, MessageBoxIcon.Error)
            disconnectCOM()
        Catch ex As Exception

        End Try
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
                    Dim startTime As DateTime = Now
                    Do While serialPort.BytesToRead = 0 And comError = False
                        If Now > DateAdd(DateInterval.Second, Timeout, starttime) Then
                            comError = True
                        End If
                        Application.DoEvents()
                    Loop
                    System.Threading.Thread.Sleep(250)
                    frmMain.lblRealtimeWarning.Visible = False
                    frmMain.lblMapWarning.Visible = False
                    frmMain.lblRCWarning.Visible = False
                    frmMain.lblParameterWarning.Visible = False
                End If
                If comError = False Then
                    Try
                        If Timeout = RebootTimeout Then
                            If fcCount > 0 Then
                                fcCount -= 1
                            Else
                                If isBluetooth = False Then
                                    Timeout = USBTimeout
                                Else
                                    Timeout = BluetoothTimeout
                                End If
                            End If
                        End If
                        ReadMSP()
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

    Public Sub readBaseflightBasics()
        sUID = "???"
        MSPquery(MSP_UID)
        readCOM()
        If comError = True Then Exit Sub
        frmMain.lblVUID.Text = sUID
        frmMain.updateStatus()

        MSPquery(MSP_IDENT)
        readCOM()
        If comError = True Then Exit Sub
        updateParameterIdent()

        MSPquery(MSP_RC)
        readCOM()
        If comError = True Then Exit Sub
        frmMain.updateStatus()

        MSPquery(MSP_BOXNAMES)
        readCOM()
        If comError = True Then Exit Sub
        frmMain.updateStatus()

        If mw_gui.version >= 220 Then
            MSPquery(MSP_BOXIDS)
            readCOM()
            If comError = True Then Exit Sub
            frmMain.updateStatus()
        Else
            Dim BOXIDS(iCheckBoxItems - 1) As Integer
            For i As Integer = 0 To iCheckBoxItems - 1
                BOXIDS(i) = i
            Next
            iBoxIdents = BOXIDS
        End If

        MSPquery(MSP_BOX)
        readCOM()
        If comError = True Then Exit Sub
        frmMain.lblVPacketReceived.Text = serial_packet_count
        frmMain.lblVPacketError.Text = serial_error_count
        Application.DoEvents()
        If cfgBoxWidth = 4 Then
            If AUX_CHANNELS >= 8 Then
                boxAUX_CHANNELS = 8
            Else
                boxAUX_CHANNELS = AUX_CHANNELS
            End If
        Else
            boxAUX_CHANNELS = 4
        End If
        frmMain.updateStatus()


        frmMain.initRCChannel()
        create_aux_panal()
        frmMain.initRealtimeChannel()
        initIndicatorLamps()

        MSPquery(MSP_MOTOR)
        readCOM()
        If comError = True Then Exit Sub
        frmMain.Motor.SetMotorsIndicatorParameters(mw_gui.motors, mw_gui.servos, mw_gui.multiType)
        frmMain.updateStatus()

        MSPquery(MSP_SERVO)
        readCOM()
        If comError = True Then Exit Sub
        'ToDo Servos must be done
        frmMain.updateStatus()

        MSPquery(MSP_FIRMWARE)
        readCOM()
        If comError = True Then Exit Sub
        frmMain.lblVParameterBaseflightVersion.Text = mw_gui.firmware
        frmMain.updateStatus()

    End Sub

End Module
