using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FootCenter.Models;

namespace FootCenter.Controllers
{
    public class AjanvarausController : Controller
    {
        private FootBaseEntities1 db = new FootBaseEntities1();

        // GET: Ajanvaraus
        public ActionResult Index()
        {
            return View(db.Ajanvaraus.ToList());
        }

        // GET: Ajanvaraus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ajanvaraus ajanvaraus = db.Ajanvaraus.Find(id);
            if (ajanvaraus == null)
            {
                return HttpNotFound();
            }
            return View(ajanvaraus);
        }

        // GET: Ajanvaraus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ajanvaraus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VarausID,AsiakasID,TyontekijaID,pvm")] Ajanvaraus ajanvaraus)
        {
            if (ModelState.IsValid)
            {
                db.Ajanvaraus.Add(ajanvaraus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ajanvaraus);
        }

        // GET: Ajanvaraus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ajanvaraus ajanvaraus = db.Ajanvaraus.Find(id);
            if (ajanvaraus == null)
            {
                return HttpNotFound();
            }
            return View(ajanvaraus);
        }

        // POST: Ajanvaraus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VarausID,AsiakasID,TyontekijaID,pvm")] Ajanvaraus ajanvaraus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ajanvaraus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ajanvaraus);
        }

        // GET: Ajanvaraus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ajanvaraus ajanvaraus = db.Ajanvaraus.Find(id);
            if (ajanvaraus == null)
            {
                return HttpNotFound();
            }
            return View(ajanvaraus);
        }

        // POST: Ajanvaraus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ajanvaraus ajanvaraus = db.Ajanvaraus.Find(id);
            db.Ajanvaraus.Remove(ajanvaraus);
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
