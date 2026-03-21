using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Usuario.Application;
using Usuario.Domain;

namespace Usuario.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddScoped<ILogin, LoginRepository>();
        services.AddScoped<ILoginServices, LoginServices>();
        services.AddScoped<IUsuarioGet, UsuarioGetRepository>();
        services.AddScoped<IUsuarioGetServices, UsuarioGetServices>();
        services.AddScoped<IUsuarioPost, UsuarioPostRepository>();
        services.AddScoped<IUsuarioPostServices, UsuarioPostServices>();
        return services;
    }
}
