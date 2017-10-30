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
    public class AmigoRepositorio : BaseRepositorio<Amigo>, IAmigoRepositorio
    {
        public AmigoRepositorio(ISession session) : base(session) { }

        public List<Amigo> ListarPaginado(Amigo amigo, int paginaAtual, string tipoOrdenacao, System.Func<Amigo, object> campoOrdenacao)
        {
            var retorno = Listar()
                    .Where(x => x.Nome.ToLower().Equals(amigo.Nome.ToLower()) || string.IsNullOrEmpty(amigo.Nome));

            if (tipoOrdenacao == Constantes.CRESCENTE)
            {
                return retorno.OrderBy(campoOrdenacao).Skip(paginaAtual).Take(Constantes.TOTAL_REGISTRO_POR_PAGINAS).ToList();
            }
            else
            {
                return retorno.OrderByDescending(campoOrdenacao).Skip(paginaAtual).Take(Constantes.TOTAL_REGISTRO_POR_PAGINAS).ToList();
            }
        }

        public int TotalRegistros(Amigo amigo)
        {
            return Listar()
                    .Where(x => x.Nome.ToLower().Equals(amigo.Nome.ToLower()) || string.IsNullOrEmpty(amigo.Nome))
                    .Count();
        }

    }
}
