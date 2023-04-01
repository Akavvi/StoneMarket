using System.Runtime.InteropServices;
using Application.Abstractions;
using Application.Exceptions;
using FluentValidation;
using MediatR;

namespace Application.Features.Users.Commands;

public class Register
{
    public sealed record Command(string Username, string Email, string Password) : IRequest<Response>;

    public sealed class Validator : AbstractValidator<Command>
    {
        public Validator(IPasswordValidator<Command> validator)
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Username).Length(4, 24);
            RuleFor(x => x.Password).Apply(validator);
        }
    }

    internal sealed class Handler : IRequestHandler<Command, Response>
    {
        private readonly IUserService _users;
        private readonly ICurrentUserProvider _userProvider;

        public Handler(IUserService users, ICurrentUserProvider userProvider)
        {
            _users = users;
            _userProvider = userProvider;
        }

        public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
            if (_userProvider.IsAuthenticated) throw new ForbiddenException("");

            var userExists = await _users.FindByEmailAsync(request.Email) is not null;
            if (userExists) throw new AlreadyExistsException("User with the specified email already exists.");

            var errors = await _users.CreateAsync(request.Email, request.Password);
            if (errors is not null) throw new Exceptions.ValidationException(nameof(request.Password), errors);

            var user = await _users.FindByEmailAsync(request.Email) ??
                       throw new Exception("Something gone wrong!");

            return new Response(user.Id!, user.Email!);
        }
    }

    public sealed record Response(long Id, string Email);
}