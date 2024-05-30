using System.Collections.Generic;
using System.Threading.Tasks;
using Usuario.get.Domain.Entidades;

namespace Usuario.get.Domain.Interfaces
{
    public interface IUsuario
    {
        Task<IEnumerable<Usuarios>> GetList();
        Task<Usuarios> GetById(int id);
        Task<Usuarios> GetByEmail(string email);
    }
}
