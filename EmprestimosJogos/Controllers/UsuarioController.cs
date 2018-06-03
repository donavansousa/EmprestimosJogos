using EmprestimosJogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmprestimosJogos.Controllers
{
    public class UsuarioController: Controller
    {

        EmprestimoContext contexto;
        public UsuarioController()
        {
            contexto = new EmprestimoContext();
        }


        [HttpGet]
        public ActionResult Login()
        {
            var u = Session["usuarioLogado"];
            if (u != null)
            {
                return null;
            }
            else
            {
                Login usuario = new Login();
                return View(usuario);
            }
        }

        [HttpPost]
        public ActionResult Logar(Login usuarioLogar)
        {
            var u = Session["usuarioLogado"];
            if (u != null)
            {
                return Redirect(usuarioLogar.ReturnUrl);
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    TempData["error"] = "Por favor preencha todos os campos!";
                    return RedirectToAction("Login");
                }
                else
                {
                    usuarioLogar.senha = SHA1(usuarioLogar.senha);

                    var usuario = (from c in contexto.Usuario where c.login == usuarioLogar.login && c.senha == usuarioLogar.senha select c).FirstOrDefault();
                    if (usuario != null)
                    {
                        if (usuario.ativo == 1)
                        {
                            Session["usuarioLogado"] = usuario.login;
                            return RedirectToAction("Index", "Home");
                        }
                        else {
                            TempData["error"] = "Usuário se encontra Inativo!";
                            return RedirectToAction("Login");
                        }
                    }
                    else
                    {
                        TempData["error"] = "Usuário ou senha Inválido(s)!";
                        return RedirectToAction("Login");
                    }
                }
            }
        }


        public static string SHA1(string value)
        {
            System.Security.Cryptography.SHA1 sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            sha1.ComputeHash(encoding.GetBytes(value));
            return BitConverter.ToString(sha1.Hash).Replace("-", "");
        }


        public ActionResult Logout() {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}