Public Class Frm_Add_New_Line_Manager
    Inherits System.Web.UI.Page
    Dim oSelect As New SelectBase
    Dim oUpdate As New UpdateBase
    Dim oInsert As New InsertBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'Session("EmployeeID") = Request.QueryString("EmployeeID").ToString
            'Session("EmployeeID_Manager") = Request.QueryString("EmployeeID_Manager").ToString
            DDL_MANAGER_LOAD()
            'DDL_EMPLOYEE_LOAD()
            DDL_MANAGER_Selected(EmplNameManager2.SelectedItem.ToString())
            'DDL_EMPLOYEE_Selected(ddlEmployeeName2.SelectedItem.ToString())
        End If
    End Sub
    Protected Sub ddl_Manager_SelectedIndexChanged(sender As Object, e As EventArgs) Handles EmplNameManager2.SelectedIndexChanged
        DDL_MANAGER_Selected(EmplNameManager2.SelectedValue.ToString())
        DDL_EMPLOYEE_LOAD(EmplNameManager2.SelectedValue.ToString())
    End Sub

    Protected Sub ddl_Employee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlEmployeeName2.SelectedIndexChanged
        DDL_EMPLOYEE_Selected(ddlEmployeeName2.SelectedValue.ToString())
    End Sub
    Sub DDL_EMPLOYEE_Selected(ByVal EmployeeID As String)
        Dim dtEmployee As New DataTable
        dtEmployee = oSelect.f_SEL_LIST_EMPLOYEE_LOAD(ddlEmployeeName2.SelectedValue.ToString())
        'dtManager = oSelect.f_SEL_DETAIL_LINE_MANAGER(Session("EmployeeID").ToString())
        If dtEmployee.Rows.Count > 0 Then
            lblEmployeeID2.Text = dtEmployee.Rows(0)("EmployeeID").ToString()
            Email2.Text = dtEmployee.Rows(0)("Email").ToString()
            lblEntity2.Text = dtEmployee.Rows(0)("Entity").ToString()
            lblWorkerType2.Text = dtEmployee.Rows(0)("WorkerType").ToString()
        End If
    End Sub
    Sub DDL_MANAGER_Selected(ByVal ManagerID As String)
        Dim dtManager As New DataTable
        dtManager = oSelect.f_SEL_LIST_MANAGER_LOAD(EmplNameManager2.SelectedValue.ToString())
        'dtManager = oSelect.f_SEL_DETAIL_LINE_MANAGER(Session("EmployeeID").ToString())
        If dtManager.Rows.Count > 0 Then
            EmplIDManager2.Text = dtManager.Rows(0)("EmployeeID_Manager").ToString()
            EmailManager2.Text = dtManager.Rows(0)("Email_Manager").ToString()

        End If
    End Sub
    Sub DDL_MANAGER_LOAD()
        Dim dtManager As New DataTable
        dtManager = oSelect.f_SEL_LIST_MANAGER_1()
        'dtManager = oSelect.f_SEL_DETAIL_LINE_MANAGER(Session("EmployeeID").ToString())
        If dtManager.Rows.Count > 0 Then
            EmplNameManager2.DataSource = dtManager
            EmplNameManager2.DataValueField = "EmployeeID_Manager"
            EmplNameManager2.DataTextField = "EmployeeName_Manager"

            EmplNameManager2.Enabled = True
            EmplNameManager2.DataBind()
            EmplNameManager2.SelectedIndex = EmplNameManager2.Items.IndexOf(EmplNameManager2.Items.FindByValue(dtManager.Rows(0)("EmployeeName_Manager").ToString()))
        End If
    End Sub
    Sub DDL_EMPLOYEE_LOAD(ByVal ManagerID As String)
        Dim dtEmployee As New DataTable
        dtEmployee = oSelect.f_SEL_LIST_EMPLOYEE(EmplNameManager2.SelectedValue.ToString())
        If dtEmployee.Rows.Count > 0 Then
            ddlEmployeeName2.DataSource = dtEmployee
            ddlEmployeeName2.DataValueField = "EmployeeID"
            ddlEmployeeName2.DataTextField = "EmployeeName"

            ddlEmployeeName2.Enabled = True
            ddlEmployeeName2.DataBind()
            ddlEmployeeName2.SelectedIndex = ddlEmployeeName2.Items.IndexOf(ddlEmployeeName2.Items.FindByValue(dtEmployee.Rows(0)("EmployeeName").ToString()))
        End If
    End Sub

    'Sub DataLOAD()
    '    Dim dtSelect As New DataTable
    '    dtSelect = oSelect.f_SEL_DETAIL_LINE_MANAGER(Session("EmployeeID").ToString())
    '    If dtSelect.Rows.Count > 0 Then
    '        lblEmployeeID2.Text = dtSelect.Rows(0)("EmployeeID").ToString()
    '        ddlEmployeeName2.Text = dtSelect.Rows(0)("EmployeeName").ToString()
    '        Email2.Text = dtSelect.Rows(0)("Email").ToString()
    '        lblEntity2.Text = dtSelect.Rows(0)("Entity").ToString()
    '        lblWorkerType2.Text = dtSelect.Rows(0)("WorkerType").ToString()
    '        EmplIDManager2.Text = dtSelect.Rows(0)("EmployeeID_Manager").ToString()

    '        'DDL_MANAGER_LOAD(EmplIDManager2.Text)
    '        'EmplNameManager2.SelectedIndex = EmplNameManager2.Items.IndexOf(EmplNameManager2.Items.FindByText(dtSelect.Rows(0)("EmployeeName_Manager").ToString()))
    '        'EmplNameManager2.Text = dtSelect.Rows(0)("EmployeeName_Manager").ToString()
    '        EmailManager2.Text = dtSelect.Rows(0)("Email_Manager").ToString()
    '    End If
    'End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        oInsert.f_INSERT_LINE_MANAGER(lblEmployeeID2.Text, ddlEmployeeName2.SelectedItem.ToString(), lblEntity2.Text,
                                      lblWorkerType2.Text, Email2.Text, EmplIDManager2.Text, EmplNameManager2.SelectedItem.ToString(), EmailManager2.Text)
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "redirect",
            "alert('Insert data success'); window.location='/HRAttendance/Frm_Mapping_Line_Manager.aspx';", True)
        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "redirect",
        '"alert('Insert data success');", True)
        'Response.Redirect("Frm_Mapping_Line_Manager.aspx")
        '"alert('Insert data success'); window.location='/HRAttendance/Frm_Mapping_Line_Manager.aspx';", True)
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Response.Redirect("Frm_Mapping_Line_Manager.aspx")
    End Sub

End Class