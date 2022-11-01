using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSOFOS.UserSide
{
    public partial class Default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Counting No. Of Menu Present in Online Order
            DataTable dt = new DataTable();
            dt = (DataTable)Session["buyitems"];
            if(dt != null)
            {
                Label2.Text = dt.Rows.Count.ToString();
            }
            else
            {
                Label2.Text = "0";
            }
        }

        //Redirect to Cart Page
        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AddtoCart.aspx");
        }

        //Timer Click Event for Displaying the Banner Ads
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Random ran = new Random();
            int i = ran.Next(1,6);
            Image2.ImageUrl = "~/Images/" + i.ToString() + ".jpg";
        }
    }
}