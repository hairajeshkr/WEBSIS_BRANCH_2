<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileShow.aspx.cs" Inherits="FileShow" StylesheetTheme="SkinFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height:100%;width:100%;">
            <asp:Image id="ImgFile" runat="server" />
            <asp:Label ID="LblMsg" runat="server" SkinID="LblRedBold"></asp:Label>
        </div>
    </form>
</body>
</html>
