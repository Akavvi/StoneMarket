using Application.Abstractions;
using FluentValidation;

namespace Application;

public static class Validation
{
    public static IRuleBuilder<T, TProperty> Apply<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder,
        ICustomValidator<T, TProperty> customValidator) =>
        ruleBuilder.CustomAsync(async (property, context, _) =>
            await customValidator.ValidateAsync(context, property));
}