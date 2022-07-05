Public Class Frm_Detail_Attendance_Admin
    Inherits System.Web.UI.Page

    Dim oSelect As New SelectBase
    Dim oUpdate As New UpdateBase
    Dim message As String
    Dim sb As New System.Text.StringBuilder()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Session("_idx") = Request.QueryString("idx").ToString
            bindData()
        End If
    End Sub
    Sub bindData()
        Dim dtData As New DataTable
        dtData = oSelect.f_SEL_ATTENDANCE_ADMIN_DETAIL(Session("_idx").ToString)
        If dtData.Rows.Count > 0 Then
            lblEmployeeKey2.Text = dtData.Rows(0)("EmployeeKey").ToString()
            lblEmployeeName2.Text = dtData.Rows(0)("EmployeeName").ToString()
            lblEntity2.Text = dtData.Rows(0)("Entity").ToString()
            lblAccessCardNo2.Text = dtData.Rows(0)("AccessCardNo").ToString()
            txtFirstSignIn2.Text = dtData.Rows(0)("FirstSignInDate").ToString()
            txtTimeSignIn2.Text = dtData.Rows(0)("FirstSignInTime").ToString()
            txtSignOut2.Text = dtData.Rows(0)("LastSignOutDate").ToString()
            txtTimeSignOut.Text = dtData.Rows(0)("LastSignOutTime").ToString()
            lblMonth2.Text = dtData.Rows(0)("Months").ToString()
            lblDays.Text = dtData.Rows(0)("Days").ToString()
            lblTypeofDays2.Text = dtData.Rows(0)("Type_of_Days").ToString()
            lblArrivalStatus2.Text = dtData.Rows(0)("ArrivalStatus").ToString()
            lblTotalWorkingTime2.Text = dtData.Rows(0)("TotalWorkingTime").ToString()
            lblWorkingStatus2.Text = dtData.Rows(0)("WorkingStatus").ToString()
            lblisOvertime2.Text = dtData.Rows(0)("isOvertime").ToString()
            lblOvertime2.Text = dtData.Rows(0)("Overtime").ToString()
            LBL12Hours2.Text = dtData.Rows(0)("12HOURS").ToString()
        End If
    End Sub
    Sub textChangedDateTime()
        If txtFirstSignIn2.Text = "" Then
            message = "Date Sign In Can't be Empty"

            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(message)
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            Exit Sub
        End If

        If txtTimeSignIn2.Text = "" Then
            message = "Time Sign In Can't be Empty"

            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(message)
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            Exit Sub
        End If

        If txtSignOut2.Text = "" Then
            message = "Date Sign Out Can't be Empty"

            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(message)
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            Exit Sub
        End If

        If txtTimeSignOut.Text = "" Then
            message = "Time Sign Out Can't be Empty"

            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(message)
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            Exit Sub
        End If

        If txtFirstSignIn2.Text <> txtSignOut2.Text Then
            message = "Date Sign In and Date Sign Out Must be Same"

            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(message)
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            Exit Sub
        End If

        If txtTimeSignIn2.Text > txtTimeSignOut.Text Then
            message = "Time Sign Out Must be Greater than or equal Time Sign In"

            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(message)
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            Exit Sub
        End If

        Dim DateSignIn As DateTime
        Dim DateSignOut As DateTime

        DateSignIn = txtFirstSignIn2.Text + " " + txtTimeSignIn2.Text
        DateSignOut = txtSignOut2.Text + " " + txtTimeSignOut.Text

        Dim dtSelect As New DataTable
        dtSelect = oSelect.f_SEL_GET_DETAIL_DAYS_ATTENDANCE(DateSignIn, DateSignOut)
        If dtSelect.Rows.Count > 0 Then
            lblMonth2.Text = dtSelect.Rows(0)("Months").ToString()
            lblDays.Text = dtSelect.Rows(0)("Days").ToString()
            lblTypeofDays2.Text = dtSelect.Rows(0)("Type_of_Days").ToString()
            lblArrivalStatus2.Text = dtSelect.Rows(0)("ArrivalStatus").ToString()
            lblTotalWorkingTime2.Text = dtSelect.Rows(0)("TotalWorkingTime").ToString()
            lblWorkingStatus2.Text = dtSelect.Rows(0)("WorkingStatus").ToString()
            lblisOvertime2.Text = dtSelect.Rows(0)("isOvertime").ToString()
            lblOvertime2.Text = dtSelect.Rows(0)("Overtime").ToString()
            LBL12Hours2.Text = dtSelect.Rows(0)("12HOURS").ToString()
        End If
    End Sub
    Protected Sub txtFirstSignIn2_TextChanged(sender As Object, e As EventArgs) Handles txtFirstSignIn2.TextChanged
        textChangedDateTime()
    End Sub

    Protected Sub txtSignOut2_TextChanged(sender As Object, e As EventArgs) Handles txtSignOut2.TextChanged
        textChangedDateTime()
    End Sub

    Protected Sub txtTimeSignIn2_TextChanged(sender As Object, e As EventArgs) Handles txtTimeSignIn2.TextChanged
        textChangedDateTime()
    End Sub

    Protected Sub txtTimeSignOut_TextChanged(sender As Object, e As EventArgs) Handles txtTimeSignOut.TextChanged
        textChangedDateTime()
    End Sub
    Public Sub Alert()
        Dim confirmValue As String = Request.Form("confirm_value")
    End Sub
    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim confirmValue As String = Request.Form("confirm_value")
        If confirmValue = "Yes" Then
            If txtFirstSignIn2.Text = "" Then
                message = "Date Sign In Can't be Empty"

                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                Exit Sub
            End If

            If txtTimeSignIn2.Text = "" Then
                message = "Time Sign In Can't be Empty"

                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                Exit Sub
            End If

            If txtSignOut2.Text = "" Then
                message = "Date Sign Out Can't be Empty"

                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                Exit Sub
            End If

            If txtTimeSignOut.Text = "" Then
                message = "Time Sign Out Can't be Empty"

                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                Exit Sub
            End If

            If txtFirstSignIn2.Text <> txtSignOut2.Text Then
                message = "Date Sign In and Date Sign Out Must be Same"

                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                Exit Sub
            End If

            If txtTimeSignIn2.Text > txtTimeSignOut.Text Then
                message = "Time Sign Out Must be Greater than or equal Time Sign In"

                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                Exit Sub
            End If
            Dim FirstSignInDate As DateTime
            Dim LastSignOutDate As DateTime
            FirstSignInDate = txtFirstSignIn2.Text + " " + txtTimeSignIn2.Text
            LastSignOutDate = txtSignOut2.Text + " " + txtTimeSignOut.Text
            'oUpdate.sp_UPDATE_ATTENDANCE(Session("_idx").ToString(), lblEmployeeKey2.Text,
            '                             FirstSignInDate, LastSignOutDate, lblMonth2.Text,
            '                             txtTimeSignIn2.Text, txtTimeSignOut.Text, lblDays.Text,
            '                             lblTypeofDays2.Text, lblArrivalStatus2.Text, lblTotalWorkingTime2.Text,
            '                             lblWorkingStatus2.Text, lblisOvertime2.Text, lblOvertime2.Text,
            '                             LBL12Hours2.Text, Session("UserID").ToString())

            message = "Update Data Success"

            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(message)
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        End If
    End Sub

End Class