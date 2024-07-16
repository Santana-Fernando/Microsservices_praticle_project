using Login.API.Application.ViewModel;
using Login.API.Application.Services;
using AutoMapper;
using Login.API.Domain.Entities;
using Login.API.Infra.Data.Context;
using Login.API.Infra.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tests.Helper;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Login
{
    public class LoginControllerTest
    {
        private readonly LoginRepository _loginRepository;
        private readonly LoginServices _loginServices;
        private readonly Presentation.Controllers.Login _loginController;
        public LoginControllerTest()
        {
            _loginRepository = LoginRepositoryStub();
            var config = configIMapper();
            var mapperMock = config.CreateMapper();

            _loginServices = new LoginServices(_loginRepository, mapperMock);
            _loginController = new Presentation.Controllers.Login(_loginServices);
        }

        private LoginRepository LoginRepositoryStub()
        {
            AppSettingsMock appSettingsMock = new AppSettingsMock();
            var options = appSettingsMock.OptionsDatabaseStub();
            var dbContext = new ApplicationDbContext(options);
            var configurationMock = appSettingsMock.configurationMockStub();

            return new LoginRepository(dbContext, configurationMock.Object);
        }

        private MapperConfiguration configIMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<LoginEntryViewModel, LoginEntry>();
                cfg.CreateMap<LoginEntry, LoginEntryViewModel>();
            });

            return config;
        }

        [Fact(DisplayName = "Should call LoginController")]
        public async Task LoginRepository_ShouldCallLoginController()
        {
            var loginEntry = new LoginEntryViewModel()
            {
                email = "fer@gmail.com",
                password = "123456"
            };

            var result = await _loginController.LoginEntry(loginEntry);

            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Should return the status StatusCodes.Status403Forbidden")]
        public async Task LoginRepository_ShouldReturnStatus403Forbidden()
        {
            var loginEntry = new LoginEntryViewModel()
            {
                email = "fer@gmail.com",
                password = "123456"
            };

            var result = await _loginController.LoginEntry(loginEntry);
                
            Assert.NotNull(result);
            if (result is ObjectResult objectResult)
            {
                Assert.Equal(StatusCodes.Status403Forbidden, objectResult.StatusCode);
            }
        }

        [Fact(DisplayName = "Should return the status Status400BadRequest if e-mail is missing.")]
        public async Task LoginRepository_ShouldReturnStatus400BadRequestEmailMissing()
        {
            var loginEntry = new LoginEntryViewModel()
            {
                email = "",
                password = "123456"
            };

            var result = await _loginController.LoginEntry(loginEntry);

            Assert.NotNull(result);
            if (result is ObjectResult objectResult)
            {
                Assert.Equal(StatusCodes.Status400BadRequest, objectResult.StatusCode);
            }
        }

        [Fact(DisplayName = "Should return the status Status400BadRequest if password is missing.")]
        public async Task LoginRepository_ShouldReturnStatus400BadRequestPasswordMissing()
        {
            var loginEntry = new LoginEntryViewModel()
            {
                email = "fer@gmail.com",
                password = ""
            };

            var result = await _loginController.LoginEntry(loginEntry);

            Assert.NotNull(result);
            if (result is ObjectResult objectResult)
            {
                Assert.Equal(StatusCodes.Status400BadRequest, objectResult.StatusCode);
            }
        }

        [Fact(DisplayName = "Should return the status 200OK if ok.")]
        public async Task LoginRepository_ShouldReturnStatus200IfOK()
        {
            var loginEntry = new LoginEntryViewModel()
            {
                email = "system@gmail.com",
                password = "123456"
            };

            var result = await _loginController.LoginEntry(loginEntry);

            Assert.NotNull(result);
            if (result is ObjectResult objectResult)
            {
                Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            }
        }
    }
}
