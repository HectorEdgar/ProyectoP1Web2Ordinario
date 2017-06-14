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
    public class AspNetUserLoginsController : Controller
    {
        private SistemaGimnasioEntities db = new SistemaGimnasioEntities();

        // GET: AspNetUserLogins
        public ActionResult Index()
        {
            var aspNetUserLogins = db.AspNetUserLogins.Include(a => a.AspNetUsers);
            return View(aspNetUserLogins.ToList());
        }

        // GET: AspNetUserLogins/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUserLogins aspNetUserLogins = db.AspNetUserLogins.Find(id);
            if (aspNetUserLogins == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUserLogins);
        }

        // GET: AspNetUserLogins/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: AspNetUserLogins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoginProvider,ProviderKey,UserId")] AspNetUserLogins aspNetUserLogins)
        {
            if (ModelState.IsValid)
            {
                db.AspNetUserLogins.Add(aspNetUserLogins);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", aspNetUserLogins.UserId);
            return View(aspNetUserLogins);
        }

        // GET: AspNetUserLogins/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUserLogins aspNetUserLogins = db.AspNetUserLogins.Find(id);
            if (aspNetUserLogins == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", aspNetUserLogins.UserId);
            return View(aspNetUserLogins);
        }

        // POST: AspNetUserLogins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoginProvider,ProviderKey,UserId")] AspNetUserLogins aspNetUserLogins)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aspNetUserLogins).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", aspNetUserLogins.UserId);
            return View(aspNetUserLogins);
        }

        // GET: AspNetUserLogins/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUserLogins aspNetUserLogins = db.AspNetUserLogins.Find(id);
            if (aspNetUserLogins == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUserLogins);
        }

        // POST: AspNetUserLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AspNetUserLogins aspNetUserLogins = db.AspNetUserLogins.Find(id);
            db.AspNetUserLogins.Remove(aspNetUserLogins);
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
