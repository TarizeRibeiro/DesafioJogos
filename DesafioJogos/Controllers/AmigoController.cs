using AutoMapper;
using Comuns;
using Entidades;
using Negocios;
using DesafioJogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesafioJogos.Controllers
{
    public class AmigoController : BaseController
    {
        public IAmigoNegocio _amigoNegocio { get; set; }
        public IHistoricoNegocio _historicoNegocio { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Manter(int id = 0)
        {
            AmigoViewModel model = new AmigoViewModel();
            if (id > 0)
            {
                model = Mapper.Map<Amigo, AmigoViewModel>(_amigoNegocio.ObterPorId(id));
            }

            return View(model);
        }

        public JsonResult ListarPaginado(AmigoViewModel model)
        {
            var paginaAtual = Convert.ToInt32(Request.Params[Constantes.PAGINA_ATUAL]);
            var tipoOrdenacao = Request.Params[Constantes.TIPO_ORDENACAO];
            var campoOrdenacao = Convert.ToInt32(Request.Params[Constantes.CAMPO_ORDENACAO]);
            var colunaParaOrdenacao = RecuperarColunaOrdenacao(campoOrdenacao);

            Amigo filtro = Mapper.Map<AmigoViewModel, Amigo>(model);

            List<Amigo> resultado = _amigoNegocio.ListarPaginado(filtro, paginaAtual, tipoOrdenacao, colunaParaOrdenacao);

            List<AmigoViewModel> listaModel = (resultado == null || !resultado.Any()) ? new List<AmigoViewModel>() : Mapper.Map<List<Amigo>, List<AmigoViewModel>>(resultado);

            var TotalRegistros = _amigoNegocio.TotalRegistros(filtro);

            return RetornaJson(listaModel, TotalRegistros);
        }

        public JsonResult Salvar(AmigoViewModel model)
        {
            string msg = model.Id > 0 ? Mensagens.MI02 : Mensagens.MI01;

            Amigo amigo = Mapper.Map<AmigoViewModel, Amigo>(model);

            _amigoNegocio.Salvar(amigo);

            return Json(msg);
        }

        public JsonResult Excluir(int id)
        {
            var mensagem = Mensagens.MI07;
            var hist = new Historico()
            {
                Amigo = new Amigo()
                {
                    ID = id
                }
            };
            var quantidade = _historicoNegocio.ListarQuantidadeHistoricoRelacionamentoAmigo(hist);
            if (quantidade == 0)
            {
                mensagem = Mensagens.MI03;

                _amigoNegocio.Excluir(id);
            }
            return Json(new { mensagem = mensagem, retorno = quantidade });
        }

        protected Func<Amigo, object> RecuperarColunaOrdenacao(int idColuna)
        {
            var ordenacao = new Func<Amigo, object>(a => a.Nome);
            switch (idColuna)
            {
                case 1:
                    ordenacao = new Func<Amigo, object>(a => string.IsNullOrEmpty(a.Celular) ? string.Empty : a.Celular);
                    break;
                case 2:
                    ordenacao = new Func<Amigo, object>(a => string.IsNullOrEmpty(a.Telefone) ? string.Empty : a.Telefone);
                    break;
                case 3:
                    ordenacao = new Func<Amigo, object>(a => string.IsNullOrEmpty(a.Email) ? string.Empty : a.Email);
                    break;
            }
            return ordenacao;
        }
    }
}