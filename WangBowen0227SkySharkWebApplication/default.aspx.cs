using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WangBowen0227SkySharkWebApplication
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                String username;
                String password;
                username =txtUserName.Text;
                password =txtPassword.Text;
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ARPDatabaseConnectionString"].ConnectionString);
                conn.Open();
                string queryString = "Select Username,Password,Role from dtUsers where Username='" + username + "'";
                SqlDataAdapter adapter = new SqlDataAdapter();

                adapter.SelectCommand = new SqlCommand(queryString, conn);

                DataSet ds1 = new DataSet();
                adapter.Fill(ds1,"dtUsers");
                if(ds1.Tables["dtUsers"].Rows.Count == 0)
                {
                    lblMessage.Text = "Invalid username";
                }
                else
                {
                if(ds1.Tables["dtUsers"].Rows[0][1].ToString().Trim()==txtPassword.Text.Trim())
                {
                    String Role;
                    Role = ds1.Tables["dtUsers"].Rows[0][2].ToString().Trim();
                    Session["userRole"] = Role;
                    if(Role =="Disabled")
                    {
                        lblMessage.Text = "Your account has been disabled.Please contact the network Administrator";
                        return;
                    }
                    switch(Role)
                    {
                        case "Admin":
                            Response.Redirect(".\\NA\\ManageUsers.aspx");
                            break;
                        case "BM":
                            Response.Redirect(".\\BM\\AddFI.aspx");
                            break ;
                        case "LOB":
                            Response.Redirect(".\\LOB\\CrateRes.aspx");
                            break;
                        case "NA":
                            Response.Redirect(".\\LOB\\ManageUsers.aspx");
                            break;   
                        }
                }
                else
                {
                    lblMessage.Text = "Invalid password";
                }
            }
                conn.Close();
          }
        }
    }
}