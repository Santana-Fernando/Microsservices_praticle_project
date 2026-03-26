using Microsoft.EntityFrameworkCore;
using Usuario.Domain;

namespace Usuario.Infra;

public class UsuarioPutRepository(ApplicationDbContext context) : IUsuarioPut
{
    private readonly ApplicationDbContext _context = context;
    public void Update(Usuarios usuarios)
    {
        _context.Update(usuarios);
        _context.SaveChanges();
    }
}
