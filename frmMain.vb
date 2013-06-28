Public Class frmMain

    Friend lngMagCalibaration As String = "Mag calibration" & vbCrLf & "is" & vbCrLf & "performed"
    Friend lngRebooting As String = "Rebooting"

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        disconnectCOM()
    End Sub

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
        setButtons(False)
        inBuf = New Byte(299) {}
        gpsBuffer = New Byte(299) {}
        readDTOnlineHelp()
        readToolTip()

        Me.chk_acc_roll.Checked = ini.ReadBoolean("GUI", "acc_roll", True)
        Me.chk_acc_pitch.Checked = ini.ReadBoolean("GUI", "acc_pitch", True)
        Me.chk_acc_z.Checked = ini.ReadBoolean("GUI", "acc_z", True)
        Me.chk_gyro_roll.Checked = ini.ReadBoolean("GUI", "gyro_roll", True)
        Me.chk_gyro_pitch.Checked = ini.ReadBoolean("GUI", "gyro_pitch", True)
        Me.chk_gyro_yaw.Checked = ini.ReadBoolean("GUI", "gyro_yaw", True)
        Me.chk_mag_roll.Checked = ini.ReadBoolean("GUI", "mag_roll", False)
        Me.chk_mag_pitch.Checked = ini.ReadBoolean("GUI", "mag_pitch", False)
        Me.chk_mag_yaw.Checked = ini.ReadBoolean("GUI", "mag_yaw", False)
        Me.chk_alt.Checked = ini.ReadBoolean("GUI", "alt", False)
        Me.chk_head.Checked = ini.ReadBoolean("GUI", "head", False)
        Me.chk_dbg1.Checked = ini.ReadBoolean("GUI", "dbg1", False)
        Me.chk_dbg2.Checked = ini.ReadBoolean("GUI", "dbg2", False)
        Me.chk_dbg3.Checked = ini.ReadBoolean("GUI", "dbg3", False)
        Me.chk_dbg4.Checked = ini.ReadBoolean("GUI", "dbg4", False)

        Me.lblParameterWarning.Visible = False
        Me.lblRealtimeWarning.Visible = False
        Me.lblMapWarning.Visible = False
        Me.lblRCWarning.Visible = False
        Me.lblParameterWarning.BringToFront()
        Me.lblRealtimeWarning.BringToFront()
        Me.lblMapWarning.BringToFront()
        Me.lblRCWarning.BringToFront()
        mw_gui = New baseflight_data_gui(iPidItems, iCheckBoxItems, iSoftwareVersion)

        isStartup = False
    End Sub

    Private Sub setTAB()
        'timerRealtime.Stop()   'don't stop because of background logging
        If isConnected = False Then
            Me.cmdLoadSettings.Enabled = False
            Me.cmdSaveSettings.Enabled = False
        End If
        isRealtime = False
        Me.cmdLoadSettings.Text = lngLoadSetting
        Me.cmdSaveSettings.Text = lngSaveSetting
        If isCLI = True And Not tabMain.SelectedTab Is tpCLI Then
            endcli()
        End If
        If isPASSGPS = True And Not tabMain.SelectedTab Is tpPassGPS Then
            endPassGPS()
        End If
        Me.MinimizeBox = True
        If tabMain.SelectedTab Is tpParameter Then
            'timerRealtime.Stop()
            If isConnected = True Then
                endcli()
                readParameterSettings()
                updateParameter()
            End If
        ElseIf tabMain.SelectedTab Is tpRCSetting Then
            LastReceived = Now
            endcli()
            If isConnected = True Then
                Me.timerRealtime.Interval = iRefreshIntervals(Me.cmbRefreshRate.SelectedIndex)
                isRealtime = True
                timerRealtime.Start()
            End If
        ElseIf tabMain.SelectedTab Is tpRealtime Then
            LastReceived = Now
            endcli()
            If isConnected = True Then
                serialPort.ReadExisting()
                Me.timerRealtime.Interval = iRefreshIntervals(Me.cmbRefreshRate.SelectedIndex)
                isRealtime = True
                timerRealtime.Start()
            End If
        ElseIf tabMain.SelectedTab Is tpMap Then
            LastReceived = Now
            endcli()
            Me.cmdLoadSettings.Text = lngLoadWayPoints
            Me.cmdSaveSettings.Text = lngSaveWayPoints
            Me.cmdLoadSettings.Enabled = True
            Me.cmdSaveSettings.Enabled = True

            'Me.MinimizeBox = False
            Me.timerRealtime.Interval = 100 'GPS only every 0.5 sec. iRefreshIntervals(Me.cmbRefreshRate.SelectedIndex)
            If isConnected = True Then
                isRealtime = True
                timerRealtime.Start()
            End If
        ElseIf tabMain.SelectedTab Is tpPassGPS Then
            startPassGPS()
            timerRealtime.Start()
        ElseIf tabMain.SelectedTab Is tpCLI Then
            isCLI = True
            timerRealtime.Stop()    'Stop logging! otherwise CLI didn't work!
            startCLI()
        ElseIf tabMain.SelectedTab Is tpGFWUpdate Then
            timerRealtime.Stop()    'Stop logging! otherwise Firmware update didn't work!
            endcli()
            initFirmwareUpdate()
        End If
    End Sub

    Delegate Sub ShowRDataCallback(ByVal Text As String)
    Private Sub DataReceivedHandler(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs)
        If isClosing = True Then Exit Sub
        LastReceived = Now
        If isRealtime = True Then
            readCOM()
        ElseIf isCLI = True Then
            Try
                System.Threading.Thread.Sleep(200)
                Do While serialPort.BytesToRead > 0
                    cliBuffer = serialPort.ReadExisting()
                    Dim MyDelegate As New ShowRDataCallback(AddressOf ShowRData)
                    Me.txtCLIResult.Invoke(MyDelegate, cliBuffer)
                Loop
                If cliBuffer.ToLower.Contains("rebooting") Then
                    isCLI = False
                    Dim MyDelegateTab As New ShowRDataCallback(AddressOf setDelegateTab)
                    Me.tabMain.Invoke(MyDelegateTab, "")
                End If
            Catch ex As Exception
                lostConnection()
            End Try
        ElseIf isPASSGPS = True Then
            ReadGPS()
        End If
    End Sub

    Private Sub ShowRData(ByVal Text As String)
        Me.txtCLIResult.AppendText(filterIncomingBuffer(Text))
        Me.txtCLIResult.ScrollToCaret()
    End Sub

    Private Sub setDelegateTab(ByVal Text As String)
        lblParameterWarning.Text = lngRebooting
        lblParameterWarning.Visible = True
        lblMapWarning.Text = lngRebooting
        lblMapWarning.Visible = True
        lblRealtimeWarning.Text = lngRebooting
        lblRealtimeWarning.Visible = True
        lblRCWarning.Text = lngRebooting
        lblRCWarning.Visible = True
        If IsNothing(selectedTab) = True Then
            selectedTab = tpParameter
        End If
        Me.tabMain.SelectedTab = selectedTab
        Timeout = RebootTimeout
        fcCount = 3
        Application.DoEvents()
    End Sub

    Private Sub cmdRefreshCOM_Click(sender As Object, e As EventArgs) Handles cmdRefreshCOM.Click
        initCOMPorts()
    End Sub

    Private Sub cmbCOMSpeed_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCOMSpeed.SelectedIndexChanged
        ini.Write("COM", "DefaultSerialSpeed", Me.cmbCOMSpeed.SelectedItem)
    End Sub

    Private Sub cmbCOMPort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCOMPort.SelectedIndexChanged
        If isStartup = True Then Exit Sub
        Try
            Dim port As String = Me.cmbCOMPort.ComboBox.SelectedValue
            If Me.cmbCOMPort.ComboBox.SelectedItem("Description").ToString.ToLower.Contains("bluetooth") Then
                isBluetooth = True
            Else
                isBluetooth = False
            End If
            ini.Write("COM", "DefaultPort", port)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdConnect_Click(sender As Object, e As EventArgs) Handles cmdConnect.Click
        AddHandler serialPort.DataReceived, AddressOf DataReceivedHandler
        Me.lblRealtimeWarning.Visible = False
        Me.lblMapWarning.Visible = False
        Me.lblRCWarning.Visible = False
        Me.lblParameterWarning.Visible = False
        If serialPort.IsOpen = True Then
            If isCLI = True Then
                serialPort.Write("exit" & vbCrLf)
                serialPort.ReadExisting()
                isCLI = False
            End If
            disconnectCOM()
            setButtons(False)
        Else
            If Not tabMain.SelectedTab Is Me.tpPassGPS Then
                Me.tabMain.SelectedTab = Me.tpParameter
                serial_error_count = 0
                serial_packet_count = 0
                setButtons(True)
                If connectCOM() = True Then
                    readBaseflightBasics()
                    'readSettings()
                    setTAB()
                Else
                    setButtons(False)
                End If
            Else
                isPASSGPS = True
                serialPort.PortName = Me.cmbCOMPort.ComboBox.SelectedValue
                serialPort.BaudRate = CInt(Me.cmbCOMSpeed.Text)
                serialPort.Open()
                Me.timerRealtime.Interval = iRefreshIntervals(Me.cmbRefreshRate.SelectedIndex)
                timerRealtime.Enabled = True
                timerRealtime.Start()
                Me.cmdConnect.Text = "PassGPS"
                Me.cmdConnect.Image = Global.BaseflightGUI.My.Resources.Resources.gps_green_x32
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
                updateParameter()  'fillParameter2GUI()
                sConfigFolder = System.IO.Path.GetDirectoryName(ofdLoadParameters.FileName)
                ini.Write("GUI", "ConfigFolder", sConfigFolder)
            End If
        End If
    End Sub

    Private Sub cmdUpdateOnlineHelp_Click(sender As Object, e As EventArgs) Handles cmdUpdateOnlineHelp.Click
        DownloadHelpXML()
    End Sub

    Dim isClosing As Boolean = False
    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        isClosing = True
        ini.Write("COM", "ComTimeout", comTimeOut)
        ini.Write("COM", "RebootTimeout", RebootTimeout)
        ini.Write("COM", "USBTimeout", USBTimeout)
        ini.Write("COM", "BluetoothTimeout", BluetoothTimeout)
        Try
            If isCLI = True Then
                endcli()
            End If
            If serialPort.IsOpen = True Then
                serialPort.Close()
            End If
        Catch ex As Exception

        End Try
        Application.Exit()
    End Sub

    Public Sub updateStatus()
        Me.lblVPacketReceived.Text = serial_packet_count
        Me.lblVPacketError.Text = serial_error_count
        Application.DoEvents()
    End Sub

    Private Sub readSettings()
        timerRealtime.Stop()
        isRealtime = False
        Timeout = 120
        fcCount = 5
        System.Threading.Thread.Sleep(200)
        serialPort.ReadExisting()
        If tabMain.SelectedTab Is tpMap Then
            readWayPointSettings()
        Else
            readParameterSettings()
        End If
        LastReceived = Now
        setTAB()
    End Sub

    Private Sub writeSettings()
        timerRealtime.Stop()
        isRealtime = False
        Timeout = 120
        fcCount = 5
        System.Threading.Thread.Sleep(200)
        serialPort.ReadExisting()
        If tabMain.SelectedTab Is tpMap Then
            writeWayPointSettings()
        Else
            writeParameterSettings()
        End If
        LastReceived = Now
        setTAB()
    End Sub

    Friend lngMsgboxStopLogging As String = "Please stop logging first!"
    Private Sub tabMain_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles tabMain.Selecting
        If bKMLLogRunning Then
            If tabMain.SelectedTab Is tpCLI Or tabMain.SelectedTab Is tpGFWUpdate Then
                e.Cancel = True
                MessageBox.Show(Me, lngMsgboxStopLogging, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub tabMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabMain.SelectedIndexChanged
        If Not Me.tabMain.SelectedTab Is Me.tpCLI Then
            selectedTab = Me.tabMain.SelectedTab
        End If
        setTAB()
    End Sub

    Friend lngSaveSetting As String = "Save Setting"
    Friend lngLoadSetting As String = "Load Setting"
    Friend lngSaveWayPoints As String = "Save WayPoints"
    Friend lngLoadWayPoints As String = "Load WayPoints"
    Dim selectedTab As System.Windows.Forms.TabPage = Nothing
    Public Sub setButtons(ByVal value As Boolean)
        cmbCOMPort.Enabled = Not value
        cmbCOMSpeed.Enabled = Not value
        cmdRefreshCOM.Enabled = Not value
        cmdReadSettings.Enabled = value
        cmdResetSettings.Enabled = value
        cmdWriteSettings.Enabled = value
        cmdSaveSettings.Enabled = value
        cmdLoadSettings.Enabled = value
        cmdCalibrateMag.Enabled = value
        cmdCalibrateAcc.Enabled = value
        cmdCLIDefaults.Enabled = value
        cmdCLIDump.Enabled = value
        cmdCLIFeature.Enabled = value
        cmdCLIHelp.Enabled = value
        cmdCLILoad.Enabled = value
        cmdCLIMap.Enabled = value
        cmdCLISave.Enabled = value
        cmdCLISend.Enabled = value
        cmdCLIDump.Enabled = value
        cmdCLIMixer.Enabled = value
        cmdCLISet.Enabled = value
        cmdCLIStatus.Enabled = value
        cmdCLIVersion.Enabled = value
    End Sub

    'Private Sub updateGUI()
    '    If tabMain.SelectedTab Is tpParameter Then
    '        fillParameter2GUI()
    '    ElseIf tabMain.SelectedTab Is tpRCSetting Then
    '        fillParameter2GUI()
    '    ElseIf tabMain.SelectedTab Is tpRealtime Then
    '        updateTPRealtime()
    '    ElseIf tabMain.SelectedTab Is tpCLI Then

    '    ElseIf tabMain.SelectedTab Is tpGFWUpdate Then

    '    ElseIf tabMain.SelectedTab Is tpMap Then

    '    End If
    'End Sub

#Region "tpParameter"

    Private Sub numRoll_P_ValueChanged(sender As Object, e As EventArgs) Handles numRoll_P.ValueChanged, numRoll_I.ValueChanged, numRoll_D.ValueChanged, _
                                                                              numPitch_P.ValueChanged, numPitch_I.ValueChanged, numPitch_D.ValueChanged, _
                                                                              numYaw_P.ValueChanged, numYaw_I.ValueChanged, numYaw_D.ValueChanged, _
                                                                              numAltitude_P.ValueChanged, numAltitude_I.ValueChanged, numAltitude_D.ValueChanged, _
                                                                              numPosHold_P.ValueChanged, numPosHold_I.ValueChanged, _
                                                                              numPosHoldRate_P.ValueChanged, numPosHoldRate_I.ValueChanged, numPosHoldRate_D.ValueChanged, _
                                                                              numNavigationRate_P.ValueChanged, numNavigationRate_I.ValueChanged, numNavigationRate_D.ValueChanged, _
                                                                              numLevel_P.ValueChanged, numLevel_I.ValueChanged, numLevel_D.ValueChanged, _
                                                                              numMag_P.ValueChanged, _
                                                                              numVelocity_P.ValueChanged, numVelocity_I.ValueChanged, numVelocity_D.ValueChanged, _
                                                                              numRATE_rp.ValueChanged, _
                                                                              numRATE_yaw.ValueChanged, _
                                                                              numRATE_tpid.ValueChanged, _
                                                                              numPowerMeterAlarm.ValueChanged
        valueChange(sender, e)
    End Sub

    Private Sub tbrRCExpo_Scroll(sender As Object, e As EventArgs) Handles trbRCExpo.Scroll
        RCExpo_Scroll()
    End Sub

    Private Sub trbRCRate_Scroll(sender As Object, e As EventArgs) Handles trbRCRate.Scroll
        RCRate_Scroll()
    End Sub

    Private Sub numRCExpo_ValueChanged(sender As Object, e As EventArgs) Handles numRCExpo.ValueChanged
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
            If comError = False And isConnected = True Or isPASSGPS = True Then
                If isPASSGPS = False Then
                    If Timeout < 120 Then
                        Me.lblRealtimeWarning.Visible = False
                        Me.lblMapWarning.Visible = False
                        Me.lblRCWarning.Visible = False
                        Me.lblParameterWarning.Visible = False
                    End If
                    If isRealtime = True Then
                        If DateDiff(DateInterval.Second, LastReceived, Now) > Timeout Then
                            timeoutError()
                        End If
                    End If
                    If tabMain.SelectedTab Is tpParameter Then
                        If bKMLLogRunning Then askForMapData()
                    ElseIf tabMain.SelectedTab Is tpRCSetting Then
                        MSPquery(MSP_STATUS)
                        Me.lblV_cycletime.Text = [String].Format("{0:0000} µs", mw_gui.cycleTime)
                        MSPquery(MSP_RC)
                        'readCOM()
                        updateRCChannels()
                        updateRCControlSettings()
                        If bKMLLogRunning Then
                            askForMapData()
                            updateTPMap()
                        End If
                    ElseIf tabMain.SelectedTab Is tpRealtime Then
                        askForRealtimeValues()
                        updateTPRealtime()
                        If bKMLLogRunning Then
                            askForMapData()
                            updateTPMap()
                        End If
                    ElseIf tabMain.SelectedTab Is tpMap Then
                        askForMapData()
                        updateTPMap()
                    End If
                    Me.lblVPacketReceived.Text = serial_packet_count
                    Me.lblVPacketError.Text = serial_error_count
                Else
                    updatePassGPS()
                End If
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
        If frmMap.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If

        'Static lastclick As Double = 0
        'Dim ThisClick As Double = DateAndTime.Timer
        'If ThisClick > lastclick + 0.5 Then
        '    Me.lblCLIHelp.Text = "Help: T=Throttle A=Aileron E=Elevator R=Ruder / Example: MAP TAER1234"
        '    Me.txtCLICommand.AppendText("Map")
        'Else
        '    Me.txtCLICommand.Text = ""
        '    serialPort.Write("Map" & vbCr & vbLf)
        'End If
        'lastclick = DateAndTime.Timer
    End Sub

    Private Sub cmdMixer_Click(sender As Object, e As EventArgs) Handles cmdCLIMixer.Click
        If frmMixer.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If
    End Sub

    Private Sub cmdFeature_Click(sender As Object, e As EventArgs) Handles cmdCLIFeature.Click
        If "" = "" Then
            If frmFeature.ShowDialog = Windows.Forms.DialogResult.OK Then

            End If
        Else
            Static lastclick As Double = 0
            Dim ThisClick As Double = DateAndTime.Timer
            If ThisClick > lastclick + 0.5 Then
                Me.txtCLICommand.AppendText("Feature")
                setCLICmdEnterCommand()
            Else
                Me.txtCLICommand.Text = ""
                serialPort.Write("Feature" & vbCr & vbLf)
            End If
            lastclick = DateAndTime.Timer
        End If
    End Sub

    Private Sub cmdSet_Click(sender As Object, e As EventArgs) Handles cmdCLISet.Click
        If "" = "" Then
            If frmSet.ShowDialog = Windows.Forms.DialogResult.OK Then

            End If
        Else
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
        End If
    End Sub

    Private Sub cmdList_Click(sender As Object, e As EventArgs)
        Me.txtCLICommand.AppendText(" LIST")
        CLISendComamand()
    End Sub

    Friend lngMsgboxSaveDump As String = "Do you want to save the DUMP to disk?"
    Friend lngMsgboxQuestion As String = "Question"
    Private Sub cmdDump_Click(sender As Object, e As EventArgs) Handles cmdCLIDump.Click
        If MessageBox.Show(Me, lngMsgboxSaveDump, lngMsgboxQuestion, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim fd As New SaveFileDialog
            fd.InitialDirectory = sConfigFolder
            fd.FileName = Now.ToString("yyyyMMdd-HHmm") & ".txt"
            fd.DefaultExt = ".txt"
            fd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            If fd.ShowDialog = Windows.Forms.DialogResult.OK Then
                isCLI = False
                serialPort.Write("DUMP" & vbCr & vbLf)
                System.Threading.Thread.Sleep(500)
                Dim dump() As String = serialPort.ReadExisting().Split(vbCrLf)
                Dim lineNo As Integer = 0
                For Each line As String In dump
                    lineNo += 1
                    If lineNo > 2 Then
                        If line.Trim.Length > 0 Then
                            If line.Trim.Substring(0, 1) <> "#" Then
                                System.IO.File.AppendAllText(fd.FileName, line)
                            End If
                        End If
                    End If
                Next
                isCLI = True
            End If
        Else
            Me.txtCLICommand.Text = "DUMP"
            CLISendComamand()
        End If
    End Sub

    Private Sub cmdLoad_Click(sender As Object, e As EventArgs) Handles cmdCLILoad.Click
        loadCLIFile()
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdCLISave.Click
        Me.txtCLICommand.Text = "SAVE"
        CLISendComamand()
    End Sub

    Private Sub cmdCLISend_Click(sender As Object, e As EventArgs) Handles cmdCLISend.Click
        CLISendComamand()
    End Sub

    'Private Sub txtCLICommand_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCLICommand.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        CLISendComamand()
    '    ElseIf e.KeyCode = (Keys.Control Or Keys.E) Then
    '        CommandHistory()
    '    End If
    'End Sub

    Private Sub txtCLICommand_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCLICommand.KeyPress
        If isConnected = True Then
            If e.KeyChar = Convert.ToChar(13) Then
                CLISendComamand()
            ElseIf e.KeyChar = Convert.ToChar(5) Then
                CommandHistory()
            End If
        End If
    End Sub

#End Region

#Region "Realtime"

    Private Sub chk_acc_roll_CheckedChanged(sender As Object, e As EventArgs) Handles chk_acc_roll.CheckedChanged
        ini.Write("GUI", "acc_roll", Me.chk_acc_roll.Checked)
    End Sub

    Private Sub chk_acc_pitch_CheckedChanged(sender As Object, e As EventArgs) Handles chk_acc_pitch.CheckedChanged
        ini.Write("GUI", "acc_pitch", Me.chk_acc_pitch.Checked)
    End Sub

    Private Sub chk_acc_z_CheckedChanged(sender As Object, e As EventArgs) Handles chk_acc_z.CheckedChanged
        ini.Write("GUI", "acc_z", Me.chk_acc_z.Checked)
    End Sub

    Private Sub chk_gyro_roll_CheckedChanged(sender As Object, e As EventArgs) Handles chk_gyro_roll.CheckedChanged
        ini.Write("GUI", "gyro_roll", Me.chk_gyro_roll.Checked)
    End Sub

    Private Sub chk_gyro_pitch_CheckedChanged(sender As Object, e As EventArgs) Handles chk_gyro_pitch.CheckedChanged
        ini.Write("GUI", "gyro_pitch", Me.chk_gyro_pitch.Checked)
    End Sub

    Private Sub chk_gyro_yaw_CheckedChanged(sender As Object, e As EventArgs) Handles chk_gyro_yaw.CheckedChanged
        ini.Write("GUI", "gyro_yaw", Me.chk_gyro_yaw.Checked)
    End Sub

    Private Sub chk_mag_roll_CheckedChanged(sender As Object, e As EventArgs) Handles chk_mag_roll.CheckedChanged
        ini.Write("GUI", "mag_roll", Me.chk_mag_roll.Checked)
    End Sub

    Private Sub chk_mag_pitch_CheckedChanged(sender As Object, e As EventArgs) Handles chk_mag_pitch.CheckedChanged
        ini.Write("GUI", "mag_pitch", Me.chk_mag_pitch.Checked)
    End Sub

    Private Sub chk_mag_yaw_CheckedChanged(sender As Object, e As EventArgs) Handles chk_mag_yaw.CheckedChanged
        ini.Write("GUI", "mag_yaw", Me.chk_mag_yaw.Checked)
    End Sub

    Private Sub chk_alt_CheckedChanged(sender As Object, e As EventArgs) Handles chk_alt.CheckedChanged
        ini.Write("GUI", "alt", Me.chk_alt.Checked)
    End Sub

    Private Sub chk_head_CheckedChanged(sender As Object, e As EventArgs) Handles chk_head.CheckedChanged
        ini.Write("GUI", "head", Me.chk_head.Checked)
    End Sub

    Private Sub chk_dbg1_CheckedChanged(sender As Object, e As EventArgs) Handles chk_dbg1.CheckedChanged
        ini.Write("GUI", "dbg1", Me.chk_dbg1.Checked)
    End Sub

    Private Sub chk_dbg2_CheckedChanged(sender As Object, e As EventArgs) Handles chk_dbg2.CheckedChanged
        ini.Write("GUI", "dbg2", Me.chk_dbg2.Checked)
    End Sub

    Private Sub chk_dbg3_CheckedChanged(sender As Object, e As EventArgs) Handles chk_dbg3.CheckedChanged
        ini.Write("GUI", "dbg3", Me.chk_dbg3.Checked)
    End Sub

    Private Sub chk_dbg4_CheckedChanged(sender As Object, e As EventArgs) Handles chk_dbg4.CheckedChanged
        ini.Write("GUI", "dbg4", Me.chk_dbg4.Checked)
    End Sub

    Friend lngCalibrateAccelerometerBody As String = "Make sure that your copter is leveled!" & vbCrLf & "Press OK when ready, then keep copter steady for 5 seconds."
    Friend lngCalibrateAccelerometerHeader As String = "Calibrating Accelerometer"
    Private Sub cmdCalibrateAcc_Click(sender As Object, e As EventArgs) Handles cmdCalibrateAcc.Click
        If Not isConnected Then
            MessageBox.Show(Me, "You have to connect to the FC first!", "Not connected", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If MessageBox.Show(Me, lngCalibrateAccelerometerBody, lngCalibrateAccelerometerHeader, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
            MSPquery(MSP_ACC_CALIBRATION)
        End If
    End Sub

    Friend lngCalibrateMagBody As String = "After pressing OK please rotate your copter around all three axes" & vbCrLf & " at least a full 360° turn for each axes. You will have 1 minute to finish"
    Friend lngCalibrateMagHeader As String = "Calibrating Magnetometer"
    Private Sub cmdCalibrateMag_Click(sender As Object, e As EventArgs) Handles cmdCalibrateMag.Click
        If Not isConnected Then
            MessageBox.Show(Me, "You have to connect to the FC first!", "Not connected", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return
        End If

        If MessageBox.Show(Me, lngCalibrateMagBody, lngCalibrateMagHeader, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
            MSPquery(MSP_MAG_CALIBRATION)
            Timeout = 120
            fcCount = 5
            lblRealtimeWarning.Text = lngMagCalibaration
            lblRealtimeWarning.Visible = True
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
    Friend lngStartKMLLog As String = "Start GPS Log"
    Friend lngStopKMLLog As String = "Stop STOP Log"

    Private Sub cmdStart_KML_log_Click(sender As Object, e As EventArgs) Handles cmdStart_KML_log.Click
        If bKMLLogRunning Then
            cmdStart_KML_log.Text = lngStartKMLLog
            cmdStart_KML_log.BackColor = Color.Transparent
            Me.Refresh()
            closeKMLLog()
        Else
            openKMLLog()
            If bKMLLogRunning Then
                cmdStart_KML_log.Text = lngStopKMLLog
                cmdStart_KML_log.BackColor = Color.LightGray
                Me.Refresh()
            End If
        End If
    End Sub

    Private Sub initTPMap()
        Try
            ' config map             
            createDTWayPoints()

            Me.MainMap.MinZoom = 1
            Me.MainMap.MaxZoom = 20
            Me.tb_mapzoom.Value = iMapZoom

            Me.MainMap.CacheLocation = IO.Path.GetDirectoryName(Application.ExecutablePath) & "/mapcache/"

            Try
                pointLng = ini.ReadDouble("GPS", "Longtitude", 7.230758)
                pointLat = ini.ReadDouble("GPS", "Latitude", 51.462447)
            Catch ex As Exception
                pointLng = 7.230758
                pointLat = 51.462447
            End Try
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

            'Me.MainMap.ForceDoubleBuffer = True
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
            frmError.lastCommand = "initTPMap()"
            frmError.myEx = ex
            If frmError.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                System.Windows.Forms.Application.Exit()
            End If
        End Try
    End Sub

    Dim oldWP As GMap.NET.PointLatLng
    Dim wpNo As Integer = 0
    Private Sub dgWayPoints_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgWayPoints.CellClick, dgWayPoints.CellContentClick
        If isStartup = True Then Exit Sub
        If e.RowIndex > -1 Then
            isStartup = True
            Me.cmdWPUpdate.Enabled = False
            editWPDr = dtWayPoints.Select("WPNo = " & dgWayPoints.Item("colWPNumber", e.RowIndex).Value)(0)
            WayPoints.Markers.Clear()
            WayPoints.Markers.Add(New GMapMarkerWayPoint(New GMap.NET.PointLatLng(editWPDr("Lat"), editWPDr("Lon")), editWPDr("Heading"), 0, 0))

            Me.txtWPLat.Text = editWPDr("Lat")
            Me.txtWPLng.Text = editWPDr("Lon")
            Me.numWPAlt.Value = editWPDr("Alt")
            Me.numWPTimeToStay.Text = editWPDr("TimeToStay")
            Me.numWPParameter.Text = editWPDr("ActionParameter")
            Me.numWPNavFlagAction.Text = editWPDr("Action")
            Me.numWPHeading.Text = editWPDr("Heading")
            setMapCtrl(True)
            isStartup = False
        End If
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

    Private Sub picSaveAsHomePosition_Click(sender As Object, e As EventArgs) Handles picGoToHomePosition.Click
        GoToHomePosition()
    End Sub

    Private Sub cmdWPUpdate_Click(sender As Object, e As EventArgs) Handles cmdWPUpdate.Click
        Me.cmdWPUpdate.Enabled = False
        editWPDr("Lat") = Me.txtWPLat.Text
        editWPDr("Lon") = Me.txtWPLng.Text
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
            dr("Lon") = pointLng
            dr("Alt") = 0
            dr("Heading") = 0
            dr("TimeToStay") = 0
            dr("Action") = 0
            dr("ActionParameter") = 0
            dtWayPoints.Rows.Add(dr)
            editWPDr = dr
            WayPoints.Markers.Clear()
            Me.txtWPLat.Text = editWPDr("Lat")
            Me.txtWPLng.Text = editWPDr("Lon")
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
            If Control.ModifierKeys = Keys.ControlKey Then
                ini.Write("GPS", "Longtitude", pointLng)
                ini.Write("GPS", "Latitude", pointLat)
            Else
                isMouseDown = True
                isMouseDraging = False

                If currentMarker.IsVisible Then
                    currentMarker.Position = Me.MainMap.FromLocalToLatLng(e.X, e.Y)
                End If
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

    Public Sub updatePassGPS()
        Me.lblVPassGPS_Hz.Text = mw_gui.GPS_Hz
        Me.gbNAV_POSLLH.Text = "NAV_POSLLH (" & mw_gui.GPS_ms_POSLLH & " ms)"
        Me.gbNAV_SOL.Text = "NAV_SOL (" & mw_gui.GPS_ms_SOL & " ms)"
        Me.gbNAV_VELNED.Text = "NAV_VELNED (" & mw_gui.GPS_ms_VELNED & " ms)"
        Me.gbNAV_SVINFO.Text = "NAV_SVINFO (" & mw_gui.GPS_ms_SVINFO & " ms)"
        Me.lblSGPSError.Text = " |  GPS Error: " & mw_gui.GPS_Error
        Me.lblsGPSPktCount.Text = " |  GPS Packets: " & mw_gui.GPS_Count
        'NAV_POSLLH
        Me.lblVPassGPS_Altitude.Text = mw_gui.GPS_altitudeMSL
        Me.lblVPassGPS_Latitude.Text = (mw_gui.GPS_latitude / 10000000).ToString("#.000000")
        Me.lblVPassGPS_Longtitude.Text = (mw_gui.GPS_longitude / 10000000).ToString("#.000000")
        Me.lblVPassGPS_AltitudeMSL.Text = mw_gui.GPS_altitudeMSL
        Me.lblVPassGPS_Altitude.Text = mw_gui.GPS_altitude
        Me.lblVhAcc.Text = mw_gui.GPS_hAcc
        Me.lblVvAcc.Text = mw_gui.GPS_vAcc


        '- 0x00 = no fix
        '- 0x01 = dead reckoning only
        '- 0x02 = 2D-fix
        '- 0x03 = 3D-fix
        '- 0x04 = GPS + dead reckoning combined
        '- 0x05 = Time only fix
        '- 0x06..0xff = reserved
        Select Case mw_gui.GPS_fix
            Case 0
                Me.lblVPassGPS_FIX.Text = "--"
                Me.lblVPassGPS_FIX_Desc.Text = "no fix"
            Case 1
                Me.lblVPassGPS_FIX.Text = ".."
                Me.lblVPassGPS_FIX_Desc.Text = "dead reckoning only"
            Case 2
                Me.lblVPassGPS_FIX.Text = "2D"
                Me.lblVPassGPS_FIX_Desc.Text = ""
            Case 3
                Me.lblVPassGPS_FIX.Text = "3D"
                Me.lblVPassGPS_FIX_Desc.Text = ""
            Case 4
                Me.lblVPassGPS_FIX.Text = "++"
                Me.lblVPassGPS_FIX_Desc.Text = "GPS + dead reckoning combined"
            Case 5
                Me.lblVPassGPS_FIX.Text = "**"
                Me.lblVPassGPS_FIX_Desc.Text = "Time only fix"
            Case Else
                Me.lblVPassGPS_FIX.Text = "??"
                Me.lblVPassGPS_FIX_Desc.Text = "reserved"
        End Select
        Me.lblVPassGPS_FIX_Status.Text = mw_gui.GPS_fix_status
        Me.lblVecefx.Text = mw_gui.GPS_ecef_x
        Me.lblVecefy.Text = mw_gui.GPS_ecef_y
        Me.lblVecefz.Text = mw_gui.GPS_ecef_z
        Me.lblVpAcc.Text = mw_gui.GPS_position_accuracy_3d
        Me.lblVecefVX.Text = mw_gui.GPS_ecef_x_velocity
        Me.lblVecefVY.Text = mw_gui.GPS_ecef_y_velocity
        Me.lblVecefVZ.Text = mw_gui.GPS_ecef_z_velocity
        Me.lblVaAcc.Text = mw_gui.GPS_speed_accuracy
        Me.lblVpDOP.Text = mw_gui.GPS_position_DOP
        Me.lblVPassGPS_SATs.Text = mw_gui.GPS_numSat

        'NAV_VELNED
        Me.lblVvelN.Text = mw_gui.GPS_ned_north
        Me.lblVvelE.Text = mw_gui.GPS_ned_east
        Me.lblVvelD.Text = mw_gui.GPS_ned_down
        Me.lblVspeed.Text = mw_gui.GPS_speed_3d
        Me.lblVgSpeed.Text = mw_gui.GPS_speed_2d
        Me.lblVheading.Text = mw_gui.GPS_heading_2d
        Me.lblVsAcc.Text = mw_gui.GPS_speed_accuracy1
        Me.lblVcAcc.Text = mw_gui.GPS_heading_accuracy

        'NAV_SVINFO
        Me.lblVnumCh.Text = mw_gui.GPS_numCH
        If mw_gui.GPS_numCH > 0 Then
            Me.lblV01_SatID.Text = mw_gui.GPS_svid(0)
            Me.pbChn01.Value = mw_gui.GPS_cno(0)
            Me.pbChn01.BarColor1 = getCnoColor(mw_gui.GPS_quality(0))
        Else
            Me.lblV01_SatID.Text = 0
            Me.pbChn01.Value = 0
        End If
        If mw_gui.GPS_numCH > 1 Then
            Me.lblV02_SatID.Text = mw_gui.GPS_svid(1)
            Me.pbChn02.Value = mw_gui.GPS_cno(1)
            Me.pbChn02.BarColor1 = getCnoColor(mw_gui.GPS_quality(1))
        Else
            Me.lblV02_SatID.Text = 0
            Me.pbChn02.Value = 0
        End If
        If mw_gui.GPS_numCH > 2 Then
            Me.lblV03_SatID.Text = mw_gui.GPS_svid(2)
            Me.pbChn03.Value = mw_gui.GPS_cno(2)
            Me.pbChn03.BarColor1 = getCnoColor(mw_gui.GPS_quality(2))
        Else
            Me.lblV03_SatID.Text = 0
            Me.pbChn03.Value = 0
        End If
        If mw_gui.GPS_numCH > 3 Then
            Me.lblV04_SatID.Text = mw_gui.GPS_svid(3)
            Me.pbChn04.Value = mw_gui.GPS_cno(3)
            Me.pbChn04.BarColor1 = getCnoColor(mw_gui.GPS_quality(3))
        Else
            Me.lblV04_SatID.Text = 0
            Me.pbChn04.Value = 0
        End If
        If mw_gui.GPS_numCH > 4 Then
            Me.lblV05_SatID.Text = mw_gui.GPS_svid(4)
            Me.pbChn05.Value = mw_gui.GPS_cno(4)
            Me.pbChn05.BarColor1 = getCnoColor(mw_gui.GPS_quality(4))
        Else
            Me.lblV05_SatID.Text = 0
            Me.pbChn05.Value = 0
        End If
        If mw_gui.GPS_numCH > 5 Then
            Me.lblV06_SatID.Text = mw_gui.GPS_svid(5)
            Me.pbChn06.Value = mw_gui.GPS_cno(5)
            Me.pbChn06.BarColor1 = getCnoColor(mw_gui.GPS_quality(5))
        Else
            Me.lblV06_SatID.Text = 0
            Me.pbChn06.Value = 0
        End If
        If mw_gui.GPS_numCH > 6 Then
            Me.lblV07_SatID.Text = mw_gui.GPS_svid(6)
            Me.pbChn07.Value = mw_gui.GPS_cno(6)
            Me.pbChn07.BarColor1 = getCnoColor(mw_gui.GPS_quality(6))
        Else
            Me.lblV07_SatID.Text = 0
            Me.pbChn07.Value = 0
        End If
        If mw_gui.GPS_numCH > 7 Then
            Me.lblV08_SatID.Text = mw_gui.GPS_svid(7)
            Me.pbChn08.Value = mw_gui.GPS_cno(7)
            Me.pbChn08.BarColor1 = getCnoColor(mw_gui.GPS_quality(7))
        Else
            Me.lblV08_SatID.Text = 0
            Me.pbChn08.Value = 0
        End If
        If mw_gui.GPS_numCH > 8 Then
            Me.lblV09_SatID.Text = mw_gui.GPS_svid(8)
            Me.pbChn09.Value = mw_gui.GPS_cno(8)
            Me.pbChn09.BarColor1 = getCnoColor(mw_gui.GPS_quality(8))
        Else
            Me.lblV09_SatID.Text = 0
            Me.pbChn09.Value = 0
        End If
        If mw_gui.GPS_numCH > 9 Then
            Me.lblV10_SatID.Text = mw_gui.GPS_svid(9)
            Me.pbChn10.Value = mw_gui.GPS_cno(9)
            Me.pbChn10.BarColor1 = getCnoColor(mw_gui.GPS_quality(9))
        Else
            Me.lblV10_SatID.Text = 0
            Me.pbChn10.Value = 0
        End If
        If mw_gui.GPS_numCH > 10 Then
            Me.lblV11_SatID.Text = mw_gui.GPS_svid(10)
            Me.pbChn11.Value = mw_gui.GPS_cno(10)
            Me.pbChn11.BarColor1 = getCnoColor(mw_gui.GPS_quality(10))
        Else
            Me.lblV11_SatID.Text = 0
            Me.pbChn11.Value = 0
        End If
        If mw_gui.GPS_numCH > 11 Then
            Me.lblV12_SatID.Text = mw_gui.GPS_svid(11)
            Me.pbChn12.Value = mw_gui.GPS_cno(11)
            Me.pbChn12.BarColor1 = getCnoColor(mw_gui.GPS_quality(11))
        Else
            Me.lblV12_SatID.Text = 0
            Me.pbChn12.Value = 0
        End If
        If mw_gui.GPS_numCH > 12 Then
            Me.lblV13_SatID.Text = mw_gui.GPS_svid(12)
            Me.pbChn13.Value = mw_gui.GPS_cno(12)
            Me.pbChn13.BarColor1 = getCnoColor(mw_gui.GPS_quality(12))
        Else
            Me.lblV13_SatID.Text = 0
            Me.pbChn13.Value = 0
        End If
        If mw_gui.GPS_numCH > 13 Then
            Me.lblV14_SatID.Text = mw_gui.GPS_svid(13)
            Me.pbChn14.Value = mw_gui.GPS_cno(13)
            Me.pbChn14.BarColor1 = getCnoColor(mw_gui.GPS_quality(13))
        Else
            Me.lblV14_SatID.Text = 0
            Me.pbChn14.Value = 0
        End If
        If mw_gui.GPS_numCH > 14 Then
            Me.lblV15_SatID.Text = mw_gui.GPS_svid(14)
            Me.pbChn15.Value = mw_gui.GPS_cno(14)
            Me.pbChn15.BarColor1 = getCnoColor(mw_gui.GPS_quality(14))
        Else
            Me.lblV15_SatID.Text = 0
            Me.pbChn15.Value = 0
        End If
        If mw_gui.GPS_numCH > 15 Then
            Me.lblV16_SatID.Text = mw_gui.GPS_svid(15)
            Me.pbChn16.Value = mw_gui.GPS_cno(15)
            Me.pbChn16.BarColor1 = getCnoColor(mw_gui.GPS_quality(15))
        Else
            Me.lblV16_SatID.Text = 0
            Me.pbChn16.Value = 0
        End If
    End Sub

    Private Function getCnoColor(ByVal qualitiy As Integer) As System.Drawing.Color
        Dim result As System.Drawing.Color = Color.DarkGray
        Select Case qualitiy
            Case 0
            Case 1 'channel is searching
            Case 2 'signal aquired
                result = Color.DarkRed
            Case 3 'signal detected but unusable
                result = Color.Red
            Case 4 'code lock on signal
                result = Color.LightGreen
            Case Else 'code and carrier locked
                result = Color.Green
        End Select
        Return result
    End Function

#End Region

    Private Sub frmMain_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        'If Me.WindowState = FormWindowState.Minimized Then
        '    Me.WindowState = FormWindowState.Normal
        '    Me.timerRealtime.Enabled = False
        'Else
        '    Me.timerRealtime.Enabled = True
        'End If
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
