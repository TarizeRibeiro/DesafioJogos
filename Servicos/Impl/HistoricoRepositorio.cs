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
    public class HistoricoRepositorio : BaseRepositorio<Historico>, IHistoricoRepositorio
    {
        public HistoricoRepositorio(ISession session) : base(session) { }
        
        public int ListarQuantidadeHistoricoRelacionamentoAmigo(Historico historico)
        {
            return Query()
                .Where(x => (historico.Amigo == null || historico.Amigo.ID == 0) || (historico.Amigo != null && historico.Amigo.ID > 0 && x.Amigo.ID == historico.Amigo.ID))
                .Count();
        }

        public List<Historico> ListarPaginado(Historico historico, int paginaAtual, string tipoOrdenacao, System.Func<Historico, object> campoOrdenacao)
        {
            var retorno = Query()
                .Where(x => ((historico.Jogo == null || historico.Jogo.ID == 0) ||
                (historico.Jogo != null && historico.Jogo.ID > 0 && x.Jogo.ID == historico.Jogo.ID))
                && ((historico.Amigo == null || historico.Amigo.ID == 0) ||
                (historico.Amigo != null && historico.Amigo.ID > 0 && x.Amigo.ID == historico.Amigo.ID)));


            if (tipoOrdenacao == Constantes.CRESCENTE)
            {
                return retorno.OrderBy(campoOrdenacao).Skip(paginaAtual).Take(Constantes.TOTAL_REGISTRO_POR_PAGINAS).ToList();
            }
            else
            {
                return retorno.OrderByDescending(campoOrdenacao).Skip(paginaAtual).Take(Constantes.TOTAL_REGISTRO_POR_PAGINAS).ToList();
            }
        }

        public int TotalRegistros(Historico historico)
        {
            var retorno = Query()
               .Where(x => (historico.Jogo == null || historico.Jogo.ID == 0) || (historico.Jogo != null && historico.Jogo.ID > 0 && x.Jogo.ID != historico.Jogo.ID))
               .Where(x => (historico.Amigo == null || historico.Amigo.ID == 0) || (historico.Amigo != null && historico.Amigo.ID > 0 && x.Amigo.ID != historico.Amigo.ID));
            
            return retorno.Count();
        }
    }
}
