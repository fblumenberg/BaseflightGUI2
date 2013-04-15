Public Class frmMain


    Private Sub me_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Baseflight GUI - Version " & Application.ProductVersion
        'tabMain.TabPages.Remove(tpGFWUpdate)
        'Me.trbRCExpo.ForeColor = Color.FromArgb(64, 64, 64)
        'Me.trbRCRate.ForeColor = Color.FromArgb(64, 64, 64)
        'Me.trbTMID.ForeColor = Color.FromArgb(64, 64, 64)
        'Me.trbTEXPO.ForeColor = Color.FromArgb(64, 64, 64)
        readGUISettings()
        initCOMPorts()
        initRealtime()
        initTPMap()
        Me.chkFWShowOutput.Checked = ini.ReadBoolean("GUI", "FirmwareShowOutput", False)

        Me.MainMap.Zoom = CDbl(iMapZoom)
        Me.tb_mapzoom.Value = iMapZoom
        versionCheck()
        setButtonsOffline()
        inBuf = New Byte(299) {}
        inBuffer = New Byte(299) {}
        AddHandler serialPort.DataReceived, AddressOf DataReceivedHandler
        isStartup = False
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
            serial_error_count = 0
            serial_packet_count = 0
            setButtonsOnline()
            If connectCOM() = True Then
                readBaseflightBasics()
                readSettings()
                setTimer()
            Else
                setButtonsOffline()
            End If
        End If
        Me.lblVPacketReceived.Text = serial_packet_count
        Me.lblVPacketError.Text = serial_error_count
    End Sub

    Private Sub cmdReadSettings_Click(sender As Object, e As EventArgs) Handles cmdReadSettings.Click
        readSettings()
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
        If Me.tabMain.SelectedTab Is Me.tpMap Then
            saveWayPointToDisc()
        Else
            saveParamterToDisk()
        End If
    End Sub

    Private Sub saveParamterToDisk()
        fillGUI2Parameter()
        'Move values from GUI to the settings object
        Dim sfdSaveParameters As New SaveFileDialog()
        sfdSaveParameters.Filter = "Baseflight Settings File|*.bfs"
        sfdSaveParameters.Title = "Save parameters to file"
        sfdSaveParameters.InitialDirectory = sConfigFolder
        Dim invalidChars As String = System.Text.RegularExpressions.Regex.Escape(New String(IO.Path.GetInvalidFileNameChars()))
        Dim invalidReStr As String = String.Format("[{0} ]+", invalidChars)
        Dim fn As String = System.Text.RegularExpressions.Regex.Replace(txtComment.Text, invalidReStr, "_")
        fn = fn & [String].Format("{0:yymmdd-hhmm}", DateTime.Now)
        sfdSaveParameters.FileName = fn
        sfdSaveParameters.ShowDialog()
        If sfdSaveParameters.FileName <> "" Then
            mw_params.save_to_xml(sfdSaveParameters.FileName)
            sConfigFolder = System.IO.Path.GetDirectoryName(sfdSaveParameters.FileName)
            ini.Write("GUI", "ConfigFolder", sConfigFolder)
        End If
    End Sub

    Private Sub cmdLoadSettings_Click(sender As Object, e As EventArgs) Handles cmdLoadSettings.Click
        If Me.tabMain.SelectedTab Is Me.tpMap Then
            loadWayPointFromDisc()
        Else
            loadParamterFromDisk()
        End If
    End Sub

    Private Sub loadParamterFromDisk()
        Dim ofdLoadParameters As New OpenFileDialog()
        ofdLoadParameters.Filter = "Baseflight Settings File|*.bfs"
        ofdLoadParameters.Title = "Load parameters from file"
        ofdLoadParameters.InitialDirectory = sConfigFolder
        If ofdLoadParameters.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            'we have file to open
            If mw_params.read_from_xml(ofdLoadParameters.FileName) Then
                fillParameter2GUI()
                sConfigFolder = System.IO.Path.GetDirectoryName(ofdLoadParameters.FileName)
                ini.Write("GUI", "ConfigFolder", sConfigFolder)
            End If
        End If
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Try
            If isCLI = True Then
                endcli()
            End If
            disconnectCOM()
        Catch ex As Exception

        End Try
        serialPort.Close()
        Application.Exit()
    End Sub

    Private Sub readSettings()
        If comError = True Then Exit Sub
        MSPquery(MSP_BOX)
        readCOM()
        If comError = True Then Exit Sub
        set_aux_panel()
        MSPquery(MSP_RC)
        readCOM()
        If comError = True Then Exit Sub
        MSPquery(MSP_PID)
        readCOM()
        If comError = True Then Exit Sub
        MSPquery(MSP_RC_TUNING)
        readCOM()
        If comError = True Then Exit Sub
        MSPquery(MSP_IDENT)
        readCOM()
        If comError = True Then Exit Sub
        MSPquery(MSP_MISC)
        readCOM()
        If comError = True Then Exit Sub
        updateParameter()
    End Sub

    Private Sub writeSettings()
        timerRealtime.Stop()
        System.Threading.Thread.Sleep(500)
        fillGUI2Parameter()
        mw_params.write_settings(serialPort)

        System.Threading.Thread.Sleep(1000)

        readSettings()
        setTimer()
    End Sub

    Private Sub tabMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabMain.SelectedIndexChanged
        setTimer()
    End Sub

    Friend lngSaveSetting As String = "Save Setting"
    Friend lngLoadSetting As String = "Load Setting"
    Friend lngSaveWayPoints As String = "Save WayPoints"
    Friend lngLoadWayPoints As String = "Load WayPoints"
    Private Sub setTimer()
        timerRealtime.Stop()
        isRealtime = False
        Me.cmdLoadSettings.Text = lngLoadSetting
        Me.cmdSaveSettings.Text = lngSaveSetting
        If isConnected = False Then
            Me.cmdLoadSettings.Enabled = False
            Me.cmdSaveSettings.Enabled = False
        End If
        Me.MinimizeBox = True
        If tabMain.SelectedTab Is tpParameter Then
            timerRealtime.Stop()
            If isConnected = True Then
                endcli()
                updateParameter()
            End If
        ElseIf tabMain.SelectedTab Is tpRCSetting Then
            endcli()
            If isConnected = True Then
                Me.timerRealtime.Interval = iRefreshIntervals(Me.cmbRefreshRate.SelectedIndex)
                isRealtime = True
                timerRealtime.Start()
            End If
        ElseIf tabMain.SelectedTab Is tpRealtime Then
            endcli()
            If isConnected = True Then
                Me.timerRealtime.Interval = iRefreshIntervals(Me.cmbRefreshRate.SelectedIndex)
                isRealtime = True
                timerRealtime.Start()
            End If
        ElseIf tabMain.SelectedTab Is tpCLI Then
            isCLI = True
            timerRealtime.Stop()
            startCLI()
        ElseIf tabMain.SelectedTab Is tpGFWUpdate Then
            timerRealtime.Stop()
            endcli()
            initFirmwareUpdate()
        ElseIf tabMain.SelectedTab Is tpMap Then
            Me.cmdLoadSettings.Text = lngLoadWayPoints
            Me.cmdSaveSettings.Text = lngSaveWayPoints
            Me.cmdLoadSettings.Enabled = True
            Me.cmdSaveSettings.Enabled = True

            Me.MinimizeBox = False
            Me.timerRealtime.Interval = 1000 'GPS only every 1 sec. iRefreshIntervals(Me.cmbRefreshRate.SelectedIndex)
            If isConnected = True Then
                isRealtime = True
                timerRealtime.Start()
            End If
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

    Public Sub setButtonsOffline()
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

    Private Sub updateGUI()
        If tabMain.SelectedTab Is tpParameter Then
            fillParameter2GUI()
        ElseIf tabMain.SelectedTab Is tpRCSetting Then
            fillParameter2GUI()
        ElseIf tabMain.SelectedTab Is tpRealtime Then
            updateTPRealtime()
        ElseIf tabMain.SelectedTab Is tpCLI Then

        ElseIf tabMain.SelectedTab Is tpGFWUpdate Then

        ElseIf tabMain.SelectedTab Is tpMap Then

        End If
    End Sub

