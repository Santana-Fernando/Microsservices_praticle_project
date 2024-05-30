
using Login.API.Application.ViewModel;
using AutoMapper;
using Login.API.Domain.Entities;

namespace Login.API.Application.Mapping
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<LoginEntry, LoginEntryViewModel>();
        }
    }
}
