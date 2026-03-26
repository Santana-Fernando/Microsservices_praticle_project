
using AutoMapper;
using System.Net;
using Usuario.Domain;

namespace Usuario.Application;

public class UsuarioDelServices(IUsuarioDel usuarioDelRepository, IUsuarioGet usuarioGetRepository) : IUsuarioDelService
{
    private IUsuarioGet _usuarioGetRepository = usuarioGetRepository;
    private IUsuarioDel _usuarioDelRepository = usuarioDelRepository;

    public HttpResponseMessage Remove(int id)
    {
        HttpResponse httpResponse = new HttpResponse();

        var usuarioRemove = _usuarioGetRepository.GetById(id).Result;

        if (usuarioRemove != null)
        {
            _usuarioDelRepository.Remove(usuarioRemove);
            return httpResponse.Response(HttpStatusCode.OK, null, "OK");
        }

        return httpResponse.Response(HttpStatusCode.NotFound, null, "Tarefa não encontrada!");
    }
}
