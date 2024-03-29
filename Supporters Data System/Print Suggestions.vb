﻿Imports System.ComponentModel
Imports System.Data.SQLite

Imports System.Linq
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Imports ExcelAutoFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat
Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Xml.XPath
Imports System.Data
Imports System.Xml


'selection query coming from other foms
Public Module GlobalVariables
    Public gettingselectedareas As String = Nothing
    Public selectedareascount As Integer = 0
End Module

Public Class Print_Suggestions
    Private Sub Print_Suggestions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            ToolStripTotalRecords.Text = "Total Records : " & count & ""
            ToolStripSelectedRecords.Text = "Selected Records : " & count & ""
        End With


        conn.Close()

        DataGridView1.DataSource = sqldt


        'checkbox defaults
        allyearsradio.Checked = True
        allstatusradio.Checked = True
        alltypesradio.Checked = True
        allareasradio.Checked = True
    End Sub

    'groupbox subcomponent enable/disable
    '-------------------------------
    'Years
    'All years
    Private Sub allyearsradio_CheckedChanged(sender As Object, e As EventArgs) Handles allyearsradio.CheckedChanged
        If allyearsradio.Checked = True Then
            oneyeartxt.Enabled = False
            fromdtpcik.Enabled = False
            todtpick.Enabled = False
            fromlabel.Enabled = False
            tolabel.Enabled = False
            oneyeartxt.ResetText()
            fromdtpcik.ResetText()
            todtpick.ResetText()
        End If
    End Sub

    'One year
    Private Sub oneyearradio_CheckedChanged(sender As Object, e As EventArgs) Handles oneyearradio.CheckedChanged
        If oneyearradio.Checked = True Then
            oneyeartxt.Enabled = True
            fromdtpcik.Enabled = False
            todtpick.Enabled = False
            fromlabel.Enabled = False
            tolabel.Enabled = False
            fromdtpcik.ResetText()
            todtpick.ResetText()
        End If
    End Sub

    'Few years
    Private Sub fewyearsradio_CheckedChanged(sender As Object, e As EventArgs) Handles fewyearsradio.CheckedChanged
        If fewyearsradio.Checked = True Then
            oneyeartxt.Enabled = False
            fromdtpcik.Enabled = True
            todtpick.Enabled = True
            fromlabel.Enabled = True
            tolabel.Enabled = True
            oneyeartxt.ResetText()
        End If
    End Sub


    'Status
    'All status
    Private Sub allstatusradio_CheckedChanged(sender As Object, e As EventArgs) Handles allstatusradio.CheckedChanged
        If allstatusradio.Checked = True Then
            approvedchkbox.Enabled = False
            pendingchkbox.Enabled = False
            completechkbox.Enabled = False
            declinedchkbox.Enabled = False

            approvedchkbox.Checked = False
            pendingchkbox.Checked = False
            completechkbox.Checked = False
            declinedchkbox.Checked = False
        End If
    End Sub

    'one status
    Private Sub fewsttatusradio_CheckedChanged(sender As Object, e As EventArgs) Handles fewsttatusradio.CheckedChanged
        If fewsttatusradio.Checked = True Then
            approvedchkbox.Enabled = True
            pendingchkbox.Enabled = True
            completechkbox.Enabled = True
            declinedchkbox.Enabled = True
        End If
    End Sub

    'types radio
    'all types
    Private Sub alltypesradio_CheckedChanged(sender As Object, e As EventArgs) Handles alltypesradio.CheckedChanged
        bridgeschkbox.Enabled = False
        roadschkbox.Enabled = False
        irrigationchkbox.Enabled = False
        welfarechkbox.Enabled = False
        otherchkbox.Enabled = False

        bridgeschkbox.Checked = False
        roadschkbox.Checked = False
        irrigationchkbox.Checked = False
        welfarechkbox.Checked = False
        otherchkbox.Checked = False

    End Sub

    'few types
    Private Sub fewtypesradio_CheckedChanged(sender As Object, e As EventArgs) Handles fewtypesradio.CheckedChanged
        bridgeschkbox.Enabled = True
        roadschkbox.Enabled = True
        irrigationchkbox.Enabled = True
        welfarechkbox.Enabled = True
        otherchkbox.Enabled = True
    End Sub

    'all areas check
    Private Sub allareasradio_CheckedChanged(sender As Object, e As EventArgs) Handles allareasradio.CheckedChanged
        selareabtn.Enabled = False
    End Sub

    'seat areas check
    Private Sub seatwiseradio_CheckedChanged(sender As Object, e As EventArgs) Handles seatwiseradio.CheckedChanged
        selareabtn.Enabled = True
    End Sub

    'division areas check
    Private Sub divisionviseradio_CheckedChanged(sender As Object, e As EventArgs) Handles divisionviseradio.CheckedChanged
        selareabtn.Enabled = True
    End Sub

    'gn division areas check
    Private Sub gndivisionwiseradio_CheckedChanged(sender As Object, e As EventArgs) Handles gndivisionwiseradio.CheckedChanged
        selareabtn.Enabled = True
    End Sub

    'search algo
    Private Sub searchbtn_Click(sender As Object, e As EventArgs) Handles searchbtn.Click

        Dim SQL As String = "Select * from suggestions where 1=1 "

        'years check
        If allareasradio.Checked = True Then

        End If

        If oneyearradio.Checked = True Then
            SQL = SQL & "AND වර්ෂය=" & oneyeartxt.Text & ""
        End If


        If fewyearsradio.Checked = True Then
            SQL = SQL & "AND වර්ෂය BETWEEN " & fromdtpcik.Text & " And " & todtpick.Text & ""
        End If


        'status check
        If allstatusradio.Checked = True Then
        End If

        If fewsttatusradio.Checked = True Then
            SQL = SQL & " AND තත්වය IN ("
            For Each chkbox As CheckBox In Me.GroupBox3.Controls.OfType(Of CheckBox)()
                If chkbox.Checked = True Then
                    SQL = SQL & "'" & chkbox.Text & "',"
                End If
            Next

            'removing last comma
            SQL = SQL.Substring(0, SQL.Length - 1)
            SQL = SQL & ")"
        End If

        'type check
        If alltypesradio.Checked = True Then
        End If

        If fewtypesradio.Checked = True Then
            SQL = SQL & " AND වර්ගය IN ("
            For Each chkbox As CheckBox In Me.GroupBox2.Controls.OfType(Of CheckBox)()
                If chkbox.Checked = True Then
                    SQL = SQL & "'" & chkbox.Text & "',"
                End If
            Next

            'removing last comma
            SQL = SQL.Substring(0, SQL.Length - 1)
            'closing bracket
            SQL = SQL & ")"
        End If


        'area check
        If allareasradio.Checked = True Then

        End If

        If seatwiseradio.Checked = True Then
            If selectedareascount > 0 Then
                SQL = SQL & " AND ආසනය IN ("
                SQL = SQL & gettingselectedareas
                SQL = SQL & ")"
            Else
                MessageBox.Show("ආසන කිසිවක් තෝරාගෙන නැත. කරැණාකර ආසන එකක් හෝ කීපයක් තෝරන්න.", "වැදගත්", MessageBoxButtons.OK, MessageBoxIcon.Question)
                Return
            End If
        End If

        If divisionviseradio.Checked = True Then
            If selectedareascount > 0 Then
                SQL = SQL & " AND කොට්ඨාශය IN ("
                SQL = SQL & gettingselectedareas
                SQL = SQL & ")"
            Else
                MessageBox.Show("කොට්ඨාශ කිසිවක් තෝරාගෙන නැත. කරැණාකර කොට්ඨාශ එකක් හෝ කීපයක් තෝරන්න.", "වැදගත්", MessageBoxButtons.OK, MessageBoxIcon.Question)
                Return
            End If
        End If

        If gndivisionwiseradio.Checked = True Then
            If selectedareascount > 0 Then
                SQL = SQL & " AND වසම IN ("
                SQL = SQL & gettingselectedareas
                SQL = SQL & ")"
            Else
                MessageBox.Show("වසම් කිසිවක් තෝරාගෙන නැත. කරැණාකර වසම් එකක් හෝ කීපයක් තෝරන්න.", "වැදගත්", MessageBoxButtons.OK, MessageBoxIcon.Question)
                Return
            End If
        End If

        DataGridView1.DataSource = Nothing
        'loading final query to datagrid
        Dim conn As New SQLiteConnection("Data Source = C:\Users\janit\Desktop\Suggestions.db")
        conn.Open()
        'loading query
        Dim sqlcmd As New SQLiteCommand
        sqlcmd.Connection = conn
        sqlcmd.CommandText = "" & SQL & ""

        Dim sqlread As SQLiteDataReader = sqlcmd.ExecuteReader
        Dim sqldt As New DataTable
        sqldt.Load(sqlread)
        sqlread.Close()
        DataGridView1.DataSource = sqldt

        'selected rows count
        Dim selreccount As Integer = DataGridView1.RowCount
        selreccount = selreccount - 1
        ToolStripSelectedRecords.Text = "Selected Records : " & selreccount.ToString & ""

        conn.Close()


    End Sub

    Private Sub selareabtn_Click(sender As Object, e As EventArgs) Handles selareabtn.Click
        If seatwiseradio.Checked = True Then
            select_seat.Show()
        End If
        If divisionviseradio.Checked = True Then
            select_division.Show()
        End If
        If gndivisionwiseradio.Checked = True Then
            select_gndivision.Show()
        End If
    End Sub

    Private Sub Printbtn_Click(sender As Object, e As EventArgs) Handles Printbtn.Click
        Try
            Printbtn.Text = "Please Wait..."
            Printbtn.Enabled = False

            SaveFileDialog1.Filter = "Excel Document (*.xlsx)|*.xlsx"
            If SaveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim xlApp As Microsoft.Office.Interop.Excel.Application
                Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
                Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
                Dim misValue As Object = System.Reflection.Missing.Value
                Dim i As Integer
                Dim j As Integer

                xlApp = New Microsoft.Office.Interop.Excel.Application
                xlWorkBook = xlApp.Workbooks.Add(misValue)
                xlWorkSheet = xlWorkBook.Sheets("sheet1")

                For i = 0 To DataGridView1.RowCount - 2
                    For j = 0 To DataGridView1.ColumnCount - 1
                        For k As Integer = 1 To DataGridView1.Columns.Count
                            xlWorkSheet.Cells(1, k) = DataGridView1.Columns(k - 1).HeaderText
                            xlWorkSheet.Cells(i + 2, j + 1) = DataGridView1(j, i).Value.ToString()
                        Next
                    Next
                Next

                xlWorkSheet.SaveAs(SaveFileDialog1.FileName)
                xlWorkBook.Close()
                xlApp.Quit()

                releaseObject(xlApp)
                releaseObject(xlWorkBook)
                releaseObject(xlWorkSheet)

                MsgBox("Successfully saved" & vbCrLf & "File are saved at : " & SaveFileDialog1.FileName, MsgBoxStyle.Information, "Information")

                Printbtn.Text = "Export"
                Printbtn.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show("Failed to save !!!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

End Class