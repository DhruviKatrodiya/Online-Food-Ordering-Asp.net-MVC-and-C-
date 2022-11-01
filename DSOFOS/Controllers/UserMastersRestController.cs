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
    public class UserMastersRestController : Controller
    {
        private DSOFOSDBEntities db = new DSOFOSDBEntities();

        // GET: UserMastersRest
        public ActionResult Index(string Search_Data, string Sorting_Order, string Filter_Value, int? Page_No)
        {
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "UserName" : "";
            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }

            ViewBag.FilterValue = Search_Data;

            var users = from user in db.UserMasters select user;
            if (!String.IsNullOrEmpty(Search_Data))
            {
                users = users.Where(user => user.UserName.ToUpper().Contains(Search_Data.ToUpper()));
            }

            switch (Sorting_Order)
            {
                case "UserName":
                    users = users.OrderByDescending(user => user.UserName);
                    break;
                default:
                    users = users.OrderBy(user => user.UserName);
                    break;
            }
            int Size_Of_Page = 5;
            int No_Of_Page = (Page_No ?? 1);


            var userMasters = db.UserMasters.Include(u => u.City).Include(u => u.Role).Include(u => u.State);
            return View(users.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        // GET: UserMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMaster userMaster = db.UserMasters.Find(id);
            if (userMaster == null)
            {
                return HttpNotFound();
            }
            return View(userMaster);
        }

        // GET: UserMasters/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName");
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName");
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName");
            return View();
        }

        // POST: UserMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserName,Password,FirstName,LastName,EmailId,ContactNo,Image,RoleId,Address,CityId,StateId,CreatedAt,UpdatedAt,Gender,Dob")] UserMaster userMaster)
        {
            if (ModelState.IsValid)
            {
                db.UserMasters.Add(userMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", userMaster.CityId);
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", userMaster.RoleId);
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName", userMaster.StateId);
            return View(userMaster);
        }

        // GET: UserMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMaster userMaster = db.UserMasters.Find(id);
            if (userMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", userMaster.CityId);
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", userMaster.RoleId);
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName", userMaster.StateId);
            return View(userMaster);
        }

        // POST: UserMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserName,Password,FirstName,LastName,EmailId,ContactNo,Image,RoleId,Address,CityId,StateId,CreatedAt,UpdatedAt,Gender,Dob")] UserMaster userMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", userMaster.CityId);
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", userMaster.RoleId);
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName", userMaster.StateId);
            return View(userMaster);
        }

        // GET: UserMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMaster userMaster = db.UserMasters.Find(id);
            if (userMaster == null)
            {
                return HttpNotFound();
            }
            return View(userMaster);
        }

        // POST: UserMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserMaster userMaster = db.UserMasters.Find(id);
            db.UserMasters.Remove(userMaster);
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
