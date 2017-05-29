namespace PVT.Q1._2017.Shop.Areas.Management.Validators
{
    using FluentValidation;
    using ViewModels;

    /// <summary>
    /// The <see cref="AlbumManagementViewModel"/> validator.
    /// </summary>
    public class AlbumManagementValidator : AbstractValidator<AlbumManagementViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumManagementValidator"/> class.
        /// </summary>
        public AlbumManagementValidator()
        {
            RuleFor(a => a.Name).NotNull().WithMessage("Укажите название альбома");
            RuleFor(a => a.Name).Matches(@"^\S+(\s\S+)*$").WithMessage("Название альбома указано не корректно");
        }
    }
}