using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Collections;

namespace M3_database
{       
     
    public partial class Register_Student : System.Web.UI.Page
    {
        static int c = 0;
        static ArrayList arr = new ArrayList();

        static int bit ;
        SqlParameter s = new SqlParameter("@bitt", SqlDbType.Bit);
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < arr.ToArray().Length; i++)
            {
                a.Controls.Add((Control)arr.ToArray()[i]);
                Literal lit = new Literal();
                lit.Text = "<br /><br />";
           //     a.Controls.Add(lit);
            }

        }
        protected void GucianU(object sender, EventArgs e)
        {
            underGradd.Visible = true;
            UnderGradID.Visible = true;
            bit = 1;
        }
        protected void nonGucian(object sender, EventArgs e)
        {
            underGradd.Visible = false;
            UnderGradID.Visible = false;
            bit = 0;
        }
        protected void Phoneplus(object sender, EventArgs e)
        {
            c++;
            TextBox tb = new TextBox();
            tb.CssClass = "txtname";
            tb.Width = 110;
            tb.Attributes.Add("PlaceHolder", "add mobile");
            arr.Add(tb);
            Response.Write(arr.ToArray().Length);
            a.Controls.Add(tb);
            Literal lit = new Literal();
            lit.Text = "<br /><br />";
           // a.Controls.Add(lit);

        }







        
        
        protected void signupclick(object sender, EventArgs e)
        {
                RadioButton guc = Gucian as RadioButton;
                RadioButton nonguc = NonGucian as RadioButton;

            if (!guc.Checked && !nonguc.Checked)
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
                    SqlCommand sign = new SqlCommand("StudentRegister", conn);
                    sign.CommandType = CommandType.StoredProcedure;
                    SqlCommand undergrad = new SqlCommand("addUndergradID", conn);
                    undergrad.CommandType = CommandType.StoredProcedure;


                    string firstname1 = firstname.Text;
                    string lastname1 = lastname.Text;
                    string password1 = password.Text;
                    string faculty1 = faculty.Text;
                    string email1 = email.Text;
                    string address1 = address.Text;
                    string undergradID = UnderGradID.Text;
                    Decimal GPa = Convert.ToDecimal(GPA.Text);
                    int phonee = Convert.ToInt32((phone.Text));

                    // check email does not already exist
                    SqlCommand check = new SqlCommand("checkEmail", conn);
                    check.CommandType = CommandType.StoredProcedure;
                    check.Parameters.Add(new SqlParameter("@email", email1));
                    SqlParameter valid = check.Parameters.Add("@valid", SqlDbType.Bit);
                    valid.Direction = System.Data.ParameterDirection.Output;

                    sign.Parameters.Add(new SqlParameter("@first_name", firstname1));
                    sign.Parameters.Add(new SqlParameter("@last_name", lastname1));
                    sign.Parameters.Add(new SqlParameter("@password", password1));
                    sign.Parameters.Add(new SqlParameter("@faculty", faculty1));
                    if (bit == 1)
                        sign.Parameters.Add(new SqlParameter("@Gucian", 1));
                    else if (bit == 0)
                        sign.Parameters.Add(new SqlParameter("@Gucian", false));

                    sign.Parameters.Add(new SqlParameter("@email", email1));
                    sign.Parameters.Add(new SqlParameter("@address", address1));

                    conn.Open();
                    check.ExecuteNonQuery();




                    if (valid.Value.ToString() == "True")
                    {
                        sign.ExecuteNonQuery();

                        SqlCommand id = new SqlCommand("SELECT id from PostGradUser where email = '" + email1 + "'", conn);

                        int resultt = (int)id.ExecuteScalar();
                        undergrad.Parameters.Add(new SqlParameter("@studentID", resultt));
                        undergrad.Parameters.Add(new SqlParameter("@undergradID", undergradID));

                        if (bit == 1)
                        {
                            SqlCommand update = new SqlCommand("update GucianStudent set GPA = '" + GPa + "' where id = '" + resultt + "'", conn);
                            update.ExecuteNonQuery();
                        }
                        else if (bit == 0)
                        {
                            SqlCommand update = new SqlCommand("update NonGucianStudent set GPA = '" + GPa + "' where id = '" + resultt + "'", conn);
                            update.ExecuteNonQuery();
                        }
                        undergrad.ExecuteNonQuery();

                        SqlCommand addphonee = new SqlCommand("addMobile", conn);
                        addphonee.CommandType = CommandType.StoredProcedure;
                        addphonee.Parameters.Add(new SqlParameter("@ID", resultt));
                        addphonee.Parameters.Add(new SqlParameter("@mobile_number", phonee));
                        addphonee.ExecuteNonQuery();


                        for (int i = 0; i < arr.ToArray().Length; i++)
                        {
                            int phonenum = Convert.ToInt32(((TextBox)arr[i]).Text);

                            SqlCommand addphone = new SqlCommand("addMobile", conn);
                            addphone.CommandType = CommandType.StoredProcedure;
                            addphone.Parameters.Add(new SqlParameter("@ID", resultt));
                            addphone.Parameters.Add(new SqlParameter("@mobile_number", phonenum));
                            addphone.ExecuteNonQuery();
                        }
                        conn.Close();

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