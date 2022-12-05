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
    public class DetailReservasiClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DetailReservasiClasses
        public ActionResult Index()
        {
            return View(db.DetailReservasiClasses.ToList());
        }

        // GET: DetailReservasiClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailReservasiClass detailReservasiClass = db.DetailReservasiClasses.Find(id);
            if (detailReservasiClass == null)
            {
                return HttpNotFound();
            }
            return View(detailReservasiClass);
        }

        // GET: DetailReservasiClasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetailReservasiClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_detail_reservasi,tanggal_check_in,tanggal_check_out,id_reservasi,id_kamar")] DetailReservasiClass detailReservasiClass)
        {
            if (ModelState.IsValid)
            {
                db.DetailReservasiClasses.Add(detailReservasiClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(detailReservasiClass);
        }

        // GET: DetailReservasiClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailReservasiClass detailReservasiClass = db.DetailReservasiClasses.Find(id);
            if (detailReservasiClass == null)
            {
                return HttpNotFound();
            }
            return View(detailReservasiClass);
        }

        // POST: DetailReservasiClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_detail_reservasi,tanggal_check_in,tanggal_check_out,id_reservasi,id_kamar")] DetailReservasiClass detailReservasiClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detailReservasiClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(detailReservasiClass);
        }

        // GET: DetailReservasiClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailReservasiClass detailReservasiClass = db.DetailReservasiClasses.Find(id);
            if (detailReservasiClass == null)
            {
                return HttpNotFound();
            }
            return View(detailReservasiClass);
        }

        // POST: DetailReservasiClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetailReservasiClass detailReservasiClass = db.DetailReservasiClasses.Find(id);
            db.DetailReservasiClasses.Remove(detailReservasiClass);
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
