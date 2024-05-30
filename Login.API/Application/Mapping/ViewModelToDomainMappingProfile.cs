
using Login.API.Application.ViewModel;
using AutoMapper;
using Login.API.Domain.Entities;

namespace Login.API.Application.Mapping
{
    public class ViewModelToDomainMappingProfile: Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<LoginEntryViewModel, LoginEntry>();
        }
    }
}
