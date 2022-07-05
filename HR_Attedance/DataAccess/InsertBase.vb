Imports System.Data.SqlClient

Public Class InsertBase

    Dim Conn As String = ConfigurationManager.ConnectionStrings("ConSql").ToString
    Dim DataAccess As New DataAccessBase

#Region "Constanta"
    Dim const_sp_DEL_USER_MATRIX As String = "sp_DEL_USER_MATRIX"

    Dim const_SP_INSERT_USER_MATRIX As String = "sp_ADD_USER_MATRIX"
    Dim const_SP_EDIT_USER_MATRIX As String = "sp_EDIT_USER_MATRIX"
    Dim const_sp_INSERT_LOG_FILE_ATTACHMENT As String = "sp_INSERT_LOG_FILE_ATTACHMENT"
    Dim const_SP_INS_MST_MENU As String = "sp_Add_Master_Menu"
    Dim const_SP_INS_MST_MENU_CHILD As String = "sp_Add_Master_Menu_Child"
    Dim const_SP_INS_TRN_ATTENDANCE As String = "sp_INSERT_UPLOAD_ATTENDANCE"
    Dim const_SP_INS_TRN_ATTENDANCE_AJENG As String = "sp_INSERT_UPLOAD_ATTENDANCE_AJENG_20190326"
    Dim const_SP_INS_MASTER_DATA_ATTENDANCE As String = "sp_INSERT_MASTER_DATA_ATTENDANCE"
    Dim const_SP_INS_MASTER_DATA_EMPLOYEE As String = "SP_INS_MASTER_DATA_EMPLOYEE"
    Dim const_SP_INS_TRN_DOC_CWH As String = "sp_INSERT_TRN_DOCUMENT"
    Dim const_SP_INS_MST_MAPPING_EMPLOYEE_MANAGERS As String = "sp_INSERT_MASTER_DATA_MAPPING_EMPLOYEE_MANAGERS"
    Dim const_sp_INSERT_LINE_MANAGER As String = "sp_INSERT_LINE_MANAGER"
    Dim const_SP_INSERT_MASTER_DATA_EMPLOYEE As String = "SP_INSERT_MASTER_DATA_EMPLOYEE"
    Dim const_sp_MENU_LIST_ATTENDANCE_MANAGER As String = "sp_MENU_LIST_ATTENDANCE_MANAGER"
    Dim const_SP_INSERT_MST_EXPIRED As String = "sp_INSERT_MST_EXPIRED"
    Dim const_SP_INS_USER_PASS As String = "SP_INS_USER_PASS"
    Dim const_sp_MENU_DOC_CWH As String = "sp_MENU_DOC_CWH"


