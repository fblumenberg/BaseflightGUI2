Module modMain
    Public iniFile As String = Application.StartupPath & "\settings.ini"
    Public ini As New IniReader(iniFile)
    Public iCheckBoxItems As Integer = 0    'number of checkboxItems (readed from optionsconfig.xml
    Public iPidItems As Integer = 10         'number if Pid items (const definition)
    Public iSoftwareVersion As Integer = 0
    Public sLogFolder As String = ""
    Public sConfigFolder As String = ""
    Public sFirmwareFolder As String = ""
    Public sWayPointFolder As String = ""
    Public iMapProviderSelectedIndex As Integer = 0
    Public iMapZoom As Integer = 0

    Public sBoxNames As String()
    Public sUID As String = "???"

    Public AUX_CHANNELS As Integer = 0
    Public isAUX_CHANNEL_update As Boolean = False

    Public cfgBoxWidth As Integer = 0       '4 old Baseflight version / 8 with AUX Channel enhancment
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

    Public isStartup As Boolean = True

    Public Sub readGUISettings()
        If System.IO.File.Exists(iniFile) = False Then
            writeGUISettings()
        End If
        guiDefaultPort = ini.ReadString("COM", "DefaultPort", "COM3")
        guiDefaultSerialSpeed = ini.ReadString("COM", "DefaultSerialSpeed", "115200")
        guiDefaultRate = ini.ReadString("GUI", "DefaultRate", "10 Hz")
        sLogFolder = ini.ReadString("GUI", "LogFolder", Application.StartupPath & "\Logfiles")
        sConfigFolder = ini.ReadString("GUI", "ConfigFolder", Application.StartupPath & "\Configfiles")
        sFirmwareFolder = ini.ReadString("GUI", "FirmwareFolder", Application.StartupPath & "\Firmwarefiles")
        sWayPointFolder = ini.ReadString("GUI", "WayPointFolder", Application.StartupPath & "\WayPoints")
        iMapProviderSelectedIndex = ini.ReadInteger("GUI", "MapProvider", 1)
        iMapZoom = ini.ReadInteger("GUI", "MapZoom", 19)
    End Sub

    Public Sub writeGUISettings()
        ini.Write("COM", "DefaultPort", guiDefaultPort)
        ini.Write("COM", "DefaultSerialSpeed", guiDefaultSerialSpeed)
        ini.Write("GUI", "DefaultRate", guiDefaultRate)
    End Sub

    Public Sub versionCheck()
        Try
            If System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() Then
                Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("http://www.klick-punkte.info/download/BaseflightGUI2.txt")
                Dim response As System.Net.HttpWebResponse = request.GetResponse()

                Dim reader As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())

                Dim newestversion As String = reader.ReadToEnd()
                Dim currentversion As String = Application.ProductVersion

                If newestversion <= currentversion Then

                    'Dim msg As String
                    'Dim title As String
                    'Dim style As MsgBoxStyle
                    'Dim res As MsgBoxResult
                    'msg = "You have the newest version!"
                    'style = MsgBoxStyle.OkOnly Or MsgBoxStyle.Information
                    'title = Application.ProductName + " - Updates"
                    'res = MsgBox(msg, style, title)

                    'If res = MsgBoxResult.Ok Then
                    '    'nothing
                    'End If

                Else

                    Dim msg As String
                    Dim title As String
                    Dim style As MsgBoxStyle
                    Dim res As MsgBoxResult
                    msg = "You have a old version. Do you want to download the new one?" + vbNewLine + "Current: " + currentversion + _
                          vbNewLine + "Newest: " + newestversion
                    style = MsgBoxStyle.YesNo Or MsgBoxStyle.Information
                    title = Application.ProductName + " - Updates"
                    res = MsgBox(msg, style, title)

                    If res = MsgBoxResult.Yes Then
                        Process.Start("http://www.klick-punkte.info/download/BaseflightGUI2.zip")
                    Else
                        'nothing
                    End If

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

End Module
