using System.Net;

namespace Usuario.Domain;
public class Autenticacao
{
    public string? token { get; set; }
    public string? name { get; set; }
    public HttpStatusCode statusCode { get; set; }
    public string message { get; set; }
}
