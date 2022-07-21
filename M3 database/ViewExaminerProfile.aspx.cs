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
    public partial class ViewExaminerProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                try
                {

                    Session["ExaminerName_S"] = viewEaminarProfile.Rows[0].Cells[1].Text;
                    Session["ExaminerField_S"] = viewEaminarProfile.Rows[0].Cells[2].Text;
                    if (viewEaminarProfile.Rows[0].Cells[3].Text == "True")
                    {

                        Nationalcheck.Checked = true;

                    }
                    else
                    {
                        Nationalcheck.Checked = false;

                    }
                    name.Text =  Session["ExaminerName_S"].ToString();
                    fieldOfwork.Text =  Session["ExaminerField_S"].ToString();
                    ExaminerEmail.Text = Session["email"].ToString();
                    ExamID.Text = Session["user"].ToString();    

                    }
                catch
                {
                    Session["loggedIn"] = false;
                    Response.Redirect("login.aspx");
                }
            

            
        }
        protected void editProfile_Click(object sender, EventArgs e)
        {
            newname.Visible = true;
            field.Visible=true;
            submitedit.Visible=true;
            Button_edit.Visible = false;
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
                viewEaminarProfile.DataBind();

                conn.Close();
                viewEaminarProfile.DataBind();

                submitedit.Visible = false;
                Button_edit.Visible = true ;
                newname.Visible = false;
                field.Visible = false;
                Session["ExaminerName_S"] = viewEaminarProfile.Rows[0].Cells[1].Text;
                    Session["ExaminerField_S"] = viewEaminarProfile.Rows[0].Cells[2].Text;
                    if (viewEaminarProfile.Rows[0].Cells[3].Text == "True")
                    {

                        Nationalcheck.Checked = true;

                    }
                    else
                    {
                        Nationalcheck.Checked = false;

                    }
                    name.Text = Session["ExaminerName_S"].ToString();
                    fieldOfwork.Text = Session["ExaminerField_S"].ToString();
                    ExaminerEmail.Text = Session["email"].ToString();
                   
                
                

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", ex.Message, true);
                Console.WriteLine(ex.Message);
                Console.WriteLine("1");
            }

        }
    }
}