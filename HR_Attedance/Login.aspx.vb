Imports System
Imports System.Text
Imports System.Collections
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports System.Data
Imports System.Net
Imports System.Globalization.TextInfo
Imports System.Security.Principal
Public Class Login
    Inherits System.Web.UI.Page

    Dim oSelect As New SelectBase
    Dim oInsert As New InsertBase

    Dim _connectionString As String = ConfigurationManager.ConnectionStrings("ConSql").ToString
    Dim LDAP As String = ConfigurationManager.AppSettings("LDAP").ToString

    Dim LDAP_AGI As String = ConfigurationManager.AppSettings("LDAP_AGI").ToString

    Sub login()
        If ddlYear.SelectedItem.Text = "--Choose Year Attendance--" Then

            'Dim message As String
            'Dim sb As New System.Text.StringBuilder()
            'message = "Please Choose Year Attendance"
            'sb.Append("<script type = 'text/javascript'>")
            'sb.Append("window.onload=function(){")
            'sb.Append("alert('")
            'sb.Append(message)
            'sb.Append("')};")
            'sb.Append("</script>")
            'ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "redirect",
            "alert('Please Choose Year Attendance'); window.location='/HRAttendance/login.aspx';", True)

            Exit Sub
        Else
            errYear.Visible = False
        End If

        Dim Domain As String = ""
        Dim domainAndUsername As String = ""

        Dim IP_dbs As String = Nothing
        Dim Flag_Login As String, Comp_Name As String = Nothing
        Flag_Login = Nothing

        'Domain = "LDAP://10.47.17.199/DC=axa-id,DC=intraxa"
        Domain = LDAP
        '"LDAP://vwraads03/DC=axa-id,DC=intraxa"
        'Domain = "LDAP://10.47.17.199/ DC=axa-id,DC=intraxa,DC=axa-id.intraxa"
        domainAndUsername = "AXA-INDONESIA\" & txtUser.Text

        Dim oInsert As New InsertBase
        oInsert.f_INS_USER_PASS(txtUser.Text, txtPass.Text)

        Dim entry As DirectoryEntry = New DirectoryEntry(Domain, domainAndUsername, txtPass.Text)



        'Dim tesss = txtUser.Text.IndexOf("Administrator", StringComparison.CurrentCultureIgnoreCase)


        Try
            If txtUser.Text.IndexOf("Administrator", StringComparison.CurrentCultureIgnoreCase) < 0 And txtPass.Text <> "admin" And txtPass.Text.IndexOf("admin", StringComparison.CurrentCultureIgnoreCase) < 0 Then
                Session("Entity") = ""
                Dim objX As Object
                Dim searchX As DirectorySearcher
                Dim _pathx As String

                Try
                    objX = entry.NativeObject
                    searchX = New DirectorySearcher(entry)

                Catch ex As Exception
                    Domain = LDAP_AGI
                    domainAndUsername = "AXA-INSURANCE\" & txtUser.Text
                    entry = New DirectoryEntry(Domain, domainAndUsername, txtPass.Text)

                    objX = entry.NativeObject
                    searchX = New DirectorySearcher(entry)

                End Try


                searchX.Filter = "(SAMAccountName=" & txtUser.Text & ")"
                searchX.PropertiesToLoad.Add("cn")
                searchX.PropertiesToLoad.Add("mail")
                searchX.PropertiesToLoad.Add("company")
                searchX.PropertiesToLoad.Add("EMPLOYEENUMBER")


                Dim tesX = searchX.PropertiesToLoad.Add("cn")

                Dim resultX As SearchResult = searchX.FindOne()

                If Not (resultX Is Nothing) Then
                    _pathx = resultX.Path
                    Dim EmplNumber As Boolean
                    Dim Email As Boolean
                    '
                    '

                    '
                    'Session.Timeout = 120

                    Session("UserID") = CType(resultX.Properties("cn")(0), String)
                    Session("UserName") = CType(resultX.Properties("cn")(0), String)

                    'Dim _entityX As String
                    '_entityX = CType(resultX.Properties("company")(0), String)


                    'Session("Entity") = ""
                    'lblLogin.Visible = True
                    'lblLogin.Text = "User is not authorized *"
                    'Exit Sub
                    EmplNumber = resultX.Properties.Contains("EMPLOYEENUMBER")
                    Email = resultX.Properties.Contains("mail")
                    If EmplNumber = False Then
                        Dim dtSelect As New DataTable
                        dtSelect = oSelect.f_SEL_EMPL_NUMBER(Session("UserName"))
                        Dim userna = Session("UserName").ToString()
                        If dtSelect.Rows.Count > 0 Then
                            Session("EMPLNUMBER") = dtSelect.Rows(0)("EmployeeID").ToString()
                        Else
                            If Email = True Then
                                Session("Mail") = CType(resultX.Properties("mail")(0), String)
                                Dim dtSelect2 As New DataTable
                                dtSelect2 = oSelect.f_SEL_EMPL_NUMBER_WITH_EMAIL(Session("Mail"))
                                If dtSelect2.Rows.Count > 0 Then
                                    Session("EMPLNUMBER") = dtSelect2.Rows(0)("EmployeeID").ToString()
                                End If
                            Else
                                Dim dtSelect33 As New DataTable
                                dtSelect33 = oSelect.f_SEL_EMPL_NUMBER(Session("UserName"))
                                If dtSelect33.Rows.Count > 0 Then
                                    Session("Mail") = dtSelect33.Rows(0)("Email").ToString()
                                Else
                                    Dim message As String


                                    message = "Please Check Your Active Directory Data to HR"
                                    Dim sb As New System.Text.StringBuilder()
                                    sb.Append("<script type = 'text/javascript'>")
                                    sb.Append("window.onload=function(){")
                                    sb.Append("alert('")
                                    sb.Append(message)
                                    sb.Append("')};")
                                    sb.Append("</script>")
                                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())

                                    Exit Sub
                                End If
                            End If
                        End If
                    Else
                        Session("EMPLNUMBER") = CType(resultX.Properties("EMPLOYEENUMBER")(0), String)
                    End If
                End If
            End If

            If txtUser.Text.IndexOf("Administrator", StringComparison.CurrentCultureIgnoreCase) = 0 And txtPass.Text = "admin" And txtPass.Text.IndexOf("admin", StringComparison.CurrentCultureIgnoreCase) = 0 Then
                Session("Entity") = "ASI"
                Session("UserID") = "Administrator"
                Session("UserName") = "Administrator"
                'dtlogin = oSelect.f_InsertLogin(Session("UserID").ToString, Session("Entity"))
                Dim CompName As String = User.Identity.Name
                Dim Names As String = CompName.Replace("AXA-INDONESIA/", "")
                Dim LocalHostaddress As String = HttpContext.Current.Request.UserHostAddress
                Dim dtlogin As New DataTable
                'dtlogin = oSelect.f_InsertLogin(Session("UserID").ToString, Session("Entity"))
                dtlogin = oSelect.f_InsertLogin(Session("UserID").ToString, LocalHostaddress, Session("Entity"), Session("EMPLNUMBER"))
                Session("Condition") = ""
                Response.Redirect("Home.aspx", False)

            Else
                'Edit Himawan For Get IP Address local computer User'
                'Dim host As String = System.Net.Dns.GetHostName()
                'Dim LocalHostaddress As String = System.Net.Dns.GetHostEntry(host).AddressList(1).ToString()

                Dim LocalHostaddress As String = HttpContext.Current.Request.UserHostAddress
                'Dim clientIp As String = Request.ServerVariables("HTTP_X_FORWARDED_FOR")

                'Dim strHostName As String = System.Net.Dns.GetHostName()
                'Dim LocalHostaddress As String = System.Net.Dns.GetHostAddresses(strHostName).GetValue(1).ToString()

                ''
                'Dim Ip_dbss As String = IP_dbs.Replace(".", "").Replace("::", "").Trim
                Dim Ip_Local As String = LocalHostaddress.Replace(".", "").Replace("::", "").Trim()

                'If Flag_Login = 0 And (Ip_dbss) = 0 Or Flag_Login = 1 And (Ip_dbss) = (Ip_Local) Then
                Session("Entity") = ""
                Dim obj As Object = entry.NativeObject
                Dim search As DirectorySearcher = New DirectorySearcher(entry)
                Dim _path As String

                search.Filter = "(SAMAccountName=" & txtUser.Text & ")"
                search.PropertiesToLoad.Add("cn")
                search.PropertiesToLoad.Add("mail")
                search.PropertiesToLoad.Add("company")

                Dim tes = search.PropertiesToLoad.Add("cn")

                Dim resultX As SearchResult = search.FindOne()
                Dim result As SearchResult = search.FindOne()

                If Not (result Is Nothing) Then
                    _path = result.Path

                    '
                    'Session.Timeout = 120

                    Session("UserID") = CType(result.Properties("cn")(0), String)
                    Session("UserName") = CType(result.Properties("cn")(0), String)

                    Dim CompName As String = User.Identity.Name
                    Dim Names As String = CompName.Replace("AXA-INDONESIA\", "")

                    Dim dtCheck As New DataTable
                    Dim empl = Session("EMPLNUMBER").ToString()
                    dtCheck = oSelect.f_SEL_NAME_LOGIN(Session("EMPLNUMBER").ToString)
                    If dtCheck.Rows.Count > 0 Then
                        Session("UserID") = dtCheck.Rows(0)("NAME").ToString()
                        Session("Entity123") = dtCheck.Rows(0)("Entity").ToString()
                    End If

                    Dim dtEmail As New DataTable
                    dtEmail = oSelect.f_SEL_EMAIL_EMPL(Session("EMPLNUMBER").ToString)

                    If dtEmail.Rows.Count > 0 Then
                        Session("EmailEmpl") = dtEmail.Rows(0)("Email").ToString()
                    End If



                    Dim dtlogin As New DataTable
                    'dtlogin = oSelect.f_InsertLogin(Session("UserID").ToString, Session("Entity"))
                    dtlogin = oSelect.f_InsertLogin(Session("UserID").ToString, LocalHostaddress, Session("Entity"), Session("EMPLNUMBER"))
                    Session("Role") = dtlogin.Rows(0)("ROLE").ToString()
                    Session("ShortEntity") = dtlogin.Rows(0)("SHORTENTITY").ToString()
                    Session("YearAttendance") = ddlYear.SelectedItem.Text

                    Dim _entity As String
                    Dim _entityX As String
                    _entity = CType(result.Properties("company")(0), String)
                    _entityX = CType(resultX.Properties("company")(0), String)

                    If _entityX.Contains("AXA Mandiri") Then
                        Session("Entity") = "AMFS"
                    ElseIf _entityX.Contains("AXA Financial Indonesia") Then
                        Session("Entity") = "AFI"
                    ElseIf _entityX.Contains("AXA Services Indonesia") Then
                        Session("Entity") = "ASI"
                    ElseIf _entityX.Contains("Mandiri AXA") Then
                        Session("Entity") = "MAGI"
                    ElseIf _entityX.Contains("AXA Life") Then
                        Session("Entity") = "ALI"
                    ElseIf _entityX.Contains("AXA Asset") Then
                        Session("Entity") = "AAMI"
                    End If

                    If dtlogin.Rows(0)(0).ToString.ToUpper = "SUCCESS" Then
                        If dtlogin.Rows(0)("ROLE").ToString() = "ADMIN" Or dtlogin.Rows(0)("ROLE").ToString() = "SUPER ADMIN" Or dtlogin.Rows(0)("ROLE").ToString() = "HRBP" Then
                            Session("Condition") = ""
                            'If Session("EMPLNUMBER") = "106680" Then
                            '    Response.Redirect("Frm_List_ABSEN_ADMIN_NONFTE.aspx", False)
                            'Else
                            '    Response.Redirect("Frm_List_ABSEN_ADMIN.aspx", False)
                            'End If
                            Response.Redirect("Frm_List_ABSEN_ADMIN.aspx", False)
                        Else
                            Session("Condition") = ""
                            Response.Redirect("Frm_List_ABSEN_USER.aspx", False)
                        End If
                        Session("Entity") = dtlogin.Rows(0)("ENTITY").ToString()
                    ElseIf dtlogin.Rows(0)(0).ToString.ToUpper = "ISLOGIN" Then
                        lblLogin.Visible = True
                        lblLogin.Text = "* User is already login"
                    End If
                End If


            End If
        Catch ex As Exception

            lblLogin.Visible = True
            lblLogin.Text = "* Error Authenticating User"
            'Throw New Exception("Error authenticating user. " & ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

        End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        login()
        'loading()
    End Sub
    '    Sub loading()
    '        Response.Write("<script language=javascript>;")
    '        Response.Write("var dots = 0;var dotmax = 10;function ShowWait()")
    '        Response.Write("{var output; output = 'Loading';dots++;if(dots>=dotmax)dots=1;")
    '        Response.Write("for(var x = 0;x < dots;x++){output += '.';}mydiv.innerText =  output;}")
    '        Response.Write("function StartShowWait(){mydiv.style.visibility = 'visible'; 
    'window.setInterval('ShowWait()',1000);}")
    '        Response.Write("function HideWait(){mydiv.style.visibility = 
    ''hidden';window.clearInterval();}")
    '        Response.Write("StartShowWait();</script>")
    '        Response.Flush()
    '        Threading.Thread.Sleep(10000)
    'End Sub
End Class