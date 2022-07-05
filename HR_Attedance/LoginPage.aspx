<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LoginPage.aspx.vb" Inherits="HR_Attedance.LoginPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta charset="UTF-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>HR Attendance System</title>
    <link rel="shortcut icon" href="Images/icon.ico" />
    <link rel='stylesheet prefetch' href='css/jquery-ui.css'/>
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="css/dist/css/bootstrap.min.css" />
     <link rel="stylesheet" href="css/font-awesome.min.css" />
</head>
<body width="50%">
  <form id="Form1" runat="server">
   <!-- <link href='http://fonts.googleapis.com/css?family=Ubuntu:500' rel='stylesheet' type='text/css'> -->
    
    <div class="body" id="bodyLogin"></div>
		<div class="grad"></div>
		<div class="header">
			<div style="margin-top:-58px"><span class="span2">AXA Indonesia Attendance System</span></div>
		</div>
		<br>
		<div class="login" style="margin-top:-90px">
          <form class="login-form">
              
              <div class="group-input">&nbsp;<font color="White"><i class="fa fa-user-o fa-fw blue"></i><asp:TextBox runat="server" ForeColor="White" ID="txtUser" placeholder="Username"></asp:TextBox></font></div>
              <div class="group-input">&nbsp;<font color="White"><i class="fa fa-key fa-fw blue"></i><asp:TextBox runat="server" ForeColor="White" ID="txtPass" TextMode="Password" placeholder="Password"></asp:TextBox></font></div>
              
              <asp:Button runat="server" ID="btnSubmit" Text="Login" /><br />
              <asp:Label runat="server" ForeColor="Red" ID="lblLogin" style="margin-left:2px" Visible="false"></asp:Label>
          </form>
		</div>

<script type="text/javascript" src='js/jquery.min.js'></script>
<script type="text/javascript" src='js/jquery-ui.min.js'></script>
<script type="text/javascript" src="js/index.js"></script>

    
  </form>  
</body>
</html>
