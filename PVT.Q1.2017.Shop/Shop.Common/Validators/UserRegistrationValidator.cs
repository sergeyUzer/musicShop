namespace Shop.Common.Validators
{
    using System;
    using System.Web.Mvc;
    using FluentValidation;
    using Infrastructure;
    using ViewModels;

    /// <summary>
    /// Defines rules for user registration
    /// </summary>
    public class UserRegistrationValidator : AbstractValidator<UserViewModel>
    {
        /// <summary>
        /// 
        /// </summary>
        public UserRegistrationValidator()
        {
            var validator = DependencyResolver.Current.GetService<IUserValidator>();

            RuleFor(u => u.Login).NotEmpty()
                .WithMessage("Поле обязательно должно быть заполнено");
            RuleFor(u => u.Login).Matches("^[a-zA-Z0-9_.-]*$")
                .WithMessage("Только буквы латинского алфавита, цифры и знак подчеркивания");
            RuleFor(u => u.Login).Must(login => !validator.IsUserExist(login))
                .WithMessage("Пользователь с таким логином уже существует");
            RuleFor(u => u.Login).Length(4, 50)
                .WithMessage("Логин должен содержать не менее 4 символов");

            RuleFor(u => u.Password).NotEmpty()
                .WithMessage("Поле обязательно должно быть заполнено");
#if DEBUG
            RuleFor(u => u.Password)
                .Matches(@"^(?=.*\w)(?=.*\d)(?=.*[!-*]).[^\s]*$")
                .WithMessage("Пароль должен содержать символы латинского алфавита, цифры и спецсимволы");
#endif
            RuleFor(u => u.Password).Length(4, 50)
                .WithMessage("Пароль должен содержать не менее 4 символов");

            RuleFor(u => u.ConfirmPassword)
                    .Equal(u => u.Password)
                    .WithMessage("Пароли не совпадают. Повторите попытку");

            RuleFor(u => u.Email).EmailAddress()
                .WithMessage("Адрес электронной почты введен некорректно");
            RuleFor(u => u.Email).NotEmpty()
                .WithMessage("Поле обязательно должно быть заполнено");
            RuleFor(u => u.Email).Must(email => !validator.IsUserExist(email))
                .WithMessage("Пользователь с таким адресом электронной почты уже существект");
        }
    }
}
