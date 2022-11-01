using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSOFOS.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.msg = "";
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserMaster usr)
        {
            DSOFOSDBEntities obj = new DSOFOSDBEntities();
            var a = obj.UserMasters.Where(l => l.UserName.Equals(usr.UserName) && l.Password.Equals(usr.Password)).ToList();
            if(a.Count > 0)
            {
                Session["Username"] = usr.UserName.ToString();
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.msg = "Invalid Username or Password";
            }
            return View();
        }

        public ActionResult Dashboard()
        {
            if(Session["Username"] == null)
            {
                ViewBag.msg = "Login First...";
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}