Module modLiveView

    Public indicators As indicator_lamp()

    Public Sub createIndicatorLamps()
        'Build indicator lamps array
        Dim rowspace As Integer = 22
        indicators = New indicator_lamp(iCheckBoxItems - 1) {}
        Dim row As Integer = 0
        Dim col As Integer = 0
        Dim startx As Integer = 800
        Dim starty As Integer = 3
        For i As Integer = 0 To iCheckBoxItems - 1
            indicators(i) = New indicator_lamp()
            indicators(i).Location = New Point(startx + col * 52, starty + row * 19)
            indicators(i).Visible = True
            indicators(i).Text = names(i)
            indicators(i).indicator_color = 1
            indicators(i).Anchor = AnchorStyles.Right
            Me.splitContainer2.Panel2.Controls.Add(indicators(i))
            col += 1
            If col = 3 Then
                col = 0
                row += 1
            End If
        Next
    End Sub

End Module
