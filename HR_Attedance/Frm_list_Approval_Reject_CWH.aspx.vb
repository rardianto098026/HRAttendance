Public Class Frm_list_Approval_Reject_CWH
    Inherits System.Web.UI.Page
    Dim oSelect As New SelectBase

    Dim _flagYear1 As Boolean
    Dim _flagQuarter1 As Boolean
    Dim _flagEmplID1 As Boolean
    Dim _flagNameEmplo1 As Boolean
    Sub Searching()
        'lblCount.Visible = False
        Session("msg") = ""
        lblSession.Text = ""
        'Validation
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

        If ChkEmpl1.Checked = True And txtEmplID.Text = "" Then
            lblEmplID2.Visible = True
            lblEmplID2.Text = "* Please fill the Employee Number"

            Exit Sub
        End If

        If ChkName.Checked = True And txtName.Text = "" Then
            lblName.Visible = True
            lblName.Text = "* Please fill the Name Employee"

            Exit Sub
        End If

        grid_Databinding()

        dgRekeningKoran.PageSize = 50
        dgRekeningKoran.CurrentPageIndex = 0
        dgRekeningKoran.DataBind()


        lblTotal.Text = dgRekeningKoran.PageCount
        txtGO.Value = dgRekeningKoran.CurrentPageIndex + 1

        lblEmplID2.Visible = False
        lblName.Visible = False
        Label4.Visible = False
        lblErrAccessCard.Visible = False
        Session("msg") = ""


    End Sub
    Protected Sub Search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Search.Click
        Session("msg") = ""
        Searching()
    End Sub
    Private Sub grid_Databinding()
        Dim _Year As String = ""
        Dim _Quarter As String = ""
        Dim _EmplID As String = ""
        Dim _NameEmplo As String = ""

        Dim _flagYear As String
        Dim _flagQuarter As String
        Dim _flagEmplID As String
        Dim _flagNameEmplo As String


        If chkAccess.Checked = False Then
            _flagYear = "0"
            _flagYear1 = True
            lblErrAccessCard.Visible = False
        Else
            _flagYear = "1"
            _flagYear1 = True
            _Year = ddlYear.SelectedItem.Text
            lblErrAccessCard.Visible = False
        End If

        If CheckBox1.Checked = False Then
            _flagQuarter = "0"
            _flagQuarter1 = False
            Label4.Visible = False
        Else
            _flagQuarter = "1"
            _flagQuarter1 = True
            _Quarter = ddlQuarter.SelectedItem.Text
            Label4.Visible = False
        End If

        If ChkEmpl1.Checked = False Then
            _flagEmplID = "0"
            _flagEmplID1 = False
            lblEmplID2.Visible = False
        Else
            _flagEmplID = "1"
            _flagEmplID1 = True
            _EmplID = txtEmplID.Text
            lblEmplID2.Visible = False
        End If

        If ChkName.Checked = False Then
            _flagNameEmplo = "0"
            _flagNameEmplo1 = False
            lblName.Visible = False
        Else
            _flagNameEmplo = "1"
            _flagNameEmplo1 = True
            _NameEmplo = txtName.Text
            lblName.Visible = False
        End If


        Dim dtSelect As New DataTable
        dtSelect = oSelect.f_SEL_LIST_DOCUMENT_CWH(Session("Entity").ToString, _Year, _Quarter, _EmplID, _NameEmplo, _flagYear, _flagQuarter, _flagEmplID, _flagNameEmplo, Session("Role"))
        Session("_Year") = ddlYear.SelectedIndex
        Session("_Quarter") = ddlQuarter.SelectedIndex
        Session("_EmplID") = txtEmplID.Text
        Session("_NameEmplo") = txtName.Text

        Session("_flagYear") = _flagYear1
        Session("_flagQuarter") = _flagQuarter1
        Session("_flagEmplID") = _flagEmplID1
        Session("_flagNameEmplo") = _flagNameEmplo1

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
            Dim EmployeeID As String = dgRekeningKoran.Items(e.Item.ItemIndex).Cells(1).Text
            Dim EmployeeName As String = dgRekeningKoran.Items(e.Item.ItemIndex).Cells(2).Text
            Dim Years As String = dgRekeningKoran.Items(e.Item.ItemIndex).Cells(4).Text
            Dim Quarters As String = dgRekeningKoran.Items(e.Item.ItemIndex).Cells(5).Text
            Dim Emails As String = dgRekeningKoran.Items(e.Item.ItemIndex).Cells(6).Text
            Dim Entity As String = dgRekeningKoran.Items(e.Item.ItemIndex).Cells(3).Text
            Session("msg") = ""
            Response.Redirect("Frm_Approval_Reject_CWH.aspx?EmplID=" + EmployeeID.ToString() + "&EmployeeName=" + EmployeeName.ToString() + "&Entity=" + Entity.ToString() + "&Year=" + Years.ToString() + "&Quarter=" + Quarters.ToString() + "&Email=" + Emails.ToString())

        End If
    End Sub

    Protected Sub Frm_List_ABSEN_ADMIN_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblSession.Text = Session("msg")
            lblEntity2.Text = Session("Entity")
            lblRole.Text = Session("Role")
            UserLoad()
            If Session("Condition") = "BackNavigate" Then
                ddlYear.SelectedIndex = Session("_Year")
                ddlQuarter.SelectedIndex = Session("_Quarter")
                txtEmplID.Text = Session("_EmplID")
                txtName.Text = Session("_NameEmplo")

                chkAccess.Checked = Session("_flagYear")
                CheckBox1.Checked = Session("_flagQuarter")
                ChkEmpl1.Checked = Session("_flagEmplID")
                ChkName.Checked = Session("_flagNameEmplo")

                Session("Condition") = ""
                Searching()
            End If
        End If

    End Sub
    Sub UserLoad()
        If Session("Role").ToString().ToUpper() = "ADMIN" Then
            Dim dtSelect As New DataTable
            '2020 Februari 28
            'If Session("EMPLNUMBER") = "" Then

            'Else

            'End If
            dtSelect = oSelect.f_SEL_LIST_DOCUMENT_CWH_LOAD(lblEntity2.Text, lblRole.Text)
            If dtSelect.Rows.Count > 0 Then
                dgRekeningKoran.PageSize = 50
                dgRekeningKoran.DataSource = dtSelect
                dgRekeningKoran.Visible = True
                dgRekeningKoran.DataBind()
            End If
        ElseIf Session("Role").ToString().ToUpper() = "SUPER ADMIN" Then
            Dim dtSelect As New DataTable
            dtSelect = oSelect.f_SEL_LIST_DOCUMENT_CWH_LOAD_SUPER_ADMIN(lblRole.Text)
            If dtSelect.Rows.Count > 0 Then
                dgRekeningKoran.PageSize = 50
                dgRekeningKoran.DataSource = dtSelect
                dgRekeningKoran.Visible = True
                dgRekeningKoran.DataBind()
            End If
        ElseIf Session("Role").ToString().ToUpper() = "HRBP" Then
            Dim dtSelect As New DataTable
            dtSelect = oSelect.f_SEL_LIST_DOCUMENT_CWH_LOAD(lblEntity2.Text, lblRole.Text)
            If dtSelect.Rows.Count > 0 Then
                dgRekeningKoran.PageSize = 50
                dgRekeningKoran.DataSource = dtSelect
                dgRekeningKoran.Visible = True
                dgRekeningKoran.DataBind()
            End If
        End If
        'Dim dtSelect As New DataTable
        'dtSelect = oSelect.f_SEL_LIST_DOCUMENT_CWH_LOAD(lblEntity2.Text, lblRole.Text)

        'dgRekeningKoran.PageSize = 50
        'dgRekeningKoran.DataSource = dtSelect
        'dgRekeningKoran.Visible = True
        'dgRekeningKoran.DataBind()
    End Sub

    Protected Sub Export_Click(sender As Object, e As EventArgs) Handles eXPORT.Click
        Searching_Export()
        exportReport()
    End Sub

    Sub Searching_Export()
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

        If ChkEmpl1.Checked = True And txtEmplID.Text = "" Then
            lblEmplID2.Visible = True
            lblEmplID2.Text = "* Please fill the Employee Number"

            Exit Sub
        End If

        If ChkName.Checked = True And txtName.Text = "" Then
            lblName.Visible = True
            lblName.Text = "* Please fill the Name Employee"

            Exit Sub
        End If

        grid_Export()
    End Sub

    Private Sub grid_Export()
        Dim _Year As String = ""
        Dim _Quarter As String = ""
        Dim _EmplID As String = ""
        Dim _NameEmplo As String = ""

        Dim _flagYear As String
        Dim _flagQuarter As String
        Dim _flagEmplID As String
        Dim _flagNameEmplo As String

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

        If ChkEmpl1.Checked = False Then
            _flagEmplID = "0"
            lblEmplID2.Visible = False
        Else
            _flagEmplID = "1"
            _EmplID = txtEmplID.Text
            lblEmplID2.Visible = False
        End If

        If ChkName.Checked = False Then
            _flagNameEmplo = "0"
            lblName.Visible = False
        Else
            _flagNameEmplo = "1"
            _NameEmplo = txtName.Text
            lblName.Visible = False
        End If

        Dim dtSelect As New DataTable
        dtSelect = oSelect.f_SEL_LIST_DOCUMENT_CWH_EXPORT(Session("Entity").ToString, _Year, _Quarter, _EmplID, _NameEmplo, _flagYear, _flagQuarter, _flagEmplID, _flagNameEmplo, Session("Role"))
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
            End If
        Next



        Dim filename As String = "List Request CWH" & Strings.Right(DateTime.Now.Year.ToString, 4).PadLeft(4, "0") & DateTime.Now.Month.ToString.PadLeft(2, "0") & DateTime.Now.Day.ToString.PadLeft(2, "0") & ".xls"


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