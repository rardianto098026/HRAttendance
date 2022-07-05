﻿
Imports System.Data.OleDb
Imports System.Data
Imports System.IO
Imports System.Configuration
Imports System.Web.UI
Imports System.Web
Imports System.DirectoryServices
Imports System.Data.SqlClient
Partial Public Class Menu
    Inherits System.Web.UI.UserControl
    Dim oInsert As New InsertBase
    Dim oUpdate As New UpdateBase
    Dim oSelect As New SelectBase

    'Dim dbname As String = "AFI_SURROUNDING_DB"
    'Dim myConn2 As SqlConnection = New SqlConnection("Data Source=ASI-IT71;Initial Catalog=AFI_SURROUNDING_DB;User Id=sa;Password=P@ssw0rd; Integrated Security=False;")
    'Dim myConn3 As SqlConnection = New SqlConnection("Data Source=ASI-IT71;Initial Catalog=AMFS_SURROUNDING_DB;User Id=sa;Password=P@ssw0rd; Integrated Security=False;")
    Dim _connectionString As String = ConfigurationManager.ConnectionStrings("ConSql").ToString
    Dim sqlConn As SqlConnection
    Sub menu()
        'Collection
        Dim myMenu As New MenuItem
        myMenu.Selectable = False
        myMenu.Text = "Collection"
        myMenu.Enabled = False
        'myMenu.NavigateUrl = "~/AddUser.aspx"

        'Report
        Dim menuReport As New MenuItem
        menuReport.Selectable = False
        menuReport.Text = "Report"
        menuReport.Enabled = False


        'Usr Matrix
        Dim menuUserMatrix As New MenuItem
        menuUserMatrix.Selectable = False
        menuUserMatrix.Text = "User Matrix"
        menuUserMatrix.Enabled = False

        'Upload
        Dim menuUpload As New MenuItem
        menuUpload.Selectable = False
        menuUpload.Text = "Upload Sequence Number"
        menuUpload.Enabled = False

        Dim menuHome As New MenuItem
        Dim menuHome2 As New MenuItem

        Menu1.Items.Add(menuHome)
        menuHome.Text = "Home"
        menuHome.Selectable = False
        menuHome.Enabled = True
        menuHome.Enabled = True
        menuHome.ChildItems.Add(New MenuItem("Home", "Home", "", "~/Frm_List_ABSEN_USER.aspx"))

        Dim dtlogin As New DataTable
        'dtlogin = oSelect.f_InsertLogin(Session("UserID").ToString, Session("Entity"))
        dtlogin = oSelect.f_SEL_GET_MAPPING_MANAGER(Session("EMPLNUMBER").ToString())

        Dim COUNTING As Integer

        If dtlogin.Rows.Count > 0 Then
            COUNTING = dtlogin.Rows(0)("COUNTING").ToString()
            If COUNTING > 0 Then
                oInsert.f_MENU_LIST_ATTENDANCE_MANAGER("", Session("EMPLNUMBER").ToString, Session("UserName").ToString, "Lisr", Session("Entity123").ToString,
                                                            Session("Role").ToString, Session("UserName").ToString, "", "", "", "1")
            End If
        End If



        'Dim dtCWH As New DataTable
        ''dtlogin = oSelect.f_InsertLogin(Session("UserID").ToString, Session("Entity"))
        'dtCWH = oSelect.f_SEL_LIST_MENU_CWH(Session("EMPLNUMBER").ToString())

        'Dim COUNTING_CWH As Integer

        'If dtCWH.Rows.Count > 0 Then
        '    COUNTING_CWH = dtlogin.Rows(0)("COUNTING").ToString()
        '    If COUNTING_CWH = 0 Then
        '        oInsert.f_MENU_LIST_DOC_CWH("", Session("EMPLNUMBER").ToString, Session("UserName").ToString, "Lisr", Session("Entity123").ToString,
        '                                                    Session("Role").ToString, Session("UserName").ToString, "", "", "", "1")
        '    End If
        'End If

        Dim EmployeeID As String = Session("EMPLNUMBER").ToString
        Dim UserName As String = Session("UserID").ToString
        Dim Path As String
        Dim Label_Menu, Label_Child, Label_name, menu_Name, MenuNameMaster As String

        If UserName = "Administrator" Then
            Dim dbcomm As SqlCommand
            Dim dtread As SqlDataReader
            ' Dim supervisorkey As Integer
            Dim command As String = "select * from MST_MENU_CHILD Where IDMenu = 'Usr'"

            sqlConn = New SqlClient.SqlConnection(_connectionString)
            dbcomm = New SqlCommand(command, sqlConn)

            sqlConn.Open()
            dtread = dbcomm.ExecuteReader()
            Try
                While dtread.Read()
                    If Not dtread.IsDBNull(dtread.GetOrdinal("IDMenuChild")) Then
                        Label_Menu = CStr(dtread("IDMenu").ToString)
                        Label_Child = CStr(dtread("IDMenuChild").ToString)
                        Path = CStr(dtread("Path").ToString)
                        menu_Name = CStr(dtread("MenuNameChild").ToString)
                        If Label_Menu = "Usr" Then
                            'Report
                            Menu1.Items.Add(menuUserMatrix)
                            menuUserMatrix.Enabled = True
                            menuUserMatrix.ChildItems.Add(New MenuItem(menu_Name, Label_Child, "", "~/" & Path & ""))
                        End If

                    End If
                End While
                Menu1.Items.Remove(menuReport)
                Menu1.Items.Remove(myMenu)
            Catch ex As Exception
            End Try
        Else

            Dim dbcomm, dbcomm2 As SqlCommand
            Dim dtread, dtread2 As SqlDataReader

            ' Dim supervisorkey As Integer
            'Dim command As String = "Select UserName,Entity,a.IDMenuChild,c.IDMenu,b.Path,b.MenuNameChild,MenuName " & _
            '                       "from [MST_USER_MATRIX] a " & _
            '                       "inner join MST_MENU_CHILD b on a.IDMenuChild = b.IDMenuChild " & _
            '                       "inner join MST_MENU c on b.IDMenu = c.IDMenu " & _
            '                       "where UserName = '" & UserName & "' and Flag = 1"
            Dim command As String, command2 As String
            If EmployeeID <> "" Then
                command = "select distinct b.IDMenu, UserName " &
                                    "from [MST_USER_MATRIX] a " &
                                    "inner join MST_MENU_CHILD b on a.IDMenuChild = b.IDMenuChild " &
                                    "where EmployeeID = '" & EmployeeID & "' and Flag = 1"
                'And ([Role] = 'ADMIN' OR [Role] = 'SUPER ADMIN' or [Role] = 'USER' or [Role] = 'HRBP') "

                command2 = " select count(distinct b.IDMenu) as Jumlah " &
                                    "from [MST_USER_MATRIX] a " &
                                    "inner join MST_MENU_CHILD b on a.IDMenuChild = b.IDMenuChild " &
                                    "where EmployeeID = '" & EmployeeID & "' and Flag = 1"
                'And ([Role] = 'ADMIN' OR [Role] = 'SUPER ADMIN' or Role = 'USER' or [Role] = 'HRBP')"

            Else
                command = "select distinct b.IDMenu, UserName " &
                                    "from [MST_USER_MATRIX] a " &
                                    "inner join MST_MENU_CHILD b on a.IDMenuChild = b.IDMenuChild " &
                                    "where UserName = '" & UserName & "' and Flag = 1"
                'And ([Role] = 'ADMIN' OR [Role] = 'SUPER ADMIN' or [Role] = 'USER' or [Role] = 'HRBP') "

                command2 = " select count(distinct b.IDMenu) as Jumlah " &
                                    "from [MST_USER_MATRIX] a " &
                                    "inner join MST_MENU_CHILD b on a.IDMenuChild = b.IDMenuChild " &
                                    "where UserName = '" & UserName & "' and Flag = 1"
                'And ([Role] = 'ADMIN' OR [Role] = 'SUPER ADMIN' or Role = 'USER' or [Role] = 'HRBP')"


            End If

            sqlConn = New SqlClient.SqlConnection(_connectionString)
            dbcomm2 = New SqlCommand(command2, sqlConn)

            sqlConn.Open()
            dtread2 = dbcomm2.ExecuteReader()
            dtread2.Read()
            Dim Jumlah As String = CStr(dtread2("Jumlah").ToString)
            dtread2.Close()
            sqlConn.Close()


            sqlConn = New SqlClient.SqlConnection(_connectionString)
            dbcomm = New SqlCommand(command, sqlConn)

            sqlConn.Open()

            Try
                dtread = dbcomm.ExecuteReader()
                'dtread.Read()
                For x As Integer = 1 To Jumlah
                    dtread.Read()
                    If Not dtread.IsDBNull(dtread.GetOrdinal("UserName")) Then
                        Label_name = CStr(dtread("UserName").ToString)
                        Label_Menu = CStr(dtread("IDMenu").ToString)
                        'Label_Child = CStr(dtread("IDMenuChild").ToString)
                        'Path = CStr(dtread("Path").ToString)
                        'menu_Name = CStr(dtread("MenuNameChild").ToString)
                        'MenuNameMaster = CStr(dtread("MenuName").ToString)

                        Dim dt As DataTable
                        dt = oSelect.f_CheckMMenus(Label_name, Label_Menu, Session("Entity"))
                        Dim jumlahMenu = dt.Rows(0)("Jumlah").ToString()

                        If EmployeeID <> "" Then
                            If jumlahMenu = 1 Then
                                Dim mymenus As New MenuItem
                                Dim dtd As DataTable
                                dtd = oSelect.f_CheckMMenu(EmployeeID, Label_Menu, Session("Entity"))
                                MenuNameMaster = dtd.Rows(0)("MenuName").ToString()
                                menu_Name = dtd.Rows(0)("MenuNameChild").ToString()
                                Label_Child = dtd.Rows(0)("IDMenuChild").ToString()
                                Path = dtd.Rows(0)("Path").ToString()

                                mymenus.Text = MenuNameMaster
                                'mymenus.ToolTip = "Menu" + x
                                Menu1.Items.Add(mymenus)
                                mymenus.Selectable = False
                                mymenus.Enabled = True
                                mymenus.ChildItems.Add(New MenuItem(menu_Name, Label_Child, "", "~/" & Path & ""))
                            ElseIf jumlahMenu > 1 Then
                                Dim mymenuM As New MenuItem
                                Dim dtd As DataTable
                                dtd = oSelect.f_CheckMMenu(EmployeeID, Label_Menu, Session("Entity"))
                                MenuNameMaster = dtd.Rows(0)("MenuName").ToString()

                                Menu1.Items.Add(mymenuM)
                                mymenuM.Text = MenuNameMaster
                                mymenuM.Selectable = False
                                mymenuM.Enabled = True

                                Dim dts As DataTable
                                dts = oSelect.f_CheckMMenu(Label_name, Label_Menu, Session("Entity"))
                                For i As Integer = 0 To dts.Rows.Count - 1
                                    Dim MenuNameChild = dts.Rows(i)("MenuNameChild").ToString()
                                    Dim IDMenuChild = dts.Rows(i)("IDMenuChild").ToString()
                                    Dim Paths = dts.Rows(i)("Path").ToString()
                                    mymenuM.ChildItems.Add(New MenuItem(MenuNameChild, IDMenuChild, "", "~/" & Paths & ""))

                                Next

                            End If
                        Else
                            If jumlahMenu = 1 Then
                                Dim mymenus As New MenuItem
                                Dim dtd As DataTable
                                dtd = oSelect.f_CheckMMenu(UserName, Label_Menu, Session("Entity"))
                                MenuNameMaster = dtd.Rows(0)("MenuName").ToString()
                                menu_Name = dtd.Rows(0)("MenuNameChild").ToString()
                                Label_Child = dtd.Rows(0)("IDMenuChild").ToString()
                                Path = dtd.Rows(0)("Path").ToString()

                                mymenus.Text = MenuNameMaster
                                'mymenus.ToolTip = "Menu" + x
                                Menu1.Items.Add(mymenus)
                                mymenus.Selectable = False
                                mymenus.Enabled = True
                                mymenus.ChildItems.Add(New MenuItem(menu_Name, Label_Child, "", "~/" & Path & ""))
                            ElseIf jumlahMenu > 1 Then
                                Dim mymenuM As New MenuItem
                                Dim dtd As DataTable
                                dtd = oSelect.f_CheckMMenu(UserName, Label_Menu, Session("Entity"))
                                MenuNameMaster = dtd.Rows(0)("MenuName").ToString()

                                Menu1.Items.Add(mymenuM)
                                mymenuM.Text = MenuNameMaster
                                mymenuM.Selectable = False
                                mymenuM.Enabled = True

                                Dim dts As DataTable
                                dts = oSelect.f_CheckMMenu(Label_name, Label_Menu, Session("Entity"))
                                For i As Integer = 0 To dts.Rows.Count - 1
                                    Dim MenuNameChild = dts.Rows(i)("MenuNameChild").ToString()
                                    Dim IDMenuChild = dts.Rows(i)("IDMenuChild").ToString()
                                    Dim Paths = dts.Rows(i)("Path").ToString()
                                    mymenuM.ChildItems.Add(New MenuItem(MenuNameChild, IDMenuChild, "", "~/" & Paths & ""))

                                Next

                            End If


                        End If
                    Else
                        Label_name = ""
                        Label_Menu = ""
                    End If


                Next

                sqlConn.Close()

            Catch ex As Exception

            End Try
            'Menu1.Items.Add(menuHome2)
            'menuHome2.Text = "Welcome " + Session("UserID").ToString
            'menuHome2.Selectable = False
            'menuHome2.Enabled = True
            'menuHome2.Enabled = True
            'Dim newStyle As New MenuItemStyle()
            'newStyle.CssClass = "mybtnstyle"
            'Dim tes = Menu1.Items.Count
            'Dim tesa = Menu1.LevelMenuItemStyles(),=
            'Dim testing = "tes"
            'Menu1.LevelMenuItemStyles.Item(1).CssClass = "mybtnstyle"
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            menu()
        End If
    End Sub

End Class
