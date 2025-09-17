using FluentValidation;
using MemkaShop.Application.Auth.Queries;

namespace MemkaShop.Application.Auth.Validation;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty();
    }
}