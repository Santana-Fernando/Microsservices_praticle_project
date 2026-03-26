using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Usuario.Application;
using System.Net.Http;
using System;
using Usuario.del.Controllers;

namespace Test.Usuario.del;
public class UsuarioDelTests
{
    private readonly Mock<IUsuarioDelService> _serviceMock;
    private readonly UsuarioDel _controller;

    public UsuarioDelTests()
    {
        _serviceMock = new Mock<IUsuarioDelService>();
        _controller = new UsuarioDel(_serviceMock.Object);
    }

    [Fact]
    public void Remove_DeveRetornar200_QuandoSucesso()
    {
        // Arrange
        var response = new HttpResponseMessage(HttpStatusCode.OK);

        _serviceMock
            .Setup(s => s.Remove(It.IsAny<int>()))
            .Returns(response);

        // Act
        var result = _controller.Remove(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okResult.Value);
    }

    [Fact]
    public void Remove_DeveRetornar404_QuandoNaoEncontrado()
    {
        // Arrange
        var response = new HttpResponseMessage(HttpStatusCode.NotFound)
        {
            ReasonPhrase = "Usuário não encontrado"
        };

        _serviceMock
            .Setup(s => s.Remove(It.IsAny<int>()))
            .Returns(response);

        // Act
        var result = _controller.Remove(1);

        // Assert
        var notFoundResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(404, notFoundResult.StatusCode);
        Assert.Equal("Usuário não encontrado", notFoundResult.Value);
    }

    [Fact]
    public void Remove_DeveRetornar401_QuandoExcecao()
    {
        // Arrange
        _serviceMock
            .Setup(s => s.Remove(It.IsAny<int>()))
            .Throws(new Exception());

        // Act
        var result = _controller.Remove(1);

        // Assert
        Assert.IsType<UnauthorizedResult>(result);
    }
}