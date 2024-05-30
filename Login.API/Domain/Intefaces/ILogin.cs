using Login.API.Domain.Entities;
using System.Threading.Tasks;

namespace Login.API.Domain.Intefaces
{
    public interface ILogin
    {
        Task<Autenticacao> Login(LoginEntry login);
    }
}
