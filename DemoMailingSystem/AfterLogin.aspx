<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AfterLogin.aspx.cs" Inherits="DemoMailingSystem.AfterLogin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style/style.css" rel="stylesheet" />
    <script src="JavaScript/jquery-ui.min.js"></script>
    <script src="JavaScript/jquery.min.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 227px;
        }

        .new {
           padding: 10px 5px; font-size: 1.2em; white-space:  pre-line; overflow: hidden;nav-down:current; 
        }
    </style>

</head>
<body>
    <div class="wrapper">
        <form id="form1" runat="server">

            <div>
                <table style="width: 100%; height: 100%; align-items: baseline">

                    <tr style="border-bottom: 2px solid">
                        <td colspan="2">
                            <h1><b>DemoMail</b></h1>
                        </td>
                        <td colspan="1">
                            <asp:TextBox ID="txtSearch" CssClass="form-control" runat="server" placeholder="Search Message By Subject Name"></asp:TextBox></td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="form-control" OnClick="btnSearch_Click" /></td>
                        <td>

                        <td></td>
                        <td>
                            <asp:Button ID="btnSignout" runat="server" Text="Signout" CssClass="form-control" OnClick="btnSignout_Click" />

                        </td>
                    </tr>
                    <tr>
                        <td rowspan="50" style="border-right: 2px solid; border-bottom: 2px solid" class="auto-style1">
                            <center>
                            <asp:Image ID="imgUser" runat="server" Height="150px" Width="150px" CssClass="img-circle"/>
                            
                           <asp:Button ID="btnProfile" Text="" BackColor="#99ffcc" Font-Bold="true" ForeColor="Black"  CssClass="form-control" runat="server" OnClick="btnProfile_Click"/>
                                <asp:FileUpload ID="fileuploader" runat="server"   Visible="false" CssClass="bottom" />
                                <asp:Button ID="btnProfileUpload" Text="Upload" Visible="false" runat="server" OnClick="btnProfileUpload_Click" />
                                <asp:Button ID="btnCancle" runat="server" Text="Cancle" OnClick="btnCancle_Click" Visible="false" />
                            <br /><br />
                       
                            <asp:LinkButton ID="lnkComposeMail" BackColor="#ffffcc" CssClass="form-control" Text="Compose Mail" runat="server" OnClick="lnkComposeMail_Click"></asp:LinkButton>
                            <br />
                            <asp:Image ID="imgNewMail" Visible="false" ImageUrl="~/img/new gif.gif" Height="70px" Width="90px" runat="server" />
                            <asp:LinkButton ID="lnkInbox"  BackColor="#ffffcc" CssClass="form-control" Text="Inbox" runat="server" OnClick="lnkInbox_Click"></asp:LinkButton>
                            <br />
                            <asp:LinkButton ID="lnkStarred"  BackColor="#ffffcc" CssClass="form-control" Text="Starred" runat="server" OnClick="lnkStarred_Click"></asp:LinkButton>
                            <br />
                            <asp:LinkButton ID="lnkSentMail"  BackColor="#ffffcc" CssClass="form-control" Text="Sent Mail" runat="server" OnClick="lnkSentMail_Click"></asp:LinkButton>
                            <br />
                            <asp:LinkButton ID="lnkDraft"  BackColor="#ffffcc" CssClass="form-control" Text="Draft" runat="server" OnClick="lnkDraft_Click"></asp:LinkButton>
                            <br />
                            <asp:LinkButton ID="lnkSpanm"  BackColor="#ffffcc" CssClass="form-control" Text="Spam" runat="server" OnClick="lnkSpanm_Click"></asp:LinkButton>
                            <br />
                            <asp:LinkButton ID="lnkTrash"  BackColor="#ffffcc" CssClass="form-control" Text="Trash" runat="server" OnClick="lnkTrash_Click"></asp:LinkButton>
                            <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                                </center>
                        </td>
                        <td></td>
                        <td colspan="5" rowspan="8" style="align-items: inherit">
                            <%-----------------------------------------------------COMPOSE BUTTON PANAL--------------------------------------------------------%>
                            <asp:Panel ID="pnlCompose" runat="server" Visible="false" CssClass="form-control" Height="100%">
                                <br />
                                <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
                                </asp:ScriptManager>
                                To :<asp:TextBox ID="txtSendTo" TextMode="Email" CssClass="form-control" runat="server" placeholder="Receiver's Id"></asp:TextBox><br />
                                <asp:AutoCompleteExtender ServiceMethod="GetCompletionList" MinimumPrefixLength="1" CompletionListCssClass="new" CompletionInterval="10" EnableCaching="false" CompletionSetCount="1" TargetControlID="txtSendTo" ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                                </asp:AutoCompleteExtender>
                                Subject :<asp:TextBox ID="txtSubject" CssClass="form-control" runat="server" placeholder="Subject"></asp:TextBox><br />
                                Attachments :<br />
                                <asp:FileUpload ID="fufiles" runat="server" AllowMultiple="True" /><br />

                                <br />
                                <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control" TextMode="MultiLine" Height="200px" Width="400px" placeholder="Type Message here.."></asp:TextBox><br />
                                <asp:Button ID="pnlComposebtnSend" runat="server" Text="Send" OnClick="pnlComposebtnSend_Click" />
                                <asp:Button ID="pnlComposebtnSaveDraft" runat="server" Text="Save Draft" OnClick="pnlComposebtnSaveDraft_Click" />
                                <asp:Button ID="pnlComposebtnDiscard" runat="server" Text="Discard" OnClick="pnlComposebtnDiscard_Click" />

                            </asp:Panel>
                            <%-----------------------------------------------------INBOX BUTTON PANAL--------------------------------------------------------%>
                            <asp:Panel ID="pnlInbox" runat="server" Visible="false" CssClass="form-control" Height="100%">
                                <asp:Button ID="btnInboxDeleteCheeked" Text="Delete Selected" CssClass="btn-danger" runat="server" OnClick="btnInboxDeleteCheeked_Click" />
                                <asp:GridView ID="grdMail" runat="server" Width="100%" AutoGenerateColumns="false" OnRowCommand="grdMail_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="msgCheekbox" runat="server" CssClass="form-control" />
                                                <asp:HiddenField ID="hff" Value='<%#Eval("MessageId") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgStarred" ImageUrl='<%#Eval("IsStarred","~/img/{0}.png") %>' runat="server" Height="30px" Width="30px" CommandName="star" CommandArgument='<%#Eval("MessageId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Sender">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnSender" Text='<%#Eval("AuthorId") %>' runat="server" CommandName="showMessage" CommandArgument='<%#Eval("MessageId") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Subject">
                                            <ItemTemplate>
                                                <%#Eval("Subject") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Message">
                                            <ItemTemplate>
                                                <%#Eval("Body") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <%#Eval("Date") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnDelete" runat="server" Text="Delete" CommandName="del" CommandArgument='<%#Eval("MessageId") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>


                                </asp:GridView>

                            </asp:Panel>

                            <asp:Panel ID="pnlShowMessage" runat="server" Visible="false" CssClass="form-control" Height="100%">
                                From :
                                <asp:Label ID="lblShowSender" Text="" runat="server"></asp:Label><br />
                                <br />
                                Subject :<asp:Label ID="lblShowSubject" Text="" runat="server"></asp:Label><br />
                                <br />
                                Message :<asp:Label ID="lblShowMessage" Text="" runat="server"></asp:Label><br />
                                <br />
                                <asp:Label ID="lblShowAttachment" Text="" runat="server"></asp:Label><br />
                                <br />
                                <asp:Label ID="lblShowDate" Text="" runat="server"></asp:Label>

                            </asp:Panel>
                            <%------------------------------------------------------SENT BUTTON PANAL--------------------------------------------------------%>
                            <asp:Panel ID="Panel1" runat="server" Visible="false" CssClass="form-control" Height="100%">
                                <asp:Button ID="btnDeleteSent" Text="Delete Selected" CssClass="btn-danger" OnClick="btnDeleteSent_Click" runat="server" />
                                <asp:GridView ID="grdSent" runat="server" Width="100%" AutoGenerateColumns="false" OnRowCommand="grdSent_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="msgCheekbox" runat="server" CssClass="form-control" />
                                                <asp:HiddenField ID="hffSent" Value='<%#Eval("MessageId") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgStarred" ImageUrl='<%#Eval("IsStarred","~/img/{0}.png") %>' runat="server" Height="30px" Width="30px" CommandName="star" CommandArgument='<%#Eval("MessageId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Send To">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnMessage" Text='<%#Eval("UserID") %>' runat="server" CommandName="showMessage" CommandArgument='<%#Eval("MessageId") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Subject">
                                            <ItemTemplate>
                                                <%#Eval("Subject") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Message">
                                            <ItemTemplate>
                                                <%#Eval("Body") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <%#Eval("Date") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnDelete" runat="server" Text="Delete" CommandName="del" CommandArgument='<%#Eval("MessageId") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>


                                </asp:GridView>

                            </asp:Panel>

                            <asp:Panel ID="pnlSent" runat="server" Visible="false" CssClass="form-control" Height="100%">
                                To :
                                <asp:Label ID="Label1" Text="" runat="server"></asp:Label><br />
                                <br />
                                Subject :<asp:Label ID="Label2" Text="" runat="server"></asp:Label><br />
                                <br />
                                Message :<asp:Label ID="Label3" Text="" runat="server"></asp:Label><br />
                                <br />
                                <asp:Label ID="Lable4" Text="" runat="server"></asp:Label><br />
                                <br />
                                <asp:Label ID="Lable5" Text="" runat="server"></asp:Label>

                            </asp:Panel>

                            <%------------------------------------------------------DRAFT BUTTON PANAL--------------------------------------------------------------------%>
                            <asp:Panel ID="pnlDraft" runat="server" Visible="false" CssClass="form-control" Height="100%">
                                <asp:Button ID="btnDeleteDraft" Text="Delete Selected" CssClass="btn-danger" OnClick="btnDeleteDraft_Click" runat="server" />
                                <asp:GridView ID="grdDraft" runat="server" Width="100%" AutoGenerateColumns="false" OnRowCommand="grdDraft_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="msgCheekbox" runat="server" CssClass="form-control" />
                                                <asp:HiddenField ID="hffDraft" Value='<%#Eval("MessageId") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgStarred" ImageUrl='<%#Eval("IsStarred","~/img/{0}.png") %>' runat="server" Height="30px" Width="30px" CommandName="star" CommandArgument='<%#Eval("MessageId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Subject">
                                            <ItemTemplate>
                                                <%#Eval("Subject") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Message">
                                            <ItemTemplate>
                                                <%#Eval("Body") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <%#Eval("Date") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnDtaft" runat="server" Text="Send" CommandName="snd" CommandArgument='<%#Eval("MessageId") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnDelete" runat="server" Text="Delete" CommandName="del" CommandArgument='<%#Eval("MessageId") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>


                                </asp:GridView>

                            </asp:Panel>

                            <asp:Panel ID="Panel3" runat="server" Visible="false" CssClass="form-control" Height="100%">
                                To :
                                <asp:Label ID="Label8" Text="" runat="server"></asp:Label><br />
                                <br />
                                Subject :<asp:Label ID="Label9" Text="" runat="server"></asp:Label><br />
                                <br />
                                Message :<asp:Label ID="Label10" Text="" runat="server"></asp:Label><br />
                                <br />
                                Attachment :<asp:Label ID="Label11" Text="" runat="server"></asp:Label><br />
                                <br />

                            </asp:Panel>

                            <%------------------------------------------------------TRASH BUTTON PANAL------------------------------------------------------------------------%>
                            <asp:Panel ID="pnlTrashBox" runat="server" Visible="false" CssClass="form-control" Height="100%">
                                <asp:GridView ID="grdTrash" runat="server" Width="100%" AutoGenerateColumns="false" OnRowCommand="grdTrash_RowCommand">
                                    <Columns>
                                        <%-- <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgStarred" ImageUrl='<%#Eval("IsStarred","~/img/{0}.png") %>' runat="server" Height="30px" Width="30px" CommandName="star" CommandArgument='<%#Eval("MessageId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="msgCheekbox" runat="server" CssClass="form-control" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="User Id">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnMessage" Text='<%#Eval("AuthorId") %>' runat="server" CommandName="showMessage" CommandArgument='<%#Eval("MessageId") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Subject">
                                            <ItemTemplate>
                                                <%#Eval("Subject") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Message">
                                            <ItemTemplate>
                                                <%#Eval("Body") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <%#Eval("Date") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnRestor" runat="server" Text="Restore" CommandName="res" CommandArgument='<%#Eval("MessageId") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnDelete" runat="server" Text="Delete" CommandName="del" CommandArgument='<%#Eval("MessageId") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>


                                </asp:GridView>

                            </asp:Panel>

                            <asp:Panel ID="pnlTrashMessage" runat="server" Visible="false" CssClass="form-control" Height="100%">
                                To :
                                <asp:Label ID="Label4" Text="" runat="server"></asp:Label><br />
                                <br />
                                Subject :<asp:Label ID="Label5" Text="" runat="server"></asp:Label><br />
                                <br />
                                Message :<asp:Label ID="Label6" Text="" runat="server"></asp:Label><br />
                                <br />
                                Attachment :<asp:Label ID="Label7" Text="" runat="server"></asp:Label><br />
                                <br />

                            </asp:Panel>

                            <%-- ----------------------------------------------------SEARCH BOX PANAL--------------------------------------------- --%>
                            <asp:Panel ID="pnlSearch" runat="server" Visible="false" CssClass="form-control" Height="100%">
                                <asp:GridView ID="grdSearch" runat="server" Width="100%" AutoGenerateColumns="false" OnRowCommand="grdSearch_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="msgCheekbox" runat="server" CssClass="form-control" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgStarred" ImageUrl='<%#Eval("IsStarred","~/img/{0}.png") %>' runat="server" Height="30px" Width="30px" CommandName="star" CommandArgument='<%#Eval("MessageId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="UserId">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnMessage" Text='<%#Eval("AuthorId") %>' runat="server" CommandName="showMessage" CommandArgument='<%#Eval("MessageId") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Subject">
                                            <ItemTemplate>
                                                <%#Eval("Subject") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Message">
                                            <ItemTemplate>
                                                <%#Eval("Body") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <%#Eval("Date") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%-- <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnDelete" runat="server" Text="Delete" CommandName="del" CommandArgument='<%#Eval("MessageId") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    </Columns>


                                </asp:GridView>

                            </asp:Panel>

                            <asp:Panel ID="pnlSearchMessage" runat="server" Visible="false" CssClass="form-control" Height="100%">
                                From :
                                <asp:Label ID="Label12" Text="" runat="server"></asp:Label><br />
                                <br />
                                Subject :<asp:Label ID="Label13" Text="" runat="server"></asp:Label><br />
                                <br />
                                Message :<asp:Label ID="Label14" Text="" runat="server"></asp:Label><br />
                                <br />
                                <asp:Label ID="Label15" Text="" runat="server"></asp:Label><br />
                                <br />
                                <asp:Label ID="Label16" Text="" runat="server"></asp:Label>


                            </asp:Panel>

                            <%-- ----------------------------------------------------PANAL STARRED BOX------------------------------------------------------------------------------------------------------------- --%>
                            <asp:Panel ID="pnlStarred" runat="server" Visible="false" CssClass="form-control" Height="100%">
                                <asp:GridView ID="grdStarred" runat="server" Width="100%" AutoGenerateColumns="false" OnRowCommand="grdStarred_RowCommand">
                                    <Columns>

                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgStarred" ImageUrl='<%#Eval("IsStarred","~/img/{0}.png") %>' runat="server" Height="30px" Width="30px" CommandName="star" CommandArgument='<%#Eval("MessageId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Sender">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnSender" Text='<%#Eval("AuthorId") %>' runat="server" CommandName="showMessage" CommandArgument='<%#Eval("MessageId") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Subject">
                                            <ItemTemplate>
                                                <%#Eval("Subject") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Message">
                                            <ItemTemplate>
                                                <%#Eval("Body") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <%#Eval("Date") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnDelete" runat="server" Text="Delete" CommandName="del" CommandArgument='<%#Eval("MessageId") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    </Columns>


                                </asp:GridView>

                            </asp:Panel>

                            <asp:Panel ID="pnlStarredMessage" runat="server" Visible="false" CssClass="form-control" Height="100%">
                                From :
                                <asp:Label ID="Label17" Text="" runat="server"></asp:Label><br />
                                <br />
                                Subject :<asp:Label ID="Label18" Text="" runat="server"></asp:Label><br />
                                <br />
                                Message :<asp:Label ID="Label19" Text="" runat="server"></asp:Label><br />
                                <br />
                                <asp:Label ID="Label20" Text="" runat="server"></asp:Label><br />
                                <br />
                                <asp:Label ID="Label21" Text="" runat="server"></asp:Label>


                            </asp:Panel>

                        </td>
                    </tr>
                </table>
            </div>
        </form>
    </div>
</body>
</html>
