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

    Public cliLoadSleep As Integer = 10

    Public sBoxNames As String()
    Public iBoxIdents As Integer()
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

    Public dtOnlineHelp As New DataTable
    Public Sub readDTOnlineHelp()
        If System.IO.Directory.Exists(Application.StartupPath & "\OnlineHelp") = False Then
            System.IO.Directory.CreateDirectory(Application.StartupPath & "\OnlineHelp")
        End If
        If System.IO.File.Exists(Application.StartupPath & "\OnlineHelp\help.xml") Then
            dtOnlineHelp.Clear()
            dtOnlineHelp.ReadXml(Application.StartupPath & "\OnlineHelp\help.xml")
        Else
            If dtOnlineHelp.Columns.Count = 0 Then
                Dim col As DataColumn
                col = New DataColumn("Item", GetType(System.String))
                dtOnlineHelp.Columns.Add(col)
                col = New DataColumn("Type", GetType(System.Int32))
                dtOnlineHelp.Columns.Add(col)
                col = New DataColumn("Language", GetType(System.String))
                dtOnlineHelp.Columns.Add(col)
                col = New DataColumn("URL", GetType(System.String))
                dtOnlineHelp.Columns.Add(col)
                col = New DataColumn("Description", GetType(System.String))
                dtOnlineHelp.Columns.Add(col)
                dtOnlineHelp.TableName = "OnlineHelp"
                saveOnlineHelp()
            End If
        End If
    End Sub

    Public Sub addEmptyRow(ByVal item As String, ByVal Type As Integer, ByVal _Language As String)
        Dim newrow As DataRow = dtOnlineHelp.NewRow
        newrow("Item") = item
        newrow("Type") = Type
        newrow("Language") = _Language
        newrow("Description") = ""
        newrow("URL") = ""
        dtOnlineHelp.Rows.Add(newrow)
    End Sub

    Public Sub saveOnlineHelp()
        Try
            dtOnlineHelp.WriteXml(Application.StartupPath & "\OnlineHelp\help.xml", XmlWriteMode.WriteSchema)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub DownloadHelpXML()
        frmMain.Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Try
            ' Make a WebClient.
            Dim web_client As Net.WebClient = New Net.WebClient
            'Backup
            System.IO.File.Copy(Application.StartupPath & "\OnlineHelp\help.xml", Application.StartupPath & "\OnlineHelp\help.bak", True)
            ' Download the file.
            web_client.DownloadFile("http://www.klick-punkte.info/download/help.xml", Application.StartupPath & "\OnlineHelp\help.xml")
            readDTOnlineHelp()
            MessageBox.Show("Done")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        frmMain.Cursor = Cursors.Default
    End Sub

    Public Sub readGUISettings()
        If System.IO.File.Exists(iniFile) = False Then
            writeGUISettings()
        End If
        guiDefaultPort = ini.ReadString("COM", "DefaultPort", "COM3")
        guiDefaultSerialSpeed = ini.ReadString("COM", "DefaultSerialSpeed", "115200")
        USBTimeout = ini.ReadInteger("COM", "USBTimeout", 15)
        BluetoothTimeout = ini.ReadInteger("COM", "BluetoothTimeout", 30)
        cliEntry = ini.ReadString("CLI", "StartCLI", cliEntry)
        ExitPASSGPS = ini.ReadString("GUI", "ExitPASSGPS", ExitPASSGPS)
        StartFWUpdate = ini.ReadString("GUI", "StartFWUpdate", StartFWUpdate)
        'write back to by sure it's in the INI file
        ini.Write("CLI", "StartCLI", cliEntry)
        ini.Write("GUI", "ExitPASSGPS", ExitPASSGPS)
        ini.Write("GUI", "StartFWUpdate", StartFWUpdate)

        comTimeOut = ini.ReadString("COM", "ComTimeout", "500")
        Timeout = ini.ReadString("COM", "FCTimeout", "10")
        guiDefaultRate = ini.ReadString("GUI", "DefaultRate", "10 Hz")
        sLogFolder = ini.ReadString("GUI", "LogFolder", Application.StartupPath & "\Logfiles")
        sConfigFolder = ini.ReadString("GUI", "ConfigFolder", Application.StartupPath & "\Configfiles")
        sFirmwareFolder = ini.ReadString("GUI", "FirmwareFolder", Application.StartupPath & "\Firmwarefiles")
        sWayPointFolder = ini.ReadString("GUI", "WayPointFolder", Application.StartupPath & "\WayPoints")
        iMapProviderSelectedIndex = ini.ReadInteger("GUI", "MapProvider", 1)
        iMapZoom = ini.ReadInteger("GUI", "MapZoom", 19)
        cliLoadSleep = ini.ReadInteger("CLI", "LoadSleep", 10)
        Language = ini.ReadString("Help", "Language", "DE")
    End Sub

    Public Sub writeGUISettings()
        ini.Write("COM", "DefaultPort", guiDefaultPort)
        ini.Write("COM", "DefaultSerialSpeed", guiDefaultSerialSpeed)
        ini.Write("GUI", "DefaultRate", guiDefaultRate)
        ini.Write("CLI", "StartCLI", cliEntry)
        ini.Write("GUI", "ExitPASSGPS", ExitPASSGPS)
        ini.Write("GUI", "StartFWUpdate", StartFWUpdate)
    End Sub

    Public Sub versionCheck()
        Try
            If System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() Then
                Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("http://www.klick-punkte.info/download/BaseflightGUI2.txt")
                Dim response As System.Net.HttpWebResponse = request.GetResponse()

                Dim reader As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())

                Dim isNew As Boolean = False
                Dim newestversion As String = reader.ReadToEnd()
                Dim currentversion As String = Application.ProductVersion
                Dim newI() As String = newestversion.Split(".")
                Dim curI() As String = currentversion.Split(".")
                If CInt(newI(0)) >= CInt(curI(0)) Then
                    If CInt(newI(0)) > CInt(curI(0)) Then
                        isNew = True
                    Else
                        If CInt(newI(1)) >= CInt(curI(1)) Then
                            If CInt(newI(1)) > CInt(curI(1)) Then
                                isNew = True
                            Else
                                If CInt(newI(2)) >= CInt(curI(2)) Then
                                    If CInt(newI(2)) > CInt(curI(2)) Then
                                        isNew = True
                                    Else
                                        If CInt(newI(3)) > CInt(curI(3)) Then
                                            isNew = True
                                        End If
                                    End If
                                Else
                                'Current Version is newer
                            End If
                            End If
                        Else
                            'Current Version is newer
                        End If
                    End If
                Else
                    'Current Version is newer
                End If
                If isNew = True Then
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

    Public Function GetMotherboardSerialNumber() As String
        Dim searcher As New System.Management.ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard")

        For Each obj As System.Management.ManagementObject In searcher.Get
            Return obj.Properties("SerialNumber").Value.ToString
        Next

        Return String.Empty
    End Function

    Public Function myMessageBox()
        Dim result As DialogResult = DialogResult.Cancel
        result = frmMessageBox.ShowDialog
        Return result
    End Function

    Public Sub sleep(ByVal value As Integer)
        System.Threading.Thread.Sleep(value)
    End Sub

End Module
