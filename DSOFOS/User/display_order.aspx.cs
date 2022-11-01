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
    public partial class display_order : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=DSOFOSDB;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            con.Open();
            SqlCommand cmd= con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from UserMaster where UserName = '" + Session["userId"].ToString() + "' order by UserId desc ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da=new SqlDataAdapter(cmd);
            da.Fill(dt);
            r1.DataSource = dt;
            r1.DataBind();

            con.Close();

        }
    }
}
