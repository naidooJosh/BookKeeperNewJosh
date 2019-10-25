using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookKeeperNewJosh.DAL;

namespace BookKeeperNewJosh.Models
{
    public class YourPostings : Controller
    {
        private BookKeeperEntities3 db = new BookKeeperEntities3();

        // GET: YourPostings
        public ActionResult Index()
        {
            var bookListings = db.BookListings.Include(b => b.Module).Include(b => b.User);
            return View(bookListings.ToList());
        }

        // GET: YourPostings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookListing bookListing = db.BookListings.Find(id);
            if (bookListing == null)
            {
                return HttpNotFound();
            }
            return View(bookListing);
        }

        // GET: YourPostings/Create
        public ActionResult Create()
        {
            ViewBag.moduleKey = new SelectList(db.Modules, "moduleKey", "moduleCode");
            ViewBag.studentNumber = new SelectList(db.Users, "studentNo", "fName");
            return View();
        }

        // POST: YourPostings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "listingID,listedPrice,soldPrice,condition,title,author,studentNumber,moduleKey,photo,description,isSold,isQuickSell,perDrop,duration")] BookListing bookListing)
        {
            if (ModelState.IsValid)
            {
                db.BookListings.Add(bookListing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.moduleKey = new SelectList(db.Modules, "moduleKey", "moduleCode", bookListing.moduleKey);
            ViewBag.studentNumber = new SelectList(db.Users, "studentNo", "fName", bookListing.studentNumber);
            return View(bookListing);
        }

        // GET: YourPostings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookListing bookListing = db.BookListings.Find(id);
            if (bookListing == null)
            {
                return HttpNotFound();
            }
            ViewBag.moduleKey = new SelectList(db.Modules, "moduleKey", "moduleCode", bookListing.moduleKey);
            ViewBag.studentNumber = new SelectList(db.Users, "studentNo", "fName", bookListing.studentNumber);
            return View(bookListing);
        }

        // POST: YourPostings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "listingID,listedPrice,soldPrice,condition,title,author,studentNumber,moduleKey,photo,description,isSold,isQuickSell,perDrop,duration")] BookListing bookListing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookListing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.moduleKey = new SelectList(db.Modules, "moduleKey", "moduleCode", bookListing.moduleKey);
            ViewBag.studentNumber = new SelectList(db.Users, "studentNo", "fName", bookListing.studentNumber);
            return View(bookListing);
        }

        // GET: YourPostings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookListing bookListing = db.BookListings.Find(id);
            if (bookListing == null)
            {
                return HttpNotFound();
            }
            return View(bookListing);
        }

        // POST: YourPostings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookListing bookListing = db.BookListings.Find(id);
            db.BookListings.Remove(bookListing);
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
