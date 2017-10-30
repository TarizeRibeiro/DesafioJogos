using Entidades;
using Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Impl
{
    public class ControleQuartoNegocio : BaseNegocio<ControleQuarto>, IControleQuartoNegocio
    {
        public IControleQuartoRepositorio _controleQuartoRepositorio { get; set; }

        public ControleQuartoNegocio(IControleQuartoRepositorio ControleQuartoRepositorio)
        {
            _controleQuartoRepositorio = ControleQuartoRepositorio;
        }
    }
}
