Imports System.ComponentModel
Imports System.Data.SQLite
Imports System
Public Class suggestions

    Dim vyear, vdivision, vgndivision, vcomplete, vcategory, vcoordinator, vmobile, vsuggestion, vseat As String

    Dim rowid As String
    Dim editrowid As String
    Dim searchtype As String
    Private Sub Updatebtn_Click(sender As Object, e As EventArgs) Handles Updatebtn.Click

        Dim sqlconnection As New SQLiteConnection("Data Source = C:\Users\janit\Desktop\Suggestions.db")

        Try
            If sqlconnection.State = ConnectionState.Closed Then
                sqlconnection.Open()
                Dim sqlstatement As String = "UPDATE `Suggestions` SET `වර්ෂය` = '" & yeartxt.Text & "', `ආසනය` = '" & seatcombo.Text & "', `කොට්ඨාශය` = '" & divisioncombo.Text & "', `වසම` = '" & GNDivisiontxt.Text & "', `වර්ගය` = '" & categorycombo.Text & "', `සම්බන්ධීකාරක` = '" & coordinatortxt.Text & "', `දුරකථනය` = '" & mobiletext.Text & "', `යෝජනාව` = '" & suggestiontxt.Text & "', `තත්වය` = '" & completecombo.Text & "' WHERE `Suggestions`.`SuggestionID` = '" & editrowid & "';"

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
                Dim sqlstatement As String = "INSERT INTO `Suggestions` (`වර්ෂය`,`ආසනය`, `කොට්ඨාශය`, `වසම`, `වර්ගය`, `සම්බන්ධීකාරක`, `දුරකථනය`, `යෝජනාව`, `තත්වය`) VALUES ('" & yeartxt.Text & "', '" & seatcombo.Text & "', '" & divisioncombo.Text & "''" & GNDivisiontxt.Text & "', '" & categorycombo.Text & "', '" & coordinatortxt.Text & "', '" & mobiletext.Text & "', '" & suggestiontxt.Text & "', '" & completecombo.Text & "');"

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
            seatcombo.Text = vseat
            divisioncombo.Text = vdivision
            GNDivisiontxt.Text = vgndivision
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
                        vseat = .Rows(i).Cells("ආසනය").Value.ToString
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
            sqlcmd.CommandText = "SELECT * FROM Suggestions WHERE වර්ෂය LIKE '%" & Searchtb.Text & "%' OR ආසනය LIKE '%" & Searchtb.Text & "%' OR කොට්ඨාශය LIKE '%" & Searchtb.Text & "%' OR 'වසම' LIKE '%" & Searchtb.Text & "%' OR වර්ගය LIKE '%" & Searchtb.Text & "%' OR සම්බන්ධීකාරක LIKE '%" & Searchtb.Text & "%' OR දුරකථනය LIKE '%" & Searchtb.Text & "%' OR යෝජනාව LIKE '%" & Searchtb.Text & "%' OR තත්වය LIKE '%" & Searchtb.Text & "%'"
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

    Private Sub divisioncombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles divisioncombo.SelectedIndexChanged
        If divisioncombo.SelectedIndex = -1 Or divisioncombo.SelectedIndex = 17 Then
            GNDivisiontxt.Items.Clear()
            GNDivisiontxt.Items.AddRange(New String() {"වෙනත්", "දිවුරුම්පිටිය", "හේවායින්න", "කලටුවාව නැගෙනහිර", "ගැටහැත්ත", "වලවිට", "මීන්නාන", "බෝපැත්ත දිද්ද", "තොරණකඩ", "ගනේගොඩ", "ඉද්දමල්ගොඩ", "හුලද්දුව", "කලටුවාව බටහිර", "උඩුවක", "නාපාවල", "පැල්පිටිය", "උඩුමත්ත", "විලේගොඩ", "විලේගොඩ   නැගෙනහිර", "ඇහැලියගොඩවත්ත", "අස්ගගුල  උතුර", "කැන්දගමුව ඉහලගම", "මොරගල", "බුළුගහපිටිය", "යකුදාගොඩ", "කැන්දන්ගමුව", "අස්ගගුල  දකුණ", "මාහර", "මාහිංගොඩ", "නාකන්දල", "වියලගොඩ", "කැන්දන්ගමුවපහලගම", "පලිගල", "මියනකොලතැන්න", "මිටිපොල", "මාපොට", "කරඳන උතුර", "කිරිපෝරුව", "නැදුරණ", "ඇරැපොළ", "සිරිසමන්පුර", "නුගදණ්ඩ", "කරඳන බටහිර", "කරඳන දකුණ", "හිඳුරන්ගල", "අමුහේන් කන්ද", "පත්බේරිය බටහිර", "පත්බේරිය", "මෙනේරිපිටිය", "පරකඩුව", "බෝධිමලුව", "තලාවිටිය", "පොහොරබාව", "පුස්සැල්ල", "දෙවිපහල", "ඇඳිරියන්වල", "එරත්න", "අඩවිකන්ද", "ලස්සකන්ද", "සුදුගල", "එක්නැලිගොඩ උතුර", "කීරගල", "කඳන්ගොඩ", "මිල්ලවිටිය", "මියනදෙනිය", "ඕවිටිගම", "තෙප්පනාව", "තෙප්පනාව ඉහලගම", "පහල කුරුවිට", "කඳන්ගොඩ දකුණ", "වතුයාය", "උඩකඩ", "එක්නැලිගොඩ", "දෙල්ගමුව", "කුරුවිට", "වලඳුර", "නඩුකාරදෙනිය", "කාහේන්ගම", "පාතගම", "තෙප්පනාව පහලගම", "කිතුල්පෙ", "කාහේන්ගම  බටහිර", "කොස්ගොඩ", "ගාලුකාගම", "එල්ලාවල", "දෙහෙරගොඩ", "කනුග්ගල්ල", "එල්ලාවල   පහලගම", "මුදුන්කොටුව", "අකුරණ", "කිරිඇල්ල", "හන්දුන්කන්ද", "එපිටවල", "මුණසිංහපුර", "යටිපවිව", "ඇල්ලගාව", "ඉඩන්ගොඩ", "මාටුවාගල", "දොඩම්පෙ බටහිර", "දොඩම්පෙ", "හොලීපිටිය", "ගිලීමලේ උතුර", "කැටවල", "ගුරුළුවාන", "සිරිපාගම", "ශ්‍රී පලාබද්දල", "මාපලාන", "කුඩාව", "දෙහෙනකන්ද", "බඹරබොටුව", "අළුපොල", "බලකොටුන්න", "හපුගස්තැන්න", "රත්ගම", "ගිලීමලේ දකුණ", "පාගොඩ", "ඇඹුල්දෙණිය", "මලංගම", "අමුතාගොඩ", "කහංගම", "කැටලියන්පල්ල", "නව නගරය", "ඇල්ලෙගෙදර", "මල්වල", "දුරේක්කන්ද", "ගලබඩ", "ගල්ලෑල්ල", "අමුණුතැන්න", "‍කෙම්පනා වත්ත", "ගුරුබැවිලාගම", "බටේවෙල", "හෙට්ටිකන්ද", "බානගොඩ", "හීන්බැරැණ්ඩුව", "එගොඩ මල්වල", "මිහිටිය", "කොස්පැලවින්න", "වෙරළුප", "දේවාලයගාව", "මුවගම", "ර/නගරය බටහිර", "ර/නගරය උතුර", "මිහිඳුගම", "මහවල", "ගොඩිගමුව", "රත්නපුර නගරය", "මුද්දුව නැගෙනහිර", "සමගිපුර", "ඇත්ඔය", "මුද්දුව", "බටුගෙද‍ර", "අංගම්මන", "තිරිවානකැටිය", "කොලඳගල", "රාවනාකන්ද", "ගල්ලෙනකන්ද", "කට්ටඩිකන්ද", "උතුරු වලේබොඩ", "බෙල්ලන්කන්ද", "බොල්තුඹේ", "පින්නවල", "උඩගම", "මද්දේගම", "පිඩලිගන්නාවෙල", "ඉහලගලගම", "විහාරවෙල", "කුඹුරුතැනිවල", "බෙලිහුල්ඔය", "යක්දෙහිවල", "මුත්තෙටිටුවෙගම", "පුවක්ගහවෙල", "බුදුන්වෙල", "හල්පෙ", "නිත්තමලුව", "කුඹල්ගම", "කිංචිගුණේ", "කරගස්තලාව", "සිලෝගම", "ඉඹුල්පෙ", "පස්සරමුල්ල", "අලකොලඇල්ල", "අටවක්වෙල", "කනතිරියන්වෙල", "පල්ලෙවෙල", "ගුරුබැවිල", "පන්දෙනිය", "පාගල්ඕවිට", "මද්දෙතලාව", "අමුවතුගොඩ", "මැදගෙදරගොඩ", "අලුත්නුවර", "තොටපල්ල", "උළුපිටිය", "මාමල්ගහ", "වෙලන්හින්න", "අමුපිටිය", "නළුවෙල", "වෑගපිටිය", "මොරහැල", "ඕලුගංතොට", "රත්මලවින්න", "කරදියමුල්ල", "හතරබා‍‍ගේ", "තුංකිඳ", "එගොඩ වලේබොඩ", "වෙලේකුඹුර", "විජිනත් කුඹුර", "බුලත්ගම", "තුඹගොඩ", "කිරිඳිගල", "යහලවෙල", "බටුගම්මන", "අල්දොර", "වටවල", "මුල්ගම", "රජවක", "බෝවත්ත", "විකිළිය", "තොටුපලතැන්න", "කිරිමැටිතැන්න", "දෙහිගස්තලාව", "බලංගොඩ නගරය", "බලංගොඩ", "ජාසිංකන්ද", "මැද්දෙකන්ද", "ඇල්ලවත්ත", "පොල්වතුගොඩ", "දුරකන්ද", "රාස්සගල", "අම්පිටියාවත්ත", "මස්සැන්න", "පෙට්ටිගල", "පල්ලෙකන්ද", "ඇල්ලෙපොල", "තලංගම", "කුමාරගම", "දාමහන", "ගොඩකුඹුර", "ඉඹුලමුර", "මහවෙලතැන්න", "‍තෙලඳිරිය", "මාවෙල", "වෙළ‍‍‍ගේ", "ගවරත්හේන", "හොරකැටිය", "පොල්වත්තහේන", "මැටිහක්වල", "මල්මීකන්ද", "මීගහවෙල", "කැන්දකැටිය", "පැලැන්දකන්ද", "මාදොල", "උඩවෙල", "ඕපනායක", "උතුරු හුණුවල", "හල්ලින්න", "දකුණු හුණුවල", "දන්දෙනිය", "වල්ලකැටිය", "අකරැල්ල", "හත්තැල්ල", "හත්තැල්ල එගොඩ", "බටදුර", "ලියනගොඩ", "ගල්කන්ද", "ගෝණකුඹුර", "බෝපැත්ත", "බැරැණ්ඩුව", "නාරංගොඩ", "කුට්ටාපිටිය", "ගනේගම", "ගොඩගම", "දොඹගස්වින්න", "සන්නස්ගම", "දිප්පිටිගල", "ලෙල්ලෝපිටිය", "වැලිමළුව", "ගල්ලින්න", "මාවුදැල්ල", "මාරපන", "පහල හකමුව", "ඉහල හකමුව", "පොත්තකන්ද", "නිරල්ගම", "අලුපොත", "දේවාලේගම", "දෙනවක පාතකඩ", "රිල්හේන", "පහල බෝපිටිය", "පැල්මඩුල්ල නගරය", "උඩතුල", "වාරිගම", "දෙනවන උඩකඩ", "පැල්මඩුල්ල ගම", "ඉහල බෝපිටිය", "හල්පාවල", "කපුහේන්තොට", "පනාවැන්න", "බොරාල", "මොරතොට", "කට්ටංගෙ", "පොරෝණුව", "කහවත්ත", "දම්බුළුවන", "රද්දැල්ල", "හල්දොල", "කරංගොඩ", "සමන්ගම", "කෙහෙල්ඕවිටිගම", "වේරගම", "දෙල්ලබඩ", "ඇලපාත", "පල්ලෙගෙදර", "කොටාමුල්ල", "අමුවල", "ගඟුල්විටිය", "නිරිඇල්ල", "පලාවෙල", "බටකඩ", "දිගාන", "මගුරුගොඩ", "හංගමුව", "දුම්බර", "කැටේපොල", "දෙතබඩකන්ද", "මඩබද්දර", "පහල ගලතුර", "ගලතුර", "සිංහලගොඩ", "ගංගොඩකන්ද", "දුම්බර මානාන", "ගවරගිරිය", "පිටකන්ද", "පල්ලෙකඩ", "ඇල්ලහේන", "විතානගම", "අයගම", "උඩුගල උතුර", "කොළඹෑව", "උඩුගල", "පරගල", "පිඹුර", "නිකගොඩ", "කොඩිප්පිලි කන්ද", "ජාතුවංගොඩ", "මීපාගම", "කුකුලේගම උතුර", "සමන්පුර", "කලවාන බටහිර", "තපස්සර කන්ද", "කොස්වත්ත", "කුකුලේගම දකුණ", "පිටිගල කන්ද", "වැවගම", "දවුගලගම", "වෙම්බියගොඩ", "කලවාන නැගෙනහිර", "වේවැල්කඳුර", "හඟරංගල", "වතුරාව", "දෙල්ගොඩ නැගෙනහිර", "දෙල්ගොඩ බටහිර", "වැද්දාගල බටහිර", "වැද්දාගල නැගෙනහිර", "කුඩුමිරිය", "තණබෙල", "රඹුක", "දොලේකන්ද", "කත්ලාන", "ගඟලගමුව", "පනාපොල", "කුඩව", "හපුගොඩ", "පොතුපිටිය උතුර", "පොතුපිටිය දකුණ", "ඉළුඹකන්ද", "පාතකඩ", "නොරගල්ල", "දොඹගම්මන", "එරබද්ද", "කිරිබත්ගල", "වන්නියවත්ත", "වටාපොත", "තුත්තිරිපිටිය", "නිවිතිගල", "යක්දෙහිවත්ත", "වතුපිටිය", "හොරංගල", "පහල කරවිට", "උඩ කරවිට", "පිංකන්ද", "හල්කඳලිය", "සිදුරුපිටිය", "දොලොස්වල", "කොළඹගම", "දොලොස්වල කන්ද", "පෑබොටුව", "හොරණෑකාර කන්ද", "දෙල්වල", "පනහැටගල", "යායින්න", "බටහිර නුගවෙල", "නැගෙනහිර නුගවෙල", "වැල්ලදුර", "බුංගිරිය", "උඩහවුපෙ", "යටාගර", "මඩලගම ජනපදය", "උතුරු පනාපිටිය", "නාඹුළුව", "අටකළන්පන්න", "පහමුණුපන්න", "කලල්ඇල්ල", "දකුණු පනාපිටිය", "ගබ්බෙල", "ඇන්දාන", "මඩලගම", "බටහිර මියනවිට", "නැගෙනහිර මියනවිට", "කිරණෝදාගම", "පන්නිල", "කොටකෙතන", "දිඹුල්වල", "හපුරුදෙනිය", "පනාවල", "බුළුවාන", "මාකඳුර", "ඇමිටියගොඩ", "රිදීවිට", "මාරගල", "හිරමඩගම", "මාදම්පෙ උතුර", "කව්ඩුවාව", "මාදම්පෙ දකුණ", "හොරමුල", "වෙරළුගහමුල", "අල්පිටිය", "ගලහිටිය", "කෝම්පිටිය", "මල්වත්ත", "වේරහැර බටහිර", "වේරහැර නැගෙනහිර", "ගොඩකවෙල", "වරායාය", "නියංගම", "බඹරගස්තැන්න", "බලවින්න උතුර", "බලවින්න බටහිර", "කපුහේන්තැන්න", "මාවතලන්ද", "මැද්දෙගම", "මස්ඉඹුල", "රක්වාන නගරය", "කොට්ටල", "රක්වාන දකුණ", "රක්වාන උතුර", "යහලවෙල", "බිබිලේගම  බටහිර", "බිබිලේගම  නැගෙනහිර", "තඹගමුව බටහිර", "දඹවින්න", "බලවින්න  නැගෙනහිර", "තඹගමුව නැගෙනහිර", "මහගම බටහිර", "මහගම නැගෙනහිර", "පරගහමඩිත්ත", "ඉළුක්කුඹුර", "පනාන", "ගල්ගොඩගම", "කෝන්ගස්තැන්න", "බෝපිටිගොඩ", "ගංගොඩගම", "මැදගංඔය", "උඩරංවල", "වැලිගෙපොල", "උඩගංගොඩ", "බෙලිමාලියද්ද", "හඳගිරිය", "හඳගිරිගොඩ", "පලුගහවෙල", "ඌරාවල", "කොට්ටිඹුල්වල", "තලගස්කන්ද", "රංවල", "අම්මඩුව", "එලමල්පෙ", "තැන්නහේන", "කලටුව කන්ද", "බදුල්ලේගම", "හටංගල", "බඹරගල", "පුස්සතො‍ට", "මඩවලලන්ද", "ගල්පාය", "මුත්තෙට්ටුපොල", "පල්ලෙබැද්ද", "තිත්තවැල්පත", "පනහඩුව", "උඩවල‍ව", "තිඹොල්කැටිය", "කොළඹගෙආර", "සංඛපාල", "මිරිස්වැල්පත", "ආඳළුව", "මඩුවන්වෙල", "උඩවලවෙ යාය 2", "රත්කැරැව්ව", "ග‍ඟේයාය", "කැටගල්ආර", "නින්දගම්පැලැස්ස", "රංචමඩම", "පනාමුර", "කෝන්කටුව", "ඇඹිලිපිටිය උඩගම", "හිඟුරආර", "කළගෙඩිආර", "මොරකැටිය", "ඇඹිලිපිටිය පල්ලෙගම", "ඇඹිලිපිටිය නව නගරය", "යෝධගම", "මොදරවාන", "සුදුගල", "වලල්ගොඩ", "ජදුර", "දියපොට", "මුල්ඇඩියාවල", "තෝරකොළයාය", "කුඹුගොඩආර", "හිඟුර", "හල්මිල්ලකැටිය", "තුංකම", "හාගල", "කුට්ටිගල", "ජුලංගැටේ", "පදලංගල", "බුලුතොට", "රංහොට්කන්ද", "යක්මඩිත්ත", "හෙලඋඩකන්ද", "හේනැග්ගොඩ", "කඹුරුගමුව", "දඹේමඩ", "වෙලේවතුගොඩ", "ඇරැපෝරුව", "විජේරිය", "පොද්දන", "ඉත්තකන්ද", "බුත්කන්ද", "කොලොන්න", "මඩුවන්වෙල පැරණිගම", "නන්දනගම", "අඹගහයාය", "කෑල්ල", "බොරළුවගෙඅයින", "උල්ලිඳුවාව", "පුපුලකැටිය", "හබ්බෙලිආර", "වලකඩ", "කෝප්පකන්ද", "දාපනේ", "දොරපනේ", "‍මොරවාඩිය", "ඕමල්පේ", "කැම්පනේ", "කල්තොට", "මැද​බැද්ද", "තන්ජන්තැන්න", "නෙළුයාය", "කූරගල", "උග්ගල් කල්තොට වම් ඉවුර වම", "උග්ගල් කල්තොට වම් ඉවුර දකුණ", "දියවින්න", "වැලිපතයාය", "මොලමුරේ", "කළුපේඩිගම", "කෝන්ගහමංකඩ"})
        End If

        'nivithigala gnd
        If divisioncombo.SelectedIndex = 0 Then
            GNDivisiontxt.Items.Clear()
            GNDivisiontxt.Items.AddRange(New String() {"පාතකඩ", "නොරගල්ල", "දොඹගම්මන", "එරබද්ද", "කිරිබත්ගල", "වන්නියවත්ත", "වටාපොත", "තුත්තිරිපිටිය", "නිවිතිගල", "යක්දෙහිවත්ත", "වතුපිටිය", "හොරංගල", "පහල කරවිට", "උඩ කරවිට", "පිංකන්ද", "හල්කඳලිය", "සිදුරුපිටිය", "දොලොස්වල", "කොළඹගම", "දොලොස්වල කන්ද", "පෑබොටුව", "හොරණෑකාර කන්ද", "දෙල්වල", "පනහැටගල"})
        End If

        'eheliyagoda gnd
        If divisioncombo.SelectedIndex = 1 Then
            GNDivisiontxt.Items.Clear()
            GNDivisiontxt.Items.AddRange(New String() {"දිවුරුම්පිටිය", "හේවායින්න", "කලටුවාව නැගෙනහිර", "ගැටහැත්ත", "වලවිට", "මීන්නාන", "බෝපැත්ත දිද්ද", "තොරණකඩ", "ගනේගොඩ", "ඉද්දමල්ගොඩ", "හුලද්දුව", "කලටුවාව බටහිර", "උඩුවක", "නාපාවල", "පැල්පිටිය", "උඩුමත්ත", "විලේගොඩ", "විලේගොඩ නැගෙනහිර", "ඇහැලියගොඩවත්ත", "අස්ගගුල  උතුර", "කැන්දගමුව ඉහලගම", "මොරගල", "බුළුගහපිටිය", "යකුදාගොඩ", "කැන්දන්ගමුව", "අස්ගගුල  දකුණ", "මාහර", "මාහිංගොඩ", "නාකන්දල", "වියලගොඩ", "කැන්දන්ගමුවපහලගම", "පලිගල", "මියනකොලතැන්න", "මිටිපොල", "මාපොට", "කරඳන උතුර", "කිරිපෝරුව", "නැදුරණ", "ඇරැපොළ", "සිරිසමන්පුර", "නුගදණ්ඩ", "කරඳන බටහිර", "කරඳන දකුණ", "හිඳුරන්ගල"})
        End If

        'kuruwita gnd
        If divisioncombo.SelectedIndex = 2 Then
            GNDivisiontxt.Items.Clear()
            GNDivisiontxt.Items.AddRange(New String() {"අමුහේන් කන්ද", "පත්බේරිය බටහිර", "පත්බේරිය", "මෙනේරිපිටිය", "පරකඩුව", "බෝධිමලුව", "තලාවිටිය", "පොහොරබාව", "පුස්සැල්ල", "දෙවිපහල", "ඇඳිරියන්වල", "එරත්න", "අඩවිකන්ද", "ලස්සකන්ද", "සුදුගල", "එක්නැලිගොඩ උතුර", "කීරගල", "කඳන්ගොඩ", "මිල්ලවිටිය", "මියනදෙනිය", "ඕවිටිගම", "තෙප්පනාව", "තෙප්පනාව ඉහලගම", "පහල කුරුවිට", "කඳන්ගොඩ දකුණ", "වතුයාය", "උඩකඩ", "එක්නැලිගොඩ", "දෙල්ගමුව", "කුරුවිට", "වලඳුර", "නඩුකාරදෙනිය", "කාහේන්ගම", "පාතගම", "තෙප්පනාව පහලගම", "කිතුල්පෙ", "කාහේන්ගම  බටහිර", "කොස්ගොඩ", "ගාලුකාගම"})
        End If

        'kiriella gnd
        If divisioncombo.SelectedIndex = 3 Then
            GNDivisiontxt.Items.Clear()
            GNDivisiontxt.Items.AddRange(New String() {"එල්ලාවල", "දෙහෙරගොඩ", "කනුග්ගල්ල", "එල්ලාවල   පහලගම", "මුදුන්කොටුව", "අකුරණ", "කිරිඇල්ල", "හන්දුන්කන්ද", "එපිටවල", "මුණසිංහපුර", "යටිපවිව", "ඇල්ලගාව", "ඉඩන්ගොඩ", "මාටුවාගල", "දොඩම්පෙ බටහිර", "දොඩම්පෙ", "හොලීපිටිය"})
        End If

        'ratnapura gnd
        If divisioncombo.SelectedIndex = 4 Then
            GNDivisiontxt.Items.Clear()
            GNDivisiontxt.Items.AddRange(New String() {"ගිලීමලේ උතුර", "කැටවල", "ගුරුළුවාන", "සිරිපාගම", "ශ්‍රී පලාබද්දල", "මාපලාන", "කුඩාව", "දෙහෙනකන්ද", "බඹරබොටුව", "අළුපොල", "බලකොටුන්න", "හපුගස්තැන්න", "රත්ගම", "ගිලීමලේ දකුණ", "පාගොඩ", "ඇඹුල්දෙණිය", "මලංගම", "අමුතාගොඩ", "කහංගම", "කැටලියන්පල්ල", "නව නගරය", "ඇල්ලෙගෙදර", "මල්වල", "දුරේක්කන්ද", "ගලබඩ", "ගල්ලෑල්ල", "අමුණුතැන්න", "‍කෙම්පනා වත්ත", "ගුරුබැවිලාගම", "බටේවෙල", "හෙට්ටිකන්ද", "බානගොඩ", "හීන්බැරැණ්ඩුව", "එගොඩ මල්වල", "මිහිටිය", "කොස්පැලවින්න", "වෙරළුප", "දේවාලයගාව", "මුවගම", "ර/නගරය බටහිර", "ර/නගරය උතුර", "මිහිඳුගම", "මහවල", "ගොඩිගමුව", "රත්නපුර නගරය", "මුද්දුව නැගෙනහිර", "සමගිපුර", "ඇත්ඔය", "මුද්දුව", "බටුගෙද‍ර", "අංගම්මන", "තිරිවානකැටිය", "කොලඳගල"})
        End If

        'ayagama gnd
        If divisioncombo.SelectedIndex = 5 Then
            GNDivisiontxt.Items.Clear()
            GNDivisiontxt.Items.AddRange(New String() {"දුම්බර", "කැටේපොල", "දෙතබඩකන්ද", "මඩබද්දර", "පහල ගලතුර", "ගලතුර", "සිංහලගොඩ", "ගංගොඩකන්ද", "දුම්බර මානාන", "ගවරගිරිය", "පිටකන්ද", "පල්ලෙකඩ", "ඇල්ලහේන", "විතානගම", "අයගම", "උඩුගල උතුර", "කොළඹෑව", "උඩුගල", "පරගල", "පිඹුර", "නිකගොඩ"})
        End If

        'kalawana gnd
        If divisioncombo.SelectedIndex = 6 Then
            GNDivisiontxt.Items.Clear()
            GNDivisiontxt.Items.AddRange(New String() {"කොඩිප්පිලි කන්ද", "ජාතුවංගොඩ", "මීපාගම", "කුකුලේගම උතුර", "සමන්පුර", "කලවාන බටහිර", "තපස්සර කන්ද", "කොස්වත්ත", "කුකුලේගම දකුණ", "පිටිගල කන්ද", "වැවගම", "දවුගලගම", "වෙම්බියගොඩ", "කලවාන නැගෙනහිර", "වේවැල්කඳුර", "හඟරංගල", "වතුරාව", "දෙල්ගොඩ නැගෙනහිර", "දෙල්ගොඩ බටහිර", "වැද්දාගල බටහිර", "වැද්දාගල නැගෙනහිර", "කුඩුමිරිය", "තණබෙල", "රඹුක", "දොලේකන්ද", "කත්ලාන", "ගඟලගමුව", "පනාපොල", "කුඩව", "හපුගොඩ", "පොතුපිටිය උතුර", "පොතුපිටිය දකුණ", "ඉළුඹකන්ද"})
        End If

        'elepatha gnd
        If divisioncombo.SelectedIndex = 7 Then
            GNDivisiontxt.Items.Clear()
            GNDivisiontxt.Items.AddRange(New String() {"කහවත්ත", "දම්බුළුවන", "රද්දැල්ල", "හල්දොල", "කරංගොඩ", "සමන්ගම", "කෙහෙල්ඕවිටිගම", "වේරගම", "දෙල්ලබඩ", "ඇලපාත", "පල්ලෙගෙදර", "කොටාමුල්ල", "අමුවල", "ගඟුල්විටිය", "නිරිඇල්ල", "පලාවෙල", "බටකඩ", "දිගාන", "මගුරුගොඩ", "හංගමුව"})
        End If

        'kahawatta gnd
        If divisioncombo.SelectedIndex = 8 Then
            GNDivisiontxt.Items.Clear()
            GNDivisiontxt.Items.AddRange(New String() {"යායින්න", "බටහිර නුගවෙල", "නැගෙනහිර නුගවෙල", "වැල්ලදුර", "බුංගිරිය", "උඩහවුපෙ", "යටාගර", "මඩලගම ජනපදය", "උතුරු පනාපිටිය", "නාඹුළුව", "අටකළන්පන්න", "පහමුණුපන්න", "කලල්ඇල්ල", "දකුණු පනාපිටිය", "ගබ්බෙල", "ඇන්දාන", "මඩලගම", "බටහිර මියනවිට", "නැගෙනහිර මියනවිට", "කිරණෝදාගම", "පන්නිල"})
        End If

        'pelmadulla gnd
        If divisioncombo.SelectedIndex = 9 Then
            GNDivisiontxt.Items.Clear()
            GNDivisiontxt.Items.AddRange(New String() {"ගෝණකුඹුර", "බෝපැත්ත", "බැරැණ්ඩුව", "නාරංගොඩ", "කුට්ටාපිටිය", "ගනේගම", "ගොඩගම", "දොඹගස්වින්න", "සන්නස්ගම", "දිප්පිටිගල", "ලෙල්ලෝපිටිය", "වැලිමළුව", "ගල්ලින්න", "මාවුදැල්ල", "මාරපන", "පහල හකමුව", "ඉහල හකමුව", "පොත්තකන්ද", "නිරල්ගම", "අලුපොත", "දේවාලේගම", "දෙනවක පාතකඩ", "රිල්හේන", "පහල බෝපිටිය", "පැල්මඩුල්ල නගරය", "උඩතුල", "වාරිගම", "දෙනවන උඩකඩ", "පැල්මඩුල්ල ගම", "ඉහල බෝපිටිය", "හල්පාවල", "කපුහේන්තොට", "පනාවැන්න", "බොරාල", "මොරතොට", "කට්ටංගෙ", "පොරෝණුව"})
        End If

        'balangoda gnd
        If divisioncombo.SelectedIndex = 10 Then
            GNDivisiontxt.Items.Clear()
            GNDivisiontxt.Items.AddRange(New String() {"එගොඩ වලේබොඩ", "වෙලේකුඹුර", "විජිනත් කුඹුර", "බුලත්ගම", "තුඹගොඩ", "කිරිඳිගල", "යහලවෙල", "බටුගම්මන", "අල්දොර", "වටවල", "මුල්ගම", "රජවක", "බෝවත්ත", "විකිළිය", "තොටුපලතැන්න", "කිරිමැටිතැන්න", "දෙහිගස්තලාව", "බලංගොඩ නගරය", "බලංගොඩ", "ජාසිංකන්ද", "මැද්දෙකන්ද", "ඇල්ලවත්ත", "පොල්වතුගොඩ", "දුරකන්ද", "රාස්සගල", "අම්පිටියාවත්ත", "මස්සැන්න", "පෙට්ටිගල", "පල්ලෙකන්ද", "ඇල්ලෙපොල", "තලංගම", "කුමාරගම", "දාමහන", "ගොඩකුඹුර", "ඉඹුලමුර", "මහවෙලතැන්න", "‍තෙලඳිරිය", "මාවෙල", "වෙළ‍‍‍ගේ", "ගවරත්හේන", "හොරකැටිය"})
        End If

        'imbulpe gnd
        If divisioncombo.SelectedIndex = 11 Then
            GNDivisiontxt.Items.Clear()
            GNDivisiontxt.Items.AddRange(New String() {"රාවනාකන්ද", "ගල්ලෙනකන්ද", "කට්ටඩිකන්ද", "උතුරු වලේබොඩ", "බෙල්ලන්කන්ද", "බොල්තුඹේ", "පින්නවල", "උඩගම", "මද්දේගම", "පිඩලිගන්නාවෙල", "ඉහලගලගම", "විහාරවෙල", "කුඹුරුතැනිවල", "බෙලිහුල්ඔය", "යක්දෙහිවල", "මුත්තෙටිටුවෙගම", "පුවක්ගහවෙල", "බුදුන්වෙල", "හල්පෙ", "නිත්තමලුව", "කුඹල්ගම", "කිංචිගුණේ", "කරගස්තලාව", "සිලෝගම", "ඉඹුල්පෙ", "පස්සරමුල්ල", "අලකොලඇල්ල", "අටවක්වෙල", "කනතිරියන්වෙල", "පල්ලෙවෙල", "ගුරුබැවිල", "පන්දෙනිය", "පාගල්ඕවිට", "මද්දෙතලාව", "අමුවතුගොඩ", "මැදගෙදරගොඩ", "අලුත්නුවර", "තොටපල්ල", "උළුපිටිය", "මාමල්ගහ", "වෙලන්හින්න", "අමුපිටිය", "නළුවෙල", "වෑගපිටිය", "මොරහැල", "ඕලුගංතොට", "රත්මලවින්න", "කරදියමුල්ල", "හතරබා‍‍ගේ", "තුංකිඳ"})
        End If

        'opanayaka gnd
        If divisioncombo.SelectedIndex = 12 Then
            GNDivisiontxt.Items.Clear()
            GNDivisiontxt.Items.AddRange(New String() {"පොල්වත්තහේන", "මැටිහක්වල", "මල්මීකන්ද", "මීගහවෙල", "කැන්දකැටිය", "පැලැන්දකන්ද", "මාදොල", "උඩවෙල", "ඕපනායක", "උතුරු හුණුවල", "හල්ලින්න", "දකුණු හුණුවල", "දන්දෙනිය", "වල්ලකැටිය", "අකරැල්ල", "හත්තැල්ල", "හත්තැල්ල එගොඩ", "බටදුර", "ලියනගොඩ", "ගල්කන්ද"})
        End If

        'godakawela gnd
        If divisioncombo.SelectedIndex = 13 Then
            GNDivisiontxt.Items.Clear()
            GNDivisiontxt.Items.AddRange(New String() {"කොටකෙතන", "දිඹුල්වල", "හපුරුදෙනිය", "පනාවල", "බුළුවාන", "මාකඳුර", "ඇමිටියගොඩ", "රිදීවිට", "මාරගල", "හිරමඩගම", "මාදම්පෙ උතුර", "කව්ඩුවාව", "මාදම්පෙ දකුණ", "හොරමුල", "වෙරළුගහමුල", "අල්පිටිය", "ගලහිටිය", "කෝම්පිටිය", "මල්වත්ත", "වේරහැර බටහිර", "වේරහැර නැගෙනහිර", "ගොඩකවෙල", "වරායාය", "නියංගම", "බඹරගස්තැන්න", "බලවින්න උතුර", "බලවින්න බටහිර", "කපුහේන්තැන්න", "මාවතලන්ද", "මැද්දෙගම", "මස්ඉඹුල", "රක්වාන නගරය", "කොට්ටල", "රක්වාන දකුණ", "රක්වාන උතුර", "යහලවෙල", "බිබිලේගම  බටහිර", "බිබිලේගම  නැගෙනහිර", "තඹගමුව බටහිර", "දඹවින්න", "බලවින්න  නැගෙනහිර", "තඹගමුව නැගෙනහිර", "මහගම බටහිර", "මහගම නැගෙනහිර"})
        End If

        'embilipitiya gnd
        If divisioncombo.SelectedIndex = 14 Then
            GNDivisiontxt.Items.Clear()
            GNDivisiontxt.Items.AddRange(New String() {"පල්ලෙබැද්ද", "තිත්තවැල්පත", "පනහඩුව", "උඩවල‍ව", "තිඹොල්කැටිය", "කොළඹගෙආර", "සංඛපාල", "මිරිස්වැල්පත", "ආඳළුව", "මඩුවන්වෙල", "උඩවලවෙ යාය 2", "රත්කැරැව්ව", "ග‍ඟේයාය", "කැටගල්ආර", "නින්දගම්පැලැස්ස", "රංචමඩම", "පනාමුර", "කෝන්කටුව", "ඇඹිලිපිටිය උඩගම", "හිඟුරආර", "කළගෙඩිආර", "මොරකැටිය", "ඇඹිලිපිටිය පල්ලෙගම", "ඇඹිලිපිටිය නව නගරය", "යෝධගම", "මොදරවාන", "සුදුගල", "වලල්ගොඩ", "ජදුර", "දියපොට", "මුල්ඇඩියාවල", "තෝරකොළයාය", "කුඹුගොඩආර", "හිඟුර", "හල්මිල්ලකැටිය", "තුංකම", "හාගල", "කුට්ටිගල", "ජුලංගැටේ", "පදලංගල"})
        End If

        'kolonna gnd
        If divisioncombo.SelectedIndex = 15 Then
            GNDivisiontxt.Items.Clear()
            GNDivisiontxt.Items.AddRange(New String() {"බුලුතොට", "රංහොට්කන්ද", "යක්මඩිත්ත", "හෙලඋඩකන්ද", "හේනැග්ගොඩ", "කඹුරුගමුව", "දඹේමඩ", "වෙලේවතුගොඩ", "ඇරැපෝරුව", "විජේරිය", "පොද්දන", "ඉත්තකන්ද", "බුත්කන්ද", "කොලොන්න", "මඩුවන්වෙල පැරණිගම", "නන්දනගම", "අඹගහයාය", "කෑල්ල", "බොරළුවගෙඅයින", "උල්ලිඳුවාව", "පුපුලකැටිය", "හබ්බෙලිආර", "වලකඩ", "කෝප්පකන්ද", "දාපනේ", "දොරපනේ", "‍මොරවාඩිය", "ඕමල්පේ", "කැම්පනේ"})
        End If

        'weligepola gnd
        If divisioncombo.SelectedIndex = 16 Then
            GNDivisiontxt.Items.Clear()
            GNDivisiontxt.Items.AddRange(New String() {"පරගහමඩිත්ත", "ඉළුක්කුඹුර", "පනාන", "ගල්ගොඩගම", "කෝන්ගස්තැන්න", "බෝපිටිගොඩ", "ගංගොඩගම", "මැදගංඔය", "උඩරංවල", "වැලිගෙපොල", "උඩගංගොඩ", "බෙලිමාලියද්ද", "හඳගිරිය", "හඳගිරිගොඩ", "පලුගහවෙල", "ඌරාවල", "කොට්ටිඹුල්වල", "තලගස්කන්ද", "රංවල", "අම්මඩුව", "එලමල්පෙ", "තැන්නහේන", "කලටුව කන්ද", "බදුල්ලේගම", "හටංගල", "බඹරගල", "පුස්සතො‍ට", "මඩවලලන්ද", "ගල්පාය", "මුත්තෙට්ටුපොල"})
        End If


    End Sub
End Class