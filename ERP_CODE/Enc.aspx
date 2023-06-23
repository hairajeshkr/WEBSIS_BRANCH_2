<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Enc.aspx.cs" Inherits="Enc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;
        <table style="width: 259px">
            <tr>
                <td style="width: 100px">
                    <asp:TextBox ID="TextBox1" runat="server" Width="311px"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ENC" Width="60px" /></td>
                <td style="width: 100px">
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="DEC" Width="52px" /></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:TextBox ID="TextBox2" runat="server" BackColor="#FFE0C0" ReadOnly="True" Width="311px"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px" bgcolor="#ECF0F5">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
