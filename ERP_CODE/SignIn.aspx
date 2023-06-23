<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="SignIn" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>DATA DAYCARE :: LOG IN</title>
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport'>
    <!-- Bootstrap 3.3.4 -->
    <link href="CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- Theme style -->
    <link href="css/styleNewTheam.css" rel="stylesheet" type="text/css" />
    
    <script src="JavaScript/General.js" type="text/javascript" language="javascript"></script>
    <script src="JavaScript/LogIn.js" type="text/javascript" language="javascript"></script>
    <script type="text/javascript" language="javascript">
        function DisableBackButton() 
        {
        window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function(evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function() { void (0) }
    </script>
    <script src="JavaScript/BrowserCustom.js" type="text/javascript" language="javascript"></script>
</head>
<body class="login-page">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <div class="login-box">
      <div class="login-logo">
          <a href="#" target="_blank" class="logo"><img src="images/logo.png" /></a>
        <div><img src="images/logo-crm.png"/></div>
      </div>
      <div class="login-box-body">
        <p class="login-box-msg">Sign in to start your session</p>
          <div class="form-group has-feedback">
            <asp:TextBox type="text" class="form-control" placeholder="User Name"  id="TxtUserName" runat="server"></asp:TextBox> 
            <span class="glyphicon glyphicon-user form-control-feedback" style="right: 0px; top: 0px"></span>
          </div>
          <div class="form-group has-feedback">
            <asp:TextBox  TextMode="Password" class="form-control" placeholder="Password" id="TxtPwd" runat="server"></asp:TextBox>
            <span class="glyphicon glyphicon-lock form-control-feedback"></span>
          </div>
          <div class="row">
            <div class="col-xs-8">    
              <div class="checkbox icheck">
                <label>
                  <input type="checkbox"> Remember Me
                </label>
             &nbsp;</div>                        
            </div>
            <div class="col-xs-4" style="left: 0px; top: 0px">
                <asp:Button ID="BtnLogIn" CssClass="btn btn-primary btn-block btn-flat" runat="server" Text="Sign In" OnClick="BtnLogIn_Click" OnClientClick="return ValidateMasterData();"/></div>
          </div>

        <div class="social-auth-links text-center">
        </div><!-- /.social-auth-links -->
      </div>
    </div>
                <div>
                </div>
                <div>
                </div>
                </FORM>
            </ContentTemplate>
        </asp:UpdatePanel>
                </form>
        <div class="copyright-text"><p>Copyright@2023 <a href="http://coinoneglobal.com/" target="_blank">Coinone Global Solutions Pvt Ltd</a>.All rights reserved.</p></div>
</body>
</html>