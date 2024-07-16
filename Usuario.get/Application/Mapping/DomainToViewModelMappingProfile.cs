using AutoMapper;
using Usuario.get.Application.Usuario.ViewModel;
using Usuario.get.Domain.Entidades;

namespace Usuario.get.Application.Mapping
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuarios, UsuariosViewModel>()
            .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
            .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.email))
            .ForMember(dest => dest.password, opt => opt.MapFrom(src => src.password));
        }
    }
}
