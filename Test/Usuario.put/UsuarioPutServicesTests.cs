using AutoMapper;
using Moq;
using System.Net;
using Usuario.Application;
using Usuario.Domain;
using Xunit;

namespace Test.Usuario.put;

public class UsuarioPutServicesTests
{
    private readonly Mock<IUsuarioPut> _usuarioPutMock;
    private readonly Mock<IUsuarioGet> _usuarioGetMock;
    private readonly Mock<IMapper> _mapperMock;

    private readonly UsuarioPutServices _service;

    public UsuarioPutServicesTests()
    {
        _usuarioPutMock = new Mock<IUsuarioPut>();
        _usuarioGetMock = new Mock<IUsuarioGet>();
        _mapperMock = new Mock<IMapper>();

        _service = new UsuarioPutServices(
            _usuarioPutMock.Object,
            _usuarioGetMock.Object,
            _mapperMock.Object
        );
    }

    [Fact]
    public void Update_DeveRetornar400_QuandoValidacaoFalhar()
    {
        var usuarioView = new UsuarioView
        {
            Id = 0,
            Name = "",
            Email = "email-invalido"
        };

        var result = _service.Update(usuarioView);

        Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
    }

    [Fact]
    public void Update_DeveRetornar404_QuandoUsuarioNaoEncontrado()
    {
        var usuarioView = new UsuarioView
        {
            Id = 1,
            Name = "Teste",
            Email = "teste@email.com"
        };

        _usuarioGetMock
            .Setup(x => x.GetById(usuarioView.Id))
            .ReturnsAsync((Usuarios)null);

        var result = _service.Update(usuarioView);

        Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
        Assert.Equal("Usuario não encontrado!", result.ReasonPhrase);
    }

    [Fact]
    public void Update_DeveAtualizarUsuarioERetornar200()
    {
        var usuarioView = new UsuarioView
        {
            Id = 1,
            Name = "Novo Nome",
            Email = "novo@email.com"
        };

        var usuarioExistente = new Usuarios
        {
            id = 1,
            name = "Antigo Nome",
            email = "antigo@email.com"
        };

        _usuarioGetMock
            .Setup(x => x.GetById(usuarioView.Id))
            .ReturnsAsync(usuarioExistente);

        var result = _service.Update(usuarioView);

        Assert.Equal(HttpStatusCode.OK, result.StatusCode);

        _usuarioPutMock.Verify(x => x.Update(It.Is<Usuarios>(u =>
            u.name == "Novo Nome" &&
            u.email == "novo@email.com"
        )), Times.Once);
    }
}
