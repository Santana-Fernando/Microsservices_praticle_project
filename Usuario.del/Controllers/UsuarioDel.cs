using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Usuario.Application;

namespace Usuario.del.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioDel(IUsuarioDelService usuarioDelService) : ControllerBase
{
    private IUsuarioDelService _usuarioDelService = usuarioDelService;

    [Authorize]
    [HttpDelete]
    [Route("Remove")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public IActionResult Remove(int id)
    {
        try
        {
            var result = _usuarioDelService.Remove(id);
            switch (result.StatusCode)
            {
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
