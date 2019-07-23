using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace DemoMailingSystem
{
    public partial class Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
           
            DataTable dt = new DataTable();
            userData ud = new userData();
            dt = ud.userLogin(txtEmailId.Text,txtPassword.Text);
           
            if(dt.Rows.Count>0)
            {
                HttpCookie login = new HttpCookie("login");
                login["Name"] = dt.Rows[0]["UserId"].ToString();
                login.Expires = DateTime.Now.AddDays(1d);
                Response.Cookies.Add(login);
                Response.Redirect("AfterLogin.aspx");
            }
            else
            {
                Response.Write("<script>alert('Wrong UserId or Password')</script>");
                txtPassword.Focus();
            }
        }

        protected void lnkbtnForgetPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgetPassword.aspx");
        }

        protected void lnkbtnsignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateNewAccount.aspx");

        }
    }
}