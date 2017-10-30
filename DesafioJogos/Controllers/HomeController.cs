using Entidades;
using Negocios;
using DesafioJogos.Autenticacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DesafioJogos.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string login = null, string senha = null)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(senha))
            {
                return View();
            }

            Usuario usuarioLogado = UsuarioNegocio.Recuperar(login, senha);

            if (usuarioLogado == null || usuarioLogado.ID == 0)
            {
                return View();
            }
            else
            {
                HttpCookie myCookie = new HttpCookie("UserId");
                myCookie.Value = usuarioLogado.ID.ToString();
                myCookie.Expires = DateTime.Now.AddMinutes(30);
                Response.Cookies.Add(myCookie);

                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Deslogar()
        {
            return RedirectToAction("Login", "Home");
        }
    }
}
