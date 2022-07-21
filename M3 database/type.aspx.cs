using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M3_database
{
    public partial class type : System.Web.UI.Page
    {
        static String typee="";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       
        protected void supervisor(object sender, EventArgs e)
        {


            Response.Redirect("Register-Supervisor.aspx");
            typee = "supervisor";
        }
        protected void Student(object sender, EventArgs e)
        {

            Response.Redirect("Register-Student.aspx");

            typee = "Student";
        }
        protected void examiner(object sender, EventArgs e)
        {
            Response.Redirect("Register-Examiner.aspx");

            typee = "examiner";

        }
        protected void Confirm(object sender, EventArgs e)
        {

           if (typee == "Student")
                Response.Redirect("Register-Student.aspx");
            else if(typee=="supervisor")
                Response.Redirect("Register-Supervisor.aspx");
            else if(typee=="examiner")
                Response.Redirect("Register-Examiner.aspx");
        }
    }
}