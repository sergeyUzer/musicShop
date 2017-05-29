namespace PVT.Q1._2017.Shop.Areas.Content.Extentions
{
    using System.Web.Mvc;

    /// <summary>
    /// The buttons helper.
    /// </summary>
    public static class ButtonsHelper
    {
        /// <summary>
        /// Renders a button with icon.
        /// </summary>
        /// <param name="helper">
        ///     The helper.
        /// </param>
        /// <param name="class">
        ///     The button CSS class.
        /// </param>
        /// <param name="iconClass">
        ///     The button icon CSS class.
        /// </param>
        /// <param name="text">
        ///     The button text.
        /// </param>
        /// <param name="href">
        ///     The url to a page.
        /// </param>
        /// <param name="onclick">
        ///     On client click function. Optional.
        /// </param>
        /// <returns>
        /// The button html.
        /// </returns>
        public static MvcHtmlString ButtonWithIcon(
            this HtmlHelper helper,
            string @class,
            string iconClass,
            string text,
            string href,
            string onclick = null)
        {
            TagBuilder builder;
            if (!string.IsNullOrWhiteSpace(href))
            {
                builder = new TagBuilder("a");
                builder.Attributes["href"] = href;
            }
            else
            {
                builder = new TagBuilder("button");
            }
            builder.Attributes["class"] = @class;

            if (!string.IsNullOrWhiteSpace(onclick))
            {
                builder.Attributes["onclick"] = onclick;
            }

            builder.InnerHtml = $"<div><span class=\"{iconClass}\"></span> <span class=\"button-with-icon-text\">{text}</span></div>";
            return MvcHtmlString.Create(builder.ToString());
        }
    }
}