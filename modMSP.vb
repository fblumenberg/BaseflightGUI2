Module modMSP

    Public inBuf As Byte()

    Private c_state As Byte = IDLE
    Private err_rcvd As Boolean = False
    Private offset As Byte = 0
    Private dataSize As Byte = 0
    Private checksum As Byte = 0
    Private cmd As Byte
    Public serial_error_count As Integer = 0
    Public serial_packet_count As Integer = 0

#Region "Commands"

    Public Const MSP_IDENT As Integer = 100

    Public Const MSP_STATUS As Integer = 101
    Public Const MSP_RAW_IMU As Integer = 102
    Public Const MSP_SERVO As Integer = 103
    Public Const MSP_MOTOR As Integer = 104
    Public Const MSP_RC As Integer = 105
    Public Const MSP_RAW_GPS As Integer = 106
    Public Const MSP_COMP_GPS As Integer = 107
    Public Const MSP_ATTITUDE As Integer = 108
    Public Const MSP_ALTITUDE As Integer = 109
    Public Const MSP_BAT As Integer = 110
    Public Const MSP_RC_TUNING As Integer = 111
    Public Const MSP_PID As Integer = 112
    Public Const MSP_BOX As Integer = 113
    Public Const MSP_MISC As Integer = 114
    Public Const MSP_MOTOR_PINS As Integer = 115
    Public Const MSP_BOXNAMES As Integer = 116
    Public Const MSP_PIDNAMES As Integer = 117
    Public Const MSP_WP As Integer = 118
    Public Const MSP_BOXIDS As Integer = 119

    Public Const MSP_SET_RAW_RC As Integer = 200
    Public Const MSP_SET_RAW_GPS As Integer = 201
    Public Const MSP_SET_PID As Integer = 202
    Public Const MSP_SET_BOX As Integer = 203
    Public Const MSP_SET_RC_TUNING As Integer = 204
    Public Const MSP_ACC_CALIBRATION As Integer = 205
    Public Const MSP_MAG_CALIBRATION As Integer = 206
    Public Const MSP_SET_MISC As Integer = 207
    Public Const MSP_RESET_CONF As Integer = 208
    Public Const MSP_SET_WP As Integer = 209
    Public Const MSP_SELECT_SETTING As Integer = 210
    Public Const MSP_SET_HEAD As Integer = 211

    Public Const MSP_EEPROM_WRITE As Integer = 250
    Public Const MSP_DEBUG As Integer = 254

    'Additional Commands not compatible with MultiWii
    Public Const MSP_UID As Integer = 160
    Public Const MSP_TEMPERATURE As Integer = 161
    Public Const MSP_SONAR As Integer = 162
    Public Const MSP_FIRMWARE As Integer = 163

    Public Const IDLE As Byte = 0
    Public Const HEADER_START As Byte = 1
    Public Const HEADER_M As Byte = 2
    Public Const HEADER_ARROW As Byte = 3
    Public Const HEADER_SIZE As Byte = 4
    Public Const HEADER_CMD As Byte = 5
    Public Const HEADER_ERR As Byte = 6

