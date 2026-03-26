namespace Usuario.Application;

public interface IUsuarioPutServices
{
    HttpResponseMessage Update(UsuarioView usuariosView);
}
