using System.Net;

namespace Application.Exceptions;

public class BaseExpection : Exception
{
    public HttpStatusCode StatusCode { get; set; }
    public BaseExpection(HttpStatusCode statusCode, string? message) : base(message)
    {
        StatusCode = statusCode;
    }
}