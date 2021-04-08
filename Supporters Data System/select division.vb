Public Class select_division
    Private Sub seldivisionbtnok_Click(sender As Object, e As EventArgs) Handles seldivisionbtnok.Click
        Dim seldivisionstring As String = Nothing
        Dim selectedchkcount As Integer = 0


        For Each chkbox As CheckBox In Me.Controls.OfType(Of CheckBox)()
            If chkbox.Checked = True Then
                selectedchkcount = selectedchkcount + 1
                seldivisionstring = seldivisionstring & "'" & chkbox.Text & "',"
            End If
        Next

        If selectedchkcount < 1 Then
            MessageBox.Show("කොට්ඨාශ කිසිවක් තෝරාගෙන නැත. කරැණාකර කොට්ඨාශ එකක් හෝ කීපයක් තෝරන්න.",
                                                      "වැදගත්",
                                                      MessageBoxButtons.OK,
                                                      MessageBoxIcon.Question)
            Return
        Else
            seldivisionstring = seldivisionstring.Substring(0, seldivisionstring.Length - 1)

            'transferring to suggestions print form
            gettingselectedareas = seldivisionstring
            selectedareascount = selectedchkcount

            Me.Hide()
        End If
    End Sub

    Private Sub seldivisionbtncancel_Click(sender As Object, e As EventArgs) Handles seldivisionbtncancel.Click
        Me.Hide()
    End Sub
End Class