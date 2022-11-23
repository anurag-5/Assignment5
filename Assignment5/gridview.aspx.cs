using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Assignment5
{
    public partial class gridview : System.Web.UI.Page
    {
        DatabaseSample db = new DatabaseSample();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = db.exedataset("select * from Employee");
                GridView1.DataBind();
            }
        }




        protected void Gridview1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex; //set edit index
            GridView1.DataSource = db.exedataset("select * from Employee"); //value taking from table
            GridView1.DataBind(); //binding data extracted from the table to the grid view 
        }

        protected void Gridview1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //take datakey value from grid view
            string empid = GridView1.DataKeys[e.RowIndex].Value.ToString(); //tacking emp value of the selected row
            //create a text box and initialize
            TextBox txtname = new TextBox();
            //access first column and assign to textbox
            txtname = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0];
            Response.Write("<script>alert(txtname);</script>");
            //create a text box and initialize
            TextBox txtemail = new TextBox();
            //access 2nd column and assign to textbox
            txtemail = (TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0];
            Response.Write("<script>alert(txtsalary);</script>");
            //create a text box for salary and initialize
            TextBox txtphone = new TextBox();
            //access 3rd column and assign to textbox
            txtphone = (TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0];
            db.exenonquery("update Employee set Name='" + txtname.Text + "',Email='" + txtemail.Text + "',Phone='" + txtphone.Text + "'where Id='" + empid + "'");
            GridView1.EditIndex = -1;  //previous view stage -1 indicate previous view only 
            GridView1.DataSource = db.exedataset("select * from Employee");
            GridView1.DataBind();

        }

        protected void Gridview1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;  //previous view stage -1 indicate previous view only 
            GridView1.DataSource = db.exedataset("select * from Employee");
            GridView1.DataBind();

        }

        protected void Gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string empid = GridView1.DataKeys[e.RowIndex].Value.ToString(); //tacking emp value of the selected row
            db.exenonquery("Delete from Employee where Id='" + empid + "'");
            GridView1.DataSource = db.exedataset("select * from Employee");
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}