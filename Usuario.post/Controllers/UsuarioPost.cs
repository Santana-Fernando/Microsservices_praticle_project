using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Usuario.Application;

namespace Usuario.post.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioPost(IUsuarioPostServices usuarioPostServices) : ControllerBase
    {
        private IUsuarioPostServices _usuarioPostServices = usuarioPostServices;

        [Authorize]
        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Register(UsuariosViewModel usuariosViewModel)
        {
            try
            {

                var result = _usuarioPostServices.Register(usuariosViewModel);
                var response = new { Message = result.ReasonPhrase };

                switch (result.StatusCode)
                {
                    case System.Net.HttpStatusCode.BadRequest:
                        return StatusCode(StatusCodes.Status400BadRequest, result.ReasonPhrase);
                    case System.Net.HttpStatusCode.InternalServerError:
                        return StatusCode(StatusCodes.Status500InternalServerError, result.ReasonPhrase);

                    default:
                        return Ok(response);
                }
            }
            catch (Exception)
            {

                return Unauthorized();
            }
        }
    }
}
