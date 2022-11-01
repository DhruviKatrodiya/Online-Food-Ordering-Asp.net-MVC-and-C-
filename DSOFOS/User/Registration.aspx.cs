using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSOFOS.User
{
    public partial class Registration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=DSOFOSDB;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Request.QueryString["id"] != null)/* && Session["UserId"] != null)*/
                {
                    getUserDetail();
                }
                else if(Session["UserId"] != null)
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string actionName = string.Empty,imagePath = string.Empty,fileExtension = string.Empty;
            bool isValidToExecute = false;
            int userId = Convert.ToInt32(Request.QueryString["UserId"]);
            string strpass = encryptpass(txtPassword.Text);
            cmd = new SqlCommand("User_Crud", con);
            cmd.Parameters.AddWithValue("@Action", userId == 0 ? "INSERT" : "UPDATE");
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@UserName", txtUsername.Text.Trim());
            cmd.Parameters.AddWithValue("@FirstName", txtFName.Text.Trim());
            cmd.Parameters.AddWithValue("@LastName", txtLName.Text.Trim());
            cmd.Parameters.AddWithValue("@EmailId", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@RoleId", ddlRoles.SelectedValue);
            cmd.Parameters.AddWithValue("@ContactNo", txtMobile.Text.Trim());
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
            cmd.Parameters.AddWithValue("@Password", strpass);
            cmd.Parameters.AddWithValue("@CityId", ddlCity.SelectedValue);


            if (fuUserImage.HasFile)
            {
                if (Utils.IsValidExtension(fuUserImage.FileName))
                {
                    Guid obj = Guid.NewGuid();
                    fileExtension = Path.GetExtension(fuUserImage.FileName);
                    imagePath = "Images/User/" + obj.ToString() + fileExtension;
                    fuUserImage.PostedFile.SaveAs(Server.MapPath("~/Images/User/") + obj.ToString() + fileExtension);
                    cmd.Parameters.AddWithValue("@Image", imagePath);
                    isValidToExecute = true;

                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Please select .jpg,.png,.jpeg Image";
                    lblMsg.CssClass = "alert alert-danger";
                    isValidToExecute = false;

                }
            }
            else
            {
                isValidToExecute = true;

            }

            if (isValidToExecute)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    actionName = userId == 0 ? 
                        "registration is successful! <b><a href='Login.aspx'>Click Here</a></b> to do login" :
                        "details updated successful <b><a href='Profile.aspx'>Can Check Here</a></b>";
                    lblMsg.Visible = true;
                    lblMsg.Text = "<b> " + txtUsername.Text.Trim() + " </b>" + actionName;
                    lblMsg.CssClass = "alert alert-success";
                    if(userId != 0)
                    {
                        Response.AddHeader("REFRESH", "1;URL=Profile.aspx");
                    }
                    clear();

                }
                catch (SqlException ex)
                {
                    if(ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "<b> " + txtUsername.Text.Trim() + " </b> username already exits,try new one...!";
                        lblMsg.CssClass = "alert alert-danger";
                    }
                    
                }
                catch (Exception ex)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Error-" + ex.Message;
                    lblMsg.CssClass = "alert alert-danger";
                }
                finally
                {
                    con.Close();
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
        void getUserDetail()
        {
            cmd = new SqlCommand("User_Crud", con);
            cmd.Parameters.AddWithValue("@Action", "SELECT4PROFILE");
            cmd.Parameters.AddWithValue("@UserId", Request.QueryString["id"]);
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count == 1)
            {
                txtUsername.Text = dt.Rows[0]["UserName"].ToString();
                txtFName.Text = dt.Rows[0]["FirstName"].ToString();
                txtLName.Text = dt.Rows[0]["LastName"].ToString();
                txtEmail.Text = dt.Rows[0]["EmailId"].ToString();
                txtMobile.Text = dt.Rows[0]["ContactNo"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                imgUser.ImageUrl = String.IsNullOrEmpty(dt.Rows[0]["Image"].ToString()) ? "../Images/No_image.png" : "../" + dt.Rows[0]["Image"].ToString();
                imgUser.Height = 200;
                imgUser.Width = 200;
                txtPassword.TextMode = TextBoxMode.SingleLine;
                txtPassword.ReadOnly = true;
                txtPassword.Text = dt.Rows[0]["Password"].ToString();
            }
            lblHeaderMsg.Text = "<h2>Edit Profile</h2>";
            btnRegister.Text = "Update";
            lblAlreadyUser.Text = "";
        }

        private void clear()
        {
            txtUsername.Text = String.Empty;
            txtFName.Text = String.Empty;
            txtLName.Text = String.Empty;
            txtMobile.Text = String.Empty;
            txtEmail.Text = String.Empty;
            ddlRoles.ClearSelection();
            txtAddress.Text = String.Empty;
            txtPassword.Text = String.Empty;


        }
    }
}