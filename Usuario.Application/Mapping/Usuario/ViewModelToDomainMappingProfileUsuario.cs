using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuario.Domain;

namespace Usuario.Application;

public class ViewModelToDomainMappingProfileUsuario : Profile
{
    public ViewModelToDomainMappingProfileUsuario()
    {
        CreateMap<UsuariosViewModel, Usuarios>()
        .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
        .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.email))
        .ForMember(dest => dest.password, opt => opt.MapFrom(src => src.password));
    }
}