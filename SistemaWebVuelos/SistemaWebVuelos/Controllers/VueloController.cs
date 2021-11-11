using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaWebVuelos.Data;
using SistemaWebVuelos.Filters;
using SistemaWebVuelos.Models;

namespace SistemaWebVuelos.Controllers
{
    [MyfilterAction]
    public class VueloController : Controller
    {
        DbVueloContext context = new DbVueloContext();
        // GET: Vuelo
        public ActionResult Index()
        {
            return View("Index", context.Vuelos.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            Vuelo vuelo = new Vuelo();
            return View("Create", vuelo);
        }


        [HttpPost]
        public ActionResult Create(Vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                context.Vuelos.Add(vuelo);
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View("Create", vuelo);
        }

        [HttpGet]
        public ActionResult Detail (int id)
        {

            Vuelo vuelo = context.Vuelos.Find(id);
            if (vuelo != null)
            {
                return View("Detail", vuelo);
            }

            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Delete(int id) 
        {
            Vuelo vuelo = context.Vuelos.Find(id);
            if (vuelo != null)
            {
                return View("Delete", vuelo);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Delete(Vuelo vuelo) 
        {
            context.Vuelos.Remove(context.Vuelos.Find(vuelo.ID));
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Vuelo vuelos = context.Vuelos.Find(id);

            if(vuelos != null)
            {
                return View("Edit", vuelos);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(Vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                context.Entry(vuelo).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View("Edit", vuelo);
        }

        [HttpGet]
        public ActionResult Buscar (string destino)
        {
            if (destino == null)
            {
                return RedirectToAction("Index");
            }

            var vuelos = (from v in context.Vuelos
                          where v.Destino == destino
                          select v).ToList();

            return View("Index", vuelos);
        }
    }
}