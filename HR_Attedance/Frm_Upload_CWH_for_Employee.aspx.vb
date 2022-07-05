Imports System.Data.OleDb
Imports System.IO
Public Class Frm_Upload_CWH_for_Employee
    Inherits System.Web.UI.Page

    Dim sb As New System.Text.StringBuilder()
    Dim uploadid As Integer
    Dim oSelect As New SelectBase
    Dim oInsert As New InsertBase
    Dim FolderCWH As String = ConfigurationManager.AppSettings("FolderCWH").ToString
    Dim FolderApprove As String = ConfigurationManager.AppSettings("FolderApprove").ToString
    Dim FolderReject As String = ConfigurationManager.AppSettings("FolderReject").ToString
    Dim FolderCWH_UAT As String = ConfigurationManager.AppSettings("FolderCWH_UAT").ToString
    Dim FolderApprove_UAT As String = ConfigurationManager.AppSettings("FolderApprove_UAT").ToString
    Dim FolderReject_UAT As String = ConfigurationManager.AppSettings("FolderReject_UAT").ToString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'EXPIRED()
            LoadEmployee()

        End If
    End Sub
    Sub EXPIRED()
        Dim dtData As New DataTable
        dtData = oSelect.f_SEL_MST_EXPIRED(ddlQuarter.SelectedItem.Text, txtUserName.SelectedItem.Text, ddlYear.SelectedItem.Text)
        If dtData.Rows.Count > 0 Then
            lblstatExpired.Text = dtData.Rows(0)("STAT").ToString()
        End If

    End Sub
    Sub LoadEmployee()
        If Session("Role").ToString().ToUpper() = "ADMIN" Then

            Dim dtEmployee As New DataTable
            dtEmployee = oSelect.f_SEL_MST_EMPLOYEE_MASTER(Session("Entity").ToString())
            If dtEmployee.Rows.Count > 0 Then
                txtUserName.DataSource = dtEmployee
                txtUserName.DataValueField = "EmployeeID"
                txtUserName.DataTextField = "EmployeeName"
                txtUserName.DataBind()
                txtUserName.Items.Insert(0, New ListItem("--Select--", "--Select--"))

                ' txtUserName.SelectedIndex = txtUserName.Items.IndexOf(txtUserName.Items.FindByText(Session("UserID").ToString()))

            End If
        ElseIf Session("Role").ToString().ToUpper() = "SUPER ADMIN" Then
            Dim dtEmployee As New DataTable
            dtEmployee = oSelect.f_SEL_EMPLOYEE_SUPER_ADMIN()
            If dtEmployee.Rows.Count > 0 Then
                txtUserName.DataSource = dtEmployee
                txtUserName.DataValueField = "EmployeeID"
                txtUserName.DataTextField = "EmployeeName"
                txtUserName.DataBind()
                txtUserName.Items.Insert(0, New ListItem("--Select--", "--Select--"))
            End If
        ElseIf Session("Role").ToString().ToUpper() = "HRBP" Then
            Dim dtEmployee As New DataTable
            dtEmployee = oSelect.f_SEL_MST_EMPLOYEE_MASTER(Session("Entity").ToString())
            If dtEmployee.Rows.Count > 0 Then
                txtUserName.DataSource = dtEmployee
                txtUserName.DataValueField = "EmployeeID"
                txtUserName.DataTextField = "EmployeeName"
                txtUserName.DataBind()
                txtUserName.Items.Insert(0, New ListItem("--Select--", "--Select--"))
            End If
        Else
            Dim dtEmployee As New DataTable
            dtEmployee = oSelect.f_SEL_MST_EMPLOYEE_USER(Session("EMPLNUMBER").ToString())
            If dtEmployee.Rows.Count > 0 Then
                txtUserName.DataSource = dtEmployee
                txtUserName.DataValueField = "EmployeeID"
                txtUserName.DataTextField = "EmployeeName"
                txtUserName.DataBind()
                txtUserName.Enabled = False
                'txtUserName.Items.Insert(0, New ListItem("--Select--", "--Select--"))
            End If
        End If
    End Sub
    Public Sub Alert()
        Dim confirmValue As String = Request.Form("confirm_value")
    End Sub
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        EXPIRED()
        Dim confirmValue As String = Request.Form("confirm_value")
        If confirmValue = "Yes" And lblstatExpired.Text = "FALSE" Then
            Dim message As String
            message = "Date Expired"

            Dim sb As New System.Text.StringBuilder()
            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(message)
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        ElseIf confirmValue = "Yes" And lblstatExpired.Text = "TRUE" Then
            Dim HasilCheck As String = Nothing
            Dim Counting As Integer = Nothing
            Dim dtCheck As New DataTable()
            dtCheck = oSelect.f_SEL_CHECK_UPLOAD_CWH(txtUserName.SelectedValue.ToString(), ddlYear.SelectedItem.Text, ddlQuarter.SelectedItem.Text)
            If dtCheck.Rows.Count > 0 Then
                Counting = dtCheck.Rows(0)("COUNTING").ToString()
                HasilCheck = dtCheck.Rows(0)("HASIL_CHECK").ToString()
            End If


            If Counting > 0 Then
                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(HasilCheck)
                sb.Append("')};")
                sb.Append("</script>")

                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                Exit Sub
            End If

            If txtUpload.PostedFile.FileName = "" Then
                lblErr_Upload.Visible = True
                lblErr_Upload.Text = "* Please choose the file you want to upload"
                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append("Please choose the file you want to upload")
                sb.Append("')};")
                sb.Append("</script>")

                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                Exit Sub
            ElseIf ddlQuarter.SelectedItem.Value.ToString() = "0" Then
                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append("Please choose the Quarter of CWH")
                sb.Append("')};")
                sb.Append("</script>")

                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                Exit Sub
            ElseIf ddlYear.SelectedItem.Value.ToString() = "0" Then
                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append("Please choose the Year of CWH")
                sb.Append("')};")
                sb.Append("</script>")

                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                Exit Sub
            End If

            Dim _total As String = UploadExcel()
            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(_total)
            sb.Append("')};")
            sb.Append("</script>")

            'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "redirect",
            '"alert('" + _total + "'); window.location='/frm_list_Doc_CWH_for_Employee.aspx';", True)

            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        End If
        'End If
        'Dim HasilCheck As String = Nothing
        'Dim Counting As Integer = Nothing
        '    Dim dtCheck As New DataTable()
        '    dtCheck = oSelect.f_SEL_CHECK_UPLOAD_CWH(txtUserName.SelectedValue.ToString(), ddlYear.SelectedItem.Text, ddlQuarter.SelectedItem.Text)
        '    If dtCheck.Rows.Count > 0 Then
        '        Counting = dtCheck.Rows(0)("COUNTING").ToString()
        '        HasilCheck = dtCheck.Rows(0)("HASIL_CHECK").ToString()
        '    End If


        '    If Counting > 0 Then
        '        sb.Append("<script type = 'text/javascript'>")
        '        sb.Append("window.onload=function(){")
        '        sb.Append("alert('")
        '        sb.Append(HasilCheck)
        '        sb.Append("')};")
        '        sb.Append("</script>")

        '        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        '        Exit Sub
        '    End If

        '    If txtUpload.PostedFile.FileName = "" Then
        '        lblErr_Upload.Visible = True
        '        lblErr_Upload.Text = "* Please choose the file you want to upload"
        '        sb.Append("<script type = 'text/javascript'>")
        '        sb.Append("window.onload=function(){")
        '        sb.Append("alert('")
        '        sb.Append("Please choose the file you want to upload")
        '        sb.Append("')};")
        '        sb.Append("</script>")

        '        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        '        Exit Sub
        '    ElseIf ddlQuarter.SelectedItem.Value.ToString() = "0" Then
        '        sb.Append("<script type = 'text/javascript'>")
        '        sb.Append("window.onload=function(){")
        '        sb.Append("alert('")
        '        sb.Append("Please choose the Quarter of CWH")
        '        sb.Append("')};")
        '        sb.Append("</script>")

        '        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        '        Exit Sub
        '    ElseIf ddlYear.SelectedItem.Value.ToString() = "0" Then
        '        sb.Append("<script type = 'text/javascript'>")
        '        sb.Append("window.onload=function(){")
        '        sb.Append("alert('")
        '        sb.Append("Please choose the Year of CWH")
        '        sb.Append("')};")
        '        sb.Append("</script>")

        '        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        '        Exit Sub
        '    End If

        '    Dim _total As String = UploadExcel()
        '    sb.Append("<script type = 'text/javascript'>")
        '    sb.Append("window.onload=function(){")
        '    sb.Append("alert('")
        '    sb.Append(_total)
        '    sb.Append("')};")
        '    sb.Append("</script>")

        '    'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "redirect",
        '    '"alert('" + _total + "'); window.location='/frm_list_Doc_CWH_for_Employee.aspx';", True)

        '    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        'End If

    End Sub
    Private Function UploadExcel() As String
        Dim row, rows, rowbsm, rowMCM As Integer
        Dim msg As String = ""
        Dim EmployeeID As String
        Try
            EmployeeID = txtUserName.SelectedValue.ToString()
            Dim shortEntity As String = ""

            Dim dtCheck As New DataTable()
            dtCheck = oSelect.f_SEL_MST_EMPLOYEE_USER(EmployeeID)
            If dtCheck.Rows.Count > 0 Then
                shortEntity = dtCheck.Rows(0)("ShortEntity").ToString()
            End If
            Dim da As New OleDbDataAdapter
            Dim dtImport As New DataTable
            Dim strFileName As String = txtUpload.PostedFile.FileName
            Dim filename As String = Path.GetFileName(strFileName)
            Dim new_path As String = FolderCWH + "\" + ddlYear.SelectedItem.Text + "\" + ddlQuarter.SelectedItem.Text + "\" + shortEntity + "\" + EmployeeID + "\" + filename
            Dim DirecPath As String = FolderCWH + "\" + ddlYear.SelectedItem.Text + "\" + ddlQuarter.SelectedItem.Text + "\" + shortEntity + "\" + EmployeeID + "\"

            If Path.GetExtension(strFileName).ToUpper = ".PDF" Then
                If txtUpload.PostedFile.ContentLength > 1048576 Then

                    msg = "Max File Size 1 MB!"
                    Return msg
                    Exit Function
                End If

                If Not Directory.Exists(DirecPath) Then
                    System.IO.Directory.CreateDirectory(DirecPath)
                End If

                If File.Exists(new_path) Then
                    File.Delete(new_path)
                End If

                txtUpload.PostedFile.SaveAs(new_path)


                'Dim UrlAuth As String = "http://" + HttpContext.Current.Request.Url.Authority
                'Dim AppPath As String = HttpContext.Current.Request.ApplicationPath
                'Dim PathApprovalReject As String = UrlAuth + AppPath + "/" + "Frm_Approval_Reject_CWH.aspx?EmplID=" + EmployeeID + "&EmplName=" + Replace(txtUserName.SelectedItem.Text, " ", "%20") + "&Entity=" + Replace(shortEntity, " ", "%20") + "&Email=" + Session("EmailEmpl").ToString() + "&Year=" + ddlYear.SelectedItem.Text.ToString() + "&Quarter=" + ddlQuarter.SelectedItem.Text.ToString() + ""
                uploadid = Convert.ToInt32(oSelect.f_InsertUploadFile(filename, Session("UserName").ToString, Session("Entity")).Rows(0)(0).ToString)

                'oSelect.f_SEND_EMAIL_NOTIF_CWH_TO_HR(txtUserName.SelectedItem.Text, EmployeeID, "\\wrbmdtapp01\Application\HRAttendance\Upload\CWH" + ddlYear.SelectedItem.Text + "\" + ddlQuarter.SelectedItem.Text + "\" + shortEntity + "\" + EmployeeID + "\" + filename, shortEntity, PathApprovalReject, ddlYear.SelectedItem.Text, ddlQuarter.SelectedItem.Text, filename, uploadid, Session("UserID").ToString())
                oSelect.f_SEND_EMAIL_NOTIF_CWH_TO_HR(txtUserName.SelectedItem.Text, EmployeeID, "", shortEntity, "", ddlYear.SelectedItem.Text,
                                                     ddlQuarter.SelectedItem.Text, filename, uploadid, Session("UserID").ToString())

                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append("Upload Berhasil")
                sb.Append("')};")
                sb.Append("</script>")
                msg = "Upload Berhasil"
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())

            Else
                Dim message As String = "Please upload with .pdf format"

                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                msg = "Please upload with .pdf format"
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                Return msg
                Exit Function
            End If

        Catch ex As Exception
            msg = ex.Message.ToString()
        End Try

        Return msg
    End Function
    Sub GetMonthQuarter()
        Dim dtSelect As New DataTable
        dtSelect = oSelect.f_SEL_QUARTER(ddlQuarter.SelectedItem.Text)
        If dtSelect.Rows.Count > 0 Then
            txtMonth.Text = dtSelect.Rows(0)("Month").ToString()
        End If
    End Sub
    Protected Sub ddlQuarter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlQuarter.SelectedIndexChanged
        GetMonthQuarter()
    End Sub

    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

        Response.Redirect("Frm_List_ABSEN_USER.aspx")
    End Sub
    'Public Function UploadData() As String
    '    Dim row, rows, rowbsm, rowMCM As Integer
    '    Dim msg As String = ""
    '    Try
    '        Dim da As New OleDbDataAdapter
    '        Dim dtImport As New DataTable
    '        Dim strFileName As String = txtUpload.PostedFile.FileName
    '        Dim filename As String = Path.GetFileName(strFileName)
    '        Dim new_path As String = Server.MapPath("Upload\") + "CWH" + "\" + ddlYear.SelectedItem.Text + "\" + ddlQuarter.SelectedItem.Text + "\" + Session("ShortEntity").ToString() + "\" + EmployeeID + "\" + filename
    '        Dim DirecPath As String = Server.MapPath("Upload\") + "CWH" + "\" + ddlYear.SelectedItem.Text + "\" + ddlQuarter.SelectedItem.Text + "\" + Session("ShortEntity").ToString() + "\" + EmployeeID + "\"

    '        If Path.GetExtension(strFileName).ToUpper = ".PDF" Then
    '            If txtUpload.PostedFile.ContentLength > 1048576 Then

    '                msg = "Max File Size 1 MB!"
    '                Return msg
    '                Exit Function
    '            End If

    '            If Not Directory.Exists(DirecPath) Then
    '                System.IO.Directory.CreateDirectory(DirecPath)
    '            End If

    '            If File.Exists(new_path) Then
    '                File.Delete(new_path)
    '            End If

    '            txtUpload.PostedFile.SaveAs(new_path)

    '            Dim UrlAuth As String = "http://" + HttpContext.Current.Request.Url.Authority
    '            Dim AppPath As String = HttpContext.Current.Request.ApplicationPath
    '            Dim PathApprovalReject As String = UrlAuth + AppPath + "/" + "Frm_Approval_Reject_CWH.aspx?EmplID=" + EmployeeID + "&EmplName=" + Replace(Session("UserID").ToString(), " ", "%20") + "&Entity=" + Replace(Session("ShortEntity").ToString(), " ", "%20") + "&Email=" + Session("EmailEmpl").ToString() + "&Year=" + ddlYear.SelectedItem.Text.ToString() + "&Quarter=" + ddlQuarter.SelectedItem.Text.ToString() + ""
    '            uploadid = Convert.ToInt32(oSelect.f_InsertUploadFile(filename, Session("UserName").ToString, Session("Entity")).Rows(0)(0).ToString)

    '            oSelect.f_SEND_EMAIL_NOTIF_CWH_TO_HR(Session("UserID").ToString(), EmployeeID, "\\wrbmdtapp01\Application\HRAttendance\Upload\CWH\" + ddlYear.SelectedItem.Text + "\" + ddlQuarter.SelectedItem.Text + "\" + Session("ShortEntity").ToString() + "\" + EmployeeID + "\" + filename, Session("ShortEntity").ToString(), PathApprovalReject, ddlYear.SelectedItem.Text, ddlQuarter.SelectedItem.Text, filename, uploadid)

    '            sb.Append("<script type = 'text/javascript'>")
    '                sb.Append("window.onload=function(){")
    '                sb.Append("alert('")
    '                sb.Append("Upload Berhasil")
    '                sb.Append("')};")
    '                sb.Append("</script>")
    '                msg = "Upload Berhasil"
    '                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())

    '            Else
    '                Dim message As String = "Please upload with .pdf format"

    '            sb.Append("<script type = 'text/javascript'>")
    '            sb.Append("window.onload=function(){")
    '            sb.Append("alert('")
    '            sb.Append(message)
    '            sb.Append("')};")
    '            sb.Append("</script>")
    '            msg = "Please upload with .pdf format"
    '            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
    '            Return msg
    '            Exit Function
    '        End If

    '    Catch ex As Exception
    '        msg = ex.Message.ToString()
    '    End Try

    '    Return msg
    'End Function
End Class