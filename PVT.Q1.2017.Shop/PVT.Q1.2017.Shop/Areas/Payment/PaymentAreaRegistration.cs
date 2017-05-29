namespace PVT.Q1._2017.Shop.Areas.Payment
{
    using System.Web.Mvc;

    /// <summary>
    /// The payment area registration.
    /// </summary>
    public class PaymentAreaRegistration : AreaRegistration 
    {
        /// <summary>
        /// Gets the area name.
        /// </summary>
        public override string AreaName 
        {
            get 
            {
                return "Payment";
            }
        }

        /// <summary>
        /// Registers the payment area.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Payment_default",
                "Payment/{controller}/{action}/{id}",
                             new { action = "Index", id = UrlParameter.Optional });
        }
    }
}