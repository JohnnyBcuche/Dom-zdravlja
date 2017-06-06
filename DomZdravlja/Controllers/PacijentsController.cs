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
    public class PacijentsController : Controller
    {
        private DomZdravljaContext db = new DomZdravljaContext();

        // GET: Pacijents
      
        public ActionResult Index(FormCollection fc, string searchString)
        {
            var pacijent = from p in db.Pacijents 
                         select p;

            if (!String.IsNullOrEmpty(searchString)) 
            {
                pacijent = pacijent.Where(s => s.Ime.Contains(searchString));
                
            }

            return View(pacijent); 
        }


        // GET: Pacijents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacijent pacijent = db.Pacijents.Find(id);
            if (pacijent == null)
            {
                return HttpNotFound();
            }
            return View(pacijent);
        }

        // GET: Pacijents/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.BolestId = new SelectList(db.Bolests, "BolestId", "Naziv");
            return View();
        }

        // POST: Pacijents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PacijentId,Ime,Godiste,OpisBolesti,Lekar,BolestId")] Pacijent pacijent)
        {
            if (ModelState.IsValid)
            {
               

                db.Pacijents.Add(pacijent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BolestId = new SelectList(db.Bolests, "BolestId", "Naziv", pacijent.BolestId);
            return View(pacijent);
        }

        // GET: Pacijents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacijent pacijent = db.Pacijents.Find(id);
            if (pacijent == null)
            {
                return HttpNotFound();
            }
            ViewBag.BolestId = new SelectList(db.Bolests, "BolestId", "Naziv", pacijent.BolestId);
            return View(pacijent);
        }

        // POST: Pacijents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PacijentId,Ime,Godiste,OpisBolesti,Lekar,BolestId")] Pacijent pacijent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pacijent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BolestId = new SelectList(db.Bolests, "BolestId", "Naziv", pacijent.BolestId);
            return View(pacijent);
        }

        // GET: Pacijents/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacijent pacijent = db.Pacijents.Find(id);
            if (pacijent == null)
            {
                return HttpNotFound();
            }
            return View(pacijent);
        }

        // POST: Pacijents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pacijent pacijent = db.Pacijents.Find(id);
            db.Pacijents.Remove(pacijent);
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

        public object upload { get; set; }
    }
}
