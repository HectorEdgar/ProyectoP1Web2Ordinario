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
    public class HorarioGimnasio_HoraController : Controller
    {
        private SistemaGimnasioEntities db = new SistemaGimnasioEntities();

        // GET: HorarioGimnasio_Hora
        public ActionResult Index()
        {
            var horarioGimnasio_Hora = db.HorarioGimnasio_Hora.Include(h => h.Hora).Include(h => h.HorarioGimnasio);
            return View(horarioGimnasio_Hora.ToList());
        }

        // GET: HorarioGimnasio_Hora/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorarioGimnasio_Hora horarioGimnasio_Hora = db.HorarioGimnasio_Hora.Find(id);
            if (horarioGimnasio_Hora == null)
            {
                return HttpNotFound();
            }
            return View(horarioGimnasio_Hora);
        }

        // GET: HorarioGimnasio_Hora/Create
        public ActionResult Create()
        {
            ViewBag.IdHora = new SelectList(db.Hora, "IdHora", "IdHora");
            ViewBag.IdHorario = new SelectList(db.HorarioGimnasio, "IdHorario", "nombre");
            return View();
        }

        // POST: HorarioGimnasio_Hora/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idHorarioGimnasio_Horas,IdHora,IdHorario,Dia")] HorarioGimnasio_Hora horarioGimnasio_Hora)
        {
            if (ModelState.IsValid)
            {
                db.HorarioGimnasio_Hora.Add(horarioGimnasio_Hora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdHora = new SelectList(db.Hora, "IdHora", "IdHora", horarioGimnasio_Hora.IdHora);
            ViewBag.IdHorario = new SelectList(db.HorarioGimnasio, "IdHorario", "nombre", horarioGimnasio_Hora.IdHorario);
            return View(horarioGimnasio_Hora);
        }

        // GET: HorarioGimnasio_Hora/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorarioGimnasio_Hora horarioGimnasio_Hora = db.HorarioGimnasio_Hora.Find(id);
            if (horarioGimnasio_Hora == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdHora = new SelectList(db.Hora, "IdHora", "IdHora", horarioGimnasio_Hora.IdHora);
            ViewBag.IdHorario = new SelectList(db.HorarioGimnasio, "IdHorario", "nombre", horarioGimnasio_Hora.IdHorario);
            return View(horarioGimnasio_Hora);
        }

        // POST: HorarioGimnasio_Hora/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idHorarioGimnasio_Horas,IdHora,IdHorario,Dia")] HorarioGimnasio_Hora horarioGimnasio_Hora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horarioGimnasio_Hora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdHora = new SelectList(db.Hora, "IdHora", "IdHora", horarioGimnasio_Hora.IdHora);
            ViewBag.IdHorario = new SelectList(db.HorarioGimnasio, "IdHorario", "nombre", horarioGimnasio_Hora.IdHorario);
            return View(horarioGimnasio_Hora);
        }

        // GET: HorarioGimnasio_Hora/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorarioGimnasio_Hora horarioGimnasio_Hora = db.HorarioGimnasio_Hora.Find(id);
            if (horarioGimnasio_Hora == null)
            {
                return HttpNotFound();
            }
            return View(horarioGimnasio_Hora);
        }

        // POST: HorarioGimnasio_Hora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HorarioGimnasio_Hora horarioGimnasio_Hora = db.HorarioGimnasio_Hora.Find(id);
            db.HorarioGimnasio_Hora.Remove(horarioGimnasio_Hora);
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
