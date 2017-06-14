using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoP1Web2.Models;

namespace ProyectoP1Web2.Controllers
{
    [Authorize]
    public class LicenciaturasController : Controller
    {
        
        private SistemaGimnasioEntities db = new SistemaGimnasioEntities();

        // GET: Licenciaturas
        public ActionResult Index()
        {
            return View(db.Licenciatura.ToList());
        }

        // GET: Licenciaturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licenciatura licenciatura = db.Licenciatura.Find(id);
            if (licenciatura == null)
            {
                return HttpNotFound();
            }
            return View(licenciatura);
        }

        // GET: Licenciaturas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Licenciaturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLicenciatura,Nombre")] Licenciatura licenciatura)
        {
            if (ModelState.IsValid)
            {
                db.Licenciatura.Add(licenciatura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(licenciatura);
        }

        // GET: Licenciaturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licenciatura licenciatura = db.Licenciatura.Find(id);
            if (licenciatura == null)
            {
                return HttpNotFound();
            }
            return View(licenciatura);
        }

        // POST: Licenciaturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLicenciatura,Nombre")] Licenciatura licenciatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licenciatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(licenciatura);
        }

        // GET: Licenciaturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licenciatura licenciatura = db.Licenciatura.Find(id);
            if (licenciatura == null)
            {
                return HttpNotFound();
            }
            return View(licenciatura);
        }

        // POST: Licenciaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Licenciatura licenciatura = db.Licenciatura.Find(id);
            db.Licenciatura.Remove(licenciatura);
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
