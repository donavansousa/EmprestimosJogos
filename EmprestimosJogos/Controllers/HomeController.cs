using EmprestimosJogos.Filters;
using EmprestimosJogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmprestimosJogos.Controllers
{
    [FilterUsuario]
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }


       

    }
}