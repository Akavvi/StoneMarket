using System.Net;

namespace Application.Exceptions;

public class AlreadyExistsException : BaseExpection
{
    public AlreadyExistsException(string? message) : base(HttpStatusCode.Conflict ,message)
    {
    }
}