using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectDup.DataContext;
using ProjectDup.Models;

namespace ProjectDup.Controllers
{
    public class PribadiController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pribadi
        public ActionResult Index()
        {
            return View(db.PribadiObj.ToList());
        }

        // GET: Pribadi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PribadiClass pribadiClass = db.PribadiObj.Find(id);
            if (pribadiClass == null)
            {
                return HttpNotFound();
            }
            return View(pribadiClass);
        }

        // GET: Pribadi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pribadi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "username,password,no_ktp,nama,no_hp,email")] PribadiClass pribadiClass)
        {
            if (ModelState.IsValid)
            {
                db.PribadiObj.Add(pribadiClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pribadiClass);
        }

        // GET: Pribadi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PribadiClass pribadiClass = db.PribadiObj.Find(id);
            if (pribadiClass == null)
            {
                return HttpNotFound();
            }
            return View(pribadiClass);
        }

        // POST: Pribadi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_pelanggan,username,password,no_ktp,nama,no_hp,email")] PribadiClass pribadiClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pribadiClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pribadiClass);
        }

        // GET: Pribadi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PribadiClass pribadiClass = db.PribadiObj.Find(id);
            if (pribadiClass == null)
            {
                return HttpNotFound();
            }
            return View(pribadiClass);
        }

        // POST: Pribadi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PribadiClass pribadiClass = db.PribadiObj.Find(id);
            db.PribadiObj.Remove(pribadiClass);
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
