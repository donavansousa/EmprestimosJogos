using EmprestimosJogos.Filters;
using EmprestimosJogos.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace EmprestimosJogos.Controllers
{
    [FilterUsuario]
    public class JogoController : Controller
    {
        EmprestimoContext contexto;
        public JogoController() {
            contexto = new EmprestimoContext();
        }
        [HttpGet]
        public ActionResult AdicionaJogo()
        {
            try
            {
                Jogo Jogo = new Jogo();
                return View(Jogo);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult AdicionaJogo(Jogo Jogo){
            try {
                Jogo.ativo = true;
            contexto.Jogo.Add(Jogo);
            contexto.SaveChanges();
            TempData["sucess"] = "Jogo salvo com sucesso";
            
            }
            catch (Exception e)
            {
                TempData["error"] = "Erro ao salvar o Jogo";
            }
            return RedirectToAction("ListaJogos");
        }

        [HttpGet]
        public ActionResult EditaJogo(int id)
        {
            try { 
            Jogo Jogo = (from c in contexto.Jogo where c.id==id select c).SingleOrDefault();
            return View(Jogo);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult EditaJogo(Jogo Jogo)
        {
            try
            {
                Jogo.ativo = true;
                contexto.Entry(Jogo).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                TempData["sucess"] = "Jogo salvo com sucesso";

            }
            catch (Exception e)
            {
                TempData["error"] = "Erro ao atualizar o cadastro do Jogo!";
            }

        
            return RedirectToAction("ListaJogos");

        }

    
        [HttpPost]
        public ActionResult ExcluiJogo(string idExcluir) {
            try
            {
                int id = int.Parse(idExcluir);
                var jogo = contexto.Jogo.Find(id);
                jogo.ativo = false;
                contexto.Entry(jogo).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                TempData["sucess"] = "Jogo " + jogo.titulo + " foi excluído com sucesso";
            }
            catch (Exception e)
            {
                TempData["error"] = "Erro ao excluir o cadastro do jogo!";
            }

            return RedirectToAction("ListaJogos");
        }

        [HttpGet]
        public ActionResult ListaJogos()
        {
            try
            {
                var Jogos = (from c in contexto.Jogo where c.ativo==true orderby c.titulo select c).ToList();
                return View(Jogos);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
