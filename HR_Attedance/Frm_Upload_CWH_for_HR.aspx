<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Frm_List_Doc_CWH_for_HR.aspx.vb" Inherits="HR_Attedance.Frm_List_Doc_CWH_for_HR" %>
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
            $('html').bind('keypress', function (e) {
                if (e.keyCode == 13) {
                    return false;
                }
            });
    </script>
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
        .auto-style1 {
            height: 20px;
        }
        .auto-style2 {
            width: 127px;
        }
        .auto-style3 {
            height: 20px;
            width: 127px;
        }
        .auto-style4 {
            margin-left: 0px;
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
         <h1 align="center"> List History CWH </h1>
        <br />
    <table width="1200px" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td background="Images/borderleft.gif" width="21" style="height: 13px">
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                       
                                              <td align ="left" height="20px" class="auto-style2">
                                            SEARCH 
                                            </td>
                                       
                                    </tr>
                                    <tr>
                                        <td align ="right" class="auto-style3">
                                            <asp:CheckBox ID="ChkEmployee" runat="server" Text="" TextAlign=left />
                                        </td>
                                        <td align ="left" width="130px" class="auto-style1">
                                          Employee Name <asp:Label ID="Label2" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                         <td align ="left" width="10px" class="auto-style1">
                                            :
                                        </td>
                                        <td width="75%"  align ="left" class="auto-style1">
                                            <asp:DropDownList ID="txtEmplName" runat="server" Width="300px"></asp:DropDownList>
                                            &nbsp; <asp:Label ID="Label5" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td align ="right" class="auto-style2">
                                            <asp:CheckBox ID="chkAccess" runat="server" Text="" TextAlign=left />
                                        </td>
                                        <td align ="left" height="20px" class="style2">
                                          Year <asp:Label ID="Label1" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                         <td align ="left" width="10px">
                                            :
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:DropDownList ID="ddlYear" runat ="server" CssClass="auto-style4">
                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="2018" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="2019" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="2020" Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                            &nbsp; <asp:Label ID="lblErrAccessCard" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td align ="right" class="auto-style3">
                                            <asp:CheckBox ID="CheckBox1" runat="server" Text="" TextAlign=left />
                                        </td>
                                        <td align ="left" class="auto-style1">
                                          Quarter <asp:Label ID="Label3" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                         <td align ="left" width="10px" class="auto-style1">
                                            :
                                        </td>
                                        <td width="75%"  align ="left" class="auto-style1">
                                            <asp:DropDownList ID="ddlQuarter" runat ="server">
                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Q1" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Q2" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Q3" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="Q4" Value="4"></asp:ListItem>
                                            </asp:DropDownList>  
                                            &nbsp; <asp:Label ID="Label4" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                        
                                    </tr>
                                    
                                    
                                    <tr>
                                        <td align ="right" class="auto-style2">
                                            &nbsp;</td>
                                        <td align ="left" height="20px" class="style2">
                                            &nbsp;</td>
                                         <td align ="left" width="100px">
                                            
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:LinkButton ID="Search" runat="server" Width="50px" >SEARCH</asp:LinkButton>
                                            <asp:LinkButton ID="eXPORT" runat="server" Style="margin-left:20px" Width="50px"> EXPORT </asp:LinkButton>
                                            <asp:LinkButton ID="Back" runat="server" STYLE="margin-left:20px" Width="50px" >BACK</asp:LinkButton>
                                            
                                        </td>
                                          </tr>
                                    
                                 </table>
                                </td>
                                </tr>
                                    
                                </table>
        <br />
     <div style='height:200%;width:1200px;text-align:center;margin:0 auto';align="center" >
                 <asp:DataGrid ID="dgRekeningKoran" runat="server" 
                            AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
                            BorderStyle="None" BorderWidth="1px" CellPadding="1" CssClass="tDatagridITReview" 
                            Height="200%" AllowSorting="True" PageSize="10" AllowPaging="true"
                            Width="1000px">
                            <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <AlternatingItemStyle CssClass="GridAltITReview" />
                            <ItemStyle CssClass="GridItemITReview" ForeColor="Black" HorizontalAlign="Center" />
                            <HeaderStyle CssClass="GridHeader" ForeColor="White" Font-Bold="True" HorizontalAlign="Center" />
                            <FooterStyle BackColor="White" ForeColor="#000066"/>
                            <Columns>	
                                <%--<asp:BoundColumn  DataField="UserName" HeaderText="Employee Name" HeaderStyle-Width="70px" SortExpression="UserName ASC" Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundColumn>--%>
                                <asp:BoundColumn  DataField="EmployeeName" HeaderText="Employee Name" HeaderStyle-Width="70px" SortExpression="EmployeeName ASC" Visible="true">
                                <HeaderStyle Width="120px"></HeaderStyle>
                                </asp:BoundColumn>

                                <asp:BoundColumn  DataField="Year" HeaderText="Year" HeaderStyle-Width="70px" SortExpression="Year ASC" Visible="true">
                                <HeaderStyle Width="70px"></HeaderStyle>
                                </asp:BoundColumn>

                                
                                <asp:BoundColumn  DataField="Quarter" HeaderText="Quarter" HeaderStyle-Width="70px" SortExpression="Quarter ASC" Visible="true">
                                <HeaderStyle Width="70px"></HeaderStyle>
                                </asp:BoundColumn>
                                
                                <asp:BoundColumn  DataField="StatusApproval" HeaderText="Status Approval" HeaderStyle-Width="70px" SortExpression="StatusApproval ASC" Visible="true">
                                <HeaderStyle Width="120px"></HeaderStyle>
                                </asp:BoundColumn>
                                
                                <asp:TemplateColumn HeaderStyle-Width="5px" HeaderText="Attachment">
                                     <ItemTemplate>
                                        <asp:LinkButton ID="ibtnEdit" runat="server" CommandName="cmdEdit" Text='<%# (Convert.ToString(DataBinder.Eval(Container.DataItem, "FileName")))%>' ></asp:LinkButton>
<%--                                        <asp:ImageButton ID="ibtnEdit" runat="server" CommandName="cmdEdit"
                                            ImageUrl="~/images/Edit.jpg" Width="20px"/>--%>
                                    </ItemTemplate>
                                </asp:TemplateColumn>

                                <asp:BoundColumn  DataField="Remarks" HeaderText="Remarks" HeaderStyle-Width="70px" SortExpression="Remarks ASC" Visible="true">
                                <HeaderStyle Width="120px"></HeaderStyle>
                               </asp:BoundColumn>
                                	
                               
                                	
                               <asp:BoundColumn  DataField="ENTITY" HeaderText="ENTITY" HeaderStyle-Width="70px" SortExpression="ENTITY ASC" Visible="false">
                                <HeaderStyle Width="120px"></HeaderStyle>
                               </asp:BoundColumn>
                                	
                               <asp:BoundColumn  DataField="FileName" HeaderText="FileName" HeaderStyle-Width="70px" SortExpression="FileName ASC" Visible="false">
                                <HeaderStyle Width="120px"></HeaderStyle>
                               </asp:BoundColumn>
                                	
                               <asp:BoundColumn  DataField="Date" HeaderText="Date" HeaderStyle-Width="70px" SortExpression="Date ASC" Visible="true">
                                <HeaderStyle Width="120px"></HeaderStyle>
                               </asp:BoundColumn>

                                <asp:BoundColumn  DataField="EmployeeID" HeaderText="EmployeeID" HeaderStyle-Width="70px" SortExpression="EmployeeID ASC" Visible="false">
                                <HeaderStyle Width="120px"></HeaderStyle>
                                </asp:BoundColumn>
                                               
                           </Columns>
                           <PagerStyle CssClass="GridPaging" HorizontalAlign="Left" Visible="False" />
                       </asp:DataGrid>
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