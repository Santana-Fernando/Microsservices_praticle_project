using AutoMapper;
using Usuario.Domain;

namespace Usuario.Application;

public class DomainToViewMappingProfileUsuario : Profile
{
    public DomainToViewMappingProfileUsuario()
    {
        CreateMap<Usuarios, UsuarioView>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email));
    }
}
