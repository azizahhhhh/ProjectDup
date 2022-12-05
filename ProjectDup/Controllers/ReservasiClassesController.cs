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
    public class ReservasiClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ReservasiClasses
        public ActionResult Index()
        {
            return View(db.ReservasiClasses.ToList());
        }

        // GET: ReservasiClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservasiClass reservasiClass = db.ReservasiClasses.Find(id);
            if (reservasiClass == null)
            {
                return HttpNotFound();
            }
            return View(reservasiClass);
        }

        // GET: ReservasiClasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReservasiClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_reservasi,Jumlah_pemesanan,id_pelanggan,id_admin,tanggal_reservasi")] ReservasiClass reservasiClass)
        {
            if (ModelState.IsValid)
            {
                db.ReservasiClasses.Add(reservasiClass);
                var reservasi_data = db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reservasiClass);
        }

        // GET: ReservasiClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservasiClass reservasiClass = db.ReservasiClasses.Find(id);
            if (reservasiClass == null)
            {
                return HttpNotFound();
            }
            return View(reservasiClass);
        }

        // POST: ReservasiClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_reservasi,Jumlah_pemesanan,id_pelanggan,id_admin,tanggal_reservasi")] ReservasiClass reservasiClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservasiClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reservasiClass);
        }

        // GET: ReservasiClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservasiClass reservasiClass = db.ReservasiClasses.Find(id);
            if (reservasiClass == null)
            {
                return HttpNotFound();
            }
            return View(reservasiClass);
        }

        // POST: ReservasiClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReservasiClass reservasiClass = db.ReservasiClasses.Find(id);
            db.ReservasiClasses.Remove(reservasiClass);
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
