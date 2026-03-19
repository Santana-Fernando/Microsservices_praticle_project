
using AutoMapper;
using Usuario.Domain;

namespace Usuario.Application;
public class DomainToViewModelMappingProfileLogin: Profile
{
    public DomainToViewModelMappingProfileLogin()
    {
        CreateMap<LoginEntry, LoginEntryViewModel>();
    }
}

