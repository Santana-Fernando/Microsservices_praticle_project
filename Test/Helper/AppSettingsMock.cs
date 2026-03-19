using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Usuario.Application;
using Moq;
using Usuario.Domain;
using AutoMapper.Internal;

namespace Tests.Helper
{
    public class AppSettingsMock
    {
        public Mock<IConfiguration> configurationMockStub()
        {
            const string jwtKey = "ChaveSuperSecreta123";
            const string jwtIssuer = "FERNANDO";
            const string jwtAudience = "AplicacaoWebAPI";
            const int jwtExpirationInMinutes = 30;

            var configurationMock = new Mock<IConfiguration>();

            configurationMock.Setup(x => x["Jwt:Key"]).Returns(jwtKey);
            configurationMock.Setup(x => x["Jwt:Issuer"]).Returns(jwtIssuer);
            configurationMock.Setup(x => x["Jwt:Audience"]).Returns(jwtAudience);
            configurationMock.Setup(x => x["Jwt:ExpirationInMinutes"]).Returns(jwtExpirationInMinutes.ToString());

            return configurationMock;
        }

        public DbContextOptions<TContext> OptionsDatabaseStub<TContext>() where TContext : DbContext
        {
            const string defaultConnectionString = "Data Source=localhost;User ID=sa;Password=Fern@nd01331;Database=MicrosservicePraticle;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            var options = new DbContextOptionsBuilder<TContext>()
                .UseSqlServer(defaultConnectionString)
                .Options;

            return options;
        }

        public MapperConfiguration configIMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.Internal().MethodMappingEnabled = false;

                cfg.CreateMap<UsuariosViewModel, Usuarios>();
                cfg.CreateMap<Usuarios, UsuariosViewModel>();
                cfg.CreateMap<UsuariosViewModel, UsuarioView>();
                cfg.CreateMap<UsuarioView, UsuariosViewModel>();
                cfg.CreateMap<Usuarios, UsuarioView>();
            });

            return config;
        }
    }
}
