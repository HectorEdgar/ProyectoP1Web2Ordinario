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
    public class HorasController : Controller
    {

        private SistemaGimnasioEntities db = new SistemaGimnasioEntities();

        // GET: Horas
        public ActionResult Index()
        {
            return View(db.Hora.ToList());
        }

        // GET: Horas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hora hora = db.Hora.Find(id);
            if (hora == null)
            {
                return HttpNotFound();
            }
            return View(hora);
        }

        // GET: Horas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Horas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdHora,HoraInicio,HoraFin")] Hora hora)
        {
            if (ModelState.IsValid)
            {
                db.Hora.Add(hora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hora);
        }

        // GET: Horas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hora hora = db.Hora.Find(id);
            if (hora == null)
            {
                return HttpNotFound();
            }
            return View(hora);
        }

        // POST: Horas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdHora,HoraInicio,HoraFin")] Hora hora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hora);
        }

        // GET: Horas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hora hora = db.Hora.Find(id);
            if (hora == null)
            {
                return HttpNotFound();
            }
            return View(hora);
        }

        // POST: Horas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hora hora = db.Hora.Find(id);
            db.Hora.Remove(hora);
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
