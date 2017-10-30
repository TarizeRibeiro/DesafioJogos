using Entidades;
using Repositorios;
using System;
using System.Collections.Generic;

namespace Negocios.Impl
{
    public class JogoNegocio : BaseNegocio<Jogo>, IJogoNegocio
    {
        public IJogoRepositorio _jogoRepositorio { get; set; }

        public JogoNegocio(IJogoRepositorio jogoRepositorio)
        {
            _jogoRepositorio = jogoRepositorio;
        }

        public List<Jogo> ListarJogosParaEmprestimo()
        {
            return _jogoRepositorio.ListarJogosParaEmprestimo();
        }

        public List<Jogo> ListarPaginado(Jogo jogo, int paginaAtual, string tipoOrdenacao, Func<Jogo, object> campoOrdenacao)
        {
            try
            {
                return _jogoRepositorio.ListarPaginado(jogo, paginaAtual, tipoOrdenacao, campoOrdenacao);
            }
            catch
            {
                throw;
            }
        }

        public int TotalRegistros(Jogo jogo)
        {
            try
            {
                return _jogoRepositorio.TotalRegistros(jogo);
            }
            catch
            {
                throw;
            }
        }
    }
}
