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
    public class ControleEmprestimoController : BaseController
    {
        public IJogoNegocio _jogoNegocio { get; set; }
        public IAmigoNegocio _amigoNegocio { get; set; }
        public IHistoricoNegocio _historicoNegocio { get; set; }

        public ActionResult Index()
        {
            CargaJogosAmigos(0);
            ControleEmprestimoViewModel model = new ControleEmprestimoViewModel();
            model.Amigo = new AmigoViewModel();
            model.Jogo = new JogoViewModel();
            return View(model);
        }

        public void CargaJogosAmigos(int id, bool isManter = false)
        {
            List<Jogo> valuesJogos = isManter ? _jogoNegocio.ListarJogosParaEmprestimo() : _jogoNegocio.Listar().ToList();
            List<Amigo> valuesAmigos = _amigoNegocio.Listar().ToList();

            if (id > 0)
            {
                ViewBag.Jogos = ConverteListItem<Jogo>(valuesJogos, "Nome", "ID", id.ToString(), true, false);
                ViewBag.Amigos = ConverteListItem<Amigo>(valuesAmigos, "Nome", "ID", id.ToString(), true, false);
            }
            else
            {
                ViewBag.Jogos = ConverteListItem<Jogo>(valuesJogos, "Nome", "ID", null, isManter, !isManter);
                ViewBag.Amigos = ConverteListItem<Amigo>(valuesAmigos, "Nome", "ID", null, isManter, !isManter);
            }
        }

        public ActionResult Manter(int id = 0)
        {
            CargaJogosAmigos(id, true);

            ControleEmprestimoViewModel model = new ControleEmprestimoViewModel();
            if (id > 0)
            {
                model = Mapper.Map<Historico, ControleEmprestimoViewModel>(_historicoNegocio.ObterPorId(id));
            }

            return View(model);
        }

        public JsonResult ListarPaginado(ControleEmprestimoViewModel model)
        {
            var paginaAtual = Convert.ToInt32(Request.Params[Constantes.PAGINA_ATUAL]);
            var tipoOrdenacao = Request.Params[Constantes.TIPO_ORDENACAO];
            var campoOrdenacao = Convert.ToInt32(Request.Params[Constantes.CAMPO_ORDENACAO]);
            var colunaParaOrdenacao = RecuperarColunaOrdenacao(campoOrdenacao);

            Historico filtro = Mapper.Map<ControleEmprestimoViewModel, Historico>(model);

            List<Historico> resultado = _historicoNegocio.ListarPaginado(filtro, paginaAtual, tipoOrdenacao, colunaParaOrdenacao);

            List<ControleEmprestimoViewModel> listaModel = (resultado == null || !resultado.Any()) ? new List<ControleEmprestimoViewModel>() : Mapper.Map<List<Historico>, List<ControleEmprestimoViewModel>>(resultado);

            var TotalRegistros = _historicoNegocio.TotalRegistros(filtro);

            return RetornaJson(listaModel, TotalRegistros);
        }

        public JsonResult Salvar(ControleEmprestimoViewModel model)
        {
            string msg = model.Id > 0 ? Mensagens.MI02 : Mensagens.MI01;

            Historico hist = Mapper.Map<ControleEmprestimoViewModel, Historico>(model);
            hist.DataAtualizacao = DateTime.Now;
            _historicoNegocio.Salvar(hist);

            Jogo jogo = _jogoNegocio.ObterPorId(hist.Jogo.ID);
            jogo.InEmprestado = true;
            _jogoNegocio.Salvar(jogo);

            return Json(msg);
        }

        public JsonResult Excluir(int id)
        {
            var mensagem = Mensagens.MI03;
            var hist = _historicoNegocio.ObterPorId(id);

            Jogo jogo = _jogoNegocio.ObterPorId(hist.Jogo.ID);
            jogo.InEmprestado = false;
            _jogoNegocio.Salvar(jogo);

            _historicoNegocio.Excluir(id);

            return Json(new { mensagem = mensagem });
        }

        protected Func<Historico, object> RecuperarColunaOrdenacao(int idColuna)
        {
            var ordenacao = new Func<Historico, object>(a => a.Amigo.Nome);
            switch (idColuna)
            {
                case 1:
                    ordenacao = new Func<Historico, object>(a => a.Jogo.Nome);
                    break;
                case 2:
                    ordenacao = new Func<Historico, object>(a => a.DataAtualizacao.ToShortDateString());
                    break;
            }
            return ordenacao;
        }
    }
}
