using AutoMapper;
using Usuario.Domain;

namespace Usuario.Application;

public class UsuarioGetServices: IUsuarioGetServices
{
    private IUsuarioGet _usuarioRepository;
    private IMapper _mapper;
    public UsuarioGetServices(IUsuarioGet usuarioRepository, IMapper mapper)
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
