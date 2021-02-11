Imports System.Data.SQLite
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

    Private Sub suggestions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'getting database
        Dim conn As New SQLiteConnection("Data Source = C:\Users\janit\Desktop\Suggestions.db")
        conn.Open()

        Dim sqlcmd As New SQLiteCommand
        sqlcmd.Connection = conn
        sqlcmd.CommandText = "Select * from Suggestions"

        Dim sqlread As SQLiteDataReader = sqlcmd.ExecuteReader
        Dim sqldt As New DataTable
        sqldt.Load(sqlread)
        sqlread.Close()
        conn.Close()

        DataGridView1.DataSource = sqldt
    End Sub

End Class