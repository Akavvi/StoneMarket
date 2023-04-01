using FluentValidation;

namespace Application.Abstractions;

public interface ICustomValidator<T, in TProperty>
{
    public Task ValidateAsync(ValidationContext<T> ctx, TProperty value);
}