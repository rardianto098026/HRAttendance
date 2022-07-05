Imports System.Data.OleDb
Imports System.IO
Public Class Frm_upload_Data_Master_Attendance
    Inherits System.Web.UI.Page
    Dim uploadid As Integer
    Dim oSelect As New SelectBase
    Dim oInsert As New InsertBase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub Alert()
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
    Private Function UploadExcel() As String
        Dim rows As Integer
        UploadData()
        Return rows
    End Function
    Public Function UploadData() As String
        Dim row, rows, rowbsm, rowMCM As Integer
        'Try
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
        da = New OleDb.OleDbDataAdapter("Select * from [Sheet1$A1:H1000000]", conn)
        dtImport = New DataTable("ExcelFile")

        da.Fill(dtImport)

        lblErr_Upload.Visible = True
        lblErr_Upload.Text = ""

        If dtImport.Rows.Count > 0 Then
            uploadid = Convert.ToInt32(oSelect.f_InsertUploadFile(filename, Session("UserName").ToString, Session("Entity")).Rows(0)(0).ToString)
            For Each dr As DataRow In dtImport.Rows
                oInsert.f_Insert_MASTER_DATA_ATTENDANCE(dr("Person Number").ToString, dr("Full Name").ToString, dr("Location Name").ToString,
                                                dr("Entity").ToString, dr("Employee Gender").ToString, dr("Worker Type").ToString,
                                                dr("Access Card").ToString, Session("UserID").ToString, uploadid)
            Next

        End If
        Return row
    End Function

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Response.Redirect("Frm_List_ABSEN_USER.aspx")
    End Sub
End Class