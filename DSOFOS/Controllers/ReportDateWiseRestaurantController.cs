using DSOFOS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSOFOS.Controllers
{
    public class ReportDateWiseRestaurantController : Controller
    {
        // GET: ReportDateWiseRestaurant
        private DSOFOSDBEntities db = new DSOFOSDBEntities();
        // GET: ReportDateWise
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string startDate, string endDate)
        {
            List<tbl_order> orders = new List<tbl_order>();
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=DSOFOSDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT o_id, o_date, o_qty, o_bill,o_unitprice,MenuItemId FROM tbl_order WHERE o_date BETWEEN @From AND @To", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        cmd.Parameters.AddWithValue("@From", Convert.ToDateTime(startDate, new CultureInfo("en-GB")));
                        cmd.Parameters.AddWithValue("@To", Convert.ToDateTime(endDate, new CultureInfo("en-GB")));
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ViewBag.Data = dt;
                        Random rnd = new Random();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            orders.Add(new tbl_order() { o_bill = rnd.Next(dt.Rows.Count) });


                        }
                    }
                }
            }
            return View(orders);

        }
    }
}