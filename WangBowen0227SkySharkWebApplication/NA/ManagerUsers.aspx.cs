using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WangBowen0227SkySharkWebApplication.NA
{
    public partial class ManagerUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddSubmit_Click(object sender, EventArgs e)
        {
            string username, password, role;
            int selection;
            role = lstAddRole.SelectedValue;

            username=txtAddUserName.Text;
            password=txtAddPassword.Text;
            selection=lstAddRole.SelectedIndex;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ARPDatabaseConnectionString"].ConnectionString);
            conn.Open();
            string queryString = "Select UserName,Password,role from dtUsers where UserName='" + username + "'";
            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.SelectCommand = new SqlCommand(queryString, conn);

            DataSet ds1 = new DataSet();
            adapter.Fill(ds1, "dtUsers");
            if (ds1.Tables["dtUsers"].Rows.Count == 0)
            {
                string insertQueryString = "INSERT INTO [dtUsers] ([Username], [Password], [Role]) VALUES ('"+username+"','"+password+"','"+role+"')";
                SqlCommand insterCommand = new SqlCommand(insertQueryString, conn);
                insterCommand.ExecuteNonQuery();
            }
            else
            {
                lblMessage.Text = "The username already exists;Please try anothor username";
                return;
            }
        }

        protected void btnDelDelete_Click(object sender, EventArgs e)
        {
            string username = txtDelUserName.Text;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ARPDatabaseConnectionString"].ConnectionString);
            conn.Open();
            if (username == "" || username == null)
            {
                lblMessage.Text = "Please specify a valid user name.";
            }
            else
            {
                string queryString = "Select Username,Password,Role from dtUsers where Username='" + username + "'";
                SqlDataAdapter adapter = new SqlDataAdapter();

                adapter.SelectCommand = new SqlCommand(queryString, conn);

                DataSet ds1 = new DataSet();
                adapter.Fill(ds1, "dtUsers");
                if (ds1.Tables["dtUsers"].Rows.Count == 0)
                {
                    lblMessage.Text = "User does not exists";
                    return;
                }
                else
                {
                    string querystring2="delete from dtUsers where Username = '"+username+"'";
                    SqlCommand insterCommand = new SqlCommand(querystring2, conn);
                    insterCommand.ExecuteNonQuery();
                    conn.Close();
                    lblMessage.Text = "User delete successfully";
                    txtDelUserName.Text = "";
                }
            }
        }
    }
}