#Region "tpParameter"

    Private Sub tbrRCExpo_Scroll(sender As Object, e As EventArgs) Handles trbRCExpo.Scroll
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

    Public Sub initRCChannel()
        Dim auxChannel As Integer = 1
        Dim visible As Boolean = True

        lblRC_AUX1.Visible = visible
        lblVRC_AUX1.Visible = visible
        pgbRC_AUX1.Visible = visible
        auxChannel += 1
        If auxChannel > AUX_CHANNELS Then visible = False

        lblRC_AUX2.Visible = visible
        lblVRC_AUX2.Visible = visible
        pgbRC_AUX2.Visible = visible
        auxChannel += 1
        If auxChannel > AUX_CHANNELS Then visible = False

        lblRC_AUX3.Visible = visible
        lblVRC_AUX3.Visible = visible
        pgbRC_AUX3.Visible = visible
        auxChannel += 1
        If auxChannel > AUX_CHANNELS Then visible = False

        lblRC_AUX4.Visible = visible
        lblVRC_AUX4.Visible = visible
        pgbRC_AUX4.Visible = visible
        auxChannel += 1
        If auxChannel > AUX_CHANNELS Then visible = False

        lblRC_AUX5.Visible = visible
        lblVRC_AUX5.Visible = visible
        pgbRC_AUX5.Visible = visible
        auxChannel += 1
        If auxChannel > AUX_CHANNELS Then visible = False

        lblRC_AUX6.Visible = visible
        lblVRC_AUX6.Visible = visible
        pgbRC_AUX6.Visible = visible
        auxChannel += 1
        If auxChannel > AUX_CHANNELS Then visible = False

        lblRC_AUX7.Visible = visible
        lblVRC_AUX7.Visible = visible
        pgbRC_AUX7.Visible = visible
        auxChannel += 1
        If auxChannel > AUX_CHANNELS Then visible = False

        lblRC_AUX8.Visible = visible
        lblVRC_AUX8.Visible = visible
        pgbRC_AUX8.Visible = visible

    End Sub

    Public Sub updateRCChannels()
        lblVRC_THR.Text = mw_gui.rcThrottle
        pgbRC_THR.Value = mw_gui.rcThrottle

        lblVRC_PITCH.Text = mw_gui.rcPitch
        pgbRC_PITCH.Value = mw_gui.rcPitch

        lblVRC_ROLL.Text = mw_gui.rcRoll
        pgbRC_ROLL.Value = mw_gui.rcRoll

        lblVRC_YAW.Text = mw_gui.rcYaw
        pgbRC_YAW.Value = mw_gui.rcYaw

        Dim auxChannel As Integer = 0

        lblVRC_AUX1.Text = mw_gui.rcAUX(0)
        pgbRC_AUX1.Value = mw_gui.rcAUX(0)
        auxChannel += 1
        If auxChannel > AUX_CHANNELS Then Exit Sub

        lblVRC_AUX2.Text = mw_gui.rcAUX(1)
        pgbRC_AUX2.Value = mw_gui.rcAUX(1)
        auxChannel += 1
        If auxChannel > AUX_CHANNELS Then Exit Sub

        lblVRC_AUX3.Text = mw_gui.rcAUX(2)
        pgbRC_AUX3.Value = mw_gui.rcAUX(2)
        auxChannel += 1
        If auxChannel > AUX_CHANNELS Then Exit Sub

        lblVRC_AUX4.Text = mw_gui.rcAUX(3)
        pgbRC_AUX4.Value = mw_gui.rcAUX(3)
        auxChannel += 1
        If auxChannel > AUX_CHANNELS Then Exit Sub

        lblVRC_AUX5.Text = mw_gui.rcAUX(4)
        pgbRC_AUX5.Value = mw_gui.rcAUX(4)
        auxChannel += 1
        If auxChannel > AUX_CHANNELS Then Exit Sub

        lblVRC_AUX6.Text = mw_gui.rcAUX(5)
        pgbRC_AUX6.Value = mw_gui.rcAUX(5)
        auxChannel += 1
        If auxChannel > AUX_CHANNELS Then Exit Sub

        lblVRC_AUX7.Text = mw_gui.rcAUX(6)
        pgbRC_AUX7.Value = mw_gui.rcAUX(6)
        auxChannel += 1
        If auxChannel > AUX_CHANNELS Then Exit Sub

        lblVRC_AUX8.Text = mw_gui.rcAUX(7)
        pgbRC_AUX8.Value = mw_gui.rcAUX(7)

    End Sub

