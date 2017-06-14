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
    public class GrupoGimnasiosController : Controller
    {
        private SistemaGimnasioEntities db = new SistemaGimnasioEntities();

        // GET: GrupoGimnasios
        public ActionResult Index()
        {
            var grupoGimnasio = db.GrupoGimnasio.Include(g => g.HorarioGimnasio);
            return View(grupoGimnasio.ToList());
        }

        // GET: GrupoGimnasios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoGimnasio grupoGimnasio = db.GrupoGimnasio.Find(id);
            if (grupoGimnasio == null)
            {
                return HttpNotFound();
            }
            return View(grupoGimnasio);
        }

        // GET: GrupoGimnasios/Create
        public ActionResult Create()
        {
            ViewBag.IdHorario = new SelectList(db.HorarioGimnasio, "IdHorario", "nombre");
            return View();
        }

        // POST: GrupoGimnasios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idGimnasio,nombre,IdHorario")] GrupoGimnasio grupoGimnasio)
        {
            if (ModelState.IsValid)
            {
                db.GrupoGimnasio.Add(grupoGimnasio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdHorario = new SelectList(db.HorarioGimnasio, "IdHorario", "nombre", grupoGimnasio.IdHorario);
            return View(grupoGimnasio);
        }

        // GET: GrupoGimnasios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoGimnasio grupoGimnasio = db.GrupoGimnasio.Find(id);
            if (grupoGimnasio == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdHorario = new SelectList(db.HorarioGimnasio, "IdHorario", "nombre", grupoGimnasio.IdHorario);
            return View(grupoGimnasio);
        }

        // POST: GrupoGimnasios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idGimnasio,nombre,IdHorario")] GrupoGimnasio grupoGimnasio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupoGimnasio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdHorario = new SelectList(db.HorarioGimnasio, "IdHorario", "nombre", grupoGimnasio.IdHorario);
            return View(grupoGimnasio);
        }

        // GET: GrupoGimnasios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoGimnasio grupoGimnasio = db.GrupoGimnasio.Find(id);
            if (grupoGimnasio == null)
            {
                return HttpNotFound();
            }
            return View(grupoGimnasio);
        }

        // POST: GrupoGimnasios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GrupoGimnasio grupoGimnasio = db.GrupoGimnasio.Find(id);
            db.GrupoGimnasio.Remove(grupoGimnasio);
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
