using AutoMapper;
using Entidades;
using DesafioJogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Comuns;
using Comuns.Enum;

namespace DesafioJogos.Mappers
{
    public class DominioParaViewModel : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<Usuario, UsuarioViewModel>()
               .ForMember(x => x.ID, y => y.MapFrom(z => z.ID))
               .ForMember(x => x.Nome, y => y.MapFrom(z => string.IsNullOrEmpty(z.Nome) ? string.Empty : z.Nome))
               .ForMember(x => x.Senha, y => y.MapFrom(z => string.IsNullOrEmpty(z.Senha) ? string.Empty : z.Senha));


            Mapper.CreateMap<Amigo, AmigoViewModel>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.ID))
               .ForMember(x => x.Nome, y => y.MapFrom(z => string.IsNullOrEmpty(z.Nome) ? string.Empty : z.Nome))
               .ForMember(x => x.Email, y => y.MapFrom(z => string.IsNullOrEmpty(z.Email) ? string.Empty : z.Email))
               .ForMember(x => x.Celular, y => y.MapFrom(z => string.IsNullOrEmpty(z.Celular) ? string.Empty : z.Celular))
               .ForMember(x => x.Telefone, y => y.MapFrom(z => string.IsNullOrEmpty(z.Telefone) ? string.Empty : z.Telefone));

            Mapper.CreateMap<Jogo, JogoViewModel>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.ID))
               .ForMember(x => x.Nome, y => y.MapFrom(z => string.IsNullOrEmpty(z.Nome) ? string.Empty : z.Nome))
               .ForMember(x => x.Plataforma, y => y.MapFrom(z => z.Plataforma))
               .ForMember(x => x.InEmprestado, y => y.MapFrom(z => z.InEmprestado))
               .ForMember(x => x.PlataformaDescricao, y => y.MapFrom(z => ((EnumTipoPlataforma)z.Plataforma).GetDescription()))
               .ForMember(x => x.EmprestadoFormatado, y => y.MapFrom(z => z.InEmprestado ? EnumSimNao.SIM.GetDescription() : EnumSimNao.NAO.GetDescription()));

            Mapper.CreateMap<Historico, ControleEmprestimoViewModel>()
                .ForMember(x => x.DataAtualizacao, y => y.MapFrom(z => z.DataAtualizacao.ToShortDateString()))
                .ForMember(x => x.Jogo, y => y.MapFrom(z => z.Jogo == null ? new JogoViewModel() : new JogoViewModel()
                {
                    Id = z.Jogo.ID,
                    Nome = z.Jogo.Nome,
                    Plataforma = z.Jogo.Plataforma,
                    PlataformaDescricao = ((EnumTipoPlataforma)z.Jogo.Plataforma).GetDescription()
                }))
                .ForMember(x => x.Amigo, y => y.MapFrom(z => z.Amigo == null ? new AmigoViewModel() : new AmigoViewModel()
                {
                    Id = z.Amigo.ID,
                    Nome = z.Amigo.Nome,
                    Celular = string.IsNullOrEmpty(z.Amigo.Celular) ? string.Empty : z.Amigo.Celular,
                    Telefone = string.IsNullOrEmpty(z.Amigo.Telefone) ? string.Empty : z.Amigo.Telefone,
                    Email = string.IsNullOrEmpty(z.Amigo.Email) ? string.Empty : z.Amigo.Email
                }));
        }
    }
}