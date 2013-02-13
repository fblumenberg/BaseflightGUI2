Public Class frmMain


    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tabMain.TabPages.Remove(tpGUISettings)
        readGUISettings()
        initCOMPorts()
        initRealtime()
        setButtonsOffline()
        inBuf = New Byte(299) {}
        inBuffer = New Byte(299) {}
        AddHandler serialPort.DataReceived, AddressOf DataReceivedHandler
    End Sub

    Private Sub cmdRefreshCOM_Click(sender As Object, e As EventArgs) Handles cmdRefreshCOM.Click
        initCOMPorts()
    End Sub

    Private Sub cmbCOMSpeed_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCOMSpeed.SelectedIndexChanged
        ini.Write("COM", "DefaultSerialSpeed", Me.cmbCOMSpeed.SelectedItem)
    End Sub

    Private Sub cmbCOMPort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCOMPort.SelectedIndexChanged
        ini.Write("COM", "DefaultPort", Me.cmbCOMPort.SelectedItem)
    End Sub

    Private Sub cmdConnect_Click(sender As Object, e As EventArgs) Handles cmdConnect.Click

        If serialPort.IsOpen = True Then
            If isCLI = True Then
                serialPort.Write("exit" & vbCrLf)
                serialPort.ReadExisting()
                isCLI = False
            End If
            disconnectCOM()
            setButtonsOffline()
        Else
            setButtonsOnline()
            If connectCOM() = True Then
                readBaseflightBasics()
                readSettings()
                fillParameter2GUI()
            Else
                setButtonsOffline()
            End If
        End If
    End Sub

    Private Sub cmdReadSettings_Click(sender As Object, e As EventArgs) Handles cmdReadSettings.Click
        readSettings()
        fillParameter2GUI()
    End Sub

    Private Sub cmdWriteSettings_Click(sender As Object, e As EventArgs) Handles cmdWriteSettings.Click
        writeSettings()
    End Sub

    Private Sub cmdResetSettings_Click(sender As Object, e As EventArgs) Handles cmdResetSettings.Click
        MSPquery(MSP_RESET_CONF)
        System.Threading.Thread.Sleep(1000)
        readSettings()
    End Sub

    Private Sub cmdSaveSettings_Click(sender As Object, e As EventArgs) Handles cmdSaveSettings.Click
        fillGUI2Parameter()
        'Move values from GUI to the settings object
        Dim sfdSaveParameters As New SaveFileDialog()
        sfdSaveParameters.Filter = "MultiWii Settings File|*.mws"
        sfdSaveParameters.Title = "Save parameters to file"
        'sfdSaveParameters.InitialDirectory = gui_settings.sSettingsFolder
        Dim invalidChars As String = System.Text.RegularExpressions.Regex.Escape(New String(IO.Path.GetInvalidFileNameChars()))
        Dim invalidReStr As String = String.Format("[{0} ]+", invalidChars)
        Dim fn As String = System.Text.RegularExpressions.Regex.Replace(txtComment.Text, invalidReStr, "_")
        fn = fn & [String].Format("{0:yymmdd-hhmm}", DateTime.Now)
        sfdSaveParameters.FileName = fn
        sfdSaveParameters.ShowDialog()
        If sfdSaveParameters.FileName <> "" Then
            mw_params.save_to_xml(sfdSaveParameters.FileName)
        End If
    End Sub

    Private Sub cmdLoadSettings_Click(sender As Object, e As EventArgs) Handles cmdLoadSettings.Click
        Dim ofdLoadParameters As New OpenFileDialog()
        ofdLoadParameters.Filter = "MultiWii Settings File|*.mws"
        ofdLoadParameters.Title = "Load parameters from file"
        'ofdLoadParameters.InitialDirectory = gui_settings.sSettingsFolder
        If ofdLoadParameters.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            'we have file to open
            If mw_params.read_from_xml(ofdLoadParameters.FileName) Then
                fillParameter2GUI()
            End If
        End If
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        If isCLI = True Then
            endcli()
        End If
        disconnectCOM()
        End
    End Sub

    Private Sub readSettings()
        MSPquery(MSP_BOX)
        readCOM()
        MSPquery(MSP_RC)
        readCOM()
        MSPquery(MSP_PID)
        readCOM()
        MSPquery(MSP_RC_TUNING)
        readCOM()
        MSPquery(MSP_IDENT)
        readCOM()
        MSPquery(MSP_MISC)
        readCOM()
        fillParameter2GUI()
    End Sub

    Private Sub writeSettings()
        timerRealtime.Stop()
        System.Threading.Thread.Sleep(500)
        fillGUI2Parameter()
        mw_params.write_settings(serialPort)

        '    mw_params.write_settings(serialPort);
        System.Threading.Thread.Sleep(1000)

        readSettings()
        fillParameter2GUI()
        System.Threading.Thread.Sleep(500)
        setTimer()
    End Sub

    Private Sub tabMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabMain.SelectedIndexChanged
        setTimer()
    End Sub

    Private Sub setTimer()
        timerRealtime.Stop()
        isRealtime = False
        If tabMain.SelectedTab Is tpParameter Then
            timerRealtime.Stop()
            endcli()
        ElseIf tabMain.SelectedTab Is tpRCSetting Then
            endcli()
            If isConnected = True Then
                isRealtime = True
                timerRealtime.Start()
            End If
        ElseIf tabMain.SelectedTab Is tpRealtime Then
            endcli()
            If isConnected = True Then
                isRealtime = True
                timerRealtime.Start()
            End If
        ElseIf tabMain.SelectedTab Is tpCLI Then
            timerRealtime.Stop()
            startCLI()
        ElseIf tabMain.SelectedTab Is tpGUISettings Then
            timerRealtime.Stop()
            endcli()
        End If
    End Sub

    Private Sub setButtonsOnline()
        cmbCOMPort.Enabled = False
        cmbCOMSpeed.Enabled = False
        cmdRefreshCOM.Enabled = False
        cmdReadSettings.Enabled = True
        cmdWriteSettings.Enabled = True
        cmdResetSettings.Enabled = True
        cmdSaveSettings.Enabled = True
        cmdLoadSettings.Enabled = True
        cmdCalibrateMag.Enabled = True
        cmdCalibrateAcc.Enabled = True
    End Sub

    Private Sub setButtonsOffline()
        cmbCOMPort.Enabled = True
        cmbCOMSpeed.Enabled = True
        cmdRefreshCOM.Enabled = True
        cmdReadSettings.Enabled = False
        cmdResetSettings.Enabled = False
        cmdWriteSettings.Enabled = False
        cmdSaveSettings.Enabled = False
        cmdLoadSettings.Enabled = False
        cmdCalibrateMag.Enabled = False
        cmdCalibrateAcc.Enabled = False
    End Sub

    Private Sub readBaseflightBasics()
        MSPquery(MSP_RC)
        readCOM()
        MSPquery(MSP_BOXNAMES)
        readCOM()
        MSPquery(MSP_BOX)
        readCOM()
        If cfgBoxWidth = 4 Then
            If AUX_CHANNELS >= 8 Then
                boxAUX_CHANNELS = 8
            Else
                boxAUX_CHANNELS = AUX_CHANNELS
            End If
        Else
            boxAUX_CHANNELS = 4
        End If
        initAUXChannel()
        initRealtimeChannel()
        create_aux_panal()
        MSPquery(MSP_IDENT)
        readCOM()
        MSPquery(MSP_MOTOR)
        readCOM()
        MSPquery(MSP_SERVO)
        readCOM()
        Me.Motor.SetMotorsIndicatorParameters(mw_gui.motors, mw_gui.servos, mw_gui.multiType)

        setTimer()
        Dim i As Long = serial_error_count
    End Sub

    Private Sub updateGUI()
        If tabMain.SelectedTab Is tpParameter Then
            fillParameter2GUI()
        ElseIf tabMain.SelectedTab Is tpRCSetting Then
            fillParameter2GUI()
        ElseIf tabMain.SelectedTab Is tpRealtime Then
            updateTPRealtime()
        ElseIf tabMain.SelectedTab Is tpCLI Then

        ElseIf tabMain.SelectedTab Is tpGUISettings Then

        End If
    End Sub

