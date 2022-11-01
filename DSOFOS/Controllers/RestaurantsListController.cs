using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DSOFOS.Models;
using PagedList;

namespace DSOFOS.Controllers
{
    public class RestaurantsListController : Controller
    {
        private DSOFOSDBEntities db = new DSOFOSDBEntities();

        // GET: RestaurantsList
        public ActionResult Index(string Search_Data, string Sorting_Order, string Filter_Value, int? Page_No)
        {
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "RestaurantName" : "";
            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }

            ViewBag.FilterValue = Search_Data;

            var rest = from restaurant in db.Restaurants select restaurant;
            if (!String.IsNullOrEmpty(Search_Data))
            {
                rest = rest.Where(restaurant => restaurant.RestaurantName.ToUpper().Contains(Search_Data.ToUpper()));
            }

            switch (Sorting_Order)
            {
                case "RestaurantName":
                    rest = rest.OrderByDescending(restaurant => restaurant.RestaurantName);
                    break;
                case "CategoryName":
                    rest = rest.OrderByDescending(restaurant => restaurant.Category.CategoryName);
                    break;
                default:
                    rest = rest.OrderBy(restaurant => restaurant.RestaurantName);
                    break;
            }
            int Size_Of_Page = 5;
            int No_Of_Page = (Page_No ?? 1);

            var restaurants = db.Restaurants.Include(r => r.Category);
            return View(rest.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        // GET: RestaurantsList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // GET: RestaurantsList/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: RestaurantsList/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestaurantId,RestaurantName,CategoryId,RestaurantImage,RestaurantDescription,IsActive,OpenTime,CloseTime,startTime,endTime")] Restaurant restaurant, HttpPostedFileBase file)
        {
            if (ModelState.IsValid || file != null && file.ContentLength > 0)
            {
                //db.Restaurants.Add(restaurant);
                //db.SaveChanges();
                //return RedirectToAction("Index");


                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    string filename = file.FileName;
                    ViewBag.Message = "File uploaded successfully";
                    restaurant.RestaurantImage = "Images/" + filename;
                    db.Restaurants.Add(restaurant);
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

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", restaurant.CategoryId);
            return View(restaurant);
        }

        // GET: RestaurantsList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", restaurant.CategoryId);
            return View(restaurant);
        }

        // POST: RestaurantsList/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestaurantId,RestaurantName,CategoryId,RestaurantImage,RestaurantDescription,IsActive,OpenTime,CloseTime,startTime,endTime")] Restaurant restaurant, HttpPostedFileBase file)
        {
            if (ModelState.IsValid || file != null && file.ContentLength > 0)
            {
                //db.Entry(restaurant).State = EntityState.Modified;
                //db.SaveChanges();
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    string filename = file.FileName;
                    ViewBag.Message = "File uploaded successfully";
                    restaurant.RestaurantImage = "Images/" + filename;
                    db.Entry(restaurant).State = EntityState.Modified;
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


            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", restaurant.CategoryId);
            return View(restaurant);
        }

        // GET: RestaurantsList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: RestaurantsList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
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