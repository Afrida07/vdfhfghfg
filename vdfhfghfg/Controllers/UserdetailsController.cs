using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using vdfhfghfg.Models;

namespace vdfhfghfg.Controllers
{
    public class UserdetailsController : Controller
    {
        private StudyAbroadEntities db = new StudyAbroadEntities();

        // GET: Userdetails
        public ActionResult Index()
        {
            return View(db.Userdetails.ToList());
        }

        // GET: Userdetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userdetail userdetail = db.Userdetails.Find(id);
            if (userdetail == null)
            {
                return HttpNotFound();
            }
            return View(userdetail);
        }

        // GET: Userdetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Userdetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Name,UserName,Email,Password")] Userdetail userdetail)
        {
            if (ModelState.IsValid)
            {
                db.Userdetails.Add(userdetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userdetail);
        }

        // GET: Userdetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userdetail userdetail = db.Userdetails.Find(id);
            if (userdetail == null)
            {
                return HttpNotFound();
            }
            return View(userdetail);
        }

        // POST: Userdetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Name,UserName,Email,Password")] Userdetail userdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userdetail);
        }

        // GET: Userdetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userdetail userdetail = db.Userdetails.Find(id);
            if (userdetail == null)
            {
                return HttpNotFound();
            }
            return View(userdetail);
        }

        // POST: Userdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Userdetail userdetail = db.Userdetails.Find(id);
            db.Userdetails.Remove(userdetail);
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
