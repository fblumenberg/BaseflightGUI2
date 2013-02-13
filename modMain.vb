Module modMain
    Public iniFile As String = Application.StartupPath & "\settings.ini"
    Public ini As New IniReader(iniFile)
    Public iCheckBoxItems As Integer = 0    'number of checkboxItems (readed from optionsconfig.xml
    Public iPidItems As Integer = 10         'number if Pid items (const definition)
    Public iSoftwareVersion As Integer = 0

    Public cfgBoxWidth As Integer = 0       '4 old Baseflight version / 8 with AUX Channel enhancment
    Public AUX_CHANNELS As Integer = 0
    Public boxAUX_CHANNELS As Integer = 0

    Public mw_params As mw_settings

    Public mw_gui As baseflight_data_gui

    Public Const PIDRoll As Integer = 0
    Public Const PIDPitch As Integer = 1
    Public Const PIDYaw As Integer = 2
    Public Const PIDAltitude As Integer = 3
    Public Const PIDPosHold As Integer = 4
    Public Const PIDPosHoldRate As Integer = 5
    Public Const PIDNavigationRate As Integer = 6
    Public Const PIDLevel As Integer = 7
    Public Const PIDMag As Integer = 8
    Public Const PIDVelocity As Integer = 9

    Public Sub readGUISettings()
        If System.IO.File.Exists(iniFile) = False Then
            writeGUISettings()
        End If
        guiDefaultPort = ini.ReadString("COM", "DefaultPort", "COM3")
        guiDefaultSerialSpeed = ini.ReadString("COM", "DefaultSerialSpeed", "115200")
        guiDefaultRate = ini.ReadString("GUI", "guiDefaultRate", "10 Hz")
    End Sub

    Public Sub writeGUISettings()
        ini.Write("COM", "DefaultPort", guiDefaultPort)
        ini.Write("COM", "DefaultSerialSpeed", guiDefaultSerialSpeed)
        ini.Write("GUI", "DefaultRate", guiDefaultRate)
    End Sub

End Module
