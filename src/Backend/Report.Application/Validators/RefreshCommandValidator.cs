using FluentValidation;
using Report.Application.Commands.AuthCommands.RefreshCommand;

namespace Report.Application.Validators
{
    public class RefreshCommandValidator : AbstractValidator<RefreshCommand>
    {
        public RefreshCommandValidator()
        {
            RuleFor(r => r.RefreshModel.AccessToken).NotEmpty().WithMessage("Refresh токен не должен быть пустым");
            RuleFor(r => r.RefreshModel.RefreshToken).NotEmpty().WithMessage("Access токен не должен быть пустым");
        }
    }
}