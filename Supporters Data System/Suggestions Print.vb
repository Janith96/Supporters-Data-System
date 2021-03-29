Public Class Suggestions_Print
    Private Sub Suggestions_Print_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
End Class