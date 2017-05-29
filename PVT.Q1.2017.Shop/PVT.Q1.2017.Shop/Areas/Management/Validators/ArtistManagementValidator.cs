namespace PVT.Q1._2017.Shop.Areas.Management.Validators
{
    using FluentValidation;
    using ViewModels;

    /// <summary>
    /// The <see cref="ArtistManagementViewModel"/> validator
    /// </summary>
    public class ArtistManagementValidator : AbstractValidator<ArtistManagementViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistManagementValidator"/> class.
        /// </summary>
        public ArtistManagementValidator()
        {
            RuleFor(t => t.Name).NotEmpty().WithMessage("Укажите имя исполнителя (название группы)");
            RuleFor(t => t.Name).Matches(@"^\S+(\s\S+)*$").WithMessage("Название имя исполнителя (название группы) указано не корректно");
        }
    }
}