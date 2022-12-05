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
    public class KamarClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: KamarClasses
        public ActionResult Index()
        {
            return View(db.KamarObj.ToList());
        }

        // GET: KamarClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KamarClass kamarClass = db.KamarObj.Find(id);
            if (kamarClass == null)
            {
                return HttpNotFound();
            }
            return View(kamarClass);
        }

        // GET: KamarClasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KamarClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_kamar,nama_kamar,harga")] KamarClass kamarClass)
        {
            if (ModelState.IsValid)
            {
                db.KamarObj.Add(kamarClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kamarClass);
        }

        // GET: KamarClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KamarClass kamarClass = db.KamarObj.Find(id);
            if (kamarClass == null)
            {
                return HttpNotFound();
            }
            return View(kamarClass);
        }

        // POST: KamarClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_kamar,nama_kamar,harga")] KamarClass kamarClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kamarClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kamarClass);
        }

        // GET: KamarClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KamarClass kamarClass = db.KamarObj.Find(id);
            if (kamarClass == null)
            {
                return HttpNotFound();
            }
            return View(kamarClass);
        }

        // POST: KamarClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KamarClass kamarClass = db.KamarObj.Find(id);
            db.KamarObj.Remove(kamarClass);
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
