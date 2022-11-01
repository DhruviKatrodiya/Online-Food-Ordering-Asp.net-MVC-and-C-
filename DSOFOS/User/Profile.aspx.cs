using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSOFOS.User
{
    public partial class Profile : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=DSOFOSDB;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    getUserDetails();
                   // getPurchaseDetails();
                }
            }
        }

        void getUserDetails()
        {
            cmd = new SqlCommand("User_Crud", con);
            cmd.Parameters.AddWithValue("@Action", "SELECT4PROFILE");
            cmd.Parameters.AddWithValue("@UserId", Session["UserId"]);
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            rUserProfile.DataSource = dt;
            rUserProfile.DataBind();
            if (dt.Rows.Count == 1)
            {
                Session["FirstName"] = dt.Rows[0]["FirstName"].ToString();
                Session["LastName"] = dt.Rows[0]["LastName"].ToString();
                Session["EmailId"] = dt.Rows[0]["EmailId"].ToString();
                Session["ContactNo"] = dt.Rows[0]["ContactNo"].ToString();
                Session["Address"] = dt.Rows[0]["Address"].ToString();
                Session["Image"] = dt.Rows[0]["Image"].ToString();
                Session["CreatedAt"] = dt.Rows[0]["CreatedAt"].ToString();
            }
        }

        //void getPurchaseDetails()
        //{

           // Response.Redirect("~/tbl_orderUser/Index");
            //cmd = new SqlCommand("Order_Crud", con);
            //cmd.Parameters.AddWithValue("@Action", "SELECT");
            //cmd.Parameters.AddWithValue("@o_id", Session["o_id"]);
            //cmd.CommandType = CommandType.StoredProcedure;
            //sda = new SqlDataAdapter(cmd);
            //dt = new DataTable();
            //sda.Fill(dt);
            //rPurchaseProfile.DataSource = dt;
            //rPurchaseProfile.DataBind();
            //if (dt.Rows.Count == 1)
            //{
            //    Session["MenuItemId"] = dt.Rows[0]["MenuItemId"].ToString();
            //    Session["in_id"] = dt.Rows[0]["in_id"].ToString();
            //    Session["o_date"] = dt.Rows[0]["o_date"].ToString();
            //    Session["o_qty"] = dt.Rows[0]["o_qty"].ToString();
            //    Session["o_bill"] = dt.Rows[0]["o_bill"].ToString();
            //    Session["o_unitprice"] = dt.Rows[0]["o_unitprice"].ToString();
            //    Session["Status"] = dt.Rows[0]["Status"].ToString();
            //    Session["UserId"] = dt.Rows[0]["UserId"].ToString();
            //}
        //}


    }
}