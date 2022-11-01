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
    public class tbl_orderRestController : Controller
    {
        private DSOFOSDBEntities db = new DSOFOSDBEntities();

        // GET: tbl_orderRest
        public ActionResult Index()
        {
            var tbl_order = db.tbl_order.Include(t => t.MenuItem).Include(t => t.tbl_invoice).Include(t => t.UserMaster);
            return View(tbl_order.ToList());
        }

        // GET: tbl_orderRest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_order tbl_order = db.tbl_order.Find(id);
            if (tbl_order == null)
            {
                return HttpNotFound();
            }
            return View(tbl_order);
        }

        // GET: tbl_orderRest/Create
        public ActionResult Create()
        {
            ViewBag.MenuItemId = new SelectList(db.MenuItems, "MenuItemId", "MenuItemName");
            ViewBag.in_id = new SelectList(db.tbl_invoice, "in_id", "in_id");
            ViewBag.UserId = new SelectList(db.UserMasters, "UserId", "UserName");
            return View();
        }

        // POST: tbl_orderRest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "o_id,MenuItemId,in_id,o_date,o_qty,o_bill,o_unitprice,Status,UserId,Name,CardNo,ExpiryDate,CvvNo,Address,PaymentMode")] tbl_order tbl_order)
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
                db.tbl_order.Add(tbl_order);
                db.SaveChanges();
                return RedirectToAction("invoice_Genration", "Categories");
            }

            ViewBag.MenuItemId = new SelectList(db.MenuItems, "MenuItemId", "MenuItemName", tbl_order.MenuItemId);
            ViewBag.in_id = new SelectList(db.tbl_invoice, "in_id", "in_id", tbl_order.in_id);
            ViewBag.UserId = new SelectList(db.UserMasters, "UserId", "UserName", tbl_order.UserId);
            return View(tbl_order);
        }

        // GET: tbl_orderRest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_order tbl_order = db.tbl_order.Find(id);
            if (tbl_order == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuItemId = new SelectList(db.MenuItems, "MenuItemId", "MenuItemName", tbl_order.MenuItemId);
            ViewBag.in_id = new SelectList(db.tbl_invoice, "in_id", "in_id", tbl_order.in_id);
            ViewBag.UserId = new SelectList(db.UserMasters, "UserId", "UserName", tbl_order.UserId);
            return View(tbl_order);
        }

        // POST: tbl_orderRest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "o_id,MenuItemId,in_id,o_date,o_qty,o_bill,o_unitprice,Status,UserId,Name,CardNo,ExpiryDate,CvvNo,Address,PaymentMode")] tbl_order tbl_order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MenuItemId = new SelectList(db.MenuItems, "MenuItemId", "MenuItemName", tbl_order.MenuItemId);
            ViewBag.in_id = new SelectList(db.tbl_invoice, "in_id", "in_id", tbl_order.in_id);
            ViewBag.UserId = new SelectList(db.UserMasters, "UserId", "UserName", tbl_order.UserId);
            return View(tbl_order);
        }

        // GET: tbl_orderRest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_order tbl_order = db.tbl_order.Find(id);
            if (tbl_order == null)
            {
                return HttpNotFound();
            }
            return View(tbl_order);
        }

        // POST: tbl_orderRest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_order tbl_order = db.tbl_order.Find(id);
            db.tbl_order.Remove(tbl_order);
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
