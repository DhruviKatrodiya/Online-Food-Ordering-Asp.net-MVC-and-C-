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
    public partial class Default1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=DSOFOSDB;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["addmenu"] = false;
            //Login Session
            if(Session["username"] != null)
            {
                Label4.Text = "Logged in as" + Session["username"].ToString();
                HyperLink1.Visible = false;
                Button1.Visible = true;
            }
            else
            {
                Label4.Text = "Hello you can Login here...";
                HyperLink1.Visible = true;
                Button1.Visible = false;
            }
            if(!IsPostBack)
            {
                Drp_MenuCategory();
            }
        }

        //logout button
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
            Label4.Text = "You have Logged Out Successfully...";
        }

        //Displaying Menu based on selected category
        protected void MenuCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strQuery = "";
            string selectedMenu = MenuCategories.SelectedItem.Text;
            if(selectedMenu == "Menu Category")
            {
                strQuery = "";
            }
            else
            {
                strQuery = "where Pcategory = '" + selectedMenu + "' ";
            }
            SqlDataAdapter sda = new SqlDataAdapter("Select * from MenuItem " + strQuery + " ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            try
            {
                if(selectedMenu == dt.Rows[0][7].ToString())
                {

                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('No MenuItem Found')</script>");
            }
            DataList1.DataSourceID = null;
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

        //searching menu based on menu name and category
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from MenuItem where (MenuItemName like '%" + TextBox1.Text +"%') or (Pcategory like '%" + TextBox1.Text + "%')",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataList1.DataSourceID = null;
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

        //passing data of which menu item is being selected & quantity by user to cart page
        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            Session["addmenu"] = "true";
            if(e.CommandName == "AddToCart")
            {
                DropDownList list = (DropDownList)(e.Item.FindControl("DropDownList1"));
                Response.Redirect("AddtoCart.aspx?id=" + e.CommandArgument.ToString() + "&quantity=" + list.SelectedItem.ToString());
            }
        }

        //for displaying the quantity of product exists  in stock & hiding AddToCart button if product is not in stock
        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label MenuItemId = e.Item.FindControl("Label6") as Label;
            Label stock = e.Item.FindControl("Label5") as Label;
            ImageButton btn = e.Item.FindControl("ImageButton1") as ImageButton;
            SqlDataAdapter sda = new SqlDataAdapter("Select * from MenuItem where MenuItemId= '" + MenuItemId.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            String stockdata = "";
            if(dt.Rows.Count > 0)
            {
                stockdata = dt.Rows[0]["Quantity"].ToString();
            }
            con.Close();    
            if(stockdata == "0")
            {
                stock.Text = "Out of Stock";
                btn.Enabled = false;
                btn.ImageUrl = "Images/SoldOut.png";
            }
            else
            {
                stock.Text = stockdata;
            }
        }

        //Display Menu Category in dropdownlist
        public void Drp_MenuCategory()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Category",con);
            MenuCategories.DataSource = cmd.ExecuteReader();
            MenuCategories.DataTextField = "CategoryName";
            MenuCategories.DataValueField = "CategoryId";
            MenuCategories.DataBind();
            MenuCategories.Items.Insert(0, "Menu Category");
            con.Close();
        }

    }
}