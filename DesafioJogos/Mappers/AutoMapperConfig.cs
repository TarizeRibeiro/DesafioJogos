using AutoMapper;

namespace DesafioJogos.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DominioParaViewModel>();
                x.AddProfile<ViewModelParaDominio>();
                x.AddProfile<DominioParaDominio>();
            });
        }
    }
}