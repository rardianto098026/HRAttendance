Public Class Frm_List_ABSEN_ADMIN_NONFTE
    Inherits System.Web.UI.Page

    Dim oSelect As New SelectBase
    Sub Searching()
        'lblCount.Visible = False

        'Validation
        If chkAccess.Checked = True And txtAccessCard.Text = "" Then
            lblErrAccessCard.Visible = True
            lblErrAccessCard.Text = "* Please fill the Access Card Number"

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

        lblEmplID2.Visible = False
        lblName.Visible = False

        Label6.Visible = False
        'lblErrType.Visible = False

    End Sub
    Protected Sub Search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Search.Click
        Searching()
    End Sub
    Private Sub grid_Databinding()
        Dim _Access As String = ""
        Dim _EmplID As String = ""
        Dim _NameEmplo As String = ""
        Dim _Month As String = ""

        Dim _flagAccessCard As String
        Dim _flagEmplID As String
        Dim _flagNameEmplo As String
        Dim _FlagMonth As String

        If chkAccess.Checked = False Then
            _flagAccessCard = "0"
            lblErrAccessCard.Visible = False
        Else
            _flagAccessCard = "1"
            _Access = txtAccessCard.Text
            lblErrAccessCard.Visible = False
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

        If ChkUpdate.Checked = False Then
            _FlagMonth = "0"
            Label6.Visible = False
        Else
            _FlagMonth = "1"
            _Month = ddlMonth.SelectedItem.Text
            Label6.Visible = False
        End If



        Dim dtSelect As New DataTable
        dtSelect = oSelect.f_SEL_LIST_ATTENDANCE_ADMIN_NONFTE(Session("Entity").ToString, _Access, _Month, _NameEmplo, _FlagMonth, _flagAccessCard, _flagNameEmplo, _flagEmplID, _EmplID, Session("Role"), Session("EMPLNUMBER").ToString())
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
            Dim AccessCardNo As String = dgRekeningKoran.Items(e.Item.ItemIndex).Cells(4).Text
            Dim Entity As String = dgRekeningKoran.Items(e.Item.ItemIndex).Cells(3).Text
            Response.Redirect("Frm_List_Detail_Admin.aspx?EmployeeID=" + EmployeeID.ToString() + "&EmployeeName=" + EmployeeName.ToString() + "&AccessCardNo=" + AccessCardNo.ToString() + "&Entity=" + Entity.ToString())
        End If
    End Sub

    Protected Sub Frm_List_ABSEN_ADMIN_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblYears.Text = Session("YearAttendance")
        End If

    End Sub
End Class