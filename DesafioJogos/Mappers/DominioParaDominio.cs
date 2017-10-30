using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioJogos.Mappers
{
    public class DominioParaDominio : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToDomainMappings"; }
        }
        protected override void Configure()
        {
        }
    }
}