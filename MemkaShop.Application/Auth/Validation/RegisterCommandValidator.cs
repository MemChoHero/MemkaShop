using FluentValidation;
using MemkaShop.Application.Auth.Commands;

namespace MemkaShop.Application.Auth.Validation;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(25)
            .MinimumLength(3);
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(30);
    }
}