using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using Usuario.Application;

namespace Usuario.get;

public static class AutoMapperConfig
{
    public static void AddAutoMapperConfiguration(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddAutoMapper(typeof(DomainToViewModelMappingProfileUsuario),
            typeof(DomainToViewMappingProfileUsuario));
    }
}