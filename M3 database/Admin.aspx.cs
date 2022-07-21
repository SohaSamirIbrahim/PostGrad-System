using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M3_database
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null || Session["usertype"].ToString() != "1")
            {
                Session["loggedIn"] = false;
                Response.Redirect("login.aspx");

            }
        }

        protected void supervisorList(object sender, EventArgs e)
        {
            countNum.Visible = false;
            ThesisView.Visible = false;
            paymentinfo.Visible = false;
            extensionInfo.Visible = false;
            success.Visible = false;
            wrong.Visible = false;
            installInfo.Visible = false;
            missing.Visible = false;
            pymentinvalid.Visible = false;
            Panel1.Visible = true;
            SupervisorView.Visible = true;

        }

        protected void thesisList(object sender, EventArgs e)
        {
            countNum.Visible = false;
            SupervisorView.Visible = false;
            paymentinfo.Visible = false;
            extensionInfo.Visible = false;
            success.Visible = false;
            wrong.Visible = false;
            missing.Visible = false;
            installInfo.Visible = false;
            Panel1.Visible = true;
            ThesisView.Visible = true;
        }

        protected void thesisCount(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand thesisCountproc = new SqlCommand("AdminViewOnGoingTheses", conn);
            thesisCountproc.CommandType = CommandType.StoredProcedure;

            SqlParameter count = thesisCountproc.Parameters.Add("@thesesCount", SqlDbType.Int);
            count.Direction= ParameterDirection.Output;

            conn.Open();
            thesisCountproc.ExecuteNonQuery();
            conn.Close();

            countNum.Text= count.Value.ToString();
            ThesisView.Visible = false;
            SupervisorView.Visible = false;
            paymentinfo.Visible = false;
            extensionInfo.Visible = false;
            success.Visible = false;
            wrong.Visible = false;
            missing.Visible = false;
            installInfo.Visible = false;
            pymentinvalid.Visible = false;
            Panel1.Visible = true;
            countNum.Visible = true;
        }

        protected void thesisPayment(object sender, EventArgs e)
        {
            ThesisView.Visible = false;
            SupervisorView.Visible = false;
            countNum.Visible = false;
            extensionInfo.Visible = false;
            success.Visible = false;
            wrong.Visible = false;
            missing.Visible = false;
            installInfo.Visible = false;
            pymentinvalid.Visible = false;
            Panel1.Visible = true;
            paymentinfo.Visible = true;

        }

        protected void issueInstallment(object sender, EventArgs e)
        {
            ThesisView.Visible = false;
            SupervisorView.Visible = false;
            countNum.Visible = false;
            extensionInfo.Visible = false;
            success.Visible = false;
            wrong.Visible = false;
            missing.Visible = false;
            paymentinfo.Visible= false;
            countNum.Visible = false;
            pymentinvalid.Visible = false;
            Panel1.Visible = true;
            installInfo.Visible = true;

        }

        protected void updateExtension(object sender, EventArgs e)
        {
            ThesisView.Visible = false;
            SupervisorView.Visible = false;
            countNum.Visible = false;   
            paymentinfo.Visible = false;
            success.Visible = false;
            wrong.Visible = false;
            missing.Visible = false;
            installInfo.Visible = false;
            pymentinvalid.Visible = false;
            Panel1.Visible = true;
            extensionInfo.Visible = true;

        }

        protected void IssuePayment(object sender, EventArgs e)
        {
            if (thSerialNum.Text != "" && amount.Text != "" && noOfInstall.Text != "" && percent.Text != "")
            {

                try
                {
                    int serialNumber = Convert.ToInt32(thSerialNum.Text);
                    double paymentAmount = Convert.ToDouble(amount.Text);
                    int numInstall = Convert.ToInt32(noOfInstall.Text);
                    double fundPercent = Convert.ToDouble(percent.Text);
                    String connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();
                    SqlConnection conn = new SqlConnection(connStr);
                    SqlCommand issuePaymentProc = new SqlCommand("AdminIssueThesisPayment", conn);
                    issuePaymentProc.CommandType = CommandType.StoredProcedure;

                    issuePaymentProc.Parameters.Add(new SqlParameter("@ThesisSerialNo", serialNumber));
                    issuePaymentProc.Parameters.Add(new SqlParameter("@amount", paymentAmount));
                    issuePaymentProc.Parameters.Add(new SqlParameter("@noOfInstallments", numInstall));
                    issuePaymentProc.Parameters.Add(new SqlParameter("@fundPercentage", fundPercent));

                    try
                    {
                        conn.Open();
                        issuePaymentProc.ExecuteNonQuery();
                        conn.Close();
                        success.Text = "Payment Issued Successfully";
                        wrong.Visible = false;
                        success.Visible = true;
                        ThesisView.DataBind();
                    }
                    catch (Exception ex)
                    {
                        pymentinvalid.Visible = false;
                        missing.Visible = false;
                        success.Visible = false;
                        wrong.Visible = true;

                    }

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Unvalid amount or percentage')</script>");
                }


            }
            else
            {
                missing.Visible = true;
                //Response.Write("<script>alert('Please enter missing data')</script>");
            }



        }


        //protected void IssuePayment(object sender, EventArgs e)
        //{
        //    if(thSerialNum.Text != "" && amount.Text != "" && noOfInstall.Text != "" && percent.Text != "")
        //    {
        //        int serialNumber = Convert.ToInt32(thSerialNum.Text);
        //        double paymentAmount = Convert.ToDouble(amount.Text);
        //        int numInstall = Convert.ToInt32(noOfInstall.Text);
        //        double fundPercent = Convert.ToDouble(percent.Text);

        //        String connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();
        //        SqlConnection conn = new SqlConnection(connStr);
        //        SqlCommand issuePaymentProc = new SqlCommand("AdminIssueThesisPayment", conn);
        //        issuePaymentProc.CommandType = CommandType.StoredProcedure;

        //        issuePaymentProc.Parameters.Add(new SqlParameter("@ThesisSerialNo", serialNumber));
        //        issuePaymentProc.Parameters.Add(new SqlParameter("@amount", paymentAmount));
        //        issuePaymentProc.Parameters.Add(new SqlParameter("@noOfInstallments", numInstall));
        //        issuePaymentProc.Parameters.Add(new SqlParameter("@fundPercentage", fundPercent));

        //        try
        //        {
        //            conn.Open();
        //            issuePaymentProc.ExecuteNonQuery();
        //            conn.Close();
        //            success.Text = "Payment Issued Successfully";
        //            wrong.Visible = false;

        //            success.Visible = true;
        //            ThesisView.DataBind();
        //        }
        //        catch (Exception ex)
        //        {
        //            pymentinvalid.Visible = false;
        //            missing.Visible = false;
        //            success.Visible = false;
        //            wrong.Visible = true;

        //        }
        //    }
        //    else
        //    {
        //        missing.Visible = true;
        //        //Response.Write("<script>alert('Please enter missing data')</script>");
        //    }



        //}

        protected void extend(object sender, EventArgs e)
        {
            if(extension.Text != "")
            {
                int serial = Convert.ToInt32(extension.Text);

                String connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand updateExtenProc = new SqlCommand("AdminUpdateExtension", conn);
                updateExtenProc.CommandType = CommandType.StoredProcedure;

                updateExtenProc.Parameters.Add(new SqlParameter("@ThesisSerialNo", serial));

                try
                {
                    conn.Open();
                    updateExtenProc.ExecuteNonQuery();
                    conn.Close();
                    success.Text = "Thesis Extended Successfully";
                    pymentinvalid.Visible = false;
                    missing.Visible = false;
                    success.Visible = true;
                    ThesisView.DataBind();
                }
                catch(Exception ex)
                {
                    pymentinvalid.Visible = false;
                    missing.Visible = false;
                    success.Visible = false;
                    wrong.Visible = true;

                }
            }

            else
            {
                missing.Visible = true;
                //Response.Write("<script>alert('Please enter missing data')</script>");
            }
        }

        protected void IssueInstallment(object sender, EventArgs e)
        {
            if(payId.Text != "" && date.Text != "")
            {
                try { 
                int payment = Convert.ToInt32(payId.Text);
                DateTime startDate = Convert.ToDateTime(date.Text);

                String connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand issueInstallProc = new SqlCommand("AdminIssueInstallPayment2", conn);
                issueInstallProc.CommandType = CommandType.StoredProcedure;

                issueInstallProc.Parameters.Add(new SqlParameter("@paymentID", payment));
                issueInstallProc.Parameters.Add(new SqlParameter("@InstallStartDate", startDate));

                conn.Open();
                issueInstallProc.ExecuteNonQuery();
                conn.Close();

                success.Text = "Installment Issued Successfully";
                pymentinvalid.Visible = false;
                missing.Visible = false;
                success.Visible = true;
                } 
                catch (Exception ex)
                {
                    missing.Visible = false;
                    success.Visible = false;
                    pymentinvalid.Visible= true;
                    wrong.Visible=false;
                }
            }
            else
            {

                missing.Visible = true;
                //Response.Write("<script>alert('Please enter missing data')</script>");
            }

        }
    }
}