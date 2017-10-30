using AutoMapper;
using Comuns;
using Comuns.Enum;
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
    public class JogoController : BaseController
    {
        public IJogoNegocio _jogoNegocio { get; set; }

        public ActionResult Index()
        {
            ViewBag.TipoPlataforma = ConverteEnumParaListItem<EnumTipoPlataforma>(string.Empty, false, true, false);
            return View();
        }

        public ActionResult Manter(int id = 0)
        {
            ViewBag.TipoPlataforma = ConverteEnumParaListItem<EnumTipoPlataforma>(string.Empty, true, false, false);
            JogoViewModel model = new JogoViewModel();
            if (id > 0)
            {
                model = Mapper.Map<Jogo, JogoViewModel>(_jogoNegocio.ObterPorId(id));
            }

            return View(model);
        }

        public JsonResult ListarPaginado(JogoViewModel model)
        {
            var paginaAtual = Convert.ToInt32(Request.Params[Constantes.PAGINA_ATUAL]);
            var tipoOrdenacao = Request.Params[Constantes.TIPO_ORDENACAO];
            var campoOrdenacao = Convert.ToInt32(Request.Params[Constantes.CAMPO_ORDENACAO]);
            var colunaParaOrdenacao = RecuperarColunaOrdenacao(campoOrdenacao);

            Jogo filtro = Mapper.Map<JogoViewModel, Jogo>(model);

            List<Jogo> resultado = _jogoNegocio.ListarPaginado(filtro, paginaAtual, tipoOrdenacao, colunaParaOrdenacao);

            List<JogoViewModel> listaModel = (resultado == null || !resultado.Any()) ? new List<JogoViewModel>() : Mapper.Map<List<Jogo>, List<JogoViewModel>>(resultado);

            var TotalRegistros = _jogoNegocio.TotalRegistros(filtro);

            return RetornaJson(listaModel, TotalRegistros);
        }

        public JsonResult Salvar(JogoViewModel model)
        {
            string msg = model.Id > 0 ? Mensagens.MI02 : Mensagens.MI01;

            Jogo jogo = Mapper.Map<JogoViewModel, Jogo>(model);
            jogo.InEmprestado = model.Id == 0 ? false : model.InEmprestado;
            _jogoNegocio.Salvar(jogo);

            return Json(msg);
        }

        public JsonResult Excluir(int id)
        {
            var mensagem = Mensagens.MI07;

            mensagem = Mensagens.MI03;

            _jogoNegocio.Excluir(id);

            return Json(new { mensagem = mensagem });
        }

        protected Func<Jogo, object> RecuperarColunaOrdenacao(int idColuna)
        {
            var ordenacao = new Func<Jogo, object>(a => a.Nome);
            switch (idColuna)
            {
                case 1:
                    ordenacao = new Func<Jogo, object>(a => ((EnumTipoPlataforma)a.Plataforma).GetDescription());
                    break;
            }
            return ordenacao;
        }
    }
}