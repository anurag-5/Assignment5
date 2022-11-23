using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DatabaseSample ds = new DatabaseSample();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into Employee values('" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "')";
            int i = ds.exenonquery(sql);
            if (i == 1)
            {
                Response.Write("<script>alert('inserted Successfully ');</script>");
            }
            else
            {
                Response.Write("Insertion Fail");
            }
        }
    }
}