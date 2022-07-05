Public Class Frm_Error_Handler
    Inherits System.Web.UI.Page

    Dim oUpdate As New UpdateBase
    Protected Sub LogOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles LogOut.Click
        If Not Session("UserID") Is Nothing And Not Session("UserID") Is Nothing Then
            oUpdate.f_UpdateLogout(Session("UserID").ToString, Session("Entity"))
            Session.Remove("Entity")
            Session.Remove("UserID")
        End If

        If Not Session("UserName") Is Nothing Then
            Session.Remove("UserName")
        End If
        If Not Session("EMPLNUMBER") Is Nothing Then
            Session.Remove("EMPLNUMBER")
        End If
        If Not Session("Role") Is Nothing Then
            Session.Remove("Role")
        End If
        If Not Session("_idx") Is Nothing Then
            Session.Remove("_idx")
        End If

        Response.Redirect("Login.aspx")
    End Sub
End Class