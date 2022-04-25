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
    public partial class ConfirmReservation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblDetails.Visible = false;
            String ConnectionString = ConfigurationManager.ConnectionStrings["ARPDatabaseConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string selectSql = "SELECT TicketNo, FltNo, DateOfJourney, ClassOfRes, TicketConfirmed, DateOfRes, Fare FROM dtReservations " +
                "where TicketNo=@TicketNo";

            SqlCommand cmd = new SqlCommand(selectSql, conn);
            cmd.Parameters.AddWithValue("@TicketNo", txtTNo.Text.Trim());


            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "TicketDetails");
            conn.Close();
            if (dataSet.Tables["TicketDetails"].Rows.Count == 0)
            {
                lblMessage.Text = "Invalid Ticket Number";
                return;
            }
            else
            {
                String DateofFlight;
                DateofFlight = dataSet.Tables["TicketDetails"].Rows[0][2].ToString();
                if (Convert.ToDateTime(DateofFlight) < Convert.ToDateTime(DateTime.Today.ToShortDateString()))
                {
                    lblMessage.Text = "The flight has already departed";
                    return;
                }
                else
                {
                    conn.Open();
                    String updateSql = "UPDATE dtReservations SET TicketConfirmed = @TicketConfirmed WHERE TicketNo = @TicketNo";
                    SqlCommand updatecmd = new SqlCommand(updateSql, conn);
                    updatecmd.Parameters.AddWithValue("@TicketConfirmed", Convert.ToBoolean(1));
                    updatecmd.Parameters.AddWithValue("@TicketNo", txtTNo.Text.Trim());
                    updatecmd.ExecuteNonQuery();
                    conn.Close();
                    lblDetails.Text = "”Ticket confirmed\n" + " FltNo :" + dataSet.Tables["TicketDetails"].Rows[0][1].ToString() + "\n DateOfJourney: "
                        + dataSet.Tables["TicketDetails"].Rows[0][2].ToString() + "" +
                        "\n ClassOfRes: " + dataSet.Tables["TicketDetails"].Rows[0][3].ToString();
                    lblDetails.Visible = true;


                }

            }
        }
    }
}