#End Region

    Public Sub MSPquery(command As Integer)
        Dim c As Byte = 0
        Dim o As Byte()
        o = New Byte(9) {}
        ' with checksum 
        o(0) = Convert.ToByte(Asc("$"c))
        o(1) = Convert.ToByte(Asc("M"c))
        o(2) = Convert.ToByte(Asc("<"c))
        o(3) = Convert.ToByte(0)
        c = c Xor o(3)
        'no payload 
        o(4) = Convert.ToByte(command)
        c = c Xor o(4)
        o(5) = Convert.ToByte(c)
        Try
            If isConnected = True Then
                serialPort.Write(o, 0, 6)
            End If
        Catch ex As Exception
            comError = True
            lostConnection()
        End Try
    End Sub

    Public Sub ReadMSP()
        Try
            Do While serialPort.BytesToRead > 0
                Dim c As Byte
                c = serialPort.ReadByte()
                Select Case c_state
                    Case IDLE
                        c_state = If(c = 36, HEADER_START, IDLE) '"$"
                        Exit Select
                    Case HEADER_START
                        c_state = If(c = 77, HEADER_M, IDLE) '"M"
                        Exit Select
                    Case HEADER_M
                        If c = 62 Then '">"
                            c_state = HEADER_ARROW
                        ElseIf c = 33 Then '"!"
                            c_state = HEADER_ERR
                        Else
                            c_state = IDLE
                        End If
                        Exit Select
                    Case HEADER_ARROW, HEADER_ERR
                        ' is this an error message? 
                        err_rcvd = (c_state = HEADER_ERR)
                        ' now we are expecting the payload size 
                        dataSize = c
                        ' reset index variables 
                        offset = 0
                        checksum = 0
                        checksum = checksum Xor c
                        c_state = HEADER_SIZE
                        If dataSize > 150 Then
                            c_state = IDLE
                        End If
                        Exit Select
                    Case HEADER_SIZE
                        cmd = c
                        checksum = checksum Xor c
                        c_state = HEADER_CMD
                        Exit Select
                    Case HEADER_CMD
                        If offset < dataSize Then
                            checksum = checksum Xor c
                            offset += 1
                            inBuf(offset) = c
                        Else
                            ' compare calculated and transferred checksum 
                            If checksum = c Then
                                ' Console.WriteLine("Copter did not understand request type " + err_rcvd);
                                If err_rcvd Then
                                Else
                                    ' we got a valid response packet, evaluate it 
                                    serial_packet_count += 1
                                    Try
                                        'frmMain.lblVPacketReceived.Text = serial_packet_count
                                    Catch ex As Exception

                                    End Try
                                    Application.DoEvents()
                                    evaluate_command(cmd)
                                End If
                            Else
                                serial_error_count += 1
                                Try
                                    'frmMain.lblVPacketError.Text = serial_error_count
                                Catch ex As Exception

                                End Try
                                Application.DoEvents()
                            End If
                            c_state = IDLE
                        End If
                        Exit Select
                End Select
            Loop
        Catch ex As Exception
            frmError.lastCommand = "ReadMSP()"
            frmError.myEx = ex
            If frmError.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                System.Windows.Forms.Application.Exit()
            End If
        End Try
    End Sub

    Private Sub evaluate_command(cmd As Byte)
        Try
            Dim ptr As Integer

            Select Case cmd
                Case MSP_IDENT
                    ptr = 1
                    mw_gui.version = Convert.ToByte(inBuf(ptr))
                    ptr += 1
                    mw_gui.multiType = Convert.ToByte(inBuf(ptr))
                    ptr += 1
                    mw_gui.protocol_version = Convert.ToByte(inBuf((ptr)))
                    ptr += 1
                    mw_gui.capability = BitConverter.ToUInt32(inBuf, ptr)
                    ptr += 4
                    Exit Select
                Case MSP_STATUS
                    ptr = 1
                    mw_gui.cycleTime = BitConverter.ToInt16(inBuf, ptr)
                    ptr += 2
                    mw_gui.i2cErrors = BitConverter.ToInt16(inBuf, ptr)
                    ptr += 2
                    mw_gui.present = BitConverter.ToInt16(inBuf, ptr)
                    ptr += 2
                    mw_gui.mode = BitConverter.ToUInt32(inBuf, ptr)
                    ptr += 4
                    Exit Select
                Case MSP_RAW_IMU
                    ptr = 1
                    mw_gui.ax = BitConverter.ToInt16(inBuf, ptr)
                    ptr += 2
                    mw_gui.ay = BitConverter.ToInt16(inBuf, ptr)
                    ptr += 2
                    mw_gui.az = BitConverter.ToInt16(inBuf, ptr)
                    ptr += 2

                    mw_gui.gx = BitConverter.ToInt16(inBuf, ptr) / 8
                    ptr += 2
                    mw_gui.gy = BitConverter.ToInt16(inBuf, ptr) / 8
                    ptr += 2
                    mw_gui.gz = BitConverter.ToInt16(inBuf, ptr) / 8
                    ptr += 2

                    mw_gui.magx = BitConverter.ToInt16(inBuf, ptr) / 3
                    ptr += 2
                    mw_gui.magy = BitConverter.ToInt16(inBuf, ptr) / 3
                    ptr += 2
                    mw_gui.magz = BitConverter.ToInt16(inBuf, ptr) / 3
                    ptr += 2
                    Exit Select
                Case MSP_SERVO
                    ptr = 1
                    For i As Integer = 0 To 7
                        mw_gui.servos(i) = BitConverter.ToInt16(inBuf, ptr)
                        ptr += 2
                    Next
                    Exit Select
                Case MSP_MOTOR
                    ptr = 1
                    For i As Integer = 0 To 7
                        mw_gui.motors(i) = BitConverter.ToInt16(inBuf, ptr)
                        ptr += 2
                    Next
                    Exit Select
                Case MSP_RC
                    Try
                        ptr = 1
                        mw_gui.rcRoll = BitConverter.ToInt16(inBuf, ptr)
                        ptr += 2
                        mw_gui.rcPitch = BitConverter.ToInt16(inBuf, ptr)
                        ptr += 2
                        mw_gui.rcYaw = BitConverter.ToInt16(inBuf, ptr)
                        ptr += 2
                        mw_gui.rcThrottle = BitConverter.ToInt16(inBuf, ptr)
                        ptr += 2
                        If AUX_CHANNELS <> ((dataSize / 2) - 4) Then
                            AUX_CHANNELS = (dataSize / 2) - 4
                            isAUX_CHANNEL_update = True
                        End If
                        For i As Integer = 0 To AUX_CHANNELS - 1
                            mw_gui.rcAUX(i) = BitConverter.ToInt16(inBuf, ptr)
                            ptr += 2
                        Next
                        Exit Select
                    Catch ex As Exception

                    End Try
                Case MSP_RAW_GPS
                    ptr = 1
                    mw_gui.GPS_fix = Convert.ToByte(inBuf(ptr))
                    ptr += 1
                    mw_gui.GPS_numSat = Convert.ToByte(inBuf(ptr))
                    ptr += 1
                    mw_gui.GPS_latitude = BitConverter.ToInt32(inBuf, ptr)
                    ptr += 4
                    mw_gui.GPS_longitude = BitConverter.ToInt32(inBuf, ptr)
                    ptr += 4
                    mw_gui.GPS_altitudeMSL = BitConverter.ToInt16(inBuf, ptr)
                    ptr += 2
                    mw_gui.GPS_speed = BitConverter.ToInt16(inBuf, ptr)
                    Exit Select
                Case MSP_COMP_GPS
                    ptr = 1
                    mw_gui.GPS_distanceToHome = BitConverter.ToInt16(inBuf, ptr)
                    ptr += 2
                    mw_gui.GPS_directionToHome = BitConverter.ToInt16(inBuf, ptr)
                    ptr += 2
                    mw_gui.GPS_update = Convert.ToByte(inBuf(ptr))
                    Exit Select
                Case MSP_ATTITUDE
                    ptr = 1
                    mw_gui.angx = BitConverter.ToInt16(inBuf, ptr) / 10
                    ptr += 2
                    mw_gui.angy = BitConverter.ToInt16(inBuf, ptr) / 10
                    ptr += 2
                    mw_gui.heading = BitConverter.ToInt16(inBuf, ptr)
                    ptr += 2
                    Exit Select
                Case MSP_ALTITUDE
                    ptr = 1
                    mw_gui.baro = BitConverter.ToInt32(inBuf, ptr)
                    ptr += 4
                    Exit Select
                Case MSP_BAT
                    ptr = 1
                    mw_params.vBat = Convert.ToByte(inBuf(ptr))
                    ptr = 1
                    mw_params.pMeterSum = BitConverter.ToInt16(inBuf, ptr)
                    Exit Select
                Case MSP_RC_TUNING
                    ptr = 1
                    mw_params.rcRate = Convert.ToByte(inBuf(ptr))
                    ptr += 1
                    mw_params.rcExpo = Convert.ToByte(inBuf(ptr))
                    ptr += 1
                    mw_params.RollPitchRate = Convert.ToByte(inBuf(ptr))
                    ptr += 1
                    mw_params.YawRate = Convert.ToByte(inBuf(ptr))
                    ptr += 1
                    mw_params.DynThrPID = Convert.ToByte(inBuf(ptr))
                    ptr += 1
                    mw_params.ThrottleMID = Convert.ToByte(inBuf(ptr))
                    ptr += 1
                    mw_params.ThrottleEXPO = Convert.ToByte(inBuf(ptr))
                    Exit Select
                Case MSP_PID
                    ptr = 0
                    For i As Integer = 0 To iPidItems - 1
                        ptr += 1
                        mw_params.pidP(i) = Convert.ToByte(inBuf(ptr))
                        ptr += 1
                        mw_params.pidI(i) = Convert.ToByte(inBuf(ptr))
                        ptr += 1
                        mw_params.pidD(i) = Convert.ToByte(inBuf(ptr))
                    Next
                    ' bOptions_needs_refresh = True
                    Exit Select
                Case MSP_BOX
                    Try
                        ptr = 1
                        cfgBoxWidth = dataSize / iCheckBoxItems
                        If mw_params.activation.Length < dataSize / cfgBoxWidth Then
                            mw_params.activation = New UInt32(dataSize / cfgBoxWidth - 1) {}
                        End If
                        For i As Integer = 0 To (dataSize / cfgBoxWidth) - 1
                            mw_params.activation(i) = BitConverter.ToInt32(inBuf, ptr)
                            ptr += cfgBoxWidth
                        Next
                    Catch ex As Exception

                    End Try
                    Exit Select
                Case MSP_BOXNAMES
                    iCheckBoxItems = 0
                    Dim builder As New System.Text.StringBuilder()
                    ptr = 1
                    While ptr <= dataSize
                        builder.Append(CChar(ChrW(inBuf(ptr))))
                        ptr += 1
                    End While
                    builder.Remove(builder.Length - 1, 1)
                    Dim boxNames As String() = builder.ToString().Split(";"c)
                    iCheckBoxItems = boxNames.Length
                    sBoxNames = New String(iCheckBoxItems) {}
                    If IsNothing(mw_gui) = False Then
                        sBoxNames = New String(builder.ToString().Split(";"c).Length - 1) {}
                        sBoxNames = boxNames
                        mw_gui.bUpdateBoxNames = True
                    End If
                    Exit Select
                Case MSP_BOXIDS
                    ptr = 0
                    Dim BOXIDS(dataSize - 1) As Integer
                    While ptr < dataSize
                        BOXIDS(ptr) = Int(inBuf(ptr + 1))
                        ptr += 1
                    End While
                    iBoxIdents = BOXIDS
                    Exit Select
                Case MSP_MISC
                    ptr = 1
                    mw_params.PowerTrigger = BitConverter.ToInt16(inBuf, ptr)
                    Exit Select
                Case MSP_DEBUG
                    ptr = 1
                    mw_gui.debug1 = BitConverter.ToInt16(inBuf, ptr)
                    ptr += 2
                    mw_gui.debug2 = BitConverter.ToInt16(inBuf, ptr)
                    ptr += 2
                    mw_gui.debug3 = BitConverter.ToInt16(inBuf, ptr)
                    ptr += 2
                    mw_gui.debug4 = BitConverter.ToInt16(inBuf, ptr)
                    Exit Select
                Case MSP_WP
                    ptr = 1
                    Dim wp_no As Byte = Convert.ToByte(inBuf(ptr))
                    ptr += 1
                    If wp_no = 0 Then
                        mw_gui.GPS_home_lat = BitConverter.ToInt32(inBuf, ptr)
                        ptr += 4
                        mw_gui.GPS_home_lon = BitConverter.ToInt32(inBuf, ptr)
                        ptr += 4
                        mw_gui.GPS_home_alt = BitConverter.ToInt32(inBuf, ptr)
                        ptr += 4
                        Dim GPS_heading As Int16 = BitConverter.ToInt16(inBuf, ptr)
                        ptr += 2
                        Dim TimeToStay As Int16 = BitConverter.ToInt16(inBuf, ptr)
                        ptr += 2
                        Dim action As Byte = Convert.ToByte(inBuf(ptr))
                        ptr += 1
                        Dim action_paramter As Int16 = BitConverter.ToInt16(inBuf, ptr)
                        ptr += 2
                    Else
                        Dim newRow As DataRow = dtWayPoints.NewRow
                        newRow("WPNo") = wp_no
                        newRow("Lat") = BitConverter.ToInt32(inBuf, ptr) / 10000000
                        ptr += 4
                        newRow("Lon") = BitConverter.ToInt32(inBuf, ptr) / 10000000
                        ptr += 4
                        newRow("Alt") = BitConverter.ToInt32(inBuf, ptr) / 10000000
                        ptr += 4
                        newRow("Heading") = BitConverter.ToInt16(inBuf, ptr)
                        ptr += 4
                        newRow("TimeToStay") = BitConverter.ToInt16(inBuf, ptr)
                        ptr += 4
                        newRow("Action") = Convert.ToByte(inBuf(ptr))
                        ptr += 4
                        newRow("ActionParameter") = BitConverter.ToInt16(inBuf, ptr)
                        ptr += 4
                        dtWayPoints.Rows.Add(newRow)
                        isNewWayPoint = True
                    End If
                    Exit Select
                Case MSP_UID
                    Dim tmp As String = ""
                    For ptr = 1 To 12
                        tmp = tmp & Hex(Convert.ToByte(inBuf(ptr)))
                    Next
                    sUID = tmp
                    Exit Select
                Case MSP_TEMPERATURE
                    ptr = 1
                    mw_gui.Temp = Convert.ToByte(inBuf(ptr))
                    Exit Select
                Case MSP_SONAR
                    ptr = 1
                    mw_gui.Sonar = BitConverter.ToInt16(inBuf, ptr)
                    Exit Select
                Case MSP_FIRMWARE
                    Dim builder As New System.Text.StringBuilder()
                    ptr = 1
                    While ptr <= dataSize
                        builder.Append(CChar(ChrW(inBuf(ptr))))
                        ptr += 1
                    End While
                    mw_gui.firmware = builder.ToString()
                    Exit Select
            End Select
        Catch ex As Exception
            frmError.lastCommand = "evaluate_command(" & cmd.ToString & ")"
            frmError.myEx = ex
            If frmError.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                System.Windows.Forms.Application.Exit()
            End If
        End Try
    End Sub

End Module
