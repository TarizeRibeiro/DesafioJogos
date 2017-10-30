using Comuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using System.Web.Routing;
using Negocios;

namespace DesafioJogos.Controllers
{
    public class BaseController : Controller
    {
        public IUsuarioNegocio UsuarioNegocio { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }
        
        private void Autorization(RequestContext filterContext, Usuario usuarioLogado)
        {
            string loginUrl = Url.Content("~") + "Home/Login";
            string urlAtual = filterContext.HttpContext.Request.Url.AbsolutePath;

            #region Paginas sem necessidade de acesso

            if ((urlAtual.Equals("/")
                    || urlAtual.ToLower().Contains("/home/login")
                    || urlAtual.ToLower().Contains("/home/manter")))
            {
                return;
            }
            #endregion Paginas sem necessidade de acesso
            
            if (usuarioLogado == null)
            {
                filterContext.HttpContext.Response.Redirect(loginUrl, true);
            }
            else
            {
                if (!ValidarAcesso(urlAtual, usuarioLogado))
                {
                    filterContext.HttpContext.Response.Redirect(loginUrl, true);
                }
            }
        }

        private bool ValidarAcesso(string urlAtual, Usuario usuarioLogado)
        {
            bool retorno = false;

            List<string> acesso = new List<string>() {
                        "/Jogo/Index", "/Jogo/Manter",
                        "/Amigo/Index", "/Amigo/Manter",
                        "/ControleEmprestimo/Index", "/ControleEmprestimo/Manter"
                    };


            return retorno;
        }

        public JsonResult RetornaJson<T>(List<T> lista, int TotalRegistros)
        {
            try
            {
                return Json(new
                {
                    sEcho = Request.Params["sEcho"].ToString(),
                    iTotalRecords = lista.Count(),
                    iTotalDisplayRecords = TotalRegistros,
                    ValidateRequest = false,
                    aaData = lista
                }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                throw;
            }
        }

        public List<SelectListItem> ConverteListItem<T>(List<T> listaEntidade, string campoTexto, string campoValor, string selecionado = "0", bool selecione = true, bool todos = false)
        {
            try
            {
                var itens = new List<SelectListItem>();

                if (selecione)
                    itens.Add(new SelectListItem { Text = Constantes.SELECIONE, Value = "" });
                else if (todos)
                    itens.Add(new SelectListItem { Text = Constantes.TODOS, Value = "" });

                Type tipo = typeof(T);
                string[] propriedades = campoTexto.Split('.');

                if (listaEntidade != null)
                {
                    foreach (var item in listaEntidade)
                    {
                        var propriedadeText = tipo.GetProperty(campoTexto);
                        var texto = String.Empty;

                        if (propriedades.Length > 1)
                        {
                            Type tipoPropriedade = tipo.GetProperty(propriedades[0]).GetValue(item).GetType();
                            propriedadeText = tipoPropriedade.GetProperty(propriedades[1]);
                            texto = propriedadeText.GetValue(item.GetType().GetProperty(propriedades[0]).GetValue(item)).ToString();
                        }
                        else
                            texto = propriedadeText.GetValue(item).ToString();

                        itens.Add(new SelectListItem
                        {
                            Value = tipo.GetProperty(campoValor).GetValue(item).ToString(),
                            Text = texto,
                            Selected = selecionado == tipo.GetProperty(campoValor).GetValue(item).ToString()
                        });
                    }
                }

                return itens;
            }
            catch
            {
                throw;
            }
        }
        
        public List<SelectListItem> ConverteEnumParaListItem<T>(string valorSelecionado, bool selecione, bool todos = false, bool valorChar = false)
        {
            try
            {
                List<SelectListItem> itens = new List<SelectListItem>();

                var valoresEnum = Enum.GetValues(typeof(T));

                foreach (var valor in valoresEnum)
                {
                    var valorConvertido = valorChar ? Convert.ToChar(valor).ToString() : ((int)valor).ToString();
                    itens.Add(new SelectListItem { Text = ((Enum)valor).GetDescription(), Value = valorConvertido, Selected = valorConvertido == valorSelecionado });


                }

                itens = itens.OrderBy(x => x.Text).ToList();

                if (selecione)
                {
                    itens.Insert(0, new SelectListItem { Text = Constantes.SELECIONE, Value = "" });
                }
                if (todos)
                {
                    itens.Insert(0, new SelectListItem { Text = Constantes.TODOS, Value = "" });
                }

                return itens;
            }
            catch
            {
                throw;
            }
        }
    }
}
