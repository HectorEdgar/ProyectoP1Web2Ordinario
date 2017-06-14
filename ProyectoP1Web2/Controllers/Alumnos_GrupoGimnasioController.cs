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
    public class Alumnos_GrupoGimnasioController : Controller
    {
        private SistemaGimnasioEntities db = new SistemaGimnasioEntities();

        // GET: Alumnos_GrupoGimnasio
        public async Task<ActionResult> Index()
        {
            var alumnos_GrupoGimnasio = db.Alumnos_GrupoGimnasio.Include(a => a.Alumno).Include(a => a.GrupoGimnasio);
            return View(await alumnos_GrupoGimnasio.ToListAsync());
        }

        // GET: Alumnos_GrupoGimnasio/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumnos_GrupoGimnasio alumnos_GrupoGimnasio = await db.Alumnos_GrupoGimnasio.FindAsync(id);
            if (alumnos_GrupoGimnasio == null)
            {
                return HttpNotFound();
            }
            return View(alumnos_GrupoGimnasio);
        }

        // GET: Alumnos_GrupoGimnasio/Create
        public ActionResult Create()
        {
            ViewBag.Matricula = new SelectList(db.Alumno, "Matricula", "Matricula");
            ViewBag.idGimnasio = new SelectList(db.GrupoGimnasio, "idGimnasio", "nombre");
            return View();
        }

        // POST: Alumnos_GrupoGimnasio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Matricula,idGimnasio,idAlumnos_GrupoGimnasio")] Alumnos_GrupoGimnasio alumnos_GrupoGimnasio)
        {
            if (ModelState.IsValid)
            {
                db.Alumnos_GrupoGimnasio.Add(alumnos_GrupoGimnasio);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Matricula = new SelectList(db.Alumno, "Matricula", "Matricula", alumnos_GrupoGimnasio.Matricula);
            ViewBag.idGimnasio = new SelectList(db.GrupoGimnasio, "idGimnasio", "nombre", alumnos_GrupoGimnasio.idGimnasio);
            return View(alumnos_GrupoGimnasio);
        }

        // GET: Alumnos_GrupoGimnasio/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumnos_GrupoGimnasio alumnos_GrupoGimnasio = await db.Alumnos_GrupoGimnasio.FindAsync(id);
            if (alumnos_GrupoGimnasio == null)
            {
                return HttpNotFound();
            }
            ViewBag.Matricula = new SelectList(db.Alumno, "Matricula", "Matricula", alumnos_GrupoGimnasio.Matricula);
            ViewBag.idGimnasio = new SelectList(db.GrupoGimnasio, "idGimnasio", "nombre", alumnos_GrupoGimnasio.idGimnasio);
            return View(alumnos_GrupoGimnasio);
        }

        // POST: Alumnos_GrupoGimnasio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Matricula,idGimnasio,idAlumnos_GrupoGimnasio")] Alumnos_GrupoGimnasio alumnos_GrupoGimnasio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumnos_GrupoGimnasio).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Matricula = new SelectList(db.Alumno, "Matricula", "Matricula", alumnos_GrupoGimnasio.Matricula);
            ViewBag.idGimnasio = new SelectList(db.GrupoGimnasio, "idGimnasio", "nombre", alumnos_GrupoGimnasio.idGimnasio);
            return View(alumnos_GrupoGimnasio);
        }

        // GET: Alumnos_GrupoGimnasio/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumnos_GrupoGimnasio alumnos_GrupoGimnasio = await db.Alumnos_GrupoGimnasio.FindAsync(id);
            if (alumnos_GrupoGimnasio == null)
            {
                return HttpNotFound();
            }
            return View(alumnos_GrupoGimnasio);
        }

        // POST: Alumnos_GrupoGimnasio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Alumnos_GrupoGimnasio alumnos_GrupoGimnasio = await db.Alumnos_GrupoGimnasio.FindAsync(id);
            db.Alumnos_GrupoGimnasio.Remove(alumnos_GrupoGimnasio);
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
