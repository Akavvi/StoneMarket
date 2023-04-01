using Application.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

public class HandleExpectionsFilterAttribute : ExceptionFilterAttribute
{
    public void OnException(ExceptionContext ctx)
    {
        var type = ctx.Exception.GetBaseException();
        if (type is BaseExpection)
        {
            
        }
    }
}