using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using Usuario.Application;

namespace Login.API.MappingConfig
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfileLogin), 
                typeof(ViewModelToDomainMappingProfileLogin));
        }
    }
}