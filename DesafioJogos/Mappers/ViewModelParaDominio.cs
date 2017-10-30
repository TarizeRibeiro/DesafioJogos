using AutoMapper;
using Entidades;
using DesafioJogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioJogos.Mappers
{
    public class ViewModelParaDominio : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<UsuarioViewModel, Usuario>()
               .ForMember(x => x.ID, y => y.MapFrom(z => z.ID))
               .ForMember(x => x.Nome, y => y.MapFrom(z => string.IsNullOrEmpty(z.Nome) ? string.Empty : z.Nome))
               .ForMember(x => x.Senha, y => y.MapFrom(z => string.IsNullOrEmpty(z.Senha) ? string.Empty : z.Senha));

            Mapper.CreateMap<AmigoViewModel, Amigo>()
               .ForMember(x => x.ID, y => y.MapFrom(z => z.Id))
               .ForMember(x => x.Nome, y => y.MapFrom(z => string.IsNullOrEmpty(z.Nome) ? string.Empty : z.Nome))
               .ForMember(x => x.Email, y => y.MapFrom(z => string.IsNullOrEmpty(z.Email) ? string.Empty : z.Email))
               .ForMember(x => x.Celular, y => y.MapFrom(z => string.IsNullOrEmpty(z.Celular) ? string.Empty : z.Celular))
               .ForMember(x => x.Telefone, y => y.MapFrom(z => string.IsNullOrEmpty(z.Telefone) ? string.Empty : z.Telefone));

            Mapper.CreateMap<JogoViewModel, Jogo>()
               .ForMember(x => x.ID, y => y.MapFrom(z => z.Id))
               .ForMember(x => x.Nome, y => y.MapFrom(z => string.IsNullOrEmpty(z.Nome) ? string.Empty : z.Nome))
               .ForMember(x => x.Plataforma, y => y.MapFrom(z => !z.Plataforma.HasValue ? 0 : z.Plataforma))
               .ForMember(x => x.InEmprestado, y => y.MapFrom(z => !z.InEmprestado));

            Mapper.CreateMap<ControleEmprestimoViewModel, Historico>()
                .ForMember(x => x.DataAtualizacao, y => y.MapFrom(z => z.DataAtualizacao))
                .ForMember(x => x.Amigo, y => y.MapFrom(z => z.Amigo == null ? new Amigo() : new Amigo()
                {
                    ID = z.Amigo.Id,
                    Nome = z.Amigo.Nome,
                    Celular = z.Amigo.Celular,
                    Telefone = z.Amigo.Telefone,
                    Email = z.Amigo.Email
                }))
                .ForMember(x => x.Jogo, y => y.MapFrom(z => z.Jogo == null ? new Jogo() : new Jogo()
                {
                    ID = z.Jogo.Id,
                    Nome = z.Jogo.Nome,
                    Plataforma = z.Jogo.Plataforma.HasValue ? z.Jogo.Plataforma.Value : 0
                }));
        }
    }
}