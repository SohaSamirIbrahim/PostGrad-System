
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
    public partial class Examiner_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["user"] == null || Session["usertype"].ToString() != "3")
            //{
            //    Session["loggedin"] = false;
            //    Response.Redirect("login.aspx");
            //}
        }

        protected void ExaminarViewProfile_Click(object sender, EventArgs e)
        {
            //Response.Write(Session["ExaminerID"]);
            viewEaminarProfile.Visible = true;
            //String connStr = WebConfigurationManager.ConnectionStrings["postgrad3ConnectionString"].ToString();
            //SqlConnection conn = new SqlConnection(connStr);
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void editProfile_Click(object sender, EventArgs e)
        {
            editProf.Visible = true;
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {
                String connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                string newname1 = newname.Text;
                string newfield = field.Text;
                SqlCommand editproc = new SqlCommand("editExaminer", conn);
                editproc.CommandType = CommandType.StoredProcedure;
                editproc.Parameters.Add(new SqlParameter("@id", Session["user"]));
                editproc.Parameters.Add(new SqlParameter("@name", newname1));
                editproc.Parameters.Add(new SqlParameter("@field", newfield));
                conn.Open();
                editproc.ExecuteNonQuery();
                conn.Close();
                viewEaminarProfile.DataBind();
                editProf.Visible = false;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", ex.Message , true);
                Console.WriteLine(ex.Message);
                Console.WriteLine("1");
            }

        }

        protected void viewEverything_Click(object sender, EventArgs e)
        {
            viewEverythinggrid.Visible = true;
        }

        protected void addcomment_Click(object sender, EventArgs e)
        {
            addgrade.Visible = false;
            back2.Visible = false;
            back1.Visible = true;
            submitcomment.Visible = true;
            addcomentfordefense.Visible = true;
        }

        protected void submitcomment_Click(object sender, EventArgs e)
        {
            Success.Visible = false;
        try { 
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int serial = Convert.ToInt32(serialno.Text);
            DateTime date1 =Convert.ToDateTime(date.Text);
            String comm = comment.Text;

            SqlCommand AddCommentsGrade = new SqlCommand("AddCommentsGrade", conn);
            AddCommentsGrade.CommandType = CommandType.StoredProcedure;
            AddCommentsGrade.Parameters.Add(new SqlParameter("@id", Session["user"]));
            AddCommentsGrade.Parameters.Add(new SqlParameter("@ThesisSerialNo", serial));
            AddCommentsGrade.Parameters.Add(new SqlParameter("@DefenseDate", date1));
            AddCommentsGrade.Parameters.Add(new SqlParameter("@comments", comm));
            conn.Open();
            AddCommentsGrade.ExecuteNonQuery();
            conn.Close();

            addgrade.Visible = true;
            addcomentfordefense.Visible=false;
            Success.Text = "Comment Added Successfully";
            Success.Visible = true;
        }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Missing or Invalid data')</script>");

                //ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", ex.Message, true);
                //Console.WriteLine(ex.Message);
                //Console.WriteLine("2");
            }

}

protected void addgrade_Click(object sender, EventArgs e)
        {
            addcomentfordefense.Visible = false;
            addcomment.Visible = false;
            back1.Visible = false;
            back2.Visible = true;
            submitgrade.Visible = true;
            addgradefordefense.Visible = true;
        }

        protected void submitgrade_Click(object sender, EventArgs e)
        {               
            Success.Visible = false;

            try { 
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int serialgrade1 = Convert.ToInt32(serialgrade.Text);
            DateTime dategrade1 = Convert.ToDateTime(dategrade.Text);
            String grade1 = grade.Text;

            SqlCommand AddDefenseGrade = new SqlCommand("AddDefenseGrade", conn);
            AddDefenseGrade.CommandType = CommandType.StoredProcedure;
            AddDefenseGrade.Parameters.Add(new SqlParameter("@id", Session["user"]));
            AddDefenseGrade.Parameters.Add(new SqlParameter("@ThesisSerialNo", serialgrade1));
            AddDefenseGrade.Parameters.Add(new SqlParameter("@DefenseDate", dategrade1));
            AddDefenseGrade.Parameters.Add(new SqlParameter("@grade", grade1));
            conn.Open();
            AddDefenseGrade.ExecuteNonQuery();
            conn.Close();

                addcomentfordefense.Visible = true;

                addgradefordefense.Visible=false;
                Success.Text = "Grade Added Successfully";
                Success.Visible = true;
        }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Missing or Invalid data')</script>");

                //ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", ex.Message, true);
                //Console.WriteLine(ex.Message);
                //Console.WriteLine("3");
            }

        }

protected void search_Click(object sender, EventArgs e)
        {
            try { 
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string word1 = word.Text;
             Session["word1"]=word1;
            SqlCommand search = new SqlCommand("search", conn);
            search.CommandType = CommandType.StoredProcedure;
            search.Parameters.Add(new SqlParameter("@id", Session["user"]));
            search.Parameters.Add(new SqlParameter("@word", word1));
            conn.Open();
            search.ExecuteNonQuery();
            searchgrid.Visible = true;
            conn.Close();
            searchgrid.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", ex.Message, true);
                Console.WriteLine(ex.Message);
                Console.WriteLine("4");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Examiner.aspx");
        }


        protected void goBackCom(object sender, EventArgs e)
        {
            back1.Visible = false;
            submitcomment.Visible = false;
            submitgrade.Visible = false;
            addcomentfordefense.Visible = false;
            back2.Visible = false;
            addcomment.Visible = true;
            addgrade.Visible= true;
        }

        protected void goBackGrade(object sender, EventArgs e)
        {
            back1.Visible = false;
            submitcomment.Visible = false;
            submitgrade.Visible = false;
            addgradefordefense.Visible= false;
            back2.Visible = false;
            addcomment.Visible = true;
            addgrade.Visible = true;
        }
    }
}