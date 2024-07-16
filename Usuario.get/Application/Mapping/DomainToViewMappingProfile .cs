using AutoMapper;
using Usuario.get.Application.Usuario.ViewModel;
using Usuario.get.Domain.Entidades;

namespace Usuario.get.Application.Mapping
{
    public class DomainToViewMappingProfile : Profile
    {
        public DomainToViewMappingProfile()
        {
            CreateMap<Usuarios, UsuarioView>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email));
        }
    }
}
