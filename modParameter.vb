Module modParameter

    Public Sub updateParameter()
        frmMain.numRoll_P.Value = mw_params.pidP(PIDRoll) / 10
        frmMain.numRoll_I.Value = mw_params.pidI(PIDRoll) / 1000
        frmMain.numRoll_D.Value = mw_params.pidD(PIDRoll)
        frmMain.numPitch_P.Value = mw_params.pidP(PIDPitch) / 10
        frmMain.numPitch_I.Value = mw_params.pidI(PIDPitch) / 1000
        frmMain.numPitch_D.Value = mw_params.pidD(PIDPitch)
        frmMain.numYaw_P.Value = mw_params.pidP(PIDYaw) / 10
        frmMain.numYaw_I.Value = mw_params.pidI(PIDYaw) / 1000
        frmMain.numYaw_D.Value = mw_params.pidD(PIDYaw)
        frmMain.numAltitude_P.Value = mw_params.pidP(PIDAltitude) / 10
        frmMain.numAltitude_I.Value = mw_params.pidI(PIDAltitude) / 1000
        frmMain.numAltitude_D.Value = mw_params.pidD(PIDAltitude)
        frmMain.numPosHold_P.Value = mw_params.pidP(PIDPosHold) / 100
        frmMain.numPosHold_I.Value = mw_params.pidI(PIDPosHold) / 100 'Obwohl nur eine Kommastelle?!?!
        ' frmMain.numPosHold_D.Value = mw_params.pidD(PIDPosHold) / 1000
        frmMain.numPosHoldRate_P.Value = mw_params.pidP(PIDPosHoldRate) / 10
        frmMain.numPosHoldRate_I.Value = mw_params.pidI(PIDPosHoldRate) / 100
        frmMain.numPosHoldRate_D.Value = mw_params.pidD(PIDPosHoldRate) / 1000
        frmMain.numNavigationRate_P.Value = mw_params.pidP(PIDNavigationRate) / 10
        frmMain.numNavigationRate_I.Value = mw_params.pidI(PIDNavigationRate) / 100
        frmMain.numNavigationRate_D.Value = mw_params.pidD(PIDNavigationRate) / 1000
        frmMain.numLevel_P.Value = mw_params.pidP(PIDLevel) / 10
        frmMain.numLevel_I.Value = mw_params.pidI(PIDLevel) / 1000
        frmMain.numLevel_D.Value = mw_params.pidD(PIDLevel)
        frmMain.numMag_P.Value = mw_params.pidP(PIDMag) / 10
        ' frmMain.numMag_I.Value = mw_params.pidI(PIDMag)
        ' frmMain.numMag_D.Value = mw_params.pidD(PIDMag)
        frmMain.numVelocity_I.Value = mw_params.pidP(PIDVelocity) / 10
        frmMain.numVelocity_I.Value = mw_params.pidI(PIDVelocity) / 100
        frmMain.numVelocity_D.Value = mw_params.pidD(PIDVelocity)

        frmMain.numRCExpo.Value = mw_params.rcExpo / 100
        frmMain.numRCRate.Value = mw_params.rcRate / 100
        frmMain.numTMID.Value = mw_params.ThrottleMID / 100
        frmMain.numTEXPO.Value = mw_params.ThrottleEXPO / 100

        frmMain.numRATE_rp.Value = mw_params.RollPitchRate / 100
        frmMain.numRATE_yaw.Value = mw_params.YawRate / 100
        frmMain.numRATE_tpid.Value = mw_params.DynThrPID / 100

        frmMain.numPowerMeterAlarm.Value = mw_params.PowerTrigger
        frmMain.txtComment.Text = mw_params.comment
        frmMain.lblVFirmware.Text = mw_gui.firmware
        frmMain.lblVPacketReceived.Text = serial_packet_count
        frmMain.lblVPacketError.Text = serial_error_count
        Application.DoEvents()
    End Sub

    Public Sub fillParameter2GUI()
        frmMain.numRoll_P.Value = mw_params.pidP(PIDRoll) / 10
        frmMain.numRoll_I.Value = mw_params.pidI(PIDRoll) / 1000
        frmMain.numRoll_D.Value = mw_params.pidD(PIDRoll)
        frmMain.numPitch_P.Value = mw_params.pidP(PIDPitch) / 10
        frmMain.numPitch_I.Value = mw_params.pidI(PIDPitch) / 1000
        frmMain.numPitch_D.Value = mw_params.pidD(PIDPitch)
        frmMain.numYaw_P.Value = mw_params.pidP(PIDYaw) / 10
        frmMain.numYaw_I.Value = mw_params.pidI(PIDYaw) / 1000
        frmMain.numYaw_D.Value = mw_params.pidD(PIDYaw)
        frmMain.numAltitude_P.Value = mw_params.pidP(PIDAltitude) / 10
        frmMain.numAltitude_I.Value = mw_params.pidI(PIDAltitude) / 1000
        frmMain.numAltitude_D.Value = mw_params.pidD(PIDAltitude)
        frmMain.numPosHold_P.Value = mw_params.pidP(PIDPosHold) / 100
        frmMain.numPosHold_I.Value = mw_params.pidI(PIDPosHold) / 100 'obwohl nur eine Kommastelle !?!?!
        ' frmMain.numPosHold_D.Value = mw_params.pidD(PIDPosHold)
        frmMain.numPosHoldRate_P.Value = mw_params.pidP(PIDPosHoldRate) / 10
        frmMain.numPosHoldRate_I.Value = mw_params.pidI(PIDPosHoldRate) / 100
        frmMain.numPosHoldRate_D.Value = mw_params.pidD(PIDPosHoldRate) / 1000
        frmMain.numNavigationRate_P.Value = mw_params.pidP(PIDNavigationRate) / 10
        frmMain.numNavigationRate_I.Value = mw_params.pidI(PIDNavigationRate) / 100
        frmMain.numNavigationRate_D.Value = mw_params.pidD(PIDNavigationRate) / 1000
        frmMain.numLevel_P.Value = mw_params.pidP(PIDLevel) / 10
        frmMain.numLevel_I.Value = mw_params.pidI(PIDLevel) / 1000
        frmMain.numLevel_D.Value = mw_params.pidD(PIDLevel)
        frmMain.numMag_P.Value = mw_params.pidP(PIDMag) / 10
        ' frmMain.numMag_I.Value = mw_params.pidI(PIDMag)
        ' frmMain.numMag_D.Value = mw_params.pidD(PIDMag)
        frmMain.numVelocity_I.Value = mw_params.pidP(PIDVelocity) / 10
        frmMain.numVelocity_I.Value = mw_params.pidI(PIDVelocity) / 1000
        frmMain.numVelocity_D.Value = mw_params.pidD(PIDVelocity)

        frmMain.numRCExpo.Value = mw_params.rcExpo / 100
        frmMain.numRCRate.Value = mw_params.rcRate / 100
        frmMain.numTMID.Value = mw_params.ThrottleMID / 100
        frmMain.numTEXPO.Value = mw_params.ThrottleEXPO / 100

        frmMain.numRATE_rp.Value = mw_params.RollPitchRate / 100
        frmMain.numRATE_yaw.Value = mw_params.YawRate / 100
        frmMain.numRATE_tpid.Value = mw_params.DynThrPID / 100

        frmMain.numPowerMeterAlarm.Value = mw_params.PowerTrigger
        frmMain.txtComment.Text = mw_params.comment

        set_aux_panel()
    End Sub

    Public Sub fillGUI2Parameter()
        'Get parameters from GUI
        mw_params.pidP(PIDRoll) = frmMain.numRoll_P.Value * 10
        mw_params.pidI(PIDRoll) = frmMain.numRoll_I.Value * 1000
        mw_params.pidD(PIDRoll) = frmMain.numRoll_D.Value
        mw_params.pidP(PIDPitch) = frmMain.numPitch_P.Value * 10
        mw_params.pidI(PIDPitch) = frmMain.numPitch_I.Value * 1000
        mw_params.pidD(PIDPitch) = frmMain.numPitch_D.Value
        mw_params.pidP(PIDYaw) = frmMain.numYaw_P.Value * 10
        mw_params.pidI(PIDYaw) = frmMain.numYaw_I.Value * 1000
        mw_params.pidD(PIDYaw) = frmMain.numYaw_D.Value
        mw_params.pidP(PIDAltitude) = frmMain.numAltitude_P.Value * 10
        mw_params.pidI(PIDAltitude) = frmMain.numAltitude_I.Value * 1000
        mw_params.pidD(PIDAltitude) = frmMain.numAltitude_D.Value
        mw_params.pidP(PIDPosHold) = frmMain.numPosHold_P.Value * 100
        mw_params.pidI(PIDPosHold) = frmMain.numPosHold_I.Value * 100 'Obwohl nur eine Kommastelle!?!?!?!
        'mw_params.pidD(PIDPosHold) = frmMain.numPosHold_D.Value 
        mw_params.pidP(PIDPosHoldRate) = frmMain.numPosHoldRate_P.Value * 10
        mw_params.pidI(PIDPosHoldRate) = frmMain.numPosHoldRate_I.Value * 100
        mw_params.pidD(PIDPosHoldRate) = frmMain.numPosHoldRate_D.Value * 1000
        mw_params.pidP(PIDNavigationRate) = frmMain.numNavigationRate_P.Value * 10
        mw_params.pidI(PIDNavigationRate) = frmMain.numNavigationRate_I.Value * 100
        mw_params.pidD(PIDNavigationRate) = frmMain.numNavigationRate_D.Value * 1000
        mw_params.pidP(PIDLevel) = frmMain.numLevel_P.Value * 10
        mw_params.pidI(PIDLevel) = frmMain.numLevel_I.Value * 1000
        mw_params.pidD(PIDLevel) = frmMain.numLevel_D.Value
        mw_params.pidP(PIDMag) = frmMain.numMag_P.Value * 10
        'mw_params.pidI(PIDMag) = frmMain.numMag_I.Value 
        'mw_params.pidD(PIDMag) = frmMain.numMag_D.Value 
        mw_params.pidP(PIDVelocity) = frmMain.numVelocity_I.Value * 10
        mw_params.pidI(PIDVelocity) = frmMain.numVelocity_I.Value * 1000
        mw_params.pidD(PIDVelocity) = frmMain.numVelocity_D.Value

        mw_params.rcExpo = CByte(frmMain.numRCExpo.Value * 100)
        mw_params.rcRate = CByte(frmMain.numRCRate.Value * 100)
        mw_params.ThrottleMID = CByte(frmMain.numTMID.Value * 100)
        mw_params.ThrottleEXPO = CByte(frmMain.numTEXPO.Value * 100)

        mw_params.RollPitchRate = CByte(frmMain.numRATE_rp.Value * 100)
        mw_params.YawRate = CByte(frmMain.numRATE_yaw.Value * 100)
        mw_params.DynThrPID = CByte(frmMain.numRATE_tpid.Value * 100)

        mw_params.PowerTrigger = CInt(frmMain.numPowerMeterAlarm.Value)
        mw_params.comment = frmMain.txtComment.Text

        read_aux_panel()
    End Sub

    Public Sub RCExpo_Scroll()
        frmMain.numRCExpo.Value = CDec(frmMain.trbRCExpo.Value) / 100
        frmMain.Rc_expo_control1.SetRCExpoParameters(CDbl(frmMain.numRCRate.Value), CDbl(frmMain.numRCExpo.Value))
    End Sub

    Public Sub RCRate_Scroll()
        frmMain.numRCRate.Value = CDec(frmMain.trbRCRate.Value) / 100
        frmMain.Rc_expo_control1.SetRCExpoParameters(CDbl(frmMain.numRCRate.Value), CDbl(frmMain.numRCExpo.Value))
    End Sub

    Public Sub RCExpo_ValueChanged()
        frmMain.trbRCExpo.Value = CInt(frmMain.numRCExpo.Value * 100)
        frmMain.Rc_expo_control1.SetRCExpoParameters(CDbl(frmMain.numRCRate.Value), CDbl(frmMain.numRCExpo.Value))
        If CInt(frmMain.numRCExpo.Value * 100) <> mw_params.rcExpo Then
            frmMain.numRCExpo.BackColor = Color.LightGray
        Else
            frmMain.numRCExpo.BackColor = Color.White
        End If
    End Sub

    Public Sub RCRate_ValueChanged()
        frmMain.trbRCRate.Value = CInt(frmMain.numRCRate.Value * 100)
        frmMain.Rc_expo_control1.SetRCExpoParameters(CDbl(frmMain.numRCRate.Value), CDbl(frmMain.numRCExpo.Value))
        If CInt(frmMain.numRCRate.Value * 100) <> mw_params.rcRate Then
            frmMain.numRCRate.BackColor = Color.LightGray
        Else
            frmMain.numRCRate.BackColor = Color.White
        End If
    End Sub

    Public Sub TMID_Scroll()
        frmMain.numTMID.Value = CDec(frmMain.trbTMID.Value) / 100
        frmMain.Throttle_expo_control1.SetRCExpoParameters(CDbl(frmMain.numTMID.Value), CDbl(frmMain.numTEXPO.Value), mw_gui.rcThrottle)
    End Sub

    Public Sub TEXPO_Scroll()
        frmMain.numTEXPO.Value = CDec(frmMain.trbTEXPO.Value) / 100
        frmMain.Throttle_expo_control1.SetRCExpoParameters(CDbl(frmMain.numTMID.Value), CDbl(frmMain.numTEXPO.Value), mw_gui.rcThrottle)
    End Sub

    Public Sub TMID_ValueChanged()
        frmMain.trbTMID.Value = CInt(frmMain.numTMID.Value * 100)
        frmMain.Throttle_expo_control1.SetRCExpoParameters(CDbl(frmMain.numTMID.Value), CDbl(frmMain.numTEXPO.Value), mw_gui.rcThrottle)
        If CInt(frmMain.numTMID.Value * 100) <> mw_params.ThrottleMID Then
            frmMain.numTMID.BackColor = Color.LightGray
        Else
            frmMain.numTMID.BackColor = Color.White
        End If
    End Sub

    Public Sub TEXPO_ValueChanged()
        frmMain.trbTEXPO.Value = CInt(frmMain.numTEXPO.Value * 100)
        frmMain.Throttle_expo_control1.SetRCExpoParameters(CDbl(frmMain.numTMID.Value), CDbl(frmMain.numTEXPO.Value), mw_gui.rcThrottle)
        If CInt(frmMain.numTEXPO.Value * 100) <> mw_params.ThrottleEXPO Then
            frmMain.numTEXPO.BackColor = Color.LightGray
        Else
            frmMain.numTEXPO.BackColor = Color.White
        End If
    End Sub

End Module
