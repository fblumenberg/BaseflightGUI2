Imports System.Windows.Forms

<System.Runtime.InteropServices.ComVisible(False)> Public Class frmError
    Public myEx As Exception
    Public lastCommand As String = ""

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End
        Application.Exit()
        Me.Close()
    End Sub

    Private Sub frmError_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim errorText As String = ""
        Dim myLastCommand As String = vbCrLf & "****  Last Command  ****" & vbCrLf
        Dim myInnerException As String = vbCrLf & "****  InnerException  ****" & vbCrLf
        Dim myStackTrace As String = "******  StackTrace  ******" & vbCrLf
        If IsNothing(myEx.HelpLink) = False Then Me.txtHelplink.Text = myEx.HelpLink
        If IsNothing(myEx.Message) = False Then Me.txtMessage.Text = myEx.Message
        If IsNothing(myEx.Source) = False Then Me.txtSource.Text = myEx.Source
        If lastCommand <> "" Then errorText = errorText & myLastCommand & lastCommand & vbCrLf
        If IsNothing(myEx.StackTrace) = False Then errorText = errorText & myStackTrace & myEx.StackTrace & vbCrLf
        If IsNothing(myEx.InnerException) = False Then errorText = errorText & myInnerException & myEx.InnerException.ToString & vbCrLf
        Me.txtErrorText.Text = errorText
        lastCommand = ""
    End Sub


    Private Sub cmdClipBoard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClipBoard.Click
        Try
            Dim myClipBoardText As String = ""
            myClipBoardText = myClipBoardText & Application.ProductName & vbCrLf
            myClipBoardText = myClipBoardText & "ProductVersion = " & Application.ProductVersion & vbCrLf
            myClipBoardText = myClipBoardText & "CurrentCulture" & vbCrLf
            myClipBoardText = myClipBoardText & "  - DisplayName = " & Application.CurrentCulture.DisplayName & vbCrLf
            myClipBoardText = myClipBoardText & "  - DateTimeFormat = " & Application.CurrentCulture.DateTimeFormat.UniversalSortableDateTimePattern & vbCrLf
            myClipBoardText = myClipBoardText & "  - NumberDecimalSeparator = " & Application.CurrentCulture.NumberFormat.NumberDecimalSeparator & vbCrLf
            myClipBoardText = myClipBoardText & "  - NumberGroupSeparator = " & Application.CurrentCulture.NumberFormat.NumberGroupSeparator & vbCrLf

            myClipBoardText = myClipBoardText & vbCrLf & "****  User Comment Start ****" & vbCrLf
            myClipBoardText = myClipBoardText & Me.txtComment.Text & vbCrLf & vbCrLf
            myClipBoardText = myClipBoardText & vbCrLf & "****  Message ****" & vbCrLf
            myClipBoardText = myClipBoardText & Me.txtMessage.Text & vbCrLf & vbCrLf
            myClipBoardText = myClipBoardText & vbCrLf & "****  Source ****" & vbCrLf
            myClipBoardText = myClipBoardText & Me.txtSource.Text & vbCrLf & vbCrLf
            myClipBoardText = myClipBoardText & vbCrLf & "****  Helplink ****" & vbCrLf
            myClipBoardText = myClipBoardText & Me.txtHelplink.Text & vbCrLf & vbCrLf
            myClipBoardText = myClipBoardText & Me.txtErrorText.Text & vbCrLf & vbCrLf
            Clipboard.Clear()
            Clipboard.SetText(myClipBoardText)
        Catch ex As Exception
            MessageBox.Show(Me, ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
