using FluentValidation;

namespace Application.Account.Commands.CreateAccount;

public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
{
  public CreateAccountCommandValidator()
  {
    RuleFor(t => t.Email)
      .NotEmpty()
      .WithMessage("Email Does Not Meet Requirements");

    RuleFor(t => t.Password)
      .NotEmpty()
      .WithMessage("Password Does Not Meet Requirements");


    RuleFor(t => t.UserName)
      .NotEmpty()
      .WithMessage("UserName Does Not Meet Requirements");


    RuleFor(t => t.DisplayName)
      .NotEmpty()
      .WithMessage("DisplayName Does Not Meet Requirements");
  }
}