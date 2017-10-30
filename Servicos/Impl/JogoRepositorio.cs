using Comuns;
using Entidades;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Impl
{
    public class JogoRepositorio : BaseRepositorio<Jogo>, IJogoRepositorio
    {
        public JogoRepositorio(ISession session) : base(session) { }

        public List<Jogo> ListarJogosParaEmprestimo()
        {
            return Listar().Where(x => !x.InEmprestado).ToList();
        }

        public List<Jogo> ListarPaginado(Jogo jogo, int paginaAtual, string tipoOrdenacao, System.Func<Jogo, object> campoOrdenacao)
        {
            var retorno = Listar()
                    .Where(x => x.Nome.ToLower().Equals(jogo.Nome.ToLower()) || string.IsNullOrEmpty(jogo.Nome))
                    .Where(x => (x.Plataforma == jogo.Plataforma) || (jogo.Plataforma == 0));

            if (tipoOrdenacao == Constantes.CRESCENTE)
            {
                return retorno.OrderBy(campoOrdenacao).Skip(paginaAtual).Take(Constantes.TOTAL_REGISTRO_POR_PAGINAS).ToList();
            }
            else
            {
                return retorno.OrderByDescending(campoOrdenacao).Skip(paginaAtual).Take(Constantes.TOTAL_REGISTRO_POR_PAGINAS).ToList();
            }
        }

        public int TotalRegistros(Jogo jogo)
        {
            return Listar()
            .Where(x => string.IsNullOrEmpty(jogo.Nome) || x.Nome.ToLower().Contains(jogo.Nome.ToLower()))
            .Where(x => (jogo.Plataforma == 0) || (x.Plataforma == jogo.Plataforma))
            .Count();
        }

    }
}
