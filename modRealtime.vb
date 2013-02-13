Module modRealtime
    Public sRefreshSpeeds As String() = {"20 Hz", "10 Hz", "5 Hz", "2 Hz", "1 Hz"}
    Public iRefreshIntervals As Integer() = {50, 100, 200, 500, 1000}
    Public guiDefaultRate As String = "10 Hz"

    Public list_acc_roll As ZedGraph.RollingPointPairList, list_acc_pitch As ZedGraph.RollingPointPairList, list_acc_z As ZedGraph.RollingPointPairList
    Public list_gyro_roll As ZedGraph.RollingPointPairList, list_gyro_pitch As ZedGraph.RollingPointPairList, list_gyro_yaw As ZedGraph.RollingPointPairList
    Public list_mag_roll As ZedGraph.RollingPointPairList, list_mag_pitch As ZedGraph.RollingPointPairList, list_mag_yaw As ZedGraph.RollingPointPairList
    Public list_alt As ZedGraph.RollingPointPairList, list_head As ZedGraph.RollingPointPairList
    Public list_dbg1 As ZedGraph.RollingPointPairList, list_dbg2 As ZedGraph.RollingPointPairList, list_dbg3 As ZedGraph.RollingPointPairList, list_dbg4 As ZedGraph.RollingPointPairList
    Public xScale As ZedGraph.Scale
    Public curve_acc_roll As ZedGraph.LineItem, curve_acc_pitch As ZedGraph.LineItem, curve_acc_z As ZedGraph.LineItem
    Public curve_gyro_roll As ZedGraph.LineItem, curve_gyro_pitch As ZedGraph.LineItem, curve_gyro_yaw As ZedGraph.LineItem
    Public curve_mag_roll As ZedGraph.LineItem, curve_mag_pitch As ZedGraph.LineItem, curve_mag_yaw As ZedGraph.LineItem
    Public curve_alt As ZedGraph.LineItem, curve_head As ZedGraph.LineItem
    Public curve_dbg1 As ZedGraph.LineItem, curve_dbg2 As ZedGraph.LineItem, curve_dbg3 As ZedGraph.LineItem, curve_dbg4 As ZedGraph.LineItem
    Public xTimeStamp As Double = 0


    Public Sub initRealtime()
        For Each rate As String In sRefreshSpeeds
            frmMain.cmbRefreshRate.Items.Add(rate)
        Next
        frmMain.cmbRefreshRate.SelectedItem = guiDefaultRate
        frmMain.timerRealtime.Enabled = True
        frmMain.timerRealtime.Stop()

        'Set up zgMonitor control for real time monitoring
        Dim myPane As ZedGraph.GraphPane = frmMain.zgMonitor.GraphPane

        ' Set the titles and axis labels
        myPane.Title.Text = ""
        myPane.XAxis.Title.Text = ""
        myPane.YAxis.Title.Text = ""

        'Set up pointlists and curves
        list_acc_roll = New ZedGraph.RollingPointPairList(300)
        curve_acc_roll = myPane.AddCurve("acc_roll", list_acc_roll, Color.Red, ZedGraph.SymbolType.None)

        list_acc_pitch = New ZedGraph.RollingPointPairList(300)
        curve_acc_pitch = myPane.AddCurve("acc_pitch", list_acc_pitch, Color.Green, ZedGraph.SymbolType.None)

        list_acc_z = New ZedGraph.RollingPointPairList(300)
        curve_acc_z = myPane.AddCurve("acc_z", list_acc_z, Color.Blue, ZedGraph.SymbolType.None)

        list_gyro_roll = New ZedGraph.RollingPointPairList(300)
        curve_gyro_roll = myPane.AddCurve("gyro_roll", list_gyro_roll, Color.Khaki, ZedGraph.SymbolType.None)

        list_gyro_pitch = New ZedGraph.RollingPointPairList(300)
        curve_gyro_pitch = myPane.AddCurve("gyro_pitch", list_gyro_pitch, Color.Cyan, ZedGraph.SymbolType.None)

        list_gyro_yaw = New ZedGraph.RollingPointPairList(300)
        curve_gyro_yaw = myPane.AddCurve("gyro_yaw", list_gyro_yaw, Color.Magenta, ZedGraph.SymbolType.None)

        list_mag_roll = New ZedGraph.RollingPointPairList(300)
        curve_mag_roll = myPane.AddCurve("mag_roll", list_mag_roll, Color.CadetBlue, ZedGraph.SymbolType.None)

        list_mag_pitch = New ZedGraph.RollingPointPairList(300)
        curve_mag_pitch = myPane.AddCurve("mag_pitch", list_mag_pitch, Color.MediumPurple, ZedGraph.SymbolType.None)

        list_mag_yaw = New ZedGraph.RollingPointPairList(300)
        curve_mag_yaw = myPane.AddCurve("mag_yaw", list_mag_yaw, Color.DarkGoldenrod, ZedGraph.SymbolType.None)

        list_alt = New ZedGraph.RollingPointPairList(300)
        curve_alt = myPane.AddCurve("alt", list_alt, Color.White, ZedGraph.SymbolType.None)

        list_head = New ZedGraph.RollingPointPairList(300)
        curve_head = myPane.AddCurve("head", list_head, Color.Orange, ZedGraph.SymbolType.None)

        list_dbg1 = New ZedGraph.RollingPointPairList(300)
        curve_dbg1 = myPane.AddCurve("dbg1", list_dbg1, Color.PaleTurquoise, ZedGraph.SymbolType.None)

        list_dbg2 = New ZedGraph.RollingPointPairList(300)
        curve_dbg2 = myPane.AddCurve("dbg2", list_dbg2, Color.PaleTurquoise, ZedGraph.SymbolType.None)

        list_dbg3 = New ZedGraph.RollingPointPairList(300)
        curve_dbg3 = myPane.AddCurve("dbg3", list_dbg3, Color.PaleTurquoise, ZedGraph.SymbolType.None)

        list_dbg4 = New ZedGraph.RollingPointPairList(300)
        curve_dbg4 = myPane.AddCurve("dbg4", list_dbg4, Color.PaleTurquoise, ZedGraph.SymbolType.None)

        ' Show the x axis grid
        myPane.XAxis.MajorGrid.IsVisible = True
        myPane.YAxis.MajorGrid.IsVisible = True

        myPane.XAxis.Scale.IsVisible = False

        ' Make the Y axis scale red
        myPane.YAxis.Scale.FontSpec.FontColor = Color.Black
        myPane.YAxis.Title.FontSpec.FontColor = Color.Black
        ' turn off the opposite tics so the Y tics don't show up on the Y2 axis
        myPane.YAxis.MajorTic.IsOpposite = False
        myPane.YAxis.MinorTic.IsOpposite = False
        ' Don't display the Y zero line
        myPane.YAxis.MajorGrid.IsZeroLine = True
        ' Align the Y axis labels so they are flush to the axis
        myPane.YAxis.Scale.Align = ZedGraph.AlignP.Inside
        myPane.YAxis.Scale.IsVisible = False
        ' Manually set the axis range
        myPane.YAxis.Scale.Min = -150
        myPane.YAxis.Scale.Max = 150

        myPane.Chart.Fill = New ZedGraph.Fill(Color.WhiteSmoke, Color.LightGray, 45.0F)
        myPane.Fill = New ZedGraph.Fill(Color.WhiteSmoke, Color.LightGray, 45.0F)
        myPane.Legend.IsVisible = False
        myPane.XAxis.Scale.IsVisible = False
        myPane.YAxis.Scale.IsVisible = True

        myPane.XAxis.Scale.MagAuto = True
        myPane.YAxis.Scale.MagAuto = False

        frmMain.zgMonitor.IsEnableHPan = True
        frmMain.zgMonitor.IsEnableHZoom = True

        For Each li As ZedGraph.LineItem In myPane.CurveList
            li.Line.Width = 1
        Next


        myPane.YAxis.Title.FontSpec.FontColor = Color.White
        myPane.XAxis.Title.FontSpec.FontColor = Color.White

        myPane.XAxis.Scale.Min = 0
        myPane.XAxis.Scale.Max = 300
        myPane.XAxis.Type = ZedGraph.AxisType.Linear



        frmMain.zgMonitor.ScrollGrace = 0
        xScale = frmMain.zgMonitor.GraphPane.XAxis.Scale
        frmMain.zgMonitor.AxisChange()

    End Sub

    Public Sub askForRealtimeValues()
        MSPquery(MSP_RC)
        'readCOM()
        MSPquery(MSP_STATUS)
        'readCOM()
        MSPquery(MSP_RAW_IMU)
        'readCOM()
        MSPquery(MSP_SERVO)
        'readCOM()
        MSPquery(MSP_MOTOR)
        'readCOM()
        MSPquery(MSP_ALTITUDE)
        'readCOM()
        MSPquery(MSP_BAT)
        'readCOM()
        MSPquery(MSP_MISC)
        'readCOM()
        MSPquery(MSP_DEBUG)
        'readCOM()
        MSPquery(MSP_TEMP)
        'readCOM()
        MSPquery(MSP_SONAR)
        'readCOM()
        MSPquery(MSP_RC)
        'readCOM()
        MSPquery(MSP_ATTITUDE)
        'readCOM()
        MSPquery(MSP_COMP_GPS)
        'readCOM()
        MSPquery(MSP_RAW_GPS)
        'readCOM()
    End Sub

    Public Sub updateTPRealtime()

        If frmMain.chk_acc_roll.Checked Then
            list_acc_roll.Add(CDbl(xTimeStamp), mw_gui.ax)
        End If
        frmMain.lblVacc_roll.Text = "" & mw_gui.ax

        If frmMain.chk_acc_pitch.Checked Then
            list_acc_pitch.Add(CDbl(xTimeStamp), mw_gui.ay)
        End If
        frmMain.lblVacc_pitch.Text = "" & mw_gui.ay

        If frmMain.chk_acc_z.Checked Then
            list_acc_z.Add(CDbl(xTimeStamp), mw_gui.az)
        End If
        frmMain.lblVacc_z.Text = "" & mw_gui.az

        If frmMain.chk_gyro_roll.Checked Then
            list_gyro_roll.Add(CDbl(xTimeStamp), mw_gui.gx)
        End If
        frmMain.lblVgyro_roll.Text = "" & mw_gui.gx

        If frmMain.chk_gyro_pitch.Checked Then
            list_gyro_pitch.Add(CDbl(xTimeStamp), mw_gui.gy)
        End If
        frmMain.lblVgyro_pitch.Text = "" & mw_gui.gy

        If frmMain.chk_gyro_yaw.Checked Then
            list_gyro_yaw.Add(CDbl(xTimeStamp), mw_gui.gz)
        End If
        frmMain.lblVgyro_yaw.Text = "" & mw_gui.gz

        If frmMain.chk_mag_roll.Checked Then
            list_mag_roll.Add(CDbl(xTimeStamp), mw_gui.magx)
        End If
        frmMain.lblVmag_roll.Text = "" & mw_gui.magx

        If frmMain.chk_mag_pitch.Checked Then
            list_mag_pitch.Add(CDbl(xTimeStamp), mw_gui.magy)
        End If
        frmMain.lblVmag_pitch.Text = "" & mw_gui.magy

        If frmMain.chk_mag_yaw.Checked Then
            list_mag_yaw.Add(CDbl(xTimeStamp), mw_gui.magz)
        End If
        frmMain.lblVmag_yaw.Text = "" & mw_gui.magz

        If frmMain.chk_alt.Checked Then
            list_alt.Add(CDbl(xTimeStamp), CDbl(mw_gui.baro) / 100.0F)
        End If
        frmMain.lblValt.Text = "" & CDbl(mw_gui.baro) / 100

        If frmMain.chk_head.Checked Then
            list_head.Add(CDbl(xTimeStamp), mw_gui.heading)
        End If
        frmMain.lblVhead.Text = "" & mw_gui.heading

        If frmMain.chk_dbg1.Checked Then
            list_dbg1.Add(CDbl(xTimeStamp), mw_gui.debug1)
        End If
        frmMain.lblVdbg1.Text = "" & mw_gui.debug1

        If frmMain.chk_dbg2.Checked Then
            list_dbg2.Add(CDbl(xTimeStamp), mw_gui.debug2)
        End If
        frmMain.lblVdbg2.Text = "" & mw_gui.debug2

        If frmMain.chk_dbg3.Checked Then
            list_dbg3.Add(CDbl(xTimeStamp), mw_gui.debug3)
        End If
        frmMain.lblVdbg3.Text = "" & mw_gui.debug3

        If frmMain.chk_dbg4.Checked Then
            list_dbg4.Add(CDbl(xTimeStamp), mw_gui.debug4)
        End If
        frmMain.lblVdbg4.Text = "" & mw_gui.debug4


        xTimeStamp = xTimeStamp + 1

        If xTimeStamp > xScale.Max Then
            Dim range As Double = xScale.Max - xScale.Min
            xScale.Max = xScale.Max + 1
            xScale.Min = xScale.Max - range
        End If
        frmMain.zgMonitor.AxisChange()
        frmMain.zgMonitor.Invalidate()

        curve_acc_roll.IsVisible = frmMain.chk_acc_roll.Checked
        curve_acc_pitch.IsVisible = frmMain.chk_acc_pitch.Checked
        curve_acc_z.IsVisible = frmMain.chk_acc_z.Checked
        curve_gyro_roll.IsVisible = frmMain.chk_gyro_roll.Checked
        curve_gyro_pitch.IsVisible = frmMain.chk_gyro_pitch.Checked
        curve_gyro_yaw.IsVisible = frmMain.chk_gyro_yaw.Checked
        curve_mag_roll.IsVisible = frmMain.chk_mag_roll.Checked
        curve_mag_pitch.IsVisible = frmMain.chk_mag_pitch.Checked
        curve_mag_yaw.IsVisible = frmMain.chk_mag_yaw.Checked
        curve_alt.IsVisible = frmMain.chk_alt.Checked
        curve_head.IsVisible = frmMain.chk_head.Checked

        'motorsIndicator1.SetMotorsIndicatorParameters(mw_gui.motors, mw_gui.servos, mw_gui.multiType)

        'update indicator lamps

        ''indNUNCHUK.SetStatus((mw_gui.present & 1) != 0);
        'indACC.SetStatus((mw_gui.present And 1) <> 0)
        'indBARO.SetStatus((mw_gui.present And 2) <> 0)
        'indMAG.SetStatus((mw_gui.present And 4) <> 0)
        'indGPS.SetStatus((mw_gui.present And 8) <> 0)
        'indSONAR.SetStatus((mw_gui.present And 16) <> 0)

        'For i As Integer = 0 To iCheckBoxItems - 1
        '    If (mw_gui.mode And (1 << i)) > 0 Then
        '        indicators(i).SetStatus(True)
        '    Else
        '        indicators(i).SetStatus(False)
        '    End If
        'Next

        frmMain.lblV_cycletime.Text = [String].Format("{0:0000} µs", mw_gui.cycleTime)
        frmMain.l_vbatt.Text = [String].Format("{0:0.0} volts", CDbl(mw_gui.vBat) / 10)
        frmMain.l_powersum.Text = [String].Format("{0:0}", mw_gui.pMeterSum)

        frmMain.lblV_i2cerrors.Text = [String].Format("{0:0}", mw_gui.i2cErrors)

        frmMain.l_Temp.Text = [String].Format("{0:0.0} C°", CDbl(mw_gui.Temp))
        frmMain.l_Sonar.Text = [String].Format("{0:0} cm", CDbl(mw_gui.Sonar))

        updateRealtimeChannels()

        frmMain.ctrlHEADING.SetHeadingIndicatorParameters(mw_gui.heading)
        frmMain.ctrlHORIZON.SetArtificalHorizon(-mw_gui.angy, -mw_gui.angx)

        frmMain.ctrlGPS.SetGPSIndicatorParameters(mw_gui.GPS_directionToHome, mw_gui.GPS_distanceToHome, mw_gui.GPS_numSat, Convert.ToBoolean(mw_gui.GPS_fix), True, Convert.ToBoolean(mw_gui.GPS_update))

    End Sub


End Module
