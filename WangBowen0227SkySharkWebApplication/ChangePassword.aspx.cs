using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WangBowen0227SkySharkWebApplication
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usrRole"] == null)
            {
                Response.Redirect("..\\default.aspx");
            }
            if (!(Session["usrRole"].ToString() == "Admin"))
            {
                Response.Redirect("..\\default.aspx");
            }
            else
            {
                Label1.Text ="Changing password for"+Session["userName"].ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                String ConnectionString = ConfigurationManager.ConnectionStrings["ARPDatabaseConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();
                string updateSql = "update dtUsers SET Password = @Password,PasswordChanged='1' where(Username=@original_username";
                SqlCommand cmd = new SqlCommand(updateSql, conn);
                cmd.Parameters.AddWithValue("Password",txtPassword.Text);
                cmd.Parameters.AddWithValue("original_username",Session["userName"]);

                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("~/NA/ManageUsers.aspx");
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
        }
    }
}