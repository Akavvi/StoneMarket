using FluentValidation;
using MediatR;
using ValidationException = Application.Exceptions.ValidationException;

namespace Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any()) return await next();

        var ctx = new ValidationContext<TRequest>(request);

        var results = await Task.WhenAll(
            _validators.Select(validator => validator.ValidateAsync(ctx, cancellationToken))
        );

        var failures = results.SelectMany(result => result.Errors).ToList();

        if (failures.Any())
            throw new ValidationException(failures);

        return await next();
    }
}