#Region "tpParameter"

    Private Sub tbrRCExpo_Scroll(sender As Object, e As EventArgs) Handles tbrRCExpo.Scroll
        RCExpo_Scroll()
    End Sub

    Private Sub trbRCRate_Scroll(sender As Object, e As EventArgs) Handles trbRCRate.Scroll
        RCRate_Scroll()
    End Sub

    Private Sub numRCExpo_ValueChanged(sender As Object, e As EventArgs) Handles numRCExpo.ValueChanged, numPowerMeterAlarm.ValueChanged
        RCExpo_ValueChanged()
    End Sub

    Private Sub numRCRate_ValueChanged(sender As Object, e As EventArgs) Handles numRCRate.ValueChanged
        RCRate_ValueChanged()
    End Sub

    Private Sub trbTMID_Scroll(sender As Object, e As EventArgs) Handles trbTMID.Scroll
        TMID_Scroll()
    End Sub

    Private Sub trbTEXPO_Scroll(sender As Object, e As EventArgs) Handles trbTEXPO.Scroll
        TEXPO_Scroll()
    End Sub

    Private Sub numTMID_ValueChanged(sender As Object, e As EventArgs) Handles numTMID.ValueChanged
        TMID_ValueChanged()
    End Sub

    Private Sub numTEXPO_ValueChanged(sender As Object, e As EventArgs) Handles numTEXPO.ValueChanged
        TEXPO_ValueChanged()
    End Sub

