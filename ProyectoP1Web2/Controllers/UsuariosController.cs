using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoP1Web2.Models;
using Newtonsoft.Json;
using System.IO;

namespace ProyectoP1Web2.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private SistemaGimnasioEntities db = new SistemaGimnasioEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            var usuario = db.Usuario.Include(u => u.Persona);
            return View(usuario.ToList());
        }
        public ActionResult IndexJson()
        {
            //List<Usuario> usuario = db.Usuario.Select(p => p).Select(p=>p).ToList();
            return View(db.Usuario.Select(p=>new
            {
                p.nombreUsuario,
                p.Contraseña,
                p.Rol
            }).ToList());
            //return View(usuario);
        }

        public ActionResult Index2()
        {
            SistemaGimnasioEntities GE = new SistemaGimnasioEntities();
            return View(GE.catalogocoord.ToList());
        }

        [HttpPost]
        public ActionResult Search(string nombreUsuario)
        {
           var usuario = db.Usuario.Where(u => u.nombreUsuario.Contains(nombreUsuario)).Select(p => new
           {
               p.nombreUsuario,
               p.Contraseña,
               p.Rol
           }).ToList();
            
            return Json(usuario, JsonRequestBehavior.AllowGet);
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

 


        public ActionResult Details2(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return PartialView(usuario.Persona);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.idPersona = new SelectList(db.Persona, "idPersona", "Nombre");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nombreUsuario,Contraseña,Rol,idPersona")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPersona = new SelectList(db.Persona, "idPersona", "Nombre", usuario.idPersona);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPersona = new SelectList(db.Persona, "idPersona", "Nombre", usuario.idPersona);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nombreUsuario,Contraseña,Rol,idPersona")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPersona = new SelectList(db.Persona, "idPersona", "Nombre", usuario.idPersona);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
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
