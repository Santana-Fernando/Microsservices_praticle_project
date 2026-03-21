using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Usuario.Domain;

namespace Usuario.Application;

public class UsuarioPostServices(IUsuarioPost usuarioPostRepository, IMapper mapper) : IUsuarioPostServices
{
    private IUsuarioPost _usuarioPostRepository = usuarioPostRepository;
    private IMapper _mapper = mapper;
    public HttpResponseMessage Register(UsuariosViewModel usuariosViewModel)
    {
        HttpResponse httpResponse = new HttpResponse();
        var validationFields = new ValidationFields(usuariosViewModel).IsValidWithErrors();
        List<string> errorMessages = validationFields.ErrorMessages
                                        .Select(result => result.ErrorMessage!)
                                        .ToList();

        try
        {
            if (!validationFields.IsValid)
            {
                string messageError = string.Join(", ", errorMessages);
                return httpResponse.Response(HttpStatusCode.BadRequest,
                    new StringContent(JsonSerializer.Serialize(errorMessages)),
                    messageError);
            }

            var tarefaMap = _mapper.Map<Usuarios>(usuariosViewModel);
            _usuarioPostRepository.Register(tarefaMap);

            return httpResponse.Response(HttpStatusCode.OK, null, "OK");
        }
        catch (Exception ex)
        {
            return httpResponse.Response(HttpStatusCode.InternalServerError, new StringContent(JsonSerializer.Serialize(ex.Message)), "Internal server error");
        }
    }
}
