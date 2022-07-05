Imports System.Data.SqlClient

Public Class SelectBase

    Dim Conn As String = ConfigurationManager.ConnectionStrings("ConSql").ToString
    Dim DataAccess As New DataAccessBase

#Region "Constanta"
    Dim const_sp_MST_EMPLOYEE As String = "sp_MST_EMPLOYEE"
    Dim const_sp_INSERT_LOGIN As String = "sp_INSERT_LOGIN"
    Dim const_sp_CHECK_MENU As String = "sp_check_Menu_MASTER"
    Dim const_sp_CHECK_MENU_NAME_MASTER As String = "sp_check_Menu_name"
    Dim const_sp_InsertUploadFile As String = "sp_INSERT_UPLOADFILE"
    Dim const_sp_SEL_NAME_LOGIN As String = "sp_SEL_NAME_LOGIN"
    Dim const_sp_SEL_EMPLOYEEID As String = "sp_SEL_EMPLOYEE"
    Dim const_sp_SEL_EMPLOYEEID_USER As String = "sp_SEL_EMPLOYEE_USER"
    Dim const_sp_SEL_EMPLOYEE_SUPER_ADMIN As String = "sp_SEL_EMPLOYEE_SUPER_ADMIN"
    Dim const_sp_SEL_LIST_ATTENDANCE_ADMIN As String = "sp_SEL_LIST_ATTENDANCE_ADMIN"
    Dim const_sp_SEL_LIST_ATTENDANCE_ADMIN_NONFTE As String = "sp_SEL_LIST_ATTENDANCE_ADMIN_NONFTE"
    Dim const_sp_SEL_LIST_DETAIL_ATTENDANCE_ADMIN As String = "[sp_SEL_LIST_DETAIL_ATTENDANCE_ADMIN]"
    Dim const_sp_SEL_LIST_DETAIL_ATTENDANCE_ADMIN_LOAD = "sp_SEL_LIST_DETAIL_ATTENDANCE_ADMIN_LOAD"
    Dim const_sp_SEL_LIST_DETAIL_ATTENDANCE_ADMIN_EXPORT_REPORT As String = "sp_SEL_LIST_DETAIL_ATTENDANCE_ADMIN_EXPORT_REPORT"

    Dim const_sp_SEL_LIST_ATTENDANCE_USER As String = "sp_SEL_LIST_ATTENDANCE_USER"
    Dim const_sp_SEL_LIST_ATTENDANCE_USER_EXPORT_REPORT As String = "sp_SEL_LIST_ATTENDANCE_USER_EXPORT_REPORT"
    Dim const_sp_SEL_LIST_ATTENDANCE_USER_LOAD = "sp_SEL_LIST_ATTENDANCE_USER_LOAD"
    Dim const_sp_SEL_DETAIL_ATTENDANCE_ADMIN As String = "sp_SEL_DETAIL_ATTENDANCE_ADMIN"
    Dim const_sp_SEL_GET_DETAIL_DAYS_ATTENDANCE As String = "sp_SEL_GET_DETAIL_DAYS_ATTENDANCE"
    Dim const_sp_CHECK_DAYS_ATTENDANCE As String = "sp_CHECK_DAYS_ATTENDANCE_NEW"
    Dim const_sp_SEL_EMPL_NUMBER As String = "sp_SEL_EMPL_NUMBER"
    Dim const_sp_SEL_EMPL_NUMBER_WITH_EMAIL As String = "sp_SEL_EMPL_NUMBER_WITH_EMAIL"
    Dim const_sp_SEND_EMAIL_NOTIF_CWH_TO_HR As String = "sp_SEND_EMAIL_NOTIF_CWH_TO_HR"
    Dim const_sp_SEL_EMAIL_EMPL As String = "sp_SEL_EMAIL_EMPL"
    Dim const_sp_SEL_DETAIL_CWH As String = "sp_SEL_DETAIL_DOC_CWH"
    Dim const_sp_SEL_LIST_DOCUMENT_CWH As String = "sp_SEL_LIST_DOCUMENT_CWH"
    Dim const_sp_SEL_LIST_DOCUMENT_CWH_EXPORT As String = "sp_SEL_LIST_DOCUMENT_CWH_EXPORT"
    Dim const_sp_SEL_LIST_DOCUMENT_CWH_LOAD As String = "sp_SEL_LIST_DOCUMENT_CWH_LOAD"
    Dim const_sp_SEL_LIST_DOCUMENT_CWH_LOAD_NONFTE As String = "sp_SEL_LIST_DOCUMENT_CWH_LOAD_NONFTE"
    Dim const_sp_SEL_LIST_DOCUMENT_CWH_LOAD_SUPER_ADMIN As String = "sp_SEL_LIST_DOCUMENT_CWH_LOAD_SUPER_ADMIN"
    Dim const_sp_SEL_CHECK_UPLOAD_CWH As String = "sp_CHECK_UPLOAD_CWH"
    Dim const_sp_SEL_LIST_DOCUMENT_CWH_FOR_EMPLOYEE_LOAD As String = "sp_SEL_LIST_DOCUMENT_CWH_FOR_EMPLOYEE_LOAD"
    Dim const_sp_SEL_LIST_DOCUMENT_CWH_FOR_EMPLOYEE As String = "sp_SEL_LIST_DOCUMENT_CWH_FOR_EMPLOYEE"
    Dim const_sp_SEL_EMPLOYEEID_ENTITY As String = "sp_SEL_EMPLOYEE_ENTITY"
    Dim const_sp_GET_MST_QUARTER As String = "sp_GET_MST_QUARTER"
    Dim const_sp_GET_STATUS_APPROVED As String = "sp_GET_STATUS_APPROVED"
    Dim const_sp_GET_STATUS_ACCESS_CWH As String = "sp_GET_STATUS_ACCESS_CWH"
    Dim const_sp_GET_MONTH_QUARTER As String = "sp_GET_MONTH_QUARTER"
    Dim const_sp_MAPPING_EMPLOYEE_MANAGER As String = "sp_MAPPING_EMPLOYEE_MANAGER"
    Dim const_sp_SEL_LIST_ATTENDANCE_FOR_MANAGER As String = "sp_SEL_LIST_ATTENDANCE_FOR_MANAGER"
    Dim const_sp_SEL_LIST_ATTENDANCE_FOR_MANAGER_LOAD As String = "sp_SEL_LIST_ATTENDANCE_FOR_MANAGER_LOAD"
    Dim const_sp_CHECK_QUARTER As String = "sp_CHECK_QUARTER"
    Dim const_sp_SEL_LINE__MANAGER As String = "sp_SEL_LINE__MANAGER"
    Dim const_sp_SEL_MST_EMPLOYEE As String = "sp_SEL_MST_EMPLOYEE"
    'Dim const_sp_SEL_LINE_MANAGER As String = "sp_SEL_LINE_MANAGER"
    Dim const_sp_SEL_LINE_MANAGER_1 As String = "sp_SEL_LIST_MANAGER"
    Dim const_sp_SEL_LINE_EMPLOYEE As String = "sp_SEL_LIST_EMPLOYEE"
    Dim const_sp_SEL_LIST_LINE_FOR_MANAGER_LOAD As String = "sp_SEL_LIST_LINE_FOR_MANAGER_LOAD"
    Dim const_sp_SEL_MST_EMPLOYEE_LOAD As String = "sp_SEL_MST_EMPLOYEE_LOAD"
    Dim const_sp_SEL_LIST_MANAGER_LOAD As String = "sp_SEL_LIST_MANAGER_LOAD"
    Dim const_sp_SEL_LIST_EMPLOYEE_LOAD As String = "sp_SEL_LIST_EMPLOYEE_LOAD"
    Dim const_sp_MAPPING_EMPLOYEE_MANAGER_LOAD As String = "sp_MAPPING_EMPLOYEE_MANAGER_LOAD"
    Dim const_sp_SEL_DETAIL_LINE_MANAGER As String = "sp_SEL_DETAIL_LINE_MANAGER"
    Dim const_sp_SEL_DETAIL_MASTER_EMPLOYEE As String = "sp_SEL_DETAIL_MASTER_EMPLOYEE"

    Dim const_sp_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER_LOAD As String = "sp_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER_LOAD"
    Dim const_sp_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER_LOAD_SUPER_ADMIN As String = "sp_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER_LOAD_SUPER_ADMIN"
    Dim const_sp_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER As String = "sp_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER"
    Dim const_sp_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER_EXPORT As String = "sp_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER_EXPORT"
    Dim const_sp_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER_SUPER_ADMIN As String = "sp_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER_SUPER_ADMIN"
    Dim const_sp_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER_SUPER_ADMIN_EXPORT As String = "sp_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER_SUPER_ADMIN_EXPORT"
    Dim const_sp_MAPPING_CWHEMPLOYEE_MANAGER As String = "sp_MAPPING_CWHEMPLOYEE_MANAGER"
    Dim const_sp_MAPPING_CWHEMPLOYEE_MANAGER_SUPER_ADMIN As String = "sp_MAPPING_CWHEMPLOYEE_MANAGER_SUPER_ADMIN"


    Dim const_sp_SEL_LIST_DETAIL_ATTENDANCE_FOR_MANAGER As String = "sp_SEL_LIST_DETAIL_ATTENDANCE_FOR_MANAGER"
    Dim const_sp_SEL_LIST_DETAIL_ATTENDANCE_FOR_MANAGER_LOAD = "sp_SEL_LIST_DETAIL_ATTENDANCE_FOR_MANAGER_LOAD"
    Dim const_sp_SEL_LIST_DETAIL_ATTENDANCE_FOR_MANAGER_EXPORT_REPORT As String = "sp_SEL_LIST_DETAIL_ATTENDANCE_FOR_MANAGER_EXPORT_REPORT"

    Dim const_sp_SEL_LINE_MANAGER_FOR_EXPORT As String = "sp_SEL_LINE_MANAGER_FOR_EXPORT"
    Dim const_sp_SEL_ACCESSCARD_FOR_EXPORT As String = "sp_SEL_ACCESSCARD_FOR_EXPORT"
    Dim const_sp_SEL_GET_MAPPING_MANAGER As String = "sp_SEL_GET_MAPPING_MANAGER"
    Dim const_sp_SEL_LIST_MST_EXPIRED As String = "sp_SEL_LIST_MST_EXPIRED"
    Dim const_sp_SEL_QUARTER_LOAD As String = "sp_SEL_QUARTER_LOAD"
    Dim const_sp_SEL_MST_EXPIRED As String = "sp_SEL_MST_EXPIRED"
    Dim const_sp_SEL_MENU_CWH As String = "sp_SEL_MENU_CWH"


