using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSOFOS.UserSide
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=DSOFOSDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into UserMaster" + "(FirstName,LastName,EmailId,Gender,Address,ContactNo,Password) values (@FirstName,@LastName,@EmailId,@Gender,@Address,@ContactNo,@Password)",con);
            cmd.Parameters.AddWithValue("@FirstName", TextBox1.Text);
            cmd.Parameters.AddWithValue("@LastName", TextBox2.Text);
            cmd.Parameters.AddWithValue("@EmailId", TextBox3.Text);
            cmd.Parameters.AddWithValue("@Gender", DropDownList1.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@Address", TextBox5.Text);
            cmd.Parameters.AddWithValue("@ContactNo", TextBox6.Text);
            cmd.Parameters.AddWithValue("@Password", TextBox7.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            ClearText();
            Label1.Text = "Registered Successfully";
            ClearText();
        }

        //Clearing all fields after user is registered
        private void ClearText()
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            TextBox5.Text = string.Empty;
            TextBox6.Text = string.Empty;
            TextBox7.Text = string.Empty;
        }
    }
}