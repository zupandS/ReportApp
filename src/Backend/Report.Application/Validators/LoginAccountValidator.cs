using FluentValidation;
using Report.Application.Commands.AccountCommands.LoginAccountCommand;

namespace Report.Application.Validators
{
    public class LoginAccountValidator: AbstractValidator<LoginAccountCommand>
    {
        public LoginAccountValidator()
        {
            RuleFor(p => p.LoginAccountModel.Password)
            .NotEmpty().WithMessage("Пароль должен быть заполнен!");

            RuleFor(p => p.LoginAccountModel.Login)
            .NotEmpty().WithMessage("Логин должен быть заполнен!");
        }
    }
}