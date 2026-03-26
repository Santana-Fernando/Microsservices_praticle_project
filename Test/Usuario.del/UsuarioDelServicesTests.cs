using Xunit;
using Moq;
using System.Net;
using Usuario.Application;
using Usuario.Domain;
using System.Threading.Tasks;

namespace Test.Usuario.del;

public class UsuarioDelServicesTests
{
    private readonly Mock<IUsuarioDel> _usuarioDelMock;
    private readonly Mock<IUsuarioGet> _usuarioGetMock;
    private readonly UsuarioDelServices _service;

    public UsuarioDelServicesTests()
    {
        _usuarioDelMock = new Mock<IUsuarioDel>();
        _usuarioGetMock = new Mock<IUsuarioGet>();

        _service = new UsuarioDelServices(
            _usuarioDelMock.Object,
            _usuarioGetMock.Object
        );
    }

    [Fact]
    public void Remove_DeveRetornar200_QuandoUsuarioExiste()
    {
        // Arrange
        var usuario = new Usuarios(); // entidade fake

        _usuarioGetMock
            .Setup(x => x.GetById(It.IsAny<int>()))
            .ReturnsAsync(usuario);

        // Act
        var result = _service.Remove(1);

        // Assert
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);

        _usuarioDelMock.Verify(x => x.Remove(usuario), Times.Once);
    }

    [Fact]
    public void Remove_DeveRetornar404_QuandoUsuarioNaoExiste()
    {
        // Arrange
        _usuarioGetMock
            .Setup(x => x.GetById(It.IsAny<int>()))
            .ReturnsAsync((Usuarios)null);

        // Act
        var result = _service.Remove(1);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);

        _usuarioDelMock.Verify(x => x.Remove(It.IsAny<Usuarios>()), Times.Never);
    }
}
