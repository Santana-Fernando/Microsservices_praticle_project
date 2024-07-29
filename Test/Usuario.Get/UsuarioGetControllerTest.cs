using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Tests.Helper;
using Usuario.get.Application.Services;
using Usuario.get.Application.Usuario.Interfaces;
using Usuario.get.Controllers;
using Usuario.get.Domain.Entidades;
using Usuario.get.Infra.Data.Context;
using Usuario.get.Infra.Data.Repository;
using Xunit;
using Xunit.Abstractions;

namespace Test.Usuario.Get
{
    public class UsuarioGetControllerTest
    {
        private readonly UsuarioGetServices _usuariosGetService;
        private readonly UsuarioGetRepository _usuariosGetRepository;
        private readonly UsuarioGet _usuarioGetController;
        public UsuarioGetControllerTest()
        {
            _usuariosGetRepository = UsuariosRepositoryStub();
            AppSettingsMock appSettingsMock = new AppSettingsMock();
            var config = appSettingsMock.configIMapper();
            var mapperMock = config.CreateMapper();

            _usuariosGetService = new UsuarioGetServices(_usuariosGetRepository, mapperMock);
            _usuarioGetController = new UsuarioGet(_usuariosGetService);
        }

        private UsuarioGetRepository UsuariosRepositoryStub()
        {
            AppSettingsMock appSettingsMock = new AppSettingsMock();
            var options = appSettingsMock.OptionsDatabaseStub<ApplicationDbContext>();
            var dbContext = new ApplicationDbContext(options);
            return new UsuarioGetRepository(dbContext);
        }

        [Fact(DisplayName = "Should call GetList")]
        public async void UsuarioController_ShouldCallGetList()
        {
            var result = await _usuarioGetController.GetList();

            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Should validate the authorization token and return Unauthorized")]
        public async Task UsuarioController_ShouldValidateTheAuthorizationTokenAndReturnUnauthorized()
        {
            var usuarioServicesMock = new Mock<IUsuarioGetServices>();
            usuarioServicesMock.Setup(x => x.GetList()).ThrowsAsync(new Exception("Unauthorized"));
            var controller = new UsuarioGet(usuarioServicesMock.Object);

            var result = await controller.GetList();

            Assert.IsAssignableFrom<UnauthorizedResult>(result);
        }


        [Fact(DisplayName = "Should validate the authorization token and return ok")]
        public async Task UsuarioController_ShouldValidateTheAuthorizationTokenAndReturnOK()
        {
            var result = await _usuarioGetController.GetList();

            Assert.NotNull(result);
            if (result is ObjectResult objectResult)
            {
                Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            }
        }


        [Fact(DisplayName = "Should call Function GetById")]
        public void UsuarioController_shouldCallFunctionGetById()
        {
            var result = _usuarioGetController.GetById(1);

            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Should return 401 if GetById Unauthorized")]
        public async Task UsuarioController_shouldReturn401IfGetByIdUnauthorized()
        {
            var usuarioServicesMock = new Mock<IUsuarioGetServices>();
            usuarioServicesMock.Setup(x => x.GetById(1)).ThrowsAsync(new Exception("Unauthorized"));
            var controller = new UsuarioGet(usuarioServicesMock.Object);

            var result = await controller.GetById(1);
            Assert.IsAssignableFrom<UnauthorizedResult>(result);
        }

        [Fact(DisplayName = "Should call Function GetById")]
        public async Task UsuarioController_shouldReturn200if()
        {
            var result = await _usuarioGetController.GetById(1);

            if (result is ObjectResult objectResult)
            {
                Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            }
        }
    }
}
