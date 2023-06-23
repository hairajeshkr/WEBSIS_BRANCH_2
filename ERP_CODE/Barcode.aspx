<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Barcode.aspx.cs" Inherits="Barcode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> </title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div>
            &nbsp;<table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 100px; height: 18px">
                        <asp:Label ID="Label1" runat="server" Text="No. Barcode"></asp:Label></td>
                    <td style="width: 100px; height: 18px">
                    </td>
                    <td style="width: 100px; height: 18px">
                        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Generate BarCode NEW" />
                        </td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 18px">
                        <asp:Label ID="Label2" runat="server" Text="FROM" Width="67px"></asp:Label>
                    </td>
                    <td style="width: 100px; height: 18px">
                        <asp:TextBox ID="TxtFrm" runat="server" EnableTheming="True"></asp:TextBox></td>
                    <td style="width: 100px; height: 18px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 18px">
                        <asp:Label ID="Label3" runat="server" Text="To" Width="67px"></asp:Label></td>
                    <td style="width: 100px; height: 18px">
                        <asp:TextBox ID="TxtTo" runat="server"></asp:TextBox></td>
                    <td style="width: 100px; height: 18px">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Generate BarCode" /></td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 18px">
                        <asp:Label ID="Label4" runat="server" Width="67px"></asp:Label></td>
                    <td style="width: 100px; height: 18px">
                        Shope BarCode</td>
                    <td style="width: 100px; height: 18px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 18px">
                        <img id="ImgThump" runat="server" alt="Thumbnail Image" src="" style="width: 383px; height: 114px" /></td>
                    <td style="height: 18px" colspan="2">
                        <img id="ImgThump0" runat="server" alt="Thumbnail Image" src="" style="width: 250px; height: 50px" /></td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="LblInfo" runat="server" ForeColor="Maroon" Width="123px"></asp:Label></td>
                    <td style="width: 100px">
                    </td>
                    <td style="width: 100px">
                        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:TextBox ID="Txtno" runat="server" Enabled="False"></asp:TextBox></td>
                    <td style="width: 100px">
                        </td>
                    <td style="width: 100px">
                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="GET" /></td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 19px">
                        <img id="Img1" runat="server" alt="Thumbnail Image" src="" style="width: 383px; height: 114px" /></td>
                    <td style="width: 100px; height: 19px">
                        
                    </td>
                    <td style="width: 100px; height: 19px">
                    <input id="Button2" type="button" value="PRINT" onclick="javascript:window.print()" /></td>
                </tr>
            </table>
            &nbsp;
            <table border="0" cellpadding="0" cellspacing="0"  style="width: 100px;">
                <tr>
                    <td>
                        1</td>
                </tr>
                <tr>
                    <td >
                        2</td>
                </tr>
                <tr>
                    <td >
                        3</td>
                </tr>
                <tr>
                    <td >
                        4</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
