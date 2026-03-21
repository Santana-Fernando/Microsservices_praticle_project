using Microsoft.EntityFrameworkCore;
using Usuario.Domain;
using Usuario.Infra;

namespace Usuario.Infra;

public class UsuarioGetRepository : IUsuarioGet
{
    private readonly ApplicationDbContext _context;
    public UsuarioGetRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Usuarios> GetById(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    public async Task<Usuarios> GetByEmail(string email)
    {
        return await _context.Usuarios.SingleOrDefaultAsync(u => u.email == email);
    }

    public async Task<IEnumerable<Usuarios>> GetList()
    {
        return await _context.Usuarios.ToListAsync();
    }
}
