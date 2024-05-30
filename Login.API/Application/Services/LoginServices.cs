using Login.API.Application.Validation;
using Login.API.Application.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Login.API.Domain.Intefaces;
using AutoMapper;
using Login.API.Domain.Entities;
using Login.API.Application.Interfaces;
using Login.API.Application.ViewModel;

namespace Login.API.Application.Services
{
    public class LoginServices : ILoginServices
    {
        private ILogin _loginRepository;
        private IMapper _mapper;
        public LoginServices(ILogin loginRepository, IMapper mapper)
        {
            _loginRepository = loginRepository;
            _mapper = mapper;
        }

        public async Task<Autenticacao> Login(LoginEntryViewModel login)
        {
            HttpResponse httpResponse = new HttpResponse();
            var validationFields = new ValidationFields(login).IsValidWithErrors();
            List<string> errorMessages = new List<string>(validationFields.ErrorMessages.Select(result => result.ErrorMessage));

            if (!validationFields.IsValid)
            {
                return httpResponse.BadRequest(errorMessages);
            }

            var mapLogin = _mapper.Map<LoginEntry>(login);
            return await _loginRepository.Login(mapLogin);
        }
    }
}
