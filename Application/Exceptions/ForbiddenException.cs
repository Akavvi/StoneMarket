using System.Net;

namespace Application.Exceptions;

public class ForbiddenException : BaseExpection
{

    public ForbiddenException(string message)
        : base(HttpStatusCode.Forbidden,message) { }
}