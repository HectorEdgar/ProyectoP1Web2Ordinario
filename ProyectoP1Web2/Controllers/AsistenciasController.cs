using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoP1Web2.Models;

namespace ProyectoP1Web2.Controllers
{
    [Authorize]
    public class AsistenciasController : Controller
    {
        private SistemaGimnasioEntities db = new SistemaGimnasioEntities();

        // GET: Asistencias
        public async Task<ActionResult> Index()
        {
            var asistencia = db.Asistencia.Include(a => a.Alumnos_GrupoGimnasio);
            return View(await asistencia.ToListAsync());
        }

        // GET: Asistencias/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistencia asistencia = await db.Asistencia.FindAsync(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            return View(asistencia);
        }

        // GET: Asistencias/Create
        public ActionResult Create()
        {
            ViewBag.idAlumnos_GrupoGimnasio = new SelectList(db.Alumnos_GrupoGimnasio, "idAlumnos_GrupoGimnasio", "Matricula");
            return View();
        }

        // POST: Asistencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Fecha,Estado,idAsistencia,idAlumnos_GrupoGimnasio")] Asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                db.Asistencia.Add(asistencia);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idAlumnos_GrupoGimnasio = new SelectList(db.Alumnos_GrupoGimnasio, "idAlumnos_GrupoGimnasio", "Matricula", asistencia.idAlumnos_GrupoGimnasio);
            return View(asistencia);
        }

        // GET: Asistencias/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistencia asistencia = await db.Asistencia.FindAsync(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAlumnos_GrupoGimnasio = new SelectList(db.Alumnos_GrupoGimnasio, "idAlumnos_GrupoGimnasio", "Matricula", asistencia.idAlumnos_GrupoGimnasio);
            return View(asistencia);
        }

        // POST: Asistencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Fecha,Estado,idAsistencia,idAlumnos_GrupoGimnasio")] Asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asistencia).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idAlumnos_GrupoGimnasio = new SelectList(db.Alumnos_GrupoGimnasio, "idAlumnos_GrupoGimnasio", "Matricula", asistencia.idAlumnos_GrupoGimnasio);
            return View(asistencia);
        }

        // GET: Asistencias/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistencia asistencia = await db.Asistencia.FindAsync(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            return View(asistencia);
        }

        // POST: Asistencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Asistencia asistencia = await db.Asistencia.FindAsync(id);
            db.Asistencia.Remove(asistencia);
            await db.SaveChangesAsync();
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
