using Comuns;
using Entidades;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Impl
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(ISession session) : base(session) { }

        public Usuario Recuperar(string login, string senha)
        {
            return Listar().Where(x => x.Nome.ToLower().Equals(login.ToLower()) && x.Senha.Equals(senha)).FirstOrDefault();
        }
    }
}
