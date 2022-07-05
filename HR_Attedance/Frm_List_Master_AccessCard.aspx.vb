﻿Public Class Frm_List_Master_AccessCard
    Inherits System.Web.UI.Page
    Dim oSelect As New SelectBase
    Sub Searching()
        'lblCount.Visible = False
        'Session("msg1") = ""
        lblSession.Text = ""
        'Validation
        If ChkAccess.Checked = True And txtAccessCard.Text = "" Or txtAccessCard.Text = "--Select--" Then
            lblAccess.Visible = True
            lblAccess.Text = "* Please fill the Access Card Number"

            Exit Sub
        End If

        If ChkEmpl.Checked = True And txtEmplID.Text = "" Or txtEmplID.Text = "--Select--" Then
            lblEmpl.Visible = True
            lblEmpl.Text = "* Please fill the Employee Name"

            Exit Sub
        End If

        Session("msg1") = ""

        grid_Databinding()

        dgRekeningKoran.PageSize = 50
        dgRekeningKoran.CurrentPageIndex = 0
        dgRekeningKoran.DataBind()


        lblTotal.Text = dgRekeningKoran.PageCount
        txtGO.Value = dgRekeningKoran.CurrentPageIndex + 1

        lblEmpl.Visible = False
        Session("msg1") = ""
        'lblErrType.Visible = False

    End Sub

    Protected Sub Search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Search.Click
        Session("msg1") = ""
        Searching()
    End Sub
    Private Sub grid_Databinding()
        Dim _Access As String = ""
        Dim _NameEmplo As String = ""

        Dim _flagAccess As String
        Dim _flagEmplName As String

        Dim _flagNameEmplo As String

        If ChkAccess.Checked = False Then
            _flagAccess = "0"
            _Access = ""
            lblAccess.Visible = False
        Else
            _flagAccess = "1"
            _Access = txtAccessCard.Text
            lblAccess.Visible = False
        End If

        If ChkEmpl.Checked = False Then
            _flagEmplName = "0"
            _NameEmplo = ""
            lblEmpl.Visible = False
        Else
            _flagEmplName = "1"
            _flagNameEmplo = "0"
            _NameEmplo = txtEmplID.Text
            lblEmpl.Visible = False
        End If

        Session("msg1") = ""

        Dim dtSelect As New DataTable
        dtSelect = oSelect.f_SEL_MST_EMPLOYEE(_Access, _flagAccess, _flagEmplName, _NameEmplo)
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
            'Dim AccessCardNo As String = dgRekeningKoran.Items(e.Item.ItemIndex).Cells(4).Text
            Dim Entity As String = dgRekeningKoran.Items(e.Item.ItemIndex).Cells(3).Text
            Dim AccessCardNo As String = dgRekeningKoran.Items(e.Item.ItemIndex).Cells(4).Text
            Session("msg1") = ""
            Response.Redirect("Frm_Edit_Master_AccessCard.aspx?EmployeeID=" + EmployeeID.ToString() + "&AccessCardNo=" + AccessCardNo.ToString())

        End If
        End Sub
        Sub AdminLOAD()
            Dim dtSelect As New DataTable
        dtSelect = oSelect.f_SEL_MST_EMPLOYEE_LOAD()

        dgRekeningKoran.PageSize = 50
            dgRekeningKoran.DataSource = dtSelect
            dgRekeningKoran.Visible = True
            dgRekeningKoran.DataBind()
        End Sub


    Protected Sub Frm_List_ABSEN_ADMIN_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblSession.Text = Session("msg1")
            AdminLOAD()
            lblEntity2.Text = Session("Entity")
            lblRole.Text = Session("Role")
        End If
    End Sub

    Protected Sub Export_Click(sender As Object, e As EventArgs) Handles Export.Click
        Searching_Export()
        exportReport()
    End Sub

    Sub Searching_Export()
        If ChkAccess.Checked = True And txtAccessCard.Text = "" Then
            lblAccess.Visible = True
            lblAccess.Text = "* Please fill the Access Card Number"

            Exit Sub
        End If

        If ChkEmpl.Checked = True And txtEmplID.Text = "" Then
            lblEmpl.Visible = True
            lblEmpl.Text = "* Please fill the Employee Number"

            Exit Sub
        End If

        grid_Export()
    End Sub

    Private Sub grid_Export()
        Dim _Access As String = ""
        Dim _NameEmplo As String = ""

        Dim _flagAccess As String
        Dim _flagEmplName As String

        Dim _flagNameEmplo As String

        If ChkAccess.Checked = False Then
            _flagAccess = "0"
            _Access = ""
            lblAccess.Visible = False
        Else
            _flagAccess = "1"
            _Access = txtAccessCard.Text
            lblAccess.Visible = False
        End If

        If ChkEmpl.Checked = False Then
            _flagEmplName = "0"
            _NameEmplo = ""
            lblEmpl.Visible = False
        Else
            _flagEmplName = "1"
            _flagNameEmplo = "0"
            _NameEmplo = txtEmplID.Text
            lblEmpl.Visible = False
        End If

        Dim dtSelect As New DataTable
        dtSelect = oSelect.f_SEL_ACCESSCARD_FOR_EXPORT(_Access, _flagAccess, _flagEmplName, _NameEmplo)
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
            End If
        Next



        Dim filename As String = "List Access Card" & Strings.Right(DateTime.Now.Year.ToString, 4).PadLeft(4, "0") & DateTime.Now.Month.ToString.PadLeft(2, "0") & ".xls"


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