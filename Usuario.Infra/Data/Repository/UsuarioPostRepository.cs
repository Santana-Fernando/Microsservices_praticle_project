using Usuario.Domain;

namespace Usuario.Infra;
public class UsuarioPostRepository(ApplicationDbContext context) : IUsuarioPost
{
    private readonly ApplicationDbContext _context = context;

    public void Register(Usuarios usuario)
    {
        _context.Add(usuario);
        _context.SaveChanges();
    }
}
