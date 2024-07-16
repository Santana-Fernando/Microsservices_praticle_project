using AutoMapper;
using Login.API.Domain.Entities;
using Login.API.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;

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

        public DbContextOptions<ApplicationDbContext> OptionsDatabaseStub()
        {
            const string defaultConnectionString = "Data Source=localhost;User ID=sa;Password=Fern@nd01331;Database=MicrosservicePraticle;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(defaultConnectionString)
                .Options;

            return options;
        }

        public DbContextOptions<Usuario.get.Infra.Data.Context.ApplicationDbContext> OptionsDatabaseStubUsuarioGet()
        {
            const string defaultConnectionString = "Data Source=localhost;User ID=sa;Password=Fern@nd01331;Database=MicrosservicePraticle;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            var options = new DbContextOptionsBuilder<Usuario.get.Infra.Data.Context.ApplicationDbContext>()
                .UseSqlServer(defaultConnectionString)
                .Options;

            return options;
        }

        /*public MapperConfiguration configIMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UsuariosViewModel, Usuarios>()
                    .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
                    .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.email))
                    .ForMember(dest => dest.password, opt => opt.MapFrom(src => src.password));

                cfg.CreateMap<Usuarios, UsuariosViewModel>()
                    .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                    .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
                    .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.email));

                cfg.CreateMap<UsuariosViewModel, UsuarioView>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
                   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                   .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email));

                cfg.CreateMap<UsuarioView, UsuariosViewModel>()
                    .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.Email));

                cfg.CreateMap<Usuarios, UsuarioView>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email));
            });

            return config;
        }*/
    }
}
