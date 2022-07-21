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
    public partial class Register_Examiner : System.Web.UI.Page
    {
        static int bit;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void national_CheckedChanged(object sender, EventArgs e)
        {
            bit = 1;
        }

        protected void international_CheckedChanged(object sender, EventArgs e)
        {
            bit = 0;
        }
        protected void signupclick(object sender, EventArgs e)
        {
            Exists.Visible = false;
            wrong.Visible = false;

            RadioButton ISnational = national as RadioButton;
            RadioButton ISNOTNational = international as RadioButton;

            if (!ISnational.Checked && !ISNOTNational.Checked)
            {
                radioUnchecked.Visible = true;
            }
            else
            {
                radioUnchecked.Visible = false;

                try
                {
                    String connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();
                    SqlConnection conn = new SqlConnection(connStr);
                    string name1 = name.Text;
                    string fieldoofwork1 = fieldOfWork.Text;
                    string password1 = password.Text;
                    string email1 = email.Text;



                    // check email does not already exist
                    SqlCommand check = new SqlCommand("checkEmail", conn);
                    check.CommandType = CommandType.StoredProcedure;
                    check.Parameters.Add(new SqlParameter("@email", email1));
                    SqlParameter valid = check.Parameters.Add("@valid", SqlDbType.Bit);
                    valid.Direction = System.Data.ParameterDirection.Output;
                    conn.Open();
                    check.ExecuteNonQuery();
                    conn.Close();
                    if (valid.Value.ToString() == "True")
                    {

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
                        conn.Close();

                        Session["ExaminerID"] = resultt;

                        Response.Redirect("login.aspx");
                    }
                    else
                    {


                        Exists.Visible = true;
                        wrong.Visible = true;


                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Invalid Entry Format')</script>");
                }
            }
        }

}
}