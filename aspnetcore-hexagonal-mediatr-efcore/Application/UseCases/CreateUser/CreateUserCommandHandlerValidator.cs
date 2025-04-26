using FluentValidation;

namespace Application.UserCases.CreateUser;

public class CreateUserCommandHandlerValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandHandlerValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("Name are required.")
            .MinimumLength(3).WithMessage("Name must be at least 3 characters long.");
    }
}