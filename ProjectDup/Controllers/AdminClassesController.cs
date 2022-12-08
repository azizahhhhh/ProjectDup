using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ProjectDup.DataContext;
using ProjectDup.Models;

namespace ProjectDup.Controllers
{
    public class AdminClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminClasses
        public ActionResult Index()
        {
            return View(db.AdminObj.ToList());
        }

        // GET: AdminClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminClass adminClass = db.AdminObj.Find(id);
            if (adminClass == null)
            {
                return HttpNotFound();
            }
            return View(adminClass);
        }

        // GET: AdminClasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_admin,nama,username,password,no_hp")] AdminClass adminClass)
        {
            if (ModelState.IsValid)
            {
                db.AdminObj.Add(adminClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adminClass);
        }

        // GET: AdminClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminClass adminClass = db.AdminObj.Find(id);
            if (adminClass == null)
            {
                return HttpNotFound();
            }
            return View(adminClass);
        }

        // POST: AdminClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_admin,nama,username,password,no_hp")] AdminClass adminClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminClass);
        }

        // GET: AdminClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminClass adminClass = db.AdminObj.Find(id);
            if (adminClass == null)
            {
                return HttpNotFound();
            }
            return View(adminClass);
        }

        // POST: AdminClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminClass adminClass = db.AdminObj.Find(id);
            db.AdminObj.Remove(adminClass);
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

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login([Bind(Include = "username,password")] AdminClass adminclass)
        {
            var admin = db.AdminObj.Where(a => a.username.Equals(adminclass.username) && a.password.Equals(adminclass.password));
            if (admin != null)
            {
                Session["login"] = true;
            }
            return RedirectToAction(nameof(Login));

        }


    }
}
