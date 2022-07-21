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
    public partial class addfillNon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null|| Session["usertype"].ToString()!="4")
            {
                Session["loggedIn"] = false;
                Response.Redirect("login.aspx");
            }

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {



        }
        protected void SqlDataSource1_Updating(object sender, SqlDataSourceCommandEventArgs e)
        {


        }


        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            try
            {
                Session["thesisserial"] = GridView1.Rows[e.NewEditIndex].Cells[6].Text.ToString();
                Session["progressno"] = GridView1.Rows[e.NewEditIndex].Cells[1].Text;

                TextBox states = GridView1.Rows[e.NewEditIndex].FindControl("TextBox1") as TextBox;
                Session["states1"] = Convert.ToInt32(states.Text);

                TextBox description = GridView1.Rows[e.NewEditIndex].FindControl("TextBox2") as TextBox;
                Session["description1"] = description.Text;
                Session["date"] = DateTime.Now;

            }
            catch (Exception ex)
            {

            }


        }






        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }


        protected void Button1_Click1(object sender, EventArgs e)
        {



        }

        protected void Addprogress(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();

            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                addprogerr1.Visible = false;
                addprogerr2.Visible = false;
                addprogerr3.Visible = false;
                addprogerr4.Visible = false;
                addprogerr5.Visible = false;
                addprogerr6.Visible = false;

                int serialnum = Convert.ToInt32(serial.Text);
                DateTime defdat = Convert.ToDateTime(datedef.Text);
                int prognum = Convert.ToInt32(progressReportNo.Text);


                if (serial.Text == null || serial.Text == "")
                {
                    addprogerr1.Visible = true;
                    addprogerr2.Visible = false;
                    addprogerr3.Visible = false;
                    addprogerr4.Visible = false;
                    addprogerr5.Visible = false;
                    addprogerr6.Visible = false;

                }
                else if (datedef.Text == null || datedef.Text == "")
                {
                    addprogerr1.Visible = false;
                    addprogerr2.Visible = true;
                    addprogerr3.Visible = false;
                    addprogerr4.Visible = false;
                    addprogerr5.Visible = false;
                    addprogerr6.Visible = false;

                }
                else if (progressReportNo == null || progressReportNo.Text == "")
                {
                    addprogerr1.Visible = false;
                    addprogerr2.Visible = false;
                    addprogerr3.Visible = true;
                    addprogerr4.Visible = false;
                    addprogerr5.Visible = false;
                    addprogerr6.Visible = false;

                }
                else if (prognum < 1)
                {
                    addprogerr1.Visible = false;
                    addprogerr2.Visible = false;
                    addprogerr3.Visible = false;
                    addprogerr4.Visible = false;
                    addprogerr5.Visible = true;
                    addprogerr6.Visible = false;

                }

                else
                {

                    SqlCommand addprog = new SqlCommand("AddProgressReport", conn);
                    addprog.CommandType = CommandType.StoredProcedure;

                    addprog.Parameters.Add(new SqlParameter("@thesisSerialNo", SqlDbType.Int)).Value = serialnum;
                    addprog.Parameters.Add(new SqlParameter("@progressReportDate", SqlDbType.DateTime)).Value = defdat;
                    addprog.Parameters.Add(new SqlParameter("@studentID", SqlDbType.Int)).Value = Session["user"];
                    addprog.Parameters.Add(new SqlParameter("@progressReportNo", SqlDbType.Int)).Value = prognum;
                    GridView1.DataBind();
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    try
                    {
                        addprog.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        addprogerr1.Visible = false;
                        addprogerr2.Visible = false;
                        addprogerr3.Visible = false;
                        addprogerr4.Visible = true;
                        addprogerr5.Visible = false;
                        addprogerr6.Visible = false;
                    }
                    conn.Close();
                    GridView1.DataBind();

                }
            }
            catch (Exception ex)
            {
                if (serial.Text == null || serial.Text == "")
                {
                    addprogerr1.Visible = true;
                    addprogerr2.Visible = false;
                    addprogerr3.Visible = false;
                    addprogerr4.Visible = false;
                    addprogerr5.Visible = false;
                    addprogerr6.Visible = false;

                }
                else if (datedef.Text == null || datedef.Text == "")
                {
                    addprogerr1.Visible = false;
                    addprogerr2.Visible = true;
                    addprogerr3.Visible = false;
                    addprogerr4.Visible = false;
                    addprogerr5.Visible = false;
                    addprogerr6.Visible = false;

                }
                else if (progressReportNo == null || progressReportNo.Text == "")
                {
                    addprogerr1.Visible = false;
                    addprogerr2.Visible = false;
                    addprogerr3.Visible = true;
                    addprogerr4.Visible = false;
                    addprogerr5.Visible = false;
                    addprogerr6.Visible = false;

                }
                else
                {
                    addprogerr1.Visible = false;
                    addprogerr2.Visible = false;
                    addprogerr3.Visible = false;
                    addprogerr4.Visible = false;
                    addprogerr5.Visible = false;
                    addprogerr6.Visible = true;
                }
            }




        }





    }
}


