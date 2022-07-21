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
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || (String)Session["usertype"] != "3")
            {
                Session["loggedIn"] = false;
                Response.Redirect("login.aspx");

            }
        }

        protected void search_Click(object sender, EventArgs e)
        {
            string word1 = word.Text;
            Session["word1"] = word1;
            searchgrid.Visible = true;
             
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Examiner.aspx");
        }
    }
}