Public Class Header
    Inherits System.Web.UI.UserControl
    Dim oUpdate As New UpdateBase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("UserID").ToString = "Administrator" Then
                lblGreet.Text = Session("UserID").ToString
                LBLEmplNumber.Text = Session("EMPLNUMBER")
            Else
                lblGreet.Text = Session("UserID").ToString
                LBLEmplNumber.Text = Session("EMPLNUMBER")
            End If

            If Session("ShortEntity") = "AMFS" Then
                imgAXA.Src = "mandiri-axa.png"
            ElseIf Session("ShortEntity") = "AFI" Then
                imgAXA.Src = "AXA-Banner.png"
            ElseIf Session("ShortEntity") = "ASI" Then
                imgAXA.Src = "AXA-Banner.png"
            ElseIf Session("ShortEntity") = "MAGI" Then
                imgAXA.Src = "mandiri-axa.png"
            ElseIf Session("ShortEntity") = "ALI" Then
                imgAXA.Src = "AXA-Banner.png"
            ElseIf Session("ShortEntity") = "AAMI" Then
                imgAXA.Src = "AXA-Banner.png"
            End If


        Catch ex As Exception
            Response.Redirect("Frm_ErrorHandler.aspx")
        End Try
    End Sub

    Protected Sub LogOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles LogOut.Click
        oUpdate.f_UpdateLogout(Session("UserID").ToString, Session("Entity"))
        Session.Remove("UserID")
        Session.Remove("Entity")
        Session.Remove("dtSelectReport")
        Session.Remove("dtSelectExportUser")
        Session.Remove("ShortEntity")
        Session.Remove("UserName")
        Session.Remove("EMPLNUMBER")
        Session.Remove("Role")
        Session.Remove("_idx")
        Session.Remove("dtSelect")
        Session.Remove("YearAttendance")
        Response.Redirect("Login.aspx")

    End Sub
End Class