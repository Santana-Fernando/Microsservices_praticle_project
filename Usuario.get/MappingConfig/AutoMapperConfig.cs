using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using Usuario.get.Application.Mapping;

namespace Usuario.get.Application.MappingConfig
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile),
                typeof(DomainToViewMappingProfile));
        }
    }
}