#End Region
    Public Function f_INS_USER_PASS(ByVal USERNAME As String, ByVal PASS As String)

        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlParameter("@USERNAME", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(USERNAME, String)

        oParam(1) = New SqlParameter("@PASS", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(PASS, String)

        Dim _connectionString As String = Conn

        Return (DataAccess.ExecuteNonQuery(_connectionString, const_SP_INS_USER_PASS, Data.CommandType.StoredProcedure, oParam))

    End Function

    Public Function f_INSERT_MST_EXPIRED(ByVal QUARTER As String, ByVal YEAR As String, ByVal DATES As String,
                                         ByVal CREATEDBY As String, ByVal RANGEPERIOD As String)

        Dim oParam(4) As SqlParameter

        oParam(0) = New SqlParameter("@QUARTER", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(QUARTER, String)

        oParam(1) = New SqlParameter("@YEAR", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(YEAR, String)

        oParam(2) = New SqlParameter("@DATE", Data.SqlDbType.Date)
        oParam(2).Value = CType(DATES, Date)

        oParam(3) = New SqlParameter("@CREATEDBY", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(CREATEDBY, String)

        oParam(4) = New SqlParameter("@RANGEPERIOD", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(RANGEPERIOD, String)


        Dim _connectionString As String = Conn

        Return (DataAccess.ExecuteNonQuery(_connectionString, const_SP_INSERT_MST_EXPIRED, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function f_MENU_LIST_ATTENDANCE_MANAGER(ByVal IdxMatrix As String, ByVal EmployeeID As String, ByVal EmployeeName As String,
                                            ByVal IDMenuChild As String, ByVal ENTITY As String, ByVal ROLE As String,
                                            ByVal CreatedBy As String, ByVal CreatedDate As String, ByVal UpdateBy As String,
                                            ByVal UpdateDate As String, ByVal Flag As String)

        Dim oParam(10) As SqlParameter

        oParam(0) = New SqlParameter("@Idx", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(IdxMatrix, String)

        oParam(1) = New SqlParameter("@EmployeeID", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(EmployeeID, String)

        oParam(2) = New SqlParameter("@UserName", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(EmployeeName, String)

        oParam(3) = New SqlParameter("@IDMenuChild", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(IDMenuChild, String)

        oParam(4) = New SqlParameter("@ENTITY", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(ENTITY, String)

        oParam(5) = New SqlParameter("@ROLE", Data.SqlDbType.VarChar)
        oParam(5).Value = CType(ROLE, String)

        oParam(6) = New SqlParameter("@CreatedBy", Data.SqlDbType.VarChar)
        oParam(6).Value = CType(CreatedBy, String)

        oParam(7) = New SqlParameter("@CreatedDate", Data.SqlDbType.VarChar)
        oParam(7).Value = CType(CreatedDate, String)

        oParam(8) = New SqlParameter("@UpdateBy", Data.SqlDbType.VarChar)
        oParam(8).Value = CType(UpdateBy, String)

        oParam(9) = New SqlParameter("@UpdateDate", Data.SqlDbType.VarChar)
        oParam(9).Value = CType(UpdateDate, String)

        oParam(10) = New SqlParameter("@Flag", Data.SqlDbType.VarChar)
        oParam(10).Value = CType(Flag, String)

        Dim _connectionString As String = Conn

        Return (DataAccess.ExecuteNonQuery(_connectionString, const_sp_MENU_LIST_ATTENDANCE_MANAGER, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function f_INSERT_MASTER_DATA_EMPLOYEE(ByVal EmployeeID As String, ByVal EmployeeName As String,
                                            ByVal Entity As String, ByVal AccessCardNo As String, ByVal LocationName As String,
                                            ByVal EmployeeGender As String, ByVal WorkerType As String, ByVal CreatedBy As String, ByVal UploadID As Integer)

        Dim oParam(8) As SqlParameter

        oParam(0) = New SqlParameter("@EmployeeID", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(EmployeeID, String)

        oParam(1) = New SqlParameter("@EmployeeName", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(EmployeeName, String)

        oParam(2) = New SqlParameter("@Entity", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(Entity, String)

        oParam(3) = New SqlParameter("@AccessCardNo", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(AccessCardNo, String)

        oParam(4) = New SqlParameter("@LocationName", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(LocationName, String)

        oParam(5) = New SqlParameter("@EmployeeGender", Data.SqlDbType.VarChar)
        oParam(5).Value = CType(EmployeeGender, String)

        oParam(6) = New SqlParameter("@WorkerType", Data.SqlDbType.VarChar)
        oParam(6).Value = CType(WorkerType, String)

        oParam(7) = New SqlParameter("@CreatedBy", Data.SqlDbType.VarChar)
        oParam(7).Value = CType(CreatedBy, String)

        oParam(8) = New SqlParameter("@UploadID", Data.SqlDbType.VarChar)
        oParam(8).Value = CType(UploadID, String)

        Dim _connectionString As String = Conn

        Return (DataAccess.ExecuteNonQuery(_connectionString, const_SP_INSERT_MASTER_DATA_EMPLOYEE, Data.CommandType.StoredProcedure, oParam))

    End Function

    Public Function f_INSERT_LINE_MANAGER(ByVal EmployeeID As String, ByVal EmployeeName As String,
                                         ByVal Entity As String, ByVal WorkerType As String,
                                         ByVal Email As String, ByVal EmployeeID_Manager As String,
                                         ByVal EmployeeName_Manager As String, ByVal Email_Manager As String)

        Dim oParam(7) As SqlParameter

        oParam(0) = New SqlParameter("@EmployeeID", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(EmployeeID, String)

        oParam(1) = New SqlParameter("@EmployeeName", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(EmployeeName, String)

        oParam(2) = New SqlParameter("@Entity", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(Entity, String)

        oParam(3) = New SqlParameter("@WorkerType", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(WorkerType, String)

        oParam(4) = New SqlParameter("@Email", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(Email, String)

        oParam(5) = New SqlParameter("@EmployeeID_Manager", Data.SqlDbType.VarChar)
        oParam(5).Value = CType(EmployeeID_Manager, String)

        oParam(6) = New SqlParameter("@EmployeeName_Manager", Data.SqlDbType.VarChar)
        oParam(6).Value = CType(EmployeeName_Manager, String)

        oParam(7) = New SqlParameter("@Email_Manager", Data.SqlDbType.VarChar)
        oParam(7).Value = CType(Email_Manager, String)


        Dim _connectionString As String = Conn

        Return (DataAccess.ExecuteNonQuery(_connectionString, const_sp_INSERT_LINE_MANAGER, Data.CommandType.StoredProcedure, oParam))

    End Function

    Public Function f_Insert_User_Matrix(ByVal _UserName As String, ByVal _IdMenuChild As String,
                                         ByVal _CreatedBy As String, ByVal ENTITY As String,
                                         ByVal ROLE As String, ByVal EmployeeID As String)

        Dim oParam(5) As SqlParameter

        oParam(0) = New SqlParameter("@UserName", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_UserName, String)

        oParam(1) = New SqlParameter("@IdMenuChild", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(_IdMenuChild, String)

        oParam(2) = New SqlParameter("@CREATED_BY", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(_CreatedBy, String)

        oParam(3) = New SqlParameter("@ENTITY", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(ENTITY, String)

        oParam(4) = New SqlParameter("@ROLE", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(ROLE, String)

        oParam(5) = New SqlParameter("@EmployeeID", Data.SqlDbType.VarChar)
        oParam(5).Value = CType(EmployeeID, String)

        Dim _connectionString As String = Conn

        Return (DataAccess.ExecuteNonQuery(_connectionString, const_SP_INSERT_USER_MATRIX, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function f_Edit_User_Matrix(ByVal _UserName As String, ByVal _IdMenuChild As String,
                                       ByVal _CreatedBy As String, ByVal ENTITY As String,
                                       ByVal ROLE As String, ByVal EmployeeID As String)

        Dim oParam(5) As SqlParameter

        oParam(0) = New SqlParameter("@UserName", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_UserName, String)

        oParam(1) = New SqlParameter("@IdMenuChild", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(_IdMenuChild, String)

        oParam(2) = New SqlParameter("@CREATED_BY", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(_CreatedBy, String)

        oParam(3) = New SqlParameter("@ENTITY", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(ENTITY, String)

        oParam(4) = New SqlParameter("@ROLE", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(ROLE, String)

        oParam(5) = New SqlParameter("@EmployeeID", Data.SqlDbType.VarChar)
        oParam(5).Value = CType(EmployeeID, String)



        Dim _connectionString As String = Conn

        Return (DataAccess.ExecuteNonQuery(_connectionString, const_SP_EDIT_USER_MATRIX, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function f_Insert_Mst_Menu(ByVal _MenuName As String, ByVal _entity As String)

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlParameter("@MenuName", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_MenuName, String)

        Dim _connectionString As String = Conn

        Return (DataAccess.ExecuteNonQuery(_connectionString, const_SP_INS_MST_MENU, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function f_Insert_Mst_Menu_Child(ByVal _MenuChildName As String, ByVal _path As String, ByVal _IDMenu As String, ByVal _entity As String)

        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlParameter("@MenuChildName", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_MenuChildName, String)

        oParam(1) = New SqlParameter("@IDMenu", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(_IDMenu, String)

        oParam(2) = New SqlParameter("@path", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(_path, String)

        Dim _connectionString As String = Conn

        Return (DataAccess.ExecuteNonQuery(_connectionString, const_SP_INS_MST_MENU_CHILD, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function f_Insert_TRN_ATTENDANCE_AJENG(ByVal _EmployeeName As String, ByVal _AccessCardNo As String,
                                            ByVal _FirstSignIn As DateTime, ByVal _LastSignOut As DateTime,
                                            ByVal _CreatedBy As String, ByVal _UploadID As Integer)

        Dim oParam(5) As SqlParameter

        oParam(0) = New SqlParameter("@EmployeeName", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_EmployeeName, String)

        oParam(1) = New SqlParameter("@AccessCardNo", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(_AccessCardNo, String)

        oParam(2) = New SqlParameter("@FirstSignIn", Data.SqlDbType.DateTime)
        oParam(2).Value = CType(_FirstSignIn, DateTime)

        oParam(3) = New SqlParameter("@LastSignOut", Data.SqlDbType.DateTime)
        oParam(3).Value = CType(_LastSignOut, DateTime)

        oParam(4) = New SqlParameter("@CreatedBy", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(_CreatedBy, String)

        oParam(5) = New SqlParameter("@UploadID", Data.SqlDbType.Int)
        oParam(5).Value = CType(_UploadID, Integer)

        Dim _connectionString As String = Conn

        Return (DataAccess.ExecuteNonQuery(_connectionString, const_SP_INS_TRN_ATTENDANCE_AJENG, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function f_Insert_TRN_ATTENDANCE(ByVal _EmployeeName As String, ByVal _AccessCardNo As String,
                                            ByVal _FirstSignIn As DateTime, ByVal _LastSignOut As DateTime,
                                            ByVal _CreatedBy As String, ByVal _UploadID As Integer)

        Dim oParam(5) As SqlParameter

        oParam(0) = New SqlParameter("@EmployeeName", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_EmployeeName, String)

        oParam(1) = New SqlParameter("@AccessCardNo", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(_AccessCardNo, String)

        oParam(2) = New SqlParameter("@FirstSignIn", Data.SqlDbType.DateTime)
        oParam(2).Value = CType(_FirstSignIn, DateTime)

        oParam(3) = New SqlParameter("@LastSignOut", Data.SqlDbType.DateTime)
        oParam(3).Value = CType(_LastSignOut, DateTime)

        oParam(4) = New SqlParameter("@CreatedBy", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(_CreatedBy, String)

        oParam(5) = New SqlParameter("@UploadID", Data.SqlDbType.Int)
        oParam(5).Value = CType(_UploadID, Integer)

        Dim _connectionString As String = Conn

        Return (DataAccess.ExecuteNonQuery(_connectionString, const_SP_INS_TRN_ATTENDANCE, Data.CommandType.StoredProcedure, oParam))

    End Function

    Public Function f_Insert_MASTER_DATA_ATTENDANCE(ByVal PersonNumber As String, ByVal FullName As String,
                                            ByVal LocationName As String, ByVal Entity As String,
                                            ByVal EmployeeGender As String, ByVal WorkerType As String,
                                            ByVal AccessCard As String, ByVal _CreatedBy As String,
                                            ByVal _UploadID As Integer)

        Dim oParam(8) As SqlParameter

        oParam(0) = New SqlParameter("@PersonNumber", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(PersonNumber, String)

        oParam(1) = New SqlParameter("@FullName", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(FullName, String)

        oParam(2) = New SqlParameter("@LocationName", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(LocationName, String)

        oParam(3) = New SqlParameter("@Entity", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(Entity, String)

        oParam(4) = New SqlParameter("@EmployeeGender", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(EmployeeGender, String)

        oParam(5) = New SqlParameter("@WorkerType", Data.SqlDbType.VarChar)
        oParam(5).Value = CType(WorkerType, String)

        oParam(6) = New SqlParameter("@AccessCard", Data.SqlDbType.VarChar)
        oParam(6).Value = CType(AccessCard, String)

        oParam(7) = New SqlParameter("@CreatedBy", Data.SqlDbType.VarChar)
        oParam(7).Value = CType(_CreatedBy, String)

        oParam(8) = New SqlParameter("@UploadID", Data.SqlDbType.Int)
        oParam(8).Value = CType(_UploadID, Integer)

        Dim _connectionString As String = Conn

        Return (DataAccess.ExecuteNonQuery(_connectionString, const_SP_INS_MASTER_DATA_ATTENDANCE, Data.CommandType.StoredProcedure, oParam))

    End Function

    Public Function f_INS_MASTER_DATA_EMPLOYEE(ByVal PersonNumber As String, ByVal FullName As String,
                                            ByVal Email As String, ByVal Entity As String,
                                            ByVal _CreatedBy As String, ByVal _UploadID As Integer)

        Dim oParam(5) As SqlParameter

        oParam(0) = New SqlParameter("@PersonNumber", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(PersonNumber, String)

        oParam(1) = New SqlParameter("@FullName", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(FullName, String)

        oParam(2) = New SqlParameter("@Email", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(Email, String)

        oParam(3) = New SqlParameter("@Entity", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(Entity, String)

        oParam(4) = New SqlParameter("@CreatedBy", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(_CreatedBy, String)

        oParam(5) = New SqlParameter("@UploadID", Data.SqlDbType.VarChar)
        oParam(5).Value = CType(_UploadID, String)

        Dim _connectionString As String = Conn

        Return (DataAccess.ExecuteNonQuery(_connectionString, const_SP_INS_MASTER_DATA_EMPLOYEE, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function f_sp_INSERT_TRN_DOCUMENT(ByVal EmployeeID As String, ByVal Years As String,
                                            ByVal Month As String, ByVal Quarter As String,
                                            ByVal CreatedBy As String, ByVal UploadID As Integer)

        Dim oParam(5) As SqlParameter

        oParam(0) = New SqlParameter("@EMPLOYEEID", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(EmployeeID, String)

        oParam(1) = New SqlParameter("@YEARS", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(Years, String)

        oParam(2) = New SqlParameter("@MONTH", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(Month, String)

        oParam(3) = New SqlParameter("@QUARTER", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(Quarter, String)

        oParam(4) = New SqlParameter("@CREATEDBY", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(CreatedBy, String)

        oParam(5) = New SqlParameter("@UPLOADID", Data.SqlDbType.Int)
        oParam(5).Value = CType(UploadID, Integer)

        Dim _connectionString As String = Conn

        Return (DataAccess.ExecuteNonQuery(_connectionString, const_SP_INS_TRN_DOC_CWH, Data.CommandType.StoredProcedure, oParam))

    End Function

    Public Function f_INS_MASTER_DATA_MAPPING_EMPLOYEE_MANAGERS(ByVal PersonNumber As String, ByVal Name As String,
                                            ByVal Entity As String, ByVal WorkerType As String, ByVal Email As String,
                                            ByVal ManagerID As String, ByVal ManagerName As String, ByVal ManagerEmail As String,
                                            ByVal _CreatedBy As String, ByVal _UploadID As Integer)

        Dim oParam(9) As SqlParameter

        oParam(0) = New SqlParameter("@PersonNumber", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(PersonNumber, String)

        oParam(1) = New SqlParameter("@Name", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(Name, String)

        oParam(2) = New SqlParameter("@Entity", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(Entity, String)

        oParam(3) = New SqlParameter("@WorkerType", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(WorkerType, String)

        oParam(4) = New SqlParameter("@Email", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(Email, String)

        oParam(5) = New SqlParameter("@ManagerID", Data.SqlDbType.VarChar)
        oParam(5).Value = CType(ManagerID, String)

        oParam(6) = New SqlParameter("@ManagerName", Data.SqlDbType.VarChar)
        oParam(6).Value = CType(ManagerName, String)

        oParam(7) = New SqlParameter("@ManagerEmail", Data.SqlDbType.VarChar)
        oParam(7).Value = CType(ManagerEmail, String)

        oParam(8) = New SqlParameter("@CreatedBy", Data.SqlDbType.VarChar)
        oParam(8).Value = CType(_CreatedBy, String)

        oParam(9) = New SqlParameter("@UploadID", Data.SqlDbType.Int)
        oParam(9).Value = CType(_UploadID, Integer)

        Dim _connectionString As String = Conn

        Return (DataAccess.ExecuteNonQuery(_connectionString, const_SP_INS_MST_MAPPING_EMPLOYEE_MANAGERS, Data.CommandType.StoredProcedure, oParam))

    End Function

    Public Function f_MENU_LIST_DOC_CWH(ByVal IdxMatrix As String, ByVal EmployeeID As String, ByVal EmployeeName As String,
                                            ByVal IDMenuChild As String, ByVal ENTITY As String, ByVal ROLE As String,
                                            ByVal CreatedBy As String, ByVal CreatedDate As String, ByVal UpdateBy As String,
                                            ByVal UpdateDate As String, ByVal Flag As String)

        Dim oParam(10) As SqlParameter

        oParam(0) = New SqlParameter("@Idx", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(IdxMatrix, String)

        oParam(1) = New SqlParameter("@EmployeeID", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(EmployeeID, String)

        oParam(2) = New SqlParameter("@UserName", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(EmployeeName, String)

        oParam(3) = New SqlParameter("@IDMenuChild", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(IDMenuChild, String)

        oParam(4) = New SqlParameter("@ENTITY", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(ENTITY, String)

        oParam(5) = New SqlParameter("@ROLE", Data.SqlDbType.VarChar)
        oParam(5).Value = CType(ROLE, String)

        oParam(6) = New SqlParameter("@CreatedBy", Data.SqlDbType.VarChar)
        oParam(6).Value = CType(CreatedBy, String)

        oParam(7) = New SqlParameter("@CreatedDate", Data.SqlDbType.VarChar)
        oParam(7).Value = CType(CreatedDate, String)

        oParam(8) = New SqlParameter("@UpdateBy", Data.SqlDbType.VarChar)
        oParam(8).Value = CType(UpdateBy, String)

        oParam(9) = New SqlParameter("@UpdateDate", Data.SqlDbType.VarChar)
        oParam(9).Value = CType(UpdateDate, String)

        oParam(10) = New SqlParameter("@Flag", Data.SqlDbType.VarChar)
        oParam(10).Value = CType(Flag, String)

        Dim _connectionString As String = Conn

        Return (DataAccess.ExecuteNonQuery(_connectionString, const_sp_MENU_DOC_CWH, Data.CommandType.StoredProcedure, oParam))

    End Function
End Class
