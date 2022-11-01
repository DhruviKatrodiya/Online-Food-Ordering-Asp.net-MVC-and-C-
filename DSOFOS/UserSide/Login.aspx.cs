using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSOFOS.UserSide
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check if user already log in or not
                if(Session["username"] != null)
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        //Does Login for user as well as for admin
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=DSOFOSDB;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select * from UserMaster where EmailId='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(TextBox1.Text == "Admin" & TextBox2.Text == "123")
            {
                Session["admin"] = TextBox1.Text;
                Response.Redirect("~/Admin/Dashboard.aspx");
            }
            else if(dt.Rows.Count == 1)
            {
                Session["username"] = TextBox1.Text;
                Session["buyitems"] = null;
                fillSavedCart();
                Response.Redirect("Default.aspx");
            }
            else
            {
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "Login Failed";
            }
        }

        //After user logged in it will fetch all cart items which were added by that user previously & storing it in session
        private void fillSavedCart()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("sno");
            dt.Columns.Add("mid");
            dt.Columns.Add("mname");
            dt.Columns.Add("mimage");
            dt.Columns.Add("mdesc");
            dt.Columns.Add("mprice");
            dt.Columns.Add("mquantity");
            dt.Columns.Add("mcategory");
            dt.Columns.Add("mtotalprice");
            String mycon = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=DSOFOSDB;Integrated Security=True";
            SqlConnection scon = new SqlConnection(mycon);
            String myquery = "select * from CartDetails where EmailId='" + Session["username"].ToString() + "'";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = scon;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            if(ds.Tables[0].Rows.Count > 0)
            {
                int i = 0;
                int counter = ds.Tables[0].Rows.Count;
                while(i < counter)
                {
                    dr = dt.NewRow();
                    dr["sno"] = i + 1;
                    dr["mid"] = ds.Tables[0].Rows[i]["MenuItemId"].ToString();
                    dr["mname"] = ds.Tables[0].Rows[i]["MenuItemName"].ToString();
                    dr["mimage"] = ds.Tables[0].Rows[i]["MenuItemImage"].ToString();
                    dr["mdesc"] = ds.Tables[0].Rows[i]["MenuItemDescription"].ToString();
                    dr["mprice"] = ds.Tables[0].Rows[i]["Amount"].ToString();
                    dr["mquantity"] = ds.Tables[0].Rows[i]["Quantity"].ToString();
                    dr["mcategory"] = ds.Tables[0].Rows[i]["Pcategory"].ToString();
                    int price = Convert.ToInt32(ds.Tables[0].Rows[i]["mprice"].ToString());
                    int quantity = Convert.ToInt16(ds.Tables[0].Rows[i]["mquantity"].ToString());
                    int totalprice = price * quantity;
                    dr["mtotalprice"] = totalprice;
                    dt.Rows.Add(dr);
                    i = i + 1;
                }
            }
            else
            {
                Session["buyitems"] = null;
            }
            Session["buyitems"] = dt;
        }

        //Redirects you to register page
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}