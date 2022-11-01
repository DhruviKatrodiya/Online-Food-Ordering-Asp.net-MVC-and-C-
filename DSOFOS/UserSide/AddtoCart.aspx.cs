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
    public partial class AddtoCart : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=DSOFOSDB;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //check whether user is logged in or not
                if(Session["username"] == null)
                {
                    Response.Redirect("Login.aspx");
                }

                //Adding menu to dridview
                //Adding Datarow & then columns to datatable
                DataTable dt =  new DataTable();
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
                if(Request.QueryString["id"] != null)
                {
                    if(Session["buyitems"] == null)
                    {
                        dr = dt.NewRow();
                        SqlDataAdapter da = new SqlDataAdapter("select * from MenuItem where MenuItemId=" + Request.QueryString["id"],con);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dr["sno"] = 1;
                        dr["mid"] = ds.Tables[0].Rows[0]["MenuItemId"].ToString();
                        dr["mname"] = ds.Tables[0].Rows[0]["MenuItemName"].ToString();
                        dr["mimage"] = ds.Tables[0].Rows[0]["MenuItemImage"].ToString();
                        dr["mdesc"] = ds.Tables[0].Rows[0]["MenuItemDescription"].ToString();
                        dr["mprice"] = ds.Tables[0].Rows[0]["Amount"].ToString();
                        dr["mquantity"] = Request.QueryString["Quantity"].ToString();
                        dr["mcategory"] = ds.Tables[0].Rows[0]["Pcategory"].ToString();
                        int price = Convert.ToInt32(ds.Tables[0].Rows[0]["mprice"].ToString());
                        int quantity = Convert.ToInt16(Request.QueryString["mquantity"].ToString());
                        int TotalPrice = price * quantity;
                        dr["mtotalprice"] = TotalPrice;
                        dt.Rows.Add(dr);
                        con.Open();
                        SqlCommand cmd = new SqlCommand("Insert into CartDetails values('" + dr["sno"] + "','" + dr["mid"] + "','" + dr["mname"] + "','" + dr["mimage"] + "','" + dr["mdesc"] + "','" + dr["mprice"] + "','" + dr["mquantity"] + "','" + dr["mcategory"] + "','" + Session["username"].ToString() + "')",con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["buyitems"] = dt;
                        Button1.Enabled = true;
                        GridView1.FooterRow.Cells[6].Text = "Total Amount";
                        GridView1.FooterRow.Cells[7].Text = grandtotal().ToString();
                        Response.Redirect("AddtoCart.aspx");
                    }
                    else
                    {
                        dt = (DataTable)Session["buyitems"];
                        int sr;
                        sr = dt.Rows.Count;
                        dr = dt.NewRow();
                        SqlDataAdapter da = new SqlDataAdapter("select * from MenuItem where MenuItemId=" + Request.QueryString["id"], con);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dr["sno"] = sr + 1;
                        dr["mid"] = ds.Tables[0].Rows[0]["MenuItemId"].ToString();
                        dr["mname"] = ds.Tables[0].Rows[0]["MenuItemName"].ToString();
                        dr["mimage"] = ds.Tables[0].Rows[0]["MenuItemImage"].ToString();
                        dr["mdesc"] = ds.Tables[0].Rows[0]["MenuItemDescription"].ToString();
                        dr["mprice"] = ds.Tables[0].Rows[0]["Amount"].ToString();
                        dr["mquantity"] = Request.QueryString["Quantity"].ToString();
                        int price = Convert.ToInt32(ds.Tables[0].Rows[0]["mprice"].ToString());
                        int quantity = Convert.ToInt16(Request.QueryString["mquantity"].ToString());
                        int TotalPrice = price * quantity;
                        dr["mtotalprice"] = TotalPrice;
                        dt.Rows.Add(dr);
                        con.Open();
                        SqlCommand cmd = new SqlCommand("Insert into CartDetails values('" + dr["sno"] + "','" + dr["mid"] + "','" + dr["mname"] + "','" + dr["mimage"] + "','" + dr["mdesc"] + "','" + dr["mprice"] + "','" + dr["mquantity"] + "','" + dr["mcategory"] + "','" + Session["username"].ToString() + "')", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["buyitems"] = dt;
                        Button1.Enabled = true;
                        GridView1.FooterRow.Cells[6].Text = "Total Amount";
                        GridView1.FooterRow.Cells[7].Text = grandtotal().ToString();
                        Response.Redirect("AddtoCart.aspx");
                    }
                }
                else
                {
                    dt = (DataTable)Session["buyitems"];
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    if(GridView1.Rows.Count > 0)
                    {
                        GridView1.FooterRow.Cells[6].Text = "Total Amount";
                        GridView1.FooterRow.Cells[7].Text = grandtotal().ToString();
                    }
                }
            }

            //If no menu present in cart then it will disable clearcart button & placeorder button  
            if(GridView1.Rows.Count.ToString() == "0")
            {
                LinkButton1.Enabled = false;
                LinkButton1.ForeColor = System.Drawing.Color.White;
                Button1.Enabled = false;
                Button1.Text = "Oops";
            }
            else
            {
                LinkButton1.Enabled = true;
                Button1.Enabled = true;
            }
            orderid();

        }

        //Calculating final price
        public int grandtotal()
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["buyitems"];
            int nrow = dt.Rows.Count;
            int i = 0;
            int totalprice = 0;
            while(i < nrow)
            {
                totalprice = totalprice + Convert.ToInt32(dt.Rows[i]["mtotalprice"].ToString());
                i = i + 1;
            }
            return totalprice;
        }

        //Generates Order Id for a order created
        public void orderid()
        {
            String alpha = "abCdefghIjklmNopqrStuvwXyz123456789";
            Random r = new Random();
            char[] myArray = new char[5];
            for(int i = 0; i < 5; i++)
            {
                myArray[i] = alpha[(int)(35 * r.NextDouble())];
            }
            String orderid;
            orderid = "Order_Id:" + DateTime.Now.Hour.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() +
                DateTime.Now.Year.ToString() + new string(myArray) + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            Session["Orderid"] = orderid;
        }

        //Link button for clearing cart items
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["buyitems"] = null;
            clearCart();
        }

        //Deleting selected menu from cart
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["buyitems"];
            for(int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                int sr;
                int sr1;
                string qdata;
                string dtdata;
                sr = Convert.ToInt32(dt.Rows[i]["sno"].ToString());
                TableCell cell = GridView1.Rows[e.RowIndex].Cells[0];
                qdata = cell.Text;
                dtdata = sr.ToString();
                sr1 = Convert.ToInt32(qdata);
                TableCell prID = GridView1.Rows[e.RowIndex].Cells[1];
                if(sr == sr1)
                {
                    dt.Rows[i].Delete();
                    dt.AcceptChanges();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete top (1) from CartDetails where MenuItemId='" + prID.Text + "' and EmailId='" + Session["username"] + "'",con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //Item has been deleted from DSOFOS
                    break;
                }
            }

            //Setting Sno. after deleting row item from cart
            for(int i = 1; i <= dt.Rows.Count; i++)
            {
                dt.Rows[i - 1]["sno"] = i;
                dt.AcceptChanges();
            }
            Session["buyitems"] = dt;
            Response.Redirect("AddtoCart.aspx");
        }

        //Redirecting to payment page
        protected void Button1_Click(object sender, EventArgs e)
        {
            bool isTrue = false;
            //first of all it will check that existing menu in cart is in stock or not
            DataTable dt = (DataTable)Session["buyitems"];
            for(int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                int pId = Convert.ToInt16(dt.Rows[i]["mid"]);
                int pQuantity = Convert.ToInt16(dt.Rows[i]["mquantity"]);
                SqlDataAdapter sda = new SqlDataAdapter("Select Quantity,MenuItemName from MenuItem where MenuItemId='" + pId + "'", con);
                DataTable dtble = new DataTable();
                sda.Fill(dtble);
                int quantity = Convert.ToInt16(dtble.Rows[0][0]);
                if(quantity == 0)
                {
                    string pName = dtble.Rows[0][1].ToString();
                    string msg = "" + pName + "is not in Stock";
                    Response.Write("<script>alert('" + msg + "');</script>"); //Display alert message that following menu is not in stock now
                    isTrue = false;
                }
                else
                {
                    isTrue = true;
                }
            }

            //Checks if cart contains any menu in it or not
            if(GridView1.Rows.Count.ToString() == "0")
            {
                //Display alert message if empty
                Response.Write("<script>alert('Your Cart is Empty. You cannot place an Order');</script>");
            }
            else
            {
                if(isTrue == true)
                {
                    Response.Redirect("PlaceOrder.aspx");
                }
            }
        }

        //Deleting All Menu at once
        public void clearCart()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete from CartDetails where Email='" + Session["username"] + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("AddtoCart.aspx");
        }
    }
}