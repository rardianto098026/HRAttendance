<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Frm_Detail_Attendance_User.aspx.vb" Inherits="HR_Attedance.Frm_Detail_Attendance_User" %>
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
                  <asp:Label ID="lblEmployeeKey1" runat="server" Text="Employee ID"></asp:Label>
                  <asp:Label ID="lblEmployeeKey2" runat="server" style="margin-left:115px"></asp:Label>
              </td>
               <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
          </tr>
          <tr>
              <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
              <td class="style1" height="30" align ="left">
                  <asp:Label ID="lblEmployeeName1" runat="server" Text="Employee Name"></asp:Label>
                  <asp:Label ID="lblEmployeeName2" runat="server" style="margin-left:96px"></asp:Label>
              </td>
               <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
          </tr>
          <tr>
              <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
              <td class="style1" height="30" align ="left">
                  <asp:Label ID="lblEntity1" runat="server" Text="Entity"></asp:Label>
                  <asp:Label ID="lblEntity2" runat="server" style="margin-left:154px"></asp:Label>
              </td>
               <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
          </tr>
             <tr>
              <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
              <td class="style1" height="30" align ="left">
                  <asp:Label ID="lblAccessCardNo1" runat="server" Text="Access Card No."></asp:Label>
                  <asp:Label ID="lblAccessCardNo2" runat="server" style="margin-left:93px"></asp:Label>
              </td>
               <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
          </tr>
          <tr>
              <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
              <td class="style1" height="30" align ="left">
                  <asp:Label ID="lblFirstSignIn1" runat="server" Text="First Sign In Date"></asp:Label>
                  <asp:Label ID="txtFirstSignIn2" runat="server" style="margin-left:91px"></asp:Label>
                  <asp:Label ID="lblTimeSignIn1" runat="server" Text="First Sign In Time" style="margin-left:113px"></asp:Label>
                  <asp:Label ID="txtTimeSignIn2" runat="server" style="margin-left:22px"></asp:Label>
                  <b><asp:Label ID="lblTimeFormat" runat="server" Text="Format hh:mm" style="margin-left:21px"></asp:Label></b>
                    
              </td>
               <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
          </tr>
          <tr>
              <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
              <td class="style1" height="30" align ="left">
                  <asp:Label ID="lblSignOut1" runat="server" Text="Last Sign Out Date"></asp:Label>
                  <asp:Label ID="txtSignOut2" runat="server" style="margin-left:82px" AutoPostBack="true" OnTextChanged="txtSignOut2_TextChanged"></asp:Label>
                  <asp:Label ID="lblTimeSignOut" runat="server" Text="Last Sign Out Time" style="margin-left:114px"></asp:Label>
                  <asp:Label ID="txtTimeSignOut" runat="server" style="margin-left:13px" AutoPostBack="true" OnTextChanged="txtTimeSignOut_TextChanged"></asp:Label>  
                  <b><asp:Label ID="lblTimeFormat2" runat="server" Text="Format hh:mm" style="margin-left:20px"></asp:Label></b>
                   
              </td>
               <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
          </tr>
          <tr>
              <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
              <td class="style1" height="30" align ="left">
                  <asp:Label ID="lblMonth1" runat="server" Text="Month"></asp:Label>
                  <asp:Label ID="lblMonth2" runat="server" style="margin-left:149px"></asp:Label>
              </td>
               <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
          </tr>
          <tr>
              <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
              <td class="style1" height="30" align ="left">
                  <asp:Label ID="lblDays1" runat="server" Text="Days"></asp:Label>
                  <asp:Label ID="lblDays" runat="server" style="margin-left:155px"></asp:Label>
                  <asp:Label ID="lblTypeofDays1" runat="server" Text="Type Of Days" style="margin-left:126px"></asp:Label>
                  <asp:Label ID="lblTypeofDays2" runat="server" style="margin-left:19px"></asp:Label>
              </td>
               <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
          </tr>
          <tr>
              <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
              <td class="style1" height="30" align ="left">
                  <asp:Label ID="lblArrivalStatus1" runat="server" Text="Arrival Status"></asp:Label>
                  <asp:Label ID="lblArrivalStatus2" runat="server" style="margin-left:112px"></asp:Label>
              </td>
               <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
          </tr>
          <tr>
              <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
              <td class="style1" height="30" align ="left">
                  <asp:Label ID="lblTotalWorkingTime1" runat="server" Text="Total Working Time"></asp:Label>
                  <asp:Label ID="lblTotalWorkingTime2" runat="server" style="margin-left:78px"></asp:Label>
                  <asp:Label ID="lblWorkingStatus1" runat="server" Text="Working Status" style="margin-left:55px"></asp:Label>
                  <asp:Label ID="lblWorkingStatus2" runat="server" style="margin-left:10px"></asp:Label>
              </td>
               <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
          </tr>
          <tr>
              <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
              <td class="style1" height="30" align ="left">
                  <asp:Label ID="lblisOvertime1" runat="server" Text="IsOvertime"></asp:Label>
                  <asp:Label ID="lblisOvertime2" runat="server" style="margin-left:124px"></asp:Label>
                  <asp:Label ID="lblOvertime1" runat="server" Text="Overtime" style="margin-left:69px"></asp:Label>
                  <asp:Label ID="lblOvertime2" runat="server" style="margin-left:44px"></asp:Label>
              </td>
               <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
          </tr>
          <tr>
              <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
              <td class="style1" height="30" align ="left">
                  <asp:Label ID="LBL12Hours1" runat="server" Text=">12 hours of Working"></asp:Label>
                  <asp:Label ID="LBL12Hours2" runat="server" style="margin-left:68px"></asp:Label>
              </td>
               <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
          </tr>
          <tr>
              <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
              <td class="style1" height="30" align ="left">
                 
              </td>
               <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
          </tr>
          <tr>
              <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
              <td class="style1" height="30" align ="left">
                 <%--<asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClientClick="Confirm_Upload()" OnClick="Alert" />--%>
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
