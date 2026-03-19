using AutoMapper;
using Usuario.Domain;

namespace Usuario.Application;

public class ViewModelToDomainMappingProfileLogin: Profile
{
    public ViewModelToDomainMappingProfileLogin()
    {
        CreateMap<LoginEntryViewModel, LoginEntry>();
    }
}
