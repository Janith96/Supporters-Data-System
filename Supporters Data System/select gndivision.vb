Public Class select_gndivision
    Private Sub seldivisionbtncancel_Click(sender As Object, e As EventArgs) Handles seldivisionbtncancel.Click
        Me.Hide()
    End Sub

    Private Sub seldivisionbtnok_Click(sender As Object, e As EventArgs) Handles seldivisionbtnok.Click
        Dim selgndivisionstring As String = Nothing
        Dim selectedcmbcount As Integer = 0


        For Each cmbbox As ComboBox In Me.Controls.OfType(Of ComboBox)()
            If cmbbox.SelectedIndex > -1 Then
                selectedcmbcount = selectedcmbcount + 1
                selgndivisionstring = selgndivisionstring & "'" & cmbbox.Text & "',"
            End If
        Next

        If selectedcmbcount < 1 Then
            MessageBox.Show("වසම් කිසිවක් තෝරාගෙන නැත. කරැණාකර වසම් එකක් හෝ කීපයක් තෝරන්න.",
                                                      "වැදගත්",
                                                      MessageBoxButtons.OK,
                                                      MessageBoxIcon.Question)
            Return
        Else
            selgndivisionstring = selgndivisionstring.Substring(0, selgndivisionstring.Length - 1)

            'transferring to suggestions print form
            gettingselectedareas = selgndivisionstring
            selectedareascount = selectedcmbcount

            Me.Hide()
        End If
    End Sub
End Class