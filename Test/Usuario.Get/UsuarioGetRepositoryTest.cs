using Usuario.get.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Tests.Helper;
using Usuario.get.Domain.Entidades;
using Usuario.get.Infra.Data.Repository;
using Xunit;
using Xunit.Abstractions;

namespace Test.Usuario.Get
{
    public class UsuarioGetRepositoryTest
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UsuarioGetRepository _usuarioGetRepository;

        public UsuarioGetRepositoryTest()
        {
            AppSettingsMock appSettingsMock = new AppSettingsMock();
            var options = appSettingsMock.OptionsDatabaseStubUsuarioGet();
            _dbContext = new ApplicationDbContext(options);

            _usuarioGetRepository = new UsuarioGetRepository(_dbContext);
        }

        private void RemoverAllUsers()
        {
            AppSettingsMock appSettingsMock = new AppSettingsMock();
            var options = appSettingsMock.OptionsDatabaseStubUsuarioGet();

            using (var dbContext = new ApplicationDbContext(options))
            {
                var usuariosParaRemover = dbContext.Usuarios.Where(u => u.id != 1).ToList();

                var usuario = new Usuarios
                {
                    id = 1,
                    name = "system",
                    email = "system@gmail.com",
                    password = "$2a$10$e/IZDBCPryoa6XMwowkItuVWAeZmYOH1RiinVrcHVTm560uGIaUa2"
                };

                if (usuariosParaRemover.Count > 0)
                {
                    dbContext.Usuarios.RemoveRange(usuariosParaRemover);
                    dbContext.Usuarios.Update(usuario);
                    dbContext.Database.ExecuteSqlRaw($"DBCC CHECKIDENT ('Usuarios', RESEED, 1)");
                    dbContext.SaveChanges();
                }
            }
        }

        [Fact(DisplayName = "Should call the function GetById")]
        public async Task UsuarioRepository_ShouldCallFunctionGetById()
        {
            var usuario = await _usuarioGetRepository.GetById(1);

            Assert.NotNull(usuario);
            Assert.True(usuario.email == "system@gmail.com");            
        }

        [Fact(DisplayName = "Should call the function GetByEmail")]
        public async Task UsuarioRepository_ShouldCallFunctionGetByEmail()
        {            
            var usuario = await _usuarioGetRepository.GetByEmail("system@gmail.com");

            Assert.NotNull(usuario);
            Assert.True(usuario.email == "system@gmail.com");   
        }

        [Fact(DisplayName = "Should call the function GetList")]
        public async Task UsuarioRepository_ShouldCallFunctionGetList()
        {
            RemoverAllUsers();
            
            var usuario = await _usuarioGetRepository.GetList();

            Assert.NotNull(usuario);
            Assert.True(usuario.ToList().Count > 0);
            
        }

    }
}
