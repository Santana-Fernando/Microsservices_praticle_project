namespace Usuario.Application;

public interface IUsuarioGetServices
{
    Task<IEnumerable<UsuarioView>> GetList();
    Task<UsuarioView> GetById(int id);
}
