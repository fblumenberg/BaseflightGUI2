Module modAUXCHANNEL
    Public pgbAUXChannel As ProgressBarCtrl()
    Public lblAUXChannelName As System.Windows.Forms.Label()
    Public lblAUXChannelValue As System.Windows.Forms.Label()
    Public pgbRealtimeChannel As ProgressBarCtrl()
    Public lblRealtimeChannelName As System.Windows.Forms.Label()
    Public lblRealtimeChannelValue As System.Windows.Forms.Label()

    Public Sub initAUXChannel()
        Dim rowspace As Integer = 20
        Dim row As Integer = 0
        Dim col As Integer = 0
        Dim startx As Integer = 10
        Dim starty As Integer = 10
        pgbAUXChannel = New ProgressBarCtrl(AUX_CHANNELS + 3) {}
        lblAUXChannelName = New System.Windows.Forms.Label(AUX_CHANNELS + 3) {}
        lblAUXChannelValue = New System.Windows.Forms.Label(AUX_CHANNELS + 3) {}
        For i As Integer = 0 To AUX_CHANNELS + 3
            Dim name As String = ""
            Select Case i
                Case 0
                    name = "THR"
                Case 1
                    name = "PITCH"
                Case 2
                    name = "ROLL"
                Case 3
                    name = "YAW"
                Case Else
                    name = "AUX" & i - 3
            End Select
            lblAUXChannelName(i) = New System.Windows.Forms.Label()
            lblAUXChannelName(i).Location = New Point(startx, (starty + i * rowspace) + 2)
            lblAUXChannelName(i).Visible = True
            lblAUXChannelName(i).Text = name
            lblAUXChannelName(i).AutoSize = True
            frmMain.pnAUXChannels.Controls.Add(lblAUXChannelName(i))

            pgbAUXChannel(i) = New ProgressBarCtrl
            pgbAUXChannel(i).Location = New Point(startx + 40, starty + i * rowspace)
            pgbAUXChannel(i).Width = 130
            pgbAUXChannel(i).Height = 18
            pgbAUXChannel(i).Minimum = 900
            pgbAUXChannel(i).Maximum = 2100
            pgbAUXChannel(i).BarColor1 = Color.DarkGray
            pgbAUXChannel(i).BarColor2 = Color.LightGray
            frmMain.pnAUXChannels.Controls.Add(pgbAUXChannel(i))

            lblAUXChannelValue(i) = New System.Windows.Forms.Label()
            lblAUXChannelValue(i).Location = New Point(startx + 170, (starty + i * rowspace) + 2)
            lblAUXChannelValue(i).Visible = True
            lblAUXChannelValue(i).Text = "1000"
            lblAUXChannelValue(i).AutoSize = True
            frmMain.pnAUXChannels.Controls.Add(lblAUXChannelValue(i))
        Next
    End Sub

    Public Sub updateAUXChannels()
        lblAUXChannelValue(0).Text = mw_gui.rcRoll
        pgbAUXChannel(0).Value = mw_gui.rcRoll
        lblAUXChannelValue(1).Text = mw_gui.rcPitch
        pgbAUXChannel(1).Value = mw_gui.rcPitch
        lblAUXChannelValue(2).Text = mw_gui.rcYaw
        pgbAUXChannel(2).Value = mw_gui.rcYaw
        lblAUXChannelValue(3).Text = mw_gui.rcThrottle
        pgbAUXChannel(3).Value = mw_gui.rcThrottle
        For i As Integer = 0 To AUX_CHANNELS - 1
            lblAUXChannelValue(i + 4).Text = mw_gui.rcAUX(i)
            pgbAUXChannel(i + 4).Value = mw_gui.rcAUX(i)
        Next
    End Sub

    Public Sub initRealtimeChannel()
        Dim rowspace As Integer = 20
        Dim row As Integer = 0
        Dim col As Integer = 0
        Dim startx As Integer = 10
        Dim starty As Integer = 10
        pgbRealtimeChannel = New ProgressBarCtrl(AUX_CHANNELS + 3) {}
        lblRealtimeChannelName = New System.Windows.Forms.Label(AUX_CHANNELS + 3) {}
        lblRealtimeChannelValue = New System.Windows.Forms.Label(AUX_CHANNELS + 3) {}
        For i As Integer = 0 To AUX_CHANNELS + 3
            Dim name As String = ""
            Select Case i
                Case 0
                    name = "THR"
                Case 1
                    name = "PITCH"
                Case 2
                    name = "ROLL"
                Case 3
                    name = "YAW"
                Case Else
                    name = "AUX" & i - 3
            End Select
            lblRealtimeChannelName(i) = New System.Windows.Forms.Label()
            lblRealtimeChannelName(i).Location = New Point(startx, (starty + i * rowspace) + 2)
            lblRealtimeChannelName(i).Visible = True
            lblRealtimeChannelName(i).Text = name
            lblRealtimeChannelName(i).AutoSize = True
            frmMain.pnRealtimeChannels.Controls.Add(lblRealtimeChannelName(i))

            pgbRealtimeChannel(i) = New ProgressBarCtrl
            pgbRealtimeChannel(i).Location = New Point(startx + 40, starty + i * rowspace)
            pgbRealtimeChannel(i).Width = 130
            pgbRealtimeChannel(i).Height = 18
            pgbRealtimeChannel(i).Minimum = 900
            pgbRealtimeChannel(i).Maximum = 2100
            pgbRealtimeChannel(i).BarColor1 = Color.DarkGray
            pgbRealtimeChannel(i).BarColor2 = Color.LightGray
            frmMain.pnRealtimeChannels.Controls.Add(pgbRealtimeChannel(i))

            lblRealtimeChannelValue(i) = New System.Windows.Forms.Label()
            lblRealtimeChannelValue(i).Location = New Point(startx + 170, (starty + i * rowspace) + 2)
            lblRealtimeChannelValue(i).Visible = True
            lblRealtimeChannelValue(i).Text = "1000"
            lblRealtimeChannelValue(i).AutoSize = True
            frmMain.pnRealtimeChannels.Controls.Add(lblRealtimeChannelValue(i))
        Next
    End Sub

    Public Sub updateRealtimeChannels()
        lblRealtimeChannelValue(0).Text = mw_gui.rcRoll
        pgbRealtimeChannel(0).Value = mw_gui.rcRoll
        lblRealtimeChannelValue(1).Text = mw_gui.rcPitch
        pgbRealtimeChannel(1).Value = mw_gui.rcPitch
        lblRealtimeChannelValue(2).Text = mw_gui.rcYaw
        pgbRealtimeChannel(2).Value = mw_gui.rcYaw
        lblRealtimeChannelValue(3).Text = mw_gui.rcThrottle
        pgbRealtimeChannel(3).Value = mw_gui.rcThrottle
        For i As Integer = 0 To AUX_CHANNELS - 1
            lblRealtimeChannelValue(i + 4).Text = mw_gui.rcAUX(i)
            pgbRealtimeChannel(i + 4).Value = mw_gui.rcAUX(i)
        Next
    End Sub

End Module
