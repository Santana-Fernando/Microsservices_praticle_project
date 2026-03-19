using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Usuario.Application;
using Usuario.Domain;
using Usuario.get.Infra.Data.Repository;
using Usuario.Infra;

namespace Usuario.Infra;

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

        services.AddScoped<ILogin, LoginRepository>();
        services.AddScoped<ILoginServices, LoginServices>();
        services.AddScoped<IUsuario, UsuarioGetRepository>();
        services.AddScoped<IUsuarioGetServices, UsuarioGetServices>();
        return services;
    }
}
