Module modParameter

    Public Sub fillParameter2GUI()
        frmMain.numRoll_P.Value = mw_gui.pidP(PIDRoll) / 10
        frmMain.numRoll_I.Value = mw_gui.pidI(PIDRoll) / 1000
        frmMain.numRoll_D.Value = mw_gui.pidD(PIDRoll)
        frmMain.numPitch_P.Value = mw_gui.pidP(PIDPitch) / 10
        frmMain.numPitch_I.Value = mw_gui.pidI(PIDPitch) / 1000
        frmMain.numPitch_D.Value = mw_gui.pidD(PIDPitch)
        frmMain.numYaw_P.Value = mw_gui.pidP(PIDYaw) / 10
        frmMain.numYaw_I.Value = mw_gui.pidI(PIDYaw) / 1000
        frmMain.numYaw_D.Value = mw_gui.pidD(PIDYaw)
        frmMain.numAltitude_P.Value = mw_gui.pidP(PIDAltitude) / 10
        frmMain.numAltitude_I.Value = mw_gui.pidI(PIDAltitude) / 1000
        frmMain.numAltitude_D.Value = mw_gui.pidD(PIDAltitude)
        frmMain.numPosHold_P.Value = mw_gui.pidP(PIDPosHold) / 10
        frmMain.numPosHold_I.Value = mw_gui.pidI(PIDPosHold) / 1000
        ' frmMain.numPosHold_D.Value = mw_gui.pidD(PIDPosHold)
        frmMain.numPosHoldRate_P.Value = mw_gui.pidP(PIDPosHoldRate) / 10
        frmMain.numPosHoldRate_I.Value = mw_gui.pidI(PIDPosHoldRate) / 100
        frmMain.numPosHoldRate_D.Value = mw_gui.pidD(PIDPosHoldRate) / 1000
        frmMain.numNavigationRate_P.Value = mw_gui.pidP(PIDNavigationRate) / 10
        frmMain.numNavigationRate_I.Value = mw_gui.pidI(PIDNavigationRate) / 100
        frmMain.numNavigationRate_D.Value = mw_gui.pidD(PIDNavigationRate) / 1000
        frmMain.numLevel_P.Value = mw_gui.pidP(PIDLevel) / 10
        frmMain.numLevel_I.Value = mw_gui.pidI(PIDLevel) / 100
        frmMain.numLevel_D.Value = mw_gui.pidD(PIDLevel)
        frmMain.numMag_P.Value = mw_gui.pidP(PIDMag) / 10
        ' frmMain.numMag_I.Value = mw_gui.pidI(PIDMag)
        ' frmMain.numMag_D.Value = mw_gui.pidD(PIDMag)
        frmMain.numVelocity_I.Value = mw_gui.pidP(PIDVelocity) / 10
        frmMain.numVelocity_I.Value = mw_gui.pidI(PIDVelocity) / 100
        frmMain.numVelocity_D.Value = mw_gui.pidD(PIDVelocity)

        frmMain.numRCExpo.Value = mw_gui.rcExpo / 100
        frmMain.numRCRate.Value = mw_gui.rcRate / 100
        frmMain.numTMID.Value = mw_gui.ThrottleMID / 100
        frmMain.numTEXPO.Value = mw_gui.ThrottleEXPO / 100

        frmMain.numRATE_rp.Value = mw_gui.RollPitchRate / 100
        frmMain.numRATE_yaw.Value = mw_gui.YawRate / 100
        frmMain.numRATE_tpid.Value = mw_gui.DynThrPID / 100

        frmMain.numPowerMeterAlarm.Value = mw_params.PowerTrigger
        frmMain.txtComment.Text = mw_params.comment

        set_aux_panel()
    End Sub

    Public Sub fillGUI2Parameter()
        'Get parameters from GUI
        mw_gui.pidP(PIDRoll) = frmMain.numRoll_P.Value * 10
        mw_gui.pidI(PIDRoll) = frmMain.numRoll_I.Value * 1000
        mw_gui.pidD(PIDRoll) = frmMain.numRoll_D.Value
        mw_gui.pidP(PIDPitch) = frmMain.numPitch_P.Value * 10
        mw_gui.pidI(PIDPitch) = frmMain.numPitch_I.Value * 1000
        mw_gui.pidD(PIDPitch) = frmMain.numPitch_D.Value
        mw_gui.pidP(PIDYaw) = frmMain.numYaw_P.Value * 10
        mw_gui.pidI(PIDYaw) = frmMain.numYaw_I.Value * 1000
        mw_gui.pidD(PIDYaw) = frmMain.numYaw_D.Value
        mw_gui.pidP(PIDAltitude) = frmMain.numAltitude_P.Value * 10
        mw_gui.pidI(PIDAltitude) = frmMain.numAltitude_I.Value * 1000
        mw_gui.pidD(PIDAltitude) = frmMain.numAltitude_D.Value
        mw_gui.pidP(PIDPosHold) = frmMain.numPosHold_P.Value * 10
        mw_gui.pidI(PIDPosHold) = frmMain.numPosHold_I.Value * 1000
        'mw_gui.pidD(PIDPosHold) = frmMain.numPosHold_D.Value 
        mw_gui.pidP(PIDPosHoldRate) = frmMain.numPosHoldRate_P.Value * 10
        mw_gui.pidI(PIDPosHoldRate) = frmMain.numPosHoldRate_I.Value * 100
        mw_gui.pidD(PIDPosHoldRate) = frmMain.numPosHoldRate_D.Value * 1000
        mw_gui.pidP(PIDNavigationRate) = frmMain.numNavigationRate_P.Value * 10
        mw_gui.pidI(PIDNavigationRate) = frmMain.numNavigationRate_I.Value * 100
        mw_gui.pidD(PIDNavigationRate) = frmMain.numNavigationRate_D.Value * 1000
        mw_gui.pidP(PIDLevel) = frmMain.numLevel_P.Value * 10
        mw_gui.pidI(PIDLevel) = frmMain.numLevel_I.Value * 100
        mw_gui.pidD(PIDLevel) = frmMain.numLevel_D.Value
        mw_gui.pidP(PIDMag) = frmMain.numMag_P.Value * 10
        'mw_gui.pidI(PIDMag) = frmMain.numMag_I.Value 
        'mw_gui.pidD(PIDMag) = frmMain.numMag_D.Value 
        mw_gui.pidP(PIDVelocity) = frmMain.numVelocity_I.Value * 10
        mw_gui.pidI(PIDVelocity) = frmMain.numVelocity_I.Value * 100
        mw_gui.pidD(PIDVelocity) = frmMain.numVelocity_D.Value

        For i = 0 To iPidItems - 1
            mw_params.pidP(i) = mw_gui.pidP(i)
            mw_params.pidI(i) = mw_gui.pidI(i)
            mw_params.pidD(i) = mw_gui.pidD(i)
        Next

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
        frmMain.numRCExpo.Value = CDec(frmMain.tbrRCExpo.Value) / 100
        frmMain.Rc_expo_control1.SetRCExpoParameters(CDbl(frmMain.numRCRate.Value), CDbl(frmMain.numRCExpo.Value))
    End Sub

    Public Sub RCRate_Scroll()
        frmMain.numRCRate.Value = CDec(frmMain.trbRCRate.Value) / 100
        frmMain.Rc_expo_control1.SetRCExpoParameters(CDbl(frmMain.numRCRate.Value), CDbl(frmMain.numRCExpo.Value))
    End Sub

    Public Sub RCExpo_ValueChanged()
        frmMain.tbrRCExpo.Value = CInt(frmMain.numRCExpo.Value * 100)
        frmMain.Rc_expo_control1.SetRCExpoParameters(CDbl(frmMain.numRCRate.Value), CDbl(frmMain.numRCExpo.Value))
        If CInt(frmMain.numRCExpo.Value * 100) <> mw_gui.rcExpo Then
            frmMain.numRCExpo.BackColor = Color.LightGray
        Else
            frmMain.numRCExpo.BackColor = Color.White
        End If
    End Sub

    Public Sub RCRate_ValueChanged()
        frmMain.trbRCRate.Value = CInt(frmMain.numRCRate.Value * 100)
        frmMain.Rc_expo_control1.SetRCExpoParameters(CDbl(frmMain.numRCRate.Value), CDbl(frmMain.numRCExpo.Value))
        If CInt(frmMain.numRCRate.Value * 100) <> mw_gui.rcRate Then
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
        If CInt(frmMain.numTMID.Value * 100) <> mw_gui.ThrottleMID Then
            frmMain.numTMID.BackColor = Color.LightGray
        Else
            frmMain.numTMID.BackColor = Color.White
        End If
    End Sub

    Public Sub TEXPO_ValueChanged()
        frmMain.trbTEXPO.Value = CInt(frmMain.numTEXPO.Value * 100)
        frmMain.Throttle_expo_control1.SetRCExpoParameters(CDbl(frmMain.numTMID.Value), CDbl(frmMain.numTEXPO.Value), mw_gui.rcThrottle)
        If CInt(frmMain.numTEXPO.Value * 100) <> mw_gui.ThrottleEXPO Then
            frmMain.numTEXPO.BackColor = Color.LightGray
        Else
            frmMain.numTEXPO.BackColor = Color.White
        End If
    End Sub

End Module