#End Region

    Private Sub cmbRefreshRate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRefreshRate.SelectedIndexChanged
        Me.timerRealtime.Interval = iRefreshIntervals(Me.cmbRefreshRate.SelectedIndex)
        ini.Write("GUI", "DefaultRate", Me.cmbRefreshRate.SelectedItem)
    End Sub

    Private Sub timerRealtime_Tick(sender As Object, e As EventArgs) Handles timerRealtime.Tick
        If comError = False Then
            If tabMain.SelectedTab Is tpRCSetting Then
                MSPquery(MSP_RC)
                readCOM()
                updateAUXChannels()
                updateRCControlSettings()
            ElseIf tabMain.SelectedTab Is tpRealtime Then
                askForRealtimeValues()
                updateTPRealtime()
            End If
            Me.lblVPacketReceived.Text = serial_packet_count
            Me.lblVPacketError.Text = serial_error_count
        Else
            timerRealtime.Stop()
        End If
    End Sub

#Region "CLI"

    Private Sub cmdClearScreen_Click(sender As Object, e As EventArgs) Handles cmdCLIClearScreen.Click
        Me.txtCLIResult.Text = ""
    End Sub

    Private Sub cmdHelp_Click(sender As Object, e As EventArgs) Handles cmdCLIHelp.Click, cmdCLIClearScreen.Click
        serialPort.Write("Help" & vbCr & vbLf)
    End Sub

    Private Sub cmdVersion_Click(sender As Object, e As EventArgs) Handles cmdCLIVersion.Click
        serialPort.Write("Version" & vbCr & vbLf)
    End Sub

    Private Sub cmdStatus_Click(sender As Object, e As EventArgs) Handles cmdCLIStatus.Click
        serialPort.Write("status" & vbCr & vbLf)
    End Sub

    Private Sub cmdDefaults_Click(sender As Object, e As EventArgs) Handles cmdCLIDefaults.Click
        serialPort.Write("Defaults" & vbCr & vbLf)
    End Sub

    Private Sub cmdMap_Click(sender As Object, e As EventArgs) Handles cmdCLIMap.Click
        Static lastclick As Double = 0
        Dim ThisClick As Double = DateAndTime.Timer
        If ThisClick > lastclick + 0.5 Then
            Me.lblCLIHelp.Text = "Help: T=Throttle A=Aileron E=Elevator R=Ruder / Example: MAP TAER1234"
            Me.txtCLICommand.AppendText("Map")
        Else
            Me.txtCLICommand.Text = ""
            serialPort.Write("Map" & vbCr & vbLf)
        End If
        lastclick = DateAndTime.Timer
    End Sub

    Private Sub cmdFeature_Click(sender As Object, e As EventArgs) Handles cmdCLIFeature.Click
        Static lastclick As Double = 0
        Dim ThisClick As Double = DateAndTime.Timer
        If ThisClick > lastclick + 0.5 Then
            Me.txtCLICommand.AppendText("Feature")
            Me.cmdCLIList.Enabled = True
            setCLICmdEnterCommand()
        Else
            Me.txtCLICommand.Text = ""
            serialPort.Write("Feature" & vbCr & vbLf)
        End If
        lastclick = DateAndTime.Timer
    End Sub

    Private Sub cmdSet_Click(sender As Object, e As EventArgs) Handles cmdCLISet.Click
        Static lastclick As Double = 0
        Dim ThisClick As Double = DateAndTime.Timer
        If ThisClick > lastclick + 0.5 Then
            Me.txtCLICommand.AppendText("Set")
            setCLICmdEnterCommand()
        Else
            Me.txtCLICommand.Text = ""
            serialPort.Write("Set" & vbCr & vbLf)
        End If
        lastclick = DateAndTime.Timer
    End Sub

    Private Sub cmdList_Click(sender As Object, e As EventArgs) Handles cmdCLIList.Click
        Me.txtCLICommand.AppendText(" LIST")
        CLISendComamand()
    End Sub

    Private Sub cmdLoad_Click(sender As Object, e As EventArgs) Handles cmdCLILoad.Click
        loadCLIFile()
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdCLISave.Click
        saveCLI()
    End Sub

    Private Sub cmdCLISend_Click(sender As Object, e As EventArgs) Handles cmdCLISend.Click
        CLISendComamand()
    End Sub

    Private Sub txtCLICommand_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCLICommand.KeyDown
        If e.KeyCode = Keys.Enter Then
            CLISendComamand()
        ElseIf e.KeyCode = (Keys.Control Or Keys.E) Then
            CommandHistory()
        End If
    End Sub

    Delegate Sub ShowRDataCallback(ByVal Text As String)
    Private Sub DataReceivedHandler(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs)
        If isRealtime = True Then
            readCOM()
        End If
        If isCLI = True Then
            System.Threading.Thread.Sleep(200)
            Do While serialPort.BytesToRead > 0
                cliBuffer = serialPort.ReadExisting()
                'cliBuffer = Str(serialPort.ReadByte)
                Dim MyDelegate As New ShowRDataCallback(AddressOf ShowRData)
                Me.txtCLIResult.Invoke(MyDelegate, cliBuffer)
            Loop
        End If
    End Sub

    Private Sub ShowRData(ByVal Text As String)
        Me.txtCLIResult.AppendText(Text)
        Me.txtCLIResult.ScrollToCaret()
    End Sub

