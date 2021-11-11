using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWebVuelos.Filters
{
    public class MyfilterAction : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Capturo de que controlador me piden la accion
            var controller = filterContext.RouteData.Values["controller"];
            //Capturo que accion me estan pidiendo
            var action = filterContext.RouteData.Values["action"];


            Debug.WriteLine(controller + " " + action + " Paso por OnActionExecuting");
        }

        //Filtro de accion - ocurre despues
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //Capturo de que controlador me piden la accion
            // Ruta: controller/accion/parametros
            var controller = filterContext.RouteData.Values["controller"];
            //Capturo que accion me estan pidiendo
            var action = filterContext.RouteData.Values["action"];


            Debug.WriteLine(controller + " " + action + " Paso por OnActionExecuted");
        }
}