using Usuario.get.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Usuario.get.Domain.Entidades;
using Usuario.get.Domain.Interfaces;

namespace Usuario.get.Infra.Data.Repository
{
    public class UsuarioGetRepository : IUsuario
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
}
