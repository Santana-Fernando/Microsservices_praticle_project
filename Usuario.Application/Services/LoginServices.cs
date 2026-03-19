using AutoMapper;
using Usuario.Domain;

namespace Usuario.Application;

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

