Module modPassGPS
    Public isPASSGPS As Boolean = False

    Public Sub endPassGPS()
        isPASSGPS = False
        isCLI = True
        If serialPort.IsOpen Then
            Dim strExit As String = StrDup(21, "@")
            serialPort.Write(strExit & vbCrLf)
            sleep(250)
        End If
    End Sub

    Public Sub startPassGPS()
        '     0xB5, 0x62, 0x06,     0x01, 0x03, 0x00, 0x01, 0x30, 0x01, 0x3C, 0xA3,                                  // set SVINFO MSG rate
        If serialPort.IsOpen Then
            isRealtime = False
            isPASSGPS = True
            serialPort.Write("#")
            sleep(250)
            serialPort.Write("PASSGPS 1" & vbCrLf)
        End If
    End Sub

    Public Sub ReadGPS()
        Try
            Dim data As Byte
            Dim ck_a As Byte = 0
            Dim ck_b As Byte = 0
            Do While serialPort.BytesToRead > 0
                data = serialPort.ReadByte()
                If data = &HB5 Then                                             'Preamble1
                    data = serialPort.ReadByte()
                    If data = &H62 Then                                         'Preambel2
                        data = serialPort.ReadByte()
                        If data = &H1 Then                                      'ClassID
                            ck_a = data                                  ' reset the checksum accumulators
                            ck_b = data                                  ' reset the checksum accumulators
                            Dim cmd As Byte = serialPort.ReadByte()             'MSGID
                            ck_a = (CInt(ck_a) + cmd) And &HFF
                            ck_b = (CInt(ck_a) + CInt(ck_b)) And &HFF                       ' checksum byte
                            'Dim payload As Byte = serialPort.ReadByte()
                            Dim payloadCounter As Integer = 0
                            Dim payload As Integer = serialPort.ReadByte()
                            ck_a = (CInt(ck_a) + payload) And &HFF
                            ck_b = (CInt(ck_a) + CInt(ck_b)) And &HFF                        ' checksum byte
                            data = serialPort.ReadByte()
                            ck_a = (CInt(ck_a) + data) And &HFF
                            ck_b = (CInt(ck_a) + CInt(ck_b)) And &HFF                       ' checksum byte
                            payload += CInt((data << 8))
                            gpsBuffer = New Byte(299) {}
                            Do While payloadCounter < payload
                                data = serialPort.ReadByte()
                                ck_a = (CInt(ck_a) + data) And &HFF
                                ck_b = (CInt(ck_a) + CInt(ck_b)) And &HFF                       ' checksum byte
                                gpsBuffer(payloadCounter) = data
                                payloadCounter += 1
                            Loop
                            data = serialPort.ReadByte()
                            If ck_a = data Then
                                data = serialPort.ReadByte()
                                If ck_b = data Then
                                    mw_gui.GPS_Count += 1
                                    Select Case cmd
                                        Case &H2
                                            GPS_calc_Hz("POSLLH")
                                            parseGPS_POSLLH(gpsBuffer)
                                        Case &H6
                                            GPS_calc_Hz("SOL")
                                            parseGPS_SOL(gpsBuffer)
                                        Case &H12
                                            GPS_calc_Hz("VELNED")
                                            parseGPS_VELNED(gpsBuffer)
                                        Case &H30
                                            GPS_calc_Hz("SVINFO")
                                            parseGPS_SVINFO(gpsBuffer)
                                    End Select
                                Else
                                    mw_gui.GPS_Error += 1
                                End If
                            Else
                                mw_gui.GPS_Error += 1
                            End If
                        End If
                    End If
                End If
            Loop
        Catch ex As Exception
            'frmError.lastCommand = "ReadGPS()"
            'frmError.myEx = ex
            'If frmError.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            '    System.Windows.Forms.Application.Exit()
            'End If
        End Try
    End Sub

    Private Sub parseGPS_POSLLH(ByVal gpsBuf() As Byte) '&H02
        'Payload = 28
        'uint32_t time;  // GPS msToW
        'int32_t  longitude;
        'int32_t  latitude;
        'int32_t  altitude_ellipsoid;
        'int32_t  altitude_msl;
        'uint32_t horizontal_accuracy;
        'uint32_t vertical_accuracy;
        Try
            Dim ptr As Integer = 0
            Dim time As UInt32 = BitConverter.ToUInt32(gpsBuf, ptr)                 ' GPS Millisecond Time of Week
            ptr += 4
            mw_gui.GPS_longitude = BitConverter.ToInt32(gpsBuf, ptr)                ' Longitude (deg)
            ptr += 4
            mw_gui.GPS_latitude = BitConverter.ToInt32(gpsBuf, ptr)                 ' Latitude (deg)
            ptr += 4
            mw_gui.GPS_altitude = BitConverter.ToInt32(gpsBuf, ptr)                 ' Height above Ellipsoid (mm)
            ptr += 4
            mw_gui.GPS_altitudeMSL = BitConverter.ToInt32(gpsBuf, ptr)              ' Height above mean sea level (mm)
            ptr += 4
            mw_gui.GPS_hAcc = BitConverter.ToUInt32(gpsBuf, ptr)                    ' Horizontal Accuracy Estimate (mm)
            ptr += 4
            mw_gui.GPS_vAcc = BitConverter.ToUInt32(gpsBuf, ptr)                    ' Vertical Accuracy Estimate (mm)
            ptr += 4
        Catch ex As Exception
            'frmError.lastCommand = "ReadGPS()"
            'frmError.myEx = ex
            'If frmError.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            '    System.Windows.Forms.Application.Exit()
            'End If
        End Try
    End Sub

    Private Sub parseGPS_SOL(ByVal gpsBuf() As Byte) '&H06
        'Payload = 52
        'uint32_t time;
        'int32_t  time_nsec;
        'int16_t  week;
        'uint8_t  fix_type;
        'uint8_t  fix_status;
        '
        'int32_t  ecef_x;
        'int32_t  ecef_y;
        'int32_t  ecef_z;
        'uint32_t position_accuracy_3d;
        '
        'int32_t  ecef_x_velocity;
        'int32_t  ecef_y_velocity;
        'int32_t  ecef_z_velocity;
        'uint32_t speed_accuracy;
        '
        'uint16_t position_DOP;
        'uint8_t  res;
        'uint8_t  satellites;
        'uint32_t res2;
        Try
            Dim ptr As Integer = 0
            Dim time As UInt32 = BitConverter.ToUInt32(gpsBuf, ptr)
            ptr += 4
            Dim time_nsec As Int32 = BitConverter.ToInt32(gpsBuf, ptr)
            ptr += 4
            Dim week As Int16 = BitConverter.ToInt16(gpsBuf, ptr)
            ptr += 2
            mw_gui.GPS_fix = Convert.ToByte(gpsBuf(ptr))
            ptr += 1
            mw_gui.GPS_fix_status = Convert.ToByte(gpsBuf(ptr))
            ptr += 1
            '
            mw_gui.GPS_ecef_x = BitConverter.ToInt32(gpsBuf, ptr)
            ptr += 4
            mw_gui.GPS_ecef_y = BitConverter.ToInt32(gpsBuf, ptr)
            ptr += 4
            mw_gui.GPS_ecef_z = BitConverter.ToInt32(gpsBuf, ptr)
            ptr += 4
            mw_gui.GPS_position_accuracy_3d = BitConverter.ToUInt32(gpsBuf, ptr)
            ptr += 4
            '
            mw_gui.GPS_ecef_x_velocity = BitConverter.ToInt32(gpsBuf, ptr)
            ptr += 4
            mw_gui.GPS_ecef_y_velocity = BitConverter.ToInt32(gpsBuf, ptr)
            ptr += 4
            mw_gui.GPS_ecef_z_velocity = BitConverter.ToInt32(gpsBuf, ptr)
            ptr += 4
            mw_gui.GPS_speed_accuracy = BitConverter.ToUInt32(gpsBuf, ptr)
            ptr += 4
            '
            mw_gui.GPS_position_DOP = BitConverter.ToUInt16(gpsBuf, ptr)
            ptr += 2
            Dim res As Byte = Convert.ToByte(gpsBuf(ptr))
            ptr += 1
            mw_gui.GPS_numSat = Convert.ToByte(gpsBuf(ptr))
            ptr += 1
            Dim res2 As UInt32 = BitConverter.ToInt32(gpsBuf, ptr)
            ptr += 4
        Catch ex As Exception
            'frmError.lastCommand = "ReadGPS()"
            'frmError.myEx = ex
            'If frmError.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            '    System.Windows.Forms.Application.Exit()
            'End If
        End Try
    End Sub

    Private Sub parseGPS_VELNED(ByVal gpsBuf() As Byte) '&H12
        'Payload = 36
        'uint32_t time;  // GPS msToW
        'int32_t  ned_north;
        'int32_t  ned_east;
        'int32_t  ned_down;
        'uint32_t speed_3d;
        'uint32_t speed_2d;
        'int32_t  heading_2d;
        'uint32_t speed_accuracy;
        'uint32_t heading_accuracy;
        Try
            Dim ptr As Integer = 0
            Dim time As UInt32 = BitConverter.ToInt32(gpsBuf, ptr)
            ptr += 4
            mw_gui.GPS_ned_north = BitConverter.ToInt32(gpsBuf, ptr)
            ptr += 4
            mw_gui.GPS_ned_east = BitConverter.ToInt32(gpsBuf, ptr)
            ptr += 4
            mw_gui.GPS_ned_down = BitConverter.ToInt32(gpsBuf, ptr)
            ptr += 4
            mw_gui.GPS_speed_3d = BitConverter.ToUInt32(gpsBuf, ptr)
            ptr += 4
            mw_gui.GPS_speed_2d = BitConverter.ToUInt32(gpsBuf, ptr)
            ptr += 4
            mw_gui.GPS_heading_2d = BitConverter.ToInt32(gpsBuf, ptr)
            ptr += 4
            mw_gui.GPS_speed_accuracy1 = BitConverter.ToInt32(gpsBuf, ptr)
            ptr += 4
            mw_gui.GPS_heading_accuracy = BitConverter.ToUInt32(gpsBuf, ptr)
            ptr += 4
        Catch ex As Exception
            'frmError.lastCommand = "ReadGPS()"
            'frmError.myEx = ex
            'If frmError.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            '    System.Windows.Forms.Application.Exit()
            'End If
        End Try
    End Sub

    Private Sub parseGPS_SVINFO(ByVal gpsBuf() As Byte) '&H30
        'typedef struct
        '{
        '    uint32_t time;                      // GPS Millisecond time of week
        '    uint8_t numCh;                      // Number of channels
        '    uint8_t globalFlags;                // Bitmask, Chip hardware generation 0:Antaris, 1:u-blox 5, 2:u-blox 6
        '    uint16_t reserved2;                 // Reserved
        '    ubx_nav_svinfo_channel channel[16]; // 16 satellites * 12 byte
        '} ubx_nav_svinfo;

        'typedef struct
        '{
        '    uint8_t chn;                        // Channel number, 255 for SVx not assigned to channel
        '    uint8_t svid;                       // Satellite ID
        '    uint8_t flags;                      // Bitmask
        '    uint8_t quality;                    // Bitfield
        '    uint8_t cno;                        // Carrier to Noise Ratio (Signal Strength)
        '    uint8_t elev;                       // Elevation in integer degrees
        '    int16_t azim;                       // Azimuth in integer degrees
        '    int32_t prRes;                      // Pseudo range residual in centimetres
        '} ubx_nav_svinfo_channel;
        Try
            Dim ptr As Integer = 0
            Dim time As UInt32 = BitConverter.ToInt32(gpsBuf, ptr)
            ptr += 4
            mw_gui.GPS_numCH = Convert.ToByte(gpsBuf(ptr))
            ptr += 1
            Dim globalFlags As Byte = Convert.ToByte(gpsBuf(ptr))
            ptr += 1
            Dim reserved2 As UInt16 = BitConverter.ToInt16(gpsBuf, ptr)
            ptr += 2
            For i As Integer = 1 To mw_gui.GPS_numCH
                If i < 17 Then
                    mw_gui.GPS_chn(i) = Convert.ToByte(gpsBuf(ptr))
                    ptr += 1
                    mw_gui.GPS_svid(i) = Convert.ToByte(gpsBuf(ptr))
                    ptr += 1
                    Dim flags As Byte = Convert.ToByte(gpsBuf(ptr))
                    ptr += 1
                    mw_gui.GPS_quality(i) = Convert.ToByte(gpsBuf(ptr))
                    ptr += 1
                    mw_gui.GPS_cno(i) = Convert.ToByte(gpsBuf(ptr))
                    ptr += 1
                    Dim elev As Byte = Convert.ToByte(gpsBuf(ptr))
                    ptr += 1
                    Dim azim As UInt16 = Convert.ToByte(gpsBuf(ptr))
                    ptr += 2
                    Dim prRes As UInt32 = Convert.ToByte(gpsBuf(ptr))
                    ptr += 4
                End If
            Next
            For i As Integer = mw_gui.GPS_numCH To 16
                mw_gui.GPS_chn(i) = 0
                mw_gui.GPS_svid(i) = 0
                mw_gui.GPS_quality(i) = 0
                mw_gui.GPS_cno(i) = 0
            Next

        Catch ex As Exception
            'frmError.lastCommand = "ReadGPS()"
            'frmError.myEx = ex
            'If frmError.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            '    System.Windows.Forms.Application.Exit()
            'End If
        End Try
    End Sub

    Dim LastTimestampNewGPSdata_SVINFO As UInt32 = 0
    Dim LastTimestampNewGPSdata_POSLLH As UInt32 = 0
    Dim LastTimestampNewGPSdata_SOL As UInt32 = 0
    Dim LastTimestampNewGPSdata_VELNED As UInt32 = 0

    Private Sub GPS_calc_Hz(ByVal Protokoll As String)
        Try
            Dim TimestampNewGPSdata As UInt32 = DateTime.UtcNow.Subtract(New DateTime(Now.Year, Now.Month, Now.Day)).TotalMilliseconds
            Dim LastTimestampNewGPSdata As UInt32 = 0
            Select Case Protokoll
                Case "SVINFO"
                    LastTimestampNewGPSdata = LastTimestampNewGPSdata_SVINFO
                Case "POSLLH"
                    LastTimestampNewGPSdata = LastTimestampNewGPSdata_POSLLH
                Case "SOL"
                    LastTimestampNewGPSdata = LastTimestampNewGPSdata_SOL
                Case "VELNED"
                    LastTimestampNewGPSdata = LastTimestampNewGPSdata_VELNED
            End Select
            Dim RealGPSDeltaTime As UInt32 = TimestampNewGPSdata - LastTimestampNewGPSdata
            mw_gui.GPS_ms_SVINFO = RealGPSDeltaTime
            Select Case Protokoll
                Case "SVINFO"
                    LastTimestampNewGPSdata_SVINFO = TimestampNewGPSdata
                Case "POSLLH"
                    LastTimestampNewGPSdata_POSLLH = TimestampNewGPSdata
                Case "SOL"
                    LastTimestampNewGPSdata_SOL = TimestampNewGPSdata
                Case "VELNED"
                    LastTimestampNewGPSdata_VELNED = TimestampNewGPSdata
            End Select
            If RealGPSDeltaTime > 0 Then
                If (RealGPSDeltaTime < 400) Then
                    If RealGPSDeltaTime > 80 And RealGPSDeltaTime < 120 Then
                        mw_gui.GPS_Hz = 10
                    ElseIf RealGPSDeltaTime > 180 And RealGPSDeltaTime < 220 Then
                        mw_gui.GPS_Hz = 5
                    ElseIf RealGPSDeltaTime > 230 And RealGPSDeltaTime < 270 Then
                        mw_gui.GPS_Hz = 4
                    Else
                        'mw_gui.GPS_Hz = RealGPSDeltaTime
                    End If
                End If
            End If
            Select Case Protokoll
                Case "SVINFO"
                    mw_gui.GPS_ms_SVINFO = RealGPSDeltaTime
                Case "POSLLH"
                    mw_gui.GPS_ms_SVINFO = RealGPSDeltaTime
                Case "SOL"
                    mw_gui.GPS_ms_SOL = RealGPSDeltaTime
                Case "VELNED"
                    mw_gui.GPS_ms_VELNED = RealGPSDeltaTime
            End Select

        Catch ex As Exception

        End Try
    End Sub

End Module