#End Region

    Public Function f_MST_EMPLOYEE() As DataTable

        Dim dt As New DataTable

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_QUARTER_LOAD, CommandType.StoredProcedure)

        Return dt

    End Function
    Public Function f_SEL_MST_EXPIRED(ByVal QUARTER As String, ByVal USERID As String, ByVal YEARS As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@QUARTER", SqlDbType.VarChar)
        oParam(0).Value = CType(QUARTER, String)

        oParam(1) = New SqlClient.SqlParameter("@USERID", SqlDbType.VarChar)
        oParam(1).Value = CType(USERID, String)

        oParam(2) = New SqlClient.SqlParameter("@YEARS", SqlDbType.VarChar)
        oParam(2).Value = CType(YEARS, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_MST_EXPIRED, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_QUARTER_LOAD() As DataTable

        Dim dt As New DataTable

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_QUARTER_LOAD, CommandType.StoredProcedure)

        Return dt

    End Function
    Public Function f_SEL_LIST_MST_EXPIRED() As DataTable

        Dim dt As New DataTable

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_MST_EXPIRED, CommandType.StoredProcedure)

        Return dt

    End Function
    Public Function f_SEL_ACCESSCARD_FOR_EXPORT(ByVal _Access As String, ByVal _flagAccess As String,
                                        ByVal _flagEmplName As String, ByVal _NameEmplo As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(3) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ACCESS", SqlDbType.VarChar)
        oParam(0).Value = CType(_Access, String)

        oParam(1) = New SqlClient.SqlParameter("@FLAGAccess", SqlDbType.VarChar)
        oParam(1).Value = CType(_flagAccess, String)

        oParam(2) = New SqlClient.SqlParameter("@FLAGEmplName", SqlDbType.VarChar)
        oParam(2).Value = CType(_flagEmplName, String)

        oParam(3) = New SqlClient.SqlParameter("@EMPLNAME", SqlDbType.VarChar)
        oParam(3).Value = CType(_NameEmplo, String)


        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_ACCESSCARD_FOR_EXPORT, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_LINE_MANAGER_FOR_EXPORT(ByVal MngrID As String, ByVal FLAGMngrID As String,
                                        ByVal FLAGEmplID As String, ByVal EmplID As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(3) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@MNGRID", SqlDbType.VarChar)
        oParam(0).Value = CType(MngrID, String)

        oParam(1) = New SqlClient.SqlParameter("@FLAGMngrID", SqlDbType.VarChar)
        oParam(1).Value = CType(FLAGMngrID, String)

        oParam(2) = New SqlClient.SqlParameter("@FLAGEmplID", SqlDbType.VarChar)
        oParam(2).Value = CType(FLAGEmplID, String)

        oParam(3) = New SqlClient.SqlParameter("@EmplID", SqlDbType.VarChar)
        oParam(3).Value = CType(EmplID, String)


        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LINE_MANAGER_FOR_EXPORT, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_MAPPING_CWHEMPLOYEE_MANAGER(ByVal Entity As String) As DataTable
        Dim dt As New DataTable

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@Entity", SqlDbType.VarChar)
        oParam(0).Value = CType(Entity, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_MAPPING_CWHEMPLOYEE_MANAGER, CommandType.StoredProcedure, oParam)

        Return dt
    End Function

    Public Function f_MAPPING_CWHEMPLOYEE_MANAGER_SUPER_ADMIN() As DataTable
        Dim dt As New DataTable

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_MAPPING_CWHEMPLOYEE_MANAGER_SUPER_ADMIN, CommandType.StoredProcedure)

        Return dt

    End Function
    Public Function f_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER(ByVal ShortEntity As String, ByVal EMPLOYEEID As String, ByVal YEAR As String, ByVal QUARTER As String,
                                       ByVal FLAGEMPLID As String, ByVal FLAGYEAR As String, ByVal FLAGQUARTER As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(6) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ShortEntity", SqlDbType.VarChar)
        oParam(0).Value = CType(ShortEntity, String)

        oParam(1) = New SqlClient.SqlParameter("@EMPLOYEEID", SqlDbType.VarChar)
        oParam(1).Value = CType(EMPLOYEEID, String)

        oParam(2) = New SqlClient.SqlParameter("@YEAR", SqlDbType.VarChar)
        oParam(2).Value = CType(YEAR, String)

        oParam(3) = New SqlClient.SqlParameter("@QUARTER", SqlDbType.VarChar)
        oParam(3).Value = CType(QUARTER, String)

        oParam(4) = New SqlClient.SqlParameter("@FLAGEMPLID", SqlDbType.VarChar)
        oParam(4).Value = CType(FLAGEMPLID, String)

        oParam(5) = New SqlClient.SqlParameter("@FLAGYEAR", SqlDbType.VarChar)
        oParam(5).Value = CType(FLAGYEAR, String)

        oParam(6) = New SqlClient.SqlParameter("@FLAGQUARTER", SqlDbType.VarChar)
        oParam(6).Value = CType(FLAGQUARTER, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER_EXPORT(ByVal ShortEntity As String, ByVal EMPLOYEEID As String, ByVal YEAR As String, ByVal QUARTER As String,
                                       ByVal FLAGEMPLID As String, ByVal FLAGYEAR As String, ByVal FLAGQUARTER As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(6) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ShortEntity", SqlDbType.VarChar)
        oParam(0).Value = CType(ShortEntity, String)

        oParam(1) = New SqlClient.SqlParameter("@EMPLOYEEID", SqlDbType.VarChar)
        oParam(1).Value = CType(EMPLOYEEID, String)

        oParam(2) = New SqlClient.SqlParameter("@YEAR", SqlDbType.VarChar)
        oParam(2).Value = CType(YEAR, String)

        oParam(3) = New SqlClient.SqlParameter("@QUARTER", SqlDbType.VarChar)
        oParam(3).Value = CType(QUARTER, String)

        oParam(4) = New SqlClient.SqlParameter("@FLAGEMPLID", SqlDbType.VarChar)
        oParam(4).Value = CType(FLAGEMPLID, String)

        oParam(5) = New SqlClient.SqlParameter("@FLAGYEAR", SqlDbType.VarChar)
        oParam(5).Value = CType(FLAGYEAR, String)

        oParam(6) = New SqlClient.SqlParameter("@FLAGQUARTER", SqlDbType.VarChar)
        oParam(6).Value = CType(FLAGQUARTER, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER_EXPORT, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER_SUPER_ADMIN(ByVal ShortEntity As String, ByVal EMPLOYEEID As String, ByVal YEAR As String, ByVal QUARTER As String,
                                       ByVal FLAGEMPLID As String, ByVal FLAGYEAR As String, ByVal FLAGQUARTER As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(6) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ShortEntity", SqlDbType.VarChar)
        oParam(0).Value = CType(ShortEntity, String)

        oParam(1) = New SqlClient.SqlParameter("@EMPLOYEEID", SqlDbType.VarChar)
        oParam(1).Value = CType(EMPLOYEEID, String)

        oParam(2) = New SqlClient.SqlParameter("@YEAR", SqlDbType.VarChar)
        oParam(2).Value = CType(YEAR, String)

        oParam(3) = New SqlClient.SqlParameter("@QUARTER", SqlDbType.VarChar)
        oParam(3).Value = CType(QUARTER, String)

        oParam(4) = New SqlClient.SqlParameter("@FLAGEMPLID", SqlDbType.VarChar)
        oParam(4).Value = CType(FLAGEMPLID, String)

        oParam(5) = New SqlClient.SqlParameter("@FLAGYEAR", SqlDbType.VarChar)
        oParam(5).Value = CType(FLAGYEAR, String)

        oParam(6) = New SqlClient.SqlParameter("@FLAGQUARTER", SqlDbType.VarChar)
        oParam(6).Value = CType(FLAGQUARTER, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER_SUPER_ADMIN, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER_SUPER_ADMIN_EXPORT(ByVal ShortEntity As String, ByVal EMPLOYEEID As String, ByVal YEAR As String, ByVal QUARTER As String,
                                       ByVal FLAGEMPLID As String, ByVal FLAGYEAR As String, ByVal FLAGQUARTER As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(6) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ShortEntity", SqlDbType.VarChar)
        oParam(0).Value = CType(ShortEntity, String)

        oParam(1) = New SqlClient.SqlParameter("@EMPLOYEEID", SqlDbType.VarChar)
        oParam(1).Value = CType(EMPLOYEEID, String)

        oParam(2) = New SqlClient.SqlParameter("@YEAR", SqlDbType.VarChar)
        oParam(2).Value = CType(YEAR, String)

        oParam(3) = New SqlClient.SqlParameter("@QUARTER", SqlDbType.VarChar)
        oParam(3).Value = CType(QUARTER, String)

        oParam(4) = New SqlClient.SqlParameter("@FLAGEMPLID", SqlDbType.VarChar)
        oParam(4).Value = CType(FLAGEMPLID, String)

        oParam(5) = New SqlClient.SqlParameter("@FLAGYEAR", SqlDbType.VarChar)
        oParam(5).Value = CType(FLAGYEAR, String)

        oParam(6) = New SqlClient.SqlParameter("@FLAGQUARTER", SqlDbType.VarChar)
        oParam(6).Value = CType(FLAGQUARTER, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER_SUPER_ADMIN_EXPORT, CommandType.StoredProcedure, oParam)

        Return dt

    End Function


    Public Function f_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER_LOAD(ByVal ShortEntity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ShortEntity", SqlDbType.VarChar)
        oParam(0).Value = CType(ShortEntity, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER_LOAD, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER_LOAD_SUPER_ADMIN(ByVal ShortEntity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ShortEntity", SqlDbType.VarChar)
        oParam(0).Value = CType(ShortEntity, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_DOCUMENT_CWH_FOR_MANAGER_LOAD_SUPER_ADMIN, CommandType.StoredProcedure, oParam)

        Return dt

    End Function


    Public Function f_SEL_DETAIL_MASTER_EMPLOYEE(ByVal EmployeeID As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMPLID", SqlDbType.VarChar)
        oParam(0).Value = CType(EmployeeID, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_DETAIL_MASTER_EMPLOYEE, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_MST_EMPLOYEE_LOAD() As DataTable

        Dim dt As New DataTable


        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_MST_EMPLOYEE_LOAD, CommandType.StoredProcedure)

        Return dt
    End Function

    Public Function f_SEL_MST_EMPLOYEE(ByVal _Access As String, ByVal _flagAccess As String,
                                        ByVal _flagEmplName As String, ByVal _NameEmplo As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(3) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ACCESS", SqlDbType.VarChar)
        oParam(0).Value = CType(_Access, String)

        oParam(1) = New SqlClient.SqlParameter("@FLAGAccess", SqlDbType.VarChar)
        oParam(1).Value = CType(_flagAccess, String)

        oParam(2) = New SqlClient.SqlParameter("@FLAGEmplName", SqlDbType.VarChar)
        oParam(2).Value = CType(_flagEmplName, String)

        oParam(3) = New SqlClient.SqlParameter("@EMPLNAME", SqlDbType.VarChar)
        oParam(3).Value = CType(_NameEmplo, String)


        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_MST_EMPLOYEE, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_LIST_EMPLOYEE_LOAD(ByVal EMPLID As String) As DataTable

        Dim dt As New DataTable

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EmployeeID", SqlDbType.VarChar)
        oParam(0).Value = CType(EMPLID, String)


        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_EMPLOYEE_LOAD, CommandType.StoredProcedure, oParam)

        Return dt
    End Function

    Public Function f_SEL_LIST_EMPLOYEE(ByVal MNGRID As String) As DataTable

        Dim dt As New DataTable

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EmployeeID_Manager", SqlDbType.VarChar)
        oParam(0).Value = CType(MNGRID, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LINE_EMPLOYEE, CommandType.StoredProcedure, oParam)

        Return dt
    End Function

    'Public Function f_SEL_LINE_MANAGER(ByVal MngrID As String) As DataTable

    '    Dim dt As New DataTable
    '    Dim oParam(0) As SqlParameter

    '    oParam(0) = New SqlClient.SqlParameter("@EmployeeID_Manager", SqlDbType.VarChar)
    '    oParam(0).Value = CType(MngrID, String)


    '    Dim _connectionString As String = Conn
    '    dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LINE_MANAGER, CommandType.StoredProcedure, oParam)

    '    Return dt

    'End Function

    Public Function f_SEL_DETAIL_LINE_MANAGER(ByVal EMPLID As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMPLID", SqlDbType.VarChar)
        oParam(0).Value = CType(EMPLID, String)


        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_DETAIL_LINE_MANAGER, CommandType.StoredProcedure, oParam)

        Return dt
    End Function


    Public Function f_SEL_GET_MAPPING_MANAGER(ByVal EMPLID As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMPLID", SqlDbType.VarChar)
        oParam(0).Value = CType(EMPLID, String)


        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_GET_MAPPING_MANAGER, CommandType.StoredProcedure, oParam)

        Return dt
    End Function



    Public Function f_SEL_LIST_MANAGER_1() As DataTable

        Dim dt As New DataTable


        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LINE_MANAGER_1, CommandType.StoredProcedure)

        Return dt
    End Function

    Public Function f_SEL_LIST_MANAGER_LOAD(ByVal MNGRID As String) As DataTable

        Dim dt As New DataTable

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EmployeeID_Manager", SqlDbType.VarChar)
        oParam(0).Value = CType(MNGRID, String)


        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_MANAGER_LOAD, CommandType.StoredProcedure, oParam)

        Return dt
    End Function

    Public Function f_SEL_LIST_LINE_FOR_MANAGER_LOAD() As DataTable

        Dim dt As New DataTable


        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_LINE_FOR_MANAGER_LOAD, CommandType.StoredProcedure)

        Return dt
    End Function

    Public Function f_SEL_LINE_MANAGER(ByVal MngrID As String, ByVal FLAGMngrID As String,
                                        ByVal FLAGEmplID As String, ByVal EmplID As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(3) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@MNGRID", SqlDbType.VarChar)
        oParam(0).Value = CType(MngrID, String)

        oParam(1) = New SqlClient.SqlParameter("@FLAGMngrID", SqlDbType.VarChar)
        oParam(1).Value = CType(FLAGMngrID, String)

        oParam(2) = New SqlClient.SqlParameter("@FLAGEmplID", SqlDbType.VarChar)
        oParam(2).Value = CType(FLAGEmplID, String)

        oParam(3) = New SqlClient.SqlParameter("@EmplID", SqlDbType.VarChar)
        oParam(3).Value = CType(EmplID, String)


        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LINE__MANAGER, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_InsertLogin(ByVal _userid As String, ByVal _ip As String, ByVal _entity As String, ByVal EMPLID As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@USERID", SqlDbType.VarChar)
        oParam(0).Value = CType(_userid, String)

        oParam(1) = New SqlClient.SqlParameter("@IP", SqlDbType.VarChar)
        oParam(1).Value = CType(_ip, String)

        oParam(2) = New SqlClient.SqlParameter("@EMPLID", SqlDbType.VarChar)
        oParam(2).Value = CType(EMPLID, String)


        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_INSERT_LOGIN, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_CheckMMenus(ByVal _UserName As String, ByVal _MenuID As String, ByVal _entity As String) As DataTable
        Dim dt As New DataTable

        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@UserName", SqlDbType.VarChar)
        oParam(0).Value = CType(_UserName, String)

        oParam(1) = New SqlClient.SqlParameter("@IDMenu", SqlDbType.VarChar)
        oParam(1).Value = CType(_MenuID, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_CHECK_MENU, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_CheckMMenu(ByVal _UserName As String, ByVal _MenuID As String, ByVal _entity As String) As DataTable
        Dim dt As New DataTable

        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@UserName", SqlDbType.VarChar)
        oParam(0).Value = CType(_UserName, String)

        oParam(1) = New SqlClient.SqlParameter("@IDMenu", SqlDbType.VarChar)
        oParam(1).Value = CType(_MenuID, String)

        Dim _connectionString As String = Conn
        'dt = FillDataset(_connectionString, const_sp_CHECK_MENUS, CommandType.StoredProcedure, oParam)
        dt = DataAccess.FillDataset(_connectionString, const_sp_CHECK_MENU_NAME_MASTER, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_InsertUploadFile(ByVal _filename As String, ByVal _createdby As String, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@FILENAME", SqlDbType.VarChar)
        oParam(0).Value = CType(_filename, String)

        oParam(1) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(1).Value = CType(_createdby, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_InsertUploadFile, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_NAME_LOGIN(ByVal EMPLID As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMPLID", SqlDbType.VarChar)
        oParam(0).Value = CType(EMPLID, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_NAME_LOGIN, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_MST_EMPLOYEE() As DataTable

        Dim dt As New DataTable

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_EMPLOYEEID, CommandType.StoredProcedure)

        Return dt

    End Function
    Public Function f_SEL_MST_EMPLOYEE_USER(ByVal EmplID As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMPLOYEEID", SqlDbType.VarChar)
        oParam(0).Value = CType(EmplID, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_EMPLOYEEID_USER, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_EMPLOYEE_SUPER_ADMIN() As DataTable

        Dim dt As New DataTable

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_EMPLOYEE_SUPER_ADMIN, CommandType.StoredProcedure)

        Return dt

    End Function

    Public Function f_SEL_LIST_ATTENDANCE_ADMIN(ByVal ENTITY As String, ByVal ACCESS As String, ByVal MONTH As String,
                                         ByVal NAME As String, ByVal FLAGMONTH As String, ByVal FLAGACCESS As String, ByVal FLAGNAME As String, ByVal FLAGEmplID As String,
                                         ByVal EmplID As String, ByVal ROLE As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(9) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ENTITY", SqlDbType.VarChar)
        oParam(0).Value = CType(ENTITY, String)

        oParam(1) = New SqlClient.SqlParameter("@ACCESS", SqlDbType.VarChar)
        oParam(1).Value = CType(ACCESS, String)

        oParam(2) = New SqlClient.SqlParameter("@MONTH", SqlDbType.VarChar)
        oParam(2).Value = CType(MONTH, String)

        oParam(3) = New SqlClient.SqlParameter("@NAME", SqlDbType.VarChar)
        oParam(3).Value = CType(NAME, String)

        oParam(4) = New SqlClient.SqlParameter("@FLAGACCESS", SqlDbType.VarChar)
        oParam(4).Value = CType(FLAGACCESS, String)

        oParam(5) = New SqlClient.SqlParameter("@FLAGNAME", SqlDbType.VarChar)
        oParam(5).Value = CType(FLAGNAME, String)

        oParam(6) = New SqlClient.SqlParameter("@FLAGEmplID", SqlDbType.VarChar)
        oParam(6).Value = CType(FLAGEmplID, String)

        oParam(7) = New SqlClient.SqlParameter("@EmplID", SqlDbType.VarChar)
        oParam(7).Value = CType(EmplID, String)

        oParam(8) = New SqlClient.SqlParameter("@ROLE", SqlDbType.VarChar)
        oParam(8).Value = CType(ROLE, String)

        oParam(9) = New SqlClient.SqlParameter("@FLAGMONTH", SqlDbType.VarChar)
        oParam(9).Value = CType(FLAGMONTH, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_ATTENDANCE_ADMIN, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_LIST_ATTENDANCE_ADMIN_NONFTE(ByVal ENTITY As String, ByVal ACCESS As String, ByVal MONTH As String,
                                         ByVal NAME As String, ByVal FLAGMONTH As String, ByVal FLAGACCESS As String, ByVal FLAGNAME As String, ByVal FLAGEmplID As String,
                                         ByVal EmplID As String, ByVal ROLE As String, ByVal IDUSER As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(10) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ENTITY", SqlDbType.VarChar)
        oParam(0).Value = CType(ENTITY, String)

        oParam(1) = New SqlClient.SqlParameter("@ACCESS", SqlDbType.VarChar)
        oParam(1).Value = CType(ACCESS, String)

        oParam(2) = New SqlClient.SqlParameter("@MONTH", SqlDbType.VarChar)
        oParam(2).Value = CType(MONTH, String)

        oParam(3) = New SqlClient.SqlParameter("@NAME", SqlDbType.VarChar)
        oParam(3).Value = CType(NAME, String)

        oParam(4) = New SqlClient.SqlParameter("@FLAGACCESS", SqlDbType.VarChar)
        oParam(4).Value = CType(FLAGACCESS, String)

        oParam(5) = New SqlClient.SqlParameter("@FLAGNAME", SqlDbType.VarChar)
        oParam(5).Value = CType(FLAGNAME, String)

        oParam(6) = New SqlClient.SqlParameter("@FLAGEmplID", SqlDbType.VarChar)
        oParam(6).Value = CType(FLAGEmplID, String)

        oParam(7) = New SqlClient.SqlParameter("@EmplID", SqlDbType.VarChar)
        oParam(7).Value = CType(EmplID, String)

        oParam(8) = New SqlClient.SqlParameter("@ROLE", SqlDbType.VarChar)
        oParam(8).Value = CType(ROLE, String)

        oParam(9) = New SqlClient.SqlParameter("@FLAGMONTH", SqlDbType.VarChar)
        oParam(9).Value = CType(FLAGMONTH, String)

        oParam(10) = New SqlClient.SqlParameter("@IDUSER", SqlDbType.VarChar)
        oParam(10).Value = CType(IDUSER, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_ATTENDANCE_ADMIN_NONFTE, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_LIST_DETAIL_ATTENDANCE_ADMIN(ByVal ENTITY As String, ByVal ACCESS As String, ByVal MONTH As String,
                                         ByVal NAME As String, ByVal FLAGMONTH As String,
                                         ByVal EmplID As String, ByVal ROLE As String, ByVal YEARATTENDANCE As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(7) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ENTITY", SqlDbType.VarChar)
        oParam(0).Value = CType(ENTITY, String)

        oParam(1) = New SqlClient.SqlParameter("@ACCESS", SqlDbType.VarChar)
        oParam(1).Value = CType(ACCESS, String)

        oParam(2) = New SqlClient.SqlParameter("@MONTH", SqlDbType.VarChar)
        oParam(2).Value = CType(MONTH, String)

        oParam(3) = New SqlClient.SqlParameter("@NAME", SqlDbType.VarChar)
        oParam(3).Value = CType(NAME, String)

        oParam(4) = New SqlClient.SqlParameter("@EmplID", SqlDbType.VarChar)
        oParam(4).Value = CType(EmplID, String)

        oParam(5) = New SqlClient.SqlParameter("@FLAGMONTH", SqlDbType.VarChar)
        oParam(5).Value = CType(FLAGMONTH, String)

        oParam(6) = New SqlClient.SqlParameter("@ROLE", SqlDbType.VarChar)
        oParam(6).Value = CType(ROLE, String)

        oParam(7) = New SqlClient.SqlParameter("@YEARATTENDANCE", SqlDbType.VarChar)
        oParam(7).Value = CType(YEARATTENDANCE, String)


        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_DETAIL_ATTENDANCE_ADMIN, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_LIST_DETAIL_ATTENDANCE_ADMIN_EXPORT_REPORT(ByVal ENTITY As String, ByVal ACCESS As String, ByVal MONTH As String,
                                         ByVal NAME As String, ByVal FLAGMONTH As String,
                                         ByVal EmplID As String, ByVal YEARATTENDANCE As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(6) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ENTITY", SqlDbType.VarChar)
        oParam(0).Value = CType(ENTITY, String)

        oParam(1) = New SqlClient.SqlParameter("@ACCESS", SqlDbType.VarChar)
        oParam(1).Value = CType(ACCESS, String)

        oParam(2) = New SqlClient.SqlParameter("@MONTH", SqlDbType.VarChar)
        oParam(2).Value = CType(MONTH, String)

        oParam(3) = New SqlClient.SqlParameter("@NAME", SqlDbType.VarChar)
        oParam(3).Value = CType(NAME, String)

        oParam(4) = New SqlClient.SqlParameter("@EmplID", SqlDbType.VarChar)
        oParam(4).Value = CType(EmplID, String)

        oParam(5) = New SqlClient.SqlParameter("@FLAGMONTH", SqlDbType.VarChar)
        oParam(5).Value = CType(FLAGMONTH, String)

        oParam(6) = New SqlClient.SqlParameter("@YEARATTENDANCE", SqlDbType.VarChar)
        oParam(6).Value = CType(YEARATTENDANCE, String)


        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_DETAIL_ATTENDANCE_ADMIN_EXPORT_REPORT, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_LIST_DETAIL_ATTENDANCE_ADMIN_LOAD(ByVal ENTITY As String, ByVal ACCESS As String,
                                         ByVal NAME As String, ByVal EmplID As String, ByVal YEARATTENDANCE As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(4) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ENTITY", SqlDbType.VarChar)
        oParam(0).Value = CType(ENTITY, String)

        oParam(1) = New SqlClient.SqlParameter("@ACCESS", SqlDbType.VarChar)
        oParam(1).Value = CType(ACCESS, String)

        oParam(2) = New SqlClient.SqlParameter("@NAME", SqlDbType.VarChar)
        oParam(2).Value = CType(NAME, String)

        oParam(3) = New SqlClient.SqlParameter("@EmplID", SqlDbType.VarChar)
        oParam(3).Value = CType(EmplID, String)

        oParam(3) = New SqlClient.SqlParameter("@EmplID", SqlDbType.VarChar)
        oParam(3).Value = CType(EmplID, String)

        oParam(4) = New SqlClient.SqlParameter("@YEARATTENDANCE", SqlDbType.VarChar)
        oParam(4).Value = CType(YEARATTENDANCE, String)


        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_DETAIL_ATTENDANCE_ADMIN_LOAD, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_LIST_ATTENDANCE_USER(ByVal DATES As String, ByVal MONTH As String, ByVal EmplID As String,
                                                ByVal FLAGMONTH As String, ByVal FLAGDATES As String, ByVal YEARATTENDANCE As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(5) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@DATE", SqlDbType.Date)
        oParam(0).Value = CType(DATES, Date)

        oParam(1) = New SqlClient.SqlParameter("@MONTH", SqlDbType.VarChar)
        oParam(1).Value = CType(MONTH, String)

        oParam(2) = New SqlClient.SqlParameter("@FLAGDATES", SqlDbType.VarChar)
        oParam(2).Value = CType(FLAGDATES, String)

        oParam(3) = New SqlClient.SqlParameter("@FLAGMONTH", SqlDbType.VarChar)
        oParam(3).Value = CType(FLAGMONTH, String)

        oParam(4) = New SqlClient.SqlParameter("@EmplID", SqlDbType.VarChar)
        oParam(4).Value = CType(EmplID, String)

        oParam(5) = New SqlClient.SqlParameter("@YEARATTENDANCE", SqlDbType.VarChar)
        oParam(5).Value = CType(YEARATTENDANCE, String)


        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_ATTENDANCE_USER, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_LIST_ATTENDANCE_USER_LOAD(ByVal EmplID As String, ByVal YEARATTENDANCE As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EmplID", SqlDbType.VarChar)
        oParam(0).Value = CType(EmplID, String)

        oParam(1) = New SqlClient.SqlParameter("@YEARATTENDANCE", SqlDbType.VarChar)
        oParam(1).Value = CType(YEARATTENDANCE, String)


        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_ATTENDANCE_USER_LOAD, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_LIST_ATTENDANCE_USER_EXPORT_REPORT(ByVal DATES As String, ByVal MONTH As String, ByVal EmplID As String,
                                                ByVal FLAGMONTH As String, ByVal FLAGDATES As String, ByVal YEARATTENDANCE As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(5) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@DATE", SqlDbType.Date)
        oParam(0).Value = CType(DATES, Date)

        oParam(1) = New SqlClient.SqlParameter("@MONTH", SqlDbType.VarChar)
        oParam(1).Value = CType(MONTH, String)

        oParam(2) = New SqlClient.SqlParameter("@FLAGDATES", SqlDbType.VarChar)
        oParam(2).Value = CType(FLAGDATES, String)

        oParam(3) = New SqlClient.SqlParameter("@FLAGMONTH", SqlDbType.VarChar)
        oParam(3).Value = CType(FLAGMONTH, String)

        oParam(4) = New SqlClient.SqlParameter("@EmplID", SqlDbType.VarChar)
        oParam(4).Value = CType(EmplID, String)

        oParam(5) = New SqlClient.SqlParameter("@YEARATTENDANCE", SqlDbType.VarChar)
        oParam(5).Value = CType(YEARATTENDANCE, String)


        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_ATTENDANCE_USER_EXPORT_REPORT, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_ATTENDANCE_ADMIN_DETAIL(ByVal IDX As Integer) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.Int)
        oParam(0).Value = CType(IDX, Integer)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_DETAIL_ATTENDANCE_ADMIN, CommandType.StoredProcedure, oParam)

        Return dt
    End Function

    Public Function f_SEL_GET_DETAIL_DAYS_ATTENDANCE(ByVal DATESIGNIN As DateTime, DATESIGNOUT As DateTime) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@DATESIGNIN", SqlDbType.DateTime)
        oParam(0).Value = CType(DATESIGNIN, DateTime)

        oParam(1) = New SqlClient.SqlParameter("@DATESIGNOUT", SqlDbType.DateTime)
        oParam(1).Value = CType(DATESIGNOUT, DateTime)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_GET_DETAIL_DAYS_ATTENDANCE, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_CHECK_DAYS_ATTENDANCE(ByVal UPLOADID As Integer, ByVal ACCESSCARDNO As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@UPLOADID", SqlDbType.Int)
        oParam(0).Value = CType(UPLOADID, Integer)

        oParam(1) = New SqlClient.SqlParameter("@ACCESSCARDNO_2", SqlDbType.VarChar)
        oParam(1).Value = CType(ACCESSCARDNO, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_CHECK_DAYS_ATTENDANCE, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_SEL_EMPL_NUMBER(ByVal EMPLOYEENAME As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMPLOYEENAME", SqlDbType.VarChar)
        oParam(0).Value = CType(EMPLOYEENAME, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_EMPL_NUMBER, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_EMPL_NUMBER_WITH_EMAIL(ByVal EMAIL As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMAIL", SqlDbType.VarChar)
        oParam(0).Value = CType(EMAIL, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_EMPL_NUMBER_WITH_EMAIL, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEND_EMAIL_NOTIF_CWH_TO_HR(ByVal EMPLNAME As String, ByVal EMPLOYEEID As String, ByVal PATH As String,
                                                 ByVal ENTITY As String, ByVal LINK_APPROVAL As String, ByVal Year As String,
                                                 ByVal Quarter As String, ByVal FILENAME As String,
                                                 ByVal UploadID As Integer, ByVal CREATEDBY As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(9) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@Name", SqlDbType.VarChar)
        oParam(0).Value = CType(EMPLNAME, String)

        oParam(1) = New SqlClient.SqlParameter("@EMPLOYEEID", SqlDbType.VarChar)
        oParam(1).Value = CType(EMPLOYEEID, String)

        oParam(2) = New SqlClient.SqlParameter("@PATH", SqlDbType.VarChar)
        oParam(2).Value = CType(PATH, String)

        oParam(3) = New SqlClient.SqlParameter("@ENTITY", SqlDbType.VarChar)
        oParam(3).Value = CType(ENTITY, String)

        oParam(4) = New SqlClient.SqlParameter("@LINK_APPROVAL", SqlDbType.VarChar)
        oParam(4).Value = CType(LINK_APPROVAL, String)

        oParam(5) = New SqlClient.SqlParameter("@Year", SqlDbType.VarChar)
        oParam(5).Value = CType(Year, String)

        oParam(6) = New SqlClient.SqlParameter("@Quarter", SqlDbType.VarChar)
        oParam(6).Value = CType(Quarter, String)

        oParam(7) = New SqlClient.SqlParameter("@FILENAME", SqlDbType.VarChar)
        oParam(7).Value = CType(FILENAME, String)

        oParam(8) = New SqlClient.SqlParameter("@UPLOADID", SqlDbType.Int)
        oParam(8).Value = CType(UploadID, Integer)

        oParam(9) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(9).Value = CType(CREATEDBY, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEND_EMAIL_NOTIF_CWH_TO_HR, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_EMAIL_EMPL(ByVal EMPLID As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMPLID", SqlDbType.VarChar)
        oParam(0).Value = CType(EMPLID, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_EMAIL_EMPL, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_DETAIL_CWH(ByVal EMPLID As String, ByVal Years As String, ByVal Quarter As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMPLID", SqlDbType.VarChar)
        oParam(0).Value = CType(EMPLID, String)

        oParam(1) = New SqlClient.SqlParameter("@YEAR", SqlDbType.VarChar)
        oParam(1).Value = CType(Years, String)

        oParam(2) = New SqlClient.SqlParameter("@QUARTER", SqlDbType.VarChar)
        oParam(2).Value = CType(Quarter, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_DETAIL_CWH, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_LIST_DOCUMENT_CWH(ByVal ENTITY As String, ByVal YEAR As String, ByVal QUARTER As String, ByVal EMPLID As String,
                                        ByVal NAME As String, ByVal FLAGYEAR As String, ByVal FLAGQUARTER As String, ByVal FLAGEmplID As String, ByVal FLAGNAME As String,
                                        ByVal ROLE As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(9) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ENTITY", SqlDbType.VarChar)
        oParam(0).Value = CType(ENTITY, String)

        oParam(1) = New SqlClient.SqlParameter("@YEAR", SqlDbType.VarChar)
        oParam(1).Value = CType(YEAR, String)

        oParam(2) = New SqlClient.SqlParameter("@QUARTER", SqlDbType.VarChar)
        oParam(2).Value = CType(QUARTER, String)

        oParam(3) = New SqlClient.SqlParameter("@EMPLID", SqlDbType.VarChar)
        oParam(3).Value = CType(EMPLID, String)

        oParam(4) = New SqlClient.SqlParameter("@NAME", SqlDbType.VarChar)
        oParam(4).Value = CType(NAME, String)

        oParam(5) = New SqlClient.SqlParameter("@FLAGYEAR", SqlDbType.VarChar)
        oParam(5).Value = CType(FLAGYEAR, String)

        oParam(6) = New SqlClient.SqlParameter("@FLAGQUARTER", SqlDbType.VarChar)
        oParam(6).Value = CType(FLAGQUARTER, String)

        oParam(7) = New SqlClient.SqlParameter("@FLAGEmplID", SqlDbType.VarChar)
        oParam(7).Value = CType(FLAGEmplID, String)

        oParam(8) = New SqlClient.SqlParameter("@FLAGNAME", SqlDbType.VarChar)
        oParam(8).Value = CType(NAME, String)

        oParam(9) = New SqlClient.SqlParameter("@ROLE", SqlDbType.VarChar)
        oParam(9).Value = CType(ROLE, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_DOCUMENT_CWH, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_LIST_DOCUMENT_CWH_EXPORT(ByVal ENTITY As String, ByVal YEAR As String, ByVal QUARTER As String, ByVal EMPLID As String,
                                        ByVal NAME As String, ByVal FLAGYEAR As String, ByVal FLAGQUARTER As String, ByVal FLAGEmplID As String, ByVal FLAGNAME As String,
                                        ByVal ROLE As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(9) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ENTITY", SqlDbType.VarChar)
        oParam(0).Value = CType(ENTITY, String)

        oParam(1) = New SqlClient.SqlParameter("@YEAR", SqlDbType.VarChar)
        oParam(1).Value = CType(YEAR, String)

        oParam(2) = New SqlClient.SqlParameter("@QUARTER", SqlDbType.VarChar)
        oParam(2).Value = CType(QUARTER, String)

        oParam(3) = New SqlClient.SqlParameter("@EMPLID", SqlDbType.VarChar)
        oParam(3).Value = CType(EMPLID, String)

        oParam(4) = New SqlClient.SqlParameter("@NAME", SqlDbType.VarChar)
        oParam(4).Value = CType(NAME, String)

        oParam(5) = New SqlClient.SqlParameter("@FLAGYEAR", SqlDbType.VarChar)
        oParam(5).Value = CType(FLAGYEAR, String)

        oParam(6) = New SqlClient.SqlParameter("@FLAGQUARTER", SqlDbType.VarChar)
        oParam(6).Value = CType(FLAGQUARTER, String)

        oParam(7) = New SqlClient.SqlParameter("@FLAGEmplID", SqlDbType.VarChar)
        oParam(7).Value = CType(FLAGEmplID, String)

        oParam(8) = New SqlClient.SqlParameter("@FLAGNAME", SqlDbType.VarChar)
        oParam(8).Value = CType(NAME, String)

        oParam(9) = New SqlClient.SqlParameter("@ROLE", SqlDbType.VarChar)
        oParam(9).Value = CType(ROLE, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_DOCUMENT_CWH_EXPORT, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_LIST_DOCUMENT_CWH_LOAD(ByVal ENTITY As String, ByVal ROLE As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ENTITY", SqlDbType.VarChar)
        oParam(0).Value = CType(ENTITY, String)

        oParam(1) = New SqlClient.SqlParameter("@ROLE", SqlDbType.VarChar)
        oParam(1).Value = CType(ROLE, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_DOCUMENT_CWH_LOAD, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_LIST_DOCUMENT_CWH_LOAD_NONFTE(ByVal ENTITY As String, ByVal ROLE As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ENTITY", SqlDbType.VarChar)
        oParam(0).Value = CType(ENTITY, String)

        oParam(1) = New SqlClient.SqlParameter("@ROLE", SqlDbType.VarChar)
        oParam(1).Value = CType(ROLE, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_DOCUMENT_CWH_LOAD_NONFTE, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_LIST_DOCUMENT_CWH_LOAD_SUPER_ADMIN(ByVal ROLE As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ROLE", SqlDbType.VarChar)
        oParam(0).Value = CType(ROLE, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_DOCUMENT_CWH_LOAD_SUPER_ADMIN, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_CHECK_UPLOAD_CWH(ByVal EMPLID As String, ByVal Years As String, ByVal Quarter As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMPLID", SqlDbType.VarChar)
        oParam(0).Value = CType(EMPLID, String)

        oParam(1) = New SqlClient.SqlParameter("@YEAR", SqlDbType.VarChar)
        oParam(1).Value = CType(Years, String)

        oParam(2) = New SqlClient.SqlParameter("@QUARTER", SqlDbType.VarChar)
        oParam(2).Value = CType(Quarter, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_CHECK_UPLOAD_CWH, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_LIST_DOCUMENT_CWH_FOR_EMPLOYEE_LOAD(ByVal EMPLOYEEID As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMPLOYEEID", SqlDbType.VarChar)
        oParam(0).Value = CType(EMPLOYEEID, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_DOCUMENT_CWH_FOR_EMPLOYEE_LOAD, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_LIST_DOCUMENT_CWH_FOR_EMPLOYEE(ByVal EMPLOYEEID As String, ByVal YEAR As String, ByVal QUARTER As String,
                                       ByVal FLAGYEAR As String, ByVal FLAGQUARTER As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(4) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMPLOYEEID", SqlDbType.VarChar)
        oParam(0).Value = CType(EMPLOYEEID, String)

        oParam(1) = New SqlClient.SqlParameter("@YEAR", SqlDbType.VarChar)
        oParam(1).Value = CType(YEAR, String)

        oParam(2) = New SqlClient.SqlParameter("@QUARTER", SqlDbType.VarChar)
        oParam(2).Value = CType(QUARTER, String)

        oParam(3) = New SqlClient.SqlParameter("@FLAGYEAR", SqlDbType.VarChar)
        oParam(3).Value = CType(FLAGYEAR, String)

        oParam(4) = New SqlClient.SqlParameter("@FLAGQUARTER", SqlDbType.VarChar)
        oParam(4).Value = CType(FLAGQUARTER, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_DOCUMENT_CWH_FOR_EMPLOYEE, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_MST_EMPLOYEE_MASTER(ByVal ENTITY As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ENTITY", SqlDbType.VarChar)
        oParam(0).Value = CType(ENTITY, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_EMPLOYEEID_ENTITY, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_GET_MST_QUARTER(ByVal MONTHS As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@MONTH", SqlDbType.VarChar)
        oParam(0).Value = CType(MONTHS, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_GET_MST_QUARTER, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_GET_STATUS_APPROVED(ByVal QUARTERS As String, ByVal YEARS As String, ByVal EmplID As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@QUARTERS", SqlDbType.VarChar)
        oParam(0).Value = CType(QUARTERS, String)

        oParam(1) = New SqlClient.SqlParameter("@YEARS", SqlDbType.VarChar)
        oParam(1).Value = CType(YEARS, String)

        oParam(2) = New SqlClient.SqlParameter("@EMPLOYEEID", SqlDbType.VarChar)
        oParam(2).Value = CType(EmplID, String)


        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_GET_STATUS_APPROVED, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_GET_STATUS_ACCESS_CWH(ByVal EmplID As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMPLOYEEID", SqlDbType.VarChar)
        oParam(0).Value = CType(EmplID, String)


        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_GET_STATUS_ACCESS_CWH, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_MST_MONTH_QUARTER(ByVal QUARTER As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@QUARTER", SqlDbType.VarChar)
        oParam(0).Value = CType(QUARTER, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_GET_MONTH_QUARTER, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_QUARTER(ByVal QUARTER As String) As DataTable
        Dim dt As New DataTable

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@QUARTER", SqlDbType.VarChar)
        oParam(0).Value = CType(QUARTER, String)

        Dim _connectionString As String = Conn
        'dt = FillDataset(_connectionString, const_sp_CHECK_MENUS, CommandType.StoredProcedure, oParam)
        dt = DataAccess.FillDataset(_connectionString, const_sp_CHECK_QUARTER, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_SEL_MAPPING_EMPLOYEE_MANAGER_LAOD() As DataTable
        Dim dt As New DataTable

        Dim _connectionString As String = Conn
        'dt = FillDataset(_connectionString, const_sp_CHECK_MENUS, CommandType.StoredProcedure, oParam)
        dt = DataAccess.FillDataset(_connectionString, const_sp_MAPPING_EMPLOYEE_MANAGER_LOAD, CommandType.StoredProcedure)

        Return dt
    End Function
    Public Function f_SEL_MAPPING_EMPLOYEE_MANAGER(ByVal EMPLOYEEID As String) As DataTable
        Dim dt As New DataTable

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMPLOYEEID", SqlDbType.VarChar)
        oParam(0).Value = CType(EMPLOYEEID, String)

        Dim _connectionString As String = Conn
        'dt = FillDataset(_connectionString, const_sp_CHECK_MENUS, CommandType.StoredProcedure, oParam)
        dt = DataAccess.FillDataset(_connectionString, const_sp_MAPPING_EMPLOYEE_MANAGER, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_SEL_LIST_ATTENDANCE_FOR_MANAGER(ByVal ENTITY As String, ByVal ACCESS As String, ByVal MONTH As String,
                                         ByVal NAME As String, ByVal FLAGMONTH As String, ByVal FLAGACCESS As String, ByVal FLAGNAME As String, ByVal FLAGEmplID As String,
                                         ByVal EmplID As String, ByVal ROLE As String, ByVal EMPLID_MANAGER As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(10) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ENTITY", SqlDbType.VarChar)
        oParam(0).Value = CType(ENTITY, String)

        oParam(1) = New SqlClient.SqlParameter("@ACCESS", SqlDbType.VarChar)
        oParam(1).Value = CType(ACCESS, String)

        oParam(2) = New SqlClient.SqlParameter("@MONTH", SqlDbType.VarChar)
        oParam(2).Value = CType(MONTH, String)

        oParam(3) = New SqlClient.SqlParameter("@NAME", SqlDbType.VarChar)
        oParam(3).Value = CType(NAME, String)

        oParam(4) = New SqlClient.SqlParameter("@FLAGACCESS", SqlDbType.VarChar)
        oParam(4).Value = CType(FLAGACCESS, String)

        oParam(5) = New SqlClient.SqlParameter("@FLAGNAME", SqlDbType.VarChar)
        oParam(5).Value = CType(FLAGNAME, String)

        oParam(6) = New SqlClient.SqlParameter("@FLAGEmplID", SqlDbType.VarChar)
        oParam(6).Value = CType(FLAGEmplID, String)

        oParam(7) = New SqlClient.SqlParameter("@EmplID", SqlDbType.VarChar)
        oParam(7).Value = CType(EmplID, String)

        oParam(8) = New SqlClient.SqlParameter("@ROLE", SqlDbType.VarChar)
        oParam(8).Value = CType(ROLE, String)

        oParam(9) = New SqlClient.SqlParameter("@FLAGMONTH", SqlDbType.VarChar)
        oParam(9).Value = CType(FLAGMONTH, String)

        oParam(10) = New SqlClient.SqlParameter("@EMPLID_MANAGER", SqlDbType.VarChar)
        oParam(10).Value = CType(EMPLID_MANAGER, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_ATTENDANCE_FOR_MANAGER, CommandType.StoredProcedure, oParam)

        Return dt

    End Function


    Public Function f_SEL_LIST_ATTENDANCE_FOR_MANAGER_LOAD(ByVal EmplID As String, ByVal YEARATTENDANCE As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EmplID", SqlDbType.VarChar)
        oParam(0).Value = CType(EmplID, String)

        oParam(1) = New SqlClient.SqlParameter("@YEARATTENDANCE", SqlDbType.VarChar)
        oParam(1).Value = CType(YEARATTENDANCE, String)


        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_ATTENDANCE_FOR_MANAGER_LOAD, CommandType.StoredProcedure, oParam)

        Return dt
    End Function


    Public Function f_SEL_LIST_DETAIL_ATTENDANCE_FOR_MANAGER(ByVal ENTITY As String, ByVal ACCESS As String, ByVal MONTH As String,
                                         ByVal NAME As String, ByVal FLAGMONTH As String,
                                         ByVal EmplID As String, ByVal ROLE As String, ByVal YEARATTENDANCE As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(7) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ENTITY", SqlDbType.VarChar)
        oParam(0).Value = CType(ENTITY, String)

        oParam(1) = New SqlClient.SqlParameter("@ACCESS", SqlDbType.VarChar)
        oParam(1).Value = CType(ACCESS, String)

        oParam(2) = New SqlClient.SqlParameter("@MONTH", SqlDbType.VarChar)
        oParam(2).Value = CType(MONTH, String)

        oParam(3) = New SqlClient.SqlParameter("@NAME", SqlDbType.VarChar)
        oParam(3).Value = CType(NAME, String)

        oParam(4) = New SqlClient.SqlParameter("@EmplID", SqlDbType.VarChar)
        oParam(4).Value = CType(EmplID, String)

        oParam(5) = New SqlClient.SqlParameter("@FLAGMONTH", SqlDbType.VarChar)
        oParam(5).Value = CType(FLAGMONTH, String)

        oParam(6) = New SqlClient.SqlParameter("@ROLE", SqlDbType.VarChar)
        oParam(6).Value = CType(ROLE, String)

        oParam(7) = New SqlClient.SqlParameter("@YEARATTENDANCE", SqlDbType.VarChar)
        oParam(7).Value = CType(YEARATTENDANCE, String)


        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_DETAIL_ATTENDANCE_FOR_MANAGER, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_LIST_DETAIL_ATTENDANCE_FOR_MANAGER_EXPORT_REPORT(ByVal ENTITY As String, ByVal ACCESS As String, ByVal MONTH As String,
                                         ByVal NAME As String, ByVal FLAGMONTH As String,
                                         ByVal EmplID As String, ByVal YEARATTENDANCE As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(6) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ENTITY", SqlDbType.VarChar)
        oParam(0).Value = CType(ENTITY, String)

        oParam(1) = New SqlClient.SqlParameter("@ACCESS", SqlDbType.VarChar)
        oParam(1).Value = CType(ACCESS, String)

        oParam(2) = New SqlClient.SqlParameter("@MONTH", SqlDbType.VarChar)
        oParam(2).Value = CType(MONTH, String)

        oParam(3) = New SqlClient.SqlParameter("@NAME", SqlDbType.VarChar)
        oParam(3).Value = CType(NAME, String)

        oParam(4) = New SqlClient.SqlParameter("@EmplID", SqlDbType.VarChar)
        oParam(4).Value = CType(EmplID, String)

        oParam(5) = New SqlClient.SqlParameter("@FLAGMONTH", SqlDbType.VarChar)
        oParam(5).Value = CType(FLAGMONTH, String)

        oParam(6) = New SqlClient.SqlParameter("@YEARATTENDANCE", SqlDbType.VarChar)
        oParam(6).Value = CType(YEARATTENDANCE, String)


        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_DETAIL_ATTENDANCE_FOR_MANAGER_EXPORT_REPORT, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_LIST_DETAIL_ATTENDANCE_FOR_MANAGER_LOAD(ByVal ENTITY As String, ByVal ACCESS As String,
                                         ByVal NAME As String, ByVal EmplID As String, ByVal YEARATTENDANCE As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(4) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ENTITY", SqlDbType.VarChar)
        oParam(0).Value = CType(ENTITY, String)

        oParam(1) = New SqlClient.SqlParameter("@ACCESS", SqlDbType.VarChar)
        oParam(1).Value = CType(ACCESS, String)

        oParam(2) = New SqlClient.SqlParameter("@NAME", SqlDbType.VarChar)
        oParam(2).Value = CType(NAME, String)

        oParam(3) = New SqlClient.SqlParameter("@EmplID", SqlDbType.VarChar)
        oParam(3).Value = CType(EmplID, String)

        oParam(4) = New SqlClient.SqlParameter("@YEARATTENDANCE", SqlDbType.VarChar)
        oParam(4).Value = CType(YEARATTENDANCE, String)


        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_DETAIL_ATTENDANCE_FOR_MANAGER_LOAD, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_LIST_MENU_CWH(ByVal EmplID As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMPLNUMBER", SqlDbType.VarChar)
        oParam(0).Value = CType(EmplID, String)


        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_MENU_CWH, CommandType.StoredProcedure, oParam)

        Return dt

    End Function


End Class
