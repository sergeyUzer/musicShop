namespace PVT.Q1._2017.Shop.Areas.Management
{
    using System.Web.Mvc;

    /// <summary>
    /// The management area registration
    /// </summary>
    public class ManagementAreaRegistration : AreaRegistration 
    {
        /// <summary>
        /// Gets the area name.
        /// </summary>
        public override string AreaName
        {
            get { return "Management"; }
        }

        /// <summary>
        /// Registers the management area.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "Management_default",
                url: "Management/{controller}/{action}/{id}",
                defaults: new { controller = "Track", action = "AddOrUpdate", id = UrlParameter.Optional });
        }
    }
}