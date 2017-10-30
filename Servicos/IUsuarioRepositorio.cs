using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario>
    {
        Usuario Recuperar(string login, string senha);
    }
}
