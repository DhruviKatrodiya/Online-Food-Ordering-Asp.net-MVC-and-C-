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
    public class FeedbacksController : Controller
    {
        private DSOFOSDBEntities db = new DSOFOSDBEntities();

        // GET: Feedbacks
        public ActionResult Index(string Search_Data, string Sorting_Order, string Filter_Value, int? Page_No)
        {

            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Feedback" : "";
            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }

            ViewBag.FilterValue = Search_Data;

            var feedbackss = from feedback in db.Feedbacks select feedback;
            if (!String.IsNullOrEmpty(Search_Data))
            {
                feedbackss = feedbackss.Where(feedback => feedback.Feedback1.ToUpper().Contains(Search_Data.ToUpper()));
            }

            switch (Sorting_Order)
            {
                case "Feedback":
                    feedbackss = feedbackss.OrderByDescending(feedback => feedback.Feedback1);
                    break;

                default:
                    feedbackss = feedbackss.OrderBy(feedback => feedback.Feedback1);
                    break;
            }

            int Size_Of_Page = 5;
            int No_Of_Page = (Page_No ?? 1);

            var feedbacks = db.Feedbacks.Include(f => f.UserMaster);
            return View(feedbackss.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        // GET: Feedbacks/Details/5
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

        // GET: Feedbacks/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserMasters, "UserId", "UserName");
            return View();
        }

        // POST: Feedbacks/Create
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
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserMasters, "UserId", "UserName", feedback.UserId);
            return View(feedback);
        }

        // GET: Feedbacks/Edit/5
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

        // POST: Feedbacks/Edit/5
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

        // GET: Feedbacks/Delete/5
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

        // POST: Feedbacks/Delete/5
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
