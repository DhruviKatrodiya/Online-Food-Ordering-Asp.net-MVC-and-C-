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
    public class FeedbacksUserController : Controller
    {
        private DSOFOSDBEntities db = new DSOFOSDBEntities();

        // GET: FeedbacksUser
        public ActionResult Index()
        {
           
            var feedbacks = db.Feedbacks.Include(f => f.UserMaster);
            return View(feedbacks.ToList());
        }

        // GET: FeedbacksUser/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // GET: FeedbacksUser/Create
        public ActionResult Create()
        {
            
            ViewBag.UserId = new SelectList(db.UserMasters, "UserId", "UserName");
            return View();
        }

        // POST: FeedbacksUser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FeedbackId,Feedback1,UserId,IsActive,CreatedAt,UserName")] Feedback feedback)
        {
            
            if (ModelState.IsValid)
            {
                db.Feedbacks.Add(feedback);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.UserId = new SelectList(db.UserMasters, "UserId", "UserName", feedback.UserId);
            return View(feedback);
        }

        // GET: FeedbacksUser/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserMasters, "UserId", "UserName", feedback.UserId);
            return View(feedback);
        }

        // POST: FeedbacksUser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FeedbackId,Feedback1,UserId,IsActive,CreatedAt,UserName")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserMasters, "UserId", "UserName", feedback.UserId);
            return View(feedback);
        }

        // GET: FeedbacksUser/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: FeedbacksUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feedback feedback = db.Feedbacks.Find(id);
            db.Feedbacks.Remove(feedback);
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
