Public Class frmReboot
    Dim countDown As Integer = 10

    Private Sub frmReboot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.lblCountdown.Text = countDown
        Me.timerCountdown.Interval = 1000
        Me.timerCountdown.Enabled = True
    End Sub

    Private Sub timerCountdown_Tick(sender As Object, e As EventArgs) Handles timerCountdown.Tick
        If countDown > 0 Then
            countDown -= 1
            Me.lblCountdown.Text = countDown
        Else
            Me.timerCountdown.Enabled = False
            'If frmMain.txtCLIResult.Text.Substring(frmMain.txtCLIResult.Text.Length - 1, 1) <> "#" Then
            '    serialPort.Write("#" & vbCrLf)
            'End If
            disconnectCOM()
            frmMain.tabMain.SelectedIndex = 0
            Me.Close()
            End If
    End Sub

End Class