#End Region

#Region "Realtime"

    Private Sub cmdCalibrateAcc_Click(sender As Object, e As EventArgs) Handles cmdCalibrateAcc.Click
        If Not isConnected Then
            MessageBox.Show(Me, "You have to connect to the FC first!", "Not connected", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return
        End If

        If MessageBox.Show(Me, "Make sure that your copter is leveled!" & vbCr & vbLf & "Press OK when ready, then keep copter steady for 5 seconds.", "Calibrating Accelerometer", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
            MSPquery(MSP_ACC_CALIBRATION)
        End If
    End Sub

    Private Sub cmdCalibrateMag_Click(sender As Object, e As EventArgs) Handles cmdCalibrateMag.Click
        If Not isConnected Then
            MessageBox.Show(Me, "You have to connect to the FC first!", "Not connected", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return
        End If

        If MessageBox.Show(Me, "After pressing OK please rotate your copter around all three axes" & vbCr & vbLf & " at least a full 360° turn for each axes. You will have 1 minute to finish", "Calibrating Magnetometer", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
            MSPquery(MSP_MAG_CALIBRATION)
        End If
    End Sub

    Friend lngContinue As String = "Continue"
    Friend lngPause As String = "Pause"
    Private Sub cmdPause_Click(sender As Object, e As EventArgs) Handles cmdPause.Click
        If cmdPause.Text = lngPause Then
            cmdPause.ForeColor = Color.Red
            cmdPause.Text = lngContinue
            timerRealtime.Stop()
        Else
            cmdPause.ForeColor = Color.Black
            cmdPause.Text = lngPause
            If isConnected Then
                timerRealtime.Start()
            End If
        End If
    End Sub

#End Region


End Class
