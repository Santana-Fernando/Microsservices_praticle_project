namespace Usuario.Domain;

public interface IUsuarioGet
{
    Task<IEnumerable<Usuarios>> GetList();
    Task<Usuarios> GetById(int id);
    Task<Usuarios> GetByEmail(string email);
}
