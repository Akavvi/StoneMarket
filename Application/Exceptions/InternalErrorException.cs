using System.Net;

namespace Application.Exceptions;

public class InternalErrorException : BaseExpection
{
    public InternalErrorException(string? message) : base(HttpStatusCode.InternalServerError, message)
    {
    }
}