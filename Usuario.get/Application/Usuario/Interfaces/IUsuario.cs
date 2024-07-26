using System.Collections.Generic;
using System.Threading.Tasks;
using Usuario.get.Application.Usuario.ViewModel;

namespace Usuario.get.Application.Usuario.Interfaces
{
    public interface IUsuarioGetServices
    {
        Task<IEnumerable<UsuarioView>> GetList();
        Task<UsuarioView> GetById(int id);
    }
}
