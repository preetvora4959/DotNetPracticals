<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Practical5_AcademicLeave.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Academic Leave Portal</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Academic Leave Management</h2>

            <asp:Label ID="lblWelcome" runat="server"></asp:Label>

            <br /><br />

            <table>
                <tr>
                    <td>Leave Date:</td>
                    <td>
                        <asp:Calendar ID="calLeaveDate" runat="server"></asp:Calendar>
                    </td>
                </tr>

                <tr>
                    <td>Leave Type:</td>
                    <td>
                        <asp:DropDownList ID="ddlLeaveType" runat="server">
                            <asp:ListItem>Medical Leave</asp:ListItem>
                            <asp:ListItem>Personal Leave</asp:ListItem>
                            <asp:ListItem>Event Leave</asp:ListItem>
                            <asp:ListItem>Emergency Leave</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>Reason:</td>
                    <td>
                        <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine"
                            Rows="4" Columns="30"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnApply" runat="server"
                            Text="Apply Leave" OnClick="btnApply_Click" />
                    </td>
                </tr>
            </table>

            <br />

            <asp:Label ID="lblResult" runat="server"></asp:Label>

            <br /><br />

            <asp:Button ID="btnLogout" runat="server"
                Text="Logout" OnClick="btnLogout_Click" />
        </div>
    </form>
</body>
</html>