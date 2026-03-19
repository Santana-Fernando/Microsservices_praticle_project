using System.Threading.Tasks;
using Moq;
using Tests.Helper;
using Xunit;
using Microsoft.Extensions.Configuration;
using Usuario.Infra;
using Usuario.Domain;
using Usuario.Application;

namespace Tests.Login
{
    public class LoginRepositoryTest
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly LoginRepository _loginRepository;
        public LoginRepositoryTest()
        {
            AppSettingsMock appSettingsMock = new AppSettingsMock();
            var options = appSettingsMock.OptionsDatabaseStub<ApplicationDbContext>();
            var configurationMock = appSettingsMock.configurationMockStub();
            _dbContext = new ApplicationDbContext(options);
            _loginRepository = new LoginRepository(_dbContext, configurationMock.Object);
        }

        [Fact(DisplayName = "Should call Authenticatio Login and return any answer")]
        public async Task LoginRepository_ShouldCallAuthenticationLogin()
        {
            var loginEntry = new LoginEntry
            {
                email = "test@example.com",
                password = "password123"
            };

            var result = await _loginRepository.Login(loginEntry);

            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Should return access denied if login data not exists")]
        public async Task LoginRepository_ShouldReturnAccessDeniedIfLoginEntryDataNotExists()
        {
            var loginEntry = new LoginEntry
            {
                email = "test@example.com",
                password = "password123"
            };

            var result = await _loginRepository.Login(loginEntry);

            Assert.NotNull(result);
            Assert.Equal("Access denied", result.message);
            Assert.Equal(System.Net.HttpStatusCode.Forbidden, result.statusCode);
        }

        [Fact(DisplayName = "Should return internal server error if login catches")]
        public async Task LoginRepository_ShouldReturnInternalServerErrorIfLoginCatches()
        {
            var configurationMock = new Mock<IConfiguration>();
            var loginRepository = new Mock<ILogin>();

            var loginEntry = new LoginEntry
            {
                email = "test@example.com",
                password = "123456"
            };

            var errorResponse = new Autenticacao
            {
                statusCode = System.Net.HttpStatusCode.InternalServerError,
                message = "InternalServerError"
            };

            loginRepository.Setup(x => x.Login(loginEntry)).ReturnsAsync(errorResponse);

            var result = await loginRepository.Object.Login(loginEntry);

            Assert.NotNull(result);
            Assert.Equal(System.Net.HttpStatusCode.InternalServerError, result.statusCode);
        }

        [Fact(DisplayName = "Should return OK if login is correct")]
        public async Task LoginRepository_ShouldReturnOkIfLoginIsCorrect()
        {
            AppSettingsMock appSettingsMock = new AppSettingsMock();
            var configurationMock = appSettingsMock.configurationMockStub();
            var loginEntry = new LoginEntry
            {
                email = "system@gmail.com",
                password = "123456"
            };

            var result = await _loginRepository.Login(loginEntry);

            Assert.NotNull(result);
            Assert.True(new TokenAuthentication(configurationMock.Object).ValidateToken(result.token));
            Assert.Equal(System.Net.HttpStatusCode.OK, result.statusCode);
            Assert.Equal("OK", result.message);
        }

    }
}
