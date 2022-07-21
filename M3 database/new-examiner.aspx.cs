using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project1
{
    public partial class new_examiner : System.Web.UI.Page
    {
        static int bit;
        protected void national_CheckedChanged(object sender, EventArgs e)
        {
            bit = 1;
        }

        protected void international_CheckedChanged(object sender, EventArgs e)
        {
            bit=0;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || (String)Session["usertype"] != "2")
            {
                Session["loggedIn"] = false;
                Response.Redirect("login.aspx");

            }
        }

        protected void Unnamed5_Click(object sender, EventArgs e)
        {

            String connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string name1 = name.Text;
            string fieldoofwork1 = fieldOfWork.Text;
            string password1 = password.Text;
            string email1 = email.Text;

            SqlCommand insert = new SqlCommand("INSERT INTO PostGradUser values ('" + email1 + "','" + password1 + "')", conn);
            conn.Open();

            insert.ExecuteNonQuery();
            conn.Close();

            SqlCommand id = new SqlCommand("SELECT id from PostGradUser where email = '" + email1 + "'", conn);

            conn.Open();

            id.ExecuteNonQuery();
            int resultt = (int)id.ExecuteScalar();
            conn.Close();

            conn.Open();

            if (bit == 1)
            {
                SqlCommand insertexaminer = new SqlCommand("INSERT INTO Examiner Values ('" + resultt + "' , '" + name1 + "' , '" + fieldoofwork1 + "', 1 )", conn);

                insertexaminer.ExecuteNonQuery();
            }
            else if (bit == 0)
            {
                SqlCommand insertexaminer = new SqlCommand("INSERT INTO Examiner Values ('" + resultt + "','" + name1 + "' , '" + fieldoofwork1 + "', 0 )", conn);
                insertexaminer.ExecuteNonQuery();

            }
            SqlCommand addexa = new SqlCommand("insintdef", conn);
            addexa.CommandType = CommandType.StoredProcedure;
            addexa.Parameters.Add(new SqlParameter("@date", (string)Session["defensedateforthesis"]));
            addexa.Parameters.Add(new SqlParameter("@serialNo", (string)Session["serialnumber"]));
            addexa.Parameters.Add(new SqlParameter("@examinerId", resultt));
            addexa.ExecuteNonQuery();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('examiner added successfully')", true);
            conn.Close();
            Response.Redirect("supervisor.aspx");
        }
    }
}