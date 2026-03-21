namespace Usuario.Application;
public interface IUsuarioPostServices
{
    HttpResponseMessage Register(UsuariosViewModel usuariosViewModel);
}
