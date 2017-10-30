using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Mapeamentos
{
    public class AmigoMap : ClassMap<Amigo>
    {
        public AmigoMap() {
            Table("AMIGO");
            Id(x => x.ID, "ID").GeneratedBy.Identity();
            Map(x => x.Nome, "NOME").Not.Nullable();
            Map(x => x.Telefone, "TELEFONE");
            Map(x => x.Celular, "CELULAR");
            Map(x => x.Email, "EMAIL");
        }
    }
}
