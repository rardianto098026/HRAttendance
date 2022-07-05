
Imports System.Data.OleDb
Imports System.IO
Public Class Frm_Upload_Master_AccessCard
    Inherits System.Web.UI.Page
    Dim uploadid As Integer
        Dim oSelect As New SelectBase
        Dim oInsert As New InsertBase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Public Sub Alert()
        Dim confirmValue As String = Request.Form("confirm_value")
    End Sub
    Public Sub Alert1()
        Dim confirmValue As String = Request.Form("confirm_value")
    End Sub
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

        Dim confirmValue As String = Request.Form("confirm_value")
        If confirmValue = "Yes" Then

            If txtUpload.PostedFile.FileName = "" Then
                lblErr_Upload.Visible = True
                lblErr_Upload.Text = "* Please choose the file you want to upload"

                Exit Sub
            End If

            Dim _total As String = UploadExcel()
            Dim sb As New System.Text.StringBuilder()

            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append("Upload Berhasil")
            sb.Append("')};")
            sb.Append("</script>")

            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        End If
    End Sub
    Protected Sub btnSubmit1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit1.Click

        Dim confirmValue As String = Request.Form("confirm_value")
        If confirmValue = "Yes" Then

            If txtUpload1.PostedFile.FileName = "" Then
                lblErr_Upload1.Visible = True
                lblErr_Upload1.Text = "* Please choose the file you want to upload"

                Exit Sub
            End If

            Dim _total As String = UploadExcel1()
            Dim sb As New System.Text.StringBuilder()

            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append("Upload Berhasil")
            sb.Append("')};")
            sb.Append("</script>")

            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        End If

    End Sub
    Private Function UploadExcel() As String
        Dim rows As Integer
        UploadData()
        Return rows
    End Function
    Private Function UploadExcel1() As String
        Dim rows As Integer
        UploadData1()
        Return rows
    End Function
    Public Function UploadData() As String
        Dim row, rows, rowbsm, rowMCM As Integer
        Try
            Dim da As New OleDbDataAdapter
            Dim dtImport As New DataTable
            Dim strFileName As String = txtUpload.PostedFile.FileName
            Dim filename As String = Path.GetFileName(strFileName)
            Dim new_path As String = Server.MapPath("Upload\") + filename
            Dim msgError As String
            'Dim row, rows, rowbsm, rowMCM As Integer
            row = 1
            rows = 0
            rowbsm = 0
            rowMCM = 0
            txtUpload.PostedFile.SaveAs(new_path)

            Dim strConn As String
            strConn = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + new_path + ";Extended Properties=""Excel 12.0;HDR=YES;IMEX=1;"""

            Dim conn As New OleDb.OleDbConnection(strConn)
            da = New OleDb.OleDbDataAdapter("Select * from [Sheet1$A1:G100000]", conn)
            dtImport = New DataTable("ExcelFile")

            da.Fill(dtImport)

            lblErr_Upload.Visible = True
            lblErr_Upload.Text = ""

            If dtImport.Rows.Count > 0 Then
                uploadid = Convert.ToInt32(oSelect.f_InsertUploadFile(filename, Session("UserName").ToString, Session("Entity")).Rows(0)(0).ToString)
                For Each dr As DataRow In dtImport.Rows
                    oInsert.f_INSERT_MASTER_DATA_EMPLOYEE(dr("EmployeeID").ToString, dr("EmployeeName").ToString,
                                                    dr("Entity").ToString, dr("AccessCardNo").ToString,
                                                    dr("LocationName").ToString, dr("EmployeeGender").ToString, dr("WorkerType").ToString,
                                                    Session("UserName").ToString, uploadid)

                Next
            End If
        Catch ex As Exception
        End Try

        Return row
    End Function

    Public Function UploadData1() As String
        Dim row, rows, rowbsm, rowMCM As Integer
        Try
            Dim da As New OleDbDataAdapter
            Dim dtImport As New DataTable
            Dim strFileName As String = txtUpload1.PostedFile.FileName
            Dim filename As String = Path.GetFileName(strFileName)
            Dim new_path As String = Server.MapPath("Upload\") + filename
            Dim msgError As String
            'Dim row, rows, rowbsm, rowMCM As Integer
            row = 1
            rows = 0
            rowbsm = 0
            rowMCM = 0
            txtUpload1.PostedFile.SaveAs(new_path)

            Dim strConn As String
            strConn = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + new_path + ";Extended Properties=""Excel 12.0;HDR=YES;IMEX=1;"""

            Dim conn As New OleDb.OleDbConnection(strConn)
            da = New OleDb.OleDbDataAdapter("Select * from [Sheet1$A1:I1000000]", conn)
            dtImport = New DataTable("ExcelFile")

            da.Fill(dtImport)

            lblErr_Upload1.Visible = True
            lblErr_Upload1.Text = ""

            'Dim a, b, c, d, e, f, g, h, i, j As String

            If dtImport.Rows.Count > 0 Then
                'uploadid = Convert.ToInt32(oSelect.f_InsertUploadFile(filename, Session("UserName").ToString, Session("Entity")).Rows(0)(0).ToString)
                For Each dr As DataRow In dtImport.Rows
                    'a = dr("EmployeeID").ToString
                    'b = dr("EmployeeName").ToString
                    'c = dr("Entity").ToString
                    'd = dr("Email").ToString
                    'e = dr("EmployeeID_Manager").ToString
                    'f = dr("EmployeeName_Manager").ToString
                    'g = dr("Email_Manager").ToString
                    oInsert.f_INSERT_LINE_MANAGER(dr("EmployeeID").ToString, dr("EmployeeName").ToString,
                                                    dr("Entity").ToString, dr("WorkerType").ToString, dr("Email").ToString, dr("EmployeeID_Manager").ToString,
                                                    dr("EmployeeName_Manager").ToString, dr("Email_Manager").ToString)

                Next
            End If
        Catch ex As Exception
        End Try

        Return row
    End Function

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Response.Redirect("Frm_List_ABSEN_ADMIN.aspx")
    End Sub

    Private Sub btnBack1_Click(sender As Object, e As EventArgs) Handles btnBack1.Click
        Response.Redirect("Frm_List_ABSEN_ADMIN.aspx")
    End Sub
End Class
