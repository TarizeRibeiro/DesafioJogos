using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public interface IUsuarioNegocio : IBaseNegocio<Usuario>
    {
        Usuario Recuperar(string login, string senha);
        ///// <summary>
        ///// Pesquisa de consumo do cliente
        ///// </summary>
        ///// <param name="consumo"></param>
        ///// <returns></returns>
        //List<Usuario> PesquisarConsumoCliente(Usuario consumo);

        ///// <summary>
        ///// Métodorealiza a páginação de uma lista
        ///// </summary>
        ///// <param name="filtro"></param>
        ///// <param name="paginaAtual"></param>
        ///// <param name="tipoOrdenacao"></param>
        ///// <param name="campoOrdenacao"></param>
        ///// <returns></returns>
        //List<Usuario> ListarPaginado(Usuario filtro, int paginaAtual, string tipoOrdenacao, System.Func<Plataforma, object> campoOrdenacao);

        ///// <summary>
        ///// retorna o total de registros do metodo ListarPaginado
        ///// </summary>
        ///// <param name="filtro"></param>
        ///// <returns></returns>
        //int TotalRegistros(Usuario filtro);
    }
}
