using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Net;
using Usuario.Application;
using Usuario.put.Controllers;
using Xunit;

namespace Test.Usuario.put;

public class UsuarioPutControllerTests
{
    private readonly Mock<IUsuarioPutServices> _serviceMock;
    private readonly UsuarioPut _controller;

    public UsuarioPutControllerTests()
    {
        _serviceMock = new Mock<IUsuarioPutServices>();
        _controller = new UsuarioPut(_serviceMock.Object);
    }

    [Fact]
    public void Update_DeveRetornar200_QuandoSucesso()
    {
        // Arrange
        var usuario = new UsuarioView();

        var response = new System.Net.Http.HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK
        };

        _serviceMock
            .Setup(x => x.Update(usuario))
            .Returns(response);

        // Act
        var result = _controller.Update(usuario);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okResult.StatusCode);
    }

    [Fact]
    public void Update_DeveRetornar400_QuandoBadRequest()
    {
        // Arrange
        var usuario = new UsuarioView();

        var response = new System.Net.Http.HttpResponseMessage
        {
            StatusCode = HttpStatusCode.BadRequest,
            ReasonPhrase = "Erro de validação"
        };

        _serviceMock
            .Setup(x => x.Update(usuario))
            .Returns(response);

        // Act
        var result = _controller.Update(usuario);

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(400, objectResult.StatusCode);
        Assert.Equal("Erro de validação", objectResult.Value);
    }

    [Fact]
    public void Update_DeveRetornar404_QuandoNotFound()
    {
        // Arrange
        var usuario = new UsuarioView();

        var response = new System.Net.Http.HttpResponseMessage
        {
            StatusCode = HttpStatusCode.NotFound,
            ReasonPhrase = "Usuário não encontrado"
        };

        _serviceMock
            .Setup(x => x.Update(usuario))
            .Returns(response);

        // Act
        var result = _controller.Update(usuario);

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(404, objectResult.StatusCode);
        Assert.Equal("Usuário não encontrado", objectResult.Value);
    }

    [Fact]
    public void Update_DeveRetornar401_QuandoException()
    {
        // Arrange
        var usuario = new UsuarioView();

        _serviceMock
            .Setup(x => x.Update(usuario))
            .Throws(new Exception());

        // Act
        var result = _controller.Update(usuario);

        // Assert
        Assert.IsType<UnauthorizedResult>(result);
    }
}