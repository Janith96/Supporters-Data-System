﻿Imports System.ComponentModel
Imports System.Data.SQLite
Public Class suggestions
    Dim vyear, vdivision, vgndivision, vcomplete, vcategory, vcoordinator, vmobile, vsuggestion As String

    Dim rowid As String
    Dim editrowid As String
    Dim searchtype As String

    Private Sub Updatebtn_Click(sender As Object, e As EventArgs) Handles Updatebtn.Click

        Dim sqlconnection As New SQLiteConnection("Data Source = C:\Users\janit\Desktop\Suggestions.db")

        Try
            If sqlconnection.State = ConnectionState.Closed Then
                sqlconnection.Open()
                Dim sqlstatement As String = "UPDATE `Suggestions` SET `වර්ෂය` = '" & yeartxt.Text & "', `කොට්ඨාශය` = '" & seatcombo.Text & "', `වසම` = '" & gndivisiontxt.Text & "', `වර්ගය` = '" & categorycombo.Text & "', `සම්බන්ධීකාරක` = '" & coordinatortxt.Text & "', `දුරකථනය` = '" & mobiletext.Text & "', `යෝජනාව` = '" & suggestiontxt.Text & "', `තත්වය` = '" & completecombo.Text & "' WHERE `Suggestions`.`SuggestionID` = '" & editrowid & "';"

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
                        'check wheather rowid change when search results change
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

        completecombo.SelectedIndex = -1
        categorycombo.SelectedIndex = -1
    End Sub

    Private Sub Exitbtn_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub

    Private Sub suggestions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'loading table to datagrid
        Dim conn As New SQLiteConnection("Data Source = C:\Users\janit\Desktop\Suggestions.db")
        conn.Open()

        'loading query
        Dim sqlcmd As New SQLiteCommand
        sqlcmd.Connection = conn
        sqlcmd.CommandText = "Select * from Suggestions"

        Dim sqlread As SQLiteDataReader = sqlcmd.ExecuteReader
        Dim sqldt As New DataTable
        sqldt.Load(sqlread)
        sqlread.Close()

        'rowcount query
        Dim count As String
        Dim sqlstatement As String = "Select COUNT(*) from Suggestions"
        Dim cmd As SQLiteCommand = New SQLiteCommand
        With cmd
            .CommandText = sqlstatement
            .CommandType = CommandType.Text
            .Connection = conn
            count = Convert.ToString(cmd.ExecuteScalar())
            ToolStripStatusTotalRecords.Text = "Total Records : " & count & ""
        End With


        conn.Close()

        'checkbox column generate
        'Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
        'checkBoxColumn.HeaderText = ""
        'checkBoxColumn.Width = 30
        'checkBoxColumn.Name = "checkBoxColumn"
        'DataGridView1.Columns.Insert(0, checkBoxColumn)

        'loading datagrid and setting seachcombo to all
        DataGridView1.DataSource = sqldt
        Searchselectcmb.SelectedIndex = 0

        'making checkbox editable
        'For Each dc As DataGridViewColumn In DataGridView1.Columns
        'If dc.Index.Equals(0) Then
        'dc.ReadOnly = False
        'Else
        'dc.ReadOnly = True
        'End If
        'Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Savebtn.Click

        Dim sqlconnection As New SQLiteConnection("Data Source = C:\Users\janit\Desktop\Suggestions.db")

        Try
            If sqlconnection.State = ConnectionState.Closed Then
                sqlconnection.Open()
                Dim sqlstatement As String = "INSERT INTO `Suggestions` (`වර්ෂය`, `කොට්ඨාශය`, `වසම`, `වර්ගය`, `සම්බන්ධීකාරක`, `දුරකථනය`, `යෝජනාව`, `තත්වය`) VALUES ('" & yeartxt.Text & "', '" & seatcombo.Text & "', '" & gndivisiontxt.Text & "', '" & categorycombo.Text & "', '" & coordinatortxt.Text & "', '" & mobiletext.Text & "', '" & suggestiontxt.Text & "', '" & completecombo.Text & "');"

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
            seatcombo.Text = vdivision
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

                        vyear = .Rows(i).Cells("වර්ෂය").Value.ToString
                        vdivision = .Rows(i).Cells("කොට්ඨාශය").Value.ToString
                        vgndivision = .Rows(i).Cells("වසම").Value.ToString
                        vcomplete = .Rows(i).Cells("තත්වය").Value.ToString
                        vcategory = .Rows(i).Cells("වර්ගය").Value.ToString
                        vcoordinator = .Rows(i).Cells("සම්බන්ධීකාරක").Value.ToString
                        vmobile = .Rows(i).Cells("දුරකථනය").Value.ToString
                        vsuggestion = .Rows(i).Cells("යෝජනාව").Value.ToString
                        rowid = .Rows(i).Cells("SuggestionID").Value.ToString

                    End If
                End With
            End If
        End If
    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        Deletebtn_Click(Nothing, Nothing)
    End Sub

    Private Sub SelectAll_Click(sender As Object, e As EventArgs) Handles SelectAll.Click
        DataGridView1.SelectAll()
    End Sub



    Private Sub Searchselectcmb_SelectedValueChanged(sender As Object, e As EventArgs) Handles Searchselectcmb.SelectedValueChanged
        searchtype = Searchselectcmb.Text
    End Sub

    Private Sub Searchtb_TextChanged(sender As Object, e As EventArgs) Handles Searchtb.TextChanged
        Dim conn As New SQLiteConnection("Data Source = C:\Users\janit\Desktop\Suggestions.db")
        conn.Open()

        Dim sqlcmd As New SQLiteCommand
        sqlcmd.Connection = conn
        If Searchselectcmb.SelectedIndex = 0 Then
            sqlcmd.CommandText = "SELECT * FROM Suggestions WHERE වර්ෂය LIKE '%" & Searchtb.Text & "%' OR කොට්ඨාශය LIKE '%" & Searchtb.Text & "%' OR 'වසම' LIKE '%" & Searchtb.Text & "%' OR වර්ගය LIKE '%" & Searchtb.Text & "%' OR සම්බන්ධීකාරක LIKE '%" & Searchtb.Text & "%' OR දුරකථනය LIKE '%" & Searchtb.Text & "%' OR යෝජනාව LIKE '%" & Searchtb.Text & "%' OR තත්වය LIKE '%" & Searchtb.Text & "%'"
        Else
            sqlcmd.CommandText = "Select * from Suggestions where " & searchtype & " like '%" & Searchtb.Text & "%'"
        End If


        Dim sqlread As SQLiteDataReader = sqlcmd.ExecuteReader
        Dim sqldt As New DataTable
        sqldt.Load(sqlread)
        sqlread.Close()
        conn.Close()

        DataGridView1.DataSource = sqldt
    End Sub
End Class