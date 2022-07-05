Imports System.Data.SqlClient

Public Class UpdateBase

    Dim Conn As String = ConfigurationManager.ConnectionStrings("ConSql").ToString
    Dim DataAccess As New DataAccessBase

#Region "Constanta"
    Dim const_sp_UPDATE_LOGOUT As String = "sp_UPDATE_LOGOUT"
    Dim const_sp_UPDATE_ATTENDANCE As String = "sp_UPDATE_ATTENDANCE"
    Dim const_sp_UPDATE_APPROVAL_CWH As String = "sp_UPDATE_APPROVAL_CWH"
    Dim const_sp_UPDATE_DETAIL_LINE_MANAGER As String = "sp_UPDATE_DETAIL_LINE_MANAGER"
    Dim const_sp_UPDATE_DETAIL_MASTER_EMPLOYEE As String = "sp_UPDATE_DETAIL_MASTER_EMPLOYEE"
#End Region

    Public Function f_UPDATE_DETAIL_MASTER_EMPLOYEE(ByVal EmployeeID As String, ByVal EmployeeName As String, ByVal Entity As String,
                                                    ByVal AccessCardNo As String, ByVal LocationName As String,
                                                    ByVal EmployeeGender As String, ByVal WorkerType As String) As Integer

        Dim oParam(6) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EmployeeID", SqlDbType.VarChar)
        oParam(0).Value = CType(EmployeeID, String)

        oParam(1) = New SqlClient.SqlParameter("@EmployeeName", SqlDbType.VarChar)
        oParam(1).Value = CType(EmployeeName, String)

        oParam(2) = New SqlClient.SqlParameter("@Entity", SqlDbType.VarChar)
        oParam(2).Value = CType(Entity, String)

        oParam(3) = New SqlClient.SqlParameter("@AccessCardNo", SqlDbType.VarChar)
        oParam(3).Value = CType(AccessCardNo, String)

        oParam(4) = New SqlClient.SqlParameter("@LocationName", SqlDbType.VarChar)
        oParam(4).Value = CType(LocationName, String)

        oParam(5) = New SqlClient.SqlParameter("@EmployeeGender", SqlDbType.VarChar)
        oParam(5).Value = CType(EmployeeGender, String)

        oParam(6) = New SqlClient.SqlParameter("@WorkerType", SqlDbType.VarChar)
        oParam(6).Value = CType(WorkerType, String)

        Dim _connectionString As String = Conn
        Return DataAccess.ExecuteNonQuery(_connectionString, const_sp_UPDATE_DETAIL_MASTER_EMPLOYEE, CommandType.StoredProcedure, oParam)

    End Function

    Public Function f_UPDATE_DETAIL_LINE_MANAGER(ByVal EmployeeID As String, ByVal EmployeeName As String, ByVal Email As String, ByVal Entity As String,
                                                 ByVal WorkerType As String, ByVal EmployeeID_Manager As String, ByVal EmployeeName_Manager As String,
                                                 ByVal Email_Manager As String) As Integer

        Dim oParam(7) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EmployeeID", SqlDbType.VarChar)
        oParam(0).Value = CType(EmployeeID, String)

        oParam(1) = New SqlClient.SqlParameter("@EmployeeName", SqlDbType.VarChar)
        oParam(1).Value = CType(EmployeeName, String)

        oParam(2) = New SqlClient.SqlParameter("@Entity", SqlDbType.VarChar)
        oParam(2).Value = CType(Entity, String)

        oParam(3) = New SqlClient.SqlParameter("@WorkerType", SqlDbType.VarChar)
        oParam(3).Value = CType(WorkerType, String)

        oParam(4) = New SqlClient.SqlParameter("@EmployeeID_Manager", SqlDbType.VarChar)
        oParam(4).Value = CType(EmployeeID_Manager, String)

        oParam(5) = New SqlClient.SqlParameter("@EmployeeName_Manager", SqlDbType.VarChar)
        oParam(5).Value = CType(EmployeeName_Manager, String)

        oParam(6) = New SqlClient.SqlParameter("@Email_Manager", SqlDbType.VarChar)
        oParam(6).Value = CType(Email_Manager, String)

        oParam(7) = New SqlClient.SqlParameter("@Email", SqlDbType.VarChar)
        oParam(7).Value = CType(Email, String)

        Dim _connectionString As String = Conn
        Return DataAccess.ExecuteNonQuery(_connectionString, const_sp_UPDATE_DETAIL_LINE_MANAGER, CommandType.StoredProcedure, oParam)

    End Function

    Public Function f_UpdateLogout(ByVal _userid As String, ByVal _entity As String) As Integer

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@USERID", SqlDbType.VarChar)
        oParam(0).Value = CType(_userid, String)

        Dim _connectionString As String = Conn
        Return DataAccess.ExecuteNonQuery(_connectionString, const_sp_UPDATE_LOGOUT, CommandType.StoredProcedure, oParam)

    End Function

    Public Function sp_UPDATE_ATTENDANCE(ByVal IDX As String, ByVal EMPLID As String, ByVal FIRSTSIGNINDATE As DateTime,
                                         ByVal LASTSIGNOUTDATE As DateTime, ByVal MONTH As String, ByVal TIMESIGNIN As String,
                                         ByVal TIMESIGNOUT As String, ByVal DAYS As String, ByVal TYPE_OF_DAYS As String,
                                         ByVal ARRIVALSTAT As String, ByVal TOTALWORKINGTIME As String, ByVal WORKINGSTAT As String,
                                         ByVal ISOVERTIME As String, ByVal OVERTIME As String, ByVal WORKING As String,
                                         ByVal CREATEDBY As String, ByVal DATEPROPIN As DateTime, ByVal DATEPROPOUT As DateTime,
                                         ByVal PROPIN As String, ByVal PROPOUT As String, ByVal REASON As String,
                                         ByVal WORKINGTIME As String, ByVal NORMAL1 As String, ByVal NORMALREST As String,
                                         ByVal HOLIDAY18 As String, ByVal HOLIDAY1 As String, ByVal HOLIDAYREST As String, ByVal ELIG_CWH As String, ByVal QUARTER As String) As Integer

        Dim oParam(28) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(IDX, String)

        oParam(1) = New SqlClient.SqlParameter("@EMPLID", SqlDbType.VarChar)
        oParam(1).Value = CType(EMPLID, String)

        oParam(2) = New SqlClient.SqlParameter("@FIRSTSIGNINDATE", SqlDbType.DateTime)
        oParam(2).Value = CType(FIRSTSIGNINDATE, DateTime)

        oParam(3) = New SqlClient.SqlParameter("@LASTSIGNOUTDATE", SqlDbType.DateTime)
        oParam(3).Value = CType(LASTSIGNOUTDATE, DateTime)

        oParam(4) = New SqlClient.SqlParameter("@MONTH", SqlDbType.VarChar)
        oParam(4).Value = CType(MONTH, String)

        oParam(5) = New SqlClient.SqlParameter("@TIMESIGNIN", SqlDbType.VarChar)
        oParam(5).Value = CType(TIMESIGNIN, String)

        oParam(6) = New SqlClient.SqlParameter("@TIMESIGNOUT", SqlDbType.VarChar)
        oParam(6).Value = CType(TIMESIGNOUT, String)

        oParam(7) = New SqlClient.SqlParameter("@DAYS", SqlDbType.VarChar)
        oParam(7).Value = CType(DAYS, String)

        oParam(8) = New SqlClient.SqlParameter("@TYPE_OF_DAYS", SqlDbType.VarChar)
        oParam(8).Value = CType(TYPE_OF_DAYS, String)

        oParam(9) = New SqlClient.SqlParameter("@ARRIVALSTAT", SqlDbType.VarChar)
        oParam(9).Value = CType(ARRIVALSTAT, String)

        oParam(10) = New SqlClient.SqlParameter("@TOTALWORKINGTIME", SqlDbType.VarChar)
        oParam(10).Value = CType(TOTALWORKINGTIME, String)

        oParam(11) = New SqlClient.SqlParameter("@WORKINGSTAT", SqlDbType.VarChar)
        oParam(11).Value = CType(WORKINGSTAT, String)

        oParam(12) = New SqlClient.SqlParameter("@ISOVERTIME", SqlDbType.VarChar)
        oParam(12).Value = CType(ISOVERTIME, String)

        oParam(13) = New SqlClient.SqlParameter("@OVERTIME", SqlDbType.VarChar)
        oParam(13).Value = CType(OVERTIME, String)

        oParam(14) = New SqlClient.SqlParameter("@WORKING", SqlDbType.VarChar)
        oParam(14).Value = CType(WORKING, String)

        oParam(15) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(15).Value = CType(CREATEDBY, String)

        oParam(16) = New SqlClient.SqlParameter("@DATEPROPIN", SqlDbType.DateTime)
        oParam(16).Value = CType(DATEPROPIN, DateTime)

        oParam(17) = New SqlClient.SqlParameter("@DATEPROPOUT", SqlDbType.DateTime)
        oParam(17).Value = CType(DATEPROPOUT, DateTime)

        oParam(18) = New SqlClient.SqlParameter("@PROPIN", SqlDbType.VarChar)
        oParam(18).Value = CType(PROPIN, String)

        oParam(19) = New SqlClient.SqlParameter("@PROPOUT", SqlDbType.VarChar)
        oParam(19).Value = CType(PROPOUT, String)

        oParam(20) = New SqlClient.SqlParameter("@REASON", SqlDbType.VarChar)
        oParam(20).Value = CType(REASON, String)

        oParam(21) = New SqlClient.SqlParameter("@WORKINGTIME", SqlDbType.VarChar)
        oParam(21).Value = CType(WORKINGTIME, String)

        oParam(22) = New SqlClient.SqlParameter("@NORMAL1", SqlDbType.VarChar)
        oParam(22).Value = CType(NORMAL1, String)

        oParam(23) = New SqlClient.SqlParameter("@NORMALREST", SqlDbType.VarChar)
        oParam(23).Value = CType(NORMALREST, String)

        oParam(24) = New SqlClient.SqlParameter("@HOLIDAY18", SqlDbType.VarChar)
        oParam(24).Value = CType(HOLIDAY18, String)

        oParam(25) = New SqlClient.SqlParameter("@HOLIDAY1", SqlDbType.VarChar)
        oParam(25).Value = CType(HOLIDAY1, String)

        oParam(26) = New SqlClient.SqlParameter("@HOLIDAYREST", SqlDbType.VarChar)
        oParam(26).Value = CType(HOLIDAYREST, String)

        oParam(27) = New SqlClient.SqlParameter("@ELIG_CWH", SqlDbType.VarChar)
        oParam(27).Value = CType(ELIG_CWH, String)

        oParam(28) = New SqlClient.SqlParameter("@QUARTER", SqlDbType.VarChar)
        oParam(28).Value = CType(QUARTER, String)

        Dim _connectionString As String = Conn
        Return DataAccess.ExecuteNonQuery(_connectionString, const_sp_UPDATE_ATTENDANCE, CommandType.StoredProcedure, oParam)

    End Function

    Public Function f_Update_Approved(ByVal EmployeeID As String, ByVal Years As String, ByVal Quarter As String,
                                      ByVal Submit As String, ByVal Email As String, ByVal Username As String, ByVal Remarks As String) As Integer

        Dim oParam(6) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EmployeeID", SqlDbType.VarChar)
        oParam(0).Value = CType(EmployeeID, String)

        oParam(1) = New SqlClient.SqlParameter("@Years", SqlDbType.VarChar)
        oParam(1).Value = CType(Years, String)

        oParam(2) = New SqlClient.SqlParameter("@Quarter", SqlDbType.VarChar)
        oParam(2).Value = CType(Quarter, String)

        oParam(3) = New SqlClient.SqlParameter("@Submit", SqlDbType.VarChar)
        oParam(3).Value = CType(Submit, String)

        oParam(4) = New SqlClient.SqlParameter("@Email", SqlDbType.VarChar)
        oParam(4).Value = CType(Email, String)

        oParam(5) = New SqlClient.SqlParameter("@Username", SqlDbType.VarChar)
        oParam(5).Value = CType(Username, String)

        oParam(6) = New SqlClient.SqlParameter("@Remarks", SqlDbType.VarChar)
        oParam(6).Value = CType(Remarks, String)

        Dim _connectionString As String = Conn
        Return DataAccess.ExecuteNonQuery(_connectionString, const_sp_UPDATE_APPROVAL_CWH, CommandType.StoredProcedure, oParam)

    End Function
End Class
