<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DemoMailingSystem.Default" %>

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
                <center><h2>Demo Mailing System</h2></center>
                <br />
                <br />
                <center>
            <table>
               
                <tr>
                    <td>
                        <asp:TextBox ID="txtEmailId" CssClass="form-control" runat="server" placeholder="Enter Email Id"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator  ID="rfvEmailId" runat="server" ControlToValidate="txtEmailId" ErrorMessage="You can't leave this empty." ForeColor="Red"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password" placeholder="Enter Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="You can't leave this empty." ForeColor="Red"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSignIn"  Text="Signin" runat="server" OnClick="btnSignIn_Click" /></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                <td>
                    <a href="ForgetPassword.aspx">Forget Password?</a>
                </td>
             </tr>
                <tr>
                    <td></td>
                </tr>
             <tr>
                <td>
                    <a href="CreateNewAccount.aspx">CreateNewAccount</a>
                </td>
               
              </tr>  
            </table>
            </center>
            </div>
        </form>

        <table>
        </table>
    </div>
</body>
</html>
