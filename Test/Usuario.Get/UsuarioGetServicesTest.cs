using AutoMapper;
using Tests.Helper;
using Usuario.get.Application.Services;
using Usuario.get.Infra.Data.Context;
using Usuario.get.Infra.Data.Repository;

namespace Test.Usuario.Get
{
    public class UsuarioGetServicesTest
    {
        private readonly UsuarioGetServices _usuariosService;
        private readonly UsuarioGetRepository _usuariosRepository;
        private readonly IMapper _mapperMock;

        public UsuarioGetServicesTest()
        {
            _usuariosRepository = UsuariosRepositoryStub();
            AppSettingsMock appSettingsMock = new AppSettingsMock();
            var config = appSettingsMock.configIMapper();
            _mapperMock = config.CreateMapper();

            _usuariosService = new UsuarioGetServices(_usuariosRepository, _mapperMock);
        }

        private UsuarioGetRepository UsuariosRepositoryStub()
        {
            AppSettingsMock appSettingsMock = new AppSettingsMock();
            var options = appSettingsMock.OptionsDatabaseStub<ApplicationDbContext>();
            var dbContext = new ApplicationDbContext(options);
            return new UsuarioGetRepository(dbContext);
        }
    }
}
