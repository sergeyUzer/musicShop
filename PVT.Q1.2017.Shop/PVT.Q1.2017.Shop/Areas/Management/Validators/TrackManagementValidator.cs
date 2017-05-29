namespace PVT.Q1._2017.Shop.Areas.Management.Validators
{
    using FluentValidation;
    using ViewModels;

    /// <summary>
    /// The <see cref="TrackManagementViewModel"/> validator
    /// </summary>
    public class TrackManagementValidator : AbstractValidator<TrackManagementViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrackManagementValidator"/> class.
        /// </summary>
        public TrackManagementValidator()
        {
            RuleFor(t => t.Name).NotEmpty().WithMessage("Укажите название трека");
            RuleFor(t => t.Name).Matches(@"^\S+(\s\S+)*$").WithMessage("Название трека указано не корректно");
            RuleFor(t => t.ArtistId).NotNull().WithMessage("Не указан исполнитель трека");
            RuleFor(t => t.GenreId).NotNull().WithMessage("Не указан жанр трека");
        }
    }
}