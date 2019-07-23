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
    public partial class CreateNewAccount : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {


                if (Connections.Connect())
                {


                    SqlCommand cmd1 = new SqlCommand("cheeckUserName", Connections.ReturnConnection());
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@userid", txtUserId.Text);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da1.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        Response.Write("<script>alert('UserId already exsist try another')</script>");
                        txtUserId.Focus();
                    }
                    else
                    {
                        string imgid= Guid.NewGuid().ToString();
                        SqlCommand cmd = new SqlCommand("createNewUser", Connections.ReturnConnection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@fname", txtFirstName.Text);
                        cmd.Parameters.AddWithValue("@lname", txtLastName.Text);
                        cmd.Parameters.AddWithValue("@userid", txtUserId.Text);
                        cmd.Parameters.AddWithValue("@password", txtConfmPassword.Text);
                        cmd.Parameters.AddWithValue("@dob", txtBirthday.Text);
                        cmd.Parameters.AddWithValue("@gender", rblGender.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@question", ddlQuestion.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@answer", txtAnswer.Text);
                        cmd.Parameters.AddWithValue("@imgid", imgid);
                        if(rblGender.SelectedValue.ToString()=="1")
                        {
                            cmd.Parameters.AddWithValue("@imgname", "male.png");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@imgname", "female.png");
                        }
                        int i = cmd.ExecuteNonQuery();
                        if (i >= 0)
                        {
                            Response.Write("<script>alert('User registered sucessfully')</script>");
                            Response.Redirect("Default.aspx");

                        }
                        else
                        {
                            Response.Write("SignUp Fails..!!");
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