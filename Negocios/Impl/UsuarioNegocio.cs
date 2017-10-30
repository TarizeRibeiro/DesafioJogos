using Entidades;
using Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Impl
{
    public class UsuarioNegocio : BaseNegocio<Usuario>, IUsuarioNegocio
    {
        public IUsuarioRepositorio _usuarioRepositorio { get; set; }

        public UsuarioNegocio(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        
        public Usuario Recuperar(string login, string senha)
        {
            return _usuarioRepositorio.Recuperar(login, senha);
        }
    }
}
