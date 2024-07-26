using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using Usuario.get.Application.Usuario.Interfaces;
using Microsoft.AspNetCore.Http;
using Usuario.get.Application.Usuario.ViewModel;
using System;

namespace Usuario.get.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioGet : Controller
    {
        private readonly IUsuarioGetServices _usuarioServices;
        public UsuarioGet(IUsuarioGetServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        [Authorize]
        [Route("GetList")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(UnauthorizedResult))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UsuarioView>))]
        public async Task<IActionResult> GetList()
        {
            try
            {
                var result = await _usuarioServices.GetList();
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        [Authorize]
        [Route("GetById")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(UnauthorizedResult))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioView))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _usuarioServices.GetById(id);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
    }
}
