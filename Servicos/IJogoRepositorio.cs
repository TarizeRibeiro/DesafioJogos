using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public interface IJogoRepositorio : IBaseRepositorio<Jogo>
    {
        List<Jogo> ListarJogosParaEmprestimo();

        List<Jogo> ListarPaginado(Jogo jogo, int paginaAtual, string tipoOrdenacao, System.Func<Jogo, object> campoOrdenacao);

        int TotalRegistros(Jogo jogo);
    }
}
