<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home1.aspx.cs" Inherits="Home1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport'>
<link href="CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />

<link href="CSS/font-awesome.css" rel="stylesheet" type="text/css" />
<link href="css/styleNewTheam.css" rel="stylesheet" type="text/css" />
<link href="CSS/all-skins.min.css" rel="stylesheet" type="text/css" />


<link href="cssdashboard/css/colors.min.css" rel="stylesheet" type="text/css"/>
<link href="cssdashboard/Global_Assets/css/icons/icomoon/styles.min.css" rel="stylesheet" type="text/css"/>
<%--DHTML WINDOW--%>

<script src="DhtmlWindow/dhtmlwindow.js" type="text/javascript"></script> 
<link href="DhtmlWindow/dhtmlwindow.css" rel="stylesheet" type="text/css" />
<link href="StyleSheet/StyleMenuVertical.css" rel="stylesheet" type="text/css" />
<script src="JavaScript/BrowserCustom.js" type="text/javascript" language="javascript"></script>
</head>
<body class="skin-black sidebar-mini">
<form id="form1" runat="server">
<div class="wrapper">
  <header class="main-header"> 
    <!-- Logo  
    <a href="#" class="logo"><span class="logo-mini"><b>CRM</b></span> <span class="logo-lg">DATA DAYCARE ~ </b>CRM</span> </a>-->
      <a href="#" target="_blank" class="logo"> <img src="images/logo.png" /></a>
    <nav class="navbar navbar-static-top" role="navigation"> <a href="#" class="sidebar-toggle" data-toggle="offcanvas" role="button"> <span class="sr-only"></span> </a>
            <div class="datadaycare-logo"><img src="images/logo-crm.png"/></div>
      <div class="company-info" style="color:#FFF; padding-top:15px; font-size:16px"><asp:Label ID="LblTitle" runat="server" Text=""></asp:Label><asp:Label ID="LblLoc" runat="server" Text=""></asp:Label><asp:Label ID="LblFaYear" runat="server" Text=""></asp:Label><asp:Label ID="LblUsr" runat="server" Text=""></asp:Label></div>
   </nav>
  </header>
  <aside class="main-sidebar">
    <section class="sidebar">
      <asp:Label ID="LblMenu" runat="server" Text=""></asp:Label>
    </section>
  </aside>
  <div class="content-wrapper">
     <div class="row"></div>
      <div class="content"><iframe style="width: 100%; height: 400px" id="frmpop" src="DashBoard.aspx" frameBorder="0" scrolling="yes"></iframe>

</div>
    </div>
  </div>
  <footer class="main-footer text-center"> <strong>Copyright@2021<a href="http://coinoneglobal.com/" target="_blank">Coinone Global Solutions Pvt Ltd</a>.</strong> All rights reserved. </footer>
  <aside class="control-sidebar control-sidebar-dark">
    <ul class="nav nav-tabs nav-justified control-sidebar-tabs">
      <!--  <li><a href="#" data-toggle="tab"></a></li>-->
    </ul>
    <div class="tab-content">
      <div class="tab-pane" id="control-sidebar-home-tab"> </div>
    </div>
  </aside>
        <ul class="nav nav-tabs nav-justified control-sidebar-tabs">
        </ul>
  <div class='control-sidebar-bg'></div>
</div>
<script src="JS/jQuery-2.1.4.min.js" type="text/javascript"></script> 
<script src="JS/jquery-ui.min.js" type="text/javascript"></script> 
<script src="JS/bootstrap.min.js" type="text/javascript"></script> 
<script src="JS/jquery.slimscroll.min.js" type="text/javascript"></script> 
<script src="JS/app.min.js" type="text/javascript"></script> 
<script src="JS/demo.js" type="text/javascript"></script> 
<script src="JS/moment-with-locales.js" type="text/javascript"></script> 
</form>
<script language="javascript" type="text/javascript">

/*$(document).on("click" , ".sknblue" , function(){$(".drag-handle").removeClass("drag-handle clr-ivory" ).addClass("drag-handle clr-blue");});*/
/*$(document).on("click" , ".sknblue" , function(){$(".drag-handle").addClass("clr-blue");});
$(document).on("click" , ".sknIvory" , function(){$(".drag-handle").addClass("clr-ivory");});
$(document).on("click" , ".sknpurple" , function(){$(".drag-handle").addClass("clr-purple");});
*/
</script>
</body>
</html>
