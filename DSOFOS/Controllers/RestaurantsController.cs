using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DSOFOS.Models;
using DSOFOS.ViewModel;
using PagedList;

namespace DSOFOS.Controllers
{
    public class RestaurantsController : Controller
    {
        private DSOFOSDBEntities db = new DSOFOSDBEntities();

        public bool IsPostBack { get; private set; }

        // GET: Restaurants
        public ActionResult Index(String Search)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] == null)
                {
                    Response.Redirect("../User/Login.aspx");
                }
                
            }

            if(Search != null)
            {
                var Result = db.Restaurants.Include(r => r.Category).Where(r => r.RestaurantName.Contains(Search));
                return View(Result);
            }

            var restaurants = db.Restaurants.Include(r => r.Category);
            return View(restaurants.ToList());
        }

        // GET: Restaurants/Details/5
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

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestaurantId,RestaurantName,CategoryId,RestaurantImage,RestaurantDescription,IsActive,OpenTime,CloseTime")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", restaurant.CategoryId);
            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
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

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestaurantId,RestaurantName,CategoryId,RestaurantImage,RestaurantDescription,IsActive,OpenTime,CloseTime")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", restaurant.CategoryId);
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
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

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //public ActionResult ShowMenuRest(int CategoryId)
        //{
        //    IEnumerable<CategoryViewModel> listofMenuItemViewModels = (from objComment in db.Restaurants
        //                                                               where objComment.CategoryId == CategoryId
        //                                                               select new CategoryViewModel()
        //                                                               {


        //                                                                   RestaurantId = objComment.RestaurantId,
        //                                                                   RestaurantName = objComment.RestaurantName,
        //                                                                   RestaurantImage = objComment.RestaurantImage,
        //                                                                   RestaurantDescription = objComment.RestaurantDescription,
        //                                                                   IsActive = objComment.IsActive,
        //                                                                   OpenTime = objComment.OpenTime,
        //                                                                   CloseTime = objComment.CloseTime

        //                                                               }).ToList();
        //    // ViewBag.CategoryId = categoryId;
        //    return View(listofMenuItemViewModels);
        //}
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //public ActionResult ShowMenu(int CategoryId)
        //{
        //    IEnumerable<MenuItemViewModel> listofMenuItemViewModels = (from objComment in db.MenuItems
        //                                                               where objComment.CategoryId == CategoryId
        //                                                               select new MenuItemViewModel()
        //                                                               {


        //                                                                   MenuItemId = objComment.MenuItemId,
        //                                                                   MenuItemName = objComment.MenuItemName,
        //                                                                   MenuItemImage = objComment.MenuItemImage,
        //                                                                   MenuItemDescription = objComment.MenuItemDescription,
        //                                                                   Amount = objComment.Amount,
        //                                                                   IsActive = objComment.IsActive

        //                                                               }).ToList();
        //    // ViewBag.CategoryId = categoryId;
        //    return View(listofMenuItemViewModels);
        //}

        //public ActionResult ShowMenuRest(int RestaurantId)
        //{
        //    IEnumerable<CategoryViewModel> listofMenuItemViewModels = (from objComment in db.Categories
        //                                                               where objComment.RestaurantId == RestaurantId
        //                                                               select new CategoryViewModel()
        //                                                               {


        //                                                                   CategoryId = objComment.CategoryId,
        //                                                                   CategoryName = objComment.CategoryName,
        //                                                                   Image = objComment.Image
                                                                           

        //                                                               }).ToList();
        //    // ViewBag.CategoryId = categoryId;
        //    return View(listofMenuItemViewModels);
        //}

        //public ActionResult AdtocartRest(int? Id)
        //{
        //    MenuItem m = db.MenuItems.Where(x => x.MenuItemId == Id).SingleOrDefault();
        //    return View(m);
        //}

        //List<FoodCartClass> li = new List<FoodCartClass>();

        //[HttpPost]
        //public ActionResult AdtocartRest(MenuItem pi, string qty, int Id)
        //{
        //    MenuItem p = db.MenuItems.Where(x => x.MenuItemId == Id).SingleOrDefault();

        //    FoodCartClass c = new FoodCartClass();
        //    c.ItemId = p.MenuItemId;
        //    c.Amount = (float)p.Amount;
        //    c.Quantity = Convert.ToInt32(qty);
        //    c.Bill = c.Amount * c.Quantity;
        //    c.Status = "Pending";

        //    c.ItemName = p.MenuItemName;
        //    if (TempData["FoodCartClass"] == null)
        //    {
        //        li.Add(c);
        //        TempData["FoodCartClass"] = li;

        //    }
        //    else
        //    {
        //        List<FoodCartClass> li2 = TempData["FoodCartClass"] as List<FoodCartClass>;
        //        int flag = 0;
        //        foreach (var item in li2)
        //        {
        //            if (item.ItemId == c.ItemId)
        //            {
        //                item.Quantity += c.Quantity;
        //                item.Bill += c.Bill;
        //                flag = 1;
        //            }
        //        }
        //        if (flag == 0)
        //        {
        //            li2.Add(c);
        //            //item is new... 
        //        }
        //        //li2.Add(c);
        //        TempData["FoodCartClass"] = li2;
        //    }

        //    TempData.Keep();

        //    return RedirectToAction("Index","Categories");
        //}

        //public ActionResult removeRest(int? id)
        //{
        //    List<FoodCartClass> li2 = TempData["FoodCartClass"] as List<FoodCartClass>;
        //    FoodCartClass c = li2.Where(x => x.ItemId == id).SingleOrDefault();
        //    li2.Remove(c);
        //    float h = 0;
        //    foreach (var item in li2)
        //    {
        //        h += item.Bill;

        //    }
        //    TempData["total"] = h;
        //    return RedirectToAction("checkout");
        //}
        //public ActionResult checkout()
        //{

        //    TempData.Keep();


        //    return View();
        //}



        //[HttpPost]

        //public ActionResult checkoutRest(tbl_order o)
        //{

        //    List<FoodCartClass> li = TempData["FoodCartClass"] as List<FoodCartClass>;
        //    tbl_invoice iv = new tbl_invoice();

        //    iv.UserId = Convert.ToInt32(Session["UserId"].ToString());
        //    iv.in_date = System.DateTime.Now;
        //    iv.in_totalbill = (float)TempData["total"];
        //    db.tbl_invoice.Add(iv);
        //    db.SaveChanges();
        //    foreach (var item in li)
        //    {
        //        tbl_order od = new tbl_order();
        //        od.MenuItemId = item.ItemId;
        //        od.in_id = iv.in_id;
        //        od.o_date = System.DateTime.Now;
        //        od.o_qty = item.Quantity;
        //        od.Status = "Pending";
        //        od.o_bill = (int)item.Bill;
        //        od.o_unitprice = (int)item.Amount;

        //        db.tbl_order.Add(od);
        //        db.SaveChanges();
        //    }
        //    //TempData.Remove("total");
        //    //TempData.Remove("FoodCartClass");
        //    TempData["msg"] = "Transaction Completed....";

        //    TempData.Keep();
        //    return RedirectToAction("Create", "PaymentsUser");
        //    //return View();
        //}
        //public ActionResult invoice_GenrationRest()
        //{
        //    TempData.Keep();


        //    return View();
        //}
        //[HttpPost]
        //public ActionResult invoice_GenrationRest(tbl_order o)
        //{


        //    List<FoodCartClass> li = TempData["FoodCartClass"] as List<FoodCartClass>;
        //    tbl_invoice iv = new tbl_invoice();

        //    // iv.UserId = Convert.ToInt32(Session["UserId"].ToString());

        //    iv.in_date = System.DateTime.Now;
        //    iv.in_totalbill = (float)TempData["total"];
        //    db.tbl_invoice.Add(iv);
        //    db.SaveChanges();
        //    foreach (var item in li)
        //    {
        //        tbl_order od = new tbl_order();
        //        od.MenuItemId = item.ItemId;
        //        od.in_id = iv.in_id;
        //        od.o_date = System.DateTime.Now;
        //        od.o_qty = item.Quantity;
        //        od.o_bill = (int)item.Bill;
        //        od.o_unitprice = (int)item.Amount;

        //        db.tbl_order.Add(od);
        //        db.SaveChanges();
        //    }
        //    TempData.Remove("total");
        //    TempData.Remove("FoodCartClass");
        //    //TempData["msg"] = "Transaction Completed....";

        //    TempData.Keep();
        //    return RedirectToAction("Create", "PaymentsUser");

        //    //return View();
        //}

        //public ActionResult ShowCommentRest(int menuItemId)
        //{
        //    IEnumerable<CommentViewModel> listofCommentViewModels = (from objComment in db.Reviews
        //                                                             where objComment.MenuItemId == menuItemId
        //                                                             select new CommentViewModel()
        //                                                             {

        //                                                                 MenuItemId = objComment.MenuItemId,
        //                                                                 Remarks = objComment.Remarks,
        //                                                                 ReviewId = objComment.ReviewId,
        //                                                                 CreatedAt = objComment.CreatedAt,
        //                                                                 Rate = objComment.Rate,
        //                                                                 UserName = objComment.UserName

        //                                                             }).ToList();
        //    ViewBag.MenuItemId = menuItemId;
        //    return View(listofCommentViewModels);
        //}

        //[HttpPost]
        //public ActionResult AddCommentRest(int menuItemId, int rating, string menuComment, string username)
        //{
        //    Review objComment = new Review();
        //    objComment.MenuItemId = menuItemId;
        //    objComment.Remarks = menuComment;
        //    objComment.CreatedAt = DateTime.Now;
        //    objComment.Rate = rating;
        //    objComment.UserName = username;
        //    //objComment.UserId =
        //    db.Reviews.Add(objComment);
        //    db.SaveChanges();
        //    return RedirectToAction("Index", "Categories");
        //}

    }
}
