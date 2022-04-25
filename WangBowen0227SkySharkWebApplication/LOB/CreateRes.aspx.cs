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
    public partial class CreateRes : System.Web.UI.Page
    {
        int FStatus = 1;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Wizard1_NextButtomClick1(object sender, WizardNavigationEventArgs e)
        {
            
            if (Wizard1.WizardSteps[e.CurrentStepIndex].ID.ToString().Trim() == "WizardStep1")
            {
 
                if (Cal1.SelectedDate <= DateTime.Now)
                {
                    lblMessageStep1.Text = "Invalid Deaparture Date";
                    e.Cancel = true;
                    return;
                }
                String ConnectionString = ConfigurationManager.ConnectionStrings["ARPDatabaseConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();
                string selectSql = "SELECT FltNo,Origin,Destination,Deptime,FareExec,FareBn FROM dtFltDetails " +
                "where FltNo=@FltNo and convert(date,Deptime,101) =@Deptime";
                SqlCommand cmd = new SqlCommand(selectSql, conn);
                cmd.Parameters.AddWithValue("@FltNo", txtFltNo.Text.Trim());
                cmd.Parameters.AddWithValue("@Deptime", Cal1.SelectedDate.ToShortDateString());
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "FltDetails");
                conn.Close();
                bool exists = false;

                foreach (DataRow myRow in dataSet.Tables["FltDetails"].Rows)
                {
                    if (myRow[0].ToString().Trim().ToLower() == txtFltNo.Text.ToLower())
                    {
                        exists = true;
                        //step 2- set data into txt box
                        txtOrg.Text = myRow[1].ToString();
                        txtDest.Text = myRow[2].ToString();
                        txtDepTime.Text = myRow[3].ToString().Substring(myRow[3].ToString().Length - 11).Trim();
                        if (lstClass.SelectedIndex == 0)
                        {
                            txtFare.Text = myRow[4].ToString();
                        }
                        else
                        {
                            txtFare.Text = myRow[5].ToString();
                        }
                    }

                    txtTNo.Text = "Auto Generated";
                    lblMessageStep1.Text = "";
                    //  txtFltNo.Enabled = false;
                    // lstClass.Enabled = false;
                    //Calendar1.Enabled = false;

                    //conn.Open();
                    String FltStatusSql = "select FltNo,StatusDate,StatusClass ,Status from dtFltStatus where  FltNo=@FltNo";

                    SqlCommand FltStatuscmd = new SqlCommand(FltStatusSql, conn);
                    FltStatuscmd.Parameters.AddWithValue("@FltNo", txtFltNo.Text.Trim());

                    SqlDataAdapter FltStatusadapter = new SqlDataAdapter(FltStatuscmd);

                    DataSet FltStatusdataSet = new DataSet();
                    FltStatusadapter.Fill(FltStatusdataSet, "FltStatus");
                    conn.Close();
                    if (FltStatusdataSet.Tables["FltStatus"].Rows.Count == 0)
                    {
                        txtStatus.Text = "Available";
                    }
                    else
                    {
                        int status = Convert.ToInt32(FltStatusdataSet.Tables["FltStatus"].Rows[0][3].ToString());
                        if (status <= 0)
                        {
                            txtStatus.Text = "WaitListed (" + Convert.ToInt32((status - 1)) + ")";
                        }
                        else
                        {
                            txtStatus.Text = "Available :" + status;
                        }
                    }



                }
                if (exists == false)
                {
                    lblMessageStep1.Text = "Incorrect flight number.Please try again";
                    e.Cancel = true;
                    return;
                }

            }
            
            if (Wizard1.WizardSteps[e.CurrentStepIndex].ID.ToString().Trim() == "WizardStep2")
            {
                String TicketNo, DateOfRes, DateOfJourney, FltNo, ClassofRes, Name, Email;
                int TicketConf, Status, fare;
                try
                {
                    FltNo = txtFltNo.Text.Trim();
                    ClassofRes = lstClass.SelectedItem.Text.Trim();
                    Name = txtName.Text.Trim();
                    DateOfRes = DateTime.Today.Date.ToShortDateString();
                    DateOfJourney = Cal1.SelectedDate.ToShortDateString();
                    Email = txtEMail.Text.Trim();

                    TicketConf = 0;
                    fare = Convert.ToInt32(txtFare.Text.Trim());

                    String ConnectionString = ConfigurationManager.ConnectionStrings["ARPDatabaseConnectionString"].ConnectionString;
                    SqlConnection conn = new SqlConnection(ConnectionString);
                    conn.Open();


                    String FltStatusSql = "select FltNo,StatusDate,StatusClass ,Status from dtFltStatus where  FltNo=@FltNo ";

                    SqlCommand FltStatuscmd = new SqlCommand(FltStatusSql, conn);
                    FltStatuscmd.Parameters.AddWithValue("@FltNo", txtFltNo.Text.Trim());
                    SqlDataAdapter FltStatusadapter = new SqlDataAdapter(FltStatuscmd);

                    DataSet FltStatusdataSet = new DataSet();
                    FltStatusadapter.Fill(FltStatusdataSet, "FltStatus");
                    conn.Close();

                    if (FltStatusdataSet.Tables["FltStatus"].Rows.Count == 0)
                    {
                      
                        conn.Open();
                        string selectSql = "SELECT FltNo,Origin,Destination,Deptime,FareExec,FareBn,SeatsExec,SeatsBn FROM dtFltDetails where FltNo=@FltNo and convert(date,Deptime,101) =@Deptime";
                        SqlCommand cmd = new SqlCommand(selectSql, conn);
                        cmd.Parameters.AddWithValue("@FltNo", txtFltNo.Text.Trim());
                        cmd.Parameters.AddWithValue("@Deptime", Cal1.SelectedDate.ToShortDateString());
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, "FltDetails");
                        conn.Close();
                        string strTotSeats;
                        int intTotSeats;
                        foreach (DataRow myRow in dataSet.Tables["FltDetails"].Rows)
                        {
                            if (myRow[0].ToString().Trim().ToLower() == txtFltNo.Text.ToLower())
                            {
                                if (lstClass.SelectedIndex == 0)
                                {
                                    strTotSeats = myRow[6].ToString();
                                }
                                else
                                {
                                    strTotSeats = myRow[7].ToString();
                                }
                                intTotSeats = Convert.ToInt32(strTotSeats);
                                conn.Open();
                                string insertSatatusSql = "INSERT INTO dtFltStatus(FltNo, StatusDate, StatusClass, Status) VALUES(@FltNo, @StatusDate,@StatusClass,@Status)";
                                SqlCommand insertSatatusSqlcmd = new SqlCommand(insertSatatusSql, conn);
                                insertSatatusSqlcmd.Parameters.AddWithValue("@FltNo", FltNo);
                                insertSatatusSqlcmd.Parameters.AddWithValue("@StatusDate", DateOfJourney);//check
                                insertSatatusSqlcmd.Parameters.AddWithValue("@StatusClass", ClassofRes);

                                insertSatatusSqlcmd.Parameters.AddWithValue("@Status", intTotSeats - 1);

                                insertSatatusSqlcmd.ExecuteNonQuery();
                                conn.Close();

                            }
                        }
                        Status = 1;
                    }
                    else
                    {
                        int val = Convert.ToInt32(FltStatusdataSet.Tables["FltStatus"].Rows[0][3]);
                        if (val >= 0)
                        {
                            Status = val - 1;
                        }
                        else
                        {
                            Status = 1;
                        }
                        FStatus = Status;

                        conn.Open();
                        string updateStatusSql = "Update dtFltStatus set Status=@status where FltNo=@FltNo and StatusDate=@StatusDate and StatusClass=@StatusClass";
                        SqlCommand updatestatuscmd = new SqlCommand(updateStatusSql, conn);
                        updatestatuscmd.Parameters.AddWithValue("@status", Status);
                        updatestatuscmd.Parameters.AddWithValue("@FltNo", FltNo);
                        updatestatuscmd.Parameters.AddWithValue("@StatusDate", DateOfJourney);//check
                        updatestatuscmd.Parameters.AddWithValue("@StatusClass", ClassofRes);

                        updatestatuscmd.ExecuteNonQuery();
                        conn.Close();

                    }

                }
                catch
                {
                }

            }
        }

        protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            if (Wizard1.WizardSteps[e.CurrentStepIndex].ID.ToString().Trim() == "WizardStep3")
            {
 
                if (txtName.Text == "" || txtName.Text == null)
                {
                    lblMessageStep3.Text = "Invalid Username";
                    return;
                }


                String TicketNo = "1", DateOfRes, DateOfJourney, FltNo, ClassofRes, Name, Email;
                int TicketConf, Status, fare;
                try
                {
                    FltNo = txtFltNo.Text.Trim();
                    ClassofRes = lstClass.SelectedItem.Text.Trim();
                    Name = txtName.Text.Trim();
                    DateOfRes = DateTime.Today.Date.ToShortDateString();
                    DateOfJourney = Cal1.SelectedDate.ToShortDateString();
                    Email = txtEMail.Text.Trim();
                    TicketConf = 0;
                    fare = Convert.ToInt32(txtFare.Text.Trim());
              
                    String ConnectionString = ConfigurationManager.ConnectionStrings["ARPDatabaseConnectionString"].ConnectionString;
                    SqlConnection conn = new SqlConnection(ConnectionString);
                    conn.Open();
                    string insertSql = "INSERT INTO [dtReservations] ([TicketNo], [FltNo], [DateOfJourney], [ClassOfRes], [Name], [EMail], [Fare], [Status], [ReservedBy], [DateOfRes], [TicketConfirmed]) " +
                                   "VALUES (@TicketNo, @FltNo, @DateOfJourney, @ClassOfRes, @Name, @EMail, @Fare, @Status, @ReservedBy, @DateOfRes, @TicketConfirmed)";

                    SqlCommand cmd = new SqlCommand(insertSql, conn);


                    String ticketNoSql = "select TicketNo from dtReservations";
                    SqlCommand ticketNoSqlCmd = new SqlCommand(ticketNoSql, conn);

                    SqlDataAdapter adapter = new SqlDataAdapter(ticketNoSqlCmd);

                    DataSet ticketNodataSet = new DataSet();
                    adapter.Fill(ticketNodataSet, "TicketNo");
                    int count, maxno, ticketno;
                    if (ticketNodataSet.Tables["TicketNo"].Rows.Count > 0)
                    {
                        maxno = Convert.ToInt32(ticketNodataSet.Tables["TicketNo"].Rows[0][0].ToString().Trim());
                        for (count = 1; count < ticketNodataSet.Tables["TicketNo"].Rows.Count; count++)
                        {
                            if (maxno < Convert.ToInt32(ticketNodataSet.Tables["TicketNo"].Rows[count][0].ToString().Trim()))
                            {
                                maxno = Convert.ToInt32(ticketNodataSet.Tables["TicketNo"].Rows[count][0].ToString().Trim());
                            }
                        }

                    }
                    else
                    {
                        maxno = 0;
                    }
                    ticketno = maxno + 1;
                    TicketNo = Convert.ToString(ticketno);

                    cmd.Parameters.AddWithValue("@TicketNo", TicketNo);//??
                    cmd.Parameters.AddWithValue("@FltNo", txtFltNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@DateOfJourney", Cal1.SelectedDate.ToShortDateString());
                    cmd.Parameters.AddWithValue("@ClassOfRes", lstClass.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@EMail", Email);
                    String discountSql = "SELECT EMail,Discount FROM dtFrequentFliers where email=@email;";
                    SqlCommand discountCmd = new SqlCommand(discountSql, conn);
                    discountCmd.Parameters.AddWithValue("@email", txtEMail.Text);

                    SqlDataAdapter discountAadapter = new SqlDataAdapter(discountCmd);

                    DataSet discountDataSet = new DataSet();
                    discountAadapter.Fill(discountDataSet, "discount");
                    if (discountDataSet.Tables["discount"].Rows.Count > 0)
                    {
                        int dicountApply = Convert.ToInt32(discountDataSet.Tables["discount"].Rows[0][1].ToString());
                        dicountApply = (100 - dicountApply) / 100;
                        fare = fare - dicountApply;
                    }

                    cmd.Parameters.AddWithValue("@Fare", fare);//discount

                    cmd.Parameters.AddWithValue("@Status", FStatus);//??
                    cmd.Parameters.AddWithValue("@ReservedBy", "Admin");//Session["usrName"].ToString()
                    cmd.Parameters.AddWithValue("@DateOfRes", DateOfRes);
                    cmd.Parameters.AddWithValue("@TicketConfirmed", Convert.ToBoolean(0));//??0==booked
                    int n = cmd.ExecuteNonQuery();

                    lblMessageStep3.Text = "Reservation complete. Fare is US$ " + fare.ToString() + " Ticket No :-" + TicketNo;

                }
                catch (Exception ex)
                {
                    lblMessageStep3.Text = ex.Message;
                }
            }
        }
    }
 
}