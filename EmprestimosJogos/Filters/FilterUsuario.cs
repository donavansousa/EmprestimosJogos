using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EmprestimosJogos.Filters
{
    public class FilterUsuario : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object usuario = filterContext.HttpContext.Session["usuarioLogado"];
            if (usuario == null)
            {

                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { Controller = "Usuario", Action = "Login" })
                    );
                
            }
        }
    }
}