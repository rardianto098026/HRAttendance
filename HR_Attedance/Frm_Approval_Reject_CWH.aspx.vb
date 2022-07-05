Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing

Public Class Frm_Approval_Reject_CWH
    Inherits System.Web.UI.Page

    Dim oSelect As New SelectBase
    Dim oUpdate As New UpdateBase
    Dim FolderCWH As String = ConfigurationManager.AppSettings("FolderCWH").ToString
    Dim FolderApprove As String = ConfigurationManager.AppSettings("FolderApprove").ToString
    Dim FolderReject As String = ConfigurationManager.AppSettings("FolderReject").ToString
    Dim FolderCWH_UAT As String = ConfigurationManager.AppSettings("FolderCWH_UAT").ToString
    Dim FolderApprove_UAT As String = ConfigurationManager.AppSettings("FolderApprove_UAT").ToString
    Dim FolderReject_UAT As String = ConfigurationManager.AppSettings("FolderReject_UAT").ToString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblEmplID.Text = Request.QueryString("EmplID").ToString
            lblEmplName.Text = Request.QueryString("EmployeeName").ToString
            lblEntity.Text = Request.QueryString("Entity").ToString
            lblEmail.Text = Request.QueryString("Email").ToString
            lblYear.Text = Request.QueryString("Year").ToString
            lblQuarter.Text = Request.QueryString("Quarter").ToString
            lblEntity2.Text = Session("Entity")
            lblRole.Text = Session("Role")
            BindData()
            Button()
        End If
    End Sub
    Sub BindData()
        Dim dtData As New DataTable
        dtData = oSelect.f_SEL_DETAIL_CWH(lblEmplID.Text, lblYear.Text, lblQuarter.Text)
        If dtData.Rows.Count > 0 Then
            LinkDwn1.Text = dtData.Rows(0)("FileName").ToString()
        End If

    End Sub
    Sub Button()
        If Session("Role").ToString().ToUpper() = "ADMIN" Then
            btnSubmit.Visible = False
            btnReject.Visible = False
            txtRemarks.Enabled = False
            btnBack.Visible = True
        ElseIf Session("Role").ToString().ToUpper() = "SUPER ADMIN" Then
            btnSubmit.Visible = False
            btnReject.Visible = False
            txtRemarks.Enabled = False
            btnBack.Visible = True
        ElseIf Session("Role").ToString().ToUpper() = "HRBP" Then
            btnSubmit.Visible = True
            btnReject.Visible = True
            txtRemarks.Enabled = True
            btnBack.Visible = True
        End If
    End Sub
    Public Sub Alert()
        Dim confirmValue As String = Request.Form("confirm_value")
    End Sub
    Public Sub Alert2()
        Dim confirmValue2 As String = Request.Form("confirm_value2")
    End Sub
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Session("Role").ToString().ToUpper() = "ADMIN" Then
            Dim sb As New System.Text.StringBuilder()

            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append("You don't have the authority to approve the CWH Program.")
            sb.Append("')};")
            sb.Append("</script>")

            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        ElseIf Session("Role").ToString().ToUpper() = "SUPER ADMIN" Then
            Dim sb As New System.Text.StringBuilder()

            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append("You don't have the authority to approve the CWH Program.")
            sb.Append("')};")
            sb.Append("</script>")

            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        ElseIf Session("Role").ToString().ToUpper() = "HRBP" Then
            Dim confirmValue As String = Request.Form("confirm_value")
            If confirmValue = "Yes" Then
                oUpdate.f_Update_Approved(lblEmplID.Text, lblYear.Text, lblQuarter.Text, "Approved", lblEmail.Text, Session("UserID"), txtRemarks.Text)
                read()

                Session("msg") = "Approved data success"

                Session("Condition") = "BackNavigate"
                Response.Redirect("Frm_list_Approval_Reject_CWH.aspx")
                'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "redirect", "alert('Approved data success');", True)

                'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "redirect", "alert('Approved data success'); Response.Redirect='/HRAttendance/Frm_List_Approval_Reject_CWH.aspx';", True)
                'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "redirect", "alert('Approved data success'); window.location='http://WRBMDTAPP01/HRAttendance/Frm_List_Approval_Reject_CWH.aspx';", True)

            End If
        End If
    End Sub

    Sub read()
        'If (Not System.IO.Directory.Exists(FolderCWH)) Then
        '    System.IO.Directory.CreateDirectory(FolderCWH)
        'End If
        'If (Not System.IO.Directory.Exists(FolderCWH_UAT)) Then
        'System.IO.Directory.CreateDirectory(FolderCWH_UAT)
        'End If

        Dim dir1 As New DirectoryInfo(FolderCWH + "\" + lblYear.Text + "\" + lblQuarter.Text + "\" + lblEntity.Text + "\" + lblEmplID.Text + "\")
        Dim FolderFiles As FileInfo() = dir1.GetFiles()

        'Dim FolderFiles As FileInfo() = dir1.GetFiles("*.pdf", SearchOption.AllDirectories)
        Dim Creationtime As DateTime = Nothing
        Dim timeNow As DateTime = Nothing

        Dim FileMinute As Integer = Nothing
        Dim extantion() As String = {"*.pdf"}
        'For Each ext As String In extantion
        For Each Files As FileInfo In FolderFiles
                Dim Filenames As String = Files.FullName
                Dim pathssss As String = Files.DirectoryName
                Dim pathssss2 As String = Files.Directory.GetFiles(0).ToString
                Dim pathssss3 As String = Files.Directory.Name
                Dim filess As String = Files.Name
                Dim fileses As String = Files.Extension


                Dim TargetFolder As String
                Dim TargetFolder1 As String
                Dim new_path As String
                Dim YearNow As String = Strings.Right(DateTime.Now.Year.ToString, 4).PadLeft(4, "0")
                Dim MonthNow As String = DateTime.Today.ToString("MMMM")
                Dim DateNow As String = DateTime.Today.ToString("dd")

                'TargetFolder = FolderApprove_UAT + "\" + lblYear.Text + "\" + lblQuarter.Text + "\" + lblEntity.Text + "\" + lblEmplID.Text + "\"
                'TargetFolder1 = FolderCWH_UAT + "\" + lblYear.Text + "\" + lblQuarter.Text + "\" + lblEntity.Text + "\" + lblEmplID.Text + "\"

                TargetFolder = FolderApprove + "\" + lblYear.Text + "\" + lblQuarter.Text + "\" + lblEntity.Text + "\" + lblEmplID.Text + "\"
                TargetFolder1 = FolderCWH + "\" + lblYear.Text + "\" + lblQuarter.Text + "\" + lblEntity.Text + "\" + lblEmplID.Text + "\"

                new_path = TargetFolder + filess

                If Not Directory.Exists(TargetFolder) Then
                    System.IO.Directory.CreateDirectory(TargetFolder)
                End If

                'If (Not System.IO.Directory.Exists(TargetFolder)) Then
                '    System.IO.Directory.CreateDirectory(TargetFolder)
                'End If

                If File.Exists(new_path) Then
                    File.Delete(new_path)
                End If

                System.IO.File.Move(Filenames, new_path)

            'If (System.IO.Directory.Exists(TargetFolder1)) Then
            '    System.IO.Directory.Delete(TargetFolder1)
            'End If
        Next
        'Next

    End Sub

    Sub Reject()
        'If (Not System.IO.Directory.Exists(FolderCWH)) Then
        '    System.IO.Directory.CreateDirectory(FolderCWH)
        'End If
        'If (Not System.IO.Directory.Exists(FolderCWH_UAT)) Then
        'System.IO.Directory.CreateDirectory(FolderCWH_UAT)
        'End If

        'Dim dir1 As New DirectoryInfo(FolderCWH)
        Dim dir1 As New DirectoryInfo(FolderCWH + "\" + lblYear.Text + "\" + lblQuarter.Text + "\" + lblEntity.Text + "\" + lblEmplID.Text + "\")
        'Dim dir1 As New DirectoryInfo(FolderCWH_UAT)
        Dim FolderFiles As FileInfo() = dir1.GetFiles()
        'Dim FolderFiles As FileInfo() = dir1.GetFiles("*.pdf", SearchOption.AllDirectories)
        Dim Creationtime As DateTime = Nothing
        Dim timeNow As DateTime = Nothing

        Dim FileMinute As Integer = Nothing
        Dim extantion() As String = {"*.pdf"}
        'For Each ext As String In extantion
        For Each Files As FileInfo In FolderFiles
                Dim Filenames As String = Files.FullName
                Dim pathssss As String = Files.DirectoryName
                Dim pathssss2 As String = Files.Directory.GetFiles(0).ToString
                Dim pathssss3 As String = Files.Directory.Name
                Dim filess As String = Files.Name
                Dim fileses As String = Files.Extension


                Dim TargetFolder As String
                Dim TargetFolder1 As String
                Dim new_path As String
                Dim new_pathh As String
                Dim YearNow As String = Strings.Right(DateTime.Now.Year.ToString, 4).PadLeft(4, "0")
                Dim MonthNow As String = DateTime.Today.ToString("MMMM")
                Dim DateNow As String = DateTime.Today.ToString("dd")

                'TargetFolder = FolderReject_UAT + "\" + lblYear.Text + "\" + lblQuarter.Text + "\" + lblEntity.Text + "\" + lblEmplID.Text + "\"
                'TargetFolder1 = FolderCWH_UAT + "\" + lblYear.Text + "\" + lblQuarter.Text + "\" + lblEntity.Text + "\" + lblEmplID.Text + "\"

                TargetFolder = FolderReject + "\" + lblYear.Text + "\" + lblQuarter.Text + "\" + lblEntity.Text + "\" + lblEmplID.Text + "\"
                TargetFolder1 = FolderCWH + "\" + lblYear.Text + "\" + lblQuarter.Text + "\" + lblEntity.Text + "\" + lblEmplID.Text + "\"

                If Not Directory.Exists(TargetFolder) Then
                    System.IO.Directory.CreateDirectory(TargetFolder)
                End If

                new_path = TargetFolder + filess
                new_pathh = TargetFolder1 + filess

                'If (Not System.IO.Directory.Exists(TargetFolder)) Then
                '    System.IO.Directory.CreateDirectory(TargetFolder)
                'End If

                If File.Exists(new_path) Then
                    File.Delete(new_path)
                End If

                System.IO.File.Move(Filenames, new_path)

            'If (System.IO.Directory.Exists(TargetFolder1)) Then
            '    System.IO.Directory.Delete(TargetFolder1)
            'End If
        Next
        'Next

    End Sub

    Private Function UploadExcel() As String
        Dim rows As Integer
        UploadData()
        Return rows
    End Function
    Public Function UploadData() As String
        Dim msg As String = ""
        Try

        Catch ex As Exception
            msg = ex.Message.ToString()
        End Try

        Return msg
    End Function

    Protected Sub LinkDwn1_Click(sender As Object, e As EventArgs) Handles LinkDwn1.Click
        Dim url As String = "/HRAttendance/upload/" + "CWHWAITING APPROVAL" + "/" + lblYear.Text + "/" + lblQuarter.Text + "/" + lblEntity.Text + "/" + lblEmplID.Text + "/" + LinkDwn1.Text

        Dim sb As New StringBuilder()
        sb.Append(" <Script type = 'text/javascript'>")
        sb.Append("window.open('")
        sb.Append(url)
        sb.Append("');")
        sb.Append("</script>")
        ClientScript.RegisterStartupScript(Me.GetType(),
                  "script", sb.ToString())
    End Sub

    Protected Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        If Session("Role").ToString().ToUpper() = "ADMIN" Then
            Dim sb As New System.Text.StringBuilder()

            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append("You don't have the authority to reject the CWH Program.")
            sb.Append("')};")
            sb.Append("</script>")

            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        ElseIf Session("Role").ToString().ToUpper() = "SUPER ADMIN" Then
            Dim sb As New System.Text.StringBuilder()

            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append("You don't have the authority to reject the CWH Program.")
            sb.Append("')};")
            sb.Append("</script>")

            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        ElseIf Session("Role").ToString().ToUpper() = "HRBP" Then
            Dim confirmValue2 As String = Request.Form("confirm_value2")
            If confirmValue2 = "Yes" Then
                oUpdate.f_Update_Approved(lblEmplID.Text, lblYear.Text, lblQuarter.Text, "Rejected", lblEmail.Text, Session("UserID"), txtRemarks.Text)


                Reject()

                Session("msg") = "Rejected data success"

                Session("Condition") = "BackNavigate"
                Response.Redirect("Frm_list_Approval_Reject_CWH.aspx")
            End If
        End If


    End Sub

    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Session("msg") = ""
        Session("Condition") = "BackNavigate"
        Response.Redirect("Frm_list_Approval_Reject_CWH.aspx")
    End Sub
End Class