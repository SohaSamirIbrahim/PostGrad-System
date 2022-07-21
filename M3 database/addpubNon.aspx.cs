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
    public partial class addpubNon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null||Session["usertype"].ToString() != "4")
            {
                Session["loggedIn"] = false;
                Response.Redirect("login.aspx");
            }
        }

        protected void addpub(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();

            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();

                SqlCommand addpublication = new SqlCommand("addPublication", conn);
                addpublication.CommandType = CommandType.StoredProcedure;
                addpublication.Parameters.Add(new SqlParameter("@title", title.Text));
                addpublication.Parameters.Add(new SqlParameter("@pubDate", pubDate.Text));
                addpublication.Parameters.Add(new SqlParameter("@host", host.Text));
                addpublication.Parameters.Add(new SqlParameter("@place", place.Text));
                if (CheckBox1.Checked)
                    addpublication.Parameters.Add(new SqlParameter("@accepted", 1));
                else
                    addpublication.Parameters.Add(new SqlParameter("@accepted", false));

                addpublication.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                SqlCommand getpubid = new SqlCommand("select max(Publication.id) from Publication", conn);
                int pubid = (int)getpubid.ExecuteScalar();

                int userid_h = Convert.ToInt32(Session["user"]);
                SqlCommand getallpub = new SqlCommand("liststudentongoinghelper", conn);
                getallpub.CommandType = CommandType.StoredProcedure;
                getallpub.Parameters.Add(new SqlParameter("@studentID", userid_h));

                SqlDataReader s22 = getallpub.ExecuteReader();
                GridView gridView22 = new GridView();
                gridView22.DataSource = s22;
                gridView22.DataBind();

                int thesisnum = Convert.ToInt32(gridView22.Rows[DropDownList1.SelectedIndex].Cells[0].Text);
                conn.Close();

                conn.Open();
                SqlCommand linkpublication = new SqlCommand("linkPubThesis", conn);
                linkpublication.CommandType = CommandType.StoredProcedure;
                linkpublication.Parameters.Add(new SqlParameter("@PubID", pubid));
                linkpublication.Parameters.Add(new SqlParameter("@thesisSerialNo", thesisnum));
                linkpublication.ExecuteNonQuery();

                pubadded.Visible = true;
                conn.Close();
            }
            catch
            {
                pubfailed.Visible = true;

            }

        }
    }
}