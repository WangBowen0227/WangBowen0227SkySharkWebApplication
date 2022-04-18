using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WangBowen0227SkySharkWebApplication.BM
{
    public partial class FreqFI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                lblMessage.Text = "";
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ARPDatabaseConnectionString"].ConnectionString);
                conn.Open();
                string insertsql = "INSERT INTO dtFrequentFliers Select EMail, Discount=@Discount from dtPassengerDetails where TotalTimesFlown>=@TotalTimesFlown";


                SqlCommand cmd = new SqlCommand(insertsql, conn);
                cmd.Parameters.AddWithValue("@Discount", lstDisc1.SelectedItem.Text.Trim());
                cmd.Parameters.AddWithValue("@TotalTimesflown", listTimeFollown.SelectedItem.Text.Trim());
                int n = cmd.ExecuteNonQuery();
                conn.Close();
                lblMessage.Text = "Record added";
                String selecSql = "select * from dtFrequentFliers";
                
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd2 = new SqlCommand(selecSql, conn);
                adapter.SelectCommand = cmd2;
                DataSet dataset = new DataSet();
                adapter.Fill(dataset, "FrequentFliers");
                conn.Close();
                DataView source = new DataView(dataset.Tables["FrequentFliers"]);
                GridView1.DataSource = source;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ARPDatabaseConnectionString"].ConnectionString);
                conn.Open();
                string insertsql = "INSERT INTO dtFrequentFliers Select EMail, Discount=@Discount from dtPassengerDetails where FareCollected>=@FareCollected";


                SqlCommand cmd = new SqlCommand(insertsql, conn);
                cmd.Parameters.AddWithValue("@Discount", lstDisc2.SelectedItem.Text.Trim());
                cmd.Parameters.AddWithValue("@TotalTimesflown", txtFare.Text.Trim());
                int n = cmd.ExecuteNonQuery();
                conn.Close();
                lblMessage.Text = "Record added";
                String selecSql = "select * from dtFrequentFliers";

                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd2 = new SqlCommand(selecSql, conn);
                adapter.SelectCommand = cmd2;
                DataSet dataset = new DataSet();
                adapter.Fill(dataset, "FrequentFliers");
                DataView source = new DataView(dataset.Tables["FrequentFliers"]);
                GridView1.DataSource = source;
                GridView1.DataBind();
                conn.Close();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
    }
}