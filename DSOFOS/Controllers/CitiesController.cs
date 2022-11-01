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
    public class CitiesController : Controller
    {
        private DSOFOSDBEntities db = new DSOFOSDBEntities();

        // GET: Cities
        public ActionResult Index(string Search_Data, string Sorting_Order, string Filter_Value, int? Page_No)
        {

            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "CityName" : "";
            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }

            ViewBag.FilterValue = Search_Data;

            var citys = from city in db.Cities select city;
            if (!String.IsNullOrEmpty(Search_Data))
            {
                citys = citys.Where(city => city.CityName.ToUpper().Contains(Search_Data.ToUpper()));
            }

            switch (Sorting_Order)
            {
                case "CityName":
                    citys = citys.OrderByDescending(city => city.CityName);
                    break;
                case "CityCode":
                    citys = citys.OrderByDescending(city => city.CityCode);
                    break;
                case "StateName":
                    citys = citys.OrderByDescending(city => city.State.StateName);
                    break;
                default:
                    citys = citys.OrderBy(city => city.CityName);
                    break;
            }
            int Size_Of_Page = 5;
            int No_Of_Page = (Page_No ?? 1);


            var cities = db.Cities.Include(c => c.State);
            return View(citys.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        // GET: Cities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // GET: Cities/Create
        public ActionResult Create()
        {
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName");
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CityId,CityName,CityCode,StateId")] City city)
        {
            if (ModelState.IsValid)
            {
                db.Cities.Add(city);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName", city.StateId);
            return View(city);
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName", city.StateId);
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CityId,CityName,CityCode,StateId")] City city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(city).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName", city.StateId);
            return View(city);
        }

        // GET: Cities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            City city = db.Cities.Find(id);
            db.Cities.Remove(city);
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
