using Login.API.Application.ViewModel;
using Login.API.Application.Services;
using Login.API.Application.Validation;
using AutoMapper;
using Login.API.Domain.Entities;
using Login.API.Domain.Intefaces;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace Tests.Login
{
    public class LoginServicesTest
    {
        private readonly LoginServices _loginServices;
        private readonly IMapper _mapperMock;
        public LoginServicesTest()
        {
            _loginServices = LoginRepositoryStub();
            var config = configIMapper();
            _mapperMock = config.CreateMapper();
        }

        private LoginServices LoginRepositoryStub()
        {
            var loginRepositoryMock = new Mock<ILogin>();
            return new LoginServices(loginRepositoryMock.Object, _mapperMock);
        }

        private MapperConfiguration configIMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<LoginEntryViewModel, LoginEntry>();
                cfg.CreateMap<LoginEntry, LoginEntryViewModel>();
            });

            return config;
        }

        [Fact(DisplayName = "Should call function login")]
        public async Task LoginServices_ShouldCallFunctionLogin()
        {
            var loginEntryViewModel = new LoginEntryViewModel
            {
                email = "test@example.com",
                password = "password123"
            };

            var result = await _loginServices.Login(loginEntryViewModel);
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Should return the message of email required")]
        public void LoginServices_ShouldReturnMessageEmailRequired()
        {            
            var loginEntryViewModel = new LoginEntryViewModel
            {
                email = "",
                password = "123456"
            };

            var validationFields = new ValidationFields(loginEntryViewModel).IsValidWithErrors();
            var requiredEmailError = validationFields.ErrorMessages.FirstOrDefault(result => result.ErrorMessage == "The E-mail is Required");

            Assert.False(validationFields.IsValid);
            Assert.NotNull(requiredEmailError);
        }

        [Fact(DisplayName = "Should return the message min Email characteres numbers")]
        public void LoginServices_ShouldReturnMessageEmailMinCharacter()
        {            
            var loginEntryViewModel = new LoginEntryViewModel
            {
                email = "f@m",
                password = "123456"
            };

            var validationFields = new ValidationFields(loginEntryViewModel).IsValidWithErrors();
            var requiredEmailError = validationFields.ErrorMessages.FirstOrDefault(result => result.ErrorMessage == "The field email must be a string or array type with a minimum length of '10'.");

            Assert.False(validationFields.IsValid);
            Assert.NotNull(requiredEmailError);
        }

        [Fact(DisplayName = "Should return the message Max Email characteres numbers")]
        public void LoginServices_ShouldReturnMessageEmailMaxCharacter()
        {
            var loginEntryViewModel = new LoginEntryViewModel
            {
                email = "asdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdf@gmail.com",
                password = "123456"
            };

            var validationFields = new ValidationFields(loginEntryViewModel).IsValidWithErrors();
            var requiredEmailError = validationFields.ErrorMessages.FirstOrDefault(result => result.ErrorMessage == "The field email must be a string or array type with a maximum length of '100'.");

            Assert.False(validationFields.IsValid);
            Assert.NotNull(requiredEmailError);
        }

        [Fact(DisplayName = "Should return the message of password required")]
        public void LoginServices_ShouldReturnMessagePasswordlRequired()
        {
            var loginEntryViewModel = new LoginEntryViewModel
            {
                email = "fer@gmail.com",
                password = ""
            };

            var validationFields = new ValidationFields(loginEntryViewModel).IsValidWithErrors();
            var requiredEmailError = validationFields.ErrorMessages.FirstOrDefault(result => result.ErrorMessage == "The Password is Required");

            Assert.False(validationFields.IsValid);
            Assert.NotNull(requiredEmailError);
        }

        [Fact(DisplayName = "Should return the message min password characteres numbers")]
        public void LoginServices_ShouldReturnMessagePasswordMinCharacter()
        {
            var loginEntryViewModel = new LoginEntryViewModel
            {
                email = "fer@gmail.com",
                password = "123"
            };

            var validationFields = new ValidationFields(loginEntryViewModel).IsValidWithErrors();
            var requiredEmailError = validationFields.ErrorMessages.FirstOrDefault(result => result.ErrorMessage == "The field password must be a string or array type with a minimum length of '6'.");

            Assert.False(validationFields.IsValid);
            Assert.NotNull(requiredEmailError);
        }

        [Fact(DisplayName = "Should return the message Max Password characteres numbers")]
        public void LoginServices_ShouldReturnMessagePasswordMaxCharacter()
        {
            var loginEntryViewModel = new LoginEntryViewModel
            {
                email = "fer@gmail.com",
                password = "1234123412341234"
            };

            var validationFields = new ValidationFields(loginEntryViewModel).IsValidWithErrors();
            var requiredEmailError = validationFields.ErrorMessages.FirstOrDefault(result => result.ErrorMessage == "The field password must be a string or array type with a maximum length of '10'.");

            Assert.False(validationFields.IsValid);
            Assert.NotNull(requiredEmailError);
        }

        [Fact(DisplayName = "Should return that the fields are ok and valid")]
        public void LoginServices_ShouldReturnTheFieldsAreOkAndValid()
        {
            var loginEntryViewModel = new LoginEntryViewModel
            {
                email = "system@gmail.com",
                password = "123456"
            };

            var validationFields = new ValidationFields(loginEntryViewModel).IsValidWithErrors();
            
            Assert.True(validationFields.IsValid);
        }
    }
}
