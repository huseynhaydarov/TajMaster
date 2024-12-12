using FluentValidation;

namespace TajMaster.Application.UseCases.Users.Commands.Create;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    { 
    }
}