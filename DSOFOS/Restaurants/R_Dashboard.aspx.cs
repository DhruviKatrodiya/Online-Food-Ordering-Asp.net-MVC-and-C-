using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSOFOS.Restaurants
{
    public partial class R_Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["breadCrum"] = "";
                if (Session["restaurant"] == null)
                {
                    Response.Redirect("../User/Login.aspx");
                }
            }
        }
    }
}