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
    public partial class view_full_order : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=DSOFOSDB;Integrated Security=True");
        int id;
        int tot = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == "")
            {
                Response.Redirect("Login.aspx");
            }

            id = Convert.ToInt32(Request.QueryString["id"].ToString());
            
            con.Open();
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from UserMaster where UserId=" + id + " ";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            r1.DataSource = dt1;
            r1.DataBind();

            con.Close();


            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from MenuItem where MenuItemId=" + id + " ";
            cmd1.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                tot = tot + Convert.ToInt32(dr["Amount"].ToString()) * Convert.ToInt32(dr["Quantity"].ToString());
            }
            r1.DataSource = dt;
            r1.DataBind();

            con.Close();

            l1.Text = "total order price =" + tot.ToString();
        }
    }
}