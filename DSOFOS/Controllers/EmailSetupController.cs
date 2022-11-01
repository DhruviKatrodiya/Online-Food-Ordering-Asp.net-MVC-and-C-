using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DSOFOS.Models;
using System.Net; 
using System.Net.Mail;


 

namespace DSOFOS.Controllers
{
    public class EmailSetupController : Controller
    {
        // GET: EmailSetup
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(DSOFOS.Models.gmail model)
        {
            MailMessage mm = new MailMessage("dhruvikatrodiya.mscict21@vnsgu.ac.in", model.To);
            mm.Subject = model.Subject;
            mm.Body = model.Body;
            mm.IsBodyHtml = false;

            SmtpClient smtp=new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("dhruvikatrodiya.mscict21@vnsgu.ac.in", "dhruvi@2021");
            smtp.UseDefaultCredentials = true;  
            smtp.Credentials = nc;
            smtp.Send(mm);
            ViewBag.Message = "Mail has been sent successfully...";

            return View();
        }
    }
}