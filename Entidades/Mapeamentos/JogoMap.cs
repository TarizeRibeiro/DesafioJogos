using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Mapeamentos
{
    public class JogoMap : ClassMap<Jogo>
    {
        public JogoMap()
        {
            Table("JOGO");
            Id(x => x.ID, "ID").GeneratedBy.Identity();
            Map(x => x.Nome, "NOME").Not.Nullable();
            Map(x => x.Plataforma, "PLATAFORMA").Not.Nullable();
            Map(x => x.InEmprestado, "IN_EMPRESTADO").Not.Nullable();
            //Map(x => x.Foto, "FOTO");
        }
    }
}
