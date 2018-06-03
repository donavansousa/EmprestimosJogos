using EmprestimosJogos.Filters;
using EmprestimosJogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EmprestimosEmprestimos.Controllers
{
    [FilterUsuario]
    public class EmprestimoController : Controller
    {
        EmprestimoContext contexto;
        public EmprestimoController() {
            contexto = new EmprestimoContext();
        }
        [HttpGet]
        public ActionResult AdicionaEmprestimo()
        {
            try
            {
                ViewData["idAmigo"] = new SelectList((from c in contexto.Amigo where c.ativo == true orderby c.nome select c).ToList(), "id", "nome");
                var emprestados = (from c in contexto.emprestimo_jogo where c.status == "e" select c.Jogo).ToList();
                var jogos = (from c in contexto.Jogo where c.ativo == true orderby c.titulo select c).ToList();
                var jogosDisponiveis = jogos.Except(emprestados).ToList();
                ViewData["idJogo"] = new SelectList(jogosDisponiveis, "id", "titulo");
                emprestimo_jogo Emprestimo = new emprestimo_jogo();
                return View(Emprestimo);
            }
            catch (Exception e)
            {
                return RedirectToAction("ListaEmprestimos");
            }
        }

        [HttpPost]
        public ActionResult AdicionaEmprestimo(emprestimo_jogo Emprestimo){
            try {
                Emprestimo.data = DateTime.Now;
                Emprestimo.status = "e";
                contexto.emprestimo_jogo.Add(Emprestimo);
                contexto.SaveChanges();
                TempData["sucess"] = "Emprestimo salvo com sucesso";
            
            }
            catch (Exception e)
            {
                TempData["error"] = "Erro ao salvar o Emprestimo";
            }
            return RedirectToAction("ListaEmprestimos");
        }

        [HttpGet]
        public ActionResult EditaEmprestimo(int id)
        {
            try {
                emprestimo_jogo Emprestimo = (from c in contexto.emprestimo_jogo where c.id == id select c).SingleOrDefault();
                ViewData["idAmigo"] = new SelectList((from c in contexto.Amigo where c.ativo==true orderby c.nome select c).ToList(), "id", "nome",Emprestimo.idAmigo);
                var emprestados = (from c in contexto.emprestimo_jogo where c.status == "e" && c.idJogo!=Emprestimo.idJogo select c.Jogo).ToList();
                var jogos = (from c in contexto.Jogo where c.ativo == true orderby c.titulo select c).ToList();
                var jogosDisponiveis = jogos.Except(emprestados).ToList();
                ViewData["idJogo"] = new SelectList(jogosDisponiveis, "id", "titulo",Emprestimo.idJogo);
                
            return View(Emprestimo);
            }
            catch (Exception e)
            {
                return RedirectToAction("ListaEmprestimos");
            }
        }

        [HttpPost]
        public ActionResult EditaEmprestimo(emprestimo_jogo Emprestimo)
        {
            try
            {
                Emprestimo.status = "e";
                contexto.Entry(Emprestimo).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                TempData["sucess"] = "Emprestimo atualizado com sucesso";

            }
            catch (Exception e)
            {
                TempData["error"] = "Erro ao atualizar o cadastro do Emprestimo!";
            }

        
            return RedirectToAction("ListaEmprestimos");

        }

        [HttpPost]
        public ActionResult ExcluiEmprestimo(string idExcluir) {

            try {
                int id = int.Parse(idExcluir);
                var emprestimo = contexto.emprestimo_jogo.Find(id);
                string amigo = emprestimo.Amigo.nome;
                string tituloJogo = emprestimo.Jogo.titulo;
                contexto.emprestimo_jogo.Remove(emprestimo);
                contexto.SaveChanges();
                TempData["sucess"] = "Emprestimo " + amigo  + " - "+ tituloJogo + " foi excluído com sucesso";
            }
            catch (Exception e)
            {
                TempData["error"] = "Erro ao excluir o cadastro do Emprestimo!";
            }

            return RedirectToAction("ListaEmprestimos");
        }

        [HttpPost]
        public ActionResult DevolverEmprestimo(string idDevolucao)
        {

            try
            {
                int id = int.Parse(idDevolucao);
                var emprestimo = contexto.emprestimo_jogo.Find(id);
                emprestimo.status = "d";
                contexto.Entry(emprestimo).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                TempData["sucess"] = "Emprestimo " + emprestimo.Amigo.nome + " - " + emprestimo.Jogo.titulo + " foi devolvido com sucesso";
            }
            catch (Exception e)
            {
                TempData["error"] = "Erro ao excluir o cadastro do Emprestimo!";
            }

            return RedirectToAction("ListaEmprestimos");
        }

        [HttpGet]
        public ActionResult ListaEmprestimos()
        {
            try
            {
                var Emprestimos = (from c in contexto.emprestimo_jogo where c.status== "e" orderby c.data descending select c).ToList();
                return View(Emprestimos);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult HistoricoEmprestimos()
        {
            try
            {
                var Emprestimos = (from c in contexto.emprestimo_jogo orderby c.data descending select c).ToList();
                return View(Emprestimos);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
