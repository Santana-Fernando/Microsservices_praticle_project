using Usuario.Domain;

namespace Usuario.Application;

public interface ILoginServices
{
    Task<Autenticacao> Login(LoginEntryViewModel login);
}

