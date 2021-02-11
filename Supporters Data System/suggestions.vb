Public Class suggestions
    Private Sub resetbtn_Click(sender As Object, e As EventArgs) Handles resetbtn.Click
        Dim txt As Control
        For Each txt In Me.Controls 'panel.controls if in a group
            If TypeOf txt Is TextBox Then
                txt.Text = ""
            End If
        Next

        Dim combo As Control
        For Each combo In Me.Controls
            If TypeOf combo Is ComboBox Then
                combo.Text = ""
            End If
        Next
    End Sub

    Private Sub Exitbtn_Click(sender As Object, e As EventArgs) Handles Exitbtn.Click
        Application.Exit()
    End Sub
End Class