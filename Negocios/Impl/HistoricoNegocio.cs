using Entidades;
using Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Impl
{
    public class HistoricoNegocio : BaseNegocio<Historico>, IHistoricoNegocio
    {
        public IHistoricoRepositorio _historicoRepositorio { get; set; }

        public HistoricoNegocio(IHistoricoRepositorio historicoRepositorio)
        {
            _historicoRepositorio = historicoRepositorio;
        }

        public int ListarQuantidadeHistoricoRelacionamentoAmigo(Historico historico)
        {
            try
            {
                return _historicoRepositorio.ListarQuantidadeHistoricoRelacionamentoAmigo(historico);
            }
            catch
            {
                throw;
            }
        }

        public List<Historico> ListarPaginado(Historico filtro, int paginaAtual, string tipoOrdenacao, System.Func<Historico, object> campoOrdenacao)
        {
            try
            {
                return _historicoRepositorio.ListarPaginado(filtro, paginaAtual, tipoOrdenacao, campoOrdenacao);
            }
            catch
            {
                throw;
            }
        }

        public int TotalRegistros(Historico filtro)
        {
            try
            {
                return _historicoRepositorio.TotalRegistros(filtro);
            }
            catch
            {
                throw;
            }
        }
    }
}
