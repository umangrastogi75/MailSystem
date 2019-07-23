using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace DemoMailingSystem
{
    public partial class AfterLogin : System.Web.UI.Page
    {
        static int temp = 0;
        static string temp1 = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.Cookies["login"] != null)
                {
                    updateProfile();
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }

        }

        [System.Web.Script.Services.ScriptMethod()]
        [WebMethod]

        public static List<string> GetCompletionList(string prefixText, int count)
        {
            if (Connections.Connect())
            {
                List<string> countryNames = new List<string>();
                SqlCommand com = new SqlCommand("userAutoComplete", Connections.ReturnConnection());
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Search", prefixText);

                SqlDataAdapter da = new SqlDataAdapter(com);

                DataTable dt = new DataTable();

                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    countryNames.Add(row["UserId"].ToString());
                }
                //int i = 0;
                //while (i <= dt.Rows.Count)
                //{
                //    countryNames.Add(dt.Rows[0]["CountryName"].ToString());
                //    i += i;
                //}
                Connections.Disconnect();
                return countryNames;
            }
            else
            {
                return null;
            }
        }

        public void updateProfile()
        {
            if (Connections.Connect())
            {
                SqlCommand cmd = new SqlCommand("getDiplayPic", Connections.ReturnConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", Request.Cookies["login"]["Name"].ToString());

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);
                imgUser.ImageUrl = "~/profile/" + dt.Rows[0]["ImageName"].ToString();
                btnProfile.Text = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"];

            }
            Connections.Disconnect();

        }

        public void DefaultMessage()
        {
            if (temp == 1)
            {
                Connections.Connect();
                SqlCommand cmd2 = new SqlCommand("delDraftMessage", Connections.ReturnConnection());
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@msgid", temp1);
                cmd2.ExecuteNonQuery();
                Connections.Disconnect();
            }

        }


        protected void lnkComposeMail_Click(object sender, EventArgs e)
        {
            pnlCompose.Visible = true;
            pnlInbox.Visible = false;
            pnlShowMessage.Visible = false;
            Panel1.Visible = false;
            pnlSent.Visible = false;
            pnlTrashBox.Visible = false;
            pnlTrashMessage.Visible = false;
            pnlDraft.Visible = false;
            pnlSearch.Visible = false;
            pnlStarred.Visible = false;
            pnlStarredMessage.Visible = false;
            pnlSearchMessage.Visible = false;
            txtSubject.Text = "";
            txtSendTo.Text = "";
            txtMessage.Text = "";
            temp = 0;
        }

        protected void lnkInbox_Click(object sender, EventArgs e)
        {
            pnlInbox.Visible = true;
            pnlCompose.Visible = false;
            pnlShowMessage.Visible = false;
            Panel1.Visible = false;
            pnlSent.Visible = false;
            pnlTrashBox.Visible = false;
            pnlTrashMessage.Visible = false;
            pnlDraft.Visible = false;
            pnlSearch.Visible = false;
            pnlStarred.Visible = false;
            pnlSearchMessage.Visible = false;
            pnlStarredMessage.Visible = false;
            temp = 0;
            dataBindEmail();
        }

        protected void lnkStarred_Click(object sender, EventArgs e)
        {
            pnlStarred.Visible = true;
            pnlCompose.Visible = false;
            pnlInbox.Visible = false;
            pnlShowMessage.Visible = false;
            Panel1.Visible = false;
            pnlSent.Visible = false;
            pnlTrashBox.Visible = false;
            pnlTrashMessage.Visible = false;
            pnlDraft.Visible = false;
            pnlSearch.Visible = false;
            pnlStarredMessage.Visible = false;
            pnlSearchMessage.Visible = false;
            temp = 0;
            dataBindStarred();

        }

        protected void lnkSentMail_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            pnlCompose.Visible = false;
            pnlInbox.Visible = false;
            pnlShowMessage.Visible = false;
            pnlSent.Visible = false;
            pnlTrashBox.Visible = false;
            pnlTrashMessage.Visible = false;
            pnlDraft.Visible = false;
            pnlSearch.Visible = false;
            pnlStarred.Visible = false;
            pnlStarredMessage.Visible = false;
            pnlSearchMessage.Visible = false;
            temp = 0;

            dataBindSentEmail();
        }

        protected void lnkDraft_Click(object sender, EventArgs e)
        {
            pnlDraft.Visible = true;
            pnlCompose.Visible = false;
            pnlInbox.Visible = false;
            pnlShowMessage.Visible = false;
            Panel1.Visible = false;
            pnlSent.Visible = false;
            pnlTrashBox.Visible = false;
            pnlTrashMessage.Visible = false;
            pnlSearch.Visible = false;
            pnlStarred.Visible = false;
            pnlStarredMessage.Visible = false;
            pnlSearchMessage.Visible = false;
            temp = 0;
            dataBindDraftBox();
        }

        protected void lnkSpanm_Click(object sender, EventArgs e)
        {

            pnlCompose.Visible = false;
            pnlInbox.Visible = false;
            pnlShowMessage.Visible = false;
            Panel1.Visible = false;
            pnlSent.Visible = false;
            pnlTrashBox.Visible = false;
            pnlTrashMessage.Visible = false;
            pnlDraft.Visible = false;
            pnlSearch.Visible = false;
            pnlStarred.Visible = false;
            pnlStarredMessage.Visible = false;
            pnlSearchMessage.Visible = false;
            temp = 0;
        }

        protected void lnkTrash_Click(object sender, EventArgs e)
        {
            pnlTrashBox.Visible = true;
            pnlCompose.Visible = false;
            pnlInbox.Visible = false;
            pnlShowMessage.Visible = false;
            Panel1.Visible = false;
            pnlSent.Visible = false;
            pnlTrashMessage.Visible = false;
            pnlDraft.Visible = false;
            pnlSearch.Visible = false;
            pnlStarred.Visible = false;
            pnlStarredMessage.Visible = false;
            pnlSearchMessage.Visible = false;
            temp = 0;
            dataBindTrashBox();

        }

        protected void btnSignout_Click(object sender, EventArgs e)
        {
            Response.Cookies["login"].Expires = DateTime.Now.AddDays(-1d);
            Response.Redirect("Default.aspx");
        }
        public void dataBindEmail()
        {
            if (Connections.Connect())
            {
                SqlCommand cmd = new SqlCommand("getMessagesInbox", Connections.ReturnConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", Request.Cookies["login"]["Name"].ToString());

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["hasAttachment"].ToString() == "1")
                    {

                        SqlCommand cmd1 = new SqlCommand("getMessageAttachment", Connections.ReturnConnection());
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@userid", dt.Rows[0]["UserId"].ToString());
                        cmd1.Parameters.AddWithValue("@msgid", dt.Rows[0]["MessageId"].ToString());

                        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                        DataTable dt1 = new DataTable();
                        da.Fill(dt1);
                        grdMail.DataSource = dt1;
                    }
                    else
                    {

                        grdMail.DataSource = dt;


                    }
                    grdMail.DataBind();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (Convert.ToInt16(dt.Rows[i]["IsRead"]) == 0)
                        {
                            grdMail.Rows[i].BackColor = System.Drawing.Color.GreenYellow;
                            imgNewMail.Visible = true;

                        }

                    }
                    if (Convert.ToInt16(dt.Rows[0]["IsRead"]) != 0)
                    {
                        imgNewMail.Visible = false;
                    }


                }
                else
                {
                    Response.Write("<script>alert('No Message')</script>");
                    pnlInbox.Visible = false;
                }



            }
            Connections.Disconnect();
        }
        public void dataBindSentEmail()
        {
            if (Connections.Connect())
            {
                SqlCommand cmd = new SqlCommand("getMessagesSent", Connections.ReturnConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", Request.Cookies["login"]["Name"].ToString());

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();

                da.Fill(dt);
                if (dt.Tables[0].Rows.Count > 0)
                {

                    grdSent.DataSource = dt;
                    grdSent.DataBind();

                }
                else
                {

                    Response.Write("<script>alert('No Message')</script>");
                    pnlSent.Visible = false;
                    Panel1.Visible = false;

                }


            }
            Connections.Disconnect();
        }

        public void dataBindStarred()
        {
            if (Connections.Connect())
            {
                SqlCommand cmd = new SqlCommand("getMessagesStarred", Connections.ReturnConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", Request.Cookies["login"]["Name"].ToString());

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["hasAttachment"].ToString() == "1")
                    {

                        SqlCommand cmd1 = new SqlCommand("getMessageAttachmentStarred", Connections.ReturnConnection());
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@userid", dt.Rows[0]["UserId"].ToString());
                        cmd1.Parameters.AddWithValue("@msgid", dt.Rows[0]["MessageId"].ToString());

                        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                        DataTable dt1 = new DataTable();
                        da.Fill(dt1);
                        grdStarred.DataSource = dt1;
                    }
                    else
                    {

                        grdStarred.DataSource = dt;


                    }
                    grdStarred.DataBind();

                }
                else
                {
                    Response.Write("<script>alert('No Message')</script>");
                    pnlStarred.Visible = false;
                }



            }
            Connections.Disconnect();
        }
        public void dataBindTrashBox()
        {
            if (Connections.Connect())
            {
                SqlCommand cmd = new SqlCommand("getMessagesTrash", Connections.ReturnConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", Request.Cookies["login"]["Name"].ToString());

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    grdTrash.DataSource = dt;
                    grdTrash.DataBind();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (Convert.ToInt16(dt.Rows[i]["IsRead"]) == 0)
                        {
                            grdTrash.Rows[i].BackColor = System.Drawing.Color.GreenYellow;


                        }

                    }

                }
                else
                {
                    Response.Write("<script>alert('No Message')</script>");
                    pnlTrashBox.Visible = false;
                }




            }
            Connections.Disconnect();
        }
        public void dataBindDraftBox()
        {
            if (Connections.Connect())
            {
                SqlCommand cmd = new SqlCommand("getMessagesDraft", Connections.ReturnConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", Request.Cookies["login"]["Name"].ToString());

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    grdDraft.DataSource = dt;
                    grdDraft.DataBind();
                }
                else
                {

                    Response.Write("<script>alert('No Message')</script>");
                    pnlDraft.Visible = false;

                }
            }
            Connections.Disconnect();


        }
        protected void pnlComposebtnSend_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtSendTo.Text == "")
                {
                    Response.Write("<script>alert('Send To Field Can't be Empty..!!')</script>");
                    txtSendTo.Focus();
                }
                else if (txtSubject.Text == "")
                {
                    Response.Write("<script>alert('Subject Field Can't be Empty..!!')</script>");
                    txtSubject.Focus();

                }
                else if (txtMessage.Text == "")
                {
                    Response.Write("<script>alert('Message Field Can't be Empty..!!')</script>");
                    txtMessage.Focus();

                }

                else
                {
                    if (Connections.Connect())
                    {
                        SqlCommand cmd4 = new SqlCommand("composeUserCheeck", Connections.ReturnConnection());
                        cmd4.CommandType = CommandType.StoredProcedure;
                        cmd4.Parameters.AddWithValue("@userid", txtSendTo.Text);
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            string msgid = Guid.NewGuid().ToString();
                            SqlCommand cmd = new SqlCommand("messageDetailInsert", Connections.ReturnConnection());
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@userid", txtSendTo.Text);
                            cmd.Parameters.AddWithValue("@msgid", msgid);
                            cmd.Parameters.AddWithValue("@subject", txtSubject.Text);
                            cmd.Parameters.AddWithValue("@msgbody", txtMessage.Text);

                            if (fufiles.HasFiles)
                            {

                                string[] FileName = new string[10];
                                int l = fufiles.PostedFiles.Count();

                                for (int i = 0; i < l; i++)
                                {
                                    FileName[i] = Path.GetFileName(fufiles.PostedFiles[i].FileName);
                                    fufiles.PostedFiles[i].SaveAs(Server.MapPath("uploads/" + msgid + FileName[i]));

                                    SqlCommand cmd1 = new SqlCommand("messageAttachmentInsert", Connections.ReturnConnection());
                                    cmd1.CommandType = CommandType.StoredProcedure;
                                    cmd1.Parameters.AddWithValue("@msgid", msgid);
                                    cmd1.Parameters.AddWithValue("@filename", msgid + FileName[i]);

                                    SqlParameter message1 = new SqlParameter("@message", SqlDbType.VarChar, 1024);
                                    message1.Direction = ParameterDirection.Output;
                                    cmd1.Parameters.Add(message1);
                                    SqlParameter stat1 = new SqlParameter("@stat", SqlDbType.Int);
                                    stat1.Direction = ParameterDirection.Output;
                                    cmd1.Parameters.Add(stat1);
                                    cmd1.ExecuteNonQuery();

                                }
                                cmd.Parameters.AddWithValue("@hasattachment", 1);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@hasattachment", 0);
                            }
                            cmd.Parameters.AddWithValue("@authorid", Request.Cookies["login"]["Name"].ToString());

                            SqlParameter message = new SqlParameter("@message", SqlDbType.VarChar, 1024);
                            message.Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(message);
                            SqlParameter stat = new SqlParameter("@stat", SqlDbType.Int);
                            stat.Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(stat);
                            cmd.ExecuteNonQuery();
                            if (stat.Value.ToString() == "1")
                            {
                                Response.Write("<script>alert('" + message.Value.ToString() + "')</script>");
                                pnlCompose.Visible = false;
                                pnlInbox.Visible = true;

                                if (temp == 1)
                                {
                                    DefaultMessage();

                                    temp = 0;
                                    temp1 = "";
                                }
                            }
                            else
                            {
                                Response.Write("<script>alert('" + message.Value.ToString() + "')</script>");
                                pnlCompose.Visible = true;
                                pnlInbox.Visible = false;
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Message Not Sent..!! UserId Does not exist')</script>");
                            pnlCompose.Visible = true;
                            pnlInbox.Visible = false;
                            txtSendTo.Text = "";
                            txtSendTo.Focus();

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            finally
            {
                Connections.Disconnect();
            }
        }
        protected void pnlComposebtnSaveDraft_Click(object sender, EventArgs e)
        {
            temp = 1;
            try
            {
                if (txtSubject.Text == "")
                {
                    Response.Write("<script>alert('Subject Field Can't be Empty..!!')</script>");
                    txtSubject.Focus();

                }
                else if (txtMessage.Text == "")
                {
                    Response.Write("<script>alert('Message Field Can't be Empty..!!')</script>");
                    txtMessage.Focus();

                }

                else
                {


                    if (Connections.Connect())
                    {
                        string msgid = Guid.NewGuid().ToString();
                        SqlCommand cmd = new SqlCommand("messageSaveDraft", Connections.ReturnConnection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@userid", txtSendTo.Text);
                        cmd.Parameters.AddWithValue("@msgid", msgid);
                        cmd.Parameters.AddWithValue("@subject", txtSubject.Text);
                        cmd.Parameters.AddWithValue("@msgbody", txtMessage.Text);

                        if (fufiles.HasFiles)
                        {

                            string[] FileName = new string[10];
                            int l = fufiles.PostedFiles.Count();

                            for (int i = 0; i < l; i++)
                            {
                                FileName[i] = Path.GetFileName(fufiles.PostedFiles[i].FileName);
                                fufiles.PostedFiles[i].SaveAs(Server.MapPath("uploads/" + msgid + FileName[i]));

                                SqlCommand cmd1 = new SqlCommand("messageAttachmentInsert", Connections.ReturnConnection());
                                cmd1.CommandType = CommandType.StoredProcedure;
                                cmd1.Parameters.AddWithValue("@msgid", msgid);
                                cmd1.Parameters.AddWithValue("@filename", msgid + FileName[i]);

                                SqlParameter message1 = new SqlParameter("@message", SqlDbType.VarChar, 1024);
                                message1.Direction = ParameterDirection.Output;
                                cmd1.Parameters.Add(message1);
                                SqlParameter stat1 = new SqlParameter("@stat", SqlDbType.Int);
                                stat1.Direction = ParameterDirection.Output;
                                cmd1.Parameters.Add(stat1);
                                cmd1.ExecuteNonQuery();

                            }
                            cmd.Parameters.AddWithValue("@hasattachment", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@hasattachment", 0);
                        }
                        cmd.Parameters.AddWithValue("@authorid", Request.Cookies["login"]["Name"].ToString());



                        SqlParameter message = new SqlParameter("@message", SqlDbType.VarChar, 1024);
                        message.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(message);
                        SqlParameter stat = new SqlParameter("@stat", SqlDbType.Int);
                        stat.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(stat);
                        cmd.ExecuteNonQuery();

                        if (temp == 1)
                        {
                            DefaultMessage();

                            temp = 0;
                            temp1 = "";
                        }
                        if (stat.Value.ToString() == "1")
                        {
                            Response.Write("<script>alert('" + message.Value.ToString() + "')</script>");
                            pnlCompose.Visible = false;
                            pnlInbox.Visible = true;
                        }
                        else
                        {
                            Response.Write("<script>alert('" + message.Value.ToString() + "')</script>");
                            pnlCompose.Visible = true;
                            pnlInbox.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            finally
            {
                Connections.Disconnect();
            }
        }

        protected void grdMail_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "showMessage")
            {

                try
                {
                    if (Connections.Connect())
                    {

                        SqlCommand cmd = new SqlCommand("fullMessageShow", Connections.ReturnConnection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@msgid", e.CommandArgument);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows[0]["hasAttachment"].ToString() == "1")
                        {

                            SqlCommand cmd1 = new SqlCommand("getMessageAttachment", Connections.ReturnConnection());
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("@userid", dt.Rows[0]["UserId"].ToString());
                            cmd1.Parameters.AddWithValue("@msgid", dt.Rows[0]["MessageId"].ToString());

                            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                            DataTable dt1 = new DataTable();
                            da1.Fill(dt1);
                            pnlShowMessage.Visible = true;
                            pnlCompose.Visible = false;
                            pnlInbox.Visible = false;
                            lblShowSender.Text = dt1.Rows[0]["AuthorId"].ToString();
                            lblShowSubject.Text = dt1.Rows[0]["Subject"].ToString();
                            lblShowMessage.Text = dt1.Rows[0]["Body"].ToString();
                            lblShowAttachment.Text = dt1.Rows[0]["NameOfFile"].ToString();
                            lblShowDate.Text = dt1.Rows[0]["Date"].ToString();

                        }
                        else
                        {
                            pnlShowMessage.Visible = true;
                            pnlCompose.Visible = false;
                            pnlInbox.Visible = false;
                            lblShowSender.Text = dt.Rows[0]["AuthorId"].ToString();
                            lblShowSubject.Text = dt.Rows[0]["Subject"].ToString();
                            lblShowMessage.Text = dt.Rows[0]["Body"].ToString();
                            lblShowAttachment.Text = "No Attachment";
                            lblShowDate.Text = dt.Rows[0]["Date"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
                finally
                {
                    Connections.Disconnect();
                }
            }
            else if (e.CommandName == "del")
            {
                try
                {
                    if (Connections.Connect())
                    {

                        SqlCommand cmd = new SqlCommand("inboxMessageDelete", Connections.ReturnConnection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@userid", Request.Cookies["login"]["Name"].ToString());
                        cmd.Parameters.AddWithValue("@msgid", e.CommandArgument);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows[0]["hasAttachment"].ToString() == "1")
                        {

                            SqlCommand cmd1 = new SqlCommand("inboxDeleteAttachment", Connections.ReturnConnection());
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("@userid", dt.Rows[0]["UserId"].ToString());
                            cmd1.Parameters.AddWithValue("@msgid", dt.Rows[0]["MessageId"].ToString());
                            cmd1.ExecuteNonQuery();

                        }
                        else
                        {
                            SqlCommand cmd2 = new SqlCommand("inboxDelMessageData", Connections.ReturnConnection());
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.AddWithValue("@userid", dt.Rows[0]["UserId"].ToString());
                            cmd2.Parameters.AddWithValue("@msgid", dt.Rows[0]["MessageId"].ToString());
                            int i = cmd2.ExecuteNonQuery();
                            if (i >= 1)
                            {
                                Response.Write("<script>alert('Message Deleted Sucessfully')</script>");
                            }
                            else
                            {
                                Response.Write("<script>alert('Message Not Deleted..!! ')</script>");
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Message Not Deleted..!! ')</script>");
                }
                finally
                {
                    Connections.Disconnect();
                    dataBindEmail();
                }
            }
            else if (e.CommandName == "star")
            {
                try
                {
                    if (Connections.Connect())
                    {

                        SqlCommand cmd = new SqlCommand("getMessageStarred", Connections.ReturnConnection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@userid", Request.Cookies["login"]["Name"].ToString());
                        cmd.Parameters.AddWithValue("@msgid", e.CommandArgument);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (Convert.ToInt16(dt.Rows[0]["IsStarred"]) == 0)
                        {
                            SqlCommand cmd1 = new SqlCommand("inboxMessageStarred", Connections.ReturnConnection());
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("@userid", Request.Cookies["login"]["Name"].ToString());
                            cmd1.Parameters.AddWithValue("@msgid", e.CommandArgument);
                            int i = cmd1.ExecuteNonQuery();
                            if (i >= 1)
                            {
                                dataBindEmail();
                            }

                        }
                        else
                        {
                            SqlCommand cmd2 = new SqlCommand("inboxMessageUnstarred", Connections.ReturnConnection());
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.AddWithValue("@userid", Request.Cookies["login"]["Name"].ToString());
                            cmd2.Parameters.AddWithValue("@msgid", e.CommandArgument);
                            int i = cmd2.ExecuteNonQuery();
                            if (i >= 1)
                            {
                                dataBindEmail();
                            }
                        }

                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    Connections.Disconnect();
                }

            }
        }

        protected void grdSent_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "showMessage")
            {

                try
                {
                    if (Connections.Connect())
                    {
                        string msgid = Guid.NewGuid().ToString();
                        SqlCommand cmd = new SqlCommand("fullMessageShowSend", Connections.ReturnConnection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@msgid", e.CommandArgument);
                        cmd.Parameters.AddWithValue("@userid", Request.Cookies["login"]["Name"].ToString());
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows[0]["hasAttachment"].ToString() == "1")
                        {

                            SqlCommand cmd1 = new SqlCommand("getSentMessageAttachment", Connections.ReturnConnection());
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("@userid", dt.Rows[0]["UserId"].ToString());
                            cmd1.Parameters.AddWithValue("@msgid", dt.Rows[0]["MessageId"].ToString());

                            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                            DataTable dt1 = new DataTable();
                            da1.Fill(dt1);
                            pnlSent.Visible = true;
                            pnlCompose.Visible = false;
                            pnlInbox.Visible = false;
                            Panel1.Visible = false;

                            Label1.Text = dt1.Rows[0]["UserId"].ToString();
                            Label2.Text = dt1.Rows[0]["Subject"].ToString();
                            Label3.Text = dt1.Rows[0]["Body"].ToString();
                            Lable4.Text = dt1.Rows[0]["NameOfFile"].ToString();
                            Lable5.Text = dt1.Rows[0]["Date"].ToString();
                        }
                        else
                        {
                            pnlSent.Visible = true;
                            pnlShowMessage.Visible = false;
                            pnlCompose.Visible = false;
                            pnlInbox.Visible = false;
                            Panel1.Visible = false;
                            Label1.Text = dt.Rows[0]["UserId"].ToString();
                            Label2.Text = dt.Rows[0]["Subject"].ToString();
                            Label3.Text = dt.Rows[0]["Body"].ToString();
                            Lable4.Text = "No Attachment";
                            Lable5.Text = dt.Rows[0]["Date"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
                finally
                {
                    Connections.Disconnect();
                }
            }
            else if (e.CommandName == "del")
            {
                try
                {
                    if (Connections.Connect())
                    {

                        SqlCommand cmd = new SqlCommand("sentboxMessageDelete", Connections.ReturnConnection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@userid", Request.Cookies["login"]["Name"].ToString());
                        cmd.Parameters.AddWithValue("@msgid", e.CommandArgument);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows[0]["hasAttachment"].ToString() == "1")
                        {

                            SqlCommand cmd1 = new SqlCommand("inboxDeleteAttachment", Connections.ReturnConnection());
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("@userid", dt.Rows[0]["UserId"].ToString());
                            cmd1.Parameters.AddWithValue("@msgid", dt.Rows[0]["MessageId"].ToString());
                            cmd1.ExecuteNonQuery();

                        }
                        else
                        {
                            SqlCommand cmd2 = new SqlCommand("inboxDelMessageData", Connections.ReturnConnection());
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.AddWithValue("@userid", dt.Rows[0]["UserId"].ToString());
                            cmd2.Parameters.AddWithValue("@msgid", dt.Rows[0]["MessageId"].ToString());
                            int i = cmd2.ExecuteNonQuery();
                            if (i >= 1)
                            {
                                Response.Write("<script>alert('Message Deleted Sucessfully')</script>");
                            }
                            else
                            {
                                Response.Write("<script>alert('Message Not Deleted..!! ')</script>");
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Message Not Deleted..!! ')</script>");
                }
                finally
                {
                    Connections.Disconnect();
                    dataBindSentEmail();
                }
            }
            else if (e.CommandName == "star")
            {
                try
                {
                    if (Connections.Connect())
                    {

                        SqlCommand cmd = new SqlCommand("getMessagesSentStarred", Connections.ReturnConnection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@userid", Request.Cookies["login"]["Name"].ToString());
                        cmd.Parameters.AddWithValue("@msgid", e.CommandArgument);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (Convert.ToInt16(dt.Rows[0]["IsStarred"]) == 0)
                        {
                            SqlCommand cmd1 = new SqlCommand("sentboxMessageStarred", Connections.ReturnConnection());
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("@userid", Request.Cookies["login"]["Name"].ToString());
                            cmd1.Parameters.AddWithValue("@msgid", e.CommandArgument);
                            int i = cmd1.ExecuteNonQuery();
                            if (i >= 1)
                            {
                                dataBindSentEmail();
                            }

                        }
                        else
                        {
                            SqlCommand cmd2 = new SqlCommand("sentboxMessageUnStarred", Connections.ReturnConnection());
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.AddWithValue("@userid", Request.Cookies["login"]["Name"].ToString());
                            cmd2.Parameters.AddWithValue("@msgid", e.CommandArgument);
                            int i = cmd2.ExecuteNonQuery();
                            if (i >= 1)
                            {
                                dataBindSentEmail();
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
                finally
                {
                    Connections.Disconnect();
                    dataBindSentEmail();

                }
            }
        }
        protected void grdTrash_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "res")
            {

                try
                {
                    if (Connections.Connect())
                    {
                        SqlCommand cmd = new SqlCommand("messageRestor", Connections.ReturnConnection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@msgid", e.CommandArgument);
                        cmd.Parameters.AddWithValue("@userid", Request.Cookies["login"]["Name"].ToString());
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            SqlCommand cmd1 = new SqlCommand("messageRestorData", Connections.ReturnConnection());
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("@userid", dt.Rows[0]["UserId"].ToString());
                            cmd1.Parameters.AddWithValue("@msgid", dt.Rows[0]["MessageId"].ToString());
                            cmd1.Parameters.AddWithValue("@current", dt.Rows[0]["LastCatagory"].ToString());
                            cmd1.Parameters.AddWithValue("@last", dt.Rows[0]["CurrentCatagory"].ToString());
                            int i = cmd1.ExecuteNonQuery();
                            if (i >= 1)
                            {
                                Response.Write("<script>alert('Message Restored Sucessfully')</script>");
                            }
                            else
                            {
                                Response.Write("<script>alert('Message Not Restored..!! ')</script>");
                            }

                        }


                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Message Not Restored..!! ')</script>");
                }
                finally
                {
                    Connections.Disconnect();
                    dataBindTrashBox();
                }
            }
            else if (e.CommandName == "del")
            {
                try
                {
                    if (Connections.Connect())
                    {

                        SqlCommand cmd = new SqlCommand("trashboxMessageDelete", Connections.ReturnConnection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@userid", Request.Cookies["login"]["Name"].ToString());
                        cmd.Parameters.AddWithValue("@msgid", e.CommandArgument);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows[0]["hasAttachment"].ToString() == "1")
                        {

                            SqlCommand cmd1 = new SqlCommand("trashDeleteAttachment", Connections.ReturnConnection());
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("@userid", dt.Rows[0]["UserId"].ToString());
                            cmd1.Parameters.AddWithValue("@msgid", dt.Rows[0]["MessageId"].ToString());
                            cmd1.ExecuteNonQuery();

                        }
                        else
                        {
                            SqlCommand cmd2 = new SqlCommand("trashDelMessageData", Connections.ReturnConnection());
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.AddWithValue("@userid", dt.Rows[0]["UserId"].ToString());
                            cmd2.Parameters.AddWithValue("@msgid", dt.Rows[0]["MessageId"].ToString());
                            int i = cmd2.ExecuteNonQuery();
                            if (i >= 1)
                            {
                                Response.Write("<script>alert('Message Deleted Sucessfully')</script>");
                            }
                            else
                            {
                                Response.Write("<script>alert('Message Not Deleted..!! ')</script>");
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Message Not Deleted..!! ')</script>");
                }
                finally
                {
                    Connections.Disconnect();
                    dataBindTrashBox();
                }
            }
        }

        protected void grdDraft_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "snd")
            {

                try
                {
                    if (Connections.Connect())
                    {
                        SqlCommand cmd = new SqlCommand("getComposeMessage", Connections.ReturnConnection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@msgid", e.CommandArgument);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["hasAttachment"].ToString() == "1")
                            {
                                //    SqlCommand cmd1 = new SqlCommand("delDraftMessageAttach", Connections.ReturnConnection());
                                //    cmd1.CommandType = CommandType.StoredProcedure;
                                //    cmd1.Parameters.AddWithValue("@msgid", e.CommandArgument);
                                //    cmd1.ExecuteNonQuery();
                                //    pnlCompose.Visible = true;
                                txtSubject.Text = dt.Rows[0]["Subject"].ToString();
                                txtMessage.Text = dt.Rows[0]["Body"].ToString();
                                txtSendTo.Focus();
                                pnlDraft.Visible = false;
                                temp = 1;
                                temp1 = e.CommandArgument.ToString();

                            }
                            else
                            {

                                //SqlCommand cmd2 = new SqlCommand("delDraftMessage", Connections.ReturnConnection());
                                //cmd2.CommandType = CommandType.StoredProcedure;
                                //cmd2.Parameters.AddWithValue("@msgid", e.CommandArgument);
                                //cmd2.ExecuteNonQuery();
                                pnlCompose.Visible = true;
                                txtSubject.Text = dt.Rows[0]["Subject"].ToString();
                                txtMessage.Text = dt.Rows[0]["Body"].ToString();
                                pnlDraft.Visible = false;
                                txtSendTo.Focus();
                                temp = 1;
                                temp1 = e.CommandArgument.ToString();
                            }
                        }
                        else
                        {

                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
                finally
                {
                    Connections.Disconnect();
                }

            }
            else if (e.CommandName == "del")
            {

                try
                {
                    if (Connections.Connect())
                    {

                        SqlCommand cmd = new SqlCommand("draftboxMessageDelete", Connections.ReturnConnection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@userid", Request.Cookies["login"]["Name"].ToString());
                        cmd.Parameters.AddWithValue("@msgid", e.CommandArgument);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows[0]["hasAttachment"].ToString() == "1")
                        {

                            SqlCommand cmd1 = new SqlCommand("inboxDeleteAttachment", Connections.ReturnConnection());
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("@userid", dt.Rows[0]["UserId"].ToString());
                            cmd1.Parameters.AddWithValue("@msgid", dt.Rows[0]["MessageId"].ToString());
                            cmd1.ExecuteNonQuery();

                        }
                        else
                        {
                            SqlCommand cmd2 = new SqlCommand("inboxDelMessageData", Connections.ReturnConnection());
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.AddWithValue("@userid", dt.Rows[0]["UserId"].ToString());
                            cmd2.Parameters.AddWithValue("@msgid", dt.Rows[0]["MessageId"].ToString());
                            int i = cmd2.ExecuteNonQuery();
                            if (i >= 1)
                            {
                                Response.Write("<script>alert('Message Deleted Sucessfully')</script>");
                            }
                            else
                            {
                                Response.Write("<script>alert('Message Not Deleted..!! ')</script>");
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Message Not Deleted..!! ')</script>");
                }
                finally
                {
                    Connections.Disconnect();
                    dataBindDraftBox();
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            pnlCompose.Visible = false;
            pnlInbox.Visible = false;
            pnlShowMessage.Visible = false;
            Panel1.Visible = false;
            pnlSent.Visible = false;
            pnlTrashBox.Visible = false;
            pnlTrashMessage.Visible = false;
            pnlDraft.Visible = false;
            pnlStarred.Visible = false;
            pnlStarredMessage.Visible = false;
            pnlSearchMessage.Visible = false;
            try
            {
                if (Connections.Connect())
                {
                    if (txtSearch.Text == "")
                    {
                        txtSearch.Focus();
                    }
                    else
                    {
                        Connections.Connect();
                        SqlCommand cmd = new SqlCommand("messageSearch", Connections.ReturnConnection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.Parameters.AddWithValue("@userid", Request.Cookies["login"]["Name"].ToString());
                        cmd.Parameters.AddWithValue("@text", txtSearch.Text);
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da1.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            pnlSearch.Visible = true;
                            pnlDraft.Visible = false;
                            grdSearch.DataSource = dt;
                            grdSearch.DataBind();

                        }
                        else
                        {
                            grdSearch.DataSource = null;
                            grdSearch.DataBind();
                            txtSearch.Text = "Record not found !!";
                        }
                    }


                }


            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connections.Disconnect();
            }

        }

        protected void grdStarred_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "showMessage")
            {

                try
                {
                    if (Connections.Connect())
                    {

                        SqlCommand cmd = new SqlCommand("fullMessageShow", Connections.ReturnConnection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@msgid", e.CommandArgument);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows[0]["hasAttachment"].ToString() == "1")
                        {

                            SqlCommand cmd1 = new SqlCommand("getMessageAttachmentStarred", Connections.ReturnConnection());
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("@userid", dt.Rows[0]["UserId"].ToString());
                            cmd1.Parameters.AddWithValue("@msgid", dt.Rows[0]["MessageId"].ToString());

                            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                            DataTable dt1 = new DataTable();
                            da1.Fill(dt1);
                            pnlStarredMessage.Visible = true;
                            pnlStarred.Visible = false;
                            Label17.Text = dt1.Rows[0]["AuthorId"].ToString();
                            Label18.Text = dt1.Rows[0]["Subject"].ToString();
                            Label19.Text = dt1.Rows[0]["Body"].ToString();
                            Label20.Text = dt1.Rows[0]["NameOfFile"].ToString();
                            Label21.Text = dt1.Rows[0]["Date"].ToString();

                        }
                        else
                        {
                            pnlStarredMessage.Visible = true;
                            pnlStarred.Visible = false;
                            pnlInbox.Visible = false;
                            Label17.Text = dt.Rows[0]["AuthorId"].ToString();
                            Label18.Text = dt.Rows[0]["Subject"].ToString();
                            Label19.Text = dt.Rows[0]["Body"].ToString();
                            Label20.Text = "No Attachment";
                            Label21.Text = dt.Rows[0]["Date"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
                finally
                {
                    Connections.Disconnect();
                }
            }
            else if (e.CommandName == "del")
            {
                try
                {
                    if (Connections.Connect())
                    {

                        SqlCommand cmd = new SqlCommand("starredMessageDelete", Connections.ReturnConnection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@userid", Request.Cookies["login"]["Name"].ToString());
                        cmd.Parameters.AddWithValue("@msgid", e.CommandArgument);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows[0]["hasAttachment"].ToString() == "1")
                        {

                            SqlCommand cmd1 = new SqlCommand("inboxDeleteAttachment", Connections.ReturnConnection());
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("@userid", dt.Rows[0]["UserId"].ToString());
                            cmd1.Parameters.AddWithValue("@msgid", dt.Rows[0]["MessageId"].ToString());
                            cmd1.ExecuteNonQuery();

                        }
                        else
                        {
                            SqlCommand cmd2 = new SqlCommand("inboxDelMessageData", Connections.ReturnConnection());
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.AddWithValue("@userid", dt.Rows[0]["UserId"].ToString());
                            cmd2.Parameters.AddWithValue("@msgid", dt.Rows[0]["MessageId"].ToString());
                            int i = cmd2.ExecuteNonQuery();
                            if (i >= 1)
                            {
                                Response.Write("<script>alert('Message Deleted Sucessfully')</script>");
                            }
                            else
                            {
                                Response.Write("<script>alert('Message Not Deleted..!! ')</script>");
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Message Not Deleted..!! ')</script>");
                }
                finally
                {
                    Connections.Disconnect();
                    dataBindStarred();
                }
            }
        }

        protected void pnlComposebtnDiscard_Click(object sender, EventArgs e)
        {
            temp = 0;
            DefaultMessage();
            pnlCompose.Visible = false;
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            fileuploader.Visible = true;
            btnProfileUpload.Visible = true;
            btnCancle.Visible = true;


        }

        protected void btnProfileUpload_Click(object sender, EventArgs e)
        {
            if (fileuploader.HasFile)
            {
                Connections.Connect();
                string imgname = Path.GetFileName(fileuploader.PostedFile.FileName).ToString();
                fileuploader.SaveAs(Server.MapPath("profile/" + imgname));
                string imgid = Guid.NewGuid().ToString();
                SqlCommand cmd = new SqlCommand("imageUpload", Connections.ReturnConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", Request.Cookies["login"]["Name"].ToString());
                cmd.Parameters.AddWithValue("@imgname", imgname);
                cmd.Parameters.AddWithValue("@imgid", imgid);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    fileuploader.Visible = false;
                    btnProfileUpload.Visible = false;
                    btnCancle.Visible = false;
                    Response.Write("<script>alert('Uploaded Sucessfully')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Image Uploaded Fail...!!')</script>");
                }
                Connections.Disconnect();
                updateProfile();
            }
            else
            {
                Response.Write("<script>alert('Please Select the file')</script>");
                fileuploader.Focus();
            }


        }

        protected void grdSearch_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "showMessage")
            {

                try
                {
                    if (Connections.Connect())
                    {

                        SqlCommand cmd = new SqlCommand("fullMessageShow", Connections.ReturnConnection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@msgid", e.CommandArgument);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows[0]["hasAttachment"].ToString() == "1")
                        {

                            SqlCommand cmd1 = new SqlCommand("getMessageAttachment", Connections.ReturnConnection());
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("@userid", dt.Rows[0]["UserId"].ToString());
                            cmd1.Parameters.AddWithValue("@msgid", dt.Rows[0]["MessageId"].ToString());

                            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                            DataTable dt1 = new DataTable();
                            da1.Fill(dt1);
                            pnlSearchMessage.Visible = true;
                            pnlSearch.Visible = false;
                            pnlInbox.Visible = false;
                            Label12.Text = dt1.Rows[0]["AuthorId"].ToString();
                            Label13.Text = dt1.Rows[0]["Subject"].ToString();
                            Label14.Text = dt1.Rows[0]["Body"].ToString();
                            Label15.Text = dt1.Rows[0]["NameOfFile"].ToString();
                            Label16.Text = dt1.Rows[0]["Date"].ToString();

                        }
                        else
                        {
                            pnlSearchMessage.Visible = true;
                            pnlSearch.Visible = false;
                            pnlInbox.Visible = false;
                            Label12.Text = dt.Rows[0]["AuthorId"].ToString();
                            Label13.Text = dt.Rows[0]["Subject"].ToString();
                            Label14.Text = dt.Rows[0]["Body"].ToString();
                            Label15.Text = "No Attachment";
                            Label16.Text = dt.Rows[0]["Date"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
                finally
                {
                    Connections.Disconnect();
                }
            }
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            fileuploader.Visible = false;
            btnProfileUpload.Visible = false;
            btnCancle.Visible = false;
        }

        protected void btnInboxDeleteCheeked_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                foreach (GridViewRow gvrow in grdMail.Rows)
                {

                    CheckBox chkdelete = (CheckBox)gvrow.FindControl("msgCheekbox") as CheckBox;

                    if (chkdelete.Checked)
                    {
                        HiddenField field = (HiddenField)gvrow.FindControl("hff");
                        string msgid = field.Value.ToString();
                        try
                        {
                            if (Connections.Connect())
                            {

                                SqlCommand cmd = new SqlCommand("inboxMessageDelete", Connections.ReturnConnection());
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@userid", Request.Cookies["login"]["Name"].ToString());
                                cmd.Parameters.AddWithValue("@msgid", msgid);
                                SqlDataAdapter da = new SqlDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                if (dt.Rows[0]["hasAttachment"].ToString() == "1")
                                {

                                    SqlCommand cmd1 = new SqlCommand("inboxDeleteAttachment", Connections.ReturnConnection());
                                    cmd1.CommandType = CommandType.StoredProcedure;
                                    cmd1.Parameters.AddWithValue("@userid", dt.Rows[0]["UserId"].ToString());
                                    cmd1.Parameters.AddWithValue("@msgid", dt.Rows[0]["MessageId"].ToString());
                                    cmd1.ExecuteNonQuery();

                                }
                                else
                                {
                                    SqlCommand cmd2 = new SqlCommand("inboxDelMessageData", Connections.ReturnConnection());
                                    cmd2.CommandType = CommandType.StoredProcedure;
                                    cmd2.Parameters.AddWithValue("@userid", dt.Rows[0]["UserId"].ToString());
                                    cmd2.Parameters.AddWithValue("@msgid", dt.Rows[0]["MessageId"].ToString());
                                    i = cmd2.ExecuteNonQuery();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Response.Write("<script>alert('Message Not Deleted..!! ')</script>");
                        }
                        finally
                        {
                            Connections.Disconnect();
                            dataBindEmail();
                        }

                    }
                    else
                    {

                    }
                }
                if (i >= 1)
                {
                    Response.Write("<script>alert('Message Deleted Sucessfully')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Please select the message you want to delete ')</script>");
                }

                dataBindEmail();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            finally
            {
                Connections.Disconnect();
                dataBindEmail();
            }
        }

        protected void btnDeleteSent_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                foreach (GridViewRow gvrow in grdSent.Rows)
                {

                    CheckBox chkdelete = (CheckBox)gvrow.FindControl("msgCheekbox") as CheckBox;

                    if (chkdelete.Checked)
                    {
                        HiddenField field = (HiddenField)gvrow.FindControl("hffSent");
                        string msgid = field.Value.ToString();
                        try
                        {
                            if (Connections.Connect())
                            {

                                SqlCommand cmd = new SqlCommand("sentboxMessageDelete", Connections.ReturnConnection());
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@userid", Request.Cookies["login"]["Name"].ToString());
                                cmd.Parameters.AddWithValue("@msgid", msgid);
                                SqlDataAdapter da = new SqlDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                if (dt.Rows[0]["hasAttachment"].ToString() == "1")
                                {

                                    SqlCommand cmd1 = new SqlCommand("inboxDeleteAttachment", Connections.ReturnConnection());
                                    cmd1.CommandType = CommandType.StoredProcedure;
                                    cmd1.Parameters.AddWithValue("@userid", dt.Rows[0]["UserId"].ToString());
                                    cmd1.Parameters.AddWithValue("@msgid", dt.Rows[0]["MessageId"].ToString());
                                    cmd1.ExecuteNonQuery();

                                }
                                else
                                {
                                    SqlCommand cmd2 = new SqlCommand("inboxDelMessageData", Connections.ReturnConnection());
                                    cmd2.CommandType = CommandType.StoredProcedure;
                                    cmd2.Parameters.AddWithValue("@userid", dt.Rows[0]["UserId"].ToString());
                                    cmd2.Parameters.AddWithValue("@msgid", dt.Rows[0]["MessageId"].ToString());
                                    i = cmd2.ExecuteNonQuery();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Response.Write("<script>alert('Message Not Deleted..!! ')</script>");
                        }
                        finally
                        {
                            Connections.Disconnect();
                            dataBindSentEmail();
                        }

                    }
                    else
                    {

                    }
                }
                if (i >= 1)
                {
                    Response.Write("<script>alert('Message Deleted Sucessfully')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Message Not Deleted..!! ')</script>");
                }

                dataBindSentEmail();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            finally
            {
                Connections.Disconnect();
                dataBindSentEmail();
            }
        }

        protected void btnDeleteDraft_Click(object sender, EventArgs e)
        {

            int i = 0;
            try
            {
                foreach (GridViewRow gvrow in grdDraft.Rows)
                {

                    CheckBox chkdelete = (CheckBox)gvrow.FindControl("msgCheekbox") as CheckBox;

                    if (chkdelete.Checked)
                    {
                        HiddenField field = (HiddenField)gvrow.FindControl("hffDraft");
                        string msgid = field.Value.ToString();
                        try
                        {
                            if (Connections.Connect())
                            {

                                SqlCommand cmd = new SqlCommand("draftboxMessageDelete", Connections.ReturnConnection());
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@userid", Request.Cookies["login"]["Name"].ToString());
                                cmd.Parameters.AddWithValue("@msgid", msgid);
                                SqlDataAdapter da = new SqlDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                if (dt.Rows[0]["hasAttachment"].ToString() == "1")
                                {

                                    SqlCommand cmd1 = new SqlCommand("inboxDeleteAttachment", Connections.ReturnConnection());
                                    cmd1.CommandType = CommandType.StoredProcedure;
                                    cmd1.Parameters.AddWithValue("@userid", dt.Rows[0]["UserId"].ToString());
                                    cmd1.Parameters.AddWithValue("@msgid", dt.Rows[0]["MessageId"].ToString());
                                    cmd1.ExecuteNonQuery();

                                }
                                else
                                {
                                    SqlCommand cmd2 = new SqlCommand("inboxDelMessageData", Connections.ReturnConnection());
                                    cmd2.CommandType = CommandType.StoredProcedure;
                                    cmd2.Parameters.AddWithValue("@userid", dt.Rows[0]["UserId"].ToString());
                                    cmd2.Parameters.AddWithValue("@msgid", dt.Rows[0]["MessageId"].ToString());
                                    i = cmd2.ExecuteNonQuery();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Response.Write("<script>alert('Message Not Deleted..!! ')</script>");
                        }
                    }
                }
                if (i >= 1)
                {
                    Response.Write("<script>alert('Message Deleted Sucessfully')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Message Not Deleted..!! ')</script>");
                }

                dataBindDraftBox();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            finally
            {
                Connections.Disconnect();
                dataBindDraftBox();
            }
        }
    }



}
