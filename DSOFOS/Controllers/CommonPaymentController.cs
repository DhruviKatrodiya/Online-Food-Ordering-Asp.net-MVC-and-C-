using DSOFOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSOFOS.Controllers
{
    public class CommonPaymentController : Controller
    {
        private UserMaster objuserMaster;
        private CommonPaymentLogic objLogic;

        public CommonPaymentController()
        {
            objuserMaster = new UserMaster();
            objLogic = new CommonPaymentLogic();
            
        }
        // GET: CommonPayment
        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Create(PaymentUserModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objLogic.InsertPayment(model);
                    TempData["Msg"] = "Recode add successfully...";
                    return RedirectToAction("Index");
                    //insert
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            { 
                TempData["Msg"]="Recode add failed..." +ex.Message;
                return RedirectToAction("Index");
            }
            
            return View();
        }

    } 
}