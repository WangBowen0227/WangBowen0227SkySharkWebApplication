using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WangBowen0227SkySharkWebApplication.LOB
{
    public partial class QuaryStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFStatSubmit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (txtFlightNo.Text == "" || txtFlightNo.Text == null)
            {
                lblMessage.Text = "Invalid flight number";
                return;
            }
            else
            {
                String ConnectionString = ConfigurationManager.ConnectionStrings["ARPDatabaseConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();

                string selectSql4 = "SELECT FltNo FROM dtFltDetails where convert(date,Deptime,101) =@Deptime";
                SqlCommand cmd4 = new SqlCommand(selectSql4, conn);
                cmd4.Parameters.AddWithValue("@Deptime", calDepDate.SelectedDate.ToShortDateString());

                SqlDataAdapter adapter4 = new SqlDataAdapter(cmd4);


                DataSet dataSet4 = new DataSet();
                adapter4.Fill(dataSet4, "FlightNo");
                conn.Close();
                Boolean flightStatus = false;
                foreach (DataRow row in dataSet4.Tables["FlightNo"].Rows)
                {
                    //step 1- Ensure the flight number is unique

                    if (row[0].ToString().Trim() == txtFlightNo.Text.Trim())
                    {
                        flightStatus = true;
                        break;
                    }
                }
                if (flightStatus)
                {
                    string selectSql = "SELECT FltNo, StatusDate, StatusClass, Status FROM dtFltStatus where FltNo=@fltno " +
                        "and StatusDate=@date and StatusClass=@class";

                    SqlCommand cmd = new SqlCommand(selectSql, conn);
                    cmd.Parameters.AddWithValue("@FltNo", txtFlightNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@date", calDepDate.SelectedDate.ToShortDateString());
                    cmd.Parameters.AddWithValue("@class", lstClass.SelectedItem.Text.Trim());



                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "FltStatus");
                    conn.Close();

                    if (dataSet.Tables["FltStatus"].Rows.Count == 0)
                    {
                        lblMessage.Text = "Status: Available";
                        ;
                    }
                    else
                    {
                        String strStatus = "";
                        int status;
                        strStatus = dataSet.Tables["FltStatus"].Rows[0][3].ToString();
                        status = Convert.ToInt32(strStatus);
                        if (status > 0)
                        {
                            lblMessage.Text = "Status: Available";
                        }
                        else
                        {
                            lblMessage.Text = "Status: Overbooked";
                        }
                    }
                }
                else
                {
                    lblMessage.Text = "Status: Not Available";
                }
            }
        }

        protected void btnTStatSubmit_Click(object sender, EventArgs e)
        {
            lblTicketStatus.Text = "";
            if (txtTNo.Text == "" || txtTNo.Text == null)
            {
                lblTicketStatus.Text = "Invalid Ticket number";
                return;
            }
            else
            {
                String ConnectionString = ConfigurationManager.ConnectionStrings["ARPDatabaseConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();
                string selectSql = "SELECT TicketConfirmed FROM dtReservations where TicketNo=@TicketNo";

                SqlCommand cmd = new SqlCommand(selectSql, conn);
                cmd.Parameters.AddWithValue("@TicketNo", txtTNo.Text.Trim());


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "TicketStatus");
                conn.Close();
                if (dataSet.Tables["TicketStatus"].Rows.Count == 0)
                {
                    conn.Open();
                    string selectSql2 = "SELECT TicketNo FROM dtCancellations where TicketNo=@TicketNo";

                    SqlCommand cmd2 = new SqlCommand(selectSql2, conn);
                    cmd2.Parameters.AddWithValue("@TicketNo", txtTNo.Text.Trim());


                    SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);

                    DataSet dataSet2 = new DataSet();
                    adapter2.Fill(dataSet2, "TicketCancellationsStatus");
                    conn.Close();
                    if (dataSet2.Tables["TicketCancellationsStatus"].Rows.Count > 0)
                    {
                        lblTicketStatus.Text = "Ticket has Cancelled";
                    }
                    else
                    {
                        lblTicketStatus.Text = "Invalid Ticket Number";
                    }


                }
                else
                {
                    String strStatus = "";

                    strStatus = dataSet.Tables["TicketStatus"].Rows[0][0].ToString();

                    if (strStatus == "True")
                    {
                        lblTicketStatus.Text = "Status: Ticket is Confirmed";
                    }
                    else
                    {
                        lblTicketStatus.Text = "Status: Ticket Not Confirmed";
                    }
                }

            }
        }
    }
}
