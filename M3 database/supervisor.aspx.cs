using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;using System.Data;


namespace Milestone3
{
    public partial class supervisor : System.Web.UI.Page
    {
        static int bit;
        static int bit2;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || (String)Session["usertype"] != "2")
            {
                Session["loggedIn"] = false;
                Response.Redirect("login.aspx");

            }
        }
        protected void pub_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupervisorPublication.aspx");

            //String connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();
            //SqlConnection conn = new SqlConnection(connStr);
            //string textb = stuidpub.Text;
            //SqlCommand cmd = new SqlCommand("checkid4", conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add(new SqlParameter("@studentID", textb));

            //SqlParameter valid = cmd.Parameters.Add("@valid", SqlDbType.Bit);
            //valid.Direction = ParameterDirection.Output;
            //conn.Open();
            //try
            //{

            //    cmd.ExecuteNonQuery();
            //    SqlDataSource2.SelectParameters["StudentID"].DefaultValue = textb;
            //    if (valid.Value.ToString() == "True")
            //    {
            //        textb = "";
            //        Session[""]
            //         Response.Redirect("SupervisorPublication.aspx");

            //        //xx.Visible = false;
            //        //GridView1.Visible = true;
            //    }
            //    else
            //    {
            //        textb = "";
            //        xx.Visible = true;
            //        GridView1.Visible = false;
            //    }
            //}
            //catch (SqlException)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('wrong serial number')", true);

            //}
            //conn.Close();
        }

        protected void namesandyears_Click(object sender, EventArgs e)
        {
            

            String connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();


            GridView2.DataBind();
            GridView2.Visible = true;
            if (GridView2.Rows.Count == 0)
            {
                nostudents.Visible = true;
            }
            else
            {
                nostudents.Visible = false;
            }
            conn.Close();
        }
        protected void Gucian_CheckedChanged(object sender, EventArgs e)
        {
            bit = 1;
        }

        protected void NonGucian_CheckedChanged(object sender, EventArgs e)
        {
            bit = 0;
        }
        protected void add_defense_Click1(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int serial = 0;
            try
            {
                serial = Convert.ToInt32(serialno.Text);

            }
            catch (FormatException ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('you have to inter the serial number')", true);

            }

           // SqlCommand exits = new SqlCommand("checkDefenseExists");



            string date = defensedate.Text;
            string loc = location.Text;
            if (string.IsNullOrEmpty(defensedate.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('you have to inter a defense date ')", true);

            }
            else if (string.IsNullOrEmpty(loc))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('you have to inter a defense location ')", true);

            }
            else
            {
                addex.Enabled = true;
                addnewex.Enabled = true;
                try
                {


                    if (bit == 1)
                    {
                        SqlCommand defguc = new SqlCommand("AddDefenseGucian", conn);
                        defguc.CommandType = CommandType.StoredProcedure;
                        defguc.Parameters.Add(new SqlParameter("@ThesisSerialNo", serial));
                        defguc.Parameters.Add(new SqlParameter("@DefenseDate", date));
                        defguc.Parameters.Add(new SqlParameter("@DefenseLocation", loc));
                        conn.Open();
                        defguc.ExecuteNonQuery();
                        conn.Close();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('defense added successfully ')", true);


                    }
                    else if (bit == 0)
                    {
                        try
                        {
                            SqlCommand defnonguc = new SqlCommand("AddDefenseNonGucian2", conn);
                            defnonguc.CommandType = CommandType.StoredProcedure;
                            defnonguc.Parameters.Add(new SqlParameter("@ThesisSerialNo", serial));
                            defnonguc.Parameters.Add(new SqlParameter("@DefenseDate", date));
                            defnonguc.Parameters.Add(new SqlParameter("@DefenseLocation", loc));
                            conn.Open();
                            defnonguc.ExecuteNonQuery();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('defense added successfully ')", true);
                            conn.Close();
                        }
                        catch (SqlException ex )
                        {
                            if (ex.Message.Contains("grade is less than 50"))
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('grade is less than 50 ')", true);
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('wrong serial number or repeated date')", true);

                            }
                        }

                    }
                   
                    }
                catch( SqlException )
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('wrong serial number or repeated date')", true);

                }
            }
   

            
        }

        protected void addeval_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int ser = 0;
            try
            {
                ser = Convert.ToInt32(serialno2.Text);

            }
            catch (FormatException ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('you have to inter the serial number')", true);

            }

            int prog = 0;
            try
            {
                 prog = Convert.ToInt32(progrepno.Text);

            }
            catch (FormatException ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('you have to inter the progress report number')", true);

            }

            int eva = 0;

            try
            {
                 eva = Convert.ToInt32(evaluation.Text);

            }
            catch (FormatException ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('you have to inter the evaluation')", true);

            }



            try
            {
    
                if (eva >= 0 && eva <= 3)
                {

                    SqlCommand cmd = new SqlCommand("EvaluateProgressReport", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@supervisorID", 13));
                    cmd.Parameters.Add(new SqlParameter("@thesisSerialNo", ser));
                    cmd.Parameters.Add(new SqlParameter("@progressReportNo", prog));
                    cmd.Parameters.Add(new SqlParameter("@evaluation", eva));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    succ.Visible = true;
                    fail.Visible = false;

                }
                else
                {
                    succ.Visible = false;
                    fail.Visible = true;
                }

            }
            catch (SqlException )
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('wrong serial number or progress report')", true);

            }

        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int theid=0;
            try {
                 theid = Convert.ToInt32(canceltxt.Text);
            }
            catch(FormatException ex){
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('you have to inter the serial number')", true);

            }
            SqlCommand cnc = new SqlCommand("CancelThesis", conn);
            cnc.CommandType = CommandType.StoredProcedure;
            cnc.Parameters.Add(new SqlParameter("ThesisSerialNo",theid));
            SqlCommand chck = new SqlCommand("checklastprogrep", conn);
            chck.CommandType = CommandType.StoredProcedure;
            chck.Parameters.Add(new SqlParameter("@ThesisSerialNo", theid));
            SqlParameter okk = chck.Parameters.Add("@ok", SqlDbType.Bit);
            okk.Direction = ParameterDirection.Output;
            SqlCommand check = new SqlCommand("chechser", conn);
            check.CommandType = CommandType.StoredProcedure;
            check.Parameters.Add(new SqlParameter("ThesisSerialNo", theid));
            SqlParameter ok2 = check.Parameters.Add("@bit", SqlDbType.Bit);
            ok2.Direction = ParameterDirection.Output;
            
            conn.Open();
            check.ExecuteNonQuery();
            

            if (ok2.Value.ToString()=="True")
            {
            chck.ExecuteNonQuery();
            cnc.ExecuteNonQuery();

            if(okk.Value.ToString()=="True")
            {
                del.Visible = false;
                    notdel.Visible = true;
            }
            else if(okk.Value.ToString()=="False")
            {
                    del.Visible = true;
                    notdel.Visible = false;
            }

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('there is no thesis with this serial number')", true);
            }
            conn.Close();

        }

        protected void addex_Click(object sender, EventArgs e)
        {
            string dattt = defensedate.Text;
            Session["defensedateforthesis"] = dattt;
            
            string serrr = serialno.Text;
            Session["serialnumber"] = serrr;
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            try
            {


                SqlCommand addexa = new SqlCommand("insintdef", conn);
                addexa.CommandType = CommandType.StoredProcedure;
                addexa.Parameters.Add(new SqlParameter("@date", dattt));
                addexa.Parameters.Add(new SqlParameter("@serialNo", serrr));
                addexa.Parameters.Add(new SqlParameter("@examinerId", add.Text));
                conn.Open();
                addexa.ExecuteNonQuery();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('examiner added successfully')", true);

                conn.Close();
            }
            catch (SqlException )
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('please enter a valid examiner id')", true);

            }
            addnewex.Enabled = false;

        }

        protected void addnewex_Click(object sender, EventArgs e)
        {
            string dattt = defensedate.Text;
            Session["defensedateforthesis"] = dattt;

            string serrr = serialno.Text;
            Session["serialnumber"] = serrr;
            Response.Redirect("new-examiner.aspx");

            addex.Enabled= false;
        }
    }
}
