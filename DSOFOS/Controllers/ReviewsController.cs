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
    public class ReviewsController : Controller
    {
        private DSOFOSDBEntities db = new DSOFOSDBEntities();

        // GET: Reviews
        public ActionResult Index(String Search)
        {
            if(Search != null)
            {
                var result = db.Reviews.Where(r => r.Rate.ToString().Contains(Search));
                return View(result);
            }
            var reviews = db.Reviews.Include(r => r.MenuItem).Include(r => r.UserMaster);
            return View(reviews.ToList());
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            ViewBag.MenuItemId = new SelectList(db.MenuItems, "MenuItemId", "MenuItemName");
            ViewBag.UserId = new SelectList(db.UserMasters, "UserId", "UserName");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewId,Rate,Remarks,UserId,MenuItemId,IsActive,CreatedAt,UserName")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MenuItemId = new SelectList(db.MenuItems, "MenuItemId", "MenuItemName", review.MenuItemId);
            ViewBag.UserId = new SelectList(db.UserMasters, "UserId", "UserName", review.UserId);
            return View(review);
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuItemId = new SelectList(db.MenuItems, "MenuItemId", "MenuItemName", review.MenuItemId);
            ViewBag.UserId = new SelectList(db.UserMasters, "UserId", "UserName", review.UserId);
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewId,Rate,Remarks,UserId,MenuItemId,IsActive,CreatedAt,UserName")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MenuItemId = new SelectList(db.MenuItems, "MenuItemId", "MenuItemName", review.MenuItemId);
            ViewBag.UserId = new SelectList(db.UserMasters, "UserId", "UserName", review.UserId);
            return View(review);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
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
