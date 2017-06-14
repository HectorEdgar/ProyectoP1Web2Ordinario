using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoP1Web2.Models;

namespace ProyectoP1Web2.Controllers
{
    [Authorize]
    public class GeoController : Controller
    {
        public ActionResult Index()
        {
            SistemaGimnasioEntities GE = new SistemaGimnasioEntities();
            return View(GE.catalogocoord.ToList());
        }

        [HttpPost]
        public ActionResult Search(string Location)
        {
            SistemaGimnasioEntities GE = new SistemaGimnasioEntities();
            var result = GE.catalogocoord.Where(x => x.nombre.Contains(Location));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index2()
        {
            SistemaGimnasioEntities GE = new SistemaGimnasioEntities();
            return View(GE.catalogocoord.ToList());
        }
        
    }
}