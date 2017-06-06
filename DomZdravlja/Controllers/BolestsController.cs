using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DomZdravlja.Models;

namespace DomZdravlja.Controllers
{
    public class BolestsController : Controller
    {
        private DomZdravljaContext db = new DomZdravljaContext();

        // GET: Bolests
        public ActionResult Index()
        {
            return View(db.Bolests.ToList());
        }

        // GET: Bolests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolest bolest = db.Bolests.Find(id);
            if (bolest == null)
            {
                return HttpNotFound();
            }
            return View(bolest);
        }

        // GET: Bolests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bolests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BolestId,Naziv")] Bolest bolest)
        {
            if (ModelState.IsValid)
            {
                db.Bolests.Add(bolest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bolest);
        }

        // GET: Bolests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolest bolest = db.Bolests.Find(id);
            if (bolest == null)
            {
                return HttpNotFound();
            }
            return View(bolest);
        }

        // POST: Bolests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BolestId,Naziv")] Bolest bolest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bolest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bolest);
        }

        // GET: Bolests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolest bolest = db.Bolests.Find(id);
            if (bolest == null)
            {
                return HttpNotFound();
            }
            return View(bolest);
        }

        // POST: Bolests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bolest bolest = db.Bolests.Find(id);
            db.Bolests.Remove(bolest);
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
