<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Company.aspx.cs" Inherits="Company" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>:: Data Daycare ERP | Log in ::</title>
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport'>
    <!-- Bootstrap 3.3.4 -->
    <link href="CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- Theme style -->
    <link href="css/styleNewTheam.css" rel="stylesheet" type="text/css" />
    
     <script src="JavaScript/General.js" type="text/javascript" language="javascript"></script>
    <script src="JavaScript/Company.js" type="text/javascript" language="javascript"></script>
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
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body class="login-page">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <div class="login-box">
      <div class="login-logo">
<a href="#" target="_blank" class="logo"><img src="images/logo.png" alt="" /></a>
        <div><img src="images/logo-crm.png" alt=""/></div>
      </div>
      <div class="login-box-body">
        <p class="login-box-Left"><asp:Label id="LblCmp" runat="server" Width="100%" style="text-align: center;" Text="Label" Height="30px" Font-Size="15pt" Font-Bold="True"></asp:Label></p>
          <div class="form-group has-feedback">             
              <asp:DropDownList ID="DdlBranch" runat="server" CssClass="Dropdown_field_style" Width="100%">
              </asp:DropDownList>
               <span class="glyphicon glyphicon-home form-control-feedback" style="right: -5px; top: 0px"></span>
          </div>
          <div class="form-group has-feedback">
              <asp:DropDownList ID="DdlFYear" runat="server" CssClass="Dropdown_field_style" Width="100%">
              </asp:DropDownList>
              <span class="glyphicon glyphicon-calendar form-control-feedback" style="right: -5px; top: 0px"></span>
          </div>
           <div class="form-group has-feedback">
              <asp:DropDownList ID="DdlAcYear" runat="server" CssClass="Dropdown_field_style" Width="100%">
              </asp:DropDownList>
              <span class="glyphicon glyphicon-calendar form-control-feedback" style="right: -5px; top: 0px"></span>
          </div>
          <div class="form-group has-feedback">
            <asp:TextBox  TextMode="Password" class="form-control" placeholder="One Time Password" id="TxtOtp" runat="server"></asp:TextBox>
            <span class="glyphicon glyphicon-lock form-control-feedback"></span>
          </div>
          <div class="form-group has-feedback">
              <table class="auto-style1">
                  <tr>
                      <td><asp:Label id="LblMn" runat="server" Width="70px" Height="25px" Font-Size="13px" Font-Bold="true" Text="Menu List"></asp:Label></td>
                      <td>
                          <asp:RadioButtonList ID="RadBtnMenu0" runat="server" Height="16px" RepeatDirection="Horizontal" Width="150px" Enabled="true">
                              <asp:ListItem Value="VR">Vertical</asp:ListItem>
                              <asp:ListItem Value="HR" Selected="True">Horizontal</asp:ListItem>
                          </asp:RadioButtonList>
                      </td>
                  </tr>
              </table>
          </div>
          <div class="row">
              <div class="col-xs-4" style="left: 0px; top: 0px">
                  <asp:Button ID="BtnClose" runat="server" CssClass="btn btn-primary btn-block btn-flat" PostBackUrl="~/SignIn.aspx" Text="Cancel" />
              </div>
              <div class="col-xs-4" style="left: 90px; top: 0px">
                  <asp:Button ID="BtnLogIn" runat="server" CssClass="btn btn-primary btn-block btn-flat" OnClick="BtnLogIn_Click" OnClientClick="return ValidateMasterData();" Text="Open" />
              </div>
          </div>
          <div class="social-auth-links text-center">
          </div>
          <!-- /.social-auth-links -->
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
        <div class="copyright-text"><p>Copyright@2023 <a href="http://coinoneglobal.com/" target="_blank">Coinone Global Solutions Pvt Ltd</a>. All rights reserved.</p></div>

</body>
</html>
