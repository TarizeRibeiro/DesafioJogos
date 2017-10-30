using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public interface IJogoNegocio : IBaseNegocio<Jogo>
    {
        List<Jogo> ListarJogosParaEmprestimo();

        List<Jogo> ListarPaginado(Jogo jogo, int paginaAtual, string tipoOrdenacao, System.Func<Jogo, object> campoOrdenacao);

        int TotalRegistros(Jogo amigo);
    }
}
