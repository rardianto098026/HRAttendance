<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Frm_Add_Line_Manager.aspx.vb" Inherits="HR_Attedance.Frm_Add_Line_Manager" %>

<%@ Register TagName="My" TagPrefix="Menu" Src="~/Menu/Menu.ascx" %>
<%@ Register TagName="My" TagPrefix="Head" Src="~/Menu/Header.ascx" %>
<%@ Register TagName="My" TagPrefix="Footer" Src="~/Menu/Footer.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
            $(document).ready(function () {
                $('#txtFirstSignIn2').datepicker({
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    showStatus: true,
                    showWeeks: true,
                    currentText: 'Now',
                    autoSize: true,
                    gotoCurrent: true,
                    showAnim: 'blind',
                    highlightWeek: true
                });
            });
</script>
<script type="text/javascript">
            $(document).ready(function () {
                $('#txtSignOut2').datepicker({
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    showStatus: true,
                    showWeeks: true,
                    currentText: 'Now',
                    autoSize: true,
                    gotoCurrent: true,
                    showAnim: 'blind',
                    highlightWeek: true
                });
            });
</script>
    <script type="text/javascript">

        function Confirm_Upload() {

            var confirm_value = document.createElement("INPUT");

            confirm_value.type = "hidden";

            confirm_value.name = "confirm_value";

            if (confirm("Do You Want to Submit Data?")) {

                confirm_value.value = "Yes";

            } else {

                confirm_value.value = "No";

            }

            document.forms[0].appendChild(confirm_value);
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
        .auto-style3 {
            height: 13px;
        }
        .auto-style4 {
            width: 695px;
            height: 13px;
        }
        .auto-style5 {
            width: 695px;
            height: 47px;
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
         <table width="100%" align="center" cellpadding="0" cellspacing="0">
          <tr>
              <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
              <td class="style1" height="30" align ="left">
                  <asp:Label ID="EmplIDManager" runat="server" Text="Employee ID Manager"></asp:Label>
                  <asp:TextBox ID="EmplIDManager2" runat="server" style="margin-left:63px" Width="300px" ReadOnly="true"></asp:TextBox>
              </td>
               <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
          </tr>
          <tr>
              <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
              <td class="style1" height="30" align ="left">
                  <asp:Label ID="EmplNameManager" runat="server" Text=" Manager Name"></asp:Label>
                  <asp:DropDownList ID="EmplNameManager2" runat="server" style="margin-left:98px" Width="304px" AutoPostBack="True" OnSelectedIndexChanged="ddl_Manager_SelectedIndexChanged"></asp:DropDownList>
                  <%--<asp:TextBox ID="EmplNameManager2" runat="server" style="margin-left:98px" Width="300"></asp:TextBox>--%>
                  
              </td>
               <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
          </tr>
             <tr>
              <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
              <td class="style1" height="30" align ="left">
                  <asp:Label ID="lblEmailManager" runat="server" Text="Email Manager"></asp:Label>
                  <asp:TextBox ID="EmailManager2" runat="server" style="margin-left:100px" Width="300px" ReadOnly="true"></asp:TextBox>
              </td>
               <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
          </tr>
             <tr>
              <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
              <td class="style1" height="30" align ="left">
                  <asp:Label ID="lblEmployeeID" runat="server" Text="Employee ID"></asp:Label>
                  <asp:Label ID="lblEmployeeID2" runat="server" style="margin-left:110px"></asp:Label>
              </td>
               <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
          </tr>
          <tr>
              <td background="Images/borderleft.gif" width="21" class="auto-style3">
                        </td>
              <td class="auto-style4" align ="left">
                  <asp:Label ID="lblEmployeeName" runat="server" Text="Employee Name"></asp:Label>
                  <asp:Label ID="lblEmployeeName2" runat="server" style="margin-left:89px"></asp:Label>
              </td>
               <td background="Images/borderRight.gif" width="21" class="auto-style3">
                        </td>
          </tr>
             <tr>
              <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
              <td class="auto-style5" height="30" align ="left">
                  <asp:Label ID="LblEmail" runat="server" Text="Email"></asp:Label>
                  <asp:Label ID="Email2" runat="server" style="margin-left:148px"></asp:Label>
              </td>
               <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
          </tr>
          <tr>
              <td background="Images/borderleft.gif" width="21" class="auto-style1">
                        </td>
              <td class="auto-style2" align ="left">
                  <asp:Label ID="lblEntity" runat="server" Text="Entity"></asp:Label>
                  <asp:Label ID="lblEntity2" runat="server" style="margin-left:148px"></asp:Label>
              </td>
               <td background="Images/borderRight.gif" width="21" class="auto-style1">
                        </td>
          </tr>
             <tr>
              <td background="Images/borderleft.gif" width="21" class="auto-style1">
                        </td>
              <td class="auto-style2" align ="left">
                  <asp:Label ID="lblWorkerType" runat="server" Text="Worker Type"></asp:Label>
                  <asp:Label ID="lblWorkerType2" runat="server" style="margin-left:110px"></asp:Label>
              </td>
               <td background="Images/borderRight.gif" width="21" class="auto-style1">
                        </td>
          </tr>

          
          <tr>
              <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
              <td class="style1" height="30" align ="left">
                 <%--<asp:Button runat="server" ID="Button1" Text="Submit" OnClientClick="Confirm_Upload()" OnClick="Alert" />
                 <asp:Button runat="server" ID="Button2"  Text="Back" style="margin-left:15px"/>--%>
              </td>
               <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
          </tr>
          <tr>
              <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
              <td class="style1" height="30" align ="left">
                 <asp:Button runat="server" ID="btnSubmit" Text="Submit" />
                 <%--<asp:Button runat="server" ID="Button1" Text="Submit" OnClientClick="Confirm_Upload()" OnClick="Alert" />--%>
                 <asp:Button runat="server" ID="btnBack"  Text="Back" style="margin-left:15px"/>
              </td>
               <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
          </tr>
          </table>
            
              <Footer:My ID="My3" runat="server" />
        
            </div>
    </form>
</body>
</html>

