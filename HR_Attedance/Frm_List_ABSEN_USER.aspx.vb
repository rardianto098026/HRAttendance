Public Class Frm_List_ABSEN_USER
    Inherits System.Web.UI.Page

    Dim oSelect As New SelectBase
    Sub Searching()
        'lblCount.Visible = False

        'Validation
        If chkAccess.Checked = True And txtDate.Text = "" Then
            lblErrDate.Visible = True
            lblErrDate.Text = "* Please fill the Date"

            Exit Sub
        End If

        If ChkUpdate.Checked = True And ddlMonth.SelectedItem.Text = "--Select--" Then
            Label6.Visible = True
            Label6.Text = "* Please Choose Month"

            Exit Sub
        End If
        grid_Databinding()

        dgRekeningKoran.PageSize = 50
        dgRekeningKoran.CurrentPageIndex = 0
        dgRekeningKoran.DataBind()


        lblTotal.Text = dgRekeningKoran.PageCount
        txtGO.Value = dgRekeningKoran.CurrentPageIndex + 1


        Label6.Visible = False
        'lblErrType.Visible = False

    End Sub
    Protected Sub Search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Search.Click
        Searching()
    End Sub
    Private Sub grid_Databinding()
        Dim _Date As String = ""
        Dim _Month As String = ""
        Dim _Quarter As String = ""

        Dim _flagDate As String
        Dim _FlagMonth As String
        Dim _FlagQuarter As String

        If chkAccess.Checked = False Then
            _flagDate = "0"
            _Date = "1900-01-01"
            lblErrDate.Visible = False
        Else
            _flagDate = "1"
            _Date = GetDateInYYYYMMDD(txtDate.Text)
            lblErrDate.Visible = False
        End If

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

        If chkQuarter.Checked = False Then
            _FlagQuarter = "0"
            Label7.Visible = False
            GetStatsCWH_LOAD()
        Else
            _FlagQuarter = "1"
            _Quarter = ddlQuarter.SelectedItem.Text
            Label7.Visible = False
            GetStatsCWH()
        End If



        Dim dtSelect As New DataTable
        dtSelect = oSelect.f_SEL_LIST_ATTENDANCE_USER(_Date, _Month, Session("EMPLNUMBER").ToString, _flagDate, _FlagMonth, Session("YearAttendance"))
        Session("dtSelect") = dtSelect
        'dgRekeningKoran.PageSize = 50
        'dgRekeningKoran.DataSource = dtSelect
        'dgRekeningKoran.Visible = True

        Dim Page As Integer
        Session("dtSelect") = dtSelect
        If ddl_View.SelectedItem.Text = "-- Choose --" Then
            Page = 50
        ElseIf ddl_View.SelectedItem.Text = "10" Then
            Page = 10
        ElseIf ddl_View.SelectedItem.Text = "20" Then
            Page = 20
        ElseIf ddl_View.SelectedItem.Text = "50" Then
            Page = 50
        ElseIf ddl_View.SelectedItem.Text = "70" Then
            Page = 70
        ElseIf ddl_View.SelectedItem.Text = "100" Then
            Page = 100
        End If

        dgRekeningKoran.PageSize = Page
        dgRekeningKoran.DataSource = dtSelect
        dgRekeningKoran.Visible = True


    End Sub
    Protected Sub lbFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbFirst.Click
        'dgRekeningKoran.DataSource = oSelect.f_SelRekeningKoran
        grid_Databinding()
        dgRekeningKoran.DataBind()
        dgRekeningKoran.CurrentPageIndex = 0
        dgRekeningKoran.DataBind()

        txtGO.Value = dgRekeningKoran.CurrentPageIndex + 1
    End Sub

    Protected Sub lbPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbPrev.Click
        If dgRekeningKoran.CurrentPageIndex <> 0 Then
            'dgRekeningKoran.DataSource = oSelect.f_SelRekeningKoran
            grid_Databinding()
            dgRekeningKoran.DataBind()
            dgRekeningKoran.CurrentPageIndex = dgRekeningKoran.CurrentPageIndex - 1
            dgRekeningKoran.DataBind()

            txtGO.Value = dgRekeningKoran.CurrentPageIndex + 1
        End If
    End Sub

    Protected Sub lnkNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNext.Click
        If dgRekeningKoran.CurrentPageIndex <> dgRekeningKoran.PageCount - 1 Then
            'dgRekeningKoran.DataSource = oSelect.f_SelRekeningKoran
            grid_Databinding()
            dgRekeningKoran.DataBind()
            dgRekeningKoran.CurrentPageIndex = dgRekeningKoran.CurrentPageIndex + 1
            dgRekeningKoran.DataBind()

            txtGO.Value = dgRekeningKoran.CurrentPageIndex + 1
        End If
    End Sub

    Protected Sub lnkLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLast.Click
        'dgRekeningKoran.DataSource = oSelect.f_SelRekeningKoran
        grid_Databinding()
        dgRekeningKoran.DataBind()
        dgRekeningKoran.CurrentPageIndex = dgRekeningKoran.PageCount - 1
        dgRekeningKoran.DataBind()

        txtGO.Value = dgRekeningKoran.CurrentPageIndex + 1
    End Sub

    Protected Sub lnkGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkGo.Click
        If IsNumeric(txtGO.Value) = True Then
            If txtGO.Value <= dgRekeningKoran.PageCount - 1 Then
                'dgRekeningKoran.DataSource = oSelect.f_SelRekeningKoran
                grid_Databinding()
                dgRekeningKoran.DataBind()
                dgRekeningKoran.CurrentPageIndex = Int32.Parse(txtGO.Value) - 1
                dgRekeningKoran.DataBind()

                txtGO.Value = dgRekeningKoran.CurrentPageIndex + 1
            End If
        End If
    End Sub
    Protected Sub ddl_View_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_View.SelectedIndexChanged

        If ddl_View.SelectedValue = "10" Then
            grid_Databinding()
            dgRekeningKoran.PageSize = 10
            dgRekeningKoran.CurrentPageIndex = 0
            dgRekeningKoran.DataBind()

            lblTotal.Text = dgRekeningKoran.PageCount
            txtGO.Value = dgRekeningKoran.CurrentPageIndex + 1
        ElseIf ddl_View.SelectedValue = "20" Then
            grid_Databinding()
            dgRekeningKoran.PageSize = 20
            dgRekeningKoran.CurrentPageIndex = 0
            dgRekeningKoran.DataBind()

            lblTotal.Text = dgRekeningKoran.PageCount
            txtGO.Value = dgRekeningKoran.CurrentPageIndex + 1
        ElseIf ddl_View.SelectedValue = "50" Then
            grid_Databinding()
            dgRekeningKoran.PageSize = 50
            dgRekeningKoran.CurrentPageIndex = 0
            dgRekeningKoran.DataBind()

            lblTotal.Text = dgRekeningKoran.PageCount
            txtGO.Value = dgRekeningKoran.CurrentPageIndex + 1
        ElseIf ddl_View.SelectedValue = "70" Then
            grid_Databinding()
            dgRekeningKoran.PageSize = 70
            dgRekeningKoran.CurrentPageIndex = 0
            dgRekeningKoran.DataBind()


            lblTotal.Text = dgRekeningKoran.PageCount
            txtGO.Value = dgRekeningKoran.CurrentPageIndex + 1
        ElseIf ddl_View.SelectedValue = "100" Then
            grid_Databinding()
            dgRekeningKoran.PageSize = 100
            dgRekeningKoran.CurrentPageIndex = 0
            dgRekeningKoran.DataBind()

            lblTotal.Text = dgRekeningKoran.PageCount
            txtGO.Value = dgRekeningKoran.CurrentPageIndex + 1
        End If
    End Sub

    Protected Sub dgRekeningKoran_ItemCommand(source As Object, e As DataGridCommandEventArgs) Handles dgRekeningKoran.ItemCommand
        If e.CommandName = "cmdEdit" Then
            Dim idx As String = dgRekeningKoran.Items(e.Item.ItemIndex).Cells(1).Text
            Response.Redirect("Frm_Detail_Attendance_User.aspx?idx=" + idx.ToString())
        End If
    End Sub
    Sub Searching_Export()
        'lblCount.Visible = False

        'Validation
        If chkAccess.Checked = True And txtDate.Text = "" Then
            lblErrDate.Visible = True
            lblErrDate.Text = "* Please fill the Date"

            Exit Sub
        End If


        If ChkUpdate.Checked = True And ddlMonth.SelectedItem.Text = "--Select--" Then
            Label6.Visible = True
            Label6.Text = "* Please Choose Month"

            Exit Sub
        End If

        grid_Export()



    End Sub
    Private Sub grid_Export()
        Dim _Date As String = ""

        Dim _Month As String = ""

        Dim _flagDate As String
        Dim _FlagMonth As String

        If chkAccess.Checked = False Then
            _flagDate = "0"
            _Date = "1900-01-01"
            lblErrDate.Visible = False
        Else
            _flagDate = "1"
            _Date = GetDateInYYYYMMDD(txtDate.Text)
            lblErrDate.Visible = False
        End If

        If ChkUpdate.Checked = False Then
            _FlagMonth = "0"
            Label6.Visible = False
        Else
            _FlagMonth = "1"
            _Month = ddlMonth.SelectedItem.Text
            Label6.Visible = False
        End If



        Dim dtSelect As New DataTable
        dtSelect = oSelect.f_SEL_LIST_ATTENDANCE_USER_EXPORT_REPORT(_Date, _Month, Session("EMPLNUMBER").ToString, _FlagMonth, _flagDate, Session("YearAttendance"))

        Session("dtSelectExportUser") = dtSelect

    End Sub
    Sub exportReport()

        Dim dgs As New GridView
        dgs.DataSource = Session("dtSelectExportUser")
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
        Session.Remove("dtSelectExportUser")
    End Sub

    Protected Sub Export_Click(sender As Object, e As EventArgs) Handles Export.Click
        Searching_Export()
        exportReport()
    End Sub
    Sub UserLoad()
        Dim dtSelect As New DataTable
        dtSelect = oSelect.f_SEL_LIST_ATTENDANCE_USER_LOAD(Session("EMPLNUMBER").ToString, Session("YearAttendance"))

        dgRekeningKoran.PageSize = 50
        dgRekeningKoran.DataSource = dtSelect
        dgRekeningKoran.Visible = True
        dgRekeningKoran.DataBind()
    End Sub
    Protected Sub Frm_List_ABSEN_USER_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblYears.Text = Session("YearAttendance")
            UserLoad()
            GetStatsCWH_LOAD()
            AccessCWH()
        End If
    End Sub

    Public Function GetDateInYYYYMMDD(ByVal dt As String) As String
        If dt = "1900-01-01" Then
            Return dt
            Exit Function
        End If
        Dim str(3) As String
        str = dt.Split("/")
        Dim tempdt As String = String.Empty
        For i As Integer = 2 To 0 Step -1
            tempdt += str(i) + "-"
        Next
        tempdt = tempdt.Substring(0, 10)
        Return tempdt
    End Function
    Sub GetStatsCWH()
        lblDocCWH.Visible = True
        lblQuarter.Visible = True
        lblStatusApproved.Visible = True
        Label2.Visible = True
        Label3.Visible = True

        lblQuarter.Text = ddlQuarter.SelectedItem.Text
        lblStatusApproved.Text = ""

        Dim dtSel As New DataTable
        dtSel = oSelect.f_SEL_GET_MST_QUARTER(ddlMonth.SelectedValue.ToString())
        If dtSel.Rows.Count > 0 Then
            lblQuarter.Text = dtSel.Rows(0)("Quarters").ToString()
        End If


        Dim dtStat As New DataTable
        dtStat = oSelect.f_SEL_GET_STATUS_APPROVED(lblQuarter.Text, Session("YearAttendance").ToString(), Session("EMPLNUMBER").ToString())
        If dtStat.Rows.Count > 0 Then
            lblStatusApproved.Text = dtStat.Rows(0)("STATUS_APPROVED").ToString()
        Else
            lblStatusApproved.Text = "NOT REQUESTED CWH"
        End If
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
        dtStat = oSelect.f_SEL_GET_STATUS_APPROVED(lblQuarter.Text, Session("YearAttendance").ToString(), Session("EMPLNUMBER").ToString())
        If dtStat.Rows.Count > 0 Then
            lblStatusApproved.Text = dtStat.Rows(0)("STATUS_APPROVED").ToString()
        Else
            lblStatusApproved.Text = "NOT REQUESTED CWH"
        End If
    End Sub
    Protected Sub ddlMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlMonth.SelectedIndexChanged
        GetStatsCWH()
    End Sub

    Sub GetMonthQuarter()
        Dim dtMonth As New DataTable
        dtMonth = oSelect.f_SEL_MST_MONTH_QUARTER(ddlQuarter.SelectedItem.Text.ToString())
        If dtMonth.Rows.Count > 0 Then
            ddlMonth.DataSource = dtMonth
            ddlMonth.DataValueField = "Months"
            ddlMonth.DataTextField = "Months_Desc"
            ddlMonth.DataBind()
            ddlMonth.Enabled = True
            Dim MonthNow As String = DateTime.Now.Month
            ddlMonth.SelectedIndex = ddlMonth.Items.IndexOf(ddlMonth.Items.FindByValue(MonthNow.ToString()))

        End If
    End Sub
    Protected Sub ddlQuarter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlQuarter.SelectedIndexChanged
        GetMonthQuarter()
    End Sub
    Sub AccessCWH()
        Dim dtStat As New DataTable
        dtStat = oSelect.f_GET_STATUS_ACCESS_CWH(Session("EMPLNUMBER").ToString())
        If dtStat.Rows.Count > 0 Then
            Search.Visible = True
            Export.Visible = True
            ListCWH.Visible = True
            LinkButton1.Visible = True
        Else
            Search.Visible = True
            Export.Visible = True
            ListCWH.Visible = False
            LinkButton1.Visible = False
        End If
    End Sub
    Protected Sub ListCWH_Click(sender As Object, e As EventArgs) Handles ListCWH.Click
        'Dim dtStat As New DataTable
        'dtStat = oSelect.f_GET_STATUS_ACCESS_CWH(Session("EMPLNUMBER").ToString())
        'If dtStat.Rows.Count > 0 Then
        '    Response.Redirect("frm_list_Doc_CWH_for_Employee.aspx")
        'Else
        '    Dim sb As New System.Text.StringBuilder()

        '    sb.Append("<script type = 'text/javascript'>")
        '    sb.Append("window.onload=function(){")
        '    sb.Append("alert('")
        '    sb.Append("You are not eligible for CWH Program. Please kindly contact your HR Services")
        '    sb.Append("')};")
        '    sb.Append("</script>")

        '    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        'End If
        Response.Redirect("frm_list_Doc_CWH_for_Employee.aspx")
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Dim dtStat As New DataTable
        dtStat = oSelect.f_GET_STATUS_ACCESS_CWH(Session("EMPLNUMBER").ToString())
        If dtStat.Rows.Count > 0 Then
            Response.Redirect("Frm_Upload_CWH_for_Employee.aspx")
        Else
            Dim sb As New System.Text.StringBuilder()

            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append("You are not eligible for CWH Program. Please kindly contact your HR Services")
            sb.Append("')};")
            sb.Append("</script>")

            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        End If
        'Response.Redirect("Frm_Upload_CWH_for_Employee.aspx")
    End Sub
End Class