<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Practical5_AcademicLeave.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Leave Portal</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Student Academic Leave Portal</h2>

            <table>
                <tr>
                    <td>Student ID:</td>
                    <td>
                        <asp:TextBox ID="txtStudentId" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>Password:</td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:CheckBox ID="chkRemember" runat="server" Text=" Remember Student ID" />
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>