using AutoMapper;
using Usuario.Domain;

namespace Usuario.Application;

public class DomainToViewModelMappingProfileUsuario: Profile
{
    public DomainToViewModelMappingProfileUsuario()
    {
        CreateMap<Usuarios, UsuariosViewModel>()
        .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
        .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.email))
        .ForMember(dest => dest.password, opt => opt.MapFrom(src => src.password));
    }
}

