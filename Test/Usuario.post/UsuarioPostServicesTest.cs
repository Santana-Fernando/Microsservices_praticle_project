using Xunit;
using Moq;
using System.Net;
using AutoMapper;
using Usuario.Application;
using Usuario.Domain;
using System;
using System.Xml.Linq;

namespace Test.Usuario.post;
public class UsuarioPostServicesTests
{
    private readonly Mock<IUsuarioPost> _mockRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly UsuarioPostServices _service;

    public UsuarioPostServicesTests()
    {
        _mockRepository = new Mock<IUsuarioPost>();
        _mockMapper = new Mock<IMapper>();
        _service = new UsuarioPostServices(_mockRepository.Object, _mockMapper.Object);
    }

    [Fact]
    public void Register_ReturnsBadRequest_WhenValidationFails()
    {
        var viewModel = new UsuariosViewModel();

        var result = _service.Register(viewModel);

        Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
    }

    [Fact]
    public void Register_ReturnsOk_WhenSuccess()
    {
        var viewModel = new UsuariosViewModel
        {
            name = "fernando",
            email = "fernando@gmail.com",
            password = "123456",
            passwordConfirmation = "123456"
        };

        var usuario = new Usuarios();

        _mockMapper
            .Setup(m => m.Map<Usuarios>(It.IsAny<UsuariosViewModel>()))
            .Returns(usuario);

        _mockRepository
            .Setup(r => r.Register(It.IsAny<Usuarios>()))
            .Verifiable();

        var result = _service.Register(viewModel);

        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        _mockRepository.Verify(r => r.Register(It.IsAny<Usuarios>()), Times.Once);
    }

    [Fact]
    public void Register_ReturnsInternalServerError_WhenExceptionOccurs()
    {
        var viewModel = new UsuariosViewModel
        {
            name = "fernando",
            email = "fernando@gmail.com",
            password = "123456",
            passwordConfirmation = "123456"
        };

        _mockMapper
            .Setup(m => m.Map<Usuarios>(It.IsAny<UsuariosViewModel>()))
            .Throws(new Exception("Erro inesperado"));

        var result = _service.Register(viewModel);

        Assert.Equal(HttpStatusCode.InternalServerError, result.StatusCode);
    }
}