using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoMailingSystem
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["login"] != null)
                {
                    if (Connections.Connect())
                    {
                        SqlCommand cmd = new SqlCommand("getDiplayPic", Connections.ReturnConnection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@userid", Request.Cookies["login"]["Name"].ToString());
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                    }

                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        protected void btnSignout_Click(object sender, EventArgs e)
        {


            HttpCookie cookie = new HttpCookie("login");
            cookie.Expires = DateTime.Now.AddDays(-1d);
            cookie = new HttpCookie("username");
            cookie.Expires = DateTime.Now.AddDays(-1d);

            Response.Redirect("Default.aspx");
        }
        protected void btnhome_Click(object sender, EventArgs e)
        {
            Response.Redirect("AfterLogin.aspx");
        }

        protected void lnkProfile_Click(object sender, EventArgs e)
        {

        }
    }
}