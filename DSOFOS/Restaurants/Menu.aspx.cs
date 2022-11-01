using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSOFOS.Restaurants
{
    public partial class Menu : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=DSOFOSDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["breadCrum"] = "Menu";
                if (Session["restaurant"] == null)
                {
                    Response.Redirect("../User/Login.aspx");
                }
                else
                {
                    getMenuItems();
                }
                
            }
            lblMsg.Visible = false;


        }

        protected void btnAddOrUpdate_Click(object sender, EventArgs e)
        {
            string actionName = string.Empty, imagePath = string.Empty, fileExtension = string.Empty;
            bool isValidToExecute = false;
            int menuitemId = Convert.ToInt32(hdnId.Value);
            cmd = new SqlCommand("MenuItem_Crudd", con);
            cmd.Parameters.AddWithValue("@Action", menuitemId == 0 ? "INSERT" : "UPDATE");
            cmd.Parameters.AddWithValue("@MenuItemId", menuitemId);
            cmd.Parameters.AddWithValue("@MenuItemName", txtName.Text.Trim());
            cmd.Parameters.AddWithValue("@MenuItemDescription", txtDescription.Text.Trim());
            cmd.Parameters.AddWithValue("@Amount", txtPrice.Text.Trim());
            cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text.Trim());
            cmd.Parameters.AddWithValue("@CategoryId", ddlCategories.SelectedValue);
            cmd.Parameters.AddWithValue("@IsActive", cbIsActive.Checked);
               cmd.Parameters.AddWithValue("@VegNonProfile", cbVegNonProfile.Checked);
            if (fuMenuImage.HasFile)
            {
                if (Utils.IsValidExtension(fuMenuImage.FileName))
                {
                    Guid obj = Guid.NewGuid();
                    fileExtension = Path.GetExtension(fuMenuImage.FileName);
                    imagePath = "Images/Menu/" + obj.ToString() + fileExtension;
                    fuMenuImage.PostedFile.SaveAs(Server.MapPath("~/Images/Menu/") + obj.ToString() + fileExtension);
                    cmd.Parameters.AddWithValue("@MenuItemImage", imagePath);
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
                    actionName = menuitemId == 0 ? "inserted" : "updated";
                    lblMsg.Visible = true;
                    lblMsg.Text = "Menu " + actionName + " Successfully!!";
                    lblMsg.CssClass = "alert alert-success";
                    getMenuItems();
                    clear();

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
        private void getMenuItems()
        {
            cmd = new SqlCommand("MenuItem_Crudd", con);
            cmd.Parameters.AddWithValue("@Action", "SELECT");
            //cmd.Parameters.AddWithValue("@CategoryName", txtName.Text.Trim());
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            rMenu.DataSource = dt;
            rMenu.DataBind();
        }

        private void clear()
        {
            txtName.Text = String.Empty;
            txtDescription.Text = String.Empty;
            txtPrice.Text = String.Empty;
            txtQuantity.Text = String.Empty;
            ddlCategories.ClearSelection();
            cbIsActive.Checked = false;
            cbVegNonProfile.Checked = false;
            hdnId.Value = "0";
            btnAddOrUpdate.Text = "Add";
            imgMenu.ImageUrl = String.Empty;

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

     

        protected void rMenu_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            lblMsg.Visible = false;
            if (e.CommandName == "edit")
            {
                cmd = new SqlCommand("MenuItem_Crudd", con);
                cmd.Parameters.AddWithValue("@Action", "GETBYID");
                cmd.Parameters.AddWithValue("@MenuItemId", e.CommandArgument);
               // cmd.Parameters.AddWithValue("@CategoryName", txtName.Text.Trim());
                cmd.CommandType = CommandType.StoredProcedure;
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                txtName.Text = dt.Rows[0]["MenuItemName"].ToString();
                txtDescription.Text = dt.Rows[0]["MenuItemDescription"].ToString();
                txtPrice.Text = dt.Rows[0]["Amount"].ToString();
                txtQuantity.Text = dt.Rows[0]["Quantity"].ToString();
                ddlCategories.SelectedValue = dt.Rows[0]["CategoryId"].ToString();
                cbIsActive.Checked = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                cbVegNonProfile.Checked = Convert.ToBoolean(dt.Rows[0]["VegNonProfile"]);
                imgMenu.ImageUrl = String.IsNullOrEmpty(dt.Rows[0]["MenuItemImage"].ToString()) ? "../Images/No_image.png" : "../" + dt.Rows[0]["MenuItemImage"].ToString();
                imgMenu.Height = 200;
                imgMenu.Width = 200;
                hdnId.Value = dt.Rows[0]["MenuItemId"].ToString();
                btnAddOrUpdate.Text = "Update";
                LinkButton btn = e.Item.FindControl("lnkEdit") as LinkButton;
                btn.CssClass = "badge badge-warning";
            }
            else if (e.CommandName == "delete")
            {
                cmd = new SqlCommand("MenuItem_Crudd", con);
                cmd.Parameters.AddWithValue("@Action", "DELETE");
                cmd.Parameters.AddWithValue("@MenuItemId", e.CommandArgument);
                //cmd.Parameters.AddWithValue("@CategoryName", txtName.Text.Trim());
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMsg.Visible = true;
                    lblMsg.Text = "Category Deleted successfully!!";
                    lblMsg.CssClass = "alert alert-success";
                    getMenuItems();
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

        protected void rMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lbllblIsActive = e.Item.FindControl("lblIsActive") as Label;
                Label lbllblVegNonProfile = e.Item.FindControl("lblVegNonProfile") as Label;
                Label lblQuantity = e.Item.FindControl("lblQuantity") as Label;
                if (lbllblIsActive.Text == "True")
                {
                    lbllblIsActive.Text = "Active";
                    lbllblIsActive.CssClass = "badge badge-success";
                }
                else
                {
                    lbllblIsActive.Text = "In-Active";
                    lbllblIsActive.CssClass = "badge badge-danger";
                }


                if (Convert.ToInt32(lblQuantity.Text) <= 5)
                {
                    lblQuantity.CssClass = "badge badge-danger";
                    lblQuantity.ToolTip = "Item about to be 'Out of Stock'!!";
                }

                if (lbllblVegNonProfile.Text == "True")
                {
                    lbllblVegNonProfile.Text = "VEG";
                    lbllblVegNonProfile.CssClass = "badge badge-success";
                }
                else
                {
                    lbllblVegNonProfile.Text = "NON-VEG";
                    lbllblVegNonProfile.CssClass = "badge badge-danger";
                }

            }
        }
    }
}