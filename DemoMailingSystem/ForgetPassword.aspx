<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="DemoMailingSystem.ForgetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style/style.css" rel="stylesheet" />
</head>
<body>
    <br />
    <br />
    <div class="wrapper">
        <form id="form1" runat="server" class="form-signin">
            <div>
                <center><h2>Reset Password</h2></center>
                <br />
                <br />
                <center>
                <table>

                    <tr>
                        <td><asp:Label ID="lbluserid" CssClass="form-control" Text="UserId :" runat="server"></asp:Label></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtuserid" runat="server" placeholder="Enter user Id"></asp:TextBox></td>
                    </tr>
                    <tr><td><asp:Label ID="lblQuestion1" CssClass="form-control" Text="Security Question :" runat="server" Visible="false"></asp:Label></td>
                        <td><asp:Label ID="lblQuestion" CssClass="form-control" Text="" runat="server" Visible="false"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblAnswer" CssClass="form-control" Text="Your Answer :" runat="server" Visible="false"></asp:Label></td>
                        <td><asp:TextBox ID="txtAnswer" CssClass="form-control" runat="server" Visible="false" autocomplete="off"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><br /></td>
                        <td><asp:Button ID="btnResetpassword" Text="Next" CssClass="bottom" runat="server" OnClick="btnResetpassword_Click" /></td>
                    </tr>

                </table>
            </div>
        </form>
    </div>
</body>
</html>
