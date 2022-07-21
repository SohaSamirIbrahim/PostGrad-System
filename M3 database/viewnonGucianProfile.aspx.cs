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
    public partial class viewnonGucianProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();

            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();


                if(Session["usertype"].ToString() != "4")
                {
                    Session["loggedIn"] = false;
                    Response.Redirect("login.aspx");
                }
                SqlCommand view = new SqlCommand("viewMyProfile", conn);
                view.CommandType = CommandType.StoredProcedure;
                view.Parameters.Add(new SqlParameter("@studentId", SqlDbType.Int)).Value = Session["user"];
                SqlDataReader s = view.ExecuteReader();
                GridView gridView = new GridView();
                gridView.DataSource = s;
                gridView.DataBind();
                Session["Studentfirstname"] = gridView.Rows[0].Cells[1].Text;
                Session["Studentlastname"] = gridView.Rows[0].Cells[2].Text;
                Session["Studenttype"] = gridView.Rows[0].Cells[3].Text;
                Session["Studentfaculty"] = gridView.Rows[0].Cells[4].Text;
                Session["Studentaddress"] = gridView.Rows[0].Cells[5].Text;
                Session["StudentGPA"] = gridView.Rows[0].Cells[6].Text;
               // Session["StudentundergradId"] = gridView.Rows[0].Cells[7].Text;
                Session["Studentemail"] = gridView.Rows[0].Cells[7].Text;

                stufirstname.Text = "FirstName:" + "    " + Session["Studentfirstname"].ToString();
                stulastname.Text = "LastName:" + "" + Session["Studentlastname"].ToString();
                stufaculty.Text = "Faculty:" + "    " + Session["Studentfaculty"].ToString();
                stutype.Text = "Type:" + Session["Studenttype"].ToString();
                stuaddress.Text = "Address:" + "    " + Session["Studentaddress"].ToString();
                stuGPA.Text = "GPA:" + Session["StudentGPA"].ToString();
               // underGradd.Text = "UnderGrad ID:" + "    " + Session["StudentundergradId"].ToString();
                stuemail.Text = "Email:" + "    " + Session["Studentemail"].ToString();
                stuID.Text = "Student ID:" + "    " + Session["user"];
                conn.Close();
            }
            catch
            {
                Session["loggedIn"] = false;
                Response.Redirect("login.aspx");
            }

        }
    }
}