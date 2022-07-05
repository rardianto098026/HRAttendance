Public Class Frm_Detail_Attendance_User
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

    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Response.Redirect("Frm_List_ABSEN_USER.aspx")
    End Sub
End Class