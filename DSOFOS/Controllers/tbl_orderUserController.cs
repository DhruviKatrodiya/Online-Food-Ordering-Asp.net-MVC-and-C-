using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DSOFOS.Models;
using PagedList;

namespace DSOFOS.Controllers
{
    public class tbl_orderUserController : Controller
    {
        private DSOFOSDBEntities db = new DSOFOSDBEntities();

        public bool IsPostBack { get; private set; }

        // GET: tbl_orderUser
        public ActionResult Index(string Search_Data, string Sorting_Order, string Filter_Value, int? Page_No)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] == null)
                {
                    Response.Redirect("../User/Login.aspx");
                }

            }
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Status" : "";
            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }

            ViewBag.FilterValue = Search_Data;

            var orders = from order in db.tbl_order select order;
            if (!String.IsNullOrEmpty(Search_Data))
            {
                orders = orders.Where(order => order.Status.ToUpper().Contains(Search_Data.ToUpper()));
            }

            switch (Sorting_Order)
            {
                case "Status":
                    orders = orders.OrderByDescending(order => order.Status);
                    break;
                case "o_date":
                    orders = orders.OrderByDescending(order => order.o_date);
                    break;
                case "o_unitprice":
                    orders = orders.OrderByDescending(order => order.o_unitprice);
                    break;
                case "MenuItemName":
                    orders = orders.OrderByDescending(order => order.MenuItem.MenuItemName);
                    break;
                case "in_id":
                    orders = orders.OrderByDescending(order => order.tbl_invoice.in_id);
                    break;
                case "UserName":
                    orders = orders.OrderByDescending(order => order.UserMaster.UserName);
                    break;
                default:
                    orders = orders.OrderBy(order => order.Status);
                    break;
            }
            int Size_Of_Page = 10;
            int No_Of_Page = (Page_No ?? 1);

            var tbl_order = db.tbl_order.Include(t => t.MenuItem).Include(t => t.tbl_invoice).Include(t => t.UserMaster);
            return View(orders.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        // GET: tbl_orderUser/Details/5
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

        // GET: tbl_orderUser/Create
        public ActionResult Create()
        {
            ViewBag.MenuItemId = new SelectList(db.MenuItems, "MenuItemId", "MenuItemName");
            ViewBag.in_id = new SelectList(db.tbl_invoice, "in_id", "in_id");
            ViewBag.UserId = new SelectList(db.UserMasters, "UserId", "UserName");
            return View();
        }

        // POST: tbl_orderUser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "o_id,MenuItemId,in_id,o_date,o_qty,o_bill,o_unitprice,Status,UserId")] tbl_order tbl_order)
        {
            if (ModelState.IsValid)
            {
                db.tbl_order.Add(tbl_order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MenuItemId = new SelectList(db.MenuItems, "MenuItemId", "MenuItemName", tbl_order.MenuItemId);
            ViewBag.in_id = new SelectList(db.tbl_invoice, "in_id", "in_id", tbl_order.in_id);
            ViewBag.UserId = new SelectList(db.UserMasters, "UserId", "UserName", tbl_order.UserId);
            return View(tbl_order);
        }

        // GET: tbl_orderUser/Edit/5
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

        // POST: tbl_orderUser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "o_id,MenuItemId,in_id,o_date,o_qty,o_bill,o_unitprice,Status,UserId")] tbl_order tbl_order)
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

        // GET: tbl_orderUser/Delete/5
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

        // POST: tbl_orderUser/Delete/5
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
