namespace PVT.Q1._2017.Shop.Areas.Content.Controllers
{
    using System.Web.Mvc;

    using global::Shop.BLL.Helpers;
    using global::Shop.BLL.Services.Infrastructure;
    using global::Shop.DAL.Infrastruture;
    using Shop.Controllers;

    /// <summary>
    /// </summary>
    public class GenresController : BaseController
    {
        public GenresController(IRepositoryFactory repositoryFactory, IServiceFactory serviceFactory) : base(repositoryFactory, serviceFactory)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="genreId">
        ///     The genre id.
        /// </param>
        /// <returns>
        /// </returns>
        public virtual ActionResult Details(int id)
        {
            using (var repository = RepositoryFactory.GetGenreRepository())
            {
                var model = repository.GetById(id);
                if (model == null)
                {
                    return View("_NotFound");
                }

                var viewModel = ModelsMapper.GetGenreDetailsViewModel(model);
                return View(viewModel);
            }
        }

        /// <summary>
        ///     Shows all albums.
        /// </summary>
        /// <returns>
        ///     All albums view.
        /// </returns>
        public ActionResult List()
        {
            var genreService = ServiceFactory.GetGenreService();
            return View(genreService.GetAllViewModels());
        }
    }
}