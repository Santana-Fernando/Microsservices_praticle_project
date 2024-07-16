using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Usuario.get.Application.Usuario.Interfaces;
using Usuario.get.Application.Usuario.ViewModel;
using Usuario.get.Domain.Entidades;
using Usuario.get.Domain.Interfaces;

namespace Usuario.get.Application.Services
{
    public class UsuarioServices: IUsuarioServices
    {
        private IUsuario _usuarioRepository;
        private IMapper _mapper;
        public UsuarioServices(IUsuario usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        
        public async Task<UsuarioView> GetById(int id)
        {
            Usuarios usuario = await _usuarioRepository.GetById(id);
            return _mapper.Map<UsuarioView>(usuario);
        }

        public async Task<IEnumerable<UsuarioView>> GetList()
        {
            var usuarios = await _usuarioRepository.GetList();
            return _mapper.Map<IEnumerable<UsuarioView>>(usuarios);
        }
    }
}
