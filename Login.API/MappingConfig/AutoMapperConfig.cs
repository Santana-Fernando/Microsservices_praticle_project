using AutoMapper;
using Login.API.Application.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Login.API.MappingConfig
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), 
                typeof(ViewModelToDomainMappingProfile));
        }
    }
}