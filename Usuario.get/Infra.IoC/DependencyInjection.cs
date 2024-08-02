using Usuario.get.Infra.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Usuario.get.Domain.Interfaces;
using Usuario.get.Infra.Data.Repository;
using Usuario.get.Application.Usuario.Interfaces;
using Usuario.get.Application.Services;

namespace Usuario.get.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DockerConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<IUsuario, UsuarioGetRepository>();
            services.AddScoped<IUsuarioGetServices, UsuarioGetServices>();
            return services;
        }
    }
}
