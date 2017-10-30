using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public interface IHistoricoRepositorio : IBaseRepositorio<Historico>
    {
        int ListarQuantidadeHistoricoRelacionamentoAmigo(Historico historico);

        List<Historico> ListarPaginado(Historico historico, int paginaAtual, string tipoOrdenacao, System.Func<Historico, object> campoOrdenacao);

        int TotalRegistros(Historico historico);
    }
}
