using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Mvc;
using Entidades;

namespace DesafioJogos.Autenticacao
{
    public class Authentication
    {
        public void Autorization(ActionExecutingContext filterContext, Usuario usuarioLogado)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                string redirectOnSuccess = filterContext.HttpContext.Request.Url.AbsolutePath;

                filterContext.Controller.TempData["msg"] = "Sistema finalizado por inatividade!";
                
                string redirectUrl = string.Format("?ReturnUrl={0}", redirectOnSuccess);
                string loginUrl = FormsAuthentication.LoginUrl + redirectUrl;
                filterContext.HttpContext.Response.Redirect(loginUrl, true);
            }
        }
    }
}