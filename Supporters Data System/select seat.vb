
Public Class select_seat
    Private Sub seatbtncancel_Click(sender As Object, e As EventArgs) Handles seatbtncancel.Click
        Me.Hide()
    End Sub

    Private Sub seatbtnok_Click(sender As Object, e As EventArgs) Handles seatbtnok.Click

        Dim selseatstring As String = Nothing
        Dim selectedchkcount As Integer = 0


        For Each chkbox As CheckBox In Me.Controls.OfType(Of CheckBox)()
            If chkbox.Checked = True Then
                selectedchkcount = selectedchkcount + 1
                selseatstring = selseatstring & "'" & chkbox.Text & "',"
            End If
        Next

        If selectedchkcount < 1 Then
            MessageBox.Show("ආසන කිසිවක් තෝරාගෙන නැත. කරැණාකර ආසන එකක් හෝ කීපයක් තෝරන්න.",
                                                      "වැදගත්",
                                                      MessageBoxButtons.OK,
                                                      MessageBoxIcon.Question)
            Return
        Else
            selseatstring = selseatstring.Substring(0, selseatstring.Length - 1)

        'transferring to suggestions print form
        gettingselectedareas = selseatstring
        selectedareascount = selectedchkcount

        Me.Hide()
        End If

    End Sub
End Class