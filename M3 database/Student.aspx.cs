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
    public partial class Student : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["usertype"].ToString()!="0")
            {
                Session["loggedIn"] = false;
                Response.Redirect("login.aspx");
            }
        }

        

       
    }
}