#End Region

    Private Sub cmbRefreshRate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRefreshRate.SelectedIndexChanged
        If isStartup = True Then Exit Sub
        Me.timerRealtime.Interval = iRefreshIntervals(Me.cmbRefreshRate.SelectedIndex)
        ini.Write("GUI", "DefaultRate", Me.cmbRefreshRate.SelectedItem)
    End Sub

    Private Sub timerRealtime_Tick(sender As Object, e As EventArgs) Handles timerRealtime.Tick
        If Me.WindowState <> FormWindowState.Minimized Then
            If comError = False Then
                If tabMain.SelectedTab Is tpRCSetting Then
                    MSPquery(MSP_RC)
                    readCOM()
                    updateRCChannels()
                    updateRCControlSettings()
                ElseIf tabMain.SelectedTab Is tpRealtime Then
                    askForRealtimeValues()
                    updateTPRealtime()
                ElseIf tabMain.SelectedTab Is tpMap Then
                    askForMapData()
                    updateTPMap()
                End If
                Me.lblVPacketReceived.Text = serial_packet_count
                Me.lblVPacketError.Text = serial_error_count
            Else
                timerRealtime.Stop()
            End If
            Application.DoEvents()
        End If
    End Sub

#Region "CLI"

    Private Sub cmdClearScreen_Click(sender As Object, e As EventArgs) Handles cmdCLIClearScreen.Click
        Me.txtCLIResult.Text = ""
    End Sub

    Private Sub cmdHelp_Click(sender As Object, e As EventArgs) Handles cmdCLIHelp.Click
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

    Private Sub cmdDump_Click(sender As Object, e As EventArgs) Handles cmdCLIDump.Click
        Me.txtCLICommand.Text = "DUMP"
        CLISendComamand()
    End Sub

    Private Sub cmdLoad_Click(sender As Object, e As EventArgs) Handles cmdCLILoad.Click
        loadCLIFile()
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdCLISave.Click
        serialPort.Write("Save" & vbCr & vbLf)
        frmReboot.StartPosition = FormStartPosition.Manual
        frmReboot.Location = New System.Drawing.Point(Me.Location.X + (Me.Width - frmReboot.Width) / 2, Me.Location.Y + (Me.Height - frmReboot.Height) / 2)
        frmReboot.Show()

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

    Private Sub ctrlHORIZON_Click(sender As Object, e As EventArgs) Handles ctrlHORIZON.Click
        Dim c As Point = System.Windows.Forms.Cursor.Position
        Dim p As Point = ctrlHORIZON.PointToClient(c)
        ctrlHORIZON.ToggleArtificalHorizonType()
    End Sub

    Private Sub cmdCheck_all_ACC_Click(sender As Object, e As EventArgs) Handles cmdCheck_all_ACC.Click
        Me.chk_acc_pitch.Checked = True
        Me.chk_acc_roll.Checked = True
        Me.chk_acc_z.Checked = True
    End Sub

    Private Sub cmdUncheck_all_ACC_Click(sender As Object, e As EventArgs) Handles cmdUncheck_all_ACC.Click
        Me.chk_acc_pitch.Checked = False
        Me.chk_acc_roll.Checked = False
        Me.chk_acc_z.Checked = False
    End Sub

    Private Sub cmdCheck_all_GYRO_Click(sender As Object, e As EventArgs) Handles cmdCheck_all_GYRO.Click
        Me.chk_gyro_pitch.Checked = True
        Me.chk_gyro_roll.Checked = True
        Me.chk_gyro_yaw.Checked = True
    End Sub

    Private Sub cmdUncheck_all_GYRO_Click(sender As Object, e As EventArgs) Handles cmdUncheck_all_GYRO.Click
        Me.chk_gyro_pitch.Checked = False
        Me.chk_gyro_roll.Checked = False
        Me.chk_gyro_yaw.Checked = False
    End Sub

    Private Sub cmdCheck_all_MAG_Click(sender As Object, e As EventArgs) Handles cmdCheck_all_MAG.Click
        Me.chk_mag_pitch.Checked = True
        Me.chk_mag_roll.Checked = True
        Me.chk_mag_yaw.Checked = True
    End Sub

    Private Sub cmdUncheck_all_MAG_Click(sender As Object, e As EventArgs) Handles cmdUncheck_all_MAG.Click
        Me.chk_mag_pitch.Checked = False
        Me.chk_mag_roll.Checked = False
        Me.chk_mag_yaw.Checked = False
    End Sub

    Public Sub initRealtimeChannel()
        Dim auxChannel As Integer = 1
        Dim visible As Boolean = True

        lblRT_AUX1.Visible = visible
        lblVRT_AUX1.Visible = visible
        pgbRT_AUX1.Visible = visible
        auxChannel += 1
        If auxChannel > AUX_CHANNELS Then visible = False

        lblRT_AUX2.Visible = visible
        lblVRT_AUX2.Visible = visible
        pgbRT_AUX2.Visible = visible
        auxChannel += 1
        If auxChannel > AUX_CHANNELS Then visible = False

        lblRT_AUX3.Visible = visible
        lblVRT_AUX3.Visible = visible
        pgbRT_AUX3.Visible = visible
        auxChannel += 1
        If auxChannel > AUX_CHANNELS Then visible = False

        lblRT_AUX4.Visible = visible
        lblVRT_AUX4.Visible = visible
        pgbRT_AUX4.Visible = visible
        auxChannel += 1
        If auxChannel > AUX_CHANNELS Then visible = False

        lblRT_AUX5.Visible = visible
        lblVRT_AUX5.Visible = visible
        pgbRT_AUX5.Visible = visible
        auxChannel += 1
        If auxChannel > AUX_CHANNELS Then visible = False

        lblRT_AUX6.Visible = visible
        lblVRT_AUX6.Visible = visible
        pgbRT_AUX6.Visible = visible
        auxChannel += 1
        If auxChannel > AUX_CHANNELS Then visible = False

        lblRT_AUX7.Visible = visible
        lblVRT_AUX7.Visible = visible
        pgbRT_AUX7.Visible = visible
        auxChannel += 1
        If auxChannel > AUX_CHANNELS Then visible = False

        lblRT_AUX8.Visible = visible
        lblVRT_AUX8.Visible = visible
        pgbRT_AUX8.Visible = visible

    End Sub

    Public Sub updateRealtimeChannels()
        lblVRT_THR.Text = mw_gui.rcThrottle
        pgbRT_THR.Value = mw_gui.rcThrottle

        lblVRT_PITCH.Text = mw_gui.rcPitch
        pgbRT_PITCH.Value = mw_gui.rcPitch

        lblVRT_ROLL.Text = mw_gui.rcRoll
        pgbRT_ROLL.Value = mw_gui.rcRoll

        lblVRT_YAW.Text = mw_gui.rcYaw
        pgbRT_YAW.Value = mw_gui.rcYaw

        Dim auxChannel As Integer = 0

        lblVRT_AUX1.Text = mw_gui.rcAUX(0)
        pgbRT_AUX1.Value = mw_gui.rcAUX(0)
        auxChannel += 1
        If auxChannel > AUX_CHANNELS Then Exit Sub

        lblVRT_AUX2.Text = mw_gui.rcAUX(1)
        pgbRT_AUX2.Value = mw_gui.rcAUX(1)
        auxChannel += 1
        If auxChannel > AUX_CHANNELS Then Exit Sub

        lblVRT_AUX3.Text = mw_gui.rcAUX(2)
        pgbRT_AUX3.Value = mw_gui.rcAUX(2)
        auxChannel += 1
        If auxChannel > AUX_CHANNELS Then Exit Sub

        lblVRT_AUX4.Text = mw_gui.rcAUX(3)
        pgbRT_AUX4.Value = mw_gui.rcAUX(3)
        auxChannel += 1
        If auxChannel > AUX_CHANNELS Then Exit Sub

        lblVRT_AUX5.Text = mw_gui.rcAUX(4)
        pgbRT_AUX5.Value = mw_gui.rcAUX(4)
        auxChannel += 1
        If auxChannel > AUX_CHANNELS Then Exit Sub

        lblVRT_AUX6.Text = mw_gui.rcAUX(5)
        pgbRT_AUX6.Value = mw_gui.rcAUX(5)
        auxChannel += 1
        If auxChannel > AUX_CHANNELS Then Exit Sub

        lblVRT_AUX7.Text = mw_gui.rcAUX(6)
        pgbRT_AUX7.Value = mw_gui.rcAUX(6)
        auxChannel += 1
        If auxChannel > AUX_CHANNELS Then Exit Sub

        lblVRT_AUX8.Text = mw_gui.rcAUX(7)
        pgbRT_AUX8.Value = mw_gui.rcAUX(7)

    End Sub

