<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateNewAccount.aspx.cs" Inherits="DemoMailingSystem.CreateNewAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style/style.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style2 {
            height: 12px;
        }
    </style>
</head>
<body>
    <br />
    <br />
    <br />
    <div class="wrapper">
        <form id="form1" runat="server" class="form-signin">
            <div>
                <table>
                    <tr>
                        <td colspan="6">
                            <center><h2>Sign Up</h2></center>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">Name</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:TextBox ID="txtFirstName" CssClass="" runat="server" placeholder="First"></asp:TextBox></td>

                        <td colspan="3">
                            <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server" placeholder="Last"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="3" class="auto-style2">
                            <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="You can't leave this empty." ForeColor="Red"></asp:RequiredFieldValidator></td>

                        <td colspan="3" class="auto-style2">
                            <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName" ErrorMessage="You can't leave this empty." ForeColor="Red"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td colspan="6">Choose your user Id</td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:TextBox ID="txtUserId" TextMode="Email" CssClass="form-control" runat="server" placeholder="User Id"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:RequiredFieldValidator ID="rfvUserId" runat="server" ControlToValidate="txtUserId" ErrorMessage="You can't leave this empty." ForeColor="Red"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td colspan="6">Create a password</td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="6">Confirm your password</td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:TextBox ID="txtConfmPassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:CompareValidator ID="vcmpPassword" ControlToCompare="txtConfmPassword" ControlToValidate="txtPassword" ErrorMessage="Password not Matched..!!" ForeColor="Red" runat="server"></asp:CompareValidator></td>
                    </tr>
                    <tr>
                        <td colspan="6">Birthday</td>
                    </tr>
                    <tr>
                        <td><asp:TextBox ID="txtBirthday" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox></td>
                    </tr>
                    <%--<tr>
                        <td colspan="4">
                            <asp:DropDownList CssClass="form-control" ID="ddlMonth" runat="server">
                                <asp:ListItem Text="-Select-" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="January" Value="1"></asp:ListItem>
                                <asp:ListItem Text="February" Value="2"></asp:ListItem>
                                <asp:ListItem Text="March" Value="3"></asp:ListItem>
                                <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                <asp:ListItem Text="July " Value="7"></asp:ListItem>
                                <asp:ListItem Text="August " Value="8"></asp:ListItem>
                                <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                <asp:ListItem Text="December" Value="12"></asp:ListItem>
                            </asp:DropDownList></td>
                        <td colspan="1">
                            <asp:TextBox ID="txtDay" CssClass="form-control" placeholder="Day" runat="server"></asp:TextBox></td>
                        <td colspan="1">
                            <asp:TextBox ID="txtYear" CssClass="form-control" placeholder="Year" runat="server"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td colspan="2">
                            <asp:RequiredFieldValidator ID="rfvMonth" runat="server" ControlToValidate="ddlMonth" ErrorMessage="You can't leave this empty." ForeColor="Red"></asp:RequiredFieldValidator></td>
                        <td colspan="2">
                            <asp:RequiredFieldValidator ID="rfvDay" runat="server" ControlToValidate="txtDay" ErrorMessage="You can't leave this empty." ForeColor="Red"></asp:RequiredFieldValidator></td>
                        <td colspan="2">
                            <asp:RequiredFieldValidator ID="rfvYear" runat="server" ControlToValidate="txtYear" ErrorMessage="You can't leave this empty." ForeColor="Red"></asp:RequiredFieldValidator></td>
                    </tr>--%>
                    <tr>
                        <td colspan="6">Gender</td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:RadioButtonList CssClass="form-control" ID="rblGender" CellSpacing="2" runat="server" RepeatColumns="2">
                                <asp:ListItem Text="Male" Selected="True" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">Security Question</td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:DropDownList CssClass="form-control" ID="ddlQuestion" runat="server">
                                <asp:ListItem Text="-------------------Select------------------" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Your First School Name" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Your Pet Name" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Your Born Place" Value="3"></asp:ListItem>

                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:TextBox ID="txtAnswer" placeholder="Your Answer" CssClass="form-control" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvAnswer" runat="server" ControlToValidate="txtAnswer" ErrorMessage="You can't leave this empty." ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnSignUp" runat="server" Text="Signup" OnClick="btnSignUp_Click" />
                        </td>
                    </tr>
                </table>

            </div>
        </form>
    </div>
</body>
</html>
