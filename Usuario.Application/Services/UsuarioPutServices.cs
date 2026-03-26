using AutoMapper;
using System.Net;
using System.Text.Json;
using Usuario.Domain;

namespace Usuario.Application;

public class UsuarioPutServices(IUsuarioPut usuarioPutRepository, IUsuarioGet usuarioGetRepository, IMapper mapper) : IUsuarioPutServices
{
    private IUsuarioGet _usuarioGetRepository = usuarioGetRepository;
    private IUsuarioPut _usuarioPutRepository = usuarioPutRepository;
    private IMapper _mapper = mapper;
    public HttpResponseMessage Update(UsuarioView usuariosView)
    {
        HttpResponse httpResponse = new HttpResponse();
        var validationFields = new ValidationFields(usuariosView).IsValidWithErrors();
        List<string> errorMessages = validationFields.ErrorMessages
                                        .Select(result => result.ErrorMessage!)
                                        .ToList();

        if (!validationFields.IsValid)
        {
            string messageError = string.Join(", ", errorMessages);

            return httpResponse.Response(HttpStatusCode.BadRequest,
                new StringContent(JsonSerializer.Serialize(errorMessages)),
                messageError);
        }

        var usurioToUpdate = _usuarioGetRepository.GetById(usuariosView.Id).Result;

        if (usurioToUpdate != null)
        {
            usurioToUpdate.name = usuariosView.Name;
            usurioToUpdate.email = usuariosView.Email;

            _usuarioPutRepository.Update(usurioToUpdate);
            return httpResponse.Response(HttpStatusCode.OK, null, "OK");
        }

        return httpResponse.Response(HttpStatusCode.NotFound, null, "Usuario não encontrado!");
    }

}
