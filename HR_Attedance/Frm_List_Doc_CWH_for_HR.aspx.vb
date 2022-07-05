Public Class Frm_List_Doc_CWH_for_HR
    Inherits System.Web.UI.Page
    Dim oSelect As New SelectBase
    Sub Searching()
        'lblCount.Visible = False

        'Validation
        'If ChkEmployee.Checked = False And chkAccess.Checked = False And CheckBox1.Checked = False Then
        '    DDL_EMPLOYEE()
        '    UserLoad()
        '    Exit Sub
        'End If

        If ChkEmployee.Checked = True And txtEmplName.SelectedItem.Value.ToString = "0" Then
            Label5.Visible = True
            Label5.Text = "* Please Choose Employee Name"

            Exit Sub
        End If

        If chkAccess.Checked = True And ddlYear.SelectedItem.Value.ToString = "0" Then
            lblErrAccessCard.Visible = True
            lblErrAccessCard.Text = "* Please Choose Year"

            Exit Sub
        End If

        If CheckBox1.Checked = True And ddlQuarter.SelectedItem.Value.ToString = "0" Then
            Label4.Visible = True
            Label4.Text = "* Please Choose Quarter"

            Exit Sub
        End If

        grid_Databinding()

        dgRekeningKoran.PageSize = 50
        dgRekeningKoran.CurrentPageIndex = 0
        dgRekeningKoran.DataBind()


        lblTotal.Text = dgRekeningKoran.PageCount
        txtGO.Value = dgRekeningKoran.CurrentPageIndex + 1

        Label4.Visible = False
        lblErrAccessCard.Visible = False



    End Sub
    Sub DDL_EMPLOYEE()

        If Session("Role").ToString().ToUpper() = "HRBP" Then
            Dim dtEmployee As New DataTable

            dtEmployee = oSelect.f_MAPPING_CWHEMPLOYEE_MANAGER(Session("Entity").ToString())
            If dtEmployee.Rows.Count > 0 Then
                txtEmplName.DataSource = dtEmployee
                txtEmplName.DataValueField = "EmployeeID"
                txtEmplName.DataTextField = "EmployeeName"
                txtEmplName.DataBind()
                txtEmplName.Enabled = True
                txtEmplName.Items.Insert(0, New ListItem("--Select--", "--Select--"))

            End If
        ElseIf Session("Role").ToString().ToUpper() = "ADMIN" Then
            Dim dtEmployee As New DataTable

            dtEmployee = oSelect.f_MAPPING_CWHEMPLOYEE_MANAGER(Session("Entity").ToString())
            If dtEmployee.Rows.Count > 0 Then
                txtEmplName.DataSource = dtEmployee
                txtEmplName.DataValueField = "EmployeeID"
                txtEmplName.DataTextField = "EmployeeName"
                txtEmplName.DataBind()
                txtEmplName.Enabled = True
                txtEmplName.Items.Insert(0, New ListItem("--Select--", "--Select--"))

            End If
        ElseIf Session("Role").ToString().ToUpper() = "SUPER ADMIN" Then
            Dim dtEmployee As New DataTable

            dtEmployee = oSelect.f_MAPPING_CWHEMPLOYEE_MANAGER_SUPER_ADMIN()
            If dtEmployee.Rows.Count > 0 Then
                txtEmplName.DataSource = dtEmployee
                txtEmplName.DataValueField = "EmployeeID"
                txtEmplName.DataTextField = "EmployeeName"
                txtEmplName.DataBind()
                txtEmplName.Enabled = True
                txtEmplName.Items.Insert(0, New ListItem("--Select--", "--Select--"))

            End If

        End If

        'Dim dtEmployee As New DataTable

        'dtEmployee = oSelect.f_MAPPING_CWHEMPLOYEE_MANAGER(Session("Entity").ToString())
        'If dtEmployee.Rows.Count > 0 Then
        '    txtEmplName.DataSource = dtEmployee
        '    txtEmplName.DataValueField = "EmployeeID"
        '    txtEmplName.DataTextField = "EmployeeName"
        '    txtEmplName.DataBind()
        '    txtEmplName.Enabled = True
        '    txtEmplName.Items.Insert(0, New ListItem("--Select--", "--Select--"))

        'End If
    End Sub
    Protected Sub Search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Search.Click
        Searching()
    End Sub
    Private Sub grid_Databinding()
        Dim _Year As String = ""
        Dim _Quarter As String = ""
        Dim _EmplID As String = ""
        Dim _NameEmpl As String = ""

        Dim _flagYear As String
        Dim _flagQuarter As String
        Dim _flagEmplID As String
        'Dim _flagNameEmplo As String

        If ChkEmployee.Checked = False Then
            _flagEmplID = "0"
            Label5.Visible = False
        Else
            _flagEmplID = "1"
            _EmplID = txtEmplName.SelectedValue.ToString()
            _NameEmpl = txtEmplName.SelectedItem.Text
            Label5.Visible = False
        End If

        If chkAccess.Checked = False Then
            _flagYear = "0"
            lblErrAccessCard.Visible = False
        Else
            _flagYear = "1"
            _Year = ddlYear.SelectedItem.Text
            lblErrAccessCard.Visible = False
        End If

        If CheckBox1.Checked = False Then
            _flagQuarter = "0"
            Label4.Visible = False
        Else
            _flagQuarter = "1"
            _Quarter = ddlQuarter.SelectedItem.Text
            Label4.Visible = False
        End If


        If Session("Role").ToString().ToUpper() = "HRBP" Or Session("Role").ToString().ToUpper() = "ADMIN" Then
            Dim dtSelect As New DataTable
            dtSelect = oSelect.f_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER(Session("ShortEntity").ToString(), _EmplID, _Year, _Quarter, _flagEmplID, _flagYear, _flagQuarter)
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
        ElseIf Session("Role").ToString().ToUpper() = "SUPER ADMIN" Then
            Dim dtSelect As New DataTable
            dtSelect = oSelect.f_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER_SUPER_ADMIN(Session("ShortEntity").ToString(), _EmplID, _Year, _Quarter, _flagEmplID, _flagYear, _flagQuarter)
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
        End If



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
            Dim EmployeeID As String = dgRekeningKoran.Items(e.Item.ItemIndex).Cells(9).Text
            Dim Years As String = dgRekeningKoran.Items(e.Item.ItemIndex).Cells(1).Text
            Dim Quarters As String = dgRekeningKoran.Items(e.Item.ItemIndex).Cells(2).Text
            Dim Entity As String = dgRekeningKoran.Items(e.Item.ItemIndex).Cells(6).Text
            Dim FileName As String = dgRekeningKoran.Items(e.Item.ItemIndex).Cells(7).Text
            Dim StatCWH As String = dgRekeningKoran.Items(e.Item.ItemIndex).Cells(3).Text

            Dim Link As String = "/HRAttendance/upload/" + "CWH" + StatCWH + "/" + Years + "/" + Quarters + "/" + Entity + "/" + EmployeeID + "/" + FileName

            Dim sb As New StringBuilder()
            sb.Append(" <Script type = 'text/javascript'>")
            sb.Append("window.open('")
            sb.Append(Link)
            sb.Append("');")
            sb.Append("</script>")
            ClientScript.RegisterStartupScript(Me.GetType(),
                  "script", sb.ToString())

            ' Response.Redirect("Frm_Approval_Reject_CWH.aspx?EmplID=" + EmployeeID.ToString() + "&EmployeeName=" + EmployeeName.ToString() + "&Entity=" + Entity.ToString() + "&Year=" + Years.ToString() + "&Quarter=" + Quarters.ToString() + "&Email=" + Emails.ToString())

        End If
    End Sub

    'Protected Sub Frm_List_ABSEN_ADMIN_Load(sender As Object, e As EventArgs) Handles Me.Load
    '    If Not Page.IsPostBack Then
    '        DDL_EMPLOYEE()
    '        UserLoad()
    '    End If
    'End Sub
    Sub UserLoad()
        If Session("Role").ToString().ToUpper() = "HRBP" Or Session("Role").ToString().ToUpper() = "ADMIN" Then
            Dim dtSelect As New DataTable
            dtSelect = oSelect.f_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER_LOAD(Session("ShortEntity").ToString())

            dgRekeningKoran.PageSize = 50
            dgRekeningKoran.DataSource = dtSelect
            dgRekeningKoran.Visible = True
            dgRekeningKoran.DataBind()
        ElseIf Session("Role").ToString().ToUpper() = "SUPER ADMIN" Then
            Dim dtSelect As New DataTable
            dtSelect = oSelect.f_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER_LOAD_SUPER_ADMIN(Session("ShortEntity").ToString())

            dgRekeningKoran.PageSize = 50
            dgRekeningKoran.DataSource = dtSelect
            dgRekeningKoran.Visible = True
            dgRekeningKoran.DataBind()
        End If
    End Sub

    Protected Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Response.Redirect("Frm_List_ABSEN_ADMIN.aspx")
    End Sub

    Protected Sub Frm_List_Doc_CWH_for_HR_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            DDL_EMPLOYEE()
            UserLoad()
        End If
    End Sub

    Protected Sub Export_Click(sender As Object, e As EventArgs) Handles eXPORT.Click
        Searching_Export()
        exportReport()
    End Sub

    Sub Searching_Export()
        If ChkEmployee.Checked = True And txtEmplName.SelectedItem.Value.ToString = "0" Then
            Label5.Visible = True
            Label5.Text = "* Please Choose Employee Name"

            Exit Sub
        End If

        If chkAccess.Checked = True And ddlYear.SelectedItem.Value.ToString = "0" Then
            lblErrAccessCard.Visible = True
            lblErrAccessCard.Text = "* Please Choose Year"

            Exit Sub
        End If

        If CheckBox1.Checked = True And ddlQuarter.SelectedItem.Value.ToString = "0" Then
            Label4.Visible = True
            Label4.Text = "* Please Choose Quarter"

            Exit Sub
        End If

        grid_Export()
    End Sub

    Private Sub grid_Export()
        Dim _Year As String = ""
        Dim _Quarter As String = ""
        Dim _EmplID As String = ""
        Dim _NameEmpl As String = ""

        Dim _flagYear As String
        Dim _flagQuarter As String
        Dim _flagEmplID As String
        'Dim _flagNameEmplo As String

        If ChkEmployee.Checked = False Then
            _flagEmplID = "0"
            Label5.Visible = False
        Else
            _flagEmplID = "1"
            _EmplID = txtEmplName.SelectedValue.ToString()
            _NameEmpl = txtEmplName.SelectedItem.Text
            Label5.Visible = False
        End If

        If chkAccess.Checked = False Then
            _flagYear = "0"
            lblErrAccessCard.Visible = False
        Else
            _flagYear = "1"
            _Year = ddlYear.SelectedItem.Text
            lblErrAccessCard.Visible = False
        End If

        If CheckBox1.Checked = False Then
            _flagQuarter = "0"
            Label4.Visible = False
        Else
            _flagQuarter = "1"
            _Quarter = ddlQuarter.SelectedItem.Text
            Label4.Visible = False
        End If


        If Session("Role").ToString().ToUpper() = "HRBP" Or Session("Role").ToString().ToUpper() = "ADMIN" Then
            Dim dtSelect As New DataTable
            dtSelect = oSelect.f_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER_EXPORT(Session("ShortEntity").ToString(), _EmplID, _Year, _Quarter, _flagEmplID, _flagYear, _flagQuarter)
            Session("dtSelectExportUser") = dtSelect
        ElseIf Session("Role").ToString().ToUpper() = "SUPER ADMIN" Then
            Dim dtSelect As New DataTable
            dtSelect = oSelect.f_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER_SUPER_ADMIN_EXPORT(Session("ShortEntity").ToString(), _EmplID, _Year, _Quarter, _flagEmplID, _flagYear, _flagQuarter)
            Session("dtSelectExportUser") = dtSelect
        End If
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
            End If
        Next



        Dim filename As String = "List History CWH" & Strings.Right(DateTime.Now.Year.ToString, 4).PadLeft(4, "0") & DateTime.Now.Month.ToString.PadLeft(2, "0") & DateTime.Now.Day.ToString.PadLeft(2, "0") & ".xls"


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
End Class