Imports System.Web.SessionState

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup

    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown

        Dim oUpdate As New UpdateBase
        'oUpdate.f_UpdateLogout(Session("UserID").ToString, Session("Entity"))
        oUpdate.f_UpdateLogout(Session("UserID").ToString, Session("Entity"))

        'Session.Remove("UserID")
        'Session.Remove("Entity")
        'Session.Remove("UserName")
        'Session.Remove("EMPLNUMBER")
        'Session.Remove("Role")
        'Session.Remove("_idx")
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
        Response.Redirect("Frm_ErrorHandler.aspx")
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.

        Dim oUpdate As New UpdateBase
        oUpdate.f_UpdateLogout(Session("UserID").ToString, Session("Entity"))
        'Session.Remove("UserID")
        'Session.Remove("Entity")
        'Session.Remove("UserName")
        'Session.Remove("EMPLNUMBER")
        'Session.Remove("Role")
        'Session.Remove("_idx")
    End Sub

End Class