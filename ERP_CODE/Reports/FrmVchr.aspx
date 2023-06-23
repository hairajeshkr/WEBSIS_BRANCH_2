<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmVchr.aspx.cs" Inherits="Reports_FrmVchr" %>


<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>REPORT'S</title>
    <link href="/aspnet_client/System_Web/2_0_50727/crystalreportviewers13/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/4_0_30319/crystalreportviewers13/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="CrystlRptViewer" runat="server" AutoDataBind="true" />
        <br />
        <asp:Label ID="LblInfo" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12pt"
            ForeColor="#CC0000" Style="text-align: center" Text="Record(s)  could not found"
            Visible="False" Width="234px"></asp:Label>
    
    </div>
    </form>
</body>
</html>
