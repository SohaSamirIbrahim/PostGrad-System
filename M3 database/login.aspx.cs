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
    public partial class login : System.Web.UI.Page
    {
        static int idd;
        protected void Page_Load(object sender, EventArgs e)
        {
           if(Session["loggedIn"] is false) {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Kindly login or Register first')", true);
            }
        }

        protected void hazoum(object sender, EventArgs e)
        {
           Response.Redirect("type.aspx");

        }
        protected void signin(object sender, EventArgs e)
        { 
        String connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();

        SqlConnection conn = new SqlConnection(connStr);

        String email =txt_username.Text;
        String pass = txt_password.Text;
           
            SqlCommand emaill = new SqlCommand("SELECT id from PostGradUser where email = '" + email + "'", conn);
            try
            {
                conn.Open();
                int result = (int)emaill.ExecuteScalar();
                idd=result;
                conn.Close();


            SqlCommand loginProc = new SqlCommand("userLogin", conn);
        loginProc.CommandType = CommandType.StoredProcedure;

            loginProc.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar)).Value = result;
            loginProc.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar)).Value = pass;


                SqlParameter sucess = loginProc.Parameters.Add("@success", SqlDbType.Bit);
        sucess.Direction = System.Data.ParameterDirection.Output;

                SqlParameter usertype = loginProc.Parameters.Add("@type", SqlDbType.Int);
                usertype.Direction = System.Data.ParameterDirection.Output;


                conn.Open();
            emaill.ExecuteNonQuery();
            loginProc.ExecuteNonQuery();

            conn.Close();
                if (sucess.Value.ToString() == "True")
                {
                    Session["user"] = result;
                    Session["password"] = pass;
                    Session["email"] = email;
                    Session["usertype"] = usertype.Value.ToString();
                    if (usertype.Value.ToString().Equals("0"))
                        Response.Redirect("Student.aspx");

                    else if (usertype.Value.ToString().Equals("1"))
                        Response.Redirect("Admin.aspx");

                    else if (usertype.Value.ToString().Equals("2"))
                        Response.Redirect("SuperVisor.aspx");

                    else if (usertype.Value.ToString().Equals("3"))
                        Response.Redirect("Examiner.aspx");

                    else if (usertype.Value.ToString().Equals("4"))
                    {
                        Response.Redirect("nongucianStudent.aspx");
                    }
                    else
                    {
                        wrong.Visible = true;

                    }
                }
                
                else
            {
                    wrong.Visible=true;
            }
            }
            catch (Exception ex)
            {
                wrong.Visible = true;
            }
        }
    }
}