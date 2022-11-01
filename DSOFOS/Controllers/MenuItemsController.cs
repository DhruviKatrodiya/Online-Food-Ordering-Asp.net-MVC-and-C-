using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DSOFOS.Models;
using DSOFOS.ViewModel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace DSOFOS.Controllers
{
    public class MenuItemsController : Controller
    {
        DSOFOSDBEntities db = new DSOFOSDBEntities();

        // GET: MenuItems
        public ActionResult Index()
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
            var menuItems = db.MenuItems.Include(m => m.Category);


            return View(menuItems.ToList());
        }

        //public ActionResult Process_Checkout()
        //{ 

        //}



        // GET: MenuItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItem menuItem = db.MenuItems.Find(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }
            return View(menuItem);
        }

        // GET: MenuItems/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: MenuItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MenuItemId,CategoryId,MenuItemName,MenuItemImage,MenuItemDescription,Amount,Quantity,IsActive,VegNonProfile,CreatedAt")] MenuItem menuItem, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                //db.MenuItems.Add(menuItem);
                //db.SaveChanges();
                //return RedirectToAction("Index");

                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    string filename = file.FileName;
                    ViewBag.Message = "File uploaded successfully";
                    menuItem.MenuItemImage = "Images/" + filename;
                    db.MenuItems.Add(menuItem);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }

            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", menuItem.CategoryId);
            return View(menuItem);
        }

        // GET: MenuItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItem menuItem = db.MenuItems.Find(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", menuItem.CategoryId);
            return View(menuItem);
        }

        // POST: MenuItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MenuItemId,CategoryId,MenuItemName,MenuItemImage,MenuItemDescription,Amount,Quantity,IsActive,VegNonProfile,CreatedAt")] MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menuItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", menuItem.CategoryId);
            return View(menuItem);
        }

        // GET: MenuItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItem menuItem = db.MenuItems.Find(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }
            return View(menuItem);
        }

        // POST: MenuItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuItem menuItem = db.MenuItems.Find(id);
            db.MenuItems.Remove(menuItem);
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
        public ActionResult Adtocart(int? Id)
        {

            MenuItem m = db.MenuItems.Where(x => x.MenuItemId == Id).SingleOrDefault();
            return View(m);
        }

        List<FoodCartClass> li = new List<FoodCartClass>();
        [HttpPost]
        public ActionResult Adtocart(MenuItem pi, string qty, int Id)
        {
            MenuItem p = db.MenuItems.Where(x => x.MenuItemId == Id).SingleOrDefault();

            FoodCartClass c = new FoodCartClass();
            c.ItemId = p.MenuItemId;
            c.Amount = (float)p.Amount;
            c.Quantity = Convert.ToInt32(qty);
            c.Bill = c.Amount * c.Quantity;
            c.Status = "Pending";
        
            c.ItemName = p.MenuItemName;
            if (TempData["FoodCartClass"] == null)
            {
                li.Add(c);
                TempData["FoodCartClass"] = li;

            }
            else
            {
                List<FoodCartClass> li2 = TempData["FoodCartClass"] as List<FoodCartClass>;
                int flag = 0;
                foreach (var item in li2)
                {
                    if (item.ItemId == c.ItemId)
                    {
                        item.Quantity += c.Quantity;
                        item.Bill += c.Bill;
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    li2.Add(c);
                    //item is new... 
                }
                //li2.Add(c);
                TempData["FoodCartClass"] = li2;
            }

            TempData.Keep();

            return RedirectToAction("Index");
        }

        public ActionResult remove(int? id)
        {
            List<FoodCartClass> li2 = TempData["FoodCartClass"] as List<FoodCartClass>;
            FoodCartClass c = li2.Where(x => x.ItemId == id).SingleOrDefault();
            li2.Remove(c);
            float h = 0;
            foreach (var item in li2)
            {
                h += item.Bill;

            }
            TempData["total"] = h;
            return RedirectToAction("checkout");
        }
        public ActionResult checkout()
        {
            TempData.Keep();


            return View();
        }



        [HttpPost]

        public ActionResult checkout(tbl_order o)
        {
            List<FoodCartClass> li = TempData["FoodCartClass"] as List<FoodCartClass>;
            tbl_invoice iv = new tbl_invoice();

            iv.UserId = Convert.ToInt32(Session["UserId"].ToString());
            iv.in_date = System.DateTime.Now;
            iv.in_totalbill = (float)TempData["total"];
            db.tbl_invoice.Add(iv);
            db.SaveChanges();
            foreach (var item in li)
            {
                tbl_order od = new tbl_order();
                od.MenuItemId = item.ItemId;
                od.in_id = iv.in_id;
                od.o_date = System.DateTime.Now;
                od.o_qty = item.Quantity;
                od.Status = "Pending";
                od.o_bill = (int)item.Bill;
                od.o_unitprice = (int)item.Amount;
              
                db.tbl_order.Add(od);
                db.SaveChanges();
            }
            //TempData.Remove("total");
            //TempData.Remove("FoodCartClass");
            TempData["msg"] = "Transaction Completed....";

            TempData.Keep();
            return RedirectToAction("Create", "PaymentsUser");
            //return View();
        }
        public ActionResult invoice_Genration()
        {
            TempData.Keep();


            return View();
        }
        [HttpPost]
        public ActionResult invoice_Genration(tbl_order o)
        {
           

            List<FoodCartClass> li = TempData["FoodCartClass"] as List<FoodCartClass>;
            tbl_invoice iv = new tbl_invoice();

            // iv.UserId = Convert.ToInt32(Session["UserId"].ToString());

            iv.in_date = System.DateTime.Now;
            iv.in_totalbill = (float)TempData["total"];
            db.tbl_invoice.Add(iv);
            db.SaveChanges();
            foreach (var item in li)
            {
                tbl_order od = new tbl_order();
                od.MenuItemId = item.ItemId;
                od.in_id = iv.in_id;
                od.o_date = System.DateTime.Now;
                od.o_qty = item.Quantity;
                od.o_bill = (int)item.Bill;
                od.o_unitprice = (int)item.Amount;
               
                db.tbl_order.Add(od);
                db.SaveChanges();
            }
            TempData.Remove("total");
            TempData.Remove("FoodCartClass");
            //TempData["msg"] = "Transaction Completed....";

            TempData.Keep();
            return RedirectToAction("Create", "PaymentsUser");
            
            //return View();
        }

        

        public ActionResult ShowComment(int menuItemId)
        {
            IEnumerable<CommentViewModel> listofCommentViewModels = (from objComment in db.Reviews
                                                                     where objComment.MenuItemId == menuItemId
                                                                     select new CommentViewModel()
                                                                     {

                                                                         MenuItemId = objComment.MenuItemId,
                                                                         Remarks = objComment.Remarks,
                                                                         ReviewId = objComment.ReviewId,
                                                                         CreatedAt = objComment.CreatedAt,
                                                                         Rate = objComment.Rate

                                                                     }).ToList();
            ViewBag.MenuItemId = menuItemId;
            return View(listofCommentViewModels);
        }

        [HttpPost]
        public ActionResult AddComment(int menuItemId,int rating,string menuComment)
        {
            Review objComment = new Review();
            objComment.MenuItemId = menuItemId; 
            objComment.Remarks = menuComment;
            objComment.CreatedAt = DateTime.Now;
            objComment.Rate = rating;
            //objComment.UserId =
            db.Reviews.Add(objComment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
