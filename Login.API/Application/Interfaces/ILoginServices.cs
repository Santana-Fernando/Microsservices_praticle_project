using Login.API.Application.ViewModel;
using Login.API.Domain.Entities;
using System.Threading.Tasks;

namespace Login.API.Application.Interfaces
{
    public interface ILoginServices
    {
        Task<Autenticacao> Login(LoginEntryViewModel login);
    }
}
