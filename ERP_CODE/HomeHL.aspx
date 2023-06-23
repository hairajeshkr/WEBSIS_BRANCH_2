<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomeHL.aspx.cs" Inherits="HomeHL" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Datadaycare - CRM</title>
<meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport'>
    <link href="CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />
<link href="CSS/font-awesome.css" rel="stylesheet" type="text/css" />
<link href="css/styleNewTheam.css" rel="stylesheet" type="text/css" />
<link href="CSS/all-skins.min.css" rel="stylesheet" type="text/css" />

<%--DHTML WINDOW--%>
<link href="DhtmlWindow/dhtmlwindow.css" rel="stylesheet" type="text/css" />
<link href="StyleSheet/StyleMenuHorizontal.css" rel="stylesheet" type="text/css" />
<script src="DhtmlWindow/dhtmlwindow.js" type="text/javascript"></script> 
<script src="JavaScript/BrowserCustom.js" type="text/javascript"></script>
</head>
<body class="skin-black sidebar-mini">
<form id="form1" runat="server">
<div class="wrapper">
  <header class="main-header"> 
    <!-- Logo http://coinoneinvents.com--> 
    <a href="#" target="_blank" class="logo"> <img src="images/logo.png" /></a>
    <nav class="navbar navbar-static-top" role="navigation"> 
        <!-- <a href="#" class="sidebar-toggle" data-toggle="offcanvas" role="button"> <span class="sr-only">Toggle navigation</span> </a>
      <div class="navbar-custom-menu">
        <ul class="nav navbar-nav">
          <li> <a href="#" data-toggle="control-sidebar"><i class="fa fa-gears"></i></a> </li>
        </ul>
      </div>--> 
      <div class="company-info" style="color:#FFF; padding-top:15px; font-size:16px"><asp:Label ID="LblTitle" runat="server" Text=""></asp:Label><asp:Label ID="LblLoc" runat="server" Text=""></asp:Label><asp:Label ID="LblFaYear" runat="server" Text=""></asp:Label><asp:Label ID="LblUsr" runat="server" Text=""></asp:Label></div>
    <div class="datadaycare-logo"><img src="images/logo-crm.png"/></div>
    </nav>
  </header>
  <aside class="main-sidebar">
    <section class="sidebar">
      <asp:Label ID="LblMenu" runat="server" Text=""></asp:Label>
    </section>
  </aside>
  <div class="content-wrapper">
    <section class="content-header">
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-home"></i>User :<asp:Label ID="LblUsr1" runat="server" Text=""></asp:Label></a></li>
      </ol>
    </section>
      <section class="content">
                 <!--   <div class="container">
              <div class="row">
                  <div class="col-xs-12"><h1 class="page-headings">Dashboard</h1></div>
              </div>
              <div class="row">
                  <div class="col-xs-8" style="padding-left:0;padding-right:0;">
                  <div class="col-xs-6"><div class="dashboard-item-container"></div></div>
                  <div class="col-xs-6"><div class="dashboard-item-container"></div></div>
                  <div class="col-xs-6"><div class="dashboard-item-container" style="margin-bottom:0;"></div></div>
                  <div class="col-xs-6"><div class="dashboard-item-container" style="margin-bottom:0;"></div></div>
                  </div>
                  
                  <div class="col-xs-4" style="padding-right:0;"><div class="dashboard-item-container"></div></div>
                  </div>
</div>

 -->
                 <table style="height:90%; width: 100%">
                     <tr>
                         <td style="height:50px;width: 120px" align="right" valign="top"></td>
                     </tr>
                     <tr>
                         <td>   <iframe style="width: 100%; height: 400px" id="frmpop" src="DashBoardNill.aspx" frameBorder="0" scrolling="yes"></iframe></td>
                     </tr>
                 </table>
    </section>
  </div>
  <footer class="main-footer text-center"> <strong>Copyright@2023<a href="http://coinoneglobal.com/" target="_blank">Coinone Global Solutions Pvt Ltd</a>.</strong> All rights reserved. </footer>
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
<script src="JS/demoHorizonal.js" type="text/javascript"></script> 
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