#End Region

#Region "Firmware"
    Private Sub searchFirmwareFile_Click(sender As Object, e As EventArgs) Handles searchFirmwareFile.Click
        readFirmwareFile()
    End Sub

    Private Sub cmdFWUpdate_Click(sender As Object, e As EventArgs) Handles cmdFWUpdate.Click
        updateFirmware()
    End Sub

    Private Sub chkFWSendR_CheckedChanged(sender As Object, e As EventArgs) Handles chkFWSendR.CheckedChanged, chkFWShowOutput.CheckedChanged
        initFirmwareUpdate()
    End Sub
#End Region

#Region "Map"

    Private Sub initTPMap()
        Try
            ' config map             
            createDTWayPoints()

            Me.MainMap.MinZoom = 1
            Me.MainMap.MaxZoom = 20
            Me.tb_mapzoom.Value = iMapZoom

            Me.MainMap.CacheLocation = IO.Path.GetDirectoryName(Application.ExecutablePath) & "/mapcache/"

            pointLng = ini.ReadDouble("GPS", "Longtitude", 7.230758)
            pointLat = ini.ReadDouble("GPS", "Latitude", 51.462447)
            copterPos = New GMap.NET.PointLatLng(pointLat, pointLng)

            mapProviders = New GMap.NET.MapProviders.GMapProvider(5) {}
            mapProviders(0) = GMap.NET.MapProviders.GMapProviders.BingHybridMap
            mapProviders(1) = GMap.NET.MapProviders.GMapProviders.BingSatelliteMap
            mapProviders(2) = GMap.NET.MapProviders.GMapProviders.GoogleHybridMap
            mapProviders(3) = GMap.NET.MapProviders.GMapProviders.GoogleSatelliteMap
            mapProviders(4) = GMap.NET.MapProviders.GMapProviders.OviHybridMap
            mapProviders(5) = GMap.NET.MapProviders.GMapProviders.OviSatelliteMap

            For i As Integer = 0 To 5
                Me.cmbMapProviders.Items.Add(mapProviders(i))
            Next

            Me.cmbMapProviders.SelectedIndex = iMapProviderSelectedIndex
            Me.MainMap.MapProvider = mapProviders(iMapProviderSelectedIndex)
            Me.tb_mapzoom.Value = Me.MainMap.MaxZoom
            Me.MainMap.Zoom = Me.MainMap.MaxZoom

            currentMarker = New GMap.NET.WindowsForms.Markers.GMapMarkerGoogleRed(Me.MainMap.Position)
            Me.MainMap.MapScaleInfoEnabled = True

            Me.MainMap.ForceDoubleBuffer = True
            Me.MainMap.Manager.Mode = GMap.NET.AccessMode.ServerAndCache

            Me.MainMap.Position = copterPos

            Dim penRoute As New Pen(Color.Yellow, 3)
            Dim penWPRoute As New Pen(Color.Red, 3)
            Dim penScale As New Pen(Color.Blue, 3)

            Me.MainMap.ScalePen = penScale

            routes = New GMap.NET.WindowsForms.GMapOverlay(Me.MainMap, "routes")
            Me.MainMap.Overlays.Add(routes)

            drawnpolygons = New GMap.NET.WindowsForms.GMapOverlay(Me.MainMap, "drawnpolygons")
            Me.MainMap.Overlays.Add(drawnpolygons)

            markers = New GMap.NET.WindowsForms.GMapOverlay(Me.MainMap, "objects")
            Me.MainMap.Overlays.Add(markers)

            polygons = New GMap.NET.WindowsForms.GMapOverlay(Me.MainMap, "polygons")
            Me.MainMap.Overlays.Add(polygons)

            positions = New GMap.NET.WindowsForms.GMapOverlay(Me.MainMap, "positions")
            Me.MainMap.Overlays.Add(positions)

            WProutes = New GMap.NET.WindowsForms.GMapOverlay(Me.MainMap, "wproutes")
            Me.MainMap.Overlays.Add(WProutes)

            WayPoints = New GMap.NET.WindowsForms.GMapOverlay(Me.MainMap, "waypoints")
            Me.MainMap.Overlays.Add(WayPoints)

            positions.Markers.Clear()
            positions.Markers.Add(New GMapMarkerQuad(copterPos, 0, 0, 0))

            'WayPoints.Markers.Clear()
            'WayPoints.Markers.Add(New GMapMarkerWayPoint(copterPos, 0, 0, 0))

            Grout = New GMap.NET.WindowsForms.GMapRoute(points, "track")
            Grout.Stroke = penRoute
            routes.Routes.Add(Grout)

            GWPRout = New GMap.NET.WindowsForms.GMapRoute(points, "wptrack")
            GWPRout.Stroke = penWPRoute
            WProutes.Routes.Add(GWPRout)

            center = New GMap.NET.WindowsForms.Markers.GMapMarkerCross(Me.MainMap.Position)

        Catch ex As Exception

        End Try
    End Sub

    Dim oldWP As GMap.NET.PointLatLng
    Dim wpNo As Integer = 0
    Private Sub dgWayPoints_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgWayPoints.CellClick, dgWayPoints.CellContentClick
        If isStartup = True Then Exit Sub
        isStartup = True
        Me.cmdWPUpdate.Enabled = False
        editWPDr = dtWayPoints.Select("WPNo = " & dgWayPoints.Item("colWPNumber", e.RowIndex).Value)(0)
        WayPoints.Markers.Clear()
        WayPoints.Markers.Add(New GMapMarkerWayPoint(New GMap.NET.PointLatLng(editWPDr("Lat"), editWPDr("Lng")), editWPDr("Heading"), 0, 0))

        Me.txtWPLat.Text = editWPDr("Lat")
        Me.txtWPLng.Text = editWPDr("Lng")
        Me.numWPAlt.Value = editWPDr("Alt")
        Me.numWPTimeToStay.Text = editWPDr("TimeToStay")
        Me.numWPParameter.Text = editWPDr("ActionParameter")
        Me.numWPNavFlagAction.Text = editWPDr("Action")
        Me.numWPHeading.Text = editWPDr("Heading")
        setMapCtrl(True)
        isStartup = False
    End Sub

    Private Sub dgWayPoints_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgWayPoints.RowsRemoved
        wpNo = 0
        For Each dr As DataRow In dtWayPoints.Rows
            wpNo += 1
            dr("WPNo") = wpNo
        Next
        updateWayPointRoute()
    End Sub


    Private Sub dgWayPoints_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgWayPoints.DragDrop
        Dim CP As Point = dgWayPoints.PointToClient(New Point(e.X, e.Y))
        Dim RowDestination As Integer = dgWayPoints.HitTest(CP.X, CP.Y).RowIndex
        Dim RowSource As Integer = e.Data.GetData("System.String")
        If RowDestination >= 0 Then
            Dim tmp(0 To dgWayPoints.Rows(0).Cells.Count - 1)
            'saving Cells
            For i = 0 To tmp.Count - 1
                tmp(i) = dgWayPoints.Rows.Item(RowSource).Cells(i).Value
            Next
            dgWayPoints.Rows.RemoveAt(RowSource)
            dgWayPoints.Rows.Insert(RowDestination, 1)
            'Aplly Saved Cells
            For i = 0 To tmp.Count - 1
                dgWayPoints.Rows(RowDestination).Cells(i).Value = tmp(i)
            Next i
            dgWayPoints.Rows(RowDestination).Selected = True
        End If
    End Sub




    Private Sub txtWPLat_TextChanged(sender As Object, e As EventArgs) Handles txtWPLat.TextChanged
        If isStartup = True Then Exit Sub
        Me.cmdWPUpdate.Enabled = True
    End Sub

    Private Sub txtWPLng_TextChanged(sender As Object, e As EventArgs) Handles txtWPLng.TextChanged
        If isStartup = True Then Exit Sub
        Me.cmdWPUpdate.Enabled = True
    End Sub

    Private Sub numWPAlt_ValueChanged(sender As Object, e As EventArgs) Handles numWPAlt.ValueChanged
        If isStartup = True Then Exit Sub
        Me.cmdWPUpdate.Enabled = True
    End Sub

    Private Sub numWPTimeToStay_ValueChanged(sender As Object, e As EventArgs) Handles numWPTimeToStay.ValueChanged
        If isStartup = True Then Exit Sub
        Me.cmdWPUpdate.Enabled = True
    End Sub

    Private Sub numWPParameter_ValueChanged(sender As Object, e As EventArgs) Handles numWPParameter.ValueChanged
        If isStartup = True Then Exit Sub
        Me.cmdWPUpdate.Enabled = True
    End Sub

    Private Sub numWPNavFlagAction_ValueChanged(sender As Object, e As EventArgs) Handles numWPNavFlagAction.ValueChanged
        If isStartup = True Then Exit Sub
        Me.cmdWPUpdate.Enabled = True
    End Sub

    Private Sub numWPHeading_ValueChanged(sender As Object, e As EventArgs) Handles numWPHeading.ValueChanged
        Me.picWPHeading.Image = getBmpHeading(Me.numWPHeading.Value)
        If isStartup = True Then Exit Sub
        Me.cmdWPUpdate.Enabled = True
        WayPoints.Markers.Clear()
        WayPoints.Markers.Add(New GMapMarkerWayPoint(New GMap.NET.PointLatLng(CDbl(Me.txtWPLat.Text), CDbl(Me.txtWPLng.Text)), CInt(Me.numWPHeading.Value), 0, 0))
    End Sub

    Private Sub cmdClearRoute_Click(sender As Object, e As EventArgs) Handles cmdClearRoute.Click
        Grout.Points.Clear()
    End Sub

    Private Sub cmdWPUpdate_Click(sender As Object, e As EventArgs) Handles cmdWPUpdate.Click
        Me.cmdWPUpdate.Enabled = False
        editWPDr("Lat") = Me.txtWPLat.Text
        editWPDr("Lng") = Me.txtWPLng.Text
        editWPDr("Alt") = Me.numWPAlt.Value
        editWPDr("TimeToStay") = Me.numWPTimeToStay.Text
        editWPDr("ActionParameter") = Me.numWPParameter.Text
        editWPDr("Action") = Me.numWPNavFlagAction.Text
        editWPDr("Heading") = Me.numWPHeading.Text
        updateWayPointRoute()
    End Sub

    Private Sub cmdWPClear_Click(sender As Object, e As EventArgs) Handles cmdWPClear.Click
        Me.cmdWPUpdate.Enabled = False
        setMapCtrl(False)
        dtWayPoints.Clear()
        wpNo = 0
        GWPRout.Points.Clear()
        Dim pos As GMap.NET.PointLatLng = Me.MainMap.Position
        Me.MainMap.Position = New GMap.NET.PointLatLng(pos.Lat + 0.00000000001, pos.Lng)
        Me.MainMap.Position = pos
    End Sub

    Private Sub setMapCtrl(ByVal enable As Boolean)
        Me.txtWPLat.Enabled = enable
        Me.txtWPLng.Enabled = enable
        Me.numWPAlt.Enabled = enable
        Me.numWPTimeToStay.Enabled = enable
        Me.numWPParameter.Enabled = enable
        Me.numWPNavFlagAction.Enabled = enable
        Me.numWPHeading.Enabled = enable
    End Sub

    Private Sub MainMap_DoubleClick(sender As Object, e As EventArgs) Handles MainMap.DoubleClick
        'ini.Write("GPS", "Longtitude", pointLng)
        'ini.Write("GPS", "Latitude", pointLat)
        'copterPos = New GMap.NET.PointLatLng(pointLat, pointLng)
        Dim newWP As GMap.NET.PointLatLng = New GMap.NET.PointLatLng(pointLat, pointLng)
        If distance(oldWP, newWP) <= 200 Then
            GWPRout.Points.Add(New GMap.NET.PointLatLng(pointLat, pointLng))
            Me.MainMap.Invalidate(False)
            Me.MainMap.Update()
            Dim pos As GMap.NET.PointLatLng = Me.MainMap.Position
            Me.MainMap.Position = New GMap.NET.PointLatLng(pos.Lat + 0.00000000001, pos.Lng)
            Me.MainMap.Position = pos
            oldWP = newWP
            Dim dr As DataRow = dtWayPoints.NewRow
            wpNo += 1
            dr("WPNo") = wpNo
            dr("Lat") = pointLat
            dr("Lng") = pointLng
            dr("Alt") = 0
            dr("Heading") = 0
            dr("TimeToStay") = 0
            dr("Action") = 0
            dr("ActionParameter") = 0
            dtWayPoints.Rows.Add(dr)
            editWPDr = dr
            WayPoints.Markers.Clear()
            Me.txtWPLat.Text = editWPDr("Lat")
            Me.txtWPLng.Text = editWPDr("Lng")
            Me.numWPAlt.Value = editWPDr("Alt")
            Me.numWPTimeToStay.Text = editWPDr("TimeToStay")
            Me.numWPParameter.Text = editWPDr("ActionParameter")
            Me.numWPNavFlagAction.Text = editWPDr("Action")
            Me.numWPHeading.Text = editWPDr("Heading")
            WayPoints.Markers.Add(New GMapMarkerWayPoint(New GMap.NET.PointLatLng(pointLat, pointLng), 0, 0, 0))
        Else

        End If
    End Sub

    Private Sub MainMap_MouseDown(sender As Object, e As MouseEventArgs) Handles MainMap.MouseDown
        start = Me.MainMap.FromLocalToLatLng(e.X, e.Y)

        If e.Button = MouseButtons.Left AndAlso Control.ModifierKeys <> Keys.Alt Then
            isMouseDown = True
            isMouseDraging = False

            If currentMarker.IsVisible Then
                currentMarker.Position = Me.MainMap.FromLocalToLatLng(e.X, e.Y)
            End If
        End If
    End Sub

    Private Sub MainMap_MouseMove(sender As Object, e As MouseEventArgs) Handles MainMap.MouseMove
        Dim point As GMap.NET.PointLatLng = Me.MainMap.FromLocalToLatLng(e.X, e.Y)

        currentMarker.Position = point

        If Not isMouseDown Then
            pointLat = point.Lat
            pointLng = point.Lng
            Me.lblVMousePos.Text = "Lat:" & [String].Format("{0:0.000000}", point.Lat) & " Lon:" & [String].Format("{0:0.000000}", point.Lng)
        End If

        'draging
        If e.Button = MouseButtons.Left AndAlso isMouseDown Then
            isMouseDraging = True
            If IsNothing(CurentRectMarker) = False Then
                ' move rect marker
                Try
                    If CurentRectMarker.InnerMarker.Tag.ToString().Contains("grid") Then
                        drawnpolygon.Points(Integer.Parse(CurentRectMarker.InnerMarker.Tag.ToString().Replace("grid", "")) - 1) = New GMap.NET.PointLatLng(point.Lat, point.Lng)
                        Me.MainMap.UpdatePolygonLocalPosition(drawnpolygon)
                    End If
                Catch
                End Try

                Dim pnew As GMap.NET.PointLatLng = Me.MainMap.FromLocalToLatLng(e.X, e.Y)

                Dim pIndex As System.Nullable(Of Integer) = CType(CurentRectMarker.Tag, System.Nullable(Of Integer))
                If pIndex.HasValue Then
                    If pIndex < polygon.Points.Count Then
                        polygon.Points(pIndex.Value) = pnew
                        Me.MainMap.UpdatePolygonLocalPosition(polygon)
                    End If
                End If

                If currentMarker.IsVisible Then
                    currentMarker.Position = pnew
                End If
                CurentRectMarker.Position = pnew

                If CurentRectMarker.InnerMarker IsNot Nothing Then
                    CurentRectMarker.InnerMarker.Position = pnew
                End If
            ElseIf IsNothing(CurentWayPoint) = False Then
                ' move WayPoint
                Dim pnew As GMap.NET.PointLatLng = Me.MainMap.FromLocalToLatLng(e.X, e.Y)

                If CurentWayPoint.IsVisible Then
                    CurentWayPoint.Position = pnew
                    Me.txtWPLat.Text = pnew.Lat
                    Me.txtWPLng.Text = pnew.Lng
                End If
            Else
                ' left click pan
                Dim latdif As Double = start.Lat - point.Lat
                Dim lngdif As Double = start.Lng - point.Lng
                Me.MainMap.Position = New GMap.NET.PointLatLng(center.Position.Lat + latdif, center.Position.Lng + lngdif)
            End If
        End If
    End Sub

    Private Sub MainMap_MouseUp(sender As Object, e As MouseEventArgs) Handles MainMap.MouseUp
        [end] = Me.MainMap.FromLocalToLatLng(e.X, e.Y)

        If e.Button = MouseButtons.Right Then
            ' ignore right clicks
            Return
        End If

        If isMouseDown Then
            ' mouse down on some other object and dragged to here.
            If e.Button = MouseButtons.Left Then
                isMouseDown = False
            End If
            If Not isMouseDraging Then
                ' cant add WP in existing rect
                If CurentRectMarker IsNot Nothing Then
                    'callMe(currentMarker.Position.Lat, currentMarker.Position.Lng, 0);
                    'Adding waypoint will come here
                    'addpolygonmarker("X", currentMarker.Position.Lng, currentMarker.Position.Lat, 0,Color.Pink);
                    'RegeneratePolygon();


                Else
                End If
            Else
                If CurentRectMarker IsNot Nothing Then
                    If CurentRectMarker.InnerMarker.Tag.ToString().Contains("grid") Then
                        drawnpolygon.Points(Integer.Parse(CurentRectMarker.InnerMarker.Tag.ToString().Replace("grid", "")) - 1) = New GMap.NET.PointLatLng([end].Lat, [end].Lng)
                        Me.MainMap.UpdatePolygonLocalPosition(drawnpolygon)
                        'callMeDrag(CurentRectMarker.InnerMarker.Tag.ToString(), currentMarker.Position.Lat, currentMarker.Position.Lng, -1);
                        'update existing point in datagrid
                    Else
                    End If
                    CurentRectMarker = Nothing
                End If
            End If
        End If

        isMouseDraging = False
    End Sub

    Private Sub MainMap_OnMapZoomChanged() Handles MainMap.OnMapZoomChanged
        If Me.MainMap.Zoom > 0 Then
            Me.tb_mapzoom.Value = CInt(Me.MainMap.Zoom)
            center.Position = Me.MainMap.Position
        End If
    End Sub

    Private Sub MainMap_OnMarkerEnter(item As GMap.NET.WindowsForms.GMapMarker) Handles MainMap.OnMarkerEnter
        If Not isMouseDown Then
            If TypeOf item Is GMapMarkerRect Then
                Dim rc As GMapMarkerRect = TryCast(item, GMapMarkerRect)
                rc.Pen.Color = Color.Red
                Me.MainMap.Invalidate(False)
                CurentRectMarker = rc
            ElseIf TypeOf item Is GMapMarkerWayPoint Then
                Dim rc As GMapMarkerWayPoint = TryCast(item, GMapMarkerWayPoint)
                Me.MainMap.Invalidate(False)
                CurentWayPoint = rc
            End If
        End If
    End Sub

    Private Sub MainMap_OnMarkerLeave(item As GMap.NET.WindowsForms.GMapMarker) Handles MainMap.OnMarkerLeave
        If Not isMouseDown Then
            If TypeOf item Is GMapMarkerRect Then
                CurentRectMarker = Nothing
                Dim rc As GMapMarkerRect = TryCast(item, GMapMarkerRect)
                rc.Pen.Color = Color.Blue
                Me.MainMap.Invalidate(False)
            ElseIf TypeOf item Is GMapMarkerWayPoint Then
                CurentWayPoint = Nothing
                Me.MainMap.Invalidate(False)
            End If
        End If
    End Sub

    Private Sub MainMap_OnPositionChanged(point As GMap.NET.PointLatLng) Handles MainMap.OnPositionChanged
        If point.Lat > 90 Then
            point.Lat = 90
        End If
        If point.Lat < -90 Then
            point.Lat = -90
        End If
        If point.Lng > 180 Then
            point.Lng = 180
        End If
        If point.Lng < -180 Then
            point.Lng = -180
        End If
        center.Position = point
        Me.lblVMousePos.Text = "Lat:" & [String].Format("{0:0.000000}", point.Lat) & " Lon:" & [String].Format("{0:0.000000}", point.Lng)
    End Sub

    Private Sub cmbMapProviders_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMapProviders.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Me.MainMap.MapProvider = DirectCast(Me.cmbMapProviders.SelectedItem, GMap.NET.MapProviders.GMapProvider)
        Me.MainMap.MaxZoom = 19
        Me.MainMap.Invalidate()
        ini.Write("GUI", "MapProvider", Me.cmbMapProviders.SelectedIndex)
        Me.Cursor = Cursors.[Default]
    End Sub

    Private Sub tb_mapzoom_Scroll(sender As Object, e As EventArgs) Handles tb_mapzoom.Scroll
        MainMap.Zoom = CDbl(tb_mapzoom.Value)
        ini.Write("GUI", "MapZoom", tb_mapzoom.Value)
    End Sub

#End Region

    Private Sub frmMain_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Normal
            Me.timerRealtime.Enabled = False
        Else
            Me.timerRealtime.Enabled = True
        End If
    End Sub

    Private Sub txtCLIResult_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCLIResult.KeyDown
        If e.Control And e.KeyCode.ToString = "A" Then
            ' When the user presses both the 'Alt key and the 'F' key,
            ' KeyPreview is set to True, and a message appears.
            ' This message is only displayed when KeyPreview is set to False.
            Me.KeyPreview = True
            Me.txtCLIResult.SelectAll()
        End If

    End Sub

End Class
