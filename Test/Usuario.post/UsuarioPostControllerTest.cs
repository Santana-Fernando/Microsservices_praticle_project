using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using Usuario.Application;
using Xunit;
using Usuario.post.Controllers;

namespace Test.Usuario.post;

public class UsuarioPostControllerTest
{
    private readonly Mock<IUsuarioPostServices> _mockService;
    private readonly UsuarioPost _controller;

    public UsuarioPostControllerTest()
    {
        _mockService = new Mock<IUsuarioPostServices>();
        _controller = new UsuarioPost(_mockService.Object);
    }

    [Fact]
    public void Register_ReturnsOk_WhenSuccess()
    {
        var viewModel = new UsuariosViewModel();

        _mockService.Setup(s => s.Register(It.IsAny<UsuariosViewModel>()))
            .Returns(new HttpResponseMessage(HttpStatusCode.OK)
            {
                ReasonPhrase = "Success"
            });

        var result = _controller.Register(viewModel);

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okResult.StatusCode);
    }

    [Fact]
    public void Register_ReturnsBadRequest_WhenBadRequest()
    {
        var viewModel = new UsuariosViewModel();

        _mockService.Setup(s => s.Register(It.IsAny<UsuariosViewModel>()))
            .Returns(new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                ReasonPhrase = "Invalid data"
            });

        var result = _controller.Register(viewModel);

        var badRequest = Assert.IsType<ObjectResult>(result);
        Assert.Equal(400, badRequest.StatusCode);
    }

    [Fact]
    public void Register_ReturnsInternalServerError_WhenError()
    {
        var viewModel = new UsuariosViewModel();

        _mockService.Setup(s => s.Register(It.IsAny<UsuariosViewModel>()))
            .Returns(new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                ReasonPhrase = "Error"
            });

        var result = _controller.Register(viewModel);

        var error = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, error.StatusCode);
    }

    [Fact]
    public void Register_ReturnsUnauthorized_WhenException()
    {
        var viewModel = new UsuariosViewModel();

        _mockService.Setup(s => s.Register(It.IsAny<UsuariosViewModel>()))
            .Throws(new Exception());

        var result = _controller.Register(viewModel);

        Assert.IsType<UnauthorizedResult>(result);
    }
}
