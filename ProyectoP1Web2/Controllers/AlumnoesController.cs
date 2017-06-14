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
    public class AlumnoesController : Controller
    {
        private SistemaGimnasioEntities db = new SistemaGimnasioEntities();

        // GET: Alumnoes
        public ActionResult Index()
        {
            var alumno = db.Alumno.Include(a => a.Grupo).Include(a => a.Persona);
            return View(alumno.ToList());
        }

        // GET: Alumnoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = db.Alumno.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return PartialView(alumno);
        }

        // GET: Alumnoes/Create
        public ActionResult Create()
        {
            ViewBag.idGrupo = new SelectList(db.Grupo, "idGrupo", "Nombre");
            ViewBag.idPersona = new SelectList(db.Persona, "idPersona", "Nombre");
            return View();
        }

        // POST: Alumnoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Matricula,idGrupo,idPersona")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                db.Alumno.Add(alumno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idGrupo = new SelectList(db.Grupo, "idGrupo", "Nombre", alumno.idGrupo);
            ViewBag.idPersona = new SelectList(db.Persona, "idPersona", "Nombre", alumno.idPersona);
            return View(alumno);
        }

        // GET: Alumnoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = db.Alumno.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            ViewBag.idGrupo = new SelectList(db.Grupo, "idGrupo", "Nombre", alumno.idGrupo);
            ViewBag.idPersona = new SelectList(db.Persona, "idPersona", "Nombre", alumno.idPersona);
            return View(alumno);
        }

        // POST: Alumnoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Matricula,idGrupo,idPersona")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idGrupo = new SelectList(db.Grupo, "idGrupo", "Nombre", alumno.idGrupo);
            ViewBag.idPersona = new SelectList(db.Persona, "idPersona", "Nombre", alumno.idPersona);
            return View(alumno);
        }

        // GET: Alumnoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = db.Alumno.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // POST: Alumnoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Alumno alumno = db.Alumno.Find(id);
            db.Alumno.Remove(alumno);
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
