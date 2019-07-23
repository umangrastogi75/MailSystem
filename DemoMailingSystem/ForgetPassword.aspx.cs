using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DemoMailingSystem
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResetpassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (Connections.Connect())
                {

                    if (btnResetpassword.Text == "Next")
                    {
                        SqlCommand cmd = new SqlCommand("forgetPasswodGetId", Connections.ReturnConnection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@userid", txtuserid.Text);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["Question"].ToString() == "1")
                            {
                                lblQuestion1.Visible = true;
                                lblQuestion.Visible = true;
                                lblAnswer.Visible = true;
                                txtAnswer.Visible = true;
                                btnResetpassword.Text = "Change Paswword";
                                lblQuestion.Text = "Your First School Name";

                            }
                            else if (dt.Rows[0]["Question"].ToString() == "2")
                            {

                                lblQuestion1.Visible = true;
                                lblQuestion.Visible = true;
                                lblAnswer.Visible = true;
                                txtAnswer.Visible = true;
                                btnResetpassword.Text = "Change Paswword";
                                lblQuestion.Text = "Your Pet Name";
                            }
                            else if (dt.Rows[0]["Question"].ToString() == "3")
                            {
                                lblQuestion1.Visible = true;
                                lblQuestion.Visible = true;
                                lblAnswer.Visible = true;
                                txtAnswer.Visible = true;
                                btnResetpassword.Text = "Change Paswword";
                                lblQuestion.Text = "Your Born Place";
                            }


                        }
                        else
                        {
                            Response.Write("<script>alert('User Id does not exist')</script>");
                        }

                    }
                    else if (btnResetpassword.Text == "Change Paswword")
                    {

                        SqlCommand cmd = new SqlCommand("forgetPasswodGetId", Connections.ReturnConnection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@userid", txtuserid.Text);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            if (txtAnswer.Text == dt.Rows[0]["Answer"].ToString())
                            {
                                lblQuestion.Visible = false;
                                lbluserid.Visible = false;
                                txtuserid.Visible = false;
                                lblQuestion1.Visible = false;
                                txtAnswer.Visible = true;
                                txtAnswer.Text = "";
                                lblAnswer.Text = "Create new password :";
                                txtAnswer.Visible = true;
                                btnResetpassword.Text = "Save";

                            }
                            else
                            {
                                Response.Write("<script>alert('Answer not Matched')</script>");

                            }
                        }

                    }
                    else
                    {
                        if (txtAnswer.Text=="")
                        {
                            txtAnswer.Focus();
                        }
                        else
                        {
                            SqlCommand cmd = new SqlCommand("changePassword", Connections.ReturnConnection());
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@userid", txtuserid.Text);
                            cmd.Parameters.AddWithValue("@password", txtAnswer.Text);
                            int res = cmd.ExecuteNonQuery();
                            if (res >= 1)
                            {
                                Response.Write("<script>alert('Password Changed Sucessfull')</script>");
                                Response.Redirect("Default.aspx");
                            }
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
    }
}