using FluentValidation.Results;

namespace Application.Exceptions;
// шлепа спасибо за код
public class ValidationException : Exception
{
    public IDictionary<string, IEnumerable<string>> Errors { get; } = new Dictionary<string, IEnumerable<string>>();

    public ValidationException()
        : base("One or more validation failures have occurred.") { }

    public ValidationException(IDictionary<string, IEnumerable<string>> errors) =>
        Errors = errors;

    public ValidationException(string propertyName, IEnumerable<string> errorDescriptions)
        : this(new Dictionary<string, IEnumerable<string>>
        {
            [propertyName] = errorDescriptions
        }) { }

    public ValidationException(string propertyName, string errorDescriptions)
        : this(propertyName, new[] { errorDescriptions }) { }

    public ValidationException(IEnumerable<ValidationFailure> failures) : this(failures
        .GroupBy(
            failure => failure.PropertyName,
            failure => failure.ErrorMessage)
        .ToDictionary(
            failuresByPropertyName => failuresByPropertyName.Key,
            failuresByPropertyName => failuresByPropertyName.AsEnumerable())) { }
}