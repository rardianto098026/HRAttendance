﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Frm_List_Detail_Admin.aspx.vb" Inherits="HR_Attedance.Frm_List_Detail_Admin" %>
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
         <h1 align="center"> List Attendance <asp:Label ID="lblYears" runat="server"></asp:Label></h1>
        <br />
    <table width="1200px" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td background="Images/borderleft.gif" width="21" style="height: 13px">
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                       
                                              <td align ="left" height="20px">
                                            SEARCH 
                                            </td>
                                       
                                    </tr>
                                    <tr>
                                        <td align ="right">
                                            
                                        </td>
                                        <td align ="left" height="20px" class="style2">
                                          AccessCardNo <asp:Label ID="Label1" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                         <td align ="left" width="10px">
                                            :
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:Label ID="LblAccessCard" runat="server"></asp:Label>
                                            &nbsp;
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td align ="right">
                                            
                                        </td>
                                        <td align ="left" height="20px" class="style2">
                                            Employee ID <asp:Label ID="lblEmplID1" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                         <td align ="left" width="10px">
                                            :
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:Label ID="lblEmplID" runat="server" Visible="true"></asp:Label>
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td align ="right">
                                        </td>
                                        <td align ="left" height="20px" class="style2">
                                          Employee Name <asp:Label ID="Label2" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                         <td align ="left" width="10px">
                                            :
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:Label ID="lblName" runat="server"></asp:Label>
                                        </td>
                                        
                                    </tr> <tr>
                                        <td align ="right">
                                        </td>
                                        <td align ="left" height="20px" class="style2">
                                          Entity 
                                        </td>
                                         <td align ="left" width="10px">
                                            :
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:Label ID="lblEntity" runat="server"></asp:Label>
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td align ="right">
                                            <asp:CheckBox ID="ChkUpdate" runat="server" Text="" TextAlign=left />
                                        </td>
                                        <td align ="left" height="20px" class="style2">
                                            Month <asp:Label ID="Label5" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                         <td align ="left" width="10px">
                                            :
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:Dropdownlist ID="ddlMonth" runat="server" CssClass="textbox"  OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Text="--Select--"></asp:ListItem> 
                                            <asp:ListItem Text="January" Value="1"></asp:ListItem> 
                                            <asp:ListItem Text="February" Value="2"></asp:ListItem> 
                                            <asp:ListItem Text="March" Value="3"></asp:ListItem> 
                                            <asp:ListItem Text="April" Value="4"></asp:ListItem> 
                                            <asp:ListItem Text="May" Value="5"></asp:ListItem> 
                                            <asp:ListItem Text="June" Value="6"></asp:ListItem> 
                                            <asp:ListItem Text="July" Value="7"></asp:ListItem> 
                                            <asp:ListItem Text="August" Value="8"></asp:ListItem> 
                                            <asp:ListItem Text="September" Value="9"></asp:ListItem> 
                                            <asp:ListItem Text="October" Value="10"></asp:ListItem> 
                                            <asp:ListItem Text="November" Value="11"></asp:ListItem> 
                                            <asp:ListItem Text="December" Value="12"></asp:ListItem> 
                                            <%--<asp:ListItem Text="Rejected"></asp:ListItem>--%> 
                                            <%--<asp:ListItem Text="Approved"></asp:ListItem>--%> 
                                            </asp:Dropdownlist>
                                            &nbsp; <asp:Label ID="Label6" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                            <b><asp:label runat="server" Visible="false" ID="lblDocCWH" Text="Document CWH Request" style="margin-left:20px"></asp:label></b>
                                            <b><asp:label runat="server" Visible="false" ID="Label3" Text="Quarter" style="margin-left:5px"></asp:label><asp:label runat="server" Visible="false" ID="lblQuarter" style="margin-left:5px"></asp:label></b>
                                            <b><asp:label runat="server" Visible="false" ID="Label4" Text=":" style="margin-left:4px"></asp:label></b>
                                            <b><asp:label runat="server" Visible="false" ID="lblStatusApproved" style="margin-left:5px"></asp:label></b>
                                       
                                        </td>
                                        
                                    </tr>
                                    
                                    
                                    <tr>
                                        <td align ="right">
                                            &nbsp;</td>
                                        <td align ="left" height="20px" class="style2">
                                            &nbsp;</td>
                                         <td align ="left" width="100px">
                                            
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:LinkButton ID="Search" runat="server" Width="50px" >SEARCH</asp:LinkButton>
                                            <asp:LinkButton ID="Export" runat="server" Width="50px" style="margin-left:8px; height: 15px;" >EXPORT</asp:LinkButton>
                                        
                                        </td>
                                          </tr>
                                    
                                 </table>
                                </td>
                                </tr>
                                    
                                </table>
        <br />
     <div style='height:200%;width:1200px;text-align:center;margin:0 auto';align="center" >
         <asp:Gridview ID="dg" runat="server" 
                            AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
                            BorderStyle="None" BorderWidth="1px" CellPadding="1" CssClass="tDatagridITReview" 
                            Height="200%" AllowSorting="True" PageSize="10" AllowPaging="true"
                            Width="1200px">
                            <HeaderStyle CssClass="GridHeader" ForeColor="White" Font-Bold="True" HorizontalAlign="Center" />
                            <FooterStyle BackColor="White" ForeColor="#000066"/>
                            <Columns>	
                                <asp:TemplateField  Visible="false" HeaderText="idx">
                                    <EditItemTemplate><asp:Label ID="txtIDX" runat="server" Visible="false" Text='<%# Eval("idx") %>'></asp:Label></EditItemTemplate><ItemTemplate><asp:Label ID="txtIDX" runat="server" Visible="false" Text='<%# Eval("idx") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle Width="1px"></HeaderStyle>
                                </asp:TemplateField>
                             
                                <asp:TemplateField HeaderText="Date">
                                    <EditItemTemplate><asp:Label ID="txtDate" runat="server" Text='<%# Eval("Dates") %>'></asp:Label></EditItemTemplate><ItemTemplate><asp:Label ID="lblDate" runat="server" Text='<%# Eval("Dates") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle Width="250px"></HeaderStyle>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="First Sign In">
                                    <EditItemTemplate><asp:Label ID="txtFirstSignIn" runat="server" Text='<%# Eval("INS") %>'></asp:Label></EditItemTemplate><ItemTemplate><asp:Label ID="lblFirstSignIn" runat="server" Text='<%# Eval("INS") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle Width="250px"></HeaderStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Sign Out">
                                    <EditItemTemplate><asp:Label ID="txtLastSignOut" runat="server" Text='<%# Eval("Outs") %>'></asp:Label></EditItemTemplate><ItemTemplate><asp:Label ID="lblLastSignOut" runat="server" Text='<%# Eval("Outs") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle Width="250px"></HeaderStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Date Proposed Sign In">
                                    <EditItemTemplate><asp:Label ID="txtDateTimePropSignIn" runat="server" Text='<%# Eval("DateTimeProposedIN") %>'></asp:Label></EditItemTemplate><ItemTemplate><asp:Label ID="lblDateTimePropSignIn" runat="server" Text='<%# Eval("DateTimeProposedIN") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle Width="250px"></HeaderStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Date Proposed Sign Out">
                                    <EditItemTemplate><asp:Label ID="txtDateTimePropSignOut" runat="server" Text='<%# Eval("DateTimeProposedOut") %>'></asp:Label></EditItemTemplate><ItemTemplate><asp:Label ID="lblDateTimePropSignOut" runat="server" Text='<%# Eval("DateTimeProposedOut") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle Width="250px"></HeaderStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Time Proposed In">
                                    <EditItemTemplate><asp:TextBox ID="txtProposedIn" runat="server" Text='<%# Eval("ProposedIn") %>'></asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="lblProposedIn" runat="server" Text='<%# Eval("ProposedIn") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle Width="250px"></HeaderStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Time Proposed Out">
                                    <EditItemTemplate><asp:TextBox ID="txtProposedOut" runat="server" Text='<%# Eval("ProposedOut") %>'></asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="lblProposedOut" runat="server" Text='<%# Eval("ProposedOut") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle Width="250px"></HeaderStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Reason">
                                    <EditItemTemplate><asp:TextBox ID="txtReason" runat="server" Text='<%# Eval("Reason") %>'></asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="lblReason" runat="server" Text='<%# Eval("Reason") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle Width="250px"></HeaderStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Status">
                                    <EditItemTemplate><asp:Label ID="txtStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label></EditItemTemplate><ItemTemplate><asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle Width="250px"></HeaderStyle>
                                </asp:TemplateField>
                                
                                
                                <asp:TemplateField HeaderText="Working Status">
                                    <EditItemTemplate><asp:Label ID="txtStatus2" runat="server" Text='<%# Eval("WorkingStatus") %>'></asp:Label></EditItemTemplate><ItemTemplate><asp:Label ID="lblStatus2" runat="server" Text='<%# Eval("WorkingStatus") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle Width="250px"></HeaderStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Eligibility CWH">
                                    <EditItemTemplate><asp:Label ID="txtElig" runat="server" Text='<%# Eval("Elig_CWH") %>'></asp:Label></EditItemTemplate><ItemTemplate><asp:Label ID="lblElig" runat="server" Text='<%# Eval("Elig_CWH") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle Width="250px"></HeaderStyle>
                                </asp:TemplateField>
                              <%--  <asp:TemplateField HeaderText="Day">
                                    <EditItemTemplate><asp:Label ID="txtDays" runat="server" Text='<%# Eval("Days") %>'></asp:Label></EditItemTemplate><ItemTemplate><asp:Label ID="lblDays" runat="server" Text='<%# Eval("Days") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle Width="80px"></HeaderStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Month">
                                    <EditItemTemplate><asp:Label ID="txtMonths" runat="server" Text='<%# Eval("Months") %>'></asp:Label></EditItemTemplate><ItemTemplate><asp:Label ID="lblMonths" runat="server" Text='<%# Eval("Months") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle Width="120px"></HeaderStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Arrival Status">
                                    <EditItemTemplate><asp:Label ID="txtArrivalStatus" runat="server" Text='<%# Eval("ArrivalStatus") %>'></asp:Label></EditItemTemplate><ItemTemplate><asp:Label ID="lblArrivalStatus" runat="server" Text='<%# Eval("ArrivalStatus") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle Width="270px"></HeaderStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Total working hours incl Lunch time">
                                    <EditItemTemplate><asp:Label ID="txtTotalWorkingTime" runat="server" Text='<%# Eval("TotalWorkingTime") %>'></asp:Label></EditItemTemplate><ItemTemplate><asp:Label ID="lblTotalWorkingTime" runat="server" Text='<%# Eval("TotalWorkingTime") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle Width="120px"></HeaderStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Working Time">
                                    <EditItemTemplate><asp:Label ID="txtWorkingTime" runat="server" Text='<%# Eval("WorkingTime") %>'></asp:Label></EditItemTemplate><ItemTemplate><asp:Label ID="lblWorkingTime" runat="server" Text='<%# Eval("WorkingTime") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle Width="80px"></HeaderStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Working Status">
                                    <EditItemTemplate><asp:Label ID="txtWorkingStatus" runat="server" Text='<%# Eval("WorkingStatus") %>'></asp:Label></EditItemTemplate><ItemTemplate><asp:Label ID="lblWorkingStatus" runat="server" Text='<%# Eval("WorkingStatus") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle Width="300px"></HeaderStyle>
                                </asp:TemplateField>--%>

                                <asp:TemplateField HeaderText="Action" ShowHeader="False"><EditItemTemplate><asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="True" 
                                         CommandName="Update" Text="Update"></asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                         CommandName="Cancel" Text="Cancel"></asp:LinkButton></EditItemTemplate><ItemTemplate><asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" 
                                         CommandName="Edit" Text="Edit"></asp:LinkButton></ItemTemplate></asp:TemplateField>
                         </Columns>     
                       </asp:Gridview>        
              </div>
        <br />
        <div style='width:1000px;text-align:center;margin:0 auto';align="center">
                    <asp:Panel ID="pnlfooter" runat="server">
                        <table id="tablepaging" runat="server" width="1000px">
                        <tr>
                            <td align="left" width="15px">
                                <asp:LinkButton ID="lbFirst" runat="server">First </asp:LinkButton>
                            </td>
                            <td align="left" width="10px">
                                <asp:LinkButton ID="lbPrev" runat="server">Prev </asp:LinkButton>
                            </td>
                            <td align="center" width="120px" valign="middle" >
                                <input type="text" class="textbox_2" runat="server" id="txtGO"/> OF 
                                <asp:Label ID="lblTotal" runat="server" Text="-"></asp:Label>
                                &nbsp; <asp:LinkButton ID="lnkGo" runat="server">GO </asp:LinkButton>
                            </td>
                            <td align="left" width="10px">
                                 <asp:LinkButton ID="lnkNext" runat="server">Next </asp:LinkButton>
                            </td>
                             <td align="left" width="10px">
                                 <asp:LinkButton ID="lnkLast" runat="server">Last </asp:LinkButton>
                            </td>
                            <td align="left">
                                &nbsp;&nbsp;Total Records : <asp:Label ID="lblTotalRecords" runat="server" Text="0 record(s)"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        
                    </table>
                   </asp:Panel>
                   
                   <table width="1200px" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    
                    <td height="30" >
                        Data per View :
                        <asp:DropDownList ID="ddl_View" runat="server" AutoPostBack="true">
                            <asp:ListItem>-- Choose --</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>50</asp:ListItem>
                            <asp:ListItem>70</asp:ListItem>
                            <asp:ListItem>100</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td background="Images/borderRight.gif" width="21" style="height: 13px">
                    </td>
                </tr>
                
        </table>
                </div> 
   
                <table width="1200px" align="center" cellpadding="0" cellspacing="0">
                
     
                </table>
                
              <br />
              <Footer:My ID="My3" runat="server" />
        
    </div>
    </form>
</body>
</html>