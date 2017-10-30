using Entidades;
using Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Impl
{
    public class AmigoNegocio : BaseNegocio<Amigo>, IAmigoNegocio
    {
        public IAmigoRepositorio _amigoRepositorio { get; set; }

        public AmigoNegocio(IAmigoRepositorio amigoRepositorio)
        {
            _amigoRepositorio = amigoRepositorio;
        }
        
        public List<Amigo> ListarPaginado(Amigo amigo, int paginaAtual, string tipoOrdenacao, Func<Amigo, object> campoOrdenacao)
        {
            try
            {
                return _amigoRepositorio.ListarPaginado(amigo, paginaAtual, tipoOrdenacao, campoOrdenacao);
            }
            catch
            {
                throw;
            }
        }

        public int TotalRegistros(Amigo filtro)
        {
            try
            {
                return _amigoRepositorio.TotalRegistros(filtro);
            }
            catch
            {
                throw;
            }
        }
    }
}
