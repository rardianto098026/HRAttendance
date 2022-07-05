Public Class Frm_List_Detail_Admin
    Inherits System.Web.UI.Page
    Dim oSelect As New SelectBase
    Dim oUpdate As New UpdateBase
    Sub Searching()
        'lblCount.Visible = False

        If ChkUpdate.Checked = True And ddlMonth.SelectedItem.Text = "--Select--" Then
            Label6.Visible = True
            Label6.Text = "* Please Choose Month"

            Exit Sub
        End If

        grid_Databinding()

        dg.PageSize = 50
        dg.PageIndex = 0
        dg.DataBind()


        lblTotal.Text = dg.PageCount
        txtGO.Value = dg.PageIndex + 1

        'lblName.Visible = False

        'Label6.Visible = False
        'lblErrType.Visible = False

    End Sub
    Protected Sub Search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Search.Click
        Searching()
    End Sub
    Private Sub grid_Databinding()
        Dim _Month As String = ""

        Dim _FlagMonth As String


        If ChkUpdate.Checked = False Then
            _FlagMonth = "0"
            Label6.Visible = False
            GetStatsCWH_LOAD()
        Else
            _FlagMonth = "1"
            _Month = ddlMonth.SelectedItem.Text
            Label6.Visible = False
            GetStatsCWH()
        End If



        Dim dtSelect As New DataTable
        dtSelect = oSelect.f_SEL_LIST_DETAIL_ATTENDANCE_ADMIN(lblEntity.Text, LblAccessCard.Text, _Month, lblName.Text, _FlagMonth, lblEmplID.Text, Session("Role").ToString(), Session("YearAttendance"))

        Session("dtSelect") = dtSelect
        dg.PageSize = 50
        dg.DataSource = dtSelect
        dg.Visible = True


    End Sub
    Sub dgLoad()
        Dim dtSelect As New DataTable
        dtSelect = oSelect.f_SEL_LIST_DETAIL_ATTENDANCE_ADMIN_LOAD(lblEntity.Text, LblAccessCard.Text, lblName.Text, lblEmplID.Text, Session("YearAttendance"))

        Session("dtSelect") = dtSelect
        dg.PageSize = 50
        dg.DataSource = dtSelect
        dg.Visible = True

        'dg.DataBind()
    End Sub
    Protected Sub lbFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbFirst.Click
        'dg.DataSource = oSelect.f_SelRekeningKoran
        grid_Databinding()
        dg.DataBind()
        dg.PageIndex = 0
        dg.DataBind()

        txtGO.Value = dg.PageIndex + 1
    End Sub

    Protected Sub lbPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbPrev.Click
        If dg.PageIndex <> 0 Then
            'dg.DataSource = oSelect.f_SelRekeningKoran
            grid_Databinding()
            dg.DataBind()
            dg.PageIndex = dg.PageIndex - 1
            dg.DataBind()

            txtGO.Value = dg.PageIndex + 1
        End If
    End Sub

    Protected Sub lnkNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNext.Click
        If dg.PageIndex <> dg.PageCount - 1 Then
            'dg.DataSource = oSelect.f_SelRekeningKoran
            grid_Databinding()
            dg.DataBind()
            dg.PageIndex = dg.PageIndex + 1
            dg.DataBind()

            txtGO.Value = dg.PageIndex + 1
        End If
    End Sub

    Protected Sub lnkLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLast.Click
        'dg.DataSource = oSelect.f_SelRekeningKoran
        grid_Databinding()
        dg.DataBind()
        dg.PageIndex = dg.PageCount - 1
        dg.DataBind()

        txtGO.Value = dg.PageIndex + 1
    End Sub

    Protected Sub lnkGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkGo.Click
        If IsNumeric(txtGO.Value) = True Then
            If txtGO.Value <= dg.PageCount - 1 Then
                'dg.DataSource = oSelect.f_SelRekeningKoran
                grid_Databinding()
                dg.DataBind()
                dg.PageIndex = Int32.Parse(txtGO.Value) - 1
                dg.DataBind()

                txtGO.Value = dg.PageIndex + 1
            End If
        End If
    End Sub
    Protected Sub ddl_View_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_View.SelectedIndexChanged

        If ddl_View.SelectedValue = "10" Then
            grid_Databinding()
            dg.PageSize = 10
            dg.PageIndex = 0
            dg.DataBind()

            lblTotal.Text = dg.PageCount
            txtGO.Value = dg.PageIndex + 1
        ElseIf ddl_View.SelectedValue = "20" Then
            grid_Databinding()
            dg.PageSize = 20
            dg.PageIndex = 0
            dg.DataBind()

            lblTotal.Text = dg.PageCount
            txtGO.Value = dg.PageIndex + 1
        ElseIf ddl_View.SelectedValue = "50" Then
            grid_Databinding()
            dg.PageSize = 50
            dg.PageIndex = 0
            dg.DataBind()

            lblTotal.Text = dg.PageCount
            txtGO.Value = dg.PageIndex + 1
        ElseIf ddl_View.SelectedValue = "70" Then
            grid_Databinding()
            dg.PageSize = 70
            dg.PageIndex = 0
            dg.DataBind()


            lblTotal.Text = dg.PageCount
            txtGO.Value = dg.PageIndex + 1
        ElseIf ddl_View.SelectedValue = "100" Then
            grid_Databinding()
            dg.PageSize = 100
            dg.PageIndex = 0
            dg.DataBind()

            lblTotal.Text = dg.PageCount
            txtGO.Value = dg.PageIndex + 1
        End If
    End Sub
    Private Sub dg_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles dg.RowEditing
        dg.EditIndex = e.NewEditIndex
        grid_Databinding()
        dg.DataBind()
    End Sub
    Protected Sub dg_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles dg.RowCancelingEdit
        dg.EditIndex = -1
        grid_Databinding()
        dg.DataBind()
    End Sub
    Protected Sub dg_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles dg.RowUpdating
        Dim IDX As Label = DirectCast(dg.Rows(e.RowIndex).FindControl("txtIDX"), Label)
        Dim Dates As Label = DirectCast(dg.Rows(e.RowIndex).FindControl("txtDate"), Label)
        Dim INS As Label = DirectCast(dg.Rows(e.RowIndex).FindControl("txtFirstSignIn"), Label)
        Dim OUT As Label = DirectCast(dg.Rows(e.RowIndex).FindControl("txtLastSignOut"), Label)
        Dim PROPIN As TextBox = DirectCast(dg.Rows(e.RowIndex).FindControl("txtProposedIn"), TextBox)
        Dim PROPOUT As TextBox = DirectCast(dg.Rows(e.RowIndex).FindControl("txtProposedOut"), TextBox)
        Dim REASON As TextBox = DirectCast(dg.Rows(e.RowIndex).FindControl("txtReason"), TextBox)

        Dim DateFirstIn As DateTime = Convert.ToDateTime(Dates.Text)
        Dim DateTimeFirstIn As DateTime = String.Format("{0:yyyy-MM-dd}", DateFirstIn) + " " + INS.Text

        Dim DateLastSignOut As DateTime = Convert.ToDateTime(Dates.Text)
        Dim DateTimeLastSignOut As DateTime = String.Format("{0:yyyy-MM-dd}", DateLastSignOut) + " " + OUT.Text

        Dim DateIn As DateTime = Convert.ToDateTime(Dates.Text)
        Dim DateTimeIn As DateTime = String.Format("{0:yyyy-MM-dd}", DateIn) + " " + PROPIN.Text

        Dim DateOut As DateTime = Convert.ToDateTime(Dates.Text)
        Dim DateTimeOut As DateTime = String.Format("{0:yyyy-MM-dd}", DateOut) + " " + PROPOUT.Text

        Dim Months As String = Nothing
        Dim Days As String = Nothing
        Dim ArrivalStatus2 As String = Nothing
        Dim TypeofDays2 As String = Nothing
        Dim TotalWorkingTime2 As String = Nothing
        Dim WorkingStatus2 As String = Nothing
        Dim isOvertime2 As String = Nothing
        Dim Overtime2 As String = Nothing
        Dim Hours2 As String = Nothing
        Dim WorkingTime As String = Nothing
        Dim NORMAL1 As String = Nothing
        Dim NORMALRest As String = Nothing
        Dim HOLIDAY18 As String = Nothing
        Dim HOLIDAY1 As String = Nothing
        Dim HOLIDAYRest As String = Nothing
        Dim ELIG_CWH As String = Nothing
        Dim QUARTER As String = Nothing
        'Dim DAYS As TextBox = DirectCast(dg.Rows(e.RowIndex).FindControl("txtDays"), TextBox)
        'Dim Months As Label = DirectCast(dg.Rows(e.RowIndex).FindControl("txtMonths"), Label)
        'Dim ArrivalStat As Label = DirectCast(dg.Rows(e.RowIndex).FindControl("txtArrivalStatus"), Label)
        'Dim TotalWorkingTime As Label = DirectCast(dg.Rows(e.RowIndex).FindControl("txtTotalWorkingTime"), Label)
        'Dim WorkingTime As Label = DirectCast(dg.Rows(e.RowIndex).FindControl("txtWorkingTime"), Label)
        'Dim WorkingStatus As Label = DirectCast(dg.Rows(e.RowIndex).FindControl("txtWorkingStatus"), Label)

        Try
            Dim dtSelect As New DataTable
            dtSelect = oSelect.f_SEL_GET_DETAIL_DAYS_ATTENDANCE(DateTimeIn, DateTimeOut)
            If dtSelect.Rows.Count > 0 Then
                Months = dtSelect.Rows(0)("Months").ToString()
                Days = dtSelect.Rows(0)("Days").ToString()
                TypeofDays2 = dtSelect.Rows(0)("Type_of_Days").ToString()
                ArrivalStatus2 = dtSelect.Rows(0)("ArrivalStatus").ToString()
                TotalWorkingTime2 = dtSelect.Rows(0)("TotalWorkingTime").ToString()
                WorkingStatus2 = dtSelect.Rows(0)("WorkingStatus").ToString()
                isOvertime2 = dtSelect.Rows(0)("isOvertime").ToString()
                Overtime2 = dtSelect.Rows(0)("Overtime").ToString()
                Hours2 = dtSelect.Rows(0)("12HOURS").ToString()
                WorkingTime = dtSelect.Rows(0)("WorkingTime").ToString()
                NORMAL1 = dtSelect.Rows(0)("NORMAL1").ToString()
                NORMALRest = dtSelect.Rows(0)("NORMALRest").ToString()
                HOLIDAY18 = dtSelect.Rows(0)("HOLIDAY18").ToString()
                HOLIDAY1 = dtSelect.Rows(0)("HOLIDAY1").ToString()
                HOLIDAYRest = dtSelect.Rows(0)("HOLIDAYRest").ToString()
                ELIG_CWH = dtSelect.Rows(0)("ELIG_CWH").ToString()
                QUARTER = dtSelect.Rows(0)("QUART").ToString()
            End If
            oUpdate.sp_UPDATE_ATTENDANCE(IDX.Text, lblEmplID1.Text, DateTimeFirstIn, DateTimeLastSignOut, Months, PROPIN.Text,
                                         PROPOUT.Text, Days, TypeofDays2, ArrivalStatus2, TotalWorkingTime2, WorkingStatus2,
                                         isOvertime2, Overtime2, Hours2, Session("UserID").ToString, DateTimeIn, DateTimeOut, PROPIN.Text, PROPOUT.Text, REASON.Text,
                                         WorkingTime, NORMAL1, NORMALRest, HOLIDAY18, HOLIDAY1, HOLIDAYRest, ELIG_CWH, QUARTER)
            grid_Databinding()
            dg.DataBind()

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "redirect",
          "alert('Save Data Sukses'); window.location='" + HttpContext.Current.Request.Url.ToString() + "';", True)

        Catch ex As Exception

            grid_Databinding()
            dg.DataBind()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "redirect",
          "alert('Save Data Gagal'); window.location='" + HttpContext.Current.Request.Url.ToString() + "';", True)

        End Try
    End Sub

    Protected Sub Frm_List_Detail_Admin_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblYears.Text = Session("YearAttendance")
            LblAccessCard.Text = Request.QueryString("AccessCardNo").ToString()
            lblName.Text = Request.QueryString("EmployeeName").ToString()
            lblEmplID.Text = Request.QueryString("EmployeeID").ToString()
            lblEntity.Text = Request.QueryString("Entity").ToString()
            dgLoad()
            'grid_Databinding()
            dg.DataBind()
            GetStatsCWH_LOAD()
        End If
    End Sub
    Sub SearchExport()
        'lblCount.Visible = False

        If ChkUpdate.Checked = True And ddlMonth.SelectedItem.Text = "--Select--" Then
            Label6.Visible = True
            Label6.Text = "* Please Choose Month"

            Exit Sub
        End If

        grid_Export()

        dg.PageSize = 50
        dg.PageIndex = 0
        dg.DataBind()
    End Sub
    Private Sub grid_Export()
        Dim _Month As String = ""

        Dim _FlagMonth As String


        If ChkUpdate.Checked = False Then
            _FlagMonth = "0"
            Label6.Visible = False
        Else
            _FlagMonth = "1"
            _Month = ddlMonth.SelectedItem.Text
            Label6.Visible = False
        End If



        Dim dtSelect As New DataTable
        dtSelect = oSelect.f_SEL_LIST_DETAIL_ATTENDANCE_ADMIN_EXPORT_REPORT(lblEntity.Text, LblAccessCard.Text, _Month, lblName.Text, _FlagMonth, lblEmplID.Text, Session("YearAttendance"))

        Session("dtSelectReport") = dtSelect
    End Sub
    Sub exportReport()

        Dim dgs As New GridView
        dgs.DataSource = Session("dtSelectReport")
        dgs.DataBind()

        For Each r As GridViewRow In dgs.Rows
            If (r.RowType = DataControlRowType.DataRow) Then
                r.Cells(0).Attributes.Add("class", "text")
                r.Cells(1).Attributes.Add("class", "text")
                r.Cells(2).Attributes.Add("class", "text")
                r.Cells(3).Attributes.Add("class", "text")
                r.Cells(4).Attributes.Add("class", "text")
                r.Cells(5).Attributes.Add("class", "text")
                r.Cells(6).Attributes.Add("class", "text")
                r.Cells(7).Attributes.Add("class", "text")
                r.Cells(8).Attributes.Add("class", "text")
                r.Cells(9).Attributes.Add("class", "text")
                r.Cells(10).Attributes.Add("class", "text")
                r.Cells(11).Attributes.Add("class", "text")
                r.Cells(12).Attributes.Add("class", "text")
                r.Cells(13).Attributes.Add("class", "text")
                r.Cells(14).Attributes.Add("class", "text")

            End If
        Next



        Dim filename As String = "List Attendance" & Strings.Right(DateTime.Now.Year.ToString, 4).PadLeft(4, "0") & DateTime.Now.Month.ToString.PadLeft(2, "0") & ".xls"


        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "inline; filename=" + filename)

        Response.AddHeader("X-Download-Options", "noopen")

        Response.Charset = ""

        Me.EnableViewState = False

        Dim tw As New System.IO.StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)

        dgs.RenderControl(hw)

        If dgs.Rows.Count > 0 Then

            Dim style As String = "<style> .text { mso-number-format:\@; } </style>"
            Response.Write(style)



            ' Write the HTML back to the browser.
            Response.Write(tw.ToString())

        Else
            Dim style As String = "NO DATA"
            Response.Write(style)
        End If
        Response.End()

        Session.Remove("dtSelect")
        Session.Remove("dtSelectReport")
    End Sub

    Protected Sub Export_Click(sender As Object, e As EventArgs) Handles Export.Click
        SearchExport()
        exportReport()
    End Sub
    Sub GetStatsCWH_LOAD()
        lblDocCWH.Visible = True
        lblQuarter.Visible = True
        lblStatusApproved.Visible = True
        Label2.Visible = True
        Label3.Visible = True

        lblQuarter.Text = ""
        lblStatusApproved.Text = ""

        Dim currentDate As DateTime = DateTime.Now


        Dim dtSel As New DataTable
        dtSel = oSelect.f_SEL_GET_MST_QUARTER(currentDate.Month.ToString())
        If dtSel.Rows.Count > 0 Then
            lblQuarter.Text = dtSel.Rows(0)("Quarters").ToString()
        End If


        Dim dtStat As New DataTable
        dtStat = oSelect.f_SEL_GET_STATUS_APPROVED(lblQuarter.Text, Session("YearAttendance").ToString(), lblEmplID.Text)
        If dtStat.Rows.Count > 0 Then
            lblStatusApproved.Text = dtStat.Rows(0)("STATUS_APPROVED").ToString()
        Else
            lblStatusApproved.Text = "NOT REQUESTED CWH"
        End If
    End Sub
    Sub GetStatsCWH()
        lblDocCWH.Visible = True
        lblQuarter.Visible = True
        lblStatusApproved.Visible = True
        Label2.Visible = True
        Label3.Visible = True

        lblQuarter.Text = ""
        lblStatusApproved.Text = ""

        Dim dtSel As New DataTable
        dtSel = oSelect.f_SEL_GET_MST_QUARTER(ddlMonth.SelectedValue.ToString())
        If dtSel.Rows.Count > 0 Then
            lblQuarter.Text = dtSel.Rows(0)("Quarters").ToString()
        End If


        Dim dtStat As New DataTable
        dtStat = oSelect.f_SEL_GET_STATUS_APPROVED(lblQuarter.Text, Session("YearAttendance").ToString(), lblEmplID.Text)
        If dtStat.Rows.Count > 0 Then
            lblStatusApproved.Text = dtStat.Rows(0)("STATUS_APPROVED").ToString()
        Else
            lblStatusApproved.Text = "NOT REQUESTED CWH"
        End If
    End Sub
    Protected Sub ddlMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlMonth.SelectedIndexChanged
        GetStatsCWH()
    End Sub
End Class