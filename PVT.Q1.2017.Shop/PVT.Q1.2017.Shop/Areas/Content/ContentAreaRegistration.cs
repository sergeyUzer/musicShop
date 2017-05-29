namespace PVT.Q1._2017.Shop.Areas.Content
{
    using System.Web.Mvc;

    /// <summary>
    /// The content area registration.
    /// </summary>
    public class ContentAreaRegistration : AreaRegistration 
    {
        /// <summary>
        /// Gets the area name.
        /// </summary>
        public override string AreaName
        {
            get { return "Content"; }
        }

        /// <summary>
        /// Registers the area.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Content_default",
                "Content/{controller}/{action}/{id}",
                new { action = "List", id = UrlParameter.Optional });
        }
    }
}