Module modRCControlSettings
    Public aux As System.Windows.Forms.CheckBox(,,)
    Public aux_labels As System.Windows.Forms.Label()
    Public cb_labels As System.Windows.Forms.Label()
    Public lmh_labels As System.Windows.Forms.Label(,)
    Dim isDrawAUX As Boolean = False
    Const rcLow As Integer = 1300
    Const rcMid As Integer = 1700

    Public Sub updateRCControlSettings()
        'Show LMH postions above switches
        For i As Integer = 0 To boxAUX_CHANNELS - 1
            lmh_labels(i, 0).BackColor = If((mw_gui.rcAUX(i) < rcLow), Color.Green, Color.Transparent)
            lmh_labels(i, 1).BackColor = If((mw_gui.rcAUX(i) > rcLow AndAlso mw_gui.rcAUX(i) < rcMid), Color.Green, Color.Transparent)
            lmh_labels(i, 2).BackColor = If((mw_gui.rcAUX(i) > rcMid), Color.Green, Color.Transparent)
        Next

        'evaluate rc_options and recolor mode which supposed to be ON at the current rc values
        Dim act As Byte()
        'act1, act2, act3, act4, opt1, opt2, opt3, opt4;
        act = New Byte(AUX_CHANNELS - 1) {}
        Dim opt As Byte()
        opt = New Byte(AUX_CHANNELS - 1) {}

        'Construct options switch mask based on rcAux input
        For i As Integer = 0 To boxAUX_CHANNELS - 1
            opt(i) = CByte(Convert.ToByte(mw_gui.rcAUX(i) < 1300) + Convert.ToByte(1300 < mw_gui.rcAUX(i) AndAlso mw_gui.rcAUX(i) < 1700) * 2 + Convert.ToByte(mw_gui.rcAUX(i) > 1700) * 4)
        Next
        'Compare with switchbox settings
        For b As Integer = 0 To iCheckBoxItems - 1
            'act1 = 0; act2 = 0; act3 = 0; act4 = 0;
            For i As Integer = 0 To boxAUX_CHANNELS - 1
                act(i) = 0
            Next
            For a As Byte = 0 To 2
                For i As Integer = 0 To boxAUX_CHANNELS - 1
                    If aux(i, a, b).Checked Then
                        act(i) += CByte(1 << a)
                    End If
                Next
            Next
            'Highlight active function name
            Dim active As Boolean
            active = False
            For i As Integer = 0 To boxAUX_CHANNELS - 1
                If (opt(i) And act(i)) <> 0 Then
                    active = True
                End If
            Next
            If active = True Then
                cb_labels(b).BackColor = Color.Red
                cb_labels(b).ForeColor = Color.Yellow
            Else
                cb_labels(b).BackColor = Color.Transparent
                cb_labels(b).ForeColor = Color.Black
            End If
        Next

    End Sub

    Public Sub create_aux_panal()
        Dim a As Integer, b As Integer, c As Integer
        Dim rowspace As Integer = 18
        Dim row As Integer = 0
        Dim col As Integer = 0
        Dim startx As Integer = 10
        Dim starty As Integer = 40

        Dim old_cb_labelsCount As Integer = 0
        If IsNothing(cb_labels) = False Then
            old_cb_labelsCount = cb_labels.Count()
        End If
        Dim old_aux_labels As Integer = 0
        If IsNothing(aux_labels) = False Then
            old_aux_labels = aux_labels.Count()
        End If
        If old_cb_labelsCount <> iCheckBoxItems Or old_aux_labels <> boxAUX_CHANNELS Then
            'Delete actual panal 
            If old_cb_labelsCount > 0 Or old_aux_labels > 0 Then
                delete_aux_panal()
            End If
            'Create new panal
            aux_labels = New System.Windows.Forms.Label(boxAUX_CHANNELS - 1) {}
            lmh_labels = New System.Windows.Forms.Label(boxAUX_CHANNELS - 1, 2) {}
            cb_labels = New System.Windows.Forms.Label(iCheckBoxItems - 1) {}
            '20
            For z = 0 To iCheckBoxItems - 1
                cb_labels(z) = New System.Windows.Forms.Label()
                cb_labels(z).Text = mw_gui.sBoxNames(z)
                cb_labels(z).Location = New Point(10, starty + z * rowspace)
                cb_labels(z).Visible = True
                cb_labels(z).AutoSize = True
                'cb_labels(z).ForeColor = Color.White
                cb_labels(z).TextAlign = ContentAlignment.MiddleRight
                frmMain.spMain.Panel1.Controls.Add(cb_labels(z))
            Next        'Build the RC control checkboxes structure

            Application.DoEvents()

            ' aux1-AUX_CHANNELS, L,M,H - AUX_CHANNELS is an setting in FC
            Dim strlmh As String = "LMH"
            For a = 0 To boxAUX_CHANNELS - 1
                aux_labels(a) = New System.Windows.Forms.Label()
                aux_labels(a).Text = "AUX" & [String].Format("{0:0}", a + 1)
                aux_labels(a).Location = New Point(startx + a * 70 + 8, starty - 35)
                aux_labels(a).AutoSize = True
                'aux_labels(a).ForeColor = Color.White
                frmMain.pnAUX.Controls.Add(aux_labels(a))
                For b = 0 To 2
                    lmh_labels(a, b) = New System.Windows.Forms.Label()
                    lmh_labels(a, b).Text = strlmh.Substring(b, 1)


                    lmh_labels(a, b).Location = New Point(startx + a * 70 + b * 18, starty - 20)
                    lmh_labels(a, b).AutoSize = True
                    'lmh_labels(a, b).ForeColor = Color.White
                    frmMain.pnAUX.Controls.Add(lmh_labels(a, b))
                    Application.DoEvents()
                Next
            Next

            Application.DoEvents()

            isDrawAUX = True
            aux = New System.Windows.Forms.CheckBox(boxAUX_CHANNELS - 1, 3, iCheckBoxItems - 1) {}
            For c = 0 To boxAUX_CHANNELS - 1
                For a = 0 To 2
                    For b = 0 To iCheckBoxItems - 1
                        aux(c, a, b) = New System.Windows.Forms.CheckBox()
                        aux(c, a, b).Location = New Point(startx + a * 18 + c * 70, starty + b * rowspace)
                        aux(c, a, b).Visible = True
                        aux(c, a, b).Text = ""
                        aux(c, a, b).AutoSize = True
                        aux(c, a, b).Size = New Size(16, 16)
                        aux(c, a, b).UseVisualStyleBackColor = True
                        'Set info on the given checkbox position
                        Dim al As New ArrayList
                        al.Add(c) 'aux
                        al.Add(a) 'rcLevel
                        al.Add(b) 'item
                        aux(c, a, b).Tag = al
                        'Which item
                        frmMain.pnAUX.Controls.Add(aux(c, a, b))
                        AddHandler aux(c, a, b).CheckedChanged, AddressOf aux_checked_changed_event
                        Application.DoEvents()
                    Next
                Next
            Next
        End If
        isDrawAUX = False
    End Sub

    Public Sub delete_aux_panal()
        Dim a As Integer, b As Integer, c As Integer
        If aux IsNot Nothing Then
            For c = 0 To aux.Length / iCheckBoxItems / 4 - 1
                For a = 0 To 2
                    For b = 0 To iCheckBoxItems - 1
                        Try
                            frmMain.tpRCSetting.Controls.Remove(aux(c, a, b))
                        Catch
                        End Try
                    Next
                Next
            Next

            For a = 0 To aux.Length / iCheckBoxItems / 4 - 1
                Try
                    frmMain.tpRCSetting.Controls.Remove(aux_labels(a))
                    For b = 0 To 2
                        frmMain.tpRCSetting.Controls.Remove(lmh_labels(a, b))
                    Next
                Catch
                End Try
            Next

            For i As Integer = 0 To iCheckBoxItems - 1
                frmMain.tpRCSetting.Controls.Remove(cb_labels(i))
            Next
        End If
    End Sub

    Public Sub set_aux_panel()
        For iCheckBoxItem As Integer = 0 To iCheckBoxItems - 1
            Dim bit As Integer = 0
            For aux_channel As Integer = 0 To boxAUX_CHANNELS - 1
                For chkLMH As Byte = 0 To 2
                    aux(aux_channel, chkLMH, iCheckBoxItem).Checked = If((mw_gui.activation(iCheckBoxItem) And (1 << bit)) = 0, False, True)
                    aux(aux_channel, chkLMH, iCheckBoxItem).BackColor = Color.Transparent
                    bit += 1
                Next
            Next
        Next
    End Sub

    Public Sub read_aux_panel()
        For iCheckBoxItem As Integer = 0 To iCheckBoxItems - 1
            Try
                mw_params.activation(iCheckBoxItem) = 0
                For chkLMH As Byte = 0 To 2
                    Dim bit As Integer = 0
                    For aux_channel As Integer = 0 To boxAUX_CHANNELS - 1
                        If aux(aux_channel, chkLMH, iCheckBoxItem).Checked Then
                            mw_params.activation(iCheckBoxItem) += CUInt(1 << (bit + chkLMH))
                        End If
                        bit += 3
                    Next
                Next
            Catch
            End Try
        Next
    End Sub

    Private Sub aux_checked_changed_event(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If isDrawAUX = True Then Return
        Dim cb As System.Windows.Forms.CheckBox = DirectCast(sender, System.Windows.Forms.CheckBox)
        'al.Add(c) 'aux
        'al.Add(a) 'rcLevel
        'al.Add(b) 'item
        Try
            If cb.Checked = (CByte(mw_gui.activation(cb.Tag(2)) And (1 << cb.Tag(0) * 3 + cb.Tag(1))) = 0) Then
                cb.BackColor = Color.Coral
            Else
                cb.BackColor = Color.Transparent
            End If
        Catch ex As Exception

        End Try
    End Sub


End Module
