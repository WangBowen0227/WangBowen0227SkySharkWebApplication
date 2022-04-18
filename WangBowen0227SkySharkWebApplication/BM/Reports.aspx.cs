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
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            String month,date,year;
            month =lstMonth.SelectedItem.Text.Trim();
            year =lstYear.SelectedItem.Text.Trim();
            date=month+"/01/ "+year;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ARPDatabaseConnectionString"].ConnectionString);
            conn.Open();
            string querystring = "SELECT FltNo, SUM(Fare) AS fare from dtDepartedFlights  where (DateOfJourney>@date) group by  FltNo";


            SqlCommand cmd = new SqlCommand(querystring, conn);
            cmd.Parameters.AddWithValue("@date", date);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet dataset =new DataSet();
            
            adapter.Fill(dataset, "FlightNo");
            conn.Close();
            DataView source = new DataView(dataset.Tables["Fare"]);
            GridView1.DataSource = source;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ARPDatabaseConnectionString"].ConnectionString);
            conn.Open();
            string querystring = "SELECT FltNo, DateOfJourney, SUM(Fare) AS Revenue from dtDepartedFlights GROUP BY DateOfJourney, FltNo";


            SqlCommand cmd = new SqlCommand(querystring, conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet dataset = new DataSet();

            adapter.Fill(dataset, "usges");
            conn.Close();
            DataView source = new DataView(dataset.Tables["usges"]);
            GridView1.DataSource = source;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ARPDatabaseConnectionString"].ConnectionString);
            conn.Open();
            string querystring = "SELECT Top 100 Email, FareCollected, TotalTimesFlown from dtPassengerDetails order by TotalTimesFlown ";


            SqlCommand cmd = new SqlCommand(querystring, conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet dataset = new DataSet();

            adapter.Fill(dataset, "FreqFl");
            conn.Close();
            DataView source = new DataView(dataset.Tables["FreqFl"]);
            GridView1.DataSource = source;
            GridView1.DataBind();
        }
    }
}