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
    public partial class SupervisorPublication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["usertype"].ToString() != "2")
            {
                Session["loggedIn"] = false;
                Response.Redirect("login.aspx");

            }
        }

        protected void viewPub(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string textb = stuidpub.Text;
            SqlCommand cmd = new SqlCommand("checkid4", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@studentID", textb));

            SqlParameter valid = cmd.Parameters.Add("@valid", SqlDbType.Bit);
            valid.Direction = ParameterDirection.Output;
            conn.Open();
            try
            {

                cmd.ExecuteNonQuery();
                SqlDataSource1.SelectParameters["StudentID"].DefaultValue = textb;
                if (valid.Value.ToString() == "True")
                {
                    textb = "";

                    xx.Visible = false;
                    GridView1.Visible = true;
                }
                else
                {
                    textb = "";
                    xx.Visible = true;
                    GridView1.Visible = false;
                }
            }
            catch (SqlException)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('wrong serial number')", true);

            }
            conn.Close();
        }
    }
}