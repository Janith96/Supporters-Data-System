﻿Imports System.Data.SQLite
Public Class suggestions
    Dim vyear, vdivision, vgndivision, vcomplete, vcategory, vcoordinator, vmobile, vsuggestion As String

    Dim rowid As String
    Dim editrowid As String

    Private Sub Updatebtn_Click(sender As Object, e As EventArgs) Handles Updatebtn.Click

        Dim sqlconnection As New SQLiteConnection("Data Source = C:\Users\janit\Desktop\Suggestions.db")

        Try
            If sqlconnection.State = ConnectionState.Closed Then
                sqlconnection.Open()
                Dim sqlstatement As String = "UPDATE `Suggestions` SET `Year` = '" & yeartxt.Text & "', `Division` = '" & divisiontxt.Text & "', `GN Division` = '" & gndivisiontxt.Text & "', `Category` = '" & categorycombo.Text & "', `Coordinator` = '" & coordinatortxt.Text & "', `MobileNo` = '" & mobiletext.Text & "', `Suggestion` = '" & suggestiontxt.Text & "', `Complete` = '" & completecombo.Text & "' WHERE `Suggestions`.`SuggestionID` = '" & editrowid & "';"

                Dim cmd As SQLiteCommand = New SQLiteCommand

                With cmd
                    .CommandText = sqlstatement
                    .CommandType = CommandType.Text
                    .Connection = sqlconnection
                    .ExecuteNonQuery()

                End With
                sqlconnection.Close()
                MsgBox("Successfully Updated!")
                Updatebtn.Enabled = False
                Savebtn.Enabled = True
                resetbtn_Click(Nothing, Nothing)
                suggestions_Load(Nothing, Nothing)

            Else
                sqlconnection.Close()
                MsgBox("Connection Error!", "Error")

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub Deletebtn_Click(sender As Object, e As EventArgs) Handles Deletebtn.Click
        Dim sqlconnection As New SQLiteConnection("Data Source = C:\Users\janit\Desktop\Suggestions.db")

        If DataGridView1.RowCount = 0 Then
            MsgBox("Cannot delete, table data is empty!", MsgBoxStyle.Critical, "Failed")
            Return
        End If

        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Cannot delete, select the table data to be deleted!", MsgBoxStyle.Critical, "Failed!")
            Return
        End If

        If MsgBox("Delete record?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then Return

        Try
            If AllCellsSelected(DataGridView1) = True Then
                If sqlconnection.State = ConnectionState.Closed Then
                    sqlconnection.Open()

                    Dim sqlstatement As String = "DELETE From Suggestions"

                    Dim cmd As SQLiteCommand = New SQLiteCommand

                    With cmd
                        .CommandText = sqlstatement
                        .CommandType = CommandType.Text
                        .Connection = sqlconnection
                        .ExecuteNonQuery()

                    End With
                    sqlconnection.Close()
                    MsgBox("Successfully Updated!")
                    Updatebtn.Enabled = False
                    Savebtn.Enabled = True
                    resetbtn_Click(Nothing, Nothing)
                    suggestions_Load(Nothing, Nothing)
                    Return
                Else
                    sqlconnection.Close()
                    MsgBox("Connection Error!", "Error")

                End If
            End If

            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                If row.Selected = True Then
                    If sqlconnection.State = ConnectionState.Closed Then
                        sqlconnection.Open()

                        Dim sqlstatement As String = "Delete from Suggestions where SuggestionID='" & rowid & "'"

                        Dim cmd As SQLiteCommand = New SQLiteCommand

                        With cmd
                            .CommandText = sqlstatement
                            .CommandType = CommandType.Text
                            .Connection = sqlconnection
                            .ExecuteNonQuery()

                        End With
                        sqlconnection.Close()
                        MsgBox("Successfully Updated!")
                        Updatebtn.Enabled = False
                        Savebtn.Enabled = True
                        resetbtn_Click(Nothing, Nothing)
                        suggestions_Load(Nothing, Nothing)
                    Else
                        sqlconnection.Close()
                        MsgBox("Connection Error!", "Error")

                    End If
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

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
        'loading table to datagrid
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Savebtn.Click

        Dim sqlconnection As New SQLiteConnection("Data Source = C:\Users\janit\Desktop\Suggestions.db")

        Try
            If sqlconnection.State = ConnectionState.Closed Then
                sqlconnection.Open()
                Dim sqlstatement As String = "INSERT INTO `Suggestions` (`Year`, `Division`, `GN Division`, `Category`, `Coordinator`, `MobileNo`, `Suggestion`, `Complete`) VALUES ('" & yeartxt.Text & "', '" & divisiontxt.Text & "', '" & gndivisiontxt.Text & "', '" & categorycombo.Text & "', '" & coordinatortxt.Text & "', '" & mobiletext.Text & "', '" & suggestiontxt.Text & "', '" & completecombo.Text & "');"

                Dim cmd As SQLiteCommand = New SQLiteCommand

                With cmd
                    .CommandText = sqlstatement
                    .CommandType = CommandType.Text
                    .Connection = sqlconnection
                    .ExecuteNonQuery()

                End With
                sqlconnection.Close()
                MsgBox("Successfully recorded!")
                Updatebtn.Enabled = False
                Savebtn.Enabled = True
                resetbtn_Click(Nothing, Nothing)
                suggestions_Load(Nothing, Nothing)

            Else
                sqlconnection.Close()
                MsgBox("Connection Error!", "Error")

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Function AllCellsSelected(dgv As DataGridView) As Boolean
        AllCellsSelected = (DataGridView1.SelectedCells.Count = (DataGridView1.RowCount * DataGridView1.Columns.GetColumnCount(DataGridViewElementStates.Visible)))
    End Function

    Private Sub Edit_Click(sender As Object, e As EventArgs) Handles Edit.Click

        If AllCellsSelected(DataGridView1) = False Then
            Dim localrowid As String
            localrowid = rowid
            editrowid = localrowid
            yeartxt.Text = vyear
            divisiontxt.Text = vdivision
            gndivisiontxt.Text = vgndivision
            completecombo.SelectedItem = vcomplete
            categorycombo.SelectedItem = vcategory
            coordinatortxt.Text = vcoordinator
            mobiletext.Text = vmobile
            suggestiontxt.Text = vsuggestion


            Updatebtn.Enabled = True
            Savebtn.Enabled = False
        Else
            MsgBox("Multiple rows selected! Please choose one row to edit.", MsgBoxStyle.Critical, "Failed!")
        End If
    End Sub


    Private Sub DataGridView1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown


        If AllCellsSelected(DataGridView1) = False Then
            If e.Button = MouseButtons.Right Then
                DataGridView1.CurrentCell = DataGridView1(e.ColumnIndex, e.RowIndex)
                Dim i As Integer
                With DataGridView1
                    If e.RowIndex >= 0 Then
                        i = .CurrentRow.Index

                        vyear = .Rows(i).Cells("Year").Value.ToString
                        vdivision = .Rows(i).Cells("Division").Value.ToString
                        vgndivision = .Rows(i).Cells("GN Division").Value.ToString
                        vcomplete = .Rows(i).Cells("Complete").Value.ToString
                        vcategory = .Rows(i).Cells("Category").Value.ToString
                        vcoordinator = .Rows(i).Cells("Coordinator").Value.ToString
                        vmobile = .Rows(i).Cells("MobileNo").Value.ToString
                        vsuggestion = .Rows(i).Cells("Suggestion").Value.ToString
                        rowid = .Rows(i).Cells("SuggestionID").Value.ToString

                    End If
                End With
            End If
        End If
    End Sub


End Class