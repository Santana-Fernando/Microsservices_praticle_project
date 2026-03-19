namespace Usuario.Domain;

public interface IUsuario
{
    Task<IEnumerable<Usuarios>> GetList();
    Task<Usuarios> GetById(int id);
    Task<Usuarios> GetByEmail(string email);
}
