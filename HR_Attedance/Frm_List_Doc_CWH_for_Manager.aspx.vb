Public Class Frm_List_Doc_CWH_for_Manager
    Inherits System.Web.UI.Page
    Dim oSelect As New SelectBase
    Sub Searching()
        'lblCount.Visible = False

        'Validation
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



        Dim dtSelect As New DataTable
        dtSelect = oSelect.f_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER(Session("ShortEntity").ToString(), _EmplID, _Year, _Quarter, _flagEmplID, _flagYear, _flagQuarter)
        Session("dtSelect") = dtSelect
            dgRekeningKoran.PageSize = 50
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

    Protected Sub Frm_List_ABSEN_ADMIN_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            DDL_EMPLOYEE()
            UserLoad()
        End If
    End Sub
    Sub UserLoad()
            Dim dtSelect As New DataTable
        dtSelect = oSelect.f_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER_LOAD(Session("ShortEntity").ToString())

        dgRekeningKoran.PageSize = 50
            dgRekeningKoran.DataSource = dtSelect
            dgRekeningKoran.Visible = True
            dgRekeningKoran.DataBind()
        End Sub

    Protected Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Response.Redirect("Frm_List_ABSEN_ADMIN.aspx")
    End Sub

End Class