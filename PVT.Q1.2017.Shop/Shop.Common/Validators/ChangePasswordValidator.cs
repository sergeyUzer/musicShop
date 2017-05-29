namespace Shop.Common.Validators
{
    using FluentValidation;
    using PVT.Q1._2017.Shop.ViewModels;

    /// <summary>
    /// Defines rules for user registration
    /// </summary>
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordViewModel>
    {
        /// <summary>
        /// 
        /// </summary>
        public ChangePasswordValidator()
        {
            RuleFor(u => u.OldPassword).NotEmpty()
                .WithMessage("Поле обязательно должно быть заполнено");
            
            RuleFor(u => u.Password).NotEmpty()
                .WithMessage("Поле обязательно должно быть заполнено");
            RuleFor(u => u.Password)
                .Matches(@"^(?=.*\w)(?=.*\d)(?=.*[!-*]).[^\s]*$")
                .WithMessage("Пароль должен содержать символы латинского алфавита, цифры и спецсимволы");
            RuleFor(u => u.Password).Length(4, 50)
                .WithMessage("Пароль должен содержать не менее 4 символов");
            RuleFor(u => u.Password)
                .NotEqual(u => u.OldPassword)
                .WithMessage("Новый пароль не должен совпадать со старым");

            RuleFor(u => u.ConfirmPassword)
                .Equal(u => u.Password)
                .WithMessage("Пароли не совпадают. Повторите попытку");            
        }
    }
}
