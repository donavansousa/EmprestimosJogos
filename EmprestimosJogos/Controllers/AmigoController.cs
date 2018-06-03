using EmprestimosJogos.Filters;
using EmprestimosJogos.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace EmprestimosJogos.Controllers
{
    [FilterUsuario]
    public class AmigoController : Controller
    {
        EmprestimoContext contexto;
        public AmigoController() {
            contexto = new EmprestimoContext();
        }
        [HttpGet]
        public ActionResult AdicionaAmigo()
        {
            try
            {
                Amigo Amigo = new Amigo();
                return View(Amigo);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult AdicionaAmigo(Amigo Amigo){
            try {
                var amigoExistente = (from c in contexto.Amigo where c.cpf == Amigo.cpf select c).FirstOrDefault();
                if (amigoExistente == null)
                {
                    Amigo.ativo = true;
                    contexto.Amigo.Add(Amigo);
                    contexto.SaveChanges();
                    TempData["sucess"] = "Amigo salvo com sucesso";
                }
                else {
                    TempData["error"] = "Já existe um amigo com este cpf";
                    return View(Amigo);
                }
            }
            catch (Exception e)
            {
                TempData["error"] = "Erro ao salvar o amigo";
            }
            return RedirectToAction("ListaAmigos");
        }

        [HttpGet]
        public ActionResult EditaAmigo(int id)
        {
            try { 
            Amigo Amigo = (from c in contexto.Amigo where c.id==id select c).SingleOrDefault();
            return View(Amigo);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult EditaAmigo(Amigo Amigo)
        {
            try
            {
                var amigoExistente = (from c in contexto.Amigo where c.cpf == Amigo.cpf && c.id!=Amigo.id select c).FirstOrDefault();
                if (amigoExistente == null)
                {
                    Amigo.ativo = true;
                    contexto.Entry(Amigo).State = System.Data.Entity.EntityState.Modified;
                    contexto.SaveChanges();
                    TempData["sucess"] = "Amigo salvo com sucesso";
                }
                else {
                    TempData["error"] = "Já existe um amigo com este cpf";
                    return View(Amigo);
                }
            }
            catch (Exception e)
            {
                TempData["error"] = "Erro ao atualizar o cadastro do Amigo!";
            }

        
            return RedirectToAction("ListaAmigos");

        }

        [HttpPost]
        public ActionResult ExcluiAmigo(string idExcluir) {
            try {
                int id = int.Parse(idExcluir);
                var amigo = contexto.Amigo.Find(id);
                amigo.ativo = false;
                contexto.Entry(amigo).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                TempData["sucess"] = "Amigo " + amigo.nome + " foi excluído com sucesso";
            }
            catch (Exception e)
            {
                TempData["error"] = "Erro ao excluir o cadastro do Amigo!";
            }

            return RedirectToAction("ListaAmigos");
        }

        [HttpGet]
        public ActionResult ListaAmigos()
        {
            try
            {
                var amigos = (from c in contexto.Amigo where c.ativo==true orderby c.nome select c).ToList();
                return View(amigos);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
