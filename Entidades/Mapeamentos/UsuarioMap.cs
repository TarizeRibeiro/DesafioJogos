using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Mapeamentos
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Table("USUARIO");
            Id(x => x.ID, "ID");
            Map(x => x.Nome, "NOME");
            Map(x => x.Senha, "SENHA");
        }
    }
}
