using Usuario.Domain;

namespace Usuario.Infra;

public class UsuarioDelRepository(ApplicationDbContext context) : IUsuarioDel
{
    private readonly ApplicationDbContext _context = context;
    public void Remove(Usuarios usuarios)
    {
        _context.Remove(usuarios);
        _context.SaveChanges();
    }
}

