namespace PVT.Q1._2017.Shop.Areas.News
{
    using System.Web.Mvc;

    /// <summary>
    /// </summary>
    public class NewsAreaRegistration : AreaRegistration
    {
        /// <summary>
        /// Gets the area name.
        /// </summary>
        public override string AreaName
        {
            get
            {
                return "News";
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "News_default",
                "News/{controller}/{action}/{partialName}",
                new { action = "Article", partialName = UrlParameter.Optional });
        }
    }
}