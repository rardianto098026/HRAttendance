<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="HR_Attedance.Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en" >
<head>
  <meta charset="UTF-8">
  <title>HR Attendance System</title>
	<meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link href="LoginPage/reset.min.css" rel="stylesheet" />
    <link href="LoginPage/css.css" rel="stylesheet" />
    <link href="LoginPage/font-awesome.min.css" rel="stylesheet" />
    <link href="LoginPage/css/style.css" rel="stylesheet" />

<%--<script type="text/javascript">
    HideWait();
</script>--%>
</head>

<body>
  
<!-- Form Mixin-->
<!-- Input Mixin-->
<!-- Button Mixin-->
<!-- Pen Title-->
<div class="pen-title">
  <h1><font color="#5379fa">AXA INDONESIA</font></h1><span><font size="5px"><b>HR <i class='fa fa-paint-brush'></i> Attendance <i class='fa fa-code'></i> System</b></font></span>
</div>
<!-- Form Module-->
<div class="module form-module">
  <div class="toggle"><i class="fa fa-times fa-pencil"></i>
    <%--<div class="tooltip">Click Me</div>--%>
  </div>
  <div class="form">
      
    <h2>Login to your account</h2>
    <form id="Form1"  runat="server">
      <asp:TextBox runat="server" ID="txtUser" placeholder="Username"></asp:TextBox>
      <asp:TextBox runat="server" ID="txtPass" TextMode="Password" placeholder="Password"></asp:TextBox>
      <asp:DropDownList runat="server" ID="ddlYear" placeholder="Year">
          <asp:ListItem Value="0">--Choose Year Attendance--</asp:ListItem>
          <asp:ListItem Value="2017">2017</asp:ListItem>
          <asp:ListItem Value="2018">2018</asp:ListItem>
          <asp:ListItem Value="2019">2019</asp:ListItem>
          <asp:ListItem Value="2020">2020</asp:ListItem>
      </asp:DropDownList>
      <asp:Label ID="errYear" runat="server" ForeColor ="Red" Visible="false"></asp:Label>
   
      <asp:Button runat="server" ID="btnSubmit" Text="Login" />
      <asp:Label runat="server" ForeColor="Red" ID="lblLogin" style="margin-left:2px" Visible="false"></asp:Label>
          
    </form>
      </div>
  </div>
    <script type="text/javascript" src="LoginPage/js/index.js"></script>
    <script type="text/javascript" src="js/jquery.min.js"></script>
</body>
</html>

