Module modLanguage
    Enum HelpType
        cliSet = 1
        cliFeature = 2
        cliMixer = 3
    End Enum

    Public Language As String = "DE"
    Public isNewOnlineItem As Boolean = False

    Friend lngError As String = "Error"
    Friend lngTimeOut As String = "The Flight Control didn't answer for more than {sec} seconds"



    Public Sub readToolTip()
        readTTipParameter()
        If isNewOnlineItem = True Then
            saveOnlineHelp()
            isNewOnlineItem = False
        End If
    End Sub

    Public Sub readTTipParameter()
        frmMain.ttMain.IsBalloon = True
        frmMain.ttMain.SetToolTip(frmMain.numRoll_P, getToolTip("p_roll"))
        frmMain.ttMain.SetToolTip(frmMain.numRoll_I, getToolTip("i_roll"))
        frmMain.ttMain.SetToolTip(frmMain.numRoll_D, getToolTip("d_roll"))
        frmMain.ttMain.SetToolTip(frmMain.numPitch_P, getToolTip("p_Pitch"))
        frmMain.ttMain.SetToolTip(frmMain.numPitch_I, getToolTip("i_Pitch"))
        frmMain.ttMain.SetToolTip(frmMain.numPitch_D, getToolTip("d_Pitch"))
        frmMain.ttMain.SetToolTip(frmMain.numYaw_P, getToolTip("p_Yaw"))
        frmMain.ttMain.SetToolTip(frmMain.numYaw_I, getToolTip("i_Yaw"))
        frmMain.ttMain.SetToolTip(frmMain.numYaw_D, getToolTip("d_Yaw"))
        frmMain.ttMain.SetToolTip(frmMain.numAltitude_P, getToolTip("p_Alt"))
        frmMain.ttMain.SetToolTip(frmMain.numAltitude_I, getToolTip("i_Alt"))
        frmMain.ttMain.SetToolTip(frmMain.numAltitude_D, getToolTip("d_Alt"))
        frmMain.ttMain.SetToolTip(frmMain.numPosHold_P, getToolTip("gps_pos_p"))
        frmMain.ttMain.SetToolTip(frmMain.numPosHold_I, getToolTip("gps_pos_i"))
        'frmMain.ttMain.SetToolTip(frmMain.numPosHold_D, geToolTip("gps_pos_d")) <- wird nicht benötigt ist aber in der Struktur vorgesehen
        frmMain.ttMain.SetToolTip(frmMain.numPosHoldRate_P, getToolTip("gps_posr_p"))
        frmMain.ttMain.SetToolTip(frmMain.numPosHoldRate_I, getToolTip("gps_posr_i"))
        frmMain.ttMain.SetToolTip(frmMain.numPosHoldRate_D, getToolTip("gps_posr_d"))
        frmMain.ttMain.SetToolTip(frmMain.numNavigationRate_P, getToolTip("gps_nav_p"))
        frmMain.ttMain.SetToolTip(frmMain.numNavigationRate_I, getToolTip("gps_nav_i"))
        frmMain.ttMain.SetToolTip(frmMain.numNavigationRate_D, getToolTip("gps_nav_d"))
        frmMain.ttMain.SetToolTip(frmMain.numLevel_P, getToolTip("p_Level"))
        frmMain.ttMain.SetToolTip(frmMain.numLevel_I, getToolTip("i_Level"))
        frmMain.ttMain.SetToolTip(frmMain.numLevel_D, getToolTip("d_Level"))
        frmMain.ttMain.SetToolTip(frmMain.numMag_P, getToolTip("p_mag"))
        frmMain.ttMain.SetToolTip(frmMain.numVelocity_P, getToolTip("p_velocity"))
        frmMain.ttMain.SetToolTip(frmMain.numVelocity_I, getToolTip("i_velocity"))
        frmMain.ttMain.SetToolTip(frmMain.numVelocity_D, getToolTip("d_velocity"))
        frmMain.ttMain.SetToolTip(frmMain.numRCExpo, getToolTip("rc_expo"))
        frmMain.ttMain.SetToolTip(frmMain.numRCRate, getToolTip("rc_rate"))
        frmMain.ttMain.SetToolTip(frmMain.numTMID, getToolTip("thr_mid"))
        frmMain.ttMain.SetToolTip(frmMain.numTEXPO, getToolTip("thr_expo"))
        frmMain.ttMain.SetToolTip(frmMain.numRATE_rp, getToolTip("roll_pitch_rate"))
        frmMain.ttMain.SetToolTip(frmMain.numRATE_yaw, getToolTip("yawrate"))
        'frmMain.ttMain.SetToolTip(frmMain.numRATE_tpid, geToolTip("Throttle PID attenuation"))
        'frmMain.ttMain.SetToolTip(frmMain.numPowerMeterAlarm, geToolTip("Power Meter Alarm"))
        'frmMain.ttMain.SetToolTip(frmMain.txtComment, geToolTip("Comment"))
    End Sub

    Public Sub readTTipBoxes()
        'frmMain.ttMain.SetToolTip(frmMain.numRoll_P, geToolTip("Roll_P"))

    End Sub

    Private Function getToolTip(ByRef Item As String) As String
        Dim result As String = ""
        result = getDescription(Item, HelpType.cliSet)
        Return result
    End Function

    Public Function getDescription(ByRef Item As String, ByVal Type As HelpType) As String
        Dim result As String = ""
        result = _getDescription(Item, Type, Language)
        If result = "" Then
            result = _getDescription(Item, Type, "US")
        End If
        Return result
    End Function

    Private Function _getDescription(ByRef Item As String, ByVal Type As HelpType, ByVal _language As String) As String
        Dim result As String = ""
        Dim dr() As DataRow = dtOnlineHelp.Select("Item like '" & Item & "' and Type = " & Type & " and Language = '" & _language & "'")
        If dr.Length = 0 Then
            addEmptyRow(Item, Type, _language)
            isNewOnlineItem = True
        Else
            Try
                result = dr(0)("Description").ToString.Replace("<BR>", Environment.NewLine)
            Catch ex As Exception
                dr(0)("Description") = ""
            End Try
        End If
        Return result
    End Function

End Module
