using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public interface IAmigoRepositorio : IBaseRepositorio<Amigo>
    {        
        List<Amigo> ListarPaginado(Amigo amigo, int paginaAtual, string tipoOrdenacao, System.Func<Amigo, object> campoOrdenacao);
        
        int TotalRegistros(Amigo filtro);
    }
}
