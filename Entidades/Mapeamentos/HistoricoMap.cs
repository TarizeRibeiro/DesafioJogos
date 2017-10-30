using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Mapeamentos
{
    public class HistoricoMap : ClassMap<Historico>
    {
        public HistoricoMap()
        {
            Table("HISTORICO");
            Id(x => x.ID, "ID").GeneratedBy.Identity();
            Map(x => x.DataAtualizacao, "DATA_ATUALIZACAO");
            References<Amigo>(x => x.Amigo, "IDAMIGO").Not.Nullable();
            References<Jogo>(x => x.Jogo, "IDJOGO").Not.Nullable();
        }
    }
}