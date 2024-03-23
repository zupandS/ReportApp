using FluentValidation;
using Report.Application.Commands.AccountCommands.CreateAccountCommand;

namespace Report.Application.Validators
{
    public class CreateAccountValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountValidator()
        {
            RuleFor(p => p.CreateAccountModel.Password)
            .NotEmpty().WithMessage("Пароль должен быть заполнен!")
            .MinimumLength(8).WithMessage("Пароль должен иметь минимум 8 символов!");

            RuleFor(p => p.CreateAccountModel.Login)
            .NotEmpty().WithMessage("Логин должен быть заполнен!")
            .MinimumLength(3).WithMessage("Логин должен иметь минимум 3 символа!")
            .MaximumLength(50).WithMessage("Логин не должен привышать 50 символов");
        }
    }
}