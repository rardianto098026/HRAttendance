﻿
Imports System.Data.OleDb
Imports System.Data
Imports System.IO
Imports System.Configuration
Imports System.Web.UI
Imports System.Web
Imports System.DirectoryServices
Imports System.Data.SqlClient
Partial Class Frm_User_Matrix
    Inherits System.Web.UI.Page
    Dim dttmpLDAP As DataTable
    Dim oInsert As New InsertBase
    Dim oSelect As New SelectBase
    Dim oDelete As New DeleteBase

    Dim _connectionString_AFI As String = ConfigurationManager.ConnectionStrings("ConSql").ToString
    Dim conn As SqlConnection

    Public Sub LoadADSIDetail()

        Dim counter As Int16 = 0
        Dim searcher As New DirectorySearcher("")

        Try
            'searcher.Filter = "(&(!(userAccountControl:1.2.840.113556.1.4.803:=2))(objectCategory=user))"
            searcher.Filter = "(&(objectCategory=person)(objectClass=user)(!(userAccountControl:1.2.840.113556.1.4.803:=2)))"
            searcher.PageSize = 10000
            searcher.SearchScope = SearchScope.Subtree

            Dim Email, UserName, GlobalUser As String
            GlobalUser = ""

            'Yensen added for LDAP'
            Dim dtLDAP As New DataTable

            Dim dcName As DataColumn
            Dim dcEmail As DataColumn

            dcName = New DataColumn("Name", System.Type.GetType("System.String"))
            dcEmail = New DataColumn("Email", System.Type.GetType("System.String"))

            dtLDAP.Columns.Add(dcName)
            dtLDAP.Columns.Add(dcEmail)

            For Each result As SearchResult In searcher.FindAll()
                Email = ""
                UserName = ""

                counter = counter + 1

                If Not (IsNothing(result)) Then
                    Dim myResultPropColl As ResultPropertyCollection
                    myResultPropColl = result.Properties

                    Dim myKey As String
                    For Each myKey In myResultPropColl.PropertyNames
                        Select Case myKey
                            'Case "samaccountname"
                            Case "name"
                                Try
                                    UserName = myResultPropColl(myKey)(0)

                                Catch ex As Exception
                                    UserName = ""
                                End Try

                            Case "mail"
                                Try
                                    Email = myResultPropColl(myKey)(0)

                                Catch ex As Exception
                                    Email = ""
                                End Try
                        End Select


                        If UserName <> "" And Email <> "" Then
                            '    InsertLDAP2(UserName, Email)
                            AddRowdtLDAP(dtLDAP, UserName, Email)
                        End If
                        'end adding

                    Next
                End If

                GlobalUser &= UserName & ":" & Email & ";"
            Next

            If Request.QueryString("id") = "" Then
                dttmpLDAP = dtLDAP.DefaultView.ToTable(True, "Name", "Email")
            Else
                dttmpLDAP = dtLDAP.DefaultView.ToTable(True, "Name", "Email")
                dttmpLDAP.DefaultView.RowFilter = "(Name like '%" & Request.QueryString("id") & "%')"
            End If

            dttmpLDAP.DefaultView.Sort = "Name asc"
            txtUserName.DataSource = dttmpLDAP
            txtUserName.DataTextField = "Name"
            txtUserName.DataValueField = "Name"
            txtUserName.DataBind()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    Public Sub AddRowdtLDAP(ByVal _dtLDAP As DataTable, ByVal _strName As String, ByVal _strEmail As String)
        Dim newRow As DataRow = _dtLDAP.NewRow()

        newRow("Name") = _strName
        newRow("Email") = _strEmail

        _dtLDAP.Rows.Add(newRow)

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim CompName As String = User.Identity.Name
            Dim Names As String = CompName.Replace("AXA-INDONESIA/", "")
            Dim LocalHostaddress As String = HttpContext.Current.Request.UserHostAddress
            Dim dtlogin As New DataTable
            'dtlogin = oSelect.f_InsertLogin(Session("UserID").ToString, Session("Entity"))
            dtlogin = oSelect.f_InsertLogin(Session("UserID").ToString, LocalHostaddress, Session("Entity"), Session("EMPLNUMBER").ToString)
        Catch ex As Exception
            'Exit Sub
            Dim errors As String
            errors = ex.Message

            Dim message As String = errors
            Dim sb As New System.Text.StringBuilder()
            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(message)
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        End Try
        'Check()
        'If Page.IsPostBack = False Then
        If Not Page.IsPostBack Then
            ' Populate1()
            LoadEmployee()
            'LoadADSIDetail()
        End If
    End Sub
    Sub LoadEmployee()
        Dim dtEmployee As New DataTable
        dtEmployee = oSelect.f_SEL_MST_EMPLOYEE()
        If dtEmployee.Rows.Count > 0 Then
            txtUserName.DataSource = dtEmployee
            txtUserName.DataValueField = "EmployeeID"
            txtUserName.DataTextField = "EmployeeName"
            txtUserName.DataBind()
            txtUserName.Items.Insert(0, New ListItem("--Select--", "--Select--"))
        End If
    End Sub
    Public Function FindControlRecursive(Of ItemType)(ByVal Ctrl As Object, ByVal id As String) As ItemType
        If String.Compare(Ctrl.ID, id, StringComparison.OrdinalIgnoreCase) = 0 AndAlso TypeOf Ctrl Is ItemType Then
            Return CType(Ctrl, ItemType)
        End If

        For Each c As Control In Ctrl.Controls
            Dim t As ItemType = FindControlRecursive(Of ItemType)(c, id)

            If t IsNot Nothing Then
                Return t
            End If
        Next

        Return Nothing
    End Function

    Public Sub check()

        Try

            Dim ds As DataSet = New DataSet()

            Dim dtparent As DataTable = New DataTable()

            Dim dtchild As DataTable = New DataTable()

            dtparent = FillParentTable()

            dtparent.TableName = "MST_MENU"

            dtchild = FillChildTable()

            dtchild.TableName = "MST_MENU_CHILD"

            ds.Tables.Add(dtparent)

            ds.Tables.Add(dtchild)
            ds.EnforceConstraints = False
            ds.Relations.Add("children", dtparent.Columns("IDMenu"), dtchild.Columns("IDMenu"))
            TreeView1.Nodes.Clear()

            Dim objDR As SqlClient.SqlDataReader
            Dim objCommand As SqlCommand
            'Dim _connectionString As String = IIf(Entitys = "AFI", _connectionString_AFI, _connectionString_AMFS)

            Dim ssql As String

            Dim ssql2 As String

            ssql = "SELECT a.UserName,b.IDMenuChild FROM dbo.MST_USER_MATRIX a " &
                    "inner join MST_MENU_CHILD b on a.IDMenuChild = b.IDMenuChild " &
                    "where UserName = '" & txtUserName.SelectedItem.Text & "' and flag = 1" &
                    "order by b.Idx"
            ssql2 = "SELECT IDMENUCHILD from mst_menu_child"

            If conn.State <> ConnectionState.Open Then
                conn.Open()
            End If




            'if (ds.Tables[0].Rows.Count > 0) then

            If (ds.Tables(0).Rows.Count > 0) Then

                TreeView1.Nodes.Clear()

                For Each masterRow As DataRow In ds.Tables(0).Rows
                    Dim masterNode As TreeNode = New TreeNode(masterRow("MenuName").ToString, Convert.ToString(masterRow("IDMenu")))
                    'If CheckBox1.Checked = True Then
                    '    masterNode.Checked = True
                    'Else
                    '    masterNode.Checked = False
                    'End If
                    TreeView1.Nodes.Add(masterNode)
                    'masterNode.ShowCheckBox = False
                    TreeView1.CollapseAll()

                    For Each childRow As DataRow In masterRow.GetChildRows("children")
                        Dim childNode As TreeNode = New TreeNode(childRow("MenuNameChild").ToString, Convert.ToString(childRow("IDMenuChild")))
                        masterNode.ChildNodes.Add(childNode)
                        childNode.Value = Convert.ToString(childRow("IDMenuChild"))
                    Next
                Next
            End If


            objCommand = New SqlClient.SqlCommand(ssql, conn)
            objDR = objCommand.ExecuteReader(CommandBehavior.CloseConnection)
            objCommand = Nothing
            Dim value As String


            While objDR.Read()
                value = CStr(objDR("IDMenuChild"))
                For Each listaa As TreeNode In TreeView1.Nodes
                    listaa.ShowCheckBox = False
                    For Each Lists As TreeNode In listaa.ChildNodes
                        If Lists.Value = value Then
                            Lists.Checked = True
                        End If
                    Next
                Next
            End While


            conn.Close()
            TreeView1.ShowCheckBoxes = TreeNodeTypes.Leaf
            TreeView1.ExpandAll()
        Catch ex As Exception
            Throw New Exception("Unable to populate treeview" + ex.Message)
        End Try
    End Sub
    Public Function FillParentTable() As DataTable
        Dim dt As DataTable = New DataTable()

        conn = New SqlClient.SqlConnection(_connectionString_AFI)

        conn.Open()
        Dim cmdstr As String = "Select * from MST_MENU"

        Dim cmd As SqlCommand = New SqlCommand(cmdstr, conn)
        Dim adp As SqlDataAdapter = New SqlDataAdapter(cmd)
        adp.Fill(dt)
        conn.Close()
        Return dt
    End Function

    Public Function FillChildTable() As DataTable
        Dim dt As DataTable = New DataTable()

        conn = New SqlClient.SqlConnection(_connectionString_AFI)

        conn.Open()
        Dim cmdstr As String = "Select * from MST_MENU_CHILD"
        Dim cmd As SqlCommand = New SqlCommand(cmdstr, conn)
        Dim adp As SqlDataAdapter = New SqlDataAdapter(cmd)
        adp.Fill(dt)
        conn.Close()
        Return dt
    End Function


    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try
            If DropDownList1.SelectedItem.Text = "--Select--" Then
                LblErr.Visible = True
                LblErr.Text = "Please Choose Role"
                Exit Sub
            End If

            Dim UserName As String = txtUserName.SelectedItem.Text
            Dim CreatedBy As String = Session("UserName").ToString
            Dim Entity As String = Session("Entity")
            Dim EmplID As String = txtUserName.SelectedValue.ToString
            Dim flag, IdMenuChild As String
            Dim objDR As SqlClient.SqlDataReader
            Dim objCommand As SqlCommand
            Dim objConnection As SqlConnection
            Dim ssql As String

            For Each RootNode As TreeNode In TreeView1.Nodes
                For Each Lists As TreeNode In RootNode.ChildNodes
                    If Lists.Checked = True Then
                        objConnection = New SqlClient.SqlConnection(_connectionString_AFI)


                        ssql = "SELECT	* FROM dbo.MST_USER_MATRIX where UserName = '" & txtUserName.SelectedItem.Text & "' and IDMenuChild = '" & Lists.Value & "' and flag = 1 and EmployeeID ='" & EmplID & "'"

                        If objConnection.State <> ConnectionState.Open Then
                            objConnection.Open()
                        End If

                        objCommand = New SqlClient.SqlCommand(ssql, objConnection)
                        objDR = objCommand.ExecuteReader(CommandBehavior.CloseConnection)
                        objCommand = Nothing

                        If objDR.HasRows Then
                            objDR.Read()
                            flag = CStr(objDR("Flag"))
                            IdMenuChild = CStr(objDR("IDMenuChild"))
                        Else
                            objDR.Read()
                            flag = 2
                            IdMenuChild = ""
                        End If

                        If Not objDR.HasRows = True And flag = "2" Then
                            oInsert.f_Insert_User_Matrix(UserName, Lists.Value, CreatedBy, Entity, DropDownList1.SelectedItem.Text, EmplID)

                            Dim message As String = "Save Data Sukses"
                            Dim sb As New System.Text.StringBuilder()
                            sb.Append("<script type = 'text/javascript'>")
                            sb.Append("window.onload=function(){")
                            sb.Append("alert('")
                            sb.Append(message)
                            sb.Append("')};")
                            sb.Append("</script>")
                            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                            'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "redirect", "alert('Save Data Sukses'); window.location='Home.aspx';", True)
                        End If
                        objDR.Close()

                    ElseIf Lists.Checked = False Then

                        objConnection = New SqlClient.SqlConnection(_connectionString_AFI)

                        ssql = "SELECT	* FROM dbo.MST_USER_MATRIX where UserName = '" & txtUserName.SelectedItem.Text & "' and IDMenuChild = '" & Lists.Value & "' and flag = 1 and EmployeeID ='" & EmplID & "'"

                        If objConnection.State <> ConnectionState.Open Then
                            objConnection.Open()
                        End If
                        objCommand = New SqlClient.SqlCommand(ssql, objConnection)
                        objDR = objCommand.ExecuteReader(CommandBehavior.CloseConnection)
                        objCommand = Nothing

                        If objDR.HasRows Then
                            oInsert.f_Edit_User_Matrix(UserName, Lists.Value, CreatedBy, Entity, DropDownList1.SelectedItem.Text, EmplID)

                            Dim message As String = "Edit Data Sukses"
                            Dim sb As New System.Text.StringBuilder()
                            sb.Append("<script type = 'text/javascript'>")
                            sb.Append("window.onload=function(){")
                            sb.Append("alert('")
                            sb.Append(message)
                            sb.Append("')};")
                            sb.Append("</script>")
                            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                            'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "redirect", "alert('Edit Data Sukses'); window.location='Home.aspx';", True)
                        End If

                    End If

                Next
            Next
            LblErr.Visible = False
        Catch ex As Exception
            Exit Sub

        End Try

    End Sub


    Protected Sub btnRetr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRetr.Click
        check()

    End Sub


    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Frm_list_absen_user.aspx")
    End Sub

    Protected Sub BtnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        oDelete.Del_USER_MATRIX(txtUserName.SelectedItem.Text)
    End Sub

    Protected Sub Export_Click(sender As Object, e As EventArgs) Handles eXPORT.Click
        exportReport()
    End Sub

    Private Sub grid_Export()

        Dim dtSelect As New DataTable
        dtSelect = oSelect.f_MST_EMPLOYEE()
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
            End If
        Next



        Dim filename As String = "Master Employee" & Strings.Right(DateTime.Now.Year.ToString, 4).PadLeft(4, "0") & DateTime.Now.Month.ToString.PadLeft(2, "0") & DateTime.Now.Day.ToString.PadLeft(2, "0") & ".xls"


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

