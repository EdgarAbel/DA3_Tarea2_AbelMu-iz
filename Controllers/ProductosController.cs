using PracticaJson.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticaJson.Controllers
{
    public class ProductosController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Productos
        public JsonResult GetJsonList()
        {
            var productos = db.productos.ToList();
            return Json(productos, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult CreateProducto(Productos productos)
        {
            var Respuesta = new { Funciono = true };
            try
            {
                db.productos.Add(productos);
                int registrosModificados = db.SaveChanges();
                if (registrosModificados > 0)
                {
                    Respuesta = new { Funciono = true };
                }
            }
            catch { }
            return Json(Respuesta);
        }
        [HttpPost]
        public JsonResult borrarProducto(int id)
        {
            var Respuesta = new { Funciono = false };
            try
            {
                var producto = db.productos.Find(id);
                db.productos.Remove(producto);
                int registrosModificados = db.SaveChanges();
                if (registrosModificados > 0)
                {
                    Respuesta = new { Funciono = true };
                }
            }
            catch { }
            return Json(Respuesta, JsonRequestBehavior.AllowGet);
        }
        public JsonResult editarProducto(int id)
        {
            var productoaEditar = db.productos.Find(id);

            var respuesta = new { id = productoaEditar.ProductoID, nombre = productoaEditar.Nombre, precio = productoaEditar.Precio };
            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult editar(Productos producto)

        {
            var resultado = db.Entry(producto).State = EntityState.Modified;
            db.SaveChanges();

            return Json(resultado, JsonRequestBehavior.AllowGet);

        }
        //public class AllowCrossSiteJsonAtribute : ActionFilterAttribute
        //{
        //    public override void OnActionExecuting(ActionExecutingContext filterContext)
        //    {
        //        filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
        //        base.OnActionExecuting(filterContext);
        //    }
        //}
    }
}