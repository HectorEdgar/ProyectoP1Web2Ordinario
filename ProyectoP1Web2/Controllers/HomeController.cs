using ProyectoP1Web2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoP1Web2.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Search(string nombre)
        {
            SistemaGimnasioEntities GE = new SistemaGimnasioEntities();
            var result = GE.catalogocoord.Where(x => x.nombre.Contains(nombre)).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Decripción de la página.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contacto de la página.";
            SistemaGimnasioEntities GE = new SistemaGimnasioEntities();
            return View(GE.catalogocoord.ToList());
        }
        public FilePathResult CargaJson()
        {
            return File("./aspnetJSON.json", "text/x-json");
        }
    }
}