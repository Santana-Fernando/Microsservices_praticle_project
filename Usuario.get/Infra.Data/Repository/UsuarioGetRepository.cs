using Login.API.Infra.Data.Context;
using System;
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
        public Task<Usuarios> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Usuarios> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuarios>> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
