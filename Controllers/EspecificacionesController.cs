using PracticaJson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticaJson.Controllers
{
    public class EspecificacionesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Especificaciones
        public JsonResult getEspeficicaciones(int? id)
        {
            if(id == null)
            {
                var esp = db.especificaciones.ToList();
                return Json(esp, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var esp = db.especificaciones.Find(id);
                return Json(esp, JsonRequestBehavior.AllowGet);
            }
        }
    }
}