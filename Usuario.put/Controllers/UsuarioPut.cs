using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Usuario.Application;

namespace Usuario.put.Controllers;


[ApiController]
[Route("[controller]")]
public class UsuarioPut(IUsuarioPutServices usuarioPutServices) : ControllerBase
{
    private IUsuarioPutServices _usuarioPutServices = usuarioPutServices;

    [Authorize]
    [HttpPut]
    [Route("Update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public IActionResult Update(UsuarioView usuariosView)
    {
        try
        {
            var result = _usuarioPutServices.Update(usuariosView);
            switch (result.StatusCode)
            {
                case System.Net.HttpStatusCode.BadRequest:
                    return StatusCode(StatusCodes.Status400BadRequest, result.ReasonPhrase);
                case System.Net.HttpStatusCode.NotFound:
                    return StatusCode(StatusCodes.Status404NotFound, result.ReasonPhrase);

                default:
                    return Ok(StatusCodes.Status200OK);
            }
        }
        catch (Exception)
        {
            return Unauthorized();
        }
    }
}
