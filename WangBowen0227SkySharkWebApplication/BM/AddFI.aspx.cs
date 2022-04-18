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
    public partial class AddFI : System.Web.UI.Page
    {

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ARPDatabaseConnectionString"].ConnectionString);
            conn.Open();
            string queryString = "Select FltNo from dtFltDetails";
     
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(queryString, conn);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset,"FlightNo");
            conn.Close();
            foreach (DataRow row in dataset.Tables["FlightNo"].Rows)
            {
                if(row[0].ToString().Trim() == txtFlightnumber.Text.Trim())
                {
                    lblMessage.Text = "The fihgt already exists.Please try another flight number";
                    return;
                }
            }
            TimeSpan deptime, arrtime;
            String DepDateTime, ArrDatetime;//end
            try
            {
                deptime = Convert.ToDateTime(txtDepartureTime.Text).TimeOfDay;
                arrtime = Convert.ToDateTime(txtArrivalTime.Text).TimeOfDay;
                DepDateTime = Calendar1.SelectedDate.ToShortDateString() + "" + deptime;
                 ArrDatetime = Calendar2.SelectedDate.ToShortDateString() + "" + arrtime;
                if(deptime >= arrtime)
                {
                    lblMessage.Text = "Departure time cant be greater than or equal to arrival time";
                    return;
                }
            }
            catch(Exception ex)
            {
                lblMessage.Text = "Invalid departure or arrival time";
                return;
            }
            try
            {
                conn.Open();
                string updateSql = "INSERT INTO [dtFltDetails] ([FltNo], [Origin], [Destination], [Deptime], [Arrtime]," +
                    "[AircraftType], " +
                    "[SeatsExec], [SeatsBn], [FareExec], [FareBn], [LaunchDate])" +
                    " VALUES (@FltNo, @Origin, @Destination, @Deptime, @Arrtime, @AircraftType," +
                    " @SeatsExec, @SeatsBn, @FareExec, @FareBn,@LaunchDate)";
                SqlCommand cmd2 = new SqlCommand(updateSql, conn);
                cmd2.Parameters.AddWithValue("@FltNo", txtFlightnumber.Text.Trim());
                cmd2.Parameters.AddWithValue("@Origin", txtOriginPlace.Text.Trim());
                cmd2.Parameters.AddWithValue("@Destination", txtDestination.Text.Trim());
                cmd2.Parameters.AddWithValue("@Deptime", DepDateTime);
                cmd2.Parameters.AddWithValue("@Arrtime", ArrDatetime);
                cmd2.Parameters.AddWithValue("@AircraftType", txtAirCraftType.Text.Trim());
                cmd2.Parameters.AddWithValue("@SeatsExec", Convert.ToInt32(txtNumberofExecutiveSeats.Text.Trim()));
                cmd2.Parameters.AddWithValue("@SeatsBn", Convert.ToInt32(txtNumberofBusinessSteas.Text.Trim()));
                cmd2.Parameters.AddWithValue("@FareExec", Convert.ToInt32(txtExecutiveClassFares.Text.Trim()));
                cmd2.Parameters.AddWithValue("@FareBn", Convert.ToInt32(txtBusinessclassfares.Text.Trim()));
                cmd2.Parameters.AddWithValue("@LaunchDate", DateTime.Today.Date.ToShortDateString());
                int n =cmd2.ExecuteNonQuery();
                conn.Close();
            }catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                conn.Close();
                return;
            }
            lblMessage.Text = "Flight add sussessfully";
            txtAirCraftType.Text = "";
            txtArrivalTime.Text = "";
            txtBusinessclassfares.Text = "";
            txtDepartureTime.Text = "";
            txtDestination.Text = "";
            txtExecutiveClassFares.Text = "";
            txtFlightnumber.Text = "";
            txtNumberofBusinessSteas.Text = "";
            txtNumberofExecutiveSeats.Text = "";
            txtOriginPlace.Text = "";       
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            txtAirCraftType.Text = "";
            txtArrivalTime.Text = "";
            txtBusinessclassfares.Text = "";
            txtDepartureTime.Text = "";
            txtDestination.Text = "";
            txtExecutiveClassFares.Text = "";
            txtFlightnumber.Text = "";
            txtNumberofBusinessSteas.Text = "";
            txtNumberofExecutiveSeats.Text = "";
            txtOriginPlace.Text = "";
        }
    }
}