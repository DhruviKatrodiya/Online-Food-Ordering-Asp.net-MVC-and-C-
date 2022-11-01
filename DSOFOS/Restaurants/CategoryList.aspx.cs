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
    public partial class CategoryList : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=DSOFOSDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(con.State == ConnectionState.Open)
            //{
            //    con.Close();
            //}
            //con.Open();

            if (!IsPostBack)
            {
                Session["breadCrum"] = "Category";
                getcategories();
            }
            lblMsg.Visible = false;

        }

        //protected void btnAddOrUpdate_Click(object sender, EventArgs e)
        //{
        //    string actionName = string.Empty, imagePath = string.Empty, fileExtension = string.Empty;
        //    bool isValidToExecute = false;
        //    int categoryId = Convert.ToInt32(hdnId.Value);
        //    cmd = new SqlCommand("Category_Crud", con);
        //    cmd.Parameters.AddWithValue("@Action", categoryId == 0 ? "INSERT" : "UPDATE");
        //    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
        //    cmd.Parameters.AddWithValue("@CategoryName", txtName.Text.Trim());
        //    cmd.Parameters.AddWithValue("@IsActive", cbIsActive.Checked);
        //    if (fuCategoryImage.HasFile)
        //    {
        //        if (Utils.IsValidExtension(fuCategoryImage.FileName))
        //        {
        //            Guid obj = Guid.NewGuid();
        //            fileExtension = Path.GetExtension(fuCategoryImage.FileName);
        //            imagePath = "Images/Category/" + obj.ToString() + fileExtension;
        //            fuCategoryImage.PostedFile.SaveAs(Server.MapPath("~/Images/Category/") + obj.ToString() + fileExtension);
        //            cmd.Parameters.AddWithValue("@Image", imagePath);
        //            isValidToExecute = true;

        //        }
        //        else
        //        {
        //            lblMsg.Visible = true;
        //            lblMsg.Text = "Please select .jpg,.png,.jpeg Image";
        //            lblMsg.CssClass = "alert alert-danger";
        //            isValidToExecute = false;

        //        }
        //    }
        //    else
        //    {
        //        isValidToExecute = true;

        //    }
        //    if (isValidToExecute)
        //    {
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        try
        //        {
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            actionName = categoryId == 0 ? "inserted" : "updated";
        //            lblMsg.Visible = true;
        //            lblMsg.Text = "Category" + actionName + "Successfully!!";
        //            lblMsg.CssClass = "alert alert-success";
        //            getcategories();
        //            clear();

        //        }
        //        catch (Exception ex)
        //        {
        //            lblMsg.Visible = true;
        //            lblMsg.Text = "Error-" + ex.Message;
        //            lblMsg.CssClass = "alert alert-danger";
        //        }
        //        finally
        //        {
        //            con.Close();
        //        }
        //    }

        //}

        private void getcategories()
        {
            cmd = new SqlCommand("Category_Crud", con);
            cmd.Parameters.AddWithValue("@Action", "SELECT");
            cmd.Parameters.AddWithValue("@CategoryName", "SELECT");
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            rCategory.DataSource = dt;
            rCategory.DataBind();
        }

        //private void clear()
        //{
        //    txtName.Text = String.Empty;
        //    cbIsActive.Checked = false;
        //    hdnId.Value = "0";
        //    btnAddOrUpdate.Text = "Add";
        //    imgCategory.ImageUrl = String.Empty;

        //}

        //protected void btnClear_Click(object sender, EventArgs e)
        //{
        //    clear();
        //}

        //protected void rCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    lblMsg.Visible = false;
        //    if (e.CommandName == "edit")
        //    {
        //        cmd = new SqlCommand("Category_Crud", con);
        //        cmd.Parameters.AddWithValue("@Action", "GETBYID");
        //        cmd.Parameters.AddWithValue("@CategoryId", e.CommandArgument);
        //        cmd.Parameters.AddWithValue("@CategoryName", txtName.Text.Trim());
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        sda = new SqlDataAdapter(cmd);
        //        dt = new DataTable();
        //        sda.Fill(dt);
        //        txtName.Text = dt.Rows[0]["CategoryName"].ToString();
        //        cbIsActive.Checked = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
        //        imgCategory.ImageUrl = String.IsNullOrEmpty(dt.Rows[0]["Image"].ToString()) ? "../Images/No_image.png" : "../" + dt.Rows[0]["Image"].ToString();
        //        imgCategory.Height = 200;
        //        imgCategory.Width = 200;
        //        hdnId.Value = dt.Rows[0]["CategoryId"].ToString();
        //        btnAddOrUpdate.Text = "Update";
        //        LinkButton btn = e.Item.FindControl("lnkEdit") as LinkButton;
        //        btn.CssClass = "badge badge-warning";
        //    }
        //    else if (e.CommandName == "delete")
        //    {
        //        cmd = new SqlCommand("Category_Crud", con);
        //        cmd.Parameters.AddWithValue("@Action", "DELETE");
        //        cmd.Parameters.AddWithValue("@CategoryId", e.CommandArgument);
        //        cmd.Parameters.AddWithValue("@CategoryName", txtName.Text.Trim());
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        try
        //        {
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            lblMsg.Visible = true;
        //            lblMsg.Text = "Category Deleted successfully!!";
        //            lblMsg.CssClass = "alert alert-success";
        //            getcategories();
        //        }
        //        catch (Exception ex)
        //        {
        //            lblMsg.Visible = true;
        //            lblMsg.Text = "Error-" + ex.Message;
        //            lblMsg.CssClass = "alert alert-danger";
        //        }
        //        finally
        //        {
        //            con.Close();
        //        }
        //    }
        //}

        protected void rCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lbl = e.Item.FindControl("lblIsActive") as Label;
                if (lbl.Text == "True")
                {
                    lbl.Text = "Active";
                    lbl.CssClass = "badge badge-success";
                }
                else
                {
                    lbl.Text = "In-Active";
                    lbl.CssClass = "badge badge-danger";
                }
            }
        }
    }
}