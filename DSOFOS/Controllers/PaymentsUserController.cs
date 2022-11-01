using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DSOFOS.Models;

namespace DSOFOS.Controllers
{
    public class PaymentsUserController : Controller
    {
        private DSOFOSDBEntities db = new DSOFOSDBEntities();

        // GET: PaymentsUser
        public ActionResult Index()
        {
            return View(db.Payments.ToList());
        }

        // GET: PaymentsUser/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // GET: PaymentsUser/Create
        public ActionResult Create()
        {
            //var list = new List<string>() { "CreditCard", "DebitCard" };
            //ViewBag.list = list;
            return View();
        }

        // POST: PaymentsUser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentId,Name,CardNo,ExpiryDate,CvvNo,Address,PaymentMode,Amount")] Payment payment)
        {
            Session["UserId"] = 43;
            if (TempData["FoodCartClass"] != null)
            {
                float x = 0;
                List<FoodCartClass> li2 = TempData["FoodCartClass"] as List<FoodCartClass>;
                foreach (var item in li2)
                {
                    x += item.Bill;

                }

                TempData["total"] = x;
            }
            TempData.Keep();

            if (ModelState.IsValid)
            {
                db.Payments.Add(payment);
                db.SaveChanges();
                return RedirectToAction("invoice_Genration", "Categories");
            }

            return View(payment);
        }

        // GET: PaymentsUser/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: PaymentsUser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentId,Name,CardNo,ExpiryDate,CvvNo,Address,PaymentMode,Amount")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(payment);
        }

        // GET: PaymentsUser/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: PaymentsUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment payment = db.Payments.Find(id);
            db.Payments.Remove(payment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
