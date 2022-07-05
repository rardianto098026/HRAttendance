<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Frm_List_Detail_Attendance_For_Manager.aspx.vb" Inherits="HR_Attedance.Frm_List_Detail_Attendance_For_Manager" %>
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
    <script type="text/javascript">
            $(document).ready(function () {
                $('#txtDate').datepicker({
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
         <h1 align="center"> List Attendance <asp:Label ID="lblName" runat="server"></asp:Label> <asp:Label ID="lblYears" runat="server" style="margin-left:10px"></asp:Label></h1>
        <asp:Label ID="lbEmplID" runat="server" Visible="false"></asp:Label>
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
                                            <asp:CheckBox ID="chkAccess" runat="server" Text="" TextAlign=left />
                                        </td>
                                        <td align ="left" height="20px" class="style2">
                                          Date <asp:Label ID="Label1" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                         <td align ="left" width="10px">
                                            :
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:TextBox ID="txtDate" runat="server" CssClass="textbox"></asp:TextBox>
                                            &nbsp; <asp:Label ID="lblErrDate" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                        
                                    </tr>
                                     <tr>
                                        <td align ="right">
                                            <asp:CheckBox ID="chkQuarter" runat="server" Text="" TextAlign=left />
                                        </td>
                                        <td align ="left" height="20px" class="style2">
                                          Quarter <asp:Label ID="Label4" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                         <td align ="left" width="10px">
                                            :
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:DropDownList runat="server" ID="ddlQuarter" AutoPostBack="true" OnSelectedIndexChanged="ddlQuarter_SelectedIndexChanged">
                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Q1" Value="Q1"></asp:ListItem>
                                                <asp:ListItem Text="Q2" Value="Q2"></asp:ListItem>
                                                <asp:ListItem Text="Q3" Value="Q3"></asp:ListItem>
                                                <asp:ListItem Text="Q4" Value="Q4"></asp:ListItem>
                                            </asp:DropDownList>
                                            &nbsp; <asp:Label ID="Label7" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
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
                                            <asp:Dropdownlist ID="ddlMonth" runat="server" CssClass="textbox" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" AutoPostBack="true">
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
                                            </asp:Dropdownlist>
                                            &nbsp; <asp:Label ID="Label6" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                            
                                        </td>
                                        <td>
                                            
                                            
                                            
                                            
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align ="right">
                                            
                                        </td>
                                        <td align ="left" height="20px" class="style2">
                                           <font size="2px"><b><asp:label runat="server" Visible="false" ID="lblDocCWH" Text="CWH Status" ></asp:label></b></font>
                                        </td>
                                         <td align ="left" width="10px">
                                            
                                        </td>
                                        <td width="75%"  align ="left">
                                           
                                            <b><asp:label runat="server" Visible="false" ID="Label2" Text="Quarter" style="margin-left:0px"></asp:label><asp:label runat="server" Visible="false" ID="lblQuarter" style="margin-left:5px"></asp:label></b>
                                            <b><asp:label runat="server" Visible="false" ID="Label3" Text=":" style="margin-left:4px"></asp:label></b>
                                            <b><asp:label runat="server" Visible="false" ID="lblStatusApproved" style="margin-left:5px"></asp:label></b>
                                        </td>
                                        <td>
                                            
                                            
                                            
                                            
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
     <div style='height:100%;width:1200px;text-align:center;margin:0 auto';align="center" >
                 <asp:DataGrid ID="dgRekeningKoran" runat="server" 
                            AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
                            BorderStyle="None" BorderWidth="1px" CellPadding="1" CssClass="tDatagridITReview" 
                            Height="100%" AllowSorting="True" PageSize="10" AllowPaging="true"
                            Width="1200px">
                            <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <AlternatingItemStyle CssClass="GridAltITReview" />
                            <ItemStyle CssClass="GridItemITReview" ForeColor="Black" HorizontalAlign="Center" />
                            <HeaderStyle CssClass="GridHeader" ForeColor="White" Font-Bold="True" HorizontalAlign="Center" />
                            <FooterStyle BackColor="White" ForeColor="#000066"/>
                            <Columns>	
                                <asp:TemplateColumn HeaderStyle-Width="10px" HeaderText="DETAIL">
                                     <ItemTemplate>
                                        
                                        <asp:ImageButton ID="ibtnEdit" runat="server" CommandName="cmdEdit"
                                            ImageUrl="~/images/Edit.jpg" Width="20px"/>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                	
                                <asp:BoundColumn  DataField="idx" HeaderText="idx" HeaderStyle-Width="1px" SortExpression="idx ASC" Visible="False">
                                <HeaderStyle Width="1px"  HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundColumn>

                                <asp:BoundColumn  DataField="Dates" HeaderText="Date" HeaderStyle-Width="50px" SortExpression="Dates ASC" Visible="TRUE">
                                <HeaderStyle Width="50px"></HeaderStyle>
                                </asp:BoundColumn>
                               
                               
                               <%-- <asp:BoundColumn  DataField="EmployeeID" HeaderText="Employee ID" HeaderStyle-Width="150px" SortExpression="EmployeeID ASC" Visible="true">
                                <HeaderStyle Width="50px"></HeaderStyle>
                                </asp:BoundColumn>
                               
								<asp:BoundColumn  DataField="EmployeeName" HeaderText="Employee Name" HeaderStyle-Width="30px" SortExpression="EmployeeName ASC" Visible="true">
                                <HeaderStyle Width="30px"></HeaderStyle>
                                </asp:BoundColumn>--%>
                                
                                <asp:BoundColumn  DataField="Ins" HeaderText="IN" HeaderStyle-Width="2px" SortExpression="IN ASC" Visible="true">
                                <HeaderStyle Width="2px"></HeaderStyle>
                                </asp:BoundColumn>
                                
                                <asp:BoundColumn  DataField="Outs" HeaderText="OUT" HeaderStyle-Width="2px" SortExpression="LastSignOut ASC" Visible="true">
                                <HeaderStyle Width="2px"></HeaderStyle>
                                </asp:BoundColumn>

                                <asp:BoundColumn  DataField="ProposedIn" HeaderText="Proposed In" HeaderStyle-Width="9px" SortExpression="ProposedIn ASC" Visible="true">
                                <HeaderStyle Width="9px"></HeaderStyle>
                                </asp:BoundColumn>

                                <asp:BoundColumn  DataField="ProposedOut" HeaderText="Proposed Out" HeaderStyle-Width="5px" SortExpression="ProposedOut ASC" Visible="true">
                                <HeaderStyle Width="5px"></HeaderStyle>
                                </asp:BoundColumn>
                                
                                <asp:BoundColumn  DataField="Days" HeaderText="Day" HeaderStyle-Width="50px" SortExpression="Days ASC" Visible="true">
                                <HeaderStyle Width="50px"></HeaderStyle>
                                </asp:BoundColumn>
                                
                               <%-- <asp:BoundColumn  DataField="Months" HeaderText="Month" HeaderStyle-Width="50px" SortExpression="Months ASC" Visible="true">
                                <HeaderStyle Width="50px"></HeaderStyle>
                                </asp:BoundColumn>--%>

                                <asp:BoundColumn  DataField="ArrivalStatus" HeaderText="Arrival Status" HeaderStyle-Width="50px" SortExpression="ArrivalStatus ASC" Visible="true">
                                <HeaderStyle Width="50px"></HeaderStyle>
                                </asp:BoundColumn>

                                <asp:BoundColumn  DataField="TotalWorkingTime" HeaderText="Total working hours" HeaderStyle-Width="95px" SortExpression="TotalWorkingTime ASC" Visible="true">
                                <HeaderStyle Width="95px"></HeaderStyle>
                                </asp:BoundColumn>

                                <%--<asp:BoundColumn  DataField="WorkingTime" HeaderText="Working Time" HeaderStyle-Width="20px" SortExpression="WorkingTime ASC" Visible="true">
                                <HeaderStyle Width="20px"></HeaderStyle>
                                </asp:BoundColumn>--%>

                                <asp:BoundColumn  DataField="WorkingStatus" HeaderText="Working Status" HeaderStyle-Width="100px" SortExpression="WorkingStatus ASC" Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundColumn>

                                 <asp:BoundColumn  DataField="Reason" HeaderText="Remarks" HeaderStyle-Width="100px" SortExpression="Reason ASC" Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundColumn>

                                 <asp:BoundColumn  DataField="Elig_CWH" HeaderText="Eligibility CWH" HeaderStyle-Width="100px" SortExpression="Elig_CWH ASC" Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundColumn> 
                           </Columns>
                           <PagerStyle CssClass="GridPaging" HorizontalAlign="Left" Visible="False" />
                       </asp:DataGrid>
              </div>
        <br />
        <div style='overflow:auto;width:1000px;text-align:center;margin:0 auto';align="center">
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