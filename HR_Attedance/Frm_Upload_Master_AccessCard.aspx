<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Frm_Upload_Master_AccessCard.aspx.vb" Inherits="HR_Attedance.Frm_Upload_Master_AccessCard" %>


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
        .auto-style3 {
            height: 22px;
        }
        .auto-style4 {
            width: 695px;
            height: 22px;
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
         <h1 align="center">Upload Master Employee</asp:Label></h1>
        <br />

     
                </div> 
   
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
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                        Upload Master Data Employee
                        &nbsp;
                        </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                        Attach File : <asp:FileUpload ID="txtUpload" runat="server" CssClass="textbox" Width="450px" /> 
                        &nbsp; <asp:Label ID="lblErr_Upload" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                        </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
                
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="Confirm_Upload()" OnClick="Alert"/>
                       &nbsp; &nbsp;
                        <asp:Button ID="btnBack" runat="server" Text="Back" />
                    </td>
                    <td background="Images/borderRight.gif" width="21">&nbsp;</td>
              </tr>

              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        
                    </td>
                    <td background="Images/borderRight.gif" width="21">&nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        
                    </td>
                    <td background="Images/borderRight.gif" width="21">&nbsp;</td>
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
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                        Upload Mapping Employee Manager
                        &nbsp;
                        </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21" class="auto-style3">
                        </td>
                    <td class="auto-style4" align ="left">
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                        Attach File : <asp:FileUpload ID="txtUpload1" runat="server" CssClass="textbox" Width="450px" /> 
                        &nbsp; <asp:Label ID="lblErr_Upload1" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                        </td>
                    <td background="Images/borderRight.gif" width="21" class="auto-style3">
                        </td>
              </tr>
                
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Button ID="btnSubmit1" runat="server" Text="Submit" OnClientClick="Confirm_Upload()" OnClick="Alert1"/>
                       &nbsp; &nbsp;
                        <asp:Button ID="btnBack1" runat="server" Text="Back" />
                    </td>
                    <td background="Images/borderRight.gif" width="21">&nbsp;</td>
              </tr>

              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        
                    </td>
                    <td background="Images/borderRight.gif" width="21">&nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        
                    </td>
                    <td background="Images/borderRight.gif" width="21">&nbsp;</td>
              </tr>
              
                </table>
                
              <br />
              <Footer:My ID="My3" runat="server" />
        
    </form>
</body>
</html>
