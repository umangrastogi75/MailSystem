<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="DemoMailingSystem.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style/style.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 317px;
        }

        .auto-style2 {
            width: 968px;
        }

        .btn {
            width: 80px;
            height: 35px;
            font-size: 14px;
            color: #555;
            background-color: #fff;
            background-image: none;
            border: 1px solid #ccc;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,0.075);
            box-shadow: inset 0 1px 1px rgba(0,0,0,0.075);
            -webkit-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
        }
    </style>
</head>
<body>
    <div class="wrapper">
        <form id="form1" runat="server">
            <div style="border-bottom: 3px solid">

                <center><h1><b>DemoMail</b></h1></center>
                <asp:Button ID="btnhome" Text="Home" runat="server" CssClass="btn" OnClick="btnhome_Click" />
                <asp:Button ID="btnSignout" runat="server" Text="Signout" CssClass="btn" OnClick="btnSignout_Click" />
            </div>
            <center>
            <table class="table">

                <tr>
                    <td>
                        <asp:Image ID="imgUser" runat="server" CssClass="img-thumbnail" /></td>
                    <td>
                        <asp:LinkButton ID="lnkProfile" Text="Change Profile" runat="server" OnClick="lnkProfile_Click"></asp:LinkButton></td>
                    <td>
                        <asp:FileUpload ID="fileUploader" runat="server" Visible="false" /></td>
                </tr>
                <tr>
                    <td>Name :</td>
                    <td><asp:Label ID="lblNmae" Text="" runat="server"></asp:Label></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                </tr>

            </table>
            </center>

        </form>
    </div>
</body>
</html>
