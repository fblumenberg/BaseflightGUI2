Public Class mw_settings

    'public fields

    Public pidP As Byte()
    'P values
    Public pidI As Byte()
    'I values
    Public pidD As Byte()
    'D values
    Public rcRate As Byte
    Public rcExpo As Byte
    Public RollPitchRate As Byte
    Public YawRate As Byte
    Public DynThrPID As Byte
    Public ThrottleMID As Byte
    Public ThrottleEXPO As Byte

    Public activation As UInteger()

    Public PowerTrigger As Integer

    'For GUI only
    Public comment As String


    Public pidnames As String()
    Private iPIDItems As Integer, iCheckBoxItems As Integer
    Private iSwVer As Integer

    'Commands
    Const MSP_IDENT As Integer = 100

    Const MSP_STATUS As Integer = 101
    Const MSP_RAW_IMU As Integer = 102
    Const MSP_SERVO As Integer = 103
    Const MSP_MOTOR As Integer = 104
    Const MSP_RC As Integer = 105
    Const MSP_RAW_GPS As Integer = 106
    Const MSP_COMP_GPS As Integer = 107
    Const MSP_ATTITUDE As Integer = 108
    Const MSP_ALTITUDE As Integer = 109
    Const MSP_BAT As Integer = 110
    Const MSP_RC_TUNING As Integer = 111
    Const MSP_PID As Integer = 112
    Const MSP_BOX As Integer = 113
    Const MSP_MISC As Integer = 114
    Const MSP_MOTOR_PINS As Integer = 115
    'out message         which pins are in use for motors & servos, for GUI
    Const MSP_BOXNAMES As Integer = 116
    'out message         the aux switch names
    Const MSP_PIDNAMES As Integer = 117
    'out message         the PID names
    Const MSP_WP As Integer = 118
    'out message         get a WP, WP# is in the payload, returns (WP#, lat, lon, alt, flags) WP#0-home, WP#16-poshold
    Const MSP_TEMP As Integer = 119
    'out message         Temperature
    Const MSP_SET_RAW_RC As Integer = 200
    Const MSP_SET_RAW_GPS As Integer = 201
    Const MSP_SET_PID As Integer = 202
    Const MSP_SET_BOX As Integer = 203
    Const MSP_SET_RC_TUNING As Integer = 204
    Const MSP_ACC_CALIBRATION As Integer = 205
    Const MSP_MAG_CALIBRATION As Integer = 206
    Const MSP_SET_MISC As Integer = 207
    Const MSP_RESET_CONF As Integer = 208

    Const MSP_EEPROM_WRITE As Integer = 250
    Const MSP_DEBUG As Integer = 254

    'Public cfgBoxWidth As Integer = 2

    'Constructor
    Public Sub New(pidItems As Integer, checkboxItems As Integer, iSoftwareVersion As Integer)

        pidP = New Byte(pidItems - 1) {}
        pidI = New Byte(pidItems - 1) {}
        pidD = New Byte(pidItems - 1) {}
        activation = New UInteger(checkboxItems - 1) {}

        iPIDItems = pidItems
        iCheckBoxItems = checkboxItems
        iSwVer = iSoftwareVersion


        pidnames = New String(pidItems - 1) {}
    End Sub

    Public Sub write_settings(serialport As IO.Ports.SerialPort)

        Dim buffer As Byte() = New Byte(249) {}
        'this must be long enough
        Dim bptr As Integer = 0
        'buffer pointer
        Dim bInt16 As Byte() = New Byte(1) {}
        'two byte buffer for converting int to two separated bytes
        Dim checksum As Byte = 0

        'Write out settings
        If serialport.IsOpen Then

            'bptr = 0;
            'checksum = 0;
            'buffer[bptr++] = (byte)'$';
            'buffer[bptr++] = (byte)'M';
            'Write RC_TUNING
            checksum = 0
            bptr = 0
            buffer(bptr) = CByte(AscW("$"c))
            bptr += 1
            buffer(bptr) = CByte(AscW("M"c))
            bptr += 1
            buffer(bptr) = CByte(AscW("<"c))
            bptr += 1
            buffer(bptr) = 7
            bptr += 1
            buffer(bptr) = CByte(MSP_SET_RC_TUNING)
            bptr += 1

            buffer(bptr) = rcRate
            bptr += 1
            buffer(bptr) = rcExpo
            bptr += 1
            buffer(bptr) = RollPitchRate
            bptr += 1
            buffer(bptr) = YawRate
            bptr += 1
            buffer(bptr) = DynThrPID
            bptr += 1
            buffer(bptr) = ThrottleMID
            bptr += 1
            buffer(bptr) = ThrottleEXPO
            bptr += 1
            For i As Integer = 3 To bptr
                checksum = checksum Xor buffer(i)
            Next
            buffer(bptr) = checksum
            bptr += 1
            serialport.Write(buffer, 0, bptr)

            'Write PID's 
            checksum = 0
            bptr = 0
            buffer(bptr) = CByte(AscW("$"c))
            bptr += 1
            buffer(bptr) = CByte(AscW("M"c))
            bptr += 1
            buffer(bptr) = CByte(AscW("<"c))
            bptr += 1
            buffer(bptr) = CByte(3 * iPIDItems)
            bptr += 1
            buffer(bptr) = CByte(MSP_SET_PID)
            bptr += 1
            For i As Integer = 0 To iPIDItems - 1
                buffer(bptr) = pidP(i)
                bptr += 1
                buffer(bptr) = pidI(i)
                bptr += 1
                buffer(bptr) = pidD(i)
                bptr += 1
            Next
            For i As Integer = 3 To bptr
                checksum = checksum Xor buffer(i)
            Next
            buffer(bptr) = checksum
            bptr += 1
            serialport.Write(buffer, 0, bptr)

            'Then write checkboxitems
            checksum = 0
            bptr = 0
            buffer(bptr) = CByte(AscW("$"c))
            bptr += 1
            buffer(bptr) = CByte(AscW("M"c))
            bptr += 1
            buffer(bptr) = CByte(AscW("<"c))
            bptr += 1
            buffer(bptr) = CByte(cfgBoxWidth * iCheckBoxItems)
            bptr += 1
            buffer(bptr) = CByte(MSP_SET_BOX)
            bptr += 1
            For i As Integer = 0 To iCheckBoxItems - 1
                buffer(bptr) = CByte(activation(i) And &HFF)
                bptr += 1
                buffer(bptr) = CByte((activation(i) >> 8) And &HFF)
                bptr += 1
                If cfgBoxWidth = 4 Then
                    buffer(bptr) = CByte((activation(i) >> 16) And &HFF)
                    bptr += 1
                    buffer(bptr) = CByte((activation(i) >> 24) And &HFF)
                    bptr += 1
                End If
            Next
            For i As Integer = 3 To bptr - 1
                checksum = checksum Xor buffer(i)
            Next
            buffer(bptr) = checksum
            bptr += 1
            serialport.Write(buffer, 0, bptr)

            'then the rest
            checksum = 0
            bptr = 0
            buffer(bptr) = CByte(AscW("$"c))
            bptr += 1
            buffer(bptr) = CByte(AscW("M"c))
            bptr += 1
            buffer(bptr) = CByte(AscW("<"c))
            bptr += 1
            buffer(bptr) = CByte(2)
            bptr += 1
            buffer(bptr) = CByte(MSP_SET_MISC)
            bptr += 1

            buffer(bptr) = CByte(PowerTrigger And &HFF)
            bptr += 1
            buffer(bptr) = CByte((PowerTrigger >> 8) And &HFF)
            bptr += 1

            For i As Integer = 3 To bptr - 1
                checksum = checksum Xor buffer(i)
            Next
            buffer(bptr) = checksum
            bptr += 1
            serialport.Write(buffer, 0, bptr)

            Dim c As Byte = 0
            Dim o As Byte()
            o = New Byte(9) {}
            ' with checksum 
            o(0) = CByte(AscW("$"c))
            o(1) = CByte(AscW("M"c))
            o(2) = CByte(AscW("<"c))
            o(3) = CByte(0)
            c = c Xor o(3)
            'no payload 
            o(4) = CByte(MSP_EEPROM_WRITE)
            c = c Xor o(4)
            o(5) = CByte(c)
            serialport.Write(o, 0, 6)
        End If
    End Sub

    Public Sub save_to_xml(filename As String)
        Dim tw As New Xml.XmlTextWriter(filename, Nothing)
        tw.Formatting = Xml.Formatting.Indented
        tw.Indentation = 4
        tw.WriteStartDocument()

        ' Get the name and version of the current assembly.
        Dim assem As Reflection.Assembly = Reflection.Assembly.GetExecutingAssembly()
        Dim assemName As Reflection.AssemblyName = assem.GetName()
        Dim ver As Version = assemName.Version
        tw.WriteComment([String].Format("{0}, Version {1}", assemName.Name, ver.ToString()))
        tw.WriteComment("MultiWii FC Parameters file")
        tw.WriteComment("MultiWii FC software revision 2.1dev")

        tw.WriteStartElement("PARAMETERS")

        tw.WriteStartElement("VERSION value=""" & iSwVer & """")
        tw.WriteEndElement()

        For i As Integer = 0 To iPIDItems - 1
            tw.WriteStartElement("PID id=""" & i & """ name=""" & pidnames(i) & """ p=""" & Convert.ToString(pidP(i)) & """ i=""" & Convert.ToString(pidI(i)) & """ d=""" & Convert.ToString(pidD(i)) & """")

            tw.WriteEndElement()
        Next

        For i As Integer = 0 To iCheckBoxItems - 1
            tw.WriteStartElement("AUXFUNC id=""" & i & """ aux1234=""" & activation(i) & """")
            tw.WriteEndElement()
        Next

        tw.WriteStartElement("RCRATE value=""" & rcRate & """")
        tw.WriteEndElement()
        tw.WriteStartElement("RCEXPO value=""" & rcExpo & """")
        tw.WriteEndElement()
        tw.WriteStartElement("THMID value=""" & ThrottleMID & """")
        tw.WriteEndElement()
        tw.WriteStartElement("THEXPO value=""" & ThrottleMID & """")
        tw.WriteEndElement()
        tw.WriteStartElement("ROLLPITCHRATE value=""" & RollPitchRate & """")
        tw.WriteEndElement()
        tw.WriteStartElement("YAWRATE value=""" & YawRate & """")
        tw.WriteEndElement()
        tw.WriteStartElement("DYNTHRPID value=""" & DynThrPID & """")
        tw.WriteEndElement()
        tw.WriteStartElement("POWERTRIGGER value=""" & PowerTrigger & """")
        tw.WriteEndElement()
        tw.WriteStartElement("COMMENT value=""" & comment & """")
        tw.WriteEndElement()

        tw.WriteEndElement()
        tw.WriteEndDocument()
        tw.Close()
    End Sub

    Public Function read_from_xml(filename As String) As Boolean

        Dim reader As New Xml.XmlTextReader(filename)
        'MessageBox.Show("Options file " + sOptionsConfigFilename + " does not found", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        Try
            While reader.Read()
                Select Case reader.NodeType
                    Case Xml.XmlNodeType.Element

                        If [String].Compare(reader.Name, "version", True) = 0 AndAlso reader.HasAttributes Then
                            If Convert.ToInt16(reader.GetAttribute("value")) <> iSwVer Then
                                Throw New System.InvalidOperationException("Version of settings file does not match with the version set in GUI")
                            End If
                        End If
                        If [String].Compare(reader.Name, "pid", True) = 0 AndAlso reader.HasAttributes Then
                            Dim tpidID As Integer = 0
                            Dim tpidP As Byte = 0
                            Dim tpidI As Byte = 0
                            Dim tpidD As Byte = 0

                            tpidID = Convert.ToInt16(reader.GetAttribute("id"))
                            tpidP = Convert.ToByte(reader.GetAttribute("p"))
                            tpidI = Convert.ToByte(reader.GetAttribute("i"))
                            tpidD = Convert.ToByte(reader.GetAttribute("d"))
                            pidP(tpidID) = tpidP
                            pidI(tpidID) = tpidI
                            pidD(tpidID) = tpidD
                        End If
                        If [String].Compare(reader.Name, "auxfunc", True) = 0 AndAlso reader.HasAttributes Then
                            Dim auxID As Integer = 0
                            Dim a1 As UInteger = 0
                            auxID = Convert.ToInt16(reader.GetAttribute("id"))
                            a1 = Convert.ToUInt16(reader.GetAttribute("aux1234"))
                            activation(auxID) = a1
                        End If
                        If [String].Compare(reader.Name, "rcrate", True) = 0 AndAlso reader.HasAttributes Then
                            rcRate = Convert.ToByte(reader.GetAttribute("value"))
                        End If
                        If [String].Compare(reader.Name, "rcexpo", True) = 0 AndAlso reader.HasAttributes Then
                            rcExpo = Convert.ToByte(reader.GetAttribute("value"))
                        End If
                        If [String].Compare(reader.Name, "thmid", True) = 0 AndAlso reader.HasAttributes Then
                            ThrottleMID = Convert.ToByte(reader.GetAttribute("value"))
                        End If
                        If [String].Compare(reader.Name, "thexpo", True) = 0 AndAlso reader.HasAttributes Then
                            ThrottleEXPO = Convert.ToByte(reader.GetAttribute("value"))
                        End If
                        If [String].Compare(reader.Name, "rollpitchrate", True) = 0 AndAlso reader.HasAttributes Then
                            RollPitchRate = Convert.ToByte(reader.GetAttribute("value"))
                        End If
                        If [String].Compare(reader.Name, "yawrate", True) = 0 AndAlso reader.HasAttributes Then
                            YawRate = Convert.ToByte(reader.GetAttribute("value"))
                        End If
                        If [String].Compare(reader.Name, "dynthrpid", True) = 0 AndAlso reader.HasAttributes Then
                            DynThrPID = Convert.ToByte(reader.GetAttribute("value"))
                        End If
                        If [String].Compare(reader.Name, "powertrigger", True) = 0 AndAlso reader.HasAttributes Then
                            PowerTrigger = Convert.ToByte(reader.GetAttribute("value"))
                        End If
                        If [String].Compare(reader.Name, "comment", True) = 0 AndAlso reader.HasAttributes Then
                            comment = reader.GetAttribute("value")
                        End If
                        Exit Select
                End Select
            End While
        Catch e As System.InvalidOperationException
            MessageBox.Show(e.Message, "Version mismatch", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return (False)
        Catch
            MessageBox.Show("Options file contains invalid data around Line : " + reader.LineNumber, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.[Stop])
            Return (False)
        Finally

            If reader IsNot Nothing Then
                reader.Close()
            End If
        End Try
        Return (True)
    End Function
End Class

