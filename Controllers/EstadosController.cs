using PracticaJson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticaJson.Controllers
{
    public class EstadosController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Estados
        public JsonResult Index()
        {
            var Estados = from est in db.estados
                          select new { estadoID = est.estadoID, nombreEstado = est.nombreEstado };
            var Estado = Estados.ToList();
            return Json(Estado, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getMunicipios(int id)
        {
            var listaMunicipio = db.municipios.Where(a => a.estadoID == id);
            var Municipios = from est in listaMunicipio
                             select new { municipioID = est.municipioID, nombreMunicipio = est.nombreMunicipio };
            var municipio = Municipios.ToList();

            return Json(municipio, JsonRequestBehavior.AllowGet);
        }
    }
}