namespace Shop.Common.Validators
{
    using FluentValidation;
    using PVT.Q1._2017.Shop.ViewModels;

    /// <summary>
    /// 
    /// </summary>
    public class ForgotPassworValidator : AbstractValidator<ForgotPasswordViewModel>
    {
        /// <summary>
        /// 
        /// </summary>
        public ForgotPassworValidator()
        {
            RuleFor(u => u.UserIdentity).NotEmpty()
                .WithMessage("Поле не должно быть пустым");
        }
    }
}
