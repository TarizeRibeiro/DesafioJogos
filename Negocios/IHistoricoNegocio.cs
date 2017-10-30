using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public interface IHistoricoNegocio : IBaseNegocio<Historico>
    {
        int ListarQuantidadeHistoricoRelacionamentoAmigo(Historico historico);

        List<Historico> ListarPaginado(Historico filtro, int paginaAtual, string tipoOrdenacao, System.Func<Historico, object> campoOrdenacao);
        
        int TotalRegistros(Historico filtro);
    }
}
