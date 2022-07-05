Public Class Frm_Edit_Master_AccessCard
    Inherits System.Web.UI.Page
    Dim oSelect As New SelectBase
        Dim oUpdate As New UpdateBase

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Session("EmployeeID") = Request.QueryString("EmployeeID").ToString
            'Session("EmployeeName") = Request.QueryString("EmployeeName").ToString
            Session("AccessCardNo") = Request.QueryString("AccessCardNo").ToString
            'Session("Entity") = Request.QueryString("Entity").ToString
            DataLOAD()
        End If
    End Sub

    Sub DataLOAD()
            Dim dtSelect As New DataTable
        dtSelect = oSelect.f_SEL_DETAIL_MASTER_EMPLOYEE(Session("EmployeeID").ToString())
        If dtSelect.Rows.Count > 0 Then
            LblAccessCard.Text = dtSelect.Rows(0)("AccessCardNo").ToString()
            lblEmplID.Text = dtSelect.Rows(0)("EmployeeID").ToString()
            lblName.Text = dtSelect.Rows(0)("EmployeeName").ToString()
            lblEntity.Text = dtSelect.Rows(0)("Entity").ToString()
            lblLocationName.Text = dtSelect.Rows(0)("LocationName").ToString()
            lblEmployeeGender.Text = dtSelect.Rows(0)("EmployeeGender").ToString()
            lblWorkerType.Text = dtSelect.Rows(0)("WorkerType").ToString()
        End If
        End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles Submit.Click
        oUpdate.f_UPDATE_DETAIL_MASTER_EMPLOYEE(lblEmplID.Text, lblName.Text, lblEntity.Text, LblAccessCard.Text, lblLocationName.Text, lblEmployeeGender.Text, lblWorkerType.Text)


        Session("msg1") = "Edit data success"
        Response.Redirect("Frm_List_Master_AccessCard.aspx")

        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "redirect",
        '    "alert('Edit data success');", True)
        'Response.Redirect("Frm_List_Master_AccessCard.aspx")
        '"alert('Edit data success'); window.location='/HRAttendance/Frm_List_Master_AccessCard.aspx';", True)
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles Back.Click
        Session("msg1") = ""
        Response.Redirect("Frm_List_Master_AccessCard.aspx")
    End Sub
End Class