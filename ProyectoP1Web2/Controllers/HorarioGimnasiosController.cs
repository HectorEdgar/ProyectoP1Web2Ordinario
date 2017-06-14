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
    public class HorarioGimnasiosController : Controller
    {
        private SistemaGimnasioEntities db = new SistemaGimnasioEntities();

        // GET: HorarioGimnasios
        public ActionResult Index()
        {
            return View(db.HorarioGimnasio.ToList());
        }

        // GET: HorarioGimnasios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<HorarioGimnasio_Hora> horarioGimnasio = db.HorarioGimnasio_Hora.Where(p=>p.IdHorario==id).ToList();
            if (horarioGimnasio == null)
            {
                return HttpNotFound();
            }
            return PartialView(horarioGimnasio);
        }

        // GET: HorarioGimnasios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HorarioGimnasios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdHorario,nombre")] HorarioGimnasio horarioGimnasio)
        {
            if (ModelState.IsValid)
            {
                db.HorarioGimnasio.Add(horarioGimnasio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(horarioGimnasio);
        }

        // GET: HorarioGimnasios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorarioGimnasio horarioGimnasio = db.HorarioGimnasio.Find(id);
            if (horarioGimnasio == null)
            {
                return HttpNotFound();
            }
            return View(horarioGimnasio);
        }

        // POST: HorarioGimnasios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdHorario,nombre")] HorarioGimnasio horarioGimnasio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horarioGimnasio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(horarioGimnasio);
        }

        // GET: HorarioGimnasios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorarioGimnasio horarioGimnasio = db.HorarioGimnasio.Find(id);
            if (horarioGimnasio == null)
            {
                return HttpNotFound();
            }
            return View(horarioGimnasio);
        }

        // POST: HorarioGimnasios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HorarioGimnasio horarioGimnasio = db.HorarioGimnasio.Find(id);
            db.HorarioGimnasio.Remove(horarioGimnasio);
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
