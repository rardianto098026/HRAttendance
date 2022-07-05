<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Frm_Approval_Reject_CWH.aspx.vb" Inherits="HR_Attedance.Frm_Approval_Reject_CWH" %>
<%@ Register TagName="My" TagPrefix="Menu" Src="~/Menu/Menu.ascx" %>
<%@ Register TagName="My" TagPrefix="Head" Src="~/Menu/Header.ascx" %>
<%@ Register TagName="My" TagPrefix="Footer" Src="~/Menu/Footer.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
  <link href="Surrounding.css" rel="stylesheet" type="text/css"/>
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

        if (confirm("Do you want to Approved the data?")) {

            confirm_value.value = "Yes";

        } else {

            confirm_value.value = "No";

        }

        document.forms[0].appendChild(confirm_value);
    }
   </script>
<script type="text/javascript">
  
  function Confirm_Upload2() {

        var confirm_value2 = document.createElement("INPUT");

        confirm_value2.type = "hidden";

        confirm_value2.name = "confirm_value2";

        if (confirm("Do you want to Rejected the data?")) {

            confirm_value2.value = "Yes";

        } else {

            confirm_value2.value = "No";

        }

        document.forms[0].appendChild(confirm_value2);
    }
   </script>
    <style type="text/css">
        .auto-style1 {
            height: 30px;
        }
        .auto-style2 {
            width: 695px;
            height: 30px;
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
	<table width="1200px" align="center" cellpadding="0" cellspacing="0">
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
                        <asp:Label ID="lblRole" runat="server" style="margin-left:0px" Visible="false"></asp:Label> 
                        <asp:Label ID="lblEntity2" runat="server" style="margin-left:45px" Visible="false"></asp:Label>    
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                        <asp:Label ID="Label1" runat="server">Employee ID</asp:Label>    
                        <asp:Label ID="lblEmplID" runat="server" style="margin-left:55px"></asp:Label>    
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                        <asp:Label ID="Label2" runat="server">Employee Name</asp:Label>    
                        <asp:Label ID="lblEmplName" runat="server" style="margin-left:32px"></asp:Label>    
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr> 
              <tr>
                    <td background="Images/borderleft.gif" width="21" class="auto-style1">
                        </td>
                    <td class="auto-style2" align ="left">
                        <asp:Label ID="Label3" runat="server">Entity</asp:Label>    
                        <asp:Label ID="lblEntity" runat="server" style="margin-left:94px"></asp:Label>    
                    </td>
                    <td background="Images/borderRight.gif" width="21" class="auto-style1">
                        </td>
              </tr> 
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                        <asp:Label ID="Label4" runat="server">Email</asp:Label>    
                        <asp:Label ID="lblEmail" runat="server" style="margin-left:91px"></asp:Label>    
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr> 
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                        <asp:Label ID="Label7" runat="server">Year</asp:Label>    
                        <asp:Label ID="lblYear" runat="server" style="margin-left:97px"></asp:Label>    
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                        <asp:Label ID="Label9" runat="server">Quarter</asp:Label>    
                        <asp:Label ID="lblQuarter" runat="server" style="margin-left:81px"></asp:Label>    
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                        <asp:Label ID="Label5" runat="server">Document CWH</asp:Label>    
                        <asp:LinkButton ID="LinkDwn1" runat="server" STYLE="margin-left:8px" Visible="true"></asp:LinkButton>
                         
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>

                <tr>
                            <td background="Images/borderleft.gif" width="21">
                                &nbsp;</td>
                            <td class="style1" height="30" align ="left">
                                <asp:Label ID="Label6" runat="server">Remarks</asp:Label>    
                                <asp:TextBox  runat="server" ID="txtRemarks" STYLE="margin-left:70px" Height="62px" Width="291px" ></asp:TextBox>
                            </td>
                            <td background="Images/borderRight.gif" width="21">
                                &nbsp;</td>
                      </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Button ID="btnSubmit" runat="server" Text="Approved" OnClientClick="Confirm_Upload()" OnClick="Alert"/>
                       &nbsp; &nbsp;
                        <asp:Button ID="btnReject" runat="server" Text="Reject" OnClientClick="Confirm_Upload2()" OnClick="Alert2"/>
                       &nbsp; &nbsp;
                        <asp:Button ID="btnBack" runat="server" Text="Back" />
                    </td>
                    <td background="Images/borderRight.gif" width="21">&nbsp;</td>
              </tr>
              
                </table>
                <table width="1200px" align="center" cellpadding="0" cellspacing="0">
                
     
                </table>
                
              <br />
              <Footer:My ID="My3" runat="server" />
        
    </div>
    </form>
</body>
</html>