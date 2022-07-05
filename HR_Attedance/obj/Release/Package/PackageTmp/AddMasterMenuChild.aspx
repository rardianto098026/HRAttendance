<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddMasterMenuChild.aspx.vb" Inherits="HR_Attedance.AddMasterMenuChild" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagName="My" TagPrefix="Menu" Src="~/Menu/Menu.ascx" %>
<%@ Register TagName="My" TagPrefix="Head" Src="~/Menu/Header.ascx" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
  <link rel="shortcut icon" href="Images/icon.ico" />
  <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>

</head>
<body onbeforeUnload="bodyUnload();" onclick="clicked=true;" oncontextmenu="return false">
    <form id="form1" runat="server">
    <div>
        <table width="1200px" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td background="Images/borderleft.gif" width="21">
                </td>
                <td align="center">
                 <Head:My ID="head" runat="server" />
                 </td>
                <td background="Images/borderRight.gif" width="21">
                </td>
            </tr>
            <tr>
                 <td width="21px" background="Images/borderleft.gif">
                    </td>
                    <td align="left" bgcolor="#0055AA">
                        <Menu:My ID="menu1" runat="Server" />
                    </td>
                    <td width="21px" background="Images/borderRight.gif">
                    </td>
            </tr>
            <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="10">
                        &nbsp;</td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Menu Child Name&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <asp:Label ID="lblErr_Upload" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                        <asp:TextBox ID="txtMenuChildName" runat="server"></asp:TextBox>
                        </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Path &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtPath" runat="server"></asp:TextBox>
                        </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              
                <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Menu Master Name&nbsp;&nbsp; 
                         &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp;<asp:Label ID="Label1" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                        <asp:DropDownList ID="ddl_Mst_Menu" runat="server">
                        </asp:DropDownList>
                        </td>
                   
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr> 
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                       &nbsp; &nbsp;
                        </td>
                    <td background="Images/borderRight.gif" width="21">&nbsp;</td>
              </tr>
              
                </table>
                <table width="1200px" align="center" cellpadding="0" cellspacing="0">
                
     
                </table>
               <table id="Table4" runat="server" height="2px"  width="792px" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="background-color:#0055AA" align="center">
                            <asp:label ID="lbl2" runat="server" Text="© PT. AXA SERVICES INDONESIA – 2015, All right reserved" ForeColor="White"></asp:label>

                            </td>
                        </tr>
                    </table>
        
    </div>
    </form>
</body>
</html>