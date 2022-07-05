<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Frm_Edit_Master_AccessCard.aspx.vb" Inherits="HR_Attedance.Frm_Edit_Master_AccessCard" %>

<%@ Register TagName="My" TagPrefix="Menu" Src="~/Menu/Menu.ascx" %>
<%@ Register TagName="My" TagPrefix="Head" Src="~/Menu/Header.ascx" %>
<%@ Register TagName="My" TagPrefix="Footer" Src="~/Menu/Footer.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/Surrounding.css" rel="stylesheet" />
<link rel="stylesheet" href="css/jquery-ui.css" />
<link rel="stylesheet" href="css/style.css" />
<script type="text/javascript" src="js/jquery-1.10.2.js"></script>
<script type="text/javascript" src="js/jquery-ui.js"></script>
<link rel="stylesheet" href="css/style.css" />
  <link rel="shortcut icon" href="Images/icon.ico" />
  <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
  <script type="text/javascript">
  
  function Confirm_Upload() {

        var confirm_value = document.createElement("INPUT");

        confirm_value.type = "hidden";

        confirm_value.name = "confirm_value";

        if (confirm("Do you want to upload the data?")) {

            confirm_value.value = "Yes";

        } else {

            confirm_value.value = "No";

        }

        document.forms[0].appendChild(confirm_value);
    }
   </script>
    <style type="text/css">
        .auto-style2 {
            height: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
         <table width="100%" align="center" cellpadding="0" cellspacing="0">
            <tr>
               
                <td align="left">
                 <Head:My ID="head" runat="server" />
                 </td>
               
            </tr>
            
            <tr>
                    <td align="left" bgcolor="#0055AA">
                        <Menu:My ID="My1" runat="Server" />
                    </td>
            </tr>
            
    </table>  
         <h1 align="center"> Edit Master Employee</asp:Label></h1>
        <br />

        
    <table width="1200px" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td background="Images/borderleft.gif" width="21" style="height: 13px">
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                       
                                              <td align ="left" class="auto-style2">
                                            Detail Employee
                                            </td>
                                       
                                    </tr>
                                    <tr>
                                        <td align ="right">
                                            
                                        </td>
                                        <td align ="left" height="20px">
                                          AccessCardNo <asp:Label ID="Label1" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                         <td align ="left" width="10px">
                                            :
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:TextBox ID="LblAccessCard" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                                            <%--<asp:Label ID="LblAccessCard" runat="server"></asp:Label>--%>
                                            &nbsp;
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td align ="right">
                                            
                                        </td>
                                        <td align ="left" height="20px">
                                            Employee ID <asp:Label ID="lblEmplID1" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                         <td align ="left" width="10px">
                                            :
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:TextBox ID="lblEmplID" runat="server" CssClass="textbox" Width="200px" ReadOnly="true"></asp:TextBox>
                                            <%--<asp:Label ID="lblEmplID" runat="server" Visible="true"></asp:Label>--%>
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td align ="right">
                                        </td>
                                        <td align ="left" height="20px">
                                          Employee Name <asp:Label ID="Label2" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                         <td align ="left" width="10px">
                                            :
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:TextBox ID="lblName" runat="server" CssClass="textbox" Width="200px" ReadOnly="true"></asp:TextBox>
                                            <%--<asp:Label ID="lblName" runat="server"></asp:Label>--%>
                                        </td>
                                        
                                    </tr> 
                                    <tr>
                                        <td align ="right">
                                        </td>
                                        <td align ="left" height="20px">
                                          Entity 
                                        </td>
                                         <td align ="left" width="10px">
                                            :
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:TextBox ID="lblEntity" runat="server" CssClass="textbox" Width="200px" ReadOnly="true"></asp:TextBox>
                                           <%-- <asp:Label ID="lblEntity" runat="server"></asp:Label>--%>
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td align ="right">
                                            
                                        </td>
                                        <td align ="left" height="20px">
                                          Location Name <asp:Label ID="Label7" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                         <td align ="left" width="10px">
                                            :
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:TextBox ID="lblLocationName" runat="server" CssClass="textbox" Width="200px" ReadOnly="true"></asp:TextBox>
                                            <%--<asp:Label ID="LblAccessCard" runat="server"></asp:Label>--%>
                                            &nbsp;
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td align ="right">
                                            
                                        </td>
                                        <td align ="left" height="20px">
                                            Employee Gender <asp:Label ID="Label8" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                         <td align ="left" width="10px">
                                            :
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:TextBox ID="lblEmployeeGender" runat="server" CssClass="textbox" Width="200px" ReadOnly="true"></asp:TextBox>
                                            <%--<asp:Label ID="lblEmplID" runat="server" Visible="true"></asp:Label>--%>
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td align ="right">
                                        </td>
                                        <td align ="left" height="20px">
                                          WorkerType <asp:Label ID="Label9" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                         <td align ="left" width="10px">
                                            :
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:TextBox ID="lblWorkerType" runat="server" CssClass="textbox" Width="200px" ReadOnly="true"></asp:TextBox>
                                            <%--<asp:Label ID="lblName" runat="server"></asp:Label>--%>
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td align ="right">
                                            &nbsp;</td>
                                        <td align ="left" height="20px">
                                            &nbsp;</td>
                                         <td align ="left" width="100px">
                                            
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:LinkButton ID="Submit" runat="server" Width="50px" >SUBMIT</asp:LinkButton>
                                            <asp:LinkButton ID="Back" runat="server" Width="50px" style="margin-left:8px; height: 15px;" >BACK</asp:LinkButton>
                                        
                                        </td>
                                          </tr>
                                    
                                 </table>
                                </td>
                                </tr>
                                    
                                </table>
        <br />
     
        <div style='height:200%;width:1200px;text-align:center;margin:0 auto';align="center" >
              </div>

        <br />
   
                <table width="1200px" align="center" cellpadding="0" cellspacing="0">
                
     
                </table>
                
              <br />
              <Footer:My ID="My3" runat="server" />
        
    </div>
    </form>
</body>
</html>
