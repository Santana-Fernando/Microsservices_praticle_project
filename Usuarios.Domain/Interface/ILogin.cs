namespace Usuario.Domain;

public interface ILogin
{
    Task<Autenticacao> Login(LoginEntry login);
}
