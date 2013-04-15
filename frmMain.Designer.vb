<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Friend Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.cmdRefreshCOM = New System.Windows.Forms.ToolStripButton()
        Me.lblPort = New System.Windows.Forms.ToolStripLabel()
        Me.cmbCOMPort = New System.Windows.Forms.ToolStripComboBox()
        Me.lblSpeed = New System.Windows.Forms.ToolStripLabel()
        Me.cmbCOMSpeed = New System.Windows.Forms.ToolStripComboBox()
        Me.cmdConnect = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdReadSettings = New System.Windows.Forms.ToolStripButton()
        Me.cmdWriteSettings = New System.Windows.Forms.ToolStripButton()
        Me.cmdResetSettings = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdSaveSettings = New System.Windows.Forms.ToolStripButton()
        Me.cmdLoadSettings = New System.Windows.Forms.ToolStripButton()
        Me.cmdExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdStart_KML_log = New System.Windows.Forms.ToolStripButton()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tpParameter = New System.Windows.Forms.TabPage()
        Me.lblPowerMeter = New System.Windows.Forms.Label()
        Me.lblFirmware = New System.Windows.Forms.Label()
        Me.lblVFirmware = New System.Windows.Forms.Label()
        Me.lblComment = New System.Windows.Forms.Label()
        Me.lblMax40Chars = New System.Windows.Forms.Label()
        Me.txtComment = New System.Windows.Forms.TextBox()
        Me.numAltitude_P = New System.Windows.Forms.NumericUpDown()
        Me.numAltitude_I = New System.Windows.Forms.NumericUpDown()
        Me.numAltitude_D = New System.Windows.Forms.NumericUpDown()
        Me.numLevel_P = New System.Windows.Forms.NumericUpDown()
        Me.numLevel_I = New System.Windows.Forms.NumericUpDown()
        Me.numLevel_D = New System.Windows.Forms.NumericUpDown()
        Me.numMag_P = New System.Windows.Forms.NumericUpDown()
        Me.numNavigationRate_D = New System.Windows.Forms.NumericUpDown()
        Me.numNavigationRate_I = New System.Windows.Forms.NumericUpDown()
        Me.numNavigationRate_P = New System.Windows.Forms.NumericUpDown()
        Me.numPitch_P = New System.Windows.Forms.NumericUpDown()
        Me.numPitch_I = New System.Windows.Forms.NumericUpDown()
        Me.numPitch_D = New System.Windows.Forms.NumericUpDown()
        Me.numPosHold_P = New System.Windows.Forms.NumericUpDown()
        Me.numPosHold_I = New System.Windows.Forms.NumericUpDown()
        Me.numPosHoldRate_P = New System.Windows.Forms.NumericUpDown()
        Me.numPosHoldRate_I = New System.Windows.Forms.NumericUpDown()
        Me.numPosHoldRate_D = New System.Windows.Forms.NumericUpDown()
        Me.numPowerMeterAlarm = New System.Windows.Forms.NumericUpDown()
        Me.numRCExpo = New System.Windows.Forms.NumericUpDown()
        Me.numRCRate = New System.Windows.Forms.NumericUpDown()
        Me.numRoll_D = New System.Windows.Forms.NumericUpDown()
        Me.numRoll_I = New System.Windows.Forms.NumericUpDown()
        Me.numRoll_P = New System.Windows.Forms.NumericUpDown()
        Me.numTEXPO = New System.Windows.Forms.NumericUpDown()
        Me.numTMID = New System.Windows.Forms.NumericUpDown()
        Me.numVelocity_D = New System.Windows.Forms.NumericUpDown()
        Me.numVelocity_I = New System.Windows.Forms.NumericUpDown()
        Me.numVelocity_P = New System.Windows.Forms.NumericUpDown()
        Me.numYaw_D = New System.Windows.Forms.NumericUpDown()
        Me.numYaw_I = New System.Windows.Forms.NumericUpDown()
        Me.numYaw_P = New System.Windows.Forms.NumericUpDown()
        Me.lblAltitude = New System.Windows.Forms.Label()
        Me.lblAltitude_D = New System.Windows.Forms.Label()
        Me.lblAltitude_I = New System.Windows.Forms.Label()
        Me.lblAltitude_P = New System.Windows.Forms.Label()
        Me.lblLevel = New System.Windows.Forms.Label()
        Me.lblLevel_D = New System.Windows.Forms.Label()
        Me.lblLevel_I = New System.Windows.Forms.Label()
        Me.lblLevel_P = New System.Windows.Forms.Label()
        Me.lblMag = New System.Windows.Forms.Label()
        Me.lblMag_P = New System.Windows.Forms.Label()
        Me.lblNavigationRate = New System.Windows.Forms.Label()
        Me.lblNavigationRate_P = New System.Windows.Forms.Label()
        Me.lblNavigationRate_I = New System.Windows.Forms.Label()
        Me.lblNavigationRate_D = New System.Windows.Forms.Label()
        Me.lblPitch = New System.Windows.Forms.Label()
        Me.lblPitch_D = New System.Windows.Forms.Label()
        Me.lblPitch_I = New System.Windows.Forms.Label()
        Me.lblPitch_P = New System.Windows.Forms.Label()
        Me.lblPosHold = New System.Windows.Forms.Label()
        Me.lblPosHold_P = New System.Windows.Forms.Label()
        Me.lblPosHold_I = New System.Windows.Forms.Label()
        Me.lblPosHoldRate = New System.Windows.Forms.Label()
        Me.lblPosHoldRate_P = New System.Windows.Forms.Label()
        Me.lblPosHoldRate_I = New System.Windows.Forms.Label()
        Me.lblPosHoldRate_D = New System.Windows.Forms.Label()
        Me.lblRCExpo = New System.Windows.Forms.Label()
        Me.lblRCRate = New System.Windows.Forms.Label()
        Me.lblRoll = New System.Windows.Forms.Label()
        Me.lblRoll_P = New System.Windows.Forms.Label()
        Me.lblRoll_I = New System.Windows.Forms.Label()
        Me.lblRoll_D = New System.Windows.Forms.Label()
        Me.lblVelocity = New System.Windows.Forms.Label()
        Me.lblVelocity_P = New System.Windows.Forms.Label()
        Me.lblVelocity_I = New System.Windows.Forms.Label()
        Me.lblVelocity_D = New System.Windows.Forms.Label()
        Me.lblYaw = New System.Windows.Forms.Label()
        Me.lblYaw_I = New System.Windows.Forms.Label()
        Me.lblYaw_P = New System.Windows.Forms.Label()
        Me.lblYaw_D = New System.Windows.Forms.Label()
        Me.lblTMID = New System.Windows.Forms.Label()
        Me.lblTEXPO = New System.Windows.Forms.Label()
        Me.trbRCRate = New System.Windows.Forms.TrackBar()
        Me.trbTEXPO = New System.Windows.Forms.TrackBar()
        Me.trbTMID = New System.Windows.Forms.TrackBar()
        Me.trbRCExpo = New System.Windows.Forms.TrackBar()
        Me.groupBox12 = New System.Windows.Forms.GroupBox()
        Me.lblThrottlePIDAttenuation = New System.Windows.Forms.Label()
        Me.lblYawRATE = New System.Windows.Forms.Label()
        Me.lblRollPitchRATE = New System.Windows.Forms.Label()
        Me.numRATE_tpid = New System.Windows.Forms.NumericUpDown()
        Me.numRATE_yaw = New System.Windows.Forms.NumericUpDown()
        Me.numRATE_rp = New System.Windows.Forms.NumericUpDown()
        Me.tpRCSetting = New System.Windows.Forms.TabPage()
        Me.pnMain = New System.Windows.Forms.Panel()
        Me.pnAUXChannels = New System.Windows.Forms.Panel()
        Me.spMain = New System.Windows.Forms.SplitContainer()
        Me.pnBoxNames = New System.Windows.Forms.Panel()
        Me.pnAUX = New System.Windows.Forms.Panel()
        Me.tpRealtime = New System.Windows.Forms.TabPage()
        Me.pnSensors = New System.Windows.Forms.Panel()
        Me.lblSensorOPTIC = New System.Windows.Forms.Label()
        Me.lblSensorSONAR = New System.Windows.Forms.Label()
        Me.lblSensorGPS = New System.Windows.Forms.Label()
        Me.lblSensorMAG = New System.Windows.Forms.Label()
        Me.lblSensorBARO = New System.Windows.Forms.Label()
        Me.lblSensorACC = New System.Windows.Forms.Label()
        Me.pnIndicator = New System.Windows.Forms.Panel()
        Me.label6 = New System.Windows.Forms.Label()
        Me.l_vbatt = New System.Windows.Forms.Label()
        Me.lblSonar = New System.Windows.Forms.Label()
        Me.lblTemp = New System.Windows.Forms.Label()
        Me.l_Sonar = New System.Windows.Forms.Label()
        Me.label7 = New System.Windows.Forms.Label()
        Me.l_Temp = New System.Windows.Forms.Label()
        Me.l_powersum = New System.Windows.Forms.Label()
        Me.lblDBG1 = New System.Windows.Forms.Label()
        Me.chk_dbg1 = New System.Windows.Forms.CheckBox()
        Me.lblVdbg1 = New System.Windows.Forms.Label()
        Me.chk_dbg2 = New System.Windows.Forms.CheckBox()
        Me.lblDBG2 = New System.Windows.Forms.Label()
        Me.lblVdbg2 = New System.Windows.Forms.Label()
        Me.chk_dbg3 = New System.Windows.Forms.CheckBox()
        Me.lblVdbg4 = New System.Windows.Forms.Label()
        Me.lblDBG3 = New System.Windows.Forms.Label()
        Me.lblDBG4 = New System.Windows.Forms.Label()
        Me.lblVdbg3 = New System.Windows.Forms.Label()
        Me.chk_dbg4 = New System.Windows.Forms.CheckBox()
        Me.lblValt = New System.Windows.Forms.Label()
        Me.lblVhead = New System.Windows.Forms.Label()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdUncheck_all_ACC = New System.Windows.Forms.Button()
        Me.cmdCheck_all_ACC = New System.Windows.Forms.Button()
        Me.lblVacc_z = New System.Windows.Forms.Label()
        Me.lblVacc_pitch = New System.Windows.Forms.Label()
        Me.lblVacc_roll = New System.Windows.Forms.Label()
        Me.lblACC_Z = New System.Windows.Forms.Label()
        Me.chk_acc_z = New System.Windows.Forms.CheckBox()
        Me.lblACC_PITCH = New System.Windows.Forms.Label()
        Me.chk_acc_pitch = New System.Windows.Forms.CheckBox()
        Me.lblACC_ROLL = New System.Windows.Forms.Label()
        Me.chk_acc_roll = New System.Windows.Forms.CheckBox()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdUncheck_all_GYRO = New System.Windows.Forms.Button()
        Me.cmdCheck_all_GYRO = New System.Windows.Forms.Button()
        Me.lblVgyro_yaw = New System.Windows.Forms.Label()
        Me.lblVgyro_pitch = New System.Windows.Forms.Label()
        Me.lblVgyro_roll = New System.Windows.Forms.Label()
        Me.lblGgyroYaw = New System.Windows.Forms.Label()
        Me.chk_gyro_yaw = New System.Windows.Forms.CheckBox()
        Me.lblGgyroPitch = New System.Windows.Forms.Label()
        Me.chk_gyro_pitch = New System.Windows.Forms.CheckBox()
        Me.lblGgyroRoll = New System.Windows.Forms.Label()
        Me.chk_gyro_roll = New System.Windows.Forms.CheckBox()
        Me.chk_alt = New System.Windows.Forms.CheckBox()
        Me.lblALT = New System.Windows.Forms.Label()
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdUncheck_all_MAG = New System.Windows.Forms.Button()
        Me.cmdCheck_all_MAG = New System.Windows.Forms.Button()
        Me.lblVmag_yaw = New System.Windows.Forms.Label()
        Me.lblVmag_pitch = New System.Windows.Forms.Label()
        Me.lblVmag_roll = New System.Windows.Forms.Label()
        Me.lblMAG_YAW = New System.Windows.Forms.Label()
        Me.chk_mag_yaw = New System.Windows.Forms.CheckBox()
        Me.lblMAG_Pitch = New System.Windows.Forms.Label()
        Me.chk_mag_pitch = New System.Windows.Forms.CheckBox()
        Me.lblMAG_roll = New System.Windows.Forms.Label()
        Me.chk_mag_roll = New System.Windows.Forms.CheckBox()
        Me.chk_head = New System.Windows.Forms.CheckBox()
        Me.lblHEAD = New System.Windows.Forms.Label()
        Me.pnRealtimeChannels = New System.Windows.Forms.Panel()
        Me.cmbRefreshRate = New System.Windows.Forms.ComboBox()
        Me.cmdCalibrateAcc = New System.Windows.Forms.Button()
        Me.lblRefreshRate = New System.Windows.Forms.Label()
        Me.cmdPause = New System.Windows.Forms.Button()
        Me.cmdCalibrateMag = New System.Windows.Forms.Button()
        Me.zgMonitor = New ZedGraph.ZedGraphControl()
        Me.tpMap = New System.Windows.Forms.TabPage()
        Me.txtWPComment = New System.Windows.Forms.TextBox()
        Me.MainMap = New GMap.NET.WindowsForms.GMapControl()
        Me.gbMapWayPoints = New System.Windows.Forms.GroupBox()
        Me.cmdWPUpdate = New System.Windows.Forms.Button()
        Me.cmdWPClear = New System.Windows.Forms.Button()
        Me.picWPHeading = New System.Windows.Forms.PictureBox()
        Me.numWPHeading = New System.Windows.Forms.NumericUpDown()
        Me.numWPParameter = New System.Windows.Forms.NumericUpDown()
        Me.numWPNavFlagAction = New System.Windows.Forms.NumericUpDown()
        Me.numWPTimeToStay = New System.Windows.Forms.NumericUpDown()
        Me.numWPAlt = New System.Windows.Forms.NumericUpDown()
        Me.txtWPLng = New System.Windows.Forms.TextBox()
        Me.txtWPLat = New System.Windows.Forms.TextBox()
        Me.lblWPHeading = New System.Windows.Forms.Label()
        Me.dgWayPoints = New System.Windows.Forms.DataGridView()
        Me.colWPNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colWPLat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colWPLng = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colWPAlt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colWPHeading = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colWPTimeToStay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblWPParameter = New System.Windows.Forms.Label()
        Me.lblWPNavFlagAction = New System.Windows.Forms.Label()
        Me.lblWPLng = New System.Windows.Forms.Label()
        Me.lblWPLat = New System.Windows.Forms.Label()
        Me.lblTimeToStay = New System.Windows.Forms.Label()
        Me.lblWPAlt = New System.Windows.Forms.Label()
        Me.cmbMapProviders = New System.Windows.Forms.ComboBox()
        Me.lblMapProvider = New System.Windows.Forms.Label()
        Me.tb_mapzoom = New System.Windows.Forms.TrackBar()
        Me.cmdClearRoute = New System.Windows.Forms.Button()
        Me.gpMapGPSLive = New System.Windows.Forms.GroupBox()
        Me.chkSetToLiveData = New System.Windows.Forms.CheckBox()
        Me.picGPS = New System.Windows.Forms.PictureBox()
        Me.lblGPS_lon = New System.Windows.Forms.Label()
        Me.lbl_GPS_numsat = New System.Windows.Forms.Label()
        Me.lblV_GPS_lat = New System.Windows.Forms.Label()
        Me.lblV_GPS_numsat = New System.Windows.Forms.Label()
        Me.lblSetMapToLiveData = New System.Windows.Forms.Label()
        Me.lbl_GPS_alt = New System.Windows.Forms.Label()
        Me.lblV_GPS_lon = New System.Windows.Forms.Label()
        Me.lblGPS_lat = New System.Windows.Forms.Label()
        Me.lblV_GPS_alt = New System.Windows.Forms.Label()
        Me.lblVMousePos = New System.Windows.Forms.Label()
        Me.tpCLI = New System.Windows.Forms.TabPage()
        Me.gbTerminal = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblSep1 = New System.Windows.Forms.Label()
        Me.cmdCLILoad = New System.Windows.Forms.Button()
        Me.lblCLIHelp = New System.Windows.Forms.Label()
        Me.cmdCLIDefaults = New System.Windows.Forms.Button()
        Me.cmdCLIMap = New System.Windows.Forms.Button()
        Me.cmdCLIVersion = New System.Windows.Forms.Button()
        Me.cmdCLIStatus = New System.Windows.Forms.Button()
        Me.cmdCLISave = New System.Windows.Forms.Button()
        Me.cmdCLIFeature = New System.Windows.Forms.Button()
        Me.cmdCLIDump = New System.Windows.Forms.Button()
        Me.cmdCLIList = New System.Windows.Forms.Button()
        Me.cmdCLISet = New System.Windows.Forms.Button()
        Me.cmdCLIClearScreen = New System.Windows.Forms.Button()
        Me.cmdCLIHelp = New System.Windows.Forms.Button()
        Me.cmdCLISend = New System.Windows.Forms.Button()
        Me.txtCLICommand = New System.Windows.Forms.TextBox()
        Me.txtCLIResult = New System.Windows.Forms.TextBox()
        Me.tpGFWUpdate = New System.Windows.Forms.TabPage()
        Me.chkFWShowOutput = New System.Windows.Forms.CheckBox()
        Me.chkFWSendR = New System.Windows.Forms.CheckBox()
        Me.lblFWError = New System.Windows.Forms.Label()
        Me.lblFWSuccessful = New System.Windows.Forms.Label()
        Me.cmdFWUpdate = New System.Windows.Forms.Button()
        Me.lblFWShowOutput = New System.Windows.Forms.Label()
        Me.txtFirmwareFile = New System.Windows.Forms.TextBox()
        Me.lblFWSendR = New System.Windows.Forms.Label()
        Me.lblFirmwareFile = New System.Windows.Forms.Label()
        Me.searchFirmwareFile = New System.Windows.Forms.Button()
        Me.timerRealtime = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblPacketReceived = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblVPacketReceived = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblVPacketError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblV_i2cerrors = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblV_cycletime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblSpring = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblUID = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblVUID = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblRT_THR = New System.Windows.Forms.Label()
        Me.lblRT_PITCH = New System.Windows.Forms.Label()
        Me.lblRT_ROLL = New System.Windows.Forms.Label()
        Me.lblRT_YAW = New System.Windows.Forms.Label()
        Me.lblRT_AUX1 = New System.Windows.Forms.Label()
        Me.lblRT_AUX2 = New System.Windows.Forms.Label()
        Me.lblRT_AUX3 = New System.Windows.Forms.Label()
        Me.lblRT_AUX4 = New System.Windows.Forms.Label()
        Me.lblRT_AUX5 = New System.Windows.Forms.Label()
        Me.lblRT_AUX6 = New System.Windows.Forms.Label()
        Me.lblRT_AUX7 = New System.Windows.Forms.Label()
        Me.lblRT_AUX8 = New System.Windows.Forms.Label()
        Me.pgbRT_THR = New CustomControls.ProgressBarCtrl()
        Me.lblVRT_THR = New System.Windows.Forms.Label()
        Me.lblVRT_PITCH = New System.Windows.Forms.Label()
        Me.pgbRT_PITCH = New CustomControls.ProgressBarCtrl()
        Me.lblVRT_ROLL = New System.Windows.Forms.Label()
        Me.pgbRT_ROLL = New CustomControls.ProgressBarCtrl()
        Me.lblVRT_YAW = New System.Windows.Forms.Label()
        Me.pgbRT_YAW = New CustomControls.ProgressBarCtrl()
        Me.lblVRT_AUX1 = New System.Windows.Forms.Label()
        Me.pgbRT_AUX1 = New CustomControls.ProgressBarCtrl()
        Me.lblVRT_AUX2 = New System.Windows.Forms.Label()
        Me.pgbRT_AUX2 = New CustomControls.ProgressBarCtrl()
        Me.lblVRT_AUX3 = New System.Windows.Forms.Label()
        Me.pgbRT_AUX3 = New CustomControls.ProgressBarCtrl()
        Me.lblVRT_AUX4 = New System.Windows.Forms.Label()
        Me.pgbRT_AUX4 = New CustomControls.ProgressBarCtrl()
        Me.lblVRT_AUX5 = New System.Windows.Forms.Label()
        Me.pgbRT_AUX5 = New CustomControls.ProgressBarCtrl()
        Me.lblVRT_AUX6 = New System.Windows.Forms.Label()
        Me.pgbRT_AUX6 = New CustomControls.ProgressBarCtrl()
        Me.lblVRT_AUX7 = New System.Windows.Forms.Label()
        Me.pgbRT_AUX7 = New CustomControls.ProgressBarCtrl()
        Me.lblVRT_AUX8 = New System.Windows.Forms.Label()
        Me.pgbRT_AUX8 = New CustomControls.ProgressBarCtrl()
        Me.Rc_expo_control1 = New BaseflightGUI.BaseflightGUIControls.rc_expo_control()
        Me.Throttle_expo_control1 = New BaseflightGUI.BaseflightGUIControls.throttle_expo_control()
        Me.lcAux = New BaseflightGUI.MRG.Controls.UI.LoadingCircle()
        Me.Motor = New BaseflightGUI.BaseflightGUIControls.BaseglightMotors()
        Me.ctrlHEADING = New BaseflightGUI.BaseflightGUIControls.heading_indicator()
        Me.ctrlGPS = New BaseflightGUI.BaseflightGUIControls.GpsIndicatorInstrumentControl()
        Me.ctrlHORIZON = New BaseflightGUI.BaseflightGUIControls.artifical_horizon()
        Me.LoadingCircle = New BaseflightGUI.MRG.Controls.UI.LoadingCircle()
        Me.pgbRC_AUX8 = New CustomControls.ProgressBarCtrl()
        Me.pgbRC_AUX7 = New CustomControls.ProgressBarCtrl()
        Me.pgbRC_AUX6 = New CustomControls.ProgressBarCtrl()
        Me.pgbRC_AUX5 = New CustomControls.ProgressBarCtrl()
        Me.pgbRC_AUX4 = New CustomControls.ProgressBarCtrl()
        Me.pgbRC_AUX3 = New CustomControls.ProgressBarCtrl()
        Me.pgbRC_AUX2 = New CustomControls.ProgressBarCtrl()
        Me.pgbRC_AUX1 = New CustomControls.ProgressBarCtrl()
        Me.pgbRC_YAW = New CustomControls.ProgressBarCtrl()
        Me.pgbRC_ROLL = New CustomControls.ProgressBarCtrl()
        Me.pgbRC_PITCH = New CustomControls.ProgressBarCtrl()
        Me.pgbRC_THR = New CustomControls.ProgressBarCtrl()
        Me.lblRC_AUX8 = New System.Windows.Forms.Label()
        Me.lblRC_AUX7 = New System.Windows.Forms.Label()
        Me.lblRC_AUX6 = New System.Windows.Forms.Label()
        Me.lblRC_AUX5 = New System.Windows.Forms.Label()
        Me.lblRC_AUX4 = New System.Windows.Forms.Label()
        Me.lblRC_AUX3 = New System.Windows.Forms.Label()
        Me.lblRC_AUX2 = New System.Windows.Forms.Label()
        Me.lblRC_AUX1 = New System.Windows.Forms.Label()
        Me.lblRC_YAW = New System.Windows.Forms.Label()
        Me.lblRC_ROLL = New System.Windows.Forms.Label()
        Me.lblRC_PITCH = New System.Windows.Forms.Label()
        Me.lblVRC_AUX8 = New System.Windows.Forms.Label()
        Me.lblVRC_AUX7 = New System.Windows.Forms.Label()
        Me.lblVRC_AUX6 = New System.Windows.Forms.Label()
        Me.lblVRC_AUX5 = New System.Windows.Forms.Label()
        Me.lblVRC_AUX4 = New System.Windows.Forms.Label()
        Me.lblVRC_AUX3 = New System.Windows.Forms.Label()
        Me.lblVRC_AUX2 = New System.Windows.Forms.Label()
        Me.lblVRC_AUX1 = New System.Windows.Forms.Label()
        Me.lblVRC_YAW = New System.Windows.Forms.Label()
        Me.lblVRC_ROLL = New System.Windows.Forms.Label()
        Me.lblVRC_PITCH = New System.Windows.Forms.Label()
        Me.lblVRC_THR = New System.Windows.Forms.Label()
        Me.lblRC_THR = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tpParameter.SuspendLayout()
        CType(Me.numAltitude_P, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAltitude_I, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAltitude_D, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLevel_P, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLevel_I, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLevel_D, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMag_P, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numNavigationRate_D, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numNavigationRate_I, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numNavigationRate_P, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPitch_P, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPitch_I, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPitch_D, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPosHold_P, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPosHold_I, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPosHoldRate_P, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPosHoldRate_I, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPosHoldRate_D, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPowerMeterAlarm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numRCExpo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numRCRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numRoll_D, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numRoll_I, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numRoll_P, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTEXPO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTMID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numVelocity_D, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numVelocity_I, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numVelocity_P, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numYaw_D, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numYaw_I, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numYaw_P, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trbRCRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trbTEXPO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trbTMID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trbRCExpo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox12.SuspendLayout()
        CType(Me.numRATE_tpid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numRATE_yaw, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numRATE_rp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpRCSetting.SuspendLayout()
        Me.pnMain.SuspendLayout()
        Me.pnAUXChannels.SuspendLayout()
        CType(Me.spMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spMain.Panel1.SuspendLayout()
        Me.spMain.Panel2.SuspendLayout()
        Me.spMain.SuspendLayout()
        Me.pnAUX.SuspendLayout()
        Me.tpRealtime.SuspendLayout()
        Me.pnSensors.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        Me.pnRealtimeChannels.SuspendLayout()
        Me.tpMap.SuspendLayout()
        Me.gbMapWayPoints.SuspendLayout()
        CType(Me.picWPHeading, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numWPHeading, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numWPParameter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numWPNavFlagAction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numWPTimeToStay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numWPAlt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgWayPoints, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tb_mapzoom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpMapGPSLive.SuspendLayout()
        CType(Me.picGPS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpCLI.SuspendLayout()
        Me.gbTerminal.SuspendLayout()
        Me.tpGFWUpdate.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdRefreshCOM, Me.lblPort, Me.cmbCOMPort, Me.lblSpeed, Me.cmbCOMSpeed, Me.cmdConnect, Me.ToolStripSeparator1, Me.cmdReadSettings, Me.cmdWriteSettings, Me.cmdResetSettings, Me.ToolStripSeparator2, Me.cmdSaveSettings, Me.cmdLoadSettings, Me.cmdExit, Me.ToolStripSeparator3, Me.cmdStart_KML_log})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1024, 54)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'cmdRefreshCOM
        '
        Me.cmdRefreshCOM.Image = Global.BaseflightGUI.My.Resources.Resources.Refresh_Page_32_n_p
        Me.cmdRefreshCOM.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdRefreshCOM.Name = "cmdRefreshCOM"
        Me.cmdRefreshCOM.Size = New System.Drawing.Size(39, 51)
        Me.cmdRefreshCOM.Text = "COM"
        Me.cmdRefreshCOM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'lblPort
        '
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(29, 51)
        Me.lblPort.Text = "Port"
        '
        'cmbCOMPort
        '
        Me.cmbCOMPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCOMPort.Name = "cmbCOMPort"
        Me.cmbCOMPort.Size = New System.Drawing.Size(75, 54)
        '
        'lblSpeed
        '
        Me.lblSpeed.Name = "lblSpeed"
        Me.lblSpeed.Size = New System.Drawing.Size(39, 51)
        Me.lblSpeed.Text = "Speed"
        '
        'cmbCOMSpeed
        '
        Me.cmbCOMSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCOMSpeed.Name = "cmbCOMSpeed"
        Me.cmbCOMSpeed.Size = New System.Drawing.Size(75, 54)
        '
        'cmdConnect
        '
        Me.cmdConnect.Image = Global.BaseflightGUI.My.Resources.Resources.Link_Add_32_n_p
        Me.cmdConnect.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdConnect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.Size = New System.Drawing.Size(56, 51)
        Me.cmdConnect.Text = "Connect"
        Me.cmdConnect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 54)
        '
        'cmdReadSettings
        '
        Me.cmdReadSettings.Image = Global.BaseflightGUI.My.Resources.Resources.Text_Document_Down_32_n_p
        Me.cmdReadSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdReadSettings.Name = "cmdReadSettings"
        Me.cmdReadSettings.Size = New System.Drawing.Size(77, 51)
        Me.cmdReadSettings.Text = "Read Setting"
        Me.cmdReadSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'cmdWriteSettings
        '
        Me.cmdWriteSettings.Image = Global.BaseflightGUI.My.Resources.Resources.Text_Document_Up_32_n_p
        Me.cmdWriteSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdWriteSettings.Name = "cmdWriteSettings"
        Me.cmdWriteSettings.Size = New System.Drawing.Size(79, 51)
        Me.cmdWriteSettings.Text = "Write Setting"
        Me.cmdWriteSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'cmdResetSettings
        '
        Me.cmdResetSettings.Image = Global.BaseflightGUI.My.Resources.Resources.Text_Document_Delete_32_n_p
        Me.cmdResetSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdResetSettings.Name = "cmdResetSettings"
        Me.cmdResetSettings.Size = New System.Drawing.Size(39, 51)
        Me.cmdResetSettings.Text = "Reset"
        Me.cmdResetSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 54)
        '
        'cmdSaveSettings
        '
        Me.cmdSaveSettings.Image = Global.BaseflightGUI.My.Resources.Resources.Text_Document_Save_32_n_p
        Me.cmdSaveSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdSaveSettings.Name = "cmdSaveSettings"
        Me.cmdSaveSettings.Size = New System.Drawing.Size(75, 51)
        Me.cmdSaveSettings.Text = "Save Setting"
        Me.cmdSaveSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'cmdLoadSettings
        '
        Me.cmdLoadSettings.Image = Global.BaseflightGUI.My.Resources.Resources.Folder_and_Text_Document_32_n_p
        Me.cmdLoadSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdLoadSettings.Name = "cmdLoadSettings"
        Me.cmdLoadSettings.Size = New System.Drawing.Size(77, 51)
        Me.cmdLoadSettings.Text = "Load Setting"
        Me.cmdLoadSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'cmdExit
        '
        Me.cmdExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.cmdExit.Image = Global.BaseflightGUI.My.Resources.Resources.Exit_Door_32_n_p
        Me.cmdExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(36, 51)
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 54)
        '
        'cmdStart_KML_log
        '
        Me.cmdStart_KML_log.Image = Global.BaseflightGUI.My.Resources.Resources.Web_Globe_32_n_p
        Me.cmdStart_KML_log.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdStart_KML_log.Name = "cmdStart_KML_log"
        Me.cmdStart_KML_log.Size = New System.Drawing.Size(82, 51)
        Me.cmdStart_KML_log.Text = "Start GPS Log"
        Me.cmdStart_KML_log.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tabMain
        '
        Me.tabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabMain.Controls.Add(Me.tpParameter)
        Me.tabMain.Controls.Add(Me.tpRCSetting)
        Me.tabMain.Controls.Add(Me.tpRealtime)
        Me.tabMain.Controls.Add(Me.tpMap)
        Me.tabMain.Controls.Add(Me.tpCLI)
        Me.tabMain.Controls.Add(Me.tpGFWUpdate)
        Me.tabMain.Location = New System.Drawing.Point(0, 54)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(1024, 486)
        Me.tabMain.TabIndex = 1
        '
        'tpParameter
        '
        Me.tpParameter.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tpParameter.Controls.Add(Me.lblPowerMeter)
        Me.tpParameter.Controls.Add(Me.lblFirmware)
        Me.tpParameter.Controls.Add(Me.lblVFirmware)
        Me.tpParameter.Controls.Add(Me.lblComment)
        Me.tpParameter.Controls.Add(Me.lblMax40Chars)
        Me.tpParameter.Controls.Add(Me.txtComment)
        Me.tpParameter.Controls.Add(Me.Rc_expo_control1)
        Me.tpParameter.Controls.Add(Me.Throttle_expo_control1)
        Me.tpParameter.Controls.Add(Me.numAltitude_P)
        Me.tpParameter.Controls.Add(Me.numAltitude_I)
        Me.tpParameter.Controls.Add(Me.numAltitude_D)
        Me.tpParameter.Controls.Add(Me.numLevel_P)
        Me.tpParameter.Controls.Add(Me.numLevel_I)
        Me.tpParameter.Controls.Add(Me.numLevel_D)
        Me.tpParameter.Controls.Add(Me.numMag_P)
        Me.tpParameter.Controls.Add(Me.numNavigationRate_D)
        Me.tpParameter.Controls.Add(Me.numNavigationRate_I)
        Me.tpParameter.Controls.Add(Me.numNavigationRate_P)
        Me.tpParameter.Controls.Add(Me.numPitch_P)
        Me.tpParameter.Controls.Add(Me.numPitch_I)
        Me.tpParameter.Controls.Add(Me.numPitch_D)
        Me.tpParameter.Controls.Add(Me.numPosHold_P)
        Me.tpParameter.Controls.Add(Me.numPosHold_I)
        Me.tpParameter.Controls.Add(Me.numPosHoldRate_P)
        Me.tpParameter.Controls.Add(Me.numPosHoldRate_I)
        Me.tpParameter.Controls.Add(Me.numPosHoldRate_D)
        Me.tpParameter.Controls.Add(Me.numPowerMeterAlarm)
        Me.tpParameter.Controls.Add(Me.numRCExpo)
        Me.tpParameter.Controls.Add(Me.numRCRate)
        Me.tpParameter.Controls.Add(Me.numRoll_D)
        Me.tpParameter.Controls.Add(Me.numRoll_I)
        Me.tpParameter.Controls.Add(Me.numRoll_P)
        Me.tpParameter.Controls.Add(Me.numTEXPO)
        Me.tpParameter.Controls.Add(Me.numTMID)
        Me.tpParameter.Controls.Add(Me.numVelocity_D)
        Me.tpParameter.Controls.Add(Me.numVelocity_I)
        Me.tpParameter.Controls.Add(Me.numVelocity_P)
        Me.tpParameter.Controls.Add(Me.numYaw_D)
        Me.tpParameter.Controls.Add(Me.numYaw_I)
        Me.tpParameter.Controls.Add(Me.numYaw_P)
        Me.tpParameter.Controls.Add(Me.lblAltitude)
        Me.tpParameter.Controls.Add(Me.lblAltitude_D)
        Me.tpParameter.Controls.Add(Me.lblAltitude_I)
        Me.tpParameter.Controls.Add(Me.lblAltitude_P)
        Me.tpParameter.Controls.Add(Me.lblLevel)
        Me.tpParameter.Controls.Add(Me.lblLevel_D)
        Me.tpParameter.Controls.Add(Me.lblLevel_I)
        Me.tpParameter.Controls.Add(Me.lblLevel_P)
        Me.tpParameter.Controls.Add(Me.lblMag)
        Me.tpParameter.Controls.Add(Me.lblMag_P)
        Me.tpParameter.Controls.Add(Me.lblNavigationRate)
        Me.tpParameter.Controls.Add(Me.lblNavigationRate_P)
        Me.tpParameter.Controls.Add(Me.lblNavigationRate_I)
        Me.tpParameter.Controls.Add(Me.lblNavigationRate_D)
        Me.tpParameter.Controls.Add(Me.lblPitch)
        Me.tpParameter.Controls.Add(Me.lblPitch_D)
        Me.tpParameter.Controls.Add(Me.lblPitch_I)
        Me.tpParameter.Controls.Add(Me.lblPitch_P)
        Me.tpParameter.Controls.Add(Me.lblPosHold)
        Me.tpParameter.Controls.Add(Me.lblPosHold_P)
        Me.tpParameter.Controls.Add(Me.lblPosHold_I)
        Me.tpParameter.Controls.Add(Me.lblPosHoldRate)
        Me.tpParameter.Controls.Add(Me.lblPosHoldRate_P)
        Me.tpParameter.Controls.Add(Me.lblPosHoldRate_I)
        Me.tpParameter.Controls.Add(Me.lblPosHoldRate_D)
        Me.tpParameter.Controls.Add(Me.lblRCExpo)
        Me.tpParameter.Controls.Add(Me.lblRCRate)
        Me.tpParameter.Controls.Add(Me.lblRoll)
        Me.tpParameter.Controls.Add(Me.lblRoll_P)
        Me.tpParameter.Controls.Add(Me.lblRoll_I)
        Me.tpParameter.Controls.Add(Me.lblRoll_D)
        Me.tpParameter.Controls.Add(Me.lblVelocity)
        Me.tpParameter.Controls.Add(Me.lblVelocity_P)
        Me.tpParameter.Controls.Add(Me.lblVelocity_I)
        Me.tpParameter.Controls.Add(Me.lblVelocity_D)
        Me.tpParameter.Controls.Add(Me.lblYaw)
        Me.tpParameter.Controls.Add(Me.lblYaw_I)
        Me.tpParameter.Controls.Add(Me.lblYaw_P)
        Me.tpParameter.Controls.Add(Me.lblYaw_D)
        Me.tpParameter.Controls.Add(Me.lblTMID)
        Me.tpParameter.Controls.Add(Me.lblTEXPO)
        Me.tpParameter.Controls.Add(Me.trbRCRate)
        Me.tpParameter.Controls.Add(Me.trbTEXPO)
        Me.tpParameter.Controls.Add(Me.trbTMID)
        Me.tpParameter.Controls.Add(Me.trbRCExpo)
        Me.tpParameter.Controls.Add(Me.groupBox12)
        Me.tpParameter.Location = New System.Drawing.Point(4, 22)
        Me.tpParameter.Name = "tpParameter"
        Me.tpParameter.Padding = New System.Windows.Forms.Padding(3)
        Me.tpParameter.Size = New System.Drawing.Size(1016, 460)
        Me.tpParameter.TabIndex = 0
        Me.tpParameter.Text = "Parameter"
        '
        'lblPowerMeter
        '
        Me.lblPowerMeter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPowerMeter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblPowerMeter.Location = New System.Drawing.Point(647, 382)
        Me.lblPowerMeter.Name = "lblPowerMeter"
        Me.lblPowerMeter.Size = New System.Drawing.Size(127, 13)
        Me.lblPowerMeter.TabIndex = 16
        Me.lblPowerMeter.Text = "Power Meter Alarm"
        '
        'lblFirmware
        '
        Me.lblFirmware.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirmware.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblFirmware.Location = New System.Drawing.Point(647, 292)
        Me.lblFirmware.Name = "lblFirmware"
        Me.lblFirmware.Size = New System.Drawing.Size(250, 13)
        Me.lblFirmware.TabIndex = 16
        Me.lblFirmware.Text = "Firmware Version"
        '
        'lblVFirmware
        '
        Me.lblVFirmware.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVFirmware.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblVFirmware.Location = New System.Drawing.Point(647, 309)
        Me.lblVFirmware.Name = "lblVFirmware"
        Me.lblVFirmware.Size = New System.Drawing.Size(250, 13)
        Me.lblVFirmware.TabIndex = 16
        Me.lblVFirmware.Text = "Firmware Version"
        '
        'lblComment
        '
        Me.lblComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblComment.Location = New System.Drawing.Point(647, 334)
        Me.lblComment.Name = "lblComment"
        Me.lblComment.Size = New System.Drawing.Size(86, 13)
        Me.lblComment.TabIndex = 16
        Me.lblComment.Text = "Comment"
        '
        'lblMax40Chars
        '
        Me.lblMax40Chars.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblMax40Chars.Location = New System.Drawing.Point(739, 334)
        Me.lblMax40Chars.Name = "lblMax40Chars"
        Me.lblMax40Chars.Size = New System.Drawing.Size(158, 16)
        Me.lblMax40Chars.TabIndex = 16
        Me.lblMax40Chars.Text = "max. 40 Character"
        Me.lblMax40Chars.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtComment
        '
        Me.txtComment.Location = New System.Drawing.Point(650, 353)
        Me.txtComment.MaxLength = 40
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(247, 20)
        Me.txtComment.TabIndex = 15
        '
        'numAltitude_P
        '
        Me.numAltitude_P.DecimalPlaces = 1
        Me.numAltitude_P.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numAltitude_P.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.numAltitude_P.Location = New System.Drawing.Point(31, 146)
        Me.numAltitude_P.Maximum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.numAltitude_P.Name = "numAltitude_P"
        Me.numAltitude_P.Size = New System.Drawing.Size(55, 20)
        Me.numAltitude_P.TabIndex = 0
        '
        'numAltitude_I
        '
        Me.numAltitude_I.DecimalPlaces = 3
        Me.numAltitude_I.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numAltitude_I.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.numAltitude_I.Location = New System.Drawing.Point(98, 146)
        Me.numAltitude_I.Maximum = New Decimal(New Integer() {250, 0, 0, 196608})
        Me.numAltitude_I.Name = "numAltitude_I"
        Me.numAltitude_I.Size = New System.Drawing.Size(55, 20)
        Me.numAltitude_I.TabIndex = 0
        '
        'numAltitude_D
        '
        Me.numAltitude_D.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numAltitude_D.Location = New System.Drawing.Point(168, 146)
        Me.numAltitude_D.Maximum = New Decimal(New Integer() {250, 0, 0, 0})
        Me.numAltitude_D.Name = "numAltitude_D"
        Me.numAltitude_D.Size = New System.Drawing.Size(55, 20)
        Me.numAltitude_D.TabIndex = 0
        '
        'numLevel_P
        '
        Me.numLevel_P.DecimalPlaces = 1
        Me.numLevel_P.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numLevel_P.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.numLevel_P.Location = New System.Drawing.Point(31, 302)
        Me.numLevel_P.Maximum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.numLevel_P.Name = "numLevel_P"
        Me.numLevel_P.Size = New System.Drawing.Size(55, 20)
        Me.numLevel_P.TabIndex = 0
        '
        'numLevel_I
        '
        Me.numLevel_I.DecimalPlaces = 3
        Me.numLevel_I.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numLevel_I.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.numLevel_I.Location = New System.Drawing.Point(98, 302)
        Me.numLevel_I.Maximum = New Decimal(New Integer() {250, 0, 0, 196608})
        Me.numLevel_I.Name = "numLevel_I"
        Me.numLevel_I.Size = New System.Drawing.Size(55, 20)
        Me.numLevel_I.TabIndex = 0
        '
        'numLevel_D
        '
        Me.numLevel_D.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numLevel_D.Location = New System.Drawing.Point(168, 302)
        Me.numLevel_D.Maximum = New Decimal(New Integer() {250, 0, 0, 0})
        Me.numLevel_D.Name = "numLevel_D"
        Me.numLevel_D.Size = New System.Drawing.Size(55, 20)
        Me.numLevel_D.TabIndex = 0
        '
        'numMag_P
        '
        Me.numMag_P.DecimalPlaces = 1
        Me.numMag_P.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numMag_P.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.numMag_P.Location = New System.Drawing.Point(31, 341)
        Me.numMag_P.Maximum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.numMag_P.Name = "numMag_P"
        Me.numMag_P.Size = New System.Drawing.Size(55, 20)
        Me.numMag_P.TabIndex = 0
        '
        'numNavigationRate_D
        '
        Me.numNavigationRate_D.DecimalPlaces = 3
        Me.numNavigationRate_D.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numNavigationRate_D.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.numNavigationRate_D.Location = New System.Drawing.Point(168, 263)
        Me.numNavigationRate_D.Maximum = New Decimal(New Integer() {250, 0, 0, 196608})
        Me.numNavigationRate_D.Name = "numNavigationRate_D"
        Me.numNavigationRate_D.Size = New System.Drawing.Size(55, 20)
        Me.numNavigationRate_D.TabIndex = 0
        '
        'numNavigationRate_I
        '
        Me.numNavigationRate_I.DecimalPlaces = 2
        Me.numNavigationRate_I.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numNavigationRate_I.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numNavigationRate_I.Location = New System.Drawing.Point(98, 263)
        Me.numNavigationRate_I.Maximum = New Decimal(New Integer() {250, 0, 0, 131072})
        Me.numNavigationRate_I.Name = "numNavigationRate_I"
        Me.numNavigationRate_I.Size = New System.Drawing.Size(55, 20)
        Me.numNavigationRate_I.TabIndex = 0
        '
        'numNavigationRate_P
        '
        Me.numNavigationRate_P.DecimalPlaces = 1
        Me.numNavigationRate_P.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numNavigationRate_P.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.numNavigationRate_P.Location = New System.Drawing.Point(31, 263)
        Me.numNavigationRate_P.Maximum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.numNavigationRate_P.Name = "numNavigationRate_P"
        Me.numNavigationRate_P.Size = New System.Drawing.Size(55, 20)
        Me.numNavigationRate_P.TabIndex = 0
        '
        'numPitch_P
        '
        Me.numPitch_P.DecimalPlaces = 1
        Me.numPitch_P.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPitch_P.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.numPitch_P.Location = New System.Drawing.Point(31, 68)
        Me.numPitch_P.Maximum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.numPitch_P.Name = "numPitch_P"
        Me.numPitch_P.Size = New System.Drawing.Size(55, 20)
        Me.numPitch_P.TabIndex = 0
        '
        'numPitch_I
        '
        Me.numPitch_I.DecimalPlaces = 3
        Me.numPitch_I.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPitch_I.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.numPitch_I.Location = New System.Drawing.Point(98, 68)
        Me.numPitch_I.Maximum = New Decimal(New Integer() {250, 0, 0, 196608})
        Me.numPitch_I.Name = "numPitch_I"
        Me.numPitch_I.Size = New System.Drawing.Size(55, 20)
        Me.numPitch_I.TabIndex = 0
        '
        'numPitch_D
        '
        Me.numPitch_D.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPitch_D.Location = New System.Drawing.Point(168, 68)
        Me.numPitch_D.Maximum = New Decimal(New Integer() {250, 0, 0, 0})
        Me.numPitch_D.Name = "numPitch_D"
        Me.numPitch_D.Size = New System.Drawing.Size(55, 20)
        Me.numPitch_D.TabIndex = 0
        '
        'numPosHold_P
        '
        Me.numPosHold_P.DecimalPlaces = 2
        Me.numPosHold_P.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPosHold_P.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numPosHold_P.Location = New System.Drawing.Point(31, 185)
        Me.numPosHold_P.Maximum = New Decimal(New Integer() {250, 0, 0, 131072})
        Me.numPosHold_P.Name = "numPosHold_P"
        Me.numPosHold_P.Size = New System.Drawing.Size(55, 20)
        Me.numPosHold_P.TabIndex = 0
        '
        'numPosHold_I
        '
        Me.numPosHold_I.DecimalPlaces = 1
        Me.numPosHold_I.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPosHold_I.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.numPosHold_I.Location = New System.Drawing.Point(98, 185)
        Me.numPosHold_I.Maximum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.numPosHold_I.Name = "numPosHold_I"
        Me.numPosHold_I.Size = New System.Drawing.Size(55, 20)
        Me.numPosHold_I.TabIndex = 0
        '
        'numPosHoldRate_P
        '
        Me.numPosHoldRate_P.DecimalPlaces = 1
        Me.numPosHoldRate_P.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPosHoldRate_P.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.numPosHoldRate_P.Location = New System.Drawing.Point(31, 224)
        Me.numPosHoldRate_P.Maximum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.numPosHoldRate_P.Name = "numPosHoldRate_P"
        Me.numPosHoldRate_P.Size = New System.Drawing.Size(55, 20)
        Me.numPosHoldRate_P.TabIndex = 0
        '
        'numPosHoldRate_I
        '
        Me.numPosHoldRate_I.DecimalPlaces = 2
        Me.numPosHoldRate_I.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPosHoldRate_I.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numPosHoldRate_I.Location = New System.Drawing.Point(98, 224)
        Me.numPosHoldRate_I.Maximum = New Decimal(New Integer() {250, 0, 0, 131072})
        Me.numPosHoldRate_I.Name = "numPosHoldRate_I"
        Me.numPosHoldRate_I.Size = New System.Drawing.Size(55, 20)
        Me.numPosHoldRate_I.TabIndex = 0
        '
        'numPosHoldRate_D
        '
        Me.numPosHoldRate_D.DecimalPlaces = 3
        Me.numPosHoldRate_D.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPosHoldRate_D.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.numPosHoldRate_D.Location = New System.Drawing.Point(168, 224)
        Me.numPosHoldRate_D.Maximum = New Decimal(New Integer() {250, 0, 0, 196608})
        Me.numPosHoldRate_D.Name = "numPosHoldRate_D"
        Me.numPosHoldRate_D.Size = New System.Drawing.Size(55, 20)
        Me.numPosHoldRate_D.TabIndex = 0
        '
        'numPowerMeterAlarm
        '
        Me.numPowerMeterAlarm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPowerMeterAlarm.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numPowerMeterAlarm.Location = New System.Drawing.Point(780, 380)
        Me.numPowerMeterAlarm.Name = "numPowerMeterAlarm"
        Me.numPowerMeterAlarm.Size = New System.Drawing.Size(50, 20)
        Me.numPowerMeterAlarm.TabIndex = 0
        '
        'numRCExpo
        '
        Me.numRCExpo.DecimalPlaces = 2
        Me.numRCExpo.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numRCExpo.Location = New System.Drawing.Point(375, 52)
        Me.numRCExpo.Maximum = New Decimal(New Integer() {250, 0, 0, 131072})
        Me.numRCExpo.Name = "numRCExpo"
        Me.numRCExpo.Size = New System.Drawing.Size(50, 20)
        Me.numRCExpo.TabIndex = 0
        '
        'numRCRate
        '
        Me.numRCRate.DecimalPlaces = 2
        Me.numRCRate.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numRCRate.Location = New System.Drawing.Point(375, 102)
        Me.numRCRate.Maximum = New Decimal(New Integer() {250, 0, 0, 131072})
        Me.numRCRate.Name = "numRCRate"
        Me.numRCRate.Size = New System.Drawing.Size(50, 20)
        Me.numRCRate.TabIndex = 0
        '
        'numRoll_D
        '
        Me.numRoll_D.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numRoll_D.Location = New System.Drawing.Point(168, 29)
        Me.numRoll_D.Maximum = New Decimal(New Integer() {250, 0, 0, 0})
        Me.numRoll_D.Name = "numRoll_D"
        Me.numRoll_D.Size = New System.Drawing.Size(55, 20)
        Me.numRoll_D.TabIndex = 0
        '
        'numRoll_I
        '
        Me.numRoll_I.DecimalPlaces = 3
        Me.numRoll_I.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numRoll_I.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.numRoll_I.Location = New System.Drawing.Point(98, 29)
        Me.numRoll_I.Maximum = New Decimal(New Integer() {250, 0, 0, 196608})
        Me.numRoll_I.Name = "numRoll_I"
        Me.numRoll_I.Size = New System.Drawing.Size(55, 20)
        Me.numRoll_I.TabIndex = 0
        '
        'numRoll_P
        '
        Me.numRoll_P.DecimalPlaces = 1
        Me.numRoll_P.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numRoll_P.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.numRoll_P.Location = New System.Drawing.Point(31, 29)
        Me.numRoll_P.Maximum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.numRoll_P.Name = "numRoll_P"
        Me.numRoll_P.Size = New System.Drawing.Size(55, 20)
        Me.numRoll_P.TabIndex = 0
        '
        'numTEXPO
        '
        Me.numTEXPO.DecimalPlaces = 2
        Me.numTEXPO.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numTEXPO.Location = New System.Drawing.Point(375, 290)
        Me.numTEXPO.Maximum = New Decimal(New Integer() {250, 0, 0, 131072})
        Me.numTEXPO.Name = "numTEXPO"
        Me.numTEXPO.Size = New System.Drawing.Size(50, 20)
        Me.numTEXPO.TabIndex = 0
        '
        'numTMID
        '
        Me.numTMID.DecimalPlaces = 2
        Me.numTMID.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numTMID.Location = New System.Drawing.Point(375, 240)
        Me.numTMID.Maximum = New Decimal(New Integer() {250, 0, 0, 131072})
        Me.numTMID.Name = "numTMID"
        Me.numTMID.Size = New System.Drawing.Size(50, 20)
        Me.numTMID.TabIndex = 0
        '
        'numVelocity_D
        '
        Me.numVelocity_D.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numVelocity_D.Location = New System.Drawing.Point(168, 380)
        Me.numVelocity_D.Maximum = New Decimal(New Integer() {250, 0, 0, 0})
        Me.numVelocity_D.Name = "numVelocity_D"
        Me.numVelocity_D.Size = New System.Drawing.Size(55, 20)
        Me.numVelocity_D.TabIndex = 0
        '
        'numVelocity_I
        '
        Me.numVelocity_I.DecimalPlaces = 3
        Me.numVelocity_I.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numVelocity_I.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.numVelocity_I.Location = New System.Drawing.Point(98, 380)
        Me.numVelocity_I.Maximum = New Decimal(New Integer() {250, 0, 0, 196608})
        Me.numVelocity_I.Name = "numVelocity_I"
        Me.numVelocity_I.Size = New System.Drawing.Size(55, 20)
        Me.numVelocity_I.TabIndex = 0
        '
        'numVelocity_P
        '
        Me.numVelocity_P.DecimalPlaces = 1
        Me.numVelocity_P.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numVelocity_P.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.numVelocity_P.Location = New System.Drawing.Point(31, 380)
        Me.numVelocity_P.Maximum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.numVelocity_P.Name = "numVelocity_P"
        Me.numVelocity_P.Size = New System.Drawing.Size(55, 20)
        Me.numVelocity_P.TabIndex = 0
        '
        'numYaw_D
        '
        Me.numYaw_D.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numYaw_D.Location = New System.Drawing.Point(168, 107)
        Me.numYaw_D.Maximum = New Decimal(New Integer() {250, 0, 0, 0})
        Me.numYaw_D.Name = "numYaw_D"
        Me.numYaw_D.Size = New System.Drawing.Size(55, 20)
        Me.numYaw_D.TabIndex = 0
        '
        'numYaw_I
        '
        Me.numYaw_I.DecimalPlaces = 3
        Me.numYaw_I.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numYaw_I.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.numYaw_I.Location = New System.Drawing.Point(98, 107)
        Me.numYaw_I.Maximum = New Decimal(New Integer() {250, 0, 0, 196608})
        Me.numYaw_I.Name = "numYaw_I"
        Me.numYaw_I.Size = New System.Drawing.Size(55, 20)
        Me.numYaw_I.TabIndex = 0
        '
        'numYaw_P
        '
        Me.numYaw_P.DecimalPlaces = 1
        Me.numYaw_P.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numYaw_P.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.numYaw_P.Location = New System.Drawing.Point(31, 107)
        Me.numYaw_P.Maximum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.numYaw_P.Name = "numYaw_P"
        Me.numYaw_P.Size = New System.Drawing.Size(55, 20)
        Me.numYaw_P.TabIndex = 0
        '
        'lblAltitude
        '
        Me.lblAltitude.AutoSize = True
        Me.lblAltitude.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAltitude.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblAltitude.Location = New System.Drawing.Point(31, 133)
        Me.lblAltitude.Name = "lblAltitude"
        Me.lblAltitude.Size = New System.Drawing.Size(50, 13)
        Me.lblAltitude.TabIndex = 1
        Me.lblAltitude.Text = "Altitude"
        '
        'lblAltitude_D
        '
        Me.lblAltitude_D.AutoSize = True
        Me.lblAltitude_D.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAltitude_D.Location = New System.Drawing.Point(153, 148)
        Me.lblAltitude_D.Name = "lblAltitude_D"
        Me.lblAltitude_D.Size = New System.Drawing.Size(15, 13)
        Me.lblAltitude_D.TabIndex = 1
        Me.lblAltitude_D.Text = "D"
        '
        'lblAltitude_I
        '
        Me.lblAltitude_I.AutoSize = True
        Me.lblAltitude_I.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAltitude_I.Location = New System.Drawing.Point(88, 148)
        Me.lblAltitude_I.Name = "lblAltitude_I"
        Me.lblAltitude_I.Size = New System.Drawing.Size(10, 13)
        Me.lblAltitude_I.TabIndex = 1
        Me.lblAltitude_I.Text = "I"
        '
        'lblAltitude_P
        '
        Me.lblAltitude_P.AutoSize = True
        Me.lblAltitude_P.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAltitude_P.Location = New System.Drawing.Point(19, 148)
        Me.lblAltitude_P.Name = "lblAltitude_P"
        Me.lblAltitude_P.Size = New System.Drawing.Size(14, 13)
        Me.lblAltitude_P.TabIndex = 1
        Me.lblAltitude_P.Text = "P"
        '
        'lblLevel
        '
        Me.lblLevel.AutoSize = True
        Me.lblLevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLevel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblLevel.Location = New System.Drawing.Point(31, 289)
        Me.lblLevel.Name = "lblLevel"
        Me.lblLevel.Size = New System.Drawing.Size(38, 13)
        Me.lblLevel.TabIndex = 1
        Me.lblLevel.Text = "Level"
        '
        'lblLevel_D
        '
        Me.lblLevel_D.AutoSize = True
        Me.lblLevel_D.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLevel_D.Location = New System.Drawing.Point(153, 304)
        Me.lblLevel_D.Name = "lblLevel_D"
        Me.lblLevel_D.Size = New System.Drawing.Size(15, 13)
        Me.lblLevel_D.TabIndex = 1
        Me.lblLevel_D.Text = "D"
        '
        'lblLevel_I
        '
        Me.lblLevel_I.AutoSize = True
        Me.lblLevel_I.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLevel_I.Location = New System.Drawing.Point(88, 304)
        Me.lblLevel_I.Name = "lblLevel_I"
        Me.lblLevel_I.Size = New System.Drawing.Size(10, 13)
        Me.lblLevel_I.TabIndex = 1
        Me.lblLevel_I.Text = "I"
        '
        'lblLevel_P
        '
        Me.lblLevel_P.AutoSize = True
        Me.lblLevel_P.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLevel_P.Location = New System.Drawing.Point(19, 304)
        Me.lblLevel_P.Name = "lblLevel_P"
        Me.lblLevel_P.Size = New System.Drawing.Size(14, 13)
        Me.lblLevel_P.TabIndex = 1
        Me.lblLevel_P.Text = "P"
        '
        'lblMag
        '
        Me.lblMag.AutoSize = True
        Me.lblMag.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMag.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblMag.Location = New System.Drawing.Point(31, 328)
        Me.lblMag.Name = "lblMag"
        Me.lblMag.Size = New System.Drawing.Size(31, 13)
        Me.lblMag.TabIndex = 1
        Me.lblMag.Text = "Mag"
        '
        'lblMag_P
        '
        Me.lblMag_P.AutoSize = True
        Me.lblMag_P.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMag_P.Location = New System.Drawing.Point(19, 343)
        Me.lblMag_P.Name = "lblMag_P"
        Me.lblMag_P.Size = New System.Drawing.Size(14, 13)
        Me.lblMag_P.TabIndex = 1
        Me.lblMag_P.Text = "P"
        '
        'lblNavigationRate
        '
        Me.lblNavigationRate.AutoSize = True
        Me.lblNavigationRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNavigationRate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblNavigationRate.Location = New System.Drawing.Point(31, 250)
        Me.lblNavigationRate.Name = "lblNavigationRate"
        Me.lblNavigationRate.Size = New System.Drawing.Size(99, 13)
        Me.lblNavigationRate.TabIndex = 1
        Me.lblNavigationRate.Text = "Navigation Rate"
        '
        'lblNavigationRate_P
        '
        Me.lblNavigationRate_P.AutoSize = True
        Me.lblNavigationRate_P.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNavigationRate_P.Location = New System.Drawing.Point(19, 265)
        Me.lblNavigationRate_P.Name = "lblNavigationRate_P"
        Me.lblNavigationRate_P.Size = New System.Drawing.Size(14, 13)
        Me.lblNavigationRate_P.TabIndex = 1
        Me.lblNavigationRate_P.Text = "P"
        '
        'lblNavigationRate_I
        '
        Me.lblNavigationRate_I.AutoSize = True
        Me.lblNavigationRate_I.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNavigationRate_I.Location = New System.Drawing.Point(88, 265)
        Me.lblNavigationRate_I.Name = "lblNavigationRate_I"
        Me.lblNavigationRate_I.Size = New System.Drawing.Size(10, 13)
        Me.lblNavigationRate_I.TabIndex = 1
        Me.lblNavigationRate_I.Text = "I"
        '
        'lblNavigationRate_D
        '
        Me.lblNavigationRate_D.AutoSize = True
        Me.lblNavigationRate_D.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNavigationRate_D.Location = New System.Drawing.Point(153, 265)
        Me.lblNavigationRate_D.Name = "lblNavigationRate_D"
        Me.lblNavigationRate_D.Size = New System.Drawing.Size(15, 13)
        Me.lblNavigationRate_D.TabIndex = 1
        Me.lblNavigationRate_D.Text = "D"
        '
        'lblPitch
        '
        Me.lblPitch.AutoSize = True
        Me.lblPitch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPitch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblPitch.Location = New System.Drawing.Point(31, 55)
        Me.lblPitch.Name = "lblPitch"
        Me.lblPitch.Size = New System.Drawing.Size(36, 13)
        Me.lblPitch.TabIndex = 1
        Me.lblPitch.Text = "Pitch"
        '
        'lblPitch_D
        '
        Me.lblPitch_D.AutoSize = True
        Me.lblPitch_D.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPitch_D.Location = New System.Drawing.Point(153, 70)
        Me.lblPitch_D.Name = "lblPitch_D"
        Me.lblPitch_D.Size = New System.Drawing.Size(15, 13)
        Me.lblPitch_D.TabIndex = 1
        Me.lblPitch_D.Text = "D"
        '
        'lblPitch_I
        '
        Me.lblPitch_I.AutoSize = True
        Me.lblPitch_I.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPitch_I.Location = New System.Drawing.Point(88, 70)
        Me.lblPitch_I.Name = "lblPitch_I"
        Me.lblPitch_I.Size = New System.Drawing.Size(10, 13)
        Me.lblPitch_I.TabIndex = 1
        Me.lblPitch_I.Text = "I"
        '
        'lblPitch_P
        '
        Me.lblPitch_P.AutoSize = True
        Me.lblPitch_P.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPitch_P.Location = New System.Drawing.Point(19, 70)
        Me.lblPitch_P.Name = "lblPitch_P"
        Me.lblPitch_P.Size = New System.Drawing.Size(14, 13)
        Me.lblPitch_P.TabIndex = 1
        Me.lblPitch_P.Text = "P"
        '
        'lblPosHold
        '
        Me.lblPosHold.AutoSize = True
        Me.lblPosHold.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPosHold.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblPosHold.Location = New System.Drawing.Point(31, 172)
        Me.lblPosHold.Name = "lblPosHold"
        Me.lblPosHold.Size = New System.Drawing.Size(54, 13)
        Me.lblPosHold.TabIndex = 1
        Me.lblPosHold.Text = "PosHold"
        '
        'lblPosHold_P
        '
        Me.lblPosHold_P.AutoSize = True
        Me.lblPosHold_P.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPosHold_P.Location = New System.Drawing.Point(19, 187)
        Me.lblPosHold_P.Name = "lblPosHold_P"
        Me.lblPosHold_P.Size = New System.Drawing.Size(14, 13)
        Me.lblPosHold_P.TabIndex = 1
        Me.lblPosHold_P.Text = "P"
        '
        'lblPosHold_I
        '
        Me.lblPosHold_I.AutoSize = True
        Me.lblPosHold_I.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPosHold_I.Location = New System.Drawing.Point(88, 187)
        Me.lblPosHold_I.Name = "lblPosHold_I"
        Me.lblPosHold_I.Size = New System.Drawing.Size(10, 13)
        Me.lblPosHold_I.TabIndex = 1
        Me.lblPosHold_I.Text = "I"
        '
        'lblPosHoldRate
        '
        Me.lblPosHoldRate.AutoSize = True
        Me.lblPosHoldRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPosHoldRate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblPosHoldRate.Location = New System.Drawing.Point(31, 211)
        Me.lblPosHoldRate.Name = "lblPosHoldRate"
        Me.lblPosHoldRate.Size = New System.Drawing.Size(81, 13)
        Me.lblPosHoldRate.TabIndex = 1
        Me.lblPosHoldRate.Text = "PosHoldRate"
        '
        'lblPosHoldRate_P
        '
        Me.lblPosHoldRate_P.AutoSize = True
        Me.lblPosHoldRate_P.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPosHoldRate_P.Location = New System.Drawing.Point(19, 226)
        Me.lblPosHoldRate_P.Name = "lblPosHoldRate_P"
        Me.lblPosHoldRate_P.Size = New System.Drawing.Size(14, 13)
        Me.lblPosHoldRate_P.TabIndex = 1
        Me.lblPosHoldRate_P.Text = "P"
        '
        'lblPosHoldRate_I
        '
        Me.lblPosHoldRate_I.AutoSize = True
        Me.lblPosHoldRate_I.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPosHoldRate_I.Location = New System.Drawing.Point(88, 226)
        Me.lblPosHoldRate_I.Name = "lblPosHoldRate_I"
        Me.lblPosHoldRate_I.Size = New System.Drawing.Size(10, 13)
        Me.lblPosHoldRate_I.TabIndex = 1
        Me.lblPosHoldRate_I.Text = "I"
        '
        'lblPosHoldRate_D
        '
        Me.lblPosHoldRate_D.AutoSize = True
        Me.lblPosHoldRate_D.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPosHoldRate_D.Location = New System.Drawing.Point(153, 226)
        Me.lblPosHoldRate_D.Name = "lblPosHoldRate_D"
        Me.lblPosHoldRate_D.Size = New System.Drawing.Size(15, 13)
        Me.lblPosHoldRate_D.TabIndex = 1
        Me.lblPosHoldRate_D.Text = "D"
        '
        'lblRCExpo
        '
        Me.lblRCExpo.AutoSize = True
        Me.lblRCExpo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRCExpo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblRCExpo.Location = New System.Drawing.Point(375, 39)
        Me.lblRCExpo.Name = "lblRCExpo"
        Me.lblRCExpo.Size = New System.Drawing.Size(56, 13)
        Me.lblRCExpo.TabIndex = 1
        Me.lblRCExpo.Text = "RC Expo"
        '
        'lblRCRate
        '
        Me.lblRCRate.AutoSize = True
        Me.lblRCRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRCRate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblRCRate.Location = New System.Drawing.Point(375, 89)
        Me.lblRCRate.Name = "lblRCRate"
        Me.lblRCRate.Size = New System.Drawing.Size(55, 13)
        Me.lblRCRate.TabIndex = 1
        Me.lblRCRate.Text = "RC Rate"
        '
        'lblRoll
        '
        Me.lblRoll.AutoSize = True
        Me.lblRoll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoll.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblRoll.Location = New System.Drawing.Point(31, 16)
        Me.lblRoll.Name = "lblRoll"
        Me.lblRoll.Size = New System.Drawing.Size(29, 13)
        Me.lblRoll.TabIndex = 1
        Me.lblRoll.Text = "Roll"
        '
        'lblRoll_P
        '
        Me.lblRoll_P.AutoSize = True
        Me.lblRoll_P.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoll_P.Location = New System.Drawing.Point(19, 31)
        Me.lblRoll_P.Name = "lblRoll_P"
        Me.lblRoll_P.Size = New System.Drawing.Size(14, 13)
        Me.lblRoll_P.TabIndex = 1
        Me.lblRoll_P.Text = "P"
        '
        'lblRoll_I
        '
        Me.lblRoll_I.AutoSize = True
        Me.lblRoll_I.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoll_I.Location = New System.Drawing.Point(88, 31)
        Me.lblRoll_I.Name = "lblRoll_I"
        Me.lblRoll_I.Size = New System.Drawing.Size(10, 13)
        Me.lblRoll_I.TabIndex = 1
        Me.lblRoll_I.Text = "I"
        '
        'lblRoll_D
        '
        Me.lblRoll_D.AutoSize = True
        Me.lblRoll_D.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoll_D.Location = New System.Drawing.Point(153, 31)
        Me.lblRoll_D.Name = "lblRoll_D"
        Me.lblRoll_D.Size = New System.Drawing.Size(15, 13)
        Me.lblRoll_D.TabIndex = 1
        Me.lblRoll_D.Text = "D"
        '
        'lblVelocity
        '
        Me.lblVelocity.AutoSize = True
        Me.lblVelocity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVelocity.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblVelocity.Location = New System.Drawing.Point(31, 367)
        Me.lblVelocity.Name = "lblVelocity"
        Me.lblVelocity.Size = New System.Drawing.Size(52, 13)
        Me.lblVelocity.TabIndex = 1
        Me.lblVelocity.Text = "Velocity"
        '
        'lblVelocity_P
        '
        Me.lblVelocity_P.AutoSize = True
        Me.lblVelocity_P.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVelocity_P.Location = New System.Drawing.Point(19, 382)
        Me.lblVelocity_P.Name = "lblVelocity_P"
        Me.lblVelocity_P.Size = New System.Drawing.Size(14, 13)
        Me.lblVelocity_P.TabIndex = 1
        Me.lblVelocity_P.Text = "P"
        '
        'lblVelocity_I
        '
        Me.lblVelocity_I.AutoSize = True
        Me.lblVelocity_I.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVelocity_I.Location = New System.Drawing.Point(88, 382)
        Me.lblVelocity_I.Name = "lblVelocity_I"
        Me.lblVelocity_I.Size = New System.Drawing.Size(10, 13)
        Me.lblVelocity_I.TabIndex = 1
        Me.lblVelocity_I.Text = "I"
        '
        'lblVelocity_D
        '
        Me.lblVelocity_D.AutoSize = True
        Me.lblVelocity_D.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVelocity_D.Location = New System.Drawing.Point(153, 382)
        Me.lblVelocity_D.Name = "lblVelocity_D"
        Me.lblVelocity_D.Size = New System.Drawing.Size(15, 13)
        Me.lblVelocity_D.TabIndex = 1
        Me.lblVelocity_D.Text = "D"
        '
        'lblYaw
        '
        Me.lblYaw.AutoSize = True
        Me.lblYaw.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYaw.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblYaw.Location = New System.Drawing.Point(31, 94)
        Me.lblYaw.Name = "lblYaw"
        Me.lblYaw.Size = New System.Drawing.Size(31, 13)
        Me.lblYaw.TabIndex = 1
        Me.lblYaw.Text = "Yaw"
        '
        'lblYaw_I
        '
        Me.lblYaw_I.AutoSize = True
        Me.lblYaw_I.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYaw_I.Location = New System.Drawing.Point(88, 109)
        Me.lblYaw_I.Name = "lblYaw_I"
        Me.lblYaw_I.Size = New System.Drawing.Size(10, 13)
        Me.lblYaw_I.TabIndex = 1
        Me.lblYaw_I.Text = "I"
        '
        'lblYaw_P
        '
        Me.lblYaw_P.AutoSize = True
        Me.lblYaw_P.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYaw_P.Location = New System.Drawing.Point(19, 109)
        Me.lblYaw_P.Name = "lblYaw_P"
        Me.lblYaw_P.Size = New System.Drawing.Size(14, 13)
        Me.lblYaw_P.TabIndex = 1
        Me.lblYaw_P.Text = "P"
        '
        'lblYaw_D
        '
        Me.lblYaw_D.AutoSize = True
        Me.lblYaw_D.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYaw_D.Location = New System.Drawing.Point(153, 109)
        Me.lblYaw_D.Name = "lblYaw_D"
        Me.lblYaw_D.Size = New System.Drawing.Size(15, 13)
        Me.lblYaw_D.TabIndex = 1
        Me.lblYaw_D.Text = "D"
        '
        'lblTMID
        '
        Me.lblTMID.AutoSize = True
        Me.lblTMID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTMID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTMID.Location = New System.Drawing.Point(372, 224)
        Me.lblTMID.Name = "lblTMID"
        Me.lblTMID.Size = New System.Drawing.Size(57, 13)
        Me.lblTMID.TabIndex = 1
        Me.lblTMID.Text = "Thr. MID"
        '
        'lblTEXPO
        '
        Me.lblTEXPO.AutoSize = True
        Me.lblTEXPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTEXPO.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTEXPO.Location = New System.Drawing.Point(372, 274)
        Me.lblTEXPO.Name = "lblTEXPO"
        Me.lblTEXPO.Size = New System.Drawing.Size(67, 13)
        Me.lblTEXPO.TabIndex = 1
        Me.lblTEXPO.Text = "Thr. EXPO"
        '
        'trbRCRate
        '
        Me.trbRCRate.AutoSize = False
        Me.trbRCRate.BackColor = System.Drawing.Color.WhiteSmoke
        Me.trbRCRate.Location = New System.Drawing.Point(375, 165)
        Me.trbRCRate.Maximum = 250
        Me.trbRCRate.Name = "trbRCRate"
        Me.trbRCRate.Size = New System.Drawing.Size(206, 20)
        Me.trbRCRate.TabIndex = 3
        Me.trbRCRate.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'trbTEXPO
        '
        Me.trbTEXPO.AutoSize = False
        Me.trbTEXPO.BackColor = System.Drawing.Color.WhiteSmoke
        Me.trbTEXPO.Location = New System.Drawing.Point(375, 353)
        Me.trbTEXPO.Maximum = 100
        Me.trbTEXPO.Name = "trbTEXPO"
        Me.trbTEXPO.Size = New System.Drawing.Size(206, 20)
        Me.trbTEXPO.TabIndex = 3
        Me.trbTEXPO.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'trbTMID
        '
        Me.trbTMID.AutoSize = False
        Me.trbTMID.BackColor = System.Drawing.Color.WhiteSmoke
        Me.trbTMID.Location = New System.Drawing.Point(375, 327)
        Me.trbTMID.Maximum = 100
        Me.trbTMID.Name = "trbTMID"
        Me.trbTMID.Size = New System.Drawing.Size(206, 20)
        Me.trbTMID.TabIndex = 3
        Me.trbTMID.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'trbRCExpo
        '
        Me.trbRCExpo.AutoSize = False
        Me.trbRCExpo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.trbRCExpo.Location = New System.Drawing.Point(375, 139)
        Me.trbRCExpo.Maximum = 100
        Me.trbRCExpo.Name = "trbRCExpo"
        Me.trbRCExpo.Size = New System.Drawing.Size(206, 20)
        Me.trbRCExpo.TabIndex = 3
        Me.trbRCExpo.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'groupBox12
        '
        Me.groupBox12.Controls.Add(Me.lblThrottlePIDAttenuation)
        Me.groupBox12.Controls.Add(Me.lblYawRATE)
        Me.groupBox12.Controls.Add(Me.lblRollPitchRATE)
        Me.groupBox12.Controls.Add(Me.numRATE_tpid)
        Me.groupBox12.Controls.Add(Me.numRATE_yaw)
        Me.groupBox12.Controls.Add(Me.numRATE_rp)
        Me.groupBox12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.groupBox12.Location = New System.Drawing.Point(650, 27)
        Me.groupBox12.Name = "groupBox12"
        Me.groupBox12.Size = New System.Drawing.Size(247, 95)
        Me.groupBox12.TabIndex = 9
        Me.groupBox12.TabStop = False
        Me.groupBox12.Text = "Rates/Expo"
        '
        'lblThrottlePIDAttenuation
        '
        Me.lblThrottlePIDAttenuation.AutoSize = True
        Me.lblThrottlePIDAttenuation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThrottlePIDAttenuation.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblThrottlePIDAttenuation.Location = New System.Drawing.Point(15, 70)
        Me.lblThrottlePIDAttenuation.Name = "lblThrottlePIDAttenuation"
        Me.lblThrottlePIDAttenuation.Size = New System.Drawing.Size(144, 13)
        Me.lblThrottlePIDAttenuation.TabIndex = 5
        Me.lblThrottlePIDAttenuation.Text = "Throttle PID attenuation"
        Me.lblThrottlePIDAttenuation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblYawRATE
        '
        Me.lblYawRATE.AutoSize = True
        Me.lblYawRATE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYawRATE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblYawRATE.Location = New System.Drawing.Point(15, 44)
        Me.lblYawRATE.Name = "lblYawRATE"
        Me.lblYawRATE.Size = New System.Drawing.Size(68, 13)
        Me.lblYawRATE.TabIndex = 4
        Me.lblYawRATE.Text = "Yaw RATE"
        Me.lblYawRATE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRollPitchRATE
        '
        Me.lblRollPitchRATE.AutoSize = True
        Me.lblRollPitchRATE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRollPitchRATE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblRollPitchRATE.Location = New System.Drawing.Point(15, 18)
        Me.lblRollPitchRATE.Name = "lblRollPitchRATE"
        Me.lblRollPitchRATE.Size = New System.Drawing.Size(101, 13)
        Me.lblRollPitchRATE.TabIndex = 3
        Me.lblRollPitchRATE.Text = "Roll/Pitch RATE"
        Me.lblRollPitchRATE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'numRATE_tpid
        '
        Me.numRATE_tpid.BackColor = System.Drawing.Color.White
        Me.numRATE_tpid.DecimalPlaces = 2
        Me.numRATE_tpid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numRATE_tpid.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numRATE_tpid.Location = New System.Drawing.Point(160, 68)
        Me.numRATE_tpid.Maximum = New Decimal(New Integer() {250, 0, 0, 131072})
        Me.numRATE_tpid.Name = "numRATE_tpid"
        Me.numRATE_tpid.Size = New System.Drawing.Size(68, 20)
        Me.numRATE_tpid.TabIndex = 2
        '
        'numRATE_yaw
        '
        Me.numRATE_yaw.BackColor = System.Drawing.Color.White
        Me.numRATE_yaw.DecimalPlaces = 2
        Me.numRATE_yaw.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numRATE_yaw.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numRATE_yaw.Location = New System.Drawing.Point(160, 42)
        Me.numRATE_yaw.Maximum = New Decimal(New Integer() {250, 0, 0, 131072})
        Me.numRATE_yaw.Name = "numRATE_yaw"
        Me.numRATE_yaw.Size = New System.Drawing.Size(68, 20)
        Me.numRATE_yaw.TabIndex = 1
        '
        'numRATE_rp
        '
        Me.numRATE_rp.BackColor = System.Drawing.Color.White
        Me.numRATE_rp.DecimalPlaces = 2
        Me.numRATE_rp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numRATE_rp.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numRATE_rp.Location = New System.Drawing.Point(160, 16)
        Me.numRATE_rp.Maximum = New Decimal(New Integer() {250, 0, 0, 131072})
        Me.numRATE_rp.Name = "numRATE_rp"
        Me.numRATE_rp.Size = New System.Drawing.Size(68, 20)
        Me.numRATE_rp.TabIndex = 0
        '
        'tpRCSetting
        '
        Me.tpRCSetting.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tpRCSetting.Controls.Add(Me.pnMain)
        Me.tpRCSetting.Location = New System.Drawing.Point(4, 22)
        Me.tpRCSetting.Name = "tpRCSetting"
        Me.tpRCSetting.Padding = New System.Windows.Forms.Padding(3)
        Me.tpRCSetting.Size = New System.Drawing.Size(1016, 460)
        Me.tpRCSetting.TabIndex = 1
        Me.tpRCSetting.Text = "RC Control Setting"
        '
        'pnMain
        '
        Me.pnMain.Controls.Add(Me.pnAUXChannels)
        Me.pnMain.Controls.Add(Me.spMain)
        Me.pnMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnMain.Location = New System.Drawing.Point(3, 3)
        Me.pnMain.Name = "pnMain"
        Me.pnMain.Size = New System.Drawing.Size(1010, 454)
        Me.pnMain.TabIndex = 0
        '
        'pnAUXChannels
        '
        Me.pnAUXChannels.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnAUXChannels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnAUXChannels.Controls.Add(Me.pgbRC_AUX8)
        Me.pnAUXChannels.Controls.Add(Me.pgbRC_AUX7)
        Me.pnAUXChannels.Controls.Add(Me.pgbRC_AUX6)
        Me.pnAUXChannels.Controls.Add(Me.pgbRC_AUX5)
        Me.pnAUXChannels.Controls.Add(Me.pgbRC_AUX4)
        Me.pnAUXChannels.Controls.Add(Me.pgbRC_AUX3)
        Me.pnAUXChannels.Controls.Add(Me.pgbRC_AUX2)
        Me.pnAUXChannels.Controls.Add(Me.pgbRC_AUX1)
        Me.pnAUXChannels.Controls.Add(Me.pgbRC_YAW)
        Me.pnAUXChannels.Controls.Add(Me.pgbRC_ROLL)
        Me.pnAUXChannels.Controls.Add(Me.pgbRC_PITCH)
        Me.pnAUXChannels.Controls.Add(Me.pgbRC_THR)
        Me.pnAUXChannels.Controls.Add(Me.lblRC_AUX8)
        Me.pnAUXChannels.Controls.Add(Me.lblRC_AUX7)
        Me.pnAUXChannels.Controls.Add(Me.lblRC_AUX6)
        Me.pnAUXChannels.Controls.Add(Me.lblRC_AUX5)
        Me.pnAUXChannels.Controls.Add(Me.lblRC_AUX4)
        Me.pnAUXChannels.Controls.Add(Me.lblRC_AUX3)
        Me.pnAUXChannels.Controls.Add(Me.lblRC_AUX2)
        Me.pnAUXChannels.Controls.Add(Me.lblRC_AUX1)
        Me.pnAUXChannels.Controls.Add(Me.lblRC_YAW)
        Me.pnAUXChannels.Controls.Add(Me.lblRC_ROLL)
        Me.pnAUXChannels.Controls.Add(Me.lblRC_PITCH)
        Me.pnAUXChannels.Controls.Add(Me.lblVRC_AUX8)
        Me.pnAUXChannels.Controls.Add(Me.lblVRC_AUX7)
        Me.pnAUXChannels.Controls.Add(Me.lblVRC_AUX6)
        Me.pnAUXChannels.Controls.Add(Me.lblVRC_AUX5)
        Me.pnAUXChannels.Controls.Add(Me.lblVRC_AUX4)
        Me.pnAUXChannels.Controls.Add(Me.lblVRC_AUX3)
        Me.pnAUXChannels.Controls.Add(Me.lblVRC_AUX2)
        Me.pnAUXChannels.Controls.Add(Me.lblVRC_AUX1)
        Me.pnAUXChannels.Controls.Add(Me.lblVRC_YAW)
        Me.pnAUXChannels.Controls.Add(Me.lblVRC_ROLL)
        Me.pnAUXChannels.Controls.Add(Me.lblVRC_PITCH)
        Me.pnAUXChannels.Controls.Add(Me.lblVRC_THR)
        Me.pnAUXChannels.Controls.Add(Me.lblRC_THR)
        Me.pnAUXChannels.Location = New System.Drawing.Point(788, 3)
        Me.pnAUXChannels.Name = "pnAUXChannels"
        Me.pnAUXChannels.Size = New System.Drawing.Size(219, 451)
        Me.pnAUXChannels.TabIndex = 1
        '
        'spMain
        '
        Me.spMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spMain.Location = New System.Drawing.Point(3, 3)
        Me.spMain.Name = "spMain"
        '
        'spMain.Panel1
        '
        Me.spMain.Panel1.Controls.Add(Me.pnBoxNames)
        '
        'spMain.Panel2
        '
        Me.spMain.Panel2.Controls.Add(Me.pnAUX)
        Me.spMain.Size = New System.Drawing.Size(780, 451)
        Me.spMain.SplitterDistance = 148
        Me.spMain.SplitterWidth = 6
        Me.spMain.TabIndex = 0
        '
        'pnBoxNames
        '
        Me.pnBoxNames.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnBoxNames.Location = New System.Drawing.Point(0, 0)
        Me.pnBoxNames.Name = "pnBoxNames"
        Me.pnBoxNames.Size = New System.Drawing.Size(146, 449)
        Me.pnBoxNames.TabIndex = 0
        '
        'pnAUX
        '
        Me.pnAUX.AutoScroll = True
        Me.pnAUX.Controls.Add(Me.lcAux)
        Me.pnAUX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnAUX.Location = New System.Drawing.Point(0, 0)
        Me.pnAUX.Name = "pnAUX"
        Me.pnAUX.Size = New System.Drawing.Size(624, 449)
        Me.pnAUX.TabIndex = 0
        '
        'tpRealtime
        '
        Me.tpRealtime.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tpRealtime.Controls.Add(Me.pnSensors)
        Me.tpRealtime.Controls.Add(Me.pnIndicator)
        Me.tpRealtime.Controls.Add(Me.label6)
        Me.tpRealtime.Controls.Add(Me.l_vbatt)
        Me.tpRealtime.Controls.Add(Me.lblSonar)
        Me.tpRealtime.Controls.Add(Me.lblTemp)
        Me.tpRealtime.Controls.Add(Me.l_Sonar)
        Me.tpRealtime.Controls.Add(Me.label7)
        Me.tpRealtime.Controls.Add(Me.l_Temp)
        Me.tpRealtime.Controls.Add(Me.l_powersum)
        Me.tpRealtime.Controls.Add(Me.lblDBG1)
        Me.tpRealtime.Controls.Add(Me.chk_dbg1)
        Me.tpRealtime.Controls.Add(Me.lblVdbg1)
        Me.tpRealtime.Controls.Add(Me.chk_dbg2)
        Me.tpRealtime.Controls.Add(Me.lblDBG2)
        Me.tpRealtime.Controls.Add(Me.lblVdbg2)
        Me.tpRealtime.Controls.Add(Me.chk_dbg3)
        Me.tpRealtime.Controls.Add(Me.lblVdbg4)
        Me.tpRealtime.Controls.Add(Me.lblDBG3)
        Me.tpRealtime.Controls.Add(Me.lblDBG4)
        Me.tpRealtime.Controls.Add(Me.lblVdbg3)
        Me.tpRealtime.Controls.Add(Me.chk_dbg4)
        Me.tpRealtime.Controls.Add(Me.lblValt)
        Me.tpRealtime.Controls.Add(Me.lblVhead)
        Me.tpRealtime.Controls.Add(Me.groupBox1)
        Me.tpRealtime.Controls.Add(Me.groupBox2)
        Me.tpRealtime.Controls.Add(Me.chk_alt)
        Me.tpRealtime.Controls.Add(Me.lblALT)
        Me.tpRealtime.Controls.Add(Me.groupBox3)
        Me.tpRealtime.Controls.Add(Me.chk_head)
        Me.tpRealtime.Controls.Add(Me.lblHEAD)
        Me.tpRealtime.Controls.Add(Me.pnRealtimeChannels)
        Me.tpRealtime.Controls.Add(Me.cmbRefreshRate)
        Me.tpRealtime.Controls.Add(Me.cmdCalibrateAcc)
        Me.tpRealtime.Controls.Add(Me.lblRefreshRate)
        Me.tpRealtime.Controls.Add(Me.cmdPause)
        Me.tpRealtime.Controls.Add(Me.cmdCalibrateMag)
        Me.tpRealtime.Controls.Add(Me.zgMonitor)
        Me.tpRealtime.Controls.Add(Me.Motor)
        Me.tpRealtime.Controls.Add(Me.ctrlHEADING)
        Me.tpRealtime.Controls.Add(Me.ctrlGPS)
        Me.tpRealtime.Controls.Add(Me.ctrlHORIZON)
        Me.tpRealtime.Location = New System.Drawing.Point(4, 22)
        Me.tpRealtime.Name = "tpRealtime"
        Me.tpRealtime.Size = New System.Drawing.Size(1016, 460)
        Me.tpRealtime.TabIndex = 2
        Me.tpRealtime.Text = "Realtime Data"
        '
        'pnSensors
        '
        Me.pnSensors.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnSensors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnSensors.Controls.Add(Me.lblSensorOPTIC)
        Me.pnSensors.Controls.Add(Me.lblSensorSONAR)
        Me.pnSensors.Controls.Add(Me.lblSensorGPS)
        Me.pnSensors.Controls.Add(Me.lblSensorMAG)
        Me.pnSensors.Controls.Add(Me.lblSensorBARO)
        Me.pnSensors.Controls.Add(Me.lblSensorACC)
        Me.pnSensors.Location = New System.Drawing.Point(715, 337)
        Me.pnSensors.Name = "pnSensors"
        Me.pnSensors.Size = New System.Drawing.Size(75, 120)
        Me.pnSensors.TabIndex = 122
        '
        'lblSensorOPTIC
        '
        Me.lblSensorOPTIC.BackColor = System.Drawing.Color.LightGray
        Me.lblSensorOPTIC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSensorOPTIC.Location = New System.Drawing.Point(4, 99)
        Me.lblSensorOPTIC.Name = "lblSensorOPTIC"
        Me.lblSensorOPTIC.Size = New System.Drawing.Size(65, 17)
        Me.lblSensorOPTIC.TabIndex = 121
        Me.lblSensorOPTIC.Text = "OPTIC"
        Me.lblSensorOPTIC.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSensorSONAR
        '
        Me.lblSensorSONAR.BackColor = System.Drawing.Color.LightGray
        Me.lblSensorSONAR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSensorSONAR.Location = New System.Drawing.Point(4, 80)
        Me.lblSensorSONAR.Name = "lblSensorSONAR"
        Me.lblSensorSONAR.Size = New System.Drawing.Size(65, 17)
        Me.lblSensorSONAR.TabIndex = 121
        Me.lblSensorSONAR.Text = "SONAR"
        Me.lblSensorSONAR.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSensorGPS
        '
        Me.lblSensorGPS.BackColor = System.Drawing.Color.LightGray
        Me.lblSensorGPS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSensorGPS.Location = New System.Drawing.Point(4, 61)
        Me.lblSensorGPS.Name = "lblSensorGPS"
        Me.lblSensorGPS.Size = New System.Drawing.Size(65, 17)
        Me.lblSensorGPS.TabIndex = 121
        Me.lblSensorGPS.Text = "GPS"
        Me.lblSensorGPS.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSensorMAG
        '
        Me.lblSensorMAG.BackColor = System.Drawing.Color.LightGray
        Me.lblSensorMAG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSensorMAG.Location = New System.Drawing.Point(4, 42)
        Me.lblSensorMAG.Name = "lblSensorMAG"
        Me.lblSensorMAG.Size = New System.Drawing.Size(65, 17)
        Me.lblSensorMAG.TabIndex = 121
        Me.lblSensorMAG.Text = "MAG"
        Me.lblSensorMAG.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSensorBARO
        '
        Me.lblSensorBARO.BackColor = System.Drawing.Color.LightGray
        Me.lblSensorBARO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSensorBARO.Location = New System.Drawing.Point(4, 23)
        Me.lblSensorBARO.Name = "lblSensorBARO"
        Me.lblSensorBARO.Size = New System.Drawing.Size(65, 17)
        Me.lblSensorBARO.TabIndex = 121
        Me.lblSensorBARO.Text = "BARO"
        Me.lblSensorBARO.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSensorACC
        '
        Me.lblSensorACC.BackColor = System.Drawing.Color.LightGray
        Me.lblSensorACC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSensorACC.Location = New System.Drawing.Point(4, 4)
        Me.lblSensorACC.Name = "lblSensorACC"
        Me.lblSensorACC.Size = New System.Drawing.Size(65, 17)
        Me.lblSensorACC.TabIndex = 121
        Me.lblSensorACC.Text = "ACC"
        Me.lblSensorACC.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnIndicator
        '
        Me.pnIndicator.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnIndicator.Location = New System.Drawing.Point(796, 337)
        Me.pnIndicator.Name = "pnIndicator"
        Me.pnIndicator.Size = New System.Drawing.Size(217, 120)
        Me.pnIndicator.TabIndex = 120
        '
        'label6
        '
        Me.label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label6.AutoSize = True
        Me.label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label6.Location = New System.Drawing.Point(500, 384)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(91, 15)
        Me.label6.TabIndex = 111
        Me.label6.Text = "Battery Voltage:"
        '
        'l_vbatt
        '
        Me.l_vbatt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.l_vbatt.AutoSize = True
        Me.l_vbatt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_vbatt.Location = New System.Drawing.Point(590, 384)
        Me.l_vbatt.Name = "l_vbatt"
        Me.l_vbatt.Size = New System.Drawing.Size(51, 15)
        Me.l_vbatt.TabIndex = 118
        Me.l_vbatt.Text = "0.0 volts"
        '
        'lblSonar
        '
        Me.lblSonar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSonar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSonar.Location = New System.Drawing.Point(510, 429)
        Me.lblSonar.Name = "lblSonar"
        Me.lblSonar.Size = New System.Drawing.Size(81, 15)
        Me.lblSonar.TabIndex = 112
        Me.lblSonar.Text = "Sonar:"
        Me.lblSonar.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTemp
        '
        Me.lblTemp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTemp.AutoSize = True
        Me.lblTemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTemp.Location = New System.Drawing.Point(510, 414)
        Me.lblTemp.Name = "lblTemp"
        Me.lblTemp.Size = New System.Drawing.Size(81, 15)
        Me.lblTemp.TabIndex = 113
        Me.lblTemp.Text = "Temperature:"
        '
        'l_Sonar
        '
        Me.l_Sonar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.l_Sonar.AutoSize = True
        Me.l_Sonar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_Sonar.Location = New System.Drawing.Point(590, 429)
        Me.l_Sonar.Name = "l_Sonar"
        Me.l_Sonar.Size = New System.Drawing.Size(34, 15)
        Me.l_Sonar.TabIndex = 115
        Me.l_Sonar.Text = "0 cm"
        '
        'label7
        '
        Me.label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label7.AutoSize = True
        Me.label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label7.Location = New System.Drawing.Point(517, 399)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(74, 15)
        Me.label7.TabIndex = 114
        Me.label7.Text = "Power Sum:"
        '
        'l_Temp
        '
        Me.l_Temp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.l_Temp.AutoSize = True
        Me.l_Temp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_Temp.Location = New System.Drawing.Point(590, 414)
        Me.l_Temp.Name = "l_Temp"
        Me.l_Temp.Size = New System.Drawing.Size(47, 15)
        Me.l_Temp.TabIndex = 116
        Me.l_Temp.Text = "23.0 C°"
        '
        'l_powersum
        '
        Me.l_powersum.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.l_powersum.AutoSize = True
        Me.l_powersum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_powersum.Location = New System.Drawing.Point(590, 399)
        Me.l_powersum.Name = "l_powersum"
        Me.l_powersum.Size = New System.Drawing.Size(35, 15)
        Me.l_powersum.TabIndex = 117
        Me.l_powersum.Text = "0000"
        '
        'lblDBG1
        '
        Me.lblDBG1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDBG1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lblDBG1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDBG1.ForeColor = System.Drawing.Color.Black
        Me.lblDBG1.Location = New System.Drawing.Point(505, 289)
        Me.lblDBG1.Name = "lblDBG1"
        Me.lblDBG1.Size = New System.Drawing.Size(41, 14)
        Me.lblDBG1.TabIndex = 100
        Me.lblDBG1.Text = "DBG1"
        '
        'chk_dbg1
        '
        Me.chk_dbg1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chk_dbg1.AutoSize = True
        Me.chk_dbg1.Location = New System.Drawing.Point(492, 289)
        Me.chk_dbg1.Name = "chk_dbg1"
        Me.chk_dbg1.Size = New System.Drawing.Size(15, 14)
        Me.chk_dbg1.TabIndex = 99
        Me.chk_dbg1.UseVisualStyleBackColor = True
        '
        'lblVdbg1
        '
        Me.lblVdbg1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblVdbg1.AutoSize = True
        Me.lblVdbg1.Location = New System.Drawing.Point(552, 290)
        Me.lblVdbg1.Name = "lblVdbg1"
        Me.lblVdbg1.Size = New System.Drawing.Size(13, 13)
        Me.lblVdbg1.TabIndex = 101
        Me.lblVdbg1.Text = "0"
        '
        'chk_dbg2
        '
        Me.chk_dbg2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chk_dbg2.AutoSize = True
        Me.chk_dbg2.Location = New System.Drawing.Point(492, 306)
        Me.chk_dbg2.Name = "chk_dbg2"
        Me.chk_dbg2.Size = New System.Drawing.Size(15, 14)
        Me.chk_dbg2.TabIndex = 102
        Me.chk_dbg2.UseVisualStyleBackColor = True
        '
        'lblDBG2
        '
        Me.lblDBG2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDBG2.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lblDBG2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDBG2.ForeColor = System.Drawing.Color.Black
        Me.lblDBG2.Location = New System.Drawing.Point(505, 306)
        Me.lblDBG2.Name = "lblDBG2"
        Me.lblDBG2.Size = New System.Drawing.Size(41, 14)
        Me.lblDBG2.TabIndex = 103
        Me.lblDBG2.Text = "DBG2"
        '
        'lblVdbg2
        '
        Me.lblVdbg2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblVdbg2.AutoSize = True
        Me.lblVdbg2.Location = New System.Drawing.Point(552, 307)
        Me.lblVdbg2.Name = "lblVdbg2"
        Me.lblVdbg2.Size = New System.Drawing.Size(13, 13)
        Me.lblVdbg2.TabIndex = 104
        Me.lblVdbg2.Text = "0"
        '
        'chk_dbg3
        '
        Me.chk_dbg3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chk_dbg3.AutoSize = True
        Me.chk_dbg3.Location = New System.Drawing.Point(492, 323)
        Me.chk_dbg3.Name = "chk_dbg3"
        Me.chk_dbg3.Size = New System.Drawing.Size(15, 14)
        Me.chk_dbg3.TabIndex = 105
        Me.chk_dbg3.UseVisualStyleBackColor = True
        '
        'lblVdbg4
        '
        Me.lblVdbg4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblVdbg4.AutoSize = True
        Me.lblVdbg4.Location = New System.Drawing.Point(552, 341)
        Me.lblVdbg4.Name = "lblVdbg4"
        Me.lblVdbg4.Size = New System.Drawing.Size(13, 13)
        Me.lblVdbg4.TabIndex = 110
        Me.lblVdbg4.Text = "0"
        '
        'lblDBG3
        '
        Me.lblDBG3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDBG3.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lblDBG3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDBG3.ForeColor = System.Drawing.Color.Black
        Me.lblDBG3.Location = New System.Drawing.Point(505, 323)
        Me.lblDBG3.Name = "lblDBG3"
        Me.lblDBG3.Size = New System.Drawing.Size(41, 14)
        Me.lblDBG3.TabIndex = 106
        Me.lblDBG3.Text = "DBG3"
        '
        'lblDBG4
        '
        Me.lblDBG4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDBG4.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lblDBG4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDBG4.ForeColor = System.Drawing.Color.Black
        Me.lblDBG4.Location = New System.Drawing.Point(505, 340)
        Me.lblDBG4.Name = "lblDBG4"
        Me.lblDBG4.Size = New System.Drawing.Size(41, 14)
        Me.lblDBG4.TabIndex = 109
        Me.lblDBG4.Text = "DBG4"
        '
        'lblVdbg3
        '
        Me.lblVdbg3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblVdbg3.AutoSize = True
        Me.lblVdbg3.Location = New System.Drawing.Point(552, 324)
        Me.lblVdbg3.Name = "lblVdbg3"
        Me.lblVdbg3.Size = New System.Drawing.Size(13, 13)
        Me.lblVdbg3.TabIndex = 107
        Me.lblVdbg3.Text = "0"
        '
        'chk_dbg4
        '
        Me.chk_dbg4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chk_dbg4.AutoSize = True
        Me.chk_dbg4.Location = New System.Drawing.Point(492, 340)
        Me.chk_dbg4.Name = "chk_dbg4"
        Me.chk_dbg4.Size = New System.Drawing.Size(15, 14)
        Me.chk_dbg4.TabIndex = 108
        Me.chk_dbg4.UseVisualStyleBackColor = True
        '
        'lblValt
        '
        Me.lblValt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblValt.Location = New System.Drawing.Point(550, 235)
        Me.lblValt.Name = "lblValt"
        Me.lblValt.Size = New System.Drawing.Size(27, 13)
        Me.lblValt.TabIndex = 97
        Me.lblValt.Text = "0"
        Me.lblValt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblVhead
        '
        Me.lblVhead.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVhead.Location = New System.Drawing.Point(550, 252)
        Me.lblVhead.Name = "lblVhead"
        Me.lblVhead.Size = New System.Drawing.Size(27, 13)
        Me.lblVhead.TabIndex = 98
        Me.lblVhead.Text = "0"
        Me.lblVhead.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'groupBox1
        '
        Me.groupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox1.BackColor = System.Drawing.Color.Transparent
        Me.groupBox1.Controls.Add(Me.cmdUncheck_all_ACC)
        Me.groupBox1.Controls.Add(Me.cmdCheck_all_ACC)
        Me.groupBox1.Controls.Add(Me.lblVacc_z)
        Me.groupBox1.Controls.Add(Me.lblVacc_pitch)
        Me.groupBox1.Controls.Add(Me.lblVacc_roll)
        Me.groupBox1.Controls.Add(Me.lblACC_Z)
        Me.groupBox1.Controls.Add(Me.chk_acc_z)
        Me.groupBox1.Controls.Add(Me.lblACC_PITCH)
        Me.groupBox1.Controls.Add(Me.chk_acc_pitch)
        Me.groupBox1.Controls.Add(Me.lblACC_ROLL)
        Me.groupBox1.Controls.Add(Me.chk_acc_roll)
        Me.groupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.groupBox1.Location = New System.Drawing.Point(484, 24)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(120, 63)
        Me.groupBox1.TabIndex = 90
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Accelerometer"
        '
        'cmdUncheck_all_ACC
        '
        Me.cmdUncheck_all_ACC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUncheck_all_ACC.ForeColor = System.Drawing.Color.Black
        Me.cmdUncheck_all_ACC.Location = New System.Drawing.Point(94, 39)
        Me.cmdUncheck_all_ACC.Name = "cmdUncheck_all_ACC"
        Me.cmdUncheck_all_ACC.Size = New System.Drawing.Size(20, 20)
        Me.cmdUncheck_all_ACC.TabIndex = 105
        Me.cmdUncheck_all_ACC.Text = "X"
        Me.cmdUncheck_all_ACC.UseVisualStyleBackColor = True
        '
        'cmdCheck_all_ACC
        '
        Me.cmdCheck_all_ACC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCheck_all_ACC.ForeColor = System.Drawing.Color.Black
        Me.cmdCheck_all_ACC.Location = New System.Drawing.Point(94, 15)
        Me.cmdCheck_all_ACC.Name = "cmdCheck_all_ACC"
        Me.cmdCheck_all_ACC.Size = New System.Drawing.Size(20, 20)
        Me.cmdCheck_all_ACC.TabIndex = 104
        Me.cmdCheck_all_ACC.Text = "+"
        Me.cmdCheck_all_ACC.UseVisualStyleBackColor = True
        '
        'lblVacc_z
        '
        Me.lblVacc_z.Location = New System.Drawing.Point(66, 45)
        Me.lblVacc_z.Name = "lblVacc_z"
        Me.lblVacc_z.Size = New System.Drawing.Size(27, 13)
        Me.lblVacc_z.TabIndex = 52
        Me.lblVacc_z.Text = "0"
        Me.lblVacc_z.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblVacc_pitch
        '
        Me.lblVacc_pitch.Location = New System.Drawing.Point(66, 30)
        Me.lblVacc_pitch.Name = "lblVacc_pitch"
        Me.lblVacc_pitch.Size = New System.Drawing.Size(27, 13)
        Me.lblVacc_pitch.TabIndex = 51
        Me.lblVacc_pitch.Text = "0"
        Me.lblVacc_pitch.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblVacc_roll
        '
        Me.lblVacc_roll.Location = New System.Drawing.Point(66, 16)
        Me.lblVacc_roll.Name = "lblVacc_roll"
        Me.lblVacc_roll.Size = New System.Drawing.Size(27, 13)
        Me.lblVacc_roll.TabIndex = 50
        Me.lblVacc_roll.Text = "0"
        Me.lblVacc_roll.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblACC_Z
        '
        Me.lblACC_Z.BackColor = System.Drawing.Color.Blue
        Me.lblACC_Z.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblACC_Z.ForeColor = System.Drawing.Color.White
        Me.lblACC_Z.Location = New System.Drawing.Point(22, 44)
        Me.lblACC_Z.Name = "lblACC_Z"
        Me.lblACC_Z.Size = New System.Drawing.Size(41, 14)
        Me.lblACC_Z.TabIndex = 49
        Me.lblACC_Z.Text = "Z"
        '
        'chk_acc_z
        '
        Me.chk_acc_z.AutoSize = True
        Me.chk_acc_z.Checked = True
        Me.chk_acc_z.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_acc_z.Location = New System.Drawing.Point(9, 44)
        Me.chk_acc_z.Name = "chk_acc_z"
        Me.chk_acc_z.Size = New System.Drawing.Size(15, 14)
        Me.chk_acc_z.TabIndex = 48
        Me.chk_acc_z.UseVisualStyleBackColor = True
        '
        'lblACC_PITCH
        '
        Me.lblACC_PITCH.BackColor = System.Drawing.Color.Green
        Me.lblACC_PITCH.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblACC_PITCH.ForeColor = System.Drawing.Color.White
        Me.lblACC_PITCH.Location = New System.Drawing.Point(22, 30)
        Me.lblACC_PITCH.Name = "lblACC_PITCH"
        Me.lblACC_PITCH.Size = New System.Drawing.Size(41, 14)
        Me.lblACC_PITCH.TabIndex = 47
        Me.lblACC_PITCH.Text = "PITCH"
        '
        'chk_acc_pitch
        '
        Me.chk_acc_pitch.AutoSize = True
        Me.chk_acc_pitch.Checked = True
        Me.chk_acc_pitch.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_acc_pitch.Location = New System.Drawing.Point(9, 30)
        Me.chk_acc_pitch.Name = "chk_acc_pitch"
        Me.chk_acc_pitch.Size = New System.Drawing.Size(15, 14)
        Me.chk_acc_pitch.TabIndex = 46
        Me.chk_acc_pitch.UseVisualStyleBackColor = True
        '
        'lblACC_ROLL
        '
        Me.lblACC_ROLL.BackColor = System.Drawing.Color.Red
        Me.lblACC_ROLL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblACC_ROLL.ForeColor = System.Drawing.Color.White
        Me.lblACC_ROLL.Location = New System.Drawing.Point(22, 16)
        Me.lblACC_ROLL.Name = "lblACC_ROLL"
        Me.lblACC_ROLL.Size = New System.Drawing.Size(41, 14)
        Me.lblACC_ROLL.TabIndex = 45
        Me.lblACC_ROLL.Text = "ROLL"
        '
        'chk_acc_roll
        '
        Me.chk_acc_roll.AutoSize = True
        Me.chk_acc_roll.Checked = True
        Me.chk_acc_roll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_acc_roll.Location = New System.Drawing.Point(9, 16)
        Me.chk_acc_roll.Name = "chk_acc_roll"
        Me.chk_acc_roll.Size = New System.Drawing.Size(15, 14)
        Me.chk_acc_roll.TabIndex = 44
        Me.chk_acc_roll.UseVisualStyleBackColor = True
        '
        'groupBox2
        '
        Me.groupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox2.BackColor = System.Drawing.Color.Transparent
        Me.groupBox2.Controls.Add(Me.cmdUncheck_all_GYRO)
        Me.groupBox2.Controls.Add(Me.cmdCheck_all_GYRO)
        Me.groupBox2.Controls.Add(Me.lblVgyro_yaw)
        Me.groupBox2.Controls.Add(Me.lblVgyro_pitch)
        Me.groupBox2.Controls.Add(Me.lblVgyro_roll)
        Me.groupBox2.Controls.Add(Me.lblGgyroYaw)
        Me.groupBox2.Controls.Add(Me.chk_gyro_yaw)
        Me.groupBox2.Controls.Add(Me.lblGgyroPitch)
        Me.groupBox2.Controls.Add(Me.chk_gyro_pitch)
        Me.groupBox2.Controls.Add(Me.lblGgyroRoll)
        Me.groupBox2.Controls.Add(Me.chk_gyro_roll)
        Me.groupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.groupBox2.Location = New System.Drawing.Point(484, 90)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(120, 63)
        Me.groupBox2.TabIndex = 92
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Gyroscope"
        '
        'cmdUncheck_all_GYRO
        '
        Me.cmdUncheck_all_GYRO.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUncheck_all_GYRO.ForeColor = System.Drawing.Color.Black
        Me.cmdUncheck_all_GYRO.Location = New System.Drawing.Point(94, 39)
        Me.cmdUncheck_all_GYRO.Name = "cmdUncheck_all_GYRO"
        Me.cmdUncheck_all_GYRO.Size = New System.Drawing.Size(20, 20)
        Me.cmdUncheck_all_GYRO.TabIndex = 108
        Me.cmdUncheck_all_GYRO.Text = "X"
        Me.cmdUncheck_all_GYRO.UseVisualStyleBackColor = True
        '
        'cmdCheck_all_GYRO
        '
        Me.cmdCheck_all_GYRO.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCheck_all_GYRO.ForeColor = System.Drawing.Color.Black
        Me.cmdCheck_all_GYRO.Location = New System.Drawing.Point(94, 15)
        Me.cmdCheck_all_GYRO.Name = "cmdCheck_all_GYRO"
        Me.cmdCheck_all_GYRO.Size = New System.Drawing.Size(20, 20)
        Me.cmdCheck_all_GYRO.TabIndex = 107
        Me.cmdCheck_all_GYRO.Text = "+"
        Me.cmdCheck_all_GYRO.UseVisualStyleBackColor = True
        '
        'lblVgyro_yaw
        '
        Me.lblVgyro_yaw.Location = New System.Drawing.Point(66, 45)
        Me.lblVgyro_yaw.Name = "lblVgyro_yaw"
        Me.lblVgyro_yaw.Size = New System.Drawing.Size(27, 13)
        Me.lblVgyro_yaw.TabIndex = 52
        Me.lblVgyro_yaw.Text = "0"
        Me.lblVgyro_yaw.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblVgyro_pitch
        '
        Me.lblVgyro_pitch.Location = New System.Drawing.Point(66, 30)
        Me.lblVgyro_pitch.Name = "lblVgyro_pitch"
        Me.lblVgyro_pitch.Size = New System.Drawing.Size(27, 13)
        Me.lblVgyro_pitch.TabIndex = 51
        Me.lblVgyro_pitch.Text = "0"
        Me.lblVgyro_pitch.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblVgyro_roll
        '
        Me.lblVgyro_roll.Location = New System.Drawing.Point(66, 16)
        Me.lblVgyro_roll.Name = "lblVgyro_roll"
        Me.lblVgyro_roll.Size = New System.Drawing.Size(27, 13)
        Me.lblVgyro_roll.TabIndex = 50
        Me.lblVgyro_roll.Text = "0"
        Me.lblVgyro_roll.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblGgyroYaw
        '
        Me.lblGgyroYaw.BackColor = System.Drawing.Color.Magenta
        Me.lblGgyroYaw.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGgyroYaw.ForeColor = System.Drawing.Color.Black
        Me.lblGgyroYaw.Location = New System.Drawing.Point(22, 44)
        Me.lblGgyroYaw.Name = "lblGgyroYaw"
        Me.lblGgyroYaw.Size = New System.Drawing.Size(41, 14)
        Me.lblGgyroYaw.TabIndex = 49
        Me.lblGgyroYaw.Text = "YAW"
        '
        'chk_gyro_yaw
        '
        Me.chk_gyro_yaw.AutoSize = True
        Me.chk_gyro_yaw.Checked = True
        Me.chk_gyro_yaw.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_gyro_yaw.Location = New System.Drawing.Point(9, 44)
        Me.chk_gyro_yaw.Name = "chk_gyro_yaw"
        Me.chk_gyro_yaw.Size = New System.Drawing.Size(15, 14)
        Me.chk_gyro_yaw.TabIndex = 48
        Me.chk_gyro_yaw.UseVisualStyleBackColor = True
        '
        'lblGgyroPitch
        '
        Me.lblGgyroPitch.BackColor = System.Drawing.Color.Cyan
        Me.lblGgyroPitch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGgyroPitch.ForeColor = System.Drawing.Color.Black
        Me.lblGgyroPitch.Location = New System.Drawing.Point(22, 30)
        Me.lblGgyroPitch.Name = "lblGgyroPitch"
        Me.lblGgyroPitch.Size = New System.Drawing.Size(41, 14)
        Me.lblGgyroPitch.TabIndex = 47
        Me.lblGgyroPitch.Text = "PITCH"
        '
        'chk_gyro_pitch
        '
        Me.chk_gyro_pitch.AutoSize = True
        Me.chk_gyro_pitch.Checked = True
        Me.chk_gyro_pitch.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_gyro_pitch.Location = New System.Drawing.Point(9, 30)
        Me.chk_gyro_pitch.Name = "chk_gyro_pitch"
        Me.chk_gyro_pitch.Size = New System.Drawing.Size(15, 14)
        Me.chk_gyro_pitch.TabIndex = 46
        Me.chk_gyro_pitch.UseVisualStyleBackColor = True
        '
        'lblGgyroRoll
        '
        Me.lblGgyroRoll.BackColor = System.Drawing.Color.Khaki
        Me.lblGgyroRoll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGgyroRoll.ForeColor = System.Drawing.Color.Black
        Me.lblGgyroRoll.Location = New System.Drawing.Point(22, 16)
        Me.lblGgyroRoll.Name = "lblGgyroRoll"
        Me.lblGgyroRoll.Size = New System.Drawing.Size(41, 14)
        Me.lblGgyroRoll.TabIndex = 45
        Me.lblGgyroRoll.Text = "ROLL"
        '
        'chk_gyro_roll
        '
        Me.chk_gyro_roll.AutoSize = True
        Me.chk_gyro_roll.Checked = True
        Me.chk_gyro_roll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_gyro_roll.Location = New System.Drawing.Point(9, 16)
        Me.chk_gyro_roll.Name = "chk_gyro_roll"
        Me.chk_gyro_roll.Size = New System.Drawing.Size(15, 14)
        Me.chk_gyro_roll.TabIndex = 44
        Me.chk_gyro_roll.UseVisualStyleBackColor = True
        '
        'chk_alt
        '
        Me.chk_alt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk_alt.AutoSize = True
        Me.chk_alt.Location = New System.Drawing.Point(493, 235)
        Me.chk_alt.Name = "chk_alt"
        Me.chk_alt.Size = New System.Drawing.Size(15, 14)
        Me.chk_alt.TabIndex = 91
        Me.chk_alt.UseVisualStyleBackColor = True
        '
        'lblALT
        '
        Me.lblALT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblALT.BackColor = System.Drawing.Color.Gainsboro
        Me.lblALT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblALT.ForeColor = System.Drawing.Color.Black
        Me.lblALT.Location = New System.Drawing.Point(506, 235)
        Me.lblALT.Name = "lblALT"
        Me.lblALT.Size = New System.Drawing.Size(41, 14)
        Me.lblALT.TabIndex = 93
        Me.lblALT.Text = "ALT"
        '
        'groupBox3
        '
        Me.groupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox3.BackColor = System.Drawing.Color.Transparent
        Me.groupBox3.Controls.Add(Me.cmdUncheck_all_MAG)
        Me.groupBox3.Controls.Add(Me.cmdCheck_all_MAG)
        Me.groupBox3.Controls.Add(Me.lblVmag_yaw)
        Me.groupBox3.Controls.Add(Me.lblVmag_pitch)
        Me.groupBox3.Controls.Add(Me.lblVmag_roll)
        Me.groupBox3.Controls.Add(Me.lblMAG_YAW)
        Me.groupBox3.Controls.Add(Me.chk_mag_yaw)
        Me.groupBox3.Controls.Add(Me.lblMAG_Pitch)
        Me.groupBox3.Controls.Add(Me.chk_mag_pitch)
        Me.groupBox3.Controls.Add(Me.lblMAG_roll)
        Me.groupBox3.Controls.Add(Me.chk_mag_roll)
        Me.groupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.groupBox3.Location = New System.Drawing.Point(484, 156)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(120, 63)
        Me.groupBox3.TabIndex = 94
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Magnetometer"
        '
        'cmdUncheck_all_MAG
        '
        Me.cmdUncheck_all_MAG.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUncheck_all_MAG.ForeColor = System.Drawing.Color.Black
        Me.cmdUncheck_all_MAG.Location = New System.Drawing.Point(94, 39)
        Me.cmdUncheck_all_MAG.Name = "cmdUncheck_all_MAG"
        Me.cmdUncheck_all_MAG.Size = New System.Drawing.Size(20, 20)
        Me.cmdUncheck_all_MAG.TabIndex = 107
        Me.cmdUncheck_all_MAG.Text = "X"
        Me.cmdUncheck_all_MAG.UseVisualStyleBackColor = True
        '
        'cmdCheck_all_MAG
        '
        Me.cmdCheck_all_MAG.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCheck_all_MAG.ForeColor = System.Drawing.Color.Black
        Me.cmdCheck_all_MAG.Location = New System.Drawing.Point(94, 15)
        Me.cmdCheck_all_MAG.Name = "cmdCheck_all_MAG"
        Me.cmdCheck_all_MAG.Size = New System.Drawing.Size(20, 20)
        Me.cmdCheck_all_MAG.TabIndex = 106
        Me.cmdCheck_all_MAG.Text = "+"
        Me.cmdCheck_all_MAG.UseVisualStyleBackColor = True
        '
        'lblVmag_yaw
        '
        Me.lblVmag_yaw.Location = New System.Drawing.Point(66, 45)
        Me.lblVmag_yaw.Name = "lblVmag_yaw"
        Me.lblVmag_yaw.Size = New System.Drawing.Size(27, 13)
        Me.lblVmag_yaw.TabIndex = 52
        Me.lblVmag_yaw.Text = "0"
        Me.lblVmag_yaw.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblVmag_pitch
        '
        Me.lblVmag_pitch.Location = New System.Drawing.Point(66, 30)
        Me.lblVmag_pitch.Name = "lblVmag_pitch"
        Me.lblVmag_pitch.Size = New System.Drawing.Size(27, 13)
        Me.lblVmag_pitch.TabIndex = 51
        Me.lblVmag_pitch.Text = "0"
        Me.lblVmag_pitch.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblVmag_roll
        '
        Me.lblVmag_roll.Location = New System.Drawing.Point(66, 16)
        Me.lblVmag_roll.Name = "lblVmag_roll"
        Me.lblVmag_roll.Size = New System.Drawing.Size(27, 13)
        Me.lblVmag_roll.TabIndex = 50
        Me.lblVmag_roll.Text = "0"
        Me.lblVmag_roll.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblMAG_YAW
        '
        Me.lblMAG_YAW.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.lblMAG_YAW.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMAG_YAW.Location = New System.Drawing.Point(22, 44)
        Me.lblMAG_YAW.Name = "lblMAG_YAW"
        Me.lblMAG_YAW.Size = New System.Drawing.Size(41, 14)
        Me.lblMAG_YAW.TabIndex = 49
        Me.lblMAG_YAW.Text = "YAW"
        '
        'chk_mag_yaw
        '
        Me.chk_mag_yaw.AutoSize = True
        Me.chk_mag_yaw.Location = New System.Drawing.Point(9, 44)
        Me.chk_mag_yaw.Name = "chk_mag_yaw"
        Me.chk_mag_yaw.Size = New System.Drawing.Size(15, 14)
        Me.chk_mag_yaw.TabIndex = 48
        Me.chk_mag_yaw.UseVisualStyleBackColor = True
        '
        'lblMAG_Pitch
        '
        Me.lblMAG_Pitch.BackColor = System.Drawing.Color.MediumPurple
        Me.lblMAG_Pitch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMAG_Pitch.Location = New System.Drawing.Point(22, 30)
        Me.lblMAG_Pitch.Name = "lblMAG_Pitch"
        Me.lblMAG_Pitch.Size = New System.Drawing.Size(41, 14)
        Me.lblMAG_Pitch.TabIndex = 47
        Me.lblMAG_Pitch.Text = "PITCH"
        '
        'chk_mag_pitch
        '
        Me.chk_mag_pitch.AutoSize = True
        Me.chk_mag_pitch.Location = New System.Drawing.Point(9, 30)
        Me.chk_mag_pitch.Name = "chk_mag_pitch"
        Me.chk_mag_pitch.Size = New System.Drawing.Size(15, 14)
        Me.chk_mag_pitch.TabIndex = 46
        Me.chk_mag_pitch.UseVisualStyleBackColor = True
        '
        'lblMAG_roll
        '
        Me.lblMAG_roll.BackColor = System.Drawing.Color.CadetBlue
        Me.lblMAG_roll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMAG_roll.Location = New System.Drawing.Point(22, 16)
        Me.lblMAG_roll.Name = "lblMAG_roll"
        Me.lblMAG_roll.Size = New System.Drawing.Size(41, 14)
        Me.lblMAG_roll.TabIndex = 45
        Me.lblMAG_roll.Text = "ROLL"
        '
        'chk_mag_roll
        '
        Me.chk_mag_roll.AutoSize = True
        Me.chk_mag_roll.Location = New System.Drawing.Point(9, 16)
        Me.chk_mag_roll.Name = "chk_mag_roll"
        Me.chk_mag_roll.Size = New System.Drawing.Size(15, 14)
        Me.chk_mag_roll.TabIndex = 44
        Me.chk_mag_roll.UseVisualStyleBackColor = True
        '
        'chk_head
        '
        Me.chk_head.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk_head.AutoSize = True
        Me.chk_head.Location = New System.Drawing.Point(493, 252)
        Me.chk_head.Name = "chk_head"
        Me.chk_head.Size = New System.Drawing.Size(15, 14)
        Me.chk_head.TabIndex = 95
        Me.chk_head.UseVisualStyleBackColor = True
        '
        'lblHEAD
        '
        Me.lblHEAD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHEAD.BackColor = System.Drawing.Color.Orange
        Me.lblHEAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHEAD.ForeColor = System.Drawing.Color.Black
        Me.lblHEAD.Location = New System.Drawing.Point(506, 252)
        Me.lblHEAD.Name = "lblHEAD"
        Me.lblHEAD.Size = New System.Drawing.Size(41, 14)
        Me.lblHEAD.TabIndex = 96
        Me.lblHEAD.Text = "HEAD"
        '
        'pnRealtimeChannels
        '
        Me.pnRealtimeChannels.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnRealtimeChannels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnRealtimeChannels.Controls.Add(Me.pgbRT_AUX8)
        Me.pnRealtimeChannels.Controls.Add(Me.pgbRT_AUX7)
        Me.pnRealtimeChannels.Controls.Add(Me.pgbRT_AUX6)
        Me.pnRealtimeChannels.Controls.Add(Me.pgbRT_AUX5)
        Me.pnRealtimeChannels.Controls.Add(Me.pgbRT_AUX4)
        Me.pnRealtimeChannels.Controls.Add(Me.pgbRT_AUX3)
        Me.pnRealtimeChannels.Controls.Add(Me.pgbRT_AUX2)
        Me.pnRealtimeChannels.Controls.Add(Me.pgbRT_AUX1)
        Me.pnRealtimeChannels.Controls.Add(Me.pgbRT_YAW)
        Me.pnRealtimeChannels.Controls.Add(Me.pgbRT_ROLL)
        Me.pnRealtimeChannels.Controls.Add(Me.pgbRT_PITCH)
        Me.pnRealtimeChannels.Controls.Add(Me.pgbRT_THR)
        Me.pnRealtimeChannels.Controls.Add(Me.lblRT_AUX8)
        Me.pnRealtimeChannels.Controls.Add(Me.lblRT_AUX7)
        Me.pnRealtimeChannels.Controls.Add(Me.lblRT_AUX6)
        Me.pnRealtimeChannels.Controls.Add(Me.lblRT_AUX5)
        Me.pnRealtimeChannels.Controls.Add(Me.lblRT_AUX4)
        Me.pnRealtimeChannels.Controls.Add(Me.lblRT_AUX3)
        Me.pnRealtimeChannels.Controls.Add(Me.lblRT_AUX2)
        Me.pnRealtimeChannels.Controls.Add(Me.lblRT_AUX1)
        Me.pnRealtimeChannels.Controls.Add(Me.lblRT_YAW)
        Me.pnRealtimeChannels.Controls.Add(Me.lblRT_ROLL)
        Me.pnRealtimeChannels.Controls.Add(Me.lblRT_PITCH)
        Me.pnRealtimeChannels.Controls.Add(Me.lblVRT_AUX8)
        Me.pnRealtimeChannels.Controls.Add(Me.lblVRT_AUX7)
        Me.pnRealtimeChannels.Controls.Add(Me.lblVRT_AUX6)
        Me.pnRealtimeChannels.Controls.Add(Me.lblVRT_AUX5)
        Me.pnRealtimeChannels.Controls.Add(Me.lblVRT_AUX4)
        Me.pnRealtimeChannels.Controls.Add(Me.lblVRT_AUX3)
        Me.pnRealtimeChannels.Controls.Add(Me.lblVRT_AUX2)
        Me.pnRealtimeChannels.Controls.Add(Me.lblVRT_AUX1)
        Me.pnRealtimeChannels.Controls.Add(Me.lblVRT_YAW)
        Me.pnRealtimeChannels.Controls.Add(Me.lblVRT_ROLL)
        Me.pnRealtimeChannels.Controls.Add(Me.lblVRT_PITCH)
        Me.pnRealtimeChannels.Controls.Add(Me.lblVRT_THR)
        Me.pnRealtimeChannels.Controls.Add(Me.lblRT_THR)
        Me.pnRealtimeChannels.Location = New System.Drawing.Point(796, 30)
        Me.pnRealtimeChannels.Name = "pnRealtimeChannels"
        Me.pnRealtimeChannels.Size = New System.Drawing.Size(217, 301)
        Me.pnRealtimeChannels.TabIndex = 89
        '
        'cmbRefreshRate
        '
        Me.cmbRefreshRate.FormattingEnabled = True
        Me.cmbRefreshRate.Location = New System.Drawing.Point(8, 3)
        Me.cmbRefreshRate.Name = "cmbRefreshRate"
        Me.cmbRefreshRate.Size = New System.Drawing.Size(55, 21)
        Me.cmbRefreshRate.TabIndex = 88
        '
        'cmdCalibrateAcc
        '
        Me.cmdCalibrateAcc.ForeColor = System.Drawing.Color.Black
        Me.cmdCalibrateAcc.Location = New System.Drawing.Point(226, 3)
        Me.cmdCalibrateAcc.Name = "cmdCalibrateAcc"
        Me.cmdCalibrateAcc.Size = New System.Drawing.Size(84, 21)
        Me.cmdCalibrateAcc.TabIndex = 83
        Me.cmdCalibrateAcc.Text = "Calibrate ACC"
        Me.cmdCalibrateAcc.UseVisualStyleBackColor = True
        '
        'lblRefreshRate
        '
        Me.lblRefreshRate.AutoSize = True
        Me.lblRefreshRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRefreshRate.ForeColor = System.Drawing.Color.Black
        Me.lblRefreshRate.Location = New System.Drawing.Point(69, 6)
        Me.lblRefreshRate.Name = "lblRefreshRate"
        Me.lblRefreshRate.Size = New System.Drawing.Size(82, 13)
        Me.lblRefreshRate.TabIndex = 81
        Me.lblRefreshRate.Text = "Refresh Rate"
        '
        'cmdPause
        '
        Me.cmdPause.ForeColor = System.Drawing.Color.Black
        Me.cmdPause.Location = New System.Drawing.Point(151, 3)
        Me.cmdPause.Name = "cmdPause"
        Me.cmdPause.Size = New System.Drawing.Size(69, 21)
        Me.cmdPause.TabIndex = 82
        Me.cmdPause.Text = "Pause"
        Me.cmdPause.UseVisualStyleBackColor = True
        '
        'cmdCalibrateMag
        '
        Me.cmdCalibrateMag.ForeColor = System.Drawing.Color.Black
        Me.cmdCalibrateMag.Location = New System.Drawing.Point(316, 3)
        Me.cmdCalibrateMag.Name = "cmdCalibrateMag"
        Me.cmdCalibrateMag.Size = New System.Drawing.Size(84, 21)
        Me.cmdCalibrateMag.TabIndex = 84
        Me.cmdCalibrateMag.Text = "Calibrate Mag"
        Me.cmdCalibrateMag.UseVisualStyleBackColor = True
        '
        'zgMonitor
        '
        Me.zgMonitor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.zgMonitor.Location = New System.Drawing.Point(8, 30)
        Me.zgMonitor.Name = "zgMonitor"
        Me.zgMonitor.ScrollGrace = 0.0R
        Me.zgMonitor.ScrollMaxX = 0.0R
        Me.zgMonitor.ScrollMaxY = 0.0R
        Me.zgMonitor.ScrollMaxY2 = 0.0R
        Me.zgMonitor.ScrollMinX = 0.0R
        Me.zgMonitor.ScrollMinY = 0.0R
        Me.zgMonitor.ScrollMinY2 = 0.0R
        Me.zgMonitor.Size = New System.Drawing.Size(468, 234)
        Me.zgMonitor.TabIndex = 4
        '
        'tpMap
        '
        Me.tpMap.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tpMap.Controls.Add(Me.txtWPComment)
        Me.tpMap.Controls.Add(Me.MainMap)
        Me.tpMap.Controls.Add(Me.gbMapWayPoints)
        Me.tpMap.Controls.Add(Me.cmbMapProviders)
        Me.tpMap.Controls.Add(Me.lblMapProvider)
        Me.tpMap.Controls.Add(Me.tb_mapzoom)
        Me.tpMap.Controls.Add(Me.cmdClearRoute)
        Me.tpMap.Controls.Add(Me.gpMapGPSLive)
        Me.tpMap.Controls.Add(Me.lblVMousePos)
        Me.tpMap.Location = New System.Drawing.Point(4, 22)
        Me.tpMap.Name = "tpMap"
        Me.tpMap.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMap.Size = New System.Drawing.Size(1016, 460)
        Me.tpMap.TabIndex = 5
        Me.tpMap.Text = "Map"
        '
        'txtWPComment
        '
        Me.txtWPComment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWPComment.Location = New System.Drawing.Point(287, 433)
        Me.txtWPComment.Name = "txtWPComment"
        Me.txtWPComment.Size = New System.Drawing.Size(148, 20)
        Me.txtWPComment.TabIndex = 56
        '
        'MainMap
        '
        Me.MainMap.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MainMap.BackColor = System.Drawing.Color.White
        Me.MainMap.Bearing = 0.0!
        Me.MainMap.CanDragMap = True
        Me.MainMap.GrayScaleMode = False
        Me.MainMap.LevelsKeepInMemmory = 5
        Me.MainMap.Location = New System.Drawing.Point(8, 6)
        Me.MainMap.MarkersEnabled = True
        Me.MainMap.MaxZoom = 2
        Me.MainMap.MinZoom = 2
        Me.MainMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter
        Me.MainMap.Name = "MainMap"
        Me.MainMap.NegativeMode = False
        Me.MainMap.PolygonsEnabled = True
        Me.MainMap.RetryLoadTile = 0
        Me.MainMap.RoutesEnabled = True
        Me.MainMap.ShowTileGridLines = False
        Me.MainMap.Size = New System.Drawing.Size(650, 413)
        Me.MainMap.TabIndex = 0
        Me.MainMap.Zoom = 0.0R
        '
        'gbMapWayPoints
        '
        Me.gbMapWayPoints.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbMapWayPoints.Controls.Add(Me.cmdWPUpdate)
        Me.gbMapWayPoints.Controls.Add(Me.cmdWPClear)
        Me.gbMapWayPoints.Controls.Add(Me.picWPHeading)
        Me.gbMapWayPoints.Controls.Add(Me.numWPHeading)
        Me.gbMapWayPoints.Controls.Add(Me.numWPParameter)
        Me.gbMapWayPoints.Controls.Add(Me.numWPNavFlagAction)
        Me.gbMapWayPoints.Controls.Add(Me.numWPTimeToStay)
        Me.gbMapWayPoints.Controls.Add(Me.numWPAlt)
        Me.gbMapWayPoints.Controls.Add(Me.txtWPLng)
        Me.gbMapWayPoints.Controls.Add(Me.txtWPLat)
        Me.gbMapWayPoints.Controls.Add(Me.lblWPHeading)
        Me.gbMapWayPoints.Controls.Add(Me.dgWayPoints)
        Me.gbMapWayPoints.Controls.Add(Me.lblWPParameter)
        Me.gbMapWayPoints.Controls.Add(Me.lblWPNavFlagAction)
        Me.gbMapWayPoints.Controls.Add(Me.lblWPLng)
        Me.gbMapWayPoints.Controls.Add(Me.lblWPLat)
        Me.gbMapWayPoints.Controls.Add(Me.lblTimeToStay)
        Me.gbMapWayPoints.Controls.Add(Me.lblWPAlt)
        Me.gbMapWayPoints.Location = New System.Drawing.Point(703, 68)
        Me.gbMapWayPoints.Name = "gbMapWayPoints"
        Me.gbMapWayPoints.Size = New System.Drawing.Size(310, 386)
        Me.gbMapWayPoints.TabIndex = 55
        Me.gbMapWayPoints.TabStop = False
        Me.gbMapWayPoints.Text = "Way Points"
        '
        'cmdWPUpdate
        '
        Me.cmdWPUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdWPUpdate.Location = New System.Drawing.Point(235, 361)
        Me.cmdWPUpdate.Name = "cmdWPUpdate"
        Me.cmdWPUpdate.Size = New System.Drawing.Size(75, 23)
        Me.cmdWPUpdate.TabIndex = 56
        Me.cmdWPUpdate.Text = "Update"
        Me.cmdWPUpdate.UseVisualStyleBackColor = True
        '
        'cmdWPClear
        '
        Me.cmdWPClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdWPClear.Location = New System.Drawing.Point(6, 361)
        Me.cmdWPClear.Name = "cmdWPClear"
        Me.cmdWPClear.Size = New System.Drawing.Size(75, 23)
        Me.cmdWPClear.TabIndex = 56
        Me.cmdWPClear.Text = "Clear"
        Me.cmdWPClear.UseVisualStyleBackColor = True
        '
        'picWPHeading
        '
        Me.picWPHeading.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picWPHeading.Image = CType(resources.GetObject("picWPHeading.Image"), System.Drawing.Image)
        Me.picWPHeading.Location = New System.Drawing.Point(272, 325)
        Me.picWPHeading.Name = "picWPHeading"
        Me.picWPHeading.Size = New System.Drawing.Size(32, 32)
        Me.picWPHeading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picWPHeading.TabIndex = 55
        Me.picWPHeading.TabStop = False
        '
        'numWPHeading
        '
        Me.numWPHeading.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numWPHeading.Enabled = False
        Me.numWPHeading.Increment = New Decimal(New Integer() {15, 0, 0, 0})
        Me.numWPHeading.Location = New System.Drawing.Point(205, 337)
        Me.numWPHeading.Maximum = New Decimal(New Integer() {180, 0, 0, 0})
        Me.numWPHeading.Minimum = New Decimal(New Integer() {180, 0, 0, -2147483648})
        Me.numWPHeading.Name = "numWPHeading"
        Me.numWPHeading.Size = New System.Drawing.Size(44, 20)
        Me.numWPHeading.TabIndex = 54
        '
        'numWPParameter
        '
        Me.numWPParameter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numWPParameter.Enabled = False
        Me.numWPParameter.Location = New System.Drawing.Point(94, 337)
        Me.numWPParameter.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.numWPParameter.Name = "numWPParameter"
        Me.numWPParameter.Size = New System.Drawing.Size(52, 20)
        Me.numWPParameter.TabIndex = 54
        '
        'numWPNavFlagAction
        '
        Me.numWPNavFlagAction.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numWPNavFlagAction.Enabled = False
        Me.numWPNavFlagAction.Location = New System.Drawing.Point(9, 337)
        Me.numWPNavFlagAction.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.numWPNavFlagAction.Name = "numWPNavFlagAction"
        Me.numWPNavFlagAction.Size = New System.Drawing.Size(44, 20)
        Me.numWPNavFlagAction.TabIndex = 54
        '
        'numWPTimeToStay
        '
        Me.numWPTimeToStay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numWPTimeToStay.Enabled = False
        Me.numWPTimeToStay.Location = New System.Drawing.Point(272, 297)
        Me.numWPTimeToStay.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.numWPTimeToStay.Name = "numWPTimeToStay"
        Me.numWPTimeToStay.Size = New System.Drawing.Size(38, 20)
        Me.numWPTimeToStay.TabIndex = 54
        '
        'numWPAlt
        '
        Me.numWPAlt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numWPAlt.Enabled = False
        Me.numWPAlt.Location = New System.Drawing.Point(272, 272)
        Me.numWPAlt.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.numWPAlt.Name = "numWPAlt"
        Me.numWPAlt.Size = New System.Drawing.Size(38, 20)
        Me.numWPAlt.TabIndex = 54
        '
        'txtWPLng
        '
        Me.txtWPLng.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWPLng.Enabled = False
        Me.txtWPLng.Location = New System.Drawing.Point(78, 297)
        Me.txtWPLng.Name = "txtWPLng"
        Me.txtWPLng.Size = New System.Drawing.Size(100, 20)
        Me.txtWPLng.TabIndex = 53
        '
        'txtWPLat
        '
        Me.txtWPLat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWPLat.Enabled = False
        Me.txtWPLat.Location = New System.Drawing.Point(78, 271)
        Me.txtWPLat.Name = "txtWPLat"
        Me.txtWPLat.Size = New System.Drawing.Size(100, 20)
        Me.txtWPLat.TabIndex = 53
        '
        'lblWPHeading
        '
        Me.lblWPHeading.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblWPHeading.AutoSize = True
        Me.lblWPHeading.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblWPHeading.Location = New System.Drawing.Point(202, 321)
        Me.lblWPHeading.Name = "lblWPHeading"
        Me.lblWPHeading.Size = New System.Drawing.Size(47, 13)
        Me.lblWPHeading.TabIndex = 39
        Me.lblWPHeading.Text = "Heading"
        '
        'dgWayPoints
        '
        Me.dgWayPoints.AllowUserToAddRows = False
        Me.dgWayPoints.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgWayPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgWayPoints.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colWPNumber, Me.colWPLat, Me.colWPLng, Me.colWPAlt, Me.colWPHeading, Me.colWPTimeToStay})
        Me.dgWayPoints.Location = New System.Drawing.Point(3, 19)
        Me.dgWayPoints.MultiSelect = False
        Me.dgWayPoints.Name = "dgWayPoints"
        Me.dgWayPoints.ReadOnly = True
        Me.dgWayPoints.RowHeadersWidth = 25
        Me.dgWayPoints.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgWayPoints.Size = New System.Drawing.Size(307, 246)
        Me.dgWayPoints.TabIndex = 52
        '
        'colWPNumber
        '
        Me.colWPNumber.HeaderText = "Number"
        Me.colWPNumber.Name = "colWPNumber"
        Me.colWPNumber.ReadOnly = True
        Me.colWPNumber.Width = 40
        '
        'colWPLat
        '
        Me.colWPLat.HeaderText = "Latitude"
        Me.colWPLat.Name = "colWPLat"
        Me.colWPLat.ReadOnly = True
        Me.colWPLat.Width = 60
        '
        'colWPLng
        '
        Me.colWPLng.HeaderText = "Longitude"
        Me.colWPLng.Name = "colWPLng"
        Me.colWPLng.ReadOnly = True
        Me.colWPLng.Width = 60
        '
        'colWPAlt
        '
        Me.colWPAlt.HeaderText = "Altitude"
        Me.colWPAlt.Name = "colWPAlt"
        Me.colWPAlt.ReadOnly = True
        Me.colWPAlt.Width = 40
        '
        'colWPHeading
        '
        Me.colWPHeading.HeaderText = "Heading"
        Me.colWPHeading.Name = "colWPHeading"
        Me.colWPHeading.ReadOnly = True
        Me.colWPHeading.Width = 40
        '
        'colWPTimeToStay
        '
        Me.colWPTimeToStay.HeaderText = "Time"
        Me.colWPTimeToStay.Name = "colWPTimeToStay"
        Me.colWPTimeToStay.ReadOnly = True
        Me.colWPTimeToStay.Width = 40
        '
        'lblWPParameter
        '
        Me.lblWPParameter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblWPParameter.AutoSize = True
        Me.lblWPParameter.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblWPParameter.Location = New System.Drawing.Point(91, 321)
        Me.lblWPParameter.Name = "lblWPParameter"
        Me.lblWPParameter.Size = New System.Drawing.Size(55, 13)
        Me.lblWPParameter.TabIndex = 39
        Me.lblWPParameter.Text = "Parameter"
        '
        'lblWPNavFlagAction
        '
        Me.lblWPNavFlagAction.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblWPNavFlagAction.AutoSize = True
        Me.lblWPNavFlagAction.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblWPNavFlagAction.Location = New System.Drawing.Point(6, 321)
        Me.lblWPNavFlagAction.Name = "lblWPNavFlagAction"
        Me.lblWPNavFlagAction.Size = New System.Drawing.Size(68, 13)
        Me.lblWPNavFlagAction.TabIndex = 38
        Me.lblWPNavFlagAction.Text = "Flag / Action"
        '
        'lblWPLng
        '
        Me.lblWPLng.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblWPLng.AutoSize = True
        Me.lblWPLng.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblWPLng.Location = New System.Drawing.Point(6, 299)
        Me.lblWPLng.Name = "lblWPLng"
        Me.lblWPLng.Size = New System.Drawing.Size(54, 13)
        Me.lblWPLng.TabIndex = 39
        Me.lblWPLng.Text = "Longitude"
        '
        'lblWPLat
        '
        Me.lblWPLat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblWPLat.AutoSize = True
        Me.lblWPLat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblWPLat.Location = New System.Drawing.Point(6, 274)
        Me.lblWPLat.Name = "lblWPLat"
        Me.lblWPLat.Size = New System.Drawing.Size(45, 13)
        Me.lblWPLat.TabIndex = 38
        Me.lblWPLat.Text = "Latitude"
        '
        'lblTimeToStay
        '
        Me.lblTimeToStay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTimeToStay.AutoSize = True
        Me.lblTimeToStay.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTimeToStay.Location = New System.Drawing.Point(202, 299)
        Me.lblTimeToStay.Name = "lblTimeToStay"
        Me.lblTimeToStay.Size = New System.Drawing.Size(64, 13)
        Me.lblTimeToStay.TabIndex = 42
        Me.lblTimeToStay.Text = "Time to stay"
        '
        'lblWPAlt
        '
        Me.lblWPAlt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblWPAlt.AutoSize = True
        Me.lblWPAlt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblWPAlt.Location = New System.Drawing.Point(202, 274)
        Me.lblWPAlt.Name = "lblWPAlt"
        Me.lblWPAlt.Size = New System.Drawing.Size(42, 13)
        Me.lblWPAlt.TabIndex = 42
        Me.lblWPAlt.Text = "Altitude"
        '
        'cmbMapProviders
        '
        Me.cmbMapProviders.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMapProviders.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cmbMapProviders.FormattingEnabled = True
        Me.cmbMapProviders.Location = New System.Drawing.Point(517, 435)
        Me.cmbMapProviders.Name = "cmbMapProviders"
        Me.cmbMapProviders.Size = New System.Drawing.Size(145, 21)
        Me.cmbMapProviders.TabIndex = 46
        '
        'lblMapProvider
        '
        Me.lblMapProvider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMapProvider.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblMapProvider.Location = New System.Drawing.Point(397, 438)
        Me.lblMapProvider.Name = "lblMapProvider"
        Me.lblMapProvider.Size = New System.Drawing.Size(114, 13)
        Me.lblMapProvider.TabIndex = 47
        Me.lblMapProvider.Text = "Map Provider"
        Me.lblMapProvider.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tb_mapzoom
        '
        Me.tb_mapzoom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tb_mapzoom.AutoSize = False
        Me.tb_mapzoom.LargeChange = 1
        Me.tb_mapzoom.Location = New System.Drawing.Point(664, 3)
        Me.tb_mapzoom.Maximum = 20
        Me.tb_mapzoom.Name = "tb_mapzoom"
        Me.tb_mapzoom.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tb_mapzoom.Size = New System.Drawing.Size(33, 421)
        Me.tb_mapzoom.TabIndex = 50
        Me.tb_mapzoom.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        '
        'cmdClearRoute
        '
        Me.cmdClearRoute.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdClearRoute.Location = New System.Drawing.Point(6, 433)
        Me.cmdClearRoute.Name = "cmdClearRoute"
        Me.cmdClearRoute.Size = New System.Drawing.Size(75, 23)
        Me.cmdClearRoute.TabIndex = 48
        Me.cmdClearRoute.Text = "Clear Route"
        Me.cmdClearRoute.UseVisualStyleBackColor = True
        '
        'gpMapGPSLive
        '
        Me.gpMapGPSLive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpMapGPSLive.Controls.Add(Me.chkSetToLiveData)
        Me.gpMapGPSLive.Controls.Add(Me.picGPS)
        Me.gpMapGPSLive.Controls.Add(Me.lblGPS_lon)
        Me.gpMapGPSLive.Controls.Add(Me.lbl_GPS_numsat)
        Me.gpMapGPSLive.Controls.Add(Me.lblV_GPS_lat)
        Me.gpMapGPSLive.Controls.Add(Me.lblV_GPS_numsat)
        Me.gpMapGPSLive.Controls.Add(Me.lblSetMapToLiveData)
        Me.gpMapGPSLive.Controls.Add(Me.lbl_GPS_alt)
        Me.gpMapGPSLive.Controls.Add(Me.lblV_GPS_lon)
        Me.gpMapGPSLive.Controls.Add(Me.lblGPS_lat)
        Me.gpMapGPSLive.Controls.Add(Me.lblV_GPS_alt)
        Me.gpMapGPSLive.Location = New System.Drawing.Point(703, 3)
        Me.gpMapGPSLive.Name = "gpMapGPSLive"
        Me.gpMapGPSLive.Size = New System.Drawing.Size(310, 59)
        Me.gpMapGPSLive.TabIndex = 54
        Me.gpMapGPSLive.TabStop = False
        Me.gpMapGPSLive.Text = "GPS live data"
        '
        'chkSetToLiveData
        '
        Me.chkSetToLiveData.AutoSize = True
        Me.chkSetToLiveData.Location = New System.Drawing.Point(289, 41)
        Me.chkSetToLiveData.Name = "chkSetToLiveData"
        Me.chkSetToLiveData.Size = New System.Drawing.Size(15, 14)
        Me.chkSetToLiveData.TabIndex = 54
        Me.chkSetToLiveData.UseVisualStyleBackColor = True
        '
        'picGPS
        '
        Me.picGPS.Image = Global.BaseflightGUI.My.Resources.Resources.gps_red_x32
        Me.picGPS.Location = New System.Drawing.Point(6, 19)
        Me.picGPS.Name = "picGPS"
        Me.picGPS.Size = New System.Drawing.Size(32, 32)
        Me.picGPS.TabIndex = 53
        Me.picGPS.TabStop = False
        '
        'lblGPS_lon
        '
        Me.lblGPS_lon.AutoSize = True
        Me.lblGPS_lon.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblGPS_lon.Location = New System.Drawing.Point(40, 38)
        Me.lblGPS_lon.Name = "lblGPS_lon"
        Me.lblGPS_lon.Size = New System.Drawing.Size(54, 13)
        Me.lblGPS_lon.TabIndex = 39
        Me.lblGPS_lon.Text = "Longitude"
        '
        'lbl_GPS_numsat
        '
        Me.lbl_GPS_numsat.AutoSize = True
        Me.lbl_GPS_numsat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbl_GPS_numsat.Location = New System.Drawing.Point(175, 41)
        Me.lbl_GPS_numsat.Name = "lbl_GPS_numsat"
        Me.lbl_GPS_numsat.Size = New System.Drawing.Size(41, 13)
        Me.lbl_GPS_numsat.TabIndex = 44
        Me.lbl_GPS_numsat.Text = "Sat/Fix"
        '
        'lblV_GPS_lat
        '
        Me.lblV_GPS_lat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblV_GPS_lat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblV_GPS_lat.Location = New System.Drawing.Point(91, 21)
        Me.lblV_GPS_lat.Name = "lblV_GPS_lat"
        Me.lblV_GPS_lat.Size = New System.Drawing.Size(80, 16)
        Me.lblV_GPS_lat.TabIndex = 41
        Me.lblV_GPS_lat.Text = "0"
        Me.lblV_GPS_lat.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblV_GPS_numsat
        '
        Me.lblV_GPS_numsat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblV_GPS_numsat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblV_GPS_numsat.Location = New System.Drawing.Point(219, 41)
        Me.lblV_GPS_numsat.Name = "lblV_GPS_numsat"
        Me.lblV_GPS_numsat.Size = New System.Drawing.Size(34, 16)
        Me.lblV_GPS_numsat.TabIndex = 45
        Me.lblV_GPS_numsat.Text = "0/0"
        Me.lblV_GPS_numsat.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSetMapToLiveData
        '
        Me.lblSetMapToLiveData.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblSetMapToLiveData.Location = New System.Drawing.Point(259, 21)
        Me.lblSetMapToLiveData.Name = "lblSetMapToLiveData"
        Me.lblSetMapToLiveData.Size = New System.Drawing.Size(45, 15)
        Me.lblSetMapToLiveData.TabIndex = 42
        Me.lblSetMapToLiveData.Text = "set Map"
        Me.lblSetMapToLiveData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_GPS_alt
        '
        Me.lbl_GPS_alt.AutoSize = True
        Me.lbl_GPS_alt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbl_GPS_alt.Location = New System.Drawing.Point(175, 23)
        Me.lbl_GPS_alt.Name = "lbl_GPS_alt"
        Me.lbl_GPS_alt.Size = New System.Drawing.Size(43, 13)
        Me.lbl_GPS_alt.TabIndex = 42
        Me.lbl_GPS_alt.Text = "GPS alt"
        '
        'lblV_GPS_lon
        '
        Me.lblV_GPS_lon.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblV_GPS_lon.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblV_GPS_lon.Location = New System.Drawing.Point(91, 38)
        Me.lblV_GPS_lon.Name = "lblV_GPS_lon"
        Me.lblV_GPS_lon.Size = New System.Drawing.Size(80, 16)
        Me.lblV_GPS_lon.TabIndex = 40
        Me.lblV_GPS_lon.Text = "0"
        Me.lblV_GPS_lon.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblGPS_lat
        '
        Me.lblGPS_lat.AutoSize = True
        Me.lblGPS_lat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblGPS_lat.Location = New System.Drawing.Point(40, 21)
        Me.lblGPS_lat.Name = "lblGPS_lat"
        Me.lblGPS_lat.Size = New System.Drawing.Size(45, 13)
        Me.lblGPS_lat.TabIndex = 38
        Me.lblGPS_lat.Text = "Latitude"
        '
        'lblV_GPS_alt
        '
        Me.lblV_GPS_alt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblV_GPS_alt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblV_GPS_alt.Location = New System.Drawing.Point(219, 21)
        Me.lblV_GPS_alt.Name = "lblV_GPS_alt"
        Me.lblV_GPS_alt.Size = New System.Drawing.Size(34, 16)
        Me.lblV_GPS_alt.TabIndex = 43
        Me.lblV_GPS_alt.Text = "0"
        Me.lblV_GPS_alt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblVMousePos
        '
        Me.lblVMousePos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblVMousePos.AutoSize = True
        Me.lblVMousePos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblVMousePos.Location = New System.Drawing.Point(87, 438)
        Me.lblVMousePos.Name = "lblVMousePos"
        Me.lblVMousePos.Size = New System.Drawing.Size(22, 13)
        Me.lblVMousePos.TabIndex = 37
        Me.lblVMousePos.Text = "0,0"
        '
        'tpCLI
        '
        Me.tpCLI.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tpCLI.Controls.Add(Me.gbTerminal)
        Me.tpCLI.Location = New System.Drawing.Point(4, 22)
        Me.tpCLI.Name = "tpCLI"
        Me.tpCLI.Size = New System.Drawing.Size(1016, 460)
        Me.tpCLI.TabIndex = 4
        Me.tpCLI.Text = "CLI"
        '
        'gbTerminal
        '
        Me.gbTerminal.Controls.Add(Me.Label2)
        Me.gbTerminal.Controls.Add(Me.Label1)
        Me.gbTerminal.Controls.Add(Me.Label4)
        Me.gbTerminal.Controls.Add(Me.Label3)
        Me.gbTerminal.Controls.Add(Me.Label5)
        Me.gbTerminal.Controls.Add(Me.lblSep1)
        Me.gbTerminal.Controls.Add(Me.cmdCLILoad)
        Me.gbTerminal.Controls.Add(Me.lblCLIHelp)
        Me.gbTerminal.Controls.Add(Me.cmdCLIDefaults)
        Me.gbTerminal.Controls.Add(Me.cmdCLIMap)
        Me.gbTerminal.Controls.Add(Me.cmdCLIVersion)
        Me.gbTerminal.Controls.Add(Me.cmdCLIStatus)
        Me.gbTerminal.Controls.Add(Me.cmdCLISave)
        Me.gbTerminal.Controls.Add(Me.cmdCLIFeature)
        Me.gbTerminal.Controls.Add(Me.cmdCLIDump)
        Me.gbTerminal.Controls.Add(Me.cmdCLIList)
        Me.gbTerminal.Controls.Add(Me.cmdCLISet)
        Me.gbTerminal.Controls.Add(Me.cmdCLIClearScreen)
        Me.gbTerminal.Controls.Add(Me.cmdCLIHelp)
        Me.gbTerminal.Controls.Add(Me.cmdCLISend)
        Me.gbTerminal.Controls.Add(Me.txtCLICommand)
        Me.gbTerminal.Controls.Add(Me.txtCLIResult)
        Me.gbTerminal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbTerminal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbTerminal.Location = New System.Drawing.Point(0, 0)
        Me.gbTerminal.Name = "gbTerminal"
        Me.gbTerminal.Size = New System.Drawing.Size(1016, 460)
        Me.gbTerminal.TabIndex = 2
        Me.gbTerminal.TabStop = False
        Me.gbTerminal.Text = "Terminal"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(935, 349)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 10)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "-------"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(935, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 10)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "-------"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Location = New System.Drawing.Point(935, 172)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 10)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "-------"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Location = New System.Drawing.Point(935, 211)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 10)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "-------"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Location = New System.Drawing.Point(935, 279)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 10)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "-------"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSep1
        '
        Me.lblSep1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSep1.Location = New System.Drawing.Point(935, 134)
        Me.lblSep1.Name = "lblSep1"
        Me.lblSep1.Size = New System.Drawing.Size(75, 10)
        Me.lblSep1.TabIndex = 4
        Me.lblSep1.Text = "-------"
        Me.lblSep1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdCLILoad
        '
        Me.cmdCLILoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCLILoad.Location = New System.Drawing.Point(935, 362)
        Me.cmdCLILoad.Name = "cmdCLILoad"
        Me.cmdCLILoad.Size = New System.Drawing.Size(75, 23)
        Me.cmdCLILoad.TabIndex = 3
        Me.cmdCLILoad.Text = "Load"
        Me.cmdCLILoad.UseVisualStyleBackColor = True
        '
        'lblCLIHelp
        '
        Me.lblCLIHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCLIHelp.AutoSize = True
        Me.lblCLIHelp.Location = New System.Drawing.Point(8, 416)
        Me.lblCLIHelp.Name = "lblCLIHelp"
        Me.lblCLIHelp.Size = New System.Drawing.Size(32, 13)
        Me.lblCLIHelp.TabIndex = 2
        Me.lblCLIHelp.Text = "Help:"
        '
        'cmdCLIDefaults
        '
        Me.cmdCLIDefaults.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCLIDefaults.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCLIDefaults.ForeColor = System.Drawing.Color.Red
        Me.cmdCLIDefaults.Location = New System.Drawing.Point(935, 328)
        Me.cmdCLIDefaults.Name = "cmdCLIDefaults"
        Me.cmdCLIDefaults.Size = New System.Drawing.Size(75, 22)
        Me.cmdCLIDefaults.TabIndex = 1
        Me.cmdCLIDefaults.Text = "Defaults"
        Me.cmdCLIDefaults.UseVisualStyleBackColor = True
        '
        'cmdCLIMap
        '
        Me.cmdCLIMap.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCLIMap.Location = New System.Drawing.Point(935, 149)
        Me.cmdCLIMap.Name = "cmdCLIMap"
        Me.cmdCLIMap.Size = New System.Drawing.Size(75, 22)
        Me.cmdCLIMap.TabIndex = 1
        Me.cmdCLIMap.Text = "Map"
        Me.cmdCLIMap.UseVisualStyleBackColor = True
        '
        'cmdCLIVersion
        '
        Me.cmdCLIVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCLIVersion.Location = New System.Drawing.Point(935, 83)
        Me.cmdCLIVersion.Name = "cmdCLIVersion"
        Me.cmdCLIVersion.Size = New System.Drawing.Size(75, 22)
        Me.cmdCLIVersion.TabIndex = 1
        Me.cmdCLIVersion.Text = "Version"
        Me.cmdCLIVersion.UseVisualStyleBackColor = True
        '
        'cmdCLIStatus
        '
        Me.cmdCLIStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCLIStatus.Location = New System.Drawing.Point(935, 111)
        Me.cmdCLIStatus.Name = "cmdCLIStatus"
        Me.cmdCLIStatus.Size = New System.Drawing.Size(75, 22)
        Me.cmdCLIStatus.TabIndex = 1
        Me.cmdCLIStatus.Text = "Status"
        Me.cmdCLIStatus.UseVisualStyleBackColor = True
        '
        'cmdCLISave
        '
        Me.cmdCLISave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCLISave.Location = New System.Drawing.Point(935, 391)
        Me.cmdCLISave.Name = "cmdCLISave"
        Me.cmdCLISave.Size = New System.Drawing.Size(75, 22)
        Me.cmdCLISave.TabIndex = 1
        Me.cmdCLISave.Text = "Save"
        Me.cmdCLISave.UseVisualStyleBackColor = True
        '
        'cmdCLIFeature
        '
        Me.cmdCLIFeature.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCLIFeature.Location = New System.Drawing.Point(935, 226)
        Me.cmdCLIFeature.Name = "cmdCLIFeature"
        Me.cmdCLIFeature.Size = New System.Drawing.Size(75, 22)
        Me.cmdCLIFeature.TabIndex = 1
        Me.cmdCLIFeature.Text = "Feature"
        Me.cmdCLIFeature.UseVisualStyleBackColor = True
        '
        'cmdCLIDump
        '
        Me.cmdCLIDump.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCLIDump.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCLIDump.Location = New System.Drawing.Point(935, 292)
        Me.cmdCLIDump.Name = "cmdCLIDump"
        Me.cmdCLIDump.Size = New System.Drawing.Size(75, 22)
        Me.cmdCLIDump.TabIndex = 1
        Me.cmdCLIDump.Text = "Dump"
        Me.cmdCLIDump.UseVisualStyleBackColor = True
        '
        'cmdCLIList
        '
        Me.cmdCLIList.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCLIList.Enabled = False
        Me.cmdCLIList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCLIList.Location = New System.Drawing.Point(935, 254)
        Me.cmdCLIList.Name = "cmdCLIList"
        Me.cmdCLIList.Size = New System.Drawing.Size(75, 22)
        Me.cmdCLIList.TabIndex = 1
        Me.cmdCLIList.Text = "List"
        Me.cmdCLIList.UseVisualStyleBackColor = True
        '
        'cmdCLISet
        '
        Me.cmdCLISet.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCLISet.Location = New System.Drawing.Point(935, 188)
        Me.cmdCLISet.Name = "cmdCLISet"
        Me.cmdCLISet.Size = New System.Drawing.Size(75, 22)
        Me.cmdCLISet.TabIndex = 1
        Me.cmdCLISet.Text = "Set"
        Me.cmdCLISet.UseVisualStyleBackColor = True
        '
        'cmdCLIClearScreen
        '
        Me.cmdCLIClearScreen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCLIClearScreen.Location = New System.Drawing.Point(935, 19)
        Me.cmdCLIClearScreen.Name = "cmdCLIClearScreen"
        Me.cmdCLIClearScreen.Size = New System.Drawing.Size(75, 22)
        Me.cmdCLIClearScreen.TabIndex = 1
        Me.cmdCLIClearScreen.Text = "Clear Screen"
        Me.cmdCLIClearScreen.UseVisualStyleBackColor = True
        '
        'cmdCLIHelp
        '
        Me.cmdCLIHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCLIHelp.Location = New System.Drawing.Point(935, 55)
        Me.cmdCLIHelp.Name = "cmdCLIHelp"
        Me.cmdCLIHelp.Size = New System.Drawing.Size(75, 22)
        Me.cmdCLIHelp.TabIndex = 1
        Me.cmdCLIHelp.Text = "Help"
        Me.cmdCLIHelp.UseVisualStyleBackColor = True
        '
        'cmdCLISend
        '
        Me.cmdCLISend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCLISend.Location = New System.Drawing.Point(935, 432)
        Me.cmdCLISend.Name = "cmdCLISend"
        Me.cmdCLISend.Size = New System.Drawing.Size(75, 22)
        Me.cmdCLISend.TabIndex = 1
        Me.cmdCLISend.Text = "Send"
        Me.cmdCLISend.UseVisualStyleBackColor = True
        '
        'txtCLICommand
        '
        Me.txtCLICommand.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCLICommand.ForeColor = System.Drawing.Color.Black
        Me.txtCLICommand.Location = New System.Drawing.Point(6, 432)
        Me.txtCLICommand.Name = "txtCLICommand"
        Me.txtCLICommand.Size = New System.Drawing.Size(923, 20)
        Me.txtCLICommand.TabIndex = 0
        '
        'txtCLIResult
        '
        Me.txtCLIResult.AllowDrop = True
        Me.txtCLIResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCLIResult.ForeColor = System.Drawing.Color.Black
        Me.txtCLIResult.Location = New System.Drawing.Point(6, 19)
        Me.txtCLIResult.Multiline = True
        Me.txtCLIResult.Name = "txtCLIResult"
        Me.txtCLIResult.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtCLIResult.Size = New System.Drawing.Size(923, 394)
        Me.txtCLIResult.TabIndex = 0
        '
        'tpGFWUpdate
        '
        Me.tpGFWUpdate.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tpGFWUpdate.Controls.Add(Me.chkFWShowOutput)
        Me.tpGFWUpdate.Controls.Add(Me.chkFWSendR)
        Me.tpGFWUpdate.Controls.Add(Me.lblFWError)
        Me.tpGFWUpdate.Controls.Add(Me.lblFWSuccessful)
        Me.tpGFWUpdate.Controls.Add(Me.cmdFWUpdate)
        Me.tpGFWUpdate.Controls.Add(Me.lblFWShowOutput)
        Me.tpGFWUpdate.Controls.Add(Me.txtFirmwareFile)
        Me.tpGFWUpdate.Controls.Add(Me.lblFWSendR)
        Me.tpGFWUpdate.Controls.Add(Me.lblFirmwareFile)
        Me.tpGFWUpdate.Controls.Add(Me.searchFirmwareFile)
        Me.tpGFWUpdate.Controls.Add(Me.LoadingCircle)
        Me.tpGFWUpdate.Location = New System.Drawing.Point(4, 22)
        Me.tpGFWUpdate.Name = "tpGFWUpdate"
        Me.tpGFWUpdate.Size = New System.Drawing.Size(1016, 460)
        Me.tpGFWUpdate.TabIndex = 3
        Me.tpGFWUpdate.Text = "Firmware Update"
        '
        'chkFWShowOutput
        '
        Me.chkFWShowOutput.AutoSize = True
        Me.chkFWShowOutput.Location = New System.Drawing.Point(94, 66)
        Me.chkFWShowOutput.Name = "chkFWShowOutput"
        Me.chkFWShowOutput.Size = New System.Drawing.Size(15, 14)
        Me.chkFWShowOutput.TabIndex = 7
        Me.chkFWShowOutput.UseVisualStyleBackColor = True
        '
        'chkFWSendR
        '
        Me.chkFWSendR.AutoSize = True
        Me.chkFWSendR.Checked = True
        Me.chkFWSendR.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFWSendR.Location = New System.Drawing.Point(94, 46)
        Me.chkFWSendR.Name = "chkFWSendR"
        Me.chkFWSendR.Size = New System.Drawing.Size(15, 14)
        Me.chkFWSendR.TabIndex = 7
        Me.chkFWSendR.UseVisualStyleBackColor = True
        '
        'lblFWError
        '
        Me.lblFWError.AutoSize = True
        Me.lblFWError.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFWError.ForeColor = System.Drawing.Color.Red
        Me.lblFWError.Location = New System.Drawing.Point(279, 46)
        Me.lblFWError.Name = "lblFWError"
        Me.lblFWError.Size = New System.Drawing.Size(85, 33)
        Me.lblFWError.TabIndex = 6
        Me.lblFWError.Text = "Error"
        Me.lblFWError.Visible = False
        '
        'lblFWSuccessful
        '
        Me.lblFWSuccessful.AutoSize = True
        Me.lblFWSuccessful.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFWSuccessful.ForeColor = System.Drawing.Color.Lime
        Me.lblFWSuccessful.Location = New System.Drawing.Point(256, 46)
        Me.lblFWSuccessful.Name = "lblFWSuccessful"
        Me.lblFWSuccessful.Size = New System.Drawing.Size(167, 33)
        Me.lblFWSuccessful.TabIndex = 6
        Me.lblFWSuccessful.Text = "Successful"
        Me.lblFWSuccessful.Visible = False
        '
        'cmdFWUpdate
        '
        Me.cmdFWUpdate.Location = New System.Drawing.Point(613, 12)
        Me.cmdFWUpdate.Name = "cmdFWUpdate"
        Me.cmdFWUpdate.Size = New System.Drawing.Size(75, 23)
        Me.cmdFWUpdate.TabIndex = 3
        Me.cmdFWUpdate.Text = "Update"
        Me.cmdFWUpdate.UseVisualStyleBackColor = True
        '
        'lblFWShowOutput
        '
        Me.lblFWShowOutput.AutoSize = True
        Me.lblFWShowOutput.Location = New System.Drawing.Point(8, 66)
        Me.lblFWShowOutput.Name = "lblFWShowOutput"
        Me.lblFWShowOutput.Size = New System.Drawing.Size(69, 13)
        Me.lblFWShowOutput.TabIndex = 1
        Me.lblFWShowOutput.Text = "Show Output"
        '
        'txtFirmwareFile
        '
        Me.txtFirmwareFile.Location = New System.Drawing.Point(94, 14)
        Me.txtFirmwareFile.Name = "txtFirmwareFile"
        Me.txtFirmwareFile.Size = New System.Drawing.Size(474, 20)
        Me.txtFirmwareFile.TabIndex = 2
        '
        'lblFWSendR
        '
        Me.lblFWSendR.AutoSize = True
        Me.lblFWSendR.Location = New System.Drawing.Point(8, 46)
        Me.lblFWSendR.Name = "lblFWSendR"
        Me.lblFWSendR.Size = New System.Drawing.Size(47, 13)
        Me.lblFWSendR.TabIndex = 1
        Me.lblFWSendR.Text = "Send 'R'"
        '
        'lblFirmwareFile
        '
        Me.lblFirmwareFile.AutoSize = True
        Me.lblFirmwareFile.Location = New System.Drawing.Point(8, 17)
        Me.lblFirmwareFile.Name = "lblFirmwareFile"
        Me.lblFirmwareFile.Size = New System.Drawing.Size(68, 13)
        Me.lblFirmwareFile.TabIndex = 1
        Me.lblFirmwareFile.Text = "Firmware File"
        '
        'searchFirmwareFile
        '
        Me.searchFirmwareFile.Location = New System.Drawing.Point(574, 12)
        Me.searchFirmwareFile.Name = "searchFirmwareFile"
        Me.searchFirmwareFile.Size = New System.Drawing.Size(23, 23)
        Me.searchFirmwareFile.TabIndex = 0
        Me.searchFirmwareFile.Text = ".."
        Me.searchFirmwareFile.UseVisualStyleBackColor = True
        '
        'timerRealtime
        '
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblPacketReceived, Me.lblVPacketReceived, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.lblVPacketError, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel5, Me.lblV_i2cerrors, Me.ToolStripStatusLabel7, Me.ToolStripStatusLabel6, Me.lblV_cycletime, Me.lblSpring, Me.lblUID, Me.lblVUID})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 539)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1024, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblPacketReceived
        '
        Me.lblPacketReceived.Name = "lblPacketReceived"
        Me.lblPacketReceived.Size = New System.Drawing.Size(97, 17)
        Me.lblPacketReceived.Text = "Packets received:"
        '
        'lblVPacketReceived
        '
        Me.lblVPacketReceived.Name = "lblVPacketReceived"
        Me.lblVPacketReceived.Size = New System.Drawing.Size(13, 17)
        Me.lblVPacketReceived.Text = "0"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel3.Text = "|"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(73, 17)
        Me.ToolStripStatusLabel4.Text = "Packet error:"
        '
        'lblVPacketError
        '
        Me.lblVPacketError.Name = "lblVPacketError"
        Me.lblVPacketError.Size = New System.Drawing.Size(13, 17)
        Me.lblVPacketError.Text = "0"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel1.Text = "|"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(87, 17)
        Me.ToolStripStatusLabel5.Text = "I²C Error count:"
        '
        'lblV_i2cerrors
        '
        Me.lblV_i2cerrors.Name = "lblV_i2cerrors"
        Me.lblV_i2cerrors.Size = New System.Drawing.Size(31, 17)
        Me.lblV_i2cerrors.Text = "0000"
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel7.Text = "|"
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(69, 17)
        Me.ToolStripStatusLabel6.Text = "Cycle Time:"
        '
        'lblV_cycletime
        '
        Me.lblV_cycletime.Name = "lblV_cycletime"
        Me.lblV_cycletime.Size = New System.Drawing.Size(13, 17)
        Me.lblV_cycletime.Text = "0"
        '
        'lblSpring
        '
        Me.lblSpring.Name = "lblSpring"
        Me.lblSpring.Size = New System.Drawing.Size(411, 17)
        Me.lblSpring.Spring = True
        '
        'lblUID
        '
        Me.lblUID.Name = "lblUID"
        Me.lblUID.Size = New System.Drawing.Size(99, 17)
        Me.lblUID.Text = "Unique device ID:"
        '
        'lblVUID
        '
        Me.lblVUID.Name = "lblVUID"
        Me.lblVUID.Size = New System.Drawing.Size(73, 17)
        Me.lblVUID.Text = "xxxx.xxxx.xxxx"
        '
        'lblRT_THR
        '
        Me.lblRT_THR.AutoSize = True
        Me.lblRT_THR.Location = New System.Drawing.Point(7, 8)
        Me.lblRT_THR.Name = "lblRT_THR"
        Me.lblRT_THR.Size = New System.Drawing.Size(30, 13)
        Me.lblRT_THR.TabIndex = 0
        Me.lblRT_THR.Text = "THR"
        '
        'lblRT_PITCH
        '
        Me.lblRT_PITCH.AutoSize = True
        Me.lblRT_PITCH.Location = New System.Drawing.Point(7, 27)
        Me.lblRT_PITCH.Name = "lblRT_PITCH"
        Me.lblRT_PITCH.Size = New System.Drawing.Size(39, 13)
        Me.lblRT_PITCH.TabIndex = 0
        Me.lblRT_PITCH.Text = "PITCH"
        '
        'lblRT_ROLL
        '
        Me.lblRT_ROLL.AutoSize = True
        Me.lblRT_ROLL.Location = New System.Drawing.Point(7, 46)
        Me.lblRT_ROLL.Name = "lblRT_ROLL"
        Me.lblRT_ROLL.Size = New System.Drawing.Size(35, 13)
        Me.lblRT_ROLL.TabIndex = 0
        Me.lblRT_ROLL.Text = "ROLL"
        '
        'lblRT_YAW
        '
        Me.lblRT_YAW.AutoSize = True
        Me.lblRT_YAW.Location = New System.Drawing.Point(7, 65)
        Me.lblRT_YAW.Name = "lblRT_YAW"
        Me.lblRT_YAW.Size = New System.Drawing.Size(32, 13)
        Me.lblRT_YAW.TabIndex = 0
        Me.lblRT_YAW.Text = "YAW"
        '
        'lblRT_AUX1
        '
        Me.lblRT_AUX1.AutoSize = True
        Me.lblRT_AUX1.Location = New System.Drawing.Point(7, 84)
        Me.lblRT_AUX1.Name = "lblRT_AUX1"
        Me.lblRT_AUX1.Size = New System.Drawing.Size(35, 13)
        Me.lblRT_AUX1.TabIndex = 0
        Me.lblRT_AUX1.Text = "AUX1"
        '
        'lblRT_AUX2
        '
        Me.lblRT_AUX2.AutoSize = True
        Me.lblRT_AUX2.Location = New System.Drawing.Point(7, 103)
        Me.lblRT_AUX2.Name = "lblRT_AUX2"
        Me.lblRT_AUX2.Size = New System.Drawing.Size(35, 13)
        Me.lblRT_AUX2.TabIndex = 0
        Me.lblRT_AUX2.Text = "AUX2"
        '
        'lblRT_AUX3
        '
        Me.lblRT_AUX3.AutoSize = True
        Me.lblRT_AUX3.Location = New System.Drawing.Point(7, 122)
        Me.lblRT_AUX3.Name = "lblRT_AUX3"
        Me.lblRT_AUX3.Size = New System.Drawing.Size(35, 13)
        Me.lblRT_AUX3.TabIndex = 0
        Me.lblRT_AUX3.Text = "AUX3"
        '
        'lblRT_AUX4
        '
        Me.lblRT_AUX4.AutoSize = True
        Me.lblRT_AUX4.Location = New System.Drawing.Point(7, 141)
        Me.lblRT_AUX4.Name = "lblRT_AUX4"
        Me.lblRT_AUX4.Size = New System.Drawing.Size(35, 13)
        Me.lblRT_AUX4.TabIndex = 0
        Me.lblRT_AUX4.Text = "AUX4"
        '
        'lblRT_AUX5
        '
        Me.lblRT_AUX5.AutoSize = True
        Me.lblRT_AUX5.Location = New System.Drawing.Point(7, 160)
        Me.lblRT_AUX5.Name = "lblRT_AUX5"
        Me.lblRT_AUX5.Size = New System.Drawing.Size(35, 13)
        Me.lblRT_AUX5.TabIndex = 0
        Me.lblRT_AUX5.Text = "AUX5"
        '
        'lblRT_AUX6
        '
        Me.lblRT_AUX6.AutoSize = True
        Me.lblRT_AUX6.Location = New System.Drawing.Point(7, 179)
        Me.lblRT_AUX6.Name = "lblRT_AUX6"
        Me.lblRT_AUX6.Size = New System.Drawing.Size(35, 13)
        Me.lblRT_AUX6.TabIndex = 0
        Me.lblRT_AUX6.Text = "AUX6"
        '
        'lblRT_AUX7
        '
        Me.lblRT_AUX7.AutoSize = True
        Me.lblRT_AUX7.Location = New System.Drawing.Point(7, 198)
        Me.lblRT_AUX7.Name = "lblRT_AUX7"
        Me.lblRT_AUX7.Size = New System.Drawing.Size(35, 13)
        Me.lblRT_AUX7.TabIndex = 0
        Me.lblRT_AUX7.Text = "AUX7"
        '
        'lblRT_AUX8
        '
        Me.lblRT_AUX8.AutoSize = True
        Me.lblRT_AUX8.Location = New System.Drawing.Point(7, 217)
        Me.lblRT_AUX8.Name = "lblRT_AUX8"
        Me.lblRT_AUX8.Size = New System.Drawing.Size(35, 13)
        Me.lblRT_AUX8.TabIndex = 0
        Me.lblRT_AUX8.Text = "AUX8"
        '
        'pgbRT_THR
        '
        Me.pgbRT_THR.BarColor1 = System.Drawing.Color.DarkGray
        Me.pgbRT_THR.BarColor2 = System.Drawing.Color.LightGray
        Me.pgbRT_THR.Location = New System.Drawing.Point(48, 3)
        Me.pgbRT_THR.Maximum = 2100
        Me.pgbRT_THR.Minimum = 900
        Me.pgbRT_THR.Name = "pgbRT_THR"
        Me.pgbRT_THR.Size = New System.Drawing.Size(130, 18)
        Me.pgbRT_THR.TabIndex = 1
        Me.pgbRT_THR.Value = 1500
        '
        'lblVRT_THR
        '
        Me.lblVRT_THR.AutoSize = True
        Me.lblVRT_THR.Location = New System.Drawing.Point(180, 6)
        Me.lblVRT_THR.Name = "lblVRT_THR"
        Me.lblVRT_THR.Size = New System.Drawing.Size(31, 13)
        Me.lblVRT_THR.TabIndex = 0
        Me.lblVRT_THR.Text = "1500"
        '
        'lblVRT_PITCH
        '
        Me.lblVRT_PITCH.AutoSize = True
        Me.lblVRT_PITCH.Location = New System.Drawing.Point(180, 25)
        Me.lblVRT_PITCH.Name = "lblVRT_PITCH"
        Me.lblVRT_PITCH.Size = New System.Drawing.Size(31, 13)
        Me.lblVRT_PITCH.TabIndex = 0
        Me.lblVRT_PITCH.Text = "1500"
        '
        'pgbRT_PITCH
        '
        Me.pgbRT_PITCH.BarColor1 = System.Drawing.Color.DarkGray
        Me.pgbRT_PITCH.BarColor2 = System.Drawing.Color.LightGray
        Me.pgbRT_PITCH.Location = New System.Drawing.Point(48, 22)
        Me.pgbRT_PITCH.Maximum = 2100
        Me.pgbRT_PITCH.Minimum = 900
        Me.pgbRT_PITCH.Name = "pgbRT_PITCH"
        Me.pgbRT_PITCH.Size = New System.Drawing.Size(130, 18)
        Me.pgbRT_PITCH.TabIndex = 1
        Me.pgbRT_PITCH.Value = 1500
        '
        'lblVRT_ROLL
        '
        Me.lblVRT_ROLL.AutoSize = True
        Me.lblVRT_ROLL.Location = New System.Drawing.Point(180, 44)
        Me.lblVRT_ROLL.Name = "lblVRT_ROLL"
        Me.lblVRT_ROLL.Size = New System.Drawing.Size(31, 13)
        Me.lblVRT_ROLL.TabIndex = 0
        Me.lblVRT_ROLL.Text = "1500"
        '
        'pgbRT_ROLL
        '
        Me.pgbRT_ROLL.BarColor1 = System.Drawing.Color.DarkGray
        Me.pgbRT_ROLL.BarColor2 = System.Drawing.Color.LightGray
        Me.pgbRT_ROLL.Location = New System.Drawing.Point(48, 41)
        Me.pgbRT_ROLL.Maximum = 2100
        Me.pgbRT_ROLL.Minimum = 900
        Me.pgbRT_ROLL.Name = "pgbRT_ROLL"
        Me.pgbRT_ROLL.Size = New System.Drawing.Size(130, 18)
        Me.pgbRT_ROLL.TabIndex = 1
        Me.pgbRT_ROLL.Value = 1500
        '
        'lblVRT_YAW
        '
        Me.lblVRT_YAW.AutoSize = True
        Me.lblVRT_YAW.Location = New System.Drawing.Point(180, 63)
        Me.lblVRT_YAW.Name = "lblVRT_YAW"
        Me.lblVRT_YAW.Size = New System.Drawing.Size(31, 13)
        Me.lblVRT_YAW.TabIndex = 0
        Me.lblVRT_YAW.Text = "1500"
        '
        'pgbRT_YAW
        '
        Me.pgbRT_YAW.BarColor1 = System.Drawing.Color.DarkGray
        Me.pgbRT_YAW.BarColor2 = System.Drawing.Color.LightGray
        Me.pgbRT_YAW.Location = New System.Drawing.Point(48, 60)
        Me.pgbRT_YAW.Maximum = 2100
        Me.pgbRT_YAW.Minimum = 900
        Me.pgbRT_YAW.Name = "pgbRT_YAW"
        Me.pgbRT_YAW.Size = New System.Drawing.Size(130, 18)
        Me.pgbRT_YAW.TabIndex = 1
        Me.pgbRT_YAW.Value = 1500
        '
        'lblVRT_AUX1
        '
        Me.lblVRT_AUX1.AutoSize = True
        Me.lblVRT_AUX1.Location = New System.Drawing.Point(180, 82)
        Me.lblVRT_AUX1.Name = "lblVRT_AUX1"
        Me.lblVRT_AUX1.Size = New System.Drawing.Size(31, 13)
        Me.lblVRT_AUX1.TabIndex = 0
        Me.lblVRT_AUX1.Text = "1500"
        '
        'pgbRT_AUX1
        '
        Me.pgbRT_AUX1.BarColor1 = System.Drawing.Color.DarkGray
        Me.pgbRT_AUX1.BarColor2 = System.Drawing.Color.LightGray
        Me.pgbRT_AUX1.Location = New System.Drawing.Point(48, 79)
        Me.pgbRT_AUX1.Maximum = 2100
        Me.pgbRT_AUX1.Minimum = 900
        Me.pgbRT_AUX1.Name = "pgbRT_AUX1"
        Me.pgbRT_AUX1.Size = New System.Drawing.Size(130, 18)
        Me.pgbRT_AUX1.TabIndex = 1
        Me.pgbRT_AUX1.Value = 1500
        '
        'lblVRT_AUX2
        '
        Me.lblVRT_AUX2.AutoSize = True
        Me.lblVRT_AUX2.Location = New System.Drawing.Point(180, 101)
        Me.lblVRT_AUX2.Name = "lblVRT_AUX2"
        Me.lblVRT_AUX2.Size = New System.Drawing.Size(31, 13)
        Me.lblVRT_AUX2.TabIndex = 0
        Me.lblVRT_AUX2.Text = "1500"
        '
        'pgbRT_AUX2
        '
        Me.pgbRT_AUX2.BarColor1 = System.Drawing.Color.DarkGray
        Me.pgbRT_AUX2.BarColor2 = System.Drawing.Color.LightGray
        Me.pgbRT_AUX2.Location = New System.Drawing.Point(48, 98)
        Me.pgbRT_AUX2.Maximum = 2100
        Me.pgbRT_AUX2.Minimum = 900
        Me.pgbRT_AUX2.Name = "pgbRT_AUX2"
        Me.pgbRT_AUX2.Size = New System.Drawing.Size(130, 18)
        Me.pgbRT_AUX2.TabIndex = 1
        Me.pgbRT_AUX2.Value = 1500
        '
        'lblVRT_AUX3
        '
        Me.lblVRT_AUX3.AutoSize = True
        Me.lblVRT_AUX3.Location = New System.Drawing.Point(180, 120)
        Me.lblVRT_AUX3.Name = "lblVRT_AUX3"
        Me.lblVRT_AUX3.Size = New System.Drawing.Size(31, 13)
        Me.lblVRT_AUX3.TabIndex = 0
        Me.lblVRT_AUX3.Text = "1500"
        '
        'pgbRT_AUX3
        '
        Me.pgbRT_AUX3.BarColor1 = System.Drawing.Color.DarkGray
        Me.pgbRT_AUX3.BarColor2 = System.Drawing.Color.LightGray
        Me.pgbRT_AUX3.Location = New System.Drawing.Point(48, 117)
        Me.pgbRT_AUX3.Maximum = 2100
        Me.pgbRT_AUX3.Minimum = 900
        Me.pgbRT_AUX3.Name = "pgbRT_AUX3"
        Me.pgbRT_AUX3.Size = New System.Drawing.Size(130, 18)
        Me.pgbRT_AUX3.TabIndex = 1
        Me.pgbRT_AUX3.Value = 1500
        '
        'lblVRT_AUX4
        '
        Me.lblVRT_AUX4.AutoSize = True
        Me.lblVRT_AUX4.Location = New System.Drawing.Point(180, 139)
        Me.lblVRT_AUX4.Name = "lblVRT_AUX4"
        Me.lblVRT_AUX4.Size = New System.Drawing.Size(31, 13)
        Me.lblVRT_AUX4.TabIndex = 0
        Me.lblVRT_AUX4.Text = "1500"
        '
        'pgbRT_AUX4
        '
        Me.pgbRT_AUX4.BarColor1 = System.Drawing.Color.DarkGray
        Me.pgbRT_AUX4.BarColor2 = System.Drawing.Color.LightGray
        Me.pgbRT_AUX4.Location = New System.Drawing.Point(48, 136)
        Me.pgbRT_AUX4.Maximum = 2100
        Me.pgbRT_AUX4.Minimum = 900
        Me.pgbRT_AUX4.Name = "pgbRT_AUX4"
        Me.pgbRT_AUX4.Size = New System.Drawing.Size(130, 18)
        Me.pgbRT_AUX4.TabIndex = 1
        Me.pgbRT_AUX4.Value = 1500
        '
        'lblVRT_AUX5
        '
        Me.lblVRT_AUX5.AutoSize = True
        Me.lblVRT_AUX5.Location = New System.Drawing.Point(180, 158)
        Me.lblVRT_AUX5.Name = "lblVRT_AUX5"
        Me.lblVRT_AUX5.Size = New System.Drawing.Size(31, 13)
        Me.lblVRT_AUX5.TabIndex = 0
        Me.lblVRT_AUX5.Text = "1500"
        '
        'pgbRT_AUX5
        '
        Me.pgbRT_AUX5.BarColor1 = System.Drawing.Color.DarkGray
        Me.pgbRT_AUX5.BarColor2 = System.Drawing.Color.LightGray
        Me.pgbRT_AUX5.Location = New System.Drawing.Point(48, 155)
        Me.pgbRT_AUX5.Maximum = 2100
        Me.pgbRT_AUX5.Minimum = 900
        Me.pgbRT_AUX5.Name = "pgbRT_AUX5"
        Me.pgbRT_AUX5.Size = New System.Drawing.Size(130, 18)
        Me.pgbRT_AUX5.TabIndex = 1
        Me.pgbRT_AUX5.Value = 1500
        '
        'lblVRT_AUX6
        '
        Me.lblVRT_AUX6.AutoSize = True
        Me.lblVRT_AUX6.Location = New System.Drawing.Point(180, 177)
        Me.lblVRT_AUX6.Name = "lblVRT_AUX6"
        Me.lblVRT_AUX6.Size = New System.Drawing.Size(31, 13)
        Me.lblVRT_AUX6.TabIndex = 0
        Me.lblVRT_AUX6.Text = "1500"
        '
        'pgbRT_AUX6
        '
        Me.pgbRT_AUX6.BarColor1 = System.Drawing.Color.DarkGray
        Me.pgbRT_AUX6.BarColor2 = System.Drawing.Color.LightGray
        Me.pgbRT_AUX6.Location = New System.Drawing.Point(48, 174)
        Me.pgbRT_AUX6.Maximum = 2100
        Me.pgbRT_AUX6.Minimum = 900
        Me.pgbRT_AUX6.Name = "pgbRT_AUX6"
        Me.pgbRT_AUX6.Size = New System.Drawing.Size(130, 18)
        Me.pgbRT_AUX6.TabIndex = 1
        Me.pgbRT_AUX6.Value = 1500
        '
        'lblVRT_AUX7
        '
        Me.lblVRT_AUX7.AutoSize = True
        Me.lblVRT_AUX7.Location = New System.Drawing.Point(180, 196)
        Me.lblVRT_AUX7.Name = "lblVRT_AUX7"
        Me.lblVRT_AUX7.Size = New System.Drawing.Size(31, 13)
        Me.lblVRT_AUX7.TabIndex = 0
        Me.lblVRT_AUX7.Text = "1500"
        '
        'pgbRT_AUX7
        '
        Me.pgbRT_AUX7.BarColor1 = System.Drawing.Color.DarkGray
        Me.pgbRT_AUX7.BarColor2 = System.Drawing.Color.LightGray
        Me.pgbRT_AUX7.Location = New System.Drawing.Point(48, 193)
        Me.pgbRT_AUX7.Maximum = 2100
        Me.pgbRT_AUX7.Minimum = 900
        Me.pgbRT_AUX7.Name = "pgbRT_AUX7"
        Me.pgbRT_AUX7.Size = New System.Drawing.Size(130, 18)
        Me.pgbRT_AUX7.TabIndex = 1
        Me.pgbRT_AUX7.Value = 1500
        '
        'lblVRT_AUX8
        '
        Me.lblVRT_AUX8.AutoSize = True
        Me.lblVRT_AUX8.Location = New System.Drawing.Point(180, 215)
        Me.lblVRT_AUX8.Name = "lblVRT_AUX8"
        Me.lblVRT_AUX8.Size = New System.Drawing.Size(31, 13)
        Me.lblVRT_AUX8.TabIndex = 0
        Me.lblVRT_AUX8.Text = "1500"
        '
        'pgbRT_AUX8
        '
        Me.pgbRT_AUX8.BarColor1 = System.Drawing.Color.DarkGray
        Me.pgbRT_AUX8.BarColor2 = System.Drawing.Color.LightGray
        Me.pgbRT_AUX8.Location = New System.Drawing.Point(48, 212)
        Me.pgbRT_AUX8.Maximum = 2100
        Me.pgbRT_AUX8.Minimum = 900
        Me.pgbRT_AUX8.Name = "pgbRT_AUX8"
        Me.pgbRT_AUX8.Size = New System.Drawing.Size(130, 18)
        Me.pgbRT_AUX8.TabIndex = 1
        Me.pgbRT_AUX8.Value = 1500
        '
        'Rc_expo_control1
        '
        Me.Rc_expo_control1.Location = New System.Drawing.Point(436, 27)
        Me.Rc_expo_control1.Name = "Rc_expo_control1"
        Me.Rc_expo_control1.Size = New System.Drawing.Size(150, 100)
        Me.Rc_expo_control1.TabIndex = 14
        Me.Rc_expo_control1.Text = "Rc_expo_control1"
        '
        'Throttle_expo_control1
        '
        Me.Throttle_expo_control1.Location = New System.Drawing.Point(436, 211)
        Me.Throttle_expo_control1.Name = "Throttle_expo_control1"
        Me.Throttle_expo_control1.Size = New System.Drawing.Size(150, 100)
        Me.Throttle_expo_control1.TabIndex = 11
        Me.Throttle_expo_control1.Text = "Throttle_expo_control1"
        '
        'lcAux
        '
        Me.lcAux.Active = False
        Me.lcAux.Color = System.Drawing.Color.DarkGray
        Me.lcAux.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lcAux.InnerCircleRadius = 45
        Me.lcAux.Location = New System.Drawing.Point(0, 0)
        Me.lcAux.Name = "lcAux"
        Me.lcAux.NumberSpoke = 10
        Me.lcAux.OuterCircleRadius = 50
        Me.lcAux.RotationSpeed = 100
        Me.lcAux.Size = New System.Drawing.Size(624, 449)
        Me.lcAux.SpokeThickness = 4
        Me.lcAux.StylePreset = BaseflightGUI.MRG.Controls.UI.LoadingCircle.StylePresets.Firefox
        Me.lcAux.TabIndex = 0
        Me.lcAux.Text = "LoadingCircle1"
        Me.lcAux.Visible = False
        '
        'Motor
        '
        Me.Motor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Motor.Location = New System.Drawing.Point(620, 30)
        Me.Motor.Name = "Motor"
        Me.Motor.Size = New System.Drawing.Size(170, 200)
        Me.Motor.TabIndex = 119
        Me.Motor.Text = "BaseglightMotors1"
        '
        'ctrlHEADING
        '
        Me.ctrlHEADING.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ctrlHEADING.Location = New System.Drawing.Point(325, 289)
        Me.ctrlHEADING.Name = "ctrlHEADING"
        Me.ctrlHEADING.Size = New System.Drawing.Size(150, 150)
        Me.ctrlHEADING.TabIndex = 87
        Me.ctrlHEADING.Text = "Heading_indicator2"
        '
        'ctrlGPS
        '
        Me.ctrlGPS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ctrlGPS.Location = New System.Drawing.Point(8, 289)
        Me.ctrlGPS.Name = "ctrlGPS"
        Me.ctrlGPS.Size = New System.Drawing.Size(150, 150)
        Me.ctrlGPS.TabIndex = 86
        Me.ctrlGPS.Text = "GpsIndicatorInstrumentControl2"
        '
        'ctrlHORIZON
        '
        Me.ctrlHORIZON.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ctrlHORIZON.Location = New System.Drawing.Point(164, 289)
        Me.ctrlHORIZON.Name = "ctrlHORIZON"
        Me.ctrlHORIZON.Size = New System.Drawing.Size(150, 150)
        Me.ctrlHORIZON.TabIndex = 85
        Me.ctrlHORIZON.Text = "Artifical_horizon2"
        '
        'LoadingCircle
        '
        Me.LoadingCircle.Active = False
        Me.LoadingCircle.Color = System.Drawing.Color.DarkGray
        Me.LoadingCircle.InnerCircleRadius = 45
        Me.LoadingCircle.Location = New System.Drawing.Point(218, 82)
        Me.LoadingCircle.Name = "LoadingCircle"
        Me.LoadingCircle.NumberSpoke = 10
        Me.LoadingCircle.OuterCircleRadius = 50
        Me.LoadingCircle.RotationSpeed = 100
        Me.LoadingCircle.Size = New System.Drawing.Size(250, 250)
        Me.LoadingCircle.SpokeThickness = 4
        Me.LoadingCircle.StylePreset = BaseflightGUI.MRG.Controls.UI.LoadingCircle.StylePresets.MacOSX
        Me.LoadingCircle.TabIndex = 5
        Me.LoadingCircle.Visible = False
        '
        'pgbRC_AUX8
        '
        Me.pgbRC_AUX8.BarColor1 = System.Drawing.Color.DarkGray
        Me.pgbRC_AUX8.BarColor2 = System.Drawing.Color.LightGray
        Me.pgbRC_AUX8.Location = New System.Drawing.Point(48, 212)
        Me.pgbRC_AUX8.Maximum = 2100
        Me.pgbRC_AUX8.Minimum = 900
        Me.pgbRC_AUX8.Name = "pgbRC_AUX8"
        Me.pgbRC_AUX8.Size = New System.Drawing.Size(130, 18)
        Me.pgbRC_AUX8.TabIndex = 37
        Me.pgbRC_AUX8.Value = 1500
        '
        'pgbRC_AUX7
        '
        Me.pgbRC_AUX7.BarColor1 = System.Drawing.Color.DarkGray
        Me.pgbRC_AUX7.BarColor2 = System.Drawing.Color.LightGray
        Me.pgbRC_AUX7.Location = New System.Drawing.Point(48, 193)
        Me.pgbRC_AUX7.Maximum = 2100
        Me.pgbRC_AUX7.Minimum = 900
        Me.pgbRC_AUX7.Name = "pgbRC_AUX7"
        Me.pgbRC_AUX7.Size = New System.Drawing.Size(130, 18)
        Me.pgbRC_AUX7.TabIndex = 26
        Me.pgbRC_AUX7.Value = 1500
        '
        'pgbRC_AUX6
        '
        Me.pgbRC_AUX6.BarColor1 = System.Drawing.Color.DarkGray
        Me.pgbRC_AUX6.BarColor2 = System.Drawing.Color.LightGray
        Me.pgbRC_AUX6.Location = New System.Drawing.Point(48, 174)
        Me.pgbRC_AUX6.Maximum = 2100
        Me.pgbRC_AUX6.Minimum = 900
        Me.pgbRC_AUX6.Name = "pgbRC_AUX6"
        Me.pgbRC_AUX6.Size = New System.Drawing.Size(130, 18)
        Me.pgbRC_AUX6.TabIndex = 27
        Me.pgbRC_AUX6.Value = 1500
        '
        'pgbRC_AUX5
        '
        Me.pgbRC_AUX5.BarColor1 = System.Drawing.Color.DarkGray
        Me.pgbRC_AUX5.BarColor2 = System.Drawing.Color.LightGray
        Me.pgbRC_AUX5.Location = New System.Drawing.Point(48, 155)
        Me.pgbRC_AUX5.Maximum = 2100
        Me.pgbRC_AUX5.Minimum = 900
        Me.pgbRC_AUX5.Name = "pgbRC_AUX5"
        Me.pgbRC_AUX5.Size = New System.Drawing.Size(130, 18)
        Me.pgbRC_AUX5.TabIndex = 28
        Me.pgbRC_AUX5.Value = 1500
        '
        'pgbRC_AUX4
        '
        Me.pgbRC_AUX4.BarColor1 = System.Drawing.Color.DarkGray
        Me.pgbRC_AUX4.BarColor2 = System.Drawing.Color.LightGray
        Me.pgbRC_AUX4.Location = New System.Drawing.Point(48, 136)
        Me.pgbRC_AUX4.Maximum = 2100
        Me.pgbRC_AUX4.Minimum = 900
        Me.pgbRC_AUX4.Name = "pgbRC_AUX4"
        Me.pgbRC_AUX4.Size = New System.Drawing.Size(130, 18)
        Me.pgbRC_AUX4.TabIndex = 29
        Me.pgbRC_AUX4.Value = 1500
        '
        'pgbRC_AUX3
        '
        Me.pgbRC_AUX3.BarColor1 = System.Drawing.Color.DarkGray
        Me.pgbRC_AUX3.BarColor2 = System.Drawing.Color.LightGray
        Me.pgbRC_AUX3.Location = New System.Drawing.Point(48, 117)
        Me.pgbRC_AUX3.Maximum = 2100
        Me.pgbRC_AUX3.Minimum = 900
        Me.pgbRC_AUX3.Name = "pgbRC_AUX3"
        Me.pgbRC_AUX3.Size = New System.Drawing.Size(130, 18)
        Me.pgbRC_AUX3.TabIndex = 30
        Me.pgbRC_AUX3.Value = 1500
        '
        'pgbRC_AUX2
        '
        Me.pgbRC_AUX2.BarColor1 = System.Drawing.Color.DarkGray
        Me.pgbRC_AUX2.BarColor2 = System.Drawing.Color.LightGray
        Me.pgbRC_AUX2.Location = New System.Drawing.Point(48, 98)
        Me.pgbRC_AUX2.Maximum = 2100
        Me.pgbRC_AUX2.Minimum = 900
        Me.pgbRC_AUX2.Name = "pgbRC_AUX2"
        Me.pgbRC_AUX2.Size = New System.Drawing.Size(130, 18)
        Me.pgbRC_AUX2.TabIndex = 36
        Me.pgbRC_AUX2.Value = 1500
        '
        'pgbRC_AUX1
        '
        Me.pgbRC_AUX1.BarColor1 = System.Drawing.Color.DarkGray
        Me.pgbRC_AUX1.BarColor2 = System.Drawing.Color.LightGray
        Me.pgbRC_AUX1.Location = New System.Drawing.Point(48, 79)
        Me.pgbRC_AUX1.Maximum = 2100
        Me.pgbRC_AUX1.Minimum = 900
        Me.pgbRC_AUX1.Name = "pgbRC_AUX1"
        Me.pgbRC_AUX1.Size = New System.Drawing.Size(130, 18)
        Me.pgbRC_AUX1.TabIndex = 32
        Me.pgbRC_AUX1.Value = 1500
        '
        'pgbRC_YAW
        '
        Me.pgbRC_YAW.BarColor1 = System.Drawing.Color.DarkGray
        Me.pgbRC_YAW.BarColor2 = System.Drawing.Color.LightGray
        Me.pgbRC_YAW.Location = New System.Drawing.Point(48, 60)
        Me.pgbRC_YAW.Maximum = 2100
        Me.pgbRC_YAW.Minimum = 900
        Me.pgbRC_YAW.Name = "pgbRC_YAW"
        Me.pgbRC_YAW.Size = New System.Drawing.Size(130, 18)
        Me.pgbRC_YAW.TabIndex = 31
        Me.pgbRC_YAW.Value = 1500
        '
        'pgbRC_ROLL
        '
        Me.pgbRC_ROLL.BarColor1 = System.Drawing.Color.DarkGray
        Me.pgbRC_ROLL.BarColor2 = System.Drawing.Color.LightGray
        Me.pgbRC_ROLL.Location = New System.Drawing.Point(48, 41)
        Me.pgbRC_ROLL.Maximum = 2100
        Me.pgbRC_ROLL.Minimum = 900
        Me.pgbRC_ROLL.Name = "pgbRC_ROLL"
        Me.pgbRC_ROLL.Size = New System.Drawing.Size(130, 18)
        Me.pgbRC_ROLL.TabIndex = 33
        Me.pgbRC_ROLL.Value = 1500
        '
        'pgbRC_PITCH
        '
        Me.pgbRC_PITCH.BarColor1 = System.Drawing.Color.DarkGray
        Me.pgbRC_PITCH.BarColor2 = System.Drawing.Color.LightGray
        Me.pgbRC_PITCH.Location = New System.Drawing.Point(48, 22)
        Me.pgbRC_PITCH.Maximum = 2100
        Me.pgbRC_PITCH.Minimum = 900
        Me.pgbRC_PITCH.Name = "pgbRC_PITCH"
        Me.pgbRC_PITCH.Size = New System.Drawing.Size(130, 18)
        Me.pgbRC_PITCH.TabIndex = 34
        Me.pgbRC_PITCH.Value = 1500
        '
        'pgbRC_THR
        '
        Me.pgbRC_THR.BarColor1 = System.Drawing.Color.DarkGray
        Me.pgbRC_THR.BarColor2 = System.Drawing.Color.LightGray
        Me.pgbRC_THR.Location = New System.Drawing.Point(48, 3)
        Me.pgbRC_THR.Maximum = 2100
        Me.pgbRC_THR.Minimum = 900
        Me.pgbRC_THR.Name = "pgbRC_THR"
        Me.pgbRC_THR.Size = New System.Drawing.Size(130, 18)
        Me.pgbRC_THR.TabIndex = 35
        Me.pgbRC_THR.Value = 1500
        '
        'lblRC_AUX8
        '
        Me.lblRC_AUX8.AutoSize = True
        Me.lblRC_AUX8.Location = New System.Drawing.Point(7, 217)
        Me.lblRC_AUX8.Name = "lblRC_AUX8"
        Me.lblRC_AUX8.Size = New System.Drawing.Size(35, 13)
        Me.lblRC_AUX8.TabIndex = 24
        Me.lblRC_AUX8.Text = "AUX8"
        '
        'lblRC_AUX7
        '
        Me.lblRC_AUX7.AutoSize = True
        Me.lblRC_AUX7.Location = New System.Drawing.Point(7, 198)
        Me.lblRC_AUX7.Name = "lblRC_AUX7"
        Me.lblRC_AUX7.Size = New System.Drawing.Size(35, 13)
        Me.lblRC_AUX7.TabIndex = 23
        Me.lblRC_AUX7.Text = "AUX7"
        '
        'lblRC_AUX6
        '
        Me.lblRC_AUX6.AutoSize = True
        Me.lblRC_AUX6.Location = New System.Drawing.Point(7, 179)
        Me.lblRC_AUX6.Name = "lblRC_AUX6"
        Me.lblRC_AUX6.Size = New System.Drawing.Size(35, 13)
        Me.lblRC_AUX6.TabIndex = 22
        Me.lblRC_AUX6.Text = "AUX6"
        '
        'lblRC_AUX5
        '
        Me.lblRC_AUX5.AutoSize = True
        Me.lblRC_AUX5.Location = New System.Drawing.Point(7, 160)
        Me.lblRC_AUX5.Name = "lblRC_AUX5"
        Me.lblRC_AUX5.Size = New System.Drawing.Size(35, 13)
        Me.lblRC_AUX5.TabIndex = 21
        Me.lblRC_AUX5.Text = "AUX5"
        '
        'lblRC_AUX4
        '
        Me.lblRC_AUX4.AutoSize = True
        Me.lblRC_AUX4.Location = New System.Drawing.Point(7, 141)
        Me.lblRC_AUX4.Name = "lblRC_AUX4"
        Me.lblRC_AUX4.Size = New System.Drawing.Size(35, 13)
        Me.lblRC_AUX4.TabIndex = 20
        Me.lblRC_AUX4.Text = "AUX4"
        '
        'lblRC_AUX3
        '
        Me.lblRC_AUX3.AutoSize = True
        Me.lblRC_AUX3.Location = New System.Drawing.Point(7, 122)
        Me.lblRC_AUX3.Name = "lblRC_AUX3"
        Me.lblRC_AUX3.Size = New System.Drawing.Size(35, 13)
        Me.lblRC_AUX3.TabIndex = 2
        Me.lblRC_AUX3.Text = "AUX3"
        '
        'lblRC_AUX2
        '
        Me.lblRC_AUX2.AutoSize = True
        Me.lblRC_AUX2.Location = New System.Drawing.Point(7, 103)
        Me.lblRC_AUX2.Name = "lblRC_AUX2"
        Me.lblRC_AUX2.Size = New System.Drawing.Size(35, 13)
        Me.lblRC_AUX2.TabIndex = 18
        Me.lblRC_AUX2.Text = "AUX2"
        '
        'lblRC_AUX1
        '
        Me.lblRC_AUX1.AutoSize = True
        Me.lblRC_AUX1.Location = New System.Drawing.Point(7, 84)
        Me.lblRC_AUX1.Name = "lblRC_AUX1"
        Me.lblRC_AUX1.Size = New System.Drawing.Size(35, 13)
        Me.lblRC_AUX1.TabIndex = 9
        Me.lblRC_AUX1.Text = "AUX1"
        '
        'lblRC_YAW
        '
        Me.lblRC_YAW.AutoSize = True
        Me.lblRC_YAW.Location = New System.Drawing.Point(7, 65)
        Me.lblRC_YAW.Name = "lblRC_YAW"
        Me.lblRC_YAW.Size = New System.Drawing.Size(32, 13)
        Me.lblRC_YAW.TabIndex = 3
        Me.lblRC_YAW.Text = "YAW"
        '
        'lblRC_ROLL
        '
        Me.lblRC_ROLL.AutoSize = True
        Me.lblRC_ROLL.Location = New System.Drawing.Point(7, 46)
        Me.lblRC_ROLL.Name = "lblRC_ROLL"
        Me.lblRC_ROLL.Size = New System.Drawing.Size(35, 13)
        Me.lblRC_ROLL.TabIndex = 4
        Me.lblRC_ROLL.Text = "ROLL"
        '
        'lblRC_PITCH
        '
        Me.lblRC_PITCH.AutoSize = True
        Me.lblRC_PITCH.Location = New System.Drawing.Point(7, 27)
        Me.lblRC_PITCH.Name = "lblRC_PITCH"
        Me.lblRC_PITCH.Size = New System.Drawing.Size(39, 13)
        Me.lblRC_PITCH.TabIndex = 5
        Me.lblRC_PITCH.Text = "PITCH"
        '
        'lblVRC_AUX8
        '
        Me.lblVRC_AUX8.AutoSize = True
        Me.lblVRC_AUX8.Location = New System.Drawing.Point(180, 215)
        Me.lblVRC_AUX8.Name = "lblVRC_AUX8"
        Me.lblVRC_AUX8.Size = New System.Drawing.Size(31, 13)
        Me.lblVRC_AUX8.TabIndex = 6
        Me.lblVRC_AUX8.Text = "1500"
        '
        'lblVRC_AUX7
        '
        Me.lblVRC_AUX7.AutoSize = True
        Me.lblVRC_AUX7.Location = New System.Drawing.Point(180, 196)
        Me.lblVRC_AUX7.Name = "lblVRC_AUX7"
        Me.lblVRC_AUX7.Size = New System.Drawing.Size(31, 13)
        Me.lblVRC_AUX7.TabIndex = 7
        Me.lblVRC_AUX7.Text = "1500"
        '
        'lblVRC_AUX6
        '
        Me.lblVRC_AUX6.AutoSize = True
        Me.lblVRC_AUX6.Location = New System.Drawing.Point(180, 177)
        Me.lblVRC_AUX6.Name = "lblVRC_AUX6"
        Me.lblVRC_AUX6.Size = New System.Drawing.Size(31, 13)
        Me.lblVRC_AUX6.TabIndex = 8
        Me.lblVRC_AUX6.Text = "1500"
        '
        'lblVRC_AUX5
        '
        Me.lblVRC_AUX5.AutoSize = True
        Me.lblVRC_AUX5.Location = New System.Drawing.Point(180, 158)
        Me.lblVRC_AUX5.Name = "lblVRC_AUX5"
        Me.lblVRC_AUX5.Size = New System.Drawing.Size(31, 13)
        Me.lblVRC_AUX5.TabIndex = 10
        Me.lblVRC_AUX5.Text = "1500"
        '
        'lblVRC_AUX4
        '
        Me.lblVRC_AUX4.AutoSize = True
        Me.lblVRC_AUX4.Location = New System.Drawing.Point(180, 139)
        Me.lblVRC_AUX4.Name = "lblVRC_AUX4"
        Me.lblVRC_AUX4.Size = New System.Drawing.Size(31, 13)
        Me.lblVRC_AUX4.TabIndex = 17
        Me.lblVRC_AUX4.Text = "1500"
        '
        'lblVRC_AUX3
        '
        Me.lblVRC_AUX3.AutoSize = True
        Me.lblVRC_AUX3.Location = New System.Drawing.Point(180, 120)
        Me.lblVRC_AUX3.Name = "lblVRC_AUX3"
        Me.lblVRC_AUX3.Size = New System.Drawing.Size(31, 13)
        Me.lblVRC_AUX3.TabIndex = 11
        Me.lblVRC_AUX3.Text = "1500"
        '
        'lblVRC_AUX2
        '
        Me.lblVRC_AUX2.AutoSize = True
        Me.lblVRC_AUX2.Location = New System.Drawing.Point(180, 101)
        Me.lblVRC_AUX2.Name = "lblVRC_AUX2"
        Me.lblVRC_AUX2.Size = New System.Drawing.Size(31, 13)
        Me.lblVRC_AUX2.TabIndex = 12
        Me.lblVRC_AUX2.Text = "1500"
        '
        'lblVRC_AUX1
        '
        Me.lblVRC_AUX1.AutoSize = True
        Me.lblVRC_AUX1.Location = New System.Drawing.Point(180, 82)
        Me.lblVRC_AUX1.Name = "lblVRC_AUX1"
        Me.lblVRC_AUX1.Size = New System.Drawing.Size(31, 13)
        Me.lblVRC_AUX1.TabIndex = 13
        Me.lblVRC_AUX1.Text = "1500"
        '
        'lblVRC_YAW
        '
        Me.lblVRC_YAW.AutoSize = True
        Me.lblVRC_YAW.Location = New System.Drawing.Point(180, 63)
        Me.lblVRC_YAW.Name = "lblVRC_YAW"
        Me.lblVRC_YAW.Size = New System.Drawing.Size(31, 13)
        Me.lblVRC_YAW.TabIndex = 14
        Me.lblVRC_YAW.Text = "1500"
        '
        'lblVRC_ROLL
        '
        Me.lblVRC_ROLL.AutoSize = True
        Me.lblVRC_ROLL.Location = New System.Drawing.Point(180, 44)
        Me.lblVRC_ROLL.Name = "lblVRC_ROLL"
        Me.lblVRC_ROLL.Size = New System.Drawing.Size(31, 13)
        Me.lblVRC_ROLL.TabIndex = 15
        Me.lblVRC_ROLL.Text = "1500"
        '
        'lblVRC_PITCH
        '
        Me.lblVRC_PITCH.AutoSize = True
        Me.lblVRC_PITCH.Location = New System.Drawing.Point(180, 25)
        Me.lblVRC_PITCH.Name = "lblVRC_PITCH"
        Me.lblVRC_PITCH.Size = New System.Drawing.Size(31, 13)
        Me.lblVRC_PITCH.TabIndex = 16
        Me.lblVRC_PITCH.Text = "1500"
        '
        'lblVRC_THR
        '
        Me.lblVRC_THR.AutoSize = True
        Me.lblVRC_THR.Location = New System.Drawing.Point(180, 6)
        Me.lblVRC_THR.Name = "lblVRC_THR"
        Me.lblVRC_THR.Size = New System.Drawing.Size(31, 13)
        Me.lblVRC_THR.TabIndex = 25
        Me.lblVRC_THR.Text = "1500"
        '
        'lblRC_THR
        '
        Me.lblRC_THR.AutoSize = True
        Me.lblRC_THR.Location = New System.Drawing.Point(7, 8)
        Me.lblRC_THR.Name = "lblRC_THR"
        Me.lblRC_THR.Size = New System.Drawing.Size(30, 13)
        Me.lblRC_THR.TabIndex = 19
        Me.lblRC_THR.Text = "THR"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 561)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.tabMain)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(970, 600)
        Me.Name = "frmMain"
        Me.Text = "Baseflight GUI"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.tabMain.ResumeLayout(False)
        Me.tpParameter.ResumeLayout(False)
        Me.tpParameter.PerformLayout()
        CType(Me.numAltitude_P, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAltitude_I, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAltitude_D, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLevel_P, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLevel_I, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLevel_D, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMag_P, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numNavigationRate_D, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numNavigationRate_I, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numNavigationRate_P, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPitch_P, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPitch_I, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPitch_D, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPosHold_P, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPosHold_I, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPosHoldRate_P, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPosHoldRate_I, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPosHoldRate_D, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPowerMeterAlarm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numRCExpo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numRCRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numRoll_D, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numRoll_I, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numRoll_P, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTEXPO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTMID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numVelocity_D, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numVelocity_I, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numVelocity_P, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numYaw_D, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numYaw_I, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numYaw_P, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trbRCRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trbTEXPO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trbTMID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trbRCExpo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox12.ResumeLayout(False)
        Me.groupBox12.PerformLayout()
        CType(Me.numRATE_tpid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numRATE_yaw, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numRATE_rp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpRCSetting.ResumeLayout(False)
        Me.pnMain.ResumeLayout(False)
        Me.pnAUXChannels.ResumeLayout(False)
        Me.pnAUXChannels.PerformLayout()
        Me.spMain.Panel1.ResumeLayout(False)
        Me.spMain.Panel2.ResumeLayout(False)
        CType(Me.spMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spMain.ResumeLayout(False)
        Me.pnAUX.ResumeLayout(False)
        Me.tpRealtime.ResumeLayout(False)
        Me.tpRealtime.PerformLayout()
        Me.pnSensors.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        Me.pnRealtimeChannels.ResumeLayout(False)
        Me.pnRealtimeChannels.PerformLayout()
        Me.tpMap.ResumeLayout(False)
        Me.tpMap.PerformLayout()
        Me.gbMapWayPoints.ResumeLayout(False)
        Me.gbMapWayPoints.PerformLayout()
        CType(Me.picWPHeading, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numWPHeading, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numWPParameter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numWPNavFlagAction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numWPTimeToStay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numWPAlt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgWayPoints, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tb_mapzoom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpMapGPSLive.ResumeLayout(False)
        Me.gpMapGPSLive.PerformLayout()
        CType(Me.picGPS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpCLI.ResumeLayout(False)
        Me.gbTerminal.ResumeLayout(False)
        Me.gbTerminal.PerformLayout()
        Me.tpGFWUpdate.ResumeLayout(False)
        Me.tpGFWUpdate.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblPort As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmbCOMPort As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents lblSpeed As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmbCOMSpeed As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents cmdConnect As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdReadSettings As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdWriteSettings As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdSaveSettings As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdLoadSettings As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tpParameter As System.Windows.Forms.TabPage
    Friend WithEvents tpRCSetting As System.Windows.Forms.TabPage
    Friend WithEvents tpRealtime As System.Windows.Forms.TabPage
    Friend WithEvents tpGFWUpdate As System.Windows.Forms.TabPage
    Friend WithEvents tpCLI As System.Windows.Forms.TabPage
    Friend WithEvents lblVelocity_D As System.Windows.Forms.Label
    Friend WithEvents lblLevel_D As System.Windows.Forms.Label
    Friend WithEvents lblNavigationRate_D As System.Windows.Forms.Label
    Friend WithEvents lblPosHoldRate_D As System.Windows.Forms.Label
    Friend WithEvents lblAltitude_D As System.Windows.Forms.Label
    Friend WithEvents lblYaw_D As System.Windows.Forms.Label
    Friend WithEvents lblPitch_D As System.Windows.Forms.Label
    Friend WithEvents lblRoll_D As System.Windows.Forms.Label
    Friend WithEvents lblVelocity_I As System.Windows.Forms.Label
    Friend WithEvents lblLevel_I As System.Windows.Forms.Label
    Friend WithEvents lblNavigationRate_I As System.Windows.Forms.Label
    Friend WithEvents lblPosHoldRate_I As System.Windows.Forms.Label
    Friend WithEvents lblPosHold_I As System.Windows.Forms.Label
    Friend WithEvents lblAltitude_I As System.Windows.Forms.Label
    Friend WithEvents lblYaw_I As System.Windows.Forms.Label
    Friend WithEvents lblPitch_I As System.Windows.Forms.Label
    Friend WithEvents lblRoll_I As System.Windows.Forms.Label
    Friend WithEvents lblVelocity_P As System.Windows.Forms.Label
    Friend WithEvents lblMag_P As System.Windows.Forms.Label
    Friend WithEvents lblLevel_P As System.Windows.Forms.Label
    Friend WithEvents lblNavigationRate_P As System.Windows.Forms.Label
    Friend WithEvents lblPosHoldRate_P As System.Windows.Forms.Label
    Friend WithEvents lblVelocity As System.Windows.Forms.Label
    Friend WithEvents lblMag As System.Windows.Forms.Label
    Friend WithEvents lblLevel As System.Windows.Forms.Label
    Friend WithEvents lblNavigationRate As System.Windows.Forms.Label
    Friend WithEvents lblPosHoldRate As System.Windows.Forms.Label
    Friend WithEvents lblPosHold_P As System.Windows.Forms.Label
    Friend WithEvents lblPosHold As System.Windows.Forms.Label
    Friend WithEvents lblAltitude_P As System.Windows.Forms.Label
    Friend WithEvents lblYaw_P As System.Windows.Forms.Label
    Friend WithEvents numVelocity_D As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblAltitude As System.Windows.Forms.Label
    Friend WithEvents lblYaw As System.Windows.Forms.Label
    Friend WithEvents numLevel_D As System.Windows.Forms.NumericUpDown
    Friend WithEvents numNavigationRate_D As System.Windows.Forms.NumericUpDown
    Friend WithEvents numPosHoldRate_D As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPitch_P As System.Windows.Forms.Label
    Friend WithEvents lblPitch As System.Windows.Forms.Label
    Friend WithEvents numAltitude_D As System.Windows.Forms.NumericUpDown
    Friend WithEvents numVelocity_I As System.Windows.Forms.NumericUpDown
    Friend WithEvents numYaw_D As System.Windows.Forms.NumericUpDown
    Friend WithEvents numLevel_I As System.Windows.Forms.NumericUpDown
    Friend WithEvents numNavigationRate_I As System.Windows.Forms.NumericUpDown
    Friend WithEvents numPosHoldRate_I As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblRoll_P As System.Windows.Forms.Label
    Friend WithEvents numPosHold_I As System.Windows.Forms.NumericUpDown
    Friend WithEvents numPitch_D As System.Windows.Forms.NumericUpDown
    Friend WithEvents numAltitude_I As System.Windows.Forms.NumericUpDown
    Friend WithEvents numVelocity_P As System.Windows.Forms.NumericUpDown
    Friend WithEvents numYaw_I As System.Windows.Forms.NumericUpDown
    Friend WithEvents numMag_P As System.Windows.Forms.NumericUpDown
    Friend WithEvents numLevel_P As System.Windows.Forms.NumericUpDown
    Friend WithEvents numNavigationRate_P As System.Windows.Forms.NumericUpDown
    Friend WithEvents numPosHoldRate_P As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblRoll As System.Windows.Forms.Label
    Friend WithEvents numPosHold_P As System.Windows.Forms.NumericUpDown
    Friend WithEvents numAltitude_P As System.Windows.Forms.NumericUpDown
    Friend WithEvents numPitch_I As System.Windows.Forms.NumericUpDown
    Friend WithEvents numYaw_P As System.Windows.Forms.NumericUpDown
    Friend WithEvents numRoll_D As System.Windows.Forms.NumericUpDown
    Friend WithEvents numPitch_P As System.Windows.Forms.NumericUpDown
    Friend WithEvents numRoll_I As System.Windows.Forms.NumericUpDown
    Friend WithEvents numRoll_P As System.Windows.Forms.NumericUpDown
    Friend WithEvents groupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents lblThrottlePIDAttenuation As System.Windows.Forms.Label
    Friend WithEvents lblYawRATE As System.Windows.Forms.Label
    Friend WithEvents lblRollPitchRATE As System.Windows.Forms.Label
    Friend WithEvents numRATE_tpid As System.Windows.Forms.NumericUpDown
    Friend WithEvents numRATE_yaw As System.Windows.Forms.NumericUpDown
    Friend WithEvents numRATE_rp As System.Windows.Forms.NumericUpDown
    Friend WithEvents trbRCRate As System.Windows.Forms.TrackBar
    Friend WithEvents trbRCExpo As System.Windows.Forms.TrackBar
    Friend WithEvents lblRCRate As System.Windows.Forms.Label
    Friend WithEvents lblRCExpo As System.Windows.Forms.Label
    Friend WithEvents numRCRate As System.Windows.Forms.NumericUpDown
    Friend WithEvents numRCExpo As System.Windows.Forms.NumericUpDown
    Friend WithEvents trbTEXPO As System.Windows.Forms.TrackBar
    Friend WithEvents trbTMID As System.Windows.Forms.TrackBar
    Friend WithEvents lblTEXPO As System.Windows.Forms.Label
    Friend WithEvents lblTMID As System.Windows.Forms.Label
    Friend WithEvents numTEXPO As System.Windows.Forms.NumericUpDown
    Friend WithEvents numTMID As System.Windows.Forms.NumericUpDown
    Friend WithEvents Artifical_horizon1 As BaseflightGUI.BaseflightGUIControls.artifical_horizon
    Friend WithEvents Heading_indicator1 As BaseflightGUI.BaseflightGUIControls.heading_indicator
    Friend WithEvents GpsIndicatorInstrumentControl1 As BaseflightGUI.BaseflightGUIControls.GpsIndicatorInstrumentControl
    Friend WithEvents zgMonitor As ZedGraph.ZedGraphControl
    Friend WithEvents cmdRefreshCOM As System.Windows.Forms.ToolStripButton
    Friend WithEvents timerRealtime As System.Windows.Forms.Timer
    Friend WithEvents cmdCalibrateAcc As System.Windows.Forms.Button
    Friend WithEvents lblRefreshRate As System.Windows.Forms.Label
    Friend WithEvents cmdPause As System.Windows.Forms.Button
    Friend WithEvents cmdCalibrateMag As System.Windows.Forms.Button
    Friend WithEvents cmdResetSettings As System.Windows.Forms.ToolStripButton
    Friend WithEvents Throttle_expo_control1 As BaseflightGUI.BaseflightGUIControls.throttle_expo_control
    Friend WithEvents ctrlHEADING As BaseflightGUI.BaseflightGUIControls.heading_indicator
    Friend WithEvents ctrlGPS As BaseflightGUI.BaseflightGUIControls.GpsIndicatorInstrumentControl
    Friend WithEvents ctrlHORIZON As BaseflightGUI.BaseflightGUIControls.artifical_horizon
    Friend WithEvents Rc_expo_control1 As BaseflightGUI.BaseflightGUIControls.rc_expo_control
    Friend WithEvents cmbRefreshRate As System.Windows.Forms.ComboBox
    Friend WithEvents pnMain As System.Windows.Forms.Panel
    Friend WithEvents spMain As System.Windows.Forms.SplitContainer
    Friend WithEvents pnAUX As System.Windows.Forms.Panel
    Friend WithEvents pnAUXChannels As System.Windows.Forms.Panel
    Friend WithEvents pnRealtimeChannels As System.Windows.Forms.Panel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblPowerMeter As System.Windows.Forms.Label
    Friend WithEvents lblComment As System.Windows.Forms.Label
    Friend WithEvents lblMax40Chars As System.Windows.Forms.Label
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents numPowerMeterAlarm As System.Windows.Forms.NumericUpDown
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdUncheck_all_ACC As System.Windows.Forms.Button
    Friend WithEvents cmdCheck_all_ACC As System.Windows.Forms.Button
    Friend WithEvents lblVacc_z As System.Windows.Forms.Label
    Friend WithEvents lblVacc_pitch As System.Windows.Forms.Label
    Friend WithEvents lblVacc_roll As System.Windows.Forms.Label
    Friend WithEvents lblACC_Z As System.Windows.Forms.Label
    Friend WithEvents chk_acc_z As System.Windows.Forms.CheckBox
    Friend WithEvents lblACC_PITCH As System.Windows.Forms.Label
    Friend WithEvents chk_acc_pitch As System.Windows.Forms.CheckBox
    Friend WithEvents lblACC_ROLL As System.Windows.Forms.Label
    Friend WithEvents chk_acc_roll As System.Windows.Forms.CheckBox
    Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdUncheck_all_GYRO As System.Windows.Forms.Button
    Friend WithEvents cmdCheck_all_GYRO As System.Windows.Forms.Button
    Friend WithEvents lblVgyro_yaw As System.Windows.Forms.Label
    Friend WithEvents lblVgyro_pitch As System.Windows.Forms.Label
    Friend WithEvents lblVgyro_roll As System.Windows.Forms.Label
    Friend WithEvents lblGgyroYaw As System.Windows.Forms.Label
    Friend WithEvents chk_gyro_yaw As System.Windows.Forms.CheckBox
    Friend WithEvents lblGgyroPitch As System.Windows.Forms.Label
    Friend WithEvents chk_gyro_pitch As System.Windows.Forms.CheckBox
    Friend WithEvents lblGgyroRoll As System.Windows.Forms.Label
    Friend WithEvents chk_gyro_roll As System.Windows.Forms.CheckBox
    Friend WithEvents chk_alt As System.Windows.Forms.CheckBox
    Friend WithEvents lblALT As System.Windows.Forms.Label
    Friend WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdUncheck_all_MAG As System.Windows.Forms.Button
    Friend WithEvents cmdCheck_all_MAG As System.Windows.Forms.Button
    Friend WithEvents lblVmag_yaw As System.Windows.Forms.Label
    Friend WithEvents lblVmag_pitch As System.Windows.Forms.Label
    Friend WithEvents lblVmag_roll As System.Windows.Forms.Label
    Friend WithEvents lblMAG_YAW As System.Windows.Forms.Label
    Friend WithEvents chk_mag_yaw As System.Windows.Forms.CheckBox
    Friend WithEvents lblMAG_Pitch As System.Windows.Forms.Label
    Friend WithEvents chk_mag_pitch As System.Windows.Forms.CheckBox
    Friend WithEvents lblMAG_roll As System.Windows.Forms.Label
    Friend WithEvents chk_mag_roll As System.Windows.Forms.CheckBox
    Friend WithEvents chk_head As System.Windows.Forms.CheckBox
    Friend WithEvents lblHEAD As System.Windows.Forms.Label
    Friend WithEvents lblValt As System.Windows.Forms.Label
    Friend WithEvents lblVhead As System.Windows.Forms.Label
    Friend WithEvents lblPacketReceived As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblVPacketReceived As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblVPacketError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblDBG1 As System.Windows.Forms.Label
    Friend WithEvents chk_dbg1 As System.Windows.Forms.CheckBox
    Friend WithEvents lblVdbg1 As System.Windows.Forms.Label
    Friend WithEvents chk_dbg2 As System.Windows.Forms.CheckBox
    Friend WithEvents lblDBG2 As System.Windows.Forms.Label
    Friend WithEvents lblVdbg2 As System.Windows.Forms.Label
    Friend WithEvents chk_dbg3 As System.Windows.Forms.CheckBox
    Friend WithEvents lblVdbg4 As System.Windows.Forms.Label
    Friend WithEvents lblDBG3 As System.Windows.Forms.Label
    Friend WithEvents lblDBG4 As System.Windows.Forms.Label
    Friend WithEvents lblVdbg3 As System.Windows.Forms.Label
    Friend WithEvents chk_dbg4 As System.Windows.Forms.CheckBox
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents l_vbatt As System.Windows.Forms.Label
    Friend WithEvents lblSonar As System.Windows.Forms.Label
    Friend WithEvents lblTemp As System.Windows.Forms.Label
    Friend WithEvents l_Sonar As System.Windows.Forms.Label
    Friend WithEvents label7 As System.Windows.Forms.Label
    Friend WithEvents l_Temp As System.Windows.Forms.Label
    Friend WithEvents l_powersum As System.Windows.Forms.Label
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblV_i2cerrors As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblV_cycletime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents gbTerminal As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCLILoad As System.Windows.Forms.Button
    Friend WithEvents lblCLIHelp As System.Windows.Forms.Label
    Friend WithEvents cmdCLIDefaults As System.Windows.Forms.Button
    Friend WithEvents cmdCLIMap As System.Windows.Forms.Button
    Friend WithEvents cmdCLIVersion As System.Windows.Forms.Button
    Friend WithEvents cmdCLIStatus As System.Windows.Forms.Button
    Friend WithEvents cmdCLISave As System.Windows.Forms.Button
    Friend WithEvents cmdCLIFeature As System.Windows.Forms.Button
    Friend WithEvents cmdCLISet As System.Windows.Forms.Button
    Friend WithEvents cmdCLIHelp As System.Windows.Forms.Button
    Friend WithEvents cmdCLISend As System.Windows.Forms.Button
    Friend WithEvents txtCLICommand As System.Windows.Forms.TextBox
    Friend WithEvents txtCLIResult As System.Windows.Forms.TextBox
    Private components As System.ComponentModel.IContainer
    Friend WithEvents Motor As BaseflightGUI.BaseflightGUIControls.BaseglightMotors
    Friend WithEvents cmdCLIList As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblSep1 As System.Windows.Forms.Label
    Friend WithEvents cmdCLIClearScreen As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdFWUpdate As System.Windows.Forms.Button
    Friend WithEvents txtFirmwareFile As System.Windows.Forms.TextBox
    Friend WithEvents lblFirmwareFile As System.Windows.Forms.Label
    Friend WithEvents searchFirmwareFile As System.Windows.Forms.Button
    Friend WithEvents LoadingCircle As BaseflightGUI.MRG.Controls.UI.LoadingCircle
    Friend WithEvents lblFWError As System.Windows.Forms.Label
    Friend WithEvents lblFWSuccessful As System.Windows.Forms.Label
    Friend WithEvents chkFWSendR As System.Windows.Forms.CheckBox
    Friend WithEvents lblFWSendR As System.Windows.Forms.Label
    Friend WithEvents chkFWShowOutput As System.Windows.Forms.CheckBox
    Friend WithEvents lblFWShowOutput As System.Windows.Forms.Label
    Friend WithEvents lblSpring As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblUID As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblVUID As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tpMap As System.Windows.Forms.TabPage
    Friend WithEvents tb_mapzoom As System.Windows.Forms.TrackBar
    Friend WithEvents cmdClearRoute As System.Windows.Forms.Button
    Friend WithEvents lblMapProvider As System.Windows.Forms.Label
    Friend WithEvents cmbMapProviders As System.Windows.Forms.ComboBox
    Friend WithEvents lblGPS_lat As System.Windows.Forms.Label
    Friend WithEvents lblV_GPS_numsat As System.Windows.Forms.Label
    Friend WithEvents lblGPS_lon As System.Windows.Forms.Label
    Friend WithEvents lbl_GPS_numsat As System.Windows.Forms.Label
    Friend WithEvents lblV_GPS_lon As System.Windows.Forms.Label
    Friend WithEvents lblV_GPS_alt As System.Windows.Forms.Label
    Friend WithEvents lbl_GPS_alt As System.Windows.Forms.Label
    Friend WithEvents lblV_GPS_lat As System.Windows.Forms.Label
    Friend WithEvents lblVMousePos As System.Windows.Forms.Label
    Friend WithEvents MainMap As GMap.NET.WindowsForms.GMapControl
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdStart_KML_log As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnIndicator As System.Windows.Forms.Panel
    Friend WithEvents lcAux As BaseflightGUI.MRG.Controls.UI.LoadingCircle
    Friend WithEvents pnSensors As System.Windows.Forms.Panel
    Friend WithEvents lblSensorOPTIC As System.Windows.Forms.Label
    Friend WithEvents lblSensorSONAR As System.Windows.Forms.Label
    Friend WithEvents lblSensorGPS As System.Windows.Forms.Label
    Friend WithEvents lblSensorMAG As System.Windows.Forms.Label
    Friend WithEvents lblSensorBARO As System.Windows.Forms.Label
    Friend WithEvents lblSensorACC As System.Windows.Forms.Label
    Friend WithEvents dgWayPoints As System.Windows.Forms.DataGridView
    Friend WithEvents picGPS As System.Windows.Forms.PictureBox
    Friend WithEvents gpMapGPSLive As System.Windows.Forms.GroupBox
    Friend WithEvents gbMapWayPoints As System.Windows.Forms.GroupBox
    Friend WithEvents lblWPLng As System.Windows.Forms.Label
    Friend WithEvents lblWPLat As System.Windows.Forms.Label
    Friend WithEvents lblTimeToStay As System.Windows.Forms.Label
    Friend WithEvents lblWPAlt As System.Windows.Forms.Label
    Friend WithEvents numWPParameter As System.Windows.Forms.NumericUpDown
    Friend WithEvents numWPNavFlagAction As System.Windows.Forms.NumericUpDown
    Friend WithEvents numWPTimeToStay As System.Windows.Forms.NumericUpDown
    Friend WithEvents numWPAlt As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtWPLng As System.Windows.Forms.TextBox
    Friend WithEvents txtWPLat As System.Windows.Forms.TextBox
    Friend WithEvents lblWPParameter As System.Windows.Forms.Label
    Friend WithEvents lblWPNavFlagAction As System.Windows.Forms.Label
    Friend WithEvents picWPHeading As System.Windows.Forms.PictureBox
    Friend WithEvents numWPHeading As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblWPHeading As System.Windows.Forms.Label
    Friend WithEvents cmdWPUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdWPClear As System.Windows.Forms.Button
    Friend WithEvents chkSetToLiveData As System.Windows.Forms.CheckBox
    Friend WithEvents lblSetMapToLiveData As System.Windows.Forms.Label
    Friend WithEvents colWPNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colWPLat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colWPLng As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colWPAlt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colWPHeading As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colWPTimeToStay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblFirmware As System.Windows.Forms.Label
    Friend WithEvents lblVFirmware As System.Windows.Forms.Label
    Friend WithEvents txtWPComment As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdCLIDump As System.Windows.Forms.Button
    Friend WithEvents pnBoxNames As System.Windows.Forms.Panel
    Friend WithEvents lblRT_ROLL As System.Windows.Forms.Label
    Friend WithEvents lblRT_PITCH As System.Windows.Forms.Label
    Friend WithEvents lblRT_THR As System.Windows.Forms.Label
    Friend WithEvents lblRT_AUX1 As System.Windows.Forms.Label
    Friend WithEvents lblRT_YAW As System.Windows.Forms.Label
    Friend WithEvents lblRT_AUX8 As System.Windows.Forms.Label
    Friend WithEvents lblRT_AUX7 As System.Windows.Forms.Label
    Friend WithEvents lblRT_AUX6 As System.Windows.Forms.Label
    Friend WithEvents lblRT_AUX5 As System.Windows.Forms.Label
    Friend WithEvents lblRT_AUX4 As System.Windows.Forms.Label
    Friend WithEvents lblRT_AUX3 As System.Windows.Forms.Label
    Friend WithEvents lblRT_AUX2 As System.Windows.Forms.Label
    Friend WithEvents pgbRT_THR As CustomControls.ProgressBarCtrl
    Friend WithEvents lblVRT_THR As System.Windows.Forms.Label
    Friend WithEvents pgbRT_AUX8 As CustomControls.ProgressBarCtrl
    Friend WithEvents pgbRT_AUX7 As CustomControls.ProgressBarCtrl
    Friend WithEvents pgbRT_AUX6 As CustomControls.ProgressBarCtrl
    Friend WithEvents pgbRT_AUX5 As CustomControls.ProgressBarCtrl
    Friend WithEvents pgbRT_AUX4 As CustomControls.ProgressBarCtrl
    Friend WithEvents pgbRT_AUX3 As CustomControls.ProgressBarCtrl
    Friend WithEvents pgbRT_AUX2 As CustomControls.ProgressBarCtrl
    Friend WithEvents pgbRT_AUX1 As CustomControls.ProgressBarCtrl
    Friend WithEvents pgbRT_YAW As CustomControls.ProgressBarCtrl
    Friend WithEvents pgbRT_ROLL As CustomControls.ProgressBarCtrl
    Friend WithEvents pgbRT_PITCH As CustomControls.ProgressBarCtrl
    Friend WithEvents lblVRT_AUX8 As System.Windows.Forms.Label
    Friend WithEvents lblVRT_AUX7 As System.Windows.Forms.Label
    Friend WithEvents lblVRT_AUX6 As System.Windows.Forms.Label
    Friend WithEvents lblVRT_AUX5 As System.Windows.Forms.Label
    Friend WithEvents lblVRT_AUX4 As System.Windows.Forms.Label
    Friend WithEvents lblVRT_AUX3 As System.Windows.Forms.Label
    Friend WithEvents lblVRT_AUX2 As System.Windows.Forms.Label
    Friend WithEvents lblVRT_AUX1 As System.Windows.Forms.Label
    Friend WithEvents lblVRT_YAW As System.Windows.Forms.Label
    Friend WithEvents lblVRT_ROLL As System.Windows.Forms.Label
    Friend WithEvents lblVRT_PITCH As System.Windows.Forms.Label
    Friend WithEvents pgbRC_AUX8 As CustomControls.ProgressBarCtrl
    Friend WithEvents pgbRC_AUX7 As CustomControls.ProgressBarCtrl
    Friend WithEvents pgbRC_AUX6 As CustomControls.ProgressBarCtrl
    Friend WithEvents pgbRC_AUX5 As CustomControls.ProgressBarCtrl
    Friend WithEvents pgbRC_AUX4 As CustomControls.ProgressBarCtrl
    Friend WithEvents pgbRC_AUX3 As CustomControls.ProgressBarCtrl
    Friend WithEvents pgbRC_AUX2 As CustomControls.ProgressBarCtrl
    Friend WithEvents pgbRC_AUX1 As CustomControls.ProgressBarCtrl
    Friend WithEvents pgbRC_YAW As CustomControls.ProgressBarCtrl
    Friend WithEvents pgbRC_ROLL As CustomControls.ProgressBarCtrl
    Friend WithEvents pgbRC_PITCH As CustomControls.ProgressBarCtrl
    Friend WithEvents pgbRC_THR As CustomControls.ProgressBarCtrl
    Friend WithEvents lblRC_AUX8 As System.Windows.Forms.Label
    Friend WithEvents lblRC_AUX7 As System.Windows.Forms.Label
    Friend WithEvents lblRC_AUX6 As System.Windows.Forms.Label
    Friend WithEvents lblRC_AUX5 As System.Windows.Forms.Label
    Friend WithEvents lblRC_AUX4 As System.Windows.Forms.Label
    Friend WithEvents lblRC_AUX3 As System.Windows.Forms.Label
    Friend WithEvents lblRC_AUX2 As System.Windows.Forms.Label
    Friend WithEvents lblRC_AUX1 As System.Windows.Forms.Label
    Friend WithEvents lblRC_YAW As System.Windows.Forms.Label
    Friend WithEvents lblRC_ROLL As System.Windows.Forms.Label
    Friend WithEvents lblRC_PITCH As System.Windows.Forms.Label
    Friend WithEvents lblVRC_AUX8 As System.Windows.Forms.Label
    Friend WithEvents lblVRC_AUX7 As System.Windows.Forms.Label
    Friend WithEvents lblVRC_AUX6 As System.Windows.Forms.Label
    Friend WithEvents lblVRC_AUX5 As System.Windows.Forms.Label
    Friend WithEvents lblVRC_AUX4 As System.Windows.Forms.Label
    Friend WithEvents lblVRC_AUX3 As System.Windows.Forms.Label
    Friend WithEvents lblVRC_AUX2 As System.Windows.Forms.Label
    Friend WithEvents lblVRC_AUX1 As System.Windows.Forms.Label
    Friend WithEvents lblVRC_YAW As System.Windows.Forms.Label
    Friend WithEvents lblVRC_ROLL As System.Windows.Forms.Label
    Friend WithEvents lblVRC_PITCH As System.Windows.Forms.Label
    Friend WithEvents lblVRC_THR As System.Windows.Forms.Label
    Friend WithEvents lblRC_THR As System.Windows.Forms.Label

End Class
