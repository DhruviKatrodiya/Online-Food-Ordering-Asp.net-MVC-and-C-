using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DSOFOS;

namespace DSOFOS.Controllers
{
    public class CategoryController : Controller
    {
        private DSOFOSDBEntities db = new DSOFOSDBEntities();

        // GET: Category
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName,Image,IsActive,CreatedAt")] Category category, HttpPostedFileBase file)
        {
            if (ModelState.IsValid || file != null && file.ContentLength > 0)
            {
                //db.Categories.Add(category);
                //db.SaveChanges();
                //return RedirectToAction("Index");
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"),
                                                   Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    string filename = file.FileName;
                    ViewBag.Message = "File uploaded successfully";
                    category.Image = "Images/" + filename;
                    db.Categories.Add(category);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }

            return View(category);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,CategoryName,Image,IsActive,CreatedAt")] Category category, HttpPostedFileBase file)
        {
            if (ModelState.IsValid || file != null && file.ContentLength > 0)
            {
                //db.Entry(category).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"),
                                                 Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    string filename = file.FileName;
                    ViewBag.Message = "File uploaded successfully";
                    category.Image = "Images/" + filename;
                    db.Entry(category).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View(category);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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
