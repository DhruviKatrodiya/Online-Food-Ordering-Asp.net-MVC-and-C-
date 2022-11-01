using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSOFOS.User
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=DSOFOSDB;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["userId"] != null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string strpass = encryptpass(txtPassword.Text);
            cmd = new SqlCommand("Select * from Roles where RoleId=1+++++++++++++", con);

            if(txtUsername.Text.Trim() == "Admin" && txtPassword.Text.Trim() == "Admin")
            {
                Session["admin"] = txtUsername.Text.Trim();
                Response.Redirect("../Admin/Dashboard.aspx");
            }
            else if(txtUsername.Text.Trim() == "Restaurant" && txtPassword.Text.Trim() == "Restaurant")
            {
                Session["restaurant"] = txtUsername.Text.Trim();
                Response.Redirect("../Restaurants/R_Dashboard.aspx");
            }
            else
            {
                cmd = new SqlCommand("User_Crud", con);
                cmd.Parameters.AddWithValue("@Action", "SELECT4LOGIN");
                cmd.Parameters.AddWithValue("@UserName",txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", strpass);
                cmd.CommandType = CommandType.StoredProcedure;
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                if(dt.Rows.Count == 1)
                {
                    Session["username"] = txtUsername.Text.Trim();
                    Session["userId"] = dt.Rows[0]["UserId"];
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Invalid Credentials..!";
                    lblMsg.CssClass = "alert alert-danger";
                }
            }
        }

        public string encryptpass(string Password)
        {
            string msg = "";
            byte[] encode = new byte[Password.Length];
            encode = Encoding.UTF8.GetBytes(Password);
            msg = Convert.ToBase64String(encode);
            return msg;
        }
    }
}